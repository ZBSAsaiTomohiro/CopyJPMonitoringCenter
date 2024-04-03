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
 	// 2014/10/22 H.Hosoda mod 2014改善開発 No11 START
    } else {
        window.top.document.title = '監視システム';
 	// 2014/10/22 H.Hosoda mod 2014改善開発 No11 END
	}
}
//**************************************
//対応終了ボタン押下時の処理
//**************************************
function btnUpd1_onclick() {
	Form1.hdnKBN.value = '2';
	//入力値チェック---------------
	if(fncDataCheck()==false){
		return false;
	}
	var strRes;
	//確認メッセージ---------------
	strRes = confirm("修正登録してよろしいですか？");

	if (strRes==false){
		return;
	}

	//オブジェクトのロック処理-----
	fncDispRoc();
	
	//登録系フレームワーク
	doPostBack('btnUpd1','');
}
//**************************************
//対応中ボタン押下時の処理
//**************************************
function btnUpd2_onclick() {
	Form1.hdnKBN.value = '3';
	//入力値チェック---------------
	if(fncDataCheck()==false){
		return false;
	}
	var strRes;
	//確認メッセージ---------------
	strRes = confirm("修正登録してよろしいですか？");

	if (strRes==false){
		return;
	}

	//オブジェクトのロック処理-----
	fncDispRoc();
	
	//登録系フレームワーク
	doPostBack('btnUpd2','');
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
	doPostBack('btnExit',''); 
}
//**************************************
//印刷押下
//**************************************
function btnPrint_onclick() {
	window.print();
}
//**************************************
//
//**************************************
function fncDispRoc() {
	with(Form1) {
		btnExit.disabled=true;
		btnUpd1.disabled=true;
		btnUpd2.disabled=true;
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
	    //受信氏名必須チェック
	    // 2014/10/22 H.Hosoda mod 2014改善開発 No11 START
		//if(cboTSTANCD.value.length==0) {
	    if (txtTSTAN_CD.value.length == 0 || txtTSTAN_CD.value == " ") {
			alert('受信者氏名は必須です');
			btnTSTAN_CD.focus();
			txtTSTAN_CD.value = "";
			return false;
		}
		//所属必須チェック
		if(cboSTD.value.length==0) {
			alert('所属は必須です');
			cboSTD.focus();
			return false;
		}
		
		// 2014/10/22 H.Hosoda add 2014改善開発 No11 START
		//対応受信日必須チェック
		if(Form1.hdnKBN.value=='2'){ // 2:対応完了登録？
			if(txtTAIO_ST_DATE.value.length==0) {
				alert('処理完了の場合、対応受信日時は必須です');
				txtTAIO_ST_DATE.focus();
				return false;
			}
			if(txtTAIO_ST_TIME.value.length==0) {
				alert('処理完了の場合、対応受信日時は必須です');
				txtTAIO_ST_TIME.focus();
				return false;
			}
		}
		// 2014/10/22 H.Hosoda add 2014改善開発 No11 END
		//対応受信日
		if(txtTAIO_ST_DATE.value.length!=0){
			if(fncChkDate(txtTAIO_ST_DATE.value) == false) {
				alert('対応受信日は正しい日付ではありません');
				txtTAIO_ST_DATE.focus();
				return false;
			}
		}
		//対応受信時刻
		if(txtTAIO_ST_TIME.value.length!=0){
			if(txtTAIO_ST_TIME.value.length != '') {
				if(fncChkTime(txtTAIO_ST_TIME.value) == false) {
					alert('対応受信時刻は時刻を入力してください');
					txtTAIO_ST_TIME.focus();
					return false;
				}
			}
		}
		//対応受信日・対応受信時刻
		if (((txtTAIO_ST_DATE.value.length  > 0) && (txtTAIO_ST_TIME.value.length == 0)) ||
		    ((txtTAIO_ST_DATE.value.length == 0) && (txtTAIO_ST_TIME.value.length  > 0))) {
			alert('対応受信日・対応受信時刻は両方入力してください');
			if (txtTAIO_ST_DATE.value.length == 0) {
				txtTAIO_ST_DATE.focus();
			} else {
				txtTAIO_ST_TIME.focus();
			}
			return false;
		}
		
		//出動日必須チェック 2008/10/20 T.Watabe add
		if(Form1.hdnKBN.value=='2'){ // 2:対応完了登録？
			if(txtSDYMD.value.length==0) {
				alert('処理完了の場合、出動日時は必須です');
				txtSDYMD.focus();
				return false;
			}
			if(txtSDTIME.value.length==0) {
				alert('処理完了の場合、出動日時は必須です');
				txtSDTIME.focus();
				return false;
			}
		}
		// 2008/10/14 T.Watabe add
		//出動日付
		if(txtSDYMD.value.length!=0){
			if(fncChkDate(txtSDYMD.value) == false) {
				alert('出動日は正しい日付ではありません');
				txtSDYMD.focus();
				return false;
			}
		}
		//出動時刻
		if(txtSDTIME.value.length!=0){
			if(fncChkTime(txtSDTIME.value) == false) {
				alert('出動時刻は時刻を入力してください');
				txtSDTIME.focus();
				return false;
			}
		}
		//出動日時
		if (((txtSDYMD.value.length  > 0) && (txtSDTIME.value.length == 0)) ||
		    ((txtSDYMD.value.length == 0) && (txtSDTIME.value.length  > 0))) {
			alert('出動日・出動時刻は両方入力してください');
			if (txtSDYMD.value.length == 0) {
				txtSDYMD.focus();
			} else {
				txtSDTIME.focus();
			}
			return false;
		}
		
		//到着日必須チェック 2008/10/20 T.Watabe add
		if(Form1.hdnKBN.value=='2'){ // 2:対応完了登録？
			if(txtTYAKYMD.value.length==0) {
				alert('処理完了の場合、到着日時は必須です');
				txtTYAKYMD.focus();
				return false;
			}
			if(txtTYAKTIME.value.length==0) {
				alert('処理完了の場合、到着日時は必須です');
				txtTYAKTIME.focus();
				return false;
			}
		}
		//到着日付
		if(txtTYAKYMD.value.length!=0){
			if(fncChkDate(txtTYAKYMD.value) == false) {
				alert('到着日は正しい日付ではありません');
				txtTYAKYMD.focus();
				return false;
			}
		}
		//到着時刻
		if(txtTYAKTIME.value.length!=0){
			if(fncChkTime(txtTYAKTIME.value) == false) {
				alert('到着時刻は時刻を入力してください');
				txtTYAKTIME.focus();
				return false;
			}
		}
		//到着日時
		if (((txtTYAKYMD.value.length  > 0) && (txtTYAKTIME.value.length == 0)) ||
		    ((txtTYAKYMD.value.length == 0) && (txtTYAKTIME.value.length  > 0))) {
			alert('到着日・到着時刻は両方入力してください');
			if (txtTYAKYMD.value.length == 0) {
				txtTYAKYMD.focus();
			} else {
				txtTYAKTIME.focus();
			}
			return false;
		}
		//処理完了日必須チェック
		if(Form1.hdnKBN.value=='2'){ // 2:対応完了登録？
			if(txtSYOKANYMD.value.length==0) {
				alert('処理完了の場合、処理完了日時は必須です');
				txtSYOKANYMD.focus();
				return false;
			}
			if(txtSYOKANTIME.value.length==0) {
				alert('処理完了の場合、処理完了日時は必須です');
				txtSYOKANTIME.focus();
				return false;
			}
		}
		//処理完了日付
		if(txtSYOKANYMD.value.length!=0){
			if(fncChkDate(txtSYOKANYMD.value) == false) {
				alert('処理完了日は正しい日付ではありません');
				txtSYOKANYMD.focus();
				return false;
			}
		}
		//処理完了時刻
		if(txtSYOKANTIME.value.length!=0){
			if(fncChkTime(txtSYOKANTIME.value) == false) {
				alert('処理完了時刻は時刻を入力してください');
				txtSYOKANTIME.focus();
				return false;
			}
		}
		//処理完了日時
		if (((txtSYOKANYMD.value.length  > 0) && (txtSYOKANTIME.value.length == 0)) ||
		    ((txtSYOKANYMD.value.length == 0) && (txtSYOKANTIME.value.length  > 0))) {
			alert('処理完了日・処理完了時刻は両方入力してください');
			if (txtSYOKANYMD.value.length == 0) {
				txtSYOKANYMD.focus();
			} else {
				txtSYOKANTIME.focus();
			}
			return false;
		}
		
		// 2014/10/22 H.Hosoda add 2014改善開発 No11 START
		//日時前後チェック 対応受信日時＜出動日時＜到着日時＜処理完了日時
		var numDateTime;
		var numDateTimeNxt;
		var strDateTimeName;
		var ctlRet;
		numDateTime = 0;
		numDateTimeNxt = 0;
		strDateTimeName="";
		
		//処理完了日時
		if ((txtSYOKANYMD.value.length > 0) && (txtSYOKANTIME.value.length > 0)){
			numDateTime = fncFmtDateTime(txtSYOKANYMD.value,txtSYOKANTIME.value);
			strDateTimeName = "処理完了日時";
		}		
		//到着日時
		if ((txtTYAKYMD.value.length > 0) && (txtTYAKTIME.value.length > 0)){
			numDateTimeNxt = fncFmtDateTime(txtTYAKYMD.value,txtTYAKTIME.value);
			if (numDateTime > 0){
				if (numDateTimeNxt >= numDateTime){
					alert('日時の前後関係に誤りがあります：' + strDateTimeName);
					ctlRet = fncGetDtCtl(strDateTimeName);
					ctlRet.focus();
					return false;
				}
			}
			numDateTime = numDateTimeNxt;
			strDateTimeName = "到着日時"
		}
		//出動日時
		if ((txtSDYMD.value.length > 0) && (txtSDTIME.value.length > 0)){
			numDateTimeNxt = fncFmtDateTime(txtSDYMD.value,txtSDTIME.value);
			if (numDateTime > 0){
				if (numDateTimeNxt >= numDateTime){
					alert('日時の前後関係に誤りがあります：' + strDateTimeName);
					ctlRet = fncGetDtCtl(strDateTimeName);
					ctlRet.focus();
					return false;
				}
			}
			numDateTime = numDateTimeNxt;
			strDateTimeName = "出動日時"
		}
		//対応受信日時
		if ((txtTAIO_ST_DATE.value.length > 0) && (txtTAIO_ST_TIME.value.length > 0)){
			numDateTimeNxt = fncFmtDateTime(txtTAIO_ST_DATE.value,txtTAIO_ST_TIME.value);
			if (numDateTime > 0){
				if (numDateTimeNxt >= numDateTime){
					alert('日時の前後関係に誤りがあります：' + strDateTimeName);
					ctlRet = fncGetDtCtl(strDateTimeName);
					ctlRet.focus();
					return false;
				}
			}
		}
		// 2014/10/22 H.Hosoda add 2014改善開発 No11 END
		
        //出動対応内容/備考　2013/10/28 T.Ono 監視改善2013№1
		fncbyteCheck1(txtSDTBIK,100);
	}
	return true;
}
//--- ↓2005/04/21 MOD　Falcon↓ -----------------
//**************************************
//
//**************************************
function fncGasu_Change(strInd) {
	with(Form1) {
		if (strInd=="1") {
			//漏れ原因有りの場合
//			rdoGASMUMU_K.checked=true;	//ガス器具を選択させる
//			rdoGASMUMU_H.checked=false;
			rdoGASMUMU_H.disabled=false;
		} else {
			//漏れ原因無しの場合
			rdoGASMUMU_K.checked=true;	
			rdoGASMUMU_H.checked=false;
			rdoGASMUMU_H.disabled=true;
		}
	}
}
//--- ↑2005/04/21 MOD　Falcon↑ -----------------

