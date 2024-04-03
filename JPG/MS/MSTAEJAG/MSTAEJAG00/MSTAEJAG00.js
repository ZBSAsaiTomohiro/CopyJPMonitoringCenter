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

    //2015/03/13 T.Ono add 2014改善開発 START
    var strRes;
    strRes = confirm("出力してよろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
    if (strRes == false) {
        return;
    }
    //2015/03/13 T.Ono add 2014改善開発 END

	fncCheckSubmit("MSTAEJCG00");
}
//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
	with(Form1) {
		var strURL;
		//2014/02/20 T.Ono mod 監視改善2013 マスタ一覧メニューへ戻す
        //strURL = "../../../COGMENUG00.aspx";
		strURL = "../../../COGMNMLG00.aspx";	
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
    var name = "MSTAEJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
    if (strTrg == 2) {                                                          //2012/05/11 NEC ou Upd
		//ＪＡの選択時は、供給センターが必ず確定していること
        //if (Form1.txtKURACD.value.length == 0) {                              //2012/05/11 NEC ou Del
        if ((Form1.txtKURACD.value == "") || (Form1.txtKURACD.value == " ")) {  //2012/05/11 NEC ou Add
			alert("クライアントを指定してください");
			Form1.txtKURACD.value="";
			Form1.btnKURACD.focus();
			return false;
		}
	}
    Form1.hdnPopcrtl.value = strTrg;
    fncPop("COPOPUPG00");       //2012/05/11 NEC ou Add

//2012/05/11 NEC ou Del Str
//	if (strTrg == '1') {
//		fncPop("COPOPUPG00");
//	} else {
//		fncPop("COPOPUPG00");
//	}
//	Form1.hdnPopcrtl.value = "";
//2012/05/11 NEC ou Del	 End
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
	with(Form1) {
		//クライアントが必ず確定していること
	    //if (Form1.txtKURACD.value.length == 0) {                              //2012/05/11 NEC ou Del
	    if ((Form1.txtKURACD.value == "") || (Form1.txtKURACD.value == " ")) {  //2012/05/11 NEC ou Add
			alert("クライアントを指定してください");
			Form1.txtKURACD.value="";
			Form1.btnKURACD.focus();
			return false;
		}
	}
}
//**************************************
//確認メッセージによる実行
//**************************************
function fncCheckSubmit(strId){
	with(Form1) {
		hdnKensaku.value=strId;
   		target="Recv";
		submit();
		hdnKensaku.value="";
		target=""				
	}
}

