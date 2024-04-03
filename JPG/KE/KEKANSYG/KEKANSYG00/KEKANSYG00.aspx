<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KEKANSYG00.aspx.vb" Inherits="KEKANSYG00.KEKANSYG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>KEKANSYG00</title>
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
											<td class="TITLE" vAlign="middle">監視対応数集計表</td>
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
			<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  START--%>
			<DIV style="LEFT: 0px; WIDTH: 900px; POSITION: absolute; TOP: 35px; HEIGHT: 30px" ms_positioning="FlowLayout">
				<DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 70px; HEIGHT: 30px" ms_positioning="FlowLayout">
			<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  END--%>
					<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  START--%>
					<%-- <table id="Table5" cellSpacing="1" cellPadding="2" width="900">--%>
					<table id="Table5" cellSpacing="1" cellPadding="2">
					<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  END--%>
						<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  START--%>
						<%-- <tr>
							<td width="10" height="30"></td>
							<td width="50" height="30"></td>
							<td width="30" height="30"></td>
							<td width="340" height="30"></td>
							<td width="480" height="30"></td>
						</tr>--%>
						<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  END--%>
						<tr>
							<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  START--%>
							<%-- <td align="right"><FONT face="MS UI Gothic"></FONT></td>D--%>
							<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  END--%>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  START--%>
							<%-- <td align="right" colSpan="2">クライアント</td>--%>
		                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
							<%--<td><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
									tabIndex="1" type="button" value="▼" name="btnKURACD" runat="server">
							</td>--%>
		                    <%-- <td><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
									tabIndex="1" type="button" value="▼" name="btnKURACD" runat="server">
							</td>
							<td><INPUT id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server"></td>--%>
							<td align="right" colSpan="2" width="90">クライアント</td>
                            <td><asp:textbox id="txtKURACD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
									tabIndex="1" type="button" value="▼" name="btnKURACD_From" runat="server">&nbsp;&nbsp;～&nbsp;
                            </td>
							<td><asp:textbox id="txtKURACD_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
									tabIndex="2" type="button" value="▼" name="btnKURACD_To" runat="server">
							</td>
							<td><INPUT id="hdnKURACD_From" type="hidden" name="hdnKURACD_From" runat="server"></td>
							<td><INPUT id="hdnKURACD_To" type="hidden" name="hdnKURACD_To" runat="server"></td>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  END--%>
						</tr>
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  START--%>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 100px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table6" cellSpacing="1" cellPadding="2" >
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  END--%>
						<tr>
							<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  START--%>
							<%-- <td align="right"><FONT face="MS UI Gothic"></FONT></td>--%>
							<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  END--%>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  START--%>
							<%--<td align="right" colSpan="2">ＪＡ</td>--%>
		                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
							<%--<td><asp:textbox id="txtJACD" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnKen1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
									tabIndex="3" type="button" value="▼" name="btnKen1" runat="server"></td>--%>
		                    <%--<td><asp:textbox id="txtJACD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnKen1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
									tabIndex="3" type="button" value="▼" name="btnKen1" runat="server"></td>
							<td><INPUT id="hdnJACD" type="hidden" name="hdnJACD" runat="server"></td>--%>
							<td align="right" colSpan="2" width="90">ＪＡ</td>
                            <td><asp:textbox id="txtJACD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnJACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
									tabIndex="3" type="button" value="▼" name="btnJACD_From" runat="server">&nbsp;&nbsp;～&nbsp;</td>
							<td><asp:textbox id="txtJACD_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnJACD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
									tabIndex="4" type="button" value="▼" name="btnJACD_To" runat="server"></td>
							<td><INPUT id="hdnJACD_From" type="hidden" name="hdnJACD_From" runat="server"></td>
							<td><INPUT id="hdnJACD_To" type="hidden" name="hdnJACD_To" runat="server"></td>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  END--%>
						</tr>
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  START--%>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 130px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table7" cellSpacing="1" cellPadding="2" >
						<tr>
							<td align="right" colSpan="2" width="90">販売事業者</td>
                            <td><asp:textbox id="txtHANGRP_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnHANGRP_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('4');"
									tabIndex="5" type="button" value="▼" name="btnHANGRP_From" runat="server">&nbsp;&nbsp;～&nbsp;</td>
							<td><asp:textbox id="txtHANGRP_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnHANGRP_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('5');"
									tabIndex="6" type="button" value="▼" name="btnHANGRP_To" runat="server"></td>
							<td><INPUT id="hdnHANGRP_From" type="hidden" name="hdnHANGRP_From" runat="server"></td>
							<td><INPUT id="hdnHANGRP_To" type="hidden" name="hdnHANGRP_To" runat="server"></td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 170px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table8" cellSpacing="1" cellPadding="2" >
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  END--%>
						<tr>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  START--%>
							<%-- <td align="right" colSpan="3">集計条件</td>--%>
							<td align="right" colSpan="2" width="90">集計条件</td>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  END--%>
							<td colSpan="2">
								<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  START--%>
								<%-- <table class="W" height="27" cellSpacing="0" cellPadding="0" width="400"> --%>
								<table class="W" height="27" cellSpacing="0" cellPadding="0" width="570">
								<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  END--%>
									<tr>
										<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  START--%>
										<%-- <td vAlign="middle" width="380">--%>
										<td vAlign="middle" width="550">
										<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  END--%>
											<%-- 2017/02/16 H.Mori add 改善2016 No8-1 START --%>
                                            <label for="rdoPGKBN6"><input id="rdoPGKBN6" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
												tabIndex="7" type="radio" CHECKED value="6" name="rdoPGKBN" runat="server">
												&nbsp;県単位&nbsp;</label>
                                            <%-- 2017/02/16 H.Mori add 改善2016 No8-1 END --%>
                                            <label for="rdoPGKBN1"><input id="rdoPGKBN1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
												tabIndex="7" type="radio" value="1" name="rdoPGKBN" runat="server">
												&nbsp;クライアント単位&nbsp;</label>
											<label for="rdoPGKBN2"><input id="rdoPGKBN2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
												tabIndex="7" type="radio" value="2" name="rdoPGKBN" runat="server">
												&nbsp;ＪＡ単位&nbsp;</label>
											<label for="rdoPGKBN3"><input id="rdoPGKBN3" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
												tabIndex="7" type="radio" value="3" name="rdoPGKBN" runat="server">
												&nbsp;ＪＡ支所単位&nbsp;</label>
											<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  START--%>	
											<label for="rdoPGKBN4"><input id="rdoPGKBN4" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
												tabIndex="7" type="radio" value="4" name="rdoPGKBN" runat="server">
												&nbsp;販売事業者単位&nbsp;</label>
                                            <%-- 2017/02/16 H.Mori del 改善2016 No8-1  
											<label for="rdoPGKBN5"><input id="rdoPGKBN5" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
												tabIndex="7" type="radio" value="5" name="rdoPGKBN" runat="server">
												&nbsp;販売事業者支所単位&nbsp;</label> --%>
											<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  END--%>
                                            <%-- 2017/02/16 H.Mori add 改善2016 No8-1 START --%>
                                            <label for="rdoPGKBN7"><input id="rdoPGKBN7" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
												tabIndex="7" type="radio" value="7" name="rdoPGKBN" runat="server">
												&nbsp;販売所単位&nbsp;</label>
                                            <%-- 2017/02/16 H.Mori add 改善2016 No8-1 END --%>	
										</td>
									</tr>
								</table>
							</td>
						</tr>
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  START--%>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 210px; HEIGHT: 25px" ms_positioning="FlowLayout">
					<table id="Table9" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" colSpan="2" width="90">発生区分</td>
							<td>
								<INPUT id="chkHSI_TEL" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="8" type="checkbox" name="chkHSI_TEL" runat="server" CHECKED>
									<label for="chkSB_HSI_TEL">電話</label>
							</td>
							<td>
								<INPUT id="chkHSI_KEI" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="9" type="checkbox" name="chkHSI_KEI" runat="server" CHECKED>
									<label for="chkHSI_KEI">警報</label>
							</td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 238px; HEIGHT: 25px" ms_positioning="FlowLayout">
					<table id="Table10" cellSpacing="1" cellPadding="2">
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  END--%>
						<!-- ▼ 2010/03/09 T.Watabe add -->
						<tr>
							<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  START--%>
							<%-- <td align="right"><FONT face="MS UI Gothic"></FONT></td>--%>
							<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  END --%>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  START--%>
							<%-- <td align="right" colSpan="2">対応区分</td>
									<td>
										<INPUT id="chkTAIOU_CHOFUKU" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
											tabIndex="7" type="checkbox" name="chkTAIOU_CHOFUKU" runat="server" CHECKED>
											<label for="chkTAIOU_CHOFUKU">重複含む</label>
									</td>--%>
							<td align="right" colSpan="2" width="90">対応区分</td>
							<td>
								<INPUT id="chkTAI_TEL" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2) "
									tabIndex="10" type="checkbox" name="chkTAI_TEL" runat="server" CHECKED>
									<label for="chkTAI_TEL">電話</label>
							</td>
							<td>
								<INPUT id="chkTAI_SHU" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="11" type="checkbox" name="chkTAI_SHU" runat="server" CHECKED>
									<label for="chkTAI_SHU">出動</label>
							</td>
							<td>
								<INPUT id="chkTAI_JUF" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="12" type="checkbox" name="chkTAI_JUF" runat="server">
									<label for="chkTAI_JUF">重複</label>
							</td>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  END --%>
						</tr>
						<!-- ▲ 2010/03/09 T.Watabe add -->
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  START--%>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 320px; POSITION: absolute; TOP: 260px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table11" cellSpacing="1" cellPadding="2">
	            <%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  END--%>
						<tr>
							<td colSpan="5" height="5"></td>
						</tr>
						<tr>
							<td colSpan="5"><INPUT id="hdnCalendar" type="hidden" name="hdnCalendar" runat="server"></td>
						</tr>
						<tr>
							<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  START--%>
							<%-- <td></td>--%>
							<%-- 2015/02/04 H.Hosoda del 監視改善2014 №14  END--%>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  START--%>
							<%-- <td align="right" colSpan="2">対象期間</td>--%>
							<td align="right" colSpan="2" width="90">対象期間</td>
							<%-- 2015/02/04 H.Hosoda mod 監視改善2014 №14  END--%>
							<td><asp:textbox id="txtTRGDATE_From" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
									tabIndex="13" runat="server" cssclass="c-f" Width="72px" MaxLength="8"></asp:textbox><INPUT id="btnCalendar1" name="btnCalendar1" class="bt-KS" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
									onclick="btnCalendar_onclick(1);" type="button" value="..." tabIndex="14"> &nbsp;～&nbsp;
								<asp:textbox id="txtTRGDATE_To" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
									tabIndex="15" runat="server" cssclass="c-f" Width="72px" MaxLength="8"></asp:textbox><INPUT id="btnCalendar2" name="btnCalendar2" class="bt-KS" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
									onclick="btnCalendar_onclick(2);" type="button" value="..." tabIndex="16">
							</td>
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  START--%>
						</tr>
					</table>
				</DIV>
                <%--2017/02/15 H.Mori mod 改善2016 No8-2 START 
                <DIV style="LEFT: 335px; WIDTH: 180px; POSITION: absolute; TOP: 265px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table class="W" id="Table12" cellSpacing="1" cellPadding="2">
						<tr>
							<td>
								<input id="rdoKIKAN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="17" type="radio"
									value="1" name="rdoKIKAN" runat="server" CHECKED onkeydown="fncFc(this)"><label for="rdoKIKAN1">対応完了日&nbsp;&nbsp;</label>
								&nbsp;&nbsp; <input id="rdoKIKAN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="17" type="radio"
									value="2" name="rdoKIKAN" runat="server" onkeydown="fncFc(this)"><label for="rdoKIKAN2">受信日&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
							</td>
						</tr>
					</table>
				</DIV> --%>
                <DIV style="LEFT: 335px; WIDTH: 330px; POSITION: absolute; TOP: 265px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table class="W" id="Table12" cellSpacing="1" cellPadding="2">
						<tr>
							<td>
								<input id="rdoKIKAN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="17" type="radio"
									value="1" name="rdoKIKAN" runat="server" CHECKED onkeydown="fncFc(this)"><label for="rdoKIKAN1">対応完了日&nbsp;&nbsp;</label>
								&nbsp;&nbsp; <input id="rdoKIKAN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="17" type="radio"
									value="2" name="rdoKIKAN" runat="server" onkeydown="fncFc(this)"><label for="rdoKIKAN2">受信日（処理中、未処理も出力される）&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
							</td>
						</tr>
					</table>
				</DIV>
                <%--2017/02/15 H.Mori mod 改善2016 No8-2 END --%>
                <%--2017/02/15 H.Mori add 改善2016 No8-2 START 対象時追加　説明文追加 --%>
                <DIV style="LEFT: 13px; WIDTH: 320px; POSITION: absolute; TOP: 300px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table98" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" colSpan="2" width="90">対象時間</td>
							<td><asp:textbox id="txtTRGTIME_From" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
										tabIndex="17" runat="server" Width="45px" cssclass="c-f" MaxLength="4"></asp:textbox>
								    &nbsp;～&nbsp;
								    <asp:textbox id="txtTRGTIME_To" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
										tabIndex="18" runat="server" Width="45px" cssclass="c-f" MaxLength="4"></asp:textbox>
							</td>
						</tr>
					</table>
				</DIV>
                <DIV style="LEFT: 335px; WIDTH: 300px; POSITION: absolute; TOP: 300px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table99" cellSpacing="1" cellPadding="2">
						<tr>
							<td>
							<span style="font-size:10pt;">※自動FAXと時間の抽出条件を同じにする場合は、<br>
                                                              &nbsp;&nbsp;&nbsp;&nbsp;対象時間のToに「0459」（4時59分）と入力します。<br>
                                                              &nbsp;&nbsp;&nbsp;&nbsp;4時59分59秒まで対象となります。</span>
							</td>
						</tr>
					</table>
				</DIV>
                <%--2017/02/15 H.Mori add 改善2016 No8-2 END 対象時追加　説明文追加 --%>
                <%-- 2020/09/14 T.Ono add 監視改善2020 START --%>
                <DIV style="LEFT: 13px; WIDTH: 320px; POSITION: absolute; TOP: 335px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table100" cellSpacing="1" cellPadding="2">
                        <tr>
                            <td align="right" colSpan="2" width="90">作動原因</td>
                            <td><INPUT id="chkTSADCD" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2) "
									tabIndex="10" type="checkbox" name="chkTSADCD" runat="server" >
									<label for="chkTSADCD">工事・交換など：63 含む</label></td>
                        </tr>
                	</table>
				</DIV>
                <%-- 2020/09/14 T.Ono add 監視改善2020 END --%>
                <%--2017/02/15 H.Mori mod 改善2016 No8-2 START 検索ボタン位置変更
				<DIV style="LEFT: 520px; WIDTH: 130px; POSITION: absolute; TOP: 265px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<!-- 2020/09/14 T.Ono mod 監視改善2020 DIV style="LEFT: 650px; WIDTH: 130px; POSITION: absolute; TOP: 300px; HEIGHT: 30px" ms_positioning="FlowLayout" -->
                <DIV style="LEFT: 650px; WIDTH: 130px; POSITION: absolute; TOP: 330px; HEIGHT: 30px" ms_positioning="FlowLayout">
                <%--2017/02/15 H.Mori mod 改善2016 No8-2 END   検索ボタン位置変更 --%>
                	<table id="Table13" cellSpacing="1" cellPadding="2">
						<tr>
				<%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  END--%>
							<td><INPUT language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
									onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="18" type="button"
									value="検索（EXCEL）" name="btnSelect" runat="server">
							</td>
						</tr>
					</table>
	        <%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  START--%>
				</DIV>
                <%--2017/02/15 H.Mori mod 改善2016 No8-2 START 集計方法位置変更
				<DIV style="LEFT: 650px; WIDTH: 500px; POSITION: absolute; TOP: 265px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
                <!-- 2020/09/14 T.Ono mod 監視改善2020 DIV style="LEFT: 785px; WIDTH: 500px; POSITION: absolute; TOP: 300px; HEIGHT: 30px" ms_positioning="FlowLayout" -->
                <DIV style="LEFT: 785px; WIDTH: 500px; POSITION: absolute; TOP: 330px; HEIGHT: 30px" ms_positioning="FlowLayout">
                <%--2017/02/15 H.Mori mod 改善2016 No8-2 END   集計方法位置変更 --%>
					<table id="Table14" cellSpacing="1" cellPadding="2">
						<tr>
							<td style="width:140px;">
		                        <a href="KEKANSYG00.pdf" target="_blank" tabindex="19"><img src="../../../Script/icon_pdf.gif" border="0" alt="img" />&nbsp;&nbsp;集計方法&nbsp;&nbsp;</a>
							</td>
						</tr>
					</table>
				</DIV>
			</DIV>
            <%-- 2015/02/04 H.Hosoda add 監視改善2014 №14  END--%>
			<br>
			<br>
			&nbsp;
		</form>
	</body>
</HTML>
