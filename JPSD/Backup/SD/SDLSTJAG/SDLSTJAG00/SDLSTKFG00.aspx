<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SDLSTKFG00.aspx.vb" Inherits="JPSD.SDLSTJAG00.SDLSTKFG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>緊急出動結果一覧</title>
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
<%-- 2013/11/28 T.Ono add 監視改善2013 START--%>
<th align="center" width="25">
№</th>
<%-- 2013/11/28 T.Ono mod 監視改善2013 END --%>
<th align="center" width="70">
処理番号</th>
<th align="center" width="90">
担当者</th>
<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 START --%>
<%-- <th align="center" width="90">
発生日/時刻</th>
<th align="center" width="90">
緊急対応日<br>/時刻</th> --%>
<th align="center" width="90">
受信日時</th>
<th align="center" width="90">
緊急依頼日時</th>
<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 END --%>
<th align="center" width="60">
発生区分</th>
<%-- 2013/11/28 T.Ono mod 監視改善2013 --%>
<%-- <th align="center" width="120">  --%>
<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 START --%>
<%-- <th align="center" width="110">
需要家名</th> --%>
<th align="center" width="110">
お客様名</th>
<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 END --%>
<%-- 2013/11/28 T.Ono mod 監視改善2013 --%>
<%-- <th align="center" width="130"> --%>
<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 START --%>
<%-- <th align="center" width="120">
電話連絡内容</th> --%>
<th nowrap="nowrap" align="center" width="85">
電話連絡内容</th>
<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 END --%>
<%-- 2013/11/28 T.Ono mod 監視改善2013 --%>
<%-- <th align="center" width="140"> --%>
<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 START --%>
<%-- <th align="center" width="130">
出動指示名称</th>
<th align="center" width="120">
出動指示備考</th> --%>
<th align="center" width="130">
出動依頼内容</th>
<th align="center" width="120">
出動依頼備考</th>
<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 END --%>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
<%-- 2013/11/28 T.Ono add 監視改善2013 START すべてのonmouseover,onmouseoutの引数変更9→10 --%>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>10LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,10)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',10)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container, "DataItem.NO")%>
</SPAN>
</td>
<%-- 2013/11/28 T.Ono mod 改善対応2013 END --%>
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
            <%-- 2013/12/11 T.Ono add 監視改善2013 --%>
            <INPUT id="hdnScrollTop" type="hidden" name="hdnScrollTop" runat="server">
            <INPUT id="hdnCLI_CD" type="hidden" name="hdnCLI_CD" runat="server">
            <INPUT id="hdnMOVE_CLI_CD" type="hidden" name="hdnMOVE_CLI_CD" runat="server"> <INPUT id="hdnMOVE_CLI_CD_NAME" type="hidden" name="hdnMOVE_CLI_CD_NAME" runat="server">
            <INPUT id="hdnJA_CD" type="hidden" name="hdnJA_CD" runat="server">
            <INPUT id="hdnMOVE_JA_CD" type="hidden" name="hdnMOVE_JA_CD" runat="server"> <INPUT id="hdnMOVE_JA_CD_NAME" type="hidden" name="hdnMOVE_JA_CD_NAME" runat="server">
            <%-- 2014/10/16 H.Hosoda add 2014改善開発 No10 START --%>
            <INPUT id="hdnGROUP_CD" type="hidden" name="hdnGROUP_CD" runat="server">
            <INPUT id="hdnMOVE_GROUP_CD" type="hidden" name="hdnMOVE_GROUP_CD" runat="server"> <INPUT id="hdnMOVE_GROUP_CD_NAME" type="hidden" name="hdnMOVE_GROUP_CD_NAME" runat="server">
            <%-- 2014/10/16 H.Hosoda add 2014改善開発 No10 END --%>
		</form>
	</body>
</HTML>
