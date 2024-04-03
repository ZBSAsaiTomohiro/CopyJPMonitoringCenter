<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSJAGJAG00.aspx.vb" Inherits="MSJAGJAG00.MSJAGJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSJAGJAG00</title>
	    <style type="text/css">
        </style>
	</HEAD>
		<% 
'***********************************************
		    ' JAグループ作成マスタ  画面
'***********************************************
' 変更履歴	    
%>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server" />
			<input id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server" />
			<input id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server" />
			<input id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server" />
			<br />
			<table cellspacing="0" cellpadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellspacing="2" cellpadding="0" width="900">
							<tr>
								<td width="*">
	                                <input class="bt-JIK" id="btnSelect" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabindex="9001" type="button" value="検索" name="btnSelect" runat="server" />
								</td>
								<td width="300">&nbsp;</td>
								<td width="220">
									<input class="bt-JIK" id="btnUpdate" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnUpdate_onclick();" tabindex="9002" type="button" value="登録" name="btnUpdate" runat="server" />
								</td>
								<td width="220">
									<input class="bt-JIK" id="btnDelete" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnDelete_onclick();" tabindex="9003" type="button" value="削除" name="btnDelete" runat="server" />
								</td>
								<td width="70">
									<input class="bt-JIK" id="btnClear" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnClear_onclick();" tabindex="9005" type="button" value="取消" name="btnClear" runat="server" />
								</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80">
									<input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();" tabindex="9006" type="button" value="終了" name="btnExit" runat="server" />
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
											<td class="TITLE" vAlign="middle">ＪＡグループ作成マスタ</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<input id="hdnKBN" type="hidden" name="hdnKBN" runat="server"  />
					</td>
				</tr>
			</table>
			<hr>
            <table cellspacing="1" cellpadding="3" width="1150">
                <tr>
                    <td width="5">&nbsp;</td>
					<td width="125" class="TXTKY" align="right" style="font-size:15px;">区分&nbsp;&nbsp;</td>
                    <td width="350" ><cc1:ctlcombo id="cboJAGKBN" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onchange="fncChengJAGKBN(),fncSetFocus(),fncChgUserCdTxt()"
		                        tabindex="1" runat="server" width="200px" cssclass="cb"></cc1:ctlcombo>
                        <input id="hdnJAGKBN" type="hidden" name="hdnJAGKBN" runat="server" />
						<input id="hdnJAGKBN_MOTO" type="hidden" name="hdnJAGKBN_MOTO" runat="server" />
                    </td>
					<td width="330">
					</td>
					<td width="140">
                        <a href="MSJAGJAG00.pdf" target="_blank" tabindex="10"><img src="../../../Script/icon_pdf.gif" border="0" alt="img" />マニュアル&nbsp;&nbsp;</a>
					</td>
					<td>&nbsp;</td>
                </tr>
				<tr>
					<td>&nbsp;</td>
					<td class="TXTKY" align="right" style="font-size:15px;">クライアントコード&nbsp;&nbsp;</td>
                    <td>
                        <asp:textbox id="txtKURACD" tabindex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"	BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabindex="2" type="button" value="▼" name="btnKURACD" runat="server" />
                        <input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server" />
						<input id="hdnKURACD_MOTO" type="hidden" name="hdnCODE_MOTO" runat="server" />
					</td>
					<td>
					</td>
					<td>
					</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td class="TXTKY" align="right" style="font-size:15px;">JA支所コード&nbsp;&nbsp;</td>
                    <td>
                        <asp:textbox id="txtACBCD_F" tabindex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnACBCD_F" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabindex="3" type="button" value="▼" name="btnACBCD_F" runat="server" />&nbsp;～
                        <input id="hdnACBCD_F" type="hidden" name="hdnACBCD_F" runat="server" />
						<input id="hdnACBCD_F_MOTO" type="hidden" name="hdnACBCD_F_MOTO" runat="server" />
					</td>
                    <td>
                        <asp:textbox id="txtACBCD_T" tabindex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnACBCD_T" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabindex="4" type="button" value="▼" name="btnACBCD_T" runat="server" />
                        <input id="hdnACBCD_T" type="hidden" name="hdnACBCD_T" runat="server" />
						<input id="hdnACBCD_T_MOTO" type="hidden" name="hdnACBCD_T_MOTO" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
					<td class="TXTKY" align="right" style="font-size:12px;">グループコード・名称&nbsp;&nbsp;</td>
                    <td colspan="2">
                        <asp:textbox id="txtGROUPCD" tabindex="-1" runat="server" CssClass="c-rNM" Width="430px" BorderStyle="Solid" BorderWidth="1px">
                        </asp:textbox><input class="bt-KS" id="btnGROUPCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('4');"
							tabindex="5" type="button" value="▼" name="btnACBCD_T" runat="server" />
                        <input id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server" />
						<input id="hdnGROUPCD_MOTO" type="hidden" name="hdnGROUPCD_MOTO" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
					<td align="right" style="font-size:15px;">出力&nbsp;&nbsp;</td>
                    <td>								
                        <input id="chkSYU_TOUROKU" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
						    tabindex="6" type="checkbox" name="chkSYU_TOUROKU" runat="server" checked />
						<label for="chkSYU_TOUROKU" style="font-size:15px;">登録分&nbsp;&nbsp;</label>
                        <input id="chkSYU_MITOUROKU" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
						    tabindex="7" type="checkbox" name="chkSYU_MITOUROKU" runat="server" checked />
						<label for="chkSYU_MITOUROKU" style="font-size:15px;">未登録分</label>
                    </td>
                    <td align="right">
                        <input language="javascript" class="bt-RNW" id="btnIKKATU" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnIKKATU_onclick();" tabindex="8" type="button"
							value="一括登録" name="btnIKKATU" runat="server" />
                    </td>
                    <td>
                        <input language="javascript" class="bt-RNW" id="btnCSVOUT" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnCSVOUT_onclick();" tabindex="9" type="button"
							value="データ出力" name="btnCSVOUT" runat="server" />
                    </td>
                </tr>
                <tr><td></td></tr>
			</table>
            <div style="background-color:#edffdb; border-top: 1px dashed gray; border-bottom: 1px dashed gray;" >
            <table  cellspacing="1" cellpadding="3" width="1300">
                <tr>
                <td width="5"></td>
                <td width="125"></td>
                <td width="350"></td>
                <td width="125"></td>
                <td width="460"></td>
                <td width="200"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
					<td align="right" style="font-size:12px;">グループコード&nbsp;&nbsp;<br />(新規登録用)&nbsp;&nbsp;</td>
                    <td><asp:textbox id="txtGROUPCD_NEW" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="21" runat="server" CssClass="c-f" Width="320px" MaxLength="30"></asp:textbox>
                            <input id="hdnReadOnlyFlg" type="hidden" name="hdnDisableFlg" runat="server" />
                    </td>
                    <td align="right" style="font-size:12px;">グループコード名&nbsp;&nbsp;<br />(新規登録、更新用)&nbsp;&nbsp;</td>
                    <td colspan="2"><asp:textbox id="txtGROUPNM_NEW" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="22" runat="server" CssClass="c-fI" Width="540px" MaxLength="60"></asp:textbox>
                    <!-- グループコード追加・変更機能用 -->
                    <input id="hdnINS_DATE_NEW" type="hidden" name="hdnINS_DATE_NEW" runat="server" />
                    <input id="hdnINS_USER_NEW" type="hidden" name="hdnINS_USER_NEW" runat="server" />
                    <input id="hdnUPD_DATE_NEW" type="hidden" name="hdnUPD_DATE_NEW" runat="server" />
                    <input id="hdnUPD_USER_NEW" type="hidden" name="hdnUPD_USER_NEW" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="right">
                        <input language="javascript" class="bt-RNW" id="btnGROUP_ADD" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btngroupadd_onclick();" tabindex="23" type="button"
							value="グループ追加" name="btnGROUP_ADD" runat="server" />
                        <input language="javascript" style="height:25px; background-color:ButtonFace" id="btnGROUP_SEARCH" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btngroupsearch_onclick();" tabindex="24" type="button"
							value="グループコード名検索" name="btnGROUP_SEARCH" runat="server" />
                        <input language="javascript" style="height:25px; background-color:ButtonFace"  id="btnGROUP_MOD" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btngroupmod_onclick();" tabindex="25" type="button"
							value="グループコード名変更確定" name="btnGROUP_MOD" runat="server" />
                    </td>
					<td style="font-size:12px; color:red;">※JAグループ作成マスタからの<br />&nbsp;&nbsp;グループコードの削除はできません</td>
                </tr>
            </table>
            </div>
            <hr />
            <table>
                <tr>
                    <td width="80">
						<input type="button" name="AllSelect" value="全て選択" onclick="btnCheckBtn(1);" id="btnAllSelect" tabindex="101" />
					</td>
                    <td width="80">
						<input type="button" name="AllRemove" value="全て解除" onclick="btnCheckBtn(2);" id="btnAllRemove" tabindex="102" />
					</td>
					<td width="790" align="right"><font color="red">表示件数：最大100件</font></td>
                </tr>
            </table>
            <input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server" /> 
			<table cellspacing="0" cellpadding="0"">
				<tr>
				    <td align="center" height="25" style="font-size:15px">№</td>
				    <td align="center" height="25" style="font-size:15px">対象</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;ｸﾗｲｱﾝﾄ</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;JA支所コード</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;グループコード・名称</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;お客様コードFrom</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;お客様コードTo</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;備考</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;登録日時</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;登録者</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;更新日時</td>
				    <td align="left" height="25" style="font-size:15px">&nbsp;&nbsp;更新者</td>
				</tr>
                <tr id="list_1">
                    <%-- .NET 使用変更により、ReadOnlyはVB側でAttributeでつける --%>
                    <td>
                        <asp:textbox id="txtNO_1" value="001" abIndex="-1" runat="server" CssClass="c-RO" Width="30px" MaxLength="3"></asp:textbox>
                    </td>
					<td align="center">
                        <asp:checkbox id="chkTARGET_1" tabIndex="1001" runat="server" Width="34px" onkeydown="fncFc(this)" />
                        <%-- <input id="hdnTARGET_1" type="hidden" name="hdnTARGET_1" runat="server" /> --%>
                    </td>
					<td>
                        <asp:textbox id="txtKURACD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="1002" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('101');" 
                            tabindex="1003" type="button" value="▼" name="btnACBCD_1" runat="server" />
                            <input id="hdnACBCD_1" type="hidden" name="hdnACBCD_1" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('201');" 
                            tabindex="1004" type="button" value="▼" name="btnGROUPCD_1" runat="server" />
                            <input id="hdnGROUPCD_1" type="hidden" name="hdnGROUPCD_1" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="1005" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="1006" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="1007" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1012" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('102');" 
                            tabindex="1013" type="button" value="▼" name="btnACBCD_2" runat="server" />
                            <input id="hdnACBCD_2" type="hidden" name="hdnACBCD_2" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('202');" 
                            tabindex="1014" type="button" value="▼" name="btnGROUPCD_2" runat="server" />
                            <input id="hdnGROUPCD_2" type="hidden" name="hdnGROUPCD_2" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1015" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1016" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1017" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1022" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_3" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('103');" 
                            tabindex="1023" type="button" value="▼" name="btnACBCD_3" runat="server" />
                            <input id="hdnACBCD_3" type="hidden" name="hdnACBCD_3" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_3" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('203');" 
                            tabindex="1024" type="button" value="▼" name="btnGROUPCD_3" runat="server" />
                            <input id="hdnGROUPCD_3" type="hidden" name="hdnGROUPCD_3" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1025" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1026" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1027" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1032" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_4" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('104');" 
                            tabindex="1033" type="button" value="▼" name="btnACBCD_4" runat="server" />
                            <input id="hdnACBCD_4" type="hidden" name="hdnACBCD_4" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_4" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('204');" 
                            tabindex="1034" type="button" value="▼" name="btnGROUPCD_4" runat="server" />
                            <input id="hdnGROUPCD_4" type="hidden" name="hdnGROUPCD_4" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1035" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1036" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1037" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1042" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_5" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('105');" 
                            tabindex="1043" type="button" value="▼" name="btnACBCD_5" runat="server" />
                            <input id="hdnACBCD_5" type="hidden" name="hdnACBCD_5" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_5" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('205');" 
                            tabindex="1044" type="button" value="▼" name="btnGROUPCD_5" runat="server" />
                            <input id="hdnGROUPCD_5" type="hidden" name="hdnGROUPCD_5" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1045" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1046" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1047" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1052" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_6" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('106');" 
                            tabindex="1053" type="button" value="▼" name="btnACBCD_6" runat="server" />
                            <input id="hdnACBCD_6" type="hidden" name="hdnACBCD_6" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_6" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('206');" 
                            tabindex="1054" type="button" value="▼" name="btnGROUPCD_6" runat="server" />
                            <input id="hdnGROUPCD_6" type="hidden" name="hdnGROUPCD_6" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1055" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1056" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1057" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1062" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_7" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('107');" 
                            tabindex="1063" type="button" value="▼" name="btnACBCD_7" runat="server" />
                            <input id="hdnACBCD_7" type="hidden" name="hdnACBCD_7" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_7" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('207');" 
                            tabindex="1064" type="button" value="▼" name="btnGROUPCD_7" runat="server" />
                            <input id="hdnGROUPCD_7" type="hidden" name="hdnGROUPCD_7" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1065" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1066" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1067" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1072" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_8" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('108');" 
                            tabindex="1073" type="button" value="▼" name="btnACBCD_8" runat="server" />
                            <input id="hdnACBCD_8" type="hidden" name="hdnACBCD_8" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_8" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('208');" 
                            tabindex="1074" type="button" value="▼" name="btnGROUPCD_8" runat="server" />
                            <input id="hdnGROUPCD_8" type="hidden" name="hdnGROUPCD_8" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1075" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1076" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1077" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1082" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_9" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('109');" 
                            tabindex="1083" type="button" value="▼" name="btnACBCD_9" runat="server" />
                            <input id="hdnACBCD_9" type="hidden" name="hdnACBCD_9" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_9" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('209');" 
                            tabindex="1084" type="button" value="▼" name="btnGROUPCD_9" runat="server" />
                            <input id="hdnGROUPCD_9" type="hidden" name="hdnGROUPCD_9" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1085" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1086" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1087" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1092" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_10" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('110');" 
                            tabindex="1093" type="button" value="▼" name="btnACBCD_10" runat="server" />
                            <input id="hdnACBCD_10" type="hidden" name="hdnACBCD_10" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_10" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('210');" 
                            tabindex="1094" type="button" value="▼" name="btnGROUPCD_10" runat="server" />
                            <input id="hdnGROUPCD_10" type="hidden" name="hdnGROUPCD_10" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1095" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1096" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1097" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1102" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_11" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('111');" 
                            tabindex="1103" type="button" value="▼" name="btnACBCD_11" runat="server" />
                            <input id="hdnACBCD_11" type="hidden" name="hdnACBCD_11" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_11" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('211');" 
                            tabindex="1104" type="button" value="▼" name="btnGROUPCD_11" runat="server" />
                            <input id="hdnGROUPCD_11" type="hidden" name="hdnGROUPCD_11" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1105" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1106" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1107" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1112" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_12" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('112');" 
                            tabindex="1113" type="button" value="▼" name="btnACBCD_12" runat="server" />
                            <input id="hdnACBCD_12" type="hidden" name="hdnACBCD_12" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_12" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('212');" 
                            tabindex="1114" type="button" value="▼" name="btnGROUPCD_12" runat="server" />
                            <input id="hdnGROUPCD_12" type="hidden" name="hdnGROUPCD_12" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1115" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1116" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1117" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1122" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_13" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('113');" 
                            tabindex="1123" type="button" value="▼" name="btnACBCD_13" runat="server" />
                            <input id="hdnACBCD_13" type="hidden" name="hdnACBCD_13" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_13" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('213');" 
                            tabindex="1124" type="button" value="▼" name="btnGROUPCD_13" runat="server" />
                            <input id="hdnGROUPCD_13" type="hidden" name="hdnGROUPCD_13" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1125" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1126" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1127" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1132" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_14" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('114');" 
                            tabindex="1133" type="button" value="▼" name="btnACBCD_14" runat="server" />
                            <input id="hdnACBCD_14" type="hidden" name="hdnACBCD_14" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_14" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('214');" 
                            tabindex="1134" type="button" value="▼" name="btnGROUPCD_14" runat="server" />
                            <input id="hdnGROUPCD_14" type="hidden" name="hdnGROUPCD_14" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1135" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1136" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1137" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1142" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_15" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('115');" 
                            tabindex="1143" type="button" value="▼" name="btnACBCD_15" runat="server" />
                            <input id="hdnACBCD_15" type="hidden" name="hdnACBCD_15" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_15" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('215');" 
                            tabindex="1144" type="button" value="▼" name="btnGROUPCD_15" runat="server" />
                            <input id="hdnGROUPCD_15" type="hidden" name="hdnGROUPCD_15" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1145" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1146" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1147" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1152" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_16" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('116');" 
                            tabindex="1153" type="button" value="▼" name="btnACBCD_16" runat="server" />
                            <input id="hdnACBCD_16" type="hidden" name="hdnACBCD_16" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_16" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('216');" 
                            tabindex="1154" type="button" value="▼" name="btnGROUPCD_16" runat="server" />
                            <input id="hdnGROUPCD_16" type="hidden" name="hdnGROUPCD_16" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1155" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1156" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1157" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1162" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_17" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('117');" 
                            tabindex="1163" type="button" value="▼" name="btnACBCD_17" runat="server" />
                            <input id="hdnACBCD_17" type="hidden" name="hdnACBCD_17" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_17" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('217');" 
                            tabindex="1164" type="button" value="▼" name="btnGROUPCD_17" runat="server" />
                            <input id="hdnGROUPCD_17" type="hidden" name="hdnGROUPCD_17" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1165" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1166" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1167" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1172" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_18" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('118');" 
                            tabindex="1173" type="button" value="▼" name="btnACBCD_18" runat="server" />
                            <input id="hdnACBCD_18" type="hidden" name="hdnACBCD_18" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_18" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('218');" 
                            tabindex="1174" type="button" value="▼" name="btnGROUPCD_18" runat="server" />
                            <input id="hdnGROUPCD_18" type="hidden" name="hdnGROUPCD_18" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1175" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1176" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1177" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1182" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_19" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('119');" 
                            tabindex="1183" type="button" value="▼" name="btnACBCD_19" runat="server" />
                            <input id="hdnACBCD_19" type="hidden" name="hdnACBCD_19" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_19" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('219');" 
                            tabindex="1184" type="button" value="▼" name="btnGROUPCD_19" runat="server" />
                            <input id="hdnGROUPCD_19" type="hidden" name="hdnGROUPCD_19" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1185" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1186" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1187" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1192" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_20" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('120');" 
                            tabindex="1193" type="button" value="▼" name="btnACBCD_20" runat="server" />
                            <input id="hdnACBCD_20" type="hidden" name="hdnACBCD_20" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_20" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('220');" 
                            tabindex="1194" type="button" value="▼" name="btnGROUPCD_20" runat="server" />
                            <input id="hdnGROUPCD_20" type="hidden" name="hdnGROUPCD_20" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1195" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1196" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1197" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1202" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_21" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('121');" 
                            tabindex="1203" type="button" value="▼" name="btnACBCD_21" runat="server" />
                            <input id="hdnACBCD_21" type="hidden" name="hdnACBCD_21" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_21" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('221');" 
                            tabindex="1204" type="button" value="▼" name="btnGROUPCD_21" runat="server" />
                            <input id="hdnGROUPCD_21" type="hidden" name="hdnGROUPCD_21" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1205" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1206" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1207" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1212" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_22" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('122');" 
                            tabindex="1213" type="button" value="▼" name="btnACBCD_22" runat="server" />
                            <input id="hdnACBCD_22" type="hidden" name="hdnACBCD_22" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_22" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('222');" 
                            tabindex="1214" type="button" value="▼" name="btnGROUPCD_22" runat="server" />
                            <input id="hdnGROUPCD_22" type="hidden" name="hdnGROUPCD_22" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1215" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1216" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1217" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1222" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_23" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('123');" 
                            tabindex="1223" type="button" value="▼" name="btnACBCD_23" runat="server" />
                            <input id="hdnACBCD_23" type="hidden" name="hdnACBCD_23" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_23" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('223');" 
                            tabindex="1224" type="button" value="▼" name="btnGROUPCD_23" runat="server" />
                            <input id="hdnGROUPCD_23" type="hidden" name="hdnGROUPCD_23" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1225" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1226" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1227" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1232" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_24" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('124');" 
                            tabindex="1233" type="button" value="▼" name="btnACBCD_24" runat="server" />
                            <input id="hdnACBCD_24" type="hidden" name="hdnACBCD_24" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_24" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('224');" 
                            tabindex="1234" type="button" value="▼" name="btnGROUPCD_24" runat="server" />
                            <input id="hdnGROUPCD_24" type="hidden" name="hdnGROUPCD_24" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1235" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1236" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1237" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1242" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_25" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('125');" 
                            tabindex="1243" type="button" value="▼" name="btnACBCD_25" runat="server" />
                            <input id="hdnACBCD_25" type="hidden" name="hdnACBCD_25" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_25" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('225');" 
                            tabindex="1244" type="button" value="▼" name="btnGROUPCD_25" runat="server" />
                            <input id="hdnGROUPCD_25" type="hidden" name="hdnGROUPCD_25" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1245" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1246" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1247" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1252" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_26" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('126');" 
                            tabindex="1253" type="button" value="▼" name="btnACBCD_26" runat="server" />
                            <input id="hdnACBCD_26" type="hidden" name="hdnACBCD_26" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_26" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('226');" 
                            tabindex="1254" type="button" value="▼" name="btnGROUPCD_26" runat="server" />
                            <input id="hdnGROUPCD_26" type="hidden" name="hdnGROUPCD_26" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1255" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1256" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1257" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1262" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_27" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('127');" 
                            tabindex="1263" type="button" value="▼" name="btnACBCD_27" runat="server" />
                            <input id="hdnACBCD_27" type="hidden" name="hdnACBCD_27" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_27" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('227');" 
                            tabindex="1264" type="button" value="▼" name="btnGROUPCD_27" runat="server" />
                            <input id="hdnGROUPCD_27" type="hidden" name="hdnGROUPCD_27" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1265" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1266" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1267" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1272" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_28" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('128');" 
                            tabindex="1273" type="button" value="▼" name="btnACBCD_28" runat="server" />
                            <input id="hdnACBCD_28" type="hidden" name="hdnACBCD_28" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_28" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('228');" 
                            tabindex="1274" type="button" value="▼" name="btnGROUPCD_28" runat="server" />
                            <input id="hdnGROUPCD_28" type="hidden" name="hdnGROUPCD_28" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1275" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1276" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1277" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1282" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_29" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('129');" 
                            tabindex="1283" type="button" value="▼" name="btnACBCD_29" runat="server" />
                            <input id="hdnACBCD_29" type="hidden" name="hdnACBCD_29" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_29" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('229');" 
                            tabindex="1284" type="button" value="▼" name="btnGROUPCD_29" runat="server" />
                            <input id="hdnGROUPCD_29" type="hidden" name="hdnGROUPCD_29" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1285" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1286" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1287" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1292" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_30" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('130');" 
                            tabindex="1293" type="button" value="▼" name="btnACBCD_30" runat="server" />
                            <input id="hdnACBCD_30" type="hidden" name="hdnACBCD_30" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_30" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('230');" 
                            tabindex="1294" type="button" value="▼" name="btnGROUPCD_30" runat="server" />
                            <input id="hdnGROUPCD_30" type="hidden" name="hdnGROUPCD_30" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1295" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1296" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1297" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1302" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_31" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('131');" 
                            tabindex="1303" type="button" value="▼" name="btnACBCD_31" runat="server" />
                            <input id="hdnACBCD_31" type="hidden" name="hdnACBCD_31" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_31" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_31" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('231');" 
                            tabindex="1304" type="button" value="▼" name="btnGROUPCD_31" runat="server" />
                            <input id="hdnGROUPCD_31" type="hidden" name="hdnGROUPCD_31" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1305" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1306" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1307" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_31" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1312" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_32" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('132');" 
                            tabindex="1313" type="button" value="▼" name="btnACBCD_32" runat="server" />
                            <input id="hdnACBCD_32" type="hidden" name="hdnACBCD_32" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_32" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_32" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('232');" 
                            tabindex="1314" type="button" value="▼" name="btnGROUPCD_32" runat="server" />
                            <input id="hdnGROUPCD_32" type="hidden" name="hdnGROUPCD_32" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1315" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1316" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1317" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_32" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1322" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_33" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('133');" 
                            tabindex="1323" type="button" value="▼" name="btnACBCD_33" runat="server" />
                            <input id="hdnACBCD_33" type="hidden" name="hdnACBCD_33" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_33" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_33" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('233');" 
                            tabindex="1324" type="button" value="▼" name="btnGROUPCD_33" runat="server" />
                            <input id="hdnGROUPCD_33" type="hidden" name="hdnGROUPCD_33" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1325" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1326" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1327" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_33" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1332" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_34" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('134');" 
                            tabindex="1333" type="button" value="▼" name="btnACBCD_34" runat="server" />
                            <input id="hdnACBCD_34" type="hidden" name="hdnACBCD_34" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_34" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_34" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('234');" 
                            tabindex="1334" type="button" value="▼" name="btnGROUPCD_34" runat="server" />
                            <input id="hdnGROUPCD_34" type="hidden" name="hdnGROUPCD_34" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1335" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1336" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1337" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_34" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1342" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_35" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('135');" 
                            tabindex="1343" type="button" value="▼" name="btnACBCD_35" runat="server" />
                            <input id="hdnACBCD_35" type="hidden" name="hdnACBCD_35" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_35" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_35" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('235');" 
                            tabindex="1344" type="button" value="▼" name="btnGROUPCD_35" runat="server" />
                            <input id="hdnGROUPCD_35" type="hidden" name="hdnGROUPCD_35" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1345" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1346" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1347" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_35" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1352" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_36" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('136');" 
                            tabindex="1353" type="button" value="▼" name="btnACBCD_36" runat="server" />
                            <input id="hdnACBCD_36" type="hidden" name="hdnACBCD_36" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_36" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_36" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('236');" 
                            tabindex="1354" type="button" value="▼" name="btnGROUPCD_36" runat="server" />
                            <input id="hdnGROUPCD_36" type="hidden" name="hdnGROUPCD_36" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1355" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1356" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1357" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_36" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1362" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_37" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('137');" 
                            tabindex="1363" type="button" value="▼" name="btnACBCD_37" runat="server" />
                            <input id="hdnACBCD_37" type="hidden" name="hdnACBCD_37" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_37" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_37" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('237');" 
                            tabindex="1364" type="button" value="▼" name="btnGROUPCD_37" runat="server" />
                            <input id="hdnGROUPCD_37" type="hidden" name="hdnGROUPCD_37" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1365" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1366" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1367" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_37" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1372" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_38" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('138');" 
                            tabindex="1373" type="button" value="▼" name="btnACBCD_38" runat="server" />
                            <input id="hdnACBCD_38" type="hidden" name="hdnACBCD_38" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_38" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_38" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('238');" 
                            tabindex="1374" type="button" value="▼" name="btnGROUPCD_38" runat="server" />
                            <input id="hdnGROUPCD_38" type="hidden" name="hdnGROUPCD_38" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1375" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1376" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1377" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_38" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1382" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_39" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('139');" 
                            tabindex="1383" type="button" value="▼" name="btnACBCD_39" runat="server" />
                            <input id="hdnACBCD_39" type="hidden" name="hdnACBCD_39" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_39" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_39" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('239');" 
                            tabindex="1384" type="button" value="▼" name="btnGROUPCD_39" runat="server" />
                            <input id="hdnGROUPCD_39" type="hidden" name="hdnGROUPCD_39" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1385" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1386" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1387" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_39" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1392" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_40" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('140');" 
                            tabindex="1393" type="button" value="▼" name="btnACBCD_40" runat="server" />
                            <input id="hdnACBCD_40" type="hidden" name="hdnACBCD_40" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_40" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_40" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('240');" 
                            tabindex="1394" type="button" value="▼" name="btnGROUPCD_40" runat="server" />
                            <input id="hdnGROUPCD_40" type="hidden" name="hdnGROUPCD_40" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1395" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1396" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1397" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_40" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1402" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_41" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('141');" 
                            tabindex="1403" type="button" value="▼" name="btnACBCD_41" runat="server" />
                            <input id="hdnACBCD_41" type="hidden" name="hdnACBCD_41" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_41" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_41" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('241');" 
                            tabindex="1404" type="button" value="▼" name="btnGROUPCD_41" runat="server" />
                            <input id="hdnGROUPCD_41" type="hidden" name="hdnGROUPCD_41" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1405" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1406" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1407" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_41" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1412" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_42" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('142');" 
                            tabindex="1413" type="button" value="▼" name="btnACBCD_42" runat="server" />
                            <input id="hdnACBCD_42" type="hidden" name="hdnACBCD_42" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_42" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_42" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('242');" 
                            tabindex="1414" type="button" value="▼" name="btnGROUPCD_42" runat="server" />
                            <input id="hdnGROUPCD_42" type="hidden" name="hdnGROUPCD_42" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1415" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1416" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1417" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_42" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1422" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_43" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('143');" 
                            tabindex="1423" type="button" value="▼" name="btnACBCD_43" runat="server" />
                            <input id="hdnACBCD_43" type="hidden" name="hdnACBCD_43" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_43" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_43" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('243');" 
                            tabindex="1424" type="button" value="▼" name="btnGROUPCD_43" runat="server" />
                            <input id="hdnGROUPCD_43" type="hidden" name="hdnGROUPCD_43" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1425" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1426" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1427" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_43" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1432" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_44" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('144');" 
                            tabindex="1433" type="button" value="▼" name="btnACBCD_44" runat="server" />
                            <input id="hdnACBCD_44" type="hidden" name="hdnACBCD_44" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_44" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_44" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('244');" 
                            tabindex="1434" type="button" value="▼" name="btnGROUPCD_44" runat="server" />
                            <input id="hdnGROUPCD_44" type="hidden" name="hdnGROUPCD_44" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1435" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1436" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1437" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_44" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1442" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_45" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('145');" 
                            tabindex="1443" type="button" value="▼" name="btnACBCD_45" runat="server" />
                            <input id="hdnACBCD_45" type="hidden" name="hdnACBCD_45" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_45" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_45" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('245');" 
                            tabindex="1444" type="button" value="▼" name="btnGROUPCD_45" runat="server" />
                            <input id="hdnGROUPCD_45" type="hidden" name="hdnGROUPCD_45" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1445" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1446" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1447" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_45" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1452" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_46" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('146');" 
                            tabindex="1453" type="button" value="▼" name="btnACBCD_46" runat="server" />
                            <input id="hdnACBCD_46" type="hidden" name="hdnACBCD_46" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_46" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_46" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('246');" 
                            tabindex="1454" type="button" value="▼" name="btnGROUPCD_46" runat="server" />
                            <input id="hdnGROUPCD_46" type="hidden" name="hdnGROUPCD_46" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1455" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1456" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1457" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_46" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1462" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_47" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('147');" 
                            tabindex="1463" type="button" value="▼" name="btnACBCD_47" runat="server" />
                            <input id="hdnACBCD_47" type="hidden" name="hdnACBCD_47" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_47" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_47" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('247');" 
                            tabindex="1464" type="button" value="▼" name="btnGROUPCD_47" runat="server" />
                            <input id="hdnGROUPCD_47" type="hidden" name="hdnGROUPCD_47" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1465" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1466" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1467" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_47" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1472" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_48" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('148');" 
                            tabindex="1473" type="button" value="▼" name="btnACBCD_48" runat="server" />
                            <input id="hdnACBCD_48" type="hidden" name="hdnACBCD_48" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_48" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_48" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('248');" 
                            tabindex="1474" type="button" value="▼" name="btnGROUPCD_48" runat="server" />
                            <input id="hdnGROUPCD_48" type="hidden" name="hdnGROUPCD_48" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1475" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1476" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1477" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_48" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1482" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_49" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('149');" 
                            tabindex="1483" type="button" value="▼" name="btnACBCD_49" runat="server" />
                            <input id="hdnACBCD_49" type="hidden" name="hdnACBCD_49" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_49" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_49" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('249');" 
                            tabindex="1484" type="button" value="▼" name="btnGROUPCD_49" runat="server" />
                            <input id="hdnGROUPCD_49" type="hidden" name="hdnGROUPCD_49" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1485" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1486" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1487" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_49" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1492" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_50" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('150');" 
                            tabindex="1493" type="button" value="▼" name="btnACBCD_50" runat="server" />
                            <input id="hdnACBCD_50" type="hidden" name="hdnACBCD_50" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_50" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_50" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('250');" 
                            tabindex="1494" type="button" value="▼" name="btnGROUPCD_50" runat="server" />
                            <input id="hdnGROUPCD_50" type="hidden" name="hdnGROUPCD_50" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1495" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1496" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1497" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_50" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_51" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1502" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_51" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_51" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('151');" 
                            tabindex="1503" type="button" value="▼" name="btnACBCD_51" runat="server" />
                            <input id="hdnACBCD_51" type="hidden" name="hdnACBCD_51" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_51" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_51" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('251');" 
                            tabindex="1504" type="button" value="▼" name="btnGROUPCD_51" runat="server" />
                            <input id="hdnGROUPCD_51" type="hidden" name="hdnGROUPCD_51" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_51" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1505" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_51" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1506" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_51" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1507" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_51" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_51" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_51" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_51" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_52" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1512" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_52" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_52" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('152');" 
                            tabindex="1513" type="button" value="▼" name="btnACBCD_52" runat="server" />
                            <input id="hdnACBCD_52" type="hidden" name="hdnACBCD_52" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_52" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_52" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('252');" 
                            tabindex="1514" type="button" value="▼" name="btnGROUPCD_52" runat="server" />
                            <input id="hdnGROUPCD_52" type="hidden" name="hdnGROUPCD_52" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_52" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1515" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_52" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1516" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_52" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1517" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_52" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_52" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_52" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_52" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_53" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1522" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_53" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_53" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('153');" 
                            tabindex="1523" type="button" value="▼" name="btnACBCD_53" runat="server" />
                            <input id="hdnACBCD_53" type="hidden" name="hdnACBCD_53" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_53" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_53" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('253');" 
                            tabindex="1524" type="button" value="▼" name="btnGROUPCD_53" runat="server" />
                            <input id="hdnGROUPCD_53" type="hidden" name="hdnGROUPCD_53" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_53" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1525" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_53" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1526" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_53" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1527" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_53" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_53" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_53" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_53" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_54" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1532" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_54" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_54" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('154');" 
                            tabindex="1533" type="button" value="▼" name="btnACBCD_54" runat="server" />
                            <input id="hdnACBCD_54" type="hidden" name="hdnACBCD_54" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_54" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_54" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('254');" 
                            tabindex="1534" type="button" value="▼" name="btnGROUPCD_54" runat="server" />
                            <input id="hdnGROUPCD_54" type="hidden" name="hdnGROUPCD_54" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_54" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1535" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_54" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1536" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_54" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1537" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_54" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_54" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_54" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_54" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_55" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1542" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_55" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_55" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('155');" 
                            tabindex="1543" type="button" value="▼" name="btnACBCD_55" runat="server" />
                            <input id="hdnACBCD_55" type="hidden" name="hdnACBCD_55" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_55" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_55" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('255');" 
                            tabindex="1544" type="button" value="▼" name="btnGROUPCD_55" runat="server" />
                            <input id="hdnGROUPCD_55" type="hidden" name="hdnGROUPCD_55" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_55" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1545" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_55" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1546" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_55" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1547" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_55" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_55" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_55" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_55" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_56" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1552" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_56" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_56" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('156');" 
                            tabindex="1553" type="button" value="▼" name="btnACBCD_56" runat="server" />
                            <input id="hdnACBCD_56" type="hidden" name="hdnACBCD_56" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_56" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_56" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('256');" 
                            tabindex="1554" type="button" value="▼" name="btnGROUPCD_56" runat="server" />
                            <input id="hdnGROUPCD_56" type="hidden" name="hdnGROUPCD_56" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_56" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1555" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_56" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1556" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_56" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1557" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_56" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_56" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_56" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_56" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_57" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1562" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_57" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_57" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('157');" 
                            tabindex="1563" type="button" value="▼" name="btnACBCD_57" runat="server" />
                            <input id="hdnACBCD_57" type="hidden" name="hdnACBCD_57" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_57" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_57" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('257');" 
                            tabindex="1564" type="button" value="▼" name="btnGROUPCD_57" runat="server" />
                            <input id="hdnGROUPCD_57" type="hidden" name="hdnGROUPCD_57" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_57" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1565" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_57" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1566" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_57" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1567" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_57" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_57" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_57" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_57" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_58" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1572" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_58" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_58" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('158');" 
                            tabindex="1573" type="button" value="▼" name="btnACBCD_58" runat="server" />
                            <input id="hdnACBCD_58" type="hidden" name="hdnACBCD_58" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_58" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_58" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('258');" 
                            tabindex="1574" type="button" value="▼" name="btnGROUPCD_58" runat="server" />
                            <input id="hdnGROUPCD_58" type="hidden" name="hdnGROUPCD_58" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_58" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1575" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_58" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1576" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_58" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1577" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_58" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_58" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_58" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_58" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_59" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1582" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_59" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_59" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('159');" 
                            tabindex="1583" type="button" value="▼" name="btnACBCD_59" runat="server" />
                            <input id="hdnACBCD_59" type="hidden" name="hdnACBCD_59" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_59" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_59" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('259');" 
                            tabindex="1584" type="button" value="▼" name="btnGROUPCD_59" runat="server" />
                            <input id="hdnGROUPCD_59" type="hidden" name="hdnGROUPCD_59" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_59" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1585" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_59" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1586" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_59" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1587" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_59" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_59" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_59" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_59" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_60" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1592" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_60" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_60" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('160');" 
                            tabindex="1593" type="button" value="▼" name="btnACBCD_60" runat="server" />
                            <input id="hdnACBCD_60" type="hidden" name="hdnACBCD_60" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_60" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_60" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('260');" 
                            tabindex="1594" type="button" value="▼" name="btnGROUPCD_60" runat="server" />
                            <input id="hdnGROUPCD_60" type="hidden" name="hdnGROUPCD_60" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_60" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1595" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_60" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1596" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_60" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1597" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_60" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_60" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_60" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_60" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_61" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1602" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_61" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_61" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('161');" 
                            tabindex="1603" type="button" value="▼" name="btnACBCD_61" runat="server" />
                            <input id="hdnACBCD_61" type="hidden" name="hdnACBCD_61" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_61" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_61" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('261');" 
                            tabindex="1604" type="button" value="▼" name="btnGROUPCD_61" runat="server" />
                            <input id="hdnGROUPCD_61" type="hidden" name="hdnGROUPCD_61" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_61" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1605" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_61" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1606" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_61" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1607" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_61" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_61" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_61" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_61" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_62" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1612" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_62" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_62" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('162');" 
                            tabindex="1613" type="button" value="▼" name="btnACBCD_62" runat="server" />
                            <input id="hdnACBCD_62" type="hidden" name="hdnACBCD_62" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_62" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_62" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('262');" 
                            tabindex="1614" type="button" value="▼" name="btnGROUPCD_62" runat="server" />
                            <input id="hdnGROUPCD_62" type="hidden" name="hdnGROUPCD_62" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_62" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1615" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_62" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1616" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_62" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1617" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_62" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_62" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_62" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_62" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_63" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1622" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_63" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_63" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('163');" 
                            tabindex="1623" type="button" value="▼" name="btnACBCD_63" runat="server" />
                            <input id="hdnACBCD_63" type="hidden" name="hdnACBCD_63" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_63" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_63" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('263');" 
                            tabindex="1624" type="button" value="▼" name="btnGROUPCD_63" runat="server" />
                            <input id="hdnGROUPCD_63" type="hidden" name="hdnGROUPCD_63" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_63" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1625" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_63" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1626" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_63" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1627" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_63" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_63" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_63" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_63" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_64" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1632" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_64" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_64" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('164');" 
                            tabindex="1633" type="button" value="▼" name="btnACBCD_64" runat="server" />
                            <input id="hdnACBCD_64" type="hidden" name="hdnACBCD_64" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_64" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_64" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('264');" 
                            tabindex="1634" type="button" value="▼" name="btnGROUPCD_64" runat="server" />
                            <input id="hdnGROUPCD_64" type="hidden" name="hdnGROUPCD_64" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_64" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1635" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_64" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1636" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_64" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1637" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_64" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_64" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_64" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_64" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_65" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1642" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_65" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_65" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('165');" 
                            tabindex="1643" type="button" value="▼" name="btnACBCD_65" runat="server" />
                            <input id="hdnACBCD_65" type="hidden" name="hdnACBCD_65" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_65" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_65" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('265');" 
                            tabindex="1644" type="button" value="▼" name="btnGROUPCD_65" runat="server" />
                            <input id="hdnGROUPCD_65" type="hidden" name="hdnGROUPCD_65" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_65" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1645" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_65" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1646" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_65" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1647" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_65" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_65" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_65" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_65" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_66" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1652" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_66" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_66" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('166');" 
                            tabindex="1653" type="button" value="▼" name="btnACBCD_66" runat="server" />
                            <input id="hdnACBCD_66" type="hidden" name="hdnACBCD_66" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_66" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_66" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('266');" 
                            tabindex="1654" type="button" value="▼" name="btnGROUPCD_66" runat="server" />
                            <input id="hdnGROUPCD_66" type="hidden" name="hdnGROUPCD_66" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_66" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1655" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_66" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1656" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_66" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1657" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_66" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_66" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_66" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_66" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_67" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1662" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_67" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_67" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('167');" 
                            tabindex="1663" type="button" value="▼" name="btnACBCD_67" runat="server" />
                            <input id="hdnACBCD_67" type="hidden" name="hdnACBCD_67" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_67" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_67" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('267');" 
                            tabindex="1664" type="button" value="▼" name="btnGROUPCD_67" runat="server" />
                            <input id="hdnGROUPCD_67" type="hidden" name="hdnGROUPCD_67" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_67" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1665" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_67" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1666" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_67" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1667" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_67" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_67" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_67" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_67" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_68" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1672" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_68" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_68" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('168');" 
                            tabindex="1673" type="button" value="▼" name="btnACBCD_68" runat="server" />
                            <input id="hdnACBCD_68" type="hidden" name="hdnACBCD_68" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_68" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_68" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('268');" 
                            tabindex="1674" type="button" value="▼" name="btnGROUPCD_68" runat="server" />
                            <input id="hdnGROUPCD_68" type="hidden" name="hdnGROUPCD_68" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_68" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1675" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_68" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1676" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_68" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1677" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_68" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_68" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_68" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_68" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_69" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1682" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_69" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_69" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('169');" 
                            tabindex="1683" type="button" value="▼" name="btnACBCD_69" runat="server" />
                            <input id="hdnACBCD_69" type="hidden" name="hdnACBCD_69" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_69" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_69" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('269');" 
                            tabindex="1684" type="button" value="▼" name="btnGROUPCD_69" runat="server" />
                            <input id="hdnGROUPCD_69" type="hidden" name="hdnGROUPCD_69" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_69" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1685" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_69" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1686" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_69" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1687" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_69" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_69" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_69" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_69" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_70" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1692" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_70" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_70" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('170');" 
                            tabindex="1693" type="button" value="▼" name="btnACBCD_70" runat="server" />
                            <input id="hdnACBCD_70" type="hidden" name="hdnACBCD_70" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_70" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_70" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('270');" 
                            tabindex="1694" type="button" value="▼" name="btnGROUPCD_70" runat="server" />
                            <input id="hdnGROUPCD_70" type="hidden" name="hdnGROUPCD_70" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_70" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1695" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_70" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1696" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_70" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1697" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_70" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_70" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_70" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_70" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_71" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1702" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_71" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_71" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('171');" 
                            tabindex="1703" type="button" value="▼" name="btnACBCD_71" runat="server" />
                            <input id="hdnACBCD_71" type="hidden" name="hdnACBCD_71" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_71" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_71" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('271');" 
                            tabindex="1704" type="button" value="▼" name="btnGROUPCD_71" runat="server" />
                            <input id="hdnGROUPCD_71" type="hidden" name="hdnGROUPCD_71" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_71" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1705" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_71" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1706" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_71" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1707" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_71" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_71" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_71" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_71" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_72" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1712" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_72" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_72" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('172');" 
                            tabindex="1713" type="button" value="▼" name="btnACBCD_72" runat="server" />
                            <input id="hdnACBCD_72" type="hidden" name="hdnACBCD_72" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_72" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_72" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('272');" 
                            tabindex="1714" type="button" value="▼" name="btnGROUPCD_72" runat="server" />
                            <input id="hdnGROUPCD_72" type="hidden" name="hdnGROUPCD_72" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_72" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1715" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_72" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1716" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_72" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1717" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_72" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_72" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_72" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_72" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_73" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1722" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_73" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_73" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('173');" 
                            tabindex="1723" type="button" value="▼" name="btnACBCD_73" runat="server" />
                            <input id="hdnACBCD_73" type="hidden" name="hdnACBCD_73" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_73" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_73" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('273');" 
                            tabindex="1724" type="button" value="▼" name="btnGROUPCD_73" runat="server" />
                            <input id="hdnGROUPCD_73" type="hidden" name="hdnGROUPCD_73" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_73" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1725" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_73" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1726" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_73" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1727" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_73" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_73" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_73" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_73" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_74" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1732" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_74" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_74" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('174');" 
                            tabindex="1733" type="button" value="▼" name="btnACBCD_74" runat="server" />
                            <input id="hdnACBCD_74" type="hidden" name="hdnACBCD_74" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_74" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_74" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('274');" 
                            tabindex="1734" type="button" value="▼" name="btnGROUPCD_74" runat="server" />
                            <input id="hdnGROUPCD_74" type="hidden" name="hdnGROUPCD_74" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_74" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1735" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_74" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1736" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_74" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1737" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_74" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_74" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_74" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_74" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_75" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1742" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_75" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_75" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('175');" 
                            tabindex="1743" type="button" value="▼" name="btnACBCD_75" runat="server" />
                            <input id="hdnACBCD_75" type="hidden" name="hdnACBCD_75" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_75" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_75" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('275');" 
                            tabindex="1744" type="button" value="▼" name="btnGROUPCD_75" runat="server" />
                            <input id="hdnGROUPCD_75" type="hidden" name="hdnGROUPCD_75" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_75" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1745" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_75" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1746" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_75" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1747" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_75" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_75" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_75" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_75" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_76" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1752" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_76" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_76" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('176');" 
                            tabindex="1753" type="button" value="▼" name="btnACBCD_76" runat="server" />
                            <input id="hdnACBCD_76" type="hidden" name="hdnACBCD_76" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_76" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_76" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('276');" 
                            tabindex="1754" type="button" value="▼" name="btnGROUPCD_76" runat="server" />
                            <input id="hdnGROUPCD_76" type="hidden" name="hdnGROUPCD_76" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_76" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1755" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_76" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1756" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_76" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1757" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_76" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_76" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_76" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_76" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_77" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1762" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_77" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_77" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('177');" 
                            tabindex="1763" type="button" value="▼" name="btnACBCD_77" runat="server" />
                            <input id="hdnACBCD_77" type="hidden" name="hdnACBCD_77" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_77" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_77" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('277');" 
                            tabindex="1764" type="button" value="▼" name="btnGROUPCD_77" runat="server" />
                            <input id="hdnGROUPCD_77" type="hidden" name="hdnGROUPCD_77" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_77" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1765" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_77" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1766" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_77" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1767" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_77" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_77" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_77" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_77" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_78" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1772" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_78" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_78" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('178');" 
                            tabindex="1773" type="button" value="▼" name="btnACBCD_78" runat="server" />
                            <input id="hdnACBCD_78" type="hidden" name="hdnACBCD_78" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_78" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_78" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('278');" 
                            tabindex="1774" type="button" value="▼" name="btnGROUPCD_78" runat="server" />
                            <input id="hdnGROUPCD_78" type="hidden" name="hdnGROUPCD_78" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_78" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1775" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_78" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1776" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_78" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1777" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_78" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_78" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_78" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_78" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_79" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1782" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_79" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_79" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('179');" 
                            tabindex="1783" type="button" value="▼" name="btnACBCD_79" runat="server" />
                            <input id="hdnACBCD_79" type="hidden" name="hdnACBCD_79" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_79" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_79" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('279');" 
                            tabindex="1784" type="button" value="▼" name="btnGROUPCD_79" runat="server" />
                            <input id="hdnGROUPCD_79" type="hidden" name="hdnGROUPCD_79" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_79" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1785" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_79" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1786" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_79" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1787" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_79" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_79" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_79" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_79" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_80" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1792" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_80" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_80" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('180');" 
                            tabindex="1793" type="button" value="▼" name="btnACBCD_80" runat="server" />
                            <input id="hdnACBCD_80" type="hidden" name="hdnACBCD_80" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_80" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_80" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('280');" 
                            tabindex="1794" type="button" value="▼" name="btnGROUPCD_80" runat="server" />
                            <input id="hdnGROUPCD_80" type="hidden" name="hdnGROUPCD_80" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_80" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1795" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_80" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1796" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_80" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1797" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_80" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_80" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_80" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_80" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_81" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1802" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_81" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_81" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('181');" 
                            tabindex="1803" type="button" value="▼" name="btnACBCD_81" runat="server" />
                            <input id="hdnACBCD_81" type="hidden" name="hdnACBCD_81" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_81" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_81" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('281');" 
                            tabindex="1804" type="button" value="▼" name="btnGROUPCD_81" runat="server" />
                            <input id="hdnGROUPCD_81" type="hidden" name="hdnGROUPCD_81" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_81" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1805" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_81" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1806" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_81" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1807" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_81" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_81" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_81" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_81" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_82" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1812" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_82" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_82" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('182');" 
                            tabindex="1813" type="button" value="▼" name="btnACBCD_82" runat="server" />
                            <input id="hdnACBCD_82" type="hidden" name="hdnACBCD_82" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_82" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_82" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('282');" 
                            tabindex="1814" type="button" value="▼" name="btnGROUPCD_82" runat="server" />
                            <input id="hdnGROUPCD_82" type="hidden" name="hdnGROUPCD_82" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_82" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1815" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_82" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1816" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_82" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1817" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_82" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_82" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_82" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_82" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_83" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1822" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_83" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_83" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('183');" 
                            tabindex="1823" type="button" value="▼" name="btnACBCD_83" runat="server" />
                            <input id="hdnACBCD_83" type="hidden" name="hdnACBCD_83" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_83" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_83" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('283');" 
                            tabindex="1824" type="button" value="▼" name="btnGROUPCD_83" runat="server" />
                            <input id="hdnGROUPCD_83" type="hidden" name="hdnGROUPCD_83" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_83" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1825" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_83" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1826" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_83" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1827" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_83" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_83" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_83" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_83" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_84" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1832" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_84" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_84" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('184');" 
                            tabindex="1833" type="button" value="▼" name="btnACBCD_84" runat="server" />
                            <input id="hdnACBCD_84" type="hidden" name="hdnACBCD_84" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_84" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_84" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('284');" 
                            tabindex="1834" type="button" value="▼" name="btnGROUPCD_84" runat="server" />
                            <input id="hdnGROUPCD_84" type="hidden" name="hdnGROUPCD_84" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_84" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1835" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_84" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1836" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_84" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1837" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_84" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_84" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_84" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_84" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_85" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1842" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_85" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_85" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('185');" 
                            tabindex="1843" type="button" value="▼" name="btnACBCD_85" runat="server" />
                            <input id="hdnACBCD_85" type="hidden" name="hdnACBCD_85" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_85" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_85" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('285');" 
                            tabindex="1844" type="button" value="▼" name="btnGROUPCD_85" runat="server" />
                            <input id="hdnGROUPCD_85" type="hidden" name="hdnGROUPCD_85" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_85" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1845" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_85" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1846" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_85" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1847" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_85" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_85" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_85" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_85" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_86" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1852" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_86" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_86" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('186');" 
                            tabindex="1853" type="button" value="▼" name="btnACBCD_86" runat="server" />
                            <input id="hdnACBCD_86" type="hidden" name="hdnACBCD_86" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_86" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_86" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('286');" 
                            tabindex="1854" type="button" value="▼" name="btnGROUPCD_86" runat="server" />
                            <input id="hdnGROUPCD_86" type="hidden" name="hdnGROUPCD_86" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_86" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1855" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_86" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1856" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_86" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1857" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_86" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_86" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_86" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_86" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_87" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1862" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_87" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_87" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('187');" 
                            tabindex="1863" type="button" value="▼" name="btnACBCD_87" runat="server" />
                            <input id="hdnACBCD_87" type="hidden" name="hdnACBCD_87" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_87" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_87" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('287');" 
                            tabindex="1864" type="button" value="▼" name="btnGROUPCD_87" runat="server" />
                            <input id="hdnGROUPCD_87" type="hidden" name="hdnGROUPCD_87" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_87" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1865" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_87" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1866" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_87" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1867" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_87" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_87" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_87" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_87" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_88" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1872" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_88" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_88" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('188');" 
                            tabindex="1873" type="button" value="▼" name="btnACBCD_88" runat="server" />
                            <input id="hdnACBCD_88" type="hidden" name="hdnACBCD_88" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_88" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_88" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('288');" 
                            tabindex="1874" type="button" value="▼" name="btnGROUPCD_88" runat="server" />
                            <input id="hdnGROUPCD_88" type="hidden" name="hdnGROUPCD_88" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_88" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1875" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_88" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1876" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_88" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1877" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_88" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_88" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_88" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_88" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_89" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1882" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_89" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_89" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('189');" 
                            tabindex="1883" type="button" value="▼" name="btnACBCD_89" runat="server" />
                            <input id="hdnACBCD_89" type="hidden" name="hdnACBCD_89" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_89" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_89" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('289');" 
                            tabindex="1884" type="button" value="▼" name="btnGROUPCD_89" runat="server" />
                            <input id="hdnGROUPCD_89" type="hidden" name="hdnGROUPCD_89" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_89" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1885" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_89" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1886" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_89" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1887" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_89" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_89" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_89" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_89" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_90" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1892" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_90" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_90" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('190');" 
                            tabindex="1893" type="button" value="▼" name="btnACBCD_90" runat="server" />
                            <input id="hdnACBCD_90" type="hidden" name="hdnACBCD_90" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_90" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_90" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('290');" 
                            tabindex="1894" type="button" value="▼" name="btnGROUPCD_90" runat="server" />
                            <input id="hdnGROUPCD_90" type="hidden" name="hdnGROUPCD_90" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_90" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1895" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_90" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1896" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_90" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1897" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_90" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_90" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_90" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_90" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_91" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1902" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_91" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_91" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('191');" 
                            tabindex="1903" type="button" value="▼" name="btnACBCD_91" runat="server" />
                            <input id="hdnACBCD_91" type="hidden" name="hdnACBCD_91" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_91" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_91" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('291');" 
                            tabindex="1904" type="button" value="▼" name="btnGROUPCD_91" runat="server" />
                            <input id="hdnGROUPCD_91" type="hidden" name="hdnGROUPCD_91" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_91" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1905" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_91" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1906" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_91" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1907" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_91" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_91" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_91" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_91" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_92" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1912" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_92" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_92" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('192');" 
                            tabindex="1913" type="button" value="▼" name="btnACBCD_92" runat="server" />
                            <input id="hdnACBCD_92" type="hidden" name="hdnACBCD_92" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_92" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_92" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('292');" 
                            tabindex="1914" type="button" value="▼" name="btnGROUPCD_92" runat="server" />
                            <input id="hdnGROUPCD_92" type="hidden" name="hdnGROUPCD_92" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_92" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1915" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_92" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1916" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_92" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1917" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_92" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_92" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_92" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_92" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_93" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1922" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_93" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_93" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('193');" 
                            tabindex="1923" type="button" value="▼" name="btnACBCD_93" runat="server" />
                            <input id="hdnACBCD_93" type="hidden" name="hdnACBCD_93" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_93" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_93" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('293');" 
                            tabindex="1924" type="button" value="▼" name="btnGROUPCD_93" runat="server" />
                            <input id="hdnGROUPCD_93" type="hidden" name="hdnGROUPCD_93" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_93" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1925" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_93" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1926" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_93" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1927" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_93" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_93" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_93" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_93" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_94" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1932" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_94" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_94" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('194');" 
                            tabindex="1933" type="button" value="▼" name="btnACBCD_94" runat="server" />
                            <input id="hdnACBCD_94" type="hidden" name="hdnACBCD_94" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_94" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_94" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('294');" 
                            tabindex="1934" type="button" value="▼" name="btnGROUPCD_94" runat="server" />
                            <input id="hdnGROUPCD_94" type="hidden" name="hdnGROUPCD_94" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_94" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1935" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_94" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1936" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_94" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1937" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_94" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_94" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_94" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_94" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_95" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1942" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_95" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_95" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('195');" 
                            tabindex="1943" type="button" value="▼" name="btnACBCD_95" runat="server" />
                            <input id="hdnACBCD_95" type="hidden" name="hdnACBCD_95" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_95" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_95" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('295');" 
                            tabindex="1944" type="button" value="▼" name="btnGROUPCD_95" runat="server" />
                            <input id="hdnGROUPCD_95" type="hidden" name="hdnGROUPCD_95" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_95" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1945" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_95" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1946" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_95" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1947" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_95" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_95" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_95" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_95" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_96" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1952" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_96" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_96" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('196');" 
                            tabindex="1953" type="button" value="▼" name="btnACBCD_96" runat="server" />
                            <input id="hdnACBCD_96" type="hidden" name="hdnACBCD_96" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_96" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_96" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('296');" 
                            tabindex="1954" type="button" value="▼" name="btnGROUPCD_96" runat="server" />
                            <input id="hdnGROUPCD_96" type="hidden" name="hdnGROUPCD_96" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_96" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1955" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_96" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1956" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_96" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1957" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_96" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_96" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_96" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_96" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_97" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1962" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_97" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_97" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('197');" 
                            tabindex="1963" type="button" value="▼" name="btnACBCD_97" runat="server" />
                            <input id="hdnACBCD_97" type="hidden" name="hdnACBCD_97" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_97" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_97" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('297');" 
                            tabindex="1964" type="button" value="▼" name="btnGROUPCD_97" runat="server" />
                            <input id="hdnGROUPCD_97" type="hidden" name="hdnGROUPCD_97" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_97" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1965" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_97" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1966" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_97" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1967" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_97" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_97" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_97" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_97" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_98" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1972" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_98" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_98" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('198');" 
                            tabindex="1973" type="button" value="▼" name="btnACBCD_98" runat="server" />
                            <input id="hdnACBCD_98" type="hidden" name="hdnACBCD_98" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_98" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_98" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('298');" 
                            tabindex="1974" type="button" value="▼" name="btnGROUPCD_98" runat="server" />
                            <input id="hdnGROUPCD_98" type="hidden" name="hdnGROUPCD_98" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_98" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1975" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_98" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1976" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_98" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1977" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_98" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_98" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_98" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_98" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_99" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1982" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_99" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_99" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('199');" 
                            tabindex="1983" type="button" value="▼" name="btnACBCD_99" runat="server" />
                            <input id="hdnACBCD_99" type="hidden" name="hdnACBCD_99" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_99" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_99" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('299');" 
                            tabindex="1984" type="button" value="▼" name="btnGROUPCD_99" runat="server" />
                            <input id="hdnGROUPCD_99" type="hidden" name="hdnGROUPCD_99" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_99" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1985" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_99" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1986" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_99" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1987" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_99" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_99" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_99" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_99" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
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
                        <asp:textbox id="txtKURACD_100" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabindex="1992" runat="server" CssClass="c-h" Width="60px" MaxLength="10"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtACBCD_100" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="240px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnACBCD_100" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('200');" 
                            tabindex="1993" type="button" value="▼" name="btnACBCD_100" runat="server" />
                            <input id="hdnACBCD_100" type="hidden" name="hdnACBCD_100" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtGROUPCD_100" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-h" Width="430px" MaxLength="10"></asp:textbox><input class="bt-KS" 
                            id="btnGROUPCD_100" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('300');" 
                            tabindex="1994" type="button" value="▼" name="btnGROUPCD_100" runat="server" />
                            <input id="hdnGROUPCD_100" type="hidden" name="hdnGROUPCD_100" runat="server" />
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_F_100" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1995" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUSERCD_T_100" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1996" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox>
                    </td>
					<td>
                        <asp:textbox id="txtBIKO_100" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="1997" runat="server" CssClass="c-fI" Width="220px" MaxLength="200"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_DATE_100" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtINS_USER_100" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_DATE_100" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="130px"></asp:textbox>
                    </td>
                    <td>
                        <asp:textbox id="txtUPD_USER_100" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="-1" runat="server" CssClass="c-RO" Width="100px"></asp:textbox>
                    </td>
				</tr>
			</table>
		</form>
	</body>
</HTML>

