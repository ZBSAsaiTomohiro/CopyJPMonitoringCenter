'******************************************************************************
' 一般消費者名簿取込
' PGID: SBMEIJAW00.asmx.vb
'******************************************************************************
'変更履歴
' 2018/09/20 T.Ono 監視改善2018 新規作成
' 2019/11/01 T.Ono 監視改善2019 CSV取込、複数シート取込

Option Explicit On 
Option Strict On

Imports Common
Imports Common.DB

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System.IO
Imports NPOI.SS.UserModel
Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel


<System.Web.Services.WebService(Namespace:="http://tempuri.org/SBMEIJAW00/Service1")> _
Public Class SBMEIJAW00
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
    '******************************************************************************
    '*　概　要:名簿基礎ファイル　各項目チェック
    '*　備　考:
    '******************************************************************************
    <WebMethod()> Public Function mChkkisofile(ByVal pstrFilePath As String, ByVal pstrDATAshu As String) As String

        Dim WB As IWorkbook = WorkbookFactory.Create(pstrFilePath)
        '2019/11/01 T.Ono mod 監視改善2019
        'Dim WS As ISheet = WB.GetSheetAt(0)
        'Dim iLastRow As Integer = WS.LastRowNum
        Dim strCell As String = "" 'セルの値格納'
        Dim strRes As String = "OK"

        Try
            '2019/11/01 T.Ono mod 監視改善2019 複数シートに対応
            For icountS As Integer = 0 To WB.NumberOfSheets - 1
                mlog("シート�ａF" & icountS)
                Dim WS As ISheet = WB.GetSheetAt(icountS)
                Dim iLastRow As Integer = WS.LastRowNum


                For iCountR As Integer = 1 To iLastRow
                    Dim getRow As IRow = WS.GetRow(iCountR)

                    For iCountC As Integer = 0 To 13 '14列目まで読み込む
                        Dim getCell As ICell = getRow.GetCell(iCountC)

                        'strCellにセルの値を格納
                        If getCell Is Nothing Then
                            '空白'
                            strCell = ""
                        Else
                            Dim celltype As CellType = getCell.CellType
                            Select Case celltype
                                Case CellType.String
                                    '文字列
                                    strCell = getCell.StringCellValue
                                Case CellType.Numeric
                                    '数値
                                    strCell = getCell.NumericCellValue.ToString
                                Case CellType.Blank
                                    'ブランク
                                    strCell = ""
                                Case Else
                                    strCell = ""
                            End Select
                        End If


                        '各項目の入力チェック
                        Select Case iCountC
                            Case 0 'クライアントコード'
                                '必須チェック
                                If strCell.Trim = "" OrElse strCell = "　" Then
                                    'Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                                    Return "KEY項目が空欄です " & "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目"
                                End If
                                '桁数チェック
                                If LenB(strCell) > 10 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 1 'JA支所コード'
                                '必須チェック
                                If strCell.Trim = "" OrElse strCell = "　" Then
                                    'Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                                    Return "KEY項目が空欄です " & "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目"
                                End If
                                '桁数チェック
                                If LenB(strCell) > 10 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 2 'お客様コード'
                                '必須チェック
                                If strCell.Trim = "" OrElse strCell = "　" Then
                                    'Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                                    Return "KEY項目が空欄です " & "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目"
                                End If
                                '桁数チェック
                                If LenB(strCell) > 20 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 3 'お客様氏名'
                                '桁数チェック
                                If LenB(strCell) > 30 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 4 '法人代表者氏名'
                                '桁数チェック
                                If LenB(strCell) > 30 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 5 '住所１'
                                '桁数チェック
                                If LenB(strCell) > 60 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 6 '住所２'
                                '桁数チェック
                                If LenB(strCell) > 30 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 7 '住所３'
                                '桁数チェック
                                If LenB(strCell) > 30 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 8 '電話番号'
                                '桁数チェック
                                If LenB(strCell) > 20 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 9 '結線区分'
                                '桁数チェック
                                If LenB(strCell) > 6 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 10 '供給形態区分'
                                '桁数チェック
                                If LenB(strCell) > 1 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 11 '適用法令区分'
                                '桁数チェック
                                If LenB(strCell) > 1 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 12 '用途区分'
                                '桁数チェック
                                If LenB(strCell) > 1 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 13 '分類コード'
                                '桁数チェック
                                If LenB(strCell) > 1 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート��:" & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                        End Select
                    Next
                Next
            Next

            Return strRes

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返す
            Return "ERROR:mChkkisofile:" & ex.ToString
        End Try


    End Function
    '******************************************************************************
    '*　概　要:名簿基礎ファイル(CSV)　各項目チェック
    '*　備　考:2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    <WebMethod()> Public Function mChkkisofileCSV(ByVal pstrFilePath As String, ByVal pstrDATAshu As String) As String

        Dim parser As New FileIO.TextFieldParser(pstrFilePath, Encoding.GetEncoding("shift_jis"))
        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",")
        parser.TrimWhiteSpace = True

        Dim strCell As String = "" 'セルの値格納
        Dim strRes As String = "OK"
        Dim iCountR As Integer = 0

        '項目
        Dim strNENDO As String = ""
        Dim strKURACD As String = ""
        Dim strKENCD As String = ""
        Dim strACBCD As String = ""
        Dim strUSER_CD As String = ""
        Dim strJUSYONM As String = ""
        Dim strADDR1 As String = ""
        Dim strADDR2 As String = ""
        Dim strADDR3 As String = ""
        Dim strADDR As String = ""
        Dim strRENTEL As String = ""
        Dim strSYUTUTEL As String = ""
        Dim strKESSEN As String = ""
        Dim strDAIHYO_NAME As String = ""
        Dim strKYOKTKBN As String = ""
        Dim strHOKBN As String = ""
        Dim strYOTOKBN As String = ""
        Dim strBUNRUICD As String = ""
        Dim strHANJICD As String = ""
        Dim strHANJINM As String = ""
        Dim strHANTENCD As String = ""
        Dim strHANTENNM As String = ""
        Dim strSAKUNEN_FLG As String = ""
        Dim strLTOS_FLG As String = ""
        Dim strINS_DATE As String = ""
        Dim strINS_USER As String = ""
        Dim strKISO_UPD_DATE As String = ""
        Dim strKISO_UPD_USER As String = ""
        Dim strLTOS_UPD_DATE As String = ""
        Dim strLTOS_UPD_USER As String = ""

        '★★★
        mlog("mChkkisofileCSV：スタート：" & Now.ToString("yyyyMMddHHmmss"))

        Try
            While Not parser.EndOfData
                Dim record As String()
                record = parser.ReadFields()

                If iCountR > 0 Then 'ヘッダは飛ばす
                    'クライアントコード'
                    strKURACD = record(0)
                    '必須チェック
                    If strKURACD.Trim = "" OrElse strKURACD = "　" Then
                        Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                    End If
                    '桁数チェック
                    If LenB(strKURACD) > 10 Then
                        mlog(strKURACD)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    'JA支所コード'
                    strACBCD = record(1)
                    '必須チェック
                    If strACBCD.Trim = "" OrElse strACBCD = "　" Then
                        Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                    End If
                    '桁数チェック
                    If LenB(strACBCD) > 10 Then
                        mlog(strACBCD)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    'お客様コード'
                    strUSER_CD = record(2)
                    '必須チェック
                    If strUSER_CD.Trim = "" OrElse strUSER_CD = "　" Then
                        Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                    End If
                    '桁数チェック
                    If LenB(strUSER_CD) > 20 Then
                        mlog(strUSER_CD)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    'お客様氏名'
                    strJUSYONM = record(3)
                    '桁数チェック
                    If LenB(strJUSYONM) > 30 Then
                        mlog(strJUSYONM)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '法人代表者氏名'
                    strDAIHYO_NAME = record(4)
                    '桁数チェック
                    If LenB(strDAIHYO_NAME) > 30 Then
                        mlog(strDAIHYO_NAME)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '住所１'
                    strADDR1 = record(5)
                    '桁数チェック
                    If LenB(strADDR1) > 60 Then
                        mlog(strADDR1)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '住所２'
                    strADDR2 = record(6)
                    '桁数チェック
                    If LenB(strADDR2) > 30 Then
                        mlog(strADDR2)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '住所３'
                    strADDR3 = record(7)
                    '桁数チェック
                    If LenB(strADDR3) > 30 Then
                        mlog(strADDR3)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '電話番号'
                    strRENTEL = record(8)
                    '桁数チェック
                    If LenB(strRENTEL) > 20 Then
                        mlog(strRENTEL)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '結線区分'
                    strKESSEN = record(9)
                    '桁数チェック
                    If LenB(strKESSEN) > 6 Then
                        mlog(strKESSEN)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '供給形態区分'
                    strKYOKTKBN = record(11)
                    '桁数チェック
                    If LenB(strKYOKTKBN) > 1 Then
                        mlog(strKYOKTKBN)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '適用法令区分'
                    strHOKBN = record(12)
                    '桁数チェック
                    If LenB(strHOKBN) > 1 Then
                        mlog(strHOKBN)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '用途区分'
                    strYOTOKBN = record(13)
                    '桁数チェック
                    If LenB(strYOTOKBN) > 1 Then
                        mlog(strYOTOKBN)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    ''分類コード'
                    'strBUNRUICD = record(13)
                    ''桁数チェック
                    'If LenB(strBUNRUICD) > 1 Then
                    '    mlog(strBUNRUICD)
                    '    Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    'End If
                End If

                iCountR += 1

            End While

            mlog("mChkkisofileCSV：エンド　：" & Now.ToString("yyyyMMddHHmmss"))
            Return strRes

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:mChkkisofileCSV:" & ex.ToString
        End Try
    End Function

    '******************************************************************************
    '*　概　要:LTOSファイル　各項目チェック
    '*　備　考:
    '******************************************************************************
    <WebMethod()> Public Function mChkLTOSfile(ByVal pstrFilePath As String, ByVal pstrDATAshu As String) As String

        Dim WB As IWorkbook = WorkbookFactory.Create(pstrFilePath)
        '2019/11/01 T.Ono mod 監視改善2019
        'Dim WS As ISheet = WB.GetSheetAt(0)
        'Dim iLastRow As Integer = WS.LastRowNum
        Dim strCell As String = "" 'セルの値格納'
        Dim strRes As String = "OK"

        Try
            '2019/11/01 T.Ono mod 監視改善2019 複数シートに対応
            For icountS As Integer = 0 To WB.NumberOfSheets - 1
                mlog("シート�ａF" & icountS)
                Dim WS As ISheet = WB.GetSheetAt(icountS)
                Dim iLastRow As Integer = WS.LastRowNum

                For iCountR As Integer = 2 To iLastRow
                    Dim getRow As IRow = WS.GetRow(iCountR)

                    For iCountC As Integer = 0 To 8
                        Dim getCell As ICell = getRow.GetCell(iCountC)

                        'strCellにセルの値を格納
                        If getCell Is Nothing Then
                            '空白  これでは空白チェックができていないが念のため残しておく。下のcelltype.blankが空白チェック'
                            strCell = ""
                        End If

                        Dim celltype As CellType = getCell.CellType
                        Select Case celltype
                            Case CellType.String
                                '文字列
                                strCell = getCell.StringCellValue
                            Case CellType.Numeric
                                '数値
                                strCell = getCell.NumericCellValue.ToString
                            Case CellType.Blank
                                'ブランク
                                strCell = ""
                            Case Else
                                strCell = ""
                        End Select


                        '各項目の入力チェック
                        Select Case iCountC
                            Case 0 '県コード'
                                '必須チェック
                                If strCell.Trim = "" OrElse strCell = "　" Then
                                    'Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                                    Return "KEY項目が空欄です " & "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目"
                                End If
                                '桁数チェック
                                If LenB(strCell) > 10 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 1 '卸コード'


                            Case 2 'JAコード'
                                '必須チェック
                                If strCell.Trim = "" OrElse strCell = "　" Then
                                    'Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                                    Return "KEY項目が空欄です " & "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目"
                                End If
                                '桁数チェック
                                If LenB(strCell) > 5 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return CStr(iCountR + 1) & "シート " & icountS + 1 & " " & "行目 文字数オーバー"
                                End If

                            Case 3 '支所コード'
                                '必須チェック
                                If strCell.Trim = "" OrElse strCell = "　" Then
                                    'Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                                    Return "KEY項目が空欄です " & "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目"
                                End If
                                '桁数チェック
                                If LenB(strCell) > 5 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 4 '利用者コード'
                                '必須チェック
                                If strCell.Trim = "" OrElse strCell = "　" Then
                                    'Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                                    Return "KEY項目が空欄です " & "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目"
                                End If
                                '桁数チェック
                                If LenB(strCell) > 20 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 5 '法人代表者氏名'
                                '桁数チェック
                                If LenB(strCell) > 30 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 6 '供給形態区分'
                                '桁数チェック
                                If LenB(strCell) > 1 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 7 '適用法令区分'
                                '桁数チェック
                                If LenB(strCell) > 1 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                            Case 8 '用途区分'
                                '桁数チェック
                                If LenB(strCell) > 1 Then
                                    mlog(strCell)
                                    'Return CStr(iCountR + 1) & "行目 文字数オーバー"
                                    Return "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目 文字数オーバー"
                                End If

                        End Select
                    Next
                Next
            Next

            Return strRes

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:mChkLTOSfile:" & ex.ToString
        End Try


    End Function
    '******************************************************************************
    '*　概　要:LTOSファイル(CSV)　各項目チェック
    '*　備　考:2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    <WebMethod()> Public Function mChkLTOSfileCSV(ByVal pstrFilePath As String, ByVal pstrDATAshu As String) As String

        Dim parser As New FileIO.TextFieldParser(pstrFilePath, Encoding.GetEncoding("shift_jis"))
        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",")
        parser.TrimWhiteSpace = True

        Dim strCell As String = "" 'セルの値格納
        Dim strRes As String = "OK"
        Dim iCountR As Integer = 0

        '項目
        Dim strNENDO As String = ""
        Dim strKENCD As String = ""
        Dim strJACD As String = ""         'JAコード
        Dim strJASCD As String = ""        '支所コード
        Dim strACBCD As String = ""        'JA支所コード（JAコード+支所コード）
        Dim strUSER_CD As String = ""
        Dim strDAIHYO_NAME As String = ""
        Dim strKYOKTKBN As String = ""
        Dim strHOKBN As String = ""
        Dim strYOTOKBN As String = ""

        mlog("mChkLTOSfileCSV：スタート：" & Now.ToString("yyyyMMddHHmmss"))
        Try
            While Not parser.EndOfData
                Dim record As String()
                record = parser.ReadFields()

                mlog(record(0))
                If iCountR > 1 Then 'ヘッダは飛ばす
                    '県コード'
                    mlog("0")
                    strKENCD = record(0)
                    '必須チェック
                    If strKENCD.Trim = "" OrElse strKENCD = "　" Then
                        Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                    End If
                    '桁数チェック
                    If LenB(strKENCD) > 10 Then
                        mlog(strKENCD)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '卸コード


                    'ＪＡコード'
                    mlog("2")
                    strJACD = record(2)
                    '必須チェック
                    If strJACD.Trim = "" OrElse strJACD = "　" Then
                        Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                    End If
                    '桁数チェック
                    If LenB(strJACD) > 5 Then
                        mlog(strJACD)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '支所コード'
                    mlog("3")
                    strJASCD = record(3)
                    '必須チェック
                    If strJASCD.Trim = "" OrElse strJASCD = "　" Then
                        Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                    End If
                    '桁数チェック
                    If LenB(strJASCD) > 5 Then
                        mlog(strJASCD)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '利用者コード'
                    strUSER_CD = record(4)
                    '必須チェック
                    If strUSER_CD.Trim = "" OrElse strUSER_CD = "　" Then
                        Return "KEY項目が空欄です " & CStr(iCountR + 1) & "行目"
                    End If
                    '桁数チェック
                    If LenB(strUSER_CD) > 20 Then
                        mlog(strUSER_CD)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '法人代表者氏名'
                    strDAIHYO_NAME = record(5)
                    '桁数チェック
                    If LenB(strDAIHYO_NAME) > 30 Then
                        mlog(strDAIHYO_NAME)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '供給形態区分'
                    strKYOKTKBN = record(6)
                    '桁数チェック
                    If LenB(strKYOKTKBN) > 1 Then
                        mlog(strKYOKTKBN)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '適用法令区分'
                    strHOKBN = record(7)
                    '桁数チェック
                    If LenB(strHOKBN) > 1 Then
                        mlog(strHOKBN)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If

                    '用途区分'
                    mlog("8")
                    strYOTOKBN = record(8)
                    '桁数チェック
                    If LenB(strYOTOKBN) > 1 Then
                        mlog(strYOTOKBN)
                        Return CStr(iCountR + 1) & "行目 文字数オーバー"
                    End If
                End If

                iCountR += 1

            End While

            mlog("mChkLTOSfileCSV：エンド　：" & Now.ToString("yyyyMMddHHmmss"))
            Return strRes

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:mChkLTOSfileCSV:" & ex.ToString
        End Try

    End Function

    '******************************************************************************
    '*　概　要:名簿基礎ファイル読み込み
    '*　備　考:
    '******************************************************************************
    <WebMethod()> Public Function mReadkisofile(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String) As String

        Dim WB As IWorkbook = WorkbookFactory.Create(pstrFilePath)
        '2019/11/01 T.Ono mod 監視改善2019
        'Dim WS As ISheet = WB.GetSheetAt(0)
        'Dim iLastRow As Integer = WS.LastRowNum
        Dim strCell As String = "" 'セルの値格納
        Dim strRes As String = "OK"

        '項目
        Dim strNENDO As String = ""
        Dim strKURACD As String = ""
        Dim strKENCD As String = ""
        Dim strACBCD As String = ""
        Dim strUSER_CD As String = ""
        Dim strJUSYONM As String = ""
        Dim strADDR1 As String = ""
        Dim strADDR2 As String = ""
        Dim strADDR3 As String = ""
        Dim strADDR As String = ""
        Dim strRENTEL As String = ""
        Dim strSYUTUTEL As String = ""
        Dim strKESSEN As String = ""
        Dim strDAIHYO_NAME As String = ""
        Dim strKYOKTKBN As String = ""
        Dim strHOKBN As String = ""
        Dim strYOTOKBN As String = ""
        Dim strBUNRUICD As String = ""
        Dim strHANJICD As String = ""
        Dim strHANJINM As String = ""
        Dim strHANTENCD As String = ""
        Dim strHANTENNM As String = ""
        Dim strSAKUNEN_FLG As String = ""
        Dim strLTOS_FLG As String = ""
        Dim strINS_DATE As String = ""
        Dim strINS_USER As String = ""
        Dim strKISO_UPD_DATE As String = ""
        Dim strKISO_UPD_USER As String = ""
        Dim strLTOS_UPD_DATE As String = ""
        Dim strLTOS_UPD_USER As String = ""

        '★★★
        mlog("mReadkisofile：スタート：" & Now.ToString("yyyyMMddHHmmss"))

        Try
            '2019/11/01 T.Ono mod 監視改善2019 複数シートに対応
            For icountS As Integer = 0 To WB.NumberOfSheets - 1
                mlog("シート�ａF" & icountS)
                Dim WS As ISheet = WB.GetSheetAt(icountS)
                Dim iLastRow As Integer = WS.LastRowNum


                For iCountR As Integer = 1 To iLastRow
                    Dim getRow As IRow = WS.GetRow(iCountR)

                    '１行読み込み
                    For iCountC As Integer = 0 To 13
                        Dim getCell As ICell = getRow.GetCell(iCountC)

                        'strCellにセルの値を格納
                        If getCell Is Nothing Then
                            '空白'
                            strCell = ""
                        Else
                            Dim celltype As CellType = getCell.CellType
                            Select Case celltype
                                Case CellType.String
                                    '文字列
                                    strCell = getCell.StringCellValue
                                Case CellType.Numeric
                                    '数値
                                    strCell = getCell.NumericCellValue.ToString
                                Case CellType.Blank
                                    'ブランク
                                    strCell = ""
                            End Select
                        End If


                        '各項目の入力チェック
                        Select Case iCountC
                            Case 0 'クライアントコード'
                                strKURACD = strCell

                            Case 1 'JA支所コード'
                                strACBCD = strCell

                            Case 2 'お客様コード'
                                strUSER_CD = strCell

                            Case 3 'お客様氏名'
                                strJUSYONM = strCell

                            Case 4 '法人代表者氏名'
                                strDAIHYO_NAME = strCell

                            Case 5 '住所１'
                                strADDR1 = strCell

                            Case 6 '住所２'
                                strADDR2 = strCell

                            Case 7 '住所３'
                                strADDR3 = strCell

                            Case 8 '電話番号'
                                strRENTEL = strCell

                            Case 9 '結線区分'
                                strKESSEN = strCell

                            Case 10 '供給形態区分'
                                strKYOKTKBN = strCell

                            Case 11 '適用法令区分'
                                strHOKBN = strCell

                            Case 12 '用途区分'
                                strYOTOKBN = strCell

                            Case 13 '分類コード'
                                strBUNRUICD = strCell

                        End Select
                    Next


                    'DB更新処理
                    strRes = FncDBprocesskiso(
                                        pstrNendo.Trim,
                                        strKURACD.Trim,
                                        strACBCD.Trim,
                                        strUSER_CD.Trim,
                                        strJUSYONM.Trim,
                                        strDAIHYO_NAME.Trim,
                                        strADDR1.Trim,
                                        strADDR2.Trim,
                                        strADDR3.Trim,
                                        strRENTEL.Trim,
                                        strKESSEN.Trim,
                                        strKYOKTKBN.Trim,
                                        strHOKBN.Trim,
                                        strYOTOKBN.Trim,
                                        strBUNRUICD.Trim,
                                        pstrUser
                                        )

                    If strRes <> "OK" Then
                        '2019/11/01 T.Ono mod 監視改善2019
                        'mlog("ERROR：" & CStr(iCountR + 1) & "行目:" & strRes)
                        'Return "ERROR：" & CStr(iCountR + 1) & "行目\n" & strRes
                        mlog("ERROR：" & "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目:" & strRes)
                        Return "ERROR：" & "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目\n" & strRes
                    End If
                Next
            Next

            mlog("mReadkisofile：エンド　：" & Now.ToString("yyyyMMddHHmmss"))
            Return strRes

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:mReadkisofile:" & ex.ToString
        End Try


    End Function
    '******************************************************************************
    '*　概　要:名簿基礎ファイル読み込み(CSV)
    '*　備　考:2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    <WebMethod()> Public Function mReadkisofileCSV(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String) As String

        Dim parser As New FileIO.TextFieldParser(pstrFilePath, Encoding.GetEncoding("shift_jis"))
        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",")
        parser.TrimWhiteSpace = True

        Dim strCell As String = "" 'セルの値格納
        Dim strRes As String = "OK"
        Dim iCountR As Integer = 0

        '項目
        Dim strNENDO As String = ""
        Dim strKURACD As String = ""
        Dim strKENCD As String = ""
        Dim strACBCD As String = ""
        Dim strUSER_CD As String = ""
        Dim strJUSYONM As String = ""
        Dim strADDR1 As String = ""
        Dim strADDR2 As String = ""
        Dim strADDR3 As String = ""
        Dim strADDR As String = ""
        Dim strRENTEL As String = ""
        Dim strSYUTUTEL As String = ""
        Dim strKESSEN As String = ""
        Dim strDAIHYO_NAME As String = ""
        Dim strKYOKTKBN As String = ""
        Dim strHOKBN As String = ""
        Dim strYOTOKBN As String = ""
        Dim strBUNRUICD As String = ""
        Dim strHANJICD As String = ""
        Dim strHANJINM As String = ""
        Dim strHANTENCD As String = ""
        Dim strHANTENNM As String = ""
        Dim strSAKUNEN_FLG As String = ""
        Dim strLTOS_FLG As String = ""
        Dim strINS_DATE As String = ""
        Dim strINS_USER As String = ""
        Dim strKISO_UPD_DATE As String = ""
        Dim strKISO_UPD_USER As String = ""
        Dim strLTOS_UPD_DATE As String = ""
        Dim strLTOS_UPD_USER As String = ""

        '★★★
        mlog("mReadkisofileCSV：スタート：" & Now.ToString("yyyyMMddHHmmss"))

        Try
            While Not parser.EndOfData
                Dim record As String()
                record = parser.ReadFields()

                If iCountR > 0 Then 'ヘッダは飛ばす
                    'クライアントコード'
                    strKURACD = record(0)

                    'JA支所コード'
                    strACBCD = record(1)

                    'お客様コード'
                    strUSER_CD = record(2)

                    'お客様氏名'
                    strJUSYONM = record(3)

                    '法人代表者氏名'
                    strDAIHYO_NAME = record(4)

                    '住所１'
                    strADDR1 = record(5)

                    '住所２'
                    strADDR2 = record(6)

                    '住所３'
                    strADDR3 = record(7)

                    '電話番号'
                    strRENTEL = record(8)

                    '結線区分'
                    strKESSEN = record(9)

                    '販売区分'
                    '不要

                    '供給形態区分'
                    strKYOKTKBN = record(11)

                    '適用法令区分'
                    strHOKBN = record(12)

                    '用途区分'
                    strYOTOKBN = record(13)

                    '分類コード'
                    '項目なし
                    strBUNRUICD = ""


                    'DB更新処理
                    strRes = FncDBprocesskiso(
                                            pstrNendo.Trim,
                                            strKURACD.Trim,
                                            strACBCD.Trim,
                                            strUSER_CD.Trim,
                                            strJUSYONM.Trim,
                                            strDAIHYO_NAME.Trim,
                                            strADDR1.Trim,
                                            strADDR2.Trim,
                                            strADDR3.Trim,
                                            strRENTEL.Trim,
                                            strKESSEN.Trim,
                                            strKYOKTKBN.Trim,
                                            strHOKBN.Trim,
                                            strYOTOKBN.Trim,
                                            strBUNRUICD.Trim,
                                            pstrUser
                                            )

                    If strRes <> "OK" Then
                        mlog("ERROR：" & CStr(iCountR + 1) & "行目:" & strRes)
                        Return "ERROR：" & CStr(iCountR + 1) & "行目\n" & strRes
                    End If

                End If

                iCountR += 1

            End While


            mlog("mReadkisofileCSV：エンド　：" & Now.ToString("yyyyMMddHHmmss"))
            Return strRes

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:mReadkisofile:" & ex.ToString
        End Try


    End Function

    '******************************************************************************
    '*　概　要:データベース更新処理（名簿基礎ファイル）
    '*　備　考:
    '******************************************************************************
    Private Function FncDBprocesskiso(
                                        ByVal pstrNENDO As String,
                                        ByVal pstrKURACD As String,
                                        ByVal pstrACBCD As String,
                                        ByVal pstrUSER_CD As String,
                                        ByVal pstrJUSYONM As String,
                                        ByVal pstrDAIHYO_NAME As String,
                                        ByVal pstrADDR1 As String,
                                        ByVal pstrADDR2 As String,
                                        ByVal pstrADDR3 As String,
                                        ByVal pstrRENTEL As String,
                                        ByVal pstrKESSEN As String,
                                        ByVal pstrKYOKTKBN As String,
                                        ByVal pstrHOKBN As String,
                                        ByVal pstrYOTOKBN As String,
                                        ByVal pstrBUNRUICD As String,
                                        ByVal pstrUSER As String
                                        ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim intMODE As Integer

        '値格納
        Dim strBUNRUICD_DB As String        'DBから取得した分類コード
        Dim strSYUTUTEL_DB As String        'DBから取得した電話番号（D30から取得）
        Dim strRENTEL_DB As String = ""     'DBから取得した電話番号（M11から取得）
        Dim strHANJIGYOSYACD_DB As String   'DBから取得した販売事業者コード
        Dim strHANJIGYOSYANM_DB As String   'DBから取得した販売事業者名
        Dim strHANBAITENCD_DB As String     'DBから取得した販売店コード
        Dim strHANBAITENNM_DB As String     'DBから取得した販売店名称
        Dim strDAIHYO_NAME_OLD As String = "" '昨年度法人代表者氏名
        Dim strBUNRUICD_OLD As String = ""  '昨年度法人代表者氏名
        Dim strSAKUNEN_FLG As String = ""   '昨年度データが存在するか。存在する="1" 存在しない=""

        strRes = "OK"

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            'トランザクション開始--------------------------
            cdb.mBeginTrans()


            '新規か更新か
            'テーブルを検索
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("    A.NENDO ")
            strSQL.Append("    ,A.KURACD ")
            strSQL.Append("    ,A.KENCD ")
            strSQL.Append("    ,A.ACBCD ")
            strSQL.Append("    ,A.USER_CD ")
            strSQL.Append("    ,A.JUSYONM ")
            strSQL.Append("    ,A.ADDR1 ")
            strSQL.Append("    ,A.ADDR2 ")
            strSQL.Append("    ,A.ADDR3 ")
            strSQL.Append("    ,A.ADDR ")
            strSQL.Append("    ,A.RENTEL ")
            strSQL.Append("    ,A.SYUTUTEL ")
            strSQL.Append("    ,A.KESSEN ")
            strSQL.Append("    ,A.DAIHYO_NAME ")
            strSQL.Append("    ,A.KYOKTKBN ")
            strSQL.Append("    ,A.HOKBN ")
            strSQL.Append("    ,A.YOTOKBN ")
            strSQL.Append("    ,A.BUNRUICD ")
            strSQL.Append("    ,A.HANJICD ")
            strSQL.Append("    ,A.HANJINM ")
            strSQL.Append("    ,A.HANTENCD ")
            strSQL.Append("    ,A.HANTENNM ")
            strSQL.Append("    ,A.SAKUNEN_FLG ")
            strSQL.Append("    ,A.LTOS_FLG ")
            strSQL.Append("    ,A.INS_DATE ")
            strSQL.Append("    ,A.INS_USER ")
            strSQL.Append("    ,A.KISO_UPD_DATE ")
            strSQL.Append("    ,A.KISO_UPD_USER ")
            strSQL.Append("    ,A.LTOS_UPD_DATE ")
            strSQL.Append("    ,A.LTOS_UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("    D30_MEIBO A ")
            strSQL.Append("WHERE ")
            strSQL.Append("    A.NENDO = :NENDO ")
            strSQL.Append("AND A.KURACD = :KURACD ")
            strSQL.Append("AND A.ACBCD = :ACBCD ")
            strSQL.Append("AND A.USER_CD = :USER_CD ")

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("NENDO") = pstrNENDO
            cdb.pSQLParamStr("KURACD") = pstrKURACD
            cdb.pSQLParamStr("ACBCD") = pstrACBCD
            cdb.pSQLParamStr("USER_CD") = pstrUSER_CD

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' モードの決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                '更新
                intMODE = 2
                'データがある場合は更新に使うデータを格納
                strSYUTUTEL_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("SYUTUTEL"))
                strBUNRUICD_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("BUNRUICD"))
            Else
                '新規登録
                intMODE = 1
                strSYUTUTEL_DB = ""
                strBUNRUICD_DB = ""
            End If


            'マスタデータ参照
            'M12_HANBAITENから、販売店コード、販売店名称を取得
            strSQL = New StringBuilder("")
            strSQL.Append("WITH X AS ")
            strSQL.Append("( ")
            strSQL.Append("    SELECT A.KURACD ")
            strSQL.Append("           ,A.ACBCD ")
            strSQL.Append("           ,B.GROUPCD ")
            strSQL.Append("           ,B.HANBAITENNM ")
            strSQL.Append("    FROM   M09_JAGROUP A ")
            strSQL.Append("           ,M12_HANBAITEN B ")
            strSQL.Append("    WHERE  A.KURACD = :KURACD ")
            strSQL.Append("    AND   A.ACBCD = :ACBCD ")
            strSQL.Append("    AND   A.USERCD_FROM IS NULL ")
            strSQL.Append("    AND   A.USERCD_TO IS NULL ")
            strSQL.Append("    AND   A.KBN = '004' ")
            strSQL.Append("    AND   A.GROUPCD = B.GROUPCD ")
            strSQL.Append("), ")
            strSQL.Append("Y AS ")
            strSQL.Append("( ")
            strSQL.Append("    SELECT A.KURACD ")
            strSQL.Append("           ,A.ACBCD ")
            strSQL.Append("           ,B.GROUPCD ")
            strSQL.Append("           ,B.HANBAITENNM ")
            strSQL.Append("    FROM   M09_JAGROUP A ")
            strSQL.Append("           ,M12_HANBAITEN B ")
            strSQL.Append("    WHERE  A.KURACD = :KURACD ")
            strSQL.Append("    AND   A.ACBCD = :ACBCD ")
            strSQL.Append("    AND   :USER_CD BETWEEN A.USERCD_FROM AND A.USERCD_TO  ")
            strSQL.Append("    AND   A.KBN = '004' ")
            strSQL.Append("    AND   A.GROUPCD = B.GROUPCD ")
            strSQL.Append("), ")
            strSQL.Append("Z AS  ")
            strSQL.Append("( ")
            strSQL.Append("    SELECT A.KURACD ")
            strSQL.Append("           ,A.ACBCD ")
            strSQL.Append("           ,B.GROUPCD ")
            strSQL.Append("           ,B.HANBAITENNM ")
            strSQL.Append("    FROM   M09_JAGROUP A ")
            strSQL.Append("           ,M12_HANBAITEN B ")
            strSQL.Append("    WHERE  A.KURACD = :KURACD ")
            strSQL.Append("    AND   A.ACBCD = :ACBCD ")
            strSQL.Append("    AND   A.USERCD_FROM = :USER_CD ")
            strSQL.Append("    AND   A.USERCD_TO IS NULL ")
            strSQL.Append("    AND   A.KBN = '004' ")
            strSQL.Append("    AND   A.GROUPCD = B.GROUPCD ")
            strSQL.Append("), ")
            strSQL.Append("DUMMY AS ")
            strSQL.Append("( ")
            strSQL.Append("SELECT :KURACD AS KURACD ")
            strSQL.Append("       ,:ACBCD AS ACBCD ")
            strSQL.Append("FROM   DUAL ")
            strSQL.Append(") ")
            strSQL.Append("SELECT NVL(Z.GROUPCD, NVL(Y.GROUPCD, NVL(X.GROUPCD, ''))) AS GROUPCD ")
            strSQL.Append("       ,NVL2(Z.GROUPCD, Z.HANBAITENNM, NVL2(Y.GROUPCD, Y.HANBAITENNM, NVL2(X.GROUPCD, X.HANBAITENNM, ''))) AS HANBAITENNM ")
            strSQL.Append("FROM   X,Y,Z,DUMMY ")
            strSQL.Append("WHERE  DUMMY.KURACD = :KURACD ")
            strSQL.Append("AND    DUMMY.ACBCD = :ACBCD ")
            strSQL.Append("AND    DUMMY.KURACD = X.KURACD(+) ")
            strSQL.Append("AND    DUMMY.ACBCD = X.ACBCD(+) ")
            strSQL.Append("AND    DUMMY.KURACD = Y.KURACD(+) ")
            strSQL.Append("AND    DUMMY.ACBCD = Y.ACBCD(+) ")
            strSQL.Append("AND    DUMMY.KURACD = Z.KURACD(+) ")
            strSQL.Append("AND    DUMMY.ACBCD = Z.ACBCD(+) ")

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("KURACD") = pstrKURACD
            cdb.pSQLParamStr("ACBCD") = pstrACBCD
            cdb.pSQLParamStr("USER_CD") = pstrUSER_CD

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' 取得した値
            '*******************************
            If Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = "" OrElse
                Convert.ToString(ds.Tables(0).Rows(0).Item("HANBAITENNM")) = "" Then 'ＤＢにデータが存在する？
                Return "販売店コード・名称が登録されていません。" & pstrKURACD & ":" & pstrACBCD & ":" & pstrUSER_CD
            Else
                strHANBAITENCD_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD"))
                strHANBAITENNM_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("HANBAITENNM"))
            End If


            'マスタデータ参照
            'M10_HANJIGYOSYAから、販売事業者コード、販売事業者名称を取得
            strSQL = New StringBuilder("")
            strSQL.Append("WITH X AS ")
            strSQL.Append("( ")
            strSQL.Append("    SELECT A.KURACD ")
            strSQL.Append("           ,A.ACBCD ")
            strSQL.Append("           ,B.GROUPCD ")
            strSQL.Append("           ,B.HANJIGYOSYANM ")
            strSQL.Append("    FROM   M09_JAGROUP A ")
            strSQL.Append("           ,M10_HANJIGYOSYA B ")
            strSQL.Append("    WHERE  A.KURACD = :KURACD ")
            strSQL.Append("    AND   A.ACBCD = :ACBCD ")
            strSQL.Append("    AND   A.USERCD_FROM IS NULL ")
            strSQL.Append("    AND   A.USERCD_TO IS NULL ")
            strSQL.Append("    AND   A.KBN = '001' ")
            strSQL.Append("    AND   A.GROUPCD = B.GROUPCD ")
            strSQL.Append("), ")
            strSQL.Append("Y AS ")
            strSQL.Append("( ")
            strSQL.Append("    SELECT A.KURACD ")
            strSQL.Append("           ,A.ACBCD ")
            strSQL.Append("           ,B.GROUPCD ")
            strSQL.Append("           ,B.HANJIGYOSYANM ")
            strSQL.Append("    FROM   M09_JAGROUP A ")
            strSQL.Append("           ,M10_HANJIGYOSYA B ")
            strSQL.Append("    WHERE  A.KURACD = :KURACD ")
            strSQL.Append("    AND   A.ACBCD = :ACBCD ")
            strSQL.Append("    AND   :USER_CD BETWEEN A.USERCD_FROM AND A.USERCD_TO  ")
            strSQL.Append("    AND   A.KBN = '001' ")
            strSQL.Append("    AND   A.GROUPCD = B.GROUPCD ")
            strSQL.Append("), ")
            strSQL.Append("Z AS  ")
            strSQL.Append("( ")
            strSQL.Append("    SELECT A.KURACD ")
            strSQL.Append("           ,A.ACBCD ")
            strSQL.Append("           ,B.GROUPCD ")
            strSQL.Append("           ,B.HANJIGYOSYANM ")
            strSQL.Append("    FROM   M09_JAGROUP A ")
            strSQL.Append("           ,M10_HANJIGYOSYA B ")
            strSQL.Append("    WHERE  A.KURACD = :KURACD ")
            strSQL.Append("    AND   A.ACBCD = :ACBCD ")
            strSQL.Append("    AND   A.USERCD_FROM = :USER_CD ")
            strSQL.Append("    AND   A.USERCD_TO IS NULL ")
            strSQL.Append("    AND   A.KBN = '001' ")
            strSQL.Append("    AND   A.GROUPCD = B.GROUPCD ")
            strSQL.Append("), ")
            strSQL.Append("DUMMY AS ")
            strSQL.Append("( ")
            strSQL.Append("SELECT :KURACD AS KURACD ")
            strSQL.Append("       ,:ACBCD AS ACBCD ")
            strSQL.Append("FROM   DUAL ")
            strSQL.Append(") ")
            strSQL.Append("SELECT NVL(Z.GROUPCD, NVL(Y.GROUPCD, NVL(X.GROUPCD, ''))) AS GROUPCD ")
            strSQL.Append("       ,NVL2(Z.GROUPCD, Z.HANJIGYOSYANM, NVL2(Y.GROUPCD, Y.HANJIGYOSYANM, NVL2(X.GROUPCD, X.HANJIGYOSYANM, ''))) AS HANJIGYOSYANM ")
            strSQL.Append("FROM   X,Y,Z,DUMMY ")
            strSQL.Append("WHERE  DUMMY.KURACD = :KURACD ")
            strSQL.Append("AND    DUMMY.ACBCD = :ACBCD ")
            strSQL.Append("AND    DUMMY.KURACD = X.KURACD(+) ")
            strSQL.Append("AND    DUMMY.ACBCD = X.ACBCD(+) ")
            strSQL.Append("AND    DUMMY.KURACD = Y.KURACD(+) ")
            strSQL.Append("AND    DUMMY.ACBCD = Y.ACBCD(+) ")
            strSQL.Append("AND    DUMMY.KURACD = Z.KURACD(+) ")
            strSQL.Append("AND    DUMMY.ACBCD = Z.ACBCD(+) ")

            'パラメータに値をセット
            cdb.pSQLParamStr("KURACD") = pstrKURACD
            cdb.pSQLParamStr("ACBCD") = pstrACBCD
            cdb.pSQLParamStr("USER_CD") = pstrUSER_CD

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' 取得した値
            '*******************************
            If Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD")) = "" OrElse
                Convert.ToString(ds.Tables(0).Rows(0).Item("HANJIGYOSYANM")) = "" Then 'ＤＢにデータが存在する？
                Return "販売事業者コード・名称が登録されていません。" & pstrKURACD & ":" & pstrACBCD & ":" & pstrUSER_CD
            Else
                strHANJIGYOSYACD_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("GROUPCD"))
                strHANJIGYOSYANM_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("HANJIGYOSYANM"))
            End If


            'マスタデータ参照
            'M11_JAHOKOKUから、販売店コード、販売店名称を取得
            'pstrRENTELが空白なら、マスタから取得
            '更新の場合、D30に入っているデータは使わない。
            If pstrRENTEL = "" Then
                Dim strTANCD As String
                For iTANCD As Integer = 0 To 29
                    strTANCD = CStr(30 - iTANCD).PadLeft(2, "0"c) '2桁0埋め

                    strSQL = New StringBuilder("")
                    strSQL.Append("WITH X AS ")
                    strSQL.Append("( ")
                    strSQL.Append("    SELECT A.KURACD ")
                    strSQL.Append("           ,A.ACBCD ")
                    strSQL.Append("           ,B.GROUPCD ")
                    strSQL.Append("           ,B.RENTEL1 ")
                    strSQL.Append("    FROM   M09_JAGROUP A ")
                    strSQL.Append("           ,M11_JAHOKOKU B ")
                    strSQL.Append("    WHERE  A.KBN = '002' ")
                    strSQL.Append("    AND    A.KURACD = :KURACD ")
                    strSQL.Append("    AND    A.ACBCD = :ACBCD ")
                    strSQL.Append("    AND    A.GROUPCD = B.GROUPCD ")
                    strSQL.Append("    AND    B.TANCD = :TANCD ")
                    strSQL.Append("    AND    A.USERCD_FROM IS NULL ")
                    strSQL.Append("    AND    A.USERCD_TO IS NULL ")
                    strSQL.Append("), ")
                    strSQL.Append("Y AS ")
                    strSQL.Append("( ")
                    strSQL.Append("    SELECT A.KURACD ")
                    strSQL.Append("           ,A.ACBCD ")
                    strSQL.Append("           ,B.GROUPCD ")
                    strSQL.Append("           ,B.RENTEL1 ")
                    strSQL.Append("    FROM   M09_JAGROUP A ")
                    strSQL.Append("           ,M11_JAHOKOKU B ")
                    strSQL.Append("    WHERE  A.KBN = '002' ")
                    strSQL.Append("    AND    A.KURACD = :KURACD ")
                    strSQL.Append("    AND    A.ACBCD = :ACBCD ")
                    strSQL.Append("    AND    A.GROUPCD = B.GROUPCD ")
                    strSQL.Append("    AND    B.TANCD = :TANCD ")
                    strSQL.Append("    AND    :USER_CD BETWEEN A.USERCD_FROM AND A.USERCD_TO ")
                    strSQL.Append("), ")
                    strSQL.Append("Z AS ")
                    strSQL.Append("( ")
                    strSQL.Append("    SELECT A.KURACD ")
                    strSQL.Append("           ,A.ACBCD ")
                    strSQL.Append("           ,B.GROUPCD ")
                    strSQL.Append("           ,B.RENTEL1 ")
                    strSQL.Append("    FROM   M09_JAGROUP A ")
                    strSQL.Append("           ,M11_JAHOKOKU B ")
                    strSQL.Append("    WHERE  A.KBN = '002' ")
                    strSQL.Append("    AND    A.KURACD = :KURACD ")
                    strSQL.Append("    AND    A.ACBCD = :ACBCD ")
                    strSQL.Append("    AND    A.GROUPCD = B.GROUPCD ")
                    strSQL.Append("    AND    B.TANCD = :TANCD ")
                    strSQL.Append("    AND    A.USERCD_FROM = :USER_CD ")
                    strSQL.Append("    AND    A.USERCD_TO IS NULL ")
                    strSQL.Append("), ")
                    strSQL.Append("DUMMY AS ")
                    strSQL.Append("( ")
                    strSQL.Append("SELECT :KURACD AS KURACD  ")
                    strSQL.Append("       ,:ACBCD AS ACBCD  ")
                    strSQL.Append("FROM   DUAL ")
                    strSQL.Append(") ")
                    strSQL.Append("SELECT NVL(Z.GROUPCD, NVL(Y.GROUPCD, NVL(X.GROUPCD, ''))) AS GROUPCD ")
                    strSQL.Append("       ,NVL2(Z.GROUPCD, Z.RENTEL1, NVL2(Y.GROUPCD, Y.RENTEL1, NVL2(X.GROUPCD, X.RENTEL1, ''))) AS RENTEL1 ")
                    strSQL.Append("FROM   X,Y,Z,DUMMY ")
                    strSQL.Append("WHERE  DUMMY.KURACD = :KURACD ")
                    strSQL.Append("AND    DUMMY.ACBCD = :ACBCD ")
                    strSQL.Append("AND    DUMMY.KURACD = X.KURACD(+) ")
                    strSQL.Append("AND    DUMMY.ACBCD = X.ACBCD(+) ")
                    strSQL.Append("AND    DUMMY.KURACD = Y.KURACD(+) ")
                    strSQL.Append("AND    DUMMY.ACBCD = Y.ACBCD(+) ")
                    strSQL.Append("AND    DUMMY.KURACD = Z.KURACD(+) ")
                    strSQL.Append("AND    DUMMY.ACBCD = Z.ACBCD(+) ")

                    'パラメータに値をセット
                    cdb.pSQLParamStr("KURACD") = pstrKURACD
                    cdb.pSQLParamStr("ACBCD") = pstrACBCD
                    cdb.pSQLParamStr("USER_CD") = pstrUSER_CD
                    cdb.pSQLParamStr("TANCD") = strTANCD

                    'SQL文セット
                    cdb.pSQL = strSQL.ToString

                    'SQL実行
                    cdb.mExecQuery()
                    ds = cdb.pResult

                    '連絡先電話番号１が取得できれば格納（TANCD=30から見て、あと勝ちにする）
                    If Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) <> "" Then
                        strRENTEL_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1"))
                    End If

                Next
            End If


            'マスタからデータ取得
            '昨年度データの検索　新規の時だけ
            If intMODE = 1 Then
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append("    A.NENDO ")
                strSQL.Append("    ,A.KURACD ")
                strSQL.Append("    ,A.KENCD ")
                strSQL.Append("    ,A.ACBCD ")
                strSQL.Append("    ,A.USER_CD ")
                strSQL.Append("    ,A.JUSYONM ")
                strSQL.Append("    ,A.ADDR1 ")
                strSQL.Append("    ,A.ADDR2 ")
                strSQL.Append("    ,A.ADDR3 ")
                strSQL.Append("    ,A.ADDR ")
                strSQL.Append("    ,A.RENTEL ")
                strSQL.Append("    ,A.SYUTUTEL ")
                strSQL.Append("    ,A.KESSEN ")
                strSQL.Append("    ,A.DAIHYO_NAME ")
                strSQL.Append("    ,A.KYOKTKBN ")
                strSQL.Append("    ,A.HOKBN ")
                strSQL.Append("    ,A.YOTOKBN ")
                strSQL.Append("    ,A.BUNRUICD ")
                strSQL.Append("    ,A.HANJICD ")
                strSQL.Append("    ,A.HANJINM ")
                strSQL.Append("    ,A.HANTENCD ")
                strSQL.Append("    ,A.HANTENNM ")
                strSQL.Append("    ,A.SAKUNEN_FLG ")
                strSQL.Append("    ,A.LTOS_FLG ")
                strSQL.Append("    ,A.INS_DATE ")
                strSQL.Append("    ,A.INS_USER ")
                strSQL.Append("    ,A.KISO_UPD_DATE ")
                strSQL.Append("    ,A.KISO_UPD_USER ")
                strSQL.Append("    ,A.LTOS_UPD_DATE ")
                strSQL.Append("    ,A.LTOS_UPD_USER ")
                strSQL.Append("FROM ")
                strSQL.Append("    D30_MEIBO A ")
                strSQL.Append("WHERE ")
                strSQL.Append("    A.NENDO = :NENDO ")
                strSQL.Append("AND A.KURACD = :KURACD ")
                strSQL.Append("AND A.ACBCD = :ACBCD ")
                strSQL.Append("AND A.USER_CD = :USER_CD ")

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("NENDO") = CStr(CInt(pstrNENDO) - 1)
                cdb.pSQLParamStr("KURACD") = pstrKURACD
                cdb.pSQLParamStr("ACBCD") = pstrACBCD
                cdb.pSQLParamStr("USER_CD") = pstrUSER_CD

                'SQL実行
                cdb.mExecQuery()
                ds = cdb.pResult

                '*******************************
                ' 取得した値
                '*******************************
                If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                    strDAIHYO_NAME_OLD = Convert.ToString(ds.Tables(0).Rows(0).Item("DAIHYO_NAME"))
                    strBUNRUICD_OLD = Convert.ToString(ds.Tables(0).Rows(0).Item("BUNRUICD"))
                    strSAKUNEN_FLG = "1"
                Else
                    strDAIHYO_NAME_OLD = ""
                    strBUNRUICD_OLD = ""
                    strSAKUNEN_FLG = ""
                End If
            End If



            '登録処理
            If intMODE = 1 Then
                '新規登録
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("  D30_MEIBO ( ")
                strSQL.Append("    NENDO ")
                strSQL.Append("    ,KURACD ")
                strSQL.Append("    ,KENCD ")
                strSQL.Append("    ,ACBCD ")
                strSQL.Append("    ,USER_CD ")
                strSQL.Append("    ,JUSYONM ")
                strSQL.Append("    ,ADDR1 ")
                strSQL.Append("    ,ADDR2 ")
                strSQL.Append("    ,ADDR3 ")
                strSQL.Append("    ,ADDR ")
                strSQL.Append("    ,RENTEL ")
                strSQL.Append("    ,SYUTUTEL ")
                strSQL.Append("    ,KESSEN ")
                strSQL.Append("    ,DAIHYO_NAME ")
                strSQL.Append("    ,KYOKTKBN ")
                strSQL.Append("    ,HOKBN ")
                strSQL.Append("    ,YOTOKBN ")
                strSQL.Append("    ,BUNRUICD ")
                strSQL.Append("    ,HANJICD ")
                strSQL.Append("    ,HANJINM ")
                strSQL.Append("    ,HANTENCD ")
                strSQL.Append("    ,HANTENNM ")
                strSQL.Append("    ,SAKUNEN_FLG ")
                strSQL.Append("    ,LTOS_FLG ")
                strSQL.Append("    ,INS_DATE ")
                strSQL.Append("    ,INS_USER ")
                strSQL.Append("    ,KISO_UPD_DATE ")
                strSQL.Append("    ,KISO_UPD_USER ")
                strSQL.Append("    ,LTOS_UPD_DATE ")
                strSQL.Append("    ,LTOS_UPD_USER ")
                strSQL.Append("  ) VALUES( ")
                strSQL.Append("    :NENDO ")
                strSQL.Append("    ,:KURACD ")
                strSQL.Append("    ,:KENCD ")
                strSQL.Append("    ,:ACBCD ")
                strSQL.Append("    ,:USER_CD ")
                strSQL.Append("    ,:JUSYONM ")
                strSQL.Append("    ,:ADDR1 ")
                strSQL.Append("    ,:ADDR2 ")
                strSQL.Append("    ,:ADDR3 ")
                strSQL.Append("    ,:ADDR ")
                strSQL.Append("    ,:RENTEL ")
                strSQL.Append("    ,:SYUTUTEL ")
                strSQL.Append("    ,:KESSEN ")
                strSQL.Append("    ,:DAIHYO_NAME ")
                strSQL.Append("    ,:KYOKTKBN ")
                strSQL.Append("    ,:HOKBN ")
                strSQL.Append("    ,:YOTOKBN ")
                strSQL.Append("    ,:BUNRUICD ")
                strSQL.Append("    ,:HANJICD ")
                strSQL.Append("    ,:HANJINM ")
                strSQL.Append("    ,:HANTENCD ")
                strSQL.Append("    ,:HANTENNM ")
                strSQL.Append("    ,:SAKUNEN_FLG ")
                strSQL.Append("    ,:LTOS_FLG ")
                strSQL.Append("    ,:INS_DATE ")
                strSQL.Append("    ,:INS_USER ")
                strSQL.Append("    ,:KISO_UPD_DATE ")
                strSQL.Append("    ,:KISO_UPD_USER ")
                strSQL.Append("    ,:LTOS_UPD_DATE ")
                strSQL.Append("    ,:LTOS_UPD_USER ")
                strSQL.Append("  ) ")

                'バインド変数
                cdb.pSQLParamStr("NENDO") = pstrNENDO
                cdb.pSQLParamStr("KURACD") = pstrKURACD
                cdb.pSQLParamStr("KENCD") = pstrKURACD.Substring(1, 2)
                cdb.pSQLParamStr("ACBCD") = pstrACBCD
                cdb.pSQLParamStr("USER_CD") = pstrUSER_CD
                cdb.pSQLParamStr("JUSYONM") = pstrJUSYONM
                cdb.pSQLParamStr("ADDR1") = pstrADDR1
                cdb.pSQLParamStr("ADDR2") = pstrADDR2
                cdb.pSQLParamStr("ADDR3") = pstrADDR3
                cdb.pSQLParamStr("ADDR") = fncmakeADD(pstrADDR1, pstrADDR2, pstrADDR3)
                cdb.pSQLParamStr("RENTEL") = pstrRENTEL
                '優先順位あってる？
                '新規登録の場合。
                '名簿基礎ファイル＞報告先マスタ
                If pstrRENTEL.Trim.Length > 0 Then
                    cdb.pSQLParamStr("SYUTUTEL") = pstrRENTEL
                ElseIf strRENTEL_DB.Trim.Length > 0 Then
                    cdb.pSQLParamStr("SYUTUTEL") = strRENTEL_DB
                Else
                    cdb.pSQLParamStr("SYUTUTEL") = ""
                End If

                cdb.pSQLParamStr("KESSEN") = pstrKESSEN

                If pstrDAIHYO_NAME.Trim.Length > 0 Then
                    cdb.pSQLParamStr("DAIHYO_NAME") = pstrDAIHYO_NAME
                ElseIf strDAIHYO_NAME_OLD.Trim.Length > 0 Then
                    cdb.pSQLParamStr("DAIHYO_NAME") = strDAIHYO_NAME_OLD
                Else
                    cdb.pSQLParamStr("DAIHYO_NAME") = ""
                End If

                cdb.pSQLParamStr("KYOKTKBN") = pstrKYOKTKBN
                cdb.pSQLParamStr("HOKBN") = pstrHOKBN
                cdb.pSQLParamStr("YOTOKBN") = pstrYOTOKBN

                '基礎ファイル＞D30＞昨年度＞用途区分等から判別
                If pstrBUNRUICD.Trim.Length > 0 Then
                    cdb.pSQLParamStr("BUNRUICD") = pstrBUNRUICD.Trim
                ElseIf strBUNRUICD_DB.Trim.Length > 0 Then
                    cdb.pSQLParamStr("BUNRUICD") = strBUNRUICD_DB
                ElseIf strBUNRUICD_OLD.Trim.Length > 0 Then
                    cdb.pSQLParamStr("BUNRUICD") = strBUNRUICD_OLD

                Else
                    If pstrYOTOKBN = "D" Then
                        cdb.pSQLParamStr("BUNRUICD") = "9"
                    ElseIf pstrHOKBN = "1" Then
                        cdb.pSQLParamStr("BUNRUICD") = "1"
                    ElseIf pstrHOKBN = "2" Then
                        cdb.pSQLParamStr("BUNRUICD") = "3"
                    ElseIf pstrHOKBN = "3" Then
                        cdb.pSQLParamStr("BUNRUICD") = "1"
                    ElseIf pstrHOKBN = "4" Then
                        cdb.pSQLParamStr("BUNRUICD") = "2"
                    ElseIf pstrHOKBN = "5" Then
                        cdb.pSQLParamStr("BUNRUICD") = "9"
                    ElseIf pstrKYOKTKBN = "1" Then
                        cdb.pSQLParamStr("BUNRUICD") = "1"
                    ElseIf pstrKYOKTKBN = "2" Then
                        cdb.pSQLParamStr("BUNRUICD") = "1"
                    ElseIf pstrKYOKTKBN = "3" Then
                        cdb.pSQLParamStr("BUNRUICD") = "2"
                    Else
                        cdb.pSQLParamStr("BUNRUICD") = ""
                    End If
                End If

                cdb.pSQLParamStr("HANJICD") = strHANJIGYOSYACD_DB
                cdb.pSQLParamStr("HANJINM") = strHANJIGYOSYANM_DB
                cdb.pSQLParamStr("HANTENCD") = strHANBAITENCD_DB
                cdb.pSQLParamStr("HANTENNM") = strHANBAITENNM_DB
                cdb.pSQLParamStr("SAKUNEN_FLG") = strSAKUNEN_FLG
                cdb.pSQLParamStr("LTOS_FLG") = ""
                cdb.pSQLParamStr("INS_DATE") = Now.ToString("yyyyMMddHHmmss")
                cdb.pSQLParamStr("INS_USER") = pstrUSER
                cdb.pSQLParamStr("KISO_UPD_DATE") = ""
                cdb.pSQLParamStr("KISO_UPD_USER") = ""
                cdb.pSQLParamStr("LTOS_UPD_DATE") = ""
                cdb.pSQLParamStr("LTOS_UPD_USER") = ""

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'SQLを実行
                cdb.mExecNonQuery()


            ElseIf intMODE = 2 Then
                '更新
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("     D30_MEIBO ")
                strSQL.Append("SET ")
                strSQL.Append("     NENDO = :NENDO ")
                strSQL.Append("     ,KURACD = :KURACD ")
                strSQL.Append("     ,KENCD = :KENCD ")
                strSQL.Append("     ,ACBCD = :ACBCD ")
                strSQL.Append("     ,USER_CD = :USER_CD ")
                strSQL.Append("     ,JUSYONM = :JUSYONM ")
                strSQL.Append("     ,ADDR1 = :ADDR1 ")
                strSQL.Append("     ,ADDR2 = :ADDR2 ")
                strSQL.Append("     ,ADDR3 = :ADDR3 ")
                strSQL.Append("     ,ADDR = :ADDR ")
                strSQL.Append("     ,RENTEL = :RENTEL ")
                strSQL.Append("     ,SYUTUTEL = :SYUTUTEL ")
                strSQL.Append("     ,KESSEN = :KESSEN ")
                strSQL.Append("     ,DAIHYO_NAME = :DAIHYO_NAME ")
                strSQL.Append("     ,KYOKTKBN = :KYOKTKBN ")
                strSQL.Append("     ,HOKBN = :HOKBN ")
                strSQL.Append("     ,YOTOKBN = :YOTOKBN ")
                strSQL.Append("     ,BUNRUICD = :BUNRUICD ")
                strSQL.Append("     ,HANJICD = :HANJICD ")
                strSQL.Append("     ,HANJINM = :HANJINM ")
                strSQL.Append("     ,HANTENCD = :HANTENCD ")
                strSQL.Append("     ,HANTENNM = :HANTENNM ")
                'strSQL.Append("     ,SAKUNEN_FLG = :SAKUNEN_FLG ")
                'strSQL.Append("     ,LTOS_FLG = :LTOS_FLG ")
                'strSQL.Append("     ,INS_DATE = :INS_DATE ")
                'strSQL.Append("     ,INS_USER = :INS_USER ")
                strSQL.Append("     ,KISO_UPD_DATE = :KISO_UPD_DATE ")
                strSQL.Append("     ,KISO_UPD_USER = :KISO_UPD_USER ")
                'strSQL.Append("     ,LTOS_UPD_DATE = :LTOS_UPD_DATE ")
                'strSQL.Append("     ,LTOS_UPD_USER = :LTOS_UPD_USER ")
                strSQL.Append("WHERE ")
                strSQL.Append("     NENDO = :NENDO ")
                strSQL.Append("AND  KURACD = :KURACD ")
                strSQL.Append("AND  ACBCD = :ACBCD ")
                strSQL.Append("AND  USER_CD = :USER_CD ")


                'バインド変数
                cdb.pSQLParamStr("NENDO") = pstrNENDO
                cdb.pSQLParamStr("KURACD") = pstrKURACD
                cdb.pSQLParamStr("KENCD") = pstrKURACD.Substring(1, 2)
                cdb.pSQLParamStr("ACBCD") = pstrACBCD
                cdb.pSQLParamStr("USER_CD") = pstrUSER_CD
                cdb.pSQLParamStr("JUSYONM") = pstrJUSYONM
                cdb.pSQLParamStr("ADDR1") = pstrADDR1
                cdb.pSQLParamStr("ADDR2") = pstrADDR2
                cdb.pSQLParamStr("ADDR3") = pstrADDR3
                cdb.pSQLParamStr("ADDR") = fncmakeADD(pstrADDR1, pstrADDR2, pstrADDR3)
                cdb.pSQLParamStr("RENTEL") = pstrRENTEL
                '更新の場合。
                '名簿基礎ファイル＞報告先マスタ
                If pstrRENTEL.Trim.Length > 0 Then
                    cdb.pSQLParamStr("SYUTUTEL") = pstrRENTEL
                ElseIf strRENTEL_DB.Trim.Length > 0 Then
                    cdb.pSQLParamStr("SYUTUTEL") = strRENTEL_DB
                Else
                    cdb.pSQLParamStr("SYUTUTEL") = ""
                End If

                cdb.pSQLParamStr("KESSEN") = pstrKESSEN

                '法人代表者氏名　更新の場合、ファイルの内容優先（空白でも）
                cdb.pSQLParamStr("DAIHYO_NAME") = pstrDAIHYO_NAME

                cdb.pSQLParamStr("KYOKTKBN") = pstrKYOKTKBN
                cdb.pSQLParamStr("HOKBN") = pstrHOKBN
                cdb.pSQLParamStr("YOTOKBN") = pstrYOTOKBN

                '分類コード
                '基礎ファイル＞D30＞用途区分等から判別
                If pstrBUNRUICD.Trim.Length > 0 Then
                    cdb.pSQLParamStr("BUNRUICD") = pstrBUNRUICD
                ElseIf strBUNRUICD_DB.Trim.Length > 0 Then
                    cdb.pSQLParamStr("BUNRUICD") = strBUNRUICD_DB
                Else
                    If pstrYOTOKBN = "D" Then
                        cdb.pSQLParamStr("BUNRUICD") = "9"
                    ElseIf pstrHOKBN = "1" Then
                        cdb.pSQLParamStr("BUNRUICD") = "1"
                    ElseIf pstrHOKBN = "2" Then
                        cdb.pSQLParamStr("BUNRUICD") = "3"
                    ElseIf pstrHOKBN = "3" Then
                        cdb.pSQLParamStr("BUNRUICD") = "1"
                    ElseIf pstrHOKBN = "4" Then
                        cdb.pSQLParamStr("BUNRUICD") = "2"
                    ElseIf pstrHOKBN = "5" Then
                        cdb.pSQLParamStr("BUNRUICD") = "9"
                    ElseIf pstrKYOKTKBN = "1" Then
                        cdb.pSQLParamStr("BUNRUICD") = "1"
                    ElseIf pstrKYOKTKBN = "2" Then
                        cdb.pSQLParamStr("BUNRUICD") = "1"
                    ElseIf pstrKYOKTKBN = "3" Then
                        cdb.pSQLParamStr("BUNRUICD") = "2"
                    Else
                        cdb.pSQLParamStr("BUNRUICD") = ""
                    End If
                End If

                cdb.pSQLParamStr("HANJICD") = strHANJIGYOSYACD_DB
                cdb.pSQLParamStr("HANJINM") = strHANJIGYOSYANM_DB
                cdb.pSQLParamStr("HANTENCD") = strHANBAITENCD_DB
                cdb.pSQLParamStr("HANTENNM") = strHANBAITENNM_DB
                'cdb.pSQLParamStr("SAKUNEN_FLG") = strSAKUNEN_FLG　　更新時は昨年度を見ない
                'cdb.pSQLParamStr("LTOS_FLG") = ""
                'cdb.pSQLParamStr("INS_DATE") = Now.ToString("yyyyMMddHHmmss")
                'cdb.pSQLParamStr("INS_USER") = pstrUSER
                cdb.pSQLParamStr("KISO_UPD_DATE") = Now.ToString("yyyyMMddHHmmss")
                cdb.pSQLParamStr("KISO_UPD_USER") = pstrUSER
                'cdb.pSQLParamStr("LTOS_UPD_DATE") = ""
                'cdb.pSQLParamStr("LTOS_UPD_USER") = ""

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'SQLを実行
                cdb.mExecNonQuery()


            End If

            '1レコードごとにコミット
            cdb.mCommit()


        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString

            '排他制御処理エラー
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If

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
    '*　概　要:LTOSファイル読み込み
    '*　備　考:
    '******************************************************************************
    <WebMethod()> Public Function mReadLTOSfile(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String) As String
        Dim WB As IWorkbook = WorkbookFactory.Create(pstrFilePath)
        '2019/11/01 T.Ono mod 監視改善2019
        'Dim WS As ISheet = WB.GetSheetAt(0)
        'Dim iLastRow As Integer = WS.LastRowNum
        Dim strCell As String = "" 'セルの値格納'
        Dim strRes As String = "OK"
        Dim intUpdateCnt As Integer = 0 '更新レコード数
        Dim intPassCnt As Integer = 0   'pass数

        '項目
        Dim strNENDO As String = ""
        Dim strKENCD As String = ""
        Dim strJACD As String = ""         'JAコード
        Dim strJASCD As String = ""        '支所コード
        Dim strACBCD As String = ""        'JA支所コード（JAコード+支所コード）
        Dim strUSER_CD As String = ""
        Dim strDAIHYO_NAME As String = ""
        Dim strKYOKTKBN As String = ""
        Dim strHOKBN As String = ""
        Dim strYOTOKBN As String = ""

        '★★★
        mlog("mReadLTOSfile：スタート：" & Now.ToString("yyyyMMddHHmmss"))

        Try
            '2019/11/01 T.Ono mod 監視改善2019 複数シートに対応
            For icountS As Integer = 0 To WB.NumberOfSheets - 1
                mlog("シート�ａF" & icountS)
                Dim WS As ISheet = WB.GetSheetAt(icountS)
                Dim iLastRow As Integer = WS.LastRowNum


                For iCountR As Integer = 2 To iLastRow
                    Dim getRow As IRow = WS.GetRow(iCountR)

                    '１行読み込み
                    For iCountC As Integer = 0 To 8
                        Dim getCell As ICell = getRow.GetCell(iCountC)

                        'strCellにセルの値を格納
                        If getCell Is Nothing Then
                            '空白'
                            strCell = ""
                        Else
                            Dim celltype As CellType = getCell.CellType
                            Select Case celltype
                                Case CellType.String
                                    '文字列
                                    strCell = getCell.StringCellValue
                                Case CellType.Numeric
                                    '数値
                                    strCell = getCell.NumericCellValue.ToString
                                Case CellType.Blank
                                    'ブランク
                                    strCell = ""
                            End Select
                        End If


                        '各項目の入力チェック
                        Select Case iCountC
                            Case 0 '県コード'
                                strKENCD = strCell

                            Case 1 '卸コードコード'


                            Case 2 'ＪＡコード'
                                strJACD = strCell

                            Case 3 '支所コード'
                                strJASCD = strCell

                            Case 4 '利用者コード'
                                strUSER_CD = strCell

                            Case 5 '法人代表者名'
                                strDAIHYO_NAME = strCell

                            Case 6 '供給形態区分'
                                strKYOKTKBN = strCell

                            Case 7 '適用法令区分'
                                strHOKBN = strCell

                            Case 8 '用途区分'
                                strYOTOKBN = strCell

                        End Select
                    Next

                    'JA支所コード
                    strACBCD = strJACD.Trim & strJASCD.Trim

                    'DB更新処理
                    strRes = FncDBprocessLTOS(
                                        pstrNendo.Trim,
                                        strKENCD.Trim,
                                        strACBCD.Trim,
                                        strUSER_CD.Trim,
                                        strDAIHYO_NAME.Trim,
                                        strKYOKTKBN.Trim,
                                        strHOKBN.Trim,
                                        strYOTOKBN.Trim,
                                        pstrUser
                                        )


                    'エラー処理
                    If strRes = "OK" Then
                        intUpdateCnt += 1
                    ElseIf strRes = "OKpass" Then
                        intPassCnt += 1
                    Else
                        '2019/11/01 T.Ono mod 監視改善2019
                        'mlog("ERROR：FncDBprocessLTOS strRes:" & CStr(iCountR + 1) & "行目:" & strRes)
                        'Return "ERROR：" & CStr(iCountR + 1) & "行目"
                        mlog("ERROR：FncDBprocessLTOS strRes:" & "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目:" & strRes)
                        Return "ERROR：" & "シート " & icountS + 1 & " " & CStr(iCountR + 1) & "行目"
                    End If
                Next
            Next


            strRes = strRes & ":" & intUpdateCnt & ":" & intPassCnt
            mlog("mReadLTOSfile：エンド　：" & Now.ToString("yyyyMMddHHmmss"))
            Return strRes

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:mReadkisofile:" & ex.ToString
        End Try

    End Function
    '******************************************************************************
    '*　概　要:LTOSファイル読み込み(CSV)
    '*　備　考:2019/11/01 T.Ono add 監視改善2019
    '******************************************************************************
    <WebMethod()> Public Function mReadLTOSfileCSV(ByVal pstrFilePath As String, ByVal pstrNendo As String, ByVal pstrUser As String) As String

        Dim parser As New FileIO.TextFieldParser(pstrFilePath, Encoding.GetEncoding("shift_jis"))
        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",")
        parser.TrimWhiteSpace = True

        Dim strCell As String = "" 'セルの値格納
        Dim strRes As String = "OK"
        Dim iCountR As Integer = 0
        Dim intUpdateCnt As Integer = 0 '更新レコード数
        Dim intPassCnt As Integer = 0   'pass数

        '項目
        Dim strNENDO As String = ""
        Dim strKENCD As String = ""
        Dim strJACD As String = ""         'JAコード
        Dim strJASCD As String = ""        '支所コード
        Dim strACBCD As String = ""        'JA支所コード（JAコード+支所コード）
        Dim strUSER_CD As String = ""
        Dim strDAIHYO_NAME As String = ""
        Dim strKYOKTKBN As String = ""
        Dim strHOKBN As String = ""
        Dim strYOTOKBN As String = ""

        '★★★
        mlog("mReadLTOSfileCSV：スタート：" & Now.ToString("yyyyMMddHHmmss"))
        Try
            While Not parser.EndOfData
                Dim record As String()
                record = parser.ReadFields()
                If iCountR > 1 Then 'ヘッダは飛ばす
                    '県コード'
                    mlog("0")
                    strKENCD = record(0)

                    '卸コード


                    'ＪＡコード'
                    mlog("2")
                    strJACD = record(2)

                    '支所コード'
                    strJASCD = record(3)

                    '利用者コード'
                    strUSER_CD = record(4)

                    '法人代表者氏名'
                    strDAIHYO_NAME = record(5)

                    '供給形態区分'
                    strKYOKTKBN = record(6)

                    '適用法令区分'
                    strHOKBN = record(7)

                    '用途区分'
                    strYOTOKBN = record(8)


                    'JA支所コード
                    strACBCD = strJACD.Trim & strJASCD.Trim

                    'DB更新処理
                    mlog("call FncDBprocessLTOS")
                    strRes = FncDBprocessLTOS(
                                        pstrNendo.Trim,
                                        strKENCD.Trim,
                                        strACBCD.Trim,
                                        strUSER_CD.Trim,
                                        strDAIHYO_NAME.Trim,
                                        strKYOKTKBN.Trim,
                                        strHOKBN.Trim,
                                        strYOTOKBN.Trim,
                                        pstrUser
                                        )


                    'エラー処理
                    If strRes = "OK" Then
                        intUpdateCnt += 1
                    ElseIf strRes = "OKpass" Then
                        intPassCnt += 1
                    Else
                        mlog("ERROR：FncDBprocessLTOS strRes:" & CStr(iCountR + 1) & "行目:" & strRes)
                        Return "ERROR：" & CStr(iCountR + 1) & "行目"
                    End If

                End If

                iCountR += 1

            End While

            strRes = strRes & ":" & intUpdateCnt & ":" & intPassCnt
            mlog("mReadLTOSfileCSV：エンド　：" & Now.ToString("yyyyMMddHHmmss"))
            Return strRes

        Catch ex As Exception
            'エラーの内容とＳＱＬ文を返すbaba
            Return "ERROR:mReadLTOSfileCSV:" & ex.ToString
        End Try


    End Function
    '******************************************************************************
    '*　概　要:データベース更新処理（LTOSファイル）
    '*　備　考:
    '******************************************************************************
    Private Function FncDBprocessLTOS(
                                        ByVal pstrNENDO As String,
                                        ByVal pstrKENCD As String,
                                        ByVal pstrACBCD As String,
                                        ByVal pstrUSER_CD As String,
                                        ByVal pstrDAIHYO_NAME As String,
                                        ByVal pstrKYOKTKBN As String,
                                        ByVal pstrHOKBN As String,
                                        ByVal pstrYOTOKBN As String,
                                        ByVal pstrUSER As String
                                        ) As String

        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim intMODE As Integer

        '値格納
        Dim strDAIHYO_NAME_DB As String     'DBから取得した法人代表者名
        Dim strBUNRUICD_DB As String        'DBから取得した分類コード

        strRes = "OK"

        '接続OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try


            mlog("FncDBprocessLTOS=1")
            'トランザクション開始--------------------------
            cdb.mBeginTrans()


            '新規か更新か
            'テーブルを検索
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("    A.NENDO ")
            strSQL.Append("    ,A.KURACD ")
            strSQL.Append("    ,A.KENCD ")
            strSQL.Append("    ,A.ACBCD ")
            strSQL.Append("    ,A.USER_CD ")
            strSQL.Append("    ,A.JUSYONM ")
            strSQL.Append("    ,A.ADDR1 ")
            strSQL.Append("    ,A.ADDR2 ")
            strSQL.Append("    ,A.ADDR3 ")
            strSQL.Append("    ,A.ADDR ")
            strSQL.Append("    ,A.RENTEL ")
            strSQL.Append("    ,A.SYUTUTEL ")
            strSQL.Append("    ,A.KESSEN ")
            strSQL.Append("    ,A.DAIHYO_NAME ")
            strSQL.Append("    ,A.KYOKTKBN ")
            strSQL.Append("    ,A.HOKBN ")
            strSQL.Append("    ,A.YOTOKBN ")
            strSQL.Append("    ,A.BUNRUICD ")
            strSQL.Append("    ,A.HANJICD ")
            strSQL.Append("    ,A.HANJINM ")
            strSQL.Append("    ,A.HANTENCD ")
            strSQL.Append("    ,A.HANTENNM ")
            strSQL.Append("    ,A.SAKUNEN_FLG ")
            strSQL.Append("    ,A.LTOS_FLG ")
            strSQL.Append("    ,A.INS_DATE ")
            strSQL.Append("    ,A.INS_USER ")
            strSQL.Append("    ,A.KISO_UPD_DATE ")
            strSQL.Append("    ,A.KISO_UPD_USER ")
            strSQL.Append("    ,A.LTOS_UPD_DATE ")
            strSQL.Append("    ,A.LTOS_UPD_USER ")
            strSQL.Append("FROM ")
            strSQL.Append("    D30_MEIBO A ")
            strSQL.Append("WHERE ")
            strSQL.Append("    A.NENDO = :NENDO ")
            strSQL.Append("AND A.KENCD = :KENCD ")
            strSQL.Append("AND A.ACBCD = :ACBCD ")
            strSQL.Append("AND A.USER_CD = :USER_CD ")

            'SQL文セット
            cdb.pSQL = strSQL.ToString

            'パラメータに値をセット
            cdb.pSQLParamStr("NENDO") = pstrNENDO
            cdb.pSQLParamStr("KENCD") = pstrKENCD
            cdb.pSQLParamStr("ACBCD") = pstrACBCD
            cdb.pSQLParamStr("USER_CD") = pstrUSER_CD

            'SQL実行
            cdb.mExecQuery()
            ds = cdb.pResult

            '*******************************
            ' モードの決定
            '*******************************
            If (ds.Tables(0).Rows.Count <> 0) Then 'ＤＢにデータが存在する？
                mlog("FncDBprocessLTOS=2")
                '更新
                intMODE = 2
                'データがある場合は更新に使うデータを格納
                strDAIHYO_NAME_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("DAIHYO_NAME"))
                strBUNRUICD_DB = Convert.ToString(ds.Tables(0).Rows(0).Item("BUNRUICD"))
            Else
                'なにもしない
                mlog("FncDBprocessLTOS=3")
                Return "OKpass"
            End If


            '法人代表者、分類コードが登録されていない場合は、LTOSファイルの内容で更新する
            If strDAIHYO_NAME_DB.Trim.Length = 0 OrElse strBUNRUICD_DB.Trim.Length = 0 Then
                mlog("FncDBprocessLTOS=4")


                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("     D30_MEIBO ")

                If strDAIHYO_NAME_DB.Trim.Length = 0 AndAlso strBUNRUICD_DB.Trim.Length = 0 Then
                    strSQL.Append("SET ")
                    strSQL.Append("     DAIHYO_NAME = :DAIHYO_NAME ")
                    strSQL.Append("     ,KYOKTKBN = :KYOKTKBN ")
                    strSQL.Append("     ,HOKBN = :HOKBN ")
                    strSQL.Append("     ,YOTOKBN = :YOTOKBN ")
                    strSQL.Append("     ,BUNRUICD = :BUNRUICD ")
                ElseIf strDAIHYO_NAME_DB.Trim.Length = 0 Then
                    strSQL.Append("SET ")
                    strSQL.Append("     DAIHYO_NAME = :DAIHYO_NAME ")
                ElseIf strBUNRUICD_DB.Trim.Length = 0 Then
                    strSQL.Append("SET ")
                    strSQL.Append("     HOKBN = :HOKBN ")
                    strSQL.Append("     ,YOTOKBN = :YOTOKBN ")
                    strSQL.Append("     ,BUNRUICD = :BUNRUICD ")
                End If

                strSQL.Append("     ,LTOS_FLG = :LTOS_FLG ")
                strSQL.Append("     ,LTOS_UPD_DATE = :LTOS_UPD_DATE ")
                strSQL.Append("     ,LTOS_UPD_USER = :LTOS_UPD_USER ")
                strSQL.Append("WHERE ")
                strSQL.Append("     NENDO = :NENDO ")
                strSQL.Append("AND  KENCD = :KENCD ")
                strSQL.Append("AND  ACBCD = :ACBCD ")
                strSQL.Append("AND  USER_CD = :USER_CD ")

                'SQL文セット
                cdb.pSQL = strSQL.ToString

                'パラメータに値をセット
                cdb.pSQLParamStr("NENDO") = pstrNENDO
                cdb.pSQLParamStr("KENCD") = pstrKENCD
                cdb.pSQLParamStr("ACBCD") = pstrACBCD
                cdb.pSQLParamStr("USER_CD") = pstrUSER_CD
                cdb.pSQLParamStr("DAIHYO_NAME") = pstrDAIHYO_NAME

                cdb.pSQLParamStr("KYOKTKBN") = pstrKYOKTKBN
                cdb.pSQLParamStr("HOKBN") = pstrHOKBN
                cdb.pSQLParamStr("YOTOKBN") = pstrYOTOKBN

                '分類コードを決める
                If pstrYOTOKBN = "D" Then
                    cdb.pSQLParamStr("BUNRUICD") = "9"
                ElseIf pstrHOKBN = "1" Then
                    cdb.pSQLParamStr("BUNRUICD") = "1"
                ElseIf pstrHOKBN = "2" Then
                    cdb.pSQLParamStr("BUNRUICD") = "3"
                ElseIf pstrHOKBN = "3" Then
                    cdb.pSQLParamStr("BUNRUICD") = "1"
                ElseIf pstrHOKBN = "4" Then
                    cdb.pSQLParamStr("BUNRUICD") = "2"
                ElseIf pstrHOKBN = "5" Then
                    cdb.pSQLParamStr("BUNRUICD") = "9"
                ElseIf pstrKYOKTKBN = "1" Then
                    cdb.pSQLParamStr("BUNRUICD") = "1"
                ElseIf pstrKYOKTKBN = "2" Then
                    cdb.pSQLParamStr("BUNRUICD") = "1"
                ElseIf pstrKYOKTKBN = "3" Then
                    cdb.pSQLParamStr("BUNRUICD") = "2"
                Else
                    cdb.pSQLParamStr("BUNRUICD") = ""
                End If

                cdb.pSQLParamStr("LTOS_FLG") = "1"  'LTOSデータで上書きしたか。した="1" していない=""
                cdb.pSQLParamStr("LTOS_UPD_DATE") = Now.ToString("yyyyMMddHHmmss")
                cdb.pSQLParamStr("LTOS_UPD_USER") = pstrUSER

                'SQLを実行
                cdb.mExecNonQuery()

            Else
                mlog("FncDBprocessLTOS=5")

                'なにもしない
                Return "OKpass"
            End If

            'コミット
            cdb.mCommit()

        Catch ex As Exception
            'エラーが起きたら エラー内容を格納
            strRes = ex.ToString

            '排他制御処理エラー
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If

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

    '**********************************************************
    '出力住所を作る
    '戻り値：出力住所
    '**********************************************************
    Function fncmakeADD(ByVal strADD1 As String, ByVal strADD2 As String, ByVal strADD3 As String) As String

        '出力住所を作る。
        Dim intichi As Integer '住所3の先頭文字が、住所12内で最後に見つかった位置
        Dim stradd12 As String = strADD1.Trim & strADD2.Trim
        Dim stradd12_End As String 'intichiから、末尾までの文字
        Dim strADD As String '出力住所


        '住所3に値がなければ1と2を結合して返す
        If strADD3.Trim.Length = 0 Then
            Return strADD1 & strADD2
        End If

        '住所3の先頭文字が、住所12内に存在するか
        intichi = stradd12.LastIndexOf(strADD3.Substring(0, 1))
        If intichi > -1 Then
            '存在する
            '存在した位置から、末尾までを取得
            stradd12_End = stradd12.Substring(intichi)

            'stradd12_Endが住所3に存在するか
            If strADD3.IndexOf(stradd12_End) > -1 Then
                '存在する
                'stradd12_Endの文字列分、住所3を削除して結合
                strADD = stradd12 & strADD3.Substring(stradd12_End.Length).Trim
            Else
                '存在しない
                'すべて結合
                strADD = strADD1 & strADD2 & strADD3
            End If
        Else
            '存在しない
            'すべて結合
            strADD = strADD1.Trim & strADD2.Trim & strADD3.Trim
        End If

        Return strADD
    End Function

    '**********************************************************
    'バイト数取得
    '戻り値：バイト数
    '**********************************************************
    Public Shared Function LenB(ByVal stTarget As String) As Integer
        Return System.Text.Encoding.GetEncoding("Shift_JIS").GetByteCount(stTarget)
    End Function

    '**********************************************************
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        'Dim LogC As New CLog
        Dim strRecLog As String
        Dim strRec As String
        Dim bytesData As Byte()

        Dim linestring As String = ""
        'If strLogFlg = "1" Then
        '書き込みファイルへのストリーム
        Dim sw As StreamWriter
        Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)

        linestring = System.DateTime.Now & "|" & pstrString + vbCrLf
        sw = New StreamWriter(fs, System.Text.Encoding.Default)

        '引数の文字列をストリームに書き込み
        sw.Write(linestring)

        'メモリフラッシュ（ファイル書き込み）
        'sw.Flush()

        'ファイルクローズ
        sw.Close()
        sw.Dispose()
        fs.Close()
        fs.Dispose()
        'End If

    End Sub
End Class
