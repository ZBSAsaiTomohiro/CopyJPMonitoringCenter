//**************************************
//��ʐ؂�ւ�
//**************************************
function fncJumpURL(strId){
	Form1.hdnJUMP.value=strId;
   	Form1.target="_parent";
	Form1.submit();
	Form1.hdnJUMP.value="";
	Form1.target=""				
}
//**************************************
//������Ώۓ`�[�ԍ��Ƃ��ďƉ��ʂ�
//**************************************
function fncJump(strKANSCD,strSYONO){
	Form1.hdnKEY_KANSCD.value = strKANSCD;
    Form1.hdnKEY_SYONO.value = strSYONO;

    Form1.hdnScrollTop.value = document.body.scrollTop; //�X�N���[���ʒu�@2013/12/11 T.Ono add �Ď����P2013

	fncJumpURL("SDSYUJAG00");
}