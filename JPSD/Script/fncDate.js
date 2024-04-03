//==================================================
//用途：日付コントロール制御
//引数：obj 日付のテキストボックス
//	idx １：フォーカス喪失時 ２：フォーカス取得時
//戻値：スラッシュの入った、または無くなった文字列
//==================================================
function fncFo_date(obj,intColor){
	//フォーカス喪失時
	if(intColor!="2"){
		//数値であれば
		if (isNaN(obj.value) == false) {
			//MAXLENGTHが6であれば年月(YYYYMM)と判断
			if (obj.maxLength == 6) {
				//スラッシュを付加
				obj.value = fncDateSlaYM(obj.value);
			} else {
				//スラッシュを付加
				obj.value = fncDateSla(obj.value);
			}
		}
	//フォーカス取得時
	} else {
		//正規表現によりスラッシュの位置を取得
		var reg = new RegExp("/","g");
		var objval = obj.value;
		//数値であれば
		if (isNaN(objval.replace(reg,"")) == false) {
			//スラッシュを削除する
			obj.value = objval.replace(reg,"");
		}
		//選択状態にする
		obj.select();
	}
	//フォーカス時の色を変える
	fncFo(obj,intColor);
}
//==================================================
//用途：数値の日付書式から/付の日付書式に変える
//引数：strDate YYYYMM形式の日付
//戻値：YYYY/MM形式の日付
//==================================================
function fncDateSlaYM(strDate){
	//文字数が6文字で無かったら
	if(strDate.length!=6){
		//値をそのまま戻す
		return strDate;
	}
	strDate=strDate.substr(0,4) + '/' + strDate.substr(4,2);

	return strDate;
}
//==================================================
//用途：数値の日付書式から/付の日付書式に変える
//引数：strDate YYYYMMDD形式の日付
//戻値：YYYY/MM/DD形式の日付
//==================================================
function fncDateSla(strDate){
	//文字数が8文字以上で無かったら
	if(strDate.length!=8){
		//値をそのまま戻す
		return strDate;
	}
	strDate=strDate.substr(0,4) + '/' + strDate.substr(4,2) + '/' + strDate.substr(6,2);

	return strDate;
}
//==================================================
//用途：日付チェック
//引数：strDate YYYY/MM/DD形式の日付
//戻値：true or false
//==================================================
function fncChkDate(strDate){
	if (strDate.length != 0) {
		if (strDate.length == 7) {
			strDate = strDate + '/01';
		}

		//スラッシュを省いた場合に８バイトであること
		var reg = new RegExp("/","g");
		if (strDate.replace(reg,"").length != 8) {
			return false;
		}

		strYear =strDate.substr(0,4);
		strMon  =strDate.substr(5,2);
		strDay  =strDate.substr(8,2);

		//チェックする各項目はすべて数値でないとエラー
		if(isNaN(strYear + strMon + strDay) == true){
			return false;
		}

		strMaxDayOfMonth = Array( 31,29,31,30,31,30,31,31,30,31,30,31 );
		if( strMon < 1 || strMon > 12 ){
			return false;
		}
		if( strDay < 1 || strDay > strMaxDayOfMonth[strMon-1] ){
			return false;
		}
		if( strMon != 2 ){
			return true;
		}
		if( strDay < 29 ){
			return true;
		}
		if( ( strYear % 4 ) == 0 && ( strYear % 100 ) != 0 ){
			return true;
		}
		if( ( strYear % 400 ) == 0 ){
			return true;
		}
		return false;
	}
}
// 2008/10/17 T.Watabe add
//==================================================
//用途：本日日付取得
//戻値：YYYY/MM/DD形式の日付
//==================================================
function getTodayStr(){
	var dd = new Date();
	var yy = dd.getYear();
	var mm = dd.getMonth() + 1;
	var dd = dd.getDate();
	if (yy < 2000) { yy += 1900; }
	if (mm < 10) { mm = "0" + mm; }
	if (dd < 10) { dd = "0" + dd; }
	return yy + "/" + mm + "/" + dd;
}
