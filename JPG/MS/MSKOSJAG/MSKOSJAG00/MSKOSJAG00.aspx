<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSKOSJAG00.aspx.vb" Inherits="JPG.MSKOSJAG00.MSKOSJAG00" EnableSessionState="ReadOnly" enableViewState="False" enableViewStateMac="False"%>
<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MSKOSJAG00</title>
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
										type="button" value="�I��" name="btnExit" runat="server">
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
											<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 START --%> 
											<%-- <td class="TITLE" vAlign="middle">�ڋq����</td> --%> 
											<td class="TITLE" vAlign="middle">���q�l����</td>
											<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 END --%> 
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
			<INPUT id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"> <INPUT id="hdnSelectClick" type="hidden" name="hdnSelectClick" runat="server">
			<INPUT id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server"> <INPUT id="hdnTaiouClick" type="hidden" name="hdnTaiouClick" runat="server"><INPUT id="hdnKEY_CLI_CD" type="hidden" name="hdnKEY_CLI_CD" runat="server"><INPUT id="hdnKEY_HAN_CD" type="hidden" name="hdnKEY_HAN_CD" runat="server"><INPUT id="hdnKEY_USER_CD" type="hidden" name="hdnKEY_USER_CD" runat="server"><INPUT id="hdnMOVE_MITOKBN" type="hidden" name="hdnMOVE_MITOKBN" runat="server">
            <input id="hdnKEY_CLI_CD_TO" type="hidden" name="hdnKEY_CLI_CD_TO" runat="server"><%-- 2019/11/01 T.Ono add �Ď����P2019 No1 --%>
 			<INPUT id="hdnKEY_JA_CD" type="hidden" name="hdnKEY_JA_CD" runat="server"> <%-- 2013/12/09 T.Ono add �Ď����P2013 --%>
			<INPUT id="hdnKEY_HAN_GRP" type="hidden" name="hdnKEY_HAN_GRP" runat="server"> <%-- 2014/12/03 H.Hosoda add �Ď����P2014 No.6--%>
            <%-- 2019/11/01 T.Ono del �Ď����P2019 No1 --%>
            <%-- <INPUT id="hdnKEY_KINREN_GRP" type="hidden" name="hdnKEY_KINREN_GRP" runat="server"> --%> <%-- 2016/11/22 H.Mori add �Ď����P2016 No2-1--%>
            <INPUT id="hdnScrollTop" type="hidden" name="hdnScrollTop" runat="server"> <%-- 2013/12/09 T.Ono add �Ď����P2013 --%>
            <table cellSpacing="1" cellPadding="0" width="980">
				<tr>
					<td width="130" align="right">�Ď��Z���^�[&nbsp;&nbsp;</td>
					<%-- 2013/12/05 T.Ono mod �Ď����P2013
                    <td width="200" align="left"><cc1:ctlcombo id="cboKANSCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="1" runat="server" CssClass="cb" Width="200px" onChange="fncKansiChange();"></cc1:ctlcombo></td> --%>
					<%-- 2014/12/02 H.Hosoda mod �Ď����P2014 No.6 START --%>
                    <%-- <td width="200" align="left"><cc1:ctlcombo id="cboKANSCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="1" runat="server" CssClass="cb" Width="200px" onChange="fncKansiChange();fncSetFocus();"></cc1:ctlcombo></td> --%>
                    <td width="200" align="left"><cc1:ctlcombo id="cboKANSCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)"
							tabIndex="1" runat="server" CssClass="cb" Width="200px" onChange="fncKansiChange();fncSetFocus();"></cc1:ctlcombo></td>
					<%-- 2014/12/02 H.Hosoda mod �Ď����P2014 No.6 END --%>
                    <%-- 2015/12/11 H.Mori mod �Ď����P2015 No.4 START 
					<td width="100"></td>
                    <td width="100"></td>
                    <td width="100"></td>
                    <td width="350"></td>
                     --%>
                    <td width="100" align="right">�̔��敪&nbsp;&nbsp;</td>
					<td width="550" colspan="3"><input name="chkHANBAI_KBN1" type="checkbox" id="chkHANBAI_KBN1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="2" checked="checked"  runat="server"/>
                        <label for="chkHANBAI_KBN1">���[�^��&nbsp;</label>
                        <input name="chkHANBAI_KBN2" type="checkbox" id="chkHANBAI_KBN2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="3" checked="checked"  runat="server"/>
                        <label for="chkHANBAI_KBN2">�{���x��&nbsp;</label>
                        <input name="chkHANBAI_KBN3" type="checkbox" id="chkHANBAI_KBN3" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="4" checked="checked"  runat="server"/>
                        <label for="chkHANBAI_KBN3">����</label>
                        <input name="chkHANBAI_KBN4" type="checkbox" id="chkHANBAI_KBN4" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="5" checked="checked"  runat="server"/>
                        <label for="chkHANBAI_KBN4">���̑�</label>
                        <input name="chkHANBAI_KBN5" type="checkbox" id="chkHANBAI_KBN5" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="6" checked="checked"  runat="server"/>
                        <label for="chkHANBAI_KBN5">�f�[�^�Ȃ�</label>
                        <input name="chkHANBAI_KBN6" type="checkbox" id="chkHANBAI_KBN6" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="7" checked="checked"  runat="server"/>
                        <label for="chkHANBAI_KBN6">��O</label>
                    </td>
				</tr>
				<tr>
                    <%-- 2016/11/16 H.Mori mod 2016���P�J�� No2-3 START --%>
					<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 START --%>
					<%-- <td align="right">���v�Ɠd�b�ԍ�&nbsp;&nbsp;</td> --%>
					<%-- <td align="right">�A����&nbsp;&nbsp;</td>
					<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 END --%>
					<%-- <td align="left"><asp:textbox id="txtTEL" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
					  		tabIndex="2" runat="server" CssClass="c-f" Width="150px" MaxLength="15"></asp:textbox></td>--%>
					<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 START --%>
					<%-- <td align="right">�����ԍ�&nbsp;&nbsp;</td>--%>
					<%-- <td align="left"><asp:textbox id="txtNCUTEL" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="3" runat="server" CssClass="c-f" Width="150px" MaxLength="15"></asp:textbox></td>--%>
					<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 END --%>
                    <td align="right">�A����^�����ԍ�&nbsp;&nbsp;</td>
					<td align="left"><asp:textbox id="txtTEL" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="8" runat="server" CssClass="c-f" Width="150px" MaxLength="15"></asp:textbox></td>
					<td width="100" align="right">���q�lFLG&nbsp;&nbsp;</td>
					<td width="220" align="left"><input name="chkUSER_FLG0" type="checkbox" id="chkUSER_FLG0" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="9" checked="checked"  runat="server"/>
                        <label for="chkUSER_FLG0">���J��&nbsp;&nbsp;&nbsp;</label>
                        <input name="chkUSER_FLG1" type="checkbox" id="chkUSER_FLG1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="10" checked="checked"  runat="server"/>
                        <label for="chkUSER_FLG1">�^�p��&nbsp;&nbsp;&nbsp;</label>
                        <input name="chkUSER_FLG2" type="checkbox" id="chkUSER_FLG2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="11" checked="checked"  runat="server"/>
                        <label for="chkUSER_FLG2">�x�~��</label>
                    </td>
                    <td width="90"></td>
                    <td width="350"></td>
                    <td></td>
                    <td></td>
                    <%-- 2016/11/16 H.Mori mod 2016���P�J�� No2-3 END --%>
                    
                    <%-- 2016/11/16 H.Mori mod 2016���P�J�� No2-3 START ���q�lFLG�����ɋl�߂�--%>
					<%-- 2013/11/27 T.Ono mod �Ď����P2013��2 Start --%>
                    <%-- <td></td>
					<td></td>--%>
                    <%-- 2015/12/11 H.Mori mod �Ď����P2015 ��4 
                    <td align="right"> --%>
                    <%-- <td width="100" align="right">���q�lFLG&nbsp;&nbsp;</td>--%>
                    <%-- 2015/12/11 H.Mori mod �Ď����P2015 ��4 
                    <td> --%>
                    <%--<td width="350"><input name="chkUSER_FLG0" type="checkbox" id="chkUSER_FLG0" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="13" checked="checked"  runat="server"/>
                        <label for="chkUSER_FLG0">���J��&nbsp;</label>
                        <input name="chkUSER_FLG1" type="checkbox" id="chkUSER_FLG1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="14" checked="checked"  runat="server"/>
                        <label for="chkUSER_FLG1">�^�p��&nbsp;</label>
                        <input name="chkUSER_FLG2" type="checkbox" id="chkUSER_FLG2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" tabindex="15" checked="checked"  runat="server"/>
                        <label for="chkUSER_FLG2">�x�~��</label>
                    </td> --%>
                    <%-- 2013/11/27 T.Ono mod �Ď����P2013��2 End --%>
                    <%--<td></td>
					<td></td> --%>
					<%-- 2016/11/16 H.Mori mod 2016���P�J�� No2-3 END ���q�lFLG�����ɋl�߂�--%>
				</tr>
				<tr>
					<%-- 2016/11/16 H.Mori mod 2016���P�J�� No2-4 START --%>
                    <%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 START --%>
					<%-- <td align="right">���v�Ɩ�&nbsp;&nbsp;</td> --%>
					<%-- <td align="right">���q�l��&nbsp;&nbsp;</td> --%>
					<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 END --%>
					<%-- <td><asp:textbox id="txtNAME" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="4" runat="server" CssClass="c-fI" Width="190px" MaxLength="15"></asp:textbox></td> --%>
					<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 START --%>
					<%-- <td align="right">���v�Ɩ��J�i&nbsp;&nbsp;</td> --%>
					<%-- <td align="right">���q�l���J�i&nbsp;&nbsp;</td> --%>
					<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 END --%>
					<%-- <td align="left"><asp:textbox id="txtKANA" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="5" runat="server" CssClass="c-fI" Width="190px" MaxLength="12"></asp:textbox>
					</td> --%>
                    <td align="right">���q�l���^�J�i&nbsp;&nbsp;</td>
					<td><asp:textbox id="txtNAME" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
						tabIndex="12" runat="server" CssClass="c-fI" Width="190px" MaxLength="15"></asp:textbox></td>
					<td align="right">���q�l�R�[�h&nbsp;&nbsp;</td>
					<td align="left"><asp:textbox id="txtUSER_CD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
									  tabIndex="13" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox></td>
                    <%-- 2016/11/16 H.Mori mod 2016���P�J�� No2-4 END --%>

                    <%-- 2013/11/27 T.Ono add �Ď����P2013��2 Start --%>
					<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 START --%>
                    <%-- <td align="right">���v�ƏZ��&nbsp;&nbsp;</td> --%>
                    <td align="right">���q�l�Z��&nbsp;&nbsp;</td>
                    <%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 START --%>
					<td align="left"><asp:textbox id="txtADDR" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
                            tabIndex="14" runat="server" CssClass="c-fI" Width="280px" MaxLength="50"></asp:textbox>
					</td>
                    <%-- 2013/11/27 T.Ono add �Ď����P2013��2 End --%>
				</tr>
				<tr>
					<td height="5" colSpan="6"></td>
				</tr>
				<tr>
					<td class="w" colSpan="6">
						<table height="27" cellSpacing="0" cellPadding="0">
  							<%-- 2013/11/27 T.Ono mod �Ď����P2013��2 Start
                            <tr>							
                                <td>&nbsp;&nbsp;�N���C�A���g��&nbsp;</td>
                                <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���-%>
								<%--<td><asp:textbox id="txtCLI_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px" ReadOnly="True"></asp:textbox><input class="bt-KS" id="btnCLI_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
										tabIndex="5" type="button" value="��" name="btnCLI_CD" runat="server"> <INPUT id="hdnCLI_CD" type="hidden" name="hdnCLI_CD" runat="server"></td>-%>
								<td><asp:textbox id="txtCLI_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnCLI_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
										tabIndex="5" type="button" value="��" name="btnCLI_CD" runat="server"> <INPUT id="hdnCLI_CD" type="hidden" name="hdnCLI_CD" runat="server"></td>
                                <td>
								&nbsp;&nbsp;�i�`�x����&nbsp;
								</td>
                                <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���-%>
								<%--<td><asp:textbox id="txtHAN_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="270px" BorderStyle="Solid"
										BorderWidth="1px" ReadOnly="True"></asp:textbox><input class="bt-KS" id="btnHAN_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
										tabIndex="6" type="button" value="��" name="btnHAN_CD" runat="server"> <INPUT id="hdnHAN_CD" type="hidden" name="hdnHAN_CD" runat="server"></td>-%>
								<td><asp:textbox id="txtHAN_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="270px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHAN_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
										tabIndex="6" type="button" value="��" name="btnHAN_CD" runat="server"> <INPUT id="hdnHAN_CD" type="hidden" name="hdnHAN_CD" runat="server"></td>
                                <td>&nbsp;&nbsp;���q�l�R�[�h&nbsp;</td>
								<td><asp:textbox id="txtUSER_CD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
										tabIndex="7" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox></td>
							</tr> --%>
  							<%-- 2019/11/01 T.Ono mod �Ď����P2019 ��1 Start --%>
                            <%-- <tr><td>&nbsp;&nbsp;�N���C�A���g��&nbsp;</td>
								<td><asp:textbox id="txtCLI_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnCLI_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
										tabIndex="15" type="button" value="��" name="btnCLI_CD" runat="server"> <INPUT id="hdnCLI_CD" type="hidden" name="hdnCLI_CD" runat="server"></td>
								<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 START -->
                                <%-- <td></td>
								<td></td> -->
                                <td>&nbsp;&nbsp;�̔����Ǝ�&nbsp;</td>
								<td><asp:textbox id="txtHANGRP" tabIndex="-1" runat="server" CssClass="c-rNM" Width="270px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHANGRP" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
										tabIndex="16" type="button" value="��" name="btnHANGRP" runat="server"> <INPUT id="hdnHANGRP" type="hidden" name="hdnHANGRP" runat="server"></td>
								<%-- 2014/11/12 H.Hosoda add �Ď����P2014 No.6 END -->
                                <%-- 2016/11/16 H.Mori add 2016���P�J�� No2-1 START -->
                                <%--<td></td>
								<td></td>-->
                                <td>&nbsp;�ً}�A����Gr&nbsp;</td>
								<td><asp:textbox id="txtKINRENGRP" tabIndex="-1" runat="server" CssClass="c-rNM" Width="210px" BorderStyle="Solid"
                                        BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnKINRENGRP" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('5');"
                                        tabIndex="17" type="button" value="��" name="btnKINRENGRP" runat="server"> <INPUT id="hdnKINRENGRP" type="hidden" name="hdnKINRENGRP" runat="server"></td>
                                <%-- 2016/11/16 H.Mori add 2016���P�J�� No2-1 END -->
							</tr>
                            <tr>
                                <td align="right">&nbsp;&nbsp;�i�`��&nbsp;</td>
								<td><asp:textbox id="txtJA_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnJA_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
										tabIndex="18" type="button" value="��" name="btnJA_CD" runat="server"> <INPUT id="hdnJA_CD" type="hidden" name="hdnJA_CD" runat="server"></td>
                                <td>&nbsp;&nbsp;�i�`�x����&nbsp;</td>
								<td><asp:textbox id="txtHAN_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHAN_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('4');"
										tabIndex="19" type="button" value="��" name="btnHAN_CD" runat="server"> <INPUT id="hdnHAN_CD" type="hidden" name="hdnHAN_CD" runat="server"></td>
                                <%--2016/11/17 H.Mori del 2016���P�J�� No2-4 ���q�l���^�J�i�̉E�ׂֈړ� START  -->
                                <%--<td>&nbsp;&nbsp;���q�l�R�[�h&nbsp;</td>
								<td><asp:textbox id="txtUSER_CD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
										tabIndex="20" runat="server" CssClass="c-f" Width="150px" MaxLength="20"></asp:textbox></td> -->
                                <%--2016/11/17 H.Mori del 2016���P�J�� No2-4 END  -->
                                <%-- 2016/11/24 H.Mori add 2016���P�J�� No2-2 START -->
                                <td colSpan="2">&nbsp;&nbsp;�`&nbsp;
                                    <asp:textbox id="txtHAN_CD_TO" tabIndex="-1" runat="server" CssClass="c-rNM" Width="215px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHAN_CD_TO" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('6');"
										tabIndex="19" type="button" value="��" name="btnHAN_CD_TO" runat="server"> <INPUT id="hdnHAN_CD_TO" type="hidden" name="hdnHAN_CD_TO" runat="server">
                                </td>
                                <%-- 2016/11/24 H.Mori add 2016���P�J�� No2-2 END -->
                            </tr>
                            <%-- 2013/11/27 T.Ono mod �Ď����P2013��2 End -->  --%>
                            <tr><td width="74">&nbsp;&nbsp;�N���C�A���g��&nbsp;</td>
								<td width="250"><asp:textbox id="txtCLI_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="225px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnCLI_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
										tabIndex="15" type="button" value="��" name="btnCLI_CD" runat="server"> <INPUT id="hdnCLI_CD" type="hidden" name="hdnCLI_CD" runat="server"></td>
                                <td width="64">&nbsp;&nbsp;&nbsp;&nbsp;�`&nbsp;</td>
								<td width="260"><asp:textbox id="txtCLI_CD_TO" tabIndex="-1" runat="server" CssClass="c-rNM" Width="230px" BorderStyle="Solid"
                                        BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnCLI_CD_TO" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('7');"
                                        tabIndex="16" type="button" value="��" name="btnCLI_CD_TO" runat="server"> <INPUT id="hdnCLI_CD_TO" type="hidden" name="hdnCLI_CD_TO" runat="server"></td>
                                <td width="64">&nbsp;�̔����Ǝ�&nbsp;</td>
								<td width="260"><asp:textbox id="txtHANGRP" tabIndex="-1" runat="server" CssClass="c-rNM" Width="230px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHANGRP" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('3');"
										tabIndex="17" type="button" value="��" name="btnHANGRP" runat="server"> <INPUT id="hdnHANGRP" type="hidden" name="hdnHANGRP" runat="server"></td>
							</tr>
                            <tr>
                                <td align="right">&nbsp;&nbsp;�i�`��&nbsp;</td>
								<td><asp:textbox id="txtJA_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="225px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnJA_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
										tabIndex="18" type="button" value="��" name="btnJA_CD" runat="server"> <INPUT id="hdnJA_CD" type="hidden" name="hdnJA_CD" runat="server">
                                        <INPUT id="hdnJA_CD_CLI" type="hidden" name="hdnJA_CD_CLI" runat="server"></td>
                                <td>&nbsp;&nbsp;�i�`�x����&nbsp;</td>
								<td><asp:textbox id="txtHAN_CD" tabIndex="-1" runat="server" CssClass="c-rNM" Width="230px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHAN_CD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('4');"
										tabIndex="19" type="button" value="��" name="btnHAN_CD" runat="server"> <INPUT id="hdnHAN_CD" type="hidden" name="hdnHAN_CD" runat="server">
                                        <INPUT id="hdnHAN_CD_CLI" type="hidden" name="hdnHAN_CD_CLI" runat="server">
								</td>
                                <td width="64">&nbsp;&nbsp;&nbsp;&nbsp;�`&nbsp;</td>
                                <td><asp:textbox id="txtHAN_CD_TO" tabIndex="-1" runat="server" CssClass="c-rNM" Width="230px" BorderStyle="Solid"
										BorderWidth="1px"></asp:textbox><input class="bt-KS" id="btnHAN_CD_TO" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('6');"
										tabIndex="19" type="button" value="��" name="btnHAN_CD_TO" runat="server"> <INPUT id="hdnHAN_CD_TO" type="hidden" name="hdnHAN_CD_TO" runat="server">
                                        <INPUT id="hdnHAN_CD_TO_CLI" type="hidden" name="hdnHAN_CD_TO_CLI" runat="server">
                                </td>
                            </tr>
  							<%-- 2019/11/01 T.Ono mod �Ď����P2019 ��1 END�@--%>
						</table>
					</td>
				</tr>
				<tr>
					<td height="5" colSpan="6"></td>
				</tr>
				<tr>
                    <%--2017/02/06 W.Ganeko mod 2016���P�J�� No2 START  --%>
					<%--<td align="right" height="24"></td> --%>
                    <td align="left" height="24"><input language="javascript" class="bt-RNW" id="btnExcel" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnExcel_onclick();" tabIndex="20" type="button"
							value="�o�́iEXCEL�j" name="btnExcel" runat="server"/>
                    </td>
                    <%--2017/02/06 W.Ganeko mod 2016���P�J�� No2 END  --%>
					<td></td>
					<td></td>
					<td align="center"><input language="javascript" class="bt-JIK" id="btnSelect" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnSelect_onclick();" tabIndex="21" type="button" value="����"
							name="btnSelect"></td>
					<td></td>
					<td align="right"><input language="javascript" class="bt-RNW" id="btnTAIO" onblur="return fncFo(this,5);"
							onfocus="fncFo(this,2)" onclick="return btnTAIO_onclick();" tabIndex="22" type="button" value="�Ή�����"
							name="btnTAIO"></td>
				</tr>
			</table>
			<br>
			<hr>
			<br>
			<table class="W" id="Table6" height="400" cellSpacing="0" cellPadding="0" width="980" border="1">
				<tr>
					<td vAlign="middle" align="center" colSpan="8"><iframe id="ifList" tabIndex="-1" name="ifList" src="" frameBorder="0" width="980" height="470"></iframe></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
