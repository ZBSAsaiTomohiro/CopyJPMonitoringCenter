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
	if (Form1.hdnGROUPCD_MOTO.value == ""){ // 新規？
	    strRes = confirm("登録してよろしいですか？");
	} else if ((Form1.txtGROUPCD_NEW.value.length != 0) && (Form1.hdnGROUPCD_MOTO.value.length != 0)) { // 検索＋新規登録用に入力あり
	    strRes = confirm("コピー登録してよろしいですか？\n※既に登録済みはエラーとなります。");
	} else if (Form1.hdnGROUPCD.value == Form1.hdnGROUPCD_MOTO.value) { // キーが変わってない？) 
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
//全て選択or全て解除ボタン押下時の処理
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
        //終了ボタンロック解除
        btnCSVout.disabled = false;
        // 2023/02/08 ADD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
        //更新：使用可へボタンロック解除
        btnUpdateJtFlgAllOn.disabled = false;
        //更新：使用不可へボタンロック解除
        btnUpdateJtFlgAllOff.disabled = false;
        // 2023/02/08 ADD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
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
	//2014/10/15 H.Hosoda del インターフェースエラー回避
    //if (wP != null) {
    //    parent.window_onunload()
    //}
	var strURL;
	strURL = "../../../COGMNMSG00.aspx";
	parent.frames("data").location=strURL;
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	//---------------------------------
    //intKbn  1:検索　3:登録/修正 4:削除 5:データ出力
	//---------------------------------
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}

	//<TODO> 入力値チェック
    with (Form1) {
	    if (intKbn != 3) {
	        if (hdnGROUPCD.value.length == " ") {
	            alert("グループコードは必須です");
	            cboGROUPCD.focus();
	            return false;
	        }
	    }else{
	        if ((hdnGROUPCD.value.length == 0) && (txtGROUPCD_NEW.value.length == 0)) {
	            alert("グループコードは必須です");
	            cboGROUPCD.focus();
	            return false;
	        }   
        }

		if (intKbn != 5) {
		    var x;
		    var dupCD1 = null;
		    var dupNM1 = null;
		    var dupCD2 = null;
		    var dupNM2 = null;
		    var dupCD3 = null;
		    var dupchk = false;
		    for (x = 1; x <= 30; x++) { // 1～30
		        dupCD1 = document.getElementById("txtKMCD_" + x);
		        dupNM1 = document.getElementById("txtKMNM_" + x);
		        if (dupCD1.value.length != 0) {
		            var y;
		            for (y = x + 1; y <= 30; y++) { // 1～30
		                dupCD2 = document.getElementById("txtKMCD_" + y);
		                dupNM2 = document.getElementById("txtKMNM_" + y);
		                if (dupCD2.value.length != 0) {
		                    if ((dupCD1.value + dupNM1.value) == (dupCD2.value + dupNM2.value)) {
		                        dupchk = true;
		                        dupCD3 = dupCD2;
		                    }
		                }
		            } // while
		        }
		    } // while
		    if (dupchk) {
		        alert("警報コード・名称が重複しています。");
		        dupCD3.focus();
		        return false;
		    }
		}
		//以下は　登録/修正時のみ
		if (intKbn == 3) {
			
			var bExist = false;
			var i;
			for (i = 1; i <= 30; i++) { // 1～30
				objKMCD = document.getElementById("txtKMCD_"+i);
				objKMNM = document.getElementById("txtKMNM_" + i);
				objPROCKBN = document.getElementById("cboPROCKBN_" + i);
				objTAIOKBN = document.getElementById("cboTAIOKBN_" + i);
				objTMSKB = document.getElementById("cboTMSKB_" + i);
				objTKTANCD = document.getElementById("txtTKTANCD_" + i);
				objTAITCD = document.getElementById("cboTAITCD_" + i);
				objTFKICD = document.getElementById("cboTFKICD_" + i);
				objTKIGCD = document.getElementById("cboTKIGCD_" + i);
				objTSADCD = document.getElementById("cboTSADCD_" + i);
				objTELRCD = document.getElementById("cboTELRCD_" + i);
				objTEL_MEMO1 = document.getElementById("txtTEL_MEMO1_" + i);
				objBIKO = document.getElementById("txtBIKO_" + i);
				if (objKMCD.value.length != 0
				    || objKMNM.value.length != 0
                    || objPROCKBN.value.length != 0
                    || objTAIOKBN.value.length != 0
                    || objTMSKB.value.length != 0
                    || objTKTANCD.value.length != 0
                    || objTAITCD.value.length != 0
                    || objTFKICD.value.length != 0
                    || objTKIGCD.value.length != 0
                    || objTSADCD.value.length != 0
                    || objTELRCD.value.length != 0
                    || objTEL_MEMO1.value.length != 0
                    || objBIKO.value.length != 0) {

				    if (objKMCD.value.length == 0) {
                        alert("警報コードは必須入力です");
                        objKMCD.focus();
						return false;
					}
		            if (objKMNM.value.length == 0) {
		                alert("警報名称は必須入力です");
		                objKMNM.focus();
		                return false;
		            }
		            if (objPROCKBN.value.length == 0) {
		                alert("対応／無視区分は必須入力です");
		                objPROCKBN.focus();
		                return false;
		            }
		            if (fncNumChk(objKMCD.value) == false) {
		                alert("警報コードは数値を入力してください");
		                objKMCD.focus();
		                return false;
		            }
		            if (fncNumChk(objTKTANCD.value) == false) {
		                alert("監視センター担当者コードは数値を入力してください");
		                objTKTANCD.focus();
		                return false;
		            }
					bExist = true; // 値あり！
				} // if
			}// while
			
			if (bExist == false){ // データが1件も入力されていない？
			    if (txtKMCD_1.value == ""){ // 新規？
			        alert("データを入力して下さい。");
			        txtKMCD_1.focus();
					return false;
			    }
			}
    	} // if 登録時のみ

		//以下は　削除時のみ
		if (intKbn == 4) {
				
			if (hdnGROUPCD_MOTO.value.length == 0){ // 新規？
			    alert("削除対象データがありません。");
			    txtKMCD_1.focus();
				return false;
			}
            if (hdnGROUPCD.value != hdnGROUPCD_MOTO.value) { // キーが変わっている？
                alert("キーが変更されています。再度検索して下さい。");
                cboGROUPCD.focus();
				return false;
			}
            var bExist = false;
            for (i = 1; i <= 30; i++) { // 1～30
			    objDEL = document.getElementById("chkDEL_" + i);
			    objKMCD = document.getElementById("txtKMCD_" + i);
			    objKMNM = document.getElementById("txtKMNM_" + i);
			    objPROCKBN = document.getElementById("cboPROCKBN_" + i);
			    if (objKMCD.value.length != 0
				    && objKMNM.value.length != 0
                    && objPROCKBN.value.length != 0 ) {

			        if (objDEL.checked) {
			            bExist = true; // 値あり！
                    }
			    }
			}
			if (bExist == false) {
			    alert("削除対象データがありません。");
			    txtKMCD_1.focus();
			    return false;
			}
		} // if 削除時のみ
	} // with
	return true;
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
		//取消ボタン使用不可
		btnClear.disabled=true;
		//終了ボタン使用不可
		btnExit.disabled=true;
		//データ出力ボタン使用不可
        btnCSVout.disabled = true;

        // 2023/02/08 ADD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
        //更新：使用可へボタン使用不可
        btnUpdateJtFlgAllOn.disabled = true;
        //更新：使用不可へボタン使用不可
        btnUpdateJtFlgAllOff.disabled = true;
        // 2023/02/08 ADD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
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
//*********************************
//警報一覧ボタン押下
//*********************************
function btnKEIHOList_onclick() {
    fncPop('MSJINJCG00');
}

