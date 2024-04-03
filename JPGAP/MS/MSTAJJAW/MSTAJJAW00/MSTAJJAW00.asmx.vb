'***********************************************
'�S���҃}�X�^
'***********************************************
' �ύX����
' 2010/04/14 T.Watabe 10������30���ɑ���
' 2010/04/14 T.Watabe ����t���O��ǉ�
' 2011/04/14 T.Watabe ����FAX���M���[���A�h���X���ڂ�ǉ�
' 2011/11/08 H.Uema   JA���ӎ������ڂ�ǉ�
' 2011/11/29 H.Uema   FAX�s�v(�ײ���)���ڂ�ǉ�
' 2011/12/01 H.Uema   FAX�s�v(JA)���ڂ�ǉ�
' 2012/03/23 W.GANEKO �X�|�b�g���[���A�h���X���ڒǉ�
' 2013/05/23 T.Ono    �ڋq�P�ʓo�^�@�\�ǉ�

Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTAJJAW00/Service1")> _
Public Class MSTAJJAW00
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
    ' 2011/04/14 T.Watabe add ������mSet�ƕʂ�mSetEx���쐬
    ' 2011/11/08 H.Uema modify mSetEx�p�����[�^�ύX�ɔ����C��(���ӎ����ǉ�)
    ' 2011/11/29 H.Uema modify mSetEx�p�����[�^�ύX�ɔ����C��(FAX�s�v(�ײ���)�敪�ǉ�)
    ' 2011/12/01 H.Uema modify mSetEx�p�����[�^�ύX�ɔ����C��(FAX�s�v(JA)�敪�ǉ�)
    ' 2013/05/23 T.Ono modify �ڋq�P�ʓo�^�@�\�ǉ� 
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

        Return mSetEx(pintMODE, _
                    pstrKBN, _
                    pstrKURACD, _
                    pstrCODE, _
                    pstrUSER_CD_FROM, _
                    pstrUSER_CD_TO, _
                    pstrTANCD, _
                    pstrTANNM, _
                    pstrRENTEL1, _
                    pstrRENTEL2, _
                    pstrRENTEL3, _
                    pstrFAXNO, _
                    pstrDISP_NO, _
                    pstrBIKO, _
                    pstrADD_DATE, _
                    pstrEDT_DATE, _
                    pstrTIME, _
                    pstrEDT_DT, _
                    strAUTO_MAIL, _
                    strGUIDELINE, _
                    strFAXKURAKBN, _
                    strFAXJAKBN, _
                    strSPOT_MAIL, _
                    strMAIL_PASS, _
                    pstrAUTO_MAIL_PASS, _
                    pstrAUTO_FAXNO, _
                    pstrAUTO_FAXNM, _
                    pstrAUTO_KBN, _
                    pstrAUTO_ZERO_FLG)
    End Function

    <WebMethod()> Public Function mSetEx( _
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
                                    ByVal pstrEDT_DT() As String, _
                                    ByVal pstrAUTO_MAIL() As String, _
                                    ByVal pstrGUIDELINE() As String, _
                                    ByVal pstrFAXKURAKBN() As String, _
                                    ByVal pstrFAXJAKBN() As String, _
                                    ByVal pstrSPOT_MAIL() As String, _
                                    ByVal pstrMAIL_PASS() As String, _
                                    ByVal pstrAUTO_MAIL_PASS() As String, _
                                    ByVal pstrAUTO_FAXNO() As String, _
                                    ByVal pstrAUTO_FAXNM() As String, _
                                    ByVal pstrAUTO_KBN() As String, _
                                    ByVal pstrAUTO_ZERO_FLG() As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

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
            'For i = 1 To 10 '10�����P�����o�^�^�C���^�폜����B ' 2010/04/14 T.Watabe edit
            For i = 1 To 30 '30�����P�����o�^�^�C���^�폜����B
                '2011/04/14 T.Watabe add pstrAUTO_MAIL�ǉ�
                '2011/11/08 H.Uema add JA���ӎ����ǉ�
                '2011/11/29 H.Uema add FAX�s�v(�ײ���)�敪�ǉ�
                '2011/12/01 H.Uema add FAX�s�v(JA)�敪�ǉ�
                '2012/03/23 W.GANEKO add SPOT���[���ǉ�
                '2013/05/23 T.Ono mod  �ڋq�P�ʓo�^�@�\�ǉ� ��������
                If pstrUSER_CD_FROM = "" Then
                    strRes = mSetTanto( _
                            cdb, _
                            pintMODE, _
                            pstrKBN, _
                            pstrKURACD, _
                            pstrCODE, _
                            pstrTANCD(i), _
                            pstrTANNM(i), _
                            pstrRENTEL1(i), _
                            pstrRENTEL2(i), _
                            pstrRENTEL3(i), _
                            pstrFAXNO(i), _
                            pstrDISP_NO(i), _
                            pstrBIKO(i), _
                            pstrADD_DATE, _
                            pstrEDT_DATE, _
                            pstrTIME, _
                            pstrEDT_DT(i), _
                            pstrAUTO_MAIL(i), _
                            pstrGUIDELINE(i), _
                            pstrFAXKURAKBN(i), _
                            pstrFAXJAKBN(i), _
                            pstrSPOT_MAIL(i), _
                            pstrMAIL_PASS(i), _
                            pstrAUTO_MAIL_PASS(i), _
                            pstrAUTO_FAXNO(i), _
                            pstrAUTO_FAXNM(i), _
                            pstrAUTO_KBN(i), _
                            pstrAUTO_ZERO_FLG(i))

                Else
                    strRes = mSetTanto2( _
                            cdb, _
                            pintMODE, _
                            pstrKBN, _
                            pstrKURACD, _
                            pstrCODE, _
                            pstrUSER_CD_FROM, _
                            pstrUSER_CD_TO, _
                            pstrTANCD(i), _
                            pstrTANNM(i), _
                            pstrRENTEL1(i), _
                            pstrRENTEL2(i), _
                            pstrRENTEL3(i), _
                            pstrFAXNO(i), _
                            pstrDISP_NO(i), _
                            pstrBIKO(i), _
                            pstrADD_DATE, _
                            pstrEDT_DATE, _
                            pstrTIME, _
                            pstrEDT_DT(i), _
                            pstrAUTO_MAIL(i), _
                            pstrGUIDELINE(i), _
                            pstrFAXKURAKBN(i), _
                            pstrFAXJAKBN(i), _
                            pstrSPOT_MAIL(i), _
                            pstrMAIL_PASS(i), _
                            pstrAUTO_MAIL_PASS(i), _
                            pstrAUTO_FAXNO(i), _
                            pstrAUTO_FAXNM(i), _
                            pstrAUTO_KBN(i), _
                            pstrAUTO_ZERO_FLG(i))
                End If


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
    <WebMethod()> Public Function mSetTanto( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrKBN As String, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrCODE As String, _
                                ByVal pstrTANCD As String, _
                                ByVal pstrTANNM As String, _
                                ByVal pstrRENTEL1 As String, _
                                ByVal pstrRENTEL2 As String, _
                                ByVal pstrRENTEL3 As String, _
                                ByVal pstrFAXNO As String, _
                                ByVal pstrDISP_NO As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrADD_DATE As String, _
                                ByVal pstrEDT_DATE As String, _
                                ByVal pstrTIME As String, _
                                ByVal pstrEDT_DT As String, _
                                ByVal pstrAUTO_MAIL As String, _
                                ByVal pstrGUIDELINE As String, _
                                ByVal pstrFAXKURAKBN As String, _
                                ByVal pstrFAXJAKBN As String, _
                                ByVal pstrSPOT_MAIL As String, _
                                ByVal pstrMAIL_PASS As String, _
                                ByVal pstrAUTO_MAIL_PASS As String, _
                                ByVal pstrAUTO_FAXNO As String, _
                                ByVal pstrAUTO_FAXNM As String, _
                                ByVal pstrAUTO_KBN As String, _
                                ByVal pstrAUTO_ZERO_FLG As String) As String
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
            strSQL.Append("  DISP_NO, ")
            strSQL.Append("  TANCD, ")
            strSQL.Append("  TANNM, ")
            strSQL.Append("  RENTEL1, ")
            strSQL.Append("  RENTEL2, ")
            strSQL.Append("  RENTEL3, ")                     '�d�b�ԍ��R 2013/05/23 T.Ono add
            strSQL.Append("  FAXNO, ")
            strSQL.Append("  BIKO, ")
            strSQL.Append("  EDT_DATE, ")                    '�X�V��
            strSQL.Append("  TIME, ")                        '�X�V����
            strSQL.Append("  AUTO_MAIL, ")                   '����FAX���M���[���A�h���X 2011/04/14 T.Watabe add
            strSQL.Append("  GUIDELINE, ")                   'JA���ӎ��� 2011/11/08 H.Uema add
            strSQL.Append("  FAXKURAKBN, ")                  'FAX�s�v(�ײ���)�敪 2011/11/29 H.Uema add
            strSQL.Append("  FAXKBN, ")                      'FAX�s�v(JA)�敪 2011/12/01 H.Uema add
            strSQL.Append("  SPOT_MAIL, ")                   'SPOT���[���ǉ� 2012/03/23 W.GANEKO add
            strSQL.Append("  MAIL_PASS, ")                    'Ұ��߽ܰ�ޒǉ� 2012/03/23 W.GANEKO add
            strSQL.Append("  AUTO_MAIL_PASS, ")             '����FAX�Y�ţ���߽ܰ�� 2013/05/23 T.Ono add
            strSQL.Append("  AUTO_FAXNO, ")                 '����FAX�ԍ� 2013/05/23 T.Ono add
            strSQL.Append("  AUTO_KBN, ")                   '�������M�敪 2013/05/23 T.Ono add
            strSQL.Append("  AUTO_ZERO_FLG, ")              '�[�������M�t���O 2013/05/23 T.Ono add
            strSQL.Append("  AUTO_FAXNM ")                  '����FAX���M�� 2013/07/22 T.Ono add
            strSQL.Append("FROM ")
            strSQL.Append("  M05_TANTO ")                    '�S���҃}�X�^
            strSQL.Append("WHERE KBN  =:KBN  ")             '�敪
            strSQL.Append("  AND KURACD =:KURACD ")         '�N���C�A���g�R�[�h�i�Ď��E�o����ALL�uZ�v�j
            strSQL.Append("  AND CODE =:CODE ")             '�R�[�h(�Ď��Z���^�[�R�[�h�^�o����ЃR�[�h�^�i�`�x���R�[�h)
            strSQL.Append("  AND LPAD(TANCD,2,'0') = :TANCD ")            '�S���҃R�[�h
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KBN") = pstrKBN               '�敪
            cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h
            cdb.pSQLParamStr("CODE") = pstrCODE             '�R�[�h
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
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                If (tmp <> pstrEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                '2011/04/14 T.Watabe edit pstrAUTO_MAIL�L�q�ǉ�
                '2011/11/08 H.Uema edit pstrGUIDELINE�L�q�ǉ�
                '2011/11/29 H.Uema edit pstrFAXKURAKBN�L�q�ǉ�
                '2011/12/01 H.Uema edit pstrFAXJAKBN�L�q�ǉ�
                '2012/03/23 W.GANEKO edit pstrSPOT_MAIL�L�q�ǉ�
                '2012/03/23 W.GANEKO edit pstrMAIL_PASS�L�q�ǉ�
                '2013/05/23 T.Ono edit �ڋq�P�ʓo�^�@�\�ǉ�
                If ( _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("DISP_NO")) = pstrDISP_NO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANCD")) = pstrTANCD) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) = pstrRENTEL1) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2")) = pstrRENTEL2) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3")) = pstrRENTEL3) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXNO")) = pstrFAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL")) = pstrAUTO_MAIL) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE")) = pstrGUIDELINE) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKURAKBN")) = pstrFAXKURAKBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKBN")) = pstrFAXJAKBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("SPOT_MAIL")) = pstrSPOT_MAIL) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL_PASS")) = pstrMAIL_PASS) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL_PASS")) = pstrAUTO_MAIL_PASS) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNO")) = pstrAUTO_FAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNM")) = pstrAUTO_FAXNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_KBN")) = pstrAUTO_KBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_ZERO_FLG")) = pstrAUTO_ZERO_FLG) _
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If

            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If

            '�c�a�`�F�b�N-----------------------------------
            '�o�^�C�����A�i�`�S���҂̏ꍇ�́A�N���C�A���g�R�[�h�̑��݃`�F�b�N���s��
            If (pintMODE = 1 Or pintMODE = 2) And pstrKBN = "3" Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" CLI_CD ")                       '�N���C�A���g�R�[�h
                strSQL.Append("FROM ")
                strSQL.Append("CLIMAS ")                        '�N���C�A���g�}�X�^
                strSQL.Append("WHERE CLI_CD=:CLI_CD ")          '�N���C�A���g�R�[�h

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

            ' 2013/06/25 T.Ono del �N���C�A���g�R�[�h�݂̂ł̓o�^�������邽�߁AJA�x���R�[�h�̃`�F�b�N�폜
            ''�o�^�C�����A�i�`�S���҂̏ꍇ�́A�R�[�h���i�`�x���R�[�h�Ƃ��đ��݃`�F�b�N���s��
            'If (pintMODE = 1 Or pintMODE = 2) And pstrKBN = "3" Then
            '    strSQL = New StringBuilder("")
            '    strSQL.Append("SELECT ")
            '    strSQL.Append(" HAN_CD ")                       '�i�`�x���R�[�h
            '    strSQL.Append("FROM ")
            '    strSQL.Append("HN2MAS ")                        '�i�`�x���}�X�^
            '    strSQL.Append("WHERE HAN_CD=:HAN_CD ")          '�i�`�x���R�[�h
            '    strSQL.Append("AND CLI_CD=:CLI_CD ")            '�N���C�A���g�R�[�h      '2012/05/24 NEC Add

            '    'SQL���Z�b�g
            '    cdb.pSQL = strSQL.ToString

            '    '�p�����[�^�ɒl���Z�b�g
            '    cdb.pSQLParamStr("HAN_CD") = pstrCODE
            '    cdb.pSQLParamStr("CLI_CD") = pstrKURACD                                 '2012/05/24 NEC Add

            '    'SQL���s
            '    cdb.mExecQuery()
            '    ds = cdb.pResult

            '    If (ds.Tables(0).Rows.Count = 0) Then
            '        '*******************************************
            '        '�i�`�x�������݂��Ȃ���
            '        '*******************************************
            '        strRes = "5"
            '        Exit Try
            '    End If
            'End If



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
                strSQL.Append("  AND LPAD(TANCD,2,'0')=:TANCD ")                '�S���҃R�[�h

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
                strSQL.Append("RENTEL3 = :RENTEL3, ")       '�d�b�ԍ��R 2013/05/23 T.Ono add
                strSQL.Append("FAXNO = :FAXNO, ")
                strSQL.Append("DISP_NO = :DISP_NO, ")
                strSQL.Append("BIKO = :BIKO, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME, ")
                strSQL.Append("AUTO_MAIL  = :AUTO_MAIL, ") '����FAX���M���[���A�h���X 2011/04/14 T.Watabe add
                strSQL.Append("GUIDELINE  = :GUIDELINE, ") 'JA���ӎ��� 2011/11/08 H.Uema add
                strSQL.Append("FAXKURAKBN  = :FAXKURAKBN, ") 'FAX�s�v(�ײ���)�敪 2011/11/29 H.Uema add
                strSQL.Append("FAXKBN  = :FAXJAKBN, ")       'FAX�s�v(JA)�敪 2011/12/01 H.Uema add
                strSQL.Append("SPOT_MAIL = :SPOT_MAIL, ")    'SPOTҰْǉ� 2012/03/23 W.GANEKO add
                strSQL.Append("MAIL_PASS  = :MAIL_PASS, ")       'Ұ��߽ܰ�ޒǉ� 2012/03/23 W.GANEKO add
                strSQL.Append("AUTO_MAIL_PASS = :AUTO_MAIL_PASS, ") '����FAX�Y�ţ���߽ܰ�� 2013/05/23 T.Ono add
                strSQL.Append("AUTO_FAXNO = :AUTO_FAXNO, ")         '����FAX�ԍ� 2013/05/23 T.Ono add
                strSQL.Append("AUTO_KBN = :AUTO_KBN, ")             '�������M�敪 2013/05/23 T.Ono add
                strSQL.Append("AUTO_ZERO_FLG = :AUTO_ZERO_FLG, ")    '�[�������M�t���O 2013/05/23 T.Ono add
                strSQL.Append("AUTO_FAXNM = :AUTO_FAXNM ")         '����FAX���M�� 2013/057/22 T.Ono add
                strSQL.Append("WHERE   ")
                strSQL.Append("      KBN    =:KBN  ")                 '�敪
                strSQL.Append("  AND KURACD =:KURACD ")             '�N���C�A���g�R�[�h
                strSQL.Append("  AND CODE   =:CODE ")                 '�R�[�h
                strSQL.Append("  AND LPAD(TANCD,2,'0')=:TANCD ")                '�S���҃R�[�h

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
                strSQL.Append("RENTEL3, ")  '�d�b�ԍ��R 2013/05/23 T.Ono add
                strSQL.Append("FAXNO, ")
                strSQL.Append("DISP_NO, ")
                strSQL.Append("BIKO, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME, ")
                strSQL.Append("AUTO_MAIL, ") '2011/04/14 T.Watabe add
                strSQL.Append("GUIDELINE, ") '2011/11/08 H.Uema add
                strSQL.Append("FAXKURAKBN, ") '2011/11/29 H.Uema add
                strSQL.Append("FAXKBN, ")   '2011/12/01 H.Uema add
                strSQL.Append("SPOT_MAIL, ")   '2012/03/23 W.GANEKO add
                strSQL.Append("MAIL_PASS, ")   '2012/03/23 W.GANEKO add
                strSQL.Append("AUTO_MAIL_PASS, ")   '����FAX�Y�ţ���߽ܰ�� 2013/05/23 T.Ono add
                strSQL.Append("AUTO_FAXNO, ")       '����FAX�ԍ� 2013/05/23 T.Ono add
                strSQL.Append("AUTO_KBN, ")         '�������M�敪 2013/05/23 T.Ono add
                strSQL.Append("AUTO_ZERO_FLG, ")    '�[�������M�t���O 2013/05/23 T.Ono add
                strSQL.Append("AUTO_FAXNM ")        '����FAX���M�� 2013/07/22 T.Ono add
                strSQL.Append(") VALUES(")
                strSQL.Append(":KBN, ")
                strSQL.Append(":KURACD, ")
                strSQL.Append(":CODE, ")
                'strSQL.Append(":TANCD, ")
                strSQL.Append("LPAD(:TANCD,2,'0'), ")
                strSQL.Append(":TANNM, ")
                strSQL.Append(":RENTEL1, ")
                strSQL.Append(":RENTEL2, ")
                strSQL.Append(":RENTEL3, ")  '�d�b�ԍ��R 2013/05/23 T.Ono add
                strSQL.Append(":FAXNO, ")
                strSQL.Append(":DISP_NO, ")
                strSQL.Append(":BIKO, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME, ")
                strSQL.Append(":AUTO_MAIL, ") '2011/04/14 T.Watabe add
                strSQL.Append(":GUIDELINE, ") '2011/11/08 H.Uema add
                strSQL.Append(":FAXKURAKBN, ") '2011/11/29 H.Uema add
                strSQL.Append(":FAXJAKBN, ") '2011/12/01 H.Uema add
                strSQL.Append(":SPOT_MAIL, ") '2012/03/23 W.GANEKO add
                strSQL.Append(":MAIL_PASS, ") '2012/03/23 W.GANEKO add
                strSQL.Append(":AUTO_MAIL_PASS, ")  '����FAX�Y�ţ���߽ܰ�� 2013/05/23 T.Ono add
                strSQL.Append(":AUTO_FAXNO, ")      '����FAX�ԍ� 2013/05/23 T.Ono add
                strSQL.Append(":AUTO_KBN, ")        '�������M�敪 2013/05/23 T.Ono add
                strSQL.Append(":AUTO_ZERO_FLG, ")   '�[�������M�t���O 2013/05/23 T.Ono add
                strSQL.Append(":AUTO_FAXNM ")       '����FAX���M�� 2013/07/22 T.Ono add
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
                cdb.pSQLParamStr("RENTEL1") = pstrRENTEL1       '�A���d�b�ԍ��P
                cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2       '�A���d�b�ԍ��Q
                cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3       '�A���d�b�ԍ��R 2013/05/23 T.Ono add
                cdb.pSQLParamStr("FAXNO") = pstrFAXNO           'FAX�ԍ�
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
                cdb.pSQLParamStr("AUTO_MAIL") = pstrAUTO_MAIL             '����FAX���M���[���A�h���X 2011/04/14 T.Watabe add
                cdb.pSQLParamStr("GUIDELINE") = pstrGUIDELINE             'JA���ӎ��� 2011/11/08 H.Uema add
                cdb.pSQLParamStr("FAXKURAKBN") = pstrFAXKURAKBN           'FAX�s�v(�ײ���)�敪 2011/11/29 H.Uema add
                cdb.pSQLParamStr("FAXJAKBN") = pstrFAXJAKBN               'FAX�s�v(JA)�敪 2011/12/01 H.Uema add
                cdb.pSQLParamStr("SPOT_MAIL") = pstrSPOT_MAIL             'SPOTҰْǉ� 2012/03/23 W.GANEKO add
                cdb.pSQLParamStr("MAIL_PASS") = pstrMAIL_PASS             'Ұ��߽ܰ�ޒǉ� 2012/03/23 W.GANEKO add
                cdb.pSQLParamStr("AUTO_MAIL_PASS") = pstrAUTO_MAIL_PASS '����FAX�Y�ţ���߽ܰ�� 2013/05/23 T.Ono add
                cdb.pSQLParamStr("AUTO_FAXNO") = pstrAUTO_FAXNO         '����FAX�ԍ� 2013/05/23 T.Ono add
                cdb.pSQLParamStr("AUTO_KBN") = pstrAUTO_KBN             '�������M�敪 2013/05/23 T.Ono add
                cdb.pSQLParamStr("AUTO_ZERO_FLG") = pstrAUTO_ZERO_FLG   '�[�������M�t���O 2013/05/23 T.Ono add
                cdb.pSQLParamStr("AUTO_FAXNM") = pstrAUTO_FAXNM         '����FAX�ԍ� 2013/07/22 T.Ono add

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

    '2013/05/24 T.Ono add  �ڋq�P�ʓo�^�@�\�ǉ�
    '************************************************
    '�S���҃}�X�^2�X�V
    '************************************************
    <WebMethod()> Public Function mSetTanto2( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrKBN As String, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrCODE As String, _
                                ByVal pstrUSER_CD_FROM As String, _
                                ByVal pstrUSER_CD_TO As String, _
                                ByVal pstrTANCD As String, _
                                ByVal pstrTANNM As String, _
                                ByVal pstrRENTEL1 As String, _
                                ByVal pstrRENTEL2 As String, _
                                ByVal pstrRENTEL3 As String, _
                                ByVal pstrFAXNO As String, _
                                ByVal pstrDISP_NO As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrADD_DATE As String, _
                                ByVal pstrEDT_DATE As String, _
                                ByVal pstrTIME As String, _
                                ByVal pstrEDT_DT As String, _
                                ByVal pstrAUTO_MAIL As String, _
                                ByVal pstrGUIDELINE As String, _
                                ByVal pstrFAXKURAKBN As String, _
                                ByVal pstrFAXJAKBN As String, _
                                ByVal pstrSPOT_MAIL As String, _
                                ByVal pstrMAIL_PASS As String, _
                                ByVal pstrAUTO_MAIL_PASS As String, _
                                ByVal pstrAUTO_FAXNO As String, _
                                ByVal pstrAUTO_FAXNM As String, _
                                ByVal pstrAUTO_KBN As String, _
                                ByVal pstrAUTO_ZERO_FLG As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim tmp As String
        Dim modeKBN As Integer '0=���q�l�P�́@1=���q�l�͈�

        strRes = "OK"

        If pstrUSER_CD_TO <> "" Then
            modeKBN = 1     '���q�l�͈�
        Else
            modeKBN = 0     '���q�l�P��
        End If

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
            strSQL.Append("  RENTEL3, ")                            '�d�b�ԍ��R
            strSQL.Append("  FAXNO, ")
            strSQL.Append("  BIKO, ")
            strSQL.Append("  EDT_DATE, ")                           '�X�V��
            strSQL.Append("  TIME, ")                               '�X�V����
            strSQL.Append("  AUTO_MAIL, ")                          '����FAX���M���[���A�h���X 
            strSQL.Append("  GUIDELINE, ")                          'JA���ӎ���
            strSQL.Append("  FAXKURAKBN, ")                         'FAX�s�v(�ײ���)�敪
            strSQL.Append("  FAXKBN, ")                             'FAX�s�v(JA)�敪
            strSQL.Append("  SPOT_MAIL, ")                          'SPOT���[���ǉ�
            strSQL.Append("  MAIL_PASS, ")                          'Ұ��߽ܰ�ޒǉ�
            strSQL.Append("  AUTO_MAIL_PASS, ")                     '����FAX�Y�ţ���߽ܰ��
            strSQL.Append("  AUTO_FAXNO, ")                         '����FAX�ԍ�
            strSQL.Append("  AUTO_KBN, ")                           '�������M�敪
            strSQL.Append("  AUTO_ZERO_FLG, ")                      '�[�������M�t���O
            strSQL.Append("  AUTO_FAXNM ")                          '����FAX���M��
            strSQL.Append("FROM ")
            strSQL.Append("  M05_TANTO2 ")                          '�S���҃}�X�^2
            strSQL.Append("WHERE KBN  =:KBN  ")                     '�敪
            strSQL.Append("  AND KURACD =:KURACD ")                 '�N���C�A���g�R�[�h�i�Ď��E�o����ALL�uZ�v�j
            strSQL.Append("  AND CODE =:CODE ")                     '�R�[�h(�Ď��Z���^�[�R�[�h�^�o����ЃR�[�h�^�i�`�x���R�[�h)
            strSQL.Append("  AND USER_CD_FROM =:USER_CD_FROM ")     '���q�l�R�[�h_FROM
            If modeKBN = 1 Then
                strSQL.Append("  AND USER_CD_TO =:USER_CD_TO ")     '���q�l�R�[�h_TO
            ElseIf modeKBN = 0 Then
                strSQL.Append("  AND USER_CD_TO Is Null ")          '���q�l�R�[�h_TO
            End If
            strSQL.Append("  AND LPAD(TANCD,2,'0') = :TANCD ")      '�S���҃R�[�h
            strSQL.Append("FOR UPDATE NOWAIT ")                     '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KBN") = pstrKBN                       '�敪
            cdb.pSQLParamStr("KURACD") = pstrKURACD                 '�N���C�A���g�R�[�h
            cdb.pSQLParamStr("CODE") = pstrCODE                     '�R�[�h
            cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     '���q�l�R�[�h_FROM
            If modeKBN = 1 Then
                cdb.pSQLParamStr("USER_CD_TO") = pstrUSER_CD_TO         '���q�l�R�[�h_TO
            End If
            cdb.pSQLParamStr("TANCD") = pstrTANCD                   '�S���҃R�[�h

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
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) & Convert.ToString(ds.Tables(0).Rows(0).Item("TIME"))
                If (tmp <> pstrEDT_DT) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If ( _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("DISP_NO")) = pstrDISP_NO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANCD")) = pstrTANCD) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) = pstrRENTEL1) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2")) = pstrRENTEL2) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3")) = pstrRENTEL3) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXNO")) = pstrFAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL")) = pstrAUTO_MAIL) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("GUIDELINE")) = pstrGUIDELINE) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKURAKBN")) = pstrFAXKURAKBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("FAXKBN")) = pstrFAXJAKBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("SPOT_MAIL")) = pstrSPOT_MAIL) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("MAIL_PASS")) = pstrMAIL_PASS) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_MAIL_PASS")) = pstrAUTO_MAIL_PASS) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNO")) = pstrAUTO_FAXNO) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_FAXNM")) = pstrAUTO_FAXNM) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_KBN")) = pstrAUTO_KBN) And _
                     (Convert.ToString(ds.Tables(0).Rows(0).Item("AUTO_ZERO_FLG")) = pstrAUTO_ZERO_FLG) _
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If

            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If

            '�c�a�`�F�b�N-----------------------------------
            '�o�^�C�����A�i�`�S���҂̏ꍇ�́A�N���C�A���g�R�[�h�̑��݃`�F�b�N���s��
            If (pintMODE = 1 Or pintMODE = 2) And pstrKBN = "3" Then

                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" CLI_CD ")                       '�N���C�A���g�R�[�h
                strSQL.Append("FROM ")
                strSQL.Append("CLIMAS ")                        '�N���C�A���g�}�X�^
                strSQL.Append("WHERE CLI_CD=:CLI_CD ")          '�N���C�A���g�R�[�h

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

            '�o�^�C�����A�i�`�S���҂̏ꍇ�́A�R�[�h���i�`�x���R�[�h�Ƃ��đ��݃`�F�b�N���s��
            If (pintMODE = 1 Or pintMODE = 2) And pstrKBN = "3" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" HAN_CD ")                       '�i�`�x���R�[�h
                strSQL.Append("FROM ")
                strSQL.Append("HN2MAS ")                        '�i�`�x���}�X�^
                strSQL.Append("WHERE HAN_CD=:HAN_CD ")          '�i�`�x���R�[�h
                strSQL.Append("AND CLI_CD=:CLI_CD ")            '�N���C�A���g�R�[�h 

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("HAN_CD") = pstrCODE
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�i�`�x�������݂��Ȃ���
                    '*******************************************
                    strRes = "5"
                    Exit Try
                End If
            End If

            ' ��L�[�̏d�����`�F�b�N
            If pintMODE = 1 Then
                If pstrTANCD = "01" OrElse pstrTANCD = "1" Then '1�s�ڂł̂ݕ]��
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT  ")
                    strSQL.Append("USER_CD_FROM ")
                    strSQL.Append("FROM ")
                    strSQL.Append("   M05_TANTO2 ")
                    strSQL.Append("WHERE  KURACD=:KURACD   ")
                    strSQL.Append("AND    CODE=:CODE   ")
                    strSQL.Append("AND    USER_CD_FROM = :USER_CD_FROM ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString

                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("KURACD") = pstrKURACD                 '�N���C�A���g�R�[�h
                    cdb.pSQLParamStr("CODE") = pstrCODE                     '�R�[�h
                    cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     '���q�l�R�[�h_FROM

                    'SQL���s
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count <> 0) Then
                        '*******************************************
                        '��L�[�̏d�����͈͂̏d���Ƃ���
                        '*******************************************
                        strRes = "8"
                        Exit Try
                    End If
                End If
            End If

            ' ���q�l�R�[�hFrom�`To�̏d�����`�F�b�N
            If pintMODE = 1 AndAlso modeKBN = 1 Then
                If pstrTANCD = "01" OrElse pstrTANCD = "1" Then '1�s�ڂł̂ݕ]��
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("   USER_CD_FROM ")
                    strSQL.Append("FROM ")
                    strSQL.Append("   M05_TANTO2 ")
                    strSQL.Append("WHERE  KURACD=:KURACD  ")
                    strSQL.Append("AND    CODE=:CODE  ")
                    strSQL.Append("AND    USER_CD_TO IS NOT NULL ")
                    strSQL.Append("AND    ( ")
                    strSQL.Append("        :USER_CD_FROM      between USER_CD_FROM and USER_CD_TO  ")
                    strSQL.Append("        OR  :USER_CD_TO    between USER_CD_FROM and USER_CD_TO  ")
                    strSQL.Append("        OR  USER_CD_FROM   between :USER_CD_FROM and :USER_CD_TO ")
                    strSQL.Append("       ) ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString

                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("KURACD") = pstrKURACD                 '�N���C�A���g�R�[�h
                    cdb.pSQLParamStr("CODE") = pstrCODE                     '�R�[�h
                    cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     '���q�l�R�[�h_FROM
                    cdb.pSQLParamStr("USER_CD_TO") = pstrUSER_CD_TO         '���q�l�R�[�h_TO

                    'SQL���s
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If (ds.Tables(0).Rows.Count <> 0) Then
                        '*******************************************
                        '�͈͂̏d��
                        '*******************************************
                        strRes = "8"
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
                strSQL.Append("M05_TANTO2 ")                        '�S���҃}�X�^�Q
                strSQL.Append("WHERE KBN  =:KBN  ")                 '�敪
                strSQL.Append("  AND KURACD =:KURACD ")             '�N���C�A���g�R�[�h
                strSQL.Append("  AND CODE =:CODE ")                 '�R�[�h
                strSQL.Append("  AND USER_CD_FROM =:USER_CD_FROM ") '���q�l�R�[�h_FROM
                If modeKBN = 1 Then
                    strSQL.Append("  AND USER_CD_TO =:USER_CD_TO ") '���q�l�R�[�h_TO
                ElseIf modeKBN = 0 Then
                    strSQL.Append("  AND USER_CD_TO Is Null ")      '���q�l�R�[�h_TO
                End If
                strSQL.Append("  AND LPAD(TANCD,2,'0')=:TANCD ")    '�S���҃R�[�h

            ElseIf pintMODE = 2 Then
                '�����敪���C��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("M05_TANTO2 ")
                strSQL.Append("SET ")
                strSQL.Append("KBN = :KBN, ")
                strSQL.Append("KURACD = :KURACD, ")
                strSQL.Append("CODE = :CODE, ")
                strSQL.Append("USER_CD_FROM = :USER_CD_FROM, ")         '���q�l�R�[�h_FROM
                If modeKBN = 1 Then
                    strSQL.Append("USER_CD_TO = :USER_CD_TO, ")         '���q�l�R�[�h_TO
                End If
                strSQL.Append("TANCD = :TANCD, ")
                strSQL.Append("TANNM = :TANNM, ")
                strSQL.Append("RENTEL1 = :RENTEL1, ")
                strSQL.Append("RENTEL2 = :RENTEL2, ")
                strSQL.Append("RENTEL3 = :RENTEL3, ")                   '�d�b�ԍ��R
                strSQL.Append("FAXNO = :FAXNO, ")
                strSQL.Append("DISP_NO = :DISP_NO, ")
                strSQL.Append("BIKO = :BIKO, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME, ")
                strSQL.Append("AUTO_MAIL  = :AUTO_MAIL, ")              '����FAX���M���[���A�h���X
                strSQL.Append("GUIDELINE  = :GUIDELINE, ")              'JA���ӎ���
                strSQL.Append("FAXKURAKBN  = :FAXKURAKBN, ")            'FAX�s�v(�ײ���)
                strSQL.Append("FAXKBN  = :FAXJAKBN, ")                  'FAX�s�v(JA)
                strSQL.Append("SPOT_MAIL = :SPOT_MAIL, ")               'SPOTҰ�
                strSQL.Append("MAIL_PASS  = :MAIL_PASS, ")              'Ұ��߽ܰ�� 
                strSQL.Append("AUTO_MAIL_PASS = :AUTO_MAIL_PASS, ")     '����FAX�Y�ţ���߽ܰ�� 
                strSQL.Append("AUTO_FAXNO = :AUTO_FAXNO, ")             '����FAX�ԍ�
                strSQL.Append("AUTO_KBN = :AUTO_KBN, ")                 '�������M�敪
                strSQL.Append("AUTO_ZERO_FLG = :AUTO_ZERO_FLG, ")       '�[�������M�t���O  
                strSQL.Append("AUTO_FAXNM = :AUTO_FAXNM ")              '����FAX���M��
                strSQL.Append("WHERE   ")
                strSQL.Append("      KBN    =:KBN  ")                   '�敪
                strSQL.Append("  AND KURACD =:KURACD ")                 '�N���C�A���g�R�[�h
                strSQL.Append("  AND CODE   =:CODE ")                   '�R�[�h
                strSQL.Append("  AND USER_CD_FROM =:USER_CD_FROM ")     '���q�l�R�[�h_FROM
                If modeKBN = 1 Then
                    strSQL.Append("  AND USER_CD_TO =:USER_CD_TO ")     '���q�l�R�[�h_TO
                ElseIf modeKBN = 0 Then
                    strSQL.Append("  AND USER_CD_TO Is Null ")          '���q�l�R�[�h_TO
                End If
                strSQL.Append("  AND LPAD(TANCD,2,'0')=:TANCD ")        '�S���҃R�[�h

            ElseIf pintMODE = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("M05_TANTO2 (")
                strSQL.Append("KBN, ")
                strSQL.Append("KURACD, ")
                strSQL.Append("CODE, ")
                strSQL.Append("USER_CD_FROM, ")  '���q�l�R�[�h_FROM
                strSQL.Append("USER_CD_TO, ")  '���q�l�R�[�h_TO
                strSQL.Append("TANCD, ")
                strSQL.Append("TANNM, ")
                strSQL.Append("RENTEL1, ")
                strSQL.Append("RENTEL2, ")
                strSQL.Append("RENTEL3, ")  '�d�b�ԍ��R
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
                strSQL.Append(":USER_CD_FROM, ")    '���q�l�R�[�h_FROM
                If modeKBN = 1 Then
                    strSQL.Append(":USER_CD_TO, ")  '���q�l�R�[�h_TO
                ElseIf modeKBN = 0 Then
                    strSQL.Append(" Null, ")  '���q�l�R�[�h_TO
                End If
                'strSQL.Append(":TANCD, ")
                strSQL.Append("LPAD(:TANCD,2,'0'), ")
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
                cdb.pSQLParamStr("KBN") = pstrKBN                       '�敪�i1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S���ҁj
                cdb.pSQLParamStr("KURACD") = pstrKURACD                 '�N���C�A���g�R�[�h
                cdb.pSQLParamStr("CODE") = pstrCODE                     '�R�[�h
                cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     '���q�l�R�[�h_FROM
                If modeKBN = 1 Then
                    cdb.pSQLParamStr("USER_CD_TO") = pstrUSER_CD_TO         '���q�l�R�[�h_TO
                End If
                cdb.pSQLParamStr("TANCD") = pstrTANCD                   '�S���҃R�[�h
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("KBN") = pstrKBN                       '�敪�i1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S���ҁj
                cdb.pSQLParamStr("KURACD") = pstrKURACD                 '�N���C�A���g�R�[�h
                cdb.pSQLParamStr("CODE") = pstrCODE                     '�R�[�h
                cdb.pSQLParamStr("USER_CD_FROM") = pstrUSER_CD_FROM     '���q�l�R�[�h_FROM
                If modeKBN = 1 Then
                    cdb.pSQLParamStr("USER_CD_TO") = pstrUSER_CD_TO     '���q�l�R�[�h_TO
                End If
                cdb.pSQLParamStr("TANCD") = pstrTANCD                   '�S���҃R�[�h
                cdb.pSQLParamStr("TANNM") = pstrTANNM                   '�S���Җ�
                cdb.pSQLParamStr("RENTEL1") = pstrRENTEL1               '�A���d�b�ԍ��P
                cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2               '�A���d�b�ԍ��Q
                cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3               '�A���d�b�ԍ��R
                cdb.pSQLParamStr("FAXNO") = pstrFAXNO                   'FAX�ԍ�
                cdb.pSQLParamStr("DISP_NO") = pstrDISP_NO               '�\������
                cdb.pSQLParamStr("BIKO") = pstrBIKO                     '���l

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
                cdb.pSQLParamStr("AUTO_MAIL") = pstrAUTO_MAIL             '����FAX���M���[���A�h���X
                cdb.pSQLParamStr("GUIDELINE") = pstrGUIDELINE             'JA���ӎ���
                cdb.pSQLParamStr("FAXKURAKBN") = pstrFAXKURAKBN           'FAX�s�v(�ײ���)�敪 
                cdb.pSQLParamStr("FAXJAKBN") = pstrFAXJAKBN               'FAX�s�v(JA)�敪
                cdb.pSQLParamStr("SPOT_MAIL") = pstrSPOT_MAIL             'SPOTҰْǉ�
                cdb.pSQLParamStr("MAIL_PASS") = pstrMAIL_PASS             'Ұ��߽ܰ�ޒǉ�
                cdb.pSQLParamStr("AUTO_MAIL_PASS") = pstrAUTO_MAIL_PASS '����FAX�Y�ţ���߽ܰ��
                cdb.pSQLParamStr("AUTO_FAXNO") = pstrAUTO_FAXNO         '����FAX�ԍ�
                cdb.pSQLParamStr("AUTO_KBN") = pstrAUTO_KBN             '�������M�敪
                cdb.pSQLParamStr("AUTO_ZERO_FLG") = pstrAUTO_ZERO_FLG   '�[�������M�t���O 
                cdb.pSQLParamStr("AUTO_FAXNM") = pstrAUTO_FAXNM         '����FAX�ԍ�

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


End Class
