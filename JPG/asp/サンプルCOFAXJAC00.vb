Option Explicit On 
'Option Strict On

Imports FAXCOMEXLib
Imports System.Configuration

Public Class COFAXJAC00

    Private strResult As String
    Private strJobNumber As String

    Private strDOCUMENT_NAME As String
    Private strDOCUMENT_SUBJECT As String
    Private strDOCUMENT_RECV_NAME As String
    Private strDOCUMENT_SENDER_NAME As String
    Private strDOCUMENT_SENDER_EMAIL As String
    Private strDOCUMENT_SENDER_FAXNUMBER As String
    Private strDOCUMENT_SENDER_TELNUMBER As String
    Private strDOCUMENT_SENDER_ADD As String

    '**************************************************************************************************
    'コンストラクタ
    '**************************************************************************************************
    Sub New()
        strResult = ""
        strJobNumber = ""

        strDOCUMENT_NAME = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_NAME")
        strDOCUMENT_SUBJECT = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SUBJECT")
        strDOCUMENT_SENDER_NAME = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDERNAME")
        strDOCUMENT_SENDER_EMAIL = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDEREMAIL")
        strDOCUMENT_SENDER_FAXNUMBER = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDERFAXNUMBER")
        strDOCUMENT_SENDER_TELNUMBER = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDER_TELNUMBER")
        strDOCUMENT_SENDER_ADD = ConfigurationSettings.AppSettings("JIDOU_DOCUMENT_SENDER_ADD")

        strDOCUMENT_RECV_NAME = strDOCUMENT_SUBJECT
    End Sub

    '**************************************************************************************************
    '送信処理
    '  パラメータ：pstrDataFile　送信するファイルパス
    '　　　　　　：pstrFaxNumber 送信先電話番号(0発信時は'0,'が付加される)
    '**************************************************************************************************
    Public Sub mFaxSend( _
                        ByVal pstrDataFile As String, _
                        ByVal pstrFaxNumber As String _
                        )
        Call mFaxSend(pstrDataFile, pstrFaxNumber, "")
    End Sub
    Public Sub mFaxSend( _
                        ByVal pstrDataFile As String, _
                        ByVal pstrFaxNumber As String, _
                        ByVal pstrSendFaxServer As String _
                        )
        '//-----------------------------------------------------------------------
        '//[COM]Microsoft Fax Service Extended COM Type Libraryを参照設定(Importsする)
        '//パラメータについての参考URL
        '//http://msdn.microsoft.com/library/en-us/fax/faxinto_z_32er.asp?frame=true
        '//-----------------------------------------------------------------------
        Dim FaxDocumentObj As New FaxDocument
        Dim FaxServerObj As New FaxServer
        Dim JobIDObj As Object

        'FAXサーバーとの接続を行う(同クライアントに接続の為、パラメータは"")
        Try
            'FaxServerObj.Connect("") ' 2010/07/02 T.Watabe edit
            If IsNothing(pstrSendFaxServer) Then
                pstrSendFaxServer = ""
            End If
            FaxServerObj.Connect(pstrSendFaxServer)
        Catch ex As Exception
            'エラー
            strJobNumber = "ERROR:" & Hex(Err.Number) & ", " & Err.Description
            Return
        End Try

        '送信パラメータを設定した後に送信を行う
        Try
            '送信ファイルパスの設定(同EXEが作成したEXCELファイル)
            FaxDocumentObj.Body = pstrDataFile

            'ドキュメント名(FAXコンソールのドキュメント名に表示される)
            FaxDocumentObj.DocumentName = strDOCUMENT_NAME

            '送信先FAX番号と送信先名前
            FaxDocumentObj.Recipients.Add(pstrFaxNumber, strDOCUMENT_RECV_NAME)

            If pstrSendFaxServer.Length <= 0 Then 'サーバ未指定？

                '送信優先度
                'fptLOW    0 The fax will be sent with a low priority. All faxes that have a normal or a high priority will be sent before a fax that has a low priority. 
                'fptNORMAL 1 The fax will be sent with a normal priority. All faxes that have a high priority will be sent before a fax that has a normal priority. 
                'fptHIGH   2 The fax will be sent with a high priority. 
                FaxDocumentObj.Priority = 2                 '//fptHIGH

                'Choose to attach the fax to the fax receipt.
                FaxDocumentObj.AttachFaxToReceipt = True

                '送付状の選択
                'Set the cover page type and the path of the cover page.
                'fcptNONE   0 No cover page. 
                'fcptLOCAL  1 Use a cover page from local computer. 
                'fcptSERVER 2 Use a cover page from the fax server common coverpages folder.  
                FaxDocumentObj.CoverPageType = 0            '//fcptSERVER ⇒ fcptNONE
                'FaxDocumentObj.CoverPage = "generic"
                'Provide the cover page note.
                'FaxDocumentObj.Note = "TEXT FAX NOTE."

                '送信先メールアドレス
                'FaxDocumentObj.ReceiptAddress = "aaaa@aaaa.com"

                '送信通知方法(メールのときは上記メールアドレス指定)
                'frtNONE   0x0000 Do not send a delivery report. 
                'frtMAIL   0x0001 Send a delivery report through SMTP mail. 
                'frtMSGBOX 0x0004 Display a delivery report in a message box on the display of a specific computer. 
                FaxDocumentObj.ReceiptType = &H0    '0x0000 '//frtMAIL ⇒ frtNONE

                '送信タイミング指定(時間指定のときはその時刻も指定する)
                'fstNOW             0 Send the fax as soon as a device is available. 
                'fstSPECIFIC_TIME   1 Send the fax no sooner than the specified time. The actual time that the fax will be sent depends on device availability and fax priority. 
                'fstDISCOUNT_PERIOD 2 Send the fax during the discount rate period. 
                FaxDocumentObj.ScheduleType = 0             '//fstSPECIFIC_TIME ⇒ fstNOW
                'CDate converts the time to the Date data type
                'FaxDocumentObj.ScheduleTime = CDate("6:00:00 PM")

            End If

            '送付件名
            FaxDocumentObj.Subject = strDOCUMENT_SUBJECT

            '送信者情報
            FaxDocumentObj.Sender.Title = ""
            FaxDocumentObj.Sender.Name = strDOCUMENT_SENDER_NAME
            FaxDocumentObj.Sender.Email = strDOCUMENT_SENDER_EMAIL
            FaxDocumentObj.Sender.FaxNumber = strDOCUMENT_SENDER_FAXNUMBER
            FaxDocumentObj.Sender.HomePhone = strDOCUMENT_SENDER_TELNUMBER
            FaxDocumentObj.Sender.StreetAddress = strDOCUMENT_SENDER_ADD
            FaxDocumentObj.Sender.Company = strDOCUMENT_SENDER_NAME
            'FaxDocumentObj.Sender.OfficeLocation
            'FaxDocumentObj.Sender.OfficePhone
            'FaxDocumentObj.Sender.City
            'FaxDocumentObj.Sender.State
            'FaxDocumentObj.Sender.Country
            'FaxDocumentObj.Sender.TSID
            'FaxDocumentObj.Sender.ZipCode
            'FaxDocumentObj.Sender.BillingCode
            'FaxDocumentObj.Sender.Department

            '上記セット情報の保存
            FaxDocumentObj.Sender.SaveDefaultSender()

            '送信実行
            JobIDObj = FaxDocumentObj.ConnectedSubmit(FaxServerObj)

            strJobNumber = JobIDObj(0)
            strResult = "OK"
        Catch ex As Exception
            FaxDocumentObj = Nothing
            FaxServerObj.Disconnect()
            FaxServerObj = Nothing

            strJobNumber = Hex(Err.Number) & ", " & Err.Description
            strResult = "ERROR:" & ex.ToString
        End Try
    End Sub

    '**************************************************************************************************
    '送信結果(ジョブナンバー)
    '**************************************************************************************************
    Public ReadOnly Property pGerJobNumber() As String
        Get
            If strResult = "OK" Then
                Return strResult
            Else
                Return strResult & " " & strJobNumber
            End If

        End Get
    End Property
End Class
