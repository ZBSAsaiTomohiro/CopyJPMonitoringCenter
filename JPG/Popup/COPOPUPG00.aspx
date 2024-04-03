<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COPOPUPG00.aspx.vb" Inherits="JPG.COPOPUPG00" EnableSessionState="ReadOnly" enableViewState="False" validateRequest="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
  		<META http-equiv="Content-Type" content="text/html; charset=shift_jis">
		<title>COPOPUPG00</title>
		<script language="JavaScript">
			// 2014/11/04 Hosoda del 1line ポップアップ表示幅変更
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
				<%-- 2014/11/04 Hosoda mod ポップアップ表示幅変更 START --%>
				<%-- <table width="340" cellpadding="0" cellspacing="0">
					<tr>
						<td class="W" height="300">
							<iframe id="ifList1" tabindex="-1" name="ifList1" src="" frameBorder="0" width="360" height="300"></iframe>
						</td>
					</tr>
				</table> --%>
				<table width="100%" cellpadding="0" cellspacing="0">
					<tr>
						<td class="W" height="300">
							<iframe id="ifList1" tabindex="-1" name="ifList1" src="" frameBorder="0" width="100%" height="300"></iframe>
						</td>
					</tr>
				</table>				
				<%-- 2014/11/04 Hosoda mod ポップアップ表示幅変更 END --%>
			</center>
			<INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"> <INPUT id="hdnListCd" type="hidden" name="hdnListCd" runat="server">
			<INPUT type="hidden" id="hdnBackCode" name="hdnBackCode" runat="server"> <INPUT type="hidden" id="hdnBackName" name="hdnBackName" runat="server">
			<INPUT type="hidden" id="hbdBackFocs" name="hbdBackFocs" runat="server"><INPUT id="hbdBackScript" type="hidden" name="hbdBackScript" runat="server"><INPUT id="hdnPopType" type="hidden" name="hdnPopType" runat="server">
			<INPUT id="hdnCode1" type="hidden" name="hdnCode1" runat="server"> <INPUT id="hdnCode2" type="hidden" name="hdnCode2" runat="server"><INPUT id="hdnClear1" type="hidden" name="hdnClear1" runat="server"><INPUT id="hdnClear2" type="hidden" name="hdnClear2" runat="server"><INPUT id="hdnClear3" type="hidden" name="hdnClear3" runat="server"><INPUT id="hdnClear4" type="hidden" name="hdnClear4" runat="server">
			<INPUT id="hdnClear5" type="hidden" name="hdnClear5" runat="server"><INPUT id="hdnClear6" type="hidden" name="hdnClear6" runat="server">
			<INPUT id="hdnClear7" type="hidden" name="hdnClear7" runat="server"><INPUT id="hdnClear8" type="hidden" name="hdnClear8" runat="server"> <%-- 2014/12/11 Hosoda add クリアオブジェクト用エリア追加 --%>
			<INPUT id="hdnClear9" type="hidden" name="hdnClear9" runat="server"><INPUT id="hdnClear10" type="hidden" name="hdnClear10" runat="server"> <%-- 2015/11/04 w.ganeko クリアオブジェクト用エリア追加 --%>
			<INPUT id="hdnClear11" type="hidden" name="hdnClear11" runat="server"><INPUT id="hdnClear12" type="hidden" name="hdnClear12" runat="server"> <%-- 2014/12/11 Hosoda add クリアオブジェクト用エリア追加 --%>
			<INPUT id="hdnClear13" type="hidden" name="hdnClear13" runat="server"><INPUT id="hdnClear14" type="hidden" name="hdnClear14" runat="server"> <%-- 2014/12/11 Hosoda add クリアオブジェクト用エリア追加 --%>
            <INPUT id="hdnCode3" type="hidden" name="hdnCode3" runat="server"> <%-- 2014/12/04 Hosoda add 絞込み条件用エリア追加 --%>
            <INPUT id="hdnCode4" type="hidden" name="hdnCode4" runat="server"> <%-- 2016/11/21 H.Mori add 絞込み条件用エリア追加 監視改善2016 No2-1 --%>
            <INPUT id="hdnCode5" type="hidden" name="hdnCode5" runat="server"> <%-- 2019/11/01 T.Ono add 監視改善2019 No1 --%>
            <INPUT type="hidden" id="hdnBackCode2" name="hdnBackCode2" runat="server"><INPUT type="hidden" id="hdnBackName2" name="hdnBackName2" runat="server">
            <INPUT type="hidden" id="hdnBackMode" name="hdnBackMode" runat="server"><%-- 2019/11/01 w.ganeko add 2019監視改善 No2--%>
		</form>
	</body>
</HTML>
