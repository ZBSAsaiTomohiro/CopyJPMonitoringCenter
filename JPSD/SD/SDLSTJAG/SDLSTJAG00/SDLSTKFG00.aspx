<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SDLSTKFG00.aspx.vb" Inherits="JPSD.SDLSTJAG00.SDLSTKFG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�ً}�o�����ʈꗗ</title>
		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblScript" runat="server"></asp:Label>
			<INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"> <INPUT id="hdnLOGIN_FLG" type="hidden" name="hdnLOGIN_FLG" runat="server">
<asp:Repeater id=rptData runat="server" DataSource="<%# dbData %>">
<HeaderTemplate>
<table cellpadding="1" cellSpacing="1" border="0" width="930">
<tr>
<%-- 2013/11/28 T.Ono add �Ď����P2013 START--%>
<th align="center" width="25">
��</th>
<%-- 2013/11/28 T.Ono mod �Ď����P2013 END --%>
<th align="center" width="70">
�����ԍ�</th>
<th align="center" width="90">
�S����</th>
<%-- 2014/10/20 H.Hosoda mod 2014���P�J�� No10 START --%>
<%-- <th align="center" width="90">
������/����</th>
<th align="center" width="90">
�ً}�Ή���<br>/����</th> --%>
<th align="center" width="90">
��M����</th>
<th align="center" width="90">
�ً}�˗�����</th>
<%-- 2014/10/20 H.Hosoda mod 2014���P�J�� No10 END --%>
<th align="center" width="60">
�����敪</th>
<%-- 2013/11/28 T.Ono mod �Ď����P2013 --%>
<%-- <th align="center" width="120">  --%>
<%-- 2014/10/20 H.Hosoda mod 2014���P�J�� No10 START --%>
<%-- <th align="center" width="110">
���v�Ɩ�</th> --%>
<th align="center" width="110">
���q�l��</th>
<%-- 2014/10/20 H.Hosoda mod 2014���P�J�� No10 END --%>
<%-- 2013/11/28 T.Ono mod �Ď����P2013 --%>
<%-- <th align="center" width="130"> --%>
<%-- 2014/10/20 H.Hosoda mod 2014���P�J�� No10 START --%>
<%-- <th align="center" width="120">
�d�b�A�����e</th> --%>
<th nowrap="nowrap" align="center" width="85">
�d�b�A�����e</th>
<%-- 2014/10/20 H.Hosoda mod 2014���P�J�� No10 END --%>
<%-- 2013/11/28 T.Ono mod �Ď����P2013 --%>
<%-- <th align="center" width="140"> --%>
<%-- 2014/10/20 H.Hosoda mod 2014���P�J�� No10 START --%>
<%-- <th align="center" width="130">
�o���w������</th>
<th align="center" width="120">
�o���w�����l</th> --%>
<th align="center" width="130">
�o���˗����e</th>
<th align="center" width="120">
�o���˗����l</th>
<%-- 2014/10/20 H.Hosoda mod 2014���P�J�� No10 END --%>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<%-- 2013/11/28 T.Ono add �Ď����P2013 START ���ׂĂ�onmouseover,onmouseout�̈����ύX9��10 --%>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>10LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container, "DataItem.NO")%>
</SPAN>
</td>
<%-- 2013/11/28 T.Ono mod ���P�Ή�2013 END --%>
<td align="center" class="LINK<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%;CURSOR: hand">
<%# DataBinder.Eval(Container,"DataItem.SYONO") %>
</SPAN>
</td>
<td align="left" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>2LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.TKTANCD_NM") %>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>3LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.HATYMD") %>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>4LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.SYOYMD") %>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>5LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.HATKBN") %>
</SPAN>
</td>
<td align="left" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>6LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.JUSYONM") %>
</SPAN>
</td>
<td align="left" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>7LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.TELRNM") %>
</SPAN>
</td>
<td align="left" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>8LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.SDNM") %>
</SPAN>
</td>
<td align="left" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>9LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.SIJI_BIKO") %>
</SPAN>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
			<INPUT id="hdnJUMP" type="hidden" name="hdnJUMP" runat="server"> <INPUT id="hdnMOVE_SIJIYMD_F" type="hidden" name="hdnMOVE_SIJIYMD_F" runat="server">
			<INPUT id="hdnMOVE_SIJIYMD_T" type="hidden" name="hdnMOVE_SIJIYMD_T" runat="server">
			<INPUT id="hdnMOVE_KBN" type="hidden" name="hdnMOVE_KBN" runat="server"> <INPUT id="hdnKEY_KANSCD" type="hidden" name="hdnKEY_KANSCD" runat="server">
			<INPUT id="hdnKEY_SYONO" type="hidden" name="hdnKEY_SYONO" runat="server">
            <%-- 2013/12/11 T.Ono add �Ď����P2013 --%>
            <INPUT id="hdnScrollTop" type="hidden" name="hdnScrollTop" runat="server">
            <INPUT id="hdnCLI_CD" type="hidden" name="hdnCLI_CD" runat="server">
            <INPUT id="hdnMOVE_CLI_CD" type="hidden" name="hdnMOVE_CLI_CD" runat="server"> <INPUT id="hdnMOVE_CLI_CD_NAME" type="hidden" name="hdnMOVE_CLI_CD_NAME" runat="server">
            <INPUT id="hdnJA_CD" type="hidden" name="hdnJA_CD" runat="server">
            <INPUT id="hdnMOVE_JA_CD" type="hidden" name="hdnMOVE_JA_CD" runat="server"> <INPUT id="hdnMOVE_JA_CD_NAME" type="hidden" name="hdnMOVE_JA_CD_NAME" runat="server">
            <%-- 2014/10/16 H.Hosoda add 2014���P�J�� No10 START --%>
            <INPUT id="hdnGROUP_CD" type="hidden" name="hdnGROUP_CD" runat="server">
            <INPUT id="hdnMOVE_GROUP_CD" type="hidden" name="hdnMOVE_GROUP_CD" runat="server"> <INPUT id="hdnMOVE_GROUP_CD_NAME" type="hidden" name="hdnMOVE_GROUP_CD_NAME" runat="server">
            <%-- 2014/10/16 H.Hosoda add 2014���P�J�� No10 END --%>
		</form>
	</body>
</HTML>
