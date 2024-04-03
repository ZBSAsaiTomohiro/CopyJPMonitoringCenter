//************************************************************
// File    : JavaScript
// Autohor : ZBS T.Watabe
// Date    : 2013/12/06
// Remarks : for InternetExplore later 5.0
//************************************************************
//  @0001 2013/12/06 T.Watabe      上下選択機能追加

var SLASH = "";

//-----------------------------------------------------
// キーコード取得（マルチブラウザ対応）
//-----------------------------------------------------
function gfunGetKeyCode(e){ 
  if(document.all) { 
    return event.keyCode 
  } else if(document.getElementById) { 
    return (e.keyCode!=0)?e.keyCode:e.charCode 
  } else if(document.layers) { 
    return e.which 
  } 
} 
// 2013/12/06 T.Watabe add
//-----------------------------------------------------
// 日付を上下左右キーで操作
//-----------------------------------------------------
function fncEasyDateChg(obj, type){
  with (document.forms[0]){
    // --------------------
    // キー取得
    // --------------------
    var lintKeyCode; 
    lintKeyCode = parseInt(gfunGetKeyCode(event)); 
    switch (lintKeyCode) { // 上下以外はキーをそのまま送る。スキップ！
    case 38: //「↑」
    case 40: //「↓」
      
      var moveMonthFlg = false; // シフトキーの時は月単位
      
      // --------------------
      // チェック
      // --------------------
      if (obj       == "undefined") break;
      if (obj.value == "undefined") break;
      
      // --------------------
      // 空の時は本日を入れる
      // --------------------
      if (obj.value == ""){
	      if (type == "m"){
	        obj.value = getPcYYYYMMDD().substring(0,6);
	      } else {
	        obj.value = getPcYYYYMMDD();
	      }
	      return (false); break;
      }
	    
	    // シフトキーの時は月単位
	    if (window.event.shiftKey == true){ 
	      moveMonthFlg = true;
	    }
      
      // それぞれの操作
	    switch (lintKeyCode) { 
	    case 37: //「←」
	      return (false); break;
	    case 38: //「↑」
	      if (type == "m"){
	        if(chgSpYMDate(obj)){
	          if(isFmtYMDate(obj)){
	            fncObjDatePlus(obj,-1); // 年月－１
	          }
	        }
	      }else{
	        if(chgSpDate(obj)){
	          if(isFmtDate(obj)){
	            if (moveMonthFlg == false){
	              fncObjDatePlus(obj,-1); // 日付－１
	            }else{
	              var ss = obj.value;
	              obj.value = ss.substr(0,6);
	              fncObjDatePlus(obj,-1); // 年月－１
	              obj.value = obj.value.substr(0,6) + SLASH + "01";
	              obj.value = adjYMDOver(obj.value.substr(0,6) + ss.substr(6,2));
	            }
	          }
	        }
	      }
	      return (false); break;
	    case 39: //「→」
	      return (false); break;
	    case 40: //「↓」
	      if (type == "m"){
	        if(chgSpYMDate(obj)){
	          if(isFmtYMDate(obj)){
	            fncObjDatePlus(obj,1); // 年月＋１
	          }
	        }
	      }else{
	        if(chgSpDate(obj)){
	          if(isFmtDate(obj)){
	            if (moveMonthFlg == false){
	              fncObjDatePlus(obj,1);  // 日付＋１
	            }else{
	              var ss = obj.value;
	              obj.value = obj.value.substr(0,6);
	              fncObjDatePlus(obj,1);  // 日付＋１
	              obj.value = obj.value.substr(0,6) + SLASH + "01";
	              obj.value = adjYMDOver(obj.value.substr(0,6) + ss.substr(6,2));
	            }
	          }
	        }
	      }
	      return (false); break;
	    default: 
	      return (true); break; 
	    } 
	    return (true); break; 
    default: 
	    return (true); break; 
	  } 
  }
}

