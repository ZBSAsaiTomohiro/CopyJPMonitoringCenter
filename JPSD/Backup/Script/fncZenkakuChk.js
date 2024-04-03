//==================================================
//用途：全角チェックする関数
//引数：str   全角チェックする文字列
//戻り値：全角を含む時はtrue、全て半角の時はfalse
//==================================================
function fncZenkakuChk(str) {
  for ( var i=0; i < str.length; i++){
    //文字コードを１６進数にして取得
    strCode=str.charCodeAt(i).toString( 16 );
    //４桁未満の場合、先頭のゼロを追加する
    if (strCode.length == 1 ) {
      strCode='000' + strCode;
    }
    if (strCode.length == 2 ) {
      strCode='00' + strCode;
    }
    if (strCode.length == 3 ) {
      strCode='0' + strCode;
    }
    //半角カナであるかチェック
    if (strCode < 'ff61' || strCode > 'ff9f'){
      //英数字、スペースであるかチェック
      if (strCode < '0020' || strCode > '007e'){
        return true;
      }
    }
  }
return false;
}
