<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSHAGJAG00.aspx.vb" Inherits="MSHAGJAG00.MSHAGJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSHAGJAG00</title>
	</HEAD>
		<% 
'***********************************************
		    ' 販売事業者グループマスタ  画面
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
			<table cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellspacing="2" cellpadding="0" width="900">
							<tr>
								<td width="*"><input class="bt-JIK" id="btnSelect" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();"
										tabindex="9001" type="button" value="検索" name="btnSelect" runat="server" />
								</td>
								<td width="300">&nbsp;</td>
								<td width="220"><input class="bt-JIK" id="btnUpdate" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnUpdate_onclick();"
										tabindex="9002" type="button" value="登録" name="btnUpdate" runat="server" />
								</td>
								<td width="220"><input class="bt-JIK" id="btnDelete" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnDelete_onclick();"
										tabindex="9003" type="button" value="削除" name="btnDelete" runat="server" />
								</td>
								<td width="70"><input class="bt-JIK" id="btnClear" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnClear_onclick();"
										tabindex="9005" type="button" value="取消" name="btnClear" runat="server" />
								</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
										tabindex="9006" type="button" value="終了" name="btnExit" runat="server" />
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
						<table cellspacing="0" cellpadding="0" width="900">
							<tr>
								<td width="20"></td>
								<td vAlign="middle" width="710">
									<table cellspacing="0" cellpadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">販売事業者グループマスタ</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="170">
								</td>
							</tr>
						</table>
						<input id="hdnKBN" type="hidden" name="hdnKBN" runat="server"  />
					</td>
				</tr>
			</table>
			<hr>
            <table cellspacing="1" cellpadding="3" width="1300">
				<tr>
					<td width="5">&nbsp;</td>
					<td width="125" align="right" style="font-size:15px;">クライアントコード&nbsp;&nbsp;</td>
                    <td width="350" >
                        <asp:textbox id="txtKURACD" tabindex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"	BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabindex="1" type="button" value="▼" name="btnKURACD" runat="server" />
                        <input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server" />
						<input id="hdnKURACD_MOTO" type="hidden" name="hdnKURACD_MOTO" runat="server" />
					</td>
					<td width="330">
					</td>
					<td width="140"></td>
					<td width="140"></td>
                    <td width="140">
                        <a href="MSHAGJAG00.pdf" target="_blank" tabindex="5"><img src="../../../Script/icon_pdf.gif" border="0" alt="img" />マニュアル&nbsp;&nbsp;</a>
                    </td>
                    <td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td align="right" style="font-size:12px;">グループコード・名称&nbsp;&nbsp;</td>
                    <td colspan="4">
                        <asp:textbox id="txtGROUPCD_F" tabindex="-1" runat="server" CssClass="c-rNM" Width="430px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnGROUPCD_F" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabindex="2" type="button" value="▼" name="btnGROUPCD_F" runat="server" />&nbsp;～&nbsp;
                        <input id="hdnGROUPCD_F" type="hidden" name="hdnGROUPCD_F" runat="server" />
						<input id="hdnGROUPCD_F_MOTO" type="hidden" name="hdnGROUPCD_F_MOTO" runat="server" />
                        <asp:textbox id="txtGROUPCD_T" tabindex="-1" runat="server" CssClass="c-rNM" Width="430px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnGROUPCD_T" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabindex="3" type="button" value="▼" name="btnGROUPCD_T" runat="server" />
                        <input id="hdnGROUPCD_T" type="hidden" name="hdnGROUPCD_T" runat="server" />
						<input id="hdnGROUPCD_T_MOTO" type="hidden" name="hdnGROUPCD_T_MOTO" runat="server" />
                    </td>
                    <td>
                        <input language="javascript" class="bt-RNW" id="btnCSVOUT" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnCsv_onclick();" tabindex="4" type="button"
							value="データ出力" name="btnCSVOUT" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
			</table>
            <hr>
            <table>
                <tr>
                    <td width="80">
						<input type="button" name="AllSelect" value="全て選択" onclick="btnCheckBtn(1);" id="btnAllSelect" tabindex="51" />
					</td>
                    <td width="80">
						<input type="button" name="AllRemove" value="全て解除" onclick="btnCheckBtn(2);" id="btnAllRemove" tabindex="52" />
					</td>
					<td width="790" align="right"><font color="red">表示件数：最大100件</font></td>
                </tr>
            </table>
			<input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server" />
			<table cellspacing="0" cellpadding="0">
				<tr>
				    <td align="center" height="25" style="font-size:15px">№</td>
				    <td align="center" height="25" style="font-size:15px">対象</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;グループコード</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;グループコード名</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;販売事業者名</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;備考</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;登録日時</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;登録者</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;更新日時</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;更新者</td>
				</tr>
				<tr id="list_1">
                    <%-- .NET 使用変更により、ReadOnlyはVB側でAttributeでつける --%>
                    <td>
                        <asp:textbox id="txtNO_1" value="001" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_1" tabIndex="1001" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1002" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1003" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1004" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1005" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_1" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_1" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_1" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_1" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_2">
                    <td>
                        <asp:textbox id="txtNO_2" value="002" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_2" tabIndex="1011" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1012" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1013" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1014" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1015" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_2" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_2" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_2" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_2" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_3">
                    <td>
                        <asp:textbox id="txtNO_3" value="003" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_3" tabindex="1021" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1022" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1023" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1024" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1025" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_3" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_3" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_3" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_3" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_4">
                    <td>
                        <asp:textbox id="txtNO_4" value="004" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_4" tabindex="1031" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1032" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1033" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1034" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1035" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_4" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_4" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_4" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_4" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_5">
                    <td>
                        <asp:textbox id="txtNO_5" value="005" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_5" tabindex="1041" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1042" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1043" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1044" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1045" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_5" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_5" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_5" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_5" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_6">
                    <td>
                        <asp:textbox id="txtNO_6" value="006" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_6" tabindex="1051" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1052" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1053" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1054" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1055" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_6" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_6" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_6" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_6" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_7">
                    <td>
                        <asp:textbox id="txtNO_7" value="007" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_7" tabindex="1061" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1062" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1063" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1064" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1065" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_7" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_7" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_7" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_7" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_8">
                    <td>
                        <asp:textbox id="txtNO_8" value="008" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_8" tabindex="1071" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1072" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1073" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1074" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1075" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_8" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_8" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_8" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_8" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_9">
                    <td>
                        <asp:textbox id="txtNO_9" value="009" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_9" tabindex="1081" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1082" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1083" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1084" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1085" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_9" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_9" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_9" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_9" onkeydown="fncFc(this)"	tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_10">
                    <td>
                        <asp:textbox id="txtNO_10" value="010" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_10" tabindex="1091" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1092" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1093" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1094" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1095" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_10" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_10" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_10" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_10" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_11">
                    <td>
                        <asp:textbox id="txtNO_11" value="011" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_11" tabindex="1101" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1102" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1103" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1104" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1105" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_11" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_11" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_11" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_11" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_12">
                    <td>
                        <asp:textbox id="txtNO_12" value="012" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_12" tabindex="1111" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1112" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1113" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1114" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1115" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_12" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_12" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_12" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_12" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_13">
                    <td>
                        <asp:textbox id="txtNO_13" value="013" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_13" tabindex="1121" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1122" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1123" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1124" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1125" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_13" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_13" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_13" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_13" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_14">
                    <td>
                        <asp:textbox id="txtNO_14" value="014" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_14" tabindex="1131" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1132" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1133" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1134" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1135" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_14" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_14" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_14" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_14" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_15">
                    <td>
                        <asp:textbox id="txtNO_15" value="015" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_15" tabindex="1141" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1142" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1143" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1144" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1145" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_15" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_15" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_15" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_15" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_16">
                    <td>
                        <asp:textbox id="txtNO_16" value="016" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_16" tabindex="1151" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1152" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1153" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1154" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1155" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_16" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_16" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_16" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_16" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_17">
                    <td>
                        <asp:textbox id="txtNO_17" value="017" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_17" tabindex="1161" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1162" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1163" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1164" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1165" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_17" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_17" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_17" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_17" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_18">
                    <td>
                        <asp:textbox id="txtNO_18" value="018" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_18" tabindex="1171" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1172" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1173" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1174" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1175" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_18" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_18" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_18" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_18" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_19">
                    <td>
                        <asp:textbox id="txtNO_19" value="019" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_19" tabindex="1181" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1182" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1183" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1184" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1185" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_19" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_19" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_19" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_19" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_20">
                    <td>
                        <asp:textbox id="txtNO_20" value="020" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_20" tabindex="1191" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1192" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1193" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1194" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1195" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_20" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_20" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_20" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_20" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_21">
                    <td>
                        <asp:textbox id="txtNO_21" value="021" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_21" tabindex="1201" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1202" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1203" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1204" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1205" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_21" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_21" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_21" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_21" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_22">
                    <td>
                        <asp:textbox id="txtNO_22" value="022" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_22" tabindex="1211" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1212" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1213" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1214" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1215" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_22" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_22" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_22" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_22" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_23">
                    <td>
                        <asp:textbox id="txtNO_23" value="023" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_23" tabindex="1221" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1222" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1223" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1224" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1225" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_23" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_23" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_23" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_23" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_24">
                    <td>
                        <asp:textbox id="txtNO_24" value="024" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_24" tabindex="1231" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1232" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1233" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1234" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1235" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_24" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_24" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_24" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_24" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_25">
                    <td>
                        <asp:textbox id="txtNO_25" value="025" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_25" tabindex="1241" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1242" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1243" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1244" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1245" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_25" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_25" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_25" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_25" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_26">
                    <td>
                        <asp:textbox id="txtNO_26" value="026" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_26" tabindex="1251" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1252" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1253" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1254" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1255" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_26" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_26" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_26" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_26" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_27">
                    <td>
                        <asp:textbox id="txtNO_27" value="027" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_27" tabindex="1261" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1262" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1263" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1264" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1265" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_27" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_27" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_27" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_27" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_28">
                    <td>
                        <asp:textbox id="txtNO_28" value="028" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_28" tabindex="1271" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1272" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1273" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1274" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1275" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_28" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_28" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_28" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_28" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_29">
                    <td>
                        <asp:textbox id="txtNO_29" value="029" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_29" tabindex="1281" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1282" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1283" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1284" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1285" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_29" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_29" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_29" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_29" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_30">
                    <td>
                        <asp:textbox id="txtNO_30" value="030" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_30" tabindex="1291" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1292" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1293" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1294" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1295" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_30" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_30" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_30" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_30" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_31">
                    <td>
                        <asp:textbox id="txtNO_31" value="031" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_31" tabindex="1301" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1302" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1303" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1304" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1305" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_31" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_31" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_31" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_31" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_32">
                    <td>
                        <asp:textbox id="txtNO_32" value="032" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_32" tabindex="1311" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1312" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1313" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1314" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1315" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_32" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_32" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_32" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_32" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_33">
                    <td>
                        <asp:textbox id="txtNO_33" value="033" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_33" tabindex="1321" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1322" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1323" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1324" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1325" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_33" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_33" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_33" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_33" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_34">
                    <td>
                        <asp:textbox id="txtNO_34" value="034" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_34" tabindex="1331" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1332" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1333" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1334" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1335" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_34" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_34" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_34" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_34" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_35">
                    <td>
                        <asp:textbox id="txtNO_35" value="035" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_35" tabindex="1341" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1342" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1343" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1344" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1345" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_35" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_35" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_35" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_35" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_36">
                    <td>
                        <asp:textbox id="txtNO_36" value="036" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_36" tabindex="1351" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1352" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1353" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1354" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1355" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_36" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_36" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_36" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_36" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_37">
                    <td>
                        <asp:textbox id="txtNO_37" value="037" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_37" tabindex="1361" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1362" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1363" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1364" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1365" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_37" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_37" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_37" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_37" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_38">
                    <td>
                        <asp:textbox id="txtNO_38" value="038" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_38" tabindex="1371" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1372" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1373" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1374" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1375" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_38" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_38" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_38" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_38" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_39">
                    <td>
                        <asp:textbox id="txtNO_39" value="039" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_39" tabindex="1381" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1382" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1383" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1384" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1385" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_39" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_39" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_39" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_39" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_40">
                    <td>
                        <asp:textbox id="txtNO_40" value="040" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_40" tabindex="1391" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1392" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1393" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1394" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1395" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_40" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_40" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_40" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_40" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_41">
                    <td>
                        <asp:textbox id="txtNO_41" value="041" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_41" tabindex="1401" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1402" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1403" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1404" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1405" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_41" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_41" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_41" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_41" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_42">
                    <td>
                        <asp:textbox id="txtNO_42" value="042" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_42" tabindex="1411" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1412" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1413" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1414" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1415" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_42" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_42" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_42" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_42" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_43">
                    <td>
                        <asp:textbox id="txtNO_43" value="043" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_43" tabindex="1421" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1422" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1423" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1424" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1425" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_43" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_43" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_43" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_43" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_44">
                    <td>
                        <asp:textbox id="txtNO_44" value="044" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_44" tabindex="1431" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1432" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1433" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1434" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1435" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_44" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_44" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_44" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_44" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_45">
                    <td>
                        <asp:textbox id="txtNO_45" value="045" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_45" tabindex="1441" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1442" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1443" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1444" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1445" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_45" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_45" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_45" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_45" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_46">
                    <td>
                        <asp:textbox id="txtNO_46" value="046" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_46" tabindex="1451" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1452" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1453" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1454" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1455" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_46" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_46" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_46" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_46" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_47">
                    <td>
                        <asp:textbox id="txtNO_47" value="047" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_47" tabindex="1461" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1462" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1463" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1464" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1465" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_47" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_47" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_47" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_47" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_48">
                    <td>
                        <asp:textbox id="txtNO_48" value="048" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_48" tabindex="1471" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1472" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1473" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1474" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1475" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_48" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_48" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_48" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_48" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_49">
                    <td>
                        <asp:textbox id="txtNO_49" value="049" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_49" tabindex="1481" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1482" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1483" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1484" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1485" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_49" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_49" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_49" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_49" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_50">
                    <td>
                        <asp:textbox id="txtNO_50" value="050" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_50" tabindex="1491" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1492" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1493" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1494" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1495" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_50" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_50" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_50" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_50" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_51">
                    <td>
                        <asp:textbox id="txtNO_51" value="051" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_51" tabindex="1501" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_51" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1502" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_51" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1503" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_51" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1504" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_51" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1505" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_51" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_51" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_51" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_51" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_52">
                    <td>
                        <asp:textbox id="txtNO_52" value="052" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_52" tabindex="1511" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_52" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1512" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_52" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1513" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_52" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1514" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_52" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1515" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_52" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_52" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_52" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_52" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_53">
                    <td>
                        <asp:textbox id="txtNO_53" value="053" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_53" tabindex="1521" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_53" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1522" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_53" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1523" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_53" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1524" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_53" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1525" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_53" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_53" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_53" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_53" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_54">
                    <td>
                        <asp:textbox id="txtNO_54" value="054" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_54" tabindex="1531" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_54" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1532" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_54" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1533" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_54" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1534" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_54" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1535" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_54" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_54" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_54" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_54" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_55">
                    <td>
                        <asp:textbox id="txtNO_55" value="055" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_55" tabindex="1541" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_55" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1542" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_55" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1543" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_55" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1544" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_55" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1545" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_55" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_55" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_55" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_55" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_56">
                    <td>
                        <asp:textbox id="txtNO_56" value="056" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_56" tabindex="1551" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_56" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1552" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_56" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1553" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_56" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1554" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_56" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1555" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_56" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_56" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_56" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_56" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_57">
                    <td>
                        <asp:textbox id="txtNO_57" value="057" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_57" tabindex="1561" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_57" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1562" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_57" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1563" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_57" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1564" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_57" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1565" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_57" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_57" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_57" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_57" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_58">
                    <td>
                        <asp:textbox id="txtNO_58" value="058" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_58" tabindex="1571" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_58" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1572" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_58" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1573" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_58" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1574" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_58" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1575" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_58" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_58" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_58" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_58" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_59">
                    <td>
                        <asp:textbox id="txtNO_59" value="059" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_59" tabindex="1581" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_59" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1582" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_59" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1583" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_59" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1584" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_59" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1585" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_59" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_59" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_59" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_59" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_60">
                    <td>
                        <asp:textbox id="txtNO_60" value="060" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_60" tabindex="1591" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_60" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1592" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_60" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1593" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_60" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1594" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_60" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1595" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_60" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_60" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_60" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_60" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_61">
                    <td>
                        <asp:textbox id="txtNO_61" value="061" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_61" tabindex="1601" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_61" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1602" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_61" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1603" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_61" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1604" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_61" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1605" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_61" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_61" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_61" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_61" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_62">
                    <td>
                        <asp:textbox id="txtNO_62" value="062" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_62" tabindex="1611" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_62" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1612" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_62" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1613" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_62" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1614" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_62" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1615" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_62" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_62" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_62" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_62" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_63">
                    <td>
                        <asp:textbox id="txtNO_63" value="063" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_63" tabindex="1621" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_63" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1622" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_63" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1623" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_63" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1624" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_63" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1625" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_63" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_63" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_63" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_63" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_64">
                    <td>
                        <asp:textbox id="txtNO_64" value="064" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_64" tabindex="1631" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_64" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1632" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_64" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1633" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_64" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1634" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_64" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1635" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_64" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_64" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_64" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_64" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_65">
                    <td>
                        <asp:textbox id="txtNO_65" value="065" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_65" tabindex="1641" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_65" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1642" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_65" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1643" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_65" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1644" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_65" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1645" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_65" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_65" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_65" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_65" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_66">
                    <td>
                        <asp:textbox id="txtNO_66" value="066" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_66" tabindex="1651" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_66" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1652" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_66" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1653" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_66" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1654" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_66" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1655" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_66" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_66" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_66" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_66" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_67">
                    <td>
                        <asp:textbox id="txtNO_67" value="067" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_67" tabindex="1661" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_67" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1662" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_67" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1663" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_67" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1664" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_67" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1665" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_67" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_67" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_67" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_67" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_68">
                    <td>
                        <asp:textbox id="txtNO_68" value="068" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_68" tabindex="1671" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_68" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1672" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_68" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1673" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_68" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1674" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_68" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1675" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_68" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_68" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_68" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_68" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_69">
                    <td>
                        <asp:textbox id="txtNO_69" value="069" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_69" tabindex="1681" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_69" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1682" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_69" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1683" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_69" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1684" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_69" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1685" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_69" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_69" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_69" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_69" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_70">
                    <td>
                        <asp:textbox id="txtNO_70" value="070" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_70" tabindex="1691" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_70" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1692" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_70" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1693" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_70" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1694" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_70" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1695" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_70" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_70" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_70" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_70" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_71">
                    <td>
                        <asp:textbox id="txtNO_71" value="071" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_71" tabindex="1701" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_71" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1702" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_71" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1703" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_71" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1704" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_71" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1705" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_71" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_71" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_71" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_71" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_72">
                    <td>
                        <asp:textbox id="txtNO_72" value="072" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_72" tabindex="1711" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_72" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1712" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_72" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1713" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_72" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1714" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_72" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1715" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_72" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_72" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_72" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_72" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_73">
                    <td>
                        <asp:textbox id="txtNO_73" value="073" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_73" tabindex="1721" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_73" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1722" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_73" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1723" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_73" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1724" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_73" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1725" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_73" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_73" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_73" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_73" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_74">
                    <td>
                        <asp:textbox id="txtNO_74" value="074" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_74" tabindex="1731" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_74" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1732" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_74" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1733" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_74" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1734" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_74" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1735" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_74" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_74" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_74" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_74" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_75">
                    <td>
                        <asp:textbox id="txtNO_75" value="075" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_75" tabindex="1741" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_75" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1742" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_75" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1743" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_75" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1744" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_75" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1745" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_75" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_75" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_75" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_75" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_76">
                    <td>
                        <asp:textbox id="txtNO_76" value="076" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_76" tabindex="1751" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_76" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1752" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_76" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1753" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_76" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1754" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_76" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1755" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_76" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_76" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_76" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_76" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_77">
                    <td>
                        <asp:textbox id="txtNO_77" value="077" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_77" tabindex="1761" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_77" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1762" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_77" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1763" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_77" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1764" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_77" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1765" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_77" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_77" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_77" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_77" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_78">
                    <td>
                        <asp:textbox id="txtNO_78" value="078" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_78" tabindex="1771" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_78" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1772" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_78" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1773" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_78" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1774" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_78" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1775" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_78" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_78" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_78" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_78" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_79">
                    <td>
                        <asp:textbox id="txtNO_79" value="079" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_79" tabindex="1781" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_79" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1782" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_79" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1783" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_79" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1784" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_79" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1785" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_79" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_79" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_79" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_79" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_80">
                    <td>
                        <asp:textbox id="txtNO_80" value="080" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_80" tabindex="1791" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_80" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1792" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_80" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1793" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_80" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1794" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_80" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1795" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_80" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_80" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_80" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_80" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_81">
                    <td>
                        <asp:textbox id="txtNO_81" value="081" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_81" tabindex="1801" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_81" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1802" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_81" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1803" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_81" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1804" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_81" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1805" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_81" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_81" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_81" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_81" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_82">
                    <td>
                        <asp:textbox id="txtNO_82" value="082" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_82" tabindex="1811" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_82" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1812" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_82" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1813" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_82" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1814" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_82" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1815" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_82" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_82" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_82" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_82" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_83">
                    <td>
                        <asp:textbox id="txtNO_83" value="083" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_83" tabindex="1821" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_83" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1822" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_83" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1823" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_83" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1824" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_83" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1825" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_83" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_83" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_83" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_83" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_84">
                    <td>
                        <asp:textbox id="txtNO_84" value="084" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_84" tabindex="1831" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_84" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1832" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_84" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1833" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_84" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1834" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_84" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1835" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_84" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_84" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_84" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_84" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_85">
                    <td>
                        <asp:textbox id="txtNO_85" value="085" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_85" tabindex="1841" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_85" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1842" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_85" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1843" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_85" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1844" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_85" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1845" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_85" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_85" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_85" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_85" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_86">
                    <td>
                        <asp:textbox id="txtNO_86" value="086" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_86" tabindex="1851" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_86" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1852" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_86" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1853" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_86" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1854" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_86" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1855" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_86" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_86" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_86" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_86" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_87">
                    <td>
                        <asp:textbox id="txtNO_87" value="087" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_87" tabindex="1861" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_87" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1862" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_87" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1863" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_87" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1864" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_87" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1865" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_87" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_87" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_87" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_87" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_88">
                    <td>
                        <asp:textbox id="txtNO_88" value="088" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_88" tabindex="1871" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_88" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1872" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_88" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1873" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_88" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1874" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_88" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1875" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_88" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_88" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_88" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_88" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_89">
                    <td>
                        <asp:textbox id="txtNO_89" value="089" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_89" tabindex="1881" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_89" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1882" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_89" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1883" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_89" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1884" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_89" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1885" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_89" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_89" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_89" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_89" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_90">
                    <td>
                        <asp:textbox id="txtNO_90" value="090" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_90" tabindex="1891" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_90" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1892" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_90" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1893" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_90" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1894" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_90" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1895" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_90" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_90" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_90" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_90" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_91">
                    <td>
                        <asp:textbox id="txtNO_91" value="091" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_91" tabindex="1901" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_91" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1902" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_91" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1903" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_91" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1904" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_91" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1905" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_91" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_91" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_91" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_91" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_92">
                    <td>
                        <asp:textbox id="txtNO_92" value="092" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_92" tabindex="1911" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_92" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1912" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_92" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1913" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_92" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1914" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_92" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1915" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_92" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_92" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_92" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_92" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_93">
                    <td>
                        <asp:textbox id="txtNO_93" value="093" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_93" tabindex="1921" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_93" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1922" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_93" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1923" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_93" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1924" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_93" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1925" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_93" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_93" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_93" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_93" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_94">
                    <td>
                        <asp:textbox id="txtNO_94" value="094" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_94" tabindex="1931" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_94" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1932" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_94" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1933" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_94" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1934" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_94" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1935" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_94" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_94" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_94" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_94" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_95">
                    <td>
                        <asp:textbox id="txtNO_95" value="095" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_95" tabindex="1941" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_95" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1942" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_95" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1943" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_95" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1944" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_95" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1945" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_95" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_95" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_95" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_95" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_96">
                    <td>
                        <asp:textbox id="txtNO_96" value="096" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_96" tabindex="1951" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_96" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1952" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_96" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1953" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_96" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1954" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_96" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1955" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_96" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_96" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_96" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_96" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_97">
                    <td>
                        <asp:textbox id="txtNO_97" value="097" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_97" tabindex="1961" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_97" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1962" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_97" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1963" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_97" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1964" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_97" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1965" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_97" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_97" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_97" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_97" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_98">
                    <td>
                        <asp:textbox id="txtNO_98" value="098" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_98" tabindex="1971" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_98" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1972" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_98" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1973" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_98" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1974" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_98" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1975" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_98" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_98" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_98" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_98" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_99">
                    <td>
                        <asp:textbox id="txtNO_99" value="099" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_99" tabindex="1981" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_99" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1982" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_99" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1983" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_99" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1984" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_99" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1985" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_99" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_99" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_99" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_99" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
				<tr id="list_100">
                    <td>
                        <asp:textbox id="txtNO_100" value="100" tabIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_100" tabindex="1991" runat="server" Width="34px" onkeydown="fncFc(this)" />
                    </td>
					<td>
                        <asp:textbox id="txtGROUPCD_100" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1992" runat="server" CssClass="c-h" Width="320px" MaxLength="30"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtGROUPNM_100" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1993" runat="server" CssClass="c-hI" Width="540px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtHANJIGYOSYANM_100" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1994" runat="server" CssClass="c-hI" Width="350px" MaxLength="60"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_100" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1995" runat="server" CssClass="c-fI" Width="200px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_100" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_100" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_100" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_100" onkeydown="fncFc(this)" tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
			</table>
		</form>
		<script type="text/javascript">

		</script>
	</body>
</HTML>
