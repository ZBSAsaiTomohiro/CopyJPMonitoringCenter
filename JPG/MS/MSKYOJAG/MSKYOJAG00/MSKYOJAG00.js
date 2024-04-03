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
//削除ボタン押下時の処理
//**************************************
function btnCheckBtn(btn) {
    if (btn == "1") {
        for (i = 1; i <= 30; i++) { // 1～30
            document.getElementById("chkDEL_" + i).checked = true;
        }
    } else if (btn == "2") {
        for (i = 1; i <= 30; i++) { // 1～30
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
	Form1.hdnKBN.value = "1"; // 1:
	if (Form1.hdnKENCD_MOTO.value == ""){ // 新規？
	    strRes = confirm("登録してよろしいですか？");
    } else if (Form1.hdnKENCD.value == Form1.hdnKENCD_MOTO.value) { // キーが変わってない？) { // キーが変わってない？
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
        //実行ボタン使用不可
        btnUpdate.disabled = false;
        //削除ボタン使用不可
        btnDelete.disabled = false;
        //検索ボタン使用不可
        btnSelect.disabled = false;
        //取消ボタン使用不可
        btnClear.disabled = false;
        //終了ボタン使用不可
        btnExit.disabled = false;
        //終了ボタン使用不可
        btnCSVout.disabled = false;
        //クライアントコード検索ボタン使用不可
        btnKENCD.disabled = false;
    }
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
	//intKbn  1:検索　2:新規　3:登録/修正 4:削除
	//---------------------------------
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
	    if ((txtKENCD.value == " ") || (txtKENCD.value == "")) {
			alert("県コードは必須です");
			btnKENCD.focus();
			return false;
		}
		if (intKbn != 5) {
		    var x;
		    var dupKYOKYU = null;
		    var dupKYOKYU2 = null;
		    var dupKYOKYU3 = null;
		    var dupchk = false;
		    for (x = 1; x <= 30; x++) { // 1～30
		        dupKYOKYU = document.getElementById("txtKYOKYU_" + x);
		        if (dupKYOKYU.value.length != 0) {
		            var y;
		            for (y = x + 1; y <= 30; y++) { // 1～30
		                dupKYOKYU2 = document.getElementById("txtKYOKYU_" + y);
		                if (dupKYOKYU2.value.length != 0) {
		                    if (dupKYOKYU.value == dupKYOKYU2.value) {
		                        dupchk = true;
		                        dupKYOKYU3 = dupKYOKYU2;
		                    }
		                }
		            } // while
		        }
		    } // while
		    if (dupchk) {
		        alert("供給センターコードが重複しています。");
		        dupKYOKYU3.focus();
		        return false;
		    }
		}
		//以下は　登録/修正時のみ
		if (intKbn == 3) {
			
			var bExist = false;
			var i;
			for (i = 1; i <= 30; i++) { // 1～30
				objKYOKYU   = document.getElementById("txtKYOKYU_"+i);
				objKYOKYUNM = document.getElementById("txtKYOKYUNM_"+i);
				if (   objKYOKYU.value.length   != 0 
				    || objKYOKYUNM.value.length != 0) {
				    
					if (objKYOKYU.value.length==0) {
                        alert("供給センターコードは必須入力です");
						objKYOKYU.focus();
						return false;
					}
		            if (objKYOKYUNM.value.length == 0) {
		                alert("供給センター名は必須入力です");
		                objKYOKYUNM.focus();
		                return false;
		            }
		            if (objKYOKYU.value.length != 0) {
		                if (jstrlen(objKYOKYU.value) > 10) {
		                    alert("桁数オーバーしています。");
		                    objKYOKYU.focus();
		                    return false;
		                }
		            }
		            if (!fncNumChk(objKYOKYU.value)) {
		                alert("数値のみ入力可能です。");
		                objKYOKYU.focus();
		                return false;
		            }
		            if (objKYOKYUNM.value.length != 0) {
		                if (jstrlen(objKYOKYUNM.value) > 30) {
		                    alert("桁数オーバーしています。");
		                    objKYOKYUNM.focus();
		                    return false;
		                }
		            }

					bExist = true; // 値あり！
				} // if
			}// while
			
			if (bExist == false){ // データが1件も入力されていない？
			    if (txtAYMD.value == ""){ // 新規？
			        alert("データを入力して下さい。");
			        txtKYOKYU_1.focus();
					return false;
			    }
			}
    	} // if 登録時のみ

		//以下は　削除時のみ
		if (intKbn == 4) {
			
			if (txtAYMD.value.length == 0){ // 新規？
			    alert("削除対象データがありません。");
			    txtKYOKYU_1.focus();
				return false;
			}
			
			if (hdnKENCD_MOTO.value.length == 0){ // 新規？
			    alert("削除対象データがありません。");
			    txtKYOKYU_1.focus();
				return false;
			}
            if (Form1.hdnKENCD.value != Form1.hdnKENCD_MOTO.value) { // キーが変わっている？
				alert("キーが変更されています。再度検索して下さい。");
				btnKENCD.focus();
				return false;
			}
            var bExist = false;
            for (i = 1; i <= 30; i++) { // 1～30
			    objDEL = document.getElementById("chkDEL_" + i);
			    objKYOKYU = document.getElementById("txtKYOKYU_" + i);
			    objKYOKYUNM = document.getElementById("txtKYOKYUNM_" + i);
			    if (objKYOKYU.value.length != 0
				    && objKYOKYUNM.value.length != 0) {

			        if (objDEL.checked) {
			            bExist = true; // 値あり！
                    }
			    }
			}
			if (bExist == false) {
			    alert("削除対象データがありません。");
			    txtKYOKYU_1.focus();
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
		fncPop('COPOPUPG00');
}
//*********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "MSKYOJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
		//終了ボタン使用不可
		btnCSVout.disabled = true;
		//クライアントコード検索ボタン使用不可
		btnKENCD.disabled=true;
	}
	fncFo(obj,5);
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
				for (j = 1; j < 5; j ++) {
					str_str = str_str + str.charAt(i+j);
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
