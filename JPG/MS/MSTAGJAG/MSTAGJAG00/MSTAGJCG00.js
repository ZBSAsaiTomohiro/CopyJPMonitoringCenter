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
//*********************************
//選択
//**************************************
function copy(obj) {
    var s = document.selection;
    var range = document.selection.createRange();
    range.moveToElementText(document.getElementById(obj));
    range.select();
}