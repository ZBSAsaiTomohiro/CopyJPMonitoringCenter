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
<%-- 2013/11/28 T.Ono add �Ď����P2013��2 START --%>
<th align="center" width="30">
��</th>
<%-- 2013/11/28 T.Ono add �Ď����P2013��2 END --%>
<th align="center" width="104">
������</th>
<th align="center" width="110">
�o�b�`�J�n����</th>
<th align="center" width="110">
�o�b�`�I������</th>
<th align="center" width="36">
���s<br>
����</th>
<th align="center" width="60">
�������</th>
<%-- 2013/11/28 T.Ono mod �Ď����P2013��2 --%>
<%-- <th align="center" width="500"> --%>
<th align="center" width="470">
���ʃ��b�Z�[�W</th>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<%-- 2013/11/28 T.Ono add �Ď����P2013��2 START --%>
<td class="OTHR" align="center">
<%# DataBinder.Eval(Container, "DataItem.NO")%>
</td>
<%-- 2013/11/28 T.Ono add �Ď����P2013��2 END --%>
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
