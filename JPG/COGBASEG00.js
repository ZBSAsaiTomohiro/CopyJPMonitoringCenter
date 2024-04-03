//==================================================
//用途：メニューボタン押下時にリンクする処理
//引数：なし
//返値：なし
//==================================================
var strClick = '0';		//乱打制御フラグ
function fncClick(strMenu,strCmd){
	var strURL;
	if (strClick == '0') {
		strClick = '1';
		if (strMenu.length==10) {
			if (strMenu.substr(0,2)=='CO') {
				strURL=strMenu+".aspx";
			} else {
				strURL=strMenu.substr(0,2)+"/"+strMenu.substr(0,8)+"/"+strMenu+"/"+strMenu+".aspx";
			}
			if (strCmd.length>=0) {
				strURL = strURL + "?CLFLG=" + strCmd;
			}
			parent.frames("data").location=strURL;		
		}
	}
}
//==================================================
//用途：フォーカス取得時,喪失時に背景色を変える
//引数：obj		色を変えるオブジェクト
//引数：color	変更する色。1:普通色 2:アクティブ色 3:必須色 4:背景色 5:ボタンの色
//備考：引数パターンは通常画面と同じ、カラーのみ変更
//==================================================
function fncFo(obj,intColor){
	//パラメータの色指定数値により、色を設定
	if(intColor==2){
		strColor="yellow"		// onfocus
	} else if(intColor==5){
		strColor="Cyan"			// onblur
	} else if(intColor==6){
		strColor="ButtonFace"	// onblur
	}
	
	//色を指定されたものに変更
	obj.style.backgroundColor=strColor;
}
//==================================================
//用途：監視センターメニュー／監視センター管理メニューの画面を終了する
//
//
//
//==================================================
//function fncClick_Close() {
//	var strRes;
//	strRes = confirm("終了してよろしいですか？");
//	if (strRes==false){
//		return;
//	}
//	window.close();
//}
//

//==================================================
//用途：マスタ管理：ログインユーザーにより、ボタンの表示・非表示を制御 '2014/01/24 T.Ono add 監視改善2013
//引数：0：川口監視センター　1：沖縄監視センター
//==================================================
function fncDispMNMS(flg) {
    if (flg == '0') {
        //川口
        document.getElementById("btnMenu009").style.display = "none";
        document.getElementById("btnMenu010").style.display = "none";
    } else if (flg == '1') {
        //沖縄
        //document.getElementById("btnMenu005").style.display = "none"; //2014/10/02 T.Ono mod 2014改善開発 No19
        document.getElementById("btnMenu004").style.display = "none";
        document.getElementById("btnMenu009").style.display = "none";
        document.getElementById("btnMenu010").style.display = "none";
    }
}
//==================================================
//用途：マスタ一覧：ログインユーザーにより、ボタンの表示・非表示を制御 　'2014/02/26 T.Ono add 監視改善2013
//引数：0：監視センター
//==================================================
function fncDispMNML(flg) {
    if (flg == '0') {
        //監視センター
        //document.getElementById("btnMenu004").style.display = "none"; //2016/04/04 T.Ono mod 2015改善開発
        document.getElementById("btnMenu005").style.display = "none";
        //document.getElementById("btnMenu010").style.display = "none"; //2014/03/24 T.Ono del
    }
}
