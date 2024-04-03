//==================================================
//用途：時間コントロール制御
//引数：obj 時間のテキストボックス
//  idx １：フォーカス喪失時 ２：フォーカス取得時
//戻値：編集後文字列
//==================================================
function fncFo_time(obj,intColor){
  //フォーカス喪失時
  if(intColor!="2"){
    //数値であれば
    if (isNaN(obj.value) == false) {
      obj.value = fncTimeHN(obj.value);
    }
  //フォーカス取得時
  } else {
    var reg = new RegExp(":","g");
    var objval = obj.value;
    obj.value = objval.replace(reg,"");
    obj.select();
  }
  //フォーカス時の色を変える
  fncFo(obj,intColor);
}
//==================================================
//用途：数値から時間編集の書式に変える
//引数：strTime YYYYMM形式の日付
//戻値：YYYY/MM形式の日付
//==================================================
function fncTimeHN(strTime){
  //文字数が6文字で無かったら
  if(strTime.length==6){
    strTime=strTime.substr(0,2) + ':' + strTime.substr(2,2) + ':' + strTime.substr(4,2);
  } else if (strTime.length==4) {
    strTime=strTime.substr(0,2) + ':' + strTime.substr(2,2);
  } else {
    //値をそのまま戻す
  }
  return strTime;
}
//==================================================
//用途：時間のチェック
//引数：
//戻値：
//==================================================
function fncChkTime(pstrTime){
  //時刻構成エラー
  if(pstrTime.length==0){
    return true;
  }
  strTime=pstrTime.split(":");
  if(strTime.length!=3){
    return false;
  }

  //時間のチェック
  //数値チェック
  if(isNaN(strTime[0])==true){
    return false;
  }
  //範囲チェック
  if(strTime[0]>"23"){
    return false;
  }

  //分のチェック
  //数値チェック
  if(isNaN(strTime[1])==true){
    return false;
  }
  //範囲チェック
  if(strTime[1]>"59"){
    return false;
  }

  //秒のチェック
  //数値チェック
  if(isNaN(strTime[2])==true){
    return false;
  }
  //範囲チェック
  if(strTime[2]>"59"){
    return false;
  }
}