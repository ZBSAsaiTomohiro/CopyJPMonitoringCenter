'******************************************************************************
' ���q�l�����o��
' PGID: MSKOSJAW00.asmx.vb
'******************************************************************************
'�ύX����
' 2017/02/06 W.GANEKO 2016�Ď����P

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSKOSJAW00/Service1")> _
Public Class MSKOSJAW00
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
    '*�@���@�l:2019/11/01 T.Ono mod �Ď����P2019 No1 CLI_CD_TO,JA_CD_CLI,HAN_CD_CLI,HAN_CD_TO_CLI�ǉ��AKINREN_GRP�폜
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    <WebMethod()> Public Function mExcel(
                                        ByVal pstrSessionID As String,
                                        ByVal pstrKANSCD As String,
                                        ByVal pstrTEL As String,
                                        ByVal pstrNAME As String,
                                        ByVal pstrADDR As String,
                                        ByVal pstrCLI_CD As String,
                                        ByVal pstrCLI_CD_TO As String,
                                        ByVal pstrJA_CD As String,
                                        ByVal pstrJA_CD_CLI As String,
                                        ByVal pstrHAN_GRP As String,
                                        ByVal pstrHAN_CD As String,
                                        ByVal pstrHAN_CD_CLI As String,
                                        ByVal pstrHAN_CD_TO As String,
                                        ByVal pstrHAN_CD_TO_CLI As String,
                                        ByVal pstrUSER_CD As String,
                                        ByVal pstrUSER_FLG0 As String,
                                        ByVal pstrUSER_FLG1 As String,
                                        ByVal pstrUSER_FLG2 As String,
                                        ByVal pstrHANBAI_KBN1 As String,
                                        ByVal pstrHANBAI_KBN2 As String,
                                        ByVal pstrHANBAI_KBN3 As String,
                                        ByVal pstrHANBAI_KBN4 As String,
                                        ByVal pstrHANBAI_KBN5 As String,
                                        ByVal pstrHANBAI_KBN6 As String
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim intGyoMax As Integer = 65535                '�ő�s��
        Dim ExcelC As New CExcel                        'Excel�N���X
        Dim compressC As New CCompress                  '���k�N���X
        Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
        Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
        Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
        Dim strHedInfo As String                        '�w�b�_�[���i���o�����j
        Dim strHedInfoHanbai As String                  '�w�b�_�[���i���o�����j
        Dim strHedInfoUserFlg As String                 '�w�b�_�[���i���o�����j
        Dim intPrntRow As Integer = 72
        Dim overFlg As String = "0"

        Dim i As Integer
        Dim cntExcel As Integer


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
            '2019/11/01 T.Ono mod �Ď����P2019 No1
            'strSQL.Append(fncMakeSelect(pstrKANSCD,
            '                      pstrTEL,
            '                      pstrNAME,
            '                      pstrADDR,
            '                      pstrCLI_CD,
            '                      pstrCLI_CD_TO,
            '                      pstrJA_CD,
            '                      pstrHAN_GRP,
            '                      pstrKINREN_GRP,
            '                      pstrHAN_CD,
            '                      pstrHAN_CD_TO,
            '                      pstrUSER_CD,
            '                      pstrUSER_FLG0,
            '                      pstrUSER_FLG1,
            '                      pstrUSER_FLG2,
            '                      pstrHANBAI_KBN1,
            '                      pstrHANBAI_KBN2,
            '                      pstrHANBAI_KBN3,
            '                      pstrHANBAI_KBN4,
            '                      pstrHANBAI_KBN5,
            '                      pstrHANBAI_KBN6
            '                      ))

            strSQL.Append(fncMakeSelect(pstrKANSCD,
                                  pstrTEL,
                                  pstrNAME,
                                  pstrADDR,
                                  pstrCLI_CD,
                                  pstrCLI_CD_TO,
                                  pstrJA_CD,
                                  pstrJA_CD_CLI,
                                  pstrHAN_GRP,
                                  pstrHAN_CD,
                                  pstrHAN_CD_CLI,
                                  pstrHAN_CD_TO,
                                  pstrHAN_CD_TO_CLI,
                                  pstrUSER_CD,
                                  pstrUSER_FLG0,
                                  pstrUSER_FLG1,
                                  pstrUSER_FLG2,
                                  pstrHANBAI_KBN1,
                                  pstrHANBAI_KBN2,
                                  pstrHANBAI_KBN3,
                                  pstrHANBAI_KBN4,
                                  pstrHANBAI_KBN5,
                                  pstrHANBAI_KBN6
                                  ))

            cdb.pSQL = strSQL.ToString
            '�p�����[�^�̃Z�b�g
            If pstrKANSCD.Length > 0 Then
                cdb.pSQLParamStr("KANSCD") = pstrKANSCD
            End If
            If pstrTEL.Length > 0 Then
                cdb.pSQLParamStr("TEL") = pstrTEL & "%"
            End If
            If pstrNAME.Length > 0 Then
                cdb.pSQLParamStr("NAME") = pstrNAME & "%"
            End If
            If pstrADDR.Length > 0 Then
                cdb.pSQLParamStr("ADDR") = pstrADDR & "%"
            End If

            '2019/11/01 T.Ono mod �Ď����P2019 START
            'If pstrCLI_CD.Length > 0 Then
            '    cdb.pSQLParamStr("CLI_CD") = pstrCLI_CD
            'End If
            'If pstrJA_CD.Length > 0 Then
            '    cdb.pSQLParamStr("JA_CD") = pstrJA_CD & "%"
            'End If
            If pstrJA_CD.Length > 0 Then
                cdb.pSQLParamStr("JA_CD") = pstrJA_CD & "%"
                cdb.pSQLParamStr("CLI_CD") = pstrJA_CD_CLI
                cdb.pSQLParamStr("CLI_CD_TO") = pstrJA_CD_CLI
            Else
                If pstrCLI_CD.Length > 0 Then
                    cdb.pSQLParamStr("CLI_CD") = pstrCLI_CD
                End If
                If pstrCLI_CD_TO.Length > 0 Then
                    cdb.pSQLParamStr("CLI_CD_TO") = pstrCLI_CD_TO
                End If
            End If
            '2019/11/01 T.Ono mod �Ď����P2019 END

            If pstrHAN_GRP.Length > 0 Then
                cdb.pSQLParamStr("HAN_GRP") = pstrHAN_GRP
                cdb.pSQLParamStr("HAN_GRP_KBN") = "001"
            End If
            '2019/11/01 T.Ono del �Ď����P2019
            'If pstrKINREN_GRP.Length > 0 Then
            '    cdb.pSQLParamStr("HAN_GRP") = pstrKINREN_GRP
            '    cdb.pSQLParamStr("HAN_GRP_KBN") = "002"
            'End If
            If pstrHAN_CD.Length > 0 Then
                cdb.pSQLParamStr("HAN_CD") = pstrHAN_CD
                cdb.pSQLParamStr("HAN_CD_TO") = pstrHAN_CD_TO
                '2019/11/01 T.Ono add �Ď����P2019
                cdb.pSQLParamStr("HAN_CD_CLI") = pstrHAN_CD_CLI
                cdb.pSQLParamStr("HAN_CD_TO_CLI") = pstrHAN_CD_TO_CLI
            End If
            If pstrUSER_CD.Length > 0 Then
                cdb.pSQLParamStr("USER_CD") = pstrUSER_CD & "%"
            End If
            If pstrUSER_FLG0 = "0" Then
                cdb.pSQLParamStr("USER_FLG0") = ""
            Else
                cdb.pSQLParamStr("USER_FLG0") = "0"
            End If
            If pstrUSER_FLG1 = "0" Then
                cdb.pSQLParamStr("USER_FLG1") = ""
            Else
                cdb.pSQLParamStr("USER_FLG1") = "1"
            End If
            If pstrUSER_FLG2 = "0" Then
                cdb.pSQLParamStr("USER_FLG2") = ""
            Else
                cdb.pSQLParamStr("USER_FLG2") = "2"
            End If

            '�`�F�b�N�{�b�N�X�@0�F�`�F�b�N�Ȃ��@1�F�`�F�b�N����
            '�̔��敪�@1�F���[�^���@2�F�{���x���@3�F�����@4�F���̑��@5�F�f�[�^�Ȃ��@6�F��O
            If pstrHANBAI_KBN1 = "1" AndAlso pstrHANBAI_KBN2 = "1" AndAlso pstrHANBAI_KBN3 = "1" AndAlso
                pstrHANBAI_KBN4 = "1" AndAlso pstrHANBAI_KBN5 = "1" AndAlso pstrHANBAI_KBN6 = "1" Then
            Else
                If pstrHANBAI_KBN1 = "1" OrElse pstrHANBAI_KBN2 = "1" OrElse pstrHANBAI_KBN3 = "1" OrElse
                   pstrHANBAI_KBN4 = "1" Then
                    If pstrHANBAI_KBN1 = "1" Then
                        cdb.pSQLParamStr("HANBAI_KBN1") = "1"
                    Else
                        cdb.pSQLParamStr("HANBAI_KBN1") = ""
                    End If
                    If pstrHANBAI_KBN2 = "1" Then
                        cdb.pSQLParamStr("HANBAI_KBN2") = "2"
                    Else
                        cdb.pSQLParamStr("HANBAI_KBN2") = ""
                    End If
                    If pstrHANBAI_KBN3 = "1" Then
                        cdb.pSQLParamStr("HANBAI_KBN3") = "3"
                    Else
                        cdb.pSQLParamStr("HANBAI_KBN3") = ""
                    End If
                    If pstrHANBAI_KBN4 = "1" Then
                        cdb.pSQLParamStr("HANBAI_KBN4") = "4"
                    Else
                        cdb.pSQLParamStr("HANBAI_KBN4") = ""
                    End If
                End If
            End If


            cdb.mExecQuery()    'SQL���s
            ds = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

            '�f�[�^�����݂��Ȃ��ꍇ
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"      '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
            End If

            dr = ds.Tables(0).Rows(0)           '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
            ExcelC.pKencd = "00"                '�N���C�A���g�R�[�h���Z�b�g
            ExcelC.pSessionID = pstrSessionID   '�Z�b�V����ID
            ExcelC.pRepoID = "MSKOSJAW00"       '���[ID
            ExcelC.mOpen()                      '�t�@�C���I�[�v��

            ExcelC.pTitle = "���q�l�������ʃ��X�g"                      '�^�C�g��
            ExcelC.pDate = DateFncC.mGet(Now.ToString("yyyyMMdd"))  '�쐬��
            'ExcelC.pScale = 93                                      '�k���g�嗦(%)
            ExcelC.pScale = 70                                      '�k���g�嗦(%)

            '�������
            ExcelC.pLandScape = True ' true:��
            '�]��
            ExcelC.pMarginTop = 2D
            ExcelC.pMarginBottom = 0.6D
            ExcelC.pMarginLeft = 1.5D
            ExcelC.pMarginRight = 1D
            ExcelC.pMarginHeader = 1.3D
            ExcelC.pMarginFooter = 1.3D

            '�w�b�_���ڂ��Z�b�g�B�i1�y�[�W������s���A�o�͍s���A�擪�s���牽�s�ڂ܂ł��s�^�C�g�����j
            ExcelC.mHeader(-1, ds.Tables(0).Rows.Count, 1)
            i = 1
            '���o����1�s��
            strHedInfo = ""
            If pstrKANSCD.Length > 0 Then
                strHedInfo = "�Ď��Z���^�[:" & pstrKANSCD
            End If
            If pstrCLI_CD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                '2019/11/01 T.Ono mod �Ď����P2019 No1
                'strHedInfo += "�N���C�A���g:" & pstrCLI_CD
                strHedInfo += "�N���C�A���g:" & pstrCLI_CD & "�`" & pstrCLI_CD_TO
            End If
            If pstrJA_CD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "JA:" & pstrJA_CD
            End If
            If pstrHAN_GRP.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "�̔����Ǝ�:" & pstrHAN_GRP
            End If
            '2019/11/01 T.Ono del �Ď����P2019
            'If pstrKINREN_GRP.Length > 0 Then
            '    If strHedInfo.Length > 0 Then
            '        strHedInfo = strHedInfo & "�A"
            '    End If
            '    strHedInfo = strHedInfo & "�ً}�A����Gr:" & pstrKINREN_GRP
            'End If
            If pstrHAN_CD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "JA�x��:" & pstrHAN_CD & "�`" & pstrHAN_CD_TO
            End If
            If pstrHANBAI_KBN1 = "1" Or pstrHANBAI_KBN2 = "1" Or pstrHANBAI_KBN3 = "1" Or pstrHANBAI_KBN4 = "1" Or pstrHANBAI_KBN5 = "1" Or pstrHANBAI_KBN6 = "1" Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "�̔��敪:"
                strHedInfoHanbai = ""
                '�̔��敪�@1�F���[�^���@2�F�{���x���@3�F�����@4�F���̑��@5�F�f�[�^�Ȃ��@6�F��O
                If pstrHANBAI_KBN1 = "1" Then
                    strHedInfoHanbai = "���[�^��"
                End If
                If pstrHANBAI_KBN2 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "�E"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "�{���x��"
                End If
                If pstrHANBAI_KBN3 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "�E"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "����"
                End If
                If pstrHANBAI_KBN4 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "�E"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "���̑�"
                End If
                If pstrHANBAI_KBN5 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "�E"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "�f�[�^�Ȃ�"
                End If
                If pstrHANBAI_KBN6 = "1" Then
                    If strHedInfoHanbai.Length > 0 Then
                        strHedInfoHanbai = strHedInfoHanbai & "�E"
                    End If
                    strHedInfoHanbai = strHedInfoHanbai & "��O"
                End If
                strHedInfo = strHedInfo & strHedInfoHanbai
            End If
            If pstrUSER_FLG0 <> "0" Or pstrUSER_FLG1 <> "0" Or pstrUSER_FLG2 <> "0" Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "���q�lFLG:"
                strHedInfoUserFlg = ""
                '�̔��敪�@1�F���[�^���@2�F�{���x���@3�F�����@4�F���̑��@5�F�f�[�^�Ȃ��@6�F��O
                If pstrUSER_FLG0 <> "0" Then
                    strHedInfoUserFlg = "���J��"
                End If
                If pstrUSER_FLG1 <> "0" Then
                    If strHedInfoUserFlg.Length > 0 Then
                        strHedInfoUserFlg = strHedInfoUserFlg & "�E"
                    End If
                    strHedInfoUserFlg = strHedInfoUserFlg & "�^�p��"
                End If
                If pstrUSER_FLG2 <> "0" Then
                    If strHedInfoUserFlg.Length > 0 Then
                        strHedInfoUserFlg = strHedInfoUserFlg & "�E"
                    End If
                    strHedInfoUserFlg = strHedInfoUserFlg & "�x�~��"
                End If
                strHedInfo = strHedInfo & strHedInfoUserFlg
            End If
            If strHedInfo.Length > 0 Then
                cntExcel += 1
                ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;white-space:nowrap;"
                'ExcelC.pCellVal(i, "colspan=16") = strHedInfo
                ExcelC.pCellVal(i) = strHedInfo
                ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            End If
            '���o����2�s��
            strHedInfo = ""
            If pstrTEL.Length > 0 Then
                strHedInfo = strHedInfo & "�A����^�����ԍ�:" & pstrTEL
            End If
            If pstrNAME.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "���q�l���^�J�i:" & pstrNAME
            End If
            If pstrUSER_CD.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "���q�l�R�[�h:" & pstrUSER_CD
            End If
            If pstrADDR.Length > 0 Then
                If strHedInfo.Length > 0 Then
                    strHedInfo = strHedInfo & "�A"
                End If
                strHedInfo = strHedInfo & "���q�l�Z��:" & pstrADDR
            End If
            If strHedInfo.Length > 0 Then
                cntExcel += 1
                'ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;"
                'ExcelC.pCellVal(i, "colspan=16") = strHedInfo
                ExcelC.pCellStyle(1) = "height:13px;width:50px;text-align:left;font-size:10px;border-style:none;white-space:nowrap;"
                ExcelC.pCellVal(i) = strHedInfo
                ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������
            End If
            '�w�b�_�s
            ExcelC.pCellStyle(1) = "height:13px;width:30px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(2) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(3) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(4) = "height:13px;width:100Px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(5) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(6) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(7) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(8) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(9) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;" '2017/10/24 H.Mori add 2017���P�J�� No2-2
            ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"
            ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none;background-color:lightgrey;"


            i = 1
            cntExcel += 1
            ExcelC.pCellVal(i) = Convert.ToString("��") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�i�`�R�[�h") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�i�`��") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�̔����Ǝ҃R�[�h") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�̔����ƎҖ�") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�̔����R�[�h") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�i�`�x���R�[�h") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�i�`�x����") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("���q�l�R�[�h") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("���q�l��") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("��\�Ҏ���") : i += 1          '2017/10/24 H.Mori add 2017���P�J�� No2-2
            ExcelC.pCellVal(i) = Convert.ToString("�A����") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�����ԍ�") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�Z��") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�K�p�@�ߋ敪") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�����`�ԋ敪") : i += 1
            ExcelC.pCellVal(i) = Convert.ToString("�p�r�敪") : i += 1
            ExcelC.mWriteLine("")       '�s���t�@�C���ɏ�������

            ''���׃f�[�^�o��
            Dim iCnt As Integer
            'AP�T�[�o����̖߂�l�����[�v����
            '���׃f�[�^�o��
            'For Each dr In ds.Tables(0).Rows
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                If cntExcel = 65536 Then
                    overFlg = "1"
                    Exit For
                End If
                dr = ds.Tables(0).Rows(iCnt)
                '���׍���
                ExcelC.pCellStyle(1) = "height:13px;width:30px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(2) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(3) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2016/02/26 H.Mori add �Ď����P2015 ��10
                ExcelC.pCellStyle(4) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(5) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(6) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(7) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(8) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(9) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8
                ExcelC.pCellStyle(10) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(11) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" '2017/10/24 H.Mori add 2017���P�J�� No2-2
                ExcelC.pCellStyle(12) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(13) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(14) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(15) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(16) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none"
                ExcelC.pCellStyle(17) = "height:13px;width:100px;text-align:left;font-size:10px;border-style:none" ' 2013/08/27 T.Ono add �Ď����P2013��8

                i = 1
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NO")) : i += 1 ' ��
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JA_CD")) : i += 1      ' [���p��]�yJA�R�[�h�z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JA_NAME")) : i += 1   ' [���p��]�yJA���z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("GROUPCD")) : i += 1   ' [���R�[�h���]�y�̔����Ǝ҃R�[�h�z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANJIGYOSYANM")) : i += 1   ' [���R�[�h���]�y�̔����ƎҖ��z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HANBCD")) : i += 1    ' []�y�̔����R�[�h�z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("HAN_CD")) : i += 1    ' []�yJA�x���R�[�h�z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("JAS_NAME")) : i += 1  ' []�yJA�x�����z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("USER_CD")) : i += 1   ' []�y���q�l�R�[�h�z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NAME")) : i += 1   ' []�y���q�l���z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("DAIHYO_NAME")) : i += 1   ' []�y��\�Ҏ����z 2017/10/24 H.Mori add 2017���P�J�� No2-2
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("KANKENSAKU_TEL")) : i += 1   ' []�y�A����z

                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("NCU_TEL")) : i += 1   '[]�y�����ԍ��z
                ExcelC.pCellVal(i) = Convert.ToString(dr.Item("ADDR")) : i += 1      '[]�y�Z���z
                ExcelC.pCellVal(i) = fncGetHOKBNNM(Convert.ToString(dr.Item("HOKBN"))) : i += 1 ' []�y�K�p�@�ߋ敪�z
                ExcelC.pCellVal(i) = fncGetKYOKTKBNNM(Convert.ToString(dr.Item("KYOKTKBN"))) : i += 1 ' []�y�����`�ԋ敪�z
                ExcelC.pCellVal(i) = fncGetYOTOKBNNM(Convert.ToString(dr.Item("YOTOKBN"))) : i += 1 ' []�y�p�r�敪�z
                ExcelC.mWriteLine("")           '�s���t�@�C���ɏ�������
                cntExcel += 1
            Next

            ExcelC.mWriteLine("")                           '�s���t�@�C���ɏ�������
            ExcelC.mClose()                                 '�t�@�C���N���[�Y

            '���k��t�@�C���̂���t�H���_
            compressC.p_Dir = ExcelC.pDirName
            '���{��t�@�C�����̎w��
            compressC.p_NihongoFileName = "���q�l�������X�g.xls"
            '���k���t�@�C����
            compressC.p_FileName = ExcelC.pDirName & ExcelC.pFileName & ".xls"
            '���k��t�@�C����
            compressC.p_madeFilename = ExcelC.pDirName & ExcelC.pFileName & ".lzh"
            If overFlg = "1" Then
                Return "OVER0" & (compressC.p_FileName)
            End If
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
    '*         2019/11/01 T.Ono mod �Ď����P2019 No1 CLI_CD_TO,JA_CD_CLI,HAN_CD_CLI,HAN_CD_TO_CLI�ǉ��AKINREN_GRP�폜
    '******************************************************************************
    Public Function fncMakeSelect(ByVal pstrKANSCD As String,
                                  ByVal pstrTEL As String,
                                  ByVal pstrNAME As String,
                                  ByVal pstrADDR As String,
                                  ByVal pstrCLI_CD As String,
                                  ByVal pstrCLI_CD_TO As String,
                                  ByVal pstrJA_CD As String,
                                  ByVal pstrJA_CD_CLI As String,
                                  ByVal pstrHAN_GRP As String,
                                  ByVal pstrHAN_CD As String,
                                  ByVal pstrHAN_CD_CLI As String,
                                  ByVal pstrHAN_CD_TO As String,
                                  ByVal pstrHAN_CD_TO_CLI As String,
                                  ByVal pstrUSER_CD As String,
                                  ByVal pstrUSER_FLG0 As String,
                                  ByVal pstrUSER_FLG1 As String,
                                  ByVal pstrUSER_FLG2 As String,
                                  ByVal pstrHANBAI_KBN1 As String,
                                  ByVal pstrHANBAI_KBN2 As String,
                                  ByVal pstrHANBAI_KBN3 As String,
                                  ByVal pstrHANBAI_KBN4 As String,
                                  ByVal pstrHANBAI_KBN5 As String,
                                  ByVal pstrHANBAI_KBN6 As String) As String

        Dim strSQL As New StringBuilder("")
        'ORDER BY��������ɇ����擾���Ȃ��ƁA�����悭���΂Ȃ�����
        strSQL.Append("SELECT ")
        strSQL.Append("A.* ")
        strSQL.Append(",ROWNUM AS NO ")
        strSQL.Append("FROM (")
        strSQL.Append("  SELECT ")
        strSQL.Append("LPAD(ROWNUM,4,0) AS ROWNO, ")
        strSQL.Append("	'' AS COLOR, ")                                              'SPAN�J���[
        strSQL.Append("	'' AS CLS, ")                                                'SPAN�N���X
        strSQL.Append("	HN.JA_CD, ")
        strSQL.Append("	HN.JA_NAME, ")
        strSQL.Append("	H1.GROUPCD, ")
        strSQL.Append("	H1.HANJIGYOSYANM, ")
        strSQL.Append("	SH.HANBCD, ")
        strSQL.Append("	SH.HAN_CD, ")
        strSQL.Append("	HN.JAS_NAME, ")
        strSQL.Append("	SH.USER_CD, ")
        strSQL.Append("	SH.NAME, ")
        strSQL.Append("	SH.KANKENSAKU_TEL, ")
        'strSQL.Append("	SH.NCU_TELA || SH.NCU_TELB AS NCU_TEL, ")
        strSQL.Append("	(CASE WHEN SH.NCU_TELA IS NULL THEN NULL ELSE SH.NCU_TELA||'-'||SUBSTR(SH.NCU_TELB,1,INSTR(SH.NCU_TELB, SUBSTR(SH.NCU_TELB, - 4))-1)||'-'||SUBSTR(SH.NCU_TELB, - 4)  END) AS NCU_TEL, ")
        strSQL.Append("	SH.ADD_1 || SH.ADD_2 || SH.ADD_3 AS ADDR, ")
        strSQL.Append("	SH.HOKBN, ")
        strSQL.Append("	SH.KYOKTKBN, ")
        strSQL.Append("	SH.YOTOKBN, ")
        strSQL.Append("	SH.DAIHYO_NAME ") '2017/10/24 H.Mori add 2017���P�J�� No2-2
        strSQL.Append("FROM SHAMAS SH, ")
        strSQL.Append("     CLIMAS CL, ")
        strSQL.Append("     HN2MAS HN, ")
        strSQL.Append("     M09_JAGROUP G1, ")     'JA�x��
        strSQL.Append("     M10_HANJIGYOSYA H1 ")


        strSQL.Append("WHERE SH.CLI_CD = CL.CLI_CD(+) ")
        strSQL.Append("AND SH.CLI_CD = HN.CLI_CD(+) ")
        strSQL.Append("AND SH.HAN_CD = HN.HAN_CD(+) ")
        strSQL.Append("  AND G1.KBN(+) = '001' ")
        strSQL.Append("  AND G1.KURACD(+) = SH.CLI_CD ")
        strSQL.Append("  AND G1.ACBCD(+) = SH.HAN_CD ")
        strSQL.Append("  AND G1.USERCD_FROM(+) IS NULL ")
        strSQL.Append("  AND G1.USERCD_TO(+) IS NULL ")
        strSQL.Append("  AND G1.GROUPCD = H1.GROUPCD(+) ")
        '�Ď��Z���^�[
        If pstrKANSCD.Length > 0 Then
            strSQL.Append(" AND SH.CLI_CD = CL.CLI_CD ")
            '2019/11/01 T.Ono mod �Ď����P2019 
            'strSQL.Append(" AND CL.KANSI_CODE = :KANSCD ")
            strSQL.Append(" AND CL.KANSI_CODE IN (" & pstrKANSCD & ") ")
        End If
        '���v�Ɠd�b�ԍ�
        If pstrTEL.Length > 0 Then
            strSQL.Append(" AND (REPLACE(REPLACE(SH.KANKENSAKU_TEL,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.RENTEL2,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.RENTEL3,'-',''), ' ','') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.NCU_TELA || SH.NCU_TELB,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.TELA || SH.TELB,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','') ")
            strSQL.Append(" OR REPLACE(REPLACE(SH.DAI3RENDORENTEL,'-',''), ' ', '') ")
            strSQL.Append("  LIKE REPLACE(:TEL,'-','')) ")
        End If
        '���v�Ɩ�
        If pstrNAME.Length > 0 Then
            strSQL.Append(" AND (REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.NAME), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:NAME), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append(" OR REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.KANA), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:NAME), 'FWKATAKANA_HWKATAKANA'),' ','')) ")
        End If
        '���v�ƏZ��
        If pstrADDR.Length > 0 Then
            strSQL.Append(" AND REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (SH.ADD_1 || SH.ADD_2 || SH.ADD_3), 'FWKATAKANA_HWKATAKANA'),' ','') ")
            strSQL.Append("  LIKE REPLACE(UTL_I18N.TRANSLITERATE(TO_SINGLE_BYTE (:ADDR), 'FWKATAKANA_HWKATAKANA'),' ','') ")
        End If
        '�N���C�A���g�R�[�h
        If pstrCLI_CD.Length > 0 Then
            '2019/11/01 T.Ono mod �Ď����P2019 No1
            'strSQL.Append(" AND SH.CLI_CD = :CLI_CD ")
            strSQL.Append(" AND SH.CLI_CD >= :CLI_CD ")
            strSQL.Append(" AND SH.CLI_CD <= :CLI_CD_TO ")
        End If
        '�i�`�R�[�h
        If pstrJA_CD.Length > 0 Then
            strSQL.Append(" AND SH.HAN_CD LIKE :JA_CD ")
        End If
        '�̔����Ǝ҃O���[�v
        If pstrHAN_GRP.Length > 0 Then
            strSQL.Append(mMakeSQL_HANGRP())
        End If
        '2019/11/01 T.Ono del �Ď����P2019 No1
        ''�ً}�A����Gr
        'If pstrKINREN_GRP.Length > 0 Then
        '    strSQL.Append(mMakeSQL_HANGRP())
        'End If
        '�i�`�x���R�[�h
        If pstrHAN_CD.Length > 0 Then
            '2019/11/01 T.Ono mod �Ď����P2019 No1
            'strSQL.Append(" AND SH.HAN_CD >= :HAN_CD ")
            'strSQL.Append(" AND SH.HAN_CD <= :HAN_CD_TO ")
            strSQL.Append(" AND SH.CLI_CD || SH.HAN_CD >= :HAN_CD_CLI || :HAN_CD ")
            strSQL.Append(" AND SH.CLI_CD || SH.HAN_CD <= :HAN_CD_TO_CLI || :HAN_CD_TO ")
        End If
        '���q�l�R�[�h
        If pstrUSER_CD.Length > 0 Then
            strSQL.Append(" AND SH.USER_CD LIKE :USER_CD ")
        End If

        '���q�lFLG
        strSQL.Append(" AND SH.USER_FLG IN (:USER_FLG0,:USER_FLG1,:USER_FLG2) ")

        '�̔��敪
        If pstrHANBAI_KBN1 = "1" AndAlso pstrHANBAI_KBN2 = "1" AndAlso pstrHANBAI_KBN3 = "1" AndAlso
            pstrHANBAI_KBN4 = "1" AndAlso pstrHANBAI_KBN5 = "1" AndAlso pstrHANBAI_KBN6 = "1" Then
        Else
            If pstrHANBAI_KBN1 = "1" OrElse pstrHANBAI_KBN2 = "1" OrElse pstrHANBAI_KBN3 = "1" OrElse
                pstrHANBAI_KBN4 = "1" Then
                If pstrHANBAI_KBN5 = "1" OrElse pstrHANBAI_KBN6 = "1" Then
                    If pstrHANBAI_KBN5 = "1" AndAlso pstrHANBAI_KBN6 = "1" Then
                        strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN IS NULL) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                    Else
                        If pstrHANBAI_KBN5 = "1" Then
                            strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                            strSQL.Append(" OR  (SH.HANBAI_KBN IS NULL)) ")
                        Else
                            strSQL.Append(" AND (SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                            strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                        End If
                    End If
                Else
                    strSQL.Append(" AND SH.HANBAI_KBN IN (:HANBAI_KBN1,:HANBAI_KBN2,:HANBAI_KBN3,:HANBAI_KBN4) ")
                End If
            Else
                If pstrHANBAI_KBN5 = "1" OrElse pstrHANBAI_KBN6 = "1" Then
                    If pstrHANBAI_KBN5 = "1" AndAlso pstrHANBAI_KBN6 = "1" Then
                        strSQL.Append(" AND ((SH.HANBAI_KBN IS NULL) ")
                        strSQL.Append(" OR  (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL)) ")
                    Else
                        If pstrHANBAI_KBN5 = "1" Then
                            strSQL.Append(" AND (SH.HANBAI_KBN IS NULL) ")
                        Else
                            strSQL.Append(" AND (SH.HANBAI_KBN NOT IN ('1','2','3','4') AND SH.HANBAI_KBN IS NOT NULL) ")
                        End If
                    End If
                Else
                    strSQL.Append(" AND  1 <> 1 ")
                End If
            End If
        End If
        '�̔��敪
        '�f�[�^�̃\�[�g���s�Ȃ�
        strSQL.Append("ORDER BY SH.CLI_CD, SH.HAN_CD, SH.USER_CD ")
        strSQL.Append(") A") '2013/12/09 add T.Ono �Ď����P2013





        Return strSQL.ToString

    End Function
    Function fncGetHOKBNNM(ByVal str As String) As String
        Dim res As String
        If str = "1" Then
            res = "1:�t�Ζ@"
        ElseIf str = "2" Then
            res = "2:�����@"
        ElseIf str = "3" Then
            res = "3:�t�Ζ@�E�����@"
        ElseIf str = "4" Then
            res = "4:�K�X���Ɩ@"
        ElseIf str = "5" Then
            res = "5:�K�p�O"
        Else
            res = str
        End If

        Return res
    End Function
    Function fncGetKYOKTKBNNM(ByVal str As String) As String
        Dim res As String
        If str = "1" Then
            res = "1:���"
        ElseIf str = "2" Then
            res = "2:�W��"
        ElseIf str = "3" Then
            res = "3:�ȃK�X"
        Else
            res = str
        End If

        Return res
    End Function
    Function fncGetYOTOKBNNM(ByVal str As String) As String
        Dim res As String
        If str = "1" Then
            res = "1:�ƒ�p"
        ElseIf str = "2" Then
            res = "2:�Ɩ��p"
        ElseIf str = "3" Then
            res = "3:�_�Ɨp"
        ElseIf str = "4" Then
            res = "4:�H�Ɨp"
        ElseIf str = "5" Then
            res = "5:���̑�"
        Else
            res = str
        End If

        Return res
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
    '******************************************************************************
    '*�@�T�@�v�F�r�p�k�쐬�i�̔����Ǝ҃O���[�v�����j
    '*�@���@�l�F
    '******************************************************************************
    Private Function mMakeSQL_HANGRP() As String

        Dim strSQL As New StringBuilder("")

        strSQL.Append(" AND EXISTS ( ")
        strSQL.Append("SELECT * FROM ( ")
        '2019/11/01 T.Ono mod �Ď����P2019 No1
        'strSQL.Append("WITH T_SH AS (SELECT SH.CLI_CD,SH.HAN_CD,SH.USER_CD FROM SHAMAS SH WHERE SH.CLI_CD= :CLI_CD), ")
        'strSQL.Append("     T_JG AS (SELECT JG.KBN,JG.KURACD,JG.ACBCD,JG.GROUPCD,JG.USERCD_FROM,JG.USERCD_TO FROM M09_JAGROUP JG WHERE JG.KBN = :HAN_GRP_KBN AND JG.KURACD = :CLI_CD) ")
        strSQL.Append("WITH T_SH AS (SELECT SH.CLI_CD,SH.HAN_CD,SH.USER_CD FROM SHAMAS SH WHERE SH.CLI_CD >= :CLI_CD AND SH.CLI_CD <= :CLI_CD_TO), ")
        strSQL.Append("     T_JG AS (SELECT JG.KBN,JG.KURACD,JG.ACBCD,JG.GROUPCD,JG.USERCD_FROM,JG.USERCD_TO FROM M09_JAGROUP JG WHERE JG.KBN = :HAN_GRP_KBN AND JG.KURACD >= :CLI_CD AND JG.KURACD <= :CLI_CD_TO) ")
        '��ʂőI�������̔����Ə��ɏ�������ʂ̌ڋq���擾
        strSQL.Append("SELECT * FROM T_SH SH1 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG1 ")
        strSQL.Append("               WHERE JG1.ACBCD = SH1.HAN_CD ")
        strSQL.Append("               AND JG1.KURACD = SH1.CLI_CD ")         '2019/11/01 T.Ono add �Ď����P2019
        strSQL.Append("               AND JG1.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG1.USERCD_FROM = SH1.USER_CD ")
        strSQL.Append("               AND JG1.USERCD_TO IS NULL ")
        strSQL.Append("            ) ")
        strSQL.Append("UNION ")
        '��ʂőI�������̔����Ə��ɏ�������͈͂̌ڋq���擾
        strSQL.Append("SELECT * FROM T_SH SH2 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG2 ")
        strSQL.Append("               WHERE JG2.ACBCD = SH2.HAN_CD ")
        strSQL.Append("               AND JG2.KURACD = SH2.CLI_CD ")         '2019/11/01 T.Ono add �Ď����P2019
        strSQL.Append("               AND JG2.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG2.USERCD_FROM IS NOT NULL ")
        strSQL.Append("               AND JG2.USERCD_TO IS NOT NULL ")
        strSQL.Append("               AND SH2.USER_CD BETWEEN JG2.USERCD_FROM AND JG2.USERCD_TO ")
        strSQL.Append("             ) ")
        '''''�ʂ̔̔����Ǝ҃O���[�v�ɑ�����ʂ̌ڋq������
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG3 ")
        strSQL.Append("               WHERE SH2.HAN_CD = JG3.ACBCD ")
        strSQL.Append("               AND JG3.KURACD = SH2.CLI_CD ")         '2019/11/01 T.Ono add �Ď����P2019
        strSQL.Append("               AND JG3.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG3.USERCD_TO IS NULL ")
        strSQL.Append("               AND SH2.USER_CD = JG3.USERCD_FROM ")
        strSQL.Append("              ) ")
        strSQL.Append("UNION ")
        '��ʂőI�������̔����Ə��ɏ�������x���̌ڋq���擾
        strSQL.Append("SELECT * FROM T_SH SH3 ")
        strSQL.Append("WHERE EXISTS ( ")
        strSQL.Append("               SELECT * FROM T_JG JG4 ")
        strSQL.Append("               WHERE SH3.HAN_CD =  JG4.ACBCD ")
        strSQL.Append("               AND JG4.KURACD = SH3.CLI_CD ")         '2019/11/01 T.Ono add �Ď����P2019
        strSQL.Append("               AND JG4.GROUPCD = :HAN_GRP ")
        strSQL.Append("               AND JG4.USERCD_FROM IS NULL ")
        strSQL.Append("               AND JG4.USERCD_TO IS NULL ")
        strSQL.Append("             ) ")
        '''''�ʂ̔̔����Ǝ҃O���[�v�ɑ�����ʂ̌ڋq������
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG5 ")
        strSQL.Append("               WHERE SH3.HAN_CD = JG5.ACBCD ")
        strSQL.Append("               AND JG5.KURACD = SH3.CLI_CD ")         '2019/11/01 T.Ono add �Ď����P2019
        strSQL.Append("               AND JG5.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG5.USERCD_TO IS NULL ")
        strSQL.Append("               AND SH3.USER_CD = JG5.USERCD_FROM ")
        strSQL.Append("              ) ")
        '''''�ʂ̔̔����Ǝ҃O���[�v�ɑ�����͈͂̌ڋq������
        strSQL.Append("AND NOT EXISTS( ")
        strSQL.Append("               SELECT * FROM T_JG JG6 ")
        strSQL.Append("               WHERE SH3.HAN_CD = JG6.ACBCD ")
        strSQL.Append("               AND JG6.KURACD = SH3.CLI_CD ")         '2019/11/01 T.Ono add �Ď����P2019
        strSQL.Append("               AND JG6.GROUPCD <> :HAN_GRP ")
        strSQL.Append("               AND JG6.USERCD_FROM IS NOT NULL ")
        strSQL.Append("               AND JG6.USERCD_TO IS NOT NULL ")
        strSQL.Append("               AND SH3.USER_CD BETWEEN JG6.USERCD_FROM AND JG6.USERCD_TO ")
        strSQL.Append("              ) ")
        strSQL.Append(") T_GRP ")
        strSQL.Append("WHERE SH.CLI_CD = T_GRP.CLI_CD ")
        strSQL.Append("AND SH.HAN_CD = T_GRP.HAN_CD ")
        strSQL.Append("AND SH.USER_CD = T_GRP.USER_CD ")
        strSQL.Append(" ) ")

        Return strSQL.ToString
    End Function
End Class
