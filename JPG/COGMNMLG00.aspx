<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COGMNMLG00.aspx.vb" Inherits="JPG.COGMNMLG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>COGMNMLG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblScript" runat="server"></asp:Label><br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200">&nbsp;</td>
								<td width="300">&nbsp;</td>
								<td width="220">&nbsp;</td>
								<td width="70">&nbsp;</td>
								<td width="30">&nbsp;</td>
								<td align="right" width="80">
									<input type="button" name="btnMenu000" class="bt-JIK" onblur="fncFo(this,6)" onfocus="fncFo(this,2);"
										tabIndex="99" value="終了" onclick="fncClick('COGMENUG00','');">
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
								<td width="20">&nbsp;</td>
								<td vAlign="middle" width="710">
									<table cellSpacing="0" cellPadding="2" width="100%">
										<tr>
											<td class="TITLE" vAlign="middle">マスタ一覧メニュー</td>
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
			<br>
			<br>
			<table cellSpacing="0" cellPadding="0" width="900">
				<tr>
					<td width="30" height="30"></td>
					<td width="870" height="30"></td>
				</tr>
				<tr>
					<td></td>
					<td>
						<table cellSpacing="0" cellPadding="0" width="560">
							<tr>
								<%--2014/01/27 T.Ono mod 監視改善2013 文言変更
                                <td width="280">
									<input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="担当者マスタ" onclick="fncClick('MSTASJAG00','');">
								</td>
								<td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="4" value="プルダウン設定マスタ" onclick="fncClick('MSPUFJAG00','');"></FONT></td>--%>
                                <td width="280">
									<input type="button" name="btnMenu001" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="担当者マスタ一覧" onclick="fncClick('MSTASJAG00','');">
								</td>
								<td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="4" value="プルダウン設定マスタ一覧" onclick="fncClick('MSPUFJAG00','');"></FONT></td>
							</tr>
							<tr>
								<td colspan="2" height="30">&nbsp;</td>
							</tr>
							<!-- 2010/03/26 T.Watabe add -->
							<tr>
								<td width="280">
									<%--2014/01/27 T.Ono mod 監視改善2013 文言変更
                                    <input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="ＪＡ担当者連絡先" onclick="fncClick('MSTAEJAG00','');">--%>
                                    <%-- 2016/02/25 T.Ono mod 2015改善開発 №7
                                    <input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="ＪＡ担当者連絡先出力" onclick="fncClick('MSTAEJAG00','');">--%>
                                    <input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="ＪＡ担当者連絡先出力" onclick="fncClick('MSTAHJAG00','');"/>
								</td>
								<td width="280">&nbsp;</td>
							</tr>
                            <%-- 2015/12/15 T.Ono mod 2015改善開発 №7 START--%>
                            <tr>
								<td colspan="2" height="30">&nbsp;</td>
							</tr>
                            <%-- 2015/12/15 T.Ono mod 2015改善開発 №7 END--%>
							<tr>
								<%-- 2015/12/15 T.Ono mod 2015改善開発 №7 START--%>
                                <%-- <td>&nbsp;</td> --%>
                                <td width="280">
                                <%-- 2016/02/25 T.Ono del 2015改善開発 №7
                                <input type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="ＪＡ担当者連絡先出力&#13;&#10;（JA報告先マスタ参照）" onclick="fncClick('MSTAHJAG00','');">--%>
                                </td>
                                <%-- 2015/12/15 T.Ono mod 2015改善開発 №7 END--%>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2" height="30">&nbsp;</td>
							</tr>
                            <%-- 2017/02/24 H.Mori del 2016改善開発 START 参照用ボタンの削除--%>
                            <%-- 2016/02/25 T.Ono add 2015改善開発 №7 START--%>
                            <%--  <tr>
                                <td width="280">
                                <input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="★参照専用★&#13;&#10;ＪＡ担当者連絡先出力" onclick="fncClick('MSTAEJAG00','');"/>
                                </td>
                            </tr> --%>
                            <%-- 2016/02/25 T.Ono add 2015改善開発 №7 END--%>
                            <%-- 2017/02/24 H.Mori del 2016改善開発 END 参照用ボタンの削除--%>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
