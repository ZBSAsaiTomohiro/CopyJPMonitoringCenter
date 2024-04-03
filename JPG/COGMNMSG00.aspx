<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COGMNMSG00.aspx.vb" Inherits="JPG.COGMNMSG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>COGMNMSG00</title>
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
											<td class="TITLE" vAlign="middle">マスタ管理メニュー</td>
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
            <!-- 2016/02/18 T.Ono mod 2015改善開発 №7 -->
			<!--<table cellSpacing="0" cellPadding="0" width="900">-->
            <table cellSpacing="0" cellPadding="0" width="1200">
				<tr>
					<td width="30" height="30"></td>
					<td width="870" height="30"></td>
				</tr>
				<tr>
					<td></td>
					<td>
						<!-- 2014/01/24 T.Ono mod 監視改善2013 マスタ管理メニュー一新 ----------START -->
						<%--<table cellSpacing="0" cellPadding="0" width="560">
                            <tr>
								<td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="担当者マスタ" onclick="fncClick('MSTANJAG00','');"></td>
								<td width="280"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="4" value="プルダウン設定マスタ" onclick="fncClick('MSPULJAG00','');"></td>
							</tr>
							<tr>
								<td colspan="2" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;<INPUT type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" 
								onclick="fncClick('MSTAJJAG00','');" tabIndex="1" value="JA担当者マスタ"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2" height="30">&nbsp;</td>
							</tr>
                        </table>--%>
                        <!-- 2016/02/18 T.Ono mod 2015改善開発 №7 -->
                        <!--<table cellSpacing="0" cellPadding="0" width="840">-->
                        <table cellSpacing="0" cellPadding="0" width="1120">
                            <tr>
								<!-- 2016/02/18 T.Ono del 2015改善開発 №7 START ボタン配置変更 -->
                                <%--<td width="280"><input type="button" name="btnMenu001" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="JA担当者・報告先マスタ" onclick="fncClick('MSTAJJAG00','');"></td>--%>
                                <td width="280"><input type="button" name="btnMenu001" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="1" value="JA担当者・報告先・注意事項&#13;&#10;マスタ" onclick="fncClick('MSTAGJAG00','');"/></td>
                                <!-- 2016/02/18 T.Ono del 2015改善開発 №7 START ボタン配置変更 -->
								<%-- 2014/10/03 T.Ono mod 2014改善開発 No19 START 
                                <td width="280"><input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="5" value="  累積情報自動FAX&メール&#13;&#10;マスタ" onclick="fncClick('MSRUIJAG00','');"></td> --%>
               					<%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 START 
                                <td width="280"><input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="5" value="自動対応グループマスタ" onclick="fncClick('MSJIGJAG00','');"/></td>--%>
                                <td width="280"><input type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="6" value="自動対応内容マスタ" onclick="fncClick('MSJINJAG00','');"></td>
               					<%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 END --%>
                                <%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 END --%>
                                <%-- 2014/10/03 T.Ono mod 2014改善開発 No19 END --%>
                                <td width="280"><input type="button" name="btnMenu009" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="9" value="供給センターマスタ" onclick="fncClick('MSKYOJAG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="2" value="監視センター担当者マスタ" onclick="fncClick('MSTAKJAG00','');"></td>
								<%-- 2014/10/03 T.Ono mod 2014改善開発 No19 START 
                                <td width="280"><input type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="6" value="自動対応グループマスタ" onclick="fncClick('MSJIGJAG00','');"></td> --%>
               					<%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 START 
                                <td width="280"><input type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="6" value="自動対応内容マスタ" onclick="fncClick('MSJINJAG00','');"></td> --%>
                                <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="7" value="JAグループ作成マスタ" onclick="fncClick('MSJAGJAG00','');"/></td>
              					<%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 END --%>
                                 <%-- 2014/10/03 T.Ono mod 2014改善開発 No19 END --%>
                                <td width="280"><input type="button" name="btnMenu010" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="10" value="プルダウン設定マスタ" onclick="fncClick('MSPULJAG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
                            <tr>
								<td width="280"><input type="button" name="btnMenu003" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="3" value="出動会社担当者マスタ" onclick="fncClick('MSTALJAG00','');"></td>
								<%-- 2014/10/03 T.Ono mod 2014改善開発 No19 START
                                <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="7" value="自動対応内容マスタ" onclick="fncClick('MSJINJAG00','');"></td> --%>
                                <%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 START 
                                <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="7" value="JAグループ作成マスタ" onclick="fncClick('MSJAGJAG00','');"/></td>--%>
								<td width="280"><input type="button" name="btnMenu008" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="8" value="販売事業者グループマスタ" onclick="fncClick('MSHAGJAG00','');"/></td>
                                <%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 END --%>
                                <%-- 2014/10/03 T.Ono mod 2014改善開発 No19 END --%>
                                <td width="280"></td>
							</tr>
                            <%-- 2014/10/03 T.Ono add 2014改善開発 No19 START --%>
                            <tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
                            <tr>
								<td width="280"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="4" value="  累積情報自動FAX&メール&#13;&#10;マスタ" onclick="fncClick('MSRUIJAG00','');"/></td>
								<%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 START 
                                <td width="280"><input type="button" name="btnMenu008" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="8" value="販売事業者グループマスタ" onclick="fncClick('MSHAGJAG00','');"/></td>--%>
                                <td width="280"></td>
								<%-- 2017/02/09 W.GANEKO mod 2016改善開発 No10 END --%>
                                <%-- 2017/02/24 H.Mori del 2016改善開発 START 参照用ボタンの削除--%>
                                <!-- 2016/02/18 T.Ono del 2015改善開発 №7 START ボタン配置変更 参照用の旧マスタ画面は端に配置 -->
                                <!-- 2015/11/04 T.Ono mod 2015改善開発 №7 START -->
                                <!-- <td width="280"></td> -->
                                <%-- <td width="280"><input type="button" name="btnMenu0012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="12" value="JA担当者・報告先・注意事項&#13;&#10;マスタ" onclick="fncClick('MSTAGJAG00','');"/></td> --%>
                                <!-- 2015/11/04 T.Ono mod 2015改善開発 №7 END -->
                                <td width="280"></td>
                                <td width="280"><%--<input type="button" name="btnMenu0016" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="16" value="★参照専用★JA担当者マスタ" onclick="fncClick('MSTAJJAG00','');"/>--%></td> 
                                <!-- 2016/02/18 T.Ono add 2015改善開発 №7 END ボタン配置変更 参照用の旧マスタ画面は端に配置 -->
                                <%-- 2017/02/24 H.Mori del 2016改善開発 END 参照用ボタンの削除--%>
							</tr>
                            <%-- 2014/10/03 T.Ono add 2014改善開発 No19 END --%>
						</table>
                        <!-- 2014/01/24 T.Ono mod 監視改善2013 マスタ管理メニュー一新 ----------END -->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
