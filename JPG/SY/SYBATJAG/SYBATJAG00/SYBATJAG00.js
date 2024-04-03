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
		strURL="../../../COGMNSSG00.aspx";	
	}
	parent.frames("data").location=strURL;		
}
//**************************************
//画面オープン時
//**************************************
function window_open() {
	with(Form1) {
		if (rdoKBN1.checked == true) {
			rdoKBN1.focus();
		} else if (rdoKBN2.checked == true) {
			rdoKBN2.focus();
		} else if (rdoKBN3.checked == true) {
			rdoKBN3.focus();
		}
	}
	fncListOut('SYBATJFG00');	
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
//検索ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
	//入力値チェック-----------
	with(Form1) {				
		//対象日付From：必須チェック
		if (txtTRGDATE_From.value.length == 0) {
			alert("対象日付Fromは必須入力です");
			txtTRGDATE_From.focus();
			return false;
		}	
		//対象日付From：日付チェック
		if (fncChkDate(txtTRGDATE_From.value) == false) {
			alert("対象日付Fromは正しい日付ではありません");
			txtTRGDATE_From.focus();
			return false;
		}
		//対象日付To：必須チェック
		if (txtTRGDATE_To.value.length == 0) {
			alert("対象日付Toは必須入力です");
			txtTRGDATE_To.focus();
			return false;
		}	
		//対象日付To：日付チェック
		if (fncChkDate(txtTRGDATE_To.value) == false) {
			alert("対象日付Toは正しい日付ではありません");
			txtTRGDATE_To.focus();
			return false;
		}
		//対象日付のFrom～Toチェック
		if((txtTRGDATE_From.value.length != 0) && (txtTRGDATE_To.value.length != 0)) {
			if((txtTRGDATE_From.value.split("/").join("") > txtTRGDATE_To.value.split("/").join(""))) {
				alert("対象日付Toは対象日付Fromより先の日付を入力してください");
				txtTRGDATE_To.focus();
				return false;
			}
		}
	}
	//イベントを持つオブジェクトに対するロック処理
	Form1.btnSelect.disabled=true;
	Form1.btnExit.disabled=true;
	fncFo(Form1.btnSelect,5);

	Form1.hdnSelectClick.value="1";
	fncListOut('SYBATJFG00');
	Form1.hdnSelectClick.value="";	
}

//2013/12/06 T.Ono add 監視改善2013
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtTRGDATE_From.focus()
}