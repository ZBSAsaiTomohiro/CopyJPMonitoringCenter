'***********************************************
'JA�S���ҁE�A����E���ӎ����}�X�^
'***********************************************
' �ύX����
' 2015/11/04 T.Ono    2015���P�J�� �V�K�쐬

Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text


Imports System.Configuration
Imports System.IO

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAGJAW00/Service1")> _
Public Class MSTAGJAW00
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
    <WebMethod()> Public Function mSet( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrKBN As String, _
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrCODE As String, _
                                    ByVal pstrUSER_CD_FROM As String, _
                                    ByVal pstrUSER_CD_TO As String, _
                                    ByVal pstrTANCD() As String, _
                                    ByVal pstrTANNM() As String, _
                                    ByVal pstrRENTEL1() As String, _
                                    ByVal pstrRENTEL2() As String, _
                                    ByVal pstrRENTEL3() As String, _
                                    ByVal pstrFAXNO() As String, _
                                    ByVal pstrDISP_NO() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrADD_DATE As String, _
                                    ByVal pstrEDT_DATE As String, _
                                    ByVal pstrTIME As String, _
                                    ByVal pstrEDT_DT() As String) As String

        ' ------------------------------
        ' strAUTO_MAIL�z�����ŗp��
        Dim strAUTO_MAIL() As String
        strAUTO_MAIL = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        ' 2011/11/08 add H.Uema strGUIDELINE�z�����ŗp��
        Dim strGUIDELINE() As String
        strGUIDELINE = New String(pstrTANCD.Length) {} '�z��̎��Ԃ��m��
        ' 2011/11/29 add H.Uema strFAXKURAKBN�z�����ŗp��
        Dim strFAXKURAKBN() As String
        strFAXKURAKBN = New String(pstrTANCD.Length) {} '�z��̎��Ԃ��m��
        ' 2011/12/01 add H.Uema strFAXJAKBN�z�����ŗp��
        Dim strFAXJAKBN() As String
        strFAXJAKBN = New String(pstrTANCD.Length) {} '�z��̎��Ԃ��m��
        ' 2012/03/23 ADD W.GANEKO strSPOT_MAIL�z�����ŗp��
        Dim strSPOT_MAIL() As String
        strSPOT_MAIL = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        ' 2012/03/23 ADD W.GANEKO strMAIL_PASS�z�����ŗp��
        Dim strMAIL_PASS() As String
        strMAIL_PASS = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        ' 2012/05/23 ADD T.ONO pstrAUTO_MAIL_PASS�z�����ŗp��
        Dim pstrAUTO_MAIL_PASS() As String
        pstrAUTO_MAIL_PASS = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        ' 2012/05/23 ADD T.ONO pstrAUTO_FAXNO�z�����ŗp��
        Dim pstrAUTO_FAXNO() As String
        pstrAUTO_FAXNO = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        ' 2012/07/18 ADD T.ONO pstrAUTO_FAXNM�z�����ŗp��
        Dim pstrAUTO_FAXNM() As String
        pstrAUTO_FAXNM = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        ' 2012/05/23 ADD T.ONO pstrAUTO_KBN�z�����ŗp��
        Dim pstrAUTO_KBN() As String
        pstrAUTO_KBN = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        ' 2012/05/23 ADD T.ONO pstrAUTO_ZERO_FLG�z�����ŗp��
        Dim pstrAUTO_ZERO_FLG() As String
        pstrAUTO_ZERO_FLG = New String(pstrTANCD.Length) {} '�z��̎��̂��m��
        Dim i As Integer
        For i = 0 To strAUTO_MAIL.Length
            strAUTO_MAIL(i) = ""
            strGUIDELINE(i) = ""
            strFAXKURAKBN(i) = ""
            strSPOT_MAIL(i) = ""
            strMAIL_PASS(i) = ""
            pstrAUTO_MAIL_PASS(i) = ""
            pstrAUTO_FAXNO(i) = ""
            pstrAUTO_FAXNM(i) = ""
            pstrAUTO_KBN(i) = ""
            pstrAUTO_ZERO_FLG(i) = ""
        Next
        ' ------------------------------

        'Return mSetEx(pintMODE, _
        '            pstrKBN, _
        '            pstrKURACD, _
        '            pstrCODE, _
        '            pstrUSER_CD_FROM, _
        '            pstrUSER_CD_TO, _
        '            pstrTANCD, _
        '            pstrTANNM, _
        '            pstrRENTEL1, _
        '            pstrRENTEL2, _
        '            pstrRENTEL3, _
        '            pstrFAXNO, _
        '            pstrDISP_NO, _
        '            pstrBIKO, _
        '            pstrADD_DATE, _
        '            pstrEDT_DATE, _
        '            pstrTIME, _
        '            pstrEDT_DT, _
        '            strAUTO_MAIL, _
        '            strGUIDELINE, _
        '            strFAXKURAKBN, _
        '            strFAXJAKBN, _
        '            strSPOT_MAIL, _
        '            strMAIL_PASS, _
        '            pstrAUTO_MAIL_PASS, _
        '            pstrAUTO_FAXNO, _
        '            pstrAUTO_FAXNM, _
        '            pstrAUTO_KBN, _
        '            pstrAUTO_ZERO_FLG)
    End Function

    '2020/11/01 T.Ono mod 2020�Ď����P pstrSD_PRT_FLG�ǉ�
    <WebMethod()> Public Function mSetEx(
                                    ByVal pintMODE As Integer,
                                    ByVal pstrDBKBN As String,
                                    ByVal pstrGROUPCD As String,
                                    ByVal pstrGROUPNM() As String,
                                    ByVal pstrTANCD() As String,
                                    ByVal pstrTANNM() As String,
                                    ByVal pstrRENTEL1() As String,
                                    ByVal pstrRENTEL2() As String,
                                    ByVal pstrRENTEL3() As String,
                                    ByVal pstrFAXNO() As String,
                                    ByVal pstrBIKO() As String,
                                    ByVal pstrSPOT_MAIL() As String,
                                    ByVal pstrMAIL_PASS() As String,
                                    ByVal pstrAUTO_FAXNM() As String,
                                    ByVal pstrAUTO_MAIL() As String,
                                    ByVal pstrAUTO_MAIL_PASS() As String,
                                    ByVal pstrAUTO_FAXNO() As String,
                                    ByVal pstrAUTO_KBN() As String,
                                    ByVal pstrAUTO_ZERO_FLG() As String,
                                    ByVal pstrSD_PRT_FLG() As String,               '2020/11/01 T.Ono 2020�Ď����P
                                    ByVal pstrGUIDELINE() As String,
                                    ByVal pstrGUIDELINE2() As String,                '2019/11/01 w.ganeko 2019�Ď����P
                                    ByVal pstrGUIDELINE3() As String,                '2019/11/01 w.ganeko 2019�Ď����P
                                    ByVal pstrGUIDELINENM1() As String,             '2020/11/01 T.Ono 2020�Ď����P
                                    ByVal pstrGUIDELINENM2() As String,             '2020/11/01 T.Ono 2020�Ď����P
                                    ByVal pstrGUIDELINENM3() As String,             '2020/11/01 T.Ono 2020�Ď����P
                                    ByVal pstrFAXKURAKBN() As String,
                                    ByVal pstrFAXJAKBN() As String,
                                    ByVal pstrINS_DATE() As String,
                                    ByVal pstrINS_USER() As String,
                                    ByVal pstrUPD_DATE() As String,
                                    ByVal pstrUPD_USER() As String,
                                    ByVal pstrUSERNM As String) As String

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

                strRes = mSetTanto(
                                cdb,
                                pintMODE,
                                pstrDBKBN,
                                pstrGROUPCD,
                                pstrGROUPNM(i),
                                pstrTANCD(i),
                                pstrTANNM(i),
                                pstrRENTEL1(i),
                                pstrRENTEL2(i),
                                pstrRENTEL3(i),
                                pstrFAXNO(i),
                                pstrBIKO(i),
                                pstrSPOT_MAIL(i),
                                pstrMAIL_PASS(i),
                                pstrAUTO_FAXNM(i),
                                pstrAUTO_MAIL(i),
                                pstrAUTO_MAIL_PASS(i),
                                pstrAUTO_FAXNO(i),
                                pstrAUTO_KBN(i),
                                pstrAUTO_ZERO_FLG(i),
                                pstrSD_PRT_FLG(i),                      '2020/11/01 T.Ono 2020�Ď����P
                                pstrGUIDELINE(i),
                                pstrGUIDELINE2(i),                     '2019/11/01 w.ganeko 2019�Ď����P      
                                pstrGUIDELINE3(i),                     '2019/11/01 w.ganeko 2019�Ď����P
                                pstrGUIDELINENM1(i),                    '2020/11/01 T.Ono 2020�Ď����P
                                pstrGUIDELINENM2(i),                    '2020/11/01 T.Ono 2020�Ď����P
                                pstrGUIDELINENM3(i),                    '2020/11/01 T.Ono 2020�Ď����P
                                pstrFAXKURAKBN(i),
                                pstrFAXJAKBN(i),
                                pstrINS_DATE(i),
                                pstrINS_USER(i),
                                pstrUPD_DATE(i),
                                pstrUPD_USER(i),
                                pstrUSERNM)



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
    <WebMethod()> Public Function mSetTanto(
                                ByRef cdb As CDB,
                                ByVal pintMODE As Integer,
                                ByVal pstrDBKBN As String,
                                ByVal pstrGROUPCD As String,
                                ByVal pstrGROUPNM As String,
                                ByVal pstrTANCD As String,
                                ByVal pstrTANNM As String,
                                ByVal pstrRENTEL1 As String,
                                ByVal pstrRENTEL2 As String,
                                ByVal pstrRENTEL3 As String,
                                ByVal pstrFAXNO As String,
                                ByVal pstrBIKO As String,
                                ByVal pstrSPOT_MAIL As String,
                                ByVal pstrMAIL_PASS As String,
                                ByVal pstrAUTO_FAXNM As String,
                                ByVal pstrAUTO_MAIL As String,
                                ByVal pstrAUTO_MAIL_PASS As String,
                                ByVal pstrAUTO_FAXNO As String,
                                ByVal pstrAUTO_KBN As String,
                                ByVal pstrAUTO_ZERO_FLG As String,
                                ByVal pstrSD_PRT_FLG As String,             '2020/11/01 T.Ono add 2020�Ď����P
                                ByVal pstrGUIDELINE As String,
                                ByVal pstrGUIDELINE2 As String,            '2019/11/01 w.ganeko 2019�Ď����P
                                ByVal pstrGUIDELINE3 As String,            '2019/11/01 w.ganeko 2019�Ď����P
                                ByVal pstrGUIDELINENM1 As String,           '2020/11/01 T.Ono add 2020�Ď����P
                                ByVal pstrGUIDELINENM2 As String,           '2020/11/01 T.Ono add 2020�Ď����P
                                ByVal pstrGUIDELINENM3 As String,           '2020/11/01 T.Ono add 2020�Ď����P
                                ByVal pstrFAXKURAKBN As String,
                                ByVal pstrFAXJAKBN As String,
                                ByVal pstrINS_DATE As String,
                                ByVal pstrINS_USER As String,
                                ByVal pstrUPD_DATE As String,
                                ByVal pstrUPD_USER As String,
                                ByVal pstrUSERNM As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

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
            strSQL.Append("	    KBN, ")
            strSQL.Append("	    GROUPCD, ")
            strSQL.Append("	    GROUPNM, ")
            strSQL.Append("	    TANCD, ")
            strSQL.Append("	    TANNM, ")
            strSQL.Append("	    RENTEL1, ")
            strSQL.Append("	    RENTEL2, ")
            strSQL.Append("	    RENTEL3, ")
            strSQL.Append("	    FAXNO, ")
            strSQL.Append("	    BIKO, ")
            strSQL.Append("	    SPOT_MAIL, ")
            strSQL.Append("	    MAIL_PASS, ")
            strSQL.Append("	    AUTO_FAXNM, ")
            strSQL.Append("	    AUTO_MAIL, ")
            strSQL.Append("	    AUTO_MAIL_PASS, ")
            strSQL.Append("	    AUTO_FAXNO, ")
            strSQL.Append("	    AUTO_KBN, ")
            strSQL.Append("	    AUTO_ZERO_FLG, ")
            strSQL.Append("	    SD_PRT_FLG, ")          '2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("	    GUIDELINE, ")
            strSQL.Append("	    GUIDELINE2, ")          '2019/11/01 w.ganeko 2019�Ď����P
            strSQL.Append("	    GUIDELINE3, ")          '2019/11/01 w.ganeko 2019�Ď����P
            strSQL.Append("	    GUIDELINENM1, ")        '2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("	    GUIDELINENM2, ")        '2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("	    GUIDELINENM3, ")        '2020/11/01 T.Ono add 2020�Ď����P
            strSQL.Append("	    FAXKURAKBN, ")
            strSQL.Append("	    FAXKBN, ")
            strSQL.Append("	    INS_DATE, ")
            strSQL.Append("	    INS_USER, ")
            strSQL.Append("	    UPD_DATE, ")
            strSQL.Append("	    UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M11_JAHOKOKU ")
            strSQL.Append("WHERE	KBN = :KBN ")
            strSQL.Append("AND	    GROUPCD = :GROUPCD ")
            strSQL.Append("AND	    LPAD(TANCD,2,'0') = :TANCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KBN") = pstrDBKBN             '�敪
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       '�O���[�v�R�[�h
            cdb.pSQLParamStr("TANCD") = pstrTANCD           '�S���҃R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pstrTANNM = "" Then '�o�^���f�[�^�͂Ȃ��H
                    pintMODE = 3 '���[�h��3�F�폜
                Else
                    pintMODE = 2 '���[�h��2�F�X�V
                End If
            Else
                If pstrTANNM = "" Then '�o�^���f�[�^�͂Ȃ��H
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                Else
                    pintMODE = 1 '���[�h��1�F�V�K
                End If
            End If


            If (pintMODE = 2) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If (
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANCD")) = pstrTANCD) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) = pstrRENTEL1) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2")) = pstrRENTEL2) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3")) = pstrRENTEL3) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXNO")) = pstrFAXNO) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("SPOT_MAIL")) = pstrSPOT_MAIL) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL_PASS")) = pstrMAIL_PASS) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNM")) = pstrAUTO_FAXNM) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL")) = pstrAUTO_MAIL) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL_PASS")) = pstrAUTO_MAIL_PASS) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNO")) = pstrAUTO_FAXNO) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_KBN")) = pstrAUTO_KBN) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_ZERO_FLG")) = pstrAUTO_ZERO_FLG) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("SD_PRT_FLG")) = pstrSD_PRT_FLG) And       '2020/11/01 T.Ono add 2020�Ď����P
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE")) = pstrGUIDELINE) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE2")) = pstrGUIDELINE2) And      '2019/11/01 w.ganeko 2019�Ď����P
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE3")) = pstrGUIDELINE3) And      '2019/11/01 w.ganeko 2019�Ď����P
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINENM1")) = pstrGUIDELINENM1) And   '2020/11/01 T.Ono add 2020�Ď����P
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINENM2")) = pstrGUIDELINENM2) And   '2020/11/01 T.Ono add 2020�Ď����P
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINENM3")) = pstrGUIDELINENM3) And   '2020/11/01 T.Ono add 2020�Ď����P
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKURAKBN")) = pstrFAXKURAKBN) And
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKBN")) = pstrFAXJAKBN)
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If


            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If

            '�c�a�`�F�b�N-----------------------------------
            'DBKBN=2,�O���[�v�R�[�h�o�^�̂Ƃ��̃`�F�b�N
            '�O���[�v�R�[�h�̃`�F�b�N�Ȃ̂ŁATANCD=01�̂Ƃ������`�F�b�N����
            If pstrDBKBN = "2" AndAlso pstrTANCD = "01" Then
                '�폜��
                If (pintMODE = 3) Then
                    '*******************************************
                    'JA�O���[�v�쐬�}�X�^�Ŏg���Ă��Ȃ����`�F�b�N
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT 'X'")
                    strSQL.Append("FROM ")
                    strSQL.Append("     M09_JAGROUP A ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("     A.KBN = '002' ")
                    strSQL.Append("AND	A.GROUPCD = :GROUPCD ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString
                    '�o�C���h�ϐ��ɒl���Z�b�g
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    'SQL���s
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count > 0) Then
                        '*******************************************
                        'JA�O���[�v�쐬�}�X�^�Ŏg�p����Ă���
                        '*******************************************
                        strRes = "4"
                        Exit Try
                    End If
                End If

                '�o�^/�X�V��
                If (pintMODE = 1 Or pintMODE = 2) Then
                    '*******************************************
                    '�������̃`�F�b�N
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("	A.CD ")
                    strSQL.Append("	,A.NAME ")
                    strSQL.Append("	,A.NAIYO1 ")
                    strSQL.Append("	,A.NAIYO2 ")
                    strSQL.Append("FROM ")
                    strSQL.Append("		M06_PULLDOWN A ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("		KBN = '78' ")
                    strSQL.Append("AND	CD = '002' ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString

                    'SQL���s
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count = 0) Then
                        '*******************************************
                        '�v���_�E���}�X�^�ɓo�^�����݂��Ȃ���
                        '*******************************************
                        strRes = "5"
                        Exit Try
                    Else
                        If Convert.ToString(ds.Tables(0).Rows(0).Item("NAIYO1")) <> pstrGROUPCD.Substring(0, 2) Then
                            '*******************************************
                            '�������ᔽ�i�O���[�v�R�[�h�̐擪��NAIYO1�����ĂȂ��j
                            '*******************************************
                            strRes = "6"
                            Exit Try
                        End If
                    End If
                End If
            End If

            '�O���[�v�R�[�h���̏d����NG�Ƃ��� 2016/01/12 T.Ono add 2015���P�J�� 
            '�o�^/�X�V��
            If (pintMODE = 1 Or pintMODE = 2) Then
                '�S���҃R�[�h01�A�O���[�v�R�[�h�����͂���̏ꍇ�Ƀ`�F�b�N
                If pstrTANCD = "01" AndAlso pstrGROUPNM.Trim.Length > 0 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("     'X' ")
                    strSQL.Append("FROM ")
                    strSQL.Append("		M11_JAHOKOKU A ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("		1 = 1 ")
                    strSQL.Append("AND	LPAD(A.TANCD,2,'0') = :TANCD ")
                    strSQL.Append("AND	A.GROUPCD <> :GROUPCD ")
                    strSQL.Append("AND	A.GROUPNM = :GROUPNM ")

                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString
                    '�o�C���h�ϐ��ɒl���Z�b�g
                    cdb.pSQLParamStr("TANCD") = pstrTANCD           '�S���҃R�[�h
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       '�O���[�v�R�[�h
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM       '�O���[�v�R�[�h��

                    'SQL���s
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count > 0) Then
                        '*******************************************
                        '�O���[�v�R�[�h���d��
                        '*******************************************
                        strRes = "7"
                        Exit Try
                    End If
                End If

            End If


            '�f�[�^�̍X�V����--------------------------------

            If pintMODE = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("     M11_JAHOKOKU ")                 'JA�S���ҁE�񍐐�E���ӎ����}�X�^
                strSQL.Append("WHERE KBN  =:KBN  ")                 '�敪
                strSQL.Append("AND  GROUPCD =:GROUPCD ")            '�N���C�A���g�R�[�h
                strSQL.Append("AND  LPAD(TANCD,2,'0')=:TANCD ")     '�S���҃R�[�h

            ElseIf pintMODE = 2 Then
                '�����敪���C��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("     M11_JAHOKOKU ")
                strSQL.Append("SET ")
                strSQL.Append("     KBN = :KBN, ")
                strSQL.Append("     GROUPCD = :GROUPCD, ")
                strSQL.Append("     GROUPNM = :GROUPNM, ")
                strSQL.Append("     TANCD = :TANCD, ")
                strSQL.Append("     TANNM = :TANNM, ")
                strSQL.Append("     RENTEL1 = :RENTEL1, ")
                strSQL.Append("     RENTEL2 = :RENTEL2, ")
                strSQL.Append("     RENTEL3 = :RENTEL3, ")
                strSQL.Append("     FAXNO = :FAXNO, ")
                strSQL.Append("     BIKO = :BIKO, ")
                strSQL.Append("     SPOT_MAIL = :SPOT_MAIL, ")
                strSQL.Append("     MAIL_PASS  = :MAIL_PASS, ")
                strSQL.Append("     AUTO_FAXNM = :AUTO_FAXNM, ")
                strSQL.Append("     AUTO_MAIL  = :AUTO_MAIL, ")
                strSQL.Append("     AUTO_MAIL_PASS = :AUTO_MAIL_PASS, ")
                strSQL.Append("     AUTO_FAXNO = :AUTO_FAXNO, ")
                strSQL.Append("     AUTO_KBN = :AUTO_KBN, ")
                strSQL.Append("     AUTO_ZERO_FLG = :AUTO_ZERO_FLG, ")
                strSQL.Append("     SD_PRT_FLG = :SD_PRT_FLG, ")        '2020/11/01 T.Ono 2020�Ď����P
                strSQL.Append("     GUIDELINE  = :GUIDELINE, ")
                strSQL.Append("     GUIDELINE2  = :GUIDELINE2, ")     '2019/11/01 w.ganeko 2019�Ď����P
                strSQL.Append("     GUIDELINE3  = :GUIDELINE3, ")     '2019/11/01 w.ganeko 2019�Ď����P
                strSQL.Append("     GUIDELINENM1  = :GUIDELINENM1, ")   '2020/11/01 T.Ono 2020�Ď����P
                strSQL.Append("     GUIDELINENM2  = :GUIDELINENM2, ")   '2020/11/01 T.Ono 2020�Ď����P
                strSQL.Append("     GUIDELINENM3  = :GUIDELINENM3, ")   '2020/11/01 T.Ono 2020�Ď����P
                strSQL.Append("     FAXKURAKBN  = :FAXKURAKBN, ")
                strSQL.Append("     FAXKBN  = :FAXJAKBN, ")
                strSQL.Append("     INS_DATE   = TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     INS_USER   = :INS_USER, ")
                strSQL.Append("     UPD_DATE   = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     UPD_USER   = :UPD_USER ")
                strSQL.Append("WHERE ")
                strSQL.Append("     KBN    = :KBN ")                    '�敪
                strSQL.Append("AND  GROUPCD = :GROUPCD ")               '�O���[�v�R�[�h
                strSQL.Append("AND  LPAD(TANCD,2,'0')= :TANCD ")        '�S���҃R�[�h

            ElseIf pintMODE = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append(" M11_JAHOKOKU (")
                strSQL.Append("     KBN, ")
                strSQL.Append("     GROUPCD, ")
                strSQL.Append("     GROUPNM, ")
                strSQL.Append("     TANCD, ")
                strSQL.Append("     TANNM, ")
                strSQL.Append("     RENTEL1, ")
                strSQL.Append("     RENTEL2, ")
                strSQL.Append("     RENTEL3, ")
                strSQL.Append("     FAXNO, ")
                strSQL.Append("     BIKO, ")
                strSQL.Append("     SPOT_MAIL, ")
                strSQL.Append("     MAIL_PASS, ")
                strSQL.Append("     AUTO_FAXNM, ")
                strSQL.Append("     AUTO_MAIL, ")
                strSQL.Append("     AUTO_MAIL_PASS, ")
                strSQL.Append("     AUTO_FAXNO, ")
                strSQL.Append("     AUTO_KBN, ")
                strSQL.Append("     AUTO_ZERO_FLG, ")
                strSQL.Append("     SD_PRT_FLG, ")          '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("     GUIDELINE, ")
                strSQL.Append("     GUIDELINE2, ")          '2019/11/01 w.ganeko 2019�Ď����P
                strSQL.Append("     GUIDELINE3, ")          '2019/11/01 w.ganeko 2019�Ď����P
                strSQL.Append("     GUIDELINENM1, ")        '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("     GUIDELINENM2, ")        '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("     GUIDELINENM3, ")        '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("     FAXKURAKBN, ")
                strSQL.Append("     FAXKBN, ")
                strSQL.Append("     INS_DATE, ")
                strSQL.Append("     INS_USER, ")
                strSQL.Append("     UPD_DATE, ")
                strSQL.Append("     UPD_USER ")
                strSQL.Append(") VALUES( ")
                strSQL.Append("     :KBN, ")
                strSQL.Append("     :GROUPCD, ")
                strSQL.Append("     :GROUPNM, ")
                strSQL.Append("     LPAD(:TANCD,2,'0'), ")
                strSQL.Append("     :TANNM, ")
                strSQL.Append("     :RENTEL1, ")
                strSQL.Append("     :RENTEL2, ")
                strSQL.Append("     :RENTEL3, ")
                strSQL.Append("     :FAXNO, ")
                strSQL.Append("     :BIKO, ")
                strSQL.Append("     :SPOT_MAIL, ")
                strSQL.Append("     :MAIL_PASS, ")
                strSQL.Append("     :AUTO_FAXNM, ")
                strSQL.Append("     :AUTO_MAIL, ")
                strSQL.Append("     :AUTO_MAIL_PASS, ")
                strSQL.Append("     :AUTO_FAXNO, ")
                strSQL.Append("     :AUTO_KBN, ")
                strSQL.Append("     :AUTO_ZERO_FLG, ")
                strSQL.Append("     :SD_PRT_FLG, ")         '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("     :GUIDELINE, ")
                strSQL.Append("     :GUIDELINE2, ")         '2019/11/01 w.ganeko 2019�Ď����P
                strSQL.Append("     :GUIDELINE3, ")         '2019/11/01 w.ganeko 2019�Ď����P
                strSQL.Append("     :GUIDELINENM1, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("     :GUIDELINENM2, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("     :GUIDELINENM3, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("     :FAXKURAKBN, ")
                strSQL.Append("     :FAXJAKBN, ")
                strSQL.Append("     TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     :INS_USER, ")
                strSQL.Append("     TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     :UPD_USER ")
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintMODE = 3 Then
                cdb.pSQLParamStr("KBN") = pstrDBKBN                     '�敪�i1:�N���C�A���g�o�^�@2:�O���[�v�R�[�h�o�^�j
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD               '�N���C�A���g�R�[�h�^�O���[�v�R�[�h
                cdb.pSQLParamStr("TANCD") = pstrTANCD                   '�S���҃R�[�h
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KBN") = pstrDBKBN                       '�敪�i1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S���ҁj
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD               '�O���[�v�R�[�h
                cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM               '�O���[�v�R�[�h��
                cdb.pSQLParamStr("TANCD") = pstrTANCD                   '�S���҃R�[�h
                cdb.pSQLParamStr("TANNM") = pstrTANNM                   '�S���Җ�
                cdb.pSQLParamStr("RENTEL1") = pstrRENTEL1               '�A���d�b�ԍ��P
                cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2               '�A���d�b�ԍ��Q
                cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3               '�A���d�b�ԍ��R
                cdb.pSQLParamStr("FAXNO") = pstrFAXNO                   'FAX�ԍ�
                cdb.pSQLParamStr("BIKO") = pstrBIKO                     '���l
                cdb.pSQLParamStr("SPOT_MAIL") = pstrSPOT_MAIL           'SPOTҰ�
                cdb.pSQLParamStr("MAIL_PASS") = pstrMAIL_PASS           'Ұ��߽ܰ��
                cdb.pSQLParamStr("AUTO_FAXNM") = pstrAUTO_FAXNM         '����FAX�ԍ�
                cdb.pSQLParamStr("AUTO_MAIL") = pstrAUTO_MAIL           '����FAX���M���[���A�h���X
                cdb.pSQLParamStr("AUTO_MAIL_PASS") = pstrAUTO_MAIL_PASS '����FAX�Y�ţ���߽ܰ�
                cdb.pSQLParamStr("AUTO_FAXNO") = pstrAUTO_FAXNO         '����FAX�ԍ�
                cdb.pSQLParamStr("AUTO_KBN") = pstrAUTO_KBN             '�������M�敪
                cdb.pSQLParamStr("AUTO_ZERO_FLG") = pstrAUTO_ZERO_FLG   '�[�������M�t���O
                cdb.pSQLParamStr("SD_PRT_FLG") = pstrSD_PRT_FLG         '�o���˗����e�E���l�\���t���O  '2020/11/01 T.Ono add 2020�Ď����P
                cdb.pSQLParamStr("GUIDELINE") = pstrGUIDELINE           'JA���ӎ���1
                cdb.pSQLParamStr("GUIDELINE2") = pstrGUIDELINE2         'JA���ӎ���2   '2019/11/01 w.ganeko 2019�Ď����P
                cdb.pSQLParamStr("GUIDELINE3") = pstrGUIDELINE3         'JA���ӎ���3   '2019/11/01 w.ganeko 2019�Ď����P
                cdb.pSQLParamStr("GUIDELINENM1") = pstrGUIDELINENM1     'JA���ӎ���1�{�^����    '2020/10/05 T.Ono 2020�Ď����P
                cdb.pSQLParamStr("GUIDELINENM2") = pstrGUIDELINENM2     'JA���ӎ���2�{�^����    '2020/10/05 T.Ono 2020�Ď����P�@
                cdb.pSQLParamStr("GUIDELINENM3") = pstrGUIDELINENM3     'JA���ӎ���3�{�^����    '2020/10/05 T.Ono 2020�Ď����P
                cdb.pSQLParamStr("FAXKURAKBN") = pstrFAXKURAKBN         'FAX�s�v(�ײ���)�敪
                cdb.pSQLParamStr("FAXJAKBN") = pstrFAXJAKBN             'FAX�s�v(JA)�敪

                If pintMODE = 1 Then
                    '�V�K�o�^�̏ꍇ
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                Else
                    '�C���o�^�̏ꍇ
                    cdb.pSQLParamStr("INS_DATE") = pstrINS_DATE
                    cdb.pSQLParamStr("INS_USER") = pstrINS_USER
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim
                End If

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
    '**********************************************************
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "testGroup" & System.DateTime.Today.ToString("yyyyMMdd")
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
