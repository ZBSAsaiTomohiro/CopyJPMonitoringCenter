<!-- 
'*******************************************************************************
' PG     : autofaxmakedat.aspx
' PG���� : ����FAX���M�O�m�F(���M�Ώۃ��X�g�쐬)
' �쐬�� : 2014/01/01 ZBS T.Watabe
'*******************************************************************************
' 2016/11/14 T.Ono ���M�ς݊m�F��ʂ̒ǉ�
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
    private Dim taiocntkbn as String
    private Dim faxkbn1 as String
    private Dim faxkbn2 as String
    private Dim compng as String
    private Dim execflg as String
    private Dim reloadcnt as integer
    private dim ret as String
    
    Public Const ORADB_DEFAULT   = &H0
    Public Const ORASQL_DEFAULT     = &H0
    Public Const ORASQL_NO_AUTOBIND = &H1
    Public Const ORASQL_FAILEXEC    = &H2
    Public Const ORAPARM_INPUT    = 1
    Public Const ORAPARM_OUTPUT   = 2
    Public Const ORAPARM_BOTH     = 3
    Public Const ORATYPE_VARCHAR2 = 1
    Public Const ORATYPE_NUMBER   = 2
    Public Const ORATYPE_SINT     = 3
    Public Const ORATYPE_FLOAT    = 4
    Public Const ORATYPE_STRING   = 5
    Public Const ORATYPE_VARCHAR  = 9
    Public Const ORATYPE_DATE     = 12
    Public Const ORATYPE_UINT     = 68
    Public Const ORATYPE_CHAR     = 96
    Public Const ORATYPE_CHARZ    = 97
    Public Const ORATYPE_CURSOR   = 102
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
    
    reloadcnt = request("reloadcnt")
    if IsDBNull(reloadcnt) = true then
        reloadcnt = 0
    else
        reloadcnt = reloadcnt + 1
    end if
    
    if request("kanscd") = "" then  '����A�N�Z�X��
        faxkbn2 = "checked"
    else
        taiocntkbn = request("taiocntkbn") '�Ή��f�[�^�J�E���g�敪(�`�F�b�N�{�b�N�X)
        faxkbn1 = request("faxkbn1")
        faxkbn2 = request("faxkbn2")
        compng = request("compng")
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
    <title>����FAX �쐬</title>
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
    </style>
    <script language="JavaScript">
      function fncExecMakeDat(){
        if(!confirm("�f�[�^���쐬���Ă�낵���ł����H")){
          return false;
        }
        document.forms[0].btnExecMakeDat.disabled = true;
        document.forms[0].btnReload.disabled = true;
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
<!-- JA-LP�Ď�CS�@����FAX���M�O�m�F ���M�Ώۃ��X�g�쐬 -->
JA-LP�Ď�CS�@FAX���M�m�F ���M�Ώۃ��X�g�쐬
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
(3:�f�[�^�쐬)
<a href="./autofaxcomp4.aspx" target="_blank">(4:���M���ʊm�F)</a>
<a href="./autofaxcomp.pdf" target="_blank"><img src="./icon_pdf.gif" border="0" alt="��������" title="��������"></a>
<a href="./autofaxcomp.xls" target="_blank"><img src="./icon_xls.gif" border="0" alt="��������" title="��������"></a>
<input type="hidden" name="execflg" id="execflg" value="" size="10" maxlength="8"><BR>
<input type="hidden" name="reloadcnt" id="reloadcnt" value="<%= reloadcnt %>">
<hr>
<%
if Request.Cookies("CENTCD").Value = "40000" then
%>
&nbsp;�Ώۓ��F<input type="text" name="ymd" value="<%= ymdto %>" size="10" maxlength="8" onKeyDown="fncEasyDateChg(this,'d');" autocomplete="off">
<input type="button" value="�f�[�^�쐬" name="btnExecMakeDat" onClick="fncExecMakeDat();">
<hr>
�y�����z<BR>
&nbsp;&nbsp;�E���M�Ώۃ��X�g�͓����Ŏ����쐬����܂��BAM5:13���B<BR>
&nbsp;&nbsp;�E�ォ��Ή��f�[�^��ύX�������̂𔽉f�����邽�߂ɓ��@�\���g�p����B<BR>
<!-- 2016/03/02 T.Ono mod 2015���P�J�� &nbsp;&nbsp;�E�ނ�݂ɉߋ��̑��M�Ώۃ��X�g���č쐬����ƁAJA�S���҃}�X�^���̐ݒ肪�ς���Ă��邽�߂�<BR> -->
&nbsp;&nbsp;�E�ނ�݂ɉߋ��̑��M�Ώۃ��X�g���č쐬����ƁAJA�S���ҁE�񍐐�E���ӎ����}�X�^���̐ݒ肪�ς���Ă��邽�߂�<BR>
&nbsp;&nbsp;  �������̖����f�[�^�u�~�v���N����\��������܂��B<BR>
�y���l�z<br>
&nbsp;&nbsp;<div class='comment'>�O��AM5:00����w���AM5:00�܂łɑΉ��������Ă���f�[�^</div><br>
&nbsp;&nbsp;���u�f�[�^�쐬�v�{�^���ɂ��A�_���I�Ɋ���o�����m���M�Ώۃ��X�g�n���쐬�B<br>
<!-- 2016/03/02 T.Ono mod 2015���P�J�� &nbsp;&nbsp;���u�Ή��f�[�^�v�����ɁA�uJA�S���҃}�X�^�v�A�uJA�S���҃}�X�^2�v���g�p���ăf�[�^�쐬�B<br>
&nbsp;&nbsp;&nbsp;&nbsp;�@�u�Ή��f�[�^�v�E�E�E���X���͂����Ή����̓f�[�^�B���ԓ��ɑΉ����������f�[�^������FAX���M�ΏۂƂȂ�B<br>
&nbsp;&nbsp;&nbsp;&nbsp;�A�uJA�S���҃}�X�^�v�E�E�E�i�`����тi�`�x���P�ʂ̏o�͏�����FAX�ԍ��EҰٱ��ڽ���i�[<br>
&nbsp;&nbsp;&nbsp;&nbsp;�B�uJA�S���҃}�X�^2�v�E�E�E�ڋq�ԍ��P��w�肨��є͈͎w��̏o�͏�����FAX�ԍ��EҰٱ��ڽ���i�[<br> -->
&nbsp;&nbsp;���u�Ή��f�[�^�v�����ɁA�uJA�O���[�v�쐬�}�X�^�v�uJA�S���ҁE�񍐐�E���ӎ����}�X�^�v���g�p���ăf�[�^�쐬�B<br>
&nbsp;&nbsp;&nbsp;&nbsp;�@�u�Ή��f�[�^�v�E�E�E���X���͂����Ή����̓f�[�^�B���ԓ��ɑΉ����������f�[�^������FAX���M�ΏۂƂȂ�B<br>
&nbsp;&nbsp;&nbsp;&nbsp;�A�uJA�O���[�v�쐬�}�X�^�v�E�E�E�i�`�x���P�ʁA�ڋq�ԍ��P��w�肨��є͈͎w��ƁuJA�S���ҁE�񍐐�E���ӎ����}�X�^�v�̃O���[�v�̕R�t�����i�[�B<br>
&nbsp;&nbsp;&nbsp;&nbsp;�B�uJA�S���ҁE�񍐐�E���ӎ����}�X�^�v�E�E�E�O���[�v���̏o�͏�����FAX�ԍ��EҰٱ��ڽ���i�[�B<br>
<hr>
<%
  if execflg = "1" then
    sql1 = ""
    'sql1 = sql1 & "/* �f�[�^�쐬���s�I */ " & vbcrlf
    'sql1 = sql1 & "VARIABLE SS VARCHAR2;" & vbcrlf
    'sql1 = sql1 & "CALL FNC_MAKE_S06AUTOFAXTAIDB('" & ymdto & "', '" & Request.Cookies("IP").Value & "', '" & Request.Cookies("userid").Value & "') INTO :SS;" & vbcrlf
    'sql1 = sql1 & "Begin VARIABLE SS VARCHAR2; KANSHI.FNC_MAKE_S06AUTOFAXTAIDB('" & ymdto & "', '" & Request.Cookies("IP").Value & "', '" & Request.Cookies("userid").Value & "') INTO :SS; end;" & vbcrlf
    'sql1 = sql1 & "declare ret varchar2(2000); Begin ret := KANSHI.FNC_MAKE_S06AUTOFAXTAIDB('" & ymdto & "', '" & Request.Cookies("IP").Value & "', '" & Request.Cookies("userid").Value & "'); DBMS_OUTPUT.PUT_LINE(ret); end;" & vbcrlf
    'sql1 = sql1 & "Begin :ret := KANSHI.FNC_MAKE_S06AUTOFAXTAIDB('" & ymdto & "', '" & Request.Cookies("IP").Value & "', '" & Request.Cookies("userid").Value & "'); end;" & vbcrlf
    'sql1 = sql1 & "declare ret varchar2(2000); Begin ret := KANSHI.FNC_MAKE_S06AUTOFAXTAIDB('" & ymdto & "', '" & Request.Cookies("IP").Value & "', '" & Request.Cookies("userid").Value & "'); DBMS_OUTPUT.PUT_LINE(ret); end;" & vbcrlf
    sql1 = sql1 & "KANSHI.AUTOFAXCOMP_CRT('" & ymdto & "', '" & Request.Cookies("IP").Value & "', '" & Request.Cookies("userid").Value & "');" & vbcrlf
    'Response.Write("SQL=[" & sql1 & "]")
    'Response.End

    Dim ADO_Cnn
    Dim ADO_Cmd
    Dim i as integer
    Dim f as integer
    Dim rtn

    ADO_Cnn = server.CreateObject("ADODB.Connection")
    ADO_Cmd = server.CreateObject("ADODB.Command")
    'ADO_Cnn.open("Driver={Microsoft ODBC for Oracle};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    'ADO_Cnn.open("Driver={Oracle in OraDB12Home1};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Cnn.open("Driver={Oracle in OraDB12Home1};DBQ=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    With ADO_Cmd
         .ActiveConnection = ADO_Cnn
         .commandText = "AUTOFAXCOMP_CRT"
         .commandType = 4
         .parameters("YMD") = ymdto
         .parameters("IP") = Request.Cookies("IP").Value
         .parameters("USR") = Request.Cookies("userid").Value
         .Execute
    End With

    ret = ""
    if String.IsNullOrEmpty(ADO_Cmd.parameters("RTN").Value) = false then
      ret = ADO_Cmd.parameters("RTN").Value
    end if
    if ret <> "" then
        Response.Write("<br>�쐬�����I[" & ymdto & "] " & ret & " <br><br>")
    end if
    
    ADO_Cnn.Close                    '�I�u�W�F�N�g�J��
    ADO_Cmd = Nothing                '�I�u�W�F�N�g�J��
    ADO_Cnn = Nothing                  '�I�u�W�F�N�g�J��
    
    Response.Write("<!-- " & sql1 & " -->")
  end if
%>
<hr>
<%
elseif Request.Cookies("CENTCD").Value = "10001" then
end if
%>
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
    Response.Write("<option value='00000'>--------</option>")
    if kanscd = "10001" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='10001'" & wk & ">10001:����</option>")
elseif Request.Cookies("CENTCD").Value = "10001" then
    Response.Write("<option value='10001' SELECTED>10001:����</option>")
else
end if
%>
</SELECT>&nbsp;
&nbsp;(FAX���M�敪&nbsp;
1�ΏۊO<input type="checkbox" name="faxkbn1" value="checked" <%= faxkbn1 %>/>&nbsp;
2�Ώ�<input type="checkbox" name="faxkbn2" value="checked" <%= faxkbn2 %>/>
)&nbsp;
<input type="checkbox" name="taiocntkbn" value="checked" <%= taiocntkbn %>/>�P�Ή��f�[�^���P���Ƃ��ăJ�E���g&nbsp;
<input type="button" value="�\��" name="btnReload" onClick="fncReload();">&nbsp;[<%= kanscd  %>]
<%
  if execflg = "0" or execflg = "1" then
    
    sql1 = ""
    'sql1 = sql1 & "/* �����ƌ����ꗗ */ " & vbcrlf
    sql1 = sql1 & "SELECT  " & vbcrlf
    sql1 = sql1 & "    YM, " & vbcrlf
    sql1 = sql1 & "    DECODE(C01,0,NULL,C01) AS C01, " & vbcrlf
    sql1 = sql1 & "    DECODE(C02,0,NULL,C02) AS C02, " & vbcrlf
    sql1 = sql1 & "    DECODE(C03,0,NULL,C03) AS C03, " & vbcrlf
    sql1 = sql1 & "    DECODE(C04,0,NULL,C04) AS C04, " & vbcrlf
    sql1 = sql1 & "    DECODE(C05,0,NULL,C05) AS C05, " & vbcrlf
    sql1 = sql1 & "    DECODE(C06,0,NULL,C06) AS C06, " & vbcrlf
    sql1 = sql1 & "    DECODE(C07,0,NULL,C07) AS C07, " & vbcrlf
    sql1 = sql1 & "    DECODE(C08,0,NULL,C08) AS C08, " & vbcrlf
    sql1 = sql1 & "    DECODE(C09,0,NULL,C09) AS C09, " & vbcrlf
    sql1 = sql1 & "    DECODE(C10,0,NULL,C10) AS C10, " & vbcrlf
    sql1 = sql1 & "    DECODE(C11,0,NULL,C11) AS C11, " & vbcrlf
    sql1 = sql1 & "    DECODE(C12,0,NULL,C12) AS C12, " & vbcrlf
    sql1 = sql1 & "    DECODE(C13,0,NULL,C13) AS C13, " & vbcrlf
    sql1 = sql1 & "    DECODE(C14,0,NULL,C14) AS C14, " & vbcrlf
    sql1 = sql1 & "    DECODE(C15,0,NULL,C15) AS C15, " & vbcrlf
    sql1 = sql1 & "    DECODE(C16,0,NULL,C16) AS C16, " & vbcrlf
    sql1 = sql1 & "    DECODE(C17,0,NULL,C17) AS C17, " & vbcrlf
    sql1 = sql1 & "    DECODE(C18,0,NULL,C18) AS C18, " & vbcrlf
    sql1 = sql1 & "    DECODE(C19,0,NULL,C19) AS C19, " & vbcrlf
    sql1 = sql1 & "    DECODE(C20,0,NULL,C20) AS C20, " & vbcrlf
    sql1 = sql1 & "    DECODE(C21,0,NULL,C21) AS C21, " & vbcrlf
    sql1 = sql1 & "    DECODE(C22,0,NULL,C22) AS C22, " & vbcrlf
    sql1 = sql1 & "    DECODE(C23,0,NULL,C23) AS C23, " & vbcrlf
    sql1 = sql1 & "    DECODE(C24,0,NULL,C24) AS C24, " & vbcrlf
    sql1 = sql1 & "    DECODE(C25,0,NULL,C25) AS C25, " & vbcrlf
    sql1 = sql1 & "    DECODE(C26,0,NULL,C26) AS C26, " & vbcrlf
    sql1 = sql1 & "    DECODE(C27,0,NULL,C27) AS C27, " & vbcrlf
    sql1 = sql1 & "    DECODE(C28,0,NULL,C28) AS C28, " & vbcrlf
    sql1 = sql1 & "    DECODE(C29,0,NULL,C29) AS C29, " & vbcrlf
    sql1 = sql1 & "    DECODE(C30,0,NULL,C30) AS C30, " & vbcrlf
    sql1 = sql1 & "    DECODE(C31,0,NULL,C31) AS C31  " & vbcrlf
    sql1 = sql1 & "FROM " & vbcrlf
    sql1 = sql1 & "( " & vbcrlf
    sql1 = sql1 & "    SELECT  " & vbcrlf
    sql1 = sql1 & "        SUBSTR(INPUT_YMD, 1, 6) AS  YM, " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '01', 1, 0)) AS C01,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '02', 1, 0)) AS C02,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '03', 1, 0)) AS C03,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '04', 1, 0)) AS C04,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '05', 1, 0)) AS C05,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '06', 1, 0)) AS C06,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '07', 1, 0)) AS C07,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '08', 1, 0)) AS C08,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '09', 1, 0)) AS C09,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '10', 1, 0)) AS C10,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '11', 1, 0)) AS C11,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '12', 1, 0)) AS C12,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '13', 1, 0)) AS C13,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '14', 1, 0)) AS C14,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '15', 1, 0)) AS C15,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '16', 1, 0)) AS C16,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '17', 1, 0)) AS C17,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '18', 1, 0)) AS C18,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '19', 1, 0)) AS C19,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '20', 1, 0)) AS C20,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '21', 1, 0)) AS C21,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '22', 1, 0)) AS C22,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '23', 1, 0)) AS C23,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '24', 1, 0)) AS C24,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '25', 1, 0)) AS C25,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '26', 1, 0)) AS C26,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '27', 1, 0)) AS C27,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '28', 1, 0)) AS C28,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '29', 1, 0)) AS C29,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '30', 1, 0)) AS C30,  " & vbcrlf
    sql1 = sql1 & "        SUM(DECODE(SUBSTR(INPUT_YMD, 7, 2), '31', 1, 0)) AS C31  " & vbcrlf
    if taiocntkbn = "checked" then
        sql1 = sql1 & "    FROM (SELECT DISTINCT INPUT_YMD, TAIOU_SYONO, TAIOU_KANSCD, TAIOU_FAXKBN, LATEST_OF_DAY_FLG, EXEC_KBN FROM S06_AUTOFAXTAIDB) " & vbcrlf
    else
        sql1 = sql1 & "    FROM S06_AUTOFAXTAIDB " & vbcrlf
    end if
    sql1 = sql1 & "    WHERE 1=1 " & vbcrlf
    sql1 = sql1 & "      AND LATEST_OF_DAY_FLG = '1' " & vbcrlf
    sql1 = sql1 & "      AND TAIOU_KANSCD IN (" & kanscdwhe & ") " & vbcrlf
    if     faxkbn1 = "checked" and faxkbn2 = "checked" then
        '�����Ƃ�
    elseif faxkbn1 = "checked" and faxkbn2 = "" then
        sql1 = sql1 & "            AND TAIOU_FAXKBN = '1' " & vbcrlf 'FAX���M�ΏۊO�̂�
    elseif faxkbn1 = ""        and faxkbn2 = "checked" then
        sql1 = sql1 & "            AND TAIOU_FAXKBN = '2' " & vbcrlf 'FAX���M�Ώۂ̂�
    else
        sql1 = sql1 & "            AND 1=0  " & vbcrlf '�����Ȃ�
    end if
    sql1 = sql1 & "                AND EXEC_KBN IN ('" & sendkbn & "') " & vbcrlf
    sql1 = sql1 & "    GROUP BY SUBSTR(INPUT_YMD, 1, 6) " & vbcrlf
    sql1 = sql1 & ") " & vbcrlf
    sql1 = sql1 & "ORDER BY YM DESC " & vbcrlf
    
    Dim ADO_Cnn
    Dim ADO_Rst
    Dim i as integer
    Dim f as integer

    ADO_Cnn = server.CreateObject("ADODB.Connection")
    ADO_Rst = server.CreateObject("ADODB.Recordset")
    'ADO_Cnn.open("Driver={Microsoft ODBC for Oracle};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    'ADO_Cnn.open("Driver={Oracle in OraDB12Home1};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Cnn.open("Driver={Oracle in OraDB12Home1};DBQ=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Rst = ADO_Cnn.Execute(sql1)
    i = 0
    Response.Write("<table class='tbl'>")
    Response.Write("<tr class='trh'>")
    Response.Write("<td rowspan=2 class='tdh2'>��</td>")
    Response.Write("<td rowspan=2 class='tdh2'>��</td>")
    Response.Write("<td colspan=31 class='tdh3'>�Ή��f�[�^�� (���M�Ώۃ��X�g��)</td>")
    Response.Write("</tr>")
    Response.Write("<tr>")
    'Response.Write("<td class='tdh1'>��</td>")
    'Response.Write("<td class='tdh2'>��</td>")
    Response.Write("<td class='tdh3' width=30px>01</td>")
    Response.Write("<td class='tdh3' width=30px>02</td>")
    Response.Write("<td class='tdh3' width=30px>03</td>")
    Response.Write("<td class='tdh3' width=30px>04</td>")
    Response.Write("<td class='tdh3' width=30px>05</td>")
    Response.Write("<td class='tdh3' width=30px>06</td>")
    Response.Write("<td class='tdh3' width=30px>07</td>")
    Response.Write("<td class='tdh3' width=30px>08</td>")
    Response.Write("<td class='tdh3' width=30px>09</td>")
    Response.Write("<td class='tdh3' width=30px>10</td>")
    Response.Write("<td class='tdh3' width=30px>11</td>")
    Response.Write("<td class='tdh3' width=30px>12</td>")
    Response.Write("<td class='tdh3' width=30px>13</td>")
    Response.Write("<td class='tdh3' width=30px>14</td>")
    Response.Write("<td class='tdh3' width=30px>15</td>")
    Response.Write("<td class='tdh3' width=30px>16</td>")
    Response.Write("<td class='tdh3' width=30px>17</td>")
    Response.Write("<td class='tdh3' width=30px>18</td>")
    Response.Write("<td class='tdh3' width=30px>19</td>")
    Response.Write("<td class='tdh3' width=30px>20</td>")
    Response.Write("<td class='tdh3' width=30px>21</td>")
    Response.Write("<td class='tdh3' width=30px>22</td>")
    Response.Write("<td class='tdh3' width=30px>23</td>")
    Response.Write("<td class='tdh3' width=30px>24</td>")
    Response.Write("<td class='tdh3' width=30px>25</td>")
    Response.Write("<td class='tdh3' width=30px>26</td>")
    Response.Write("<td class='tdh3' width=30px>27</td>")
    Response.Write("<td class='tdh3' width=30px>28</td>")
    Response.Write("<td class='tdh3' width=30px>29</td>")
    Response.Write("<td class='tdh3' width=30px>30</td>")
    Response.Write("<td class='tdh3' width=30px>31</td>")
    Response.Write("</tr>")
    
    Dim cnt as integer
    Dim maxday as integer
    Dim std_cls29 as String
    Dim std_cls30 as String
    Dim std_cls31 as String
    cnt = 0
    Do Until ADO_Rst.EOF = True
        i = i + 1
        cnt = cnt + 1
        f = i mod 2
        
        Select Case cint(mid(ADO_Rst.Fields("YM").Value, 5,2))
            Case 2
                maxday = 28
                std_cls29 = "tdcout"
                std_cls30 = "tdcout"
                std_cls31 = "tdcout"
            Case 2
                maxday = 29
                std_cls29 = "tdr" & f
                std_cls30 = "tdcout"
                std_cls31 = "tdcout"
            Case 4,6,9,11
                maxday = 30
                std_cls29 = "tdr" & f
                std_cls30 = "tdr" & f
                std_cls31 = "tdcout"
            Case Else
                maxday = 31
                std_cls29 = "tdr" & f
                std_cls30 = "tdr" & f
                std_cls31 = "tdr" & f
        End Select
        
        Response.Write("<tr>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & i                              & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'>" & ADO_Rst.Fields("YM").Value  & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C01").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C02").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C03").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C04").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C05").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C06").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C07").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C08").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C09").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C10").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C11").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C12").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C13").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C14").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C15").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C16").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C17").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C18").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C19").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C20").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C21").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C22").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C23").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C24").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C25").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C26").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C27").Value & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("C28").Value & "</td>" & vbcrlf)
        Response.Write("<td class='" & std_cls29 & "'>" & ADO_Rst.Fields("C29").Value & "</td>" & vbcrlf)
        Response.Write("<td class='" & std_cls30 & "'>" & ADO_Rst.Fields("C30").Value & "</td>" & vbcrlf)
        Response.Write("<td class='" & std_cls31 & "'>" & ADO_Rst.Fields("C31").Value & "</td>" & vbcrlf)
        Response.Write("</tr>" & vbcrlf)
        ADO_Rst.MoveNext
    Loop
    Response.Write("</table>")
    
    if cnt <= 0 then
        Response.Write("<br>�Y���f�[�^������܂���B<br><br>")
    end if
    
    ADO_Rst.Close                    '�I�u�W�F�N�g�J��
    ADO_Cnn.Close                    '�I�u�W�F�N�g�J��
    ADO_Rst = Nothing                '�I�u�W�F�N�g�J��
    ADO_Cnn = Nothing                  '�I�u�W�F�N�g�J��
    
    Response.Write("<!-- " & sql1 & " -->")
  end if
%>
�y�����z<BR>
�E�Ή��f�[�^�𑗐M��ɕR�t������̌����B<BR>
&nbsp;&nbsp;(������f�[�^�𕡐����֕񍐂���ꍇ�����邽�߁A���ۂ̑Ή�������葝����ꍇ������܂�)<BR>
&nbsp;&nbsp;(�����M�ΏۊO���������Ă��܂�)<BR>
<hr>
<BR>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>
