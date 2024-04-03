<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COLOGING00.aspx.vb" Inherits="JPSD.COLOGING00" EnableSessionState="ReadOnly" enableViewState="False" enableViewStateMac="False" enableEventValidation="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ログオン画面</title>
		<script language="javascript">
// 2012/06/26 NEC ou Del Str
//		var obj;
//		obj=document.referrer;
//		if (obj != '') {
//		    parent.location.href = '/JPSD/COGBASEG00.aspx';
//        }
// 2012/06/26 NEC ou Del End
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200" height="20">&nbsp;
								</td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;
								</td>
								<td width="70">&nbsp;
								</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80">&nbsp;
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
											<td class="TITLE" vAlign="middle">認証コード入力</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="170"><br>
									&nbsp;
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr>
			<BR>
			<BR>
			<BR>
			<BR>
			<table cellSpacing="0" cellPadding="0">
				<tr>
					<td width="50" height="50" valign="top"></td>
					<td valign="top">
						<SPAN style="FONT-WEIGHT: bold; FONT-SIZE: 20px; FILTER: Glow(color=yellow); WIDTH: 100%; COLOR: green">認証コードとパスワードを入力してください</SPAN>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<table cellSpacing="0" cellPadding="0">
							<tr>
								<td class="W">
									<table cellSpacing="2" cellPadding="2">
										<tr>
											<td colspan="2" height="3"></td>
										</tr>
										<tr>
											<td width="90" align="right">出動会社コード</td>
											<td width="180"><INPUT class="c-f" id="txtSHUTU_CD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
													type="text" name="txtSHUTU_CD" runat="server" tabIndex="1"></td>
										</tr>
										<tr>
											<td align="right">拠点コード</td>
											<td><INPUT class="c-f" id="txtKYOTEN_CD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
													type="text" name="txtKYOTEN_CD" runat="server" tabIndex="2"></td>
										</tr>
										<tr>
											<td colspan="2" height="10"></td>
										</tr>
										<tr>
											<td align="right">パスワード</td>
											<td><INPUT class="c-f" id="txtUserPass" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
													type="password" name="txtUserPass" runat="server" tabIndex="3"></td>
										</tr>
										<tr>
											<td colspan="2" height="3"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="30">&nbsp;</td>
							</tr>
							<tr>
								<td class="MSG"><asp:label id="lblMsg" runat="server" Width="408px" ForeColor="Red"></asp:label></td>
							</tr>
						</table>
						<table>
							<tr>
								<td height="30"></td>
							</tr>
						</table>
						<INPUT class="bt-RNW" id="btnLogon" type="submit" value="ＯＫ" name="btnLogon" runat="server"
							onblur="fncFo(this,5)" onfocus="fncFo(this,2)" tabIndex="4"> &nbsp;&nbsp; <INPUT class="bt-RNW" id="btnCancel" type="reset" value="キャンセル" name="btnCancel" runat="server"
							onblur="fncFo(this,5)" onfocus="fncFo(this,2)" tabIndex="5">
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
