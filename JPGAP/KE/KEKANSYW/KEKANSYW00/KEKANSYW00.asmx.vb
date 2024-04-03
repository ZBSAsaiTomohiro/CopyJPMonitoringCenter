'***************************************************************************
'  �Ď��Ή����W�v�\
'***************************************************************************
' �ύX����
' 2008/11/21 T.Watabe �V�K�쐬
' 2009/02/17 T.Watabe �o�������́A���A�Ή��󋵁��W�F�ً}�o���i�o����Ёj��ΏۂƂ���悤�ɕύX
' 2010/03/09 T.Watabe �Ή��敪���d���𒠕[�Ɋ܂�or�܂܂Ȃ��̏�����ǉ�
' 2010/03/10 T.Watabe �\�����ڂ�ǉ�
' 2019/11/01 W.GANEKO JA���̂ō폜�t���O��1�̃f�[�^�̂ݕ\��


Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KEKANSYW00/Service1")> _
Public Class KEKANSYW00
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
    '2017/02/16 H.Mori mod ���P2016 No8-2 �����ύX
    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 �����ύX
    '2020/11/01 T.Ono mod   �Ď����P2020�@�����ύX pstrTSADCD �ǉ�
    '<WebMethod()> Public Function mCheck( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrJacd As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal _
    '                                    ) As String
    '<WebMethod()> Public Function mCheck( _
    '                                    ByVal pstrKuracdFrom As String, _
    '                                    ByVal pstrKuracdTo As String, _
    '                                    ByVal pstrJacdFrom As String, _
    '                                    ByVal pstrJacdTo As String, _
    '                                    ByVal pstrHangrpFrom As String, _
    '                                    ByVal pstrHangrpTo As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrHasseiTel As String, _
    '                                    ByVal pstrHasseiKei As String, _
    '                                    ByVal pstrTaiouTel As String, _
    '                                    ByVal pstrTaiouShu As String, _
    '                                    ByVal pstrTaiouJuf As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrTrgdatekbn As String, _
    '                                    ByVal pdecPageMax As Decimal _
    '                                    ) As String
    <WebMethod()> Public Function mCheck(
                                        ByVal pstrKuracdFrom As String,
                                        ByVal pstrKuracdTo As String,
                                        ByVal pstrJacdFrom As String,
                                        ByVal pstrJacdTo As String,
                                        ByVal pstrHangrpFrom As String,
                                        ByVal pstrHangrpTo As String,
                                        ByVal pstrPgkbn As String,
                                        ByVal pstrHasseiTel As String,
                                        ByVal pstrHasseiKei As String,
                                        ByVal pstrTaiouTel As String,
                                        ByVal pstrTaiouShu As String,
                                        ByVal pstrTaiouJuf As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrTrgdatekbn As String,
                                        ByVal pdecPageMax As Decimal,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrTsadcd As String
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
            '2017/02/16 H.Mori mod ���P2016 No8-2 START
            '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
            '2020/11/01 T.Ono mod �Ď����P2020 pstrTsadcd �ǉ�
            'cdb.pSQL = fncMakeSelect(2, _
            '                         pstrKuracd, _
            '                         pstrJacd, _
            '                         pstrTrgFrom, _
            '                         pstrTrgTo, _
            '                         "", _
            '                         "", _
            '                         pdecPageMax)

            'cdb.pSQL = fncMakeSelect(2, _
            '                          pstrKuracdFrom, _
            '                          pstrKuracdTo, _
            '                          pstrJacdFrom, _
            '                          pstrJacdTo, _
            '                          pstrHangrpFrom, _
            '                          pstrHangrpTo, _
            '                          pstrTrgFrom, _
            '                          pstrTrgTo, _
            '                          pstrPgkbn, _
            '                          pstrHasseiTel, _
            '                          pstrHasseiKei, _
            '                          pstrTaiouTel, _
            '                          pstrTaiouShu, _
            '                          pstrTaiouJuf, _
            '                          pstrTrgdatekbn, _
            '                          pdecPageMax)
            '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End
            cdb.pSQL = fncMakeSelect(2,
                                      pstrKuracdFrom,
                                      pstrKuracdTo,
                                      pstrJacdFrom,
                                      pstrJacdTo,
                                      pstrHangrpFrom,
                                      pstrHangrpTo,
                                      pstrTrgFrom,
                                      pstrTrgTo,
                                      pstrPgkbn,
                                      pstrHasseiTel,
                                      pstrHasseiKei,
                                      pstrTaiouTel,
                                      pstrTaiouShu,
                                      pstrTaiouJuf,
                                      pstrTrgdatekbn,
                                      pdecPageMax,
                                      pstrTrgTimeFrom,
                                      pstrTrgTimeTo,
                                      pstrTsadcd)
            '2017/02/16 H.Mori mod ���P2016 No8-2 END

            '�p�����[�^�Z�b�g
            '2015/02/10 H.Hosoda mod �Ď����P2014 ��14 Start
            'If pstrKuracd.Length <> 0 Then
            '    cdb.pSQLParamStr("KURACD") = pstrKuracd
            'End If
            'If pstrJacd.Length > 0 Then cdb.pSQLParamStr("JACD") = pstrJacd
            'If pstrTrgFrom.Length > 0 Then cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            'If pstrTrgTo.Length > 0 Then cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            '�N���C�A���g�R�[�h
            If pstrKuracdFrom <> "" Then
                cdb.pSQLParamStr("KURACD_FROM") = pstrKuracdFrom
            End If
            If pstrKuracdTo <> "" Then
                cdb.pSQLParamStr("KURACD_TO") = pstrKuracdTo
            End If
            '�i�`�R�[�h ' @
            If pstrJacdFrom <> "" Then
                cdb.pSQLParamStr("JACD_FROM") = pstrJacdFrom
            End If
            If pstrJacdTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJacdTo
            End If
            '�̔����Ǝ҃O���[�v�R�[�h
            If pstrHangrpFrom <> "" Then
                cdb.pSQLParamStr("HANGRP_FROM") = pstrHangrpFrom
            End If
            If pstrHangrpTo <> "" Then
                cdb.pSQLParamStr("HANGRP_TO") = pstrHangrpTo
            End If
            '�Ή��������܂��͎�M��
            If pstrTrgFrom <> "" Then
                cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            End If
            If pstrTrgTo <> "" Then
                cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            End If
            '�Ή����������܂��͎�M�����@2017/02/16 H.Mori add ���P2016 No8-2 
            If pstrTrgTimeFrom <> "" Then
                cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            End If
            If pstrTrgTimeTo <> "" Then
                cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            End If
            '�����敪
            If pstrHasseiTel.Length = 0 And pstrHasseiKei.Length = 0 Then
                '�����Ȃ�
            Else
                '��������
                If pstrHasseiTel.Length <> 0 And pstrHasseiKei.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrHasseiTel
                    cdb.pSQLParamStr("HATKBN2") = pstrHasseiKei
                ElseIf pstrHasseiTel.Length <> 0 And pstrHasseiKei.Length = 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrHasseiTel
                ElseIf pstrHasseiTel.Length = 0 And pstrHasseiKei.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN2") = pstrHasseiKei
                Else
                End If
            End If

            '�Ή��敪
            If pstrTaiouTel.Length = 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length = 0 Then
                '�����Ȃ�
            Else
                '��������
                '�S������
                If pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                    '�����
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                    '�����
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                Else
                End If
            End If
            '2015/02/10 H.Hosoda mod �Ď����P2014 ��14 End

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
    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 �����ύX
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrJacd As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrTaiouChofuku As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKuraNm As String, _
    '                                    ByVal pstrJaNm As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrCentcd As String _
    '                                    ) As String
    '2017/02/15 H.Mori mod ���P2016 No8-2 START
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKuracdFrom As String, _
    '                                    ByVal pstrKuracdTo As String, _
    '                                    ByVal pstrJacdFrom As String, _
    '                                    ByVal pstrJacdTo As String, _
    '                                    ByVal pstrHangrpFrom As String, _
    '                                    ByVal pstrHangrpTo As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrHasseiTel As String, _
    '                                    ByVal pstrHasseiKei As String, _
    '                                    ByVal pstrTaiouTel As String, _
    '                                    ByVal pstrTaiouShu As String, _
    '                                    ByVal pstrTaiouJuf As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrTrgdatekbn As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrCentcd As String _
    '                                    ) As String
    '2020/11/01 T.Ono mod �Ď����P2020 
    'pstrTSADOCD �ǉ�
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKuracdFrom As String,
                                        ByVal pstrKuracdTo As String,
                                        ByVal pstrJacdFrom As String,
                                        ByVal pstrJacdTo As String,
                                        ByVal pstrHangrpFrom As String,
                                        ByVal pstrHangrpTo As String,
                                        ByVal pstrPgkbn As String,
                                        ByVal pstrHasseiTel As String,
                                        ByVal pstrHasseiKei As String,
                                        ByVal pstrTaiouTel As String,
                                        ByVal pstrTaiouShu As String,
                                        ByVal pstrTaiouJuf As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrTrgdatekbn As String,
                                        ByVal pdecPageMax As Decimal,
                                        ByVal pstrCentcd As String,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrTsadcd As String
                                        ) As String
        '2017/02/16 H.Mori mod ���P2016 No8-2 END

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

        Dim strTmp() As String

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
            '2017/02/16 H.Mori mod ���P2016 No8-2 START
            '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
            'strSQL.Append(fncMakeSelect(2, _
            '                         pstrKuracd, _
            '                         pstrJacd, _
            '                         pstrTrgFrom, _
            '                         pstrTrgTo, _
            '                         pstrPgkbn, _
            '                         pstrTaiouChofuku, _
            '                         pdecPageMax))
            'strSQL.Append(fncMakeSelect(2, _
            '                          pstrKuracdFrom, _
            '                          pstrKuracdTo, _
            '                          pstrJacdFrom, _
            '                          pstrJacdTo, _
            '                          pstrHangrpFrom, _
            '                          pstrHangrpTo, _
            '                          pstrTrgFrom, _
            '                          pstrTrgTo, _
            '                          pstrPgkbn, _
            '                          pstrHasseiTel, _
            '                          pstrHasseiKei, _
            '                          pstrTaiouTel, _
            '                          pstrTaiouShu, _
            '                          pstrTaiouJuf, _
            '                          pstrTrgdatekbn, _
            '                          pdecPageMax))
            '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End
            '2020/11/01 T.Ono mod �Ď����P2020
            'pstrTsadcd �ǉ�
            strSQL.Append(fncMakeSelect(2,
                                      pstrKuracdFrom,
                                      pstrKuracdTo,
                                      pstrJacdFrom,
                                      pstrJacdTo,
                                      pstrHangrpFrom,
                                      pstrHangrpTo,
                                      pstrTrgFrom,
                                      pstrTrgTo,
                                      pstrPgkbn,
                                      pstrHasseiTel,
                                      pstrHasseiKei,
                                      pstrTaiouTel,
                                      pstrTaiouShu,
                                      pstrTaiouJuf,
                                      pstrTrgdatekbn,
                                      pdecPageMax,
                                      pstrTrgTimeFrom,
                                      pstrTrgTimeTo,
                                      pstrTsadcd))
            '2017/02/16 H.Mori mod ���P2016 No8-2 END

            cdb.pSQL = strSQL.ToString 'SQL���Z�b�g

            '2015/02/10 H.Hosoda add �Ď����P2014 ��14 Start
            '�p�����[�^�Z�b�g
            '�N���C�A���g�R�[�h
            If pstrKuracdFrom <> "" Then
                cdb.pSQLParamStr("KURACD_FROM") = pstrKuracdFrom
            End If
            If pstrKuracdTo <> "" Then
                cdb.pSQLParamStr("KURACD_TO") = pstrKuracdTo
            End If
            '�i�`�R�[�h ' @
            If pstrJacdFrom <> "" Then
                cdb.pSQLParamStr("JACD_FROM") = pstrJacdFrom
            End If
            If pstrJacdTo <> "" Then
                cdb.pSQLParamStr("JACD_TO") = pstrJacdTo
            End If
            '�̔����Ǝ҃O���[�v�R�[�h
            If pstrHangrpFrom <> "" Then
                cdb.pSQLParamStr("HANGRP_FROM") = pstrHangrpFrom
            End If
            If pstrHangrpTo <> "" Then
                cdb.pSQLParamStr("HANGRP_TO") = pstrHangrpTo
            End If
            '�Ή��������܂��͎�M��
            If pstrTrgFrom <> "" Then
                cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            End If
            If pstrTrgTo <> "" Then
                cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            End If
            '�Ή����������܂��͎�M�����@2017/02/15 H.Mori add ���P2016 No8-2 
            If pstrTrgTimeFrom <> "" Then
                cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            End If
            If pstrTrgTimeTo <> "" Then
                cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            End If
            '�����敪
            If pstrHasseiTel.Length = 0 And pstrHasseiKei.Length = 0 Then
                '�����Ȃ�
            Else
                '��������
                If pstrHasseiTel.Length <> 0 And pstrHasseiKei.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrHasseiTel
                    cdb.pSQLParamStr("HATKBN2") = pstrHasseiKei
                ElseIf pstrHasseiTel.Length <> 0 And pstrHasseiKei.Length = 0 Then
                    cdb.pSQLParamStr("HATKBN1") = pstrHasseiTel
                ElseIf pstrHasseiTel.Length = 0 And pstrHasseiKei.Length <> 0 Then
                    cdb.pSQLParamStr("HATKBN2") = pstrHasseiKei
                Else
                End If
            End If

            '�Ή��敪
            If pstrTaiouTel.Length = 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length = 0 Then
                '�����Ȃ�
            Else
                '��������
                '�S������
                If pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                    '�����
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                    '�����
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length = 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                ElseIf pstrTaiouTel.Length <> 0 And pstrTaiouShu.Length = 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN1") = pstrTaiouTel
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                ElseIf pstrTaiouTel.Length = 0 And pstrTaiouShu.Length <> 0 And pstrTaiouJuf.Length <> 0 Then
                    cdb.pSQLParamStr("TAIOKBN2") = pstrTaiouShu
                    cdb.pSQLParamStr("TAIOKBN3") = pstrTaiouJuf
                Else
                End If
            End If
            '2015/02/10 H.Hosoda add �Ď����P2014 ��14 End

            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
                Return "DATAMAX"    '�f�[�^���ő�s���𒴂��鎖�������������Ԃ�
            End If

            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            ExcelC.pKencd = "00"                '���R�[�h���Z�b�g
            ExcelC.pSessionID = pstrSessionID   '�Z�b�V����ID
            ExcelC.pRepoID = "KEKANSYW00"       '���[ID
            ExcelC.mOpen()                      '�t�@�C���I�[�v��

            ExcelC.pTitle = "�Ď��Ή����W�v�\"                        '�^�C�g��
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

            '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
            ExcelC.mHeader(65000, ds.Tables(0).Rows.Count, 3)

            '-----------------------
            ' �G�N�Z�����ڏ��
            '-----------------------
            Dim arrColNM1(27) As String
            Dim arrColNM2(27) As String
            Dim arrColID(27) As String
            Dim arrWidth(27) As String '�� ����1�`28
            Dim arrHeadBGColor(27) As String
            Dim arrLetters() As String = {"0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB"}
            Dim zoku As String
            Dim buf As String

            Dim i As Integer
            If True Then
                '2017/02/17 H.Mori add ���P2016 No8-1 START
                'arrColNM1(1) = "�N���C�A���g"
                If pstrPgkbn = "6" Then
                    arrColNM1(1) = "��"
                Else
                    arrColNM1(1) = "�N���C�A���g"
                End If
                '2017/02/17 H.Mori add ���P2016 No8-1 END
                arrColNM1(2) = ""

                If pstrPgkbn = "2" Then
                    arrColNM1(3) = "�i�`"
                    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
                    'Else
                    '2017/02/23 H.Mori mod ���P2016 No8-1 �̔����ƎҎx���P�ʂ̍폜
                    'ElseIf pstrPgkbn = "3" Or pstrPgkbn = "5" Then
                ElseIf pstrPgkbn = "3" Then
                    arrColNM1(3) = "�i�`�x��"
                ElseIf pstrPgkbn = "4" Then
                    arrColNM1(3) = "�̔����Ǝ�"
                    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End
                    '2017/02/17 H.Mori add ���P2016 No8-1 START
                ElseIf pstrPgkbn = "7" Then
                    arrColNM1(3) = "�̔���"
                    '2017/02/17 H.Mori add ���P2016 No8-1 END
                End If

                arrColNM2(4) = ""
                arrColNM1(5) = "�Z�L�����e�B"
                '2015/02/13 H.Hosoda mod �Ď����P2014 ��14 Start
                'arrColNM2(5) = "�I�[�o�[�\��"
                'arrColNM2(6) = "�g�p�I�[�o�["
                'arrColNM2(7) = "�x���Ւf"
                'arrColNM2(8) = "���͎Ւf"
                'arrColNM2(9) = "���ʃI�[�o�["
                arrColNM2(5) = "�g�p���ԃI�[�o�\��"
                arrColNM2(6) = "�g�p���ԃI�[�o�Ւf"
                arrColNM2(7) = "�K�X�x���Ւf"
                arrColNM2(8) = "���̓Z���T�Ւf"
                arrColNM2(9) = "�ő嗬�ʃI�[�o�Ւf"
                '2015/02/13 H.Hosoda mod �Ď����P2014 ��14 End
                arrColNM2(10) = "�Ւf�وُ�"
                '2017/11/01 H.Mori mod 2017���P�J�� No8-1 START 
                ''2015/02/13 H.Hosoda mod �Ď����P2014 ��14 Start
                ''arrColNM2(11) = "�x���쓮"
                ''arrColNM2(12) = "�O���Z���T�["
                'arrColNM2(11) = "�K�X�x���쓮"
                'arrColNM2(12) = "�O���P�Z���T�Ւf"
                ''2015/02/13 H.Hosoda mod �Ď����P2014 ��14 End
                'arrColNM2(13) = "���k��Ւf"
                ''2015/02/13 H.Hosoda mod �Ď����P2014 ��14 Start
                ''arrColNM2(14) = "���S�m�F��"
                'arrColNM2(14) = "���S�m�F���Ւf"
                ''2015/02/13 H.Hosoda mod �Ď����P2014 ��14 End
                'arrColNM2(15) = "�����R�k(��)"
                'arrColNM2(16) = "�����R�k(��)"
                'arrColNM2(17) = "���̑�"
                'arrColNM2(18) = "�Ǘ����P"
                'arrColNM2(19) = "�Ǘ����Q"
                arrColNM2(11) = "�K�X�x���쓮"
                arrColNM2(12) = "���k��Ւf"
                arrColNM2(13) = "���S�m�F���Ւf"
                arrColNM2(14) = "�����R�k(��)"
                arrColNM2(15) = "�����R�k(��)"
                arrColNM2(16) = "���̑��P"
                arrColNM2(17) = "���̑��Q"
                arrColNM2(18) = "�Ǘ����P"
                arrColNM2(19) = "�Ǘ����Q"
                '2017/11/01 H.Mori mod 2017���P�J�� No8-1 END 
                arrColNM2(20) = "���v "
                arrColNM2(21) = "���o��"
                arrColNM2(22) = "���v"
                arrColNM2(23) = "���o��"
                arrColNM2(24) = "���v"
                arrColNM2(25) = "���o��"
                arrColNM2(26) = "��"
                If pstrPgkbn = "2" Then
                    arrColNM2(27) = "JA"
                    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
                    'Else
                    '2017/02/23 H.Mori mod ���P2016 No8-1 �̔����ƎҎx���P�ʂ̍폜
                    'ElseIf pstrPgkbn = "3" Or pstrPgkbn = "5" Then
                ElseIf pstrPgkbn = "3" Then
                    arrColNM2(27) = "JA�x��"
                ElseIf pstrPgkbn = "4" Then
                    arrColNM2(27) = "�̔����Ǝ�"
                    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End
                    '2017/02/17 H.Mori add ���P2016 No8-1 START
                ElseIf pstrPgkbn = "7" Then
                    arrColNM2(27) = "�̔���"
                    '2017/02/17 H.Mori add ���P2016 No8-1 END
                End If
            End If
            If True Then
                arrColID(1) = "KURACD"
                arrColID(2) = "KURANM"
                arrColID(3) = "JACD"
                arrColID(4) = "JANM"
                arrColID(5) = "C01"
                arrColID(6) = "C02"
                arrColID(7) = "C03"
                arrColID(8) = "C04"
                arrColID(9) = "C05"
                arrColID(10) = "C06"
                arrColID(11) = "C07"
                arrColID(12) = "C08"
                arrColID(13) = "C09"
                arrColID(14) = "C10"
                arrColID(15) = "C11"
                arrColID(16) = "C12"
                arrColID(17) = "C13"
                arrColID(18) = "C14"
                arrColID(19) = "C15"
                arrColID(20) = "C16"
                arrColID(21) = "C20"
                arrColID(22) = "C17"
                arrColID(23) = "C21"
                arrColID(24) = "C18"
                arrColID(25) = "C19"
                arrColID(26) = "KENNM"
                arrColID(27) = "JACD"
            End If
            If True Then '��
                arrWidth(1) = "31"
                arrWidth(2) = "133"
                arrWidth(3) = "53"
                arrWidth(4) = "133"
                arrWidth(5) = "66"
                arrWidth(6) = "66"
                arrWidth(7) = "66"
                arrWidth(8) = "66"
                arrWidth(9) = "66"
                arrWidth(10) = "66"
                arrWidth(11) = "66"
                arrWidth(12) = "66"
                arrWidth(13) = "66"
                arrWidth(14) = "66"
                arrWidth(15) = "66"
                arrWidth(16) = "66"
                arrWidth(17) = "66"
                arrWidth(18) = "66"
                arrWidth(19) = "66"
                arrWidth(20) = "66"
                arrWidth(21) = "66"
                arrWidth(22) = "54"
                arrWidth(23) = "54"
                arrWidth(24) = "66"
                arrWidth(25) = "66"
                arrWidth(26) = "41"
                arrWidth(27) = "51"
            End If
            If True Then
                arrHeadBGColor(1) = "background:#99CCFF;" '��
                arrHeadBGColor(2) = "background:#99CCFF;" '��
                arrHeadBGColor(3) = "background:#99CCFF;" '��
                arrHeadBGColor(4) = "background:#99CCFF;" '��
                arrHeadBGColor(5) = "background:#CCFFCC;" '����
                arrHeadBGColor(6) = "background:#CCFFCC;" '����
                arrHeadBGColor(7) = "background:#CCFFCC;" '����
                arrHeadBGColor(8) = "background:#CCFFCC;" '����
                arrHeadBGColor(9) = "background:#CCFFCC;" '����
                arrHeadBGColor(10) = "background:#CCFFCC;" '����
                arrHeadBGColor(11) = "background:#CCFFCC;" '����
                arrHeadBGColor(12) = "background:#CCFFCC;" '����
                arrHeadBGColor(13) = "background:#CCFFCC;" '����
                arrHeadBGColor(14) = "background:#CCFFCC;" '����
                arrHeadBGColor(15) = "background:#CCFFCC;" '����
                arrHeadBGColor(16) = "background:#CCFFCC;" '����
                arrHeadBGColor(17) = "background:#CCFFCC;" '����
                arrHeadBGColor(18) = "background:#CCFFCC;" '����
                'arrHeadBGColor(19) = "background:#CCFFCC;" '����
                arrHeadBGColor(19) = "background:#CCFFCC;color:#FF0000;" '���� '2017/11/17 H.Mori mod 2017���P�J�� No8-1
                arrHeadBGColor(20) = "background:#CCFFCC;" '����
                arrHeadBGColor(21) = "background:#CCFFCC;" '����
                arrHeadBGColor(22) = "background:#CCFFFF;" '���F
                arrHeadBGColor(23) = "background:#CCFFFF;" '���F
                arrHeadBGColor(24) = "background:#FFFF99;" '���F
                'arrHeadBGColor(25) = "background:#FFCC99;" '��
                arrHeadBGColor(25) = "background:#FFFF99;" '���F
                arrHeadBGColor(26) = "background:#99CCFF;" '��
                arrHeadBGColor(27) = "background:#99CCFF;" '��
            End If


            '���w�b�_�s1
            If True Then
                '2015/03/16 T.Ono add 2014���P�J�� �ǉ��v�] �w��������o�� START
                'Dim sDateFT As String
                'If Len(pstrTrgFrom) > 0 Or Len(pstrTrgTo) > 0 Then
                '    sDateFT = DateFncC.mGet(pstrTrgFrom) & "�`" & DateFncC.mGet(pstrTrgTo)
                'End If
                'For i = 1 To 27
                '    ExcelC.pCellStyle(i) = "height:26px;text-align:left;font-size:13px;border-style:none;"
                'Next
                'ExcelC.pCellVal(1) = ""
                'ExcelC.pCellVal(2) = ""
                'ExcelC.pCellVal(3, "colspan=9") = Convert.ToString("�Ώۊ���:" & sDateFT)
                'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
                Dim sDateFT As String = ""
                Dim sKuraFT As String = ""
                Dim sJaFT As String = ""
                Dim sHangrpJI As String = ""
                Dim sPgkbn As String = ""
                Dim sHasseikbn As String = ""
                Dim sTaioukbn As String = ""
                Dim sTrgdatekbn As String = ""
                '2017/02/16 H.Mori add ���P2016 No8-2 �����ǉ� START
                'If Len(pstrTrgFrom) > 0 OrElse Len(pstrTrgTo) > 0 Then
                '    sDateFT = "�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom) & "�`" & DateFncC.mGet(pstrTrgTo)
                'End If
                If Len(pstrTrgTimeFrom) = 0 OrElse Len(pstrTrgTimeFrom) = 0 Then
                    sDateFT = "�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom) & "�`" & DateFncC.mGet(pstrTrgTo)
                Else
                    sDateFT = "�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom) & " " & CTimeFncC.mGet(pstrTrgTimeFrom, 0) & "�`" & DateFncC.mGet(pstrTrgTo) & " " & CTimeFncC.mGet(pstrTrgTimeTo, 0)
                End If
                '2017/02/16 H.Mori add ���P2016 No8-2 �����ǉ� START
                If pstrTrgdatekbn = "1" Then
                    sDateFT += "�E�Ή�������"
                Else
                    sDateFT += "�E��M��"
                End If
                If Len(pstrKuracdFrom) > 0 OrElse Len(pstrKuracdTo) > 0 Then
                    sKuraFT = "�A�ײ��āF" & pstrKuracdFrom & "�`" & pstrKuracdTo
                End If
                If Len(pstrJacdFrom) > 0 OrElse Len(pstrJacdTo) > 0 Then
                    sJaFT = "�AJA:" & pstrJacdFrom & "�`" & pstrJacdTo
                End If
                If Len(pstrHangrpFrom) > 0 OrElse Len(pstrHangrpTo) > 0 Then
                    sHangrpJI = "�A�̔����Ǝ�:" & pstrHangrpFrom & "�`" & pstrHangrpTo
                End If
                If pstrPgkbn = "1" Then
                    sPgkbn = "�A�W�v�����F�ײ��ĒP��"
                ElseIf pstrPgkbn = "2" Then
                    sPgkbn = "�A�W�v�����FJA�P��"
                ElseIf pstrPgkbn = "3" Then
                    sPgkbn = "�A�W�v�����FJA�x���P��"
                ElseIf pstrPgkbn = "4" Then
                    sPgkbn = "�A�W�v�����F�̔����ƎҒP��"
                    '2017/02/17 H.Mori mod ���P2016 No8-1 START
                    'ElseIf pstrPgkbn = "5" Then
                    '    sPgkbn = "�A�W�v�����F�̔����ƎҎx���P��"
                    'End If
                ElseIf pstrPgkbn = "6" Then
                    sPgkbn = "�A�W�v�����F���P��"
                ElseIf pstrPgkbn = "7" Then
                    sPgkbn = "�A�W�v�����F�̔����P��"
                End If
                '2017/02/17 H.Mori mod ���P2016 No8-1 END
                If Len(pstrHasseiTel) > 0 And Len(pstrHasseiKei) > 0 Then
                    sHasseikbn = "�A�����敪�F�d�b�E�x��"
                ElseIf Len(pstrHasseiTel) > 0 Then
                    sHasseikbn = "�A�����敪�F�d�b"
                ElseIf Len(pstrHasseiKei) > 0 Then
                    sHasseikbn = "�A�����敪�F�x��"
                End If
                If Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) > 0 Then
                    sTaioukbn = "�A�Ή��敪�F�d�b�E�o���E�d��"
                ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) > 0 Then
                    sTaioukbn = "�A�Ή��敪�F�d�b�E�o��"
                ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouJuf) > 0 Then
                    sTaioukbn = "�A�Ή��敪�F�d�b�E�d��"
                ElseIf Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) > 0 Then
                    sTaioukbn = "�A�Ή��敪�F�o���E�d��"
                ElseIf Len(pstrTaiouTel) > 0 Then
                    sTaioukbn = "�A�Ή��敪�F�d�b"
                ElseIf Len(pstrTaiouShu) > 0 Then
                    sTaioukbn = "�A�Ή��敪�F�o��"
                ElseIf Len(pstrTaiouJuf) > 0 Then
                    sTaioukbn = "�A�Ή��敪�F�d��"
                Else
                End If

                '2020/11/01 T.Ono add 2020�Ď����P
                If pstrTsadcd = "1" Then
                    sTaioukbn = "�A�쓮�����F�H���E�����Ȃ�(63) �܂�"
                Else
                    sTaioukbn = "�A�쓮�����F�H���E�����Ȃ�(63) �܂܂Ȃ�"
                End If

                For i = 1 To 27
                    ExcelC.pCellStyle(i) = "height:26px;text-align:left;font-size:13px;border-style:none;"
                Next
                ExcelC.pCellVal(1) = ""
                ExcelC.pCellVal(2) = ""
                ExcelC.pCellVal(3, "colspan=22") = Convert.ToString(sDateFT & sKuraFT & sJaFT & sHangrpJI & sPgkbn & sHasseikbn & sTaioukbn)
                ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
                '2015/03/16 T.Ono add 2014���P�J�� �ǉ��v�] �w��������o�� END
            End If

            '���w�b�_�s2
            If True Then
                For i = 1 To 27
                    '2017/02/17 H.Mori mod ���P2016 No8-1 START
                    'If pstrPgkbn = "1" And (i = 3 Or i = 4 Or i = 27) Then '1:�N���C�A���g�́A�i�`���ڂ��X�L�b�v
                    If (pstrPgkbn = "1" Or pstrPgkbn = "6") And (i = 3 Or i = 4 Or i = 27) Then '1:�N���C�A���g�A�����́A�i�`���ڂ��X�L�b�v
                        '2017/02/17 H.Mori mod ���P2016 No8-1 END
                        '�X�L�b�v
                    Else
                        'ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;background-color:lightgrey;" & arrHeadBGColor(i)
                        ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(i)
                    End If
                Next
                '2017/02/17 H.Mori mod ���P2016 No8-1 START�@
                'ExcelC.pCellVal(1, "colspan=2 rowspan=2") = Convert.ToString("�N���C�A���g")
                'If pstrPgkbn = "1" Then
                '�X�L�b�v
                If pstrPgkbn = "6" Then
                    ExcelC.pCellVal(1, "colspan=2 rowspan=2") = Convert.ToString("��")
                Else
                    ExcelC.pCellVal(1, "colspan=2 rowspan=2") = Convert.ToString("�N���C�A���g")
                End If
                If pstrPgkbn = "1" Or pstrPgkbn = "6" Then
                    '�X�L�b�v
                    '2017/02/17 H.Mori mod ���P2016 No8-1 END
                ElseIf pstrPgkbn = "2" Then
                    ExcelC.pCellVal(3, "colspan=2 rowspan=2") = Convert.ToString("�i�`")
                    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
                    'Else
                    '2017/02/23 H.Mori mod ���P2016 No8-1 �̔����ƎҎx���P�ʂ̍폜
                    'ElseIf pstrPgkbn = "3" Or pstrPgkbn = "5" Then
                ElseIf pstrPgkbn = "3" Then
                    ExcelC.pCellVal(3, "colspan=2 rowspan=2") = Convert.ToString("�i�`�x��")
                ElseIf pstrPgkbn = "4" Then
                    ExcelC.pCellVal(3, "colspan=2 rowspan=2") = Convert.ToString("�̔����Ǝ�")
                    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End
                    '2017/02/17 H.Mori mod ���P2016 No8-1 START
                ElseIf pstrPgkbn = "7" Then
                    ExcelC.pCellVal(3, "colspan=2 rowspan=2") = Convert.ToString("�̔���")
                    '2017/02/17 H.Mori mod ���P2016 No8-1 END
                End If
                ExcelC.pCellVal(5, "colspan=17") = "�x    ��"
                ExcelC.pCellVal(22, "colspan=2") = "�d�b"
                'ExcelC.pCellStyle(22) = "height:26px;width:" & arrWidth(22) & "px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(22)
                ExcelC.pCellStyle(22) = "height:26px;width:" & arrWidth(22) & "px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(22)
                ExcelC.pCellVal(24, "colspan=2") = "�Ή����������v "
                'ExcelC.pCellStyle(24) = "height:26px;width:" & arrWidth(24) & "px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(24)
                ExcelC.pCellStyle(24) = "height:26px;width:" & arrWidth(24) & "px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(24)
                ExcelC.pCellVal(26, "rowspan=2") = "��"
                '2017/02/17 H.Mori mod ���P2016 No8-1 START�@
                'If pstrPgkbn = "1" Then
                If pstrPgkbn = "1" Or pstrPgkbn = "6" Then
                    '2017/02/17 H.Mori mod ���P2016 No8-1 END
                    '�@
                ElseIf pstrPgkbn = "2" Then
                    ExcelC.pCellVal(27, "rowspan=2") = Convert.ToString("JA")
                    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
                    'Else
                    '2017/02/23 H.Mori mod ���P2016 No8-1 �̔����ƎҎx���P�ʂ̍폜
                    'ElseIf pstrPgkbn = "3" Or pstrPgkbn = "5" Then
                ElseIf pstrPgkbn = "3" Then
                    ExcelC.pCellVal(27, "rowspan=2") = Convert.ToString("JA�x��")
                ElseIf pstrPgkbn = "4" Then
                    ExcelC.pCellVal(27, "rowspan=2") = Convert.ToString("�̔����Ǝ�")
                    '2017/02/17 H.Mori mod ���P2016 No8-1 START
                ElseIf pstrPgkbn = "7" Then
                    ExcelC.pCellVal(27, "rowspan=2") = Convert.ToString("�̔���")
                    '2017/02/17 H.Mori mod ���P2016 No8-1 END
                End If
                ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            End If

            '���w�b�_�s3
            For i = 1 To 27
                '2017/02/17 H.Mori mod ���P2016 No8-1 START
                'If pstrPgkbn = "1" And (i = 3 Or i = 4 Or i = 27) Then '1:�N���C�A���g�́A�i�`���ڂ��X�L�b�v
                If (pstrPgkbn = "1" Or pstrPgkbn = "6") And (i = 3 Or i = 4 Or i = 27) Then '1:�N���C�A���g�́A�i�`���ڂ��X�L�b�v
                    '2017/02/17 H.Mori mod ���P2016 No8-1 END
                    '�X�L�b�v
                Else
                    'ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;background-color:lightgrey;" & arrHeadBGColor(i)
                    ExcelC.pCellStyle(i) = "height:26px;text-align:center;font-size:9px;border-style:solid;" & arrHeadBGColor(i)
                End If
            Next

            '2015/02/13 H.Hosoda mod �Ď����P2014 ��14 Start
            'ExcelC.pCellVal(5) = Convert.ToString("�I�[�o�[�\��")
            'ExcelC.pCellVal(6) = Convert.ToString("�g�p�I�[�o�[")
            'ExcelC.pCellVal(7) = Convert.ToString("�x���Ւf")
            'ExcelC.pCellVal(8) = Convert.ToString("���͎Ւf")
            'ExcelC.pCellVal(9) = Convert.ToString("���ʃI�[�o�[")
            ExcelC.pCellVal(5) = Convert.ToString("�g�p���ԃI�[�o�\��")
            ExcelC.pCellVal(6) = Convert.ToString("�g�p���ԃI�[�o�Ւf")
            ExcelC.pCellVal(7) = Convert.ToString("�K�X�x���Ւf")
            ExcelC.pCellVal(8) = Convert.ToString("���̓Z���T�Ւf")
            ExcelC.pCellVal(9) = Convert.ToString("�ő嗬�ʃI�[�o�Ւf")
            '2015/02/13 H.Hosoda mod �Ď����P2014 ��14 End
            ExcelC.pCellVal(10) = Convert.ToString("�Ւf�وُ�")

            '2017/11/01 H.Mori mod 2017���P�J�� No8-1 START 
            ''2015/02/13 H.Hosoda mod �Ď����P2014 ��14 Start
            ''ExcelC.pCellVal(11) = Convert.ToString("�x���쓮")
            ''ExcelC.pCellVal(12) = Convert.ToString("�O���Z���T�[")
            'ExcelC.pCellVal(11) = Convert.ToString("�K�X�x���쓮")
            'ExcelC.pCellVal(12) = Convert.ToString("�O���P�Z���T�Ւf")
            ''2015/02/13 H.Hosoda mod �Ď����P2014 ��14 End
            'ExcelC.pCellVal(13) = Convert.ToString("���k��Ւf")
            ''2015/02/13 H.Hosoda mod �Ď����P2014 ��14 Start
            ''ExcelC.pCellVal(14) = Convert.ToString("���S�m�F��")
            'ExcelC.pCellVal(14) = Convert.ToString("���S�m�F���Ւf")
            ''2015/02/13 H.Hosoda mod �Ď����P2014 ��14 End
            'ExcelC.pCellVal(15) = Convert.ToString("�����R�k(��)")
            'ExcelC.pCellVal(16) = Convert.ToString("�����R�k(��)")
            'ExcelC.pCellVal(17) = Convert.ToString("���̑�")
            'ExcelC.pCellVal(18) = Convert.ToString("�Ǘ����P")
            'ExcelC.pCellVal(19) = Convert.ToString("�Ǘ����Q")
            ExcelC.pCellVal(11) = Convert.ToString("�K�X�x���쓮")
            ExcelC.pCellVal(12) = Convert.ToString("���k��Ւf")
            ExcelC.pCellVal(13) = Convert.ToString("���S�m�F���Ւf")
            ExcelC.pCellVal(14) = Convert.ToString("�����R�k(��)")
            ExcelC.pCellVal(15) = Convert.ToString("�����R�k(��)")
            ExcelC.pCellVal(16) = Convert.ToString("���̑��P")
            ExcelC.pCellVal(17) = Convert.ToString("���̑��Q")
            ExcelC.pCellVal(18) = Convert.ToString("�Ǘ����P")
            ExcelC.pCellVal(19) = Convert.ToString("�Ǘ����Q")
            '2017/11/01 H.Mori mod 2017���P�J�� No8-1 END 
            ExcelC.pCellVal(20) = Convert.ToString("���v")
            ExcelC.pCellVal(21) = Convert.ToString("���o��")
            ExcelC.pCellVal(22) = Convert.ToString("���v")
            ExcelC.pCellVal(23) = Convert.ToString("���o��")
            ExcelC.pCellVal(24) = Convert.ToString("���v")
            ExcelC.pCellVal(25) = Convert.ToString("���o��")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������

            '�����׃f�[�^�s
            Dim iCnt As Integer
            Dim tmp As String
            Dim col2 As Integer '2017/11/06 H.Mori add 2017���P�J�� No8-1
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)
                '2017/11/06 H.Mori mod 2017���P�J�� No8-1 START
                If pstrPgkbn = "1" Or pstrPgkbn = "6" Then
                    col2 = 3
                Else
                    col2 = 5
                End If
                '2017/11/06 H.Mori mod 2017���P�J�� No8-1 END

                '���׍���
                For i = 1 To 27
                    buf = ""
                    tmp = ""
                    zoku = ""
                    '2017/02/17 H.Mori mod ���P2016 No8-1 START
                    'If pstrPgkbn = "1" And (i = 3 Or i = 4 Or i = 27) Then '1:�N���C�A���g�́A�i�`���ڂ��X�L�b�v
                    If (pstrPgkbn = "1" Or pstrPgkbn = "6") And (i = 3 Or i = 4 Or i = 27) Then '1:�N���C�A���g�́A�i�`���ڂ��X�L�b�v
                        '2017/02/17 H.Mori mod ���P2016 No8-1 END
                        '�X�L�b�v
                    Else
                        buf = Convert.ToString(dr.Item(arrColID(i)))
                        tmp = "width:" & arrWidth(i) & "px;"
                        If i >= 5 And i <= 25 Then   '���l����
                            tmp = "mso-number-format:'\#\,\#\#0';text-align:right;"
                            '2017/11/06 H.Mori mod 2017���P�J�� No8-1 START
                            'zoku = "x:num=" & buf
                            If i = 19 Then
                                zoku = "x:num=0 x:fmla='= " & arrLetters(col2 + 15) & iCnt + 4 & "-SUM(" & arrLetters(col2) & iCnt + 4 & ":" & arrLetters(col2 + 13) & iCnt + 4 & ")'" '�� =T4-SUM(E4:R4)"
                            Else
                                zoku = "x:num=" & buf
                            End If
                            '2017/11/06 H.Mori mod 2017���P�J�� No8-1 END
                        Else                        '��������
                            tmp = "text-align:left;white-space:nowrap;"
                        End If

                        '2017/02/16 H.Mori mod ���P2016 No8-4 START ̫�Ļ��ނ�8��10�֕ύX
                        'ExcelC.pCellStyle(i) = "height:16px;font-size:11px;border-style:solid;" & tmp
                        If i >= 5 And i <= 25 Then
                            ExcelC.pCellStyle(i) = "height:16px;font-size:13px;border-style:solid;" & tmp '���l����
                        Else
                            ExcelC.pCellStyle(i) = "height:16px;font-size:11px;border-style:solid;" & tmp '��������
                        End If
                        '2017/02/16 H.Mori mod ���P2016 No8-4 END   ̫�Ļ��ނ�8��10�֕ύX
                        ExcelC.pCellVal(i, zoku) = buf
                    End If
                Next
                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
            Next


            '���t�b�^�s�i���v�j
            Dim col As Integer '�o�̓G�N�Z����̃J�����ԍ�
            tmp = "background:#99CCFF;text-align:right;"
            tmp = tmp & "height:26px;font-size:11px;border-style:solid;" & tmp
            '2017/02/17 H.Mori mod ���P2016 No8-1 START
            'If pstrPgkbn = "1" Then
            If pstrPgkbn = "1" Or pstrPgkbn = "6" Then
                '2017/02/17 H.Mori mod ���P2016 No8-1 END
                buf = "���v"
                zoku = "colspan=2"
                col = 2
                i = 5
            Else
                buf = "���v"
                zoku = "colspan=4"
                col = 4
                i = 5
            End If
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellVal(1, zoku) = buf
            ExcelC.pCellStyle(26) = tmp
            ExcelC.pCellVal(26) = ""
            '2017/02/17 H.Mori mod ���P2016 No8-1 START
            'If pstrPgkbn > "1" Then
            If pstrPgkbn <> "1" And pstrPgkbn <> "6" Then
                '2017/02/17 H.Mori mod ���P2016 No8-1 END
                ExcelC.pCellStyle(27) = tmp
                ExcelC.pCellVal(27) = ""
            End If

            If True Then
                For i = i To 27 - 2
                    col = col + 1
                    buf = ""
                    zoku = ""
                    tmp = ""

                    '���l����
                    '2017/02/16 H.Mori mod ���P2016 No8-4 START ̫�Ļ��ނ�8��10�֕ύX
                    'tmp = tmp & "height:16px;font-size:11px;border-style:solid;"
                    tmp = tmp & "height:16px;font-size:13px;border-style:solid;"
                    '2017/02/16 H.Mori mod ���P2016 No8-4 START ̫�Ļ��ނ�8��10�֕ύX
                    tmp = tmp & "width:" & arrWidth(i) & "px;"
                    tmp = tmp & "text-align:right;mso-number-format:'\#\,\#\#0';"
                    zoku = "x:num=0 x:fmla='=SUM(" & arrLetters(col) & "4:" & arrLetters(col) & "" & iCnt + 3 & ")'" '�� =SUM(E4:E100)"
                    buf = ""

                    ExcelC.pCellStyle(i) = tmp
                    ExcelC.pCellVal(i, zoku) = buf
                Next
                ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            End If

            '2015/02/13 H.Hosoda add �Ď����P2014 ��14 Start
            '���t�b�^�s�i�x��⑫�F���̑��A�Ǘ����P�A�Ǘ����Q�j
            tmp = "height:16px;font-size:11px;text-align:left;border-style:none;"
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            '2017/10/31 H.Mori add 2017���P�J�� No8-1 START
            '' �K�X�x���Ւf
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�y�K�X�x���Ւf�z04�F�K�X�x���Ւf�A05�F�b�n�x���Ւf�A06�F��Q�K�X�x���Ւf")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            '2017/10/31 H.Mori add 2017���P�J�� No8-1 END
            '2017/02/16 H.Mori mod ���P2016 No8-3 START
            '' �K�X�x���쓮
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            '2017/10/31 H.Mori mod 2017���P�J�� No8-1 START
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�K�X�x���쓮:�K�X�x���쓮�A�o���N�x���쓮�A�K�X�R��x��")
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�y�K�X�x���쓮�z10�F�K�X�x���쓮�A11�F��Q�K�X�x���쓮�A14�F�b�n�x���쓮�A50�F�o���N�x���쓮�A50�F�K�X�R��x��")
            '2017/10/31 H.Mori mod 2017���P�J�� No8-1 END
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            '2017/02/16 H.Mori mod ���P2016 No8-3 END
            '2017/10/31 H.Mori mod 2017���P�J�� No8-1 START ���̑��A�Ǘ����P�A�Ǘ����Q�@���@���̑��P�A���̑��Q�A�Ǘ����P�A�Ǘ����Q�֕ύX
            '' ���̑�
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("���̑�:��Q�K�X�x���쓮�A���̓Z���T�쓮�A���k��쓮�A���[�^�d�r�d���ቺ�A�x��햢�ڑ��^�M�����Z���A�x���d���v���O�����A���͊Ď��ُ�A�Z���^�Ւf�A�ً}�Ւf�^����Ւf")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ''2015/12/17 T.Ono add �ێ��Ǘ� �x��CD�����Ή� START
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@ ���[�h�T�[�x�C�A�����g�p���ԁA�K�X�g�p�ʑ����A�K�X�g�p�ʌ����A��^�R�Ċ�A�K�X�s�g�p�x���A�v���y�C�c�ʌx���A������Ԗ����x���A�v���G���[�x���A�t���x���A�ǈ��ُ�x���A�������͏���ُ�A�������͉����ُ�")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@ �R�k�������A�R�k�����ُ�A�R�k�����s�A�R�k�����ُ�Ȃ��A�v���y�C�Ւf�A�v���G���[�Ւf�A�t���Ւf")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ''2015/12/17 T.Ono add �ێ��Ǘ� �x��CD�����Ή� END
            ' '' �Ǘ����P
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�Ǘ����P:�e�X�g�Ւf�A�Ւf�ٕ��A�A�Z�L�����e�B���한�A")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ' '' �Ǘ����Q
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            ''2017/02/23 H.Mori mod ���P2016 No8-3
            ''ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�Ǘ����Q:�{���x�����A�c�ʌx��R�A�c�ʌx��Q�A�c�ʌx��P�A���Z�b�g�v���A�O���@��Q�쓮�A�`�b�t�d�r�E�d���ቺ�A�Z���T���b�Z�[�W")
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�Ǘ����Q:�{���x�����A�c�ʌx��R�A�c�ʌx��Q�A�c�ʌx��P�A���Z�b�g�v���A�O���@��Q�쓮�A�`�b�t�d�r�E�d���ቺ�A�Z���T���b�Z�[�W�A�x�m�b�t�e�@�R���Z���g�����A�o���N�c�ʌx���S�O���쓮�A�o���N�c�ʌx���Q�O���쓮")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ''2015/02/13 H.Hosoda add �Ď����P2014 ��14 End
            ''2017/02/16 H.Mori mod ���P2016 No8-3 START
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@ �����ؑւ��؂�ւ��܂����A�����ؑւ��������܂����A�t���x���i�o���N�j�A�o���N�x��한���A�x�[�p���C�U�[�ُ�A�x�[�p�[���C�U�[�����A�Ւf�ق����܂����A�M���@�ُ�A�Q�������͂��ቺ���܂����A�Q�������͂�����ɂȂ�܂���")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@ ���Ԉ��ُ͈�A�G�A�[���ُ͈�A�l�P�|�[�g�����삵�܂����B�A�l�P�|�[�g���������܂����B�A�{���x�Ɉُ�A�T�[���o���u�쓮�i�x�[�o�j�A�T�[���o���u�����i�x�[�o�j�A�m�b�t�e�X�g�@���픭��")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@ �ً}�Ւf�ف^�ϐk�Ւf�ف@�񕜁A�ً}�Ւf�ف^�ϐk�Ւf�ف@�쓮�A�C����ُ�")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            'ExcelC.pCellStyle(1) = tmp
            'ExcelC.pCellStyle(2) = tmp
            'ExcelC.pCellVal(1) = ""
            'ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@ ���Z���T���b�Z�[�W�ɂ��ā@�x��R�[�h=50�A�x�񃁃b�Z�[�W=�o���N�x���쓮�A�K�X�R��x��̏ꍇ�A�K�X�x���쓮�֏W�v����B")
            'ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            '2017/02/16 H.Mori mod ���P2016 No8-3 END
            '�y ���̑��P�z
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�y ���̑��P�z03�F�O���Z���T�Ւf�A32�F�Z���^�Ւf�A33�F�ً}�Ւf�^����Ւf�A34�F���[�^�d�r�d���ቺ�Ւf�A35�F���[�h�T�[�x�C�A3C�F������Ԗ����x���A3D�F�v���G���[�x���A3E�F�t���x���A3I�F�R�k�������A3J�F�R�k�����ُ�A3K�F�R�k�����s�A3L�F�R�k�����ُ�Ȃ��A")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@�@�@�@ 3M�F�v���y�C�Ւf�A3N�F�v���G���[�Ւf�A3O�F�t���Ւf�A40�F�f�|�`�c�o�d�r�ቺ�A50�F�t���x���A50�F�x�[�p���C�U�[�ُ�A50�F�Ւf�ق����܂����A50�F�M���@�ُ�A50�F�Q�������͂��ቺ���܂����A50�F���Ԉ��ُ͈�A50�F�G�A�[���ُ͈�A")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@�@�@�@ 50�F�l�P�|�[�g�����삵�܂����A50�F�{���x�Ɉُ�A50�F�T�[���o���u�쓮�i�x�[�o�j�A50�F�ً}�Ւf�ف^�ϐk�Ւf�ف@�쓮�A50�F�C����ُ�")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            '�y ���̑��Q�z
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�y ���̑��Q�z12�F���̓Z���T�쓮�A13�F���k��쓮�A17�F�e�X�g�Ւf�A18�F�Ւf�ٕ��A�A23�F���[�^�d�r�d���ቺ�A24�F�x��햢�ڑ��^�M�����Z���A25�F�x���d���v���O�����A26�F���͊Ď��ُ�A3F�F�ǈ��ُ�x���A3G�F�������͏���ُ�A3H�F�������͉����ُ�A")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@�@�@�@ 50�F�x�m�b�t�e�@�R���Z���g����")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            '�y�Ǘ����P�z
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�y�Ǘ����P�z19�F�{���x�����A20�F�Z�L�����e�B���한�A�A27�F�c�ʌx��R�A28�F�c�ʌx��Q�A29�F�c�ʌx��P�A30�F���Z�b�g�v���A31�F�O���@��Q�쓮�A36�F�����g�p���ԁA37�F�K�X�g�p�ʑ����A38�F�K�X�g�p�ʌ����A39�F��^�R�Ċ�A3A�F�K�X�s�g�p�x���A")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@�@�@�@�@3B�F�v���y�C�c�ʌx���A49�F�`�b�t�d�r�E�d���ቺ�A50�F�o���N�c�ʌx���S�O���쓮�A50�F�o���N�c�ʌx���Q�O���쓮�A50�F�����ؑւ��؂�ւ��܂����A50�F�����ؑւ��������܂����A50�F�o���N�x��한���A50�F�x�[�p�[���C�U�[�����A")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = tmp
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�@�@�@�@�@�@�@50�F�Q�������͂�����ɂȂ�܂����A50�F�l�P�|�[�g���������܂����B�A50�F�T�[���o���u�����i�x�[�o�j�A50�F�m�b�t�e�X�g�@���픭�āA50�F�ً}�Ւf�ف^�ϐk�Ւf�ف@��")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            '�y�Ǘ����Q�z
            ExcelC.pCellStyle(1) = tmp
            ExcelC.pCellStyle(2) = "height:16px;font-size:11px;text-align:left;border-style:none;color:#FF0000;" '2017/11/17 H.Mori mod 2017���P�J�� No8-1
            ExcelC.pCellVal(1) = ""
            ExcelC.pCellVal(2, "colspan=22") = Convert.ToString("�y�Ǘ����Q�z��L�ȊO�̌x��@���x����e���m�F���A���e�ɓK�������ڂɏW�񂵂Ă��������B")
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            '2017/10/31 H.Mori mod 2017���P�J�� No8-1 END ���̑��A�Ǘ����P�A�Ǘ����Q�@���@���̑��P�A���̑��Q�A�Ǘ����P�A�Ǘ����Q�֕ύX

            ExcelC.mClose()                                 '�t�@�C���N���[�Y

            '���k��t�@�C���̂���t�H���_
            compressC.p_Dir = ExcelC.pDirName
            '���{��t�@�C�����̎w��
            compressC.p_NihongoFileName = "�Ď��Ή����W�v�\.xls"
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
    '*�@�T�@�v:�w�b�_�[�s���쐬
    '*�@���@�l:
    '******************************************************************************
    Public Sub SubMakeHetter(ByVal pExcelC As CExcel, ByVal pdr As DataRow)

        '�w�b�_�[���
        pExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-style:none"
        pExcelC.pCellVal(1, "colspan = 9") = "�i�`:" & Convert.ToString(pdr.Item("JANM")) & _
                                            "�@�i�`�x��:" & Convert.ToString(pdr.Item("SISYONM"))
        pExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

    End Sub

    '******************************************************************************
    '*�@�T�@�v:�r�d�k�d�b�s�����쐬
    '*�@���@�l:[ind]1:�����擾  2:�f�[�^�擾
    '******************************************************************************
    '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 �����ύX
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                              ByVal pstrKuracd As String, _
    '                              ByVal pstrJacd As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrPgKbn As String, _
    '                              ByVal pstrTaiouChofuku As String, _
    '                              ByVal pdecPageMax As Decimal) As String
    '2017/02/15 H.Mori mod ���P2016 No8-2 �����ύX
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                              ByVal pstrKuracdFrom As String, _
    '                              ByVal pstrKuracdTo As String, _
    '                              ByVal pstrJacdFrom As String, _
    '                              ByVal pstrJacdTo As String, _
    '                              ByVal pstrHangrpFrom As String, _
    '                              ByVal pstrHangrpTo As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrPgKbn As String, _
    '                              ByVal pstrHasseiTel As String, _
    '                              ByVal pstrHasseiKei As String, _
    '                              ByVal pstrTaiouTel As String, _
    '                              ByVal pstrTaiouShu As String, _
    '                              ByVal pstrTaiouJuf As String, _
    '                              ByVal pstrTrgdatekbn As String, _
    '                              ByVal pdecPageMax As Decimal) As String
    '2020/11/01 T.Ono mod �Ď����P2020
    'pstrTsadco �ǉ�
    Public Function fncMakeSelect(ByVal ind As Integer,
                              ByVal pstrKuracdFrom As String,
                              ByVal pstrKuracdTo As String,
                              ByVal pstrJacdFrom As String,
                              ByVal pstrJacdTo As String,
                              ByVal pstrHangrpFrom As String,
                              ByVal pstrHangrpTo As String,
                              ByVal pstrTrgFrom As String,
                              ByVal pstrTrgTo As String,
                              ByVal pstrPgKbn As String,
                              ByVal pstrHasseiTel As String,
                              ByVal pstrHasseiKei As String,
                              ByVal pstrTaiouTel As String,
                              ByVal pstrTaiouShu As String,
                              ByVal pstrTaiouJuf As String,
                              ByVal pstrTrgdatekbn As String,
                              ByVal pdecPageMax As Decimal,
                              ByVal pstrTrgTimeFrom As String,
                              ByVal pstrTrgTimeTo As String,
                              ByVal pstrTsadcd As String) As String

        Dim strSQL As New StringBuilder("")
        Dim strWHE As New StringBuilder("")

        '----------------
        ' SQL�����쐬(����)
        '----------------
        '2017/02/15 H.Mori mod ���P2016 No8-2 �Ώێ��Ԓǉ� START
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 �Ώۊ��ԋ敪�ɂ�镪��ǉ� Start
        'If Len(pstrTrgFrom) > 0 Then '������FROM
        '    strWHE.Append("    AND HATYMD >= '" & pstrTrgFrom & "' ")
        'End If
        'If Len(pstrTrgTo) > 0 Then '������TO
        '    strWHE.Append("    AND HATYMD <= '" & pstrTrgTo & "' ")
        'End If
        'If pstrTrgdatekbn = "1" Then
        '    If Len(pstrTrgFrom) > 0 Then '�Ή�������FROM
        '        strWHE.Append("    AND SYOYMD >= :TRGDATE_FROM ")
        '    End If
        '    If Len(pstrTrgTo) > 0 Then '�Ή�������TO
        '        strWHE.Append("    AND SYOYMD <= :TRGDATE_TO ")
        '    End If
        'Else
        '    If Len(pstrTrgFrom) > 0 Then '��M��FROM
        '        strWHE.Append("    AND HATYMD >= :TRGDATE_FROM ")
        '    End If
        '    If Len(pstrTrgTo) > 0 Then '��M��TO
        '        strWHE.Append("    AND HATYMD <= :TRGDATE_TO ")
        '    End If
        'End If
        If pstrTrgdatekbn = "1" Then '�Ή�������
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strWHE.Append(" AND SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strWHE.Append(" AND SYOYMD || SYOTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        Else                       '��M��
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strWHE.Append(" AND HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strWHE.Append(" AND HATYMD || HATTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        End If
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 �Ώۊ��ԋ敪�ɂ�镪��ǉ� End
        '2017/02/16 H.Mori mod ���P2016 No8-2 �Ώێ��Ԓǉ� END
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 Start
        'If Len(pstrKuracd) > 0 Then '�N���C�A���g�R�[�h
        '    strWHE.Append("    AND KURACD = '" & pstrKuracd & "' ")
        'End If
        'If Len(pstrJacd) > 0 Then '�i�`�R�[�h
        '    strWHE.Append("    AND JACD = '" & pstrJacd & "' ")
        'End If
        '2010/03/09 T.Watabe add
        'If pstrTaiouChofuku = "0" Then '0:�d�����܂܂Ȃ��H
        '    strWHE.Append("    AND TAIOKBN <> '3' ")
        'End If
        If Len(pstrKuracdFrom) > 0 Then '�N���C�A���gFROM
            strWHE.Append("    AND KURACD >= :KURACD_FROM ")
        End If
        If Len(pstrKuracdTo) > 0 Then '�N���C�A���gTO
            strWHE.Append("    AND KURACD <= :KURACD_TO ")
        End If
        If Len(pstrJacdFrom) > 0 Then '�i�`�R�[�hFROM
            strWHE.Append("    AND JACD >= :JACD_FROM ")
        End If
        If Len(pstrJacdTo) > 0 Then '�i�`�R�[�hTO
            strWHE.Append("    AND JACD <= :JACD_TO ")
        End If
        If Len(pstrHangrpFrom) > 0 Then '�̔����Ǝ�FROM
            strWHE.Append("    AND HANJICD >= :HANGRP_FROM ")
        End If
        If Len(pstrHangrpTo) > 0 Then '�̔����Ǝ�TO
            strWHE.Append("    AND HANJICD <= :HANGRP_TO ")
        End If
        If Len(pstrHasseiTel) > 0 And Len(pstrHasseiKei) > 0 Then '�����敪:�S�đI��
            strWHE.Append("    AND (HATKBN = :HATKBN1 OR HATKBN = :HATKBN2) ")
        ElseIf Len(pstrHasseiTel) > 0 And Len(pstrHasseiKei) = 0 Then '�����敪:�d�b�̂ݑI��
            strWHE.Append("    AND HATKBN = :HATKBN1 ")
        ElseIf Len(pstrHasseiTel) = 0 And Len(pstrHasseiKei) > 0 Then '�����敪:�x��̂ݑI��
            strWHE.Append("    AND HATKBN = :HATKBN2 ")
        Else
            '�����Ȃ�
        End If
        If Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) > 0 Then '�Ή��敪:�S�đI��
            strWHE.Append("    AND (TAIOKBN = :TAIOKBN1 OR TAIOKBN = :TAIOKBN2 OR TAIOKBN = :TAIOKBN3) ")
        ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) = 0 Then '�Ή��敪:�d�b�E�o����I��
            strWHE.Append("    AND (TAIOKBN = :TAIOKBN1 OR TAIOKBN = :TAIOKBN2) ")
        ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) = 0 And Len(pstrTaiouJuf) > 0 Then '�Ή��敪:�d�b�E�d����I��
            strWHE.Append("    AND (TAIOKBN = :TAIOKBN1 OR TAIOKBN = :TAIOKBN3) ")
        ElseIf Len(pstrTaiouTel) = 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) > 0 Then '�Ή��敪:�o���E�d����I��
            strWHE.Append("    AND (TAIOKBN = :TAIOKBN2 OR TAIOKBN = :TAIOKBN3) ")
        ElseIf Len(pstrTaiouTel) > 0 And Len(pstrTaiouShu) = 0 And Len(pstrTaiouJuf) = 0 Then '�Ή��敪:�d�b�̂ݑI��
            strWHE.Append("    AND TAIOKBN = :TAIOKBN1 ")
        ElseIf Len(pstrTaiouTel) = 0 And Len(pstrTaiouShu) > 0 And Len(pstrTaiouJuf) = 0 Then  '�Ή��敪:�o���̂ݑI��
            strWHE.Append("    AND TAIOKBN = :TAIOKBN2 ")
        ElseIf Len(pstrTaiouTel) = 0 And Len(pstrTaiouShu) = 0 And Len(pstrTaiouJuf) > 0 Then '�Ή��敪:�d���̂ݑI��
            strWHE.Append("    AND TAIOKBN = :TAIOKBN3 ")
        Else
            '�����Ȃ�
        End If
        '2015/02/04 H.Hosoda mod �Ď����P2014 ��14 End

        '2020/09/14 T.Ono add �Ď����P2020 START
        '�쓮�����i�H�������܂܂Ȃ��j
        If pstrTsadcd = "0" Then '�`�F�b�N�Ȃ�
            strWHE.Append("    AND (TSADCD <> '63' OR TSADCD IS NULL) ")
        End If
        '2020/09/14 T.Ono add �Ď����P2020 END

        If ind = 1 Then
            '----------------
            ' 1:�����擾
            '----------------
            strSQL.Append("SELECT COUNT(*) FROM D20_TAIOU ")
            strSQL.Append("    WHERE  ")
            strSQL.Append("        1=1 ")
            strSQL.Append(strWHE) '�����ǉ�
            If False Then
            ElseIf pstrPgKbn = "1" Then '�N���C�A���g�W�v
                strSQL.Append("    GROUP BY KURACD ")
            ElseIf pstrPgKbn = "2" Then '�i�`�W�v
                strSQL.Append("    GROUP BY KURACD, JACD ")
            ElseIf pstrPgKbn = "3" Then '�i�`�x���W�v
                strSQL.Append("    GROUP BY KURACD, ACBCD ")
                '2015/02/13 H.Hosoda add �Ď����P2014 ��14 START
            ElseIf pstrPgKbn = "4" Then  '�̔����ƎҒP�� 
                strSQL.Append("    GROUP BY KURACD, HANJICD ")
                '2017/02/17 H.Mori mod ���P2016 No8-1 START
                'ElseIf pstrPgKbn = "5" Then  '�̔����ƎҎx���P�� 
                '    strSQL.Append("    GROUP BY KURACD, ACBCD, HANJICD ")
                '2015/02/13 H.Hosoda add �Ď����P2014 ��14 END
            ElseIf pstrPgKbn = "6" Then  '���P�� 
                strSQL.Append("    GROUP BY SUBSTR(KURACD,2,2) ")
            ElseIf pstrPgKbn = "7" Then  '�̔����P�� 
                strSQL.Append("    GROUP BY KURACD, HANBCD ")
                '2017/02/17 H.Mori mod ���P2016 No8-1 END
            End If
        Else
            '----------------
            ' 2:�f�[�^�擾
            '----------------
            strSQL.Append("WITH S AS ( ") '�@WITH��i�W�v�R�p�^�[���̈Ⴂ�������ŕ\���B�������ʂɂ��邽�߁B�j
            If False Then
            ElseIf pstrPgKbn = "1" Then '�N���C�A���g�W�v �i��KMCD1=24�́AKMCD2=21,22�̎��ɁA���ꂼ��KMCD1=21,22�ɕϊ�����B2008/12/19 by�Ď��Z���^�[��؎��j
                'strSQL.Append("    SELECT KURACD, NULL  AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(SDSKBN,'2',1,0)) AS SDSCNT ") ' 2009/02/17 T.Watabe edit
                'strSQL.Append("    SELECT KURACD, NULL  AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TFKICD,'8',1,0)) AS SDSCNT ") ' 2009/08/11 T.Watabe edit
                'strSQL.Append("    SELECT KURACD, NULL  AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ") '2017/02/16 H.Mori mod ���P2016 No7-1
                strSQL.Append("    SELECT KURACD, NULL  AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
            ElseIf pstrPgKbn = "2" Then '�i�`�W�v
                'strSQL.Append("    SELECT KURACD,          JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(SDSKBN,'2',1,0)) AS SDSCNT ") ' 2009/02/17 T.Watabe edit
                'strSQL.Append("    SELECT KURACD,          JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TFKICD,'8',1,0)) AS SDSCNT ") ' 2009/08/11 T.Watabe edit
                'strSQL.Append("    SELECT KURACD,          JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ") '2017/02/16 H.Mori mod ���P2016 No7-1
                strSQL.Append("    SELECT KURACD,          JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
            ElseIf pstrPgKbn = "3" Then '�i�`�x���W�v
                'strSQL.Append("    SELECT KURACD, ACBCD AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(SDSKBN,'2',1,0)) AS SDSCNT ") ' 2009/02/17 T.Watabe edit
                'strSQL.Append("    SELECT KURACD, ACBCD AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TFKICD,'8',1,0)) AS SDSCNT ") ' 2009/08/11 T.Watabe edit
                'strSQL.Append("    SELECT KURACD, ACBCD AS JACD, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ")
                'strSQL.Append("    SELECT KURACD, ACBCD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ") '2017/02/16 H.Mori mod ���P2016 No7-1
                strSQL.Append("    SELECT KURACD, ACBCD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
                '2015/02/09 H.Hosoda add �Ď����P2014 ��14 START
            ElseIf pstrPgKbn = "4" Then '�̔����ƎҒP��
                'strSQL.Append("    SELECT KURACD, HANJICD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ") '2017/02/16 H.Mori mod ���P2016 No7-1
                strSQL.Append("    SELECT KURACD, HANJICD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
                '2017/02/17 H.Mori mod ���P2016 No8-1 START
                'ElseIf pstrPgKbn = "5" Then '�̔����ƎҎx���P��
                '    strSQL.Append("    SELECT KURACD, ACBCD AS JACD,HANJICD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT ")
                '2015/02/09 H.Hosoda add �Ď����P2014 ��14 START
            ElseIf pstrPgKbn = "6" Then '���P��
                strSQL.Append("    SELECT SUBSTR(KURACD,2,2) AS KURACD, NULL  AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
            ElseIf pstrPgKbn = "7" Then '�̔����P��
                strSQL.Append("    SELECT KURACD, HANBCD AS JACD, TAIOKBN, DECODE(KMCD1,'24',DECODE(KMCD2,'21','21','22','22',KMCD1),KMCD1) AS KMCD1, HATKBN, COUNT(*) AS CNT, SUM(DECODE(TAIOKBN,'2',1,0)) AS SDSCNT, KMNM1 ")
                '2017/02/17 H.Mori mod ���P2016 No8-1 END
            End If
            strSQL.Append("    FROM D20_TAIOU ")
            strSQL.Append("    WHERE  ")
            strSQL.Append("        1=1 ")
            strSQL.Append(strWHE) '�����ǉ�
            strSQL.Append("    GROUP BY  ")
            strSQL.Append("        KURACD, ")
            strSQL.Append("        JACD, ")
            strSQL.Append("        ACBCD, ")
            strSQL.Append("        HANJICD, ") '2015/02/10 H.Hosoda add �Ď����P2014 ��14
            strSQL.Append("        HANBCD, ") '2017/02/17 H.Mori add ���P2016 No8-1
            strSQL.Append("        KMCD1, ")
            strSQL.Append("        KMCD2, ")
            strSQL.Append("        HATKBN, ")
            strSQL.Append("        TAIOKBN, ") '2010/03/10 T.Watabe add
            strSQL.Append("        KMNM1 ") '2017/02/16 H.Mori add ���P2016 No8-3
            strSQL.Append("    HAVING COUNT(*) <> 0 ")
            strSQL.Append(") ")

            strSQL.Append("SELECT  ") '�A�{��
            strSQL.Append("    A.KURACD, ")
            '2017/02/17 H.Mori mod ���P2016 No8-1 START
            If pstrPgKbn = "6" Then
                strSQL.Append("    B.KEN_NAME AS KURANM, ")
            Else
                strSQL.Append("    B.CLI_NAME AS KURANM, ")
            End If
            '2017/02/17 H.Mori mod ���P2016 No8-1 END
            strSQL.Append("    A.JACD, ")
            If False Then
                '2017/02/17 H.Mori mod ���P2016 No8-1 START
                'ElseIf pstrPgKbn = "1" Then '�N���C�A���g�W�v
            ElseIf pstrPgKbn = "1" Or pstrPgKbn = "6" Or pstrPgKbn = "7" Then '�N���C�A���g�W�v�A���W�v�A�̔����W�v
                '2017/02/17 H.Mori mod ���P2016 No8-1 END
                strSQL.Append("    NULL AS JANM, ")
            ElseIf pstrPgKbn = "2" Then '�i�`�W�v
                '2014/03/24 T.Ono mod JA���̂�JA_CD�Ō�������
                'strSQL.Append("    (SELECT MAX(C.JA_NAME)  FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.HAN_CD = A.JACD) AS JANM, ")
                '2019/11/01 W.GANEKO mod 2019�Ď����P JA���̂�JA_CD�ō폜�ς݂͕\�����Ȃ�
                'strSQL.Append("    (SELECT MAX(C.JA_NAME)  FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.JA_CD = A.JACD) AS JANM, ")
                strSQL.Append("    (SELECT MAX(C.JA_NAME)  FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.JA_CD = A.JACD AND C.DEL_FLG IS NULL) AS JANM, ")
                '2015/02/09 H.Hosoda mod �Ď����P2014 ��14
                'ElseIf pstrPgKbn = "3" Then '�i�`�x���W�v 
                '2017/02/23 H.Mori mod ���P2016 No8-1 �̔����ƎҎx���P�ʂ̍폜
                'ElseIf pstrPgKbn = "3" Or pstrPgKbn = "5" Then '�i�`�x���W�v�A�̔����ƎҎx���P��
            ElseIf pstrPgKbn = "3" Then '�i�`�x���W�v
                '2019/11/01 W.GANEKO mod 2019�Ď����P  JA���̂�JA_CD�ō폜�ς݂͕\�����Ȃ�
                'strSQL.Append("    (SELECT MAX(C.JAS_NAME) FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.HAN_CD = A.JACD) AS JANM, ")
                strSQL.Append("    (SELECT MAX(C.JAS_NAME) FROM HN2MAS C WHERE C.CLI_CD = A.KURACD AND C.HAN_CD = A.JACD AND C.DEL_FLG IS NULL) AS JANM, ")
            ElseIf pstrPgKbn = "4" Then '�̔����ƎҒP�� '2015/02/09 H.Hosoda add �Ď����P2014 ��14
                strSQL.Append("    (SELECT C.HANJIGYOSYANM FROM M10_HANJIGYOSYA C WHERE C.GROUPCD = A.JACD) AS JANM, ")
            End If
            strSQL.Append("    A.C01,A.C02,A.C03,A.C04,A.C05,A.C06,A.C07,A.C08,A.C09,A.C10, ")
            strSQL.Append("    A.C11,A.C12,A.C13,A.C14,A.C15,A.C16,A.C17,A.C18,A.C19, ")
            strSQL.Append("    A.C20,A.C21, ") '2010/03/10 T.Watabe add
            strSQL.Append("    B.KEN_NAME AS KENNM ")
            strSQL.Append("FROM  ")
            strSQL.Append("    ( ")
            strSQL.Append("    SELECT  ")
            strSQL.Append("        KURACD, ")
            strSQL.Append("        JACD, ")
            '�y�g�p���ԃI�[�o�\���z
            strSQL.Append("        SUM(DECODE(KMCD1,'09',CNT,0)) AS C01, ")
            '�y�g�p���ԃI�[�o�Ւf�z
            strSQL.Append("        SUM(DECODE(KMCD1,'02',CNT,0)) AS C02, ")
            '�y�K�X�x���Ւf�z
            strSQL.Append("        SUM(DECODE(KMCD1,'04',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'05',CNT,0)) + ") '2017/11/01 H.Mori add 2017���P�J�� No8-1
            strSQL.Append("        SUM(DECODE(KMCD1,'06',CNT,0)) AS C03, ")
            '�y���̓Z���T�Ւf�z
            strSQL.Append("        SUM(DECODE(KMCD1,'07',CNT,0)) AS C04, ")
            '�y�ő嗬�ʃI�[�o�Ւf�z
            strSQL.Append("        SUM(DECODE(KMCD1,'01',CNT,0)) AS C05, ")
            '�y�Ւf�وُ�z
            strSQL.Append("        SUM(DECODE(KMCD1,'16',CNT,0)) AS C06, ")
            '2017/02/16 H.Mori mod ���P2016 No8-3 START
            '�y�K�X�x���쓮�z
            'strSQL.Append("        SUM(DECODE(KMCD1,'10',CNT,0)) AS C07, ")
            strSQL.Append("        SUM(DECODE(KMCD1,'10',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'11',CNT,0)) + ") '2017/11/01 H.Mori mod 2017���P�J�� No8-1
            strSQL.Append("        SUM(DECODE(KMCD1,'14',CNT,0)) + ") '2017/11/01 H.Mori add 2017���P�J�� No8-1
            strSQL.Append("        SUM(DECODE(KMCD1,'5G',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5I',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'�o���N�x���쓮',CNT,'�K�X�R��x��',CNT,0),0)) AS C07, ")
            '2017/02/16 H.Mori mod ���P2016 No8-3 END
            '2017/11/01 H.Mori mod 2017���P�J�� No8-1 START �W�v���ڂ̌�����
            'strSQL.Append("        SUM(DECODE(KMCD1,'03',CNT,0)) AS C08, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'08',CNT,0)) AS C09, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'15',CNT,0)) AS C10, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'21',CNT,0)) AS C11, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'22',CNT,0)) AS C12, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'23',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'24',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'25',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'26',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'11',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'12',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'13',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'32',CNT,0)) + ")
            ''2015/12/17 T.Ono add �ێ��Ǘ� �x��CD�����Ή� START
            ''strSQL.Append("        SUM(DECODE(KMCD1,'33',CNT,0)) AS C13, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'33',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'35',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'36',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'37',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'38',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'39',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3A',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3B',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3C',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3D',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3E',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3F',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3G',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3H',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3I',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3J',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3K',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3L',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3M',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3N',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'3O',CNT,0)) AS C13, ")
            ''2015/12/17 T.Ono add �ێ��Ǘ� �x��CD�����Ή� END
            'strSQL.Append("        SUM(DECODE(KMCD1,'20',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'17',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'18',CNT,0)) AS C14, ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'19',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'27',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'28',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'29',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'30',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'31',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'40',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'49',CNT,0)) + ")
            ''2017/02/16 H.Mori mod ���P2016 No8-3 START
            ''strSQL.Append("        SUM(DECODE(KMCD1,'50',CNT,0)) AS C15, ")           
            'strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'�o���N�x���쓮',0,'�K�X�R��x��',0,CNT),0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5A',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5B',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5C',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5D',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5E',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5F',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5H',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5J',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5K',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5L',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5M',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5N',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5O',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5P',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5Q',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5R',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5S',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5T',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5U',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5V',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5W',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5X',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5Y',CNT,0)) + ")
            'strSQL.Append("        SUM(DECODE(KMCD1,'5Z',CNT,0)) AS C15, ")
            ''2017/02/16 H.Mori mod ���P2016 No8-3 END
            '�y���k��Ւf�z
            strSQL.Append("        SUM(DECODE(KMCD1,'08',CNT,0)) AS C08, ")
            '�y���S�m�F���Ւf�z
            strSQL.Append("        SUM(DECODE(KMCD1,'15',CNT,0)) AS C09, ")
            '�y�����R�k(��)�z
            strSQL.Append("        SUM(DECODE(KMCD1,'21',CNT,0)) AS C10, ")
            '�y�����R�k(��)�z
            strSQL.Append("        SUM(DECODE(KMCD1,'22',CNT,0)) AS C11, ")
            '�y���̑��P�z
            strSQL.Append("        SUM(DECODE(KMCD1,'03',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'32',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'33',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'34',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'35',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3C',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3D',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3E',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3I',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3J',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3K',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3L',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3M',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3N',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3O',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'40',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'�t���x��',CNT,'�x�[�p���C�U�[�ُ�',CNT,'�Ւf�ق����܂���',CNT,")
            strSQL.Append("        '�M���@�ُ�',CNT,'�Q�������͂��ቺ���܂���',CNT,'���Ԉ��ُ͈�',CNT,'�G�A�[���ُ͈�',CNT,")
            strSQL.Append("        '�l�P�|�[�g�����삵�܂����B',CNT,'�{���x�Ɉُ�',CNT,'�T�[���o���u�쓮�i�x�[�o�j',CNT,'�ً}�Ւf�ف^�ϐk�Ւf�ف@�쓮',CNT,")
            strSQL.Append("        '�C����ُ�',CNT,0),0)) +")
            strSQL.Append("        SUM(DECODE(KMCD1,'5F',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5J',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5L',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5M',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5N',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5P',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5Q',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5R',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5T',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5U',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5Y',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5Z',CNT,0)) AS C12, ")
            '�y���̑��Q�z
            strSQL.Append("        SUM(DECODE(KMCD1,'12',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'13',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'17',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'18',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'23',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'24',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'25',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'26',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3F',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3G',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3H',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'�x�m�b�t�e�@�R���Z���g����',CNT,0),0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5A',CNT,0)) AS C13, ")
            '�y�Ǘ����P�z
            strSQL.Append("        SUM(DECODE(KMCD1,'19',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'20',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'27',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'28',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'29',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'30',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'31',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'36',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'37',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'38',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'39',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3A',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'3B',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'49',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'50',DECODE(KMNM1,'�o���N�c�ʌx���S�O���쓮',CNT,'�o���N�c�ʌx���S�O��',CNT,'�o���N�c�ʌx���Q�O���쓮',CNT,")
            strSQL.Append("        '�o���N�c�ʌx���Q�O��',CNT,'�����ؑւ��؂�ւ��܂���',CNT,'�����ؑւ��������܂���',CNT,'�o���N�x��한��',CNT,'�x�[�p�[���C�U�[����',CNT,")
            strSQL.Append("        '�Q�������͂�����ɂȂ�܂���',CNT,'�l�P�|�[�g���������܂����B',CNT,'�T�[���o���u�����i�x�[�o�j',CNT,'�m�b�t�e�X�g�@���픭��',CNT,")
            strSQL.Append("        '�ً}�Ւf�ف^�ϐk�Ւf�ف@��',CNT,0),0)) +")
            strSQL.Append("        SUM(DECODE(KMCD1,'5B',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5C',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5D',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5E',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5H',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5K',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5O',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5S',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5V',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5W',CNT,0)) + ")
            strSQL.Append("        SUM(DECODE(KMCD1,'5X',CNT,0)) AS C14, ")
            '�y�Ǘ����Q�z
            strSQL.Append("        SUM(DECODE(KMCD1,'99',CNT,0)) AS C15, ")
            '2017/11/01 H.Mori mod 2017���P�J�� No8-1 END �W�v���ڂ̌�����
            strSQL.Append("        SUM(DECODE(HATKBN,'2',CNT,0)) AS C16, ")
            strSQL.Append("        SUM(DECODE(HATKBN,'1',CNT,0)) AS C17, ")
            strSQL.Append("        SUM(CNT) AS C18, ")
            strSQL.Append("        SUM(SDSCNT) AS C19, ")
            strSQL.Append("        SUM(DECODE(HATKBN,'2', DECODE(TAIOKBN,'2',CNT,0),0)) AS C20, ") '2:�x��2:�o�� 2010/03/10 T.Watabe add
            strSQL.Append("        SUM(DECODE(HATKBN,'1', DECODE(TAIOKBN,'2',CNT,0),0)) AS C21  ") '1:�d�b��2:�o�� 2010/03/10 T.Watabe add
            strSQL.Append("    FROM S ")
            strSQL.Append("    GROUP BY  ")
            strSQL.Append("        KURACD, ")
            strSQL.Append("        JACD ")
            '2017/02/23 H.Mori del ���P2016 No8-1 �̔����ƎҎx���P�ʂ̍폜 START
            '2015/02/13 H.Hosoda add �Ď����P2014 ��14 START
            'If pstrPgKbn = "5" Then '�̔����ƎҎx���P��
            '    strSQL.Append("        ,HANJICD ")
            'End If
            '2015/02/13 H.Hosoda add �Ď����P2014 ��14 END
            '2017/02/23 H.Mori del ���P2016 No8-1 �̔����ƎҎx���P�ʂ̍폜 END
            strSQL.Append("    ) A, ")
            '2017/02/23 H.Mori mod ���P2016 No8-1 START
            If pstrPgKbn = "6" Then
                strSQL.Append("(SELECT KEN_CODE,KEN_NAME FROM CLIMAS GROUP BY KEN_CODE,KEN_NAME) B ")
            Else
                strSQL.Append("    CLIMAS B ")
            End If
            '2017/02/23 H.Mori mod ���P2016 No8-1 END
            strSQL.Append("WHERE  ")
            '2017/02/21 H.Mori mod ���P2016 No8-1 START
            If pstrPgKbn = "6" Then
                strSQL.Append("    B.KEN_CODE(+) = A.KURACD ")
            Else
                strSQL.Append("    B.CLI_CD(+) = A.KURACD ")
            End If
            '2017/02/21 H.Mori mod ���P2016 No8-1 END
            strSQL.Append("ORDER BY  ")
            strSQL.Append("    A.KURACD, ")
            strSQL.Append("    A.JACD ")
        End If

        Return strSQL.ToString

    End Function

End Class
