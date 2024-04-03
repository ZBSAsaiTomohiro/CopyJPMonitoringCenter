//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
}
//**************************************
//実行ボタン押下時の処理
//**************************************
function btnJikkou_onclick() {
	//確認メッセージ-----------
	var strRes;
	strRes = confirm("実行してよろしいですか？");
	if (strRes==false){
		return;
	}
	Form1.btnExit.disabled=true;
	Form1.target="Recv";
	doPostBack('btnJikkou','');
	Form1.target="";
}
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
		strURL="../../../COGMNSSG00.aspx";	
	}
	parent.frames("data").location=strURL;		
}
