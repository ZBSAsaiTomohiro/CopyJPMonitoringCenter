'***************************************************************************
'  �i�`�S���ҘA����G�N�Z���o��
'***************************************************************************
' �ύX����
' 2015/12/16 T.Ono �V�K�쐬
'�iMSTAEJAG00���R�s�[�@JA�S���ҁE�񍐐�E���ӎ����}�X�^���Q�Ƃ��邽�߂Ƀ��j���[�A���j

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAHJAW00/Service1")> _
Public Class MSTAHJAW00
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
    '******************************************************************************
    '*�@�T�@�v:�����`�F�b�N���s��
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    '  2019/11/01 T.Ono mod �Ď����P2019�@pstrKuracd_to��ǉ�
    <WebMethod()> Public Function mCheck(
                                        ByVal pstrKuracd As String,
                                        ByVal pstrKuracd_to As String,
                                        ByVal pstrJAcd As String,
                                        ByVal pstrGroupcd As String,
                                        ByVal pstrCentercd As String,
                                        ByVal pdecPageMax As Decimal
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim decGyoMax As Decimal = pdecPageMax '�ő�s��

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try


        '���[�o�͍��ڂ̎擾�pSQL���Z�b�g-------------------
        Try
            '���[�o�͍��ڂ̎擾�pSQL���Z�b�g
            '2019/11/01 T.Ono mod �Ď����P2019 pstrkuracd_to�ǉ�
            'cdb.pSQL = fncMakeSelect(2,
            '                         pstrKuracd,
            '                         pstrJAcd,
            '                         pstrGroupcd,
            '                         pstrCentercd)
            cdb.pSQL = fncMakeSelect(2,
                                     pstrKuracd,
                                     pstrKuracd_to,
                                     pstrJAcd,
                                     pstrGroupcd,
                                     pstrCentercd)

            '�p�����[�^�Z�b�g
            '�N���C�A���g�R�[�h
            If pstrKuracd.Length > 0 Then cdb.pSQLParamStr("KURACD") = pstrKuracd
            '�N���C�A���g�R�[�hTo  2019/11/01 T.Ono add �Ď����P2019
            If pstrKuracd_to.Length > 0 Then cdb.pSQLParamStr("KURACD_TO") = pstrKuracd_to
            '�i�`�R�[�h
            If pstrJAcd.Length > 0 Then cdb.pSQLParamStr("JACD") = pstrJAcd & "%"
            '�O���[�v�R�[�h
            If pstrGroupcd.Length > 0 Then cdb.pSQLParamStr("GROUPCD") = pstrGroupcd

            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            ElseIf ds.Tables(0).Rows.Count > decGyoMax Then
                Return "DATAMAX"    '�f�[�^���ő�s���𒴂��鎖�������������Ԃ�
            End If

            Return "OK"
        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function

    '******************************************************************************
    '*�@�T�@�v:�o�͂��s���܂�
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    '  2019/11/01 T.Ono mod �Ď����P2019�@pstrkuracd_to,pstrJAcd_CLI��ǉ�
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKuracd As String,
                                        ByVal pstrKuracd_to As String,
                                        ByVal pstrJAcd As String,
                                        ByVal pstrJAcd_CLI As String,
                                        ByVal pstrGroupcd As String,
                                        ByVal pstrPgkbn As String,
                                        ByVal pstrKuraNm As String,
                                        ByVal pstrGroupNm As String,
                                        ByVal pdecPageMax As Decimal,
                                        ByVal pstrCentcd As String
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim intGyoMax As Integer = CInt(pdecPageMax)    '�ő�s��
        Dim ExcelC As New CExcel                        'Excel�N���X
        Dim compressC As New CCompress                  '���k�N���X
        Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
        Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
        Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim strHedInfo As String                        '�w�b�_�[���i���o�����j
        Dim intPrntRow As Integer = 72
        Dim StrFileNM1() As String                      '�o�^̧�ٖ�1�@2013/07/25 T.Ono add
        Dim StrFileNM2() As String                      '�o�^̧�ٖ�2�@2013/07/25 T.Ono add
        Dim StrFileNMtmp(1) As String                   '�o�^̧�ٖ�tmp�@2013/07/25 T.Ono add

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '���[�o�͍��ڂ̎擾�pSQL���Z�b�g-------------------
        Try
            mlog("mExcel pstrKuracd:" & pstrKuracd & " pstrGroupcd:" & pstrGroupcd & " pstrCentcd:" & pstrCentcd)
            '���[�o�͍��ڂ̎擾�pSQL���Z�b�g
            '2019/11/01 T.Ono mod �Ď����P2019 pstrkuracd_to�ǉ�
            'strSQL.Append(fncMakeSelect(2,
            '                         pstrKuracd,
            '                         pstrJAcd,
            '                         pstrGroupcd,
            '                         pstrCentcd))
            strSQL.Append(fncMakeSelect(2,
                                     pstrKuracd,
                                     pstrKuracd_to,
                                     pstrJAcd,
                                     pstrGroupcd,
                                     pstrCentcd))

            '�p�����[�^�Z�b�g
            '2019/11/01 T.Ono mod �Ď����P2019 START
            ''�N���C�A���g�R�[�h
            'If pstrKuracd.Length > 0 Then cdb.pSQLParamStr("KURACD") = pstrKuracd
            ''�i�`�R�[�h
            'If pstrJAcd.Length > 0 Then cdb.pSQLParamStr("JACD") = pstrJAcd & "%"
            If pstrJAcd.Length > 0 Then
                '�i�`�R�[�h
                cdb.pSQLParamStr("JACD") = pstrJAcd & "%"
                '�N���C�A���g�R�[�h�@JA�w��̏ꍇ�́AJA�̃N���C�A���g�R�[�h������
                cdb.pSQLParamStr("KURACD") = pstrJAcd_CLI
                cdb.pSQLParamStr("KURACD_TO") = pstrJAcd_CLI
            Else
                '�N���C�A���g�R�[�h
                If pstrKuracd.Length > 0 Then cdb.pSQLParamStr("KURACD") = pstrKuracd
                If pstrKuracd_to.Length > 0 Then cdb.pSQLParamStr("KURACD_TO") = pstrKuracd_to
            End If
            '2019/11/01 T.Ono mod �Ď����P2019�@END
            '�O���[�v�R�[�h
            If pstrGroupcd.Length > 0 Then cdb.pSQLParamStr("GROUPCD") = pstrGroupcd

            cdb.pSQL = strSQL.ToString 'SQL���Z�b�g
            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
                Return "DATAMAX"    '�f�[�^���ő�s���𒴂��鎖�������������Ԃ�
            End If


            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ReDim Preserve StrFileNM1(j)
                ReDim Preserve StrFileNM2(j)

                If Convert.ToString(ds.Tables(0).Rows(j).Item("TANCD")) = "01" Then

                    StrFileNMtmp = fncSearchFile(Convert.ToString(ds.Tables(0).Rows(j).Item("GROUPCD")))
                    StrFileNM1(j) = StrFileNMtmp(0)
                    StrFileNM2(j) = StrFileNMtmp(1)
                Else
                    StrFileNM1(j) = ""
                    StrFileNM2(j) = ""
                End If
            Next

            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            ExcelC.pKencd = "00"                '���R�[�h���Z�b�g
            ExcelC.pSessionID = pstrSessionID   '�Z�b�V����ID
            ExcelC.pRepoID = "MSTAHJAW00"       '���[ID
            ExcelC.mOpen()                      '�t�@�C���I�[�v��

            ExcelC.pTitle = "�i�`�S���ҘA����"                        '�^�C�g��
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '�쐬��

            ExcelC.pFitPaper = True '�p���ɉ����Ńt�B�b�g������
            'If pstrPgkbn = "1" Then '1:�N���C�A���g�W��H
            '    ExcelC.pScale = 80                '�k���g�嗦(%)
            'Else
            '    ExcelC.pScale = 65                '�k���g�嗦(%)
            'End If

            '�������
            ExcelC.pLandScape = True 'true:��/false:�c
            '�]��
            ExcelC.pMarginTop = 2D
            ExcelC.pMarginBottom = 0.6D
            ExcelC.pMarginLeft = 1D
            ExcelC.pMarginRight = 0.5D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 1.3D
            ExcelC.pSheetName = "DATA"

            '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
            ExcelC.mHeader(65000, ds.Tables(0).Rows.Count, 1)

            '-----------------------
            ' �G�N�Z�����ڏ��
            '-----------------------
            Dim arrColNM1(31) As String
            Dim arrColNM2(31) As String
            Dim arrColID(31) As String
            Dim arrHeadBGColor(31) As String
            Dim zoku As String
            Dim buf As String

            Dim i As Integer
            If True Then
                arrColNM1(1) = "�敪"
                arrColNM1(2) = "�ײ��ĺ���"
                arrColNM1(3) = "��ٰ�ߺ���"
                arrColNM1(4) = "��ٰ�ߺ��ޖ�"
                arrColNM1(5) = "����"
                arrColNM1(6) = "�S���Җ�����"
                arrColNM1(7) = "�d�b�ԍ��P"
                arrColNM1(8) = "�d�b�ԍ��Q"
                arrColNM1(9) = "�d�b�ԍ��R"
                arrColNM1(10) = "��߯�FAX�ԍ�"
                arrColNM1(11) = "�L��"
                arrColNM1(12) = "��߯�FAX���M��Ұٱ��ڽ"
                arrColNM1(13) = "��߯�FAX�Y�ţ���߽ܰ��"
                arrColNM1(14) = "����FAX���M��"
                arrColNM1(15) = "����FAX���M��Ұٱ��ڽ"
                arrColNM1(16) = "����FAX�Y�ţ���߽ܰ��"
                arrColNM1(17) = "����FAX�ԍ�"
                arrColNM1(18) = "�������M�敪"
                arrColNM1(19) = "�[�������M�t���O"
                arrColNM1(20) = "�񍐗v�E�s�v�����l(JA)"
                arrColNM1(21) = "�񍐗v�E�s�v�����l(�ײ���)"
                arrColNM1(22) = "���ӎ���"
                arrColNM1(23) = "̧�ٓo�^�P"
                arrColNM1(24) = "̧�ٓo�^�Q"
                arrColNM1(25) = "�쐬����"
                arrColNM1(26) = "�쐬��"
                arrColNM1(27) = "�X�V����"
                arrColNM1(28) = "�X�V��"
                arrColNM1(29) = "�ײ��ĺ���"
                arrColNM1(30) = "�ײ��Ė�"
            End If
            If True Then
                arrColID(1) = "KBN"
                arrColID(2) = "KURACD"
                arrColID(3) = "GROUPCD"
                arrColID(4) = "GROUPNM"
                arrColID(5) = "TANCD"
                arrColID(6) = "TANNM"
                arrColID(7) = "RENTEL1"
                arrColID(8) = "RENTEL2"
                arrColID(9) = "RENTEL3"
                arrColID(10) = "FAXNO"
                arrColID(11) = "BIKO"
                arrColID(12) = "SPOT_MAIL"
                arrColID(13) = "MAIL_PASS"
                arrColID(14) = "AUTO_FAXNM"
                arrColID(15) = "AUTO_MAIL"
                arrColID(16) = "AUTO_MAIL_PASS"
                arrColID(17) = "AUTO_FAXNO"
                arrColID(18) = "AUTO_KBN"
                arrColID(19) = "AUTO_ZERO_FLG"
                arrColID(20) = "FAXKBN"
                arrColID(21) = "FAXKURAKBN"
                arrColID(22) = "GUIDELINE"
                arrColID(23) = "file1"
                arrColID(24) = "file2"
                arrColID(25) = "INS_DATE"
                arrColID(26) = "INS_USER"
                arrColID(27) = "UPD_DATE"
                arrColID(28) = "UPD_USER"
                arrColID(29) = "CLI_CD"
                arrColID(30) = "CLI_NAME"
            End If

            If True Then
                arrHeadBGColor(1) = "background:#99CCFF;" '��
                arrHeadBGColor(2) = "background:#99CCFF;" '��
                arrHeadBGColor(3) = "background:#99CCFF;" '��
                arrHeadBGColor(4) = "background:#99CCFF;" '��
                arrHeadBGColor(5) = "background:#99CCFF;" '��
                arrHeadBGColor(6) = "background:#99CCFF;" '��
                arrHeadBGColor(7) = "background:#99CCFF;" '��
                arrHeadBGColor(8) = "background:#99CCFF;" '��
                arrHeadBGColor(9) = "background:#99CCFF;" '��
                arrHeadBGColor(10) = "background:#99CCFF;" '��
                arrHeadBGColor(11) = "background:#99CCFF;" '��
                arrHeadBGColor(12) = "background:#99CCFF;" '��
                arrHeadBGColor(13) = "background:#99CCFF;" '��
                arrHeadBGColor(14) = "background:#99CCFF;" '��
                arrHeadBGColor(15) = "background:#99CCFF;" '��
                arrHeadBGColor(16) = "background:#99CCFF;" '��
                arrHeadBGColor(17) = "background:#99CCFF;" '��
                arrHeadBGColor(18) = "background:#99CCFF;" '��
                arrHeadBGColor(19) = "background:#99CCFF;" '��
                arrHeadBGColor(20) = "background:#99CCFF;" '��
                arrHeadBGColor(21) = "background:#99CCFF;" '��
                arrHeadBGColor(22) = "background:#99CCFF;" '��
                arrHeadBGColor(23) = "background:#99CCFF;" '��
                arrHeadBGColor(24) = "background:#99CCFF;" '��
                arrHeadBGColor(25) = "background:#99CCFF;" '��
                arrHeadBGColor(26) = "background:#99CCFF;" '��
                arrHeadBGColor(27) = "background:#99CCFF;" '��
                arrHeadBGColor(28) = "background:#99CCFF;" '��
                arrHeadBGColor(29) = "background:#CCFFCC;" '����
                arrHeadBGColor(30) = "background:#CCFFCC;" '����
            End If


            '���w�b�_�s1
            For i = 1 To 30
                ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(i)
                ExcelC.pCellVal(i) = arrColNM1(i)
            Next
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������

            '�����׃f�[�^�s
            Dim iCnt As Integer
            Dim tmp As String
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                '���׍���
                For i = 1 To 30
                    buf = ""
                    tmp = ""
                    zoku = ""
                    ' �o�^̧�ٖ�������
                    If i = 23 Then
                        buf = Convert.ToString(StrFileNM1(iCnt))  '�o�^̧��1
                    ElseIf i = 24 Then
                        buf = Convert.ToString(StrFileNM2(iCnt)) '�o�^̧��2
                    Else
                        buf = Convert.ToString(dr.Item(arrColID(i)))
                    End If
                    tmp = "text-align:left;white-space:nowrap;"

                    ExcelC.pCellStyle(i) = "height:16px;font-size:11px;border-style:solid;" & tmp
                    ExcelC.pCellVal(i, zoku) = buf
                Next
                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
            Next

            ExcelC.mClose()                                 '�t�@�C���N���[�Y

            '���k��t�@�C���̂���t�H���_
            compressC.p_Dir = ExcelC.pDirName
            '���{��t�@�C�����̎w��
            compressC.p_NihongoFileName = "�i�`�S���ҘA����.xls"
            '���k���t�@�C����
            compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
            '���k��t�@�C����
            compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
            'Excel�𒼐ڊJ���悤�ɕύX�A�t�@�C���t���p�X��Ԃ�
            ''���k���s
            'compressC.mCompress()
            ''���k�����t�@�C����Base64�G���R�[�h���Ė߂�
            ''.xls�`���ɕύX
            ''Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
            'Return FileToStrC.mFileToStr(compressC.p_FileName)
            Return compressC.p_FileName

        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function

    '******************************************************************************
    '*�@�T�@�v:�r�d�k�d�b�s�����쐬
    '*�@���@�l:[ind]1:�����擾  2:�f�[�^�擾
    '******************************************************************************
    '  2019/11/01 T.Ono mod �Ď����P2019�@pstrkuracd_to��ǉ�
    Public Function fncMakeSelect(ByVal ind As Integer,
                                  ByVal pstrKuracd As String,
                                  ByVal pstrKuracd_to As String,
                                  ByVal pstrJAcd As String,
                                  ByVal pstrGroupcd As String,
                                  ByVal pstrCentercd As String) As String

        Dim strSQL As New StringBuilder("")
        Dim strWHE As New StringBuilder("")

        '�Ď��Z���^�[�R�[�h
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        arrTemp = pstrCentercd.Split(Convert.ToChar(","))
        For i = 0 To arrTemp.Length - 1
            If strCenter.Length > 0 Then
                strCenter = strCenter & ","
            End If
            strCenter = strCenter & "'" & arrTemp(i) & "'"
        Next

        If ind = 1 Then

        Else
            '----------------
            ' 2:�f�[�^�擾
            '----------------
            '�R�t������
            strSQL.Append("WITH Z AS  ")
            strSQL.Append("(SELECT X.KURACD, X.GROUPCD, Y.CLI_CD, Y.CLI_NAME ")
            strSQL.Append(" FROM M09_JAGROUP X ")
            strSQL.Append("	,CLIMAS Y ")
            strSQL.Append(" WHERE X.KBN = '002' ")
            If pstrCentercd.Trim.Length > 0 Then
                strSQL.Append(" AND Y.KANSI_CODE IN (" & strCenter & ") ")
            End If
            If pstrKuracd.Trim.Length > 0 Then
                '2049/11/01 T.Ono mod �Ď����P2019
                'strSQL.Append(" AND Y.CLI_CD = :KURACD ")
                strSQL.Append(" AND Y.CLI_CD >= :KURACD ")
                strSQL.Append(" AND Y.CLI_CD <= :KURACD_TO ")
            End If
            If pstrJAcd.Trim.Length > 0 Then
                strSQL.Append(" AND X.ACBCD LIKE :JACD ")
            End If
            If pstrGroupcd.Trim.Length > 0 Then
                strSQL.Append(" AND X.GROUPCD = :GROUPCD ")
            End If
            strSQL.Append(" AND X.KURACD = Y.CLI_CD ")
            If pstrKuracd.Trim.Length = 0 Then '�ײ��Ă��ׂ��O���[�v�����邽�߁A2�d�o�͂���Ȃ��悤�ɂ���
                strSQL.Append(" AND X.KURACD = (SELECT MIN(W.KURACD) ")
                strSQL.Append("                 FROM M09_JAGROUP W ")
                strSQL.Append("                 WHERE X.GROUPCD = W.GROUPCD) ")
            End If
            strSQL.Append(" GROUP BY KURACD, GROUPCD, CLI_CD, CLI_NAME ")
            strSQL.Append(" ORDER BY KURACD, GROUPCD ")
            strSQL.Append(") ")
            strSQL.Append("SELECT ")
            strSQL.Append("  A.KBN ")
            strSQL.Append("	,A.GROUPCD AS SORT ")
            strSQL.Append("	,'' AS KURACD ")
            'strSQL.Append("	,A.GROUPCD ")
            strSQL.Append("	,DECODE(A.TANCD, '01', A.GROUPCD, '') AS GROUPCD ")
            strSQL.Append("	,A.GROUPNM ")
            strSQL.Append("	,A.TANCD ")
            strSQL.Append("	,A.TANNM ")
            strSQL.Append("	,A.RENTEL1 ")
            strSQL.Append("	,A.RENTEL2 ")
            strSQL.Append("	,A.RENTEL3 ")
            strSQL.Append("	,A.FAXNO ")
            strSQL.Append("	,A.BIKO ")
            strSQL.Append("	,A.SPOT_MAIL ")
            strSQL.Append("	,A.MAIL_PASS ")
            strSQL.Append("	,A.AUTO_FAXNM ")
            strSQL.Append("	,A.AUTO_MAIL ")
            strSQL.Append("	,A.AUTO_MAIL_PASS ")
            strSQL.Append("	,A.AUTO_FAXNO ")
            strSQL.Append("	,A.AUTO_KBN ")
            strSQL.Append("	,A.AUTO_ZERO_FLG ")
            strSQL.Append("	,A.GUIDELINE ")
            strSQL.Append("	,A.FAXKBN ")
            strSQL.Append("	,A.FAXKURAKBN ")
            strSQL.Append("	,A.INS_DATE ")
            strSQL.Append("	,A.INS_USER ")
            strSQL.Append("	,A.UPD_DATE ")
            strSQL.Append("	,A.UPD_USER ")
            strSQL.Append("	,Z.CLI_CD ")
            strSQL.Append("	,Z.CLI_NAME ")
            strSQL.Append("FROM M11_JAHOKOKU A ")
            strSQL.Append("	,Z ")
            strSQL.Append("WHERE A.KBN = '2' ")
            strSQL.Append("AND A.GROUPCD = Z.GROUPCD ")

            If pstrKuracd.Trim.Length = 0 Then
                '�R�t���Ȃ�
                strSQL.Append("UNION ALL ")
                strSQL.Append("SELECT ")
                strSQL.Append("  A.KBN ")
                strSQL.Append("	,A.GROUPCD AS SORT ")
                strSQL.Append("	,'' AS KURACD ")
                'strSQL.Append("	,A.GROUPCD ")
                strSQL.Append("	,DECODE(A.TANCD, '01', A.GROUPCD, '') AS GROUPCD ")
                strSQL.Append("	,A.GROUPNM ")
                strSQL.Append("	,A.TANCD ")
                strSQL.Append("	,A.TANNM ")
                strSQL.Append("	,A.RENTEL1 ")
                strSQL.Append("	,A.RENTEL2 ")
                strSQL.Append("	,A.RENTEL3 ")
                strSQL.Append("	,A.FAXNO ")
                strSQL.Append("	,A.BIKO ")
                strSQL.Append("	,A.SPOT_MAIL ")
                strSQL.Append("	,A.MAIL_PASS ")
                strSQL.Append("	,A.AUTO_FAXNM ")
                strSQL.Append("	,A.AUTO_MAIL ")
                strSQL.Append("	,A.AUTO_MAIL_PASS ")
                strSQL.Append("	,A.AUTO_FAXNO ")
                strSQL.Append("	,A.AUTO_KBN ")
                strSQL.Append("	,A.AUTO_ZERO_FLG ")
                strSQL.Append("	,A.GUIDELINE ")
                strSQL.Append("	,A.FAXKBN ")
                strSQL.Append("	,A.FAXKURAKBN ")
                strSQL.Append("	,A.INS_DATE ")
                strSQL.Append("	,A.INS_USER ")
                strSQL.Append("	,A.UPD_DATE ")
                strSQL.Append("	,A.UPD_USER ")
                strSQL.Append("	,'' AS CLI_CD ")
                strSQL.Append("	,'' AS CLI_NAME ")
                strSQL.Append("FROM M11_JAHOKOKU A ")
                strSQL.Append("WHERE A.KBN = '2' ")
                If pstrGroupcd.Trim.Length > 0 Then
                    strSQL.Append("AND A.GROUPCD = :GROUPCD ")
                End If
                strSQL.Append("AND NOT EXISTS(SElECT 'X' FROM M09_JAGROUP B WHERE A.GROUPCD = B.GROUPCD) ")
            End If

            If pstrJAcd.Trim.Length = 0 AndAlso pstrGroupcd.Trim.Length = 0 Then
                '�N���C�A���g�o�^ �ײ��Ă̂ݎw�肵���Ƃ��ɕ\������B
                strSQL.Append("UNION ALL ")
                strSQL.Append("SELECT A.KBN ")
                strSQL.Append("	,A.GROUPCD AS SORT ")
                'strSQL.Append("	,A.GROUPCD AS KURACD ")
                strSQL.Append("	,DECODE(A.TANCD, '01', A.GROUPCD, '') AS KURACD ")
                strSQL.Append("	,'' AS GROUPCD ")
                strSQL.Append("	,A.GROUPNM ")
                strSQL.Append("	,A.TANCD ")
                strSQL.Append("	,A.TANNM ")
                strSQL.Append("	,A.RENTEL1 ")
                strSQL.Append("	,A.RENTEL2 ")
                strSQL.Append("	,A.RENTEL3 ")
                strSQL.Append("	,A.FAXNO ")
                strSQL.Append("	,A.BIKO ")
                strSQL.Append("	,A.SPOT_MAIL ")
                strSQL.Append("	,A.MAIL_PASS ")
                strSQL.Append("	,A.AUTO_FAXNM ")
                strSQL.Append("	,A.AUTO_MAIL ")
                strSQL.Append("	,A.AUTO_MAIL_PASS ")
                strSQL.Append("	,A.AUTO_FAXNO ")
                strSQL.Append("	,A.AUTO_KBN ")
                strSQL.Append("	,A.AUTO_ZERO_FLG ")
                strSQL.Append("	,A.GUIDELINE ")
                strSQL.Append("	,A.FAXKBN ")
                strSQL.Append("	,A.FAXKURAKBN ")
                strSQL.Append("	,A.INS_DATE ")
                strSQL.Append("	,A.INS_USER ")
                strSQL.Append("	,A.UPD_DATE ")
                strSQL.Append("	,A.UPD_USER ")
                strSQL.Append(" ,B.CLI_CD ")
                strSQL.Append("	,B.CLI_NAME ")
                strSQL.Append("FROM M11_JAHOKOKU A ")
                strSQL.Append("	,CLIMAS B ")
                strSQL.Append("WHERE A.KBN = '1' ")
                If pstrCentercd.Trim.Length > 0 Then
                    strSQL.Append("AND B.KANSI_CODE IN (" & strCenter & ") ")
                End If
                If pstrKuracd.Trim.Length > 0 Then
                    '2019/11/01 T.Ono mod �Ď����P2019
                    'strSQL.Append("AND A.GROUPCD = :KURACD ")
                    strSQL.Append("AND A.GROUPCD >= :KURACD ")
                    strSQL.Append("AND A.GROUPCD <= :KURACD_TO ")
                End If
                strSQL.Append("AND A.GROUPCD = B.CLI_CD ")
            End If

            strSQL.Append("ORDER BY KBN, SORT, TANCD ")

        End If

        Return strSQL.ToString

    End Function


    Private Function fncSearchFile(ByVal GROUPCD As String) As String()

        Dim Res() As String = {"", ""}
        Dim searchPattern As String
        Dim folder As String
        Dim buf As String

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

        searchPattern = GROUPCD.Trim & "_"

        Dim fs As String() = System.IO.Directory.GetFiles(folder, searchPattern & "*") 'folder�ɂ���t�@�C�����擾����
        If fs.Length > 0 Then
            buf = fs(0).Substring(fs(0).LastIndexOf("\") + 1)
            Res(0) = buf.Substring(searchPattern.Length)

        End If
        If fs.Length > 1 Then
            buf = fs(1).Substring(fs(1).LastIndexOf("\") + 1)
            Res(1) = buf.Substring(searchPattern.Length)
        End If


        Return Res
    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testMSTAH" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

            '�����̕�������X�g���[���ɏ�������
            outFile.Write(System.DateTime.Now & ":[" & pstrString + "]" & vbCrLf)

            '�������t���b�V���i�t�@�C���������݁j
            outFile.Flush()

            '�t�@�C���N���[�Y
            outFile.Close()
        End If
    End Sub
End Class
