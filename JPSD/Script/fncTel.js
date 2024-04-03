//==================================================
//用途：電話番号の入力値フォーマットチェック
//引数：入力値
//戻値：Boolean
//==================================================
function fncChkTel(strTel) {
  //----------------------2004/06/15変更　池田-------------------------
  //⇒ハイフンもＯＫとする為　[ＪＰミニ監視ＰＧ修正　No.61]
  //if ((strTel.match(/^[0-9]+\-[0-9]+\-[0-9]+$/) == null) && (strTel.length!=0)) {
  if ((strTel.match(/^[0-9]+\-[0-9]+\-[0-9]+$/) == null) && 
	  (strTel.match(/^[0-9]+$/) == null) && (strTel.length!=0)) {
  //------------------------------ここまで-----------------------------
    return false;
  }
  return true;
}
//市内のみ入力用
function fncChkTelIn(strTel) {
  if ((strTel.match(/^[0-9]+\-[0-9]+$/) == null) && (strTel.length!=0)) {
    return false;
  }
  return true;
}
