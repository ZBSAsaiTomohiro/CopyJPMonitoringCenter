//==================================================
//用途：マウスがおいてあるオブジェクトの背景色を変える関数
//引数：id    色を変えるオブジェクトのID 
//引数：color 変更する色　
//引数：num   色を変える列の数
//適用イベント：onmouseout,onmouseover
//注意：列が複数ある場合、オブジェクト名の最後に
//    ＜順序番号＞+LPGを付加すること
//    例・・・aaa2LPG,aaa3LPG,aaa4LPG
//==================================================
function fncBG(id, color,num){
  if(document.all){
    document.all(id,0).style.backgroundColor = color;
    if (num >= 2){
      for(i = 2;i<=num;i++){
        document.all(id + i +'LPG',0).style.backgroundColor = color;
      }
    }
  }else if(document.getElementById){
    document.getElementById(id).style.backgroundColor = color;
    if (num >= 2){
      for(i = 2;i<=num;i++){
        document.getElementById(id + i +'LPG').style.backgroundColor = color;
      }
    }
  }
}
