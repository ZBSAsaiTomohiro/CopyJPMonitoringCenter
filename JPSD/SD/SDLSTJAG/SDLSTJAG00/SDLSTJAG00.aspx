<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SDLSTJAG00.aspx.vb" Inherits="JPSD.SDLSTJAG00.SDLSTJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>緊急出動一覧</title>
	    <style type="text/css">
            .style1
            {
                width: 50px;
            }
        </style>
	</HEAD>
    <%-- 2013/12/10 T.Ono mod 監視改善2013
	<body> --%>
    <body onload="window_open();">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900" height="25">
							<tr>
								<td width="200">&nbsp;
								</td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;</td>
								<td width="70">&nbsp;</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
										type="button" value="戻る" name="btnExit" runat="server" tabindex="91">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td vAlign="bottom">
						<table cellSpacing="0" cellPadding="0" width="900">
							<tr>
								<td width="20"></td>
								<td vAlign="middle" width="500">
									<table cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">緊急出動一覧</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="400">
								</td>
							</tr>
						</table>
						<INPUT id="hdnSelectClick" type="hidden" name="hdnSelectClick" runat="server"><INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"><INPUT id="hdnLOGIN_FLG" type="hidden" name="hdnLOGIN_FLG" runat="server">
						<INPUT id="hdnMsgMode" type="hidden" name="hdnMsgMode" runat="server">
					</td>
				</tr>
			</table>
			<hr>
			<INPUT id="hdnKEY_KANSCD" type="hidden" name="hdnKEY_KANSCD" runat="server"><INPUT id="hdnKEY_SYONO" type="hidden" name="hdnKEY_SYONO" runat="server">
             <%-- 2013/12/11 T.Ono add 監視改善2013 --%>
            <INPUT id="hdnScrollTop" type="hidden" name="hdnScrollTop" runat="server">
            <INPUT id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server">            
            <INPUT id="hdnOTHER_KANSI_CENTER" type="hidden" name="hdnOTHER_KANSI_CENTER" runat="server">
			<table cellSpacing="1" cellPadding="0" width="970">
				<tr>
                    <%-- 2013/11/28 T.Ono mod 監視改善2013 START--%>
					<%-- <td colspan="6" height="5"></td> --%>
					<td width="32"height="5"></td>
					<td width="110"height="5"></td>
					<td width="220"height="5"></td>
					<td width="350"height="5"></td>
					<td width="65"height="5"></td>
					<td width="190"height="5"></td>
                    <%-- 2013/11/28 T.Ono mod 監視改善2013 END--%>
				<tr>
					<td></td>
					<td align="right">区分&nbsp;&nbsp;&nbsp;&nbsp;</td>
					<%-- 2013/11/28 T.Ono mod 監視改善2013 --%>
                    <%-- <td colspan="4"> --%>
                    <td>
						<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 START --%>
						<%-- <table class="W" cellpadding="1" cellspacing="0" width="200"> --%>
						<table class="W" cellpadding="1" cellspacing="0" width="215">
						<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 END --%>
							<tr>
								<td>
									<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 START --%>
									<%--<input id="rdoKBN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
										value="1" name="rdoKBN" runat="server" CHECKED onkeydown="fncFc(this)" onclick="fncRdoKBN_Chenge(this)"><label for="rdoKBN1">出動一覧&nbsp;&nbsp;</label>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="rdoKBN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
										value="2" name="rdoKBN" runat="server" onkeydown="fncFc(this)" onclick="fncRdoKBN_Chenge(this)"><label for="rdoKBN2">結果一覧&nbsp;&nbsp;</label> --%>
									<input id="rdoKBN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
										value="1" name="rdoKBN" runat="server" CHECKED onkeydown="fncFc(this)" onclick="fncRdoKBN_Chenge(this)"><label for="rdoKBN1">出動中一覧&nbsp;&nbsp;</label>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="rdoKBN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
										value="2" name="rdoKBN" runat="server" onkeydown="fncFc(this)" onclick="fncRdoKBN_Chenge(this)"><label for="rdoKBN2">出動結果一覧&nbsp;&nbsp;</label>
									 <%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 END --%>
								</td>
							</tr>
						</table>
					</td>
                    <%-- 2013/11/28 T.Ono add 監視改善2013 START--%>
                    <td align="right"><div id="divCLI" name="divCLI">クライアント名&nbsp;<asp:textbox id="txtCLI_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnCLI_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
										tabIndex="9" type="button" value="▼" name="btnCLI_CD" runat="server"> <INPUT id="hdnCLI_CD" type="hidden" name="hdnCLI_CD" runat="server">&nbsp;&nbsp;</div></td>
                    <td></td>
					<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 START --%>
					<%-- <td></td> --%>
					<td align="right" width="180">
						検索対象件数：<asp:textbox id="txtKEKKA_KENSU" tabIndex="-1" runat="server" BorderWidth="1px"
							BorderStyle="Solid" Width="40px" CssClass="c-rNM" style="TEXT-ALIGN: right"></asp:textbox>
					</td>
					<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 END --%>
                    <%-- 2013/11/28 T.Ono add 監視改善2013 END --%>
				</tr>
				<tr>
					<td width="30"></td>
					<td align="right" width="100">検索対象期間</td>
					<td width="200">
						<asp:textbox id="txtSIJIYMD_From" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
							tabIndex="2" runat="server" Width="80px" CssClass="c-f" MaxLength="8"></asp:textbox>
						&nbsp;～&nbsp;
						<asp:textbox id="txtSIJIYMD_To" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
							tabIndex="3" runat="server" Width="80px" CssClass="c-f" MaxLength="8"></asp:textbox>
					</td>
					<%-- 2013/11/28 T.Ono mod 監視改善2013 START --%>
                    <%-- <td width="100"></td>
					<td align="left" width="180"> --%>
                    <td  align="right"><div id="divJA" name="divJA">ＪＡ名&nbsp;<asp:textbox id="txtJA_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnJA_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
										tabIndex="10" type="button" value="▼" name="btnJA_CD" runat="server"> <INPUT id="hdnJA_CD" type="hidden" name="hdnJA_CD" runat="server">&nbsp;&nbsp;</div></td>
					<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 START --%>
					<%-- <td align="left" class="style1"> --%>
                    <%-- 2013/11/28 T.Ono mod 監視改善2013 END --%>
						<%--<input language="javascript" class="bt-JIK" id="btnSelect" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="4" type="button"
							value="検索" name="btnSelect" runat="server" Height="21px">
					</td> --%>
                    <td></td>
					<%-- 2014/10/20 H.Hosoda mod 2014改善開発 No10 END --%>
                    <%--2012/04/06 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
					<%--<td align="right" width="310">
						検索対象件数：<asp:textbox id="txtKEKKA_KENSU" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px"
							BorderStyle="Solid" Width="40px" CssClass="c-rNM" style="TEXT-ALIGN: right"></asp:textbox>
					</td>--%>
                    <%-- 2013/11/28 T.Ono mod 監視改善2013 --%>
                    <%-- <td align="right" width="310"> --%>
					<%-- 2014/10/20 H.Hosoda del 2014改善開発 No10 START --%>
                    <%-- <td align="right" width="180">
						検索対象件数：<asp:textbox id="txtKEKKA_KENSU" tabIndex="-1" runat="server" BorderWidth="1px"
							BorderStyle="Solid" Width="40px" CssClass="c-rNM" style="TEXT-ALIGN: right"></asp:textbox>
					</td> --%>
					<%-- 2014/10/20 H.Hosoda del 2014改善開発 No10 END --%>
				</tr>
				<%-- 2014/10/20 H.Hosoda add 2014改善開発 No10 START --%>
				<tr>
					<td width="30"></td>
					<td width="100"></td>
					<td width="200"></td>
                    <td  align="right"><div id="divGRP" name="divGRP">販売事業者&nbsp;<asp:textbox id="txtGROUP_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnGROUP_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
										tabIndex="11" type="button" value="▼" name="btnGROUP_CD" runat="server"> <INPUT id="hdnGROUP_CD" type="hidden" name="hdnGROUP_CD" runat="server">&nbsp;&nbsp;</div></td>
					<td align="left" class="style1">
						<input language="javascript" class="bt-JIK" id="btnSelect" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="4" type="button"
							value="検索" name="btnSelect" runat="server" Height="21px">
					</td>
					<td></td>
				</tr>
				<%-- 2014/10/20 H.Hosoda add 2014改善開発 No10 END --%>
				<tr>
					<td colspan="6" height="10"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="970">
				<tr>
					<td width="10"></td>
					<td width="960">
						<%-- 2013/11/28 T.Ono mod 監視改善2013 --%>
                        <%-- <table class="W" height="490" cellSpacing="0" cellPadding="0" width="960" border="1"> --%>
                        <table class="W" height="570" cellSpacing="0" cellPadding="0" width="960" border="1">
							<tr>
                                <%-- 2013/11/28 T.Ono mod 監視改善2013 --%>
								<%-- <td vAlign="middle" align="center" colSpan="8"><iframe id="ifList" tabIndex="-1" name="ifList" src="" frameBorder="0" width="950" height="490"></iframe></td> --%>
							    <td vAlign="middle" align="center" colSpan="8"><iframe id="Iframe1" tabIndex="-1" name="ifList" src="" frameBorder="0" width="950" height="570"></iframe></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
