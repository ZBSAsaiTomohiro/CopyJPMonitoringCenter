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
	fncListOut('MSKOSJFG00');	
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
}
//**************************************
//一覧表示
//**************************************
function fncListOut(strId){
  Form1.hdnKensaku.value=strId;
  Form1.target="ifList";
  Form1.submit();
  Form1.hdnKensaku.value="";
  Form1.target=""       
}
//**************************************
//検索ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
	//入力値チェック-----------
	if(fncDataCheck(1)==false){
		return false;
	}
    //オブジェクトに対するロック処理
	fncFo(Form1.btnSelect,5);
	Form1.btnSelect.disabled=true;
	Form1.btnExcel.disabled = true;     //2017/02/06 W.Ganeko 2016改善開発
	Form1.btnExit.disabled = true;
	Form1.btnHAN_CD.disabled = true;
	Form1.btnHAN_CD_TO.disabled = true; //2016/11/24 H.Mori add 2016改善開発 No2-2
	Form1.btnJA_CD.disabled = true;     //2013/12/09 T.Ono add 監視改善2013
	Form1.btnHANGRP.disabled = true;   //2014/12/03 H.Hosoda add 2014改善開発 No6
    Form1.btnCLI_CD.disabled = true;
    Form1.btnCLI_CD_TO.disabled = true; //2019/11/01 T.Ono del 監視改善2019 No1
	Form1.btnTAIO.disabled = true;
	//Form1.btnKINRENGRP.disabled = true;   //2016/11/17 H.Mori add 2016改善開発 No2-1 2019/11/01 T.Ono del 監視改善2019 No1
	Form1.hdnScrollTop.value = "0";     //2013/12/10 T.Ono add 監視改善2013
	Form1.hdnSelectClick.value = "1";
	fncListOut('MSKOSJFG00');
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
	strURL="../../../COGMENUG00.aspx";	

	parent.frames("data").location=strURL;		
}
//*************************************
//対応入力ボタン押下時の処理
//*************************************
function btnTAIO_onclick() {
	with(Form1){
		hdnKensaku.value="KETAIJAG00";
		hdnTaiouClick.value="1"
		submit();
		hdnKensaku.value="";
		hdnTaiouClick.value = "";
	}	
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	//intKbn : 1 検索
	//intKbn : 2 登録
	//intKbn : 3 修正
	//-------------------------------------
	//<TODO> 入力値チェック
	with(Form1) {
		//需要家電話番号：電話番号チェック
		if (fncChkTel(txtTEL.value) == false) {
			//2014/12/03 H.Hosoda mod 2014改善開発 No6 
		    //alert("需要家電話番号は正しい電話番号ではありません");
		    //2016/11/16 H.Mori del 2016改善開発 No2-3
			//alert("連絡先は正しい電話番号ではありません");
		    alert("連絡先／結線番号は正しい電話番号ではありません");
			txtTEL.focus();
			return false;
		}

        //2019/11/01 T.Ono del 監視改善2019 No1
        if ((hdnCLI_CD.value != "" && hdnCLI_CD.value != " ")
            || (hdnCLI_CD_TO.value != "" && hdnCLI_CD_TO.value != " ")) {
            if (hdnCLI_CD.value == "" || hdnCLI_CD.value == " ") {
                alert("クライアント名Toのみの指定はできません");
                btnCLI_CD.focus();
                return false;
            }
            if (hdnCLI_CD_TO.value == "" || hdnCLI_CD_TO.value == " ") {
                alert("クライアント名Fromのみの指定はできません");
                btnCLI_CD_TO.focus();
                return false;
            }
        }

        //2019/11/01 T.Ono add 監視改善2019 クライアントFROM > クライアントTOの場合
        if ((hdnCLI_CD.value != "" && hdnCLI_CD.value != " ") && (hdnCLI_CD_TO.value != "" && hdnCLI_CD_TO.value != " ") && (hdnCLI_CD.value > hdnCLI_CD_TO.value)) {
            alert("クライアント名(FROM)とクライアント名(TO)の範囲指定が間違っています。");
            btnCLI_CD.focus();
            return false;
        }

        //2016/11/24 H.Mori add 2016改善開発 No2-2 片方のみ検索の場合
        if ((hdnHAN_CD.value != "" && hdnHAN_CD.value != " ")
                                || (hdnHAN_CD_TO.value != "" && hdnHAN_CD_TO.value != " ")) {
            if (hdnHAN_CD.value == "" || hdnHAN_CD.value == " ") {
                alert("JA支所Toのみの指定はできません");
                btnHAN_CD.focus();
                return false;
            }
            if (hdnHAN_CD_TO.value == "" || hdnHAN_CD_TO.value == " ") {
                alert("JA支所Fromのみの指定はできません");
                btnHAN_CD_TO.focus();
                return false;
            }
        }

        //2016/11/24 H.Mori add 2016改善開発 No2-2 JA支所名FROM > JA支所名TOの場合
        //2019/11/01 T.Ono del 監視改善2019 クライアントが違う場合を考慮し、チェックを行わない
        //if ((hdnHAN_CD.value != "" && hdnHAN_CD.value != " ") && (hdnHAN_CD_TO.value != "" && hdnHAN_CD_TO.value != " ") && (hdnHAN_CD.value > hdnHAN_CD_TO.value)) {
        //    alert("ＪＡ支所(FROM)とＪＡ支所(TO)の範囲指定が間違っています。");
        //    btnHAN_CD.focus();
        //    return false;
        //}

            //2016/11/16 H.Mori del 2016改善開発 No2-3 START
            //2014/12/03 H.Hosoda add 2014改善開発 No6 START
		    //結線番号：電話番号チェック
		    //if (fncChkTel(txtNCUTEL.value) == false) {
		    //	alert("結線番号は正しい電話番号ではありません");
		    //	txtNCUTEL.focus();
		    //	return false;
		    //}
		    //2014/12/03 H.Hosoda add 2014改善開発 No6 END
            //2016/11/16 H.Mori del 2016改善開発 No2-3 END
            //需要家名カナ：半角カナ
		    //--- ↓2005/05/19 DEL Falcon↓ ---
		    //if (fncZenkakuChk(txtKANA.value) == true) {
		    //	alert("需要家名カナは半角カナで入力して下さい");
		    //	txtKANA.focus();
		    //	return false;
		    //}
		    //--- ↑2005/05/19 DEL Falcon↑ ---
    }
    return true;
}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {
    //2014/01/21 T.Ono mod 監視改善2013
    //JA名、JA支所名ともにクライアント必須
    //JA支所名はJA名を必須としない
    //if (strFlg=="2") { 
    //2014/12/04 H.Hosoda mod 監視改善2014 No.6 販売事業所グループ追加対応
    //JA名、販売事業者名、JA支所名ともにクライアント必須
    //if ((strFlg=="2") || (strFlg=="3")) {
    //2016/11/24 H.Mori mod 2016改善開発 No2-1,2-2 緊急連絡先Gr,JA支所TO 追加対応
    //緊急連絡先Gr                      クライアント必須
    //if ((strFlg=="2") || (strFlg=="3") || (strFlg=="4"))
    //2019/11/01 T.Ono del 監視改善2019 No1
    //if ((strFlg == "2") || (strFlg == "3") || (strFlg == "4") || (strFlg == "5") || (strFlg == "6")) {
    if ((strFlg == "2") || (strFlg == "3") || (strFlg == "4") || (strFlg == "6")) {
		//JAポップアップ出力時
		//if(Form1.txtCLI_CD.value.length==0) { 2014/01/16 T.Ono mod 監視改善2013
        if ((Form1.txtCLI_CD.value == "") || (Form1.txtCLI_CD.value == " ")) { 
			alert("クライアント名を選択して下さい");
			Form1.btnCLI_CD.focus();
			return false;
		}

        //2019/11/01 T.Ono mod 監視改善2019 No1 
        if ((Form1.txtCLI_CD_TO.value == "") || (Form1.txtCLI_CD_TO.value == " ")) {
            alert("クライアント名を選択して下さい");
            Form1.btnCLI_CD_TO.focus();
            return false;
        }
//    }else if (strFlg=="3") {
//        //2013/12/09 T.Ono add 監視改善2013
//        //JA支所ポップアップ出力時
//        //if(Form1.txtJA_CD.value.length==0) { 2014/01/16 T.Ono mod 監視改善2013
//        if ((Form1.txtJA_CD.value == "") || (Form1.txtJA_CD.value == " ")) { 
//			alert("ＪＡ名を選択して下さい");
//			Form1.btnJA_CD.focus();
//			return false;
//		}
//    }else{
	}
	
	//2014/12/04 H.Hosoda add 2014改善開発 No6 START
    // ＪＡ名
    if (strFlg == '2') {
        // 販売事業者が既に選択されている場合は、選択不可
        if ((Form1.txtHANGRP.value != "") && (Form1.txtHANGRP.value != " ")) {
            alert("ＪＡ名と販売事業者は両方を選択することはできません");
            return false;
        }
        //2019/11/01 T.Ono del 監視改善2019 No1
        ////2016/11/17 H.Mori add 2016改善開発 No2-1
        //// 緊急連絡先Grが既に選択されている場合は、選択不可
        //if ((Form1.txtKINRENGRP.value != "") && (Form1.txtKINRENGRP.value != " ")) {
        //    alert("ＪＡ名と緊急連絡先Grは両方を選択することはできません");
        //    return false;
        //}
    }
    // 販売事業者
    if (strFlg == '3') {
        // ＪＡ名が既に選択されている場合は、選択不可
        if ((Form1.txtJA_CD.value != "") && (Form1.txtJA_CD.value != " ")) {
            alert("ＪＡ名と販売事業者は両方を選択することはできません");
            return false;
        }
        //2019/11/01 T.Ono del 監視改善2019 No1
        ////2016/11/17 H.Mori add 2016改善開発 No2-1
        //// 緊急連絡先Grが既に選択されている場合は、選択不可
        //if ((Form1.txtKINRENGRP.value != "") && (Form1.txtKINRENGRP.value != " ")) {
        //    alert("販売事業者と緊急連絡先Grは両方を選択することはできません");
        //    return false;
        //}
    }
    //2014/12/04 H.Hosoda add 2014改善開発 No6 END

    //2019/11/01 T.Ono del 監視改善2019 No1
    ////2016/11/17 H.Mori add 2016改善開発 No2-1 START
    //// 緊急連絡先Gr
    //if (strFlg == '5') {
    //    // ＪＡ名が既に選択されている場合は、選択不可
    //    if ((Form1.txtJA_CD.value != "") && (Form1.txtJA_CD.value != " ")) {
    //        alert("ＪＡ名と緊急連絡先Grは両方を選択することはできません");
    //        return false;
    //    }   
    //    // 販売事業者が既に選択されている場合は、選択不可
    //    if ((Form1.txtHANGRP.value != "") && (Form1.txtHANGRP.value != " ")) {
    //        alert("販売事業者と緊急連絡先Grは両方を選択することはできません");
    //        return false;
    //    }
    //}
    ////2016/11/17 H.Mori add 2016改善開発 No2-1 END

	Form1.hdnPopcrtl.value = strFlg;

    //2019/11/01 T.Ono mod 監視改善2019 No1 strFlg=7(ｸﾗｲｱﾝﾄTo)追加
    //2016/11/17 H.Mori add 2016改善開発 No2-1 緊急連絡先Gr
	//2014/12/04 H.Hosoda mod 2014改善開発 No6 START
	//fncPop('COPOPUPG00');
    if (strFlg == '1') {
        fncPop("COPOPUPG00");
    } else if (strFlg == '2') {
        fncPop("COPOPUPG00");
    } else if (strFlg == '3') {
        fncPop("COPOPUPG00", "600");
    } else if (strFlg == '5') {
        fncPop("COPOPUPG00", "700");
    } else if (strFlg == '7') {
        fncPop("COPOPUPG00");
	}  else {
	    fncPop("COPOPUPG00");
	}
	//2014/12/04 H.Hosoda mod 2014改善開発 No6 END
}
//*********************************
//ポップアップ用
//*********************************
var wP;
//2014/12/04 H.Hosoda mod 2014改善開発 No6 START
//function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
//    var nowday = new Date();
//    var name = "MSKOSJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
	//2014/10/15 H.Hosoda add 2014改善開発 No20 END
