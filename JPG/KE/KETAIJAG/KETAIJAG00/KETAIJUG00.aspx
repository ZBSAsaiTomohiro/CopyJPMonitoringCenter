<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KETAIJUG00.aspx.vb" Inherits="JPG.KETAIJAG00.KETAIJUG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�R�s�[�⏕���</title>
		<script language="JavaScript">
			window.resizeTo(300,280);
			window.moveTo(25,25);
		</script>
		<style>
		    .W_TITLE { WIDTH: 100px; font-size: 13px;}
	    </style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label>
            <table>
                <tr>
                    <td align="right" colspan="2">
                        <input language="javascript" class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="return btnExit_onclick(); __doPostBack('btnExit','')" tabIndex="1" type="button"
							value="�I��" name="btnExit"/></td>
                </tr>
                <tr>
                    <td class="W_TITLE">�N���C�A���g�R�[�h</td>
                    <td><asp:textbox id="txtKURACD" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" ReadOnly="True" onclick="copy('txtKURACD');" onmousedown="copy('txtKURACD');"></asp:textbox></td>
                </tr>
                <tr>
                    <td class="W_TITLE">�i�`�x���R�[�h</td>
                    <td><asp:textbox id="txtACBCD" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" ReadOnly="True" onclick="copy('txtACBCD');" onmousedown="copy('txtACBCD');"></asp:textbox></td>
                </tr>
                <tr>
                    <td class="W_TITLE">���q�l�R�[�h</td>
                    <td><asp:textbox id="txtUSER_CD" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" ReadOnly="True" onclick="copy('txtUSER_CD');" onmousedown="copy('txtUSER_CD');"></asp:textbox></td>
                </tr>
                <tr>
                    <td class="W_TITLE">�d�b�ԍ��s�O</td>
                    <td><asp:textbox id="txtTEL1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" ReadOnly="True" onclick="copy('txtTEL1');" onmousedown="copy('txtTEL1');"></asp:textbox></td>
                </tr>
                <tr>
                    <td class="W_TITLE">�d�b�ԍ��s��</td>
                    <td><asp:textbox id="txtTEL2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
								Width="140px" ReadOnly="True" onclick="copy('txtTEL2');" onmousedown="copy('txtTEL2');"></asp:textbox></td>
                </tr>
            </table>
        </form>
	</body>
</HTML>
