'***********************************************
' PGID�FKERUIJOW00
' PG���F�ݐϏ��ꗗ
'***********************************************
' �ύX����
' 2010/03/05 T.Watabe ���[�^���j�l(D20_TAIOU.KENSIN)�𒠕[�ɒǉ�
' 2010/06/02 T.Watabe �[�����o�͂ɑΉ�
' 2010/09/10 T.Watabe �߰��̨��
' 2011/02/01 T.Watabe ���[�G�N�Z�������kexe�`���֕ύX���ē]��������@����߂�B���̂܂ܓ]���B
' 2011/02/10 T.Watabe �����̕����֖߂�
' 2011/05/11 T.Watabe FAX���M���s������̂��߁A�o�̓G�N�Z���t�@�C���̔{���A�}�[�W����ύX�B�{��93��100�A�}�[�W�����E�k��
' 2011/06/02 T.Watabe �t�@�C�������u�ݐϏ��_<JA��>_�Z�b�V����ID.xls�v�ɕύX
' 2011/11/21 H.Uema   �����敪�Ɂu�d�b�^�x��v���ڒǉ��ɔ����C���B

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB
Imports Common.CCompress

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.IO
Imports System.IO.Compression

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KERUIJOW00/Service1")> _
Public Class KERUIJOW00
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

    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '******************************************************************************
    '*�@�T�@�v:�����`�F�b�N���s��
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    '<WebMethod()> Public Function mCheck( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJacd As String, _
    '                                    ByVal pstrJascd As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal _
    '                                    ) As String
    '    Return mCheck2( _
    '        pstrKuracd, _
    '        pstrKyocd, _
    '        pstrJacd, _
    '        pstrJacd, _
    '        pstrJascd, _
    '        pstrJascd, _
    '        pstrStkbn, _
    '        pstrTrgFrom, _
    '        pstrTrgTo, _
    '        pdecPageMax _
    '        )
    '    End Function
    '******************************************************************************
    '*�@�T�@�v:�����`�F�b�N���s��
    '*�@���@�l:
    '******************************************************************************
    '2017/02/15 H.Mori mod ���P2016 No9-1 START
    '<WebMethod()> Public Function mCheck( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJacdFr As String, _
    '                                    ByVal pstrJacdTo As String, _
    '                                    ByVal pstrJascdFr As String, _
    '                                    ByVal pstrJascdTo As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrHanbaiCdFr As String, _
    '                                    ByVal pstrHanbaiCdTo As String, _
    '                                    ByVal pstrTaikbn As String, _
    '                                    ByVal pstrHkkbn As String _
    '                                    ) As String
    '    Return mCheck2( _
    'pstrKuracd, _
    'pstrKyocd, _
    'pstrJacdFr, _
    'pstrJacdTo, _
    'pstrJascdFr, _
    'pstrJascdTo, _
    'pstrStkbn, _
    'pstrTrgFrom, _
    'pstrTrgTo, _
    'pdecPageMax, _
    'pstrHanbaiCdFr, _
    'pstrHanbaiCdTo, _
    'pstrTaikbn, _
    'pstrHkkbn _
    ')

    'End Function
    <WebMethod()> Public Function mCheck( _
                                        ByVal pstrKuracd As String, _
                                        ByVal pstrKyocd As String, _
                                        ByVal pstrJacdFr As String, _
                                        ByVal pstrJacdTo As String, _
                                        ByVal pstrJascdFr As String, _
                                        ByVal pstrJascdTo As String, _
                                        ByVal pstrStkbn As String, _
                                        ByVal pstrTrgFrom As String, _
                                        ByVal pstrTrgTo As String, _
                                        ByVal pdecPageMax As Decimal, _
                                        ByVal pstrHanbaiCdFr As String, _
                                        ByVal pstrHanbaiCdTo As String, _
                                        ByVal pstrTaikbn As String, _
                                        ByVal pstrHkkbn As String, _
                                        ByVal pstrKikankbn As String, _
                                        ByVal pstrTrgTimeFrom As String, _
                                        ByVal pstrTrgTimeTo As String _
                                        ) As String
        Return mCheck2( _
    pstrKuracd, _
    pstrKyocd, _
    pstrJacdFr, _
    pstrJacdTo, _
    pstrJascdFr, _
    pstrJascdTo, _
    pstrStkbn, _
    pstrTrgFrom, _
    pstrTrgTo, _
    pdecPageMax, _
    pstrHanbaiCdFr, _
    pstrHanbaiCdTo, _
    pstrTaikbn, _
    pstrHkkbn, _
    pstrKikankbn, _
    pstrTrgTimeFrom, _
    pstrTrgTimeTo _
    )

    End Function
    '2017/02/15 H.Mori mod ���P2016 No9-1 END

    '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '2017/02/15 H.Mori mod ���P2016 No9-1 START
    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '<WebMethod()> Public Function mCheck2( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJaCdFr As String, _
    '                                    ByVal pstrJaCdTo As String, _
    '                                    ByVal pstrJasCdFr As String, _
    '                                    ByVal pstrJasCdTo As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal _
    '                                    ) As String
    '<WebMethod()> Public Function mCheck2( _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJaCdFr As String, _
    '                                    ByVal pstrJaCdTo As String, _
    '                                    ByVal pstrJasCdFr As String, _
    '                                    ByVal pstrJasCdTo As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrHanbaiCdFr As String, _
    '                                    ByVal pstrHanbaiCdTo As String, _
    '                                    ByVal pstrTaikbn As String, _
    '                                    ByVal pstrHkkbn As String _
    '                                    ) As String
    <WebMethod()> Public Function mCheck2( _
                                        ByVal pstrKuracd As String, _
                                        ByVal pstrKyocd As String, _
                                        ByVal pstrJaCdFr As String, _
                                        ByVal pstrJaCdTo As String, _
                                        ByVal pstrJasCdFr As String, _
                                        ByVal pstrJasCdTo As String, _
                                        ByVal pstrStkbn As String, _
                                        ByVal pstrTrgFrom As String, _
                                        ByVal pstrTrgTo As String, _
                                        ByVal pdecPageMax As Decimal, _
                                        ByVal pstrHanbaiCdFr As String, _
                                        ByVal pstrHanbaiCdTo As String, _
                                        ByVal pstrTaikbn As String, _
                                        ByVal pstrHkkbn As String, _
                                        ByVal pstrKikankbn As String, _
                                        ByVal pstrTrgTimeFrom As String, _
                                        ByVal pstrTrgTimeTo As String _
                                        ) As String
        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
        '2017/02/15 H.Mori mod ���P2016 No9-1 END
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
            Dim SQL As String
            '2011.11.21 MOD H.Uema *---------------------* start
            'SQL = fncMakeSelect(2, _
            '                         pstrKuracd, _
            '                         pstrKyocd, _
            '                         pstrJaCdFr, _
            '                         pstrJaCdTo, _
            '                         pstrJasCdFr, _
            '                         pstrJasCdTo, _
            '                         pstrTrgFrom, _
            '                         pstrTrgTo, _
            '                         "", _
            '                         pdecPageMax)
            '2015/11/04 w.ganeko 2015���P�J�� ��6 start
            'SQL = fncMakeSelect(2, _
            '                    pstrKuracd, _
            '                    pstrKyocd, _
            '                    pstrJaCdFr, _
            '                    pstrJaCdTo, _
            '                    pstrJasCdFr, _
            '                    pstrJasCdTo, _
            '                    pstrTrgFrom, _
            '                    pstrTrgTo, _
            '                    "", _
            '                    pdecPageMax, _
            '                    pstrStkbn)
            '2017/02/15 H.Mori mod ���P2016 No9-1 START
            'SQL = fncMakeSelect(2, _
            '                    pstrKuracd, _
            '                    pstrKyocd, _
            '                    pstrJaCdFr, _
            '                    pstrJaCdTo, _
            '                    pstrJasCdFr, _
            '                    pstrJasCdTo, _
            '                    pstrTrgFrom, _
            '                    pstrTrgTo, _
            '                    "", _
            '                    pdecPageMax, _
            '                    pstrStkbn, _
            '                    pstrHanbaiCdFr, _
            '                    pstrHanbaiCdTo, _
            '                    pstrTaikbn, _
            '                    pstrHkkbn)
            '2015/11/04 w.ganeko 2015���P�J�� ��6 end
            '2011.11.21 MOD H.Uema *---------------------* end
            SQL = fncMakeSelect(2, _
                                pstrKuracd, _
                                pstrKyocd, _
                                pstrJaCdFr, _
                                pstrJaCdTo, _
                                pstrJasCdFr, _
                                pstrJasCdTo, _
                                pstrTrgFrom, _
                                pstrTrgTo, _
                                "", _
                                pdecPageMax, _
                                pstrStkbn, _
                                pstrHanbaiCdFr, _
                                pstrHanbaiCdTo, _
                                pstrTaikbn, _
                                pstrHkkbn, _
                                pstrKikankbn, _
                                pstrTrgTimeFrom, _
                                pstrTrgTimeTo)
            '2017/02/15 H.Mori mod ���P2016 No9-1 END

            'Return "DEBUG:" & SQL
            cdb.pSQL = SQL
            '�p�����[�^�Z�b�g
            If pstrKuracd.Length <> 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKuracd
            End If
            If pstrKyocd.Length > 0 Then cdb.pSQLParamStr("KYOCD") = pstrKyocd
            '2015/11/04 w.ganeko 2015���P�J�� ��6 start
            If pstrHanbaiCdFr.Length > 0 Then cdb.pSQLParamStr("GROUPCDFR") = pstrHanbaiCdFr
            If pstrHanbaiCdTo.Length > 0 Then cdb.pSQLParamStr("GROUPCDTO") = pstrHanbaiCdTo
            '2015/11/04 w.ganeko 2015���P�J�� ��6 end
            If pstrJaCdFr.Length > 0 Then cdb.pSQLParamStr("JACDFR") = pstrJaCdFr
            If pstrJaCdTo.Length > 0 Then cdb.pSQLParamStr("JACDTO") = pstrJaCdTo
            If pstrJasCdFr.Length > 0 Then cdb.pSQLParamStr("JASCDFR") = pstrJasCdFr
            If pstrJasCdTo.Length > 0 Then cdb.pSQLParamStr("JASCDTO") = pstrJasCdTo
            cdb.pSQLParamStr("HATKBN") = pstrStkbn
            If pstrTrgFrom.Length > 0 Then cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            If pstrTrgTo.Length > 0 Then cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            '2017/02/15 H.Mori add ���P2016 No9-1 START
            If pstrTrgTimeFrom.Length > 0 Then cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            If pstrTrgTimeTo.Length > 0 Then cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            '2017/02/15 H.Mori add ���P2016 No9-1 END

            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�������̏�����Ȃ����@2013/12/05 T.Ono mod �Ď����P2013
            '�f�[�^�����݂��Ȃ��ꍇ
            'If ds.Tables(0).Rows.Count = 0 Then
            '    Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            'ElseIf ds.Tables(0).Rows.Count > decGyoMax Then
            '    Return "DATAMAX"    '�f�[�^���ő�s���𒴂��鎖�������������Ԃ�
            'End If
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
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
    '*�@�T�@�v:�ꗗ�̏o�͂��s���܂�
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJacd As String, _
    '                                    ByVal pstrJascd As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKuraNm As String, _
    '                                    ByVal pstrKyoNm As String, _
    '                                    ByVal pstrJaNm As String, _
    '                                    ByVal pstrJasNm As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrCentcd As String _
    '                                    ) As String
    '2017/02/15 H.Mori mod ���P2016 No9-1 START
    '<WebMethod()> Public Function mExcel( _
    '                                    ByVal pstrSessionID As String, _
    '                                    ByVal pstrKuracd As String, _
    '                                    ByVal pstrKyocd As String, _
    '                                    ByVal pstrJacdFr As String, _
    '                                    ByVal pstrJacdTo As String, _
    '                                    ByVal pstrJascdFr As String, _
    '                                    ByVal pstrJascdTo As String, _
    '                                    ByVal pstrStkbn As String, _
    '                                    ByVal pstrPgkbn As String, _
    '                                    ByVal pstrTrgFrom As String, _
    '                                    ByVal pstrTrgTo As String, _
    '                                    ByVal pstrKuraNm As String, _
    '                                    ByVal pstrKyoNm As String, _
    '                                    ByVal pstrJaNmFr As String, _
    '                                    ByVal pstrJaNmTo As String, _
    '                                    ByVal pstrJasNmFr As String, _
    '                                    ByVal pstrJasNmTo As String, _
    '                                    ByVal pdecPageMax As Decimal, _
    '                                    ByVal pstrCentcd As String, _
    '                                    ByVal pstrHanbaiCdFr As String, _
    '                                    ByVal pstrHanbaiCdTo As String, _
    '                                    ByVal pstrTaikbn As String, _
    '                                    ByVal pstrHkkbn As String, _
    '                                    ByVal pstrHanbaiNmFr As String, _
    '                                    ByVal pstrHanbaiNmTo As String _
    '                                    ) As String

    '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '2020/11/01 T.Ono mod 2020�Ď����P pstrSdPrt�ǉ�
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKuracd As String,
                                        ByVal pstrKyocd As String,
                                        ByVal pstrJacdFr As String,
                                        ByVal pstrJacdTo As String,
                                        ByVal pstrJascdFr As String,
                                        ByVal pstrJascdTo As String,
                                        ByVal pstrStkbn As String,
                                        ByVal pstrPgkbn As String,
                                        ByVal pstrTrgFrom As String,
                                        ByVal pstrTrgTo As String,
                                        ByVal pstrKuraNm As String,
                                        ByVal pstrKyoNm As String,
                                        ByVal pstrJaNmFr As String,
                                        ByVal pstrJaNmTo As String,
                                        ByVal pstrJasNmFr As String,
                                        ByVal pstrJasNmTo As String,
                                        ByVal pdecPageMax As Decimal,
                                        ByVal pstrCentcd As String,
                                        ByVal pstrHanbaiCdFr As String,
                                        ByVal pstrHanbaiCdTo As String,
                                        ByVal pstrTaikbn As String,
                                        ByVal pstrHkkbn As String,
                                        ByVal pstrHanbaiNmFr As String,
                                        ByVal pstrHanbaiNmTo As String,
                                        ByVal pstrKikankbn As String,
                                        ByVal pstrTrgTimeFrom As String,
                                        ByVal pstrTrgTimeTo As String,
                                        ByVal pstrSdPrt As String
                                        ) As String
        '2017/02/15 H.Mori mod ���P2016 No9-1 END

        '2016/12/05 T.Ono add 2016���P�J�� ��12
        Dim faxNo() As String = {"", ""}
        Dim mailADD() As String = {"", ""}

        '2014/01/06 T.Ono mod �Ď����P2013
        '�ݐϏ��ꗗ���j���[����̏o�͌`����exe��xls�֕ύX����
        '�ݐώ���FAX��exe�̂܂܂ɂ��Ă����K�v�����邽�߁A
        '���j���[����́umExcel3�v�@�ݐώ���FAX����́umExcel2�v���g�p����
        'Return mExcel2( _
        '                pstrSessionID, _
        '                pstrKuracd, _
        '                pstrKyocd, _
        '                pstrJacd, _
        '                pstrJacd, _
        '                pstrJascd, _
        '                pstrJascd, _
        '                pstrStkbn, _
        '                pstrPgkbn, _
        '                pstrTrgFrom, _
        '                pstrTrgTo, _
        '                pstrKuraNm, _
        '                pstrKyoNm, _
        '                pstrJaNm, _
        '                pstrJasNm, _
        '                pdecPageMax, _
        '                pstrCentcd, _
        '                "0", _
        '                True _
        '                )
        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
        'Return mExcel3( _
        '                pstrSessionID, _
        '                pstrKuracd, _
        '                pstrKyocd, _
        '                pstrJacd, _
        '                pstrJacd, _
        '                pstrJascd, _
        '                pstrJascd, _
        '                pstrStkbn, _
        '                pstrPgkbn, _
        '                pstrTrgFrom, _
        '                pstrTrgTo, _
        '                pstrKuraNm, _
        '                pstrKyoNm, _
        '                pstrJaNm, _
        '                pstrJasNm, _
        '                pdecPageMax, _
        '                pstrCentcd, _
        '                "0", _
        '                True _
        '                )
        '2017/02/15 H.Mori mod ���P2016 No9-1 START
        'Return mExcel3( _
        '        pstrSessionID, _
        '        pstrKuracd, _
        '        pstrKyocd, _
        '        pstrJacdFr, _
        '        pstrJacdTo, _
        '        pstrJascdFr, _
        '        pstrJascdTo, _
        '        pstrStkbn, _
        '        pstrPgkbn, _
        '        pstrTrgFrom, _
        '        pstrTrgTo, _
        '        pstrKuraNm, _
        '        pstrKyoNm, _
        '        pstrJaNmFr, _
        '        pstrJaNmTo, _
        '        pstrJasNmFr, _
        '        pstrJasNmTo, _
        '        pdecPageMax, _
        '        pstrCentcd, _
        '        "0", _
        '        True, _
        '        pstrHanbaiCdFr, _
        '        pstrHanbaiCdTo, _
        '        pstrTaikbn, _
        '        pstrHkkbn, _
        '        pstrHanbaiNmFr, _
        '        pstrHanbaiNmTo, _
        '        "0", _
        '        faxNo, _
        '        mailADD _
        '        )
        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
        '2020/11/01 T.Ono mod 2020�Ď����P pstrSdPrt�ǉ�
        Return mExcel3(
                pstrSessionID,
                pstrKuracd,
                pstrKyocd,
                pstrJacdFr,
                pstrJacdTo,
                pstrJascdFr,
                pstrJascdTo,
                pstrStkbn,
                pstrPgkbn,
                pstrTrgFrom,
                pstrTrgTo,
                pstrKuraNm,
                pstrKyoNm,
                pstrJaNmFr,
                pstrJaNmTo,
                pstrJasNmFr,
                pstrJasNmTo,
                pdecPageMax,
                pstrCentcd,
                "0",
                pstrSdPrt,
                True,
                pstrHanbaiCdFr,
                pstrHanbaiCdTo,
                pstrTaikbn,
                pstrHkkbn,
                pstrHanbaiNmFr,
                pstrHanbaiNmTo,
                "0",
                faxNo,
                mailADD,
                pstrKikankbn,
                pstrTrgTimeFrom,
                pstrTrgTimeTo
                )
        '2017/02/15 H.Mori mod ���P2016 No9-1 END
    End Function
    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '<WebMethod()> Public Function mExcel2( _
    '                                ByVal pstrSessionID As String, _
    '                                ByVal pstrKuracd As String, _
    '                                ByVal pstrKyocd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrStkbn As String, _
    '                                ByVal pstrPgkbn As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrKuraNm As String, _
    '                                ByVal pstrKyoNm As String, _
    '                                ByVal pstrJaNm As String, _
    '                                ByVal pstrJasNm As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrCentcd As String, _
    '                                ByVal pstrZeroSend As String, _
    '                                ByVal pbolLzhAutoExec As Boolean _
    '                                ) As String

    '    Dim strSQL As New StringBuilder("")
    '    Dim cdb As New CDB
    '    Dim ds As New DataSet
    '    Dim dr As DataRow
    '    Dim intGYOSU As Integer = 5                     '���s������s��
    '    Dim intGyoMax As Integer = CInt(pdecPageMax)    '�ő�s��
    '    'Dim intGyoMax As Integer = 4500 '�ő�s��
    '    Dim ExcelC As New CExcel                        'Excel�N���X
    '    Dim compressC As New CCompress                  '���k�N���X
    '    Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
    '    Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
    '    Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
    '    Dim strHedInfo As String                        '�w�b�_�[���i���o�����j
    '    Dim intPrntRow As Integer = 72
    '    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '    Dim pstrHanbaiCdFr As String = ""
    '    Dim pstrHanbaiCdTo As String = ""
    '    Dim pstrTaikbn As String = "0"
    '    Dim pstrHkkbn As String = "2"
    '    Dim pstrHanbaiNmFr As String = ""
    '    Dim pstrHanbaiNmTo As String = ""
    '    Dim pstrZipFlg As String = "1"
    '    '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '    Dim strTmp() As String

    '    '�ڑ�OPEN----------------------------------------
    '    Try
    '        cdb.mOpen()
    '    Catch ex As Exception
    '        Return ex.ToString
    '    Finally

    '    End Try

    '    ' ---------------------------------
    '    ' �i�`���A�����A�N���C�A���g���A�������������擾
    '    ' ---------------------------------
    '    Dim jaNmFr As String = ""
    '    Dim jaNmTo As String = ""
    '    Dim jasNmFr As String = ""
    '    Dim jasNmTo As String = ""
    '    Dim kenNm As String = ""
    '    Dim HanNmFr As String = ""
    '    Dim HanNmTo As String = ""
    '    'Dim clientNm As String = ""
    '    Dim centerNm As String = ""
    '    Try
    '        jaNmFr = getDB2JasNm(cdb, pstrKuracd, pstrJaCdFr)
    '        jaNmFr = jaNmFr.Trim
    '        If pstrJaCdFr.Length <> 0 And pstrJaCdFr = pstrJaCdTo Then
    '            jaNmTo = jaNmFr
    '        Else
    '            jaNmTo = getDB2JasNm(cdb, pstrKuracd, pstrJaCdTo)
    '        End If
    '        jasNmFr = getDB2JasNm(cdb, pstrKuracd, pstrJasCdFr)
    '        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '        strTmp = pstrHanbaiNmFr.Split(Convert.ToChar(":"))
    '        HanNmFr = strTmp(strTmp.Length - 1).Trim
    '        If pstrHanbaiCdFr.Length <> 0 And pstrHanbaiCdFr = pstrHanbaiCdTo Then
    '            HanNmTo = HanNmFr
    '        ElseIf pstrHanbaiCdTo.Length <> 0 Then
    '            strTmp = pstrHanbaiNmTo.Split(Convert.ToChar(":"))
    '            HanNmTo = strTmp(strTmp.Length - 1).Trim
    '        End If
    '        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '        If pstrJasCdFr.Length <> 0 And pstrJasCdFr = pstrJasCdTo Then
    '            jasNmTo = jasNmFr
    '        Else
    '            jasNmTo = getDB2JasNm(cdb, pstrKuracd, pstrJasCdTo)
    '        End If
    '        kenNm = getDB2KenNm(cdb, pstrKuracd)

    '        '2011.11.22 MOD H.Uema �N���C�A���g���w��̏ꍇ�A������̂ŏC��
    '        'centerNm = getDB2CenterNm(cdb, pstrKuracd.Substring(1, 2), pstrKyocd)
    '        If (pstrKuracd.Length > 2) Then
    '            centerNm = getDB2CenterNm(cdb, pstrKuracd.Substring(1, 2), pstrKyocd)
    '        End If

    '    Catch ex As Exception
    '        '2011.11.22 MOD H.Uema *----------* start
    '        'Return ex.ToString
    '        cdb.mClose()        '�ڑ��N���[�Y
    '        Return "ERROR:" & ex.ToString
    '        '2011.11.22 MOD H.Uema *----------* end
    '    Finally
    '    End Try

    '    '���[�o�͍��ڂ̎擾�pSQL���Z�b�g-------------------
    '    Try
    '        '2011.11.21 MOD H.Uema *---------------------* start
    '        '���[�o�͍��ڂ̎擾�pSQL���Z�b�g
    '        'strSQL.Append(fncMakeSelect(2, _
    '        '                         pstrKuracd, _
    '        '                         pstrKyocd, _
    '        '                         pstrJaCdFr, _
    '        '                         pstrJaCdTo, _
    '        '                         pstrJasCdFr, _
    '        '                         pstrJasCdTo, _
    '        '                         pstrTrgFrom, _
    '        '                         pstrTrgTo, _
    '        '                         pstrPgkbn, _
    '        '                         pdecPageMax))
    '        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '        'strSQL.Append(fncMakeSelect(2, _
    '        '                        pstrKuracd, _
    '        '                        pstrKyocd, _
    '        '                        pstrJaCdFr, _
    '        '                        pstrJaCdTo, _
    '        '                        pstrJasCdFr, _
    '        '                        pstrJasCdTo, _
    '        '                        pstrTrgFrom, _
    '        '                        pstrTrgTo, _
    '        '                        pstrPgkbn, _
    '        '                        pdecPageMax, _
    '        '                        pstrStkbn))
    '        strSQL.Append(fncMakeSelect(2, _
    '                                pstrKuracd, _
    '                                pstrKyocd, _
    '                                pstrJaCdFr, _
    '                                pstrJaCdTo, _
    '                                pstrJasCdFr, _
    '                                pstrJasCdTo, _
    '                                pstrTrgFrom, _
    '                                pstrTrgTo, _
    '                                pstrPgkbn, _
    '                                pdecPageMax, _
    '                                pstrStkbn, _
    '                                pstrHanbaiCdFr, _
    '                                pstrHanbaiCdTo, _
    '                                pstrTaikbn, _
    '                                pstrHkkbn
    '                               ))
    '        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '        '2011.11.21 MOD H.Uema *---------------------* end

    '        cdb.pSQL = strSQL.ToString

    '        '�p�����[�^�Z�b�g
    '        If pstrKuracd.Length <> 0 Then
    '            cdb.pSQLParamStr("KURACD") = pstrKuracd
    '        End If
    '        If pstrKyocd.Length > 0 Then cdb.pSQLParamStr("KYOCD") = pstrKyocd
    '        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '        If pstrHanbaiCdFr.Length > 0 Then cdb.pSQLParamStr("GROUPCDFR") = pstrHanbaiCdFr
    '        If pstrHanbaiCdTo.Length > 0 Then cdb.pSQLParamStr("GROUPCDTO") = pstrHanbaiCdTo
    '        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '        If pstrJaCdFr.Length > 0 Then cdb.pSQLParamStr("JACDFR") = pstrJaCdFr
    '        If pstrJaCdTo.Length > 0 Then cdb.pSQLParamStr("JACDTO") = pstrJaCdTo
    '        If pstrJasCdFr.Length > 0 Then cdb.pSQLParamStr("JASCDFR") = pstrJasCdFr
    '        If pstrJasCdTo.Length > 0 Then cdb.pSQLParamStr("JASCDTO") = pstrJasCdTo
    '        cdb.pSQLParamStr("HATKBN") = pstrStkbn '�����敪
    '        If pstrTrgFrom.Length > 0 Then cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
    '        If pstrTrgTo.Length > 0 Then cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo

    '        cdb.mExecQuery()    'SQL���s
    '        ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

    '        '�������̏�����Ȃ����@2013/12/05 T.Ono mod �Ď����P2013
    '        ''�f�[�^�����݂��Ȃ��ꍇ
    '        'If ds.Tables(0).Rows.Count = 0 And pstrZeroSend <> "1" Then
    '        '    Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
    '        'ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
    '        '    Return "DATAMAX"    '�f�[�^���ő�s���𒴂��鎖�������������Ԃ�
    '        'End If
    '        If ds.Tables(0).Rows.Count = 0 And pstrZeroSend <> "1" Then
    '            Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
    '        End If

    '        'dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
    '        ExcelC.pKencd = "00"                '�N���C�A���g�R�[�h���Z�b�g
    '        ExcelC.pSessionID = pstrSessionID   '�Z�b�V����ID
    '        ExcelC.pRepoID = "KERUIJOX00"       '���[ID
    '        ExcelC.mOpen()                      '�t�@�C���I�[�v��

    '        '2014/03/20 T.Ono mod FAX�^�C�g���ύX�v�]
    '        'ExcelC.pTitle = "�ݐϏ��ꗗ�\"                        '�^�C�g��
    '        'ExcelC.pTitle = "�Ď��Z���^�[�Ή����ʗݐϖ��ׁi���񍐁j" '�^�C�g��  2014/03/31 T.Ono mod "()"�𔼊p�ɁBExcel2003���ƍ쐬���̉E�񂹂��Â��A�^�C�g���Əd�Ȃ�
    '        ExcelC.pTitle = "�Ď��Z���^�[�Ή����ʗݐϖ���(����)" '�^�C�g��
    '        ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '�쐬��
    '        'ExcelC.pScale = 93                                      '�k���g�嗦(%)
    '        ExcelC.pScale = 100                                      '�k���g�嗦(%) ' 2011/05/11 T.Watabe edit
    '        'ExcelC.pFitPaper = True                                 '�߰��̨�� 2010/09/10 T.Watabe add

    '        '�������
    '        ExcelC.pLandScape = False
    '        '�]��
    '        ExcelC.pMarginTop = 2D
    '        'ExcelC.pMarginBottom = 1.6D
    '        ExcelC.pMarginBottom = 0.6D
    '        'ExcelC.pMarginLeft = 2D    ' 2011/05/11 T.Watabe edit
    '        'ExcelC.pMarginRight = 1.1D ' 2011/05/11 T.Watabe edit
    '        ExcelC.pMarginLeft = 1.7D
    '        ExcelC.pMarginRight = 0D
    '        ExcelC.pMarginHeader = 1.3D
    '        ExcelC.pMarginFooter = 1.3D

    '        '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
    '        'ExcelC.mHeader(intGYOSU, ds.Tables(0).Rows.Count, 5)
    '        ExcelC.mHeader(intPrntRow, ds.Tables(0).Rows.Count, 4)

    '        '�e��̕����s�N�Z���ŃZ�b�g�B�g���������B
    '        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
    '        'ExcelC.pCellStyle(1) = "height:0px;width:66px;border-style:none"
    '        ExcelC.pCellStyle(1) = "height:0px;width:71px;border-style:none"
    '        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
    '        ExcelC.pCellStyle(2) = "height:0px;width:65px;border-style:none"
    '        ExcelC.pCellStyle(3) = "height:0px;width:21px;border-style:none"
    '        ExcelC.pCellStyle(4) = "height:0px;width:72px;border-style:none"
    '        ExcelC.pCellStyle(5) = "height:0px;width:23px;border-style:none"
    '        ExcelC.pCellStyle(6) = "height:0px;width:86px;border-style:none"
    '        'ExcelC.pCellStyle(7) = "height:0px;width:144px;border-style:none" '2010/03/05 T.Watabe edit
    '        ExcelC.pCellStyle(7) = "height:0px;width:204px;border-style:none"
    '        ExcelC.pCellStyle(8) = "height:0px;width:72px;border-style:none"
    '        '2006/06/14 NEC UPDATE START
    '        'ExcelC.pCellStyle(9) = "height:0px;width:175px;border-style:none"
    '        'ExcelC.pCellStyle(9) = "height:0px;width:195px;border-style:none" '2010/03/05 T.Watabe edit
    '        ExcelC.pCellStyle(9) = "height:0px;width:135px;border-style:none"
    '        ExcelC.pCellStyle(10) = "height:0px;width:5px;border-style:none"
    '        ExcelC.pCellStyle(11) = "height:0px;width:5px;border-style:none"
    '        '2006/06/14 NEC UPDATE END
    '        ExcelC.pCellVal(1) = ""
    '        ExcelC.pCellVal(2) = ""
    '        ExcelC.pCellVal(3) = ""
    '        ExcelC.pCellVal(4) = ""
    '        ExcelC.pCellVal(5) = ""
    '        ExcelC.pCellVal(6) = ""
    '        ExcelC.pCellVal(7) = ""
    '        ExcelC.pCellVal(8) = ""
    '        ExcelC.pCellVal(9) = ""
    '        ExcelC.pCellVal(10) = ""
    '        ExcelC.pCellVal(11) = ""
    '        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

    '        If True Then
    '            '���o�����i��i�j
    '            ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-bottom-style:none"
    '            ExcelC.pCellVal(1, "colspan = 9") = "���o����"
    '            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

    '            '���o�����i���i�j
    '            strHedInfo = "����:"
    '            'If pstrKuracd.Length <> 0 Then strHedInfo &= Convert.ToString(dr.Item("KENNM"))
    '            If pstrKuracd.Length <> 0 Then strHedInfo &= kenNm
    '            strHedInfo &= "�@�����Z���^�[:"
    '            If pstrKyocd.Length <> 0 Then
    '                'strHedInfo &= Convert.ToString(dr.Item("NAME"))
    '                'strTmp = pstrKyoNm.Split(Convert.ToChar(":"))
    '                'strHedInfo &= strTmp(strTmp.Length - 1)
    '                strHedInfo &= centerNm
    '            End If
    '            '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '            If pstrHanbaiCdFr.Length <> 0 Or pstrHanbaiCdTo.Length <> 0 Then '�̔����Ǝ� ����or�Е����ݒ肳��Ă���ꍇ
    '                strHedInfo &= "�@�̔����Ǝ�:"
    '                If pstrHanbaiCdFr.Length <> 0 And pstrHanbaiCdFr = pstrHanbaiCdTo Then '�̔����Ǝ� from�Ato�������ꍇ�����̂P��\��
    '                    strHedInfo &= HanNmFr
    '                Else
    '                    strHedInfo &= HanNmFr & " �` " & HanNmTo
    '                End If
    '            End If
    '            '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '            strHedInfo &= "�@�i�`:"
    '            If pstrJaCdFr.Length <> 0 And pstrJaCdFr = pstrJaCdTo Then '�i�`���� from�Ato�������ꍇ�����̂P��\��
    '                'strTmp = pstrJaNm.Split(Convert.ToChar(":"))
    '                'strHedInfo &= strTmp(strTmp.Length - 1)
    '                strHedInfo &= jaNmFr
    '            ElseIf pstrJaCdFr.Length <> 0 Or pstrJaCdTo.Length <> 0 Then '�i�`���� ����or�Е����ݒ肳��Ă���ꍇ 
    '                'strTmp = pstrJaNm.Split(Convert.ToChar(":"))
    '                'strHedInfo &= strTmp(strTmp.Length - 1)
    '                'strHedInfo &= Convert.ToString(dr.Item("JANM"))
    '                strHedInfo &= jaNmFr & " �` " & jaNmTo
    '            End If
    '            strHedInfo &= "�@�i�`�x��:"
    '            'If pstrJasCd.Length <> 0 Then
    '            '    strTmp = pstrJasNm.Split(Convert.ToChar(":"))
    '            '    strHedInfo &= strTmp(strTmp.Length - 1)
    '            '    'strHedInfo &= Convert.ToString(dr.Item("ACBNM"))
    '            'End If
    '            If pstrJasCdFr.Length <> 0 And pstrJasCdFr = pstrJasCdTo Then '�i�`���� from�Ato�������ꍇ�����̂P��\��
    '                strHedInfo &= jasNmFr
    '            ElseIf pstrJasCdFr.Length <> 0 Or pstrJasCdTo.Length <> 0 Then '�i�`���� ����or�Е����ݒ肳��Ă���ꍇ 
    '                strHedInfo &= jasNmFr & " �` " & jasNmTo
    '            End If

    '            ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '            ExcelC.pCellVal(1, "colspan = 9") = strHedInfo
    '            ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������

    '            '���o�����i���i�j
    '            '2011.11.21 MOD H.Uema *---------------* start
    '            'If pstrStkbn = "1" Then
    '            '    strHedInfo = "�����敪:�d�b"
    '            'Else
    '            '    strHedInfo = "�����敪:�x��"
    '            'End If
    '            If pstrStkbn = "1" Then
    '                strHedInfo = "�����敪:�d�b"
    '            ElseIf pstrStkbn = "2" Then
    '                strHedInfo = "�����敪:�x��"
    '            Else
    '                strHedInfo = "�����敪:�d�b�^�x��"
    '            End If
    '            '2011.11.21 MOD H.Uema *---------------* end

    '            If pstrTrgTo <> "" Then
    '                strHedInfo &= "�@�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom) & "�`" & DateFncC.mGet(pstrTrgTo)
    '            Else
    '                strHedInfo &= "�@�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom)
    '            End If
    '            ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none"
    '            ExcelC.pCellVal(1, "colspan = 9") = strHedInfo
    '            ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '        End If

    '        '���׃f�[�^�o��
    '        Dim intd As Integer = 0                   '��������
    '        Dim intRow As Integer = 0                   '��������
    '        Dim iRCnt As Integer = 0                   '��������
    '        Dim iCnt As Integer
    '        Dim strKyoCd As String = ""    '�O�񋟋��Z���^�[�R�[�h
    '        Dim strJaCd As String = ""         '�O��i�`�R�[�h
    '        Dim strAcdCd As String = ""       '�O��i�`�x���R�[�h
    '        Dim strHanjiCd As String = ""       '�O��̔����Ǝ҃R�[�h 2015/11/04 w.ganeko 2015���P�J�� ��6
    '        Dim blnFlg As Boolean = False                '����t���O

    '        '--- ��2005/05/23 ADD Falcon�� ---
    '        Dim strSTD_CD As String
    '        Dim intHedFlg As Integer = 0
    '        '--- ��2005/05/23 ADD Falcon�� ---
    '        Dim strTAIOKBN As String        '--- 2005/05/26 ADD Falcon ---

    '        '--- ��2005/07/12 ADD Falcon�� ---
    '        Dim strTFKICD As String
    '        Dim bolStdFlg As Boolean        '�o�����\���t���O(True�F�\���@False�F��\��)
    '        '--- ��2005/07/12 ADD Falcon�� ---

    '        '2006/02/01 NEC ADD START
    '        '�o�������������ǂ������ʂ��邽�߂�DataRow
    '        Dim drPageBreak As DataRow
    '        '�J�E���^
    '        Dim intCntPageBreak As Integer

    '        '2006/02/01 NEC ADD END

    '        If ds.Tables(0).Rows.Count = 0 And pstrZeroSend = "1" Then '2010/06/02 T.Watabe add
    '            '�ΏۂO���Ń[�����o�͂��聨�f�[�^�Z�b�g���X���[

    '            ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '            ExcelC.pCellStyle(1) = "height:16px;text-align:left;font-size:13px;border-style:none;"
    '            ExcelC.pCellVal(1, "colspan=7") = "���ԓ��̏��͂���܂���ł����B"
    '            ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������

    '        ElseIf ds.Tables(0).Rows.Count = 0 Then '2010/06/02 T.Watabe add
    '            '�ΏۂO�����f�[�^�Z�b�g���X���[

    '        Else

    '            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
    '            strKyoCd = Convert.ToString(ds.Tables(0).Rows(0).Item("HAISO_CD"))    '�O�񋟋��Z���^�[�R�[�h
    '            strJaCd = Convert.ToString(ds.Tables(0).Rows(0).Item("JACD"))         '�O��i�`�R�[�h
    '            strAcdCd = Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD"))       '�O��i�`�x���R�[�h
    '            strHanjiCd = Convert.ToString(ds.Tables(0).Rows(0).Item("HANJICD"))   '�O��̔����Ǝ҃R�[�h 2015/11/04 W.GANEKO 2015���P�J�� ��6

    '            'AP�T�[�o����̖߂�l�����[�v����
    '            'For Each dr In ds.Tables(0).Rows
    '            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
    '                dr = ds.Tables(0).Rows(iCnt)

    '                If pstrPgkbn = "1" Then
    '                    'JA�P��
    '                    If strJaCd <> Convert.ToString(dr.Item("JACD")) Then
    '                        '���y�[�W���s��
    '                        ExcelC.mWriteLine("", True)
    '                        strJaCd = Convert.ToString(dr.Item("JACD"))
    '                        intRow = 0
    '                    End If
    '                    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '                    'ElseIf pstrPgkbn = "2" Then
    '                    '    '�����Z���^�[�P��
    '                    '    If strKyoCd <> Convert.ToString(dr.Item("HAISO_CD")) Then
    '                    '        '���y�[�W���s��
    '                    '        ExcelC.mWriteLine("", True)
    '                    '        strKyoCd = Convert.ToString(dr.Item("HAISO_CD"))
    '                    '        intRow = 0
    '                    '    End If
    '                ElseIf pstrPgkbn = "2" Then
    '                    'JA�x���P��
    '                    If strKyoCd <> Convert.ToString(dr.Item("ACBCD")) Then
    '                        '���y�[�W���s��
    '                        ExcelC.mWriteLine("", True)
    '                        strKyoCd = Convert.ToString(dr.Item("ACBCD"))
    '                        intRow = 0
    '                    End If
    '                ElseIf pstrPgkbn = "3" Then
    '                    '�̔����ƎҒP��
    '                    If strHanjiCd <> Convert.ToString(dr.Item("HANJICD")) Then
    '                        '���y�[�W���s��
    '                        ExcelC.mWriteLine("", True)
    '                        strHanjiCd = Convert.ToString(dr.Item("HANJICD"))
    '                        intRow = 0
    '                    End If
    '                ElseIf pstrPgkbn = "4" Then
    '                    '�����Z���^�[�P��
    '                    If strKyoCd <> Convert.ToString(dr.Item("HAISO_CD")) Then
    '                        '���y�[�W���s��
    '                        ExcelC.mWriteLine("", True)
    '                        strKyoCd = Convert.ToString(dr.Item("HAISO_CD"))
    '                        intRow = 0
    '                    End If
    '                    '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '                End If

    '                '--- ��2005/05/23 MOD Falcon�� ---
    '                'If intRow = 0 Or (intRow Mod 5) = 0 Then
    '                'If intRow > 0 And (intRow Mod 5) = 0 Then
    '                '   ExcelC.mWriteLine("", True)
    '                'End If

    '                intHedFlg = 0
    '                '2006/02/01 NEC UPDATE START
    '                'strSTD_CD = Convert.ToString(dr.Item("STD_CD"))         '�o����ЃR�[�h
    '                ''--- ��2005/05/26 ADD Falcon�� ---
    '                'strTAIOKBN = Convert.ToString(dr.Item("TAIOKBN"))       '�Ή��敪�i�P�F�d�b�Ή��@�Q�F�o���w���j
    '                ''--- ��2005/05/26 ADD Falcon�� ---

    '                ''--- ��2005/07/12 ADD Falcon�� ---
    '                'strTFKICD = Convert.ToString(dr.Item("TFKICD"))         '���A�Ή���(8:�ً}�o���i�ϑ���j)
    '                'If (strSTD_CD.Length <> 0) And (strTAIOKBN = "2") And (strTFKICD = "8") Then
    '                '    bolStdFlg = True    '�o�����\��
    '                'Else
    '                '    bolStdFlg = False   '�o������\��
    '                'End If
    '                intCntPageBreak = iCnt
    '                If intRow = 0 Or (intGYOSU = 4 And (intRow Mod 4) = 0) _
    '                        Or (intGYOSU = 3 And (intRow Mod 3) = 0) Then
    '                    bolStdFlg = False   '�o������\��
    '                    '���݂̍s����S�s��܂łɏo����񂪑��݂��邩�`�F�b�N
    '                    Do Until intCntPageBreak - iCnt = 4
    '                        If intCntPageBreak <= ds.Tables(0).Rows.Count - 1 Then
    '                            drPageBreak = ds.Tables(0).Rows(intCntPageBreak)
    '                            strSTD_CD = Convert.ToString(drPageBreak.Item("STD_CD"))         '�o����ЃR�[�h
    '                            strTAIOKBN = Convert.ToString(drPageBreak.Item("TAIOKBN"))       '�Ή��敪�i�P�F�d�b�Ή��@�Q�F�o���w���j
    '                            strTFKICD = Convert.ToString(drPageBreak.Item("TFKICD"))         '���A�Ή���(8:�ً}�o���i�ϑ���j)
    '                            If (strSTD_CD.Length <> 0) And (strTAIOKBN = "2") And (strTFKICD = "8") Then
    '                                bolStdFlg = True    '�o�����\��
    '                            End If
    '                        End If
    '                        '�J�E���g�A�b�v
    '                        intCntPageBreak += 1
    '                    Loop
    '                End If
    '                '2006/02/01 NEC UPDATE END

    '                '--- ��2005/07/12 ADD Falcon�� ---

    '                If intRow = 0 Then
    '                    intHedFlg = 1       '�P�ԍŏ��͕K���w�b�_���w�b�_����������
    '                    '//�o�͍s���̐ݒ�---------------
    '                    '--- ��2005/07/12 MOD Falcon�� ---
    '                    ''�o����ЃR�[�h�����݂��Ȃ��ꍇ�S�s�o�́A���݂���ꍇ�͂R�s�o��
    '                    'If strSTD_CD.Length = 0 Then
    '                    '�P�y�[�W�̍s���͏o������\���̏ꍇ�͂S�s�A�\���̏ꍇ�͂R�s��ݒ�
    '                    If bolStdFlg = True Then
    '                        intGYOSU = 3
    '                    Else
    '                        intGYOSU = 4
    '                    End If
    '                    '--- ��2005/07/12 MOD Falcon�� ---
    '                    '//-----------------------------
    '                Else
    '                    If (intGYOSU = 4 And (intRow Mod 4) = 0) _
    '                        Or (intGYOSU = 3 And (intRow Mod 3) = 0) Then
    '                        intHedFlg = 1   '�w�b�_�������݁F�L
    '                        intRow = 0      '�s���J�E���g�F0
    '                        intGYOSU = 0    '�P�y�[�W�o�͐��F0
    '                        '//�o�͍s���̐ݒ�---------------
    '                        '--- ��2005/07/12 MOD Falcon�� ---
    '                        '�o����ЃR�[�h�����݂��Ȃ��ꍇ�S�s�o�́A���݂���ꍇ�͂R�s�o��
    '                        'If strSTD_CD.Length = 0 Then
    '                        '�P�y�[�W�̍s���͏o������\���̏ꍇ�͂S�s�A�\���̏ꍇ�͂R�s��ݒ�
    '                        If bolStdFlg = True Then
    '                            intGYOSU = 3
    '                        Else
    '                            intGYOSU = 4
    '                        End If
    '                        '--- ��2005/07/12 MOD Falcon�� ---
    '                        '//-----------------------------
    '                        ExcelC.mWriteLine("", True)
    '                    Else
    '                        '//�o�͍s���̐ݒ�---------------
    '                        If intGYOSU = 4 Then
    '                            '--- ��2005/07/12 MOD Falcon�� ---
    '                            '�o����ЃR�[�h�����݂���ꍇ�͂R�s�o��
    '                            'If strSTD_CD.Length <> 0 Then
    '                            If bolStdFlg = True Then
    '                                intGYOSU = 3
    '                            Else
    '                                intGYOSU = intGYOSU
    '                            End If
    '                            '--- ��2005/07/12 MOD Falcon�� ---
    '                        Else
    '                            intGYOSU = intGYOSU
    '                        End If
    '                        '//-----------------------------
    '                    End If
    '                End If

    '                If intHedFlg = 1 Then
    '                    ExcelC.mWriteLine("")
    '                    ExcelC.pCellStyle(1) = "height:16px;text-align:left;font-size:13px;border:none"
    '                    ExcelC.pCellStyle(2) = "height:16px;text-align:left;font-size:13px;border:none"     '<-- 2005/05/21 ADD
    '                    'ExcelC.pCellVal(1, "colspan=2") = "�����F" & Convert.ToString(dr.Item("KENNM"))
    '                    ExcelC.pCellVal(1, "colspan=2") = "�����F" & kenNm
    '                    If pstrPgkbn = "1" Then
    '                        ExcelC.pCellVal(2, "colspan=7") = "�i�`���F" & Convert.ToString(dr.Item("JANM"))
    '                        'ExcelC.pCellVal(1, "colspan=9") = "�i�`���F" & Convert.ToString(dr.Item("JANM"))
    '                        ''& "�@" & "�i�`�x�����F" & Convert.ToString(dr.Item("ACBNM"))
    '                        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '                        'ElseIf pstrPgkbn = "2" Then
    '                        '    ExcelC.pCellVal(2, "colspan=7") = "�����Z���^�[���F" & Convert.ToString(dr.Item("NAME"))
    '                        '    'ExcelC.pCellVal(1, "colspan=9") = "�����Z���^�[���F" & Convert.ToString(dr.Item("NAME"))
    '                        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '                    ElseIf pstrPgkbn = "2" Then
    '                        ExcelC.pCellVal(2, "colspan=7") = "JA�x�����F" & Convert.ToString(dr.Item("ACBNM"))
    '                    ElseIf pstrPgkbn = "3" Then
    '                        ExcelC.pCellVal(2, "colspan=7") = "�̔����ƎҖ��F" & Convert.ToString(dr.Item("HANJINM"))
    '                    ElseIf pstrPgkbn = "4" Then
    '                        ExcelC.pCellVal(2, "colspan=7") = "�����Z���^�[���F" & Convert.ToString(dr.Item("NAME"))
    '                        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    '                    End If
    '                    ExcelC.mWriteLine("")


    '                    iRCnt = iRCnt + 1
    '                End If

    '                '--- ��2005/05/23 MOD Falcon�� ---

    '                '���׍���
    '                '--- ��2005/05/21 MOD Falcon�� ---  '�ړ�
    '                '1�i��----------------------------------------------------------------
    '                '2006/06/13 NEC UPDATE START
    '                'ExcelC.pCellStyle(1) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
    '                'ExcelC.pCellVal(1) = "�i�`��:"
    '                'ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                'ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JACD")) & "�@" & Convert.ToString(dr.Item("JANM"))
    '                ''JA/JA�x��
    '                'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                'ExcelC.pCellVal(3) = "�i�`�x����:"
    '                'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
    '                'ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("ACBCD")) & "�@" & Convert.ToString(dr.Item("ACBNM"))
    '                'ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                'JA�x��
    '                ExcelC.pCellStyle(1) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
    '                ExcelC.pCellVal(1, "colspan = 2") = "�i�`�x����:"
    '                ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
    '                ExcelC.pCellVal(2, "colspan = 7") = Convert.ToString(dr.Item("ACBCD")) & "�@" & Convert.ToString(dr.Item("ACBNM"))
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '2006/06/13 NEC UPDATE END

    '                '----------------------------------------------------------------------
    '                '--- ��2005/05/21 MOD Falcon�� ---
    '                '2�i��-----------------------------------------------------------------
    '                '���q�l��
    '                ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(1) = "����:"
    '                ExcelC.pCellVal(1) = "���q�l��:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.pCellStyle(2) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUSYONM"))
    '                '���q�l�R�[�h
    '                ExcelC.pCellStyle(3) = "text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(3) = "���v�ƃR�[�h:"
    '                ExcelC.pCellVal(3) = "���q�l�R�[�h:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.pCellStyle(4) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("JUYOKA"))
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '3�i��-----------------------------------------------------------------
    '                '�����ԍ�
    '                ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(1) = "TEL:"
    '                ExcelC.pCellVal(1) = "�����ԍ�:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.pCellStyle(2) = "font-size:13px;border-style:none"
    '                '2006/06/14 NEC UPDATE START
    '                'ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL"))
    '                If Convert.ToString(dr.Item("JUTEL1")) = "" Then
    '                    ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL2"))
    '                Else
    '                    ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL1")) & "-" & Convert.ToString(dr.Item("JUTEL2"))
    '                End If
    '                '2006/06/14 NEC UPDATE END
    '                '�A����
    '                ExcelC.pCellStyle(3) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(3) = "�A����:"
    '                ExcelC.pCellStyle(4) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("RENTEL"))
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '4�i��-----------------------------------------------------------------
    '                '�Z��
    '                ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1) = "�Z��:"
    '                ExcelC.pCellStyle(2) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:dashed"
    '                ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("ADDR"))
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                ''5�i��-----------------------------------------------------------------
    '                ''��t����
    '                'ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:dashed;border-bottom-style:none"
    '                'ExcelC.pCellVal(1, "colspan = 9") = "��t����:" & _
    '                '                                    DateFncC.mGet(Convert.ToString(dr.Item("HATYMD"))) & _
    '                '                                    " " & CTimeFncC.mGet(Convert.ToString(dr.Item("HATTIME")), 0)
    '                'ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '5�i��-----------------------------------------------------------------
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1) = "<�ً}>"
    '                '���ې�
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(2) = "���ې�:"
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KEIHOSU"))
    '                '���ʋ敪
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(4) = "���ʋ敪:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = Convert.ToString(dr.Item("RYURYO"))
    '                '�����敪
    '                ExcelC.pCellStyle(6) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ' 2015/02/17 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(6) = "�������:"
    '                ExcelC.pCellVal(6) = "�����敪:"
    '                ' 2015/02/17 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.pCellStyle(7) = "font-size:13px;border-style:none"
    '                ExcelC.pCellVal(7) = Convert.ToString(dr.Item("TMSKB_NAI"))
    '                '2006/06/13 NEC UPDATE START
    '                ''��������
    '                'ExcelC.pCellStyle(8) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(8) = "��������:"
    '                'ExcelC.pCellStyle(9) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(9) = DateFncC.mGet(Convert.ToString(dr.Item("SYOYMD"))) & _
    '                '                     " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOTIME")), 0)
    '                '��M����
    '                ExcelC.pCellStyle(8) = "text-align:right;font-size:13px;border-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(8) = "��t����:"
    '                ExcelC.pCellVal(8) = "��M����:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.pCellStyle(9) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(9) = DateFncC.mGet(Convert.ToString(dr.Item("HATYMD"))) & _
    '                                                    " " & CTimeFncC.mGet(Convert.ToString(dr.Item("HATTIME")), 0)
    '                '2006/06/13 NEC UPDATE END
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '6�i��-----------------------------------------------------------------
    '                '�x��P���b�Z�[�W
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM1"))
    '                '�A������
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(2) = "�A�������:"
    '                ExcelC.pCellVal(2) = "�A������:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TAITNM"))
    '                '2006/06/13 NEC UPDATE START
    '                ''�Ή��敪
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "�Ή��敪:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
    '                '��������
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(4) = "��������:"
    '                ExcelC.pCellVal(4) = "��������:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SYOYMD"))) & _
    '                                     " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOTIME")), 0)
    '                '2006/06/13 NEC UPDATE END
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '7�i��-----------------------------------------------------------------
    '                '�x��Q���b�Z�[�W
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM2"))
    '                '�S���Җ�
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(2) = "�S���Җ�:"
    '                '2006/06/13 NEC UPDATE START
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TKTANCD_NM"))
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TKTANCD_NM"))
    '                '2011.11.21 MOD H.Uema *-------------------* start
    '                ''�Ή��敪
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "�Ή��敪:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                ''�����敪
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "�����敪:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("HATKBN_NAI"))
    '                '2011.11.21 MOD H.Uema *-------------------* end
    '                '�˗�����
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(4) = "�˗�����:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SIJIYMD"))) & _
    '                                     " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SIJITIME")), 0)
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                '2006/06/13 NEC UPDATE END
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '8�i��-----------------------------------------------------------------
    '                '�x��R���b�Z�[�W
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM3"))
    '                '���A���
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(2) = "���A����:"
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TFKINM")) '2010/03/05 T.Watabe edit
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TFKINM"))
    '                '2011.11.21 MOD H.Uema *-------------------* start
    '                ''���[�^�w�j�l '2010/03/05 T.Watabe add
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "���[�^�l:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                ''�Ή��敪
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "�Ή��敪:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
    '                '2011.11.21 MOD H.Uema *-------------------* end
    '                '�����敪
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(4) = "�����敪:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = Convert.ToString(dr.Item("HATKBN_NAI"))
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '9�i��-----------------------------------------------------------------
    '                '�x��S���b�Z�[�W
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM4"))
    '                '�������
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(2) = "����:"
    '                ExcelC.pCellVal(2) = "�������:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                '2011.11.21 MOD H.Uema *-------------------* start
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TKIGNM"))
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TKIGNM"))
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                ''���[�^�w�j�l
    '                'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                'ExcelC.pCellVal(4) = "���[�^�l:"
    '                'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
    '                '�Ή��敪
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(4) = "�Ή��敪:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
    '                '2011.11.21 MOD H.Uema *-------------------* end
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '10�i��----------------------------------------------------------------
    '                '�x��T���b�Z�[�W
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM5"))
    '                '�쓮����
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(2) = "�쓮����:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TSADNM"))
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TSADNM"))
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ' 2015/02/12 H.Hosoda add 2014���P�J�� No9 START
    '                '���[�^�w�j�l
    '                ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                ExcelC.pCellVal(4) = "���[�^�l:"
    '                ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
    '                ' 2015/02/12 H.Hosoda add 2014���P�J�� No9 END
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '11�i��----------------------------------------------------------------
    '                '�x��U���b�Z�[�W
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none"
    '                ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM6"))
    '                '--- ��2005/05/21 MOD Falcon�� ---
    '                '--- �o�����̏o�͒ǉ� ----------
    '                ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                '2006/06/14 NEC UPDATE START
    '                'ExcelC.pCellVal(2) = ""
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = ""
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                'ExcelC.pCellVal(2) = "�o���w��:"
    '                ExcelC.pCellVal(2) = "�o���˗�:"
    '                ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("SDNM"))
    '                '2006/06/14 NEC UPDATE END
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '12�i��----------------------------------------------------------------
    '                '�d�b�����P
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO1"))
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '13�i��----------------------------------------------------------------
    '                '�d�b�����P
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
    '                ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO2"))
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                '14�i��----------------------------------------------------------------
    '                '���A���상��
    '                ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none"
    '                ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("FUK_MEMO"))
    '                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������

    '                '2006/2/1 NEC UPDATE START
    '                ''If intGYOSU = 3 And strSTD_CD.Length <> 0 Then                     '--- 2005/05/26 DEL Falcon ---
    '                'If intGYOSU = 3 Then
    '                '    '--- ��2005/07/12 MOD Falcon�� ---
    '                '    'If strSTD_CD.Length <> 0 And strTAIOKBN = "2" Then  '--- 2005/05/26 MOD Falcon ---
    '                '    If bolStdFlg = True Then
    '                '        '--- ��2005/07/12 MOD Falcon�� ---
    '                '�o�����ł���΁A�o�����e��\��
    '                If Convert.ToString(dr.Item("STD_CD")).Length <> 0 And _
    '                Convert.ToString(dr.Item("TAIOKBN")) = "2" And _
    '                Convert.ToString(dr.Item("TFKICD")) = "8" Then
    '                    '2006/2/1 NEC UPDATE END
    '                    '15�i��-----------------------------------------------------------------
    '                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "colspan = 5") = "���o�����"
    '                    '�Ή�����
    '                    ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                    'ExcelC.pCellVal(2) = "�A�������:"
    '                    'ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("AITNM"))
    '                    ExcelC.pCellVal(2) = "�Ή�����:"
    '                    ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("AITNM"))
    '                    '��M����
    '                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                    ExcelC.pCellVal(4) = "��M����:"
    '                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SIJIYMD"))) & _
    '                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SIJITIME")), 0)
    '                    ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    '16�i��-----------------------------------------------------------------
    '                    '�o���Ή���
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
    '                    'ExcelC.pCellVal(1, "colspan = 5") = "��M�Ҏ���:" & Convert.ToString(dr.Item("TSTANNM"))
    '                    ExcelC.pCellVal(1, "colspan = 5") = "�o���Ή���:" & Convert.ToString(dr.Item("SYUTDTNM"))
    '                    '�������
    '                    ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(2) = "�������:"
    '                    ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KIGNM"))
    '                    '�o������
    '                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                    ExcelC.pCellVal(4) = "�o������:"
    '                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SDYMD"))) & _
    '                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SDTIME")), 0)
    '                    ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
    '                    ' 2015/02/12 H.Hosoda del 2014���P�J�� No9 START
    '                    ''�쓮����
    '                    'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(3) = "�쓮����:"
    '                    'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("SADNM"))
    '                    ' 2015/02/12 H.Hosoda del 2014���P�J�� No9 END
    '                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    '17�i��-----------------------------------------------------------------
    '                    '���A����
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "colspan = 5") = "���A����:" & Convert.ToString(dr.Item("FKINM"))
    '                    ' 2015/02/12 H.Hosoda add 2014���P�J�� No9 START
    '                    '�쓮����
    '                    ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(2) = "�쓮����:"
    '                    ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("SADNM"))
    '                    '��������
    '                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
    '                    ExcelC.pCellVal(4) = "��������:"
    '                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("TYAKYMD"))) & _
    '                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("TYAKTIME")), 0)
    '                    ' 2015/02/12 H.Hosoda add 2014���P�J�� No9 END
    '                    ' 2015/02/12 H.Hosoda del 2014���P�J�� No9 START
    '                    ''�Z���T����
    '                    'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(3) = "�Z���T����:"
    '                    'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("ASENM"))
    '                    ' 2015/02/12 H.Hosoda del 2014���P�J�� No9 END
    '                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    '18�i��-----------------------------------------------------------------
    '                    ' 2015/02/12 H.Hosoda del 2014���P�J�� No9 START
    '                    ''����
    '                    'ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(1, "colspan = 5") = "����:" & Convert.ToString(dr.Item("KIGNM"))
    '                    ''���̑�����
    '                    'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
    '                    ''--- ��2005/05/31 MOD Falcon�� ---
    '                    ''ExcelC.pCellVal(3) = "���̑�����:"
    '                    'ExcelC.pCellVal(3) = "�������:"
    '                    ''--- ��2005/05/31 MOD Falcon�� ---
    '                    'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("STANM"))
    '                    ' 2015/02/12 H.Hosoda del 2014���P�J�� No9 END
    '                    ' 2015/02/12 H.Hosoda add 2014���P�J�� No9 START
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "colspan = 7") = ""
    '                    '��������
    '                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-style:none"
    '                    ExcelC.pCellVal(2) = "��������:"
    '                    ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                    ExcelC.pCellVal(3) = DateFncC.mGet(Convert.ToString(dr.Item("SYOKANYMD"))) & _
    '                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOKANTIME")), 0)
    '                    ' 2015/02/12 H.Hosoda add 2014���P�J�� No9 END
    '                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    '19�i��-----------------------------------------------------------------
    '                    '2006/06/14 NEC UPDATE START
    '                    '�o�����l
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "nowrap") = "�o�����l:"
    '                    ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SIJI_BIKO1"))
    '                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    ''20�i��-----------------------------------------------------------------
    '                    ''���l�P
    '                    'ExcelC.pCellStyle(1) = "text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(1) = "���l�P:"
    '                    'ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK1"))
    '                    'ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    ''21�i��-----------------------------------------------------------------
    '                    ''���l�Q
    '                    'ExcelC.pCellStyle(1) = "text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    'ExcelC.pCellVal(1) = "���l�Q:"
    '                    'ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK2"))
    '                    'ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    ''22�i��-----------------------------------------------------------------
    '                    ''���̑����L
    '                    'ExcelC.pCellStyle(1) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none"
    '                    ''--- ��2005/05/31 MOD Falcon�� ---
    '                    ''ExcelC.pCellVal(1) = "���̑����L:"
    '                    'ExcelC.pCellVal(1) = "������L:"
    '                    ''--- ��2005/05/31 MOD Falcon�� ---
    '                    'ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-left-style:none"
    '                    'ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SNTTOKKI"))
    '                    'ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    '20�i��-----------------------------------------------------------------
    '                    '�o������(1)
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1, "nowrap") = "�o������:"
    '                    ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK2"))
    '                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    '21�i��-----------------------------------------------------------------
    '                    '�o������(2)
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1) = ""
    '                    ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none;border-left-style:none"
    '                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SNTTOKKI"))
    '                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    '22�i��-----------------------------------------------------------------
    '                    '�o������(3)
    '                    ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-right-style:none"
    '                    ExcelC.pCellVal(1) = ""
    '                    ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-left-style:none"
    '                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK3"))
    '                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                    '2006/06/14 NEC UPDATE END
    '                End If
    '                '2006/2/1 NEC UPDATE START
    '                'End If
    '                '2006/2/1 NEC UPDATE END

    '                '--- ��2005/05/21 MOD Falcon�� ---

    '                '--- ��2005/05/21 DEL Falcon�� ---
    '                ''�A�����e�P0
    '                'ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(2) = "�A�����e:"
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TEL_MEMO1"))
    '                'ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                ''12�i��----------------------------------------------------------------
    '                'ExcelC.pCellStyle(1) = "height:16px;font-size:13px;none;border-right-style:none;border-bottom-style:dashed"
    '                'ExcelC.pCellVal(1, "colspan = 5") = ""
    '                ''�A�����e�Q
    '                'ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-left-style:none;border-right-style:none"
    '                'ExcelC.pCellVal(2) = ""
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none"
    '                'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TEL_MEMO2"))
    '                'ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                ''13�i��----------------------------------------------------------------
    '                'ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-right-style:none;"
    '                'ExcelC.pCellVal(1, "colspan = 5") = "JA���F" & Convert.ToString(dr.Item("JACD")) & "�@" & _
    '                '                                               Convert.ToString(dr.Item("JANM"))
    '                ''JA/JA�x��
    '                'ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-left-style:none;border-right-style:none;"
    '                'ExcelC.pCellVal(2) = ""
    '                'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;"
    '                'ExcelC.pCellVal(3, "colspan = 3") = "JA�x�����F" & Convert.ToString(dr.Item("ACBCD")) & "�@" & _
    '                '                                               Convert.ToString(dr.Item("ACBNM"))
    '                'ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
    '                ''----------------------------------------------------------------------
    '                '--- ��2005/05/21 DEL Falcon�� ---
    '                '�s���̃J�E���g
    '                intRow = intRow + 1
    '                '2004/11/24 NEC ADD START
    '                If (intRow Mod intGYOSU) = 0 Then
    '                    'ExcelC.pCellStyle(1) = "height:6px;border:none"
    '                    'ExcelC.pCellVal(1, "colspan = 9") = ""
    '                    'ExcelC.mWriteLine("", True)
    '                Else
    '                    ExcelC.pCellStyle(1) = "height:6px;border:none"
    '                    ExcelC.pCellVal(1, "colspan = 9") = ""
    '                    ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
    '                End If

    '                '--- ��2005/05/23 ADD Falcon�� ---
    '                'iRCnt = iRCnt + 13
    '                If intGYOSU = 4 Then
    '                    iRCnt = iRCnt + 15
    '                Else
    '                    iRCnt = iRCnt + 22
    '                End If
    '                '--- ��2005/05/23 ADD Falcon�� ---
    '            Next
    '        End If

    '        ExcelC.mWriteLine("")                           '�s���t�@�C���ɏ�������
    '        ExcelC.mClose()                                 '�t�@�C���N���[�Y

    '        ' 2011/02/10 T.Watabe edit ���̕����֖߂�
    '        If True Then

    '            Dim strXlsSubName As String ' 2011/06/02 T.Watabe add
    '            If jaNmFr.Length > 0 Then
    '                strXlsSubName = jaNmFr
    '            ElseIf centerNm.Length > 0 Then
    '                strXlsSubName = centerNm
    '            ElseIf kenNm.Length > 0 Then
    '                strXlsSubName = kenNm
    '            End If

    '            '�t�@�C���f�[�^���G���R�[�h���ČĂяo�����֖߂�����
    '            '���k��t�@�C���̂���t�H���_
    '            compressC.p_Dir = ExcelC.pDirName
    '            '���{��t�@�C�����̎w��
    '            'compressC.p_NihongoFileName = pstrSessionID & "�ݐϏ��ꗗ�\.xls" ' 2011/06/02 T.Watabe edit
    '            compressC.p_NihongoFileName = "�ݐϏ��_" & strXlsSubName & "_" & pstrSessionID & ".xls"
    '            '���k���t�@�C����
    '            compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
    '            '���k��t�@�C����
    '            compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
    '            compressC.p_Exec = pbolLzhAutoExec '�𓀎��̎������s����H�^�Ȃ��H
    '            '���k���s
    '            compressC.mCompress()
    '            mlog("@1_" & compressC.p_madeFilename)
    '            '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
    '            Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
    '        Else
    '            ' 2011/02/01 T.Watabe edit
    '            '�t�@�C���p�X��߂������i�����j
    '            Dim sCopyFrom As String = ExcelC.pDirName & ExcelC.pFileName & ".xls"
    '            'Dim sCopyTo As String = ExcelC.pDirName & pstrSessionID & "�ݐϏ��ꗗ�\.xls"
    '            'Microsoft.VisualBasic.FileSystem.Rename(sCopyFrom, sCopyTo)
    '            'Return FileToStrC.mFileToStr(sCopyTo)
    '            'Return FileToStrC.mFileToStr(sCopyFrom)
    '            mlog("@2_" & sCopyFrom)
    '            Return sCopyFrom
    '        End If

    '    Catch ex As Exception
    '        '�G���[�̓��e�Ƃr�p�k����Ԃ�
    '        Return "ERROR:" & ex.ToString

    '    Finally
    '        cdb.mClose()        '�ڑ��N���[�Y
    '    End Try

    'End Function
    '2015/11/04 w.ganeko 2015���P�J�� ��6 end

    '******************************************************************************
    '*�@�T�@�v:�Ď��Z���^�[���j���[�u�ݐϏ��ꗗ�v�p�@���[��DL�`����ύXexe��xls
    '*�@���@�l:mExcel2���R�s�[���č쐬 2014/01/06 T.Ono add �Ď����P2013
    '*        :2016/12/05 T.Ono mod 2016���P�J�� ��12 [pstrfaxNo()][pstrmailADD()] �ǉ�
    '*        :2020/11/01 T.Ono mod 2020�Ď����P pstrSdPrt�@�ǉ�
    '******************************************************************************
    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    '<WebMethod()> Public Function mExcel3( _
    '                                ByVal pstrSessionID As String, _
    '                                ByVal pstrKuracd As String, _
    '                                ByVal pstrKyocd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrStkbn As String, _
    '                                ByVal pstrPgkbn As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrKuraNm As String, _
    '                                ByVal pstrKyoNm As String, _
    '                                ByVal pstrJaNm As String, _
    '                                ByVal pstrJasNm As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrCentcd As String, _
    '                                ByVal pstrZeroSend As String, _
    '                                ByVal pbolLzhAutoExec As Boolean _
    '                                ) As String
    '<WebMethod()> Public Function mExcel3( _
    '                                ByVal pstrSessionID As String, _
    '                                ByVal pstrKuracd As String, _
    '                                ByVal pstrKyocd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrStkbn As String, _
    '                                ByVal pstrPgkbn As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrKuraNm As String, _
    '                                ByVal pstrKyoNm As String, _
    '                                ByVal pstrJaNmFr As String, _
    '                                ByVal pstrJaNmTo As String, _
    '                                ByVal pstrJasNmFr As String, _
    '                                ByVal pstrJasNmTo As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrCentcd As String, _
    '                                ByVal pstrZeroSend As String, _
    '                                ByVal pbolLzhAutoExec As Boolean, _
    '                                ByVal pstrHanbaiCdFr As String, _
    '                                ByVal pstrHanbaiCdTo As String, _
    '                                ByVal pstrTaikbn As String, _
    '                                ByVal pstrHkkbn As String, _
    '                                ByVal pstrHanbaiNmFr As String, _
    '                                ByVal pstrHanbaiNmTo As String, _
    '                                ByVal pstrZipFlg As String, _
    '                                ByVal pstrfaxNo() As String, _
    '                                ByVal pstrmailADD() As String _
    '                                ) As String
    '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    <WebMethod()> Public Function mExcel3(
                                    ByVal pstrSessionID As String,
                                    ByVal pstrKuracd As String,
                                    ByVal pstrKyocd As String,
                                    ByVal pstrJaCdFr As String,
                                    ByVal pstrJaCdTo As String,
                                    ByVal pstrJasCdFr As String,
                                    ByVal pstrJasCdTo As String,
                                    ByVal pstrStkbn As String,
                                    ByVal pstrPgkbn As String,
                                    ByVal pstrTrgFrom As String,
                                    ByVal pstrTrgTo As String,
                                    ByVal pstrKuraNm As String,
                                    ByVal pstrKyoNm As String,
                                    ByVal pstrJaNmFr As String,
                                    ByVal pstrJaNmTo As String,
                                    ByVal pstrJasNmFr As String,
                                    ByVal pstrJasNmTo As String,
                                    ByVal pdecPageMax As Decimal,
                                    ByVal pstrCentcd As String,
                                    ByVal pstrZeroSend As String,
                                    ByVal pstrSdPrt As String,
                                    ByVal pbolLzhAutoExec As Boolean,
                                    ByVal pstrHanbaiCdFr As String,
                                    ByVal pstrHanbaiCdTo As String,
                                    ByVal pstrTaikbn As String,
                                    ByVal pstrHkkbn As String,
                                    ByVal pstrHanbaiNmFr As String,
                                    ByVal pstrHanbaiNmTo As String,
                                    ByVal pstrZipFlg As String,
                                    ByVal pstrfaxNo() As String,
                                    ByVal pstrmailADD() As String,
                                    ByVal pstrKikankbn As String,
                                    ByVal pstrTrgTimeFrom As String,
                                    ByVal pstrTrgTimeTo As String
                                    ) As String
        '2017/02/15 H.Mori mod ���P2016 No9-1 END

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim intGYOSU As Integer = 5                     '���s������s��
        Dim intGyoMax As Integer = CInt(pdecPageMax)    '�ő�s��
        'Dim intGyoMax As Integer = 4500 '�ő�s��
        Dim ExcelC As New CExcel                        'Excel�N���X
        Dim compressC As New CCompress                  '���k�N���X
        Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
        Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
        Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim strHedInfo As String                        '�w�b�_�[���i���o�����j
        Dim intPrntRow As Integer = 72

        Dim strTmp() As String
        Dim strTmpTo() As String

        '2016/11/30 T.Ono add 2016���P�J�� ��12 --------------------Start
        '���O�o�͂Ɏg�p
        Dim strEXEC_YMD As String
        Dim strEXEC_TIME As String
        Dim strGUID As String
        Dim intSEQNO As Integer
        Dim wkstrTAIOU_SYONO As String = ""
        Dim wkstrTAIOU_KANSCD As String = ""
        Dim wkstrTAIOU_KURACD As String = ""
        Dim wkstrTAIOU_JACD As String = ""
        Dim wkstrTAIOU_ACBCD As String = ""
        Dim wkstrTAIOU_USER_CD As String = ""
        Dim wkstrAUTO_ZERO_FLG As String = "" ' �y�[�������M�t���O�z 0:�f�[�^����/1:�[�����I(�f�[�^�Ȃ�)�@


        strEXEC_YMD = Format(DateTime.Now, "yyyyMMdd")
        strEXEC_TIME = Format(DateTime.Now, "HHmmss")
        strGUID = pstrSessionID
        intSEQNO = 0
        '2016/11/30 T.Ono add 2016���P�J�� ��12 --------------------End


        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        ' ---------------------------------
        ' �i�`���A�����A�N���C�A���g���A�������������擾
        ' ---------------------------------
        Dim jaNmFr As String = ""
        Dim jaNmTo As String = ""
        Dim jasNmFr As String = ""
        Dim jasNmTo As String = ""
        Dim kenNm As String = ""
        Dim HanNmFr As String = ""
        Dim HanNmTo As String = ""
        'Dim clientNm As String = ""
        Dim centerNm As String = ""
        Try
            '2015/01/23 T.Ono add JA��JA�x�������\������Ă������ߏC�� START
            'jaNmFr = getDB2JasNm(cdb, pstrKuracd, pstrJaCdFr)
            'jaNmFr = jaNmFr.Trim
            'If pstrJaCdFr.Length <> 0 And pstrJaCdFr = pstrJaCdTo Then
            '    jaNmTo = jaNmFr
            'Else
            '    jaNmTo = getDB2JasNm(cdb, pstrKuracd, pstrJaCdTo)
            'End If
            '2015/11/04 w.ganeko 2015���P�J�� ��6
            'strTmp = pstrJaNm.Split(Convert.ToChar(":"))
            strTmp = pstrJaNmFr.Split(Convert.ToChar(":"))
            jaNmFr = strTmp(strTmp.Length - 1).Trim
            strTmp = pstrHanbaiNmFr.Split(Convert.ToChar(":"))
            HanNmFr = strTmp(strTmp.Length - 1).Trim
            If pstrHanbaiCdFr.Length <> 0 And pstrHanbaiCdFr = pstrHanbaiCdTo Then
                HanNmTo = HanNmFr
            ElseIf pstrHanbaiCdTo.Length <> 0 Then
                strTmp = pstrHanbaiNmTo.Split(Convert.ToChar(":"))
                HanNmTo = strTmp(strTmp.Length - 1).Trim
            End If
            '2015/11/04 w.ganeko 2015���P�J�� ��6
            'jaNmTo = jaNmFr 'JA�R�[�h��From��To�͓������̂�n���Ă���̂�IF���ɂ���K�v�Ȃ�
            strTmpTo = pstrJaNmTo.Split(Convert.ToChar(":"))
            jaNmTo = strTmpTo(strTmpTo.Length - 1).Trim
            '2015/01/23 T.Ono add JA��JA�x�������\������Ă������ߏC�� END
            jasNmFr = getDB2JasNm(cdb, pstrKuracd, pstrJasCdFr)
            If pstrJasCdFr.Length <> 0 And pstrJasCdFr = pstrJasCdTo Then
                jasNmTo = jasNmFr
            Else
                jasNmTo = getDB2JasNm(cdb, pstrKuracd, pstrJasCdTo)
            End If
            kenNm = getDB2KenNm(cdb, pstrKuracd)

            '2011.11.22 MOD H.Uema �N���C�A���g���w��̏ꍇ�A������̂ŏC��
            'centerNm = getDB2CenterNm(cdb, pstrKuracd.Substring(1, 2), pstrKyocd)
            If (pstrKuracd.Length > 2) Then
                centerNm = getDB2CenterNm(cdb, pstrKuracd.Substring(1, 2), pstrKyocd)
            End If

        Catch ex As Exception
            '2011.11.22 MOD H.Uema *----------* start
            'Return ex.ToString
            cdb.mClose()        '�ڑ��N���[�Y
            Return "ERROR:" & ex.ToString
            '2011.11.22 MOD H.Uema *----------* end
        Finally
        End Try

        '���[�o�͍��ڂ̎擾�pSQL���Z�b�g-------------------
        Try
            '2015/11/04 w.ganeko 2015���P�J�� ��6 start
            'strSQL.Append(fncMakeSelect(2, _
            '                        pstrKuracd, _
            '                        pstrKyocd, _
            '                        pstrJaCdFr, _
            '                        pstrJaCdTo, _
            '                        pstrJasCdFr, _
            '                        pstrJasCdTo, _
            '                        pstrTrgFrom, _
            '                        pstrTrgTo, _
            '                        pstrPgkbn, _
            '                        pdecPageMax, _
            '                        pstrStkbn))
            '2017/02/15 H.Mori mod ���P2016 No9-1 START
            'strSQL.Append(fncMakeSelect(2, _
            '                        pstrKuracd, _
            '                        pstrKyocd, _
            '                        pstrJaCdFr, _
            '                        pstrJaCdTo, _
            '                        pstrJasCdFr, _
            '                        pstrJasCdTo, _
            '                        pstrTrgFrom, _
            '                        pstrTrgTo, _
            '                        pstrPgkbn, _
            '                        pdecPageMax, _
            '                        pstrStkbn, _
            '                        pstrHanbaiCdFr, _
            '                        pstrHanbaiCdTo, _
            '                        pstrTaikbn, _
            '                        pstrHkkbn
            '                       ))
            '2015/11/04 w.ganeko 2015���P�J�� ��6 end
            strSQL.Append(fncMakeSelect(2,
                                    pstrKuracd,
                                    pstrKyocd,
                                    pstrJaCdFr,
                                    pstrJaCdTo,
                                    pstrJasCdFr,
                                    pstrJasCdTo,
                                    pstrTrgFrom,
                                    pstrTrgTo,
                                    pstrPgkbn,
                                    pdecPageMax,
                                    pstrStkbn,
                                    pstrHanbaiCdFr,
                                    pstrHanbaiCdTo,
                                    pstrTaikbn,
                                    pstrHkkbn,
                                    pstrKikankbn,
                                    pstrTrgTimeFrom,
                                    pstrTrgTimeTo
                                   ))
            '2017/02/15 H.Mori mod ���P2016 No9-1 END
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�Z�b�g
            If pstrKuracd.Length <> 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKuracd
            End If
            If pstrKyocd.Length > 0 Then cdb.pSQLParamStr("KYOCD") = pstrKyocd
            '2015/11/04 w.ganeko 2015���P�J�� ��6 start
            If pstrHanbaiCdFr.Length > 0 Then cdb.pSQLParamStr("GROUPCDFR") = pstrHanbaiCdFr
            If pstrHanbaiCdTo.Length > 0 Then cdb.pSQLParamStr("GROUPCDTO") = pstrHanbaiCdTo
            '2015/11/04 w.ganeko 2015���P�J�� ��6 end
            If pstrJaCdFr.Length > 0 Then cdb.pSQLParamStr("JACDFR") = pstrJaCdFr
            If pstrJaCdTo.Length > 0 Then cdb.pSQLParamStr("JACDTO") = pstrJaCdTo
            If pstrJasCdFr.Length > 0 Then cdb.pSQLParamStr("JASCDFR") = pstrJasCdFr
            If pstrJasCdTo.Length > 0 Then cdb.pSQLParamStr("JASCDTO") = pstrJasCdTo
            cdb.pSQLParamStr("HATKBN") = pstrStkbn '�����敪
            If pstrTrgFrom.Length > 0 Then cdb.pSQLParamStr("TRGDATE_FROM") = pstrTrgFrom
            If pstrTrgTo.Length > 0 Then cdb.pSQLParamStr("TRGDATE_TO") = pstrTrgTo
            '2017/02/15 H.Mori add ���P2016 No9-1 START
            If pstrTrgTimeFrom.Length > 0 Then cdb.pSQLParamStr("TRGTIME_FROM") = pstrTrgTimeFrom
            If pstrTrgTimeTo.Length > 0 Then cdb.pSQLParamStr("TRGTIME_TO") = pstrTrgTimeTo & "59"
            '2017/02/15 H.Mori add ���P2016 No9-1 END

            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�������̏�����Ȃ����@2013/12/05 T.Ono mod �Ď����P2013
            ''�f�[�^�����݂��Ȃ��ꍇ
            'If ds.Tables(0).Rows.Count = 0 And pstrZeroSend <> "1" Then
            '    Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            'ElseIf ds.Tables(0).Rows.Count > intGyoMax Then
            '    Return "DATAMAX"    '�f�[�^���ő�s���𒴂��鎖�������������Ԃ�
            'End If
            If ds.Tables(0).Rows.Count = 0 And pstrZeroSend <> "1" Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            End If

            'dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            ExcelC.pKencd = "00"                '�N���C�A���g�R�[�h���Z�b�g
            ExcelC.pSessionID = pstrSessionID   '�Z�b�V����ID
            ExcelC.pRepoID = "KERUIJOX00"       '���[ID
            ExcelC.mOpen()                      '�t�@�C���I�[�v��

            '2014/03/20 T.Ono mod FAX�^�C�g���ύX�v�]
            'ExcelC.pTitle = "�ݐϏ��ꗗ�\"                        '�^�C�g��
            'ExcelC.pTitle = "�Ď��Z���^�[�Ή����ʗݐϖ��ׁi���񍐁j" '�^�C�g��  2014/03/31 T.Ono mod
            ExcelC.pTitle = "�Ď��Z���^�[�Ή����ʗݐϖ���(����)" '�^�C�g��
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '�쐬��
            ExcelC.pScale = 100                                      '�k���g�嗦(%)
            'ExcelC.pFitPaper = True                                 '�߰��̨��

            '�������
            ExcelC.pLandScape = False
            '�]��
            ExcelC.pMarginTop = 2D
            ExcelC.pMarginBottom = 0.6D
            ExcelC.pMarginLeft = 1.7D
            ExcelC.pMarginRight = 0D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 1.3D

            '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
            ExcelC.mHeader(intPrntRow, ds.Tables(0).Rows.Count, 4)

            '�e��̕����s�N�Z���ŃZ�b�g�B�g���������B
            ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
            'ExcelC.pCellStyle(1) = "height:0px;width:66px;border-style:none"
            ExcelC.pCellStyle(1) = "height:0px;width:71px;border-style:none"
            ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
            ExcelC.pCellStyle(2) = "height:0px;width:65px;border-style:none"
            ExcelC.pCellStyle(3) = "height:0px;width:21px;border-style:none"
            ExcelC.pCellStyle(4) = "height:0px;width:72px;border-style:none"
            ExcelC.pCellStyle(5) = "height:0px;width:23px;border-style:none"
            ExcelC.pCellStyle(6) = "height:0px;width:86px;border-style:none"
            ExcelC.pCellStyle(7) = "height:0px;width:204px;border-style:none"
            ExcelC.pCellStyle(8) = "height:0px;width:72px;border-style:none"
            ExcelC.pCellStyle(9) = "height:0px;width:135px;border-style:none"
            ExcelC.pCellStyle(10) = "height:0px;width:5px;border-style:none"
            ExcelC.pCellStyle(11) = "height:0px;width:5px;border-style:none"
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
            ExcelC.pCellVal(11) = ""
            ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

            If True Then
                '���o�����i��i�j
                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-bottom-style:none"
                ExcelC.pCellVal(1, "colspan = 9") = "���o����"
                ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������

                '���o�����i���i�j
                strHedInfo = "����:"
                If pstrKuracd.Length <> 0 Then strHedInfo &= kenNm
                strHedInfo &= "�@�����Z���^�[:"
                If pstrKyocd.Length <> 0 Then
                    strHedInfo &= centerNm
                End If
                '2015/11/04 w.ganeko 2015���P�J�� ��6 start
                If pstrHanbaiCdFr.Length <> 0 Or pstrHanbaiCdTo.Length <> 0 Then '�̔����Ǝ� ����or�Е����ݒ肳��Ă���ꍇ
                    strHedInfo &= "�@�̔����Ǝ�:"
                    If pstrHanbaiCdFr.Length <> 0 And pstrHanbaiCdFr = pstrHanbaiCdTo Then '�̔����Ǝ� from�Ato�������ꍇ�����̂P��\��
                        strHedInfo &= HanNmFr
                    Else
                        strHedInfo &= HanNmFr & " �` " & HanNmTo
                    End If
                End If
                '2015/11/04 w.ganeko 2015���P�J�� ��6 end
                strHedInfo &= "�@�i�`:"
                If pstrJaCdFr.Length <> 0 And pstrJaCdFr = pstrJaCdTo Then '�i�`���� from�Ato�������ꍇ�����̂P��\��
                    strHedInfo &= jaNmFr
                ElseIf pstrJaCdFr.Length <> 0 Or pstrJaCdTo.Length <> 0 Then '�i�`���� ����or�Е����ݒ肳��Ă���ꍇ 
                    strHedInfo &= jaNmFr & " �` " & jaNmTo
                End If
                strHedInfo &= "�@�i�`�x��:"
                If pstrJasCdFr.Length <> 0 And pstrJasCdFr = pstrJasCdTo Then '�i�`���� from�Ato�������ꍇ�����̂P��\��
                    strHedInfo &= jasNmFr
                ElseIf pstrJasCdFr.Length <> 0 Or pstrJasCdTo.Length <> 0 Then '�i�`���� ����or�Е����ݒ肳��Ă���ꍇ 
                    strHedInfo &= jasNmFr & " �` " & jasNmTo
                End If

                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                ExcelC.pCellVal(1, "colspan = 9") = strHedInfo
                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������

                '���o�����i���i�j
                If pstrStkbn = "1" Then
                    strHedInfo = "�����敪:�d�b"
                ElseIf pstrStkbn = "2" Then
                    strHedInfo = "�����敪:�x��"
                Else
                    strHedInfo = "�����敪:�d�b�^�x��"
                End If

                If pstrTrgTo <> "" Then
                    strHedInfo &= "�@�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom) & "�`" & DateFncC.mGet(pstrTrgTo)
                Else
                    strHedInfo &= "�@�Ώۊ���:" & DateFncC.mGet(pstrTrgFrom)
                End If
                ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none"
                ExcelC.pCellVal(1, "colspan = 9") = strHedInfo
                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
            End If

            '���׃f�[�^�o��
            Dim intd As Integer = 0                   '��������
            Dim intRow As Integer = 0                   '��������
            Dim iRCnt As Integer = 0                   '��������
            Dim iCnt As Integer
            Dim strKyoCd As String = ""    '�O�񋟋��Z���^�[�R�[�h
            Dim strJaCd As String = ""         '�O��i�`�R�[�h
            Dim strAcdCd As String = ""       '�O��i�`�x���R�[�h
            Dim strHanjiCd As String = ""       '�O��̔����Ǝ҃R�[�h 2015/11/04 w.ganeko 2015���P�J�� ��6
            Dim blnFlg As Boolean = False                '����t���O

            '--- ��2005/05/23 ADD Falcon�� ---
            Dim strSTD_CD As String
            Dim intHedFlg As Integer = 0
            '--- ��2005/05/23 ADD Falcon�� ---
            Dim strTAIOKBN As String        '--- 2005/05/26 ADD Falcon ---

            '--- ��2005/07/12 ADD Falcon�� ---
            Dim strTFKICD As String
            Dim bolStdFlg As Boolean        '�o�����\���t���O(True�F�\���@False�F��\��)
            '--- ��2005/07/12 ADD Falcon�� ---

            '2006/02/01 NEC ADD START
            '�o�������������ǂ������ʂ��邽�߂�DataRow
            Dim drPageBreak As DataRow
            '�J�E���^
            Dim intCntPageBreak As Integer

            '�o����񂠂�̌���  2020/11/01 T.Ono add 2020�Ď����P
            Dim intSdCnt As Integer = 0

            '2006/02/01 NEC ADD END

            If ds.Tables(0).Rows.Count = 0 And pstrZeroSend = "1" Then '2010/06/02 T.Watabe add
                '�ΏۂO���Ń[�����o�͂��聨�f�[�^�Z�b�g���X���[

                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                ExcelC.pCellStyle(1) = "height:16px;text-align:left;font-size:13px;border-style:none;"
                ExcelC.pCellVal(1, "colspan=7") = "���ԓ��̏��͂���܂���ł����B"
                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������


                '2016/11/30 T.Ono add 2016���P�J�� ��12 --------------------Start
                'S05_AUTOFAXLOGDB�ɏ�������

                '���O�o�͗p�Ƀf�[�^�Z�b�g
                wkstrTAIOU_SYONO = ""
                wkstrTAIOU_KANSCD = ""
                wkstrTAIOU_KURACD = pstrKuracd
                wkstrTAIOU_JACD = ""
                wkstrTAIOU_ACBCD = ""
                wkstrTAIOU_USER_CD = ""
                wkstrAUTO_ZERO_FLG = "1" ' �y�[�������M�t���O�z 0:�f�[�^����/1:�[�����I(�f�[�^�Ȃ�)

                'EXEC_KBN=0
                '�ݐϏ��FAX����ďo��DEBUGNO=0�́A�ݐϏ��ꗗ����ďo��DEBUGNO=1
                'LATEST_OF_DAY_FLG��"0"�ɂ��Ă����B����FAX���M�O�m�F��"1"�����Ă��邽�߁B
                'FAX�̂��Đ敪���[�v
                For i As Integer = 0 To 1
                    If pstrfaxNo(i).Length > 0 Then
                        intSEQNO = intSEQNO + 1
                        Call mInsertS05AutofaxLog(cdb,
                            strEXEC_YMD,
                            strEXEC_TIME,
                            "0",
                            strGUID,
                            intSEQNO,
                            pstrTrgFrom,
                            "0",
                            wkstrTAIOU_KANSCD,
                            wkstrTAIOU_SYONO,
                            wkstrTAIOU_KURACD,
                            wkstrTAIOU_JACD,
                            wkstrTAIOU_ACBCD,
                            wkstrTAIOU_USER_CD,
                            "1",
                            pstrfaxNo(i),
                            "",
                            wkstrAUTO_ZERO_FLG,
                            "",
                            "0",
                            ""
                            )
                    End If
                Next

                'MAIL�̂��Đ敪���[�v
                For i As Integer = 0 To 1
                    If pstrmailADD(i).Length > 0 Then
                        intSEQNO = intSEQNO + 1
                        Call mInsertS05AutofaxLog(cdb,
                            strEXEC_YMD,
                            strEXEC_TIME,
                            "0",
                            strGUID,
                            intSEQNO,
                            pstrTrgFrom,
                            "0",
                            wkstrTAIOU_KANSCD,
                            wkstrTAIOU_SYONO,
                            wkstrTAIOU_KURACD,
                            wkstrTAIOU_JACD,
                            wkstrTAIOU_ACBCD,
                            wkstrTAIOU_USER_CD,
                            "2",
                            "",
                            pstrmailADD(i),
                            wkstrAUTO_ZERO_FLG,
                            "",
                            "0",
                            ""
                            )
                    End If
                Next
                '2016/11/30 T.Ono add 2016���P�J�� ��12 --------------------End



            ElseIf ds.Tables(0).Rows.Count = 0 Then '2010/06/02 T.Watabe add
                '�ΏۂO�����f�[�^�Z�b�g���X���[

            Else

                dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
                strKyoCd = Convert.ToString(ds.Tables(0).Rows(0).Item("HAISO_CD"))    '�O�񋟋��Z���^�[�R�[�h
                strJaCd = Convert.ToString(ds.Tables(0).Rows(0).Item("JACD"))         '�O��i�`�R�[�h
                strAcdCd = Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD"))       '�O��i�`�x���R�[�h
                strHanjiCd = Convert.ToString(ds.Tables(0).Rows(0).Item("HANJICD"))   '�O��̔����Ǝ҃R�[�h 2015/11/04 W.GANEKO 2015���P�J�� ��6

                'AP�T�[�o����̖߂�l�����[�v����
                'For Each dr In ds.Tables(0).Rows
                For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).Rows(iCnt)

                    If pstrPgkbn = "1" Then
                        'JA�P��
                        If strJaCd <> Convert.ToString(dr.Item("JACD")) Then
                            '���y�[�W���s��
                            ExcelC.mWriteLine("", True)
                            strJaCd = Convert.ToString(dr.Item("JACD"))
                            intRow = 0
                        End If
                        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
                        'ElseIf pstrPgkbn = "2" Then
                        '    '�����Z���^�[�P��
                        '    If strKyoCd <> Convert.ToString(dr.Item("HAISO_CD")) Then
                        '        '���y�[�W���s��
                        '        ExcelC.mWriteLine("", True)
                        '        strKyoCd = Convert.ToString(dr.Item("HAISO_CD"))
                        '        intRow = 0
                        '    End If
                    ElseIf pstrPgkbn = "2" Then
                        'JA�x���P��
                        If strAcdCd <> Convert.ToString(dr.Item("ACBCD")) Then
                            '���y�[�W���s��
                            ExcelC.mWriteLine("", True)
                            strAcdCd = Convert.ToString(dr.Item("ACBCD"))
                            intRow = 0
                        End If
                    ElseIf pstrPgkbn = "3" Then
                        '�̔����ƎҒP��
                        If strHanjiCd <> Convert.ToString(dr.Item("HANJICD")) Then
                            '���y�[�W���s��
                            ExcelC.mWriteLine("", True)
                            strHanjiCd = Convert.ToString(dr.Item("HANJICD"))
                            intRow = 0
                        End If
                    ElseIf pstrPgkbn = "4" Then
                        '�����Z���^�[�P��
                        If strKyoCd <> Convert.ToString(dr.Item("HAISO_CD")) Then
                            '���y�[�W���s��
                            ExcelC.mWriteLine("", True)
                            strKyoCd = Convert.ToString(dr.Item("HAISO_CD"))
                            intRow = 0
                        End If
                        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
                    End If

                    '2020/11/01 T.Ono mod 2020�Ď����P Start
                    'intHedFlg = 0
                    'intCntPageBreak = iCnt
                    'If intRow = 0 Or (intGYOSU = 4 And (intRow Mod 4) = 0) _
                    '        Or (intGYOSU = 3 And (intRow Mod 3) = 0) Then
                    '    bolStdFlg = False   '�o������\��
                    '    '���݂̍s����S�s��܂łɏo����񂪑��݂��邩�`�F�b�N
                    '    Do Until intCntPageBreak - iCnt = 4
                    '        If intCntPageBreak <= ds.Tables(0).Rows.Count - 1 Then
                    '            drPageBreak = ds.Tables(0).Rows(intCntPageBreak)
                    '            strSTD_CD = Convert.ToString(drPageBreak.Item("STD_CD"))         '�o����ЃR�[�h
                    '            strTAIOKBN = Convert.ToString(drPageBreak.Item("TAIOKBN"))       '�Ή��敪�i�P�F�d�b�Ή��@�Q�F�o���w���j
                    '            strTFKICD = Convert.ToString(drPageBreak.Item("TFKICD"))         '���A�Ή���(8:�ً}�o���i�ϑ���j)
                    '            If (strSTD_CD.Length <> 0) And (strTAIOKBN = "2") And (strTFKICD = "8") Then
                    '                bolStdFlg = True    '�o�����\��
                    '            End If
                    '        End If
                    '        '�J�E���g�A�b�v
                    '        intCntPageBreak += 1
                    '    Loop
                    'End If

                    'If intRow = 0 Then
                    '    intHedFlg = 1       '�P�ԍŏ��͕K���w�b�_���w�b�_����������
                    '    '//�o�͍s���̐ݒ�---------------
                    '    '�P�y�[�W�̍s���͏o������\���̏ꍇ�͂S�s�A�\���̏ꍇ�͂R�s��ݒ�
                    '    If bolStdFlg = True Then
                    '        intGYOSU = 3
                    '    Else
                    '        intGYOSU = 4
                    '    End If
                    '    '//-----------------------------
                    'Else
                    '    If (intGYOSU = 4 And (intRow Mod 4) = 0) _
                    '        Or (intGYOSU = 3 And (intRow Mod 3) = 0) Then
                    '        intHedFlg = 1   '�w�b�_�������݁F�L
                    '        intRow = 0      '�s���J�E���g�F0
                    '        intGYOSU = 0    '�P�y�[�W�o�͐��F0
                    '        '//�o�͍s���̐ݒ�---------------
                    '        '�P�y�[�W�̍s���͏o������\���̏ꍇ�͂S�s�A�\���̏ꍇ�͂R�s��ݒ�
                    '        If bolStdFlg = True Then
                    '            intGYOSU = 3
                    '        Else
                    '            intGYOSU = 4
                    '        End If
                    '        '//-----------------------------
                    '        ExcelC.mWriteLine("", True)
                    '    Else
                    '        '//�o�͍s���̐ݒ�---------------
                    '        If intGYOSU = 4 Then
                    '            '�o����ЃR�[�h�����݂���ꍇ�͂R�s�o��
                    '            'If strSTD_CD.Length <> 0 Then
                    '            If bolStdFlg = True Then
                    '                intGYOSU = 3
                    '            Else
                    '                intGYOSU = intGYOSU
                    '            End If
                    '        Else
                    '            intGYOSU = intGYOSU
                    '        End If
                    '        '//-----------------------------
                    '    End If
                    'End If

                    intHedFlg = 0
                    intCntPageBreak = iCnt
                    If intRow = 0 Or (intGYOSU = 3 And (intRow Mod 3) = 0) _
                            Or (intGYOSU = 2 And (intRow Mod 2) = 0) Then
                        bolStdFlg = False   '�o������\��
                        intSdCnt = 0
                        '���݂̍s����R�s��܂łɏo����񂪑��݂��邩�`�F�b�N
                        Do Until intCntPageBreak - iCnt = 3
                            If intCntPageBreak <= ds.Tables(0).Rows.Count - 1 Then
                                drPageBreak = ds.Tables(0).Rows(intCntPageBreak)
                                strSTD_CD = Convert.ToString(drPageBreak.Item("STD_CD"))         '�o����ЃR�[�h
                                strTAIOKBN = Convert.ToString(drPageBreak.Item("TAIOKBN"))       '�Ή��敪�i�P�F�d�b�Ή��@�Q�F�o���w���j
                                strTFKICD = Convert.ToString(drPageBreak.Item("TFKICD"))         '���A�Ή���(8:�ً}�o���i�ϑ���j)
                                If (strSTD_CD.Length <> 0) And (strTAIOKBN = "2") And (strTFKICD = "8") Then
                                    bolStdFlg = True    '�o�����\��
                                    intSdCnt += 1       '�o����񂠂茏��
                                End If
                            End If
                            '�J�E���g�A�b�v
                            intCntPageBreak += 1
                        Loop
                    End If

                    If intRow = 0 Then
                        intHedFlg = 1       '�P�ԍŏ��͕K���w�b�_���w�b�_����������
                        '//�o�͍s���̐ݒ�---------------
                        '�o�����\�����Q���ȏ�Ȃ�Q���\���B�O���܂��͂P���Ȃ�R���\���B
                        If intSdCnt >= 2 Then
                            intGYOSU = 2
                        Else
                            intGYOSU = 3
                        End If
                        '//-----------------------------
                    Else
                        If (intGYOSU = 3 And (intRow Mod 3) = 0) _
                            Or (intGYOSU = 2 And (intRow Mod 2) = 0) Then
                            intHedFlg = 1   '�w�b�_�������݁F�L
                            intRow = 0      '�s���J�E���g�F0
                            intGYOSU = 0    '�P�y�[�W�o�͐��F0
                            '//�o�͍s���̐ݒ�---------------
                            '�o�����\�����Q���ȏ�Ȃ�Q���\���B�O���܂��͂P���Ȃ�R���\���B
                            If intSdCnt >= 2 Then
                                intGYOSU = 2
                            Else
                                intGYOSU = 3
                            End If
                            '//-----------------------------
                            ExcelC.mWriteLine("", True)
                        Else
                            '//�o�͍s���̐ݒ�---------------
                            If intGYOSU = 4 Then
                                '�o����ЃR�[�h�����݂���ꍇ�͂R���o��
                                If bolStdFlg = True Then
                                    intGYOSU = 3
                                Else
                                    intGYOSU = intGYOSU
                                End If
                            Else
                                intGYOSU = intGYOSU
                            End If
                            '//-----------------------------
                        End If
                    End If
                    '2020/11/01 T.Ono mod 2020�Ď����P End

                    If intHedFlg = 1 Then
                        ExcelC.mWriteLine("")
                        ExcelC.pCellStyle(1) = "height:16px;text-align:left;font-size:13px;border:none"
                        ExcelC.pCellStyle(2) = "height:16px;text-align:left;font-size:13px;border:none"     '<-- 2005/05/21 ADD
                        ExcelC.pCellVal(1, "colspan=2") = "�����F" & kenNm
                        If pstrPgkbn = "1" Then
                            ExcelC.pCellVal(2, "colspan=7") = "�i�`���F" & Convert.ToString(dr.Item("JANM"))
                            'ElseIf pstrPgkbn = "2" Then
                            '    ExcelC.pCellVal(2, "colspan=7") = "�����Z���^�[���F" & Convert.ToString(dr.Item("NAME"))
                            '2015/11/04 w.ganeko 2015���P�J�� ��6 start
                        ElseIf pstrPgkbn = "2" Then
                            ExcelC.pCellVal(2, "colspan=7") = "JA�x�����F" & Convert.ToString(dr.Item("ACBNM"))
                        ElseIf pstrPgkbn = "3" Then
                            ExcelC.pCellVal(2, "colspan=7") = "�̔����ƎҖ��F" & Convert.ToString(dr.Item("HANJINM"))
                        ElseIf pstrPgkbn = "4" Then
                            ExcelC.pCellVal(2, "colspan=7") = "�����Z���^�[���F" & Convert.ToString(dr.Item("NAME"))
                            '2015/11/04 w.ganeko 2015���P�J�� ��6 end
                        End If
                        ExcelC.mWriteLine("")


                        iRCnt = iRCnt + 1
                    End If


                    '���׍���
                    '1�i��----------------------------------------------------------------
                    'JA�x��
                    ExcelC.pCellStyle(1) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
                    ExcelC.pCellVal(1, "colspan = 2") = "�i�`�x����:"
                    ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
                    ExcelC.pCellVal(2, "colspan = 7") = Convert.ToString(dr.Item("ACBCD")) & "�@" & Convert.ToString(dr.Item("ACBNM"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '2�i��-----------------------------------------------------------------
                    '���q�l��
                    ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                    ' 2015/02/13 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(1) = "����:"
                    ExcelC.pCellVal(1) = "���q�l��:"
                    ' 2015/02/13 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(2) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUSYONM"))
                    '���q�l�R�[�h
                    ExcelC.pCellStyle(3) = "text-align:right;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(3) = "���v�ƃR�[�h:"
                    ExcelC.pCellVal(3) = "���q�l�R�[�h:"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(4) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                    ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("JUYOKA"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '3�i��-----------------------------------------------------------------
                    '�����ԍ�
                    ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(1) = "TEL:"
                    ExcelC.pCellVal(1) = "�����ԍ�:"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(2) = "font-size:13px;border-style:none"
                    If Convert.ToString(dr.Item("JUTEL1")) = "" Then
                        ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL2"))
                    Else
                        ExcelC.pCellVal(2, "colspan = 5") = Convert.ToString(dr.Item("JUTEL1")) & "-" & Convert.ToString(dr.Item("JUTEL2"))
                    End If
                    '�A����
                    ExcelC.pCellStyle(3) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = "�A����:"
                    ExcelC.pCellStyle(4) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(4, "colspan = 2") = Convert.ToString(dr.Item("RENTEL"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '4�i��-----------------------------------------------------------------
                    '�Z��
                    ExcelC.pCellStyle(1) = "height:16px;text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1) = "�Z��:"
                    ExcelC.pCellStyle(2) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:dashed"
                    ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("ADDR"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '5�i��-----------------------------------------------------------------
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1) = "<�ً}>"
                    '���ې�
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(2) = "���ې�:"
                    ExcelC.pCellStyle(3) = "font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KEIHOSU"))
                    '���ʋ敪
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-left-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(4) = "���ʋ敪:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = Convert.ToString(dr.Item("RYURYO"))
                    '�������
                    ExcelC.pCellStyle(6) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/17 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(6) = "�������:"
                    ExcelC.pCellVal(6) = "�����敪:"
                    ' 2015/02/17 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(7) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(7) = Convert.ToString(dr.Item("TMSKB_NAI"))
                    '��M����
                    ExcelC.pCellStyle(8) = "text-align:right;font-size:13px;border-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(8) = "��t����:"
                    ExcelC.pCellVal(8) = "��M����:"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(9) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(9) = DateFncC.mGet(Convert.ToString(dr.Item("HATYMD"))) &
                                                        " " & CTimeFncC.mGet(Convert.ToString(dr.Item("HATTIME")), 0)
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '6�i��-----------------------------------------------------------------
                    '�x��P���b�Z�[�W
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM1"))
                    '�A������
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(2) = "�A�������:"
                    ExcelC.pCellVal(2) = "�A������:"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TAITNM"))
                    '��������
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(4) = "��������:"
                    ExcelC.pCellVal(4) = "��������:"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SYOYMD"))) &
                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOTIME")), 0)
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '7�i��-----------------------------------------------------------------
                    '�x��Q���b�Z�[�W
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM2"))
                    '�S���Җ�
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(2) = "�S���Җ�:"

                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TKTANCD_NM"))
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    ''�����敪
                    'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    'ExcelC.pCellVal(4) = "�����敪:"
                    'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("HATKBN_NAI"))
                    '�˗�����
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(4) = "�˗�����:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SIJIYMD"))) &
                                         " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SIJITIME")), 0)
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '8�i��-----------------------------------------------------------------
                    '�x��R���b�Z�[�W
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM3"))
                    '���A���
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(2) = "���A����:"
                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TFKINM"))
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    ''�Ή��敪
                    'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    'ExcelC.pCellVal(4) = "�Ή��敪:"
                    'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    '�����敪
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(4) = "�����敪:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = Convert.ToString(dr.Item("HATKBN_NAI"))
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '9�i��-----------------------------------------------------------------
                    '�x��S���b�Z�[�W
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM4"))
                    '�������
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(2) = "����:"
                    ExcelC.pCellVal(2) = "�������:"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TKIGNM"))
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    ''���[�^�w�j�l
                    'ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    'ExcelC.pCellVal(4) = "���[�^�l:"
                    'ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    'ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
                    '�Ή��敪
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(4) = "�Ή��敪:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = Convert.ToString(dr.Item("TAIOKBN_NAI"))
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '10�i��----------------------------------------------------------------
                    '�x��T���b�Z�[�W
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM5"))
                    '�쓮����
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(2) = "�쓮����:"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("TSADNM"))
                    ExcelC.pCellVal(3) = Convert.ToString(dr.Item("TSADNM"))
                    ExcelC.pCellStyle(3) = "font-size:13px;border-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ' 2015/02/16 H.Hosoda add 2014���P�J�� No9 START
                    '���[�^�w�j�l
                    ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                    ExcelC.pCellVal(4) = "���[�^�l:"
                    ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(5) = Convert.ToString(dr.Item("KENSIN"))
                    ' 2015/02/16 H.Hosoda add 2014���P�J�� No9 END
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '11�i��----------------------------------------------------------------
                    '�x��U���b�Z�[�W
                    ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-top-style:none"
                    ExcelC.pCellVal(1, "colspan = 5") = Convert.ToString(dr.Item("KMNM6"))
                    '--- �o�����̏o�͒ǉ� ----------
                    ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-top-style:none;border-right-style:none;border-bottom-style:none"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                    'ExcelC.pCellVal(2) = "�o���w��:"
                    ExcelC.pCellVal(2) = "�o���˗�:"
                    ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                    ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                    '2020/11/01 T.Ono mod 2020�Ď����P Start
                    'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("SDNM"))
                    If pstrSdPrt = "0" Then
                        ExcelC.pCellVal(3, "colspan = 3") = ""
                    Else
                        ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("SDNM"))
                    End If
                    '2020/11/01 T.Ono mod 2020�Ď����P End
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '12�i��----------------------------------------------------------------
                    '�d�b�����P
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO1"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '13�i��----------------------------------------------------------------
                    '�d�b�����P
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO2"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '14�i��----------------------------------------------------------------
                    '���A���상��
                    'ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none"          '2020/11/01 T.Ono mod 2020�Ď����P
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("FUK_MEMO"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������

                    '2020/11/01 T.Ono mod 2020�Ď����P Start
                    '12�i��----------------------------------------------------------------
                    '�d�b�����S
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO4"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '13�i��----------------------------------------------------------------
                    '�d�b�����T
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO5"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    '14�i��----------------------------------------------------------------
                    '�d�b�����U
                    ExcelC.pCellStyle(1) = "height:16px;font-size:12px;border-top-style:none"
                    ExcelC.pCellVal(1, "colspan = 9") = Convert.ToString(dr.Item("TEL_MEMO6"))
                    ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������

                    '2020/11/01 T.Ono mod 2020�Ď����P End

                    '�o�����ł���΁A�o�����e��\��
                    If Convert.ToString(dr.Item("STD_CD")).Length <> 0 And
                    Convert.ToString(dr.Item("TAIOKBN")) = "2" And
                    Convert.ToString(dr.Item("TFKICD")) = "8" Then
                        '2006/2/1 NEC UPDATE END
                        '15�i��-----------------------------------------------------------------
                        ExcelC.pCellStyle(1) = "height:16px;font-size:13px;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "colspan = 5") = "���o�����"
                        '�A�������
                        ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                        'ExcelC.pCellVal(2) = "�A�������:"
                        'ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-bottom-style:none;border-left-style:none"
                        'ExcelC.pCellVal(3, "colspan = 3") = Convert.ToString(dr.Item("AITNM"))
                        ExcelC.pCellVal(2) = "�Ή�����:"
                        ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-style:none"
                        ExcelC.pCellVal(3) = Convert.ToString(dr.Item("AITNM"))
                        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                        ' 2015/02/16 H.Hosoda add 2014���P�J�� No9 START
                        '��M����
                        ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                        ExcelC.pCellVal(4) = "��M����:"
                        ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                        ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SIJIYMD"))) &
                                             " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SIJITIME")), 0)
                        ' 2015/02/16 H.Hosoda add 2014���P�J�� No9 END
                        ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                        '16�i��-----------------------------------------------------------------
                        '��M�Ҏ���
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                        'ExcelC.pCellVal(1, "colspan = 5") = "��M�Ҏ���:" & Convert.ToString(dr.Item("TSTANNM"))
                        ''�쓮����
                        'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        'ExcelC.pCellVal(3) = "�쓮����:"
                        'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("SADNM"))
                        ExcelC.pCellVal(1, "colspan = 5") = "�o���Ή���:" & Convert.ToString(dr.Item("SYUTDTNM"))
                        '�������
                        ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        ExcelC.pCellVal(2) = "�������:"
                        ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-style:none"
                        ExcelC.pCellVal(3) = Convert.ToString(dr.Item("KIGNM"))
                        '�o������
                        ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                        ExcelC.pCellVal(4) = "�o������:"
                        ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                        ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("SDYMD"))) &
                                             " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SDTIME")), 0)
                        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                        ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                        '17�i��-----------------------------------------------------------------
                        '���A����
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "colspan = 5") = "���A����:" & Convert.ToString(dr.Item("FKINM"))
                        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                        ''�Z���T����
                        'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        'ExcelC.pCellVal(3) = "�Z���T����:"
                        'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("ASENM"))
                        '�쓮����
                        ExcelC.pCellStyle(2) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        ExcelC.pCellVal(2) = "�쓮����:"
                        ExcelC.pCellStyle(3) = "height:16px;font-size:13px;border-style:none"
                        ExcelC.pCellVal(3) = Convert.ToString(dr.Item("SADNM"))
                        '��������
                        ExcelC.pCellStyle(4) = "text-align:right;font-size:13px;border-style:none"
                        ExcelC.pCellVal(4) = "��������:"
                        ExcelC.pCellStyle(5) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                        ExcelC.pCellVal(5) = DateFncC.mGet(Convert.ToString(dr.Item("TYAKYMD"))) &
                                             " " & CTimeFncC.mGet(Convert.ToString(dr.Item("TYAKTIME")), 0)
                        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                        ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                        '18�i��-----------------------------------------------------------------
                        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 START
                        ''����
                        'ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        'ExcelC.pCellVal(1, "colspan = 5") = "����:" & Convert.ToString(dr.Item("KIGNM"))
                        ''���̑�����
                        'ExcelC.pCellStyle(3) = "text-align:right;height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none;border-right-style:none"
                        'ExcelC.pCellVal(3) = "�������:"
                        'ExcelC.pCellStyle(4) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        'ExcelC.pCellVal(4, "colspan = 3") = Convert.ToString(dr.Item("STANM"))
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "colspan = 7") = ""
                        '��������
                        ExcelC.pCellStyle(2) = "text-align:right;font-size:13px;border-style:none"
                        ExcelC.pCellVal(2) = "��������:"
                        ExcelC.pCellStyle(3) = "font-size:13px;border-top-style:none;border-left-style:none;border-bottom-style:none"
                        ExcelC.pCellVal(3) = DateFncC.mGet(Convert.ToString(dr.Item("SYOKANYMD"))) &
                                             " " & CTimeFncC.mGet(Convert.ToString(dr.Item("SYOKANTIME")), 0)
                        ' 2015/02/16 H.Hosoda mod 2014���P�J�� No9 END
                        ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                        '19�i��-----------------------------------------------------------------
                        '�o�����l
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "nowrap") = "�o�����l:"
                        ExcelC.pCellStyle(2) = "height:16px;font-size:13px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        '2020/11/01 T.Ono mod 2020�Ď����P Start
                        'ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SIJI_BIKO1"))
                        If pstrSdPrt = "0" Then
                            ExcelC.pCellVal(2, "colspan = 8") = ""
                        Else
                            ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SIJI_BIKO1"))
                        End If
                        '2020/11/01 T.Ono mod 2020�Ď����P End
                        ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                        '20�i��-----------------------------------------------------------------
                        '�o������(1)
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1, "nowrap") = "�o������:"
                        ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK2"))
                        ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                        '21�i��-----------------------------------------------------------------
                        '�o������(2)
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-bottom-style:none;border-right-style:none"
                        ExcelC.pCellVal(1) = ""
                        ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-bottom-style:none;border-left-style:none"
                        ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SNTTOKKI"))
                        ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                        '22�i��-----------------------------------------------------------------
                        '�o������(3)
                        ExcelC.pCellStyle(1) = "font-size:13px;border-top-style:none;border-right-style:none"
                        ExcelC.pCellVal(1) = ""
                        ExcelC.pCellStyle(2) = "height:16px;font-size:12px;border-top-style:none;border-left-style:none"
                        ExcelC.pCellVal(2, "colspan = 8") = Convert.ToString(dr.Item("SDTBIK3"))
                        ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                    End If

                    '�s���̃J�E���g
                    intRow = intRow + 1
                    If (intRow Mod intGYOSU) = 0 Then
                    Else
                        ExcelC.pCellStyle(1) = "height:6px;border:none"
                        ExcelC.pCellVal(1, "colspan = 9") = ""
                        ExcelC.mWriteLine("")   '�s���t�@�C���ɏ�������
                    End If

                    If intGYOSU = 4 Then
                        iRCnt = iRCnt + 15
                    Else
                        iRCnt = iRCnt + 22
                    End If

                    '2016/11/30 T.Ono add 2016���P�J�� ��12 --------------------Start
                    'S05_AUTOFAXLOGDB�ɏ�������
                    '���O�o�͗p�Ƀf�[�^�Z�b�g
                    wkstrTAIOU_SYONO = Convert.ToString(dr.Item("SYONO"))
                    wkstrTAIOU_KANSCD = Convert.ToString(dr.Item("KANSCD"))
                    wkstrTAIOU_KURACD = Convert.ToString(dr.Item("KURACD"))
                    wkstrTAIOU_JACD = Convert.ToString(dr.Item("JACD"))
                    wkstrTAIOU_ACBCD = Convert.ToString(dr.Item("ACBCD"))
                    wkstrTAIOU_USER_CD = Convert.ToString(dr.Item("JUYOKA"))
                    wkstrAUTO_ZERO_FLG = "0" ' �y�[�������M�t���O�z 0:�f�[�^����/1:�[�����I(�f�[�^�Ȃ�)

                    'EXEC_KBN=0
                    '�ݐϏ��FAX����ďo��DEBUGNO=0�́A�ݐϏ��ꗗ����ďo��DEBUGNO=1
                    ''LATEST_OF_DAY_FLG��"0"�ɂ��Ă����B����FAX���M�O�m�F��"1"�����Ă��邽�߁B
                    'FAX�̂��Đ敪���[�v
                    For i As Integer = 0 To 1
                        If pstrfaxNo(i).Length > 0 Then
                            intSEQNO = intSEQNO + 1
                            Call mInsertS05AutofaxLog(cdb,
                                strEXEC_YMD,
                                strEXEC_TIME,
                                "0",
                                strGUID,
                                intSEQNO,
                                pstrTrgFrom,
                                "0",
                                wkstrTAIOU_KANSCD,
                                wkstrTAIOU_SYONO,
                                wkstrTAIOU_KURACD,
                                wkstrTAIOU_JACD,
                                wkstrTAIOU_ACBCD,
                                wkstrTAIOU_USER_CD,
                                "1",
                                pstrfaxNo(i),
                                "",
                                wkstrAUTO_ZERO_FLG,
                                "",
                                "0",
                                ""
                                )
                        End If
                    Next

                    'MAIL�̂��Đ敪���[�v
                    For i As Integer = 0 To 1
                        If pstrmailADD(i).Length > 0 Then
                            intSEQNO = intSEQNO + 1
                            Call mInsertS05AutofaxLog(cdb,
                                strEXEC_YMD,
                                strEXEC_TIME,
                                "0",
                                strGUID,
                                intSEQNO,
                                pstrTrgFrom,
                                "0",
                                wkstrTAIOU_KANSCD,
                                wkstrTAIOU_SYONO,
                                wkstrTAIOU_KURACD,
                                wkstrTAIOU_JACD,
                                wkstrTAIOU_ACBCD,
                                wkstrTAIOU_USER_CD,
                                "2",
                                "",
                                pstrmailADD(i),
                                wkstrAUTO_ZERO_FLG,
                                "",
                                "0",
                                ""
                                )
                        End If
                    Next
                    '2016/11/30 T.Ono add 2016���P�J�� ��12 --------------------End

                Next
            End If

            ExcelC.mWriteLine("")                           '�s���t�@�C���ɏ�������
            ExcelC.mClose()                                 '�t�@�C���N���[�Y

            ' 2011/02/10 T.Watabe edit ���̕����֖߂�
            If True Then

                Dim strXlsSubName As String ' 2011/06/02 T.Watabe add
                If jaNmFr.Length > 0 Then
                    strXlsSubName = jaNmFr
                ElseIf centerNm.Length > 0 Then
                    strXlsSubName = centerNm
                ElseIf kenNm.Length > 0 Then
                    strXlsSubName = kenNm
                End If

                '2018/02/19 T.Ono mod START --------------------
                '���k���@��ύX�BUNLHA32.DLL�͎g��Ȃ��B

                ''�t�@�C���f�[�^���G���R�[�h���ČĂяo�����֖߂�����
                ''���k��t�@�C���̂���t�H���_
                'compressC.p_Dir = ExcelC.pDirName
                ''���{��t�@�C�����̎w��f
                ''compressC.p_NihongoFileName = pstrSessionID & "�ݐϏ��ꗗ�\.xls" ' 2011/06/02 T.Watabe edit
                'compressC.p_NihongoFileName = "�ݐϏ��_" & strXlsSubName & "_" & pstrSessionID & ".xls"
                ''���k���t�@�C����
                'compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                ''���k��t�@�C����
                'compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
                'compressC.p_Exec = pbolLzhAutoExec '�𓀎��̎������s����H�^�Ȃ��H

                ''2014/01/16 T.Ono mod �Ď����P2013 Excel�𒼐ڊJ���悤�ɕύX�A�t�@�C���t���p�X��Ԃ�
                '''���k���s
                ''compressC.mCompress()
                '''���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                '''.xls�`���ɕύX 2013/12/05 T.Ono mod �Ď����P2013
                '''Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
                ''Return FileToStrC.mFileToStr(compressC.p_FileName)
                ''2015/11/04 w.ganeko 2015���P�J�� ��6 start
                ''Return compressC.p_FileName
                'If pstrZipFlg = "0" Then
                '    'Return compressC.p_FileName
                '    Dim sCopyFrom As String = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                '    Return sCopyFrom
                'ElseIf pstrZipFlg = "1" Then
                '    '���k���s
                '    compressC.mCompress()
                '    '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                '    Return FileToStrC.mFileToStr(compressC.p_madeFilename.Replace(".lzh", ".exe"))
                'End If
                ''2015/11/04 w.ganeko 2015���P�J�� ��6 end

                '�ϐ��錾
                Dim strToDir As String = ""           '���k��t�@�C���̂���t�H���_
                Dim strToZipDir As String = ""        '���k����f�B���N�g��
                Dim strNihongoFileName As String = "" '���{��t�@�C�����̎w��(�p�����[�^[�Z�b�V����] + �d�b�ԍ�)
                Dim strFileName As String = ""        '���k���t�@�C����(FAX�pEXCEL�A���[���pZIP�t�@�C����)
                Dim strmadeFilename As String = ""    '���k��t�@�C����(�p�����[�^[�Z�b�V����])

                '�t�@�C���f�[�^���G���R�[�h���ČĂяo�����֖߂�����
                '���k��t�@�C���̂���t�H���_
                strToDir = ExcelC.pDirName
                '���{��t�@�C�����̎w��f
                strNihongoFileName = "�ݐϏ��_" & strXlsSubName & "_" & pstrSessionID & ".xls"
                '���k���t�@�C����
                strFileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                '���k��t�@�C����
                strmadeFilename = ExcelC.pDirName & ExcelC.pFileName & ".zip"

                If pstrZipFlg = "0" Then
                    '�ݐϏ��ꗗ�iExcel�t�@�C������Ԃ��j
                    Dim sCopyFrom As String = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                    Return sCopyFrom
                ElseIf pstrZipFlg = "1" Then
                    '�ݐϏ�񎩓�FAX�iZIP���ɂ�Ԃ��j
                    '���k����f�B���N�g���̍쐬
                    strToZipDir = ExcelC.pDirName & pstrSessionID
                    If File.Exists(strToZipDir) = False Then
                        System.IO.Directory.CreateDirectory(strToZipDir)
                    End If

                    '���k��t�@�C����      (�p�����[�^[�Z�b�V����])���Q��ڈȍ~�̎��͒ǉ������
                    strmadeFilename = strToZipDir & ".zip"

                    '�f�B���N�g�������k�iZIP���ɍ쐬�j
                    If File.Exists(strmadeFilename) = False Then
                        ZipFile.CreateFromDirectory(strToZipDir, strmadeFilename, CompressionLevel.Optimal,
                                    False, System.Text.Encoding.GetEncoding("shift_jis"))
                    End If

                    'ZIP���ɂ��I�[�v�����A�t�@�C����ǉ�
                    Using fo As ZipArchive = ZipFile.Open(strmadeFilename, ZipArchiveMode.Update)
                        Dim e As ZipArchiveEntry = fo.CreateEntryFromFile(strFileName, strNihongoFileName)
                    End Using

                    '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                    Return FileToStrC.mFileToStr(strmadeFilename)

                End If
                '2018/02/19 T.Ono mod END ----------------------

            Else
                ' 2011/02/01 T.Watabe edit
                '�t�@�C���p�X��߂������i�����j
                Dim sCopyFrom As String = ExcelC.pDirName & ExcelC.pFileName & ".xls"
                'Dim sCopyTo As String = ExcelC.pDirName & pstrSessionID & "�ݐϏ��ꗗ�\.xls"
                'Microsoft.VisualBasic.FileSystem.Rename(sCopyFrom, sCopyTo)
                'Return FileToStrC.mFileToStr(sCopyTo)
                'Return FileToStrC.mFileToStr(sCopyFrom)
                Return sCopyFrom
            End If

        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function

    '******************************************************************************
    '*�@�T�@�v:�t�@�C�����k�i�����f�[�^���t�@�C���ɕ������A���k��(lzh,zip)�A�ēx�����f�[�^�ɕϊ����Ė߂��j
    '*�@���@�l:
    '******************************************************************************
    <WebMethod()> Public Function compressStr2Arc2Str(ByVal pFileName As String, ByVal pBase64Data As String, ByVal pPass As String) As String

        Dim compressC As New CCompress                  '���k�N���X
        Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim excelPath As String
        Try

            excelPath = ConfigurationSettings.AppSettings.Get("EXCELPATH")

            If saveString2BinFile(pBase64Data, excelPath & pFileName) Then

                If False Then
                    '���k��t�@�C���̂���t�H���_
                    compressC.p_Dir = excelPath
                    '���{��t�@�C�����̎w��
                    compressC.p_NihongoFileName = pFileName ' pstrSessionID & "�ݐϏ��ꗗ�\.xls"
                    '���k���t�@�C����
                    compressC.p_FileName = excelPath & pFileName   ' ExcelC.pDirName & ExcelC.pFileName & ".xls"
                    '���k��t�@�C����
                    compressC.p_madeFilename = excelPath & pFileName.Replace(".xls", ".lzh") ' ExcelC.pDirName & ExcelC.pFileName & ".lzh"
                    compressC.p_Exec = False '�𓀎��̎������s����H�^�Ȃ��H
                    '���k���s
                    compressC.mCompress()
                    '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                    Return FileToStrC.mFileToStr(compressC.p_madeFilename)
                End If
                If True Then
                    Dim sXlsFilePath As String = excelPath & pFileName
                    Dim sZipFilePath As String = excelPath & pFileName.Replace(".xls", ".zip")

                    Call fncMakeZipWithPass(sXlsFilePath, sZipFilePath, pPass)

                    '���k�����t�@�C����Base64�G���R�[�h���Ė߂�
                    Return FileToStrC.mFileToStr(sZipFilePath)
                End If

            Else
                Dim buf As String = ""
                If IsNothing(pBase64Data) = False And pBase64Data.Length >= 10 Then buf = pBase64Data.Substring(0, 10)

                Return "ERROR:�����f�[�^����t�@�C�������G���[[" & pFileName & "][" & buf & "](compressStr2Arc2Str)"
            End If

        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally

        End Try

    End Function

    '==========================================================================================
    ' �o�C�g�����񂩂�t�@�C���ɕ���
    '==========================================================================================
    Public Function saveString2BinFile(ByVal base64Data As String, ByVal saveFilePath As String) As Boolean
        If base64Data.Length <= 0 Then Return False
        If saveFilePath.Length <= 0 Then Return False
        Try
            Dim bs() As Byte = System.Convert.FromBase64String(base64Data) '�o�C�g�^�z��ɖ߂�
            Dim outFile As New System.IO.FileStream(saveFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write)             '�t�@�C���ɏ�������
            outFile.Write(bs, 0, bs.Length)
            outFile.Close()
        Catch ex As Exception
            Return False
        End Try
        Return True
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
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                              ByVal pstrKuracd As String, _
    '                              ByVal pstrKyocd As String, _
    '                              ByVal pstrJacd As String, _
    '                              ByVal pstrJascd As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrPgKbn As String, _
    '                              ByVal pdecPageMax As Decimal) As String

    '    Dim strSQL As New StringBuilder("")

    '    strSQL.Append("SELECT ")
    '    If ind = 1 Then
    '        strSQL.Append("COUNT(*) ")
    '    Else
    '        strSQL.Append("DT.KENNM, ")
    '        strSQL.Append("DT.KURACD, ")
    '        strSQL.Append("DT.KANSCD, ")
    '        '20050730 NEC UPDATE START
    '        'strSQL.Append("HN.HAISO_CD, ")          '--JA�x���}�X�^�D�����Z���^�[�R�[�h
    '        strSQL.Append("HA.HAISO_CD, ")          '--�z���Z���^�}�X�^�D�����Z���^�[�R�[�h
    '        '20050730 NEC UPDATE END
    '        strSQL.Append("HA.NAME, ")              '--�z���Z���^�}�X�^�D�����Z���^�[��
    '        strSQL.Append("DT.JACD, ")
    '        strSQL.Append("DT.JANM, ")
    '        strSQL.Append("DT.ACBCD, ")
    '        strSQL.Append("DT.ACBNM, ")
    '        strSQL.Append("DT.ACBCD || DT.USER_CD AS JUYOKA, ")
    '        strSQL.Append("DT.JUSYONM, ")
    '        '2006/06/14 NEC UPDATE START
    '        'strSQL.Append("DT.JUTEL1 || DT.JUTEL2 AS JUTEL, ")
    '        strSQL.Append("DT.JUTEL1, ")
    '        strSQL.Append("DT.JUTEL2, ")
    '        '2006/06/14 NEC END
    '        strSQL.Append("DT.RENTEL, ")
    '        strSQL.Append("DT.ADDR, ")
    '        strSQL.Append("DT.HATKBN_NAI, ")
    '        strSQL.Append("DT.HATYMD, ")
    '        strSQL.Append("DT.HATTIME, ")
    '        strSQL.Append("DT.KEIHOSU, ")
    '        strSQL.Append("DT.RYURYO, ")
    '        strSQL.Append("DT.KMNM1, ")
    '        strSQL.Append("DT.KMNM2, ")
    '        strSQL.Append("DT.KMNM3, ")
    '        strSQL.Append("DT.KMNM4, ")
    '        strSQL.Append("DT.KMNM5, ")
    '        strSQL.Append("DT.KMNM6, ")
    '        strSQL.Append("DT.TMSKB_NAI, ")
    '        strSQL.Append("DT.SYOYMD, ")
    '        strSQL.Append("DT.SYOTIME, ")
    '        strSQL.Append("DT.TAITNM, ")
    '        strSQL.Append("DT.TAIOKBN_NAI, ")
    '        strSQL.Append("DT.TKTANCD_NM, ")
    '        strSQL.Append("DT.TFKINM, ")
    '        strSQL.Append("DT.TKIGNM, ")
    '        strSQL.Append("DT.TSADNM, ")
    '        '2006/06/14 NEC UPDATE START
    '        strSQL.Append("DT.SDNM, ")
    '        '2006/06/14 NEC UPDATE END
    '        strSQL.Append("DT.TFKICD, ")    '--- 2005/07/12 ADD Falcon
    '        '--- ��2005/05/21 ADD Falcon�� ---
    '        strSQL.Append("DT.FUK_MEMO, ")
    '        strSQL.Append("DT.AITNM, ")
    '        strSQL.Append("DT.TSTANNM, ")
    '        strSQL.Append("DT.SADNM, ")
    '        strSQL.Append("DT.FKINM, ")
    '        strSQL.Append("DT.ASENM, ")
    '        strSQL.Append("DT.KIGNM, ")
    '        strSQL.Append("DT.STANM, ")
    '        strSQL.Append("DT.SDTBIK1, ")
    '        strSQL.Append("DT.SDTBIK2, ")
    '        '2006/06/14 NEC UPDATE START
    '        strSQL.Append("DT.SDTBIK3, ")
    '        strSQL.Append("DT.SIJI_BIKO1, ")
    '        '2006/06/14 NEC UPDATE END
    '        strSQL.Append("DT.SNTTOKKI, ")
    '        strSQL.Append("DT.STD_CD, ")
    '        '--- ��2005/05/21 ADD Falcon�� ---
    '        strSQL.Append("DT.TAIOKBN, ")       '--- 2005/05/26 ADD Falcon ---
    '        strSQL.Append("DT.TEL_MEMO1, ")
    '        strSQL.Append("DT.TEL_MEMO2, ")
    '        strSQL.Append("DT.KENSIN ") '2010/03/05 T.Watabe add
    '        strSQL.Append("FROM ")
    '        strSQL.Append("D20_TAIOU DT, ")
    '        strSQL.Append("HN2MAS HN, ")
    '        '20050730 NEC UPDATE START
    '        'strSQL.Append("HAIMAS HA ")
    '        strSQL.Append("(SELECT J.CLI_CD,J.HAN_CD,H.HAISO_CD,H.NAME FROM HN2MAS J,HAIMAS H ")
    '        strSQL.Append("WHERE SUBSTR(J.CLI_CD,2,2)=H.KEN_CD AND ")
    '        strSQL.Append("J.HAISO_CD=H.HAISO_CD ) HA ")
    '        '20050730 NEC UPDATE END
    '    End If
    '    'WHERE
    '    strSQL.Append("WHERE DT.TAIOKBN<'3' ")        '�d���͊܂܂Ȃ�
    '    strSQL.Append("  AND DT.KURACD=HN.CLI_CD(+) ")
    '    strSQL.Append("  AND DT.ACBCD=HN.HAN_CD(+) ")
    '    '20050730 NEC UPDATE START
    '    'strSQL.Append("  AND SUBSTR(HN.CLI_CD,2,2)=HA.KEN_CD(+) ")
    '    'strSQL.Append("  AND HN.HAISO_CD=HA.HAISO_CD(+) ")
    '    strSQL.Append("  AND DT.KURACD=HA.CLI_CD(+) ")
    '    strSQL.Append("  AND DT.ACBCD=HA.HAN_CD(+) ")
    '    '20050730 NEC UPDATE END
    '    ' ��ʂ���̏����w��
    '    If pstrKuracd.Length <> 0 Then
    '        strSQL.Append(" AND DT.KURACD = :KURACD ")
    '    End If
    '    If pstrKyocd.Length <> 0 Then
    '        '20050730 NEC UPDATE START
    '        '�����Z���^�[���w�肳�ꂽ�Ƃ��͓�������
    '        'strSQL.Append("  AND :KYOCD=HN.HAISO_CD(+) ")
    '        strSQL.Append("  AND DT.KURACD=HA.CLI_CD ")
    '        strSQL.Append("  AND DT.ACBCD=HA.HAN_CD ")
    '        '20050730 NEC UPDATE END
    '        strSQL.Append("  AND :KYOCD=HA.HAISO_CD ")
    '    End If
    '    If pstrJacd.Length <> 0 Then
    '        'strSQL.Append("	  AND DT.JACD LIKE :JACD || '%' ")
    '        strSQL.Append("	  AND DT.JACD = :JACD ")
    '    End If
    '    If pstrJascd.Length <> 0 Then
    '        strSQL.Append("	  AND DT.ACBCD = :JASCD ")
    '    End If
    '    strSQL.Append("	  AND DT.HATKBN = :HATKBN ")
    '    ''�w�肳��Ă���Ώۊ��Ԃɉ����Ĕ������Ŕ�r���s��
    '    If pstrTrgFrom.Length > 0 And pstrTrgTo.Length > 0 Then
    '        strSQL.Append(" AND DT.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
    '    ElseIf pstrTrgFrom.Length > 0 And pstrTrgTo.Length = 0 Then
    '        strSQL.Append(" AND DT.HATYMD >= :TRGDATE_FROM ")
    '    ElseIf pstrTrgFrom.Length = 0 And pstrTrgTo.Length > 0 Then
    '        strSQL.Append(" AND DT.HATYMD <= :TRGDATE_TO ")
    '    End If

    '    If ind = 2 Then
    '        strSQL.Append(" AND ROWNUM <= " & pdecPageMax & " ")

    '        'ORDER BY
    '        strSQL.Append("	ORDER BY ")
    '        If pstrPgKbn = "1" Then
    '            strSQL.Append("DT.KURACD, ")
    '            strSQL.Append("DT.JACD, ")
    '            strSQL.Append("DT.HATYMD, ")
    '            strSQL.Append("DT.HATTIME, ")
    '            strSQL.Append("DT.ACBCD ")
    '        ElseIf pstrPgKbn = "2" Then
    '            strSQL.Append("DT.KURACD, ")
    '            strSQL.Append("HN.HAISO_CD, ")
    '            strSQL.Append("DT.HATYMD, ")
    '            strSQL.Append("DT.HATTIME, ")
    '            strSQL.Append("DT.ACBCD, ")
    '            strSQL.Append("DT.USER_CD ")
    '        Else
    '            strSQL.Append("DT.HATYMD, ")
    '            strSQL.Append("DT.HATTIME, ")
    '            strSQL.Append("DT.ACBCD, ")
    '            strSQL.Append("DT.USER_CD ")
    '        End If
    '    End If

    '    Return strSQL.ToString

    'End Function
    '*-----------------------------------------------------------*
    '2011.11.21 MOD H.Uema
    ' �����ǉ�(�����敪�F3�ǉ��ɔ���)
    '*-----------------------------------------------------------*
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                              ByVal pstrKuraCd As String, _
    '                              ByVal pstrKyoCd As String, _
    '                              ByVal pstrJaCdFr As String, _
    '                              ByVal pstrJaCdTo As String, _
    '                              ByVal pstrJasCdFr As String, _
    '                              ByVal pstrJasCdTo As String, _
    '                              ByVal pstrTrgFrom As String, _
    '                              ByVal pstrTrgTo As String, _
    '                              ByVal pstrPgKbn As String, _
    '                              ByVal pdecPageMax As Decimal) As String
    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                                ByVal pstrKuraCd As String, _
    '                                ByVal pstrKyoCd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrPgKbn As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrHatKbn As String) As String
    ''**********************************************************
    '' 2012/06/28 ADD W.GANEKO
    ''���O�f���o��
    ''�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    ''**********************************************************
    'Public Sub mlog(ByVal pstrString As String)
    '    Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
    '    Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
    '    Dim strPath As String = strLogPath & strFilnm & ".txt"
    '    Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
    '    If strLogFlg = "1" Then
    '        '�������݃t�@�C���ւ̃X�g���[��
    '        Dim outFile As New StreamWriter(strPath, True, System.Text.Encoding.Default)

    '        '�����̕�������X�g���[���ɏ�������
    '        outFile.Write(System.DateTime.Now & pstrString + vbCrLf)

    '        '�������t���b�V���i�t�@�C���������݁j
    '        outFile.Flush()

    '        '�t�@�C���N���[�Y
    '        outFile.Close()
    '    End If
    'End Sub
    '2017/02/15 H.Mori mod ���P2016 No9-1 START
    'Public Function fncMakeSelect(ByVal ind As Integer, _
    '                                ByVal pstrKuraCd As String, _
    '                                ByVal pstrKyoCd As String, _
    '                                ByVal pstrJaCdFr As String, _
    '                                ByVal pstrJaCdTo As String, _
    '                                ByVal pstrJasCdFr As String, _
    '                                ByVal pstrJasCdTo As String, _
    '                                ByVal pstrTrgFrom As String, _
    '                                ByVal pstrTrgTo As String, _
    '                                ByVal pstrPgKbn As String, _
    '                                ByVal pdecPageMax As Decimal, _
    '                                ByVal pstrHatKbn As String, _
    '                                ByVal pstrHanbaiCdFr As String, _
    '                                ByVal pstrHanbaiCdTo As String, _
    '                                ByVal pstrTaikbn As String, _
    '                                ByVal pstrHkkbn As String
    '                                ) As String
    '2015/11/04 w.ganeko 2015���P�J�� ��6 end
    Public Function fncMakeSelect(ByVal ind As Integer, _
                                ByVal pstrKuraCd As String, _
                                ByVal pstrKyoCd As String, _
                                ByVal pstrJaCdFr As String, _
                                ByVal pstrJaCdTo As String, _
                                ByVal pstrJasCdFr As String, _
                                ByVal pstrJasCdTo As String, _
                                ByVal pstrTrgFrom As String, _
                                ByVal pstrTrgTo As String, _
                                ByVal pstrPgKbn As String, _
                                ByVal pdecPageMax As Decimal, _
                                ByVal pstrHatKbn As String, _
                                ByVal pstrHanbaiCdFr As String, _
                                ByVal pstrHanbaiCdTo As String, _
                                ByVal pstrTaikbn As String, _
                                ByVal pstrHkkbn As String, _
                                ByVal pstrKikankbn As String, _
                                ByVal pstrTrgTimeFrom As String, _
                                ByVal pstrTrgTimeTo As String _
                                ) As String
        '2017/02/15 H.Mori mod ���P2016 No9-1 END
        Dim strSQL As New StringBuilder("")
        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
        Dim taiArry As String() = pstrTaikbn.Split(","c)
        Dim taiStr As String = ""
        For i As Integer = 0 To taiArry.Length - 1 Step 1
            If taiArry(i) <> "0" And taiArry(i) <> "" Then
                If taiStr <> "" Then
                    taiStr = taiStr & ","
                End If
                taiStr = taiStr & "'" & taiArry(i) & "'"
            End If
        Next
        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
        strSQL.Append("SELECT ")
        If ind = 1 Then
            strSQL.Append("COUNT(*) ")
        Else
            strSQL.Append("DT.KENNM, ")
            strSQL.Append("DT.KURACD, ")
            strSQL.Append("DT.KANSCD, ")
            strSQL.Append("DT.SYONO, ")             '2016/11/30 T.Ono add 2016���P�J�� ��12
            '20050730 NEC UPDATE START
            'strSQL.Append("HN.HAISO_CD, ")          '--JA�x���}�X�^�D�����Z���^�[�R�[�h
            strSQL.Append("HA.HAISO_CD, ")          '--�z���Z���^�}�X�^�D�����Z���^�[�R�[�h
            '20050730 NEC UPDATE END
            strSQL.Append("HA.NAME, ")              '--�z���Z���^�}�X�^�D�����Z���^�[��
            strSQL.Append("DT.JACD, ")
            strSQL.Append("DT.JANM, ")
            strSQL.Append("DT.ACBCD, ")
            strSQL.Append("DT.ACBNM, ")
            strSQL.Append("DT.ACBCD || DT.USER_CD AS JUYOKA, ")
            strSQL.Append("DT.JUSYONM, ")
            '2006/06/14 NEC UPDATE START
            'strSQL.Append("DT.JUTEL1 || DT.JUTEL2 AS JUTEL, ")
            strSQL.Append("DT.JUTEL1, ")
            strSQL.Append("DT.JUTEL2, ")
            '2006/06/14 NEC END
            strSQL.Append("DT.RENTEL, ")
            strSQL.Append("DT.ADDR, ")
            strSQL.Append("DT.HATKBN_NAI, ")
            strSQL.Append("DT.HATYMD, ")
            strSQL.Append("DT.HATTIME, ")
            strSQL.Append("DT.KEIHOSU, ")
            strSQL.Append("DT.RYURYO, ")
            '2020/11/01 T.Ono mod 2020�Ď����P Start
            '' 2015/01/05 H.Hosoda mod 2014���P�J�� No8,9 �ǉ��Ή� START
            ''strSQL.Append("DT.KMNM1, ")
            ''strSQL.Append("DT.KMNM2, ")
            ''strSQL.Append("DT.KMNM3, ")
            ''strSQL.Append("DT.KMNM4, ")
            ''strSQL.Append("DT.KMNM5, ")
            ''strSQL.Append("DT.KMNM6, ")
            'strSQL.Append("DECODE(DT.KMCD1,NULL,'',DT.KMNM1) AS KMNM1,")
            'strSQL.Append("DECODE(DT.KMCD2,NULL,'',DT.KMNM2) AS KMNM2,")
            'strSQL.Append("DECODE(DT.KMCD3,NULL,'',DT.KMNM3) AS KMNM3,")
            'strSQL.Append("DECODE(DT.KMCD4,NULL,'',DT.KMNM4) AS KMNM4,")
            'strSQL.Append("DECODE(DT.KMCD5,NULL,'',DT.KMNM5) AS KMNM5,")
            'strSQL.Append("DECODE(DT.KMCD6,NULL,'',DT.KMNM6) AS KMNM6,")
            '' 2015/01/05 H.Hosoda mod 2014���P�J�� No8,9 �ǉ��Ή� END
            strSQL.Append("DT.KMNM1, ")
            strSQL.Append("DT.KMNM2, ")
            strSQL.Append("DT.KMNM3, ")
            strSQL.Append("DT.KMNM4, ")
            strSQL.Append("DT.KMNM5, ")
            strSQL.Append("DT.KMNM6, ")
            '2020/11/01 T.Ono mod 2020�Ď����P StartEND
            strSQL.Append("DT.TMSKB_NAI, ")
            strSQL.Append("DT.SYOYMD, ")
            strSQL.Append("DT.SYOTIME, ")
            strSQL.Append("DT.TAITNM, ")
            strSQL.Append("DT.TAIOKBN_NAI, ")
            strSQL.Append("DT.TKTANCD_NM, ")
            strSQL.Append("DT.TFKINM, ")
            strSQL.Append("DT.TKIGNM, ")
            strSQL.Append("DT.TSADNM, ")
            '2006/06/14 NEC UPDATE START
            strSQL.Append("DT.SDNM, ")
            '2006/06/14 NEC UPDATE END
            strSQL.Append("DT.TFKICD, ")    '--- 2005/07/12 ADD Falcon
            '--- ��2005/05/21 ADD Falcon�� ---
            strSQL.Append("DT.FUK_MEMO, ")
            strSQL.Append("DT.AITNM, ")
            ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 START
            'strSQL.Append("DT.TSTANNM, ")
            strSQL.Append("DT.SYUTDTNM, ")
            ' 2015/02/12 H.Hosoda mod 2014���P�J�� No9 END
            strSQL.Append("DT.SADNM, ")
            strSQL.Append("DT.FKINM, ")
            'strSQL.Append("DT.ASENM, ") ' 2015/02/12 H.Hosoda del 2014���P�J�� No9
            strSQL.Append("DT.KIGNM, ")
            'strSQL.Append("DT.STANM, ") ' 2015/02/12 H.Hosoda del 2014���P�J�� No9
            strSQL.Append("DT.SDTBIK1, ")
            strSQL.Append("DT.SDTBIK2, ")
            '2006/06/14 NEC UPDATE START
            strSQL.Append("DT.SDTBIK3, ")
            strSQL.Append("DT.SIJI_BIKO1, ")
            '2006/06/14 NEC UPDATE END
            strSQL.Append("DT.SNTTOKKI, ")
            strSQL.Append("DT.STD_CD, ")
            '--- ��2005/05/21 ADD Falcon�� ---
            strSQL.Append("DT.TAIOKBN, ")       '--- 2005/05/26 ADD Falcon ---
            strSQL.Append("DT.TEL_MEMO1, ")
            strSQL.Append("DT.TEL_MEMO2, ")
            strSQL.Append("DT.TEL_MEMO4, ")         '2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("DT.TEL_MEMO5, ")         '2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("DT.TEL_MEMO6, ")         '2020/11/01 T.Ono add 2020�Ď����P
            ' 2015/02/12 H.Hosoda add 2014���P�J�� No8,9 START
            strSQL.Append("DT.SIJIYMD, ")
            strSQL.Append("DT.SIJITIME, ")
            strSQL.Append("DT.SDYMD, ")
            strSQL.Append("DT.SDTIME, ")
            strSQL.Append("DT.TYAKYMD, ")
            strSQL.Append("DT.TYAKTIME, ")
            strSQL.Append("DT.SYOKANYMD, ")
            strSQL.Append("DT.SYOKANTIME, ")
            strSQL.Append("DT.HANJICD, ")                  '2015/11/04 w.ganeko 2015���P�J�� ��6
            strSQL.Append("DT.HANJINM, ")                  '2015/11/04 w.ganeko 2015���P�J�� ��6
            ' 2015/02/12 H.Hosoda add 2014���P�J�� No8,9 END
            strSQL.Append("DT.KENSIN ") '2010/03/05 T.Watabe add
            strSQL.Append("FROM ")
            strSQL.Append("    D20_TAIOU DT, ")
            strSQL.Append("    HN2MAS HN, ")
            '20050730 NEC UPDATE START
            'strSQL.Append("HAIMAS HA ")
            strSQL.Append("    ( ")
            strSQL.Append("        SELECT J.CLI_CD,J.HAN_CD,H.HAISO_CD,H.NAME ")
            strSQL.Append("        FROM HN2MAS J,HAIMAS H ")
            strSQL.Append("        WHERE SUBSTR(J.CLI_CD,2,2)=H.KEN_CD AND J.HAISO_CD=H.HAISO_CD ")
            strSQL.Append("    ) HA ")
            '20050730 NEC UPDATE END
        End If
        'WHERE
        strSQL.Append("WHERE ")        '�d���͊܂܂Ȃ�
        '2015/11/04 w.ganeko 2015���P�J�� ��6 start
        'strSQL.Append("      DT.TAIOKBN<'3' ")        '�d���͊܂܂Ȃ�
        If taiStr.Length > 0 And taiStr <> "" Then
            strSQL.Append("      DT.TAIOKBN IN (" & taiStr & ")") '�d���͊܂܂Ȃ�
        Else
            strSQL.Append("      DT.TAIOKBN<'3'") '�d���͊܂܂Ȃ�
        End If
        '�̔����Ǝ�
        If pstrHanbaiCdFr.Length <> 0 Or pstrHanbaiCdTo.Length <> 0 Then
            'strSQL.Append("      AND EXISTS( ")
            'strSQL.Append("        SELECT 'X' FROM ")
            'strSQL.Append("          M10_HANJIGYOSYA M10, ")
            'strSQL.Append("          M09_JAGROUP M09, ")
            'strSQL.Append("          CLIMAS CL ")
            'strSQL.Append("         WHERE 1=1 ")
            'strSQL.Append("         AND M09.KURACD = CL.CLI_CD ")
            'strSQL.Append("         AND M10.GROUPCD = M09.GROUPCD ")
            'strSQL.Append("         AND CL.CLI_CD = M09.KURACD ")
            'strSQL.Append("         AND CL.CLI_CD = DT.KURACD ")
            'strSQL.Append("         AND M09.ACBCD = DT.ACBCD ")
            'strSQL.Append("      ) ")
            If pstrHanbaiCdFr.Length <> 0 Then strSQL.Append("	  AND DT.HANJICD >= :GROUPCDFR ")
            If pstrHanbaiCdTo.Length <> 0 Then strSQL.Append("	  AND DT.HANJICD <= :GROUPCDTO ")
        End If
        If pstrHkkbn.Length <> 0 And pstrHkkbn <> "0" Then
            strSQL.Append("      AND DT.FAXRUISEKIKBN = '" & pstrHkkbn & "' ")
        End If
        '2015/11/04 w.ganeko 2015���P�J�� ��6 end
        strSQL.Append("  AND DT.KURACD=HN.CLI_CD(+) ")
        strSQL.Append("  AND DT.ACBCD=HN.HAN_CD(+) ")
        '20050730 NEC UPDATE START
        'strSQL.Append("  AND SUBSTR(HN.CLI_CD,2,2)=HA.KEN_CD(+) ")
        'strSQL.Append("  AND HN.HAISO_CD=HA.HAISO_CD(+) ")
        strSQL.Append("  AND DT.KURACD=HA.CLI_CD(+) ")
        strSQL.Append("  AND DT.ACBCD=HA.HAN_CD(+) ")
        '20050730 NEC UPDATE END
        ' ��ʂ���̏����w��
        If pstrKuraCd.Length <> 0 Then
            strSQL.Append(" AND DT.KURACD = :KURACD ")
        End If
        If pstrKyoCd.Length <> 0 Then
            '20050730 NEC UPDATE START
            '�����Z���^�[���w�肳�ꂽ�Ƃ��͓�������
            'strSQL.Append("  AND :KYOCD=HN.HAISO_CD(+) ")
            strSQL.Append("  AND DT.KURACD=HA.CLI_CD ")
            strSQL.Append("  AND DT.ACBCD=HA.HAN_CD ")
            '20050730 NEC UPDATE END
            strSQL.Append("  AND :KYOCD=HA.HAISO_CD ")
        End If
        If pstrJaCdFr.Length <> 0 Then strSQL.Append("	  AND DT.JACD >= :JACDFR ")
        If pstrJaCdTo.Length <> 0 Then strSQL.Append("	  AND DT.JACD <= :JACDTO ")
        If pstrJasCdFr.Length <> 0 Then strSQL.Append("	  AND DT.ACBCD >= :JASCDFR ")
        If pstrJasCdTo.Length <> 0 Then strSQL.Append("	  AND DT.ACBCD <= :JASCDTO ")
        '2011.11.21 MODIFY H.Uema *-----------------------------------------* start
        'strSQL.Append("	  AND DT.HATKBN = :HATKBN ")
        If String.Compare("3", pstrHatKbn, True) <> 0 Then
            strSQL.Append("	  AND DT.HATKBN = :HATKBN ")
        Else
            strSQL.Append("   AND DT.HATKBN < :HATKBN ")
        End If
        '2011.11.21 MODIFY H.Uema *-----------------------------------------* end

        ' 2015/02/12 H.Hosoda mod 2014���P�J�� No8,9 �ǉ��Ή� START
        ''�w�肳��Ă���Ώۊ��Ԃɉ����Ĕ������Ŕ�r���s��
        'If pstrTrgFrom.Length > 0 And pstrTrgTo.Length > 0 Then
        '    strSQL.Append(" AND DT.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        'ElseIf pstrTrgFrom.Length > 0 And pstrTrgTo.Length = 0 Then
        '    strSQL.Append(" AND DT.HATYMD >= :TRGDATE_FROM ")
        'ElseIf pstrTrgFrom.Length = 0 And pstrTrgTo.Length > 0 Then
        '    strSQL.Append(" AND DT.HATYMD <= :TRGDATE_TO ")
        'End If
        ''�w�肳��Ă���Ώۊ��Ԃɉ����đΉ��������Ŕ�r���s��
        '2017/02/15 H.Mori mod ���P2016 No9-1 START
        'If pstrTrgFrom.Length > 0 And pstrTrgTo.Length > 0 Then
        '    strSQL.Append(" AND DT.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
        'ElseIf pstrTrgFrom.Length > 0 And pstrTrgTo.Length = 0 Then
        '    strSQL.Append(" AND DT.SYOYMD >= :TRGDATE_FROM ")
        'ElseIf pstrTrgFrom.Length = 0 And pstrTrgTo.Length > 0 Then
        '    strSQL.Append(" AND DT.SYOYMD <= :TRGDATE_TO ")
        'End If
        ' 2015/02/12 H.Hosoda mod 2014���P�J�� No8,9 �ǉ��Ή� END
        If pstrKikankbn = "1" Then '�Ή�������
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strSQL.Append(" AND DT.SYOYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strSQL.Append(" AND DT.SYOYMD || DT.SYOTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        Else                       '��M��
            If pstrTrgTimeFrom.Length = 0 AndAlso pstrTrgTimeTo.Length = 0 Then
                strSQL.Append(" AND DT.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO ")
            ElseIf pstrTrgTimeFrom.Length > 0 AndAlso pstrTrgTimeTo.Length > 0 Then
                strSQL.Append(" AND DT.HATYMD || DT.HATTIME BETWEEN :TRGDATE_FROM || :TRGTIME_FROM AND :TRGDATE_TO || :TRGTIME_TO ")
            End If
        End If
            '2017/02/15 H.Mori mod ���P2016 No9-1 END

            If ind = 2 Then
                'strSQL.Append(" AND ROWNUM <= " & pdecPageMax & " ") 2013/12/06 T.Ono del �Ď����P2013

                'ORDER BY
                strSQL.Append("	ORDER BY ")
                If pstrPgKbn = "1" Then
                    strSQL.Append("DT.KURACD, ")
                    strSQL.Append("DT.JACD, ")
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.ACBCD ")
                    '2015/11/04 w.ganeko 2015���P�J�� ��6 start
                    'ElseIf pstrPgKbn = "2" Then
                    '    strSQL.Append("DT.KURACD, ")
                    '    strSQL.Append("HN.HAISO_CD, ")
                    '    strSQL.Append("DT.HATYMD, ")
                    '    strSQL.Append("DT.HATTIME, ")
                    '    strSQL.Append("DT.ACBCD, ")
                    '    strSQL.Append("DT.USER_CD ")
                ElseIf pstrPgKbn = "2" Then
                    strSQL.Append("DT.KURACD, ")
                    strSQL.Append("DT.JACD, ")
                    strSQL.Append("DT.ACBCD, ")
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.USER_CD ")
                ElseIf pstrPgKbn = "3" Then
                    strSQL.Append("DT.KURACD, ")
                    strSQL.Append("DT.HANJICD, ")
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.ACBCD, ")
                    strSQL.Append("DT.USER_CD ")
                ElseIf pstrPgKbn = "4" Then
                    strSQL.Append("DT.KURACD, ")
                    strSQL.Append("HN.HAISO_CD, ")
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.ACBCD, ")
                    strSQL.Append("DT.USER_CD ")
                    '2015/11/04 w.ganeko 2015���P�J�� ��6 end
                Else
                    strSQL.Append("DT.HATYMD, ")
                    strSQL.Append("DT.HATTIME, ")
                    strSQL.Append("DT.ACBCD, ")
                    strSQL.Append("DT.USER_CD ")
                End If
            End If
            'mlog(strSQL.ToString)

            Return strSQL.ToString

    End Function

    ''''******************************************************************************
    ''''*�@�T�@�v:�r�d�k�d�b�s�����쐬
    ''''*�@���@�l:
    ''''******************************************************************************
    '''Public Function fncMakeSelect2(ByVal pstrKuracd As String, _
    '''                              ByVal pstrKyocd As String, _
    '''                              ByVal pstrJacd As String, _
    '''                              ByVal pstrJascd As String, _
    '''                              ByVal pstrTrgFrom As String, _
    '''                              ByVal pstrTrgTo As String) As String

    '''    Dim strSQL As New StringBuilder("")

    '''    'SELECT
    '''    strSQL.Append("SELECT ")
    '''    strSQL.Append(" TAI.KENNM AS KENNM, ")
    '''    strSQL.Append(" NOU.CENTNM AS CENTNM, ")
    '''    strSQL.Append(" NOU.ACBNM AS JANM, ")
    '''    strSQL.Append(" NOU.SISYONM AS SISYONM, ")
    '''    strSQL.Append(" NOU.ACBKETA AS ACBKETA, ")
    '''    strSQL.Append(" TAI.ACBCD AS ACBCD, ")
    '''    strSQL.Append(" TAI.HATKBN_NAI AS HATKBN_NAI, ")
    '''    strSQL.Append(" TAI.JUYOKA AS JUYOKA, ")
    '''    strSQL.Append(" TAI.JUSYONM AS JUSYONM, ")
    '''    strSQL.Append(" TAI.JUTEL AS JUTEL, ")
    '''    strSQL.Append(" TAI.RENTEL AS RENTEL, ")
    '''    strSQL.Append(" TAI.ADDR AS ADDR, ")
    '''    strSQL.Append(" TAI.HATYMD AS HATYMD, ")
    '''    strSQL.Append(" TAI.HATTIME AS HATTIME, ")
    '''    strSQL.Append(" TAI.KEIHOSU AS KEIHOSU, ")
    '''    strSQL.Append(" TAI.RYURYO AS RYURYO, ")
    '''    strSQL.Append(" TAI.KMNM1 AS KMNM1, ")
    '''    strSQL.Append(" TAI.KMNM2 AS KMNM2, ")
    '''    strSQL.Append(" TAI.KMNM3 AS KMNM3, ")
    '''    strSQL.Append(" TAI.KMNM4 AS KMNM4, ")
    '''    strSQL.Append(" TAI.KMNM5 AS KMNM5, ")
    '''    strSQL.Append(" TAI.KMNM6 AS KMNM6 , ")
    '''    strSQL.Append(" TAI.TMSKB AS TMSKB , ")
    '''    strSQL.Append(" TAI.TMSKB_NAI AS TMSKB_NAI, ")
    '''    strSQL.Append(" TAI.SYOYMD AS SYOYMD, ")
    '''    strSQL.Append(" TAI.SYOTIME AS SYOTIME, ")
    '''    strSQL.Append(" TAI.TAITNM AS TAITNM, ")
    '''    strSQL.Append(" TAI.TAIOKBN AS TAIOKBN, ")
    '''    strSQL.Append(" TAI.TAIOKBN_NAI AS TAIOKBN_NAI, ")
    '''    strSQL.Append(" TAI.TKTANCD_NM AS TKTANCD_NM, ")
    '''    strSQL.Append(" TAI.TFKINM AS TFKINM, ")
    '''    strSQL.Append(" TAI.TKIGNM AS TKIGNM, ")
    '''    strSQL.Append(" TAI.TSADNM AS TSADNM, ")
    '''    strSQL.Append(" TAI.TEL_MEMO1 AS TEL_MEMO1, ")
    '''    strSQL.Append(" TAI.TEL_MEMO2 AS TEL_MEMO2 ")

    '''    'FROM
    '''    strSQL.Append(" FROM ")
    '''    strSQL.Append(" (")
    '''    strSQL.Append(" SELECT NOU.KENCD,")
    '''    strSQL.Append("   NOU.ACBCD,")
    '''    strSQL.Append("   NOU.ACBNM,")
    '''    strSQL.Append("   NOU.SISYONM,")
    '''    strSQL.Append("   NOU.ACBKETA,")
    '''    strSQL.Append("   KYO.CENTNM ")
    '''    strSQL.Append("  FROM M03_NOKYO NOU,")
    '''    strSQL.Append("   M04_KYOKYU KYO ")
    '''    strSQL.Append("  WHERE NOU.KENCD=KYO.KENCD ")
    '''    strSQL.Append("    AND NOU.CENTCD=KYO.CENTCD ")
    '''    strSQL.Append(" ) NOU, ")
    '''    strSQL.Append(" D20_TAIOU TAI")

    '''    'WHERE
    '''    If pstrKuracd.Length <> 0 Then
    '''        strSQL.Append("	WHERE TAI.KENCD = :KENCD")
    '''    End If
    '''    If pstrKyocd.Length <> 0 Then
    '''        strSQL.Append("	  AND NOU.CENTCD LIKE :CENTCD || '%'")
    '''    End If
    '''    If pstrJacd.Length <> 0 Then
    '''        strSQL.Append("	  AND TAI.ACBCD LIKE :JACD || '%'")
    '''    End If
    '''    If pstrJascd.Length <> 0 Then
    '''        strSQL.Append("	  AND TAI.ACBCD = :JASCD")
    '''    End If
    '''    strSQL.Append("	  AND TAI.HATKBN = :HATKBN")
    '''    ''�w�肳��Ă���Ώۊ��Ԃɉ����Ĕ������Ŕ�r���s��
    '''    If pstrTrgFrom.Length > 0 And pstrTrgTo.Length > 0 Then
    '''        strSQL.Append(" AND TAI.HATYMD BETWEEN :TRGDATE_FROM AND :TRGDATE_TO")
    '''    ElseIf pstrTrgFrom.Length > 0 And pstrTrgTo.Length = 0 Then
    '''        strSQL.Append(" AND TAI.HATYMD >= :TRGDATE_FROM")
    '''    ElseIf pstrTrgFrom.Length = 0 And pstrTrgTo.Length > 0 Then
    '''        strSQL.Append(" AND TAI.HATYMD <= :TRGDATE_TO")
    '''    End If
    '''    strSQL.Append("	AND TAI.KENCD=NOU.KENCD(+)")
    '''    strSQL.Append("	AND TAI.ACBCD=NOU.ACBCD(+)")
    '''    '�d���͊܂܂Ȃ�
    '''    strSQL.Append("	AND TAI.TAIOKBN<'3'")

    '''    'ORDER BY
    '''    strSQL.Append("	ORDER BY ")
    '''    '2004/11/24 NEC UPDATE START
    '''    '���������Ƀ\�[�g
    '''    'strSQL.Append("	TAI.KENCD,")
    '''    'strSQL.Append("	TAI.ACBCD,")
    '''    'strSQL.Append("	TAI.JUYOKA")
    '''    strSQL.Append("	TAI.HATYMD,")
    '''    strSQL.Append("	TAI.HATTIME")
    '''    '2004/11/24 NEC UPDATE END

    '''    Return strSQL.ToString
    '''End Function
    '===========================================================
    ' �i�`�����c�a����擾 2015/01/23 T.Ono add 
    '===========================================================
    Private Function getDB2JaNm(ByVal cdb As CDB, ByVal clientCd As String, ByVal jaCd As String) As String

        Dim res As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim SQL As StringBuilder = New StringBuilder("")

        If clientCd.Length = 0 Then Return "" '���ނ���͂��̂܂܋�ŕԂ�
        If jaCd.Length = 0 Then Return "" '���ނ���͂��̂܂܋�ŕԂ�

        SQL.Append("SELECT JA_NAME FROM HN2MAS WHERE CLI_CD = '" & clientCd & "' AND  JA_CD = '" & jaCd & "'")
        Try
            cdb.pSQL = SQL.ToString
            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            End If
            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            res = Convert.ToString(dr.Item("JA_NAME"))

        Catch ex As Exception
        Finally
        End Try
        Return res
    End Function
    '===========================================================
    ' �i�`�E�i�`�x�������c�a����擾
    '===========================================================
    Private Function getDB2JasNm(ByVal cdb As CDB, ByVal clientCd As String, ByVal jasCd As String) As String

        Dim res As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim SQL As StringBuilder = New StringBuilder("")

        If clientCd.Length = 0 Then Return "" '���ނ���͂��̂܂܋�ŕԂ�
        If jasCd.Length = 0 Then Return "" '���ނ���͂��̂܂܋�ŕԂ�

        SQL.Append("SELECT JAS_NAME FROM HN2MAS WHERE CLI_CD = '" & clientCd & "' AND  HAN_CD = '" & jasCd & "'")
        Try
            cdb.pSQL = SQL.ToString
            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            End If
            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            res = Convert.ToString(dr.Item("JAS_NAME"))

        Catch ex As Exception
        Finally
        End Try
        Return res
    End Function

    '===========================================================
    ' �������c�a����擾
    '===========================================================
    Private Function getDB2KenNm(ByVal cdb As CDB, ByVal clientCd As String) As String

        Dim res As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim SQL As StringBuilder = New StringBuilder("")

        If clientCd.Length = 0 Then Return "" '���ނ���͂��̂܂܋�ŕԂ�

        SQL.Append("SELECT KEN_NAME FROM CLIMAS WHERE CLI_CD = '" & clientCd & "' ")
        Try
            cdb.pSQL = SQL.ToString
            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            End If
            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            res = Convert.ToString(dr.Item("KEN_NAME"))

        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Return res
    End Function

    ''===========================================================
    '' �N���C�A���g�����c�a����擾
    ''===========================================================
    'Private Function getDB2ClientNm(ByVal cdb As CDB, ByVal clientCd As String) As String

    '    Dim res As String
    '    Dim ds As New DataSet
    '    Dim dr As DataRow
    '    Dim SQL As StringBuilder

    '    If clientCd.Length = 0 Then Return "" '���ނ���͂��̂܂܋�ŕԂ�

    '    SQL.Append("SELECT CLI_NAME FROM CLIMAS WHERE CLI_CD = '" & clientCd & "' ")
    '    Try
    '        cdb.pSQL = SQL.ToString
    '        cdb.mExecQuery()    'SQL���s
    '        ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

    '        '�f�[�^�����݂��Ȃ��ꍇ
    '        If ds.Tables(0).Rows.Count = 0 Then
    '            Return ""      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
    '        End If
    '        dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
    '        res = Convert.ToString(dr.Item("CLI_NAME"))

    '    Catch ex As Exception
    '    Finally
    '    End Try
    '    Return res
    'End Function

    '===========================================================
    ' �������������c�a����擾
    '===========================================================
    Private Function getDB2CenterNm(ByVal cdb As CDB, ByVal kenCd As String, ByVal centerCd As String) As String

        Dim res As String
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim SQL As StringBuilder = New StringBuilder("")

        If kenCd.Length = 0 Then Return "" '���ނ���͂��̂܂܋�ŕԂ�
        If centerCd.Length = 0 Then Return "" '���ނ���͂��̂܂܋�ŕԂ�

        SQL.Append("SELECT NAME FROM HAIMAS WHERE KEN_CD = '" & kenCd & "' AND HAISO_CD = '" & centerCd & "' ")
        Try
            cdb.pSQL = SQL.ToString
            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            End If
            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            res = Convert.ToString(dr.Item("NAME"))

        Catch ex As Exception
        Finally
        End Try
        Return res
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
    End Sub

    '******************************************************************************
    '*�@�T�@�v�FS05_AUTOFAXLOGDB �ݐϏ�񎩓�FAX�̃��O���L�^����B
    '*�@���@�l�F
    '*  ��  ���F2016/11/30 T.Ono
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
    '*�@�T�@�v�FS05_AUTOFAXLOGDB ���O�̑O�񕪂��N���A����B
    '*�@���@�l�F2016/11/30���_�ł͖��g�p�B�f�o�b�O���s�@�\���Ȃ��̂ŁA�g�p���Ȃ��B
    '*        �F�g���Ƃ��́A���̃R�����g�������Ă��������B 
    '*  ��  ���F2016/11/30 T.Ono
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


End Class
