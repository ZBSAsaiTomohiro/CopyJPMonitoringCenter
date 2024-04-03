<!-- 
'*******************************************************************************
' PG     : excelfax.aspx
' PG���� : �G�N�Z����FAX���M�e�X�g
' �쐬�� : 2014/01/01 ZBS T.Watabe
'*******************************************************************************
' �X�V����
' 2014/04/16 T.Watabe �[�������M�t���O�̔�r�`�F�b�N���t��������B
!-->
<%@LANGUAGE="VBScript" CODEPAGE="932"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<!-- %@ Import Namespace="System.Configuration" % -->

<script runat="server">
    '��`�A�錾'
    private Dim sendkbn As String
    private dim ymdfr as string
    private dim ymdto as string
    private dim kanscd as string 
    private dim kanscdwhe as string 
    private dim kanscdlock as string 
    private Dim sql1 as String
    private Dim faxsendflg as String
    private Dim strJobNumber as String
    private Dim pstrSendFaxServer as String
    private Dim pstrDataFile as String
    private Dim pstrFaxNumber as String
    private Dim strResult as String
    
</script>  
<%
    If Request("hdnFaxSend") <> "" Then
        faxsendflg = Request("hdnFaxSend")
    End If
    If Request("txtSendFaxServer") <> "" Then
        pstrSendFaxServer = Request("txtSendFaxServer")
    End If
    
 %>
 
