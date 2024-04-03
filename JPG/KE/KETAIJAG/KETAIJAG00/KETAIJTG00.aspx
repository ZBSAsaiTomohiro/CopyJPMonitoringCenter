<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KETAIJTG00.aspx.vb" Inherits="JPG.KETAIJAG00.KETAIJTG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>連絡先選択</title>
		<script language="JavaScript">
			// window.resizeTo(620,726);
			//window.resizeTo(800,766); 2010/04/28 T.Watabe edit
			//window.moveTo(200,2);
		    //window.resizeTo(1010,770); 2013/05/27 T.Ono edit
		    window.resizeTo(1150, 770);
			window.moveTo(100,20);
		</script>
        <style>.WAKU { BORDER: black 1px solid; }
            .TD_PAD { PADDING-RIGHT: 10px; PADDING-LEFT: 10px; }
            .TD_PAD2 { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; }
            .HR1 { border-width: 1px 0px 0px 0px;
                   border-style: solid;
                   border-color: black;
                   height: 1px; }
        </style>
            
	</HEAD>
	<body onload="fncOTHER_KANSI_CENTER();">
		<form id="Form1" method="post" runat="server">
			<OBJECT id="Fax" codeBase="/JPG/FaxCab.CAB#Version=1,0,0,0" height="0" width="0" classid="clsid:21E1F969-A7C0-4C5C-9E37-56FAAD4578FE"
				name="Fax" viewastext>
				<PARAM NAME="_Version" VALUE="65536">
				<PARAM NAME="_ExtentX" VALUE="26">
				<PARAM NAME="_ExtentY" VALUE="26">
				<PARAM NAME="_StockProps" VALUE="0">
			</OBJECT>
			<table id="Table1" cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td class="WW">
						<table id="Table2" cellspacing="2" cellpadding="0">
							<tr>
								<td width="200">&nbsp;</td>
								<%-- <td width="300">&nbsp;</td> --%>
                                <%-- 2015/11/09 H.Mori add 2015改善開発 No2 START --%>
                                <td align="left" width="300"><input class="bt-RNW" id="btnSoExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
                                        onclick="return btnExit_onclick();" name="btnSoExit" tabindex="96" type="button" value="送信せず閉じる" runat="server" />&nbsp;
                                </td>
                                <%-- 2015/11/09 H.Mori add 2015改善開発 No2 END --%>
								<td width="220">&nbsp;</td>
								<td width="70">
									<% 
									'<input language="javascript" class="bt-RNW" id="btnTaiou" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
									'	onclick="return btnTaiou_onclick();" tabindex="95" type="button" value="対応入力画面へ" name="btnTaiou">
								%>
								</td>
								<td>&nbsp;</td>
                                <%-- 2015/12/09 w.ganeko add 2015改善開発 No2 START --%>
								<!--<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
										onclick="return btnExit_onclick();" tabindex="96" type="button" value="閉じる" name="btnExit"/>&nbsp;
								</td>-->
								<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" runat="server"
										onclick="return btnExit_Check_onclick();" tabindex="96" type="button" value="閉じる" name="btnExit"/>&nbsp;
								</td>
                                <%-- 2015/12/09 w.ganeko add 2015改善開発 No2 END --%>
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
												<td class="TITLE" valign="middle">連絡先選択</td>
											</tr>
										</tbody></table>
								</td>
								<td width="170">&nbsp;</td>
							</tr>
						</table>
						<table>
							<tr>
                                <%--2016/02/02 w.ganeko 2015改善開発 №2 第2弾 start --%>
                                <%--<td>ＪＡ/ＪＡ支所&nbsp;&nbsp;</td>--%>
                                <td>グループ名称&nbsp;&nbsp;</td>
                                <%--2016/02/02 w.ganeko 2015改善開発 №2 第2弾 end --%>
                                <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
								<%--<td><asp:textbox id="txtACBNM" tabindex="-1" runat="server" readonly="True" width="288px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                <td><asp:textbox id="txtACBNM" tabindex="-1" runat="server" width="288px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>							
                                <td rowspan="2" width="60"></td>
								<td rowspan="2">
									<input class="bt-LNG" id="btnTelHas" onblur="fncFo(this,5)" style="WIDTH:120px;TEXT-ALIGN:center"
										onfocus="fncFo(this,2)" onclick="return btnDial_onclick('1');" tabindex="-1" type="button"
										value="電話FAXメール&#13;&#10;発信" name="btnTelHas" runat="server"/>
								</td>
                				<%-- 2014/12/15 T.Ono add 2014改善開発 No4 START --%>
								<td width="150">
                    				<%-- 2015/12/15 w.ganeko add 2015改善開発 No2 START --%>
									<div id="tagMail1" align="center">
                                        <label for="chkMenyMail1">複数送信</label><input id="chkMenyMail1" onclick="fncClickRadio()" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
									</div>
                    				<%-- 2015/12/15 w.ganeko add 2015改善開発 No2 END --%>
                                </td>
                                <td rowspan="2">
                                	<input class="bt-LNG" id="btnPreview" onblur="fncFo(this,5)" style="WIDTH:120px;TEXT-ALIGN:center"
										onfocus="fncFo(this,2)" onclick="return btnDial_onclick('2');" tabindex="-1" type="button"
										value="FAXメール&#13;&#10;プレビュー" name="btnPreview" runat="server" />
								</td>
                                <td rowspan="2" valign="bottom"><font color="red">変更不可<br />（変更時は対応画面から）</font></td>
                				<%-- 2014/12/15 T.Ono add 2014改善開発 No4 END --%>
							</tr>
							<tr>
                                <%--2016/02/02 w.ganeko 2015改善開発 №2 第2弾 start --%>
                                <%-- <td>ＪＡ/ＪＡ支所カナ&nbsp;&nbsp;</td>--%> 
                                <td>ＪＡ/ＪＡ支所&nbsp;&nbsp;</td> 
                                <%--2016/02/02 w.ganeko 2015改善開発 №2 第2弾 end --%>
                                <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
								<%--<td><asp:textbox id="txtACBKN" tabindex="-1" runat="server" readonly="True" width="288px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                <td><asp:textbox id="txtACBKN" tabindex="-1" runat="server" width="288px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
                                <td>
                    				<%-- 2015/12/15 w.ganeko add 2015改善開発 No2 START --%>
									<%--<div id="tagMail1">--%>
                                    	<!-- 2014/12/25 T.Ono add 2014改善開発 No4 onclick="fncClickRadio()"追加-->
                                        <%-- <input id="rdoMail1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
										name="rdoTel">メール送信のみ --%>
                                        <!-- 2015/12/07 H.Mori add 2015改善開発 No2　チェックボックスに変更　-->
                                        <%-- <input id="rdoMail1" onclick="fncClickRadio()" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
										name="rdoTel">メール送信のみ --%>
									<%-- </div> --%>
                                    <font id="menylbl" style="color:Red;">同時送信可能な件数は<br />FAX:10件、ﾒｰﾙ:30件です。</font>
                    				<%-- 2015/12/15 w.ganeko add 2015改善開発 No2 END --%>
								</td>
							</tr>
						</table>
						<input id="hdnREN_1_TANCD" type="hidden" runat="server" NAME="hdnREN_1_TANCD"><input id="hdnREN_2_TANCD" type="hidden" runat="server" NAME="hdnREN_2_TANCD"><input id="hdnREN_3_TANCD" type="hidden" runat="server" NAME="hdnREN_3_TANCD"><input id="hdnREN_4_TANCD" type="hidden" runat="server" NAME="hdnREN_4_TANCD"><input id="hdnREN_5_TANCD" type="hidden" runat="server" NAME="hdnREN_5_TANCD">
						<input id="hdnREN_6_TANCD" type="hidden" runat="server" NAME="hdnREN_6_TANCD"><input id="hdnREN_7_TANCD" type="hidden" runat="server" NAME="hdnREN_7_TANCD"><input id="hdnREN_8_TANCD" type="hidden" runat="server" NAME="hdnREN_8_TANCD"><input id="hdnREN_9_TANCD" type="hidden" runat="server" NAME="hdnREN_9_TANCD"><input id="hdnREN_10_TANCD" type="hidden" runat="server" NAME="hdnREN_10_TANCD">
						<!-- 2010/05/10 T.Watabe add -->
						<input id="hdnREN_11_TANCD" type="hidden" runat="server" NAME="hdnREN_11_TANCD"><input id="hdnREN_12_TANCD" type="hidden" runat="server" NAME="hdnREN_12_TANCD"><input id="hdnREN_13_TANCD" type="hidden" runat="server" NAME="hdnREN_13_TANCD"><input id="hdnREN_14_TANCD" type="hidden" runat="server" NAME="hdnREN_14_TANCD"><input id="hdnREN_15_TANCD" type="hidden" runat="server" NAME="hdnREN_15_TANCD">
						<input id="hdnREN_16_TANCD" type="hidden" runat="server" NAME="hdnREN_16_TANCD"><input id="hdnREN_17_TANCD" type="hidden" runat="server" NAME="hdnREN_17_TANCD"><input id="hdnREN_18_TANCD" type="hidden" runat="server" NAME="hdnREN_18_TANCD"><input id="hdnREN_19_TANCD" type="hidden" runat="server" NAME="hdnREN_19_TANCD"><input id="hdnREN_20_TANCD" type="hidden" runat="server" NAME="hdnREN_20_TANCD">
						<input id="hdnREN_21_TANCD" type="hidden" runat="server" NAME="hdnREN_21_TANCD"><input id="hdnREN_22_TANCD" type="hidden" runat="server" NAME="hdnREN_22_TANCD"><input id="hdnREN_23_TANCD" type="hidden" runat="server" NAME="hdnREN_23_TANCD"><input id="hdnREN_24_TANCD" type="hidden" runat="server" NAME="hdnREN_24_TANCD"><input id="hdnREN_25_TANCD" type="hidden" runat="server" NAME="hdnREN_25_TANCD">
						<input id="hdnREN_26_TANCD" type="hidden" runat="server" NAME="hdnREN_26_TANCD"><input id="hdnREN_27_TANCD" type="hidden" runat="server" NAME="hdnREN_27_TANCD"><input id="hdnREN_28_TANCD" type="hidden" runat="server" NAME="hdnREN_28_TANCD"><input id="hdnREN_29_TANCD" type="hidden" runat="server" NAME="hdnREN_29_TANCD"><input id="hdnREN_30_TANCD" type="hidden" runat="server" NAME="hdnREN_30_TANCD">
						<input id="hdnFAXEXEPATH" type="hidden" name="hdnFAXEXEPATH" runat="server"> <input id="hdnFAXEXENAME" type="hidden" name="hdnFAXEXENAME" runat="server">
						<input id="hdnFAXHEAD" type="hidden" name="hdnFAXHEAD" runat="server"> <input id="hdnFAXSESSION" type="hidden" name="hdnFAXSESSION" runat="server">
   						<input id="hdnFAX_TITLE_SELECT" type="hidden" name="hdnFAX_TITLE_SELECT" runat="server" value="1">
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
						<input id="hdnTEL_MEMO2" type="hidden" name="hdnTEL_MEMO2" runat="server">
                        <!-- 2020/11/01 T.Ono add 2020監視改善 -->
                        <input id="hdnTEL_MEMO4" type="hidden" name="hdnTEL_MEMO4" runat="server"><input id="hdnTEL_MEMO5" type="hidden" name="hdnTEL_MEMO5" runat="server"><input id="hdnTEL_MEMO6" type="hidden" name="hdnTEL_MEMO6" runat="server">                        
                        <input id="hdnTKIGCD" type="hidden" name="hdnTKIGCD" runat="server">
						<input id="hdnTSADCD" type="hidden" name="hdnTSADCD" runat="server"><input id="hdnACBCD" type="hidden" name="hdnACBCD" runat="server">
						<input id="hdnMITOKBN" type="hidden" name="hdnMITOKBN" runat="server"><input id="hdnSNDFAXNO" type="hidden" name="hdnSNDFAXNO" runat="server">
						<input id="hdnFAX_TITLE" type="hidden" name="hdnFAX_TITLE" runat="server"> <input id="hdnM05_TANTO_HAN_CD" type="hidden" name="hdnM05_TANTO_HAN_CD" runat="server"><!-- 2010/05/12 T.Watabe add -->
						<input id="hdnSNDMAIL" type="hidden" name="hdnSNDMAIL" runat="server"><input id="hdnSNDMAILPASS" type="hidden" name="hdnSNDMAILPASS" runat="server">
						<input id="hdnREN_1_MAILPASS" type="hidden" name="hdnREN_1_MAILPASS" runat="server">
						<input id="hdnREN_2_MAILPASS" type="hidden" name="hdnREN_2_MAILPASS" runat="server">
						<input id="hdnREN_3_MAILPASS" type="hidden" name="hdnREN_3_MAILPASS" runat="server">
						<input id="hdnREN_4_MAILPASS" type="hidden" name="hdnREN_4_MAILPASS" runat="server">
						<input id="hdnREN_5_MAILPASS" type="hidden" name="hdnREN_5_MAILPASS" runat="server">
						<input id="hdnREN_6_MAILPASS" type="hidden" name="hdnREN_6_MAILPASS" runat="server">
						<input id="hdnREN_7_MAILPASS" type="hidden" name="hdnREN_7_MAILPASS" runat="server">
						<input id="hdnREN_8_MAILPASS" type="hidden" name="hdnREN_8_MAILPASS" runat="server">
						<input id="hdnREN_9_MAILPASS" type="hidden" name="hdnREN_9_MAILPASS" runat="server">
						<input id="hdnREN_10_MAILPASS" type="hidden" name="hdnREN_10_MAILPASS" runat="server">
						<input id="hdnREN_11_MAILPASS" type="hidden" name="hdnREN_11_MAILPASS" runat="server">
						<input id="hdnREN_12_MAILPASS" type="hidden" name="hdnREN_12_MAILPASS" runat="server">
						<input id="hdnREN_13_MAILPASS" type="hidden" name="hdnREN_13_MAILPASS" runat="server">
						<input id="hdnREN_14_MAILPASS" type="hidden" name="hdnREN_14_MAILPASS" runat="server">
						<input id="hdnREN_15_MAILPASS" type="hidden" name="hdnREN_15_MAILPASS" runat="server">
						<input id="hdnREN_16_MAILPASS" type="hidden" name="hdnREN_16_MAILPASS" runat="server">
						<input id="hdnREN_17_MAILPASS" type="hidden" name="hdnREN_17_MAILPASS" runat="server">
						<input id="hdnREN_18_MAILPASS" type="hidden" name="hdnREN_18_MAILPASS" runat="server">
						<input id="hdnREN_19_MAILPASS" type="hidden" name="hdnREN_19_MAILPASS" runat="server">
						<input id="hdnREN_20_MAILPASS" type="hidden" name="hdnREN_20_MAILPASS" runat="server">
						<input id="hdnREN_21_MAILPASS" type="hidden" name="hdnREN_21_MAILPASS" runat="server">
						<input id="hdnREN_22_MAILPASS" type="hidden" name="hdnREN_22_MAILPASS" runat="server">
						<input id="hdnREN_23_MAILPASS" type="hidden" name="hdnREN_23_MAILPASS" runat="server">
						<input id="hdnREN_24_MAILPASS" type="hidden" name="hdnREN_24_MAILPASS" runat="server">
						<input id="hdnREN_25_MAILPASS" type="hidden" name="hdnREN_25_MAILPASS" runat="server">
						<input id="hdnREN_26_MAILPASS" type="hidden" name="hdnREN_26_MAILPASS" runat="server">
						<input id="hdnREN_27_MAILPASS" type="hidden" name="hdnREN_27_MAILPASS" runat="server">
						<input id="hdnREN_28_MAILPASS" type="hidden" name="hdnREN_28_MAILPASS" runat="server">
						<input id="hdnREN_29_MAILPASS" type="hidden" name="hdnREN_29_MAILPASS" runat="server">
						<input id="hdnREN_30_MAILPASS" type="hidden" name="hdnREN_30_MAILPASS" runat="server">
						<input id="hdnSendFlg" type="hidden" name="hdnSendFlg" runat="server">
                        <!-- 2013/07/11 T.Ono add　M05_TANTO2を使用した場合のUSER_CD_FROM-->
                        <input id="hdnUSER_CD_FROM" type="hidden" name="hdnUSER_CD_FROM" runat="server" />
                        <!-- 2014/02/04 T.Ono add 監視改善2013 -->
                        <input id="hdnFAXServerKBN" type="hidden" name="hdnFAXServerKBN" runat="server" />
                        <!-- 2014/12/24 T.Ono add 2014改善開発 No4 START -->
                        <input id="hdnPreviewFlg" type="hidden" name="hdnPreviewFlg" runat="server" /><!-- プレビュー確認したか -->
                        <input id="hdnBtnKBN" type="hidden" name="hdnBtnKBN" runat="server" /><!-- 1:送信ﾎﾞﾀﾝ押下 2：ﾌﾟﾚﾋﾞｭｰﾎﾞﾀﾝ押下 -->
                        <!-- 2014/12/24 T.Ono add 2014改善開発 No4 END -->  
                        <!-- 2016/04/19 T.Ono add　2015改善開発 №7-->
                        <input id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server" />
						<hr style="COLOR: black" width="98%"> 
						<!--  <div style="OVERFLOW:auto; WIDTH:100%; COLOR:black; HEIGHT:420px"> 2013/07/23 T.Ono mod-->
						<div style="OVERFLOW:auto; WIDTH:1090; COLOR:black; HEIGHT:420px">
                            <!-- 2014/12/25 T.Ono add 2014改善開発 No4 -->
                            <!-- ラジオボタンに"onclick="fncClickRadio()"追加 ラジオボタンにより、発信ボタンの有効無効を切り替える-->
							<table style="WIDTH:1050">
                            <tr>
                            <td>
                            <table id="RENRAKU" cellspacing="0" cellpadding="0" width="510px">
                                <tr>
									<td class="TD_PAD">連絡先01</td>
									<td><asp:textbox id="txtTANNM1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
											tabindex="1" runat="server" width="400px" cssclass="c-hI" maxlength="30"></asp:textbox>
									</td>
									<td class="TD_PAD2"></td>
                                </tr>
								<tr>
									<td></td>
									<td style="margin-left: 40px">
                                        <%--2016/12/13 H.Mori mod 2016改善開発 No6-1 checked --%> 
										<%--TEL<input id="rdoTel1_1" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" 
                                            onfocus="fncFo(this,2)" tabindex="-1" type="radio" runat="server"
											name="rdoTel"/>--%>
                                        TEL<input id="rdoTel1_1" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" 
                                            onfocus="fncFo(this,2)" tabindex="-1" type="radio" runat="server"
											checked name="rdoTel"/><asp:textbox id="txtRENTEL1_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
											tabindex="2" runat="server" width="112px" cssclass="c-h" maxlength="15"></asp:textbox>
										<input id="rdoTel2_1" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" 
                                            onfocus="fncFo(this,2)" tabindex="-1" type="radio" runat="server"
											name="rdoTel"/><asp:textbox id="txtRENTEL2_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="3" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_1" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" 
                                            onfocus="fncFo(this,2)" tabindex="-1" type="radio" runat="server"
											name="rdoTel"/><asp:textbox id="txtRENTEL3_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="3" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>	
									</td>
									<td class="TD_PAD2"></td>
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                            <tr>
									<td class="TD_PAD">連絡先02</td>
									<td><asp:textbox id="txtTANNM2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
											tabindex="1" runat="server" width="400px" cssclass="c-hI" maxlength="30"></asp:textbox>
									</td>
                                    <td></td>
							</tr>	
								<tr>
									<td></td>
									<td style="margin-left: 80px">
										TEL<input id="rdoTel1_2" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"  runat="server"/><asp:textbox id="txtRENTEL1_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
											tabindex="2" runat="server" width="112px" cssclass="c-h" maxlength="15"></asp:textbox>
										<input id="rdoTel2_2" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"  runat="server"/><asp:textbox id="txtRENTEL2_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="3" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_2" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="3" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>										
									</td>
									<td></td>
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先03</td>
									<td><asp:textbox id="txtTANNM3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
											tabindex="1" runat="server" width="400px" cssclass="c-hI" maxlength="30"></asp:textbox>
									</td>
								</tr>
								<tr>
									<td></td>
									<td>
										TEL<input id="rdoTel1_3" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
											tabindex="2" runat="server" width="112px" cssclass="c-h" maxlength="15"></asp:textbox>
										<input id="rdoTel2_3" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="3" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_3" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="3" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>
										
									</td>
									
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先04</td>
									<td><asp:textbox id="txtTANNM4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
											tabindex="1" runat="server" width="400px" cssclass="c-hI" maxlength="30"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
									<td>
                                        <%--2016/12/13 H.Mori mod 2016改善開発 No6-1 checked --%> 
										<%-- TEL<input id="rdoTel1_4" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											checked name="rdoTel" runat="server"/>--%>
                                        TEL<input id="rdoTel1_4" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
											tabindex="2" runat="server" width="112px" cssclass="c-h" maxlength="15"></asp:textbox>
										<input id="rdoTel2_4" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="3" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_4" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="3" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>
										
									
									
									</td>
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先5</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM5" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO5" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM5" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_5" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_5" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax5" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX5" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_5" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server" /><asp:textbox id="txtRENTEL1_5" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_5" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_5" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_5" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_5" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										
									</td>
									
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先6</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM6" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO6" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM6" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_6" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_6" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax6" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX6" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_6" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_6" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_6" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_6" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_6" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_6" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										
									</td>
									
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先7</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM7" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO7" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM7" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_7" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_7" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax7" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX7" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_7" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_7" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_7" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_7" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_7" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_7" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									
									</td>
									
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先8</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM8" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO8" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM8" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
					
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_8" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_8" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax8" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX8" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_8" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_8" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_8" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_8" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_8" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_8" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										
									</td>
									
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先9</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM9" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO9" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM9" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_9" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_9" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax9" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX9" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_9" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_9" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_9" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_9" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_9" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_9" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									
									</td>
									
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先10</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM10" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO10" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM10" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
							
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_10" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_10" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax10" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX10" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_10" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_10" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_10" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_10" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_10" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_10" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									
									</td>
									
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>			
								<tr>
									<td class="TD_PAD">連絡先11</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM11" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO11" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM11" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_11" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_11" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_11" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_11" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax11" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX11" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_11" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_11" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_11" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_11" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_11" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_11" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>									
									</td>
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先12</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM12" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO12" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%> 
                                    <td>
										<asp:textbox id="txtTANNM12" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_12" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_12" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_12" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_12" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax12" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX12" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_12" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_12" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_12" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_12" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_12" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_12" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>	
								<tr>
									<td class="TD_PAD">連絡先13</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM13" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO13" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM13" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_13" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_13" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_13" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_13" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax13" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX13" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_13" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_13" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_13" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_13" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_13" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_13" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									
									</td>
									
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先14</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM14" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO14" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM14" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_14" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_14" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_14" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_14" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax14" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX14" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_14" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_14" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_14" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_14" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_14" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_14" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										
									</td>	
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先15</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM15" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO15" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM15" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_15" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_15" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_15" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_15" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax15" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX15" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_15" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_15" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_15" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_15" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_15" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_15" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										
									</td>
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先16</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM16" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO16" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM16" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_16" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_16" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_16" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_16" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax16" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX16" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_16" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_16" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_16" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_16" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_16" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_16" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									
									</td>
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先17</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM17" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO17" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM17" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_17" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_17" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_17" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_17" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax17" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX17" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_17" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_17" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_17" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_17" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_17" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_17" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>	
									</td>
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先18</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM18" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO18" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM18" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_18" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_18" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_18" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_18" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax18" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX18" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_18" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_18" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_18" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_18" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_18" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_18" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
								</tr>
						        <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先19</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM19" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO19" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM19" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_19" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_19" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_19" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_19" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax19" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX19" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_19" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_19" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_19" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_19" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_19" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_19" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>								
								</tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先20</td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										<asp:textbox id="txtTANNM20" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO20" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM20" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_20" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_20" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_20" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_20" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax20" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX20" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_20" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_20" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_20" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_20" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_20" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_20" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>								
									</td>
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先21</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM21" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO21" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM21" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_21" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_21" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_21" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_21" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax21" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX21" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_21" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_21" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_21" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_21" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_21" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_21" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先22</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM22" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO22" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM22" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>								
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_22" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_22" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_22" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_22" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax22" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX22" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_22" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_22" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_22" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_22" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_22" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_22" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>									
									</td>									
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先23</td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										<asp:textbox id="txtTANNM23" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO23" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM23" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_23" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_23" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_23" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_23" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax23" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX23" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_23" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_23" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_23" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_23" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_23" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_23" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										
									</td>									
								</tr>
						        <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先24</td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										<asp:textbox id="txtTANNM24" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO24" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM24" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>									
								<tr>
									<td></td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										TEL<input id="rdoTel1_24" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_24" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_24" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_24" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax24" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX24" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_24" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_24" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_24" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_24" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_24" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_24" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>										
									</td>									
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先25</td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										<asp:textbox id="txtTANNM25" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO25" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM25" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>									
								<tr>
									<td></td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										TEL<input id="rdoTel1_25" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_25" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_25" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_25" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax25" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX25" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_25" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_25" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_25" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_25" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_25" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_25" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>									
									</td>								
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先26</td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										<asp:textbox id="txtTANNM26" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO26" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM26" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_26" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_26" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_26" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_26" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax26" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX26" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_26" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_26" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_26" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_26" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_26" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_26" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>								
									</td>									
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先27</td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										<asp:textbox id="txtTANNM27" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO27" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM27" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>								
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_27" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_27" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_27" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_27" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax27" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX27" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_27" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_27" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_27" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_27" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_27" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_27" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>										
									</td>									
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先28</td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										<asp:textbox id="txtTANNM28" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO28" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM28" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_28" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_28" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_28" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_28" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax28" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX28" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_28" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_28" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_28" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_28" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_28" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_28" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>										
									</td>									
								</tr>
							    <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先29</td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										<asp:textbox id="txtTANNM29" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO29" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM29" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>									
								<tr>
									<td></td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										TEL<input id="rdoTel1_29" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_29" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_29" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_29" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax29" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX29" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_29" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_29" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_29" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_29" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_29" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_29" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>										
									</td>									
								</tr>
						        <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
								<tr>
									<td class="TD_PAD">連絡先30</td>
									<%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                                    <%--<td>
										<asp:textbox id="txtTANNM30" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
									<td>記事<asp:textbox id="txtBIKO30" tabindex="-1" runat="server" readonly="True" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                    <td>
										<asp:textbox id="txtTANNM30" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>									
								<tr>
									<td></td>
                                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
									<%--<td>
										TEL<input id="rdoTel1_30" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL1_30" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_30" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtRENTEL2_30" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										FAX<input id="rdoFax30" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel"><asp:textbox id="txtFAX30" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>--%>
                                    <td>
										TEL<input id="rdoTel1_30" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL1_30" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
										<input id="rdoTel2_30" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL2_30" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
                                        <!-- ▼▼▼ 2013/05/27 T.Ono add 顧客単位登録機能追加 ▼▼▼ -->
										<input id="rdoTel3_30" onclick="fncClickRadio('2');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server"/><asp:textbox id="txtRENTEL3_30" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>										
									</td>								
								</tr>
							</table>
                            </td> 
                            <td style="width:10px;"></td>
                            <td>
                            <table  id="Table5" cellspacing="0" cellpadding="0" width="530px">
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="5" runat="server" width="400px" cssclass="c-fI" maxlength="30"></asp:textbox>
									</td>
                                    <td class="TD_PAD2"></td>
                                </tr>
                                <tr>
                                    <%-- 2016/05/06 w.ganeko start --%>
                                    <%--<td id="tdFaxMail_1" align="right">
                                        <label id="lblFaxMail_1" for="chkFaxMail_1">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_1" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/>--%>
                                    <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_1">FAX</label><input id="chkFax_1" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="4" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail1" align="right">
									    <label for="chkMail_1">メール</label><input id="chkMail_1" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td class="TD_PAD2"></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="5" runat="server" width="400px" cssclass="c-fI" maxlength="30"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <%-- 2016/05/06 w.ganeko start --%>
                                    <%-- <td id="tdFaxMail_2" align="right">
                                        <label id="lblFaxMail_2" for="chkFaxMail_2">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_2" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/>--%>
                                    <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_2">FAX</label><input id="chkFax_2" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="4" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail2" align="right">
									    <label for="chkMail_2">メール</label><input id="chkMail_2" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="5" runat="server" width="400px" cssclass="c-fI" maxlength="30"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <%-- 2016/05/06 w.ganeko start --%>
                                    <%--<td id="tdFaxMail_3" align="right">
                                        <label id="lblFaxMail_3" for="chkFaxMail_3">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_3" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                    <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_3">FAX</label><input id="chkFax_3" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="4" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail3" align="right">
									    <label for="chkMail_3">メール</label><input id="chkMail_3" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="5" runat="server" width="400px" cssclass="c-fI" maxlength="30"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <%-- 2016/05/06 w.ganeko start --%>
                                    <%--<td id="tdFaxMail_4" align="right">
                                        <label id="lblFaxMail_4" for="chkFaxMail_4">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_4" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                    <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_4">FAX</label><input id="chkFax_4" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="4" runat="server" width="112px" cssclass="c-f" maxlength="15"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail4" align="right">
									    <label for="chkMail_4">メール</label><input id="chkMail_4" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO5" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <%-- 2016/05/06 w.ganeko start --%>
                                    <%--<td id="tdFaxMail_5" align="right">
                                        <label id="lblFaxMail_5" for="chkFaxMail_5">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_5" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                    <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_5">FAX</label><input id="chkFax_5" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX5" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>

                                    <td id="tagFaxMail5" align="right">
									    <label for="chkMail_5">メール</label><input id="chkMail_5" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO6" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%--<td id="tdFaxMail_6" align="right">
                                        <label id="lblFaxMail_6" for="chkFaxMail_6">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_6" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/>--%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_6">FAX</label><input id="chkFax_6" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX6" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail6" align="right">
									    <label for="chkMail_6">メール</label><input id="chkMail_6" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO7" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_7" align="right">
                                        <label id="lblFaxMail_7" for="chkFaxMail_7">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_7" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_7">FAX</label><input id="chkFax_7" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX7" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>

                                    <td id="tagFaxMail7" align="right">
									    <label for="chkMail_7">メール</label><input id="chkMail_7" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO8" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_8" align="right">
                                        <label id="lblFaxMail_8" for="chkFaxMail_8">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_8" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_8">FAX</label><input id="chkFax_8" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX8" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail8" align="right">
									    <label for="chkMail_8">メール</label><input id="chkMail_8" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO9" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%--<td id="tdFaxMail_9" align="right">
                                        <label id="lblFaxMail_9" for="chkFaxMail_9">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_9" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/>--%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_9">FAX</label><input id="chkFax_9" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX9" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail9" align="right">
									    <label for="chkMail_9">メール</label><input id="chkMail_9" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO10" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%--<td id="tdFaxMail_10" align="right">
                                        <label id="lblFaxMail_10" for="chkFaxMail_10">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_10" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_10">FAX</label><input id="chkFax_10" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX10" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>

                                    <td id="tagFaxMail10" align="right">
									    <label for="chkMail_10">メール</label><input id="chkMail_10" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO11" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_11" align="right">
                                        <label id="lblFaxMail_11" for="chkFaxMail_11">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_11" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_11">FAX</label><input id="chkFax_11" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX11" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>

                                    <td id="tagFaxMail11" align="right">
									    <label for="chkMail_11">メール</label><input id="chkMail_11" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO12" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_12" align="right">
                                        <label id="lblFaxMail_12" for="chkFaxMail_12">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_12" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
										    />--%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_12">FAX</label><input id="chkFax_12" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX12" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>

                                    <td id="tagFaxMail12" align="right">
									    <label for="chkMail_12">メール</label><input id="chkMail_12" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO13" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_13" align="right">
                                        <label id="lblFaxMail_13" for="chkFaxMail_13">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_13" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_13">FAX</label><input id="chkFax_13" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX13" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail13" align="right">
									    <label for="chkMail_13">メール</label><input id="chkMail_13" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO14" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_14" align="right">
                                        <label id="lblFaxMail_14" for="chkFaxMail_14">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_14" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_14">FAX</label><input id="chkFax_14" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX14" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail14" align="right">
									    <label for="chkMail_14">メール</label><input id="chkMail_14" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO15" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_15" align="right">
                                        <label id="lblFaxMail_15" for="chkFaxMail_15">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_15" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_15">FAX</label><input id="chkFax_15" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX15" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail15" align="right">
									    <label for="chkMail_15">メール</label><input id="chkMail_15" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO16" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_16" align="right">
                                        <label id="lblFaxMail_16" for="chkFaxMail_16">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_16" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_16">FAX</label><input id="chkFax_16" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX16" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail16" align="right">
									    <label for="chkMail_16">メール</label><input id="chkMail_16" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO17" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%--<td id="tdFaxMail_17" align="right">
                                        <label id="lblFaxMail_17" for="chkFaxMail_17">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_17" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_17">FAX</label><input id="chkFax_17" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX17" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail17" align="right">
									    <label for="chkMail_17">メール</label><input id="chkMail_17" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO18" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                  <%-- 2016/05/06 w.ganeko start --%>
                                  <%--<td id="tdFaxMail_18" align="right">
                                        <label id="lblFaxMail_18" for="chkFaxMail_18">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_18" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                  <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_18">FAX</label><input id="chkFax_18" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX18" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail18" align="right">
									    <label for="chkMail_18">メール</label><input id="chkMail_18" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO19" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                  <%-- 2016/05/06 w.ganeko start --%>
                                  <%-- <td id="tdFaxMail_19" align="right">
                                        <label id="lblFaxMail_19" for="chkFaxMail_19">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_19" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                  <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_19">FAX</label><input id="chkFax_19" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX19" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>

                                    <td id="tagFaxMail19" align="right">
									    <label for="chkMail_19">メール</label><input id="chkMail_19" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO20" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                  <%-- 2016/05/06 w.ganeko start --%>
                                  <%--  <td id="tdFaxMail_20" align="right">
                                        <label id="lblFaxMail_20" for="chkFaxMail_20">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_20" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                  <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_20">FAX</label><input id="chkFax_20" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX20" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail20" align="right">
									    <label for="chkMail_20">メール</label><input id="chkMail_20" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO21" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                  <%-- 2016/05/06 w.ganeko start --%>
                                  <%-- <td id="tdFaxMail_21" align="right">
                                        <label id="lblFaxMail_21" for="chkFaxMail_21">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_21" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                  <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_21">FAX</label><input id="chkFax_21" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX21" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail21" align="right">
									    <label for="chkMail_21">メール</label><input id="chkMail_21" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO22" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_22" align="right">
                                        <label id="lblFaxMail_22" for="chkFaxMail_22">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_22" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_22">FAX</label><input id="chkFax_22" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX22" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail22" align="right">
									    <label for="chkMail_22">メール</label><input id="chkMail_22" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO23" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_23" align="right">
                                        <label id="lblFaxMail_23" for="chkFaxMail_23">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_23" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%> 
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_23">FAX</label><input id="chkFax_23" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX23" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail23" align="right">
									    <label for="chkMail_23">メール</label><input id="chkMail_23" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO24" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_24" align="right">
                                        <label id="lblFaxMail_24" for="chkFaxMail_24">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_24" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_24">FAX</label><input id="chkFax_24" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX24" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail24" align="right">
									    <label for="chkMail_24">メール</label><input id="chkMail_24" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO25" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%--  <td id="tdFaxMail_25" align="right">
                                        <label id="lblFaxMail_25" for="chkFaxMail_25">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_25" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_25">FAX</label><input id="chkFax_25" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
										    /><asp:textbox id="txtFAX25" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail25" align="right">
									    <label for="chkMail_25">メール</label><input id="chkMail_25" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO26" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_26" align="right">
                                        <label id="lblFaxMail_26" for="chkFaxMail_26">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_26" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_26">FAX</label><input id="chkFax_26" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
										    /><asp:textbox id="txtFAX26" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail26" align="right">
									    <label for="chkMail_26">メール</label><input id="chkMail_26" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO27" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_27" align="right">
                                        <label id="lblFaxMail_27" for="chkFaxMail_27">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_27" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_27">FAX</label><input id="chkFax_27" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX27" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail27" align="right">
									    <label for="chkMail_27">メール</label><input id="chkMail_27" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO28" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_28" align="right">
                                        <label id="lblFaxMail_28" for="chkFaxMail_28">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_28" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_28">FAX</label><input id="chkFax_28" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX28" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail28" align="right">
									    <label for="chkMail_28">メール</label><input id="chkMail_28" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO29" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_29" align="right">
                                        <label id="lblFaxMail_29" for="chkFaxMail_29">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_29" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_29">FAX</label><input id="chkFax_29" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX29" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail29" align="right">
									    <label for="chkMail_29">メール</label><input id="chkMail_29" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr class="HR1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">記事<asp:textbox id="txtBIKO30" tabindex="-1" runat="server" width="400px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>
									</td>
                                    <td></td>
                                </tr>
                                <tr>
                                   <%-- 2016/05/06 w.ganeko start --%>
                                   <%-- <td id="tdFaxMail_30" align="right">
                                        <label id="lblFaxMail_30" for="chkFaxMail_30">FAX＆ﾒｰﾙ</label><input id="chkFaxMail_30" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox"
											/> --%>
                                   <%-- 2016/05/06 w.ganeko end --%>
                                    <td align="left">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label for="chkFax_30">FAX</label><input id="chkFax_30" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"
											/><asp:textbox id="txtFAX30" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
											borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;
                                    </td>
                                    <td id="tagFaxMail30" align="right">
									    <label for="chkMail_30">メール</label><input id="chkMail_30" onclick="fncClickRadio('1');" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="-1" type="checkbox" runat="server"/>
                                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
										<%--<asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											readonly="True" tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox>--%>
                                        <asp:textbox id="txtSPOT_MAIL_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
											tabindex="-1" runat="server" width="200px" cssclass="c-rNM" maxlength="50"></asp:textbox> 
									</td>
                                    <td></td>
                                </tr>
                            </table>
                            </td>
                            </tr>
                            </table>
						</div>
						<hr style="COLOR: black" width="95%">
						<table id="Table3" cellspacing="0" cellpadding="3">
							<tr>
                                <%-- 2014/12/15 T.Ono mod 2014改善開発 №4 START
								<td>電話連絡備考</td>
								<td><asp:textbox id="txtDENWABIKO" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabindex="21" runat="server"
										width="400px" cssclass="c-fI" textmode="MultiLine" height="45px"></asp:textbox></td> --%>
                                <td>FAXタイトル</td>
                                <td><cc1:ctlcombo id="cboFAX_TITLE" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus();fncSelectValue();"
										tabindex="22" runat="server" width="180px" cssclass="cb"></cc1:ctlcombo></td> 
                                <%-- 2014/12/15 T.Ono mod 2014改善開発 №4 END　--%>
                                <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
								<%--<td rowspan="3" valign="top">
									連絡先情報ファイル<br>
									<asp:textbox id="txtFileName1" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
										BorderWidth="1px" ReadOnly="True"></asp:textbox><asp:button ID="btnFileDownload1" runat="server" text="開く" /><br>
									<asp:textbox id="txtFileName2" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
										BorderWidth="1px" ReadOnly="True"></asp:textbox><asp:button ID="btnFileDownload2" runat="server" text="開く" />
								</td>--%>
                                <!-- <td rowspan="3" valign="top"> 2014/01/31 T.Ono mod 監視改善2013 -->
                                <td rowspan="2" valign="top">
									連絡先情報ファイル<br>
									<asp:textbox id="txtFileName1" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><asp:button ID="btnFileDownload1" runat="server" text="開く" /><br/>
									<asp:textbox id="txtFileName2" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><asp:button ID="btnFileDownload2" runat="server" text="開く" />
								</td>
                                <%-- 2014/12/15 T.Ono mod 2014改善開発 №4 START --%>
                                <td rowspan="2" valign="middle">
                                    <table id="tblFAXServer"class="W">
                                        <tr>
                                            <td>FAXサーバー&nbsp;：</td>
                                            <td align="center" valign="middle" width="30"><input id="rdoFAXServer1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										        tabIndex="5" type="radio" value="1" name="rdoFAXServer" runat="server" checked />
								            </td>
								            <td valign="middle" width="90"><label for="rdoFAXServer1">10.10.15.140&nbsp;&nbsp;</label></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="center" valign="middle" width="30"><input id="rdoFAXServer2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										        tabIndex="5" type="radio" value="2" name="rdoFAXServer" runat="server" />
								            </td>
								            <td valign="middle" width="90"><label for="rdoFAXServer2">10.10.15.141&nbsp;&nbsp;</label></td>
                                        </tr>                                                                   
                                    </table>
                                </td>
                                <%-- 2014/12/15 T.Ono mod 2014改善開発 №4 END --%>
							</tr>
							<tr>
								<%-- 2014/12/15 T.Ono mod 2014改善開発 №4 START --%>
                                <%-- <td>FAXタイトル</td> --%>
								<%-- <td> --%>
                                    <%-- 2013/08/22 T.Ono mod 監視改善2013№1 
                                    <cc1:ctlcombo id="cboFAX_TITLE" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
										tabindex="22" runat="server" width="180px" cssclass="cb"></cc1:ctlcombo> --%>
                                    <%-- <cc1:ctlcombo id="cboFAX_TITLE" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
										tabindex="22" runat="server" width="180px" cssclass="cb"></cc1:ctlcombo>
									<iframe id="ifFax" tabindex="-1" name="ifFax" align="left" marginwidth="0" src="" frameborder="0"
										width="0" scrolling="no" height="0"></iframe> --%>
								<%-- </td> --%>
								<td>メモ欄</td>
                                <td><asp:textbox id="txtFAX_REN" onblur="fncFo(this,1);fncDelKAIGYO(this)" onfocus="fncFo(this,2)" tabindex="23" runat="server"
										width="400px" cssclass="c-fI" textmode="MultiLine" height="48px"></asp:textbox>
									<iframe id="ifFax" tabindex="-1" name="ifFax" align="left" marginwidth="0" src="" frameborder="0"
										width="0" scrolling="no" height="0"></iframe>
								</td>
                                <%-- 2014/12/15 T.Ono mod 2014改善開発 №4 END --%>
							</tr>
							<%-- 2014/12/15 T.Ono mod 2014改善開発 №4 START
                            <tr>
                                <td>FAX連絡欄</td>
								<td><asp:textbox id="txtFAX_REN" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabindex="23" runat="server"
										width="400px" cssclass="c-fI" textmode="MultiLine" height="45px"></asp:textbox></td> 
                                <!-- 2014/01/31 T.Ono add 監視改善2013 -->
                                <td>
                                    <table id="tblFAXServer"class="W">
                                        <tr>
                                            <td>FAXサーバー&nbsp;：</td>
                                            <td align="center" valign="middle" width="30"><input id="rdoFAXServer1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										        tabIndex="5" type="radio" value="3" name="rdoFAXServer" runat="server" checked>
								            </td>
								            <td valign="middle" width="90"><label for="rdoFAXServer1">10.10.15.140&nbsp;&nbsp;</label></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td align="center" valign="middle" width="30"><input id="rdoFAXServer2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										        tabIndex="5" type="radio" value="3" name="rdoFAXServer" runat="server">
								            </td>
								            <td valign="middle" width="90"><label for="rdoFAXServer2">10.10.15.141&nbsp;&nbsp;</label></td>
                                        </tr>                                
                                    </table>
                                </td>
                            </tr>
                            2014/12/15 T.Ono mod 2014改善開発 №4 END --%>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
