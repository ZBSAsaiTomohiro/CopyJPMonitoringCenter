<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COGBASEG00.aspx.vb" Inherits="JPSD.KOGBASEG00" EnableSessionState="ReadOnly" enableViewState="False" %>
<HTML>
	<HEAD>
		<TITLE>�o����ЃV�X�e��</TITLE>
		<script language="javascript">
	var wP;
	function window_onload(){
		//�|�b�v�A�b�v�ŌĂ΂ꂽ��ʂłȂ����
		if(window.opener == null){
			fncOnloadLocation();
		}
		fncPopupOpen();
	}
	function fncOnloadLocation(){
		if (window.document.readyState=='complete'){
			window.frames("data").location='/JPSD/SD/SDLSTJAG/SDLSTJAG00/SDLSTJAG00.aspx';
		} else {
			timerID = setTimeout("fncOnloadLocation('/JPSD/SD/SDLSTJAG/SDLSTJAG00/SDLSTJAG00.aspx')",500);
		}
	}
	function window_onunload() {
		//�|�b�v�A�b�v���J���Ă����
		if (wP != null){
			//����
		    wP.close();
			wP=null;
		}
	}
    <%-- 2014/10/15 H.Hosoda del 2014���P�J�� No20 START --%>
	// 2008/11/04 T.Watabe add JPG����ڐA
	//function fncPopupOpen(){
	//	wP=window.open("","wP","toolbar=no,location=no,menubar=no,top=0,left=200,width=1,height=1,scrollbars=yes");
	//	window.focus();
	//	return wP;
	//}
    <%-- 2014/10/15 H.Hosoda del 2014���P�J�� No20 END --%>
    <%-- 2014/10/31 H.Hosoda mod �|�b�v�A�b�v�\�����ύX START --%>
    <%-- 2014/10/15 H.Hosoda mod 2014���P�J�� No20 START --%>
    //function fncPopupOpen(name){
	//    wP = window.open("", name, "toolbar=no,location=no,menubar=no,top=0,left=200,width=1,height=1,scrollbars=yes");
	//    window.focus();
	//	return wP;
	//}
    <%-- 2014/10/15 H.Hosoda mod 2014���P�J�� No20 END --%>
    function fncPopupOpen(name,strOptwidth){
		if(typeof strOptwidth === 'undefined') strOptwidth = "400";
	    wP = window.open("", name, "toolbar=no,location=no,menubar=no,top=0,left=200,width=" + strOptwidth + ",height=385,scrollbars=yes");
	    window.focus();
		return wP;
	}    
    <%-- 2014/10/31 H.Hosoda mod �|�b�v�A�b�v�\�����ύX END --%>
	window.onload = fncOnloadLocation;
		</script>
	</HEAD>
	<frameset rows="0,*,0" frameborder="yes" framespacing="1" onunload="window_onunload();">
		<frame id="Head" name="Head" src="" scrolling="no">
		<frame id="Data" name="Data" src="" scrolling="auto">
		<frame id="Recv" name="Recv" src="" scrolling="auto">
	</frameset>
</HTML>
