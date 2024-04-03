window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
}
//**************************************
//画面オープン時
//**************************************
function window_open() {
	with(Form1) {
	    //画面の初期設定
	    // 2013/07/09 T.Ono 沖縄では表示しない
        if (document.getElementById("hdntab").value == "1") {
            document.getElementById('tab').style.display = "none";
            document.getElementById('spS1').style.display = "none";
            document.getElementById('spS2').style.display = "block";
        } else {
            document.getElementById('spS1').style.display = "block";
            document.getElementById('spS2').style.display = "none";
	    }
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
	Form1.hdnKBN.value = "1"; // 1:
	if (Form1.hdnKURACD_MOTO.value == ""){ // 新規？
	    strRes = confirm("登録してよろしいですか？");
	//▼▼▼ 2013/05/24 T.Ono mod 顧客単位登録機能追加 ▼▼▼
	//}else if (Form1.hdnKURACD.value == Form1.hdnKURACD_MOTO.value 
	//       && Form1.hdnCODE.value == Form1.hdnCODE_MOTO.value){ // キーが変わってない？
    //    strRes = confirm("登録してよろしいですか？");
    } else if (Form1.hdnKURACD.value == Form1.hdnKURACD_MOTO.value
	       && Form1.hdnCODE.value == Form1.hdnCODE_MOTO.value
           && Form1.txtUSER_CD_FROM.value == Form1.hdnUSER_CD_FROM_MOTO.value
           && Form1.txtUSER_CD_TO.value == Form1.hdnUSER_CD_TO_MOTO.value) { // キーが変わってない？) { // キーが変わってない？
        strRes = confirm("登録してよろしいですか？");
    //▲▲▲ 2013/05/24 T.Ono mod 顧客単位登録機能追加 ▲▲▲
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
	
	// データ項目を全て空にする→登録処理で削除となる。
	var i;
	//for (i = 1; i <= 10; i++) { // 1～10 2010/04/12 T.Watabe edit
	for (i = 1; i <= 30; i++) { // 1～30
		document.getElementById("txtTANNM_"+i).value = "";
		document.getElementById("txtRENTEL1_"+i).value = "";
		document.getElementById("txtRENTEL2_" + i).value = "";
		document.getElementById("txtRENTEL3_" + i).value = ""; // 2013/05/27 T.Ono add
		document.getElementById("txtFAXNO_"+i).value = "";
		document.getElementById("txtBIKO_"+i).value = "";
		document.getElementById("txtAUTO_MAIL_"+i).value = ""; // 2011/04/14 T.Watabe add
		document.getElementById("txtSPOT_MAIL_"+i).value = ""; // 2012/03/23 W.GANEKO add
		document.getElementById("txtMAIL_PASS_" + i).value = ""; // 2012/03/23 W.GANEKO add
		document.getElementById("txtAUTO_MAIL_PASS_" + i).value = ""; // 2013/07/11 T.Ono add
		document.getElementById("txtAUTO_FAXNO_" + i).value = ""; // 2013/07/11 T.Ono add
		document.getElementById("txtAUTO_FAXNM_" + i).value = ""; // 2013/07/18 T.Ono add
	}
    document.getElementById("txtGUIDELINE").value = ""; // 2013/07/11 T.Ono add
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
//  2014/01/27 T.Ono mod 監視改善2013 戻り先はマスタ管理メニュー
//	if(Form1.hdnBackUrl.value=="EIGYOU") {
//		strURL="../../../COGMENUG00.aspx";
//	} else if (Form1.hdnBackUrl.value=="KANSHI") {
//		strURL="../../../COGMENUG00.aspx";	
//	} else {
//		strURL="../../../COGMNMSG00.aspx";	
//	}
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
		//if (rdoKBN1.checked==true) {
	        //if (hdnKURACD.value.length==0) {                              //2012/04/20 NEC ou Del
	        if ((txtKURACD.value == " ") || (txtKURACD.value == "")) {      //2012/04/20 NEC ou Add
				alert("クライアントコードは必須です");
				btnKURACD.focus();
				return false;
			}
		//}
		//if (intKbn != 1) {
			//コード：必須
			//if (hdnCODE.value.length==0) {
            if ((txtCODE.value == " ") || (txtCODE.value == "")) {          //2012/04/20 NEC ou Add
                //　2013/06/24 T.ono mod
                //クライアントのみの登録を可能にするため、入力チェックを削除
                //意図的に空欄にされたものとして、"XXXX"を登録
//                alert("ＪＡ支所コードは必須入力です");
//                btnCODECD.focus();
//				return false;
				hdnCODE.value = 'XXXX'
			}
		//}

        // 2013/06/13 add T.Ono 
        //お客様コードFrom～Toの入力チェック
			var from;
			var to;
			from = txtUSER_CD_FROM.value.replace(/(^\s+)|(\s+$)/g, "")　//空白除去
			to = txtUSER_CD_TO.value.replace(/(^\s+)|(\s+$)/g, "")　　　//空白除去

			if ((from == "") && (to != "")) {
                //Toのみ入力
                alert("お客様コードの入力が不正です");
                return false;
            }
            if ((from.length != txtUSER_CD_FROM.value.length) || (to.length != txtUSER_CD_TO.value.length)) {
                //空白の入力
                alert("お客様コードの入力が不正です（空白の入力）");
                return false;
            }
            if ((from != "") && (to != "")) {
                if (from == to) {
                    alert("お客様コードの入力が不正です（同値）");
                    return false;
                }
                if (from.length != to.length) {
                    alert("お客様コードの入力が不正です（桁数）");
                    return false;
                }
                if (from > to) {
                    alert("お客様コードの入力が不正です（From>To）");
                    return false;
                }
            }



		//以下は　登録/修正時のみ
		if (intKbn == 3) {
		    //報告要・不要区分の変更をチェック 2015/02/18 T.Ono add 2014改善開発 No15 START
		    var res;
		    var faxja;
		    var faxkura;
            //JA
		    if (rdoFAXJA[0].checked) {
		        faxja = "";
		    } else if (rdoFAXJA[1].checked) {
		        faxja = "0";
		    } else if (rdoFAXJA[2].checked) {
		        faxja = "1";
		    }
            //ｸﾗｲｱﾝﾄ
		    if (rdoFAXKURA[0].checked) {
		        faxkura = "";
		    } else if (rdoFAXKURA[1].checked) {
		        faxkura = "0";
		    } else if (rdoFAXKURA[2].checked) {
		        faxkura = "1";
		    }
		    //alert("[" + hdnFAXJA_MOTO.value + "]:[" + faxja + "] [" + hdnFAXKURA_MOTO.value + "]:[" + faxkura + "]"); //デバッグ
		    if (((hdnFAXJA_MOTO.value != "9") && (hdnFAXJA_MOTO.value != faxja)) ||
                ((hdnFAXKURA_MOTO.value != "9") && (hdnFAXKURA_MOTO.value != faxkura))) { //hdnFAXKURA_MOTOは初期値"9"
		        res = confirm("報告要・不要区分が変更されましたがよろしいですか？")
		        if (res == false) {
		            btnUpdate.focus();
		            return false;
		        }
		    }
		    //2015/02/18 T.Ono add 2014改善開発 No15 END
                        
			var bExist = false;
			var i;
			//for (i = 1; i <= 10; i++) { // 1～10
			for (i = 1; i <= 30; i++) { // 1～30
				//objTANCD   = document.getElementById("txtTANCD_"+i);
				objTANNM   = document.getElementById("txtTANNM_"+i);
				objRENTEL1 = document.getElementById("txtRENTEL1_"+i);
				objRENTEL2 = document.getElementById("txtRENTEL2_" + i);
				objRENTEL3 = document.getElementById("txtRENTEL3_" + i);    // 2013/05/23 T.Ono add
				objFAXNO   = document.getElementById("txtFAXNO_"+i);
				objBIKO    = document.getElementById("txtBIKO_"+i);
				objAUTO_MAIL    = document.getElementById("txtAUTO_MAIL_"+i); // 2011/04/14 T.Watabe add
				objSPOT_MAIL    = document.getElementById("txtSPOT_MAIL_"+i); // 2012/03/23 W.GANEKO add
				objMAIL_PASS = document.getElementById("txtMAIL_PASS_" + i); // 2012/03/23 W.GANEKO add
				//▼▼▼ 2013/05/23 T.Ono add 顧客単位登録機能追加 ▼▼▼
				objAUTO_MAIL_PASS   = document.getElementById("txtAUTO_MAIL_PASS_" + i);
				objAUTO_FAXNO = document.getElementById("txtAUTO_FAXNO_" + i);
				objAUTO_FAXNM = document.getElementById("txtAUTO_FAXNM_" + i);
				objAUTO_KBN         = document.getElementById("cboAUTO_KBN_" + i);
				objAUTO_ZERO_FLG    = document.getElementById("cboAUTO_ZERO_FLG_" + i);
				//▲▲▲ 2013/05/23 T.Ono add 顧客単位登録機能追加 ▲▲▲

				// 2013/05/23 T.Ono add 顧客単位登録機能追加
				// 2011/04/14 T.Watabe add  objAUTO_MAIL
				if (   objTANNM.value.length   != 0 
				    || objRENTEL1.value.length != 0 
				    || objRENTEL2.value.length != 0 
				    || objFAXNO.value.length   != 0 
				    || objBIKO.value.length    != 0 
				    || objAUTO_MAIL.value.length    != 0
				    || objSPOT_MAIL.value.length    != 0
				    || objMAIL_PASS.value.length != 0  
                    || objRENTEL3.value.length    != 0
                    || objAUTO_MAIL_PASS.value.length    != 0
                    || objAUTO_FAXNO.value.length != 0
                    || objAUTO_FAXNM.value.length != 0
                    || objAUTO_KBN.value.length != 0
                    || objAUTO_ZERO_FLG.value.length != 0) {
				    
					//担当者コード
					//if (objTANCD.value.length == 0) {
					//	alert("担当者コードは必須入力です");
					//	objTANCD.focus();
					//	return false;
					//}
					//ＪＡ支所担当者コードは1～10で入力してください
					//if (fncNumChk(objTANCD.value) == false) {
					//	alert("ＪＡ支所担当者コードは1～10で入力してください");
					//	objTANCD.focus();
					//	return false;
					//}
					//if ((parseInt(objTANCD.value) < 1) || (parseInt(objTANCD.value) > 10)) {
					//	alert("ＪＡ支所担当者コードは1～10で入力してください");
					//	objTANCD.focus();
					//	return false;
					//}
					//担当名漢字
					if (objTANNM.value.length==0) {
						showtab(0); // 2011/11/09 ADD H.Uema
						alert("担当名漢字は必須入力です");
						objTANNM.focus();
						return false;
					}
					//電話番号１：必須チェック(ＪＡ担当者)
					//if (rdoKBN1.checked==true) {
						if (objRENTEL1.value.length==0) {
							showtab(0); // 2011/11/09 ADD H.Uema
							alert("ＪＡ支所担当者の場合、電話番号１は必須です");
							objRENTEL1.focus();
							return false;
						}
					//}
					//電話番号１：電話番号チェック
					if (fncChkTel(objRENTEL1.value) == false) {
						showtab(0); // 2011/11/09 ADD H.Uema
						alert("電話番号１は正しい電話番号ではありません");
						objRENTEL1.focus();
						return false;
					}
					//電話番号２：電話番号チェック
					if (fncChkTel(objRENTEL2.value) == false) {
						showtab(0); // 2011/11/09 ADD H.Uema
						alert("電話番号２は正しい電話番号ではありません");
						objRENTEL2.focus();
						return false;
		            }
		            // 2013/05/23 T.Ono add 顧客単位登録機能追加
                    //電話番号３：電話番号チェック
		            if (fncChkTel(objRENTEL3.value) == false) {
		                showtab(0);
		                alert("電話番号３は正しい電話番号ではありません");
		                objRENTEL3.focus();
		                return false;
		            }
					//ＦＡＸ番号：電話番号チェック
					if (fncChkTel(objFAXNO.value) == false) {
						showtab(0); // 2011/11/09 ADD H.Uema
						alert("ＦＡＸ番号は正しいＦＡＸ番号ではありません");
						objFAXNO.focus();
						return false;
		            }
		            // 2013/05/23 T.Ono add 顧客単位登録機能追加
		            //自動ＦＡＸ番号：電話番号チェック
		            if (fncChkTel(objAUTO_FAXNO.value) == false) {
		                showtab(0); // 2011/11/09 ADD H.Uema
		                alert("ＦＡＸ番号は正しいＦＡＸ番号ではありません");
		                objAUTO_FAXNO.focus();
		                return false;
		            }
					
					bExist = true; // 値あり！
				} // if
				

			}// while
			
			// ▼▼▼ 2011/11/09 ADD H.Uema ▼▼▼
			//JA注意事項(レングスチェック)
            // 2013/06/25 T.Ono mod 2000byteに拡張
            //if (jstrlen(txtGUIDELINE.value) > 1000) {
            if(jstrlen(txtGUIDELINE.value) > 2000) {
				showtab(1);
				//alert("JA注意事項は 1000byte 以下で入力して下さい");
				alert("注意事項は 2000byte 以下で入力して下さい");
				txtGUIDELINE.focus();
				return false;
			}
			// ▲▲▲ 2011/11/09 ADD H.Uema ▲▲▲
				
			if (bExist == false){ // データが1件も入力されていない？
			    if (txtAYMD.value == ""){ // 新規？
			        alert("データを入力して下さい。");
			        txtTANNM_1.focus();
					return false;
			    }
			}
		} // if 登録時のみ

		//以下は　削除時のみ
		if (intKbn == 4) {
			
			if (txtAYMD.value.length == 0){ // 新規？
			    alert("削除対象データがありません。");
			    txtTANNM_1.focus();
				return false;
			}
			
			if (hdnKURACD_MOTO.value.length == 0){ // 新規？
			    alert("削除対象データがありません。");
			    txtTANNM_1.focus();
				return false;
			}
            // 2013/05/24 T.Ono mod 顧客単位登録機能追加
//			if (Form1.hdnKURACD.value != Form1.hdnKURACD_MOTO.value
//				|| Form1.hdnCODE.value != Form1.hdnCODE_MOTO.value) { // キーが変わっている？
            if (Form1.hdnKURACD.value != Form1.hdnKURACD_MOTO.value
				|| Form1.hdnCODE.value != Form1.hdnCODE_MOTO.value
                || Form1.txtUSER_CD_FROM.value != Form1.hdnUSER_CD_FROM_MOTO.value
                || Form1.txtUSER_CD_TO.value != Form1.hdnUSER_CD_TO_MOTO.value) { // キーが変わっている？
				alert("キーが変更されています。再度検索して下さい。");
				return false;
			}
			
		} // if 削除時のみ
	} // with
	return true;
}
//**************************************
//担当者区分が変更された時
//**************************************
//function fncTanto(obj,ind) {
//	if (ind == "0"){
//		fncClearTanto()
//	}
//	//ＪＡ支所担当者
//	if(ind == "0"){
//		Form1.btnKURACD.disabled=false;
//	}
//	sp1.style.visibility="visible";
//	lblCODE.innerText="ＪＡ支所コード";	
//}
//**************************************
//担当者区分が変更時の値クリア
//**************************************
//function fncClearTanto() {
//	with(Form1) {
//		txtKURACD.value='';
//		hdnKURACD.value='';		
//		hdnCODE.value='';
//		txtCODE.value='';
//	}
//}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {
    //2015/02/18 T.Ono mod 2014改善開発 No15 START
    ////2012/04/20 NEC ou Upd
	////if (strFlg == "2" && Form1.hdnKURACD.value.length == 0) {
    //if (strFlg == "2" &&
    //   ((Form1.txtKURACD.value == " ") || (Form1.txtKURACD.value == ""))) {
    if ((strFlg == "2" || strFlg == "3")  &&
       ((Form1.txtKURACD.value == " ") || (Form1.txtKURACD.value == ""))) {
    //2015/02/18 T.Ono mod 2014改善開発 No15 END
		alert("クライアントコードを選択してください");
		Form1.btnKURACD.focus();
	} else {
		Form1.hdnPopcrtl.value = strFlg;
		//2015/02/18 T.Ono mod 2014改善開発 No15 START
        //fncPop('COPOPUPG00');
		if (strFlg == '3') {
		    fncPop('COPOPUPG00', "700");
		} else {
		    fncPop('COPOPUPG00');
		}
		//2015/02/18 T.Ono mod 2014改善開発 No15 END
	}
}
// 2011/12/07 add h.uema
//**************************************
//tipsボタン押下
//**************************************
function btnTips_onclick() {
	fncPop('MSTAJJPG00');
}
//*********************************
//ポップアップ用
//*********************************
var wP;
//function fncPop(strId) { //2015/02/18 T.Ono mod 2014改善開発 No15
function fncPop(strId, strOptwidth) {
    if (typeof strOptwidth === 'undefined') strOptwidth = "400"; //2015/02/18 T.Ono add 2014改善開発 No15
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "MSTAJJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
	//2014/10/15 H.Hosoda add 2014改善開発 No20 END
	if (wP == null||wP.closed== true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
	    //wP = parent.fncPopupOpen(name); //2015/02/18 T.Ono mod 2014改善開発 No15
	    wP = parent.fncPopupOpen(name, strOptwidth);
    } else {
        wP.close();
        wP = null;
        //wP = parent.fncPopupOpen(name); //2015/02/18 T.Ono mod 2014改善開発 No15
        wP = parent.fncPopupOpen(name, strOptwidth);
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
		//btnDelete.disabled=true;
		//検索ボタン使用不可
		btnSelect.disabled=true;
		//新規ボタン使用不可
		//btnInsert.disabled=true;
		//取消ボタン使用不可
		btnClear.disabled=true;
		//終了ボタン使用不可
		btnExit.disabled=true;
		//クライアントコード検索ボタン使用不可
		btnKURACD.disabled=true;
		//コード検索ボタン使用不可
		btnCODECD.disabled=true;
	}
	fncFo(obj,5);
}
//**************************************
// ファイルアップロードボタン押下時の処理
//**************************************
function btnFileUpload_onclick() {
	with(Form1) {
	    //if (hdnKURACD.value.length==0) {                              //2012/04/20 NEC ou Del
	    if ((txtKURACD.value == " ") || (txtKURACD.value == "")) {      //2012/04/20 NEC ou Add
			alert("クライアントコードは必須です");
			btnKURACD.focus();
			return false;
		}
	}
	return true;
}
// ▼▼▼ 2011/11/08 ADD H.Uema タブ対応 ▼▼▼
//**************************************
// タブ切替用変数
//**************************************
var tab = {
	init: function(){
		var tabs = this.setup.tabs;
		var pages = this.setup.pages;
		
		for(i=0; i<pages.length; i++) {
			if(i !== 0) pages[i].style.display = 'none';
			tabs[i].onclick = function(){ tab.showpage(this); return false; };
		}
	},
	
	showpage: function(obj){
		var tabs = this.setup.tabs;
		var pages = this.setup.pages;
		var num;
		
		for(num=0; num<tabs.length; num++) {
			if(tabs[num] === obj) break;
		}
		
		for(var i=0; i<pages.length; i++) {
			if(i == num) {
				pages[num].style.display = 'block';
				tabs[num].className = 'present';
			}
			else{
				pages[i].style.display = 'none';
				tabs[i].className = null;
			}
		}
	}
}
//**************************************
// プレビューボタン押下時の処理
//**************************************
function hpre(obj) {
    document.getElementById('pre').innerHTML = obj.value + "&nbsp;";
    // 2013/06/24 T.ono add クライアントのみ/クライアント＋JA支所でプレビューの表示サイズを変える
    if ((Form1.txtCODE.value == " ") || (Form1.txtCODE.value == "")) {
        document.getElementById('pre').style.height = '202'
    }else{
        document.getElementById('pre').style.height = '420'
    }
    
}
//**************************************
// タブ切替
//**************************************
function showtab(tabno){
	if (tab.setup.tabs.length > tabno) {
		tab.showpage(tab.setup.tabs[tabno])	
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
// ▲▲▲ 2011/11/08 ADD H.Uema タブ対応 ▲▲▲
//▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
//**************************************
// タブ切替用変数
//**************************************
var tab2 = {
	init: function(){
		var tabs = this.setup.tabs;
		var pages = this.setup.pages;
		
		for(i=0; i<pages.length; i++) {
			if(i !== 0) pages[i].style.display = 'none';
			tabs[i].onclick = function(){ tab.showpage2(this); return false; };
		}
	},
	
	showpage2: function(obj){
		var tabs = this.setup.tabs;
		var pages = this.setup.pages;
		var num;
		
		for(num=0; num<tabs.length; num++) {
			if(tabs[num] === obj) break;
		}
		
		for(var i=0; i<pages.length; i++) {
			if(i == num) {
				pages[num].style.display = 'block';
				tabs[num].className = 'present';
			}
			else{
				pages[i].style.display = 'none';
				tabs[i].className = null;
			}
		}
	}
}

//**************************************
// 報告用・不要区分の表示・非表示切り替え　2013/12/13 T.Ono add 監視改善
// 2015/02/18 T.Ono 2014改善開発 No15 にて使用しなくなった
//**************************************
function fncFAXKBNDisp() {
    with (Form1) {
        if ((txtCODE.value == " ") || (txtCODE.value == "")) {
            document.getElementById('tblFAX_Default').style.display = "none";
            document.getElementById('lblpre').innerHTML = "クライアント注意事項";
        } else {
            document.getElementById('tblFAX_Default').style.display = "block";
            document.getElementById('lblpre').innerHTML = "JA注意事項";
        }
    }
}

//**************************************
// コピーボタン押下　2015/02/17 T.Ono add 2014改善開発 No15
//**************************************
function fncIchiran_Copy() {

    var i;
    var str = "";
    var cnt = 0;
    var chk = "0"; //チェック有無のチェックに使用

    //コピー
    for (i = 1; i <= 30; i++) { // 1～30
        objCopy = document.getElementById("chkCopy_" + i);
        if (objCopy.checked) {
            chk = "1";
            if (cnt == 0) {
                cnt = 1;
            } else {
                str += "\n" //2行目以降は改行を付けてから値を格納
            }
            str += document.getElementById("txtTANNM_" + i).value;
            str += "," + document.getElementById("txtRENTEL1_" + i).value;
            str += "," + document.getElementById("txtRENTEL2_" + i).value;
            str += "," + document.getElementById("txtRENTEL3_" + i).value;
        }
    }

    //ｺﾋﾟﾍﾟチェック有無のチェック
    if (chk == "0") {
        //ｺﾋﾟﾍﾟチェック無し
        alert("チェックを付けてください。");
        Form1.btnICHIRAN_COPY.focus();
        return;
    } else {
        window.clipboardData.setData("text", str)
        alert("コピー元のチェックを外し、コピー先をチェックしてください。");
    }
}

//**************************************
// ペーストボタン押下　2015/02/17 T.Ono add 2014改善開発 No15
//**************************************
function fncIchiran_Paste() {
    
    var str = window.clipboardData.getData("text"); //クリップボードの値取得
    var row;
    var col;
    var i;
    var j = 0;
    var chk = "0"; //チェック有無のチェックに使用

    //上書きチェック
    for (i = 1; i <= 30; i++) { // 1～30
        objCopy = document.getElementById("chkCopy_" + i);
        if (objCopy.checked) {
            chk = "1";
            if  ((document.getElementById("txtTANNM_" + i).value != "") ||
                (document.getElementById("txtRENTEL1_" + i).value != "") ||
                (document.getElementById("txtRENTEL2_" + i).value != "") ||
                (document.getElementById("txtRENTEL3_" + i).value != "")) {

                var res = confirm("上書きしてよろしいですか？");
                if (res == false) {
                    Form1.btnICHIRAN_PASTE.focus();
                    return;
                } else {
                    break;
                }
            }
        }
    }

    //ｺﾋﾟﾍﾟチェック有無のチェック
    if (chk == "0") {
        alert("チェックを付けてください。");
        Form1.btnICHIRAN_PASTE.focus();
        return;
    }

    //クリップボードの値を格納
    if (str) {
        //1行ずつrowに格納
        row = str.split("\n");
    } else {
        //何もコピーされていなければ抜ける
        return;
    }

    //貼り付け
    for (i = 1; i <= 30; i++) { // 1～30
        objCopy = document.getElementById("chkCopy_" + i);
        if (objCopy.checked) { //チェックがある行に貼り付け
            if (row.length > 0 && j < row.length) {
                col = row[j].split(",") //カンマ区切りでcolに格納
                if (typeof col[0] != "undefined") { document.getElementById("txtTANNM_" + i).value = col[0]; }
                if (typeof col[1] != "undefined") { document.getElementById("txtRENTEL1_" + i).value = col[1]; }
                if (typeof col[2] != "undefined") { document.getElementById("txtRENTEL2_" + i).value = col[2]; }
                if (typeof col[3] != "undefined") { document.getElementById("txtRENTEL3_" + i).value = col[3]; }
                j++;
            }
        }
    }
}

//**************************************
// クリアボタン押下　2015/02/17 T.Ono add 2014改善開発 No15
//**************************************
function fncIchiran_Clear() {

    var chk = "0"; //チェック有無のチェックに使用
    
    //クリア
    for (i = 1; i <= 30; i++) { // 1～30
        objCopy = document.getElementById("chkCopy_" + i);
        if (objCopy.checked) { //チェックがある行クリア
            chk = "1"
            document.getElementById("txtTANNM_" + i).value = "";
            document.getElementById("txtRENTEL1_" + i).value = "";
            document.getElementById("txtRENTEL2_" + i).value = "";
            document.getElementById("txtRENTEL3_" + i).value = "";
        }
    }
    
    //ｺﾋﾟﾍﾟチェック有無のチェック
    if (chk == "0") {
        alert("チェックを付けてください。");
        Form1.btnICHIRAN_CLEAR.focus();
        return;
    }

}

//**************************************
// 登録済み一覧選択後、お客様コードをセット　2015/02/18 T.Ono add 2014改善開発 No15
//**************************************
function fncSetUserCD() {

    var str;

    with (Form1) {
        //一旦クリアする
        txtUSER_CD_FROM.value = "";
        txtUSER_CD_TO.value = "";
        txtUSER_NM.value = "";
    
        //カンマ区切りで格納
        str = hdnUSER_CD_TEMP.value.split(",")
        //alert(str.length + ":" + str[0] + ":" + str[1]);
        //お客様コードFrom
        if (str.length > 0) {
            txtUSER_CD_FROM.value = str[0];
        }
        //お客様コードTo
        if (str.length > 1) {
            txtUSER_CD_TO.value = str[1];
        }
    }
}
