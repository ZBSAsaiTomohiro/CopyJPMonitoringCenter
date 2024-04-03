<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTAGJAG00.aspx.vb" Inherits="MSTAGJAG00.MSTAGJAG00" EnableSessionState="ReadOnly" enableViewState="False" validateRequest="false" %>
<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSTAGJAG00</title>
		<% 
'***********************************************
' JA担当者・連絡先・報告先マスタ  メイン画面
'***********************************************
' 変更履歴
' 2015/11/04 T.Ono 新規作成   
%>
		<style type="text/css">
			#tab { PADDING-LEFT: 0px; MARGIN-BOTTOM: 1em; MARGIN-LEFT: 0px; OVERFLOW: hidden; BORDER-BOTTOM: #333 2px solid; HEIGHT: 1.5em }
			#tab LI { FLOAT: left; WIDTH: 150px; HEIGHT: 1.5em }
			#tab LI A { BORDER-RIGHT: #ccc 1px solid; BORDER-TOP: #ccc 1px solid; DISPLAY: block; BORDER-LEFT: #ccc 5px solid; WIDTH: 150px; COLOR: #777; BORDER-BOTTOM: 0px; HEIGHT: 1.5em; TEXT-ALIGN: center }
			#tab LI A:hover { BORDER-LEFT-COLOR: #333; BORDER-BOTTOM-COLOR: #333; COLOR: #000; BORDER-TOP-COLOR: #333; BORDER-RIGHT-COLOR: #333 }
			#tab LI.present A { BORDER-LEFT-COLOR: #333; BORDER-BOTTOM-COLOR: #333; COLOR: #000; BORDER-TOP-COLOR: #333; BORDER-RIGHT-COLOR: #333 }
			#page1 { PADDING-TOP: 0em }
			#page2 { PADDING-TOP: 0em }
			.preview { OVERFLOW: hidden; WIDTH: 100%; HEIGHT: 100% }
			.style1
            {
                width: 342px;
            }
			.style2
            {
                width: 150px;
            }
			.style3
            {
                height: 34px;
            }
			</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
			<asp:label id="lblScript" runat="server"></asp:label>
			<INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"> <INPUT id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server">
			<INPUT id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server">
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="*"><input class="bt-JIK" id="btnSelect" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();"
										tabIndex="9001" type="button" value="検索" name="btnSelect" runat="server">
								</td>
								<td width="300">&nbsp;</td>
								<td width="220"><input class="bt-JIK" id="btnUpdate" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnUpdate_onclick();"
										tabIndex="9002" type="button" value="登録" name="btnUpdate" runat="server"/>
								</td>
								<td width="220"><input class="bt-JIK" id="btnDelete" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnDelete_onclick();"
										tabIndex="9003" type="button" value="削除" name="btnDelete" runat="server"/>
								</td>
								<td width="70"><input class="bt-JIK" id="btnClear" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnClear_onclick();"
										tabIndex="9005" type="button" value="取消" name="btnClear" runat="server"/>
								</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
										tabIndex="9006" type="button" value="終了" name="btnExit" runat="server"/>
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
											<td class="TITLE" vAlign="middle">JA担当者・報告先・注意事項マスタ</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="170">作成日：<asp:textbox id="txtAYMD" tabIndex="-1" runat="server" CssClass="c-RO" Width="72px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><br>
									更新日：<asp:textbox id="txtUYMD" tabIndex="-1" runat="server" CssClass="c-RO" Width="72px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox>
								</td>
							</tr>
						</table>
						<input id="hdnKBN" type="hidden" name="hdnKBN" runat="server"/>
                        <input id="hdnDBKBN" type="hidden" name="hdnDBKBN" runat="server"/><!-- DBのKBNフィールド -->
                        <input id="hdnKEY" type="hidden" name="hdnKEY" runat="server"/><!-- DBのGROUPCDフィールド -->
                        <input id="hdnINS_DATE_1" type="hidden" name="hdnINS_DATE_1" runat="server"/><input id="hdnINS_DATE_2" type="hidden" name="hdnINS_DATE_2" runat="server"/>
                        <input id="hdnINS_DATE_3" type="hidden"	name="hdnINS_DATE_3" runat="server"/><input id="hdnINS_DATE_4" type="hidden"	name="hdnINS_DATE_4" runat="server"/>
                        <input id="hdnINS_DATE_5" type="hidden"	name="hdnINS_DATE_5" runat="server"/><input id="hdnINS_DATE_6" type="hidden"	name="hdnINS_DATE_6" runat="server"/>
                        <input id="hdnINS_DATE_7" type="hidden"	name="hdnINS_DATE_7" runat="server"/><input id="hdnINS_DATE_8" type="hidden"	name="hdnINS_DATE_8" runat="server"/>
                        <input id="hdnINS_DATE_9" type="hidden"	name="hdnINS_DATE_9" runat="server"/><input id="hdnINS_DATE_10" type="hidden" name="hdnINS_DATE_10" runat="server"/>
                        <input id="hdnINS_DATE_11" type="hidden" name="hdnINS_DATE_11" runat="server"/><input id="hdnINS_DATE_12" type="hidden" name="hdnINS_DATE_12" runat="server"/>
                        <input id="hdnINS_DATE_13" type="hidden" name="hdnINS_DATE_13" runat="server"/><input id="hdnINS_DATE_14" type="hidden" name="hdnINS_DATE_14" runat="server"/>
                        <input id="hdnINS_DATE_15" type="hidden" name="hdnINS_DATE_15" runat="server"/><input id="hdnINS_DATE_16" type="hidden" name="hdnINS_DATE_16" runat="server"/>
                        <input id="hdnINS_DATE_17" type="hidden" name="hdnINS_DATE_17" runat="server"/><input id="hdnINS_DATE_18" type="hidden" name="hdnINS_DATE_18" runat="server"/>
                        <input id="hdnINS_DATE_19" type="hidden" name="hdnINS_DATE_19" runat="server"/><input id="hdnINS_DATE_20" type="hidden" name="hdnINS_DATE_20" runat="server"/>
                        <input id="hdnINS_DATE_21" type="hidden" name="hdnINS_DATE_21" runat="server"/><input id="hdnINS_DATE_22" type="hidden" name="hdnINS_DATE_22" runat="server"/>
                        <input id="hdnINS_DATE_23" type="hidden" name="hdnINS_DATE_23" runat="server"/><input id="hdnINS_DATE_24" type="hidden" name="hdnINS_DATE_24" runat="server"/>
                        <input id="hdnINS_DATE_25" type="hidden" name="hdnINS_DATE_25" runat="server"/><input id="hdnINS_DATE_26" type="hidden" name="hdnINS_DATE_26" runat="server"/>
                        <input id="hdnINS_DATE_27" type="hidden" name="hdnINS_DATE_27" runat="server"/><input id="hdnINS_DATE_28" type="hidden" name="hdnINS_DATE_28" runat="server"/>
                        <input id="hdnINS_DATE_29" type="hidden" name="hdnINS_DATE_29" runat="server"/><input id="hdnINS_DATE_30" type="hidden" name="hdnINS_DATE_30" runat="server"/>
                        <input id="hdnINS_USER_1" type="hidden" name="hdnINS_USER_1" runat="server"/><input id="hdnINS_USER_2" type="hidden" name="hdnINS_USER_2" runat="server"/>
                        <input id="hdnINS_USER_3" type="hidden"	name="hdnINS_USER_3" runat="server"/><input id="hdnINS_USER_4" type="hidden"	name="hdnINS_USER_4" runat="server"/>
                        <input id="hdnINS_USER_5" type="hidden"	name="hdnINS_USER_5" runat="server"/><input id="hdnINS_USER_6" type="hidden"	name="hdnINS_USER_6" runat="server"/>
                        <input id="hdnINS_USER_7" type="hidden"	name="hdnINS_USER_7" runat="server"/><input id="hdnINS_USER_8" type="hidden"	name="hdnINS_USER_8" runat="server"/>
                        <input id="hdnINS_USER_9" type="hidden"	name="hdnINS_USER_9" runat="server"/><input id="hdnINS_USER_10" type="hidden" name="hdnINS_USER_10" runat="server"/>
                        <input id="hdnINS_USER_11" type="hidden" name="hdnINS_USER_11" runat="server"/><input id="hdnINS_USER_12" type="hidden" name="hdnINS_USER_12" runat="server"/>
                        <input id="hdnINS_USER_13" type="hidden" name="hdnINS_USER_13" runat="server"/><input id="hdnINS_USER_14" type="hidden" name="hdnINS_USER_14" runat="server"/>
                        <input id="hdnINS_USER_15" type="hidden" name="hdnINS_USER_15" runat="server"/><input id="hdnINS_USER_16" type="hidden" name="hdnINS_USER_16" runat="server"/>
                        <input id="hdnINS_USER_17" type="hidden" name="hdnINS_USER_17" runat="server"/><input id="hdnINS_USER_18" type="hidden" name="hdnINS_USER_18" runat="server"/>
                        <input id="hdnINS_USER_19" type="hidden" name="hdnINS_USER_19" runat="server"/><input id="hdnINS_USER_20" type="hidden" name="hdnINS_USER_20" runat="server"/>
                        <input id="hdnINS_USER_21" type="hidden" name="hdnINS_USER_21" runat="server"/><input id="hdnINS_USER_22" type="hidden" name="hdnINS_USER_22" runat="server"/>
                        <input id="hdnINS_USER_23" type="hidden" name="hdnINS_USER_23" runat="server"/><input id="hdnINS_USER_24" type="hidden" name="hdnINS_USER_24" runat="server"/>
                        <input id="hdnINS_USER_25" type="hidden" name="hdnINS_USER_25" runat="server"/><input id="hdnINS_USER_26" type="hidden" name="hdnINS_USER_26" runat="server"/>
                        <input id="hdnINS_USER_27" type="hidden" name="hdnINS_USER_27" runat="server"/><input id="hdnINS_USER_28" type="hidden" name="hdnINS_USER_28" runat="server"/>
                        <input id="hdnINS_USER_29" type="hidden" name="hdnINS_USER_29" runat="server"/><input id="hdnINS_USER_30" type="hidden" name="hdnINS_USER_30" runat="server"/>
                        <input id="hdnUPD_DATE_1" type="hidden" name="hdnUPD_DATE_1" runat="server"/><input id="hdnUPD_DATE_2" type="hidden" name="hdnUPD_DATE_2" runat="server"/>
                        <input id="hdnUPD_DATE_3" type="hidden"	name="hdnUPD_DATE_3" runat="server"/><input id="hdnUPD_DATE_4" type="hidden"	name="hdnUPD_DATE_4" runat="server"/>
                        <input id="hdnUPD_DATE_5" type="hidden"	name="hdnUPD_DATE_5" runat="server"/><input id="hdnUPD_DATE_6" type="hidden"	name="hdnUPD_DATE_6" runat="server"/>
                        <input id="hdnUPD_DATE_7" type="hidden"	name="hdnUPD_DATE_7" runat="server"/><input id="hdnUPD_DATE_8" type="hidden"	name="hdnUPD_DATE_8" runat="server"/>
                        <input id="hdnUPD_DATE_9" type="hidden"	name="hdnUPD_DATE_9" runat="server"/><input id="hdnUPD_DATE_10" type="hidden" name="hdnUPD_DATE_10" runat="server"/>
                        <input id="hdnUPD_DATE_11" type="hidden" name="hdnUPD_DATE_11" runat="server"/><input id="hdnUPD_DATE_12" type="hidden" name="hdnUPD_DATE_12" runat="server"/>
                        <input id="hdnUPD_DATE_13" type="hidden" name="hdnUPD_DATE_13" runat="server"/><input id="hdnUPD_DATE_14" type="hidden" name="hdnUPD_DATE_14" runat="server"/>
                        <input id="hdnUPD_DATE_15" type="hidden" name="hdnUPD_DATE_15" runat="server"/><input id="hdnUPD_DATE_16" type="hidden" name="hdnUPD_DATE_16" runat="server"/>
                        <input id="hdnUPD_DATE_17" type="hidden" name="hdnUPD_DATE_17" runat="server"/><input id="hdnUPD_DATE_18" type="hidden" name="hdnUPD_DATE_18" runat="server"/>
                        <input id="hdnUPD_DATE_19" type="hidden" name="hdnUPD_DATE_19" runat="server"/><input id="hdnUPD_DATE_20" type="hidden" name="hdnUPD_DATE_20" runat="server"/>
                        <input id="hdnUPD_DATE_21" type="hidden" name="hdnUPD_DATE_21" runat="server"/><input id="hdnUPD_DATE_22" type="hidden" name="hdnUPD_DATE_22" runat="server"/>
                        <input id="hdnUPD_DATE_23" type="hidden" name="hdnUPD_DATE_23" runat="server"/><input id="hdnUPD_DATE_24" type="hidden" name="hdnUPD_DATE_24" runat="server"/>
                        <input id="hdnUPD_DATE_25" type="hidden" name="hdnUPD_DATE_25" runat="server"/><input id="hdnUPD_DATE_26" type="hidden" name="hdnUPD_DATE_26" runat="server"/>
                        <input id="hdnUPD_DATE_27" type="hidden" name="hdnUPD_DATE_27" runat="server"/><input id="hdnUPD_DATE_28" type="hidden" name="hdnUPD_DATE_28" runat="server"/>
                        <input id="hdnUPD_DATE_29" type="hidden" name="hdnUPD_DATE_29" runat="server"/><input id="hdnUPD_DATE_30" type="hidden" name="hdnUPD_DATE_30" runat="server"/>
                        <input id="hdnUPD_USER_1" type="hidden" name="hdnUPD_USER_1" runat="server"/><input id="hdnUPD_USER_2" type="hidden" name="hdnUPD_USER_2" runat="server"/>
                        <input id="hdnUPD_USER_3" type="hidden"	name="hdnUPD_USER_3" runat="server"/><input id="hdnUPD_USER_4" type="hidden"	name="hdnUPD_USER_4" runat="server"/>
                        <input id="hdnUPD_USER_5" type="hidden"	name="hdnUPD_USER_5" runat="server"/><input id="hdnUPD_USER_6" type="hidden"	name="hdnUPD_USER_6" runat="server"/>
                        <input id="hdnUPD_USER_7" type="hidden"	name="hdnUPD_USER_7" runat="server"/><input id="hdnUPD_USER_8" type="hidden"	name="hdnUPD_USER_8" runat="server"/>
                        <input id="hdnUPD_USER_9" type="hidden"	name="hdnUPD_USER_9" runat="server"/><input id="hdnUPD_USER_10" type="hidden" name="hdnUPD_USER_10" runat="server"/>
                        <input id="hdnUPD_USER_11" type="hidden" name="hdnUPD_USER_11" runat="server"/><input id="hdnUPD_USER_12" type="hidden" name="hdnUPD_USER_12" runat="server"/>
                        <input id="hdnUPD_USER_13" type="hidden" name="hdnUPD_USER_13" runat="server"/><input id="hdnUPD_USER_14" type="hidden" name="hdnUPD_USER_14" runat="server"/>
                        <input id="hdnUPD_USER_15" type="hidden" name="hdnUPD_USER_15" runat="server"/><input id="hdnUPD_USER_16" type="hidden" name="hdnUPD_USER_16" runat="server"/>
                        <input id="hdnUPD_USER_17" type="hidden" name="hdnUPD_USER_17" runat="server"/><input id="hdnUPD_USER_18" type="hidden" name="hdnUPD_USER_18" runat="server"/>
                        <input id="hdnUPD_USER_19" type="hidden" name="hdnUPD_USER_19" runat="server"/><input id="hdnUPD_USER_20" type="hidden" name="hdnUPD_USER_20" runat="server"/>
                        <input id="hdnUPD_USER_21" type="hidden" name="hdnUPD_USER_21" runat="server"/><input id="hdnUPD_USER_22" type="hidden" name="hdnUPD_USER_22" runat="server"/>
                        <input id="hdnUPD_USER_23" type="hidden" name="hdnUPD_USER_23" runat="server"/><input id="hdnUPD_USER_24" type="hidden" name="hdnUPD_USER_24" runat="server"/>
                        <input id="hdnUPD_USER_25" type="hidden" name="hdnUPD_USER_25" runat="server"/><input id="hdnUPD_USER_26" type="hidden" name="hdnUPD_USER_26" runat="server"/>
                        <input id="hdnUPD_USER_27" type="hidden" name="hdnUPD_USER_27" runat="server"/><input id="hdnUPD_USER_28" type="hidden" name="hdnUPD_USER_28" runat="server"/>
                        <input id="hdnUPD_USER_29" type="hidden" name="hdnUPD_USER_29" runat="server"/><input id="hdnUPD_USER_30" type="hidden" name="hdnUPD_USER_30" runat="server"/>
					</td>
				</tr>
			</table>
			<hr>
            <table cellSpacing="1" cellPadding="3" width="1150">
				<tr>
					<td width="5">&nbsp;</td>
					<td width="125" class="TXTKY" align="right" style="font-size:15px;">クライアントコード&nbsp;&nbsp;</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                    <td width="350"><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
							BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabindex="1" type="button" value="▼" name="btnKURACD" runat="server" />
                            <input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server" />
						    <input id="hdnKURACD_MOTO" type="hidden" name="hdnKURACD_MOTO" runat="server" />
					</td>
					<td rowspan="4" class="style1">
						<div style="BORDER-RIGHT:black 1px dotted; BORDER-TOP:black 1px dotted; Z-INDEX:1; BORDER-LEFT:black 1px dotted; WIDTH:350px; BORDER-BOTTOM:black 1px dotted; BACKGROUND-COLOR:#edffdb">
							<div>
								ファイル登録 <INPUT type="file" ID="FileUpload1" name="FileUpload1" width="60px">
								<asp:Button ID="btnFileUpload" runat="server" Text="upload" />
							</div>
							<br>
                            <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                            <asp:textbox id="hdnFileKey" Visible="False" runat="server"></asp:textbox>
							<asp:textbox id="txtFileName1" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
								BorderWidth="1px"></asp:textbox><asp:button ID="btnFileDownload1" runat="server" text="開く" /><asp:button ID="btnFileDelete1" runat="server" text="削除" /><br>
							<asp:textbox id="txtFileName2" tabIndex="-1" runat="server" CssClass="c-rNM" Width="250px" BorderStyle="Solid"
								BorderWidth="1px"></asp:textbox><asp:button ID="btnFileDownload2" runat="server" text="開く" /><asp:button ID="btnFileDelete2" runat="server" text="削除" />
						</div>
					</td>
					<td rowspan="4">
					</td>
				</tr>
				<tr>
					<td></td>
					<td align="right" style="font-size:15px;">ＪＡ支所コード&nbsp;&nbsp;</td>
                    <td><asp:textbox id="txtACBCD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid"
							BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnACBCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="2" type="button" value="▼" name="btnACBCD" runat="server"> <INPUT id="hdnACBCD" type="hidden" name="hdnACBCD" runat="server">
						<INPUT id="hdnACBCD_MOTO" type="hidden" name="hdnACBCD_MOTO" runat="server">
					</td>
				</tr>
    			<tr>
					<td></td>
					<td class="TXTKY" align="right"  style="font-size:13px;">グループコード・名称&nbsp;&nbsp;</td>
                    <td><asp:textbox id="txtGROUPCD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="300px" BorderStyle="Solid"
							BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnGROUPCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabIndex="3" type="button" value="▼" name="btnGROUPCD" runat="server"> <INPUT id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server">
						<INPUT id="hdnGROUPCD_MOTO" type="hidden" name="hdnGROUPCD_MOTO" runat="server">
					</td>
				</tr>
				<tr>
					<td class="style3"></td>
					<td class="style3" align="right" style="font-size:13px;">グループコード&nbsp;&nbsp;<br />（新規登録用）&nbsp;&nbsp;</td>
                    <td class="style3"><asp:textbox id="txtGROUPNEW" onkeydown="fncFc(this)"  onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
                            tabIndex="4" runat="server" CssClass="c-f" Width="300px" BorderStyle="Solid" BorderWidth="1px" MaxLength="30">
                            </asp:textbox><INPUT id="hdnGROUPNEW_MOTO" type="hidden" name="hdnGROUPNEW_MOTO" runat="server"></td>
				</tr>
                <tr>
                    <td></td>
					<td align="right" style="font-size:13px;">グループ内確認&nbsp;&nbsp;</td>
                    <td><input class="bt-RNW" id="btnTOUROKUZUMI" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnTOUROKUZUMI_onclick();"
							tabindex="5" type="button" value="登録JA支所" name="btnTOUROKUZUMI" runat="server"/></td>
                    <td align="right"><span id="spS1"><a href="MSTAGJAG00_K.pdf" tabIndex="6" target="_blank"><img src="../../../Script/icon_pdf.gif" border="0"/>マニュアル&nbsp;&nbsp;</a></span>
                    <span id="spS2"><a href="MSTAGJAG00_O.pdf" tabIndex="6" target="_blank"><img src="../../../Script/icon_pdf.gif" border="0">/マニュアル&nbsp;&nbsp;</a></span></td>
                    <td></td>         
                </tr>         
			</table>
			<INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"> 
			<!-- タブ対応 -->
            <input id="hdntab" type="hidden" name="hdntab" runat="server"/>
            <ul id="tab">
				<li id="tab1" class="present">
					<a href="#page1">JA担当者・ｽﾎﾟｯﾄFAX</a></li>
				<li id="tab2">
                    <a href="#page2" ><asp:label id="Label1" Runat="server" Text="自動FAX&ﾒｰﾙ"></asp:label></a></li>
				<li id="tab3">
					<a href="#page3" ><asp:label id="Label2" Runat="server" Text="注意事項"></asp:label></a></li>
				<li id="tab4">
					<a href="#page4" ><asp:label id="Label3" Runat="server" Text="報告要・不要初期値"></asp:label></a></li>
			</ul>
			<!-- タブ対応 -->
			<div id="page1">
                <table width="500px">
                    <tr>
                        <td width="480px"><input class="bt-RNW" id="btnICHIRAN_COPY" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncIchiran_Copy()"
							tabindex="7" type="button" value="コピー" name="btnICHIRAN_COPY" runat="server"/>
                            <input class="bt-RNW" id="btnICHIRAN_PASTE" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncIchiran_Paste()"
							tabindex="8" type="button" value="ペースト" name="btnICHIRAN_PASTE" runat="server"/>
                            <input class="bt-RNW" id="btnICHIRAN_CLEAR" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncIchiran_Clear()"
							tabindex="9" type="button" value="クリア" name="btnICHIRAN_CLEAR" runat="server"/></td>
                        <td>
                        </td>
                    </tr>
                    <tr>
						<td align="left" height="25">&nbsp;&nbsp;グループコード名&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:textbox id="txtGROUPNM" onkeydown="fncFc(this)"  onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
                            tabIndex="10" runat="server" CssClass="c-hI" Width="300px" MaxLength="60" BorderStyle="Solid" BorderWidth="1px"></asp:textbox></td>
	                    <td></td>
					</tr>
                </table>
				<table cellSpacing="0" cellPadding="0">
					<tr id="koumoku">
						<td id="DispAlwy_100" align="left" height="25">ｺﾋﾟﾍﾟ </td>
						<td id="DispAlwy_1" align="left" height="25">ｺｰﾄﾞ</td>
						<td id="DispAlwy_2" align="left" height="25">&nbsp;&nbsp;担当者名漢字</td>
						<td id="DispSpot_1" align="left" height="25">電話番号１</td>
						<td id="DispSpot_2" align="left" height="25">電話番号２</td>
						<td id="DispSpot_3" align="left" height="25">電話番号３</td>
                        <td id="DispSpot_4" align="left" height="25">ｽﾎﾟｯﾄFAX番号</td>
						<td id="DispSpot_5" align="left" height="25">記事(※印刷対象外)</td>
						<td id="DispSpot_6" align="left" height="25">ｽﾎﾟｯﾄFAX送信先ﾒｰﾙｱﾄﾞﾚｽ</td>
						<td id="DispSpot_7" align="left" height="25" width="100px">ｽﾎﾟｯﾄFAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ</td>
					</tr>
					<tr id="list_1">
                        <hr />
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_1" tabIndex="101" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><INPUT id="hdnDISP_NO_1" type="hidden" name="hdnDISP_NO_1" runat="server">
							<asp:textbox id="txtTANCD_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_1" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="102" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="103" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="104" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="105" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="106" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="107" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="108" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="109" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
					</tr>
					<tr id="list_2">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_2" tabIndex="121" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><INPUT id="hdnDISP_NO_2" type="hidden" name="hdnDISP_NO_2" runat="server">
							<asp:textbox id="txtTANCD_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_2" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="122" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="123" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="124" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL3_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="125" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtFAXNO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="126" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="127" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="128" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="129" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
					</tr>
					<tr id="list_3">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_3" tabIndex="141" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><INPUT id="hdnDISP_NO_3" type="hidden" name="hdnDISP_NO_3" runat="server">
							<asp:textbox id="txtTANCD_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_3" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="142" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="143" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="144" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="145" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="146" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="147" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="148" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="149" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_4">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_4" tabIndex="161" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><INPUT id="hdnDISP_NO_4" type="hidden" name="hdnDISP_NO_4" runat="server">
							<asp:textbox id="txtTANCD_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_4" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="162" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="163" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="164" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="165" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="166" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="167" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="168" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="169" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_5">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_5" tabIndex="181" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
					    <td><INPUT id="hdnDISP_NO_5" type="hidden" name="hdnDISP_NO_5" runat="server">
							<asp:textbox id="txtTANCD_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_5" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="182" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="183" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="184" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="185" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="186" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="187" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="188" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="189" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_6">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_6" tabIndex="201" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_6" type="hidden" name="hdnDISP_NO_6" runat="server">
							<asp:textbox id="txtTANCD_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_6" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="202" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="203" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="204" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="205" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="206" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="207" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="208" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="209" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_7">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_7" tabIndex="221" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_7" type="hidden" name="hdnDISP_NO_7" runat="server">
							<asp:textbox id="txtTANCD_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_7" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="222" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="223" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="224" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="225" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="226" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="227" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="228" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="229" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_8">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_8" tabIndex="241" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_8" type="hidden" name="hdnDISP_NO_8" runat="server">
							<asp:textbox id="txtTANCD_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_8" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="242" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="243" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="244" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="245" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="246" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="247" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="248" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="249" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_9">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_9" tabIndex="261" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_9" type="hidden" name="hdnDISP_NO_9" runat="server">
							<asp:textbox id="txtTANCD_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_9" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="262" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="263" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="264" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="265" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="266" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="267" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="268" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="269" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_10">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_10" tabIndex="281" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_10" type="hidden" name="hdnDISP_NO_10" runat="server">
							<asp:textbox id="txtTANCD_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="282" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="283" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="284" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="285" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="286" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="287" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="288" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="289" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_11">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_11" tabIndex="301" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_11" type="hidden" name="hdnDISP_NO_11" runat="server">
							<asp:textbox id="txtTANCD_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="302" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="303" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="304" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="305" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="306" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="307" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="308" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="309" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_12">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_12" tabIndex="321" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_12" type="hidden" name="hdnDISP_NO_12" runat="server">
							<asp:textbox id="txtTANCD_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="322" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="323" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="324" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="325" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="326" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="327" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="328" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="329" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_13">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_13" tabIndex="341" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_13" type="hidden" name="hdnDISP_NO_13" runat="server">
							<asp:textbox id="txtTANCD_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="342" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="343" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="344" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="345" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="346" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="347" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="348" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="349" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_14">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_14" tabIndex="361" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_14" type="hidden" name="hdnDISP_NO_14" runat="server">
							<asp:textbox id="txtTANCD_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="362" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="363" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="364" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="365" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="366" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="367" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="368" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="369" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_15">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_15" tabIndex="381" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_15" type="hidden" name="hdnDISP_NO_15" runat="server">
							<asp:textbox id="txtTANCD_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="382" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="383" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="384" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="385" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="386" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="387" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
                        <td><asp:textbox id="txtSPOT_MAIL_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="388" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="389" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_16">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_16" tabIndex="401" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_16" type="hidden" name="hdnDISP_NO_16" runat="server">
							<asp:textbox id="txtTANCD_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="402" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="403" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="404" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="405" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="406" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="407" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="408" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="409" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_17">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_17" tabIndex="421" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_17" type="hidden" name="hdnDISP_NO_17" runat="server">
							<asp:textbox id="txtTANCD_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="422" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="423" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="424" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="425" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="426" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="427" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="428" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="429" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_18">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_18" tabIndex="441" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_18" type="hidden" name="hdnDISP_NO_18" runat="server">
							<asp:textbox id="txtTANCD_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="442" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="443" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="444" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="445" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="446" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="447" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="448" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="449" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_19">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_19" tabIndex="461" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_19" type="hidden" name="hdnDISP_NO_19" runat="server">
							<asp:textbox id="txtTANCD_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="462" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="463" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="464" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="465" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="466" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="467" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="468" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="469" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_20">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_20" tabIndex="481" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_20" type="hidden" name="hdnDISP_NO_20" runat="server">
							<asp:textbox id="txtTANCD_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="482" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="483" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="484" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="485" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="486" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="487" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="488" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="489" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr>
						<td colspan="6">↓21～30は印刷対象外↓</td>
					</tr>
					<tr id="list_21">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_21" tabIndex="501" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_21" type="hidden" name="hdnDISP_NO_21" runat="server">
							<asp:textbox id="txtTANCD_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="502" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="503" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="504" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="505" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="506" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="507" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="508" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="509" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_22">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_22" tabIndex="521" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_22" type="hidden" name="hdnDISP_NO_22" runat="server">
							<asp:textbox id="txtTANCD_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="522" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="523" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="524" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="525" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="526" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="527" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="528" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="529" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_23">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_23" tabIndex="541" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_23" type="hidden" name="hdnDISP_NO_23" runat="server">
							<asp:textbox id="txtTANCD_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="542" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="543" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="544" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="545" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="546" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="547" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="548" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="549" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_24">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_24" tabIndex="561" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_24" type="hidden" name="hdnDISP_NO_24" runat="server">
							<asp:textbox id="txtTANCD_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>  
						<td><asp:textbox id="txtTANNM_24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="562" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="563" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="564" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="565" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="566" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="567" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="568" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="569" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_25">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_25" tabIndex="581" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_25" type="hidden" name="hdnDISP_NO_25" runat="server">
							<asp:textbox id="txtTANCD_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="582" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="583" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="584" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="585" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="586" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="587" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="588" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="589" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_26">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_26" tabIndex="601" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_26" type="hidden" name="hdnDISP_NO_26" runat="server">
							<asp:textbox id="txtTANCD_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="602" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="603" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="604" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="605" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="606" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="607" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="608" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="609" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_27">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_27" tabIndex="621" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_27" type="hidden" name="hdnDISP_NO_27" runat="server">
							<asp:textbox id="txtTANCD_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="622" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="623" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="624" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="625" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="626" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="627" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="628" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="629" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_28">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_28" tabIndex="641" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_28" type="hidden" name="hdnDISP_NO_28" runat="server">
							<asp:textbox id="txtTANCD_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="642" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="643" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="644" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="645" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="646" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="647" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="648" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="649" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_29">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_29" tabIndex="661" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_29" type="hidden" name="hdnDISP_NO_29" runat="server">
							<asp:textbox id="txtTANCD_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="662" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="663" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="664" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="665" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="666" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="667" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="668" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="669" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
					<tr id="list_30">
                        <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                        <td><asp:checkbox id="chkCopy_30" tabIndex="681" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
						<td><INPUT id="hdnDISP_NO_30" type="hidden" name="hdnDISP_NO_30" runat="server">
							<asp:textbox id="txtTANCD_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
						<td><asp:textbox id="txtTANNM_30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="682" runat="server" CssClass="c-hI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL1_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="683" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtRENTEL2_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="684" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtRENTEL3_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="685" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><asp:textbox id="txtFAXNO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="686" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
						<td><asp:textbox id="txtBIKO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="687" runat="server" CssClass="c-fI" Width="300px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtSPOT_MAIL_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="688" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
						<td><asp:textbox id="txtMAIL_PASS_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="689" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                    </tr>
				</table>
			</div>
			<div id="page2">
                <table width="500px">
                    <tr>
                        <td width="480px"><input class="bt-RNW" id="btnATICHIRAN_COPY" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncAtIchiran_Copy()"
							tabindex="997" type="button" value="コピー" name="btnATICHIRAN_COPY" runat="server"/>
                            <input class="bt-RNW" id="btnATICHIRAN_PASTE" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncAtIchiran_Paste()"
							tabindex="998" type="button" value="ペースト" name="btnATICHIRAN_PASTE" runat="server"/>
                            <input class="bt-RNW" id="btnIATCHIRAN_CLEAR" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncAtIchiran_Clear()"
							tabindex="999" type="button" value="クリア" name="btnIATCHIRAN_CLEAR" runat="server"/></td>
                    </tr>
                </table>

            	<table cellSpacing="0" cellPadding="0">
					<tr>
                        <td align="left" height="25"  Width="32px">ｺﾋﾟﾍﾟ </td> 
						<td align="left" height="25">ｺｰﾄﾞ</td>
                        <td align="left" height="25">&nbsp;&nbsp;自動FAX送信名</td>
                        <td align="left" height="25">自動FAX送信先ﾒｰﾙｱﾄﾞﾚｽ</td>
                        <td align="left" height="25" width="100px">自動FAX添付ﾌｧｲﾙﾊﾟｽﾜｰﾄﾞ</td>
                        <td align="left" height="25">自動FAX番号</td>
                        <td align="left" height="25">自動送信区分</td>
                        <td align="left" height="25">ゼロ件送信フラグ</td>
                        <td align="left" height="25">出動依頼内容・備考</td>  <!-- 2020/11/01 T.Ono add 2020監視改善 -->
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_1" tabIndex="1001" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_1" text="01" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1002" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1003" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1004" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1005" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1006" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1007" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <!-- 2020/11/01 T.Ono add 2020監視改善 出動依頼内容・備考印字フラグ追加-->
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1008" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_2" tabIndex="1011" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_2" text="02" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                    	<td><asp:textbox id="txtAUTO_FAXNM_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1012" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1013" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1014" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1015" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1016" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1017" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1018" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_3" tabIndex="1021" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_3" text="03" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabindex="1022" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1023" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1024" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1025" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1026" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1027" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1028" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_4" tabIndex="1031" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_4" text="04" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabindex="1032" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1033" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1034" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1035" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1036" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1037" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_4" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1038" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_5" tabIndex="1041" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_5" text="05" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabindex="1042" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1043" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1044" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabindex="1045" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1046" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1047" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_5" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1048" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_6" tabIndex="1051" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_6" text="06" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1052" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1053" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1054" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1055" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1056" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1057" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_6" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1058" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_7" tabIndex="1061" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_7" text="07" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1062" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1063" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1064" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1065" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1066" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1067" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_7" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1068" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_8" tabIndex="1071" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_8" text="08" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1072" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1073" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1074" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1075" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1076" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1077" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_8" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1078" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_9" tabIndex="1081" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_9" text="09" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1082" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1083" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1084" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1085" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1086" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1087" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_9" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1088" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_10" tabIndex="1091" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_10" text="10" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1092" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1093" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1094" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1095" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1096" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1097" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_10" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1098" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_11" tabIndex="1101" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_11" text="11" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1102" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1103" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1104" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1105" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1106" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1107" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_11" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1108" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_12" tabIndex="1111" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_12" text="12" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1112" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1113" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1114" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1115" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1116" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1117" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_12" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1118" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_13" tabIndex="1121" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_13" text="13" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1122" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1123" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1124" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1125" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1126" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1127" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_13" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1128" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_14" tabIndex="1131" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_14" text="14" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1132" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1133" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1134" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1135" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1136" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1137" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_14" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1138" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_15" tabIndex="1141" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_15" text="15" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1142" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1143" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1144" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1145" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1146" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1147" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_15" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1148" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_16" tabIndex="1151" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_16" text="16" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1152" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1153" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1154" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1155" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1156" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1157" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_16" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1158" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_17" tabIndex="1161" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_17" text="17" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1162" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1163" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1164" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1165" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1166" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1167" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_17" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1168" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_18" tabIndex="1171" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_18" text="18" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1172" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1173" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1174" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1175" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1176" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1177" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_18" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1178" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_19" tabIndex="1181" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_19" text="19" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1182" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1183" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1184" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1185" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1186" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1187" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_19" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1188" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_20" tabIndex="1191" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_20" text="20" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1192" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1193" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1194" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1195" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1196" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1197" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_20" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1198" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
						<td></td><td colspan="6">↓21～30は印刷対象外↓</td>
					</tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_21" tabIndex="1201" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_21" text="21" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1202" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1203" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1204" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1205" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1206" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1207" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_21" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1208" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_22" tabIndex="1211" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_22" text="22" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1212" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1213" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1214" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1215" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1216" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1217" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_22" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1218" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_23" tabIndex="1221" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_23" text="23" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1222" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1223" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1224" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1225" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1226" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1227" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_23" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1228" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_24" tabIndex="1231" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_24" text="24" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1232" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1233" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1234" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1235" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1236" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1237" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_24" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1238" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_25" tabIndex="1241" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_25" text="25" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1242" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1243" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1244" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1245" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1246" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1247" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_25" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1248" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_26" tabIndex="1251" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_26" text="26" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1252" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1253" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1254" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1255" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1256" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1257" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_26" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1258" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_27" tabIndex="1261" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_27" text="27" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1262" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1263" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1264" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1265" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1266" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1267" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_27" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1268" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_28" tabIndex="1271" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_28" text="28" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1272" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1273" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1274" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1275" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1276" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1277" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_28" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1278" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_29" tabIndex="1281" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_29" text="29" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1282" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1283" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1284" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1285" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1286" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1287" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_29" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1288" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                    <tr>
                        <td><asp:checkbox id="chkAtCopy_30" tabIndex="1291" runat="server" Width="32px" onkeydown="fncFc(this)" /></td>
                        <td><asp:textbox id="txtTANCD2_30" text="30" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="-1" runat="server" CssClass="c-RO" Width="26px" MaxLength="4"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNM_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1292" runat="server" CssClass="c-fI" Width="250px" MaxLength="30"></asp:textbox></td>
						<td><asp:textbox id="txtAUTO_MAIL_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1293" runat="server" CssClass="c-f" Width="200px" MaxLength="50"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_MAIL_PASS_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1294" runat="server" CssClass="c-f" Width="100px" MaxLength="10"></asp:textbox></td>
                        <td><asp:textbox id="txtAUTO_FAXNO_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="1295" runat="server" CssClass="c-f" Width="120px" MaxLength="15"></asp:textbox></td>
                        <td><cc1:ctlcombo id="cboAUTO_KBN_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1296" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                        <td><cc1:ctlcombo id="cboAUTO_ZERO_FLG_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1297" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td>
                        <td><cc1:ctlcombo id="cboSD_PRT_FLG_30" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" 
		                        tabindex="1298" runat="server" width="120px" cssclass="cb"></cc1:ctlcombo></td> 
                    </tr>
                </table>
			</div>
			<div id="page3">
				<table>
                    <tr>
     					<td valign="top" style="height:25px;" colspan="3"><b><asp:RadioButton id="guidelineClck1" tabIndex="1301" runat="server" groupName="guidelineClck" value="1" Checked="true" onclick="chkGuidelineRadio_onclick()" Text="JA注意事項1"/><asp:RadioButton id="guidelineClck2" tabIndex="1301" runat="server" groupName="guidelineClck" value="2"  onclick="chkGuidelineRadio_onclick()" Text="JA注意事項2"/><asp:RadioButton id="guidelineClck3" tabIndex="1301" runat="server" groupName="guidelineClck" value="3"  onclick="chkGuidelineRadio_onclick()" Text="JA注意事項3"/></b></td>
                    </tr>
                    <!-- 2020/10/05 T.Ono add 監視改善2020 Start -->
                    <tr>
                        <td align="right" class="style2">
                            <b><asp:label id="lblguidelineNM" style="font-size:10pt" Runat="server" Text="ボタン名称"></asp:label></b><br>
                        </td>
                        <td style="font-size:10pt" colspan=2>
                            &nbsp;&nbsp;１&nbsp;&nbsp;<asp:textbox id="txtGUIDELINENM1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1302" runat="server" CssClass="c-fI" Width="170px" MaxLength="20"></asp:textbox>
                            &nbsp;&nbsp;２&nbsp;&nbsp;<asp:textbox id="txtGUIDELINENM2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1303" runat="server" CssClass="c-fI" Width="170px" MaxLength="20"></asp:textbox>
                            &nbsp;&nbsp;３&nbsp;&nbsp;<asp:textbox id="txtGUIDELINENM3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
				                tabIndex="1304" runat="server" CssClass="c-fI" Width="170px" MaxLength="20"></asp:textbox>
                        </td>
                    </tr>
                    <!-- 2020/10/05 T.Ono add 監視改善2020 End -->
					<tr valign="top">
						<td align="right" class="style2">
                            <b><asp:label id="lblpre" style="font-size:10pt" Runat="server" Text="JA注意事項"></asp:label></b><br>
							<br>
							<input id="btnTips" style="BACKGROUND-COLOR:buttonface" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
								onclick="return btnTips_onclick();" tabIndex="1305" type="button" value="tips" name="btnTips"
								runat="server"> 
							 <input style="BACKGROUND-COLOR:buttonface" id="preview" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
								onclick="hpre(txtGUIDELINE);" tabIndex="1306" type="button" value="プレビュー" name="preview"
								runat="server"> 
						</td>
						<td>
							<asp:textbox id="txtGUIDELINE" name="txtGUIDELINE" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								TabIndex="1307" Runat="server" TextMode="MultiLine" Columns="40" Rows="25" />
   							<asp:textbox id="txtGUIDELINE2" name="txtGUIDELINE2" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								TabIndex="1307" Runat="server" TextMode="MultiLine" Columns="40" Rows="25" style="display:none;"/>
   							<asp:textbox id="txtGUIDELINE3" name="txtGUIDELINE3" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								TabIndex="1307" Runat="server" TextMode="MultiLine" Columns="40" Rows="25" style="display:none;"/>
						</td>
                        <td nowrap width="400" height="420">
							<asp:label id="pre" class="preview" width="400" height="420" Runat="server"></asp:label><!-- プレビュー領域 -->
						</td>
					</tr>
				</table>
			</div>
			<div id="page4">
                <table >
                    <tr><td height="20px"></td></tr>
				    <tr>
                        <td width="30px"></td>
                        <td>
                            <table cellSpacing="1" cellPadding="3" class="W">
                                <tr><td colspan="3">（ 報告要・不要初期値 ）</td></tr>
				                <tr>
                                    <td width="20px"></td>
					                <td align="right">JA&nbsp;&nbsp;</td>
					                <td vAlign="middle"><input id="rdoFAXJA1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							                tabIndex="1311" type="radio" value="1" name="rdoFAXJA" runat="server" /></td>
					                <td vAlign="middle"><label for="rdoFAXJA1">必要&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
					                <td vAlign="middle"><input id="rdoFAXJA2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							                tabIndex="1311" type="radio" value="2" name="rdoFAXJA" runat="server" /></td>
					                <td vAlign="middle"><label for="rdoFAXJA2">不要&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                    <input id="hdnFAXJA_MOTO" type="hidden" name="hdnFAXJA_MOTO" value="9" runat="server"/>
                                    </td>
				                </tr>
				                <tr>
                                    <td width="20px"></td>
					                <td align="right">ｸﾗｲｱﾝﾄ&nbsp;&nbsp;</td>
					                <td vAlign="middle"><input id="rdoFAXKURA1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							                tabIndex="1312" type="radio" value="1" name="rdoFAXKURA" runat="server" /></td>
					                <td vAlign="middle"><label for="rdoFAXKURA1">必要&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
					                <td vAlign="middle"><input id="rdoFAXKURA2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							                tabIndex="1312" type="radio" value="2" name="rdoFAXKURA" runat="server" /></td>
					                <td vAlign="middle"><label for="rdoFAXKURA2">不要&nbsp;&nbsp;&nbsp;&nbsp;</label>
                                    <input id="hdnFAXKURA_MOTO" type="hidden" name="hdnFAXKURA_MOTO" value="9" runat="server"/>
                                    </td>
				                </tr>

                            </table>
                        </td>
				    </tr>
			    </table>
			</div>
		</form>
		<!-- タブ切替用変数の設定 -->
		<script type="text/javascript">
		// <![CDATA[
			tab.setup = {
				tabs: document.getElementById('tab').getElementsByTagName('li'),
				pages: [
					document.getElementById('page1'),
					document.getElementById('page2'),
					document.getElementById('page3'),
					document.getElementById('page4')
				]
			}

			tab.init();
		// ]]>
		</script>
        <script type="text/javascript">

		</script>
	</body>
</HTML>
