<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTAKJAG00.aspx.vb" Inherits="MSTAKJAG00.MSTAKJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSTAKJAG00</title>
	</HEAD>
		<% 
'***********************************************
' 監視センター担当者マスタ  画面
'***********************************************
' 変更履歴	    
%>
<body>
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
			<asp:label id="lblScript" runat="server"></asp:label>
			<input id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server" />
            <input id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server" />
			<input id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server" />
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="*"><input class="bt-JIK" id="btnSelect" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();"
										tabIndex="1001" type="button" value="検索" name="btnSelect" runat="server">
								</td>
								<td width="300">&nbsp;</td>
								<td width="220"><input class="bt-JIK" id="btnUpdate" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnUpdate_onclick();"
										tabIndex="1002" type="button" value="登録" name="btnUpdate" runat="server">
								</td>
								<td width="220"><input class="bt-JIK" id="btnDelete" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnDelete_onclick();"
										tabIndex="1003" type="button" value="削除" name="btnDelete" runat="server">
								</td>
								<td width="70"><input class="bt-JIK" id="btnClear" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnClear_onclick();"
										tabIndex="1005" type="button" value="取消" name="btnClear" runat="server">
								</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
										tabIndex="1006" type="button" value="終了" name="btnExit" runat="server">
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
											<td class="TITLE" vAlign="middle">監視センター担当者マスタ</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="170">
								</td>
							</tr>
						</table>
						<input id="hdnKBN" type="hidden" name="hdnKBN" runat="server"  />
						<input id="hdnADD_DATE_1" type="hidden" name="hdnADD_DATE_1" runat="server" />
						<input id="hdnADD_DATE_2" type="hidden" name="hdnADD_DATE_2" runat="server" />
						<input id="hdnADD_DATE_3" type="hidden" name="hdnADD_DATE_3" runat="server" />
						<input id="hdnADD_DATE_4" type="hidden" name="hdnADD_DATE_4" runat="server" />
						<input id="hdnADD_DATE_5" type="hidden" name="hdnADD_DATE_5" runat="server" />
						<input id="hdnADD_DATE_6" type="hidden" name="hdnADD_DATE_6" runat="server" />
						<input id="hdnADD_DATE_7" type="hidden" name="hdnADD_DATE_7" runat="server" />
						<input id="hdnADD_DATE_8" type="hidden" name="hdnADD_DATE_8" runat="server" />
						<input id="hdnADD_DATE_9" type="hidden" name="hdnADD_DATE_9" runat="server" />
						<input id="hdnADD_DATE_10" type="hidden" name="hdnADD_DATE_10" runat="server" />
						<input id="hdnADD_DATE_11" type="hidden" name="hdnADD_DATE_11" runat="server" />
						<input id="hdnADD_DATE_12" type="hidden" name="hdnADD_DATE_12" runat="server" />
						<input id="hdnADD_DATE_13" type="hidden" name="hdnADD_DATE_13" runat="server" />
						<input id="hdnADD_DATE_14" type="hidden" name="hdnADD_DATE_14" runat="server" />
						<input id="hdnADD_DATE_15" type="hidden" name="hdnADD_DATE_15" runat="server" />
						<input id="hdnADD_DATE_16" type="hidden" name="hdnADD_DATE_16" runat="server" />
						<input id="hdnADD_DATE_17" type="hidden" name="hdnADD_DATE_17" runat="server" />
						<input id="hdnADD_DATE_18" type="hidden" name="hdnADD_DATE_18" runat="server" />
						<input id="hdnADD_DATE_19" type="hidden" name="hdnADD_DATE_19" runat="server" />
						<input id="hdnADD_DATE_20" type="hidden" name="hdnADD_DATE_20" runat="server" />
						<input id="hdnADD_DATE_21" type="hidden" name="hdnADD_DATE_21" runat="server" />
						<input id="hdnADD_DATE_22" type="hidden" name="hdnADD_DATE_22" runat="server" />
						<input id="hdnADD_DATE_23" type="hidden" name="hdnADD_DATE_23" runat="server" />
						<input id="hdnADD_DATE_24" type="hidden" name="hdnADD_DATE_24" runat="server" />
						<input id="hdnADD_DATE_25" type="hidden" name="hdnADD_DATE_25" runat="server" />
						<input id="hdnADD_DATE_26" type="hidden" name="hdnADD_DATE_26" runat="server" />
						<input id="hdnADD_DATE_27" type="hidden" name="hdnADD_DATE_27" runat="server" />
						<input id="hdnADD_DATE_28" type="hidden" name="hdnADD_DATE_28" runat="server" />
						<input id="hdnADD_DATE_29" type="hidden" name="hdnADD_DATE_29" runat="server" />
						<input id="hdnADD_DATE_30" type="hidden" name="hdnADD_DATE_30" runat="server" />
						<input id="hdnEDT_DATE_1" type="hidden" name="hdnEDT_DATE_1" runat="server" />
						<input id="hdnEDT_DATE_2" type="hidden" name="hdnEDT_DATE_2" runat="server" />
						<input id="hdnEDT_DATE_3" type="hidden" name="hdnEDT_DATE_3" runat="server" />
						<input id="hdnEDT_DATE_4" type="hidden" name="hdnEDT_DATE_4" runat="server" />
						<input id="hdnEDT_DATE_5" type="hidden" name="hdnEDT_DATE_5" runat="server" />
						<input id="hdnEDT_DATE_6" type="hidden" name="hdnEDT_DATE_6" runat="server" />
						<input id="hdnEDT_DATE_7" type="hidden" name="hdnEDT_DATE_7" runat="server" />
						<input id="hdnEDT_DATE_8" type="hidden" name="hdnEDT_DATE_8" runat="server" />
						<input id="hdnEDT_DATE_9" type="hidden" name="hdnEDT_DATE_9" runat="server" />
						<input id="hdnEDT_DATE_10" type="hidden" name="hdnEDT_DATE_10" runat="server" />
						<input id="hdnEDT_DATE_11" type="hidden" name="hdnEDT_DATE_11" runat="server" />
						<input id="hdnEDT_DATE_12" type="hidden" name="hdnEDT_DATE_12" runat="server" />
						<input id="hdnEDT_DATE_13" type="hidden" name="hdnEDT_DATE_13" runat="server" />
						<input id="hdnEDT_DATE_14" type="hidden" name="hdnEDT_DATE_14" runat="server" />
						<input id="hdnEDT_DATE_15" type="hidden" name="hdnEDT_DATE_15" runat="server" />
						<input id="hdnEDT_DATE_16" type="hidden" name="hdnEDT_DATE_16" runat="server" />
						<input id="hdnEDT_DATE_17" type="hidden" name="hdnEDT_DATE_17" runat="server" />
						<input id="hdnEDT_DATE_18" type="hidden" name="hdnEDT_DATE_18" runat="server" />
						<input id="hdnEDT_DATE_19" type="hidden" name="hdnEDT_DATE_19" runat="server" />
						<input id="hdnEDT_DATE_20" type="hidden" name="hdnEDT_DATE_20" runat="server" />
						<input id="hdnEDT_DATE_21" type="hidden" name="hdnEDT_DATE_21" runat="server" />
						<input id="hdnEDT_DATE_22" type="hidden" name="hdnEDT_DATE_22" runat="server" />
						<input id="hdnEDT_DATE_23" type="hidden" name="hdnEDT_DATE_23" runat="server" />
						<input id="hdnEDT_DATE_24" type="hidden" name="hdnEDT_DATE_24" runat="server" />
						<input id="hdnEDT_DATE_25" type="hidden" name="hdnEDT_DATE_25" runat="server" />
						<input id="hdnEDT_DATE_26" type="hidden" name="hdnEDT_DATE_26" runat="server" />
						<input id="hdnEDT_DATE_27" type="hidden" name="hdnEDT_DATE_27" runat="server" />
						<input id="hdnEDT_DATE_28" type="hidden" name="hdnEDT_DATE_28" runat="server" />
						<input id="hdnEDT_DATE_29" type="hidden" name="hdnEDT_DATE_29" runat="server" />
						<input id="hdnEDT_DATE_30" type="hidden" name="hdnEDT_DATE_30" runat="server" />
						<input id="hdnTIME_1" type="hidden" name="hdnTIME_1" runat="server" />
						<input id="hdnTIME_2" type="hidden" name="hdnTIME_2" runat="server" />
						<input id="hdnTIME_3" type="hidden" name="hdnTIME_3" runat="server" />
						<input id="hdnTIME_4" type="hidden" name="hdnTIME_4" runat="server" />
						<input id="hdnTIME_5" type="hidden" name="hdnTIME_5" runat="server" />
						<input id="hdnTIME_6" type="hidden" name="hdnTIME_6" runat="server" />
						<input id="hdnTIME_7" type="hidden" name="hdnTIME_7" runat="server" />
						<input id="hdnTIME_8" type="hidden" name="hdnTIME_8" runat="server" />
						<input id="hdnTIME_9" type="hidden" name="hdnTIME_9" runat="server" />
						<input id="hdnTIME_10" type="hidden" name="hdnTIME_10" runat="server" />
						<input id="hdnTIME_11" type="hidden" name="hdnTIME_11" runat="server" />
						<input id="hdnTIME_12" type="hidden" name="hdnTIME_12" runat="server" />
						<input id="hdnTIME_13" type="hidden" name="hdnTIME_13" runat="server" />
						<input id="hdnTIME_14" type="hidden" name="hdnTIME_14" runat="server" />
						<input id="hdnTIME_15" type="hidden" name="hdnTIME_15" runat="server" />
						<input id="hdnTIME_16" type="hidden" name="hdnTIME_16" runat="server" />
						<input id="hdnTIME_17" type="hidden" name="hdnTIME_17" runat="server" />
						<input id="hdnTIME_18" type="hidden" name="hdnTIME_18" runat="server" />
						<input id="hdnTIME_19" type="hidden" name="hdnTIME_19" runat="server" />
						<input id="hdnTIME_20" type="hidden" name="hdnTIME_20" runat="server" />
						<input id="hdnTIME_21" type="hidden" name="hdnTIME_21" runat="server" />
						<input id="hdnTIME_22" type="hidden" name="hdnTIME_22" runat="server" />
						<input id="hdnTIME_23" type="hidden" name="hdnTIME_23" runat="server" />
						<input id="hdnTIME_24" type="hidden" name="hdnTIME_24" runat="server" />
						<input id="hdnTIME_25" type="hidden" name="hdnTIME_25" runat="server" />
						<input id="hdnTIME_26" type="hidden" name="hdnTIME_26" runat="server" />
						<input id="hdnTIME_27" type="hidden" name="hdnTIME_27" runat="server" />
						<input id="hdnTIME_28" type="hidden" name="hdnTIME_28" runat="server" />
						<input id="hdnTIME_29" type="hidden" name="hdnTIME_29" runat="server" />
						<input id="hdnTIME_30" type="hidden" name="hdnTIME_30" runat="server" />
					</td>
				</tr>
			</table>
			<hr>
            <table cellSpacing="1" cellPadding="5" width="1150">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="100" class="TXTKY" align="right">監視ｾﾝﾀｰｺｰﾄﾞ&nbsp;&nbsp;</td>
                    <td width="350" >
                        <asp:textbox id="txtCODE" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"	BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnCODE" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabIndex="1" type="button" value="▼" name="btnCODE" runat="server" />
                        <input id="hdnCODE" type="hidden" name="hdnCODE" runat="server" />
						<input id="hdnCODE_MOTO" type="hidden" name="hdnCODE_MOTO" runat="server" />
					</td>
					<td width="350">
					</td>
					<td width="140">
                        <a href="MSTAKJAG00.pdf" target="_blank" tabIndex="5"><img src="../../../Script/icon_pdf.gif" border="0" alt="img" />マニュアル&nbsp;&nbsp;</a>
					</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td  class="TXTKY" align="right">担当者コード&nbsp;&nbsp;</td>
                    <td >
                        <asp:textbox id="txtTANCD_F" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnTANCD_F" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="2" type="button" value="▼" name="btnTANCD_F" runat="server" />&nbsp;～
                        <input id="hdnTANCD_F" type="hidden" name="hdnTANCD_F" runat="server" />
						<input id="hdnTANCD_F_MOTO" type="hidden" name="hdnTANCD_F_MOTO" runat="server" />
					</td>
                    <td>
                        <asp:textbox id="txtTANCD_T" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnTANCD_T" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabIndex="3" type="button" value="▼" name="btnTANCD_T" runat="server" />
                        <input id="hdnTANCD_T" type="hidden" name="hdnTANCD_T" runat="server" />
						<input id="hdnTANCD_T_MOTO" type="hidden" name="hdnTANCD_T_MOTO" runat="server" />
                    </td>
                    <td>
                        <input language="javascript" class="bt-RNW" id="btnCSVout" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnCsv_onclick();" tabIndex="4" type="button"
							value="データ出力" name="btnCSVout" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
			</table>
            <hr>
            <table>
                <tr>
                    <td width="80">
						<input type="button" name="AllSelect" value="全て選択" onclick="fncAllSelectClick();" id="btnAllSelect" tabIndex="51" />
					</td>
                    <td width="80">
						<input type="button" name="AllRemove" value="全て解除" onclick="fncAllRemoveClick();" id="btnAllRemove" tabIndex="52" />
					</td>
					<td width="790" align="right"><font color="red">表示件数：最大30件</font></td>
                </tr>
            </table>
			<input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server" />
			<table cellSpacing="0" cellPadding="0">
				<tr>
					<td align="left" height="25">№</td>
					<td align="left" height="25">&nbsp;&nbsp;削</td>
					<td align="left" height="25">&nbsp;&nbsp;担当者コード</td>
					<td align="left" height="25">&nbsp;&nbsp;担当者名漢字</td>
					<td align="left" height="25">&nbsp;&nbsp;担当者ID</td><!-- 2020/11/01 T.Ono add 2020監視改善 -->
					<td align="left" height="25">&nbsp;&nbsp;表示順</td>
                    <td align="left" height="25">&nbsp;&nbsp;備考</td>
				</tr>
				<tr id="list_1">
                    <%-- .NET 使用変更により、ReadOnlyはVB側でAttributeでつける --%>
                    <%-- 2020/11/01 T.Ono mod 2020監視改善　担当者IDを追加。tabindex変更。 --%>
                    <td>
                        <asp:textbox id="txtNo_1" value="01" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_1" tabIndex="111" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_1" type="hidden" name="hdnDEL_1" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtTANCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="112" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="113" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="114" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="115" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="116" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="122" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="123" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="124" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="125" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="126" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="132" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="133" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="134" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="135" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="136" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="142" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="143" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="144" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="145" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="146" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="152" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="153" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="154" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="155" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="156" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="162" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="163" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="164" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="165" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="166" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="172" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="173" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="174" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="175" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="176" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="182" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="183" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="184" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="185" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="186" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="192" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="193" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="194" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="195" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="196" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="202" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="203" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="204" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="205" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="206" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="212" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="213" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="214" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="215" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="216" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="222" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="223" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="224" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="225" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="226" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="232" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="233" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="234" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="235" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="236" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="242" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="243" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="244" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="245" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="246" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="252" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="253" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="254" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="255" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="256" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="262" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="263" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="264" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="265" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="266" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="272" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="273" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="274" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="275" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="276" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="282" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="283" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="284" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="285" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="286" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="292" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="293" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="294" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="295" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="296" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="302" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="303" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="304" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="305" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="306" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="312" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="313" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="314" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="315" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="316" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_22">
                    <td>
                        <asp:textbox id="txtNo_22" value="22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_22" tabIndex="321" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_22" type="hidden" name="hdnDEL_22" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtTANCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="322" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="323" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="324" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="325" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="326" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="332" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="333" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="334" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="335" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="336" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="342" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="343" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="344" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="345" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="346" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="352" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="353" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="354" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="355" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="356" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="362" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="363" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="364" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="365" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="366" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="372" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="373" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="374" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="375" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="376" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="382" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="383" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="384" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="385" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="386" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="392" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="393" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="394" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="395" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="396" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
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
                        <asp:textbox id="txtTANCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="402" runat="server" CssClass="c-h" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANNM_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="403" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtTANID_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="404" runat="server" CssClass="c-f" Width="140px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtDISP_NO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="405" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="406" runat="server" CssClass="c-fI" Width="400px" MaxLength="30"></asp:textbox>
                    </td>
				</tr>
			</table>
		</form>
		<script type="text/javascript">

		</script>
	</body>
</HTML>
