<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MSTAJJPG00.aspx.vb" Inherits="MSTAJJAG00.MSTAJJPG00" EnableSessionState="ReadOnly" enableViewState="False" validateRequest="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tips HTMLタグの使用方法</title>
		<style type="text/css">INPUT {
	PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; CURSOR: pointer; PADDING-TOP: 0px; outline: 3px none red
}
LABEL {
	CURSOR: pointer
}
TABLE.base {
	FONT-SIZE: 11pt; BACKGROUND-COLOR: #000000
}
.t0 {
	FONT-SIZE: 11pt; BACKGROUND-COLOR: #ccddff; BORDER: Solid 1px Black
}
.t1 {
	FONT-SIZE: 11pt; COLOR: #222222; BACKGROUND-COLOR: #bbbbbb; TEXT-ALIGN: left; BORDER: Solid 1px Black
}
.t2 {
	FONT-SIZE: 11pt; COLOR: #222222; BACKGROUND-COLOR: #cccccc; TEXT-ALIGN: left; BORDER: Solid 1px Black
}
.t3 {
	FONT-SIZE: 11pt; COLOR: #222222; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: left; BORDER: Solid 1px Black
}
.t4 {
	FONT-SIZE: 11pt; BACKGROUND-COLOR: #cccccc; TEXT-ALIGN: left; BORDER: Solid 1px Black
}
.t5 {
	FONT-SIZE: 11pt; BACKGROUND-COLOR: #dddddd; TEXT-ALIGN: left; BORDER: Solid 1px Black
}
</style>
		<script language="JavaScript">
		window.resizeTo(700,600);
		</script>
	</HEAD>
	<body topMargin="0" marginwidth="10" marginheight="10">
		<form id="Form1" method="post" runat="server">
			<center><asp:label id="lblScript" runat="server"></asp:label>
				<table width="100%">
					<tr>
						<td vAlign="top" align="right" height="20"><input onclick="window.close();" type="button" value="閉じる">
						</td>
					</tr>
				</table>
				<table>
					<tr>
						<td class="TITLE"><u><asp:label id="lblListName" runat="server">Tips HTMLタグの使用方法</asp:label></u></td>
					</tr>
				</table>
				<table cellSpacing="0" cellPadding="0" border="1" style="BORDER: Solid 1px Black">
					<tr>
						<td class="t1" rowSpan="2">強調</td>
						<td class="t5">&lt;b&gt;太字&lt;/b&gt;にします。</td>
					</tr>
					<tr>
						<td bgColor="white" style="BORDER: Solid 1px Black"><b>太字</b>にします。</td>
					</tr>
					<tr>
						<td class="t1" rowSpan="2">斜体</td>
						<td class="t5">&lt;i&gt;斜体文字&lt;/i&gt;にします。</td>
					</tr>
					<tr>
						<td bgColor="white" style="BORDER: Solid 1px Black"><i>斜体文字</i>にします。</td>
					</tr>
					<tr>
						<td class="t1" rowSpan="2">文字色</td>
						<td class="t5">&lt;font color=red&gt;赤い文字&lt;/font&gt;にします。</td>
					</tr>
					<tr>
						<td bgColor="white" style="BORDER: Solid 1px Black"><font color="red">赤い文字</font>にします。</td>
					</tr>
					<tr>
						<td class="t1" rowSpan="2">背景色</td>
						<td class="t5">今月は&lt;span 
							style="background-color:#ffff99;"&gt;１０日&lt;/span&gt;が締日です。</td>
					</tr>
					<tr>
						<td bgColor="white" style="BORDER: Solid 1px Black">今月は<span style="BACKGROUND-COLOR: #ffff99">１０日</span>が締日です。</td>
					</tr>
					<tr>
						<td class="t1" rowSpan="2">改行</td>
						<td class="t5">ここで&lt;br&gt;改行します。</td>
					</tr>
					<tr>
						<td bgColor="white" style="BORDER: Solid 1px Black">ここで<br>
							改行します。</td>
					</tr>
					<tr>
						<td class="t1" rowSpan="2">リンク</td>
						<td class="t5">&lt;a href='http://www.ja-lp.co.jp/' 
							target='_blank'&gt;JA-LPﾎｰﾑﾍﾟｰｼﾞ&lt;/a&gt;が開きます。</td>
					</tr>
					<tr>
						<td bgColor="white" style="BORDER: Solid 1px Black"><a href="http://www.ja-lp.co.jp/" target="_blank">JA-LPﾎｰﾑﾍﾟｰｼﾞ</a>が開きます。</td>
					</tr>
					<tr>
						<td class="t1" rowSpan="2">画像</td>
						<td class="t5">&lt;img src='http://www.ja-lp.co.jp/image/bnr_ansin.gif'&gt;が表示されます。</td>
					</tr>
					<tr>
						<td bgColor="white" style="BORDER: Solid 1px Black"><img src="http://www.ja-lp.co.jp/image/bnr_ansin.gif">が表示されます。</td>
					</tr>
					<tr>
						<td class="t1" rowSpan="2">スライド（マーキー）</td>
						<td class="t5">&lt;marquee&gt;マーキー&lt;/marquee&gt;</td>
					</tr>
					<tr>
						<td bgColor="white" style="BORDER: Solid 1px Black">
							<marquee>今月の締日は１０日ですので前日までに確認宜しくお願いします。</marquee></td>
					</tr>
					<tr style="BORDER: Solid 1px Black">
						<td class="t0">&nbsp;</td>
						<td class="t0">
							<table>
								<tr vAlign="top">
									<td noWrap><span style="COLOR: #000000">■</span>
										Black (#000000)<br>
										<span style="COLOR: #808080">■</span>
										Gray (#808080)<br>
										<span style="COLOR: #c0c0c0">■</span>
										Silver (#C0C0C0)<br>
										<span style="COLOR: #000000">□</span>
										White (#FFFFFF)<br>
									</td>
									<td noWrap><span style="COLOR: #ff0000">■</span>
										Red (#FF0000)<br>
										<span style="COLOR: #ffff00">■</span>
										Yellow (#FFFF00)<br>
										<span style="COLOR: #00ff00">■</span>
										Lime (#00FF00)<br>
										<span style="COLOR: #00ffff">■</span>
										Aqua (#00FFFF)<br>
										<span style="COLOR: #0000ff">■</span>
										Blue (#0000FF)<br>
										<span style="COLOR: #ff00ff">■</span>
										Fuchsia (#FF00FF)<br>
									</td>
									<td noWrap><span style="COLOR: #800000">■</span>
										Maroon (#800000)<br>
										<span style="COLOR: #808000">■</span>
										Olive (#808000)<br>
										<span style="COLOR: #008000">■</span>
										Green (#008000)<br>
										<span style="COLOR: #008080">■</span>
										Teal (#008080)<br>
										<span style="COLOR: #000080">■</span>
										Navy (#000080)<br>
										<span style="COLOR: #800080">■</span>
										Purple (#800080)<br>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
		</form>
		</CENTER>
	</body>
</HTML>
