'***************************************************************************
'  �i�`�S���ҘA����G�N�Z���o��
'***************************************************************************
' �ύX����
' 2010/03/29 T.Watabe �V�K�쐬

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAEJAW00/Service1")> _
Public Class MSTAEJAW00
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
    <WebMethod()> Public Function mCheck( _
                                        ByVal pstrKuracd As String, _
                                        ByVal pstrJacd As String, _
                                        ByVal pdecPageMax As Decimal _
                                        ) As String
        Dim strSQL As New StringBuilder("")
        Dim cdb As New cdb
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
            cdb.pSQL = fncMakeSelect(2, _
                                     pstrKuracd, _
                                     pstrJacd)

            '�p�����[�^�Z�b�g
            If pstrKuracd.Length <> 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKuracd
            End If
            If pstrJacd.Length > 0 Then cdb.pSQLParamStr("JACD") = pstrJacd

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
    <WebMethod()> Public Function mExcel( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKuracd As String, _
                                        ByVal pstrJacd As String, _
                                        ByVal pstrPgkbn As String, _
                                        ByVal pstrKuraNm As String, _
                                        ByVal pstrJaNm As String, _
                                        ByVal pdecPageMax As Decimal, _
                                        ByVal pstrCentcd As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New cdb
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
            '���[�o�͍��ڂ̎擾�pSQL���Z�b�g
            strSQL.Append(fncMakeSelect(2, _
                                     pstrKuracd, _
                                     pstrJacd))

            cdb.pSQL = strSQL.ToString 'SQL���Z�b�g
            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
                Return "DATAMAX"    '�f�[�^���ő�s���𒴂��鎖�������������Ԃ�
            End If

            ' 2013/07/25 T.Ono add
            For j As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ReDim Preserve StrFileNM1(j)
                ReDim Preserve StrFileNM2(j)

                If Convert.ToString(ds.Tables(0).Rows(j).Item("TANCD")) = "01" Then

                    StrFileNMtmp = fncSearchFile(Convert.ToString(ds.Tables(0).Rows(j).Item("KURACD")), Convert.ToString(ds.Tables(0).Rows(j).Item("CODE")), _
                                  Convert.ToString(ds.Tables(0).Rows(j).Item("USER_CD_FROM")))

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
            ExcelC.pRepoID = "MSTAEJAW00"       '���[ID
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
            ' 2013/07/05 T.Ono mod ��ǉ� ---------- START
            'Dim arrColNM1(24) As String
            'Dim arrColNM2(24) As String
            'Dim arrColID(24) As String
            'Dim arrWidth(24) As String '�� ����1�`24
            'Dim arrHeadBGColor(24) As String
            Dim arrColNM1(40) As String
            Dim arrColNM2(40) As String
            Dim arrColID(40) As String
            Dim arrWidth(40) As String '�� ����1�`28
            Dim arrHeadBGColor(40) As String
            ' 2013/07/05 T.Ono mod ��ǉ� ---------- END
            Dim zoku As String
            Dim buf As String

            Dim i As Integer
            If True Then
                ' 2013/07/05 T.Ono mod ��ǉ�&�^�C�g���������ɕύX ---------- START
                'arrColNM1(1) = "KBN"
                'arrColNM1(2) = "KURACD"
                'arrColNM1(3) = "CODE"
                'arrColNM1(4) = "TANCD"
                'arrColNM1(5) = "TANNM"
                'arrColNM1(6) = "RENTEL1"
                'arrColNM1(7) = "RENTEL2"
                'arrColNM1(8) = "FAXNO"
                'arrColNM1(9) = "DISP_NO"
                'arrColNM1(10) = "BIKO"
                'arrColNM1(11) = "ADD_DATE"
                'arrColNM1(12) = "EDT_DATE"
                'arrColNM1(13) = "TIME"
                'arrColNM1(14) = "HAN_CD"
                'arrColNM1(15) = "JAS_NAME"
                'arrColNM1(16) = "JAS_KANA"
                'arrColNM1(17) = "JA_CD"
                'arrColNM1(18) = "JA_NAME"
                'arrColNM1(19) = "JA_KANA"
                'arrColNM1(20) = "TEL_REN1"
                'arrColNM1(21) = "TEL_FAX1"
                'arrColNM1(22) = "HAN_KETA"
                'arrColNM1(23) = "JA_KETA"
                'arrColNM1(24) = "CLI_NAME"
                arrColNM1(1) = "�敪"
                arrColNM1(2) = "�ײ���޺���"
                arrColNM1(3) = "JA�x������"
                arrColNM1(4) = "���q�l����(FROM)"
                arrColNM1(5) = "���q�l����(TO)"
                arrColNM1(6) = "����"
                arrColNM1(7) = "�S���Җ�����"
                arrColNM1(8) = "�d�b�ԍ��P"
                arrColNM1(9) = "�d�b�ԍ��Q"
                arrColNM1(10) = "�d�b�ԍ��R"
                arrColNM1(11) = "��߯�FAX�ԍ�"
                '2013/12/06 T.Ono mod �Ď����P2013
                'arrColNM1(12) = "���l"
                arrColNM1(12) = "�L��"
                arrColNM1(13) = "��߯�FAX���M��Ұٱ��ڽ"
                arrColNM1(14) = "��߯�FAX�Y�ţ���߽ܰ��"
                arrColNM1(15) = "����FAX���M��"
                arrColNM1(16) = "����FAX���M��Ұٱ��ڽ"
                arrColNM1(17) = "����FAX�Y�ţ���߽ܰ��"
                arrColNM1(18) = "����FAX�ԍ�"
                arrColNM1(19) = "�������M�敪"
                arrColNM1(20) = "�[�������M�t���O"
                '2013/12/06 T.Ono mod �Ď����P2013
                'arrColNM1(21) = "FAX�s�v�����l(JA)"
                'arrColNM1(22) = "FAX�s�v�����l(�ײ���)"
                arrColNM1(21) = "�񍐗v�E�s�v�����l(JA)"
                arrColNM1(22) = "�񍐗v�E�s�v�����l(�ײ���)"
                arrColNM1(23) = "���ӎ���"
                arrColNM1(24) = "̧�ٓo�^�P"
                arrColNM1(25) = "̧�ٓo�^�Q"
                arrColNM1(26) = "�\����"
                arrColNM1(27) = "�쐬��"
                arrColNM1(28) = "�X�V��"
                arrColNM1(29) = "�X�V����"
                arrColNM1(30) = "JA�x������"
                arrColNM1(31) = "JA�x����"
                arrColNM1(32) = "JA�x������"
                arrColNM1(33) = "JA����"
                arrColNM1(34) = "JA��"
                arrColNM1(35) = "JA����"
                arrColNM1(36) = "�d�b�ԍ�"
                arrColNM1(37) = "FAX�ԍ�"
                arrColNM1(38) = "JA����(HAN_KETA)"
                arrColNM1(39) = "JA�x������(JA_KETA)"
                arrColNM1(40) = "�ײ��Ė�"
                ' 2013/07/05 T.Ono mod ��ǉ� ---------- END
            End If
            If True Then
                ' 2013/07/05 T.Ono mod ��ǉ� ---------- START
                'arrColID(1) = "KBN"
                'arrColID(2) = "KURACD"
                'arrColID(3) = "CODE"
                'arrColID(4) = "TANCD"
                'arrColID(5) = "TANNM"
                'arrColID(6) = "RENTEL1"
                'arrColID(7) = "RENTEL2"
                'arrColID(8) = "FAXNO"
                'arrColID(9) = "DISP_NO"
                'arrColID(10) = "BIKO"
                'arrColID(11) = "ADD_DATE"
                'arrColID(12) = "EDT_DATE"
                'arrColID(13) = "TIME"
                'arrColID(14) = "HAN_CD"
                'arrColID(15) = "JAS_NAME"
                'arrColID(16) = "JAS_KANA"
                'arrColID(17) = "JA_CD"
                'arrColID(18) = "JA_NAME"
                'arrColID(19) = "JA_KANA"
                'arrColID(20) = "TEL_REN1"
                'arrColID(21) = "TEL_FAX1"
                'arrColID(22) = "HAN_KETA"
                'arrColID(23) = "JA_KETA"
                'arrColID(24) = "CLI_NAME"
                arrColID(1) = "KBN"
                arrColID(2) = "KURACD"
                arrColID(3) = "CODE"
                arrColID(4) = "USER_CD_FROM"
                arrColID(5) = "USER_CD_TO"
                arrColID(6) = "TANCD"
                arrColID(7) = "TANNM"
                arrColID(8) = "RENTEL1"
                arrColID(9) = "RENTEL2"
                arrColID(10) = "RENTEL3"
                arrColID(11) = "FAXNO"
                arrColID(12) = "BIKO"
                arrColID(13) = "SPOT_MAIL"
                arrColID(14) = "MAIL_PASS"
                arrColID(15) = "AUTO_FAXNM"
                arrColID(16) = "AUTO_MAIL"
                arrColID(17) = "AUTO_MAIL_PASS"
                arrColID(18) = "AUTO_FAXNO"
                arrColID(19) = "AUTO_KBN"
                arrColID(20) = "AUTO_ZERO_FLG"
                arrColID(21) = "FAXKBN"
                arrColID(22) = "FAXKURAKBN"
                arrColID(23) = "GUIDELINE"
                arrColID(24) = "file1"
                arrColID(25) = "file2"
                arrColID(26) = "DISP_NO"
                arrColID(27) = "ADD_DATE"
                arrColID(28) = "EDT_DATE"
                arrColID(29) = "TIME"
                arrColID(30) = "HAN_CD"
                arrColID(31) = "JAS_NAME"
                arrColID(32) = "JAS_KANA"
                arrColID(33) = "JA_CD"
                arrColID(34) = "JA_NAME"
                arrColID(35) = "JA_KANA"
                arrColID(36) = "TEL_REN1"
                arrColID(37) = "TEL_FAX1"
                arrColID(38) = "HAN_KETA"
                arrColID(39) = "JA_KETA"
                arrColID(40) = "CLI_NAME"
                ' 2013/07/05 T.Ono mod ��ǉ� ---------- END
            End If
            'If True Then '��
            '    arrWidth(1) = "31"
            '    arrWidth(2) = "66"
            '    arrWidth(3) = "66"
            '    arrWidth(4) = "66"
            '    arrWidth(5) = "66"
            '    arrWidth(6) = "66"
            '    arrWidth(7) = "66"
            '    arrWidth(8) = "66"
            '    arrWidth(9) = "66"
            '    arrWidth(10) = "66"
            '    arrWidth(11) = "66"
            '    arrWidth(12) = "66"
            '    arrWidth(13) = "66"
            '    arrWidth(14) = "66"
            '    arrWidth(15) = "66"
            '    arrWidth(16) = "66"
            '    arrWidth(17) = "66"
            '    arrWidth(18) = "66"
            '    arrWidth(19) = "66"
            '    arrWidth(20) = "66"
            '    arrWidth(21) = "66"
            '    arrWidth(22) = "66"
            '    arrWidth(23) = "66"
            'End If
            If True Then
                'arrHeadBGColor(1) = "background:#99CCFF;" '��
                'arrHeadBGColor(2) = "background:#99CCFF;" '��
                'arrHeadBGColor(3) = "background:#99CCFF;" '��
                'arrHeadBGColor(4) = "background:#99CCFF;" '��
                'arrHeadBGColor(5) = "background:#99CCFF;" '��
                'arrHeadBGColor(6) = "background:#99CCFF;" '��
                'arrHeadBGColor(7) = "background:#99CCFF;" '��
                'arrHeadBGColor(8) = "background:#99CCFF;" '��
                'arrHeadBGColor(9) = "background:#99CCFF;" '��
                'arrHeadBGColor(10) = "background:#99CCFF;" '��
                'arrHeadBGColor(11) = "background:#99CCFF;" '��
                'arrHeadBGColor(12) = "background:#99CCFF;" '��
                'arrHeadBGColor(13) = "background:#99CCFF;" '��
                'arrHeadBGColor(14) = "background:#CCFFCC;" '����
                'arrHeadBGColor(15) = "background:#CCFFCC;" '����
                'arrHeadBGColor(16) = "background:#CCFFCC;" '����
                'arrHeadBGColor(17) = "background:#CCFFCC;" '����
                'arrHeadBGColor(18) = "background:#CCFFCC;" '����
                'arrHeadBGColor(19) = "background:#CCFFCC;" '����
                'arrHeadBGColor(20) = "background:#CCFFCC;" '����
                'arrHeadBGColor(21) = "background:#CCFFCC;" '����
                'arrHeadBGColor(22) = "background:#CCFFCC;" '����
                'arrHeadBGColor(23) = "background:#CCFFCC;" '����
                'arrHeadBGColor(24) = "background:#CCFFFF;" '���F
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
                arrHeadBGColor(29) = "background:#99CCFF;" '��
                arrHeadBGColor(30) = "background:#CCFFCC;" '����
                arrHeadBGColor(31) = "background:#CCFFCC;" '����
                arrHeadBGColor(32) = "background:#CCFFCC;" '����
                arrHeadBGColor(33) = "background:#CCFFCC;" '����
                arrHeadBGColor(34) = "background:#CCFFCC;" '����
                arrHeadBGColor(35) = "background:#CCFFCC;" '����
                arrHeadBGColor(36) = "background:#CCFFCC;" '����
                arrHeadBGColor(37) = "background:#CCFFCC;" '����
                arrHeadBGColor(38) = "background:#CCFFCC;" '����
                arrHeadBGColor(39) = "background:#CCFFCC;" '����
                arrHeadBGColor(40) = "background:#CCFFFF;" '���F
            End If


            '���w�b�_�s1
            ' 2013/07/05 T.Ono mod
            'For i = 1 To 24
            For i = 1 To 40
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
                ' 2013/07/05 T.Ono mod
                'For i = 1 To 24
                For i = 1 To 40
                    buf = ""
                    tmp = ""
                    zoku = ""
                    ' �o�^̧�ٖ������� 2013/07/25 T.Ono add
                    'buf = Convert.ToString(dr.Item(arrColID(i)))
                    If i = 24 Then
                        buf = Convert.ToString(StrFileNM1(iCnt))  '�o�^̧��1
                    ElseIf i = 25 Then
                        buf = Convert.ToString(StrFileNM2(iCnt)) '�o�^̧��2
                    Else
                        buf = Convert.ToString(dr.Item(arrColID(i)))
                    End If
                    'tmp = "width:" & arrWidth(i) & "px;"
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
            '2014/01/16 T.Ono mod �Ď����P2013 Excel�𒼐ڊJ���悤�ɕύX�A�t�@�C���t���p�X��Ԃ�
            ''���k���s
            'compressC.mCompress()
            ''���k�����t�@�C����Base64�G���R�[�h���Ė߂�
            ''.xls�`���ɕύX 2013/12/06 T.Ono mod �Ď����P2013
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
    Public Function fncMakeSelect(ByVal ind As Integer, _
                                  ByVal pstrKuracd As String, _
                                  ByVal pstrJacd As String) As String

        Dim strSQL As New StringBuilder("")
        Dim strWHE As New StringBuilder("")

        '----------------
        ' SQL�����쐬(����)
        '----------------
        If Len(pstrKuracd) > 0 Then '�N���C�A���g�R�[�h
            strWHE.Append("    AND A.KURACD = '" & pstrKuracd & "' ")
        End If
        If Len(pstrJacd) > 0 Then '�i�`�R�[�h
            '2010/05/16 NEC ou Upd Str
            'strWHE.Append("    AND A.CODE = '" & pstrJacd & "' ")
            strWHE.Append("    AND B.JA_CD = '" & pstrJacd & "' ")
            '2010/05/16 NEC ou Upd End
        End If

        If ind = 1 Then
            '----------------
            ' 1:�����擾
            '----------------
            strSQL.Append("SELECT COUNT(*) FROM M05_TANTO A ")
            strSQL.Append("    WHERE  ")
            strSQL.Append("        1=1 ")
            strSQL.Append("    AND A.KBN = '3'  ")
            strSQL.Append(strWHE) '�����ǉ�
        Else
            '----------------
            ' 2:�f�[�^�擾
            '----------------
            '/* SQL3�Ď�HON����i�`�S���҃f�[�^�ꗗ�𔲂��o��.SQL */
            strSQL.Append("SELECT ")
            strSQL.Append("    A.KBN      , ")
            strSQL.Append("    A.KURACD   , ")
            'strSQL.Append("    A.CODE     , ") '2013/07/31 T.Ono add
            strSQL.Append("    DECODE(A.CODE, 'XXXX' ,'', A.CODE) AS CODE     , ")
            strSQL.Append("    LPAD(A.TANCD,2,'0') AS TANCD, ")
            strSQL.Append("    A.TANNM    , ")
            strSQL.Append("    A.RENTEL1  , ")
            strSQL.Append("    A.RENTEL2  , ")
            strSQL.Append("    A.FAXNO    , ")
            strSQL.Append("    A.DISP_NO  , ")
            strSQL.Append("    A.BIKO     , ")
            strSQL.Append("    A.ADD_DATE , ")
            strSQL.Append("    A.EDT_DATE , ")
            strSQL.Append("    A.TIME     , ")
            strSQL.Append("    B.HAN_CD,  ")
            strSQL.Append("    B.JAS_NAME,  ")
            strSQL.Append("    B.JAS_KANA,  ")
            strSQL.Append("    B.JA_CD,  ")
            strSQL.Append("    B.JA_NAME,  ")
            strSQL.Append("    B.JA_KANA,  ")
            strSQL.Append("    B.TEL_REN1,  ")
            strSQL.Append("    B.TEL_FAX1,  ")
            strSQL.Append("    B.HAN_KETA,  ")
            strSQL.Append("    B.JA_KETA, ")
            strSQL.Append("    C.CLI_NAME ")
            ' 2013/07/05 T.Ono add ---------- START
            strSQL.Append(" �@ , ")
            strSQL.Append(" �@ NULL AS USER_CD_FROM, ")
            strSQL.Append("    NULL AS USER_CD_TO, ")
            strSQL.Append("    A.RENTEL3, ")
            strSQL.Append("    A.AUTO_FAXNO, ")
            strSQL.Append("    A.SPOT_MAIL,      ")
            strSQL.Append("    A.MAIL_PASS,    ")
            strSQL.Append("    A.AUTO_FAXNM,     ")
            strSQL.Append("    A.AUTO_MAIL,     ")
            strSQL.Append("    A.AUTO_MAIL_PASS, ")
            strSQL.Append("    A.AUTO_FAXNO,     ")
            strSQL.Append("    A.AUTO_KBN,       ")
            strSQL.Append("    A.AUTO_ZERO_FLG, ")
            strSQL.Append("    A.FAXKURAKBN,     ")
            strSQL.Append("    A.FAXKBN,         ")
            strSQL.Append("    A.GUIDELINE,      ")
            strSQL.Append("    '01' AS NO, ")   'M05_TANTO�Ƌ��
            strSQL.Append("    DECODE(A.CODE,'XXXX','01','02') AS NO2 ")   '�N���C�A���g�݂̂̓o�^�����
            ' 2013/07/05 T.Ono add ---------- END
            strSQL.Append("FROM  ")
            strSQL.Append("    M05_TANTO A,  ")
            strSQL.Append("    HN2MAS B,  ")
            strSQL.Append("    CLIMAS C ")
            strSQL.Append("WHERE  ")
            strSQL.Append("        B.CLI_CD (+) = A.KURACD ")
            strSQL.Append("    AND B.HAN_CD (+) = A.CODE ")
            strSQL.Append("    AND C.CLI_CD (+) = A.KURACD ")
            strSQL.Append("    AND A.KBN = '3'  ")
            strSQL.Append(strWHE) '�����ǉ�
            ' ������ 2013/07/05 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            ' M05_TANTO2������f�[�^���擾
            'strSQL.Append("ORDER BY  ")
            'strSQL.Append("    A.KURACD   , ")
            'strSQL.Append("    A.CODE     , ")
            'strSQL.Append("    LPAD(A.TANCD,2,'0') ")
            strSQL.Append("UNION ALL ")
            strSQL.Append("SELECT ")
            strSQL.Append("    A.KBN      , ")
            strSQL.Append("    A.KURACD   , ")
            strSQL.Append("    A.CODE     , ")
            strSQL.Append("    LPAD(A.TANCD,2,'0') AS TANCD, ")
            strSQL.Append("    A.TANNM    , ")
            strSQL.Append("    A.RENTEL1  , ")
            strSQL.Append("    A.RENTEL2  , ")
            strSQL.Append("    A.FAXNO    , ")
            strSQL.Append("    A.DISP_NO  , ")
            strSQL.Append("    A.BIKO     , ")
            strSQL.Append("    A.ADD_DATE , ")
            strSQL.Append("    A.EDT_DATE , ")
            strSQL.Append("    A.TIME     , ")
            strSQL.Append("    B.HAN_CD, ")
            strSQL.Append("    B.JAS_NAME, ")
            strSQL.Append("    B.JAS_KANA, ")
            strSQL.Append("    B.JA_CD, ")
            strSQL.Append("    B.JA_NAME, ")
            strSQL.Append("    B.JA_KANA, ")
            strSQL.Append("    B.TEL_REN1, ")
            strSQL.Append("    B.TEL_FAX1, ")
            strSQL.Append("    B.HAN_KETA, ")
            strSQL.Append("    B.JA_KETA, ")
            strSQL.Append("    C.CLI_NAME, ")
            strSQL.Append(" �@ A.USER_CD_FROM, ")
            strSQL.Append("    A.USER_CD_TO, ")
            strSQL.Append("    A.RENTEL3, ")
            strSQL.Append("    A.AUTO_FAXNO, ")
            strSQL.Append("    A.SPOT_MAIL,      ")
            strSQL.Append("    A.MAIL_PASS,    ")
            strSQL.Append("    A.AUTO_FAXNM,     ")
            strSQL.Append("    A.AUTO_MAIL,     ")
            strSQL.Append("    A.AUTO_MAIL_PASS, ")
            strSQL.Append("    A.AUTO_FAXNO,     ")
            strSQL.Append("    A.AUTO_KBN,       ")
            strSQL.Append("    A.AUTO_ZERO_FLG, ")
            strSQL.Append("    A.FAXKURAKBN,     ")
            strSQL.Append("    A.FAXKBN,         ")
            strSQL.Append("    A.GUIDELINE,      ")
            strSQL.Append("    '02' AS NO, ")   'M05_TANTO�Ƌ��
            strSQL.Append("    '02' AS NO2 ")   '�N���C�A���g�݂̂̓o�^�����
            strSQL.Append("FROM ")
            strSQL.Append("    M05_TANTO2 A, ")
            strSQL.Append("    HN2MAS B, ")
            strSQL.Append("    CLIMAS C ")
            strSQL.Append("WHERE ")
            strSQL.Append("        B.CLI_CD (+) = A.KURACD ")
            strSQL.Append("    AND B.HAN_CD (+) = A.CODE ")
            strSQL.Append("    AND C.CLI_CD (+) = A.KURACD ")
            strSQL.Append("    AND A.KBN = '3'  ")
            strSQL.Append(strWHE) '�����ǉ�
            strSQL.Append("ORDER BY ")
            strSQL.Append("    KBN, ")
            strSQL.Append("    NO2, ")
            strSQL.Append("    KURACD, ")
            strSQL.Append("    CODE, ")
            strSQL.Append("    NO, ")
            strSQL.Append("    USER_CD_TO, ")
            strSQL.Append("    USER_CD_FROM, ")
            strSQL.Append("    TANCD ")
            ' ������ 2013/07/05 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
        End If

        Return strSQL.ToString

    End Function


    Private Function fncSearchFile(ByVal KURACD As String, ByVal CODE As String, ByVal USER_CD_FROM As String) As String()

        Dim Res() As String = {"", ""}
        Dim searchPattern As String
        Dim folder As String
        Dim buf As String

        folder = ConfigurationSettings.AppSettings("JA_TAN_MST_PATH")

        If Trim(USER_CD_FROM) <> "" Then
            searchPattern = KURACD.Trim & "_" & CODE.Trim & "_" & USER_CD_FROM.Trim & "_"
        Else
            searchPattern = KURACD.Trim & "_" & CODE.Trim & "_" & "X" & "_"
        End If

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

End Class
