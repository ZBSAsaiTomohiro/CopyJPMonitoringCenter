window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
}
//******************************************************************************
// 一般消費者名簿出力
// PGID: SBMEOJAW00.asmx.vb
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
	strRes = confirm("出力してよろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
	if (strRes==false){
		return;
    }

    //document.getElementById("lblStatus").style.visibility = "visible"

	doPostBack('btnSelect','');
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
    var name = "SBMEOJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
//ポップアップ
//**************************************
function btnPopup_onclick(strTrg) {
    
	Form1.hdnPopcrtl.value = strTrg;

	if (strTrg == '2' || strTrg == '3') {
	    fncPop("COPOPUPG00", "600");
	} else {
	    fncPop("COPOPUPG00");
	}
    
	//Form1.hdnPopcrtl.value = "";      //2019/11/01 T.Ono del 監視改善2019
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	with(Form1) {
        //年度
        //桁数チェック
        if (txtNENDO.value.length < 4) {
            alert("年度は4桁で入力してください");
            txtNENDO.focus();
            return false;
        }
        //数字チェック
        if (fncNumChk(txtNENDO.value) == false) {
            alert("年度は数字で入力してください");
            txtNENDO.focus();
            return false;
        }

        //県コード
        //桁数チェック
        if (txtKENCD.value.length < 2) {
            alert("県コードは2桁で入力してください");
            txtKENCD.focus();
            return false;
        }
        //数字チェック
        if (fncNumChk(txtKENCD.value) == false) {
            alert("県コードは数字で入力してください");
            txtKENCD.focus();
            return false;
        }
 	}
}
//**************************************
//確認メッセージによる実行
//**************************************
function fncCheckSubmit(strId){
	with(Form1) {
		hdnKensaku.value=strId;
   		target="Recv";
		submit();
		hdnKensaku.value="";
		target=""				
	}
}
//**************************************
//トリム
//**************************************
function fncTrim(str){
    return str.replace(" ", "");
}
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtKURACD_From.focus()
}
//**************************************
//Toへの自動セット 2019/11/01 T.Ono add 監視改善2019
//**************************************
function fncSetTo() {
    with (Form1) {

        //クライアント名Toセット
        if (hdnPopcrtl.value == '0') {
            hdnKURACD_To.value = "";
            txtKURACD_To.value = "";
            hdnKURACD_To.value = hdnKURACD_From.value;
            txtKURACD_To.value = txtKURACD_From.value;
        }

        //販売店Toセット
        if (hdnPopcrtl.value == '2') {
            txtHANTENCD_To.value = "";
            hdnHANTENCD_To.value = "";

            txtHANTENCD_To.value = txtHANTENCD_From.value;
            hdnHANTENCD_To.value = hdnHANTENCD_From.value;
        }
    }
}