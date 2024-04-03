Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Web.Services
Imports System.Text

<System.Web.Services.WebService(Namespace:="http://tempuri.org/KEKESJAW00/Service1")> _
Public Class KEKESJAW00
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

    '************************************************
    'パラメータ処理番号データのロックフラグを解除(NULL)します
    '************************************************
    <WebMethod()> Public Function mDel(ByVal pintDelCnt As Integer, ByVal pstrDelKeys As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

        strRes = "OK"

        '------------------------------------------------
        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally

        End Try

        Try
            '------------------------------------------------
            'トランザクション開始--------------------------
            cdb.mBeginTrans()

            '*********************************
            '処理ストーリー
            '[-]特になし。削除のみ
            '*********************************

            '------------------------------------------------
            'カンマ編集を配列に編集
            Dim arrDelKey As String()
            arrDelKey = fncArrayOut(pstrDelKeys, pintDelCnt)

            '------------------------------------------------
            'ＤＢ更新（ロック解除）----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("")
            strSQL.Append("DELETE FROM ")
            strSQL.Append("T11_KEIHOFILE ")                         '警報ファイルＤＢ
            strSQL.Append("WHERE FILE_NAME =:FILE_NAME ")           '警報ファイル名

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            Dim i As Integer
            For i = 0 To pintDelCnt - 1
                'パラメータセット
                cdb.pSQLParamStr("FILE_NAME") = arrDelKey(i)     '警報ファイル名
                'SQLを実行
                cdb.mExecNonQuery()
            Next

            'コミット
            cdb.mCommit()
        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString
            'ロールバック
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '接続クローズ
            cdb.mClose()
        End Try

        cdb = Nothing

        Return strRes
    End Function


    '******************************************************************************
    '*　概　要：配列として取得
    '*　備　考：Public Function
    '******************************************************************************
    Private Function fncArrayOut(ByVal pstrArrBox As String, ByVal pintArr As Integer) As String()
        Dim intLop As Integer
        Dim intIdx As Integer
        Dim strCut As String = ","
        Dim strTmp As String
        Dim arrRec() As String
        ReDim arrRec(pintArr)

        intIdx = 0
        For intLop = 1 To Len(pstrArrBox)
            If Len(pstrArrBox) = intLop Then
                If Mid(pstrArrBox, intLop, 1) <> strCut Then
                    strTmp = strTmp & Mid(pstrArrBox, intLop, 1)
                    arrRec(intIdx) = strTmp
                    strTmp = ""
                ElseIf Mid(pstrArrBox, intLop, 1) = strCut Then
                    arrRec(intIdx) = strTmp
                    strTmp = ""

                    intIdx += 1
                    arrRec(intIdx) = strTmp
                    strTmp = ""
                End If
            ElseIf Mid(pstrArrBox, intLop, 1) = strCut Then
                arrRec(intIdx) = strTmp
                intIdx += 1
                strTmp = ""
            Else
                strTmp = strTmp & Mid(pstrArrBox, intLop, 1)
            End If
        Next

        Return arrRec
    End Function
End Class
