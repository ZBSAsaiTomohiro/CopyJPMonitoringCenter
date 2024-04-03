<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SBMEOJAG00.aspx.vb" Inherits="JPG.SBMEOJAG00.SBMEOJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SBMEOJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
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
											<td class="TITLE" vAlign="middle">一般消費者名簿出力</td>
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

			<DIV style="LEFT: 0px; WIDTH: 900px; POSITION: absolute; TOP: 35px; HEIGHT: 30px" ms_positioning="FlowLayout">
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 70px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table5" cellSpacing="1" cellPadding="2">
						<tr>
                            <td align="right" height="25" width="90">年度</td>
							<td><asp:textbox id="txtNENDO" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="1" runat="server" CssClass="c-h" Width="100px" MaxLength="4"></asp:textbox></td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 100px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table6" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" height="25" width="90">県</td>
							<td><asp:textbox id="txtKENCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="2" runat="server" CssClass="c-h" Width="100px" MaxLength="2"></asp:textbox>
							</td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 130px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table7" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" colSpan="2" width="90">クライアント</td>
                            <td>&nbsp<asp:textbox id="txtKURACD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
									tabIndex="3" type="button" value="▼" name="btnKURACD_From" runat="server">&nbsp;～&nbsp;
                            </td>
							<td><asp:textbox id="txtKURACD_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
									tabIndex="4" type="button" value="▼" name="btnKURACD_To" runat="server">
							</td>
							<td><INPUT id="hdnKURACD_From" type="hidden" name="hdnKURACD_From" runat="server"></td>
							<td><INPUT id="hdnKURACD_To" type="hidden" name="hdnKURACD_To" runat="server"></td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 160px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table8" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" colSpan="2" width="90">販売店</td>
                            <td>&nbsp<asp:textbox id="txtHANTENCD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnHANTENCD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
									tabIndex="5" type="button" value="▼" name="btnHANTENCD_From" runat="server">&nbsp;～&nbsp;
                            </td>
							<td><asp:textbox id="txtHANTENCD_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnHANTENCD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
									tabIndex="6" type="button" value="▼" name="btnHANTENCD_To" runat="server">
							</td>
							<td><INPUT id="hdnHANTENCD_From" type="hidden" name="hdnHANTENCD_From" runat="server"></td>
							<td><INPUT id="hdnHANTENCD_To" type="hidden" name="hdnHANTENCD_To" runat="server"></td>
						</tr>
					</table>
				</DIV>

                <DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 190px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table9" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" height="25" width="90">出力リスト</td>
                            <td>
                                <%--
                                <cc1:ctlcombo id="cbofiletype" onkeydown="fncFc(this)" onblur="fncFo(this,1)"
                                onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onchange="fncSetFocus();"
                                TabIndex="7" runat="server" Width="150px" CssClass="cb"></cc1:ctlcombo>
                                <INPUT id="hdnfiletype" type="hidden" name="hdnfiletype" runat="server">
                                    --%>
                                <asp:DropDownList id="listfiletype" runat="server" Width="150px" CssClass="c-hI" onkeydown="fncFc(this)"
                                    onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onchange="fncSetFocus();"
                                    TabIndex="7">
							    </asp:DropDownList>
                            </td>
                            <td width="225">
							</td>
							<td>
                                <INPUT language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
							        onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="20" type="button"
							        value="実行" name="btnSelect" runat="server">
							</td>

						</tr>
					</table>
				</DIV>
                <DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 220px; HEIGHT: 50px" ms_positioning="FlowLayout">
					<table id="Table10" cellSpacing="1" cellPadding="2" >
						<tr>
							<td align="right" height="25" width="90"></td>
                            <td align="Left" height="25" width="300" style="font-size:20px;font-weight:bold;" >
                                <asp:label ID="lblStatus" runat="server" style="visibility:hidden">ファイル出力中。。。</asp:label></td>
						</tr>
					</table>
				</DIV>
                <DIV style="LEFT: 700px; WIDTH: 250px; POSITION: absolute; TOP: 70px; HEIGHT: 30px; font-size:16px;" ms_positioning="FlowLayout">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;県 コ ー ド<br />
                        青森:20&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 新潟:39&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;岡山:62<br />
                        岩手:21&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 富山:40&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;広島:63<br />
                        宮城:22&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 石川:41&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;山口:64<br />
                        秋田:23&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 岐阜:42&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;徳島:70<br />
                        山形:24&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 静岡:43&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;香川:71<br />
                        福島:25&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 三重:45&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;愛媛:72<br />
                        山形:26&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 福井:50&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;高知:73<br />
                        茨城:30&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 滋賀:51&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;福岡:80<br />
                        群馬:32&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 京都:52&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;佐賀:81<br />
                        埼玉:33&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 大阪:53&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;長崎:82<br />
                        千葉:34&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 兵庫:54&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;熊本:83<br />
                        東京:35&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 奈良:55&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;大分:84<br />
                        神奈川:36&nbsp;&nbsp;&nbsp;&nbsp; 鳥取:60&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;鹿児島:86<br />
                        山梨:37&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 島根:61&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;沖縄:88<br />

                        
                </DIV>
			</DIV>
		</form>
	</body>
</HTML>
