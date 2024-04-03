//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
	//var strRes;
	//strRes = confirm("終了してよろしいですか？");
	//if (strRes==false){
	//	return;
	//}
	var strURL;
	//if(Form1.hdnBackUrl.value=="EIGYOU") {
	//	strURL="../../../COGMENUG00.aspx";
	////--- ↓2005/04/28 ADD Falcon↓ ---
	//} else if (Form1.hdnBackUrl.value=="KANSHI") {
	//	strURL="../../../COGMENUG00.aspx";		 
	////--- ↑2005/04/28 ADD Falcon↑ ---
	//} else {
	//	strURL="../../../COGMNMLG00.aspx";	
	//}	
	
	//strURL = "../../MSTASJAG00/MSTASJAG00.aspx";
	//parent.frames("data").location=strURL;		
	history.back();
	
	//with(Form1){
	//	action = "MSTASJAG00.aspx?CLFLG=";
	//	target = "_parent";
	//	submit();
	//	target = "";
	//}
}
