<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KEKESJAG00.aspx.vb" Inherits="JPG.KEKESJAG00.KEKESJAG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>欠損データ一覧</title>
	</HEAD>
	<body onload="window_onload();">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><br>
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="480">
							<tr>
								<td width="200">&nbsp;</td>
								<td width="80">
									<input class="bt-JIK" id="btnDelete" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnDelete_onclick();"
										tabIndex="94" type="button" value="削除" name="btnDelete" runat="server">
								</td>
								<td width="120">&nbsp;</td>
								<td width="80" align="right">
									<input class="bt-JIK" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
										tabIndex="96" type="button" value="終了" name="btnExit" runat="server" id="btnExit">
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
						<table id="Table3" cellSpacing="0" cellPadding="0" width="480">
							<tr>
								<td width="20"></td>
								<td vAlign="middle" width="290">
									<table id="Table4" cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">欠損データ一覧</td>
										</tr>
									</table>
								</td>
								<td width="170">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr>
			<center>
				<br>
				<br>
				<table class="W" height="400" cellSpacing="0" cellPadding="0" width="480" border="1">
					<TR>
						<td vAlign="middle" align="center"><iframe id="ifList" name="ifList" src="" frameBorder="0" width="480" height="400"></iframe></td>
					</TR>
				</table>
				<INPUT id="hdnKenSaku" type="hidden" name="hdnKenSaku" runat="server"><INPUT id="hdnDelKey" type="hidden" name="hdnDelKey" runat="server"><INPUT id="hdnDelCnt" type="hidden" name="hdnDelCnt" runat="server">
				<BR>
				<table cellSpacing="0" cellPadding="0" width="480">
					<TR>
						<td></td>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
