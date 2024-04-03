//==================================================
//用途：小数点以下の数値に、0編集する
//引数：strNum 入力された数値
//    intKeta 小数点以下桁数
//戻値：0編集された数値
//使用イベント：フォーカス喪失時
//==================================================
function fncNum0(strNum,intKeta){
  //数値でなければ
  if(isNaN(strNum)){
    //長さ０の文字列を返す
    return '';
  }
  //長さ０の文字列であれば
  if(strNum.length==0){
    //長さ０の文字列を返す
    return '';
  }
  var str=String(Number(strNum));
  var strRes=new String('');
  //先頭が小数点で、少数点以下桁数が0でなければ
  if(str.indexOf('.')==0 && intKeta!=0){
    //先頭に0を付加する
    strRes='0' + str
  } else if(str.indexOf('.')==0 && intKeta==0) {
    //0を返す
    return '0';
  } else {
    strRes=str;
  }
  
  //少数点桁が0でなければ
  if(intKeta > 0){

    //少数点が含まれていない場合
    if(str.lastIndexOf(".") == -1){
      //小数点を付加して
      strRes=str + ".";
      //足りない0を付加して
      strRes=strRes + fncLoopStr('0',intKeta);
    //少数点が含まれている場合
    } else {
      //数値の宣言
      var int = new Number;
      //既にある小数点以下の桁数
      int=str.length-str.indexOf('.')-1;
      //足りない0を付加する
      strRes=str + fncLoopStr('0',intKeta-int);
      //引数の小数点以下桁数が、引数の数値の小数点以下桁数より多い場合
      if (intKeta<int){
        strRes=strRes.slice(0,strNum.length+intKeta-int);
      }
    }
    //値を返す
    return strRes;
  //桁数が0であれば
  } else if(intKeta == 0){
    //最後に小数点があったら、削除
    if(strRes.length==strRes.indexOf('.')+1){
      strRes=strRes.replace('.','');
    }
    strRes=String(parseInt(strRes,10));
    return strRes;
  //桁数が-1であれば
  } else if(intKeta == -1){
    //最後に小数点があったら、削除
    if(strRes.length==strRes.indexOf('.')+1){
      strRes=strRes.replace('.','');
    }
    //その他とくに何もせず、リターン
    return strRes;
  }
}
//==================================================
//用途：連続して同じ文字を返す
//引数：str   連続して取得したい文字（例：0）
//    intLen  取得する文字の数（例：5）
//戻値：連続する同じ文字(例：00000)
//==================================================
function fncLoopStr(str,intLen){
inti=0;
strBack='';
  while (inti < intLen) {
    strBack=strBack + str;
    inti++;
  }
  return strBack;
}
//==================================================
//用途：カンマ編集して、フォーカス時の色変更をする
//引数：obj 入力された数値のテキストボックス
//    idx intColor
//戻値：カンマ編集した数値
//使用イベント：フォーカス喪失時、取得時
//==================================================
function fncFo_Num(obj,intColor,intKeta){
  //フォーカス喪失時
  if(intColor!=2){
    //小数点以下処理
    obj.value=fncNum0(obj.value,intKeta);
    var str = obj.value;
    var strTmp=new String('');
    str = str.replace(/,/g, "");
    var tmpStr = "";
    while (str != (strTmp = str.replace(/^([+-]?\d+)(\d\d\d)/,"$1,$2"))) {
      str = strTmp;
    }
    obj.value= str;
  //フォーカス取得時
  } else {
    //カンマ削除
    obj.value = obj.value.split(",").join("");
    obj.select();
  }
  //フォーカス取得関数を呼ぶ
  fncFo(obj,intColor);
}
//==================================================
//用途：渡された数値項目の桁あふれ(OverFlow)チェック
//引数：obj 入力された数値のテキストボックス
//戻値：桁あふれの場合 false
//    正常な場合 true
//使用イベント：実行ボタン押下時
//==================================================
function fncNumOF(obj){
  //マイナス対応
  decMaxVal = obj.maxLength -1;
  //入力値の絶対値で判断
  decVal = obj.value.replace(/,/g,'').replace(/^-/,'');

  if(decMaxVal < decVal.length){
    return false;
  } else {
    return true;
  }
}
  