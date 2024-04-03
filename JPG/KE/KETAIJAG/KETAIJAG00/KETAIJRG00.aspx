<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KETAIJRG00.aspx.vb" Inherits="JPG.KETAIJAG00.KETAIJRG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>対応履歴照会</title>
		<script language="JavaScript">
			<%-- 2015/11/30 H.Mori mod 2015改善開発 No3 START --%>
            <%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
			<%-- window.resizeTo(990,695); --%>
			<%-- window.resizeTo(990,760); --%>
			<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
            <%-- // 2022/12/20 MOD START Y.ARAKAKI 2022更改No10 _Edgeウィンドウサイズ調整対応 --%>
            <%-- window.resizeTo(990, 780);  --%>
            window.resizeTo(990, 820); 
            <%-- // 2022/12/20 MOD END   Y.ARAKAKI 2022更改No10 _Edgeウィンドウサイズ調整対応 --%>
            <%-- 2015/11/30 H.Mori mod 2015改善開発 No3 END --%>
			<%-- window.moveTo(25,25); --%>
            <%-- 2021/10/01 saka mod 2021年度監視改善①対応履歴照会の電話対応メモ欄を拡張 --%>
		</script>
	<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
		<%-- <style>.POSS_WAKU1 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 37px; HEIGHT: 145px }
	.POSS_DENWA1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 47px }
	.POSS_DENTI1 { Z-INDEX: 2; LEFT: 310px; POSITION: absolute; TOP: 33px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU2 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 195px; HEIGHT: 120px }
	.POSS_SYUDO1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 202px }
	.POSS_SYUTI1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 188px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU3 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 335px; HEIGHT: 145px }
	.POSS_DENWA2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 345px }
	.POSS_DENTI2 { Z-INDEX: 2; LEFT: 310px; POSITION: absolute; TOP: 330px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU4 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 490px; HEIGHT: 123px }
	.POSS_SYUDO2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 500px }
	.POSS_SYUTI2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 485px; BACKGROUND-COLOR: cornsilk }
	.POSS_BORDER { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; POSITION: absolute; TOP: 323px }
	.POSS_BUTTON { LEFT: 300px; POSITION: absolute; TOP: 620px } --%>
     <%-- 2015/11/30 H.Mori mod 2015改善開発 No3 START --%>
		<%-- <style>.POSS_WAKU1 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 37px; HEIGHT: 145px }
	.POSS_DENWA1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 47px }
	.POSS_DENTI1 { Z-INDEX: 2; LEFT: 310px; POSITION: absolute; TOP: 34px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU2 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 195px; HEIGHT: 147px }
	.POSS_SYUDO1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 202px;
                right: 140px;
            }
	.POSS_SYUTI1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 190px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU3 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 360px; HEIGHT: 145px }
	.POSS_DENWA2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 370px }
	.POSS_DENTI2 { Z-INDEX: 2; LEFT: 310px; POSITION: absolute; TOP: 356px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU4 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 515px; HEIGHT: 148px }
	.POSS_SYUDO2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 525px }
	.POSS_SYUTI2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 511px; BACKGROUND-COLOR: cornsilk }
	.POSS_BORDER { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; POSITION: absolute; TOP: 348px }
	.POSS_BUTTON { LEFT: 300px; POSITION: absolute; TOP: 670px } --%>
	<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>

