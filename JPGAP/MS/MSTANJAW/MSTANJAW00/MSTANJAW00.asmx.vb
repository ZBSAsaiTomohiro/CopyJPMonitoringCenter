'***********************************************
'�S���҃}�X�^
'***********************************************
Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text

<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSTANJAW00/Service1")> _
Public Class MSTANJAW00
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

    'pintKBN
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

    <WebMethod()> Public Function mSet( _
                                    ByVal pintKBN As Integer, _
                                    ByVal pstrKBN As String, _
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrCODE As String, _
                                    ByVal pstrTANCD As String, _
                                    ByVal pstrTANNM As String, _
                                    ByVal pstrRENTEL1 As String, _
                                    ByVal pstrRENTEL2 As String, _
                                    ByVal pstrFAXNO As String, _
                                    ByVal pstrDISP_NO As String, _
                                    ByVal pstrBIKO As String, _
                                    ByVal pstrADD_DATE As String, _
                                    ByVal pstrEDT_DATE As String, _
                                    ByVal pstrTIME As String) As String
        Dim ds As New DataSet
        Dim cdb As New cdb
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

            strRes = mSetTanto( _
                        cdb, _
                        pintKBN, _
                        pstrKBN, _
                        pstrKURACD, _
                        pstrCODE, _
                        pstrTANCD, _
                        pstrTANNM, _
                        pstrRENTEL1, _
                        pstrRENTEL2, _
                        pstrFAXNO, _
                        pstrDISP_NO, _
                        pstrBIKO, _
                        pstrADD_DATE, _
                        pstrEDT_DATE, _
                        pstrTIME)
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
    '�S���҃}�X�^�X�V�i�Ή����͉�ʂ�����g�p�j
    '************************************************
    <WebMethod()> Public Function mSetTanto( _
                                ByRef cdb As CDB, _
                                ByVal pintKBN As Integer, _
                                ByVal pstrKBN As String, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrCODE As String, _
                                ByVal pstrTANCD As String, _
                                ByVal pstrTANNM As String, _
                                ByVal pstrRENTEL1 As String, _
                                ByVal pstrRENTEL2 As String, _
                                ByVal pstrFAXNO As String, _
                                ByVal pstrDISP_NO As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrADD_DATE As String, _
                                ByVal pstrEDT_DATE As String, _
                                ByVal pstrTIME As String) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

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
            strSQL.Append(" EDT_DATE, ")                    '�X�V��
            strSQL.Append(" TIME ")                         '�X�V����
            strSQL.Append("FROM ")
            strSQL.Append("M05_TANTO ")                     '�S���҃}�X�^
            strSQL.Append("WHERE KBN  =:KBN  ")             '�敪
            '--- ��2005/07/19 ADD Falcon�� ---
            strSQL.Append("  AND KURACD =:KURACD ")         '�N���C�A���g�R�[�h�i�Ď��E�o����ALL�uZ�v�j
            '--- ��2005/07/19 ADD Falcon�� ---
            strSQL.Append("  AND CODE =:CODE ")             '�R�[�h(�Ď��Z���^�[�R�[�h�^�o����ЃR�[�h�^�i�`�x���R�[�h)
            strSQL.Append("  AND TANCD=:TANCD ")            '�S���҃R�[�h
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KBN") = pstrKBN               '�敪
            '--- ��2005/07/19 ADD Falcon�� ---
            cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h
            '--- ��2005/07/19 ADD Falcon�� ---
            cdb.pSQLParamStr("CODE") = pstrCODE             '�R�[�h
            cdb.pSQLParamStr("TANCD") = pstrTANCD           '�S���҃R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '�o�^���ɓ���L�[�̃f�[�^�����݂��鎞
            If (pintKBN = 1) And (ds.Tables(0).Rows.Count <> 0) Then
                '*******************************************
                '�o�^���ɓ����L�[�̃f�[�^�����ɑ��݂���ꍇ�̓G���[�Ƃ���
                '*******************************************
                strRes = "1"
                Exit Try
            Else
                If (pintKBN = 2) Then
                    '*******************************************
                    '�C���������L�[�̃f�[�^�����݂��Ȃ��ꍇ�̓G���[�Ƃ���
                    '*******************************************
                    If (ds.Tables(0).Rows.Count = 0) Then
                        strRes = "2"
                        Exit Try
                    End If
                    '*******************************************
                    '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                    '*******************************************
                    If ((Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) <> pstrEDT_DATE) Or _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TIME")) <> pstrTIME)) Then
                        strRes = "0"
                        Exit Try
                    End If
                End If
            End If

            '�c�a�`�F�b�N-----------------------------------
            '�o�^�C�����A�i�`�S���҂̏ꍇ�́A�N���C�A���g�R�[�h�̑��݃`�F�b�N���s��
            If (pintKBN = 1 Or pintKBN = 2) And pstrKBN = "3" Then
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
            If (pintKBN = 1 Or pintKBN = 2) And pstrKBN = "3" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" HAN_CD ")                       '�i�`�x���R�[�h
                strSQL.Append("FROM ")
                strSQL.Append("HN2MAS ")                        '�i�`�x���}�X�^
                strSQL.Append("WHERE HAN_CD=:HAN_CD ")          '�i�`�x���R�[�h
                strSQL.Append("AND CLI_CD=:CLI_CD ")            '�N���C�A���g�R�[�h      '2012/05/24 NEC Add

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("HAN_CD") = pstrCODE
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD                                 '2012/05/24 NEC Add

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

            '�o�^�C�����A�Ď��Z���^�[�S���҂̏ꍇ�́A�R�[�h���Ď��Z���^�[�R�[�h�Ƃ��đ��݃`�F�b�N���s��
            If (pintKBN = 1 Or pintKBN = 2) And pstrKBN = "1" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" KANSI_CD ")                     '�Ď��Z���^�R�[�h
                strSQL.Append("FROM ")
                strSQL.Append("KANSIMAS ")                      '�Ď��Z���^�}�X�^
                strSQL.Append("WHERE KANSI_CD=:KANSI_CD ")      '�Ď��Z���^�R�[�h

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("KANSI_CD") = pstrCODE

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�Ď��Z���^�����݂��Ȃ���
                    '*******************************************
                    strRes = "6"
                    Exit Try
                End If
            End If

            '�o�^�C�����A�o����ВS���҂̏ꍇ�́A�R�[�h���o����ЃR�[�h�Ƃ��đ��݃`�F�b�N���s��
            If (pintKBN = 1 Or pintKBN = 2) And pstrKBN = "2" Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" SHUTU_CD ")                     '�o����ЃR�[�h
                strSQL.Append("FROM ")
                strSQL.Append("SHUTUDOMAS ")                    '�o����Ѓ}�X�^
                '--- ��2005/05/23 MOD Falcon�� ---
                'strSQL.Append("WHERE SHUTU_CD=:SHUTU_CD ")      '�o����ЃR�[�h
                strSQL.Append("WHERE SHUTU_CD || KYOTEN_CD =:SHUTU_CD ")      '�o����ЃR�[�h�{���_�R�[�h
                '--- ��2005/05/23 MOD Falcon�� ---

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("SHUTU_CD") = pstrCODE

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�o����Ђ����݂��Ȃ���
                    '*******************************************
                    strRes = "7"
                    Exit Try
                End If
            End If

            '�f�[�^�̍X�V����--------------------------------
            If pintKBN = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("M05_TANTO ")                         '�S���҃}�X�^
                strSQL.Append("WHERE KBN  =:KBN  ")                 '�敪
                '--- ��2005/07/19 ADD Falcon�� ---
                strSQL.Append("  AND KURACD =:KURACD ")             '�N���C�A���g�R�[�h
                '--- ��2005/07/19 ADD Falcon�� ---
                strSQL.Append("  AND CODE =:CODE ")                 '�R�[�h
                strSQL.Append("  AND TANCD=:TANCD ")                '�S���҃R�[�h

            ElseIf pintKBN = 2 Then
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
                strSQL.Append("FAXNO = :FAXNO, ")
                strSQL.Append("DISP_NO = :DISP_NO, ")
                strSQL.Append("BIKO = :BIKO, ")
                strSQL.Append("ADD_DATE   = :ADD_DATE, ")
                strSQL.Append("EDT_DATE   = :EDT_DATE, ")
                strSQL.Append("TIME       = :TIME ")
                strSQL.Append("WHERE KBN  =:KBN  ")                 '�敪
                '--- ��2005/07/19 ADD Falcon�� ---
                strSQL.Append("  AND KURACD =:KURACD ")             '�N���C�A���g�R�[�h
                '--- ��2005/07/19 ADD Falcon�� ---
                strSQL.Append("  AND CODE =:CODE ")                 '�R�[�h
                strSQL.Append("  AND TANCD=:TANCD ")                '�S���҃R�[�h

            ElseIf pintKBN = 1 Then
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
                strSQL.Append("FAXNO, ")
                strSQL.Append("DISP_NO, ")
                strSQL.Append("BIKO, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME ")
                strSQL.Append(") VALUES(")
                strSQL.Append(":KBN, ")
                strSQL.Append(":KURACD, ")
                strSQL.Append(":CODE, ")
                strSQL.Append(":TANCD, ")
                strSQL.Append(":TANNM, ")
                strSQL.Append(":RENTEL1, ")
                strSQL.Append(":RENTEL2, ")
                strSQL.Append(":FAXNO, ")
                strSQL.Append(":DISP_NO, ")
                strSQL.Append(":BIKO, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME ")
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintKBN = 3 Then
                cdb.pSQLParamStr("KBN") = pstrKBN               '�敪�i1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S���ҁj
                '--- ��2005/07/19 ADD Falcon�� ---
                cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h
                '--- ��2005/07/19 ADD Falcon�� ---
                cdb.pSQLParamStr("CODE") = pstrCODE             '�R�[�h
                cdb.pSQLParamStr("TANCD") = pstrTANCD           '�S���҃R�[�h
            ElseIf pintKBN = 1 Or pintKBN = 2 Then

                cdb.pSQLParamStr("KBN") = pstrKBN               '�敪�i1:�Ď��Z���^�[�S���ҁ@2:�o����ВS���� 3:JA�x���S���ҁj
                cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h
                cdb.pSQLParamStr("CODE") = pstrCODE             '�R�[�h
                cdb.pSQLParamStr("TANCD") = pstrTANCD           '�S���҃R�[�h
                cdb.pSQLParamStr("TANNM") = pstrTANNM           '�S���Җ�
                cdb.pSQLParamStr("RENTEL1") = pstrRENTEL1       '�A���d�b�ԍ��P
                cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2       '�A���d�b�ԍ��Q
                cdb.pSQLParamStr("FAXNO") = pstrFAXNO           'FAX�ԍ�
                cdb.pSQLParamStr("DISP_NO") = pstrDISP_NO       '�\������
                cdb.pSQLParamStr("BIKO") = pstrBIKO             '���l

                If pintKBN = 1 Then
                    '�V�K�o�^�̏ꍇ
                    cdb.pSQLParamStr("ADD_DATE") = Now.ToString("yyyyMMdd")
                    cdb.pSQLParamStr("EDT_DATE") = ""
                Else
                    '�C���o�^�̏ꍇ
                    cdb.pSQLParamStr("ADD_DATE") = pstrADD_DATE
                    cdb.pSQLParamStr("EDT_DATE") = Now.ToString("yyyyMMdd")
                End If
                cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")

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