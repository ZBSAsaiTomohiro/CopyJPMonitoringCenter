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
	//入力値チェック-----------※日付のFromToなど
	if(fncDataCheck(1)==false){
		return false;
	}

    //2015/02/09 H.Hosoda add 2014改善開発 No14 START
    var strRes;
    strRes = confirm("出力してよろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
    if (strRes == false) {
        return;
    }
    //2015/02/09 H.Hosoda add 2014改善開発 No14 START
	
	fncCheckSubmit("KEKANSCG00");
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
//2015/02/09 H.Hosoda mod 2014改善開発 No14 START
//function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
//    var nowday = new Date();
//    var name = "KEKANSYG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
function fncPop(strId, strOptwidth) {
    if (typeof strOptwidth === 'undefined') strOptwidth = "400";
    //2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "KEKANSYG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
    //2014/10/15 H.Hosoda add 2014改善開発 No20 END
    if (wP == null || wP.closed == true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
        wP = parent.fncPopupOpen(name, strOptwidth);
    } else {
        wP.close();
        wP = null;
        wP = parent.fncPopupOpen(name, strOptwidth);
    }
    wP.focus();
    Form1.hdnKensaku.value = strId;
    //Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
    Form1.target = name;
    Form1.submit();
    Form1.hdnKensaku.value = "";
    Form1.target = ""
}
//2015/02/09 H.Hosoda mod 2014改善開発 No14 END
//**************************************
//ポップアップ
//**************************************
function btnPopup_onclick(strTrg) {
    //2015/02/09 H.Hosoda del 監視改善2014 №14 START
	//if (strTrg == 1) {
		//ＪＡの選択時は、供給センターが必ず確定していること
	    //if (Form1.txtKURACD.value.length == 0) {                                  //2012/04/04 NEC ou Del
	//    if ((Form1.txtKURACD.value == "") || (Form1.txtKURACD.value == " ")) {      //2012/04/04 NEC ou Add
	//		alert("クライアントを指定してください");
	//		Form1.txtKURACD.value="";
	//		Form1.btnKURACD.focus();
	//		return false;
	//	}
    //2015/02/09 H.Hosoda del 監視改善2014 №14 End
	//--- ↓2005/05/24 DEL Falcon↓ ---
	//}else if (strTrg == 2) {
	//	//ＪＡの選択時は、供給センターが必ず確定していること
	//	if (Form1.txtKYOCD.value.length == 0) {
	//		alert("供給センターを指定してください");
	//		Form1.txtJACD.value="";
	//		Form1.btnKYOCD.focus();
	//		return false;
	//	}
	//--- ↑2005/05/24 DEL Falcon↑ ---
	//}else if (strTrg == 3) {
	//	//ＪＡ支所の選択時は、ＪＡが必ず確定していること
    //   if (Form1.txtJACD.value.length == 0) {
	//		alert("ＪＡを指定してください");
	//		Form1.txtJASCD.value="";
	//		Form1.btnKen1.focus();
	//		return false;
	//	}
    //} //2015/02/09 H.Hosoda del 監視改善2014 №14

    //2015/02/09 H.Hosoda add 監視改善2014 №13 START
    // ＪＡ
    if (strTrg == '2' || strTrg == '3') {
        // 販売事業者が既に選択されている場合は、選択不可
        if (((Form1.txtHANGRP_From.value != "") && (Form1.txtHANGRP_From.value != " "))
	        || ((Form1.txtHANGRP_To.value != "") && (Form1.txtHANGRP_To.value != " "))) {
            alert("ＪＡ名と販売事業者は両方を選択することはできません");
            return false;
        }
    }
    // 販売事業者
    if (strTrg == '4' || strTrg == '5') {
        // ＪＡ名が既に選択されている場合は、選択不可
        if (((Form1.txtJACD_From.value != "") && (Form1.txtJACD_From.value != " "))
	        || ((Form1.txtJACD_To.value != "") && (Form1.txtJACD_To.value != " "))) {
            alert("ＪＡ名と販売事業者は両方を選択することはできません");
            return false;
        }
    }
    //2015/02/09 H.Hosoda add 監視改善2014 №14 END

    Form1.hdnPopcrtl.value = strTrg;
    //2015/02/09 H.Hosoda mod 2014改善開発 No14 START
	//if (strTrg == '1') {
	//    fncPop("COPOPUPG00");
	if (strTrg == '4' || strTrg == '5') {
	    fncPop("COPOPUPG00", "600");
    //2015/02/09 H.Hosoda mod 2014改善開発 No14 END
	} else {
		fncPop("COPOPUPG00");
    }
    //2019/11/01 w.ganeko 2019監視改善
	//Form1.hdnPopcrtl.value = "";	
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

        //2015/02/09 H.Hosoda add 監視改善2014 №14 START
        //クライアントコードToの未入力チェック
        if (fncTrim(Form1.hdnKURACD_From.value).length != 0) {
            if (fncTrim(Form1.hdnKURACD_To.value).length == 0) {
                alert('クライアントToは必須入力です');
                Form1.btnKURACD_To.focus();
                return false;
            }
        }
        if (fncTrim(Form1.hdnKURACD_From.value).length == 0) {
            if (fncTrim(Form1.hdnKURACD_To.value).length != 0) {
                alert('クライアントFromは必須入力です');
                Form1.btnKURACD_From.focus();
                return false;
            }
        }
        //クライアントのFrom～Toチェック
        if (fncTrim(Form1.hdnKURACD_From.value).length != 0 && fncTrim(Form1.hdnKURACD_To.value).length != 0) {
            if (hdnKURACD_From.value > hdnKURACD_To.value) {
                alert("クライアントToはクライアントFromより大きいクライアントを入力してください");
                Form1.btnKURACD_To.focus();
                return false;
            }
        }
        // ＪＡコードがどちらか指定されている時はクライアントコードは同じでないといけないチェック 
        if ((fncTrim(hdnJACD_From.value) != "" || fncTrim(hdnJACD_To.value) != "")) {
            if (fncTrim(hdnKURACD_From.value) != fncTrim(hdnKURACD_To.value)) {
                alert("クライアントコードに同じ値を設定してください");
                Form1.btnKURACD_To.focus();
                return false;
            }
        }
        // ＪＡコードのFrom～Toチェック
        if (fncTrim(hdnJACD_From.value) != "" && fncTrim(hdnJACD_To.value) != "") {
            if (fncTrim(hdnJACD_From.value) > fncTrim(hdnJACD_To.value)) {
                alert("ＪＡコードToはＪＡコードFromより大きいＪＡコードを入力してください");
                Form1.btnJACD_To.focus();
                return false;
            }
        }
        // 販売事業者グループコードがどちらか指定されている時はクライアントコードは同じでないといけないチェック
        if ((fncTrim(hdnHANGRP_From.value) != "" || fncTrim(hdnHANGRP_To.value) != "")) {
            if (fncTrim(hdnKURACD_From.value) != fncTrim(hdnKURACD_To.value)) {
                alert("クライアントコードに同じ値を設定してください");
                Form1.btnKURACD_To.focus();
                return false;
            }
        }
        // 販売事業者グループコードのFrom～Toチェック
        if (fncTrim(hdnHANGRP_From.value) != "" && fncTrim(hdnHANGRP_To.value) != "") {
            if (fncTrim(hdnHANGRP_From.value) > fncTrim(hdnHANGRP_To.value)) {
                alert("販売事業者グループコードToは販売事業者グループコードFromより大きい販売事業者グループコードを入力してください");
                Form1.btnHANGRP_To.focus();
                return false;
            }
        }
        //発生区分チェック
        if (Form1.chkHSI_TEL.checked == false && Form1.chkHSI_KEI.checked == false) {
            alert("発生区分を1つ以上選択してください");
            Form1.chkHSI_TEL.focus();
            return false;
        }
        //対応区分チェック
        if (Form1.chkTAI_TEL.checked == false && Form1.chkTAI_SHU.checked == false && Form1.chkTAI_JUF.checked == false) {
            alert("対応区分を1つ以上選択してください");
            Form1.chkTAI_TEL.focus();
            return false;
        }
        //2015/02/09 H.Hosoda add 監視改善2014 №14 END

        //対象期間Ｆの未入力チェック   2017/02/15 H.Mori add 改善2016 No8-2 
        if (txtTRGDATE_From.value.length == 0) {
            alert("対象期間Fromは必須入力です");
            txtTRGDATE_From.focus();
            return false;
        }
        //対象期間Ｔの未入力チェック   2017/02/15 H.Mori add 改善2016 No8-2
        if (txtTRGDATE_To.value.length == 0) {
            alert("対象期間Toは必須入力です");
            txtTRGDATE_To.focus();
            return false;
        }
		//対象期間Ｆの日付チェック
		if (fncChkDate(txtTRGDATE_From.value)==false) {
			alert("対象期間Fromは正しい日付ではありません");
			txtTRGDATE_From.focus();
			return false;
		}
		//対象期間Ｔの日付チェック
		if (fncChkDate(txtTRGDATE_To.value)==false) {
			alert("対象期間Toは正しい日付ではありません");
			txtTRGDATE_To.focus();
			return false;
		}
		//対象期間のFrom～Toチェック
		if((txtTRGDATE_From.value.length != 0) && (txtTRGDATE_To.value.length != 0)) {
			if((txtTRGDATE_From.value.split("/").join("") > txtTRGDATE_To.value.split("/").join(""))) {
				alert("対象期間Toは対象期間Fromより先の日付を入力してください");
				txtTRGDATE_To.focus();
				return false;
            }
        }
        //対象時間Ｆのみ入力チェック   2017/02/15 H.Mori add 改善2016 No8-2
        if ((txtTRGTIME_From.value.length != 0) && (txtTRGTIME_To.value.length == 0)) {
            alert("対象時間Fromのみの指定はできません");
            txtTRGTIME_To.focus();
            return false;
        }

        //対象時間Ｔのみ入力チェック   2017/02/15 H.Mori add 改善2016 No8-2 
        if ((txtTRGTIME_From.value.length == 0) && (txtTRGTIME_To.value.length != 0)) {
            alert("対象時間Toのみの指定はできません");
            txtTRGTIME_From.focus();
            return false;
        }

        //対象時間Ｆの時刻チェック   2017/02/15 H.Mori add 改善2016 No8-2
        if ((txtTRGTIME_From.value.length > 0) && (fncChkTime(txtTRGTIME_From.value + ':00') == false)) {
            alert("対象時間Fromは時刻を入力してください");
            txtTRGTIME_From.focus();
            return false;
        }
        //対象時間Ｔの時刻チェック   2017/02/15 H.Mori add 改善2016 No8-2
        if ((txtTRGTIME_To.value.length > 0) && (fncChkTime(txtTRGTIME_To.value + ':00') == false)) {
            alert("対象時間Toは時刻を入力してください");
            txtTRGTIME_To.focus();
            return false;
        }
        //対象時間のFrom～Toチェック 2017/02/15 H.Mori add 改善2016 No8-2
        if ((txtTRGTIME_From.value.length != 0) && (txtTRGTIME_To.value.length != 0)) {
            if (txtTRGDATE_From.value == txtTRGDATE_To.value) {
                if ((txtTRGTIME_From.value.split(":").join("") > txtTRGTIME_To.value.split(":").join(""))) {
                    alert("対象期間が同日の場合、対象時間Toは対象時間Fromより先の時刻を入力してください");
                    txtTRGTIME_To.focus();
                    return false;
                }
            }
        }
		////ＪＡと支所の整合性チェック
		//if (hdnJASCD.value.length !=0) {
		//	if(hdnJACD.value != hdnJASCD.value.substring(0,hdnJACD.value.length)) {
		//		alert("ＪＡに紐付くＪＡ支所ではありません。再度選択してください");
		//		btnKen2.focus();
		//		return false;
		//	}
		//}
	}
}
//**************************************
//確認メッセージによる実行
//**************************************
function fncCheckSubmit(strId){
	with(Form1) {
		hdnKensaku.value = strId;
   		target = "Recv";
		submit();
		hdnKensaku.value = "";
		target = "";
	}

}
//2015/02/09 H.Hosoda add 監視改善2014 №14 START
function fncTrim(str) {
    return str.replace(" ", "");
}
//**************************************
// 集計条件の活性・非活性の切替
//**************************************
function fncPGKBNDisp() {
    with (Form1) {
        if ((fncTrim(hdnJACD_From.value) != "" || fncTrim(hdnJACD_To.value) != "")) {
            rdoPGKBN2.disabled = false;
            rdoPGKBN3.disabled = false;
            rdoPGKBN4.disabled = true;
            //rdoPGKBN5.disabled = true; 2017/02/23 H.Mori del 改善2016 No8-1
            rdoPGKBN2.parentNode.style.Color = "#000000"
            rdoPGKBN3.parentNode.style.Color = "#000000"
            rdoPGKBN4.parentNode.style.Color = "#a9a9a9"
            //rdoPGKBN5.parentNode.style.Color = "#a9a9a9" 2017/02/23 H.Mori del 改善2016 No8-1
            //if (rdoPGKBN4.checked == true || rdoPGKBN5.checked == true) { 2017/02/23 H.Mori mod 改善2016 No8-1
            if (rdoPGKBN4.checked == true) { 
                rdoPGKBN6.checked = true
            }
        } else if (fncTrim(hdnHANGRP_From.value) != "" || fncTrim(hdnHANGRP_To.value) != "") {
            rdoPGKBN2.disabled = true;
            rdoPGKBN3.disabled = true;
            rdoPGKBN4.disabled = false;
            //rdoPGKBN5.disabled = false; 2017/02/23 H.Mori del 改善2016 No8-1
            rdoPGKBN2.parentNode.style.Color = "#a9a9a9"
            rdoPGKBN3.parentNode.style.Color = "#a9a9a9"
            rdoPGKBN4.parentNode.style.Color = "#000000"
            //rdoPGKBN5.parentNode.style.Color = "#000000" 2017/02/23 H.Mori del 改善2016 No8-1
            if (rdoPGKBN2.checked == true || rdoPGKBN3.checked == true) {
                rdoPGKBN6.checked = true
            }
        } else {
            rdoPGKBN2.disabled = false;
            rdoPGKBN3.disabled = false;
            rdoPGKBN4.disabled = false;
            //rdoPGKBN5.disabled = false; 2017/02/23 H.Mori del 改善2016 No8-1
            rdoPGKBN2.parentNode.style.Color = "#000000"
            rdoPGKBN3.parentNode.style.Color = "#000000"
            rdoPGKBN4.parentNode.style.Color = "#000000"
            //rdoPGKBN5.parentNode.style.Color = "#000000" 2017/02/23 H.Mori del 改善2016 No8-1
        }
        //クライアント名Toセット
        if (hdnPopcrtl.value == '0') {
            hdnKURACD_To.value = hdnKURACD_From.value;
            txtKURACD_To.value = txtKURACD_From.value;
        }
        //JA支所名Toセット
        if (hdnPopcrtl.value == '2') {
            hdnJACD_To.value = hdnJACD_From.value;
            txtJACD_To.value = txtJACD_From.value;
        }

        //販売事業者名Toセット
        if (hdnPopcrtl.value == '4') {
            hdnHANGRP_To.value = hdnHANGRP_From.value;
            txtHANGRP_To.value = txtHANGRP_From.value;
        }
    }
}
//2015/02/09 H.Hosoda add 監視改善2014 №14 END


