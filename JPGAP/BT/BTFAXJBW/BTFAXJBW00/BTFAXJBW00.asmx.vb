'***********************************************
' �Ή����e���ׁi�e�`�w�j�@���[�o�� (�������[�����M�Ή���)
' ID:BTFAXJBW00
'***********************************************
' �ύX����
' 2008/10/14 T.Watabe ���ڃ^�C�g���u�Ή����v���u���������v�ɕύX
' 2008/10/14 T.Watabe �o����З��Ɏ�M����(�o���w����������)�A�o��������ǉ�
' 2008/10/21 T.Watabe �o����Џ����敪�E���e��\��
' 2008/11/04 T.Watabe FAX1�����P�y�[�W�Ɏ��܂�Ȃ��̂�1�s�s�v�ȍs���o�͂��Ȃ��悤�ɕύX�B
' 2010/05/24 T.Watabe FAX���M��AҰّ��M��A���ꂼ�ꕡ���ݒ���\�ɉ��ǁB
' 2010/09/14 T.Watabe ��PG(BTFAXJAE00)������Q�Ƃł���悤��ҿ��ނ�ǉ�
'                           �������mExcel,�V�����mExcel2���Ăяo��
' 2010/09/15 T.Watabe DB SID��߂�ҿ��ނ�ǉ�
' 2010/09/17 T.Watabe FAX���ꖇ�Ɏ��܂�Ȃ��̂ŁA�k���g�嗦��93����90�֕ύX�B
' 2010/10/06 T.Watabe FAX���ꖇ�Ɏ��܂�Ȃ����̑Ή�(�]�������B�ް��������s�͋l�߂�)
' 2010/12/21 T.Watabe �ײ��đ��M�̍ۂ̏����s�����C��
' 2011/03/10 T.Watabe ���k�t�@�C�����̐擪�ɸײ��ĺ��ނ�t�^
' 2011/03/10 T.Watabe �����敪��3:FAX,Ұّ��M�����ɑΉ�����悤�ɕύX
' 2011/04/14 T.Watabe �v���O����ID��BTFAXJAW00�Ƃ͕ʂɕ�����B�i�����򕌊Ď��Z���^�[�ɉe����^���Ȃ��ׁj
' 2011/05/17 T.Watabe �ײ��đ��M������޳�Ͻ�.name='0'or'-'��FAX���M�ΏۊO(�K�{���ڂ̈�)
' 2011/05/20 T.Watabe �̔����������M�Ώۂ̓d�b��FAX�̒��o�����ɕs�������׏C���B
'                       �@AUTO_KUBUN=3�̍ہAFAX���M�悪�P���ł��AҰٱ��ڽ���Q�ȏ�ݒ�̏ꍇ�ɕ����񑗐M����Ă��܂��B
'                       �A�Ӑ}�I��fax���M���Ȃ������FAX�ԍ�[0]�Ȃǂ𑗐M�̍Ō�ɕύX�i���푗�M��D��j
' 2011/05/23 T.Watabe ���ۂɑΉ���������JA�ɑ΂��ĂO���񍐂�FAX�����M����Ă��܂����s��̉��C�B
'                       ��FAX�ԍ��̃n�C�t������������FAX�ԍ��̏d������������̂����A
'                         �㑱�����Ńn�C�t���L��FAX�ԍ��̃f�[�^���擾�ł����ɂO���񍐂ƂȂ��Ă��܂����B
' 2011/05/27 T.Watabe �N���C�A���g���M�̍ۂ́A�N���C�A���g�R�[�h���i�`�R�[�h�����������Ń\�[�g����悤�ɕύX�B
' 2011/05/27 T.Watabe �N���C�A���g���M�̍ۂ́A�N���C�A���g�����t�@�C���ɐݒ肷��悤�ɕύX�B�i�̔��X���M�́A�i�`���j
' 2011/06/14 T.Watabe D20_TAIOU���Y���̓��t�݂̂��炩���߃R�s�[����B
' 2011/11/14 H.Uema   �e�`�w�ԍ��n�C�t����菜�����`���ŏ������s���悤�ɕύX�B

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Configuration
Imports System.Text

