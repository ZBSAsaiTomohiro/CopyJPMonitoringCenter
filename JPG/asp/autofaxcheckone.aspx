<%@ Page aspcompat=true LANGUAGE="VBScript" CODEPAGE="932"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<!-- #include file ="autofaxcommon.aspx" -->
<script runat="server">
    '��`�A�錾'
    private Dim syono As String 
    private dim kanscdwhe as string 
    private dim kanscdlock as string 
    private Dim sql1 as String
    private Dim execflg as String
    private Dim reloadcnt as integer
    private dim ret as String
    private dim nowdt as String
    
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
    
    if request("execflg") <> "" then 
      execflg = request("execflg")
    else
      execflg = "0"
    end if
    if request("syono") <> "" then 
      syono = request("syono")
    else
      syono = "13002210969"
    end if
    
    
    '�����Ɋ�Â��Ď��Z���^�[�͈͂̏��̂ݕ\�����邽�߂̋K��
    if Request.Cookies("CENTCD").Value = "40000" then
        kanscdlock = "'32020','34020','36020','10001'"
    elseif Request.Cookies("CENTCD").Value = "10001" then
        kanscdlock = "'10001'"
    else
        kanscdlock = "'ERROR'"
    end if
    
    reloadcnt = request("reloadcnt")
    if IsDBNull(reloadcnt) = true then
        reloadcnt = 0
    else
        reloadcnt = reloadcnt + 1
    end if
    Dim dtmNow As DateTime
    dtmNow = DateTime.Now
    nowdt = dtmNow.ToString("yyyy/MM/dd HH:mm:ss")
