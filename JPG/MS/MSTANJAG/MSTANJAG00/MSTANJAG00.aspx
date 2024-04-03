<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTANJAG00.aspx.vb" Inherits="JPG.MSTANJAG00.MSTANJAG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSTANJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><INPUT id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server"><br>
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
											<td class="TITLE" vAlign="middle">担当者マスタ</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="170">作成日：<asp:textbox id="txtAYMD" tabIndex="-1" runat="server" CssClass="c-RO" Width="72px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><br>
									更新日：<asp:textbox id="txtUYMD" tabIndex="-1" runat="server" CssClass="c-RO" Width="72px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox>
								</td>
							</tr>
						</table>
						<INPUT id="hdnKBN" type="hidden" name="hdnKBN" runat="server"><INPUT id="hdnTIME" type="hidden" name="hdnTIME" runat="server">
					</td>
				</tr>
			</table>
			<hr>
			<table cellSpacing="0" cellPadding="5" width="900">
				<tr>
					<td width="120" height="30"></td>
					<td width="280" height="30"><INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"></td>
					<td width="500" height="30"></td>
				</tr>
				<tr>
					<td class="TXTKY" align="right" height="25">区分</td>
					<td colSpan="2">
						<table height="25" cellSpacing="0" cellPadding="0" width="400">
							<tr>
								<td class="w" height="20">
									<table height="27" cellSpacing="0" cellPadding="0">
										<tr>
											<td vAlign="middle"><input id="rdoKBN1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
													onclick="fncTanto(this,0)" tabIndex="1" type="radio" CHECKED value="1" name="rdoKBN" runat="server"></td>
											<td vAlign="middle"><label for="rdoKBN1">ＪＡ支所担当者&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
											<td vAlign="middle"><input id="rdoKBN2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
													onclick="fncTanto(this,0)" tabIndex="1" type="radio" value="2" name="rdoKBN" runat="server"></td>
											<td vAlign="middle"><label for="rdoKBN2">監視センター担当者&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
											<td vAlign="middle"><input id="rdoKBN3" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
													onclick="fncTanto(this,0)" tabIndex="1" type="radio" value="3" name="rdoKBN" runat="server"></td>
											<td vAlign="middle"><label for="rdoKBN3">出動会社担当者&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<INPUT id="hdnTANKBN" type="hidden" name="hdnTANKBN" runat="server"> <INPUT id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server">
					</td>
				</tr>
				<tr>
					<td colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="900">
							<tr>
								<td class="TXTKY" align="right" width="160"><span id="sp1">クライアントコード&nbsp;&nbsp;</span></td>
                                <%--2012/04/03 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
								<%--<td width="740"><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
										BorderWidth="1px" ReadOnly="True"></asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
										tabIndex="2" type="button" value="▼" name="btnKURACD" runat="server"> <INPUT id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server">
								</td>--%>
								<td width="740"><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
										tabIndex="2" type="button" value="▼" name="btnKURACD" runat="server"> <INPUT id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="TXTKY" align="right"><asp:label id="lblCODE" runat="server" Width="150"></asp:label></td>
                    <%--2012/04/03 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                    <%--<td><asp:textbox id="txtCODE" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid"
							BorderWidth="1px" ReadOnly="True"></asp:textbox><input class="bt-KS" id="btnCODECD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="3" type="button" value="▼" name="btnCODECD" runat="server"> <INPUT id="hdnCODE" type="hidden" name="hdnCODE" runat="server">
					</td>--%>
					<td><asp:textbox id="txtCODE" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid"
							BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnCODECD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="3" type="button" value="▼" name="btnCODECD" runat="server"> <INPUT id="hdnCODE" type="hidden" name="hdnCODE" runat="server">
					</td>
					<td></td>
				</tr>
				<tr>
					<td class="TXTKY" align="right" height="25">担当者コード</td>
					<td><asp:textbox id="txtTANCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="4" runat="server" CssClass="c-k" Width="56px" MaxLength="4"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td align="right" height="25">担当者名漢字</td>
					<td><asp:textbox id="txtTANNM" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="5" runat="server" CssClass="c-hI" Width="400px" MaxLength="30"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td align="right" height="25">電話番号１</td>
					<td><asp:textbox id="txtRENTEL1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="6" runat="server" CssClass="c-f" Width="130px" MaxLength="15"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td align="right" height="25">電話番号２</td>
					<td><asp:textbox id="txtRENTEL2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="7" runat="server" CssClass="c-f" Width="130px" MaxLength="15"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td align="right" height="25">FAX番号</td>
					<td><asp:textbox id="txtFAXNO" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="8" runat="server" CssClass="c-f" Width="130px" MaxLength="15"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td align="right" height="25">表示順序</td>
					<td><asp:textbox id="txtDISP_NO" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="9" runat="server" CssClass="c-f" Width="40px" MaxLength="3"></asp:textbox></td>
					<td></td>
				</tr>
				<tr>
					<td align="right" height="25">備考</td>
					<td><asp:textbox id="txtBIKO" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="10" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox></td>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
