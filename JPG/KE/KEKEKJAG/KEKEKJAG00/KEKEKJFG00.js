//**************************************
//画面切り替え
//**************************************
function fncJumpURL(strId){
	Form1.hdnJUMP.value=strId;
   	Form1.target="_parent";
	Form1.submit();
	Form1.hdnJUMP.value="";
	Form1.target=""				
}
//**************************************
//引数を対象伝票番号として照会画面へ
//**************************************
function fncJump(strKANSCD,strSYONO){
	Form1.hdnKEY_KANSCD.value = strKANSCD;
    Form1.hdnKEY_SYONO.value = strSYONO;

    Form1.hdnScrollTop.value = document.body.scrollTop;　//スクロール位置　2013/12/10 T.Ono add 監視改善2013

	fncJumpURL("KETAIJAG00");
}