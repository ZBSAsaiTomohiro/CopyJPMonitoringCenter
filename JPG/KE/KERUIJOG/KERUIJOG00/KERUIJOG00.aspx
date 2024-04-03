<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KERUIJOG00.aspx.vb" Inherits="JPG.KERUIJOG00.KERUIJOG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>MSKOLJAG00</title>
        <style type="text/css">
            .auto-style1 {
                width: 30px;
            }
        </style>
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
											<td class="TITLE" vAlign="middle">累積情報一覧</td>
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
            <%-- 2017/02/14 H.Mori mod 2016改善開発 No9-1 START --%>
			<%--<table id="Table5" cellSpacing="1" cellPadding="2" width="900"> --%>
            <table id="Table5" cellSpacing="1" cellPadding="2" width="900">
			<%-- 2017/02/14 H.Mori mod 2016改善開発 No9-1 END --%>	
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
					<td align="right" colSpan="3">供給センター&nbsp;</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                    <%-- <td align="left"><asp:textbox id="txtKYOCD" tabIndex="-1" runat="server" Width="270px" cssclass="c-rNM" BorderColor="Black"
							onChange="fncTest();" BorderStyle="Solid" BorderWidth="1px" ReadOnly="True"></asp:textbox><INPUT class="bt-KS" id="btnKYOCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabIndex="2" type="button" value="▼" name="btnKYOCD" runat="server">
					</td>--%>
					<td align="left"><asp:textbox id="txtKYOCD" tabIndex="-1" runat="server" Width="270px" cssclass="c-rNM" BorderColor="Black"
							onChange="fncTest();" BorderStyle="Solid" BorderWidth="1px"></asp:textbox><INPUT class="bt-KS" id="btnKYOCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabIndex="2" type="button" value="▼" name="btnKYOCD" runat="server">
					</td>
					<td><INPUT id="hdnKYOCD" type="hidden" name="hdnKYOCD" runat="server"></td>
					<td>&nbsp;</td>
				</tr>
                <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 start --%>
				<tr>
					<td style="text-align:right;" colspan="3">販売事業者</td>
					<td style="text-align:left;">
                         <asp:textbox id="txtHANJICD_F" tabIndex="-1" runat="server" Width="330px" cssclass="c-rNM" BorderColor="Black" 
                         onChange="fncTest();" BorderStyle="Solid" BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHANJICD_F" 
                         onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('6');" tabindex="2" type="button" value="▼" name="btnHANJICD_F" runat="server"/>～
                         <input id="hdnHANJICD_F" type="hidden" name="hdnHANJICD_F" runat="server"/>
					</td>
					<td style="text-align:left;">
                         <asp:textbox id="txtHANJICD_T" tabIndex="-1" runat="server" Width="330px" cssclass="c-rNM" BorderColor="Black"
                         onChange="fncTest();" BorderStyle="Solid" BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHANJICD_T"
                         onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('7');" tabindex="2" type="button" value="▼" name="btnHANJICD_T" runat="server"/>
                         <input id="hdnHANJICD_T" type="hidden" name="hdnHANJICD_T" runat="server"/>
					</td>
                    <td>&nbsp;</td>
				</tr>
                <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 end --%>
				<tr>
					<td align="right"><FONT face="MS UI Gothic"></FONT></td>
					<td align="right" colSpan="2">ＪＡ</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                    <%--<td><asp:textbox id="txtJACD" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnKen1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="3" type="button" value="▼" name="btnKen1" runat="server"></td>--%>
                    <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 start --%>
					<%--<td><asp:textbox id="txtJACD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnKen1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="3" type="button" value="▼" name="btnKen1" runat="server"></td>
					<td><INPUT id="hdnJACD" type="hidden" name="hdnJACD" runat="server"></td> --%>
					<td><asp:textbox id="txtJACD_F" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><input class="bt-KS" id="btnKen1_F" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabindex="3" type="button" value="▼" name="btnKen1_F" runat="server"/>～
                            <input id="hdnJACD_F" type="hidden" name="hdnJACD_F" runat="server"/>
                    </td>
					<td><asp:textbox id="txtJACD_T" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><input class="bt-KS" id="btnKen1_T" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabindex="3" type="button" value="▼" name="btnKen1_T" runat="server"/>
                            <input id="hdnJACD_T" type="hidden" name="hdnJACD_T" runat="server"/>
                    </td>
                    <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 end --%>
				</tr>
				<tr>
					<td align="right"></td>
					<td align="right" colSpan="2">ＪＡ支所</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
					<%--<td><asp:textbox id="txtJASCD" tabIndex="-1" runat="server" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnKen2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabIndex="4" type="button" value="▼" name="btnKen2" runat="server"></td>--%>
                    <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 start --%>
                    <%--<td><asp:textbox id="txtJASCD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><INPUT class="bt-KS" id="btnKen2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabIndex="4" type="button" value="▼" name="btnKen2" runat="server"></td>
					<td><INPUT id="hdnJASCD" type="hidden" name="hdnJASCD" runat="server"></td> --%>
                    <td><asp:textbox id="txtJASCD_F" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><input class="bt-KS" id="btnKen2_F" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('4');"
							tabindex="4" type="button" value="▼" name="btnKen2_F" runat="server"/>～
                            <input id="hdnJASCD_F" type="hidden" name="hdnJASCD_F" runat="server"/>
                    </td>
                    <td><asp:textbox id="txtJASCD_T" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><input class="bt-KS" id="btnKen2_T" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('5');"
							tabindex="4" type="button" value="▼" name="btnKen2_T" runat="server"/>
                            <input id="hdnJASCD_T" type="hidden" name="hdnJASCD_T" runat="server"/>
                    </td>
                    <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 end --%>
				</tr>
				<tr>
					<td align="right" colSpan="3">発生区分</td>
					<td colSpan="2">
						<table class="W" height="27" cellSpacing="0" cellPadding="0" width="280">
							<tr>
								<td vAlign="middle" width="30"><input id="rdoSTKBN1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="5" type="radio" CHECKED value="1" name="rdoSTKBN" runat="server">
								</td>
								<td vAlign="middle" width="50"><label for="rdoSTKBN1">電話&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
								<td vAlign="middle" width="30"><input id="rdoSTKBN2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="5" type="radio" value="2" name="rdoSTKBN" runat="server">
								</td>
								<td vAlign="middle" width="50"><label for="rdoSTKBN2">警報&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
								<!-- 2011.11.21 ADD H.Uema start -->
								<td valign="middle" width="30"><input id="rdoSTKBN3" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="5" type="radio" value="3" name="rdoSTKBN" runat="server">
								</td>
								<td valign="middle" width="90"><label for="rdoSTKBN3">電話／警報&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
								<!-- 2011.11.21 ADD H.Uema end -->
							</tr>
						</table>
					</td>
				</tr>
                <%-- 2015/11/04 W.GANEKO MOD 2015改善開発 №6 start --%>
                <tr>
					<td style="text-align:right;" colspan="3">対応区分</td>
					<td colspan="2">
						<table class="W" style="height:27px;width:280px;padding:0;border-collapse:collapse;">
							<tr>
								<td style="vertical-align:middle;" class="auto-style1"><input id="checkTEL" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="5" type="checkbox" checked="checked" value="1" name="checkTEL" runat="server"/>
								</td>
								<td style="vertical-align:middle;width:50px;"><label for="checkTEL">電話&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
								<td style="vertical-align:middle;width:30px;"><input id="checkSYTUDO" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="5" type="checkbox" checked="checked" value="2" name="checkSYTUDO" runat="server"/>
								</td>
								<td style="vertical-align:middle;width:50px;"><label for="checkSYTUDO">出動&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
								<td style="vertical-align:middle;width:30px;"><input id="checkTYOFUKU" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="5" type="checkbox" value="3" name="checkTYOFUKU" runat="server"/>
								</td>
								<td style="vertical-align:middle;width:90px;"><label for="checkTYOFUKU">重複&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
							</tr>
						</table>
					</td>
				</tr>
                <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 end --%>
				<tr>
					<td align="right" colSpan="3">改ページ条件</td>
					<td colSpan="2">
                        <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 --%>
						<%-- table class="W" height="27" cellSpacing="0" cellPadding="0" width="400"> --%>
						<table class="W" height="27" cellSpacing="0" cellPadding="0" width="550">
							<tr>
								<td vAlign="middle" width="30"><input id="rdoPGKBN1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="6" type="radio" CHECKED value="1" name="rdoPGKBN" runat="server">
								</td>
								<td vAlign="middle" width="70"><label for="rdoPGKBN1">JA単位&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
                                <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 start --%>
 								<%-- <td vAlign="middle" width="30"><input id="rdoPGKBN2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="6" type="radio" value="2" name="rdoPGKBN" runat="server">
								</td>
								<td vAlign="middle" width="130"><label for="rdoPGKBN2">供給センター単位&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
								<td vAlign="middle" width="30"><input id="rdoPGKBN3" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="6" type="radio" value="3" name="rdoPGKBN" runat="server">
								</td>
								<td vAlign="middle" width="100"><label for="rdoPGKBN3">改ページなし&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
                                --%>
								<td vAlign="middle" width="30"><input id="rdoPGKBN2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="6" type="radio" value="2" name="rdoPGKBN" runat="server">
								</td>
								<td vAlign="middle" width="90"><label for="rdoPGKBN2">JA支所単位&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
								<td vAlign="middle" width="30"><input id="rdoPGKBN3" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="6" type="radio" value="3" name="rdoPGKBN" runat="server">
								</td>
								<td vAlign="middle" width="110"><label for="rdoPGKBN3">販売事業者単位&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
  								<td vAlign="middle" width="30"><input id="rdoPGKBN4" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="6" type="radio" value="4" name="rdoPGKBN" runat="server">
								</td>
								<td vAlign="middle" width="130"><label for="rdoPGKBN4">供給センター単位&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
								<td vAlign="middle" width="30"><input id="rdoPGKBN5" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabIndex="6" type="radio" value="5" name="rdoPGKBN" runat="server">
								</td>
								<td vAlign="middle" width="100"><label for="rdoPGKBN5">改ページなし&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
                               <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 end --%>
							</tr>
						</table>
					</td>
				</tr>
                <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 start --%>
				<tr>
					<td align="right" colspan="3">報告要・不要</td>
					<td colspan="2">
                        <table cellSpacing="0" cellPadding="0">
                           <tr>
                             <td>
            					<table class="W" height="27" cellSpacing="0" cellPadding="0" width="280">
			        				<tr>
					        			<td vAlign="middle" width="30"><input id="rdoHOKOKU1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							        			tabIndex="6" type="radio" CHECKED value="2" name="rdoHOKOKU" runat="server">
			    			    		</td>
				    			    	<td vAlign="middle" width="70"><label for="rdoHOKOKU1">必要のみ&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
					    		    	<td vAlign="middle" width="30"><input id="rdoHOKOKU2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
						    				tabIndex="6" type="radio" value="0" name="rdoHOKOKU" runat="server">
							    	    </td>
    							        <td vAlign="middle" width="100"><label for="rdoHOKOKU2">全て&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
	        						</tr>
        						</table>
                            </td>
                            <td>
                               <label style="font-weight:bold;font-size:10pt;">※累積の報告要・不要区分を参照</label>
                            </td>
                           </tr>
                        </table>
 					</td>
				</tr>
                <%-- 2015/11/04 W.GANEKO 2015改善開発 №6 end --%>
                <tr>
                    <%-- 2020/11/01 T.Ono mod 2020改善開発 start --%>
					<%-- <td colSpan="5" height="5"></td> --%>
                    <td style="text-align:right;" colspan="3">出動依頼内容<br />・備考</td>
					<td colspan="2">
						<table class="W" style="height:27px;width:280px;padding:0;border-collapse:collapse;">
							<tr>
								<td vAlign="middle" class="auto-style1"><input id="checkSdPrt" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="6" type="checkbox" checked="checked" value="1" name="checkSdPrt" runat="server"/>
								</td>
								<td vAlign="middle" width="70"><label for="checkSdPrt">表示あり&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
                                <td vAlign="middle" width="30">
                                <td vAlign="middle" width="100">
							</tr>
						</table>
					</td>



                    <%-- 2020/11/01 T.Ono mod 2020改善開発 end --%>
				</tr>
				<tr>
					<td colSpan="5"><INPUT id="hdnCalendar" type="hidden" name="hdnCalendar" runat="server"></td>
				</tr>
				<tr>
					<td></td>
					<td align="right" colSpan="2">対象期間</td>
                    <%--2017/02/14 H.Mori mod 改善2016 No9-1 START 検索ボタンの位置変更.対象期間区分の追加 
					<td><asp:textbox id="txtTRGDATE_From" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
							tabIndex="7" runat="server" cssclass="c-f" Width="72px" MaxLength="8"></asp:textbox><INPUT id="btnCalendar1" name="btnCalendar1" class="bt-KS" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="btnCalendar_onclick(1);" type="button" value="..." tabIndex="6"> &nbsp;～&nbsp;
						<asp:textbox id="txtTRGDATE_To" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
							tabIndex="8" runat="server" cssclass="c-f" Width="72px" MaxLength="8"></asp:textbox><INPUT id="btnCalendar2" name="btnCalendar2" class="bt-KS" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="btnCalendar_onclick(2);" type="button" value="..." tabIndex="8">
					</td> --%>
					<%--<td><INPUT language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="9" type="button"
							value="検索（EXCEL）" name="btnSelect" runat="server"> 
							<%--
							<INPUT language="javascript" class="bt-RNW" id="btnSelectTest" onblur="return fncFo(this,5);" onfocus="fncFo(this,2)" 
							onclick="return btnSelect_onclick();" tabIndex="9" type="button" value="出力テスト（EXCEL）" name="btnSelectTest" runat="server">
							
					</td> --%>
                    <td colSpan="2">
                        <table cellspacing="0" cellPadding="0">
                            <tr>
                                <td width="230">
                                    <asp:textbox id="txtTRGDATE_From" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
							            tabIndex="6" runat="server" cssclass="c-f" Width="72px" MaxLength="8"></asp:textbox><INPUT id="btnCalendar1" name="btnCalendar1" class="bt-KS" 
                                        onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							            onclick="btnCalendar_onclick(1);" type="button" value="..." tabIndex="7"> &nbsp;～&nbsp;
						            <asp:textbox id="txtTRGDATE_To" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
							            tabIndex="8" runat="server" cssclass="c-f" Width="72px" MaxLength="8"></asp:textbox><INPUT id="btnCalendar2" name="btnCalendar2" class="bt-KS" 
                                        onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							            onclick="btnCalendar_onclick(2);" type="button" value="..." tabIndex="9">
                                </td>
                                <td width="20"></td>
                                <td>
            					    <table class="W" height="29" cellspacing="0" cellpadding="1" width="310">
                                        <tr>
					        			    <td valign="middle" width="20"><input id="rdoKIKAN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="10" type="radio"
							                    value="1" name="rdoKIKAN" runat="server" CHECKED onkeydown="fncFc(this)">
                                            </td>
                                            <td valign="middle" width="70"><label for="rdoKIKAN1">対応完了日</label></td>
						                    <td valign="middle" width="20"><input id="rdoKIKAN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="10" type="radio"
							                                                        value="2" name="rdoKIKAN" runat="server" onkeydown="fncFc(this)">
                                            </td>
                                            <td valign="middle" width="200"><label for="rdoKIKAN2">受信日（処理中、未処理も出力される）</label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>					
                    </td>
                    <%--2017/02/14 H.Mori mod 改善2016 No9-1 END --%>
				</tr>
                <%--2017/02/14 H.Mori add 改善2016 No9-1 START --%>
                <tr>
                    <td></td>
                    <td align="right" colSpan="2" style="padding-top:7px; vertical-align:top;">対象時間</td>
                    <td colSpan="2">
                        <table cellspacing="0" cellPadding="0">
                            <tr>
                                <td width="230" valign="top">
                                    <asp:textbox id="txtTRGTIME_From" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
										tabIndex="11" runat="server" Width="45px" cssclass="c-f" MaxLength="4"></asp:textbox>
								    &nbsp;～&nbsp;
								    <asp:textbox id="txtTRGTIME_To" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
										tabIndex="12" runat="server" Width="45px" cssclass="c-f" MaxLength="4"></asp:textbox>&nbsp;&nbsp;
                                </td>
                                <td width="20"></td>
                                <td>
                                <span style="font-size:10pt;">※自動FAXと時間の抽出条件を同じにする場合は、<br>
                                                              &nbsp;&nbsp;&nbsp;&nbsp;対象時間のToに「0459」（4時59分）と入力します。<br>
                                                              &nbsp;&nbsp;&nbsp;&nbsp;4時59分59秒まで対象となります。</span>
                                </td>
                                <td width="50"></td>
                                <td valign="top">
                                    <INPUT language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
					                    onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="13" type="button"
							            value="検索（EXCEL）" name="btnSelect" runat="server">
                                </td>                        
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--2017/02/14 H.Mori add 改善2016 No9-1 END --%>
			</table>
			<br>
			<br>
			&nbsp;
		</form>
	</body>
</HTML>
