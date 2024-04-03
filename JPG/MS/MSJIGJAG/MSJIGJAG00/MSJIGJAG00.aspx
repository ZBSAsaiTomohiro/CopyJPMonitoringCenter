<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSJIGJAG00.aspx.vb" Inherits="MSJIGJAG00.MSJIGJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSJIGJAG00</title>
	</HEAD>
		<% 
'***********************************************
		    ' 自動対応グループマスタ  画面
'***********************************************
' 変更履歴	    
%>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server" />
			<input id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server" />
			<input id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server" />
			<input id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server" />
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="*">
	                                <input class="bt-JIK" id="btnSelect" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="1001" type="button" value="検索" name="btnSelect" runat="server" />
								</td>
								<td width="300">&nbsp;</td>
								<td width="220">
									<input class="bt-JIK" id="btnUpdate" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnUpdate_onclick();" tabIndex="1002" type="button" value="登録" name="btnUpdate" runat="server" />
								</td>
								<td width="220">
									<input class="bt-JIK" id="btnDelete" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnDelete_onclick();" tabIndex="1003" type="button" value="削除" name="btnDelete" runat="server" />
								</td>
								<td width="70">
									<input class="bt-JIK" id="btnClear" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnClear_onclick();" tabIndex="1005" type="button" value="取消" name="btnClear" runat="server" />
								</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80">
									<input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();" tabIndex="1006" type="button" value="終了" name="btnExit" runat="server" />
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
											<td class="TITLE" vAlign="middle">自動対応グループマスタ</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<input id="hdnKBN" type="hidden" name="hdnKBN" runat="server"  />
						<input id="hdnINS_DATE_1" type="hidden" name="hdnINS_DATE_1" runat="server" />
						<input id="hdnINS_DATE_2" type="hidden" name="hdnINS_DATE_2" runat="server" />
						<input id="hdnINS_DATE_3" type="hidden" name="hdnINS_DATE_3" runat="server" />
						<input id="hdnINS_DATE_4" type="hidden" name="hdnINS_DATE_4" runat="server" />
						<input id="hdnINS_DATE_5" type="hidden" name="hdnINS_DATE_5" runat="server" />
						<input id="hdnINS_DATE_6" type="hidden" name="hdnINS_DATE_6" runat="server" />
						<input id="hdnINS_DATE_7" type="hidden" name="hdnINS_DATE_7" runat="server" />
						<input id="hdnINS_DATE_8" type="hidden" name="hdnINS_DATE_8" runat="server" />
						<input id="hdnINS_DATE_9" type="hidden" name="hdnINS_DATE_9" runat="server" />
						<input id="hdnINS_DATE_10" type="hidden" name="hdnINS_DATE_10" runat="server" />
						<input id="hdnINS_DATE_11" type="hidden" name="hdnINS_DATE_11" runat="server" />
						<input id="hdnINS_DATE_12" type="hidden" name="hdnINS_DATE_12" runat="server" />
						<input id="hdnINS_DATE_13" type="hidden" name="hdnINS_DATE_13" runat="server" />
						<input id="hdnINS_DATE_14" type="hidden" name="hdnINS_DATE_14" runat="server" />
						<input id="hdnINS_DATE_15" type="hidden" name="hdnINS_DATE_15" runat="server" />
						<input id="hdnINS_DATE_16" type="hidden" name="hdnINS_DATE_16" runat="server" />
						<input id="hdnINS_DATE_17" type="hidden" name="hdnINS_DATE_17" runat="server" />
						<input id="hdnINS_DATE_18" type="hidden" name="hdnINS_DATE_18" runat="server" />
						<input id="hdnINS_DATE_19" type="hidden" name="hdnINS_DATE_19" runat="server" />
						<input id="hdnINS_DATE_20" type="hidden" name="hdnINS_DATE_20" runat="server" />
						<input id="hdnINS_DATE_21" type="hidden" name="hdnINS_DATE_21" runat="server" />
						<input id="hdnINS_DATE_22" type="hidden" name="hdnINS_DATE_22" runat="server" />
						<input id="hdnINS_DATE_23" type="hidden" name="hdnINS_DATE_23" runat="server" />
						<input id="hdnINS_DATE_24" type="hidden" name="hdnINS_DATE_24" runat="server" />
						<input id="hdnINS_DATE_25" type="hidden" name="hdnINS_DATE_25" runat="server" />
						<input id="hdnINS_DATE_26" type="hidden" name="hdnINS_DATE_26" runat="server" />
						<input id="hdnINS_DATE_27" type="hidden" name="hdnINS_DATE_27" runat="server" />
						<input id="hdnINS_DATE_28" type="hidden" name="hdnINS_DATE_28" runat="server" />
						<input id="hdnINS_DATE_29" type="hidden" name="hdnINS_DATE_29" runat="server" />
						<input id="hdnINS_DATE_30" type="hidden" name="hdnINS_DATE_30" runat="server" />
                        <input id="hdnINS_DATE_31" type="hidden" name="hdnINS_DATE_31" runat="server" />
						<input id="hdnINS_DATE_32" type="hidden" name="hdnINS_DATE_32" runat="server" />
						<input id="hdnINS_DATE_33" type="hidden" name="hdnINS_DATE_33" runat="server" />
						<input id="hdnINS_DATE_34" type="hidden" name="hdnINS_DATE_34" runat="server" />
						<input id="hdnINS_DATE_35" type="hidden" name="hdnINS_DATE_35" runat="server" />
						<input id="hdnINS_DATE_36" type="hidden" name="hdnINS_DATE_36" runat="server" />
						<input id="hdnINS_DATE_37" type="hidden" name="hdnINS_DATE_37" runat="server" />
						<input id="hdnINS_DATE_38" type="hidden" name="hdnINS_DATE_38" runat="server" />
						<input id="hdnINS_DATE_39" type="hidden" name="hdnINS_DATE_39" runat="server" />
						<input id="hdnINS_DATE_40" type="hidden" name="hdnINS_DATE_40" runat="server" />
						<input id="hdnINS_DATE_41" type="hidden" name="hdnINS_DATE_41" runat="server" />
						<input id="hdnINS_DATE_42" type="hidden" name="hdnINS_DATE_42" runat="server" />
						<input id="hdnINS_DATE_43" type="hidden" name="hdnINS_DATE_43" runat="server" />
						<input id="hdnINS_DATE_44" type="hidden" name="hdnINS_DATE_44" runat="server" />
						<input id="hdnINS_DATE_45" type="hidden" name="hdnINS_DATE_45" runat="server" />
						<input id="hdnINS_DATE_46" type="hidden" name="hdnINS_DATE_46" runat="server" />
						<input id="hdnINS_DATE_47" type="hidden" name="hdnINS_DATE_47" runat="server" />
						<input id="hdnINS_DATE_48" type="hidden" name="hdnINS_DATE_48" runat="server" />
						<input id="hdnINS_DATE_49" type="hidden" name="hdnINS_DATE_49" runat="server" />
						<input id="hdnINS_DATE_50" type="hidden" name="hdnINS_DATE_50" runat="server" />
						<input id="hdnUPD_DATE_1" type="hidden" name="hdnUPD_DATE_1" runat="server" />
						<input id="hdnUPD_DATE_2" type="hidden" name="hdnUPD_DATE_2" runat="server" />
						<input id="hdnUPD_DATE_3" type="hidden" name="hdnUPD_DATE_3" runat="server" />
						<input id="hdnUPD_DATE_4" type="hidden" name="hdnUPD_DATE_4" runat="server" />
						<input id="hdnUPD_DATE_5" type="hidden" name="hdnUPD_DATE_5" runat="server" />
						<input id="hdnUPD_DATE_6" type="hidden" name="hdnUPD_DATE_6" runat="server" />
						<input id="hdnUPD_DATE_7" type="hidden" name="hdnUPD_DATE_7" runat="server" />
						<input id="hdnUPD_DATE_8" type="hidden" name="hdnUPD_DATE_8" runat="server" />
						<input id="hdnUPD_DATE_9" type="hidden" name="hdnUPD_DATE_9" runat="server" />
						<input id="hdnUPD_DATE_10" type="hidden" name="hdnUPD_DATE_10" runat="server" />
						<input id="hdnUPD_DATE_11" type="hidden" name="hdnUPD_DATE_11" runat="server" />
						<input id="hdnUPD_DATE_12" type="hidden" name="hdnUPD_DATE_12" runat="server" />
						<input id="hdnUPD_DATE_13" type="hidden" name="hdnUPD_DATE_13" runat="server" />
						<input id="hdnUPD_DATE_14" type="hidden" name="hdnUPD_DATE_14" runat="server" />
						<input id="hdnUPD_DATE_15" type="hidden" name="hdnUPD_DATE_15" runat="server" />
						<input id="hdnUPD_DATE_16" type="hidden" name="hdnUPD_DATE_16" runat="server" />
						<input id="hdnUPD_DATE_17" type="hidden" name="hdnUPD_DATE_17" runat="server" />
						<input id="hdnUPD_DATE_18" type="hidden" name="hdnUPD_DATE_18" runat="server" />
						<input id="hdnUPD_DATE_19" type="hidden" name="hdnUPD_DATE_19" runat="server" />
						<input id="hdnUPD_DATE_20" type="hidden" name="hdnUPD_DATE_20" runat="server" />
						<input id="hdnUPD_DATE_21" type="hidden" name="hdnUPD_DATE_21" runat="server" />
						<input id="hdnUPD_DATE_22" type="hidden" name="hdnUPD_DATE_22" runat="server" />
						<input id="hdnUPD_DATE_23" type="hidden" name="hdnUPD_DATE_23" runat="server" />
						<input id="hdnUPD_DATE_24" type="hidden" name="hdnUPD_DATE_24" runat="server" />
						<input id="hdnUPD_DATE_25" type="hidden" name="hdnUPD_DATE_25" runat="server" />
						<input id="hdnUPD_DATE_26" type="hidden" name="hdnUPD_DATE_26" runat="server" />
						<input id="hdnUPD_DATE_27" type="hidden" name="hdnUPD_DATE_27" runat="server" />
						<input id="hdnUPD_DATE_28" type="hidden" name="hdnUPD_DATE_28" runat="server" />
						<input id="hdnUPD_DATE_29" type="hidden" name="hdnUPD_DATE_29" runat="server" />
						<input id="hdnUPD_DATE_30" type="hidden" name="hdnUPD_DATE_30" runat="server" />
                        <input id="hdnUPD_DATE_31" type="hidden" name="hdnUPD_DATE_31" runat="server" />
						<input id="hdnUPD_DATE_32" type="hidden" name="hdnUPD_DATE_32" runat="server" />
						<input id="hdnUPD_DATE_33" type="hidden" name="hdnUPD_DATE_33" runat="server" />
						<input id="hdnUPD_DATE_34" type="hidden" name="hdnUPD_DATE_34" runat="server" />
						<input id="hdnUPD_DATE_35" type="hidden" name="hdnUPD_DATE_35" runat="server" />
						<input id="hdnUPD_DATE_36" type="hidden" name="hdnUPD_DATE_36" runat="server" />
						<input id="hdnUPD_DATE_37" type="hidden" name="hdnUPD_DATE_37" runat="server" />
						<input id="hdnUPD_DATE_38" type="hidden" name="hdnUPD_DATE_38" runat="server" />
						<input id="hdnUPD_DATE_39" type="hidden" name="hdnUPD_DATE_39" runat="server" />
						<input id="hdnUPD_DATE_40" type="hidden" name="hdnUPD_DATE_40" runat="server" />
						<input id="hdnUPD_DATE_41" type="hidden" name="hdnUPD_DATE_41" runat="server" />
						<input id="hdnUPD_DATE_42" type="hidden" name="hdnUPD_DATE_42" runat="server" />
						<input id="hdnUPD_DATE_43" type="hidden" name="hdnUPD_DATE_43" runat="server" />
						<input id="hdnUPD_DATE_44" type="hidden" name="hdnUPD_DATE_44" runat="server" />
						<input id="hdnUPD_DATE_45" type="hidden" name="hdnUPD_DATE_45" runat="server" />
						<input id="hdnUPD_DATE_46" type="hidden" name="hdnUPD_DATE_46" runat="server" />
						<input id="hdnUPD_DATE_47" type="hidden" name="hdnUPD_DATE_47" runat="server" />
						<input id="hdnUPD_DATE_48" type="hidden" name="hdnUPD_DATE_48" runat="server" />
						<input id="hdnUPD_DATE_49" type="hidden" name="hdnUPD_DATE_49" runat="server" />
						<input id="hdnUPD_DATE_50" type="hidden" name="hdnUPD_DATE_50" runat="server" />
					</td>
				</tr>
			</table>
			<hr>
            <table cellSpacing="1" cellPadding="5" width="1150">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="100" class="TXTKY" align="right">クライアントコード&nbsp;&nbsp;</td>
                    <td width="350" >
                        <asp:textbox id="txtKURACD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"	BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabIndex="1" type="button" value="▼" name="btnKURACD" runat="server" />
                        <input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server" />
						<input id="hdnKURACD_MOTO" type="hidden" name="hdnCODE_MOTO" runat="server" />
					</td>
					<td width="350">
					</td>
					<td width="140">
                        <a href="MSJIGJAG00.pdf" target="_blank" tabIndex="7"><img src="../../../Script/icon_pdf.gif" border="0" alt="img" />マニュアル&nbsp;&nbsp;</a>
					</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td  class="TXTKY" align="right">JA支所コード&nbsp;&nbsp;</td>
                    <td>
                        <asp:textbox id="txtACBCD_F" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnACBCD_F" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="2" type="button" value="▼" name="btnACBCD_F" runat="server" />&nbsp;～
                        <input id="hdnACBCD_F" type="hidden" name="hdnACBCD_F" runat="server" />
						<input id="hdnACBCD_F_MOTO" type="hidden" name="hdnACBCD_F_MOTO" runat="server" />
					</td>
                    <td>
                        <asp:textbox id="txtACBCD_T" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnACBCD_T" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabIndex="3" type="button" value="▼" name="btnACBCD_T" runat="server" />
                        <input id="hdnACBCD_T" type="hidden" name="hdnACBCD_T" runat="server" />
						<input id="hdnACBCD_T_MOTO" type="hidden" name="hdnACBCD_T_MOTO" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
					<td class="TXTKY" align="right">グループコード&nbsp;&nbsp;</td>
                    <td><cc1:ctlcombo id="cboGROUPCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onchange="fncChengGroup()"
		                        tabindex="4" runat="server" width="200px" cssclass="cb"></cc1:ctlcombo>
                        <input id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server" />
						<input id="hdnGROUPCD_MOTO" type="hidden" name="hdnGROUPCD_MOTO" runat="server" />
                    </td>
                    <td align="right">
                        <input language="javascript" class="bt-RNW" id="btnIkkatu" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnikkatu_onclick();" tabIndex="5" type="button"
							value="一括登録" name="btnIkkatu" runat="server" />
                    </td>
                    <td>
                        <input language="javascript" class="bt-RNW" id="btnCSVout" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnCsv_onclick();" tabIndex="6" type="button"
							value="データ出力" name="btnCSVout" runat="server" />
                    </td>
                </tr>
			</table>
            <hr>
            <table>
                <tr>
                    <td width="80">
						<input type="button" name="AllSelect" value="全て選択" onclick="btnCheckBtn(1);" id="btnAllSelect" tabIndex="51" />
					</td>
                    <td width="80">
						<input type="button" name="AllRemove" value="全て解除" onclick="btnCheckBtn(2);" id="btnAllRemove" tabIndex="52" />
					</td>
					<td width="790" align="right"><font color="red">表示件数：最大50件</font></td>
                </tr>
            </table>
            <input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server" /> 
			<table cellSpacing="0" cellPadding="0"">
				<tr>
				    <td align="left" height="25">&nbsp;№</td>
				    <td align="left" height="25">&nbsp;&nbsp;削</td>
				    <td align="left" height="25">&nbsp;&nbsp;クライアントコード</td>
				    <td align="left" height="25">&nbsp;&nbsp;JA支所コード<br />（JAコードでの登録不可）</td>
				    <td align="left" height="25">&nbsp;&nbsp;グループコード</td>
				    <td align="left" height="25">&nbsp;&nbsp;使用フラグ</td>
				    <td align="left" height="25">&nbsp;&nbsp;備考</td>
				</tr>
				<tr id="list_1">
                    <%-- .NET 使用変更により、ReadOnlyはVB側でAttributeでつける --%>
                    <td>
                        <asp:textbox id="txtNo_1" value="01" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_1" tabIndex="111" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_1" type="hidden" name="hdnDEL_1" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="112" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="113" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="114" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="115" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="116" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_2">
                    <td>
                        <asp:textbox id="txtNo_2" value="02" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_2" tabIndex="121" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_2" type="hidden" name="hdnDEL_2" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="122" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="123" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="124" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="125" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="126" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_3">
                    <td>
                        <asp:textbox id="txtNo_3" value="03" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_3" tabIndex="131" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_3" type="hidden" name="hdnDEL_3" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="132" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="133" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="134" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="135" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="136" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_4">
                    <td>
                        <asp:textbox id="txtNo_4" value="04" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_4" tabIndex="141" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_4" type="hidden" name="hdnDEL_4" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="142" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="143" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="144" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="145" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="146" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_5">
                    <td>
                        <asp:textbox id="txtNo_5" value="05" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_5" tabIndex="151" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_5" type="hidden" name="hdnDEL_5" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="152" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="153" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="154" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="155" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="156" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_6">
                    <td>
                        <asp:textbox id="txtNo_6" value="06" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_6" tabIndex="161" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_6" type="hidden" name="hdnDEL_6" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="162" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="163" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="164" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="165" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="166" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_7">
                    <td>
                        <asp:textbox id="txtNo_7" value="07" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_7" tabIndex="171" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_7" type="hidden" name="hdnDEL_7" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="172" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="173" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="174" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="175" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="176" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_8">
                    <td>
                        <asp:textbox id="txtNo_8" value="08" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_8" tabIndex="181" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_8" type="hidden" name="hdnDEL_8" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="182" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="183" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="184" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="185" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="186" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_9">
                    <td>
                        <asp:textbox id="txtNo_9" value="09" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_9" tabIndex="191" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_9" type="hidden" name="hdnDEL_9" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="192" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="193" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="194" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="195" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="196" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_10">
                    <td>
                        <asp:textbox id="txtNo_10" value="10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_10" tabIndex="201" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_10" type="hidden" name="hdnDEL_10" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="202" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="203" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="204" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="205" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="206" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_11">
                    <td>
                        <asp:textbox id="txtNo_11" value="11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_11" tabIndex="211" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_11" type="hidden" name="hdnDEL_11" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="212" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="213" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="214" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="215" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="216" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_12">
                    <td>
                        <asp:textbox id="txtNo_12" value="12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_12" tabIndex="221" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_12" type="hidden" name="hdnDEL_12" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="222" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="223" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="224" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="225" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="226" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_13">
                    <td>
                        <asp:textbox id="txtNo_13" value="13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_13" tabIndex="231" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_13" type="hidden" name="hdnDEL_13" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="232" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="233" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="234" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="235" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="236" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_14">
                    <td>
                        <asp:textbox id="txtNo_14" value="14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_14" tabIndex="241" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_14" type="hidden" name="hdnDEL_14" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="241" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="243" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="244" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="245" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="246" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_15">
                    <td>
                        <asp:textbox id="txtNo_15" value="15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_15" tabIndex="251" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_15" type="hidden" name="hdnDEL_15" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="252" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="253" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="254" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="255" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="256" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_16">
                    <td>
                        <asp:textbox id="txtNo_16" value="16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_16" tabIndex="261" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_16" type="hidden" name="hdnDEL_16" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="262" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="263" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="264" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="265" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="266" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_17">
                    <td>
                        <asp:textbox id="txtNo_17" value="17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_17" tabIndex="271" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_17" type="hidden" name="hdnDEL_17" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="272" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="273" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="274" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="275" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="276" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_18">
                    <td>
                        <asp:textbox id="txtNo_18" value="18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_18" tabIndex="281" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_18" type="hidden" name="hdnDEL_18" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="282" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="283" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="284" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="285" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="286" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_19">
                    <td>
                        <asp:textbox id="txtNo_19" value="19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_19" tabIndex="291" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_19" type="hidden" name="hdnDEL_19" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="292" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="293" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="294" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="295" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="296" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_20">
                    <td>
                        <asp:textbox id="txtNo_20" value="20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_20" tabIndex="301" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_20" type="hidden" name="hdnDEL_20" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="302" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="303" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="304" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="305" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="306" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_21">
                    <td>
                        <asp:textbox id="txtNo_21" value="21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_21" tabIndex="311" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_21" type="hidden" name="hdnDEL_21" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="312" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="313" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="314" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="315" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="316" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_22">
                    <td>
                        <asp:textbox id="txtNo_22" value="22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_22" tabIndex="322" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_22" type="hidden" name="hdnDEL_22" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="323" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="323" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="324" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="325" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="326" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_23">
                    <td>
                        <asp:textbox id="txtNo_23" value="23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_23" tabIndex="331" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_23" type="hidden" name="hdnDEL_23" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="332" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="333" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="334" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="335" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="336" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_24">
                    <td>
                        <asp:textbox id="txtNo_24" value="24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_24" tabIndex="341" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_24" type="hidden" name="hdnDEL_24" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="342" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="343" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="344" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="345" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="346" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_25">
                    <td>
                        <asp:textbox id="txtNo_25" value="25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_25" tabIndex="351" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_25" type="hidden" name="hdnDEL_25" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="352" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="353" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="354" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="355" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="356" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_26">
                    <td>
                        <asp:textbox id="txtNo_26" value="26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_26" tabIndex="361" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_26" type="hidden" name="hdnDEL_26" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="362" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="363" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="364" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="365" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="366" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_27">
                    <td>
                        <asp:textbox id="txtNo_27" value="27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_27" tabIndex="371" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_27" type="hidden" name="hdnDEL_27" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="372" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="373" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="374" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="375" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="376" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_28">
                    <td>
                        <asp:textbox id="txtNo_28" value="28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_28" tabIndex="381" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_28" type="hidden" name="hdnDEL_28" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="382" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="383" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="384" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="385" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="386" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_29">
                    <td>
                        <asp:textbox id="txtNo_29" value="29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_29" tabIndex="391" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_29" type="hidden" name="hdnDEL_29" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="392" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="393" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="394" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="395" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="396" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_30">
                    <td>
                        <asp:textbox id="txtNo_30" value="30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_30" tabIndex="401" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_30" type="hidden" name="hdnDEL_30" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="402" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="403" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="404" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="405" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="406" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
                </tr>
				<tr id="list_31">
                    <td>
                        <asp:textbox id="txtNo_31" value="31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_31" tabIndex="411" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_31" type="hidden" name="hdnDEL_31" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="412" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="413" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="414" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="415" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="416" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_32">
                    <td>
                        <asp:textbox id="txtNo_32" value="32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_32" tabIndex="421" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_32" type="hidden" name="hdnDEL_32" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="422" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="423" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="424" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="425" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="426" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_33">
                    <td>
                        <asp:textbox id="txtNo_33" value="33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_33" tabIndex="431" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_33" type="hidden" name="hdnDEL_33" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="432" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="433" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="434" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="435" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="436" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_34">
                    <td>
                        <asp:textbox id="txtNo_34" value="34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_34" tabIndex="441" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_34" type="hidden" name="hdnDEL_34" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="442" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="443" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="444" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="445" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="446" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_35">
                    <td>
                        <asp:textbox id="txtNo_35" value="35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_35" tabIndex="451" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_35" type="hidden" name="hdnDEL_35" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="452" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="453" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="454" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="455" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="456" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_36">
                    <td>
                        <asp:textbox id="txtNo_36" value="36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_36" tabIndex="461" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_36" type="hidden" name="hdnDEL_36" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="462" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="463" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="464" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="465" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="466" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_37">
                    <td>
                        <asp:textbox id="txtNo_37" value="37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_37" tabIndex="471" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_37" type="hidden" name="hdnDEL_37" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="472" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="473" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="474" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="475" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="476" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_38">
                    <td>
                        <asp:textbox id="txtNo_38" value="38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_38" tabIndex="481" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_38" type="hidden" name="hdnDEL_38" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="482" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="483" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="484" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="485" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="486" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_39">
                    <td>
                        <asp:textbox id="txtNo_39" value="39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_39" tabIndex="491" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_39" type="hidden" name="hdnDEL_39" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="492" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="493" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="494" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="495" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="496" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_40">
                    <td>
                        <asp:textbox id="txtNo_40" value="40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_40" tabIndex="501" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_40" type="hidden" name="hdnDEL_40" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="502" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="503" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="504" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="505" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="506" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_41">
                    <td>
                        <asp:textbox id="txtNo_41" value="41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_41" tabIndex="511" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_41" type="hidden" name="hdnDEL_41" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="512" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="513" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="514" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="515" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="516" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_42">
                    <td>
                        <asp:textbox id="txtNo_42" value="42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_42" tabIndex="521" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_42" type="hidden" name="hdnDEL_42" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="522" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="523" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="524" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="525" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="526" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_43">
                    <td>
                        <asp:textbox id="txtNo_43" value="43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_43" tabIndex="531" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_43" type="hidden" name="hdnDEL_43" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="532" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="533" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="534" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="535" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="536" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_44">
                    <td>
                        <asp:textbox id="txtNo_44" value="44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_44" tabIndex="541" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_44" type="hidden" name="hdnDEL_44" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="542" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="543" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="544" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="545" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="546" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_45">
                    <td>
                        <asp:textbox id="txtNo_45" value="45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_45" tabIndex="551" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_45" type="hidden" name="hdnDEL_45" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="552" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="553" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="554" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="555" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="556" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_46">
                    <td>
                        <asp:textbox id="txtNo_46" value="46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_46" tabIndex="561" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_46" type="hidden" name="hdnDEL_46" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="562" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="563" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="564" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="565" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="566" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_47">
                    <td>
                        <asp:textbox id="txtNo_47" value="47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_47" tabIndex="571" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_47" type="hidden" name="hdnDEL_47" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="572" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="573" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="574" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="575" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="576" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_48">
                    <td>
                        <asp:textbox id="txtNo_48" value="48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_48" tabIndex="581" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_48" type="hidden" name="hdnDEL_48" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="582" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="583" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="584" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="585" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="586" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_49">
                    <td>
                        <asp:textbox id="txtNo_49" value="49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_49" tabIndex="591" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_49" type="hidden" name="hdnDEL_49" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="592" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="593" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="594" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="595" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="596" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_50">
                    <td>
                        <asp:textbox id="txtNo_50" value="50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_50" tabIndex="601" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_50" type="hidden" name="hdnDEL_50" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="602" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="603" runat="server" CssClass="c-h" Width="130px" MaxLength="10"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboGROUPCD_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="604" runat="server" width="130px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="605" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="606" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

