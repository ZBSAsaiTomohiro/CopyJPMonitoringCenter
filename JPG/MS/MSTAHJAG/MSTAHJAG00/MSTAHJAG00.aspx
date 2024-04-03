<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTAHJAG00.aspx.vb" Inherits="JPG.MSTAHJAG00.MSTAHJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSTAHJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><%-- 2017/07/20 H.Mori hdnBackUrlをadd --%><INPUT id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server"><br>
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
										type="button" value="終了" name="btnExit" runat="server" tabindex="91"/>
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
											<td class="TITLE" vAlign="middle">ＪＡ担当者連絡先エクセル出力</td>
										</tr>
									</table>
								</td>
								<td width="170">&nbsp;</td>
							</tr>
						</table>
						<INPUT id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server"/><INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"/>
					</td>
				</tr>
			</table>
			<hr>
			<table id="Table5" cellSpacing="1" cellPadding="2" width="900">
				<tr>
					<td width="10" height="30"></td>
					<td width="100" height="30"></td>
					<td width="30" height="30"></td>
					<td width="340" height="30"></td>
					<td width="430" height="30"></td>
				</tr>
				<tr>
					<td align="right"><font face="MS UI Gothic"></font></td>
					<td align="right" colSpan="2" style="font-size:15px;">クライアント</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                    <%-- 2019/11/01 T.Ono mod 監視改善2019 START --%>
                    <%--<td><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
							tabIndex="1" type="button" value="▼" name="btnKURACD" runat="server"/>
					</td>
					<td><INPUT id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server"/></td> --%>
                    <td colspan="2"><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
							tabIndex="1" type="button" value="▼" name="btnKURACD" runat="server"/>&nbsp;&nbsp;～&nbsp;&nbsp;
                        <asp:textbox id="txtKURACD_TO" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><input class="bt-KS" id="btnKURACD_TO" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
							tabIndex="2" type="button" value="▼" name="btnKURACD_TO" runat="server"/>
                        <INPUT id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server"/><INPUT id="hdnKURACD_TO" type="hidden" name="hdnKURACD_TO" runat="server"/>
                    </td>
                    <%-- 2019/11/01 T.Ono mod 監視改善2019 END --%>
				</tr>
				<tr>
					<td align="right"><font face="MS UI Gothic"></font></td>
					<td align="right" colSpan="2" style="font-size:13px;">ＪＡ</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                    <td><asp:textbox id="txtJACD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><input class="bt-KS" id="btnJACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabIndex="3" type="button" value="▼" name="btnJACD" runat="server"/></td>
					<td><INPUT id="hdnJACD" type="hidden" name="hdnJACD" runat="server"/><INPUT id="hdnJACD_CLI" type="hidden" name="hdnJACD_CLI" runat="server"></td>
				</tr>
				<tr>
					<td align="right"><FONT face="MS UI Gothic"></FONT></td>
					<td align="right" colSpan="2" style="font-size:13px;">グループコード・名称</td>
                    <%--2012/04/04 .NET 使用変更により、ReadOnlyはVB側でAttributeでつける--%>
                    <td><asp:textbox id="txtGROUPCD" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
							BorderColor="Black" cssclass="c-rNM" Width="300px"></asp:textbox><input class="bt-KS" id="btnGROUPCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabIndex="4" type="button" value="▼" name="btnGROUPCD" runat="server"/></td>
					<td><input id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server"/></td>
				</tr>
				<tr>
					<td colSpan="5" height="5"></td>
				</tr>
				<tr>
					<td colSpan="3"></td>
					<td colSpan="2"><input language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="10" type="button"
							value="EXCEL出力" name="btnSelect" runat="server"/>
					</td>
				</tr>
				<tr>
					<td colSpan="5" height="50"></td>
				</tr>
				<tr>
					<td colSpan="3">&nbsp;</td>
					<td colSpan="2"><a href="MSTAHJAX00.xls" target="_blank"><img src="../../../Script/icon_xls.gif" border="0">ＪＡ毎連絡先シート作成エクセル</a>(保存ダウンロード後、開きなおして実行して下さい)</td>
				</tr>
				<tr>
					<td colSpan="3">&nbsp;</td>
					<td colSpan="2">
                    <%-- 2016/11/28 H.Mori del 監視改善2016 START 
                        <a href="MSTAHJAX00.zip" target="_blank"><img src="../../../Script/icon_xls.gif" border="0">ＪＡ毎連絡先シート作成エクセル</a>(圧縮ファイル)
                     2016/11/28 H.Mori del 監視改善2016 END --%>
                    </td>
				</tr>
                <%-- 2016/11/28 H.Mori add 監視改善2016 START --%>
                <tr>
                    <td colSpan="3">&nbsp;</td>
                    <td colSpan="2">
                        <div style="text-indent:-2em;padding-left:2em;">
                        <label style="font-weight:bold;font-size:12pt;">※JA毎連絡先シート作成エクセルの使い方<br>
                        </label>
                        <span style="font-size:10pt;">
                            1.クライアント、ＪＡ等を選択し、ＪＡ担当者のEXCEL出力を行ってください。<br>
                            2.「ＪＡ毎連絡先シート作成エクセル」のリンクより、保存ダウンロードし、ファイルを開いてください。<br>
                            3.2つのファイルを開いた状態で、2で開いたＪＡ毎連絡先シート作成エクセルの<br>
                            &nbsp;&nbsp;ＪＡ担当者一覧エクセル入力シート作成ボタンを押してください。
                        </span>
                        </div>
                    </td>
                </tr>
                <%-- 2016/11/28 H.Mori add 監視改善2016 END --%>
			</table>
			<br>
			<br>
			&nbsp;
		</form>
	</body>
</HTML>