//**************************************
//ポップアップ 2014/10/23 H.Hosoda mod 2014改善開発 No11
//**************************************
function btnPopup_onclick(strTrg) {

    Form1.hdnPopcrtl.value = strTrg;
    fncPop("COPOPUPG00");
    Form1.hdnPopcrtl.value = "";
}

// 2008/11/04 T.Watabe add
//**************************************
// ポップアップ画面呼び出し（連絡先表示、等）
//**************************************
var wP;
function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "SDSYUJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
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
	Form1.hdnKensaku.value = strId;
	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
	Form1.target = name;
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""
}

//2013/08/26 T.Ono add 監視改善2013№1
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtGENIN_KIJI.focus()
}
//2013/10/25 T.Ono 監視改善2013№1
//**************************************
//用途：出動結果内容/報告　入力バイト数チェックとhdnへの格納（100バイト×3行までOK）
//引数：obj   チェック対象オブジェクト
//引数：lenmax最大文字数（1行あたり）
//**************************************
function fncbyteCheck1(obj, lenmax) {

    if (obj.value.length > 0) {
        var ss = obj.value;
        var wk = "";
        var es = "";
        var arr = new Array("", "", "", "");
        var arrcnt = new Array(0, 0, 0, 0);
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
                    Sleep(0.5);
                    alert("タブが入力されています：出動対応内容/報告\n\nタブの入力はできません。削除してください。");
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
                Sleep(0.5);
                alert("文字数がオーバーしています：出動対応内容/報告\n\n300バイト以内かつ3行以内で入力してください");
                obj.focus();
                return false;
            }
            if (row > 2) {
                //alert("３行を超えています。\n\n１行１００文字、３行まで。\n\n[" + (row + 1) + "行以上あり]");
                Sleep(0.5);
                alert("文字数がオーバーしています：出動対応内容/報告\n\n300バイト以内かつ3行以内で入力してください");
                obj.focus();
                return false;
            }
        }
        //alert("debug\n" + arr[0] + "\n" + arr[1] + "\n" + arr[2] + "\n" + arrcnt[0] + "\n" + arrcnt[1] + "\n" + arrcnt[2] + "");
        Form1.hdnSDTBIK2.value = arr[0] //1行目
        Form1.hdnSNTTOKKI.value = arr[1] //2行目
        Form1.hdnSDTBIK3.value = arr[2]  //3行目
    }

}
function Sleep(T) {
    var d1 = new Date().getTime();
    var d2 = new Date().getTime();
    while (d2 < d1 + 1000 * T) {    //T秒待つ 
        d2 = new Date().getTime();
    }
    return;
} 

