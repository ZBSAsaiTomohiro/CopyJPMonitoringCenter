<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSKYOJAG00.aspx.vb" Inherits="MSKYOJAG00.MSKYOJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>供給センターマスタ</title>
	</HEAD>
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
											<td class="TITLE" vAlign="middle">供給センターマスタ</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<input id="hdnKBN" type="hidden" name="hdnKBN" runat="server"  />
						<input id="txtAYMD" type="hidden" name="txtAYMD" runat="server" />
						<input id="txtUYMD" type="hidden" name="txtUYMD" runat="server" />
						<input id="hdnTIME" type="hidden" name="hdnTIME" runat="server" />
						<input id="hdnEDT_DT_1" type="hidden" name="hdnEDT_DT_1" runat="server" />
						<input id="hdnEDT_DT_2" type="hidden" name="hdnEDT_DT_2" runat="server" />
						<input id="hdnEDT_DT_3" type="hidden" name="hdnEDT_DT_3" runat="server" />
						<input id="hdnEDT_DT_4" type="hidden" name="hdnEDT_DT_4" runat="server" />
						<input id="hdnEDT_DT_5" type="hidden" name="hdnEDT_DT_5" runat="server" />
						<input id="hdnEDT_DT_6" type="hidden" name="hdnEDT_DT_6" runat="server" />
						<input id="hdnEDT_DT_7" type="hidden" name="hdnEDT_DT_7" runat="server" />
						<input id="hdnEDT_DT_8" type="hidden" name="hdnEDT_DT_8" runat="server" />
						<input id="hdnEDT_DT_9" type="hidden" name="hdnEDT_DT_9" runat="server" />
						<input id="hdnEDT_DT_10" type="hidden" name="hdnEDT_DT_10" runat="server" />
						<input id="hdnEDT_DT_11" type="hidden" name="hdnEDT_DT_11" runat="server" />
						<input id="hdnEDT_DT_12" type="hidden" name="hdnEDT_DT_12" runat="server" />
						<input id="hdnEDT_DT_13" type="hidden" name="hdnEDT_DT_13" runat="server" />
						<input id="hdnEDT_DT_14" type="hidden" name="hdnEDT_DT_14" runat="server" />
						<input id="hdnEDT_DT_15" type="hidden" name="hdnEDT_DT_15" runat="server" />
						<input id="hdnEDT_DT_16" type="hidden" name="hdnEDT_DT_16" runat="server" />
						<input id="hdnEDT_DT_17" type="hidden" name="hdnEDT_DT_17" runat="server" />
						<input id="hdnEDT_DT_18" type="hidden" name="hdnEDT_DT_18" runat="server" />
						<input id="hdnEDT_DT_19" type="hidden" name="hdnEDT_DT_19" runat="server" />
						<input id="hdnEDT_DT_20" type="hidden" name="hdnEDT_DT_20" runat="server" />
						<input id="hdnEDT_DT_21" type="hidden" name="hdnEDT_DT_21" runat="server" />
						<input id="hdnEDT_DT_22" type="hidden" name="hdnEDT_DT_22" runat="server" />
						<input id="hdnEDT_DT_23" type="hidden" name="hdnEDT_DT_23" runat="server" />
						<input id="hdnEDT_DT_24" type="hidden" name="hdnEDT_DT_24" runat="server" />
						<input id="hdnEDT_DT_25" type="hidden" name="hdnEDT_DT_25" runat="server" />
						<input id="hdnEDT_DT_26" type="hidden" name="hdnEDT_DT_26" runat="server" />
						<input id="hdnEDT_DT_27" type="hidden" name="hdnEDT_DT_27" runat="server" />
						<input id="hdnEDT_DT_28" type="hidden" name="hdnEDT_DT_28" runat="server" />
						<input id="hdnEDT_DT_29" type="hidden" name="hdnEDT_DT_29" runat="server" />
						<input id="hdnEDT_DT_30" type="hidden" name="hdnEDT_DT_30" runat="server" />
						<input id="hdnADD_DT_1" type="hidden" name="hdnADD_DT_1" runat="server" />
						<input id="hdnADD_DT_2" type="hidden" name="hdnADD_DT_2" runat="server" />
						<input id="hdnADD_DT_3" type="hidden" name="hdnADD_DT_3" runat="server" />
						<input id="hdnADD_DT_4" type="hidden" name="hdnADD_DT_4" runat="server" />
						<input id="hdnADD_DT_5" type="hidden" name="hdnADD_DT_5" runat="server" />
						<input id="hdnADD_DT_6" type="hidden" name="hdnADD_DT_6" runat="server" />
						<input id="hdnADD_DT_7" type="hidden" name="hdnADD_DT_7" runat="server" />
						<input id="hdnADD_DT_8" type="hidden" name="hdnADD_DT_8" runat="server" />
						<input id="hdnADD_DT_9" type="hidden" name="hdnADD_DT_9" runat="server" />
						<input id="hdnADD_DT_10" type="hidden" name="hdnADD_DT_10" runat="server" />
						<input id="hdnADD_DT_11" type="hidden" name="hdnADD_DT_11" runat="server" />
						<input id="hdnADD_DT_12" type="hidden" name="hdnADD_DT_12" runat="server" />
						<input id="hdnADD_DT_13" type="hidden" name="hdnADD_DT_13" runat="server" />
						<input id="hdnADD_DT_14" type="hidden" name="hdnADD_DT_14" runat="server" />
						<input id="hdnADD_DT_15" type="hidden" name="hdnADD_DT_15" runat="server" />
						<input id="hdnADD_DT_16" type="hidden" name="hdnADD_DT_16" runat="server" />
						<input id="hdnADD_DT_17" type="hidden" name="hdnADD_DT_17" runat="server" />
						<input id="hdnADD_DT_18" type="hidden" name="hdnADD_DT_18" runat="server" />
						<input id="hdnADD_DT_19" type="hidden" name="hdnADD_DT_19" runat="server" />
						<input id="hdnADD_DT_20" type="hidden" name="hdnADD_DT_20" runat="server" />
						<input id="hdnADD_DT_21" type="hidden" name="hdnADD_DT_21" runat="server" />
						<input id="hdnADD_DT_22" type="hidden" name="hdnADD_DT_22" runat="server" />
						<input id="hdnADD_DT_23" type="hidden" name="hdnADD_DT_23" runat="server" />
						<input id="hdnADD_DT_24" type="hidden" name="hdnADD_DT_24" runat="server" />
						<input id="hdnADD_DT_25" type="hidden" name="hdnADD_DT_25" runat="server" />
						<input id="hdnADD_DT_26" type="hidden" name="hdnADD_DT_26" runat="server" />
						<input id="hdnADD_DT_27" type="hidden" name="hdnADD_DT_27" runat="server" />
						<input id="hdnADD_DT_28" type="hidden" name="hdnADD_DT_28" runat="server" />
						<input id="hdnADD_DT_29" type="hidden" name="hdnADD_DT_29" runat="server" />
						<input id="hdnADD_DT_30" type="hidden" name="hdnADD_DT_30" runat="server" />
					</td>
				</tr>
			</table>
			<hr>
            <table cellSpacing="1" cellPadding="5" width="1150">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="60" class="TXTKY" align="right" style="font-size:15px;">県コード</td>
                    <td width="350">
                        <asp:textbox id="txtKENCD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"	BorderWidth="1px" />
                        <input class="bt-KS" id="btnKENCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');" tabIndex="2" type="button" value="▼" name="btnKENCD" runat="server" />
                        <input id="hdnKENCD" type="hidden" name="hdnKENCD" runat="server" />
						<input id="hdnKENCD_MOTO" type="hidden" name="hdnKENCD_MOTO" runat="server" />
					</td>
                    <td style="width:330px;"></td>
                    <td>
                    <span id="spS1"><a href="MSKYOJAG00.pdf" target="_blank" tabindex="3"><img src="../../../Script/icon_pdf.gif" border="0">マニュアル&nbsp;&nbsp;</a></span>
                    </td>

				</tr>
				<tr>
                    <td  colspan="4" style="width:690px;"></td>
                    <td>
                        <input id="btnCSVout" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnCsv_onclick();" tabIndex="4" type="button" value="データ出力" name="btnCSVout" runat="server" />
					</td>
				</tr>
			</table>
			<input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server" /> 
			<hr/>
			<div id="page1">
				<table cellSpacing="0" cellPadding="0" style="margin-left:20px;">
                    <tr>
                        <td colspan="4" style="height:25px;">
                            <input id="checkbtn" type="button" value="全て選択" onclick="btnCheckBtn('1');" tabindex="5"/>
                            <input id="nocheckbtn" type="button" value="全て解除" onclick="btnCheckBtn('2');" tabindex="6"/>
                        </td>
                        <td style="width:380px;"></td>
                        <td><font style="color:Red;">表示件数：最大30件</font></td>
                    </tr>
					<tr id="koumoku">
						<td id="DispNo_0" style="text-align:center;height:25px;font-size:15px;">№</td>
						<td id="DispDel_0" style="text-align:center;height:25px;font-size:15px;">削</td>
						<td id="DispKyokyu_0" style="text-align:center;height:25px;font-size:15px;">供給センターコード</td>
						<td id="DispKyokyuNm_0" style="text-align:center;height:25px;font-size:15px;">供給センター名称</td>
					</tr>
					<tr id="list_1">
                        <td id="DispNo_1">
                        	<input id="hdnDISP_NO_1" type="hidden" name="hdnDISP_NO_1" runat="server" />
							<asp:textbox id="txtNO_1" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="01"/>
						</td>
						<td id="DispDel_1" style="text-align:center;">
							<asp:checkbox id="chkDEL_1" tabIndex="7" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_1">
							<asp:textbox id="txtKYOKYU_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_1">
							<asp:textbox id="txtKYOKYUNM_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_2">
                        <td id="DispNo_2">
                        	<input id="hdnDISP_NO_2" type="hidden" name="hdnDISP_NO_2" runat="server" />
							<asp:textbox id="txtNO_2" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="02"/>
						</td>
						<td id="DispDel_2" style="text-align:center;">
							<asp:checkbox id="chkDEL_2" tabIndex="8" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_2">
							<asp:textbox id="txtKYOKYU_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="8" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_2">
							<asp:textbox id="txtKYOKYUNM_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="8" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_3">
                        <td id="DispNo_3">
                        	<input id="hdnDISP_NO_3" type="hidden" name="hdnDISP_NO_3" runat="server" />
							<asp:textbox id="txtNO_3" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="03"/>
						</td>
						<td id="DispDel_3" style="text-align:center;">
							<asp:checkbox id="chkDEL_3" tabIndex="9" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_3">
							<asp:textbox id="txtKYOKYU_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="9" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_3">
							<asp:textbox id="txtKYOKYUNM_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="9" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_4">
                        <td id="DispNo_4">
                        	<input id="hdnDISP_NO_4" type="hidden" name="hdnDISP_NO_4" runat="server" />
							<asp:textbox id="txtNO_4" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="04"/>
						</td>
						<td id="DispDel_4" style="text-align:center;">
							<asp:checkbox id="chkDEL_4" tabIndex="10" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_4">
							<asp:textbox id="txtKYOKYU_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="10" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_4">
							<asp:textbox id="txtKYOKYUNM_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="10" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_5">
                        <td id="DispNo_5">
                        	<input id="hdnDISP_NO_5" type="hidden" name="hdnDISP_NO_5" runat="server" />
							<asp:textbox id="txtNO_5" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="05"/>
						</td>
						<td id="DispDel_5" style="text-align:center;">
							<asp:checkbox id="chkDEL_5" tabIndex="11" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_5">
							<asp:textbox id="txtKYOKYU_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="11" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_5">
							<asp:textbox id="txtKYOKYUNM_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="11" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_6">
                        <td id="DispNo_6">
                        	<input id="hdnDISP_NO_6" type="hidden" name="hdnDISP_NO_6" runat="server" />
							<asp:textbox id="txtNO_6" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="06"/>
						</td>
						<td id="DispDel_6" style="text-align:center;">
							<asp:checkbox id="chkDEL_6" tabIndex="12" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_6">
							<asp:textbox id="txtKYOKYU_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="12" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_6">
							<asp:textbox id="txtKYOKYUNM_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="12" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_7">
                        <td id="DispNo_7">
                        	<input id="hdnDISP_NO_7" type="hidden" name="hdnDISP_NO_7" runat="server" />
							<asp:textbox id="txtNO_7" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="07"/>
						</td>
						<td id="DispDel_7" style="text-align:center;">
							<asp:checkbox id="chkDEL_7" tabIndex="13" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_7">
							<asp:textbox id="txtKYOKYU_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="13" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_7">
							<asp:textbox id="txtKYOKYUNM_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="13" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_8">
                        <td id="DispNo_8">
                        	<input id="hdnDISP_NO_8" type="hidden" name="hdnDISP_NO_8" runat="server" />
							<asp:textbox id="txtNO_8" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="08"/>
						</td>
						<td id="DispDel_8" style="text-align:center;">
							<asp:checkbox id="chkDEL_8" tabIndex="14" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_8">
							<asp:textbox id="txtKYOKYU_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="14" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_8">
							<asp:textbox id="txtKYOKYUNM_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="14" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_9">
                        <td id="DispNo_9">
                        	<input id="hdnDISP_NO_9" type="hidden" name="hdnDISP_NO_9" runat="server" />
							<asp:textbox id="txtNO_9" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="09"/>
						</td>
						<td id="DispDel_9" style="text-align:center;">
							<asp:checkbox id="chkDEL_9" tabIndex="15" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_9">
							<asp:textbox id="txtKYOKYU_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="15" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_9">
							<asp:textbox id="txtKYOKYUNM_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="15" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_10">
                        <td id="DispNo_10">
                        	<input id="hdnDISP_NO_10" type="hidden" name="hdnDISP_NO_10" runat="server" />
							<asp:textbox id="txtNO_10" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="10"/>
						</td>
						<td id="DispDel_10" style="text-align:center;">
							<asp:checkbox id="chkDEL_10" tabIndex="16" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_10">
							<asp:textbox id="txtKYOKYU_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="16" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_10">
							<asp:textbox id="txtKYOKYUNM_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="16" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_11">
                        <td id="DispNo_11">
                        	<input id="hdnDISP_NO_11" type="hidden" name="hdnDISP_NO_11" runat="server" />
							<asp:textbox id="txtNO_11" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="11"/>
						</td>
						<td id="DispDel_11" style="text-align:center;">
							<asp:checkbox id="chkDEL_11" tabIndex="17" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_11">
							<asp:textbox id="txtKYOKYU_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="17" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_11">
							<asp:textbox id="txtKYOKYUNM_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="17" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_12">
                        <td id="DispNo_12">
                        	<input id="hdnDISP_NO_12" type="hidden" name="hdnDISP_NO_12" runat="server" />
							<asp:textbox id="txtNO_12" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="12"/>
						</td>
						<td id="DispDel_12" style="text-align:center;">
							<asp:checkbox id="chkDEL_12" tabIndex="18" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_12">
							<asp:textbox id="txtKYOKYU_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="18" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_12">
							<asp:textbox id="txtKYOKYUNM_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="18" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_13">
                        <td id="DispNo_13">
                        	<input id="hdnDISP_NO_13" type="hidden" name="hdnDISP_NO_13" runat="server" />
							<asp:textbox id="txtNO_13" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="13"/>
						</td>
						<td id="DispDel_13" style="text-align:center;">
							<asp:checkbox id="chkDEL_13" tabIndex="19" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_13">
							<asp:textbox id="txtKYOKYU_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="19" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_13">
							<asp:textbox id="txtKYOKYUNM_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="19" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_14">
                        <td id="DispNo_14">
                        	<input id="hdnDISP_NO_14" type="hidden" name="hdnDISP_NO_14" runat="server" />
							<asp:textbox id="txtNO_14" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="14"/>
						</td>
						<td id="DispDel_14" style="text-align:center;">
							<asp:checkbox id="chkDEL_14" tabIndex="20" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_14">
							<asp:textbox id="txtKYOKYU_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="20" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_14">
							<asp:textbox id="txtKYOKYUNM_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="20" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_15">
                        <td id="DispNo_15">
                        	<input id="hdnDISP_NO_15" type="hidden" name="hdnDISP_NO_15" runat="server" />
							<asp:textbox id="txtNO_15" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="15"/>
						</td>
						<td id="DispDel_15" style="text-align:center;">
							<asp:checkbox id="chkDEL_15" tabIndex="21" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_15">
							<asp:textbox id="txtKYOKYU_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="21" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_15">
							<asp:textbox id="txtKYOKYUNM_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="21" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_16">
                        <td id="DispNo_16">
                        	<input id="hdnDISP_NO_16" type="hidden" name="hdnDISP_NO_16" runat="server" />
							<asp:textbox id="txtNO_16" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="16"/>
						</td>
						<td id="DispDel_16" style="text-align:center;">
							<asp:checkbox id="chkDEL_16" tabIndex="22" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_16">
							<asp:textbox id="txtKYOKYU_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="22" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_16">
							<asp:textbox id="txtKYOKYUNM_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="22" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_17">
                        <td id="DispNo_17">
                        	<input id="hdnDISP_NO_17" type="hidden" name="hdnDISP_NO_17" runat="server" />
							<asp:textbox id="txtNO_17" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="17"/>
						</td>
						<td id="DispDel_17" style="text-align:center;">
							<asp:checkbox id="chkDEL_17" tabIndex="23" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_17">
							<asp:textbox id="txtKYOKYU_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="23" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_17">
							<asp:textbox id="txtKYOKYUNM_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="23" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_18">
                        <td id="DispNo_18">
                        	<input id="hdnDISP_NO_18" type="hidden" name="hdnDISP_NO_18" runat="server" />
							<asp:textbox id="txtNO_18" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="18"/>
						</td>
						<td id="DispDel_18" style="text-align:center;">
							<asp:checkbox id="chkDEL_18" tabIndex="24" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_18">
							<asp:textbox id="txtKYOKYU_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="24" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_18">
							<asp:textbox id="txtKYOKYUNM_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="24" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_19">
                        <td id="DispNo_19">
                        	<input id="hdnDISP_NO_19" type="hidden" name="hdnDISP_NO_19" runat="server" />
							<asp:textbox id="txtNO_19" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="19"/>
						</td>
						<td id="DispDel_19" style="text-align:center;">
							<asp:checkbox id="chkDEL_19" tabIndex="25" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_19">
							<asp:textbox id="txtKYOKYU_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="25" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_19">
							<asp:textbox id="txtKYOKYUNM_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="25" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_20">
                        <td id="DispNo_20">
                        	<input id="hdnDISP_NO_20" type="hidden" name="hdnDISP_NO_20" runat="server" />
							<asp:textbox id="txtNO_20" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="20"/>
						</td>
						<td id="DispDel_20" style="text-align:center;">
							<asp:checkbox id="chkDEL_20" tabIndex="26" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_20">
							<asp:textbox id="txtKYOKYU_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="26" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_20">
							<asp:textbox id="txtKYOKYUNM_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="26" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_21">
                        <td id="DispNo_21">
                        	<input id="hdnDISP_NO_21" type="hidden" name="hdnDISP_NO_21" runat="server" />
							<asp:textbox id="txtNO_21" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="21"/>
						</td>
						<td id="DispDel_21" style="text-align:center;">
							<asp:checkbox id="chkDEL_21" tabIndex="27" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_21">
							<asp:textbox id="txtKYOKYU_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="27" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_21">
							<asp:textbox id="txtKYOKYUNM_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="27" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_22">
                        <td id="DispNo_22">
                        	<input id="hdnDISP_NO_22" type="hidden" name="hdnDISP_NO_22" runat="server" />
							<asp:textbox id="txtNO_22" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="22"/>
						</td>
						<td id="DispDel_22" style="text-align:center;">
							<asp:checkbox id="chkDEL_22" tabIndex="28" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_22">
							<asp:textbox id="txtKYOKYU_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="28" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_22">
							<asp:textbox id="txtKYOKYUNM_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="28" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_23">
                        <td id="DispNo_23">
                        	<input id="hdnDISP_NO_23" type="hidden" name="hdnDISP_NO_23" runat="server" />
							<asp:textbox id="txtNO_23" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="23"/>
						</td>
						<td id="DispDel_23" style="text-align:center;">
							<asp:checkbox id="chkDEL_23" tabIndex="29" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_23">
							<asp:textbox id="txtKYOKYU_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="29" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_23">
							<asp:textbox id="txtKYOKYUNM_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="29" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_24">
                        <td id="DispNo_24">
                        	<input id="hdnDISP_NO_24" type="hidden" name="hdnDISP_NO_24" runat="server" />
							<asp:textbox id="txtNO_24" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="24"/>
						</td>
						<td id="DispDel_24" style="text-align:center;">
							<asp:checkbox id="chkDEL_24" tabIndex="30" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_24">
							<asp:textbox id="txtKYOKYU_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="30" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_24">
							<asp:textbox id="txtKYOKYUNM_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="30" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_25">
                        <td id="DispNo_25">
                        	<input id="hdnDISP_NO_25" type="hidden" name="hdnDISP_NO_25" runat="server" />
							<asp:textbox id="txtNO_25" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="25"/>
						</td>
						<td id="DispDel_25" style="text-align:center;">
							<asp:checkbox id="chkDEL_25" tabIndex="31" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_25">
							<asp:textbox id="txtKYOKYU_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="31" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_25">
							<asp:textbox id="txtKYOKYUNM_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="31" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_26">
                        <td id="DispNo_26">
                        	<input id="hdnDISP_NO_26" type="hidden" name="hdnDISP_NO_26" runat="server" />
							<asp:textbox id="txtNO_26" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="26"/>
						</td>
						<td id="DispDel_26" style="text-align:center;">
							<asp:checkbox id="chkDEL_26" tabIndex="32" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_26">
							<asp:textbox id="txtKYOKYU_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="32" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_26">
							<asp:textbox id="txtKYOKYUNM_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="32" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_27">
                        <td id="DispNo_27">
                        	<input id="hdnDISP_NO_27" type="hidden" name="hdnDISP_NO_27" runat="server" />
							<asp:textbox id="txtNO_27" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="27"/>
						</td>
						<td id="DispDel_27" style="text-align:center;">
							<asp:checkbox id="chkDEL_27" tabIndex="33" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_27">
							<asp:textbox id="txtKYOKYU_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="33" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_27">
							<asp:textbox id="txtKYOKYUNM_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="33" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_28">
                        <td id="DispNo_28">
                        	<input id="hdnDISP_NO_28" type="hidden" name="hdnDISP_NO_28" runat="server" />
							<asp:textbox id="txtNO_28" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="28"/>
						</td>
						<td id="DispDel_28" style="text-align:center;">
							<asp:checkbox id="chkDEL_28" tabIndex="34" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_28">
							<asp:textbox id="txtKYOKYU_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="34" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_28">
							<asp:textbox id="txtKYOKYUNM_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="34" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_29">
                        <td id="DispNo_29">
                        	<input id="hdnDISP_NO_29" type="hidden" name="hdnDISP_NO_29" runat="server" />
							<asp:textbox id="txtNO_29" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="29"/>
						</td>
						<td id="DispDel_29" style="text-align:center;">
							<asp:checkbox id="chkDEL_29" tabIndex="35" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_29">
							<asp:textbox id="txtKYOKYU_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="35" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_29">
							<asp:textbox id="txtKYOKYUNM_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="35" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
					<tr id="list_30">
                        <td id="DispNo_30">
                        	<input id="hdnDISP_NO_30" type="hidden" name="hdnDISP_NO_30" runat="server" />
							<asp:textbox id="txtNO_30" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="30"/>
						</td>
						<td id="DispDel_30" style="text-align:center;">
							<asp:checkbox id="chkDEL_30" tabIndex="36" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispKyokyu_30">
							<asp:textbox id="txtKYOKYU_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="36" runat="server" CssClass="c-h" Width="120px" MaxLength="10" />
						</td>
						<td id="DispKyokyuNm_30">
							<asp:textbox id="txtKYOKYUNM_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="36" runat="server" CssClass="c-hI" Width="220px" MaxLength="15" />
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
