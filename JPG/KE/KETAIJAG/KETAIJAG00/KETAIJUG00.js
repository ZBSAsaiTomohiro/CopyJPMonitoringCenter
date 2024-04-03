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
    parent.opener.frames('data').Form1.btnCopy.focus();
    window.close();
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl, strFlg) {
    Form1.target = "ifList"
    __doPostBack(strCtl, strFlg);
    Form1.target = ""
}
//**************************************
//選択
//**************************************
function copy(obj) {
    document.getElementById(obj).select();
}