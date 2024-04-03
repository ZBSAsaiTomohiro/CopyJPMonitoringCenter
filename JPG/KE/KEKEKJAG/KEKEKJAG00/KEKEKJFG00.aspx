<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KEKEKJFG00.aspx.vb" Inherits="JPG.KEKEKJAG00.KEKEKJFG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>KEKEKJFG00</title>
		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblScript" runat="server"></asp:Label>
<asp:Repeater  id=rptData runat="server" DataSource="<%# dbData %>">
<HeaderTemplate>
<table cellpadding="1" cellSpacing="1" border="0" width="940">
<tr>
<%-- 2013/11/28 T.Ono mod 監視改善2013 START --%>
<%-- 
<%-- 2011.11.02 MOD h.uema 表示項目変更に伴う修正 START -%>
<%--
<th align="center" width="100">
処理</th>
-%>
<th align="center" width="50">
JA支所<br>コード</th>
<th align="center" width="170">
JA支所名</th>
<%-- <th align="center" width="90"> -%>
<th align="center" width="60">
発生日</th>
<%-- <th align="center" width="80"> -%>
<th align="center" width="40">
発生<br>時刻</th>
<%-- <th align="center" width="90"> -%>
<th align="center" width="80">
対応完了日</th>
<%-- <th align="center" width="80"> -%>
<th align="center" width="60">
対応完了<br>時刻</th>
<%-- <th align="center" width="80"> -%>
<th align="center" width="60">
発生区分</th>
<%-- <th align="center" width="80"> -%>
<th align="center" width="60">
対応区分</th>
<%-- 2011.11.02 ADD h.uema 表示項目変更に伴う修正 START -%>
<th align="center" width="170">
警報１</th>
<%-- 2011.11.02 ADD h.uema 表示項目変更に伴う修正 END -%>
<%-- <th align="center" width="80"> -%>
<th align="center" width="60">
処理区分</th>
<%-- <th align="center" width="260"> -%>
<th align="center" width="130">
需要家名</th>
</tr>
<%-- 2011.11.02 MOD h.uema 表示項目変更に伴う修正 END -%> --%>
<th align="center" width="30">
№
</th>
<th align="center" width="50">
JA支所<br>コード</th>
<th align="center" width="160">
JA支所名</th>
<th align="center" width="60">
受信日</th>
<th align="center" width="40">
受信<br>時刻</th>
<th align="center" width="80">
対応完了日</th>
<th align="center" width="60">
対応完了<br>時刻</th>
<th align="center" width="60">
発生区分</th>
<th align="center" width="60">
対応区分</th>
<th align="center" width="160">
警報１</th>
<th align="center" width="60">
処理区分</th>
<%-- 2014/11/12 H.Hosoda add 監視改善2014 No.7 START --%>
<th align="center" width="120">
<%-- 需要家名</th> --%>
お客様名</th>
<%-- 2014/11/12 H.Hosoda add 監視改善2014 No.7 END --%>
</tr>
<%-- 2013/11/28 T.Ono mod 監視改善2013 END --%>
</HeaderTemplate>
<ItemTemplate>
<tr>
<%-- 2013/11/28 T.Ono mod 監視改善2013 START  すべてのonmouseover,onmouseoutの引数変更11→12 --%>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>12LPG"
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container, "DataItem.NO")%>
</SPAN>
</td>
<%-- 2013/11/28 T.Ono mod 監視改善2013 END --%>
<%-- 2011.11.28 ADD h.uema START --%>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.ACBCD") %>
</SPAN>
</td>
<%-- 2011.11.28 ADD h.uema END --%>
 <td align="left" class="LINK<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>2LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow',12)" 
