<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KETAIJVG00.aspx.vb" Inherits="JPG.KETAIJAG00.KETAIJVG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�d�b�ԍ��I��</title>
		<script language="JavaScript">
		    //window.resizeTo(780,250); 2016/12/12 H.Mori mod 2016���P�J�� No5-1
            <%-- // 2022/12/20 MOD START Y.ARAKAKI 2022�X��No10 _Edge�E�B���h�E�T�C�Y�����Ή� --%>
            <%-- window.resizeTo(780, 340); --%>
            window.resizeTo(780, 380);
            <%-- // 2022/12/20 MOD END   Y.ARAKAKI 2022�X��No10 _Edge�E�B���h�E�T�C�Y�����Ή� --%>
			//window.moveTo(25, 25); 2016/04/15 T.Ono mod 2015���P�J�� �\���ʒu�ύX�̒ǉ��v�]
			window.moveTo(25, 250);
		</script>
		<style>
		    .W_TITLE { WIDTH: 60px; font-size: 13px;}
		    .W_TITLE_2 { font-size: 14px;}
		    .W_TITLE_3 { text-align:center;}
		    .W_TITLE_4 { font-size: 13px;}
		    .W_TITLE_5 { font-size: 14px; color: red} /* 2016/12/12 H.Mori add 2016���P�J�� No5-1 ���� */
		    .W_FRAME1  { position:relative; left:-4px; border-style: solid; border-color:red;} /* 2016/12/19 H.Mori add 2016���P�J�� No5-1 */
	    </style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label>
            <input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server"/>
            <input id="hdnACBCD" type="hidden" name="hdnACBCD" runat="server"/>
            <input id="hdnUSER_CD" type="hidden" name="hdnUSER_CD" runat="server"/>
            <input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server"/>
  			<table id="Table3" cellspacing="0" cellpadding="0">
				<tr>
					<td width="20"></td>
					<td valign="middle" width="800">
						<table id="Table4" cellspacing="0" cellpadding="2" width="100%">
							<tbody>
								<tr>
									<td class="TITLE" valign="middle">�d�b�ԍ��I��</td>
								</tr>
							</tbody></table>
					</td>
					<td width="170">&nbsp;<input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="return btnExit_onclick(); __doPostBack('btnExit','')" tabIndex="1" type="button"
							value="�I��" name="btnExit"/>
                    </td>
				</tr>
			</table>
            <br />
            <br />
            <br />
            <table>
                <tr>
                    <td></td>
                    <td></td>
                    <td class="W_TITLE_2 W_TITLE_3" >�d�b�ԍ�</td>
                    <td class="W_TITLE_2 W_TITLE_3" >���l</td>
                    <td class="W_TITLE_2 W_TITLE_3" >�X�V��</td>
                    <td></td>
                </tr>
                <tr>
                    <td class="W_TITLE"><label for="rdoTel1_2" class="W_TITLE_2">�A����2</label></td>
                    <td><input id="rdoTel1_2" onblur="fncFo(this,4)" 
                                            onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server" value="2"/></td>
                    <td><asp:textbox id="txtRENTEL2" tabIndex="1" runat="server" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" onkeydown="fncFc(this)" cssclass="c-f" maxlength="15" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"></asp:textbox></td>
                    <td><asp:textbox id="txtRENTEL2_BIKO" tabIndex="1" runat="server" BorderWidth="1px" BorderStyle="Solid"
								Width="200px" onkeydown="fncFc(this)" cssclass="c-f" maxlength="24" onblur="fnc_bikoCheck(this,2),fncFo(this,1)" onfocus="fncFo(this,2)" style="IME-MODE: active;"></asp:textbox></td>
                    <td><asp:textbox id="txtRENTEL2_UPD_DATE" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
								Width="140px"></asp:textbox></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="W_TITLE"><label for="rdoTel1_3" class="W_TITLE_2">�A����3</label></td>
                    <td><input id="rdoTel1_3"  onblur="fncFo(this,4)" 
                                            onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server" value="3"/></td>
                    <td><asp:textbox id="txtRENTEL3" tabIndex="1" runat="server" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" cssclass="c-f" maxlength="15" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"></asp:textbox></td>
                    <td><asp:textbox id="txtRENTEL3_BIKO" tabIndex="1" runat="server" BorderWidth="1px" BorderStyle="Solid"
								Width="200px" onkeydown="fncFc(this)" cssclass="c-f" maxlength="24" onblur="fnc_bikoCheck(this,3),fncFo(this,1)" onfocus="fncFo(this,2)" style="IME-MODE: active;"></asp:textbox></td>
                    <td><asp:textbox id="txtRENTEL3_UPD_DATE" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
								Width="140px"></asp:textbox></td>
                    <td></td>
                </tr>
                <%--2016/12/19 H.Mori del(mod) 2016���P�J�� No5-1 START                               
                <tr><td colspan="6"><br /><br /></td></tr>
                <tr>
                   <td colspan="4" style="text-align:center;">
						<input class="bt-LNG" id="btnTelHas" onblur="fncFo(this,5)" style="WIDTH:120px;TEXT-ALIGN:center"
							onfocus="fncFo(this,2)" onclick="return fncDial_Tel();" tabindex="-1" type="button"
							value="�d�b���M" name="btnTelHas" runat="server"/>
                   </td>
                    <td colspan="2" style="text-align:center;">
						<input class="bt-LNG" id="btnTelEnt" onblur="fncFo(this,5)" style="WIDTH:120px;TEXT-ALIGN:center"
							onfocus="fncFo(this,2)" onclick="return fncDataEnt();" tabindex="-1" type="button"
							value="�o�^" name="btnTelEnt" runat="server"/>
                   </td>               
                </tr> --%>
                <tr><td><br /><br /></td></tr>
                <%-- 2016/12/19 H.Mori del(mod) 2016���P�J�� No5-1 END --%>
            </table>
            <%-- 2016/12/19 H.Mori add 2016���P�J�� No5-1 START --%>
            <table class="W_FRAME1">
                <tr>
                    <%-- <td colspan="4"><label class="W_TITLE_5">�����L�A����́A����ȊO�g�p�֎~</label></td> 2021/02/05 T.Ono mod 2020���P�J�� --%>
                    <td colspan="4"><label class="W_TITLE_5">������E�_�ސ�E�L���ȊO�g�p�֎~</label></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="W_TITLE"><label for="rdoTel_AB" class="W_TITLE_2">�d�b�ԍ�</label></td>
                    <td><input id="rdoTel_AB"  onblur="fncFo(this,4)" 
                                            onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server" value="3"/></td>
                    <td><asp:textbox id="txtTELAB" tabIndex="1" runat="server" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" CssClass="c-rNM" maxlength="20" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"></asp:textbox></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="W_TITLE"><label for="rdoTel_DAI3" class="W_TITLE_2">��3�A���A����</label></td>
                    <td><input id="rdoTel_DAI3"  onblur="fncFo(this,4)" 
                                            onfocus="fncFo(this,2)" tabindex="-1" type="radio"
											name="rdoTel" runat="server" value="3"/></td>
                    <td><asp:textbox id="txtDAI3RENDORENTEL" tabIndex="1" runat="server" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" CssClass="c-rNM" maxlength="15" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"></asp:textbox></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
            <%-- 2016/12/19 H.Mori mod 2016���P�J�� No5-1 END ���L�A���楥���3�A���A�����table�� --%>
            <%-- 2016/12/19 H.Mori mod 2016���P�J�� No5-1 START �d�b���M�A�o�^�{�^����table�� --%>
            <table>
                <tr><td><br /><br /></td></tr>
                <tr>
                   <td width="315" style="text-align:right;">
						<input class="bt-LNG" id="btnTelHas" onblur="fncFo(this,5)" style="WIDTH:120px;TEXT-ALIGN:center"
							onfocus="fncFo(this,2)" onclick="return fncDial_Tel();" tabindex="-1" type="button"
							value="�d�b���M" name="btnTelHas" runat="server"/>
                   </td>
                   <td width="205"></td>
                    <td width="320" style="text-align:left;">
						<input class="bt-LNG" id="btnTelEnt" onblur="fncFo(this,5)" style="WIDTH:120px;TEXT-ALIGN:center"
							onfocus="fncFo(this,2)" onclick="return fncDataEnt();" tabindex="-1" type="button"
							value="�o�^" name="btnTelEnt" runat="server"/>
                   </td>               
                </tr>
            </table>
            <%-- 2016/12/19 H.Mori mod 2016���P�J�� No5-1 END �d�b���M�A�o�^�{�^����table�� --%>
        </form>
	</body>
</HTML>
