<!-- 
'*******************************************************************************
' PG     : autofaxcomp4.aspx
' PG���� : FAX���M�m�F(4:���M���ʊm�F)
' �쐬�� : 2016/11/14 ZBS T.Ono
'*******************************************************************************
' �X�V����
' 
!-->
<%@ Page aspcompat=true LANGUAGE="VBScript" CODEPAGE="932"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<!-- #include file ="autofaxcomp4sql.aspx" -->
<script runat="server">
    '��`�A�錾'
    private Dim sendkbn As String
    private dim ymdfr as string
    private dim ymdto as string
    private dim kanscd as string 
    private dim kanscdwhe as string 
    private dim kanscdlock as string 
    private Dim faxtype as String
    private Dim faxtype0 as String
    private Dim faxtype1 as String
    private Dim faxtype2 as String
    private Dim faxmatch as String
    private Dim faxmatch0 as String
    private Dim faxmatch1 as String
    private Dim faxmatch2 as String
    private Dim sql1 as String
    private Dim sql2 as String
</script>
<%
    
    '�L���b�V�����Z�L�����e�B�[��A���p�s�ɂ���B
    Response.Buffer = True
    Response.CacheControl = "no-cache"
    Response.AddHeader("Pragma", "no-cache")
    Response.Expires = -1 
    Response.Cookies("SESSION").Expires = datetime.today.adddays(1)
    
    '�s���J�ږh�~�[�u
    try
        if request.cookies("SSO_CHECK").value = "OK" then
            response.cookies("SESSION").value = session.sessionID ' �{���̃Z�b�V����ID�ɒu�������B
        elseif request.cookies("SESSION").value <> session.sessionID then
            response.redirect("../autofaxcheck.aspx") '�F�؏�����
        end if
        if request.cookies("userid").value = "" then '���[�UID���Ȃ��ꍇ�͔F�؏�����
            response.redirect("../autofaxcheck.aspx")
        elseif request.cookies("CENTCD").value = "" then '�Ď��Z���^�[�R�[�h���Ȃ��ꍇ�͔F�؏�����
            response.redirect("../autofaxcheck.aspx")
        end if
    catch ex as System.NullReferenceException
        response.redirect("../autofaxcheck.aspx") '�F�؏�����
    end try
    
    dim dt as datetime
    dim ss as string
    
    ymdfr = ""
    ymdto = ""
    if request("ymd") <> "" then 
        if request("ymd").length <> 8 then
            '�G���[
        else
            ss = request("ymd").substring(0,4) & "/" & request("ymd").substring(4,2) & "/" & request("ymd").substring(6,2)
            If DateTime.TryParse(ss, dt) Then
              'ok
              ymdfr = dt.addDays(-1).ToString("yyyyMMdd")
              ymdto = request("ymd")
            else
              '�G���[
            end if
        end if
    end if
    if ymdto = "" then
        '���w��A�G���[���������́A�{�����t���x�[�X�Ɏw��
        ymdfr = DateTime.Today.addDays(-1).ToString("yyyyMMdd")
        ymdto = DateTime.Today.ToString("yyyyMMdd")
    end if
    
    
    if request("kanscd") <> "" then 
        kanscd = request("kanscd")
    else
        '��̏ꍇ
        if Request.Cookies("CENTCD").Value = "40000" then
            kanscd = "40000"
        elseif Request.Cookies("CENTCD").Value = "10001" then
            kanscd = "10001"
        else
            kanscd = ""
        end if
    end if
    if kanscd = "40000" then
        kanscdwhe = "'32020','34020','36020'"
    else
        kanscdwhe = "'" & kanscd & "'"
    end if
    
    '��ʃ��W�I�{�^��
    if request("faxtype") = "1" then
        '����FAX
        faxtype0 = ""
        faxtype1 = "checked"
        faxtype2 = ""
        faxtype  = "1"
    elseif request("faxtype") = "2" then
        '�ݐ�FAX
        faxtype0 = ""
        faxtype1 = ""
        faxtype2 = "checked"
        faxtype  = "2"
    else
        '�S��(�����l)
        faxtype0 = "checked"
        faxtype1 = ""
        faxtype2 = ""
        faxtype  = "0"
    end if
    
     '��v���W�I�{�^��
    if request("faxmatch") = "0" then
        '�S��
        faxmatch0 = "checked"
        faxmatch1 = ""
        faxmatch2 = ""
        faxmatch  = "0"
    elseif request("faxmatch") = "1" then
        'OK
        faxmatch0 = ""
        faxmatch1 = "checked"
        faxmatch2 = ""
        faxmatch  = "1"
    else
        'NG(�����l)
        faxmatch0 = ""
        faxmatch1 = ""
        faxmatch2 = "checked"
        faxmatch  = "2"
    end if

    
    '�����Ɋ�Â��Ď��Z���^�[�͈͂̏��̂ݕ\�����邽�߂̋K��
    if Request.Cookies("CENTCD").Value = "40000" then
        'kanscdlock = "'32020','34020','36020','10001'"
        kanscdlock = "1" '����Ď��Z���^�[�ł��邱�Ƃ��킩���OK�Ȃ̂Ńt���O�ɂ���B
    elseif Request.Cookies("CENTCD").Value = "10001" then
        kanscdlock = "'10001'"
    else
        kanscdlock = "'ERROR'"
    end if
    '���M�敪�@1:�̔���JA/2:�ײ���
    if request("sendkbn") <> "" then 
        sendkbn = request("sendkbn")
    else
        sendkbn = "1"
    end if
