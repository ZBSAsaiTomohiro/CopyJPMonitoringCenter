<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTAEJAG00.aspx.vb" Inherits="JPG.MSTAEJAG00.MSTAEJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSTAEJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><br>
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
										type="button" value="終了" name="btnExit" runat="server" tabindex="91">
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
											<td class="TITLE" vAlign="middle">ＪＡ担当者連絡先エクセル出力</td>
										</tr>
									</table>
								</td>
								<td width="170">&nbsp;</td>
							</tr>
						</table>
						<INPUT id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server"><INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server">
					</td>
				</tr>
			</table>
			<hr>
			<table id="Table5" cellSpacing="1" cellPadding="2" width="900">
				<tr>
					<td width="10" height="30"></td>
					<td width="50" height="30"></td>
					<td width="30" height="30"></td>
					<td width="340" height="30"></td>
					<td width="480" height="30"></td>
				</tr>
				<tr>
					<td align="right"><FONT face="MS UI Gothic"></FONT></td>
					<td align="right" colSpan="2">クライアント</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
					<%--<td><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
							tabIndex="1" type="button" value="▼" name="btnKURACD" runat="server">
					</td>--%>
                    <td><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
							tabIndex="1" type="button" value="▼" name="btnKURACD" runat="server">
					</td>
					<td><INPUT id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server"></td>
				</tr>
				<tr>
					<td align="right"><FONT face="MS UI Gothic"></FONT></td>
					<td align="right" colSpan="2">ＪＡ</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
					<%--<td><asp:textbox id="txtJACD" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnKen1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="3" type="button" value="▼" name="btnKen1" runat="server"></td>--%>
                    <td><asp:textbox id="txtJACD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnKen1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="3" type="button" value="▼" name="btnKen1" runat="server"></td>
					<td><INPUT id="hdnJACD" type="hidden" name="hdnJACD" runat="server"></td>
				</tr>
				<tr>
					<td colSpan="5" height="5"></td>
				</tr>
				<tr>
					<td colSpan="3"></td>
					<td colSpan="2"><INPUT language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="10" type="button"
							value="EXCEL出力" name="btnSelect" runat="server">
					</td>
				</tr>
				<tr>
					<td colSpan="5" height="50"></td>
				</tr>
				<tr>
					<td colSpan="3">&nbsp;</td>
					<td colSpan="2"><a href="MSTAEJAX00.xls" target="_blank"><img src="../../../Script/icon_xls.gif" border="0">ＪＡ毎連絡先シート作成エクセル</a>(保存ダウンロード後、開きなおして実行して下さい)</td>
				</tr>
				<tr>
					<td colSpan="3">&nbsp;</td>
					<td colSpan="2"><a href="MSTAEJAX00.zip" target="_blank"><img src="../../../Script/icon_xls.gif" border="0">ＪＡ毎連絡先シート作成エクセル</a>(圧縮ファイル)</td>
				</tr>
			</table>
			<br>
			<br>
			&nbsp;
		</form>
	</body>
</HTML>
