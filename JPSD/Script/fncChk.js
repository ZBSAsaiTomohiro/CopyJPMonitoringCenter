//==================================================
//用途：入力不可能文字をチェックする
//引数：
//戻値：
//==================================================
function fncChkChar(){
//Form内のオブジェクト数分のループ
	for(i=0;i<Form1.elements.length;i++){
			//テキストボックスか、テキストエリアであれば
			if(Form1.elements[i].type=='text'||Form1.elements[i].type=='textarea'){
				//入力禁止文字チェック
				if(Form1.elements[i].value.match(/&/m)||Form1.elements[i].value.match(/\?/m)||Form1.elements[i].value.match(/'/m)||Form1.elements[i].value.match(/"/m)||Form1.elements[i].value.match(/</m)||Form1.elements[i].value.match(/>/m)){
						var str="「'」";
						alert(str+'、「&」、「"」、「?」、「<」、「>」の文字は使用できません');
						Form1.elements[i].focus();
						Form1.elements[i].select();
						return false;
				}
			}
		}
}
