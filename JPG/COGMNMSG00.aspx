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
										tabIndex="99" value="�I��" onclick="fncClick('COGMENUG00','');">
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
											<td class="TITLE" vAlign="middle">�}�X�^�Ǘ����j���[</td>
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
            <!-- 2016/02/18 T.Ono mod 2015���P�J�� ��7 -->
			<!--<table cellSpacing="0" cellPadding="0" width="900">-->
            <table cellSpacing="0" cellPadding="0" width="1200">
				<tr>
					<td width="30" height="30"></td>
					<td width="870" height="30"></td>
				</tr>
				<tr>
					<td></td>
					<td>
						<!-- 2014/01/24 T.Ono mod �Ď����P2013 �}�X�^�Ǘ����j���[��V ----------START -->
						<%--<table cellSpacing="0" cellPadding="0" width="560">
                            <tr>
								<td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="�S���҃}�X�^" onclick="fncClick('MSTANJAG00','');"></td>
								<td width="280"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="4" value="�v���_�E���ݒ�}�X�^" onclick="fncClick('MSPULJAG00','');"></td>
							</tr>
							<tr>
								<td colspan="2" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td>&nbsp;<INPUT type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);" 
								onclick="fncClick('MSTAJJAG00','');" tabIndex="1" value="JA�S���҃}�X�^"></td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2" height="30">&nbsp;</td>
							</tr>
                        </table>--%>
                        <!-- 2016/02/18 T.Ono mod 2015���P�J�� ��7 -->
                        <!--<table cellSpacing="0" cellPadding="0" width="840">-->
                        <table cellSpacing="0" cellPadding="0" width="1120">
                            <tr>
								<!-- 2016/02/18 T.Ono del 2015���P�J�� ��7 START �{�^���z�u�ύX -->
                                <%--<td width="280"><input type="button" name="btnMenu001" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="1" value="JA�S���ҁE�񍐐�}�X�^" onclick="fncClick('MSTAJJAG00','');"></td>--%>
                                <td width="280"><input type="button" name="btnMenu001" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="1" value="JA�S���ҁE�񍐐�E���ӎ���&#13;&#10;�}�X�^" onclick="fncClick('MSTAGJAG00','');"/></td>
                                <!-- 2016/02/18 T.Ono del 2015���P�J�� ��7 START �{�^���z�u�ύX -->
								<%-- 2014/10/03 T.Ono mod 2014���P�J�� No19 START 
                                <td width="280"><input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="5" value="  �ݐϏ�񎩓�FAX&���[��&#13;&#10;�}�X�^" onclick="fncClick('MSRUIJAG00','');"></td> --%>
               					<%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 START 
                                <td width="280"><input type="button" name="btnMenu005" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="5" value="�����Ή��O���[�v�}�X�^" onclick="fncClick('MSJIGJAG00','');"/></td>--%>
                                <td width="280"><input type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="6" value="�����Ή����e�}�X�^" onclick="fncClick('MSJINJAG00','');"></td>
               					<%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 END --%>
                                <%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 END --%>
                                <%-- 2014/10/03 T.Ono mod 2014���P�J�� No19 END --%>
                                <td width="280"><input type="button" name="btnMenu009" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="9" value="�����Z���^�[�}�X�^" onclick="fncClick('MSKYOJAG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td width="280"><input type="button" name="btnMenu002" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="2" value="�Ď��Z���^�[�S���҃}�X�^" onclick="fncClick('MSTAKJAG00','');"></td>
								<%-- 2014/10/03 T.Ono mod 2014���P�J�� No19 START 
                                <td width="280"><input type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="6" value="�����Ή��O���[�v�}�X�^" onclick="fncClick('MSJIGJAG00','');"></td> --%>
               					<%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 START 
                                <td width="280"><input type="button" name="btnMenu006" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="6" value="�����Ή����e�}�X�^" onclick="fncClick('MSJINJAG00','');"></td> --%>
                                <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="7" value="JA�O���[�v�쐬�}�X�^" onclick="fncClick('MSJAGJAG00','');"/></td>
              					<%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 END --%>
                                 <%-- 2014/10/03 T.Ono mod 2014���P�J�� No19 END --%>
                                <td width="280"><input type="button" name="btnMenu010" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="10" value="�v���_�E���ݒ�}�X�^" onclick="fncClick('MSPULJAG00','');"></td>
							</tr>
							<tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
                            <tr>
								<td width="280"><input type="button" name="btnMenu003" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="3" value="�o����ВS���҃}�X�^" onclick="fncClick('MSTALJAG00','');"></td>
								<%-- 2014/10/03 T.Ono mod 2014���P�J�� No19 START
                                <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabIndex="7" value="�����Ή����e�}�X�^" onclick="fncClick('MSJINJAG00','');"></td> --%>
                                <%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 START 
                                <td width="280"><input type="button" name="btnMenu007" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="7" value="JA�O���[�v�쐬�}�X�^" onclick="fncClick('MSJAGJAG00','');"/></td>--%>
								<td width="280"><input type="button" name="btnMenu008" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="8" value="�̔����Ǝ҃O���[�v�}�X�^" onclick="fncClick('MSHAGJAG00','');"/></td>
                                <%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 END --%>
                                <%-- 2014/10/03 T.Ono mod 2014���P�J�� No19 END --%>
                                <td width="280"></td>
							</tr>
                            <%-- 2014/10/03 T.Ono add 2014���P�J�� No19 START --%>
                            <tr>
								<td colspan="3" height="30">&nbsp;</td>
							</tr>
                            <tr>
								<td width="280"><input type="button" name="btnMenu004" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="4" value="  �ݐϏ�񎩓�FAX&���[��&#13;&#10;�}�X�^" onclick="fncClick('MSRUIJAG00','');"/></td>
								<%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 START 
                                <td width="280"><input type="button" name="btnMenu008" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="8" value="�̔����Ǝ҃O���[�v�}�X�^" onclick="fncClick('MSHAGJAG00','');"/></td>--%>
                                <td width="280"></td>
								<%-- 2017/02/09 W.GANEKO mod 2016���P�J�� No10 END --%>
                                <%-- 2017/02/24 H.Mori del 2016���P�J�� START �Q�Ɨp�{�^���̍폜--%>
                                <!-- 2016/02/18 T.Ono del 2015���P�J�� ��7 START �{�^���z�u�ύX �Q�Ɨp�̋��}�X�^��ʂ͒[�ɔz�u -->
                                <!-- 2015/11/04 T.Ono mod 2015���P�J�� ��7 START -->
                                <!-- <td width="280"></td> -->
                                <%-- <td width="280"><input type="button" name="btnMenu0012" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="12" value="JA�S���ҁE�񍐐�E���ӎ���&#13;&#10;�}�X�^" onclick="fncClick('MSTAGJAG00','');"/></td> --%>
                                <!-- 2015/11/04 T.Ono mod 2015���P�J�� ��7 END -->
                                <td width="280"></td>
                                <td width="280"><%--<input type="button" name="btnMenu0016" class="MENU1" onblur="fncFo(this,5)" onfocus="fncFo(this,2);"
										tabindex="16" value="���Q�Ɛ�p��JA�S���҃}�X�^" onclick="fncClick('MSTAJJAG00','');"/>--%></td> 
                                <!-- 2016/02/18 T.Ono add 2015���P�J�� ��7 END �{�^���z�u�ύX �Q�Ɨp�̋��}�X�^��ʂ͒[�ɔz�u -->
                                <%-- 2017/02/24 H.Mori del 2016���P�J�� END �Q�Ɨp�{�^���̍폜--%>
							</tr>
                            <%-- 2014/10/03 T.Ono add 2014���P�J�� No19 END --%>
						</table>
                        <!-- 2014/01/24 T.Ono mod �Ď����P2013 �}�X�^�Ǘ����j���[��V ----------END -->
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
