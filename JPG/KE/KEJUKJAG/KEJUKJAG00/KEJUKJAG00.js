window.onunload = function () {
    //ウインドウ閉じるときに、開いているポップアップを一緒に閉じる
    if (wP != null && wP.closed == false) {
        wP.close();
    }
}
//**********************************
//ポップアップ用
//*********************************
var wP;
function fncPop(strId){
	//2014/10/15 H.Hosoda add 2014改善開発 No20 START
    var nowday = new Date();
    var name = "KEJUKJAG00_" + nowday.getFullYear() + nowday.getMonth() + nowday.getDate() + nowday.getHours() + nowday.getMinutes() + nowday.getSeconds();
	//2014/10/15 H.Hosoda add 2014改善開発 No20 END	

	if (wP == null||wP.closed== true) {
        //wP = parent.fncPopupOpen(); //2014/10/15 H.Hosoda mod 2014改善開発 No20
	    //wP = parent.fncPopupOpen(name);  //2015/11/02 w.ganeko mod 2015改善開発 №9
        //2016/11/16 H.Mori add 2016改善開発 No1-1 START
	    //wP = parent.fncPopupOpen(name, 1100, 800);
	    if (strId == "KEJUKJOG00") {
	        wP = window.open("", name, "toolbar=no,location=no,menubar=no,top=1000,left=1000,width=" + 1 + ",height=" + 1 + ",scrollbars=yes");
	    }
	    else {
	        wP = parent.fncPopupOpen(name, 1100, 800);
	    }
	    //2016/11/16 H.Mori add 2016改善開発 No1-1 END
	} else {
        wP.close();
        wP = null;
        //wP = parent.fncPopupOpen(name);  //2015/11/02 w.ganeko mod 2015改善開発 №9 
        wP = parent.fncPopupOpen(name, 1100, 800);
    }
	wP.focus();
	Form1.hdnKensaku.value=strId;
	//Form1.target = "wP" //2014/10/15 H.Hosoda mod 2014改善開発 No20
	Form1.target = name;
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""
}
//**********************************
//アラート出力画面
//*********************************
function fncAlert_output() {
	fncPop('KEJUKJOG00');
}
//**********************************
//欠損一覧ボタンを押下
//*********************************
function btnKeson_onclick(obj) {
	fncPop('KEKESJAG00');
}
//2015/11/02 w.ganeko 2015改善開発 №9 start
//**********************************
//担当者一覧ボタンを押下
//*********************************
function btnTanto_onclick(obj) {
    fncPop('MSTASJAG00');
}
//2015/11/02 w.ganeko 2015改善開発 №9 end
//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
	var strRes;
	strRes = confirm("終了してよろしいですか？");
	if (strRes==false){
		return;
	}
	var strURL;
	strURL="about:blank";
	parent.frames("Recv").location=strURL;
	strURL="../../../COGMENUG00.aspx";
	parent.frames("data").location=strURL;		
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	Form1.target="Recv"
	__doPostBack(strCtl,strFlg); 
	Form1.target=""
}
//**************************************
//警報データチェック
//**************************************
function fncDataCheck() {
	Form1.hdnKensaku.value="KEJUKJKG00";
	Form1.target="Recv"
	Form1.submit();
	Form1.hdnKensaku.value="";
	Form1.target=""
}
//**************************************
//最初押下
//**************************************
function btnFirst_onclick() {
	//オブジェクトに対するロック処理
	fncBtnRoc(Form1.btnFirst);
	doPostBack('btnFirst',''); 
}
//**************************************
//前押下
//**************************************
function btnPre_onclick() {
	//オブジェクトに対するロック処理
	fncBtnRoc(Form1.btnPre);
	doPostBack('btnPre',''); 
}
//**************************************
//次押下
//**************************************
function btnNex_onclick() {
	//オブジェクトに対するロック処理
	fncBtnRoc(Form1.btnNex);
	doPostBack('btnNex','');
}
//**************************************
//最後押下
//**************************************
function btnEnd_onclick() {
	//オブジェクトに対するロック処理
	fncBtnRoc(Form1.btnEnd);
	doPostBack('btnEnd','');

}
//**************************************
//最新表示押下
//**************************************
function btnRenew_onclick() {
	//オブジェクトに対するロック処理
	fncBtnRoc(Form1.btnRenew);
	doPostBack('btnRenew',''); 
}
//**************************************
//監視用画面の出力
//**************************************
function fncDispKansi() {
	//spS1.style.visibility="hidden";	//メニューに追加した為(監視用として)終了ボタンを出力する
	spB1.style.visibility="hidden";
	spB2.style.visibility="hidden";
	spB3.style.visibility="hidden";
    spB11.style.visibility = "hidden";
    spB22.style.visibility = "hidden";
    spB33.style.visibility = "hidden";
    //2019/11/01 W.GANEKO 2019改善開発 START
    spB4.style.visibility = "hidden";
    spB5.style.visibility = "hidden";
    spB6.style.visibility = "hidden";
    spB44.style.visibility = "hidden";
    spB55.style.visibility = "hidden";
    spB66.style.visibility = "hidden";
    //2019/11/01 W.GANEKO 2019改善開発 END
	spK1.style.visibility = "hidden";
	spchk.style.visibility = "hidden";  //2013/12/13 T.Ono add 監視改善2013
	spK2.style.visibility = "hidden";   //2015/11/02 w.ganeko 2015監視改善 №9
}
//**************************************
//ロック解除ボタン押下
//**************************************
function btnNOROC_onclick(ind) {
    //2019/11/01 w.ganeko 2019監視改善 No 3,4 start
    var strRes;
    strRes = confirm('ロック解除しても宜しいですか？');
    if (strRes == false) {
        return;
    }
    //2019/11/01 w.ganeko 2019監視改善 No 3,4 end
	with(Form1){
		//オブジェクトに対するロック処理
		fncBtnRoc(document.Form1.elements['btn' + ind + 'ROC']);
		hdnINDEX.value = ind;
		hdnKEY_SERIAL.value = document.Form1.elements['hdn' + ind + 'SERIAL'].value;
		hdnKensaku.value="KEJUKJRG00";
		target="Recv"
		submit();
		hdnKensaku.value="";
		target=""
	}
}
//**************************************
//緊急対応ボタン押下
//**************************************
function btnROC_onclick(ind) {
	with(Form1){
	    hdnBtmOukaFlg.value = "1";   //2014/01/20 T.Ono
        //オブジェクトに対するロック処理
		fncBtnRoc(document.Form1.elements['btn' + ind + 'TAIOU']);
		hdnINDEX.value = ind;
		hdnKEY_SERIAL.value = document.Form1.elements['hdn' + ind + 'SERIAL'].value;
		hdnKensaku.value="KEJUKJNG00";
		target="Recv"
		submit();
		hdnKensaku.value="";
		target=""
	}
}
//**********************************
//対応入力画面へ移動
//*********************************
function fncMove_taijag() {
	with(Form1){
		hdnKensaku.value="KETAIJAG00";
		submit();
		hdnKensaku.value="";
	}	
}
//**********************************
//監視エラー履歴出力
//*********************************
var wM;
function fncMessage() {
	var strMsg;
	dtDate = new Date();
	strMsg = dtDate.getFullYear() + '/' + dtDate.getMonth() + '/' + dtDate.getDate() + ' ' + dtDate.getHours() + ':' + dtDate.getMinutes() + ':' + dtDate.getSeconds();
	if (wM == null||wM.closed== true) {
		wM = window.open("","","width=400,height=200");
	}
	wM.document.open("text/html");
	wM.document.write("<html>")
	wM.document.write("<style>")
	wM.document.write("BODY { FONT-SIZE: 12px; BACKGROUND-COLOR: cornsilk ; margin-top:0px }")
	wM.document.write("TD   { border-style:none }")
	wM.document.write(".tit { FONT-SIZE: 22px; FONT-STYLE: oblique; COLOR: RED}")
	wM.document.write(".msg { FONT-SIZE: 13px; COLOR: RED}")
	wM.document.write(".btn { WIDTH: 80px; HEIGHT: 25px;background-color:ButtonFace }")
	wM.document.write("</style>")
	wM.document.write("<title>受信警報表示パネル監視エラー</title>")
	wM.document.write("<body onload='btnClose.focus();'><center>")
	wM.document.write("<table width='350'>")
	wM.document.write("<tr><td height='20'>&nbsp;</td></tr>")
	wM.document.write("<tr><td align='center' class='tit'>受信警報表示パネル監視エラー</td></tr>")
	wM.document.write("<tr><td align='center' class='msg'>" + strMsg + "&nbsp;：&nbsp;警報監視時にエラーが発生しました。</td></tr>")
	wM.document.write("<tr><td align='center' class='msg'><br>警報受信パネル監視用ページが見つかりません。<br>サーバーを確認して下さい。</td></tr>")
	wM.document.write("<tr><td height='20'>&nbsp;</td></tr>")
	wM.document.write("<tr><td align='center'><input class='btn' name='btnClose' type='button' value='閉じる' onclick='window.close();'></td></tr>")
	wM.document.write("</table>")
	wM.document.write("</center></body>")
	wM.document.write("</html>")
	wM.document.close();
}
//**********************************
//アラート画面削除
//*********************************
function fncMessage_delete() {
	//ウィンドウが開いていれば閉じる
	if (wM != null){
		//閉じる
		wM.close();
		wM=null;
	}
}
//**********************************
//イベントボタンに対してロックをかける
//*********************************
function fncBtnRoc(obj) {
	with(Form1){
		btn1TAIOU.disabled = true;
		btn2TAIOU.disabled = true;
        btn3TAIOU.disabled = true;
		btn1ROC.disabled=true;
		btn2ROC.disabled=true;
		btn3ROC.disabled=true;
        //2019/11/01 W.GANEKO 2019監視改善 No 3,4 START
        btn4TAIOU.disabled = true;
        btn5TAIOU.disabled = true;
        btn6TAIOU.disabled = true;
        btn4ROC.disabled = true;
        btn5ROC.disabled = true;
        btn6ROC.disabled = true;
        //2019/11/01 W.GANEKO 2019監視改善 No 3,4 END
		btnFirst.disabled=true;
		btnPre.disabled=true;
		btnNex.disabled=true;
		btnEnd.disabled=true;
		btnRenew.disabled=true;
		btnTanto.disabled = true; //2015/11/02 w.ganeko 2015改善開発 №9
    }
	fncFo(obj,5);
}
//**********************************
//チェックボックスクリックイベント　2013/12/19 T.Ono add 監視改善
//チェック状態の取得　0：チェックなし　1：チェックあり
//*********************************
function fncchkclick(obj, ind) {
    with (Form1) {

        if (ind == "0") {
            //自動更新
            if (obj.checked) {
                hdnJido.value = "1";
            } else {
                hdnJido.value = "0";
            }
        } else if (ind == "1") {
            //未処理のみ
            if (obj.checked) {
                hdnMishori.value = "1";
            } else {
                hdnMishori.value = "0";
            }
        } else {
        }
        btnRenew_onclick();
    }
}
//**********************************
//データ受信フレームの一定時間の更新をチェック　2013/12/19 T.Ono add 監視改善2013
//対応入力用　
//********************************* 
function fncCheck_retry2() {

    if (document.getElementById('hdnJido').value == '0') {
        //自動更新にチェックのない場合は抜ける
        return;
    }
    //2014/01/20 T.Ono add 監視改善2013
    if (document.getElementById('hdnBtmOukaFlg').value == '1') {
        //緊急対応ボタン押下時は抜ける
        return;
    }

    var s = 'try{ parent.Recv.document.location.href }catch(kl_err){ 0 }';
    if (!eval(s)) {
        fncDataCheck();
        fncMessage();
    } else {
        obj = parent.Recv.document.getElementById('hdnDummy');
        if (obj == null) {
            fncDataCheck();
            fncMessage();
        }
    }
}

