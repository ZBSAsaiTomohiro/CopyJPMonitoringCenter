window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
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
	//入力値チェック-----------
	if(fncDataCheck(1)==false){
		return false;
	}
	fncBtnRoc(Form1.btnSelect);
	
    doPostBack('btnSelect','');
}
//**************************************
//全て選択/解除ボタン押下
//**************************************
function btnCheckBtn(btn) {
    if (btn == "1") {
        for (i = 1; i <= 50; i++) { // 1～30
            document.getElementById("chkDEL_" + i).checked = true;
        }
    } else if (btn == "2") {
        for (i = 1; i <= 50; i++) { // 1～30
            document.getElementById("chkDEL_" + i).checked = false;
        }
    }
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
	Form1.hdnKBN.value = "1"; // 1:登録
	strRes = confirm("登録してよろしいですか？");
	if (strRes == false){
		return;
	}
	fncBtnRoc(Form1.btnUpdate);
	doPostBack('btnUpdate',''); 
}
//**************************************
//削除ボタン押下時の処理
//**************************************
function btnDelete_onclick() {
	//入力値チェック-----------
	if(fncDataCheck(4)==false){ // 4:削除
		return false;
	}
	var strRes;
	//確認メッセージ-----------
	Form1.hdnKBN.value = "4"; // 4:削除
	strRes = confirm("削除してよろしいですか？");
	if (strRes == false){
		return;
	}
	fncBtnRoc(Form1.btnUpdate);
	doPostBack('btnUpdate','');
}
//**************************************
//データ出力ボタン押下時の処理
//**************************************
function btnCsv_onclick() {
    //入力値チェック-----------
    if (fncDataCheck(5) == false) { // 5:データ出力
        return false;
    }
    var strRes;
    //確認メッセージ-----------
    Form1.hdnKBN.value = "5"; // 5:データ出力
    strRes = confirm("データ出力してよろしいですか？");
    if (strRes == false) {
        return;
    }
    fncBtnRoc(Form1.btnCSVout);
    doPostBack('btnCSVout', '');
    with (Form1) {
        //実行ボタンロック解除
        btnUpdate.disabled = false;
        //削除ボタンロック解除
        btnDelete.disabled = false;
        //検索ボタンロック解除
        btnSelect.disabled = false;
        //取消ボタンロック解除
        btnClear.disabled = false;
        //終了ボタンロック解除
        btnExit.disabled = false;
        //データ出力ボタンロック解除
        btnCSVout.disabled = false;
        //一括登録ボタンロック解除
        btnIkkatu.disabled = false;
        //クライアントコード検索ボタンロック解除
        btnKURACD.disabled = false;
        //JA支所コード（From）検索ボタンロック解除
        btnACBCD_F.disabled = false;
        //JA支所コード（To）検索ボタンロック解除
        btnACBCD_T.disabled = false;
    }
}
//**************************************
//一括登録ボタン押下時の処理
//**************************************
function btnikkatu_onclick() {
    //入力値チェック-----------
    if (fncDataCheck(6) == false) {
        return false;
    }
    var strRes;
    //確認メッセージ----------- 
    Form1.hdnKBN.value = "1"; // 1:登録
        if ((Form1.hdnKURACD.value != "") || (Form1.hdnKURACD.value != " ")){
            strRes = confirm("登録してよろしいですか？");
        }
    	if (strRes == false){
    		return;
    	}
    fncBtnRoc(Form1.btnUpdate);
    doPostBack('btnikkatu', '');
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
	strURL = "../../../COGMNMSG00.aspx";
	parent.frames("data").location=strURL;		
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	//---------------------------------
	//intKbn  1:検索　3:登録/修正 4:削除 5:データ出力 6:一括登録
	//---------------------------------
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
        //検索時
	    if (intKbn == 1) {
	        if (((txtKURACD.value == " ") || (txtKURACD.value == "")) 
                && (hdnGROUPCD.value.length == " ")){
	            alert("検索条件を指定してください");
	            btnKURACD.focus();
	            return false;
	        }
//	        if ((hdnACBCD_F.value != "" && hdnACBCD_F.value != " ")
//                && (hdnACBCD_T.value == "" || hdnACBCD_T.value == " ")) {
//                alert("JA支所コード（To）を指定してください");
//	            btnACBCD_T.focus();
//	            return false;
//	        }
	    }
        
        //一括登録時
        if (intKbn == 6) {
            if ((txtKURACD.value == " ") || (txtKURACD.value == "")) {
	            alert("クライアントコードは必須です");
	            btnKURACD.focus();
	            return false;
	        }
	        if (hdnGROUPCD.value.length == " ") {
	            alert("グループコードは必須です");
	            cboGROUPCD.focus();
	            return false;
	        }
//	        if ((hdnACBCD_F.value != "" && hdnACBCD_F.value != " ")
//                && (hdnACBCD_T.value == "" || hdnACBCD_T.value == " ")) {
//	            alert("JA支所コード（To）を指定してください");
//	            btnACBCD_T.focus();
//	            return false;
//	        }
	    }

	    //登録/修正、削除時
	    if ((intKbn == 3) || (intKbn == 4)) {
	        var x;
	        var dupKURACD1 = null;
	        var dupACBCD1 = null;
	        var dupKURACD2 = null;
	        var dupACBCD2 = null;
	        var dupKURACD3 = null;
	        var dupchk = false;
	        for (x = 1; x <= 50; x++) { // 1～50
	            dupKURACD1 = document.getElementById("txtKURACD_" + x);
	            dupACBCD1 = document.getElementById("txtACBCD_" + x);
	            if (dupKURACD1.value.length != 0) {
	                var y;
	                for (y = x + 1; y <= 50; y++) { // 1～50
	                    dupKURACD2 = document.getElementById("txtKURACD_" + y);
	                    dupACBCD2 = document.getElementById("txtACBCD_" + y);
	                    if (dupKURACD2.value.length != 0) {
	                        if ((dupKURACD1.value + dupACBCD1.value) == (dupKURACD2.value + dupACBCD2.value)) {
	                            dupchk = true;
	                            dupKURACD3 = dupKURACD2;
	                        }
	                    }
	                } // while
	            }
	        } // while
	        if (dupchk) {
	            alert("クライアントコード・JA支所コードが重複しています。");
	            dupKURACD3.focus();
	            return false;
	        }
	    }
		
        //登録/修正時のみ
		if (intKbn == 3) {
			
			var bExist = false;
			var i;
			for (i = 1; i <= 50; i++) { // 1～30
			    var objKURACD = document.getElementById("txtKURACD_" + i);
			    var objACBCD = document.getElementById("txtACBCD_" + i);
				var select = document.getElementById('cboGROUPCD_' + i);
				var options = document.getElementById('cboGROUPCD_' + i).options;
				var varGROUPCD = options.item(select.selectedIndex).text;
				var objGROUPCD = document.getElementById("cboGROUPCD_" + i);
				var objBIKO = document.getElementById("txtBIKO_" + i);

				if (objKURACD.value.length != 0
				    || objACBCD.value.length != 0
                    || varGROUPCD.length != 0
                    || objBIKO.value.length != 0) {

				    if (objKURACD.value.length == 0) {
                        alert("クライアントコードは必須入力です");
                        objKURACD.focus();
						return false;
					}
		            if (objACBCD.value.length == 0) {
		                alert("JA支所コードは必須入力です");
		                objACBCD.focus();
		                return false;
		            }
		            if (varGROUPCD.length == 0) {
		                alert("グループコードは必須入力です");
		                objGROUPCD.focus();
		                return false;
		            }

					bExist = true; // 値あり！
				} // if
			}// while
			
			if (bExist == false){ // データが1件も入力されていない？
			    if (txtKURACD_1.value == ""){ // 新規？
			        alert("データを入力して下さい。");
			        txtKURACD_1.focus();
					return false;
			    }
			}
    	} // if 登録時のみ

		//以下は　削除時のみ
		if (intKbn == 4) {

		    if ((hdnKURACD_MOTO.value.length == 0) && (hdnGROUPCD_MOTO.value.length == 0)) { // 新規？
		        alert("削除対象データがありません。");
		        txtKURACD_1.focus();
		        return false;
		    }
            
            if ((hdnKURACD.value == " " || hdnKURACD.value == "") 
                && (hdnKURACD_MOTO.value == "" || hdnKURACD_MOTO.value == " ")){ //クライアントコード未選択時を考慮
                if (hdnGROUPCD.value != hdnGROUPCD_MOTO.value) { // キーが変わっている？
				    alert("キーが変更されています。再度検索して下さい。");
				    btnKURACD.focus();
                    return false;
			    }

            }else{
                if (hdnKURACD.value != hdnKURACD_MOTO.value
                    || hdnGROUPCD.value != hdnGROUPCD_MOTO.value) { // キーが変わっている？
				    alert("キーが変更されています。再度検索して下さい。");
				    btnKURACD.focus();
                    return false;
			    }
            }

            var bExist = false;
            for (i = 1; i <= 50; i++) { // 1～50
                var objDEL = document.getElementById("chkDEL_" + i);
                var objKURACD = document.getElementById("txtKURACD_" + i);
                var objACBCD = document.getElementById("txtACBCD_" + i);
                var select = document.getElementById('cboGROUPCD_' + i);
                var options = document.getElementById('cboGROUPCD_' + i).options;
                var varGROUPCD = options.item(select.selectedIndex).text;
                var objGROUPCD = document.getElementById("cboGROUPCD_" + i);

                if (objKURACD.value.length != 0
                	&& objACBCD.value.length != 0
                    && varGROUPCD.length != 0 ) {

                	if (objDEL.checked) {
                		bExist = true; // 値あり！
                    }
                }
            }
			if (bExist == false) {
			    alert("削除対象データがありません。");
			    txtKURACD_1.focus();
			    return false;
			}
		} // if 削除時のみ
	} // with
	return true;
}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {

    if ((strFlg == "2" || strFlg == "3") &&
        (Form1.txtKURACD.value == " " || Form1.txtKURACD.value == "")) {
		alert("クライアントコードを選択してください");
		Form1.btnKURACD.focus();
//    } else if ((strFlg == "3") &&
//        ((Form1.txtACBCD_F.value == " ") || (Form1.txtACBCD_F.value == ""))) {
//        alert("JA支所コード（From）を選択してください");
//		Form1.btnACBCD_F.focus();

	} else {
		Form1.hdnPopcrtl.value = strFlg;
		fncPop('COPOPUPG00');
	}
}
//*********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "MSJIGJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
		btnDelete.disabled = true;
		//検索ボタン使用不可
		btnSelect.disabled=true;
		//新規ボタン使用不可
		//btnInsert.disabled=true;
		//取消ボタン使用不可
		btnClear.disabled=true;
		//終了ボタン使用不可
		btnExit.disabled=true;
		//データ出力ボタン使用不可
		btnCSVout.disabled = true;
        //一括登録ボタン使用不可
		btnIkkatu.disabled = true;
		//クライアントコード検索ボタン使用不可
		btnKURACD.disabled = true;
		//JA支所コード（From）検索ボタン使用不可
		btnACBCD_F.disabled = true;
		//JA支所コード（To）検索ボタン使用不可
		btnACBCD_T.disabled = true;
		//一括登録ボタン使用不可
		btnIkkatu.disabled = true;
	}
	fncFo(obj,5);
}
//**************************************
//グループコードを取得
//**************************************
function fncChengGroup() {

    var select = document.getElementById('cboGROUPCD');
    var options = document.getElementById('cboGROUPCD').options;
    Form1.hdnGROUPCD.value = options.item(select.selectedIndex).text;

}