<%-- 2021/10/01 2021年度改善① sakaUPD Start 
        <style>.POSS_WAKU1 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 37px; HEIGHT: 160px }

	.POSS_DENWA1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 47px; }
	.POSS_DENTI1 { Z-INDEX: 2; LEFT: 310px; POSITION: absolute; TOP: 34px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU2 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 209px; HEIGHT: 148px }
	.POSS_SYUDO1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 217px;
                right: 140px;
            }
	.POSS_SYUTI1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 205px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU3 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 375px; HEIGHT: 160px }
	.POSS_DENWA2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 385px }
	.POSS_DENTI2 { Z-INDEX: 2; LEFT: 310px; POSITION: absolute; TOP: 372px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU4 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 548px; HEIGHT: 148px }
	.POSS_SYUDO2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 558px }
	.POSS_SYUTI2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 544px; BACKGROUND-COLOR: cornsilk }
	.POSS_BORDER { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; POSITION: absolute; TOP: 363px }
	.POSS_BUTTON { LEFT: 300px; POSITION: absolute; TOP: 705px }
	.POSS_KEIHO1 { POSITION: absolute; TOP: 37px }
	.POSS_KEIHO2 { POSITION: absolute; TOP: 375px }    2021/10/01 2021年度改善① sakaUPD 中間 --%>

        <style>.POSS_WAKU1 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 37px; HEIGHT: 178px }

	.POSS_DENWA1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 45px; }
	.POSS_DENTI1 { Z-INDEX: 2; LEFT: 310px; POSITION: absolute; TOP: 32px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU2 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 219px; HEIGHT: 139px }
	.POSS_SYUDO1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 227px;
                right: 140px;
            }
	.POSS_SYUTI1 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 215px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU3 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 365px; HEIGHT: 181px }
	.POSS_DENWA2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 375px }
	.POSS_DENTI2 { Z-INDEX: 2; LEFT: 310px; POSITION: absolute; TOP: 362px; BACKGROUND-COLOR: cornsilk }
	.POSS_WAKU4 { Z-INDEX: 1; LEFT: 290px; WIDTH: 650px; POSITION: absolute; TOP: 549px; HEIGHT: 139px }
	.POSS_SYUDO2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 559px }
	.POSS_SYUTI2 { Z-INDEX: 2; LEFT: 300px; POSITION: absolute; TOP: 546px; BACKGROUND-COLOR: cornsilk }
	.POSS_BORDER { BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; POSITION: absolute; TOP: 359px }
	.POSS_BUTTON { LEFT: 300px; POSITION: absolute; TOP: 693px }
	.POSS_KEIHO1 { POSITION: absolute; TOP: 37px }
    .POSS_KEIHO2 { POSITION: absolute; TOP: 367px } 
/*-- 2021/10/01 2021年度改善① sakaUPD End --*/

	/* 2015/11/30 H.Mori mod 2015改善開発 No3 END*/ 
	/* 2013/10/24 T.Ono 監視改善2013№1*/
/*-- 2021/10/01 2021年度改善① sakaUPD&ADD start */

	.TELMEMO{
	  font-family: "ＭＳ ゴシック",sans-serif;
	  font-size: 12px; 
	  width:610px;
	 /* height:50px;*/
	  height:78px;
	  overflow:hidden; /* ｽｸﾛｰﾙﾊﾞｰ消す */
	  word-break:break-all; /* IEのみ、単語途中でも改行 */
	  background-color:Gainsboro;
	  border-width:1px;
	  border-style:Solid;
	}
 /*-- 2021/10/01 2021年度改善① sakaADD STDMEMOは完全追加 */
	.STDMEMO{
	  font-family: "ＭＳ ゴシック",sans-serif;
	  font-size: 12px; 
	  width:610px;
	  height:40px;
	  overflow:hidden; /* ｽｸﾛｰﾙﾊﾞｰ消す */
	  word-break:break-all; /* IEのみ、単語途中でも改行 */
	  background-color:Gainsboro;
	  border-width:1px;
	  border-style:Solid;
	}
