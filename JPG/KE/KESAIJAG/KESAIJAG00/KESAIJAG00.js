window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
}
//******************************************************************************
// 災害対応帳票
// PGID: KESAIJAG00.asmx.vb
//******************************************************************************
// 変更履歴
// 2020/01/06 T.Ono 新規作成

//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	__doPostBack(strCtl,strFlg); 
}
//**************************************
//出力ボタン押下時の処理
//**************************************
function btnSelect_onclick(strFlg) {
	//入力値チェック
	if(fncDataCheck(1)==false){
		return false;
	}
	
	var strRes;
	strRes = confirm("出力してよろしいですか？\n※データ件数により処理に時間がかかる場合があります。");
	if (strRes==false){
		return;
	}

    if (strFlg == 1) {
        //集計表
        doPostBack('btnOutput', '');
    } else if (strFlg == 2) {
        //明細表
        doPostBack('btnSelect', '');
    }
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
//    var name = "KESAIJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
    var name = "KESAIJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
    
	Form1.hdnPopcrtl.value = strTrg;
	fncPop('COPOPUPG00');
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
	
	Form1.hdnJACD_From.value="";
	Form1.hdnJACD_To.value="";
	Form1.txtJACD_From.value="";
    Form1.txtJACD_To.value = "";

    Form1.hdnJACD_From_CLI.value = ""; 
    Form1.hdnJACD_To_CLI.value = "";   
}

