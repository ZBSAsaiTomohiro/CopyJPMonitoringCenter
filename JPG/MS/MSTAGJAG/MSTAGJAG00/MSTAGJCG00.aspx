<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTAGJCG00.aspx.vb" Inherits="MSTAGJAG00.MSTAGJCG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
  		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
		<title>MSTAGJCG00</title>
		<script language="JavaScript">
			window.resizeTo(420,430);
			function window_open() {
				fncListOut("MSTAGJBG00","ifList1");
			}
		</script>
	</HEAD>
	<body onload="window_open();document.Form1.focus();">
		<form id="Form1" method="post" runat="server">
			<center><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT>
				<br>
				<br>
				<asp:Label id="lblScript" runat="server"></asp:Label>
				<table>
					<tr>
						<td class="TITLE">
							<u>
								<asp:Label id="lblListName" runat="server"></asp:Label>
							</u>
						</td>
					</tr>
				</table>
				<br>
				<br>
				<table width="340" cellpadding="0" cellspacing="0">
					<tr>
						<td class="W" height="300">
							<iframe id="ifList1" tabindex="-1" name="ifList1" src="" frameBorder="0" width="360" height="300"></iframe>
						</td>
					</tr>
				</table>
			</center>
            <INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server">
            <INPUT id="hdnCode1" type="hidden" name="hdnCode1" runat="server">
		</form>
	</body>
</HTML>
