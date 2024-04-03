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
		//画面の初期設定（区分に合わせた出力エリアの表示内容制御)
		//moriif (rdoKBN1.checked==true) {
		//    fncTanto(rdoKBN1, 1);
		//} else if (rdoKBN2.checked==true){
		//	fncTanto(rdoKBN2, 1);
		//} else {
		//	fncTanto(rdoKBN3, 1);	
	    //}
	    //add mori
	    if (hdnTANKBN.Value == '1') {
	        fncTanto(hdnTANKBN, 1);
	    } else if (hdnTANKBN.Value == '2') {
	        fncTanto(hdnTANKBN, 1);
	    } else {
	        fncTanto(hdnTANKBN, 1);	
	    }
	}
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	with(Form1) {
		if (rdoKBN1.checked==true) {
			hdnTANKBN.value = "1";		
		} else if (rdoKBN2.checked==true) {
			hdnTANKBN.value = "2";
		} else {
			hdnTANKBN.value = "3";
		}
		//__doPostBack(strCtl,strFlg); 
		
		// add
		hdnKensaku.value = "MSTAFJAG00";
		hdnKEY_KBN.value    = hdnTANKBN.value;
		hdnKEY_KURACD.value = hdnKURACD.value;
		hdnKEY_CODE.value = hdnCODE.value;
		//2016/02/19 H.Mori add 2015改善開発 №9
		hdnKEY_GROUPCD.value = hdnGROUPCD.value;
		hdnKEY_JACD.value = txtJACD.value;
        //2015/11/02 w.ganeko add 2015改善開発 №9
		hdnKEY_TANTOTEL.value = txtTantoTel.value;
		
		target = "_self";
		submit();
		target = "";
		
		hdnKensaku.value = "";
		hdnKEY_KBN.value    = "";
		hdnKEY_KURACD.value = "";
		hdnKEY_CODE.value   = "";
		//2016/02/19 H.Mori add 2015改善開発 №9
		hdnKEY_GROUPCD.value = "";
        hdnKEY_JACD.value   = "";
		hdnTANKBN.value     = "";
		//2015/11/02 w.ganeko add 2015改善開発 №9
		hdnKEY_TANTOTEL.value = "";
     }
}
//**************************************
//検索ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
    //入力値チェック
    if (fncDataCheck(1) == false) {
        return false;
    }//2016/02/08 H.Mori add 2015改善 No.9

	//入力値チェック-----------
	//if(fncDataCheck(1)==false){
	//	return false;
	//}
	fncBtnRoc(Form1.btnSelect);
	doPostBack('btnSelect',''); 
}
//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
	//var strRes;
	//strRes = confirm("終了してよろしいですか？");
	//if (strRes==false){
	//	return;
	//}
	var strURL;
//2015/11/01 w.ganeko mod 2015改善開発 №9 start
//	if(Form1.hdnBackUrl.value=="EIGYOU") {
//		strURL="../../../COGMENUG00.aspx";
//	2014/02/20 T.Ono del 監視改善2013 営業所以外はマスタ一覧メニューへ
//    //--- ↓2005/04/28 ADD Falcon↓ ---
//	} else if (Form1.hdnBackUrl.value=="KANSHI") {
//		strURL="../../../COGMENUG00.aspx";		 
//	//--- ↑2005/04/28 ADD Falcon↑ ---
//	} else {
//		strURL="../../../COGMNMLG00.aspx";	
//	}
//    parent.frames("data").location = strURL;
    var oener = opener;
    if (oener != undefined) {
        strRes = confirm("終了してよろしいですか？");
        if (strRes == false) {
            return;
        }
        window.close();
    } else {
        if (Form1.hdnBackUrl.value == "EIGYOU") {
            strURL = "../../../COGMENUG00.aspx";
        } else {
            strURL = "../../../COGMNMLG00.aspx";
        }
        parent.frames("data").location = strURL;
    }
