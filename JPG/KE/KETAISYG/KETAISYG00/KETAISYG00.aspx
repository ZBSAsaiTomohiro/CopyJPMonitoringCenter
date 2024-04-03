<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KETAISYG00.aspx.vb" Inherits="JPG.KETAISYG00.KETAISYG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSKOLJAG00</title>
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
											<%-- <td class="TITLE" vAlign="middle">警報出力指示画面</td> 2013/12/04 T.Ono mod 監視改善2013--%>
											<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
											<%-- <td class="TITLE" vAlign="middle">警報対応出力指示画面</td> --%>
											<%-- <td class="TITLE" vAlign="middle">監視対応出力</td> 2017/02/17 W.GANEKO 2016監視改善--%>
											<td class="TITLE" vAlign="middle">対応結果明細出力</td>
											<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
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
				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
				<%-- <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 100px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 70px; HEIGHT: 30px" ms_positioning="FlowLayout">
				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
					<table id="Table5" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" height="25" width="90">監視センター</td>
							<td colspan="2">
								<%-- 2013/08/29 T.Ono mod 監視改善2013№1
                                <cc1:ctlcombo id="cboKANSCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
									tabIndex="1" runat="server" CssClass="cb" Width="200px"  onChange="fncKansiChange();"></cc1:ctlcombo>--%>
								<%-- 2014/12/09 H.Hosoda mod 監視改善2014 №13 START --%>
                                <%-- <cc1:ctlcombo id="cboKANSCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
									tabIndex="1" runat="server" CssClass="cb" Width="200px"  onChange="fncKansiChange();fncSetFocus();"></cc1:ctlcombo>--%>
                                <cc1:ctlcombo id="cboKANSCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)"
									tabIndex="1" runat="server" CssClass="cb" Width="200px"  onChange="fncKansiChange();fncSetFocus();"></cc1:ctlcombo>
								<%-- 2014/12/09 H.Hosoda mod 監視改善2014 №13 END --%>
								<input id="hdnKANSCD" name="hdnKANSCD" type="hidden" runat="server">
							</td>
						</tr>
					</table>
				</DIV>

				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
				<%-- <DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 130px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 100px; HEIGHT: 30px" ms_positioning="FlowLayout">
				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
					<table id="Table6" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" colSpan="2" width="90">クライアント</td>
                            <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
							<%--<td><asp:textbox id="txtKURACD_From" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
									tabIndex="2" type="button" value="▼" name="btnKURACD_From" runat="server">&nbsp;～&nbsp;

							<td><asp:textbox id="txtKURACD_To" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
									tabIndex="3" type="button" value="▼" name="btnKURACD_To" runat="server">
							</td>--%>
                            <td><asp:textbox id="txtKURACD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
									tabIndex="2" type="button" value="▼" name="btnKURACD_From" runat="server">&nbsp;～&nbsp;
                            </td>
							<td><asp:textbox id="txtKURACD_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
									tabIndex="3" type="button" value="▼" name="btnKURACD_To" runat="server">
							</td>
                            <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
							<td><INPUT id="hdnKURACD_From" type="hidden" name="hdnKURACD_From" runat="server"></td>
							<td><INPUT id="hdnKURACD_To" type="hidden" name="hdnKURACD_To" runat="server"></td>
						</tr>

					</table>
				</DIV>

				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
				<%-- <DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 160px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 130px; HEIGHT: 30px" ms_positioning="FlowLayout">
				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
					<table id="Table6" cellSpacing="1" cellPadding="2" >
						<tr>
							<td align="right" colSpan="2" width="90">ＪＡ</td>
                            <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
							<%--<td><asp:textbox id="txtJACD_From" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnJACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
									tabIndex="3" type="button" value="▼" name="btnJACD_From" runat="server"></td>
							<td><asp:textbox id="txtJACD_To" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnJACD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
									tabIndex="3" type="button" value="▼" name="btnJACD_To" runat="server"></td>--%>
                            <%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
                            <%-- <td><asp:textbox id="txtJACD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnJACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
									tabIndex="3" type="button" value="▼" name="btnJACD_From" runat="server"></td> --%>
                            <td><asp:textbox id="txtJACD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnJACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
									tabIndex="4" type="button" value="▼" name="btnJACD_From" runat="server">&nbsp;～&nbsp;</td>
							<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
							<td><asp:textbox id="txtJACD_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnJACD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
									tabIndex="5" type="button" value="▼" name="btnJACD_To" runat="server"></td>
                            <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
							<td><INPUT id="hdnJACD_From" type="hidden" name="hdnJACD_From" runat="server"></td>
							<td><INPUT id="hdnJACD_To" type="hidden" name="hdnJACD_To" runat="server"></td>
                            <%-- 2019/11/01 T.Ono add 監視改善2019 START --%>
                            <td><input id="hdnJACD_From_CLI" type="hidden" name="hdnJACD_From_CLI" runat="server" />
                                <input id="hdnJACD_To_CLI" type="hidden" name="hdnJACD_To_CLI" runat="server" /></td>
                            <%-- 2019/11/01 T.Ono add 監視改善2019 END --%>
						</tr>
					</table>
				</DIV>
				<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 START --%>
				<DIV style="LEFT: 13px; WIDTH: 900px; POSITION: absolute; TOP: 160px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table14" cellSpacing="1" cellPadding="2" >
						<tr>
							<td align="right" colSpan="2" width="90">販売事業者</td>
                            <td><asp:textbox id="txtHANGRP_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnHANGRP_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('4');"
									tabIndex="6" type="button" value="▼" name="btnHANGRP_From" runat="server">&nbsp;～&nbsp;</td>
							<td><asp:textbox id="txtHANGRP_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnHANGRP_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('5');"
									tabIndex="7" type="button" value="▼" name="btnHANGRP_To" runat="server"></td>
							<td><INPUT id="hdnHANGRP_From" type="hidden" name="hdnHANGRP_From" runat="server"></td>
							<td><INPUT id="hdnHANGRP_To" type="hidden" name="hdnHANGRP_To" runat="server"></td>
						</tr>
					</table>
				</DIV>
				<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 END --%>
				<DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 190px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table7" cellSpacing="1" cellPadding="2">
						<tr>
							<td colSpan="3"><INPUT id="hdnCalendar" type="hidden" name="hdnCalendar" runat="server"></td>
						</tr>

						<tr>
							<%-- <td align="right" colSpan="2" width="90">発生日</td> 2013/12/03 T.Ono mod 監視改善2013--%> 
							<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
							<%-- <td align="right" colSpan="2" width="90">受信日</td> --%>
							<td align="right" colSpan="2" width="90">対象期間</td>
							<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
							<td><asp:textbox id="txtTRGDATE_From" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
									tabIndex="8" runat="server" cssclass="c-f" Width="72px" MaxLength="8"></asp:textbox>
									<INPUT id="btnCalendar1" name="btnCalendar1" class="bt-KS" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
									onclick="btnCalendar_onclick(1);" type="button" value="..." tabIndex="9"> &nbsp;～&nbsp;
								<asp:textbox id="txtTRGDATE_To" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
									tabIndex="10" runat="server" cssclass="c-f" Width="72px" MaxLength="8"></asp:textbox>
									<INPUT id="btnCalendar2" name="btnCalendar2" class="bt-KS" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
									onclick="btnCalendar_onclick(2);" type="button" value="..." tabIndex="11">
							</td>
						</tr>
					</table>
				</DIV>
				<%--2017/02/16 H.Mori mod 改善2016 No7-1 START --%>
				<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 START --%>
				<%--<DIV style="LEFT: 335px; WIDTH: 500px; POSITION: absolute; TOP: 190px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table class="W" id="Table10" cellSpacing="1" cellPadding="2">
						<tr>
							<td>
								<input id="rdoKIKAN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
									value="1" name="rdoKIKAN" runat="server" CHECKED onkeydown="fncFc(this)"><label for="rdoKIKAN1">対応完了日&nbsp;&nbsp;</label>
								&nbsp;&nbsp; <input id="rdoKIKAN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
									value="2" name="rdoKIKAN" runat="server" onkeydown="fncFc(this)"><label for="rdoKIKAN2">受信日&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
							</td>
						</tr>
					</table>
				</DIV>　--%>
				<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 END --%>
                <DIV style="LEFT: 335px; WIDTH: 500px; POSITION: absolute; TOP: 190px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table class="W" id="Table11" cellSpacing="1" cellPadding="2">
						<tr>
							<td>
								<input id="rdoKIKAN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="14" type="radio"
									value="1" name="rdoKIKAN" runat="server" CHECKED onkeydown="fncFc(this)"><label for="rdoKIKAN1">対応完了日&nbsp;&nbsp;</label>
								&nbsp;&nbsp; <input id="rdoKIKAN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="15" type="radio"
									value="2" name="rdoKIKAN" runat="server" onkeydown="fncFc(this)"><label for="rdoKIKAN2">受信日（処理中、未処理も出力される）&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
							</td>
						</tr>
					</table>
				</DIV>
				<%--2017/02/16 H.Mori mod 改善2016 No7-1 END --%>
                <%--2017/02/16 H.Mori add 改善2016 No7-1 START 対象時追加　説明文追加 --%>
                <DIV style="LEFT: 13px; WIDTH: 320px; POSITION: absolute; TOP: 220px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table98" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" colSpan="2" width="90">対象時間</td>
							<td><asp:textbox id="txtTRGTIME_From" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
										tabIndex="12" runat="server" Width="45px" cssclass="c-f" MaxLength="4"></asp:textbox>
								    &nbsp;～&nbsp;
								    <asp:textbox id="txtTRGTIME_To" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
										tabIndex="13" runat="server" Width="45px" cssclass="c-f" MaxLength="4"></asp:textbox>
							</td>
						</tr>
					</table>
				</DIV>
                <DIV style="LEFT: 335px; WIDTH: 300px; POSITION: absolute; TOP: 220px; HEIGHT: 30px" ms_positioning="FlowLayout">
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
                <%--2017/02/16 H.Mori add 改善2016 No7-1 END 対象時追加　説明文追加 --%>
                <%--2017/02/16 H.Mori mod 改善2016 No7-1 位置変更
				<DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 220px; HEIGT: 25px" ms_positioning="FlowLayout">　--%>
                <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 250px; HEIGT: 25px" ms_positioning="FlowLayout">
					<table id="Table8" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" width="90">発生区分</td>
							<td>
								<INPUT id="chkHSI_TEL" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="16" type="checkbox" name="chkHSI_TEL" runat="server" CHECKED>
									<label for="chkSB_HSI_TEL">電話</label>
							</td>
							<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 START --%>
							<td>
								<INPUT id="chkHSI_KEI" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="17" type="checkbox" name="chkHSI_KEI" runat="server" CHECKED>
									<label for="chkHSI_KEI">警報</label>
							</td>
							<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 END --%>
						</tr>
					</table>
				</DIV>
				<%-- 2014/11/13 H.Hosoda del 監視改善2014 №13 START --%>
				<%-- <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 245px; HEIGHT: 25px" ms_positioning="FlowLayout">
					<table id="Table9" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" width="90"></td>
							<td>
								<INPUT id="chkHSI_KEI" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="9" type="checkbox" name="chkHSI_KEI" runat="server" CHECKED>
									<label for="chkHSI_KEI">警報</label>
							</td>
						</tr>
					</table>
				</DIV> --%>
				<%-- 2014/11/13 H.Hosoda del 監視改善2014 №13 END --%>
				<%--2017/02/16 H.Mori mod 改善2016 No7-1 位置変更 --%>
                <%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
				<%--<DIV style="LEFT: 200px; WIDTH: 500px; POSITION: absolute; TOP: 220px; HEIGHT: 25px" ms_positioning="FlowLayout"> --%>
				<%--<DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 250px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
                <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 280px; HEIGHT: 30px" ms_positioning="FlowLayout">
                <%--2017/02/16 H.Mori mod 改善2016 No7-1 位置変更 --%>
					<table id="Table9" cellSpacing="1" cellPadding="2">
						<tr>
							<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
							<%-- <td noWrap align="right">対応区分</td> --%>
							<td align="right" width="90">対応区分</td>
							<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
							<td>
								<INPUT id="chkTAI_TEL" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2) "
									tabIndex="18" type="checkbox" name="chkTAI_TEL" runat="server" CHECKED>
									<label for="chkTAI_TEL">電話</label>
							</td>
							<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 START --%>
							<td>
								<INPUT id="chkTAI_SHU" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="19" type="checkbox" name="chkTAI_SHU" runat="server" CHECKED>
									<label for="chkTAI_SHU">出動</label>
							</td>
							<td>
								<INPUT id="chkTAI_JUF" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
									tabIndex="20" type="checkbox" name="chkTAI_JUF" runat="server">
									<label for="chkTAI_JUF">重複</label>
							</td>
							<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 END --%>
						</tr>
					</table>
				</DIV>
				
				<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 START --%>
				<%--2017/02/16 H.Mori mod 改善2016 No7-1 位置変更
                <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 280px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
                <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 310px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table10" cellSpacing="1" cellPadding="2">
						<tr>
							<%-- 2017/02/17 W.GANEKO MOD 監視改善　№7 <td align="right" width="90">出力項目</td> --%>
							<td align="right" width="90">出力対象</td>
							<td class="W" style="height:30px;vertical-align:middle">
								<input id="rdoOUTPUT1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="21" type="radio"
									value="1" name="rdoOUTPUT" runat="server" CHECKED onkeydown="fncFc(this)"><label for="rdoOUTPUT1">通常&nbsp;&nbsp;</label>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <input id="rdoOUTPUT2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="21" type="radio"
									value="2" name="rdoOUTPUT" runat="server" onkeydown="fncFc(this)"><label for="rdoOUTPUT2">月次帳票と同じ（重複含まず）&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
							</td>
						</tr>
					</table>
				</DIV>
				<%--2017/02/16 H.Mori mod 改善2016 No7-1 位置変更
                <DIV style="LEFT: 380px; WIDTH: 500px; POSITION: absolute; TOP: 280px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
                <DIV style="LEFT: 380px; WIDTH: 500px; POSITION: absolute; TOP: 310px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table10" cellSpacing="1" cellPadding="2">
						<tr>
							<td style="width:140px;">
		                        <a href="KETAISYG00.pdf" target="_blank" tabindex="22"><img src="../../../Script/icon_pdf.gif" border="0" alt="img" />&nbsp;&nbsp;出力条件&nbsp;&nbsp;</a>
							</td>
						</tr>
					</table>
				</DIV>
				<%-- 2014/11/13 H.Hosoda add 監視改善2014 №13 END --%>
				<%-- 2017/02/17 W.GANEKO add 監視改善2016 №7 START --%>
                <DIV style="LEFT: 13px; WIDTH: 600px; POSITION: absolute; TOP: 350px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table12" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" width="90">法令区分</td>
							<td class="W" style="height:30px;vertical-align:middle">
								<input id="rdoHOKBN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="23" type="radio"
									value="1" name="rdoHOKBN" runat="server" CHECKED onkeydown="fncFc(this)"><label for="rdoHOKBN1">総合計&nbsp;&nbsp;</label>
								&nbsp;&nbsp;&nbsp;<input id="rdoHOKBN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="23" type="radio"
									value="2" name="rdoHOKBN" runat="server" onkeydown="fncFc(this)"><label for="rdoHOKBN2">液石&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                    <input id="rdoHOKBN3" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="23" type="radio"
									value="3" name="rdoHOKBN" runat="server" onkeydown="fncFc(this)"><label for="rdoHOKBN3">その他&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
							</td>
						</tr>
					</table>
				</DIV>	
                <DIV style="LEFT: 13px; WIDTH: 600px; POSITION: absolute; TOP: 390px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table15" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" width="90">出力項目</td>
							<td class="W" style="height:30px;vertical-align:middle">
								<input id="rdoOUTLIST1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="24" type="radio"
									value="1" name="rdoOUTLIST" runat="server" CHECKED onkeydown="fncFc(this)"><label for="rdoOUTLIST1">全て&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
								&nbsp;&nbsp;&nbsp;&nbsp;<input id="rdoOUTLIST2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="24" type="radio"
									value="2" name="rdoOUTLIST" runat="server" onkeydown="fncFc(this)"><label for="rdoOUTLIST2">日次報告と同じ(出動会社あり)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                    <input id="rdoOUTLIST3" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="24" type="radio"
									value="3" name="rdoOUTLIST" runat="server" onkeydown="fncFc(this)"><label for="rdoOUTLIST3">日次報告と同じ(出動会社なし)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
							</td>
						</tr>
					</table>
				</DIV>				
				<%-- 2017/02/17 W.GANEKO add 監視改善2016 №7 END --%>
                <%-- 2017/02/16 H.Mori mod 改善2016 No7-1 位置変更 START --%>
				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
				<%-- <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 300px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<%-- <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 340px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
				<%-- 2017/02/17 W.GANEKO mod 監視改善2016 №7 START --%>
                <%-- <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 370px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
                <DIV style="LEFT: 13px; WIDTH: 500px; POSITION: absolute; TOP: 430px; HEIGHT: 30px" ms_positioning="FlowLayout">
				<%-- 2017/02/17 W.GANEKO mod 監視改善2016 №7 END --%>
                <%-- 2017/02/16 H.Mori mod 改善2016 No7-1 位置変更 END --%>
					<table id="Table13" cellSpacing="1" cellPadding="2">

						<td align="right" width="90">復帰対応状況&nbsp;</td>
						<td>
                            <%-- 2013/08/29 T.Ono mod 監視改善2013№1
                            <cc1:ctlcombo id="cboTFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="13" runat="server" width="360px" cssclass="cb"></cc1:ctlcombo>--%>
							<%-- 2014/12/09 H.Hosoda mod 監視改善2014 №13 START --%>
                            <%-- <cc1:ctlcombo id="cboTFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
								tabindex="13" runat="server" width="360px" cssclass="cb"></cc1:ctlcombo> --%>
                            <cc1:ctlcombo id="cboTFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
								tabindex="25" runat="server" width="360px" cssclass="cb"></cc1:ctlcombo>
							<%-- 2014/12/09 H.Hosoda mod 監視改善2014 №13 END --%>
