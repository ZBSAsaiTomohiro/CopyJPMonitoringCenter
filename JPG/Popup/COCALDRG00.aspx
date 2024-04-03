<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COCALDRG00.aspx.vb" Inherits="JPG.COCALDRG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>日付選択</title>
		<script language="JavaScript">
		//画面サイズの指定
		window.resizeTo(270,300);  
		</script>
	</HEAD>
	<body onload="document.Form1.focus();">
		<form name="Form1" id="Form1" method="post" runat="server">
			<FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic"></FONT><FONT face="MS UI Gothic">
			</FONT>
			<asp:Label id="lblScript" runat="server"></asp:Label><INPUT id="hdnBackDate" type="hidden" name="hdnBackDate" runat="server"><INPUT id="hbdBackFocs" type="hidden" name="hbdBackFocs" runat="server">
			<br>
			<br>
			<center>
				<asp:calendar id="calender" runat="server" OtherMonthDayStyle-BackColor="#FFC0C0" BorderColor="Black"
					NextPrevFormat="FullMonth" BorderStyle="Solid" Width="192px" Height="204px">
					<TodayDayStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="Blue" ForeColor="White"></TodayDayStyle>
					<SelectorStyle HorizontalAlign="Center" VerticalAlign="Middle"></SelectorStyle>
					<DayStyle Font-Underline="True" HorizontalAlign="Center" Height="20px" BorderWidth="1px" ForeColor="Blue"
						BorderStyle="Solid" BorderColor="Black" Width="130px" VerticalAlign="Middle"></DayStyle>
					<NextPrevStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"></NextPrevStyle>
					<DayHeaderStyle Font-Bold="True" HorizontalAlign="Center" Height="20px" BorderWidth="1px" BorderStyle="Solid"
						BorderColor="Black" VerticalAlign="Middle" BackColor="LightCyan"></DayHeaderStyle>
					<SelectedDayStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="Blue"></SelectedDayStyle>
					<TitleStyle Font-Bold="True" HorizontalAlign="Center" Height="20px" ForeColor="White" VerticalAlign="Middle"
						BackColor="Blue"></TitleStyle>
					<WeekendDayStyle HorizontalAlign="Center" ForeColor="Red" VerticalAlign="Middle" BackColor="Cyan"></WeekendDayStyle>
					<OtherMonthDayStyle HorizontalAlign="Center" ForeColor="Gray" VerticalAlign="Middle" BackColor="Lavender"></OtherMonthDayStyle>
				</asp:calendar>
			</center>
		</form>
	</body>
</HTML>
