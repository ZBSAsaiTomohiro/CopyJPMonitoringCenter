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
	if (Form1.hdnKURACD_MOTO.value == ""){ // 新規？
	    strRes = confirm("登録してよろしいですか？");
    } else if (Form1.hdnKURACD.value == Form1.hdnKURACD_MOTO.value) { // キーが変わってない？) { // キーが変わってない？
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
        btnKURACD.disabled = false;
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
	//intKbn  1:検索　2:新規　3:登録/修正 4:削除 5:データ出力
	//---------------------------------
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
//      2014/03/07 T.Ono del データ出力は、クライアントなしでも可とする
//	    if ((txtKURACD.value == " ") || (txtKURACD.value == "")) {
//			alert("クライアントコードは必須です");
//			btnKURACD.focus();
//			return false;
//		}
		if (intKbn != 5) {
		    //2014/03/07 T.Ono mod データ出力は、クライアントなしでも可とする
            if ((txtKURACD.value == " ") || (txtKURACD.value == "")) {
		        alert("クライアントコードは必須です");
		        btnKURACD.focus();
		        return false;
		    }
//		    送信順は必須としない。空白も可
//		    var x;
//		    var dupSEND = null;
//		    var dupSEND2 = null;
//		    var dupSEND3 = null;
//		    var dupchk = false;
//		    for (x = 1; x <= 30; x++) { // 1～30
//		        dupSEND = document.getElementById("txtSEND_" + x);
//		        if (dupSEND.value.length != 0) {
//		            var y;
//		            for (y = x + 1; y <= 30; y++) { // 1～30
//		                dupSEND2 = document.getElementById("txtSEND_" + y);
//		                if (dupSEND2.value.length != 0) {
//		                    if (dupSEND.value == dupSEND2.value) {
//		                        dupchk = true;
//		                        dupSEND3 = dupSEND2;
//		                    }
//		                }
//		            } // while
//		        }
//		    } // while
//		    if (dupchk) {
//		        alert("送信順が重複しています。");
//		        dupSEND3.focus();
//		        return false;
//		    }
		}
		//以下は　登録/修正時のみ
		if (intKbn == 3) {

			var bExist = false;
			var i;
			for (i = 1; i <= 30; i++) { // 1～30
                objSEND = document.getElementById("txtSEND_" + i);
                objFAX1 = document.getElementById("txtFAX1_" + i);
                objFAX2 = document.getElementById("txtFAX2_" + i);
                objMAIL1 = document.getElementById("txtMail1_" + i);
                objMAIL2 = document.getElementById("txtMail2_" + i);
                objKYOKYU = document.getElementById("txtKYOKYU_" + i);   //2014/03/10 T.Ono add
                objACBCDFR = document.getElementById("txtACBCDFR_" + i); //2014/03/10 T.Ono add
                objACBCDTO = document.getElementById("txtACBCDTO_" + i); //2014/03/10 T.Ono add

                //2014/03/10 T.Ono mod 送信順は必須としない ----------START
//				if (objSEND.value.length   != 0) {
//					if (objSEND.value.length==0) {
//                        alert("送信順は必須入力です");
//                        objSEND.focus();
//						return false;
//					}
//            		if (jstrlen(objSEND.value) > 8) {
//		                alert("桁数オーバーしています。");
//		                objSEND.focus();
//		                return false;
//		            }
//		            if (!fncNumChk(objSEND.value)) {
//		                alert("数値のみ入力可能です。");
//		                objSEND.focus();
//		                return false;
//		            }
//		            
//                    if ((objFAX1.value.length == 0) && (objFAX2.value.length == 0)
//                        && (objMAIL1.value.length == 0) && (objMAIL2.value.length == 0)) {
//		                alert("FAXかメールを入力して下さい。");
//		                objFAX1.focus();
//		                return false;
//		            }
//		            bExist = true; // 値あり！
//		        } // if
		        if (objSEND.value.length != 0
				    || objKYOKYU.value.length != 0
                    || objACBCDFR.value.length != 0
                    || objACBCDTO.value.length != 0
                    || objFAX1.value.length != 0
                    || objFAX2.value.length != 0
                    || objMAIL1.value.length != 0
                    || objMAIL2.value.length != 0) {

		            if ((objFAX1.value.length == 0) && (objFAX2.value.length == 0)
                        && (objMAIL1.value.length == 0) && (objMAIL2.value.length == 0)) {
		                alert("FAXかメールを入力して下さい。");
		                objFAX1.focus();
		                return false;
		            }

		            bExist = true; // 値あり！
		        } // if
		        if (objSEND.value.length != 0) {
		            if (jstrlen(objSEND.value) > 8) {
		                alert("桁数オーバーしています。");
		                objSEND.focus();
		                return false;
		            }
		            if (!fncNumChk(objSEND.value)) {
		                alert("数値のみ入力可能です。");
		                objSEND.focus();
		                return false;
		            }
		        }
		        //2014/03/10 T.Ono mod 送信順は必須としない ----------END

            	//objKYOKYU = document.getElementById("txtKYOKYU_" + i);  //2014/03/10 T.Ono del 上に移動
            	if (objKYOKYU.value.length != 0) {
            	    if (jstrlen(objKYOKYU.value) > 10) {
            	        alert("桁数オーバーしています。");
            	        objKYOKYU.focus();
            	        return false;
            	    }
                }
            	//objACBCDFR = document.getElementById("txtACBCDFR_" + i);  //2014/03/10 T.Ono del 上に移動
            	if (objACBCDFR.value.length != 0) {
            	    if (jstrlen(objACBCDFR.value) > 10) {
            	        alert("桁数オーバーしています。");
            	        objACBCDFR.focus();
            	        return false;
            	    }
            	}
            	//objACBCDTO = document.getElementById("txtACBCDTO_" + i);  //2014/03/10 T.Ono del 上に移動
            	if (objACBCDTO.value.length != 0) {
            	    if (jstrlen(objACBCDTO.value) > 10) {
            	        alert("桁数オーバーしています。");
            	        objACBCDTO.focus();
            	        return false;
            	    }
            	}
            	if (objFAX1.value.length != 0) {
            	    if (jstrlen(objFAX1.value) > 15) {
            	        alert("桁数オーバーしています。");
            	        objFAX1.focus();
            	        return false;
            	    }
            	    if (fncChkTel(objFAX1.value) == false) {
            	        alert("FAX1は正しいFAX番号ではありません");
            	        objFAX1.focus();
            	        return false;
                    }
            	}
            	if (objFAX2.value.length != 0) {
            	    if (jstrlen(objFAX2.value) > 15) {
            	        alert("桁数オーバーしています。");
            	        objFAX2.focus();
            	        return false;
            	    }
            	    if (fncChkTel(objFAX2.value) == false) {
            	        alert("FAX2は正しいFAX番号ではありません");
            	        objFAX2.focus();
            	        return false;
            	    }
            	}
            	if (objMAIL1.value.length != 0) {
            	    if (jstrlen(objMAIL1.value) > 100) {
            	        alert("桁数オーバーしています。");
            	        objMAIL1.focus();
            	        return false;
            	    }
            	}
            	if (objMAIL2.value.length != 0) {
            	    if (jstrlen(objMAIL2.value) > 100) {
            	        alert("桁数オーバーしています。");
            	        objMAIL2.focus();
            	        return false;
            	    }
            	}
            	objNXSEND = document.getElementById("txtNXSEND_" + i);
            	if (objNXSEND.value.length != 0) {
            	    if (jstrlen(objNXSEND.value) > 10) {
            	        alert("桁数オーバーしています。");
            	        objNXSEND.focus();
            	        return false;
            	    }
            	    if (!fncChkDate(objNXSEND.value)) {
            	        alert("日付形式が正しくありません。");
            	        objNXSEND.focus();
            	        return false;
            	    }
            	}
            	objSENDSTR = document.getElementById("txtSENDSTR_" + i);
            	if (objSENDSTR.value.length != 0) {
            	    if (jstrlen(objSENDSTR.value) > 10) {
            	        alert("桁数オーバーしています。");
            	        objSENDSTR.focus();
            	        return false;
            	    }
            	    if (!fncChkDate(objSENDSTR.value)) {
            	        alert("日付形式が正しくありません。");
            	        objSENDSTR.focus();
            	        return false;
            	    }
            	}
            	objSENDEND = document.getElementById("txtSENDEND_" + i);
            	if (objSENDEND.value.length != 0) {
            	    if (jstrlen(objSENDEND.value) > 10) {
            	        alert("桁数オーバーしています。");
            	        objSENDEND.focus();
            	        return false;
            	    }
            	    if (!fncChkDate(objSENDEND.value)) {
            	        alert("日付形式が正しくありません。");
            	        objSENDEND.focus();
            	        return false;
            	    } 
            	}
            	objMAILPASS = document.getElementById("txtMAILPASS_" + i);
            	if (objMAILPASS.value.length != 0) {
            	    if (jstrlen(objMAILPASS.value) > 20) {
            	        alert("桁数オーバーしています。");
            	        objMAILPASS.focus();
            	        return false;
            	    }
            	}
            	objZIP = document.getElementById("txtZIP_" + i);
            	if (objZIP.value.length != 0) {
            	    if (jstrlen(objZIP.value) > 100) {
            	        alert("桁数オーバーしています。");
            	        objZIP.focus();
            	        return false;
            	    }
            	}
            	objBIKOU = document.getElementById("txtBIKOU_" + i);
            	if (objBIKOU.value.length != 0) {
            	    if (jstrlen(objBIKOU.value) > 500) {
            	        alert("桁数オーバーしています。");
            	        objBIKOU.focus();
            	        return false;
            	    }
            	}
            	if ((objFAX1.value.length != 0) || (objFAX2.value.length != 0)
                        || (objMAIL1.value.length != 0) || (objMAIL2.value.length != 0)) {
            	    var nowdt = fncGetNowDate(1);
                    if(objSENDSTR.value.length == 0){
                        objSENDSTR.value = nowdt;
                    }
                    if (objSENDEND.value.length == 0) {
                        objSENDEND.value = "2099/12/31";
                    }
                    if (objNXSEND.value.length == 0) {
                        objNXSEND.value = nowdt;
                    }
            	}

         } // while
			
			if (bExist == false){ // データが1件も入力されていない？
			    if (txtAYMD.value == ""){ // 新規？
			        alert("データを入力して下さい。");
			        txtSEND_1.focus();
					return false;
			    }
			}
    	} // if 登録時のみ

		//以下は　削除時のみ
		if (intKbn == 4) {
			
			//if (txtAYMD.value.length == 0){ // 新規？
			//    alert("削除対象データがありません。");
			 //   txtSEND_1.focus();
			//	return false;
			//}
			
			if (hdnKURACD_MOTO.value.length == 0){ // 新規？
			    alert("削除対象データがありません。");
			    txtSEND_1.focus();
				return false;
			}
            if (Form1.hdnKURACD.value != Form1.hdnKURACD_MOTO.value) { // キーが変わっている？
				alert("キーが変更されています。再度検索して下さい。");
				btnKURACD.focus();
				return false;
			}
            var bExist = false;
            for (i = 1; i <= 30; i++) { // 1～30
			    objDEL = document.getElementById("chkDEL_" + i);
			    objSEND = document.getElementById("txtSEND_" + i);
			    if (objSEND.value.length != 0) {
			        if (objDEL.checked) {
			            bExist = true; // 値あり！
                    }
			    }
			}
			if (bExist == false) {
			    alert("削除対象データがありません。");
			    txtSEND_1.focus();
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
//    2014/03/11 T.Ono mod JA支所コード追加のため、チェックを追加
//    Form1.hdnPopcrtl.value = strFlg;
//    fncPop('COPOPUPG00');
    if ((strFlg == "101" || strFlg == "102") &&
        (Form1.txtKURACD.value == " " || Form1.txtKURACD.value == "")) {
        alert("クライアントコードを選択してください");
        Form1.btnKURACD.focus();
    } else {
        Form1.hdnPopcrtl.value = strFlg;
        fncPop('COPOPUPG00');
    }


}
//*********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId) {
    var nowday = new Date();
    var name = "MSRUIJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds(); //2014/10/02 T.Ono add 2014改善開発 No20
    if (wP == null || wP.closed == true) {
        //wP = parent.fncPopupOpen(); //2014/10/02 T.Ono mod 2014改善開発 No20
        wP = parent.fncPopupOpen(name); 
    } else {
        wP.close();
        wP = null;
        //wP = parent.fncPopupOpen(); //2014/10/02 T.Ono mod 2014改善開発 No20
        wP = parent.fncPopupOpen(name);
    }
	wP.focus();
	Form1.hdnKensaku.value=strId;
	//Form1.target = "wP" //2014/10/02 T.Ono mod 2014改善開発 No20
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
		btnKURACD.disabled=true;
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
//**************************************
//Toへの自動セット 2019/11/01 T.Ono add 監視改善2019
//**************************************
function fncSetTo() {
    with (Form1) {

        //JA支所名Toセット
        if (hdnPopcrtl.value == '101') {
            hdnACBCD_T.value = "";
            txtACBCD_T.value = "";
            hdnACBCD_T.value = hdnACBCD_F.value;
            txtACBCD_T.value = txtACBCD_F.value;
        }
    }
}
