<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COGMNCTG00.aspx.vb" Inherits="JPG.COGMNCTG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>COGMNCTG00</title>
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
											<td class="TITLE" vAlign="middle">
												<asp:Label id="lblTitle" runat="server"></asp:Label>���j���[</td>
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
										tabIndex="1" value="�x���M�p�l��(�Ή����͗p)" onclick="fncClick('KEJUKJAG00','');"></td>
								<td width="280"><input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="6" value="�x���M�p�l��(�\����p)" onclick="fncClick('KEJUKJAG00','KANSHI');"></td>
								<%-- 2014/01/24 T.Ono mod �Ď����P2013
								<td width="280"><input type="button" name="btnMenu009" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="10" value="�S���҃}�X�^" onclick="fncClick('MSTANJAG00','');"></td>--%>
								<td width="280"><input type="button" name="btnMenu009" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="11" value="�}�X�^�Ǘ����j���[" onclick="fncClick('COGMNMSG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<%-- 2014/10/14 H.Hosoda mod 2014���P�J�� No22 START --%>
								<%-- <td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="2" value="�d�b�Ή�����" onclick="fncClick('MSKOSJAG00','KETAIOU');"></td>
								<td width="280"><INPUT class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" onclick="fncClick('SDLOGJAG00','');"
										tabIndex="6" type="button" value="�ً}�o���m�F�ꗗ" name="btnMenu006">&nbsp;</td> --%>
								<td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="2" value="�d�b�Ή�����/���q�l����" onclick="fncClick('MSKOSJAG00','KETAIOU');"></td>
								<td width="280"><INPUT class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" onclick="fncClick('SDLOGJAG00','');"
										tabIndex="7" type="button" value="�ً}�o���ꗗ" name="btnMenu006">&nbsp;</td>
								 <%-- 2014/10/14 H.Hosoda mod 2014���P�J�� No22 END --%>
								 
								<%-- 2014/01/24 T.Ono mod �Ď����P2013
								<!-- 2008/12/18 T.Watabe add -->
								<td width="280"><input type="button" name="btnMenu014" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="11" value="JA�S���҃}�X�^" onclick="fncClick('MSTAJJAG00','');"></td>--%>
								<td width="280"><input type="button" name="btnMenu014" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="12" value="�}�X�^�ꗗ���j���[" onclick="fncClick('COGMNMLG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td width="280"><input type="button" name="btnMenu003" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="3" value="�Ή����ʈꗗ" onclick="fncClick('KEKEKJAG00','');"></td>
								<%-- 2014/01/24 T.Ono mod �Ď����P2013
								<%-- 2013/07/25 T.Ono mod
								<td width="280"><FONT face="MS UI Gothic"></FONT></td> %>
								<td width="280"><input type="button" name="btnMenu010" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="7" value="�i�`�S���ҘA����" onclick="fncClick('MSTAEJAG00','');"></td>
								<td width="280"><input type="button" name="btnMenu010" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="12" value="�S���҃}�X�^�ꗗ" onclick="fncClick('MSTASJAG00','');"></td>--%>
								
								<%-- 2014/10/14 H.Hosoda mod 2014���P�J�� No22 START --%>
								<%-- 2014/08/27 T.Ono mod �{�^�����ԈႦ�̂��ߕύX �ً}�Ή��o�́��x��Ή��o�� --%>
								<%-- <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="7" value="�x��Ή��o��" onclick="fncClick('KETAISYG00','');"></td> --%>
								<%-- 2017/02/17 W.GANEKO mod 2016���P�J�� No7 START --%>
								<%-- <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="7" value="�Ď��Ή��o��" onclick="fncClick('KETAISYG00','');"></td> --%>
								<td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="8" value="�Ή����ʖ��׏o��" onclick="fncClick('KETAISYG00','');"></td>
								 <%-- 2017/02/17 W.GANEKO mod 2016���P�J�� No7 END --%>
								 <%-- 2014/10/14 H.Hosoda mod 2014���P�J�� No22 END --%>
								<td width="280"><input type="button" name="btnMenu011" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="13" value="�V�X�e���Ǘ����j���[" onclick="fncClick('COGMNSSG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td width="280"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="4" value="�ݐϏ��ꗗ" onclick="fncClick('KERUIJOG00','');"></td>
								<%-- 2014/02/03 T.Ono mod �Ď����P2013
								<!-- �x���Ή��o�� 2006/05/23_ADD_BEGIN   -->
								<td width="280"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="8" value="�x��Ή��o��" onclick="fncClick('KETAISYG00','');"></td>
								<!-- �x���Ή��o�� 2006/05/23_ADD_BEGIN   -->
								<!-- 2006/05/23_DEL						<td width="280"></td> -->
								<!-- 2008/07/02 T.Watabe edit
								<td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="12" value="���[�Ǘ����j���[" onclick=""></FONT></td>
								//-->
								<td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu011" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="13" value="�V�X�e���Ǘ����j���[" onclick="fncClick('COGMNSSG00','');"></FONT></td>  --%>
								<td width="280"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="9" value="�Ď��Ή����W�v�\" onclick="fncClick('KEKANSYG00','');"></td>
								<!-- 2014/09/10 T.Ono mod ���[�T�[�o�[���v���C�X IP���ڽ�ύX -->
								<%-- <td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu011" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="13" value="�Ď����[" onclick="javascript:window.open('http://10.10.100.23/tyouhyou/','tyouhyou'); return false;"></FONT></td> --%>
								<%-- 2014/10/14 H.Hosoda mod 2014���P�J�� No22 START --%>											
								<%-- <td width="280"><font face="MS UI Gothic"><input type="button" name="btnMenu011" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabindex="13" value="�Ď����[" onclick="javascript:window.open('http://10.11.100.23/tyouhyou/','tyouhyou'); return false;"/></font></td> --%>
								<td width="280"><font face="MS UI Gothic"><input type="button" name="btnMenu011" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabindex="14" value="�������[" onclick="javascript:window.open('http://10.11.100.23/tyouhyou/','tyouhyou'); return false;"/></font></td>
								 <%-- 2014/10/14 H.Hosoda mod 2014���P�J�� No22 END --%>
								<!-- �������������[�J���� �����[�X���͖{�ԗp�ɂ��邱��-->
								<%-- <td width="280"><font face="MS UI Gothic"><input type="button" name="btnMenu011" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabindex="13" value="�Ď����[" onclick="javascript:window.open('http://10.10.100.24:8080/tyouhyou/','tyouhyou'); return false;"/></font></td> --%>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
                                <%-- 2019/01/10 T.Ono add 2018���P�J�� --%>
                                <td width="280"><input type="button" name="btnMenu013" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="5" value="��ʏ���Җ��냁�j���[" onclick="fncClick('COGMNMEG00', '');"></td><!-- 2018/11/08 T.Ono add 2018���P�J�� -->
                                <td width="280">
                                    <%-- 2020/01/6 T.Ono �ЊQ�Ή����[ --%>
                                    <input type="button" name="btnMenu014" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="10" value="�ЊQ�Ή����[" onclick="fncClick('KESAIJAG00', '');">
                                </td>
								<td width="280">&nbsp;</td>
								<%-- 2014/02/03 T.Ono del �Ď����P2013
								<!-- 2008/11/20 add -->
								<td width="280"><input type="button" name="btnMenu013" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="9" value="�Ď��Ή����W�v�\" onclick="fncClick('KEKANSYG00','');"></td>
								<!-- 2009/04/06_edit ���[�T�[�o��ύX
								<td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="14" value="���[�Ǘ����j���[" onclick="javascript:window.open('http://10.10.10.15/tyouhyou/login.asp'); return false;"></FONT></td>
								-->
								<td width="280"><FONT face="MS UI Gothic"><input type="button" name="btnMenu012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
											tabIndex="14" value="�Ď����[" onclick="javascript:window.open('http://10.10.100.23/tyouhyou/','tyouhyou'); return false;"></FONT></td>  --%>
							</tr>
                            <%-- 2019/01/10  T.Ono add 2018���P�J��--%>
                            <tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
                            <%-- 2014/10/17  T.Ono add 2014���P�J��--%>
                            <tr>
                                <td width="280"><input type="button" name="btnMenu999" tabindex="15" value="�c�Ə����j���[" onclick="fncClick('COGMNEGG00','');"/></td>
                            </tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