//	if (wP == null||wP.closed== true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
//        wP = parent.fncPopupOpen(name);
//    } else {
//        wP.close();
//        wP = null;
//        wP = parent.fncPopupOpen(name);
//    }
//	wP.focus();
//	Form1.hdnKensaku.value=strId;
	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
//	Form1.target = name;
//	Form1.submit();
//	Form1.hdnKensaku.value="";
//	Form1.target=""
//}
function fncPop(strId,strOptwidth){
	if(typeof strOptwidth === 'undefined') strOptwidth = "400";
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "MSKOSJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
	//2014/10/15 H.Hosoda add 2014改善開発 No20 END
	if (wP == null||wP.closed== true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
        wP = parent.fncPopupOpen(name,strOptwidth);
    } else {
        wP.close();
        wP = null;
        wP = parent.fncPopupOpen(name,strOptwidth);
    }
	wP.focus();
	Form1.hdnKensaku.value=strId;
	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
	Form1.target = name;
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""
}
//2014/12/04 H.Hosoda mod 2014改善開発 No6 END
//*********************************
//監視センターコンボが変更された時
//*********************************
function fncKansiChange() {
	with(Form1) {
		hdnCLI_CD.value="";
		txtCLI_CD.value = "";
        hdnCLI_CD_TO.value = ""; //2019/11/01 T.Ono del 監視改善2019 No1   
        txtCLI_CD_TO.value = ""; //2019/11/01 T.Ono del 監視改善2019 No1
		hdnJA_CD.value = "";    //2013/12/09 T.Ono add 監視改善2013
        txtJA_CD.value = "";    //2013/12/09 T.Ono add 監視改善2013
        hdnJA_CD_CLI.value = "";    //2019/11/01 T.Ono add 監視改善2019
		hdnHAN_CD.value="";
		txtHAN_CD.value = "";
		hdnHAN_CD_TO.value = "";  //2016/11/24 H.Mori add 監視改善2016      
		txtHAN_CD_TO.value = "";  //2016/11/24 H.Mori add 監視改善2016
		hdnHANGRP.value = "";     //2016/11/22 H.Mori add 監視改善2016
		txtHANGRP.value = "";     //2016/11/22 H.Mori add 監視改善2016
		//hdnKINRENGRP.value = "";  //2016/11/22 H.Mori add 監視改善2016 2019/11/01 T.Ono del 監視改善2019 No1
		//txtKINRENGRP.value = "";  //2016/11/22 H.Mori add 監視改善2016 2019/11/01 T.Ono del 監視改善2019 No1
	}
}
//2013/12/05 T.Ono add 監視改善2013
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtCLI_CD.focus()
}
//2017/02/06 W.GANEKO add 監視改善2016
//**************************************
//出力ボタン押下時の処理
//**************************************
function btnExcel_onclick() {
    Form1.hdnSelectClick.value = "";

    //入力値チェック
    if (fncDataCheck(1) == false) {
        return false;
    }

    var strRes;
    strRes = confirm("出力してよろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
    if (strRes == false) {
        return;
    }

    doPostBack('btnExcel', '');

}
//**************************************
//Toへの自動セット 2019/11/01 T.Ono add 監視改善2019
//**************************************
function fncSetTo() {
    with (Form1) {

        //クライアント名Toセット
        if (hdnPopcrtl.value == '1'){
            hdnCLI_CD_TO.value = ""; 
            txtCLI_CD_TO.value = "";
            hdnCLI_CD_TO.value = hdnCLI_CD.value;
            txtCLI_CD_TO.value = txtCLI_CD.value;
        }

        //JA支所名Toセット
        if (hdnPopcrtl.value == '4') {
            hdnHAN_CD_TO.value = ""; 
            txtHAN_CD_TO.value = "";
            hdnHAN_CD_TO_CLI.value = "";

            hdnHAN_CD_TO.value = hdnHAN_CD.value;
            txtHAN_CD_TO.value = txtHAN_CD.value;
            hdnHAN_CD_TO_CLI.value = hdnHAN_CD_CLI.value;
        } 
    }
}