/*-- 2021/10/01 2021年度改善① sakaUPD&ADD End  --*/
	        .style1
            {
                height: 13px;
            }
	        .style2
            {
                height: 17px;
            }
	</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<INPUT id="hdnMyAspx" type="hidden" name="hdnMyAspx" runat="server"><INPUT id="hdnRownum" type="hidden" name="hdnRownum" runat="server"><INPUT id="hdnRIREKI_KURACD" type="hidden" name="hdnRIREKI_KURACD" runat="server"><INPUT id="hdnRIREKI_ACBCD" type="hidden" name="hdnRIREKI_ACBCD" runat="server"><INPUT id="hdnRIREKI_USER_CD" type="hidden" name="hdnRIREKI_USER_CD" runat="server">
			<asp:label id="lblScript" runat="server"></asp:label><BR>
			<TABLE cellSpacing="0" cellPadding="2" width="930">
				<TR>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD class="TITLE" vAlign="middle" width="200">需要家履歴一覧</TD> --%>
					<TD class="TITLE" vAlign="middle" width="200">お客様履歴一覧</TD>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
					<TD width="250">お客様コード&nbsp;
						<asp:textbox id="txtJUYOKA" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="160px" ReadOnly="True"></asp:textbox></TD>
					<%-- <TD width="350">お客様氏名&nbsp; --%><%-- 2015/01/21 T.Ono mod 2014改善開発 No3 START --%>
					<TD width="350">お客様名&nbsp;
						<asp:textbox id="txtJUYOKANAME" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="250px" ReadOnly="True"></asp:textbox></TD>
					<TD align="right" width="130"><INPUT language="javascript" class="bt-JIK" id="btnPrint" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="return btnPrint_onclick();" tabIndex="96" type="button" value="印刷" name="btnExit">
						<INPUT language="javascript" class="bt-JIK" id="btnExit" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="return btnExit_onclick(); __doPostBack('btnExit','')" tabIndex="96" type="button"
							value="終了" name="btnExit">
					</TD>
				</TR>
			</TABLE>
			<%'*******警報１*******%>
			<TABLE class="POSS_KEIHO1" cellSpacing="0" cellPadding="0">
				<TR>
					<TD colSpan="3"><asp:textbox id="txtHATYMD1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="143px" ReadOnly="True"></asp:textbox>&nbsp;<asp:textbox id="txtTMSKB_NAI1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="74px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
                    <%-- 2015/11/19 H.Mori mod 2015改善開発 No3 START --%> 
                    <%-- <TD width="130">発生区分&nbsp; --%>
					<TD width="125">発生区分&nbsp;
                    <%-- 2015/11/19 H.Mori mod 2015改善開発 No3 END --%>
						<asp:textbox id="txtHATKBN1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="74px" ReadOnly="True"></asp:textbox></TD>
					<%-- 2015/11/19 H.Mori mod 2015改善開発 No3 START --%> 
                    <%--
                    <TD width="60">事象数
					</TD>
                    <TD width="30"><asp:textbox id="txtKEIHOSU1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="24px" ReadOnly="True"></asp:textbox></TD>  --%>
                    <TD width="45">メータ値
					</TD>
					<TD width="30"><asp:textbox id="txtKENSIN1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="68px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/19 H.Mori mod 2015改善開発 No3 END --%>
				</TR>
				<TR>
					<TD>対応区分&nbsp;
						<asp:textbox id="txtTAIOKBN1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="74px" ReadOnly="True"></asp:textbox></TD>
					<TD>流量区分
					</TD>
					<TD><asp:textbox id="txtRYURYO1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="24px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><FONT face="MS UI Gothic"><asp:textbox id="txtMSG1_1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
								Width="264px" ReadOnly="True"></asp:textbox></FONT></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG1_2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG1_3" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG1_4" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG1_5" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG1_6" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD align="right" colSpan="3">緊急対応日時 --%>
					<TD align="right" colSpan="3">対応完了日時
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
						<asp:textbox id="txtSYOYMD1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="143px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<%-- 2014/12/01 H.Hosoda add 2014改善開発 No3 START --%>
				<TR>
					<TD colSpan="3" height="13">メモ欄
					</TD>
				</TR>
				<%-- 2014/12/01 H.Hosoda add 2014改善開発 No3 END --%>
				<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
				<%-- <TR>
					<TD colSpan="3" height="75"></TD>
				</TR> --%>
				<TR>
					<TD colSpan="3" height="75px">
					<textarea name="txtFAX_REN_1" id="txtFAX_REN_1" tabindex="-1" rows="3" cols="100" class="TELMEMO" style="width:264px;height:70px;" readonly></textarea></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="12px"></TD>
				</TR>
				<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
			</TABLE>
			<%'*******電話対応 枠*******%>
			<TABLE class="W POSS_WAKU1" cellSpacing="0" cellPadding="0">
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<%'*******電話対応*******%>
			<TABLE class="POSS_DENWA1" cellSpacing="0" cellPadding="0">
				<TR>
					<TD>担当者名&nbsp;</TD>
					<TD><asp:textbox id="txtTKTANCD_NM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
					<TD>連絡相手&nbsp;</TD>
					<TD><asp:textbox id="txtTAITNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
				</TR>
                <TR>
                <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%> 
					<TD width="80">復帰対応状況&nbsp;</TD>
                    <TD width="240"><asp:textbox id="txtTFKINM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
					<TD width="65">電話内容&nbsp;</TD>
					<TD width="265"><asp:textbox id="txtTELRNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
                <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%> 
                </TR>
				<TR>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD>器具原因&nbsp;</TD> --%>
					<TD>原因器具&nbsp;</TD>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
					<TD><asp:textbox id="txtTKIGNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
					<%-- 2015/11/20 H.Mori del 2015改善開発 No3
                    <TD>作動原因&nbsp;</TD>
					<TD><asp:textbox id="txtTSADNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%>
                    <TD>最終架電先&nbsp;</TD>
                    <TD><asp:textbox id="txtKOK_TELNO1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%>
				</TR>
				<TR><%-- 2015/11/20 H.Mori del 2015改善開発 No3
					<TD>電話内容&nbsp;</TD>
					<TD><asp:textbox id="" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>  --%>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%>
                    <TD>作動原因&nbsp;</TD>
					<TD><asp:textbox id="txtTSADNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%>
					<TD></TD>
					<TD></TD>
				</TR>
