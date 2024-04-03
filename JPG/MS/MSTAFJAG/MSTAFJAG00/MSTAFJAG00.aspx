<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTAFJAG00.aspx.vb" Inherits="JPG.MSTAFJAG00.MSTAFJAG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>’S“–ŽÒƒ}ƒXƒ^ˆê——</title>

<Style>
.OTHR{font-size: 10pt; HEIGHT: 15pt}					
</Style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label>
			<INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"> <INPUT id="hdnKenSaku" type="hidden" name="hdnKenSaku" runat="server">
			<INPUT id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server">
			
			<!-- 2008/07/31 T.Watabe add -->
			<INPUT id="hdnKEY_KBN" type="hidden" name="hdnKEY_KBN" runat="server">
			<INPUT id="hdnKEY_KURACD" type="hidden" name="hdnKEY_KURACD" runat="server">
			<INPUT id="hdnKEY_CODE" type="hidden" name="hdnKEY_CODE" runat="server">
            <%-- 2016/02/19 H.Mori add 2015‰ü‘PŠJ”­ ‡‚9--%>
            <INPUT id="hdnKEY_GROUPCD" type="hidden" name="hdnKEY_GROUPCD" runat="server">
			<INPUT id="hdnKEY_JACD" type="hidden" name="hdnKEY_JACD" runat="server">
            <%-- 2015/11/01 W.GANEKO add 2015‰ü‘PŠJ”­ ‡‚9--%>
			<INPUT id="hdnKEY_TANTOTEL" type="hidden" name="hdnKEY_TANTOTEL" runat="server">
			
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200">&nbsp;</td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;</td>
								<td width="70">&nbsp;</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
										tabIndex="96" type="button" value="–ß‚é" name="btnExit" runat="server">
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
								<td width="16"></td>
								<td vAlign="middle" width="710">
									<table cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">’S“–ŽÒƒ}ƒXƒ^ˆê——</td>
										</tr>
									</table>
								</td>
								<td height="44"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr>
			<asp:Label id="lblHtml" runat="server"></asp:Label>
		</form>
	</body>
</HTML>
