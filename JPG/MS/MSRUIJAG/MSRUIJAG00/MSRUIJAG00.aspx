<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSRUIJAG00.aspx.vb" Inherits="MSRUIJAG00.MSRUIJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>累積情報自動ＦＡＸ＆メールマスタ</title>
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
											<td class="TITLE" vAlign="middle">累積情報自動ＦＡＸ＆メールマスタ</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<input id="hdnKBN" type="hidden" name="hdnKBN" runat="server"  />
						<input id="txtAYMD" type="hidden" name="txtAYMD" runat="server" />
						<input id="txtUYMD" type="hidden" name="txtUYMD" runat="server" />
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
					<td class="TXTKY" align="right" style="width:120px;font-size:15px;">クライアントコード</td>
                    <td width="350">
                        <asp:textbox id="txtKURACD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"	BorderWidth="1px" /><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');" tabIndex="1" type="button" value="▼" name="btnKURACD" runat="server" />
                        <input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server" />
                        <input id="hdnKENCD" type="hidden" name="hdnKENCD" runat="server" />
						<input id="hdnKURACD_MOTO" type="hidden" name="hdnKURACD_MOTO" runat="server" />
					</td>
                    <td style="width:330px;"></td>
                    <td>
                    <span id="spS1"><a href="MSRUIJAG00.pdf" target="_blank" tabIndex="5"><img src="../../../Script/icon_pdf.gif" border="0">マニュアル&nbsp;&nbsp;</a></span>
                    </td>

				</tr>
				<tr>
                    <%-- 2014/03/10 T.Ono mod 監視改善2013 絞込み条件として、JA支所コードを追加
                    <td  colspan="4" style="width:690px;"></td> --%>
                    <td width="10">&nbsp;</td>
					<td align="right" style="width:120px;font-size:15px;">JA支所コード</td>
                    <td width="350">
                        <asp:textbox id="txtACBCD_F" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnACBCD_F" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('101');"
							tabIndex="2" type="button" value="▼" name="btnACBCD_F" runat="server" />&nbsp;～
                        <input id="hdnACBCD_F" type="hidden" name="hdnACBCD_F" runat="server" />
						<input id="hdnACBCD_F_MOTO" type="hidden" name="hdnACBCD_F_MOTO" runat="server" />
                    </td>
                    <td style="width:330px;">
                        <asp:textbox id="txtACBCD_T" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnACBCD_T" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('102');"
							tabIndex="3" type="button" value="▼" name="btnACBCD_T" runat="server" />
                        <input id="hdnACBCD_T" type="hidden" name="hdnACBCD_T" runat="server" />
						<input id="hdnACBCD_T_MOTO" type="hidden" name="hdnACBCD_T_MOTO" runat="server" />
                    </td>
                    <td>
                        <input id="btnCSVout" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnCsv_onclick();" tabIndex="4" type="button" value="データ出力" name="btnCSVout" runat="server" />
					</td>
				</tr>
			</table>
			<input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server" /> 
			<hr/>
			<div id="page1">
				<table cellSpacing="0" cellPadding="0" style="margin-left:20px;width:2800px;">
                    <tr>
                        <td colspan="4" style="height:25px;">
                            <input id="checkbtn" type="button" value="全て選択" onclick="btnCheckBtn('1');" tabIndex="6"/>
                            <input id="nocheckbtn" type="button" value="全て解除" onclick="btnCheckBtn('2');" tabIndex="7"/>
                        </td>
                        <td colspan="6" style="width:350px;"></td>
                        <td><font style="color:Red;">表示件数：最大30件</font></td>
                    </tr>
					<tr id="koumoku">
						<td id="DispNo_0" style="text-align:center;height:25px;font-size:15px;">№</td>
						<td id="DispDel_0" style="text-align:center;height:25px;font-size:15px;">削</td>
						<td id="DispSend_0" style="text-align:center;height:25px;font-size:15px;">送信順</td>
						<td id="DispKyokyu_0" style="text-align:center;height:25px;font-size:15px;">供給センター</td>
						<td id="DispAcbcdFr_0" style="text-align:left;height:25px;font-size:15px;">JA支所From</td>
						<td id="DispAcbcdTo_0" style="text-align:left;height:25px;font-size:15px;">JA支所To</td>
					    <td id="DispHassei_0" style="text-align:center;height:25px;font-size:15px;">発生区分</td>
						<td id="DispKaipage_0" style="text-align:center;height:25px;font-size:15px;">改ページ条件</td>
						<td id="DispKikan_0" style="text-align:center;height:25px;font-size:15px;">期間条件</td>
						<td id="DispFax1_0" style="text-align:center;height:25px;font-size:15px;">FAX番号1</td>
						<td id="DispFax2_0" style="text-align:center;height:25px;font-size:15px;">FAX番号2</td>
						<td id="DispMail1_0" style="text-align:center;height:25px;font-size:15px;">メールアドレス1</td>
						<td id="DispMail2_0" style="text-align:center;height:25px;font-size:15px;">メールアドレス2</td>
						<td id="DispZero_0" style="text-align:center;height:25px;font-size:15px;">0件送信</td>
						<td id="DispSD_PRT_0" style="text-align:center;height:25px;font-size:13px;">出動依頼内容・備考</td>    <!-- 2020/11/01 T.Ono add 2020監視改善 -->
						<td id="DispNxSnd_0" style="text-align:center;height:25px;font-size:15px;">次回送信日</td>
						<td id="DispLsSnd_0" style="text-align:center;height:25px;font-size:15px;">最終正常送信日</td>
						<td id="DispSndKbn_0" style="text-align:center;height:25px;font-size:15px;">送信停止区分</td>
						<td id="DispSndStr_0" style="text-align:center;height:25px;font-size:15px;">送信開始日</td>
						<td id="DispSndEnd_0" style="text-align:center;height:25px;font-size:15px;">送信終了日</td>
						<td id="DispMailPs_0" style="text-align:center;height:25px;font-size:15px;">メールパスワード</td>
						<td id="DispZip_0" style="text-align:center;height:25px;font-size:15px;">ZIPファイル名</td>
						<td id="DispBikou_0" style="text-align:center;height:25px;font-size:15px;">備考</td>
					</tr>
					<tr id="list_1">
                        <td id="DispNo_1">
                        	<input id="hdnID_1" type="hidden" name="hdnID_1" runat="server" />
                        	<input id="hdnDISP_NO_1" type="hidden" name="hdnDISP_NO_1" runat="server" />
							<asp:textbox id="txtNO_1" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="01"/>
						</td>
						<td id="DispDel_1" style="text-align:center;">
							<asp:checkbox id="chkDEL_1" tabIndex="7" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_1">
                            <%-- 2014/03/10 T.Ono mod 監視改善2013　送信順は必須としない
							<asp:textbox id="txtSEND_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-h" Width="60px" MaxLength="8" /> --%>
                            <asp:textbox id="txtSEND_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_1" style="width:105px;">
							<asp:textbox id="txtKYOKYU_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');" tabIndex="7" type="button" value="▼" name="btnKYOKYU_1" runat="server" />
						</td>
						<td id="DispAcbcdFr_1" style="width:145px;">
							<asp:textbox id="txtACBCDFR_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('31');" tabIndex="7" type="button" value="▼" name="btnACBCDFR_1" runat="server" />
						</td>
						<td id="DispAcbcdTo_1" style="width:145px;">
							<asp:textbox id="txtACBCDTO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('61');" tabIndex="7" type="button" value="▼" name="btnACBCDTO_1" runat="server" />
						</td>
						<td id="DispHassei_1">
							<asp:DropDownList  id="listHASSEI_1" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="7">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_1">
							<asp:DropDownList  id="listKAIPAGE_1" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="7">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_1">
							<asp:DropDownList  id="listKIKAN_1" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="7">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_1">
							<asp:textbox id="txtFAX1_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_1">
							<asp:textbox id="txtFAX2_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_1">
							<asp:textbox id="txtMail1_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_1">
							<asp:textbox id="txtMail2_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_1">
							<asp:DropDownList  id="listZEROSND_1" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="7"/>
						</td>
						<!-- 2020/11/01 T.Ono add 2020監視改善 出動依頼内容・備考印字フラグ追加 -->
						<td id="DispSD_PRT_1">
							<asp:DropDownList  id="listSD_PRT_1" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="7"/>
						</td>
						<td id="DispNxSnd_1">
							<asp:textbox id="txtNXSEND_1" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_1">
							<asp:textbox id="txtLSSEND_1" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_1">
							<asp:DropDownList  id="listSNDSTOP_1" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="7"/>
						</td>
						<td id="DispSndStr_1">
							<asp:textbox id="txtSENDSTR_1" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_1">
							<asp:textbox id="txtSENDEND_1" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_1">
							<asp:textbox id="txtMAILPASS_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_1">
							<asp:textbox id="txtZIP_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_1">
							<asp:textbox id="txtBIKOU_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="7" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_2">
                        <td id="DispNo_2">
                        	<input id="hdnID_2" type="hidden" name="hdnID_2" runat="server" />
                        	<input id="hdnDISP_NO_2" type="hidden" name="hdnDISP_NO_2" runat="server" />
							<asp:textbox id="txtNO_2" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="02"/>
						</td>
						<td id="DispDel_2" style="text-align:center;">
							<asp:checkbox id="chkDEL_2" tabIndex="8" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_2">
							<asp:textbox id="txtSEND_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_2" style="width:105px;">
							<asp:textbox id="txtKYOKYU_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');" tabIndex="8" type="button" value="▼" name="btnKYOKYU_2" runat="server" />
						</td>
						<td id="DispAcbcdFr_2" style="width:145px;">
							<asp:textbox id="txtACBCDFR_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('32');" tabIndex="8" type="button" value="▼" name="btnACBCDFR_2" runat="server" />
						</td>
						<td id="DispAcbcdTo_2" style="width:145px;">
							<asp:textbox id="txtACBCDTO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('62');" tabIndex="8" type="button" value="▼" name="btnACBCDTO_2" runat="server" />
						</td>
						<td id="DispHassei_2">
							<asp:DropDownList  id="listHASSEI_2" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="8">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_2">
							<asp:DropDownList  id="listKAIPAGE_2" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="8">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_2">
							<asp:DropDownList  id="listKIKAN_2" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="8">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_2">
							<asp:textbox id="txtFAX1_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_2">
							<asp:textbox id="txtFAX2_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_2">
							<asp:textbox id="txtMail1_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_2">
							<asp:textbox id="txtMail2_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_2">
							<asp:DropDownList  id="listZEROSND_2" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="8"/>
						</td>
						<td id="DispSD_PRT_2">
							<asp:DropDownList  id="listSD_PRT_2" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="8"/>
						</td>
						<td id="DispNxSnd_2">
							<asp:textbox id="txtNXSEND_2" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_2">
							<asp:textbox id="txtLSSEND_2" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_2">
							<asp:DropDownList  id="listSNDSTOP_2" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="8"/>
						</td>
						<td id="DispSndStr_2">
							<asp:textbox id="txtSENDSTR_2" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_2">
							<asp:textbox id="txtSENDEND_2" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_2">
							<asp:textbox id="txtMAILPASS_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_2">
							<asp:textbox id="txtZIP_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_2">
							<asp:textbox id="txtBIKOU_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="8" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_3">
                        <td id="DispNo_3">
                        	<input id="hdnID_3" type="hidden" name="hdnID_3" runat="server" />
                        	<input id="hdnDISP_NO_3" type="hidden" name="hdnDISP_NO_3" runat="server" />
							<asp:textbox id="txtNO_3" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="03"/>
						</td>
						<td id="DispDel_3" style="text-align:center;">
							<asp:checkbox id="chkDEL_3" tabIndex="9" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_3">
							<asp:textbox id="txtSEND_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_3" style="width:105px;">
							<asp:textbox id="txtKYOKYU_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_3" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');" tabIndex="9" type="button" value="▼" name="btnKYOKYU_3" runat="server" />
						</td>
						<td id="DispAcbcdFr_3" style="width:145px;">
							<asp:textbox id="txtACBCDFR_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_3" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('33');" tabIndex="9" type="button" value="▼" name="btnACBCDFR_3" runat="server" />
						</td>
						<td id="DispAcbcdTo_3" style="width:145px;">
							<asp:textbox id="txtACBCDTO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_3" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('63');" tabIndex="9" type="button" value="▼" name="btnACBCDTO_3" runat="server" />
						</td>
						<td id="DispHassei_3">
							<asp:DropDownList  id="listHASSEI_3" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="9">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_3">
							<asp:DropDownList  id="listKAIPAGE_3" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="9">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_3">
							<asp:DropDownList  id="listKIKAN_3" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="9">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_3">
							<asp:textbox id="txtFAX1_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_3">
							<asp:textbox id="txtFAX2_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_3">
							<asp:textbox id="txtMail1_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_3">
							<asp:textbox id="txtMail2_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_3">
							<asp:DropDownList  id="listZEROSND_3" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="9"/>
						</td>
						<td id="DispSD_PRT_3">
							<asp:DropDownList  id="listSD_PRT_3" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="9"/>
						</td>
						<td id="DispNxSnd_3">
							<asp:textbox id="txtNXSEND_3" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_3">
							<asp:textbox id="txtLSSEND_3" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_3">
							<asp:DropDownList  id="listSNDSTOP_3" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="9"/>
						</td>
						<td id="DispSndStr_3">
							<asp:textbox id="txtSENDSTR_3" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_3">
							<asp:textbox id="txtSENDEND_3" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_3">
							<asp:textbox id="txtMAILPASS_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_3">
							<asp:textbox id="txtZIP_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_3">
							<asp:textbox id="txtBIKOU_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="9" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_4">
                        <td id="DispNo_4">
                        	<input id="hdnID_4" type="hidden" name="hdnID_4" runat="server" />
                        	<input id="hdnDISP_NO_4" type="hidden" name="hdnDISP_NO_4" runat="server" />
							<asp:textbox id="txtNO_4" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="04"/>
						</td>
						<td id="DispDel_4" style="text-align:center;">
							<asp:checkbox id="chkDEL_4" tabIndex="10" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_4">
							<asp:textbox id="txtSEND_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_4" style="width:105px;">
							<asp:textbox id="txtKYOKYU_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_4" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('4');" tabIndex="10" type="button" value="▼" name="btnKYOKYU_4" runat="server" />
						</td>
						<td id="DispAcbcdFr_4" style="width:145px;">
							<asp:textbox id="txtACBCDFR_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_4" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('34');" tabIndex="10" type="button" value="▼" name="btnACBCDFR_4" runat="server" />
						</td>
						<td id="DispAcbcdTo_4" style="width:145px;">
							<asp:textbox id="txtACBCDTO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_4" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('64');" tabIndex="10" type="button" value="▼" name="btnACBCDTO_4" runat="server" />
						</td>
						<td id="DispHassei_4">
							<asp:DropDownList  id="listHASSEI_4" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="10">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_4">
							<asp:DropDownList  id="listKAIPAGE_4" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="10">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_4">
							<asp:DropDownList  id="listKIKAN_4" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="10">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_4">
							<asp:textbox id="txtFAX1_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_4">
							<asp:textbox id="txtFAX2_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_4">
							<asp:textbox id="txtMail1_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_4">
							<asp:textbox id="txtMail2_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_4">
							<asp:DropDownList  id="listZEROSND_4" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="10"/>
						</td>
						<td id="DispSD_PRT_4">
							<asp:DropDownList  id="listSD_PRT_4" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="10"/>
						</td>
						<td id="DispNxSnd_4">
							<asp:textbox id="txtNXSEND_4" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_4">
							<asp:textbox id="txtLSSEND_4" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_4">
							<asp:DropDownList  id="listSNDSTOP_4" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="10"/>
						</td>
						<td id="DispSndStr_4">
							<asp:textbox id="txtSENDSTR_4" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_4">
							<asp:textbox id="txtSENDEND_4" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_4">
							<asp:textbox id="txtMAILPASS_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_4">
							<asp:textbox id="txtZIP_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_4">
							<asp:textbox id="txtBIKOU_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="10" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_5">
                        <td id="DispNo_5">
                        	<input id="hdnID_5" type="hidden" name="hdnID_5" runat="server" />
                        	<input id="hdnDISP_NO_5" type="hidden" name="hdnDISP_NO_5" runat="server" />
							<asp:textbox id="txtNO_5" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="05"/>
						</td>
						<td id="DispDel_5" style="text-align:center;">
							<asp:checkbox id="chkDEL_5" tabIndex="11" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_5">
							<asp:textbox id="txtSEND_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_5" style="width:105px;">
							<asp:textbox id="txtKYOKYU_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_5" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('5');" tabIndex="11" type="button" value="▼" name="btnKYOKYU_5" runat="server" />
						</td>
						<td id="DispAcbcdFr_5" style="width:145px;">
							<asp:textbox id="txtACBCDFR_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_5" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('35');" tabIndex="11" type="button" value="▼" name="btnACBCDFR_5" runat="server" />
						</td>
						<td id="DispAcbcdTo_5" style="width:145px;">
							<asp:textbox id="txtACBCDTO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_5" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('65');" tabIndex="11" type="button" value="▼" name="btnACBCDTO_5" runat="server" />
						</td>
						<td id="DispHassei_5">
							<asp:DropDownList  id="listHASSEI_5" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="11">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_5">
							<asp:DropDownList  id="listKAIPAGE_5" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="11">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_5">
							<asp:DropDownList  id="listKIKAN_5" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="11">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_5">
							<asp:textbox id="txtFAX1_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_5">
							<asp:textbox id="txtFAX2_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_5">
							<asp:textbox id="txtMail1_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_5">
							<asp:textbox id="txtMail2_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_5">
							<asp:DropDownList  id="listZEROSND_5" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="11"/>
						</td>
						<td id="DispSD_PRT_5">
							<asp:DropDownList  id="listSD_PRT_5" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="11"/>
						</td>
						<td id="DispNxSnd_5">
							<asp:textbox id="txtNXSEND_5" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_5">
							<asp:textbox id="txtLSSEND_5" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_5">
							<asp:DropDownList  id="listSNDSTOP_5" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="11"/>
						</td>
						<td id="DispSndStr_5">
							<asp:textbox id="txtSENDSTR_5" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_5">
							<asp:textbox id="txtSENDEND_5" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_5">
							<asp:textbox id="txtMAILPASS_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_5">
							<asp:textbox id="txtZIP_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_5">
							<asp:textbox id="txtBIKOU_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="11" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_6">
                        <td id="DispNo_6">
                        	<input id="hdnID_6" type="hidden" name="hdnID_6" runat="server" />
                        	<input id="hdnDISP_NO_6" type="hidden" name="hdnDISP_NO_6" runat="server" />
							<asp:textbox id="txtNO_6" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="06"/>
						</td>
						<td id="DispDel_6" style="text-align:center;">
							<asp:checkbox id="chkDEL_6" tabIndex="12" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_6">
							<asp:textbox id="txtSEND_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_6" style="width:105px;">
							<asp:textbox id="txtKYOKYU_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_6" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('6');" tabIndex="12" type="button" value="▼" name="btnKYOKYU_6" runat="server" />
						</td>
						<td id="DispAcbcdFr_6" style="width:145px;">
							<asp:textbox id="txtACBCDFR_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_6" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('36');" tabIndex="12" type="button" value="▼" name="btnACBCDFR_6" runat="server" />
						</td>
						<td id="DispAcbcdTo_6" style="width:145px;">
							<asp:textbox id="txtACBCDTO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_6" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('66');" tabIndex="12" type="button" value="▼" name="btnACBCDTO_6" runat="server" />
						</td>
						<td id="DispHassei_6">
							<asp:DropDownList  id="listHASSEI_6" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="12">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_6">
							<asp:DropDownList  id="listKAIPAGE_6" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="12">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_6">
							<asp:DropDownList  id="listKIKAN_6" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="12">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_6">
							<asp:textbox id="txtFAX1_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_6">
							<asp:textbox id="txtFAX2_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_6">
							<asp:textbox id="txtMail1_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_6">
							<asp:textbox id="txtMail2_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_6">
							<asp:DropDownList  id="listZEROSND_6" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="12"/>
						</td>
						<td id="DispSD_PRT_6">
							<asp:DropDownList  id="listSD_PRT_6" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="12"/>
						</td>
						<td id="DispNxSnd_6">
							<asp:textbox id="txtNXSEND_6" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_6">
							<asp:textbox id="txtLSSEND_6" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_6">
							<asp:DropDownList  id="listSNDSTOP_6" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="12"/>
						</td>
						<td id="DispSndStr_6">
							<asp:textbox id="txtSENDSTR_6" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_6">
							<asp:textbox id="txtSENDEND_6" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_6">
							<asp:textbox id="txtMAILPASS_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_6">
							<asp:textbox id="txtZIP_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_6">
							<asp:textbox id="txtBIKOU_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="12" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_7">
                        <td id="DispNo_7">
                        	<input id="hdnID_7" type="hidden" name="hdnID_7" runat="server" />
                        	<input id="hdnDISP_NO_7" type="hidden" name="hdnDISP_NO_7" runat="server" />
							<asp:textbox id="txtNO_7" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="07"/>
						</td>
						<td id="DispDel_7" style="text-align:center;">
							<asp:checkbox id="chkDEL_7" tabIndex="13" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_7">
							<asp:textbox id="txtSEND_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_7" style="width:105px;">
							<asp:textbox id="txtKYOKYU_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_7" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('7');" tabIndex="13" type="button" value="▼" name="btnKYOKYU_7" runat="server" />
						</td>
						<td id="DispAcbcdFr_7" style="width:145px;">
							<asp:textbox id="txtACBCDFR_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_7" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('37');" tabIndex="13" type="button" value="▼" name="btnACBCDFR_7" runat="server" />
						</td>
						<td id="DispAcbcdTo_7" style="width:145px;">
							<asp:textbox id="txtACBCDTO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_7" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('67');" tabIndex="13" type="button" value="▼" name="btnACBCDTO_7" runat="server" />
						</td>
						<td id="DispHassei_7">
							<asp:DropDownList  id="listHASSEI_7" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="13">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_7">
							<asp:DropDownList  id="listKAIPAGE_7" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="13">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_7">
							<asp:DropDownList  id="listKIKAN_7" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="13">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_7">
							<asp:textbox id="txtFAX1_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_7">
							<asp:textbox id="txtFAX2_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_7">
							<asp:textbox id="txtMail1_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_7">
							<asp:textbox id="txtMail2_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_7">
							<asp:DropDownList  id="listZEROSND_7" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="13"/>
						</td>
						<td id="DispSD_PRT_7">
							<asp:DropDownList  id="listSD_PRT_7" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="13"/>
						</td>
						<td id="DispNxSnd_7">
							<asp:textbox id="txtNXSEND_7" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_7">
							<asp:textbox id="txtLSSEND_7" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_7">
							<asp:DropDownList  id="listSNDSTOP_7" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="13"/>
						</td>
						<td id="DispSndStr_7">
							<asp:textbox id="txtSENDSTR_7" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_7">
							<asp:textbox id="txtSENDEND_7" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_7">
							<asp:textbox id="txtMAILPASS_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_7">
							<asp:textbox id="txtZIP_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_7">
							<asp:textbox id="txtBIKOU_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="13" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_8">
                        <td id="DispNo_8">
                        	<input id="hdnID_8" type="hidden" name="hdnID_8" runat="server" />
                        	<input id="hdnDISP_NO_8" type="hidden" name="hdnDISP_NO_8" runat="server" />
							<asp:textbox id="txtNO_8" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="08"/>
						</td>
						<td id="DispDel_8" style="text-align:center;">
							<asp:checkbox id="chkDEL_8" tabIndex="14" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_8">
							<asp:textbox id="txtSEND_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_8" style="width:105px;">
							<asp:textbox id="txtKYOKYU_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_8" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('8');" tabIndex="14" type="button" value="▼" name="btnKYOKYU_8" runat="server" />
						</td>
						<td id="DispAcbcdFr_8" style="width:145px;">
							<asp:textbox id="txtACBCDFR_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_8" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('38');" tabIndex="14" type="button" value="▼" name="btnACBCDFR_8" runat="server" />
						</td>
						<td id="DispAcbcdTo_8" style="width:145px;">
							<asp:textbox id="txtACBCDTO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_8" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('68');" tabIndex="14" type="button" value="▼" name="btnACBCDTO_8" runat="server" />
						</td>
						<td id="DispHassei_8">
							<asp:DropDownList  id="listHASSEI_8" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="14">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_8">
							<asp:DropDownList  id="listKAIPAGE_8" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="14">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_8">
							<asp:DropDownList  id="listKIKAN_8" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="14">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_8">
							<asp:textbox id="txtFAX1_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_8">
							<asp:textbox id="txtFAX2_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_8">
							<asp:textbox id="txtMail1_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_8">
							<asp:textbox id="txtMail2_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_8">
							<asp:DropDownList  id="listZEROSND_8" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="14"/>
						</td>
						<td id="DispSD_PRT_8">
							<asp:DropDownList  id="listSD_PRT_8" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="14"/>
						</td>
						<td id="DispNxSnd_8">
							<asp:textbox id="txtNXSEND_8" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_8">
							<asp:textbox id="txtLSSEND_8" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_8">
							<asp:DropDownList  id="listSNDSTOP_8" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="14"/>
						</td>
						<td id="DispSndStr_8">
							<asp:textbox id="txtSENDSTR_8" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_8">
							<asp:textbox id="txtSENDEND_8" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_8">
							<asp:textbox id="txtMAILPASS_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_8">
							<asp:textbox id="txtZIP_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_8">
							<asp:textbox id="txtBIKOU_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="14" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_9">
                        <td id="DispNo_9">
                        	<input id="hdnID_9" type="hidden" name="hdnID_9" runat="server" />
                        	<input id="hdnDISP_NO_9" type="hidden" name="hdnDISP_NO_9" runat="server" />
							<asp:textbox id="txtNO_9" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="09"/>
						</td>
						<td id="DispDel_9" style="text-align:center;">
							<asp:checkbox id="chkDEL_9" tabIndex="15" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_9">
							<asp:textbox id="txtSEND_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_9" style="width:105px;">
							<asp:textbox id="txtKYOKYU_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_9" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('9');" tabIndex="15" type="button" value="▼" name="btnKYOKYU_9" runat="server" />
						</td>
						<td id="DispAcbcdFr_9" style="width:145px;">
							<asp:textbox id="txtACBCDFR_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_9" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('39');" tabIndex="15" type="button" value="▼" name="btnACBCDFR_9" runat="server" />
						</td>
						<td id="DispAcbcdTo_9" style="width:145px;">
							<asp:textbox id="txtACBCDTO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_9" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('69');" tabIndex="15" type="button" value="▼" name="btnACBCDTO_9" runat="server" />
						</td>
						<td id="DispHassei_9">
							<asp:DropDownList  id="listHASSEI_9" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="15">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_9">
							<asp:DropDownList  id="listKAIPAGE_9" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="15">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_9">
							<asp:DropDownList  id="listKIKAN_9" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="15">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_9">
							<asp:textbox id="txtFAX1_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_9">
							<asp:textbox id="txtFAX2_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_9">
							<asp:textbox id="txtMail1_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_9">
							<asp:textbox id="txtMail2_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_9">
							<asp:DropDownList  id="listZEROSND_9" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="15"/>
						</td>
						<td id="DispSD_PRT_9">
							<asp:DropDownList  id="listSD_PRT_9" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="15"/>
						</td>
						<td id="DispNxSnd_9">
							<asp:textbox id="txtNXSEND_9" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_9">
							<asp:textbox id="txtLSSEND_9" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_9">
							<asp:DropDownList  id="listSNDSTOP_9" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="15"/>
						</td>
						<td id="DispSndStr_9">
							<asp:textbox id="txtSENDSTR_9" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_9">
							<asp:textbox id="txtSENDEND_9" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_9">
							<asp:textbox id="txtMAILPASS_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_9">
							<asp:textbox id="txtZIP_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_9">
							<asp:textbox id="txtBIKOU_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="15" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_10">
                        <td id="DispNo_10">
                        	<input id="hdnID_10" type="hidden" name="hdnID_10" runat="server" />
                        	<input id="hdnDISP_NO_10" type="hidden" name="hdnDISP_NO_10" runat="server" />
							<asp:textbox id="txtNO_10" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="10"/>
						</td>
						<td id="DispDel_10" style="text-align:center;">
							<asp:checkbox id="chkDEL_10" tabIndex="16" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_10">
							<asp:textbox id="txtSEND_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_10" style="width:105px;">
							<asp:textbox id="txtKYOKYU_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_10" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('10');" tabIndex="16" type="button" value="▼" name="btnKYOKYU_10" runat="server" />
						</td>
						<td id="DispAcbcdFr_10" style="width:145px;">
							<asp:textbox id="txtACBCDFR_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_10" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('40');" tabIndex="16" type="button" value="▼" name="btnACBCDFR_10" runat="server" />
						</td>
						<td id="DispAcbcdTo_10" style="width:145px;">
							<asp:textbox id="txtACBCDTO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_10" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('70');" tabIndex="16" type="button" value="▼" name="btnACBCDTO_10" runat="server" />
						</td>
						<td id="DispHassei_10">
							<asp:DropDownList  id="listHASSEI_10" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="16">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_10">
							<asp:DropDownList  id="listKAIPAGE_10" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="16">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_10">
							<asp:DropDownList  id="listKIKAN_10" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="16">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_10">
							<asp:textbox id="txtFAX1_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_10">
							<asp:textbox id="txtFAX2_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_10">
							<asp:textbox id="txtMail1_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_10">
							<asp:textbox id="txtMail2_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_10">
							<asp:DropDownList  id="listZEROSND_10" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="16"/>
						</td>
						<td id="DispSD_PRT_10">
							<asp:DropDownList  id="listSD_PRT_10" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="16"/>
						</td>
						<td id="DispNxSnd_10">
							<asp:textbox id="txtNXSEND_10" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_10">
							<asp:textbox id="txtLSSEND_10" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_10">
							<asp:DropDownList  id="listSNDSTOP_10" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="16"/>
						</td>
						<td id="DispSndStr_10">
							<asp:textbox id="txtSENDSTR_10" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_10">
							<asp:textbox id="txtSENDEND_10" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_10">
							<asp:textbox id="txtMAILPASS_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_10">
							<asp:textbox id="txtZIP_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_10">
							<asp:textbox id="txtBIKOU_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="16" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_11">
                        <td id="DispNo_11">
                        	<input id="hdnID_11" type="hidden" name="hdnID_11" runat="server" />
                        	<input id="hdnDISP_NO_11" type="hidden" name="hdnDISP_NO_11" runat="server" />
							<asp:textbox id="txtNO_11" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="11"/>
						</td>
						<td id="DispDel_11" style="text-align:center;">
							<asp:checkbox id="chkDEL_11" tabIndex="17" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_11">
							<asp:textbox id="txtSEND_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_11" style="width:105px;">
							<asp:textbox id="txtKYOKYU_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_11" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('11');" tabIndex="17" type="button" value="▼" name="btnKYOKYU_11" runat="server" />
						</td>
						<td id="DispAcbcdFr_11" style="width:145px;">
							<asp:textbox id="txtACBCDFR_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_11" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('41');" tabIndex="17" type="button" value="▼" name="btnACBCDFR_11" runat="server" />
						</td>
						<td id="DispAcbcdTo_11" style="width:145px;">
							<asp:textbox id="txtACBCDTO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_11" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('71');" tabIndex="17" type="button" value="▼" name="btnACBCDTO_11" runat="server" />
						</td>
						<td id="DispHassei_11">
							<asp:DropDownList  id="listHASSEI_11" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="17">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_11">
							<asp:DropDownList  id="listKAIPAGE_11" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="17">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_11">
							<asp:DropDownList  id="listKIKAN_11" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="17">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_11">
							<asp:textbox id="txtFAX1_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_11">
							<asp:textbox id="txtFAX2_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_11">
							<asp:textbox id="txtMail1_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_11">
							<asp:textbox id="txtMail2_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_11">
							<asp:DropDownList  id="listZEROSND_11" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="17"/>
						</td>
						<td id="DispSD_PRT_11">
							<asp:DropDownList  id="listSD_PRT_11" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="17"/>
						</td>
						<td id="DispNxSnd_11">
							<asp:textbox id="txtNXSEND_11" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_11">
							<asp:textbox id="txtLSSEND_11" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_11">
							<asp:DropDownList  id="listSNDSTOP_11" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="17"/>
						</td>
						<td id="DispSndStr_11">
							<asp:textbox id="txtSENDSTR_11" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_11">
							<asp:textbox id="txtSENDEND_11" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_11">
							<asp:textbox id="txtMAILPASS_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_11">
							<asp:textbox id="txtZIP_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_11">
							<asp:textbox id="txtBIKOU_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="17" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_12">
                        <td id="DispNo_12">
                        	<input id="hdnID_12" type="hidden" name="hdnID_12" runat="server" />
                        	<input id="hdnDISP_NO_12" type="hidden" name="hdnDISP_NO_12" runat="server" />
							<asp:textbox id="txtNO_12" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="12"/>
						</td>
						<td id="DispDel_12" style="text-align:center;">
							<asp:checkbox id="chkDEL_12" tabIndex="18" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_12">
							<asp:textbox id="txtSEND_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_12" style="width:105px;">
							<asp:textbox id="txtKYOKYU_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_12" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('12');" tabIndex="18" type="button" value="▼" name="btnKYOKYU_12" runat="server" />
						</td>
						<td id="DispAcbcdFr_12" style="width:145px;">
							<asp:textbox id="txtACBCDFR_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_12" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('42');" tabIndex="18" type="button" value="▼" name="btnACBCDFR_12" runat="server" />
						</td>
						<td id="DispAcbcdTo_12" style="width:145px;">
							<asp:textbox id="txtACBCDTO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_12" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('72');" tabIndex="18" type="button" value="▼" name="btnACBCDTO_12" runat="server" />
						</td>
						<td id="DispHassei_12">
							<asp:DropDownList  id="listHASSEI_12" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="18">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_12">
							<asp:DropDownList  id="listKAIPAGE_12" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="18">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_12">
							<asp:DropDownList  id="listKIKAN_12" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="18">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_12">
							<asp:textbox id="txtFAX1_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_12">
							<asp:textbox id="txtFAX2_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_12">
							<asp:textbox id="txtMail1_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_12">
							<asp:textbox id="txtMail2_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_12">
							<asp:DropDownList  id="listZEROSND_12" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="18"/>
						</td>
						<td id="DispSD_PRT_12">
							<asp:DropDownList  id="listSD_PRT_12" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="18"/>
						</td>
						<td id="DispNxSnd_12">
							<asp:textbox id="txtNXSEND_12" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_12">
							<asp:textbox id="txtLSSEND_12" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_12">
							<asp:DropDownList  id="listSNDSTOP_12" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="18"/>
						</td>
						<td id="DispSndStr_12">
							<asp:textbox id="txtSENDSTR_12" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_12">
							<asp:textbox id="txtSENDEND_12" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_12">
							<asp:textbox id="txtMAILPASS_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_12">
							<asp:textbox id="txtZIP_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_12">
							<asp:textbox id="txtBIKOU_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="18" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_13">
                        <td id="DispNo_13">
                        	<input id="hdnID_13" type="hidden" name="hdnID_13" runat="server" />
                        	<input id="hdnDISP_NO_13" type="hidden" name="hdnDISP_NO_13" runat="server" />
							<asp:textbox id="txtNO_13" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="13"/>
						</td>
						<td id="DispDel_13" style="text-align:center;">
							<asp:checkbox id="chkDEL_13" tabIndex="19" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_13">
							<asp:textbox id="txtSEND_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_13" style="width:105px;">
							<asp:textbox id="txtKYOKYU_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_13" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('13');" tabIndex="19" type="button" value="▼" name="btnKYOKYU_13" runat="server" />
						</td>
						<td id="DispAcbcdFr_13" style="width:145px;">
							<asp:textbox id="txtACBCDFR_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_13" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('43');" tabIndex="19" type="button" value="▼" name="btnACBCDFR_13" runat="server" />
						</td>
						<td id="DispAcbcdTo_13" style="width:145px;">
							<asp:textbox id="txtACBCDTO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_13" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('73');" tabIndex="19" type="button" value="▼" name="btnACBCDTO_13" runat="server" />
						</td>
						<td id="DispHassei_13">
							<asp:DropDownList  id="listHASSEI_13" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="19">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_13">
							<asp:DropDownList  id="listKAIPAGE_13" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="19">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_13">
							<asp:DropDownList  id="listKIKAN_13" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="19">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_13">
							<asp:textbox id="txtFAX1_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_13">
							<asp:textbox id="txtFAX2_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_13">
							<asp:textbox id="txtMail1_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_13">
							<asp:textbox id="txtMail2_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_13">
							<asp:DropDownList  id="listZEROSND_13" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="19"/>
						</td>
						<td id="DispSD_PRT_13">
							<asp:DropDownList  id="listSD_PRT_13" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="19"/>
						</td>
						<td id="DispNxSnd_13">
							<asp:textbox id="txtNXSEND_13" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_13">
							<asp:textbox id="txtLSSEND_13" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_13">
							<asp:DropDownList  id="listSNDSTOP_13" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="19"/>
						</td>
						<td id="DispSndStr_13">
							<asp:textbox id="txtSENDSTR_13" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_13">
							<asp:textbox id="txtSENDEND_13" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_13">
							<asp:textbox id="txtMAILPASS_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_13">
							<asp:textbox id="txtZIP_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_13">
							<asp:textbox id="txtBIKOU_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="19" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_14">
                        <td id="DispNo_14">
                        	<input id="hdnID_14" type="hidden" name="hdnID_14" runat="server" />
                        	<input id="hdnDISP_NO_14" type="hidden" name="hdnDISP_NO_14" runat="server" />
							<asp:textbox id="txtNO_14" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="14"/>
						</td>
						<td id="DispDel_14" style="text-align:center;">
							<asp:checkbox id="chkDEL_14" tabIndex="20" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_14">
							<asp:textbox id="txtSEND_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_14" style="width:105px;">
							<asp:textbox id="txtKYOKYU_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_14" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('14');" tabIndex="20" type="button" value="▼" name="btnKYOKYU_14" runat="server" />
						</td>
						<td id="DispAcbcdFr_14" style="width:145px;">
							<asp:textbox id="txtACBCDFR_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_14" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('44');" tabIndex="20" type="button" value="▼" name="btnACBCDFR_14" runat="server" />
						</td>
						<td id="DispAcbcdTo_14" style="width:145px;">
							<asp:textbox id="txtACBCDTO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_14" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('74');" tabIndex="20" type="button" value="▼" name="btnACBCDTO_14" runat="server" />
						</td>
						<td id="DispHassei_14">
							<asp:DropDownList  id="listHASSEI_14" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="20">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_14">
							<asp:DropDownList  id="listKAIPAGE_14" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="20">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_14">
							<asp:DropDownList  id="listKIKAN_14" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="20">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_14">
							<asp:textbox id="txtFAX1_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_14">
							<asp:textbox id="txtFAX2_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_14">
							<asp:textbox id="txtMail1_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_14">
							<asp:textbox id="txtMail2_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_14">
							<asp:DropDownList  id="listZEROSND_14" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="20"/>
						</td>
						<td id="DispSD_PRT_14">
							<asp:DropDownList  id="listSD_PRT_14" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="20"/>
						</td>
						<td id="DispNxSnd_14">
							<asp:textbox id="txtNXSEND_14" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_14">
							<asp:textbox id="txtLSSEND_14" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_14">
							<asp:DropDownList  id="listSNDSTOP_14" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="20"/>
						</td>
						<td id="DispSndStr_14">
							<asp:textbox id="txtSENDSTR_14" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_14">
							<asp:textbox id="txtSENDEND_14" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_14">
							<asp:textbox id="txtMAILPASS_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_14">
							<asp:textbox id="txtZIP_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_14">
							<asp:textbox id="txtBIKOU_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="20" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_15">
                        <td id="DispNo_15">
                        	<input id="hdnID_15" type="hidden" name="hdnID_15" runat="server" />
                        	<input id="hdnDISP_NO_15" type="hidden" name="hdnDISP_NO_15" runat="server" />
							<asp:textbox id="txtNO_15" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="15"/>
						</td>
						<td id="DispDel_15" style="text-align:center;">
							<asp:checkbox id="chkDEL_15" tabIndex="21" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_15">
							<asp:textbox id="txtSEND_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_15" style="width:105px;">
							<asp:textbox id="txtKYOKYU_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_15" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('15');" tabIndex="21" type="button" value="▼" name="btnKYOKYU_15" runat="server" />
						</td>
						<td id="DispAcbcdFr_15" style="width:145px;">
							<asp:textbox id="txtACBCDFR_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_15" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('45');" tabIndex="21" type="button" value="▼" name="btnACBCDFR_15" runat="server" />
						</td>
						<td id="DispAcbcdTo_15" style="width:145px;">
							<asp:textbox id="txtACBCDTO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_15" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('75');" tabIndex="21" type="button" value="▼" name="btnACBCDTO_15" runat="server" />
						</td>
						<td id="DispHassei_15">
							<asp:DropDownList  id="listHASSEI_15" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="21">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_15">
							<asp:DropDownList  id="listKAIPAGE_15" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="21">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_15">
							<asp:DropDownList  id="listKIKAN_15" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="21">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_15">
							<asp:textbox id="txtFAX1_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_15">
							<asp:textbox id="txtFAX2_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_15">
							<asp:textbox id="txtMail1_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_15">
							<asp:textbox id="txtMail2_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_15">
							<asp:DropDownList  id="listZEROSND_15" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="21"/>
						</td>
						<td id="DispSD_PRT_15">
							<asp:DropDownList  id="listSD_PRT_15" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="21"/>
						</td>
						<td id="DispNxSnd_15">
							<asp:textbox id="txtNXSEND_15" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_15">
							<asp:textbox id="txtLSSEND_15" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_15">
							<asp:DropDownList  id="listSNDSTOP_15" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="21"/>
						</td>
						<td id="DispSndStr_15">
							<asp:textbox id="txtSENDSTR_15" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_15">
							<asp:textbox id="txtSENDEND_15" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_15">
							<asp:textbox id="txtMAILPASS_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_15">
							<asp:textbox id="txtZIP_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_15">
							<asp:textbox id="txtBIKOU_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="21" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_16">
                        <td id="DispNo_16">
                        	<input id="hdnID_16" type="hidden" name="hdnID_16" runat="server" />
                        	<input id="hdnDISP_NO_16" type="hidden" name="hdnDISP_NO_16" runat="server" />
							<asp:textbox id="txtNO_16" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="16"/>
						</td>
						<td id="DispDel_16" style="text-align:center;">
							<asp:checkbox id="chkDEL_16" tabIndex="22" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_16">
							<asp:textbox id="txtSEND_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_16" style="width:105px;">
							<asp:textbox id="txtKYOKYU_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_16" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('16');" tabIndex="22" type="button" value="▼" name="btnKYOKYU_16" runat="server" />
						</td>
						<td id="DispAcbcdFr_16" style="width:145px;">
							<asp:textbox id="txtACBCDFR_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_16" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('46');" tabIndex="22" type="button" value="▼" name="btnACBCDFR_16" runat="server" />
						</td>
						<td id="DispAcbcdTo_16" style="width:145px;">
							<asp:textbox id="txtACBCDTO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_16" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('76');" tabIndex="22" type="button" value="▼" name="btnACBCDTO_16" runat="server" />
						</td>
						<td id="DispHassei_16">
							<asp:DropDownList  id="listHASSEI_16" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="22">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_16">
							<asp:DropDownList  id="listKAIPAGE_16" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="22">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_16">
							<asp:DropDownList  id="listKIKAN_16" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="22">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_16">
							<asp:textbox id="txtFAX1_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_16">
							<asp:textbox id="txtFAX2_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_16">
							<asp:textbox id="txtMail1_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_16">
							<asp:textbox id="txtMail2_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_16">
							<asp:DropDownList  id="listZEROSND_16" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="22"/>
						</td>
						<td id="DispSD_PRT_16">
							<asp:DropDownList  id="listSD_PRT_16" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="22"/>
						</td>
						<td id="DispNxSnd_16">
							<asp:textbox id="txtNXSEND_16" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_16">
							<asp:textbox id="txtLSSEND_16" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_16">
							<asp:DropDownList  id="listSNDSTOP_16" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="22"/>
						</td>
						<td id="DispSndStr_16">
							<asp:textbox id="txtSENDSTR_16" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_16">
							<asp:textbox id="txtSENDEND_16" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_16">
							<asp:textbox id="txtMAILPASS_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_16">
							<asp:textbox id="txtZIP_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_16">
							<asp:textbox id="txtBIKOU_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="22" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_17">
                        <td id="DispNo_17">
                        	<input id="hdnID_17" type="hidden" name="hdnID_17" runat="server" />
                        	<input id="hdnDISP_NO_17" type="hidden" name="hdnDISP_NO_17" runat="server" />
							<asp:textbox id="txtNO_17" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="17"/>
						</td>
						<td id="DispDel_17" style="text-align:center;">
							<asp:checkbox id="chkDEL_17" tabIndex="23" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_17">
							<asp:textbox id="txtSEND_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_17" style="width:105px;">
							<asp:textbox id="txtKYOKYU_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_17" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('17');" tabIndex="23" type="button" value="▼" name="btnKYOKYU_17" runat="server" />
						</td>
						<td id="DispAcbcdFr_17" style="width:145px;">
							<asp:textbox id="txtACBCDFR_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_17" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('47');" tabIndex="23" type="button" value="▼" name="btnACBCDFR_17" runat="server" />
						</td>
						<td id="DispAcbcdTo_17" style="width:145px;">
							<asp:textbox id="txtACBCDTO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_17" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('77');" tabIndex="23" type="button" value="▼" name="btnACBCDTO_17" runat="server" />
						</td>
						<td id="DispHassei_17">
							<asp:DropDownList  id="listHASSEI_17" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="23">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_17">
							<asp:DropDownList  id="listKAIPAGE_17" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="23">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_17">
							<asp:DropDownList  id="listKIKAN_17" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="23">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_17">
							<asp:textbox id="txtFAX1_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_17">
							<asp:textbox id="txtFAX2_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_17">
							<asp:textbox id="txtMail1_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_17">
							<asp:textbox id="txtMail2_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_17">
							<asp:DropDownList  id="listZEROSND_17" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="23"/>
						</td>
						<td id="DispSD_PRT_17">
							<asp:DropDownList  id="listSD_PRT_17" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="23"/>
						</td>
						<td id="DispNxSnd_17">
							<asp:textbox id="txtNXSEND_17" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_17">
							<asp:textbox id="txtLSSEND_17" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_17">
							<asp:DropDownList  id="listSNDSTOP_17" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="23"/>
						</td>
						<td id="DispSndStr_17">
							<asp:textbox id="txtSENDSTR_17" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_17">
							<asp:textbox id="txtSENDEND_17" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_17">
							<asp:textbox id="txtMAILPASS_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_17">
							<asp:textbox id="txtZIP_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_17">
							<asp:textbox id="txtBIKOU_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="23" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_18">
                        <td id="DispNo_18">
                        	<input id="hdnID_18" type="hidden" name="hdnID_18" runat="server" />
                        	<input id="hdnDISP_NO_18" type="hidden" name="hdnDISP_NO_18" runat="server" />
							<asp:textbox id="txtNO_18" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="18"/>
						</td>
						<td id="DispDel_18" style="text-align:center;">
							<asp:checkbox id="chkDEL_18" tabIndex="24" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_18">
							<asp:textbox id="txtSEND_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_18" style="width:105px;">
							<asp:textbox id="txtKYOKYU_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_18" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('18');" tabIndex="24" type="button" value="▼" name="btnKYOKYU_18" runat="server" />
						</td>
						<td id="DispAcbcdFr_18" style="width:145px;">
							<asp:textbox id="txtACBCDFR_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_18" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('48');" tabIndex="24" type="button" value="▼" name="btnACBCDFR_18" runat="server" />
						</td>
						<td id="DispAcbcdTo_18" style="width:145px;">
							<asp:textbox id="txtACBCDTO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_18" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('78');" tabIndex="24" type="button" value="▼" name="btnACBCDTO_18" runat="server" />
						</td>
						<td id="DispHassei_18">
							<asp:DropDownList  id="listHASSEI_18" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="24">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_18">
							<asp:DropDownList  id="listKAIPAGE_18" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="24">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_18">
							<asp:DropDownList  id="listKIKAN_18" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="24">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_18">
							<asp:textbox id="txtFAX1_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_18">
							<asp:textbox id="txtFAX2_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_18">
							<asp:textbox id="txtMail1_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_18">
							<asp:textbox id="txtMail2_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_18">
							<asp:DropDownList  id="listZEROSND_18" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="24"/>
						</td>
						<td id="DispSD_PRT_18">
							<asp:DropDownList  id="listSD_PRT_18" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="24"/>
						</td>
						<td id="DispNxSnd_18">
							<asp:textbox id="txtNXSEND_18" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_18">
							<asp:textbox id="txtLSSEND_18" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_18">
							<asp:DropDownList  id="listSNDSTOP_18" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="24"/>
						</td>
						<td id="DispSndStr_18">
							<asp:textbox id="txtSENDSTR_18" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_18">
							<asp:textbox id="txtSENDEND_18" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_18">
							<asp:textbox id="txtMAILPASS_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_18">
							<asp:textbox id="txtZIP_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_18">
							<asp:textbox id="txtBIKOU_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="24" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_19">
                        <td id="DispNo_19">
                        	<input id="hdnID_19" type="hidden" name="hdnID_19" runat="server" />
                        	<input id="hdnDISP_NO_19" type="hidden" name="hdnDISP_NO_19" runat="server" />
							<asp:textbox id="txtNO_19" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="19"/>
						</td>
						<td id="DispDel_19" style="text-align:center;">
							<asp:checkbox id="chkDEL_19" tabIndex="25" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_19">
							<asp:textbox id="txtSEND_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_19" style="width:105px;">
							<asp:textbox id="txtKYOKYU_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_19" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('19');" tabIndex="25" type="button" value="▼" name="btnKYOKYU_19" runat="server" />
						</td>
						<td id="DispAcbcdFr_19" style="width:145px;">
							<asp:textbox id="txtACBCDFR_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_19" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('49');" tabIndex="25" type="button" value="▼" name="btnACBCDFR_19" runat="server" />
						</td>
						<td id="DispAcbcdTo_19" style="width:145px;">
							<asp:textbox id="txtACBCDTO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_19" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('79');" tabIndex="25" type="button" value="▼" name="btnACBCDTO_19" runat="server" />
						</td>
						<td id="DispHassei_19">
							<asp:DropDownList  id="listHASSEI_19" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="25">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_19">
							<asp:DropDownList  id="listKAIPAGE_19" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="25">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_19">
							<asp:DropDownList  id="listKIKAN_19" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="25">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_19">
							<asp:textbox id="txtFAX1_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_19">
							<asp:textbox id="txtFAX2_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_19">
							<asp:textbox id="txtMail1_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_19">
							<asp:textbox id="txtMail2_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_19">
							<asp:DropDownList  id="listZEROSND_19" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="25"/>
						</td>
						<td id="DispSD_PRT_19">
							<asp:DropDownList  id="listSD_PRT_19" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="25"/>
						</td>
						<td id="DispNxSnd_19">
							<asp:textbox id="txtNXSEND_19" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_19">
							<asp:textbox id="txtLSSEND_19" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_19">
							<asp:DropDownList  id="listSNDSTOP_19" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="25"/>
						</td>
						<td id="DispSndStr_19">
							<asp:textbox id="txtSENDSTR_19" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_19">
							<asp:textbox id="txtSENDEND_19" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_19">
							<asp:textbox id="txtMAILPASS_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_19">
							<asp:textbox id="txtZIP_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_19">
							<asp:textbox id="txtBIKOU_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="25" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_20">
                        <td id="DispNo_20">
                        	<input id="hdnID_20" type="hidden" name="hdnID_20" runat="server" />
                        	<input id="hdnDISP_NO_20" type="hidden" name="hdnDISP_NO_20" runat="server" />
							<asp:textbox id="txtNO_20" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="20"/>
						</td>
						<td id="DispDel_20" style="text-align:center;">
							<asp:checkbox id="chkDEL_20" tabIndex="26" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_20">
							<asp:textbox id="txtSEND_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_20" style="width:105px;">
							<asp:textbox id="txtKYOKYU_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_20" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('20');" tabIndex="26" type="button" value="▼" name="btnKYOKYU_20" runat="server" />
						</td>
						<td id="DispAcbcdFr_20" style="width:145px;">
							<asp:textbox id="txtACBCDFR_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_20" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('50');" tabIndex="26" type="button" value="▼" name="btnACBCDFR_20" runat="server" />
						</td>
						<td id="DispAcbcdTo_20" style="width:145px;">
							<asp:textbox id="txtACBCDTO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_20" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('80');" tabIndex="26" type="button" value="▼" name="btnACBCDTO_20" runat="server" />
						</td>
						<td id="DispHassei_20">
							<asp:DropDownList  id="listHASSEI_20" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="26">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_20">
							<asp:DropDownList  id="listKAIPAGE_20" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="26">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_20">
							<asp:DropDownList  id="listKIKAN_20" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="26">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_20">
							<asp:textbox id="txtFAX1_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_20">
							<asp:textbox id="txtFAX2_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_20">
							<asp:textbox id="txtMail1_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_20">
							<asp:textbox id="txtMail2_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_20">
							<asp:DropDownList  id="listZEROSND_20" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="26"/>
						</td>
						<td id="DispSD_PRT_20">
							<asp:DropDownList  id="listSD_PRT_20" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="26"/>
						</td>
						<td id="DispNxSnd_20">
							<asp:textbox id="txtNXSEND_20" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_20">
							<asp:textbox id="txtLSSEND_20" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_20">
							<asp:DropDownList  id="listSNDSTOP_20" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="26"/>
						</td>
						<td id="DispSndStr_20">
							<asp:textbox id="txtSENDSTR_20" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_20">
							<asp:textbox id="txtSENDEND_20" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_20">
							<asp:textbox id="txtMAILPASS_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_20">
							<asp:textbox id="txtZIP_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_20">
							<asp:textbox id="txtBIKOU_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="26" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_21">
                        <td id="DispNo_21">
                        	<input id="hdnID_21" type="hidden" name="hdnID_21" runat="server" />
                        	<input id="hdnDISP_NO_21" type="hidden" name="hdnDISP_NO_21" runat="server" />
							<asp:textbox id="txtNO_21" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="21"/>
						</td>
						<td id="DispDel_21" style="text-align:center;">
							<asp:checkbox id="chkDEL_21" tabIndex="27" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_21">
							<asp:textbox id="txtSEND_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_21" style="width:105px;">
							<asp:textbox id="txtKYOKYU_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_21" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('21');" tabIndex="27" type="button" value="▼" name="btnKYOKYU_21" runat="server" />
						</td>
						<td id="DispAcbcdFr_21" style="width:145px;">
							<asp:textbox id="txtACBCDFR_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_21" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('51');" tabIndex="27" type="button" value="▼" name="btnACBCDFR_21" runat="server" />
						</td>
						<td id="DispAcbcdTo_21" style="width:145px;">
							<asp:textbox id="txtACBCDTO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_21" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('81');" tabIndex="27" type="button" value="▼" name="btnACBCDTO_21" runat="server" />
						</td>
						<td id="DispHassei_21">
							<asp:DropDownList  id="listHASSEI_21" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="27">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_21">
							<asp:DropDownList  id="listKAIPAGE_21" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="27">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_21">
							<asp:DropDownList  id="listKIKAN_21" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="27">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_21">
							<asp:textbox id="txtFAX1_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_21">
							<asp:textbox id="txtFAX2_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_21">
							<asp:textbox id="txtMail1_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_21">
							<asp:textbox id="txtMail2_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_21">
							<asp:DropDownList  id="listZEROSND_21" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="27"/>
						</td>
						<td id="DispSD_PRT_21">
							<asp:DropDownList  id="listSD_PRT_21" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="27"/>
						</td>
						<td id="DispNxSnd_21">
							<asp:textbox id="txtNXSEND_21" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_21">
							<asp:textbox id="txtLSSEND_21" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_21">
							<asp:DropDownList  id="listSNDSTOP_21" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="27"/>
						</td>
						<td id="DispSndStr_21">
							<asp:textbox id="txtSENDSTR_21" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_21">
							<asp:textbox id="txtSENDEND_21" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_21">
							<asp:textbox id="txtMAILPASS_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_21">
							<asp:textbox id="txtZIP_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_21">
							<asp:textbox id="txtBIKOU_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="27" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_22">
                        <td id="DispNo_22">
                        	<input id="hdnID_22" type="hidden" name="hdnID_22" runat="server" />
                        	<input id="hdnDISP_NO_22" type="hidden" name="hdnDISP_NO_22" runat="server" />
							<asp:textbox id="txtNO_22" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="22"/>
						</td>
						<td id="DispDel_22" style="text-align:center;">
							<asp:checkbox id="chkDEL_22" tabIndex="28" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_22">
							<asp:textbox id="txtSEND_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_22" style="width:105px;">
							<asp:textbox id="txtKYOKYU_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_22" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('22');" tabIndex="28" type="button" value="▼" name="btnKYOKYU_22" runat="server" />
						</td>
						<td id="DispAcbcdFr_22" style="width:145px;">
							<asp:textbox id="txtACBCDFR_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_22" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('52');" tabIndex="28" type="button" value="▼" name="btnACBCDFR_22" runat="server" />
						</td>
						<td id="DispAcbcdTo_22" style="width:145px;">
							<asp:textbox id="txtACBCDTO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_22" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('82');" tabIndex="28" type="button" value="▼" name="btnACBCDTO_22" runat="server" />
						</td>
						<td id="DispHassei_22">
							<asp:DropDownList  id="listHASSEI_22" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="28">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_22">
							<asp:DropDownList  id="listKAIPAGE_22" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="28">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_22">
							<asp:DropDownList  id="listKIKAN_22" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="28">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_22">
							<asp:textbox id="txtFAX1_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_22">
							<asp:textbox id="txtFAX2_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_22">
							<asp:textbox id="txtMail1_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_22">
							<asp:textbox id="txtMail2_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_22">
							<asp:DropDownList  id="listZEROSND_22" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="28"/>
						</td>
						<td id="DispSD_PRT_22">
							<asp:DropDownList  id="listSD_PRT_22" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="28"/>
						</td>
						<td id="DispNxSnd_22">
							<asp:textbox id="txtNXSEND_22" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_22">
							<asp:textbox id="txtLSSEND_22" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_22">
							<asp:DropDownList  id="listSNDSTOP_22" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="28"/>
						</td>
						<td id="DispSndStr_22">
							<asp:textbox id="txtSENDSTR_22" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_22">
							<asp:textbox id="txtSENDEND_22" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_22">
							<asp:textbox id="txtMAILPASS_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_22">
							<asp:textbox id="txtZIP_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_22">
							<asp:textbox id="txtBIKOU_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="28" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_23">
                        <td id="DispNo_23">
                        	<input id="hdnID_23" type="hidden" name="hdnID_23" runat="server" />
                        	<input id="hdnDISP_NO_23" type="hidden" name="hdnDISP_NO_23" runat="server" />
							<asp:textbox id="txtNO_23" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="23"/>
						</td>
						<td id="DispDel_23" style="text-align:center;">
							<asp:checkbox id="chkDEL_23" tabIndex="29" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_23">
							<asp:textbox id="txtSEND_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_23" style="width:105px;">
							<asp:textbox id="txtKYOKYU_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_23" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('23');" tabIndex="29" type="button" value="▼" name="btnKYOKYU_23" runat="server" />
						</td>
						<td id="DispAcbcdFr_23" style="width:145px;">
							<asp:textbox id="txtACBCDFR_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_23" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('53');" tabIndex="29" type="button" value="▼" name="btnACBCDFR_23" runat="server" />
						</td>
						<td id="DispAcbcdTo_23" style="width:145px;">
							<asp:textbox id="txtACBCDTO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_23" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('83');" tabIndex="29" type="button" value="▼" name="btnACBCDTO_23" runat="server" />
						</td>
						<td id="DispHassei_23">
							<asp:DropDownList  id="listHASSEI_23" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="29">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_23">
							<asp:DropDownList  id="listKAIPAGE_23" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="29">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_23">
							<asp:DropDownList  id="listKIKAN_23" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="29">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_23">
							<asp:textbox id="txtFAX1_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_23">
							<asp:textbox id="txtFAX2_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_23">
							<asp:textbox id="txtMail1_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_23">
							<asp:textbox id="txtMail2_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_23">
							<asp:DropDownList  id="listZEROSND_23" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="29"/>
						</td>
						<td id="DispSD_PRT_23">
							<asp:DropDownList  id="listSD_PRT_23" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="29"/>
						</td>
						<td id="DispNxSnd_23">
							<asp:textbox id="txtNXSEND_23" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_23">
							<asp:textbox id="txtLSSEND_23" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_23">
							<asp:DropDownList  id="listSNDSTOP_23" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="29"/>
						</td>
						<td id="DispSndStr_23">
							<asp:textbox id="txtSENDSTR_23" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_23">
							<asp:textbox id="txtSENDEND_23" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_23">
							<asp:textbox id="txtMAILPASS_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_23">
							<asp:textbox id="txtZIP_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_23">
							<asp:textbox id="txtBIKOU_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="29" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_24">
                        <td id="DispNo_24">
                        	<input id="hdnID_24" type="hidden" name="hdnID_24" runat="server" />
                        	<input id="hdnDISP_NO_24" type="hidden" name="hdnDISP_NO_24" runat="server" />
							<asp:textbox id="txtNO_24" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="24"/>
						</td>
						<td id="DispDel_24" style="text-align:center;">
							<asp:checkbox id="chkDEL_24" tabIndex="30" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_24">
							<asp:textbox id="txtSEND_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_24" style="width:105px;">
							<asp:textbox id="txtKYOKYU_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_24" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('24');" tabIndex="30" type="button" value="▼" name="btnKYOKYU_24" runat="server" />
						</td>
						<td id="DispAcbcdFr_24" style="width:145px;">
							<asp:textbox id="txtACBCDFR_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_24" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('54');" tabIndex="30" type="button" value="▼" name="btnACBCDFR_24" runat="server" />
						</td>
						<td id="DispAcbcdTo_24" style="width:145px;">
							<asp:textbox id="txtACBCDTO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_24" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('84');" tabIndex="30" type="button" value="▼" name="btnACBCDTO_24" runat="server" />
						</td>
						<td id="DispHassei_24">
							<asp:DropDownList  id="listHASSEI_24" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="30">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_24">
							<asp:DropDownList  id="listKAIPAGE_24" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="30">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_24">
							<asp:DropDownList  id="listKIKAN_24" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="30">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_24">
							<asp:textbox id="txtFAX1_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_24">
							<asp:textbox id="txtFAX2_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_24">
							<asp:textbox id="txtMail1_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_24">
							<asp:textbox id="txtMail2_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_24">
							<asp:DropDownList  id="listZEROSND_24" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="30"/>
						</td>
						<td id="DispSD_PRT_24">
							<asp:DropDownList  id="listSD_PRT_24" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="30"/>
						</td>
						<td id="DispNxSnd_24">
							<asp:textbox id="txtNXSEND_24" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_24">
							<asp:textbox id="txtLSSEND_24" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_24">
							<asp:DropDownList  id="listSNDSTOP_24" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="30"/>
						</td>
						<td id="DispSndStr_24">
							<asp:textbox id="txtSENDSTR_24" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_24">
							<asp:textbox id="txtSENDEND_24" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_24">
							<asp:textbox id="txtMAILPASS_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_24">
							<asp:textbox id="txtZIP_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_24">
							<asp:textbox id="txtBIKOU_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="30" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_25">
                        <td id="DispNo_25">
                        	<input id="hdnID_25" type="hidden" name="hdnID_25" runat="server" />
                        	<input id="hdnDISP_NO_25" type="hidden" name="hdnDISP_NO_25" runat="server" />
							<asp:textbox id="txtNO_25" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="25"/>
						</td>
						<td id="DispDel_25" style="text-align:center;">
							<asp:checkbox id="chkDEL_25" tabIndex="31" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_25">
							<asp:textbox id="txtSEND_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_25" style="width:105px;">
							<asp:textbox id="txtKYOKYU_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_25" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('25');" tabIndex="31" type="button" value="▼" name="btnKYOKYU_25" runat="server" />
						</td>
						<td id="DispAcbcdFr_25" style="width:145px;">
							<asp:textbox id="txtACBCDFR_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_25" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('55');" tabIndex="31" type="button" value="▼" name="btnACBCDFR_25" runat="server" />
						</td>
						<td id="DispAcbcdTo_25" style="width:145px;">
							<asp:textbox id="txtACBCDTO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_25" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('85');" tabIndex="31" type="button" value="▼" name="btnACBCDTO_25" runat="server" />
						</td>
						<td id="DispHassei_25">
							<asp:DropDownList  id="listHASSEI_25" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="31">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_25">
							<asp:DropDownList  id="listKAIPAGE_25" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="31">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_25">
							<asp:DropDownList  id="listKIKAN_25" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="31">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_25">
							<asp:textbox id="txtFAX1_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_25">
							<asp:textbox id="txtFAX2_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_25">
							<asp:textbox id="txtMail1_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_25">
							<asp:textbox id="txtMail2_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_25">
							<asp:DropDownList  id="listZEROSND_25" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="31"/>
						</td>
						<td id="DispSD_PRT_25">
							<asp:DropDownList  id="listSD_PRT_25" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="31"/>
						</td>
						<td id="DispNxSnd_25">
							<asp:textbox id="txtNXSEND_25" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_25">
							<asp:textbox id="txtLSSEND_25" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_25">
							<asp:DropDownList  id="listSNDSTOP_25" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="31"/>
						</td>
						<td id="DispSndStr_25">
							<asp:textbox id="txtSENDSTR_25" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_25">
							<asp:textbox id="txtSENDEND_25" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_25">
							<asp:textbox id="txtMAILPASS_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_25">
							<asp:textbox id="txtZIP_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_25">
							<asp:textbox id="txtBIKOU_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="31" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_26">
                        <td id="DispNo_26">
                        	<input id="hdnID_26" type="hidden" name="hdnID_26" runat="server" />
                        	<input id="hdnDISP_NO_26" type="hidden" name="hdnDISP_NO_26" runat="server" />
							<asp:textbox id="txtNO_26" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="26"/>
						</td>
						<td id="DispDel_26" style="text-align:center;">
							<asp:checkbox id="chkDEL_26" tabIndex="32" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_26">
							<asp:textbox id="txtSEND_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_26" style="width:105px;">
							<asp:textbox id="txtKYOKYU_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_26" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('26');" tabIndex="32" type="button" value="▼" name="btnKYOKYU_26" runat="server" />
						</td>
						<td id="DispAcbcdFr_26" style="width:145px;">
							<asp:textbox id="txtACBCDFR_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_26" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('56');" tabIndex="32" type="button" value="▼" name="btnACBCDFR_26" runat="server" />
						</td>
						<td id="DispAcbcdTo_26" style="width:145px;">
							<asp:textbox id="txtACBCDTO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_26" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('86');" tabIndex="32" type="button" value="▼" name="btnACBCDTO_26" runat="server" />
						</td>
						<td id="DispHassei_26">
							<asp:DropDownList  id="listHASSEI_26" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="32">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_26">
							<asp:DropDownList  id="listKAIPAGE_26" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="32">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_26">
							<asp:DropDownList  id="listKIKAN_26" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="32">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_26">
							<asp:textbox id="txtFAX1_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_26">
							<asp:textbox id="txtFAX2_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_26">
							<asp:textbox id="txtMail1_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_26">
							<asp:textbox id="txtMail2_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_26">
							<asp:DropDownList  id="listZEROSND_26" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="32"/>
						</td>
						<td id="DispSD_PRT_26">
							<asp:DropDownList  id="listSD_PRT_26" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="32"/>
						</td>
						<td id="DispNxSnd_26">
							<asp:textbox id="txtNXSEND_26" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_26">
							<asp:textbox id="txtLSSEND_26" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_26">
							<asp:DropDownList  id="listSNDSTOP_26" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="32"/>
						</td>
						<td id="DispSndStr_26">
							<asp:textbox id="txtSENDSTR_26" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_26">
							<asp:textbox id="txtSENDEND_26" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_26">
							<asp:textbox id="txtMAILPASS_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_26">
							<asp:textbox id="txtZIP_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_26">
							<asp:textbox id="txtBIKOU_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="32" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_27">
                        <td id="DispNo_27">
                        	<input id="hdnID_27" type="hidden" name="hdnID_27" runat="server" />
                        	<input id="hdnDISP_NO_27" type="hidden" name="hdnDISP_NO_27" runat="server" />
							<asp:textbox id="txtNO_27" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="27"/>
						</td>
						<td id="DispDel_27" style="text-align:center;">
							<asp:checkbox id="chkDEL_27" tabIndex="33" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_27">
							<asp:textbox id="txtSEND_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_27" style="width:105px;">
							<asp:textbox id="txtKYOKYU_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_27" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('27');" tabIndex="33" type="button" value="▼" name="btnKYOKYU_27" runat="server" />
						</td>
						<td id="DispAcbcdFr_27" style="width:145px;">
							<asp:textbox id="txtACBCDFR_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_27" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('57');" tabIndex="33" type="button" value="▼" name="btnACBCDFR_27" runat="server" />
						</td>
						<td id="DispAcbcdTo_27" style="width:145px;">
							<asp:textbox id="txtACBCDTO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_27" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('87');" tabIndex="33" type="button" value="▼" name="btnACBCDTO_27" runat="server" />
						</td>
						<td id="DispHassei_27">
							<asp:DropDownList  id="listHASSEI_27" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="33">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_27">
							<asp:DropDownList  id="listKAIPAGE_27" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="33">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_27">
							<asp:DropDownList  id="listKIKAN_27" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="33">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_27">
							<asp:textbox id="txtFAX1_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_27">
							<asp:textbox id="txtFAX2_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_27">
							<asp:textbox id="txtMail1_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_27">
							<asp:textbox id="txtMail2_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_27">
							<asp:DropDownList  id="listZEROSND_27" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="33"/>
						</td>
						<td id="DispSD_PRT_27">
							<asp:DropDownList  id="listSD_PRT_27" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="33"/>
						</td>
						<td id="DispNxSnd_27">
							<asp:textbox id="txtNXSEND_27" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_27">
							<asp:textbox id="txtLSSEND_27" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_27">
							<asp:DropDownList  id="listSNDSTOP_27" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="33"/>
						</td>
						<td id="DispSndStr_27">
							<asp:textbox id="txtSENDSTR_27" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_27">
							<asp:textbox id="txtSENDEND_27" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_27">
							<asp:textbox id="txtMAILPASS_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_27">
							<asp:textbox id="txtZIP_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_27">
							<asp:textbox id="txtBIKOU_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="33" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_28">
                        <td id="DispNo_28">
                        	<input id="hdnID_28" type="hidden" name="hdnID_28" runat="server" />
                        	<input id="hdnDISP_NO_28" type="hidden" name="hdnDISP_NO_28" runat="server" />
							<asp:textbox id="txtNO_28" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="28"/>
						</td>
						<td id="DispDel_28" style="text-align:center;">
							<asp:checkbox id="chkDEL_28" tabIndex="34" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_28">
							<asp:textbox id="txtSEND_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_28" style="width:105px;">
							<asp:textbox id="txtKYOKYU_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_28" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('28');" tabIndex="34" type="button" value="▼" name="btnKYOKYU_28" runat="server" />
						</td>
						<td id="DispAcbcdFr_28" style="width:145px;">
							<asp:textbox id="txtACBCDFR_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_28" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('58');" tabIndex="34" type="button" value="▼" name="btnACBCDFR_28" runat="server" />
						</td>
						<td id="DispAcbcdTo_28" style="width:145px;">
							<asp:textbox id="txtACBCDTO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_28" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('88');" tabIndex="34" type="button" value="▼" name="btnACBCDTO_28" runat="server" />
						</td>
						<td id="DispHassei_28">
							<asp:DropDownList  id="listHASSEI_28" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="34">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_28">
							<asp:DropDownList  id="listKAIPAGE_28" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="34">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_28">
							<asp:DropDownList  id="listKIKAN_28" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="34">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_28">
							<asp:textbox id="txtFAX1_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_28">
							<asp:textbox id="txtFAX2_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_28">
							<asp:textbox id="txtMail1_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_28">
							<asp:textbox id="txtMail2_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_28">
							<asp:DropDownList  id="listZEROSND_28" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="34"/>
						</td>
						<td id="DispSD_PRT_28">
							<asp:DropDownList  id="listSD_PRT_28" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="34"/>
						</td>
						<td id="DispNxSnd_28">
							<asp:textbox id="txtNXSEND_28" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_28">
							<asp:textbox id="txtLSSEND_28" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_28">
							<asp:DropDownList  id="listSNDSTOP_28" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="34"/>
						</td>
						<td id="DispSndStr_28">
							<asp:textbox id="txtSENDSTR_28" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_28">
							<asp:textbox id="txtSENDEND_28" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_28">
							<asp:textbox id="txtMAILPASS_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_28">
							<asp:textbox id="txtZIP_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_28">
							<asp:textbox id="txtBIKOU_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="34" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_29">
                        <td id="DispNo_29">
                        	<input id="hdnID_29" type="hidden" name="hdnID_29" runat="server" />
                        	<input id="hdnDISP_NO_29" type="hidden" name="hdnDISP_NO_29" runat="server" />
							<asp:textbox id="txtNO_29" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="29"/>
						</td>
						<td id="DispDel_29" style="text-align:center;">
							<asp:checkbox id="chkDEL_29" tabIndex="35" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_29">
							<asp:textbox id="txtSEND_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_29" style="width:105px;">
							<asp:textbox id="txtKYOKYU_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_29" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('29');" tabIndex="35" type="button" value="▼" name="btnKYOKYU_29" runat="server" />
						</td>
						<td id="DispAcbcdFr_29" style="width:145px;">
							<asp:textbox id="txtACBCDFR_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_29" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('59');" tabIndex="35" type="button" value="▼" name="btnACBCDFR_29" runat="server" />
						</td>
						<td id="DispAcbcdTo_29" style="width:145px;">
							<asp:textbox id="txtACBCDTO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_29" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('89');" tabIndex="35" type="button" value="▼" name="btnACBCDTO_29" runat="server" />
						</td>
						<td id="DispHassei_29">
							<asp:DropDownList  id="listHASSEI_29" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="35">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_29">
							<asp:DropDownList  id="listKAIPAGE_29" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="35">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_29">
							<asp:DropDownList  id="listKIKAN_29" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="35">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_29">
							<asp:textbox id="txtFAX1_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_29">
							<asp:textbox id="txtFAX2_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_29">
							<asp:textbox id="txtMail1_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_29">
							<asp:textbox id="txtMail2_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_29">
							<asp:DropDownList  id="listZEROSND_29" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="35"/>
						</td>
						<td id="DispSD_PRT_29">
							<asp:DropDownList  id="listSD_PRT_29" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="35"/>
						</td>
						<td id="DispNxSnd_29">
							<asp:textbox id="txtNXSEND_29" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_29">
							<asp:textbox id="txtLSSEND_29" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_29">
							<asp:DropDownList  id="listSNDSTOP_29" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="35"/>
						</td>
						<td id="DispSndStr_29">
							<asp:textbox id="txtSENDSTR_29" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_29">
							<asp:textbox id="txtSENDEND_29" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_29">
							<asp:textbox id="txtMAILPASS_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_29">
							<asp:textbox id="txtZIP_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_29">
							<asp:textbox id="txtBIKOU_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="35" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
					<tr id="list_30">
                        <td id="DispNo_30">
                        	<input id="hdnID_30" type="hidden" name="hdnID_30" runat="server" />
                        	<input id="hdnDISP_NO_30" type="hidden" name="hdnDISP_NO_30" runat="server" />
							<asp:textbox id="txtNO_30" tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" value="30"/>
						</td>
						<td id="DispDel_30" style="text-align:center;">
							<asp:checkbox id="chkDEL_30" tabIndex="36" runat="server"  Width="26px" onkeydown="fncFc(this)" />
						</td>
						<td id="DispSend_30">
							<asp:textbox id="txtSEND_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="60px" MaxLength="8" />
						</td>
						<td id="DispKyokyu_30" style="width:105px;">
							<asp:textbox id="txtKYOKYU_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  
                            CssClass="c-f" Width="80px" /><input class="bt-KS" id="btnKYOKYU_30" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('30');" tabIndex="36" type="button" value="▼" name="btnKYOKYU_30" runat="server" />
						</td>
						<td id="DispAcbcdFr_30" style="width:145px;">
							<asp:textbox id="txtACBCDFR_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDFR_30" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('60');" tabIndex="36" type="button" value="▼" name="btnACBCDFR_30" runat="server" />
						</td>
						<td id="DispAcbcdTo_30" style="width:145px;">
							<asp:textbox id="txtACBCDTO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"
                            CssClass="c-f" Width="120px" /><input class="bt-KS" id="btnACBCDTO_30" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('90');" tabIndex="36" type="button" value="▼" name="btnACBCDTO_30" runat="server" />
						</td>
						<td id="DispHassei_30">
							<asp:DropDownList  id="listHASSEI_30" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="36">
							</asp:DropDownList >
						</td>
						<td id="DispKaipage_30">
							<asp:DropDownList  id="listKAIPAGE_30" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="36">
							</asp:DropDownList >
						</td>
						<td id="DispKikan_30">
							<asp:DropDownList  id="listKIKAN_30" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="36">
							</asp:DropDownList >
						</td>
						<td id="DispFax1_30">
							<asp:textbox id="txtFAX1_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispFax2_30">
							<asp:textbox id="txtFAX2_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="200px" MaxLength="15" />
						</td>
						<td id="DispMail1_30">
							<asp:textbox id="txtMail1_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispMail2_30">
							<asp:textbox id="txtMail2_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="200px" MaxLength="100" />
						</td>
						<td id="DispZero_30">
							<asp:DropDownList  id="listZEROSND_30" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="36"/>
						</td>
						<td id="DispSD_PRT_30">
							<asp:DropDownList  id="listSD_PRT_30" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" TabIndex="36"/>
						</td>
						<td id="DispNxSnd_30">
							<asp:textbox id="txtNXSEND_30" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispLsSnd_30">
							<asp:textbox id="txtLSSEND_30" tabIndex="-1" runat="server" CssClass="c-RO" Width="120px" />
						</td>
						<td id="DispSndKbn_30">
							<asp:DropDownList  id="listSNDSTOP_30" runat="server" Width="120px" CssClass="c-hI" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" tabIndex="36"/>
						</td>
						<td id="DispSndStr_30">
							<asp:textbox id="txtSENDSTR_30" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispSndEnd_30">
							<asp:textbox id="txtSENDEND_30" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="120px" />
						</td>
						<td id="DispMailPs_30">
							<asp:textbox id="txtMAILPASS_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  CssClass="c-f" Width="150px" MaxLength="20" />
						</td>
						<td id="DispZip_30">
							<asp:textbox id="txtZIP_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  CssClass="c-fI" Width="160px" MaxLength="30" />
						</td>
						<td id="DispBikou_30">
							<asp:textbox id="txtBIKOU_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabIndex="36" runat="server"  CssClass="c-fI" Width="500px" MaxLength="500" />
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
