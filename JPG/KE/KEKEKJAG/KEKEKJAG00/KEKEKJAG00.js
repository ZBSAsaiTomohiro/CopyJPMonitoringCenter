window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
}
//**************************************
//画面オープン時
//**************************************
function window_onload() {
	//一覧の表示
	fncListOut('KEKEKJFG00')
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
	//入力値チェック
	if(fncDataCheck(1)==false){
		return false;
	}
	
    //オブジェクトに対するロック処理
	fncFo(Form1.btnSelect,5);
	Form1.btnSelect.disabled=true;
	Form1.btnCalendar1.disabled=true;
	Form1.btnCalendar2.disabled=true;
	Form1.btnTKTANCD.disabled=true;
	Form1.btnKURACD.disabled = true;
    Form1.btnKURACD_TO.disabled = true; //2019/11/01 T.Ono add 監視改善2019
	Form1.btnJACD.disabled = true;      //2013/12/10 T.Ono add 監視改善2013
	//Form1.btnHANGRP.disabled = true;    //2014/12/08 H.Hosoda add 監視改善2014 No.7 //2019/11/01 T.Ono del 監視改善2019
	Form1.btnACBCD.disabled = true;
    Form1.btnACBCD_TO.disabled = true;  //2019/11/01 T.Ono add 監視改善2019
	Form1.btnKMCD.disabled = true;      //2013/12/10 T.Ono add 監視改善2013
	Form1.btnExit.disabled = true;
	//Form1.btnKINRENGRP.disabled = true; //2016/12/27 H.Mori add 2016改善開発 No3-1 //2019/11/01 T.Ono del 監視改善2019

	Form1.hdnScrollTop.value = "0";     //2013/12/10 T.Ono add 監視改善2013

	Form1.hdnSelectClick.value = "1";
	fncListOut('KEKEKJFG00');	
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
//**************************************
//カレンダーの表示
//**************************************
function btnCalendar_onclick(ind) {
	Form1.hdnCalendar.value=ind;
	fncPop('COCALDRG00');
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	with(Form1) {
		//発生期間Ｆの日付チェック
		if (fncChkDate(txtHATYMD_From.value)==false) {
			alert("対象期間Fromは正しい日付ではありません");
			txtHATYMD_From.focus();
			return false;
		}
		//発生期間Ｔの日付チェック
		if (fncChkDate(txtHATYMD_To.value)==false) {
		    alert("対象期間Toは正しい日付ではありません");
			txtHATYMD_To.focus();
			return false;
		}
		//発生期間のFrom～Toチェック
		if((txtHATYMD_From.value.length != 0) && (txtHATYMD_To.value.length != 0)) {
			if((txtHATYMD_From.value.split("/").join("") > txtHATYMD_To.value.split("/").join(""))) {
				alert("対象期間Toは対象期間Fromより先の日付を入力してください");
				txtHATYMD_To.focus();
				return false;
			}
		}
		//発生時刻Ｆの日付チェック
		if ((txtHATTIME_From.value.length > 0) && (fncChkTime(txtHATTIME_From.value + ':00')==false)) {
			alert("対象時間Fromは時刻を入力してください");
			txtHATTIME_From.focus();
			return false;
		}
		//発生期間Ｔの日付チェック
		if ((txtHATTIME_To.value.length > 0) && (fncChkTime(txtHATTIME_To.value + ':00')==false)) {
			alert("対象時間Toは時刻を入力してください");
			txtHATTIME_To.focus();
			return false;
		}
//		//発生期間のFrom～Toチェック　2013/12/10 T.Ono del 監視改善2013
//		if((txtHATTIME_From.value.length != 0) && (txtHATTIME_To.value.length != 0)) {
//			if((txtHATTIME_From.value.split(":").join("") > txtHATTIME_To.value.split(":").join(""))) {
//				alert("発生時刻Toは発生時刻Fromより先の時刻を入力してください");
//				txtHATTIME_To.focus();
//				return false;
//			}
//		}

        //2013/12/10 T.Ono add 監視改善2013
        //発生期間Fromの必須チェック（時刻入力時）
        if ((txtHATTIME_From.value.length > 0) && (txtHATYMD_From.value.length == 0)) {
            alert("対象期間Fromを入力してください");
            txtHATYMD_From.focus();
            return false;
        }
        //発生期間Toの必須チェック（時刻入力時）
        if ((txtHATTIME_To.value.length > 0) && (txtHATYMD_To.value.length == 0)) {
            alert("対象期間Toを入力してください");
            txtHATYMD_To.focus();
            return false;
        }
        //日付同日・対象時間のFrom～Toチェック 2017/10/26 H.Mori 2017改善開発 №3-1
        if ((txtHATTIME_From.value.length != 0) && (txtHATTIME_To.value.length != 0)) {
            if (txtHATYMD_From.value == txtHATYMD_To.value) {
                if ((txtHATTIME_From.value.split(":").join("") > txtHATTIME_To.value.split(":").join(""))) {
                    alert("対象期間が同日の場合、対象時間Toは対象時間Fromより先の時刻を入力してください");
                    txtHATTIME_To.focus();
                    return false;
                }
            }
        }

		//お客様名カナ：半角カナ
		//--- ↓2005/05/19 DEL Falcon↓ ---
		//if (fncZenkakuChk(txtJUSYOKN.value) == true) {
		//	alert("お客様名カナは半角カナで入力して下さい");
		//	txtJUSYOKN.focus();
		//	return false;
		//}
		//--- ↑2005/05/19 DEL Falcon↑ ---
		//お客様電話番号：電話番号チェック
        if (fncChkTel(txtJUTEL.value) == false) {
            //2016/11/25 H.Mori mod 2016改善開発 No3-2 START
			//2014/12/08 H.Hosoda mod 監視改善2014 No.7 START
			//alert("お客様電話番号は正しい電話番号ではありません");
			//alert("連絡先は正しい電話番号ではありません");
			//2014/12/08 H.Hosoda mod 監視改善2014 No.7 START
			alert("連絡先／結線番号は正しい電話番号ではありません");
			//2016/11/25 H.Mori mod 2016改善開発 No3-2 END
            txtJUTEL.focus();
			return false;
		}


        //2016/11/25 H.Mori del 2016改善開発 No3-2 START
        //結線番号：電話番号チェック  2014/12/08 H.Hosoda add 監視改善2014 No.7
        //if (fncChkTel(txtNCUTEL.value) == false) {
        //	alert("結線番号は正しい電話番号ではありません");
        //	txtNCUTEL.focus();
        //	return false;
        //}
        //2016/11/25 H.Mori mod 2016改善開発 No3-2 START




        //2019/11/01 T.Ono del 監視改善2019 No1
        if ((hdnKURACD.value != "" && hdnKURACD.value != " ")
            || (hdnKURACD_TO.value != "" && hdnKURACD_TO.value != " ")) {
            if (hdnKURACD.value == "" || hdnKURACD.value == " ") {
                alert("クライアント名Toのみの指定はできません");
                btnKURACD.focus();
                return false;
            }
            if (hdnKURACD_TO.value == "" || hdnKURACD_TO.value == " ") {
                alert("クライアント名Fromのみの指定はできません");
                btnKURACD_TO.focus();
                return false;
            }
        }

        //2019/11/01 T.Ono add 監視改善2019 クライアントFROM > クライアントTOの場合
        if ((hdnKURACD.value != "" && hdnKURACD.value != " ") && (hdnKURACD_TO.value != "" && hdnKURACD_TO.value != " ") && (hdnKURACD.value > hdnKURACD_TO.value)) {
            alert("クライアント名(FROM)とクライアント名(TO)の範囲指定が間違っています。");
            btnKURACD.focus();
            return false;
        }

        //2019/11/01 T.Ono add 監視改善2019
        if ((hdnACBCD.value != "" && hdnACBCD.value != " ")
            || (hdnACBCD_TO.value != "" && hdnACBCD_TO.value != " ")) {
            if (hdnACBCD.value == "" || hdnACBCD.value == " ") {
                alert("JA支所Toのみの指定はできません");
                btnACBCD.focus();
                return false;
            }
            if (hdnACBCD_TO.value == "" || hdnACBCD_TO.value == " ") {
                alert("JA支所Fromのみの指定はできません");
                btnACBCD_TO.focus();
                return false;
            }
        }
	}	
}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {
    //2016/11/25 H.Mori mod 監視改善2016 No3-1 START
    //2014/01/21 T.Ono mod 監視改善2013
    //JA名、JA支所名ともにクライアント必須
    //JA支所名はJA名を必須としない
    //if (strFlg == "2") {
    //2014/12/08 H.Hosoda mod 監視改善2014 No.7 START
    //JA名、JA支所名、販売事業者ともにクライアント必須
    //if ((strFlg=="2") || (strFlg=="3")){
    //if ((strFlg == "2") || (strFlg == "3") || (strFlg == "6") || (strFlg == "7")) { //2019/11/01 T.Ono mod 監視改善2019
    if ((strFlg == "2") || (strFlg == "3") || (strFlg == "7")) {
    //2014/12/08 H.Hosoda mod 監視改善2014 No.7 END
    //2016/11/25 H.Mori mod 監視改善2016 No3-1 END
		//JAポップアップ出力時
	    //if(Form1.hdnKURACD.value.length==0) { 2014/01/16 T.Ono mod 監視改善2013
        if ((Form1.hdnKURACD.value == "") || (Form1.hdnKURACD.value == " ")) {
 			alert("クライアント名を選択して下さい");
			Form1.btnKURACD.focus();
			return false;
		}

        //2019/11/01 T.Ono mod 監視改善2019
        if ((Form1.hdnKURACD_TO.value == "") || (Form1.hdnKURACD_TO.value == " ")) {
            alert("クライアント名を選択して下さい");
            Form1.btnKURACD_TO.focus();
            return false;
        }

//    }else if (strFlg=="3") {
//        //2013/12/10 T.Ono add 監視改善2013
//        //JA支所ポップアップ出力時
//		//if(Form1.txtJANM.value.length==0) { 2014/01/16 T.Ono mod 監視改善2013
//        if ((Form1.txtJANM.value == "") || (Form1.txtJANM.value == " ")) { 
//			alert("ＪＡ名を選択して下さい");
//			Form1.btnJACD.focus();
//			return false;
//		}
//    }else{
    }

    //2019/11/01 T.Ono del 監視改善2019
    ////2014/12/08 H.Hosoda add 2014改善開発 No7 START
    //// ＪＡ名
    //if (strFlg == '2') {
    //    // 販売事業者が既に選択されている場合は、選択不可
    //    if ((Form1.txtHANGRP.value != "") && (Form1.txtHANGRP.value != " ")) {
    //        alert("ＪＡ名と販売事業者は両方を選択することはできません");
    //        return false;
    //    }
    //    //2016/11/25 H.Mori add 2016改善開発 No3-1
    //    // 緊急連絡先Grが既に選択されている場合は、選択不可
    //    if ((Form1.txtKINRENGRP.value != "") && (Form1.txtKINRENGRP.value != " ")) {
    //        alert("ＪＡ名と緊急連絡先Grは両方を選択することはできません");
    //        return false;
    //    }
    //}
    //2019/11/01 T.Ono del 監視改善2019
    // 販売事業者
    //if (strFlg == '6') {
    //    // ＪＡ名が既に選択されている場合は、選択不可
    //    if ((Form1.txtJANM.value != "") && (Form1.txtJANM.value != " ")) {
    //        alert("ＪＡ名と販売事業者は両方を選択することはできません");
    //        return false;
    //    }
    //    //2016/11/25 H.Mori add 2016改善開発 No3-1
    //    // 緊急連絡先Grが既に選択されている場合は、選択不可
    //    if ((Form1.txtKINRENGRP.value != "") && (Form1.txtKINRENGRP.value != " ")) {
    //        alert("販売事業者と緊急連絡先Grは両方を選択することはできません");
    //        return false;
    //    }
    //}

    //2019/11/01 T.Ono del 監視改善2019
    //2016/11/25 H.Mori add 2016改善開発 No3-1 START
    // 緊急連絡先Gr
    //if (strFlg == '7') {
    //    // ＪＡ名が既に選択されている場合は、選択不可
    //    if ((Form1.txtJANM.value != "") && (Form1.txtJANM.value != " ")) {
    //        alert("ＪＡ名と緊急連絡先Grは両方を選択することはできません");
    //        return false;
    //    }
    //    // 販売事業者が既に選択されている場合は、選択不可
    //    if ((Form1.txtHANGRP.value != "") && (Form1.txtHANGRP.value != " ")) {
    //        alert("販売事業者と緊急連絡先Grは両方を選択することはできません");
    //        return false;
    //    }
    //}

    //2014/12/08 H.Hosoda add 2014改善開発 No7 END
    Form1.hdnPopcrtl.value = strFlg;
    //2019/11/01 T.Ono mod 監視改善2019 START
    ////2016/11/25 H.Mori add 2016改善開発 No3-1 緊急連絡先Gr
	////2014/12/04 H.Hosoda mod 2014改善開発 No6 START
	////fncPop('COPOPUPG00');
    //if (strFlg == '6') {
    //    fncPop("COPOPUPG00","600");
    //} else if (strFlg == '7') {
    //    fncPop("COPOPUPG00", "700");
    //} else {
    //    fncPop("COPOPUPG00");
    //}
	////2014/12/04 H.Hosoda mod 2014改善開発 No6 END
    fncPop('COPOPUPG00');
    //2019/11/01 T.Ono mod 監視改善2019 END
}
//*********************************
//ポップアップ用
//*********************************
var wP;
//2014/12/08 H.Hosoda mod 2014改善開発 No7 START
//function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
//    var nowday = new Date();
//    var name = "KEKEKJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
    var name = "KEKEKJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
//2014/12/08 H.Hosoda mod 2014改善開発 No7 END
//*********************************
//監視センターコンボが変更された時
//*********************************
function fncKansiChange() {
	with(Form1) {
		hdnTKTANCD.value="";
		txtTKTANCD.value="";
		hdnKURACD.value="";
		txtKURACD.value = "";
        hdnKURACD_TO.value = ""; //2019/11/01 T.Ono add 監視改善2019
        txtKURACD_TO.value = ""; //2019/11/01 T.Ono add 監視改善2019
		hdnJACD.value = "";     //2013/12/10 T.Ono add 監視改善2013
		txtJANM.value = "";     //2013/12/10 T.Ono add 監視改善2013
		hdnACBCD.value="";
		txtACBNM.value = "";
        hdnACBCD_TO.value = ""; //2019/11/01 T.Ono add 監視改善2019
        txtACBNM_TO.value = ""; //2019/11/01 T.Ono add 監視改善2019
        //2019/11/01 T.Ono del 監視改善2019
  　　　//hdnHANGRP.value = "";     //2016/11/25 H.Mori add 監視改善2016
		//txtHANGRP.value = "";     //2016/11/25 H.Mori add 監視改善2016
		//hdnKINRENGRP.value = "";  //2016/11/25 H.Mori add 監視改善2016
		//txtKINRENGRP.value = "";  //2016/11/25 H.Mori add 監視改善2016
	}
}
//************************************** 
// 警報メッセージの選択後、HIDDEN項目を表示項目へコピー  2013/12/10 T.Ono add 監視改善2013
//**************************************
function fncKeihoMsgCopy() {
    with (Form1) {
//        txtKMCD.value = (hdnKMCD.value.length > 0) ? (hdnKMCD.value + "：" + hdnKMNM.value) : "";
        if ((hdnKMCD.value == "") || (hdnKMCD.value == " ")) {
            txtKMCD.value = "";
        } else {
            txtKMCD.value = (hdnKMCD.value + " : " + hdnKMNM.value);
        }
    }
}
//**************************************
//コンボボックスからのフォーカス移動 2013/12/10 T.Ono add 監視改善2013
//**************************************
function fncSetFocus() {
    Form1.txtKURACD.focus()
}
//**************************************
//Toへの自動セット 2019/11/01 T.Ono add 監視改善2019
//**************************************
function fncSetTo() {
    with (Form1) {

        //クライアント名Toセット
        if (hdnPopcrtl.value == '1') {
            hdnKURACD_TO.value = "";
            txtKURACD_TO.value = "";
            hdnKURACD_TO.value = hdnKURACD.value;
            txtKURACD_TO.value = txtKURACD.value;
        }

        //JA支所名Toセット
        if (hdnPopcrtl.value == '3') {
            hdnACBCD_TO.value = "";
            txtACBNM_TO.value = "";
            hdnACBCD_TO_CLI.value = "";

            hdnACBCD_TO.value = hdnACBCD.value;
            txtACBNM_TO.value = txtACBNM.value;
            hdnACBCD_TO_CLI.value = hdnACBCD_CLI.value;
        }
    }
}