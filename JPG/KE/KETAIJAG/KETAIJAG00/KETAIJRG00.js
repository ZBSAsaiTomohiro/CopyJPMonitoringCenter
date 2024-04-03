//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
    // 2009/01/23 T.Watabe edit
	//var strRes;
	//strRes = confirm("終了してよろしいですか？");
	//if (strRes==false){
	//	return;
	//}
	parent.opener.frames('data').Form1.btnRireki.focus();	
	window.close();
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	Form1.target="ifList"
	__doPostBack(strCtl,strFlg); 
	Form1.target=""
}
//**************************************
//最初押下
//**************************************
function btnFirst_onclick() {
	fncBtnRoc(Form1.btnFirst);
	doPostBack('btnFirst',''); 
}
//**************************************
//前押下
//**************************************
function btnPre_onclick() {
	fncBtnRoc(Form1.btnPre);
	doPostBack('btnPre',''); 
}
//**************************************
//次押下
//**************************************
function btnNex_onclick() {
	fncBtnRoc(Form1.btnNex);
	doPostBack('btnNex','');
}
//**************************************
//最後押下
//**************************************
function btnEnd_onclick() {
	fncBtnRoc(Form1.btnEnd);
	doPostBack('btnEnd','');
}
//**********************************
//イベントボタンに対してロックをかける
//*********************************
function fncBtnRoc(obj) {
	with(Form1){
		btnExit.disabled=true;
		btnFirst.disabled=true;
		btnPre.disabled=true;
		btnNex.disabled=true;
		btnEnd.disabled=true;
	}
	fncFo(obj,5);
}
//**************************************
//印刷押下
//**************************************
function btnPrint_onclick() {
	window.print();
}