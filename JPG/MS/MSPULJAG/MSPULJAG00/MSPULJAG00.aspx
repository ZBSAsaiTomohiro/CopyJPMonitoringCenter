<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSPULJAG00.aspx.vb" Inherits="JPG.MSPULJAG00.MSPULJAG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSPULJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200"><input class="bt-JIK" id="btnSelect" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();"
										tabIndex="92" type="button" value="検索" name="btnSelect" runat="server"> <input class="bt-JIK" id="btnInsert" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnInsert_onclick();"
										tabIndex="93" type="button" value="新規" name="btnInsert" runat="server">
								</td>
								<td width="300">&nbsp;</td>
								<td width="220"><input class="bt-JIK" id="btnUpdate" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnUpdate_onclick();"
										tabIndex="91" type="button" value="登録" name="btnUpdate" runat="server"> <input class="bt-JIK" id="btnDelete" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnDelete_onclick();"
										tabIndex="94" type="button" value="削除" name="btnDelete" runat="server">
								</td>
								<td width="70"><input class="bt-JIK" id="btnClear" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnClear_onclick();"
										tabIndex="95" type="button" value="取消" name="btnClear" runat="server">
								</td>
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
								<td width="20"></td>
								<td vAlign="middle" width="710">
									<table cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">プルダウン設定マスタ</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="170">作成日：<asp:textbox id="txtAYMD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
										Width="72px" CssClass="c-RO"></asp:textbox><br>
									更新日：<asp:textbox id="txtUYMD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
										Width="72px" CssClass="c-RO"></asp:textbox>
								</td>
							</tr>
						</table>
						<INPUT id="hdnTIME" type="hidden" name="hdnTIME" runat="server"><INPUT id="hdnKBN" type="hidden" name="hdnKBN" runat="server">
						<INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"><INPUT id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server">
						<INPUT id="hdnPopType" type="hidden" name="hdnPopType" runat="server">
					</td>
				</tr>
			</table>
			<hr>
			<table cellSpacing="2" cellPadding="3" width="900">
				<tr>
					<td width="130" height="30"></td>
					<td width="70" height="30"></td>
					<td width="700" height="30"></td>
				</tr>
				<tr>
					<td class="TXTKY" align="right">区分</td>
					<td colSpan="2">
						<table cellSpacing="0" cellPadding="0">
							<tr>
								<td><asp:textbox id="txtKBN" runat="server" Width="30px" CssClass="c-h" onkeydown="fncFc(this)" onblur="fncFcChange(this,3)"
										onfocus="fncFcChange(this,2)" tabIndex="1" MaxLength="2"></asp:textbox></td>
								<td><input class="bt-KS" id="btnKenKBN" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnPopup_onclick('1');"
										tabIndex="2" type="button" value="..." name="btnKenKBN" runat="server">&nbsp;&nbsp;&nbsp;
								</td>
								<%--<td><asp:textbox id="txtKBN_NAME" runat="server" CssClass="c-rNM" Width="200px" ReadOnly="True" BorderStyle="Solid"
										BorderWidth="1px" tabIndex="-1"></asp:textbox></td>--%>
                                <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
								<td><asp:textbox id="txtKBN_NAME" runat="server" CssClass="c-rNM" Width="200px" BorderStyle="Solid"
										BorderWidth="1px" tabIndex="-1"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="TXTKY" align="right">コード</td>
					<td colSpan="2">
						<table cellSpacing="0" cellPadding="0">
							<tr>
								<td><asp:textbox id="txtCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
										tabIndex="3" runat="server" Width="48px" CssClass="c-h" MaxLength="6"></asp:textbox></td>
								<td><INPUT class="bt-KS" id="btnKenCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnPopup_onclick('2');"
										tabIndex="4" type="button" value="..." name="btnKenCD" runat="server">&nbsp;&nbsp;&nbsp;
								</td>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="4">&nbsp;</td>
				</tr>
				<tr>
					<td align="right" colspan="2">名称</td>
					<td><asp:textbox id="txtNAME" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="5" runat="server" Width="800px" CssClass="c-hI" MaxLength="100"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right" colspan="2">表示順序</td>
					<td><asp:textbox id="txtDISP_NO" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="6" runat="server" Width="32px" CssClass="c-f" MaxLength="3" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right" colspan="2">内容１</td>
					<td><asp:textbox id="txtNAIYO1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="7" runat="server" Width="610px" CssClass="c-fI" MaxLength="50"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right" colspan="2">内容２</td>
					<td><asp:textbox id="txtNAIYO2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="8" runat="server" Width="610px" CssClass="c-fI" MaxLength="50"></asp:textbox></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
