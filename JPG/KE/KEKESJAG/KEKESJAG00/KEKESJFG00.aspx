<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KEKESJFG00.aspx.vb" Inherits="JPG.KEKESJAG00.KEKEKJFG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>KEKEKJFG00</title>
		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
<asp:Label id="lblScript" runat="server"></asp:Label>
<asp:Repeater id="rptKesonData" runat="server" DataSource="<%# dbKeson %>">

<HeaderTemplate>
<table cellpadding="1" cellSpacing="1" border="0" width="440">
<tr>
<th align="center" width="30">
削除</th>
<th align="center" width="120">
FTPファイル名</th>
<th align="center" width="70">
状態</th>
<th align="center" width="70">
登録状況</th>
<th align="center" width="140">
最終更新時刻</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<td align="center" class="LINK">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'yellow' ,5)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'skyblue',5)" STYLE="WIDTH: 100%;CURSOR: hand">
<input type="checkbox" 
name="chkDel<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>" 
tabIndex="<%# DataBinder.Eval(Container,"DataItem.ROWNO") * 10 %>">
<input type="hidden" 
name="hdnKey<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>" 
tabIndex="<%# (DataBinder.Eval(Container,"DataItem.ROWNO") * 10) + 1 %>"
value="<%# DataBinder.Eval(Container,"DataItem.FTPFILE") %>">						

</SPAN>
</td>
<td align="center" class="OTHR">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>2LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'yellow' ,5)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'skyblue',5)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.FTPFILE") %>
</SPAN>
</td>
<td align="center" class="OTHR">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>3LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'yellow' ,5)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'skyblue',5)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.STATE") %>
</SPAN>
</td>
<td align="center" class="OTHR">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>4LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'yellow' ,5)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'skyblue',5)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.JOUKYOU") %>
</SPAN>
</td>
<td align="center" class="OTHR">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>5LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'yellow' ,5)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.KEY") %>', 'skyblue',5)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.UPDDATE") %>
</SPAN>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>			

</asp:Repeater><INPUT id="hdnDataCnt" type="hidden" name="hdnDataCnt" runat="server">
		</form>
	</body>
</HTML>
