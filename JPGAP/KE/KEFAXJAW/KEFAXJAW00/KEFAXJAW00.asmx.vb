'***********************************************
'�Ή����́@�i�`�e�`�w�쐬
'***********************************************
' �ύX����
' 2010/03/24 T.Watabe �Ď�����FAX�ԍ����e�`�w����Ɉ󎚂���悤�ɕύX
' 2010/08/30 T.Watabe �p���{����98%�֕ύX�BFAX��M���łQ�y�[�W�ɂȂ��Ă��܂����ۂ��������悤�ɕύX�B
' 2010/09/13 T.Watabe �ύX��߂��i�p���{����98%�֕ύX�BFAX��M���łQ�y�[�W�ɂȂ��Ă��܂����ۂ��������悤�ɕύX�B�j
' 2011/05/30 T.Watabe �Z�b�V�����̍쐬��GUID���烉���_���ȕ�������g�p����悤�ɕύX
' 2011/08/24 T.Watabe FAX���ꖇ�Ɏ��܂�Ȃ����̑Ή�(�d�b�A�����e��Z�߂�)
' 2012/03/26 W.GANEKO FAX�����[�����̓��[����đ��M�@�\�ǉ�

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Text
Imports System.Web.Services
Imports System.Configuration    '//Configuration
Imports System.IO

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KEFAXJAW00/KEFAXJAW00")> _
Public Class KEFAXJAW00
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

    'Excel�N���X
    Dim ExcelC As New CExcel

    Private gstrPATH As String      '//�t�H���_�p�X
    '--- ��2005/05/10 DEL Falcon�� ---
    'Private gstrPGCD As String      '//�v���O����ID     
    '--- ��2005/05/10 DEL Falcon�� ---
    '--- ��2005/05/10 MOD Falcon�� ---
    Private gstrPGCD As String = "KEFAXJAW00"   '//�v���O����ID     
    '--- ��2005/05/10 MOD Falcon�� ---
    Private gstrRecText() As String

    '--- 2005/09/22 UPDATE START ---
    Private gstrPoint As String = "~"
    'Private gstrPoint As String = ">"
    '--- 2005/09/22 UPDATE START ---

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    '�@DATA0�F�Ώۃf�[�^������܂���
    '  2014/12/24 T.Ono mod 2014���P�J�� No4 ������pstrBtnKBN�ǉ� 1:�d�bFAX���[�����M�����@2:�v���r���[����
    <WebMethod()> Public Function mExcel( _
                                            ByVal pstrSessionID As String, _
                                            ByVal pstrTEXT_NAME As String, _
                                            ByVal pstrSEND_NAME As String, _
                                            ByVal pstrSEND_POST As String, _
                                            ByVal pstrSEND_ADDS As String, _
                                            ByVal pstrSEND_FAX As String, _
                                            ByVal pstrSEND_TEL As String, _
                                            ByVal pstrBtnKBN As String _
                                            ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow

        Dim UtilFucC As New CUtilFuc

        '���s������s��
        'Dim intGYOSU As Integer = 47 ' 2008/02/29 T.Watabe edit
        Dim intGYOSU As Integer = 53
        '���t�ϊ��N���X
        Dim DateFncC As New CDateFnc
        '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim FileToStrC As New CFileStr

        Dim arrFaxData() As String
        Dim strTaiouTextName As String
        Dim strFaxData As String
        Dim strTaiouText As String

        ReDim gstrRecText(0)

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        Dim strRec As String = "OK"
        Try
            '--- ��2005/05/10 DEL Falcon�� ---
            'gstrPGCD = "KEFAXJAW00"
            '--- ��2005/05/10 DEL Falcon�� ---
            gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "\00\"
            'gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "00"
            '�Ή����̓f�[�^�e�L�X�g
            strTaiouTextName = gstrPGCD & "\" & pstrTEXT_NAME

            '//------------------------------------------------------------
            '�Ή����̓f�[�^�t�@�C����ǂݍ���
            strRec = fncTaiouRecv(strTaiouTextName, strTaiouText)
            If strRec <> "OK" Then
                Return strRec
            End If

            '//">"��؂�f�[�^���擾�@�z��Ɋi�[
            If strTaiouText.Length <> 0 Then
                arrFaxData = strTaiouText.Split(Convert.ToChar(gstrPoint))
            End If

            '//�f�[�^�Z�b�g ----------------------------------
            Dim strSYONO As String = arrFaxData(0)                          '�����ԍ�
            Dim strFAXTITLE As String = arrFaxData(1)                       '�e�`�w�^�C�g��
            Dim strACBCD As String = arrFaxData(2)                          '�i�`�x���R�[�h
            Dim strKURACD As String = arrFaxData(3)                         '�N���C�A���g�R�[�h
            Dim strKANSCD As String = arrFaxData(4)                         '�Ď��Z���^�[�R�[�h
            Dim strJUSYONM As String = arrFaxData(5)                        '���q�l����
            Dim strUSER_CD As String = arrFaxData(6)                        '���q�l�R�[�h
            Dim strJUTEL1 As String = arrFaxData(7)                         '����d�b�s�O
            Dim strJUTEL2 As String = arrFaxData(8)                         '����d�b�s��
            Dim strRENTEL As String = arrFaxData(9)                         '�A���d�b�ԍ�
            Dim strADDR As String = arrFaxData(10)                          '�Z��
            Dim strHATYMD As String = arrFaxData(11)                        '������
            Dim strHATTIME As String = arrFaxData(12)                       '��������
            Dim strKENSIN As String = arrFaxData(13)                        '���[�^�l
            Dim strRYURYO As String = arrFaxData(14)                        '���ʋ敪
            Dim strMETASYU As String = arrFaxData(15)                       '���[�^���
            Dim strKMNM1 As String = arrFaxData(16)                         '�x�񃁃b�Z�[�W�P
            Dim strKMNM2 As String = arrFaxData(17)                         '�x�񃁃b�Z�[�W�Q
            Dim strKMNM3 As String = arrFaxData(18)                         '�x�񃁃b�Z�[�W�R
            Dim strKMNM4 As String = arrFaxData(19)                         '�x�񃁃b�Z�[�W�S
            Dim strKMNM5 As String = arrFaxData(20)                         '�x�񃁃b�Z�[�W�T
            Dim strKMNM6 As String = arrFaxData(21)                         '�x�񃁃b�Z�[�W�U
            Dim strTAIOKBN As String = fncGET_PULLNM("09", arrFaxData(22))  '�Ή��敪
            Dim strTKTANCD As String = arrFaxData(23)                       '�Ď��Z���^�[�S����
            Dim strSYOYMD As String = arrFaxData(24)                        '�Ή�������
            Dim strSYOTIME As String = arrFaxData(25)                       '�Ή���������
            Dim strSIJIYMD As String = arrFaxData(26)                       '�o���w����
            Dim strSIJITIME As String = arrFaxData(27)                      '�o���w������
            Dim strTAITCD As String = fncGET_PULLNM("12", arrFaxData(28))   '�A������
            Dim strTELRCD As String = fncGET_PULLNM("15", arrFaxData(29))   '�d�b�A�����e
            Dim strFUK_MEMO As String = arrFaxData(30)                      '���A���상��
            Dim strTEL_MEMO1 As String = arrFaxData(31)                     '�d�b�����P
            Dim strTEL_MEMO2 As String = arrFaxData(32)                     '�d�b�����Q
            '2020/11/01 T.Ono mod 2020�Ď����P Start
            'Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(33))   '�������
            'Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(34))   '�쓮����
            'Dim strFAX_REN As String = arrFaxData(35)                       '�˗����e
            'Dim strMITOKBN As String = arrFaxData(36)                       '���o�^�e�k�f
            Dim strTEL_MEMO4 As String = arrFaxData(33)                     '�d�b�����S
            Dim strTEL_MEMO5 As String = arrFaxData(34)                     '�d�b�����T
            Dim strTEL_MEMO6 As String = arrFaxData(35)                     '�d�b�����U
            Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(36))   '�������
            Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(37))   '�쓮����
            Dim strFAX_REN As String = arrFaxData(38)                       '�˗����e
            Dim strMITOKBN As String = arrFaxData(39)                       '���o�^�e�k�f
            '2020/11/01 T.Ono mod 2020�Ď����P End
            '//------------------------------------------------
            '2006/06/09 NEC ADD START
            Dim strMAP_CD As String                                         '�n�}�ԍ�
            Dim strUSER_FLG As String                                       '���q�l���
            '2006/06/09 NEC ADD END
            '���R�[�h���Z�b�g
            If strKURACD.Length <> 0 Then
                ExcelC.pKencd = strKURACD.Substring(1, 2)
            Else
                '--- ��2005/05/12 DEL Falcon�� ---
                'ExcelC.pKencd = "99"
                '--- ��2005/05/12 DEL Falcon�� ---
                '--- ��2005/05/12 MOD Falcon�� ---
                ExcelC.pKencd = "00"
                '--- ��2005/05/12 MOD Falcon�� ---
            End If
            '�Z�b�V����ID
            ExcelC.pSessionID = pstrSessionID

            '���[ID
            ExcelC.pRepoID = "KEFAXJAX00"

            '���[�c
            ExcelC.pLandScape = False

            '�t�@�C���I�[�v��
            ExcelC.mOpen()

            '�^�C�g��
            ExcelC.pTitle = strFAXTITLE

            '�쐬��
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))

            '�k���g�嗦
            'ExcelC.pScale = 100 ' 2010/08/30 T.Watabe edit
            'ExcelC.pScale = 98 ' 2010/09/13 T.Watabe edit
            ExcelC.pScale = 100

            '�\���{��80%��       '2016/12/13 H.Mori add 2016���P�J�� No6-2 
            ExcelC.pZoom = 80

            '�y�[�W�c����1�ցi1�y�[�W�Ɏ��߂�)       '2022/07/20 Y.Arakaki add �����C��
            'ExcelC.pPageCnt = 1 '�f�B�X�v���C�ݒ�ŉ��Ƃ�����ׁA��x�R�����g�A�E�g�B�Ďg�p���̓R�����g�����B

            '�ǉ����� 20220720_Y.arakaki
            'ExcelC.pFitPaper = True '�c��1�y�[�WON �ʏ��false�ŏk���g�嗦���Q�ƁB'�f�B�X�v���C�ݒ�ŉ��Ƃ�����ׁA��x�R�����g�A�E�g�B�Ďg�p���̓R�����g�����B

            '�]��
            ExcelC.pMarginTop = 1.8D
            'ExcelC.pMarginBottom = 1.5D ' 2008/02/29 T.Watabe edit
            ExcelC.pMarginBottom = 0D
            ExcelC.pMarginLeft = 1.2D
            ExcelC.pMarginRight = 1.5D
            ExcelC.pMarginHeader = 1.3D
            'ExcelC.pMarginFooter = 1.3D ' 2008/02/29 T.Watabe edit
            ExcelC.pMarginFooter = 0D

            '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
            ExcelC.mHeader(intGYOSU, intGYOSU, 1)

            '�e��̕����s�N�Z���ŃZ�b�g�B�g���������B
            '1�s��
            'ExcelC.pCellStyle(1) = "width:40px;border-style:none"  '-- 2005/05/21 MOD Falcon ---
            ExcelC.pCellStyle(1) = "width:32px;border-style:none"
            ExcelC.pCellStyle(2) = "width:103px;border-style:none"
            ExcelC.pCellStyle(3) = "width:72px;border-style:none"
            ExcelC.pCellStyle(4) = "width:72px;border-style:none"
            ExcelC.pCellStyle(5) = "width:72px;border-style:none"
            ExcelC.pCellStyle(6) = "width:72px;border-style:none"
            ExcelC.pCellStyle(7) = "width:72px;border-style:none"
            ExcelC.pCellStyle(8) = "width:72px;border-style:none"
            ExcelC.pCellStyle(9) = "width:72px;border-style:none"
            ExcelC.pCellStyle(10) = "width:80px;border-style:none"
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
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '--------------------------------------------------
            '�f�[�^�̎擾
            '--------------------------------------------------
            strSQL.Append("SELECT ")
            strSQL.Append("JA.JA_NAME, ")
            strSQL.Append("JA.JAS_NAME, ")
            strSQL.Append("CL.KEN_NAME, ")
            strSQL.Append("HA.NAME AS HAISO_NAME, ")
            strSQL.Append("KA.KANSI_NAME, ")
            '2006/06/14 NEC UPDATE START
            strSQL.Append("KA.TEL, ")
            '2006/06/14 NEC UPDATE END
            strSQL.Append("KA.KINKYU_TEL, ") ' 2010/03/24 T.Watabe add �Ď�����FAX�ԍ�
            strSQL.Append("TA.TANNM ")
            strSQL.Append("FROM HN2MAS JA, ")
            strSQL.Append("     CLIMAS CL, ")
            strSQL.Append("     HAIMAS HA, ")
            strSQL.Append("     KANSIMAS KA, ")
            strSQL.Append("     M05_TANTO TA ")
            strSQL.Append("WHERE CL.CLI_CD = :KURACD ")
            strSQL.Append("  AND CL.CLI_CD = JA.CLI_CD(+) ")
            strSQL.Append("  AND :ACBCD = JA.HAN_CD(+) ")
            strSQL.Append("  AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD(+) ")
            strSQL.Append("  AND JA.HAISO_CD = HA.HAISO_CD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = KA.KANSI_CD(+) ")
            strSQL.Append("  AND '1' = TA.KBN(+) ")
            '--- ��2005/07/19 ADD Falcon�� ---
            strSQL.Append("  AND 'ZZZZ' = TA.KURACD(+) ")
            '--- ��2005/07/19 ADD Falcon�� ---
            strSQL.Append("  AND CL.KANSI_CODE = TA.CODE(+) ")
            strSQL.Append("  AND :TKTANCD = TA.TANCD(+) ")


            '//SQL�Z�b�g
            cdb.pSQL = strSQL.ToString
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("KURACD") = strKURACD
            cdb.pSQLParamStr("ACBCD") = strACBCD
            cdb.pSQLParamStr("TKTANCD") = strTKTANCD

            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                'Return "DATA0"
            Else
                '//�f�[�^���i�[
                dr = ds.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD START
            Dim dsShamas As New DataSet
            Dim drShamas As DataRow
            Dim strSQL_Shamas As New StringBuilder("")

            strSQL_Shamas.Append("SELECT ")
            strSQL_Shamas.Append("MAP_CD, ")        '�n�}�ԍ�
            strSQL_Shamas.Append("USER_FLG ")      '���q�l���
            strSQL_Shamas.Append("FROM SHAMAS ")
            strSQL_Shamas.Append("WHERE CLI_CD=:CLI_CD AND ")
            strSQL_Shamas.Append(" HAN_CD=:HAN_CD AND ")
            strSQL_Shamas.Append(" USER_CD=:USER_CD ")

            '//SQL�Z�b�g
            cdb.pSQL = strSQL_Shamas.ToString
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("CLI_CD") = strKURACD
            cdb.pSQLParamStr("HAN_CD") = strACBCD
            cdb.pSQLParamStr("USER_CD") = strUSER_CD

            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            dsShamas = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strSQL_Shamas.Remove(0, strSQL_Shamas.Length)
                strSQL_Shamas.Append("SELECT ")
                strSQL_Shamas.Append("'' AS MAP_CD, ")        '�n�}�ԍ�
                strSQL_Shamas.Append("'' AS USER_FLG ")      '���q�l���
                strSQL_Shamas.Append("FROM DUAL ")

                '//SQL�Z�b�g
                cdb.pSQL = strSQL_Shamas.ToString

                '//SQL���s
                cdb.mExecQuery()
                '//�f�[�^�Z�b�g�Ɋi�[
                dsShamas = cdb.pResult
                '//�f�[�^���i�[
                drShamas = dsShamas.Tables(0).Rows(0)
            Else
                '//�f�[�^���i�[
                drShamas = dsShamas.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD END

            '--------------------------------------------------
            '�f�[�^�̏o��
            '--------------------------------------------------
            Dim strTemp As String = ""

            '2�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2006/06/07 NEC UPDATE START
            'If ds.Tables(0).Rows.Count = 0 Then
            '    strTemp = ""
            'Else
            '    strTemp = Convert.ToString(dr.Item("JA_NAME"))
            'End If
            'ExcelC.pCellVal(1, "colspan=10") = "�i�`���F" & strTemp
            ExcelC.pCellVal(1, "colspan=10") = "���M��FAX�ԍ��F" & pstrSEND_TEL
            '2006/06/07 NEC UPDATE END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '3�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                If Convert.ToString(dr.Item("JAS_NAME")) = "" Then
                    strTemp = ""
                Else
                    strTemp = Convert.ToString(dr.Item("JAS_NAME")) & "�@�䒆"
                End If
            End If
            '2006/06/07 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=10") = "�x�����F" & strTemp
            ExcelC.pCellVal(1, "colspan=10") = "�i�`�x�����@ �F" & strTemp
            '2006/06/07 NEC UPDATE END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '4�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = ""
            ExcelC.pCellVal(2, "colspan=2") = ""
            '2006/06/14 NEC UPDATE START
            'ExcelC.pCellVal(3, "colspan=4 align=right") = "FAX�ԍ��F" & pstrSEND_TEL
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TEL"))
            End If
            ExcelC.pCellVal(3, "colspan=4 align=right") = "���M��TEL�F" & strTemp
            '2006/06/14 NEC UPDATE END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '2010/03/24 T.Watabe add
            '5�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = ""
            ExcelC.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KINKYU_TEL"))
            End If
            ExcelC.pCellVal(3, "colspan=4 align=right") = "���M��FAX�F" & strTemp
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '6�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KEN_NAME"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "���@�@�@���@ �F" & strTemp
            ExcelC.pCellVal(2, "colspan=5 align=right") = "���M�ҁF" & pstrSEND_NAME
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '7�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("HAISO_NAME"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "�����������@ �F" & strTemp
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KANSI_NAME"))
            End If
            ExcelC.pCellVal(2, "colspan=5 align=right") = strTemp
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '7�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '8�s��
            ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = ""
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '9�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "<<��M���>>"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '10�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2006/06/13 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=10") = "���q�l�����F" & strJUSYONM
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC.pCellVal(1, "colspan=7") = "���q�l�����F" & strJUSYONM
            ExcelC.pCellVal(1, "colspan=7") = "���q�l���@�F" & strJUSYONM
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END

            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("MAP_CD"))
            End If
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            '2006/06/23 NEC UPDATE START
            'ExcelC.pCellVal(2, "colspan=2") = "�n�}�m���F" & strTemp
            'ExcelC.pCellVal(2, "colspan=3") = "�n�}�m���@�F" & strTemp
            '2006/06/23 NEC UPDATE END
            ExcelC.pCellVal(2, "colspan=3") = "�n�}�ԍ��@�F" & strTemp
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            '2006/06/13 NEC UPDATE END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '11�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2006/06/07 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=5") = "�d�b�ԍ��F" & strJUTEL1 & strJUTEL2
            'ExcelC.pCellVal(1, "colspan=10") = "���q�l�R�[�h�F" & strUSER_CD
            '2006/06/13 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=10") = "���q�l�R�[�h�F" & strACBCD & strUSER_CD
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=7") = "���q�l���ށF" & strACBCD & strUSER_CD
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("USER_FLG"))
            End If

            Select Case strTemp
                Case "0"
                    '0:���J��
                    ExcelC.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "���J��"
                Case "1"
                    '1:�^�p��
                    ExcelC.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "�^�p��"
                Case "2"
                    '2:�x�~��
                    ExcelC.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "�x�~��"
                Case Else
                    '���̑�
                    ExcelC.pCellVal(2, "colspan=3") = "���q�l��ԁF"
            End Select
            '2006/06/13 NEC UPDATE END
            '2006/06/07 NEC UPDATE END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '12�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2006/06/07 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=5") = "�d�b�ԍ��F" & strJUTEL1 & strJUTEL2
            'ExcelC.pCellVal(1, "colspan=5") = "�d�b�ԍ��F" & strJUTEL1 & "-" & strJUTEL2
            '2006/06/07 NEC UPDATE END
            '2006/06/20 NEC UPDATE START
            'ExcelC.pCellVal(1, "colspan=4") = "�d�b�ԍ��F" & Convert.ToString(dr.Item("KTELNO"))
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'If strJUTEL1 = "" Or strJUTEL2 = "" Then
            '    ExcelC.pCellVal(1, "colspan=5") = "�d�b�ԍ��@�F" & strJUTEL1 & strJUTEL2
            'Else
            '    ExcelC.pCellVal(1, "colspan=5") = "�d�b�ԍ��@�F" & strJUTEL1 & "-" & strJUTEL2
            'End If
            ''2006/06/20 NEC UPDATE END
            'ExcelC.pCellVal(2, "colspan=5") = "�A���d�b�ԍ��F" & strRENTEL
            If strJUTEL1 = "" Or strJUTEL2 = "" Then
                ExcelC.pCellVal(1, "colspan=5") = "�����ԍ��@�F" & strJUTEL1 & strJUTEL2
            Else
                ExcelC.pCellVal(1, "colspan=5") = "�����ԍ��@�F" & strJUTEL1 & "-" & strJUTEL2
            End If
            ExcelC.pCellVal(2, "colspan=5") = "�A����F" & strRENTEL
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '13�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�Z���@�@�@�F" & strADDR
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '14�s��
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '15�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�y�x����e�z"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '16�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC.pCellVal(1, "colspan=4") = "�������@�@�F" & strHATYMD & " " & strHATTIME
            ExcelC.pCellVal(1, "colspan=4") = "��M�����@�F" & strHATYMD & " " & strHATTIME
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC.pCellVal(2, "colspan=6") = "���[�^�l�@�F" & strKENSIN
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '17�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = "���ʋ敪�@�F" & strRYURYO
            ExcelC.pCellVal(2, "colspan=6") = "���[�^��ʁF" & strMETASYU
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '18�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "1�F" & strKMNM1
            ExcelC.pCellVal(2, "colspan=5") = "4�F" & strKMNM4
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '19�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "2�F" & strKMNM2
            ExcelC.pCellVal(2, "colspan=5") = "5�F" & strKMNM5
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '20�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "3�F" & strKMNM3
            ExcelC.pCellVal(2, "colspan=5") = "6�F" & strKMNM6
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '21�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '21�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            'ExcelC.pCellVal(1, "colspan=10") = ""
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '21�s��
            'ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"    2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "<<�Ď��Z���^�[�Ή����e>>"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '22�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "�Ή��敪�@�@�F" & strTAIOKBN
            ExcelC.pCellVal(2, "colspan=5") = "�����ԍ�(�Ɖ�p)�F" & strSYONO
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '23�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TANNM"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "�Ď������S���F" & strTemp
            'ExcelC.pCellVal(2, "colspan=5") = "�Ή����F" & strSYOYMD & " " & strSYOTIME 2008/10/14 T.Watabe edit
            
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC.pCellVal(2, "colspan=5") = "���������@�@�@�@�F" & strSYOYMD & " " & strSYOTIME
            ExcelC.pCellVal(2, "colspan=5") = "�Ή����������@�@�F" & strSYOYMD & " " & strSYOTIME
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '24�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC.pCellVal(1, "colspan=10") = "�˗����@�@�@�F" & strSIJIYMD & " " & strSIJITIME
            ExcelC.pCellVal(1, "colspan=10") = "�˗������@�@�F" & strSIJIYMD & " " & strSIJITIME
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '25�s��
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '26�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�A������@�@�F" & strTAITCD
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '27�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�d�b�A�����e�F" & strTELRCD
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ' 2011/08/24 T.Watabe edit
            '''30�s��
            ''ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            '''--- ��2005/05/17 MOD Falcon�� ---
            '''�o�͏���d�b�����P�˓d�b�����Q�˕��A���상���ɏC��
            '''31�s��
            '''--- ��2005/05/16 MOD Falcon�� ---
            ''ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '''ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '''10�񌋍��ɕύX
            ''ExcelC.pCellVal(1, "colspan=10") = strTEL_MEMO1
            '''ExcelC.pCellVal(2, "colspan=1") = ""
            ''ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            '''--- ��2005/05/16 MOD Falcon�� ---
            '''32�s��
            '''--- ��2005/05/16 MOD Falcon�� ---
            ''ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '''ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ''ExcelC.pCellVal(1, "colspan=10") = strTEL_MEMO2
            '''ExcelC.pCellVal(2, "colspan=1") = ""
            ''ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            '''--- ��2005/05/16 MOD Falcon�� ---
            '''33�s��
            '''--- ��2005/05/16 MOD Falcon�� ---
            ''ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '''ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            '''10�񌋍��ɕύX
            ''ExcelC.pCellVal(1, "colspan=10") = strFUK_MEMO
            '''ExcelC.pCellVal(2, "colspan=1") = ""
            ''ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            '''--- ��2005/05/16 MOD Falcon�� ---
            '''--- ��2005/05/17 MOD Falcon�� ---
            '28�s��
            ExcelC.pCellStyle(1) = "border-style:none"
            'ExcelC.pCellStyle(2) = "border-style:none;height:72px;vertical-align:top" '�����w�肷��ƁA���s���ύ��ɂȂ炸�P�s�ɂȂ��Ă��܂��B
            ExcelC.pCellStyle(2) = "border-style:none;vertical-align:top"
            ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO    2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO & strTEL_MEMO4 & strTEL_MEMO5 & strTEL_MEMO6
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '29�s��
            ExcelC.pCellStyle(1) = "border-style:none;height:6pt"    '2020/11/01 T.Ono add 2020�Ď����P
            ExcelC.pCellVal(1, "colspan=10") = ""    '2020/11/01 T.Ono add 2020�Ď����P
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '30�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC.pCellVal(1, "colspan=10") = "�������@�F" & strTKIGCD
            ExcelC.pCellVal(1, "colspan=10") = "�������@�@�F" & strTKIGCD
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '31�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�쓮�����@�@�F" & strTSADCD
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '32�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            ''2015/05/13 H.Mori mod �������̂ЂƂ�̍s���k�� START
            ''ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            'ExcelC.pCellStyle(1) = "border-style:none;height:9pt"
            'ExcelC.pCellVal(1) = ""
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ''2015/05/13 H.Mori mod �������̂ЂƂ�̍s���k�� END

            '32�s��
            '2015/04/30 H.Mori mod ���������g��
            'ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(1) = "border-style:none;height:47pt;vertical-align:top;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC.pCellVal(1, "colspan=10") = "�˗����e�@�@�F" & strFAX_REN
            ExcelC.pCellVal(1, "colspan=10") = "�������@�@�@�F" & strFAX_REN
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '33�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2021/02/12 T.Ono mod ���̕����͕\�����Ȃ� Start
            ''If strMITOKBN = "1" Then    2020/11/01 T.Ono mod vbCRLF���t���Ă��Ĕ��f�ł��ĂȂ�
            'If strMITOKBN.Substring(0, 1) = "1" Then
            '    ExcelC.pCellVal(1, "colspan=10") = "�u���q�l�}�X�^�[�@�����A�Z���A�d�b�ԍ������m�F�̏�A���A�����������B�v"
            'Else
            '    ExcelC.pCellVal(1, "colspan=10") = ""
            'End If
            ExcelC.pCellVal(1, "colspan=10") = ""
            '2021/02/12 T.Ono mod ���̕����͕\�����Ȃ� Start
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ' 2008/02/29 T.Watabe del
            '40�s��
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '41�s��
            'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            'ExcelC.pCellVal(1, "colspan=10") = ""
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ' 2008/02/29 T.Watabe add
            '34�s�ځ`44�s��
            ExcelC.pCellStyle(1) = "border:.5pt solid black; height:23.25pt; font-size:12pt"
            ExcelC.pCellVal(1, "colspan=3") = "���Ə����F"
            ExcelC.pCellStyle(4) = "border:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(4, "colspan=3") = "�Ή��Җ��F"
            ExcelC.pCellStyle(7) = "border:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(7, "colspan=4") = "�Ή������F"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC.pCellStyle(1) = "border:.5pt solid black; height:195.0pt;width:24pt;font-size:13pt;background:silver;layout-flow:vertical"
            'ExcelC.pCellVal(1, "rowspan=12") = "�Ή�����" ' 2010/03/24 T.Watabe edit �P�s���₵���̂ŉ�����P�s���炷
            '2015/04/30 H.Mori mod �Ή����ʂ���s���폜 
            'ExcelC.pCellVal(1, "rowspan=11") = "�Ή�����"
            ExcelC.pCellVal(1, "rowspan=10") = "�Ή�����"
            ExcelC.pCellStyle(2) = "border-right:.5pt solid black;font-size:12pt"
            'ExcelC.pCellVal(2, "colspan=9 rowspan=10") = "�@" ' 2010/03/24 T.Watabe edit �P�s���₵���̂ŉ�����P�s���炷
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            '2015/04/30 H.Mori mod �Ή����ʂ���s���폜 
            'ExcelC.pCellVal(2, "colspan=9 rowspan=9") = "�@"
            ExcelC.pCellVal(2, "colspan=9 rowspan=8") = "�@"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            '2015/04/30 H.Mori del �Ή����ʂ���s���폜 
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9") = "���������F"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9") = "�񍐓����F"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������


            '�t�b�^���ڂ̏����o���ƁA�t�@�C���N���[�Y
            ExcelC.mClose()

            '//�e�L�X�g�f�[�^�t�@�C���̍폜
            Kill(gstrPATH & strTaiouTextName)

            '2014/12/25 T.Ono mod 2014���P�J�� No4 START
            ''�쐬�����t�@�C����Base64�G���R�[�h���Ė߂�
            'Return FileToStrC.mFileToStr(ExcelC.pDirName & ExcelC.pFileName & ".xls")
            If pstrBtnKBN = "2" Then
                '�v���r���[�{�^�����������ꍇ(JPG����Ă΂ꂽ�ꍇ)
                Return ExcelC.pDirName & ExcelC.pFileName & ".xls"
            Else
                '���M�{�^�����������ꍇ(KEFAXJAE00.exe����Ă΂ꂽ�ꍇ)
                Return FileToStrC.mFileToStr(ExcelC.pDirName & ExcelC.pFileName & ".xls")
            End If
            '2014/12/25 T.Ono mod 2014���P�J�� No4 END

        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            '�ڑ��N���[�Y
            cdb.mClose()

        End Try

    End Function
    '2015/12/09 w.ganeko 2015���P�J�� ��2 start
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    <WebMethod()> Public Function mExcelSpot( _
                                            ByVal pstrRoop As String, _
                                            ByVal pstrSessionID As String, _
                                            ByVal pstrTEXT_NAME As String, _
                                            ByVal pstrSEND_NAME As String, _
                                            ByVal pstrSEND_POST As String, _
                                            ByVal pstrSEND_ADDS As String, _
                                            ByVal pstrSEND_FAX As String, _
                                            ByVal pstrSEND_TEL As String, _
                                            ByVal pstrBtnKBN As String _
                                            ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow

        Dim UtilFucC As New CUtilFuc

        '���s������s��
        'Dim intGYOSU As Integer = 47 ' 2008/02/29 T.Watabe edit
        Dim intGYOSU As Integer = 53
        '���t�ϊ��N���X
        Dim DateFncC As New CDateFnc
        '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim FileToStrC As New CFileStr

        Dim arrFaxData() As String
        Dim strTaiouTextName As String
        Dim strFaxData As String
        Dim strTaiouText As String

        ReDim gstrRecText(0)

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        Dim strRec As String = "OK"
        Try
            gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "\00\"
            '�Ή����̓f�[�^�e�L�X�g
            strTaiouTextName = gstrPGCD & "\" & pstrTEXT_NAME

            '//------------------------------------------------------------
            '�Ή����̓f�[�^�t�@�C����ǂݍ���
            strRec = fncTaiouRecv(strTaiouTextName, strTaiouText)
            If strRec <> "OK" Then
                Return strRec
            End If

            '//">"��؂�f�[�^���擾�@�z��Ɋi�[
            If strTaiouText.Length <> 0 Then
                arrFaxData = strTaiouText.Split(Convert.ToChar(gstrPoint))
            End If

            '//�f�[�^�Z�b�g ----------------------------------
            Dim strSYONO As String = arrFaxData(0)                          '�����ԍ�
            Dim strFAXTITLE As String = arrFaxData(1)                       '�e�`�w�^�C�g��
            Dim strACBCD As String = arrFaxData(2)                          '�i�`�x���R�[�h
            Dim strKURACD As String = arrFaxData(3)                         '�N���C�A���g�R�[�h
            Dim strKANSCD As String = arrFaxData(4)                         '�Ď��Z���^�[�R�[�h
            Dim strJUSYONM As String = arrFaxData(5)                        '���q�l����
            Dim strUSER_CD As String = arrFaxData(6)                        '���q�l�R�[�h
            Dim strJUTEL1 As String = arrFaxData(7)                         '����d�b�s�O
            Dim strJUTEL2 As String = arrFaxData(8)                         '����d�b�s��
            Dim strRENTEL As String = arrFaxData(9)                         '�A���d�b�ԍ�
            Dim strADDR As String = arrFaxData(10)                          '�Z��
            Dim strHATYMD As String = arrFaxData(11)                        '������
            Dim strHATTIME As String = arrFaxData(12)                       '��������
            Dim strKENSIN As String = arrFaxData(13)                        '���[�^�l
            Dim strRYURYO As String = arrFaxData(14)                        '���ʋ敪
            Dim strMETASYU As String = arrFaxData(15)                       '���[�^���
            Dim strKMNM1 As String = arrFaxData(16)                         '�x�񃁃b�Z�[�W�P
            Dim strKMNM2 As String = arrFaxData(17)                         '�x�񃁃b�Z�[�W�Q
            Dim strKMNM3 As String = arrFaxData(18)                         '�x�񃁃b�Z�[�W�R
            Dim strKMNM4 As String = arrFaxData(19)                         '�x�񃁃b�Z�[�W�S
            Dim strKMNM5 As String = arrFaxData(20)                         '�x�񃁃b�Z�[�W�T
            Dim strKMNM6 As String = arrFaxData(21)                         '�x�񃁃b�Z�[�W�U
            Dim strTAIOKBN As String = fncGET_PULLNM("09", arrFaxData(22))  '�Ή��敪
            Dim strTKTANCD As String = arrFaxData(23)                       '�Ď��Z���^�[�S����
            Dim strSYOYMD As String = arrFaxData(24)                        '�Ή�������
            Dim strSYOTIME As String = arrFaxData(25)                       '�Ή���������
            Dim strSIJIYMD As String = arrFaxData(26)                       '�o���w����
            Dim strSIJITIME As String = arrFaxData(27)                      '�o���w������
            Dim strTAITCD As String = fncGET_PULLNM("12", arrFaxData(28))   '�A������
            Dim strTELRCD As String = fncGET_PULLNM("15", arrFaxData(29))   '�d�b�A�����e
            Dim strFUK_MEMO As String = arrFaxData(30)                      '���A���상��
            Dim strTEL_MEMO1 As String = arrFaxData(31)                     '�d�b�����P
            Dim strTEL_MEMO2 As String = arrFaxData(32)                     '�d�b�����Q
            '2020/11/01 T.Ono mod 2020�Ď����P Start
            'Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(33))   '�������
            'Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(34))   '�쓮����
            'Dim strFAX_REN As String = arrFaxData(35)                       '�˗����e
            'Dim strMITOKBN As String = arrFaxData(36)                       '���o�^�e�k�f
            Dim strTEL_MEMO4 As String = arrFaxData(33)                     '�d�b�����S
            Dim strTEL_MEMO5 As String = arrFaxData(34)                     '�d�b�����T
            Dim strTEL_MEMO6 As String = arrFaxData(35)                     '�d�b�����U
            Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(36))   '�������
            Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(37))   '�쓮����
            Dim strFAX_REN As String = arrFaxData(38)                       '�˗����e
            Dim strMITOKBN As String = arrFaxData(39)                       '���o�^�e�k�f
            '2020/11/01 T.Ono mod 2020�Ď����P End
            '//------------------------------------------------
            '2006/06/09 NEC ADD START
            Dim strMAP_CD As String                                         '�n�}�ԍ�
            Dim strUSER_FLG As String                                       '���q�l���
            '���R�[�h���Z�b�g
            If strKURACD.Length <> 0 Then
                ExcelC.pKencd = strKURACD.Substring(1, 2)
            Else
                ExcelC.pKencd = "00"
            End If
            '�Z�b�V����ID
            ExcelC.pSessionID = pstrRoop & pstrSessionID

            '���[ID
            ExcelC.pRepoID = "KEFAXJAX00"

            '���[�c
            ExcelC.pLandScape = False

            '�t�@�C���I�[�v��
            ExcelC.mOpen()

            '�^�C�g��
            ExcelC.pTitle = strFAXTITLE

            '�쐬��
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))

            '�k���g�嗦
            ExcelC.pScale = 100

            '�]��
            ExcelC.pMarginTop = 1.8D
            ExcelC.pMarginBottom = 0D
            ExcelC.pMarginLeft = 1.2D
            ExcelC.pMarginRight = 1.5D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 0D

            '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
            ExcelC.mHeader(intGYOSU, intGYOSU, 1)

            '�e��̕����s�N�Z���ŃZ�b�g�B�g���������B
            '1�s��
            ExcelC.pCellStyle(1) = "width:32px;border-style:none"
            ExcelC.pCellStyle(2) = "width:103px;border-style:none"
            ExcelC.pCellStyle(3) = "width:72px;border-style:none"
            ExcelC.pCellStyle(4) = "width:72px;border-style:none"
            ExcelC.pCellStyle(5) = "width:72px;border-style:none"
            ExcelC.pCellStyle(6) = "width:72px;border-style:none"
            ExcelC.pCellStyle(7) = "width:72px;border-style:none"
            ExcelC.pCellStyle(8) = "width:72px;border-style:none"
            ExcelC.pCellStyle(9) = "width:72px;border-style:none"
            ExcelC.pCellStyle(10) = "width:80px;border-style:none"
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
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '--------------------------------------------------
            '�f�[�^�̎擾
            '--------------------------------------------------
            strSQL.Append("SELECT ")
            strSQL.Append("JA.JA_NAME, ")
            strSQL.Append("JA.JAS_NAME, ")
            strSQL.Append("CL.KEN_NAME, ")
            strSQL.Append("HA.NAME AS HAISO_NAME, ")
            strSQL.Append("KA.KANSI_NAME, ")
            strSQL.Append("KA.TEL, ")
            strSQL.Append("KA.KINKYU_TEL, ") ' 2010/03/24 T.Watabe add �Ď�����FAX�ԍ�
            strSQL.Append("TA.TANNM ")
            strSQL.Append("FROM HN2MAS JA, ")
            strSQL.Append("     CLIMAS CL, ")
            strSQL.Append("     HAIMAS HA, ")
            strSQL.Append("     KANSIMAS KA, ")
            strSQL.Append("     M05_TANTO TA ")
            strSQL.Append("WHERE CL.CLI_CD = :KURACD ")
            strSQL.Append("  AND CL.CLI_CD = JA.CLI_CD(+) ")
            strSQL.Append("  AND :ACBCD = JA.HAN_CD(+) ")
            strSQL.Append("  AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD(+) ")
            strSQL.Append("  AND JA.HAISO_CD = HA.HAISO_CD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = KA.KANSI_CD(+) ")
            strSQL.Append("  AND '1' = TA.KBN(+) ")
            strSQL.Append("  AND 'ZZZZ' = TA.KURACD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = TA.CODE(+) ")
            strSQL.Append("  AND :TKTANCD = TA.TANCD(+) ")


            '//SQL�Z�b�g
            cdb.pSQL = strSQL.ToString
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("KURACD") = strKURACD
            cdb.pSQLParamStr("ACBCD") = strACBCD
            cdb.pSQLParamStr("TKTANCD") = strTKTANCD

            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                'Return "DATA0"
            Else
                '//�f�[�^���i�[
                dr = ds.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD START
            Dim dsShamas As New DataSet
            Dim drShamas As DataRow
            Dim strSQL_Shamas As New StringBuilder("")

            strSQL_Shamas.Append("SELECT ")
            strSQL_Shamas.Append("MAP_CD, ")        '�n�}�ԍ�
            strSQL_Shamas.Append("USER_FLG ")      '���q�l���
            strSQL_Shamas.Append("FROM SHAMAS ")
            strSQL_Shamas.Append("WHERE CLI_CD=:CLI_CD AND ")
            strSQL_Shamas.Append(" HAN_CD=:HAN_CD AND ")
            strSQL_Shamas.Append(" USER_CD=:USER_CD ")

            '//SQL�Z�b�g
            cdb.pSQL = strSQL_Shamas.ToString
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("CLI_CD") = strKURACD
            cdb.pSQLParamStr("HAN_CD") = strACBCD
            cdb.pSQLParamStr("USER_CD") = strUSER_CD

            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            dsShamas = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strSQL_Shamas.Remove(0, strSQL_Shamas.Length)
                strSQL_Shamas.Append("SELECT ")
                strSQL_Shamas.Append("'' AS MAP_CD, ")        '�n�}�ԍ�
                strSQL_Shamas.Append("'' AS USER_FLG ")      '���q�l���
                strSQL_Shamas.Append("FROM DUAL ")

                '//SQL�Z�b�g
                cdb.pSQL = strSQL_Shamas.ToString

                '//SQL���s
                cdb.mExecQuery()
                '//�f�[�^�Z�b�g�Ɋi�[
                dsShamas = cdb.pResult
                '//�f�[�^���i�[
                drShamas = dsShamas.Tables(0).Rows(0)
            Else
                '//�f�[�^���i�[
                drShamas = dsShamas.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD END

            '--------------------------------------------------
            '�f�[�^�̏o��
            '--------------------------------------------------
            Dim strTemp As String = ""

            '2�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "���M��FAX�ԍ��F" & pstrSEND_TEL
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '3�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                If Convert.ToString(dr.Item("JAS_NAME")) = "" Then
                    strTemp = ""
                Else
                    strTemp = Convert.ToString(dr.Item("JAS_NAME")) & "�@�䒆"
                End If
            End If
            ExcelC.pCellVal(1, "colspan=10") = "�i�`�x�����@ �F" & strTemp
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '4�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = ""
            ExcelC.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TEL"))
            End If
            ExcelC.pCellVal(3, "colspan=4 align=right") = "���M��TEL�F" & strTemp
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '4�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = ""
            ExcelC.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KINKYU_TEL"))
            End If
            ExcelC.pCellVal(3, "colspan=4 align=right") = "���M��FAX�F" & strTemp
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '5�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KEN_NAME"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "���@�@�@���@ �F" & strTemp
            ExcelC.pCellVal(2, "colspan=5 align=right") = "���M�ҁF" & pstrSEND_NAME
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '6�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("HAISO_NAME"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "�����������@ �F" & strTemp
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KANSI_NAME"))
            End If
            ExcelC.pCellVal(2, "colspan=5 align=right") = strTemp
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '7�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '8�s��
            ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = ""
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '9�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "<<��M���>>"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '10�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=7") = "���q�l���@�F" & strJUSYONM

            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("MAP_CD"))
            End If
            ExcelC.pCellVal(2, "colspan=3") = "�n�}�ԍ��@�F" & strTemp
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '11�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=7") = "���q�l���ށF" & strACBCD & strUSER_CD
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("USER_FLG"))
            End If

            Select Case strTemp
                Case "0"
                    '0:���J��
                    ExcelC.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "���J��"
                Case "1"
                    '1:�^�p��
                    ExcelC.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "�^�p��"
                Case "2"
                    '2:�x�~��
                    ExcelC.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "�x�~��"
                Case Else
                    '���̑�
                    ExcelC.pCellVal(2, "colspan=3") = "���q�l��ԁF"
            End Select
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '12�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If strJUTEL1 = "" Or strJUTEL2 = "" Then
                ExcelC.pCellVal(1, "colspan=5") = "�����ԍ��@�F" & strJUTEL1 & strJUTEL2
            Else
                ExcelC.pCellVal(1, "colspan=5") = "�����ԍ��@�F" & strJUTEL1 & "-" & strJUTEL2
            End If
            ExcelC.pCellVal(2, "colspan=5") = "�A����F" & strRENTEL
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '13�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�Z���@�@�@�F" & strADDR
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '14�s��
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '15�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�y�x����e�z"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '16�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = "��M�����@�F" & strHATYMD & " " & strHATTIME
            ExcelC.pCellVal(2, "colspan=6") = "���[�^�l�@�F" & strKENSIN
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '17�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=4") = "���ʋ敪�@�F" & strRYURYO
            ExcelC.pCellVal(2, "colspan=6") = "���[�^��ʁF" & strMETASYU
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '18�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "1�F" & strKMNM1
            ExcelC.pCellVal(2, "colspan=5") = "4�F" & strKMNM4
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '19�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "2�F" & strKMNM2
            ExcelC.pCellVal(2, "colspan=5") = "5�F" & strKMNM5
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '20�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "3�F" & strKMNM3
            ExcelC.pCellVal(2, "colspan=5") = "6�F" & strKMNM6
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '21�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '22�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            'ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            'ExcelC.pCellVal(1, "colspan=10") = ""
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '21�s��
            'ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"     2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "<<�Ď��Z���^�[�Ή����e>>"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '22�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=5") = "�Ή��敪�@�@�F" & strTAIOKBN
            ExcelC.pCellVal(2, "colspan=5") = "�����ԍ�(�Ɖ�p)�F" & strSYONO
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '23�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TANNM"))
            End If
            ExcelC.pCellVal(1, "colspan=5") = "�Ď������S���F" & strTemp

            ExcelC.pCellVal(2, "colspan=5") = "�Ή����������@�@�F" & strSYOYMD & " " & strSYOTIME
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '24�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�˗������@�@�F" & strSIJIYMD & " " & strSIJITIME
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '25�s��
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '26�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�A������@�@�F" & strTAITCD
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '27�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�d�b�A�����e�F" & strTELRCD
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '28�s��
            ExcelC.pCellStyle(1) = "border-style:none"
            ExcelC.pCellStyle(2) = "border-style:none;vertical-align:top"
            ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO    2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO & strTEL_MEMO4 & strTEL_MEMO5 & strTEL_MEMO6
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '29�s��
            ExcelC.pCellStyle(1) = "border-style:none;height:6pt"    '2020/11/01 T.Ono add 2020�Ď����P
            ExcelC.pCellVal(1, "colspan=10") = ""    '2020/11/01 T.Ono add 2020�Ď����P
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '30�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�������@�@�F" & strTKIGCD
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '31�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�쓮�����@�@�F" & strTSADCD
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '32�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            'ExcelC.pCellStyle(1) = "border-style:none;height:9pt"
            'ExcelC.pCellVal(1) = ""
            'ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '32�s��
            ExcelC.pCellStyle(1) = "border-style:none;height:47pt;vertical-align:top;font-size:13pt"
            ExcelC.pCellVal(1, "colspan=10") = "�������@�@�@�F" & strFAX_REN
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '33�s��
            ExcelC.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2021/02/12 T.Ono mod ���̕����͕\�����Ȃ� Start
            ''If strMITOKBN = "1" Then    2020/11/01 T.Ono mod
            'If strMITOKBN.Substring(0, 1) = "1" Then
            '    ExcelC.pCellVal(1, "colspan=10") = "�u���q�l�}�X�^�[�@�����A�Z���A�d�b�ԍ������m�F�̏�A���A�����������B�v"
            'Else
            '    ExcelC.pCellVal(1, "colspan=10") = ""
            'End If
            ExcelC.pCellVal(1, "colspan=10") = ""
            '2021/02/12 T.Ono mod ���̕����͕\�����Ȃ� END
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            '34�s�ځ`44�s��
            ExcelC.pCellStyle(1) = "border:.5pt solid black; height:23.25pt; font-size:12pt"
            ExcelC.pCellVal(1, "colspan=3") = "���Ə����F"
            ExcelC.pCellStyle(4) = "border:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(4, "colspan=3") = "�Ή��Җ��F"
            ExcelC.pCellStyle(7) = "border:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(7, "colspan=4") = "�Ή������F"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC.pCellStyle(1) = "border:.5pt solid black; height:195.0pt;width:24pt;font-size:13pt;background:silver;layout-flow:vertical"
            ExcelC.pCellVal(1, "rowspan=10") = "�Ή�����"
            ExcelC.pCellStyle(2) = "border-right:.5pt solid black;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9 rowspan=8") = "�@"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9") = "���������F"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC.pCellVal(2, "colspan=9") = "�񍐓����F"
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������


            '�t�b�^���ڂ̏����o���ƁA�t�@�C���N���[�Y
            ExcelC.mClose()

            '//�e�L�X�g�f�[�^�t�@�C���̍폜
            'Kill(gstrPATH & strTaiouTextName)

            If pstrBtnKBN = "2" Then
                '�v���r���[�{�^�����������ꍇ(JPG����Ă΂ꂽ�ꍇ)
                Return ExcelC.pDirName & ExcelC.pFileName & ".xls"
            Else
                '���M�{�^�����������ꍇ(KEFAXJAE00.exe����Ă΂ꂽ�ꍇ)
                Return FileToStrC.mFileToStr(ExcelC.pDirName & ExcelC.pFileName & ".xls")
            End If
            '2014/12/25 T.Ono mod 2014���P�J�� No4 END

        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            '�ڑ��N���[�Y
            cdb.mClose()

        End Try

    End Function
    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    <WebMethod()> Public Function mExcelSpotKill( _
                                            ByVal pstrSessionID As String, _
                                            ByVal pstrTEXT_NAME As String) As String
        Dim strRec As String = "OK"
        Dim strTaiouTextName As String

        gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "\00\"
        '�Ή����̓f�[�^�e�L�X�g
        strTaiouTextName = gstrPGCD & "\" & pstrTEXT_NAME

        '//�e�L�X�g�f�[�^�t�@�C���̍폜
        Kill(gstrPATH & strTaiouTextName)
        Return strRec
    End Function

    '2015/12/09 w.ganeko 2015���P�J�� ��2 end

    '*****************************************************************
    '*�@�T�@�v�F�e�L�X�g�t�@�C���쐬
    '*�@���@�l�F��؂蕶���u>�v�Ńp�����[�^��A��
    '*          2020/11/01 T.Ono mod 2020�Ď����P pstrTEL_MEMO4�`6��ǉ�
    '*****************************************************************
    <WebMethod()> Public Function fncDataOut(
                            ByVal pstrSYONO As String,
                            ByVal pstrFAX_TITLE As String,
                            ByVal pstrACBCD As String,
                            ByVal pstrKURACD As String,
                            ByVal pstrKANSCD As String,
                            ByVal pstrJUSYONM As String,
                            ByVal pstrUSER_CD As String,
                            ByVal pstrJUTEL1 As String,
                            ByVal pstrJUTEL2 As String,
                            ByVal pstrRENTEL As String,
                            ByVal pstrADDR As String,
                            ByVal pstrHATYMD As String,
                            ByVal pstrHATTIME As String,
                            ByVal pstrKENSIN As String,
                            ByVal pstrRYURYO As String,
                            ByVal pstrMETASYU As String,
                            ByVal pstrKMNM1 As String,
                            ByVal pstrKMNM2 As String,
                            ByVal pstrKMNM3 As String,
                            ByVal pstrKMNM4 As String,
                            ByVal pstrKMNM5 As String,
                            ByVal pstrKMNM6 As String,
                            ByVal pstrTAIOKBN As String,
                            ByVal pstrTKTANCD As String,
                            ByVal pstrSYOYMD As String,
                            ByVal pstrSYOTIME As String,
                            ByVal pstrSIJIYMD As String,
                            ByVal pstrSIJITIME As String,
                            ByVal pstrTAITCD As String,
                            ByVal pstrTELRCD As String,
                            ByVal pstrFUK_MEMO As String,
                            ByVal pstrTEL_MEMO1 As String,
                            ByVal pstrTEL_MEMO2 As String,
                            ByVal pstrTEL_MEMO4 As String,
                            ByVal pstrTEL_MEMO5 As String,
                            ByVal pstrTEL_MEMO6 As String,
                            ByVal pstrTKIGCD As String,
                            ByVal pstrTSADCD As String,
                            ByVal pstrFAX_REN As String,
                            ByVal pstrMITOKBN As String
                        ) As String

        Dim strRec As String
        '--- ��2005/05/10 DEL Falcon�� ---
        'Dim strProcId As String = "KEFAXJAW00"
        '--- ��2005/05/10 DEL Falcon�� ---
        Dim strFileNM As String

        strRec = "OK"
        Try

            Dim strTaiouText As New StringBuilder("")
            strTaiouText.Append(pstrSYONO & gstrPoint)
            strTaiouText.Append(pstrFAX_TITLE & gstrPoint)
            strTaiouText.Append(pstrACBCD & gstrPoint)
            strTaiouText.Append(pstrKURACD & gstrPoint)
            strTaiouText.Append(pstrKANSCD & gstrPoint)
            strTaiouText.Append(pstrJUSYONM & gstrPoint)
            strTaiouText.Append(pstrUSER_CD & gstrPoint)
            strTaiouText.Append(pstrJUTEL1 & gstrPoint)
            strTaiouText.Append(pstrJUTEL2 & gstrPoint)
            strTaiouText.Append(pstrRENTEL & gstrPoint)
            strTaiouText.Append(pstrADDR & gstrPoint)
            strTaiouText.Append(pstrHATYMD & gstrPoint)
            strTaiouText.Append(pstrHATTIME & gstrPoint)
            strTaiouText.Append(pstrKENSIN & gstrPoint)
            strTaiouText.Append(pstrRYURYO & gstrPoint)
            strTaiouText.Append(pstrMETASYU & gstrPoint)
            strTaiouText.Append(pstrKMNM1 & gstrPoint)
            strTaiouText.Append(pstrKMNM2 & gstrPoint)
            strTaiouText.Append(pstrKMNM3 & gstrPoint)
            strTaiouText.Append(pstrKMNM4 & gstrPoint)
            strTaiouText.Append(pstrKMNM5 & gstrPoint)
            strTaiouText.Append(pstrKMNM6 & gstrPoint)
            strTaiouText.Append(pstrTAIOKBN & gstrPoint)
            strTaiouText.Append(pstrTKTANCD & gstrPoint)
            strTaiouText.Append(pstrSYOYMD & gstrPoint)
            strTaiouText.Append(pstrSYOTIME & gstrPoint)
            strTaiouText.Append(pstrSIJIYMD & gstrPoint)
            strTaiouText.Append(pstrSIJITIME & gstrPoint)
            strTaiouText.Append(pstrTAITCD & gstrPoint)
            strTaiouText.Append(pstrTELRCD & gstrPoint)
            strTaiouText.Append(pstrFUK_MEMO & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO1 & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO2 & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO4 & gstrPoint)    '2020/11/01 T.Ono add 2020�Ď����P
            strTaiouText.Append(pstrTEL_MEMO5 & gstrPoint)    '2020/11/01 T.Ono add 2020�Ď����P
            strTaiouText.Append(pstrTEL_MEMO6 & gstrPoint)    '2020/11/01 T.Ono add 2020�Ď����P
            strTaiouText.Append(pstrTKIGCD & gstrPoint)
            strTaiouText.Append(pstrTSADCD & gstrPoint)
            strTaiouText.Append(pstrFAX_REN & gstrPoint)
            strTaiouText.Append(pstrMITOKBN)
            '�o��
            strTaiouText.Append(vbCrLf)

            '�t�@�C���̍쐬--------------------------------
            'Dim strSessionID As String = Now.ToString("yyyyMMddhhmiss") ' 2011/05/30 T.Watabe edit
            'Dim strSessionID As String = Now.ToString("yyyyMMddHHmmss") & CInt(Rnd() * 1000000000)  '�Z�b�V�����̍쐬(�������g�p)
            'Dim strSessionID As String = "" & GetRandomPasswordUsingGUID(14)  '�Z�b�V�����̍쐬(�������g�p)
            'Dim strSessionID As String = "" & CInt(Rnd() * 1000000000)   '�Z�b�V�����̍쐬(�������g�p)
            Dim strSessionID As String = "" & GetRandomPasswordUsingGUID(8)  '�Z�b�V�����̍쐬(�������g�p)

            Dim FileToStrC As New CFileStr
            Dim strFileName As String
            With FileToStrC
                '--- ��2005/05/12 DEL Falcon�� ---
                '.pKencd = ""    '�N���C�A���g�R�[�h���
                '--- ��2005/05/12 DEL Falcon�� ---
                '--- ��2005/05/12 MOD Falcon�� ---
                .pKencd = "00"
                '--- ��2005/05/12 MOD Falcon�� ---
                '--- ��2005/05/10 DEL Falcon�� ---
                '.pPgcd = strProcId
                '--- ��2005/05/10 DEL Falcon�� ---
                '--- ��2005/05/10 MOD Falcon�� ---
                .pPgcd = gstrPGCD
                '--- ��2005/05/10 MOD Falcon�� ---
                .pSessionID = strSessionID
                strFileName = .mStrToFile(strTaiouText.ToString)
            End With

            strRec = "OK"
            '--- ��2005/05/12 DEL Falcon�� ---
            'fncMakeDir(ConfigurationSettings.AppSettings("TEXTPATH"))
            '--- ��2005/05/12 DEL Falcon�� ---
            strFileNM = FileToStrC.pFileName

            '---------------------------------------------
        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRec = ex.ToString
        Finally

        End Try

        Return strRec & strFileNM

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
    'HHMISS �� HH:MI
    '****************************************************************
    Private Function fncTimeSet(ByVal strTime As String) As String
        If strTime.Length = 4 Or strTime.Length = 6 Then
            Return strTime.Substring(0, 2) & ":" & strTime.Substring(2, 2)
        Else
            Return ""
        End If
    End Function

    '**********************************************************
    '�t�H���_�̍쐬
    '**********************************************************
    Private Function fncMakeDir(ByVal strPath As String) As String
        '�f�B���N�g���쐬(���ɂ���Ζ���)
        Dim dirInfo As New DirectoryInfo(strPath)
        dirInfo.Create()
        '�쐬�p�X��Ԃ�
        Return strPath
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�v���_�E���}�X�^���������A�R�[�h���疼�̂��擾����
    '******************************************************************************
    Private Function fncGET_PULLNM(ByVal pstrKBN As String, ByVal pstrCD As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        strRes = ""

        '�l���Ȃ��ꍇ�͋��Ԃ�
        If pstrCD.Length = 0 Then
            Return strRes
        End If

        '�c�a�I�[�v��
        cdb.mOpen()
        'SQL�쐬
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("NAME ")
        strSQL.Append("FROM ")
        strSQL.Append("M06_PULLDOWN ")
        strSQL.Append("WHERE :KBN = KBN(+)")
        strSQL.Append(" AND :CD = CD(+)")
        'SQL���Z�b�g
        cdb.pSQL = strSQL.ToString
        '�p�����[�^�Z�b�g
        cdb.pSQLParamStr("KBN") = pstrKBN       '//�敪
        cdb.pSQLParamStr("CD") = pstrCD         '//�R�[�h
        'SQL�����s
        cdb.mExecQuery()
        '�f�[�^�Z�b�g�ɒl���i�[
        ds = cdb.pResult
        If ds.Tables(0).Rows.Count = 0 Then
            '�f�[�^��0����������
            strRes = ""
        Else
            strRes = Convert.ToString(ds.Tables(0).Rows(0).Item("NAME"))
        End If
        '�c�a�N���[�Y
        cdb.mClose()

        Return strRes
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�e�L�X�g�t�@�C���̓ǂݍ���
    '*�@���@�l�F
    '******************************************************************************
    Private Function fncTaiouRecv(ByVal pstrFileName As String, ByRef pstrTaiouText As String) As String

        Dim strReturn As New StringBuilder("")                  '���ʓ��e�̊i�[�ϐ�
        Dim strRec As String

        strRec = "OK"
        Try

            '���ʃt�@�C�������݂��Ȃ��ꍇ�A�G���[
            If Dir(gstrPATH & "\" & pstrFileName, FileAttribute.Normal) = "" Then
                Return "ERROR:�f�[�^�t�@�C����������܂���B" & vbCrLf & vbCrLf & "[" & gstrPATH & "\" & pstrFileName & "]"
            End If
            '---------------------------------------------
            '�t�@�C����0�o�C�g�ŏo�͂���A�������݂�҂��Ă���
            '�t�@�C���������Ă�0�o�C�g�̉\������

            '���ʃt�@�C���̎擾
            Dim c As String
            FileOpen(1, gstrPATH & "\" & pstrFileName, OpenMode.Input, OpenAccess.Read)
            Do
                Try
                    c = InputString(1, 1)
                    strReturn.Append(c)
                Catch
                    Exit Do
                End Try
            Loop
            FileClose()

            '���e�̃`�F�b�N
            If strReturn.ToString.Length = 0 Then
                Return "DATA0"
            End If

            strRec = "OK"
            pstrTaiouText = strReturn.ToString

        Catch ex As Exception
            strRec = "ERROR:" & ex.ToString
            pstrTaiouText = ""

        End Try

        Return strRec
    End Function

    ' 2011/05/30 T.Watabe add
    ' VB.NET
    Public Function GetRandomPasswordUsingGUID(ByVal length As Integer) As String

        'Get the GUID
        Dim guidResult As String = System.Guid.NewGuid().ToString()

        'Remove the hyphens
        guidResult = guidResult.Replace("-", String.Empty)

        'Make sure length is valid
        If length <= 0 OrElse length > guidResult.Length Then
            Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
        End If

        'Return the first length bytes
        Return guidResult.Substring(0, length)
    End Function
    '2012/03/26 ADD START W.GANEKO
    '*****************************************************************
    '*�@�T�@�v�FEXCEL�t�@�C���쐬
    '*�@���@�l�F��؂蕶���u>�v�Ńp�����[�^��A��
    '*          2015/01/19 T.Ono mod 2014���P�J�� [���M��:pstrSEND_NAME]��ǉ�
    '*          2020/11/01 T.Ono mod 2020�Ď����P pstrTEL_MEMO4�`6��ǉ�
    '*****************************************************************
    <WebMethod()> Public Function fncExcelDataOut(
                            ByVal pstrSYONO As String,
                            ByVal pstrFAX_TITLE As String,
                            ByVal pstrACBCD As String,
                            ByVal pstrKURACD As String,
                            ByVal pstrKANSCD As String,
                            ByVal pstrJUSYONM As String,
                            ByVal pstrUSER_CD As String,
                            ByVal pstrJUTEL1 As String,
                            ByVal pstrJUTEL2 As String,
                            ByVal pstrRENTEL As String,
                            ByVal pstrADDR As String,
                            ByVal pstrHATYMD As String,
                            ByVal pstrHATTIME As String,
                            ByVal pstrKENSIN As String,
                            ByVal pstrRYURYO As String,
                            ByVal pstrMETASYU As String,
                            ByVal pstrKMNM1 As String,
                            ByVal pstrKMNM2 As String,
                            ByVal pstrKMNM3 As String,
                            ByVal pstrKMNM4 As String,
                            ByVal pstrKMNM5 As String,
                            ByVal pstrKMNM6 As String,
                            ByVal pstrTAIOKBN As String,
                            ByVal pstrTKTANCD As String,
                            ByVal pstrSYOYMD As String,
                            ByVal pstrSYOTIME As String,
                            ByVal pstrSIJIYMD As String,
                            ByVal pstrSIJITIME As String,
                            ByVal pstrTAITCD As String,
                            ByVal pstrTELRCD As String,
                            ByVal pstrFUK_MEMO As String,
                            ByVal pstrTEL_MEMO1 As String,
                            ByVal pstrTEL_MEMO2 As String,
                            ByVal pstrTEL_MEMO4 As String,
                            ByVal pstrTEL_MEMO5 As String,
                            ByVal pstrTEL_MEMO6 As String,
                            ByVal pstrTKIGCD As String,
                            ByVal pstrTSADCD As String,
                            ByVal pstrFAX_REN As String,
                            ByVal pstrMITOKBN As String,
                            ByVal pstrSENDFLG As String,
                            ByVal pstrMAIL As String,
                            ByVal pstrMAILPASS As String,
                            ByVal pstrSEND_NAME As String
                        ) As String

        Dim strRec As String
        Dim strFileNM As String
        Dim strZipNM As String
        Dim strPotPath As String
        Dim strExcelNM As String

        strRec = "OK"
        Try

            Dim strTaiouText As New StringBuilder("")
            strTaiouText.Append(pstrSYONO & gstrPoint)
            strTaiouText.Append(pstrFAX_TITLE & gstrPoint)
            strTaiouText.Append(pstrACBCD & gstrPoint)
            strTaiouText.Append(pstrKURACD & gstrPoint)
            strTaiouText.Append(pstrKANSCD & gstrPoint)
            strTaiouText.Append(pstrJUSYONM & gstrPoint)
            strTaiouText.Append(pstrUSER_CD & gstrPoint)
            strTaiouText.Append(pstrJUTEL1 & gstrPoint)
            strTaiouText.Append(pstrJUTEL2 & gstrPoint)
            strTaiouText.Append(pstrRENTEL & gstrPoint)
            strTaiouText.Append(pstrADDR & gstrPoint)
            strTaiouText.Append(pstrHATYMD & gstrPoint)
            strTaiouText.Append(pstrHATTIME & gstrPoint)
            strTaiouText.Append(pstrKENSIN & gstrPoint)
            strTaiouText.Append(pstrRYURYO & gstrPoint)
            strTaiouText.Append(pstrMETASYU & gstrPoint)
            strTaiouText.Append(pstrKMNM1 & gstrPoint)
            strTaiouText.Append(pstrKMNM2 & gstrPoint)
            strTaiouText.Append(pstrKMNM3 & gstrPoint)
            strTaiouText.Append(pstrKMNM4 & gstrPoint)
            strTaiouText.Append(pstrKMNM5 & gstrPoint)
            strTaiouText.Append(pstrKMNM6 & gstrPoint)
            strTaiouText.Append(pstrTAIOKBN & gstrPoint)
            strTaiouText.Append(pstrTKTANCD & gstrPoint)
            strTaiouText.Append(pstrSYOYMD & gstrPoint)
            strTaiouText.Append(pstrSYOTIME & gstrPoint)
            strTaiouText.Append(pstrSIJIYMD & gstrPoint)
            strTaiouText.Append(pstrSIJITIME & gstrPoint)
            strTaiouText.Append(pstrTAITCD & gstrPoint)
            strTaiouText.Append(pstrTELRCD & gstrPoint)
            strTaiouText.Append(pstrFUK_MEMO & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO1 & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO2 & gstrPoint)
            strTaiouText.Append(pstrTEL_MEMO4 & gstrPoint)    '2020/11/01 T.Ono add 2020�Ď����P
            strTaiouText.Append(pstrTEL_MEMO5 & gstrPoint)    '2020/11/01 T.Ono add 2020�Ď����P
            strTaiouText.Append(pstrTEL_MEMO6 & gstrPoint)    '2020/11/01 T.Ono add 2020�Ď����P
            strTaiouText.Append(pstrTKIGCD & gstrPoint)
            strTaiouText.Append(pstrTSADCD & gstrPoint)
            strTaiouText.Append(pstrFAX_REN & gstrPoint)
            strTaiouText.Append(pstrMITOKBN)
            '�o��
            strTaiouText.Append(vbCrLf)
            Dim strToMail As String()
            Dim strToMailPass As String()
            Dim FileToStrC As New CFileStr
            Dim strMess As String
            Dim strKANSI_NAME As String = ""
            Dim strBIKOU As String = ""
            Dim strTEL As String = ""
            Dim strExcelName As String = ""
            Dim strKANSI As String()
            '2015/12/09 w.ganeko 2015���P�J�� ��2
            'strToMail = pstrMAIL.Split("|"c)
            'strToMailPass = pstrMAILPASS.Split("|"c)
            strToMail = pstrMAIL.Split(","c)
            strToMailPass = pstrMAILPASS.Split(","c)
            strKANSI = fncKansiAdress(pstrKANSCD).Split(";"c)
            If strKANSI(0) = "OK" Then
                strKANSI_NAME = strKANSI(1)
                strBIKOU = strKANSI(2)
                strTEL = strKANSI(3)
            End If

            strMess = fncSendMessage(pstrKANSCD, strKANSI_NAME, strBIKOU, strTEL)
            strPotPath = ConfigurationSettings.AppSettings("TEXTPATH") & "00\" & gstrPGCD & "\"

            Dim i As Integer
            For i = 0 To strToMail.Length - 1
                If strToMail(i) <> "" Then
                    '�t�@�C���̍쐬--------------------------------
                    Dim strSessionID As String = "" & GetRandomPasswordUsingGUID(8)  '�Z�b�V�����̍쐬(�������g�p)

                    Dim strFileName As String
                    With FileToStrC
                        .pKencd = "00"
                        .pPgcd = gstrPGCD
                        .pSessionID = strSessionID
                        strFileName = .mStrToFile(strTaiouText.ToString)
                    End With
                    strRec = "OK"
                    strFileNM = FileToStrC.pFileName

                    'EXCEL�t�@�C���쐬
                    strExcelName = "�Ď��Ή��˗���" & Now.ToString("yyyyMMdd") & "_" & strSessionID & ".xls"
                    '2015/01/19 T.Ono mod 2014���P�J�� [���M��:pstrSEND_NAME]��ǉ�
                    'strExcelNM = mZipExcel(strSessionID, strFileNM, strExcelName, "", "", "", "", "")
                    strExcelNM = mZipExcel(strSessionID, strFileNM, strExcelName, pstrSEND_NAME, "", "", "", "")
                    strZipNM = "�Ď��Ή��˗���" & Now.ToString("yyyyMMdd") & "_" & strSessionID & ".zip"

                    'EXCEL�t�@�C����zip�t�@�C���쐬
                    fncMakeZipWithPass(strExcelNM, strPotPath & strZipNM, strToMailPass(i))
                    '���[�����Mzip�t�@�C���Y�t
                    mMailSend(strPotPath & strZipNM, strToMail(i), True, strBIKOU, strMess)
                End If
            Next
            '---------------------------------------------
        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRec = "ERROR:" & ex.ToString
        Finally

        End Try

        Return strRec & strFileNM

    End Function
    Private Function mZipExcel( _
                                            ByVal pstrSessionID As String, _
                                            ByVal pstrTEXT_NAME As String, _
                                            ByVal pstrFILE_NAME As String, _
                                            ByVal pstrSEND_NAME As String, _
                                            ByVal pstrSEND_POST As String, _
                                            ByVal pstrSEND_ADDS As String, _
                                            ByVal pstrSEND_FAX As String, _
                                            ByVal pstrSEND_TEL As String _
                                            ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim ExcelC2 As New CExcel
        Dim UtilFucC As New CUtilFuc

        '���s������s��
        'Dim intGYOSU As Integer = 47 ' 2008/02/29 T.Watabe edit
        Dim intGYOSU As Integer = 53
        '���t�ϊ��N���X
        Dim DateFncC As New CDateFnc
        '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim FileToStrC As New CFileStr

        Dim arrFaxData() As String
        Dim strTaiouTextName As String
        Dim strFaxData As String
        Dim strTaiouText As String

        ReDim gstrRecText(0)

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        Dim strRec As String = "OK"
        Try
            gstrPATH = ConfigurationSettings.AppSettings("TEXTPATH") & "\00\"
            '�Ή����̓f�[�^�e�L�X�g
            strTaiouTextName = gstrPGCD & "\" & pstrTEXT_NAME

            '//------------------------------------------------------------
            '�Ή����̓f�[�^�t�@�C����ǂݍ���
            strRec = fncTaiouRecv(strTaiouTextName, strTaiouText)
            If strRec <> "OK" Then
                Return strRec
            End If

            '//">"��؂�f�[�^���擾�@�z��Ɋi�[
            If strTaiouText.Length <> 0 Then
                arrFaxData = strTaiouText.Split(Convert.ToChar(gstrPoint))
            End If

            '//�f�[�^�Z�b�g ----------------------------------
            Dim strSYONO As String = arrFaxData(0)                          '�����ԍ�
            Dim strFAXTITLE As String = arrFaxData(1)                       '�e�`�w�^�C�g��
            Dim strACBCD As String = arrFaxData(2)                          '�i�`�x���R�[�h
            Dim strKURACD As String = arrFaxData(3)                         '�N���C�A���g�R�[�h
            Dim strKANSCD As String = arrFaxData(4)                         '�Ď��Z���^�[�R�[�h
            Dim strJUSYONM As String = arrFaxData(5)                        '���q�l����
            Dim strUSER_CD As String = arrFaxData(6)                        '���q�l�R�[�h
            Dim strJUTEL1 As String = arrFaxData(7)                         '����d�b�s�O
            Dim strJUTEL2 As String = arrFaxData(8)                         '����d�b�s��
            Dim strRENTEL As String = arrFaxData(9)                         '�A���d�b�ԍ�
            Dim strADDR As String = arrFaxData(10)                          '�Z��
            Dim strHATYMD As String = arrFaxData(11)                        '������
            Dim strHATTIME As String = arrFaxData(12)                       '��������
            Dim strKENSIN As String = arrFaxData(13)                        '���[�^�l
            Dim strRYURYO As String = arrFaxData(14)                        '���ʋ敪
            Dim strMETASYU As String = arrFaxData(15)                       '���[�^���
            Dim strKMNM1 As String = arrFaxData(16)                         '�x�񃁃b�Z�[�W�P
            Dim strKMNM2 As String = arrFaxData(17)                         '�x�񃁃b�Z�[�W�Q
            Dim strKMNM3 As String = arrFaxData(18)                         '�x�񃁃b�Z�[�W�R
            Dim strKMNM4 As String = arrFaxData(19)                         '�x�񃁃b�Z�[�W�S
            Dim strKMNM5 As String = arrFaxData(20)                         '�x�񃁃b�Z�[�W�T
            Dim strKMNM6 As String = arrFaxData(21)                         '�x�񃁃b�Z�[�W�U
            Dim strTAIOKBN As String = fncGET_PULLNM("09", arrFaxData(22))  '�Ή��敪
            Dim strTKTANCD As String = arrFaxData(23)                       '�Ď��Z���^�[�S����
            Dim strSYOYMD As String = arrFaxData(24)                        '�Ή�������
            Dim strSYOTIME As String = arrFaxData(25)                       '�Ή���������
            Dim strSIJIYMD As String = arrFaxData(26)                       '�o���w����
            Dim strSIJITIME As String = arrFaxData(27)                      '�o���w������
            Dim strTAITCD As String = fncGET_PULLNM("12", arrFaxData(28))   '�A������
            Dim strTELRCD As String = fncGET_PULLNM("15", arrFaxData(29))   '�d�b�A�����e
            Dim strFUK_MEMO As String = arrFaxData(30)                      '���A���상��
            Dim strTEL_MEMO1 As String = arrFaxData(31)                     '�d�b�����P
            Dim strTEL_MEMO2 As String = arrFaxData(32)                     '�d�b�����Q
            '2020/11/01 T.Ono mod 2020�Ď����P Start
            'Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(33))   '�������
            'Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(34))   '�쓮����
            'Dim strFAX_REN As String = arrFaxData(35)                       '�˗����e
            'Dim strMITOKBN As String = arrFaxData(36)                       '���o�^�e�k�f
            Dim strTEL_MEMO4 As String = arrFaxData(33)                     '�d�b�����S
            Dim strTEL_MEMO5 As String = arrFaxData(34)                     '�d�b�����T
            Dim strTEL_MEMO6 As String = arrFaxData(35)                     '�d�b�����U 
            Dim strTKIGCD As String = fncGET_PULLNM("16", arrFaxData(36))   '�������
            Dim strTSADCD As String = fncGET_PULLNM("17", arrFaxData(37))   '�쓮����
            Dim strFAX_REN As String = arrFaxData(38)                       '�˗����e
            Dim strMITOKBN As String = arrFaxData(39)                       '���o�^�e�k�f
            '2020/11/01 T.Ono mod 2020�Ď����P End
            '//------------------------------------------------
            Dim strMAP_CD As String                                         '�n�}�ԍ�
            Dim strUSER_FLG As String                                       '���q�l���
            '���R�[�h���Z�b�g
            'If strKURACD.Length <> 0 Then
            'ExcelC.pKencd = strKURACD.Substring(1, 2)
            'Else
            ExcelC2.pKencd = "00"
            'End If
            '�Z�b�V����ID
            ExcelC2.pSessionID = pstrSessionID

            '���[ID
            ExcelC2.pRepoID = gstrPGCD

            '���[�c
            ExcelC2.pLandScape = False

            '�t�@�C���I�[�v��
            ExcelC2.mOpen()

            '�^�C�g��
            ExcelC2.pTitle = strFAXTITLE

            '�쐬��
            ExcelC2.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))

            '�k���g�嗦
            ExcelC2.pScale = 100

            '�]��
            ExcelC2.pMarginTop = 1.8D
            ExcelC2.pMarginBottom = 0D
            ExcelC2.pMarginLeft = 1.2D
            ExcelC2.pMarginRight = 1.5D
            ExcelC2.pMarginHeader = 1.3D
            ExcelC2.pMarginFooter = 0D

            '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
            ExcelC2.mHeader(intGYOSU, intGYOSU, 1)

            '�e��̕����s�N�Z���ŃZ�b�g�B�g���������B
            '1�s��
            ExcelC2.pCellStyle(1) = "width:32px;border-style:none"
            ExcelC2.pCellStyle(2) = "width:103px;border-style:none"
            ExcelC2.pCellStyle(3) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(4) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(5) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(6) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(7) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(8) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(9) = "width:72px;border-style:none"
            ExcelC2.pCellStyle(10) = "width:80px;border-style:none"
            ExcelC2.pCellVal(1) = ""
            ExcelC2.pCellVal(2) = ""
            ExcelC2.pCellVal(3) = ""
            ExcelC2.pCellVal(4) = ""
            ExcelC2.pCellVal(5) = ""
            ExcelC2.pCellVal(6) = ""
            ExcelC2.pCellVal(7) = ""
            ExcelC2.pCellVal(8) = ""
            ExcelC2.pCellVal(9) = ""
            ExcelC2.pCellVal(10) = ""
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '--------------------------------------------------
            '�f�[�^�̎擾
            '--------------------------------------------------
            strSQL.Append("SELECT ")
            strSQL.Append("JA.JA_NAME, ")
            strSQL.Append("JA.JAS_NAME, ")
            strSQL.Append("CL.KEN_NAME, ")
            strSQL.Append("HA.NAME AS HAISO_NAME, ")
            strSQL.Append("KA.KANSI_NAME, ")
            strSQL.Append("KA.TEL, ")
            strSQL.Append("KA.KINKYU_TEL, ") ' 2010/03/24 T.Watabe add �Ď�����FAX�ԍ�
            strSQL.Append("TA.TANNM ")
            strSQL.Append("FROM HN2MAS JA, ")
            strSQL.Append("     CLIMAS CL, ")
            strSQL.Append("     HAIMAS HA, ")
            strSQL.Append("     KANSIMAS KA, ")
            strSQL.Append("     M05_TANTO TA ")
            strSQL.Append("WHERE CL.CLI_CD = :KURACD ")
            strSQL.Append("  AND CL.CLI_CD = JA.CLI_CD(+) ")
            strSQL.Append("  AND :ACBCD = JA.HAN_CD(+) ")
            strSQL.Append("  AND SUBSTR(JA.CLI_CD,2,2) = HA.KEN_CD(+) ")
            strSQL.Append("  AND JA.HAISO_CD = HA.HAISO_CD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = KA.KANSI_CD(+) ")
            strSQL.Append("  AND '1' = TA.KBN(+) ")
            strSQL.Append("  AND 'ZZZZ' = TA.KURACD(+) ")
            strSQL.Append("  AND CL.KANSI_CODE = TA.CODE(+) ")
            strSQL.Append("  AND :TKTANCD = TA.TANCD(+) ")


            '//SQL�Z�b�g
            cdb.pSQL = strSQL.ToString
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("KURACD") = strKURACD
            cdb.pSQLParamStr("ACBCD") = strACBCD
            cdb.pSQLParamStr("TKTANCD") = strTKTANCD

            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
            Else
                '//�f�[�^���i�[
                dr = ds.Tables(0).Rows(0)
            End If

            '2006/06/09 NEC ADD START
            Dim dsShamas As New DataSet
            Dim drShamas As DataRow
            Dim strSQL_Shamas As New StringBuilder("")

            strSQL_Shamas.Append("SELECT ")
            strSQL_Shamas.Append("MAP_CD, ")        '�n�}�ԍ�
            strSQL_Shamas.Append("USER_FLG ")      '���q�l���
            strSQL_Shamas.Append("FROM SHAMAS ")
            strSQL_Shamas.Append("WHERE CLI_CD=:CLI_CD AND ")
            strSQL_Shamas.Append(" HAN_CD=:HAN_CD AND ")
            strSQL_Shamas.Append(" USER_CD=:USER_CD ")

            '//SQL�Z�b�g
            cdb.pSQL = strSQL_Shamas.ToString
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("CLI_CD") = strKURACD
            cdb.pSQLParamStr("HAN_CD") = strACBCD
            cdb.pSQLParamStr("USER_CD") = strUSER_CD

            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            dsShamas = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strSQL_Shamas.Remove(0, strSQL_Shamas.Length)
                strSQL_Shamas.Append("SELECT ")
                strSQL_Shamas.Append("'' AS MAP_CD, ")        '�n�}�ԍ�
                strSQL_Shamas.Append("'' AS USER_FLG ")      '���q�l���
                strSQL_Shamas.Append("FROM DUAL ")

                '//SQL�Z�b�g
                cdb.pSQL = strSQL_Shamas.ToString

                '//SQL���s
                cdb.mExecQuery()
                '//�f�[�^�Z�b�g�Ɋi�[
                dsShamas = cdb.pResult
                '//�f�[�^���i�[
                drShamas = dsShamas.Tables(0).Rows(0)
            Else
                '//�f�[�^���i�[
                drShamas = dsShamas.Tables(0).Rows(0)
            End If

            '--------------------------------------------------
            '�f�[�^�̏o��
            '--------------------------------------------------
            Dim strTemp As String = ""

            '2�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "���M��FAX�ԍ��F" & pstrSEND_TEL
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '3�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                If Convert.ToString(dr.Item("JAS_NAME")) = "" Then
                    strTemp = ""
                Else
                    strTemp = Convert.ToString(dr.Item("JAS_NAME")) & "�@�䒆"
                End If
            End If
            ExcelC2.pCellVal(1, "colspan=10") = "�i�`�x�����@ �F" & strTemp
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '4�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=4") = ""
            ExcelC2.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TEL"))
            End If
            ExcelC2.pCellVal(3, "colspan=4 align=right") = "���M��TEL�F" & strTemp
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '4�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(3) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=4") = ""
            ExcelC2.pCellVal(2, "colspan=2") = ""
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KINKYU_TEL"))
            End If
            ExcelC2.pCellVal(3, "colspan=4 align=right") = "���M��FAX�F" & strTemp
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '5�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KEN_NAME"))
            End If
            ExcelC2.pCellVal(1, "colspan=5") = "���@�@�@���@ �F" & strTemp
            ExcelC2.pCellVal(2, "colspan=5 align=right") = "���M�ҁF" & pstrSEND_NAME
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '6�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("HAISO_NAME"))
            End If
            ExcelC2.pCellVal(1, "colspan=5") = "�����������@ �F" & strTemp
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("KANSI_NAME"))
            End If
            ExcelC2.pCellVal(2, "colspan=5 align=right") = strTemp
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '7�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            'ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '7�s��
            ExcelC2.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = ""
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '9�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "<<��M���>>"
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '10�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC2.pCellVal(1, "colspan=7") = "���q�l�����F" & strJUSYONM
            ExcelC2.pCellVal(1, "colspan=7") = "���q�l���@�F" & strJUSYONM
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END

            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("MAP_CD"))
            End If
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC2.pCellVal(2, "colspan=3") = "�n�}�m���@�F" & strTemp
            ExcelC2.pCellVal(2, "colspan=3") = "�n�}�ԍ��@�F" & strTemp
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '11�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=7") = "���q�l���ށF" & strACBCD & strUSER_CD
            If dsShamas.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(drShamas.Item("USER_FLG"))
            End If

            Select Case strTemp
                Case "0"
                    '0:���J��
                    ExcelC2.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "���J��"
                Case "1"
                    '1:�^�p��
                    ExcelC2.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "�^�p��"
                Case "2"
                    '2:�x�~��
                    ExcelC2.pCellVal(2, "colspan=3") = "���q�l��ԁF" & "�x�~��"
                Case Else
                    '���̑�
                    ExcelC2.pCellVal(2, "colspan=3") = "���q�l��ԁF"
            End Select
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '12�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'If strJUTEL1 = "" Or strJUTEL2 = "" Then
            '    ExcelC2.pCellVal(1, "colspan=5") = "�d�b�ԍ��@�F" & strJUTEL1 & strJUTEL2
            'Else
            '    ExcelC2.pCellVal(1, "colspan=5") = "�d�b�ԍ��@�F" & strJUTEL1 & "-" & strJUTEL2
            'End If
            'ExcelC2.pCellVal(2, "colspan=5") = "�A���d�b�ԍ��F" & strRENTEL
            If strJUTEL1 = "" Or strJUTEL2 = "" Then
                ExcelC2.pCellVal(1, "colspan=5") = "�����ԍ��@�F" & strJUTEL1 & strJUTEL2
            Else
                ExcelC2.pCellVal(1, "colspan=5") = "�����ԍ��@�F" & strJUTEL1 & "-" & strJUTEL2
            End If
            ExcelC2.pCellVal(2, "colspan=5") = "�A����F" & strRENTEL
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '13�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "�Z���@�@�@�F" & strADDR
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '14�s��
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '15�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "�y�x����e�z"
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '16�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC2.pCellVal(1, "colspan=4") = "�������@�@�F" & strHATYMD & " " & strHATTIME
            ExcelC2.pCellVal(1, "colspan=4") = "��M�����@�F" & strHATYMD & " " & strHATTIME
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC2.pCellVal(2, "colspan=6") = "���[�^�l�@�F" & strKENSIN
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '17�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=4") = "���ʋ敪�@�F" & strRYURYO
            ExcelC2.pCellVal(2, "colspan=6") = "���[�^��ʁF" & strMETASYU
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '18�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=5") = "1�F" & strKMNM1
            ExcelC2.pCellVal(2, "colspan=5") = "4�F" & strKMNM4
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '19�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=5") = "2�F" & strKMNM2
            ExcelC2.pCellVal(2, "colspan=5") = "5�F" & strKMNM5
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '20�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=5") = "3�F" & strKMNM3
            ExcelC2.pCellVal(2, "colspan=5") = "6�F" & strKMNM6
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '21�s��
            '2020/11/01 T.Ono mod 2020�Ď����P
            'ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '22�s��
            '2020/11/01 T.Ono mod 2020�Ď����P
            'ExcelC2.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            'ExcelC2.pCellVal(1, "colspan=10") = ""
            'ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '21�s��
            'ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"    2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC2.pCellStyle(1) = "border-bottom-style:none;border-left-style:none;border-right-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "<<�Ď��Z���^�[�Ή����e>>"
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '22�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=5") = "�Ή��敪�@�@�F" & strTAIOKBN
            ExcelC2.pCellVal(2, "colspan=5") = "�����ԍ�(�Ɖ�p)�F" & strSYONO
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '23�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(2) = "border-style:none;font-size:13pt"
            If ds.Tables(0).Rows.Count = 0 Then
                strTemp = ""
            Else
                strTemp = Convert.ToString(dr.Item("TANNM"))
            End If
            ExcelC2.pCellVal(1, "colspan=5") = "�Ď������S���F" & strTemp
            'ExcelC2.pCellVal(2, "colspan=5") = "�Ή����F" & strSYOYMD & " " & strSYOTIME 2008/10/14 T.Watabe edit
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC2.pCellVal(2, "colspan=5") = "���������@�@�@�@�F" & strSYOYMD & " " & strSYOTIME
            ExcelC2.pCellVal(2, "colspan=5") = "�Ή����������@�@�F" & strSYOYMD & " " & strSYOTIME
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '24�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC2.pCellVal(1, "colspan=10") = "�˗����@�@�@�F" & strSIJIYMD & " " & strSIJITIME
            ExcelC2.pCellVal(1, "colspan=10") = "�˗������@�@�F" & strSIJIYMD & " " & strSIJITIME
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '25�s��
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '26�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "�A������@�@�F" & strTAITCD
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '27�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "�d�b�A�����e�F" & strTELRCD
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '28�s��
            ExcelC2.pCellStyle(1) = "border-style:none"
            'ExcelC2.pCellStyle(2) = "border-style:none;height:72px;vertical-align:top" '�����w�肷��ƁA���s���ύ��ɂȂ炸�P�s�ɂȂ��Ă��܂��B
            ExcelC2.pCellStyle(2) = "border-style:none;vertical-align:top"
            ExcelC2.pCellVal(1) = ""
            'ExcelC2.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO  2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC2.pCellVal(2, "colspan=9") = strTEL_MEMO1 & strTEL_MEMO2 & strFUK_MEMO & strTEL_MEMO4 & strTEL_MEMO5 & strTEL_MEMO6
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '29�s��
            ExcelC2.pCellStyle(1) = "border-style:none;height:6pt"    '2020/11/01 T.Ono add 2020�Ď����P
            ExcelC2.pCellVal(1, "colspan=10") = ""    '2020/11/01 T.Ono add 2020�Ď����P
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '30�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC2.pCellVal(1, "colspan=10") = "�������@�F" & strTKIGCD
            ExcelC2.pCellVal(1, "colspan=10") = "�������@�@�F" & strTKIGCD
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '31�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellVal(1, "colspan=10") = "�쓮�����@�@�F" & strTSADCD
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '37�s��
            '2020/11/01 T.Ono del 2020�Ď����P
            ''2015/05/14 H.Mori mod �������̂ЂƂ�̍s���k�� START
            ''ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            'ExcelC2.pCellStyle(1) = "border-style:none;height:9pt"
            'ExcelC2.pCellVal(1) = ""
            'ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            ''2015/05/14 H.Mori mod �������̂ЂƂ�̍s���k�� END

            '32�s��
            '2015/04/30 H.Mori mod ���������g�� 
            'ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            ExcelC2.pCellStyle(1) = "border-style:none;height:47pt;vertical-align:top;font-size:13pt"
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 START
            'ExcelC2.pCellVal(1, "colspan=10") = "�˗����e�@�@�F" & strFAX_REN
            ExcelC2.pCellVal(1, "colspan=10") = "�������@�@�@�F" & strFAX_REN
            '2015/02/27 H.Hosoda mod 2014���P�J�� No.5 END
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '33�s��
            ExcelC2.pCellStyle(1) = "border-style:none;font-size:13pt"
            '2021/02/12 T.Ono mod ���̕����͕\�����Ȃ� Start
            ''If strMITOKBN = "1" Then '2020/11/01 T.Ono mod
            'If strMITOKBN.Substring(0, 1) = "1" Then
            '    ExcelC2.pCellVal(1, "colspan=10") = "�u���q�l�}�X�^�[�@�����A�Z���A�d�b�ԍ������m�F�̏�A���A�����������B�v"
            'Else
            '    ExcelC2.pCellVal(1, "colspan=10") = ""
            'End If
            ExcelC.pCellVal(1, "colspan=10") = ""
            '2021/02/12 T.Ono mod ���̕����͕\�����Ȃ� Start
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            '34�s�ځ`44�s��
            ExcelC2.pCellStyle(1) = "border:.5pt solid black; height:23.25pt; font-size:12pt"
            ExcelC2.pCellVal(1, "colspan=3") = "���Ə����F"
            ExcelC2.pCellStyle(4) = "border:.5pt solid black;font-size:12pt"
            ExcelC2.pCellVal(4, "colspan=3") = "�Ή��Җ��F"
            ExcelC2.pCellStyle(7) = "border:.5pt solid black;font-size:12pt"
            ExcelC2.pCellVal(7, "colspan=4") = "�Ή������F"
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC2.pCellStyle(1) = "border:.5pt solid black; height:195.0pt;width:24pt;font-size:13pt;background:silver;layout-flow:vertical"
            '2015/04/30 H.Mori mod �Ή����ʂ���s���폜 
            'ExcelC.pCellVal(1, "rowspan=11") = "�Ή�����"
            ExcelC2.pCellVal(1, "rowspan=10") = "�Ή�����"
            ExcelC2.pCellStyle(2) = "border-right:.5pt solid black;font-size:12pt"
            '2015/04/30 H.Mori mod �Ή����ʂ���s���폜 
            'ExcelC2.pCellVal(2, "colspan=9 rowspan=9") = "�@"
            ExcelC2.pCellVal(2, "colspan=9 rowspan=8") = "�@"
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������
            '2015/04/30 H.Mori del �Ή����ʂ���s���폜 
            'ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC2.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC2.pCellVal(2, "colspan=9") = "���������F"
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������

            ExcelC2.pCellStyle(2) = "border-right:.5pt solid black; height:21.0pt;font-size:12pt"
            ExcelC2.pCellVal(2, "colspan=9") = "�񍐓����F"
            ExcelC2.mWriteLine("")   '�s���t�@�C���ɏ�������


            '�t�b�^���ڂ̏����o���ƁA�t�@�C���N���[�Y
            ExcelC2.mClose()

            '//�e�L�X�g�f�[�^�t�@�C���̍폜
            Kill(gstrPATH & strTaiouTextName)

            '�쐬�����t�@�C����Base64�G���R�[�h���Ė߂�
            'Return FileToStrC.mFileToStr(ExcelC2.pDirName & ExcelC2.pFileName & ".xls")
            System.IO.File.Move(ExcelC2.pDirName & ExcelC2.pFileName & ".xls", ExcelC2.pDirName & pstrFILE_NAME)
            Return ExcelC2.pDirName & pstrFILE_NAME

        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
            ExcelC2 = Nothing
        End Try

    End Function
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
        Kill(sXlsFilePath)

    End Sub
    '**************************************************************************************************
    ' ���[�����M����
    '  �p�����[�^�FpstrDataFile�@�@���M����t�@�C���p�X
    '�@�@�@�@�@�@�FpstrMailAddress ���M�惁�[���A�h���X
    '�@�@�@�@�@�@�FpbolFileCheck   �t�@�C���`�F�b�N�t���O
    '**************************************************************************************************
    Private Sub mMailSend( _
                        ByVal pstrDataFile As String, _
                        ByVal pstrMailAddress As String, _
                        ByVal pbolFileCheck As Boolean, _
                        ByVal pstrSEND_MAILADDRESS As String, _
                        ByVal pstrSEND_BODY As String _
                        )
        Dim strResult As String = ""

        Try
            Dim mm As New System.Web.Mail.MailMessage
            Dim attachment As System.Web.Mail.MailAttachment
            '2018/10/16 del BCC�������2�d���M����Ă��܂����ߊO��
            'Dim strSEND_BCC As String = pstrSEND_MAILADDRESS '�Ď��Z���^�[���[���A�h���X��BCC�ő��M
            Dim strSEND_BCC As String = "" '�Ď��Z���^�[���[���A�h���X��BCC�ő��M
            Dim strSEND_SUBJECT As String = "�Ή��˗����i���t�j"
            Dim strSEND_SMTP As String = ConfigurationSettings.AppSettings("MAIL_SMTP")

            '=== SMTP�F�� ===
            mm.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1 'smtpauthenticate = 1:SMTP�F��
            mm.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = "jalp" ' �W���Ď��Z���^�[�̃��[�UID
            mm.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "jalp"

            '=== �`�F�b�N ===
            If strResult.Length > 0 Then Exit Sub
            If pbolFileCheck Then '2010/07/02 T.Watabe add
                If System.IO.File.Exists(pstrDataFile) = False Then
                    strResult = "ERROR:�Ώۃt�@�C�������݂��܂���B[" & pstrDataFile & "]"
                    Debug.WriteLine("mMailSend �`�F�b�N [" & pstrDataFile & " �͑��݂��܂���]")
                End If
                If strResult.Length > 0 Then Exit Sub
            End If

            '=== ���[�����M���� === 
            '//���M��
            mm.From = pstrSEND_MAILADDRESS
            '//���M��
            mm.To = pstrMailAddress
            '//�m�F�p�Ƃ���BCC�ő��M����
            If strSEND_BCC <> Nothing Then
                If strSEND_BCC.Length > 0 Then
                    mm.Bcc = strSEND_BCC
                End If
            End If
            '//�薼
            mm.Subject = strSEND_SUBJECT
            '//�{��
            mm.Body = pstrSEND_BODY
            '//JIS�R�[�h�ɕϊ�����
            mm.BodyEncoding = System.Text.Encoding.GetEncoding(50220)
            If pstrDataFile.Length > 0 Then ' 2010/01/19 T.Watabe add �t�@�C���`�F�b�N��ǉ�
                '//�Y�t�t�@�C���̎w��
                attachment = New System.Web.Mail.MailAttachment(pstrDataFile)
                mm.Attachments.Add(attachment)
            End If
            '//SMTP�T�[�o�[���w�肷��
            System.Web.Mail.SmtpMail.SmtpServer = strSEND_SMTP
            '//���M����
            System.Web.Mail.SmtpMail.Send(mm)
            strResult = "OK"
        Catch ex As Exception

            strResult = "ERROR:" & ex.ToString
        End Try
    End Sub
    '**************************************************************************************************
    '���[���{���쐬
    '**************************************************************************************************
    Private Function fncSendMessage( _
                        ByVal pstrKANSI_CD As String, _
                        ByVal pstrKANSI_NAME As String, _
                        ByVal pstrBIKOU As String, _
                        ByVal pstrTEL As String _
                        ) As String
        Dim strResult As String()

        Dim strSEND As New StringBuilder("")
        strSEND.Append("(��)JA-LP�K�X���Z���^�[�@�ł��B" & vbCrLf)
        strSEND.Append("������ς����b�ɂȂ��Ă���܂��B" & vbCrLf)
        strSEND.Append("" & vbCrLf)
        strSEND.Append("�Ή��˗�����Y�t�t�@�C���ɂĂ��񍐂����Ă��������܂��̂�" & vbCrLf)
        strSEND.Append("�������̂قǁA��낵�����肢�\���グ�܂��B" & vbCrLf)
        strSEND.Append("" & vbCrLf)
        strSEND.Append("---------------------------------------------------------------" & vbCrLf)
        strSEND.Append("(��)JA-LP�K�X���Z���^�[" & vbCrLf)
        strSEND.Append("" & pstrKANSI_NAME & vbCrLf)             '���Ď��Z���^�[��
        strSEND.Append("" & vbCrLf)
        strSEND.Append("Mail:" & pstrBIKOU & vbCrLf)             '���Ď��Z���^�[���[���A�h���X
        strSEND.Append("TEL:" & pstrTEL & vbCrLf)                '���Ď��Z���^�[�d�b�ԍ�

        Return strSEND.ToString
    End Function
    '**************************************************************************************************
    '�d�b�ԍ��擾
    '**************************************************************************************************
    Private Function fncKansiAdress(ByVal pstrKANSI_CD As String) As String
        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strResult As String
        Dim strKANSI_NAME As String
        Dim strBIKOU As String
        Dim strTEL As String


        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strResult = "ERROR;" & ex.ToString
        Finally

        End Try

        Try
            strSQL.Append("SELECT ")
            strSQL.Append("KA.KANSI_NAME, ")
            strSQL.Append("KA.TEL, ")
            strSQL.Append("KA.BIKOU ")
            strSQL.Append("FROM KANSIMAS KA ")
            strSQL.Append("WHERE KA.KANSI_CD = :KANSI_CD ")


            '//SQL�Z�b�g
            cdb.pSQL = strSQL.ToString
            '//�p�����[�^�Z�b�g
            cdb.pSQLParamStr("KANSI_CD") = pstrKANSI_CD

            '//SQL���s
            cdb.mExecQuery()
            '//�f�[�^�Z�b�g�Ɋi�[
            ds = cdb.pResult
            '//�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                strKANSI_NAME = ""
                strBIKOU = ""
                strTEL = ""
            Else
                '//�f�[�^���i�[
                dr = ds.Tables(0).Rows(0)
                strKANSI_NAME = Convert.ToString(dr.Item("KANSI_NAME"))
                strBIKOU = Convert.ToString(dr.Item("BIKOU"))
                strTEL = Convert.ToString(dr.Item("TEL"))
            End If
            strResult = "OK;" & strKANSI_NAME & ";" & strBIKOU & ";" & strTEL
        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            strResult = "ERROR;" & ex.ToString
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try
        Return strResult
    End Function
    '**********************************************************
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrFileNm As String, ByVal pstrString As String)
        Dim strPath As String = "D:\inetpub\wwwroot\JPGAP\TEMP\" & pstrFileNm & ".txt"

        '�������݃t�@�C���ւ̃X�g���[��
        Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

        '�����̕�������X�g���[���ɏ�������
        outFile.Write(pstrString + vbCrLf)

        '�������t���b�V���i�t�@�C���������݁j
        outFile.Flush()

        '�t�@�C���N���[�Y
        outFile.Close()

    End Sub
End Class
