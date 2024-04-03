//==================================================
//用途：電話番号の入力値フォーマットチェック
//引数：入力値
//戻値：Boolean
//==================================================
function fncChkTel(strTel) {
  //⇒ハイフンもＯＫ
  //if ((strTel.match(/^[0-9]+\-[0-9]+\-[0-9]+$/) == null) && (strTel.length!=0)) {
  // 20221005 MOD START Y.ARAKAKI 2022更改No③ 検索時のハイフンチェック削除対応 
  //if ((strTel.match(/^[0-9]+\-[0-9]+\-[0-9]+$/) == null) && 
  if ((strTel.match(/^[0-9\-]+$/) == null) && 
        (strTel.match(/^[0-9]+$/) == null) && (strTel.length!=0)) {
  // 20221005 MOD END Y.ARAKAKI 2022更改No③ 検索時のハイフンチェック削除対応 

        return false;
  }
  return true;
}
//市内のみ入力用
function fncChkTelIn(strTel) {
  if ((strTel.match(/^[0-9]+\-[0-9]+$/) == null) 
  && (strTel.length!=0)&&(strTel.match(/^[0-9]+$/) == null)) {
    return false;
  }
  return true;
}
