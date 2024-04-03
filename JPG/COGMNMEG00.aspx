<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COGMNMEG00.aspx.vb" Inherits="JPG.COGMNMEG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>COGMNMEG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblScript" runat="server"></asp:Label><br>
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
								<td align="right" width="80">
									<input type="button" name="btnMenu000" class="bt-JIK" onblur="fncFo(this,6)" onfocus="fncFo(this,2);"
										tabIndex="99" value="終了" onclick="fncClick('COGMENUG00','');">
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
								<td width="20">&nbsp;</td>
								<td vAlign="middle" width="710">
									<table cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">一般消費者名簿メニュー</td>
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
			<br>
			<br>
            <table cellSpacing="0" cellPadding="0" width="1200">
				<tr>
					<td width="30" height="30"></td>
					<td width="870" height="30"></td>
				</tr>
				<tr>
					<td></td>
					<td>
                        <table cellSpacing="0" cellPadding="0" width="1120">
                            <tr>
                                <td width="280"><input type="button" name="btnMenu001" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="1" value="一般消費者名簿取込" onclick="fncClick('SBMEIJAG00','');"/></td>
                                <td width="280"><input type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="3" value="一般消費者名簿出力" onclick="fncClick('SBMEOJAG00','');"></td>
                                <td width="280"><input type="button" name="btnMenu009" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="5" value="販売店グループマスタ" onclick="fncClick('MSHATJAG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="2" value="JAグループ作成マスタ" onclick="fncClick('MSJAGJAG00','');"></td>
                                <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="4" value="販売事業者グループマスタ" onclick="fncClick('MSHAGJAG00','');"/></td>
                                <td width="280"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
                            <tr>
								<td width="280"></td>
								<td width="280"></td>
                                <td width="280"></td>
                                <td width="280"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
