window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
}
//******************************************************************************
// 一般消費者名簿取込
// PGID: SBMEIJAW00.asmx.vb
//******************************************************************************
// 変更履歴

//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
}
//**************************************
//出力ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
	//入力値チェック
	if(fncDataCheck(1)==false){
		return false;
	}
	
	var strRes;
	strRes = confirm("取込を行います。よろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
	if (strRes==false){
		return;
	}

    document.getElementById("Table9").style.visibility = "visible"

    doPostBack('btnSelect', '');
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
		strURL="../../../COGMNMEG00.aspx";
	}
	parent.frames("Data").location=strURL;		
}
//**********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId, strOptwidth) {
    if (typeof strOptwidth === 'undefined') strOptwidth = "400";
    var nowday = new Date();
    var name = "SBMEIJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
    if (wP == null || wP.closed == true) {
        wP = parent.fncPopupOpen(name, strOptwidth);
    } else {
        wP.close();
        wP = null;
        wP = parent.fncPopupOpen(name, strOptwidth);
    }
    wP.focus();
    Form1.hdnKensaku.value = strId;
    Form1.target = name;
    Form1.submit();
    Form1.hdnKensaku.value = "";
    Form1.target = ""
}

//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	with(Form1) {

        //年度
        //桁数チェック
        if (txtNENDO.value.length < 4){
            alert("年度は4桁で入力してください");
            Form1.txtNENDO.focus();
            return false;
        }
        //数字チェック
        if (fncNumChk(txtNENDO.value) == false) {
            alert("年度は数字で入力してください");
            Form1.txtNENDO.focus();
            return false;
        }

        //対象ファイル
        //未選択チェック
        if (FileUpload1.value.length == 0) {
            alert("対象ファイルを選択してください");
            Form1.btnSelect.focus();
            return false;
        }
	}
}


function fncTrim(str){
    return str.replace(" ", "");
}

