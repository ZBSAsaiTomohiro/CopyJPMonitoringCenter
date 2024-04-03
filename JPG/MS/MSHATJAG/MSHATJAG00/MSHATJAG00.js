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
    strRes = confirm("登録してよろしいですか？");
    if (strRes == false) {
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
    strURL = "../../../COGMNMEG00.aspx";
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
    fncBtnRoc(Form1.btnCSVOUT);
    doPostBack('btnCSVOUT', '');
    fncBtnUnRoc(Form1.btnCSVOUT);
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
    with (Form1) {

        //登録/修正、削除時
        if ((intKbn == 3) || (intKbn == 4)) {
        
            //入力データの重複確認
            var x;
            var dupTARGET1 = null;
            var dupGROUPCD1 = null;
            var strGROUPCD1 = "";
            var dupTARGET2 = null;
            var dupGROUPCD2 = null;
            var strGROUPCD2 = "";
            var dupGROUPCD3 = null;
            var dupchk = false;

            for (x = 1; x <= 100; x++) { // 1～100        
                dupTARGET1 = document.getElementById("chkTARGET_" + x);
                dupGROUPCD1 = document.getElementById("txtGROUPCD_" + x);
                strGROUPCD1 = dupGROUPCD1.value.replace(/(^\s+)|(\s+$)/g, "")
                if ((dupTARGET1.checked == true) && (strGROUPCD1.length != 0)) {
                    var y;
                    for (y = x + 1; y <= 100; y++) { // 1～100
                        dupTARGET2 = document.getElementById("chkTARGET_" + y);
                        dupGROUPCD2 = document.getElementById("txtGROUPCD_" + y);
                        strGROUPCD2 = dupGROUPCD2.value.replace(/(^\s+)|(\s+$)/g, "");
                        if ((dupTARGET2.checked == true) && (strGROUPCD2.length != 0)) {
                            if (strGROUPCD1 == strGROUPCD2) {
                                dupchk = true;
                                dupGROUPCD3 = dupGROUPCD2;
                            }
                        }
                    } // while
                }
            } // while
            if (dupchk) {
                alert("グループコードが重複しています。");
                dupGROUPCD3.focus();
                return false;
            }
        }


        //以下は　登録/修正時のみ
        if (intKbn == 3) {
            //必須項目の確認
            var bExist = false;
            var i;
            for (i = 1; i <= 100; i++) { // 1～100
                var objTARGET = document.getElementById("chkTARGET_" + i);
                //グループコード
                var objGROUPCD = document.getElementById("txtGROUPCD_" + i);
                var strGROUPCD = objGROUPCD.value.replace(/(^\s+)|(\s+$)/g, "");
                //グループコード名
                var objGROUPNM = document.getElementById("txtGROUPNM_" + i);
                var strGROUPNM = objGROUPNM.value.replace(/(^\s+)|(\s+$)/g, "");
                //グループコード
                var objHANBAITENNM = document.getElementById("txtHANBAITENNM_" + i);
                var strHANBAITENNM = objHANBAITENNM.value.replace(/(^\s+)|(\s+$)/g, "");
                //備考
                var objBIKO = document.getElementById("txtBIKO_" + i);
                var strBIKO = objBIKO.value.replace(/(^\s+)|(\s+$)/g, "");

                if ((objTARGET.checked == true)
                    && (strGROUPCD.length != 0
				    || strGROUPNM.length != 0
                    || strHANBAITENNM.length != 0
                    || strBIKO.length != 0)) {

                    //グループコード(必須チェック)
                    if (strGROUPCD.length == 0) {
                        alert("グループコードは必須入力です");
                        objGROUPCD.focus();
                        return false;
                    }
                    //グループコード名(必須チェック)
                    if (strGROUPNM.length == 0) {
                        alert("グループコード名は必須入力です");
                        objGROUPNM.focus();
                        return false;
                    }
                    //販売店名(必須チェック)
                    if (strHANBAITENNM.length == 0) {
                        alert("販売店名は必須入力です");
                        objHANBAITENNM.focus();
                        return false;
                    }

                    //グループコード(全角チェック)
                    if (fncZenkakuChk(strGROUPCD) == true) {
                        alert("グループコードは半角で入力して下さい");
                        objGROUPCD.focus();
                        return false;
                    }
                    //グループコード名(レングスチェック)
                    if (fncGetByte(strGROUPNM) > 60) {
                        alert("グループコード名は全角30文字以内で入力して下さい");
                        objGROUPNM.focus();
                        return false;
                    }
                    //販売店名(レングスチェック)
                    if (fncGetByte(strHANBAITENNM) > 100) {
                        alert("販売店名は全角50文字以内で入力して下さい");
                        objHANBAITENNM.focus();
                        return false;
                    }
                    //備考(レングスチェック)
                    if (fncGetByte(strBIKO) > 200) {
                        alert("備考は全角100文字以内で入力して下さい");
                        objBIKO.focus();
                        return false;
                    }

                    bExist = true; // 値あり！
                } // if
            } // while

            if (bExist == false) { // データが1件も入力されていない？
                alert("データを入力して下さい。");
                txtGROUPCD_1.focus();
                return false;
            }
        } // if 登録時のみ

        //削除時のみ
		if (intKbn == 4) {

		    //削除対象データが入力されているか
            var bExist = false;
            for (i = 1; i <= 100; i++) { // 1～100
                var objTARGET = document.getElementById("chkTARGET_" + i);
                var objGROUPCD = document.getElementById("txtGROUPCD_" + i);
                var strGROUPCD = objGROUPCD.value.replace(/(^\s+)|(\s+$)/g, "");

                if (objTARGET.checked == true
                    && strGROUPCD.length != 0) {
                    
                    bExist = true; // 値あり！
                }
            }
			if (bExist == false) {
			    alert("削除対象データがありません。");
			    txtGROUPCD_1.focus();
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

    Form1.hdnPopcrtl.value = strFlg;
    if (strFlg == "2" || strFlg == "3") {
        fncPop('COPOPUPG00', "600");
    } else {
        fncPop('COPOPUPG00');
    }

}
//*********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId, strOptwidth) {
    if (typeof strOptwidth === 'undefined') strOptwidth = "400";
    var nowday = new Date();
    var name = "MSHATJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds(); //2014/10/02 T.Ono add 2014改善開発 No20
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
//イベントボタンに対してロックをかける
//**************************************
function fncBtnRoc(obj) {
	with(Form1){
		//検索ボタン使用不可
		btnUpdate.disabled=true;
		//削除ボタン使用不可
		btnDelete.disabled=true;
		//検索ボタン使用不可
		btnSelect.disabled=true;
		//取消ボタン使用不可
		btnClear.disabled=true;
		//終了ボタン使用不可
		btnExit.disabled=true;
		//クライアントコード検索ボタン使用不可
		btnKURACD.disabled=true;
		//グループコード(From)検索ボタン使用不可
		btnGROUPCD_F.disabled = true;
		//グループコード(To)検索ボタン使用不可
		btnGROUPCD_T.disabled = true;
		//データ出力検索ボタン使用不可
		btnCSVOUT.disabled = true;
	}
	fncFo(obj,5);
}
//**************************************
//イベントボタンに対してロックを解除する
//**************************************
function fncBtnUnRoc(obj) {
    with (Form1) {
        //検索ボタン使用可
        btnUpdate.disabled = false;
        //削除ボタン使用可
        btnDelete.disabled = false;
        //検索ボタン使用可
        btnSelect.disabled = false;
        //取消ボタン使用可
        btnClear.disabled = false;
        //終了ボタン使用可
        btnExit.disabled = false;
        //クライアントコード検索ボタン使用可
        btnKURACD.disabled = false;
        //グループコード(From)検索ボタン使用可
        btnGROUPCD_F.disabled = false;
        //グループコード(To)検索ボタン使用可
        btnGROUPCD_T.disabled = false;
        //データ出力検索ボタン使用可
        btnCSVOUT.disabled = false;
    }
    fncFo(obj, 5);
}
//**************************************
//全て選択/解除ボタン押下
//**************************************
function btnCheckBtn(btn) {
    if (btn == "1") {
        for (i = 1; i <= 100; i++) { // 1～100
            document.getElementById("chkTARGET_" + i).checked = true;
        }
    } else if (btn == "2") {
        for (i = 1; i <= 100; i++) { // 1～100
            document.getElementById("chkTARGET_" + i).checked = false;
        }
    }
}
//**************************************
//Toへの自動セット 2019/11/01 T.Ono add 監視改善2019
//**************************************
function fncSetTo() {
    with (Form1) {

        //グループコードToセット
        if (hdnPopcrtl.value == '2') {
            hdnGROUPCD_T.value = "";
            txtGROUPCD_T.value = "";
            hdnGROUPCD_T.value = hdnGROUPCD_F.value;
            txtGROUPCD_T.value = txtGROUPCD_F.value;
        }
    }
}