//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
    var strRec;
    strRes = confirm("終了してもよろしいですか？");
    if (strRes == false) {
        return;
    }
    var str = document.getElementById("txtRENTEL2").value;
    while (str.indexOf("-", 0) != -1) {
        str = str.replace("-","");
    }
    parent.opener.frames('data').Form1.hdnRENTEL2.value = str;
    parent.opener.frames('data').Form1.hdnRENTEL2_BIKO.value = document.getElementById("txtRENTEL2_BIKO").value;
    var str = document.getElementById("txtRENTEL3").value;
    while (str.indexOf("-", 0) != -1) {
        str = str.replace("-", "");
    }
    parent.opener.frames('data').Form1.hdnRENTEL3.value = str;
    parent.opener.frames('data').Form1.hdnRENTEL3_BIKO.value = document.getElementById("txtRENTEL3_BIKO").value;
    var rdoJVG = null;
    obj = document.getElementById("rdoTel1_2");
    if (obj.checked == true) { // チェックあり！
        rdoJVG = "2";
    }
    //電話２
    obj = document.getElementById("rdoTel1_3");
    if (obj.checked == true) { // チェックあり！
        rdoJVG = "3";
    }
    //2016/12/13 H.Mori add 2016改善開発 No5-1 START
    obj = document.getElementById("rdoTel_AB");
    if (obj.checked == true) { // チェックあり！
        rdoJVG = "4";
    }
    obj = document.getElementById("rdoTel_DAI3");
    if (obj.checked == true) { // チェックあり！
        rdoJVG = "5";
    }
    //2016/12/13 H.Mori add 2016改善開発 No5-1 END
    parent.opener.frames('data').Form1.hdnTelJVG.value = rdoJVG;
    parent.opener.frames('data').Form1.btnTelHas2.focus();
    window.close();
}
//**************************************
//電話発信
//**************************************
function fncDial_Tel() {

    var strTel
    var strAite
    var strObj
    //電話１
    obj = document.getElementById("rdoTel1_2");
    if (obj.checked == true) { // チェックあり！
        strTel = document.getElementById("txtRENTEL2").value;
        strAite = document.getElementById("txtRENTEL2_BIKO").value;
        strObj = document.getElementById("txtRENTEL2");
    }
    //電話２
    obj = document.getElementById("rdoTel1_3");
    if (obj.checked == true) { // チェックあり！
        strTel = document.getElementById("txtRENTEL3").value;
        strAite = document.getElementById("txtRENTEL3_BIKO").value;
        strObj = document.getElementById("txtRENTEL3");
    }
    //電話番号    2016/12/13 H.Mori add 2016改善開発 No5-1 
    obj = document.getElementById("rdoTel_AB");
    if (obj.checked == true) { // チェックあり！
        strTel = document.getElementById("txtTELAB").value;
        strAite = "";
        strObj = document.getElementById("txtTELAB");
    }
    //第3連動連絡先    2016/12/13 H.Mori add 2016改善開発 No5-1 
    obj = document.getElementById("rdoTel_DAI3");
    if (obj.checked == true) { // チェックあり！
        strTel = document.getElementById("txtDAI3RENDORENTEL").value;
        strAite = "";
        strObj = document.getElementById("txtDAI3RENDORENTEL");
    }

    //電話番号必須チェック
    if (strTel.length == 0) {
        alert('電話番号がありません');
        strObj.focus();
        return;
    }
    //電話番号チェック
    if (fncChkTel(strTel) == false) {
        alert("電話番号が正しくありません");
        strObj.focus();
        return;
    }
    var strRec;
    strRes = confirm("電話発信してよろしいですか？");
    if (strRes == false) {
        return;
    }
    var str = document.getElementById("txtRENTEL2").value;
    while (str.indexOf("-", 0) != -1) {
        str = str.replace("-", "");
    }
    parent.opener.frames('data').Form1.hdnRENTEL2.value = str;
    parent.opener.frames('data').Form1.hdnRENTEL2_BIKO.value = document.getElementById("txtRENTEL2_BIKO").value;
    var str = document.getElementById("txtRENTEL3").value;
    while (str.indexOf("-", 0) != -1) {
        str = str.replace("-", "");
    }
    parent.opener.frames('data').Form1.hdnRENTEL3.value = str;
    parent.opener.frames('data').Form1.hdnRENTEL3_BIKO.value = document.getElementById("txtRENTEL3_BIKO").value;
    
    //2016/12/13 H.Mori add 2016改善開発 No5-1 START
    var str = document.getElementById("txtTELAB").value;
    while (str.indexOf("-", 0) != -1) {
        str = str.replace("-", "");
    }
    parent.opener.frames('data').Form1.hdnTELAB.value = str;
    var str = document.getElementById("txtDAI3RENDORENTEL").value;
    while (str.indexOf("-", 0) != -1) {
        str = str.replace("-", "");
    }
    parent.opener.frames('data').Form1.hdnDAI3RENDORENTEL.value = str;
        //parent.opener.frames('data').Form1.hdnRENTEL2_BIKO.value = document.getElementById("txtRENTEL2_BIKO").value;
    //2016/12/13 H.Mori add 2016改善開発 No5-1 END

    var rdoJVG = null;
    obj = document.getElementById("rdoTel1_2");
    if (obj.checked == true) { // チェックあり！
        rdoJVG = "2";
    }
    obj = document.getElementById("rdoTel1_3");
    if (obj.checked == true) { // チェックあり！
        rdoJVG = "3";
    }
    //2016/12/13 H.Mori add 2016改善開発 No5-1 START
    obj = document.getElementById("rdoTel_AB");
    if (obj.checked == true) { // チェックあり！
        rdoJVG = "4";
    }
    obj = document.getElementById("rdoTel_DAI3");
    if (obj.checked == true) { // チェックあり！
        rdoJVG = "5";
    }
    //2016/12/13 H.Mori add 2016改善開発 No5-1 END

    parent.opener.frames('data').Form1.hdnTelJVG.value = rdoJVG;
    strTel = strTel.replace("-", "").replace("-", "");
    //ログの整合性を合わせる為に親画面の電話発信機能を使用する
    //parent.opener.frames('data').btnDial_onclick('3', strTel, strAite);
    parent.opener.frames('data').btnDial_onclick('4', strTel, strAite);
    document.getElementById("btnTelHas").focus();

    //カーソルはポップアップにセットしておく
    //parent.opener.frames('data').Form1.btnTelHas2.focus();
    //window.close();
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl, strFlg) {
    __doPostBack(strCtl, strFlg);
}
//**************************************
//選択
//**************************************
function fncDataEnt() {
    //連絡先2
    var strObj = document.getElementById("txtRENTEL2");
    var strTel = document.getElementById("txtRENTEL2").value;
    if (strTel.length != 0) {
        if (fncChkTel(strTel) == false) {
            alert("連絡先2は正しい電話番号ではありません");
            strObj.focus();
            return false;
        }
    }
    //連絡先3
    strObj = document.getElementById("txtRENTEL3");
    strTel = document.getElementById("txtRENTEL3").value;
    if (strTel.length != 0) {
        if (fncChkTel(strTel) == false) {
            alert("連絡先3は正しい電話番号ではありません");
            strObj.focus();
            return false;
        }
    }
    strObj = document.getElementById("txtRENTEL2_BIKO");
    var strBiko = document.getElementById("txtRENTEL2_BIKO").value;
    if (strBiko.length != 0) {
        if (fncGetByte(strBiko) > 24) {
            alert("文字数がオーバーしています：連絡先2備考\r\n24バイト以内で入力して下さい");
            strObj.focus();
            return false;
        }
        if (fnc_byteCheck2(strObj)) {
            alert("タブが入力されています：連絡先2備考\n\nタブの入力はできません。削除してください。");
            strObj.focus();
            return false;
        }
    }
    strObj = document.getElementById("txtRENTEL3_BIKO");
    strBiko = document.getElementById("txtRENTEL3_BIKO").value;
    if (strBiko.length != 0) {
        if (fncGetByte(strBiko) > 24) {
            alert("文字数がオーバーしています：連絡先3備考\r\n24バイト以内で入力して下さい");
            strObj.focus();
            return false;
        }
        if (fnc_byteCheck2(strObj)) {
            alert("タブが入力されています：連絡先3備考\n\nタブの入力はできません。削除してください。");
            strObj.focus();
            return false;
        }
    }
    var strRec;
    strRes = confirm("登録してもよろしいですか？");
    if (strRes == false) {
        return;
    }
    document.getElementById("hdnKensaku").value = "1";
    doPostBack('btnTelEnt', '');
}
function fnc_byteCheck2(obj) {

    if (obj.value.length > 0) {
        var ss = obj.value;
        var wk = "";
        var es = "";
        var arr = new Array("", "", "", "");
        var arrcnt = new Array(0, 0, 0, 0);
        var cnt = 0;
        var row = 0;

        for (i = 0; i < ss.length; i++) {
            wk = ss.substring(i, i + 1);
            es = escape(wk);
            if (es.charAt(0) == "%") {
                if (es == "%09") {
                    /* タブ \t */
                    /* →見た目の大きさが一定でないため、禁止とする */
                    return true;
                }
            }
        }
    }
    return false;
}
function fnc_bikoCheck(obj,flg) {
    var strBiko = obj.value;
    var strBikoNm = null;
    if(flg == 2){
       strBikoNm = "連絡先2備考"
    } else if(flg == 3){
       strBikoNm = "連絡先3備考"
    }
    if (strBiko.length != 0) {
        if (fncGetByte(strBiko) > 24) {
            alert("文字数がオーバーしています：" + strBikoNm + "\r\n24バイト以内で入力して下さい");
            obj.focus();
            return false;
        }
        if (fnc_byteCheck2(obj)) {
            alert("タブが入力されています：" + strBikoNm + "\n\nタブの入力はできません。削除してください。");
            obj.focus();
            return false;
        }
    }
    return true;
}