onmouseout="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%;CURSOR: hand">
<%-- 2011.11.02 MOD h.uema 表示項目変更に伴う修正 START --%>
<%--# DataBinder.Eval(Container,"DataItem.SYONO") --%>
<%# DataBinder.Eval(Container,"DataItem.ACBNM") %>
<%-- 2011.11.02 MOD h.uema 表示項目変更に伴う修正 END --%>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>3LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.HATYMD") %>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>4LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.HATTIME") %>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>5LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 99%">
<%# DataBinder.Eval(Container,"DataItem.SYOYMD") %>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>6LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.SYOTIME") %>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>7LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.HATKBN") %>
</SPAN>
</td>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>8LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.TAIOKBN") %>
</SPAN>
</td>
<%-- 2011.11.02 ADD h.uema START --%>
<td align="left" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>9LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.KMNM1") %>
</SPAN>
</td>
<%-- 2011.11.02 ADD h.uema END --%>
<td align="center" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>10LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.TMSKB") %>
</SPAN>
</td>
<td align="left" class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>11LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', 'yellow' ,12)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container,"DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container,"DataItem.COLOR") %>',12)" STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container,"DataItem.JUSYONM") %>
</SPAN>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
			<INPUT id="hdnJUMP" type="hidden" name="hdnJUMP" runat="server"> <INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
			<INPUT id="hdnKEY_SYONO" type="hidden" name="hdnKEY_SYONO" runat="server"> <INPUT id="hdnKEY_KANSCD" type="hidden" name="hdnKEY_KANSCD" runat="server">
			<INPUT id="hdnMOVE_TMSKB" type="hidden" name="hdnMOVE_TMSKB" runat="server"> <INPUT id="hdnMOVE_JUTEL" type="hidden" name="hdnMOVE_JUTEL" runat="server">
			<%-- <INPUT id="hdnMOVE_NCUTEL" type="hidden" name="hdnMOVE_NCUTEL" runat="server"> 2014/12/05 H.Hosoda add 監視改善2014 No.7 2016/11/25 H.Mori del 監視改善2016 No3-2 --%>
			<INPUT id="hdnMOVE_KANSCD" type="hidden" name="hdnMOVE_KANSCD" runat="server"> <INPUT id="hdnMOVE_HATKBN" type="hidden" name="hdnMOVE_HATKBN" runat="server">
			<INPUT id="hdnMOVE_TKTANCD" type="hidden" name="hdnMOVE_TKTANCD" runat="server"><INPUT id="hdnMOVE_TKTANNM" type="hidden" name="hdnMOVE_TKTANNM" runat="server">
			<%-- 2014/12/04 H.Hosoda mod 監視改善2014 No.7 START --%>
            <%-- <INPUT id="hdnMOVE_TAIOKBN" type="hidden" name="hdnMOVE_TAIOKBN" runat="server"> --%>
            <INPUT id="hdnMOVE_TAIOKBN1" type="hidden" name="hdnMOVE_TAIOKBN1" runat="server">
            <INPUT id="hdnMOVE_TAIOKBN2" type="hidden" name="hdnMOVE_TAIOKBN2" runat="server">
            <INPUT id="hdnMOVE_TAIOKBN3" type="hidden" name="hdnMOVE_TAIOKBN3" runat="server">
			<%-- 2014/12/04 H.Hosoda mod 監視改善2014 No.7 END --%>
			<INPUT id="hdnMOVE_JUSYONM" type="hidden" name="hdnMOVE_JUSYONM" runat="server">
			<%-- <INPUT id="hdnMOVE_JUSYOKN" type="hidden" name="hdnMOVE_JUSYOKN" runat="server"> 2016/11/24 H.Mori del 監視改善2016 No3-3 --%>
			<%-- 2017/10/25 H.Mori add 2017改善開発 No3-1 START --%>
            <input id="hdnMOVE_KIKANKBN" type="hidden" name="hdnKIKANKBN" runat="server">
            <%-- 2017/10/25 H.Mori add 2017改善開発 No3-1 END --%>
            <INPUT id="hdnMOVE_HATYMD_To" type="hidden" name="hdnMOVE_HATYMD_To" runat="server">
			<INPUT id="hdnMOVE_HATTIME_To" type="hidden" name="hdnMOVE_HATTIME_To" runat="server">
			<INPUT id="hdnMOVE_HATYMD_From" type="hidden" name="hdnMOVE_HATYMD_From" runat="server">
			<INPUT id="hdnMOVE_HATTIME_From" type="hidden" name="hdnMOVE_HATTIME_From" runat="server">
			<INPUT id="hdnMOVE_KURACD" type="hidden" name="hdnMOVE_KURACD" runat="server"> <INPUT id="hdnMOVE_KURACD_NAME" type="hidden" name="hdnMOVE_KURACD_NAME" runat="server">
			<INPUT id="hdnMOVE_ACBCD" type="hidden" name="hdnMOVE_ACBCD" runat="server"> <INPUT id="hdnMOVE_ACBCD_NAME" type="hidden" name="hdnMOVE_ACBCD" runat="server">
            <%-- 2019/11/01 T.Ono add 監視改善2019 START --%>
            <INPUT id="hdnMOVE_KURACD_TO" type="hidden" name="hdnMOVE_KURACD_TO" runat="server"> <INPUT id="hdnMOVE_KURACD_TO_NAME" type="hidden" name="hdnMOVE_KURACD_TO_NAME" runat="server">
			<INPUT id="hdnMOVE_ACBCD_TO" type="hidden" name="hdnMOVE_ACBCD_TO" runat="server"> <INPUT id="hdnMOVE_ACBCD_TO_NAME" type="hidden" name="hdnMOVE_ACBCD_TO_NAME" runat="server">
            <INPUT id="hdnMOVE_ACBCD_CLI" type="hidden" name="hdnMOVE_ACBCD_CLI" runat="server"> <INPUT id="hdnMOVE_ACBCD_TO_CLI" type="hidden" name="hdnMOVE_ACBCD_TO_CLI" runat="server">
            <INPUT id="hdnMOVE_JACD_CLI" type="hidden" name="hdnMOVE_JACD_CLI" runat="server">
            <%-- 2019/11/01 T.Ono add 監視改善2019 END --%>
			<INPUT id="hdnMOVE_USER_CD" type="hidden" name="hdnMOVE_USER_CD" runat="server">
			<INPUT id="hdnMOVE_KMCD" type="hidden" name="hdnMOVE_KMCD" runat="server"><!-- 2011.11.15 ADD H.Uema 警報コード -->
            <%-- 警報名 2013/12/10 T.Ono add 監視改善2013 --%>
            <INPUT id="hdnMOVE_KMNM" type="hidden" name="hdnMOVE_KMNM" runat="server">
            <INPUT id="hdnMOVE_JACD" type="hidden" name="hdnMOVE_JACD" runat="server"> <INPUT id="hdnMOVE_JACD_NAME" type="hidden" name="hdnMOVE_JACD_NAME" runat="server">
			<%-- 2014/12/08 H.Hosoda mod 監視改善2014 No.7 START --%>
            <INPUT id="hdnMOVE_HAN_GRP" type="hidden" name="hdnMOVE_HAN_GRP" runat="server"> <INPUT id="hdnMOVE_HAN_GRP_NAME" type="hidden" name="hdnMOVE_HAN_GRP_NAME" runat="server">
			<%-- 2014/12/08 H.Hosoda mod 監視改善2014 No.7 END --%>
            <%-- 2016/11/25 H.Mori add 改善対応2016 No3-1 START --%> 
            <INPUT id="hdnMOVE_KINREN_GRP" type="hidden" name="hdnMOVE_KINREN_GRP" runat="server"> <INPUT id="hdnMOVE_KINREN_GRP_NAME" type="hidden" name="hdnMOVE_KINREN_GRP_NAME" runat="server">
            <%-- 2016/11/25 H.Mori add 改善対応2016 No3-1 END --%>
            <INPUT id="hdnScrollTop" type="hidden" name="hdnScrollTop" runat="server">
		</form>
	</body>
</HTML>
