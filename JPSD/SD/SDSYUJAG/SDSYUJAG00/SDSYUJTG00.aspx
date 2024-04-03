<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SDSYUJTG00.aspx.vb" Inherits="JPSD.SDSYUJAG00.SDSYUJTG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<title>連絡先一覧</title>
		<script language="JavaScript">
			// window.resizeTo(620,726);
			window.resizeTo(710,766);
			window.moveTo(200,2);
		</script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td class="WW">
						<table id="Table2" cellspacing="2" cellpadding="0">
							<tr>
								<td width="200">&nbsp;</td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;</td>
								<td width="70">
								</td>
								<td>&nbsp;</td>
								<td align="right" width="80"><input language="javascript" class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
										onclick="return btnExit_onclick();" tabindex="96" type="button" value="終了" name="btnExit">&nbsp;
								</td>
							</tr>
						</table>
						<asp:label id="lblScript" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td height="3"></td>
				</tr>
				<tr>
					<td valign="bottom">
						<table id="Table3" cellspacing="0" cellpadding="0">
							<tr>
								<td width="20"></td>
								<td valign="middle" width="710">
									<table id="Table4" cellspacing="0" cellpadding="2" width="100%">
										<tbody>
											<tr>
												<td class="TITLE" valign="middle">連絡先一覧</td>
											</tr>
										</tbody></table>
								</td>
								<td width="170">&nbsp;</td>
							</tr>
						</table>
						<table>
							<tr>
								<td>ＪＡ/ＪＡ支所&nbsp;&nbsp;</td>
								<td><asp:textbox id="txtACBNM" tabindex="-1" runat="server" readonly="True" width="288px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
							</tr>
							<tr>
								<td>ＪＡ/ＪＡ支所カナ&nbsp;&nbsp;</td>
								<td><asp:textbox id="txtACBKN" tabindex="-1" runat="server" readonly="True" width="288px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
							</tr>
						</table>
						<input id="hdnREN_1_TANCD" type="hidden" runat="server" NAME="hdnREN_1_TANCD"><input id="hdnREN_2_TANCD" type="hidden" runat="server" NAME="hdnREN_2_TANCD"><input id="hdnREN_3_TANCD" type="hidden" runat="server" NAME="hdnREN_3_TANCD"><input id="hdnREN_4_TANCD" type="hidden" runat="server" NAME="hdnREN_4_TANCD"><input id="hdnREN_5_TANCD" type="hidden" runat="server" NAME="hdnREN_5_TANCD">
						<input id="hdnREN_6_TANCD" type="hidden" runat="server" NAME="hdnREN_6_TANCD"><input id="hdnREN_7_TANCD" type="hidden" runat="server" NAME="hdnREN_7_TANCD"><input id="hdnREN_8_TANCD" type="hidden" runat="server" NAME="hdnREN_8_TANCD"><input id="hdnREN_9_TANCD" type="hidden" runat="server" NAME="hdnREN_9_TANCD"><input id="hdnREN_10_TANCD" type="hidden" runat="server" NAME="hdnREN_10_TANCD">
						<input id="hdnFAXEXEPATH" type="hidden" name="hdnFAXEXEPATH" runat="server"> <input id="hdnFAXEXENAME" type="hidden" name="hdnFAXEXENAME" runat="server">
						<input id="hdnFAXHEAD" type="hidden" name="hdnFAXHEAD" runat="server"> <input id="hdnFAXSESSION" type="hidden" name="hdnFAXSESSION" runat="server">
						<input id="hdnHATYMD" type="hidden" name="hdnHATYMD" runat="server"><input id="hdnSYONO" type="hidden" name="hdnSYONO" runat="server">
						<input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server"><input id="hdnKANSCD" type="hidden" name="hdnKANSCD" runat="server">
						<input id="hdnJUSYONM" type="hidden" name="hdnJUSYONM" runat="server"> <input id="hdnUSER_CD" type="hidden" name="hdnUSER_CD" runat="server">
						<input id="hdnJUTEL1" type="hidden" name="hdnJUTEL1" runat="server"><input id="hdnJUTEL2" type="hidden" name="hdnJUTEL2" runat="server">
						<input id="hdnRENTEL" type="hidden" name="hdnRENTEL" runat="server"><input id="hdnADDR" type="hidden" name="hdnADDR" runat="server">
						<input id="hdnKENSIN" type="hidden" name="hdnKENSIN" runat="server"> <input id="hdnRYURYO" type="hidden" name="hdnRYURYO" runat="server">
						<input id="hdnMETASYU" type="hidden" name="hdnMETASYU" runat="server"><input id="hdnHATTIME" type="hidden" name="hdnHATTIME" runat="server">
						<input id="hdnKMNM1" type="hidden" name="hdnKMNM1" runat="server"><input id="hdnKMNM2" type="hidden" name="hdnKMNM2" runat="server">
						<input id="hdnKMNM3" type="hidden" name="hdnKMNM3" runat="server"><input id="hdnKMNM4" type="hidden" name="hdnKMNM4" runat="server">
						<input id="hdnKMNM5" type="hidden" name="hdnKMNM5" runat="server"><input id="hdnKMNM6" type="hidden" name="hdnKMNM6" runat="server">
						<input id="hdnTAIOKBN" type="hidden" name="hdnTAIOKBN" runat="server"><input id="hdnTKTANCD" type="hidden" name="hdnTKTANCD" runat="server">
						<input id="hdnSYOYMD" type="hidden" name="hdnSYOYMD" runat="server"><input id="hdnSYOTIME" type="hidden" name="hdnSYOTIME" runat="server">
						<input id="hdnSIJIYMD" type="hidden" name="hdnSIJIYMD" runat="server"><input id="hdnSIJITIME" type="hidden" name="hdnSIJITIME" runat="server">
						<input id="hdnTAITCD" type="hidden" name="hdnTAITCD" runat="server"><input id="hdnTELRCD" type="hidden" name="hdnTELRCD" runat="server">
						<input id="hdnFUK_MEMO" type="hidden" name="hdnFUK_MEMO" runat="server"><input id="hdnTEL_MEMO1" type="hidden" name="hdnTEL_MEMO1" runat="server">
						<input id="hdnTEL_MEMO2" type="hidden" name="hdnTEL_MEMO2" runat="server"><input id="hdnTKIGCD" type="hidden" name="hdnTKIGCD" runat="server">
						<input id="hdnTSADCD" type="hidden" name="hdnTSADCD" runat="server"><input id="hdnACBCD" type="hidden" name="hdnACBCD" runat="server">
						<input id="hdnMITOKBN" type="hidden" name="hdnMITOKBN" runat="server"><input id="hdnSNDFAXNO" type="hidden" name="hdnSNDFAXNO" runat="server">
						<hr style="COLOR: black" width="98%">
						
						<div style="color:black; height:560px; width:100%; overflow:auto;">
						
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>一次連絡先</td> 2016/02/05 H.Mori mod 一次連絡先 → 連絡先01--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                   <td>連絡先1</td>
									<td colspan="5"><asp:textbox id="txtTANNM1" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX1" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
                                <tr style="BORDER-RIGHT: black thin solid; BORDER-TOP: black thin solid; BORDER-LEFT: black thin solid; BORDER-BOTTOM: black thin solid">
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_1" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_1" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td nowrap width="114">
										<asp:textbox id="txtRENTEL1_1" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_1" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_1" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
                                    <%-- 2013/06/28 T.Ono mod END --%>
									<%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
									<%--  <td nowrap align="right" width="50"></td>--%>
									<%-- <td nowrap align="left" width="140">--%>
									<%-- 	</td>--%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail1" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="5"><asp:textbox id="txtBIKO1" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<hr style="COLOR: black" width="98%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先１</td> 2016/02/05 H.Mori mod 二次連絡先１ → 連絡先02--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先2</td>
									<td colspan="5"><asp:textbox id="txtTANNM2" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX2" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_2" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_2" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
                                    <td nowrap width="114">
										<asp:textbox id="txtRENTEL1_2" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_2" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
                                    <td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_2" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
                                    <%-- 2013/06/28 T.Ono mod END --%>
									<%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%-- <td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%-- <td nowrap align="left" width="140"> --%>
									<%-- 	<asp:textbox id="" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail2" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="5"><asp:textbox id="txtBIKO2" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<hr style="COLOR: black" width="98%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先２</td> 2016/02/05 H.Mori mod 二次連絡先２ → 連絡先03--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先3</td>
									<td colspan="5"><asp:textbox id="txtTANNM3" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX3" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
								</tr>
								<tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_3" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_3" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td nowrap width="114">
										<asp:textbox id="txtRENTEL1_3" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_3" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_3" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
                                    <%-- 2013/06/28 T.Ono mod END --%>
									<%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%--<td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%--<td nowrap align="left" width="140"> --%>
									<%--	<asp:textbox id="txtFAX3" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail3" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="4"><asp:textbox id="txtBIKO3" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<hr style="COLOR: black" width="95%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先３</td> 2016/02/05 H.Mori mod 二次連絡先3 → 連絡先04--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先4</td>
									<td colspan="5"><asp:textbox id="txtTANNM4" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX4" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
								</tr>
                                <tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_4" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_4" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td nowrap width="114">
										<asp:textbox id="txtRENTEL1_4" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_4" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_4" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
                                    <%-- 2013/06/28 T.Ono mod END --%>
									<%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%--<td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%--<td nowrap align="left" width="140"> --%>
									<%--	<asp:textbox id="txtFAX4" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail4" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="5"><asp:textbox id="txtBIKO4" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							
							<!-- ▼ 2008/11/04 T.Watabe add -->
							<hr style="COLOR: black" width="95%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先４</td> 2016/02/05 H.Mori mod 二次連絡先４ → 連絡先5--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先5</td>
									<td colspan="5"><asp:textbox id="txtTANNM5" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
								</tr>
                                <tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td nowrap width="114">
										<asp:textbox id="txtRENTEL1_5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<%-- 2013/06/28 T.Ono mod END --%>
                                    <%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%--<td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%--<td nowrap align="left" width="140"> --%>
									<%--	<asp:textbox id="txtFAX5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail5" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="5"><asp:textbox id="txtBIKO5" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<hr style="COLOR: black" width="95%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先５</td> 2016/02/05 H.Mori mod 一次連絡先５ → 連絡先6--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先6</td>
									<td colspan="5"><asp:textbox id="txtTANNM6" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
								</tr>
                                <tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td nowrap width="114">
										<asp:textbox id="txtRENTEL1_6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<%-- 2013/06/28 T.Ono mod END --%>
                                    <%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%--<td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%--<td nowrap align="left" width="140"> --%>
									<%--	<asp:textbox id="txtFAX6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail6" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="5"><asp:textbox id="txtBIKO6" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<hr style="COLOR: black" width="95%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先６</td> 2016/02/05 H.Mori mod 二次連絡先６ → 連絡先7--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先7</td>
									<td colspan="5"><asp:textbox id="txtTANNM7" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
								</tr>
                                <tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td nowrap width="114">
										<asp:textbox id="txtRENTEL1_7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<%-- 2013/06/28 T.Ono mod END --%>
                                    <%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%--<td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%--<td nowrap align="left" width="140"> --%>
									<%--	<asp:textbox id="txtFAX7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail7" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="4"><asp:textbox id="txtBIKO7" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<hr style="COLOR: black" width="95%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先７</td> 2016/02/05 H.Mori mod 二次連絡先７ → 連絡先8--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先8</td>
									<td colspan="5"><asp:textbox id="txtTANNM8" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
								</tr>
                                <tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td nowrap width="114">
										<asp:textbox id="txtRENTEL1_8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<%-- 2013/06/28 T.Ono mod END --%>
                                    <%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%--<td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%--<td nowrap align="left" width="140"> --%>
									<%--	<asp:textbox id="txtFAX8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail8" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="5"><asp:textbox id="txtBIKO8" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<hr style="COLOR: black" width="95%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先８</td> 2016/02/05 H.Mori mod 二次連絡先８ → 連絡先9--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先9</td>
									<td colspan="5"><asp:textbox id="txtTANNM9" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
								</tr>
                                <tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td nowrap width="114">
										<asp:textbox id="txtRENTEL1_9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<%-- 2013/06/28 T.Ono mod END --%>
                                    <%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%--<td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%--<td nowrap align="left" width="140"> --%>
									<%--	<asp:textbox id="txtFAX8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail9" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="5"><asp:textbox id="txtBIKO9" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<hr style="COLOR: black" width="95%">
							<table id="Table3" cellspacing="0" cellpadding="3">
								<tr>
									<%--<td>二次連絡先９</td> 2016/02/05 H.Mori mod 二次連絡先９ → 連絡先10--%>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <td>連絡先10</td>
									<td colspan="5"><asp:textbox id="txtTANNM10" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        FAX&nbsp;<asp:textbox id="txtFAX10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                     <%-- 2019/08/02 W.GANEKO mod START --%>
								</tr>
                                <tr>
									<%--<td nowrap width="80">電話番号</td> 2016/02/05 H.Mori mod 電話番号 → TEL--%>
                                    <td nowrap width="80">TEL</td>
									<%-- 2013/06/28 T.Ono mod START　電話番号3追加とサイズ調整
                                    <td nowrap width="140">
										<asp:textbox id="txtRENTEL1_10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="140">
										<asp:textbox id="txtRENTEL2_10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td nowrap width="114">
										<asp:textbox id="txtRENTEL1_10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL2_10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<td nowrap align="left" width="114">
										<asp:textbox id="txtRENTEL3_10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
									<%-- 2013/06/28 T.Ono mod END --%>
                                    <%--<td nowrap width="50">FAX番号</td> 2016/02/05 H.Mori mod FAX番号 → FAX--%>
                                    <%-- 2019/08/02 W.GANEKO mod START --%>
                                    <%--<td nowrap align="right" width="50">FAX&nbsp;</td> --%>
									<%--<td nowrap align="left" width="140"> --%>
									<%--	<asp:textbox id="txtFAX8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
									<td COLSPAN="2" nowrap align="left">ﾒｰﾙ&nbsp;<asp:textbox id="txtMail10" tabindex="-1" runat="server" readonly="True" width="155px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <%-- 2019/08/02 W.GANEKO mod END --%>
								</tr>
								<tr>
									<%--<td>連絡先記事</td> 2016/02/05 H.Mori mod 連絡先記事 → 記事--%>
                                    <td>記事</td>
									<td colspan="5"><asp:textbox id="txtBIKO10" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
								</tr>
							</table>
							<!-- ▲ 2008/11/04 T.Watabe add -->
						
						</div>
						
						<hr style="COLOR: black" width="95%">
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
