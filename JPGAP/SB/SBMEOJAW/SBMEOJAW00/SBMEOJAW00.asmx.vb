'******************************************************************************
' ��ʏ���Җ���o��
' PGID: SBMEOJAW00.asmx.vb
'******************************************************************************
'�ύX����
' 2019/01/11 T.Ono �V�K�쐬

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.IO
Imports NPOI.SS.UserModel
Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel
Imports NPOI.SS.Util.CellUtil

<System.Web.Services.WebService(Namespace:="http://tempuri.org/SBMEOJAW00/Service1")> _
Public Class SBMEOJAW00
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
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrNENDO As String,
                                        ByVal pstrKENCD As String,
                                        ByVal pstrKURACDFrom As String,
                                        ByVal pstrKURACDTo As String,
                                        ByVal pstrHANTENCDFrom As String,
                                        ByVal pstrHANTENCDTo As String,
                                        ByVal pstrFileType As String
                                        ) As String


        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim strRec As String = ""

        '�쐬�t�@�C���i�[�t�H���_
        'Dim strTempDir As String = "C:\inetpub\wwwroot\JPGAP\TEMP\00\SBMEOJAW00\"
        Dim strTempDir As String = ConfigurationSettings.AppSettings("SBMEOJAW_PATH")
        Dim strZipDirName As String = Now.ToString("yyyyMMddHHmmss")�@�@'�쐬����excel������t�H���_
        Dim strZipDirPath As String = strTempDir & strZipDirName & "\"  '�t�H���_�̃p�X

        '�t�H���_�쐬
        If File.Exists(strZipDirPath) = False Then
            System.IO.Directory.CreateDirectory(strZipDirPath)
        End If


        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally

        End Try

        '���[�o�͍��ڂ̎擾�pSQL���Z�b�g-------------------
        Try

            '���ރR�[�hNULL�̃f�[�^���邩�`�F�b�NSQL���Z�b�g
            If pstrFileType = "1" Then
                strSQL.Append(fncMakeChkSelect(pstrNENDO,
                                            pstrKENCD,
                                            pstrKURACDFrom,
                                            pstrKURACDTo,
                                            pstrHANTENCDFrom,
                                            pstrHANTENCDTo,
                                            pstrFileType))

                cdb.pSQL = strSQL.ToString

                '�p�����[�^�Z�b�g
                '�N�x
                cdb.pSQLParamStr("NENDO") = pstrNENDO.Trim
                '���R�[�h
                cdb.pSQLParamStr("KENCD") = pstrKENCD.Trim
                '�N���C�A���g�R�[�h
                If pstrKURACDFrom.Trim.Length > 0 Then
                    cdb.pSQLParamStr("KURACD_FROM") = pstrKURACDFrom.Trim
                End If
                If pstrKURACDTo.Trim.Length > 0 Then
                    cdb.pSQLParamStr("KURACD_TO") = pstrKURACDTo.Trim
                End If
                '�̔��X�R�[�h
                If pstrHANTENCDFrom.Trim.Length > 0 Then
                    cdb.pSQLParamStr("HANTENCD_FROM") = pstrHANTENCDFrom.Trim
                End If
                If pstrHANTENCDTo.Trim.Length > 0 Then
                    cdb.pSQLParamStr("HANTENCD_TO") = pstrHANTENCDTo.Trim
                End If

                cdb.mExecQuery()    'SQL���s
                ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

                '�f�[�^�����݂���ꍇ
                If ds.Tables(0).Rows.Count > 0 Then
                    Return "NULLEXIST"      '���ރR�[�hNULL�̃f�[�^����
                End If
            End If


            '���[�o�͍��ڂ̎擾�pSQL���Z�b�g
            strSQL.Clear()
            strSQL.Append(fncMakeSelect(pstrNENDO,
                                        pstrKENCD,
                                        pstrKURACDFrom,
                                        pstrKURACDTo,
                                        pstrHANTENCDFrom,
                                        pstrHANTENCDTo,
                                        pstrFileType))

            cdb.pSQL = strSQL.ToString

            '�p�����[�^�Z�b�g
            '�N�x
            cdb.pSQLParamStr("NENDO") = pstrNENDO.Trim
            '���R�[�h
            cdb.pSQLParamStr("KENCD") = pstrKENCD.Trim
            '�N���C�A���g�R�[�h
            If pstrKURACDFrom.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD_FROM") = pstrKURACDFrom.Trim
            End If
            If pstrKURACDTo.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD_TO") = pstrKURACDTo.Trim
            End If
            '�̔��X�R�[�h
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                cdb.pSQLParamStr("HANTENCD_FROM") = pstrHANTENCDFrom.Trim
            End If
            If pstrHANTENCDTo.Trim.Length > 0 Then
                cdb.pSQLParamStr("HANTENCD_TO") = pstrHANTENCDTo.Trim
            End If

            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            End If


            '���[�쐬
            Select Case pstrFileType
                Case "1"
                    '��ʏ���Җ���
                    strRec = IppansyohisyaOut(ds, dr, strZipDirPath)
                Case "2"
                    '�m�F�p���X�g
                    strRec = KakuninlistOut(ds, dr, strZipDirPath, pstrFileType)
                Case "3"
                    '���ׂ�
                    strRec = KakuninlistOut(ds, dr, strZipDirPath, pstrFileType)
            End Select

            If strRec.Substring(0, 5) = "ERROR" Then
                mlog(strRec)
                Return strRec
            End If


            '�ϐ��錾
            Dim strToDir As String = ""           '���k��t�@�C���̂���t�H���_
            Dim strToZipDir As String = ""        '���k����f�B���N�g��
            Dim strNihongoFileName As String = "" '���{��t�@�C�����̎w��(�p�����[�^[�Z�b�V����] + �d�b�ԍ�)
            Dim strFileName As String = ""        '���k���t�@�C����(FAX�pEXCEL�A���[���pZIP�t�@�C����)
            Dim strmadeFilename As String = ""    '���k��t�@�C����(�p�����[�^[�Z�b�V����])


            'Dim strZipFileName As String = "C:\inetpub\wwwroot\JPGAP\TEMP\00\SBMEOJAW00\DLFile.zip"
            Dim strZipFileName As String = strTempDir & strZipDirName & ".zip"


            Dim fastZip As New ICSharpCode.SharpZipLib.Zip.FastZip()

            fastZip.CreateEmptyDirectories = True

            fastZip.UseZip64 = ICSharpCode.SharpZipLib.Zip.UseZip64.Dynamic

            fastZip.CreateZip(strZipFileName, strZipDirPath, True, Nothing, Nothing)

            '���k����ZIP�t�@�C������߂�
            Return strZipFileName
            'mlog(pstrSESSION & "\" & pstrKANSI_CODE & "\" & pstrKURACD_F & "\" & pstrKURACD_T, "BTFAXJAX00:mExcelOut�F8")

        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�baba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function

    '******************************************************************************
    '*�@�T�@�v:�r�d�k�d�b�s�����쐬
    '*�@���@�l:��ʏ���Җ���̏ꍇ�̕��ރR�[�hNULL���R�[�h���`�F�b�N
    '******************************************************************************
    Public Function fncMakeChkSelect(ByVal pstrNENDO As String,
                      ByVal pstrKENCD As String,
                      ByVal pstrKURACDFrom As String,
                      ByVal pstrKURACDTo As String,
                      ByVal pstrHANTENCDFrom As String,
                      ByVal pstrHANTENCDTo As String,
                      ByVal pstrFileType As String) As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append("SELECT NENDO, ")
        strSQL.Append("       KURACD, ")
        strSQL.Append("       KENCD, ")
        strSQL.Append("       ACBCD, ")
        strSQL.Append("       USER_CD, ")
        strSQL.Append("       JUSYONM, ")
        strSQL.Append("       ADDR1, ")
        strSQL.Append("       ADDR2, ")
        strSQL.Append("       ADDR3, ")
        strSQL.Append("       ADDR, ")
        strSQL.Append("       RENTEL, ")
        strSQL.Append("       SYUTUTEL, ")
        strSQL.Append("       KESSEN, ")
        strSQL.Append("       DAIHYO_NAME, ")
        strSQL.Append("       KYOKTKBN, ")
        strSQL.Append("       HOKBN, ")
        strSQL.Append("       YOTOKBN, ")
        strSQL.Append("       BUNRUICD, ")
        strSQL.Append("       HANJICD, ")
        strSQL.Append("       HANJINM, ")
        strSQL.Append("       HANTENCD, ")
        strSQL.Append("       HANTENNM ")
        strSQL.Append("FROM   D30_MEIBO ")
        strSQL.Append("WHERE  1=1 ")
        strSQL.Append("AND    NENDO = :NENDO ")
        strSQL.Append("AND    KENCD = :KENCD ")
        strSQL.Append("AND    BUNRUICD IS NULL ")


        '2019/11/01 T.Ono mod �Ď����P2019 START
        '�I���p�^�[���ɂ���āASQL��ς���
        ''�N���C�A���g�R�[�h
        'If pstrKURACDFrom.Trim.Length > 0 Then
        '    strSQL.Append("AND    KURACD >= :KURACD_FROM ")
        'End If
        'If pstrKURACDTo.Trim.Length > 0 Then
        '    strSQL.Append("AND    KURACD <= :KURACD_TO ")
        'End If

        ''�̔��X�R�[�h
        'If pstrHANTENCDFrom.Trim.Length > 0 Then
        '    strSQL.Append("AND    HANTENCD >= :HANTENCD_FROM ")
        'End If
        'If pstrHANTENCDTo.Trim.Length > 0 Then
        '    strSQL.Append("AND    HANTENCD <= :HANTENCD_TO ")
        'End If

        If pstrKURACDFrom.Trim.Length > 0 Then
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                '�N���C�A���g���̔��X
                strSQL.Append("AND    KURACD || HANTENCD >= :KURACD_FROM || :HANTENCD_FROM ")
            Else
                '�N���C�A���g
                strSQL.Append("AND    KURACD >= :KURACD_FROM ")
            End If
        Else
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                '�̔��X
                strSQL.Append("AND    HANTENCD >= :HANTENCD_FROM ")
            End If
        End If

        If pstrKURACDTo.Trim.Length > 0 Then
            If pstrHANTENCDTo.Trim.Length > 0 Then
                '�N���C�A���g���̔��X
                strSQL.Append("AND    KURACD || HANTENCD <= :KURACD_TO || :HANTENCD_TO ")
            Else
                '�N���C�A���g
                strSQL.Append("AND    KURACD <= :KURACD_TO ")
            End If
        Else
            If pstrHANTENCDTo.Trim.Length > 0 Then
                '�̔��X
                strSQL.Append("AND    HANTENCD <= :HANTENCD_TO ")
            End If
        End If
        '2019/11/01 T.Ono mod �Ď����P2019 END

        Return strSQL.ToString

    End Function


    '******************************************************************************
    '*�@�T�@�v:�r�d�k�d�b�s�����쐬
    '*�@���@�l:
    '******************************************************************************
    Public Function fncMakeSelect(ByVal pstrNENDO As String,
                      ByVal pstrKENCD As String,
                      ByVal pstrKURACDFrom As String,
                      ByVal pstrKURACDTo As String,
                      ByVal pstrHANTENCDFrom As String,
                      ByVal pstrHANTENCDTo As String,
                      ByVal pstrFileType As String) As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append("SELECT NENDO, ")
        strSQL.Append("       KURACD, ")
        strSQL.Append("       KENCD, ")
        strSQL.Append("       ACBCD, ")
        strSQL.Append("       USER_CD, ")
        strSQL.Append("       JUSYONM, ")
        strSQL.Append("       ADDR1, ")
        strSQL.Append("       ADDR2, ")
        strSQL.Append("       ADDR3, ")
        strSQL.Append("       ADDR, ")
        strSQL.Append("       RENTEL, ")
        strSQL.Append("       SYUTUTEL, ")
        strSQL.Append("       KESSEN, ")
        strSQL.Append("       DAIHYO_NAME, ")
        strSQL.Append("       KYOKTKBN, ")
        strSQL.Append("       HOKBN, ")
        strSQL.Append("       YOTOKBN, ")
        strSQL.Append("       BUNRUICD, ")
        strSQL.Append("       HANJICD, ")
        strSQL.Append("       HANJINM, ")
        strSQL.Append("       HANTENCD, ")
        strSQL.Append("       HANTENNM ")
        strSQL.Append("FROM   D30_MEIBO ")
        strSQL.Append("WHERE  1=1 ")
        strSQL.Append("AND    NENDO = :NENDO ")
        strSQL.Append("AND    KENCD = :KENCD ")

        '2019/11/01 T.Ono mod �Ď����P2019 START
        '�I���p�^�[���ɂ���āASQL��ς���
        ''�N���C�A���g�R�[�h
        'If pstrKURACDFrom.Trim.Length > 0 Then
        '    strSQL.Append("AND    KURACD >= :KURACD_FROM ")
        'End If
        'If pstrKURACDTo.Trim.Length > 0 Then
        '    strSQL.Append("AND    KURACD <= :KURACD_TO ")
        'End If

        ''�̔��X�R�[�h
        'If pstrHANTENCDFrom.Trim.Length > 0 Then
        '    strSQL.Append("AND    HANTENCD >= :HANTENCD_FROM ")
        'End If
        'If pstrHANTENCDTo.Trim.Length > 0 Then
        '    strSQL.Append("AND    HANTENCD <= :HANTENCD_TO ")
        'End If

        If pstrKURACDFrom.Trim.Length > 0 Then
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                '�N���C�A���g���̔��X
                strSQL.Append("AND    KURACD || HANTENCD >= :KURACD_FROM || :HANTENCD_FROM ")
            Else
                '�N���C�A���g
                strSQL.Append("AND    KURACD >= :KURACD_FROM ")
            End If
        Else
            If pstrHANTENCDFrom.Trim.Length > 0 Then
                '�̔��X
                strSQL.Append("AND    HANTENCD >= :HANTENCD_FROM ")
            End If
        End If

        If pstrKURACDTo.Trim.Length > 0 Then
            If pstrHANTENCDTo.Trim.Length > 0 Then
                '�N���C�A���g���̔��X
                strSQL.Append("AND    KURACD || HANTENCD <= :KURACD_TO || :HANTENCD_TO ")
            Else
                '�N���C�A���g
                strSQL.Append("AND    KURACD <= :KURACD_TO ")
            End If
        Else
            If pstrHANTENCDTo.Trim.Length > 0 Then
                '�̔��X
                strSQL.Append("AND    HANTENCD <= :HANTENCD_TO ")
            End If
        End If
        '2019/11/01 T.Ono mod �Ď����P2019 END

        '�o�̓��X�g���̏�����order
        Select Case pstrFileType
            Case "1" '��ʏ���Җ���
                strSQL.Append("AND    BUNRUICD <> '9' ")
                strSQL.Append("ORDER BY HANJICD, BUNRUICD, HANTENCD, KENCD, KURACD, ACBCD, USER_CD ")
            Case "2" '�m�F���X�g
                strSQL.Append("AND    BUNRUICD IS NULL ")
                strSQL.Append("ORDER BY HANJICD, BUNRUICD, HANTENCD, KENCD, KURACD, ACBCD, USER_CD ")
            Case "3" '���ׂ�
                strSQL.Append("ORDER BY HANJICD, HANTENCD, BUNRUICD, KENCD, KURACD, ACBCD, USER_CD ")
        End Select

        Return strSQL.ToString

    End Function

    '******************************************************************************
    '*�@�T�@�v:EXCEL�o�́i��ʏ���Җ���j
    '*�@���@�l:
    '******************************************************************************
    Function IppansyohisyaOut(ByVal ds As DataSet, ByVal dr As DataRow, ByVal pZipFileDir As String) As String

        Dim book As IWorkbook = New XSSFWorkbook()
        Dim sheet1 As ISheet
        Dim wfs As FileStream
        Dim rows As IRow
        Dim style1 As ICellStyle '�w�b�_�p
        Dim style2 As ICellStyle '���חp

        Dim strFileName As String
        Dim strFilePath As String
        Dim strSheetName As String

        Dim strFileName_old As String = "0"
        Dim strHANTEN_old As String = "0"

        '���׃f�[�^�o��
        Dim iCnt As Integer = 0
        Dim isheet As Integer = 1
        Dim iRow As Integer = 0


        Try
            'AP�T�[�o����̖߂�l�����[�v����
            '�f�[�^�o��
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                'excel�t�@�C����
                If Convert.ToString(dr.Item("HANJICD")).Trim.Length > 0 Then
                    strFileName = Convert.ToString(dr.Item("HANJICD")) & "_" & Convert.ToString(dr.Item("BUNRUICD")) & ".xlsx"
                Else
                    strFileName = "HANJICDnull_" & Convert.ToString(dr.Item("KENCD")) & Convert.ToString(dr.Item("ACBCD")) & ".xlsx"

                End If
                strFileName = Convert.ToString(dr.Item("HANJICD")) & "_" & Convert.ToString(dr.Item("BUNRUICD")) & ".xlsx"

                '�V�K�t�@�C���쐬
                If strFileName <> strFileName_old Then

                    '����
                    If iCnt > 0 Then
                        book.Write(wfs)
                        wfs.Dispose()
                        book.Close()
                    End If

                    book = New XSSFWorkbook()
                    strFilePath = pZipFileDir & strFileName
                    wfs = New FileStream(strFilePath, FileMode.Create)
                    strFileName_old = strFileName '�����R�[�h�Ƃ̔�r�p

                    '�V�K�V�[�g�쐬
                    isheet = 1       '�V�[�g�ԍ�
                    If Convert.ToString(dr.Item("HANTENNM")).Trim.Length > 0 Then
                        strSheetName = Convert.ToString(dr.Item("HANTENNM"))
                        If strSheetName.Length > 25 Then
                            strSheetName = "(" & isheet & ")" & strSheetName.Substring(0, 25)
                        Else
                            strSheetName = "(" & isheet & ")" & strSheetName
                        End If

                        sheet1 = book.CreateSheet(strSheetName)  '�V�[�g�쐬
                    Else
                        sheet1 = book.CreateSheet("(" & isheet & ")" & "HANTENNMnull_" & Convert.ToString(dr.Item("HANTENCD")))  '�V�[�g�쐬
                    End If

                    strHANTEN_old = Convert.ToString(dr.Item("HANTENCD")) '�����R�[�h�Ƃ̔�r�p
                    iRow = 0          '�V�[�g�쐬������A�s�����Z�b�g

                    '�w�b�_�p����
                    style1 = book.CreateCellStyle()
                    style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center
                    style1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center
                    style1.WrapText = True

                    '���חp����
                    style2 = book.CreateCellStyle()
                    Dim format2 As IDataFormat = book.CreateDataFormat()
                    style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.ShrinkToFit = True
                    style2.DataFormat = format2.GetFormat("@") '������ IDataFormat�I�u�W�F�N�g������āAGetFormat�ŕ������short�^���擾����

                Else
                    '�V�K�V�[�g�쐬
                    If Convert.ToString(dr.Item("HANTENCD")) <> strHANTEN_old Then
                        isheet += 1          '�V�[�g�ԍ�
                        If Convert.ToString(dr.Item("HANTENNM")).Trim.Length > 0 Then
                            strSheetName = Convert.ToString(dr.Item("HANTENNM"))
                            If strSheetName.Length > 25 Then
                                strSheetName = "(" & isheet & ")" & strSheetName.Substring(0, 25)
                            Else
                                strSheetName = "(" & isheet & ")" & strSheetName
                            End If
                            sheet1 = book.CreateSheet(strSheetName)  '�V�[�g�쐬
                        Else
                            sheet1 = book.CreateSheet("(" & isheet & ")" & "HANTENNMnull_" & Convert.ToString(dr.Item("HANTENNM")))  '�V�[�g�쐬
                        End If

                        strHANTEN_old = Convert.ToString(dr.Item("HANTENCD")) '�����R�[�h�Ƃ̔�r�p
                        iRow = 0             '�V�[�g�쐬������A�s�����Z�b�g
                    End If
                End If


                '�w�b�_
                If iRow = 0 Then
                    rows = sheet1.CreateRow(0)
                    rows.CreateCell(0).SetCellValue("�P�D�ϑ��̔������F" & Convert.ToString(dr.Item("HANTENNM")))
                    sheet1.SetColumnWidth(0, 256 * 5) '1������256����1���P�ʁB���悻5�����B

                    rows = sheet1.CreateRow(1)
                    rows.CreateCell(0).SetCellValue("�Q�D������ƎҖ��F������Ђi�`-LP�K�X���Z���^�[")

                    If Convert.ToString(dr.Item("BUNRUICD")) = "1" OrElse Convert.ToString(dr.Item("BUNRUICD")) = "2" Then
                        rows = sheet1.CreateRow(2)
                        'rows.CreateCell(0).SetCellValue("�R�D�ۈ��Ɩ��敪�F�ً}�A����") 2019/05/09 T.Ono mod 
                        rows.CreateCell(0).SetCellValue("�R�D�ۈ��Ɩ��敪�F�ً}���A��")
                    Else
                        rows = sheet1.CreateRow(2)
                        rows.CreateCell(0).SetCellValue("�R�D�ۈ��Ɩ��敪�F")
                    End If

                    rows = sheet1.CreateRow(3)
                    rows.CreateCell(0).SetCellValue("�S�D��ʏ���ғ��̎����i�@�l�ɂ����Ă͖��̋y�ё�\�҂̎����j�A�Z���A�d�b�ԍ�")


                    rows = sheet1.CreateRow(5)
                    rows.CreateCell(0).SetCellValue("No.")
                    sheet1.GetRow(5).GetCell(0).CellStyle = style1
                    rows.CreateCell(1).SetCellValue("���R�[�h")
                    sheet1.SetColumnWidth(1, 256 * 8)
                    sheet1.GetRow(5).GetCell(1).CellStyle = style1
                    rows.CreateCell(2).SetCellValue("JA�x���R�[�h")
                    sheet1.SetColumnWidth(2, 256 * 12)
                    sheet1.GetRow(5).GetCell(2).CellStyle = style1
                    rows.CreateCell(3).SetCellValue("���q�l�R�[�h")
                    sheet1.SetColumnWidth(3, 256 * 12)
                    sheet1.GetRow(5).GetCell(3).CellStyle = style1
                    rows.CreateCell(4).SetCellValue("��ʏ���ғ���" & vbLf & "�����E����")
                    sheet1.SetColumnWidth(4, 256 * 21)
                    sheet1.GetRow(5).GetCell(4).CellStyle = style1
                    rows.CreateCell(5).SetCellValue("��\�Җ�")
                    sheet1.SetColumnWidth(5, 256 * 21)
                    sheet1.GetRow(5).GetCell(5).CellStyle = style1
                    rows.CreateCell(6).SetCellValue("�Z��")
                    sheet1.SetColumnWidth(6, 256 * 35)
                    sheet1.GetRow(5).GetCell(6).CellStyle = style1
                    rows.CreateCell(7).SetCellValue("�d�b�ԍ�")
                    sheet1.SetColumnWidth(7, 256 * 15)
                    sheet1.GetRow(5).GetCell(7).CellStyle = style1
                    rows.CreateCell(8).SetCellValue("���l")
                    sheet1.SetColumnWidth(8, 256 * 10)
                    sheet1.GetRow(5).GetCell(8).CellStyle = style1

                    '�ꕔ��\��
                    sheet1.SetColumnHidden(1, True)
                    sheet1.SetColumnHidden(2, True)
                    sheet1.SetColumnHidden(3, True)

                    iRow = 6
                End If

                '���׍s
                rows = sheet1.CreateRow(iRow)
                rows.CreateCell(0).SetCellValue(iRow - 5)
                sheet1.GetRow(iRow).GetCell(0).CellStyle = style2
                rows.CreateCell(1).SetCellValue(Convert.ToString(dr.Item("KENCD")))
                sheet1.GetRow(iRow).GetCell(1).CellStyle = style2
                rows.CreateCell(2).SetCellValue(Convert.ToString(dr.Item("ACBCD")))
                sheet1.GetRow(iRow).GetCell(2).CellStyle = style2
                rows.CreateCell(3).SetCellValue(Convert.ToString(dr.Item("USER_CD")))
                sheet1.GetRow(iRow).GetCell(3).CellStyle = style2
                rows.CreateCell(4).SetCellValue(Convert.ToString(dr.Item("JUSYONM")))
                sheet1.GetRow(iRow).GetCell(4).CellStyle = style2
                rows.CreateCell(5).SetCellValue(Convert.ToString(dr.Item("DAIHYO_NAME")))
                sheet1.GetRow(iRow).GetCell(5).CellStyle = style2
                rows.CreateCell(6).SetCellValue(Convert.ToString(dr.Item("ADDR")))
                sheet1.GetRow(iRow).GetCell(6).CellStyle = style2
                rows.CreateCell(7).SetCellValue(Convert.ToString(dr.Item("SYUTUTEL")))
                sheet1.GetRow(iRow).GetCell(7).CellStyle = style2
                rows.CreateCell(8).SetCellValue(Convert.ToString(dr.Item("KESSEN")))
                sheet1.GetRow(iRow).GetCell(8).CellStyle = style2

                iRow += 1
            Next

            book.Write(wfs)

            wfs.Dispose()
            book.Close()

            Return "OK!!!"

        Catch ex As Exception
            Return "ERROR:" & "IppansyohisyaOut:" & ex.Message

        Finally
            wfs.Dispose()
            book.Close()
        End Try
    End Function

    '******************************************************************************
    '*�@�T�@�v:EXCEL�o�́i�m�F�p���X�g�j
    '*�@���@�l:
    '******************************************************************************
    Function KakuninlistOut(ByVal ds As DataSet, ByVal dr As DataRow, ByVal pZipFileDir As String, ByVal pFileType As String) As String

        Dim book As IWorkbook = New XSSFWorkbook()
        Dim sheet1 As ISheet
        Dim wfs As FileStream
        Dim rows As IRow
        Dim cells As ICell

        Dim strFileName As String
        Dim strFilePath As String
        Dim strSheetName As String

        Dim strFileName_old As String = "0"
        Dim strHANTEN_old As String = "0"

        '���׃f�[�^�o��
        Dim iCnt As Integer = 0
        Dim isheet As Integer = 1
        Dim iRow As Integer = 0


        '�Z���̏����ݒ�@ICellStyle���`���Ċe�Z���ɓK�p����
        '�r������i�ׂ��g�j
        Dim style1 As ICellStyle
        '�w�i�F���F
        Dim style2 As ICellStyle
        '���חp
        Dim style3 As ICellStyle
        Dim format3 As IDataFormat


        Try
            'AP�T�[�o����̖߂�l�����[�v����
            '�f�[�^�o��
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                'excel�t�@�C����
                strFileName = Convert.ToString(dr.Item("HANJICD")) & ".xlsx"

                '�V�K�t�@�C���쐬
                If strFileName <> strFileName_old Then

                    '����
                    If iCnt > 0 Then
                        book.Write(wfs)
                        wfs.Dispose()
                        book.Close()
                    End If

                    book = New XSSFWorkbook()
                    strFilePath = pZipFileDir & strFileName
                    wfs = New FileStream(strFilePath, FileMode.Create)
                    strFileName_old = strFileName '�����R�[�h�Ƃ̔�r�p

                    '�V�K�V�[�g�쐬
                    isheet = 1       '�V�[�g�ԍ�
                    If Convert.ToString(dr.Item("HANTENNM")).Trim.Length > 0 Then
                        strSheetName = Convert.ToString(dr.Item("HANTENNM"))
                        If strSheetName.Length > 25 Then
                            strSheetName = "(" & isheet & ")" & strSheetName.Substring(0, 25)
                        Else
                            strSheetName = "(" & isheet & ")" & strSheetName
                        End If
                        sheet1 = book.CreateSheet(strSheetName)  '�V�[�g�쐬
                    Else
                        sheet1 = book.CreateSheet("HANTENNMnull_" & Convert.ToString(dr.Item("HANTENNM")))  '�V�[�g�쐬
                    End If

                    strHANTEN_old = Convert.ToString(dr.Item("HANTENCD")) '�����R�[�h�Ƃ̔�r�p
                    iRow = 0          '�V�[�g�쐬������A�s�����Z�b�g

                    '�Z���̏����ݒ�@ICellStyle���`���Ċe�Z���ɓK�p����
                    '�r������i�ׂ��g�j
                    style1 = book.CreateCellStyle()
                    style1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin

                    '�w�i�F���F
                    style2 = book.CreateCellStyle()
                    style2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                    style2.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground
                    style2.FillForegroundColor = NPOI.SS.UserModel.IndexedColors.Yellow.Index

                    '���חp
                    style3 = book.CreateCellStyle()
                    format3 = book.CreateDataFormat()
                    style3.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin
                    style3.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin
                    style3.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin
                    style3.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin
                    style3.ShrinkToFit = True
                    style3.DataFormat = format3.GetFormat("@") '������ IDataFormat�I�u�W�F�N�g������āAGetFormat�ŕ������short�^���擾����


                Else
                    '�V�K�V�[�g�쐬
                    If Convert.ToString(dr.Item("HANTENCD")) <> strHANTEN_old Then
                        isheet += 1          '�V�[�g�ԍ�
                        If Convert.ToString(dr.Item("HANTENNM")).Trim.Length > 0 Then
                            strSheetName = Convert.ToString(dr.Item("HANTENNM"))
                            If strSheetName.Length > 25 Then
                                strSheetName = "(" & isheet & ")" & strSheetName.Substring(0, 25)
                            Else
                                strSheetName = "(" & isheet & ")" & strSheetName
                            End If
                            sheet1 = book.CreateSheet(strSheetName)  '�V�[�g�쐬
                        Else
                            sheet1 = book.CreateSheet("(" & isheet & ")" & "HANTENNMnull_" & Convert.ToString(dr.Item("HANTENCD")))  '�V�[�g�쐬
                        End If

                        strHANTEN_old = Convert.ToString(dr.Item("HANTENCD")) '�����R�[�h�Ƃ̔�r�p
                        iRow = 0             '�V�[�g�쐬������A�s�����Z�b�g
                    End If
                End If


                '�w�b�_�s
                If iRow = 0 Then
                    rows = sheet1.CreateRow(iRow)
                    rows.CreateCell(0).SetCellValue("�ײ��ĺ���")
                    sheet1.SetColumnWidth(0, 256 * 12) '1������256����1���P�ʁB���悻12�����B
                    sheet1.GetRow(iRow).GetCell(0).CellStyle = style1
                    rows.CreateCell(1).SetCellValue("JA�x������")
                    sheet1.SetColumnWidth(1, 256 * 12)
                    sheet1.GetRow(iRow).GetCell(1).CellStyle = style1
                    rows.CreateCell(2).SetCellValue("���q�l����")
                    sheet1.SetColumnWidth(2, 256 * 12)
                    sheet1.GetRow(iRow).GetCell(2).CellStyle = style1
                    rows.CreateCell(3).SetCellValue("���q�l����")
                    sheet1.SetColumnWidth(3, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(3).CellStyle = style1
                    rows.CreateCell(4).SetCellValue("�@�l��\�Ҏ���")
                    sheet1.SetColumnWidth(4, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(4).CellStyle = style1
                    rows.CreateCell(5).SetCellValue("�Z���P")
                    sheet1.SetColumnWidth(5, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(5).CellStyle = style1
                    rows.CreateCell(6).SetCellValue("�Z���Q")
                    sheet1.SetColumnWidth(6, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(6).CellStyle = style1
                    rows.CreateCell(7).SetCellValue("�Z���R")
                    sheet1.SetColumnWidth(7, 256 * 21)
                    sheet1.GetRow(iRow).GetCell(7).CellStyle = style1
                    rows.CreateCell(8).SetCellValue("�A���d�b�ԍ�")
                    sheet1.SetColumnWidth(8, 256 * 12)
                    sheet1.GetRow(iRow).GetCell(8).CellStyle = style1
                    rows.CreateCell(9).SetCellValue("����/������")
                    sheet1.SetColumnWidth(9, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(9).CellStyle = style1
                    rows.CreateCell(10).SetCellValue("�����`�ԋ敪")
                    sheet1.SetColumnWidth(10, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(10).CellStyle = style1
                    rows.CreateCell(11).SetCellValue("�K�p�@�ߋ敪")
                    sheet1.SetColumnWidth(11, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(11).CellStyle = style1
                    rows.CreateCell(12).SetCellValue("�p�r�敪")
                    sheet1.SetColumnWidth(12, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(12).CellStyle = style1
                    rows.CreateCell(13).SetCellValue("���ރR�[�h")
                    sheet1.SetColumnWidth(13, 256 * 10)
                    sheet1.GetRow(iRow).GetCell(13).CellStyle = style1

                    '�m�F�p���X�g�͈ꕔ��\���A�w�i�F����
                    If pFileType = "2" Then
                        sheet1.SetColumnHidden(9, True)
                        sheet1.SetColumnHidden(10, True)
                        sheet1.SetColumnHidden(11, True)
                        sheet1.SetColumnHidden(12, True)
                        sheet1.GetRow(0).GetCell(4).CellStyle = style2
                        sheet1.GetRow(0).GetCell(13).CellStyle = style2
                    End If

                    iRow += 1
                End If

                '���׍s
                rows = sheet1.CreateRow(iRow)
                rows.CreateCell(0).SetCellValue(Convert.ToString(dr.Item("KURACD")))
                sheet1.GetRow(iRow).GetCell(0).CellStyle = style3
                rows.CreateCell(1).SetCellValue(Convert.ToString(dr.Item("ACBCD")))
                sheet1.GetRow(iRow).GetCell(1).CellStyle = style3
                rows.CreateCell(2).SetCellValue(Convert.ToString(dr.Item("USER_CD")))
                sheet1.GetRow(iRow).GetCell(2).CellStyle = style3
                rows.CreateCell(3).SetCellValue(Convert.ToString(dr.Item("JUSYONM")))
                sheet1.GetRow(iRow).GetCell(3).CellStyle = style3
                rows.CreateCell(4).SetCellValue(Convert.ToString(dr.Item("DAIHYO_NAME")))
                sheet1.GetRow(iRow).GetCell(4).CellStyle = style3
                rows.CreateCell(5).SetCellValue(Convert.ToString(dr.Item("ADDR1")))
                sheet1.GetRow(iRow).GetCell(5).CellStyle = style3
                rows.CreateCell(6).SetCellValue(Convert.ToString(dr.Item("ADDR2")))
                sheet1.GetRow(iRow).GetCell(6).CellStyle = style3
                rows.CreateCell(7).SetCellValue(Convert.ToString(dr.Item("ADDR3")))
                sheet1.GetRow(iRow).GetCell(7).CellStyle = style3
                rows.CreateCell(8).SetCellValue(Convert.ToString(dr.Item("RENTEL")))
                sheet1.GetRow(iRow).GetCell(8).CellStyle = style3
                rows.CreateCell(9).SetCellValue(Convert.ToString(dr.Item("KESSEN")))
                sheet1.GetRow(iRow).GetCell(9).CellStyle = style3
                rows.CreateCell(10).SetCellValue(Convert.ToString(dr.Item("KYOKTKBN")))
                sheet1.GetRow(iRow).GetCell(10).CellStyle = style3
                rows.CreateCell(11).SetCellValue(Convert.ToString(dr.Item("HOKBN")))
                sheet1.GetRow(iRow).GetCell(11).CellStyle = style3
                rows.CreateCell(12).SetCellValue(Convert.ToString(dr.Item("YOTOKBN")))
                sheet1.GetRow(iRow).GetCell(12).CellStyle = style3
                rows.CreateCell(13).SetCellValue(Convert.ToString(dr.Item("BUNRUICD")))
                sheet1.GetRow(iRow).GetCell(13).CellStyle = style3

                iRow += 1
            Next

            book.Write(wfs)

            wfs.Dispose()
            book.Close()

            Return "OK!!!" '5�����Ԃ��Ȃ���substring�ŃG���[�ɂȂ�

        Catch ex As Exception
            Return "ERROR:" & "KakuninlistOut:" & pFileType & ":" & ex.Message

        Finally
            wfs.Dispose()
            book.Close()
        End Try
    End Function

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
