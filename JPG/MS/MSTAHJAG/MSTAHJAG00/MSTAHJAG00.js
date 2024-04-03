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
    
    var strRes;
    strRes = confirm("出力してよろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
    if (strRes == false) {
        return;
    }
    
	fncCheckSubmit("MSTAHJCG00");
}
//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
	with(Form1) {
	    var strURL;
	    if (hdnBackUrl.value == "EIGYOU") {
	        //営業所メニューへ戻す    //2017/07/20 H.Mori add
	        strURL = "../../../COGMENUG00.aspx";
	    } else {
	        //マスタ一覧メニューへ戻す
	        strURL = "../../../COGMNMLG00.aspx";
	    }
	}
	parent.frames("Data").location=strURL;		
}
//**********************************
//ポップアップ用
//*********************************
var wP;

function fncPop(strId, strOptwidth) {
    if (typeof strOptwidth === 'undefined') strOptwidth = "400";
    var nowday = new Date();
    var name = "MSTAHJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
	
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
//ポップアップ
//**************************************
function btnPopup_onclick(strTrg) {
    if (strTrg == '1') { 
        //ＪＡの選択時は、供給センターが必ず確定していること
        if ((Form1.txtKURACD.value == "") || (Form1.txtKURACD.value == " ")) {
            alert("クライアントを指定してください");
            Form1.txtKURACD.value = "";
            Form1.btnKURACD.focus();
            return false;
        }
        //2019/11/01 T.Ono add 監視改善2019
        if ((Form1.txtKURACD_TO.value == "") || (Form1.txtKURACD_TO.value == " ")) {
            alert("クライアントを指定してください");
            Form1.txtKURACD_TO.value = "";
            Form1.btnKURACD_TO.focus();
            return false;
        }

        // グループコードが既に選択されている場合は、選択不可
        if ((Form1.txtGROUPCD.value != "") && (Form1.txtGROUPCD.value != " ")) {
            alert("ＪＡとグループコードは両方を選択することはできません");
            return false;
        }
    }
    // グループコード
    if (strTrg == '2') {
        // JAが既に選択されている場合は、選択不可
        if ((Form1.txtJACD.value != "") && (Form1.txtJACD.value != " ")) {
            alert("ＪＡとグループコードは両方を選択することはできません");
            return false;
        }
    }
    
    
    Form1.hdnPopcrtl.value = strTrg;
    if (strTrg == '2') {
        fncPop('COPOPUPG00', "700");
    } else {
        fncPop('COPOPUPG00');
    }

}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
    //入力チェックはないが、関数は残しておく
	with(Form1) {

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
//**************************************
//Toへの自動セット 2019/11/01 T.Ono add 監視改善2019
//**************************************
function fncSetTo() {
    with (Form1) {
        //クライアント名Toセット
        if (hdnPopcrtl.value == '0') {
            hdnKURACD_TO.value = "";
            txtKURACD_TO.value = "";
            hdnKURACD_TO.value = hdnKURACD.value;
            txtKURACD_TO.value = txtKURACD.value;
        }
    }
}
