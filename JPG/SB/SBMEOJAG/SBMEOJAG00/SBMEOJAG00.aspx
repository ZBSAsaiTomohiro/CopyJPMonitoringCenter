<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SBMEOJAG00.aspx.vb" Inherits="JPG.SBMEOJAG00.SBMEOJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SBMEOJAG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><br>
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
										type="button" value="�I��" name="btnExit" runat="server" tabindex="91">
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
											<td class="TITLE" vAlign="middle">��ʏ���Җ���o��</td>
										</tr>
									</table>
								</td>
								<td width="170">&nbsp;</td>
							</tr>
						</table>
						<INPUT id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server"><INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server">
					</td>
				</tr>
			</table>
			<hr>

			<DIV style="LEFT: 0px; WIDTH: 900px; POSITION: absolute; TOP: 35px; HEIGHT: 30px" ms_positioning="FlowLayout">
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 70px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table5" cellSpacing="1" cellPadding="2">
						<tr>
                            <td align="right" height="25" width="90">�N�x</td>
							<td><asp:textbox id="txtNENDO" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="1" runat="server" CssClass="c-h" Width="100px" MaxLength="4"></asp:textbox></td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 100px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table6" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" height="25" width="90">��</td>
							<td><asp:textbox id="txtKENCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="2" runat="server" CssClass="c-h" Width="100px" MaxLength="2"></asp:textbox>
							</td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 130px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table7" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" colSpan="2" width="90">�N���C�A���g</td>
                            <td>&nbsp<asp:textbox id="txtKURACD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');"
									tabIndex="3" type="button" value="��" name="btnKURACD_From" runat="server">&nbsp;�`&nbsp;
                            </td>
							<td><asp:textbox id="txtKURACD_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnKURACD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
									tabIndex="4" type="button" value="��" name="btnKURACD_To" runat="server">
							</td>
							<td><INPUT id="hdnKURACD_From" type="hidden" name="hdnKURACD_From" runat="server"></td>
							<td><INPUT id="hdnKURACD_To" type="hidden" name="hdnKURACD_To" runat="server"></td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 160px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table8" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" colSpan="2" width="90">�̔��X</td>
                            <td>&nbsp<asp:textbox id="txtHANTENCD_From" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnHANTENCD_From" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
									tabIndex="5" type="button" value="��" name="btnHANTENCD_From" runat="server">&nbsp;�`&nbsp;
                            </td>
							<td><asp:textbox id="txtHANTENCD_To" tabIndex="-1" runat="server" BorderWidth="1px" BorderStyle="Solid"
									BorderColor="Black" cssclass="c-rNM" Width="220px"></asp:textbox><INPUT class="bt-KS" id="btnHANTENCD_To" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
									tabIndex="6" type="button" value="��" name="btnHANTENCD_To" runat="server">
							</td>
							<td><INPUT id="hdnHANTENCD_From" type="hidden" name="hdnHANTENCD_From" runat="server"></td>
							<td><INPUT id="hdnHANTENCD_To" type="hidden" name="hdnHANTENCD_To" runat="server"></td>
						</tr>
					</table>
				</DIV>

                <DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 190px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table9" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" height="25" width="90">�o�̓��X�g</td>
                            <td>
                                <%--
                                <cc1:ctlcombo id="cbofiletype" onkeydown="fncFc(this)" onblur="fncFo(this,1)"
                                onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onchange="fncSetFocus();"
                                TabIndex="7" runat="server" Width="150px" CssClass="cb"></cc1:ctlcombo>
                                <INPUT id="hdnfiletype" type="hidden" name="hdnfiletype" runat="server">
                                    --%>
                                <asp:DropDownList id="listfiletype" runat="server" Width="150px" CssClass="c-hI" onkeydown="fncFc(this)"
                                    onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onchange="fncSetFocus();"
                                    TabIndex="7">
							    </asp:DropDownList>
                            </td>
                            <td width="225">
							</td>
							<td>
                                <INPUT language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
							        onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="20" type="button"
							        value="���s" name="btnSelect" runat="server">
							</td>

						</tr>
					</table>
				</DIV>
                <DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 220px; HEIGHT: 50px" ms_positioning="FlowLayout">
					<table id="Table10" cellSpacing="1" cellPadding="2" >
						<tr>
							<td align="right" height="25" width="90"></td>
                            <td align="Left" height="25" width="300" style="font-size:20px;font-weight:bold;" >
                                <asp:label ID="lblStatus" runat="server" style="visibility:hidden">�t�@�C���o�͒��B�B�B</asp:label></td>
						</tr>
					</table>
				</DIV>
                <DIV style="LEFT: 700px; WIDTH: 250px; POSITION: absolute; TOP: 70px; HEIGHT: 30px; font-size:16px;" ms_positioning="FlowLayout">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�� �R �[ �h<br />
                        �X:20&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �V��:39&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���R:62<br />
                        ���:21&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �x�R:40&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�L��:63<br />
                        �{��:22&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �ΐ�:41&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�R��:64<br />
                        �H�c:23&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ��:42&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����:70<br />
                        �R�`:24&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �É�:43&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����:71<br />
                        ����:25&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �O�d:45&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���Q:72<br />
                        �R�`:26&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ����:50&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���m:73<br />
                        ���:30&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ����:51&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����:80<br />
                        �Q�n:32&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ���s:52&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����:81<br />
                        ���:33&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ���:53&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����:82<br />
                        ��t:34&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ����:54&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�F�{:83<br />
                        ����:35&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; �ޗ�:55&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�啪:84<br />
                        �_�ސ�:36&nbsp;&nbsp;&nbsp;&nbsp; ����:60&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;������:86<br />
                        �R��:37&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ����:61&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����:88<br />

                        
                </DIV>
			</DIV>
		</form>
	</body>
</HTML>