<%--			2013/10/24 T.Ono 監視改善2013№1 ▼▼▼
	            <TR>
					<TD>&nbsp;</TD>
					<TD colSpan="3"><asp:textbox id="txtTEL_MEMO1_1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="496px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD colSpan="3"><asp:textbox id="txtTEL_MEMO2_1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="496px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD height="22">&nbsp;</TD>
					<TD colSpan="3" height="22"><asp:textbox id="txtFUK_MEMO1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="496px" ReadOnly="True"></asp:textbox></TD>
				</TR>--%>
	            <TR>
					<TD colspan="4" rowspan = "3">&nbsp;&nbsp;
                     <textarea name="txtTEL_MEMO_1" id="txtTEL_MEMO_1" tabindex="-1" rows="3" cols="100" class="TELMEMO" runat="server" readonly></textarea> </TD>
				</TR>

                <%-- 2013/10/24 T.Ono 監視改善2013№1 ▲▲▲ --%>
			</TABLE>
			<%'*******電話対応 タイトル*******%>
			<SPAN class="POSS_DENTI1">&nbsp;&nbsp;***&nbsp;電&nbsp;話&nbsp;対&nbsp;応&nbsp;***&nbsp;&nbsp;</SPAN>
			<%'*******出動対応１ 枠*******%>
			<TABLE class="W POSS_WAKU2" cellSpacing="0" cellPadding="0">
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<%'*******出動対応*******%>
			<TABLE class="POSS_SYUDO1" cellSpacing="0" cellPadding="0">
				<TR>
                    <%-- 2015/12/01 H.Mori mod 2015改善開発 No3 START 修正した電話対応と幅を合わせる --%>
                    <%-- 2015/01/20 T.Ono mod 2014改善開発 No3 ｽｸﾛｰﾙﾊﾞｰが出てしまうので幅を指定する START --%>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD height="24">担当者名&nbsp;</TD> --%>
					<%-- <TD height="24">出動対応者&nbsp;</TD> --%>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
					<%--  <TD height="24"><FONT face="MS UI Gothic"><asp:textbox id="txtTSTANNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
								BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></FONT></TD> --%>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD height="24">連絡相手&nbsp;</TD> --%>
					<%-- <TD height="24">対応相手&nbsp;</TD> --%>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
					<%-- <TD height="24"><asp:textbox id="txtAITNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%--  <TD width="60" height="24">出動対応者&nbsp;</TD>
					<TD width="264" height="24"><FONT face="MS UI Gothic"><asp:textbox id="txtTSTANNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
								BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></FONT></TD>
					<TD width="47" height="24">対応相手&nbsp;</TD>
					<TD width="278" height="24"><asp:textbox id="txtAITNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/01/20 T.Ono mod 2014改善開発 No3 幅を指定する END --%>
                    <TD width="80" height="24">出動対応者&nbsp;</TD>
					<TD width="240" height="24"><FONT face="MS UI Gothic"><asp:textbox id="txtTSTANNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
								BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></FONT></TD>
					<TD width="65" height="24">対応相手&nbsp;</TD>
					<TD width="265" height="24"><asp:textbox id="txtAITNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/12/01 H.Mori mod 2015改善開発 No3 END --%>
                </TR>
				<TR>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD>器具原因&nbsp;</TD> --%>
					<TD>原因器具&nbsp;</TD>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END--%>
					<TD><asp:textbox id="txtKIGNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori del 2015改善開発 No3 
					<TD>作動原因&nbsp;</TD>
					<TD><asp:textbox id="txtSADNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%>
                    <TD>復帰操作&nbsp;</TD>
					<TD><asp:textbox id="txtFKINM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%>
				</TR>
				<%-- 2014/12/01 H.Hosoda del 2014改善開発 No3 START --%>
				<%-- <TR>
					<TD height="22">その他原因&nbsp;</TD>
					<TD height="22"><asp:textbox id="txtSTANM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
					<TD height="22">センサ原因&nbsp;</TD>
					<TD height="22"><asp:textbox id="txtASENM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
				</TR> --%>
				<%-- 2014/12/01 H.Hosoda del 2014改善開発 No3 END --%>
				<TR><%-- 2015/11/20 H.Mori del 2015改善開発 No3 
					<TD>復帰操作&nbsp;</TD>
					<TD><asp:textbox id="txtFKINM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%>
                    <TD>作動原因&nbsp;</TD>
					<TD><asp:textbox id="txtSADNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%>
					<TD></TD>
					<TD></TD>
				</TR>
				<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
				<%-- <TR>
					<TD>備考１&nbsp;</TD>
					<TD colSpan="3"><asp:textbox id="txtSDTBIK2_1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="496px" ReadOnly="True"></asp:textbox></TD>
				</TR> --%>
				<TR height="18px">
					<TD colSpan="4">出動結果内容/報告&nbsp;</TD>
				</TR>
				<TR>
					<TD colspan="4" rowspan = "3">&nbsp;&nbsp;
				<%'**2021/10/01 2021年度改善① sakaUPD Start	<textarea name="txtSDTBIK2_1" id="txtSDTBIK2_1" tabindex="-1" rows="3" cols="100" class="TELMEMO" readonly=""></textarea> </TD> **%>
                    <textarea name="txtSDTBIK2_1" id="txtSDTBIK2_1" tabindex="-1" rows="3" cols="100" class="STDMEMO" readonly=""></textarea> </TD>
                <%'**2021/10/01 2021年度改善① sakaUPD End **%>
				</TR>
				<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
			</TABLE>
			<%'*******出動対応１ タイトル*******%>
			<SPAN class="POSS_SYUTI1">&nbsp;&nbsp;***&nbsp;出&nbsp;動&nbsp;対&nbsp;応&nbsp;***&nbsp;&nbsp;</SPAN>
			<%'*******分割線*******%>
			<HR class="POSS_BORDER">
			<%'*******警報２*******%>
            <%-- 2015/11/30 H.Mori add 2015改善開発 No3 START --%>
			<%-- <TABLE cellSpacing="0" cellPadding="0"> --%> 
            <TABLE class="POSS_KEIHO2" cellSpacing="0" cellPadding="0" >
            <%-- 2015/11/30 H.Mori add 2015改善開発 No3 END --%>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtHATYMD2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="143px" ReadOnly="True"></asp:textbox>&nbsp;<asp:textbox id="txtTMSKB_NAI2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="74px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<%-- 2015/11/19 H.Mori mod 2015改善開発 No3 START --%> 
                    <%-- <TD width="130">発生区分&nbsp; --%>
					<TD width="125">発生区分&nbsp;
                    <%-- 2015/11/19 H.Mori mod 2015改善開発 No3 END --%>
						<asp:textbox id="txtHATKBN2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="74px" ReadOnly="True"></asp:textbox></TD>
					<%-- 2015/11/19 H.Mori mod 2015改善開発 No3 START --%> 
                    <%--
                    <TD width="60">事象数
					</TD>
					<TD width="30"><asp:textbox id="txtKEIHOSU2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="24px" ReadOnly="True"></asp:textbox></TD> --%>
                    <TD width="45">メータ値
					</TD>
					<TD width="30"><asp:textbox id="txtKENSIN2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="68px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/19 H.Mori mod 2015改善開発 No3 END --%>
				</TR>
				<TR>
					<TD>対応区分&nbsp;
						<asp:textbox id="txtTAIOKBN2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="74px" ReadOnly="True"></asp:textbox></TD>
					<TD>流量区分
					</TD>
					<TD><asp:textbox id="txtRYURYO2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="24px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG2_1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG2_2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG2_3" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG2_4" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG2_5" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:textbox id="txtMSG2_6" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="264px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD align="right" colSpan="3">緊急対応日時&nbsp; --%>
					<TD align="right" colSpan="3">対応完了日時&nbsp;
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
						<asp:textbox id="txtSYOYMD2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="143px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<%-- 2014/12/01 H.Hosoda add 2014改善開発 No3 START --%>
				<TR>
					<TD colSpan="3" class="style1">メモ欄
					</TD>
				</TR>
				<TR>
					<TD colSpan="3" height="75px">
					<textarea name="txtFAX_REN_2" id="txtFAX_REN_2" tabindex="-1" rows="3" cols="100" class="TELMEMO" style="width:264px;height:70px;" readonly=""></textarea></TD>
				</TR>
				<TR>
					<TD colSpan="3" height="12px"></TD>
				</TR>
				<%-- 2014/12/01 H.Hosoda add 2014改善開発 No3 END --%>
			</TABLE>
			<%'*******電話対応 枠*******%>
			<TABLE class="W POSS_WAKU3" cellSpacing="0" cellPadding="0">
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<%'*******電話対応*******%>
			<TABLE class="POSS_DENWA2" cellSpacing="0" cellPadding="0">
				<TR>
					<TD>担当者名&nbsp;</TD>
					<TD><FONT face="MS UI Gothic"><asp:textbox id="txtTKTANCD_NM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
								BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></FONT></TD>
					<TD>連絡相手&nbsp;</TD>
					<TD><asp:textbox id="txtTAITNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
				</TR>
                <TR>
                <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%> 
					<TD width="80">復帰対応状況&nbsp;</TD>
                    <TD width="240"><asp:textbox id="txtTFKINM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
					<TD width="65">電話内容&nbsp;</TD>
					<TD width="265"><asp:textbox id="txtTELRNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
                <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%> 
                </TR>
                <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%> 
				<TR>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%--<TD>器具原因&nbsp;</TD> --%>
					<TD>原因器具&nbsp;</TD>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
					<TD><asp:textbox id="txtTKIGNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
					<%-- 2015/11/20 H.Mori del 2015改善開発 No3
                    <TD>作動原因&nbsp;</TD>
					<TD><asp:textbox id="txtTSADNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%>
                    <TD>最終架電先&nbsp;</TD>
                    <TD><asp:textbox id="txtKOK_TELNO2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%>
				</TR>
				<TR><%-- 2015/11/20 H.Mori del 2015改善開発 No3　
					<TD>電話内容&nbsp;</TD>
					<TD><asp:textbox id="txtTELRNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%>
                    <TD>作動原因&nbsp;</TD>
					<TD><asp:textbox id="txtTSADNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%>
					<TD></TD>
					<TD></TD>
				</TR>
