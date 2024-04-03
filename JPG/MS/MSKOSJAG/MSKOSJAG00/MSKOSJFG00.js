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
//引数を対象伝票番号として入力・照会画面へ
//**************************************
function fncJump(strCLI_CD,strHAN_CD,strUSER_CD){
	Form1.hdnKEY_CLI_CD.value = strCLI_CD;
	Form1.hdnKEY_HAN_CD.value = strHAN_CD;
	Form1.hdnKEY_USER_CD.value = strUSER_CD;

	Form1.hdnScrollTop.value = document.body.scrollTop;

	fncJumpURL("KETAIJAG00");
}