// 2014/10/22 H.Hosoda add 2014改善開発 No11 START
//**************************************
// onLoad時処理
//**************************************
function fncOnLoad(){
	if (document.Form1.document.getElementById('txtJUSYONM').value.length > 0) {
		window.top.document.title = document.Form1.document.getElementById('txtJUSYONM').value;
	}
	else if (document.Form1.document.getElementById('txtJUSYONM').value.length == 0)
	{
		window.top.document.title = "新規"
	}
}
//**************************************
// 日時フォーマット
// 日付(YYYY/MM/DD)と時間(HH:MM:SS)の
// 文字列を数値（YYYYMMDDHHMMSS）に変換
//**************************************
function fncFmtDateTime(strDate,strTime){
	var regDate = new RegExp("/","g");
	var regTime = new RegExp(":","g");
	var strFmtDate;
	var strFmtTime;	
	strFmtDate = strDate.replace(regDate,"");
	strFmtTime = strTime.replace(regTime,"");
	return Number(strFmtDate + strFmtTime);
}
//**************************************
// 日時名称を判定しコントロールを返す
//**************************************
function fncGetDtCtl(strDateName){
	switch (strDateName){
		case "処理完了日時":
		    return Form1.txtSYOKANYMD;
			break;
		case "到着日時":
		    return Form1.txtTYAKYMD;
			break;
		case "出動日時":
		    return Form1.txtSDYMD;
			break;
		case "対応受信日時":
		    return Form1.txtTAIO_ST_DATE;
			break;
		default:
			break;
    }
    return;
}
// 2014/10/22 H.Hosoda add 2014改善開発 No11 END
// 2017/10/27 H.Mori add 2017改善開発 №6-1 START
//**************************************
// 日付差異チェック
//**************************************
function fncDateCheck1() {
    var regDate = new RegExp("/", "g");
    var strFmtDate;
    var tai = Form1.txtTAIO_ST_DATE.value;
    strFmtDate = tai.replace(regDate, "");
    strFmtDate = parseInt(strFmtDate) + 1;         //対応受信日 + 1
    var syo = Form1.txtSYOKANYMD.value;  //処理完了日
    //対応受信日から2日以降の場合NG
    if (syo > strFmtDate) {
        alert('受信日と完了日に差異がありますが、よろしいですか？');
        //Form1.txtHATYMD.focus();  //2017/11/17 H.Mori mod 2017改善開発 №6-1
        return false;
    }
}
// 2017/10/27 H.Mori add 2017改善開発 №6-1 END