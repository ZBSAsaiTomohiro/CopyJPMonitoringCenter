//**************************************
//�I���{�^���������̏���
//**************************************
function btnExit_onclick() {
    // 2009/01/23 T.Watabe edit
	//var strRes;
	//strRes = confirm("�I�����Ă�낵���ł����H");
	//if (strRes==false){
	//	return;
	//}
	parent.opener.frames('data').Form1.btnRireki.focus();	
	window.close();
}
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	Form1.target="ifList"
	__doPostBack(strCtl,strFlg); 
	Form1.target=""
}
//**************************************
//�ŏ�����
//**************************************
function btnFirst_onclick() {
	fncBtnRoc(Form1.btnFirst);
	doPostBack('btnFirst',''); 
}
//**************************************
//�O����
//**************************************
function btnPre_onclick() {
	fncBtnRoc(Form1.btnPre);
	doPostBack('btnPre',''); 
}
//**************************************
//������
//**************************************
function btnNex_onclick() {
	fncBtnRoc(Form1.btnNex);
	doPostBack('btnNex','');
}
//**************************************
//�Ō㉟��
//**************************************
function btnEnd_onclick() {
	fncBtnRoc(Form1.btnEnd);
	doPostBack('btnEnd','');
}
//**********************************
//�C�x���g�{�^���ɑ΂��ă��b�N��������
//*********************************
function fncBtnRoc(obj) {
	with(Form1){
		btnExit.disabled=true;
		btnFirst.disabled=true;
		btnPre.disabled=true;
		btnNex.disabled=true;
		btnEnd.disabled=true;
	}
	fncFo(obj,5);
}
//**************************************
//�������
//**************************************
function btnPrint_onclick() {
	window.print();
}