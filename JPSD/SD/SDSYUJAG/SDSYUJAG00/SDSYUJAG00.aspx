<%@ Register TagPrefix="cc1" Namespace="JPG.Common.Controls" Assembly="COCNTRLL00" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SDSYUJAG00.aspx.vb" Inherits="JPSD.SDSYUJAG00.SDSYUJAG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>�ً}�o���m�F�E����</title>
        <!-- 2013/07/30 T.Ono add �������ʕ���Ή� -->
        <style type="text/css" media="print">
        <!--
        @media print {
          body {
            zoom: 92%; /* */
          }
        }
        -->
        </style>
        <style>
        .TELMEMO{
        �@font-family: "�l�r �S�V�b�N",sans-serif;
        �@font-size: 12px; 
        �@width:610px;
        �@height:80px; /* height:50px; 2020/11/01 T.Ono mod 2020�Ď����P */
        �@overflow:hidden; /* ��۰��ް���� */
        �@word-break:break-all; /* IE�̂݁A�P��r���ł����s */
        �@IME-MODE: active; /* ���̓��[�h�S�p */
	    }
        </style>
	</HEAD>
	<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
	<%-- <body> --%>
	<body onload="fncOnLoad();">
	<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>	
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server">
			<INPUT id="hdnLOGIN_FLG" type="hidden" name="hdnLOGIN_FLG" runat="server">
			<BR>
			<TABLE id="Table4" cellSpacing="0" cellPadding="2" width="980">
				<TBODY>
					<TR>
						<TD class="TITLE" vAlign="middle" width="500"><SPAN id="lblTitle">�ً}�Ή�������</SPAN></TD>
						<TD align="right"><INPUT language="javascript" class="bt-JIK" id="btnUpd1" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
								onclick="return btnUpd1_onclick();" tabIndex="96" type="button" value="�Ή�����" name="btnUpd1" runat="server"></TD>
						<TD align="right"><INPUT language="javascript" class="bt-JIK" id="btnUpd2" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
								onclick="return btnUpd2_onclick();" tabIndex="96" type="button" value="�Ή���" name="btnUpd2" runat="server"></TD>
						<TD align="right">
							<INPUT class="bt-JIK" id="btnPrint" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnPrint_onclick();" tabIndex="96" type="button" value="���" name="btnPrint">
							<INPUT class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)" onclick="return btnExit_onclick();" tabIndex="96" type="button" value="�I��" name="btnExit" runat="server">
							
							<INPUT id="hdnKEY_KANSCD" type="hidden" name="hdnKEY_KANSCD" runat="server"> <INPUT id="hdnKEY_SYONO" type="hidden" name="hdnKEY_SYONO" runat="server">
							<INPUT id="hdnKBN" type="hidden" name="hdnKBN" runat="server"> <INPUT id="hdnEDT_DATE" type="hidden" name="hdnEDT_DATE" runat="server">
							<INPUT id="hdnEDT_TIME" type="hidden" name="hdnEDT_TIME" runat="server"> <INPUT id="hdnMOVE_SIJIYMD_F" type="hidden" name="hdnMOVE_SIJIYMD_F" runat="server">
							<INPUT id="hdnMOVE_SIJIYMD_T" type="hidden" name="hdnMOVE_SIJIYMD_T" runat="server">
							<INPUT id="hdnMOVE_KBN" type="hidden" name="hdnMOVE_KBN" runat="server"> <INPUT id="hdnSTDCD" type="hidden" name="hdnSTDCD" runat="server">
							
							<!-- 2008/11/04 T.Watabe add -->
							<input id="hdnPopcrtl" type="hidden" name="hdnPopcrtl" runat="server">
							<input id="hdnKensaku" type="hidden" name="hdnKensaku" runat="server">
							
							<!-- 2008/11/05 T.Watabe add -->
							<input id="hdnKURACD" type="hidden" name="hdnKURACD" runat="server">
							<input id="hdnJASCD" type="hidden" name="hdnJASCD" runat="server">

                            <!-- 2013/12/10 T.Ono add �Ď����P2013 -->
                            <input id="hdnScrollTop" type="hidden" name="hdnScrollTop" runat="server">
                            <input id="hdnMOVE_CLI_CD" type="hidden" name="hdnMOVE_CLI_CD" runat="server"> <input id="hdnMOVE_CLI_CD_NAME" type="hidden" name="hdnMOVE_CLI_CD_NAME" runat="server">
                            <input id="hdnMOVE_JA_CD" type="hidden" name="hdnMOVE_JA_CD" runat="server"> <input id="hdnMOVE_JA_CD_NAME" type="hidden" name="hdnMOVE_JA_CD_NAME" runat="server">
                          	<%-- 2014/10/21 H.Hosoda add 1Line 2014���P�J�� No10 --%>
                            <input id="hdnMOVE_GROUP_CD" type="hidden" name="hdnMOVE_GROUP_CD" runat="server"> <input id="hdnMOVE_GROUP_CD_NAME" type="hidden" name="hdnMOVE_GROUP_CD_NAME" runat="server">

						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<BR>
			<%'**********  �Ď��Z���^�[�Ή����  ************%>
			<SPAN>
				<TABLE class="POSS_HED1" cellSpacing="0" cellPadding="0" width="980">
					<TBODY>
						<TR>
							<TD width="80">����</TD>
                            <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
							<%--<TD width="60"><asp:textbox id="txtKENNM" tabIndex="-1" runat="server" Width="50" CssClass="c-rNM" ReadOnly="True"
									BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
							<TD align="right">�����Z���^�[&nbsp;&nbsp;</TD>
							<TD width="230"><asp:textbox id="txtHAISO_NAME" tabIndex="-1" runat="server" Width="230" CssClass="c-rNM" ReadOnly="True"
									BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
							<TD align="right">�i�`�x��&nbsp;&nbsp;</TD>
							<TD width="260"><asp:textbox id="txtJANM" tabIndex="-1" runat="server" Width="260" CssClass="c-rNM" ReadOnly="True"
									BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
							<TD align="right">�����ԍ�&nbsp;&nbsp;</TD>
							<TD width="90"><asp:textbox id="txtSYONO" tabIndex="-1" runat="server" Width="90" CssClass="c-rNM" ReadOnly="True"
									BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                            <TD width="60"><asp:textbox id="txtKENNM" tabIndex="-1" runat="server" Width="50" CssClass="c-rNM"
									BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
							<TD align="right">�����Z���^�[&nbsp;&nbsp;</TD>
							<TD width="230"><asp:textbox id="txtHAISO_NAME" tabIndex="-1" runat="server" Width="230" CssClass="c-rNM"
									BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
							<TD align="right">�i�`�x��&nbsp;&nbsp;</TD>
							<TD width="260"><asp:textbox id="txtJANM" tabIndex="-1" runat="server" Width="260" CssClass="c-rNM"
									BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
							<TD align="right">�����ԍ�&nbsp;&nbsp;</TD>
							<TD width="90"><asp:textbox id="txtSYONO" tabIndex="-1" runat="server" Width="90" CssClass="c-rNM"
									BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
							<TD align="right"><input type="button" name="btnRenraku" value="�A����" class="bt-JIK" onclick="return fncPop('SDSYUJTG00');"></TD>
						</TR>
					</TBODY></TABLE>
				<TABLE class="POSS_HED2" cellSpacing="0" cellPadding="0" width="980">
					<TR>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD width="80">��������</TD>
						<TD width="75"><asp:textbox id="txtHATYMD" tabIndex="-1" runat="server" Width="74" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="50"><asp:textbox id="txtHATTIME" tabIndex="-1" runat="server" Width="49" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD align="right">&nbsp;�����敪&nbsp;</TD>
						<TD width="75"><asp:textbox id="txtHATKBN" tabIndex="-1" runat="server" Width="74" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD align="right">&nbsp;�w������ &nbsp;</TD>
						<TD width="75"><asp:textbox id="txtSIJIYMD" tabIndex="-1" runat="server" Width="74" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="50"><asp:textbox id="txtSIJITIME" tabIndex="-1" runat="server" Width="60" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD align="right">&nbsp;�Ď��Z���^�[�S����&nbsp;</TD>
						<TD width="340"><asp:textbox id="txtTKTANCD_NM" tabIndex="-1" runat="server" Width="340" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                        <%-- 2015/01/16 T.Ono add 2014���P�J�� No11 �ĕύX START --%>
                        <%-- <TD width="80">��������</TD> --%>
                        <TD width="80">��M����</TD>
						<%-- 2015/01/16 T.Ono add 2014���P�J�� No11 �ĕύX END --%>
						<TD width="75"><asp:textbox id="txtHATYMD" tabIndex="-1" runat="server" Width="74" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="50"><asp:textbox id="txtHATTIME" tabIndex="-1" runat="server" Width="49" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD align="right">&nbsp;�����敪&nbsp;</TD>
						<TD width="75"><asp:textbox id="txtHATKBN" tabIndex="-1" runat="server" Width="74" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
						<%-- <TD align="right">&nbsp;�w������ &nbsp;</TD> --%>
						<TD align="right">&nbsp;�˗����� &nbsp;</TD>
						 <%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
						<TD width="75"><asp:textbox id="txtSIJIYMD" tabIndex="-1" runat="server" Width="74" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="50"><asp:textbox id="txtSIJITIME" tabIndex="-1" runat="server" Width="60" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD align="right">&nbsp;�Ď��Z���^�[�S����&nbsp;</TD>
						<TD width="340"><asp:textbox id="txtTKTANCD_NM" tabIndex="-1" runat="server" Width="340" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
				</TABLE>
				<!-- <TABLE class="POSS_HED3" cellSpacing="0" cellPadding="0" width="880"> '2013/07/30 T.Ono mod �������ʕ���Ή� -->
                <TABLE class="POSS_HED3" cellSpacing="0" cellPadding="0" width="980">
					<TR>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
						<%-- <TD noWrap width="80">�o���w�����e</TD> --%>
						<TD noWrap width="80">�o���˗����e</TD>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD colSpan="5"><asp:textbox class="c-rNM" id="txtSDNM" tabIndex="-1" runat="server" Width="850" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                        <TD colSpan="5"><asp:textbox class="c-rNM" id="txtSDNM" tabIndex="-1" runat="server" Width="850"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
					<TR>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
						<%-- <TD noWrap width="80">�o���w�����l</TD> --%>
						<TD noWrap width="80">�o���˗����l</TD>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
						<%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
                        <%--<TD colSpan="5"><asp:textbox class="c-rNM" id="txtSIJI_BIKO" tabIndex="-1" runat="server" Width="850" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                        <TD colSpan="5"><asp:textbox class="c-rNM" id="txtSIJI_BIKO" tabIndex="-1" runat="server" Width="850"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
					<TR>
                    <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD width="80">���q�l����</TD>
						<TD width="280"><asp:textbox class="c-rNM" id="txtJUSYONM" tabIndex="-1" runat="server" Width="245" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD noWrap align="right" width="90">�t���K�i&nbsp;&nbsp;</TD>
						<TD width="280"><asp:textbox class="c-rNM" id="txtJUSYOKN" tabIndex="-1" runat="server" Width="245" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="80">&nbsp;���d�b�ԍ�&nbsp;</TD>
						<TD align="left" width="120"><asp:textbox class="c-rNM" id="txtKTELNO" tabIndex="-1" runat="server" Width="110" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                        <%-- <TD width="80">���q�l����</TD> --%><%-- 2015/01/21 T.Ono mod 2014���P�J�� No11 �ǉ��ύX STAR --%>
						<TD width="80">���q�l��</TD>
						<TD width="280"><asp:textbox class="c-rNM" id="txtJUSYONM" tabIndex="-1" runat="server" Width="245"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD noWrap align="right" width="90">�t���K�i&nbsp;&nbsp;</TD>
						<TD width="280"><asp:textbox class="c-rNM" id="txtJUSYOKN" tabIndex="-1" runat="server" Width="245"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<!-- <TD width="80">&nbsp;���d�b�ԍ�&nbsp;</TD> 2013/07/30 T.Ono mod �������ʕ���Ή� -->
						<%-- 2015/01/16 T.Ono add 2014���P�J�� No11 �ĕύX STAR --%>
                        <%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
						<%-- <TD width="81">&nbsp;���d�b�ԍ�&nbsp;</TD> --%>
						<%-- <TD width="81">&nbsp;�A����d�b&nbsp;</TD> --%>
                        <TD width="81" align="center">&nbsp;�A����&nbsp;</TD>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
						<%-- 2015/01/16 T.Ono add 2014���P�J�� No11 �ĕύX END --%>
						<TD align="left" width="120"><asp:textbox class="c-rNM" id="txtKTELNO" tabIndex="-1" runat="server" Width="110"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
					<TR>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD width="80">���Z��</TD>
						<TD width="710" colSpan="3"><asp:textbox class="c-rNM" id="txtADDR" tabIndex="-1" runat="server" Width="710" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="60" align="right">&nbsp;�n�}�ԍ�</TD>
						<TD width="120" align="left"><asp:textbox class="c-rNM" id="txtTIZUNO" tabIndex="-1" runat="server" ReadOnly="True" Width="110"
								BorderStyle="Solid" BorderWidth="1px"></asp:textbox></TD>--%>
                        <TD width="80">���Z��</TD>
						<TD width="710" colSpan="3"><asp:textbox class="c-rNM" id="txtADDR" tabIndex="-1" runat="server" Width="710"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="60" align="right">&nbsp;�n�}�ԍ�</TD>
						<TD width="120" align="left"><asp:textbox class="c-rNM" id="txtTIZUNO" tabIndex="-1" runat="server" Width="110"
								BorderStyle="Solid" BorderWidth="1px"></asp:textbox></TD>
					</TR>
				</TABLE>
			</SPAN>
			<%'**********  �x��  ************%>
			<TABLE style="LEFT: 50px; POSITION: absolute; TOP: 190px" cellSpacing="0" cellPadding="0">
				<TBODY>
					<TR>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD width="20" rowSpan="3">�x��</TD>
						<TD width="15"><asp:textbox id="txtKMNO1" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM" ReadOnly="True"
								value="1" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="200"><asp:textbox id="txtKMNM1" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="15"><asp:textbox id="txtKMNO4" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM" ReadOnly="True"
								value="4" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="200"><asp:textbox id="txtKMNM4" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                        <TD width="20" rowSpan="3">�x��</TD>
						<TD width="15"><asp:textbox id="txtKMNO1" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM"
								value="1" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="200"><asp:textbox id="txtKMNM1" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="15"><asp:textbox id="txtKMNO4" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM"
								value="4" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD width="200"><asp:textbox id="txtKMNM4" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
					<TR>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD><asp:textbox id="txtKMNO2" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM" ReadOnly="True"
								value="2" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNM2" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNO5" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM" ReadOnly="True"
								value="5" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNM5" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM" ReadOnly="True"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                        <TD><asp:textbox id="txtKMNO2" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM"
								value="2" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNM2" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNO5" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM"
								value="5" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNM5" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD> 
					</TR>
					<TR>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD><asp:textbox id="txtKMNO3" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM" value="3"
								readOnly BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNM3" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM" readOnly
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNO6" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM" value="6"
								readOnly BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNM6" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM" readOnly
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                        <TD><asp:textbox id="txtKMNO3" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM" value="3"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNM3" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNO6" tabIndex="-1" runat="server" Width="12" CssClass="c-rNM" value="6"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox id="txtKMNM6" tabIndex="-1" runat="server" Width="195" CssClass="c-rNM"
								BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
				</TBODY></TABLE>
			<%'**********  ���q�l���(�K�X���)  ************%>
<%
''<TABLE style="LEFT: 490px; POSITION: absolute; TOP: 183px" cellSpacing="0" cellPadding="0">
''	<TBODY>
''		<TR>
''			<TD align="center" width="30" rowSpan="5">��<BR>
''				�q<BR>
''				�l<BR>
''				��<BR>
''				��</TD>
''			<TD align="center" colSpan="2">�K�X���</TD>
''			<TD></TD>
''			<TD align="center">������</TD>
''			<TD align="center">�w�j</TD>
''		</TR>
''		<TR>
''			<TD width="132"><asp:textbox class="c-rNM" id="txtGAS1_HINMEI" tabIndex="-1" runat="server" Width="130" readOnly
''					name="txtGAS1_HINMEI" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD><asp:textbox class="c-rNM" id="txtGAS1_DAISU" style="TEXT-ALIGN: right" tabIndex="-1" runat="server"
''					Width="40" readOnly name="txtGAS1_DAISU" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD align="right" Width="90">�{���x���� &nbsp;</TD>
''			<TD Width="80"><asp:textbox class="c-rNM" id="txtKONKAI_HAISO" tabIndex="-1" runat="server" Width="74" readOnly
''					name="txtZENKAI_HAISO" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD Width="100"><asp:textbox class="c-rNM" id="txtKONKAI_HAI_S" tabIndex="-1" runat="server" Width="100" readOnly
''					name="txtZENKAI_HAS_S" BorderWidth="1px" BorderStyle="Solid" style="TEXT-ALIGN: right"></asp:textbox></TD>
''		</TR>
''		<TR>
''			<TD><asp:textbox class="c-rNM" id="txtGAS2_HINMEI" tabIndex="-1" runat="server" Width="130" readOnly
''					name="txtGAS2_HINMEI" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD><asp:textbox class="c-rNM" id="txtGAS2_DAISU" style="TEXT-ALIGN: right" tabIndex="-1" runat="server"
''					Width="40" readOnly name="txtGAS2_DAISU" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD align="right">�{���x�ؑ� &nbsp;</TD>
''			<TD><asp:textbox class="c-rNM" id="txtKONKAI_HASEI" tabIndex="-1" runat="server" Width="74" readOnly
''					name="txtKONKAI_HAISO" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD><asp:textbox class="c-rNM" id="txtKONKAI_HAS_S" tabIndex="-1" runat="server" Width="100" readOnly
''					name="txtKONKAI_HAS_S" BorderWidth="1px" BorderStyle="Solid" style="TEXT-ALIGN: right"></asp:textbox></TD>
''		</TR>
''		<TR>
''			<TD width="130"><asp:textbox class="c-rNM" id="txtGAS3_HINMEI" tabIndex="-1" runat="server" Width="130" readOnly
''					name="txtGAS3_HINMEI" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD><asp:textbox class="c-rNM" id="txtGAS3_DAISU" style="TEXT-ALIGN: right" tabIndex="-1" runat="server"
''					Width="40" readOnly name="txtGAS3_DAISU" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD align="right">���[�^�^�� &nbsp;</TD>
''			<TD colSpan="3"><asp:textbox class="c-rNM" id="txtMET_KATA" tabIndex="-1" runat="server" Width="125" readOnly
''					name="txtMET_KATA" BorderWidth="1px" BorderStyle="Solid"></asp:textbox>&nbsp; 
''				�m�b�t&nbsp;<asp:textbox class="c-rNM" id="txtNCU_SET" tabIndex="-1" runat="server" Width="20" readOnly name="txtORNCU"
''					BorderStyle="Solid" BorderWidth="1px"></asp:textbox></TD>
''		</TR>
''		<TR>
''			<TD width="130"><asp:textbox class="c-rNM" id="txtGAS4_HINMEI" tabIndex="-1" runat="server" Width="130" readOnly
''					name="txtGAS4_HINMEI" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD><asp:textbox class="c-rNM" id="txtGAS4_DAISU" style="TEXT-ALIGN: right" tabIndex="-1" runat="server"
''					Width="40" readOnly name="txtGAS4_DAISU" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''			<TD align="right">���[�^���[�J�[&nbsp;</TD>
''			<TD colSpan="2"><asp:textbox class="c-rNM" id="txtMET_MAKER" tabIndex="-1" runat="server" Width="150" readOnly
''					name="txtMETMAKER" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
''		</TR>
''	</TBODY></TABLE>
%>
			<TABLE style="LEFT: 490px; POSITION: absolute; TOP: 183px" cellSpacing="0" cellPadding="0">
				<TBODY>
					<TR>
						<TD align="center" width="30" rowSpan="5">��<BR>
							�q<BR>
							�l<BR>
							��<BR>
							��</TD>
						<TD align="center" colSpan="2">�K�X���</TD>
					</TR>
					<TR>
						<TD width="132"><asp:textbox class="c-rNM" id="txtGAS1_HINMEI" tabIndex="-1" runat="server" Width="130"
								name="txtGAS1_HINMEI" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox class="c-rNM" id="txtGAS1_DAISU" style="TEXT-ALIGN: right" tabIndex="-1" runat="server"
								Width="40" name="txtGAS1_DAISU" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:textbox class="c-rNM" id="txtGAS2_HINMEI" tabIndex="-1" runat="server" Width="130"
								name="txtGAS2_HINMEI" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox class="c-rNM" id="txtGAS2_DAISU" style="TEXT-ALIGN: right" tabIndex="-1" runat="server"
								Width="40" name="txtGAS2_DAISU" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="130"><asp:textbox class="c-rNM" id="txtGAS3_HINMEI" tabIndex="-1" runat="server" Width="130"
								name="txtGAS3_HINMEI" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox class="c-rNM" id="txtGAS3_DAISU" style="TEXT-ALIGN: right" tabIndex="-1" runat="server"
								Width="40" name="txtGAS3_DAISU" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="130"><asp:textbox class="c-rNM" id="txtGAS4_HINMEI" tabIndex="-1" runat="server" Width="130"
								name="txtGAS4_HINMEI" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox class="c-rNM" id="txtGAS4_DAISU" style="TEXT-ALIGN: right" tabIndex="-1" runat="server"
								Width="40" name="txtGAS4_DAISU" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
				</TBODY></TABLE>
			<TABLE style="LEFT: 700px; POSITION: absolute; TOP: 183px" cellSpacing="0" cellPadding="0" style='display:none'>
				<TBODY>
					<TR>
						<TD></TD>
						<TD align="center">������</TD>
						<TD align="center">�w�j</TD>
					</TR>
					<TR>
						<TD align="right" Width="90">�{���x���� &nbsp;</TD>
						<TD Width="80"><asp:textbox class="c-rNM" id="txtKONKAI_HAISO" tabIndex="-1" runat="server" Width="74"
								name="txtZENKAI_HAISO" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD Width="100"><asp:textbox class="c-rNM" id="txtKONKAI_HAI_S" tabIndex="-1" runat="server" Width="100"
								name="txtZENKAI_HAS_S" BorderWidth="1px" BorderStyle="Solid" style="TEXT-ALIGN: right"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="right">�{���x�ؑ� &nbsp;</TD>
						<TD><asp:textbox class="c-rNM" id="txtKONKAI_HASEI" tabIndex="-1" runat="server" Width="74"
								name="txtKONKAI_HAISO" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
						<TD><asp:textbox class="c-rNM" id="txtKONKAI_HAS_S" tabIndex="-1" runat="server" Width="100"
								name="txtKONKAI_HAS_S" BorderWidth="1px" BorderStyle="Solid" style="TEXT-ALIGN: right"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="right">���[�^�^�� &nbsp;</TD>
						<TD colSpan="3"><asp:textbox class="c-rNM" id="txtMET_KATA" tabIndex="-1" runat="server" Width="125"
								name="txtMET_KATA" BorderWidth="1px" BorderStyle="Solid"></asp:textbox>&nbsp; 
							�m�b�t&nbsp;<asp:textbox class="c-rNM" id="txtNCU_SET" tabIndex="-1" runat="server" Width="20" name="txtORNCU"
								BorderStyle="Solid" BorderWidth="1px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="right">���[�^���[�J�[&nbsp;</TD>
						<TD colSpan="2"><asp:textbox class="c-rNM" id="txtMET_MAKER" tabIndex="-1" runat="server" Width="150"
								name="txtMETMAKER" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					</TR>
				</TBODY>
			</TABLE>
				
			<!-- 2009/01/09 T.Watabe add �{���x���ǉ� -->
			<%'**********  �{���x���  ************%>
			<%-- 2013/10/28 T.Ono �Ď����P2013��1 mod
            <TABLE style="LEFT: 700px; POSITION: absolute; TOP: 193px; BORDER: black 1px solid; Z-INDEX: 1; BACKGROUND-COLOR: #edffdb; border-style:dotted;" --%>
            <TABLE style="LEFT: 705px; POSITION: absolute; TOP: 182px; BORDER: black 1px solid; Z-INDEX: 1; BACKGROUND-COLOR: #edffdb; border-style:dotted;"
			cellSpacing="0" cellPadding="0" border='1'>
				<TBODY>
					<TR>
						<%-- 2013/10/28 T.Ono �Ď����P��1 mod
                        <TD colspan='6' align="center" valign="middle" height="30px"><font style="FONT-WEIGHT: bold; FONT-SIZE: 14px">&lt;&lt; �{���x��� &gt;&gt;</font></TD> --%>
                        <TD colspan='6' align="center" valign="middle" height="26px"><font style="FONT-WEIGHT: bold; FONT-SIZE: 14px">&lt;&lt; �{���x��� &gt;&gt;</font></TD>
					</TR>
					<TR>
						<TD width="20">&nbsp;</TD>
						<TD align="center">�e��</TD>
						<TD align="center">�{��</TD>
						<TD align="center">�e��</TD>
						<TD align="center">�\��</TD>
						<TD width="20">&nbsp;</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD align="right"><asp:textbox id="txtBONB1_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg&nbsp;</TD>
						<TD align="center"><asp:textbox id="txtBONB1_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></TD>
						<TD align="center"><asp:textbox id="txtBONB1_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="60px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg</TD>--%>
                        <TD align="right"><asp:textbox id="txtBONB1_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg&nbsp;</TD>
						<TD align="center"><asp:textbox id="txtBONB1_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></TD>
						<TD align="center"><asp:textbox id="txtBONB1_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="60px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg</TD>
						<TD align="center"><input id="chkBONB1_YOBI" disabled tabindex="-1" type="checkbox" name="chkBONB1_YOBI" runat="server"><input id="hdnBONB1_YOBI" type="hidden" name="hdnBONB1_YOBI" runat="server"></TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD align="right"><asp:textbox id="txtBONB2_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg&nbsp;</TD>
						<TD align="center"><asp:textbox id="txtBONB2_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></TD>
						<TD align="center"><asp:textbox id="txtBONB2_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="60px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg</TD>--%>
                        <TD align="right"><asp:textbox id="txtBONB2_KKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg&nbsp;</TD>
						<TD align="center"><asp:textbox id="txtBONB2_HON" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="35px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox></TD>
						<TD align="center"><asp:textbox id="txtBONB2_RKG" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="60px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;kg</TD>
						<TD align="center"><input id="chkBONB2_YOBI" disabled tabindex="-1" type="checkbox" name="chkBONB2_YOBI" runat="server"><input id="hdnBONB2_YOBI" type="hidden" name="hdnBONB2_YOBI" runat="server"></TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<%-- 2013/10/28 T.Ono �Ď����P2013��1
                        <TD colspan='6' align="center">&nbsp;</TD> --%>
                        <TD colspan='6' align="center" height="3px"></TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD colspan='2' align="right">�O��z����&nbsp;</TD>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD colspan='2' align="left"><asp:textbox id="txtZENKAI_HAISO" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</TD>--%>
                        <TD colspan='2' align="left"><asp:textbox id="txtZENKAI_HAISO" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;</TD> 
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD colspan='2' align="right">�O��w�j&nbsp;</TD>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD colspan='2' align="left"><asp:textbox id="txtZENKAI_HAI_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</TD>--%>
                        <TD colspan='2' align="left"><asp:textbox id="txtZENKAI_HAI_S" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="73px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM"></asp:textbox>&nbsp;m3&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD colspan='2' align="right">����z���\���&nbsp;</TD>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD colspan='2' align="left"><asp:textbox id="txtJIKAI_HAISO" tabindex="-1" runat="server" readonly="True" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></TD>--%>
                        <TD colspan='2' align="left"><asp:textbox id="txtJIKAI_HAISO" tabindex="-1" runat="server" width="75px" borderstyle="Solid"
							borderwidth="1px" cssclass="c-rNM"></asp:textbox></TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD colspan='2' align="right">�z��������̐���g�p��&nbsp;</TD>
                        <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
						<%--<TD colspan='2' align="left"><asp:textbox id="txtG_ZAIKO" style="TEXT-ALIGN: right" tabindex="-1" runat="server" readonly="True"
							width="64px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4716"></asp:textbox>&nbsp;kg</TD>--%>
                        <TD colspan='2' align="left"><asp:textbox id="txtG_ZAIKO" style="TEXT-ALIGN: right" tabindex="-1" runat="server"
							width="64px" borderstyle="Solid" borderwidth="1px" cssclass="c-rNM" designtimedragdrop="4716"></asp:textbox>&nbsp;kg</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<%-- 2013/10/28 T.Ono �Ď����P2013��1 del
                        <TD colspan='6' align="center" height="10px"></TD> --%>
					</TR>
				</TBODY>
			</TABLE>
			<%'**********  �d�b�A���P  ************%>
			<TABLE style="LEFT: 10px; POSITION: absolute; TOP: 265px" cellSpacing="0" cellPadding="0">
				<TR>
					<TD width="80">�A������</TD>
                    <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<TD width="350" colSpan="5"><asp:textbox class="c-rNM" id="txtTAITNM" tabIndex="-1" runat="server" Width="360" readOnly name="txtTAITNM"
							BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                    <TD width="350" colSpan="5"><asp:textbox class="c-rNM" id="txtTAITNM" tabIndex="-1" runat="server" Width="360" name="txtTAITNM"
							BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
				</TR>
				<TR>
                    <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<TD width="80">�d�b�A�����e</TD>
					<TD><asp:textbox class="c-rNM" id="txtTELRNM" tabIndex="-1" runat="server" Width="200" readOnly name="txtTELRNM"
							BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					<TD align="right" width="60">����&nbsp;</TD>
					<TD><asp:textbox class="c-rNM" id="txtTKIGNM" tabIndex="-1" runat="server" Width="140" readOnly name="txtTKIGNM"
							BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					<TD align="right" width="60">�쓮����&nbsp;</TD>
					<TD><asp:textbox class="c-rNM" id="txtTSADNM" tabIndex="-1" runat="server" Width="140" readOnly name="txtTSADNM"
							BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>--%>
                    <TD width="80">�d�b�A�����e</TD>
					<TD><asp:textbox class="c-rNM" id="txtTELRNM" tabIndex="-1" runat="server" Width="200" name="txtTELRNM"
							BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
					<%-- <TD align="right" width="60">����&nbsp;</TD> --%>
					<TD align="right" width="60">�������&nbsp;</TD>
					<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
					<TD><asp:textbox class="c-rNM" id="txtTKIGNM" tabIndex="-1" runat="server" Width="140" name="txtTKIGNM"
							BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
					<TD align="right" width="60">�쓮����&nbsp;</TD>
					<TD><asp:textbox class="c-rNM" id="txtTSADNM" tabIndex="-1" runat="server" Width="140" name="txtTSADNM"
							BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>
				</TR>
			</TABLE>
			<%'**********  �d�b�A���Q  ************%>
			<!-- <TABLE style="LEFT: 10px; POSITION: absolute; TOP: 310px" cellSpacing="0" cellPadding="0"> 2020/11/01 T.Ono mod 2020�Ď����P -->
            <TABLE style="LEFT: 10px; POSITION: absolute; TOP: 310px" width="980" cellSpacing="0" cellPadding="0">
<%--			2013/10/24 T.Ono �Ď����P2013��1 ������ 
                <TR>
					<TD width="30" rowSpan="3">���l</TD>
                    <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���-%>
					<%--<TD width="580"><asp:textbox class="c-rNM" id="txtTEL_MEMO1" tabIndex="-1" runat="server" Width="580" readOnly
							name="txtTEL_MEMO1" BorderWidth="1px" BorderStyle="Solid"></asp:textbox>&nbsp;</TD>-%>
                    <TD width="580"><asp:textbox class="c-rNM" id="txtTEL_MEMO1" tabIndex="-1" runat="server" Width="580"
							name="txtTEL_MEMO1" BorderWidth="1px" BorderStyle="Solid"></asp:textbox>&nbsp;</TD>
					<TD></TD>
					<TD rowspan="3" valign="top"></TD>
							
				</TR>
				<TR>
				    <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���-%>
					<%--<TD noWrap width="580"><asp:textbox class="c-rNM" id="txtTEL_MEMO2" tabIndex="-1" runat="server" Width="580" readOnly
							name="txtTEL_MEMO2" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>-%>
                    <TD noWrap width="580"><asp:textbox class="c-rNM" id="txtTEL_MEMO2" tabIndex="-1" runat="server" Width="580"
							name="txtTEL_MEMO2" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>        				
				</TR>
				<TR>
                    <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���-%>
					<%--<TD><asp:textbox class="c-rNM" id="txtFUK_MEMO" tabIndex="-1" runat="server" Width="580" readOnly
							name="txtFUK_MEMO" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD>-%>
                    <TD><asp:textbox class="c-rNM" id="txtFUK_MEMO" tabIndex="-1" runat="server" Width="580"
							name="txtFUK_MEMO" BorderWidth="1px" BorderStyle="Solid"></asp:textbox></TD> 
				</TR>--%>
                <TR>
					<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
					<%-- <TD width="30" >���l</TD> --%>
					<TD width="50" >�Ď��Z���^�Ή����e</TD>
					<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
                    <%-- 2020/11/01 T.Ono mod 2020�Ď����P --%>
                    <%-- <TD width="580"><textarea name="txtTEL_MEMO" id="txtTEL_MEMO" tabindex="-1" rows="3" cols="100" class="TELMEMO"
                                              style="background-color:Gainsboro;border-width:1px;border-style:Solid;" runat="server"></textarea> </TD> --%>
                    <TD width="580"><textarea name="txtTEL_MEMO" id="txtTEL_MEMO" tabindex="-1" rows="6" cols="100" class="TELMEMO"
                                              style="font-family: '�l�r �S�V�b�N',sans-serif; background-color:Gainsboro;border-width:1px;border-style:Solid;" runat="server"></textarea> </TD>
                </TR>
                <tr><td height="3px"></td></tr>
                <%-- 2013/10/24 T.Ono �Ď����P2013��1 ������ --%>

				<TR>
					<TD width="80" >���q�l�L��&nbsp;</TD>
                    <%--2012/04/06 .NET �g�p�ύX�ɂ��AReadOnly��VB����Attribute�ł���--%>
					<%--<TD><asp:textbox class="c-rNM" id="txtGENIN_KIJI" tabIndex="-1" runat="server" Width="580" readOnly--%>
<%--                2013/10/24 T.Ono �Ď����P2013��1 
                    <TD><asp:textbox class="c-rNM" id="txtGENIN_KIJI" tabIndex="-1" runat="server" Width="580"
							name="txtGENIN_KIJI" BorderWidth="1px" BorderStyle="Solid" ></asp:textbox>
					</TD>--%>
                    <%-- 2021/02/09 T.Ono mod 2020�Ď����P %>
                    <TD><asp:textbox class="c-rNM" id="txtGENIN_KIJI" tabIndex="-1" runat="server" Width="900"
							name="txtGENIN_KIJI" BorderWidth="1px" BorderStyle="Solid" style="font-size: 12px;"></asp:textbox>
					</TD> --%>
                    <TD><textarea name="txtGENIN_KIJI" id="txtGENIN_KIJI" rows="2" cols="100" tabindex="22" cssclass="c-rNM" 
                              style="font-family: '�l�r �S�V�b�N',sans-serif; font-size: 12px; width:920px; height:32px; overflow:hidden; word-break:break-all; background-color:Gainsboro;" 
                              runat="server"></textarea>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
			
			<%'**********  �Ή����e�P  ************%>
	        <!-- <SPAN style="Z-INDEX: 4; LEFT: 40px; POSITION: absolute; TOP: 425px" 2020/11/01 T.Ono mod 2020�Ď����P -->
            <SPAN style="Z-INDEX: 4; LEFT: 40px; POSITION: absolute; TOP: 453px; width:930px ">
				<TABLE cellSpacing="0" cellPadding="0">
                	<TR>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
						<%-- <TD width="80">��M�Ҏ���</TD> --%>
						<TD width="80">�o����t��</TD>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
                        <%-- 2013/08/26 T.Ono mod �Ď����P2013��1
                    	<TD width="360" colspan="3"><cc1:ctlcombo id="cboTSTANCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="1" runat="server" Width="360px" CssClass="cb-h"></cc1:ctlcombo></TD>--%>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
                        <%-- <TD width="360" colspan="3"><cc1:ctlcombo id="cboTSTANCD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
								tabIndex="1" runat="server" Width="360px" CssClass="cb-h"></cc1:ctlcombo></TD> --%>
						<TD width="360" colspan="3">
						<asp:textbox id="txtTSTAN_CD" tabIndex="-1" runat="server" cssclass="c-h" Width="280px" 
						BorderStyle="Solid" BorderWidth="1px"></asp:textbox><INPUT class="bt-KS" id="btnTSTAN_CD" onblur="fncFo(this,5)" 
						onfocus="fncFo(this,2)" onclick="return btnPopup_onclick('0');" tabIndex="1" type="button" value="��" name="btnTSTAN_CD" runat="server">
                        <INPUT id="hdnTSTAN_CD" type="hidden" name="hdnTSTAN_CD" runat="server"><INPUT id="hdnTSTAN_NM" type="hidden" name="hdnTSTAN_NM" runat="server"></TD>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
						<TD align="right" width="80">���� &nbsp;</TD>
                        <%-- 2013/08/26 T.Ono mod �Ď����P2013��1
						<TD width="150"><cc1:ctlcombo id="cboSTD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)"
								tabIndex="2" runat="server" Width="150" CssClass="cb-h"></cc1:ctlcombo></TD>--%>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
						<%-- <TD width="150"><cc1:ctlcombo id="cboSTD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
								tabIndex="2" runat="server" Width="150" CssClass="cb-h"></cc1:ctlcombo></TD> --%>
						<TD width="150"><cc1:ctlcombo id="cboSTD" onkeydown="fncFc(this)" onblur="fncFo(this,3)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
								tabIndex="2" runat="server" Width="150" CssClass="cb-h"></cc1:ctlcombo></TD>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
						<TD align="right" width="100">�o���Ή��� &nbsp;</TD>
						<TD width="150"><asp:textbox id="txtSYUTDNM" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="3" runat="server" Width="120" CssClass="c-fI" MaxLength="8"></asp:textbox></TD>
					</TR>
					<TR>
						<TD width="80">�Ή���M����</TD>
						<TD width="150"><asp:textbox id="txtTAIO_ST_DATE" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
								tabIndex="4" runat="server" Width="74" CssClass="c-f" MaxLength="8"></asp:textbox><asp:textbox id="txtTAIO_ST_TIME" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
								tabIndex="5" runat="server" Width="60" CssClass="c-f" MaxLength="6"></asp:textbox></TD>
						
						<!-- 2008/10/14 T.Watabe add -->
						<TD width="80" align="right">�o������ &nbsp;</TD>
						<TD width="150"><asp:textbox id="txtSDYMD" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
								tabIndex="6" runat="server" Width="74" CssClass="c-f" MaxLength="8"></asp:textbox><asp:textbox id="txtSDTIME" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
								tabIndex="7" runat="server" Width="60" CssClass="c-f" MaxLength="6"></asp:textbox></TD>
						
						<TD align="right" width="80">�������� &nbsp;</TD>
						<TD><asp:textbox id="txtTYAKYMD" onkeydown="fncFc(this)" onblur="fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
								tabIndex="8" runat="server" Width="74" CssClass="c-f" MaxLength="8"></asp:textbox><asp:textbox id="txtTYAKTIME" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
								tabIndex="9" runat="server" Width="60" CssClass="c-f" MaxLength="6"></asp:textbox></TD>
						<TD align="right" width="100">������������ &nbsp;</TD>
						<TD><asp:textbox id="txtSYOKANYMD" onkeydown="fncFc(this)" onblur="fncDateCheck1(),fncFo_date(this,1)" onfocus="fncFo_date(this,2)"
								tabIndex="10" runat="server" Width="74" CssClass="c-f" MaxLength="8"></asp:textbox><asp:textbox id="txtSYOKANTIME" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
								tabIndex="11" runat="server" Width="60" CssClass="c-f" MaxLength="6"></asp:textbox></TD> <%--2017/10/27 H.Mori mod 2017���P�J�� No6-1 id="txtSYOKANYMD"��onblur��fncDateCheck1��ǉ� --%>
					</TR>
					<TR>
						<TD width="80">�Ή�����</TD>
                        <%-- 2013/08/26 T.Ono mod �Ď����P2013��1
						<TD colspan="3"><cc1:ctlcombo id="cboSYUTDCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
								tabIndex="12" runat="server" Width="230px" CssClass="cb"></cc1:ctlcombo></TD>--%>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
						<%-- <TD colspan="3"><cc1:ctlcombo id="cboSYUTDCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
								tabIndex="12" runat="server" Width="230px" CssClass="cb"></cc1:ctlcombo></TD> --%>
						<TD colspan="3"><cc1:ctlcombo id="cboSYUTDCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
								tabIndex="12" runat="server" Width="230px" CssClass="cb"></cc1:ctlcombo></TD>
						<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
						<TD align="right" width="80">�s�ݎ��̑[�u &nbsp;</TD>
						<TD colSpan="3"><INPUT id="chkMETHEIKAKU" onkeydown="fncFc(this)" onblur="fncFo(this,6)" onfocus="fncFo(this,2)"
								tabIndex="13" type="checkbox" name="chkMETHEIKAKU" runat="server"><label for="chkMETHEIKAKU">���[�^�\���Ւf�ٕ~�m�F</label>
							<INPUT id="chkRUSUHAIRI" onkeydown="fncFc(this)" onblur="fncFo(this,6)" onfocus="fncFo(this,2)"
								tabIndex="14" type="checkbox" name="chkRUSUHAIRI" runat="server"><label for="chkRUSUHAIRI">�����\���̓\�t</label></TD>
					</TR>
				</TABLE>
				<table>
					<tr>
						<td width="1"></td>
					</tr>
				</table>
				<TABLE style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid"
					cellSpacing="0" cellPadding="4">
					<TBODY>
						<TR>
							<TD>
								<TABLE cellSpacing="0" cellPadding="0">
									<TR>
										<TD width="80">���q�l�̂��b</TD>
										<TD><input id="rdoHanasi1" onkeydown="fncFc(this)" onblur="fncFo(this,6)" onfocus="fncFo(this,2)"
												tabIndex="15" type="radio" name="rdoHanasi" runat="server"><label for="rdoHanasi1">�@�K�X�֘A</label>&nbsp;
                                            <%-- 2013/08/26 T.Ono mod �Ď����P2013��1
											<cc1:ctlcombo id="cboHanasi" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
												tabIndex="16" runat="server" Width="150" CssClass="cb"></cc1:ctlcombo></TD>--%>
											<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
											<%-- <cc1:ctlcombo id="cboHanasi" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
												tabIndex="16" runat="server" Width="150" CssClass="cb"></cc1:ctlcombo></TD>--%>												
											<cc1:ctlcombo id="cboHanasi" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
												tabIndex="16" runat="server" Width="150" CssClass="cb"></cc1:ctlcombo></TD>
											<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
										<TD><INPUT id="rdoHanasi2" onkeydown="fncFc(this)" onblur="fncFo(this,6)" onfocus="fncFo(this,2)"
												tabIndex="17" type="radio" name="rdoHanasi" runat="server"><label for="rdoHanasi2">�A���̑��i�K�X�ȊO�j</label></TD>
										<TD align="right" width="80">���b���e &nbsp;</TD>
										<TD width="150"><asp:textbox id="txtSDTBIK1" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
												tabIndex="18" runat="server" Width="380" CssClass="c-fI" MaxLength="35"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TBODY></TABLE>
			</SPAN>
			<%'**********  �����A�i�`�^���A�A����  ************%>
			<!-- <TABLE style="Z-INDEX: 4; LEFT: 40px; POSITION: absolute; TOP: 535px" cellSpacing="0" cellPadding="0"> 2013/07/30 T.Ono mod �������ʕ���Ή� -->
            <!-- <TABLE style="Z-INDEX: 4; LEFT: 40px; POSITION: absolute; TOP: 541px" cellSpacing="0" cellPadding="0"> 2020/11/01 T.Ono mod 2020�Ď����P -->
            <TABLE style="Z-INDEX: 4; LEFT: 40px; POSITION: absolute; TOP: 569px" cellSpacing="0" cellPadding="0">
				<TR>
                <%-- 2013/08/26 T.Ono mod �Ď����P2013��1
					<TD><cc1:ctlcombo id="cboKIGCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="19" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD>
					<TD colspan="2">&nbsp;&nbsp;<cc1:ctlcombo id="cboFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="23" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD>--%>
					<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
					<%-- <TD><cc1:ctlcombo id="cboKIGCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabIndex="19" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD>
					<TD colspan="2">&nbsp;&nbsp;<cc1:ctlcombo id="cboFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabIndex="23" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD> --%>							
					<TD><cc1:ctlcombo id="cboKIGCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabIndex="19" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD>
					<TD colspan="2">&nbsp;&nbsp;<cc1:ctlcombo id="cboFKICD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabIndex="23" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD>							
					<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
				</TR>
				<TR>
                    <%-- 2013/08/26 T.Ono mod �Ď����P2013��1
					<TD width="150"><cc1:ctlcombo id="cboSADCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="20" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD>--%>
					<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 START --%>
					<%-- <TD width="150"><cc1:ctlcombo id="cboSADCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabIndex="20" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD> --%>
					<TD width="150"><cc1:ctlcombo id="cboSADCD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onmousedown="fncFo(this,2)" onfocus="fncFo(this,2)" onChange="fncSetFocus()"
							tabIndex="20" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD>
					<%-- 2014/10/22 H.Hosoda mod 2014���P�J�� No11 END --%>
					<TD width="170">&nbsp;&nbsp;�i�`�^���A�̘A������</TD>
					<TD width="70" align="center">�A������</TD>
				</TR>
				<TR>
					<%	
' 2008/10/14 T.Watabe edit
'<TD><cc1:ctlcombo id="cboASECD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
'		tabIndex="21" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD>
					%>
					<TD><INPUT id="hdnASECD" type="hidden" name="hdnASECD" runat="server"></TD>
					
					<TD align="right"><asp:textbox id="txtJAKENREN" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="24" runat="server" Width="150" CssClass="c-fI" MaxLength="8"></asp:textbox></TD>
					<TD align="center"><asp:textbox id="txtRENTIME" onkeydown="fncFc(this)" onblur="fncFo_time(this,1)" onfocus="fncFo_time(this,2)"
							tabIndex="25" runat="server" Width="60" CssClass="c-f" MaxLength="6"></asp:textbox></TD>
				</TR>
				<TR>
					<%  
' 2008/10/14 T.Watabe edit
'<TD><cc1:ctlcombo id="cboSTACD" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
'	tabIndex="22" runat="server" Width="170" CssClass="cb"></cc1:ctlcombo></TD> 
					%>
					<TD><INPUT id="hdnSTACD" type="hidden" name="hdnSTACD" runat="server"></TD> 
					
					<TD align="right" colSpan="2">�ȈՃK�X���̑ݗ^&nbsp;<INPUT id="chkKIGUTAIYO" onkeydown="fncFc(this)" onblur="fncFo(this,6)" onfocus="fncFo(this,2)"
								tabIndex="26" type="checkbox" name="chkKIGUTAIYO" runat="server"><label for="chkKIGUTAIYO">�L</label>&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
			</TABLE>
			<%'**********  �_���P  ************%>
			<!-- <TABLE class="W" style="Z-INDEX: 4; LEFT: 450px; POSITION: absolute; TOP: 535px" cellSpacing="0" 2013/07/30 T.Ono mod �������ʕ���Ή� -->
            <!-- <TABLE class="W" style="Z-INDEX: 4; LEFT: 450px; POSITION: absolute; TOP: 541px" cellSpacing="0" cellPadding="0"> 2020/11/01 T.Ono mod 2020�Ď����P -->
            <TABLE class="W" style="Z-INDEX: 4; LEFT: 450px; POSITION: absolute; TOP: 569px" cellSpacing="0" cellPadding="0">
				<TR>
					<TD width="120">&nbsp;�@�K�X�R��_��<BR>
						&nbsp;�i�����j</TD>
					<TD><INPUT id="rdoGASMUMU1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="26" type="radio" name="rdoGASMUMU" runat="server" onclick="fncGasu_Change(1)"><label for="rdoGASMUMU1">�L</label><INPUT id="rdoGASMUMU2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="27" type="radio" name="rdoGASMUMU" runat="server" onclick="fncGasu_Change(2)"><label for="rdoGASMUMU2">��</label><BR>
						�i<INPUT id="rdoGASMUMU_K" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="27" type="radio" name="rdoGASGEN" runat="server"><label for="rdoGASMUMU_K">�K�X���</label><INPUT id="rdoGASMUMU_H" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="28" type="radio" name="rdoGASGEN" runat="server"><label for="rdoGASMUMU_H">�z��</label>�j</TD>
				</TR>
				<TR>
					<TD width="120">&nbsp;�A�K�X�؂�m�F</TD>
					<TD><INPUT id="rdoGASUGUMU1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="29" type="radio" name="rdoGASUGUMU" runat="server"><label for="rdoGASUGUMU1">�L</label><INPUT id="rdoGASUGUMU2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="30" type="radio" name="rdoGASUGUMU" runat="server"><label for="rdoGASUGUMU2">��</label></TD>
				</TR>
				<TR>
					<TD width="120">&nbsp;�C�S���z�[�X����</TD>
					<TD><INPUT id="rdoHOSKOKAN1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="31" type="radio" name="rdoHOSKOKAN" runat="server"><label for="rdoHOSKOKAN1">���{</label><INPUT id="rdoHOSKOKAN2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="32" type="radio" name="rdoHOSKOKAN" runat="server"><label for="rdoHOSKOKAN2">�����{</label></TD>
				</TR>
			</TABLE>
			<%'**********  �_���Q  ************%>
			<!-- <TABLE style="Z-INDEX: 4; LEFT: 755px; POSITION: absolute; TOP: 538px" cellSpacing="0" cellPadding="0"> 2020/11/01 T.Ono mod 2020�Ď����P -->
            <TABLE style="Z-INDEX: 4; LEFT: 755px; POSITION: absolute; TOP: 566px" cellSpacing="0" cellPadding="0">
				<TR>
					<TD align="right">���[�^</TD>
					<TD><INPUT id="rdoMETYOINA1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="33" type="radio" name="rdoMETYOINA" runat="server"><label for="rdoMETYOINA1">��</label><INPUT id="rdoMETYOINA2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="34" type="radio" name="rdoMETYOINA" runat="server"><label for="rdoMETYOINA2">��</label></TD>
				</TR>
				<TR>
					<TD align="right">������</TD>
					<TD><INPUT id="rdoTYOUYOINA1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="35" type="radio" name="rdoTYOUYOINA" runat="server"><label for="rdoTYOUYOINA1">��</label><INPUT id="rdoTYOUYOINA2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="36" type="radio" name="rdoTYOUYOINA" runat="server"><label for="rdoTYOUYOINA2">��</label></TD>
				</TR>
				<TR>
					<TD align="right">�e��E���ԃo���u</TD>
					<TD><INPUT id="rdoVALYOINA1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="37" type="radio" name="rdoVALYOINA" runat="server"><label for="rdoVALYOINA1">��</label><INPUT id="rdoVALYOINA2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)" 
							tabIndex="38" type="radio" name="rdoVALYOINA" runat="server"><label for="rdoVALYOINA2">��</label></TD>
				</TR>
				<TR>
					<%-- 2017/02/17 W.GANEKO MOD 2016�Ď����P ��7 --%>
					<%-- <TD align="right">�z�r�C��</TD> --%>
					<TD align="right">���r�C��</TD>
					<TD><INPUT id="rdoKYUHAIUMU1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="39" type="radio" name="rdoKYUHAIUMU" runat="server"><label for="rdoKYUHAIUMU1">�L</label><INPUT id="rdoKYUHAIUMU2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="40" type="radio" name="rdoKYUHAIUMU" runat="server"><label for="rdoKYUHAIUMU2">��</label></TD>
				</TR>
				<TR>
					<TD align="right">�b�n�Z�x</TD>
					<TD><INPUT id="rdoCOYOINA1" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="41" type="radio" name="rdoCOYOINA" runat="server"><label for="rdoCOYOINA1">��</label>
						<INPUT id="rdoCOYOINA2" onkeydown="fncFc(this)" onblur="fncFo(this,4)" onfocus="fncFo(this,2)"
							tabIndex="42" type="radio" name="rdoCOYOINA" runat="server"><label for="rdoCOYOINA2">��</label></TD>
				</TR>
			</TABLE>
			<%'**********  �Ō�̔��l  ************%>
			<!-- <TABLE style="Z-INDEX: 4; LEFT: 10px; POSITION: absolute; TOP: 630px" cellSpacing="0" cellPadding="0"> 2020/11/01 T.Ono mod 2020�Ď����P -->
            <TABLE style="Z-INDEX: 4; LEFT: 10px; POSITION: absolute; TOP: 658px" cellSpacing="0" cellPadding="0">
				<TR>
					<TD align="left">�o������</TD>
				</TR>
				<TR>
					<TD align="left">���e/��</TD>
				</TR>
			</TABLE>
			<!-- <TABLE style="Z-INDEX: 4; LEFT: 70px; POSITION: absolute; TOP: 625px" cellSpacing="0" cellPadding="0">�@2020/11/01 T.Ono mod 2020�Ď����P -->
            <TABLE style="Z-INDEX: 4; LEFT: 70px; POSITION: absolute; TOP: 653px" cellSpacing="0" cellPadding="0">
				<%-- 2013/08/26 T.Ono mod �Ď����P2013��1 --%>
<%--            <TR>
					<TD><asp:textbox id="txtSDTBIK2" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="43" runat="server" Width="630" CssClass="c-fI" MaxLength="50"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="txtSNTTOKKI" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="44" runat="server" Width="630" CssClass="c-fI" MaxLength="50"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="txtSDTBIK3" onkeydown="fncFc(this)" onblur="fncFo(this,1)" onfocus="fncFo(this,2)"
							tabIndex="45" runat="server" Width="630" CssClass="c-fI" MaxLength="50"></asp:textbox></TD>
				</TR>--%>
                <TR>
					<TD>
						<%-- 2014/12/15 T.Ono mod START --%>
                        <%-- 2014/10/22 H.Hosoda mod START --%>
                        <%-- <textarea name="txtSDTBIK" id="txtSDTBIK" tabindex="43" rows="3" cols="100" class="TELMEMO" 
                                    onblur="fncbyteCheck1(this,100),fncFo(this,1)" onfocus="fncFo(this,2)" runat="server"></textarea> --%>
						<%-- <textarea name="txtSDTBIK" id="txtSDTBIK" tabindex="43" rows="3" cols="100"
									style="font-family: '�l�r �S�V�b�N',sans-serif; font-size: 13px; width:610px; height:50px; overflow:hidden; word-break:break-all; IME-MODE: active;" 
									onblur="fncbyteCheck1(this,100),fncFo(this,1)" onfocus="fncFo(this,2)" runat="server"></textarea> --%>
                        <textarea name="txtSDTBIK" id="txtSDTBIK" tabindex="43" rows="3" cols="100"
									style="font-family: '�l�r �S�V�b�N',sans-serif; font-size: 12px; width:610px; height:50px; overflow:hidden; word-break:break-all; IME-MODE: active;" 
									onblur="fncbyteCheck1(this,100),fncFo(this,1)" onfocus="fncFo(this,2)" runat="server"></textarea>
						<%-- 2014/10/22 H.Hosoda mod END --%>
                        <%-- 2014/12/15 T.Ono mod END --%>
                        <INPUT id="hdnSDTBIK2" type="hidden" name="hdnSDTBIK2" runat="server">
                        <INPUT id="hdnSNTTOKKI" type="hidden" name="hdnSNTTOKKI" runat="server">
                        <INPUT id="hdnSDTBIK3" type="hidden" name="hdnSDTBIK3" runat="server">
                    </TD>
				</TR>
			</TABLE>
			<%'**********  �g2  ************%>
			<%' BACKGROUND-COLOR: #e0ffff %>
			<%-- 2020/11/01 T.Ono mod 2020�Ď����P TOP: 402px; �� TOP: 434px; --%>
            <TABLE style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; Z-INDEX: 1; LEFT: 5px; BORDER-LEFT: black 1px solid; WIDTH: 990px; BORDER-BOTTOM: black 1px solid; POSITION: absolute; TOP: 434px; HEIGHT: 290px; BACKGROUND-COLOR: #dbffff"
				cellSpacing="0" cellPadding="3">
				<TR>
					<TD vAlign="top" align="center"><font style="FONT-WEIGHT: bold; FONT-SIZE: 14px">�ً}�Ή����C�����́i�����񍐁j</font></TD>
				</TR>
			</TABLE>
			<%'**********  �g3  ************%>
			<!-- <TABLE class="W" style="Z-INDEX: 3; LEFT: 705px; WIDTH: 240px; POSITION: absolute; TOP: 535px; HEIGHT: 105px" 2013/07/30 T.Ono mod �������ʕ���Ή� -->
            <!-- <TABLE class="W" style="Z-INDEX: 3; LEFT: 705px; WIDTH: 240px; POSITION: absolute; TOP: 541px; HEIGHT: 105px"
				cellSpacing="0" cellPadding="3"> 2020/11/01 T.Ono mod 2020�Ď����P -->
            <TABLE class="W" style="Z-INDEX: 3; LEFT: 705px; WIDTH: 240px; POSITION: absolute; TOP: 559px; HEIGHT: 105px"
				cellSpacing="0" cellPadding="3">
				<TR>
					<TD valign="top" align="left">�B���̑��_������</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