//**************************************
//入力値チェック
//**************************************
function fncDataCheck(intKbn) {
    with (Form1) {

        //クライアントのFrom～Toチェック
        if ((hdnKURACD_To.value.length != "") && (hdnKURACD_To.value != " ")) {
            if (hdnKURACD_From.value > hdnKURACD_To.value) {
                alert("クライアントToはクライアントFromより大きいクライアントを入力してください");
                Form1.btnKURACD_To.focus();
                return false;
            }
        }


		//発生日Ｆの未入力チェック
		if (txtTRGDATE_From.value.length==0) {
			alert("対象期間Fromは必須入力です");
			Form1.txtTRGDATE_From.focus();
			return false;
		}

		//発生日Ｔの未入力チェック
		if (Form1.txtTRGDATE_To.value.length==0) {
		    alert("対象期間Toは必須入力です");
			Form1.txtTRGDATE_To.focus();
			return false;
		}

		//発生日Ｆの日付チェック
		if (fncChkDate(Form1.txtTRGDATE_From.value)==false) {
		    alert("対象期間Fromは正しい日付ではありません");
			Form1.txtTRGDATE_From.focus();
			return false;
		}

		//発生日Ｔの日付チェック
		if (fncChkDate(Form1.txtTRGDATE_To.value)==false) {
		    alert("対象期間Toは正しい日付ではありません");
			Form1.txtTRGDATE_To.focus();
			return false;
		}

		//発生日のFrom～Toチェック
		if((txtTRGDATE_From.value.split("/").join("") > txtTRGDATE_To.value.split("/").join(""))) {
		    alert("対象期間Toは対象期間Fromより先の日付を入力してください");
			Form1.txtTRGDATE_To.focus();
			return false;
		}

        //対象時間Ｆのみ入力チェック   2017/02/16 H.Mori add 改善2016 No7-1
        if ((txtTRGTIME_From.value.length != 0) && (txtTRGTIME_To.value.length == 0)) {
            alert("対象時間Fromのみの指定はできません");
            txtTRGTIME_To.focus();
            return false;
        }

        //対象時間Ｔのみ入力チェック   2017/02/15 H.Mori add 改善2016 No7-1
        if ((txtTRGTIME_From.value.length == 0) && (txtTRGTIME_To.value.length != 0)) {
            alert("対象時間Toのみの指定はできません");
            txtTRGTIME_From.focus();
            return false;
        }

        //対象時間Ｆの時刻チェック   2017/02/15 H.Mori add 改善2016 No7-1
        if ((txtTRGTIME_From.value.length > 0) && (fncChkTime(txtTRGTIME_From.value + ':00') == false)) {
            alert("対象時間Fromは時刻を入力してください");
            txtTRGTIME_From.focus();
            return false;
        }

        //対象時間Ｔの時刻チェック   2017/02/15 H.Mori add 改善2016 No7-1
        if ((txtTRGTIME_To.value.length > 0) && (fncChkTime(txtTRGTIME_To.value + ':00') == false)) {
            alert("対象時間Toは時刻を入力してください");
            txtTRGTIME_To.focus();
            return false;
        }
        //対象時間のFrom～Toチェック 2017/02/15 H.Mori add 改善2016 No7-1
        if ((txtTRGTIME_From.value.length != 0) && (txtTRGTIME_To.value.length != 0)) {
            if (txtTRGDATE_From.value == txtTRGDATE_To.value) {
                if ((txtTRGTIME_From.value.split(":").join("") > txtTRGTIME_To.value.split(":").join(""))) {
                    alert("対象期間が同日の場合、対象時間Toは対象時間Fromより先の時刻を入力してください");
                    txtTRGTIME_To.focus();
                    return false;
                }
            }
        }

		//対応区分チェック
		if (Form1.chkTAI_TEL.checked==false && Form1.chkTAI_SHU.checked==false && Form1.chkTAI_JUF.checked==false) {
			alert("対応区分を1つ以上選択してください");
			Form1.chkTAI_TEL.focus();
			return false;
		}
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

//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtKURACD_From.focus()
}
//**************************************
//Toへの自動セット
//**************************************
function fncSetTo() {
    with (Form1) {

        //クライアント名Toセット
        if (hdnPopcrtl.value == '0') {
            hdnKURACD_To.value = "";
            txtKURACD_To.value = "";
            hdnKURACD_To.value = hdnKURACD_From.value;
            txtKURACD_To.value = txtKURACD_From.value;
        }

        //JAToセット
        if (hdnPopcrtl.value == '2') {
            hdnJACD_To.value = "";
            txtJACD_To.value = "";
            hdnJACD_To_CLI.value = "";

            hdnJACD_To.value = hdnJACD_From.value;
            txtJACD_To.value = txtJACD_From.value;
            hdnJACD_To_CLI.value = hdnJACD_From_CLI.value;
        }
    }
}
//**************************************
//対応完了日or感震器遮断警報ラジオボタン 2021/10/01saka 2021年度監視改善⑥未処理感震器遮断警報出力で画面制御を考えたが不要となった
//**************************************
//2021/10/01頑張ったが不使用ということになったのですべてコメントアウト（ただ後段で参照できるように残しておく・・ラジオボタンをクリックすることで画面項目を活性化したり非活性化したりの）
//function chkRadio_KIKAN() {
//    with (Form1) {
//        //チェックあり
//        if (rdoKIKAN1.checked == true) {
//            //alert("対応完了日チェック");                ←メッセージを表示できるのでサンプル残し
//            Table9.disabled = false;                    //KESAIJAG00.aspxのIDから対応区分を活性化
//            Table10.disabled = false;                   //出力項目を活性化
//            Table13.disabled = false;                   //個人情報を活性化
//            Table11.disabled = false;                   //作動原因を活性化
//            cboTSADCD.value = "59";                     //元々の初期値である「59:自然災害」を再セット
//            btnSelect.disabled = false;                 //明細表出力ボタンを活性化
//        } else if (rdoKIKAN2.checked == true) {
//            //alert("感震器遮断チェック");                ←メッセージを表示できるのでサンプル残し
//            Table9.disabled = true;　　　               //KESAIJAG00.aspxのIDから対応区分を非活性化
//            Table10.disabled = true;                    //出力項目を非活性化
//            Table13.disabled = true;                    //個人情報を非活性化
//            cboTSADCD.value = "";                     　//作動原因の初期値をクリア
//            Table11.disabled = true;                    //クリアしてから非活性化、順番が逆でも正常に動いたが一応
//            btnSelect.disabled = true;                  //明細表出力ボタンを非活性化
//        }
//    }
//}