//2015/11/01 w.ganeko mod 2015改善開発 №9 end
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	//---------------------------------
	//intKbn  1:検索　2:新規　3:登録/修正
	//---------------------------------
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
	    //2016/02/08 H.Mori del 2015改善 No.9 START
        //if (rdoKBN1.checked == true) {
		//    //if (hdnKURACD.value.length==0) {                            //2012/05/11 NEC ou Del
		//    if ((txtKURACD.value == "") || (txtKURACD.value == " ")) {    //2012/05/11 NEC ou Add
		//		alert("ＪＡ支所担当者の場合、クライアントコードは必須です");
		//		btnKURACD.focus();
		//		return false;
		//	}
		//}
		//if (rdoKBN1.checked == false) {
		//	//コード：必須
		//    //if (hdnCODE.value.length==0) {                            //2012/05/11 NEC ou Del
		//    if ((txtCODE.value = "") || (txtCODE.value = " ")) {        //2012/05/11 NEC ou Add
		//		alert("コードは必須入力です");
		//		btnCODECD.focus();
		//		return false;
		//	}
		//}
        //2016/02/08 H.Mori del 2015改善 No.9 END
        if (fncChkTel(txtTantoTel.value) == false) {  //2016/02/08 H.Mori add 2015改善 No.9
		    alert("連絡先は正しい電話番号ではありません");
		    txtTantoTel.focus();
		    return false;
		}
    }
	return true;
}
//**************************************
//担当者区分が変更された時
//**************************************
function fncTanto(obj,ind) {
	if (ind == "0"){
		fncClearTanto()
	}
	if (obj.value=="1") {
		//ＪＡ支所担当者
	    //if(ind == "0"){  //2016/2/09 H.Mori del コメント化
			Form1.btnKURACD.disabled = false;
			Form1.txtJACD.disabled = false;
			Form1.txtJACD.className = "c-f";
			Form1.txtTantoTel.disabled = false;
			Form1.txtTantoTel.className = "c-f";
			Form1.btnGROUPCD.disabled = false; //2016/2/12 H.Mori add
        //}
		sp1.style.visibility="visible";
		sp2.style.visibility = "visible"; //2016/2/03 H.Mori add
		sp3.style.visibility = "visible"; //2016/2/08 H.Mori add
		sp4.style.visibility = "visible"; //2016/2/08 H.Mori add
		sp5.style.visibility = "visible"; //2016/2/12 H.Mori add
        lblCODE.innerText="ＪＡ支所コード";	
	} else if (obj.value=="2") {
		//監視センター担当者
		//if(ind == "0"){  //2016/2/09 H.Mori del コメント化
			Form1.btnKURACD.disabled = true;
			Form1.txtJACD.disabled = true;
			Form1.txtJACD.className = "c-rNM";
			Form1.txtTantoTel.disabled = true;
			Form1.txtTantoTel.className = "c-rNM";
			Form1.btnGROUPCD.disabled = true; //2016/2/12 H.Mori add
        //}
		sp1.style.visibility="hidden";
		sp2.style.visibility = "hidden"; //2016/2/03 H.Mori add
		sp3.style.visibility = "hidden"; //2016/2/08 H.Mori add
		sp4.style.visibility = "hidden"; //2016/2/08 H.Mori add
		sp5.style.visibility = "hidden"; //2016/2/12 H.Mori add
        lblCODE.innerText="監視センターコード";
	} else if (obj.value=="3") {
		//出動会社担当者
        //if(ind == "0"){ //2016/2/09 H.Mori del コメント化
			Form1.btnKURACD.disabled = true;
			Form1.txtJACD.disabled = true;
			Form1.txtJACD.className = "c-rNM";
			Form1.txtTantoTel.disabled = true;
			Form1.txtTantoTel.className = "c-rNM";
			Form1.btnGROUPCD.disabled = true; //2016/2/12 H.Mori add
        //}
		sp1.style.visibility="hidden";
		sp2.style.visibility = "hidden"; //2016/2/03 H.Mori add
		sp3.style.visibility = "hidden"; //2016/2/08 H.Mori add
		sp4.style.visibility = "hidden"; //2016/2/08 H.Mori add
		sp5.style.visibility = "hidden"; //2016/2/12 H.Mori add
        lblCODE.innerText="出動会社コード";
	}
}
//**************************************
//担当者区分が変更時の値クリア
//**************************************
function fncClearTanto() {
	with(Form1) {
		txtKURACD.value='';
		hdnKURACD.value='';		
		hdnCODE.value='';
		txtCODE.value = '';
		txtGROUPCD.value = '';
		hdnGROUPCD.value = '';
		txtJACD.value='';
		txtTantoTel.value = '';
    }
}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {
    //if (Form1.rdoKBN1.checked == true && strFlg == "2" && Form1.hdnKURACD.value.length == 0) {
    if (Form1.rdoKBN1.checked == true && strFlg == "2" &&
        ((Form1.txtKURACD.value == "") || (Form1.txtKURACD.value == " "))) {  //2012/05/11 NEC ou Add   
        alert("クライアントコードを選択してください");
        Form1.btnKURACD.focus();
    } else {
        with (Form1) {
            if (rdoKBN1.checked == true) {
                hdnTANKBN.value = "1";
            } else if (rdoKBN2.checked == true) {
                hdnTANKBN.value = "2";
            } else {
                hdnTANKBN.value = "3";
            }
        }
        Form1.hdnPopcrtl.value = strFlg;
        //fncPop('COPOPUPG00');
        if (strFlg == "3") {    //2016/02/16 H.Mori mod 2015改善開発 №9
            fncPop('COPOPUPG00', "700");
        } else {
            fncPop('COPOPUPG00');
        }
    }
}
//*********************************
//ポップアップ用
//*********************************
var wP;
//function fncPop(strId){
function fncPop(strId, strOptwidth) {
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "MSTASJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
    //2015/11/02 w.ganeko add 2015改善開発 No9
    var oener = opener;
    //2014/10/15 H.Hosoda add 2014改善開発 No20 END
	if (wP == null||wP.closed== true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
	    //2015/11/02 w.ganeko mod 2015改善開発 №9 start
	    //wP = parent.fncPopupOpen(name);
	    if (oener == undefined) {
	        //2016/02/12 H.Mori mod 2015改善開発 №9
	        //wP = parent.fncPopupOpen(name);
	        wP = parent.fncPopupOpen(name,strOptwidth);
	    } else {
	        //2016/02/12 H.Mori mod 2015改善開発 №9
	        //wP = fncPopupOpenNest(name);
	        wP = fncPopupOpenNest(name,strOptwidth);
	    }
	    //2015/11/02 w.ganeko mod 2015改善開発 №9 end
	} else {
        wP.close();
        wP = null;
        //2015/11/02 w.ganeko mod 2015改善開発 №9 start
        //wP = parent.fncPopupOpen(name);
        if (oener == undefined) {
            //2016/02/12 H.Mori mod 2015改善開発 №9
            //wP = parent.fncPopupOpen(name);
            wP = parent.fncPopupOpen(name, strOptwidth);
        } else {
            //2016/02/12 H.Mori mod 2015改善開発 №9
            //wP = fncPopupOpenNest(name);
            wP = fncPopupOpenNest(name, strOptwidth);
        }
        //2015/11/02 w.ganeko mod 2015改善開発 №9 end
    }
	wP.focus();
	Form1.hdnKensaku.value=strId;
	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
	Form1.target = name;
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""
}
//2015/11/02 w.ganeko 2015改善開発 №9 start
//**************************************
//親を当画面にしてポップ画面を開く
//**************************************
var wPNest
function fncPopupOpenNest(name, strOptwidth, strOptheight) {
    if (typeof strOptwidth === 'undefined') strOptwidth = "400";
    if (typeof strOptheight === 'undefined') strOptheight = "385";
    wPNest = window.open("", name, "toolbar=no,location=no,menubar=no,top=0,left=200,width=" + strOptwidth + ",height=" + strOptheight + ",scrollbars=yes");
    window.focus();
    return wPNest;
}
//2015/11/02 w.ganeko 2015改善開発 №9 end
//**************************************
//イベントボタンに対してロックをかける
//**************************************
function fncBtnRoc(obj) {
	with(Form1){
		//検索ボタン使用不可
		btnSelect.disabled = true;
		//終了ボタン使用不可
		btnExit.disabled = true;
		//クライアントコード検索ボタン使用不可
		btnKURACD.disabled = true;
		//コード検索ボタン使用不可
		btnCODECD.disabled = true;

		txtJACD.disabled = true;
        //2015/11/02 w.ganeko 2015改善開発 №9
		txtTantoTel.disabled = true;
		//2016/02/12 H.Mori add 2015改善開発 №9
		btnGROUPCD.disabled = true;
    }
	fncFo(obj,5);
}