<%

    if faxsendflg = "1" then
        strJobNumber = "test"
        try
            '("C:\TEMP\FAXTEST.vbs FAXTEST.rtf")
            'Set objShell = Server.CreateObject ("WScript.Shell")
            'objShell.Run "C:\TEMP\FAXTEST.vbs", 1, False
            'Set objShell = Nothing
            'System.Diagnostics.Process.Start("C:\TEMP\FAXTEST.vbs", "FAXTEST.rtf")
            
            strJobNumber = strJobNumber & ",1"

            'ProcessStartInfo�I�u�W�F�N�g���쐬����
            Dim psi As New System.Diagnostics.ProcessStartInfo()
            '�N������t�@�C���̃p�X���w�肷��
            psi.FileName = "C:\TEMP\FAXTEST.vbs"
            '�R�}���h���C���������w�肷��
            'psi.Arguments = """FAXTEST.rtf"""

            '�A�v���P�[�V�������N������
            System.Diagnostics.Process.Start(psi)

            strJobNumber = strJobNumber & ",2"

        Catch ex As Exception
            '�G���[
		    strJobNumber = ex.ToString
        End Try
    end if
    if faxsendflg = "9" then
      

    
        Dim strDOCUMENT_NAME As String
        Dim strDOCUMENT_SUBJECT As String
        Dim strDOCUMENT_RECV_NAME As String
        Dim strDOCUMENT_SENDER_NAME As String
        Dim strDOCUMENT_SENDER_EMAIL As String
        Dim strDOCUMENT_SENDER_FAXNUMBER As String
        Dim strDOCUMENT_SENDER_TELNUMBER As String
        Dim strDOCUMENT_SENDER_ADD As String

        strDOCUMENT_NAME             = "DOCUMENT_NAME"
        strDOCUMENT_SUBJECT          = "DOCUMENT_SUBJECT"
        strDOCUMENT_RECV_NAME        = "DOCUMENT_RECV_NAME"
        strDOCUMENT_SENDER_NAME      = "DOCUMENT_SENDER_NAME"
        strDOCUMENT_SENDER_EMAIL     = "test@ja-lp.co.jp"
        strDOCUMENT_SENDER_FAXNUMBER = "048-228-2009"
        strDOCUMENT_SENDER_TELNUMBER = "048-228-2007"
        strDOCUMENT_SENDER_ADD       = "����s"
        
        'pstrSendFaxServer = "10.10.15.141"
        'pstrSendFaxServer = ""
        'pstrDataFile = "C:\TEMP\FAXTEST.txt"
        pstrDataFile = "C:\TEMP\FAXTEST.rtf"
        pstrFaxNumber = "0333502160"

        '//-----------------------------------------------------------------------
        '//[COM]Microsoft Fax Service Extended COM Type Library���Q�Ɛݒ�(Imports����)
        '//�p�����[�^�ɂ��Ă̎Q�lURL
        '//http://msdn.microsoft.com/library/en-us/fax/faxinto_z_32er.asp?frame=true
        '//-----------------------------------------------------------------------
        Dim FaxDocumentObj As New FAXCOMEXLib.FaxDocument
        Dim FaxServerObj As New FAXCOMEXLib.FaxServer
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
            'strJobNumber = "ERROR:" & Hex(Err.Number) & ", " & Err.Description
		    strJobNumber = ex.ToString
        End Try

        if strJobNumber = "" then

            '���M�p�����[�^��ݒ肵����ɑ��M���s��
            Try
                '���M�t�@�C���p�X�̐ݒ�(��EXE���쐬����EXCEL�t�@�C��)
                FaxDocumentObj.Body = pstrDataFile

                '�h�L�������g��(FAX�R���\�[���̃h�L�������g���ɕ\�������)
                FaxDocumentObj.DocumentName = strDOCUMENT_NAME

                '���M��FAX�ԍ��Ƒ��M�於�O
                FaxDocumentObj.Recipients.Add(pstrFaxNumber, strDOCUMENT_RECV_NAME)

                'If pstrSendFaxServer.Length <= 0 Then '�T�[�o���w��H
                if true then

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

                'strJobNumber = Hex(Err.Number) & ", " & Err.Description
		        strJobNumber = ex.ToString
            End Try
        end if ' 
    end if

    if faxsendflg = "9" then
	    Dim wFaxServer As FAXCOMEXLib.FaxServer = Nothing
	    Try
		    wFaxServer = New FAXCOMEXLib.FaxServer
		    '���[�J���}�V�����g�p����ꍇ�� Nothing�łn�j
		    wFaxServer.Connect("10.10.15.141")
		
		    '�h�L�������g�쐬
		    Dim wFaxDocument As New FAXCOMEXLib.FaxDocument
		    With wFaxDocument
			    '���M��
			    .Recipients.Add("0,0333502160", "zbs")

			    '���M��
			    .CoverPageType = FAXCOMEXLib.FAX_COVERPAGE_TYPE_ENUM.fcptSERVER
			    '.CoverPage = "���.cov"
			    .Sender.FaxNumber = "0482282007"
			    .Sender.Name = "JA���񂵂�Z���^�["
			    .Subject = "FAX���M�e�X�g 20140805"
			    .Note = "�e�X�g"
			    .Body = "C:\FAXTEST.txt"
		    End With
		    '���M����
		    wFaxDocument.ConnectedSubmit(wFaxServer)
	    Catch ex As Exception
		    strJobNumber = ex.ToString
	    Finally
		    If wFaxServer IsNot Nothing Then
			    wFaxServer.Disconnect()
		    End If
	    End Try


    end if
%>

<script language="JavaScript">
<!--
    function fncSendFax() {
        //alert("hello");
        document.forms[0].hdnFaxSend.value = "1";
        document.forms[0].submit();
    }

-->
</script>
<html>
<head>
    <title>����FAX(1)</title>
    <meta http-equiv="Content-Type" content="text/html; charset=Shift_JIS">
    <meta http-equiv="Content-Script-Type" content="text/javascript">
    <meta http-equiv="Content-Style-Type" content="text/css">
    <style>
    body{
        font-family: "MS UI Gothic", "Meiryo UI", "MS Gothic";
        ##font-size:small;
    }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
JA-LP�Ď�CS�@����FAX���M�O�m�F�@01


<input type="button" name="btnFax" value="FAX" onClick="fncSendFax();">
<input type="hidden" name="hdnFaxSend" value="">
<input type="text" name="txtSendFaxServer" value="<%= pstrSendFaxServer %>">
<input type="button" name="btnSetFaxServer" value="��" onClick="document.forms[0].txtSendFaxServer.value='10.10.15.141';">
<input class="bt-JIK" id="btnExit" onclick="return btnExit_onclick();"	tabIndex="94" type="button" value="�I��" name="btnExit" runat="server" >
<%= now() %>
<hr>
<pre>
<%= strJobNumber %>
</pre>
<hr>
<pre>
<%= strResult %>
</pre>
<hr>
�y���l�z<br>

FAX�T�[�o�F<%= pstrSendFaxServer %><br>
���M�t�@�C���F<%= pstrDataFile %><br>
���M��F<%= pstrFaxNumber %><br>
USER:<%= System.Security.Principal.WindowsIdentity.GetCurrent().Name %>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>


