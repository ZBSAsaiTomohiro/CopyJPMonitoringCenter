'***********************************************
'�����Ή����e�}�X�^
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


<System.Web.Services.WebService(Namespace:="http://tempuri.org/MSJINJAW00/Service1")> _
Public Class MSJINJAW00
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
                                    ByVal pstrGROUPCD As String, _
                                    ByVal pstrKMCD() As String, _
                                    ByVal pstrKMNM() As String, _
                                    ByVal pstrPROCKBN() As String, _
                                    ByVal pstrTAIOKBN() As String, _
                                    ByVal pstrTMSKB() As String, _
                                    ByVal pstrTKTANCD() As String, _
                                    ByVal pstrTAITCD() As String, _
                                    ByVal pstrTFKICD() As String, _
                                    ByVal pstrTKIGCD() As String, _
                                    ByVal pstrTSADCD() As String, _
                                    ByVal pstrTELRCD() As String, _
                                    ByVal pstrTEL_MEMO1() As String, _
                                    ByVal pstrUSE_FLG() As String, _
                                    ByVal pstrINS_DATE() As String, _
                                    ByVal pstrUPD_DATE() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrDEL() As String
                                    ) As String

        ' ------------------------------
        '�z�����ŗp��
        Dim strKMCD() As String
        strKMCD = New String(pstrKMCD.Length) {} '�z��̎��̂��m��
        Dim strKMNM() As String
        strKMNM = New String(pstrKMNM.Length) {} '�z��̎��̂��m��
        Dim strPROCKBN() As String
        strPROCKBN = New String(pstrPROCKBN.Length) {} '�z��̎��̂��m��
        Dim strTAIOKBN() As String
        strTAIOKBN = New String(pstrTAIOKBN.Length) {} '�z��̎��̂��m��
        Dim strTMSKB() As String
        strTMSKB = New String(pstrTMSKB.Length) {} '�z��̎��̂��m��
        Dim strTKTANCD() As String
        strTKTANCD = New String(pstrTKTANCD.Length) {} '�z��̎��̂��m��
        Dim strTAITCD() As String
        strTAITCD = New String(pstrTAITCD.Length) {} '�z��̎��̂��m��
        Dim strTFKICD() As String
        strTFKICD = New String(pstrTFKICD.Length) {} '�z��̎��̂��m��
        Dim strTKIGCD() As String
        strTKIGCD = New String(pstrTKIGCD.Length) {} '�z��̎��̂��m��
        Dim strTSADCD() As String
        strTSADCD = New String(pstrTSADCD.Length) {} '�z��̎��̂��m��
        Dim strTELRCD() As String
        strTELRCD = New String(pstrTELRCD.Length) {} '�z��̎��̂��m��
        Dim strTEL_MEMO1() As String
        strTEL_MEMO1 = New String(pstrTEL_MEMO1.Length) {} '�z��̎��̂��m��
        Dim strUSE_FLG() As String
        strUSE_FLG = New String(pstrUSE_FLG.Length) {} '�z��̎��̂��m��
        Dim strDEL() As String
        strDEL = New String(pstrDEL.Length) {} '�z��̎��̂��m��
        Dim strINS_DATE() As String
        strINS_DATE = New String(pstrINS_DATE.Length) {} '�z��̎��̂��m��
        Dim strUPD_DATE() As String
        strUPD_DATE = New String(pstrUPD_DATE.Length) {} '�z��̎��̂��m��
        Dim strBIKO() As String
        strBIKO = New String(pstrBIKO.Length) {} '�z��̎��̂��m��

        Dim i As Integer
        For i = 0 To strKMCD.Length
            strKMCD(i) = ""
            strKMNM(i) = ""
            strPROCKBN(i) = ""
            strTAIOKBN(i) = ""
            strTMSKB(i) = ""
            strTKTANCD(i) = ""
            strTAITCD(i) = ""
            strTFKICD(i) = ""
            strTKIGCD(i) = ""
            strTSADCD(i) = ""
            strTELRCD(i) = ""
            strTEL_MEMO1(i) = ""
            strUSE_FLG(i) = ""
            strINS_DATE(i) = ""
            strUPD_DATE(i) = ""
            strBIKO(i) = ""
            strDEL(i) = ""
        Next
        ' ------------------------------

        '2017/02/09 W.GANEKO UPD 2016�Ď����P ��10
        'Return mSetEx(pintMODE, _
        '            pstrGROUPCD, _
        '            pstrKMCD, _
        '            pstrKMNM, _
        '            pstrPROCKBN, _
        '            pstrTAIOKBN, _
        '            pstrTMSKB, _
        '            pstrTKTANCD, _
        '            pstrTAITCD, _
        '            pstrTFKICD, _
        '            pstrTKIGCD, _
        '            pstrTSADCD, _
        '            pstrTELRCD, _
        '            pstrTEL_MEMO1, _
        '            pstrUSE_FLG, _
        '            pstrINS_DATE, _
        '            pstrUPD_DATE, _
        '            pstrBIKO, _
        '            pstrDEL)
        Return mSetEx(pintMODE, _
           pstrGROUPCD, _
           pstrKMCD, _
           pstrKMNM, _
           pstrPROCKBN, _
           pstrTAIOKBN, _
           pstrTMSKB, _
           pstrTKTANCD, _
           pstrTAITCD, _
           pstrTFKICD, _
           pstrTKIGCD, _
           pstrTSADCD, _
           pstrTELRCD, _
           pstrTEL_MEMO1, _
           pstrUSE_FLG, _
           pstrINS_DATE, _
           pstrUPD_DATE, _
           pstrBIKO, _
           pstrDEL, _
           "")
    End Function
    '2017/02/09 W.GANEKO UPD 2016�Ď����P ��10
    '<WebMethod()> Public Function mSetEx( _
    '                                ByVal pintMODE As Integer, _
    '                                ByVal pstrGROUPCD As String, _
    '                                ByVal pstrKMCD() As String, _
    '                                ByVal pstrKMNM() As String, _
    '                                ByVal pstrPROCKBN() As String, _
    '                                ByVal pstrTAIOKBN() As String, _
    '                                ByVal pstrTMSKB() As String, _
    '                                ByVal pstrTKTANCD() As String, _
    '                                ByVal pstrTAITCD() As String, _
    '                                ByVal pstrTFKICD() As String, _
    '                                ByVal pstrTKIGCD() As String, _
    '                                ByVal pstrTSADCD() As String, _
    '                                ByVal pstrTELRCD() As String, _
    '                                ByVal pstrTEL_MEMO1() As String, _
    '                                ByVal pstrUSE_FLG() As String, _
    '                                ByVal pstrINS_DATE() As String, _
    '                                ByVal pstrUPD_DATE() As String, _
    '                                ByVal pstrBIKO() As String, _
    '                                ByVal pstrDEL() As String
    '                                ) As String
    <WebMethod()> Public Function mSetEx( _
                                    ByVal pintMODE As Integer, _
                                    ByVal pstrGROUPCD As String, _
                                    ByVal pstrKMCD() As String, _
                                    ByVal pstrKMNM() As String, _
                                    ByVal pstrPROCKBN() As String, _
                                    ByVal pstrTAIOKBN() As String, _
                                    ByVal pstrTMSKB() As String, _
                                    ByVal pstrTKTANCD() As String, _
                                    ByVal pstrTAITCD() As String, _
                                    ByVal pstrTFKICD() As String, _
                                    ByVal pstrTKIGCD() As String, _
                                    ByVal pstrTSADCD() As String, _
                                    ByVal pstrTELRCD() As String, _
                                    ByVal pstrTEL_MEMO1() As String, _
                                    ByVal pstrUSE_FLG() As String, _
                                    ByVal pstrINS_DATE() As String, _
                                    ByVal pstrUPD_DATE() As String, _
                                    ByVal pstrBIKO() As String, _
                                    ByVal pstrDEL() As String, _
                                    ByVal pstrGROUPNM As String
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
            For i = 1 To 30 '30�����P�����o�^�^�C���^�폜����B
                mlog("loop:" & pstrDEL(i) & pstrGROUPCD & "_" & pstrKMCD(i) & "_" & pstrKMNM(i))

                '2017/02/09 W.GANEKO UPD 2016�Ď����P ��10
                'strRes = mSetTanto( _
                '        cdb, _
                '        pintMODE, _
                '        pstrGROUPCD, _
                '        pstrKMCD(i), _
                '        pstrKMNM(i), _
                '        pstrPROCKBN(i), _
                '        pstrTAIOKBN(i), _
                '        pstrTMSKB(i), _
                '        pstrTKTANCD(i), _
                '        pstrTAITCD(i), _
                '        pstrTFKICD(i), _
                '        pstrTKIGCD(i), _
                '        pstrTSADCD(i), _
                '        pstrTELRCD(i), _
                '        pstrTEL_MEMO1(i), _
                '        pstrUSE_FLG(i), _
                '        pstrINS_DATE(i), _
                '        pstrUPD_DATE(i), _
                '        pstrBIKO(i), _
                '        pstrDEL(i))
                strRes = mSetTanto( _
                        cdb, _
                        pintMODE, _
                        pstrGROUPCD, _
                        pstrKMCD(i), _
                        pstrKMNM(i), _
                        pstrPROCKBN(i), _
                        pstrTAIOKBN(i), _
                        pstrTMSKB(i), _
                        pstrTKTANCD(i), _
                        pstrTAITCD(i), _
                        pstrTFKICD(i), _
                        pstrTKIGCD(i), _
                        pstrTSADCD(i), _
                        pstrTELRCD(i), _
                        pstrTEL_MEMO1(i), _
                        pstrUSE_FLG(i), _
                        pstrINS_DATE(i), _
                        pstrUPD_DATE(i), _
                        pstrBIKO(i), _
                        pstrDEL(i), _
                        pstrGROUPNM)
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
    '2017/02/09 W.GANEKO UPD 2016�Ď����P ��10
    '<WebMethod()> Public Function mSetTanto( _
    '                            ByRef cdb As CDB, _
    '                            ByVal pintMODE As Integer, _
    '                            ByVal pstrGROUPCD As String, _
    '                            ByVal pstrKMCD As String, _
    '                            ByVal pstrKMNM As String, _
    '                            ByVal pstrPROCKBN As String, _
    '                            ByVal pstrTAIOKBN As String, _
    '                            ByVal pstrTMSKB As String, _
    '                            ByVal pstrTKTANCD As String, _
    '                            ByVal pstrTAITCD As String, _
    '                            ByVal pstrTFKICD As String, _
    '                            ByVal pstrTKIGCD As String, _
    '                            ByVal pstrTSADCD As String, _
    '                            ByVal pstrTELRCD As String, _
    '                            ByVal pstrTEL_MEMO1 As String, _
    '                            ByVal pstrUSE_FLG As String, _
    '                            ByVal pstrINS_DATE As String, _
    '                            ByVal pstrUPD_DATE As String, _
    '                            ByVal pstrBIKO As String, _
    '                            ByVal pstrDEL As String
    '                            ) As String
    <WebMethod()> Public Function mSetTanto( _
                                ByRef cdb As CDB, _
                                ByVal pintMODE As Integer, _
                                ByVal pstrGROUPCD As String, _
                                ByVal pstrKMCD As String, _
                                ByVal pstrKMNM As String, _
                                ByVal pstrPROCKBN As String, _
                                ByVal pstrTAIOKBN As String, _
                                ByVal pstrTMSKB As String, _
                                ByVal pstrTKTANCD As String, _
                                ByVal pstrTAITCD As String, _
                                ByVal pstrTFKICD As String, _
                                ByVal pstrTKIGCD As String, _
                                ByVal pstrTSADCD As String, _
                                ByVal pstrTELRCD As String, _
                                ByVal pstrTEL_MEMO1 As String, _
                                ByVal pstrUSE_FLG As String, _
                                ByVal pstrINS_DATE As String, _
                                ByVal pstrUPD_DATE As String, _
                                ByVal pstrBIKO As String, _
                                ByVal pstrDEL As String, _
                                ByVal pstrGROUPNM As String
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
            strSQL.Append("  	    A.GROUPCD ")
            strSQL.Append(" 	    ,A.KMCD ")
            strSQL.Append(" 	    ,A.KMNM ")
            strSQL.Append(" 	    ,A.PROCKBN ")
            strSQL.Append(" 	    ,A.TAIOKBN ")
            strSQL.Append(" 	    ,A.TMSKB ")
            strSQL.Append(" 	    ,A.TKTANCD ")
            strSQL.Append(" 	    ,A.TAITCD ")
            strSQL.Append(" 	    ,A.TFKICD ")
            strSQL.Append(" 	    ,A.TKIGCD ")
            strSQL.Append(" 	    ,A.TSADCD ")
            strSQL.Append(" 	    ,A.TELRCD ")
            strSQL.Append(" 	    ,A.TEL_MEMO1 ")
            strSQL.Append(" 	    ,A.USE_FLG ")
            strSQL.Append(" 	    ,A.INS_DATE ")
            strSQL.Append(" 	    ,A.UPD_DATE ")
            strSQL.Append(" 		,A.BIKO ")
            strSQL.Append(" 		,A.GROUPNM ") '2017/02/09 W.GANEKO 2016�Ď����P ��10
            strSQL.Append("FROM ")
            strSQL.Append("		M08_AUTOTAIOU A ")
            strSQL.Append("WHERE ")
            strSQL.Append("		A.GROUPCD = :GROUPCD ")
            strSQL.Append("AND		A.KMCD = :KMCD ")
            strSQL.Append("AND		A.KMNM = :KMNM ")
            strSQL.Append("ORDER BY A.KMCD ")
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD       '�O���[�v�R�[�h
            cdb.pSQLParamStr("KMCD") = pstrKMCD             '�x��R�[�h
            cdb.pSQLParamStr("KMNM") = pstrKMNM             '�x�񖼏�

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
                If pstrKMCD = "" Then '�o�^���f�[�^�͂Ȃ��H
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
                '2017/02/09 W.GANEKO 2016�Ď����P ��10
                'If ( _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("KMCD")) = pstrKMCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("KMNM")) = pstrKMNM) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("PROCKBN")) = pstrPROCKBN) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TAIOKBN")) = pstrTAIOKBN) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TMSKB")) = pstrTMSKB) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TKTANCD")) = pstrTKTANCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TAITCD")) = pstrTAITCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TFKICD")) = pstrTFKICD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TKIGCD")) = pstrTKIGCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TSADCD")) = pstrTSADCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TELRCD")) = pstrTELRCD) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("TEL_MEMO1")) = pstrTEL_MEMO1) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("USE_FLG")) = pstrUSE_FLG) And _
                '        (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) _
                '     ) Then
                If ( _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KMCD")) = pstrKMCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("KMNM")) = pstrKMNM) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("PROCKBN")) = pstrPROCKBN) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TAIOKBN")) = pstrTAIOKBN) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TMSKB")) = pstrTMSKB) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TKTANCD")) = pstrTKTANCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TAITCD")) = pstrTAITCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TFKICD")) = pstrTFKICD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TKIGCD")) = pstrTKIGCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TSADCD")) = pstrTSADCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TELRCD")) = pstrTELRCD) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("TEL_MEMO1")) = pstrTEL_MEMO1) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("USE_FLG")) = pstrUSE_FLG) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO) And _
                        (Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPNM")) = pstrGROUPNM) _
                     ) Then

                    pintMODE = 4 '�X�L�b�v
                End If
            End If

            If pintMODE = 4 Then
                '�X�L�b�v�����̃��R�[�h
                Exit Try
            End If


            '�f�[�^�̍X�V����--------------------------------

            If pintMODE = 3 Then
                '�����敪���폜
                strSQL = New StringBuilder("")
                strSQL.Append("DELETE ")
                strSQL.Append("FROM ")
                strSQL.Append("			M08_AUTOTAIOU ")
                strSQL.Append("WHERE ")
                strSQL.Append("			GROUPCD =:GROUPCD ")    '�O���[�v�R�[�h
                strSQL.Append("AND		KMCD =:KMCD ")          '�x��R�[�h
                strSQL.Append("AND		KMNM =:KMNM ")          '�x�񖼏�

            ElseIf pintMODE = 2 Then
                '�����敪���C��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("         M08_AUTOTAIOU ")
                strSQL.Append("SET ")
                strSQL.Append("     	GROUPCD = :GROUPCD, ")
                strSQL.Append("     	KMCD = :KMCD, ")
                strSQL.Append("     	KMNM = :KMNM, ")
                strSQL.Append("     	PROCKBN = :PROCKBN, ")
                strSQL.Append("     	TAIOKBN = :TAIOKBN, ")
                strSQL.Append("     	TMSKB = :TMSKB, ")
                strSQL.Append("     	TKTANCD = :TKTANCD, ")
                strSQL.Append("     	TAITCD = :TAITCD, ")
                strSQL.Append("     	TFKICD = :TFKICD, ")
                strSQL.Append("     	TKIGCD = :TKIGCD, ")
                strSQL.Append("     	TSADCD = :TSADCD, ")
                strSQL.Append("     	TELRCD = :TELRCD, ")
                strSQL.Append("     	TEL_MEMO1 = :TEL_MEMO1, ")
                strSQL.Append("     	USE_FLG = :USE_FLG, ")
                strSQL.Append("     	INS_DATE = TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	UPD_DATE = TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("     	BIKO = :BIKO, ")
                strSQL.Append("     	GROUPNM = :GROUPNM ")   '2017/02/09 W.GANEKO 2016�Ď����P ��10
                strSQL.Append("WHERE   ")
                strSQL.Append("         GROUPCD =:GROUPCD  ")
                strSQL.Append("  AND    KMCD =:KMCD ")
                strSQL.Append("  AND    KMNM =:KMNM ")

            ElseIf pintMODE = 1 Then
                '�����敪���V�K
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append(" M08_AUTOTAIOU (")
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
                strSQL.Append("     GROUPNM ")        '2017/02/09 W.GANEKO 2016�Ď����P ��10
                strSQL.Append(") VALUES(")
                strSQL.Append("		:GROUPCD, ")
                strSQL.Append("		:KMCD, ")
                strSQL.Append("		:KMNM, ")
                strSQL.Append("		:PROCKBN, ")
                strSQL.Append("		:TAIOKBN, ")
                strSQL.Append("		:TMSKB, ")
                strSQL.Append("		:TKTANCD, ")
                strSQL.Append("		:TAITCD, ")
                strSQL.Append("		:TFKICD, ")
                strSQL.Append("		:TKIGCD, ")
                strSQL.Append("		:TSADCD, ")
                strSQL.Append("		:TELRCD, ")
                strSQL.Append("		:TEL_MEMO1, ")
                strSQL.Append("		:USE_FLG, ")
                strSQL.Append("		TO_DATE(:INS_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		TO_DATE(:UPD_DATE, 'YYYY/MM/DD HH24:MI:SS'), ")
                strSQL.Append("		:BIKO, ")
                strSQL.Append("		:GROUPNM ")     '2017/02/09 W.GANEKO 2016�Ď����P ��10
                strSQL.Append(")")
            End If

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            If pintMODE = 3 Then
                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                cdb.pSQLParamStr("KMCD") = pstrKMCD
                cdb.pSQLParamStr("KMNM") = pstrKMNM
            ElseIf pintMODE = 1 Or pintMODE = 2 Then

                cdb.pSQLParamStr("GROUPCD") = pstrGROUPCD
                cdb.pSQLParamStr("KMCD") = pstrKMCD
                cdb.pSQLParamStr("KMNM") = pstrKMNM
                cdb.pSQLParamStr("PROCKBN") = pstrPROCKBN
                cdb.pSQLParamStr("TAIOKBN") = pstrTAIOKBN
                cdb.pSQLParamStr("TMSKB") = pstrTMSKB
                cdb.pSQLParamStr("TKTANCD") = pstrTKTANCD
                cdb.pSQLParamStr("TAITCD") = pstrTAITCD
                cdb.pSQLParamStr("TFKICD") = pstrTFKICD
                cdb.pSQLParamStr("TKIGCD") = pstrTKIGCD
                cdb.pSQLParamStr("TSADCD") = pstrTSADCD
                cdb.pSQLParamStr("TELRCD") = pstrTELRCD
                cdb.pSQLParamStr("TEL_MEMO1") = pstrTEL_MEMO1
                cdb.pSQLParamStr("GROUPNM") = pstrGROUPNM       '2017/02/09 W.GANEKO 2016�Ď����P ��10

                If pstrUSE_FLG = "" Then
                    cdb.pSQLParamStr("USE_FLG") = "1"
                Else
                    cdb.pSQLParamStr("USE_FLG") = pstrUSE_FLG
                End If
                cdb.pSQLParamStr("BIKO") = pstrBIKO

                If pintMODE = 1 Then
                    '�V�K�o�^�̏ꍇ
                    cdb.pSQLParamStr("INS_DATE") = Now.ToString()
                    cdb.pSQLParamStr("UPD_DATE") = ""
                Else
                    '�C���o�^�̏ꍇ
                    cdb.pSQLParamStr("INS_DATE") = pstrINS_DATE
                    cdb.pSQLParamStr("UPD_DATE") = Now.ToString()
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
                                        ByVal pstrGROUPCD As String _
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
            strSQL.Append("SELECT ")
            strSQL.Append("      A.GROUPCD ")
            strSQL.Append("     ,A.KMCD ")
            strSQL.Append("     ,A.KMNM ")
            strSQL.Append("     ,A.PROCKBN ")
            strSQL.Append("     ,A.TAIOKBN ")
            strSQL.Append("     ,A.TMSKB ")
            strSQL.Append("     ,A.TKTANCD ")
            strSQL.Append("     ,A.TAITCD ")
            strSQL.Append("     ,A.TFKICD ")
            strSQL.Append("     ,A.TKIGCD ")
            strSQL.Append("     ,A.TSADCD ")
            strSQL.Append("     ,A.TELRCD ")
            strSQL.Append("     ,A.TEL_MEMO1 ")
            strSQL.Append("     ,A.USE_FLG ")
            strSQL.Append("     ,A.BIKO ")
            strSQL.Append("     ,A.INS_DATE ")
            strSQL.Append("     ,A.UPD_DATE ")
            strSQL.Append("     ,A.GROUPNM ")       '2017/02/09 W.GANEKO 2016�Ď����P ��10
            strSQL.Append("FROM M08_AUTOTAIOU A ")
            strSQL.Append("WHERE	A.GROUPCD = :GROUPCD ")
            strSQL.Append("ORDER BY A.KMCD ")
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            '�o����ЃR�[�h
            If pstrGROUPCD.Length > 0 Then
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
            CSVC.pRepoID = "MSJINJAW00"       '���[ID
            CSVC.mOpen()
            Dim iCnt As Integer
            Dim irCnt As Integer
            For iCnt = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(iCnt)

                If iCnt = 0 Then
                    CSVC.pColValStrEx = "�O���[�v�R�[�h"
                    CSVC.pColValStrEx = "�x��R�[�h"
                    CSVC.pColValStrEx = "�x�񖼏�"
                    CSVC.pColValStrEx = "�Ή��^�����敪"
                    CSVC.pColValStrEx = "�Ή��敪"
                    CSVC.pColValStrEx = "�����敪"
                    CSVC.pColValStrEx = "�Ď������S���Һ���"
                    CSVC.pColValStrEx = "�A������"
                    CSVC.pColValStrEx = "���A�Ή���"
                    CSVC.pColValStrEx = "�K�X���"
                    CSVC.pColValStrEx = "�쓮����"
                    CSVC.pColValStrEx = "�d�b�A�����e"
                    CSVC.pColValStrEx = "�d�b�Ή�����"
                    CSVC.pColValStrEx = "�g�p�t���O"
                    CSVC.pColValStrEx = "���l"
                    CSVC.pColValStrEx = "�o�^����"
                    CSVC.pColValStrEx = "�X�V����"
                    CSVC.pColValStrEx = "�O���[�v�R�[�h��"  '2017/02/09 W.GANEKO 2016�Ď����P ��10
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
