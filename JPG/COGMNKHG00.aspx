<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COGMNKHG00.aspx.vb" Inherits="JPG.COGMNKHG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>COGMNKHG00</title>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="lblScript" runat="server"></asp:Label><br>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td class="WW">
						<table cellSpacing="2" cellPadding="0" width="900">
							<tr>
								<td width="200" height="25">&nbsp;</td>
								<td width="300" height="25">&nbsp;</td>
								<td width="220" height="25">&nbsp;</td>
								<td width="70" height="25">&nbsp;</td>
								<td width="30" height="25">&nbsp;</td>
								<td align="right" width="80">&nbsp;</td>
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
											<!-- 2020/03/09 T.Ono mod <td class="TITLE" vAlign="middle">運行開発部メニュー</td> -->
                                            <td class="TITLE" vAlign="middle">第１ネットワークソリューション部メニュー</td>
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
						<table cellSpacing="0" cellPadding="0" width="840">
							<tr>
								<td width="280"><input type="button" name="btnMenu001" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="警報受信パネル(対応入力用)" onclick="fncClick('KEJUKJAG00','');"></td>
								<td width="280"><input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="6" value="警報受信パネル(表示専用)" onclick="fncClick('KEJUKJAG00','KANSHI');"></td>
								<td width="280"><input type="button" name="btnMenu009" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="11" value="マスタ管理メニュー" onclick="fncClick('COGMNMSG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<%-- 2014/10/14 H.Hosoda mod 2014改善開発 No22 START --%>
								<%-- <td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="2" value="電話対応入力" onclick="fncClick('MSKOSJAG00','KETAIOU');"></td>
								<td width="280"><INPUT class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" onclick="fncClick('SDLOGJAG00','');"
										tabIndex="6" type="button" value="緊急出動確認一覧" name="btnMenu005">&nbsp;</td> --%>
								<td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="2" value="電話対応入力/お客様検索" onclick="fncClick('MSKOSJAG00','KETAIOU');"></td>
								<td width="280"><INPUT class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" onclick="fncClick('SDLOGJAG00','');"
										tabIndex="7" type="button" value="緊急出動一覧" name="btnMenu005">&nbsp;</td>
								<%-- 2014/10/14 H.Hosoda mod 2014改善開発 No22 END --%>
								<td width="280"><input type="button" name="btnMenu010" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="12" value="マスタ一覧メニュー" onclick="fncClick('COGMNMLG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td width="280"><input type="button" name="btnMenu003" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="3" value="対応結果一覧" onclick="fncClick('KEKEKJAG00','');"></td>
								<td width="280">
									<!-- input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" tabIndex="7" value="販売管理締処理" onclick="fncClick('SYHANJAG00','');" --><!-- 2010/03/05 T.Watabe edit -->
									<%-- 2014/10/14 H.Hosoda mod 2014改善開発 No22 START --%>
									<%-- <input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" tabIndex="7" value="警報対応出力" onclick="fncClick('KETAISYG00','');"></td> --%>
                                    <%-- 2017/02/17 W.GANEKO mod 2016改善開発 No7 START --%>
									<%-- <input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" tabIndex="7" value="監視対応出力" onclick="fncClick('KETAISYG00','');"></td> --%>
									<input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" tabIndex="8" value="対応結果明細出力" onclick="fncClick('KETAISYG00','');"></td>
                                    <%-- 2017/02/17 W.GANEKO mod 2016改善開発 No7 END --%>
									<%-- 2014/10/14 H.Hosoda mod 2014改善開発 No22 END --%>
								</td>
								<td width="280"><input type="button" name="btnMenu011" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="13" value="システム管理メニュー" onclick="fncClick('COGMNSSG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td width="280"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="4" value="累積情報一覧" onclick="fncClick('KERUIJOG00','');"></td>
								<!-- 警報器対応出力 2006/05/23_ADD_BEGIN   -->
								<td width="280">
									<!-- input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" tabIndex="8" value="警報対応出力" onclick="fncClick('KETAISYG00','');" --><!-- 2010/03/05 T.Watabe edit -->
									<input type="button" name="btnMenu013" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" tabIndex="9" value="監視対応数集計表" onclick="fncClick('KEKANSYG00','');"></td>
								<!-- 警報器対応出力 2006/05/23_ADD_END   -->
								<!-- 2006/05/23_DEL				<td width="280"></td>    -->
								<!-- 2008/11/20_edit			<td width="280"></td>    -->
								<!-- 2009/04/06_edit 帳票サーバを変更
								<td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="12" value="帳票管理メニュー" onclick="javascript:window.open('http://10.10.10.15/tyouhyou/login.asp'); return false;"></FONT></td>
								-->
								<!-- 2014/09 帳票サーバーリプレイス IPｱﾄﾞﾚｽ変更 -->
								<%-- <td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="12" value="監視帳票" onclick="javascript:window.open('http://10.10.100.23/tyouhyou/','tyouhyou'); return false;"></FONT></td> --%>
											
								<%-- 2014/10/14 H.Hosoda mod 2014改善開発 No22 START --%>
								<%-- <td width="280"><font face="MS UI Gothic"><input type="button" name="btnMenu012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabindex="12" value="監視帳票" onclick="javascript:window.open('http://10.11.100.23/tyouhyou/','tyouhyou'); return false;"/></font></td> --%>
								<td width="280"><font face="MS UI Gothic"><input type="button" name="btnMenu012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabindex="14" value="月次帳票" onclick="javascript:window.open('http://10.11.100.23/tyouhyou/','tyouhyou'); return false;"/></font></td>
								<%-- 2014/10/14 H.Hosoda mod 2014改善開発 No22 END --%>
								<!-- ★★★月次帳票開発環境 リリース時は本番用にすること-->
								<%-- <td width="280"><font face="MS UI Gothic"><input type="button" name="btnMenu012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabindex="12" value="月次帳票" onclick="javascript:window.open('http://10.10.100.24:8080/tyouhyou/','tyouhyou'); return false;"/></font></td> --%>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
                                <%-- 2019/01/10 T.Ono add 2018改善開発  --%>
								<td width="280"><input type="button" name="btnMenu013" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="5" value="一般消費者名簿メニュー" onclick="fncClick('COGMNMEG00', '');"></td><!-- 2018/11/08 T.Ono add 2018改善開発 -->
								<td width="280">
                                    <%-- 2020/01/6 T.Ono 災害対応帳票 --%>
                                    <input type="button" name="btnMenu014" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="10" value="災害対応帳票" onclick="fncClick('KESAIJAG00', '');"></td>
								<td width="280">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
