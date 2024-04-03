<%@ Page Language="vb" AutoEventWireup="false" Codebehind="COGBASEG00.aspx.vb" Inherits="JPG.COGBASEG00" EnableSessionState="ReadOnly" enableViewState="False"%>
<html><head><title>監視システム</title></head>
<script language="javascript">
	var wP;
	function window_onload(){
		//ポップアップで呼ばれた画面でなければ
		if(window.opener == null){
			fncOnloadLocation();
		}
		fncPopupOpen();
	}
	function fncOnloadLocation(){
		if (window.document.readyState=='complete'){
				if (Form1.hdnMNFLG.value == 'SYCTIJAG00') {
					window.frames("data").location='/JPG/SY/SYCTIJAG/SYCTIJAG00/SYCTIJAG00.aspx?CTINO=' + Form1.hdnSVFLG.value + '';		
				} else {
					window.frames("data").location='/JPG/COGMENUG00.aspx';
				}
		} else {
				if (Form1.hdnMNFLG.value == 'SYCTIJAG00') {
					timerID = setTimeout("fncOnloadLocation('/JPG/SY/SYCTIJAG/SYCTIJAG00/SYCTIJAG00.aspx?CTINO=' + Form1.hdnSVFLG.value + '')",500);
				} else {
					timerID = setTimeout("fncOnloadLocation('/JPG/COGMENUG00.aspx')",500);
				}
		}
	}
	<%-- 2014/10/02 T.Ono mod 2014改善開発 No20 START --%>
	//function fncPopupOpen() {
	    //function fncPopupOpen(name){
	//    wP = window.open("", "wP", "toolbar=no,location=no,menubar=no,top=0,left=200,width=1,height=1,scrollbars=yes");
        //wP = window.open("", name, "toolbar=no,location=no,menubar=no,top=0,left=200,width=1,height=1,scrollbars=yes");
	    //wP = window.showModalDialog("/JPG/Popup/COPOPUPG00.aspx", "", "dialogWidth: 500px; dialogHeight: 200px;");
	//    window.focus();
	//	return wP;
	//}
    <%-- 2014/11/04 H.Hosoda mod ポップアップ表示幅変更 START --%>
    //function fncPopupOpen(name){
	//    wP = window.open("", name, "toolbar=no,location=no,menubar=no,top=0,left=200,width=1,height=1,scrollbars=yes");
	//    window.focus();
	//	return wP;
	//}
    <%-- 2015/11/02 w.ganeko mod 2015改善開発 №9 START --%>
    function fncPopupOpen(name,strOptwidth,strOptheight){
<%--  // alert("ポップアップ \n name:" + name + "\n strOptwidth:" + strOptwidth + "\n strOptheight:" + strOptheight ); //確認するときだけコメント解除 --%>
		if(typeof strOptwidth === 'undefined') strOptwidth = "400";
		if(typeof strOptheight === 'undefined') strOptheight = "385";
	    wP = window.open("", name, "toolbar=no,location=no,menubar=no,top=0,left=200,width=" + strOptwidth + ",height=" + strOptheight + ",scrollbars=yes");
	    window.focus();
		return wP;
	}
    <%-- 2015/11/02 w.ganeko mod 2015改善開発 №9 END --%>
    <%-- 2014/10/02 T.Ono mod 2014改善開発 No20 END --%>
    <%-- 2014/11/04 H.Hosoda mod ポップアップ表示幅変更 END --%>
		function window_onunload() {
		//ポップアップが開いていれば
		if (wP != null){
			//閉じる
			wP.close();
			wP=null;
		}
	}
	function window_close() {
		window.close();
	}
	window.onload = fncOnloadLocation;
</script>
<form id="Form1" method="post" runat="server">
	<input id="hdnSVFLG" type="hidden" name="hdnSVFLG" runat="server">
	<input id="hdnMNFLG" type="hidden" name="hdnMNFLG" runat="server">
</form>
<frameset rows="0,*,0" frameborder="yes" framespacing="1" onunload="window_onunload();">
	<frame id="Head" name="Head" src="" scrolling="no">
	<frame id="Data" name="Data" src="" scrolling="auto">
	<frame id="Recv" name="Recv" src="" scrolling="auto">
</frameset>
</html>