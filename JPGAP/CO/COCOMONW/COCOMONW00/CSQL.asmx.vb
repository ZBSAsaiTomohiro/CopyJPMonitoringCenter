Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common

Imports System.Web.Services

<WebService(Namespace:="http://tempuri.org/")> _
Public Class CSQL
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
    '���N���A���̍s�̂���ꗗ
    <WebMethod()> Public Function mGetDataClearRow(ByVal pSQL As String, ByVal pDs As DataSet, ByVal pNoDatRec As Boolean, ByVal pClearRow As Boolean) As DataSet
        Return fncGetData(pSQL, pDs, pNoDatRec, pClearRow)
    End Function
    '���N���A���̍s�̂Ȃ��ꗗ
    <WebMethod()> Public Function mGetData(ByVal pSQL As String, ByVal pDs As DataSet, ByVal pNoDatRec As Boolean) As DataSet
        Return fncGetData(pSQL, pDs, pNoDatRec, False)
    End Function

    Protected Function fncGetData(ByRef pSQL As String, ByRef pDs As DataSet, ByRef pNoDatRec As Boolean, ByRef pClearRow As Boolean) As DataSet
        Dim ds As New DataSet

        Dim cdb As New cdb
        Dim ConstC As New CConst


        Dim strColName As String

        Dim i As Integer = 0

        '�ڑ�OPEN
        cdb.mOpen()

        'SQL���s
        cdb.pSQL = pSQL

        '�p�����[�^�̃f�[�^�Z�b�g���w�肳��Ă����
        If pDs.Tables.Count <> 0 Then

            '�p�����[�^�ɒl���Z�b�g
            For i = 0 To pDs.Tables(0).Rows.Count - 1
                '�f�[�^�Z�b�g�̂P��ڂ̓p�����[�^��
                strColName = Convert.ToString(pDs.Tables(0).Rows(i).Item(0))
                '�f�[�^�Z�b�g�̂Q��ڂ̓f�[�^�^�Ȃ̂ŁAVARCHAR2�ł����
                If Convert.ToBoolean(pDs.Tables(0).Rows(i).Item(1)) = True Then
                    '�f�[�^�Z�b�g�̂R��ڂ͕�����p�����[�^�l�Ȃ̂ŁA������̃p�����[�^�l�ɃZ�b�g����
                    cdb.pSQLParamStr(strColName) = Convert.ToString(pDs.Tables(0).Rows(i).Item(2))
                    'NUMBER�ł����
                Else
                    '�f�[�^�Z�b�g�̂S��ڂ͐��l�p�����[�^�l�Ȃ̂ŁA���l�̃p�����[�^�l�ɃZ�b�g����
                    cdb.pSQLParamDec(strColName) = Convert.ToDecimal(pDs.Tables(0).Rows(i).Item(3))
                    'VARHCAR2�ANUMBER�ȊO��
                End If
            Next
        End If

        cdb.mExecQuery()

        ds = cdb.pResult

        If ds.Tables(0).Rows.Count = 0 And pNoDatRec = True Then
            Dim dr As DataRow
            '�J�����̐����Q�ɖ����Ȃ�������
            If ds.Tables(0).Columns.Count < 2 Then
                '�f�[�^�J������ǉ�
                Dim dc As New DataColumn
                dc.DataType = System.Type.GetType("System.String")
                ds.Tables(0).Columns.Add(dc)
            End If

            dr = ds.Tables(0).NewRow()
            dr(0) = "XYZ"
            dr(1) = "�f�[�^����"
            ds.Tables(0).Rows.Add(dr)

            '���N���A���̍s���o���̂ł����
        ElseIf pClearRow = True Then
            Dim dr As DataRow
            '�J�����̐����Q�ɖ����Ȃ�������
            If ds.Tables(0).Columns.Count < 2 Then
                '�f�[�^�J������ǉ�
                Dim dc As New DataColumn
                dc.DataType = System.Type.GetType("System.String")
                ds.Tables(0).Columns.Add(dc)
            End If
            dr = ds.Tables(0).NewRow()
            dr.Item(0) = ""
            dr.Item(1) = ConstC.pPopupClearRow  '�N���A�̎��̕�����
            ds.Tables(0).Rows.InsertAt(dr, 0)

        End If

        '�ڑ��N���[�Y
        cdb.mClose()

        cdb = Nothing

        Return ds

    End Function

End Class
