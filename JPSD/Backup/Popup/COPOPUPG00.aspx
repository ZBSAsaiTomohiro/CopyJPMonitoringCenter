<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COPOPUPG00.aspx.vb" Inherits="JPSD.COPOPUPG00" EnableSessionState="ReadOnly" enableViewState="False" validateRequest="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
  		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
		<title>COPOPUPG00</title>
		<script language="JavaScript">
			// 2014/10/31 Hosoda del 1line ポップアップ表示幅変更
			//window.resizeTo(420,430);
			function window_open() {
				fncListOut("COPOPUFG00","ifList1");
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
				<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 START --%>
				<%-- <table width="340" cellpadding="0" cellspacing="0"> --%>
				<table width="100%" cellpadding="0" cellspacing="0">
				<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 END --%>
					<tr>
						<td class="W" height="300">
							<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 START --%>
							<%-- <iframe id="ifList1" tabindex="-1" name="ifList1" src="" frameBorder="0" width="360" height="300"></iframe> --%>
							<iframe id="ifList1" tabindex="-1" name="ifList1" src="" frameBorder="0" width="100%" height="300"></iframe>
							<%-- 2014/10/31 Hosoda mod ポップアップ表示幅変更 END --%>
						</td>
					</tr>
				</table>
			</center>
			<INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"> <INPUT id="hdnListCd" type="hidden" name="hdnListCd" runat="server">
			<INPUT type="hidden" id="hdnBackCode" name="hdnBackCode" runat="server"> <INPUT type="hidden" id="hdnBackName" name="hdnBackName" runat="server">
			<INPUT type="hidden" id="hbdBackFocs" name="hbdBackFocs" runat="server"><INPUT id="hbdBackScript" type="hidden" name="hbdBackScript" runat="server"><INPUT id="hdnPopType" type="hidden" name="hdnPopType" runat="server">
			<INPUT id="hdnCode1" type="hidden" name="hdnCode1" runat="server"> <INPUT id="hdnCode2" type="hidden" name="hdnCode2" runat="server"><INPUT id="hdnClear1" type="hidden" name="hdnClear1" runat="server"><INPUT id="hdnClear2" type="hidden" name="hdnClear2" runat="server"><INPUT id="hdnClear3" type="hidden" name="hdnClear3" runat="server"><INPUT id="hdnClear4" type="hidden" name="hdnClear4" runat="server">
			<INPUT id="hdnClear5" type="hidden" name="hdnClear5" runat="server"><INPUT id="hdnClear6" type="hidden" name="hdnClear6" runat="server">
            <%-- 2014/10/30 H.Hosoda add 2014改善開発 No11 START --%>
            <INPUT type="hidden" id="hdnBackNameOnly" name="hdnBackNameOnly" runat="server">
            <%-- 2014/10/30 H.Hosoda add 2014改善開発 No11 END --%>
		</form>
	</body>
</HTML>
