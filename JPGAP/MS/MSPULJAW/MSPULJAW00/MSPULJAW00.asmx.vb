Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSPULJAW00/Service1")> _
Public Class MSPULJAW00
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
    '�v���_�E���ݒ�}�X�^���X�g�f�[�^�擾
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
                                    ByVal pstrCD As String, _
                                    ByVal pstrNAME As String, _
                                    ByVal pstrNAIYO1 As String, _
                                    ByVal pstrNAIYO2 As String, _
                                    ByVal pstrDISP_NO As String, _
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

            '*********************************
            '�����X�g�[���[
            '�E�r���̃`�F�b�N���s���B
            '�E�o�^���ɂ̓f�[�^�͖������݂��Ȃ�����
            '�E�C�����ɂ̓f�[�^�͑��݂��邱��
            '*********************************

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" EDT_DATE, ")            '�X�V��
            strSQL.Append(" TIME ")             '�X�V����
            strSQL.Append("FROM ")
            strSQL.Append("M06_PULLDOWN ")          '�v���_�E���}�X�^
            strSQL.Append("WHERE KBN  =:KBN  ")     '�敪
            strSQL.Append("  AND CD =:CD ")         '�R�[�h
            strSQL.Append("FOR UPDATE NOWAIT ")     '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KBN") = pstrKBN       '�敪
            cdb.pSQLParamStr("CD") = pstrCD         '�R�[�h

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

            '�o�^�C�����A�v���_�E���敪���敪�̗L���`�F�b�N���s�Ȃ�
            If (pintKBN = 1 Or pintKBN = 2) Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append(" CD ")                  '�敪
                strSQL.Append("FROM ")
                strSQL.Append("M06_PULLDOWN ")         '�v���_�E���}�X�^
                strSQL.Append("WHERE KBN = '00' ")      '�敪
                strSQL.Append("  AND CD = :CD ")        '�R�[�h

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("CD") = pstrKBN       '�敪

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�敪�����݂��Ȃ���
                    '*******************************************
                    strRes = "4"
                    Exit Try
                End If
            End If

            '�f�[�^�̍X�V����--------------------------------
            If pintKBN = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("M06_PULLDOWN ")          '�v���_�E���}�X�^
                strSQL.Append("WHERE KBN =:KBN  ")      '�敪
                strSQL.Append("  AND CD =:CD ")         '�R�[�h

            ElseIf pintKBN = 2 Then
                '�����敪���C��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("M06_PULLDOWN ")
                strSQL.Append("SET ")
                strSQL.Append("KBN =:KBN, ")
                strSQL.Append("CD =:CD, ")
                strSQL.Append("NAME =:NAME, ")
                strSQL.Append("NAIYO1 =:NAIYO1, ")
                strSQL.Append("NAIYO2 =:NAIYO2, ")
                strSQL.Append("DISP_NO =:DISP_NO, ")
                strSQL.Append("ADD_DATE    = :ADD_DATE, ")
                strSQL.Append("EDT_DATE    = :EDT_DATE, ")
                strSQL.Append("TIME     = :TIME ")
                strSQL.Append("WHERE KBN =:KBN  ")      '�敪
                strSQL.Append("  AND CD =:CD ")         '�R�[�h

            ElseIf pintKBN = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("M06_PULLDOWN (")
                strSQL.Append("KBN, ")
                strSQL.Append("CD, ")
                strSQL.Append("NAME, ")
                strSQL.Append("NAIYO1, ")
                strSQL.Append("NAIYO2, ")
                strSQL.Append("DISP_NO, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_DATE, ")
                strSQL.Append("TIME ")
                strSQL.Append(") VALUES(")
                strSQL.Append(":KBN, ")
                strSQL.Append(":CD, ")
                strSQL.Append(":NAME, ")
                strSQL.Append(":NAIYO1, ")
                strSQL.Append(":NAIYO2, ")
                strSQL.Append(":DISP_NO, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_DATE, ")
                strSQL.Append(":TIME ")
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintKBN = 3 Then
                cdb.pSQLParamStr("KBN") = pstrKBN                   '�敪
                cdb.pSQLParamStr("CD") = pstrCD                     '�R�[�h
            ElseIf pintKBN = 1 Or pintKBN = 2 Then
                cdb.pSQLParamStr("KBN") = pstrKBN                   '�敪
                cdb.pSQLParamStr("CD") = pstrCD                     '�R�[�h
                cdb.pSQLParamStr("NAME") = pstrNAME                 '����
                cdb.pSQLParamStr("NAIYO1") = pstrNAIYO1             '���e�P
                cdb.pSQLParamStr("NAIYO2") = pstrNAIYO2             '���e�Q
                cdb.pSQLParamStr("DISP_NO") = pstrDISP_NO           '�\������
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
            '�R�~�b�g
            cdb.mCommit()
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
End Class