<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTASJAG00.aspx.vb" Inherits="MSTASJAG00.MSTASJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
        <%-- 2015/11/01 W.GANEKO MOD 2015改善開発 №9 --%>
		<title>担当者マスタ一覧</title>
	</HEAD>
	<body>
        <%-- 2015/11/01 W.GANEKO MOD 2015改善開発 №9 --%>
		<%-- %>form id="Form1" method="post" runat="server" action="MSTASJAG00.aspx?CLFLG="> --%>
		<form id="Form1" method="post" runat="server" action="../../../MS/MSTASJAG/MSTASJAG00/MSTASJAG00.aspx?CLFLG=">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><INPUT id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server"><br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200"><input class="bt-JIK" id="btnSelect" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();"
										tabIndex="92" type="button" value="検索" name="btnSelect" runat="server">&nbsp;
								</td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;
								</td>
								<td width="70">&nbsp;
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
											<td class="TITLE" vAlign="middle">担当者マスタ一覧</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="170"><br>
									&nbsp;
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
                                <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
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
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
					<%--<td>
						<asp:textbox id="txtCODE" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid"
							BorderWidth="1px" ReadOnly="True"></asp:textbox><input class="bt-KS" id="btnCODECD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="3" type="button" value="▼" name="btnCODECD" runat="server"> 
						<INPUT id="hdnCODE" type="hidden" name="hdnCODE" runat="server">
					</td>--%>
                    <td>
						<asp:textbox id="txtCODE" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid"
							BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnCODECD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="3" type="button" value="▼" name="btnCODECD" runat="server"> 
						<INPUT id="hdnCODE" type="hidden" name="hdnCODE" runat="server">
					</td>
					<td>
						<!-- 2008/07/31 T.Watabe add -->
						<INPUT id="hdnKEY_KBN" type="hidden" name="hdnKEY_KBN" runat="server"> 
						<INPUT id="hdnKEY_KURACD" type="hidden" name="hdnKEY_KURACD" runat="server">
						<INPUT id="hdnKEY_CODE" type="hidden" name="hdnKEY_CODE" runat="server">
                        <%-- 2016/02/19 H.Mori add 2015改善開発 №9--%>
                        <INPUT id="hdnKEY_GROUPCD" type="hidden" name="hdnKEY_GROUPCD" runat="server">
						<INPUT id="hdnKEY_JACD" type="hidden" name="hdnKEY_JACD" runat="server">
                        <%-- 2015/11/01 W.GANEKO add 2015改善開発 №9--%>
						<INPUT id="hdnKEY_TANTOTEL" type="hidden" name="hdnKEY_TANTOTEL" runat="server">
					</td>
				</tr>
                <%--mori add --%>
                <tr>
					<td class="TXTKY" align="right"  style="font-size:13px;"><span id="sp5">グループコード・名称</span></td>
                    <td><asp:textbox id="txtGROUPCD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid"
							BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnGROUPCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabIndex="3" type="button" value="▼" name="btnGROUPCD" runat="server"> <INPUT id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server">
						<%--  <INPUT id="hdnGROUPCD_MOTO" type="hidden" name="hdnGROUPCD_MOTO" runat="server"> --%>
					</td>
				</tr>
                <%--mori add --%>
				<tr>
					<%-- <td class="TXTKY" align="right">ＪＡコード</td> 2016/2/03 H.Mori mod --%>
					<td class="TXTKY" align="right"><span id="sp2">ＪＡコード</span></td>
                    <td>
						<asp:textbox id="txtJACD" tabIndex="9" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox><span id="sp3">※前方一致</span>
					</td>
					<td></td>
				</tr>
                <%-- 2015/11/01 W.GANEKO add 2015改善開発 №9 start --%>
				<tr>
                    <%-- <td class="TXTKY" align="right">ＪＡ・担当者連絡先</td> 2016/2/08 H.Mori mod --%>
					<td class="TXTKY" align="right"><span id="sp4">ＪＡ・担当者連絡先</span></td>
					<td>
						<asp:textbox id="txtTantoTel" tabIndex="10" runat="server" CssClass="c-f" Width="150px" MaxLength="15"></asp:textbox>
					</td>
					<td></td>
				</tr>
                <%-- 2015/11/01 W.GANEKO add 2015改善開発 №9 end --%>
			</table>
		</form>
	</body>
</HTML>
