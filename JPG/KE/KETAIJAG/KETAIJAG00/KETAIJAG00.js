//2022/08/05 ADD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
//**************************************
//Array.indexOf() IE用に独自実装
//  参考：https://goma.pw/article/2016-02-22-0/
//**************************************
if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (obj, start) {
        for (var i = (start || 0), j = this.length; i < j; i++) {
            if (this[i] === obj) { return i; }
        }
        return -1;
    }
}
/**
 * 古いブラウザに対応するための、ポリフィル情報を追加。 //指定桁埋め（必要桁に満たない場合、左端から指定文字で桁埋めを実行する）
 * String.padStart()
 * version 1.0.1
 * Feature	        Chrome  Firefox Internet Explorer   Opera	Safari	Edge
 * Basic support	57   	51      (No)	            44   	10      15
 * -------------------------------------------------------------------------------
 */
// https://github.com/uxitten/polyfill/blob/master/string.polyfill.js
// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/padStart
if (!String.prototype.padStart) {
    String.prototype.padStart = function padStart(targetLength, padString) {
        targetLength = targetLength >> 0; //truncate if number, or convert non-number to 0;
        padString = String(typeof padString !== "undefined" ? padString : " ");
        if (this.length >= targetLength) {
            return String(this);
        } else {
            targetLength = targetLength - this.length;
            if (targetLength > padString.length) {
                padString += padString.repeat(targetLength / padString.length); //append to original to ensure we are longer than needed
            }
            return padString.slice(0, targetLength) + String(this);
        }
    };
}
//2022/08/05 ADD END Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

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
	if (strCtl!='btnExit') {
		Form1.target="Recv";
	}
	__doPostBack(strCtl,strFlg); 
	if (strCtl!='btnExit') {
		Form1.target="";
    } else {
        window.top.document.title = '監視システム'; // 2014/12/9 T.Ono add 2014改善開発 №2
    }
}
//*********************************
//submit
//*********************************
function doSubmit(strId){
	Form1.hdnKensaku.value=strId;
	Form1.target="Recv"
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""
}
//*********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "KETAIJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
// 2022/12/21 ADD START Y.ARAKAKI 2022更改No9 _顧客記事への初回リアルタイム日付自動セット対応
var setDayTimeFlg = true;
//**************************************
//チェックボックス変更
//**************************************
function okyakukiji_AddDate() {
    var TxtArea_txtGENIN_KIJI = document.getElementById('txtGENIN_KIJI');
    if (setDayTimeFlg) {
        var wkNowDayTime = new Date();
        var nowDayTime = " " + wkNowDayTime.getFullYear() + "/" +
            (wkNowDayTime.getMonth() + 1).toString().padStart(2, '0') + "/" +
            wkNowDayTime.getDate().toString().padStart(2, '0') + " "; //年月日までを表示する。
        //wkNowDayTime.getHours().toString().padStart(2, '0') + ":" + // 時間：時分表示は不要とのことだったので、コメントのみ残し実装しない。
        //wkNowDayTime.getMinutes().toString().padStart(2, '0') + " ";// 分：
        TxtArea_txtGENIN_KIJI.value += nowDayTime;
        setDayTimeFlg = false;//一度実行したら、フラグを切って2度以降の処理を実行しない。（画面再表示でフラグリセット）
        TxtArea_txtGENIN_KIJI.blur();  //文字列追加するとキャレットが左端に移動してしまうため、
        TxtArea_txtGENIN_KIJI.focus(); //ブラーでフォーカス解除→フォーカスで再選択状態にして、キャレット位置を右端になるよう調整。
        // ※.setSelectionRange()やWindow.getSelection()は「プロパティまたはメソッドをサポートしていません。」と表示され使用不可だった。
    }
}
// 2022/12/21 ADD END   Y.ARAKAKI 2022更改No9 _顧客記事への初回リアルタイム日付自動セット対応
//**************************************
//登録ボタン押下時の処理
//**************************************
function btnUpdate_onclick() {
	//入力値チェック---------------
	if(fncDataCheck()==false){
		return false;
	}
	var strRes;
	//確認メッセージ---------------
	if (Form1.hdnBackUrl.value == "KEKEKJAG00") {
		//対応結果一覧画面からの画面遷移の場合 【修正モード】
		Form1.hdnKBN.value = "2";
		strRes = confirm("修正登録してよろしいですか？");
	} else if(Form1.hdnBackUrl.value == "MSKOSJAG00" || Form1.hdnBackUrl.value == "KEJUKJAG00"){
		//警報受信パネルからの画面遷移の場合、もしくは顧客検索画面からの画面遷移の場合 【新規モード】	
		Form1.hdnKBN.value = "1";
		strRes = confirm("登録してよろしいですか？");
	}
	if (strRes==false){
		return;
	}
	//オブジェクトのロック処理-----
	fncDispRoc();
	
	//電話発信ログの取得-----------
	var strRec;
	var strRec1;
	var strRec2;
	var strRec3;
	var strMsg = "";
	var strTmp = "";
	// 2017/03/06 T.Ono mod 2016改善開発 №12 START
	// 発信ボタン押下の処理で、実行日時等を取得するため
    // ここではhdnへの格納のみとする。
	//for (i=1; i<=intDialCnt; i++) {
	//	if (strDialResult[i-1] == '1') {
	//		//発信結果が発信処理済（正常終了）だったら
	//		//結果ファイル名にはカウントを付加する
	//		strRec = Form1.Dial.SetResultName(Form1.hdnTELEXERESULT.value + i + ".txt");
	//		//処理結果セット
	//		strRec = Form1.Dial.FncResultSet();
	//		//処理結果ステータスの取得
	//		strRec1 = Form1.Dial.GetResult_YM();	//実行年月日
	//		strRec2 = Form1.Dial.GetResult_TM();	//実行時間
	//		strRec3 = Form1.Dial.GetResult_ST();	//処理結果ステータス
	//		strDialDates[i-1] = strRec1;	//実行年月日を配列に格納
	//		strDialTimes[i-1] = strRec2;	//実行年月日を配列に格納
	//		strDialStates[i-1] = strRec3;	//処理結果ステータスを配列に格納
	//	} else {
	//		strRec1 = "";
	//		strRec2 = "";
	//		strRec3 = "";
	//		strDialDates[i-1] = "";
	//		strDialTimes[i-1] = "";
	//		strDialStates[i-1] = "";
	//	}
	//	//Hiddenに処理結果を格納
	//	Form1.hdnDialKbns.value = strDialKbns;
	//	Form1.hdnDialNumbers.value = strDialNumbers;
	//	Form1.hdnDialAitename.value = strDialAitenm;
	//	Form1.hdnDialResult.value = strDialResult;
	//	Form1.hdnDialDates.value =	strDialDates;
	//	Form1.hdnDialTimes.value =	strDialTimes;
	//	Form1.hdnDialStates.value = strDialStates;
	//}
    //Hiddenに処理結果を格納
    Form1.hdnDialKbns.value = strDialKbns;
    Form1.hdnDialNumbers.value = strDialNumbers;
    Form1.hdnDialAitename.value = strDialAitenm;
    Form1.hdnDialResult.value = strDialResult;
    Form1.hdnDialDates.value = strDialDates;
    Form1.hdnDialTimes.value = strDialTimes;
    Form1.hdnDialStates.value = strDialStates;
    // 2017/03/06 T.Ono mod 2016改善開発 №12 END
    // 2019/11/01 w.ganeko 2016改善開発 №9-12 start
    Form1.rdoMsg1.disabled = false;
    Form1.rdoMsg2.disabled = false;
    Form1.rdoMsg3.disabled = false;
    Form1.rdoMsg4.disabled = false;
    Form1.rdoMsg5.disabled = false;
    Form1.rdoMsg6.disabled = false;
    // 2019/11/01 w.ganeko 2016改善開発 №9-12 end
    //2014/12/22 T.Ono add 2014改善開発 No4
    //登録したら、FAX・メール送信フラグを戻す
    Form1.hdnSEND_FAX_FLG.value = '0';    

	//登録系フレームワーク
	doPostBack('btnUpdate','');
}
//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
	var strRes;

	//2014/12/22 T.Ono add 2014改善開発 No4
    //FAX・メールを送信している場合は、必ず登録させる
	if (Form1.hdnSEND_FAX_FLG.value == '1') {
	    alert('登録を行ってください。');
	    Form1.btnUpdate.focus();
	    return;
	}
    strRes = confirm("終了してよろしいですか？");
	if (strRes==false){
		return;
	}

	doPostBack('btnExit',''); 
}
//**************************************
//ウィンドウクローズ 2005.05.19 ADD FALCON
//**************************************
function fncWindow_close() {
	parent.window_close();
}
//**************************************
//終了処理
//**************************************
function fncExit() {
	doPostBack('btnExit',''); 
}
//**************************************
//印刷押下
//**************************************
function btnPrint_onclick() {
	window.print();
}
//**************************************
//対応履歴照会ボタン押下時の処理
//**************************************
function btnRireki_onclick() {
	fncPop('KETAIJRG00');
}
//**************************************
//連絡先選択・もしくは電話発信ボタンの処理
//**************************************
//--- ↓2005/09/07 MOD Falcon↓ ---
function btnRenraku_onclick(strMODE) {
//function btnRenraku_onclick() {
	if (strMODE == '1'){
	//if (Form1.btnRenraku.value=="電話発信") {
		//ボタンのVALUEが'電話発信'の場合電話発信を行う	
		var strAite;
		strAite = Form1.txtSTD.value + "/" + Form1.txtSTD_KYOTEN.value
		btnDial_onclick("2",Form1.txtSTD_TEL.value,strAite);
    } else if (strMODE == '2') {
		//alert(Form1.hdnREN_STD_JASCD.value + ":" + Form1.hdnREN_STD_JANA.value + ":" + Form1.hdnREN_STD_JASNA.value);
		//--- ↓2005/05/19 ADD Falcon↓ ---
		//<TODO> 入力値チェック
		//クライアントコード
		if(Form1.txtClientCD.value=="") {
			alert('クライアントコードは必須です');
			Form1.btnKURACD.focus();
			return false;
		}
		//ＪＡ支所名
		// 2013/07/25 T.Ono mod
        //if(Form1.hdnJASCD.value=="") {
        if((Form1.hdnJASCD.value=="") ||  (Form1.hdnJASCD.value==" ")){
            alert('ＪＡ支所名は必須です');
            Form1.btnJASCD.focus();
            return false;
        }
        //--- ↑2005/05/19 ADD Falcon↑ ---

        //2016/12/09 H.Mori add 2016改善開発 No4-5
        //警報メッセージ選択ボタンチェック
        if (Form1.rdoMsg2.checked && (Form1.txtKMNM2.value == "" || Form1.txtKMNM2.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(2)');
            return false;
        } else if (Form1.rdoMsg3.checked && (Form1.txtKMNM3.value == "" || Form1.txtKMNM3.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(3)');
            return false;
        } else if (Form1.rdoMsg4.checked && (Form1.txtKMNM4.value == "" || Form1.txtKMNM4.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(4)');
            return false;
        } else if (Form1.rdoMsg5.checked && (Form1.txtKMNM5.value == "" || Form1.txtKMNM5.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(5)');
            return false;
        } else if (Form1.rdoMsg6.checked && (Form1.txtKMNM6.value == "" || Form1.txtKMNM6.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(6)');
            return false;
        }

        //2020/03/11 T.Ono add 2019監視改善
        //ラジオボタンがdisableだと、Form送信時、値が送信されないのでhdnに格納する
        for (var i = 0; i < Form1.rdoMsg.length - 1; i++) {
            if (Form1.rdoMsg[i].checked) {
                Form1.hdnrdoMsg.value = Form1.rdoMsg[i].value
            }
        }

        //2013/10/25 T.Ono 監視改善№1
        fnc_byteCheck1(Form1.txtTEL_MEMO, 100);

        fncPop('KETAIJTG00');
    //2016/02/02 w.ganeko 2015監視開発改善 №1-3 start
    } else if (strMODE == '3') {
        //クライアントコード
        if (Form1.txtClientCD.value == "") {
            alert('クライアントコードは必須です');
            Form1.btnKURACD.focus();
            return false;
        }
        //ＪＡ支所名
        // 2013/07/25 T.Ono mod
        //if(Form1.hdnJASCD.value=="") {
        if ((Form1.hdnJASCD.value == "") || (Form1.hdnJASCD.value == " ")) {
            alert('ＪＡ支所名は必須です');
            Form1.btnJASCD.focus();
            return false;
        }
        if (Form1.txtJUYOKA.value == "") {
            alert('お客様コードは必須です');
            Form1.txtJUYOKA.focus();
            return false;
        }
        //--- ↑2005/05/19 ADD Falcon↑ ---

        fncPop('KETAIJVG00');
        //2016/02/02 w.ganeko 2015監視開発改善 №1-3 end
    }
	//--- ↑2005/09/07 MOD Falcon↑ ---
}
//**************************************
//画面項目をロックする(使用不可)
//**************************************
function fncDispRoc() {
	with(Form1) {
		//イベントを持つオブジェクトに対するロック処理
		btnExit.disabled=true;
		btnTelHas1.disabled=true;
		btnRireki.disabled=true;
		btnUpdate.disabled=true;
		btnRenraku.disabled=true;
		txtSYOYMD.readOnly=true;
		txtSIJIYMD.readOnly=true;
		btnTel.disabled=true;	//--- 2005/09/07 ADD Falcon ---
		btnTelHas2.disabled = true; //--- 2016/02/02 ADD W.GANEKO ---
   }
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck() {
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
        //クライアントコード
		//if(txtClientCD.value=="") {
	    if ((txtClientCD.value == "") || (txtClientCD.value == " ")) {      //2012/04/18 NEC ou Upd
			alert('クライアントコードは必須です');
			btnKURACD.focus();
			return false;
		}
		//ＪＡ支所名
		//if(hdnJASCD.value=="") {
        if ((hdnJASCD.value == "") || (hdnJASCD.value == " ")) {            //2012/04/18 NEC ou Upd
			alert('ＪＡ支所名は必須です');
			btnJASCD.focus();
			return false;
		}
		//フリガナ半角カナ
		//--- ↓2005/05/19 DEL Falcon↓ ---
		//if (fncZenkakuChk(txtJUSYOKN.value) == true) {
		//	alert("フリガナは半角カナで入力して下さい");
		//	txtJUSYOKN.focus();
		//	return false;
		//}
		//--- ↑2005/05/19 DEL Falcon↑ ---
		//電話番号(市外)
		if (fncNumChk(txtJUTEL1.value) == false) {
			alert("電話番号(市外)は半角数値で入力して下さい");
			txtJUTEL1.focus();
			return false;
		}
		//--- ↓2005.07.08 MOD Falcon↓ ---
		//電話番号(市内)
		//if (fncNumChk(txtJUTEL2.value) == false) {
		//	alert("電話番号(市内)は半角数値で入力して下さい");
		//	txtJUTEL2.focus();
		//	return false;
		//}
		if (fncChkTelIn(txtJUTEL2.value) == false) {
			alert("電話番号(市内)は正しい電話番号ではありません");
			txtJUTEL2.focus();
			return false;
		}
		//--- ↑2005.07.08 MOD Falcon↑ ---
		//住所(レングスチェック)
		if(fncGetByte(txtADDR.value) > 120) {
			alert("住所は全角60文字以内で入力して下さい");
			txtADDR.focus();
			return false;
		}
		//連絡先
        // 20221130 MOD START Y.ARAKAKI 2022更改No③ 検索時のハイフンチェック削除対応 --独自から本来の呼出に戻す修正。
        //2021/10/01 2021年度監視改善⑦電話番号14ケタ化で、受信パネルでハイフン1つをOKとする ハイフン0～2までOKロジックを共通ではなくこのJSの一番下に作成
		if (fncChkTel(txtRENTEL.value) == false) {
        //if (fncChkTel14(txtRENTEL.value) == false) {
			alert("連絡先は正しい電話番号ではありません");
			txtRENTEL.focus();
			return false;
        }
        // 20221130 MOD END   Y.ARAKAKI 2022更改No③ 検索時のハイフンチェック削除対応 --独自から本来の呼出に戻す修正。

		//対応区分
		if(cboTAIOKBN.value=="") {
			alert('対応区分は必須です');
			cboTAIOKBN.focus();
			return false;
		}
		//処理区分
		if(cboTAIOKBN.value=="3") {			//対応区分が[重複]の時処理区分は[2:処理済み]
			if(cboTMSKB.value!="2") {
				alert('対応区分が重複の場合、処理区分は処理済みのみ選択可能です');
				cboTMSKB.focus();
				return false;
			}
		}		
		if(cboTAIOKBN.value!="3") {			//対応区分が[重複]以外の時のみ必須チェック
			if(cboTMSKB.value=="") {
				alert('処理区分は必須です');
				cboTMSKB.focus();
				return false;
			}
		}
		//監視センター担当者の必須チェック
		//if(txtTKTANCD.value=="") {
        if ((txtTKTANCD.value == "") || (txtTKTANCD.value == " ")) {        //2012/04/18 NEC ou Upd
			alert('監視センター担当者は必須です');
			btnTKTANCD.focus();
			return false;
		}
		
		//--- ↓2005/05/19 DEL Falcon↓ ---
		//連絡相手
		//if(cboTAIOKBN.value!="3") {			//対応区分が[重複]以外の時のみ必須チェック
		//	if(cboTAITCD.value=="") {
		//		alert('連絡相手は必須です');
		//		cboTAITCD.focus();
		//		return false;
		//	}
		//}
		//--- ↑2005/05/19 DEL Falcon↑ ---
		
		//2016/12/05 H.Mori add 2016改善開発　No4-2 START 
        //電話連絡内容の必須チェック
        //if ((cboTELRCD.value == "") || (cboTELRCD.value == " ")) {        //2012/04/18 NEC ou Upd    
        //    alert('電話連絡内容は必須です');
        //    cboTELRCD.focus();
        //    return false;
        //}
        //2016/12/05 H.Mori add 2016改善開発　No4-2 END

        //対応完了日：日付チェック
		if(fncChkDate(txtSYOYMD.value) == false) {
			alert('対応完了日は正しい日付ではありません');
			txtSYOYMD.focus();
			return false;
		}
		//対応完了時刻：時間チェック
		if(txtSYOTIME.value.length != '') {
			if(fncChkTime(txtSYOTIME.value) == false) {
				alert('対応完了時刻は時刻を入力してください');
				txtSYOTIME.focus();
				return false;
			}
		}
		//対応完了日・時刻
		if (((txtSYOYMD.value.length  > 0) && (txtSYOTIME.value.length == 0)) ||
		    ((txtSYOYMD.value.length == 0) && (txtSYOTIME.value.length  > 0))) {
				alert('対応完了日・対応完了時刻は両方入力してください');
				if (txtSYOYMD.value.length == 0) {
					txtSYOYMD.focus();
				} else {
					txtSYOTIME.focus();
				}
				return false;
		}
		//処理区分が[2:処理済み]の場合、対応完了日・時刻は必須
		if (cboTMSKB.value=="2") {
			if (txtSYOYMD.value=="") {
				alert('処理区分が処理済みの場合、対応完了日は必須です');
				txtSYOYMD.focus();
				return false;
			}
		}
		//指示日：日付チェック
		if(fncChkDate(txtSIJIYMD.value) == false) {
			alert('指示日は正しい日付ではありません');
			txtSIJIYMD.focus();
			return false;
		}
		//時刻：時刻チェック
		if(txtSIJITIME.value.length != '') {
			if(fncChkTime(txtSIJITIME.value) == false) {
				alert('指示時刻は時刻を入力してください');
				txtSIJITIME.focus();
				return false;
			}
		}
		//指示・時間
		if (((txtSIJIYMD.value.length  > 0) && (txtSIJITIME.value.length == 0)) ||
		    ((txtSIJIYMD.value.length == 0) && (txtSIJITIME.value.length  > 0))) {
				alert('指示日・指示時刻は両方入力してください');
				if (txtSIJIYMD.value.length == 0) {
					txtSIJIYMD.focus();
				} else {
					txtSIJITIME.focus();
				}
				return false;
		}
		//対応区分が[2:出動指示]の場合、指示日・時刻は必須
		if (cboTAIOKBN.value=="2") {
			if (txtSIJIYMD.value=="") {
				alert('対応区分が出動指示の場合、指示日は必須です');
				txtSIJIYMD.focus();
				return false;
			}
		}
		//対応区分が[重複]の時、ＦＡＸ不要にチェック
		if(cboTAIOKBN.value=="3") {			
			if (chkFAXKBN.checked==false) {
				alert('対応区分が重複の場合、ＦＡＸ不要(JA)は必須です');
				chkFAXKBN.focus();
				return false;
			}
		} 
		//対応区分が[重複]の時、ＦＡＸ不要(ｸﾗｲｱﾝﾄ)にチェック 2010/07/12 T.Watabe add
		if(cboTAIOKBN.value=="3") {			
			if (chkFAXKURAKBN.checked == false) {
				alert('対応区分が重複の場合、ＦＡＸ不要(ｸﾗｲﾝﾄ)は必須です');
				chkFAXKURAKBN.focus();
				return false;
			}
		}
        //対応区分が[重複]の時、報告不要(累積)にチェック 2015/12/17 H.Mori add
        if (cboTAIOKBN.value == "3") {
            if (chkFAXRUISEKIKBN.checked == false) {
                alert('対応区分が重複の場合、報告不要(累積)は必須です');
                chkFAXRUISEKIKBN.focus();
                return false;
            }
        } 
		// 2008/10/29 T.Watabe del NCU発生日時は、NCU日時が狂っている場合もあるのでチェックしない。
		// 発生日時 ' 2008/10/15 T.Watabe add
		//if(txtNCUHATYMD.value.length <= 0) {
		//	alert('発生日を入力して下さい');
		//	return false;
		//}
		//if(txtNCUHATTIME.value.length <= 0) {
		//	alert('発生時間を入力して下さい');
		//	return false;
		//}
		//if(fncChkDate(txtNCUHATYMD.value) == false) {
		//	alert('発生日は正しい日付ではありません');
		//	return false;
		//}
		//if(fncChkTime(txtNCUHATTIME.value + ":00") == false) {
		//	alert('発生時間は時刻を入力して下さい');
		//	txtNCUHATTIME.focus();
		//	return false;
		//}
		
		// 受信日時 2007/04/25 T.Watabe add
		if(txtHATYMD.value.length <= 0) {
			alert('受信日を入力して下さい');
			return false;
		}
		if(txtHATTIME.value.length <= 0) {
			alert('受信時間を入力して下さい');
			return false;
		}
		if(fncChkDate(txtHATYMD.value) == false) {
			alert('受信日は正しい日付ではありません');
			return false;
		}
		if(fncChkTime(txtHATTIME.value + ":00") == false) {
			alert('受信時間は時刻を入力して下さい');
			txtHATTIME.focus();
			return false;
		}
		
		// 発生区分 2007/04/25 T.Watabe add
        //if(hdnHATKBN.value.length <= 0) {
        if ((txtHATKBN.value == "") || (txtHATKBN.value == " ")) {          //2012/04/18 NEC ou Upd
			alert('発生区分を選択して下さい');
			return false;
		}
		
		// 2008/10/29 T.Watabe del NCU発生日時は、NCU日時が狂っている場合もあるのでチェックしない。
		//// 発生日時と受信日時の前後関係チェック 2008/10/15 T.Watabe add
		//var ncuhat1 = txtNCUHATYMD.value + "_" + txtNCUHATTIME.value + ":00";
		//var hat1 = txtHATYMD.value + "_" + txtHATTIME.value + ":00";
		//if(ncuhat1 > hat1) {
		//	alert('発生日時と受信日時の前後関係を確認して下さい。');
		//	return false;
		//}

        // 20221202 MOD START Y.ARAKAKI 2022更改No② 依頼日時と対応完了日時の前後関係チェック追加対応
        // ↓既存チェックについて、共通項目を利用しているため、変数位置を移動して共通利用できるように加工する。
        // 併せて、今回のチェック用フラグ（入力有無チェック）を追加し、2度同じチェックをしないよう工夫する。
		//if ((txtSYOYMD.value + txtSYOTIME.value).length > 0) {
			
		//	// 受信日時と対応完了日時の前後関係チェック 2007/05/09 T.Watabe add
		//	var hat = txtHATYMD.value + "_" + txtHATTIME.value + ":00";
		//	var kan = txtSYOYMD.value + "_" + txtSYOTIME.value;
		//	if(hat > kan) {
		//		// 2012/03/23 W.GANEKO MOD メッセージ出力内容変更
		//		//alert('発生日時と対応完了日時の前後関係を確認して下さい。');
		//		alert('受信日時と対応完了日時の前後関係を確認して下さい。');
		//		return false;
		//	}
		//}

  //      // 受信日時と依頼日時の前後関係チェック 2014/12/09 T.Ono add 2014改善開発 №2
  //      if ((txtSIJIYMD.value + txtSIJITIME.value).length > 0) {
  //          var hat = txtHATYMD.value + "_" + txtHATTIME.value + ":00";
  //          var siji = txtSIJIYMD.value + "_" + txtSIJITIME.value;
  //          if (hat > siji) {
  //              alert('受信日時と出動依頼日時の前後関係を確認して下さい。');
  //              return false;
  //          }
  //      }

        // 比較用値の用意
        var hat = txtHATYMD.value + "_" + txtHATTIME.value + ":00"; // 受信日時
        var kan = txtSYOYMD.value + "_" + txtSYOTIME.value;         // 対応完了日時
        var siji = txtSIJIYMD.value + "_" + txtSIJITIME.value;      // 依頼日時
        var umuFlg_TaioKanryoYmdTime = false; //有無フラグ_対応完了日時  (初期値：無)
        var umuFlg_ShutudoIraiYmdTime = false; //有無フラグ_出動依頼日時 (初期値：無)

        // 既存処理の記載を簡略化 （処理内容自体に変更はありません。）
        // 相互間チェック_受信日時-対応完了日時　間  追加時期→// 受信日時と対応完了日時の前後関係チェック 2007/05/09 T.Watabe add
        if ((txtSYOYMD.value + txtSYOTIME.value).length > 0) {
            umuFlg_TaioKanryoYmdTime = true; //対応完了日時_有無＝有
            if (hat > kan) {
                alert('受信日時と対応完了日時の前後関係を確認して下さい。');
                return false;
            }
        }
        // 相互間チェック_受信日時-出動依頼日時　間  追加時期→// 受信日時と依頼日時の前後関係チェック 2014/12/09 T.Ono add 2014改善開発 №2
        if ((txtSIJIYMD.value + txtSIJITIME.value).length > 0) {
            umuFlg_ShutudoIraiYmdTime = true; //出動依頼日時_有無＝有
            if (hat > siji) {
                alert('受信日時と出動依頼日時の前後関係を確認して下さい。');
                return false;
            }
        }
        // 今回（2022/12/02）新規追加
        // 相互間チェック_対応完了日時-出動依頼日時　間 
        if (umuFlg_TaioKanryoYmdTime && umuFlg_ShutudoIraiYmdTime) { //出動依頼日時と対応完了日時、両方入力ある場合のみチェック実施。
            if (siji > kan) {
                alert('対応完了日時は出動依頼日時より後の日時を入力してください。');
                return false;
            }
        }
        // 20221202 MOD END   Y.ARAKAKI 2022更改No② 依頼日時と対応完了日時の前後関係チェック追加対応

        //2013/08/20 T.Ono add 監視改善2013№1
        //警報メッセージ選択ボタンチェック
        if (rdoMsg2.checked && (txtKMNM2.value == "" || txtKMNM2.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(2)');
            return false;
        } else if (rdoMsg3.checked && (txtKMNM3.value == "" || txtKMNM3.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(3)');
            return false;
        } else if (rdoMsg4.checked && (txtKMNM4.value == "" || txtKMNM4.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(4)');
            return false;
        } else if (rdoMsg5.checked && (txtKMNM5.value == "" || txtKMNM5.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(5)');
            return false;
        } else if (rdoMsg6.checked && (txtKMNM6.value == "" || txtKMNM6.value == " ： ")) {
            alert('警報メッセージが正しく選択されていません(6)');
            return false;
        }
        //2019/11/01 w.ganeko 2019監視改善 No9-12 start
        //2020/03/11 T.Ono add 監視改善2019 １電話対応で、１未処理／３処理中の場合も必須としない
        //if (cboTAIOKBN.value != "3") {
        if ((cboTAIOKBN.value == "2") || (cboTAIOKBN.value == "1" && cboTMSKB.value == "2")) {
             //連絡相手
            if (cboTAITCD.value == "" || cboTAITCD.value == " ") {
                alert('連絡相手は必須です');
                cboTAITCD.focus();
                return false;
            }
            //電話連絡内容
            if (cboTELRCD.value == "" || (cboTELRCD.value == " ")) {
                alert('電話連絡内容は必須です');
                cboTELRCD.focus();
                return false;
            }
            //復帰対応状況
            if (cboTFKICD.value == "" || cboTFKICD.value == " ") {
                alert('復帰対応状況は必須です');
                cboTFKICD.focus();
                return false;
            }
            //原因器具
            if (cboTKIGCD.value == "" || cboTKIGCD.value == " ") {
                alert('原因器具は必須です');
                cboTKIGCD.focus();
                return false;
            }
            //作動原因
            if (cboTSADCD.value == "" || cboTSADCD.value == " ") {
                alert('作動原因は必須です');
                cboTSADCD.focus();
                return false;
            }
        }
        //2019/11/01 w.ganeko 2019監視改善 No9-12 end

        //2013/10/25 T.Ono 監視改善№1
        if (fnc_byteCheck1(txtTEL_MEMO, 100) == false) {
            return false;
        }

        //2021/01/05 T.Ono 2020監視改善
        if (fnc_byteCheck2(txtGENIN_KIJI, 300) == false) {
            return false;
        }

    }
	return true;
}
//**************************************
//電話発信ボタン押下時の処理
//**************************************
var intDialCnt = 0;
var strDialKbns    = new Array();
var strDialNumbers = new Array();
var strDialAitenm  = new Array();
var strDialResult  = new Array();
var strDialDates   = new Array();
var strDialTimes   = new Array();
var strDialStates = new Array();
var listcboTFKICD = new Array();        //「復帰対応状況」
var listcboTKIGCD = new Array();        //「原因器具」  //2022/08/05 ADD Y.Arakaki2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
var listcboTSADCD1 = new Array();        //2020/11/01 T.Ono 監視改善2020
var listcboTSADCD2 = new Array();        //2020/11/01 T.Ono 監視改善2020
var listcboTSADCD3 = new Array();        //2020/11/01 T.Ono 監視改善2020
var listcboTSADCD4 = new Array();        //2020/11/01 T.Ono 監視改善2020
var listcboTSADCD5 = new Array();        //2020/11/01 T.Ono 監視改善2020
var listcboTSADCD6 = new Array();        //2020/11/01 T.Ono 監視改善2020
var listcboTSADCD0 = new Array();        //2020/11/01 T.Ono 監視改善2020
//var listcboTKIGCD1 = new Array();        //2021/10/01 2021年度改善②saka だが、原因器具の警報だけでの制御は改善しないとなったのでロジックを残し戻す
//var listcboTKIGCD2 = new Array();        //2021/10/01
//var listcboTKIGCD3 = new Array();        //2021/10/01
//var listcboTKIGCD4 = new Array();        //2021/10/01
//var listcboTKIGCD5 = new Array();        //2021/10/01
//var listcboTKIGCD6 = new Array();        //2021/10/01
//var listcboTKIGCD0 = new Array();        //2021/10/01

//2022/07/29 ADD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
//vbで検索した除外全項目保持リスト
var listRemoveCheckTFKICD = new Array();        //項目除外リスト（復帰対応状況用）
var listRemoveCheckTKIGCD = new Array();        //項目除外リスト（原因器具）

//2023/01/18 DEL Y.ARAKAKI 2022更改No8_追加対応  プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。
//var listViewCheckTSADCD = new Array();        //項目表示リスト（作動原因） ※１．全項目から、表示させたいNoだけ管理
var listRemoveCheckTSADCD = new Array();        //項目除外リスト（作動原因） ※２．上記を考慮後、さらに表示から消したいNo(表示リストより除外強い)を管理

//2022/07/29 ADD END Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

//2022/12/08 ADD START Y.ARAKAKI 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応
var listKeihouJidouSentakuCD = new Array();        //特定警報メッセージNo選択時の自動選択リスト（画面の複数項目が自動選択対象）
//2022/12/08 ADD END   Y.ARAKAKI 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応

var flgKeihoMsgCopy = 0;                 //2020/11/01 T.Ono 監視改善2020 警報を変えたら'1'にする
//2017/02/27 T.Ono mod 見えTELくんﾊﾞｰｼﾞｮﾝｱｯﾌﾟ電話発信方式変更
//function btnDial_onclick(strFlg,strTelParam,strAitenm) {
//	var strRec;
//	if((strFlg == "1") || (strFlg == "2")) {
//		//ポップアップ協力員での電話発信でも使用する為制御する
//		strRes = confirm("電話発信してよろしいですか？");
//		if (strRes==false){
//			if(strFlg == "1") {
//				Form1.cboTAIOKBN.focus();
//			}else {
//				Form1.txtSIJIYMD.focus();	
//			}
//			return;
//		}
//	}
//	var strTelNo;
//	var strTelCk;	//--- 2005/05/19 ADD Falcon

//	intDialCnt += 1;
//	//初期情報のセット--------------------------------------------
//	strRec = Form1.Dial.SetExePath(Form1.hdnTELEXEPATH.value);
//	strRec = Form1.Dial.SetExeName(Form1.hdnTELEXENAME.value);
//	strRec = Form1.Dial.SetInitAtCommand(Form1.hdnATCOMMAND.value);
//	//ＷＡＩＴフラグをセット(デフォルト：NoWait　1:Wait 2:NoWait)
//	strRec = Form1.Dial.SetWaitFlag(Form1.hdnTELWAITFLG.value);
//	//パルストーン信号をセット(P:パルス T:トーン)
//	strRec = Form1.Dial.SetPlstFlag(Form1.hdnTELPLSTORN.value);
//	//電話番号頭文字をセット
//	strRec = Form1.Dial.SetHdValue(Form1.hdnTELHEAD.value);
//	if(strFlg == "1") {
//		//--- ↓2005/05/19 ADD Falcon↓ ---
//		//連絡先電話番号が未入力の場合電話番号市外＋市内で電話発信を行う
//		if(strTelParam.length==0) {
//			strTelParam = (Form1.txtJUTEL1.value + Form1.txtJUTEL2.value).replace(/-/, "");
//			strTelCk = 'TEL';
//		}
//		//--- ↑2005/05/19 ADD Falcon↑ ---
//		//受信情報の電話発信ボタンだったら
//		if(strTelParam.length==0) {
//			//需要家電話番号の存在チェック
//			alert('連絡先の電話番号がありません');
//			//Form1.cboTAIOKBN.focus();		//--- 2005/05/19 DEL Falcon
//			Form1.txtRENTEL.focus();		//--- 2005/05/19 MOD Falcon
//			return;
//		}
//		strTelNo = strTelParam;
//		//電話番号チェック
//		if (fncChkTel(strTelNo) == false) {
//			alert("電話番号が正しくありません");
//			//--- ↓2005/05/19 ADD Falcon↓ ---
//			if (strTelCk == "TEL") {
//				Form1.txtJUTEL1.focus();		
//			} else {
//				//Form1.cboTAIOKBN.focus();		//--- 2005/05/19 DEL Falcon
//				Form1.txtRENTEL.focus();		//--- 2005/05/19 MOD Falcon
//			}
//			//--- ↑2005/05/19 ADD Falcon↑ ---
//			return;
//		}
//		strDialKbns[intDialCnt-1] = 1;			//需要家電話番号
//	} else if(strFlg == "2") {
//		//受信情報の電話発信ボタンだったら
//		if(strTelParam.length==0) {
//			//出動会社電話番号の存在チェック
//			alert('出動会社の電話番号がありません');
//			Form1.txtSTD_TEL.focus();	
//			return;
//		}
//		strTelNo = strTelParam;
//		//電話番号チェック
//		if (fncChkTel(strTelNo) == false) {
//			alert("電話番号が正しくありません");
//			Form1.txtSTD_TEL.focus();
//			return;
//		}
//		strDialKbns[intDialCnt-1] = 2;			//出動会社電話番号
//   } else if (strFlg == "4") {
//        //電話番号選択から電話時は需要家電話番号で登録
//        strTelNo = strTelParam;
//        strDialKbns[intDialCnt - 1] = 1; 		//需要家電話番号
//    } else {
//		//連絡先の電話発信ボタンの場合（既に電話番号はチェック済み)
//		strTelNo = strTelParam;
//		strDialKbns[intDialCnt-1] = 3;	//連絡先に電話	
//	}
//	//電話番号をセット
//　　strRec = Form1.Dial.SetCallPhoneNumber(strTelNo);
//	//-----------------------------------------------------------
//	//結果ファイル名にはカウントを付加する
//　　strRec = Form1.Dial.SetResultName(Form1.hdnTELEXERESULT.value + intDialCnt + ".txt");
//	//電話発信開始
//　　strRec = Form1.Dial.FncCallPhone();
//	//プロセス実行ステータス取得
//　　strRec = Form1.Dial.GetStatus();
//	//alert(strRec + '\n__０：未発信\n__１：発信処理済み\n__２：実行中\n__９：発信処理プロセス実行エラー');
//	strDialNumbers[intDialCnt-1] = strTelNo;
//	strDialAitenm[intDialCnt-1] = strAitenm;
//	strDialResult[intDialCnt-1] = strRec;
//	if(strFlg == "1") {
//		Form1.cboTAIOKBN.focus();
//	}else {
//		Form1.txtSIJIYMD.focus();
//	}
//}
function btnDial_onclick(strFlg, strTelParam, strAitenm) {
    var strRec = "0";
    if ((strFlg == "1") || (strFlg == "2")) {
        //ポップアップ協力員での電話発信でも使用する為制御する
        strRes = confirm("電話発信してよろしいですか？");
        if (strRes == false) {
            if (strFlg == "1") {
                Form1.cboTAIOKBN.focus();
            } else {
                Form1.txtSIJIYMD.focus();
            }
            return;
        }
    }
    var strTelNo;
    var strTelCk;

    intDialCnt += 1;
    if (strFlg == "1") {
        //連絡先電話番号が未入力の場合電話番号市外＋市内で電話発信を行う
        if (strTelParam.length == 0) {
            strTelParam = (Form1.txtJUTEL1.value + Form1.txtJUTEL2.value).replace(/-/, "");
            strTelCk = 'TEL';
        }
        //受信情報の電話発信ボタンだったら
        if (strTelParam.length == 0) {
            //需要家電話番号の存在チェック
            alert('連絡先の電話番号がありません');
            Form1.txtRENTEL.focus();
            return;
        }
        strTelNo = strTelParam;
        //電話番号チェック
        // 20221130 MOD START Y.ARAKAKI 2022更改No③ 検索時のハイフンチェック削除対応 --独自から本来の呼出に戻す修正。
        //2021/10/01 '2021年度監視改善⑦TEL番14ケタ化で、受信パネルから表示される電話番号発信時にハイフン1つのためここだけ対応
        if (fncChkTel(strTelNo) == false) {  
        //if (fncChkTel14(strTelNo) == false) {
            alert("電話番号が正しくありません");
            if (strTelCk == "TEL") {
                Form1.txtJUTEL1.focus();
            } else {
                Form1.txtRENTEL.focus();
            }
            return;
        }
        // 20221130 MOD END   Y.ARAKAKI 2022更改No③ 検索時のハイフンチェック削除対応 --独自から本来の呼出に戻す修正。
        strDialKbns[intDialCnt - 1] = 1; 		//需要家電話番号
    } else if (strFlg == "2") {
        //受信情報の電話発信ボタンだったら
        if (strTelParam.length == 0) {
            //出動会社電話番号の存在チェック
            alert('出動会社の電話番号がありません');
            Form1.txtSTD_TEL.focus();
            return;
        }
        strTelNo = strTelParam;
        //電話番号チェック
        if (fncChkTel(strTelNo) == false) {
            alert("電話番号が正しくありません");
            Form1.txtSTD_TEL.focus();
            return;
        }
        strDialKbns[intDialCnt - 1] = 2; 		//出動会社電話番号
    } else if (strFlg == "4") {
        //電話番号選択から電話時は需要家電話番号で登録
        strTelNo = strTelParam;
        strDialKbns[intDialCnt - 1] = 1; 		//需要家電話番号
    } else {
        //連絡先の電話発信ボタンの場合（既に電話番号はチェック済み)
        strTelNo = strTelParam;
        strDialKbns[intDialCnt - 1] = 3; //連絡先に電話	
    }

    //電話発信処理
    try {
        var sh = new ActiveXObject("WScript.Shell");
        var res = sh.run('D:/KANSI/DIAL/call.vbs "' + strTelNo + '" "' + strAitenm + '"', 0, true); //trueはvbsの処理結果を返してもらう。falseは返さない。結果は0固定。
        //var res = sh.run('D:/KANSI/DIAL/call.vbs "' + strTelNo + '" "' + strAitenm ); //trueはvbsの処理結果を返してもらう。falseは返さない。結果は0固定。

        if (res == "0") {
            //正常
            strRec = "1";
        } else {
            strRec = "9";
            alert("電話発信に失敗しました\n" + res);
        }
    } catch (e) {
        strRec = "9";
        alert("電話発信に失敗しました" + e.ToString);
    }

    //開放
    sh = null;

    //発信時刻を取得
    var currentDate = new Date();
    var strhours = currentDate.getHours();
    var strminutes = currentDate.getMinutes();
    var strseconds = currentDate.getSeconds();
    var strtime = (('' + strhours).length < 2 ? '0' : '') + strhours + (('' + strminutes).length < 2 ? '0' : '') + strminutes + (('' + strseconds).length < 2 ? '0' : '') + strseconds;

    //alert("strymd:" + fncGetNowDate(0) + " strtime:" + strtime);

    //S04_TELLLOGDB登録情報
    strDialNumbers[intDialCnt - 1] = strTelNo;
    strDialAitenm[intDialCnt - 1] = strAitenm;
    strDialResult[intDialCnt - 1] = strRec;
    strDialDates[intDialCnt - 1] = fncGetNowDate(0);　//発信日付
    strDialTimes[intDialCnt - 1] = strtime;　//発信時刻


    if (strFlg == "1") {
        Form1.cboTAIOKBN.focus();
    } else {
        Form1.txtSIJIYMD.focus();
    }
}
//**************************************
//サーバー日付をテキストボックスに転記
//**************************************
function fncNowDate(Obj) {
	//フォーカス処理
	if (Obj.readOnly == false) {
		if((Obj.id == 'txtSYOYMD') || (Obj.id == 'txtSIJIYMD')) {
			fncFo_date(Obj,2);
		}else {
			fncFo_time(Obj,2);
		}
		with(Form1) {
			if (Obj.id == 'txtSYOYMD') {
				if ((txtSYOYMD.value.length > 0) && (txtSYOTIME.value.length > 0)) {
					//データが入力されている場合は、自動表示しない
					return;
				}else if (cboTMSKB.value != "2") {
					//処理区分が[処理済み]でない場合は、自動表示をしない
					return;
				}
				//対応完了日対象として実行
				doSubmit("KETAIJKG00_TKN");
			} else {
				if ((txtSIJIYMD.value.length > 0) && (txtSIJITIME.value.length > 0)) {
					//データが入力されている場合は、自動表示しない				
					return;
				}else if (cboTAIOKBN.value != "2") {
					//対応区分が[出動指示]でない場合は、自動表示をしない
					return;
				}
				//出動指示日対象として実行
				doSubmit("KETAIJKG00_SSJ");
			}
		}
	}
}
//**************************************
//検索補助ボタン押下
//**************************************
function btnPopup_onclick(strFlg) {
	if ((strFlg == "1" || strFlg == "2" || strFlg == "3")) {
		if ((strFlg == "2" || strFlg == "3") && Form1.txtClientCD.value.length == 0) {
			alert("クライアントコードを選択してください");
			Form1.btnKURACD.focus();
		} else {
			Form1.hdnPopcrtl.value = strFlg;
			fncPop('COPOPUPG00');
		}
	}else{
		// 2007/04/18 T.Watabe add
		// 警報メッセージ１～６プルダウン		
		Form1.hdnPopcrtl.value = strFlg;
		fncPop('COPOPUPG00');
	}
}
//**************************************
//
//**************************************
function fncSyutudouIni() {
	with(Form1) {
		//県を初期化する	
		txtKENNM.value='';
		//ＪＡ支所が初期化されるので関連する出動会社情報を初期化する	
		hdnSTD_CD.value='';
		txtSTD.value='';
		hdnSTD_KYOTEN_CD.value='';
		txtSTD_KYOTEN.value='';
		txtSTD_TEL.value='';
		//btnRenraku.value='連絡先選択';	'2005/09/07 DEL Falcon
		hdnREN_STD_JASCD.value='';
		hdnREN_STD_JANA.value='';
		hdnREN_STD_JASNA.value='';
		hdnREN_0_TANCD.value='';
		hdnREN_0_NA.value='';
		hdnREN_0_TEL1.value='';
		hdnREN_0_TEL2.value = '';
		hdnREN_0_TEL3.value = '';	//2013/12/10 T.Ono add 監視改善2013
		hdnREN_0_FAX.value='';
		hdnREN_0_BIKO.value='';
		hdnREN_1_TANCD.value='';
		hdnREN_1_NA.value='';
		hdnREN_1_TEL1.value='';
		hdnREN_1_TEL2.value = '';
		hdnREN_1_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_1_FAX.value='';
		hdnREN_1_BIKO.value='';
		hdnREN_2_TANCD.value='';
		hdnREN_2_NA.value='';
		hdnREN_2_TEL1.value='';
		hdnREN_2_TEL2.value = '';
		hdnREN_2_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_2_FAX.value='';
		hdnREN_2_BIKO.value='';
		hdnREN_3_TANCD.value='';
		hdnREN_3_NA.value='';
		hdnREN_3_TEL1.value='';
		hdnREN_3_TEL2.value = '';
		hdnREN_3_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_3_FAX.value='';
		hdnREN_3_BIKO.value='';
		
		/* 2008/11/04 T.Watabe add */
		hdnREN_4_TANCD.value='';
		hdnREN_4_NA.value='';
		hdnREN_4_TEL1.value='';
		hdnREN_4_TEL2.value = '';
		hdnREN_4_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_4_FAX.value='';
		hdnREN_4_BIKO.value='';
		hdnREN_5_TANCD.value='';
		hdnREN_5_NA.value='';
		hdnREN_5_TEL1.value='';
		hdnREN_5_TEL2.value = '';
		hdnREN_5_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_5_FAX.value='';
		hdnREN_5_BIKO.value='';
		hdnREN_6_TANCD.value='';
		hdnREN_6_NA.value='';
		hdnREN_6_TEL1.value='';
		hdnREN_6_TEL2.value = '';
		hdnREN_6_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_6_FAX.value='';
		hdnREN_6_BIKO.value='';
		hdnREN_7_TANCD.value='';
		hdnREN_7_NA.value='';
		hdnREN_7_TEL1.value='';
		hdnREN_7_TEL2.value = '';
		hdnREN_7_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_7_FAX.value='';
		hdnREN_7_BIKO.value='';
		hdnREN_8_TANCD.value='';
		hdnREN_8_NA.value='';
		hdnREN_8_TEL1.value='';
		hdnREN_8_TEL2.value = '';
		hdnREN_8_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_8_FAX.value='';
		hdnREN_8_BIKO.value='';
		hdnREN_9_TANCD.value='';
		hdnREN_9_NA.value='';
		hdnREN_9_TEL1.value='';
		hdnREN_9_TEL2.value = '';
		hdnREN_9_TEL3.value = ''; //2013/12/10 T.Ono add 監視改善2013
		hdnREN_9_FAX.value='';
		hdnREN_9_BIKO.value='';
		
		fncChgDispFukusima(); // 2007/04/25 T.Watabe
		
	}
	//クライアントを選択後、県名を取得する
	// ※2011.11.07 コメント追加 h.uema （併せて,FAX不要区分も取得する)
	doSubmit("KETAIJKG00_KEN");	
}
//**************************************
// 出動会社、連絡担当者、販売事業者取得
//**************************************
//2014/12/19 T.Ono mod 2014改善開発 No2 START
//function fncSyutudou() {
//	//ＪＡ支所選択後、そのＪＡ支所に関連する出動会社、もしくは連絡担当者情報を取得する。
//	Form1.btnRenraku.disabled = true;
//	Form1.btnUpdate.disabled = true;
//	doSubmit("KETAIJKG00_REN");
//	//alert(Form1.hdnGuideline.value);
//	//document.getElementById("lblGuideline").innerHTML = Form1.hdnGuideline.value + "&nbsp;";
//	//Form1.hdnGuideline.value='';
//}
function fncSyutudou(Flg) {
    Form1.btnRenraku.disabled = true;
    Form1.btnUpdate.disabled = true;
    if (Flg == 1) {
        //Loadイベント
        doSubmit("KETAIJKG00_REN");
    } else {
        //その他（JA支所選択、お客様コードonBlur）
        doSubmit("KETAIJKG00_REN_AND_HANGRP");
    }
}
//2014/12/19 T.Ono mod 2014改善開発 No2 END
//**************************************
//対応区分が変更されたとき(重複の場合は項目固定値(初期表示))
//**************************************
function fncTAIO_Change() {
	with(Form1) {
        if (cboTAIOKBN.value == "3") {
            cboTMSKB.value = "2";		//処理区分を処理済に変更
            fncTMSKB_Chenge();		//処理区分変更のための制御（日付・時刻は登録前に任意に指定）
            chkFAXKBN.checked = true;		//ＦＡＸ不要にチェック
            chkFAXKURAKBN.checked = true; //ＦＡＸ不要にチェック 2010/07/12 T.Watabe add
            chkFAXRUISEKIKBN.checked = true; //報告不要(累積)にチェック 2010/07/12 T.Watabe add
            cboTAITCD.className = "c-f";
            cboTELRCD.className = "c-f";
            cboTFKICD.className = "c-f";
            cboTKIGCD.className = "c-f";
            cboTSADCD.className = "c-f";
            cboTAITCD.style.backgroundColor = "white";
            cboTELRCD.style.backgroundColor = "white";
            cboTFKICD.style.backgroundColor = "white";
            cboTKIGCD.style.backgroundColor = "white";
            cboTSADCD.style.backgroundColor = "white";
            var blurevent = function () {
                fncFo(this, 1);
            };
            cboTAITCD.onblur = blurevent;
            cboTELRCD.onblur = blurevent;
            cboTFKICD.onblur = blurevent;
            cboTKIGCD.onblur = blurevent;
            cboTSADCD.onblur = blurevent;

        //} else { //2020/03/11 T.Ono add 監視改善2019 START
        } else if (cboTAIOKBN.value == "2") {
            cboTAITCD.className = "cb-h";
            cboTELRCD.className = "cb-h";
            cboTFKICD.className = "cb-h";
            cboTKIGCD.className = "cb-h";
            cboTSADCD.className = "cb-h";
            cboTAITCD.style.backgroundColor = "LightPink";
            cboTELRCD.style.backgroundColor = "LightPink";
            cboTFKICD.style.backgroundColor = "LightPink";
            cboTKIGCD.style.backgroundColor = "LightPink";
            cboTSADCD.style.backgroundColor = "LightPink";
            var blurevent = function () {
                fncFo(this, 3);
            };
            cboTAITCD.onblur = blurevent;
            cboTELRCD.onblur = blurevent;
            cboTFKICD.onblur = blurevent;
            cboTKIGCD.onblur = blurevent;
            cboTSADCD.onblur = blurevent;

        //2020/03/11 T.Ono add 監視改善2019 START
        } else if (cboTAIOKBN.value == "1") {
            if (cboTMSKB.value == "1" || cboTMSKB.value == "3") {
                fncPulldownStyle(2)
            } else {
                fncPulldownStyle(1)
            }
        //2020/03/11 T.Ono add 監視改善2019 END
        }

        //2019/11/01 w.ganeko 2019監視改善 No6 start
        //2022/08/05 MOD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        crtcboTFKICDOption();//「復帰対応状況」リスト編集処理
        crtcboTKIGCDOption();//「原因器具」リスト編集処理
        crtcboTSADCDOption();// 「作動原因」リスト編集処理
        //2022/08/05 MOD END Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

    }
}
//2019/11/01 w.ganeko 2019監視改善 No6 start
//**************************************
//　option作成(復帰対応状況) //2022/08/05 y.arakaki コメント修正  //2019/11/01 w.ganeko 2019監視改善 No6 
//**************************************
function crtcboTFKICDOption() {
    with (Form1) {

        //更新画面表示時、表示値を仮保持
        var selectListValTFKICD = cboTFKICD.value;  // 2022/08/05 ADD Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        
        var options = cboTFKICD.options;
        for (var i = options.length - 1; i > -1; i--) {
            cboTFKICD.remove(i);
        }
        var option = new Option("", "", true);
        cboTFKICD.appendChild(option);

        //2022/08/05 ADD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

        //1電話、2出動、3重複の共通処理：除外オプションを取得する。
        var chkKeihouNo = "";//ラジオ選択された警報メッセージNo
        chkKeihouNo = getKeihouNo(); //警報Noを取得

        var chkRemoveOptionNo = "";//除外オプション（配列）分割前
        chkRemoveOptionNo = editRemoveOption(listRemoveCheckTFKICD, chkKeihouNo, cboTAIOKBN.value);//除外リスト、警報Noと対応区分Noを元に、除外オプションNo一覧を取得

        var remFukkiTaiouList = [];//除外オプション（配列）分割後
        if (fncChkBlunkStr(chkRemoveOptionNo)) {//「空,null,undefined」以外の場合
            remFukkiTaiouList = chkRemoveOptionNo.split(",");//カンマ区切りの1行(xx,yy,zz)を、配列[xx,yy,zz]に加工
        }
        //2022/08/05 ADD END Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

        //2022/08/05 MOD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        if (cboTAIOKBN.value == "1") {  // 対応区分_1:電話対応
            for (var i = 0; i < listcboTFKICD.length; i++) {
                //if (listcboTFKICD[i].flg != undefined && listcboTFKICD[i].flg != null && listcboTFKICD[i].flg != "1") {
                if (listcboTFKICD[i].flg != undefined && listcboTFKICD[i].flg != null && listcboTFKICD[i].flg != "1"
                    && (remFukkiTaiouList.length == 0
                    || remFukkiTaiouList.indexOf(listcboTFKICD[i].val) === -1)  ) { // ===-1 →存在しないこと。 !==-1 →存在すること
                    crtOption(listcboTFKICD[i], cboTFKICD);
                }
            }
        } else if (cboTAIOKBN.value == "2") {  // 対応区分_2:出動依頼
            for (var i = 0; i < listcboTFKICD.length; i++) {
                //if (listcboTFKICD[i].flg != undefined && listcboTFKICD[i].flg != null && listcboTFKICD[i].flg == "1") {
                if (listcboTFKICD[i].flg != undefined && listcboTFKICD[i].flg != null && listcboTFKICD[i].flg == "1"
                    && (remFukkiTaiouList.length == 0
                    || remFukkiTaiouList.indexOf(listcboTFKICD[i].val) === -1)  ) {
                   crtOption(listcboTFKICD[i], cboTFKICD);
               }
            }
        } else if (cboTAIOKBN.value == "3") {  // 対応区分_3:重複
            //3:重複の場合、復帰対応（区分14）の内容１フラグは確認しない。
            for (var i = 0; i < listcboTFKICD.length; i++) {
                if ( remFukkiTaiouList.length == 0
                        || remFukkiTaiouList.indexOf(listcboTFKICD[i].val) === -1) {
                    crtOption(listcboTFKICD[i], cboTFKICD);
                }
            }
        //2022/08/05 MOD END Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        } else { // 対応区分_上記以外（今の想定では空選択）
            for (var i = 0; i < listcboTFKICD.length; i++) {
                crtOption(listcboTFKICD[i], cboTFKICD);
            }
        }
        // 2022/08/05 ADD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
        //編集後、選択状態を復元できる場合は復元する。
        if (fncChkBlunkStr(selectListValTFKICD)) { //リスト選択値が「空,null,undefined」以外の場合
            for (var i = 0; i < cboTFKICD.length; i++) {
                if (cboTFKICD.options[i].value == selectListValTFKICD) { //選択Noと一致する行が存在した場合、選択状態にする。
                    cboTFKICD.options[i].selected = true;
                    break;
                }
            }
        }
        // 2022/08/05 ADD END   Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
    }
}
//2022/08/02 ADD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応
//**************************************
//　option作成(原因器具) 
//**************************************
function crtcboTKIGCDOption() {
    with (Form1) {

        //更新画面表示時、表示値を仮保持
        var selectListValTKIGCD = cboTKIGCD.value; 
        
        //一度、リストを初期化し空にする。
        var options = cboTKIGCD.options;
        for (var i = options.length - 1; i > -1; i--) {
            cboTKIGCD.remove(i);
        }
        //1行目に空項目を設定
        var option = new Option("", "", true);
        cboTKIGCD.appendChild(option);

        //1電話、2出動、3重複の共通処理：除外オプションを取得する。
        var chkKeihouNo = "";//ラジオ選択された警報メッセージNo
        chkKeihouNo = getKeihouNo(); //警報Noを取得

        var chkRemoveOptionNo = "";//除外オプション（配列）分割前
        chkRemoveOptionNo = editRemoveOption(listRemoveCheckTKIGCD,chkKeihouNo, cboTAIOKBN.value);//除外リスト、警報Noと対応区分Noを元に、除外オプションNo一覧を取得
        
        var remGenninKiguList = [];//除外オプション（配列）分割後
        if (fncChkBlunkStr(chkRemoveOptionNo) ) { //「空,null,undefined」以外の場合
            remGenninKiguList = chkRemoveOptionNo.split(",");//カンマ区切りの1行(xx,yy,zz)を、配列[xx,yy,zz]に加工
        }

        //１電話、２出動、3重複の場合、除外項目を除いて原因器具項目を表示。
        if (cboTAIOKBN.value == "1" || cboTAIOKBN.value == "2" || cboTAIOKBN.value == "3") {
            for (var i = 0; i < listcboTKIGCD.length; i++) {
                if (   remGenninKiguList.length == 0
                    || remGenninKiguList.indexOf(listcboTKIGCD[i].val) === -1) { // ===-1 →存在しないこと。 !==-1 →存在すること
                    crtOption(listcboTKIGCD[i], cboTKIGCD);
                }
            }
        } else {
            //上記以外（想定では空選択）の場合、全項目をリスト表示
            for (var i = 0; i < listcboTKIGCD.length; i++) {
                crtOption(listcboTKIGCD[i], cboTKIGCD);
            }
        }

        //編集後、選択状態を復元できる場合は復元する。
        if (fncChkBlunkStr(selectListValTKIGCD)) { //リスト選択値が「空,null,undefined」以外の場合
            for (var i = 0; i < cboTKIGCD.length; i++) {
                if (cboTKIGCD.options[i].value == selectListValTKIGCD) { //選択Noと一致する行が存在した場合、選択状態にする。
                    cboTKIGCD.options[i].selected = true;
                    break;
                }
            }
        }

    }
}
//**************************************
//　option作成(作動原因) 
//**************************************
function crtcboTSADCDOption() {
    with (Form1) {

        //更新画面表示時、表示値を仮保持
        var selectListValTSADCD = cboTSADCD.value;
        
        //一度、リストを初期化し空にする。
        var options = cboTSADCD.options;
        for (var i = options.length - 1; i > -1; i--) {
            cboTSADCD.remove(i);
        }
        //1行目に空項目を設定
        var option = new Option("", "", true);
        cboTSADCD.appendChild(option);

        //1電話、2出動、3重複の共通処理：除外オプションを取得する。
        var chkKeihouNo = "";//ラジオ選択された警報メッセージNo
        chkKeihouNo = getKeihouNo(); //警報Noを取得

        // 2023/01/18 DEL START Y.ARAKAKI 2022更改No8_追加対応 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。
        ////絞り込み表示用リスト
        //var chkViewOptionNo = "";//絞込表示オプション（配列）分割前
        //chkViewOptionNo = editViewOption(listViewCheckTSADCD, chkKeihouNo)
        //var viewSadouGenninList = [];//絞込表示オプション（配列）分割後
        //if (fncChkBlunkStr(chkViewOptionNo)) { //「空,null,undefined」以外の場合
        //    viewSadouGenninList = chkViewOptionNo.split(",");//カンマ区切りの1行(xx,yy,zz)を、配列[xx,yy,zz]に加工
        //}
        // 2023/01/18 DEL END   Y.ARAKAKI 2022更改No8_追加対応 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。

        //除外用リスト
        var chkRemoveOptionNo = "";//除外オプション（配列）分割前
        chkRemoveOptionNo = editRemoveOption(listRemoveCheckTSADCD, chkKeihouNo, cboTAIOKBN.value);//除外リスト、警報Noと対応区分Noを元に、除外オプションNo一覧を取得
        var remSadouGenninList = [];//除外オプション（配列）分割後
        if (fncChkBlunkStr(chkRemoveOptionNo)) { //「空,null,undefined」以外の場合
            remSadouGenninList = chkRemoveOptionNo.split(",");//カンマ区切りの1行(xx,yy,zz)を、配列[xx,yy,zz]に加工
        }
        
        //１電話、２出動、３重複の場合、除外項目を除いて原因器具項目を表示。
        if (cboTAIOKBN.value == "1" || cboTAIOKBN.value == "2" || cboTAIOKBN.value == "3") {
            for (var i = 0; i < listcboTSADCD0.length; i++) {
                // 2023/01/18 MOD START Y.ARAKAKI 2022更改No8_追加対応 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。
                // ①絞込表示に存在し、かつ、②除外リストに存在しない 項目Noの場合のみ、リストへ追加する。
                //if ( (viewSadouGenninList.length == 0 || viewSadouGenninList.indexOf(listcboTSADCD0[i].val) !== -1)
                //    && (remSadouGenninList.length == 0 || remSadouGenninList.indexOf(listcboTSADCD0[i].val) === -1)

                // 除外リストに存在しない 項目Noの場合のみ、リストへ追加する。
                if ( remSadouGenninList.length == 0 || remSadouGenninList.indexOf(listcboTSADCD0[i].val) === -1) { // ===-1 →存在しないこと。 !==-1 →存在すること
                    crtOption(listcboTSADCD0[i], cboTSADCD);
                }
                // 2023/01/18 MOD END   Y.ARAKAKI 2022更改No8_追加対応 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。
            }
        } else {
            //上記以外（想定では空選択）の場合、全項目をリスト表示
            for (var i = 0; i < listcboTSADCD0.length; i++) {
                // 2023/01/18 MOD START Y.ARAKAKI 2022更改No8_追加対応 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。
                //if (viewSadouGenninList.length == 0 || viewSadouGenninList.indexOf(listcboTSADCD0[i].val) !== -1
                //   ) { // ===-1 →存在しないこと。 !==-1 →存在すること
                //    crtOption(listcboTSADCD0[i], cboTSADCD);
                //}
                crtOption(listcboTSADCD0[i], cboTSADCD);
                // 2023/01/18 MOD END   Y.ARAKAKI 2022更改No8_追加対応 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。


            }
        }
        
        //編集後、選択状態を復元できる場合は復元する。
        if (fncChkBlunkStr(selectListValTSADCD)) { //リスト選択値が「空,null,undefined」以外の場合
            for (var i = 0; i < cboTSADCD.length; i++) {
                if (cboTSADCD.options[i].value == selectListValTSADCD) { //選択Noと一致する行が存在した場合、選択状態にする。
                    cboTSADCD.options[i].selected = true;
                    break;
                }
            }
        }

    }
}
//**************************************
//　警報メッセージNo取得処理(警報メッセージボックスを加工)  
//**************************************
function getKeihouNo() {
    var resultKeihouNo = "";//初期値空。警報メッセージが空の場合も初期値で返却する。
    var radioKeihouNo = document.getElementsByName('rdoMsg');

    var keihouTxt = "";
    var yousoKeihouTxtBoxName = "";

    for (var i = 0; i < radioKeihouNo.length; i++) { //１～６回繰り返し
        //ラジオチェックが付いた行の警報メッセージを取得する。
        if (radioKeihouNo.item(i).checked) { 

            //testKNoTxt += "警報" + String(i) + "：" + radioKeihouNo.item(i).checked;
            //testKNoTxt += KAIGYO + "警報" + String(i) + "中身：" + radioKeihouNo.item(i).value;

            yousoKeihouTxtBoxName = "txtKMNM" + String(radioKeihouNo.item(i).value);//警報メッセージのID名を生成
            keihouTxt = document.getElementById(yousoKeihouTxtBoxName); //警報メッセージを取得
            ////これでもテキストボックス（非活性）中身を取得できる。が、要素名が可変で取得できないので今回採用しない。
            //keihouTxt = Form1.txtKMNM1.value;

            if (keihouTxt.value != "" && keihouTxt.value != " ： ") {//中身ある行だけ取得して、
                resultKeihouNo += keihouTxt.value.split("：")[0]; //警報メッセージの左2桁（警報メッセージNO)を取得
                break;//チェック行以外不要のため、ブレイクでfor中断。
            }
        }
    }
    return resultKeihouNo;
}
//**************************************
//　除外オプションNo取得処理(復帰対応状況、原因器具、作動原因_共通)  
//**************************************
function editRemoveOption(listRemoveCheck,keihouNo, taiouKbn) {
    var resultRemOptNo = "";
    if (taiouKbn == "1" || taiouKbn == "2" || taiouKbn == "3") { //１電話、２出動、３重複のみ、除外オプションを選択。
        for (var i = 0; i < listRemoveCheck.length; i++) {
            if (listRemoveCheck[i].keihoMsgNo == keihouNo
                && listRemoveCheck[i].taioKbnNo == taiouKbn) {
                resultRemOptNo = listRemoveCheck[i].removeNo;
                break;
            }
        }
    }
    return resultRemOptNo;
}
// 2023/01/18 DEL START Y.ARAKAKI 2022更改No8_追加対応 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。
////**************************************
////　絞込表示オプションNo取得処理(作動原因のみ_今後を想定し、念のため共通化)  
////**************************************
//function editViewOption(listViewCheck, keihouNo) {
//    var resultViewOptNo = "";
//    for (var i = 0; i < listViewCheck.length; i++) {
//        if (listViewCheck[i].keihoMsgNo == keihouNo) {
//            resultViewOptNo = listViewCheck[i].viewNo;
//            break;
//        }
//    }
//    return resultViewOptNo;
//}
// 2023/01/18 DEL END   Y.ARAKAKI 2022更改No8_追加対応 プルダウン区分59による制限表示設定を不使用とし、今後区分84の除外項目のみで制御するよう修正。
//2022/08/02 ADD END Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

//2022/12/09 ADD START Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応
var beforKeihoNo;
//**************************************
//　警報No毎による、各種リスト項目の自動選択処理(特定の警報Noに反応して、特定のリスト内容を自動選択させる。)  
//**************************************
function setAutoListValues() {

    var beforJidouSentakuFlg = false;//前回自動選択対象フラグ。trueの場合、前回の警報Noは自動選択対象だった。
    var afterJidouSentakuFlg = false;//今回自動選択対象フラグ。前回と今回両方の判断おわったらループ抜ける用の判定フラグ。

    // 初期化前であった場合(nullまたはundifined)、ここで初期化する。
    if (fncChkBlunkStr(beforKeihoNo) == false) {
        beforKeihoNo = ""; //初期化
    }

    var chkKeihouNo = "";//ラジオ選択された警報メッセージNo
    chkKeihouNo = getKeihouNo(); //警報Noを取得(共通処理呼出)

    var wkJidouSentakuLists = "";// 分割前の自動選択リスト

    //M06_PULLDOWN(KBN=86)のX系を除く件数分ループ
    for (var i = 0; i < listKeihouJidouSentakuCD.length; i++) {
        // ① 前回が自動選択対象の警報Noか確認。(空なら処理しない)
        if (!beforJidouSentakuFlg 
            && fncChkBlunkStr(beforKeihoNo) 
            && (beforKeihoNo == listKeihouJidouSentakuCD[i].keihoMsgNo) ) {
            beforJidouSentakuFlg = true;
        }

        // ② DBの警報Noと、画面選択警報Noが一致するかチェック
        if (!afterJidouSentakuFlg 
            && chkKeihouNo == listKeihouJidouSentakuCD[i].keihoMsgNo) { 
            wkJidouSentakuLists = listKeihouJidouSentakuCD[i].jidouSentakuList;//分割前の自動選択リストを取得。
            afterJidouSentakuFlg = true;
            
        }

        // ③両方判定済の場合、ループ抜ける。
        if (beforJidouSentakuFlg && afterJidouSentakuFlg){
            break;//for文を抜ける。
        }
    }

    //分割前の自動選択リストを取得していた場合、分割して特定のリスト項目へ反映する。
    var jidouSentakuLists = [];//分割後
    if (fncChkBlunkStr(wkJidouSentakuLists)) { //「空,null,undefined」以外の場合
        jidouSentakuLists = wkJidouSentakuLists.split(",");//カンマ区切りの1行(xx,yy,zz)を、配列[xx,yy,zz]に加工
        var wkPullDownNo = "";//プルダウンリストNo(M06_PULLDOWNのKBN2桁)_12：通信相手,15：電話連絡内容,14：復帰対応状況,16：原因器具,17：作動原因
        var wkPullDownValueNo = "";//プルダウン内容2桁
        for (var i = 0; i < jidouSentakuLists.length; i++) { //各種リストを自動選択する処理（ループ）
            if (fncChkBlunkStr(jidouSentakuLists[i])) {//null空チェック(正しく登録されていれば問題なく取得できる。)
                wkPullDownNo = jidouSentakuLists[i].substr(0, 2);//左端から2桁
                wkPullDownValueNo = jidouSentakuLists[i].substr(2);//3桁目以降すべて(最大2桁)
            } else {
                continue;//もしnull空がいたらスキップ
            }
            //リストへ反映していく処理 ※対象リストのNoと実際のリストを関連付けるため、直書きしている。
            switch (wkPullDownNo) {
                case "12"://12：通信相手
                    listValueSelected("cboTAITCD", wkPullDownValueNo);
                    break;
                case "15"://15：電話連絡内容 
                    listValueSelected("cboTELRCD", wkPullDownValueNo);
                    break;
                case "14"://14：復帰対応状況 
                    listValueSelected("cboTFKICD", wkPullDownValueNo);
                    break;
                case "16"://16：原因器具
                    listValueSelected("cboTKIGCD", wkPullDownValueNo);
                    break;
                case "17"://17：作動原因 
                    listValueSelected("cboTSADCD", wkPullDownValueNo);
                    break;
            }
        }
        beforKeihoNo = chkKeihouNo;//前警報Noに、今回の警報No(自動更新対象）を設定。

    } else if (beforJidouSentakuFlg) {
        // 前回警報Noが自動選択対象、かつ、今回警報Noが自動選択対象外の場合、反映先のリストを初期化する。
        listValueSelected("cboTAITCD", "");//12：通信相手
        listValueSelected("cboTELRCD", "");//15：電話連絡内容 
        listValueSelected("cboTFKICD", "");//14：復帰対応状況 
        listValueSelected("cboTKIGCD", "");//16：原因器具
        listValueSelected("cboTSADCD", "");//17：作動原因 
        beforKeihoNo = "";//前警報Noも一緒にリセット
    }
}
//**************************************
//　対象リスト項目の指定項目を、選択状態にする。(共通処理)  
//**************************************
function listValueSelected(wkCboListName, valueNo) {
    var wkCboList = document.Form1.document.getElementById(wkCboListName);
    for (var i = 0; i < wkCboList.length; i++) {
        if (wkCboList.options[i].value == valueNo) { //選択Noと一致する行が存在した場合、選択状態にする。
            wkCboList.options[i].selected = true;
            break;
        }
    }
}
//2022/12/09 ADD END   Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応



//**************************************
//　option 作成 //2019/11/01 w.ganeko 2019監視改善 No6
//**************************************
function crtOption(item,tag) {
    var option = document.createElement("option");
    option.text = item.txt;
    option.innerHTML = item.txt;
    option.value = item.val;
    tag.appendChild(option);
}
//2019/11/01 w.ganeko 2019監視改善 No6 end
//**************************************
//処理区分が変更されたとき(処理済の場合は完了日を使用可能)
//**************************************
function fncTMSKB_Chenge() {
	with(Form1) {
		if (cboTMSKB.value=="2") {
			txtSYOYMD.readOnly=false;
			//txtSYOYMD.tabIndex="29";
			txtSYOYMD.style.backgroundColor='white';
			txtSYOTIME.readOnly=false;
			//txtSYOTIME.tabIndex="30";
            txtSYOTIME.style.backgroundColor = 'white';
		} else {
			txtSYOYMD.value="";			
			txtSYOYMD.readOnly=true;
			//txtSYOYMD.tabIndex="-1";
			txtSYOYMD.style.backgroundColor='Gainsboro';
			txtSYOTIME.value="";			
			txtSYOTIME.readOnly=true;
			//txtSYOTIME.tabIndex="-1";
            txtSYOTIME.style.backgroundColor = 'Gainsboro';

        }

        //2020/03/11 T.Ono add 監視改善2019 START
        //対応区分=１電話かつ、未処理、処理中の場合は、連絡相手等のプルダウンを必須としない
        if (cboTAIOKBN.value == "1") {
            if (cboTMSKB.value == "2") {
                //１電話対応、２処理済み
                fncPulldownStyle(1)
            } else {
                //１電話対応、１未処理／３処理中
                fncPulldownStyle(2)
            }
        } else if (cboTAIOKBN.value == "2") {
            //２出動依頼
            fncPulldownStyle(1)
        } else if (cboTAIOKBN.value == "3") {
            //３重複
            fncPulldownStyle(2)
        }
	}
}
//2020/03/11 T.Ono add 監視改善2019
//**************************************
// 連絡相手、電話連絡内容、復帰対応状況、原因器具、作動原因を必須とするか否か
//**************************************
function fncPulldownStyle(flg) {
    with (Form1) {
        if (flg == "1") {
            //必須
            cboTAITCD.className = "cb-h";
            cboTELRCD.className = "cb-h";
            cboTFKICD.className = "cb-h";
            cboTKIGCD.className = "cb-h";
            cboTSADCD.className = "cb-h";
            cboTAITCD.style.backgroundColor = "LightPink";
            cboTELRCD.style.backgroundColor = "LightPink";
            cboTFKICD.style.backgroundColor = "LightPink";
            cboTKIGCD.style.backgroundColor = "LightPink";
            cboTSADCD.style.backgroundColor = "LightPink";
            var blurevent = function () {
                fncFo(this, 3);
            };
            cboTAITCD.onblur = blurevent;
            cboTELRCD.onblur = blurevent;
            cboTFKICD.onblur = blurevent;
            cboTKIGCD.onblur = blurevent;
            cboTSADCD.onblur = blurevent;
        } else {
            //必須でない
            cboTAITCD.className = "c-f";
            cboTELRCD.className = "c-f";
            cboTFKICD.className = "c-f";
            cboTKIGCD.className = "c-f";
            cboTSADCD.className = "c-f";
            cboTAITCD.style.backgroundColor = "white";
            cboTELRCD.style.backgroundColor = "white";
            cboTFKICD.style.backgroundColor = "white";
            cboTKIGCD.style.backgroundColor = "white";
            cboTSADCD.style.backgroundColor = "white";
            var blurevent = function () {
                fncFo(this, 1);
            };
            cboTAITCD.onblur = blurevent;
            cboTELRCD.onblur = blurevent;
            cboTFKICD.onblur = blurevent;
            cboTKIGCD.onblur = blurevent;
            cboTSADCD.onblur = blurevent;
        }
    }
}
// 2007/04/25 T.Watabe add
//**************************************
// 警報メッセージの選択後、HIDDEN項目を表示項目へコピー 
//**************************************
function fncKeihoMsgCopy() {
	with(Form1) {
	    //2015/01/06 T.Ono mod 2014改善開発 No2 START
        //txtKMNM1.value = (hdnKMCD1.value.length > 0) ? (hdnKMCD1.value + "：" + hdnKMNM1.value) : "";
	    //txtKMNM2.value = (hdnKMCD2.value.length > 0) ? (hdnKMCD2.value + "：" + hdnKMNM2.value) : "";
	    //txtKMNM3.value = (hdnKMCD3.value.length > 0) ? (hdnKMCD3.value + "：" + hdnKMNM3.value) : "";
	    //txtKMNM4.value = (hdnKMCD4.value.length > 0) ? (hdnKMCD4.value + "：" + hdnKMNM4.value) : "";
	    //txtKMNM5.value = (hdnKMCD5.value.length > 0) ? (hdnKMCD5.value + "：" + hdnKMNM5.value) : "";
	    //txtKMNM6.value = (hdnKMCD6.value.length > 0) ? (hdnKMCD6.value + "：" + hdnKMNM6.value) : "";

	    txtKMNM1.value = (hdnKMCD1.value.length > 0) ? (hdnKMCD1.value + "：" + hdnKMNM1.value) : hdnKMNM1.value;
	    txtKMNM2.value = (hdnKMCD2.value.length > 0) ? (hdnKMCD2.value + "：" + hdnKMNM2.value) : hdnKMNM2.value;
	    txtKMNM3.value = (hdnKMCD3.value.length > 0) ? (hdnKMCD3.value + "：" + hdnKMNM3.value) : hdnKMNM3.value;
	    txtKMNM4.value = (hdnKMCD4.value.length > 0) ? (hdnKMCD4.value + "：" + hdnKMNM4.value) : hdnKMNM4.value;
	    txtKMNM5.value = (hdnKMCD5.value.length > 0) ? (hdnKMCD5.value + "：" + hdnKMNM5.value) : hdnKMNM5.value;
	    txtKMNM6.value = (hdnKMCD6.value.length > 0) ? (hdnKMCD6.value + "：" + hdnKMNM6.value) : hdnKMNM6.value;
		//2015/01/06 T.Ono mod 2014改善開発 No2 END

        //2020/11/01 T.Ono add 2020監視改善
        flgKeihoMsgCopy = 1;
        fncMsgchange();
	}
}
// 2007/04/25 T.Watabe add
//**************************************
// 対応入力可能クライアントは新規で入力できるようにする。
//**************************************
function fncChgDispFukusima() {
	with(Form1) {
		//if (txtClientCD.value == '3250'){ // 2007/04/19 T.Watabe add
		if (fncChkTaiouInputOk(txtClientCD.value, hdnInputClientList.value)){ // 2007/05/09 T.Watabe edit
			// 入力可
			btnKEICD1.disabled = false;
			btnKEICD2.disabled = false;
			btnKEICD3.disabled = false;
			btnKEICD4.disabled = false;
			btnKEICD5.disabled = false;
			btnKEICD6.disabled = false;
			btnHATKBN.disabled = false;
			txtHATYMD.readOnly = false;
			txtHATTIME.readOnly = false;
			txtHATYMD.className = "c-f";
			txtHATTIME.className = "c-f";
		}else{
			// 入力不可
			btnKEICD1.disabled = true;
			btnKEICD2.disabled = true;
			btnKEICD3.disabled = true;
			btnKEICD4.disabled = true;
			btnKEICD5.disabled = true;
			btnKEICD6.disabled = true;
			btnHATKBN.disabled = true;
			txtHATYMD.readOnly = true;
			txtHATTIME.readOnly = true;
			txtHATYMD.className = "c-rNM";
			txtHATTIME.className = "c-rNM";
		}
		
		// 2008/10/15 T.Watabe add
		txtNCUHATYMD.readOnly = true;
		txtNCUHATTIME.readOnly = true;
		txtNCUHATYMD.className = "c-rNM";
		txtNCUHATTIME.className = "c-rNM";
	}
}

// 2007/05/09 T.Watabe add
//**************************************
// 対応入力可能クライアントの判定
//**************************************
function fncChkTaiouInputOk(clientCD, clientList) {
	
	// 引数チェック
	if (clientCD.length   <= 0) return false;
	if (clientList.length <= 0) return false;
	
	var arr;
	arr = clientList.split(",");		//カンマ区切りで配列にする
	arr.sort();							//昇順でソート
	if (clientList.length > 0){
		for (var i = 0; i < arr.length; i++){
			if (clientCD == arr[i]) return true; // 合致したらtrueを返す
		}
	}
	return false; // 見つからないのでfalseを返す
}

// 2007/05/09 T.Watabe add
//**************************************
// onLoad時処理
//**************************************
function fncOnLoad(){
	fncChgDispFukusima(); // 対応入力可能クライアントは新規で入力できるようにする。
	fncHATYMDDiffChk();   // 発生日時(NCU感知)と受信日時(テレコン受信)の時間差チェック 2008/10/17 T.Watabe add
	fncDispFaxKbn();  // ほかの監視ｾﾝﾀｰには見せない 2010/10/27 T.Watabe add
	// 2014/05/14 T.Ono add 2014改善開発 №2
	if (document.Form1.document.getElementById('txtJUSYONM').value.length > 0) {
	    window.top.document.title = document.Form1.document.getElementById('txtJUSYONM').value;
	} else if (document.Form1.document.getElementById('txtJUSYONM').value.length == 0) {
	    window.top.document.title = "新規";
	}

}

// 2010/10/27 T.Watabe add
//**************************************
// ほかの監視ｾﾝﾀｰには見せない
//**************************************
function fncDispFaxKbn() {
	with(document.Form1){
	    if(document.getElementById("hdnOTHER_KANSI_CENTER").value == "1"){ // ほかの監視ｾﾝﾀｰ？
	         document.getElementById('divFaxKbnDisp1').style.display='none';
	         document.getElementById('divFaxKbnDisp2').style.display = 'none';
	         //2015/11/16 H.Mori add 2015改善開発 No1
             document.getElementById('divFaxKbnDisp3').style.display = 'none';
	         document.getElementById('btnUpdate').style.width='110px';
	         //document.getElementById('btnUpdate').style.width = '100px';
             // 2011/11/10 H.Uema add ja注意事項は表示させない
	         document.getElementById('divGuideline').style.display='none';      
	    }
	}
}

// 2008/10/16 T.Watabe add
//**************************************
// 発生日時と受信日時が離れていたら色を付けて警告
//**************************************
function fncHATYMDDiffChk() {
	with(document.Form1){
		
		// 日時入力チェック
		if (txtNCUHATYMD.value.length  != 10) return false;
		if (txtNCUHATTIME.value.length !=  5) return false;
		if (txtHATYMD.value.length     != 10) return false;
		if (txtHATTIME.value.length    !=  5) return false;
		
		dObj1 = new Date(txtNCUHATYMD.value + " " + txtNCUHATTIME.value + ":00");
		dObj2 = new Date(txtHATYMD.value + " " + txtHATTIME.value + ":00");
		var ms = dObj2.getTime() - dObj1.getTime();
		var baseMin = hdnNCUDiffChkMin.value * 1;
		ms = Math.floor(ms / (1000 * 60));           // ミリ秒から分へ変換。切捨て。
		if (ms >= baseMin){ // 設定値以上過ぎてる？(30分)
			//NCUHAT_MSG.innerHTML = "<b><font style='font-size:11px; color:red;'>発生と受信の時間が" + hdnNCUDiffChkMin.value + "分以上経過しています。</font></b>";
			txtNCUHATYMD.style.backgroundColor  = "tomato"; // 背景を赤に変更
			txtNCUHATTIME.style.backgroundColor = "tomato"; // 背景を赤に変更
			 
		}else{
			//NCUHAT_MSG.innerHTML = "";
			txtNCUHATYMD.style.backgroundColor  = "Gainsboro"; // 背景を戻す
			txtNCUHATTIME.style.backgroundColor = "Gainsboro"; // 背景を戻す
		}
		return true;
	}
}

// 2011/11/10 H.Uema add
//**************************************
// 注意事項をセットする
//**************************************
function setGuideline() {
	with(document.Form1){
		document.getElementById("lblGuideline").innerHTML = txtGuideline.value + "&nbsp;";
		txtGuideline.value = "";
        // 2019/11/01 W.GANEKO add START
        document.getElementById("lblGuideline2").innerHTML = txtGuideline2.value + "&nbsp;";
        txtGuideline2.value = "";
        document.getElementById("lblGuideline3").innerHTML = txtGuideline3.value + "&nbsp;";
        txtGuideline3.value = "";
        // 2019/11/01 W.GANEKO add END
        // 2020/11/01 T.Ono add 監視改善2020 ボタン名 Start
        document.getElementById("lblGuidelineNM1").innerHTML = txtGuidelineNM1.value;
        txtGuideline.value = "";
        document.getElementById("lblGuidelineNM2").innerHTML = txtGuidelineNM2.value;
        txtGuideline2.value = "";
        document.getElementById("lblGuidelineNM3").innerHTML = txtGuidelineNM3.value;
        txtGuideline3.value = "";
        // 2020/10/01 T.Ono add 監視改善2020 ボタン名 End
	}
}

//2013/06/25 T.Ono add
//**************************************
// 注意事項(クライアント)をセットする
//**************************************
function setGuidelineCL() {
    with (document.Form1) {
        document.getElementById("lblGuidelineCL").innerHTML = txtGuidelineCL.value + "&nbsp;";
        txtGuidelineCL.value = "";
        // 2019/11/01 W.GANEKO add START
        document.getElementById("lblGuidelineCL2").innerHTML = txtGuidelineCL2.value + "&nbsp;";
        txtGuidelineCL2.value = "";
        document.getElementById("lblGuidelineCL3").innerHTML = txtGuidelineCL3.value + "&nbsp;";
        txtGuidelineCL3.value = "";
        // 2019/11/01 W.GANEKO add END
        // 2020/11/01 T.Ono add 監視改善2020 ボタン名 Start
        document.getElementById("lblGuidelineNMCL1").innerHTML = txtGuidelineNMCL1.value;
        txtGuideline.value = "";
        document.getElementById("lblGuidelineNMCL2").innerHTML = txtGuidelineNMCL2.value;
        txtGuideline2.value = "";
        document.getElementById("lblGuidelineNMCL3").innerHTML = txtGuidelineNMCL3.value;
        txtGuideline3.value = "";
        // 2020/11/01 T.Ono add 監視改善2020 ボタン名 End
    }
}
//2013/06/27 T.Ono add
//**************************************
//連絡先、JA注意事項等をセットする
//**************************************
function fncJUYOKAblur() {
    with (Form1) {
        //クライアント
        if ((txtClientCD.value == "") || (txtClientCD.value == " ")) {
            return false;
        }
        //ＪＡ支所名
        if ((hdnJASCD.value == "") || (hdnJASCD.value == " ")) {
            return false;
        }
    }
    //クライアント、ＪＡ支所名が入っていたら情報セット
    fncSyutudou();
}

//2013/08/15 T.Ono add 監視改善2013№1
//**************************************
//背景色の変更
//**************************************
function fncChangeColor() {

    with (Form1) {

        var d = []
        d.push(txtGAS_RESTART.value.replace(/\u002f/g, ""))   //スラッシュを削除
        d.push(txtGAS_START.value.replace(/\u002f/g, ""))
        d.push(txtGAS_DELE.value.replace(/\u002f/g, ""))

        var maxdate = Math.max.apply(null, d);  //一番大きい値を取得

        //ガス供給復活
        if (maxdate == d[0] && maxdate != 0) {
            //alert(d[0]);
            document.body.style.backgroundColor = "Cornsilk";
            //tableGASSTATE.style.backgroundColor = "Cornsilk"; //ｶﾞｽ供給**日のエリアのみ色変えの場合
            return;
        }
        //ガス供給休止日
        if (maxdate == d[1] && maxdate != 0) {
            //alert(d[1]);
            document.body.style.backgroundColor = "Yellow";
            return;
        }
        //ガス供給廃止日
        if (maxdate == d[2] && maxdate != 0) {
            //alert(d[2]);
            //document.body.style.backgroundColor = "HotPink";　//2014/02/04 T.Ono mod 色を変更
            document.body.style.backgroundColor = "LightPink";
            return;
        }
        //すべて空白
        if (maxdate == 0 ) {
            //alert("00000000");
            //document.body.style.backgroundColor = "Cornsilk";
            tableGASSTATE.style.backgroundColor = "Cornsilk";
            return;
        }
    }
}
//2013/08/19 T.Ono add 監視改善2013№1
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtMET_KATA.focus()
}

//2013/08/19 T.Ono 監視改善2013№1
//**************************************
//コピー補助ボタン押下時の処理
//**************************************
function btnCopy_onclick() {
    fncPop('KETAIJUG00');
}
//2013/08/23 T.Ono 監視改善2013№1
//**************************************
//用途：フォーカス取得時,喪失時に背景色を変える（お客様記事専用）
//引数：obj   色を変えるオブジェクト
//引数：color 変更する色。1を渡して黄緑にする
//**************************************
function fncFo_OKYAKU(obj, intColor) {
    //パラメータの色指定数値により、色を設定
    if (intColor == 1) {
        strColor = "greenyellow"
        ///2016/12/06 H.Mori 監視改善2016 No4-8 START
        if ((Form1.txtGENIN_KIJI.value == "") || (Form1.txtGENIN_KIJI.value == " ")) {
            if (Form1.chkSYUSEI.checked == true) {
                Form1.txtRENTEL.style.backgroundColor = 'white';
            } else if (Form1.chkSYUSEI.checked == false) {
                Form1.txtRENTEL.style.backgroundColor = 'Gainsboro';
            }
        } else {
            Form1.txtRENTEL.style.backgroundColor = 'greenyellow';
        }
        ///2016/12/06 H.Mori 監視改善2016 No4-8 END
    }
    ///2016/12/06 H.Mori 監視改善2016 No4-8 START
    else if (intColor == 3) {
        if ((Form1.txtGENIN_KIJI.value == "") || (Form1.txtGENIN_KIJI.value == " ")) {
            if (Form1.chkSYUSEI.checked == true) {
                strColor = 'white';
            } else if (Form1.chkSYUSEI.checked == false) {
                strColor = 'Gainsboro';
            }
        } else {
            strColor = 'greenyellow';
        }
    }
    ///2016/12/06 H.Mori 監視改善2016 No4-8 END

    //テキストボックスだったら
    if (obj.type == "text") {
        //読取専用だったら
        if (obj.readOnly == true) {
            //何もしないで終了
            return;
        } else {
            //フォーカスを取得した時＋入力可能テキストの場合
            if (intColor == 2) {
                obj.select();
            }
        }
    }
    //色を指定されたものに変更
    obj.style.backgroundColor = strColor;
}
//2013/10/24 T.Ono 監視改善2013№1
//2020/11/014 T.Ono 監視改善2020
//**************************************
//用途：お客様記事 日付の自動入力
//引数：obj   入力対象オブジェクト
//**************************************
function fnc_InsertDate(obj) {
    var today = new Date();
    var year = today.getFullYear();
    var Month = today.getMonth() + 1;
    var day = today.getDate();
    var msg = obj.value
    var SetObj = obj

    SetObj.value = msg + year + "/" + Month + "/" + day;

}
//**************************************
//用途：電話対応メモ　入力バイト数チェックとhdnへの格納（100バイト×3行までOK）
//引数：obj   チェック対象オブジェクト
//引数：lenmax最大文字数（1行あたり）
//備考：2020/11/01 T.Ono mod 2020監視改善
//      入力欄を100バイト×6行に変更
//**************************************
function fnc_byteCheck1(obj, lenmax) {

    if (obj.value.length > 0) {
        var ss = obj.value;
        var wk = "";
        var es = "";
        //var arr = new Array("", "", "", "");  //2020/11/01 T.Ono mod 2020監視改善
        var arr = new Array("", "", "", "", "", "", "", "");
        //var arrcnt = new Array(0, 0, 0, 0);  //2020/11/01 T.Ono mod 2020監視改善
        var arrcnt = new Array(0, 0, 0, 0, 0, 0, 0);
        var cnt = 0;
        var row = 0;
        var objname = "";

        for (i = 0; i < ss.length; i++) {
            wk = ss.substring(i, i + 1);
            es = escape(wk);
            if (es.charAt(0) == "%") {
                if (es >= "%uFF61" && es <= "%uFF9F") {
                    /* 半角カナ */
                    cnt = cnt + 1;
                    if (cnt > lenmax) { /* lenmax文字を超えたら、次行へいく！ */
                        row++;
                        cnt = 1;
                    }
                    arrcnt[row] = arrcnt[row] + 1;
                    arr[row] += wk;
                } else if (es.charAt(1) == "u") {
                    /* if (es.charAt(1) == "u") { */
                    /* 全角 */
                    cnt = cnt + 2;
                    if (cnt > lenmax) { /* lenmaxを超えたら、次行へいく！ */
                        row++;
                        cnt = 2;
                    }
                    arrcnt[row] = arrcnt[row] + 2;
                    arr[row] += wk;
                } else if (es == "%0D") {
                    /* 改行コード CR */
                    cnt = 0;
                    row++;
                } else if (es == "%0A") {
                    /* 改行コード LF */
                    /* →無視 */
                } else if (es == "%09") {
                    /* タブ \t */
                    /* →見た目の大きさが一定でないため、禁止とする */
                    alert("タブが入力されています：電話対応メモ\n\nタブの入力はできません。削除してください。");
                    obj.focus();
                    return false;
                } else if (es >= "%00" && es <= "%1F") {
                    /* 制御ｺｰﾄﾞ */
                    /* →無視 */
                } else if (es >= "%A7" && es <= "%F7") {
                    /* 2013/12/02 T.Ono add */
                    /* 全角記号（%uのつかない一部の文字§¨°±´¶×÷） */
                    cnt = cnt + 2;
                    if (cnt > lenmax) { /* lenmaxを超えたら、次行へいく！ */
                        row++;
                        cnt = 2;
                    }
                    arrcnt[row] = arrcnt[row] + 2;
                    arr[row] += wk;
                } else {
                    /* 半角記号 */
                    cnt = cnt + 1;
                    if (cnt > lenmax) { /* lenmax文字を超えたら、次行へいく！ */
                        row++;
                        cnt = 1;
                    }
                    arrcnt[row] = arrcnt[row] + 1;
                    arr[row] += wk;
                }
            } else {
                /* 半角 */
                cnt = cnt + 1;
                if (cnt > lenmax) { /* lenmax文字を超えたら、次行へいく！ */
                    row++;
                    cnt = 1;
                }
                arrcnt[row] = arrcnt[row] + 1;
                arr[row] += wk;
            }

            if (cnt > lenmax) {
                //alert("１行が半角100文字を超えています。\n\n[" + arr[row] + "]\n\n[" + (row + 1) + "行目]");
                //alert("文字数がオーバーしています：電話対応メモ\n\n300バイト以内かつ3行以内で入力してください");  //2020/11/01 T.Ono mod 2020監視改善
                alert("文字数がオーバーしています：電話対応メモ\n\n600バイト以内かつ6行以内で入力してください");
                obj.focus();
                return false;
            }
            //if (row > 2) {
            if (row > 5) {
                //alert("３行を超えています。\n\n１行１００文字、３行まで。\n\n[" + (row + 1) + "行以上あり]");
                //alert("文字数がオーバーしています：電話対応メモ\n\n300バイト以内かつ3行以内で入力してください");  //2020/11/01 T.Ono mod 2020監視改善
                alert("文字数がオーバーしています：電話対応メモ\n\n600バイト以内かつ6行以内で入力してください");
                obj.focus();
                return false;
            }
        }
        //alert("debug\n" + arr[0] + "\n" + arr[1] + "\n" + arr[2] + "\n" + arrcnt[0] + "\n" + arrcnt[1] + "\n" + arrcnt[2] + "");
        Form1.hdnTEL_MEMO1.value = arr[0] //1行目
        Form1.hdnTEL_MEMO2.value = arr[1] //2行目
        Form1.hdnFUK_MEMO.value = arr[2]  //3行目
        Form1.hdnTEL_MEMO4.value = arr[3] //4行目  //2020/11/01 T.Ono add 2020監視改善
        Form1.hdnTEL_MEMO5.value = arr[4] //5行目  //2020/11/01 T.Ono add 2020監視改善
        Form1.hdnTEL_MEMO6.value = arr[5] //6行目  //2020/11/01 T.Ono add 2020監視改善
        // 2015/03/05 T.Ono add START 入力値を消した場合、hdnTEL_MEMOに値が残らないよう変更
    } else {
        Form1.hdnTEL_MEMO1.value = "" //1行目
        Form1.hdnTEL_MEMO2.value = "" //2行目
        Form1.hdnFUK_MEMO.value = ""  //3行目
        Form1.hdnTEL_MEMO4.value = "" //4行目  //2020/11/01 T.Ono add 2020監視改善
        Form1.hdnTEL_MEMO5.value = "" //5行目  //2020/11/01 T.Ono add 2020監視改善
        Form1.hdnTEL_MEMO6.value = "" //6行目  //2020/11/01 T.Ono add 2020監視改善
        // 2015/03/05 T.Ono add END
    }
    return true;

}
//2013/10/24 T.Ono 監視改善2013№1
//**************************************
//用途：入力バイト数チェック（1行）
//引数：obj   チェック対象オブジェクト
//引数：lenmax最大バイト数
//備考：2020/11/01 T.Ono mod 監視改善2020
//　　　ﾒｯｾｰｼﾞのバイト数を可変に変更
//**************************************
function fnc_byteCheck2(obj, lenmax) {

    if (obj.value.length > 0) {
        var ss = obj.value;
        var wk = "";
        var es = "";
        var arr = new Array("", "", "", "");
        var arrcnt = new Array(0, 0, 0, 0);
        var cnt = 0;
        var row = 0;

        for (i = 0; i < ss.length; i++) {
            wk = ss.substring(i, i + 1);
            es = escape(wk);
            if (es.charAt(0) == "%") {
         		if(es >= "%uFF61" && es <= "%uFF9F"){
	         		/* 半角カナ */
	         		cnt = cnt + 1;
	         		if (cnt > lenmax) { /* lenmax文字を超えたらエラー */
                        //alert("文字数がオーバーしています：お客様記事\n\n160バイト以内で入力してくださいaaa");
                        alert("文字数がオーバーしています：お客様記事\n\n" + lenmax + "バイト以内で入力してください");
	         		    obj.focus();
	         		    return false;
         			}
	         		arrcnt[row] = arrcnt[row] + 1;
	         		arr[row] += wk;
				}else if (es.charAt(1) == "u") {
                /* if (es.charAt(1) == "u") { */
                    /* 全角 */
                    cnt = cnt + 2;
                    if (cnt > lenmax) { /* lenmax文字を超えたらエラー */
                        alert("文字数がオーバーしています：お客様記事\n\n" + lenmax + "バイト以内で入力してください");
                        obj.focus();
                        return false;
                    }
                    arrcnt[row] = arrcnt[row] + 2;
                    arr[row] += wk;
                } else if (es == "%09") {
                    /* タブ \t */
                    /* →見た目の大きさが一定でないため、禁止とする */
                    alert("タブが入力されています：お客様記事\n\nタブの入力はできません。削除してください。");
                    obj.focus();
                    return false;
                } else if (es >= "%00" && es <= "%1F") {
                    /* 制御ｺｰﾄﾞ */
                    /* →無視 */
                } else if (es >= "%A7" && es <= "%F7") {
                    /* 2013/12/02 T.Ono add */
                    /* 全角記号（%uのつかない一部の文字§¨°±´¶×÷） */
                    cnt = cnt + 2;
                    if (cnt > lenmax) { /* lenmax文字を超えたらエラー */
                        alert("文字数がオーバーしています：お客様記事\n\n" + lenmax + "バイト以内で入力してください");
                        obj.focus();
                        return false;
                    }
                    arrcnt[row] = arrcnt[row] + 2;
                    arr[row] += wk;                  
                } else {
                    /* 半角記号 */
                    cnt = cnt + 1;
                    if (cnt > lenmax) { /* lenmax文字を超えたらエラー */
                        alert("文字数がオーバーしています：お客様記事\n\n" + lenmax + "バイト以内で入力してください");
                        obj.focus();
                        return false;
                    }
                    arrcnt[row] = arrcnt[row] + 1;
                    arr[row] += wk;
                }
            } else {
                /* 半角 */
                cnt = cnt + 1;
                if (cnt > lenmax) { /* lenmax文字を超えたらエラー */
                    alert("文字数がオーバーしています：お客様記事\n\n" + lenmax + "バイト以内で入力してください");
                    obj.focus();
                    return false;
                }
                arrcnt[row] = arrcnt[row] + 1;
                arr[row] += wk;
            }
        }
        //alert("debug\n" + arr[0] + "\n" + arr[1] + "\n" + arr[2] + "\n" + arrcnt[0] + "\n" + arrcnt[1] + "\n" + arrcnt[2] + "")
    }

}
//2016/12/05 H.Mori add 2016改善開発 No4-8
//**************************************
//データ修正チェックボックス
//**************************************
function chkSYUSEI_onclick() {
    with (Form1) {
        //チェックあり
        if (chkSYUSEI.checked == true) {
            txtJUYOKA.style.backgroundColor = 'white';
            //お客様記事が空白の場合
            if ((txtGENIN_KIJI.value == "") || (txtGENIN_KIJI.value == " ")) {
                txtRENTEL.style.backgroundColor = 'white';
            //お客様記事に値が入力されている場合
            } else {
                txtRENTEL.style.backgroundColor = 'greenyellow';
            }
            txtJUSYONM.style.backgroundColor = 'white';
            txtJUSYOKN.style.backgroundColor = 'white';
            txtJUTEL1.style.backgroundColor = 'white';
            txtJUTEL2.style.backgroundColor = 'white';
            txtADDR.style.backgroundColor = 'white';
            txtJUYOKA.className = "c-f";
            txtRENTEL.className = "c-f";
            txtJUSYONM.className = "c-fI";
            txtJUSYOKN.className = "c-fI";
            txtJUTEL1.className = "c-f";
            txtJUTEL2.className = "c-f";
            txtADDR.className = "c-fI";

            //編集可能にする
            txtJUYOKA.readOnly = false;
            txtRENTEL.readOnly = false;
            txtJUSYONM.readOnly = false;
            txtJUSYOKN.readOnly = false;
            txtJUTEL1.readOnly = false;
            txtJUTEL2.readOnly = false;
            txtADDR.readOnly = false;
        
        //チェックなし
        } else if (chkSYUSEI.checked == false) {
            txtJUYOKA.style.backgroundColor = 'Gainsboro';
            //お客様記事が空白の場合
            if ((txtGENIN_KIJI.value == "") || (txtGENIN_KIJI.value == " ")) {
                txtRENTEL.style.backgroundColor = 'Gainsboro';
            //お客様記事に値が入力されている場合
            } else {
                txtRENTEL.style.backgroundColor = 'greenyellow';
            }
            txtJUSYONM.style.backgroundColor = 'Gainsboro';
            txtJUSYOKN.style.backgroundColor = 'Gainsboro';
            txtJUTEL1.style.backgroundColor = 'Gainsboro';
            txtJUTEL2.style.backgroundColor = 'Gainsboro';
            txtADDR.style.backgroundColor = 'Gainsboro';

            //読み取り専用にする
            txtJUYOKA.readOnly = true;
            txtRENTEL.readOnly = true;
            txtJUSYONM.readOnly = true;
            txtJUSYOKN.readOnly = true;
            txtJUTEL1.readOnly = true;
            txtJUTEL2.readOnly = true;
            txtADDR.readOnly = true;
        }
    }
}

//2016/12/06 H.Mori add 2016改善開発 No4-8
//**************************************
//住所のフォーカスをコントロールする
//**************************************
function fncADDR(obj,intColor) {    
    //チェックあり
    if (Form1.chkSYUSEI.checked == true) {
        fncFo(obj,intColor);
    //チェックなし
    } else if (Form1.chkSYUSEI.checked == false) {
        return false;
    }
}

//2017/10/18 H.Mori 2017改善開発 №4-3 
//**************************************
//ロックユーザー確認
//**************************************
function fncChkRocuser(strBtnId) {
    with (Form1) {
        if (hdnBackUrl.value == "KEJUKJAG00") {
            if (strBtnId == "1") {
                doSubmit("KETAIJKG00_ROC_btnTelHas1");
            }
            if (strBtnId == "2") {
                doSubmit("KETAIJKG00_ROC_btnTelHas2");
            }
            if (strBtnId == "3") {
                doSubmit("KETAIJKG00_ROC_btnRenraku");
            }
            if (strBtnId == "4") {
                doSubmit("KETAIJKG00_ROC_btnTKTANCD");
            }
        } else {
            if (strBtnId == "1") {
                btnDial_onclick('1', Form1.txtRENTEL.value, Form1.txtJUSYONM.value);
            }
            if (strBtnId == "2") {
                btnRenraku_onclick('3');
            }
            if (strBtnId == "3") {
                btnRenraku_onclick('2');
            }
            if (strBtnId == "4") {
                btnPopup_onclick('3');
            }
          }
    }
}

//2019/07/29 W.GANEKO add 2019改善開発 No4-8
//**************************************
//クライアント注意事項ラジオボタン
//**************************************
function chkClientRadio_onclick() {
    with (Form1) {
        //チェックあり
        if (guidelineClck1.checked == true) {
            document.getElementById("dlblGuidelineCL").style.display = "";
            document.getElementById("dlblGuidelineCL2").style.display = "none";
            document.getElementById("dlblGuidelineCL3").style.display = "none";
        } else if (guidelineClck2.checked == true) {
            document.getElementById("dlblGuidelineCL").style.display = "none";
            document.getElementById("dlblGuidelineCL2").style.display = "";
            document.getElementById("dlblGuidelineCL3").style.display = "none";
        } else if (guidelineClck3.checked == true) {
            document.getElementById("dlblGuidelineCL").style.display = "none";
            document.getElementById("dlblGuidelineCL2").style.display = "none";
            document.getElementById("dlblGuidelineCL3").style.display = "";
        }
    }
}
//2019/11/01 W.GANEKO add 2019改善開発 No4-8
//**************************************
//JA注意事項ラジオボタン
//**************************************
function chkJaChuiRadio_onclick() {
    with (Form1) {
        //チェックあり
        if (guidelineck1.checked == true) {
            document.getElementById("dlblGuideline").style.display = "";
            document.getElementById("dlblGuideline2").style.display = "none";
            document.getElementById("dlblGuideline3").style.display = "none";
        } else if (guidelineck2.checked == true) {
            document.getElementById("dlblGuideline").style.display = "none";
            document.getElementById("dlblGuideline2").style.display = "";
            document.getElementById("dlblGuideline3").style.display = "none";
        } else if (guidelineck3.checked == true) {
            document.getElementById("dlblGuideline").style.display = "none";
            document.getElementById("dlblGuideline2").style.display = "none";
            document.getElementById("dlblGuideline3").style.display = "";
        }
    }
}
//2019/11/01 W.GANEKO add 2019改善開発 No4-8
//**************************************
//警報修正チェックボックス
//**************************************
function chkMSGSEI_onclick() {
    with (Form1) {
        //チェックあり
        if (chkMSGSEI.checked == true) {
            rdoMsg1.disabled = false;
            rdoMsg2.disabled = false;
            rdoMsg3.disabled = false;
            rdoMsg4.disabled = false;
            rdoMsg5.disabled = false;
            rdoMsg6.disabled = false;
            //チェックなし
        } else if (chkMSGSEI.checked == false) {
            //読み取り専用にする
            rdoMsg1.disabled = true;
            rdoMsg2.disabled = true;
            rdoMsg3.disabled = true;
            rdoMsg4.disabled = true;
            rdoMsg5.disabled = true;
            rdoMsg6.disabled = true;
        }
    }
}

//2020/11/01 T.Ono add 監視改善2020
//**************************************
//チェックボックス変更
//**************************************
function fncMsgchange() {
    //2022/08/19 MOD START Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

    //2023/09/15 DEL Y.ARAKAKI プルダウン区分59（作動原因リスト表示絞込）の完全無効化対応 ※コメントアウト箇所の完全削除を実施

    //既存のラジオボタン選択式から、3種リストをJS処理で編集する形式へ変更。 これに併せてvb側は処理不要になるかも？
    crtcboTFKICDOption();//「復帰対応状況」リスト編集処理
    crtcboTKIGCDOption();//「原因器具」リスト編集処理
    crtcboTSADCDOption();// 「作動原因」リスト編集処理
    //2022/08/19 MOD END Y.ARAKAKI 2022更改No8 _対応入力画面の対応区分＋警報メッセージ組合せのリスト絞込対応

    //2022/12/09 ADD START Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応
    setAutoListValues();//警報Noを元に、各種リストの選択内容を設定する。
    //2022/12/09 ADD END   Y.Arakaki 2022更改No⑦ _特定警報メッセージNo選択時のリスト自動選択対応

    // 2022/12/21 ADD START Y.ARAKAKI 2022更改No① _対応入力画面における警報選択時の発生区分変更対応
    editHasseiKbn(); //選択された警報Noの有無で、発生区分表示を変更する。
    // 2022/12/21 ADD END   Y.ARAKAKI 2022更改No① _対応入力画面における警報選択時の発生区分変更対応

}
// 2022/12/21 ADD START Y.ARAKAKI 2022更改No① _対応入力画面における警報選択時の発生区分変更対応
//**************************************
// 発生区分：自動選択編集処理 //警報メッセージ選択時、値ありの場合だけ自動的に発生区分を「1:電話」から「2:緊急警報」表示に切り替える。
//**************************************
function editHasseiKbn() {
    var chkKeihoNo = getKeihouNo(); //現在選択されている、警報メッセージNo2桁（未選択時は空欄）を取得。

    var wkTxtHatKbnValue = "";
    var wkHdnHatKbnValue = "";

    if (fncChkBlunkStr(chkKeihoNo)) { //空null、undfinedチェック（値ありならtrue）
        wkTxtHatKbnValue = "緊急警報"; //固定値「緊急警報」を設定。(プルダウンマスタ（KBN=08）でも管理しているが、今回固定。)
        wkHdnHatKbnValue = 2; //2:緊急警報 
    } else {
        wkTxtHatKbnValue = "電話"; //固定値「電話」を設定。(プルダウンマスタ（KBN=08）でも管理しているが、今回固定。)
        wkHdnHatKbnValue = 1; //1:電話
    }

    //画面に反映
    with (Form1) { //getElementByIdの代わり。
        txtHATKBN.value = wkTxtHatKbnValue; 
        hdnHATKBN.value = wkHdnHatKbnValue; 
    }

}
// 2022/12/21 ADD END   Y.ARAKAKI 2022更改No① _対応入力画面における警報選択時の発生区分変更対応

// 20221130 MOD START Y.ARAKAKI 2022更改No③ 検索時のハイフンチェック削除対応
////2021/10/01 sakaADD 2021監視改善⑦ 電話番号14ケタ化で対応入力画面右上連絡先の臨時エラーチェック
////**************************************
////数字のみ、ハイフン1つ、ハイフン2つをOKとする
////**************************************
////入力用
//function fncChkTel14(strTel) {
//    if ((strTel.match(/^[0-9]+\-[0-9]+$/) == null)
//        && (strTel.match(/^[0-9]+\-[0-9]+\-[0-9]+$/) == null)
//        && (strTel.length != 0) && (strTel.match(/^[0-9]+$/) == null)) {
//        return false;
//    }
//    return true;
//}
// 20221130 MOD END   Y.ARAKAKI 2022更改No③ 検索時のハイフンチェック削除対応

// 2023/09/22 ADD START Y.ARAKAKI 2023更改テスト実装 _住所検索機能の外部サイト追加
//**************************************
// 対応入力画面専用：子画面表示（地理院地図）
//**************************************
var winSearchAddress;
function openSearchAddress() {
    //小画面サイズ調整
    var winStatusSearchAddress = 'width=640,height=480,left=300,top=200,menubar=no,toolbar=no,location=no,resizable=yes';
    //ウィンドウ展開(地理院地図)
    winSearchAddress = window.open('https:&#47;&#47;maps&#46;gsi&#46;go&#46;jp&#47;', 'searchAddress', winStatusSearchAddress);
}
//**************************************
// 対応入力画面専用：住所コピー
//**************************************
function copyTxtADDR() {
    var wkTxtADDR = document.getElementById('txtADDR');
    var wkTxtADDRValue = wkTxtADDR.value;

    if (navigator.clipboard) { // navigator.clipboardが使えるか判定する
        return navigator.clipboard.writeText(wkTxtADDRValue).then(function () { /* クリップボードへ書き込む */  })
    } else {
        wkTxtADDR.focus();
        wkTxtADDR.select(); // inputタグを選択する
        document.execCommand('copy'); // クリップボードにコピーする

        // for IE
        if (document.selection) {
            document.selection.empty();
            // for Firefox
        } else if (window.getSelection) {
            window.getSelection().removeAllRanges();
        }
        wkTxtADDR.blur();
    }

    //wkTxtADDR.select;
    //document.execCommand("copy");
    //wkTxtADDR.blur();
}
// 2023/09/22 ADD END   Y.ARAKAKI 2023更改テスト実装 _住所検索機能の外部サイト追加