<%--			2013/10/24 T.Ono 監視改善2013№1 ▼▼▼
                <TR>
					<TD>&nbsp;</TD>
					<TD colSpan="3"><asp:textbox id="txtFUK_MEMO2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="496px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD colSpan="3"><asp:textbox id="txtTEL_MEMO1_2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="496px" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD colSpan="3"><asp:textbox id="txtTEL_MEMO2_2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="496px" ReadOnly="True"></asp:textbox></TD>
				</TR>--%>
                <TR>
					<TD colspan="4" rowspan = "3">&nbsp;&nbsp;
                     <textarea name="txtTEL_MEMO_2" id="txtTEL_MEMO_2" tabindex="-1" rows="3" cols="100" class="TELMEMO" runat="server" readonly></textarea> </TD>
				</TR>
                <%-- 2013/10/24 T.Ono 監視改善2013№1 ▲▲▲ --%>
			</TABLE>
			<%'*******電話対応 タイトル*******%>
			<SPAN class="POSS_DENTI2">&nbsp;&nbsp;***&nbsp;電&nbsp;話&nbsp;対&nbsp;応&nbsp;***&nbsp;&nbsp;</SPAN>
			<%'*******出動対応 枠*******%>
			<TABLE class="W POSS_WAKU4" cellSpacing="0" cellPadding="0">
				<TR>
					<TD>&nbsp;</TD>
				</TR>
			</TABLE>
			<%'*******出動対応*******%>
			<TABLE class="POSS_SYUDO2" cellSpacing="0" cellPadding="0">
				<TR>
                    <%-- 2015/12/01 H.Mori mod 2015改善開発 No3 --%>
                    <%-- 2015/01/20 T.Ono mod 2014改善開発 No3 幅を指定する START --%>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD>担当者名&nbsp;</TD> --%>
					<%-- <TD>出動対応者&nbsp;</TD> --%>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
					<%-- <TD><asp:textbox id="txtTSTANNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD>連絡相手&nbsp;</TD> --%>
					<%-- <TD>対応相手&nbsp;</TD> --%>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
					<%-- <TD><asp:textbox id="txtAITNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%--  <TD width="60" height="24">出動対応者&nbsp;</TD>
					<TD width="264" height="24"><FONT face="MS UI Gothic"><asp:textbox id="txtTSTANNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
								BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></FONT></TD>
					<TD width="47" height="24">対応相手&nbsp;</TD>
					<TD width="278" height="24"><asp:textbox id="txtAITNM1" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/01/20 T.Ono mod 2014改善開発 No3 幅を指定する END --%>
                    <TD width="80">出動対応者&nbsp;</TD>
					<TD width="240"><asp:textbox id="txtTSTANNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="200px" ReadOnly="True"></asp:textbox></TD>
					<TD width="65">対応相手&nbsp;</TD>
					<TD width="265"><asp:textbox id="txtAITNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/12/01 H.Mori mod 2015改善開発 No3 END --%>
				</TR>
				<TR>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
					<%-- <TD>器具原因&nbsp;</TD> --%>
					<TD>原因器具&nbsp;</TD>
					<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
					<TD><asp:textbox id="txtKIGNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori del 2015改善開発 No3 
					<TD>作動原因&nbsp;</TD>
					<TD><asp:textbox id="txtSADNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%>
                    <TD>復帰操作&nbsp;</TD>
					<TD><asp:textbox id="txtFKINM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%>
				</TR>
				<%-- 2014/12/01 H.Hosoda del 2014改善開発 No3 START --%>
				<%-- <TR>
					<TD>その他原因&nbsp;</TD>
					<TD><asp:textbox id="txtSTANM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
					<TD>センサ原因&nbsp;</TD>
					<TD><asp:textbox id="txtASENM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
				</TR> --%>
				<%-- 2014/12/01 H.Hosoda del 2014改善開発 No3 END --%>
				<TR><%-- 2015/11/20 H.Mori del 2015改善開発 No3 
					<TD>復帰操作&nbsp;</TD>
					<TD><asp:textbox id="txtFKINM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD> --%>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 START --%>
                    <TD>作動原因&nbsp;</TD>
					<TD><asp:textbox id="txtSADNM2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px" BorderStyle="Solid"
							Width="200px" ReadOnly="True"></asp:textbox></TD>
                    <%-- 2015/11/20 H.Mori add 2015改善開発 No3 END --%>
					<TD></TD>
					<TD></TD>
				</TR>
				<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 START --%>
				<%-- <TR>
					<TD>備考１&nbsp;</TD>
					<TD colSpan="3"><asp:textbox id="txtSDTBIK2_2" tabIndex="-1" runat="server" CssClass="c-rNM" BorderWidth="1px"
							BorderStyle="Solid" Width="496px" ReadOnly="True"></asp:textbox></TD>
				</TR> --%>
				<TR height="18px">
					<TD colSpan="4">出動結果内容/報告&nbsp;</TD>
				</TR>
				<TR>
					<TD colspan="4" rowspan = "3">&nbsp;&nbsp;
				<%'**2021/10/01 2021年度改善① sakaUPD Start	<textarea name="txtSDTBIK2_2" id="txtSDTBIK2_2" tabindex="-1" rows="3" cols="100" class="TELMEMO" readonly=""></textarea> </TD> **%>
                    <textarea name="txtSDTBIK2_2" id="txtSDTBIK2_2" tabindex="-1" rows="3" cols="100" class="STDMEMO" readonly=""></textarea> </TD>
                <%'**2021/10/01 2021年度改善① sakaUPD End **%>
				</TR>
				<%-- 2014/12/01 H.Hosoda mod 2014改善開発 No3 END --%>
			</TABLE>
			<%'*******出動対応２ タイトル*******%>
			<SPAN class="POSS_SYUTI2">&nbsp;&nbsp;***&nbsp;出&nbsp;動&nbsp;対&nbsp;応&nbsp;***&nbsp;&nbsp;</SPAN>
			<%'*******ボタン*******%>
			<table class="POSS_BUTTON" cellSpacing="0" cellPadding="0">
				<tr>
					<td width="100"><input language="javascript" class="bt-JIK" id="btnFirst" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="return btnFirst_onclick();" tabIndex="96" type="button" value="先頭" name="btnFirst" runat="server">
					</td>
					<td width="100"><input language="javascript" class="bt-JIK" id="btnPre" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="return btnPre_onclick();" tabIndex="96" type="button" value="前" name="btnPre" runat="server">
					</td>
					<td width="100"><input language="javascript" class="bt-JIK" id="btnNex" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="return btnNex_onclick();" tabIndex="96" type="button" value="次" name="btnNex" runat="server">
					</td>
					<td width="100"><input language="javascript" class="bt-JIK" id="btnEnd" onblur="fncFo(this,5)" onfocus="fncFo(this,2)"
							onclick="return btnEnd_onclick();" tabIndex="96" type="button" value="最後" name="btnEnd" runat="server">
					</td>
				</tr>
			</table>
			<iframe id="ifList" name="ifList" src="" frameBorder="0" width="0" height="0"></iframe></form>
	</body>
</HTML>
