<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KEJUKJAG00.aspx.vb" Inherits="JPG.KEJUKJAG00.KEJUKJAG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>KEJUKJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><br>
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table id="Table2" cellSpacing="1" cellPadding="0" width="900">
							<tr>
								<td width="200">&nbsp;</td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;</td>
								<td width="70">&nbsp;</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80"><span id="spS1"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
											tabIndex="96" type="button" value="èIóπ" name="btnExit" runat="server">
									</span></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="2"></td>
				</tr>
				<tr>
					<td vAlign="bottom">
						<table id="Table3" cellSpacing="0" cellPadding="0" width="900">
							<tr>
								<td width="20"></td>
                                <td vAlign="middle" width="370">
									<table id="Table4" cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">éÛêMåxïÒï\é¶ÉpÉlÉã</td>
										</tr>
									</table>
								</td>
								<td width="170">åxïÒñ¢èàóùåèêî&nbsp;
									<asp:textbox id="txtCOUNT" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="56px"
										BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox><INPUT id="hdnKEY_SERIAL" type="hidden" name="hdnKEY_SERIAL" runat="server">
									<INPUT id="hdnINDEX" type="hidden" name="hdnINDEX" runat="server"> <INPUT id="hdnNoReactionCOUNT" type="hidden" name="hdnNoReactionCOUNT" runat="server">
									<INPUT id="hdnDoReactionCOUNT" type="hidden" name="hdnDoReactionCOUNT" runat="server">
									<INPUT id="hdnTaiTmskbCOUNT" type="hidden" name="hdnTaiTmskbCOUNT" runat="server">
								</td>
								<td width="360">ëŒâûñ¢èàóùåèêî&nbsp;
									<asp:textbox id="txtTAICNT" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="56px"
										BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;åxïÒï\é¶ÉpÉlÉãëçåèêî&nbsp;
                                    <asp:textbox id="txtTOTALCNT" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="56px"
										BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
							</tr>
						</table>
						<INPUT id="hdnRownum" type="hidden" name="hdnRownum" runat="server">
						<INPUT id="hdnDataCount" type="hidden" name="hdnDataCount" runat="server">
						<INPUT id="hdnCtlFlg" type="hidden" name="hdnCtlFlg" runat="server">
						<INPUT id="hdnSYORI_SERIAL1" type="hidden" name="hdnSYORI_SERIAL1" runat="server">
						<INPUT id="hdnSYORI_SERIAL2" type="hidden" name="hdnSYORI_SERIAL2" runat="server">
						<INPUT id="hdnSYORI_SERIAL3" type="hidden" name="hdnSYORI_SERIAL3" runat="server">
						<INPUT id="hdnSYORI_SERIAL4" type="hidden" name="hdnSYORI_SERIAL4" runat="server">
						<INPUT id="hdnSYORI_SERIAL5" type="hidden" name="hdnSYORI_SERIAL5" runat="server">
						<INPUT id="hdnSYORI_SERIAL6" type="hidden" name="hdnSYORI_SERIAL6" runat="server">
					</td>
				</tr>
			</table>
			<table style="BORDER-BOTTOM: black 1px solid" cellSpacing="0" cellPadding="0" width="1090">
				<tr>
					<td></td>
				</tr>
			</table>
			<br>
			<table cellSpacing="0" cellPadding="0" width="1440">
                <tr>
                    <td>
                        <table  cellSpacing="0" cellPadding="0" width="530">
                            <tr>
                                <td colspan="2"><div style="padding:1px 0px 1px 0px;float:left;width: 20px;border: 1px solid #000000;background-color: #ffffff;font-size: 13pt;text-align: center;font-weight: bold;">1</div>&nbsp;<asp:textbox id="txt1KMYMD" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txt1KMTIME" tabIndex="-1" runat="server" Width="64px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>
                                </td>
                                <td align="right">∏◊≤±›ƒ&nbsp;</td>
            					<td>
                                    <asp:textbox id="txt1KURACD" tabIndex="-1" runat="server" Width="48px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;åßñº&nbsp;<asp:textbox id="txt1KENNM" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;<asp:textbox id="txt1ROC" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="70px"
							BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
            					</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;åxïÒ“Øæ∞ºﬁêî&nbsp;<asp:textbox id="txt1KMCNT" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox>&nbsp;&nbsp;ó¨ó ãÊï™&nbsp;<asp:textbox id="txt1RYURYO" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BoderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox><INPUT id="hdn1SERIAL" type="hidden" name="hdn1SERIAL" runat="server">
                                </td>
                                <td align="right">ÇiÇ`ñº&nbsp;</td>
                                <td><asp:textbox id="txt1JANM" tabIndex="-1" runat="server" Width="195px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt1KMMESSAGE1" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">Ç®ãqól&nbsp;</td>
                                <td><asp:textbox id="txt1JUYONM" tabIndex="-1" runat="server" Width="250px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt1KMMESSAGE2" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"	BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">òAóçêÊ&nbsp;</td>
                                <td><asp:textbox id="txt1JUTEL" tabIndex="-1" runat="server" Width="140px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt1KMMESSAGE3" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td rowspan="2" align="right">èZèä&nbsp;</td>
                                <td rowspan="2">
                                    <asp:TextBox id="txt1ADDR" style="overflow:hidden" tabIndex="-1" runat="server" Width="250px" Height="45px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM" TextMode="MultiLine" Columns="40" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2"><span id="spB1"><input class="bt-LNG" id="btn1TAIOU" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnROC_onclick(1)"
								tabIndex="96" type="button" value="ãŸã}ëŒâû" name="btn1TAIOU" runat="server"></span>
                                </td>
               					<td>“∞¿íl<asp:textbox id="txt1META" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="70px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="3">ÉçÉbÉN&nbsp;<asp:textbox id="txt1ROCUSER" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"
							BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
                                    <span id="spB11"><input style="height:24px;width:135px;background-color: ButtonFace;" id="btn1ROC" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnNOROC_onclick(1);"
								tabIndex="96" type="button" value="ÉçÉbÉNâèú" name="btn1ROC" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <div style=" width:1px; height: 160px; background-color: black;margin:0 10px 0 10px;"></div>
                    </td>
                    <td>
                        <table  cellSpacing="0" cellPadding="0" width="530">
                            <tr>
                                <td colspan="2"><div style="padding:1px 0px 1px 0px;float:left;width: 20px;border: 1px solid #000000;background-color: #ffffff;font-size: 13pt;text-align: center;font-weight: bold;">4</div>&nbsp;<asp:textbox id="txt4KMYMD" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txt4KMTIME" tabIndex="-1" runat="server" Width="64px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>
                                </td>
                                <td align="right">∏◊≤±›ƒ&nbsp;</td>
            					<td>
                                    <asp:textbox id="txt4KURACD" tabIndex="-1" runat="server" Width="48px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;åßñº&nbsp;<asp:textbox id="txt4KENNM" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;<asp:textbox id="txt4ROC" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="70px"
							BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
            					</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;åxïÒ“Øæ∞ºﬁêî&nbsp;<asp:textbox id="txt4KMCNT" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox>&nbsp;&nbsp;ó¨ó ãÊï™&nbsp;<asp:textbox id="txt4RYURYO" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BoderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox><INPUT id="hdn4SERIAL" type="hidden" name="hdn4SERIAL" runat="server">
                                </td>
                                <td align="right">ÇiÇ`ñº&nbsp;</td>
                                <td><asp:textbox id="txt4JANM" tabIndex="-1" runat="server" Width="195px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt4KMMESSAGE1" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">Ç®ãqól&nbsp;</td>
                                <td><asp:textbox id="txt4JUYONM" tabIndex="-1" runat="server" Width="250px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt4KMMESSAGE2" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"	BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">òAóçêÊ&nbsp;</td>
                                <td><asp:textbox id="txt4JUTEL" tabIndex="-1" runat="server" Width="140px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt4KMMESSAGE3" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td rowspan="2" align="right">èZèä&nbsp;</td>
                                <td rowspan="2">
                                    <asp:TextBox id="txt4ADDR" style="overflow:hidden" tabIndex="-1" runat="server" Width="250px" Height="45px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM" TextMode="MultiLine" Columns="40" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2"><span id="spB4"><input class="bt-LNG" id="btn4TAIOU" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnROC_onclick(4)"
								tabIndex="96" type="button" value="ãŸã}ëŒâû" name="btn4TAIOU" runat="server"></span>
                                </td>
               					<td>“∞¿íl<asp:textbox id="txt4META" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="70px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="3">ÉçÉbÉN&nbsp;<asp:textbox id="txt4ROCUSER" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"
							BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
                                    <span id="spB44"><input style="height:24px;width:135px;background-color: ButtonFace;" id="btn4ROC" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnNOROC_onclick(4);"
								tabIndex="96" type="button" value="ÉçÉbÉNâèú" name="btn4ROC" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                    </td>

                    <%-- //ÉåÉCÉAÉEÉgé¿å± ècê¸Ç™í«â¡Ç≈Ç´ÇÈÇ©ÅBÇ† --%>
                    <td rowspan="6">
                        <div style=" width:1px; height: 500px; background-color: black;margin:0 10px 0 10px;"></div>
                    </td>
                    <td rowspan="6">
                        <table  cellSpacing="0" cellPadding="0" style="height:500px;width:300px; border:1px medium black;background:#ffffff;">
                            <tr><td style="background:#008000;">
                                <div style=" height:450px;overflow-y:scroll; background:#000000;line-height:160%;font-size:12pt;">
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                    <div style="background:#ffffff;color:#515151;margin-bottom:1px;">
                                        2023/09/29 09:00 Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®Ç†Ç¢Ç§Ç¶Ç®</div>
                                
                                </div>
                                </td></tr>
                            <tr><td style=" height:50px;background:#66cdaa;">
                                <input type="text" name="testTextA1" style="width:300px;" />
                                <input type="button" value="ÉÅÉÇãLò^">

                                </td></tr>
                        </table>
                    </td>

                </tr>
				<tr>
					<td colSpan="3">
						<table style="BORDER-BOTTOM: black 1px solid" cellSpacing="0" cellPadding="0" width="1090">
							<tr>
								<td></td>
							</tr>
						</table>
						<br>
						<br>
					</td>
				</tr>


                <tr>
                    <td>
                        <table  cellSpacing="0" cellPadding="0"  width="530">
                            <tr>
                                <td colspan="2"><div style="padding:1px 0px 1px 0px;float:left;width: 20px;border: 1px solid #000000;background-color: #ffffff;font-size: 13pt;text-align: center;font-weight: bold;">2</div>&nbsp;<asp:textbox id="txt2KMYMD" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txt2KMTIME" tabIndex="-1" runat="server" Width="64px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>
                                </td>
                                <td align="right">∏◊≤±›ƒ&nbsp;</td>
            					<td>
                                    <asp:textbox id="txt2KURACD" tabIndex="-1" runat="server" Width="48px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;åßñº&nbsp;<asp:textbox id="txt2KENNM" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;<asp:textbox id="txt2ROC" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="70px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
            					</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;åxïÒ“Øæ∞ºﬁêî&nbsp;<asp:textbox id="txt2KMCNT" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox>&nbsp;&nbsp;ó¨ó ãÊï™&nbsp;<asp:textbox id="txt2RYURYO" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px"
							BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox><INPUT id="hdn2SERIAL" type="hidden" name="hdn2SERIAL" runat="server">
                                </td>
                                <td align="right">ÇiÇ`ñº&nbsp;</td>
                                <td><asp:textbox id="txt2JANM" tabIndex="-1" runat="server" Width="195px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt2KMMESSAGE1" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">Ç®ãqól&nbsp;</td>
                                <td><asp:textbox id="txt2JUYONM" tabIndex="-1" runat="server" Width="250px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt2KMMESSAGE2" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"	BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">òAóçêÊ&nbsp;</td>
                                <td><asp:textbox id="txt2JUTEL" tabIndex="-1" runat="server" Width="140px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt2KMMESSAGE3" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td rowspan="2" align="right">èZèä&nbsp;</td>
                                <td rowspan="2">
                                    <asp:TextBox id="txt2ADDR" style="overflow:hidden" tabIndex="-1" runat="server" Width="250px" Height="45px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM" TextMode="MultiLine" Columns="40" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2"><span id="spB2"><input class="bt-LNG" id="btn2TAIOU" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnROC_onclick(2)"
								tabIndex="96" type="button" value="ãŸã}ëŒâû" name="btn2TAIOU" runat="server"></span>
                                </td>
               					<td>“∞¿íl<asp:textbox id="txt2META" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="70px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="3">ÉçÉbÉN&nbsp;<asp:textbox id="txt2ROCUSER" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"
							BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
                                    <span id="spB22"><input style="height:24px;width:135px;background-color: ButtonFace;" id="btn2ROC" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnNOROC_onclick(2);"
								tabIndex="96" type="button" value="ÉçÉbÉNâèú" name="btn2ROC" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <div style=" width:1px; height: 160px; background-color: black;margin:0 10px 0 10px;"></div>
                    </td>
                    <td>
                        <table  cellSpacing="0" cellPadding="0" width="530">
                            <tr>
                                <td colspan="2"><div style="padding:1px 0px 1px 0px;float:left;width: 20px;border: 1px solid #000000;background-color: #ffffff;font-size: 13pt;text-align: center;font-weight: bold;">5</div>&nbsp;<asp:textbox id="txt5KMYMD" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txt5KMTIME" tabIndex="-1" runat="server" Width="64px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>
                                </td>
                                <td align="right">∏◊≤±›ƒ&nbsp;</td>
            					<td>
                                    <asp:textbox id="txt5KURACD" tabIndex="-1" runat="server" Width="48px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;åßñº&nbsp;<asp:textbox id="txt5KENNM" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;<asp:textbox id="txt5ROC" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="70px"
							BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
            					</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;åxïÒ“Øæ∞ºﬁêî&nbsp;<asp:textbox id="txt5KMCNT" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox>&nbsp;&nbsp;ó¨ó ãÊï™&nbsp;<asp:textbox id="txt5RYURYO" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BoderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox><INPUT id="hdn5SERIAL" type="hidden" name="hdn5SERIAL" runat="server">
                                </td>
                                <td align="right">ÇiÇ`ñº&nbsp;</td>
                                <td><asp:textbox id="txt5JANM" tabIndex="-1" runat="server" Width="195px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt5KMMESSAGE1" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">Ç®ãqól&nbsp;</td>
                                <td><asp:textbox id="txt5JUYONM" tabIndex="-1" runat="server" Width="250px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt5KMMESSAGE2" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"	BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">òAóçêÊ&nbsp;</td>
                                <td><asp:textbox id="txt5JUTEL" tabIndex="-1" runat="server" Width="140px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt5KMMESSAGE3" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td rowspan="2" align="right">èZèä&nbsp;</td>
                                <td rowspan="2">
                                    <asp:TextBox id="txt5ADDR" style="overflow:hidden" tabIndex="-1" runat="server" Width="250px" Height="45px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM" TextMode="MultiLine" Columns="40" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2"><span id="spB5"><input class="bt-LNG" id="btn5TAIOU" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnROC_onclick(5)"
								tabIndex="96" type="button" value="ãŸã}ëŒâû" name="btn5TAIOU" runat="server"></span>
                                </td>
               					<td>“∞¿íl<asp:textbox id="txt5META" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="70px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="3">ÉçÉbÉN&nbsp;<asp:textbox id="txt5ROCUSER" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"
							BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
                                    <span id="spB55"><input style="height:24px;width:135px;background-color: ButtonFace;" id="btn5ROC" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnNOROC_onclick(5);"
								tabIndex="96" type="button" value="ÉçÉbÉNâèú" name="btn5ROC" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
				<tr>
					<td colSpan="3">
						<table style="BORDER-BOTTOM: black 1px solid" cellSpacing="0" cellPadding="0" width="1090">
							<tr>
								<td></td>
							</tr>
						</table>
						<br>
						<br>
					</td>
				</tr>

                <tr>
                    <td>
                        <table  cellSpacing="0" cellPadding="0"  width="530">
                            <tr>
                                <td colspan="2"><div style="padding:1px 0px 1px 0px;float:left;width: 20px;border: 1px solid #000000;background-color: #ffffff;font-size: 13pt;text-align: center;font-weight: bold;">3</div>&nbsp;<asp:textbox id="txt3KMYMD" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txt3KMTIME" tabIndex="-1" runat="server" Width="64px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>
                                </td>
                                <td align="right">∏◊≤±›ƒ&nbsp;</td>
            					<td>
                                    <asp:textbox id="txt3KURACD" tabIndex="-1" runat="server" Width="48px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;åßñº&nbsp;<asp:textbox id="txt3KENNM" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;<asp:textbox id="txt3ROC" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="70px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
            					</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;åxïÒ“Øæ∞ºﬁêî&nbsp;<asp:textbox id="txt3KMCNT" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox>&nbsp;&nbsp;ó¨ó ãÊï™&nbsp;<asp:textbox id="txt3RYURYO" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px"
							BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox><INPUT id="hdn3SERIAL" type="hidden" name="hdn3SERIAL" runat="server">
                                </td>
                                <td align="right">ÇiÇ`ñº&nbsp;</td>
                                <td><asp:textbox id="txt3JANM" tabIndex="-1" runat="server" Width="195px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt3KMMESSAGE1" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">Ç®ãqól&nbsp;</td>
                                <td><asp:textbox id="txt3JUYONM" tabIndex="-1" runat="server" Width="250px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt3KMMESSAGE2" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"	BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">òAóçêÊ&nbsp;</td>
                                <td><asp:textbox id="txt3JUTEL" tabIndex="-1" runat="server" Width="140px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt3KMMESSAGE3" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td rowspan="2" align="right">èZèä&nbsp;</td>
                                <td rowspan="2">
                                    <asp:TextBox id="txt3ADDR" style="overflow:hidden" tabIndex="-1" runat="server" Width="250px" Height="45px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM" TextMode="MultiLine" Columns="40" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2"><span id="spB3"><input class="bt-LNG" id="btn3TAIOU" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnROC_onclick(3)"
								tabIndex="96" type="button" value="ãŸã}ëŒâû" name="btn3TAIOU" runat="server"></span>
                                </td>
               					<td>“∞¿íl<asp:textbox id="txt3META" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="70px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="3">ÉçÉbÉN&nbsp;<asp:textbox id="txt3ROCUSER" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"
							BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
                                    <span id="spB33"><input style="height:24px;width:135px;background-color: ButtonFace;" id="btn3ROC" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnNOROC_onclick(3);"
								tabIndex="96" type="button" value="ÉçÉbÉNâèú" name="btn3ROC" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <div style=" width:1px; height: 160px; background-color: black;margin:0 10px 0 10px;"></div>
                    </td>
                     <td>
                        <table  cellSpacing="0" cellPadding="0" width="530">
                            <tr>
                                <td colspan="2"><div style="padding:1px 0px 1px 0px;float:left;width: 20px;border: 1px solid #000000;background-color: #ffffff;font-size: 13pt;text-align: center;font-weight: bold;">6</div>&nbsp;<asp:textbox id="txt6KMYMD" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txt6KMTIME" tabIndex="-1" runat="server" Width="64px" BorderStyle="Solid" BorderWidth="1px"
							CssClass="c-rNM"></asp:textbox>
                                </td>
                                <td align="right">∏◊≤±›ƒ&nbsp;</td>
            					<td>
                                    <asp:textbox id="txt6KURACD" tabIndex="-1" runat="server" Width="48px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;åßñº&nbsp;<asp:textbox id="txt6KENNM" tabIndex="-1" runat="server" Width="95px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                    </asp:textbox>&nbsp;<asp:textbox id="txt6ROC" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="70px"
							BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
            					</td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;åxïÒ“Øæ∞ºﬁêî&nbsp;<asp:textbox id="txt6KMCNT" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox>&nbsp;&nbsp;ó¨ó ãÊï™&nbsp;<asp:textbox id="txt6RYURYO" style="TEXT-ALIGN: center" tabIndex="-1" runat="server" Width="25px" BoderStyle="Solid" BorderWidth="1px" CssClass="c-rNM">
                                </asp:textbox><INPUT id="hdn6SERIAL" type="hidden" name="hdn6SERIAL" runat="server">
                                </td>
                                <td align="right">ÇiÇ`ñº&nbsp;</td>
                                <td><asp:textbox id="txt6JANM" tabIndex="-1" runat="server" Width="195px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt6KMMESSAGE1" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">Ç®ãqól&nbsp;</td>
                                <td><asp:textbox id="txt6JUYONM" tabIndex="-1" runat="server" Width="250px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt6KMMESSAGE2" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"	BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td align="right">òAóçêÊ&nbsp;</td>
                                <td><asp:textbox id="txt6JUTEL" tabIndex="-1" runat="server" Width="140px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:textbox id="txt6KMMESSAGE3" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                                <td rowspan="2" align="right">èZèä&nbsp;</td>
                                <td rowspan="2">
                                    <asp:TextBox id="txt6ADDR" style="overflow:hidden" tabIndex="-1" runat="server" Width="250px" Height="45px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM" TextMode="MultiLine" Columns="40" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2"><span id="spB6"><input class="bt-LNG" id="btn6TAIOU" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnROC_onclick(6)"
								tabIndex="96" type="button" value="ãŸã}ëŒâû" name="btn6TAIOU" runat="server"></span>
                                </td>
               					<td>“∞¿íl<asp:textbox id="txt6META" style="TEXT-ALIGN: right" tabIndex="-1" runat="server" Width="70px" BorderStyle="Solid" BorderWidth="1px" CssClass="c-rNM"></asp:textbox></td>
                            </tr>
                            <tr>
                                <td colspan="3">ÉçÉbÉN&nbsp;<asp:textbox id="txt6ROCUSER" tabIndex="-1" runat="server" Width="220px" BorderStyle="Solid"
							BorderWidth="1px" CssClass="c-rNM"></asp:textbox>
                                    <span id="spB66"><input style="height:24px;width:135px;background-color: ButtonFace;" id="btn6ROC" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnNOROC_onclick(6);"
								tabIndex="96" type="button" value="ÉçÉbÉNâèú" name="btn6ROC" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

				<tr>
					<td colSpan="3">
						<table style="BORDER-BOTTOM: black 1px solid" cellSpacing="0" cellPadding="0" width="1090">
							<tr>
								<td></td>
							</tr>
						</table>
						<br>
						<br>
					</td>
				</tr>
				<tr>
					<td width="210"><INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"></td>
					<td width="110"></td>
					<td width="200"></td>
					<td width="50"></td>
					<td width="50"></td>
					<td width="130"></td>
					<td width="70"></td>
					<td width="80"></td>
                    <td width="50"></td>
                    <td width="300"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="900">
				<tr>
                    <td><span id="spchk">&nbsp;<input name="chkJido" type="checkbox" id="chkJido" onclick="fncchkclick(this,0)" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="97" runat="server"/>
                        <label for="chkJido">é©ìÆçXêV&nbsp;&nbsp;</label>
                        <input name="chkMishori" type="checkbox" id="chkMishori"  onclick="fncchkclick(this,1)" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="98" runat="server"/>
                        <label for="chkMishori">ñ¢èàóùÇÃÇ›&nbsp;</label></span></td>
					<%-- 2015/11/02 W.ganeko add 2015â¸ëPäJî≠ No9 start --%>
                    <td>
						<span id="spK2">
						<input class="bt-RNW" id="btnTanto" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnTanto_onclick(this);"
								tabIndex="96" type="button" value="JAíSìñé“àÍóó" name="btnTanto" runat="server"/>
                        </span></td>
					<%-- 2015/11/02 W.ganeko add 2015â¸ëPäJî≠ No9 end --%>
					<td align="right">
                    <input class="bt-JIK" id="btnFirst" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnFirst_onclick();"
							tabIndex="96" type="button" value="êÊì™" name="btnFirst" runat="server"> <input class="bt-JIK" id="btnPre" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPre_onclick();"
							tabIndex="96" type="button" value="ëO" name="btnPre" runat="server"> <input class="bt-JIK" id="btnNex" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnNex_onclick();"
							tabIndex="96" type="button" value="éü" name="btnNex" runat="server"> <input class="bt-JIK" id="btnEnd" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnEnd_onclick();"
							tabIndex="96" type="button" value="ç≈å„" name="btnEnd" runat="server"> &nbsp; 
						&nbsp; &nbsp; <input class="bt-RNW" id="btnRenew" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnRenew_onclick();"
							tabIndex="96" type="button" value="ç≈êVï\é¶" name="btnRenew" runat="server"> &nbsp; 
						&nbsp; &nbsp;
						<span id="spK1">
                            <!-- 2016/01/07 T.Ono mod îÒï\é¶Ç…ïœçX(style="visibility:hidden"í«â¡) -->
							<input style="visibility:hidden" class="bt-RNW" id="btnKeson" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnKeson_onclick(this);"
								tabIndex="96" type="button" value="åáëπÉfÅ[É^àÍóó" name="btnKeson" runat="server"/>
						</span></td>
				</tr>
						<%-- 2013/12/13 T.Ono add äƒéãâ¸ëP2013 --%>
                        <INPUT id="hdnJido" type="hidden" name="hdnJido" runat="server"/> <INPUT id="hdnMishori" type="hidden" name="hdnMishori" runat="server"/>
                        <INPUT id="hdnBtmOukaFlg" type="hidden" name="hdnBtmOukaFlg" runat="server"/>
			</table>
		</form>
	</body>
</HTML>
