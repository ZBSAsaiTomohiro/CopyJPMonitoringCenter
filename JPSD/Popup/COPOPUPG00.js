//**************************************
//IFRAME出力処理
//**************************************
function fncListOut(strId,strTrg){
	Form1.hdnKensaku.value=strId;
    Form1.target=strTrg;
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""				
}
//**************************************
//検索ボタン押下後の処理
//**************************************
function btnSelect_onclick(strTrg) {
	fncListOut(strTrg,"ifList1");
}
//**************************************
//テキストボックスにてENTERキー押下後の処理(テキストが１つのとき)
//**************************************
function fncEnter(strTrg) {
	if (event.keyCode == 13) {
		fncListOut(strTrg,"ifList1");
	}
}