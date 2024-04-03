//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
	var strRes;
	strRes = confirm("終了してよろしいですか？");
	if (strRes==false){
		return;
	}
	with(Form1) {
	var strURL;	
	strURL="../../../COGMNMLG00.aspx";	
	}
	parent.frames("data").location=strURL;		
}