// 2013/12/06 T.Watabe add
// 日付の日がその月の末尾日より大きい場合は末尾日に補正
function adjYMDOver(ymd){
	
	if (ymd.length != 8) return ymd;
	
	var yy = ymd.substr(0,4);
	var mm = ymd.substr(4,2);
	var dd = ymd.substr(6,2);
	
	var nIndex = "99";
	
  switch (parseInt(mm,10)) {
    case 1: case 3: case 5: case 7: case 8: case 10: case 12:
      nIndex = "31";
      break;
    case 4: case 6: case 9: case 11:
      nIndex = "30";
      break;
    case 2:
      if (((yy % 4) == 0 && (yy % 100) !=0 ) || (yy % 400) == 0) {
        nIndex = "29";
      }
      else {
        nIndex = "28";
      }
      break;
    default:
      return false;
  }
  	
  if (dd > nIndex) dd = nIndex;
  
  return yy + SLASH + mm + SLASH + dd;
  
}

// 2013/12/06 T.Watabe add
//-----------------------------------------------------
// オブジェクト日付加算
// @param obj  対象        yyyymm or yyyymmdd
// @param num  日数、月数
//-----------------------------------------------------
function fncObjDatePlus(obj, num){
  
  ///定義
  var ymd, yy, mm, dd, ee, type;
  err = 0;
  
  if (obj == undefined) return false;
  if (obj.value == "") return false;
  if (num == null) return false;
  if (num == "") return false;
  if (num == 0) return true;
  
  
  
  ymd = obj.value;
  if (false);
  else if (ymd.length ==  6) type = "m";
  else if (ymd.length == 8) type = "d";
  else type = "";
  
  if (type.length > 0){
    yy = ymd.substring(0,4);
    mm = ymd.substring(4,6);
    dd = ymd.substring(6,8);
    if (mm == null || mm.length <= 0) mm = "01";
    if (dd == null || dd.length <= 0) dd = "01";
    ee = new Date(yy, mm - 1, dd);
    
    if (type == "m"){
      ee.setMonth(ee.getMonth() + num);
    }else if (type == "d"){
      ee.setTime(ee.getTime() + num * 24 * 3600 * 1000);
    }
    yy = ee.getFullYear();
    mm = ee.getMonth() + 1;
    dd = ee.getDate();
    if (mm < 10) { mm = "0" + mm; }
    if (dd < 10) { dd = "0" + dd; }
    
    if (type == "m"){
      ymd = yy + SLASH + mm;
    }else if (type == "d"){
      ymd = yy + SLASH + mm + SLASH + dd;
    }
    obj.value = ymd;
  }
}

