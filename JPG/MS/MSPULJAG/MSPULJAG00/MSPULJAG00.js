window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
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
	strURL="../../../COGMNMSG00.aspx";	
	}
	parent.frames("data").location=strURL;		
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
}
//**************************************
//検索ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
	//入力値チェック-----------キー項目のみチェック
	if(fncDataCheck(1)==false){
		return false;
	}
	//イベントボタンのロック処理
	fncBtnRoc(Form1.btnSelect);
	doPostBack('btnSelect',''); 
}
//**************************************
//新規ボタン押下時の処理
//**************************************
function btnInsert_onclick() {
	//入力値チェック-----------キー項目のみチェック
	if(fncDataCheck(2)==false){
		return false;
	}
	//イベントボタンのロック処理
	fncBtnRoc(Form1.btnInsert);
	doPostBack('btnInsert',''); 
}
//**************************************
//登録ボタン押下時の処理
//**************************************
function btnUpdate_onclick() {
	//入力値チェック-----------キー項目含む全チェック
	if(fncDataCheck(3)==false){
		return false;
	}
	var strRes;
	//確認メッセージ-----------
	if (Form1.btnDelete.disabled == false) {
		//削除ボタンが使用可能⇒検索後⇒修正モード
		Form1.hdnKBN.value = "2";
		strRes = confirm("修正登録してよろしいですか？");
	} else {
		//削除ボタンが使用不可⇒検索前⇒新規モード
		Form1.hdnKBN.value = "1";
		strRes = confirm("新規登録してよろしいですか？");
	}
	if (strRes==false){
		return;
	}
	//イベントボタンのロック処理
	fncBtnRoc(Form1.btnUpdate);
	doPostBack('btnUpdate',''); 
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
	//イベントボタンのロック処理
	fncBtnRoc(Form1.btnDelete);
	doPostBack('btnDelete',''); 
}
//**************************************
//取消ボタン押下時の処理
//**************************************
function btnClear_onclick() {
	var strRes;
	strRes = confirm("取消してよろしいですか？");
	if (strRes==false){
		return;
	}
	//イベントボタンのロック処理
	fncBtnRoc(Form1.btnClear);
	doPostBack('btnClear',''); 
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	//---------------------------------
	//intKbn  1:検索　2:新規　3:登録/修正
	//---------------------------------
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
		//区分：必須
		if (txtKBN.value.length==0) {
			alert("区分は必須入力です");
			txtKBN.focus();
			return false;
		}
		//区分：区分は'00'以外
		if (txtKBN.value == '00') {
			alert("区分は'00'以外を入力して下さい");
			txtKBN.focus();
			return false;
		}
		//コード：必須
		if (txtCD.value.length==0) {
			alert("コードは必須入力です");
			txtCD.focus();
			return false;
		}
		//以下は　登録/修正時のみ
		if (intKbn == 3) {
			//名称：必須
			if (txtNAME.value.length==0) {
				alert("名称は必須入力です");
				txtNAME.focus();
				return false;
			}
			//表示順序：数値
			if (fncNumChk(txtDISP_NO.value.split(",").join("")) == false) {
				alert("表示順序は半角数値で入力して下さい");
				txtDISP_NO.focus();
				return false;
			}
		}
	}
	return true;
}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {
	if (strFlg == "2" && Form1.txtKBN.value.length == 0) {
		alert("区分を入力してください");
		Form1.txtKBN.focus();
	} else {	
		Form1.hdnPopcrtl.value = strFlg;
		fncPop('COPOPUPG00');
	}
}
//**************************************
//コード変更時の名称クリア処理
//**************************************
var KEY_CD;
function fncFcChange(obj,ind) {
	if (obj.readOnly == false) {
		if (ind == 2) {
			KEY_CD = obj.value;
		} else if (ind == 3 && KEY_CD.length != 0 && KEY_CD != obj.value) {
			Form1.txtKBN_NAME.value = "";
			Form1.txtCD.value = "";
		}
		fncFo(obj,ind)
	}
}
//*********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "MSPULJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
	//2014/10/15 H.Hosoda add 2014改善開発 No20 END
	if (wP == null||wP.closed== true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
        wP = parent.fncPopupOpen(name);
    } else {
        wP.close();
        wP = null;
        wP = parent.fncPopupOpen(name);
    }
	wP.focus();
	Form1.hdnKensaku.value=strId;
	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
	Form1.target = name;
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""
}
//**************************************
//イベントボタンに対してロックをかける
//**************************************
function fncBtnRoc(obj) {
	with(Form1){
		//実行ボタン使用不可
		btnUpdate.disabled=true;
		//削除ボタン使用不可
		btnDelete.disabled=true;
		//検索ボタン使用不可
		btnSelect.disabled=true;
		//新規ボタン使用不可
		btnInsert.disabled=true;
		//取消ボタン使用不可
		btnClear.disabled=true;
		//終了ボタン使用不可
		btnExit.disabled=true;
		//区分検索ボタン使用不可
		btnKenKBN.disabled=true;
		//コード検索ボタン使用不可
		btnKenCD.disabled=true;
	}
	fncFo(obj,5);
}