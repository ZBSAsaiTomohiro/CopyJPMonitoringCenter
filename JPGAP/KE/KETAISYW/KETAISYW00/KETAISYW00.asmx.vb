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
' 2023/01/06 Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�  excelOut1,excelOut2,excelOut4��Excel�o�͂ɁAJM�R�[�h(D20_TAIOU.KINRENCD)�y��JM�a��(D20_TAIOU.JMNAME)��ǉ�

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.IO


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
    '*        
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    '2014/12/10 H.Hosoda mod �Ď����P2014 ��13 ������ǉ�
    '2019/11/01 T.Ono mod �Ď����P2019 pstrJACDFrom_CLI,pstrJACDTo_CLI �ǉ�
    '2020/01/06 T.Ono mod �ЊQ�Ή����[ pstrTSADCD,pstrTSADNM �ǉ� 
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
    '2017/02/16 H.Mori mod ���P2016 No7-1 START
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
    '                                    ByVal pstrJACDTo As String, _
    '                                    ByVal pstrHANGRPFrom As String, _
    '                                    ByVal pstrHANGRPTo As String, _
    '                                    ByVal pstrOUTKBN As String, _
    '                                    ByVal pstrKIKANKBN As String _
    '                                    ) As String
    '2017/02/17 W.GANEKO mod ���P2016 No7 START
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKANSCD As String,
                                        ByVal pstrTFKICD As String,
                                        ByVal pstrStkbn1 As String,
                                        ByVal pstrStkbn2 As String,
                                        ByVal pstrPgkbn1 As String,
                                        ByVal pstrPgkbn2 As String,
                                        ByVal pstrPgkbn3 As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrKURACDFrom As String,
                                        ByVal pstrKURACDTo As String,
                                        ByVal pstrJACDFrom As String,
                                        ByVal pstrJACDFrom_CLI As String,
                                        ByVal pstrJACDTo As String,
                                        ByVal pstrJACDTo_CLI As String,
                                        ByVal pstrHANGRPFrom As String,
                                        ByVal pstrHANGRPTo As String,
                                        ByVal pstrOUTKBN As String,
                                        ByVal pstrKIKANKBN As String,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrHOKBN As String,
                                        ByVal pstrOUTLIST As String,
                                        ByVal pstrTFKINM As String,
                                        ByVal pstrTSADCD As String,
                                        ByVal pstrTSADNM As String
                                        ) As String
        '2017/02/17 W.GANEKO mod ���P2016 No7 END
        '2017/02/16 H.Mori mod ���P2016 No7-1 END

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
        Dim strHedInfoHasei As String                        '�w�b�_�[���i���o�����j
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
            '2017/02/16 H.Mori mod ���P2016 No7-1 ������ǉ�
            '2014/12/10 H.Hosoda mod �Ď����P2014 ��13 ������ǉ�
            '2017/02/17 W.GANEKO mod ���P2016 No7 ������ǉ�
            '2019/11/01 T.Ono mod �Ď����P2019 pstrJACDFrom_CLI,pstrJACDTo_CLI �ǉ�
            '2020/01/06 T.Ono mod �ЊQ�Ή����[ psrtTSADNM,psrtTSADNM �ǉ�
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
            '                            pstrJACDTo, _
            '                            pstrHANGRPFrom, _
            '                            pstrHANGRPTo, _
            '                            pstrOUTKBN, _
            '                            pstrKIKANKBN))
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
            '                            pstrJACDTo, _
            '                            pstrHANGRPFrom, _
            '                            pstrHANGRPTo, _
            '                            pstrOUTKBN, _
            '                            pstrKIKANKBN, _
            '                            pstrTrgTimeFrom, _
            '                            pstrTrgTimeTo))
            strSQL.Append(fncMakeSelect(pstrKANSCD,
                                        pstrTFKICD,
                                        pstrStkbn1,
                                        pstrStkbn2,
                                        pstrPgkbn1,
                                        pstrPgkbn2,
                                        pstrPgkbn3,
                                        pstrTrgFrom,
                                        pstrTrgTo,
                                        pstrKURACDFrom,
                                        pstrKURACDTo,
                                        pstrJACDFrom,
                                        pstrJACDFrom_CLI,
                                        pstrJACDTo,
                                        pstrJACDTo_CLI,
                                        pstrHANGRPFrom,
                                        pstrHANGRPTo,
                                        pstrOUTKBN,
                                        pstrKIKANKBN,
                                        pstrTrgTimeFrom,
                                        pstrTrgTimeTo,
                                        pstrHOKBN,
                                        pstrOUTLIST,
                                        pstrTFKINM,
                                        pstrTSADCD,
                                        pstrTSADNM))
            '2017/02/17 W.GANEKO mod ���P2016 No7 END
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
                cdb.pSQLParamStr("JACD_FROM_CLI") = pstrJACDFrom_CLI    '2019/11/01 T.Ono add �Ď����P2019
            End If
            If pstrJACDTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJACDTo
                cdb.pSQLParamStr("JACD_TO_CLI") = pstrJACDTo_CLI        '2019/11/01 T.Ono add �Ď����P2019
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

            '�Ή����������܂��͎�M�����@2017/02/16 H.Mori add ���P2016 No7-1 
            If pstrTrgTimeFrom <> "" Then
                cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            End If
            If pstrTrgTimeTo <> "" Then
                cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            End If

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

            '�쓮���� '2020/01/06 T.Ono add �ЊQ�Ή����[
            If pstrTSADCD.Length > 0 Then cdb.pSQLParamStr("TSADCD") = pstrTSADCD

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

            'ExcelC.pTitle = "�x��o��"                        '�^�C�g��
            ExcelC.pTitle = "�Ή����ʖ���"                        '�^�C�g�� 2017/02/17 W.GANEKO 2016�Ď����P ��7
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
            '2017/02/17 W.GANEKO MOD 2016�Ď����P START
            '���o����1�s��
            strHedInfo = ""
            If pstrKANSCD.Length > 0 Then
                strHedInfo = "�Ď��Z���^�[:" & pstrKANSCD
            End If
            If pstrKURACDFrom.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo += "�N���C�A���g:" & pstrKURACDFrom & "�`" & pstrKURACDTo
            End If
            If pstrJACDFrom.Length > 0 Or pstrJACDTo.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "JA:" & pstrJACDFrom & "�`" & pstrJACDTo
            End If
            If pstrHANGRPFrom.Length > 0 Or pstrHANGRPTo.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "�̔����Ǝ�:" & pstrHANGRPFrom & "�`" & pstrHANGRPTo
            End If
            If pstrTrgFrom.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                If pstrTrgTimeFrom.Length > 0 Then
                    strHedInfo = strHedInfo & "�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom) & " " & CTimeFncC.mGet(pstrTrgTimeFrom, 0) & "�`" & DateFncC.mGet(pstrTrgTo) & " " & CTimeFncC.mGet(pstrTrgTimeTo, 0)
                Else
                    strHedInfo = strHedInfo & "�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom) & "�`" & DateFncC.mGet(pstrTrgTo)
                End If
                If pstrKIKANKBN = "1" Then
                    strHedInfo = strHedInfo & "�E�Ή�������"
                Else
                    strHedInfo = strHedInfo & "�E��M��"
                End If
            End If
            If pstrStkbn1.Length > 0 Or pstrStkbn2.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "�����敪:"
                strHedInfoHasei = ""
                If pstrStkbn1 = "1" Then
                    strHedInfoHasei = "�d�b"
                End If
                If pstrStkbn2 = "2" Then
                    If strHedInfoHasei.Length > 0 Then
                        strHedInfoHasei = strHedInfoHasei & "�E"
                    End If
                    strHedInfoHasei = strHedInfoHasei & "�x��"
                End If
                strHedInfo = strHedInfo & strHedInfoHasei
            End If
            If pstrPgkbn1.Length > 0 Or pstrPgkbn2.Length > 0 Or pstrPgkbn3.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "�Ή��敪:"
                strHedInfoHasei = ""
                If pstrPgkbn1 = "1" Then
                    strHedInfoHasei = "�d�b"
                End If
                If pstrPgkbn2 = "2" Then
                    If strHedInfoHasei.Length > 0 Then
                        strHedInfoHasei = strHedInfoHasei & "�E"
                    End If
                    strHedInfoHasei = strHedInfoHasei & "�o��"
                End If
                If pstrPgkbn3 = "3" Then
                    If strHedInfoHasei.Length > 0 Then
                        strHedInfoHasei = strHedInfoHasei & "�E"
                    End If
                    strHedInfoHasei = strHedInfoHasei & "�d��"
                End If
                strHedInfo = strHedInfo & strHedInfoHasei
            End If

            If pstrOUTKBN.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                If pstrOUTKBN = "1" Then
                    strHedInfo = strHedInfo & "�o�͑Ώ�:�ʏ�"
                ElseIf pstrOUTKBN = "2" Then
                    strHedInfo = strHedInfo & "�o�͑Ώ�:�������[�Ɠ���(�d���܂܂�)"
                End If
            End If
            If pstrHOKBN.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                If pstrHOKBN = "1" Then
                    strHedInfo = strHedInfo & "�@�ߋ敪:�����v"
                ElseIf pstrHOKBN = "2" Then
                    strHedInfo = strHedInfo & "�@�ߋ敪:�t��"
                ElseIf pstrHOKBN = "3" Then
                    strHedInfo = strHedInfo & "�@�ߋ敪:���̑�"
                End If
            End If
            If pstrOUTLIST.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                If pstrOUTLIST = "1" Then
                    strHedInfo = strHedInfo & "�o�͍���:�S��"
                ElseIf pstrOUTLIST = "2" Then
                    strHedInfo = strHedInfo & "�o�͍���:�����񍐂Ɠ���(�o����Ђ���)"
                ElseIf pstrOUTLIST = "3" Then
                    strHedInfo = strHedInfo & "�o�͍���:�����񍐂Ɠ���(�o����ЂȂ�)"
                ElseIf pstrOUTLIST = "4" Then '2020/10/05 T.Ono add �Ď����P2020
                    strHedInfo = strHedInfo & "�o�͍���:�����񍐂Ɠ���(�o����ЂȂ�)�A�l���Ȃ�"
                End If
            End If
            If pstrTFKICD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "���A�Ή���:" & pstrTFKINM
            End If
            '2020/01/06 T.Ono add �ЊQ�Ή����[
            If pstrTSADCD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "�쓮����:" & pstrTSADNM
            End If

            If strHedInfo.Length > 0 Then
                'cntExcel += 1
                ExcelC.pCellStyle(1) = "height:13px;width:35px;text-align:left;font-size:10px;border-style:none;white-space:nowrap;"
                'ExcelC.pCellVal(i, "colspan=16") = strHedInfo
                ExcelC.pCellVal(1) = strHedInfo
                ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            End If

            'EXCEL�o��
            If pstrOUTLIST = "1" Then
                ExcelC = excelOut1(ds, dr, ExcelC)
            ElseIf pstrOUTLIST = "4" Then '2020/09/15 T.Ono add �Ď����P2020
                ExcelC = excelOut4(pstrOUTLIST, ds, dr, ExcelC)
            Else
                ExcelC = excelOut2(pstrOUTLIST, ds, dr, ExcelC)
            End If
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
            '2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 START
            'ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(2) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(3) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2016/02/26 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellStyle(4) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(5) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(6) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(7) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(8) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(9) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(18) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(19) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(20) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(21) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(22) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(23) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(24) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(25) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(26) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(27) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(28) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(31) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(32) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(33) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(34) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(35) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(36) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2013/10/28 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(37) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(38) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(39) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ''ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"  2013/08/27 T.Ono del �Ď����P2013��8
            ''ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"  2013/08/27 T.Ono del �Ď����P2013��8
            'ExcelC.pCellStyle(40) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(41) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(42) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            'ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ''ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add dell
            ''ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add dell
            'ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2010/03/24 T.Watabe add
            'ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            'ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            '' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13 START
            ''ExcelC.pCellStyle(54) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2011/05/17 T.Watabe add
            'ExcelC.pCellStyle(55) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            '' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13 END
            'ExcelC.pCellStyle(56) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add �Ď����P2014 ��13
            'ExcelC.pCellStyle(57) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add �Ď����P2014 ��13
            'ExcelC.pCellStyle(58) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add �Ď����P2014 ��13
            'ExcelC.pCellStyle(59) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2015/12/10 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellStyle(60) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2016/2/1 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellStyle(61) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2016/2/1 H.Mori add �Ď����P2015 ��10
            ''ExcelC.pCellStyle(58) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2014/12/09 H.Hosoda add �Ď����P2014 ��13
            ''ExcelC.pCellStyle(59) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2015/12/10 H.Mori mod �Ď����P2015 ��10 �ԍ���58��59
            'ExcelC.pCellStyle(62) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" ' 2016/2/1 H.Mori mod �Ď����P2015 ��10 �ԍ���59��61
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
            'If False Then
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
            'End If
            'i = 1
            '2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 START
            'ExcelC.pCellVal(i) = Convert.ToString("FAXJA��") : i += 1 ' 2011/05/17 T.Watabe add
            'ExcelC.pCellVal(i) = Convert.ToString("FAX�ב�") : i += 1 ' 2011/05/17 T.Watabe add
            'ExcelC.pCellVal(i) = Convert.ToString("�ݐϑ�") : i += 1 ' 2016/02/26 H.Mori add �Ď����P2015 ��10

            'ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8     5
            'ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8     6
            ''ExcelC.pCellVal(i) = Convert.ToString("�Ή���M��") : i += 1 2013/08/27 T.Ono mod �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("�Ή�����") : i += 1   2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("��M��") : i += 1                                             '7
            'ExcelC.pCellVal(i) = Convert.ToString("��M����") : i += 1                                           '8
            'ExcelC.pCellVal(i) = Convert.ToString("�x������") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8     9
            'ExcelC.pCellVal(i) = Convert.ToString("���ʋ敪") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8     10
            'ExcelC.pCellVal(i) = Convert.ToString("�x��P") : i += 1                                             '11
            'ExcelC.pCellVal(i) = Convert.ToString("�x��Q") : i += 1                                             '12
            'ExcelC.pCellVal(i) = Convert.ToString("�x��R") : i += 1                                             '13
            'ExcelC.pCellVal(i) = Convert.ToString("�x��S") : i += 1                                             '14
            'ExcelC.pCellVal(i) = Convert.ToString("�x��T") : i += 1                                             '15
            'ExcelC.pCellVal(i) = Convert.ToString("�x��U") : i += 1                                             '16
            'ExcelC.pCellVal(i) = Convert.ToString("���q�lFLG") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8   '17
            'ExcelC.pCellVal(i) = Convert.ToString("�w�j�l") : i += 1                                             '18
            'ExcelC.pCellVal(i) = Convert.ToString("�N���C�A���g�R�[�h") : i += 1                                 '19
            'ExcelC.pCellVal(i) = Convert.ToString("����") : i += 1                                               '20
            'ExcelC.pCellVal(i) = Convert.ToString("�i�`�R�[�h") : i += 1           ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13  21
            'ExcelC.pCellVal(i) = Convert.ToString("�i�`��") : i += 1               ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13  22
            'ExcelC.pCellVal(i) = Convert.ToString("�̔����Ǝ҃R�[�h") : i += 1     ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13  23
            'ExcelC.pCellVal(i) = Convert.ToString("�̔����ƎҖ�") : i += 1         ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13  24
            'ExcelC.pCellVal(i) = Convert.ToString("�i�`�x���R�[�h") : i += 1                                                   '26
            'ExcelC.pCellVal(i) = Convert.ToString("�i�`�x����") : i += 1                                                       '27
            ''ExcelC.pCellVal(i) = Convert.ToString("NCU�ڑ�(���)") : i += 1    ' 2013/08/27 T.Ono add �Ď����P2013��8       
            ''ExcelC.pCellVal(i) = Convert.ToString("�ڑ��敪") : i += 1 ' 2013/08/27 T.Ono add �Ď����P2013��8               
            'ExcelC.pCellVal(i) = Convert.ToString("���q�l�R�[�h") : i += 1                                                     '28
            'ExcelC.pCellVal(i) = Convert.ToString("���q�l��") : i += 1                                                         '29
            'ExcelC.pCellVal(i) = Convert.ToString("��\�Ҏ���") : i += 1    ' 2017/02/17 W.GANEKO add �Ď����P2016 ��7          30
            ''ExcelC.pCellVal(i) = Convert.ToString("�A����d�b") : i += 1 ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13           
            'ExcelC.pCellVal(i) = Convert.ToString("�A����") : i += 1                                                           '31
            '' 2014/12/11 H.Hosoda mod �Ď����P2014 ��13 START
            ''ExcelC.pCellVal(i) = Convert.ToString("�����d�b�ԍ�") : i += 1       ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�����ԍ�") : i += 1                                                         '32
            '' 2014/12/11 H.Hosoda mod �Ď����P2014 ��13 END    
            'ExcelC.pCellVal(i) = Convert.ToString("�ŏI�˓d��") : i += 1 ' 2016/2/1 H.Mori add �Ď����P2015 ��10                33
            'ExcelC.pCellVal(i) = Convert.ToString("�Z��") : i += 1                                                             '34
            'ExcelC.pCellVal(i) = Convert.ToString("�̔��敪") : i += 1 ' 2015/12/10 H.Mori add �Ď����P2015 ��10                35
            ''ExcelC.pCellVal(i) = Convert.ToString("�����敪�E���e") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("�Ή��敪�E���e") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("�����敪�E���e") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1                                                         '36
            'ExcelC.pCellVal(i) = Convert.ToString("�Ή��敪") : i += 1                                                         '37
            'ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1                                                         '38
            'ExcelC.pCellVal(i) = Convert.ToString("�Ď������S����") : i += 1 ' 2010/03/24 T.Watabe add                          39
            ''ExcelC.pCellVal(i) = Convert.ToString("�Ή�������") : i += 1                                                       
            ''ExcelC.pCellVal(i) = Convert.ToString("�Ή���������") : i += 1                                                     
            'ExcelC.pCellVal(i) = Convert.ToString("�A������") : i += 1 '2013/10/28 T.Ono add �Ď����P2013��8                    40
            ''ExcelC.pCellVal(i) = Convert.ToString("�d�b�A���E���e") : i += 1     2013/08/27 T.Ono mod �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("���A�Ή��󋵁E���e") : i += 1 2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�d�b�A��") : i += 1                                                         '41
            'ExcelC.pCellVal(i) = Convert.ToString("���A�Ή���") : i += 1                                                     '42
            ''ExcelC.pCellVal(i) = Convert.ToString("�d�b�Ή������P") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�Ď��Ή����e") : i += 1                                                     '43
            'ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1         '2014/12/09 H.Hosoda add �Ď����P2014 ��13         44
            ''ExcelC.pCellVal(i) = Convert.ToString("�d�b�Ή������Q") : i += 1  2013/08/27 T.Ono del �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("�d�b�Ή������R") : i += 1  2013/08/27 T.Ono del �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("�K�X���E���e") : i += 1 2013/10/28 T.Ono mod �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("�쓮�����E���e") : i += 1 2013/10/28 T.Ono mod �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("�K�X���") : i += 1  ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            'ExcelC.pCellVal(i) = Convert.ToString("�Ď����l") : i += 1 ' 2016/2/1 H.Mori add �Ď����P2015 ��10                  50
            'ExcelC.pCellVal(i) = Convert.ToString("�������") : i += 1                                                         '51
            'ExcelC.pCellVal(i) = Convert.ToString("�쓮����") : i += 1                                                         '52
            ''ExcelC.pCellVal(i) = Convert.ToString("�o���v����") : i += 1   ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            ''ExcelC.pCellVal(i) = Convert.ToString("�o���v������") : i += 1 ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            'ExcelC.pCellVal(i) = Convert.ToString("�o���˗���") : i += 1                                                       '57
            'ExcelC.pCellVal(i) = Convert.ToString("�o���˗�����") : i += 1                                                     '58
            'ExcelC.pCellVal(i) = Convert.ToString("�o����Ж�") : i += 1                                                       '59
            'ExcelC.pCellVal(i) = Convert.ToString("�o����t��") : i += 1 ' 2010/03/24 T.Watabe add                              60
            'ExcelC.pCellVal(i) = Convert.ToString("�o���Ή���") : i += 1 ' 2010/03/24 T.Watabe add                              61
            'ExcelC.pCellVal(i) = Convert.ToString("�o����") : i += 1                                                           '62
            'ExcelC.pCellVal(i) = Convert.ToString("�o������") : i += 1                                                         '63
            ''ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1   ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            ''ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1 ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            'ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1                                                           '64
            'ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1                                                         '65
            ''ExcelC.pCellVal(i) = Convert.ToString("�Ή����e�P") : i += 1  2013/08/27 T.Ono mod �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("�o���Ή����e") : i += 1                                                     '66
            ''ExcelC.pCellVal(i) = Convert.ToString("�Ή����e�Q") : i += 1  2013/08/27 T.Ono del �Ď����P2013��8
            ''ExcelC.pCellVal(i) = Convert.ToString("�Ή����e�R") : i += 1  2013/08/27 T.Ono del �Ď����P2013��8
            'ExcelC.pCellVal(i) = Convert.ToString("���A����") : i += 1                                                         '67
            ''ExcelC.pCellVal(i) = Convert.ToString("�[�u�I����") : i += 1   ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            ''ExcelC.pCellVal(i) = Convert.ToString("�[�u�I������") : i += 1 ' 2014/12/09 H.Hosoda mod �Ď����P2014 ��13
            'ExcelC.pCellVal(i) = Convert.ToString("����������") : i += 1                                                       '68
            'ExcelC.pCellVal(i) = Convert.ToString("������������") : i += 1                                                     '69
            'ExcelC.pCellVal(i) = Convert.ToString("�K�p�@�ߋ敪") : i += 1                                                     '70
            'ExcelC.pCellVal(i) = Convert.ToString("�����`�ԋ敪") : i += 1                                                     '71
            'ExcelC.pCellVal(i) = Convert.ToString("�p�r�敪") : i += 1                                                         '72
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ������� 


            ''���׃f�[�^�o��
            'Dim iCnt As Integer
            'AP�T�[�o����̖߂�l�����[�v����
            '���׃f�[�^�o��
            'For Each dr In ds.Tables(0).Rows
            'For iCnt = 0 To ds.Tables(0).Rows.Count - 1
            'dr = ds.Tables(0).Rows(iCnt)
            '���׍���
            '2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 START
            'ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(2) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(3) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2016/02/26 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellStyle(4) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(5) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(6) = "height:13px;width:65px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(7) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(8) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(9) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(18) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(19) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(20) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(21) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(22) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(23) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(24) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(25) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(26) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(27) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(28) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(31) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(32) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(33) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(34) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(35) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/10/28 T.Ono add �Ď����P2013��8
            'ExcelC.pCellStyle(36) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(37) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(38) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            ''ExcelC.pCellStyle(29) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del �Ď����P2013��8
            ''ExcelC.pCellStyle(30) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del �Ď����P2013��8
            'ExcelC.pCellStyle(39) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(40) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(41) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(42) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(45) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(46) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(47) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(48) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(49) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            'ExcelC.pCellStyle(50) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            ''ExcelC.pCellStyle(43) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"  2013/08/27 T.Ono del �Ď����P2013��8
            ''ExcelC.pCellStyle(44) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add  2013/08/27 T.Ono del �Ď����P2013��8
            'ExcelC.pCellStyle(51) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add
            'ExcelC.pCellStyle(52) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2010/03/24 T.Watabe add
            'ExcelC.pCellStyle(53) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2011/05/17 T.Watabe add
            ''2014/12/09 H.Hosoda add �Ď����P2014 ��13 START
            ''ExcelC.pCellStyle(53) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" ' 2011/05/17 T.Watabe add
            'ExcelC.pCellStyle(54) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
            ''2014/12/09 H.Hosoda add �Ď����P2014 ��13 END
            'ExcelC.pCellStyle(55) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
            'ExcelC.pCellStyle(56) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
            'ExcelC.pCellStyle(57) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
            'ExcelC.pCellStyle(58) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
            'ExcelC.pCellStyle(59) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2015/12/10 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellStyle(60) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2016/2/1 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellStyle(61) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2016/2/1 H.Mori add �Ď����P2015 ��10
            ''ExcelC.pCellStyle(58) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2014/12/09 H.Hosoda add �Ď����P2014 ��13
            ''ExcelC.pCellStyle(59) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2015/12/10 H.Mori mod �Ď����P2015 ��10 
            'ExcelC.pCellStyle(62) = "height:13px;width:10px;text-align:left;font-size:10px;border-style:none" '2016/2/1 H.Mori mod �Ď����P2015 ��10
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
            'If False Then
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
            'End If
            '    i = 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1 ' FAX�s�v 1:�s�v/2:�K�v
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1 ' �e�`�w�s�v(�ײ���) 1:�s�v/2:�K�v
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXRUISEKIKBN")) : i += 1 ' �񍐕s�v(�ݐ�) 1:�s�v/2:�K�v 2016/02/26 H.Mori add �Ď����P2015 ��10
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXSPOTKBN")) : i += 1 ' �˗��� 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATYMD")) : i += 1  ' �������� 2013/08/29 T.Ono add �Ď����P2013��8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATTIME")) : i += 1 ' �������� 2013/08/29 T.Ono add �Ď����P2013��8
            '    '2013/11/01 T.Ono mod �Ή���ʂ̎�M�������o�͂���悤�ɕύX
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUYMD")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUTIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1

            '    ExcelC.pCellVal(i) = fncSetChien(Convert.ToString(dr.Item("CHIEN"))) : i += 1  ' �x������ 2013/10/28 T.Ono add �Ď����P2013��8

            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1 ' ���ʋ敪 2013/08/29 T.Ono add �Ď����P2013��8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("OYAKU_FLG")) : i += 1 ' ���q�lFLG 2013/08/29 T.Ono add �Ď����P2013��8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KURACD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1      ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���p��]�yJA�R�[�h�z
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1      ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���p��]�yJA���z
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJICD")) : i += 1   ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���R�[�h���]�y�̔����Ǝ҃R�[�h�z
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJINM")) : i += 1   ' 2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���R�[�h���]�y�̔����ƎҖ��z
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBCD")) : i += 1  ' �̔����R�[�h 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TUSIN")) : i += 1   ' NSU�ڑ��i��ʁj  2013/08/29 T.Ono add �Ď����P2013��8
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM")) : i += 1 ' �ڑ��i�oor�[���j 2013/08/29 T.Ono add �Ď����P2013��8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("DAIHYO_NAME")) : i += 1  ' ��\�Ҏ��� 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1

            '    ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 ' �����d�b�ԍ�     2013/10/28 T.Ono add �Ď����P2013��8

            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KOK_TELNO")) : i += 1 ' 2016/2/1 H.Mori add �Ď����P2015 ��10 �y���M�d�b�ԍ��z
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBAI_KBN")) : i += 1 ' 2015/12/10 H.Mori add �Ď����P2015 ��10 [���q�l���]�̔��敪
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATKBN_NAI")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1 ' 2010/03/24 T.Watabe add  [�Ή����]�y�Ď��Z���^�[�S���Җ��z 
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITCD")) : i += 1 ' �A������     2013/10/28 T.Ono add �Ď����P2013��8
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TFKINM")) : i += 1
            '    ' 2013/10/28 T.Ono mod �Ď����P2013��8
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO2")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FUK_MEMO")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAX_REN")) : i += 1 ' 2014/12/10 H.Hosoda add �Ď����P2014 ��13 [�A����]�yFAX�A�����z
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KANSHI_BIKO")) : i += 1 ' 2016/2/1 H.Mori add �Ď����P2015 ��10 [���q�l���]�Ď����l
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TUSIN")) : i += 1    ' NCU�ڑ�(���) 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM")) : i += 1  ' �ڑ��敪 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1   ' �Ή������� 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1  ' �Ή��������� 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSTANNM")) : i += 1 ' 2010/03/24 T.Watabe add [�o������]�y��M�Ҏ����z
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYUTDTNM")) : i += 1 ' 2010/03/24 T.Watabe add [�o������]�y�o���Ή��ҁz
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKTIME")) : i += 1
            '    ' 2013/10/28 T.Ono mod �Ď����P2013��8
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SNTTOKKI")) : i += 1
            '    'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK3")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FKINM")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANYMD")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANTIME")) : i += 1
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HOKBN")) : i += 1      ' �K�p�@�ߋ敪 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYOKTKBN")) : i += 1   ' �����`�ԋ敪 2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = Convert.ToString(dr.Item("YOTOKBN")) : i += 1    ' �p�r�敪     2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            '    ExcelC.pCellVal(i) = "1"
            '    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
            'Next
            '2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 END

            ExcelC.mWriteLine("")                           '�s���t�@�C���ɏ�������
            ExcelC.mClose()                                 '�t�@�C���N���[�Y

            '���k��t�@�C���̂���t�H���_
            compressC.p_Dir = ExcelC.pDirName
            '���{��t�@�C�����̎w��
            'compressC.p_NihongoFileName = "�x��o��.xls"
            compressC.p_NihongoFileName = "�Ή����ʖ���.xls"               '2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
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
    '2017/02/17 W.GANEKO ADD �Ď����P2016 ��7
    '******************************************************************************
    '*�@�T�@�v:EXCEL�o�́iOUTLIST=1�F�S�āj
    '*�@���@�l:�Ή��c�a�擾
    '******************************************************************************
    Function excelOut1(ByVal ds As DataSet, ByVal dr As DataRow, ByVal ExcelC As Common.CExcel) As Common.CExcel

        Dim i As Integer
        Dim excel_h13px As String = "height:13px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_h56px As String = "height:56px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_backgroundcolor As String = "background-color:lightgrey;"
        Dim excel_w10px As String = "width:10px;"
        Dim excel_w30px As String = "width:30px;"
        Dim excel_w35px As String = "width:35px;"
        Dim excel_w40px As String = "width:40px;"
        Dim excel_w50px As String = "width:50px;"
        Dim excel_w60px As String = "width:60px;"
        Dim excel_w65px As String = "width:65px;"
        Dim excel_w70px As String = "width:70px;"
        Dim excel_w100px As String = "width:100px;"
        Dim excel_w150px As String = "width:150px;"
        Dim excel_w160px As String = "width:160px;"  'JM�R�[�h����  2023/01/06 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 
        Dim excel_w360px As String = "width:360px;"  'JM�a������    2023/01/06 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 

        Dim excel_h56px_w10px As String = "height:56px;width:10px;text-align:left;font-size:10px;border-style:none;"
        ' 2023/01/06 MOD START Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� pCellStyle�̔ԍ����炵�i�r����2���ڒǉ������ׁB�j
        ExcelC.pCellStyle(1) = excel_h56px & excel_w35px & excel_backgroundcolor    'FAXJA��
        ExcelC.pCellStyle(2) = excel_h56px & excel_w35px & excel_backgroundcolor    'FAX�ו�
        ExcelC.pCellStyle(3) = excel_h56px & excel_w35px & excel_backgroundcolor    '�ݐϕ�
        ExcelC.pCellStyle(4) = excel_h56px & excel_w35px & excel_backgroundcolor    '�˗���
        ExcelC.pCellStyle(5) = excel_h56px & excel_w65px & excel_backgroundcolor    '��������
        ExcelC.pCellStyle(6) = excel_h56px & excel_w40px & excel_backgroundcolor    '��������
        ExcelC.pCellStyle(7) = excel_h56px & excel_w65px & excel_backgroundcolor    '��M��
        ExcelC.pCellStyle(8) = excel_h56px & excel_w40px & excel_backgroundcolor    '��M����
        ExcelC.pCellStyle(9) = excel_h56px & excel_w40px & excel_backgroundcolor    '�x������
        ExcelC.pCellStyle(10) = excel_h56px & excel_w30px & excel_backgroundcolor   '���ʋ敪

        ExcelC.pCellStyle(11) = excel_h56px & excel_w150px & excel_backgroundcolor  '�x��P
        ExcelC.pCellStyle(12) = excel_h56px & excel_w100px & excel_backgroundcolor  '�x��Q
        ExcelC.pCellStyle(13) = excel_h56px & excel_w100px & excel_backgroundcolor  '�x��R
        ExcelC.pCellStyle(14) = excel_h56px & excel_w40px & excel_backgroundcolor   '�x��S
        ExcelC.pCellStyle(15) = excel_h56px & excel_w40px & excel_backgroundcolor   '�x��T
        ExcelC.pCellStyle(16) = excel_h56px & excel_w40px & excel_backgroundcolor   '�x��U
        ExcelC.pCellStyle(17) = excel_h56px & excel_w60px & excel_backgroundcolor   '���q�lFLG
        ExcelC.pCellStyle(18) = excel_h56px & excel_w60px & excel_backgroundcolor   '�w�j�l
        ExcelC.pCellStyle(19) = excel_h56px & excel_w50px & excel_backgroundcolor   '�N���C�A���g�R�[�h
        ExcelC.pCellStyle(20) = excel_h56px & excel_w50px & excel_backgroundcolor   '����

        ExcelC.pCellStyle(21) = excel_h56px & excel_w50px & excel_backgroundcolor   '�i�`�R�[�h
        ExcelC.pCellStyle(22) = excel_h56px & excel_w100px & excel_backgroundcolor  '�i�`��
        ExcelC.pCellStyle(23) = excel_h56px & excel_w160px & excel_backgroundcolor  '�i�`�S���ҕ񍐐�R�[�h ' 2023/01/06 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�
        ExcelC.pCellStyle(24) = excel_h56px & excel_w360px & excel_backgroundcolor  '�i�`�S���ҕ񍐐於     ' 2023/01/06 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�
        ExcelC.pCellStyle(25) = excel_h56px & excel_w100px & excel_backgroundcolor  '�̔����Ǝ҃R�[�h
        ExcelC.pCellStyle(26) = excel_h56px & excel_w100px & excel_backgroundcolor  '�̔����ƎҖ�
        ExcelC.pCellStyle(27) = excel_h56px & excel_w50px & excel_backgroundcolor   '�̔����R�[�h
        ExcelC.pCellStyle(28) = excel_h56px & excel_w60px & excel_backgroundcolor   '�i�`�x���R�[�h
        ExcelC.pCellStyle(29) = excel_h56px & excel_w100px & excel_backgroundcolor  '�i�`�x����
        ExcelC.pCellStyle(30) = excel_h56px & excel_w60px & excel_backgroundcolor   '���q�l�R�[�h

        ExcelC.pCellStyle(31) = excel_h56px & excel_w100px & excel_backgroundcolor  '���q�l��
        ExcelC.pCellStyle(32) = excel_h56px & excel_w60px & excel_backgroundcolor   '��\�Ҏ���
        ExcelC.pCellStyle(33) = excel_h56px & excel_w100px & excel_backgroundcolor  '�A����
        ExcelC.pCellStyle(34) = excel_h56px & excel_w100px & excel_backgroundcolor  '�����ԍ�
        ExcelC.pCellStyle(35) = excel_h56px & excel_w100px & excel_backgroundcolor  '�ŏI�˓d��
        ExcelC.pCellStyle(36) = excel_h56px & excel_w100px & excel_backgroundcolor  '�Z��
        ExcelC.pCellStyle(37) = excel_h56px & excel_w100px & excel_backgroundcolor  '�̔��敪
        ExcelC.pCellStyle(38) = excel_h56px & excel_w70px & excel_backgroundcolor   '�����敪
        ExcelC.pCellStyle(39) = excel_h56px & excel_w70px & excel_backgroundcolor   '�Ή��敪
        ExcelC.pCellStyle(40) = excel_h56px & excel_w70px & excel_backgroundcolor   '�����敪

        ExcelC.pCellStyle(41) = excel_h56px & excel_w100px & excel_backgroundcolor  '�Ď������S����
        ExcelC.pCellStyle(42) = excel_h56px & excel_w70px & excel_backgroundcolor   '�A������
        ExcelC.pCellStyle(43) = excel_h56px & excel_w70px & excel_backgroundcolor   '�d�b�A��
        ExcelC.pCellStyle(44) = excel_h56px & excel_w70px & excel_backgroundcolor   '���A�Ή���
        ExcelC.pCellStyle(45) = excel_h56px & excel_w150px & excel_backgroundcolor  '�Ď��Ή����e
        ExcelC.pCellStyle(46) = excel_h56px & excel_w100px & excel_backgroundcolor  '������
        ExcelC.pCellStyle(47) = excel_h56px & excel_w70px & excel_backgroundcolor   '�Ď����l
        ExcelC.pCellStyle(48) = excel_h56px & excel_w70px & excel_backgroundcolor   '�������
        ExcelC.pCellStyle(49) = excel_h56px & excel_w100px & excel_backgroundcolor  '�쓮����
        ExcelC.pCellStyle(50) = excel_h56px & excel_w30px & excel_backgroundcolor   'NCU�ڑ�(���)

        ExcelC.pCellStyle(51) = excel_h56px & excel_w50px & excel_backgroundcolor   '�ڑ��敪
        ExcelC.pCellStyle(52) = excel_h56px & excel_w60px & excel_backgroundcolor   '�Ή�������
        ExcelC.pCellStyle(53) = excel_h56px & excel_w60px & excel_backgroundcolor   '�Ή���������
        ExcelC.pCellStyle(54) = excel_h56px & excel_w60px & excel_backgroundcolor   '�o���˗���
        ExcelC.pCellStyle(55) = excel_h56px & excel_w60px & excel_backgroundcolor   '�o���˗�����
        ExcelC.pCellStyle(56) = excel_h56px & excel_w100px & excel_backgroundcolor  '�o����Ж�
        ExcelC.pCellStyle(57) = excel_h56px & excel_w100px & excel_backgroundcolor  '�o����t��
        ExcelC.pCellStyle(58) = excel_h56px & excel_w100px & excel_backgroundcolor  '�o���Ή���
        ExcelC.pCellStyle(59) = excel_h56px & excel_w60px & excel_backgroundcolor   '�o����
        ExcelC.pCellStyle(60) = excel_h56px & excel_w60px & excel_backgroundcolor   '�o������

        ExcelC.pCellStyle(61) = excel_h56px & excel_w60px & excel_backgroundcolor   '������
        ExcelC.pCellStyle(62) = excel_h56px & excel_w60px & excel_backgroundcolor   '��������
        ExcelC.pCellStyle(63) = excel_h56px & excel_w100px & excel_backgroundcolor  '�o���Ή����e
        ExcelC.pCellStyle(64) = excel_h56px & excel_w100px & excel_backgroundcolor  '���A����
        ExcelC.pCellStyle(65) = excel_h56px & excel_w60px & excel_backgroundcolor   '����������
        ExcelC.pCellStyle(66) = excel_h56px & excel_w60px & excel_backgroundcolor   '������������
        ExcelC.pCellStyle(67) = excel_h56px & excel_w70px & excel_backgroundcolor   '�K�p�@�ߋ敪
        ExcelC.pCellStyle(68) = excel_h56px & excel_w70px & excel_backgroundcolor   '�����`�ԋ敪
        ExcelC.pCellStyle(69) = excel_h56px & excel_w70px & excel_backgroundcolor   '�p�r�敪
        ExcelC.pCellStyle(70) = excel_h56px & excel_w10px & excel_backgroundcolor   '�i�ŏI��u���ڂȂ��v�����s�ʒu�j
        ' 2023/01/06 MOD END   Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�

        i = 1

        ' 2023/01/06 MOD START Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� �w�b�_��2���ڒǉ� �{ �R�����g����
        ExcelC.pCellVal(i) = Convert.ToString("FAXJA��") : i += 1               '1   '2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 
        ExcelC.pCellVal(i) = Convert.ToString("FAX�ו�") : i += 1               '2   '2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 
        ExcelC.pCellVal(i) = Convert.ToString("�ݐϕ�") : i += 1                '3   '2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 
        ExcelC.pCellVal(i) = Convert.ToString("�˗���") : i += 1                  '4   '2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 
        ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1                '5   '2013/08/27 T.Ono add �Ď����P2013��8     
        ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1                '6   '2013/08/27 T.Ono add �Ď����P2013��8     
        ExcelC.pCellVal(i) = Convert.ToString("��M��") : i += 1                  '7
        ExcelC.pCellVal(i) = Convert.ToString("��M����") : i += 1                '8
        ExcelC.pCellVal(i) = Convert.ToString("�x������") : i += 1                '9   '2013/08/27 T.Ono add �Ď����P2013��8
        ExcelC.pCellVal(i) = Convert.ToString("���ʋ敪") : i += 1                '10  '2013/08/27 T.Ono add �Ď����P2013��8

        ExcelC.pCellVal(i) = Convert.ToString("�x��P") : i += 1                  '11
        ExcelC.pCellVal(i) = Convert.ToString("�x��Q") : i += 1                  '12
        ExcelC.pCellVal(i) = Convert.ToString("�x��R") : i += 1                  '13
        ExcelC.pCellVal(i) = Convert.ToString("�x��S") : i += 1                  '14
        ExcelC.pCellVal(i) = Convert.ToString("�x��T") : i += 1                  '15
        ExcelC.pCellVal(i) = Convert.ToString("�x��U") : i += 1                  '16
        ExcelC.pCellVal(i) = Convert.ToString("���q�lFLG") : i += 1               '17  '2013/08/27 T.Ono add �Ď����P2013��8
        ExcelC.pCellVal(i) = Convert.ToString("�w�j�l") : i += 1                  '18
        ExcelC.pCellVal(i) = Convert.ToString("�N���C�A���g�R�[�h") : i += 1      '19
        ExcelC.pCellVal(i) = Convert.ToString("����") : i += 1                    '20

        ExcelC.pCellVal(i) = Convert.ToString("�i�`�R�[�h") : i += 1              '21  '2014/12/11 H.Hosoda add �Ď����P2014 ��13  
        ExcelC.pCellVal(i) = Convert.ToString("�i�`��") : i += 1                  '22  '2014/12/11 H.Hosoda add �Ď����P2014 ��13  
        ExcelC.pCellVal(i) = Convert.ToString("�i�`�S���ҕ񍐐�R�[�h") : i += 1  '23  '2023/01/06 ADD Y.ARAKAKI 2022�X��No�E
        ExcelC.pCellVal(i) = Convert.ToString("�i�`�S���ҕ񍐐於") : i += 1      '24  '2023/01/06 ADD Y.ARAKAKI 2022�X��No�E      
        ExcelC.pCellVal(i) = Convert.ToString("�̔����Ǝ҃R�[�h") : i += 1        '25  '2014/12/11 H.Hosoda add �Ď����P2014 ��13  
        ExcelC.pCellVal(i) = Convert.ToString("�̔����ƎҖ�") : i += 1            '26  '2014/12/11 H.Hosoda add �Ď����P2014 ��13  
        ExcelC.pCellVal(i) = Convert.ToString("�̔����R�[�h") : i += 1            '27  '2017/02/17 W.GANEKO add �Ď����P2016 ��7   
        ExcelC.pCellVal(i) = Convert.ToString("�i�`�x���R�[�h") : i += 1          '28
        ExcelC.pCellVal(i) = Convert.ToString("�i�`�x����") : i += 1              '29
        ExcelC.pCellVal(i) = Convert.ToString("���q�l�R�[�h") : i += 1            '30

        ExcelC.pCellVal(i) = Convert.ToString("���q�l��") : i += 1                '31
        ExcelC.pCellVal(i) = Convert.ToString("��\�Ҏ���") : i += 1              '32  '2017/02/17 W.GANEKO add �Ď����P2016 ��7
        ExcelC.pCellVal(i) = Convert.ToString("�A����") : i += 1                  '33
        ExcelC.pCellVal(i) = Convert.ToString("�����ԍ�") : i += 1                '34
        ExcelC.pCellVal(i) = Convert.ToString("�ŏI�˓d��") : i += 1              '35  '2016/2/1 H.Mori add �Ď����P2015 ��10
        ExcelC.pCellVal(i) = Convert.ToString("�Z��") : i += 1                    '36
        ExcelC.pCellVal(i) = Convert.ToString("�̔��敪") : i += 1                '37  '2015/12/10 H.Mori add �Ď����P2015 ��10
        ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1                '38
        ExcelC.pCellVal(i) = Convert.ToString("�Ή��敪") : i += 1                '39
        ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1                '40

        ExcelC.pCellVal(i) = Convert.ToString("�Ď������S����") : i += 1          '41  '2010/03/24 T.Watabe add
        ExcelC.pCellVal(i) = Convert.ToString("�A������") : i += 1                '42  '2013/10/28 T.Ono add �Ď����P2013��8
        ExcelC.pCellVal(i) = Convert.ToString("�d�b�A��") : i += 1                '43
        ExcelC.pCellVal(i) = Convert.ToString("���A�Ή���") : i += 1            '44
        ExcelC.pCellVal(i) = Convert.ToString("�Ď��Ή����e") : i += 1            '45
        ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1                  '46  '2014/12/09 H.Hosoda add �Ď����P2014 ��13
        ExcelC.pCellVal(i) = Convert.ToString("�Ď����l") : i += 1                '47  '2016/2/1 H.Mori add �Ď����P2015 ��10
        ExcelC.pCellVal(i) = Convert.ToString("�������") : i += 1                '48
        ExcelC.pCellVal(i) = Convert.ToString("�쓮����") : i += 1                '49
        ExcelC.pCellVal(i) = Convert.ToString("NCU�ڑ�(���)") : i += 1           '50  '2017/02/17 W.GANEKO add �Ď����P2016 ��7

        ExcelC.pCellVal(i) = Convert.ToString("�ڑ��敪") : i += 1                '51  '2017/02/17 W.GANEKO add �Ď����P2016 ��7
        ExcelC.pCellVal(i) = Convert.ToString("�Ή�������") : i += 1              '52  '2017/02/17 W.GANEKO add �Ď����P2016 ��7
        ExcelC.pCellVal(i) = Convert.ToString("�Ή���������") : i += 1            '53  '2017/02/17 W.GANEKO add �Ď����P2016 ��7
        ExcelC.pCellVal(i) = Convert.ToString("�o���˗���") : i += 1              '54
        ExcelC.pCellVal(i) = Convert.ToString("�o���˗�����") : i += 1            '55
        ExcelC.pCellVal(i) = Convert.ToString("�o����Ж�") : i += 1              '56
        ExcelC.pCellVal(i) = Convert.ToString("�o����t��") : i += 1              '57  '2010/03/24 T.Watabe add 
        ExcelC.pCellVal(i) = Convert.ToString("�o���Ή���") : i += 1              '58  '2010/03/24 T.Watabe add 
        ExcelC.pCellVal(i) = Convert.ToString("�o����") : i += 1                  '59
        ExcelC.pCellVal(i) = Convert.ToString("�o������") : i += 1                '60

        ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1                  '61
        ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1                '62
        ExcelC.pCellVal(i) = Convert.ToString("�o���Ή����e") : i += 1            '63
        ExcelC.pCellVal(i) = Convert.ToString("���A����") : i += 1                '64
        ExcelC.pCellVal(i) = Convert.ToString("����������") : i += 1              '65
        ExcelC.pCellVal(i) = Convert.ToString("������������") : i += 1            '66
        ExcelC.pCellVal(i) = Convert.ToString("�K�p�@�ߋ敪") : i += 1            '67
        ExcelC.pCellVal(i) = Convert.ToString("�����`�ԋ敪") : i += 1            '68
        ExcelC.pCellVal(i) = Convert.ToString("�p�r�敪") : i += 1                '69
        ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������                       '(70���[�̗�A�L�ڂȂ��̂܂�)
        ' 2023/01/06 MOD END   Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�

        ''���׃f�[�^�o��
        Dim iCnt As Integer
        'AP�T�[�o����̖߂�l�����[�v����
        '���׃f�[�^�o��
        For iCnt = 0 To ds.Tables(0).Rows.Count - 1
            dr = ds.Tables(0).Rows(iCnt)
            ' 2023/01/06 MOD START Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� ���ׂɁA�w�b�_�Ɠ��l2���ڒǉ�
            '���׍���
            ExcelC.pCellStyle(1) = excel_h13px & excel_w35px
            ExcelC.pCellStyle(2) = excel_h13px & excel_w35px
            ExcelC.pCellStyle(3) = excel_h13px & excel_w35px
            ExcelC.pCellStyle(4) = excel_h13px & excel_w35px
            ExcelC.pCellStyle(5) = excel_h13px & excel_w65px
            ExcelC.pCellStyle(6) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(7) = excel_h13px & excel_w65px
            ExcelC.pCellStyle(8) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(9) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(10) = excel_h13px & excel_w30px

            ExcelC.pCellStyle(11) = excel_h13px & excel_w150px
            ExcelC.pCellStyle(12) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(13) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(14) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(15) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(16) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(17) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(18) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(19) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(20) = excel_h13px & excel_w50px

            ExcelC.pCellStyle(21) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(22) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(23) = excel_h13px & excel_w160px  'JM�R�[�h  2023/01/06 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 
            ExcelC.pCellStyle(24) = excel_h13px & excel_w360px  'JM�a��    2023/01/06 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 
            ExcelC.pCellStyle(25) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(26) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(27) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(28) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(29) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(30) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(31) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(32) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(33) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(34) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(35) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(36) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(37) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(38) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(39) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(40) = excel_h13px & excel_w70px

            ExcelC.pCellStyle(41) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(42) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(43) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(44) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(45) = excel_h13px & excel_w150px
            ExcelC.pCellStyle(46) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(47) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(48) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(49) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(50) = excel_h13px & excel_w30px

            ExcelC.pCellStyle(51) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(52) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(53) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(54) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(55) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(56) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(57) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(58) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(59) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(60) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(61) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(62) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(63) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(64) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(65) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(66) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(67) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(68) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(69) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(70) = excel_h13px & excel_w10px
            ' 2023/01/06 MOD END   Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�
            i = 1
            ' 2023/01/06 MOD START Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� ���ׂɁA�w�b�_�Ɠ��l2���ڒǉ�
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1              '[ 1]FAX�s�v(JA)     1:�s�v/2:�K�v
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1          '[ 2]FAX�s�v(�ײ���) 1:�s�v/2:�K�v
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXRUISEKIKBN")) : i += 1       '[ 3]�񍐕s�v(�ݐ�)  1:�s�v/2:�K�v  2016/02/26 H.Mori add �Ď����P2015 ��10
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXSPOTKBN")) : i += 1          '[ 4]�˗���                  2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATYMD")) : i += 1           '[ 5]��������                2013/08/29 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCUHATTIME")) : i += 1          '[ 6]��������                2013/08/29 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1              '[ 7]��M��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1             '[ 8]��M����
            ExcelC.pCellVal(i) = fncSetChien(Convert.ToString(dr.Item("CHIEN"))) : i += 1  '[ 9]�x������                2013/10/28 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1              '[10]���ʋ敪                2013/08/29 T.Ono add �Ď����P2013��8

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1               '[11]�x��P
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1               '[12]�x��Q
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1               '[13]�x��R
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1               '[14]�x��S
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1               '[15]�x��T
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1               '[16]�x��U
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("OYAKU_FLG")) : i += 1           '[17]���q�lFLG               2013/08/29 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1              '[18]�w�j�l
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KURACD")) : i += 1              '[19]�N���C�A���g�R�[�h
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1               '[20]����

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1                '[21]�i�`�R�[�h              2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���p��]�yJA�R�[�h�z
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1                '[22]�i�`��                  2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���p��]�yJA���z
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KINRENCD")) : i += 1            '[23]�i�`�S���ҕ񍐐�R�[�h  2023/01/06 ADD Y.ARAKAKI 2022�X��No�E
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JMNAME")) : i += 1              '[24]�i�`�S���ҕ񍐐於      2023/01/06 ADD Y.ARAKAKI 2022�X��No�E
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJICD")) : i += 1             '[25]�̔����Ǝ҃R�[�h        2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���R�[�h���]�y�̔����Ǝ҃R�[�h�z
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJINM")) : i += 1             '[26]�̔����ƎҖ�            2014/12/11 H.Hosoda add �Ď����P2014 ��13 [���R�[�h���]�y�̔����ƎҖ��z
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBCD")) : i += 1              '[27]�̔����R�[�h            2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1               '[28]�i�`�x���R�[�h
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1               '[29]�i�`�x����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1             '[30]���q�l�R�[�h

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1             '[31]���q�l��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("DAIHYO_NAME")) : i += 1         '[32]��\�Ҏ���              2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1              '[33]�A����
            ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 '[34]�����d�b�ԍ� 2013/10/28 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KOK_TELNO")) : i += 1           '[35]�ŏI�˓d��              2016/02/01 H.Mori add �Ď����P2015 ��10 �y���M�d�b�ԍ��z
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1                '[36]�Z��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBAI_KBN")) : i += 1          '[37]�̔��敪                2015/12/10 H.Mori add �Ď����P2015 ��10 [���q�l���]�̔��敪
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATKBN_NAI")) : i += 1          '[38]�����敪
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1         '[39]�Ή��敪
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1           '[40]�����敪

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1          '[41]�Ď������S����          2010/03/24 T.Watabe add  [�Ή����]�y�Ď��Z���^�[�S���Җ��z 
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITCD")) : i += 1              '[42]�A������                2013/10/28 T.Ono add �Ď����P2013��8
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1              '[43]�d�b�A��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TFKINM")) : i += 1              '[44]���A�Ή���
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1  '2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) &
                                 Convert.ToString(dr.Item("TEL_MEMO4")) & Convert.ToString(dr.Item("TEL_MEMO5")) & Convert.ToString(dr.Item("TEL_MEMO6")) : i += 1  '[45]�Ď��Ή����e
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAX_REN")) : i += 1             '[46]������                  2014/12/10 H.Hosoda add �Ď����P2014 ��13 [�A����]�yFAX�A�����z
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KANSHI_BIKO")) : i += 1         '[47]�Ď����l                2016/02/01 H.Mori add �Ď����P2015 ��10 [���q�l���]�Ď����l
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1              '[48]�������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1              '[49]�쓮����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TUSIN")) : i += 1               '[50]NCU�ڑ�(���)           2017/02/17 W.GANEKO ADD 2016�Ď����P ��7

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM")) : i += 1           '[51]�ڑ��敪                2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1              '[52]�Ή�������              2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1             '[53]�Ή���������            2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1             '[54]�o���˗���
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1            '[55]�o���˗�����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD")) : i += 1                 '[56]�o����Ж�
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSTANNM")) : i += 1             '[57]�o����t��              2010/03/24 T.Watabe add [�o������]�y��M�Ҏ����z
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYUTDTNM")) : i += 1            '[58]�o���Ή���              2010/03/24 T.Watabe add [�o������]�y�o���Ή��ҁz
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDYMD")) : i += 1               '[59]�o����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTIME")) : i += 1              '[60]�o������

            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKYMD")) : i += 1             '[61]������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKTIME")) : i += 1            '[62]��������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3")) : i += 1 '[63]�o���Ή����e 
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FKINM")) : i += 1               '[64]���A����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANYMD")) : i += 1           '[65]����������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANTIME")) : i += 1          '[66]������������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HOKBN")) : i += 1               '[67]�K�p�@�ߋ敪            2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYOKTKBN")) : i += 1            '[68]�����`�ԋ敪            2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("YOTOKBN")) : i += 1             '[69]�p�r�敪                2017/02/17 W.GANEKO ADD 2016�Ď����P ��7
            ExcelC.pCellVal(i) = "1"                                                       '[70]���ŏI��i�w�b�_�L�ڂȂ��j
            ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
            ' 2023/01/06 MOD END   Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�
        Next

        Return ExcelC
    End Function
    '2017/02/17 W.GANEKO ADD �Ď����P2016 ��7
    '******************************************************************************
    '*�@�T�@�v:EXCEL�o�́iOUTLIST=2�F�����񍐂Ɠ���(�o����Ђ���)�^OUTLIST=3�F�����񍐂Ɠ���(�o����ЂȂ�)�j
    '*�@���@�l:�Ή��c�a�擾
    '******************************************************************************
    Function excelOut2(ByVal OUTLIST As String, ByVal ds As DataSet, ByVal dr As DataRow, ByVal ExcelC As Common.CExcel) As Common.CExcel

        Dim i As Integer
        Dim excel_h13px As String = "height:13px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_h56px As String = "height:56px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_backgroundcolor As String = "background-color:lightgrey;"
        Dim excel_w10px As String = "width:10px;"
        Dim excel_w30px As String = "width:30px;"
        Dim excel_w35px As String = "width:35px;"
        Dim excel_w40px As String = "width:40px;"
        Dim excel_w50px As String = "width:50px;"
        Dim excel_w60px As String = "width:60px;"
        Dim excel_w65px As String = "width:65px;"
        Dim excel_w70px As String = "width:70px;"
        Dim excel_w100px As String = "width:100px;"
        Dim excel_w150px As String = "width:150px;"
        Dim excel_h56px_w10px As String = "height:56px;width:10px;text-align:left;font-size:10px;border-style:none;"
        'Dim maxCnt As Integer
        'If OUTLIST = "2" Then
        '    maxCnt = 78
        'ElseIf OUTLIST = "3" Then
        '    maxCnt = 47
        'End If
        Dim x As Integer
        ExcelC.pCellStyle(1) = excel_h56px & excel_w50px & excel_backgroundcolor
        ExcelC.pCellStyle(2) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(3) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(4) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(5) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(6) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(7) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(8) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(9) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(10) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(11) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(12) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(13) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(14) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(15) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(16) = excel_h56px & excel_w30px & excel_backgroundcolor
        ExcelC.pCellStyle(17) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(18) = excel_h56px & excel_w60px & excel_backgroundcolor

        ExcelC.pCellStyle(19) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(20) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(21) = excel_h56px & excel_w30px & excel_backgroundcolor
        ExcelC.pCellStyle(22) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(23) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(24) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(25) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(26) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(27) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(28) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(29) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(30) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(31) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(32) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(33) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(34) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(35) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(36) = excel_h56px & excel_w70px & excel_backgroundcolor

        ExcelC.pCellStyle(37) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(38) = excel_h56px & excel_w150px & excel_backgroundcolor
        ExcelC.pCellStyle(39) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(40) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(41) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(42) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(43) = excel_h56px & excel_w70px & excel_backgroundcolor
        If OUTLIST = "2" Then
            ExcelC.pCellStyle(44) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(45) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(46) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(47) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(48) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(49) = excel_h56px & excel_w150px & excel_backgroundcolor
            ExcelC.pCellStyle(50) = excel_h56px & excel_w70px & excel_backgroundcolor
            ExcelC.pCellStyle(51) = excel_h56px & excel_w70px & excel_backgroundcolor
            ExcelC.pCellStyle(52) = excel_h56px & excel_w70px & excel_backgroundcolor
            ExcelC.pCellStyle(53) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(54) = excel_h56px & excel_w40px & excel_backgroundcolor

            ExcelC.pCellStyle(55) = excel_h56px & excel_w100px & excel_backgroundcolor
            ExcelC.pCellStyle(56) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(57) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(58) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(59) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(60) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(61) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(62) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(63) = excel_h56px & excel_w40px & excel_backgroundcolor
            ExcelC.pCellStyle(64) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(65) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(66) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(67) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(68) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(69) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(70) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(71) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(72) = excel_h56px & excel_w100px & excel_backgroundcolor

            ExcelC.pCellStyle(73) = excel_h56px & excel_w60px & excel_backgroundcolor
            ExcelC.pCellStyle(74) = excel_h56px & excel_w70px & excel_backgroundcolor
            ExcelC.pCellStyle(75) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(76) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(77) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(78) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(79) = excel_h56px & excel_w10px & excel_backgroundcolor
        ElseIf OUTLIST = "3" Then
            ExcelC.pCellStyle(44) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(45) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(46) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(47) = excel_h56px & excel_w35px & excel_backgroundcolor
            ExcelC.pCellStyle(48) = excel_h56px & excel_w10px & excel_backgroundcolor
        End If

        i = 1
        ExcelC.pCellVal(i) = Convert.ToString("����") : i += 1                                               '1
        ExcelC.pCellVal(i) = Convert.ToString("�����Z���^�[��") : i += 1                                     '2
        ExcelC.pCellVal(i) = Convert.ToString("�i�`�R�[�h") : i += 1                                         '3
        ExcelC.pCellVal(i) = Convert.ToString("�i�`��") : i += 1                                             '4
        ExcelC.pCellVal(i) = Convert.ToString("�i�`�x���R�[�h") : i += 1                                     '5
        ExcelC.pCellVal(i) = Convert.ToString("�i�`�x����") : i += 1                                         '6
        ExcelC.pCellVal(i) = Convert.ToString("���q�l�R�[�h") : i += 1                                       '7
        ExcelC.pCellVal(i) = Convert.ToString("���q�l��") : i += 1                                           '8
        ExcelC.pCellVal(i) = Convert.ToString("�A����") : i += 1                                             '9
        ExcelC.pCellVal(i) = Convert.ToString("�����ԍ�") : i += 1                                           '10

        ExcelC.pCellVal(i) = Convert.ToString("�Z��") : i += 1                                               '11
        ExcelC.pCellVal(i) = Convert.ToString("������~��") : i += 1                                         '12
        ExcelC.pCellVal(i) = Convert.ToString("����p�~��") : i += 1                                         '13
        ExcelC.pCellVal(i) = Convert.ToString("�n�}�ԍ�") : i += 1                                           '14
        ExcelC.pCellVal(i) = Convert.ToString("�W���敪") : i += 1                                           '15
        ExcelC.pCellVal(i) = Convert.ToString("NCU�ݒu�敪") : i += 1                                        '16
        ExcelC.pCellVal(i) = Convert.ToString("���q�l���") : i += 1                                         '17
        ExcelC.pCellVal(i) = Convert.ToString("��M��") : i += 1                                             '18
        ExcelC.pCellVal(i) = Convert.ToString("��M����") : i += 1                                           '19
        ExcelC.pCellVal(i) = Convert.ToString("���[�^�l") : i += 1                                           '20

        ExcelC.pCellVal(i) = Convert.ToString("���ʋ敪") : i += 1                                           '21
        ExcelC.pCellVal(i) = Convert.ToString("���[�^���") : i += 1                                         '22
        ExcelC.pCellVal(i) = Convert.ToString("�x��P") : i += 1                                             '23
        ExcelC.pCellVal(i) = Convert.ToString("�x��Q") : i += 1                                             '24
        ExcelC.pCellVal(i) = Convert.ToString("�x��R") : i += 1                                             '25
        ExcelC.pCellVal(i) = Convert.ToString("�x��S") : i += 1                                             '26
        ExcelC.pCellVal(i) = Convert.ToString("�x��T") : i += 1                                             '27
        ExcelC.pCellVal(i) = Convert.ToString("�x��U") : i += 1                                             '28
        ExcelC.pCellVal(i) = Convert.ToString("�Ή��敪") : i += 1                                           '29
        ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1                                           '30

        ExcelC.pCellVal(i) = Convert.ToString("�Ď������S��") : i += 1                                       '31
        ExcelC.pCellVal(i) = Convert.ToString("�˗���") : i += 1                                             '32
        ExcelC.pCellVal(i) = Convert.ToString("�˗�����") : i += 1                                           '33
        ExcelC.pCellVal(i) = Convert.ToString("�Ή�������") : i += 1                                         '34
        ExcelC.pCellVal(i) = Convert.ToString("�Ή���������") : i += 1                                       '35
        ExcelC.pCellVal(i) = Convert.ToString("�A������") : i += 1                                           '36
        ExcelC.pCellVal(i) = Convert.ToString("�d�b�A�����e") : i += 1                                       '37
        ExcelC.pCellVal(i) = Convert.ToString("�Ď��Ή����e") : i += 1                                       '38
        ExcelC.pCellVal(i) = Convert.ToString("�������") : i += 1                                           '39
        ExcelC.pCellVal(i) = Convert.ToString("�쓮����") : i += 1                                           '40

        ExcelC.pCellVal(i) = Convert.ToString("�o���˗����e") : i += 1                                       '41
        ExcelC.pCellVal(i) = Convert.ToString("�o���˗����l") : i += 1                                       '42
        ExcelC.pCellVal(i) = Convert.ToString("�����ԍ�(�Ɖ�p)") : i += 1                                   '43
        If OUTLIST = "2" Then
            ExcelC.pCellVal(i) = Convert.ToString("�o���ϑ���") : i += 1                                         '44
            ExcelC.pCellVal(i) = Convert.ToString("�x���E���_��") : i += 1                                       '45
            ExcelC.pCellVal(i) = Convert.ToString("�o���Ή���") : i += 1                                         '46
            ExcelC.pCellVal(i) = Convert.ToString("�Ή�����") : i += 1                                           '47
            ExcelC.pCellVal(i) = Convert.ToString("�K�X�֘A") : i += 1                                           '48
            ExcelC.pCellVal(i) = Convert.ToString("���q�l�̂��b���e") : i += 1                                   '49
            ExcelC.pCellVal(i) = Convert.ToString("���A�Ή�") : i += 1                                           '50

            ExcelC.pCellVal(i) = Convert.ToString("Ұ��쓮�����P") : i += 1                                      '51
            ExcelC.pCellVal(i) = Convert.ToString("�������") : i += 1                                           '52
            ExcelC.pCellVal(i) = Convert.ToString("�o�����ʓ��e/��") : i += 1                                  '53
            ExcelC.pCellVal(i) = Convert.ToString("�K�X�R��_��") : i += 1                                       '54
            ExcelC.pCellVal(i) = Convert.ToString("�i�޽�R��j����") : i += 1                                    '55
            ExcelC.pCellVal(i) = Convert.ToString("�K�X�؂�_��") : i += 1                                       '56
            ExcelC.pCellVal(i) = Convert.ToString("Ұ��_��") : i += 1                                            '57
            ExcelC.pCellVal(i) = Convert.ToString("���ΰ�����") : i += 1                                         '58
            ExcelC.pCellVal(i) = Convert.ToString("������_��") : i += 1                                         '59

            ExcelC.pCellVal(i) = Convert.ToString("�e����������") : i += 1                                     '60
            ExcelC.pCellVal(i) = Convert.ToString("�b�n�Z�x") : i += 1                                           '61
            ExcelC.pCellVal(i) = Convert.ToString("���r�C��") : i += 1                                           '62
            ExcelC.pCellVal(i) = Convert.ToString("�ȈՃK�X���̑ݗ^") : i += 1                                 '63
            ExcelC.pCellVal(i) = Convert.ToString("��M��") : i += 1                                             '64
            ExcelC.pCellVal(i) = Convert.ToString("��M����") : i += 1                                           '65
            ExcelC.pCellVal(i) = Convert.ToString("�o����") : i += 1                                             '66
            ExcelC.pCellVal(i) = Convert.ToString("�o������") : i += 1                                           '67
            ExcelC.pCellVal(i) = Convert.ToString("������") : i += 1                                             '68
            ExcelC.pCellVal(i) = Convert.ToString("��������") : i += 1                                           '69
            ExcelC.pCellVal(i) = Convert.ToString("����������") : i += 1                                         '70

            ExcelC.pCellVal(i) = Convert.ToString("������������") : i += 1                                       '71
            ExcelC.pCellVal(i) = Convert.ToString("�A����E�A������") : i += 1                                 '72
            ExcelC.pCellVal(i) = Convert.ToString("�A������") : i += 1                                           '73
            ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1                                           '74
        End If
        ExcelC.pCellVal(i) = Convert.ToString("FAXJA��") : i += 1                                          '75
        ExcelC.pCellVal(i) = Convert.ToString("FAX�ו�") : i += 1                                          '76
        ExcelC.pCellVal(i) = Convert.ToString("�ݐϕ�") : i += 1                                           '77
        ExcelC.pCellVal(i) = Convert.ToString("�˗���") : i += 1                                             '78
        ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������                                                                

        ''���׃f�[�^�o��
        Dim iCnt As Integer
        'AP�T�[�o����̖߂�l�����[�v����
        '���׃f�[�^�o��
        For iCnt = 0 To ds.Tables(0).Rows.Count - 1
            dr = ds.Tables(0).Rows(iCnt)
            '���׍���
            ExcelC.pCellStyle(1) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(2) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(3) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(4) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(5) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(6) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(7) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(8) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(9) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(10) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(11) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(12) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(13) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(14) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(15) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(16) = excel_h13px & excel_w30px
            ExcelC.pCellStyle(17) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(18) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(19) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(20) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(21) = excel_h13px & excel_w30px
            ExcelC.pCellStyle(22) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(23) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(24) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(25) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(26) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(27) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(28) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(29) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(30) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(31) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(32) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(33) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(34) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(35) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(36) = excel_h13px & excel_w70px

            ExcelC.pCellStyle(37) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(38) = excel_h13px & excel_w150px
            ExcelC.pCellStyle(39) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(40) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(41) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(42) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(43) = excel_h13px & excel_w70px
            If OUTLIST = "2" Then
                ExcelC.pCellStyle(44) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(45) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(46) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(47) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(48) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(49) = excel_h13px & excel_w150px
                ExcelC.pCellStyle(50) = excel_h13px & excel_w70px
                ExcelC.pCellStyle(51) = excel_h13px & excel_w70px
                ExcelC.pCellStyle(52) = excel_h13px & excel_w70px
                ExcelC.pCellStyle(53) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(54) = excel_h13px & excel_w40px

                ExcelC.pCellStyle(55) = excel_h13px & excel_w100px
                ExcelC.pCellStyle(56) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(57) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(58) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(59) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(60) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(61) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(62) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(63) = excel_h13px & excel_w40px
                ExcelC.pCellStyle(64) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(65) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(66) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(67) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(68) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(69) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(70) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(71) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(72) = excel_h13px & excel_w100px

                ExcelC.pCellStyle(73) = excel_h13px & excel_w60px
                ExcelC.pCellStyle(74) = excel_h13px & excel_w70px
                ExcelC.pCellStyle(75) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(76) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(77) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(78) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(79) = excel_h13px & excel_w10px
            ElseIf OUTLIST = "3" Then
                ExcelC.pCellStyle(44) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(45) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(46) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(47) = excel_h13px & excel_w35px
                ExcelC.pCellStyle(48) = excel_h13px & excel_w10px
            End If
            i = 1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1                  '1 ����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYOKYUNM")) : i += 1               '2 �����Z���^�[��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1                   '3 JA�R�[�h
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1                   '4 JA��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1                  '5 JA�x���R�[�h
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1                  '6 JA�x���R�[�h��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1                '7 ���q�l�R�[�h
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1                '8 ���q�l��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1                 '9 �A����
            ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 '10 �����d�b�ԍ�
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1                   '11 �Z��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_STOP")) : i += 1               '12 ������~��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_DELE")) : i += 1               '13 ����p�~��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TIZUNO")) : i += 1                 '14 �n�}�ԍ�
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SHUGOU")) : i += 1                 '15 �W���敪
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM2")) : i += 1             '16 NCU�ݒu�敪
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_FLG")) : i += 1              '17 ���q�l���
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("UNYO")) : i += 1                   '17 ���q�l��� '2017/11/17 H.Mori mod 2017���P�J�� No7-1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1                 '18 ��M��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1                '19 ��M����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1                 '20 ���[�^�l
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1                 '21 ���ʋ敪
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("METASYU")) : i += 1                '22 ���[�^���
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1                  '23 �x��1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1                  '24 �x��2
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1                  '25 �x��3
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1                  '26 �x��4
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1                  '27 �x��5
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1                  '28 �x��6
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1            '29 �Ή��敪
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1              '30 �����敪
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1             '31 �Ď��Z���^�[�S���� 
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1                '32 �˗���
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1               '33 �˗�����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1                 '34 �Ή�������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1                '35 �Ή���������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITNM")) : i += 1                 '36 �A������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1                 '37 �d�b�A�����e
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1 '38 �Ď��Ή����e  '2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) &
                                 Convert.ToString(dr.Item("TEL_MEMO4")) & Convert.ToString(dr.Item("TEL_MEMO5")) & Convert.ToString(dr.Item("TEL_MEMO6")) : i += 1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1                 '39 �������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1                 '40 �쓮����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDNM")) : i += 1                   '41 �o���˗����e
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJI_BIKO1")) : i += 1             '42 �o���˗����l
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYONO")) : i += 1                  '43 �����ԍ�(�Ɖ�p)
            If OUTLIST = "2" Then
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD")) : i += 1                '44 �o���ϑ���
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("STD_KYOTEN")) : i += 1         '45 �x���E���_��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYUTDTNM")) : i += 1           '46 �o���Ή���
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("AITNM")) : i += 1              '47 �Ή�����
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_FLG")) : i += 1            '48 �K�X�֘A
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK1")) : i += 1            '49 ���q�l�̂��b���e
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FKINM")) : i += 1              '50 ���A�Ή�
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1             '51 ���[�^�쓮�����P
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1             '52 �������
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTBIK2")) & Convert.ToString(dr.Item("SNTTOKKI")) & Convert.ToString(dr.Item("SDTBIK3")) : i += 1  '53 �o�����ʓ��e�^��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GASMUMU")) : i += 1            '54 �K�X�R��_��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ORGENIN")) : i += 1            '55 (�K�X�R��)����
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GASGUMU")) : i += 1            '56 �K�X�؂�_��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("METYOINA")) : i += 1           '57 ���[�^�_��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HOSKOKAN")) : i += 1           '58 �S���z�[�X����
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYOUYOINA")) : i += 1          '59 ������_��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("VALYOINA")) : i += 1           '60 �e��E���ԃo���u
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("COYOINA")) : i += 1            '61 CO�Z�x
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYUHAIUMU")) : i += 1          '62 ���r�C��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KIGTAIYO")) : i += 1           '63 �ȈՃK�X���̑ݗ^
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1            '64 ��M��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1           '65 ��M����
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDYMD")) : i += 1              '66 �o����
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDTIME")) : i += 1             '67 �o������
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKYMD")) : i += 1            '68 ������
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TYAKTIME")) : i += 1           '69 ��������
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANYMD")) : i += 1          '70 ����������
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOKANTIME")) : i += 1         '71 ������������
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JAKENREN")) : i += 1           '72 �A���󋵁E�A������
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTIME")) : i += 1            '73 �A������
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDSKBN_NAI")) : i += 1         '74 �����敪
            End If
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1                 '75 FAXJA�� FAX�s�v 1:�s�v/2:�K�v
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1             '76 FAX�ו� �e�`�w�s�v(�ײ���) 1:�s�v/2:�K�v
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXRUISEKIKBN")) : i += 1          '77 �ݐϕ� 1:�s�v/2:�K�v 2016/02/26 H.Mori add �Ď����P2015 ��10
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXSPOTKBN")) : i += 1             '78 �˗���
            ExcelC.pCellVal(i) = "1"
            ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
        Next

        Return ExcelC
    End Function
    '2020/09/15 T.Ono add �Ď����P2020
    '******************************************************************************
    '*�@�T�@�v:EXCEL�o�́iOUTLIST=4�F�l���Ȃ��@���@�����񍐂Ɠ���(�o����ЂȂ�)�j
    '*�@���@�l:�Ή��c�a�擾
    '*         �ЊQ�Ή����[����̏o��
    '******************************************************************************
    Function excelOut4(ByVal OUTLIST As String, ByVal ds As DataSet, ByVal dr As DataRow, ByVal ExcelC As Common.CExcel) As Common.CExcel

        Dim i As Integer
        Dim excel_h13px As String = "height:13px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_h56px As String = "height:56px;text-align:left;font-size:10px;border-style:none;"
        Dim excel_backgroundcolor As String = "background-color:lightgrey;"
        Dim excel_w10px As String = "width:10px;"
        Dim excel_w30px As String = "width:30px;"
        Dim excel_w35px As String = "width:35px;"
        Dim excel_w40px As String = "width:40px;"
        Dim excel_w50px As String = "width:50px;"
        Dim excel_w60px As String = "width:60px;"
        Dim excel_w65px As String = "width:65px;"
        Dim excel_w70px As String = "width:70px;"
        Dim excel_w100px As String = "width:100px;"
        Dim excel_w150px As String = "width:150px;"
        Dim excel_h56px_w10px As String = "height:56px;width:10px;text-align:left;font-size:10px;border-style:none;"
        'Dim maxCnt As Integer
        'If OUTLIST = "2" Then
        '    maxCnt = 78
        'ElseIf OUTLIST = "3" Then
        '    maxCnt = 47
        'End If
        Dim x As Integer
        ExcelC.pCellStyle(1) = excel_h56px & excel_w50px & excel_backgroundcolor
        ExcelC.pCellStyle(2) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(3) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(4) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(5) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(6) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(7) = excel_h56px & excel_w60px & excel_backgroundcolor

        ExcelC.pCellStyle(8) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(9) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(10) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(11) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(12) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(13) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(14) = excel_h56px & excel_w40px & excel_backgroundcolor
        ExcelC.pCellStyle(15) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(16) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(17) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(18) = excel_h56px & excel_w60px & excel_backgroundcolor
        ExcelC.pCellStyle(19) = excel_h56px & excel_w60px & excel_backgroundcolor

        ExcelC.pCellStyle(20) = excel_h56px & excel_w100px & excel_backgroundcolor
        ExcelC.pCellStyle(21) = excel_h56px & excel_w150px & excel_backgroundcolor
        ExcelC.pCellStyle(22) = excel_h56px & excel_w70px & excel_backgroundcolor
        ExcelC.pCellStyle(23) = excel_h56px & excel_w70px & excel_backgroundcolor

        i = 1
        ExcelC.pCellVal(i) = Convert.ToString("����") : i += 1                                               '1
        ExcelC.pCellVal(i) = Convert.ToString("�����Z���^�[��") : i += 1                                     '2
        'ExcelC.pCellVal(i) = Convert.ToString("�i�`�R�[�h") : i += 1                                         '3
        ExcelC.pCellVal(i) = Convert.ToString("�i�`��") : i += 1                                             '4
        'ExcelC.pCellVal(i) = Convert.ToString("�i�`�x���R�[�h") : i += 1                                     '5
        ExcelC.pCellVal(i) = Convert.ToString("�i�`�x����") : i += 1                                         '6
        'ExcelC.pCellVal(i) = Convert.ToString("���q�l�R�[�h") : i += 1                                       '7
        'ExcelC.pCellVal(i) = Convert.ToString("���q�l��") : i += 1                                           '8
        'ExcelC.pCellVal(i) = Convert.ToString("�A����") : i += 1                                             '9
        'ExcelC.pCellVal(i) = Convert.ToString("�����ԍ�") : i += 1                                           '10

        ExcelC.pCellVal(i) = Convert.ToString("�Z��") : i += 1                                               '11
        'ExcelC.pCellVal(i) = Convert.ToString("������~��") : i += 1                                         '12
        'ExcelC.pCellVal(i) = Convert.ToString("����p�~��") : i += 1                                         '13
        'ExcelC.pCellVal(i) = Convert.ToString("�n�}�ԍ�") : i += 1                                           '14
        ExcelC.pCellVal(i) = Convert.ToString("�W���敪") : i += 1                                           '15
        'ExcelC.pCellVal(i) = Convert.ToString("NCU�ݒu�敪") : i += 1                                        '16
        'ExcelC.pCellVal(i) = Convert.ToString("���q�l���") : i += 1                                         '17
        ExcelC.pCellVal(i) = Convert.ToString("��M��") : i += 1                                             '18
        ExcelC.pCellVal(i) = Convert.ToString("��M����") : i += 1                                           '19
        'ExcelC.pCellVal(i) = Convert.ToString("���[�^�l") : i += 1                                           '20

        'ExcelC.pCellVal(i) = Convert.ToString("���ʋ敪") : i += 1                                           '21
        'ExcelC.pCellVal(i) = Convert.ToString("���[�^���") : i += 1                                         '22
        ExcelC.pCellVal(i) = Convert.ToString("�x��P") : i += 1                                             '23
        ExcelC.pCellVal(i) = Convert.ToString("�x��Q") : i += 1                                             '24
        ExcelC.pCellVal(i) = Convert.ToString("�x��R") : i += 1                                             '25
        ExcelC.pCellVal(i) = Convert.ToString("�x��S") : i += 1                                             '26
        ExcelC.pCellVal(i) = Convert.ToString("�x��T") : i += 1                                             '27
        ExcelC.pCellVal(i) = Convert.ToString("�x��U") : i += 1                                             '28
        ExcelC.pCellVal(i) = Convert.ToString("�Ή��敪") : i += 1                                           '29
        'ExcelC.pCellVal(i) = Convert.ToString("�����敪") : i += 1                                           '30

        'ExcelC.pCellVal(i) = Convert.ToString("�Ď������S��") : i += 1                                       '31
        ExcelC.pCellVal(i) = Convert.ToString("�˗���") : i += 1                                             '32
        ExcelC.pCellVal(i) = Convert.ToString("�˗�����") : i += 1                                           '33
        ExcelC.pCellVal(i) = Convert.ToString("�Ή�������") : i += 1                                         '34
        ExcelC.pCellVal(i) = Convert.ToString("�Ή���������") : i += 1                                       '35
        'ExcelC.pCellVal(i) = Convert.ToString("�A������") : i += 1                                           '36
        ExcelC.pCellVal(i) = Convert.ToString("�d�b�A�����e") : i += 1                                       '37
        ExcelC.pCellVal(i) = Convert.ToString("�Ď��Ή����e") : i += 1                                       '38
        ExcelC.pCellVal(i) = Convert.ToString("�������") : i += 1                                           '39
        ExcelC.pCellVal(i) = Convert.ToString("�쓮����") : i += 1                                           '40

        'ExcelC.pCellVal(i) = Convert.ToString("�o���˗����e") : i += 1                                       '41
        'ExcelC.pCellVal(i) = Convert.ToString("�o���˗����l") : i += 1                                       '42
        'ExcelC.pCellVal(i) = Convert.ToString("�����ԍ�(�Ɖ�p)") : i += 1                                   '43
        'ExcelC.pCellVal(i) = Convert.ToString("FAXJA��") : i += 1                                          '75
        'ExcelC.pCellVal(i) = Convert.ToString("FAX�ו�") : i += 1                                          '76
        'ExcelC.pCellVal(i) = Convert.ToString("�ݐϕ�") : i += 1                                           '77
        'ExcelC.pCellVal(i) = Convert.ToString("�˗���") : i += 1                                             '78
        ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������                                                                

        ''���׃f�[�^�o��
        Dim iCnt As Integer
        'AP�T�[�o����̖߂�l�����[�v����
        '���׃f�[�^�o��
        For iCnt = 0 To ds.Tables(0).Rows.Count - 1
            dr = ds.Tables(0).Rows(iCnt)
            '���׍���
            ExcelC.pCellStyle(1) = excel_h13px & excel_w50px
            ExcelC.pCellStyle(2) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(3) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(4) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(5) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(6) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(7) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(8) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(9) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(10) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(11) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(12) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(13) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(14) = excel_h13px & excel_w40px
            ExcelC.pCellStyle(15) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(16) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(17) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(18) = excel_h13px & excel_w60px
            ExcelC.pCellStyle(19) = excel_h13px & excel_w60px

            ExcelC.pCellStyle(20) = excel_h13px & excel_w100px
            ExcelC.pCellStyle(21) = excel_h13px & excel_w150px
            ExcelC.pCellStyle(22) = excel_h13px & excel_w70px
            ExcelC.pCellStyle(23) = excel_h13px & excel_w70px

            i = 1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENNM")) : i += 1                  '1 ����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KYOKYUNM")) : i += 1               '2 �����Z���^�[��
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JACD")) : i += 1                   '3 JA�R�[�h
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JANM")) : i += 1                   '4 JA��
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBCD")) : i += 1                  '5 JA�x���R�[�h
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ACBNM")) : i += 1                  '6 JA�x���R�[�h��
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1                '7 ���q�l�R�[�h
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JUSYONM")) : i += 1                '8 ���q�l��
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RENTEL")) : i += 1                 '9 �A����
            'ExcelC.pCellVal(i) = fncSetJUTEL(Convert.ToString(dr.Item("JUTEL1")), Convert.ToString(dr.Item("JUTEL2"))) : i += 1 '10 �����d�b�ԍ�
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1                   '11 �Z��
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_STOP")) : i += 1               '12 ������~��
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GAS_DELE")) : i += 1               '13 ����p�~��
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TIZUNO")) : i += 1                 '14 �n�}�ԍ�
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SHUGOU")) : i += 1                 '15 �W���敪
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_SETNM2")) : i += 1             '16 NCU�ݒu�敪
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_FLG")) : i += 1              '17 ���q�l���
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("UNYO")) : i += 1                   '17 ���q�l��� '2017/11/17 H.Mori mod 2017���P�J�� No7-1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATYMD")) : i += 1                 '18 ��M��
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HATTIME")) : i += 1                '19 ��M����
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KENSIN")) : i += 1                 '20 ���[�^�l
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("RYURYO")) : i += 1                 '21 ���ʋ敪
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("METASYU")) : i += 1                '22 ���[�^���
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM1")) : i += 1                  '23 �x��1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM2")) : i += 1                  '24 �x��2
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM3")) : i += 1                  '25 �x��3
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM4")) : i += 1                  '26 �x��4
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM5")) : i += 1                  '27 �x��5
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KMNM6")) : i += 1                  '28 �x��6
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAIOKBN_NAI")) : i += 1            '29 �Ή��敪
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TMSKB_NAI")) : i += 1              '30 �����敪
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKTANCD_NM")) : i += 1             '31 �Ď��Z���^�[�S���� 
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJIYMD")) : i += 1                '32 �˗���
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJITIME")) : i += 1               '33 �˗�����
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOYMD")) : i += 1                 '34 �Ή�������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYOTIME")) : i += 1                '35 �Ή���������
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TAITNM")) : i += 1                 '36 �A������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TELRNM")) : i += 1                 '37 �d�b�A�����e
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) : i += 1 '38 �Ď��Ή����e  '2020/11/01 T.Ono mod 2020�Ď����P
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TEL_MEMO1")) & Convert.ToString(dr.Item("TEL_MEMO2")) & Convert.ToString(dr.Item("FUK_MEMO")) &
                                 Convert.ToString(dr.Item("TEL_MEMO4")) & Convert.ToString(dr.Item("TEL_MEMO5")) & Convert.ToString(dr.Item("TEL_MEMO6")) : i += 1
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TKIGNM")) : i += 1                 '39 �������
            ExcelC.pCellVal(i) = Convert.ToString(dr.Item("TSADNM")) : i += 1                 '40 �쓮����
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SDNM")) : i += 1                   '41 �o���˗����e
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SIJI_BIKO1")) : i += 1             '42 �o���˗����l
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("SYONO")) : i += 1                  '43 �����ԍ�(�Ɖ�p)
            If OUTLIST = "2" Then
            End If
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKBN")) : i += 1                 '75 FAXJA�� FAX�s�v 1:�s�v/2:�K�v
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXKURAKBN")) : i += 1             '76 FAX�ו� �e�`�w�s�v(�ײ���) 1:�s�v/2:�K�v
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXRUISEKIKBN")) : i += 1          '77 �ݐϕ� 1:�s�v/2:�K�v 2016/02/26 H.Mori add �Ď����P2015 ��10
            'ExcelC.pCellVal(i) = Convert.ToString(dr.Item("FAXSPOTKBN")) : i += 1             '78 �˗���
            'ExcelC.pCellVal(i) = "1"
            ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
        Next

        Return ExcelC
    End Function
    '******************************************************************************
    '*�@�T�@�v:�r�d�k�d�b�s�����쐬
    '*�@���@�l:�Ή��c�a�擾
    '******************************************************************************
    '2014/12/10 H.Hosoda mod �Ď����P2014 ��13 ������ǉ�
    '2019/11/01 T.Ono mod �Ď����P2019 pstrJACDFrom_CLI,pstrJACDTo_CLI �ǉ�
    '2020/01/06 T.Ono mod �ЊQ�Ή����[ psrtTSADNM �ǉ�
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
    '2017/02/16 H.Mori mod ���P2016 No8-2 ������ǉ�
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
    '                              ByVal pstrJACDTo As String, _
    '                              ByVal pstrHANGRPFrom As String, _
    '                              ByVal pstrHANGRPTo As String, _
    '                              ByVal pstrOUTKBN As String, _
    '                              ByVal pstrKIKANKBN As String) As String
    '2017/02/17 W.GANEKO mod �Ď����P2016 ��7 ������ǉ� START
    'Public Function fncMakeSelect(ByVal pstrKANSCD As String, _
    '                          ByVal pstrTFKICD As String, _
    '                          ByVal pstrStkbn1 As String, _
    '                          ByVal pstrStkbn2 As String, _
    '                          ByVal pstrPgkbn1 As String, _
    '                          ByVal pstrPgkbn2 As String, _
    '                          ByVal pstrPgkbn3 As String, _
    '                          ByVal pstrTrgFrom As String, _
    '                          ByVal pstrTrgTo As String, _
    '                          ByVal pstrKURACDFrom As String, _
    '                          ByVal pstrKURACDTo As String, _
    '                          ByVal pstrJACDFrom As String, _
    '                          ByVal pstrJACDTo As String, _
    '                          ByVal pstrHANGRPFrom As String, _
    '                          ByVal pstrHANGRPTo As String, _
    '                          ByVal pstrOUTKBN As String, _
    '                          ByVal pstrKIKANKBN As String, _
    '                          ByVal pstrTrgTimeFrom As String, _
    '                          ByVal pstrTrgTimeTo As String) As String
    Public Function fncMakeSelect(ByVal pstrKANSCD As String,
                                  ByVal pstrTFKICD As String,
                                  ByVal pstrStkbn1 As String,
                                  ByVal pstrStkbn2 As String,
                                  ByVal pstrPgkbn1 As String,
                                  ByVal pstrPgkbn2 As String,
                                  ByVal pstrPgkbn3 As String,
                                  ByVal pstrTrgFrom As String,
                                  ByVal pstrTrgTo As String,
                                  ByVal pstrKURACDFrom As String,
                                  ByVal pstrKURACDTo As String,
                                  ByVal pstrJACDFrom As String,
                                  ByVal pstrJACDFromCLI As String,
                                  ByVal pstrJACDTo As String,
                                  ByVal pstrJACDTo_CLI As String,
                                  ByVal pstrHANGRPFrom As String,
                                  ByVal pstrHANGRPTo As String,
                                  ByVal pstrOUTKBN As String,
                                  ByVal pstrKIKANKBN As String,
                                  ByVal pstrTrgTimeFrom As String,
                                  ByVal pstrTrgTimeTo As String,
                                  ByVal pstrHOKBN As String,
                                  ByVal pstrOUTLIST As String,
                                  ByVal pstrTFKINM As String,
                                  ByVal pstrTSADCD As String,
                                  ByVal pstrTSADNM As String) As String
        '2017/02/17 W.GANEKO mod �Ď����P2016 ��7 END
        Dim strSQL As New StringBuilder("")

        '2016/05/02 T.Ono mod �Ď����P2015 ��10�C�� START
        ''2016/04/20 H.Mori mod �Ď����P2015 �ŏI�˓d��C�� START
        ''2016/02/01 H.Mori add �Ď����P2015 �ŏI�˓d�� START
        'strSQL.Append("WITH ")
        'strSQL.Append("TEL AS ( ")
        ''strSQL.Append("SELECT C.KOK_TELNO,C.EXEC_KBN,C.SEQNO ")
        ''strSQL.Append("FROM   S04_TELLOGDB C ")
        ''strSQL.Append("       ,(SELECT MAX(B.EXEC_YMD || LPAD(B.EXEC_TIME, 6, '0')) AS YMD, B.SEQNO ")
        ''strSQL.Append("       FROM D20_TAIOU A,S04_TELLOGDB B ")
        ''strSQL.Append("       WHERE A.SYONO = B.SEQNO ")
        ''strSQL.Append("       AND 1 = B.EXEC_KBN ")
        ''strSQL.Append("       GROUP BY B.SEQNO) TEL ")
        ''strSQL.Append("WHERE  C.SEQNO = TEL.SEQNO ")
        ''strSQL.Append("AND    (C.EXEC_YMD || LPAD(C.EXEC_TIME, 6, '0')) = TEL.YMD) ")
        ''2016/02/01 H.Mori add �Ď����P2015 �ŏI�˓d�� END
        'strSQL.Append("SELECT ")
        'strSQL.Append(" B.KOK_TELNO, ")
        'strSQL.Append(" B.SEQNO ")
        'strSQL.Append("FROM( ")
        'strSQL.Append("     SELECT ")
        'strSQL.Append("           C.SEQNO, ")
        'strSQL.Append("           MAX(C.EXEC_YMD || LPAD(C.EXEC_TIME, 6, '0')) AS YMD ")
        'strSQL.Append("     FROM  S04_TELLOGDB C ")
        'strSQL.Append("     WHERE C.EXEC_KBN = '1' ")
        'strSQL.Append("     AND   C.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_FROM, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        'strSQL.Append("                      AND     TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_TO, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        'strSQL.Append("     GROUP BY ")
        'strSQL.Append("           C.SEQNO ")
        'strSQL.Append("    ) A ")
        'strSQL.Append("INNER JOIN S04_TELLOGDB B ON A.SEQNO = B.SEQNO ")
        'strSQL.Append("                          AND A.YMD = B.EXEC_YMD || LPAD(B.EXEC_TIME, 6, '0') ")
        'strSQL.Append("WHERE B.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_FROM, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        'strSQL.Append("                 AND     TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_TO, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        'strSQL.Append(" ) ")
        ''2016/04/20 H.Mori mod �Ď����P2015 �ŏI�˓d��C�� END
        strSQL.Append("WITH ")
        strSQL.Append("TEL AS ( ")
        strSQL.Append("SELECT C.SEQNO, ")
        strSQL.Append("       C.KOK_TELNO ")
        strSQL.Append("FROM ( ")
        strSQL.Append("  SELECT ROWNUM AS NUM, ")
        strSQL.Append("         B.SEQNO, ")
        strSQL.Append("         B.KOK_TELNO ")
        strSQL.Append("  FROM ( ")
        strSQL.Append("    SELECT A.SEQNO, ")
        strSQL.Append("           A.KOK_TELNO ")
        strSQL.Append("    FROM   S04_TELLOGDB A ")
        strSQL.Append("    WHERE  A.EXEC_KBN = '1' ")
        strSQL.Append("    AND    A.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_FROM, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        strSQL.Append("                      AND     TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_TO, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        strSQL.Append("    ORDER BY A.SEQNO, A.ADD_DATE, A.TIME, LPAD(A.EDANO,2,'0') ")
        strSQL.Append("    ) B ")
        strSQL.Append("  ) C ")
        strSQL.Append("WHERE NOT EXISTS ( ")
        strSQL.Append("  SELECT 'X' ")
        strSQL.Append("  FROM ( ")
        strSQL.Append("    SELECT ROWNUM AS NUM, ")
        strSQL.Append("           E.SEQNO ")
        strSQL.Append("    FROM ( ")
        strSQL.Append("      SELECT D.SEQNO ")
        strSQL.Append("      FROM   S04_TELLOGDB D ")
        strSQL.Append("      WHERE  D.EXEC_KBN = '1' ")
        strSQL.Append("      AND    D.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_FROM, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        strSQL.Append("                        AND     TO_CHAR(ADD_MONTHS(TO_DATE(:TRGDATE_TO, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        strSQL.Append("      ORDER BY D.SEQNO, D.ADD_DATE, D.TIME, LPAD(D.EDANO,2,'0') ")
        strSQL.Append("      ) E ")
        strSQL.Append("    ) F ")
        strSQL.Append("  WHERE C.SEQNO = F.SEQNO ")
        strSQL.Append("  AND   C.NUM < F.NUM ")
        strSQL.Append("  ) ")
        strSQL.Append(") ")
        '2016/05/02 T.Ono mod �Ď����P2015 ��10�C�� END

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
        strSQL.Append("    DECODE(TAI.FAXRUISEKIKBN, '2', '��', ' ') AS FAXRUISEKIKBN, ") ' 2016/02/26 H.Mori add 2015�Ď����P ��10
        strSQL.Append("    TAI.NCUHATYMD, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.NCUHATTIME, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        '2013/11/01 T.Ono mod �Ή���ʂ̎�M�������o�͂���悤�ɕύX
        'strSQL.Append("    TAI.JUYMD, ")                                            ' 2008/11/11 T.Watabe edit
        'strSQL.Append("    TAI.JUTIME, ")
        strSQL.Append("    TAI.HATYMD, ")
        strSQL.Append("    TAI.HATTIME, ")
        strSQL.Append("    ROUND((TO_DATE(TAI.HATYMD || SUBSTR(TAI.HATTIME,0,4), 'YYYYMMDDHH24MISS') - TO_DATE(TAI.NCUHATYMD || TAI.NCUHATTIME, 'YYYYMMDDHH24MISS'))  * 1440) AS CHIEN, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.RYURYO, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        '2015/04/09 H.Mori mod �Ď����P2015 ���ނȂ��A���̂���̏ꍇ���\������ START
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
        '2015/04/09 H.Mori mod �Ď����P2015 ���ނȂ��A���̂���̏ꍇ���\������ END
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
        'strSQL.Append("    KOK.TUSIN, ") ' 2013/08/29 T.Ono add �Ď����P2013��8
        strSQL.Append("    TAI.TUSIN, ") ' 2017/02/17 W.GANEKO add �Ď����P2016 ��7
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
        strSQL.Append("    TAI.TEL_MEMO4, ")    '2020/11/01 T.Ono add �Ď����P2020
        strSQL.Append("    TAI.TEL_MEMO5, ")    '2020/11/01 T.Ono add �Ď����P2020
        strSQL.Append("    TAI.TEL_MEMO6, ")    '2020/11/01 T.Ono add �Ď����P2020
        strSQL.Append("    TAI.FAX_REN, ") ' 2014/12/10 H.Hosoda add �Ď����P2014 ��13
        strSQL.Append("    TAI.KANSHI_BIKO, ") ' 2016/2/1 H.Mori add �Ď����P2015 ��10
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
        strSQL.Append("    ,TEL.KOK_TELNO ")   '2016/2/1 H.Mori add �Ď����P2015 ��10
        '2017/02/17 W.GANEKO 2016�Ď����P ��7 START
        strSQL.Append("    ,DECODE(TAI.FAXSPOTKBN, '2', '��', ' ') AS FAXSPOTKBN ") '�˗���
        strSQL.Append("    ,TAI.DAIHYO_NAME ")         '��\�Ҏ���
        strSQL.Append("    ,TAI.HANBCD ")              '�̔����R�[�h
        strSQL.Append("    ,DECODE(TAI.HOKBN,'1','1:�t�Ζ@','2','2:�����@','3','3:�t�Ζ@�E�����@','4','4:�K�X���Ɩ@','5','5:�K�p�O',TAI.HOKBN) AS HOKBN ") '�K�p�@�ߋ敪
        strSQL.Append("    ,DECODE(TAI.KYOKTKBN,'1','1:���','2','2:�W��','3','3:�ȃK�X',TAI.KYOKTKBN) AS KYOKTKBN ")                                      '�����`�ԋ敪
        strSQL.Append("    ,DECODE(TAI.YOTOKBN,'1','1:�ƒ�p','2','2:�Ɩ��p','3','3:�_�Ɨp','4','4:�H�Ɨp','5','5:���̑�',TAI.YOTOKBN) AS YOTOKBN ")       '�p�r�敪
        '2017/10/27 H.Mori mod 2017���P�J�� No7-1 START
        'strSQL.Append("    ,KOK.GAS_STOP ")
        'strSQL.Append("    ,KOK.GAS_DELE ")
        strSQL.Append("    ,TAI.GAS_STOP ")            '������~��
        strSQL.Append("    ,TAI.GAS_DELE ")            '����p�~��
        '2017/10/27 H.Mori mod 2017���P�J�� No7-1 END
        strSQL.Append("    ,HAI.NAME AS KYOKYUNM ")    '�����Z���^�[��
        '2017/10/27 H.Mori mod 2017���P�J�� No7-1 START
        'strSQL.Append("    ,DECODE(KOK.USER_FLG, '0', '0:���J��', '1', '1:�^�p��', '2', '2:�x�~��', KOK.USER_FLG) AS USER_FLG ")   
        strSQL.Append("    ,DECODE(TAI.UNYO, '0', '0:���J��', '1', '1:�^�p��', '2', '2:�x�~��', TAI.UNYO) AS UNYO ")   '���q�l���
        '2017/10/27 H.Mori mod 2017���P�J�� No7-1 END
        strSQL.Append("    ,TAI.TAITNM ")              '�A������
        strSQL.Append("    ,TAI.SDNM ")                '�o���˗����e
        strSQL.Append("    ,DECODE(TAI.NCU_SET, '3', '3:��', TAI.NCU_SET||':�L') AS NCU_SETNM2 ") 'NCU�ݒu�敪
        strSQL.Append("    ,TAI.TIZUNO ")              '�n�}�ԍ�
        strSQL.Append("    ,TAI.METASYU ")             '���[�^���
        strSQL.Append("    ,TAI.SIJI_BIKO1 ")          '�w���˗����l
        strSQL.Append("    ,TAI.SYONO ")               '�����ԍ�(�Ɖ�p) 
        strSQL.Append("    ,TAI.STD_KYOTEN ")          '�x���E���_��
        strSQL.Append("    ,TAI.AITNM ")               '�Ή�����
        strSQL.Append("    ,TAI.SDTBIK1 ")             '���q�l�̂��b���e
        strSQL.Append("    ,TAI.FKINM ")               '���A�Ή�
        strSQL.Append("    ,TAI.TSADNM ")              '���[�^�쓮�����P
        strSQL.Append("    ,TAI.TKIGNM ")              '�������
        strSQL.Append("    ,TAI.JAKENREN ")            '�A���󋵁E�A������
        strSQL.Append("    ,TAI.RENTIME ")             '�A������
        strSQL.Append("    ,TAI.SDSKBN_NAI ")          '�����敪
        strSQL.Append("    ,(CASE ")                   '�K�X�֘A
        strSQL.Append("        WHEN TAI.METFUKKI = '1' THEN '1:���[�^���A' ")
        strSQL.Append("        WHEN TAI.HOAN = '1' THEN '1:�ۈ�' ")
        strSQL.Append("        WHEN TAI.GASGIRE = '1' THEN '1:�K�X�؂�' ")
        strSQL.Append("        WHEN TAI.KIGKOSYO = '1' THEN '1:���̏�' ")
        strSQL.Append("        WHEN TAI.CSNTGEN = '1' THEN '1:���̑�' ")
        strSQL.Append("        ELSE NULL ")
        strSQL.Append("     END) AS GAS_FLG ")
        '2017/10/27 H.Mori mod 2017���P�J�� No7-1 START
        'strSQL.Append("    ,KOK.SHUGOU || DECODE(PL6.NAME,NULL,NULL,':'||PL6.NAME) AS SHUGOU ")        
        strSQL.Append("    ,TAI.SHUGOU || DECODE(PL6.NAME,NULL,NULL,':'||PL6.NAME) AS SHUGOU ")         '�W���敪
        '2017/10/27 H.Mori mod 2017���P�J�� No7-1 END
        strSQL.Append("    ,DECODE(TAI.GASMUMU, '0', '0:�L', TAI.GASMUMU||':��') AS GASMUMU ")          '�K�X�R��_��
        strSQL.Append("    ,DECODE(TAI.ORGENIN, '1', '1:�K�X���', TAI.ORGENIN) AS ORGENIN ")           '(�K�X�R��)����
        strSQL.Append("    ,DECODE(TAI.GASGUMU, '0', '0:�L', TAI.GASGUMU||':��') AS GASGUMU ")          '�K�X�؂�_��
        strSQL.Append("    ,DECODE(TAI.METYOINA, '0', '0:��', TAI.METYOINA||':��') AS METYOINA ")       '���[�^�_��
        strSQL.Append("    ,DECODE(TAI.HOSKOKAN, '0', '0:���{', TAI.HOSKOKAN||':�����{') AS HOSKOKAN ") '�S���z�[�X����
        strSQL.Append("    ,DECODE(TAI.TYOUYOINA, '0', '0:��', TAI.TYOUYOINA||':��') AS TYOUYOINA ")    '������_��
        strSQL.Append("    ,DECODE(TAI.VALYOINA, '0', '0:��', TAI.VALYOINA||':��') AS VALYOINA ")       '�e��E���ԃo���u
        strSQL.Append("    ,DECODE(TAI.COYOINA, '0', '0:��', TAI.COYOINA||':��') AS COYOINA ")          'CO�Z�x
        strSQL.Append("    ,DECODE(TAI.KYUHAIUMU, '0', '0:��', TAI.KYUHAIUMU||':��') AS KYUHAIUMU ")    '���r�C��
        strSQL.Append("    ,DECODE(TAI.KIGTAIYO, '1', '1:�L', TAI.KIGTAIYO||':��') AS KIGTAIYO ")       '�ȈՃK�X���̑ݗ^
        '2017/02/17 W.GANEKO 2016�Ď����P ��7 END
        ' 2023/01/11 ADD START Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�
        strSQL.Append("    ,KINRENCD ")       'JM�R�[�h�i�i�`�S���ҕ񍐐�R�[�h�j
        strSQL.Append("    ,JMNAME ")         'JM�a���i�i�`�S���ҕ񍐐於�j
        ' 2023/01/11 ADD END   Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�
        strSQL.Append("FROM ")
        strSQL.Append("    D20_TAIOU TAI")
        '2013/10/30 �Ď����P2013��8
        strSQL.Append("    LEFT JOIN SHAMAS KOK ON TAI.KURACD = KOK.CLI_CD  ")
        strSQL.Append("                         AND TAI.ACBCD = KOK.HAN_CD ")
        strSQL.Append("                         AND TAI.USER_CD = KOK.USER_CD ")
        '2017/02/17 �Ď����P2016��7 W.GANEKO
        strSQL.Append("    LEFT JOIN HN2MAS HN2 ON TAI.KURACD = HN2.CLI_CD  ")
        strSQL.Append("                         AND TAI.ACBCD = HN2.HAN_CD ")
        strSQL.Append("    LEFT JOIN HAIMAS HAI ON SUBSTR(HN2.CLI_CD,2,2) = HAI.KEN_CD  ")
        strSQL.Append("                         AND HN2.HAISO_CD = HAI.HAISO_CD ")
        '2017/10/27 H.Mori mod 2017���P�J�� No7-1 START
        'strSQL.Append("    LEFT JOIN M06_PULLDOWN PL6 ON PL6.KBN = '03' AND PL6.CD = KOK.SHUGOU ")
        strSQL.Append("    LEFT JOIN M06_PULLDOWN PL6 ON PL6.KBN = '03' AND PL6.CD = TAI.SHUGOU ")
        '2017/10/27 H.Mori mod 2017���P�J�� No7-1 END
        'End If
        strSQL.Append("    LEFT JOIN TEL ON TAI.SYONO = TEL.SEQNO  ") '2016/2/1 H.Mori add �Ď����P2015 ��10

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
            '2019/11/01 T.Ono add �Ď����P2019
            'strSQL.Append(" AND TAI.JACD >= :JACD_FROM ")
            strSQL.Append(" AND TAI.KURACD || TAI.JACD >= :JACD_FROM_CLI || :JACD_FROM ")
        End If
        If pstrJACDTo <> "" Then
            '2019/11/01 T.Ono add �Ď����P2019
            'strSQL.Append(" AND TAI.JACD <= :JACD_TO ")
            strSQL.Append(" AND TAI.KURACD || TAI.JACD <= :JACD_TO_CLI || :JACD_TO ")
        End If

        '�̔����Ǝ҃O���[�v�R�[�h  2014/12/12 H.Hosoda add �Ď����P2014 ��13
        If pstrHANGRPFrom <> "" Then
            '2019/11/01 T.Ono mod �Ď����P2019 START
            'strSQL.Append(" AND TAI.HANJICD >= :HANGRP_FROM ")
            If pstrKURACDFrom <> "" Then
                strSQL.Append(" AND TAI.KURACD || TAI.HANJICD >= :KURACD_FROM || :HANGRP_FROM ")
            Else
                strSQL.Append(" AND TAI.HANJICD >= :HANGRP_FROM ")
            End If
            '2019/11/01 T.Ono mod �Ď����P2019 END
        End If
        If pstrHANGRPTo <> "" Then
            '2019/11/01 T.Ono mod �Ď����P2019 START
            'strSQL.Append(" AND TAI.HANJICD <= :HANGRP_TO ")
            If pstrKURACDTo <> "" Then
                strSQL.Append(" AND TAI.KURACD || TAI.HANJICD <= :KURACD_TO || :HANGRP_TO ")
            Else
                strSQL.Append(" AND TAI.HANJICD <= :HANGRP_TO ")
            End If
            '2019/11/01 T.Ono mod �Ď����P2019 END
        End If

        '2017/02/16 H.Mori mod ���P2016 No7-1 �Ώێ��Ԓǉ� START
        '2014/12/11 H.Hosoda mod �Ď����P2014 ��13 START
        '������
        'strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        '�Ώۊ���
        'If pstrKIKANKBN = "1" Then '�Ή�������
        '    strSQL.Append(" AND TAI.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        'Else                       '��M��
        '    strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        'End If
        '2014/12/11 H.Hosoda mod �Ď����P2014 ��13 END
        If pstrKIKANKBN = "1" Then '�Ή�������
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strSQL.Append(" AND TAI.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strSQL.Append(" AND TAI.SYOYMD || TAI.SYOTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        Else                       '��M��
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strSQL.Append(" AND TAI.HATYMD || TAI.HATTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        End If
        '2017/02/16 H.Mori mod ���P2016 No7-1 �Ώێ��Ԓǉ� END

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
        '2017/02/17 W.GANEKO ADD 2016�Ď����P ��7 START
        '�@�ߋ敪
        If pstrHOKBN = "1" Then '�����v
            '�����w�肵�Ȃ�
        ElseIf pstrHOKBN = "2" Then '�t��
            strSQL.Append(" AND ( ")
            strSQL.Append("    TAI.HOKBN IN ('1','3') ")
            strSQL.Append("   OR ")
            strSQL.Append("   ((TAI.HOKBN NOT IN ('1','2','3','4','5') OR TAI.HOKBN IS NULL) AND TAI.KYOKTKBN IN ('1','2')) ")
            strSQL.Append(" ) ")
        ElseIf pstrHOKBN = "3" Then '���̑�
            strSQL.Append(" AND ( ")
            strSQL.Append("    TAI.HOKBN IN ('2','4','5') ")
            strSQL.Append("   OR ")
            strSQL.Append("   ((TAI.HOKBN NOT IN ('1','2','3','4','5') OR TAI.HOKBN IS NULL) AND (TAI.KYOKTKBN NOT IN ('1','2') OR TAI.KYOKTKBN IS NULL)) ")
            strSQL.Append(" ) ")
        End If
        '2017/02/17 W.GANEKO ADD 2016�Ď����P ��7 END
        '���A�Ή���
        If pstrTFKICD.Length <> 0 Then
            strSQL.Append(" AND TAI.TFKICD = :TFKICD ")
        End If
        '2020/01/06 T.Ono add �ЊQ�Ή����[
        If pstrTSADCD.Length <> 0 Then
            strSQL.Append(" AND TAI.TSADCD = :TSADCD ")
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
        strSQL.Append(" ORDER BY ")
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
        'mlog(strSQL.ToString & ":" & pstrHOKBN & ":" & pstrOUTLIST)
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
    '**********************************************************
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        'Dim LogC As New CLog
        Dim strRecLog As String
        Dim strRec As String
        Dim bytesData As Byte()

        Dim linestring As String = ""
        'If strLogFlg = "1" Then
        '�������݃t�@�C���ւ̃X�g���[��
        Dim sw As StreamWriter
        Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)

        linestring = System.DateTime.Now & "|" & pstrString + vbCrLf
        sw = New StreamWriter(fs, System.Text.Encoding.Default)

        '�����̕�������X�g���[���ɏ�������
        sw.Write(linestring)

        '�������t���b�V���i�t�@�C���������݁j
        'sw.Flush()

        '�t�@�C���N���[�Y
        sw.Close()
        sw.Dispose()
        fs.Close()
        fs.Dispose()
        'End If

    End Sub
End Class