%>
<html>
<head>
    <title>����FAX ����[<%= syono %>]</title>
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
    }
    .tdh2{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(153,255,153, 0.5)), to(#33CC00));
          background: -moz-linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
          background: -o-linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
          background: linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
        background-color: #33CC00;
    }
    .tdh3{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(255,255,255, 0.5)), to(#98f9f9));
          background: -moz-linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
          background: -o-linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
          background: linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
        background-color:#98f9f9;
        text-align:center;
    }
    .tdh4{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(255,255,255, 0.5)), to(#f9ca9a));
          background: -moz-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: -o-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
        background-color: #f9ca9a;
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
    .tdcout{
        text-align: center;
        background-color: #D3D3D3;
    }
    .tblwaku{
        text-align: left;
        vertical-align: top;
    }
    .tdwaku{
        text-align: left;
        vertical-align: top;
    }
    </style>
    <script language="JavaScript">
      function fncExecMakeDat(){
        document.forms[0].execflg.value = "1";
        document.forms[0].submit();
      }
      function fncReload(){
        document.forms[0].execflg.value = "0";
        document.forms[0].submit();
      }
    </script>
</head>
<body>
    <form runat="server">
�Ή��f�[�^[<%= syono %>](<%= nowdt %>����)
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
<%= kanscdwhe  %><br>
-->
&nbsp;&nbsp;
<input type="button" name="btnClose" id="btnClose" value="����" onClick="window.close();">
<a href="./autofaxcomp.pdf" target="_blank"><img src="./icon_pdf.gif" border="0" alt="��������" title="��������"></a>
<a href="./autofaxcomp.xls" target="_blank"><img src="./icon_xls.gif" border="0" alt="��������" title="��������"></a>
<input type="hidden" name="execflg" id="execflg" value="" size="10" maxlength="8">
<input type="hidden" name="reloadcnt" id="reloadcnt" value="<%= reloadcnt %>">
<hr>
<%
    
    sql1 = ""
    'sql1 = sql1 & "/* �Ή��f�[�^ */ " & vbcrlf
    sql1 = sql1 & "SELECT *" & vbcrlf
    sql1 = sql1 & "FROM D20_TAIOU " & vbcrlf
    sql1 = sql1 & "WHERE SYONO = '" & syono & "' " & vbcrlf
    sql1 = sql1 & "AND KANSCD IN (" & kanscdlock & ") " & vbcrlf
    
    'Response.Write("SQL=[" & sql1 & "]")
    'Response.End
    Dim ADO_Cnn
    Dim ADO_Rst
    Dim i as integer
    Dim f as integer
    Dim cnt as integer
    
    ADO_Cnn = server.CreateObject("ADODB.Connection")
    ADO_Rst = server.CreateObject("ADODB.Recordset")
    'ADO_Cnn.open("Driver={Microsoft ODBC for Oracle};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    'ADO_Cnn.open("Driver={Oracle in OraDB12Home1};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Cnn.open("Driver={Oracle in OraDB12Home1};DBQ=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Rst = ADO_Cnn.Execute(sql1)
    cnt = 0
    Response.Write("<table class='tblwaku'>")
    Response.Write("<tr>")
    Response.Write("<td class='tdwaku' border='0'>")
    
    Response.Write("<table class='tbl'>")
    Response.Write("<tr class='trh'>")
    Response.Write("<td class='tdh2'>��</td>")
    Response.Write("<td class='tdh2'>����</td>")
    Response.Write("<td class='tdh2'>���e</td>")
    Response.Write("</tr>")
    
    if ADO_Rst.EOF = False then
        for i = 0 to 79
            cnt = cnt + 1
            f = i mod 2
            Response.Write("<tr>" & vbcrlf)
            Response.Write("<td class='tdr" & f & "'>" & (i + 1)                    & "</td>" & vbcrlf)
            Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields(i).Name  & "</td>" & vbcrlf)
            Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields(i).Value & "</td>" & vbcrlf)
            Response.Write("</tr>" & vbcrlf)
        next
    end if
    Response.Write("</table>")
    Response.Write("</td>")
    Response.Write("<td class='tdwaku' border='0'>")
    Response.Write("&nbsp;&nbsp;")
    Response.Write("</td>")
    Response.Write("<td class='tdwaku' border='0'>")
    Response.Write("<table class='tbl'>")
    Response.Write("<tr class='trh'>")
    Response.Write("<td class='tdh2'>��</td>")
    Response.Write("<td class='tdh2'>����</td>")
    Response.Write("<td class='tdh2'>���e</td>")
    Response.Write("</tr>")
    if ADO_Rst.EOF = False then
        for i = 80 to 159
            cnt = cnt + 1
            f = i mod 2
            Response.Write("<tr>" & vbcrlf)
            Response.Write("<td class='tdr" & f & "'>" & (i + 1)                    & "</td>" & vbcrlf)
            Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields(i).Name  & "</td>" & vbcrlf)
            Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields(i).Value & "</td>" & vbcrlf)
            Response.Write("</tr>" & vbcrlf)
        next
    end if
    Response.Write("</table>")
    Response.Write("</td>")
    Response.Write("<td class='tdwaku' border='0'>")
    Response.Write("&nbsp;&nbsp;")
    Response.Write("</td>")
    Response.Write("<td class='tdwaku' border='0'>")
    Response.Write("<table class='tbl'>")
    Response.Write("<tr class='trh'>")
    Response.Write("<td class='tdh2'>��</td>")
    Response.Write("<td class='tdh2'>����</td>")
    Response.Write("<td class='tdh2'>���e</td>")
    Response.Write("</tr>")
    if ADO_Rst.EOF = False then
        for i = 160 to 220
            cnt = cnt + 1
            f = i mod 2
            Response.Write("<tr>" & vbcrlf)
            Response.Write("<td class='tdr" & f & "'>" & (i + 1)                    & "</td>" & vbcrlf)
            Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields(i).Name  & "</td>" & vbcrlf)
            Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields(i).Value & "</td>" & vbcrlf)
            Response.Write("</tr>" & vbcrlf)
        next
    end if
    Response.Write("</table>")
    Response.Write("</td>")
    Response.Write("</tr>")
    Response.Write("</table>")
    if cnt <= 0 then
        Response.Write("<br>�Y���f�[�^������܂���B<br><br>")
    end if
    
    ADO_Rst.Close                    '�I�u�W�F�N�g�J��
    ADO_Cnn.Close                    '�I�u�W�F�N�g�J��
    ADO_Rst = Nothing                '�I�u�W�F�N�g�J��
    ADO_Cnn = Nothing                  '�I�u�W�F�N�g�J��
    
    Response.Write("<!-- " & sql1 & " -->")
%>
<hr>
�y�����z<BR>
�E�Ή��f�[�^�e�[�u���̖��ׂ�\���B<BR>
<hr>
<BR>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>
