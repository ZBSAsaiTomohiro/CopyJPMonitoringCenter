//==================================================
//用途：バイト数を返す関数
//引数：str		バイト数をカウントする文字列
//==================================================
function fncGetByte(str) { 
	var len,i; 
	len = 0; 
	str = escape(str); 
	for (i = 0; i< str.length; i++, len++) { 
		if (str.charAt(i) == "%") { 
			if (str.charAt(++i) == "u") {
				i += 3;
				len++;
			}
			i++;
		} 
	} 
	return len; 
} 

