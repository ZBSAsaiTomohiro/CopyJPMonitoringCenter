<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSJINJAG00.aspx.vb" Inherits="MSJINJAG00.MSJINJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSJINJAG00</title>
	</HEAD>
<% 
'***********************************************
    ' 自動対応内容マスタ  画面
'***********************************************
' 変更履歴	    
%>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server" />
			<input id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server" />
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
											<td class="TITLE" vAlign="middle">自動対応内容マスタ</td>
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
					</td>
				</tr>
			</table>
			<hr>
            <%-- // 2023/01/26 MOD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応 --%>
            <table cellspacing="1" cellpadding="5" width="1150">
                <tr>
                    <td>
                        <table cellspacing="1" cellpadding="5" width="550">
                            <tr>
                                <td width="10">&nbsp;</td>
                                <%-- 2017/02/09 W.GANEKO UPD START 2016監視改善 №10 --%>
                                <%-- <td width="100" class="TXTKY" align="right">グループコード&nbsp;&nbsp;</td>
                    <td width="350" >
                        <cc1:ctlcombo id="cboGROUPCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onchange="fncChengGroup()"
		                        tabindex="1" runat="server" width="200px" cssclass="cb"></cc1:ctlcombo>
                        <input id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server" />
						<input id="hdnGROUPCD_MOTO" type="hidden" name="hdnGROUPCD_MOTO" runat="server" />
					</td> --%>
                                <td width="140" class="TXTKY" align="right">グループコード・名称&nbsp;&nbsp;</td>
                                <td width="400">
                                    <asp:TextBox ID="txtGROUPCD" TabIndex="-1" runat="server" CssClass="c-rNM" Width="360px" BorderStyle="Solid" BorderWidth="1px">
                                    </asp:TextBox><input class="bt-KS" id="btnGROUPCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('4');"
                                        tabindex="1" type="button" value="▼" name="btnGROUPCD" runat="server" />
                                    <input id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server" />
                                    <input id="hdnGROUPCD_MOTO" type="hidden" name="hdnGROUPCD_MOTO" runat="server" />
                                </td>
                                <%-- 2017/02/09 W.GANEKO UPD END 2016監視改善 №10 --%>
                            </tr>
                            <tr>
                                <td width="10">&nbsp;</td>
                                <td width="140" align="right">グループコード&nbsp;&nbsp;<br />
                                    （新規登録用）&nbsp;&nbsp;
                                </td>
                                <td width="400">
                                    <asp:TextBox ID="txtGROUPCD_NEW" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
                                        TabIndex="2" runat="server" CssClass="c-f" Width="200px" MaxLength="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="150" colspan="2">&nbsp;</td>
                                <td width="400">
                                    <input language="javascript" class="bt-RNW" id="btnKEIHOList" onblur="return fncFo(this,5);"
                                        onfocus="fncFo(this,2)" onclick="return btnKEIHOList_onclick();" tabindex="4" type="button"
                                        value="警報一覧" name="btnCSVout" runat="server" />&nbsp;&nbsp;
                                    <input language="javascript" class="bt-RNW" id="btnCSVout" onblur="return fncFo(this,5);"
                                        onfocus="fncFo(this,2)" onclick="return btnCsv_onclick();" tabindex="5" type="button"
                                        value="データ出力" name="btnCSVout" runat="server" />&nbsp;&nbsp;
                                    <a href="MSJINJAG00.pdf" target="_blank" tabindex="5">
                                        <img src="../../../Script/icon_pdf.gif" border="0" alt="img" />マニュアル&nbsp;&nbsp;</a>
                                </td>
                            </tr>
                        </table>
                    </td>

                    <td>
                        <%-- //ここに今回のリストとボタンを追加。  --%>
                        <table cellspacing="1" cellpadding="5" width="600" style="border:1px solid #000;" >
                            <tr><%-- //1行目  --%>
                                <td width="220" class="TXTKY TD-NOWRAP" align="right">グループコード・名称（範囲）&nbsp;&nbsp;</td>
                                <td width="380" colspan="3" class="TD-NOWRAP" >
                                    使用区分の一括変更（対象_8：感震器遮断、15：安全確認中遮断）<br>
                                    ※更新前の状態を保持せず、常にまとめて"使用可"または"不可"に更新。
                                </td>
                            </tr>
                            <tr><%-- //2行目  --%>
                                <td width="220" class="TXTKY TD-NOWRAP" align="right">From&nbsp;&nbsp;</td>
                                <td width="380" class="TD-NOWRAP">
                                    <cc1:CTLCombo ID="cboJTLISTFROM" Width="370px" CssClass="cb-h" TabIndex="-1"
                                        onfocus="fncFo(this,2)" onblur="fncFo(this,3)" 
                                        onkeydown="fncFc(this)" onmousedown="fncFo(this,2)" 
                                        runat="server" >
                                    </cc1:CTLCombo>
                                </td>
                            </tr>
                            <tr><%-- //3行目  --%>
                                <td width="220" class="TXTKY TD-NOWRAP" align="right">To&nbsp;&nbsp;</td>
                                <td width="380" class="TD-NOWRAP">
                                    <cc1:CTLCombo ID="cboJTLISTTO" Width="370px" CssClass="cb-h" TabIndex="-1"
                                        onfocus="fncFo(this,2)" onblur="fncFo(this,3)" 
                                        onkeydown="fncFc(this)" onmousedown="fncFo(this,2)" 
                                        runat="server" >
                                    </cc1:CTLCombo>
                                </td>
                            </tr>
                            <tr><%-- //4行目  --%>
                                <td width="220"></td>
                                <td width="380" class="TD-NOWRAP" >
                                    <input type="button" name="btnUpdateJtFlgAllOn" value="更新：使用可へ"    TabIndex="-1"
                                        class="bt-RNW" id="btnUpdateJtFlgAllOn" 
                                        onfocus="fncFo(this,2)" onblur="fncFo(this,5)" 
                                        onclick="return btnAllUseFlgFromTo(1);" runat="server">
                                    &nbsp; <%-- //ボタン間で、すき間をあける  --%>
                                    <input type="button" name="btnUpdateJtFlgAllOff" value="更新：使用不可へ" TabIndex="-1"
                                        class="bt-RNW" id="btnUpdateJtFlgAllOff" 
                                        onfocus="fncFo(this,2)" onblur="fncFo(this,5)" 
                                        onclick="return btnAllUseFlgFromTo(2);" runat="server">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <%-- // 2023/01/26 MOD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応 --%>
            <hr>
            <%-- 2021/10/01 sakaUPD start 2021年度監視改善⑤ 使用フラグを一括で変更 --%>
            <%-- <table> --%>
            <table width="2260">
            <%-- 2021/10/01 sakaUPD end 2021年度監視改善⑤ 使用フラグを一括で変更 --%>
                <tr>
                    <td width="80">
						<input type="button" name="AllSelect" value="全て選択" onclick="btnCheckBtn(1);" id="btnAllSelect" tabIndex="51" />
					</td>
                    <td width="80">
						<input type="button" name="AllRemove" value="全て解除" onclick="btnCheckBtn(2);" id="btnAllRemove" tabIndex="52" />
					</td>
					<td width="790" align="right"><font color="red">表示件数：最大30件</font></td>
                </tr>
                <tr>
                    <td colspan="3">
                        グループコード名&nbsp;&nbsp;<asp:textbox id="txtGROUPNM" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="53" runat="server" CssClass="c-hI" Width="250px" MaxLength="60"></asp:textbox>
                    </td>
                    <%-- 2021/10/01 sakaADD start 2021監視改善⑤ 使用フラグを一括で変更 --%>
					<td width="1050">
                    </td>
                    <td width="80">
						<input type="button" name="AllUse" value="全使用可能" onclick="btnAllUseFlg(1);" id="btnAllUse" />
					</td>
                    <td width="80">
						<input type="button" name="AllNotUse" value="全使用不可" onclick="btnAllUseFlg(2);" id="btnAllNotUse" />
					</td>
                    <%-- 2021/10/01 sakaADD end 2021監視改善⑤ 使用フラグを一括で変更 --%>
                </tr>
            </table>
            <input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server" />
			<table cellSpacing="0" cellPadding="0"">
				<tr>
				    <td align="left" height="25">&nbsp;№</td>
				    <td align="left" height="25">&nbsp;&nbsp;削</td>
				    <td align="left" height="25">&nbsp;&nbsp;警報コード</td>
				    <td align="left" height="25">&nbsp;&nbsp;警報名称</td>
				    <td align="left" height="25">&nbsp;&nbsp;対応／無視区分</td>
				    <td align="left" height="25">&nbsp;&nbsp;対応区分</td>
				    <td align="left" height="25">&nbsp;&nbsp;処理区分</td>
				    <td align="left" height="25">&nbsp;&nbsp;監視センター<br />&nbsp;&nbsp;担当者コード</td>
				    <td align="left" height="25">&nbsp;&nbsp;連絡相手</td>
				    <td align="left" height="25">&nbsp;&nbsp;復帰対応状況</td>
				    <td align="left" height="25">&nbsp;&nbsp;ガス器具</td>
				    <td align="left" height="25">&nbsp;&nbsp;作動原因</td>
				    <td align="left" height="25">&nbsp;&nbsp;電話連絡内容</td>
				    <td align="left" height="25">&nbsp;&nbsp;電話対応メモ</td>
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
                        <asp:checkbox id="chkDEL_1" tabIndex="101" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_1" type="hidden" name="hdnDEL_1" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="102" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="103" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <%-- // リスト挙動修正、これをすべてのリストに追加すれば治る。→onmousedown="fncFo(this,2)"  --%>
                        <cc1:ctlcombo id="cboPROCKBN_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="104" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="105" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="106" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="107" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="108" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="109" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="110" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="111" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="112" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="113" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="114" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="115" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
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
                        <asp:textbox id="txtKMCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="122" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="123" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="124" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="125" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="126" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="127" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="128" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="129" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="130" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="131" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="132" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="133" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="134" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="135" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_3">
                    <td>
                        <asp:textbox id="txtNo_3" value="03" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_3" tabIndex="141" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_3" type="hidden" name="hdnDEL_3" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="142" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="143" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="144" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="145" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="146" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="147" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="148" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="149" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="150" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="151" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="152" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="153" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="154" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="155" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_4">
                    <td>
                        <asp:textbox id="txtNo_4" value="04" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_4" tabIndex="161" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_4" type="hidden" name="hdnDEL_4" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="162" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="163" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="164" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="165" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="166" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="167" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="168" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="169" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="170" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="171" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="172" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="173" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="174" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="175" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_5">
                    <td>
                        <asp:textbox id="txtNo_5" value="05" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_5" tabIndex="181" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_5" type="hidden" name="hdnDEL_5" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="182" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="183" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="184" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="185" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="186" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="187" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="188" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="189" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="190" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="191" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="192" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="193" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="194" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="195" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_6">
                    <td>
                        <asp:textbox id="txtNo_6" value="06" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_6" tabIndex="201" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_6" type="hidden" name="hdnDEL_6" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="202" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="203" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="204" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="205" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="206" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="207" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="208" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="209" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="210" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="211" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="212" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="213" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="214" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="215" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_7">
                    <td>
                        <asp:textbox id="txtNo_7" value="07" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_7" tabIndex="221" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_7" type="hidden" name="hdnDEL_7" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="222" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="223" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="224" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="225" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="226" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="227" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="228" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="229" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="230" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="231" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="232" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="233" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="234" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="235" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_8">
                    <td>
                        <asp:textbox id="txtNo_8" value="08" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_8" tabIndex="241" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_8" type="hidden" name="hdnDEL_8" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="242" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="243" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="244" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="245" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="246" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="247" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="248" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="249" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="250" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="251" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="252" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="253" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="254" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="255" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_9">
                    <td>
                        <asp:textbox id="txtNo_9" value="09" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_9" tabIndex="261" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_9" type="hidden" name="hdnDEL_9" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="262" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="263" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="264" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="265" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="266" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="267" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="268" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="269" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="270" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="271" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="272" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="273" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="274" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="275" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_10">
                    <td>
                        <asp:textbox id="txtNo_10" value="10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_10" tabIndex="281" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_10" type="hidden" name="hdnDEL_10" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="282" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="283" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="284" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="285" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="286" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="287" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="288" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="289" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="290" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="291" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="292" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="293" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="294" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="295" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_11">
                    <td>
                        <asp:textbox id="txtNo_11" value="11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_11" tabIndex="301" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_11" type="hidden" name="hdnDEL_11" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="302" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="303" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="304" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="305" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="306" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="307" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="308" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="309" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="310" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="311" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="312" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="313" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="314" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="315" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_12">
                    <td>
                        <asp:textbox id="txtNo_12" value="12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_12" tabIndex="321" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_12" type="hidden" name="hdnDEL_12" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="322" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="323" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="324" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="325" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="326" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="327" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="328" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="329" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="330" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="331" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="332" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="334" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="335" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="336" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_13">
                    <td>
                        <asp:textbox id="txtNo_13" value="13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_13" tabIndex="341" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_13" type="hidden" name="hdnDEL_13" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="342" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="343" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="344" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="345" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="346" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="347" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="348" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="349" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="350" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="351" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="352" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="353" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="354" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="355" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_14">
                    <td>
                        <asp:textbox id="txtNo_14" value="14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_14" tabIndex="361" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_14" type="hidden" name="hdnDEL_14" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="362" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="363" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="364" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="365" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="366" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="367" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="368" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="369" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="370" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="371" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="372" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="373" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="374" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="375" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_15">
                    <td>
                        <asp:textbox id="txtNo_15" value="15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_15" tabIndex="381" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_15" type="hidden" name="hdnDEL_15" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="382" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="383" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="384" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="385" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="386" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="387" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="388" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="389" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="390" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="391" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="392" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="393" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="394" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtBIKO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="395" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_16">
                    <td>
                        <asp:textbox id="txtNo_16" value="16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_16" tabIndex="401" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_16" type="hidden" name="hdnDEL_16" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="402" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="403" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="404" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="405" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="406" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="407" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="408" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="409" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="410" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="411" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="412" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="413" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="414" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="415" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_17">
                    <td>
                        <asp:textbox id="txtNo_17" value="17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_17" tabIndex="421" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_17" type="hidden" name="hdnDEL_17" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="422" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="423" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="424" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="425" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="426" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="427" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="428" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="429" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="430" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="431" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="432" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="433" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="434" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="435" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_18">
                    <td>
                        <asp:textbox id="txtNo_18" value="18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_18" tabIndex="441" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_18" type="hidden" name="hdnDEL_18" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="442" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="443" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="444" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="445" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="446" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="447" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="448" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="449" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="450" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="451" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="452" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="453" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="454" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="455" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_19">
                    <td>
                        <asp:textbox id="txtNo_19" value="19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_19" tabIndex="461" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_19" type="hidden" name="hdnDEL_19" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="462" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="463" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="464" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="465" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="466" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="467" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="468" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="469" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="470" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="471" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="472" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="476" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="474" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="475" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_20">
                    <td>
                        <asp:textbox id="txtNo_20" value="20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_20" tabIndex="481" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_20" type="hidden" name="hdnDEL_20" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="482" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="483" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="484" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="485" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="486" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="487" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="488" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="489" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="490" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="491" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="492" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="493" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="494" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="495" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_21">
                    <td>
                        <asp:textbox id="txtNo_21" value="21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_21" tabIndex="501" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_21" type="hidden" name="hdnDEL_21" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="502" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="503" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="504" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="505" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="506" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="507" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="508" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="509" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="510" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="511" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="512" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="513" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="514" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="515" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_22">
                    <td>
                        <asp:textbox id="txtNo_22" value="22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_22" tabIndex="521" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_22" type="hidden" name="hdnDEL_22" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="522" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="523" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="524" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="525" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="526" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="527" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="528" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="529" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="530" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="531" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="532" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="533" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="534" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="535" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_23">
                    <td>
                        <asp:textbox id="txtNo_23" value="23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_23" tabIndex="541" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_23" type="hidden" name="hdnDEL_23" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="542" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="543" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="544" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="545" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="546" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="547" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="548" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="549" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="550" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="551" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="552" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="553" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="554" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="555" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_24">
                    <td>
                        <asp:textbox id="txtNo_24" value="24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_24" tabIndex="561" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_24" type="hidden" name="hdnDEL_24" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="562" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="563" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="564" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="565" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="566" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="567" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="568" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="569" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="570" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="571" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="572" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="573" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="574" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="575" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_25">
                    <td>
                        <asp:textbox id="txtNo_25" value="25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_25" tabIndex="581" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_25" type="hidden" name="hdnDEL_25" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="582" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="583" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="584" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="585" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="586" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="587" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="588" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="589" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="590" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="591" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="592" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="593" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="594" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="595" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_26">
                    <td>
                        <asp:textbox id="txtNo_26" value="26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_26" tabIndex="601" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_26" type="hidden" name="hdnDEL_26" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="602" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="603" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="604" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="605" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="606" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="607" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="608" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="609" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="610" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="611" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="612" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="613" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="614" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="615" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_27">
                    <td>
                        <asp:textbox id="txtNo_27" value="27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_27" tabIndex="621" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_27" type="hidden" name="hdnDEL_27" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="622" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="623" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="624" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="625" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="626" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="627" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="628" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="629" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="630" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="631" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="632" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="633" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="634" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="635" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_28">
                    <td>
                        <asp:textbox id="txtNo_28" value="28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_28" tabIndex="641" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_28" type="hidden" name="hdnDEL_28" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="642" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="643" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="644" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="645" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="646" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="647" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="648" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="649" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="650" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="651" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="652" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="653" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="654" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="655" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_29">
                    <td>
                        <asp:textbox id="txtNo_29" value="29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_29" tabIndex="661" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_29" type="hidden" name="hdnDEL_29" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="662" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="663" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="664" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="665" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="666" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="667" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="668" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="669" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="670" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="671" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="672" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="673" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="674" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="675" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_30">
                    <td>
                        <asp:textbox id="txtNo_30" value="30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:checkbox id="chkDEL_30" tabIndex="681" runat="server" Width="26px" onkeydown="fncFc(this)" />
                        <input id="hdnDEL_30" type="hidden" name="hdnDEL_30" runat="server" />
                    </td>
					<td>
                        <asp:textbox id="txtKMCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="682" runat="server" CssClass="c-h" Width="80px" MaxLength="2"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtKMNM_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="683" runat="server" CssClass="c-hI" Width="250px" MaxLength="15"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboPROCKBN_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="684" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAIOKBN_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="685" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTMSKB_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="686" runat="server" width="100px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTKTANCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="687" runat="server" CssClass="c-f" Width="80px" MaxLength="3"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTAITCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="688" runat="server" width="220px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTFKICD_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="689" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTKIGCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="690" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTSADCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="691" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboTELRCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                    tabindex="692" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo>
                    </td>
                    <td>
                        <asp:textbox id="txtTEL_MEMO1_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="693" runat="server" CssClass="c-fI" Width="400px" MaxLength="50"></asp:textbox>
                    </td>
                    <td>
                        <cc1:ctlcombo id="cboUSE_FLG_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
		                    tabindex="694" runat="server" width="100px" cssclass="cb-h"></cc1:ctlcombo>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="695" runat="server" CssClass="c-fI" Width="400px" MaxLength="500"></asp:textbox>
                    </td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
