//**************************************
//画面オープン時
//**************************************
function window_onload() {
	//画面サイズの指定
	window.resizeTo(550,580);  
	//一覧の表示
	fncListOut('KEKESJFG00');
}
//**************************************
//一覧表示
//**************************************
function fncListOut(strId){
	Form1.hdnKenSaku.value=strId;
	Form1.target="ifList";
	Form1.submit();
	Form1.hdnKenSaku.value="";
	Form1.target=""       
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
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
	window.close();
}
//**************************************
//削除ボタン押下時の処理
//**************************************
function btnDelete_onclick() {
	var strRes;
	strRes = confirm("削除してよろしいですか？");
	if (strRes==false){
		return;
	}
	var indDel = 0;
	Form1.hdnDelKey.value = "";
	for (i=1; i<=ifList.Form1.hdnDataCnt.value; i++) {
		//削除チェックのついたキーを取得
		if (ifList.Form1.elements['chkDel'+i].checked == true) {
			if (indDel > 0) {
				Form1.hdnDelKey.value = Form1.hdnDelKey.value + ','
			}
			Form1.hdnDelKey.value = Form1.hdnDelKey.value + ifList.Form1.elements['hdnKey'+i].value;
			indDel += 1;
		}	
	}
	if (indDel == 0) {
		alert("削除データが選択されていません");
		return;
	}
	//イベントボタンのロック処理
	//削除ボタン使用不可
	Form1.btnDelete.disabled=true;
	Form1.btnExit.disabled=true;
	Form1.hdnDelCnt.value = indDel;
	//<TEST用>：alert(Form1.hdnDelCnt.value + '件削除：' + Form1.hdnDelKey.value);	//削除対象データのキー(カンマ編集)
	//doPostBack("btnDelete");       //2012/04/24 NEC ou Del
	doPostBack("btnDelete", "");     //2012/04/24 NEC ou Add
}


