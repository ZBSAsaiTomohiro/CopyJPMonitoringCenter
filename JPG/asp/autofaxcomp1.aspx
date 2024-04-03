<!-- 
'*******************************************************************************
' PG     : autofaxcomp.aspx
' PG���� : ����FAX���M�O�m�F(���M�斈)
' �쐬�� : 2014/01/01 ZBS T.Watabe
'*******************************************************************************
' �X�V����
' 2014/04/16 T.Watabe �[�������M�t���O�̔�r�`�F�b�N���t��������B
' 2016/03/02 T.Ono    2015���P�J�� �Q�ƃ}�X�^�ύX�̂��߁A���l�Ȃǂ̕����ύX
' 2016/11/14 T.Ono ���M�ς݊m�F��ʂ̒ǉ��B�Ď�������10001���폜�B
!-->
<%@ Page aspcompat=true LANGUAGE="VBScript" CODEPAGE="932"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<!-- #include file ="autofaxcommon.aspx" -->
<script runat="server">
    '��`�A�錾'
    private Dim sendkbn As String
    private dim ymdfr as string
    private dim ymdto as string
    private dim kanscd as string 
    private dim kanscdwhe as string 
    private dim kanscdlock as string 
    private Dim sql1 as String
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
    
    '�����Ɋ�Â��Ď��Z���^�[�͈͂̏��̂ݕ\�����邽�߂̋K��
    if Request.Cookies("CENTCD").Value = "40000" then
        kanscdlock = "'32020','34020','36020','10001'"
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
    <title>����FAX(1)</title>
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
<!-- JA-LP�Ď�CS�@����FAX���M�O�m�F�@01 -->
JA-LP�Ď�CS�@FAX���M�m�F�@01
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
(1:���M�斈)
<a href="./autofaxcomp2.aspx" target="_blank">(2:����)</a>
<a href="./autofaxmakedat.aspx" target="_blank">(3:�f�[�^�쐬)</a>
<a href="./autofaxcomp4.aspx" target="_blank">(4:���M���ʊm�F)</a>
<a href="./autofaxcomp.pdf" target="_blank"><img src="./icon_pdf.gif" border="0" alt="��������" title="��������"></a>
<a href="./autofaxcomp.xls" target="_blank"><img src="./icon_xls.gif" border="0" alt="��������" title="��������"></a>
<hr>
&nbsp;���M�P�ʁF<SELECT name="sendkbn">
<%
dim wk as string
    if sendkbn = "1" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='1'" & wk & ">1:JA/�̔���</option>")
    if sendkbn = "2" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='2'" & wk & ">2:�ײ���</option>")
%>
</SELECT>
&nbsp;�Ď������F<SELECT name="kanscd">
<%
if Request.Cookies("CENTCD").Value = "40000" then
    if kanscd = "40000" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='40000'" & wk & ">40000:�R�Ď��S��</option>")
    if kanscd = "32020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='32020'" & wk & ">32020</option>")
    if kanscd = "34020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='34020'" & wk & ">34020</option>")
    if kanscd = "36020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='36020'" & wk & ">36020</option>")
    '2016/12/21 T.Ono del 2016���P�J�� ��12 ����͕\�����Ȃ��悤�ɂ���B
    '(���̂ق���10001�œ����Ă����Ƃ��̕���͂��̂܂܂ɂ��Ă���)
    'Response.Write("<option value=''" & wk & ">--------</option>")
    'if kanscd = "10001" then wk = "SELECTED" else wk = ""
    'Response.Write("<option value='10001'" & wk & ">10001:����</option>")
elseif Request.Cookies("CENTCD").Value = "10001" then
    Response.Write("<option value='10001' SELECTED>10001:����</option>")
