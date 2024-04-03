<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COGMNSSG00.aspx.vb" Inherits="JPG.COGMNSSG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>COGMNSSG00</title>
	</HEAD>
	<body onload="window_onload();">
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
											<td class="TITLE" vAlign="middle">システム管理メニュー</td>
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
			<table cellSpacing="0" cellPadding="0" width="900">
				<tr>
					<td width="30" height="30"></td>
					<td width="870" height="30"></td>
				</tr>
				<tr>
					<td></td>
					<td>
						<table cellSpacing="0" cellPadding="0" width="840">
							<tr>
								<td width="280">
									<input type="button" name="btnMenu001" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" tabIndex="1" value="実行履歴一覧" onclick="fncClick('SYBATJAG00','');"></td>
								<td width="280">
									<INPUT class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" onclick="fncClick('SYDIKJAG00','');" tabIndex="2" type="button" value="緊急時監視業務代行設定" name="btnMenu003"></td>
								<td width="280">
									<INPUT class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" onclick="fncClick('SYGETJAG00','');" tabIndex="3" type="button" value="データ整理" name="btnMenu004">
								</td>
							</tr>
							<tr>
								<td colspan="2" height="30">
									&nbsp;
								</td>
							</tr>
							<tr>
								<td>
									<span id="sp01">
										<!-- INPUT class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" onclick="" tabIndex="4" type="button" value="帳票データ作成処理" name="btnMenu002" -->
									</span>&nbsp;
									</td>
								<td height="24">
									&nbsp;<!--INPUT class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" onclick="fncClick('SYGETJAG00','');" tabIndex="2" type="button" value="データ整理" name="btnMenu004" -->
								</td>
							</tr>
							<tr>
								<td colspan="2" height="30">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