//*********************************
//ポップアップ用
//*********************************
var wP;
//function fncPop(strId) {
//	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
//    var nowday = new Date();
//    var name = "MSJINJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
//	//2014/10/15 H.Hosoda add 2014改善開発 No20 END
//    if (wP == null || wP.closed == true) {
//        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
//        wP = parent.fncPopupOpen(name); 
//    } else {
//        wP.close();
//        wP = null;
//        wP = parent.fncPopupOpen(name);
//    }
//    wP.focus();
//    Form1.hdnKensaku.value = strId;
//	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
//	Form1.target = name;
//    Form1.submit();
//    Form1.hdnKensaku.value = "";
//    Form1.target = ""
//}
function fncPop(strId, strOptwidth) {
    if (typeof strOptwidth === 'undefined') strOptwidth = "400";
    var nowday = new Date();
    var name = "MSJAGJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds(); //2014/10/02 T.Ono add 2014改善開発 No20
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
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {

    fncPop('COPOPUPG00', "600");
}
//**************************************
//全使用可能or全使用不可ボタン押下時の処理 2021/10/01 2021年度監視改善⑤sakaADD 使用フラグを一括で変更
//**************************************
function btnAllUseFlg(btn) {
    if (btn == "1") {
        for (i = 1; i <= 30; i++) { // 1～30
            document.getElementById("cboUSE_FLG_" + i).value = "1";
        }
    } else if (btn == "2") {
        for (i = 1; i <= 30; i++) { // 1～30
            document.getElementById("cboUSE_FLG_" + i).value = "0";
        }
    }
}
// 2023/02/07 ADD START Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応
//**************************************
//範囲指定：全使用可能or全使用不可処理（警報No08_感震器遮断、No15_安全確認中遮断の2種用） 
//**************************************
function btnAllUseFlgFromTo(btn) {
    with (Form1) {

        //単体入力チェック→相互間範囲チェック
        if (cboJTLISTFROM.value == "" || cboJTLISTFROM.value == " ") { //選択チェック:（範囲）From
            alert('グループコード・名称（範囲）Fromを選択して下さい');
            cboJTLISTFROM.focus();
            return false;
        } else if (cboJTLISTTO.value == "" || cboJTLISTTO.value == " ") { //選択チェック:（範囲）To
            alert('グループコード・名称（範囲）Toを選択して下さい');
            cboJTLISTTO.focus();
            return false;
        } else if (cboJTLISTFROM.value > cboJTLISTTO.value) {　//範囲チェック
            alert('グループコード・名称（範囲）の前後関係を確認して下さい。');
            cboJTLISTFROM.focus();
            return false;
        }

        var postBackName = "btnUpdateJtFlgAllOn"; //初期値："1_一括：使用可
        var updUseFlgType = "更新内容…使用フラグ【1：使用可】";
        var focusButtonName = Form1.btnUpdateJtFlgAllOn; //初期値：使用可ボタン
        //チェック用
        if (btn == "1") {
            postBackName = "btnUpdateJtFlgAllOn";
        } else if (btn == "2") {
            postBackName = "btnUpdateJtFlgAllOff";
            updUseFlgType = "更新内容…使用フラグ【0：使用不可】";
            var focusButtonName = Form1.btnUpdateJtFlgAllOff; //使用不可ボタン
        }

        //確認メッセージ-----------
        Form1.hdnKBN.value = "2"; // 2:修正（更新）
        strRes = confirm("使用区分の範囲一括更新を実施します。よろしいですか？\r\n" + updUseFlgType);
        if (strRes == false) {
            return;
        }
        fncBtnRoc(focusButtonName); // ボタン非活性化＋押下ボタンへ再度focus当てる？ Form1.ボタン名
        doPostBack(postBackName, ''); //更新処理呼出し

    }

}
// 2023/02/07 ADD END   Y.ARAKAKI 2022更改No⑤ _自動対応内容マスタ_特定警報Noの使用フラグ一括設定追加対応

