//**************************************
//画面オープン時
//**************************************
function window_open() {
	with(Form1) {
		//画面の初期設定（区分に合わせた出力エリアの表示内容制御)
		if (rdoKBN1.checked==true) {
			fncTanto(rdoKBN1,1);
		} else if (rdoKBN2.checked==true){
			fncTanto(rdoKBN2,1);
		} else {
			fncTanto(rdoKBN3,1);	
		}
	}
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	with(Form1) {
		if (rdoKBN1.checked==true) {
			hdnTANKBN.value = "1";		
		} else if (rdoKBN2.checked==true) {
			hdnTANKBN.value = "2";
		} else {
			hdnTANKBN.value = "3";
		}
	}
	__doPostBack(strCtl,strFlg); 
	Form1.hdnTANKBN.value = "";	
}
//**************************************
//検索ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
	//入力値チェック-----------
	if(fncDataCheck(1)==false){
		return false;
	}
	fncBtnRoc(Form1.btnSelect);
	doPostBack('btnSelect',''); 
}
//**************************************
//新規ボタン押下時の処理
//**************************************
function btnInsert_onclick() {
	//入力値チェック-----------
	if(fncDataCheck(2)==false){
		return false;
	}
	fncBtnRoc(Form1.btnInsert);
	doPostBack('btnInsert',''); 
}
//**************************************
//登録ボタン押下時の処理
//**************************************
function btnUpdate_onclick() {
	//入力値チェック-----------
	if(fncDataCheck(3)==false){
		return false;
	}
	var strRes;
	//確認メッセージ-----------
	if (Form1.btnDelete.disabled == false) {
		//削除ボタンが使用可能⇒検索後
		//修正モード	
		Form1.hdnKBN.value = "2";
		strRes = confirm("修正登録してよろしいですか？");
	} else {
		//削除ボタンが使用不可⇒検索前
		//新規モード	
		Form1.hdnKBN.value = "1";
		strRes = confirm("新規登録してよろしいですか？");
	}
	if (strRes==false){
		return;
	}
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
	fncBtnRoc(Form1.btnClear);
	doPostBack('btnClear',''); 
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
	var strURL;
	if (Form1.hdnBackUrl.value == "EIGYOU") {
	    strURL = "../../../COGMENUG00.aspx";
	//--- ↓2005/04/28 ADD Falcon↓ ---
	} else if (Form1.hdnBackUrl.value=="KANSHI") {
		strURL="../../../COGMENUG00.aspx";		 
	//--- ↑2005/04/28 ADD Falcon↑ ---
	} else {
		strURL="../../../COGMNMSG00.aspx";	
	}
	parent.frames("data").location=strURL;		
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
		if (rdoKBN1.checked==true) {
		    //if (hdnKURACD.value.length==0) {                              //2012/04/19 NEC ou Del
		    if ((txtKURACD.value == " ") || (txtKURACD.value == "")) {      //2012/04/19 NEC ou Add
				alert("ＪＡ支所担当者の場合、クライアントコードは必須です");
				btnKURACD.focus();
				return false;
			}
		}
		//コード：必須
        //if (hdnCODE.value.length==0) {                                    //2012/04/19 NEC ou Del
        if ((txtCODE.value == " ") || (txtCODE.value == "")) {              //2012/04/19 NEC ou Add
			alert("コードは必須入力です");
			btnCODECD.focus();
			return false;
		}
		//担当者コード
		if (txtTANCD.value.length==0) {
			alert("担当者コードは必須入力です");
			txtTANCD.focus();
			return false;
		}
		//ＪＡ支所担当者コードは1～4で入力してください
		if (rdoKBN1.checked==true) {
			if (fncNumChk(txtTANCD.value) == false) {
				alert("ＪＡ支所担当者コードは1～4で入力してください");
				txtTANCD.focus();
				return false;
			}
			if ((parseInt(txtTANCD.value)<1) || (parseInt(txtTANCD.value)>4)) {
				alert("ＪＡ支所担当者コードは1～4で入力してください");
				txtTANCD.focus();
				return false;
			}
		}		
		//以下は　登録/修正時のみ
		if (intKbn == 3) {
			//担当名漢字
			if (txtTANNM.value.length==0) {
				alert("担当名漢字は必須入力です");
				txtTANNM.focus();
				return false;
			}
			//電話番号１：必須チェック(ＪＡ担当者)
			if (rdoKBN1.checked==true) {
				if (txtRENTEL1.value.length==0) {
					alert("ＪＡ支所担当者の場合、電話番号１は必須です");
					txtRENTEL1.focus();
					return false;
				}
			}
			//電話番号１：電話番号チェック
			if (fncChkTel(txtRENTEL1.value) == false) {
				alert("電話番号１は正しい電話番号ではありません");
				txtRENTEL1.focus();
				return false;
			}
			//電話番号２：電話番号チェック
			if (fncChkTel(txtRENTEL2.value) == false) {
				alert("電話番号２は正しい電話番号ではありません");
				txtRENTEL2.focus();
				return false;
			}
			//ＦＡＸ番号：電話番号チェック
			if (fncChkTel(txtFAXNO.value) == false) {
				alert("ＦＡＸ番号は正しいＦＡＸ番号ではありません");
				txtFAXNO.focus();
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
//担当者区分が変更された時
//**************************************
function fncTanto(obj,ind) {
	if (ind == "0"){
		fncClearTanto()
	}
	if (obj.value=="1") {
		//ＪＡ支所担当者
		if(ind == "0"){
			Form1.btnKURACD.disabled=false;
		}
		sp1.style.visibility="visible";
		lblCODE.innerText="ＪＡ支所コード";	
	} else if (obj.value=="2") {
		//監視センター担当者
		if(ind == "0"){
			Form1.btnKURACD.disabled=true;
		}
		sp1.style.visibility="hidden";
		lblCODE.innerText="監視センターコード";
	} else if (obj.value=="3") {
		//出動会社担当者
		if(ind == "0"){
			Form1.btnKURACD.disabled=true;	
		}
		sp1.style.visibility="hidden";
		lblCODE.innerText="出動会社コード";
	}
}
//**************************************
//担当者区分が変更時の値クリア
//**************************************
function fncClearTanto() {
	with(Form1) {
		txtKURACD.value='';
		hdnKURACD.value='';		
		hdnCODE.value='';
		txtCODE.value='';
	}
}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {
    //2012/04/19 NEC ou Upd
	//if (Form1.rdoKBN1.checked == true && strFlg == "2" && Form1.hdnKURACD.value.length == 0) {
    if (Form1.rdoKBN1.checked == true && strFlg == "2" &&
        ((Form1.txtKURACD.value == " ") || (Form1.txtKURACD.value == ""))) {
		alert("クライアントコードを選択してください");
		Form1.btnKURACD.focus();
	} else {
		with(Form1) {	
			if (rdoKBN1.checked==true) {
				hdnTANKBN.value = "1";		
			} else if (rdoKBN2.checked==true) {
				hdnTANKBN.value = "2";
			} else {
				hdnTANKBN.value = "3";
			}
		}
		Form1.hdnPopcrtl.value = strFlg;
		fncPop('COPOPUPG00');
	}
}
//*********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId){
	if (wP == null||wP.closed== true) {
		wP=parent.fncPopupOpen();
	}
	wP.focus();
	Form1.hdnKensaku.value=strId;
	Form1.target="wP"
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
		//クライアントコード検索ボタン使用不可
		btnKURACD.disabled=true;
		//コード検索ボタン使用不可
		btnCODECD.disabled=true;
	}
	fncFo(obj,5);
}
