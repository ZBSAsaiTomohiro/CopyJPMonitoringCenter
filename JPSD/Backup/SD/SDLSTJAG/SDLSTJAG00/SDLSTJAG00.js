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
    //	fncListOut('SDLSTKFG00');

    //2013/12/11 T.Ono add 監視改善2013
    //クライアント、JA、販売事業者選択は川口のみ使用可  →　出動会社のみ非表示
    if ((document.getElementById("hdnLOGIN_FLG").value == "0")) {
        //出動会社システムから
        document.getElementById("divCLI").style.display = "none";
        document.getElementById("divJA").style.display = "none";
        document.getElementById("divGRP").style.display = "none"; //2014/10/21 H.Hosoda add 2014改善開発 No10
    //営業所で使用可　2017/10/26 H.Mori del 2017改善開発 №5-1
//  } else if ((document.getElementById("hdnOTHER_KANSI_CENTER").value == "1")) { 
//      //川口監視センター以外
//      document.getElementById("divCLI").style.display = "none";
//      document.getElementById("divJA").style.display = "none";
//      document.getElementById("divGRP").style.display = "none"; //2014/10/21 H.Hosoda add 2014改善開発 No10
    } else {
        document.getElementById("divCLI").style.display = "block";
        document.getElementById("divJA").style.display = "block";
        document.getElementById("divGRP").style.display = "block"; //2014/10/21 H.Hosoda add 2014改善開発 No10
    }
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
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
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
		//0:通常出動会社　1:監視センター			
		if (hdnLOGIN_FLG.value=="1") {
			//parent.location.href='/JPG/COGBASEG00.aspx'
			parent.location.href='/JPG/COGMENUG00.aspx'
		} else {
            strURL="../../../COLOGING00.aspx";
            //parent.frames("data").location = strURL;      // 2012/06/26 NEC ou Del
            parent.location.href = strURL;                  // 2012/06/26 NEC ou Add
		}
	}

}
//**************************************
//検索ボタン押下時の処理
//**************************************
function btnSelect_onclick() {
	//入力値チェック-----------
	if(Form1.rdoKBN1.checked==true){
		if(fncDataCheck(0)==false){
			return false;
		}
	}else{
		if(fncDataCheck(1)==false){
			return false;
		}
	}
	
    //オブジェクトに対するロック処理
	fncFo(Form1.btnSelect,5);
	Form1.btnSelect.disabled=true;
	Form1.btnExit.disabled=true;
	Form1.hdnSelectClick.value = "1";
	Form1.hdnScrollTop.value = "0";     //2013/12/10 T.Ono add 監視改善2013
	if(Form1.rdoKBN1.checked==true){
		fncListOut('SDLSTSFG00');
	}else{
		fncListOut('SDLSTKFG00');
	}
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	with(Form1) {
		
		//検索対象期間From：必須
		if ((intKbn == 1) && (txtSIJIYMD_From.value.length==0)) {
			alert("検索対象期間Fromは必須入力です");
			txtSIJIYMD_From.focus();
			return false;
		}
		//検索対象期間To：必須
		if ((intKbn == 1) && (txtSIJIYMD_To.value.length==0)) {
			alert("検索対象期間Toは必須入力です");
			txtSIJIYMD_To.focus();
			return false;
		}
		//検索対象期間From：日付チェック
		if (fncChkDate(txtSIJIYMD_From.value)==false) {
			alert("検索対象期間Fromは正しい日付ではありません");
			txtSIJIYMD_From.focus();
			return false;
		}
		//検索対象期間Ｔo：日付チェック
		if (fncChkDate(txtSIJIYMD_To.value)==false) {
			alert("検索対象期間Toは正しい日付ではありません");
			txtSIJIYMD_To.focus();
			return false;
		}
		//検索対象期間：From～Toチェック
		if((txtSIJIYMD_From.value.length != 0) && (txtSIJIYMD_To.value.length != 0)) {
			if((txtSIJIYMD_From.value.split("/").join("") > txtSIJIYMD_To.value.split("/").join(""))) {
				alert("検索対象期間Toは検索対象期間Fromより先の日付を入力してください");
				txtSIJIYMD_To.focus();
				return false;
			}
		}
	}	
}
//**************************************
//画面区分が変更された時
//**************************************
function fncRdoKBN_Chenge(obj) {
	fncChangeMode(obj.value,'0')
}
//**************************************
//画面区分による制御
//**************************************
function fncChangeMode(intKBN,strMODE) {
	if (intKBN == 1) {
		//出動一覧
		Form1.txtSIJIYMD_From.readOnly = true;
		Form1.txtSIJIYMD_From.tabIndex = "-1";
		Form1.txtSIJIYMD_From.style.backgroundColor='Gainsboro';
		Form1.txtSIJIYMD_From.value = "";
		Form1.txtSIJIYMD_To.readOnly = true;
		Form1.txtSIJIYMD_To.tabIndex = "-1";
		Form1.txtSIJIYMD_To.style.backgroundColor='Gainsboro';
		Form1.txtSIJIYMD_To.value = "";
		
		//検索した状態で出力（しかし、フォーカスのセットはしない）
		Form1.hdnSelectClick.value = "2";		
		fncListOut('SDLSTSFG00');
	} else {
		//結果一覧
		Form1.txtSIJIYMD_From.readOnly = false;
		Form1.txtSIJIYMD_From.tabIndex = "2";
		Form1.txtSIJIYMD_From.style.backgroundColor='white';
		Form1.txtSIJIYMD_To.readOnly = false;
		Form1.txtSIJIYMD_To.tabIndex = "3";
		Form1.txtSIJIYMD_To.style.backgroundColor='white';
		
		if (strMODE == "0") {
			Form1.txtSIJIYMD_From.value = getTodayStr();
			Form1.txtSIJIYMD_To.value = getTodayStr();
			Form1.hdnSelectClick.value = "";
			fncListOut('SDLSTKFG00');
		} else {
			//検索した状態で出力（画面戻り遷移の時に使用）
			Form1.hdnSelectClick.value = "1";
			fncListOut('SDLSTKFG00');
		}
	}
}
//**************************************
//ポップアップ
//**************************************
function btnPopup_onclick(strTrg) {

    //2014/10/21 H.Hosoda mod 2014改善開発 No10 START
    //if (strTrg == 1) {
    if (strTrg == 1 || strTrg == 2) {
    //2014/10/21 H.Hosoda mod 2014改善開発 No10 END
        //ＪＡまたは販売事業者の選択時は、クライアントを選択すること
        if ((Form1.txtCLI_CD.value == "") || (Form1.txtCLI_CD.value == " ")) { 
            alert("クライアントを指定してください");
            Form1.txtCLI_CD.value = "";
            Form1.btnCLI_CD.focus();
            return false;
        }
    }
    //2014/10/21 H.Hosoda add 2014改善開発 No10 START
    // ＪＡ名
    if (strTrg == '1') {
        // 販売事業者が既に選択されている場合は、選択不可
        if ((Form1.txtGROUP_CD.value != "") && (Form1.txtGROUP_CD.value != " ")) {
            alert("ＪＡ名と販売事業者は両方を選択することはできません");
            return false;
        }
    }
    // 販売事業者
    if (strTrg == '2') {
        // ＪＡ名が既に選択されている場合は、選択不可
        if ((Form1.txtJA_CD.value != "") && (Form1.txtJA_CD.value != " ")) {
            alert("ＪＡ名と販売事業者は両方を選択することはできません");
            return false;
        }
    }
    //2014/10/21 H.Hosoda add 2014改善開発 No10 END

    Form1.hdnPopcrtl.value = strTrg;
    if (strTrg == '1') {
        fncPop("COPOPUPG00");
    // 2014/10/31 H.Hosoda add ポップアップ表示幅変更 START
    }
    else if (strTrg == '2') {
        fncPop("COPOPUPG00","600");
    // 2014/10/31 H.Hosoda add ポップアップ表示幅変更 END
    } else {
        fncPop("COPOPUPG00");
    }
    Form1.hdnPopcrtl.value = "";
}
//**********************************
//ポップアップ用
//*********************************
var wP;
// 2014/10/31 H.Hosoda mod ポップアップ表示幅変更 START
//function fncPop(strId) {
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
//    var nowday = new Date();
//   var name = "SDLSTJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
	//2014/10/15 H.Hosoda add 2014改善開発 No20 END
//    if (wP == null || wP.closed == true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
//        wP = parent.fncPopupOpen(name);
//    } else {
//        wP.close();
//        wP = null;
//        wP = parent.fncPopupOpen(name);
//    }
//    wP.focus();
//    Form1.hdnKensaku.value = strId;
	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
//	Form1.target = name;
//    Form1.submit();
//    Form1.hdnKensaku.value = "";
//    Form1.target = ""
//}
function fncPop(strId,strOptwidth) {
	if(typeof strOptwidth === 'undefined') strOptwidth = "400";
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "SDLSTJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
	//2014/10/15 H.Hosoda add 2014改善開発 No20 END
    if (wP == null || wP.closed == true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
        wP = parent.fncPopupOpen(name,strOptwidth);
    } else {
        wP.close();
        wP = null;
        wP = parent.fncPopupOpen(name,strOptwidth);
    }
    wP.focus();
    Form1.hdnKensaku.value = strId;
	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
	Form1.target = name;
    Form1.submit();
    Form1.hdnKensaku.value = "";
    Form1.target = ""
}
// 2014/10/31 H.Hosoda mod ポップアップ表示幅変更 END
