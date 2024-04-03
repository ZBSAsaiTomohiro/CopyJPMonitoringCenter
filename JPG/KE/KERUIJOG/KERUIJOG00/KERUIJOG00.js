window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
}
// 2011/02/02（試行錯誤）
function __doPostBackNew(eventTarget, eventArgument) {
	try{
//alert("__doPostBackNew 00 eventTarget=[" + eventTarget + "] eventArgument=[" + eventArgument + "]");  // 2011/02/02
		var theform;
		if (window.navigator.appName.toLowerCase().indexOf("microsoft") > -1) {
			theform = document.Form1;
		}
		else {
			theform = document.forms["Form1"];
		}
		theform.__EVENTTARGET.value = eventTarget.split("$").join(":");
		theform.__EVENTARGUMENT.value = eventArgument;
		theform.target = "_blank";  // 2011/02/02
		theform.submit();
	}catch(e){
		alert("ERROR:" + e);
	}
}

//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg);  // 2011/02/02
	//__doPostBackNew(strCtl,strFlg);  // 2011/02/10 T.Watabe 元の処理に戻す
}
//**************************************
//検索ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
	//入力値チェック-----------※日付のFromToなど
	if(fncDataCheck(1)==false){
		return false;
	}
    //2015/02/12 H.Hosoda add 2014改善開発 No8 START
    var strRes;
    strRes = confirm("出力してよろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
    if (strRes == false) {
        return;
    }
    //2015/02/12 H.Hosoda add 2014改善開発 No8 START
	fncCheckSubmit("KERUIJCG00");
	//fncCheckSubmit2("KERUIJCG00");
	
	return false;
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
	with(Form1) {
		var strURL;	
		strURL="../../../COGMENUG00.aspx";
	}
	parent.frames("Data").location=strURL;		
}
//**********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "KERUIJOG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
//ポップアップ
//**************************************
function btnPopup_onclick(strTrg) {
    if (strTrg == 1) {
        //供給センター
        //if (Form1.txtKURACD.value.length == 0) {                                  //2012/04/04 NEC ou Del
        if ((Form1.txtKURACD.value == "") || (Form1.txtKURACD.value == " ")) {      //2012/04/04 NEC ou Add
            alert("クライアントを指定してください");
            Form1.txtKURACD.value = "";
            Form1.btnKURACD.focus();
            return false;
        }
        //--- ↓2005/05/24 DEL Falcon↓ ---
        //}else if (strTrg == 2) {
        //  //ＪＡ
        //	//ＪＡの選択時は、供給センターが必ず確定していること
        //	if (Form1.txtKYOCD.value.length == 0) {
        //		alert("供給センターを指定してください");
        //		Form1.txtJACD.value="";
        //		Form1.btnKYOCD.focus();
        //		return false;
        //	}
        //--- ↑2005/05/24 DEL Falcon↑ ---
        //2014/01/21 T.Ono mod 監視改善2013
        //JA名、JA支所名ともにクライアント必須
        //JA支所名はJA名を必須としない
        //    } else if (strTrg == 3) {
        //        //if (Form1.txtJACD.value.length == 0) {                                //2012/04/04 NEC ou Del
        //        if ((Form1.txtJACD.value == "") || (Form1.txtJACD.value == " ")) {      //2012/04/04 NEC ou Del
        //			alert("ＪＡを指定してください");
        //			Form1.txtJASCD.value="";
        //			Form1.btnKen1.focus();
        //2015/11/04 W.GANEKO 2015改善開発 №6
        //} else if ((strTrg == 2) || (strTrg == 3)) {
    } else if ((strTrg == 2) || (strTrg == 3) || (strTrg == 4) || (strTrg == 5) || (strTrg == 6) || (strTrg == 7)) {
        //ＪＡ、ＪＡ支所、販売事業者
        if ((Form1.txtKURACD.value == "") || (Form1.txtKURACD.value == " ")) {
            alert("クライアントを指定してください");
            Form1.txtKURACD.value = "";
            Form1.btnKURACD.focus();
            return false;
        }
        if ((strTrg == 6) || (strTrg == 7)) {
            if (((Form1.txtJACD_F.value != "") && (Form1.txtJACD_F.value != " ")) || ((Form1.txtJACD_T.value != "") && (Form1.txtJACD_T.value != " "))) {
                alert("JAが指定されている場合、販売事業者は指定できません。");
                Form1.txtHANJICD_F.value = "";
                Form1.btnHANJICD_F.focus();
                return false;
            }
        }
        if ((strTrg == 2) || (strTrg == 3)) {
            if (((Form1.txtHANJICD_F.value != "") && (Form1.txtHANJICD_F.value != " ")) || ((Form1.txtHANJICD_T.value != "") && (Form1.txtHANJICD_T.value != " "))) {
                alert("販売事業者が指定されている場合、JAは指定できません。");
                Form1.txtJACD_F.value = "";
                Form1.btnKen1_F.focus();
                return false;
            }
        }
    }
	Form1.hdnPopcrtl.value = strTrg;
	if (strTrg == '1') {
		fncPop("COPOPUPG00");
	} else {
		fncPop("COPOPUPG00");
	}
	//Form1.hdnPopcrtl.value = "";      //2019/11/01 T.Ono dell 監視改善2019	
}
//**************************************
//カレンダーの表示
//**************************************
function btnCalendar_onclick(ind) {
	Form1.hdnCalendar.value=ind;
	fncPop('COCALDRG00');
	Form1.hdnCalendar.value="";
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
    with (Form1) {

        //対象期間Ｆの未入力チェック   2017/02/14 H.Mori add 改善2016 No9-1 
        if (txtTRGDATE_From.value.length == 0) {
            alert("対象期間Fromは必須入力です");
            txtTRGDATE_From.focus();
            return false;
        }

        //対象期間Ｔの未入力チェック   2017/02/14 H.Mori add 改善2016 No9-1
        if (txtTRGDATE_To.value.length == 0) {
            alert("対象期間Toは必須入力です");
            txtTRGDATE_To.focus();
            return false;
        }

        //対象期間Ｆの日付チェック
        if (fncChkDate(txtTRGDATE_From.value) == false) {
            alert("対象期間Fromは正しい日付ではありません");
            txtTRGDATE_From.focus();
            return false;
        }
        //対象期間Ｔの日付チェック
        if (fncChkDate(txtTRGDATE_To.value) == false) {
            alert("対象期間Toは正しい日付ではありません");
            txtTRGDATE_To.focus();
            return false;
        }
        //対象期間のFrom～Toチェック
        if ((txtTRGDATE_From.value.length != 0) && (txtTRGDATE_To.value.length != 0)) {
            if ((txtTRGDATE_From.value.split("/").join("") > txtTRGDATE_To.value.split("/").join(""))) {
                alert("対象期間Toは対象期間Fromより先の日付を入力してください");
                txtTRGDATE_To.focus();
                return false;
            }
        }
        //対象時間Ｆのみ入力チェック   2017/02/14 H.Mori add 改善2016 No9-1 
        if ((txtTRGTIME_From.value.length != 0) && (txtTRGTIME_To.value.length == 0)) {
            alert("対象時間Fromのみの指定はできません");
            txtTRGTIME_To.focus();
            return false;
        }

        //対象時間Ｔのみ入力チェック   2017/02/14 H.Mori add 改善2016 No9-1 
        if ((txtTRGTIME_From.value.length == 0) && (txtTRGTIME_To.value.length != 0)) {
            alert("対象時間Toのみの指定はできません");
            txtTRGTIME_From.focus();
            return false;
        }

        //対象時間Ｆの時刻チェック   2017/02/14 H.Mori add 改善2016 No9-1
        if ((txtTRGTIME_From.value.length > 0) && (fncChkTime(txtTRGTIME_From.value + ':00') == false)) {
            alert("対象時間Fromは時刻を入力してください");
            txtTRGTIME_From.focus();
            return false;
        }
        //対象時間Ｔの時刻チェック   2017/02/14 H.Mori add 改善2016 No9-1
        if ((txtTRGTIME_To.value.length > 0) && (fncChkTime(txtTRGTIME_To.value + ':00') == false)) {
            alert("対象時間Toは時刻を入力してください");
            txtTRGTIME_To.focus();
            return false;
        }

        //対象時間のFrom～Toチェック 2017/02/14 H.Mori add 改善2016 No9-1
        if ((txtTRGTIME_From.value.length != 0) && (txtTRGTIME_To.value.length != 0)) {
            if (txtTRGDATE_From.value == txtTRGDATE_To.value) {
                if ((txtTRGTIME_From.value.split(":").join("") > txtTRGTIME_To.value.split(":").join(""))) {
                    alert("対象期間が同日の場合、対象時間Toは対象時間Fromより先の時刻を入力してください");
                    txtTRGTIME_To.focus();
                    return false;
                }
            }
        }
        //ＪＡと支所の整合性チェック
        //if (hdnJASCD.value.length !=0) {        2014/01/21 T.Ono mod 監視改善2013
        //2015/11/02 w.ganeko 2015改善開発 №6 start
        //if ((hdnJASCD.value != "") && (hdnJASCD.value != " ") && (hdnJACD.value != "") && (hdnJACD.value != " ")) {
        //	if(hdnJACD.value != hdnJASCD.value.substring(0,hdnJACD.value.length)) {
        //        alert("ＪＡに紐付くＪＡ支所ではありません。再度選択してください");
        //		btnKen2.focus();
        //		return false;
        //	}
        //}
        if (checkTEL.checked == false && checkSYTUDO.checked == false && checkTYOFUKU.checked == false) {
                alert("対応区分にチェックがついていません。");
                checkTEL.focus();
                return false;
        }
        if ((hdnHANJICD_F.value != "" && hdnHANJICD_F.value != " ") && (hdnHANJICD_T.value != "" && hdnHANJICD_T.value != " ") && (hdnHANJICD_F.value > hdnHANJICD_T.value)) {
            alert("販売事業者(FROM)と販売事業者(TO)の範囲指定が間違っています。");
            btnKen1_F.focus();
            return false;
        }
        if ((hdnJACD_F.value != "" && hdnJACD_F.value != " ") && (hdnJACD_T.value != "" && hdnJACD_T.value != " ") && (hdnJACD_F.value > hdnJACD_T.value)) {
            alert("ＪＡ(FROM)とＪＡ(TO)の範囲指定が間違っています。");
            btnKen1_F.focus();
            return false;
        }
        if ((hdnJASCD_F.value != "" && hdnJASCD_F.value != " ") && (hdnJASCD_T.value != "" && hdnJASCD_T.value != " ") && (hdnJASCD_F.value > hdnJASCD_T.value)) {
            alert("ＪＡ支所(FROM)とＪＡ支所(TO)の範囲指定が間違っています。");
            btnKen2_F.focus();
            return false;
        }
        if ((hdnJASCD_F.value != "" && hdnJASCD_F.value != " ")) {
            if ((hdnHANJICD_F.value != "" && hdnHANJICD_F.value != " ") && (hdnHANJICD_T.value != "" && hdnHANJICD_T.value != " ") && (hdnJACD_F.value != hdnJACD_T.value)) {
                alert("販売事業者(FROM)と販売事業者(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnHANJICD_F.value != "" && hdnHANJICD_F.value != " ") && (hdnHANJICD_T.value == "" || hdnHANJICD_T.value == " ")) {
                alert("販売事業者(FROM)と販売事業者(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnHANJICD_T.value != "" && hdnHANJICD_T.value != " ") && (hdnHANJICD_F.value == "" || hdnHANJICD_F.value == " ")) {
                alert("販売事業者(FROM)と販売事業者(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnJACD_F.value != "" && hdnJACD_F.value != " ") && (hdnJACD_T.value != "" && hdnJACD_T.value != " ") && (hdnJACD_F.value != hdnJACD_T.value)) {
                alert("ＪＡ(FROM)とＪＡ(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnJACD_F.value != "" && hdnJACD_F.value != " ") && (hdnJACD_T.value == "" || hdnJACD_T.value == " ")) {
                alert("ＪＡ(FROM)とＪＡ(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnJACD_T.value != "" && hdnJACD_T.value != " ") && (hdnJACD_F.value == "" || hdnJACD_F.value == " ")) {
                alert("ＪＡ(FROM)とＪＡ(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnJACD_F.value != "" && hdnJACD_F.value != " ") && hdnJACD_F.value != hdnJASCD_F.value.substring(0, hdnJACD_F.value.length)) {
                alert("ＪＡに紐付くＪＡ支所ではありません。再度選択してください");
                btnKen2_F.focus();
                return false;
            }
            if ((hdnJACD_T.value != "" && hdnJACD_T.value != " ") && hdnJACD_T.value != hdnJASCD_F.value.substring(0, hdnJACD_T.value.length)) {
                alert("ＪＡに紐付くＪＡ支所ではありません。再度選択してください");
                btnKen2_F.focus();
                return false;
            }
        }
        if ((hdnJASCD_T.value != "" && hdnJASCD_T.value != " ")) {
            if ((hdnHANJICD_F.value != "" && hdnHANJICD_F.value != " ") && (hdnHANJICD_T.value != "" && hdnHANJICD_T.value != " ") && (hdnJACD_F.value != hdnJACD_T.value)) {
                alert("販売事業者(FROM)と販売事業者(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnHANJICD_F.value != "" && hdnHANJICD_F.value != " ") && (hdnHANJICD_T.value == "" || hdnHANJICD_T.value == " ")) {
                alert("販売事業者(FROM)と販売事業者(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnHANJICD_T.value != "" && hdnHANJICD_T.value != " ") && (hdnHANJICD_F.value == "" || hdnHANJICD_F.value == " ")) {
                alert("販売事業者(FROM)と販売事業者(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnJACD_F.value != "" && hdnJACD_F.value != " ") && (hdnJACD_T.value != "" && hdnJACD_T.value != " ") && (hdnJACD_F.value != hdnJACD_T.value)) {
                alert("ＪＡ(FROM)とＪＡ(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnJACD_F.value != "" && hdnJACD_F.value != " ") && (hdnJACD_T.value == "" || hdnJACD_T.value == " ")) {
                alert("ＪＡ(FROM)とＪＡ(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnJACD_T.value != "" && hdnJACD_T.value != " ") && (hdnJACD_F.value == "" || hdnJACD_F.value == " ")) {
                alert("ＪＡ(FROM)とＪＡ(TO)が等しくありません。");
                btnKen1_F.focus();
                return false;
            }
            if ((hdnJACD_F.value != "" && hdnJACD_F.value != " ") && hdnJACD_F.value != hdnJASCD_T.value.substring(0, hdnJACD_F.value.length)) {
                alert("ＪＡに紐付くＪＡ支所ではありません。再度選択してください");
                btnKen2_T.focus();
                return false;
            }
            if ((hdnJACD_T.value != "" && hdnJACD_T.value != " ") && hdnJACD_T.value != hdnJASCD_T.value.substring(0, hdnJACD_T.value.length)) {
                alert("ＪＡに紐付くＪＡ支所ではありません。再度選択してください");
                btnKen2_T.focus();
                return false;
            }
        }
        //2015/11/02 w.ganeko 2015改善開発 №6 end
        return true;
    }
}
//**************************************
//確認メッセージによる実行
//**************************************
function fncCheckSubmit(strId){
	try{ // 2011/02/02 T.Watabe edit
		with(document.Form1) {
			hdnKensaku.value = strId;
   			target = "Recv";
			submit();
			hdnKensaku.value = "";
			target = "";
		}
	}catch(e){
		alert("ERROR:" & e);
	}
	return true;
}
//**************************************
//ポップアップ
//**************************************
function fncCheckSubmit2(strId) {
	try{ // 2011/02/02 T.Watabe edit
		with(document.Form1) {
			hdnPopcrtl.value = strId;
			fncPop(strId);
			hdnPopcrtl.value = "";	
		}
	}catch(e){
		alert("ERROR:" & e);
	}
	return true;
}
//**************************************
//Toへの自動セット 2019/11/01 T.Ono add 監視改善2019
//**************************************
function fncSetTo() {
    with (Form1) {

        //JAToセット
        if (hdnPopcrtl.value == '2') {
            hdnJACD_T.value = "";
            txtJACD_T.value = "";
            hdnJACD_T.value = hdnJACD_F.value;
            txtJACD_T.value = txtJACD_F.value;
        }

        //JA支所名Toセット
        if (hdnPopcrtl.value == '4') {
            hdnJASCD_T.value = "";
            txtJASCD_T.value = "";
            hdnJASCD_T.value = hdnJASCD_F.value;
            txtJASCD_T.value = txtJASCD_F.value;
        }

        //販売事業者Toセット
        if (hdnPopcrtl.value == '6') {
            hdnHANJICD_T.value = "";
            txtHANJICD_T.value = "";
            hdnHANJICD_T.value = hdnHANJICD_F.value;
            txtHANJICD_T.value = txtHANJICD_F.value;
        }
    }
}
