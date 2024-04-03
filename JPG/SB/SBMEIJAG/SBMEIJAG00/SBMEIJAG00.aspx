<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SBMEIJAG00.aspx.vb" Inherits="JPG.SBMEIJAG00.SBMEIJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SBMEIJAG00</title>
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
										type="button" value="終了" name="btnExit" runat="server" tabindex="91">
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
											<td class="TITLE" vAlign="middle">一般消費者名簿取込</td>
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
                            <td align="right" height="25" width="90">年度</td>
							<td><asp:textbox id="txtNENDO" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="1" runat="server" CssClass="c-h" Width="100px" MaxLength="4"></asp:textbox>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 100px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table6" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" height="25" width="90">取込データ</td>
							<td >
							    <div>
								<input id="rdoDATA1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="2" type="radio"
									value="1" name="rdoDATA" runat="server" CHECKED onkeydown="fncFc(this)"><label for="rdoDATA1">名簿基礎ファイル&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
								&nbsp;&nbsp;&nbsp;&nbsp;<input id="rdoDATA2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="2" type="radio"
									value="2" name="rdoDATA" runat="server" onkeydown="fncFc(this)"><label for="rdoDATA2">ＬＴＯＳファイル&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
							    </div>
							</td>
						</tr>
					</table>
				</DIV>
				<DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 130px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table7" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" height="25" width="90">対象ファイル</td>
							<td >
							    <div>
                                    <input style="width: 500px" type="file" id="FileUpload1" name="FileUpload1" tabIndex="3" >
							    </div>
							</td>
                            <td>
                                <div>
                                    &nbsp;&nbsp;<a href="SBMEIJAG00.pdf" target="_blank" tabIndex="4"><img src="../../../Script/icon_pdf.gif" border="0" alt="img" />作業手順について&nbsp;&nbsp;</a>
                                </div>
                            </td>
						</tr>
					</table>
				</DIV>
                <DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 160px; HEIGHT: 30px" ms_positioning="FlowLayout">
					<table id="Table8" cellSpacing="1" cellPadding="2">
						<tr>
							<td align="right" height="25" width="90"></td>
                            <td align="right" height="25" width="300"></td>
							<td >
							    <div>
                                    <INPUT language="javascript" class="bt-RNW" id="btnSelect" onblur="return fncFo(this,5);"
							        onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="10" type="button"
							        value="実行" name="btnSelect" runat="server">
							    </div>
							</td>
						</tr>
					</table>
				</DIV>
                <DIV style="LEFT: 13px; WIDTH: 800px; POSITION: absolute; TOP: 190px; HEIGHT: 50px" ms_positioning="FlowLayout">
					<table id="Table9" cellSpacing="1" cellPadding="2" style="visibility:hidden">
						<tr>
							<td align="right" height="25" width="90"></td>
                            <td align="Left" height="25" width="300" style="font-size:20px;font-weight:bold;" >ファイル取込中。。。</td>
						</tr>
					</table>
				</DIV>


			</DIV>
		</form>
	</body>
</HTML>
