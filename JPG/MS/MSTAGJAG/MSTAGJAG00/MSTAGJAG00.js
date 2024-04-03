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
	    //沖縄では表示しない
	    if (document.getElementById("hdntab").value == "1") {
	        document.getElementById('tab3').style.display = "none";　//注意事項タブ
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
	if ((Form1.hdnKURACD_MOTO.value == "") && (Form1.hdnGROUPCD_MOTO.value == "")){ // 新規？(検索してない)
	    strRes = confirm("登録してよろしいですか？");
	} else if (Form1.hdnKURACD.value == Form1.hdnKURACD_MOTO.value
           && Form1.hdnGROUPCD.value == Form1.hdnGROUPCD_MOTO.value
	       && Form1.txtGROUPNEW.value == "") { // キーが変わってない？)(検索後、登録)
        strRes = confirm("登録してよろしいですか？");
	}else{ //その他(検索後、キーを変え登録)
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
	for (i = 1; i <= 30; i++) { // 1～30
		document.getElementById("txtTANNM_"+i).value = "";
		document.getElementById("txtRENTEL1_"+i).value = "";
		document.getElementById("txtRENTEL2_" + i).value = "";
		document.getElementById("txtRENTEL3_" + i).value = ""; 
		document.getElementById("txtFAXNO_"+i).value = "";
		document.getElementById("txtBIKO_" + i).value = "";
		document.getElementById("txtSPOT_MAIL_" + i).value = "";
		document.getElementById("txtMAIL_PASS_" + i).value = ""; 
		document.getElementById("txtAUTO_FAXNM_" + i).value = ""; 
		document.getElementById("txtAUTO_MAIL_"+i).value = ""; 
		document.getElementById("txtAUTO_MAIL_PASS_" + i).value = ""; 
		document.getElementById("txtAUTO_FAXNO_" + i).value = ""; 
	}
    document.getElementById("txtGROUPNM").value = ""; 
    document.getElementById("txtGUIDELINE").value = ""; 
    document.getElementById("txtGUIDELINE2").value = "";  //2019/11/01 w.ganeko 2019監視改善
    document.getElementById("txtGUIDELINE3").value = "";  //2019/11/01 w.ganeko 2019監視改善
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
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	//---------------------------------
	//intKbn  1:検索　2:新規　3:登録/修正 4:削除
	//---------------------------------
//	//入力禁止文字チェック
//	if(fncChkChar()==false){
//		return false;
//	}
	//<TODO> 入力値チェック
	with(Form1) {
        
        //検索時(intKbn=1)
	    if (intKbn == 1) {
	        //クライアントまたは、グループコード必須
	        if (((txtKURACD.value == " ") || (txtKURACD.value == "")) && ((txtGROUPCD.value == " ") || (txtGROUPCD.value == ""))){
			    alert("検索条件を選択してください");
			    btnGROUPCD.focus();
			    return false;
		    }

			//JA支所があって、グループコードなしはNG
			if (((txtACBCD.value != " ") && (txtACBCD.value != "")) && ((txtGROUPCD.value == " ") || (txtGROUPCD.value == ""))) {
			    alert("グループコードを選択してください");
			    btnGROUPCD.focus();
			    return false;
			}
	    }
        

		//以下は　登録/修正時のみ
        if (intKbn == 3) {

            //入力禁止文字チェック
            if (fncChkChar_MSTAG() == false) {
                return false;
            }

            //クライアントコードまたは、グループコードまたは、グループコード（新規登録用）必須
            if (((txtKURACD.value == " ") || (txtKURACD.value == ""))　&&
            　　((txtGROUPCD.value == " ") || (txtGROUPCD.value == "")) && 
                ((txtGROUPNEW.value == " ") || (txtGROUPNEW.value == ""))) {
                alert("クライアントコードまたはグループコードを選択してください");
                btnGROUPCD.focus();
                return false;
            }


		    //報告要・不要区分の変更をチェック
		    var res;
		    var faxja;
		    var faxkura;
            //JA
		    if (rdoFAXJA[0].checked) {
		        faxja = "0";
		    } else if (rdoFAXJA[1].checked) {
		        faxja = "1";
		    }
            //ｸﾗｲｱﾝﾄ
		    if (rdoFAXKURA[0].checked) {
		        faxkura = "0";
		    } else if (rdoFAXKURA[1].checked) {
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

		    //グループコード名(レングスチェック)
		    if (fnc_byteCheck(txtGROUPNM.value) > 60) {
		        showtab(0); 
                alert("グループコード名は全角30文字以内で入力して下さい");
		        txtGROUPNM.focus();
		        return false;
		    }
                        
			var bExist = false;
			var i;
			for (i = 1; i <= 30; i++) { // 1～30
				objTANNM   = document.getElementById("txtTANNM_"+i);
				objRENTEL1 = document.getElementById("txtRENTEL1_"+i);
				objRENTEL2 = document.getElementById("txtRENTEL2_" + i);
				objRENTEL3 = document.getElementById("txtRENTEL3_" + i);    
				objFAXNO   = document.getElementById("txtFAXNO_"+i);
				objBIKO    = document.getElementById("txtBIKO_"+i);
				objSPOT_MAIL = document.getElementById("txtSPOT_MAIL_" + i); 
				objMAIL_PASS = document.getElementById("txtMAIL_PASS_" + i); 
				objAUTO_FAXNM = document.getElementById("txtAUTO_FAXNM_" + i);
				objAUTO_MAIL = document.getElementById("txtAUTO_MAIL_" + i); 
				objAUTO_MAIL_PASS = document.getElementById("txtAUTO_MAIL_PASS_" + i);
				objAUTO_FAXNO = document.getElementById("txtAUTO_FAXNO_" + i);
				objAUTO_KBN = document.getElementById("cboAUTO_KBN_" + i);
				objAUTO_ZERO_FLG = document.getElementById("cboAUTO_ZERO_FLG_" + i);


				if (i == 1) {
				    //コード01は必須
                    //担当名漢字
				    if (objTANNM.value.length == 0) {
				        showtab(0);
				        alert("担当名漢字は必須入力です");
				        objTANNM.focus();
				        return false;
				    }
				    //電話番号１：必須チェック

				    if (objRENTEL1.value.length == 0) {
				        showtab(0);
				        alert("電話番号１は必須です");
				        objRENTEL1.focus();
				        return false;
				    }
				}

				if (   objTANNM.value.length   != 0 
				    || objRENTEL1.value.length != 0
				    || objRENTEL2.value.length != 0
                    || objRENTEL3.value.length != 0
				    || objFAXNO.value.length   != 0
				    || objBIKO.value.length != 0
				    || objSPOT_MAIL.value.length != 0
				    || objMAIL_PASS.value.length != 0
                    || objAUTO_FAXNM.value.length != 0
				    || objAUTO_MAIL.value.length    != 0
                    || objAUTO_MAIL_PASS.value.length    != 0
                    || objAUTO_FAXNO.value.length != 0
                    || objAUTO_KBN.value.length != 0
                    || objAUTO_ZERO_FLG.value.length != 0) {
				    

					//担当名漢字
					if (objTANNM.value.length==0) {
						showtab(0);
						alert("担当名漢字は必須入力です");
						objTANNM.focus();
						return false;
					}
					//電話番号１：必須チェック
					
					if (objRENTEL1.value.length==0) {
						showtab(0); 
						alert("電話番号１は必須です");
						objRENTEL1.focus();
						return false;
					}
					
					//電話番号１：電話番号チェック
					if (fncChkTel(objRENTEL1.value) == false) {
						showtab(0);
						alert("電話番号１は正しい電話番号ではありません");
						objRENTEL1.focus();
						return false;
					}
					//電話番号２：電話番号チェック
					if (fncChkTel(objRENTEL2.value) == false) {
						showtab(0);
						alert("電話番号２は正しい電話番号ではありません");
						objRENTEL2.focus();
						return false;
		            }
                    //電話番号３：電話番号チェック
		            if (fncChkTel(objRENTEL3.value) == false) {
		                showtab(0);
		                alert("電話番号３は正しい電話番号ではありません");
		                objRENTEL3.focus();
		                return false;
		            }
					//ＦＡＸ番号：電話番号チェック
					if (fncChkTel(objFAXNO.value) == false) {
						showtab(0);
						alert("ＦＡＸ番号は正しいＦＡＸ番号ではありません");
						objFAXNO.focus();
						return false;
		            }
		            //自動ＦＡＸ番号：電話番号チェック
		            if (fncChkTel(objAUTO_FAXNO.value) == false) {
		                showtab(1);
		                alert("ＦＡＸ番号は正しいＦＡＸ番号ではありません");
		                objAUTO_FAXNO.focus();
		                return false;
		            }

					bExist = true; // 値あり！
				} // if
				

			}// while

            //JA注意事項(レングスチェック)
            if (fnc_byteCheck(txtGUIDELINE.value) > 2000) {
                showtab(2);
                document.getElementById("guidelineClck1").checked = "true";
                document.getElementById("txtGUIDELINE").style.display = "block";
                document.getElementById("txtGUIDELINE2").style.display = "none";
                document.getElementById("txtGUIDELINE3").style.display = "none";
				alert("注意事項は 2000byte 以下で入力して下さい");
				txtGUIDELINE.focus();
				return false;
            }
            //2019/11/01 w.ganeko 2019監視改善 No 6 start
            //JA注意事項2(レングスチェック)
            if (fnc_byteCheck(txtGUIDELINE2.value) > 2000) {
                showtab(2);
                document.getElementById("guidelineClck2").checked = "true";
                document.getElementById("txtGUIDELINE").style.display = "none";
                document.getElementById("txtGUIDELINE2").style.display = "block";
                document.getElementById("txtGUIDELINE3").style.display = "none";
                alert("注意事項は 2000byte 以下で入力して下さい");
                txtGUIDELINE2.focus();
                return false;
            }
            //JA注意事項3(レングスチェック)
            if (fnc_byteCheck(txtGUIDELINE3.value) > 2000) {
                showtab(2);
                document.getElementById("guidelineClck3").checked = "true";
                document.getElementById("txtGUIDELINE").style.display = "none";
                document.getElementById("txtGUIDELINE2").style.display = "none";
                document.getElementById("txtGUIDELINE3").style.display = "block";
                alert("注意事項は 2000byte 以下で入力して下さい");
                txtGUIDELINE3.focus();
                return false;
            }
            //JA注意事項1ボタン名(レングスチェック)
            if (fnc_byteCheck(txtGUIDELINENM1.value) > 20) {
                showtab(2);
                alert("注意事項ボタン名は 20byte 以下で入力して下さい");
                txtGUIDELINENM1.focus();
                return false;
            }
            //JA注意事項2ボタン名(レングスチェック)
            if (fnc_byteCheck(txtGUIDELINENM2.value) > 20) {
                showtab(2);
                alert("注意事項ボタン名は 20byte 以下で入力して下さい");
                txtGUIDELINENM2.focus();
                return false;
            }
            //JA注意事項1ボタン名(レングスチェック)
            if (fnc_byteCheck(txtGUIDELINENM3.value) > 20) {
                showtab(2);
                alert("注意事項ボタン名は 20byte 以下で入力して下さい");
                txtGUIDELINENM3.focus();
                return false;
            }

            //2019/11/01 w.ganeko 2019監視改善 No 6 end
			if (bExist == false){ // データが1件も入力されていない？
			    //if (txtAYMD.value == ""){ // 新規？
			        showtab(0);
                    alert("データを入力して下さい。");
			        txtTANNM_1.focus();
					return false;
			    //}
			}
		} // if 登録時のみ

		//以下は　削除時のみ
		if (intKbn == 4) {
			
			if (txtAYMD.value.length == 0){ // 新規？
			    alert("削除対象データがありません。");
			    txtTANNM_1.focus();
				return false;
			}
			
			if ((hdnKURACD_MOTO.value.length == 0) && (hdnGROUPCD_MOTO.value.length == 0)){ // 新規？
			    alert("削除対象データがありません。");
			    txtTANNM_1.focus();
				return false;
			}
            
            if (hdnKURACD.value != hdnKURACD_MOTO.value
				|| hdnGROUPCD.value != hdnGROUPCD_MOTO.value) { // キーが変わっている？
                alert("キーが変更されています。再度検索して下さい。");
                btnSelect.focus();
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

    if ((strFlg == "2") && ((Form1.txtKURACD.value == " ") || (Form1.txtKURACD.value == ""))) {
		alert("クライアントコードを選択してください");
		Form1.btnKURACD.focus();
	} else {
		Form1.hdnPopcrtl.value = strFlg;
		if (strFlg == '3') {
		    fncPop('COPOPUPG00', "700");
		} else {
		    fncPop('COPOPUPG00');
		}
	}
}
//*********************************
//登録JA支所ボタン押下
//*********************************
function btnTOUROKUZUMI_onclick() {

    //グループコード必須チェック
    if ((Form1.txtGROUPCD.value == " ") || (Form1.txtGROUPCD.value == "")) {
        alert("グループコードを選択してください");
        Form1.btnGROUPCD.focus();
        return false;
    }

    fncPop('MSTAGJCG00');
}
//**************************************
//tipsボタン押下
//**************************************
function btnTips_onclick() {
	fncPop('MSTAGJPG00');
}
//*********************************
//ポップアップ用
//*********************************
var wP;

function fncPop(strId, strOptwidth) {
    if (typeof strOptwidth === 'undefined') strOptwidth = "400";
    var nowday = new Date();
    var name = "MSTAGJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();

	if (wP == null||wP.closed== true) {
	    wP = parent.fncPopupOpen(name, strOptwidth);
    } else {
        wP.close();
        wP = null;
        wP = parent.fncPopupOpen(name, strOptwidth);
    }
	wP.focus();
	Form1.hdnKensaku.value=strId;
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
		//新規ボタン使用不可
		//btnInsert.disabled=true;
		//取消ボタン使用不可
		btnClear.disabled=true;
		//終了ボタン使用不可
		btnExit.disabled=true;
		//クライアントコード検索ボタン使用不可
		btnKURACD.disabled=true;
		//JA支所コード検索ボタン使用不可
		btnACBCD.disabled = true;
		//グループコード検索ボタン使用不可
		btnGROUPCD.disabled = true;
	}
	fncFo(obj,5);
}
//**************************************
// ファイルアップロードボタン押下時の処理
//**************************************
function btnFileUpload_onclick() {
	with(Form1) {
	    if ((txtGROUPCD.value == " ") || (txtGROUPCD.value == "")) {
			alert("グループコードは必須です");
			btnGROUPCD.focus();
			return false;
		}
	}
	return true;
}

//**************************************
// プレビューボタン押下時の処理
//**************************************
function hpre(obj) {
    //2019/11/01 w.ganeko 2019監視改善 start
    with (Form1) {
        //チェックあり
        if (guidelineClck1.checked == true) {
            obj = txtGUIDELINE;
        } else if (guidelineClck2.checked == true) {
            obj = txtGUIDELINE2;
        } else if (guidelineClck3.checked == true) {
            obj = txtGUIDELINE3;
        }
    }
    //2019/11/01 w.ganeko 2019監視改善 end
    document.getElementById('pre').innerHTML = obj.value + "&nbsp;";
    //クライアントのみ/クライアント＋JA支所でプレビューの表示サイズを変える
    if (((Form1.txtGROUPCD.value == " ") || (Form1.txtGROUPCD.value == "")) && 
        ((Form1.txtGROUPNEW.value == " ") || (Form1.txtGROUPNEW.value == ""))){
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
// 入力バイト数を返却
//**************************************
function fnc_byteCheck(str) {

    if (str.length > 0) {
        var ss = str;
        var wk = "";
        var es = "";
        var cnt = 0;

        for (i = 0; i < ss.length; i++) {
            wk = ss.substring(i, i + 1);
            es = escape(wk);
            if (es.charAt(0) == "%") {
                if (es >= "%uFF61" && es <= "%uFF9F") {
                    /* 半角カナ */
                    cnt = cnt + 1;
                } else if (es.charAt(1) == "u") {
                    /* 全角 */
                    cnt = cnt + 2;
                } else if (es >= "%A7" && es <= "%F7") {
                    /* 全角記号（%uのつかない一部の文字§¨°±´¶×÷） */
                    cnt = cnt + 2;
                } else {
                    /* 半角記号 */
                    cnt = cnt + 1;
                }
            } else {
                /* 半角 */
                cnt = cnt + 1;
            }
        }
        //alert(cnt)
    }
    return cnt;
}
//**************************************
// タブ切替用変数
//**************************************
var tab = {
    init: function () {
        var tabs = this.setup.tabs;
        var pages = this.setup.pages;

        for (i = 0; i < pages.length; i++) {
            if (i !== 0) pages[i].style.display = 'none';
            tabs[i].onclick = function () { tab.showpage(this); return false; };
        }
    },

    showpage: function (obj) {
        var tabs = this.setup.tabs;
        var pages = this.setup.pages;
        var num;

        for (num = 0; num < tabs.length; num++) {
            if (tabs[num] === obj) break;
        }

        for (var i = 0; i < pages.length; i++) {
            if (i == num) {
                pages[num].style.display = 'block';
                tabs[num].className = 'present';
            }
            else {
                pages[i].style.display = 'none';
                tabs[i].className = null;
            }
        }
    }
}

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
// コピーボタン押下　ブラウザの仕様変更により、使えなくなる可能性あり（林センター長了承済み）
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
            str += "," + document.getElementById("txtFAXNO_" + i).value;          //2019/11/01 w.ganeko 2019監視改善 No 6
            str += "," + document.getElementById("txtBIKO_" + i).value;           //2019/11/01 w.ganeko 2019監視改善 No 6
            str += "," + document.getElementById("txtSPOT_MAIL_" + i).value;      //2019/11/01 w.ganeko 2019監視改善 No 6
            str += "," + document.getElementById("txtMAIL_PASS_" + i).value;      //2019/11/01 w.ganeko 2019監視改善 No 6
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
// ペーストボタン押下　ブラウザの仕様変更により、使えなくなる可能性あり（林センター長了承済み）
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
                (document.getElementById("txtRENTEL3_" + i).value != "") ||
                (document.getElementById("txtFAXNO_" + i).value != "") ||      //2019/11/01 w.ganeko 2019監視改善 No 6
                (document.getElementById("txtBIKO_" + i).value != "") ||       //2019/11/01 w.ganeko 2019監視改善 No 6
                (document.getElementById("txtSPOT_MAIL_" + i).value != "") ||  //2019/11/01 w.ganeko 2019監視改善 No 6
                (document.getElementById("txtMAIL_PASS_" + i).value != "")     //2019/11/01 w.ganeko 2019監視改善 No 6
            ) {

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
                if (typeof col[4] != "undefined") { document.getElementById("txtFAXNO_" + i).value = col[4]; }      //2019/11/01 w.ganeko 2019監視改善 No 6
                if (typeof col[5] != "undefined") { document.getElementById("txtBIKO_" + i).value = col[5]; }       //2019/11/01 w.ganeko 2019監視改善 No 6
                if (typeof col[6] != "undefined") { document.getElementById("txtSPOT_MAIL_" + i).value = col[6]; }  //2019/11/01 w.ganeko 2019監視改善 No 6
                if (typeof col[7] != "undefined") { document.getElementById("txtMAIL_PASS_" + i).value = col[7]; }  //2019/11/01 w.ganeko 2019監視改善 No 6
                j++;
            }
        }
    }
}

//**************************************
// クリアボタン押下　ブラウザの仕様変更により、使えなくなる可能性あり（林センター長了承済み）
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
            document.getElementById("txtFAXNO_" + i).value = "";       //2019/11/01 w.ganeko 2019監視改善 No 6
            document.getElementById("txtBIKO_" + i).value = "";        //2019/11/01 w.ganeko 2019監視改善 No 6
            document.getElementById("txtSPOT_MAIL_" + i).value = "";   //2019/11/01 w.ganeko 2019監視改善 No 6
            document.getElementById("txtMAIL_PASS_" + i).value = "";   //2019/11/01 w.ganeko 2019監視改善 No 6
        }
    }
    
    //ｺﾋﾟﾍﾟチェック有無のチェック
    if (chk == "0") {
        alert("チェックを付けてください。");
        Form1.btnICHIRAN_CLEAR.focus();
        return;
    }

}
//2019/11/01 W.GANEKO 2019監視改善 No6
//**************************************
// コピーボタン押下　ブラウザの仕様変更により、使えなくなる可能性あり（林センター長了承済み）
//**************************************
function fncAtIchiran_Copy() {

    var i;
    var str = "";
    var cnt = 0;
    var chk = "0"; //チェック有無のチェックに使用

    //コピー
    for (i = 1; i <= 30; i++) { // 1～30
        objCopy = document.getElementById("chkAtCopy_" + i);
        if (objCopy.checked) {
            chk = "1";
            if (cnt == 0) {
                cnt = 1;
            } else {
                str += "\n" //2行目以降は改行を付けてから値を格納
            }
            str += document.getElementById("txtAUTO_FAXNM_" + i).value;
            str += "," + document.getElementById("txtAUTO_MAIL_" + i).value;
            str += "," + document.getElementById("txtAUTO_MAIL_PASS_" + i).value;
            str += "," + document.getElementById("txtAUTO_FAXNO_" + i).value;
        }
    }

    //ｺﾋﾟﾍﾟチェック有無のチェック
    if (chk == "0") {
        //ｺﾋﾟﾍﾟチェック無し
        alert("チェックを付けてください。");
        Form1.btnATICHIRAN_COPY.focus();
        return;
    } else {
        window.clipboardData.setData("text", str)
        alert("コピー元のチェックを外し、コピー先をチェックしてください。");
    }
}

