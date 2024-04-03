<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SYBATJAG00.aspx.vb" Inherits="JPG.SYBATJAG00.SYBATJAG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>バッチ実行履歴一覧</title>
	</HEAD>
	<body onload="window_open();">
		<form id="Form1" method="post" runat="server">
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
											<td class="TITLE" vAlign="middle">実行履歴一覧</td>
										</tr>
									</table>
								</td>
								<td width="170">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<hr>
			<table cellSpacing="1" cellPadding="2">
				<tr>
					<td width="30"></td>
					<td width="220"></td>
					<td width="100"></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<table cellSpacing="0" cellPadding="0">
							<tr>
								<td class="w" height="27" valign="middle">
									<table cellSpacing="2" cellPadding="0" height="27">
										<tr>
											<td valign="middle" width="21"><input id="rdoKBN1" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
													value="1" name="rdoKBN" runat="server" onkeydown="fncFc(this)"></td>
											<td valign="middle"><label for="rdoKBN1">全て&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
											<td valign="middle"><input id="rdoKBN2" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
													value="2" name="rdoKBN" runat="server" onkeydown="fncFc(this)"></td>
											<td valign="middle"><label for="rdoKBN2">正常&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
											<td valign="middle"><input id="rdoKBN3" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabIndex="1" type="radio"
													value="3" name="rdoKBN" runat="server" onkeydown="fncFc(this)"></td>
											<td valign="middle"><label for="rdoKBN3">エラー&nbsp;&nbsp;&nbsp;&nbsp;</label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<%-- 2013/12/06 T.Ono mod 監視改善2013
                    <td>対象処理&nbsp;<cc1:ctlcombo id="cboPROC_ID" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="2" runat="server" CssClass="cb" Width="230px"></cc1:ctlcombo> --%>
                    <td>対象処理&nbsp;<cc1:ctlcombo id="cboPROC_ID" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"　onchange="fncSetFocus()"
							tabIndex="2" runat="server" CssClass="cb" Width="230px"></cc1:ctlcombo>
				<tr>
					<td>&nbsp;</td>
					<td>
						対象日付&nbsp;<asp:textbox id="txtTRGDATE_From" onkeydown="fncFc(this)" onblur="fncFo_date(this,3)" onfocus="fncFo_date(this,2)"
							tabIndex="3" runat="server" MaxLength="8" Width="80px" cssclass="c-h"></asp:textbox>&nbsp;～&nbsp;
						<asp:textbox id="txtTRGDATE_To" onkeydown="fncFc(this)" onblur="fncFo_date(this,3)" onfocus="fncFo_date(this,2)"
							tabIndex="4" runat="server" MaxLength="8" Width="80px" cssclass="c-h"></asp:textbox>
					</td>
					<td>
						<INPUT language="javascript" class="bt-JIK" id="btnSelect" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="5" type="button"
							value="検索" name="btnSelect" runat="server">
					</td>
				</tr>
			</table>
			<br>
			<br>
			<%-- 2013/11/28 T.Ono mod 監視改善2013№2 --%>
            <%-- <table class="W" height="480" cellSpacing="0" cellPadding="0" width="960" border="1"> --%>
            <table class="W" height="560" cellSpacing="0" cellPadding="0" width="960" border="1">
				<tr>
					<td vAlign="middle" align="center" colspan="8">
						<%-- 2013/11/28 T.Ono mod 監視改善2013№2 --%>
                        <%-- <iframe id="ifList" name="ifList" src="" frameBorder="0" width="960" height="480" tabIndex="-1"></iframe> --%>
                        <iframe id="ifList" name="ifList" src="" frameBorder="0" width="960" height="560" tabIndex="-1"></iframe>
					</td>
				</tr>
			</table>
			<INPUT id="hdnKenSaku" type="hidden" name="hdnKenSaku" runat="server"> <INPUT id="hdnSelectClick" type="hidden" name="hdnSelectClick" runat="server">
		</form>
	</body>
</HTML>
