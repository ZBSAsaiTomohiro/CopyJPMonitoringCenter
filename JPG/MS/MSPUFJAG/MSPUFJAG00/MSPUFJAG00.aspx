<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSPUFJAG00.aspx.vb" Inherits="JPG.MSPUFJAG00.MSPUFJAG00"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>プルダウン設定マスタ一覧</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblScript" runat="server"></asp:Label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
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
										tabIndex="96" type="button" value="終了" name="btnExit" runat="server">
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
											<td class="TITLE" vAlign="middle">プルダウン設定マスタ一覧</td>
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