'Imports java.util.zip 'vjslib.dll�ւ̎Q�Ɛݒ肪�K�v�ł� 
<System.Web.Services.WebService(Namespace:="http://tempuri.org/JPGAP.BTFAXJBW00/BTFAXJBW00")> _
Public Class BTFAXJBW00
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
        Dim cdb As New cdb
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
    <WebMethod()> Public Function mExcel2( _
                                        ByVal pstrKANSI_CODE As String, _
                                        ByVal pstrSESSION As String, _
                                        ByVal pstrTAISYOUBI As String, _
                                        ByVal pstrKURACD_F As String, _
                                        ByVal pstrKURACD_T As String, _
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
    '--- ��2005/09/10 MOD Falcon�� ---  '�����e�`�w���ߎ����폜
    '--- ��2005/09/06 MOD Falcon�� ---  '�����e�`�w���ߎ����ǉ�
    ' ����
    ' pstrSEND_KBN ���M�敪 1:�̔���(JA�E�x��)/2:�ײ���
    ' pintDebugSQLNo SQL�f�o�b�O�p�� 0:�f�o�b�O�Ȃ�/1�`:�f�o�b�O����
    <WebMethod()> Public Function mExcel3( _
                                        ByVal pstrKANSI_CODE As String, _
                                        ByVal pstrSESSION As String, _
                                        ByVal pstrTAISYOUBI As String, _
                                        ByVal pstrKURACD_F As String, _
                                        ByVal pstrKURACD_T As String, _
                                        ByVal pstrCreateFilePath As String, _
                                        ByVal pstrSEND_JALP_NAME As String, _
                                        ByVal pstrSEND_CENT_NAME As String, _
                                        ByVal pstrSEND_KBN As String, _
                                        ByVal pintDebugSQLNo As Integer _
                                       ) As String
        '--- ��2005/09/06 MOD Falcon�� ---
        '--- ��2005/09/10 MOD Falcon�� ---

        '--------------------------------------------------
        '�����e�`�w�ԍ��ɓ��͂��ꂽ�ԍ����ɂe�`�w���M�E�t�@�C���쐬���s��
        Dim cdb As New cdb
        Dim strSQL As New StringBuilder("")
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String
        Dim GUID As String = System.Guid.NewGuid().ToString() ' 2011/06/14 T.Watabe add


        '--------------------------------------------------
        '�v���O�����h�c(�쐬���[�Ɏg�p)
        strPGID = "BTFAXJAX00"

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
        If pstrSEND_KBN = "1" Then '���M�敪 1:�̔���(JA�E�x��)/2:�ײ���
            strWHERE_TAIOU.Append("  AND TAI.FAXKBN = '2' " & vbCrLf)            '//�e�`�w�K�v(JA)
        Else
            strWHERE_TAIOU.Append("  AND TAI.FAXKURAKBN = '2' " & vbCrLf)        '//�e�`�w�K�v(�ײ��ċ������)
        End If
        strWHERE_TAIOU.Append("  AND TAI.TMSKB = '2' " & vbCrLf)             '//�����ς�
        '--- ��2005/09/10 MOD Falcon�� ---  
        '2005/09/06�̏C�������ɖ߂�
        strWHERE_TAIOU.Append("  AND ( " & vbCrLf)
        strWHERE_TAIOU.Append("          (TAI.SYOYMD || TAI.SYOTIME > '" & strTaisyoStDT & "' " & vbCrLf)
        strWHERE_TAIOU.Append("          AND TAI.SYOYMD || TAI.SYOTIME   <='" & strTaisyoEdDT & "') " & vbCrLf)
        '--- ��2005/09/06 MOD Falcon�� ---
        '�����e�`�w���ߎ������Ď��Z���^�[����exeCONFIG�t�@�C���ɐݒ�
        'strWHERE_TAIOU.Append("  AND ((TAI.SYOYMD || TAI.SYOTIME > '" & fncAdd_Date(pstrTAISYOUBI, -1) & pstrJIDOFAXSIME & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOYMD || TAI.SYOTIME   <='" & pstrTAISYOUBI & pstrJIDOFAXSIME & "') ")
        'strWHERE_TAIOU.Append("  AND ((TAI.SYOYMD || TAI.SYOTIME > '" & strTaisyoStDT & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOYMD || TAI.SYOTIME   <='" & strTaisyoEdDT & "') ")
        '--- ��2005/09/06 MOD Falcon�� ---
        '--- ��2005/09/10 MOD Falcon�� ---

        '--- ��2005/09/10 MOD Falcon�� --- 
        '2005/09/06�̏C�������ɖ߂�
        strWHERE_TAIOU.Append("      OR  " & vbCrLf)
        strWHERE_TAIOU.Append("          (TAI.SYOKANYMD || TAI.SYOKANTIME > '" & strTaisyoStDT & "' " & vbCrLf)
        strWHERE_TAIOU.Append("          AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "') " & vbCrLf)
        strWHERE_TAIOU.Append("      ) " & vbCrLf)
        '--- ��2005/09/06 MOD Falcon�� ---
        '�����e�`�w���ߎ������Ď��Z���^�[����exeCONFIG�t�@�C���ɐݒ�
        'strWHERE_TAIOU.Append("  OR (TAI.SYOKANYMD || TAI.SYOKANTIME > '" & fncAdd_Date(pstrTAISYOUBI, -1) & pstrJIDOFAXSIME & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & pstrTAISYOUBI & pstrJIDOFAXSIME & "')) ")
        '--- ��2005/05/23 MOD Falcon�� ---
        'strWHERE_TAIOU.Append("  OR (TAI.SYOKANYMD || TAI.SYOKANTIME > '" & strTaisyoStDT & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "')) ")
        'strWHERE_TAIOU.Append("  OR (TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOKANYMD || TAI.SYOKANTIME <='" & strTaisyoEdDT & "')) ")
        '--- ��2005/05/19 MOD Falcon�� ---
        '�����������A�����������Ԃ������ɒǉ�(OR)
        'strWHERE_TAIOU.Append("  AND TAI.SYOYMD || TAI.SYOTIME > '" & strTaisyoStDT & "' ")
        'strWHERE_TAIOU.Append("  AND TAI.SYOYMD || TAI.SYOTIME <='" & strTaisyoEdDT & "' ")
        '--- ��2005/05/19 MOD Falcon�� ---
        '--- ��2005/05/23 MOD Falcon�� ---
        '--- ��2005/09/06 MOD Falcon�� ---
        '--- ��2005/09/10 MOD Falcon�� ---

        '--- ��2005/09/10 ADD Falcon�� ---
        '�N���C�A���g�R�[�h�͈͎̔w���ǉ�
        If pstrKURACD_F.Length > 0 Then
            strWHERE_TAIOU.Append("  AND TAI.KURACD >= '" & pstrKURACD_F & "' " & vbCrLf)
            strWHERE_CLI.Append("  AND CLI.CLI_CD >= '" & pstrKURACD_F & "' " & vbCrLf) '2010/12/21 T.Watabe add
        End If
        If pstrKURACD_T.Length > 0 Then
            strWHERE_TAIOU.Append("  AND TAI.KURACD <= '" & pstrKURACD_T & "' " & vbCrLf)
            strWHERE_CLI.Append("  AND CLI.CLI_CD <= '" & pstrKURACD_T & "' " & vbCrLf) '2010/12/21 T.Watabe add
        End If

        '�Ď��Z���^�[�R�[�h��ǉ��i��ʂŕK�{�H�Ȃ̂ł����Œǉ��j
        strWHERE_TAIOU.Append("         AND TAI.KANSCD  = '" & pstrKANSI_CODE & "' " & vbCrLf) '2011/05/20 T.Watabe add
        strWHERE_CLI.Append("         AND CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' " & vbCrLf) '2011/05/20 T.Watabe add
        '--- ��2005/09/10 ADD Falcon�� ---

        Dim strWHERE_TAIOU_COPY As New StringBuilder("") '2011/06/14 T.Watabe add
        strWHERE_TAIOU_COPY.Append(strWHERE_TAIOU)
        strWHERE_TAIOU.Append("         AND TAI.GUID  = '" & GUID & "' " & vbCrLf) '2011/06/14 T.Watabe add

        Try
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
            strRec = "ERROR:" & ex.ToString
            cdb.mClose() '�ڑ��N���[�Y
            Return strRec
        Finally
        End Try

        '--------------------------------------------------
        Try
            '�f�[�^��SELECT
            strSQL = New StringBuilder("")
            'SQL�쐬�J�n
            If True Then
                '--- 2005/05/19 MOD Falcon ---      AUTO��AUTO_KUBUN
                'strSQL.Append("SELECT ")
                'strSQL.Append("    AUTO_KUBUN, ")
                'strSQL.Append("    AUTO_FAX, ")
                'strSQL.Append("    AUTO_MAIL, ")
                'strSQL.Append("    MAX(HATYMD) AS HATYMD ") ' 2007/09/18 T.Watabe add �\�[�g�ɔ��������ǉ�
                'strSQL.Append("FROM ")
                'strSQL.Append("( ")
                'strSQL.Append("    SELECT ")
                'strSQL.Append("        JAS.AUTO_KUBUN, ")
                'strSQL.Append("        DECODE(JAS.AUTO_KUBUN,1,JAS.AUTO_FAX,'') AS AUTO_FAX, ")
                'strSQL.Append("        DECODE(JAS.AUTO_KUBUN,2,JAS.AUTO_MAIL,'') AS AUTO_MAIL, ")
                'strSQL.Append("        TAI.HATYMD || '-' || TAI.HATTIME AS HATYMD ") ' 2007/09/18 T.Watabe add
                'strSQL.Append("    FROM ")
                'strSQL.Append("        CLIMAS CLI,")
                'strSQL.Append("        HN2MAS JAS, ")
                'strSQL.Append("        D20_TAIOU TAI ")
                'strSQL.Append("    WHERE ")
                'strSQL.Append("            CLI.KANSI_CODE  = :KANSI_CODE")
                'strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD")
                'strSQL.Append("        AND (JAS.AUTO_KUBUN = '" & strFAXKBN & "' OR JAS.AUTO_KUBUN = '" & strMAILKBN & "') ")
                'strSQL.Append("        AND JAS.CLI_CD      = TAI.KURACD ")
                'strSQL.Append("        AND JAS.HAN_CD      = TAI.ACBCD ")
                'strSQL.Append(strWHERE_TAIOU.ToString)
                'strSQL.Append(") ")
                'strSQL.Append("GROUP BY AUTO_KUBUN, AUTO_FAX, AUTO_MAIL ")
                'strSQL.Append("ORDER BY AUTO_FAX, AUTO_MAIL, HATYMD ") ' 2007/09/18 T.Watabe add
                If pstrSEND_KBN = "1" Then '���M�敪 1:�̔���(JA�E�x��)/2:�ײ���
                    '2011/03/27 T.Watabe Ұٱ��ڽ�Q�Ɛ��S���}�X�^�ɕύX�B��\JA�ɂ��Ή�(�x�����Ƃ̎w��ł͂Ȃ��A��\��JA�̂�ұ�ނ��w�肵�Ă���ꍇ)
                    'strSQL.Append("SELECT  ")
                    'strSQL.Append("    AUTO_KUBUN,  ")
                    'strSQL.Append("    AUTO_FAX, ")
                    'strSQL.Append("    AUTO_MAIL, ")
                    'strSQL.Append("    SUM(TAIOU) AS CNT ") '���̌������O�́A�O�����M���s���B
                    'strSQL.Append("FROM ")
                    'strSQL.Append("( ")
                    'strSQL.Append("    SELECT  ") '�Ώۇ@ AUTO_FAX �� AUTO_MAIL�i�����j
                    'strSQL.Append("        JAS.AUTO_KUBUN,  ")
                    ''strSQL.Append("        DECODE(JAS.AUTO_KUBUN,1,JAS.AUTO_FAX,'') AS AUTO_FAX,  ") ' 2011/03/10 T.Watabe edit
                    ''strSQL.Append("        DECODE(JAS.AUTO_KUBUN,2,JAS.AUTO_MAIL,'') AS AUTO_MAIL, ")
                    'strSQL.Append("        JAS.AUTO_FAX AS AUTO_FAX,  ")
                    'strSQL.Append("        JAS.AUTO_MAIL AS AUTO_MAIL, ")
                    'strSQL.Append("        DECODE(T.ACBCD, NULL, 0, 1) AS TAIOU ")
                    'strSQL.Append("    FROM  ")
                    'strSQL.Append("        CLIMAS CLI, ")
                    'strSQL.Append("        HN2MAS JAS, ")
                    'strSQL.Append("        D20_TAIOU T ")
                    'strSQL.Append("    WHERE  ")
                    'strSQL.Append("            CLI.KANSI_CODE  = :KANSI_CODE")
                    'strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD")
                    ''strSQL.Append("        AND (JAS.AUTO_KUBUN = '" & strFAXKBN & "' OR JAS.AUTO_KUBUN = '" & strMAILKBN & "') ") ' 2011/03/10 T.Watabe edit
                    'strSQL.Append("        AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strMAILKBN & "', '" & strBoth & "') ")
                    'strSQL.Append("        AND T.KURACD (+)= JAS.CLI_CD ")
                    'strSQL.Append("        AND T.ACBCD  (+)= JAS.HAN_CD ")
                    'strSQL.Append("        AND ( ")
                    'strSQL.Append("                EXISTS ( ") ' 0���񍐈ȊO�̏ꍇ�A�����ő��݃f�[�^��ΏۂƂ���
                    'strSQL.Append("                    SELECT *  ")
                    'strSQL.Append("                    FROM D20_TAIOU TAI ")
                    'strSQL.Append("                    WHERE  ")
                    'strSQL.Append("                            JAS.CLI_CD = TAI.KURACD  ")
                    'strSQL.Append("                        AND JAS.HAN_CD = TAI.ACBCD  ")
                    'strSQL.Append(strWHERE_TAIOU.ToString)
                    'strSQL.Append("                ) ")
                    'strSQL.Append("                OR  ")
                    'strSQL.Append("                (JAS.YOBI3 = '1' AND T.ACBCD IS NULL) ") '�\���R��1(0���񍐂�����)���Ή��f�[�^���Ȃ�(0��)
                    'strSQL.Append("            ) ")
                    'strSQL.Append("    UNION ALL ") ' 2010/05/24 T.Watabe add TELA_FAX1&TELB_FAX1�p�̒��o
                    'strSQL.Append("    SELECT  ") '�ΏۇA TELA_FAX1&TELB_FAX1
                    'strSQL.Append("        JAS.AUTO_KUBUN,  ")
                    ''strSQL.Append("        DECODE(JAS.AUTO_KUBUN, 1, RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1),'') AS AUTO_FAX,  ") ' 2011/03/10 T.Watabe edit ' 2010/05/24 T.Watabe add
                    'strSQL.Append("        RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) AS AUTO_FAX,  ")
                    'strSQL.Append("        NULL AS AUTO_MAIL, ")
                    'strSQL.Append("        DECODE(T.ACBCD, NULL, 0, 1) AS TAIOU ")
                    'strSQL.Append("    FROM  ")
                    'strSQL.Append("        CLIMAS CLI, ")
                    'strSQL.Append("        HN2MAS JAS, ")
                    'strSQL.Append("        D20_TAIOU T ")
                    'strSQL.Append("    WHERE  ")
                    'strSQL.Append("            CLI.KANSI_CODE  = :KANSI_CODE")
                    'strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD")
                    ''strSQL.Append("        AND JAS.AUTO_KUBUN = '" & strFAXKBN & "' ")
                    'strSQL.Append("        AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strBoth & "') ")
                    'strSQL.Append("        AND (JAS.TELA_FAX1 || TELB_FAX1) IS NOT NULL ")
                    'strSQL.Append("        AND T.KURACD (+)= JAS.CLI_CD ")
                    'strSQL.Append("        AND T.ACBCD  (+)= JAS.HAN_CD ")
                    'strSQL.Append("        AND ( ")
                    'strSQL.Append("                EXISTS ( ")
                    'strSQL.Append("                    SELECT *  ")
                    'strSQL.Append("                    FROM D20_TAIOU TAI ")
                    'strSQL.Append("                    WHERE  ")
                    'strSQL.Append("                            JAS.CLI_CD = TAI.KURACD  ")
                    'strSQL.Append("                        AND JAS.HAN_CD = TAI.ACBCD  ")
                    'strSQL.Append(strWHERE_TAIOU.ToString)
                    'strSQL.Append("                ) ")
                    'strSQL.Append("                OR  ")
                    'strSQL.Append("                (JAS.YOBI3 = '1' AND T.ACBCD IS NULL) ") '�\���R��1(0���񍐂�����)���Ή��f�[�^���Ȃ�(0��)
                    'strSQL.Append("            ) ")
                    'strSQL.Append(")  ")
                    'strSQL.Append("GROUP BY AUTO_KUBUN, AUTO_FAX, AUTO_MAIL ")
                    'strSQL.Append("ORDER BY AUTO_KUBUN, AUTO_FAX, AUTO_MAIL ")
                    ' 2011/05/20 T.Watabe edit
                    'If False Then
                    '    strSQL.Append("SELECT  " & vbCrLf)
                    '    strSQL.Append("    A.AUTO_KUBUN,  " & vbCrLf)
                    '    strSQL.Append("    A.AUTO_FAX, " & vbCrLf)
                    '    strSQL.Append("    DECODE(B.AUTO_MAIL, NULL, C.AUTO_MAIL, B.AUTO_MAIL) AS AUTO_MAIL, " & vbCrLf)
                    '    'strSQL.Append("    SUM(A.TAIOU) AS CNT " & vbCrLf) '���̌������O�́A�O�����M���s���B
                    '    strSQL.Append("    0 AS CNT " & vbCrLf) '���̌������O�́A�O�����M���s���B ' 2011/05/19
                    '    strSQL.Append("FROM " & vbCrLf)
                    '    strSQL.Append("( " & vbCrLf)
                    '    strSQL.Append("    SELECT  " & vbCrLf) '�Ώۇ@ AUTO_FAX �� AUTO_MAIL�i�����j
                    '    strSQL.Append("        JAS.CLI_CD,  " & vbCrLf)
                    '    strSQL.Append("        JAS.HAN_CD,  " & vbCrLf)
                    '    strSQL.Append("        JAS.JA_CD ,  " & vbCrLf)
                    '    strSQL.Append("        JAS.AUTO_KUBUN,  " & vbCrLf)
                    '    'strSQL.Append("        DECODE(JAS.AUTO_KUBUN,1,JAS.AUTO_FAX,'') AS AUTO_FAX,  ") ' 2011/03/10 T.Watabe edit
                    '    'strSQL.Append("        DECODE(JAS.AUTO_KUBUN,2,JAS.AUTO_MAIL,'') AS AUTO_MAIL, ")
                    '    strSQL.Append("        JAS.AUTO_FAX AS AUTO_FAX,  " & vbCrLf)
                    '    strSQL.Append("        JAS.AUTO_MAIL AS AUTO_MAIL /* ���̱��ڽ�͎g��Ȃ��BNULL�ł����܂�Ȃ� */ " & vbCrLf)
                    '    'strSQL.Append("        DECODE(T.ACBCD, NULL, 0, 1) AS TAIOU " & vbCrLf) ' 2011/05/19
                    '    strSQL.Append("    FROM  " & vbCrLf)
                    '    strSQL.Append("        CLIMAS CLI, " & vbCrLf)
                    '    strSQL.Append("        HN2MAS JAS " & vbCrLf)
                    '    'strSQL.Append("        D20_TAIOU T " & vbCrLf) ' 2011/05/19 del
                    '    strSQL.Append("    WHERE  " & vbCrLf)
                    '    strSQL.Append("            CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    '    strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD" & vbCrLf)
                    '    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    '    'strSQL.Append("        AND (JAS.AUTO_KUBUN = '" & strFAXKBN & "' OR JAS.AUTO_KUBUN = '" & strMAILKBN & "') ") ' 2011/03/10 T.Watabe edit
                    '    strSQL.Append("        AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    '    'strSQL.Append("        AND T.KURACD (+)= JAS.CLI_CD " & vbCrLf) ' 2011/05/19
                    '    'strSQL.Append("        AND T.ACBCD  (+)= JAS.HAN_CD " & vbCrLf) ' 2011/05/19
                    '    strSQL.Append("        AND ( " & vbCrLf)
                    '    strSQL.Append("                EXISTS ( " & vbCrLf) ' 0���񍐈ȊO�̏ꍇ�A�����ő��݃f�[�^��ΏۂƂ���
                    '    strSQL.Append("                    SELECT *  " & vbCrLf)
                    '    strSQL.Append("                    FROM D20_TAIOU TAI " & vbCrLf)
                    '    strSQL.Append("                    WHERE  " & vbCrLf)
                    '    strSQL.Append("                            JAS.CLI_CD = TAI.KURACD  " & vbCrLf)
                    '    strSQL.Append("                        AND JAS.HAN_CD = TAI.ACBCD  " & vbCrLf)
                    '    strSQL.Append(strWHERE_TAIOU.ToString)
                    '    strSQL.Append("                ) " & vbCrLf)
                    '    strSQL.Append("            OR  " & vbCrLf) ' 2011/05/19 edit
                    '    'strSQL.Append("                (JAS.YOBI3 = '1' AND T.ACBCD IS NULL) " & vbCrLf) '�\���R��1(0���񍐂�����)���Ή��f�[�^���Ȃ�(0��)
                    '    strSQL.Append("                (" & vbCrLf)
                    '    strSQL.Append("                    JAS.YOBI3 = '1' " & vbCrLf) '�\���R��1(0���񍐂�����)
                    '    strSQL.Append("                AND " & vbCrLf)
                    '    strSQL.Append("                    NOT EXISTS ( " & vbCrLf) '�Ή��f�[�^���Ȃ�(0��)
                    '    strSQL.Append("                        SELECT *  " & vbCrLf)
                    '    strSQL.Append("                        FROM D20_TAIOU TAI " & vbCrLf)
                    '    strSQL.Append("                        WHERE  " & vbCrLf)
                    '    strSQL.Append("                                JAS.CLI_CD = TAI.KURACD  " & vbCrLf)
                    '    strSQL.Append("                            AND JAS.HAN_CD = TAI.ACBCD  " & vbCrLf)
                    '    strSQL.Append(strWHERE_TAIOU.ToString)
                    '    strSQL.Append("                    ) " & vbCrLf)
                    '    strSQL.Append("                ) " & vbCrLf)
                    '    strSQL.Append("            ) " & vbCrLf)
                    '    strSQL.Append("    UNION ALL " & vbCrLf) ' 2010/05/24 T.Watabe add TELA_FAX1&TELB_FAX1�p�̒��o
                    '    strSQL.Append("    SELECT  " & vbCrLf) '�ΏۇA TELA_FAX1&TELB_FAX1
                    '    strSQL.Append("        JAS.CLI_CD,  " & vbCrLf)
                    '    strSQL.Append("        JAS.HAN_CD,  " & vbCrLf)
                    '    strSQL.Append("        JAS.JA_CD ,  " & vbCrLf)
                    '    strSQL.Append("        JAS.AUTO_KUBUN,  " & vbCrLf)
                    '    'strSQL.Append("        DECODE(JAS.AUTO_KUBUN, 1, RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1),'') AS AUTO_FAX,  ") ' 2011/03/10 T.Watabe edit ' 2010/05/24 T.Watabe add
                    '    strSQL.Append("        RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) AS AUTO_FAX,  " & vbCrLf)
                    '    strSQL.Append("        NULL AS AUTO_MAIL " & vbCrLf)
                    '    'strSQL.Append("        DECODE(T.ACBCD, NULL, 0, 1) AS TAIOU " & vbCrLf) ' 2011/05/19
                    '    strSQL.Append("    FROM  " & vbCrLf)
                    '    strSQL.Append("        CLIMAS CLI, " & vbCrLf)
                    '    strSQL.Append("        HN2MAS JAS " & vbCrLf)
                    '    'strSQL.Append("        D20_TAIOU T " & vbCrLf) ' 2011/05/19 del
                    '    strSQL.Append("    WHERE  " & vbCrLf)
                    '    strSQL.Append("            CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    '    strSQL.Append("        AND CLI.CLI_CD      = JAS.CLI_CD" & vbCrLf)
                    '    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    '    'strSQL.Append("        AND JAS.AUTO_KUBUN = '" & strFAXKBN & "' ")
                    '    strSQL.Append("        AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    '    strSQL.Append("        AND (JAS.TELA_FAX1 || TELB_FAX1) IS NOT NULL " & vbCrLf)
                    '    'strSQL.Append("        AND T.KURACD (+)= JAS.CLI_CD " & vbCrLf)
                    '    'strSQL.Append("        AND T.ACBCD  (+)= JAS.HAN_CD " & vbCrLf)
                    '    strSQL.Append("        AND ( " & vbCrLf)
                    '    strSQL.Append("                EXISTS ( " & vbCrLf)
                    '    strSQL.Append("                    SELECT *  " & vbCrLf)
                    '    strSQL.Append("                    FROM D20_TAIOU TAI " & vbCrLf)
                    '    strSQL.Append("                    WHERE  " & vbCrLf)
                    '    strSQL.Append("                            JAS.CLI_CD = TAI.KURACD  " & vbCrLf)
                    '    strSQL.Append("                        AND JAS.HAN_CD = TAI.ACBCD  " & vbCrLf)
                    '    strSQL.Append(strWHERE_TAIOU.ToString)
                    '    strSQL.Append("                ) " & vbCrLf)
                    '    strSQL.Append("            OR  " & vbCrLf) ' 2011/05/19 edit
                    '    'strSQL.Append("                (JAS.YOBI3 = '1' AND T.ACBCD IS NULL) " & vbCrLf) '�\���R��1(0���񍐂�����)���Ή��f�[�^���Ȃ�(0��)
                    '    strSQL.Append("                (" & vbCrLf)
                    '    strSQL.Append("                    JAS.YOBI3 = '1' " & vbCrLf) '�\���R��1(0���񍐂�����)
                    '    strSQL.Append("                AND " & vbCrLf)
                    '    strSQL.Append("                    NOT EXISTS ( " & vbCrLf) '�Ή��f�[�^���Ȃ�(0��)
                    '    strSQL.Append("                        SELECT *  " & vbCrLf)
                    '    strSQL.Append("                        FROM D20_TAIOU TAI " & vbCrLf)
                    '    strSQL.Append("                        WHERE  " & vbCrLf)
                    '    strSQL.Append("                                JAS.CLI_CD = TAI.KURACD  " & vbCrLf)
                    '    strSQL.Append("                            AND JAS.HAN_CD = TAI.ACBCD  " & vbCrLf)
                    '    strSQL.Append(strWHERE_TAIOU.ToString)
                    '    strSQL.Append("                    ) " & vbCrLf)
                    '    strSQL.Append("                ) " & vbCrLf)
                    '    strSQL.Append("            ) " & vbCrLf)
                    '    strSQL.Append("    ) A, " & vbCrLf)
                    '    strSQL.Append("    M05_TANTO B, " & vbCrLf)
                    '    strSQL.Append("    M05_TANTO C " & vbCrLf)
                    '    strSQL.Append("WHERE " & vbCrLf)
                    '    strSQL.Append("        B.KURACD (+)= RTRIM(A.CLI_CD) " & vbCrLf)
                    '    strSQL.Append("    AND B.CODE   (+)= RTRIM(A.HAN_CD) " & vbCrLf)
                    '    strSQL.Append("    AND B.KBN    (+)= '3' " & vbCrLf)
                    '    strSQL.Append("    AND B.AUTO_MAIL (+)IS NOT NULL " & vbCrLf)
                    '    strSQL.Append("    AND C.KURACD (+)= RTRIM(A.CLI_CD) " & vbCrLf)
                    '    strSQL.Append("    AND C.CODE   (+)= RTRIM(A.JA_CD) " & vbCrLf)
                    '    strSQL.Append("    AND C.KBN    (+)= '3' " & vbCrLf)
                    '    strSQL.Append("    AND C.AUTO_MAIL (+)IS NOT NULL " & vbCrLf)
                    '    strSQL.Append("GROUP BY  " & vbCrLf)
                    '    strSQL.Append("    A.AUTO_KUBUN,  " & vbCrLf)
                    '    strSQL.Append("    A.AUTO_FAX,  " & vbCrLf)
                    '    strSQL.Append("    DECODE(B.AUTO_MAIL, NULL, C.AUTO_MAIL, B.AUTO_MAIL) " & vbCrLf)
                    '    strSQL.Append("HAVING " & vbCrLf) '2011/05/19 T.Watabe add
                    '    strSQL.Append("    (A.AUTO_FAX IS NOT NULL OR DECODE(B.AUTO_MAIL, NULL, C.AUTO_MAIL, B.AUTO_MAIL) IS NOT NULL) " & vbCrLf) '2011/05/19 T.Watabe add
                    '    strSQL.Append("ORDER BY  " & vbCrLf)
                    '    strSQL.Append("    AUTO_KUBUN,  " & vbCrLf)
                    '    strSQL.Append("    AUTO_FAX,  " & vbCrLf)
                    '    strSQL.Append("    AUTO_MAIL  " & vbCrLf)
                    'End If
                    strSQL.Append("WITH JAS AS ( /* JAS�F�ΏۂƂȂ�HN2MAS�f�[�^ */" & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("        J.CLI_CD,  " & vbCrLf)
                    strSQL.Append("        J.HAN_CD,  " & vbCrLf)
                    strSQL.Append("        J.JA_CD ,  " & vbCrLf)
                    strSQL.Append("        J.AUTO_KUBUN," & vbCrLf)
                    strSQL.Append("        J.YOBI3," & vbCrLf)
                    strSQL.Append("        J.AUTO_FAX,  " & vbCrLf)
                    strSQL.Append("        J.AUTO_MAIL AS AUTO_MAIL /* ���̱��ڽ�͎g��Ȃ��BNULL�ł����܂�Ȃ� */ " & vbCrLf)
                    strSQL.Append("    FROM  " & vbCrLf)
                    strSQL.Append("        CLIMAS CLI, " & vbCrLf)
                    strSQL.Append("        HN2MAS J " & vbCrLf)
                    strSQL.Append("    WHERE 1=1 " & vbCrLf)
                    strSQL.Append("        AND CLI.CLI_CD      = J.CLI_CD " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append("        AND J.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append(")," & vbCrLf)
                    strSQL.Append("T AS ( /* T:�ΏۂƂȂ�Ή��f�[�^��KURACD��ACBCD */" & vbCrLf)
                    strSQL.Append("    SELECT" & vbCrLf)
                    strSQL.Append("        DISTINCT" & vbCrLf)
                    strSQL.Append("        TAI.KURACD," & vbCrLf)
                    strSQL.Append("        TAI.ACBCD" & vbCrLf)
                    'strSQL.Append("    FROM D20_TAIOU TAI " & vbCrLf) ' D20_TAIOU_COPY���g�p 2011/06/14
                    strSQL.Append("    FROM D20_TAIOU_COPY TAI " & vbCrLf)
                    strSQL.Append("    WHERE 1=1 " & vbCrLf)
                    strSQL.Append(strWHERE_TAIOU.ToString)
                    strSQL.Append(") " & vbCrLf)
                    strSQL.Append("/* FAX�� */ " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("        '1' AS AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("        DECODE(LENGTH(A.AUTO_FAX), 1, 2, 1) AS AUTO_FAX_SORT, " & vbCrLf)
                    strSQL.Append("        A.AUTO_FAX, " & vbCrLf)
                    strSQL.Append("        NULL AS AUTO_MAIL, " & vbCrLf)
                    strSQL.Append("        0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM " & vbCrLf)
                    strSQL.Append("        ( " & vbCrLf)
                    strSQL.Append("            /* �@ 0���񍐂���(FAX) */" & vbCrLf)
                    strSQL.Append("            SELECT  " & vbCrLf)
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- START
                    ' FAX�ԍ��̃n�C�t������菜���悤��SQL���C��("REPLACE(JAS.AUTO_FAX, '-')")
                    'strSQL.Append("                JAS.AUTO_FAX " & vbCrLf) 'DEL
                    strSQL.Append(ReplaceHyphen("JAS.AUTO_FAX") & " AS AUTO_FAX " & vbCrLf) 'ADD
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- END
                    strSQL.Append("            FROM  " & vbCrLf)
                    strSQL.Append("                JAS " & vbCrLf)
                    strSQL.Append("            WHERE " & vbCrLf)
                    strSQL.Append("                    JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("                AND JAS.YOBI3 = '1'" & vbCrLf)
                    strSQL.Append("                AND JAS.AUTO_FAX IS NOT NULL" & vbCrLf)
                    strSQL.Append("        UNION" & vbCrLf)
                    strSQL.Append("            /* �A �Ή��f�[�^����(FAX) */" & vbCrLf)
                    strSQL.Append("            SELECT  " & vbCrLf)
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- START
                    'strSQL.Append("                JAS.AUTO_FAX " & vbCrLf) 'DEL
                    strSQL.Append(ReplaceHyphen("JAS.AUTO_FAX") & " AS AUTO_FAX " & vbCrLf) 'ADD
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- END
                    strSQL.Append("            FROM  " & vbCrLf)
                    strSQL.Append("                JAS," & vbCrLf)
                    strSQL.Append("                T" & vbCrLf)
                    strSQL.Append("            WHERE " & vbCrLf)
                    strSQL.Append("                    JAS.AUTO_KUBUN IN ('" & strFAXKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("                AND JAS.AUTO_FAX IS NOT NULL" & vbCrLf)
                    strSQL.Append("                AND JAS.CLI_CD = T.KURACD  " & vbCrLf)
                    strSQL.Append("                AND JAS.HAN_CD = T.ACBCD  " & vbCrLf)
                    strSQL.Append("        ) A" & vbCrLf)
                    strSQL.Append("    GROUP BY " & vbCrLf)
                    strSQL.Append("        A.AUTO_FAX" & vbCrLf)
                    strSQL.Append("UNION " & vbCrLf)
                    strSQL.Append("/* Ұٕ� */ " & vbCrLf)
                    strSQL.Append("    SELECT  " & vbCrLf)
                    strSQL.Append("        '2' AS AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("        NULL AS AUTO_FAX_SORT, " & vbCrLf)
                    strSQL.Append("        NULL AS AUTO_FAX, " & vbCrLf)
                    strSQL.Append("        DECODE(B.AUTO_MAIL, NULL, C.AUTO_MAIL, B.AUTO_MAIL) AS AUTO_MAIL, " & vbCrLf)
                    strSQL.Append("        0 AS CNT " & vbCrLf)
                    strSQL.Append("    FROM " & vbCrLf)
                    strSQL.Append("        ( " & vbCrLf)
                    strSQL.Append("            /* �B0���񍐂���(Ұ�) */" & vbCrLf)
                    strSQL.Append("            SELECT  " & vbCrLf)
                    strSQL.Append("                JAS.CLI_CD,  " & vbCrLf)
                    strSQL.Append("                JAS.HAN_CD,  " & vbCrLf)
                    strSQL.Append("                JAS.JA_CD " & vbCrLf)
                    strSQL.Append("            FROM  " & vbCrLf)
                    strSQL.Append("                JAS " & vbCrLf)
                    strSQL.Append("            WHERE " & vbCrLf)
                    strSQL.Append("                    JAS.AUTO_KUBUN IN ('" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("                AND JAS.YOBI3 = '1'" & vbCrLf)
                    strSQL.Append("        UNION" & vbCrLf)
                    strSQL.Append("            /* �C �Ή��f�[�^����(FAX) */" & vbCrLf)
                    strSQL.Append("            SELECT  " & vbCrLf)
                    strSQL.Append("                JAS.CLI_CD,  " & vbCrLf)
                    strSQL.Append("                JAS.HAN_CD,  " & vbCrLf)
                    strSQL.Append("                JAS.JA_CD " & vbCrLf)
                    strSQL.Append("            FROM  " & vbCrLf)
                    strSQL.Append("                JAS, " & vbCrLf)
                    strSQL.Append("                T " & vbCrLf)
                    strSQL.Append("            WHERE " & vbCrLf)
                    strSQL.Append("                    JAS.AUTO_KUBUN IN ('" & strMAILKBN & "', '" & strBoth & "') " & vbCrLf)
                    strSQL.Append("                AND JAS.CLI_CD = T.KURACD  " & vbCrLf)
                    strSQL.Append("                AND JAS.HAN_CD = T.ACBCD " & vbCrLf)
                    strSQL.Append("        ) A, " & vbCrLf)
                    strSQL.Append("        M05_TANTO B, " & vbCrLf)
                    strSQL.Append("        M05_TANTO C " & vbCrLf)
                    strSQL.Append("    WHERE " & vbCrLf)
                    strSQL.Append("            B.KURACD (+)= RTRIM(A.CLI_CD) " & vbCrLf)
                    strSQL.Append("        AND B.CODE   (+)= RTRIM(A.HAN_CD) " & vbCrLf)
                    strSQL.Append("        AND B.KBN    (+)= '3' " & vbCrLf)
                    strSQL.Append("        AND B.AUTO_MAIL (+)IS NOT NULL " & vbCrLf)
                    strSQL.Append("        AND C.KURACD (+)= RTRIM(A.CLI_CD) " & vbCrLf)
                    strSQL.Append("        AND C.CODE   (+)= RTRIM(A.JA_CD) " & vbCrLf)
                    strSQL.Append("        AND C.KBN    (+)= '3' " & vbCrLf)
                    strSQL.Append("        AND C.AUTO_MAIL (+)IS NOT NULL " & vbCrLf)
                    strSQL.Append("    GROUP BY " & vbCrLf)
                    strSQL.Append("        DECODE(B.AUTO_MAIL, NULL, C.AUTO_MAIL, B.AUTO_MAIL) " & vbCrLf)
                    strSQL.Append("    HAVING " & vbCrLf)
                    strSQL.Append("        DECODE(B.AUTO_MAIL, NULL, C.AUTO_MAIL, B.AUTO_MAIL) IS NOT NULL " & vbCrLf)
                    strSQL.Append(" /* FAX��Ұق������ă\�[�g */ " & vbCrLf)
                    strSQL.Append("ORDER BY AUTO_KUBUN, AUTO_FAX_SORT, AUTO_FAX, AUTO_MAIL " & vbCrLf)

                Else
                    '2:�ײ���(�������)
                    'strSQL.Append("SELECT " & vbCrLf)
                    'strSQL.Append("    AUTO_KUBUN, " & vbCrLf)
                    'strSQL.Append("    AUTO_FAX, " & vbCrLf)
                    'strSQL.Append("    AUTO_MAIL, " & vbCrLf)
                    'strSQL.Append("    SUM(TAIOU) AS CNT " & vbCrLf)
                    'strSQL.Append("FROM " & vbCrLf)
                    'strSQL.Append("( " & vbCrLf)
                    'strSQL.Append("        /* �@FAX�ʏ� */ " & vbCrLf)
                    'strSQL.Append("        SELECT " & vbCrLf)
                    'strSQL.Append("            '1'    AS AUTO_KUBUN, " & vbCrLf)
                    'strSQL.Append("            P.NAME AS AUTO_FAX, " & vbCrLf)
                    'strSQL.Append("            NULL   AS AUTO_MAIL, " & vbCrLf)
                    'strSQL.Append("            DECODE(TAI.ACBCD, NULL, 0, 1) AS TAIOU " & vbCrLf)
                    'strSQL.Append("        FROM " & vbCrLf)
                    'strSQL.Append("            CLIMAS CLI, " & vbCrLf)
                    'strSQL.Append("            M06_PULLDOWN P, " & vbCrLf)
                    'strSQL.Append("            D20_TAIOU TAI " & vbCrLf)
                    'strSQL.Append("        WHERE 1=1 " & vbCrLf)
                    ''strSQL.Append("                CLI.KANSI_CODE    = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    'strSQL.Append("            AND P.KBN = '76' " & vbCrLf)
                    'strSQL.Append("            AND P.NAME IS NOT NULL " & vbCrLf)
                    'strSQL.Append("            AND P.NAME <> '0' " & vbCrLf) ' 0��FAX���M�ΏۊO ' 2011/05/17 T.Watabe add
                    'strSQL.Append("            AND P.NAME <> '-' " & vbCrLf) ' -��FAX���M�ΏۊO ' 2011/05/17 T.Watabe add
                    'strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD  " & vbCrLf)
                    'strSQL.Append("            AND TAI.KURACD          = CLI.CLI_CD  " & vbCrLf)
                    'strSQL.Append(strWHERE_TAIOU.ToString & vbCrLf)
                    'strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    'strSQL.Append("    UNION ALL " & vbCrLf)
                    'strSQL.Append("        /* �AFAX�O���\�� */ " & vbCrLf)
                    'strSQL.Append("        SELECT " & vbCrLf)
                    'strSQL.Append("            '1'    AS AUTO_KUBUN, " & vbCrLf)
                    'strSQL.Append("            P.NAME AS AUTO_FAX, " & vbCrLf)
                    'strSQL.Append("            NULL   AS AUTO_MAIL, " & vbCrLf)
                    'strSQL.Append("            0 AS TAIOU " & vbCrLf)
                    'strSQL.Append("        FROM " & vbCrLf)
                    'strSQL.Append("            CLIMAS CLI, " & vbCrLf)
                    'strSQL.Append("            M06_PULLDOWN P " & vbCrLf)
                    'strSQL.Append("        WHERE 1=1 " & vbCrLf)
                    ''strSQL.Append("                CLI.KANSI_CODE    = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    'strSQL.Append("            AND P.KBN = '76' " & vbCrLf)
                    'strSQL.Append("            AND P.NAME IS NOT NULL " & vbCrLf)
                    'strSQL.Append("            AND P.NAME <> '0' " & vbCrLf) ' 0��FAX���M�ΏۊO ' 2011/05/17 T.Watabe add
                    'strSQL.Append("            AND P.NAME <> '-' " & vbCrLf) ' -��FAX���M�ΏۊO ' 2011/05/17 T.Watabe add
                    'strSQL.Append("            AND SUBSTR(P.CD, 1, 4) = CLI.CLI_CD  " & vbCrLf)
                    'strSQL.Append("            AND SUBSTR(P.NAIYO2, 1, 1) = '1' /* 0���\�� */ " & vbCrLf)
                    'strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    'strSQL.Append("    UNION ALL " & vbCrLf)
                    'strSQL.Append("        /* �BҰْʏ� */ " & vbCrLf)
                    'strSQL.Append("        SELECT " & vbCrLf)
                    'strSQL.Append("            '2'    AS AUTO_KUBUN, " & vbCrLf)
                    'strSQL.Append("            NULL AS AUTO_FAX, " & vbCrLf)
                    'strSQL.Append("            P.NAIYO1   AS AUTO_MAIL, " & vbCrLf)
                    'strSQL.Append("            DECODE(TAI.ACBCD, NULL, 0, 1) AS TAIOU " & vbCrLf)
                    'strSQL.Append("        FROM " & vbCrLf)
                    'strSQL.Append("            CLIMAS CLI, " & vbCrLf)
                    'strSQL.Append("            M06_PULLDOWN P, " & vbCrLf)
                    'strSQL.Append("            D20_TAIOU TAI " & vbCrLf)
                    'strSQL.Append("        WHERE 1=1 " & vbCrLf)
                    ''strSQL.Append("                CLI.KANSI_CODE    = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    'strSQL.Append("            AND P.KBN = '76' " & vbCrLf)
                    'strSQL.Append("            AND P.NAIYO1 IS NOT NULL " & vbCrLf)
                    'strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD  " & vbCrLf)
                    'strSQL.Append("            AND TAI.KURACD          = CLI.CLI_CD  " & vbCrLf)
                    'strSQL.Append(strWHERE_TAIOU.ToString & vbCrLf)
                    'strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    'strSQL.Append("    UNION ALL " & vbCrLf)
                    'strSQL.Append("        /* �CҰقO���\�� */ " & vbCrLf)
                    'strSQL.Append("        SELECT " & vbCrLf)
                    'strSQL.Append("            '2'    AS AUTO_KUBUN, " & vbCrLf)
                    'strSQL.Append("            NULL AS AUTO_FAX, " & vbCrLf)
                    'strSQL.Append("            P.NAIYO1   AS AUTO_MAIL, " & vbCrLf)
                    'strSQL.Append("            0 AS TAIOU " & vbCrLf)
                    'strSQL.Append("        FROM " & vbCrLf)
                    'strSQL.Append("            CLIMAS CLI, " & vbCrLf)
                    'strSQL.Append("            M06_PULLDOWN P " & vbCrLf)
                    'strSQL.Append("        WHERE 1=1 " & vbCrLf)
                    ''strSQL.Append("                CLI.KANSI_CODE    = '" & pstrKANSI_CODE & "'     " & vbCrLf)
                    'strSQL.Append("            AND P.KBN = '76' " & vbCrLf)
                    'strSQL.Append("            AND P.NAIYO1 IS NOT NULL " & vbCrLf)
                    'strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD  " & vbCrLf)
                    'strSQL.Append("            AND SUBSTR(P.NAIYO2, 1, 1) = '1' /* 0���\�� */ " & vbCrLf)
                    'strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    'strSQL.Append(") " & vbCrLf)
                    'strSQL.Append("GROUP BY      " & vbCrLf)
                    'strSQL.Append("    AUTO_KUBUN, " & vbCrLf)
                    'strSQL.Append("    AUTO_FAX, " & vbCrLf)
                    'strSQL.Append("    AUTO_MAIL " & vbCrLf)

                    strSQL.Append("WITH T AS ( /* T:�Ή��f�[�^�e�[�u�����̏����ɍ��v����KURACD */ " & vbCrLf)
                    strSQL.Append("    SELECT " & vbCrLf)
                    strSQL.Append("        DISTINCT " & vbCrLf)
                    strSQL.Append("        TAI.KURACD " & vbCrLf)
                    'strSQL.Append("    FROM D20_TAIOU TAI  " & vbCrLf) ' 2011/06/14
                    strSQL.Append("    FROM D20_TAIOU_COPY TAI  " & vbCrLf)
                    strSQL.Append("    WHERE 1=1  " & vbCrLf)
                    strSQL.Append(strWHERE_TAIOU.ToString & vbCrLf)
                    'strSQL.Append("          AND TAI.KANSCD  = '32020'  " & vbCrLf)
                    'strSQL.Append("          AND TAI.KURACD >= '3200'  " & vbCrLf)
                    'strSQL.Append("          AND TAI.KURACD <= '3223'  " & vbCrLf)
                    'strSQL.Append("          AND TAI.FAXKURAKBN = '2'  " & vbCrLf)
                    'strSQL.Append("          AND TAI.TMSKB = '2'  " & vbCrLf)
                    'strSQL.Append("          AND (  " & vbCrLf)
                    'strSQL.Append("                  (TAI.SYOYMD || TAI.SYOTIME > '20110519050000'  " & vbCrLf)
                    'strSQL.Append("                  AND TAI.SYOYMD || TAI.SYOTIME   <='20110520050000')  " & vbCrLf)
                    'strSQL.Append("              OR   " & vbCrLf)
                    'strSQL.Append("                  (TAI.SYOKANYMD || TAI.SYOKANTIME > '20110519050000'  " & vbCrLf)
                    'strSQL.Append("                  AND TAI.SYOKANYMD || TAI.SYOKANTIME <='20110520050000')  " & vbCrLf)
                    'strSQL.Append("              )  " & vbCrLf)
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
                    ' FAX�ԍ��̃n�C�t������菜���悤��SQL���C��("REPLACE(JP.NAME, '-')")
                    'strSQL.Append("            P.NAME AS AUTO_FAX,  " & vbCrLf) 'DEL
                    strSQL.Append(ReplaceHyphen("P.NAME") & " AS AUTO_FAX, " & vbCrLf)   'ADD
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- END
                    strSQL.Append("            NULL   AS AUTO_MAIL  " & vbCrLf)
                    strSQL.Append("        FROM  " & vbCrLf)
                    strSQL.Append("            CLIMAS CLI,  " & vbCrLf)
                    strSQL.Append("            M06_PULLDOWN P,  " & vbCrLf)
                    strSQL.Append("            T  " & vbCrLf)
                    strSQL.Append("        WHERE 1=1  " & vbCrLf)
                    strSQL.Append("            AND P.KBN = '76'  " & vbCrLf)
                    strSQL.Append("            AND P.NAME IS NOT NULL  " & vbCrLf)
                    strSQL.Append("            AND P.NAME <> '0'  " & vbCrLf)
                    strSQL.Append("            AND P.NAME <> '-'  " & vbCrLf)
                    strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append("            AND T.KURACD          = CLI.CLI_CD   " & vbCrLf)
                    'strSQL.Append("            AND CLI.KANSI_CODE  = '32020'  " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append("    UNION ALL " & vbCrLf)
                    strSQL.Append("        /* �AFAX�O���\�� */  " & vbCrLf)
                    strSQL.Append("        SELECT  " & vbCrLf)
                    strSQL.Append("            '1'    AS AUTO_KUBUN,  " & vbCrLf)
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- START
                    'strSQL.Append("            P.NAME AS AUTO_FAX,  " & vbCrLf) 'DEL
                    strSQL.Append(ReplaceHyphen("P.NAME") & " AS AUTO_FAX, " & vbCrLf)   'ADD
                    '2011/11/14 MOD H.Uema -------------------------------------------------------------------- END
                    strSQL.Append("            NULL   AS AUTO_MAIL  " & vbCrLf)
                    strSQL.Append("        FROM  " & vbCrLf)
                    strSQL.Append("            CLIMAS CLI,  " & vbCrLf)
                    strSQL.Append("            M06_PULLDOWN P  " & vbCrLf)
                    strSQL.Append("        WHERE 1=1  " & vbCrLf)
                    strSQL.Append("            AND P.KBN = '76'  " & vbCrLf)
                    strSQL.Append("            AND P.NAME IS NOT NULL  " & vbCrLf)
                    strSQL.Append("            AND P.NAME <> '0'  " & vbCrLf)
                    strSQL.Append("            AND P.NAME <> '-'  " & vbCrLf)
                    strSQL.Append("            AND SUBSTR(P.CD, 1, 4) = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append("            AND SUBSTR(P.NAIYO2, 1, 1) = '1' /* 0���\�� */  " & vbCrLf)
                    'strSQL.Append("         AND CLI.KANSI_CODE  = '32020'  " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append("    UNION ALL " & vbCrLf)
                    strSQL.Append("        /* �BҰْʏ� */  " & vbCrLf)
                    strSQL.Append("        SELECT  " & vbCrLf)
                    strSQL.Append("            '2'    AS AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("            NULL AS AUTO_FAX,  " & vbCrLf)
                    strSQL.Append("            P.NAIYO1   AS AUTO_MAIL  " & vbCrLf)
                    strSQL.Append("        FROM  " & vbCrLf)
                    strSQL.Append("            CLIMAS CLI,  " & vbCrLf)
                    strSQL.Append("            M06_PULLDOWN P,  " & vbCrLf)
                    strSQL.Append("            T  " & vbCrLf)
                    strSQL.Append("        WHERE 1=1  " & vbCrLf)
                    strSQL.Append("            AND P.KBN = '76'  " & vbCrLf)
                    strSQL.Append("            AND P.NAIYO1 IS NOT NULL  " & vbCrLf)
                    strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append("            AND T.KURACD          = CLI.CLI_CD   " & vbCrLf)
                    'strSQL.Append("            AND CLI.KANSI_CODE  = '32020'  " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append("    UNION ALL " & vbCrLf)
                    strSQL.Append("        /* �CҰقO���\�� */  " & vbCrLf)
                    strSQL.Append("        SELECT  " & vbCrLf)
                    strSQL.Append("            '2'    AS AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("            NULL AS AUTO_FAX,  " & vbCrLf)
                    strSQL.Append("            P.NAIYO1   AS AUTO_MAIL  " & vbCrLf)
                    strSQL.Append("        FROM  " & vbCrLf)
                    strSQL.Append("            CLIMAS CLI,  " & vbCrLf)
                    strSQL.Append("            M06_PULLDOWN P  " & vbCrLf)
                    strSQL.Append("        WHERE 1=1  " & vbCrLf)
                    strSQL.Append("            AND P.KBN = '76'  " & vbCrLf)
                    strSQL.Append("            AND P.NAIYO1 IS NOT NULL  " & vbCrLf)
                    strSQL.Append("            AND SUBSTR(P.CD, 1,4) = CLI.CLI_CD   " & vbCrLf)
                    strSQL.Append("            AND SUBSTR(P.NAIYO2, 1, 1) = '1' /* 0���\�� */  " & vbCrLf)
                    'strSQL.Append("         AND CLI.KANSI_CODE  = '32020'  " & vbCrLf)
                    strSQL.Append(strWHERE_CLI.ToString & vbCrLf)
                    strSQL.Append(")  " & vbCrLf)
                    strSQL.Append("GROUP BY  " & vbCrLf)
                    strSQL.Append("    AUTO_KUBUN,  " & vbCrLf)
                    strSQL.Append("    AUTO_FAX,  " & vbCrLf)
                    strSQL.Append("    AUTO_MAIL  " & vbCrLf)
                End If
            End If

            'DEBUG
            If pintDebugSQLNo = 1 Then
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
            For Each dr In ds.Tables(0).Rows
                '--- ��2005/05/19 MOD Falcon�� ---      AUTO��AUTO_KUBUN
                autoKbn = Convert.ToString(dr.Item("AUTO_KUBUN"))
                'If (Convert.ToString(dr.Item("AUTO_KUBUN")) = strFAXKBN And Convert.ToString(dr.Item("AUTO_FAX")).Length > 0) Or _
                '   (Convert.ToString(dr.Item("AUTO_KUBUN")) = strMAILKBN And Convert.ToString(dr.Item("AUTO_MAIL")).Length > 0) Then
                If ((autoKbn = strFAXKBN Or autoKbn = strBoth) And Convert.ToString(dr.Item("AUTO_FAX")).Length > 0) Or _
                   ((autoKbn = strMAILKBN Or autoKbn = strBoth) And Convert.ToString(dr.Item("AUTO_MAIL")).Length > 0) Then

                    ' 2011/03/10 T.Watabe edit FAX��Ұق𗼕����M�\�ɕύX
                    'ReDim Preserve arrAUTO(intData)
                    'ReDim Preserve arrAUTO_FAX(intData)
                    'ReDim Preserve arrAUTO_MAIL(intData)
                    'ReDim Preserve arrAUTO_CNT(intData)
                    'arrAUTO(intData) = Convert.ToString(dr.Item("AUTO_KUBUN"))
                    'arrAUTO_FAX(intData) = Convert.ToString(dr.Item("AUTO_FAX"))
                    'arrAUTO_MAIL(intData) = Convert.ToString(dr.Item("AUTO_MAIL"))
                    'arrAUTO_CNT(intData) = Convert.ToInt16(dr.Item("CNT"))
                    'intData += 1
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

            If intData = 0 Then
                '//�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                Return "DATA0"
            End If

            'DEBUG
            If pintDebugSQLNo = 102 Then
                Return "DEBUG[" & strSQL.ToString & "]"
            End If

            Dim i As Integer
            For i = 0 To intData - 1
                If intLoop = intData Then
                    strFlg = "1"
                Else
                    strFlg = "0"
                End If
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


            '2011/06/14 T.Watabe add
            '--------------------------------
            ' D20�̏�����폜
            '--------------------------------
            mDeleteD20Taiou(cdb, GUID)

        Catch ex As Exception
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
            sql.Append("SELECT ")
            sql.Append("    TAI.*, ")
            sql.Append("    SYSDATE, ")
            sql.Append("    '" & GUID & "' ")
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
        Dim sZipFilePass As String ' 2008/12/12 T.Watabe add
        Dim sendCD As String '2010/05/24 T.Watabe add

        Dim cliCd4FileHead As String = "" '2011/03/10 T.Watabe add
        Dim jaName4FileHead As String = ""  ' 2011/05/19 T.Watabe add
        Dim centerName As String = ""

        If pstrSEND_KBN = "1" Then
            sendCD = "H" '�̔���
        Else
            sendCD = "C" '����
        End If


        Dim sel As StringBuilder = New StringBuilder("")
        Dim fro As StringBuilder = New StringBuilder("")
        Dim whe As StringBuilder = New StringBuilder("")
        Dim wheC As StringBuilder = New StringBuilder("")
        Dim wheJ As StringBuilder = New StringBuilder("")
        Dim ord As StringBuilder = New StringBuilder("")

        If pstrSEND_KBN = "1" Then '1:�̔����H

            sel.Append("    ,JAS.YOBI5 ") ' �p�X���[�h

            fro.Append("    ,HN2MAS JAS ")

            whe.Append("AND CLI.CLI_CD     = JAS.CLI_CD " & vbCrLf)
            'whe.Append("AND JAS.AUTO_KUBUN = :AUTO_KUBUN ")     '--- 2005/05/19 MOD Falcon ---  AUTO �� AUTO_KUBUN
            If pstrAUTO = strFAXKBN Then '�e�`�w���M�H
                whe.Append("  AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)  ' 2011/03/10 T.Watabe edit
                '2011/11/15 MOD H.Uema -------------------------------------------------------------------- START
                'whe.Append("  AND (JAS.AUTO_FAX = :AUTO_FAX OR RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) = :AUTO_FAX)" & vbCrLf)
                whe.Append("  AND (" & ReplaceHyphen("JAS.AUTO_FAX") & " = :AUTO_FAX " & vbCrLf)
                whe.Append("       OR " & ReplaceHyphen("RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1)") & " = :AUTO_FAX)" & vbCrLf)
                '2011/11/15 MOD H.Uema -------------------------------------------------------------------- END 
            Else '���[�����M�H
                whe.Append("  AND JAS.AUTO_KUBUN IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf) ' 2011/03/10 T.Watabe edit
                'whe.Append("  AND JAS.AUTO_MAIL = :AUTO_MAIL ")' 2011/03/28 T.Watabe edit �P�̃��[�����M�p�f�[�^�쐬���̒��o�p�r�p�k
                whe.Append("    AND (JAS.CLI_CD, JAS.HAN_CD, JAS.JA_CD) IN ( " & vbCrLf) '/* JPGAP�� ���M�Ώۃ��A�h����A�ΏۂƂȂ�i�`�x���𒊏o����SQL */
                whe.Append("        /* 1:�i�`�x�����x���Ń��A�h�ݒ� */ " & vbCrLf)
                whe.Append("            SELECT  " & vbCrLf)
                whe.Append("                A.CLI_CD, A.HAN_CD, A.JA_CD " & vbCrLf)
                whe.Append("            FROM  " & vbCrLf)
                whe.Append("                HN2MAS A, " & vbCrLf)
                whe.Append("                M05_TANTO C " & vbCrLf)
                whe.Append("            WHERE " & vbCrLf)
                whe.Append("                    C.KURACD = A.CLI_CD " & vbCrLf)
                whe.Append("                AND C.CODE   = A.HAN_CD " & vbCrLf)
                whe.Append("                AND C.KBN    = '3' " & vbCrLf)
                whe.Append("                and C.AUTO_MAIL = :AUTO_MAIL " & vbCrLf)
                whe.Append("                AND A.HAN_CD <> A.JA_CD /* JA�͏��O�BJA�x���̂� */ " & vbCrLf)
                whe.Append("        UNION " & vbCrLf)
                whe.Append("        /* 2:�i�`���x���Ń��A�h�ݒ� */ " & vbCrLf)
                whe.Append("            SELECT  " & vbCrLf)
                whe.Append("               X.CLI_CD, X.HAN_CD, X.JA_CD " & vbCrLf)
                whe.Append("            FROM  " & vbCrLf)
                whe.Append("                ( " & vbCrLf)
                whe.Append("                    SELECT  " & vbCrLf)
                whe.Append("                        A.CLI_CD, A.HAN_CD, A.JA_CD " & vbCrLf)
                whe.Append("                    FROM  " & vbCrLf)
                whe.Append("                        HN2MAS A, " & vbCrLf)
                whe.Append("                        M05_TANTO B " & vbCrLf)
                whe.Append("                    WHERE " & vbCrLf)
                whe.Append("                            B.KURACD (+)= A.CLI_CD " & vbCrLf)
                whe.Append("                        AND B.CODE   (+)= A.HAN_CD " & vbCrLf)
                whe.Append("                        AND B.KBN    (+)= '3' " & vbCrLf)
                whe.Append("                        AND B.KURACD IS NULL " & vbCrLf)
                whe.Append("                ) X, " & vbCrLf)
                whe.Append("                M05_TANTO Y " & vbCrLf)
                whe.Append("            WHERE " & vbCrLf)
                whe.Append("                    Y.KURACD = X.CLI_CD " & vbCrLf)
                whe.Append("                AND Y.CODE   = X.JA_CD " & vbCrLf)
                whe.Append("                AND Y.KBN    = '3' " & vbCrLf)
                whe.Append("                and Y.AUTO_MAIL = :AUTO_MAIL " & vbCrLf)
                whe.Append("    ) " & vbCrLf)
            End If
            whe.Append("  AND JAS.CLI_CD   = TAI.KURACD  " & vbCrLf)
            whe.Append("  AND JAS.HAN_CD   = TAI.ACBCD  " & vbCrLf)
            whe.Append("  AND SUBSTR(JAS.CLI_CD,2,2) = KYO.KEN_CD(+) " & vbCrLf)
            whe.Append("  AND JAS.HAISO_CD = KYO.HAISO_CD(+) " & vbCrLf)

            ord.Append("    HATYMDT " & vbCrLf) ' 2011/05/27 T.Watabe add �\�[�g��̔��X�ƃN���C�A���g�ŕς���

        Else '2:�ײ��āH

            'sel.Append("    ,CLI.CLI_CD AS YOBI5 ") ' �p�X���[�h 2008/12/12 T.Watabe add
            sel.Append("    ,DECODE(INSTR(P.NAIYO2, ','), 0, NULL, SUBSTR(P.NAIYO2, INSTR(P.NAIYO2, ',') + 1)) AS YOBI5 " & vbCrLf) ' �p�X���[�h 2010/10/25 T.Watabe add
            sel.Append("    ,TAI.JACD AS JA_CD " & vbCrLf) ' 2011/05/27 T.Watabe add 

            fro.Append("    ,M06_PULLDOWN P " & vbCrLf)
            fro.Append("    ,HN2MAS JAS " & vbCrLf)

            whe.Append("  AND P.KBN              = '76' " & vbCrLf)
            whe.Append("  AND SUBSTR(P.CD, 1, 4) = TAI.KURACD  " & vbCrLf)
            'whe.Append("  AND :AUTO_KUBUN IS NOT NULL ") '��а
            If pstrAUTO = strFAXKBN Then '�e�`�w���M�H
                '2011/11/15 MOD H.Uema -------------------------------------------------------------------- START
                'whe.Append("  AND P.NAME   = :AUTO_FAX " & vbCrLf)
                whe.Append("  AND " & ReplaceHyphen("P.NAME") & " = :AUTO_FAX " & vbCrLf)
                '2011/11/15 MOD H.Uema -------------------------------------------------------------------- START
            Else '���[�����M�H
                whe.Append("  AND P.NAIYO1 = :AUTO_MAIL " & vbCrLf)
            End If
            whe.Append("  AND JAS.CLI_CD   = TAI.KURACD  " & vbCrLf)
            whe.Append("  AND JAS.HAN_CD   = TAI.ACBCD  " & vbCrLf)
            whe.Append("  AND SUBSTR(JAS.CLI_CD,2,2) = KYO.KEN_CD(+) " & vbCrLf)
            whe.Append("  AND JAS.HAISO_CD = KYO.HAISO_CD(+) " & vbCrLf)

            ord.Append("    CLI_CD, JA_CD, HATYMDT " & vbCrLf) ' 2011/05/27 T.Watabe add �\�[�g��̔��X�ƃN���C�A���g�ŕς���

        End If

        Try
            '//------------------------------------------------
            ' �f�[�^��SELECT
            '//------------------------------------------------
            strSQL = New StringBuilder("")
            'SQL�쐬�J�n
            strSQL.Append("SELECT " & vbCrLf)
            strSQL.Append("    CLI.CLI_CD,  " & vbCrLf) '2011/03/10 T.Watabe add
            strSQL.Append("    CLI.CLI_NAME,  " & vbCrLf) '2011/05/27 T.Watabe add
            '20051003 NEC ADD START
            strSQL.Append("    KOK.USER_CD SH_USER, " & vbCrLf)
            '20051003 NEC ADD END
            strSQL.Append("    TAI.JANM, " & vbCrLf)
            strSQL.Append("    TAI.ACBNM, " & vbCrLf)
            strSQL.Append("    TAI.KENNM, " & vbCrLf)
            strSQL.Append("    KYO.NAME, " & vbCrLf)
            'strSQL.Append("    JAS.AUTO_FAX, ")
            'strSQL.Append("    JAS.AUTO_MAIL, ")
            strSQL.Append("    TAI.JUSYONM, " & vbCrLf)
            strSQL.Append("    TAI.ACBCD, " & vbCrLf)
            strSQL.Append("    TAI.USER_CD, " & vbCrLf)
            strSQL.Append("    TAI.KTELNO, " & vbCrLf)
            '2006/06/14 NEC UPDATE START
            strSQL.Append("    TAI.SDNM, " & vbCrLf)
            strSQL.Append("    TAI.JUTEL1, " & vbCrLf)
            strSQL.Append("    TAI.JUTEL2, " & vbCrLf)
            strSQL.Append("    KOK.USER_FLG, " & vbCrLf)
            '2006/06/14 NEC UPDATE END
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
            '2006/06/14 NEC UPDATE START
            strSQL.Append("    TAI.SDTBIK3, " & vbCrLf)
            '2006/06/14 NEC UPDATE END
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
            'strSQL.Append("    ,JAS.YOBI5 " & vbCrLf) ' �p�X���[�h 2008/12/12 T.Watabe add
            strSQL.Append(sel) ' �p�X���[�h 2008/12/12 T.Watabe add
            strSQL.Append("FROM CLIMAS CLI, " & vbCrLf)
            'strSQL.Append("     HN2MAS JAS, " & vbCrLf)
            'strSQL.Append("     D20_TAIOU TAI, " & vbCrLf)' D20_TAIOU_COPY���g�p 2011/06/14
            strSQL.Append("     D20_TAIOU_COPY TAI, " & vbCrLf)
            strSQL.Append("     HAIMAS KYO, " & vbCrLf)
            strSQL.Append("     SHAMAS KOK, " & vbCrLf)
            strSQL.Append("     M06_PULLDOWN PL3, " & vbCrLf)
            strSQL.Append("     M06_PULLDOWN PL5 " & vbCrLf)
            strSQL.Append(fro)
            strSQL.Append("WHERE " & vbCrLf)
            strSQL.Append("    CLI.KANSI_CODE = '" & pstrKANSI_CODE & "'  " & vbCrLf)
            strSQL.Append("AND CLI.CLI_CD     = TAI.KURACD ")
            'strSQL.Append("AND JAS.AUTO_KUBUN = '" & pstrAUTO & "' ")     '--- 2005/05/19 MOD Falcon ---  AUTO �� AUTO_KUBUN
            'If pstrAUTO = strFAXKBN Then
            '    '�e�`�w���M�̏ꍇ
            '    'strSQL.Append("  AND JAS.AUTO_FAX = :AUTO_FAX ") �f2010/05/24 T.Watabe edit
            '    strSQL.Append("  AND (JAS.AUTO_FAX = :AUTO_FAX OR RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) = :AUTO_FAX)")
            'Else
            '    '���[�����M�̏ꍇ
            '    strSQL.Append("  AND JAS.AUTO_MAIL = :AUTO_MAIL ")
            'End If
            'strSQL.Append("  AND JAS.CLI_CD   = TAI.KURACD  ")
            'strSQL.Append("  AND JAS.HAN_CD   = TAI.ACBCD  ")
            'strSQL.Append("  AND SUBSTR(JAS.CLI_CD,2,2) = KYO.KEN_CD(+) ")
            'strSQL.Append("  AND JAS.HAISO_CD = KYO.HAISO_CD(+) ")
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

            If pintDebugSQLNo = 2 Or (pintDebugSQLNo >= 2000 And pintDebugSQLNo <= 2999) Then
                If pstrAUTO = strFAXKBN Then
                    Return "DEBUG[" & strSQL.ToString & "]"
                End If
            End If
            If pintDebugSQLNo = 3 Or (pintDebugSQLNo >= 3000 And pintDebugSQLNo <= 3999) Then
                If pstrAUTO <> strFAXKBN Then
                    Return "DEBUG[" & strSQL.ToString & "]"
                End If
            End If

            cdb.pSQL = strSQL.ToString '//SQL�Z�b�g

            '//�p�����[�^�̃Z�b�g
            'cdb.pSQLParamStr("KANSI_CODE") = pstrKANSI_CODE
            'cdb.pSQLParamStr("AUTO_KUBUN") = strFAXKBN
            'If pstrAUTO = strFAXKBN Then
            If pstrAUTO = strFAXKBN Then
                cdb.pSQLParamStr("AUTO_FAX") = pstrFAXNO '�e�`�w���M�̏ꍇ
            Else
                cdb.pSQLParamStr("AUTO_MAIL") = pstrMAILAD '���[�����M�̏ꍇ
            End If

            cdb.mExecQuery() '//SQL���s
            ds = cdb.pResult  '//�f�[�^�Z�b�g�Ɋi�[

            If pintDebugSQLNo = 103 Then ' DEBUG
                Return "DEBUG:(" & pintDebugSQLNo & ")[" & strSQL.ToString & "]"
            End If

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
                If pstrAUTO = strFAXKBN Then
                    '�e�`�w���M�̏ꍇ
                    ExcelC.pTitle = "�Ď��Z���^�[�Ή����e���ׁi�e�`�w�j"
                Else
                    '���[�����M�̏ꍇ
                    ExcelC.pTitle = "�Ď��Z���^�[�Ή����e���ׁi���[���j"
                End If
                ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd")) '�쐬��
                'ExcelC.pScale = 93               '�k���g�嗦 2010/09/17 T.Watabe edit
                ExcelC.pScale = 95               '�k���g�嗦
                If pstrSEND_KBN = "2" Then '2:�N���C�A���g�̖ڈ���t�b�^�֕t����
                    ExcelC.pFooter = "&R ."
                    'ExcelC.pFooter = "&R &P \/ " & pintCNT & "."
                Else
                    'ExcelC.pFooter = "&R &P \/ " & pintCNT & " "
                End If

                '�]��
                '2005/10/03 NEC UPDATE
                '2005/12/22 NEC UPDATE
                '2006/06/21 NEC UPDATE 
                ExcelC.pMarginTop = 1.8D
                'ExcelC.pMarginBottom = 1D ' 2010/10/06 T.Watabe edit
                ExcelC.pMarginBottom = 0.5D
                ExcelC.pMarginLeft = 1.2D
                ExcelC.pMarginRight = 1.5D
                ExcelC.pMarginHeader = 1D
                'ExcelC.pMarginFooter = 1D ' 2010/10/06 T.Watabe edit
                ExcelC.pMarginFooter = 0.5D
            End If

            If ds.Tables(0).Rows.Count = 0 Then  '//�f�[�^�����݂��Ȃ��H

                wheC = New StringBuilder("")
                wheJ = New StringBuilder("")

                '�N���C�A���g�R�[�h�͈͎̔w���ǉ�
                If pstrKURACD_F.Length > 0 Then
                    wheC.Append("  AND CLI.CLI_CD >= '" & pstrKURACD_F & "' " & vbCrLf) '2011/05/26 T.Watabe add
                    wheJ.Append("  AND JAS.CLI_CD >= '" & pstrKURACD_F & "' " & vbCrLf) '2011/05/26 T.Watabe add
                End If
                If pstrKURACD_T.Length > 0 Then
                    wheC.Append("  AND CLI.CLI_CD <= '" & pstrKURACD_T & "' " & vbCrLf) '2011/05/26 T.Watabe add
                    wheJ.Append("  AND JAS.CLI_CD <= '" & pstrKURACD_T & "' " & vbCrLf) '2011/05/26 T.Watabe add
                End If


                'Return "DATA0" '//�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                '-------------
                ' �}�X�^���擾
                '-------------
                strSQL = New StringBuilder("")
                If pstrSEND_KBN = "1" Then '1:�̔����H
                    strSQL.Append("SELECT DISTINCT " & vbCrLf)
                    strSQL.Append("    CLI.CLI_CD,  " & vbCrLf) '2011/03/10 T.Watabe add
                    strSQL.Append("    JAS.JA_NAME AS JANM,  " & vbCrLf) '2011/05/19 T.Watabe add
                    strSQL.Append("    KYO.NAME AS CENTER_NAME, " & vbCrLf)
                    strSQL.Append("    CLI.KEN_NAME, " & vbCrLf)
                    strSQL.Append("    KAN.TEL, " & vbCrLf)
                    strSQL.Append("    JAS.YOBI5 AS YOBI5 " & vbCrLf) ' �p�X���[�h '2011/05/26 T.Watabe add
                    'strSQL.Append("    JAS.JA_CD, JAS.HAN_CD ") ' 2011/05/26 T.Watabe edit
                    strSQL.Append("FROM  " & vbCrLf)
                    strSQL.Append("    CLIMAS CLI, " & vbCrLf)
                    strSQL.Append("    HN2MAS JAS, " & vbCrLf)
                    strSQL.Append("    HAIMAS KYO, " & vbCrLf)
                    strSQL.Append("    KANSIMAS KAN " & vbCrLf)
                    strSQL.Append("WHERE " & vbCrLf)
                    strSQL.Append("        CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    strSQL.Append("    AND CLI.CLI_CD      = JAS.CLI_CD " & vbCrLf)
                    If pstrAUTO = "1" Then '1:FAX���M
                        'strSQL.Append("    AND JAS.AUTO_KUBUN  = '1' AND JAS.AUTO_FAX    = '" & pstrFAXNO & "' " & vbCrLf)
                        'strSQL.Append("    AND JAS.AUTO_KUBUN  = '1' " & vbCrLf) ' 2011/03/10 T.Watabe edit
                        strSQL.Append("    AND JAS.AUTO_KUBUN IN ('" & strFAXKBN & "','" & strBoth & "') " & vbCrLf)
                        '2011/11/15 MOD H.Uema -------------------------------------------------------------------- START
                        'strSQL.Append("    AND (JAS.AUTO_FAX = '" & pstrFAXNO & "' OR RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1) = '" & pstrFAXNO & "')" & vbCrLf)
                        strSQL.Append("  AND (" & ReplaceHyphen("JAS.AUTO_FAX") & " = '" & pstrFAXNO & "' " & vbCrLf)
                        strSQL.Append("       OR " & ReplaceHyphen("RTRIM(JAS.TELA_FAX1) || RTRIM(TELB_FAX1)") & " = '" & pstrFAXNO & "')" & vbCrLf)
                        '2011/11/15 MOD H.Uema -------------------------------------------------------------------- END 
                    Else
                        'strSQL.Append("    AND JAS.AUTO_KUBUN  = '2' AND JAS.AUTO_MAIL    = '" & pstrMAILAD & "' ") ' 2011/03/10 T.Watabe edit
                        strSQL.Append("    AND JAS.AUTO_KUBUN IN ('" & strMAILKBN & "','" & strBoth & "') " & vbCrLf)
                        'strSQL.Append("    AND JAS.AUTO_MAIL    = '" & pstrMAILAD & "' ") ' 2011/05/26 T.Watabe edit
                        strSQL.Append("    AND " & vbCrLf)
                        strSQL.Append("    ( " & vbCrLf)
                        strSQL.Append("        (JAS.CLI_CD, JAS.JA_CD) IN (    " & vbCrLf)
                        strSQL.Append("          SELECT DISTINCT KURACD AS CLI_CD, CODE AS JA_CD FROM M05_TANTO " & vbCrLf)
                        strSQL.Append("          WHERE KBN = '3' AND AUTO_MAIL = '" & pstrMAILAD & "' " & vbCrLf)
                        strSQL.Append("        ) " & vbCrLf)
                        strSQL.Append("    OR " & vbCrLf)
                        strSQL.Append("        (JAS.CLI_CD, JAS.HAN_CD) IN (    " & vbCrLf)
                        strSQL.Append("          SELECT DISTINCT KURACD AS CLI_CD, CODE AS JA_CD FROM M05_TANTO " & vbCrLf)
                        strSQL.Append("          WHERE KBN = '3' AND AUTO_MAIL = '" & pstrMAILAD & "' " & vbCrLf)
                        strSQL.Append("        ) " & vbCrLf)
                        strSQL.Append("    ) " & vbCrLf)
                    End If
                    strSQL.Append("    AND JAS.YOBI3       = '1' " & vbCrLf)
                    strSQL.Append("    AND KYO.KEN_CD(+)   = SUBSTR(JAS.CLI_CD,2,2) " & vbCrLf)
                    strSQL.Append("    AND KYO.HAISO_CD(+) = JAS.HAISO_CD " & vbCrLf)
                    strSQL.Append("    AND KAN.KANSI_CD (+)= CLI.KANSI_CODE " & vbCrLf)
                    strSQL.Append(wheC) ' 2011/05/26 T.Watabe edit
                    strSQL.Append(wheJ) ' 2011/05/26 T.Watabe edit
                    'strSQL.Append("ORDER BY CLI_CD, JA_CD, HAN_CD ") ' 2011/05/26 T.Watabe edit

                Else '2:�ײ��āH
                    strSQL.Append("SELECT DISTINCT " & vbCrLf)
                    strSQL.Append("    CLI.CLI_CD,  " & vbCrLf) '2011/03/10 T.Watabe add
                    strSQL.Append("    '' AS JANM,  " & vbCrLf) '2011/05/19 T.Watabe add
                    strSQL.Append("    CLI.CLI_NAME AS CENTER_NAME, " & vbCrLf)
                    strSQL.Append("    CLI.KEN_NAME, " & vbCrLf)
                    strSQL.Append("    KAN.TEL, " & vbCrLf)
                    strSQL.Append("    DECODE(INSTR(P.NAIYO2, ','), 0, NULL, SUBSTR(P.NAIYO2, INSTR(P.NAIYO2, ',') + 1)) AS YOBI5 " & vbCrLf) ' �p�X���[�h '2011/05/26 T.Watabe add
                    strSQL.Append("FROM " & vbCrLf)
                    strSQL.Append("    CLIMAS CLI, " & vbCrLf)
                    strSQL.Append("    M06_PULLDOWN P, " & vbCrLf)
                    strSQL.Append("    KANSIMAS KAN " & vbCrLf)
                    strSQL.Append("WHERE " & vbCrLf)
                    strSQL.Append("        CLI.KANSI_CODE  = '" & pstrKANSI_CODE & "' " & vbCrLf)
                    strSQL.Append("    AND P.KBN = '76' " & vbCrLf)
                    strSQL.Append("    AND SUBSTR(P.CD, 1, 4) = CLI.CLI_CD  " & vbCrLf)
                    If pstrAUTO = "1" Then
                        '2011/11/15 MOD H.Uema -------------------------------------------------------------------- START
                        'strSQL.Append("    AND P.NAME   = '" & pstrFAXNO & "' " & vbCrLf)
                        strSQL.Append("    AND " & ReplaceHyphen("P.NAME") & " = '" & pstrFAXNO & "' " & vbCrLf)
                        '2011/11/15 MOD H.Uema -------------------------------------------------------------------- END
                    Else
                        strSQL.Append("    AND P.NAIYO1 = '" & pstrMAILAD & "' " & vbCrLf)
                    End If
                    strSQL.Append("    AND KAN.KANSI_CD (+)= CLI.KANSI_CODE " & vbCrLf)
                    strSQL.Append(wheC) ' 2011/05/26 T.Watabe edit
                    'strSQL.Append("ORDER BY CLI_CD ") ' 2011/05/26 T.Watabe edit
                End If

                ' DEBUG
                If pintDebugSQLNo = 4 Or (pintDebugSQLNo >= 4000 And pintDebugSQLNo <= 4999) Then
                    If pstrAUTO = strFAXKBN Then
                        Return "DEBUG[" & strSQL.ToString & "]"
                    End If
                End If
                If pintDebugSQLNo = 5 Or (pintDebugSQLNo >= 5000 And pintDebugSQLNo <= 5999) Then
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

                If pintDebugSQLNo = 1010 Then ' DEBUG
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

                '//------------------------------------------------
                '// �t�@�C���̍쐬�Q�i�f�[�^�ݒ�j
                '//------------------------------------------------
                ExcelC.mHeader(intGYOSU, 30, 1)

                '�e��̕����s�N�Z���ŃZ�b�g�B�g���������B
                '1�s��
                'ExcelC.pCellStyle(1) = "width:50px;border-style:none"
                'ExcelC.pCellStyle(2) = "width:104px;border-style:none"
                ExcelC.pCellStyle(1) = "width:32px;border-style:none"
                ExcelC.pCellStyle(2) = "width:122px;border-style:none"
                ExcelC.pCellStyle(3) = "width:72px;border-style:none"
                ExcelC.pCellStyle(4) = "width:72px;border-style:none"

                ExcelC.pCellStyle(5) = "width:90px;border-style:none"
                ExcelC.pCellStyle(6) = "width:115px;border-style:none"
                ExcelC.pCellStyle(7) = "width:72px;border-style:none"
                ExcelC.pCellStyle(8) = "width:52px;border-style:none"
                ExcelC.pCellStyle(9) = "width:80px;border-style:none"
                'ExcelC.pCellStyle(10) = "width:62px;border-style:none"
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

                ''3�s��
                'ExcelC.pCellStyle(1) = "border-style:none"
                'ExcelC.pCellStyle(2) = "border-style:none"
                'ExcelC.pCellStyle(3) = "border-style:none"
                'ExcelC.pCellVal(1, "colspan=2") = "�����F" & kenName
                'If pstrSEND_KBN = "1" Then
                '    ExcelC.pCellVal(2, "colspan=4") = "�����Z���^�[���F" & centerName
                'Else
                '    ExcelC.pCellVal(2, "colspan=4") = "�N���C�A���g���F" & centerName
                'End If
                'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '3�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=10") = "�i�`��       �F" & jaName4FileHead
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '4�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                ExcelC.pCellVal(1, "colspan=10") = "���@�@�@���@ �F" & kenName
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '5�s��
                ExcelC.pCellStyle(1) = "border-style:none"
                If pstrSEND_KBN = "1" Then '1:�̔��X�^2:�N���C�A���g
                    ExcelC.pCellVal(1, "colspan=10") = "����������   �F" & centerName
                Else
                    ExcelC.pCellVal(1, "colspan=10") = "�ײ��Ė�     �F" & centerName
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

            Else
                If pintDebugSQLNo = 106 Then ' DEBUG
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

                If pintDebugSQLNo = 107 Then ' DEBUG
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
                'ExcelC.pCellStyle(1) = "width:50px;border-style:none"
                'ExcelC.pCellStyle(2) = "width:104px;border-style:none"
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
                    ExcelC.pCellVal(1, "colspan=6") = "���q�l�����F" & Convert.ToString(dr.Item("JUSYONM"))
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
                        ExcelC.pCellVal(1, "colspan=6") = "�d�b�ԍ��@�F" & Convert.ToString(dr.Item("JUTEL1")) & Convert.ToString(dr.Item("JUTEL2"))
                    Else
                        ExcelC.pCellVal(1, "colspan=6") = "�d�b�ԍ��@�F" & Convert.ToString(dr.Item("JUTEL1")) & "-" & Convert.ToString(dr.Item("JUTEL2"))
                    End If
                    '2006/06/14 NEC UPDATE END
                    ExcelC.pCellVal(2, "colspan=4") = "�A���d�b�ԍ��F" & Convert.ToString(dr.Item("RENTEL"))
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
                    ExcelC.pCellVal(1, "colspan=3") = "�������F" & fncDateSet(Convert.ToString(dr.Item("HATYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("HATTIME")))
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

                    '24�s��
                    ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = ""
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '25�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
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
                    ExcelC.pCellVal(2, "colspan=5") = "���������@�@�@�@�F" & fncDateSet(Convert.ToString(dr.Item("SYOYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOTIME")))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '28�s��
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
                    ExcelC.pCellStyle(2) = "border-style:none;height:64px;vertical-align:top"
                    ExcelC.pCellVal(1) = ""
                    ExcelC.pCellVal(2, "colspan=9") = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    '--- ��2005/05/17 MOD Falcon�� ---

                    '34�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�������@�F" & Convert.ToString(dr.Item("TKIGNM"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '35�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�쓮�����@�@�F" & Convert.ToString(dr.Item("TSADNM"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '36�s��
                    '2006/06/14 NEC UPDATE START
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�o���w���@�@�F" & Convert.ToString(dr.Item("SDNM"))
                    '2006/06/14 NEC UPDATE END
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '37�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�o���w�����l�F" & Convert.ToString(dr.Item("SIJI_BIKO1"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '38�s��
                    ExcelC.pCellStyle(1) = "border-style:none"
                    ExcelC.pCellVal(1, "colspan=10") = "�@�@�@�@�@�@�@" & Convert.ToString(dr.Item("siji_biko2"))
                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                    '39�s��
                    '2006/06/15 NEC UPDATE START
                    'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    '2006/06/15 NEC UPDATE END

                    '40�s��
                    ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none"
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
                        ExcelC.pCellVal(1, "colspan=3") = "�Ή��ҁ@�@ �F" & Convert.ToString(dr.Item("SYUTDTNM"))
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
                        ExcelC.pCellVal(3, "colspan=4") = "�[�u���������F" & fncDateSet(Convert.ToString(dr.Item("SYOKANYMD"))) & " " & fncTimeSet(Convert.ToString(dr.Item("SYOKANTIME"))) ' 2008/10/14 T.Watabe add
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
                        ExcelC.pCellVal(1, "colspan=5") = "�K�X���F" & Convert.ToString(dr.Item("KIGNM"))
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
                        ExcelC.pCellStyle(2) = "border-style:none;height:64px;vertical-align:top"
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

                Next
            End If

            '�t�@�C���N���[�Y
            ExcelC.mClose()

            If pintDebugSQLNo = 108 Then ' DEBUG
                Return "DEBUG:(" & pintDebugSQLNo & ")[ExcelC.pDirName=" & ExcelC.pDirName & "]"
            End If

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
                    fncMakeZipWithPass(ExcelC.pDirName & ExcelC.pFileName & ".xls", ExcelC.pDirName & ExcelC.pFileName & ".zip", sZipFilePass)

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

                fncFileKill(ExcelC.pDirName & ExcelC.pFileName & ".xls") '�G�N�Z���t�@�C���폜�I
                fncFileKill(ExcelC.pDirName & ExcelC.pFileName & ".zip") 'zip�t�@�C���폜�I

                '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
            End If
        Catch ex As Exception
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
        Dim cdb As New cdb
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
            sql.Append("WHERE PROC_ID = 'BTFAXJBE00' ")
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

End Class
