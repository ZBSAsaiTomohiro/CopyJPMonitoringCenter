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
	if (Form1.hdnCODE_MOTO.value == ""){ // 新規？
	    strRes = confirm("登録してよろしいですか？");
	} else if (Form1.hdnCODE.value == Form1.hdnCODE_MOTO.value) { // キーが変わってない？) { // キーが変わってない？
        strRes = confirm("登録してよろしいですか？");
	}else{
		strRes = confirm("コピー登録してよろしいですか？\n※既に登録済みはエラーとなります。");
	}
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
        //監視センターコード検索ボタンロック解除
        btnCODE.disabled = false;
        //担当者コード（From）検索ボタンロック解除
        btnTANCD_F.disabled = false;
        //担当者コード（To）検索ボタンロック解除
        btnTANCD_T.disabled = false;
    }
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	//---------------------------------
	//intKbn  1:検索　2:新規　3:登録/修正 4:削除 5:データ出力
	//---------------------------------
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
	    if ((txtCODE.value == " ") || (txtCODE.value == "")) {
			alert("監視センターコードは必須です");
			btnCODE.focus();
			return false;
		}

//        if ((txtTANCD_T.value != " ") && (txtTANCD_T.value != "")) {
//            if ((txtTANCD_F.value == " ") || (txtTANCD_F.value == "")) {
//                alert("担当者コード（From）を入力してください");
//                btnTANCD_F.focus();
//                return false;
//            }
//        }

