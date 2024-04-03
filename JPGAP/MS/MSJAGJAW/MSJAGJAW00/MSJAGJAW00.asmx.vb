'***********************************************
'JA�O���[�v�쐬�}�X�^
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSJAGJAW00/Service1")> _
Public Class MSJAGJAW00
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
    'JA�O���[�v�쐬�}�X�^���X�g�f�[�^�擾
    '************************************************
    '�y���ʁz
    '  OK : ����ɏI�����܂���
    '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
    '   1 : ���Ƀf�[�^�����݂��܂�
    '   2 : �Ώۃf�[�^�����݂��܂���
    '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������
    ' ----------------------------------------------
    <WebMethod()> Public Function mSetEx( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrJAGKBN As String, _
                                    ByVal pstrTARGET() As String, _
                                    ByVal pstrKURACD() As String, _
                                    ByVal pstrACBCD() As String, _
                                    ByVal pstrGROUPCD() As String, _
                                    ByVal pstrUSERCD_F() As String, _
                                    ByVal pstrUSERCD_T() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrINS_DATE() As String, _
                                    ByVal pstrINS_USER() As String, _
                                    ByVal pstrUPD_DATE() As String, _
                                    ByVal pstrUPD_USER() As String, _
                                    ByVal pstrUSERNM As String _
                                    ) As String
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
            For i = 1 To pstrKURACD.Length - 1 '�P�����o�^�^�X�V�^�폜����B
                mlog("loop:" & pstrTARGET(i) & pstrKURACD(i) & "_" & pstrACBCD(i) & "_" & pstrGROUPCD(i))

                If pstrTARGET(i) = "true" AndAlso pstrKURACD(i) <> "" Then
                    '�Ώۃ`�F�b�N����A���͂���̂ݏ���
                    strRes = mSetGroup( _
                            cdb, _
                            pintMODE, _
                            pstrJAGKBN, _
                            pstrTARGET(i), _
                            pstrKURACD(i), _
                            pstrACBCD(i), _
                            pstrGROUPCD(i), _
                            pstrUSERCD_F(i), _
                            pstrUSERCD_T(i), _
                            pstrBIKO(i), _
                            pstrINS_DATE(i), _
                            pstrINS_USER(i), _
                            pstrUPD_DATE(i), _
                            pstrUPD_USER(i), _
                            pstrUSERNM)
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
    '�}�X�^�X�V
    '************************************************
    <WebMethod()> Public Function mSetGroup( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrJAGKBN As String, _
                                ByVal pstrTARGET As String, _
                                ByVal pstrKURACD As String, _
                                ByVal pstrACBCD As String, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrUSERCD_F As String, _
                                ByVal pstrUSERCD_T As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String _
                                ) As String
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
            strSQL.Append("	    A.KBN ")
            strSQL.Append("	    ,A.KURACD ")
            strSQL.Append("	    ,A.ACBCD ")
            strSQL.Append("	    ,A.GROUPCD ")
            strSQL.Append("	    ,A.USERCD_FROM ")
            strSQL.Append("	    ,A.USERCD_TO ")
            strSQL.Append("	    ,A.BIKO ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,A.INS_USER ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	    ,A.UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M09_JAGROUP A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.KBN = :JAGKBN ")
            strSQL.Append("AND  A.KURACD = :KURACD ")
            strSQL.Append("AND	A.ACBCD = :ACBCD ")
            If pstrJAGKBN.Trim <> "003" Then                     '2017/02/09 w.ganeko 2016�Ď����P ��10
                If pstrUSERCD_F.Trim.Length > 0 Then
                    strSQL.Append("AND	A.USERCD_FROM = :USERCD_F ")
                Else
                    strSQL.Append("AND	A.USERCD_FROM IS NULL ")
                End If
            End If
            strSQL.Append("ORDER BY KURACD, ACBCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN         '�O���[�v�敪
            cdb.pSQLParamStr("KURACD") = pstrKURACD         '�N���C�A���g�R�[�h
            cdb.pSQLParamStr("ACBCD") = pstrACBCD           'JA�x���R�[�h
            If pstrJAGKBN.Trim <> "003" Then                     '2017/02/09 w.ganeko 2016�Ď����P ��10
                If pstrUSERCD_F.Trim.Length > 0 Then
                    cdb.pSQLParamStr("USERCD_F") = pstrUSERCD_F '���[�U�[�R�[�hFrom
                End If
            End If
            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 4 Then '�폜�{�^������
                    pintMODE = 3 '���[�h��3�F�폜
                Else
                    pintMODE = 2 '���[�h��2�F�X�V
                End If
            Else
                If pintMODE = 4 Then
                    pintMODE = 4 '���[�h��4�F�X�L�b�v
                Else
                    pintMODE = 1 '���[�h��1�F�V�K
                End If
            End If


            If (pintMODE = 3) Then '�c�a�Ƀf�[�^�����݂��āA�폜�̏ꍇ
                '*******************************************
                '�폜���Ŏ󂯓n���ꂽ���t�y�ю��Ԃƍ폜�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If
            End If


            If (pintMODE = 2) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    Exit Try
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KBN")) = pstrJAGKBN) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KURACD")) = pstrKURACD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("ACBCD")) = pstrACBCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("USERCD_FROM")) = pstrUSERCD_F) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("USERCD_TO")) = pstrUSERCD_T) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) _
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If

            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If

            '�c�a�`�F�b�N-----------------------------------
            '�o�^/�X�V���A
            If (pintMODE = 1 Or pintMODE = 2) Then

                '*******************************************
                '�N���C�A���g�R�[�h�̑��݃`�F�b�N
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT  ")
                strSQL.Append(" CLI_CD ")
                strSQL.Append("FROM ")
                strSQL.Append(" CLIMAS ")
                strSQL.Append("WHERE CLI_CD = :CLI_CD ")
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

                '*******************************************
                'JA�x���R�[�h�̑��݃`�F�b�N
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append("		A.HAN_CD ")
                strSQL.Append("FROM ")
                strSQL.Append("		HN2MAS A ")
                strSQL.Append("WHERE ")
                strSQL.Append("		A.CLI_CD = :CLI_CD ")
                strSQL.Append("AND	A.HAN_CD = :JA_CD ")
                strSQL.Append("AND	NVL(A.DEL_FLG,'0') <> '1' ")
                strSQL.Append("AND	NOT EXISTS( ")
                strSQL.Append("			SELECT	'X' ")
                strSQL.Append("			FROM	HN2MAS B ")
                strSQL.Append("			WHERE	A.CLI_CD = B.CLI_CD ")
                strSQL.Append("			AND		A.HAN_CD = B.JA_CD ")
                strSQL.Append("			) ")
                strSQL.Append("ORDER BY A.CLI_CD, A.HAN_CD ")
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("CLI_CD") = pstrKURACD
                cdb.pSQLParamStr("JA_CD") = pstrACBCD

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    'JA�x���R�[�h�����݂��Ȃ���
                    '*******************************************
                    strRes = "5"
                    Exit Try
                End If

                '*******************************************
                'JA�x���R�[�h���̓o�^�����`�F�b�N
                '100���ȏ�͉�ʂɕ\���ł��Ȃ��̂�
                '����100���o�^����ꍇ��NG
                If pintMODE = 1 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("		COUNT(*) AS CNT ")
                    strSQL.Append("FROM ")
                    strSQL.Append("		M09_JAGROUP ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("		KBN = :JAGKBN ")
                    strSQL.Append("AND KURACD = :KURACD ")
                    strSQL.Append("AND ACBCD = :ACBCD ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString
                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN
                    cdb.pSQLParamStr("KURACD") = pstrKURACD
                    cdb.pSQLParamStr("ACBCD") = pstrACBCD

                    'SQL���s
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    If CInt(ds.Tables(0).Rows(0).Item("CNT")) >= 100 Then
                        '*******************************************
                        '100���o�^����
                        '*******************************************
                        strRes = "6"
                        Exit Try
                    End If
                End If


                '*******************************************
                '�O���[�v�R�[�h�̑��݃`�F�b�N 2016/03/09 T.Ono add 2015���P�J��
                '�敪�ɖ��ɑΉ�����}�X�^�ɁA�O���[�v�̓o�^�����邩�m�F
                strSQL = New StringBuilder("")
                If pstrJAGKBN.Trim = "001" Then
                    strSQL.Append("SELECT GROUPCD ")
                    strSQL.Append("FROM M10_HANJIGYOSYA ")
                    strSQL.Append("WHERE GROUPCD = :GROUPCD ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString
                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

                ElseIf pstrJAGKBN.Trim = "002" Then
                    strSQL.Append("SELECT GROUPCD ")
                    strSQL.Append("FROM M11_JAHOKOKU ")
                    strSQL.Append("WHERE GROUPCD = :GROUPCD ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString
                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

                ElseIf pstrJAGKBN.Trim = "003" Then           '2017/02/09 w.ganeko 2016�Ď����P ��10
                    strSQL.Append("SELECT GROUPCD ")
                    strSQL.Append("FROM M08_AUTOTAIOU ")
                    strSQL.Append("WHERE GROUPCD = :GROUPCD ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString
                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

                ElseIf pstrJAGKBN.Trim = "004" Then '2019/01/28 T.Ono add 2018���P�J��
                    strSQL.Append("SELECT GROUPCD ")
                    strSQL.Append("FROM M12_HANBAITEN ")
                    strSQL.Append("WHERE GROUPCD = :GROUPCD ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString
                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD

                Else
                    strSQL.Append("SELECT 'X' ")
                    strSQL.Append("FROM DUAL ")
                    strSQL.Append("WHERE 1 <> 1 ")
                End If

                'SQL���s
                cdb.mExecQuery()
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�O���[�v�R�[�h�����݂��Ȃ���
                    '*******************************************
                    strRes = "7"
                    Exit Try
                End If
            End If

            '�f�[�^�̍X�V����--------------------------------

            If pintMODE = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("	    M09_JAGROUP ")
                strSQL.Append("WHERE ")
                strSQL.Append("	    KBN = :JAGKBN ")
                strSQL.Append("AND  KURACD = :KURACD ")
                strSQL.Append("AND	ACBCD = :ACBCD ")
                If pstrJAGKBN.Trim <> "003" Then           '2017/02/09 w.ganeko 2016�Ď����P ��10
                    If pstrUSERCD_F.Trim.Length > 0 Then
                        strSQL.Append("AND	USERCD_FROM = :USERCD_F ")
                    Else
                        strSQL.Append("AND	USERCD_FROM IS NULL ")
                    End If
                End If

            ElseIf pintMODE = 2 Then
                '�����敪���X�V
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("         M09_JAGROUP ")
                strSQL.Append("SET ")
                strSQL.Append("     	KBN = :JAGKBN, ")
                strSQL.Append("     	KURACD = :KURACD, ")
                strSQL.Append("     	ACBCD = :ACBCD, ")
                strSQL.Append("     	GROUPCD = :GROUPCD, ")
                strSQL.Append("     	USERCD_FROM = :USERCD_F, ")
                strSQL.Append("     	USERCD_TO = :USERCD_T, ")
                strSQL.Append("     	BIKO = :BIKO, ")
                strSQL.Append("     	INS_DATE = TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	INS_USER = :INS_USER, ")
                strSQL.Append("     	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	UPD_USER = :UPD_USER ")
                strSQL.Append("WHERE ")
                strSQL.Append("	    KBN = :JAGKBN ")
                strSQL.Append("AND  KURACD = :KURACD ")
                strSQL.Append("AND	ACBCD = :ACBCD ")
                If pstrJAGKBN.Trim <> "003" Then           '2017/02/09 w.ganeko 2016�Ď����P ��10
                    If pstrUSERCD_F.Trim.Length > 0 Then
                        strSQL.Append("AND	USERCD_FROM = :USERCD_F ")
                    Else
                        strSQL.Append("AND	USERCD_FROM IS NULL ")
                    End If
                End If
            ElseIf pintMODE = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append(" M09_JAGROUP (")
                strSQL.Append("     KBN, ")
                strSQL.Append("     KURACD, ")
                strSQL.Append("     ACBCD, ")
                strSQL.Append("     GROUPCD, ")
                strSQL.Append("     USERCD_FROM, ")
                strSQL.Append("     USERCD_TO, ")
                strSQL.Append("     BIKO, ")
                strSQL.Append("     INS_DATE, ")
                strSQL.Append("     INS_USER, ")
                strSQL.Append("     UPD_DATE, ")
                strSQL.Append("     UPD_USER ")
                strSQL.Append(") VALUES(")
                strSQL.Append("		:JAGKBN, ")
                strSQL.Append("		:KURACD, ")
                strSQL.Append("		:ACBCD, ")
                strSQL.Append("		:GROUPCD, ")
                strSQL.Append("		:USERCD_F, ")
                strSQL.Append("		:USERCD_T, ")
                strSQL.Append("		:BIKO, ")
                strSQL.Append("		TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		:INS_USER, ")
                strSQL.Append("		TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		:UPD_USER ")
                strSQL.Append(")")
            End If

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString
                '�o�C���h�ϐ��ɒl���Z�b�g
                If pintMODE = 3 Then
                    cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN
                    cdb.pSQLParamStr("ACBCD") = pstrACBCD
                    cdb.pSQLParamStr("KURACD") = pstrKURACD
                    If pstrUSERCD_F.Trim.Length > 0 Then
                        cdb.pSQLParamStr("USERCD_F") = pstrUSERCD_F
                    End If

                ElseIf pintMODE = 1 Or pintMODE = 2 Then

                    cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN
                    cdb.pSQLParamStr("ACBCD") = pstrACBCD
                    cdb.pSQLParamStr("KURACD") = pstrKURACD
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("BIKO") = pstrBIKO
                    cdb.pSQLParamStr("USERCD_F") = pstrUSERCD_F
                    cdb.pSQLParamStr("USERCD_T") = pstrUSERCD_T


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
    '******************************************************************************
    '*�@�T�@�v:�ꗗ�̏o�͂��s���܂�
    '*�@���@�l:
    '******************************************************************************
    '�@DATA0:�Ώۃf�[�^������܂���
    <WebMethod()> Public Function mCSV( _
                                        ByVal pstrSessionID As String, _
                                        ByVal pstrAUTHCENTERCD As String, _
                                        ByVal pstrJAGKBN As String, _
                                        ByVal pstrKURACD As String, _
                                        ByVal pstrACBCD_F As String, _
                                        ByVal pstrACBCD_T As String, _
                                        ByVal pstrGROUPCD As String, _
                                        ByVal pstrSYU_TOUROKU As Boolean, _
                                        ByVal pstrSYU_MITOUROKU As Boolean _
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

        '�֘A����Ď��Z���^�[�̃N���C�A���g�R�[�h�̂ݏo�͂��邱��
        '�`�c�F�؂��ꂽ�u�g�p�\�Ď��Z���^�[�v�ɏ�������N���C�A���g���o��
        Dim i As Integer
        Dim arrTemp() As String
        Dim strCenter As String = ""
        arrTemp = pstrAUTHCENTERCD.Split(Convert.ToChar(","))
        For i = 0 To arrTemp.Length - 1
            If strCenter.Length > 0 Then
                strCenter = strCenter & ","
            End If
            strCenter = strCenter & "'" & arrTemp(i) & "'"
        Next

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            Return ex.ToString
        Finally
        End Try
        Try
            strSQL = New StringBuilder("")
            strSQL.Append("WITH Z AS( ")

            If pstrSYU_TOUROKU = True Then
                '�o�^��
                strSQL.Append("SELECT CASE WHEN USERCD_FROM IS NULL THEN '1' ")
                strSQL.Append("	WHEN USERCD_FROM IS NOT NULL AND USERCD_TO IS NOT NULL THEN '2' ")
                strSQL.Append("	WHEN USERCD_FROM IS NOT NULL AND USERCD_TO IS NULL THEN '3' ")
                strSQL.Append("	ELSE '0' ")
                strSQL.Append("	END AS NO ")
                strSQL.Append("	,A.KBN ")
                strSQL.Append("	,A.KURACD ")
                strSQL.Append("	,A.ACBCD ")
                strSQL.Append("	,A.GROUPCD ")
                strSQL.Append("	,A.USERCD_FROM ")
                strSQL.Append("	,A.USERCD_TO ")
                strSQL.Append("	,A.BIKO ")
                strSQL.Append("	,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
                strSQL.Append("	,A.INS_USER ")
                strSQL.Append("	,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
                strSQL.Append("	,A.UPD_USER ")
                strSQL.Append("	,B.GROUPNM ")
                strSQL.Append("	,A.KURACD AS KURACD2 ") '�ײ��Ă̈ꗗ����邽�߂Ɏg�p
                strSQL.Append("	,A.ACBCD AS ACBCD2 ") 'JA�x���̈ꗗ����邽�߂Ɏg�p
                strSQL.Append("FROM M09_JAGROUP A ")
                strSQL.Append(" ,CLIMAS C ") '�Ď��������ނł̍i���@2015/12/10 T.Ono add 
                '�O���[�v���̎擾
                If pstrJAGKBN.Trim = "001" Then
                    '�̔����Ǝ҃O���[�v�}�X�^
                    strSQL.Append(" ,M10_HANJIGYOSYA B ")
                ElseIf pstrJAGKBN.Trim = "002" Then
                    'JA�S���ҁE�A����E���ӎ����}�X�^�@2015/12/10 T.Ono add 2015���P�J�� ��7
                    strSQL.Append(" ,M11_JAHOKOKU B ")
                ElseIf pstrJAGKBN.Trim = "003" Then
                    '�����Ή��}�X�^�@2017/02/09 W.Ganeko add 2016���P�J�� ��10
                    strSQL.Append(" ,(SELECT GROUPCD,GROUPNM FROM M08_AUTOTAIOU GROUP BY GROUPCD,GROUPNM) B ")
                ElseIf pstrJAGKBN.Trim = "004" Then
                    '�̔��X�O���[�v�}�X�^�@2019/01/28 T.Ono add 2018���P�J��
                    strSQL.Append(" ,M12_HANBAITEN B ")
                End If
                strSQL.Append("WHERE 1=1 ")
                strSQL.Append("AND A.KBN = :JAGKBN ")
                '�Ď��Z���^�[�R�[�h�B�w��̊Ď��Z���^�[�̂݁B�w�肪�����ꍇ�͑S�āB2015/12/10 T.Ono add 
                If strCenter.Length > 0 Then
                    strSQL.Append("AND C.KANSI_CODE IN (" & strCenter & ") ")
                End If
                strSQL.Append("AND A.KURACD = C.CLI_CD ") '2015/12/10 T.Ono add 

                If pstrKURACD.Trim.Length > 0 Then
                    strSQL.Append("AND A.KURACD = :KURACD ")
                End If
                If pstrACBCD_F.Trim.Length > 0 AndAlso pstrACBCD_T.Trim.Length > 0 Then
                    strSQL.Append("AND A.ACBCD >= :ACBCD_F ")
                    strSQL.Append("AND A.ACBCD <= :ACBCD_T ")
                End If
                If pstrGROUPCD.Trim.Length > 0 Then
                    strSQL.Append("AND A.GROUPCD = :GROUPCD ")
                End If
                '�敪�ɂ��A�����ύX
                If pstrJAGKBN.Trim = "001" Then
                    strSQL.Append("AND A.GROUPCD = B.GROUPCD(+) ")
                ElseIf pstrJAGKBN.Trim = "002" Then '2015/12/10 T.Ono add 2015���P�J�� ��7
                    strSQL.Append("AND A.GROUPCD = B.GROUPCD(+) ")
                    strSQL.Append("AND LPAD(B.TANCD, 2, '0') = '01' ")
                ElseIf pstrJAGKBN.Trim = "003" Then '2017/02/09 W.GANEKO add 2016���P�J�� ��10
                    strSQL.Append("AND A.GROUPCD = B.GROUPCD(+) ")
                ElseIf pstrJAGKBN.Trim = "004" Then '2019/01/28 T.Ono add 2018�J�����P
                    strSQL.Append("AND A.GROUPCD = B.GROUPCD(+) ")
                End If
            End If

            If pstrSYU_TOUROKU = True AndAlso pstrSYU_MITOUROKU = True Then
                strSQL.Append("UNION ALL ")
            End If

            If pstrSYU_MITOUROKU = True Then
                strSQL.Append("SELECT '1' AS NO ")
                strSQL.Append("	,:JAGKBN AS KBN ")
                strSQL.Append("	,'' AS KURACD ")
                strSQL.Append("	,'' ACBCD ")
                strSQL.Append("	,'' AS GROUPCD ")
                strSQL.Append("	,'' AS USERCD_FROM ")
                strSQL.Append("	,'' AS USERCD_TO ")
                strSQL.Append("	,'' AS BIKO ")
                strSQL.Append("	,'' AS INS_DATE ")
                strSQL.Append("	,'' AS INS_USER ")
                strSQL.Append("	,'' AS UPD_DATE ")
                strSQL.Append("	,'' AS UPD_USER ")
                strSQL.Append("	,'' AS GROUPNM ")
                strSQL.Append("	,A.CLI_CD AS KURACD2 ") '�ײ��Ă̈ꗗ����邽�߂Ɏg�p
                strSQL.Append("	,A.HAN_CD AS ACBCD2 ") 'JA�x���̈ꗗ����邽�߂Ɏg�p
                strSQL.Append("FROM HN2MAS A ")
                strSQL.Append("	,HN2MAS B ")
                strSQL.Append("	,CLIMAS C ")
                strSQL.Append("WHERE NOT EXISTS (SELECT 'X' ")
                strSQL.Append("	FROM M09_JAGROUP D ")
                strSQL.Append("	WHERE 1=1 ")
                strSQL.Append("	AND D.KBN = :JAGKBN ")
                strSQL.Append("	AND D.KURACD = A.CLI_CD ")
                strSQL.Append("	AND D.ACBCD = A.HAN_CD ")
                strSQL.Append("	AND D.USERCD_FROM IS NULL ")
                strSQL.Append("	) ")
                strSQL.Append("AND A.CLI_CD = B.CLI_CD ")
                strSQL.Append("AND A.HAN_CD = B.HAN_CD ")
                strSQL.Append("AND A.HAN_CD <> B.JA_CD ")
                strSQL.Append("AND C.CLI_CD = A.CLI_CD ")
                strSQL.Append("AND NVL(A.DEL_FLG,'0') <> '1' ")
                strSQL.Append("AND NVL(B.DEL_FLG,'0') <> '1' ")
                '�Ď��Z���^�[�R�[�h�B�w��̊Ď��Z���^�[�̂݁B�w�肪�����ꍇ�͑S�āB
                If strCenter.Length > 0 Then
                    strSQL.Append("AND C.KANSI_CODE IN (" & strCenter & ") ")
                End If
                If pstrKURACD.Trim.Length > 0 Then
                    strSQL.Append("AND A.CLI_CD = :KURACD ")
                End If
                If pstrACBCD_F.Trim.Length > 0 AndAlso pstrACBCD_T.Trim.Length > 0 Then
                    strSQL.Append("AND A.HAN_CD >= :ACBCD_F ")
                    strSQL.Append("AND A.HAN_CD <= :ACBCD_T ")
                End If
            End If

            strSQL.Append(") ")
            strSQL.Append("SELECT ")
            strSQL.Append("	Z.KBN AS KBN ")
            strSQL.Append("	,Z.KURACD AS KURACD ")
            strSQL.Append("	,Z.ACBCD AS ACBCD ")
            strSQL.Append("	,Z.GROUPCD AS GROUPCD ")
            strSQL.Append("	,Z.GROUPNM AS GROUPNM ")
            strSQL.Append("	,Z.USERCD_FROM AS USERCD_FROM ")
            strSQL.Append("	,Z.USERCD_TO AS USERCD_TO ")
            strSQL.Append("	,Z.BIKO AS BIKO ")
            strSQL.Append("	,Z.INS_DATE AS INS_DATE ")
            strSQL.Append("	,Z.INS_USER AS INS_USER ")
            strSQL.Append("	,Z.UPD_DATE AS UPD_DATE ")
            strSQL.Append("	,Z.UPD_USER AS UPD_USER ")
            strSQL.Append("	,A.CLI_CD AS HN2_KURACD ")
            strSQL.Append("	,A.HAN_CD AS HN2_ACBCD ")
            strSQL.Append("	,A.JAS_NAME AS HN2_ACBNM ")
            strSQL.Append("FROM Z, HN2MAS A ")
            strSQL.Append("WHERE Z.KURACD2 = A.CLI_CD ")
            strSQL.Append("AND Z.ACBCD2 = A.HAN_CD ")
            strSQL.Append("ORDER BY KBN, HN2_KURACD, HN2_ACBCD, NO, USERCD_FROM ")


            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            '�O���[�v�敪
            If pstrJAGKBN.Trim.Length > 0 Then
                cdb.pSQLParamStr("JAGKBN") = pstrJAGKBN
            End If
            '�N���C�A���g�R�[�h
            If pstrKURACD.Trim.Length > 0 Then
                cdb.pSQLParamStr("KURACD") = pstrKURACD
            End If
            'JA�x���R�[�h
            If pstrACBCD_F.Trim.Length > 0 AndAlso pstrACBCD_T.Trim.Length > 0 Then
                cdb.pSQLParamStr("ACBCD_F") = pstrACBCD_F
                cdb.pSQLParamStr("ACBCD_T") = pstrACBCD_T
            End If
            '�O���[�v�R�[�h
            If pstrGROUPCD.Trim.Length > 0 AndAlso pstrSYU_TOUROKU = True Then
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
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
            CSVC.pRepoID = "MSJAGJAW00"       '���[ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "�敪"
                    CSVC.pColValStrEx = "�N���C�A���g"
                    CSVC.pColValStrEx = "JA�x���R�[�h"
                    CSVC.pColValStrEx = "�O���[�v�R�[�h"
                    CSVC.pColValStrEx = "�O���[�v��"
                    CSVC.pColValStrEx = "���q�l�R�[�hFrom"
                    CSVC.pColValStrEx = "���q�l�R�[�hTo"
                    CSVC.pColValStrEx = "���l"
                    CSVC.pColValStrEx = "�o�^����"
                    CSVC.pColValStrEx = "�o�^��"
                    CSVC.pColValStrEx = "�X�V����"
                    CSVC.pColValStrEx = "�X�V��"
                    CSVC.pColValStrEx = "�x���Q�ײ���"
                    CSVC.pColValStrEx = "�x���QJA�x������"
                    CSVC.pColValStrEx = "�x���QJA�x����"
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
            '�G���[�̓��e�Ƃr�p�k����Ԃ�
            Return "ERROR:" & ex.ToString

        Finally
            cdb.mClose()        '�ڑ��N���[�Y
        End Try

    End Function

    '************************************************
    '�̔����Ǝ҃O���[�v�ǉ��E�ύX�@pintMODE=7:�ǉ��@9:�ύX
    '************************************************
    <WebMethod()> Public Function mSetHANJIGYOSYA( _
                                ByVal pintMODE As Integer, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrGROUPNM As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String _
                                ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim tmp As String

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
            '*********************************

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.GROUPCD ")
            strSQL.Append("	    ,A.GROUPNM ")
            strSQL.Append("	    ,A.HANJIGYOSYANM ")
            strSQL.Append("	    ,A.BIKO ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,A.INS_USER ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	    ,A.UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M10_HANJIGYOSYA A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.GROUPCD = :GROUPCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD         '�O���[�v�R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 7 Then '�ǉ��{�^��
                    strRes = "1" '�o�^�ς݃f�[�^����̃G���[
                    pintMODE = 0 '�I��
                End If
            Else
                If pintMODE = 9 Then '�ύX�{�^��
                    strRes = "2" '�Y���f�[�^�Ȃ��̃G���[
                    pintMODE = 0 '�I��
                End If
            End If

            If (pintMODE = 9) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    pintMODE = 0 '�I��
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) _
                     ) Then

                    pintMODE = 0 '�I��
                End If
            End If


            If pintMODE <> 0 Then
                '�f�[�^�̍X�V����--------------------------------
                '�ǉ�����
                If pintMODE = 9 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("	M10_HANJIGYOSYA ")
                    strSQL.Append("SET ")
                    strSQL.Append("	GROUPCD = :GROUPCD, ")
                    strSQL.Append("	GROUPNM = :GROUPNM, ")
                    strSQL.Append("	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("	UPD_USER = :UPD_USER ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("	GROUPCD = :GROUPCD ")

                ElseIf pintMODE = 7 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO ")
                    strSQL.Append(" M10_HANJIGYOSYA ( ")
                    strSQL.Append("     GROUPCD, ")
                    strSQL.Append("     GROUPNM, ")
                    strSQL.Append("     HANJIGYOSYANM, ")
                    strSQL.Append("     BIKO, ")
                    strSQL.Append("     INS_DATE, ")
                    strSQL.Append("     INS_USER, ")
                    strSQL.Append("     UPD_DATE, ")
                    strSQL.Append("     UPD_USER ")
                    strSQL.Append(") VALUES( ")
                    strSQL.Append("		:GROUPCD, ")
                    strSQL.Append("		:GROUPNM, ")
                    strSQL.Append("		:HANJIGYOSYANM, ")
                    strSQL.Append("		:BIKO, ")
                    strSQL.Append("		TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("		:INS_USER, ")
                    strSQL.Append("		TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("		:UPD_USER ")
                    strSQL.Append(")")
                End If

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�o�C���h�ϐ��ɒl���Z�b�g
                If pintMODE = 9 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim

                ElseIf pintMODE = 7 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("HANJIGYOSYANM") = ""
                    cdb.pSQLParamStr("BIKO") = ""
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                End If

                'SQL�����s
                cdb.mExecNonQuery()
            End If


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
    'JA�S���ҁE�񍐐�E���ӎ����O���[�v�ǉ��E�ύX�@pintMODE=7:�ǉ��@9:�ύX
    '************************************************
    <WebMethod()> Public Function mSetJAHOKOKU( _
                                ByVal pintMODE As Integer, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrGROUPNM As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String _
                                ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim tmp As String

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
            '*********************************

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.GROUPCD ")
            strSQL.Append("	    ,A.GROUPNM ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,A.INS_USER ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	    ,A.UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M11_JAHOKOKU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.GROUPCD = :GROUPCD ")
            strSQL.Append("AND  LPAD(A.TANCD, 2, '0') = '01' ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD         '�O���[�v�R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 7 Then '�ǉ��{�^��
                    strRes = "1" '�o�^�ς݃f�[�^����̃G���[
                    pintMODE = 0 '�I��
                End If
            Else
                If pintMODE = 9 Then '�ύX�{�^��
                    strRes = "2" '�Y���f�[�^�Ȃ��̃G���[
                    pintMODE = 0 '�I��
                End If
            End If

            If (pintMODE = 9) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    pintMODE = 0 '�I��
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) _
                     ) Then

                    pintMODE = 0 '�I��
                End If
            End If

            '�O���[�v�R�[�h���̏d����NG�Ƃ��� 2016/01/12 T.Ono add 2015���P�J�� 
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("     'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("		M11_JAHOKOKU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		1 = 1 ")
            strSQL.Append("AND	LPAD(A.TANCD,2,'0') = '01' ")
            strSQL.Append("AND	A.GROUPCD <> :GROUPCD ")
            strSQL.Append("AND	A.GROUPNM = :GROUPNM ")

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       '�O���[�v�R�[�h
            cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM       '�O���[�v�R�[�h��

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            If (ds.Tables(0).Rows.Count > 0) Then
                '*******************************************
                '�O���[�v�R�[�h���d��
                '*******************************************
                strRes = "3"
                Exit Try
            End If


            If pintMODE <> 0 Then
                '�f�[�^�̍X�V����--------------------------------
                '�ǉ�����
                If pintMODE = 9 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("	M11_JAHOKOKU ")
                    strSQL.Append("SET ")
                    strSQL.Append("	GROUPCD = :GROUPCD, ")
                    strSQL.Append("	GROUPNM = :GROUPNM, ")
                    strSQL.Append("	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("	UPD_USER = :UPD_USER ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("	GROUPCD = :GROUPCD ")
                    strSQL.Append("AND  LPAD(TANCD, 2, '0') = '01' ")

                ElseIf pintMODE = 7 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO  ")
                    strSQL.Append(" M11_JAHOKOKU ( ")
                    strSQL.Append("     KBN, ")
                    strSQL.Append("     GROUPCD, ")
                    strSQL.Append("     GROUPNM, ")
                    strSQL.Append("     TANNM, ")
                    strSQL.Append("     TANCD, ")
                    strSQL.Append("     RENTEL1, ")
                    strSQL.Append("     FAXKURAKBN, ")
                    strSQL.Append("     FAXKBN, ")
                    strSQL.Append("     INS_DATE, ")
                    strSQL.Append("     INS_USER, ")
                    strSQL.Append("     UPD_DATE, ")
                    strSQL.Append("     UPD_USER ")
                    strSQL.Append(") VALUES( ")
                    strSQL.Append("     '2', ")         '�敪�@2�F�O���[�v�R�[�h�o�^
                    strSQL.Append("     :GROUPCD, ")
                    strSQL.Append("     :GROUPNM, ")
                    strSQL.Append("     '0', ")         '�S���Җ�����
                    strSQL.Append("     '01', ")        '�R�[�h
                    strSQL.Append("     '0', ")         '�d�b�ԍ��P
                    strSQL.Append("     '0', ")         '�񍐗v�E�s�v�����l�ײ���
                    strSQL.Append("     '0', ")         '�񍐗v�E�s�v�����lJA
                    strSQL.Append("     TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("     :INS_USER, ")
                    strSQL.Append("     TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("     :UPD_USER ")
                    strSQL.Append(")")
                End If

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�o�C���h�ϐ��ɒl���Z�b�g
                If pintMODE = 9 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim

                ElseIf pintMODE = 7 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                End If

                'SQL�����s
                cdb.mExecNonQuery()
            End If


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
    '2017/02/09 W.GANEKO ADD START 2016�Ď����P ��10
    '************************************************
    '�����Ή��O���[�v�ǉ��E�ύX�@pintMODE=7:�ǉ��@9:�ύX
    '************************************************
    <WebMethod()> Public Function mSetAUTOTAIOU( _
                                ByVal pintMODE As Integer, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrGROUPNM As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrINS_USER As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrUPD_USER As String, _
                                ByVal pstrUSERNM As String _
                                ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim tmp As String

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
            '*********************************

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.GROUPCD ")
            strSQL.Append("	    ,A.GROUPNM ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M08_AUTOTAIOU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.GROUPCD = :GROUPCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD         '�O���[�v�R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 7 Then '�ǉ��{�^��
                    strRes = "1" '�o�^�ς݃f�[�^����̃G���[
                    pintMODE = 0 '�I��
                End If
            Else
                If pintMODE = 9 Then '�ύX�{�^��
                    strRes = "2" '�Y���f�[�^�Ȃ��̃G���[
                    pintMODE = 0 '�I��
                End If
            End If

            If (pintMODE = 9) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    pintMODE = 0 '�I��
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) _
                     ) Then

                    pintMODE = 0 '�I��
                End If
            End If

            '�O���[�v�R�[�h���̏d����NG�Ƃ���
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("     'X' ")
            strSQL.Append("FROM ")
            strSQL.Append("		M08_AUTOTAIOU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		1 = 1 ")
            strSQL.Append("AND	A.GROUPCD <> :GROUPCD ")
            strSQL.Append("AND	A.GROUPNM = :GROUPNM ")

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       '�O���[�v�R�[�h
            cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM       '�O���[�v�R�[�h��

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            If (ds.Tables(0).Rows.Count > 0) Then
                '*******************************************
                '�O���[�v�R�[�h���d��
                '*******************************************
                strRes = "3"
                Exit Try
            End If


            If pintMODE <> 0 Then
                '�f�[�^�̍X�V����--------------------------------
                '�ǉ�����
                If pintMODE = 9 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("	M08_AUTOTAIOU ")
                    strSQL.Append("SET ")
                    strSQL.Append("	GROUPCD = :GROUPCD, ")
                    strSQL.Append("	GROUPNM = :GROUPNM, ")
                    strSQL.Append("	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("	GROUPCD = :GROUPCD ")

                ElseIf pintMODE = 7 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO  ")
                    strSQL.Append(" M08_AUTOTAIOU ( ")
                    strSQL.Append("     GROUPCD, ")
                    strSQL.Append("     KMCD, ")
                    strSQL.Append("     KMNM, ")
                    strSQL.Append("     PROCKBN, ")
                    strSQL.Append("     TAIOKBN, ")
                    strSQL.Append("     TMSKB, ")
                    strSQL.Append("     TKTANCD, ")
                    strSQL.Append("     TAITCD, ")
                    strSQL.Append("     TFKICD, ")
                    strSQL.Append("     TKIGCD, ")
                    strSQL.Append("     TSADCD, ")
                    strSQL.Append("     TELRCD, ")
                    strSQL.Append("     TEL_MEMO1, ")
                    strSQL.Append("     USE_FLG, ")
                    strSQL.Append("     INS_DATE, ")
                    strSQL.Append("     UPD_DATE, ")
                    strSQL.Append("     BIKO, ")
                    strSQL.Append("     GROUPNM ")
                    strSQL.Append(") VALUES( ")
                    strSQL.Append("     :GROUPCD, ")    '�O���[�v�R�[�h
                    strSQL.Append("     '99', ")        '�x��R�[�h
                    strSQL.Append("     '0', ")         '�x�񖼏�
                    strSQL.Append("     '1', ")         '�Ή��^�����敪
                    strSQL.Append("     NULL, ")        '�Ή��敪
                    strSQL.Append("     NULL, ")        '�����敪
                    strSQL.Append("     NULL, ")        '�Ď��Z���^�[�S����CD
                    strSQL.Append("     NULL, ")        '�A������CD
                    strSQL.Append("     NULL, ")        '���A�Ή���
                    strSQL.Append("     NULL, ")        '�K�X���
                    strSQL.Append("     NULL, ")        '�쓮����
                    strSQL.Append("     NULL, ")        '�d�b�A�����e
                    strSQL.Append("     NULL, ")        '�d�b�Ή������P
                    strSQL.Append("     '1', ")         '�g�p�t���O
                    strSQL.Append("     TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("     TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("     NULL, ")        '���l
                    strSQL.Append("     :GROUPNM ")     '�O���[�v����
                    strSQL.Append(")")
                End If

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�o�C���h�ϐ��ɒl���Z�b�g
                If pintMODE = 9 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()

                ElseIf pintMODE = 7 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                End If

                'SQL�����s
                cdb.mExecNonQuery()
            End If


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
    '�̔��X�O���[�v�ǉ��E�ύX�@pintMODE=7:�ǉ��@9:�ύX
    '************************************************
    <WebMethod()> Public Function mSetHANBAITEN(
                                ByVal pintMODE As Integer,
                                ByVal pstrGROUPCD As String,
                                ByVal pstrGROUPNM As String,
                                ByVal pstrINS_DATE As String,
                                ByVal pstrINS_USER As String,
                                ByVal pstrUPD_DATE As String,
                                ByVal pstrUPD_USER As String,
                                ByVal pstrUSERNM As String
                                ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim tmp As String

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
            '*********************************

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("	    A.GROUPCD ")
            strSQL.Append("	    ,A.GROUPNM ")
            strSQL.Append("	    ,A.HANBAITENNM ")
            strSQL.Append("	    ,A.BIKO ")
            strSQL.Append("	    ,TO_CHAR(A.INS_DATE, 'YYYY/MM/DD HH24:MI:SS') AS INS_DATE ")
            strSQL.Append("	    ,A.INS_USER ")
            strSQL.Append("	    ,TO_CHAR(A.UPD_DATE, 'YYYY/MM/DD HH24:MI:SS') AS UPD_DATE ")
            strSQL.Append("	    ,A.UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("	    M12_HANBAITEN A ")
            strSQL.Append("WHERE ")
            strSQL.Append("	    A.GROUPCD = :GROUPCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD         '�O���[�v�R�[�h

            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult


            '*******************************
            ' ���[�h�̍Č���
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then '�c�a�Ƀf�[�^�����݂���H
                If pintMODE = 7 Then '�ǉ��{�^��
                    strRes = "1" '�o�^�ς݃f�[�^����̃G���[
                    pintMODE = 0 '�I��
                End If
            Else
                If pintMODE = 9 Then '�ύX�{�^��
                    strRes = "2" '�Y���f�[�^�Ȃ��̃G���[
                    pintMODE = 0 '�I��
                End If
            End If

            If (pintMODE = 9) Then '�c�a�Ƀf�[�^�����݂��āA�X�V�̏ꍇ
                '*******************************************
                '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                '*******************************************
                tmp = Convert.ToString(ds.Tables(0).Rows(0).Item("INS_DATE")) & "_" & Convert.ToString(ds.Tables(0).Rows(0).Item("UPD_DATE"))
                If (tmp <> pstrINS_DATE & "_" & pstrUPD_DATE) Then
                    strRes = "0"
                    pintMODE = 0 '�I��
                End If

                '*******************************************
                ' �C�����Ńf�[�^���ύX����Ă��Ȃ��ꍇ�̓X�L�b�v
                '*******************************************
                If (
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = pstrGROUPCD) And
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM)
                     ) Then

                    pintMODE = 0 '�I��
                End If
            End If


            If pintMODE <> 0 Then
                '�f�[�^�̍X�V����--------------------------------
                '�ǉ�����
                If pintMODE = 9 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("UPDATE ")
                    strSQL.Append("	M12_HANBAITEN ")
                    strSQL.Append("SET ")
                    strSQL.Append("	GROUPCD = :GROUPCD, ")
                    strSQL.Append("	GROUPNM = :GROUPNM, ")
                    strSQL.Append("	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("	UPD_USER = :UPD_USER ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("	GROUPCD = :GROUPCD ")

                ElseIf pintMODE = 7 Then
                    strSQL = New StringBuilder("")
                    strSQL.Append("INSERT INTO ")
                    strSQL.Append(" M12_HANBAITEN ( ")
                    strSQL.Append("     GROUPCD, ")
                    strSQL.Append("     GROUPNM, ")
                    strSQL.Append("     HANBAITENNM, ")
                    strSQL.Append("     BIKO, ")
                    strSQL.Append("     INS_DATE, ")
                    strSQL.Append("     INS_USER, ")
                    strSQL.Append("     UPD_DATE, ")
                    strSQL.Append("     UPD_USER ")
                    strSQL.Append(") VALUES( ")
                    strSQL.Append("		:GROUPCD, ")
                    strSQL.Append("		:GROUPNM, ")
                    strSQL.Append("		:HANBAITENNM, ")
                    strSQL.Append("		:BIKO, ")
                    strSQL.Append("		TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("		:INS_USER, ")
                    strSQL.Append("		TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                    strSQL.Append("		:UPD_USER ")
                    strSQL.Append(")")
                End If

                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�o�C���h�ϐ��ɒl���Z�b�g
                If pintMODE = 9 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_USER") = pstrUSERNM.Trim

                ElseIf pintMODE = 7 Then
                    cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                    cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM
                    cdb.pSQLParamStr("HANBAITENNM") = ""
                    cdb.pSQLParamStr("BIKO") = ""
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("INS_USER") = pstrUSERNM.Trim
                    cdb.pSQLParamStr("UPD_DATE") = ""
                    cdb.pSQLParamStr("UPD_USER") = ""
                End If

                'SQL�����s
                cdb.mExecNonQuery()
            End If


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