// 2013/12/06 T.Watabe add
//-----------------------------------------------------
// 日付書式チェック
//-----------------------------------------------------
function isFmtDate(obj)
{
  if (obj.value == "") return true;
  var sDate = new String(obj.value);
  var yy,mm,dd;
  var nStart, nIndex;
  var bflg = false;
  if (sDate.length == 8) {
    for (i = 0; i < 8; i++) {
      if (isNaN(parseInt(sDate.charAt(i), 10))) {
        bflg = true;
        break;
      }
    }
    yy = sDate.substr(0,4);
    mm = sDate.substr(4,2);
    dd = sDate.substr(6,2);
  }
  if (bflg || sDate.length != 8) {
    for (i = 0, nStart = 0; i < 2 && (nIndex = sDate.indexOf(SLASH, nStart)) != -1; i++, nStart = (nIndex + 1)) {
      switch (i) {
        case 0: yy = sDate.substr(nStart, nIndex - nStart); break;
        case 1: mm = sDate.substr(nStart, nIndex - nStart); break;
        default: break;
      }
    }
    if (nIndex == -1) {
      //put_errmsg("YYYYMMDD または YYYY/MM/DD 形式で日付を入力して下さい", obj);
      return false;
    }
    dd = sDate.substr(nStart,sDate.length-nStart);
    if (yy.length != 4) {
      //put_errmsg("年が認識できません：[" + yy + "]", obj);
      return false;
    }
    if (mm.length != 2) {
      //put_errmsg("月が認識できません：[" + mm + "]", obj);
      return false;
    }
    if (dd.length != 2) {
      //put_errmsg("日が認識できません：[" + dd + "]", obj);
      return false;
    }
  }
  for (i = 0; i < yy.length; i++) {
    if (isNaN(parseInt(yy.charAt(i), 10))) {
      //put_errmsg("年に不正な文字が入力されています：[" + yy.charAt(i) + "]", obj);
      return false;
    }
  }
  for (i = 0; i < mm.length; i++) {
    if (isNaN(parseInt(mm.charAt(i), 10))) {
      //put_errmsg("月に不正な文字が入力されています：[" + mm.charAt(i) + "]", obj);
      return false;
    }
  }
  for (i = 0; i < dd.length; i++) {
    if (isNaN(parseInt(dd.charAt(i), 10))) {
      //put_errmsg("日に不正な文字が入力されています：[" + dd.charAt(i) + "]", obj);
      return false;
    }
  }
  
  switch (parseInt(mm,10)) {
    case 1: case 3: case 5: case 7: case 8: case 10: case 12:
      nIndex = 31;
      break;
    case 4: case 6: case 9: case 11:
      nIndex = 30;
      break;
    case 2:
      if (((yy % 4) == 0 && (yy % 100) !=0 ) || (yy % 400) == 0) {
        nIndex = 29;
      }
      else {
        nIndex = 28;
      }
      break;
    default:
      //put_errmsg("月が間違っています：[" + mm + "]", obj);
      return false;
  }
  if (parseInt(dd, 10) < 1 || parseInt(dd, 10) > nIndex) {
    //put_errmsg("日が間違っています：[" + dd + "]", obj);
    return false;
  }
  if (mm.length == 1) mm = "0" + mm;
  if (dd.length == 1) dd = "0" + dd;
  obj.value = yy + SLASH + mm + SLASH + dd;
  
  return true;
}
// 2013/12/06 T.Watabe add
//-----------------------------------------------------
// ＰＣの年月日を取得
//-----------------------------------------------------
function getPcYYYYMMDD(){
  dd = new Date();
  yy = dd.getYear();
  mm = dd.getMonth() + 1;
  dd = dd.getDate();
  if (yy < 2000) { yy += 1900; }
  if (mm < 10) { mm = "0" + mm; }
  if (dd < 10) { dd = "0" + dd; }
  return (yy + SLASH + mm + SLASH + dd);
}
// 2013/12/06 T.Watabe add
//-----------------------------------------------------
// ＰＣの時分を取得
//-----------------------------------------------------
function getPcHHMM(){
  dd = new Date();
  hh = dd.getHours();
  mm = dd.getMinutes();
  if (hh < 10) { hh = "0" + hh; }
  if (mm < 10) { mm = "0" + mm; }
  return (hh + ":" + mm);
}
// 2013/12/06 T.Watabe add
//-----------------------------------------------------
// 日付特別変換 yyyy/mm/dd SalesDateText.javaで使用
//-----------------------------------------------------
function chgSpDate(obj){
	with (document.forms[0]){
		// チェック
	  if (obj.value.length <= 0) return true;
	  var sDate = new String(obj.value);
	  sDate = sDate.toLowerCase();  // 小文字にしておく
	  
	  // 置き換え
	  if(false){
	  }else if (sDate == "0"){ // 0は現在日付に変換
	    obj.value = getPcYYYYMMDD();
	  //}else if (sDate == "1"){ // 1はシステム日付に変換
	  //  if (document.forms[0].systemDate != undefined && systemDate.value.length >= 10){
	  //    obj.value = systemDate.value.substring(0,10);
	  //  }
	  }else if (sDate == "9"){ // 9は「2999/12/31」(遠い未来日)をセット
	    obj.value = "29991231";
	  }
  }
  return true;
}
// 2013/12/06 T.Watabe add
//-----------------------------------------------------
// 年月特別変換 yyyy/mm SalesDateText.javaで使用
//-----------------------------------------------------
function chgSpYMDate(obj){
	with (document.forms[0]){
		// チェック
	  if (obj.value.length <= 0) return true;
	  var sDate = new String(obj.value);
	  sDate = sDate.toLowerCase();  // 小文字にしておく
	  
	  // 置き換え
	  if(false){
	  }else if (sDate == "0"){ // 0は現在年月に変換
	    obj.value = getPcYYYYMMDD().substring(0,6);
	  //}else if (sDate == "1"){ // 1はシステム日付に変換
	  //  if (document.forms[0].systemDate != undefined && systemDate.value.length >= 7){
	  //    obj.value = systemDate.value.substring(0,7);
	  //  }
	  }else if (sDate == "9"){ // 9は「2999/12」(遠い未来年月)をセット
	    obj.value = "299912";
	  }
  }
  return true;
}