%>
<html>
<head>
    <title>����FAX(4)</title>
    <meta http-equiv="Content-Type" content="text/html; charset=Shift_JIS">
    <meta http-equiv="Content-Script-Type" content="text/javascript">
    <meta http-equiv="Content-Style-Type" content="text/css">
    <script src="./autofax.js"></script>
    <style>
    body{
        font-family: "MS UI Gothic", "Meiryo UI", "MS Gothic";
        ##font-size:small;
    }
    .tbl{
        border-collapse: collapse; /* �g���̕\�����@ */ 
        border: 1px #1C79C6 solid; /* �e�[�u���S�̘̂g���i�����E�F�E�X�^�C���j */ 
    }
    .tbl td{
        border: 1px #1C79C6 solid; /* �Z���̘g���i�����E�F�E�X�^�C���j */ 
    }
    .comment{
        font-size:small;
        color:purple;
        display: inline-block; _display: inline;
    }
    .trh{}
    .tdh1{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(255,255,255, 0.5)), to(#f9ca9a));
          background: -moz-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: -o-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
        background-color: #f9ca9a;
        text-align: center;
    }
    .tdh2{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(153,255,153, 0.5)), to(#33CC00));
          background: -moz-linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
          background: -o-linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
          background: linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
        background-color: #33CC00;
        text-align: center;
    }
    .tdh3{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(255,255,255, 0.5)), to(#98f9f9));
          background: -moz-linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
          background: -o-linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
          background: linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
        background-color:#98f9f9;
        text-align: center;
    }
    .tdh4{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(255,255,255, 0.5)), to(#f9ca9a));
          background: -moz-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: -o-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
        background-color: #f9ca9a;
        text-align: center;
    }
    .tdl0{
        text-align: left;
        background-color: #CCFFCC;
    }
    .tdr0{
        text-align: right;
        background-color: #CCFFCC;
    }
    .tdc0{
        text-align: center;
        background-color: #CCFFCC;
    }
    .tdl1{
        text-align: left;
        background-color: white;
    }
    .tdr1{
        text-align: right;
        background-color: white;
    }
    .tdc1{
        text-align: center;
        background-color: white;
    }
    </style>
</head>
<body>
    <form runat="server">
JA-LP�Ď�CS�@FAX���M�m�F�@04
�y<%= Request.Cookies("IP").Value %>, 
<%= Request.Cookies("USERNAME").Value %>, 
<%= Request.Cookies("CENTCD").Value %>,
<%= SID %>�z
<!-- 
<%= Request.Cookies("userid").Value  %><br>
<%= Request.Cookies("usernm").Value  %><br>
<%= Request.Cookies("PCNAME").Value  %><br>
<%= Request.Cookies("AD_CN").Value  %><br>
<%= Request.Cookies("AUTH_KBN").Value  %><br>
<%= ymdfr %><br>
<%= ymdto  %><br>
<%= kanscd  %><br>
<%= kanscdwhe  %><br>
-->
&nbsp;&nbsp;
<a href="./autofaxcomp0.aspx" target="_blank">(0:�S�̊m�F)</a>
<a href="./autofaxcomp1.aspx" target="_blank">(1:���M�斈)</a>
<a href="./autofaxcomp2.aspx" target="_blank">(2:����)</a>
<a href="./autofaxmakedat.aspx" target="_blank">(3:�f�[�^�쐬)</a>
(4:���M���ʊm�F)
<a href="./autofaxcomp.pdf" target="_blank"><img src="./icon_pdf.gif" border="0" alt="��������" title="��������"></a>
<a href="./autofaxcomp.xls" target="_blank"><img src="./icon_xls.gif" border="0" alt="��������" title="��������"></a>
<hr>
&nbsp;�Ď������F<SELECT name="kanscd">
<%
dim wk as string
if Request.Cookies("CENTCD").Value = "40000" then
    if kanscd = "40000" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='40000'" & wk & ">40000:�R�Ď��S��</option>")
    if kanscd = "32020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='32020'" & wk & ">32020</option>")
    if kanscd = "34020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='34020'" & wk & ">34020</option>")
    if kanscd = "36020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='36020'" & wk & ">36020</option>")
