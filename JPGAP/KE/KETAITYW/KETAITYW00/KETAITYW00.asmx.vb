'******************************************************************************
' �Ď��Ή��o��
' PGID: KETAISYW00.asmx.vb
'******************************************************************************
'�ύX����
' 2008/11/27 T.Watabe �Ď��R�[�h�̕K�{���O��
' 2009/01/23 T.Watabe �x��R�[�h�̕\���������Ă����_���C��
' 2009/03/24 T.Watabe �Ď������S���ҁA�o����Ў�t�ҁA�o����Џo���҂̕\����ǉ�
' 2011/05/17 T.Watabe FAX�s�v��FAX�ײ�ĕs�v�𒠕[�ɏo�͒ǉ�
' 2014/12/09 H.Hosoda �Ď����P2014 ��13

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KETAISYW00/Service1")> _
Public Class KETAISYW00
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
    '*�@�T�@�v:���v�ƍX�V�E�폜�ꗗ�̏o�͂��s���܂�
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    '2014/12/10 H.Hosoda mod �Ď����P2014 ��13 ������ǉ�
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKANSCD As String, _
    '                                    ByVal pstrTFKICD As String, _
    '                                    ByVal pstrStkbn1 As String, _
    '                                    ByVal pstrStkbn2 As String, _
    '                                    ByVal pstrPgkbn1 As String, _
    '                                    ByVal pstrPgkbn2 As String, _
    '                                    ByVal pstrPgkbn3 As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKURACDFrom As String, _
    '                                    ByVal pstrKURACDTo As String, _
    '                                    ByVal pstrJACDFrom As String, _
    '                                    ByVal pstrJACDTo As String _
    '                                    ) As String
    <WebMethod()> Public Function mExcel( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKANSCD As String, _
                                        ByVal pstrTFKICD As String, _
                                        ByVal pstrStkbn1 As String, _
                                        ByVal pstrStkbn2 As String, _
                                        ByVal pstrPgkbn1 As String, _
                                        ByVal pstrPgkbn2 As String, _
                                        ByVal pstrPgkbn3 As String, _
                                        ByVal pstrTrgFrom As String, _
                                        ByVal pstrTrgTo As String, _
                                        ByVal pstrKURACDFrom As String, _
                                        ByVal pstrKURACDTo As String, _
                                        ByVal pstrJACDFrom As String, _
                                        ByVal pstrJACDTo As String, _
                                        ByVal pstrHANGRPFrom As String, _
                                        ByVal pstrHANGRPTo As String, _
                                        ByVal pstrOUTKBN As String, _
                                        ByVal pstrKIKANKBN As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        'Dim intGYOSU As Integer = 5                     '���s������s��
        'Dim intGyoMax As Integer = CInt(pdecPageMax)    '�ő�s��
        Dim intGyoMax As Integer = 65535                '�ő�s��
        Dim ExcelC As New CExcel                        'Excel�N���X
        Dim compressC As New CCompress                  '���k�N���X
        Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
        Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
        Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim strHedInfo As String                        '�w�b�_�[���i���o�����j
        Dim intPrntRow As Integer = 72

        Dim strTmp() As String

        Dim i As Integer ' 2011/05/17 T.Watabe add


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
            '2014/12/10 H.Hosoda mod �Ď����P2014 ��13 ������ǉ�
            'strSQL.Append(fncMakeSelect(pstrKANSCD, _
            '                            pstrTFKICD, _
            '                            pstrStkbn1, _
            '                            pstrStkbn2, _
            '                            pstrPgkbn1, _
            '                            pstrPgkbn2, _
            '                            pstrPgkbn3, _
            '                            pstrTrgFrom, _
            '                            pstrTrgTo, _
            '                            pstrKURACDFrom, _
            '                            pstrKURACDTo, _
            '                            pstrJACDFrom, _
            '                            pstrJACDTo))
            strSQL.Append(fncMakeSelect(pstrKANSCD, _
                                        pstrTFKICD, _
                                        pstrStkbn1, _
                                        pstrStkbn2, _
                                        pstrPgkbn1, _
                                        pstrPgkbn2, _
                                        pstrPgkbn3, _
                                        pstrTrgFrom, _
                                        pstrTrgTo, _
                                        pstrKURACDFrom, _
                                        pstrKURACDTo, _
                                        pstrJACDFrom, _
                                        pstrJACDTo, _
                                        pstrHANGRPFrom, _
                                        pstrHANGRPTo, _
                                        pstrOUTKBN, _
                                        pstrKIKANKBN))

            cdb.pSQL = strSQL.ToString

            '�p�����[�^�Z�b�g
            '�Ď��Z���^�[�R�[�h
            If pstrKANSCD <> "" Then ' 2008/11/27 T.Watabe add
                cdb.pSQLParamStr("KANSCD") = pstrKANSCD
            End If
            '�Ď��Z���^�[�R�[�h
            If pstrKURACDFrom <> "" Then ' 2008/11/27 T.Watabe add
                cdb.pSQLParamStr("KURACD_FROM") = pstrKURACDFrom
            End If
            If pstrKURACDTo <> "" Then ' 2008/11/27 T.Watabe add
                cdb.pSQLParamStr("KURACD_TO") = pstrKURACDTo
            End If
            '�i�`�R�[�h ' @
            If pstrJACDFrom <> "" Then
                cdb.pSQLParamStr("JACD_FROM") = pstrJACDFrom
            End If
            If pstrJACDTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJACDTo
            End If
            '�̔����Ǝ҃O���[�v�R�[�h 2014/12/12 H.Hosoda add �Ď����P2014 ��13
            If pstrHANGRPFrom <> "" Then
                cdb.pSQLParamStr("HANGRP_FROM") = pstrHANGRPFrom
            End If
            If pstrHANGRPTo <> "" Then
                cdb.pSQLParamStr("HANGRP_TO") = pstrHANGRPTo
            End If

            '�Ή��������܂��͎�M��
            cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo          '�Ή�������(To)�܂��͎�M��(To)

            '�����敪
            If pstrStkbn1.Length = 0 And pstrStkbn2.Length = 0 Then
                '�����Ȃ�
            Else
                '��������
                If pstrStkbn1.Length <> 0 And pstrStkbn2.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrStkbn1
                    cdb.pSQLParamStr("HATKBN2") = pstrStkbn2
                ElseIf pstrStkbn1.Length <> 0 And pstrStkbn2.Length = 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrStkbn1
                ElseIf pstrStkbn1.Length = 0 And pstrStkbn2.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN2") = pstrStkbn2
                Else
                End If
            End If

            '�Ή��敪
            If pstrPgkbn1.Length = 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length = 0 Then
                '�����Ȃ�
            Else
                '��������
                '�S������
                If pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                    cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
                    cdb.pSQLParamStr("TAIOKBN3") = pstrPgkbn3

                    '�����
                ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
                ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN3") = pstrPgkbn3

                    '�����
                ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                    cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
                ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrPgkbn1
                    cdb.pSQLParamStr("TAIOKBN3") = pstrPgkbn3
                ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrPgkbn2
                    cdb.pSQLParamStr("TAIOKBN3") = pstrPgkbn3
                Else
                End If
            End If

            '���A�Ή���
            If pstrTFKICD.Length > 0 Then cdb.pSQLParamStr("TFKICD") = pstrTFKICD

            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                'ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
                '    Return "DATAMAX"    '�f�[�^���ő�s���𒴂��鎖�������������Ԃ�
            End If

            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            ExcelC.pKencd = "00"                '�N���C�A���g�R�[�h���Z�b�g
            ExcelC.pSessionID = pstrSessionID   '�Z�b�V����ID
            'ExcelC.pRepoID = "KETAISYX00"       '���[ID 2007/12/11 T.Watabe edit 00�ȉ��Ƀt�H���_�����悤�ɕύX
            ExcelC.pRepoID = "KETAISYW00"       '���[ID
            ExcelC.mOpen()                      '�t�@�C���I�[�v��

            ExcelC.pTitle = "�x��o��"                        '�^�C�g��
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '�쐬��
            'ExcelC.pScale = 93                                      '�k���g�嗦(%)
            ExcelC.pScale = 70                                      '�k���g�嗦(%)

            '�������
            'ExcelC.pLandScape = False ' true:��
            ExcelC.pLandScape = True ' true:��
            '�]��
            ExcelC.pMarginTop = 2D
            ExcelC.pMarginBottom = 0.6D
            ExcelC.pMarginLeft = 1.5D
            ExcelC.pMarginRight = 1D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 1.3D

            '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
            'ExcelC.mHeader(intGYOSU, ds.Tables(0).Rows.Count, 5)
            'ExcelC.mHeader(40, ds.Tables(0).Rows.Count, 1)' 2011/05/17 T.Watabe edit ���y�[�W�ݒ�Ȃ��ɕύX
            ExcelC.mHeader(-1, ds.Tables(0).Rows.Count, 1)

            ''�������
            'ExcelC.pLandScape = False
            ''�]��
            'ExcelC.pMarginTop = 2D
            'ExcelC.pMarginBottom = 0.6D
            'ExcelC.pMarginLeft = 2D
            'ExcelC.pMarginRight = 1.1D
            'ExcelC.pMarginHeader = 1.3D
            'ExcelC.pMarginFooter = 1.3D

            '�w�b�_�s
            ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(2) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(3) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(4) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(5) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(6) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(7) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(8) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(9) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(18) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(19) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(20) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(21) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(22) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(23) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(24) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(25) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(26) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(27) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(28) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(31) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(32) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(33) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(34) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(35) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/10/28 T.Ono add �Ď����P2013��8
            ExcelC.pCellStyle(36) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(37) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(38) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"  2013/08/27 T.Ono del �Ď����P2013��8
            'ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"  2013/08/27 T.Ono del �Ď����P2013��8
            ExcelC.pCellStyle(39) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(40) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(41) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(42) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add dell
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add dell
            ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add
            ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13 START
            'ExcelC.pCellStyle(54) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13 END
            ExcelC.pCellStyle(55) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add �Ď����P2014 ��13
            ExcelC.pCellStyle(56) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add �Ď����P2014 ��13
            ExcelC.pCellStyle(57) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add �Ď����P2014 ��13
            ExcelC.pCellStyle(58) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2015/12/10 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellStyle(58) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add �Ď����P2014 ��13
            ExcelC.pCellStyle(59) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2015/12/10 H.Mori mod �Ď����P2015 ��10 �ԍ���58��59
            'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2008/11/11 T.Watabe edit
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"

            'ExcelC.pCellVal(1) = Convert.ToString("�Ď��Z���^�[�R�[�h") ' 2008/11/11 T.Watabe edit
            'ExcelC.pCellVal(2) = Convert.ToString("�����ԍ�")
            'ExcelC.pCellVal(3) = Convert.ToString("������")
            'ExcelC.pCellVal(4) = Convert.ToString("��������")
            'ExcelC.pCellVal(5) = Convert.ToString("�Ή���M��")
            'ExcelC.pCellVal(6) = Convert.ToString("�Ή�����")
            'ExcelC.pCellVal(7) = Convert.ToString("�x��P�R�[�h")
            'ExcelC.pCellVal(8) = Convert.ToString("�x��P���b�Z�[�W")
            'ExcelC.pCellVal(9) = Convert.ToString("�x��Q�R�[�h")
            'ExcelC.pCellVal(10) = Convert.ToString("�x��Q���b�Z�[�W")
            'ExcelC.pCellVal(11) = Convert.ToString("�x��R�R�[�h")
            'ExcelC.pCellVal(12) = Convert.ToString("�x��R���b�Z�[�W")
            'ExcelC.pCellVal(13) = Convert.ToString("�x��S�R�[�h")
            'ExcelC.pCellVal(14) = Convert.ToString("�x��S���b�Z�[�W")
            'ExcelC.pCellVal(15) = Convert.ToString("�x��T�R�[�h")
            'ExcelC.pCellVal(16) = Convert.ToString("�x��T���b�Z�[�W")
            'ExcelC.pCellVal(17) = Convert.ToString("�x��U�R�[�h")
            'ExcelC.pCellVal(18) = Convert.ToString("�x��U���b�Z�[�W")
            'ExcelC.pCellVal(19) = Convert.ToString("�S�_�x���R�[�h")
            'ExcelC.pCellVal(20) = Convert.ToString("�N���C�A���g�R�[�h")
            'ExcelC.pCellVal(21) = Convert.ToString("����")
            'ExcelC.pCellVal(22) = Convert.ToString("�i�`�R�[�h")
            'ExcelC.pCellVal(23) = Convert.ToString("�i�`��")
            'ExcelC.pCellVal(24) = Convert.ToString("�i�`�x���R�[�h")
            'ExcelC.pCellVal(25) = Convert.ToString("�i�`�x����")
            'ExcelC.pCellVal(26) = Convert.ToString("���q�l�R�[�h")
            'ExcelC.pCellVal(27) = Convert.ToString("���q�l��")
            'ExcelC.pCellVal(28) = Convert.ToString("�d�b�ԍ��s�O�P")
            'ExcelC.pCellVal(29) = Convert.ToString("�d�b�ԍ��s�O�Q")
            'ExcelC.pCellVal(30) = Convert.ToString("�A����d�b")
            'ExcelC.pCellVal(31) = Convert.ToString("�����d�b�ԍ�")
            'ExcelC.pCellVal(32) = Convert.ToString("�Z��")
            'ExcelC.pCellVal(33) = Convert.ToString("�m�b�t�ڑ�")
            'ExcelC.pCellVal(34) = Convert.ToString("�����敪")
            'ExcelC.pCellVal(35) = Convert.ToString("�����敪�E���e")
            'ExcelC.pCellVal(36) = Convert.ToString("�Ή��敪")
            'ExcelC.pCellVal(37) = Convert.ToString("�Ή��敪�E���e")
            'ExcelC.pCellVal(38) = Convert.ToString("�����敪")
            'ExcelC.pCellVal(39) = Convert.ToString("�����敪�E���e")
            'ExcelC.pCellVal(40) = Convert.ToString("�Ή�������")
            'ExcelC.pCellVal(41) = Convert.ToString("�Ή���������")
            'ExcelC.pCellVal(42) = Convert.ToString("�d�b�A��")
            'ExcelC.pCellVal(43) = Convert.ToString("�d�b�A���E���e")
            'ExcelC.pCellVal(44) = Convert.ToString("���A�Ή���")
            'ExcelC.pCellVal(45) = Convert.ToString("���A�Ή��󋵁E���e")
            'ExcelC.pCellVal(46) = Convert.ToString("���A���상��")
            'ExcelC.pCellVal(47) = Convert.ToString("�d�b�Ή������P")
            'ExcelC.pCellVal(48) = Convert.ToString("�d�b�Ή������Q")
            'ExcelC.pCellVal(49) = Convert.ToString("���o�^�e�k�f")
            'ExcelC.pCellVal(50) = Convert.ToString("�K�X���")
            'ExcelC.pCellVal(51) = Convert.ToString("�K�X���E���e")
            'ExcelC.pCellVal(52) = Convert.ToString("�쓮����")
            'ExcelC.pCellVal(53) = Convert.ToString("�쓮�����E���e")

            '2011/05/17 T.Watabe edit
            If False Then
                'ExcelC.pCellVal(1) = Convert.ToString("�Ή���M��")
                'ExcelC.pCellVal(2) = Convert.ToString("�Ή�����")
                'ExcelC.pCellVal(3) = Convert.ToString("�x��P")
                'ExcelC.pCellVal(4) = Convert.ToString("�x��Q")
                'ExcelC.pCellVal(5) = Convert.ToString("�x��R")
                'ExcelC.pCellVal(6) = Convert.ToString("�x��S")
                'ExcelC.pCellVal(7) = Convert.ToString("�x��T")
                'ExcelC.pCellVal(8) = Convert.ToString("�x��U")
                'ExcelC.pCellVal(9) = Convert.ToString("�w�j�l")
                'ExcelC.pCellVal(10) = Convert.ToString("�N���C�A���g�R�[�h")
                'ExcelC.pCellVal(11) = Convert.ToString("����")
                'ExcelC.pCellVal(12) = Convert.ToString("�i�`�x���R�[�h")
                'ExcelC.pCellVal(13) = Convert.ToString("�i�`�x����")
                'ExcelC.pCellVal(14) = Convert.ToString("���q�l�R�[�h")
                'ExcelC.pCellVal(15) = Convert.ToString("���q�l��")
                'ExcelC.pCellVal(16) = Convert.ToString("�A����d�b")
                'ExcelC.pCellVal(17) = Convert.ToString("�Z��")
                'ExcelC.pCellVal(18) = Convert.ToString("�����敪�E���e")
                'ExcelC.pCellVal(19) = Convert.ToString("�Ή��敪�E���e")
                'ExcelC.pCellVal(20) = Convert.ToString("�����敪�E���e")
                ''ExcelC.pCellVal(21) = Convert.ToString("�Ή�������") ' 2010/03/24 T.Watabe edit
                ''ExcelC.pCellVal(22) = Convert.ToString("�Ή���������")
                ''ExcelC.pCellVal(23) = Convert.ToString("�d�b�A���E���e")
                ''ExcelC.pCellVal(24) = Convert.ToString("���A�Ή��󋵁E���e")
                ''ExcelC.pCellVal(25) = Convert.ToString("�d�b�Ή������P")
                ''ExcelC.pCellVal(26) = Convert.ToString("�d�b�Ή������Q")
                ''ExcelC.pCellVal(27) = Convert.ToString("�d�b�Ή������R")
                ''ExcelC.pCellVal(28) = Convert.ToString("�K�X���E���e")
                ''ExcelC.pCellVal(29) = Convert.ToString("�쓮�����E���e")
                ''ExcelC.pCellVal(30) = Convert.ToString("�o���v����")
                ''ExcelC.pCellVal(31) = Convert.ToString("�o���v������")
                ''ExcelC.pCellVal(32) = Convert.ToString("�o����Ж�")
                ''ExcelC.pCellVal(33) = Convert.ToString("�o����")
                ''ExcelC.pCellVal(34) = Convert.ToString("�o������")
                ''ExcelC.pCellVal(35) = Convert.ToString("������")
                ''ExcelC.pCellVal(36) = Convert.ToString("��������")
                ''ExcelC.pCellVal(37) = Convert.ToString("�Ή����e�P")
                ''ExcelC.pCellVal(38) = Convert.ToString("�Ή����e�Q")
                ''ExcelC.pCellVal(39) = Convert.ToString("�Ή����e�R")
                ''ExcelC.pCellVal(40) = Convert.ToString("���A����")
                ''ExcelC.pCellVal(41) = Convert.ToString("�[�u�I����")
                ''ExcelC.pCellVal(42) = Convert.ToString("�[�u�I������")
                'ExcelC.pCellVal(21) = Convert.ToString("�Ď������S����") ' 2010/03/24 T.Watabe add
                'ExcelC.pCellVal(22) = Convert.ToString("�Ή�������")
                'ExcelC.pCellVal(23) = Convert.ToString("�Ή���������")
                'ExcelC.pCellVal(24) = Convert.ToString("�d�b�A���E���e")
                'ExcelC.pCellVal(25) = Convert.ToString("���A�Ή��󋵁E���e")
                'ExcelC.pCellVal(26) = Convert.ToString("�d�b�Ή������P")
                'ExcelC.pCellVal(27) = Convert.ToString("�d�b�Ή������Q")
                'ExcelC.pCellVal(28) = Convert.ToString("�d�b�Ή������R")
                'ExcelC.pCellVal(29) = Convert.ToString("�K�X���E���e")
                'ExcelC.pCellVal(30) = Convert.ToString("�쓮�����E���e")
                'ExcelC.pCellVal(31) = Convert.ToString("�o���v����")
                'ExcelC.pCellVal(32) = Convert.ToString("�o���v������")
                'ExcelC.pCellVal(33) = Convert.ToString("�o����Ж�")
                'ExcelC.pCellVal(34) = Convert.ToString("�o����t��") ' 2010/03/24 T.Watabe add
                'ExcelC.pCellVal(35) = Convert.ToString("�o���Ή���") ' 2010/03/24 T.Watabe add
                'ExcelC.pCellVal(36) = Convert.ToString("�o����")
                'ExcelC.pCellVal(37) = Convert.ToString("�o������")
                'ExcelC.pCellVal(38) = Convert.ToString("������")
                'ExcelC.pCellVal(39) = Convert.ToString("��������")
                'ExcelC.pCellVal(40) = Convert.ToString("�Ή����e�P")
                'ExcelC.pCellVal(41) = Convert.ToString("�Ή����e�Q")
                'ExcelC.pCellVal(42) = Convert.ToString("�Ή����e�R")
                'ExcelC.pCellVal(43) = Convert.ToString("���A����")
                'ExcelC.pCellVal(44) = Convert.ToString("�[�u�I����")
                'ExcelC.pCellVal(45) = Convert.ToString("�[�u�I������")
            End If
            i = 1
            ExcelC.pCellVal(i) = Convert.ToString("FAXJA��") : i += 1 ' 2011/05/17 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("FAX�ב�") : i += 1 ' 2011/05/17 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�Ή���M��") : i += 1 2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�Ή�����") : i += 1   2013/08/27 T.Ono mod �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("��M��") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("��M����") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�x������") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("���ʋ敪") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("�x��P") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�x��Q") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�x��R") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�x��S") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�x��T") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�x��U") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("���q�lFLG") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("�w�j�l") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�N���C�A���g�R�[�h") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("����") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�i�`�R�[�h") : i += 1           ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("�i�`��") : i += 1               ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("�̔����Ǝ҃R�[�h") : i += 1     ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("�̔����ƎҖ�") : i += 1         ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("�i�`�x���R�[�h") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�i�`�x����") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("NCU�ڑ�(���)") : i += 1    ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("�ڑ��敪") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("���q�l�R�[�h") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("���q�l��") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("�A����d�b") : i += 1 ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("�A����") : i += 1
            ' 2014/12/11 H.Hosoda mod �Ď����P2014 ��13 START
            'ExcelC.pCellVal(i) = Convert.ToString("�����d�b�ԍ�") : i += 1       ' 2013/08/27 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("�����ԍ�") : i += 1
            ' 2014/12/11 H.Hosoda mod �Ď����P2014 ��13 END    
            ExcelC.pCellVal(i) = Convert.ToString("�Z��") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�̔��敪") : i += 1 ' 2015/12/10 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellVal(i) = Convert.ToString("�����敪�E���e") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�Ή��敪�E���e") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�����敪�E���e") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�Ή��敪") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�Ď������S����") : i += 1 ' 2010/03/24 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("�Ή�������") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�Ή���������") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�A������") : i += 1 '2013/10/28 T.Ono add �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�d�b�A���E���e") : i += 1     2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("���A�Ή��󋵁E���e") : i += 1 2013/08/27 T.Ono mod �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("�d�b�A��") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("���A�Ή���") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("�d�b�Ή������P") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("�Ď��Ή����e") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1         '2014/12/09 H.Hosoda add �Ď����P2014 ��13
            'ExcelC.pCellVal(i) = Convert.ToString("�d�b�Ή������Q") : i += 1  2013/08/27 T.Ono del �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�d�b�Ή������R") : i += 1  2013/08/27 T.Ono del �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�K�X���E���e") : i += 1 2013/10/28 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�쓮�����E���e") : i += 1 2013/10/28 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�K�X���") : i += 1  ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("�������") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�쓮����") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("�o���v����") : i += 1   ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            'ExcelC.pCellVal(i) = Convert.ToString("�o���v������") : i += 1 ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("�o���˗���") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�o���˗�����") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�o����Ж�") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�o����t��") : i += 1 ' 2010/03/24 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("�o���Ή���") : i += 1 ' 2010/03/24 T.Watabe add
            ExcelC.pCellVal(i) = Convert.ToString("�o����") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�o������") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1   ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            'ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1 ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("�Ή����e�P") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("�o���Ή����e") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("�Ή����e�Q") : i += 1  2013/08/27 T.Ono del �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�Ή����e�R") : i += 1  2013/08/27 T.Ono del �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString("���A����") : i += 1
            'ExcelC.pCellVal(i) = Convert.ToString("�[�u�I����") : i += 1   ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            'ExcelC.pCellVal(i) = Convert.ToString("�[�u�I������") : i += 1 ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            ExcelC.pCellVal(i) = Convert.ToString("����������") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("������������") : i += 1
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������

            ''���׃f�[�^�o��
            Dim iCnt As Integer
            'AP�T�[�o����̖߂�l�����[�v����
            '���׃f�[�^�o��
            'For Each dr In ds.Tables(0).Rows
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)
                '���׍���
                ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(2) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(3) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(4) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(5) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(6) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(7) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(8) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(9) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(18) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(19) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(20) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(21) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(22) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(23) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(24) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(25) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(26) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(27) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(28) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(31) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(32) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(33) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(34) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/10/28 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(35) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(36) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(37) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del �Ď����P2013��8
                'ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del �Ď����P2013��8
                ExcelC.pCellStyle(38) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(39) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(40) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(41) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(42) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del �Ď����P2013��8
                'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add  2013/08/27 T.Ono del �Ď����P2013��8
                ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add
                ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add
                ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2011/05/17 T.Watabe add
                '2014/12/09 H.Hosoda add �Ď����P2014 ��13 START
                'ExcelC.pCellStyle(53) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" ' 2011/05/17 T.Watabe add
                ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                '2014/12/09 H.Hosoda add �Ď����P2014 ��13 END
                ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
                ExcelC.pCellStyle(55) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
                ExcelC.pCellStyle(56) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
                ExcelC.pCellStyle(57) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
                ExcelC.pCellStyle(58) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2015/12/10 H.Mori add �Ď����P2015 ��10
                'ExcelC.pCellStyle(58) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
                ExcelC.pCellStyle(59) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2015/12/10 H.Mori mod �Ď����P2015 ��10 
                'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2008/11/11 T.Watabe edit
                'ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                'ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"

                ' 2011/05/17 T.Watabe edit
                If False Then
                    'ExcelC.pCellVal(1) = Convert.ToString(dr.Item("KANSCD")) ' 2008/11/11 T.Watabe edit
                    'ExcelC.pCellVal(2) = Convert.ToString(dr.Item("SYONO"))
                    'ExcelC.pCellVal(3) = Convert.ToString(dr.Item("HATYMD"))
                    'ExcelC.pCellVal(4) = Convert.ToString(dr.Item("HATTIME"))
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("JUYMD"))
                    'ExcelC.pCellVal(6) = Convert.ToString(dr.Item("JUTIME"))
                    'ExcelC.pCellVal(7) = Convert.ToString(dr.Item("KMCD1"))
                    'ExcelC.pCellVal(8) = Convert.ToString(dr.Item("KMNM1"))
                    'ExcelC.pCellVal(9) = Convert.ToString(dr.Item("KMCD2"))
                    'ExcelC.pCellVal(10) = Convert.ToString(dr.Item("KMNM2"))
                    'ExcelC.pCellVal(11) = Convert.ToString(dr.Item("KMCD3"))
                    'ExcelC.pCellVal(12) = Convert.ToString(dr.Item("KMNM3"))
                    'ExcelC.pCellVal(13) = Convert.ToString(dr.Item("KMCD4"))
                    'ExcelC.pCellVal(14) = Convert.ToString(dr.Item("KMNM4"))
                    'ExcelC.pCellVal(15) = Convert.ToString(dr.Item("KMCD5"))
                    'ExcelC.pCellVal(16) = Convert.ToString(dr.Item("KMNM5"))
                    'ExcelC.pCellVal(17) = Convert.ToString(dr.Item("KMCD6"))
                    'ExcelC.pCellVal(18) = Convert.ToString(dr.Item("KMNM6"))
                    'ExcelC.pCellVal(19) = Convert.ToString(dr.Item("ZSISYO"))
                    'ExcelC.pCellVal(20) = Convert.ToString(dr.Item("KURACD"))
                    'ExcelC.pCellVal(21) = Convert.ToString(dr.Item("KENNM"))
                    'ExcelC.pCellVal(22) = Convert.ToString(dr.Item("JACD"))
                    'ExcelC.pCellVal(23) = Convert.ToString(dr.Item("JANM"))
                    'ExcelC.pCellVal(24) = Convert.ToString(dr.Item("ACBCD"))
                    'ExcelC.pCellVal(25) = Convert.ToString(dr.Item("ACBNM"))
                    'ExcelC.pCellVal(26) = Convert.ToString(dr.Item("USER_CD"))
                    'ExcelC.pCellVal(27) = Convert.ToString(dr.Item("JUSYONM"))
                    'ExcelC.pCellVal(28) = Convert.ToString(dr.Item("JUTEL1"))
                    'ExcelC.pCellVal(29) = Convert.ToString(dr.Item("JUTEL2"))
                    'ExcelC.pCellVal(30) = Convert.ToString(dr.Item("RENTEL"))
                    'ExcelC.pCellVal(31) = Convert.ToString(dr.Item("KTELNO"))
                    'ExcelC.pCellVal(32) = Convert.ToString(dr.Item("ADDR"))
                    'ExcelC.pCellVal(33) = Convert.ToString(dr.Item("NCU_SET"))
                    'ExcelC.pCellVal(34) = Convert.ToString(dr.Item("HATKBN"))
                    'ExcelC.pCellVal(35) = Convert.ToString(dr.Item("HATKBN_NAI"))
                    'ExcelC.pCellVal(36) = Convert.ToString(dr.Item("TAIOKBN"))
                    'ExcelC.pCellVal(37) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    'ExcelC.pCellVal(38) = Convert.ToString(dr.Item("TMSKB"))
                    'ExcelC.pCellVal(39) = Convert.ToString(dr.Item("TMSKB_NAI"))
                    'ExcelC.pCellVal(40) = Convert.ToString(dr.Item("SYOYMD"))
                    'ExcelC.pCellVal(41) = Convert.ToString(dr.Item("SYOTIME"))
                    'ExcelC.pCellVal(42) = Convert.ToString(dr.Item("TELRCD"))
                    'ExcelC.pCellVal(43) = Convert.ToString(dr.Item("TELRNM"))
                    'ExcelC.pCellVal(44) = Convert.ToString(dr.Item("TFKICD"))
                    'ExcelC.pCellVal(45) = Convert.ToString(dr.Item("TFKINM"))
                    'ExcelC.pCellVal(46) = Convert.ToString(dr.Item("FUK_MEMO"))
                    'ExcelC.pCellVal(47) = Convert.ToString(dr.Item("TEL_MEMO1"))
                    'ExcelC.pCellVal(48) = Convert.ToString(dr.Item("TEL_MEMO2"))
                    'ExcelC.pCellVal(49) = Convert.ToString(dr.Item("MITOKBN"))
                    'ExcelC.pCellVal(50) = Convert.ToString(dr.Item("TKIGCD"))
                    'ExcelC.pCellVal(51) = Convert.ToString(dr.Item("TKIGNM"))
                    'ExcelC.pCellVal(52) = Convert.ToString(dr.Item("TSADCD"))
                    'ExcelC.pCellVal(53) = Convert.ToString(dr.Item("TSADNM"))
                    'ExcelC.pCellVal(54) = "1"
                    'ExcelC.pCellVal(1) = Convert.ToString(dr.Item("JUYMD"))
                    'ExcelC.pCellVal(2) = Convert.ToString(dr.Item("JUTIME"))
                    'ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KMNM1"))
                    'ExcelC.pCellVal(4) = Convert.ToString(dr.Item("KMNM2"))
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KMNM3"))
                    'ExcelC.pCellVal(6) = Convert.ToString(dr.Item("KMNM4"))
                    'ExcelC.pCellVal(7) = Convert.ToString(dr.Item("KMNM5"))
                    'ExcelC.pCellVal(8) = Convert.ToString(dr.Item("KMNM6"))
                    'ExcelC.pCellVal(9) = Convert.ToString(dr.Item("KENSIN"))
                    'ExcelC.pCellVal(10) = Convert.ToString(dr.Item("KURACD"))
                    'ExcelC.pCellVal(11) = Convert.ToString(dr.Item("KENNM"))
                    'ExcelC.pCellVal(12) = Convert.ToString(dr.Item("ACBCD"))
                    'ExcelC.pCellVal(13) = Convert.ToString(dr.Item("ACBNM"))
                    'ExcelC.pCellVal(14) = Convert.ToString(dr.Item("USER_CD"))
                    'ExcelC.pCellVal(15) = Convert.ToString(dr.Item("JUSYONM"))
                    'ExcelC.pCellVal(16) = Convert.ToString(dr.Item("RENTEL"))
                    'ExcelC.pCellVal(17) = Convert.ToString(dr.Item("ADDR"))
                    'ExcelC.pCellVal(18) = Convert.ToString(dr.Item("HATKBN_NAI"))
                    'ExcelC.pCellVal(19) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    'ExcelC.pCellVal(20) = Convert.ToString(dr.Item("TMSKB_NAI"))
                    ''ExcelC.pCellVal(21) = Convert.ToString(dr.Item("SYOYMD")) ' 2008/11/11 T.Watabe edit
                    ''ExcelC.pCellVal(22) = Convert.ToString(dr.Item("SYOTIME"))
                    ''ExcelC.pCellVal(23) = Convert.ToString(dr.Item("TELRNM"))
                    ''ExcelC.pCellVal(24) = Convert.ToString(dr.Item("TFKINM"))
                    ''ExcelC.pCellVal(25) = Convert.ToString(dr.Item("TEL_MEMO1"))
                    ''ExcelC.pCellVal(26) = Convert.ToString(dr.Item("TEL_MEMO2"))
                    ''ExcelC.pCellVal(27) = Convert.ToString(dr.Item("FUK_MEMO"))
                    ''ExcelC.pCellVal(28) = Convert.ToString(dr.Item("TKIGNM"))
                    ''ExcelC.pCellVal(29) = Convert.ToString(dr.Item("TSADNM"))
                    ''ExcelC.pCellVal(30) = Convert.ToString(dr.Item("SIJIYMD"))
                    ''ExcelC.pCellVal(31) = Convert.ToString(dr.Item("SIJITIME"))
                    ''ExcelC.pCellVal(32) = Convert.ToString(dr.Item("STD"))
                    ''ExcelC.pCellVal(33) = Convert.ToString(dr.Item("SDYMD"))
                    ''ExcelC.pCellVal(34) = Convert.ToString(dr.Item("SDTIME"))
                    ''ExcelC.pCellVal(35) = Convert.ToString(dr.Item("TYAKYMD"))
                    ''ExcelC.pCellVal(36) = Convert.ToString(dr.Item("TYAKTIME"))
                    ''ExcelC.pCellVal(37) = Convert.ToString(dr.Item("SDTBIK2"))
                    ''ExcelC.pCellVal(38) = Convert.ToString(dr.Item("SNTTOKKI"))
                    ''ExcelC.pCellVal(39) = Convert.ToString(dr.Item("SDTBIK3"))
                    ''ExcelC.pCellVal(40) = Convert.ToString(dr.Item("FKINM"))
                    ''ExcelC.pCellVal(41) = Convert.ToString(dr.Item("SYOKANYMD"))
                    ''ExcelC.pCellVal(42) = Convert.ToString(dr.Item("SYOKANTIME"))
                    ''ExcelC.pCellVal(43) = "1"
                    'ExcelC.pCellVal(21) = Convert.ToString(dr.Item("TKTANCD_NM")) ' 2010/03/24 T.Watabe add  [�Ή����]�y�Ď��Z���^�[�S���Җ��z 
                    'ExcelC.pCellVal(22) = Convert.ToString(dr.Item("SYOYMD"))
                    'ExcelC.pCellVal(23) = Convert.ToString(dr.Item("SYOTIME"))
                    'ExcelC.pCellVal(24) = Convert.ToString(dr.Item("TELRNM"))
                    'ExcelC.pCellVal(25) = Convert.ToString(dr.Item("TFKINM"))
                    'ExcelC.pCellVal(26) = Convert.ToString(dr.Item("TEL_MEMO1"))
                    'ExcelC.pCellVal(27) = Convert.ToString(dr.Item("TEL_MEMO2"))
                    'ExcelC.pCellVal(28) = Convert.ToString(dr.Item("FUK_MEMO"))
                    'ExcelC.pCellVal(29) = Convert.ToString(dr.Item("TKIGNM"))
                    'ExcelC.pCellVal(30) = Convert.ToString(dr.Item("TSADNM"))
                    'ExcelC.pCellVal(31) = Convert.ToString(dr.Item("SIJIYMD"))
                    'ExcelC.pCellVal(32) = Convert.ToString(dr.Item("SIJITIME"))
                    'ExcelC.pCellVal(33) = Convert.ToString(dr.Item("STD"))
                    'ExcelC.pCellVal(34) = Convert.ToString(dr.Item("TSTANNM")) ' 2010/03/24 T.Watabe add [�o������]�y��M�Ҏ����z
                    'ExcelC.pCellVal(35) = Convert.ToString(dr.Item("SYUTDTNM")) ' 2010/03/24 T.Watabe add [�o������]�y�o���Ή��ҁz
                    'ExcelC.pCellVal(36) = Convert.ToString(dr.Item("SDYMD"))
                    'ExcelC.pCellVal(37) = Convert.ToString(dr.Item("SDTIME"))
                    'ExcelC.pCellVal(38) = Convert.ToString(dr.Item("TYAKYMD"))
                    'ExcelC.pCellVal(39) = Convert.ToString(dr.Item("TYAKTIME"))
                    'ExcelC.pCellVal(40) = Convert.ToString(dr.Item("SDTBIK2"))
                    'ExcelC.pCellVal(41) = Convert.ToString(dr.Item("SNTTOKKI"))
                    'ExcelC.pCellVal(42) = Convert.ToString(dr.Item("SDTBIK3"))
                    'ExcelC.pCellVal(43) = Convert.ToString(dr.Item("FKINM"))
                    'ExcelC.pCellVal(44) = Convert.ToString(dr.Item("SYOKANYMD"))
                    'ExcelC.pCellVal(45) = Convert.ToString(dr.Item("SYOKANTIME"))
                    'ExcelC.pCellVal(46) = "1"
                End If
                i = 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1 ' FAX�s�v 1:�s�v/2:�K�v
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1 ' �e�`�w�s�v(�ײ���) 1:�s�v/2:�K�v
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATYMD")) : i += 1  ' �������� 2013/08/29 T.Ono add �Ď����P2013��8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATTIME")) : i += 1 ' �������� 2013/08/29 T.Ono add �Ď����P2013��8
                '2013/11/01 T.Ono mod �Ή���ʂ̎�M�������o�͂���悤�ɕύX
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUYMD")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUTIME")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1

                ExcelC.pCellVal(i) = fncSetChien(Convert.ToString(dr.Item("CHIEN"))) : i += 1  ' �x������ 2013/10/28 T.Ono add �Ď����P2013��8

                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1 ' ���ʋ敪 2013/08/29 T.Ono add �Ď����P2013��8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("OYAKU_FLG")) : i += 1 ' ���q�lFLG 2013/08/29 T.Ono add �Ď����P2013��8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KURACD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1      ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���p��]�yJA�R�[�h�z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1      ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���p��]�yJA���z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJICD")) : i += 1   ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���R�[�h���]�y�̔����Ǝ҃R�[�h�z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJINM")) : i += 1   ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���R�[�h���]�y�̔����ƎҖ��z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TUSIN")) : i += 1   ' NSU�ڑ��i��ʁj  2013/08/29 T.Ono add �Ď����P2013��8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM")) : i += 1 ' �ڑ��i�oor�[���j 2013/08/29 T.Ono add �Ď����P2013��8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1

                ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 ' �����d�b�ԍ�     2013/10/28 T.Ono add �Ď����P2013��8

                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBAI_KBN")) : i += 1 ' 2015/12/10 H.Mori add �Ď����P2015 ��10 [���q�l���]�̔��敪
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATKBN_NAI")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1 ' 2010/03/24 T.Watabe add  [�Ή����]�y�Ď��Z���^�[�S���Җ��z 
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITCD")) : i += 1 ' �A������     2013/10/28 T.Ono add �Ď����P2013��8
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TFKINM")) : i += 1
                ' 2013/10/28 T.Ono mod �Ď����P2013��8
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO2")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FUK_MEMO")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAX_REN")) : i += 1 ' 2014/12/10 H.Hosoda add �Ď����P2014 ��13 [�A����]�yFAX�A�����z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSTANNM")) : i += 1 ' 2010/03/24 T.Watabe add [�o������]�y��M�Ҏ����z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYUTDTNM")) : i += 1 ' 2010/03/24 T.Watabe add [�o������]�y�o���Ή��ҁz
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTIME")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKTIME")) : i += 1
                ' 2013/10/28 T.Ono mod �Ď����P2013��8
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SNTTOKKI")) : i += 1
                'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK3")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FKINM")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANYMD")) : i += 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANTIME")) : i += 1
                ExcelC.pCellVal(i) = "1"
                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
            Next

            ExcelC.mWriteLine("")                           '�s���t�@�C���ɏ�������
            ExcelC.mClose()                                 '�t�@�C���N���[�Y

            '���k��t�@�C���̂���t�H���_
            compressC.p_Dir = ExcelC.pDirName
            '���{��t�@�C�����̎w��
            compressC.p_NihongoFileName = "�x��o��.xls"
            '���k���t�@�C����
            compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
            '���k��t�@�C����
            compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
            '2014/01/16 T.Ono mod �Ď����P2013 Excel�𒼐ڊJ���悤�ɕύX�A�t�@�C���t���p�X��Ԃ�
            ''���k���s
            ''compressC.mCompress()
            ''���k�����t�@�C����Base64�G���R�[�h���Ė߂�
            ''.xls�`���ɕύX 2013/12/05 T.Ono mod �Ď����P2013
            ''Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
            'Return FileToStrC.mFileToStr(compressC.p_FileName)
            Return (compressC.p_FileName)

        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�baba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function

    '******************************************************************************
    '*�@�T�@�v:�r�d�k�d�b�s�����쐬
    '*�@���@�l:�Ή��c�a�擾
    '******************************************************************************
    '2014/12/10 H.Hosoda mod �Ď����P2014 ��13 ������ǉ�
    'Public Function fncMakeSelect(ByVal pstrKANSCD As String, _
    '                              ByVal pstrTFKICD As String, _
    '                              ByVal pstrStkbn1 As String, _
    '                              ByVal pstrStkbn2 As String, _
    '                              ByVal pstrPgkbn1 As String, _
    '                              ByVal pstrPgkbn2 As String, _
    '                              ByVal pstrPgkbn3 As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrKURACDFrom As String, _
    '                              ByVal pstrKURACDTo As String, _
    '                              ByVal pstrJACDFrom As String, _
    '                              ByVal pstrJACDTo As String) As String
    Public Function fncMakeSelect(ByVal pstrKANSCD As String, _
                                  ByVal pstrTFKICD As String, _
                                  ByVal pstrStkbn1 As String, _
                                  ByVal pstrStkbn2 As String, _
                                  ByVal pstrPgkbn1 As String, _
                                  ByVal pstrPgkbn2 As String, _
                                  ByVal pstrPgkbn3 As String, _
                                  ByVal pstrTrgFrom As String, _
                                  ByVal pstrTrgTo As String, _
                                  ByVal pstrKURACDFrom As String, _
                                  ByVal pstrKURACDTo As String, _
                                  ByVal pstrJACDFrom As String, _
                                  ByVal pstrJACDTo As String, _
                                  ByVal pstrHANGRPFrom As String, _
                                  ByVal pstrHANGRPTo As String, _
                                  ByVal pstrOUTKBN As String, _
                                  ByVal pstrKIKANKBN As String) As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append("SELECT ")
        'If ind = 1 Then
        '    strSQL.Append("COUNT(*) ")
        'Else
        'strSQL.Append("KANSCD, ") ' 2008/11/11 T.Watabe edit
        'strSQL.Append("SYONO, ")
        'strSQL.Append("HATYMD, ")
        'strSQL.Append("HATTIME, ")
        'strSQL.Append("JUYMD, ")
        'strSQL.Append("JUTIME, ")
        'strSQL.Append("KMCD1, ")
        'strSQL.Append("KMNM1, ")
        'strSQL.Append("KMCD2, ")
        'strSQL.Append("KMNM2, ")
        'strSQL.Append("KMCD3, ")
        'strSQL.Append("KMNM3, ")
        'strSQL.Append("KMCD4, ")
        'strSQL.Append("KMNM4, ")
        'strSQL.Append("KMCD5, ")
        'strSQL.Append("KMNM5, ")
        'strSQL.Append("KMCD6, ")
        'strSQL.Append("KMNM6, ")
        'strSQL.Append("ZSISYO, ")
        'strSQL.Append("KURACD, ")
        'strSQL.Append("KENNM, ")
        'strSQL.Append("JACD, ")
        'strSQL.Append("JANM, ")
        'strSQL.Append("ACBCD, ")
        'strSQL.Append("ACBNM, ")
        'strSQL.Append("USER_CD, ")
        'strSQL.Append("JUSYONM, ")
        'strSQL.Append("JUTEL1, ")
        'strSQL.Append("JUTEL2, ")
        'strSQL.Append("RENTEL, ")
        'strSQL.Append("KTELNO, ")
        'strSQL.Append("ADDR, ")
        'strSQL.Append("NCU_SET, ")
        'strSQL.Append("HATKBN, ")
        'strSQL.Append("HATKBN_NAI, ")
        'strSQL.Append("TAIOKBN, ")
        'strSQL.Append("TAIOKBN_NAI, ")
        'strSQL.Append("TMSKB, ")
        'strSQL.Append("TMSKB_NAI, ")
        'strSQL.Append("SYOYMD, ")
        'strSQL.Append("SYOTIME, ")
        'strSQL.Append("TELRCD, ")
        'strSQL.Append("TELRNM, ")
        'strSQL.Append("TFKICD, ")
        'strSQL.Append("TFKINM, ")
        'strSQL.Append("FUK_MEMO, ")
        'strSQL.Append("TEL_MEMO1, ")
        'strSQL.Append("TEL_MEMO2, ")
        'strSQL.Append("MITOKBN, ")
        'strSQL.Append("TKIGCD, ")
        'strSQL.Append("TKIGNM, ")
        'strSQL.Append("TSADCD, ")
        'strSQL.Append("TSADNM ")
        strSQL.Append("    DECODE(TAI.FAXKBN,     '2', '��', ' ') AS FAXKBN,     ") ' 2011/05/17 T.Watabe add
        strSQL.Append("    DECODE(TAI.FAXKURAKBN, '2', '��', ' ') AS FAXKURAKBN, ") ' 2011/05/17 T.Watabe add
        strSQL.Append("    TAI.NCUHATYMD, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.NCUHATTIME, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        '2013/11/01 T.Ono mod �Ή���ʂ̎�M�������o�͂���悤�ɕύX
        'strSQL.Append("    TAI.JUYMD, ")                                            ' 2008/11/11 T.Watabe edit
        'strSQL.Append("    TAI.JUTIME, ")
        strSQL.Append("    TAI.HATYMD, ")
        strSQL.Append("    TAI.HATTIME, ")
        strSQL.Append("    ROUND((TO_DATE(TAI.HATYMD || SUBSTR(TAI.HATTIME,0,4), 'YYYYMMDDHH24MISS') - TO_DATE(TAI.NCUHATYMD || TAI.NCUHATTIME, 'YYYYMMDDHH24MISS'))  * 1440) AS CHIEN, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.RYURYO, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        '2015/04/09 H.Mori mod �Ď����P2014 ���ނȂ��A���̂���̏ꍇ���\������ START
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD1), NULL, NULL, TAI.KMCD1 || ':' || TAI.KMNM1) AS KMNM1, ") ' 2009/01/23 T.Watabe edit
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD2), NULL, NULL, TAI.KMCD2 || ':' || TAI.KMNM2) AS KMNM2, ")
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD3), NULL, NULL, TAI.KMCD3 || ':' || TAI.KMNM3) AS KMNM3, ")
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD4), NULL, NULL, TAI.KMCD4 || ':' || TAI.KMNM4) AS KMNM4, ")
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD5), NULL, NULL, TAI.KMCD5 || ':' || TAI.KMNM5) AS KMNM5, ")
        'strSQL.Append("    DECODE(RTRIM(TAI.KMCD6), NULL, NULL, TAI.KMCD6 || ':' || TAI.KMNM6) AS KMNM6, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD1) IS NOT NULL AND RTRIM(TAI.KMNM1) IS NOT NULL  THEN TAI.KMCD1 || ':' || TAI.KMNM1 WHEN RTRIM(TAI.KMCD1) IS NOT NULL THEN TAI.KMCD1 WHEN RTRIM(TAI.KMNM1) IS NOT NULL THEN KMNM1 ELSE NULL END KMNM1, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD2) IS NOT NULL AND RTRIM(TAI.KMNM2) IS NOT NULL  THEN TAI.KMCD2 || ':' || TAI.KMNM2 WHEN RTRIM(TAI.KMCD2) IS NOT NULL THEN TAI.KMCD2 WHEN RTRIM(TAI.KMNM2) IS NOT NULL THEN KMNM2 ELSE NULL END KMNM2, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD3) IS NOT NULL AND RTRIM(TAI.KMNM3) IS NOT NULL  THEN TAI.KMCD3 || ':' || TAI.KMNM3 WHEN RTRIM(TAI.KMCD3) IS NOT NULL THEN TAI.KMCD3 WHEN RTRIM(TAI.KMNM3) IS NOT NULL THEN KMNM3 ELSE NULL END KMNM3, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD4) IS NOT NULL AND RTRIM(TAI.KMNM4) IS NOT NULL  THEN TAI.KMCD4 || ':' || TAI.KMNM4 WHEN RTRIM(TAI.KMCD4) IS NOT NULL THEN TAI.KMCD4 WHEN RTRIM(TAI.KMNM4) IS NOT NULL THEN KMNM4 ELSE NULL END KMNM4, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD5) IS NOT NULL AND RTRIM(TAI.KMNM5) IS NOT NULL  THEN TAI.KMCD5 || ':' || TAI.KMNM5 WHEN RTRIM(TAI.KMCD5) IS NOT NULL THEN TAI.KMCD5 WHEN RTRIM(TAI.KMNM5) IS NOT NULL THEN KMNM5 ELSE NULL END KMNM5, ")
        strSQL.Append("    CASE WHEN RTRIM(TAI.KMCD6) IS NOT NULL AND RTRIM(TAI.KMNM6) IS NOT NULL  THEN TAI.KMCD6 || ':' || TAI.KMNM6 WHEN RTRIM(TAI.KMCD6) IS NOT NULL THEN TAI.KMCD6 WHEN RTRIM(TAI.KMNM6) IS NOT NULL THEN KMNM6 ELSE NULL END KMNM6, ")
        '2015/04/09 H.Mori mod �Ď����P2014 ���ނȂ��A���̂���̏ꍇ���\������ END
        strSQL.Append("    DECODE(TAI.UNYO, '0', '0:���J��', '1', '1:�^�p��', '2', '2:�x�~��', NULL) AS OYAKU_FLG, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.KENSIN, ")
        strSQL.Append("    TAI.KURACD, ")
        strSQL.Append("    TAI.KENNM, ")
        strSQL.Append("    TAI.JACD, ")     ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
        strSQL.Append("    TAI.JANM, ")     ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
        strSQL.Append("    TAI.HANJICD, ")  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
        strSQL.Append("    TAI.HANJINM, ")  ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13
        strSQL.Append("    TAI.ACBCD, ")
        strSQL.Append("    TAI.ACBNM, ")
        strSQL.Append("    KOK.TUSIN, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        strSQL.Append("    DECODE(TAI.NCU_SET, '1', '�o����', '2', '�[��', '3', '������', NULL) AS NCU_SETNM, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.USER_CD, ")
        strSQL.Append("    TAI.JUSYONM, ")
        strSQL.Append("    TAI.RENTEL, ")
        strSQL.Append("    TAI.JUTEL1, ") ' 2013/10/28 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.JUTEL2, ") ' 2013/10/28 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.ADDR, ")
        strSQL.Append("    DECODE(TRIM(TAI.HANBAI_KBN), '1', '1:���[�^��', '2', '2:�{���x��', '3', '3:����', '4', '4:���̑�', TAI.HANBAI_KBN) AS HANBAI_KBN, ") ' 2015/12/10 H.Mori add �Ď����P2015 ��10
        '2013/12/05 T.Ono mod �Ď����P2013
        'strSQL.Append("    TAI.HATKBN_NAI, ")
        'strSQL.Append("    TAI.TAIOKBN_NAI, ")
        'strSQL.Append("    TAI.TMSKB_NAI, ")
        strSQL.Append("    DECODE(RTRIM(TAI.HATKBN), NULL, NULL, TAI.HATKBN || ':' || TAI.HATKBN_NAI) AS HATKBN_NAI, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TAIOKBN), NULL, NULL, TAI.TAIOKBN || ':' || TAI.TAIOKBN_NAI) AS TAIOKBN_NAI, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TMSKB), NULL, NULL, TAI.TMSKB || ':' || TAI.TMSKB_NAI) AS TMSKB_NAI, ")
        strSQL.Append("    TAI.SYOYMD, ")
        strSQL.Append("    TAI.SYOTIME, ")
        'strSQL.Append("    TAITCD, ") ' 2013/10/28 T.Ono add �Ď����P2013��8
        'strSQL.Append("    TAITNM, ") ' 2013/10/28 T.Ono add �Ď����P2013��8
        strSQL.Append("    DECODE(RTRIM(TAI.TAITCD), NULL, NULL, TAI.TAITCD || ':' || TAI.TAITNM) AS TAITCD, ") ' 2013/10/28 T.Ono add �Ď����P2013��8
        '2013/12/05 T.Ono mod �Ď����P2013
        'strSQL.Append("    TAI.TELRNM, ")
        'strSQL.Append("    TAI.TFKINM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TELRCD), NULL, NULL, TAI.TELRCD || ':' || TAI.TELRNM) AS TELRNM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TFKICD), NULL, NULL, TAI.TFKICD || ':' || TAI.TFKINM) AS TFKINM, ")
        strSQL.Append("    TAI.TEL_MEMO1, ")
        strSQL.Append("    TAI.TEL_MEMO2, ")
        strSQL.Append("    TAI.FUK_MEMO, ")
        strSQL.Append("    TAI.FAX_REN, ") ' 2014/12/10 H.Hosoda add �Ď����P2014 ��13
        '2013/12/05 T.Ono mod �Ď����P2013
        'strSQL.Append("    TAI.TKIGNM, ")
        'strSQL.Append("    TAI.TSADNM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TKIGCD), NULL, NULL, TAI.TKIGCD || ':' || TAI.TKIGNM) AS TKIGNM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TSADCD), NULL, NULL, TAI.TSADCD || ':' || TAI.TSADNM) AS TSADNM, ")
        strSQL.Append("    TAI.SIJIYMD, ")
        strSQL.Append("    TAI.SIJITIME, ")
        strSQL.Append("    TAI.STD, ")
        strSQL.Append("    TAI.SDYMD, ")
        strSQL.Append("    TAI.SDTIME, ")
        strSQL.Append("    TAI.TYAKYMD, ")
        strSQL.Append("    TAI.TYAKTIME, ")
        strSQL.Append("    TAI.SDTBIK2, ")
        strSQL.Append("    TAI.SNTTOKKI, ")
        strSQL.Append("    TAI.SDTBIK3, ")
        '2013/12/05 T.Ono mod �Ď����P2013
        'strSQL.Append("    TAI.FKINM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.FKICD), NULL, NULL, TAI.FKICD || ':' || TAI.FKINM) AS FKINM, ")
        strSQL.Append("    TAI.SYOKANYMD, ")
        strSQL.Append("    TAI.SYOKANTIME, ")

        '2013/12/05 T.Ono mod �Ď����P2013
        'strSQL.Append("    TAI.TKTANCD_NM, ") ' 2009/03/24 T.Watabe add [�Ή����]�y�Ď��Z���^�[�S���Җ��z
        'strSQL.Append("    TAI.TSTANNM, ")    ' 2009/03/24 T.Watabe add [�o������]�y��M�Ҏ����z
        strSQL.Append("    DECODE(RTRIM(TAI.TKTANCD), NULL, NULL, TAI.TKTANCD || ':' || TAI.TKTANCD_NM) AS TKTANCD_NM, ")
        strSQL.Append("    DECODE(RTRIM(TAI.TSTANCD), NULL, NULL, TAI.TSTANCD || ':' || TAI.TSTANNM) AS TSTANNM, ")
        strSQL.Append("    TAI.SYUTDTNM ")    ' 2009/03/24 T.Watabe add [�o������]�y�o���Ή��ҁz
        strSQL.Append("FROM ")
        strSQL.Append("    D20_TAIOU TAI")
        '2013/10/30 �Ď����P2013��8
        strSQL.Append("    LEFT JOIN SHAMAS KOK ON TAI.KURACD = KOK.CLI_CD  ")
        strSQL.Append("                         AND TAI.ACBCD = KOK.HAN_CD ")
        strSQL.Append("                         AND TAI.USER_CD = KOK.USER_CD ")
        'End If

        'WHERE
        strSQL.Append("WHERE ")
        strSQL.Append(" 1 = 1 ") ' 2008/11/27 T.Watabe add

        ' ��ʂ���̏����w��
        '�Ď��Z���^�[
        If pstrKANSCD <> "" Then ' 2008/11/27 T.Watabe add �Ď��R�[�h�̕K�{���O��
            strSQL.Append(" AND TAI.KANSCD = :KANSCD ")
        End If
        '�N���C�A���g�b�c
        'strSQL.Append(" AND KURACD BETWEEN :KURACD_FROM AND :KURACD_TO ") ' 2008/11/27 T.Watabe edit
        If pstrKURACDFrom <> "" Then
            strSQL.Append(" AND TAI.KURACD >= :KURACD_FROM ")
        End If
        If pstrKURACDTo <> "" Then
            strSQL.Append(" AND TAI.KURACD <= :KURACD_TO ")
        End If

        '�i�`�b�c ' 2008/11/11 T.Watabe edit
        If pstrJACDFrom <> "" Then
            strSQL.Append(" AND TAI.JACD >= :JACD_FROM ")
        End If
        If pstrJACDTo <> "" Then
            strSQL.Append(" AND TAI.JACD <= :JACD_TO ")
        End If

        '�̔����Ǝ҃O���[�v�R�[�h  2014/12/12 H.Hosoda add �Ď����P2014 ��13
        If pstrHANGRPFrom <> "" Then
            strSQL.Append(" AND TAI.HANJICD >= :HANGRP_FROM ")
        End If
        If pstrHANGRPTo <> "" Then
            strSQL.Append(" AND TAI.HANJICD <= :HANGRP_TO ")
        End If

        '2014/12/11 H.Hosoda mod �Ď����P2014 ��13 START
        '������
        'strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        '�Ώۊ���
        If pstrKIKANKBN = "1" Then '�Ή�������
            strSQL.Append(" AND TAI.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        Else                       '��M��
            strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        End If
        '2014/12/11 H.Hosoda mod �Ď����P2014 ��13 END

        '�����敪
        If pstrStkbn1.Length = 0 And pstrStkbn2.Length = 0 Then
            '�����Ȃ�
        Else
            '��������
            If pstrStkbn1.Length <> 0 And pstrStkbn2.Length <> 0 Then
                strSQL.Append(" AND (TAI.HATKBN = :HATKBN1 OR TAI.HATKBN = :HATKBN2) ")
            ElseIf pstrStkbn1.Length <> 0 And pstrStkbn2.Length = 0 Then
                strSQL.Append(" AND TAI.HATKBN = :HATKBN1 ")
            ElseIf pstrStkbn1.Length = 0 And pstrStkbn2.Length <> 0 Then
                strSQL.Append(" AND TAI.HATKBN = :HATKBN2 ")
            Else
            End If
        End If

        '�Ή��敪
        If pstrPgkbn1.Length = 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length = 0 Then
            '�����Ȃ�
        Else
            '��������
            '�S������
            If pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length <> 0 Then
                strSQL.Append(" AND (TAI.TAIOKBN = :TAIOKBN1 OR TAI.TAIOKBN = :TAIOKBN2 OR TAI.TAIOKBN = :TAIOKBN3) ")

                '�����
            ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length = 0 Then
                strSQL.Append(" AND TAI.TAIOKBN = :TAIOKBN1 ")
            ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length = 0 Then
                strSQL.Append(" AND TAI.TAIOKBN = :TAIOKBN2 ")
            ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length <> 0 Then
                strSQL.Append(" AND TAI.TAIOKBN = :TAIOKBN3 ")

                '�����
            ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length = 0 Then
                strSQL.Append(" AND (TAI.TAIOKBN = :TAIOKBN1 OR TAI.TAIOKBN = :TAIOKBN2) ")
            ElseIf pstrPgkbn1.Length <> 0 And pstrPgkbn2.Length = 0 And pstrPgkbn3.Length <> 0 Then
                strSQL.Append(" AND (TAI.TAIOKBN = :TAIOKBN1 OR TAI.TAIOKBN = :TAIOKBN3) ")
            ElseIf pstrPgkbn1.Length = 0 And pstrPgkbn2.Length <> 0 And pstrPgkbn3.Length <> 0 Then
                strSQL.Append(" AND (TAI.TAIOKBN = :TAIOKBN2 OR TAI.TAIOKBN = :TAIOKBN3) ")
            Else
            End If
        End If

        '���A�Ή���
        If pstrTFKICD.Length <> 0 Then
            strSQL.Append(" AND TAI.TFKICD = :TFKICD ")
        End If

        '2014/12/10 H.Hosoda add �Ď����P2014 ��13 START
        If pstrOUTKBN = "2" Then '�o�͍��ڂŌ������[�Ɠ�����I����
            strSQL.Append(" AND TAI.TAIOKBN <> '3' ") '�Ή��敪�F3.�d��������
            '�������[�̏o�͑Ώۂł���x��R�[�h�i�Ή��敪�F2.�o���w���͌x��R�[�h�Ɋւ�炸�o�́j
            strSQL.Append(" AND (EXISTS (SELECT * FROM M06_PULLDOWN MCD WHERE MCD.NAIYO1 = TAI.KMCD1 AND MCD.KBN ='80' AND MCD.NAIYO1 IS NOT NULL AND MCD.NAIYO2 IS NULL AND MCD.NAME <= '08') ")
            strSQL.Append("      OR EXISTS (SELECT * FROM M06_PULLDOWN MCD WHERE MCD.NAIYO1 = TAI.KMCD1 AND MCD.NAIYO2 LIKE TAI.KMNM1 || '%' AND MCD.KBN ='80' AND MCD.NAIYO1 IS NOT NULL AND MCD.NAIYO2 IS NOT NULL AND MCD.NAME <= '08') ")
            strSQL.Append("      OR EXISTS (SELECT * FROM M06_PULLDOWN MCD WHERE MCD.NAIYO2 LIKE TAI.KMNM1 || '%' AND MCD.KBN ='80' AND MCD.NAIYO1 IS NULL AND MCD.NAIYO2 IS NOT NULL AND MCD.NAME <= '08') ")
            '2015/04/10 T.Ono mod 2014���P�J�� No13 START
            'strSQL.Append("      OR TAI.TAIOKBN = '2') ")
            strSQL.Append("      OR TAI.TAIOKBN = '2' ")
            strSQL.Append("      OR TAI.HATKBN = '1') ") '�����敪=�d�b�͑S�ĕ\��
            '2015/04/10 T.Ono mod 2014���P�J�� No13 End
            '�������[�̏o�͑Ώۂł���쓮�����i�Ή��敪�F2.�o���w���͍쓮�����Ɋւ�炸�o�́j
            strSQL.Append(" AND ((TAI.TSADCD<>'63' AND TAI.TSADCD<>'66') OR TAI.TSADCD IS NULL OR TAI.TAIOKBN = '2') ")
        End If
        '2014/12/10 H.Hosoda add �Ď����P2014 ��13 END

        'ORDER BY
        strSQL.Append("	ORDER BY ")
        'strSQL.Append("    KANSCD, ") ' 2008/11/20 T.Watabe edit
        'strSQL.Append("    KURACD, ")
        'strSQL.Append("    HATKBN, ")
        'strSQL.Append("    TAIOKBN, ")
        'strSQL.Append("    TFKICD ")
        strSQL.Append("    KURACD, ") '�N���C�A���g
        strSQL.Append("    ACBCD, ") '�i�`�x��
        '2013/11/01 T.Ono mod �Ή���ʂ̎�M�������o�͂���悤�ɕύX
        'strSQL.Append("    JUYMD, ") '�Ή���M��
        'strSQL.Append("    JUTIME ") '�Ή���M����
        strSQL.Append("    HATYMD, ") '��M��
        strSQL.Append("    HATTIME ") '��M����

        Return strSQL.ToString

    End Function

    Function fncSetChien(ByVal str As String) As String
        ' �x�����Ԃ𕪂��玞�F���ɕϊ�
        Dim M As Long '��
        Dim H As Long '����
        Dim fugou As String '�}�C�i�X
        Dim res As String


        If str = "0" Then
            res = Convert.ToString("0:00")
        Else
            fugou = CStr(Convert.ToString(str.IndexOf("-")))
            If fugou <> "-1" Then
                M = CLng(str) * -1
            Else
                M = CLng(str)
            End If

            H = CLng(M \ 60)
            M = M Mod 60

            If fugou <> "-1" Then
                res = Convert.ToString("-" & H & ":" & M.ToString.PadLeft(2, "0"c))
            Else
                res = Convert.ToString(H & ":" & M.ToString.PadLeft(2, "0"c))
            End If
        End If

        Return res
    End Function

    Function fncSetJUTEL(ByVal str1 As String, ByVal str2 As String) As String
        Dim res As String

        If str1 = "" Then 'JUTEL1����
            If str2 = "" Then 'JUTEL2����
                res = ""
            ElseIf Len(str2) < 5 Then 'JUTEL2��4�����ȉ��i�n�C�t������K�v�Ȃ��j
                res = str2
            Else 'JUTEL2��5�����ȏ�
                If str2.IndexOf("-") <> -1 Then 'JUTEL2�Ƀn�C�t������
                    res = str2
                Else 'JUTEL2�Ƀn�C�t���Ȃ�
                    res = str2.Substring(0, Len(str2) - 4) & "-" & str2.Substring(Len(str2) - 4)
                End If
            End If
        Else
            If str2 = "" Then
                res = str1
            ElseIf Len(str2) < 5 Then
                res = str1 & "-" & str2
            Else
                If str2.IndexOf("-") <> -1 Then
                    res = str1 & "-" & str2
                Else
                    res = str1 & "-" & str2.Substring(0, Len(str2) - 4) & "-" & str2.Substring(Len(str2) - 4)
                End If
            End If


        End If

        Return res
    End Function
End Class
