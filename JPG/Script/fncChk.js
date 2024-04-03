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
			//20050729 NEC ADD START
			if(Form1.elements[i].id=='txtRYURYO'){return true;}
			//20050729 NEC ADD END
			// 2011.11.08 ADD H.Uema Start
			if (Form1.elements[i].id == 'txtGUIDELINE') {return true;}
			// 2011.11.08 ADD H.Uema End
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

//==================================================
//用途：文字列null空チェック処理(null、""、undefinedの場合false(NG)、それ以外の場合はtrue(OK)を返却します。)
//引数：文字列
//戻値：boolean（true=文字列有、 false=文字列なし（undefined、null、空）
//==================================================
function fncChkBlunkStr(checkStr) {
    var resultChkStr = false;
    if (checkStr != undefined && checkStr != null && checkStr != "") {
        resultChkStr = true;
    }
    return resultChkStr;
}