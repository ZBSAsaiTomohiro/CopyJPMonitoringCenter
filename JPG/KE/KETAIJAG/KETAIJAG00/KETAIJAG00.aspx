<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KETAIJAG00.aspx.vb" Inherits="JPG.KETAIJAG00.KETAIJAG00" EnableSessionState="ReadOnly" enableViewState="False" enableViewStateMac="False"%>
<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>KETAIJAG00</title>
	<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 START --%>
		<%--<style>.POSS_META { LEFT: 100px; POSITION: absolute; TOP: 265px }
	.POSS_YOUKI { LEFT: 100px; POSITION: absolute; TOP: 307px }
	.POSS_SIYOU { LEFT: 310px; POSITION: absolute; TOP: 300px }
	.POSS_KENSIN { LEFT: 470px; POSITION: absolute; TOP: 347px }
	.POSS_BONBE { LEFT: 642px; POSITION: absolute; TOP: 265px }
	.POSS_HAISO { LEFT: 470px; POSITION: absolute; TOP: 265px }
	.POSS_GASU { LEFT: 815px; POSITION: absolute; TOP: 265px }
	.POSS_HAISI { LEFT: 310px; POSITION: absolute; TOP: 408px }
	.POSS_RIREKI { LEFT: 870px; POSITION: absolute; TOP: 403px }
	.POSS_KAITU_DAY { LEFT: 37px; POSITION: absolute; TOP: 415px } /* 2013/08/15 T.Ono add �Ď����P2013��1 */ --%>
	<style>.POSS_META { LEFT: 100px; POSITION: absolute; TOP: 286px } 
	.POSS_YOUKI { LEFT: 100px; POSITION: absolute; TOP: 328px }
	.POSS_SIYOU { LEFT: 310px; POSITION: absolute; TOP: 321px }
	.POSS_KENSIN { LEFT: 470px; POSITION: absolute; TOP: 368px }
	.POSS_BONBE { LEFT: 642px; POSITION: absolute; TOP: 286px }
	.POSS_HAISO { LEFT: 470px; POSITION: absolute; TOP: 286px }
	.POSS_GASU { LEFT: 815px; POSITION: absolute; TOP: 286px }
	.POSS_HAISI { LEFT: 310px; POSITION: absolute; TOP: 431px } /* 2016/01/08 T.Ono mod 2015���P�J�� ����̒����̂���TOP�ύX429��431 */
	.POSS_RIREKI { LEFT: 870px; POSITION: absolute; TOP: 424px }
	.POSS_KAITU_DAY { LEFT: 37px; POSITION: absolute; TOP: 436px } /* 2013/08/15 T.Ono add �Ď����P2013��1 */
	/* 2013/07/24 mod T.Ono */
	/* .POSS_GUIDELINE { LEFT: 1000px; OVERFLOW: auto; POSITION: absolute; TOP: 30px } */
	.POSS_GUIDELINE { LEFT: 1015px; OVERFLOW: auto; POSITION: absolute; TOP: 30px }
	/* 2013/06/25 add T.Ono */
	.GUIDELINE_lbl { OVERFLOW: hidden; WIDTH: 100%; HEIGHT: 100% }
	.TELMEMO{
	  font-family: "�l�r �S�V�b�N",sans-serif;
	  font-size: 13px; 
	  width:710px;
	  height:50px;
	  overflow:hidden; /* ��۰��ް���� */
	  word-break:break-all; /* IE�̂݁A�P��r���ł����s */
	  IME-MODE: active; /* ���̓��[�h�S�p */
	}
	</style>
	</HEAD>
	<body onunload="parent.window_onunload();" onload="fncOnLoad();">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><input id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
			<%-- 2017/03/06 T.Ono del CTI�X�� ����TEL�N���g�p�������M�����ɕύX
            <OBJECT id="Dial" codeBase="/JPG/DialCab.CAB#Version=1,0,0,1" height="1" width="1" classid="clsid:478F512E-2E06-4665-8719-CD51B2237224"
				name="Dial" viewastext>
				<PARAM NAME="_Version" VALUE="65536">
				<PARAM NAME="_ExtentX" VALUE="26">
				<PARAM NAME="_ExtentY" VALUE="26">
				<PARAM NAME="_StockProps" VALUE="0">
			</OBJECT> --%>
			<table id="Table4" cellspacing="0" cellpadding="0" width="985">
				<tr>
					<td class="TITLE" valign="middle" width="600"><asp:label id="lblTitle" runat="server"></asp:label></td>
					<td align="right">
                            <!-- 2013/08/15 T.Ono add �Ď����P2013��1 -->
                            <input class="bt-RNW" id="btnCopy" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnCopy_onclick()"
							tabindex="96" type="button" value="�ں݂ւ̺�߰�⏕" name="btnExit" runat="server">&nbsp;
                            <input language="javascript" class="bt-JIK" id="btnPrint" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="btnPrint_onclick();" tabindex="96" type="button" value="���" name="btnPrint">&nbsp;<input class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();"
							tabindex="96" type="button" value="�I��" name="btnExit" runat="server">
					</td>
				</tr>
			</table>
			<table id="Table5" cellspacing="1" cellpadding="1" width="985">
				<tr>
					<td class="T" valign="middle" height="13">&nbsp;&nbsp;<b>��M���</b> <input id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server"><input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server">
						<input id="hdnBackUrl" type="hidden" name="hdnBackUrl" runat="server"> <input id="hdnKBN" type="hidden" name="hdnKBN" runat="server">
						<input id="hdnEDT_DATE" type="hidden" name="hdnEDT_DATE" runat="server"> <input id="hdnADD_DATE" type="hidden" name="hdnADD_DATE" runat="server">
						<input id="hdnTIME" type="hidden" name="hdnTIME" runat="server"><input id="hdnTAIO_ST_DATE" type="hidden" name="hdnTAIO_ST_DATE" runat="server"><input id="hdnTAIO_ST_TIME" type="hidden" name="hdnTAIO_ST_TIME" runat="server"><input id="hdnJUYMD" type="hidden" name="hdnJUYMD" runat="server"><input id="hdnJUTIME" type="hidden" name="hdnJUTIME" runat="server">
						<input id="hdnFocusObj" type="hidden" name="hdnFocusObj" runat="server"> <input id="hdnUNYOCD" type="hidden" name="hdnUNYOCD" runat="server">
						<input id="hdnTELEXEPATH" type="hidden" name="hdnTELEXEPATH" runat="server"> <input id="hdnTELWAITFLG" type="hidden" name="hdnTELWAITFLG" runat="server">
						<input id="hdnTELPLSTORN" type="hidden" name="hdnTELPLSTORN" runat="server"> <input id="hdnTELEXENAME" type="hidden" name="hdnTELEXENAME" runat="server">
						<input id="hdnTELEXERESULT" type="hidden" name="hdnTELEXERESULT" runat="server">
						<input id="hdnTELHEAD" type="hidden" name="hdnTELHEAD" runat="server"> <input id="hdnATCOMMAND" type="hidden" name="hdnATCOMMAND" runat="server">
						<input id="hdnDialKbns" type="hidden" name="hdnDialKbns" runat="server"> <input id="hdnDialNumbers" type="hidden" name="hdnDialNumbers" runat="server"><input id="hdnDialAitename" type="hidden" name="hdnDialAitename" runat="server">
						<input id="hdnDialResult" type="hidden" name="hdnDialResult" runat="server"> <input id="hdnDialDates" type="hidden" name="hdnDialDates" runat="server">
						<input id="hdnDialTimes" type="hidden" name="hdnDialTimes" runat="server"> <input id="hdnDialStates" type="hidden" name="hdnDialStates" runat="server">
						<input id="hdnKMCD1" type="hidden" name="hdnKMCD1" runat="server"> <input id="hdnKMNM1" type="hidden" name="hdnKMNM1" runat="server">
						<input id="hdnKMCD2" type="hidden" name="hdnKMCD2" runat="server"> <input id="hdnKMNM2" type="hidden" name="hdnKMNM2" runat="server">
						<input id="hdnKMCD3" type="hidden" name="hdnKMCD3" runat="server"> <input id="hdnKMNM3" type="hidden" name="hdnKMNM3" runat="server">
						<input id="hdnKMCD4" type="hidden" name="hdnKMCD4" runat="server"> <input id="hdnKMNM4" type="hidden" name="hdnKMNM4" runat="server">
						<input id="hdnKMCD5" type="hidden" name="hdnKMCD5" runat="server"> <input id="hdnKMNM5" type="hidden" name="hdnKMNM5" runat="server">
						<input id="hdnKMCD6" type="hidden" name="hdnKMCD6" runat="server"> <input id="hdnKMNM6" type="hidden" name="hdnKMNM6" runat="server"><input id="hdnKTELNO" type="hidden" name="hdnKTELNO" runat="server">
                        <!-- 2020/03/11 T.Ono add 2019�Ď����P -->
                        <input id="hdnrdoMsg" type="hidden" name="hdnrdoMsg" runat="server">
                        <!-- 2014/02/12 T.Ono add �Ď����P2013�@�d���\�� -->
                        <input id="hdnchoufukuhyouji" type="hidden" name="hdnchoufukuhyouji" runat="server" />
					</td>
				</tr>
			</table>
			<table id="Table6" border="0" cellspacing="0" cellpadding="0" width="985">
				<!-- 2008/10/15 T.Watabe add -->
				<tr>
					<td align="right" width="120">��������&nbsp; <input id="hdnNCUHATYMD" type="hidden" name="hdnNCUHATYMD" runat="server">
						<input id="hdnNCUDiffChkMin" type="hidden" name="hdnNCUDiffChkMin" runat="server"><!-- 2008/10/16 T.Watabe add -->
					</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap colspan="8">
						<asp:textbox id="txtNCUHATYMD" tabindex="90" runat="server" readonly="True" width="88px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txtNCUHATTIME" tabindex="91" runat="server" readonly="True" width="48px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>
						<span id="NCUHAT_MSG"></span>
					</td>--%>
                    <td nowrap colspan="2">
						<asp:textbox id="txtNCUHATYMD" tabindex="90" runat="server" width="88px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txtNCUHATTIME" tabindex="91" runat="server" width="48px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>
						<span id="NCUHAT_MSG"></span>&nbsp;<label for="chkMSGSEI">�x��C��</label><input id="chkMSGSEI" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							    tabindex="31" type="checkbox" name="chkSYUSEI" onclick="chkMSGSEI_onclick()" runat="server">
					</td>
                    <%--2016/12/05 H.Mori add 2016���P�J�� No4-8 START  --%>
                    <td nowrap colspan="2" align="right">
                        <div class="nopr">
                            <label for="chkSYUSEI">�f�[�^�C���`�F�b�N�{�b�N�X&nbsp;</label>
                        </div>
                    </td>
                    <td>
                        <div class="nopr">
                            <input id="chkSYUSEI" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							    tabindex="31" type="checkbox" name="chkSYUSEI" onclick="chkSYUSEI_onclick()" runat="server">
                        </div>
                    </td>
                    <td></td><td></td>
                    <%--2016/12/05 H.Mori add 2016���P�J�� No4-8 END  --%>
				</tr>
				<tr>
					<td align="right">��M����&nbsp;<input id="hdnHATYMD" type="hidden" name="hdnHATYMD" runat="server">
					</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap colspan="3"><asp:textbox id="txtHATYMD" tabindex="92" runat="server" readonly="True" width="88px" borderstyle="Solid"
							onkeydown="fncFc(this)" onblur="fncFo_date(this,1);fncHATYMDDiffChk();" onfocus="fncNowDate(this)" borderwidth="1px"
							cssclass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txtHATTIME" tabindex="93" runat="server" readonly="True" width="48px" borderstyle="Solid"
							onkeydown="fncFc(this)" onblur="fncFo_time(this,1);fncHATYMDDiffChk();" onfocus="fncFo_time(this,2)" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;���q�lFLG
						<asp:textbox id="txtUSER_FLG" tabindex="-1" runat="server" readonly="True" width="48px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���[�^�[�l<input id="hdnNUM_DIGIT" type="hidden" name="hdnNUM_DIGIT" runat="server">
					</td>--%>
                    <td nowrap colspan="3"><asp:textbox id="txtHATYMD" tabindex="92" runat="server" width="88px" borderstyle="Solid"
							onkeydown="fncFc(this)" onblur="fncFo_date(this,1);fncHATYMDDiffChk();" onfocus="fncNowDate(this)" borderwidth="1px"
							cssclass="c-rNM"></asp:textbox>&nbsp;<asp:textbox id="txtHATTIME" tabindex="93" runat="server" width="48px" borderstyle="Solid"
							onkeydown="fncFc(this)" onblur="fncFo_time(this,1);fncHATYMDDiffChk();" onfocus="fncFo_time(this,2)" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;���q�lFLG
						<asp:textbox id="txtUSER_FLG" tabindex="-1" runat="server" width="48px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���[�^�[�l<input id="hdnNUM_DIGIT" type="hidden" name="hdnNUM_DIGIT" runat="server">
					</td>
					<td align="right">���q�l�R�[�h&nbsp;</td>
                    <%--2016/12/06 H.Mori mod 2016���P�J�� No4-8 START --%>
					<%-- 2013/06/27 T.Ono mod
                    <td><asp:textbox id="txtJUYOKA" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="3" runat="server" width="200px" cssclass="c-f" maxlength="20"></asp:textbox></td>--%>
                    <%-- <td><asp:textbox id="txtJUYOKA" onkeydown="fncFc(this)" onblur="fncFo(this,1);fncJUYOKAblur();" onfocus="fncFo(this,2)"
							tabindex="3" runat="server" width="200px" cssclass="c-f" maxlength="20"></asp:textbox></td> --%>
                    <td><asp:textbox id="txtJUYOKA" onkeydown="fncFc(this)" onblur="fncFo(this,1);fncJUYOKAblur();" onfocus="fncFo(this,2)"
							tabindex="3" runat="server" width="200px" cssclass="c-rNM" borderstyle="Solid" borderwidth="1px" maxlength="20"></asp:textbox></td>
					<%--2016/12/06 H.Mori mod 2016���P�J�� No4-8 END --%>
                    <td align="right" width="46">�A����&nbsp;</td>
                    <%-- 2016/12/05 H.Mori mod 2016���P�J�� No4-4 START
					<td><asp:textbox id="txtRENTEL" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="9" runat="server" width="110px" cssclass="c-f" maxlength="20"></asp:textbox></td> --%>
                    <td><asp:textbox id="txtRENTEL" onkeydown="fncFc(this)" onblur="fncFo_OKYAKU(this,3)" onfocus="fncFo(this,2)"
                            tabindex="9" runat="server" width="130px" cssclass="c-rNM" borderstyle="Solid" borderwidth="1px" maxlength="20"></asp:textbox></td> <%-- 2021/10/01 2021�N�x�Ď����P�FTEL��14�P�^����width��110px��130px�ɕύX --%>
                    <%-- 2016/12/05 H.Mori mod 2016���P�J�� No4-4 END --%>
				</tr>
				<tr>
					<td align="right">�x�񃁃b�Z�[�W��&nbsp;</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td colspan="3"><asp:textbox id="txtKEIHOSU" tabindex="-1" runat="server" readonly="True" width="24px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;���ʋ敪&nbsp;
						<asp:textbox id="txtRYURYO" tabindex="-1" runat="server" readonly="True" width="24px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp; ���[�^�[���&nbsp;
						<asp:textbox id="txtMETASYU" tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtKMSIN" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="72px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <td colspan="3"><asp:textbox id="txtKEIHOSU" tabindex="-1" runat="server" width="24px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;���ʋ敪&nbsp;
						<asp:textbox id="txtRYURYO" tabindex="-1" runat="server" width="24px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp; ���[�^�[���&nbsp;
						<asp:textbox id="txtMETASYU" tabindex="-1" runat="server" width="112px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtKMSIN" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="72px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
					<%-- <td align="right">���q�l����&nbsp;</td> --%><%-- 2015/01/21 T.Ono mod 2014���P�J�� No2 --%>
					<td align="right">���q�l��&nbsp;</td>
                    <%--2016/12/06 H.Mori mod 2016���P�J�� No4-8 
					<td colspan="2"><asp:textbox id="txtJUSYONM" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="4" runat="server" width="245px" cssclass="c-fI" maxlength="15"></asp:textbox></td>--%>
                    <td colspan="2"><asp:textbox id="txtJUSYONM" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="4" runat="server" width="245px" cssclass="c-rNM" borderstyle="Solid" borderwidth="1px" maxlength="15"></asp:textbox></td>
                    <%-- 2016/02/02 w.ganeko mod 2015���P�J�� ��1-3 start --%>
					<%-- <td align="right" rowspan="3"><input class="bt-LNG" id="btnTelHas1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnDial_onclick('1',Form1.txtRENTEL.value,Form1.txtJUSYONM.value);"
							tabindex="10" type="button" value="�d�b���M" name="btnTelHas1" runat="server">
					</td> --%>
                    <td align="right" rowspan="3"><input class="bt-LNG" id="btnTelHas1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncChkRocuser('1');"
							tabindex="10" type="button" value="&nbsp;&nbsp;&nbsp;�d�b&#13;&#10;���M" name="btnTelHas1" runat="server" style="font-size:11pt;height:60px;width:80px;"/><input class="bt-LNG" id="btnTelHas2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncChkRocuser('2');"
							tabindex="10" type="button" value="&nbsp;&nbsp;&nbsp;&nbsp;�d�b&#13;&#10;&nbsp;&nbsp;&nbsp;&nbsp;�ԍ�&#13;&#10;�I��" name="btnTelHas2" runat="server" style="font-size:9pt;height:60px;width:60px;"/>
					</td> <%--2017/10/19 H.Mori mod 2017���P�J�� No4-3 id="btnTelHas1"��onclick="btnDial_onclick('1',Form1.txtRENTEL.value,Form1.txtJUSYONM.value);" ���@onclick="fncChkRocuser('1');"�@�ɕύX�B id="btnTelHas2"��onclick="btnRenraku_onclick('3');"�@���@onclick="fncChkRocuser('2');"�@�ɕύX�B --%>
					<%--<td align="right"><input class="bt-LNG" id="btnOpenTel1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="btnDial_onclick('1',Form1.txtRENTEL.value,Form1.txtJUSYONM.value);"
							tabindex="10" type="button" value="�d�b&#13;&#10;�ԍ�&#13;&#10;�I��" name="btnOpenTel1" runat="server">
					</td>--%>
                    <%-- 2016/02/02 w.ganeko mod 2015���P�J�� ��1-3 end --%>
				</tr>
				<tr>
					<td align="right">�x�񃁃b�Z�[�W�P&nbsp;</td>
					<td colspan="3">
                        <%-- 2020/11/01 T.Ono mod �Ď����P2020
                        <!-- 2013/08/15 T.Ono add �Ď����P2013��1 -->
                        <input id="rdoMsg1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" 
										tabindex="94" type="radio" CHECKED value="1" name="rdoMsg" runat="server"> --%>
                        <input id="rdoMsg1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" onclick="fncMsgchange()" 
										tabindex="94" type="radio" CHECKED value="1" name="rdoMsg" runat="server">
                        <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<asp:textbox id="txtKMNM1" tabindex="-1" runat="server" readonly="True" width="266px" borderstyle="Solid"--%>
                        <asp:textbox id="txtKMNM1" tabindex="-1" runat="server" width="266px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnKEICD1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('11');"
							tabindex="1" type="button" value="��" name="btnKEICD1" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;�N���C�A���g�R�[�h</td>
					<td align="right">�t���K�i&nbsp;</td>
                    <%--2016/12/06 H.Mori mod 2016���P�J�� No4-8 
					<td><asp:textbox id="txtJUSYOKN" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="5" runat="server" width="200px" cssclass="c-fI" maxlength="12"></asp:textbox></td>--%>
				    <td><asp:textbox id="txtJUSYOKN" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="5" runat="server" width="200px" cssclass="c-rNM" borderstyle="Solid" borderwidth="1px" maxlength="12"></asp:textbox></td>
                </tr>
				<tr>
					<td align="right">�x�񃁃b�Z�[�W�Q&nbsp;</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td colspan="3"><asp:textbox id="txtKMNM2" tabindex="-1" runat="server" readonly="True" width="266px" borderstyle="Solid"--%>
                    <td colspan="3">
                        <%-- 2020/11/01 T.Ono mod �Ď����P2020
                        <!-- 2013/08/15 T.Ono add �Ď����P2013��1 -->
                        <input id="rdoMsg2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="94" type="radio" value="2" name="rdoMsg" runat="server"> --%>
                        <input id="rdoMsg2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" onclick="fncMsgchange()"
										tabindex="94" type="radio" value="2" name="rdoMsg" runat="server">
                        <asp:textbox id="txtKMNM2" tabindex="-1" runat="server" width="266px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnKEICD2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('12');"
							tabindex="1" type="button" value="��" name="btnKEICD2" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;
						<%--<asp:textbox id="txtClientCD" tabindex="-1" runat="server" readonly="True" width="35px" borderstyle="Solid"--%>
                        <asp:textbox id="txtClientCD" tabindex="-1" runat="server" width="35px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-h"></asp:textbox><input class="bt-KS" id="btnKURACD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('1');"
							tabindex="1" type="button" value="��" name="btnKURACD" runat="server"><input id="txtClientNAME" type="hidden" name="txtClientNAME" runat="server">
						<input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server">
					</td>
					<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 START --%>
					<%-- <td align="right">�d�b�ԍ�&nbsp;</td> --%>
					<td align="right">�����ԍ�&nbsp;</td>
					<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 END --%>
                    <%-- 2016/12/06 H.Mori mod 2016���P�J�� No4-8 START --%>
                    <%-- <td colspan="1"><asp:textbox id="txtJUTEL1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="6" runat="server" width="112px" cssclass="c-f" maxlength="10"></asp:textbox><asp:textbox id="txtJUTEL2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="7" runat="server" width="112px" cssclass="c-f" maxlength="10"></asp:textbox>
					     </td>--%>
					<td colspan="1"><asp:textbox id="txtJUTEL1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="6" runat="server" width="112px" cssclass="c-rNM" borderstyle="Solid" borderwidth="1px" maxlength="10"></asp:textbox>&nbsp;<asp:textbox id="txtJUTEL2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="7" runat="server" width="112px" cssclass="c-rNM" borderstyle="Solid" borderwidth="1px" maxlength="10"></asp:textbox>
					</td>
                    <%-- 2016/12/06 H.Mori mod 2016���P�J�� No4-8 END --%>
				</tr>
				<tr>
					<td align="right">�x�񃁃b�Z�[�W�R&nbsp;</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td colspan="3"><asp:textbox id="txtKMNM3" tabindex="-1" runat="server" readonly="True" width="266px" borderstyle="Solid"--%>
                    <td colspan="3">
                        <%-- 2020/11/01 T.Ono mod �Ď����P2020
                        <!-- 2013/08/15 T.Ono add �Ď����P2013��1 -->
                        <input id="rdoMsg3" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="94" type="radio" value="3" name="rdoMsg" runat="server">�@--%>
                        <input id="rdoMsg3" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" onclick="fncMsgchange()"
										tabindex="94" type="radio" value="3" name="rdoMsg" runat="server">
                        <asp:textbox id="txtKMNM3" tabindex="-1" runat="server" width="266px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnKEICD3" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('13');"
							tabindex="1" type="button" value="��" name="btnKEICD3" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;����
					</td>
					<td align="right" rowspan="2">�Z��&nbsp;</td>
                    <%-- 2016/12/06 H.Mori mod 2016���P�J�� No4-8 
                    <td valign="top" colspan="3" rowspan="2"><asp:textbox id="txtADDR" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" tabindex="8" runat="server"
					        width="350px" cssclass="c-fI" height="42px" textmode="MultiLine"></asp:textbox></td>--%>
					<td valign="top" colspan="3" rowspan="2"><asp:textbox id="txtADDR" onblur="return fncADDR(this,1);" onfocus="return fncADDR(this,2);" tabindex="8" runat="server"
							width="350px" cssclass="c-rNM" borderstyle="Solid" borderwidth="1px" height="42px" textmode="MultiLine"></asp:textbox>
<%-- //2023/09/22_�e�X�g���� --%>
<input 
  type="button" 
  name="btnCopyAddress" 
  id="btnCopyAddress" 
  class="bt-LNG" 
  tabindex="10" 
  onfocus="fncFo(this,2)" 
  onblur="fncFo(this,5)" 
  onclick="copyTxtADDR();"
  value="�&#13;&#10;��&#13;&#10;�" 
  runat="server" 
  style="font-size:9pt;height:42px;width:20px;text-align:center;writing-mode:vertical-rl;" 
  />
<input 
  type="button" 
  name="btnSearchAddress" 
  id="btnSearchAddress" 
  class="bt-LNG" 
  tabindex="10" 
  onfocus="fncFo(this,2)" 
  onblur="fncFo(this,5)" 
  onclick="openSearchAddress();"
  value="��&#13;&#10;��" 
  runat="server" 
  style="font-size:9pt;height:42px;width:20px;text-align:center;writing-mode:vertical-rl;" 
  />

<%-- //2023/09/22_�e�X�g���������܂� --%>

					</td>
				</tr>
				<tr>
					<td align="right">�x�񃁃b�Z�[�W�S&nbsp;</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td colspan="3"><asp:textbox id="txtKMNM4" tabindex="-1" runat="server" readonly="True" width="266px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnKEICD4" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('14');"
							tabindex="1" type="button" value="��" name="btnKEICD4" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtKENNM" tabindex="-1" runat="server" readonly="True" width="88px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <td colspan="7">
                        <%-- 2020/11/01 T.Ono mod �Ď����P2020
                        <!-- 2013/08/15 T.Ono add �Ď����P2013��1 -->
                        <input id="rdoMsg4" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="94" type="radio" value="4" name="rdoMsg" runat="server"> --%>
                        <input id="rdoMsg4" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" onclick="fncMsgchange()"
										tabindex="94" type="radio" value="4" name="rdoMsg" runat="server">
                        <asp:textbox id="txtKMNM4" tabindex="-1" runat="server" width="266px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnKEICD4" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('14');"
							tabindex="1" type="button" value="��" name="btnKEICD4" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtKENNM" tabindex="-1" runat="server" width="88px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right">�x�񃁃b�Z�[�W�T&nbsp;</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td colspan="3"><asp:textbox id="txtKMNM5" tabindex="-1" runat="server" readonly="True" width="266px" borderstyle="Solid"--%>
                    <td colspan="3">
                        <%-- 2020/11/01 T.Ono mod �Ď����P2020
                        <!-- 2013/08/15 T.Ono add �Ď����P2013��1 -->
                        <input id="rdoMsg5" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="94" type="radio" value="5" name="rdoMsg" runat="server"> --%>
                        <input id="rdoMsg5" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" onclick="fncMsgchange()"
										tabindex="94" type="radio" value="5" name="rdoMsg" runat="server">
                        <asp:textbox id="txtKMNM5" tabindex="-1" runat="server" width="266px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnKEICD5" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('15');"
							tabindex="1" type="button" value="��" name="btnKEICD5" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;�i�`�x����
					</td>
					<td align="right">
						<div class="nopr">���l&nbsp;</div>
					</td>
					<%--<td colspan="3"><asp:textbox id="txtUSER_KIJI" tabindex="-1" runat="server" readonly="True" width="365px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM-nopr c-rNM"></asp:textbox></td>--%>
                    <td colspan="3"><asp:textbox id="txtUSER_KIJI" tabindex="-1" runat="server" width="365px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM-nopr c-rNM"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right">�x�񃁃b�Z�[�W�U&nbsp;</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap colspan="5">
						<asp:textbox id="txtKMNM6" tabindex="-1" runat="server" readonly="True" width="266px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnKEICD6" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('16');"
							tabindex="1" type="button" value="��" name="btnKEICD6" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtACBNM" tabindex="-1" runat="server" readonly="True" width="288px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-h"></asp:textbox><input class="bt-KS" id="btnJASCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabindex="2" type="button" value="��" name="btnJASCD" runat="server"><input id="hdnJASCD" type="hidden" name="hdnJASCD" runat="server"></td>--%>
                    <td nowrap colspan="7">
                        <%-- 2020/11/01 T.Ono mod �Ď����P2020
                        <!-- 2013/08/15 T.Ono add �Ď����P2013��1 -->
                        <input id="rdoMsg6" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
										tabindex="94" type="radio" value="6" name="rdoMsg" runat="server"> --%>
                        <input id="rdoMsg6" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" onclick="fncMsgchange()"
										tabindex="94" type="radio" value="6" name="rdoMsg" runat="server">
						<asp:textbox id="txtKMNM6" tabindex="-1" runat="server" width="266px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnKEICD6" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('16');"
							tabindex="1" type="button" value="��" name="btnKEICD6" runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtACBNM" tabindex="-1" runat="server" width="288px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-h"></asp:textbox><input class="bt-KS" id="btnJASCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('2');"
							tabindex="2" type="button" value="��" name="btnJASCD" runat="server"><input id="hdnJASCD" type="hidden" name="hdnJASCD" runat="server">
                        <span style="border-style: solid ; border-width: 1px;">
                        <label for="chkFAXKBN">�񍐕s�v<div id="divFaxKbnDisp1" name="divFaxKbnDisp1" style="DISPLAY:inline">(JA)</div></label><input id="chkFAXKBN" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabindex="31" type="checkbox" name="chkFAXKBN" runat="server"><div id="divFaxKbnDisp2" name="divFaxKbnDisp2" style="DISPLAY:inline"><label for="chkFAXKURAKBN">(�ײ���)</label><input id="chkFAXKURAKBN" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
								tabindex="31" type="checkbox" name="chkFAXKURAKBN" runat="server"></div>&nbsp;
                        <div id="divFaxKbnDisp3" name="divFaxKbnDisp3" style="DISPLAY:inline"><label for="chkFAXRUISEKIKBN">(�ݐ�)</label><input id="chkFAXRUISEKIKBN" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
								tabindex="31" type="checkbox" name="chkFAXRUISEKIKBN" runat="server"></div></span></td>
				</tr>
				<%-- 2014/11/28 H.Hosoda add 2014���P�J�� No2 START --%>
				<%-- 2016/01/08 T.Ono mod 2015���P�J�� ����̒����̂���height�w��--%>
                <%-- <tr > --%>
                <tr style="height:13px" >
                    <%-- 2015/11/16 H.Mori mod 2015���P�J�� No1
					<td align="right">�̔����Ǝ�&nbsp;</td> --%>
                    <td align="right" class="nopr">�̔����Ǝ�&nbsp;</td>
                    <%-- 2016/02/02 w.ganeko mod 2015���P�J�� No1-3 start --%>
					<%-- <td nowrap colspan="7"> --%>
                    <%-- <asp:textbox id="txtHANGRP" tabindex="-1" runat="server" width="868px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM-nopr c-rNM"></asp:textbox> --%>
					<td nowrap colspan="3">
                        <asp:textbox id="txtHANGRP" tabindex="-1" runat="server" width="420px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM-nopr c-rNM"></asp:textbox>
                    </td>
                    <td align="right" class="nopr">�Ď����l&nbsp;</td>
                    <td nowrap colspan="3">
                        <asp:textbox id="txtKANSHI_BIKO" tabindex="-1" runat="server" width="400px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM-nopr c-rNM"></asp:textbox>
                    </td>
                    <%-- 2016/02/02 w.ganeko mod 2015���P�J�� No1-3 end --%>
                    <!--<input name="txtHANGRP" type="text" id="txtHANGRP" tabindex="-1" class="c-rNM-nopr c-rNM" ReadOnly="true" style="border-width:1px;border-style:Solid;width:868px;" /></td> -->
				</tr>
				<%-- 2014/11/28 H.Hosoda add 2014���P�J�� No2 END --%>
				<tr>
					<td width="100"></td>
					<td width="100"></td>
					<td width="100"></td>
					<td width="190"></td>
					<td width="80"></td>
					<td width="170"></td>
					<td width="46"></td>
					<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 START --%>
					<%-- <td width="100"></td> --%>
					<td width="130"></td>
					<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 END --%>
				</tr>
			</table>
			<table id="Table7" cellspacing="1" cellpadding="1" width="985">
				<tr>
					<td class="T" valign="middle" height="13">&nbsp;&nbsp;<b>���q�l���</b> <input id="hdnKEY_SERIAL" type="hidden" name="hdnKEY_SERIAL" runat="server">
						<input id="hdnKEY_CLI_CD" type="hidden" name="hdnKEY_CLI_CD" runat="server"> <input id="hdnKEY_HAN_CD" type="hidden" name="hdnKEY_HAN_CD" runat="server">
						<input id="hdnKEY_USER_CD" type="hidden" name="hdnKEY_USER_CD" runat="server"> <input id="hdnMOVE_NAME" type="hidden" name="hdnMOVE_NAME" runat="server">
						<input id="hdnMOVE_KANAD" type="hidden" name="hdnMOVE_KANAD" runat="server"> <input id="hdnMOVE_CLI_CD" type="hidden" name="hdnMOVE_CLI_CD" runat="server">
						<input id="hdnMOVE_CLI_CD_NAME" type="hidden" name="hdnMOVE_CLI_CD_NAME" runat="server">
						<input id="hdnMOVE_HAN_CD" type="hidden" name="hdnMOVE_HAN_CD" runat="server"> <input id="hdnMOVE_HAN_CD_NAME" type="hidden" name="hdnMOVE_HAN_CD_NAME" runat="server">
						<%-- 2016/11/24 H.Mori add 2016���P�J�� No2-2 START --%>
                        <input id="hdnMOVE_HAN_CD_TO" type="hidden" name="hdnMOVE_HAN_CD_TO" runat="server"> <input id="hdnMOVE_HAN_CD_NAME_TO" type="hidden" name="hdnMOVE_HAN_CD_NAME_TO" runat="server">
                        <%-- 2016/11/24 H.Mori add 2016���P�J�� No2-2 END --%>
                        <input id="hdnMOVE_USER_CD" type="hidden" name="hdnMOVE_USER_CD" runat="server">
						<input id="hdnMOVE_KANSCD" type="hidden" name="hdnMOVE_KANSCD" runat="server"> <input id="hdnMOVE_TEL" type="hidden" name="hdnMOVE_TEL" runat="server"><input id="hdnKEY_KANSCD" type="hidden" name="hdnKEY_KANSCD" runat="server"><input id="hdnKEY_SYONO" type="hidden" name="hdnKEY_SYONO" runat="server">
						<input id="hdnMOVE_TMSKB" type="hidden" name="hdnMOVE_TMSKB" runat="server"> <input id="hdnMOVE_JUTEL" type="hidden" name="hdnMOVE_JUTEL" runat="server">
                        <input id="hdnMOVE_NCUTEL" type="hidden" name="hdnMOVE_NCUTEL" runat="server"> <%-- 2014/12/03 H.Hosoda add 2014���P�J�� No6 --%>
						<input id="hdnMOVE_HATKBN" type="hidden" name="hdnMOVE_HATKBN" runat="server"> <input id="hdnMOVE_TKTANCD" type="hidden" name="hdnMOVE_TKTANCD" runat="server"><input id="hdnMOVE_TKTANNM" type="hidden" name="hdnMOVE_TKTANNM" runat="server">						
    					<%-- 2014/12/04 H.Hosoda mod 2014���P�J�� No7 START --%>
                        <%-- <input id="hdnMOVE_TAIOKBN" type="hidden" name="hdnMOVE_TAIOKBN" runat="server"> --%>
                        <input id="hdnMOVE_TAIOKBN1" type="hidden" name="hdnMOVE_TAIOKBN1" runat="server">
                        <input id="hdnMOVE_TAIOKBN2" type="hidden" name="hdnMOVE_TAIOKBN2" runat="server">
                        <input id="hdnMOVE_TAIOKBN3" type="hidden" name="hdnMOVE_TAIOKBN3" runat="server">
    					<%-- 2014/12/04 H.Hosoda mod 2014���P�J�� No7 END --%>
						<input id="hdnMOVE_JUSYONM" type="hidden" name="hdnMOVE_JUSYONM" runat="server">
						<input id="hdnMOVE_JUSYOKN" type="hidden" name="hdnMOVE_JUSYOKN" runat="server">
						<input id="hdnMOVE_HATYMD_To" type="hidden" name="hdnMOVE_HATYMD_To" runat="server">
						<input id="hdnMOVE_HATTIME_To" type="hidden" name="hdnMOVE_HATTIME_To" runat="server">
						<input id="hdnMOVE_HATYMD_From" type="hidden" name="hdnMOVE_HATYMD_From" runat="server">
						<input id="hdnMOVE_HATTIME_From" type="hidden" name="hdnMOVE_HATTIME_From" runat="server">
						<input id="hdnMOVE_KURACD" type="hidden" name="hdnMOVE_KURACD" runat="server"> <input id="hdnMOVE_KURACD_NAME" type="hidden" name="hdnMOVE_KURACD_NAME" runat="server">
                        <input id="hdnMOVE_ACBCD" type="hidden" name="hdnMOVE_ACBCD" runat="server"> <input id="hdnMOVE_ACBCD_NAME" type="hidden" name="hdnMOVE_ACBCD_NAME" runat="server">
						<%-- 2019/11/01 T.Ono add �Ď����P2019 START --%>
                        <input id="hdnMOVE_KURACD_TO" type="hidden" name="hdnMOVE_KURACD_TO" runat="server"> <input id="hdnMOVE_KURACD_TO_NAME" type="hidden" name="hdnMOVE_KURACD_TO_NAME" runat="server">
                        <input id="hdnMOVE_ACBCD_TO" type="hidden" name="hdnMOVE_ACBCD_TO" runat="server"> <input id="hdnMOVE_ACBCD_TO_NAME" type="hidden" name="hdnMOVE_ACBCD_TO_NAME" runat="server">
						<input id="hdnMOVE_ACBCD_CLI" type="hidden" name="hdnMOVE_ACBCD_CLI" runat="server">
                        <input id="hdnMOVE_ACBCD_TO_CLI" type="hidden" name="hdnMOVE_ACBCD_TO_CLI" runat="server">
                        <%-- 2019/11/01 T.Ono add �Ď����P2019 END --%>
                        <input id="hdnMOVE_MITOKBN" type="hidden" name="hdnMOVE_MITOKBN" runat="server"><input id="hdnMOVE_MODE" type="hidden" name="hdnMOVE_MODE" runat="server">
						<input id="hdnMOVE_KMCD" type="hidden" name="hdnMOVE_KMCD" runat="server"><!-- 2011.11.15 ADD H.Uema -->
                        <%-- 2013/12/09 T.Ono add �Ď����P2013 --%>
                        <input id="hdnKEY_JA_CD" type="hidden" name="hdnKEY_JA_CD" runat="server"> 
                        <input id="hdnMOVE_JA_CD" type="hidden" name="hdnMOVE_JA_CD" runat="server"> <input id="hdnMOVE_JA_CD_NAME" type="hidden" name="hdnMOVE_JA_CD_NAME" runat="server">
    					<%-- 2014/12/03 H.Hosoda add 2014���P�J�� No6 START --%>
                        <input id="hdnKEY_HAN_GRP" type="hidden" name="hdnKEY_HAN_GRP" runat="server"> 
                        <input id="hdnMOVE_HAN_GRP" type="hidden" name="hdnMOVE_HAN_GRP" runat="server"> <input id="hdnMOVE_HAN_GRP_NAME" type="hidden" name="hdnMOVE_HAN_GRP_NAME" runat="server">
    					<%-- 2014/12/03 H.Hosoda add 2014���P�J�� No6 END --%>
                        <%-- 2016/11/22 H.Mori add 2016���P�J�� No2-1 START --%>
                        <input id="hdnKEY_KINREN_GRP" type="hidden" name="hdnKEY_KINREN_GRP" runat="server"> 
                        <input id="hdnMOVE_KINREN_GRP" type="hidden" name="hdnMOVE_KINREN_GRP" runat="server"> <input id="hdnMOVE_KINREN_GRP_NAME" type="hidden" name="hdnMOVE_KINREN_GRP_NAME" runat="server">
    					<%-- 2016/11/22 H.Mori add 2016���P�J�� No2-1 END --%>                          
                        <input id="hdnMOVE_ADDR" type="hidden" name="hdnMOVE_ADDR" runat="server"> <input id="hdnMOVE_KMNM" type="hidden" name="hdnMOVE_KMNM" runat="server">
                        <input id="hdnMOVE_USER_FLG0" type="hidden" name="hdnMOVE_USER_FLG0" runat="server"> <input id="hdnMOVE_USER_FLG1" type="hidden" name="hdnMOVE_USER_FLG0" runat="server">
                        <input id="hdnMOVE_USER_FLG2" type="hidden" name="hdnMOVE_USER_FLG0" runat="server">
                        <%-- 2015/12/15 H.Mori add 2015���P�J�� No4 START --%>
                        <input id="hdnMOVE_HANBAI_KBN1" type="hidden" name="hdnMOVE_HANBAI_KBN1" runat="server"> <input id="hdnMOVE_HANBAI_KBN2" type="hidden" name="hdnMOVE_HANBAI_KBN2" runat="server">
                        <input id="hdnMOVE_HANBAI_KBN3" type="hidden" name="hdnMOVE_HANBAI_KBN3" runat="server"> <input id="hdnMOVE_HANBAI_KBN4" type="hidden" name="hdnMOVE_HANBAI_KBN4" runat="server">
                        <input id="hdnMOVE_HANBAI_KBN5" type="hidden" name="hdnMOVE_HANBAI_KBN5" runat="server"> <input id="hdnMOVE_HANBAI_KBN6" type="hidden" name="hdnMOVE_HANBAI_KBN6" runat="server">
                        <%-- 2015/12/15 H.Mori add 2015���P�J�� No4 END --%>
                        <%-- 2017/10/25 H.Mori add 2017���P�J�� No3-1 START --%>
                        <input id="hdnMOVE_KIKANKBN" type="hidden" name="hdnKIKANKBN" runat="server">
                        <%-- 2017/10/25 H.Mori add 2017���P�J�� No3-1 END --%>
                        <%-- 2019/11/01 T.Ono add �Ď����P2019 No1 START --%>
                        <input id="hdnMOVE_CLI_CD_TO" type="hidden" name="hdnMOVE_CLI_CD_TO" runat="server"><input id="hdnMOVE_CLI_CD_TO_NAME" type="hidden" name="hdnMOVE_CLI_CD_TO_NAME" runat="server">
                        <input id="hdnMOVE_HAN_CD_CLI" type="hidden" name="hdnMOVE_HAN_CD_CLI" runat="server">
                        <input id="hdnMOVE_HAN_CD_TO_CLI" type="hidden" name="hdnMOVE_HAN_CD_TO_CLI" runat="server">
                        <input id="hdnMOVE_JA_CD_CLI" type="hidden" name="hdnMOVE_JA_CD_CLI" runat="server">
                        <%-- 2019/11/01 T.Ono add �Ď����P2019 No1 END --%>
                        <input id="hdnJido" type="hidden" name="hdnJido" runat="server"> <input id="hdnMishori" type="hidden" name="hdnMishori" runat="server">
                        <input id="hdnScrollTop" type="hidden" name="hdnScrollTop" runat="server">
					</td>
				</tr>
			</table>
			<table id="Table8" cellspacing="0" cellpadding="0" width="985">
				<tr>
					<td valign="top">
						<table cellspacing="0" cellpadding="0" width="80">
							<tr>
                                <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
								<%--<td colspan="2">&nbsp;&nbsp;�m�b�t�ڑ�&nbsp;<asp:textbox id="txtTUSIN" tabindex="-1" runat="server" readonly="True" width="20px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                <td colspan="2">&nbsp;&nbsp;�m�b�t�ڑ�&nbsp;<asp:textbox id="txtTUSIN" tabindex="-1" runat="server" width="20px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
							</tr>
							<tr>
								<td align="right" width="60">�ڑ��i�o�j</td>
								<td width="20"><input id="chkNCU_SET1" disabled tabindex="-1" type="checkbox" name="chkNCU_SET1" runat="server">
								</td>
							</tr>
							<tr>
								<td align="right">�ڑ��i�[���j</td>
								<td><input id="chkNCU_SET2" disabled tabindex="-1" type="checkbox" name="chkNCU_SET2" runat="server">
								</td>
							</tr>
							<tr>
								<td align="right">���ڑ�</td>
								<td><input id="chkNCU_SET0" disabled tabindex="-1" type="checkbox" name="chkNCU_SET0" runat="server">
								</td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp;�n�}�ԍ�</td>
							</tr>
							<tr>
                                <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
								<%--<td align="right" colspan="2"><asp:textbox id="txtMAP_CD" tabindex="-1" runat="server" readonly="True" width="80px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                                <td align="right" colspan="2"><asp:textbox id="txtMAP_CD" tabindex="-1" runat="server" width="80px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
							</tr>
							<tr>
								<td colspan="2">&nbsp;&nbsp;�����敪</td>
							</tr>
							<tr>
                                <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
								<%--<td align="right" colspan="2"><asp:textbox id="txtBOMB_TYPE" tabindex="-1" runat="server" readonly="True" width="80px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox><input id="hdnBOMB_TYPE" type="hidden" name="hdnBOMB_TYPE" runat="server">
								</td>--%>
								<td align="right" colspan="2"><asp:textbox id="txtBOMB_TYPE" tabindex="-1" runat="server" width="80px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox><input id="hdnBOMB_TYPE" type="hidden" name="hdnBOMB_TYPE" runat="server">
								</td>
							</tr>
						</table>
					</td>
					<td></td>
				</tr>
				<tr>
					<td colspan="2" height="24"><input id="hdnNCU" type="hidden" name="hdnNCU" runat="server"><input id="hdnKANSCD" type="hidden" name="hdnKANSCD" runat="server"><input id="hdnKANSFLG" type="hidden" name="hdnKANSFLG" runat="server">
						<input id="hdnREN_STD_JASCD" type="hidden" name="hdnREN_STD_JASCD" runat="server">
						<input id="hdnREN_STD_JANA" type="hidden" name="hdnREN_STD_JANA" runat="server">
						<input id="hdnREN_STD_JASNA" type="hidden" name="hdnREN_STD_JASNA" runat="server">
						<input id="hdnREN_0_NA" type="hidden" name="hdnREN_0_NA" runat="server"> <input id="hdnREN_0_TANCD" type="hidden" name="hdnREN_0_TANCD" runat="server">
						<input id="hdnREN_0_TEL1" type="hidden" name="hdnREN_0_TEL1" runat="server"> <input id="hdnREN_0_TEL2" type="hidden" name="hdnREN_0_TEL2" runat="server">
                        <input id="hdnREN_0_TEL3" type="hidden" name="hdnREN_0_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_0_FAX" type="hidden" name="hdnREN_0_FAX" runat="server"><input id="hdnREN_0_BIKO" type="hidden" name="hdnREN_0_BIKO" runat="server">
						<input id="hdnREN_1_NA" type="hidden" name="hdnREN_1_NA" runat="server"><input id="hdnREN_1_TANCD" type="hidden" name="hdnREN_1_TANCD" runat="server">
						<input id="hdnREN_1_TEL1" type="hidden" name="hdnREN_1_TEL1" runat="server"><input id="hdnREN_1_TEL2" type="hidden" name="hdnREN_1_TEL2" runat="server">
                        <input id="hdnREN_1_TEL3" type="hidden" name="hdnREN_1_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_1_FAX" type="hidden" name="hdnREN_1_FAX" runat="server"><input id="hdnREN_1_BIKO" type="hidden" name="hdnREN_1_BIKO" runat="server">
						<input id="hdnREN_2_NA" type="hidden" name="hdnREN_2_NA" runat="server"> <input id="hdnREN_2_TANCD" type="hidden" name="hdnREN_2_TANCD" runat="server">
						<input id="hdnREN_2_TEL1" type="hidden" name="hdnREN_2_TEL1" runat="server"> <input id="hdnREN_2_TEL2" type="hidden" name="hdnREN_2_TEL2" runat="server">
                        <input id="hdnREN_2_TEL3" type="hidden" name="hdnREN_2_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_2_FAX" type="hidden" name="hdnREN_2_FAX" runat="server"> <input id="hdnREN_2_BIKO" type="hidden" name="hdnREN_2_BIKO" runat="server">
						<input id="hdnREN_3_NA" type="hidden" name="hdnREN_3_NA" runat="server"><input id="hdnREN_3_TANCD" type="hidden" name="hdnREN_3_TANCD" runat="server">
						<input id="hdnREN_3_TEL1" type="hidden" name="hdnREN_3_TEL1" runat="server"><input id="hdnREN_3_TEL2" type="hidden" name="hdnREN_3_TEL2" runat="server">
                        <input id="hdnREN_3_TEL3" type="hidden" name="hdnREN_3_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_3_FAX" type="hidden" name="hdnREN_3_FAX" runat="server"><input id="hdnREN_3_BIKO" type="hidden" name="hdnREN_3_BIKO" runat="server">
						<!-- ' 2008/10/31 T.Watabe add -->
						<input id="hdnREN_4_NA" type="hidden" name="hdnREN_4_NA" runat="server"> <input id="hdnREN_4_TANCD" type="hidden" name="hdnREN_4_TANCD" runat="server">
						<input id="hdnREN_4_TEL1" type="hidden" name="hdnREN_4_TEL1" runat="server"> <input id="hdnREN_4_TEL2" type="hidden" name="hdnREN_4_TEL2" runat="server">
                        <input id="hdnREN_4_TEL3" type="hidden" name="hdnREN_4_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_4_FAX" type="hidden" name="hdnREN_4_FAX" runat="server"> <input id="hdnREN_4_BIKO" type="hidden" name="hdnREN_4_BIKO" runat="server">
						<input id="hdnREN_5_NA" type="hidden" name="hdnREN_5_NA" runat="server"> <input id="hdnREN_5_TANCD" type="hidden" name="hdnREN_5_TANCD" runat="server">
						<input id="hdnREN_5_TEL1" type="hidden" name="hdnREN_5_TEL1" runat="server"> <input id="hdnREN_5_TEL2" type="hidden" name="hdnREN_5_TEL2" runat="server">
                        <input id="hdnREN_5_TEL3" type="hidden" name="hdnREN_5_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_5_FAX" type="hidden" name="hdnREN_5_FAX" runat="server"> <input id="hdnREN_5_BIKO" type="hidden" name="hdnREN_5_BIKO" runat="server">
						<input id="hdnREN_6_NA" type="hidden" name="hdnREN_6_NA" runat="server"> <input id="hdnREN_6_TANCD" type="hidden" name="hdnREN_6_TANCD" runat="server">
						<input id="hdnREN_6_TEL1" type="hidden" name="hdnREN_6_TEL1" runat="server"> <input id="hdnREN_6_TEL2" type="hidden" name="hdnREN_6_TEL2" runat="server">
                        <input id="hdnREN_6_TEL3" type="hidden" name="hdnREN_6_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_6_FAX" type="hidden" name="hdnREN_6_FAX" runat="server"> <input id="hdnREN_6_BIKO" type="hidden" name="hdnREN_6_BIKO" runat="server">
						<input id="hdnREN_7_NA" type="hidden" name="hdnREN_7_NA" runat="server"> <input id="hdnREN_7_TANCD" type="hidden" name="hdnREN_7_TANCD" runat="server">
						<input id="hdnREN_7_TEL1" type="hidden" name="hdnREN_7_TEL1" runat="server"> <input id="hdnREN_7_TEL2" type="hidden" name="hdnREN_7_TEL2" runat="server">
                        <input id="hdnREN_7_TEL3" type="hidden" name="hdnREN_7_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_7_FAX" type="hidden" name="hdnREN_7_FAX" runat="server"> <input id="hdnREN_7_BIKO" type="hidden" name="hdnREN_7_BIKO" runat="server">
						<input id="hdnREN_8_NA" type="hidden" name="hdnREN_8_NA" runat="server"> <input id="hdnREN_8_TANCD" type="hidden" name="hdnREN_8_TANCD" runat="server">
						<input id="hdnREN_8_TEL1" type="hidden" name="hdnREN_8_TEL1" runat="server"> <input id="hdnREN_8_TEL2" type="hidden" name="hdnREN_8_TEL2" runat="server">
                        <input id="hdnREN_8_TEL3" type="hidden" name="hdnREN_8_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_8_FAX" type="hidden" name="hdnREN_8_FAX" runat="server"> <input id="hdnREN_8_BIKO" type="hidden" name="hdnREN_8_BIKO" runat="server">
						<input id="hdnREN_9_NA" type="hidden" name="hdnREN_9_NA" runat="server"> <input id="hdnREN_9_TANCD" type="hidden" name="hdnREN_9_TANCD" runat="server">
						<input id="hdnREN_9_TEL1" type="hidden" name="hdnREN_9_TEL1" runat="server"> <input id="hdnREN_9_TEL2" type="hidden" name="hdnREN_9_TEL2" runat="server">
                        <input id="hdnREN_9_TEL3" type="hidden" name="hdnREN_9_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_9_FAX" type="hidden" name="hdnREN_9_FAX" runat="server"> <input id="hdnREN_9_BIKO" type="hidden" name="hdnREN_9_BIKO" runat="server">
						<!-- ' 2010/05/10 T.Watabe add -->
						<input id="hdnREN_10_NA" type="hidden" name="hdnREN_10_NA" runat="server"> <input id="hdnREN_10_TANCD" type="hidden" name="hdnREN_10_TANCD" runat="server">
						<input id="hdnREN_10_TEL1" type="hidden" name="hdnREN_10_TEL1" runat="server"> <input id="hdnREN_10_TEL2" type="hidden" name="hdnREN_10_TEL2" runat="server">
                        <input id="hdnREN_10_TEL3" type="hidden" name="hdnREN_10_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_10_FAX" type="hidden" name="hdnREN_10_FAX" runat="server"> <input id="hdnREN_10_BIKO" type="hidden" name="hdnREN_10_BIKO" runat="server">
						<input id="hdnREN_11_NA" type="hidden" name="hdnREN_11_NA" runat="server"> <input id="hdnREN_11_TANCD" type="hidden" name="hdnREN_11_TANCD" runat="server">
						<input id="hdnREN_11_TEL1" type="hidden" name="hdnREN_11_TEL1" runat="server"> <input id="hdnREN_11_TEL2" type="hidden" name="hdnREN_11_TEL2" runat="server">
                        <input id="hdnREN_11_TEL3" type="hidden" name="hdnREN_11_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_11_FAX" type="hidden" name="hdnREN_11_FAX" runat="server"> <input id="hdnREN_11_BIKO" type="hidden" name="hdnREN_11_BIKO" runat="server">
						<input id="hdnREN_12_NA" type="hidden" name="hdnREN_12_NA" runat="server"> <input id="hdnREN_12_TANCD" type="hidden" name="hdnREN_12_TANCD" runat="server">
						<input id="hdnREN_12_TEL1" type="hidden" name="hdnREN_12_TEL1" runat="server"> <input id="hdnREN_12_TEL2" type="hidden" name="hdnREN_12_TEL2" runat="server">
                        <input id="hdnREN_12_TEL3" type="hidden" name="hdnREN_12_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_12_FAX" type="hidden" name="hdnREN_12_FAX" runat="server"> <input id="hdnREN_12_BIKO" type="hidden" name="hdnREN_12_BIKO" runat="server">
						<input id="hdnREN_13_NA" type="hidden" name="hdnREN_13_NA" runat="server"> <input id="hdnREN_13_TANCD" type="hidden" name="hdnREN_13_TANCD" runat="server">
						<input id="hdnREN_13_TEL1" type="hidden" name="hdnREN_13_TEL1" runat="server"> <input id="hdnREN_13_TEL2" type="hidden" name="hdnREN_13_TEL2" runat="server">
                        <input id="hdnREN_13_TEL3" type="hidden" name="hdnREN_13_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_13_FAX" type="hidden" name="hdnREN_13_FAX" runat="server"> <input id="hdnREN_13_BIKO" type="hidden" name="hdnREN_13_BIKO" runat="server">
						<input id="hdnREN_14_NA" type="hidden" name="hdnREN_14_NA" runat="server"> <input id="hdnREN_14_TANCD" type="hidden" name="hdnREN_14_TANCD" runat="server">
						<input id="hdnREN_14_TEL1" type="hidden" name="hdnREN_14_TEL1" runat="server"> <input id="hdnREN_14_TEL2" type="hidden" name="hdnREN_14_TEL2" runat="server">
                        <input id="hdnREN_14_TEL3" type="hidden" name="hdnREN_14_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_14_FAX" type="hidden" name="hdnREN_14_FAX" runat="server"> <input id="hdnREN_14_BIKO" type="hidden" name="hdnREN_14_BIKO" runat="server">
						<input id="hdnREN_15_NA" type="hidden" name="hdnREN_15_NA" runat="server"> <input id="hdnREN_15_TANCD" type="hidden" name="hdnREN_15_TANCD" runat="server">
						<input id="hdnREN_15_TEL1" type="hidden" name="hdnREN_15_TEL1" runat="server"> <input id="hdnREN_15_TEL2" type="hidden" name="hdnREN_15_TEL2" runat="server">
                        <input id="hdnREN_15_TEL3" type="hidden" name="hdnREN_15_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_15_FAX" type="hidden" name="hdnREN_15_FAX" runat="server"> <input id="hdnREN_15_BIKO" type="hidden" name="hdnREN_15_BIKO" runat="server">
						<input id="hdnREN_16_NA" type="hidden" name="hdnREN_16_NA" runat="server"> <input id="hdnREN_16_TANCD" type="hidden" name="hdnREN_16_TANCD" runat="server">
						<input id="hdnREN_16_TEL1" type="hidden" name="hdnREN_16_TEL1" runat="server"> <input id="hdnREN_16_TEL2" type="hidden" name="hdnREN_16_TEL2" runat="server">
                        <input id="hdnREN_16_TEL3" type="hidden" name="hdnREN_16_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_16_FAX" type="hidden" name="hdnREN_16_FAX" runat="server"> <input id="hdnREN_16_BIKO" type="hidden" name="hdnREN_16_BIKO" runat="server">
						<input id="hdnREN_17_NA" type="hidden" name="hdnREN_17_NA" runat="server"> <input id="hdnREN_17_TANCD" type="hidden" name="hdnREN_17_TANCD" runat="server">
						<input id="hdnREN_17_TEL1" type="hidden" name="hdnREN_17_TEL1" runat="server"> <input id="hdnREN_17_TEL2" type="hidden" name="hdnREN_17_TEL2" runat="server">
                        <input id="hdnREN_17_TEL3" type="hidden" name="hdnREN_17_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_17_FAX" type="hidden" name="hdnREN_17_FAX" runat="server"> <input id="hdnREN_17_BIKO" type="hidden" name="hdnREN_17_BIKO" runat="server">
						<input id="hdnREN_18_NA" type="hidden" name="hdnREN_18_NA" runat="server"> <input id="hdnREN_18_TANCD" type="hidden" name="hdnREN_18_TANCD" runat="server">
						<input id="hdnREN_18_TEL1" type="hidden" name="hdnREN_18_TEL1" runat="server"> <input id="hdnREN_18_TEL2" type="hidden" name="hdnREN_18_TEL2" runat="server">
                        <input id="hdnREN_18_TEL3" type="hidden" name="hdnREN_18_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_18_FAX" type="hidden" name="hdnREN_18_FAX" runat="server"> <input id="hdnREN_18_BIKO" type="hidden" name="hdnREN_18_BIKO" runat="server">
						<input id="hdnREN_19_NA" type="hidden" name="hdnREN_19_NA" runat="server"> <input id="hdnREN_19_TANCD" type="hidden" name="hdnREN_19_TANCD" runat="server">
						<input id="hdnREN_19_TEL1" type="hidden" name="hdnREN_19_TEL1" runat="server"> <input id="hdnREN_19_TEL2" type="hidden" name="hdnREN_19_TEL2" runat="server">
                        <input id="hdnREN_19_TEL3" type="hidden" name="hdnREN_19_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_19_FAX" type="hidden" name="hdnREN_19_FAX" runat="server"> <input id="hdnREN_19_BIKO" type="hidden" name="hdnREN_19_BIKO" runat="server">
						<input id="hdnREN_20_NA" type="hidden" name="hdnREN_20_NA" runat="server"> <input id="hdnREN_20_TANCD" type="hidden" name="hdnREN_20_TANCD" runat="server">
						<input id="hdnREN_20_TEL1" type="hidden" name="hdnREN_20_TEL1" runat="server"> <input id="hdnREN_20_TEL2" type="hidden" name="hdnREN_20_TEL2" runat="server">
                        <input id="hdnREN_20_TEL3" type="hidden" name="hdnREN_20_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_20_FAX" type="hidden" name="hdnREN_20_FAX" runat="server"> <input id="hdnREN_20_BIKO" type="hidden" name="hdnREN_20_BIKO" runat="server">
						<input id="hdnREN_21_NA" type="hidden" name="hdnREN_21_NA" runat="server"> <input id="hdnREN_21_TANCD" type="hidden" name="hdnREN_21_TANCD" runat="server">
						<input id="hdnREN_21_TEL1" type="hidden" name="hdnREN_21_TEL1" runat="server"> <input id="hdnREN_21_TEL2" type="hidden" name="hdnREN_21_TEL2" runat="server">
                        <input id="hdnREN_21_TEL3" type="hidden" name="hdnREN_21_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_21_FAX" type="hidden" name="hdnREN_21_FAX" runat="server"> <input id="hdnREN_21_BIKO" type="hidden" name="hdnREN_21_BIKO" runat="server">
						<input id="hdnREN_22_NA" type="hidden" name="hdnREN_22_NA" runat="server"> <input id="hdnREN_22_TANCD" type="hidden" name="hdnREN_22_TANCD" runat="server">
						<input id="hdnREN_22_TEL1" type="hidden" name="hdnREN_22_TEL1" runat="server"> <input id="hdnREN_22_TEL2" type="hidden" name="hdnREN_22_TEL2" runat="server">
                        <input id="hdnREN_22_TEL3" type="hidden" name="hdnREN_22_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_22_FAX" type="hidden" name="hdnREN_22_FAX" runat="server"> <input id="hdnREN_22_BIKO" type="hidden" name="hdnREN_22_BIKO" runat="server">
						<input id="hdnREN_23_NA" type="hidden" name="hdnREN_23_NA" runat="server"> <input id="hdnREN_23_TANCD" type="hidden" name="hdnREN_23_TANCD" runat="server">
						<input id="hdnREN_23_TEL1" type="hidden" name="hdnREN_23_TEL1" runat="server"> <input id="hdnREN_23_TEL2" type="hidden" name="hdnREN_23_TEL2" runat="server">
                        <input id="hdnREN_23_TEL3" type="hidden" name="hdnREN_23_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_23_FAX" type="hidden" name="hdnREN_23_FAX" runat="server"> <input id="hdnREN_23_BIKO" type="hidden" name="hdnREN_23_BIKO" runat="server">
						<input id="hdnREN_24_NA" type="hidden" name="hdnREN_24_NA" runat="server"> <input id="hdnREN_24_TANCD" type="hidden" name="hdnREN_24_TANCD" runat="server">
						<input id="hdnREN_24_TEL1" type="hidden" name="hdnREN_24_TEL1" runat="server"> <input id="hdnREN_24_TEL2" type="hidden" name="hdnREN_24_TEL2" runat="server">
                        <input id="hdnREN_24_TEL3" type="hidden" name="hdnREN_24_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_24_FAX" type="hidden" name="hdnREN_24_FAX" runat="server"> <input id="hdnREN_24_BIKO" type="hidden" name="hdnREN_24_BIKO" runat="server">
						<input id="hdnREN_25_NA" type="hidden" name="hdnREN_25_NA" runat="server"> <input id="hdnREN_25_TANCD" type="hidden" name="hdnREN_25_TANCD" runat="server">
						<input id="hdnREN_25_TEL1" type="hidden" name="hdnREN_25_TEL1" runat="server"> <input id="hdnREN_25_TEL2" type="hidden" name="hdnREN_25_TEL2" runat="server">
                        <input id="hdnREN_25_TEL3" type="hidden" name="hdnREN_25_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_25_FAX" type="hidden" name="hdnREN_25_FAX" runat="server"> <input id="hdnREN_25_BIKO" type="hidden" name="hdnREN_25_BIKO" runat="server">
						<input id="hdnREN_26_NA" type="hidden" name="hdnREN_26_NA" runat="server"> <input id="hdnREN_26_TANCD" type="hidden" name="hdnREN_26_TANCD" runat="server">
						<input id="hdnREN_26_TEL1" type="hidden" name="hdnREN_26_TEL1" runat="server"> <input id="hdnREN_26_TEL2" type="hidden" name="hdnREN_26_TEL2" runat="server">
                        <input id="hdnREN_26_TEL3" type="hidden" name="hdnREN_26_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_26_FAX" type="hidden" name="hdnREN_26_FAX" runat="server"> <input id="hdnREN_26_BIKO" type="hidden" name="hdnREN_26_BIKO" runat="server">
						<input id="hdnREN_27_NA" type="hidden" name="hdnREN_27_NA" runat="server"> <input id="hdnREN_27_TANCD" type="hidden" name="hdnREN_27_TANCD" runat="server">
						<input id="hdnREN_27_TEL1" type="hidden" name="hdnREN_27_TEL1" runat="server"> <input id="hdnREN_27_TEL2" type="hidden" name="hdnREN_27_TEL2" runat="server">
                        <input id="hdnREN_27_TEL3" type="hidden" name="hdnREN_27_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_27_FAX" type="hidden" name="hdnREN_27_FAX" runat="server"> <input id="hdnREN_27_BIKO" type="hidden" name="hdnREN_27_BIKO" runat="server">
						<input id="hdnREN_28_NA" type="hidden" name="hdnREN_28_NA" runat="server"> <input id="hdnREN_28_TANCD" type="hidden" name="hdnREN_28_TANCD" runat="server">
						<input id="hdnREN_28_TEL1" type="hidden" name="hdnREN_28_TEL1" runat="server"> <input id="hdnREN_28_TEL2" type="hidden" name="hdnREN_28_TEL2" runat="server">
                        <input id="hdnREN_28_TEL3" type="hidden" name="hdnREN_28_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_28_FAX" type="hidden" name="hdnREN_28_FAX" runat="server"> <input id="hdnREN_28_BIKO" type="hidden" name="hdnREN_28_BIKO" runat="server">
						<input id="hdnREN_29_NA" type="hidden" name="hdnREN_29_NA" runat="server"> <input id="hdnREN_29_TANCD" type="hidden" name="hdnREN_29_TANCD" runat="server">
						<input id="hdnREN_29_TEL1" type="hidden" name="hdnREN_29_TEL1" runat="server"> <input id="hdnREN_29_TEL2" type="hidden" name="hdnREN_29_TEL2" runat="server">
                        <input id="hdnREN_29_TEL3" type="hidden" name="hdnREN_29_TEL3" runat="server"> <!-- 2013/05/27 T.Ono add -->
						<input id="hdnREN_29_FAX" type="hidden" name="hdnREN_29_FAX" runat="server"> <input id="hdnREN_29_BIKO" type="hidden" name="hdnREN_29_BIKO" runat="server">
						<input id="hdnREN_DENWABIKO" type="hidden" name="hdnREN_DENWABIKO" runat="server">
						<input id="hdnREN_FAXTITLE" type="hidden" name="hdnREN_FAXTITLE" runat="server"><input id="hdnFAX_TITLE_CD" type="hidden" name="hdnFAX_TITLE_CD" runat="server">
						<input id="hdnREN_FAXREN" type="hidden" name="hdnREN_FAXREN" runat="server"> <input id="hdnREN_0_EDT_DATE" type="hidden" name="hdnREN_0_EDT_DATE" runat="server"><input id="hdnREN_0_TIME" type="hidden" name="hdnREN_0_TIME" runat="server">
						<input id="hdnREN_1_EDT_DATE" type="hidden" name="hdnREN_1_EDT_DATE" runat="server"><input id="hdnREN_1_TIME" type="hidden" name="hdnREN_1_TIME" runat="server">
						<input id="hdnREN_2_EDT_DATE" type="hidden" name="hdnREN_2_EDT_DATE" runat="server"><input id="hdnREN_2_TIME" type="hidden" name="hdnREN_2_TIME" runat="server">
						<input id="hdnREN_3_EDT_DATE" type="hidden" name="hdnREN_3_EDT_DATE" runat="server"><input id="hdnREN_3_TIME" type="hidden" name="hdnREN_3_TIME" runat="server">
						<!-- 2008/11/04 T.Watabe add -->
						<input id="hdnREN_4_EDT_DATE" type="hidden" name="hdnREN_4_EDT_DATE" runat="server"><input id="hdnREN_4_TIME" type="hidden" name="hdnREN_4_TIME" runat="server">
						<input id="hdnREN_5_EDT_DATE" type="hidden" name="hdnREN_5_EDT_DATE" runat="server"><input id="hdnREN_5_TIME" type="hidden" name="hdnREN_5_TIME" runat="server">
						<input id="hdnREN_6_EDT_DATE" type="hidden" name="hdnREN_6_EDT_DATE" runat="server"><input id="hdnREN_6_TIME" type="hidden" name="hdnREN_6_TIME" runat="server">
						<input id="hdnREN_7_EDT_DATE" type="hidden" name="hdnREN_7_EDT_DATE" runat="server"><input id="hdnREN_7_TIME" type="hidden" name="hdnREN_7_TIME" runat="server">
						<input id="hdnREN_8_EDT_DATE" type="hidden" name="hdnREN_8_EDT_DATE" runat="server"><input id="hdnREN_8_TIME" type="hidden" name="hdnREN_8_TIME" runat="server">
						<input id="hdnREN_9_EDT_DATE" type="hidden" name="hdnREN_9_EDT_DATE" runat="server"><input id="hdnREN_9_TIME" type="hidden" name="hdnREN_9_TIME" runat="server">
						<!-- ' 2010/05/10 T.Watabe add -->
						<input id="hdnREN_10_EDT_DATE" type="hidden" name="hdnREN_10_EDT_DATE" runat="server"><input id="hdnREN_10_TIME" type="hidden" name="hdnREN_10_TIME" runat="server">
						<input id="hdnREN_11_EDT_DATE" type="hidden" name="hdnREN_11_EDT_DATE" runat="server"><input id="hdnREN_11_TIME" type="hidden" name="hdnREN_11_TIME" runat="server">
						<input id="hdnREN_12_EDT_DATE" type="hidden" name="hdnREN_12_EDT_DATE" runat="server"><input id="hdnREN_12_TIME" type="hidden" name="hdnREN_12_TIME" runat="server">
						<input id="hdnREN_13_EDT_DATE" type="hidden" name="hdnREN_13_EDT_DATE" runat="server"><input id="hdnREN_13_TIME" type="hidden" name="hdnREN_13_TIME" runat="server">
						<input id="hdnREN_14_EDT_DATE" type="hidden" name="hdnREN_14_EDT_DATE" runat="server"><input id="hdnREN_14_TIME" type="hidden" name="hdnREN_14_TIME" runat="server">
						<input id="hdnREN_15_EDT_DATE" type="hidden" name="hdnREN_15_EDT_DATE" runat="server"><input id="hdnREN_15_TIME" type="hidden" name="hdnREN_15_TIME" runat="server">
						<input id="hdnREN_16_EDT_DATE" type="hidden" name="hdnREN_16_EDT_DATE" runat="server"><input id="hdnREN_16_TIME" type="hidden" name="hdnREN_16_TIME" runat="server">
						<input id="hdnREN_17_EDT_DATE" type="hidden" name="hdnREN_17_EDT_DATE" runat="server"><input id="hdnREN_17_TIME" type="hidden" name="hdnREN_17_TIME" runat="server">
						<input id="hdnREN_18_EDT_DATE" type="hidden" name="hdnREN_18_EDT_DATE" runat="server"><input id="hdnREN_18_TIME" type="hidden" name="hdnREN_18_TIME" runat="server">
						<input id="hdnREN_19_EDT_DATE" type="hidden" name="hdnREN_19_EDT_DATE" runat="server"><input id="hdnREN_19_TIME" type="hidden" name="hdnREN_19_TIME" runat="server">
						<input id="hdnREN_20_EDT_DATE" type="hidden" name="hdnREN_20_EDT_DATE" runat="server"><input id="hdnREN_20_TIME" type="hidden" name="hdnREN_20_TIME" runat="server">
						<input id="hdnREN_21_EDT_DATE" type="hidden" name="hdnREN_21_EDT_DATE" runat="server"><input id="hdnREN_21_TIME" type="hidden" name="hdnREN_21_TIME" runat="server">
						<input id="hdnREN_22_EDT_DATE" type="hidden" name="hdnREN_22_EDT_DATE" runat="server"><input id="hdnREN_22_TIME" type="hidden" name="hdnREN_22_TIME" runat="server">
						<input id="hdnREN_23_EDT_DATE" type="hidden" name="hdnREN_23_EDT_DATE" runat="server"><input id="hdnREN_23_TIME" type="hidden" name="hdnREN_23_TIME" runat="server">
						<input id="hdnREN_24_EDT_DATE" type="hidden" name="hdnREN_24_EDT_DATE" runat="server"><input id="hdnREN_24_TIME" type="hidden" name="hdnREN_24_TIME" runat="server">
						<input id="hdnREN_25_EDT_DATE" type="hidden" name="hdnREN_25_EDT_DATE" runat="server"><input id="hdnREN_25_TIME" type="hidden" name="hdnREN_25_TIME" runat="server">
						<input id="hdnREN_26_EDT_DATE" type="hidden" name="hdnREN_26_EDT_DATE" runat="server"><input id="hdnREN_26_TIME" type="hidden" name="hdnREN_26_TIME" runat="server">
						<input id="hdnREN_27_EDT_DATE" type="hidden" name="hdnREN_27_EDT_DATE" runat="server"><input id="hdnREN_27_TIME" type="hidden" name="hdnREN_27_TIME" runat="server">
						<input id="hdnREN_28_EDT_DATE" type="hidden" name="hdnREN_28_EDT_DATE" runat="server"><input id="hdnREN_28_TIME" type="hidden" name="hdnREN_28_TIME" runat="server">
						<input id="hdnREN_29_EDT_DATE" type="hidden" name="hdnREN_29_EDT_DATE" runat="server"><input id="hdnREN_29_TIME" type="hidden" name="hdnREN_29_TIME" runat="server">
						<input id="hdnJACD" type="hidden" name="hdnJACD" runat="server"><input id="hdnJANAME" type="hidden" name="hdnJANAME" runat="server"><input id="hdnJASNAME" type="hidden" name="hdnJASNAME" runat="server">
                        <input id="hdnHANJICD" type="hidden" name="hdnHANJICD" runat="server" /><input id="hdnHANJINM" type="hidden" name="hdnHANJINM" runat="server" /> <!-- 2014/12/16 T.Ono add 2014���P�J�� No2 -->
						<input id="hdnFAXEXEPATH" type="hidden" name="hdnFAXEXEPATH" runat="server"> <input id="hdnFAXEXENAME" type="hidden" name="hdnFAXEXENAME" runat="server">
						<input id="hdnFAXHEAD" type="hidden" name="hdnFAXHEAD" runat="server"> <input id="hdnFAXSESSION" type="hidden" name="hdnFAXSESSION" runat="server">
						<input id="hdnCtiFlg" type="hidden" name="hdnCtiFlg" runat="server"> <input id="hdnM05_TANTO_HAN_CD" type="hidden" name="hdnM05_TANTO_HAN_CD" runat="server"><!-- 2010/05/12 T.Watabe add -->
						<!-- ' 2012/03/26 W.GANEKO add -->
						<input id="hdnREN_0_MAIL" type="hidden" name="hdnREN_0_MAIL" runat="server">
						<input id="hdnREN_1_MAIL" type="hidden" name="hdnREN_1_MAIL" runat="server">
						<input id="hdnREN_2_MAIL" type="hidden" name="hdnREN_2_MAIL" runat="server">
						<input id="hdnREN_3_MAIL" type="hidden" name="hdnREN_3_MAIL" runat="server">
						<input id="hdnREN_4_MAIL" type="hidden" name="hdnREN_4_MAIL" runat="server">
						<input id="hdnREN_5_MAIL" type="hidden" name="hdnREN_5_MAIL" runat="server">
						<input id="hdnREN_6_MAIL" type="hidden" name="hdnREN_6_MAIL" runat="server">
						<input id="hdnREN_7_MAIL" type="hidden" name="hdnREN_7_MAIL" runat="server">
						<input id="hdnREN_8_MAIL" type="hidden" name="hdnREN_8_MAIL" runat="server">
						<input id="hdnREN_9_MAIL" type="hidden" name="hdnREN_9_MAIL" runat="server">
						<input id="hdnREN_10_MAIL" type="hidden" name="hdnREN_10_MAIL" runat="server">
						<input id="hdnREN_11_MAIL" type="hidden" name="hdnREN_11_MAIL" runat="server">
						<input id="hdnREN_12_MAIL" type="hidden" name="hdnREN_12_MAIL" runat="server">
						<input id="hdnREN_13_MAIL" type="hidden" name="hdnREN_13_MAIL" runat="server">
						<input id="hdnREN_14_MAIL" type="hidden" name="hdnREN_14_MAIL" runat="server">
						<input id="hdnREN_15_MAIL" type="hidden" name="hdnREN_15_MAIL" runat="server">
						<input id="hdnREN_16_MAIL" type="hidden" name="hdnREN_16_MAIL" runat="server">
						<input id="hdnREN_17_MAIL" type="hidden" name="hdnREN_17_MAIL" runat="server">
						<input id="hdnREN_18_MAIL" type="hidden" name="hdnREN_18_MAIL" runat="server">
						<input id="hdnREN_19_MAIL" type="hidden" name="hdnREN_19_MAIL" runat="server">
						<input id="hdnREN_20_MAIL" type="hidden" name="hdnREN_20_MAIL" runat="server">
						<input id="hdnREN_21_MAIL" type="hidden" name="hdnREN_21_MAIL" runat="server">
						<input id="hdnREN_22_MAIL" type="hidden" name="hdnREN_22_MAIL" runat="server">
						<input id="hdnREN_23_MAIL" type="hidden" name="hdnREN_23_MAIL" runat="server">
						<input id="hdnREN_24_MAIL" type="hidden" name="hdnREN_24_MAIL" runat="server">
						<input id="hdnREN_25_MAIL" type="hidden" name="hdnREN_25_MAIL" runat="server">
						<input id="hdnREN_26_MAIL" type="hidden" name="hdnREN_26_MAIL" runat="server">
						<input id="hdnREN_27_MAIL" type="hidden" name="hdnREN_27_MAIL" runat="server">
						<input id="hdnREN_28_MAIL" type="hidden" name="hdnREN_28_MAIL" runat="server">
						<input id="hdnREN_29_MAIL" type="hidden" name="hdnREN_29_MAIL" runat="server">
						<input id="hdnREN_0_MAILPASS" type="hidden" name="hdnREN_0_MAILPASS" runat="server">
						<input id="hdnREN_1_MAILPASS" type="hidden" name="hdnREN_1_MAILPASS" runat="server">
						<input id="hdnREN_2_MAILPASS" type="hidden" name="hdnREN_2_MAILPASS" runat="server">
						<input id="hdnREN_3_MAILPASS" type="hidden" name="hdnREN_3_MAILPASS" runat="server">
						<input id="hdnREN_4_MAILPASS" type="hidden" name="hdnREN_4_MAILPASS" runat="server">
						<input id="hdnREN_5_MAILPASS" type="hidden" name="hdnREN_5_MAILPASS" runat="server">
						<input id="hdnREN_6_MAILPASS" type="hidden" name="hdnREN_6_MAILPASS" runat="server">
						<input id="hdnREN_7_MAILPASS" type="hidden" name="hdnREN_7_MAILPASS" runat="server">
						<input id="hdnREN_8_MAILPASS" type="hidden" name="hdnREN_8_MAILPASS" runat="server">
						<input id="hdnREN_9_MAILPASS" type="hidden" name="hdnREN_9_MAILPASS" runat="server">
						<input id="hdnREN_10_MAILPASS" type="hidden" name="hdnREN_10_MAILPASS" runat="server">
						<input id="hdnREN_11_MAILPASS" type="hidden" name="hdnREN_11_MAILPASS" runat="server">
						<input id="hdnREN_12_MAILPASS" type="hidden" name="hdnREN_12_MAILPASS" runat="server">
						<input id="hdnREN_13_MAILPASS" type="hidden" name="hdnREN_13_MAILPASS" runat="server">
						<input id="hdnREN_14_MAILPASS" type="hidden" name="hdnREN_14_MAILPASS" runat="server">
						<input id="hdnREN_15_MAILPASS" type="hidden" name="hdnREN_15_MAILPASS" runat="server">
						<input id="hdnREN_16_MAILPASS" type="hidden" name="hdnREN_16_MAILPASS" runat="server">
						<input id="hdnREN_17_MAILPASS" type="hidden" name="hdnREN_17_MAILPASS" runat="server">
						<input id="hdnREN_18_MAILPASS" type="hidden" name="hdnREN_18_MAILPASS" runat="server">
						<input id="hdnREN_19_MAILPASS" type="hidden" name="hdnREN_19_MAILPASS" runat="server">
						<input id="hdnREN_20_MAILPASS" type="hidden" name="hdnREN_20_MAILPASS" runat="server">
						<input id="hdnREN_21_MAILPASS" type="hidden" name="hdnREN_21_MAILPASS" runat="server">
						<input id="hdnREN_22_MAILPASS" type="hidden" name="hdnREN_22_MAILPASS" runat="server">
						<input id="hdnREN_23_MAILPASS" type="hidden" name="hdnREN_23_MAILPASS" runat="server">
						<input id="hdnREN_24_MAILPASS" type="hidden" name="hdnREN_24_MAILPASS" runat="server">
						<input id="hdnREN_25_MAILPASS" type="hidden" name="hdnREN_25_MAILPASS" runat="server">
						<input id="hdnREN_26_MAILPASS" type="hidden" name="hdnREN_26_MAILPASS" runat="server">
						<input id="hdnREN_27_MAILPASS" type="hidden" name="hdnREN_27_MAILPASS" runat="server">
						<input id="hdnREN_28_MAILPASS" type="hidden" name="hdnREN_28_MAILPASS" runat="server">
						<input id="hdnREN_29_MAILPASS" type="hidden" name="hdnREN_29_MAILPASS" runat="server">
                        <!-- 2013/07/11 T.Ono add�@M05_TANTO2���g�p�����ꍇ��USER_CD_FROM-->
                        <input id="hdnUSER_CD_FROM" type="hidden" name="hdnUSER_CD_FROM" runat="server">
                        <!-- 2014/12/22 T.Ono add 2014���P�J�� No4 FAX�E���[�����MFLG-->
                        <input id="hdnSEND_FAX_FLG" type="hidden" name="hdnSEND_FAX_FLG" runat="server"> 
                        <!-- 2016/12/14 H.Mori add�@2016���P�J�� No6-3 ��߯�FAX���M�ς݃t���O-->
                        <input id="hdnFAXSPOTKBN" type="hidden" name="hdnFAXSPOTKBN" runat="server" />
                        <!-- 2016/02/02 w.ganeko add�@2015���P�J�� ��1-3 start -->
                        <input id="hdnRENTEL2" type="hidden" name="hdnRENTEL2" runat="server">
                        <input id="hdnRENTEL2_BIKO" type="hidden" name="hdnRENTEL2_BIKO" runat="server">
                        <input id="hdnRENTEL2_UPD_DATE" type="hidden" name="hdnRENTEL2_UPD_DATE" runat="server">
                        <input id="hdnRENTEL3" type="hidden" name="hdnRENTEL3" runat="server">
                        <input id="hdnRENTEL3_BIKO" type="hidden" name="hdnRENTEL3_BIKO" runat="server">
                        <input id="hdnRENTEL3_UPD_DATE" type="hidden" name="hdnRENTEL3_UPD_DATE" runat="server">
                        <input id="hdnTelJVG" type="hidden" name="hdnTelJVG" runat="server">
                        <!-- 2016/02/02 w.ganeko add�@2015���P�J�� ��1-3 end -->
                        <!-- 2016/02/02 w.ganeko add�@2015���P�J�� ��2 start -->
                        <input id="hdnGROUPCD" type="hidden" name="hdnGROUPCD" runat="server">
                        <input id="hdnGROUPNM" type="hidden" name="hdnGROUPNM" runat="server">
                        <!-- 2016/02/02 w.ganeko add�@2015���P�J�� ��2 end -->
                        <%--2016/12/12 H.Mori add 2016���P�J�� No5-1 START --%>
                        <input id="hdnTELAB" type="hidden" name="hdnTELAB" runat="server">
                        <input id="hdnDAI3RENDORENTEL" type="hidden" name="hdnDAI3RENDORENTEL" runat="server">
                        <%--2016/12/12 H.Mori add 2016���P�J�� No5-1 END --%>
                        <%--2016/12/22 H.Mori add 2016���P�J�� No4-6 START --%>
                        <input id="hdnDAIHYO_NAME" type="hidden" name="hdnDAIHYO_NAME" runat="server">
                        <input id="hdnHOKBN" type="hidden" name="hdnHOKBN" runat="server">
                        <input id="hdnYOTOKBN" type="hidden" name="hdnYOTOKBN" runat="server">
                        <input id="hdnHANBCD" type="hidden" name="hdnHANBCD" runat="server">
                        <%--2016/12/22 H.Mori add 2016���P�J�� No4-6 END --%>
                        <%--2017/10/16 H.Mori add 2017���P�J�� No4-1 START --%>
                        <input id="hdnSHUGOU" type="hidden" name="hdnSHUGOU" runat="server">
                        <%--2017/10/16 H.Mori add 2017���P�J�� No4-1 END --%>
					</td>
				</tr>
			</table>
			<table id="Table7" cellspacing="1" cellpadding="1" width="985">
				<tr>
					<td class="T" valign="middle" height="13">&nbsp;&nbsp;<b>�Ή����</b></td>
				</tr>
			</table>
			<table id="Table8" cellspacing="0" cellpadding="0" width="985">
				<tr>
					<td width="80"></td>
					<td width="150"></td>
					<td width="320"></td>
					<td width="70"></td>
					<td width="180"></td>
					<td width="160"></td>
				</tr>
				<tr>
					<td colspan="6">
						<table cellspacing="0" cellpadding="0">
							<tr>
								<td nowrap>�����敪&nbsp;</td>
                                <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
								<%--<td><asp:textbox id="txtHATKBN" tabindex="-1" runat="server" readonly="True" width="74px" borderstyle="Solid"--%>
                                <td><asp:textbox id="txtHATKBN" tabindex="-1" runat="server" width="74px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM"></asp:textbox><input class="bt-KS" id="btnHATKBN" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('21');"
										tabindex="1" type="button" value="��" name="btnHATKBN" runat="server"><input id="hdnHATKBN" type="hidden" name="hdnHATKBN" runat="server">&nbsp;&nbsp;
								</td>
								<td nowrap>�Ή��敪&nbsp;</td>
								<td>
                                    <%-- 2013/08/22 T.Ono mod �Ď����P2013��1 �I����Ƀt�H�[�J�X���ړ�
                                    <cc1:ctlcombo id="cboTAIOKBN" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
										tabindex="11" runat="server" width="100px" cssclass="cb-h" onchange="fncTAIO_Change();"></cc1:ctlcombo>&nbsp;&nbsp;&nbsp; --%>
                                    <%-- 2014/12/09 T.Ono mod 2014���P�J�� No2
                                    <cc1:ctlcombo id="cboTAIOKBN" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
										tabindex="11" runat="server" width="100px" cssclass="cb-h" onchange="fncTAIO_Change();fncSetFocus();"></cc1:ctlcombo>&nbsp;&nbsp;&nbsp; --%>
                                    <cc1:ctlcombo id="cboTAIOKBN" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)"
										tabindex="11" runat="server" width="100px" cssclass="cb-h" onchange="fncTAIO_Change();fncSetFocus();"></cc1:ctlcombo>&nbsp;&nbsp;&nbsp;
                                </td>
								<td nowrap>�����敪&nbsp;</td>
								<td>
                                    <%-- 2013/08/22 T.Ono mod �Ď����P2013��1
                                    <cc1:ctlcombo id="cboTMSKB" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
										tabindex="12" runat="server" width="100px" cssclass="cb-h" onchange="fncTMSKB_Chenge();"></cc1:ctlcombo></td> --%>
                                    <%-- 2014/12/09 T.Ono mod 2014���P�J�� No2
                                    <cc1:ctlcombo id="cboTMSKB" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" 
										tabindex="12" runat="server" width="100px" cssclass="cb-h" onchange="fncTMSKB_Chenge();fncSetFocus();"></cc1:ctlcombo></td> --%>
                                    <cc1:ctlcombo id="cboTMSKB" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" 
										tabindex="12" runat="server" width="100px" cssclass="cb-h" onchange="fncTMSKB_Chenge();fncSetFocus();"></cc1:ctlcombo></td>
								<td nowrap>&nbsp;&nbsp;�Ď��Z���^�[�S����&nbsp;</td>
                                <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
								<%--<td><asp:textbox id="txtTKTANCD" tabindex="-1" runat="server" readonly="True" width="250px" borderstyle="Solid"--%>
                                <td><asp:textbox id="txtTKTANCD" tabindex="-1" runat="server" width="250px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-h"></asp:textbox><input class="bt-KS" id="btnTKTANCD" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="fncChkRocuser('4');"
										tabindex="13" type="button" value="��" name="btnTKTANCD" runat="server"><input id="hdnTKTANCD" type="hidden" name="hdnTKTANCD" runat="server">&nbsp;&nbsp;&nbsp;
								</td> <%--2017/10/19 H.Mori mod 2017���P�J�� No4-3 id="btnTKTANCD"��onclick="return btnPopup_onclick('3');" �� onclick="fncChkRocuser('4');" --%>
								<td nowrap align="right">�����ԍ�&nbsp;
                                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
									<%--<asp:textbox id="txtSYONO" tabindex="-1" runat="server" readonly="True" width="80px" borderstyle="Solid"--%>
                                    <asp:textbox id="txtSYONO" tabindex="-1" runat="server" width="100px" borderstyle="Solid"
										borderwidth="1px" cssclass="c-rNM" designtimedragdrop="2727"></asp:textbox><input id="hdnSYONO" type="hidden" name="hdnSYONO" runat="server">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
                    <%-- 2013/10/16 T.Ono mod �Ď����P2013��1 ������ --%>
<%--					<td nowrap align="right">�A������&nbsp;</td>
					<td colspan="5">
                        <cc1:ctlcombo id="cboTAITCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="14" runat="server" width="380px" cssclass="cb" designtimedragdrop="2731"></cc1:ctlcombo>&nbsp;&nbsp;&nbsp; 
						�Ή�������&nbsp;
						<asp:textbox id="txtSYOYMD" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncNowDate(this)"
							tabindex="29" runat="server" width="74px" cssclass="c-f" maxlength="8"></asp:textbox>&nbsp;&nbsp;����&nbsp;&nbsp;
						<asp:textbox id="txtSYOTIME" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
							tabindex="30" runat="server" width="74px" cssclass="c-f" maxlength="6"></asp:textbox>&nbsp;<label for="chkFAXKBN">�񍐕s�v<div id="divFaxKbnDisp1" name="divFaxKbnDisp1" style="DISPLAY:inline">(JA)</div></label><input id="chkFAXKBN" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabindex="31" type="checkbox" name="chkFAXKBN" runat="server"><div id="divFaxKbnDisp2" name="divFaxKbnDisp2" style="DISPLAY:inline"><label for="chkFAXKURAKBN">(�ײ���)</label><input id="chkFAXKURAKBN" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
								tabindex="31" type="checkbox" name="chkFAXKURAKBN" runat="server"></div>
						&nbsp; <input class="bt-SRT" id="btnUpdate" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnUpdate_onclick();"
							tabindex="32" type="button" value="�o�^" name="btnUpdate" runat="server">
					</td>
				</tr>
				<tr>
					<td nowrap align="right">�d�b�A�����e&nbsp;</td>
                    <td colspan="2"><cc1:ctlcombo id="cboTELRCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="15" runat="server" width="380px" cssclass="cb"></cc1:ctlcombo></td> 
					<td nowrap align="right">���A�Ή���&nbsp;</td>
					<td nowrap colspan="2"><cc1:ctlcombo id="cboTFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="19" runat="server" width="360px" cssclass="cb"></cc1:ctlcombo></td>
				</tr>
				<tr>
					<td colspan="3"><asp:textbox id="txtTEL_MEMO1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="16" runat="server" width="540px" cssclass="c-fI" maxlength="50"></asp:textbox></td>
					<td nowrap align="right">�K�X���&nbsp;</td>
					<td colspan="2"><cc1:ctlcombo id="cboTKIGCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="20" runat="server" width="360px" cssclass="cb" designtimedragdrop="2751"></cc1:ctlcombo></td> 
				</tr>
				<tr>
					<td colspan="3"><asp:textbox id="txtTEL_MEMO2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="17" runat="server" width="540px" cssclass="c-fI" maxlength="50" designtimedragdrop="2762"></asp:textbox></td>
					<td nowrap align="right">�쓮����&nbsp;</td>
					<td colspan="2"><cc1:ctlcombo id="cboTSADCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="21" runat="server" width="360px" cssclass="cb"></cc1:ctlcombo></td> 
				</tr>
				<tr>
					<td colspan="3"><asp:textbox id="txtFUK_MEMO" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="18" runat="server" width="540px" cssclass="c-fI" maxlength="50" designtimedragdrop="2748"></asp:textbox></td>
					<td nowrap align="right">
						<div class="nopr">���q�l�L��&nbsp;</div>
					</td>
                    <td colspan="2"><asp:textbox id="txtGENIN_KIJI" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="22" runat="server" width="360px" cssclass="c-fI-nopr c-fI" maxlength="50"></asp:textbox></td> 
				</tr>--%>
                	<td nowrap align="left" colspan="6">�A������
                        <%-- 2014/12/09 T.Ono mod 2014���P�J�� No2
                        <cc1:ctlcombo id="cboTAITCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="14" runat="server" width="220px" cssclass="cb" designtimedragdrop="2731"></cc1:ctlcombo>&nbsp; --%>
                        <%-- 2015/11/16 H.Mori mod 2015���P�J�� No1 
                        <cc1:ctlcombo id="cboTAITCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="14" runat="server" width="220px" cssclass="cb" designtimedragdrop="2731"></cc1:ctlcombo>&nbsp; --%>
                        <%-- 2019/11/01 w.ganeko mod 2019���P�J�� No8-12 
                        <cc1:ctlcombo id="cboTAITCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="14" runat="server" width="150px" cssclass="cb" designtimedragdrop="2731"></cc1:ctlcombo>&nbsp; --%>
                        <cc1:ctlcombo id="cboTAITCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="14" runat="server" width="150px" cssclass="cb-h" designtimedragdrop="2731"></cc1:ctlcombo>&nbsp;
                        �d�b�A�����e
                        <%-- 2014/12/09 T.Ono mod 2014���P�J�� No2
                        <cc1:ctlcombo id="cboTELRCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="15" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo> &nbsp; --%>
                        <%-- 2016/12/05 H.Mori mod 2016���P�J�� No4-2
                        <cc1:ctlcombo id="cboTELRCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="15" runat="server" width="170px" cssclass="cb"></cc1:ctlcombo> &nbsp; --%>
                        <cc1:ctlcombo id="cboTELRCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="15" runat="server" width="170px" cssclass="cb-h"></cc1:ctlcombo> &nbsp;
						�Ή�������
						<asp:textbox id="txtSYOYMD" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncNowDate(this)"
							tabindex="29" runat="server" width="74px" cssclass="c-f" maxlength="8"></asp:textbox>&nbsp;
                        ����
						<asp:textbox id="txtSYOTIME" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
							tabindex="30" runat="server" width="74px" cssclass="c-f" maxlength="6"></asp:textbox>&nbsp;
                        <%-- 2019/07/29 W.GANEKO DEL 2019���P�J�� No1 --%> 
                        <%-- 2015/11/16 H.Mori add 2015���P�J�� No1 --%> 
                        <%-- <span style="border-style: solid ; border-width: 1px;">
                        <label for="chkFAXKBN">�񍐕s�v<div id="divFaxKbnDisp1" name="divFaxKbnDisp1" style="DISPLAY:inline">(JA)</div></label><input id="chkFAXKBN" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabindex="31" type="checkbox" name="chkFAXKBN" runat="server"><div id="divFaxKbnDisp2" name="divFaxKbnDisp2" style="DISPLAY:inline"><label for="chkFAXKURAKBN">(�ײ���)</label><input id="chkFAXKURAKBN" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
								tabindex="31" type="checkbox" name="chkFAXKURAKBN" runat="server"></div>&nbsp;--%>
                        <%-- 2015/11/16 H.Mori add 2015���P�J�� No1 START --%> 
                        <%-- <div id="divFaxKbnDisp3" name="divFaxKbnDisp3" style="DISPLAY:inline"><label for="chkFAXRUISEKIKBN">(�ݐ�)</label><input id="chkFAXRUISEKIKBN" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
								tabindex="31" type="checkbox" name="chkFAXRUISEKIKBN" runat="server"></div>  </span>&nbsp;&nbsp; --%>
                        <%-- 2015/11/16 H.Mori add 2015���P�J�� No1 END --%>       
                        <%-- 2019/11/01 W.GANEKO DEL 2019���P�J�� No1 --%> 
                        <span style="width:250px;"></span><input class="bt-SRT" id="btnUpdate" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnUpdate_onclick();"
							tabindex="32" type="button" value="�o�^" name="btnUpdate" runat="server">
					</td>
				</tr>
				<tr>
                    <td colspan="3" rowspan="3">
                    <%-- 2014/06/05 mod T.Ono ���p���͂ɂȂ邱�Ƃ����邽�߁Aclass���g��Ȃ�
                    <textarea name="txtTEL_MEMO" id="txtTEL_MEMO" rows="3" cols="100" class="TELMEMO"
                                 onblur="fnc_byteCheck1(this,100),fncFo(this,1)" onfocus="fncFo(this,2)" runat="server"></textarea> --%>
                    <%-- 2016/02/02 w.ganeko 2015���P�J�� ��1-4 ��2�e start --%>
                    <%--<textarea name="txtTEL_MEMO" id="txtTEL_MEMO" rows="3" cols="100" tabindex="16"
                                 style="font-family: '�l�r �S�V�b�N',sans-serif; font-size: 13px; width:710px; height:50px; overflow:hidden; word-break:break-all; IME-MODE: active;" 
                                 onblur="fnc_byteCheck1(this,100),fncFo(this,1)" onfocus="fncFo(this,2)" runat="server"></textarea> --%>
                    <%-- 2020/11/01 T.Ono mod 2020�Ď����P
                        <textarea name="txtTEL_MEMO" id="txtTEL_MEMO" rows="3" cols="100" tabindex="16"
                                 style="font-family: '�l�r �S�V�b�N',sans-serif; font-size: 14px; width:710px; height:50px; overflow:hidden; word-break:break-all; IME-MODE: active;" 
                                 onblur="fnc_byteCheck1(this,100),fncFo(this,1)" onfocus="fncFo(this,2)" runat="server"></textarea> --%>
                        <textarea name="txtTEL_MEMO" id="txtTEL_MEMO" rows="3" cols="100" tabindex="16"
                                 style="font-family: '�l�r �S�V�b�N',sans-serif; font-size: 14px; width:710px; height:96px; overflow:hidden; word-break:break-all; IME-MODE: active;" 
                                 onblur="fnc_byteCheck1(this,100),fncFo(this,1)" onfocus="fncFo(this,2)" runat="server"></textarea>

                    <%-- 2016/02/02 w.ganeko 2015���P�J�� ��1-4 ��2�e end --%>
                    <input id="hdnTEL_MEMO1" type="hidden" name="hdnTEL_MEMO1" runat="server">�@<!-- 1�s�� -->
                    <input id="hdnTEL_MEMO2" type="hidden" name="hdnTEL_MEMO2" runat="server"> <!-- 2�s�� -->
                    <input id="hdnFUK_MEMO" type="hidden" name="hdnFUK_MEMO" runat="server"> <!-- 3�s�� -->
                    <input id="hdnTEL_MEMO4" type="hidden" name="hdnTEL_MEMO4" runat="server"> <!-- 4�s�� 2020/11/01 T.Ono add 2020�Ď����P -->
                    <input id="hdnTEL_MEMO5" type="hidden" name="hdnTEL_MEMO5" runat="server"> <!-- 5�s�� 2020/11/01 T.Ono add 2020�Ď����P -->
                    <input id="hdnTEL_MEMO6" type="hidden" name="hdnTEL_MEMO6" runat="server"> <!-- 6�s�� 2020/11/01 T.Ono add 2020�Ď����P -->
                    </td>
					<td nowrap align="right">���A�Ή���&nbsp;</td>
                    <%-- 2014/12/09 T.Ono mod 2014���P�J�� No2
					<td nowrap colspan="2"><cc1:ctlcombo id="cboTFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="19" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo></td> --%>
                    <%-- 2019/11/01 w.ganeko mod 2019���P�J�� No6-12
					<td nowrap colspan="2"><cc1:ctlcombo id="cboTFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="19" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo></td> --%>
					<td nowrap colspan="2"><cc1:ctlcombo id="cboTFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="19" runat="server" width="190px" cssclass="cb-h"></cc1:ctlcombo></td>
                </tr>
                <tr>
				    <%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 START
					<td nowrap align="right">�K�X���&nbsp;</td>
					<td colspan="2"><cc1:ctlcombo id="cboTKIGCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="20" runat="server" width="190px" cssclass="cb" designtimedragdrop="2751"></cc1:ctlcombo></td> --%>
					<td nowrap align="right">�������&nbsp;</td>
   				    <%-- 2019/11/01 w.ganeko mod 2019���P�J�� No6-12 START
                    <td colspan="2"><cc1:ctlcombo id="cboTKIGCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="20" runat="server" width="190px" cssclass="cb" designtimedragdrop="2751"></cc1:ctlcombo></td> --%>
                    <td colspan="2"><cc1:ctlcombo id="cboTKIGCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="20" runat="server" width="190px" cssclass="cb-h" designtimedragdrop="2751"></cc1:ctlcombo>
                        <!-- <input id="hdnTKIGCD" type="hidden" name="hdnTKIGCD" runat="server"> 2021/10/01 2021�N�x���P�Ď��A�Ή���ʂ̌������v���_�E������saka �Ή��Ȃ��ƂȂ������߃R�����g�� -->
                    </td> 
				    <%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 END --%>
				</tr>
                <tr>
                    <td nowrap align="right">�쓮����&nbsp;</td>
                    <%-- 2014/12/09 T.Ono mod 2014���P�J�� No2
					<td colspan="2"><cc1:ctlcombo id="cboTSADCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="21" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo></td> --%>
                    <%-- 2019/11/01 w.ganeko mod 2019���P�J�� No6-12 START
					<td colspan="2"><cc1:ctlcombo id="cboTSADCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="21" runat="server" width="190px" cssclass="cb"></cc1:ctlcombo></td> --%>
                    <td colspan="2"><cc1:ctlcombo id="cboTSADCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabindex="21" runat="server" width="190px" cssclass="cb-h"></cc1:ctlcombo>
                        <input id="hdnTSADCD1" type="hidden" name="hdnTSADCD1" runat="server"><!-- 2020/11/01 T.Ono 2020�Ď����P -->
                    </td>
				</tr>
				<tr>
					<td colspan="6" nowrap align="left" >
						<div class="nopr" >���q�l�L��&nbsp;
                            <%-- 2020/11/05 T.Ono mod 2020�Ď����P 
					<asp:textbox id="txtGENIN_KIJI" onkeydown="fncFc(this)" onblur="fnc_byteCheck2(this,160),fncFo_OKYAKU(this,1)" onfocus="fncFo(this,2)"
							tabindex="22" runat="server" width="920px" cssclass="c-fI-nopr c-fI" maxlength="160"  style="background-color:greenyellow"></asp:textbox></div></td> --%> 
					<%-- <asp:textbox id="txtGENIN_KIJI" onkeydown="fncFc(this)" onblur="fncFo_OKYAKU(this,1)" onfocus="fnc_InsertDate(this),fncFo(this,2)"
							tabindex="22" runat="server" width="920px" cssclass="c-fI-nopr c-fI" maxlength="300"  style="background-color:greenyellow"></asp:textbox></div></td> --%>
                    <%-- 2021/02/15 T.Ono mod ���t�������͂��폜 
                            <textarea name="txtGENIN_KIJI" id="txtGENIN_KIJI" rows="2" cols="100" tabindex="22" cssclass="c-fI-nopr c-fI" 
                              style="font-family: '�l�r �S�V�b�N',sans-serif; font-size: 12px; width:920px; height:32px; overflow:hidden; word-break:break-all; IME-MODE: active; background-color:greenyellow" 
                              onblur="fncFo_OKYAKU(this,1)" onfocus="fnc_InsertDate(this),fncFo(this,2)" runat="server"></textarea> --%>
                            <textarea name="txtGENIN_KIJI" id="txtGENIN_KIJI" rows="2" cols="100" tabindex="22" cssclass="c-fI-nopr c-fI" 
                              style="font-family: '�l�r �S�V�b�N',sans-serif; font-size: 12px; width:920px; height:32px; overflow:hidden; word-break:break-all; IME-MODE: active; background-color:greenyellow" 
                              onblur="fncFo_OKYAKU(this,1)" onfocus="fncFo(this,2)" onclick="okyakukiji_AddDate()" runat="server"></textarea>
                        </div>
                    </td>
				</tr>
                <%-- 2013/10/16 T.Ono mod �Ď����P2013��1 ������ --%>
				<tr>
					<td width="80" height="0"></td>
					<td width="240"></td>
					<td width="120"></td>
					<td width="80"></td>
					<td width="240"></td>
					<td width="120"></td>
				</tr>
			</table>
			<%'############  �o���w�� ############%>
			<table class="W" id="Table12" cellspacing="1" cellpadding="0" width="985">
				<tr>
					<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 START --%>
					<%-- <td class="T" nowrap rowspan="4">�o���w��<br>
						�i�w���̏ꍇ�̂݋L���j</td>
					<td nowrap align="right">�o���w�����e&nbsp;</td> --%>
					<td class="T" nowrap rowspan="3">�o���˗�<br>
						�i�˗��̏ꍇ�̂݋L���j</td>
					<td nowrap align="right">�o���˗����e&nbsp;</td>
					<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 END --%>
					<td colspan="2">
						<table cellspacing="0" cellpadding="0">
							<tr>
								<td>
                                    <%-- 2013/08/22 T.Ono mod �Ď����P2013��1
                                    <cc1:ctlcombo id="cboSDCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
										tabindex="23" runat="server" width="380px" cssclass="cb"></cc1:ctlcombo></td> --%>
                                    <%-- 2014/12/09 T.Ono mod 2014���P�J�� No2
                                    <cc1:ctlcombo id="cboSDCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
										tabindex="23" runat="server" width="380px" cssclass="cb"></cc1:ctlcombo></td> --%>
                                    <cc1:ctlcombo id="cboSDCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
										tabindex="23" runat="server" width="380px" cssclass="cb"></cc1:ctlcombo></td>
								<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 START --%>
								<%-- <td nowrap>&nbsp;&nbsp;&nbsp;&nbsp;�w����&nbsp;</td> --%>
								<td nowrap>&nbsp;&nbsp;&nbsp;&nbsp;�˗���&nbsp;</td>
								<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 END --%>
								<td><asp:textbox id="txtSIJIYMD" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncNowDate(this)"
										tabindex="27" runat="server" width="74px" cssclass="c-f" maxlength="8"></asp:textbox>&nbsp;&nbsp;</td>
								<td nowrap>&nbsp;&nbsp;����&nbsp;</td>
								<td><asp:textbox id="txtSIJITIME" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
										tabindex="28" runat="server" width="69px" cssclass="c-f" maxlength="6"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td align="right" rowspan="3">
						<table>
							<tr>
                                <td align="right"><input language="javascript" class="bt-RNW" id="btnRenraku" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
										onclick="fncChkRocuser('3');" tabindex="26" type="button" value="�A����I��" name="btnRenraku">
								</td> <%--2017/10/19 H.Mori mod 2017���P�J�� No4-3 id="btnRenraku"��onclick="btnRenraku_onclick('2');" �� onclick="fncChkRocuser('3');" --%>                        
							</tr>
							<tr>
								<td align="right"><input language="javascript" class="bt-RNW" id="btnTel" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
										onclick="btnRenraku_onclick('1');" tabindex="26" type="button" value="�d�b���M" name="btnTel">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 START --%>
					<%-- <td nowrap align="right">�o���w�����l&nbsp;</td> --%>
					<td nowrap align="right">�o���˗����l&nbsp;</td>
					<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 END --%>
					<td nowrap width="520"><asp:textbox id="txtSIJI_BIKO1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="24" runat="server" width="519px" cssclass="c-fI" maxlength="35" designtimedragdrop="3518"></asp:textbox></td>
				</tr>
				<tr>
					<td nowrap align="right">�o����Ж�&nbsp;</td>
					<%--<td nowrap><asp:textbox id="txtSTD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="-1" runat="server" readonly="True" width="160px" borderstyle="Solid" borderwidth="1px"
							cssclass="c-rNM" maxlength="50" designtimedragdrop="3518"></asp:textbox><input id="hdnSTD_CD" type="hidden" name="hdnSTD_CD" runat="server">
						&nbsp;&nbsp;���_��
						<asp:textbox id="txtSTD_KYOTEN" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="-1" runat="server" readonly="True" width="160px" borderstyle="Solid" borderwidth="1px"
							cssclass="c-rNM" maxlength="50" designtimedragdrop="3518"></asp:textbox><input id="hdnSTD_KYOTEN_CD" type="hidden" name="hdnSTD_KYOTEN_CD" runat="server">
						&nbsp;&nbsp;&nbsp;�d�b�ԍ�&nbsp;
						<asp:textbox id="txtSTD_TEL" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="-1" runat="server" readonly="True" width="112px" borderstyle="Solid" borderwidth="1px"
							cssclass="c-rNM" maxlength="50" designtimedragdrop="3518"></asp:textbox></td>--%>
					<td nowrap><asp:textbox id="txtSTD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="-1" runat="server" width="160px" borderstyle="Solid" borderwidth="1px"
							cssclass="c-rNM" maxlength="50" designtimedragdrop="3518"></asp:textbox><input id="hdnSTD_CD" type="hidden" name="hdnSTD_CD" runat="server">
						&nbsp;&nbsp;���_��
						<asp:textbox id="txtSTD_KYOTEN" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="-1" runat="server" width="160px" borderstyle="Solid" borderwidth="1px"
							cssclass="c-rNM" maxlength="50" designtimedragdrop="3518"></asp:textbox><input id="hdnSTD_KYOTEN_CD" type="hidden" name="hdnSTD_KYOTEN_CD" runat="server">
						&nbsp;&nbsp;&nbsp;�d�b�ԍ�&nbsp;
						<asp:textbox id="txtSTD_TEL" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="-1" runat="server" width="112px" borderstyle="Solid" borderwidth="1px"
							cssclass="c-rNM" maxlength="50" designtimedragdrop="3518"></asp:textbox></td>
				</tr>
				<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 START --%>
				<%-- <tr> --%>
				<tr style="display:none">
				<%-- 2014/11/28 H.Hosoda mod 2014���P�J�� No2 END --%>
					<td nowrap align="right">
					<td nowrap width="520">
						<asp:textbox id="txtSIJI_BIKO2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabindex="25" runat="server" width="519px" cssclass="c-fI" maxlength="35" designtimedragdrop="3518"
							style="VISIBILITY:hidden"></asp:textbox></td>
				</tr>
			</table>
			<%'############  ���[�^ ############%>
			<table class="POSS_META" cellspacing="0" cellpadding="0">
				<tr>
                    <td align="center">�̔��敪</td><%-- 2015/11/17 H.Mori add 2015���P�J�� No1 --%>
                    <td align="center">�����`�ԋ敪</td><%-- 2016/12/02 H.Mori add 2016���P�J�� No4-3 --%>
					<td align="center">���[�^�^��</td>
					<td align="center">���[�^���[�J�[</td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap align="center"><asp:textbox id="txtMET_KATA" tabindex="-1" runat="server" readonly="True" width="140px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtMET_MAKER" tabindex="-1" runat="server" readonly="True" width="220px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <%-- 2015/11/17 H.Mori add 2015���P�J�� No1 --%>
                    <td nowrap align="center"><asp:textbox ID="txtHANBAI_KBN" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input id="hdnHANBAI_KBN" type="hidden" name="hdnHANBAI_KBN" runat="server" >&nbsp;</td>
                    <%-- 2016/12/02 H.Mori add 2016���P�J�� No4-3 START --%>
                    <td nowrap align="center"><asp:textbox ID="txtKYOKTKBN" tabindex="-1" runat="server" width="62px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox><input id="hdnKYOKTKBN" type="hidden" name="hdnKYOKTKBN" runat="server" >&nbsp;</td>
                    <%-- 2016/12/02 H.Mori add 2016���P�J�� No4-3 END --%>
                    <td nowrap align="center"><asp:textbox id="txtMET_KATA" tabindex="-1" runat="server" width="140px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
                    <%-- 2015/11/17 H.Mori mod 2015���P�J�� No1 
					<td align="center"><asp:textbox id="txtMET_MAKER" tabindex="-1" runat="server" width="220px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <%-- 2016/12/02 H.Mori mod 2016���P�J�� No4-3 START 
                    <td align="center"><asp:textbox id="txtMET_MAKER" tabindex="-1" runat="server" width="142px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td> --%>
                    <td align="center"><asp:textbox id="txtMET_MAKER" tabindex="-1" runat="server" width="80px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
                    <%-- 2016/12/02 H.Mori mod 2016���P�J�� No4-3 END --%>
				</tr>
			</table>
			<%'############  �e�� ############%>
			<table class="POSS_YOUKI" cellspacing="0" cellpadding="0">
				<tr>
					<td>&nbsp;</td>
					<td align="center">�e��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
					<td align="center">�{��</td>
					<td align="center">&nbsp;</td>
					<td align="center">�e��&nbsp;&nbsp;&nbsp;&nbsp;</td>
					<td align="center">�\��&nbsp;</td>
				</tr>
				<tr>
					<td align="right">&nbsp;</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td align="center"><asp:textbox id="txtBONB1_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB1_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB1_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB1_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
					<td align="center">&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB1_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB1_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="60px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg</td>
					<td align="center"><input id="chkBONB1_YOBI" disabled tabindex="-1" type="checkbox" name="chkBONB1_YOBI" runat="server"><input id="hdnBONB1_YOBI" type="hidden" name="hdnBONB1_YOBI" runat="server"></td>
				</tr>
				<tr>
					<td align="right">&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB2_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB2_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB2_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB2_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
					<td align="center">&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB2_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB2_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="60px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg</td>
					<td align="center"><input id="chkBONB2_YOBI" disabled tabindex="-1" type="checkbox" name="chkBONB2_YOBI" runat="server"><input id="hdnBONB2_YOBI" type="hidden" name="hdnBONB2_YOBI" runat="server"></td>
				</tr>
				<tr>
					<td align="right">&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB3_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB3_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB3_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB3_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
					<td align="center">&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB3_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB3_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="60px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg</td>
					<td align="center"><input id="chkBONB3_YOBI" disabled tabindex="-1" type="checkbox" name="chkBONB3_YOBI" runat="server"><input id="hdnBONB3_YOBI" type="hidden" name="hdnBONB3_YOBI" runat="server"></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB4_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB4_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB4_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB4_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
					<td align="center">&nbsp;</td>
					<%--<td align="center"><asp:textbox id="txtBONB4_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td align="center"><asp:textbox id="txtBONB4_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="60px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg</td>
					<td align="center"><input id="chkBONB4_YOBI" disabled tabindex="-1" type="checkbox" name="chkBONB4_YOBI" runat="server"><input id="hdnBONB4_YOBI" type="hidden" name="hdnBONB4_YOBI" runat="server"></td>
				</tr>
			</table>
			<%'############  �g�p�� ############%>
			<table class="POSS_SIYOU" cellspacing="0" cellpadding="0">
				<tr>
					<td colspan="2" height="5"></td>
				</tr>
				<tr>
					<td height="35">�z���������<br>
						����g�p��
					</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td width="100"><asp:textbox id="txtG_ZAIKO" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td width="100"><asp:textbox id="txtG_ZAIKO" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="64px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4716"></asp:textbox>&nbsp;kg&nbsp;</td>
				</tr>
				<tr>
					<td height="35">�P������<br>
						�g�p��&nbsp;&nbsp;
					</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td width="100"><asp:textbox id="txtICHI_SIYO" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"--%>
                    <td width="100"><asp:textbox id="txtICHI_SIYO" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="64px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4716"></asp:textbox>&nbsp;m3&nbsp;</td>
				</tr>
				<tr>
					<td height="35">�\���P������<br>
						�g�p��
					</td>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td width="120"><asp:textbox id="txtYOSOKU_ICHI_SIYO" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							readonly="True" width="64px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4716"></asp:textbox>&nbsp;m3&nbsp;</td>--%>
                    <td width="120"><asp:textbox id="txtYOSOKU_ICHI_SIYO" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="64px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4716"></asp:textbox>&nbsp;m3&nbsp;</td>
				</tr>
			</table>
			<%'############  ���j ############%>
			<table class="POSS_KENSIN" cellspacing="0" cellpadding="0">
				<tr>
					<td align="center" width="80">���j��</td>
					<td align="center" width="80">�w�j</td>
					<td align="center" width="80">�g�p��</td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td><asp:textbox id="txtZENKAI_KENSIN" tabindex="-1" runat="server" readonly="True" width="75px"
							borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4726"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtZENKAI_KEN_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>
					<td><asp:textbox id="txtZENKAI_KEN_SIYO" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="69px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>--%>
                    <td><asp:textbox id="txtZENKAI_KENSIN" tabindex="-1" runat="server" width="75px"
							borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4726"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtZENKAI_KEN_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>
					<td><asp:textbox id="txtZENKAI_KEN_SIYO" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="69px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td><asp:textbox id="txtKONKAI_KENSIN" tabindex="-1" runat="server" readonly="True" width="75px"
							borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtKONKAI_KEN_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4733"></asp:textbox>&nbsp;m3&nbsp;</td>
					<td><asp:textbox id="txtKONKAI_KEN_SIYO" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="69px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>--%>
                    <td><asp:textbox id="txtKONKAI_KENSIN" tabindex="-1" runat="server" width="75px"
							borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtKONKAI_KEN_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4733"></asp:textbox>&nbsp;m3&nbsp;</td>
					<td><asp:textbox id="txtKONKAI_KEN_SIYO" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="69px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>
				</tr>
			</table>
			<%'############  �{���x�ؑ� ############%>
			<table class="POSS_BONBE" cellspacing="0" cellpadding="0" width="150">
				<tr>
					<td align="center" width="70">�{���x�ؑ�</td>
					<td align="center" width="80">�w�j</td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td><asp:textbox id="txtZENKAI_HASEI" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtZENKAI_HAS_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>--%>
                    <td><asp:textbox id="txtZENKAI_HASEI" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtZENKAI_HAS_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>  
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td><asp:textbox id="txtKONKAI_HASEI" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4748"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtKONKAI_HAS_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>--%>
                    <td><asp:textbox id="txtKONKAI_HASEI" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4748"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtKONKAI_HAS_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>
				</tr>
			</table>
			<%'############  �z�� ############%>
			<table class="POSS_HAISO" cellspacing="0" cellpadding="0" width="160">
				<tr>
					<td align="center" width="80">�z����</td>
					<td align="center" width="80">�w�j</td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td><asp:textbox id="txtZENKAI_HAISO" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtZENKAI_HAI_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>--%>
                    <td><asp:textbox id="txtZENKAI_HAISO" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtZENKAI_HAI_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td><asp:textbox id="txtKONKAI_HAISO" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtKONKAI_HAI_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>--%>
                    <td><asp:textbox id="txtKONKAI_HAISO" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td><asp:textbox id="txtKONKAI_HAI_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</td>
				</tr>
				<tr>
					<td colspan="2">����z���\���&nbsp;
						<%--<asp:textbox id="txtJIKAI_HAISO" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"--%>
                        <asp:textbox id="txtJIKAI_HAISO" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
				</tr>
			</table>
			<%'############  �K�X��� ############%>
			<table class="POSS_GASU" cellspacing="0" cellpadding="0" width="125">
				<tr>
					<td nowrap align="center">�K�X���i��</td>
					<td nowrap align="center">�䐔</td>
					<td nowrap align="center">����</td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap align="center"><asp:textbox id="txtGAS1_HINMEI" tabindex="-1" runat="server" readonly="True" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS1_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS1_SEIFL" tabindex="-1" runat="server" readonly="True" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <td nowrap align="center"><asp:textbox id="txtGAS1_HINMEI" tabindex="-1" runat="server" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS1_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS1_SEIFL" tabindex="-1" runat="server" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap align="center"><asp:textbox id="txtGAS2_HINMEI" tabindex="-1" runat="server" readonly="True" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS2_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS2_SEIFL" tabindex="-1" runat="server" readonly="True" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <td nowrap align="center"><asp:textbox id="txtGAS2_HINMEI" tabindex="-1" runat="server" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS2_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS2_SEIFL" tabindex="-1" runat="server" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap align="center"><asp:textbox id="txtGAS3_HINMEI" tabindex="-1" runat="server" readonly="True" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS3_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS3_SEIFL" tabindex="-1" runat="server" readonly="True" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <td nowrap align="center"><asp:textbox id="txtGAS3_HINMEI" tabindex="-1" runat="server" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS3_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS3_SEIFL" tabindex="-1" runat="server" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap align="center"><asp:textbox id="txtGAS4_HINMEI" tabindex="-1" runat="server" readonly="True" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS4_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS4_SEIFL" tabindex="-1" runat="server" readonly="True" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <td nowrap align="center"><asp:textbox id="txtGAS4_HINMEI" tabindex="-1" runat="server" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS4_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS4_SEIFL" tabindex="-1" runat="server" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
				</tr>
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<td nowrap align="center"><asp:textbox id="txtGAS5_HINMEI" tabindex="-1" runat="server" readonly="True" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS5_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS5_SEIFL" tabindex="-1" runat="server" readonly="True" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>--%>
                    <td nowrap align="center"><asp:textbox id="txtGAS5_HINMEI" tabindex="-1" runat="server" width="120px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td nowrap align="center"><asp:textbox id="txtGAS5_DAISU" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="26px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center"><asp:textbox id="txtGAS5_SEIFL" tabindex="-1" runat="server" width="26px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></td>
				</tr>
			</table>
			<%'############  �x�p�~ ############%>
			<table id="tableGASSTATE" class="POSS_HAISI" cellspacing="0" cellpadding="0">
				<tr>
                    <%--2012/04/04 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<td align="center">�K�X�����x�~��<br>
                    �i������~���j</td> <%--2017/10/13 H.Mori add 2017���P�J�� No7 �i������~���j�ǉ� --%>
					<%--<td><asp:textbox id="txtGAS_START" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>--%>
                    <td><asp:textbox id="txtGAS_START" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center">�K�X�����p�~��<br>
                    �i����p�~���j</td> <%--2017/10/13 H.Mori add 2017���P�J�� No7 �i����p�~���j�ǉ� --%>
					<%--<td><asp:textbox id="txtGAS_DELE" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>--%>
                    <td><asp:textbox id="txtGAS_DELE" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
					<td align="center">�K�X����������</td>
					<%--<td><asp:textbox id="txtGAS_RESTART" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>--%>
                    <td><asp:textbox id="txtGAS_RESTART" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</td>
				</tr>
			</table>
            <%'############  �{���H���� ############%>�@<!-- 2013/08/15 T.Ono add �Ď����P2013��1 -->
			<table class="POSS_KAITU_DAY" cellspacing="0" cellpadding="0">
				<tr>
					<td align="center">�{���H����</td>
                    <td><asp:textbox id="txtKAITU_DAY" tabindex="-1" runat="server" width="150px" borderstyle="Solid" BorderColor="Black"
							borderwidth="1px" cssclass="c-rNM" style="color:Red"></asp:textbox>&nbsp;</td>
				</tr>
			</table>
			<%'############  �Ή������Ɖ� ############%>
			<input class="POSS_RIREKI bt-RNW" id="btnRireki" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
				onclick="btnRireki_onclick();" tabindex="-1" type="button" value="�Ή������Ɖ�" name="btnRireki">
			<!-- 2007/05/09 T.Watabe add �Ή����͉\�N���C�A���g���c�a�v���_�E�����X�g�Œǉ��ł���悤�� -->
			<input id="hdnInputClientList" type="hidden" name="hdnInputClientList" runat="server">
			<INPUT id="hdnSDSKBN" type="hidden" name="hdnSDSKBN" runat="server"><!-- 2008/10/17 T.Watabe add -->
			<INPUT id="hdnOTHER_KANSI_CENTER" type="hidden" name="hdnOTHER_KANSI_CENTER" runat="server"><!-- 2010/10/27 T.Watabe add -->
			<%-- 2011/11/09 add H.Uema JA���ӎ����t�H�[���ǉ� START --%>
			<div class="POSS_GUIDELINE" id="divGuideline">
				<table cellspacing="2">
					<!-- 2013/06/25 mod T.Ono ���ӎ������g��&���� START -->
<%--                     <tr class="COMMT">
						<td nowrap>JA���ӎ���</td>
					</tr>
					<tr>
						<td nowrap class="W" width="200" height="400">&nbsp;<asp:Label id="lblGuideline" Runat="server"></asp:Label></td>
					</tr> --%>
					<tr class="COMMT">
     					<td nowrap><input type="radio" id="guidelineClck1" name="guidelineClck" value="1" checked onclick="chkClientRadio_onclick()"/><label id="lblGuidelineNMCL1" for="guidelineClck1">�N���C�A���g1</label><input type="radio" id="guidelineClck2" name="guidelineClck" value="2" onclick="chkClientRadio_onclick()"/><label id="lblGuidelineNMCL2" for="guidelineClck2">�N���C�A���g2</label><input type="radio" id="guidelineClck3" name="guidelineClck" value="3" onclick="chkClientRadio_onclick()"/><label id="lblGuidelineNMCL3" for="guidelineClck3">�N���C�A���g3</label></td>
					</tr>
					<tr>
						<td nowrap class="W" width="400" height="202"><table id="dlblGuidelineCL"><tr><td><asp:Label id="lblGuidelineCL" class="GUIDELINE_lbl" width="400" height="202" Runat="server"></asp:Label></td></tr></table><table id="dlblGuidelineCL2" style="display:none;"><tr><td><asp:Label id="lblGuidelineCL2" class="GUIDELINE_lbl" width="400" height="202" Runat="server"></asp:Label></td></tr></table><table id="dlblGuidelineCL3"  style="display:none;"><tr><td><asp:Label id="lblGuidelineCL3" class="GUIDELINE_lbl" width="400" height="202" Runat="server"></asp:Label></td></tr></table></td>
					</tr>
					<tr class="COMMT">
						<td nowrap><input type="radio" id="guidelineck1" name="guidelineck" value="1" checked  onclick="chkJaChuiRadio_onclick()"/><label id="lblGuidelineNM1" for="guidelineck1">JA���ӎ���1</label><input type="radio" id="guidelineck2"  name="guidelineck" value="2"  onclick="chkJaChuiRadio_onclick()"/><label id="lblGuidelineNM2" for="guidelineck2">JA���ӎ���2</label><input type="radio" id="guidelineck3"  name="guidelineck" value="3"  onclick="chkJaChuiRadio_onclick()"/><label id="lblGuidelineNM3" for="guidelineck3">JA���ӎ���3</label></td>
					</tr>
					<tr>
						<td nowrap class="W" width="400" height="420"><table id="dlblGuideline"><tr><td><asp:Label id="lblGuideline" class="GUIDELINE_lbl" width="400" height="420" Runat="server"></asp:Label></td></tr></table><table id="dlblGuideline2"  style="display:none;"><tr><td><asp:Label id="lblGuideline2" class="GUIDELINE_lbl" width="400" height="420" Runat="server"></asp:Label></td></tr></table><table id="dlblGuideline3" style="display:none;"><tr><td><asp:Label id="lblGuideline3" class="GUIDELINE_lbl" width="400" height="420"  Runat="server"></asp:Label></td></tr></table></td>
					</tr>
                    <!-- 2013/06/13 mod T.Ono END -->
				</table>
			</div>
			<input id="txtGuideline" style="display: none;" type="text" name="txtGuideline" onchange="setGuideline();">
            <input id="txtGuidelineCL" style="display: none;" type="text" name="txtGuidelineCL" onchange="setGuidelineCL();"><!-- 2013/06/25 T.Ono add -->
			<input id="txtGuideline2" style="display: none;" type="text" name="txtGuideline2" onchange="setGuideline();">      <!-- 2019/11/01 W.GANEKO add -->
            <input id="txtGuidelineCL2" style="display: none;" type="text" name="txtGuidelineCL2" onchange="setGuidelineCL();"><!-- 2019/11/01 W.GANEKO add -->
			<input id="txtGuideline3" style="display: none;" type="text" name="txtGuideline3" onchange="setGuideline();">      <!-- 2019/11/01 W.GANEKO add -->
            <input id="txtGuidelineCL3" style="display: none;" type="text" name="txtGuidelineCL3" onchange="setGuidelineCL();"><!-- 2019/11/01 W.GANEKO add -->
            <!-- 2020/10/05 T.Ono add �Ď����P2020 ���ӎ����{�^���� -->
            <input id="txtGuidelineNM1" style="display: none;" type="text" name="txtGuidelineNM1" onchange="setGuideline();">
            <input id="txtGuidelineNMCL1" style="display: none;" type="text" name="txtGuidelineNMCL1" onchange="setGuideline();">
            <input id="txtGuidelineNM2" style="display: none;" type="text" name="txtGuidelineNM2" onchange="setGuideline();" />
            <input id="txtGuidelineNMCL2" style="display: none;" type="text" name="txtGuidelineNMCL2" onchange="setGuideline();">
            <input id="txtGuidelineNM3" style="display: none;" type="text" name="txtGuidelineNM3" onchange="setGuideline();">
            <input id="txtGuidelineNMCL3" style="display: none;" type="text" name="txtGuidelineNMCL3" onchange="setGuideline();">
			<%-- 2011/11/09 add H.Uema JA���ӎ����t�H�[���ǉ� END --%>
		</form>
	</body>
</HTML>
