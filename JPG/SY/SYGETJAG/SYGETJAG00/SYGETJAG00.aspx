<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SYGETJAG00.aspx.vb" Inherits="SYGETJAG00.SYGETJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label>
			<INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200"></td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;<INPUT language="javascript" class="bt-JIK" id="btnJikkou" onblur="return fncFo(this,5);"
										onfocus="fncFo(this,2)" onclick="return btnJikkou_onclick();" tabIndex="1" type="button" value="���s" name="btnJikkou"
										runat="server"></td>
								<td width="70">&nbsp;</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80"><input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
										tabIndex="94" type="button" value="�I��" name="btnExit" runat="server">
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
											<td class="TITLE" vAlign="middle">�f�[�^����
											</td>
										</tr>
									</table>
								</td>
								<td vAlign="middle" align="right" width="170"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<INPUT id="hdnTRGDATEM" type="hidden" name="hdnTRGDATEM" runat="server"> <INPUT id="hdnDELMONTH_APLOG" type="hidden" name="hdnDELMONTH_APLOG" runat="server">
			<INPUT id="hdnDELMONTH_BATLOG" type="hidden" name="hdnDELMONTH_BATLOG" runat="server">
			<INPUT id="hdnDELMONTH_TELLOG" type="hidden" name="hdnDELMONTH_TELLOG" runat="server">
			<INPUT id="hdnDELMONTH_FILE" type="hidden" name="hdnDELMONTH_FILE" runat="server">
			<INPUT id="hdnDELMONTH_BACKFILE" type="hidden" name="hdnDELMONTH_BACKFILE" runat="server">
			<!-- 2016/12/27 T.Ono add 2016���P�J�� ��12 START -->
            <INPUT id="hdnDELMONTH_AUTOFAXLOGDB" type="hidden" name="hdnDELMONTH_AUTOFAXLOGDB" runat="server">
			<INPUT id="hdnDELMONTH_AUTOFAXTAIDB" type="hidden" name="hdnDELMONTH_AUTOFAXTAIDB" runat="server">
			<INPUT id="hdnDELMONTH_FAXOUTBOXLOG" type="hidden" name="hdnDELMONTH_FAXOUTBOXLOG" runat="server">
            <!-- 2016/12/27 T.Ono add 2016���P�J�� ��12 END -->
			<hr>
			<table cellSpacing="0" cellPadding="0" width="800">
				<TBODY>
					<tr>
						<td width="50"></td>
						<td width="650">
							<table cellSpacing="0" cellPadding="0" width="600" border='1' rules='all' bgcolor='#eeeeee'>
							    <col width='150'/>
							    <col width='120'/>
							    <col width='*'/>
								<tr>
									<th>�폜�Ώ�</th><th>�Ώۓ��i�ȑO�j</th><th>&nbsp;</th>
								</tr>
								<tr>
									<td valign=top>�x��c�a</td><td valign=top><asp:textbox id="txtTRGDATE1" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>&nbsp;</td>
								<tr>
								<tr>
									<td valign=top>�Ή��c�a</td><td valign=top><asp:textbox id="txtTRGDATE2" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>&nbsp;</td>
								<tr>
								<tr>
									<td valign=top>�o�b�`���O</td><td valign=top><asp:textbox id="txtTRGDATE3" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>&nbsp;</td>
								<tr>
								<tr>
									<td valign=top>�`�o���O</td><td valign=top><asp:textbox id="txtTRGDATE4" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>&nbsp;</td>
								<tr>
								<tr>
									<td valign=top>�d�b���M���O</td><td valign=top><asp:textbox id="txtTRGDATE5" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>&nbsp;</td>
								<tr>
								<tr>
									<td valign=top>�ꎞ�쐬�t�@�C��</td><td valign=top><asp:textbox id="txtTRGDATE6" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>�����k�s�n�r�A��<br>KERUIJOX00 �ݐϏ��ꗗ<br>BTFAXJAX00 �����e�`�w<br>KEFAXJAX00 �Ή����͂e�`�w</td>
								<tr>
								<tr>
									<td valign=top>�`�o۸��ޯ�����̧��</td><td valign=top><asp:textbox id="txtTRGDATE7" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>BTGETJAE00 �`�o۸��ޯ�����̧��</td>
								<tr>
								<tr>
									<td valign=top>�ޯ�����̧��</td><td valign=top><asp:textbox id="txtTRGDATE8" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>KEFAXJAW00 �Ή������ް�FAX���M�p�ꎞ̧��</td>
								<tr>
                                <!-- 2016/12/27 T.Ono add 2016���P�J�� ��12 START -->
                                <tr>
									<td valign=top>����FAX���O</td><td valign=top><asp:textbox id="txtTRGDATE9" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>S05_AUTOFAXLOGDB</td>
								<tr>
                                <tr>
									<td valign=top>����FAX��r�p�Ή��ް�</td><td valign=top><asp:textbox id="txtTRGDATE10" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>S06_AUTOFAXTAIDB</td>
								<tr>
                                <tr>
									<td valign=top>FAX�T�[�o�[���M���O</td><td valign=top><asp:textbox id="txtTRGDATE11" ReadOnly="True" BorderWidth="1px" BorderStyle="Solid" BorderColor="Black" tabIndex="1" runat="server" Width="100px" CssClass="c-RO" MaxLength="10"></asp:textbox></td><td>S07_FAXOUTBOXLOG</td>
								<tr>
                                <!-- 2016/12/27 T.Ono add 2016���P�J�� ��12 END -->
							</table>
						</td>
						<td width="100" valign="bottom" align="right">&nbsp;
						</td>
					</tr>
				<TBODY>
			</table>
		</form>
		</TBODY></TABLE>
	</body>
</HTML>
