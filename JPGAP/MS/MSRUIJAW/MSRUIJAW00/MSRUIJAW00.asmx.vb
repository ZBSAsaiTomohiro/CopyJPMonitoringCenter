'***********************************************
'�ݐϏ�񎩓�FAX&���[���}�X�^
'***********************************************
' �ύX����

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports System.IO


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSRUIJAW00/Service1")> _
Public Class MSRUIJAW00
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

    'pintMODE
    '   1:�V�K�o�^
    '   2:�C���o�^
    '   3:�폜
    '************************************************
    '�ݐϏ�񎩓�FAX&���[���}�X�^���X�g�f�[�^�擾
    '************************************************
    '�y���ʁz
    '  OK : ����ɏI�����܂���
    '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
    '   1 : ���Ƀf�[�^�����݂��܂�
    '   2 : �Ώۃf�[�^�����݂��܂���
    '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������
    ' ----------------------------------------------
    '2020/11/01 T.Ono mod 2020�Ď����P pstrSD_PRT�ǉ�
    <WebMethod()> Public Function mSet(
                                    ByVal pintMODE As Integer,
                                    ByVal pstrKURACD As String,
                                    ByVal pstrID() As String,
                                    ByVal pstrSEND() As String,
                                    ByVal pstrKYOKYUCD() As String,
                                    ByVal pstrACBCDFR() As String,
                                    ByVal pstrACBCDTO() As String,
                                    ByVal pstrFAX1() As String,
                                    ByVal pstrFAX2() As String,
                                    ByVal pstrMAIL1() As String,
                                    ByVal pstrMAIL2() As String,
                                    ByVal pstrNXSEND() As String,
                                    ByVal pstrLSSEND() As String,
                                    ByVal pstrSENDSTR() As String,
                                    ByVal pstrSENDEND() As String,
                                    ByVal pstrMAILPASS() As String,
                                    ByVal pstrZIPFILE() As String,
                                    ByVal pstrBIKOU() As String,
                                    ByVal pstrHASSEI() As String,
                                    ByVal pstrKAIPAGE() As String,
                                    ByVal pstrKIKAN() As String,
                                    ByVal pstrZEROSEND() As String,
                                    ByVal pstrSD_PRT() As String,
                                    ByVal pstrSNDSTOP() As String,
                                    ByVal pstrDEL() As String,
                                    ByVal pstrADD_DATE As String,
                                    ByVal pstrEDT_DATE As String,
                                    ByVal pstrADD_DT() As String,
                                    ByVal pstrEDT_DT() As String) As String

        ' ------------------------------
        ' strAUTO_MAIL�z�����ŗp��
        Dim strKYOKYUCD() As String
        strKYOKYUCD = New String(pstrKYOKYUCD.Length) {} '�z��̎��̂��m��
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '�z��̎��̂��m��
        Dim i As Integer
        For i = 0 To strKYOKYUCD.Length
            strKYOKYUCD(i) = ""
            strDEL(i) = ""
        Next
        ' ------------------------------
        '2020/11/01 T.Ono mod 2020�Ď����P pstrSD_PRT�ǉ�
        Return mSetEx(pintMODE,
                      pstrKURACD,
                      pstrID,
                      pstrSEND,
                      pstrKYOKYUCD,
                      pstrACBCDFR,
                      pstrACBCDTO,
                      pstrFAX1,
                      pstrFAX2,
                      pstrMAIL1,
                      pstrMAIL2,
                      pstrNXSEND,
                      pstrLSSEND,
                      pstrSENDSTR,
                      pstrSENDEND,
                      pstrMAILPASS,
                      pstrZIPFILE,
                      pstrBIKOU,
                      pstrHASSEI,
                      pstrKAIPAGE,
                      pstrKIKAN,
                      pstrZEROSEND,
                      pstrSD_PRT,
                      pstrSNDSTOP,
                      pstrDEL,
                      pstrADD_DATE,
                      pstrEDT_DATE,
                      pstrADD_DT,
                      pstrEDT_DT)
    End Function

    '2020/11/01 T.Ono mod 2020�Ď����P pstrSD_PRT�ǉ�
    <WebMethod()> Public Function mSetEx(
                                    ByVal pintMODE As Integer,
                                    ByVal pstrKURACD As String,
                                    ByVal pstrID() As String,
                                    ByVal pstrSEND() As String,
                                    ByVal pstrKYOKYUCD() As String,
                                    ByVal pstrACBCDFR() As String,
                                    ByVal pstrACBCDTO() As String,
                                    ByVal pstrFAX1() As String,
                                    ByVal pstrFAX2() As String,
                                    ByVal pstrMAIL1() As String,
                                    ByVal pstrMAIL2() As String,
                                    ByVal pstrNXSEND() As String,
                                    ByVal pstrLSSEND() As String,
                                    ByVal pstrSENDSTR() As String,
                                    ByVal pstrSENDEND() As String,
                                    ByVal pstrMAILPASS() As String,
                                    ByVal pstrZIPFILE() As String,
                                    ByVal pstrBIKOU() As String,
                                    ByVal pstrHASSEI() As String,
                                    ByVal pstrKAIPAGE() As String,
                                    ByVal pstrKIKAN() As String,
                                    ByVal pstrZEROSEND() As String,
                                    ByVal pstrSD_PRT() As String,
                                    ByVal pstrSNDSTOP() As String,
                                    ByVal pstrDEL() As String,
                                    ByVal pstrADD_DATE As String,
                                    ByVal pstrEDT_DATE As String,
                                    ByVal pstrADD_DT() As String,
                                    ByVal pstrEDT_DT() As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String

        strRes = "OK"

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            '�g�����U�N�V�����J�n--------------------------
            cdb.mBeginTrans()

            Dim i As Integer
            For i = 1 To 30 '30�����P�����o�^�^�C���^�폜����B

                '2020/11/01 T.Ono mod 2020�Ď����P pstrSD_PRT�ǉ�
                strRes = mSetRuiauto(
                        cdb,
                        pintMODE,
                        pstrKURACD,
                        pstrID(i),
                        pstrSEND(i),
                        pstrKYOKYUCD(i),
                        pstrACBCDFR(i),
                        pstrACBCDTO(i),
                        pstrFAX1(i),
                        pstrFAX2(i),
                        pstrMAIL1(i),
                        pstrMAIL2(i),
                        pstrNXSEND(i),
                        pstrLSSEND(i),
                        pstrSENDSTR(i),
                        pstrSENDEND(i),
                        pstrMAILPASS(i),
                        pstrZIPFILE(i),
                        pstrBIKOU(i),
                        pstrHASSEI(i),
                        pstrKAIPAGE(i),
                        pstrKIKAN(i),
                        pstrZEROSEND(i),
                        pstrSD_PRT(i),
                        pstrSNDSTOP(i),
                        pstrDEL(i),
                        pstrADD_DATE,
                        pstrEDT_DATE,
                        pstrADD_DT(i),
                        pstrEDT_DT(i))

                If strRes <> "OK" Then
                    Exit For
                End If
            Next

            If strRes = "OK" Then
                '�R�~�b�g
                cdb.mCommit()
            Else
                '���[���o�b�N
                cdb.mRollback()
            End If

        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString

            '�r�����䏈���G���[
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If

            '���[���o�b�N
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        cdb = Nothing

        Return strRes

    End Function
    '************************************************
    '�ݐϏ��FAX�}�X�^�X�V
    '************************************************
    '2020/11/01 T.Ono 2020�Ď����P pstrSD_PRT�ǉ�
    <WebMethod()> Public Function mSetRuiauto(
                                ByRef cdb As CDB,
                                ByVal pintMODE As Integer,
                                ByVal pstrKURACD As String,
                                ByVal pstrID As String,
                                ByVal pstrSEND As String,
                                ByVal pstrKYOKYUCD As String,
                                ByVal pstrACBCDFR As String,
                                ByVal pstrACBCDTO As String,
                                ByVal pstrFAX1 As String,
                                ByVal pstrFAX2 As String,
                                ByVal pstrMAIL1 As String,
                                ByVal pstrMAIL2 As String,
                                ByVal pstrNXSEND As String,
                                ByVal pstrLSSEND As String,
                                ByVal pstrSENDSTR As String,
                                ByVal pstrSENDEND As String,
                                ByVal pstrMAILPASS As String,
                                ByVal pstrZIPFILE As String,
                                ByVal pstrBIKOU As String,
                                ByVal pstrHASSEI As String,
                                ByVal pstrKAIPAGE As String,
                                ByVal pstrKIKAN As String,
                                ByVal pstrZEROSEND As String,
                                ByVal pstrSD_PRT As String,
                                ByVal pstrSNDSTOP As String,
                                ByVal pstrDEL As String,
                                ByVal pstrADD_DATE As String,
                                ByVal pstrEDT_DATE As String,
                                ByVal pstrADD_DT As String,
                                ByVal pstrEDT_DT As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim re As Integer
        Dim newId As Integer
        Dim newSEQ As Integer

        Dim tmp As String

        strRes = "OK"

        Try
            '*********************************
            '�����X�g�[���[
            '�E�r���̃`�F�b�N���s���B
            '�E�o�^���ɂ̓f�[�^�͖������݂��Ȃ�����
            '�E�C�����ɂ̓f�[�^�͑��݂��邱��
            '�E�Z���^�[�R�[�h�̑��݃`�F�b�N���s��
            '*********************************

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("A.ID, ")
            strSQL.Append("A.SEQ, ")
            strSQL.Append("A.KURACD, ")
            strSQL.Append("A.HAISO_CD, ")
            strSQL.Append("A.ACBCD_FR, ")
            strSQL.Append("A.ACBCD_TO, ")
            strSQL.Append("A.HATKBN, ")
            strSQL.Append("A.PAGEKBN, ")
            strSQL.Append("A.PERIODKBN, ")
            strSQL.Append("A.FAX1, ")
            strSQL.Append("A.FAX2, ")
            strSQL.Append("A.MAIL1, ")
            strSQL.Append("A.MAIL2, ")
            strSQL.Append("A.ZEROSENDKBN, ")
            strSQL.Append("A.SD_PRT, ")                     '�o���˗����e�E���l�\���t���O 2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("A.JOTAI, ")
            strSQL.Append("A.LASTSENDDATE, ")
            strSQL.Append("A.NEXTSENDDATE, ")
            strSQL.Append("A.SENDSTOPKBN, ")
            strSQL.Append("A.SENDSTDATE, ")
            strSQL.Append("A.SENDEDDATE, ")
            strSQL.Append("A.BIKO, ")
            strSQL.Append("A.DEL_FLG, ")
            strSQL.Append("A.MAIL_PASSWORD, ")
            strSQL.Append("A.ZIP_FILE_NAME, ")
            strSQL.Append("A.INS_DATE, ")
            strSQL.Append("A.UPD_DATE ")                  '�X�V����
            strSQL.Append("FROM ")
            strSQL.Append("  B10_BTRUIJAE A ")              '�ݐϏ�񎩓�FAX&���[���}�X�^
            strSQL.Append("WHERE A.ID   = :ID ")
            strSQL.Append("AND A.KURACD   = :KURACD ")
            strSQL.Append("AND A.DEL_FLG  = '0' ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("ID") = pstrID               'ID
            cdb.pSQLParamStr("KURACD") = pstrKURACD               '�N���C�A���g�R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 4 Then 'pintMODE=4(�폜)
                    If pstrDEL = "true" Then
                        pintMODE = 3 '���[�h��3�F�폜
                    Else
                        pintMODE = 2 '���[�h��2�F�X�V
                    End If
                Else
                    pintMODE = 2 '���[�h��2�F�X�V
                End If
            Else
                '�o�^���f�[�^�͂Ȃ��H
                '2014/03/10 T.Ono mod ���̗͂L����FAX�ƃ��[���Ń`�F�b�N
                'If pstrSEND = "" Then 
                If pstrFAX1 = "" AndAlso pstrFAX2 = "" AndAlso pstrMAIL1 = "" AndAlso pstrMAIL2 = "" Then
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                ElseIf pstrDEL = "true" Then
                    strRes = "0"
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                Else
                    pintMODE = 1 '���[�h��1�F�V�K
                End If
            End If

            If (pintMODE = 2) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If (
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SEQ")) = pstrSEND) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("KURACD")) = pstrKURACD) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("HAISO_CD")) = pstrKYOKYUCD) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD_FR")) = pstrACBCDFR) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD_TO")) = pstrACBCDTO) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("HATKBN")) = pstrHASSEI) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("PAGEKBN")) = pstrKAIPAGE) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("PERIODKBN")) = pstrKIKAN) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("FAX1")) = pstrFAX1) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("FAX2")) = pstrFAX2) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL1")) = pstrMAIL1) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL2")) = pstrMAIL2) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("NEXTSENDDATE")) = pstrNXSEND) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("ZEROSENDKBN")) = pstrZEROSEND) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SD_PRT")) = pstrSD_PRT) And                '2020/11/01 T.Ono add 2020�Ď����P
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SENDSTOPKBN")) = pstrSNDSTOP) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SENDSTDATE")) = pstrSENDSTR) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("SENDEDDATE")) = pstrSENDEND) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKOU) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL_PASSWORD")) = pstrMAILPASS) And
                (Convert.ToString(ds.Tables(0).Rows(0).Item("ZIP_FILE_NAME")) = pstrZIPFILE)
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If

            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If

            '�c�a�`�F�b�N-----------------------------------
            '�o�^�C�����A�N���C�A���g�R�[�h�̑��݃`�F�b�N���s��
            If (pintMODE = 1 Or pintMODE = 2) Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT  ")
                strSQL.Append(" CLI_CD ")                     '�N���C�A���g�R�[�h
                strSQL.Append("FROM ")
                strSQL.Append("CLIMAS ")                        '�N���C�A���g�}�X�^
                strSQL.Append("WHERE CLI_CD = :CLI_CD ")  '�N���C�A���g�R�[�h
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�N���C�A���g�R�[�h�����݂��Ȃ���
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If

            '�o�^�C�����A���M���̏d���`�F�b�N���s��
            '2014/03/10 T.Ono mod ���M���̓��͂�����ꍇ�B�����ꍇ�͎����̔�
            'If (pintMODE = 1 Or pintMODE = 2) Then
            If (pintMODE = 1 Or pintMODE = 2) AndAlso pstrSEND.Trim.Length > 0 Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append("     ID ")
                strSQL.Append("FROM ")
                strSQL.Append("     B10_BTRUIJAE ")
                strSQL.Append("WHERE ")
                strSQL.Append("     DEL_FLG ='0' ")
                strSQL.Append("AND  SEQ = :SEQ ")
                If pintMODE = 2 Then
                    strSQL.Append("AND  ID != :ID ")
                End If
                strSQL.Append("ORDER BY ID ")
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("SEQ") = pstrSEND
                If pintMODE = 2 Then
                    cdb.pSQLParamStr("ID") = pstrID
                End If

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count <> 0) Then
                    '*******************************************
                    '���M�������݂��鎞
                    '*******************************************
                    strRes = "5"
                    Exit Try
                End If
            End If

            '�f�[�^�̍X�V����--------------------------------

            If pintMODE = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("B10_BTRUIJAE ")                      '�ݐϏ�񎩓�FAX&���[��
                strSQL.Append("SET ")
                strSQL.Append("    DEL_FLG     = '1' ")          ' �폜�t���O
                strSQL.Append("    ,UPD_DATE     = SYSDATE ")          ' �X�V��
                strSQL.Append("WHERE ID  =:ID  ")                   'ID

            ElseIf pintMODE = 2 Then
                '�����敪���C��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("B10_BTRUIJAE ")
                strSQL.Append("SET ")
                strSQL.Append("    SEQ          = :SEQ, ")               ' ����
                strSQL.Append("    KURACD       = :KURACD, ")            ' �ײ��
                strSQL.Append("    HAISO_CD     = :HAISO_CD, ")          ' ����
                strSQL.Append("    ACBCD_FR     = :ACBCD_FR, ")          ' �x�� From
                strSQL.Append("    ACBCD_TO     = :ACBCD_TO, ")          ' �x�� To
                strSQL.Append("    HATKBN       = :HATKBN, ")            ' ��
                strSQL.Append("    PAGEKBN      = :PAGEKBN, ")           ' ��
                strSQL.Append("    PERIODKBN    = :PERIODKBN, ")         ' ��
                strSQL.Append("    FAX1         = :FAX1, ")              ' FAX1
                strSQL.Append("    FAX2         = :FAX2, ")              ' FAX2
                strSQL.Append("    MAIL1        = :MAIL1, ")             ' Ұ�1
                strSQL.Append("    MAIL2        = :MAIL2, ")             ' Ұ�2
                strSQL.Append("    MAIL_PASSWORD= :MAIL_PASSWORD, ")     ' Ұ��߽ܰ��
                strSQL.Append("    ZEROSENDKBN  = :ZEROSENDKBN, ")       ' �O
                strSQL.Append("    SD_PRT       = :SD_PRT, ")            ' �o���˗����e�E���l�\���t���O
                'strSQL.Append("    JOTAI        = NULL, ")               ' ���
                'strSQL.Append("    LASTSENDDATE = NULL, ")              ' ����
                strSQL.Append("    NEXTSENDDATE = :NEXTSENDDATE, ")      ' ����
                strSQL.Append("    SENDSTOPKBN  = :SENDSTOPKBN, ")       ' ��~
                strSQL.Append("    SENDSTDATE   = :SENDSTDATE, ")        ' ���M�J�n��
                strSQL.Append("    SENDEDDATE   = :SENDEDDATE, ")        ' ���M�I����
                strSQL.Append("    BIKO         = :BIKO, ")              ' ���l
                'strSQL.Append("    INS_DATE     = :INS_DATE, ")          ' �X�V��
                strSQL.Append("    UPD_DATE     = SYSDATE, ")          ' �X�V��
                strSQL.Append("    ZIP_FILE_NAME = :ZIP_FILE_NAME ")     ' zip�t�@�C����

                strSQL.Append("WHERE   ")
                strSQL.Append("      ID  =:ID  ")                  '���R�[�h

            ElseIf pintMODE = 1 Then
                '--------------------
                ' ID�̔�
                '--------------------
                strSQL = New StringBuilder
                strSQL.Append("SELECT MAX(ID) FROM B10_BTRUIJAE ")
                Try
                    cdb.pSQL = strSQL.ToString()
                    cdb.mExecQuery() 'SQL���s�I

                    '���ʂ��f�[�^�Z�b�g�Ɋi�[
                    ds = cdb.pResult

                    '�f�[�^�����݂��Ȃ��ꍇ
                    If ds.Tables(0).Rows.Count = 0 Then
                        '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                        re = 0
                    Else
                        '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
                        re = Convert.ToInt16(ds.Tables(0).Rows(0).Item(0))
                    End If
                Catch ex As Exception
                    ' ex.ToString
                    re = 0
                Finally
                End Try
                newId = re + 1
                '--------------------
                ' ���M���̔ԁi���͂Ȃ��̏ꍇ�j
                '--------------------
                If pstrSEND.Trim.Length = 0 Then
                    strSQL = New StringBuilder
                    strSQL.Append("SELECT MAX(SEQ) FROM B10_BTRUIJAE ")
                    Try
                        cdb.pSQL = strSQL.ToString()
                        cdb.mExecQuery() 'SQL���s�I

                        '���ʂ��f�[�^�Z�b�g�Ɋi�[
                        ds = cdb.pResult

                        '�f�[�^�����݂��Ȃ��ꍇ
                        If ds.Tables(0).Rows.Count = 0 Then
                            '�f�[�^��0���ł��邱�Ƃ������������Ԃ�
                            re = 0
                        Else
                            '�f�[�^���[�Ƀf�[�^�Z�b�g���i�[
                            re = Convert.ToInt16(ds.Tables(0).Rows(0).Item(0))
                        End If
                    Catch ex As Exception
                        ' ex.ToString
                        re = 0
                    Finally
                    End Try
                    newSEQ = re + 1
                End If
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("B10_BTRUIJAE (")
                strSQL.Append("    ID, ")
                strSQL.Append("    SEQ, ")
                strSQL.Append("    KURACD, ")
                strSQL.Append("    HAISO_CD, ")
                strSQL.Append("    ACBCD_FR, ")
                strSQL.Append("    ACBCD_TO, ")
                strSQL.Append("    HATKBN, ")
                strSQL.Append("    PAGEKBN, ")
                strSQL.Append("    PERIODKBN, ")
                strSQL.Append("    FAX1, ")
                strSQL.Append("    FAX2, ")
                strSQL.Append("    MAIL1, ")
                strSQL.Append("    MAIL2, ")
                strSQL.Append("    ZEROSENDKBN, ")
                strSQL.Append("    SD_PRT, ")               '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("    JOTAI, ")
                strSQL.Append("    LASTSENDDATE, ")
                strSQL.Append("    NEXTSENDDATE, ")
                strSQL.Append("    SENDSTOPKBN, ")
                strSQL.Append("    SENDSTDATE, ")
                strSQL.Append("    SENDEDDATE, ")
                strSQL.Append("    BIKO, ")
                strSQL.Append("    DEL_FLG, ")
                strSQL.Append("    INS_DATE, ")
                strSQL.Append("    UPD_DATE, ")
                strSQL.Append("    MAIL_PASSWORD, ")
                strSQL.Append("    ZIP_FILE_NAME ")
                strSQL.Append(") VALUES ( ")
                strSQL.Append("    :ID, ")
                strSQL.Append("    :SEQ, ")
                strSQL.Append("    :KURACD, ")
                strSQL.Append("    :HAISO_CD, ")
                strSQL.Append("    :ACBCD_FR, ")
                strSQL.Append("    :ACBCD_TO, ")
                strSQL.Append("    :HATKBN, ")
                strSQL.Append("    :PAGEKBN, ")
                strSQL.Append("    :PERIODKBN, ")
                strSQL.Append("    :FAX1, ")
                strSQL.Append("    :FAX2, ")
                strSQL.Append("    :MAIL1, ")
                strSQL.Append("    :MAIL2, ")
                strSQL.Append("    :ZEROSENDKBN, ")
                strSQL.Append("    :SD_PRT, ")              '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("    'OK', ")
                strSQL.Append("    NULL, ")
                strSQL.Append("    :NEXTSENDDATE, ")
                strSQL.Append("    :SENDSTOPKBN, ")
                strSQL.Append("    :SENDSTDATE, ")
                strSQL.Append("    :SENDEDDATE, ")
                strSQL.Append("    :BIKO, ")
                strSQL.Append("    '0', ")
                strSQL.Append("    SYSDATE, ")
                strSQL.Append("    NULL, ")
                strSQL.Append("    :MAIL_PASSWORD, ")
                strSQL.Append("    :ZIP_FILE_NAME ")
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintMODE = 3 Then
                cdb.pSQLParamStr("ID") = pstrID                 'ID
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                If pintMODE = 1 Then
                    cdb.pSQLParamStr("ID") = Convert.ToString(newId)     'ID
                Else
                    cdb.pSQLParamStr("ID") = pstrID                      'ID
                End If
                '2014/03/10 T.Ono mod ���M���̓��͂������ꍇ�́A�����̔�
                'cdb.pSQLParamStr("SEQ") = pstrSEND                   '���M��
                If pstrSEND.Trim.Length > 0 Then
                    cdb.pSQLParamStr("SEQ") = pstrSEND                   '���M��
                Else
                    cdb.pSQLParamStr("SEQ") = Convert.ToString(newSEQ)   '���M���i�����̔ԁj
                End If
                cdb.pSQLParamStr("KURACD") = pstrKURACD              '�N���C�A���g�R�[�h
                cdb.pSQLParamStr("HAISO_CD") = pstrKYOKYUCD          '�����Z���^�[
                cdb.pSQLParamStr("ACBCD_FR") = pstrACBCDFR           'JA�x��FROM
                cdb.pSQLParamStr("ACBCD_TO") = pstrACBCDTO           'JA�x��TO
                cdb.pSQLParamStr("HATKBN") = pstrHASSEI              '�����敪
                cdb.pSQLParamStr("PAGEKBN") = pstrKAIPAGE            '���y�[�W����
                cdb.pSQLParamStr("PERIODKBN") = pstrKIKAN            '���ԏ���
                cdb.pSQLParamStr("FAX1") = pstrFAX1                  'FAX1
                cdb.pSQLParamStr("FAX2") = pstrFAX2                  'FAX2
                cdb.pSQLParamStr("MAIL1") = pstrMAIL1                '���[��1
                cdb.pSQLParamStr("MAIL2") = pstrMAIL2                '���[��2
                cdb.pSQLParamStr("ZEROSENDKBN") = pstrZEROSEND       '0�����M�敪
                cdb.pSQLParamStr("SD_PRT") = pstrSD_PRT              '�o���˗����e�E���l�\���t���O
                'cdb.pSQLParamStr("JOTAI") = "OK"                     '���
                'cdb.pSQLParamStr("LASTSENDDATE") = ""                '�ŏI���푗�M��
                cdb.pSQLParamStr("NEXTSENDDATE") = pstrNXSEND        '���񑗐M��
                cdb.pSQLParamStr("SENDSTOPKBN") = pstrSNDSTOP        '���M��~�敪
                cdb.pSQLParamStr("SENDSTDATE") = pstrSENDSTR         '���M�J�n��
                cdb.pSQLParamStr("SENDEDDATE") = pstrSENDEND         '���M�I����
                cdb.pSQLParamStr("BIKO") = pstrBIKOU                 '���l
                cdb.pSQLParamStr("MAIL_PASSWORD") = pstrMAILPASS     '���[���p�X���[�h
                cdb.pSQLParamStr("ZIP_FILE_NAME") = pstrZIPFILE      'ZIP�t�@�C����
                'If pintMODE = 1 Then
                '�V�K�o�^�̏ꍇ
                'cdb.pSQLParamStr("INS_DATE") = Now.ToString("yyyyMMdd")
                'cdb.pSQLParamStr("UPD_DATE") = ""
                '            Else
                '�C���o�^�̏ꍇ
                '               cdb.pSQLParamStr("INS_DATE") = pstrADD_DT
                '              cdb.pSQLParamStr("UPD_DATE") = Now.ToString("yyyyMMdd")
                '         End If
            End If

            'SQL�����s
            cdb.mExecNonQuery()

        Catch ex As NullReferenceException
            strRes = "0"
        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString

            '�r�����䏈���G���[
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If
            strRes = strRes & cdb.pErr
        Finally

        End Try

        Return strRes

    End Function
    '******************************************************************************
    '*�@�T�@�v:���v�ƍX�V�E�폜�ꗗ�̏o�͂��s���܂�
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrKURACD As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSV�N���X
        Dim compressC As New CCompress                  '���k�N���X
        Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
        Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
        Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
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
        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("A.ID, ")
            strSQL.Append("A.SEQ, ")
            strSQL.Append("A.KURACD, ")
            strSQL.Append("A.HAISO_CD, ")
            strSQL.Append("A.ACBCD_FR, ")
            strSQL.Append("A.ACBCD_TO, ")
            strSQL.Append("A.HATKBN, ")
            strSQL.Append("A.PAGEKBN, ")
            strSQL.Append("A.PERIODKBN, ")
            strSQL.Append("A.FAX1, ")
            strSQL.Append("A.FAX2, ")
            strSQL.Append("A.MAIL1, ")
            strSQL.Append("A.MAIL2, ")
            strSQL.Append("A.ZEROSENDKBN, ")
            strSQL.Append("A.SD_PRT, ")                 '2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("A.JOTAI, ")
            strSQL.Append("A.LASTSENDDATE, ")
            strSQL.Append("A.NEXTSENDDATE, ")
            strSQL.Append("A.SENDSTOPKBN, ")
            strSQL.Append("A.SENDSTDATE, ")
            strSQL.Append("A.SENDEDDATE, ")
            strSQL.Append("A.MAIL_PASSWORD, ")
            strSQL.Append("A.ZIP_FILE_NAME, ")
            strSQL.Append("A.INS_DATE, ")
            strSQL.Append("A.UPD_DATE, ")
            strSQL.Append("A.BIKO ")
            strSQL.Append("FROM ")
            strSQL.Append("  B10_BTRUIJAE A ")
            '2014/03/07 T.Ono mod �N���C�A���g�R�[�h�̎w��͔C��
            'strSQL.Append("WHERE KURACD  =:KURACD  ")
            strSQL.Append("WHERE 1=1 ")
            If pstrKURACD.Trim.Length > 0 Then
                strSQL.Append("AND KURACD  =:KURACD ")
            End If
            strSQL.Append("AND A.DEL_FLG  = '0' ")
            strSQL.Append("ORDER BY TO_NUMBER(SEQ)  ")
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            '2014/03/07 T.Ono mod �N���C�A���g�R�[�h�̎w��͔C��
            'cdb.pSQLParamStr("KURACD") = pstrKURACD
            If pstrKURACD.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD.Trim
            End If

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult
            CSVC.pKencd = "00"
            CSVC.pSessionID = pstrSessionID   '�Z�b�V����ID
            CSVC.pRepoID = "MSRUIJAW00"       '���[ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)
                If iCnt = 0 Then
                    CSVC.pColValStrEx = "ID"
                    CSVC.pColValStrEx = "���M��"
                    CSVC.pColValStrEx = "�N���C�A���g�R�[�h"
                    CSVC.pColValStrEx = "�����Z���^�[�R�[�h"
                    CSVC.pColValStrEx = "JA�x��FROM"
                    CSVC.pColValStrEx = "JA�x��TO"
                    CSVC.pColValStrEx = "�����敪"
                    CSVC.pColValStrEx = "���y�[�W����"
                    CSVC.pColValStrEx = "���ԏ���"
                    CSVC.pColValStrEx = "FAX�ԍ�1"
                    CSVC.pColValStrEx = "FAX�ԍ�2"
                    CSVC.pColValStrEx = "���[���ԍ�1"
                    CSVC.pColValStrEx = "���[���ԍ�2"
                    CSVC.pColValStrEx = "0�����M�敪"
                    CSVC.pColValStrEx = "�o�����e�E���l�\���t���O"      '2020/11/01 T.Ono add 2020�Ď����P
                    CSVC.pColValStrEx = "���"
                    CSVC.pColValStrEx = "�ŏI���푗�M��"
                    CSVC.pColValStrEx = "���񑗐M��"
                    CSVC.pColValStrEx = "���M��~�敪"
                    CSVC.pColValStrEx = "���M�J�n��"
                    CSVC.pColValStrEx = "���M�I����"
                    CSVC.pColValStrEx = "���[���p�X���[�h"
                    CSVC.pColValStrEx = "ZIP�t�@�C����"
                    CSVC.pColValStrEx = "�o�^����"
                    CSVC.pColValStrEx = "�X�V����"
                    CSVC.pColValStrEx = "���l"
                    CSVC.mWriteLine()
                End If
                For irCnt = 0 To dr.Table.Columns.Count - 1
                    CSVC.pColValStrEx = Convert.ToString(dr.Item(irCnt))
                Next
                CSVC.mWriteLine()
            Next
            CSVC.mClose()
            Return CSVC.pDirName & CSVC.pFileName
        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�baba
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testRUISEKI" & System.DateTime.Today.ToString("yyyyMMdd")
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
