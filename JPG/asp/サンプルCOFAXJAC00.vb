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
    '�R���X�g���N�^
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
    '���M����
    '  �p�����[�^�FpstrDataFile�@���M����t�@�C���p�X
    '�@�@�@�@�@�@�FpstrFaxNumber ���M��d�b�ԍ�(0���M����'0,'���t�������)
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
        '//[COM]Microsoft Fax Service Extended COM Type Library���Q�Ɛݒ�(Imports����)
        '//�p�����[�^�ɂ��Ă̎Q�lURL
        '//http://msdn.microsoft.com/library/en-us/fax/faxinto_z_32er.asp?frame=true
        '//-----------------------------------------------------------------------
        Dim FaxDocumentObj As New FaxDocument
        Dim FaxServerObj As New FaxServer
        Dim JobIDObj As Object

        'FAX�T�[�o�[�Ƃ̐ڑ����s��(���N���C�A���g�ɐڑ��ׁ̈A�p�����[�^��"")
        Try
            'FaxServerObj.Connect("") ' 2010/07/02 T.Watabe edit
            If IsNothing(pstrSendFaxServer) Then
                pstrSendFaxServer = ""
            End If
            FaxServerObj.Connect(pstrSendFaxServer)
        Catch ex As Exception
            '�G���[
            strJobNumber = "ERROR:" & Hex(Err.Number) & ", " & Err.Description
            Return
        End Try

        '���M�p�����[�^��ݒ肵����ɑ��M���s��
        Try
            '���M�t�@�C���p�X�̐ݒ�(��EXE���쐬����EXCEL�t�@�C��)
            FaxDocumentObj.Body = pstrDataFile

            '�h�L�������g��(FAX�R���\�[���̃h�L�������g���ɕ\�������)
            FaxDocumentObj.DocumentName = strDOCUMENT_NAME

            '���M��FAX�ԍ��Ƒ��M�於�O
            FaxDocumentObj.Recipients.Add(pstrFaxNumber, strDOCUMENT_RECV_NAME)

            If pstrSendFaxServer.Length <= 0 Then '�T�[�o���w��H

                '���M�D��x
                'fptLOW    0 The fax will be sent with a low priority. All faxes that have a normal or a high priority will be sent before a fax that has a low priority. 
                'fptNORMAL 1 The fax will be sent with a normal priority. All faxes that have a high priority will be sent before a fax that has a normal priority. 
                'fptHIGH   2 The fax will be sent with a high priority. 
                FaxDocumentObj.Priority = 2                 '//fptHIGH

                'Choose to attach the fax to the fax receipt.
                FaxDocumentObj.AttachFaxToReceipt = True

                '���t��̑I��
                'Set the cover page type and the path of the cover page.
                'fcptNONE   0 No cover page. 
                'fcptLOCAL  1 Use a cover page from local computer. 
                'fcptSERVER 2 Use a cover page from the fax server common coverpages folder.  
                FaxDocumentObj.CoverPageType = 0            '//fcptSERVER �� fcptNONE
                'FaxDocumentObj.CoverPage = "generic"
                'Provide the cover page note.
                'FaxDocumentObj.Note = "TEXT FAX NOTE."

                '���M�惁�[���A�h���X
                'FaxDocumentObj.ReceiptAddress = "aaaa@aaaa.com"

                '���M�ʒm���@(���[���̂Ƃ��͏�L���[���A�h���X�w��)
                'frtNONE   0x0000 Do not send a delivery report. 
                'frtMAIL   0x0001 Send a delivery report through SMTP mail. 
                'frtMSGBOX 0x0004 Display a delivery report in a message box on the display of a specific computer. 
                FaxDocumentObj.ReceiptType = &H0    '0x0000 '//frtMAIL �� frtNONE

                '���M�^�C�~���O�w��(���Ԏw��̂Ƃ��͂��̎������w�肷��)
                'fstNOW             0 Send the fax as soon as a device is available. 
                'fstSPECIFIC_TIME   1 Send the fax no sooner than the specified time. The actual time that the fax will be sent depends on device availability and fax priority. 
                'fstDISCOUNT_PERIOD 2 Send the fax during the discount rate period. 
                FaxDocumentObj.ScheduleType = 0             '//fstSPECIFIC_TIME �� fstNOW
                'CDate converts the time to the Date data type
                'FaxDocumentObj.ScheduleTime = CDate("6:00:00 PM")

            End If

            '���t����
            FaxDocumentObj.Subject = strDOCUMENT_SUBJECT

            '���M�ҏ��
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

            '��L�Z�b�g���̕ۑ�
            FaxDocumentObj.Sender.SaveDefaultSender()

            '���M���s
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
    '���M����(�W���u�i���o�[)
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