<!--								<input id="hdnTFKICD" name="hdnTFKICD" type="hidden" runat="server"> -->
						</td>
					</table>
				</DIV>
				<%-- 2017/02/16 H.Mori mod 改善2016 No7-1 位置変更 START --%>
                <%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 START --%>
				<%-- <DIV style="LEFT: 500px; WIDTH: 500px; POSITION: absolute; TOP: 300px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<%-- <DIV style="LEFT: 500px; WIDTH: 500px; POSITION: absolute; TOP: 340px; HEIGHT: 30px" ms_positioning="FlowLayout"> --%>
				<%-- 2014/11/13 H.Hosoda mod 監視改善2014 №13 END --%>
				<%-- 2017/02/17 W.GANEKO mod 監視改善2016 №7 START --%>
                <%--<DIV style="LEFT: 500px; WIDTH: 500px; POSITION: absolute; TOP: 370px; HEIGHT: 30px" ms_positioning="FlowLayout">--%>
                <DIV style="LEFT: 500px; WIDTH: 500px; POSITION: absolute; TOP: 430px; HEIGHT: 30px" ms_positioning="FlowLayout">
				<%-- 2017/02/17 W.GANEKO mod 監視改善2016 №7 END --%>
                <%-- 2017/02/16 H.Mori mod 改善2016 No7-1 位置変更 END --%>
					<table id="Table13" cellSpacing="1" cellPadding="2">
						<tr>
							<td><INPUT language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="26" type="button"
							value="出力（EXCEL）" name="btnSelect" runat="server">
							</td>
						</tr>
					</table>
				</DIV>

			</DIV>
			<br>
			<br>
			&nbsp;
		</form>
	</body>
</HTML>
