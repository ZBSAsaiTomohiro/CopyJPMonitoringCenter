<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SYBATJFG00.aspx.vb" Inherits="JPG.SYBATJAG00.SYBATJFG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SYBATJFG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
<asp:Label id="lblScript" runat="server"></asp:Label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
<asp:Repeater id=rptData runat="server" DataSource="<%# dbData %>">
<HeaderTemplate>
<table cellpadding="1" cellSpacing="1" width="920" border="0">
<tr>
<%-- 2013/11/28 T.Ono add 監視改善2013№2 START --%>
<th align="center" width="30">
№</th>
<%-- 2013/11/28 T.Ono add 監視改善2013№2 END --%>
<th align="center" width="104">
処理名</th>
<th align="center" width="110">
バッチ開始日時</th>
<th align="center" width="110">
バッチ終了日時</th>
<th align="center" width="36">
実行<br>
結果</th>
<th align="center" width="60">
処理状態</th>
<%-- 2013/11/28 T.Ono mod 監視改善2013№2 --%>
<%-- <th align="center" width="500"> --%>
<th align="center" width="470">
結果メッセージ</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<%-- 2013/11/28 T.Ono add 監視改善2013№2 START --%>
<td class="OTHR" align="center">
<%# DataBinder.Eval(Container, "DataItem.NO")%>
</td>
<%-- 2013/11/28 T.Ono add 監視改善2013№2 END --%>
<td class="OTHR" align="center">
<%# DataBinder.Eval(Container,"DataItem.PROC_ID") %>
</td>
<td class="OTHR" align="center">
<%# DataBinder.Eval(Container,"DataItem.ST_YMD") %>
</td>
<td class="OTHR" align="center">
<%# DataBinder.Eval(Container,"DataItem.ED_YMD") %>
</td>
<td class="OTHR" align="center">
<%# DataBinder.Eval(Container,"DataItem.PROJ_STATUS") %>
</td>
<td class="OTHR" align="center">
<%# DataBinder.Eval(Container,"DataItem.EXEC_STATUS") %>
</td>
<td class="OTHR">
<%# DataBinder.Eval(Container,"DataItem.MSG") %>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
<INPUT id="Hidden1" type="hidden" name="hdnMyAspx" runat="server">
		</form>
	</body>
</HTML>
