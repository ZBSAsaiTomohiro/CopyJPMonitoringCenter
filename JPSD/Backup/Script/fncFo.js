//==================================================
//�p�r�F�t�H�[�J�X�擾��,�r�����ɔw�i�F��ς���
//�����Fobj   �F��ς���I�u�W�F�N�g
//�����Fcolor �ύX����F�B1:���ʐF 2:�A�N�e�B�u�F 3:�K�{�F 4:�w�i�F 5:�{�^���̐F
//==================================================
function fncFo(obj,intColor){
  //�p�����[�^�̐F�w�萔�l�ɂ��A�F��ݒ�
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
  
  //�e�L�X�g�{�b�N�X��������
  if(obj.type=="text"){ 
    //�ǎ��p��������
    if(obj.readOnly==true){
      //�������Ȃ��ŏI��
      return;
    } else {
      //�t�H�[�J�X���擾�������{���͉\�e�L�X�g�̏ꍇ
      if(intColor==2) {
        obj.select();
      }
    }
  }
    //�F���w�肳�ꂽ���̂ɕύX
    obj.style.backgroundColor=strColor;
}
//==================================================
//�p�r�F�G���^�[�L�[�ɂ��t�H�[�J�X�ړ�
//�����Fobj
//==================================================
function fncFc(obj){
  var obj=window.event.srcElement;
  //�G���^�[�L�[���������ꂽ��
  if(event.keyCode == 13) {
    event.keyCode = 9;
  }
}
