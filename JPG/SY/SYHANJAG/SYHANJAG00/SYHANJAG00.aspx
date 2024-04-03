<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SYHANJAG00.aspx.vb" Inherits="JPG.SYHANJAG00.SYHANJAG00" EnableSessionState="ReadOnly" enableViewState="False" enableViewStateMac="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SYHANJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200"><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server">
									<asp:Label id="lblScript" runat="server"></asp:Label>
								</td>
								<td width="300">&nbsp;</td>
								<td width="220">
								</td>
								<td width="70">
								</td>
								<td width="30">&nbsp;</td>
								<td width="80" align="right">
									<input name="btnExit" id="btnExit" type="button" class="bt-JIK" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();" tabIndex="96" value="終了">
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
								<td vAlign="middle" width="710">
									<table cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">販売管理締処理</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" width="170" align="right">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr>
			<table width="400" cellpadding="5" cellspacing="0">
				<tr>
					<td width="150" height="30"></td>
					<td width="250"></td>
				</tr>
				<tr>
					<td align="right">作成区分</td>
					<td>
						<table cellSpacing="0" cellPadding="0">
							<tr>
								<td class="w" height="20">
									<table cellSpacing="0" cellPadding="0" height="27">
										<tr>
											<td valign="middle" width="20">
												<input value="1" name="rdoKBN" id="rdoKBN1" onkeydown="fncFc(this)" tabIndex="1" onblur="fncFo(this,4)"
													onfocus="fncFo(this,2)" type="radio" checked runat="server" onclick="fncKbnChange();"></td>
											<td valign="middle"><label for="rdoKBN1">通常作成&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
											<td valign="middle">
												<input value="2" name="rdoKBN" id="rdoKBN2" onkeydown="fncFc(this)" tabIndex="1" onblur="fncFo(this,4)"
													onfocus="fncFo(this,2)" type="radio" runat="server" onclick="fncKbnChange();"></td>
											<td valign="middle"><label for="rdoKBN2">再作成&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="25"></td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="right">県コード</td>
					<td>
						<cc1:ctlcombo id="cboKENCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="2" runat="server" CssClass="cb-h" Width="100px" onChange="return cboKen_change();"></cc1:ctlcombo>
					</td>
				<tr>
					<td align="right">対象年月</td>
					<td>
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
						<%--<asp:textbox id="txtTAISYO" tabIndex="-1" runat="server" CssClass="c-RO" Width="75px" BorderStyle="Solid"
							BorderWidth="1px" ReadOnly="True"></asp:textbox>--%>
                        <asp:textbox id="txtTAISYO" tabIndex="-1" runat="server" CssClass="c-RO" Width="75px" BorderStyle="Solid"
							BorderWidth="1px"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td align="right">集計期間</td>
					<td>
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
						<%--<asp:textbox id="txtSYUKEIF" tabIndex="-1" runat="server" CssClass="c-RO" Width="75px" BorderStyle="Solid"
							BorderWidth="1px" ReadOnly="True"></asp:textbox>&nbsp;～&nbsp;--%>
                        <asp:textbox id="txtSYUKEIF" tabIndex="-1" runat="server" CssClass="c-RO" Width="75px" BorderStyle="Solid"
							BorderWidth="1px"></asp:textbox>&nbsp;～&nbsp;
						<asp:TextBox id="txtSYUKEIT" onkeydown="fncFc(this)" onblur="fncFo_date(this,3)" onfocus="fncFo_date(this,2)"
							runat="server" Width="75px" CssClass="c-h" tabIndex="3" MaxLength="8"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td><input type="button" value="実行" class="bt-JIK" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" id="btnJikkou" name="btnJikkou" onclick="return btnJikkou_onclick();"
							runat="server" tabIndex="4"></td>
				</tr>
			</table>
			<INPUT id="hdnTAISYO" type="hidden" name="hdnTAISYO" runat="server"><INPUT id="hdnTAISYOP1" type="hidden" name="hdnTAISYOP1" runat="server"><INPUT id="hdnSYUKEIF" type="hidden" name="hdnSYUKEIF" runat="server"><INPUT id="hdnSYUKEIT" type="hidden" name="hdnSYUKEIT" runat="server"><INPUT id="hdnSYUKEIFP1" type="hidden" name="hdnSYUKEIFP1" runat="server"><INPUT id="hdnSYUKEITP1" type="hidden" name="hdnSYUKEITP1" runat="server">
		</form>
	</body>
</HTML>
