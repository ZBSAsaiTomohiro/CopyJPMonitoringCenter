<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSKOSJFG00.aspx.vb" Inherits="JPG.MSKOSJAG00.MSKOSJFG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSKOSJAG00</title>
		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblScript" runat="server"></asp:Label>
<asp:Repeater id=rptData runat="server" DataSource="<%# dbData %>">
<HeaderTemplate>
<table cellpadding="1" cellSpacing="1" width="940" border="0">
<%-- 2013/11/26 T.Ono mod 改善対応2013№2 START
<tr>
<th align="center" width="140">
需要家コード
</th>
<th align="center" width="190">
需要家名
</th>
<th align="center" width="180">
需要家名カナ
</th>
<th align="center" width="110">
需要家電話番号
</th>
<th align="center" width="320">
需要家住所
</th>
</tr> --%>
<tr>
<%-- 2014/11/12 H.Hosoda mod 改善対応2014№6 START --%>
<%-- <th align="center" width="30">
№
</th>
<th align="center" width="140">
需要家コード
</th>
<th align="center" width="190">
需要家名
</th>
<th align="center" width="160">
需要家名カナ
</th>
<th align="center" width="110">
需要家電話番号
</th>
<th align="center" width="300">
需要家住所
</th>
 --%>
<th align="center" width="30">
№
</th>
<th align="center" width="140">
お客様コード
</th>
<th align="center" width="190">
お客様名
</th>
<%-- <th align="center" width="170"> 2014/04/09 T.Ono mod 罫線が消えていたので調整 --%>
<th align="center" width="95">
お客様名カナ
</th>
<th align="center" width="95">
連絡先
</th>
<th align="center" width="100">
結線番号
</th>
<th align="center" width="280">
お客様住所
</th>
<%-- 2014/11/12 H.Hosoda mod 改善対応2014№6 END --%>
</tr>
<%-- 2013/11/26 T.Ono mod 改善対応2013№2 END --%>
</HeaderTemplate>
<ItemTemplate>
<tr>
<%-- 2013/11/26 T.Ono add 改善対応2013№2 START すべてのonmouseover,onmouseoutの引数変更5→6 --%>
<%-- 2014/12/02 H.Hosoda mod 改善対応2014№6 START すべてのonmouseover,onmouseoutの引数変更6→7 --%>
<td align="center" class="LINK<%# DataBinder.Eval(Container, "DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>6LPG"
onmouseover="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', 'yellow' ,7)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container, "DataItem.COLOR") %>',7)" 
STYLE="WIDTH: 100%;CURSOR: hand">
<%# DataBinder.Eval(Container, "DataItem.NO")%>
</SPAN>
</td>
<%-- 2013/11/26 T.Ono mod 改善対応2013№2 END --%>
<td align="left" class="LINK<%# DataBinder.Eval(Container, "DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', 'yellow' ,7)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container, "DataItem.COLOR") %>',7)" 
STYLE="WIDTH: 100%;CURSOR: hand">
<%# DataBinder.Eval(Container, "DataItem.JCODE") %>
</SPAN>
</td>
<td class="OTHR<%# DataBinder.Eval(Container, "DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>2LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', 'yellow' ,7)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container, "DataItem.COLOR") %>',7)" 
STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container, "DataItem.NAME") %>
</SPAN>
</td>
<%-- 2014/12/03 H.Hosoda mod 改善対応2014№6 START --%>
<%-- <td class="OTHR<%# DataBinder.Eval(Container,"DataItem.CLS") %>"> --%>
<td nowrap class="OTHR<%# DataBinder.Eval(Container, "DataItem.CLS") %>">
<%-- 2014/12/03 H.Hosoda mod 改善対応2014№6 END --%>
<SPAN id="bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>3LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', 'yellow' ,7)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container, "DataItem.COLOR") %>',7)" 
<%-- 2014/12/03 H.Hosoda mod 改善対応2014№6 START --%>
<%-- STYLE="WIDTH: 100%"> --%>
STYLE="WIDTH: 99%">
<%-- 2014/12/03 H.Hosoda mod 改善対応2014№6 END --%>
<%# DataBinder.Eval(Container, "DataItem.KANA") %>
</SPAN>
</td>
<td  align="left" class="OTHR<%# DataBinder.Eval(Container, "DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>4LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', 'yellow' ,7)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container, "DataItem.COLOR") %>',7)" 
STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container, "DataItem.TEL") %>
</SPAN>
</td>
<%-- 2014/11/12 H.Hosoda mod 改善対応2014№6 START --%>
<td align="left" class="OTHR<%# DataBinder.Eval(Container, "DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>7LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', 'yellow' ,7)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container, "DataItem.COLOR") %>',7)" 
STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container, "DataItem.NCUTEL") %>
</SPAN>
</td>
<%-- 2014/11/12 H.Hosoda mod 改善対応2014№6 END --%>
<td class="OTHR<%# DataBinder.Eval(Container, "DataItem.CLS") %>">
<SPAN id="bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>5LPG" 
onmouseover="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', 'yellow' ,7)" 
onmouseout ="fncBG('bc<%# DataBinder.Eval(Container, "DataItem.ROWNO") %>', '<%# DataBinder.Eval(Container, "DataItem.COLOR") %>',7)" 
STYLE="WIDTH: 100%">
<%# DataBinder.Eval(Container, "DataItem.ADDR") %>
</SPAN>
</td>
</tr>
</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>
			<INPUT id="hdnJUMP" type="hidden" name="hdnJUMP" runat="server"> <INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
			<INPUT id="hdnKEY_CLI_CD" type="hidden" name="hdnKEY_CLI_CD" runat="server"> <INPUT id="hdnKEY_HAN_CD" type="hidden" name="hdnKEY_HAN_CD" runat="server">
			<INPUT id="hdnKEY_USER_CD" type="hidden" name="hdnKEY_USER_CD" runat="server"> <INPUT id="hdnMOVE_NAME" type="hidden" name="hdnMOVE_NAME" runat="server">
			<INPUT id="hdnMOVE_KANAD" type="hidden" name="hdnMOVE_KANAD" runat="server"> <INPUT id="hdnMOVE_CLI_CD" type="hidden" name="hdnMOVE_CLI_CD" runat="server"><INPUT id="hdnMOVE_CLI_CD_NAME" type="hidden" name="hdnMOVE_CLI_CD_NAME" runat="server">
            <INPUT id="hdnMOVE_HAN_CD" type="hidden" name="hdnMOVE_HAN_CD" runat="server"> <INPUT id="hdnMOVE_HAN_CD_NAME" type="hidden" name="hdnMOVE_HAN_CD_NAME" runat="server">
            <%-- 2016/11/24 H.Mori add 改善対応2016 No2-2 START --%>
            <INPUT id="hdnMOVE_HAN_CD_TO" type="hidden" name="hdnMOVE_HAN_CD_TO" runat="server"> <INPUT id="hdnMOVE_HAN_CD_NAME_TO" type="hidden" name="hdnMOVE_HAN_CD_NAME_TO" runat="server">
			<%-- 2016/11/24 H.Mori add 改善対応2016 No2-2 END --%>
            <INPUT id="hdnMOVE_USER_CD" type="hidden" name="hdnMOVE_USER_CD" runat="server">
			<INPUT id="hdnMOVE_KANSCD" type="hidden" name="hdnMOVE_KANSCD" runat="server"> <INPUT id="hdnMOVE_TEL" type="hidden" name="hdnMOVE_TEL" runat="server">
			<INPUT id="hdnMOVE_MITOKBN" type="hidden" name="hdnMOVE_MITOKBN" runat="server">
			<INPUT id="hdnMOVE_NCUTEL" type="hidden" name="hdnMOVE_NCUTEL" runat="server"> <%-- 2014/12/02 H.Hosoda add 改善対応2014 №6 --%>
            <%-- 2013/12/09 T.Ono add 監視改善 --%>
            <INPUT id="hdnKEY_JA_CD" type="hidden" name="hdnKEY_JA_CD" runat="server"> <INPUT id="hdnMOVE_ADDR" type="hidden" name="hdnMOVE_ADDR" runat="server"> 
            <INPUT id="hdnMOVE_JA_CD" type="hidden" name="hdnMOVE_JA_CD" runat="server"> <INPUT id="hdnMOVE_JA_CD_NAME" type="hidden" name="hdnMOVE_JA_CD_NAME" runat="server">
            <%-- 2014/12/02 H.Hosoda add 改善対応2014 №6 START --%>
            <INPUT id="hdnKEY_HAN_GRP" type="hidden" name="hdnKEY_HAN_GRP" runat="server"> 
            <INPUT id="hdnMOVE_HAN_GRP" type="hidden" name="hdnMOVE_HAN_GRP" runat="server"> <INPUT id="hdnMOVE_HAN_GRP_NAME" type="hidden" name="hdnMOVE_HAN_GRP_NAME" runat="server">
            <%-- 2014/12/02 H.Hosoda add 改善対応2014 №6 END --%>
            <INPUT id="hdnScrollTop" type="hidden" name="hdnScrollTop" runat="server">
            <INPUT id="hdnMOVE_USER_FLG0" type="hidden" name="hdnMOVE_USER_FLG0" runat="server"><INPUT id="hdnMOVE_USER_FLG1" type="hidden" name="hdnMOVE_USER_FLG1" runat="server">
            <INPUT id="hdnMOVE_USER_FLG2" type="hidden" name="hdnMOVE_USER_FLG2" runat="server">
            <%-- 2015/12/11 H.Mori add 改善対応2015 №4 START --%>
            <INPUT id="hdnMOVE_HANBAI_KBN1" type="hidden" name="hdnMOVE_HANBAI_KBN1" runat="server"><INPUT id="hdnMOVE_HANBAI_KBN2" type="hidden" name="hdnMOVE_HANBAI_KBN2" runat="server">
            <INPUT id="hdnMOVE_HANBAI_KBN3" type="hidden" name="hdnMOVE_HANBAI_KBN3" runat="server"><INPUT id="hdnMOVE_HANBAI_KBN4" type="hidden" name="hdnMOVE_HANBAI_KBN4" runat="server">
            <INPUT id="hdnMOVE_HANBAI_KBN5" type="hidden" name="hdnMOVE_HANBAI_KBN5" runat="server"><INPUT id="hdnMOVE_HANBAI_KBN6" type="hidden" name="hdnMOVE_HANBAI_KBN6" runat="server">
            <%-- 2015/12/11 H.Mori add 改善対応2015 №4 END --%>
            <%-- 2016/11/22 H.Mori add 改善対応2016 No2-1 START --%>
            <INPUT id="hdnKEY_KINREN_GRP" type="hidden" name="hdnKEY_KINREN_GRP" runat="server"> 
            <INPUT id="hdnMOVE_KINREN_GRP" type="hidden" name="hdnMOVE_KINREN_GRP" runat="server"> <INPUT id="hdnMOVE_KINREN_GRP_NAME" type="hidden" name="hdnMOVE_KINREN_GRP_NAME" runat="server">
            <%-- 2016/11/22 H.Mori add 改善対応2016 No2-1 END --%>
            <%-- 2019/11/01 T.Ono add 監視改善2019 START --%>
            <INPUT id="hdnMOVE_CLI_CD_TO" type="hidden" name="hdnMOVE_CLI_CD_TO" runat="server"><INPUT id="hdnMOVE_CLI_CD_TO_NAME" type="hidden" name="hdnMOVE_CLI_CD_TO_NAME" runat="server">
			<INPUT id="hdnMOVE_JA_CD_CLI" type="hidden" name="hdnMOVE_JA_CD_CLI" runat="server">
            <INPUT id="hdnMOVE_HAN_CD_CLI" type="hidden" name="hdnMOVE_HAN_CD_CLI" runat="server">
            <INPUT id="hdnMOVE_HAN_CD_TO_CLI" type="hidden" name="hdnMOVE_HAN_CD_TO_CLI" runat="server">
            <%-- 2019/11/01 T.Ono add 監視改善2019 END --%>
		</form>
	</body>
</HTML>
