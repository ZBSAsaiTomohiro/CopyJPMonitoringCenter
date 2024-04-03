//==================================================
//用途：フォーカス取得時,喪失時に背景色を変える
//引数：obj   色を変えるオブジェクト
//引数：color 変更する色。1:普通色 2:アクティブ色 3:必須色 4:背景色 5:ボタンの色
//==================================================
function fncFo(obj,intColor){
  //パラメータの色指定数値により、色を設定
  if(intColor==1){
    strColor="white"
  } else if(intColor==2){
    strColor="yellow"
  } else if(intColor==3){
    strColor="LightPink"
  } else if(intColor==4){
    strColor="cornsilk"
  } else if(intColor==5){
    strColor="ButtonFace"
  } else if(intColor==6){
    strColor="e0ffff"
  }
  
  //テキストボックスだったら
  if(obj.type=="text"){ 
    //読取専用だったら
    if(obj.readOnly==true){
      //何もしないで終了
      return;
    } else {
      //フォーカスを取得した時＋入力可能テキストの場合
      if(intColor==2) {
        obj.select();
      }
    }
  }
    //色を指定されたものに変更
    obj.style.backgroundColor=strColor;
}
//==================================================
//用途：エンターキーによりフォーカス移動
//引数：obj
//==================================================
function fncFc(obj){
  var obj=window.event.srcElement;
  //エンターキーが押下された時
  if(event.keyCode == 13) {
    event.keyCode = 9;
  }
}