elseif Request.Cookies("CENTCD").Value = "10001" then
    Response.Write("<option value='10001' SELECTED>10001:����</option>")
else
end if
%>
</SELECT>
&nbsp;���M���F<input type="text" name="ymd" value="<%= ymdto %>" size="10" maxlength="8" onKeyDown="fncEasyDateChg(this,'d');" autocomplete="off">
(��ʁF
<input type="radio" name="faxtype" value="0" <%= faxtype0 %> />�S��&nbsp;
<input type="radio" name="faxtype" value="1" <%= faxtype1 %> />����FAX&nbsp;
<input type="radio" name="faxtype" value="2" <%= faxtype2 %> />�ݐ�FAX
(�󔒂͏�ɕ\��))&nbsp;
(��v�F
<input type="radio" name="faxmatch" value="0" <%= faxmatch0 %> />�S��&nbsp;
<input type="radio" name="faxmatch" value="1" <%= faxmatch1 %> />OK&nbsp;
<input type="radio" name="faxmatch" value="2" <%= faxmatch2 %> />NG
)&nbsp;


<input type="submit" value="����" name="btnSearch">
<hr>
<%
    'SQL�擾 ���M���ʊm�F��p[autofaxcomp4sql.aspx]
    sql2 = getcount(ymdto)
    
    Dim ADO_Cnn2
    Dim ADO_Rst2
    Dim i2 as integer
    Dim f2 as integer
    
    'DEBUG�p
    'Response.Write("faxtypeL=[" & ymdto & ":" & kanscdwhe & ":" & kanscdlock & ":" & sendkbn & ":" & faxtype & ":" & faxmatch & "]")
    'Response.Write("SQL=[" & sql1 & "]")
    'Response.End


    ADO_Cnn2 = server.CreateObject("ADODB.Connection")
    ADO_Rst2 = server.CreateObject("ADODB.Recordset")
    'ADO_Cnn2.open("Driver={Microsoft ODBC for Oracle};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    'ADO_Cnn2.open("Driver={Oracle in OraDB12Home1};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Cnn2.open("Driver={Oracle in OraDB12Home1};DBQ=" & SID & "; UID=KANSHI; PWD=KANSHI0;")

    ADO_Rst2 = ADO_Cnn2.Execute(sql2)

    i2 = 0
    Response.Write("<table class='tbl'>")
    Response.Write("<tr class='trh'>")
    Response.Write("<td class='tdh1'>���</td>")
    Response.Write("<td class='tdh3'>FAX���s����</td>")
    Response.Write("<td class='tdh2'>FAX���M���O<br>�i����܂ށj</td>")
    Response.Write("<td class='tdh4'>��v</td>")
    Response.Write("</tr>")

    
    Dim cnt2 as integer
    cnt2 = 0
    Do Until ADO_Rst2.EOF = True
        i2 = i2 + 1
        cnt2 = cnt2 + 1
        f2 = i2 mod 2
        if ADO_Rst2.Fields("RES").Value = "��" then wk = " style='background-color:#98f9f9;'" else wk = " style='background-color:pink;'"
        Response.Write("<tr>" & vbcrlf)
        Response.Write("<td class='tdr" & f2 & "'>" & ADO_Rst2.Fields("FAX_TYPE").Value                                            & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f2 & "'>" & ADO_Rst2.Fields("AUTO_FAXCNT").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f2 & "'>" & ADO_Rst2.Fields("FAXLOGCONT").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f2 & "'" & wk & ">" & ADO_Rst2.Fields("RES").Value              & "</td>" & vbcrlf)
        Response.Write("</tr>" & vbcrlf)
        ADO_Rst2.MoveNext
    Loop
    
    Response.Write("</table>")
    
    
    if cnt2 <= 0 then
        Response.Write("<br>�Y���f�[�^������܂���B<br><br>")
    end if
    
    ADO_Rst2.Close                    '�I�u�W�F�N�g�J��
    ADO_Cnn2.Close                    '�I�u�W�F�N�g�J��
    ADO_Rst2 = Nothing                 '�I�u�W�F�N�g�J��
    ADO_Cnn2 = Nothing                '�I�u�W�F�N�g�J��
    
    Response.Write("<!-- " & sql2 & " -->")
%>
�y���l�z<br>
���ݐϏ�񎩓�FAX�A����FAX�����s���Đ����������M������FAX���M���O�̑��M������r�B<br>
�@��v���Ȃ��ꍇ�A�ݐρE����FAX�����s���������M����Ă��Ȃ��B�܂��́A�V�X�e�������s���Ă��Ȃ������M���ꂽ�\��������B<br>
����L�A�u�Ď������v�u��ʁv�u��v�v�̍i�荞�ݏ����͓K�p����Ȃ��B
<hr>
<%
    'SQL�擾 ���M���ʊm�F��p[autofaxcomp4sql.aspx]
    sql1 = getlist(ymdto, kanscdwhe, kanscdlock, sendkbn, faxtype, faxmatch)
    
    Dim ADO_Cnn
    Dim ADO_Rst
    Dim i as integer
    Dim f as integer
    
    'DEBUG�p
    'Response.Write("faxtypeL=[" & ymdto & ":" & kanscdwhe & ":" & kanscdlock & ":" & sendkbn & ":" & faxtype & ":" & faxmatch & "]")
    'Response.Write("SQL=[" & sql1 & "]")
    'Response.End


    ADO_Cnn = server.CreateObject("ADODB.Connection")
    ADO_Rst = server.CreateObject("ADODB.Recordset")
    'ADO_Cnn.open("Driver={Microsoft ODBC for Oracle};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    'ADO_Cnn.open("Driver={Oracle in OraDB12Home1};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Cnn.open("Driver={Oracle in OraDB12Home1};DBQ=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Rst = ADO_Cnn.Execute(sql1)

    i = 0
    Response.Write("<table class='tbl'>")
    Response.Write("<tr class='trh'>")
    Response.Write("<td rowspan=2 class='tdh1'>��</td>")
    Response.Write("<td colspan=6 class='tdh3'>FAX���s����</td>")
    Response.Write("<td rowspan=2 class='tdh4'>��v</td>")
    Response.Write("<td colspan=5 class='tdh2'>FAX���M���O</td>")
    Response.Write("</tr>")
    Response.Write("<tr>")
    Response.Write("<td class='tdh3'>���</td>")
    Response.Write("<td class='tdh3'>����</td>")
    Response.Write("<td class='tdh3'>��</td>")
    Response.Write("<td class='tdh3'>FAX�ԍ�</td>")
    Response.Write("<td class='tdh3'>����</td>")
    Response.Write("<td class='tdh3'>0��<br>���M</td>")
    Response.Write("<td class='tdh2'>�X�e�[�^�X</td>")
    Response.Write("<td class='tdh2'>����</td>")
    Response.Write("<td class='tdh2'>FAX�ԍ�</td>")
    Response.Write("<td class='tdh2'>����</td>")
    Response.Write("<td class='tdh2'>�^�C�g��</td>")
    Response.Write("</tr>")
    
    Dim cnt as integer
    cnt = 0
    Do Until ADO_Rst.EOF = True
        i = i + 1
        cnt = cnt + 1
        f = i mod 2
        if ADO_Rst.Fields("RES").Value = "��" then wk = " style='background-color:#98f9f9;'" else wk = " style='background-color:pink;'"
        Response.Write("<tr>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & i                                            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("FAXTYPE").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("KANSCD").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("KURACD").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("AUTO_FAXNO").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("PAGE").Value              & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("ZERO_FLG").Value               & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'" & wk & ">" & ADO_Rst.Fields("RES").Value              & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("STATUS").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("STARTTIME").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("RECIPIENTFAXNUMBER").Value    & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("TOTALPAGES").Value           & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("DOCUMENT").Value & "</td>" & vbcrlf)
        Response.Write("</tr>" & vbcrlf)
        ADO_Rst.MoveNext
    Loop
    Response.Write("</table>")
    
    if cnt <= 0 then
        Response.Write("<br>�Y���f�[�^������܂���B<br><br>")
    end if
    
    ADO_Rst.Close                    '�I�u�W�F�N�g�J��
    ADO_Cnn.Close                    '�I�u�W�F�N�g�J��
    ADO_Rst = Nothing                 '�I�u�W�F�N�g�J��
    ADO_Cnn = Nothing                '�I�u�W�F�N�g�J��
    
    Response.Write("<!-- " & sql1 & " -->")
    
%>
<hr>
�y���l�z<br>
��FAX���s���ʁE�E�E�ݐϏ�񎩓�FAX�A����FAX�����s���ăt�@�C���𐶐�����ۂ�DB�֏o�͂���郍�O����ɁAFAX�ԍ��ŏW�v�����ꗗ�B����FAX�f�o�b�O���[�h�Ŏ��s�������ʂ͊܂܂Ȃ��B<br>
��FAX���M���O�E�E�EFAX�T�[�o�[(141)��FAX���M���O(OutBoxLog.txt)��DB�Ɏ捞�ݕ\���������́B<br>
����v�E�E�E��ʁg���ׁh�g��JA�h�͓d�b�ԍ��ƌ�������v���Ă��邩����B��ʁF�݂͓d�b�ԍ��̈�v�A�X�e�[�^�X�g�����h�ł��邩����B�i��:��v/�~:�s��v�j<br>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>
