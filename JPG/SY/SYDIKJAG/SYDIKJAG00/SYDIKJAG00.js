//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
}
//*********************************
//submit
//*********************************
function doSubmit(strId){
	Form1.hdnKensaku.value=strId;
	Form1.target="Recv"
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""
}
//**************************************
//戻るボタン押下時の処理
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
//代行設定ボタン押下時の処理
//**************************************
function btnSET_onclick() {
	with(Form1){
		//入力値チェック
		
		//監視センター：必須チェック
		if ((Form1.cboKANSCD.value.length == 0) || (Form1.cboKANSCD.value == "XYZ")) {
			alert('監視センターを選択して下さい');
			Form1.cboKANSCD.focus();
			return false;
		}
		//代行監視センター：必須チェック
		if ((Form1.cboDAIKOKANSCD.value.length == 0) || (Form1.cboDAIKOKANSCD.value == "XYZ")) {
			alert('代行監視センターを選択して下さい');
			Form1.cboDAIKOKANSCD.focus();
			return false;
		}
		//監視センター・代行監視センターが同じ場合エラー
		if ((Form1.cboKANSCD.value) == (Form1.cboDAIKOKANSCD.value)) {
			alert('監視センターと代行監視センターは異なる監視センターを選択して下さい');
			Form1.cboDAIKOKANSCD.focus();
			return false;
		}
	}
	var strRes;
	strRes = confirm("代行設定処理を行います。よろしいですか？");
	if (strRes==false){
		return false;
	}

    //オブジェクトに対するロック処理
	fncDispRoc();
	Form1.hdnMODE.value='1';
	doPostBack('btnSET',''); 

}
//**************************************
//代行解除ボタン押下時の処理
//**************************************
function btnCANCEL_onclick() {
	with(Form1){
		//入力値チェック
		
		//監視センター：必須チェック
		if ((Form1.cboKANSCD.value.length == 0) || (Form1.cboKANSCD.value == "XYZ")) {
			alert('監視センターを選択して下さい');
			Form1.cboKANSCD.focus();
			return false;
		}
	}
	var strRes;
	strRes = confirm("代行解除処理を行います。よろしいですか？");
	if (strRes==false){
		return false;
	}

    //オブジェクトに対するロック処理
	fncDispRoc();
	Form1.hdnMODE.value='2';
	doPostBack('btnCANCEL',''); 
}
//**************************************
//画面項目をロックする(使用不可)
//**************************************
function fncDispRoc() {
	with(Form1) {
		//イベントを持つオブジェクトに対するロック処理
		btnExit.disabled=true;
		btnSET.disabled=true;
		btnCANCEL.disabled=true;
	}
}
