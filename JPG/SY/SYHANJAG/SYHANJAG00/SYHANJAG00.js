//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
}
//**************************************
//登録ボタン押下時の処理
//**************************************
function btnJikkou_onclick() {
	//入力値チェック-----------
	if(fncDataCheck()==false){
		return false;
	}
	var strRes;
	strRes = confirm("実行してよろしいですか？");			
	if (strRes==false){
		return;
	}
	Form1.btnExit.disabled=true;
	Form1.btnJikkou.disabled=true;
	Form1.target="Recv";
	doPostBack('btnJikkou','');
	Form1.target="";
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
	strURL="../../../COGMENUG00.aspx";
	parent.frames("data").location=strURL;		
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck() {
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
		//県：必須チェック
		if ((cboKENCD.value.length == 0) || (cboKENCD.value == "XYZ")) {
			alert('県を選択して下さい');
			cboKENCD.focus();
			return false;
		}
		//再作成で対応年月が未登録の場合は実行できない
		if ((rdoKBN2.checked == true) && (txtTAISYO.value.length==0)) {
			alert('前回処理しているデータが存在しない為、再作成は行えません');
			cboKENCD.focus();
			return false;
		}
		//集計期間Ｔ：必須チェック
		if (txtSYUKEIT.value.length==0) {
			alert("集計期間Toを入力してください");
			txtSYUKEIT.focus();
			return false;
		}
		//集計期間Ｔの日付チェック
		if (fncChkDate(txtSYUKEIT.value)==false) {
			alert("集計期間Toは正しい日付ではありません");
			txtSYUKEIT.focus();
			return false;
		}
		//集計期間のFrom～Toチェック
		if((txtSYUKEIF.value.length != 0) && (txtSYUKEIT.value.length != 0)) {
			if((txtSYUKEIF.value.split("/").join("") > txtSYUKEIT.value.split("/").join(""))) {
				alert("集計期間Toは集計期間Fromより先の日付を入力してください");
				txtSYUKEIT.focus();
				return false;
			}
		}
	}
	return true;
}
//**************************************
//県コンボ変更時
//**************************************
function cboKen_change() {
	with(Form1) {	 
		if ((cboKENCD.value=="XYZ") || (cboKENCD.value.length==0)) {
			txtTAISYO.value="";
			txtSYUKEIF.value="";
			txtSYUKEIT.value="";
			//県情報の削除
			hdnTAISYO.value="";
			hdnTAISYOP1.value="";
			hdnSYUKEIF.value="";
			hdnSYUKEIT.value="";
			hdnSYUKEIFP1.value="";
			hdnSYUKEITP1.value="";
		} else {
			//--- ↓2005/05/16 ADD Falcon↓ ---
			btnJikkou.disabled=true;		//実行ボタン使用不可
			//--- ↑2005/05/16 ADD Falcon↑ ---

			hdnKensaku.value = "SYHANJKG00";
			target="Recv";
			doPostBack('cboKENCD','');
			target="";
			hdnKensaku.value = "";
		}
	}

}
//**************************************
//作成区分変更時
//**************************************
function fncKbnChange() {
	with(Form1) {
		if (rdoKBN1.checked==true) {
			txtTAISYO.value =fncDateSlaYM(hdnTAISYOP1.value);		//'今回
			txtSYUKEIF.value=fncDateSla(hdnSYUKEIFP1.value);		//'今回
			txtSYUKEIT.value=fncDateSla(hdnSYUKEITP1.value);		//
			
			txtSYUKEIT.style.backgroundColor='LightPink';
			txtSYUKEIT.readOnly=false;
		} else {
			txtTAISYO.value=fncDateSlaYM(hdnTAISYO.value);
			txtSYUKEIF.value=fncDateSla(hdnSYUKEIF.value);
			txtSYUKEIT.value=fncDateSla(hdnSYUKEIT.value);

			txtSYUKEIT.style.backgroundColor='Gainsboro';			
			txtSYUKEIT.readOnly=true;
		}
	
	}
}