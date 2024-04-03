Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB
Imports JPG.Common

Imports System.Web.Services

<WebService(Namespace:="http://tempuri.org/")> _
Public Class CSQL
    Inherits System.Web.Services.WebService

#Region " Web サービス デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        'この呼び出しは Web サービス デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に独自の初期化コードを追加してください。

    End Sub

    'Web サービス デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ : 以下のプロシージャは、Web サービス デザイナで必要です。
    'Web サービス デザイナを使って変更することができます。  
    'コード エディタによる変更は行わないでください。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: このプロシージャは Web サービス デザイナで必要です。
        'コード エディタによる変更は行わないでください。
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region
    '＜クリア＞の行のある一覧
    <WebMethod()> Public Function mGetDataClearRow(ByVal pSQL As String, ByVal pDs As DataSet, ByVal pNoDatRec As Boolean, ByVal pClearRow As Boolean) As DataSet
        Return fncGetData(pSQL, pDs, pNoDatRec, pClearRow)
    End Function
    '＜クリア＞の行のない一覧
    <WebMethod()> Public Function mGetData(ByVal pSQL As String, ByVal pDs As DataSet, ByVal pNoDatRec As Boolean) As DataSet
        Return fncGetData(pSQL, pDs, pNoDatRec, False)
    End Function

    Protected Function fncGetData(ByRef pSQL As String, ByRef pDs As DataSet, ByRef pNoDatRec As Boolean, ByRef pClearRow As Boolean) As DataSet
        Dim ds As New DataSet

        Dim cdb As New cdb
        Dim ConstC As New CConst


        Dim strColName As String

        Dim i As Integer = 0

        '接続OPEN
        cdb.mOpen()

        'SQL実行
        cdb.pSQL = pSQL

        'パラメータのデータセットが指定されていれば
        If pDs.Tables.Count <> 0 Then

            'パラメータに値をセット
            For i = 0 To pDs.Tables(0).Rows.Count - 1
                'データセットの１列目はパラメータ名
                strColName = Convert.ToString(pDs.Tables(0).Rows(i).Item(0))
                'データセットの２列目はデータ型なので、VARCHAR2であれば
                If Convert.ToBoolean(pDs.Tables(0).Rows(i).Item(1)) = True Then
                    'データセットの３列目は文字列パラメータ値なので、文字列のパラメータ値にセットする
                    cdb.pSQLParamStr(strColName) = Convert.ToString(pDs.Tables(0).Rows(i).Item(2))
                    'NUMBERであれば
                Else
                    'データセットの４列目は数値パラメータ値なので、数値のパラメータ値にセットする
                    cdb.pSQLParamDec(strColName) = Convert.ToDecimal(pDs.Tables(0).Rows(i).Item(3))
                    'VARHCAR2、NUMBER以外は
                End If
            Next
        End If

        cdb.mExecQuery()

        ds = cdb.pResult

        If ds.Tables(0).Rows.Count = 0 And pNoDatRec = True Then
            Dim dr As DataRow
            'カラムの数が２個に満たなかったら
            If ds.Tables(0).Columns.Count < 2 Then
                'データカラムを追加
                Dim dc As New DataColumn
                dc.DataType = System.Type.GetType("System.String")
                ds.Tables(0).Columns.Add(dc)
            End If

            dr = ds.Tables(0).NewRow()
            dr(0) = "XYZ"
            dr(1) = "データ無し"
            ds.Tables(0).Rows.Add(dr)

            '＜クリア＞の行を出すのであれば
        ElseIf pClearRow = True Then
            Dim dr As DataRow
            'カラムの数が２個に満たなかったら
            If ds.Tables(0).Columns.Count < 2 Then
                'データカラムを追加
                Dim dc As New DataColumn
                dc.DataType = System.Type.GetType("System.String")
                ds.Tables(0).Columns.Add(dc)
            End If
            dr = ds.Tables(0).NewRow()
            dr.Item(0) = ""
            dr.Item(1) = ConstC.pPopupClearRow  'クリアの時の文字列
            ds.Tables(0).Rows.InsertAt(dr, 0)

        End If

        '接続クローズ
        cdb.mClose()

        cdb = Nothing

        Return ds

    End Function

End Class
