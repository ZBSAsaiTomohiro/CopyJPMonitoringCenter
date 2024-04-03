<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SYDIKJAG00.aspx.vb" Inherits="JPG.SYDIKJAG00.SYDIKJAG00" EnableSessionState="ReadOnly" enableViewState="False" enableViewStateMac="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SYDIKJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label>
			<INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><br>
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table id="Table2" cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200">&nbsp;</td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;</td>
								<td width="70">&nbsp;</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
										type="button" value="終了" name="btnExit" runat="server">
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
						<table id="Table3" cellSpacing="0" cellPadding="0" width="900">
							<tr>
								<td width="20"></td>
								<td vAlign="middle" width="710">
									<table id="Table4" cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">緊急時監視業務代行設定</td>
											<input id="hdnMODE" type="hidden" name="hdnMODE" runat="server"> <input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server">
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
			<table id="Table5" cellSpacing="2" cellPadding="0" width="900">
				<tr>
					<td class="EXPOSI">
						この画面は、監視センターのルータ障害等、監視センターが<BR>
						ネットワークに接続できない場合、他の監視センターが処理を代行するものです。<BR>
						通常運用時は、絶対に操作しないでください。
					</td>
				</tr>
			</table>
			<table width="900" cellpadding="5" cellspacing="0">
				<tr>
					<td width="180" height="30"></td>
					<td width="280" height="30"></td>
					<td width="500" height="30"></td>
				</tr>
				<tr>
					<td align="right" height="25" class="TXTKY">監視センターコード</td>
					<td colspan="2">
						<cc1:ctlcombo id="cboKANSCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="1" runat="server" CssClass="cb" Width="200px"></cc1:ctlcombo>
						<input id="hdnKANSICD" name="hdnKANSICD" type="hidden" runat="server">
					</td>
				</tr>
				<tr>
					<td colspan="2" align="center" class="ARROW">↓</td>
					<td></td>
				</tr>
				<tr>
					<td align="right" height="25" class="TXTKY">代行監視センターコード</td>
					<td colspan="2">
						<cc1:ctlcombo id="cboDAIKOKANSCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="2" runat="server" CssClass="cb" Width="200px"></cc1:ctlcombo>
						<input id="hdnDAI_KANSI_CD" name="hdnDAI_KANSI_CD" type="hidden" runat="server">
					</td>
				<tr>
					<td colspan="2">&nbsp;</td>
					<td></td>
				</tr>
				<tr>
					<td colspan="2">&nbsp;</td>
					<td></td>
				</tr>
				<tr>
					<td colspan="2" align="center">
						<input class="bt-LNG" id="btnSET" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnSET_onclick();"
							tabIndex="3" type="button" value="代行設定" name="btnSET" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;
						<input class="bt-LNG" id="btnCANCEL" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnCANCEL_onclick();"
							tabIndex="4" type="button" value="代行解除" name="btnCANCEL" runat="server">
					</td>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
