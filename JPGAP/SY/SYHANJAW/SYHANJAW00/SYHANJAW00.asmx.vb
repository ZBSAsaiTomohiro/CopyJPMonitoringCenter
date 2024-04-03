'***********************************************
'�S���҃}�X�^
'***********************************************
Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Configuration
Imports System.text


<System.Web.Services.WebService(Namespace:="http://tempuri.org/SYHANJAW00/SYHANJAW00")> _
Public Class SYHANJAW00
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

    'EXE���s
    '******************************************************************************
    '*�@�T�@�v�FEXE�̎��s
    '*�@���@�l�F�p�����[�^�Ƃ���
    '*�@�@�@�@�F�P�D�Ώ۔N��
    '*�@�@�@�@�F�Q�D�W�v����FROM
    '*�@�@�@�@�F�R�D�W�v����TO
    '******************************************************************************
    'OK     : �n�j
    'else   : ���s�G���[(catch���e)
    <WebMethod()> Public Function mExec( _
                                        ByVal pstrKENCD As String, _
                                        ByVal pstrTRGDATE As String, _
                                        ByVal pstrSYUFROM As String, _
                                        ByVal pstrSYUTO As String, _
                                        ByVal pstrMOT_TRGDATE As String, _
                                        ByVal pstrMOT_SYUFROM As String _
                                        ) As String
        Dim strRec As String
        strRec = "OK"

        Dim ds As New DataSet
        Dim cdb As New cdb
        Dim strSQL As StringBuilder

        Dim strFLG As String

        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRec = ex.ToString
            Return strRec
        Finally
        End Try

        Try
            '//--------------------------------------------
            '�g�����U�N�V�����J�n
            cdb.mBeginTrans()


            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" NAME, ")                        '�Ώ۔N��
            strSQL.Append(" NAIYO1, ")                      '�W�v����FROM
            strSQL.Append(" NAIYO2 ")                       '�W�v����TO
            strSQL.Append("FROM ")
            strSQL.Append("M06_PULLDOWN ")                  '�v���_�E���}�X�^
            strSQL.Append("WHERE KBN  =:KBN  ")             '�敪
            strSQL.Append("  AND CD =:KENCD ")              '�R�[�h(���R�[�h�Ō���)
            strSQL.Append("FOR UPDATE NOWAIT ")             '�r�������������
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KBN") = "56"                  '�̔��Ǘ������
            cdb.pSQLParamStr("KENCD") = pstrKENCD
            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult
            '�o�^���ɓ���L�[�̃f�[�^�����݂��鎞
            If (ds.Tables(0).Rows.Count = 0) Then
                '���݂��Ȃ��ꍇ�͏��񏈗�����
                strFLG = "1"
            Else
                If ( _
                    (Convert.ToString(ds.Tables(0).Rows(0).Item("NAME")) <> pstrMOT_TRGDATE) Or _
                    (Convert.ToString(ds.Tables(0).Rows(0).Item("NAIYO1")) <> pstrMOT_SYUFROM) _
                   ) Then
                    Return "0"
                    ''strRec = "���̃��[�U�[�ɂ���Ċ��ɏ������s���Ă��܂��B�ēx���s���Ă�������"
                End If
                strFLG = "2"
            End If


            '//--------------------------------------------
            'EXE���N������
            '<< �p�����[�^ >>
            Dim strAregs(6) As String

            strAregs(0) = pstrKENCD
            strAregs(1) = pstrTRGDATE
            strAregs(2) = pstrSYUFROM
            strAregs(3) = pstrSYUTO
            strAregs(4) = pstrMOT_TRGDATE
            strAregs(5) = pstrMOT_SYUFROM

            Dim strAreg As String
            Dim intProc As Integer
            strAreg = Join(strAregs, ",")
            intProc = Shell(ConfigurationSettings.AppSettings("EXEPATH") & _
                            "SYHANJAE00.exe " & strAreg, _
                            AppWinStyle.Hide, False)


            '//--------------------------------------------
            '�v���_�E���}�X�^�̓������́A
            '�Ώ۔N���E�W�v����FROM�E�W�v����TO���X�V����
            strSQL = New StringBuilder("")
            If strFLG = "1" Then
                strSQL.Append("INSERT INTO M06_PULLDOWN ")
                strSQL.Append("( ")
                strSQL.Append("KBN, ")
                strSQL.Append("CD, ")
                strSQL.Append("NAME, ")
                strSQL.Append("NAIYO1, ")
                strSQL.Append("NAIYO2, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("TIME ")
                strSQL.Append(") VALUES ( ")
                strSQL.Append(":KBN, ")
                strSQL.Append(":KENCD, ")
                strSQL.Append(":TRGDATE, ")
                strSQL.Append(":SYUFROM, ")
                strSQL.Append(":SYUTO, ")
                strSQL.Append(":SDATE, ")
                strSQL.Append(":TIME ")
                strSQL.Append(") ")
            Else
                strSQL.Append("UPDATE M06_PULLDOWN SET ")
                strSQL.Append("NAME   = :TRGDATE, ")
                strSQL.Append("NAIYO1 = :SYUFROM, ")
                strSQL.Append("NAIYO2 = :SYUTO, ")
                strSQL.Append("EDT_DATE = :SDATE, ")
                strSQL.Append("TIME = :TIME ")
                strSQL.Append("WHERE KBN =:KBN ")
                strSQL.Append("  AND CD =:KENCD ")
            End If
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�o�C���h�ϐ��ɒl���Z�b�g
            cdb.pSQLParamStr("KBN") = "56"
            cdb.pSQLParamStr("KENCD") = pstrKENCD
            cdb.pSQLParamStr("TRGDATE") = pstrTRGDATE
            cdb.pSQLParamStr("SYUFROM") = pstrSYUFROM
            cdb.pSQLParamStr("SYUTO") = pstrSYUTO
            cdb.pSQLParamStr("SDATE") = Now.ToString("yyyyMMdd")
            cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")
            'SQL�����s
            cdb.mExecNonQuery()

            '�R�~�b�g
            cdb.mCommit()
        Catch ex As Exception
            '�G���[���e���i�[
            strRec = ex.ToString

            '���[���o�b�N
            cdb.mRollback()
            strRec = strRec & cdb.pErr
        Finally
            '//
        End Try

        cdb = Nothing

        Return strRec

    End Function
End Class
