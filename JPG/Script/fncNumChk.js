﻿//==================================================
//用途：数値項目の整合性チェック
//引数：obj 入力された数値のテキストボックス
//戻値：数値以外の値である場合 false
//    正常な数値の場合 true
//使用イベント：実行ボタン押下時
//==================================================
function fncNumChk(strNum) {
	if ((strNum.length>0) && (strNum.match(/^[0-9]+$/) == null)) {
	    return false;
	}
	return true;
}
