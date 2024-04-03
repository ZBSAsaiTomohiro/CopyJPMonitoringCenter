<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COPOPUFG00.aspx.vb" Inherits="JPSD.COPOPUFG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
		<title>COPOPUFG00</title>
	</HEAD>
	<body onload="document.Form1.focus();">
		<form name="Form1" id="Form1" method="post" runat="server">
			<center>
			<asp:Label id="lblScript" runat="server"></asp:Label>

<asp:Repeater id=rptIframe runat="server" DataSource="<%# dbSet %>">

<HeaderTemplate>
<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 START --%>
<%-- <table cellpadding="1" cellSpacing="1" width="320" border="0">
<tr>
<th align="center" width="100">
コード
</th>
<th align="center" width="200"> --%>
<table cellpadding="1" cellSpacing="1" border="0" style="table-layout:fixed;width:100%;">
<colgroup>
	<col style="width:32%;">
	<col style="width:68%;">
</colgroup>
<tr>
<th align="center">
コード
</th>
<th align="center">
<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 END --%>
名称
</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 START --%>
<%-- <td align="center" class="CODE"> --%>
<td align="center" class="CODE" style="word-wrap:break-word;min-height:20px;">
<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 END --%>

<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>', 'yellow' ,2)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>', 'skyblue',2)" 
<%-- 2014/10/30 H.Hosoda add 2014改善開発 No11 START --%>
<%-- onclick="fncPutData('<%# DataBinder.Eval(Container,"DataItem.CODE") %>','<%# DataBinder.Eval(Container,"DataItem.CDNM") %>')"
STYLE="WIDTH: 100%;CURSOR: hand">  --%>
onclick="fncPutData('<%# DataBinder.Eval(Container,"DataItem.CODE") %>','<%# DataBinder.Eval(Container,"DataItem.CDNM") %>','<%# DataBinder.Eval(Container,"DataItem.NAME") %>')" 
STYLE="display:block;width: 100%;CURSOR: hand">
<%-- 2014/10/30 H.Hosoda add 2014改善開発 No11 END --%>
<%# DataBinder.Eval(Container,"DataItem.CODE") %>
<%-- </SPAN> --%>
</td>
<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 START --%>
<%-- <td align="left" class="NAME"> --%>
<td align="left" class="NAME" style="word-wrap:break-word;min-height:20px;">
<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 END --%>
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>2LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>', 'yellow',2)" 
onmouseout="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.CODE") %>', 'skyblue',2)" 
<%-- 2014/10/30 H.Hosoda add 2014改善開発 No11 START --%>
<%-- onclick="fncPutData('<%# DataBinder.Eval(Container,"DataItem.CODE") %>','<%# DataBinder.Eval(Container,"DataItem.CDNM") %>')"
STYLE="WIDTH: 100%;CURSOR: hand">  --%>
onclick="fncPutData('<%# DataBinder.Eval(Container,"DataItem.CODE") %>','<%# DataBinder.Eval(Container,"DataItem.CDNM") %>','<%# DataBinder.Eval(Container,"DataItem.NAME") %>')" 
STYLE="display:block;width: 100%;CURSOR: hand">
<%-- 2014/10/30 H.Hosoda add 2014改善開発 No11 END --%>
<%# DataBinder.Eval(Container,"DataItem.NAME") %>
<%-- </SPAN> --%>
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