else
end if
%>
</SELECT>
&nbsp;�Ώۓ��F<input type="text" name="ymd" value="<%= ymdto %>" size="10" maxlength="8" onKeyDown="fncEasyDateChg(this,'d');" autocomplete="off">
<input type="submit" value="����" name="btnSearch">
<hr>
<%
    'SQL�擾 ���ʒ�`[autofaxcommon.aspx]
    sql1 = getCompSQL4FaxNo("1", ymdto, kanscdwhe, kanscdlock, sendkbn)
    
    Dim ADO_Cnn
    Dim ADO_Rst
    Dim i as integer
    Dim f as integer
    
    'DEBUG�p
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
    Response.Write("<td colspan=8 class='tdh2'>���M�Ώۃ��X�g</td>")
    Response.Write("<td rowspan=2 class='tdh4'>��v</td>")
    Response.Write("<td colspan=5 class='tdh3'>����FAX���s����</td>")
    Response.Write("</tr>")
    Response.Write("<tr>")
    'Response.Write("<td class='tdh1'>��</td>")
    Response.Write("<td class='tdh2'>����</td>")
    Response.Write("<td class='tdh2'>��</td>")
    Response.Write("<td class='tdh2'>FAX/Ұ�</td>")
    'Response.Write("<td class='tdh2'>���M��JA��(FAX�ԍ�����Ͻ��ɊY����������)</td>") 2016/02/24 T.Ono mod 2015���P�J��
    Response.Write("<td class='tdh2'>����FAX���M��(FAX�ԍ�����Ͻ��ɊY����������)</td>")
    Response.Write("<td class='tdh2'>��<br>��</td>")
    Response.Write("<td class='tdh2'>��<br>��</td>")
    Response.Write("<td class='tdh2'>0��<br>���M</td>") ' 2014/04/16 T.Watabe add
    Response.Write("<td class='tdh2'>�Y��Ͻ�</td>")
    Response.Write("<td class='tdh3'>����</td>")
    Response.Write("<td class='tdh3'>��</td>")
    Response.Write("<td class='tdh3'>FAX/Ұ�</td>")
    Response.Write("<td class='tdh3'>��<br>��</td>")
    Response.Write("<td class='tdh3'>0��<br>���M</td>")
    'Response.Write("<td class='tdh4'>��v</td>")
    Response.Write("</tr>")
    
    Dim cnt as integer
    cnt = 0
    Do Until ADO_Rst.EOF = True
        i = i + 1
        cnt = cnt + 1
        f = i mod 2
        if ADO_Rst.Fields("COMP").Value = "��" then wk = " style='background-color:#98f9f9;'" else wk = " style='background-color:pink;'"
        Response.Write("<tr>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & i                                            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("TAIOU_KANSCD").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("TAIOU_KURACD").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("AUTO_FAXNO").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("AUTO_JANM").Value              & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("SEND_CNT").Value               & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("ALL_CNT").Value               & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'>" & ADO_Rst.Fields("AUTO_ZERO_FLG").Value & "</td>" & vbcrlf) ' 2014/04/16 T.Watabe add
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("AUTO_CHOICE").Value       & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'" & wk & ">" & ADO_Rst.Fields("COMP").Value              & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("LOG_KANSCD").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("LOG_KURACD").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("LOG_AUTO_FAXNO").Value    & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("LOG_CNT").Value           & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'>" & ADO_Rst.Fields("LOG_AUTO_ZERO_FLG").Value & "</td>" & vbcrlf)
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
<div class='comment'>�O��AM5:00����w���AM5:00�܂�</div><br>
<!-- 2016/03/02 T.Ono mod 2015���P�J�� 
�����M�Ώۃ��X�g�E�E�E�O��am5:00����w���am5:00�܂ł�24H�̑Ή��f�[�^����ɁAJA�S����Ͻ����Q�Ƃ��Ċ���o�������M��ꗗ�B�[�������M�ɂ��ẮAJA�S����Ͻ�����ɂ���K�v�����邽�ߊ܂߂Ă��܂���B
������FAX���s���ʁE�E�E���ۂɎ���FAX�����s����̧�ق𐶐�����ۂ�DB�֏o�͂���郍�O����ɁAFAX�ԍ��ŏW�񂵂��ꗗ�B�f�o�b�O���[�h�Ŏ��s���邱�Ƃɂ��A���M�����Ƀ��O�o�͉\�B<br>
���Y��Ͻ��E�E�EJA�S����Ͻ��o�^���������ŊY���������x����\�� �i1:�ڋq�w��/2:�ڋq�͈�/3:JA�x��/4:JA�j<br>
�����M�於�E�E�E�ꗗ�ɂȂ���FAX�ԍ�����JA�S����Ͻ����ēx�����Ȃ����ĕ\���������́B����FAX�ԍ��ňႤ���̂�o�^���Ă��܂����ꍇ�́A�z��ǂ���\������Ȃ��ꍇ������܂��B<br>
����v�E�E�E�d�b�ԍ��ƌ�������v���Ă��邩����B�[�������M�̏ꍇ�̂ݑ��M�Ώۃ��X�g�͑��݂����B�i��:��v/�~:�s��v�j<br> -->
�����M�Ώۃ��X�g�E�E�E�O��am5:00����w���am5:00�܂ł�24H�̑Ή��f�[�^����ɁAJA�S���ҁE�񍐐�E���ӎ���Ͻ����Q�Ƃ��Ċ���o�������M��ꗗ�B<br>
������FAX���s���ʁE�E�E���ۂɎ���FAX�����s����̧�ق𐶐�����ۂ�DB�֏o�͂���郍�O����ɁAFAX�ԍ��ŏW�񂵂��ꗗ�B�f�o�b�O���[�h�Ŏ��s���邱�Ƃɂ��A���M�����Ƀ��O�o�͉\�B<br>
���Y��Ͻ��E�E�EJA�S���ҁE�񍐐�E���ӎ���Ͻ��o�^���������ŊY���������x����\�� �i1:�ڋq�w��/2:�ڋq�͈�/3:JA�x���j<br>
������FAX���M���E�E�E�ꗗ�ɂȂ���FAX�ԍ�����JA�S���ҁE�񍐐�E���ӎ���Ͻ����ēx�����Ȃ����ĕ\���������́B����FAX�ԍ��ňႤ���̂�o�^���Ă��܂����ꍇ�́A�z��ǂ���\������Ȃ��ꍇ������܂��B<br>
����v�E�E�E�d�b�ԍ��ƌ�������v���Ă��邩����B�i��:��v/�~:�s��v�j<br>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>