//        if ((txtTANCD_F.value != " ") && (txtTANCD_F.value != "")) {
//	        if ((txtTANCD_T.value == " ") || (txtTANCD_T.value == "")) {
//                alert("担当者コード（To）を入力してください");
//                btnTANCD_T.focus();
//			    return false;
//	        }
//		}

        if (intKbn != 5) {
            var x;
            var dupTANCD = null;
            var dupTANCD2 = null;
            var dupTANCD3 = null;
            var dupchk = false;
            for (x = 1; x <= 30; x++) { // 1～30
                dupTANCD = document.getElementById("txtTANCD_" + x);
                if (dupTANCD.value.length != 0) {
                    var y;
                    for (y = x + 1; y <= 30; y++) { // 1～30
                        dupTANCD2 = document.getElementById("txtTANCD_" + y);
                        if (dupTANCD2.value.length != 0) {
                            if (dupTANCD.value == dupTANCD2.value) {
                                dupchk = true;
                                dupTANCD3 = dupTANCD2;
                            }
                        }
                    } // while
                }
            } // while
            if (dupchk) {
                alert("担当者コードが重複しています");
                dupTANCD3.focus();
                return false;
            }
        }

        //以下は　登録/修正時のみ
        if (intKbn == 3) {
            var bExist = false;
            var i;
            for (i = 1; i <= 30; i++) { // 1～30
                objTANCD = document.getElementById("txtTANCD_" + i);
                objTANNM = document.getElementById("txtTANNM_" + i);
                objTANID = document.getElementById("txtTANID_" + i);    //2020/11/01 T.Ono add 2020監視改善
                objDISP_NO = document.getElementById("txtDISP_NO_" + i);
                objBIKO = document.getElementById("txtBIKO_" + i);
                if (objTANCD.value.length != 0
				            || objTANNM.value.length != 0
                            || objDISP_NO.value.length != 0
                            || objBIKO.value.length != 0) {
                    if (objTANCD.value.length == 0) {
                        alert("担当者コードは必須入力です");
                        objTANCD.focus();
                        return false;
                    }
                    if (objTANNM.value.length == 0) {
                        alert("担当者名は必須入力です");
                        objTANNM.focus();
                        return false;
                    }
                    if (fncNumChk(objTANCD.value) == false) {
                        alert("担当者コードは数値を入力してください");
                        objTANCD.focus();
                        return false;
                    }
                    if (jstrlen(objTANCD.value) != 3) {
                        alert("担当者コードは3桁で入力してください");
                        objTANCD.focus();
                        return false;
                    }
                    if (fncNumChk(objDISP_NO.value) == false) {
                        alert("表示順は数値を入力してください");
                        objDISP_NO.focus();
                        return false;
                    }

                    bExist = true; // 値あり！
                } // if
            } // while

            if (bExist == false) { // データが1件も入力されていない？
                objTANCD = document.getElementById("txtTANCD_1");
                if (objTANCD.value == "") { // 新規？
                    alert("データを入力して下さい。");
                    txtTANCD_1.focus();
                    return false;
                }
            }
        } // if 登録時のみ

        //以下は　削除時のみ
        if (intKbn == 4) {

            if (hdnCODE_MOTO.value.length == 0) { // 新規？
                alert("削除対象データがありません。");
                txtTANCD_1.focus();
                return false;
            }
            if (Form1.hdnCODE.value != Form1.hdnCODE_MOTO.value) { // キーが変わっている？
                alert("キーが変更されています。再度検索して下さい。");
                btnCODE.focus();
                return false;
            }
            var bExist = false;
            for (i = 1; i <= 30; i++) { // 1～30
                objDEL = document.getElementById("chkDEL_" + i);
                objTANCD = document.getElementById("txtTANCD_" + i);
                objTANNM = document.getElementById("txtTANNM_" + i);
                objTANID = document.getElementById("txtTANID_" + i);    //2020/11/01 T.Ono add 2020監視改善
                objDISP_NO = document.getElementById("txtDISP_NO_" + i);
                objBIKO = document.getElementById("txtBIKO_" + i);
                if (objTANCD.value.length != 0
				            || objTANNM.value.length != 0
				            || objDISP_NO.value.length != 0
				            || objBIKO.value.length != 0) {
                    
                    if (objTANCD.value.length == 0) {
                        alert("担当者コードは必須入力です");
                        objTANCD.focus();
                        return false;
                    }
                    if (objTANNM.value.length == 0) {
                        alert("担当者名は必須入力です");
                        objTANNM.focus();
                        return false;
                    }
                    if (fncNumChk(objTANCD.value) == false) {
                        alert("担当者コードは数値を入力してください");
                        objTANCD.focus();
                        return false;
                    }
                    if (jstrlen(objTANCD.value) != 3) {
                        alert("担当者コードは3桁で入力してください");
                        objTANCD.focus();
                        return false;
                    }
                    if (objDEL.checked) {
                        bExist = true; // 値あり！
                    }
                }
            }
            if (bExist == false) {
                alert("削除対象データがありません。");
                txtTANCD_1.focus();
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
       ((Form1.txtCODE.value == " ") || (Form1.txtCODE.value == ""))) {
		alert("監視センターコードを選択してください");
		Form1.btnCODE.focus();
//    } else if (strFlg == "3" &&
//       ((Form1.txtTANCD_F.value == " ") || (Form1.txtTANCD_F.value == ""))) {
//        alert("担当者コード（From）を選択してください");
//        Form1.btnTANCD_F.focus();
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
    var nowday = new Date();
    var name = "MSTAKJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
    //var name = "MSTAKJAG00";
    if (wP == null||wP.closed== true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
        wP = parent.fncPopupOpen(name); 
    } else {
        wP.close();
        wP = null;
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
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
		//取消ボタン使用不可
		btnClear.disabled=true;
		//終了ボタン使用不可
		btnExit.disabled=true;
		//監視センターコード検索ボタン使用不可
		btnCODE.disabled=true;
		//担当者コード(From)検索ボタン使用不可
		btnTANCD_F.disabled = true;
		//担当者コード(To)検索ボタン使用不可
		btnTANCD_T.disabled = true;
		//データ出力検索ボタン使用不可
		btnCSVout.disabled = true;
	}
	fncFo(obj,5);
}
//**************************************
//全て選択ボタン押下
//**************************************
function fncAllSelectClick() {
    for (i = 1; i < 31; i = i + 1) {
        document.getElementById("chkDEL_" + i).checked = true;
    }
}
//**************************************
//全て解除ボタン押下
//**************************************
function fncAllRemoveClick() {
    for (i = 1; i < 31; i = i + 1) {
        document.getElementById("chkDEL_" + i).checked = false;
    }
}
//**************************************
// バイト数を返却
//**************************************
function jstrlen(str) {
    var len = 0;
    var i = 0;
    var j = 0;
    var str_str = "";
    str = escape(str);
    for (i = 0; i < str.length; i++, len++) {
        if (str.charAt(i) == "%") {
            if (str.charAt(++i) == "u") {
                str_str = "";
                for (j = 1; j < 5; j++) {
                    str_str = str_str + str.charAt(i + j);
                }
                if ((str_str >= "FF61") && (str_str <= "FF9F")) {
                } else {
                    len++;
                }
                i += 3;
            }
            i++;
        }
    }
    return len;
}