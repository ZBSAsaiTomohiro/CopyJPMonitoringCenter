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
function btnCSVOUT_onclick() {
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
//一括登録ボタン押下時の処理
//**************************************
function btnIKKATU_onclick() {
    //入力値チェック-----------
    if (fncDataCheck(6) == false) {
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
    doPostBack('btnIKKATU', '');
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

    document.getElementById('hdnReadOnlyFlg').value = "0" //グループコード(新規登録用)は入力可にする

	fncBtnRoc(Form1.btnClear);
	doPostBack('btnClear', '');
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
//グループ追加ボタン押下時の処理
//**************************************
function btngroupadd_onclick() {
    //入力値チェック-----------
    if (fncDataCheck(7) == false) {
        return false;
    }
    var strRes;
    //確認メッセージ----------- 
    Form1.hdnKBN.value = "7"; // 7:グループ追加
    strRes = confirm("登録してよろしいですか？");

    if (strRes == false) {
        return;
    }
    fncBtnRoc(Form1.btnGROUP_ADD);
    doPostBack('btnGROUP_ADD', '');
}
//**************************************
//グループコード名検索ボタン押下時の処理
//**************************************
function btngroupsearch_onclick() {
    //入力値チェック-----------
    if (fncDataCheck(8) == false) {
        return false;
    }

//    var strgroup = new Array(2);
//    document.getElementById("txtGROUPCD_NEW").value = ""
//    document.getElementById("txtGROUPNM_NEW").value = ""

//    with(Form1) {
//        if ((txtGROUPCD.value != "") && (txtGROUPCD.value != " ")) {

//            strgroup = txtGROUPCD.value.split(":");
//            strgroup[0] = strgroup[0].replace(/(^\s+)|(\s+$)/g, "");
//            strgroup[1] = strgroup[1].replace(/(^\s+)|(\s+$)/g, "");
//            document.getElementById("txtGROUPCD_NEW").value = strgroup[0]
//            document.getElementById("txtGROUPNM_NEW").value = strgroup[1]
//        }
//    }

    fncBtnRoc(Form1.btnGROUP_SEARCH);
    doPostBack('btnGROUP_SEARCH', '');
    fncBtnUnRoc(Form1.btnGROUP_SEARCH);
}
//**************************************
//グループコード名変更確定ボタン押下時の処理
//**************************************
function btngroupmod_onclick() {
    //入力値チェック-----------
    if (fncDataCheck(9) == false) {
        return false;
    }
    var strRes;
    //確認メッセージ----------- 
    Form1.hdnKBN.value = "9"; // 9:グループコード名変更確定
    strRes = confirm("登録してよろしいですか？");

    if (strRes == false) {
        return;
    }
    fncBtnRoc(Form1.btnGROUP_MOD);
    doPostBack('btnGROUP_MOD', '');
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	//---------------------------------
    //intKbn  1:検索　3:登録/修正 4:削除 5:データ出力 6:一括登録
    //　　　　7:グループ追加　8:グループコード名検索　9:グループコード名変更確定
	//---------------------------------
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {

        //共通　JA支所From/To片方のみは不可
        if ((hdnACBCD_F.value != "" && hdnACBCD_F.value != " ")
                || (hdnACBCD_T.value != "" && hdnACBCD_T.value != " ")) {
	        if (hdnACBCD_F.value == "" || hdnACBCD_F.value == " ") {
	            alert("JA支所Toのみの指定はできません");
	            btnACBCD_F.focus();
	            return false;
	        }
	        if (hdnACBCD_T.value == "" || hdnACBCD_T.value == " ") {
	            alert("JA支所Fromのみの指定はできません");
	            btnACBCD_T.focus();
	            return false;
	        }
	    }


        //検索時
	    if (intKbn == 1) {
            //ｸﾗｲｱﾝﾄまたは、グループは必須
	        if (((txtKURACD.value == " ") || (txtKURACD.value == ""))
                && ((txtGROUPCD.value == " ") || (txtGROUPCD.value == ""))) {
	            alert("検索条件を指定してください");
	            btnKURACD.focus();
	            return false;
	        }
	        //未登録分チェックありのときは、ｸﾗｲｱﾝﾄ必須
            if ((chkSYU_MITOUROKU.checked == true) &&
                ((txtKURACD.value == " ") || (txtKURACD.value == ""))) {
                alert("クライアントコードは必須です");
                btnKURACD.focus();
                return false;
            }
            //出力のチェックは必須
            if ((chkSYU_MITOUROKU.checked == false) && (chkSYU_TOUROKU.checked == false)) {
                alert("出力のチェックは必須です");
                chkSYU_TOUROKU.focus();
                return false;
            }
	    }


	    //登録/修正、削除時
	    if ((intKbn == 3) || (intKbn == 4)) {

            //区分が変更されていないか確認
	        if (hdnJAGKBN.value != hdnJAGKBN_MOTO.value) {
	            alert("キーが変更されています。再度検索して下さい。");
	            cboJAGKBN.focus();
	            return false;
	        }

            //入力データの重複確認
	        var x;
	        var dupTARGET1 = null;
	        var dupKURACD1 = null;
	        var strKURACD1 = "";
	        var dupACBCD1 = null;
	        var strACBCD1 = "";
	        var dupUSERCD_F1 = null;
	        var strUSERCD_F1 = null;

	        var dupTARGET2 = null;
	        var dupKURACD2 = null;
	        var strKURACD2 = "";
	        var dupACBCD2 = null;
	        var strACBCD2 = "";
	        var dupUSERCD_F2 = null;
	        var strUSERCD_F2 = "";

	        var dupKURACD3 = null;
	        var dupchk = false;

	        for (x = 1; x <= 100; x++) { // 1～100
	            dupTARGET1 = document.getElementById("chkTARGET_" + x);
	            dupKURACD1 = document.getElementById("txtKURACD_" + x);
	            strKURACD1 = dupKURACD1.value.replace(/(^\s+)|(\s+$)/g, "")
	            dupACBCD1 = document.getElementById("hdnACBCD_" + x);
	            strACBCD1 = dupACBCD1.value.replace(/(^\s+)|(\s+$)/g, "")
	            dupUSERCD_F1 = document.getElementById("txtUSERCD_F_" + x);
	            strUSERCD_F1 = dupUSERCD_F1.value.replace(/(^\s+)|(\s+$)/g, "")
	            if ((dupTARGET1.checked == true) && (strKURACD1.length != 0)) {
	                var y;
	                for (y = x + 1; y <= 100; y++) { // 1～100
	                    dupTARGET2 = document.getElementById("chkTARGET_" + y);
	                    dupKURACD2 = document.getElementById("txtKURACD_" + y);
	                    strKURACD2 = dupKURACD2.value.replace(/(^\s+)|(\s+$)/g, "");
	                    dupACBCD2 = document.getElementById("hdnACBCD_" + y);
	                    strACBCD2 = dupACBCD2.value.replace(/(^\s+)|(\s+$)/g, "");
	                    dupUSERCD_F2 = document.getElementById("txtUSERCD_F_" + y);
	                    strUSERCD_F2 = dupUSERCD_F2.value.replace(/(^\s+)|(\s+$)/g, "");
	                    if ((dupTARGET2.checked == true) && (strKURACD2.length != 0)) {
	                        if ((strKURACD1 + strACBCD1 + strUSERCD_F1)
                                == (strKURACD2 + strACBCD2 + strUSERCD_F2)) {
	                            dupchk = true;
	                            dupKURACD3 = dupKURACD2;
	                        }
	                    }
	                } // while
	            }
	        } // while
	        if (dupchk) {
	            alert("クライアントコード・JA支所コード・お客様コードが重複しています。");
	            dupKURACD3.focus();
	            return false;
	        }
	    }
		
        //登録/修正時のみ
		if (intKbn == 3) {
			
            //必須項目の確認
			var bExist = false;
			var i;
			for (i = 1; i <= 100; i++) { // 1～100
			    var objTARGET = document.getElementById("chkTARGET_" + i);
                //クライアントコード
			    var objKURACD = document.getElementById("txtKURACD_" + i);
			    var strKURACD = objKURACD.value.replace(/(^\s+)|(\s+$)/g, "");
                //JA支所コード
			    var objACBCD = document.getElementById("hdnACBCD_" + i);
			    var strACBCD = objACBCD.value.replace(/(^\s+)|(\s+$)/g, "");
			    var objACBCDbtn = document.getElementById("btnACBCD_" + i);
                //グループコード
			    var objGROUPCD = document.getElementById("hdnGROUPCD_" + i);
			    var strGROUPCD = objGROUPCD.value.replace(/(^\s+)|(\s+$)/g, "");
			    var objGROUPCDbtn = document.getElementById("btnGROUPCD_" + i);
                //お客様コード
			    var objUSERCD_F = document.getElementById("txtUSERCD_F_" + i);
			    var strUSERCD_F = objUSERCD_F.value.replace(/(^\s+)|(\s+$)/g, "");
			    var objUSERCD_T = document.getElementById("txtUSERCD_T_" + i);
			    var strUSERCD_T = objUSERCD_T.value.replace(/(^\s+)|(\s+$)/g, "");
                //備考
			    var objBIKO = document.getElementById("txtBIKO_" + i);
			    var strBIKO = objBIKO.value.replace(/(^\s+)|(\s+$)/g, "");

				if ((objTARGET.checked == true)
                    && (strKURACD.length != 0
				    || strACBCD.length != 0
                    || strGROUPCD.length != 0
                    || strUSERCD_F.length != 0
                    || strUSERCD_T.length != 0
                    || strBIKO.length != 0)) {

                    //クライアント(必須チェック)
				    if (strKURACD.length == 0) {
                        alert("クライアントコードは必須入力です");
                        objKURACD.focus();
						return false;
		            }
		            //JA支所(必須チェック)
		            if (strACBCD.length == 0) {
		                alert("JA支所コードは必須入力です");
		                objACBCDbtn.focus();
		                return false;
		            }
		            //グループコード(必須チェック)
                    if (strGROUPCD.length == 0) {
		                alert("グループコードは必須入力です");
		                objGROUPCDbtn.focus();
		                return false;
		            }

		            //クライアント(数値チェック)
		            if (fncNumChk(strKURACD) == false) {
		                alert("クライアントコードは半角数値で入力して下さい");
		                objKURACD.focus();
		                return false;
		            }
                    //備考(レングスチェック)
		            if (fncGetByte(strBIKO) > 200) {
		                alert("備考は全角100文字以内で入力して下さい");
		                objBIKO.focus();
		                return false;
		            }
					// 2014/11/04 H.Hosoda add お客様コードチェック追加 START
					if ((strUSERCD_F == "") && (strUSERCD_T != "")) {
						//Toのみ入力
						alert("お客様コードの入力が不正です");
						objUSERCD_F.focus();
						return false;
					}
					if ((strUSERCD_F.length != objUSERCD_F.value.length) || (strUSERCD_T.length != objUSERCD_T.value.length)) {
						//空白の入力
						alert("お客様コードの入力が不正です（空白の入力）");
						objUSERCD_F.focus();						
						return false;
					}
					if ((strUSERCD_F != "") && (strUSERCD_T != "")) {
						if (strUSERCD_F == strUSERCD_T) {
							alert("お客様コードの入力が不正です（同値）");
							objUSERCD_F.focus();
							return false;
						}
						if (strUSERCD_F.length != strUSERCD_T.length) {
							alert("お客様コードの入力が不正です（桁数）");
							objUSERCD_F.focus();							
							return false;
						}
						if (strUSERCD_F > strUSERCD_T) {
							alert("お客様コードの入力が不正です（From>To）");
							objUSERCD_F.focus();							
							return false;
						}
					}
					// 2014/11/04 H.Hosoda add お客様コードチェック追加 END
					bExist = true; // 値あり！
				} // if
			}// while
			
			if (bExist == false){ // データが1件も入力されていない？
			        alert("データを入力して下さい。");
			        txtKURACD_1.focus();
					return false;
			}
    	} // if 登録時のみ


		//削除時のみ
		if (intKbn == 4) {

            //検索しているか確認
		    if ((hdnKURACD_MOTO.value.length == 0) && (hdnGROUPCD_MOTO.value.length == 0)) { // 新規？
		        alert("削除対象データがありません。");
		        txtKURACD_1.focus();
		        return false;
		    }

		    //削除対象データが入力されているか
            var bExist = false;
            for (i = 1; i <= 100; i++) { // 1～100
                var objTARGET = document.getElementById("chkTARGET_" + i);
                var objKURACD = document.getElementById("txtKURACD_" + i);
                var strKURACD = objKURACD.value.replace(/(^\s+)|(\s+$)/g, "");
                var objACBCD = document.getElementById("hdnACBCD_" + i);
                var strACBCD = objACBCD.value.replace(/(^\s+)|(\s+$)/g, "");
                var objGROUPCD = document.getElementById("hdnGROUPCD_" + i);
                var strGROUPCD = objGROUPCD.value.replace(/(^\s+)|(\s+$)/g, "");

                if (objTARGET.checked == true
                	&& strKURACD.length != 0
                	&& strACBCD.length != 0
                    && strGROUPCD.length != 0) {
                    
                    bExist = true; // 値あり！
                }
            }
			if (bExist == false) {
			    alert("削除対象データがありません。");
			    txtKURACD_1.focus();
			    return false;
			}
		} // if 削除時のみ


        //データ出力時
        if (intKbn == 5) {
            //出力(必須チェック)
            if ((chkSYU_MITOUROKU.checked == false) && (chkSYU_TOUROKU.checked == false)) {
                alert("出力のチェックは必須です");
                chkSYU_TOUROKU.focus();
                return false;
            }
        }


        //一括登録時
        if (intKbn == 6) {
            //クライアント(必須チェック)
            if ((txtKURACD.value == " ") || (txtKURACD.value == "")) {
                alert("クライアントコードは必須です");
                btnKURACD.focus();
                return false;
            }
            //グループコード(必須チェック)
            if ((hdnGROUPCD.value == " ") || (hdnGROUPCD.value == "")) {
                alert("グループコードは必須です");
                btnGROUPCD.focus();
                return false;
            }
        }


        //グループ追加、変更確定時
        if ((intKbn == 7) || (intKbn == 9)){
            var strGROUPCD_NEW = txtGROUPCD_NEW.value.replace(/(^\s+)|(\s+$)/g, "");
            var strGROUPNM_NEW = txtGROUPNM_NEW.value.replace(/(^\s+)|(\s+$)/g, "");

            //グループコード(必須チェック)
            if (strGROUPCD_NEW.length == 0) {
                alert("グループコードは必須です");
                txtGROUPCD_NEW.focus();
                return false;
            }
            //グループコード名(必須チェック)
            if (strGROUPNM_NEW.length == 0) {
                alert("グループコード名は必須です");
                txtGROUPNM_NEW.focus();
                return false;
            }
            //グループコード(全角チェック)
            if (fncZenkakuChk(strGROUPCD_NEW) == true) {
                alert("グループコードは半角で入力して下さい");
                txtGROUPCD_NEW.focus();
                return false;
            }
            //グループコード名(レングスチェック)
            if (fncGetByte(strGROUPNM_NEW) > 60) {
                alert("グループコード名は全角30文字以内で入力して下さい");
                txtGROUPNM_NEW.focus();
                return false;
            }
        }


        //グループコード名検索
        if (intKbn == 8) {
            //グループコード(必須チェック)
            if ((txtGROUPCD.value == " ") || (txtGROUPCD.value == "")){
                alert("グループコードを選択してください");
                btnGROUPCD.focus();
                return false;
            }
        }


	} // with
	return true;
}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {
	
	// 2014/11/04 H.Hosoda mod ポップアップ表示幅変更 START
    /*if ((strFlg == "2" || strFlg == "3") &&
        (Form1.txtKURACD.value == " " || Form1.txtKURACD.value == "")) {
		alert("クライアントコードを選択してください");
		Form1.btnKURACD.focus();
	} else {
		Form1.hdnPopcrtl.value = strFlg;
		fncPop('COPOPUPG00');
	}*/
	
    if ((strFlg == "2" || strFlg == "3") &&
        (Form1.txtKURACD.value == " " || Form1.txtKURACD.value == "")) {
		alert("クライアントコードを選択してください");
		Form1.btnKURACD.focus();
		return false;
	}
	
	Form1.hdnPopcrtl.value = strFlg;	
    if (strFlg == "4" || (parseInt(strFlg) >= 201 && parseInt(strFlg) <= 300)) {
		fncPop('COPOPUPG00',"600");
    } else {
		fncPop('COPOPUPG00');
	}
	// 2014/11/04 H.Hosoda mod ポップアップ表示幅変更 END
}
//*********************************
//ポップアップ用
//*********************************
var wP;
// 2014/11/04 H.Hosoda mod ポップアップ表示幅変更 START
/*function fncPop(strId){
	var nowday = new Date();
	var name = "MSJAGJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds(); //2014/10/02 T.Ono add 2014改善開発 No20
	if (wP == null || wP.closed == true) {
	    wP = parent.fncPopupOpen(name);
	} else {
	    wP.close();
	    wP = null;
	    wP = parent.fncPopupOpen(name);
	}
	wP.focus();
	Form1.hdnKensaku.value = strId;
	Form1.target = name;
	Form1.submit();
	Form1.hdnKensaku.value = "";
	Form1.target = ""
}*/
function fncPop(strId,strOptwidth){
	if(typeof strOptwidth === 'undefined') strOptwidth = "400";	
	var nowday = new Date();
	var name = "MSJAGJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds(); //2014/10/02 T.Ono add 2014改善開発 No20
	if (wP == null || wP.closed == true) {
	    wP = parent.fncPopupOpen(name,strOptwidth);
	} else {
	    wP.close();
	    wP = null;
	    wP = parent.fncPopupOpen(name,strOptwidth);
	}
	wP.focus();
	Form1.hdnKensaku.value = strId;
	Form1.target = name;
	Form1.submit();
	Form1.hdnKensaku.value = "";
	Form1.target = ""
}
// 2014/11/04 H.Hosoda mod ポップアップ表示幅変更 END
//**************************************
//イベントボタンに対してロックをかける
//**************************************
function fncBtnRoc(obj) {
    with (Form1) {
        //検索ボタン使用不可
        btnSelect.disabled = true;
		//登録ボタン使用不可
		btnUpdate.disabled=true;
		//削除ボタン使用不可
		btnDelete.disabled = true;
		//取消ボタン使用不可
		btnClear.disabled=true;
		//終了ボタン使用不可
		btnExit.disabled=true;
		//データ出力ボタン使用不可
		btnCSVOUT.disabled = true;
        //一括登録ボタン使用不可
		btnIKKATU.disabled = true;
		//クライアントコード検索ボタン使用不可
		btnKURACD.disabled = true;
		//JA支所コード（From）検索ボタン使用不可
		btnACBCD_F.disabled = true;
		//JA支所コード（To）検索ボタン使用不可
		btnACBCD_T.disabled = true;
		//グループコードボタン使用不可
		btnGROUPCD.disabled = true;
		//グループ追加ボタン使用不可
		btnGROUP_ADD.disabled = true;
		//グループコード名検索ボタン使用不可
		btnGROUP_SEARCH.disabled = true;
		//グループコード名変更確定ボタン使用不可
		btnGROUP_MOD.disabled = true;
	}
	fncFo(obj,5);
}
//**************************************
//イベントボタンに対してロックを解除する
//**************************************
function fncBtnUnRoc(obj) {
    with (Form1) {
        //検索ボタン使用不可
        btnSelect.disabled = false;
        //登録ボタン使用不可
        btnUpdate.disabled = false;
        //削除ボタン使用不可
        btnDelete.disabled = false;
        //取消ボタン使用不可
        btnClear.disabled = false;
        //終了ボタン使用不可
        btnExit.disabled = false;
        //データ出力ボタン使用不可
        btnCSVOUT.disabled = false;
        //一括登録ボタン使用不可
        btnIKKATU.disabled = false;
        //クライアントコード検索ボタン使用不可
        btnKURACD.disabled = false;
        //JA支所コード（From）検索ボタン使用不可
        btnACBCD_F.disabled = false;
        //JA支所コード（To）検索ボタン使用不可
        btnACBCD_T.disabled = false;
        //グループコードボタン使用不可
        btnGROUPCD.disabled = false;
        //グループ追加ボタン使用不可
        btnGROUP_ADD.disabled = false;
        //グループコード名検索ボタン使用不可
        btnGROUP_SEARCH.disabled = false;
        //グループコード名変更確定ボタン使用不可
        btnGROUP_MOD.disabled = false;
    }
    fncFo(obj, 5);
}
//**************************************
//区分を取得
//**************************************
function fncChengJAGKBN() {
    var select = document.getElementById('cboJAGKBN');
    var options = document.getElementById('cboJAGKBN').options;
    Form1.hdnJAGKBN.value = options.item(select.selectedIndex).value;

}
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtKURACD.focus()
}
//2017/02/09 w.ganeko add start 2016監視改善
//**************************************
//お客様コード使用設定
//**************************************
function fncChgUserCdTxt() {

    for (x = 1; x <= 100; x++) { // 1～100
        var objUSERCD_F = document.getElementById("txtUSERCD_F_" + x);
        var objUSERCD_T = document.getElementById("txtUSERCD_T_" + x);
        if (Form1.hdnJAGKBN.value == "003") {
            objUSERCD_F.value = "";
            objUSERCD_F.readOnly = true;
            objUSERCD_F.style.backgroundColor = 'Gainsboro';

            objUSERCD_T.value = "";
            objUSERCD_T.readOnly = true;
            objUSERCD_T.style.backgroundColor = 'Gainsboro';
        } else {
            objUSERCD_F.readOnly = false;
            objUSERCD_F.style.backgroundColor = 'white';
            objUSERCD_T.readOnly = false;
            objUSERCD_T.style.backgroundColor = 'white';
        }
    } // while
}
//2017/02/09 w.ganeko add end 2016監視改善
//**************************************
//Toへの自動セット 2019/11/01 T.Ono add 監視改善2019
//**************************************
function fncSetTo() {
    with (Form1) {

        //JA支所名Toセット
        if (hdnPopcrtl.value == '2') {
            hdnACBCD_T.value = "";
            txtACBCD_T.value = "";
            hdnACBCD_T.value = hdnACBCD_F.value;
            txtACBCD_T.value = txtACBCD_F.value;
        }
    }
}