//**************************************
// ペーストボタン押下　ブラウザの仕様変更により、使えなくなる可能性あり（林センター長了承済み）
//**************************************
function fncAtIchiran_Paste() {

    var str = window.clipboardData.getData("text"); //クリップボードの値取得
    var row;
    var col;
    var i;
    var j = 0;
    var chk = "0"; //チェック有無のチェックに使用

    //上書きチェック
    for (i = 1; i <= 30; i++) { // 1～30
        objCopy = document.getElementById("chkAtCopy_" + i);
        if (objCopy.checked) {
            chk = "1";
            if ((document.getElementById("txtAUTO_FAXNM_" + i).value != "") ||
                (document.getElementById("txtAUTO_MAIL_" + i).value != "") ||
                (document.getElementById("txtAUTO_MAIL_PASS_" + i).value != "") ||
                (document.getElementById("txtAUTO_FAXNO_" + i).value != "")
            ) {

                var res = confirm("上書きしてよろしいですか？");
                if (res == false) {
                    Form1.btnATICHIRAN_PASTE.focus();
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
        Form1.btnATICHIRAN_PASTE.focus();
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
        objCopy = document.getElementById("chkAtCopy_" + i);
        if (objCopy.checked) { //チェックがある行に貼り付け
            if (row.length > 0 && j < row.length) {
                col = row[j].split(",") //カンマ区切りでcolに格納
                if (typeof col[0] != "undefined") { document.getElementById("txtAUTO_FAXNM_" + i).value = col[0]; }
                if (typeof col[1] != "undefined") { document.getElementById("txtAUTO_MAIL_" + i).value = col[1]; }
                if (typeof col[2] != "undefined") { document.getElementById("txtAUTO_MAIL_PASS_" + i).value = col[2]; }
                if (typeof col[3] != "undefined") { document.getElementById("txtAUTO_FAXNO_" + i).value = col[3]; }
                j++;
            }
        }
    }
}

//**************************************
// クリアボタン押下　ブラウザの仕様変更により、使えなくなる可能性あり（林センター長了承済み）
//**************************************
function fncAtIchiran_Clear() {

    var chk = "0"; //チェック有無のチェックに使用

    //クリア
    for (i = 1; i <= 30; i++) { // 1～30
        objCopy = document.getElementById("chkAtCopy_" + i);
        if (objCopy.checked) { //チェックがある行クリア
            chk = "1"
            document.getElementById("txtAUTO_FAXNM_" + i).value = "";
            document.getElementById("txtAUTO_MAIL_" + i).value = "";
            document.getElementById("txtAUTO_MAIL_PASS_" + i).value = "";
            document.getElementById("txtAUTO_FAXNO_" + i).value = "";
        }
    }

    //ｺﾋﾟﾍﾟチェック有無のチェック
    if (chk == "0") {
        alert("チェックを付けてください。");
        Form1.btnICHIRAN_CLEAR.focus();
        return;
    }

}
//==================================================
//用途：入力不可能文字をチェックする(当画面専用)
//引数：
//戻値：
//==================================================
function fncChkChar_MSTAG() {
    //Form内のオブジェクト数分のループ
    for (i = 0; i < Form1.elements.length; i++) {
        //テキストボックスか、テキストエリアであれば
        if (Form1.elements[i].type == 'text' || Form1.elements[i].type == 'textarea') {
            if (Form1.elements[i].id == 'txtRYURYO') { return true; }
            if (Form1.elements[i].id == 'txtGUIDELINE') { return true; }
            if (Form1.elements[i].id == 'txtGUIDELINE2') { return true; }  //2019/11/01 w.ganeko 2019監視改善
            if (Form1.elements[i].id == 'txtGUIDELINE3') { return true; }  //2019/11/01 w.ganeko 2019監視改善
            //入力禁止文字チェック
            if (Form1.elements[i].value.match(/&/m) || Form1.elements[i].value.match(/\?/m) || Form1.elements[i].value.match(/'/m) || Form1.elements[i].value.match(/"/m) || Form1.elements[i].value.match(/</m) || Form1.elements[i].value.match(/>/m)) {
                var str = "「'」";
                alert(str + '、「&」、「"」、「?」、「<」、「>」の文字は使用できません');

                if (/txtAUTO_/.test(Form1.elements[i].id)) {
                    document.getElementById("tab2").click();
                } else {
                    document.getElementById("tab1").click();
                }
                Form1.elements[i].focus();
                Form1.elements[i].select();
                return false;
            }
        }
    }
}
//2019/11/01 W.GANEKO add 2019改善開発 No4-8
//**************************************
//データ修正チェックボックス
//**************************************
function chkGuidelineRadio_onclick() {
    with (Form1) {
        //チェックあり
        if (guidelineClck1.checked == true) {
            document.getElementById("txtGUIDELINE").style.display = "block";
            document.getElementById("txtGUIDELINE2").style.display = "none";
            document.getElementById("txtGUIDELINE3").style.display = "none";
        } else if (guidelineClck2.checked == true) {
            document.getElementById("txtGUIDELINE").style.display = "none";
            document.getElementById("txtGUIDELINE2").style.display = "block";
            document.getElementById("txtGUIDELINE3").style.display = "none";
        } else if (guidelineClck3.checked == true) {
            document.getElementById("txtGUIDELINE").style.display = "none";
            document.getElementById("txtGUIDELINE2").style.display = "none";
            document.getElementById("txtGUIDELINE3").style.display = "block";
        }
    }
}
//2019/07/29 W.GANEKO add 2019改善開発 No4-8
