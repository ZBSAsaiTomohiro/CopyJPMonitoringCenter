window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
}
//******************************************************************************
// 警報出力指示画面
// PGID: KETAITYW00.asmx.vb
//******************************************************************************
// 変更履歴
// 2008/11/27 T.Watabe 監視コードの必須を外す

//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
}
//**************************************
//出力ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
	//入力値チェック
	if(fncDataCheck(1)==false){
		return false;
	}
	
	//2014/12/15 H.Hosoda add 2014改善開発 No13 START
	var strRes;
	strRes = confirm("出力してよろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
	if (strRes==false){
		return;
	}
	//2014/12/15 H.Hosoda add 2014改善開発 No13 END
	
	doPostBack('btnSelect','');

	//fncCheckSubmit("KETAITCG00");
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
//2014/12/12 H.Hosoda mod 2014改善開発 No13 START
//function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
//    var nowday = new Date();
//    var name = "KETAITYG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
    var name = "KETAITYG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
//2014/12/12 H.Hosoda mod 2014改善開発 No13 END
//**************************************
//ポップアップ
//**************************************
function btnPopup_onclick(strTrg) {

	// 2008/11/27 T.Watabe del
	//if ((Form1.cboKANSCD.value.length == 0) || (Form1.cboKANSCD.value == "XYZ")) {
	//	//クライアントコード選択時は、監視センターが必ず確定していること
	//	alert('監視センターを指定してください');
	//	Form1.cboKANSCD.focus();
	//	return false;
	//}

////	if (strTrg == 0) {
////		//ＪＡの選択時は、供給センターが必ず確定していること
////		if (Form1.txtKANSICD.value.length == 0) {
////			alert("監視センターを指定してください");
////			Form1.txtKANSICD.value="";
////			Form1.txtKANSICD.focus();
////			return false;
////		}
////	}else if (strTrg == 3) {
////		//ＪＡ支所の選択時は、ＪＡが必ず確定していること
////		if (Form1.txtJACD.value.length == 0) {
////			alert("ＪＡを指定してください");
////			Form1.txtJASCD.value="";
////		Form1.btnKen1.focus();
////			return false;
////		}
////	}

	//2014/12/11 H.Hosoda add 監視改善2014 №13 START
    // ＪＡ
    if (strTrg == '2' || strTrg == '3' ) {
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
	//2014/12/11 H.Hosoda add 監視改善2014 №13 END
	
	Form1.hdnPopcrtl.value = strTrg;
	//2014/12/12 H.Hosoda mod 2014改善開発 No13 START
	//fncPop('COPOPUPG00');
	if (strTrg == '4' || strTrg == '5') {
	    fncPop("COPOPUPG00", "600");
	} else {
	    fncPop("COPOPUPG00");
	}
	//2014/12/12 H.Hosoda mod 2014改善開発 No13 END

//	Form1.hdnPopcrtl.value = strTrg;
//	if (strTrg == '1') {
//		fncPop("COPOPUPG00");
//	} else {
//		fncPop("COPOPUPG00");
//	}
	Form1.hdnPopcrtl.value = "";	
}
//**************************************
//カレンダーの表示
//**************************************
function btnCalendar_onclick(ind) {
	Form1.hdnCalendar.value=ind;
	fncPop('COCALDRG00');
	Form1.hdnCalendar.value="";
}

//*********************************
//監視センターコンボが変更された時
//*********************************
function fncKansiChange() {
	Form1.hdnKURACD_From.value="";
	Form1.hdnKURACD_To.value="";
	Form1.txtKURACD_From.value="";
	Form1.txtKURACD_To.value="";
	
	Form1.hdnJACD_From.value=""; //@
	Form1.hdnJACD_To.value="";
	Form1.txtJACD_From.value="";
	Form1.txtJACD_To.value="";
}

//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	with(Form1) {
		// 2008/11/27 T.Watabe edit 監視センターの必須を外す
		////監視センターコードの未入力チェック
		//if ((Form1.cboKANSCD.value.length == 0) || (Form1.cboKANSCD.value == "XYZ")) {
		//	alert('監視センターは必須入力です');
		//	Form1.cboKANSCD.focus();
		//	return false;
		//}
		if ((Form1.cboKANSCD.value.length == 0) || (Form1.cboKANSCD.value == "XYZ")) {
		}else{
		    //クライアントコードＦの未入力チェック
		    //if (Form1.hdnKURACD_From.value.length == 0) {                     //2012/04/26 NEC ou Del                         
		    if (fncTrim(Form1.hdnKURACD_From.value).length == 0) {              //2012/04/26 NEC ou Add
				alert('クライアントFromは必須入力です');
				Form1.btnKURACD_From.focus();
				return false;
			}

			//クライアントコードToの未入力チェック
            //if (Form1.hdnKURACD_To.value.length == 0) {                       //2012/04/26 NEC ou Del
            if (fncTrim(Form1.hdnKURACD_To.value).length == 0) {                //2012/04/26 NEC ou Add
				alert('クライアントToは必須入力です');
				Form1.btnKURACD_To.focus();
				return false;
			}

			//クライアントのFrom～Toチェック
			if(hdnKURACD_From.value > hdnKURACD_To.value) {
				alert("クライアントToはクライアントFromより大きいクライアントを入力してください");
				Form1.btnKURACD_To.focus();
				return false;
			}
			
			// ＪＡコードがどちらか指定されている時はクライアントコードは同じでないといけないチェック ' 2008/11/11 T.Watabe edit
			if ((fncTrim(hdnJACD_From.value) != "" || fncTrim(hdnJACD_To.value) != "")) {            //2012/04/26 NEC ou Upd
				if (fncTrim(hdnKURACD_From.value) != fncTrim(hdnKURACD_To.value)) {                  //2012/04/26 NEC ou Upd
					alert("クライアントコードを同じ値を設定してください");
					Form1.btnKURACD_To.focus();
					return false;
				}
			}	
			// ＪＡコードのFrom～Toチェック ' 2008/11/11 T.Watabe edit
			if (fncTrim(hdnJACD_From.value) != "" && fncTrim(hdnJACD_To.value) != "") {             //2012/04/26 NEC ou Upd
				if (fncTrim(hdnJACD_From.value) > fncTrim(hdnJACD_To.value)) {                      //2012/04/26 NEC ou Upd
					alert("ＪＡコードToはＪＡコードFromより大きいＪＡコードを入力してください");
					Form1.btnJACD_To.focus();
					return false;
				}
			}

			// 販売事業者グループコードがどちらか指定されている時はクライアントコードは同じでないといけないチェック ' 2014/12/12 H.Hosoda add 監視改善2014 №13
			if ((fncTrim(hdnHANGRP_From.value) != "" || fncTrim(hdnHANGRP_To.value) != "")) {
				if (fncTrim(hdnKURACD_From.value) != fncTrim(hdnKURACD_To.value)) {
					alert("クライアントコードを同じ値を設定してください");
					Form1.btnKURACD_To.focus();
					return false;
				}
			}	
			// 販売事業者グループコードのFrom～Toチェック ' 2014/12/12 H.Hosoda add 監視改善2014 №13
			if (fncTrim(hdnHANGRP_From.value) != "" && fncTrim(hdnHANGRP_To.value) != "") {
				if (fncTrim(hdnHANGRP_From.value) > fncTrim(hdnHANGRP_To.value)) {
					alert("販売事業者グループコードToは販売事業者グループコードFromより大きい販売事業者グループコードを入力してください");
					Form1.btnHANGRP_To.focus();
					return false;
				}
			}
		}
		
		//発生日Ｆの未入力チェック
		if (txtTRGDATE_From.value.length==0) {
			alert("発生日Fromは必須入力です");
			Form1.txtTRGDATE_From.focus();
			return false;
		}

		//発生日Ｔの未入力チェック
		if (Form1.txtTRGDATE_To.value.length==0) {
			alert("発生日Toは必須入力です");
			Form1.txtTRGDATE_To.focus();
			return false;
		}

		//発生日Ｆの日付チェック
		if (fncChkDate(Form1.txtTRGDATE_From.value)==false) {
			alert("発生日Fromは正しい日付ではありません");
			Form1.txtTRGDATE_From.focus();
			return false;
		}

		//発生日Ｔの日付チェック
		if (fncChkDate(Form1.txtTRGDATE_To.value)==false) {
			alert("発生日Toは正しい日付ではありません");
			Form1.txtTRGDATE_To.focus();
			return false;
		}

		//発生日のFrom～Toチェック
		if((txtTRGDATE_From.value.split("/").join("") > txtTRGDATE_To.value.split("/").join(""))) {
			alert("発生日Toは発生日Fromより先の日付を入力してください");
			Form1.txtTRGDATE_To.focus();
			return false;
		}
		
		//2014/12/09 H.Hosoda add 監視改善2014 №13 START
		//発生区分チェック
		if (Form1.chkHSI_TEL.checked==false && Form1.chkHSI_KEI.checked==false) {
			alert("発生区分を1つ以上選択してください");
			Form1.chkHSI_TEL.focus();
			return false;
		}
		//対応区分チェック
		if (Form1.chkTAI_TEL.checked==false && Form1.chkTAI_SHU.checked==false && Form1.chkTAI_JUF.checked==false) {
			alert("対応区分を1つ以上選択してください");
			Form1.chkTAI_TEL.focus();
			return false;
		}
		//2014/12/09 H.Hosoda add 監視改善2014 №13 END
	}
}
////**************************************
////確認メッセージによる実行
////**************************************
//function fncCheckSubmit(strId){
//	with(Form1) {
//		hdnKensaku.value=strId;
//   		target="Recv";
//		submit();
//		hdnKensaku.value="";
//		target=""				
//	}
//}

//2012/04/26 NEC ou Add Str
function fncTrim(str){
    return str.replace(" ", "");
}
//2012/04/26 NEC ou Add End
//2013/08/29 T.Ono add 監視改善2013№1
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtKURACD_From.focus()
}