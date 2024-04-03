'***********************************************
'�Ď��Z���^�[�S���҃}�X�^
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAKJAW00/Service1")> _
Public Class MSTAKJAW00
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
    '�S���҃}�X�^���X�g�f�[�^�擾
    '************************************************
    '�y���ʁz
    '  OK : ����ɏI�����܂���
    '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
    '   1 : ���Ƀf�[�^�����݂��܂�
    '   2 : �Ώۃf�[�^�����݂��܂���
    '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������
    ' ----------------------------------------------
    '  2020/11/01 T.Ono mod 2020�Ď����P pstrTANID�ǉ�
    <WebMethod()> Public Function mSet(
                                    ByVal pintMODE As Integer,
                                    ByVal pstrKBN As String,
                                    ByVal pstrKURACD As String,
                                    ByVal pstrCODE As String,
                                    ByVal pstrTANCD_F As String,
                                    ByVal pstrTANCD_T As String,
                                    ByVal pstrTANCD() As String,
                                    ByVal pstrTANNM() As String,
                                    ByVal pstrTANID() As String,
                                    ByVal pstrDISP_NO() As String,
                                    ByVal pstrBIKO() As String,
                                    ByVal pstrDEL() As String,
                                    ByVal pstrADD_DATE() As String,
                                    ByVal pstrEDT_DATE() As String,
                                    ByVal pstrTIME() As String) As String

        ' ------------------------------
        '�z�����ŗp��
        Dim strTANCD() As String
        strTANCD = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        Dim strTANNM() As String
        strTANNM = New String(pstrTANNM.Length) {} '�z��̎��̂��m��
        Dim strTANID() As String                                        '2020/11/01 T.Ono add 2020�Ď����P
        strTANID = New String(pstrTANID.Length) {} '�z��̎��̂��m��    '2020/11/01 T.Ono add 2020�Ď����P
        Dim strDISP_NO() As String
        strDISP_NO = New String(pstrDISP_NO.Length) {} '�z��̎��̂��m��
        Dim strBIKO() As String
        strBIKO = New String(pstrBIKO.Length) {} '�z��̎��̂��m��
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '�z��̎��̂��m��
        Dim strADD_DATE() As String
        strADD_DATE = New String(pstrADD_DATE.Length) {} '�z��̎��̂��m��
        Dim strEDT_DATE() As String
        strEDT_DATE = New String(pstrEDT_DATE.Length) {} '�z��̎��̂��m��
        Dim strTIME() As String
        strTIME = New String(pstrTIME.Length) {} '�z��̎��̂��m��

        Dim i As Integer
        For i = 0 To strTANCD.Length
            strTANCD(i) = ""
            strTANNM(i) = ""
            strTANID(i) = ""    '2020/11/01 T.Ono add 2020�Ď����P
            strDISP_NO(i) = ""
            strBIKO(i) = ""
            strDEL(i) = ""
            strADD_DATE(i) = ""
            strEDT_DATE(i) = ""
            strTIME(i) = ""
        Next
        ' ------------------------------

        '2020/11/01 T.Ono mod 2020�Ď����P pstrTANID�ǉ�
        Return mSetEx(pintMODE,
                    pstrKBN,
                    pstrKURACD,
                    pstrCODE,
                    pstrTANCD_F,
                    pstrTANCD_T,
                    pstrTANCD,
                    pstrTANNM,
                    pstrTANID,
                    pstrDISP_NO,
                    pstrBIKO,
                    pstrDEL,
                    pstrADD_DATE,
                    pstrEDT_DATE,
                    pstrTIME)
    End Function

    '2020/11/01 T.Ono mod 2020�Ď����P pstrTANID()�ǉ�
    <WebMethod()> Public Function mSetEx(
                                    ByVal pintMODE As Integer,
                                    ByVal pstrKBN As String,
                                    ByVal pstrKURACD As String,
                                    ByVal pstrCODE As String,
                                    ByVal pstrTANCD_F As String,
                                    ByVal pstrTANCD_T As String,
                                    ByVal pstrTANCD() As String,
                                    ByVal pstrTANNM() As String,
                                    ByVal pstrTANID() As String,
                                    ByVal pstrDISP_NO() As String,
                                    ByVal pstrBIKO() As String,
                                    ByVal pstrDEL() As String,
                                    ByVal pstrADD_DATE() As String,
                                    ByVal pstrEDT_DATE() As String,
                                    ByVal pstrTIME() As String) As String
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
                mlog("loop:" & pstrDEL(i) & pstrCODE & "_" & pstrTANCD(i) & "_" & pstrTANID(i))

                '2020/11/01 T.Ono mod 2020�Ď����P pstrTANID(i)�ǉ�
                strRes = mSetTanto(
                        cdb,
                        pintMODE,
                        pstrKBN,
                        pstrKURACD,
                        pstrCODE,
                        pstrTANCD(i),
                        pstrTANNM(i),
                        pstrTANID(i),
                        pstrDISP_NO(i),
                        pstrBIKO(i),
                        pstrDEL(i),
                        pstrADD_DATE(i),
                        pstrEDT_DATE(i),
                        pstrTIME(i))

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
    '�S���҃}�X�^�X�V
    '************************************************
    '2020/11/01 T.Ono mod 2020�Ď����P pstrTANID�ǉ�
    <WebMethod()> Public Function mSetTanto(
                                ByRef cdb As CDB,
                                ByVal pintMODE As Integer,
                                ByVal pstrKBN As String,
                                ByVal pstrKURACD As String,
                                ByVal pstrCODE As String,
                                ByVal pstrTANCD As String,
                                ByVal pstrTANNM As String,
                                ByVal pstrTANID As String,
                                ByVal pstrDISP_NO As String,
                                ByVal pstrBIKO As String,
                                ByVal pstrDEL As String,
                                ByVal pstrADD_DATE As String,
                                ByVal pstrEDT_DATE As String,
                                ByVal pstrTIME As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim tmp As String
        Dim strEDT_DT As String

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
            strSQL.Append("  DISP_NO, ")
            strSQL.Append("  TANCD, ")
            strSQL.Append("  TANNM, ")
            strSQL.Append("  RENTEL1, ")
            strSQL.Append("  RENTEL2, ")
            strSQL.Append("  RENTEL3, ")                     '�d�b�ԍ��R
            strSQL.Append("  FAXNO, ")
            strSQL.Append("  BIKO, ")
            strSQL.Append("  EDT_DATE, ")                    '�X�V��
            strSQL.Append("  TIME, ")                        '�X�V����
            strSQL.Append("  AUTO_MAIL, ")                   '����FAX���M���[���A�h���X
            strSQL.Append("  GUIDELINE, ")                   'JA���ӎ���
            strSQL.Append("  FAXKURAKBN, ")                  'FAX�s�v(�ײ���)�敪
            strSQL.Append("  FAXKBN, ")                      'FAX�s�v(JA)�敪
            strSQL.Append("  SPOT_MAIL, ")                   'SPOT���[���ǉ�
            strSQL.Append("  MAIL_PASS, ")                    'Ұ��߽ܰ�ޒǉ�
            strSQL.Append("  AUTO_MAIL_PASS, ")             '����FAX�Y�ţ���߽ܰ��
            strSQL.Append("  AUTO_FAXNO, ")                 '����FAX�ԍ�
            strSQL.Append("  AUTO_KBN, ")                   '�������M�敪
            strSQL.Append("  AUTO_ZERO_FLG, ")              '�[�������M�t���O
            strSQL.Append("  AUTO_FAXNM ")                  '����FAX���M��d
            strSQL.Append("FROM ")
            strSQL.Append("  M05_TANTO ")                    '�S���҃}�X�^
            strSQL.Append("WHERE KBN  =:KBN  ")             '�敪
            strSQL.Append("  AND KURACD =:KURACD ")         '�N���C�A���g�R�[�h�i�Ď��E�o����ALL�uZ�v�j
            strSQL.Append("  AND CODE =:CODE ")             '�R�[�h(�Ď��Z���^�[�R�[�h�^�o����ЃR�[�h�^�i�`�x���R�[�h)
            strSQL.Append("  AND TANCD = :TANCD ")            '�S���҃R�[�h
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KBN") = pstrKBN               '�敪 "1"�Œ�
            cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h "ZZZZ"�Œ�
            cdb.pSQLParamStr("CODE") = pstrCODE             '�R�[�h�i�Ď��Z���^�[�R�[�h�j
            cdb.pSQLParamStr("TANCD") = pstrTANCD           '�S���҃R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 4 Then 'pintMODE=4(�폜)
                    If pstrDEL = "true" Then '�폜�Ώۃ`�F�b�N����H 
                        pintMODE = 3 '���[�h��3�F�폜
                    Else
                        pintMODE = 4 '���[�h��4�F�X�L�b�v
                    End If
                Else
                    pintMODE = 2 '���[�h��2�F�X�V
                End If
            Else
                If pstrTANCD = "" Then '�o�^���f�[�^�͂Ȃ��H
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                ElseIf pstrDEL = "true" Then
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                    strRes = "0"
                Else
                    pintMODE = 1 '���[�h��1�F�V�K
                End If
            End If


            If (pintMODE = 3) Then '�c�a�Ƀf�[�^�����݂��āA�폜�̏ꍇ
                '*******************************************
                '�폜���Ŏ󂯓n���ꂽ���t�y�ю��Ԃƍ폜�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                strEDT_DT = pstrEDT_DATE & pstrTIME
                If (tmp <> strEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If
            End If

            If (pintMODE = 2) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                strEDT_DT = pstrEDT_DATE & pstrTIME
                If (tmp <> strEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                '2020/11/01 T.Ono mod 2020�Ď����P�@TANID�̔�r��ǉ�
                If (
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("DISP_NO")) = pstrDISP_NO) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANCD")) = pstrTANCD) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE")) = pstrTANID) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO)
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If

            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If

            '�c�a�`�F�b�N-----------------------------------
            '�o�^�C�����A�Ď��Z���^�[�R�[�h�̑��݃`�F�b�N���s��
            If pintMODE = 1 OrElse pintMODE = 2 Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" KANSI_CD ")                     '�Ď��Z���^�[�R�[�h
                strSQL.Append("FROM ")
                strSQL.Append(" KANSIMAS ")                     '�Ď��Z���^�[�}�X�^
                strSQL.Append("WHERE KANSI_CD=:CODE ")          '�Ď��Z���^�[�R�[�h

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("CODE") = pstrCODE

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�Ď��Z���^�[�R�[�h�����݂��Ȃ���
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If


            '�f�[�^�̍X�V����--------------------------------

            If pintMODE = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("M05_TANTO ")                         '�S���҃}�X�^
                strSQL.Append("WHERE KBN  =:KBN  ")                 '�敪
                strSQL.Append("  AND KURACD =:KURACD ")             '�N���C�A���g�R�[�h
                strSQL.Append("  AND CODE =:CODE ")                 '�R�[�h
                strSQL.Append("  AND TANCD=:TANCD ")                '�S���҃R�[�h

            ElseIf pintMODE = 2 Then
                '�����敪���C��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("M05_TANTO ")
                strSQL.Append("SET ")
                strSQL.Append("KBN = :KBN, ")
                strSQL.Append("KURACD = :KURACD, ")
                strSQL.Append("CODE = :CODE, ")
                strSQL.Append("TANCD = :TANCD, ")
                strSQL.Append("TANNM = :TANNM, ")
                strSQL.Append("RENTEL1 = :RENTEL1, ")
                strSQL.Append("RENTEL2 = :RENTEL2, ")
                strSQL.Append("RENTEL3 = :RENTEL3, ")               '�d�b�ԍ��R
                strSQL.Append("FAXNO = :FAXNO, ")
                strSQL.Append("DISP_NO = :DISP_NO, ")
                strSQL.Append("BIKO = :BIKO, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME, ")
                strSQL.Append("AUTO_MAIL  = :AUTO_MAIL, ")          '����FAX���M���[���A�h���X
                strSQL.Append("GUIDELINE  = :GUIDELINE, ")          'JA���ӎ���
                strSQL.Append("FAXKURAKBN  = :FAXKURAKBN, ")        'FAX�s�v(�ײ���)�敪
                strSQL.Append("FAXKBN  = :FAXJAKBN, ")              'FAX�s�v(JA)�敪
                strSQL.Append("SPOT_MAIL = :SPOT_MAIL, ")           'SPOTҰْǉ�
                strSQL.Append("MAIL_PASS  = :MAIL_PASS, ")          'Ұ��߽ܰ�ޒǉ�
                strSQL.Append("AUTO_MAIL_PASS = :AUTO_MAIL_PASS, ") '����FAX�Y�ţ���߽ܰ��
                strSQL.Append("AUTO_FAXNO = :AUTO_FAXNO, ")         '����FAX�ԍ�
                strSQL.Append("AUTO_KBN = :AUTO_KBN, ")             '�������M�敪
                strSQL.Append("AUTO_ZERO_FLG = :AUTO_ZERO_FLG, ")   '�[�������M�t���O
                strSQL.Append("AUTO_FAXNM = :AUTO_FAXNM ")          '����FAX���M��
                strSQL.Append("WHERE   ")
                strSQL.Append("      KBN    =:KBN  ")               '�敪
                strSQL.Append("  AND KURACD =:KURACD ")             '�N���C�A���g�R�[�h
                strSQL.Append("  AND CODE   =:CODE ")               '�R�[�h
                strSQL.Append("  AND TANCD  =:TANCD ")              '�S���҃R�[�h

            ElseIf pintMODE = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("M05_TANTO (")
                strSQL.Append("KBN, ")
                strSQL.Append("KURACD, ")
                strSQL.Append("CODE, ")
                strSQL.Append("TANCD, ")
                strSQL.Append("TANNM, ")
                strSQL.Append("RENTEL1, ")
                strSQL.Append("RENTEL2, ")
                strSQL.Append("RENTEL3, ")          '�d�b�ԍ��R
                strSQL.Append("FAXNO, ")
                strSQL.Append("DISP_NO, ")
                strSQL.Append("BIKO, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME, ")
                strSQL.Append("AUTO_MAIL, ")
                strSQL.Append("GUIDELINE, ")
                strSQL.Append("FAXKURAKBN, ")
                strSQL.Append("FAXKBN, ")
                strSQL.Append("SPOT_MAIL, ")
                strSQL.Append("MAIL_PASS, ")
                strSQL.Append("AUTO_MAIL_PASS, ")   '����FAX�Y�ţ���߽ܰ��
                strSQL.Append("AUTO_FAXNO, ")       '����FAX�ԍ�
                strSQL.Append("AUTO_KBN, ")         '�������M�敪
                strSQL.Append("AUTO_ZERO_FLG, ")    '�[�������M�t���O
                strSQL.Append("AUTO_FAXNM ")        '����FAX���M��
                strSQL.Append(") VALUES(")
                strSQL.Append(":KBN, ")
                strSQL.Append(":KURACD, ")
                strSQL.Append(":CODE, ")
                strSQL.Append(":TANCD, ")
                strSQL.Append(":TANNM, ")
                strSQL.Append(":RENTEL1, ")
                strSQL.Append(":RENTEL2, ")
                strSQL.Append(":RENTEL3, ")         '�d�b�ԍ��R
                strSQL.Append(":FAXNO, ")
                strSQL.Append(":DISP_NO, ")
                strSQL.Append(":BIKO, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME, ")
                strSQL.Append(":AUTO_MAIL, ")
                strSQL.Append(":GUIDELINE, ")
                strSQL.Append(":FAXKURAKBN, ")
                strSQL.Append(":FAXJAKBN, ")
                strSQL.Append(":SPOT_MAIL, ")
                strSQL.Append(":MAIL_PASS, ")
                strSQL.Append(":AUTO_MAIL_PASS, ")  '����FAX�Y�ţ���߽ܰ��
                strSQL.Append(":AUTO_FAXNO, ")      '����FAX�ԍ�
                strSQL.Append(":AUTO_KBN, ")        '�������M�敪
                strSQL.Append(":AUTO_ZERO_FLG, ")   '�[�������M�t���O
                strSQL.Append(":AUTO_FAXNM ")       '����FAX���M��
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintMODE = 3 Then
                cdb.pSQLParamStr("KBN") = pstrKBN               '�敪�i1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S���ҁj
                cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h
                cdb.pSQLParamStr("CODE") = pstrCODE             '�R�[�h
                cdb.pSQLParamStr("TANCD") = pstrTANCD           '�S���҃R�[�h
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KBN") = pstrKBN               '�敪�i1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S���ҁj
                cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h
                cdb.pSQLParamStr("CODE") = pstrCODE             '�R�[�h
                cdb.pSQLParamStr("TANCD") = pstrTANCD           '�S���҃R�[�h
                cdb.pSQLParamStr("TANNM") = pstrTANNM           '�S���Җ�
                cdb.pSQLParamStr("RENTEL1") = ""                '�A���d�b�ԍ��P
                cdb.pSQLParamStr("RENTEL2") = ""                '�A���d�b�ԍ��Q
                cdb.pSQLParamStr("RENTEL3") = ""                '�A���d�b�ԍ��R
                cdb.pSQLParamStr("FAXNO") = ""                  'FAX�ԍ�
                cdb.pSQLParamStr("DISP_NO") = pstrDISP_NO       '�\������
                cdb.pSQLParamStr("BIKO") = pstrBIKO             '���l

                If pintMODE = 1 Then
                    '�V�K�o�^�̏ꍇ
                    cdb.pSQLParamStr("ADD_DATE") = Now.ToString("yyyyMMdd")
                    cdb.pSQLParamStr("EDT_DATE") = ""
                Else
                    '�C���o�^�̏ꍇ
                    cdb.pSQLParamStr("ADD_DATE") = pstrADD_DATE
                    cdb.pSQLParamStr("EDT_DATE") = Now.ToString("yyyyMMdd")
                End If
                cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")
                cdb.pSQLParamStr("AUTO_MAIL") = ""              '����FAX���M���[���A�h���X
                'cdb.pSQLParamStr("GUIDELINE") = ""              'JA���ӎ���    2020/11/01 T.Ono mod 2020�Ď����P 
                cdb.pSQLParamStr("GUIDELINE") = pstrTANID       '�S����ID
                cdb.pSQLParamStr("FAXKURAKBN") = ""             'FAX�s�v(�ײ���)�敪
                cdb.pSQLParamStr("FAXJAKBN") = ""               'FAX�s�v(JA)�敪
                cdb.pSQLParamStr("SPOT_MAIL") = ""              'SPOTҰْǉ�
                cdb.pSQLParamStr("MAIL_PASS") = ""              'Ұ��߽ܰ�ޒǉ�
                cdb.pSQLParamStr("AUTO_MAIL_PASS") = ""         '����FAX�Y�ţ���߽ܰ��
                cdb.pSQLParamStr("AUTO_FAXNO") = ""             '����FAX�ԍ�
                cdb.pSQLParamStr("AUTO_KBN") = ""               '�������M�敪
                cdb.pSQLParamStr("AUTO_ZERO_FLG") = ""          '�[�������M�t���O
                cdb.pSQLParamStr("AUTO_FAXNM") = ""             '����FAX�ԍ�

            End If

            'SQL�����s
            cdb.mExecNonQuery()


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
    '*�@�T�@�v:�ꗗ�̏o�͂��s���܂�
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrCODE As String, _
                                        ByVal pstrTANCD_F As String, _
                                        ByVal pstrTANCD_T As String _
                                        ) As String

        Dim strSQL As New StringBuilder("")
        Dim cdb As New CDB
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim CSVC As New CCSV                            'CSV�N���X
        'Dim compressC As New CCompress                  '���k�N���X
        'Dim DateFncC As New CDateFnc                    '���t�ϊ��N���X
        'Dim CTimeFncC As New CTimeFnc                   '���ԕϊ��N���X
        'Dim FileToStrC As New CFileStr                  '�t�@�C����Base64�ɃG���R�[�h����N���X
        
        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Try
            strSQL = New StringBuilder("")
            strSQL.Append(" SELECT ")
            strSQL.Append(" 	A.CODE ")
            strSQL.Append(" 	,A.TANCD ")
            strSQL.Append(" 	,A.TANNM ")
            strSQL.Append(" 	,A.GUIDELINE ")    '2020/11/01 T.Ono add 2020�Ď����P �S����ID�ǉ�
            strSQL.Append(" 	,A.DISP_NO ")
            strSQL.Append(" 	,A.BIKO ")
            strSQL.Append(" 	,A.ADD_DATE ")
            strSQL.Append(" 	,A.EDT_DATE ")
            strSQL.Append(" 	,A.TIME ")
            strSQL.Append(" FROM  ")
            strSQL.Append(" 	M05_TANTO A ")
            strSQL.Append(" WHERE 1=1 ")
            strSQL.Append(" AND	A.KBN = '1' ")
            strSQL.Append(" AND	A.KURACD = 'ZZZZ' ")
            strSQL.Append(" AND	A.CODE = :CODE ")
            If pstrTANCD_F.Length > 0 AndAlso pstrTANCD_T.Length > 0 Then
                strSQL.Append(" AND	TO_NUMBER(A.TANCD) >= TO_NUMBER(:TANCD_F) ")
                strSQL.Append(" AND	TO_NUMBER(A.TANCD) <= TO_NUMBER(:TANCD_T) ")
            End If
            strSQL.Append(" ORDER BY TO_NUMBER(A.TANCD) ")
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            '�Ď��Z���^�[�R�[�h
            If pstrCODE.Length > 0 Then
                cdb.pSQLParamStr("CODE") = pstrCODE
            End If
            '�S���҃R�[�hFrom
            If pstrTANCD_F.Length > 0 Then
                cdb.pSQLParamStr("TANCD_F") = pstrTANCD_F
            End If
            '�S���҃R�[�hTo
            If pstrTANCD_T.Length > 0 Then
                cdb.pSQLParamStr("TANCD_T") = pstrTANCD_T
            End If


            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '�f�[�^�������ꍇ�͏I��
            If ds.Tables(0).Rows.Count = 0 Then
                Return "DATA0"
            End If

            CSVC.pKencd = "00"
            CSVC.pSessionID = pstrSessionID   '�Z�b�V����ID
            CSVC.pRepoID = "MSTAKJAW00"       '���[ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "�Ď��Z���^�[�R�[�h"
                    CSVC.pColValStrEx = "�S���҃R�[�h"
                    CSVC.pColValStrEx = "�S���Җ�"
                    CSVC.pColValStrEx = "�S����ID"    '2020/11/01 T.Ono add 2020�Ď����P
                    CSVC.pColValStrEx = "�\����"
                    CSVC.pColValStrEx = "���l"
                    CSVC.pColValStrEx = "�o�^��"
                    CSVC.pColValStrEx = "�X�V��"
                    CSVC.pColValStrEx = "�X�V����"
                    CSVC.mWriteLine()
                End If

                For irCnt = 0 To dr.Table.Columns.Count - 1
                    CSVC.pColValStrEx = Convert.ToString(dr.Item(irCnt))
                    'CSVC.pColVal = "=""" & Convert.ToString(dr.Item(irCnt)) & """"
                Next
                CSVC.mWriteLine()
            Next
            CSVC.mClose()
            Return CSVC.pDirName & CSVC.pFileName
        Catch ex As Exception
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function
    '**********************************************************
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testKANSI" & System.DateTime.Today.ToString("yyyyMMdd")
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
