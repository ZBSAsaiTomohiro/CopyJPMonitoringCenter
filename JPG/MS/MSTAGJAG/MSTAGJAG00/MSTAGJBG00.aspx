<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTAGJBG00.aspx.vb" Inherits="MSTAGJAG00.MSTAGJBG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
		<title>MSTAGJBG00</title>
	</HEAD>
	<body onload="document.Form1.focus();">
		<form name="Form1" id="Form1" method="post" runat="server">
			<center>
			<asp:Label id="lblScript" runat="server"></asp:Label>

<asp:Repeater id=rptIframe runat="server" DataSource="<%# dbSet %>">

<HeaderTemplate>
<table cellpadding="1" cellSpacing="1" width="320" border="0">
<tr>
<th align="center" width="100">
コード
</th>
<th align="center" width="200">
名称
</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td align="center" class="CODE">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>', 'yellow' ,2)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>', 'skyblue',2)" 
onclick="copy('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>');"
STYLE="WIDTH: 100%;CURSOR: hand" />
<%# DataBinder.Eval(Container,"DataItem.CODE") %>
</SPAN>
</td>
<td align="left" class="NAME">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>2LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>', 'yellow',2)" 
onmouseout="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>', 'skyblue',2)" 
onclick="copy('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>2LPG')"
STYLE="WIDTH: 100%;CURSOR: hand" />
<%# DataBinder.Eval(Container,"DataItem.NAME") %>
</SPAN>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>			

</asp:Repeater>						

			</center>
		</form>
	</body>
</HTML>
