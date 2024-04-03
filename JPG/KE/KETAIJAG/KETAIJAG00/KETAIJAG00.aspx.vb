'***********************************************
'�Ή�����  ���C�����
'***********************************************
' �ύX����
' 2008/10/24 T.Watabe  NCU�ڑ���SHAMAS�̒ʐM���[�h��\������悤�ɕύX
' 2008/10/29 T.Watabe  �x�񂩂�̏ꍇ�ɁA�Z���������؂�Ȃ��悤�ɑΉ�
' 2009/01/05 T.Watabe  �u0�`9�v�͂��̂܂܁A�u: ; < = > ?�v�͂��ꂼ��u10 11 12 13 14 15�v�ɒu�������A���̑��́u0�v
' 2009/02/17 T.Watabe  ��L�Ή��ɉ����āu0�`15�v�͂��̂܂܂Ƃ���B
' 2009/03/23 T.Watabe  T10_KEIHO��NCU�x�񔭐����E���Ԃ��Q�Ƃ���悤�ɕύX
' 2011/11/28 H.Uema    JA���ӎ����\���y��FAX�s�v�敪(�ײ���)�ݒ�Ή�
' 2011/12/01 H.Uema    FAX�s�v�敪(JA)�ݒ�Ή�
' 2013/05    T.Ono     �Ď����P2013�@�ڋq�P�ʓo�^�@�\�ǉ�
' 2013/08    T.Ono     �Ď����P2013�@��1�@��ʍ��ڒǉ���
' 2013/12    T.Ono     �Ď����P2013�@�\���p�l���ǉ����ځA�ڋq�������ǉ����ڂւ̖߂�l��ǉ�
' 2014/02    T.Ono     �Ď����P2013�@�d���\���Ή�
' 2014/12    T.Ono     2014���P�J���@��2
' 2019/11    W.GANEKO  2019���P�J���@��8-12
' 2020/11    T.Ono     2020�Ď����P
' 2021/10/01 saka      2021�N�x�Ď����P�A�̌x��ɂ�茴�����v���_�E���̃Z�b�g���e�𐧌䂷��̂́A����͂���Ή��敪�ƕ��������䂪����ł��Ȃ����߁A���ׂăR�����g��(�Ή��敪�̐���܂߂ĕ����̉\������)
' 2022/07/29 Y.ARAKAKI 2022�X��No8 (�����܂߂���s����) _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�
' 2023/01/04 Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 

Option Explicit On
Option Strict On

Imports Common
Imports Common.DB   '2019/11/01 w.ganeko 2019/11/01 2019�Ď����P
Imports JPG.Common

Imports System.Text
Imports System.Diagnostics
Imports System.IO
Imports JPG.Common.log

Partial Class KETAIJAG00
    Inherits System.Web.UI.Page
    '--- ��2005/04/20 ADD�@Falcon�� -----------------
    '--- ��2005/04/20 ADD�@Falcon�� -----------------
    '--- ��2005/05/19 ADD Falcon�� ---
    '--- ��2005/05/19 ADD Falcon�� ---
    '--- ��2005/09/09 ADD Falcon�� ---
    '--- ��2005/09/09 ADD Falcon�� ---



    ' 2008/10/31 T.Watabe add

    ' 2010/05/10 T.Watabe add
    '2012/03/26 START ADD W.GANEKO
    '2012/03/26 END ADD W.GANEKO


    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate
    '2010/05/10 T.Watabe add
    'Protected WithEvents Button1 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button2 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button3 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button4 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button5 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents Button6 As System.Web.UI.HtmlControls.HtmlInputButton
    'Protected WithEvents btnSearchTEL As System.Web.UI.HtmlControls.HtmlInputButton


    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' Render
    '******************************************************************************
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        MyBase.Render(writer)

        Dim strWrite As New StringBuilder("")

        strWrite.Append("<script language='JavaScript'>")
        strWrite.Append(strMsg.ToString())
        strWrite.Append("</script>")
        writer.Write(strWrite.ToString())
    End Sub

    '******************************************************************************
    '�o�^�n�t���[�����[�NPublic�ϐ��@�i�o�^�E�폜���Ɋi�[���܂��B�j
    '******************************************************************************
    Private strCBO_TAIOKBN As String
    Private strCBO_TMSKB As String
    Private strCBO_TAITCD As String
    Private strCBO_TELRCD As String
    Private strCBO_TFKICD As String
    Private strCBO_TKIGCD As String
    Private strCBO_TSADCD As String
    Private strCBO_SDCD As String
    '''''--------------------------
    Public gstrKBN As String
    Public gstrKANSCD As String
    Public gstrSYONO As String
    Public gstrNCUHATYMD As String ' 2008/10/15 T.Watabe add
    Public gstrNCUHATTIME As String ' 2008/10/15 T.Watabe add
    Public gstrHATYMD As String
    Public gstrHATTIME As String
    Public gstrKENSIN As String
    Public gstrKEIHOSU As String
    Public gstrRYURYO As String
    Public gstrMETASYU As String
    Public gstrUNYO As String
    Public gstrJUYMD As String
    Public gstrJUTIME As String
    Public gstrNUM_DIGIT As String
    Public gstrKMCD1 As String
    Public gstrKMNM1 As String
    Public gstrKMCD2 As String
    Public gstrKMNM2 As String
    Public gstrKMCD3 As String
    Public gstrKMNM3 As String
    Public gstrKMCD4 As String
    Public gstrKMNM4 As String
    Public gstrKMCD5 As String
    Public gstrKMNM5 As String
    Public gstrKMCD6 As String
    Public gstrKMNM6 As String
    Public gstrKURACD As String
    Public gstrKENNM As String
    Public gstrJACD As String
    Public gstrJANM As String
    Public gstrHANJICD As String '�̔����Ǝ҃R�[�h 2014/12/17 T.Ono add 2014���P�J�� No2 START
    Public gstrHANJINM As String '�̔����ƎҖ�     2014/12/17 T.Ono add 2014���P�J�� No2 START
    Public gstrACBCD As String
    Public gstrACBNM As String
    Public gstrUSER_CD As String
    Public gstrJUSYONM As String
    Public gstrJUSYOKN As String
    Public gstrJUTEL1 As String
    Public gstrJUTEL2 As String
    Public gstrRENTEL As String
    Public gstrKTELNO As String
    Public gstrADDR As String
    '--- ��2005/09/09 MOD Falcon�� ---
    'Public gstrUSER_KIJI As String
    Public gstrBIKOU As String
    '--- ��2005/09/09 MOD Falcon�� ---
    Public gstrNCU_SET As String
    Public gstrTIZUNO As String
    Public gstrHANBAI_KBN As String '�̔��敪 2015/11/25 H.Mori add 2015���P�J�� No1
    Public gstrKYOKTKBN As String   '�����`�ԋ敪 2016/12/02 H.Mori add 2016���P�J�� No4-3
    Public gstrMET_KATA As String
    Public gstrMET_MAKER As String
    Public gstrBONB1_KKG As String
    Public gstrBONB1_HON As String
    Public gstrBONB1_YOBI As String
    Public gstrBONB2_KKG As String
    Public gstrBONB2_HON As String
    Public gstrBONB2_YOBI As String
    Public gstrBONB3_KKG As String
    Public gstrBONB3_HON As String
    Public gstrBONB3_YOBI As String
    Public gstrBONB4_KKG As String
    Public gstrBONB4_HON As String
    Public gstrBONB4_YOBI As String
    Public gstrZENKAI_HAISO As String
    Public gstrZENKAI_HAI_S As String
    Public gstrKONKAI_HAISO As String
    Public gstrKONKAI_HAI_S As String
    Public gstrJIKAI_HAISO As String
    Public gstrZENKAI_KENSIN As String
    Public gstrZENKAI_KEN_S As String
    Public gstrZENKAI_KEN_SIYO As String
    Public gstrKONKAI_KENSIN As String
    Public gstrKONKAI_KEN_S As String
    Public gstrKONKAI_KEN_SIYO As String
    Public gstrZENKAI_HASEI As String
    Public gstrZENKAI_HAS_S As String
    Public gstrKONKAI_HASEI As String
    Public gstrKONKAI_HAS_S As String
    Public gstrG_ZAIKO As String
    Public gstrICHI_SIYO As String
    Public gstrYOSOKU_ICHI_SIYO As String
    Public gstrGAS1_HINMEI As String
    Public gstrGAS1_DAISU As String
    Public gstrGAS1_SEIFL As String
    Public gstrGAS2_HINMEI As String
    Public gstrGAS2_DAISU As String
    Public gstrGAS2_SEIFL As String
    Public gstrGAS3_HINMEI As String
    Public gstrGAS3_DAISU As String
    Public gstrGAS3_SEIFL As String
    Public gstrGAS4_HINMEI As String
    Public gstrGAS4_DAISU As String
    Public gstrGAS4_SEIFL As String
    Public gstrGAS5_HINMEI As String
    Public gstrGAS5_DAISU As String
    Public gstrGAS5_SEIFL As String
    Public gstrHATKBN As String
    Public gstrTAIOKBN As String
    Public gstrTMSKB As String
    Public gstrTKTANCD As String
    Public gstrTAITCD As String
    Public gstrTAIO_ST_DATE As String
    Public gstrTAIO_ST_TIME As String
    Public gstrSYOYMD As String
    Public gstrSYOTIME As String
    Public gstrTAIO_SYO_TIME As String
    Public gstrFAXKBN As String
    Public gstrFAXKURAKBN As String ' 2010/07/12 T.Watabe add
    Public gstrFAXRUISEKIKBN As String ' 2015/11/17 H.Mori add 2015���P�J�� No1
    Public gstrTELRCD As String
    Public gstrTFKICD As String
    Public gstrFUK_MEMO As String
    Public gstrTEL_MEMO1 As String
    Public gstrTEL_MEMO2 As String
    Public gstrTEL_MEMO4 As String  '2020/11/01 T.Ono add 2020�Ď����P
    Public gstrTEL_MEMO5 As String  '2020/11/01 T.Ono add 2020�Ď����P
    Public gstrTEL_MEMO6 As String  '2020/11/01 T.Ono add 2020�Ď����P
    Public gstrMITOKBN As String
    Public gstrTKIGCD As String
    Public gstrTSADCD As String
    Public gstrGENIN_KIJI As String
    Public gstrSDCD As String
    Public gstrSIJIYMD As String
    Public gstrSIJITIME As String
    Public gstrSIJI_BIKO1 As String
    Public gstrSIJI_BIKO2 As String
    Public gstrSTD_JASCD As String
    Public gstrSTD_JANA As String
    Public gstrSTD_JASNA As String
    Public gstrREN_CODE As String
    Public gstrREN_NA As String
    Public gstrREN_TEL_1 As String
    Public gstrREN_TEL_2 As String
    Public gstrREN_TEL_3 As String          ' 2013/05/27 T.Ono add
    Public gstrREN_FAX As String            '�e�`�w�ԍ��P
    Public gstrREN_BIKO As String
    Public gstrREN_EDT_DATE As String
    Public gstrREN_TIME As String
    Public gstrREN_1_CODE As String
    Public gstrREN_1_NA As String
    Public gstrREN_1_TEL1 As String
    Public gstrREN_1_TEL2 As String
    Public gstrREN_1_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_1_FAX As String          '�e�`�w�ԍ��Q
    Public gstrREN_1_BIKO As String
    Public gstrREN_1_EDT_DATE As String
    Public gstrREN_1_TIME As String
    Public gstrREN_2_CODE As String
    Public gstrREN_2_NA As String
    Public gstrREN_2_TEL1 As String
    Public gstrREN_2_TEL2 As String
    Public gstrREN_2_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_2_FAX As String          '�e�`�w�ԍ��R
    Public gstrREN_2_BIKO As String
    Public gstrREN_2_EDT_DATE As String
    Public gstrREN_2_TIME As String
    Public gstrREN_3_CODE As String
    Public gstrREN_3_NA As String
    Public gstrREN_3_TEL1 As String
    Public gstrREN_3_TEL2 As String
    Public gstrREN_3_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_3_FAX As String          '�e�`�w�ԍ��S
    Public gstrREN_3_BIKO As String
    Public gstrREN_3_EDT_DATE As String
    Public gstrREN_3_TIME As String

    '2008/10/31 T.Watabe add
    Public gstrREN_4_CODE As String          '�T
    Public gstrREN_4_NA As String
    Public gstrREN_4_TEL1 As String
    Public gstrREN_4_TEL2 As String
    Public gstrREN_4_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_4_FAX As String
    Public gstrREN_4_BIKO As String
    Public gstrREN_5_CODE As String          '�U
    Public gstrREN_5_NA As String
    Public gstrREN_5_TEL1 As String
    Public gstrREN_5_TEL2 As String
    Public gstrREN_5_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_5_FAX As String
    Public gstrREN_5_BIKO As String
    Public gstrREN_6_CODE As String          '�V
    Public gstrREN_6_NA As String
    Public gstrREN_6_TEL1 As String
    Public gstrREN_6_TEL2 As String
    Public gstrREN_6_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_6_FAX As String
    Public gstrREN_6_BIKO As String
    Public gstrREN_7_CODE As String          '�W
    Public gstrREN_7_NA As String
    Public gstrREN_7_TEL1 As String
    Public gstrREN_7_TEL2 As String
    Public gstrREN_7_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_7_FAX As String
    Public gstrREN_7_BIKO As String
    Public gstrREN_8_CODE As String          '�X
    Public gstrREN_8_NA As String
    Public gstrREN_8_TEL1 As String
    Public gstrREN_8_TEL2 As String
    Public gstrREN_8_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_8_FAX As String
    Public gstrREN_8_BIKO As String
    Public gstrREN_9_CODE As String          '�P�O
    Public gstrREN_9_NA As String
    Public gstrREN_9_TEL1 As String
    Public gstrREN_9_TEL2 As String
    Public gstrREN_9_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_9_FAX As String
    Public gstrREN_9_BIKO As String

    ' 2010/05/10 T.Watabe add
    Public gstrREN_10_CODE As String
    Public gstrREN_10_NA As String
    Public gstrREN_10_TEL1 As String
    Public gstrREN_10_TEL2 As String
    Public gstrREN_10_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_10_FAX As String
    Public gstrREN_10_BIKO As String
    Public gstrREN_11_CODE As String
    Public gstrREN_11_NA As String
    Public gstrREN_11_TEL1 As String
    Public gstrREN_11_TEL2 As String
    Public gstrREN_11_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_11_FAX As String
    Public gstrREN_11_BIKO As String
    Public gstrREN_12_CODE As String
    Public gstrREN_12_NA As String
    Public gstrREN_12_TEL1 As String
    Public gstrREN_12_TEL2 As String
    Public gstrREN_12_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_12_FAX As String
    Public gstrREN_12_BIKO As String
    Public gstrREN_13_CODE As String
    Public gstrREN_13_NA As String
    Public gstrREN_13_TEL1 As String
    Public gstrREN_13_TEL2 As String
    Public gstrREN_13_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_13_FAX As String
    Public gstrREN_13_BIKO As String
    Public gstrREN_14_CODE As String
    Public gstrREN_14_NA As String
    Public gstrREN_14_TEL1 As String
    Public gstrREN_14_TEL2 As String
    Public gstrREN_14_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_14_FAX As String
    Public gstrREN_14_BIKO As String
    Public gstrREN_15_CODE As String
    Public gstrREN_15_NA As String
    Public gstrREN_15_TEL1 As String
    Public gstrREN_15_TEL2 As String
    Public gstrREN_15_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_15_FAX As String
    Public gstrREN_15_BIKO As String
    Public gstrREN_16_CODE As String
    Public gstrREN_16_NA As String
    Public gstrREN_16_TEL1 As String
    Public gstrREN_16_TEL2 As String
    Public gstrREN_16_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_16_FAX As String
    Public gstrREN_16_BIKO As String
    Public gstrREN_17_CODE As String
    Public gstrREN_17_NA As String
    Public gstrREN_17_TEL1 As String
    Public gstrREN_17_TEL2 As String
    Public gstrREN_17_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_17_FAX As String
    Public gstrREN_17_BIKO As String
    Public gstrREN_18_CODE As String
    Public gstrREN_18_NA As String
    Public gstrREN_18_TEL1 As String
    Public gstrREN_18_TEL2 As String
    Public gstrREN_18_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_18_FAX As String
    Public gstrREN_18_BIKO As String
    Public gstrREN_19_CODE As String
    Public gstrREN_19_NA As String
    Public gstrREN_19_TEL1 As String
    Public gstrREN_19_TEL2 As String
    Public gstrREN_19_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_19_FAX As String
    Public gstrREN_19_BIKO As String
    Public gstrREN_20_CODE As String
    Public gstrREN_20_NA As String
    Public gstrREN_20_TEL1 As String
    Public gstrREN_20_TEL2 As String
    Public gstrREN_20_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_20_FAX As String
    Public gstrREN_20_BIKO As String
    Public gstrREN_21_CODE As String
    Public gstrREN_21_NA As String
    Public gstrREN_21_TEL1 As String
    Public gstrREN_21_TEL2 As String
    Public gstrREN_21_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_21_FAX As String
    Public gstrREN_21_BIKO As String
    Public gstrREN_22_CODE As String
    Public gstrREN_22_NA As String
    Public gstrREN_22_TEL1 As String
    Public gstrREN_22_TEL2 As String
    Public gstrREN_22_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_22_FAX As String
    Public gstrREN_22_BIKO As String
    Public gstrREN_23_CODE As String
    Public gstrREN_23_NA As String
    Public gstrREN_23_TEL1 As String
    Public gstrREN_23_TEL2 As String
    Public gstrREN_23_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_23_FAX As String
    Public gstrREN_23_BIKO As String
    Public gstrREN_24_CODE As String
    Public gstrREN_24_NA As String
    Public gstrREN_24_TEL1 As String
    Public gstrREN_24_TEL2 As String
    Public gstrREN_24_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_24_FAX As String
    Public gstrREN_24_BIKO As String
    Public gstrREN_25_CODE As String
    Public gstrREN_25_NA As String
    Public gstrREN_25_TEL1 As String
    Public gstrREN_25_TEL2 As String
    Public gstrREN_25_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_25_FAX As String
    Public gstrREN_25_BIKO As String
    Public gstrREN_26_CODE As String
    Public gstrREN_26_NA As String
    Public gstrREN_26_TEL1 As String
    Public gstrREN_26_TEL2 As String
    Public gstrREN_26_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_26_FAX As String
    Public gstrREN_26_BIKO As String
    Public gstrREN_27_CODE As String
    Public gstrREN_27_NA As String
    Public gstrREN_27_TEL1 As String
    Public gstrREN_27_TEL2 As String
    Public gstrREN_27_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_27_FAX As String
    Public gstrREN_27_BIKO As String
    Public gstrREN_28_CODE As String
    Public gstrREN_28_NA As String
    Public gstrREN_28_TEL1 As String
    Public gstrREN_28_TEL2 As String
    Public gstrREN_28_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_28_FAX As String
    Public gstrREN_28_BIKO As String
    Public gstrREN_29_CODE As String
    Public gstrREN_29_NA As String
    Public gstrREN_29_TEL1 As String
    Public gstrREN_29_TEL2 As String
    Public gstrREN_29_TEL3 As String         ' 2013/05/27 T.Ono add
    Public gstrREN_29_FAX As String
    Public gstrREN_29_BIKO As String
    '2012/03/26 START W.GANEKO
    Public gstrREN_MAIL As String
    Public gstrREN_1_MAIL As String
    Public gstrREN_2_MAIL As String
    Public gstrREN_3_MAIL As String
    Public gstrREN_4_MAIL As String
    Public gstrREN_5_MAIL As String
    Public gstrREN_6_MAIL As String
    Public gstrREN_7_MAIL As String
    Public gstrREN_8_MAIL As String
    Public gstrREN_9_MAIL As String
    Public gstrREN_10_MAIL As String
    Public gstrREN_11_MAIL As String
    Public gstrREN_12_MAIL As String
    Public gstrREN_13_MAIL As String
    Public gstrREN_14_MAIL As String
    Public gstrREN_15_MAIL As String
    Public gstrREN_16_MAIL As String
    Public gstrREN_17_MAIL As String
    Public gstrREN_18_MAIL As String
    Public gstrREN_19_MAIL As String
    Public gstrREN_20_MAIL As String
    Public gstrREN_21_MAIL As String
    Public gstrREN_22_MAIL As String
    Public gstrREN_23_MAIL As String
    Public gstrREN_24_MAIL As String
    Public gstrREN_25_MAIL As String
    Public gstrREN_26_MAIL As String
    Public gstrREN_27_MAIL As String
    Public gstrREN_28_MAIL As String
    Public gstrREN_29_MAIL As String
    Public gstrREN_MAILPASS As String
    Public gstrREN_1_MAILPASS As String
    Public gstrREN_2_MAILPASS As String
    Public gstrREN_3_MAILPASS As String
    Public gstrREN_4_MAILPASS As String
    Public gstrREN_5_MAILPASS As String
    Public gstrREN_6_MAILPASS As String
    Public gstrREN_7_MAILPASS As String
    Public gstrREN_8_MAILPASS As String
    Public gstrREN_9_MAILPASS As String
    Public gstrREN_10_MAILPASS As String
    Public gstrREN_11_MAILPASS As String
    Public gstrREN_12_MAILPASS As String
    Public gstrREN_13_MAILPASS As String
    Public gstrREN_14_MAILPASS As String
    Public gstrREN_15_MAILPASS As String
    Public gstrREN_16_MAILPASS As String
    Public gstrREN_17_MAILPASS As String
    Public gstrREN_18_MAILPASS As String
    Public gstrREN_19_MAILPASS As String
    Public gstrREN_20_MAILPASS As String
    Public gstrREN_21_MAILPASS As String
    Public gstrREN_22_MAILPASS As String
    Public gstrREN_23_MAILPASS As String
    Public gstrREN_24_MAILPASS As String
    Public gstrREN_25_MAILPASS As String
    Public gstrREN_26_MAILPASS As String
    Public gstrREN_27_MAILPASS As String
    Public gstrREN_28_MAILPASS As String
    Public gstrREN_29_MAILPASS As String
    '2012/03/26 END W.GANEKO

    Public gstrREN_DENWABIKO As String
    Public gstrREN_FAX_REN As String        '������
    Public gstrREN_FAXTITLE As String       '�e�`�w�^�C�g��
    Public gstrFAX_TITLE_CD As String       '�e�`�w�^�C�g���R�[�h   '2005/09/09 ADD Falcon
    Public gstrSTD_CD As String
    Public gstrSTD As String
    Public gstrSTD_KYOTEN_CD As String
    Public gstrSTD_KYOTEN As String
    Public gstrSTD_TEL As String
    Public gstrADD_DATE As String
    Public gstrEDT_DATE As String
    Public gstrTIME As String
    '//�Ή�DB�ǉ�����---------------
    Public gstrBOMB_TYPE As String
    Public gstrGAS_STOP As String
    Public gstrGAS_DELE As String
    Public gstrGAS_RESTART As String
    '2016/02/02 w.ganeko 2015���P�J�� ��1-3 start
    Public gstrKANSHI_BIKO As String
    Public gstrRENTEL2 As String
    Public gstrRENTEL2_BIKO As String
    Public gstrRENTEL2_UPD_DATE As String
    Public gstrRENTEL3 As String
    Public gstrRENTEL3_BIKO As String
    Public gstrRENTEL3_UPD_DATE As String
    Public gstrTelJVG As String
    Public gstrKBNMODE As String
    '2016/02/02 w.ganeko 2015���P�J�� ��1-3 end
    '2016/12/12 H.Mori 2016���P�J�� No5-1 START
    Public gstrTELAB As String
    Public gstrDAI3RENDORENTEL As String
    '2016/12/12 H.Mori 2016���P�J�� No5-1 END
    '2016/12/14 H.Mori add 2016�Ď����P No6-3 START
    Public gstrFAXSPOTKBN As String
    '2016/12/14 H.Mori add 2016�Ď����P No6-3 END
    '2016/12/22 H.Mori add 2016�Ď����P No4-6 START
    Public gstrDAIHYO_NAME As String
    Public gstrHOKBN As String
    Public gstrYOTOKBN As String
    Public gstrHANBCD As String
    Public gstrKINRENCD As String
    Public gstrJMNAME As String   ' 2023/01/04 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 
    '2016/12/22 H.Mori add 2016�Ď����P No4-6 END
    '2017/10/16 H.Mori add 2017���P�J�� No4-1 START
    Public gstrSHUGOU As String
    '2017/10/16 H.Mori add 2017���P�J�� No4-1 END

    '//-----------------------------
    '�d�b���M���O�o�^�p
    Public gstrDialKbns As String
    Public gstrDialNumbers As String
    Public gstrDialAites As String
    Public gstrDialResult As String
    Public gstrDialDates As String
    Public gstrDialTimes As String
    Public gstrDialStates As String
    Public gstrSDSKBN As String ' 2008/10/17 T.Watabe add
    Public gstrTUSIN As String ' 2008/10/24 T.Watabe add
    '�{���H����------------------
    Public gstrKAITU_DAY As String '2013/08/23 T.Ono add �Ď����P2013��1

#Region " Web �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    '���̌Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    '���� : ���̃v���[�X�z���_�錾�� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    '�폜����шړ����Ȃ��ł��������B
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: ���̃��\�b�h�Ăяo���� Web �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
        InitializeComponent()
    End Sub

#End Region

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                        Handles MyBase.Load

        '2012/04/04 NEC ou Add Str
        '.NET�̎d�l�ύX�ɂ��AReadOnly������ASPX�ł���ƁA�T�[�o����
        '�l�̎Q�Ƃ��ł��Ȃ��Ȃ邽�߁AVB����Attribute�ł���
        If MyBase.IsPostBack = False Then
            '------�y��M���z------
            txtNCUHATYMD.Attributes.Add("ReadOnly", "true")
            txtNCUHATTIME.Attributes.Add("ReadOnly", "true")
            txtHATYMD.Attributes.Add("ReadOnly", "true")
            txtHATTIME.Attributes.Add("ReadOnly", "true")
            txtUSER_FLG.Attributes.Add("ReadOnly", "true")
            txtKEIHOSU.Attributes.Add("ReadOnly", "true")
            txtRYURYO.Attributes.Add("ReadOnly", "true")
            txtMETASYU.Attributes.Add("ReadOnly", "true")
            txtKMSIN.Attributes.Add("ReadOnly", "true")
            txtKMNM1.Attributes.Add("ReadOnly", "true")
            txtKMNM2.Attributes.Add("ReadOnly", "true")
            txtKMNM3.Attributes.Add("ReadOnly", "true")
            txtKMNM4.Attributes.Add("ReadOnly", "true")
            txtKMNM5.Attributes.Add("ReadOnly", "true")
            txtKMNM6.Attributes.Add("ReadOnly", "true")
            txtClientCD.Attributes.Add("ReadOnly", "true")
            txtKENNM.Attributes.Add("ReadOnly", "true")
            txtACBNM.Attributes.Add("ReadOnly", "true")
            txtUSER_KIJI.Attributes.Add("ReadOnly", "true")
            txtHANGRP.Attributes.Add("ReadOnly", "true")
            txtKANSHI_BIKO.Attributes.Add("ReadOnly", "true")     '2016/02/02 w.ganeko add 2015���P�J�� ��1-3
            '------�y���q�l���z------
            txtTUSIN.Attributes.Add("ReadOnly", "true")
            txtMAP_CD.Attributes.Add("ReadOnly", "true")
            txtBOMB_TYPE.Attributes.Add("ReadOnly", "true")
            txtHANBAI_KBN.Attributes.Add("ReadOnly", "true") '2015/11/20 H.Mori add 2015���P�J�� No1
            txtKYOKTKBN.Attributes.Add("ReadOnly", "true") '2016/12/02 H.Mori add 2016���P�J�� No4-3
            txtMET_KATA.Attributes.Add("ReadOnly", "true")
            txtMET_MAKER.Attributes.Add("ReadOnly", "true")
            txtBONB1_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB1_HON.Attributes.Add("ReadOnly", "true")
            txtBONB1_RKG.Attributes.Add("ReadOnly", "true")
            txtBONB2_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB2_HON.Attributes.Add("ReadOnly", "true")
            txtBONB2_RKG.Attributes.Add("ReadOnly", "true")
            txtBONB3_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB3_HON.Attributes.Add("ReadOnly", "true")
            txtBONB3_RKG.Attributes.Add("ReadOnly", "true")
            txtBONB4_KKG.Attributes.Add("ReadOnly", "true")
            txtBONB4_HON.Attributes.Add("ReadOnly", "true")
            txtBONB4_RKG.Attributes.Add("ReadOnly", "true")
            txtG_ZAIKO.Attributes.Add("ReadOnly", "true")
            txtICHI_SIYO.Attributes.Add("ReadOnly", "true")
            txtYOSOKU_ICHI_SIYO.Attributes.Add("ReadOnly", "true")
            txtZENKAI_KENSIN.Attributes.Add("ReadOnly", "true")
            txtZENKAI_KEN_S.Attributes.Add("ReadOnly", "true")
            txtZENKAI_KEN_SIYO.Attributes.Add("ReadOnly", "true")
            txtKONKAI_KENSIN.Attributes.Add("ReadOnly", "true")
            txtKONKAI_KEN_S.Attributes.Add("ReadOnly", "true")
            txtKONKAI_KEN_SIYO.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HASEI.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAS_S.Attributes.Add("ReadOnly", "true")
            txtKONKAI_HASEI.Attributes.Add("ReadOnly", "true")
            txtKONKAI_HAS_S.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtZENKAI_HAI_S.Attributes.Add("ReadOnly", "true")
            txtKONKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtKONKAI_HAI_S.Attributes.Add("ReadOnly", "true")
            txtJIKAI_HAISO.Attributes.Add("ReadOnly", "true")
            txtGAS1_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS1_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS1_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS2_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS2_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS2_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS3_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS3_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS3_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS4_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS4_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS4_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS5_HINMEI.Attributes.Add("ReadOnly", "true")
            txtGAS5_DAISU.Attributes.Add("ReadOnly", "true")
            txtGAS5_SEIFL.Attributes.Add("ReadOnly", "true")
            txtGAS_START.Attributes.Add("ReadOnly", "true")
            txtGAS_DELE.Attributes.Add("ReadOnly", "true")
            txtGAS_RESTART.Attributes.Add("ReadOnly", "true")
            txtKAITU_DAY.Attributes.Add("ReadOnly", "true")         ' 2013/08/19 T.Ono add �Ď����P2013��1
            '------�y�Ή����z------
            txtHATKBN.Attributes.Add("ReadOnly", "true")
            txtTKTANCD.Attributes.Add("ReadOnly", "true")
            txtSYONO.Attributes.Add("ReadOnly", "true")
            txtSTD.Attributes.Add("ReadOnly", "true")
            txtSTD_KYOTEN.Attributes.Add("ReadOnly", "true")
            txtSTD_TEL.Attributes.Add("ReadOnly", "true")
            '------�y�f�[�^�C���`�F�b�N�{�b�N�X�z------             ' 2016/12/05 H.Mori add �Ď����P2016 No4-8
            txtJUYOKA.Attributes.Add("ReadOnly", "true")
            txtRENTEL.Attributes.Add("ReadOnly", "true")
            txtJUSYONM.Attributes.Add("ReadOnly", "true")
            txtJUSYOKN.Attributes.Add("ReadOnly", "true")
            txtJUTEL1.Attributes.Add("ReadOnly", "true")
            txtJUTEL2.Attributes.Add("ReadOnly", "true")
            txtADDR.Attributes.Add("ReadOnly", "true")
            '2019/11/01 w.ganeko 2019�Ď����P No6-12 start
            rdoMsg1.Attributes.Add("Disabled", "true")
            rdoMsg2.Attributes.Add("Disabled", "true")
            rdoMsg3.Attributes.Add("Disabled", "true")
            rdoMsg4.Attributes.Add("Disabled", "true")
            rdoMsg5.Attributes.Add("Disabled", "true")
            rdoMsg6.Attributes.Add("Disabled", "true")
            '2019/11/01 w.ganeko 2019�Ď����P No6-12 end
        End If
        '2012/04/04 NEC ou Add End

        'putlog("Page_Load 01")

        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load start")

        '//------------------------------------------
        '//�@�F�؏���
        '<TODO>�F�g�p�\�������w�肷��
        '[�v���_�E���}�X�^]�g�p�\����(�^:��/�c:�~/��:��/�o:�~)
        '2005/12/03 NEC UPDATE START
        '[�Ή�����]�g�p�\����(�^:��/�c:��/��:��/�o:�~)
        'AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI & "," & AuthC.pGROUP_EIGYOU)
        '2005/12/03 NEC UPDATE START

        '//------------------------------------------
        '���͕⏕�|�b�v�A�b�v���o�͂���
        If hdnKensaku.Value = "COPOPUPG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load COPOPUPG00 Server.Transfer=COPOPUPG00.aspx")
            Server.Transfer("../../../Popup/COPOPUPG00.aspx")
        End If
        '�Ή������Ɖ��ʂ��o�͂���(�|�b�v�A�b�v)
        If hdnKensaku.Value = "KETAIJRG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJRG00 Server.Transfer=KETAIJRG00.aspx")
            Server.Transfer("KETAIJRG00.aspx")
        End If
        '�A����I�����o��
        If hdnKensaku.Value = "KETAIJTG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJTG00 Server.Transfer=KETAIJTG00.aspx")
            Server.Transfer("KETAIJTG00.aspx")
        End If
        '�N���C�A���g�ɕR�Â��������擾����
        If hdnKensaku.Value = "KETAIJKG00_KEN" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_KEN Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '�i�`�ɕR�Â��o����Ђ������͘A���S���҂��擾����
        If hdnKensaku.Value = "KETAIJKG00_REN" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_REN Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '�i�`�ɕR�Â��o����ЁA�A���S���ҁA�̔����Ǝ҂��擾���� 2014/12/19 T.Ono add 2014���P�J�� No2
        If hdnKensaku.Value = "KETAIJKG00_REN_AND_HANGRP" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_REN_AND_HANGRP Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '�Ή��������E�������o�͂���
        If hdnKensaku.Value = "KETAIJKG00_TKN" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_TKN Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '�o���w�����E�������o�͂���
        If hdnKensaku.Value = "KETAIJKG00_SSJ" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJKG00_SSJ Server.Transfer=KETAIJKG00.aspx")
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '2017/10/18 H.Mori add 2017���P�J�� No4-3 START
        If hdnKensaku.Value = "KETAIJKG00_ROC_btnTelHas1" Then
            Server.Transfer("KETAIJKG00.aspx")
        End If
        If hdnKensaku.Value = "KETAIJKG00_ROC_btnTelHas2" Then
            Server.Transfer("KETAIJKG00.aspx")
        End If
        If hdnKensaku.Value = "KETAIJKG00_ROC_btnRenraku" Then
            Server.Transfer("KETAIJKG00.aspx")
        End If
        If hdnKensaku.Value = "KETAIJKG00_ROC_btnTKTANCD" Then
            Server.Transfer("KETAIJKG00.aspx")
        End If
        '2017/10/18 H.Mori add 2017���P�J�� No4-3 END
        '�R�s�[�⏕��ʂ��o�͂���(�|�b�v�A�b�v) 2013/08/19 T.Ono add �Ď����P2013��1
        If hdnKensaku.Value = "KETAIJUG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJUG00 Server.Transfer=KETAIJUG00.aspx")
            Server.Transfer("KETAIJUG00.aspx")
        End If
        '2016/02/02 w.ganeko 2015���P�J�� ��1-3 START
        If hdnKensaku.Value = "KETAIJVG00" Then
            gstrRENTEL2 = hdnRENTEL2.Value
            gstrRENTEL2_BIKO = hdnRENTEL2_BIKO.Value
            gstrRENTEL2_UPD_DATE = hdnRENTEL2_UPD_DATE.Value
            gstrRENTEL3 = hdnRENTEL3.Value
            gstrRENTEL3_BIKO = hdnRENTEL3_BIKO.Value
            gstrRENTEL3_UPD_DATE = hdnRENTEL3_UPD_DATE.Value
            gstrKURACD = txtClientCD.Text
            gstrACBCD = hdnJASCD.Value
            gstrUSER_CD = txtJUYOKA.Text
            gstrTelJVG = hdnTelJVG.Value
            gstrTELAB = hdnTELAB.Value '2016/12/12 H.Mori add 2016���P�J�� No5-1
            gstrDAI3RENDORENTEL = hdnDAI3RENDORENTEL.Value '2016/12/12 H.Mori add 2016���P�J�� No5-1
            If hdnBackUrl.Value = "MSKOSJAG00" Then
                '���p�Ҍ�����ʂ���̉�ʑJ�ڂ̏ꍇ
                If hdnMOVE_MODE.Value = "1" Then
                    'Dim strRes(6) As String  '2016/12/12 H.Mori add 2016���P�J�� No5-1
                    Dim strRes(9) As String
                    strRes = fncGetSHAMAS()
                    gstrRENTEL2 = strRes(0)
                    gstrRENTEL2_BIKO = strRes(1)
                    gstrRENTEL2_UPD_DATE = strRes(2)
                    gstrRENTEL3 = strRes(3)
                    gstrRENTEL3_BIKO = strRes(4)
                    gstrRENTEL3_UPD_DATE = strRes(5)
                    gstrTELAB = strRes(6) & strRes(7) '2016/12/12 H.Mori add 2016���P�J�� No5-1
                    gstrDAI3RENDORENTEL = strRes(8)     '2016/12/12 H.Mori add 2016���P�J�� No5-1
                End If
            End If
            If hdnBackUrl.Value = "KEKEKJAG00" Then
                gstrKBNMODE = "2"               '�C��
            Else
                gstrKBNMODE = "1"               '�o�^
            End If
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJVG00 Server.Transfer=KETAIJVG00.aspx")
            Server.Transfer("KETAIJVG00.aspx")
        End If
        '2016/02/02 w.ganeko 2015���P�J�� ��1-3 end

        '//------------------------------------------
        '// Script�����ݗp�ϐ��錾
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML���ɕK�v��JavaScript/CSS�͂�����[strScript]�ϐ��Ɋi�[��
        '      ��ʏ�[lblScript]�ɏ������݂��s���܂�(SPAN�^�O�Ƃ��ăN���C�A���g�ɃX�N���v�g��
        '      �o�͂���܂��B)
        '//------------------------------------------
        '//�@JavaScript�i�[
        strScript.Append("<Script language=javascript>")
        '<�Ǝ��X�N���v�g>
        strScript.Append(cscript1.mWriteScript(
                MyBase.MapPath("../../../KE/KETAIJAG/KETAIJAG00/") & "KETAIJAG00.js"))
        '<�t�H�[�J�X�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        '<���t�֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncDate.js"))
        '<�d�b�ԍ��`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTel.js"))
        '<���̓`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncChk.js"))
        '<���Ԋ֘A�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncTime.js"))
        '<�o�C�g���֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncGetByte.js"))
        '<�S�p�`�F�b�N�֐�>
        '--- ��2005/05/19 DEL Falcon�� ---
        'strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncZenkakuChk.js"))
        '--- ��2005/05/19 DEL Falcon�� ---
        '<�����`�F�b�N�֐�>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncNumChk.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//�@Css�i�[
        strScript.Append("<Style media='print'>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssPrint.css"))
        strScript.Append("</Style>")
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssSmall.css"))
        strScript.Append("</Style>")
        '//------------------------------------------

        '2010/10/27 T.Watabe add
        Dim strDivFaxKbnDisp As String = "[" & AuthC.pGROUPNAME & "][" & InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") & "]"
        strScript.Append("<!-- 2010/10/27 AD�̊Ď�������� " & strDivFaxKbnDisp & " -->" & vbCrLf)
        If InStr(AuthC.pGROUPNAME, "0�Ď��Ɩ��P��") > 0 Then ' �����򕌂̉�ʂɂ͕\�������Ȃ�
            'strScript.Append("<script language='javascript'>document.getElementById('divFaxKbnDisp1').style.display='none';document.getElementById('divFaxKbnDisp2').style.display='none';alert('test 2010/10/27 watabe');</script>" & vbCrLf)
            hdnOTHER_KANSI_CENTER.Value = "1"
        Else
            hdnOTHER_KANSI_CENTER.Value = "0"
        End If
        '//�@Script������
        lblScript.Text = strScript.ToString

        '//------------------------------------------
        '//  �Ď��Z���^�[�R�[�h�t���O
        hdnKANSFLG.Value = "0"

        '//------------------------------------------------------------------------------

        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//���߂ĊJ�������������s�����

            '�b�s�h���o�^�t���O(�֌W�̂Ȃ��J�ڂ̏ꍇ�̓Z�b�g���Ȃ�)
            hdnMOVE_MITOKBN.Value = ""

            '--- ��2005/05/19 ADD Falcon�� ---
            '�b�s�h�̎��ɒl���Z�b�g�i�����I��CTI���ǂ����𔻒f�j
            hdnCtiFlg.Value = ""
            '--- ��2005/05/19 ADD Falcon�� ---

            '�J�ڂ��Ă�����ʂ�ێ����J�ڌ���ʕʂ̏����\�����s��------------------
            '[�I���{�^��](�������ɖ߂��ʂ̐��������(VB - Transfer))
            Dim strMyAspx As String
            strMyAspx = Request.Form("hdnMyAspx")

            Dim strTitleVal As String       '�^�C�g�������Z�b�g
            Dim strButtonVal As String      '�{�^���l���Z�b�g
            btnTelHas2.Disabled = False
            If strMyAspx = "MSKOSJAG00" Then
                '���p�Ҍ�����ʂ���̉�ʑJ�ڂ̏ꍇ
                hdnBackUrl.Value = "MSKOSJAG00"
                strTitleVal = "�Ή�����"
                strButtonVal = "�o�^"
            ElseIf strMyAspx = "KEKEKJAG00" Then
                '�Ή����͕ύX�Ɖ��ʂ���̉�ʑJ�ڂ̏ꍇ
                hdnBackUrl.Value = "KEKEKJAG00"
                strTitleVal = "�Ή����͕ύX"
                strButtonVal = "�X�V"
            ElseIf strMyAspx = "KEJUKJAG00" Then
                '�x���M�p�l������̉�ʑJ�ڂ̏ꍇ
                hdnBackUrl.Value = "KEJUKJAG00"
                strTitleVal = "�Ή�����"
                strButtonVal = "�o�^"
            Else
                If Request.Path.LastIndexOf("SYCTIJAG00") >= 0 Then
                    '�b�s�h����̉�ʑJ�ڂ̏ꍇ
                    hdnBackUrl.Value = "MSKOSJAG00"
                    strTitleVal = "�Ή�����"
                    strButtonVal = "�o�^"
                Else
                    '���̑�����̉�ʑJ�ڂ̏ꍇ
                    hdnBackUrl.Value = ""
                    strTitleVal = ""
                    strButtonVal = ""
                End If
            End If
            '��L�Z�b�g�����^�C�g���E�{�^���l���Z�b�g����
            lblTitle.Text = strTitleVal
            btnUpdate.Value = strButtonVal

            '�d�b���M�֘A----------------------------------------------------------
            hdnTELEXEPATH.Value = ConfigurationSettings.AppSettings("TELEXEPATH")
            hdnTELEXENAME.Value = ConfigurationSettings.AppSettings("TELEXENAME")
            hdnTELEXERESULT.Value = ConfigurationSettings.AppSettings("TELEXERESULT")
            hdnTELWAITFLG.Value = ConfigurationSettings.AppSettings("TELWAITFLG")
            hdnTELPLSTORN.Value = ConfigurationSettings.AppSettings("TELPLSTORN")
            hdnTELHEAD.Value = ConfigurationSettings.AppSettings("TELHEAD")
            hdnATCOMMAND.Value = ConfigurationSettings.AppSettings("ATCOMMANDINI")

            '�e�`�w���M�֘A--------------------------------------------------------
            hdnFAXEXEPATH.Value = ConfigurationSettings.AppSettings("FAXEXEPATH")
            hdnFAXEXENAME.Value = ConfigurationSettings.AppSettings("FAXEXENAME")
            hdnFAXHEAD.Value = ConfigurationSettings.AppSettings("FAXHEAD")
            '2012/04/04 NEC ou Upd Str
            'hdnFAXSESSION.Value = Request.Cookies.Get("ASP.NET_SessionId").Value
            hdnFAXSESSION.Value = Me.Session.SessionID
            '2012/04/04 NEC ou Upd End

            '�J�ڌ���ʂ̏���ێ�����--------------------------------------------
            Dim strRec As String

            If Request.Path.LastIndexOf("SYCTIJAG00") >= 0 Then
                '�b�s�h����̑J�ڂ̏ꍇ

                '�Ď��Z���^�[�R�[�h�t���O
                hdnKANSFLG.Value = "1"

                '--- ��2005/05/19 ADD Falcon�� ---
                '�b�s�h�̎��ɒl���Z�b�g�i�����I��CTI���ǂ����𔻒f�j
                hdnCtiFlg.Value = "1"
                '--- ��2005/05/19 ADD Falcon�� ---

                Dim SYCTIJAG00_C As New SYCTIJAG00.SYCTIJAG00
                SYCTIJAG00_C = CType(Context.Handler, SYCTIJAG00.SYCTIJAG00)

                '�ꗗ�̃����N����̑J�ڎ�
                hdnKEY_CLI_CD.Value = SYCTIJAG00_C.gstrCLI_CD
                hdnKEY_JA_CD.Value = ""                             '2013/12/09 T.Ono add �Ď����P2013
                hdnKEY_HAN_GRP.Value = ""                           '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                hdnKEY_KINREN_GRP.Value = ""                        '2016/11/22 H.Mori add �Ď����P2016 No2-1
                hdnKEY_HAN_CD.Value = SYCTIJAG00_C.gstrHAN_CD
                hdnKEY_USER_CD.Value = SYCTIJAG00_C.gstrUSER_CD
                '����l(MOVE)��ێ�����
                hdnMOVE_NAME.Value = ""
                hdnMOVE_KANAD.Value = ""
                hdnMOVE_ADDR.Value = ""             '2013/12/09 T.Ono add �Ď����P2013
                hdnMOVE_CLI_CD.Value = ""
                hdnMOVE_CLI_CD_NAME.Value = ""
                hdnMOVE_JA_CD.Value = ""            '2013/12/09 T.Ono add �Ď����P2013
                hdnMOVE_JA_CD_NAME.Value = ""       '2013/12/09 T.Ono add �Ď����P2013
                hdnMOVE_JA_CD_CLI.Value = ""        '2019/11/01 T.Ono add �Ď����P2019
                hdnMOVE_HAN_GRP.Value = ""          '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                hdnMOVE_HAN_GRP_NAME.Value = ""     '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                hdnMOVE_KINREN_GRP.Value = ""          '2016/11/22 H.Mori add �Ď����P2016 No2-1
                hdnMOVE_KINREN_GRP_NAME.Value = ""     '2016/11/22 H.Mori add �Ď����P2016 No2-1
                hdnMOVE_HAN_CD.Value = ""
                hdnMOVE_HAN_CD_NAME.Value = ""
                hdnMOVE_HAN_CD_CLI.Value = ""          '2019/11/01 T.Ono add �Ď����P2019
                hdnMOVE_HAN_CD_TO.Value = ""           '2016/11/24 H.Mori add �Ď����P2016 No2-2
                hdnMOVE_HAN_CD_NAME_TO.Value = ""      '2016/11/24 H.Mori add �Ď����P2016 No2-2
                hdnMOVE_HAN_CD_TO_CLI.Value = ""       '2019/11/01 T.Ono add �Ď����P2019
                hdnMOVE_USER_CD.Value = ""
                hdnMOVE_KANSCD.Value = ""
                hdnMOVE_TEL.Value = SYCTIJAG00_C.gstrCTITELNO
                hdnMOVE_NCUTEL.Value = ""           '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                '2011.11.15 ADD H.Uema
                hdnMOVE_KMCD.Value = ""
                hdnMOVE_KMNM.Value = ""             '2013/12/10 T.Ono add �Ď����P2013
                hdnScrollTop.Value = "0"            '2013/12/10 T.Ono add �Ď����P2013
                hdnMOVE_USER_FLG0.Value = "1"       '���q�lFLG�@2014/01/10 T.Ono add �Ď����P2013
                hdnMOVE_USER_FLG1.Value = "1"       '���q�lFLG�@2014/01/10 T.Ono add �Ď����P2013
                hdnMOVE_USER_FLG2.Value = "1"       '���q�lFLG�@2014/01/10 T.Ono add �Ď����P2013
                hdnMOVE_HANBAI_KBN1.Value = "1"     '�̔��敪   2015/12/15 H.Mori add �Ď����P2015
                hdnMOVE_HANBAI_KBN2.Value = "1"     '�̔��敪   2015/12/15 H.Mori add �Ď����P2015
                hdnMOVE_HANBAI_KBN3.Value = "1"     '�̔��敪   2015/12/15 H.Mori add �Ď����P2015
                hdnMOVE_HANBAI_KBN4.Value = "1"     '�̔��敪   2015/12/15 H.Mori add �Ď����P2015
                hdnMOVE_HANBAI_KBN5.Value = "1"     '�̔��敪   2015/12/15 H.Mori add �Ď����P2015
                hdnMOVE_HANBAI_KBN6.Value = "1"     '�̔��敪   2015/12/15 H.Mori add �Ď����P2015

                '��ʂ̏o�́i�R���{�̏ꍇ�͕ϐ��Ɋi�[�j
                strRec = fncSetData_KOKYAKU()
                If strRec <> "OK" Then
                    Call fncError()
                    Exit Sub
                End If
            Else
                If strMyAspx = "MSKOSJAG00" Then
                    '���p�Ҍ�����ʂ���̉�ʑJ�ڂ̏ꍇ
                    If Convert.ToString(Request.Form("hdnTaiouClick")) = "1" Then
                        '�Ή����̓{�^�������ł̑J�ڎ�
                        'btnTelHas2.Disabled = True

                        '�b�s�h���o�^�t���O(�֌W�̂Ȃ��J�ڂ̏ꍇ�̓Z�b�g���Ȃ�)
                        hdnMOVE_MITOKBN.Value = Request.Form("hdnMOVE_MITOKBN")

                        '--- ��2005/05/19 ADD Falcon�� ---
                        '�b�s�h�̎��ɒl���Z�b�g�i�����I��CTI���ǂ����𔻒f�j
                        hdnCtiFlg.Value = Request.Form("hdnMOVE_MITOKBN")
                        '--- ��2005/05/19 ADD Falcon�� ---

                        '--- ��2005/04/20 ADD�@Falcon�� -----------------
                        '�Ή����͑J�ڃ��[�h
                        hdnMOVE_MODE.Value = Request.Form("hdnTaiouClick")
                        '--- ��2005/04/20 ADD�@Falcon�� -----------------

                        '�Ď��Z���^�[�R�[�h�t���O
                        hdnKANSFLG.Value = "0"

                        hdnHATKBN.Value = "1"
                        txtHATKBN.Text = "�d�b"
                        '�d�b�A�����e�i�����l55:���̑��j 2016/12/20 H.Mori add 2016���P�J�� No4-2
                        'strCBO_TELRCD = "55" '2019/11/01 w.ganeko 2019�Ď����P No 6 del

                        Dim DateFncC As New CDateFnc
                        Dim TimeFncC As New CTimeFnc
                        Dim strSYSDATE As String = Now.ToString("yyyyMMdd")
                        Dim strSYSTIME As String = Now.ToString("HHmmss")
                        '�������� ' 2008/10/15 T.Watabe add
                        txtNCUHATYMD.Text = DateFncC.mGet(strSYSDATE)
                        txtNCUHATTIME.Text = TimeFncC.mGet(strSYSTIME, 0)
                        '��M����
                        txtHATYMD.Text = DateFncC.mGet(strSYSDATE)
                        txtHATTIME.Text = TimeFncC.mGet(strSYSTIME, 0)
                        '�Ή��J�n��
                        hdnTAIO_ST_DATE.Value = strSYSDATE
                        hdnTAIO_ST_TIME.Value = strSYSTIME
                        '��M��
                        hdnJUYMD.Value = strSYSDATE
                        hdnJUTIME.Value = strSYSTIME
                        '�X�N���[���o�[�ʒu�̕ێ�
                        hdnScrollTop.Value = "0"            '2013/12/10 T.Ono add �Ď����P2013
                        '���q�lFLG
                        hdnMOVE_USER_FLG0.Value = "1"       '2014/01/10 T.Ono add �Ď����P2013
                        hdnMOVE_USER_FLG1.Value = "1"       '2014/01/10 T.Ono add �Ď����P2013
                        hdnMOVE_USER_FLG2.Value = "1"       '2014/01/10 T.Ono add �Ď����P2013
                        '�̔��敪
                        hdnMOVE_HANBAI_KBN1.Value = "1"     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN2.Value = "1"     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN3.Value = "1"     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN4.Value = "1"     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN5.Value = "1"     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN6.Value = "1"     '2015/12/15 H.Mori add �Ď����P2015

                        '2020/11/01 T.Ono add 2020�Ď����P
                        '�Ď��Z���^�[�S����
                        Dim strTANInfo() As String
                        strTANInfo = fncGetTANInfo()

                        '�Ď��Z���^�[�S���҃R�[�h
                        If Convert.ToString(strTANInfo(0)) <> "" Then
                            hdnTKTANCD.Value = Convert.ToString(strTANInfo(0))
                            '�Ď��Z���^�[�S���Җ�
                            txtTKTANCD.Text = Convert.ToString(strTANInfo(0)) & "�F" & Convert.ToString(strTANInfo(1))
                        End If

                    Else
                        '�ꗗ�̃����N����̑J�ڎ�

                        '�b�s�h���o�^�t���O(�֌W�̂Ȃ��J�ڂ̏ꍇ�̓Z�b�g���Ȃ�)
                        hdnMOVE_MITOKBN.Value = Request.Form("hdnMOVE_MITOKBN")

                        '--- ��2005/05/19 ADD Falcon�� ---
                        '�b�s�h�̎��ɒl���Z�b�g�i�����I��CTI���ǂ����𔻒f�j
                        hdnCtiFlg.Value = Request.Form("hdnMOVE_MITOKBN")
                        '--- ��2005/05/19 ADD Falcon�� ---

                        '�Ď��Z���^�[�R�[�h�t���O
                        hdnKANSFLG.Value = "1"

                        hdnKEY_CLI_CD.Value = Request.Form("hdnKEY_CLI_CD")
                        hdnKEY_JA_CD.Value = Request.Form("hdnKEY_JA_CD")                   '2013/12/09 T.Ono add �Ď����P2013
                        hdnKEY_HAN_GRP.Value = Request.Form("hdnKEY_HAN_GRP")               '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                        hdnKEY_KINREN_GRP.Value = Request.Form("hdnKEY_KINREN_GRP")               '2016/11/22 H.Mori add �Ď����P2016 No2-1
                        hdnKEY_HAN_CD.Value = Request.Form("hdnKEY_HAN_CD")
                        hdnKEY_USER_CD.Value = Request.Form("hdnKEY_USER_CD")
                        '����l(MOVE)��ێ�����
                        hdnMOVE_KANSCD.Value = Request.Form("hdnMOVE_KANSCD")
                        hdnMOVE_TEL.Value = Request.Form("hdnMOVE_TEL")
                        hdnMOVE_NCUTEL.Value = Request.Form("hdnMOVE_NCUTEL")               '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                        hdnMOVE_NAME.Value = Request.Form("hdnMOVE_NAME")
                        hdnMOVE_KANAD.Value = Request.Form("hdnMOVE_KANAD")
                        hdnMOVE_ADDR.Value = Request.Form("hdnMOVE_ADDR")                   '2013/12/09 T.Ono add �Ď����P2013
                        hdnMOVE_CLI_CD.Value = Request.Form("hdnMOVE_CLI_CD")
                        hdnMOVE_CLI_CD_NAME.Value = Request.Form("hdnMOVE_CLI_CD_NAME")
                        hdnMOVE_CLI_CD_TO.Value = Request.Form("hdnMOVE_CLI_CD_TO")           '2019/11/01 T.Ono add �Ď����P2019 No1
                        hdnMOVE_CLI_CD_TO_NAME.Value = Request.Form("hdnMOVE_CLI_CD_TO_NAME") '2019/11/01 T.Ono add �Ď����P2019 No1
                        hdnMOVE_JA_CD.Value = Request.Form("hdnMOVE_JA_CD")                 '2013/12/09 T.Ono add �Ď����P2013
                        hdnMOVE_JA_CD_NAME.Value = Request.Form("hdnMOVE_JA_CD_NAME")       '2013/12/09 T.Ono add �Ď����P2013
                        hdnMOVE_JA_CD_CLI.Value = Request.Form("hdnMOVE_JA_CD_CLI")         '2019/11/01 T.Ono add �Ď����P2019
                        hdnMOVE_HAN_GRP.Value = Request.Form("hdnMOVE_HAN_GRP")             '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                        hdnMOVE_HAN_GRP_NAME.Value = Request.Form("hdnMOVE_HAN_GRP_NAME")   '2014/12/03 H.Hosoda add �Ď����P2014 No.6
                        hdnMOVE_KINREN_GRP.Value = Request.Form("hdnMOVE_KINREN_GRP")             '2016/11/22 H.Mori add �Ď����P2016 No2-1
                        hdnMOVE_KINREN_GRP_NAME.Value = Request.Form("hdnMOVE_KINREN_GRP_NAME")   '2016/11/22 H.Mori add �Ď����P2016 No2-1
                        hdnMOVE_HAN_CD.Value = Request.Form("hdnMOVE_HAN_CD")
                        hdnMOVE_HAN_CD_NAME.Value = Request.Form("hdnMOVE_HAN_CD_NAME")
                        hdnMOVE_HAN_CD_CLI.Value = Request.Form("hdnMOVE_HAN_CD_CLI")             '2019/11/01 T.Ono add �Ď����P2019
                        hdnMOVE_HAN_CD_TO.Value = Request.Form("hdnMOVE_HAN_CD_TO")               '2016/11/24 H.Mori add �Ď����P2016 No2-2
                        hdnMOVE_HAN_CD_NAME_TO.Value = Request.Form("hdnMOVE_HAN_CD_NAME_TO")     '2016/11/24 H.Mori add �Ď����P2016 No2-2
                        hdnMOVE_HAN_CD_TO_CLI.Value = Request.Form("hdnMOVE_HAN_CD_TO_CLI")       '2019/11/01 T.Ono add �Ď����P2019
                        hdnMOVE_USER_CD.Value = Request.Form("hdnMOVE_USER_CD")
                        hdnMOVE_USER_FLG0.Value = Request.Form("hdnMOVE_USER_FLG0")         '2013/12/20 T.Ono add �Ď����P2013
                        hdnMOVE_USER_FLG1.Value = Request.Form("hdnMOVE_USER_FLG1")         '2013/12/20 T.Ono add �Ď����P2013
                        hdnMOVE_USER_FLG2.Value = Request.Form("hdnMOVE_USER_FLG2")         '2013/12/20 T.Ono add �Ď����P2013
                        hdnMOVE_HANBAI_KBN1.Value = Request.Form("hdnMOVE_HANBAI_KBN1")     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN2.Value = Request.Form("hdnMOVE_HANBAI_KBN2")     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN3.Value = Request.Form("hdnMOVE_HANBAI_KBN3")     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN4.Value = Request.Form("hdnMOVE_HANBAI_KBN4")     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN5.Value = Request.Form("hdnMOVE_HANBAI_KBN5")     '2015/12/15 H.Mori add �Ď����P2015
                        hdnMOVE_HANBAI_KBN6.Value = Request.Form("hdnMOVE_HANBAI_KBN6")     '2015/12/15 H.Mori add �Ď����P2015
                        '�X�N���[���o�[�ʒu�̕ێ�
                        hdnScrollTop.Value = Request.Form("hdnScrollTop")                   '2013/12/10 T.Ono add �Ď����P2013

                        '��ʂ̏o�́i�R���{�̏ꍇ�͕ϐ��Ɋi�[�j
                        strRec = fncSetData_KOKYAKU()
                        If strRec <> "OK" Then
                            Call fncError()
                            Exit Sub
                        End If
                    End If

                ElseIf strMyAspx = "KEKEKJAG00" Then
                    '�Ή����͕ύX�ꗗ��ʂ���̉�ʑJ�ڂ̏ꍇ

                    '�Ď��Z���^�[�R�[�h�t���O
                    hdnKANSFLG.Value = "1"

                    '�ꗗ�ɂđI�����ꂽ�����L�[�̎擾
                    hdnKEY_KANSCD.Value = Request.Form("hdnKEY_KANSCD")
                    hdnKEY_SYONO.Value = Request.Form("hdnKEY_SYONO")
                    '����l(MOVE)��ێ�����
                    hdnMOVE_TMSKB.Value = Request.Form("hdnMOVE_TMSKB")
                    hdnMOVE_JUTEL.Value = Request.Form("hdnMOVE_JUTEL")
                    hdnMOVE_NCUTEL.Value = Request.Form("hdnMOVE_NCUTEL")               '2014/12/03 H.Hosoda add �Ď����P2014 No.7
                    hdnMOVE_KANSCD.Value = Request.Form("hdnMOVE_KANSCD")
                    hdnMOVE_HATKBN.Value = Request.Form("hdnMOVE_HATKBN")
                    'hdnMOVE_TAIOKBN.Value = Request.Form("hdnMOVE_TAIOKBN")            '2014/12/03 H.Hosoda del �Ď����P2014 No.7
                    hdnMOVE_TAIOKBN1.Value = Request.Form("hdnMOVE_TAIOKBN1")           '2014/12/03 H.Hosoda add �Ď����P2014 No.7
                    hdnMOVE_TAIOKBN2.Value = Request.Form("hdnMOVE_TAIOKBN2")           '2014/12/03 H.Hosoda add �Ď����P2014 No.7
                    hdnMOVE_TAIOKBN3.Value = Request.Form("hdnMOVE_TAIOKBN3")           '2014/12/03 H.Hosoda add �Ď����P2014 No.7
                    hdnMOVE_TKTANCD.Value = Request.Form("hdnMOVE_TKTANCD")
                    hdnMOVE_TKTANNM.Value = Request.Form("hdnMOVE_TKTANNM")
                    hdnMOVE_JUSYONM.Value = Request.Form("hdnMOVE_JUSYONM")
                    hdnMOVE_JUSYOKN.Value = Request.Form("hdnMOVE_JUSYOKN")
                    hdnMOVE_KIKANKBN.Value = Request.Form("hdnMOVE_KIKANKBN")    '2017/10/26 H.Mori add 2017���P�J�� No3-1
                    hdnMOVE_HATYMD_To.Value = Request.Form("hdnMOVE_HATYMD_To")
                    hdnMOVE_HATTIME_To.Value = Request.Form("hdnMOVE_HATTIME_To")
                    hdnMOVE_HATYMD_From.Value = Request.Form("hdnMOVE_HATYMD_From")
                    hdnMOVE_HATTIME_From.Value = Request.Form("hdnMOVE_HATTIME_From")
                    hdnMOVE_KURACD.Value = Request.Form("hdnMOVE_KURACD")
                    hdnMOVE_KURACD_NAME.Value = Request.Form("hdnMOVE_KURACD_NAME")
                    hdnMOVE_KURACD_TO.Value = Request.Form("hdnMOVE_KURACD_TO")           '2019/11/01 T.Ono add �Ď����P2019
                    hdnMOVE_KURACD_TO_NAME.Value = Request.Form("hdnMOVE_KURACD_TO_NAME") '2019/11/01 T.Ono add �Ď����P2019
                    hdnMOVE_JA_CD.Value = Request.Form("hdnMOVE_JACD")                 '2013/12/09 T.Ono add �Ď����P2013
                    hdnMOVE_JA_CD_NAME.Value = Request.Form("hdnMOVE_JACD_NAME")       '2013/12/09 T.Ono add �Ď����P2013
                    hdnMOVE_JA_CD_CLI.Value = Request.Form("hdnMOVE_JACD_CLI")         '2019/11/01 T.Ono add �Ď����P2019
                    hdnMOVE_HAN_GRP.Value = Request.Form("hdnMOVE_HAN_GRP")            '2014/12/03 H.Hosoda add �Ď����P2014 No.7
                    hdnMOVE_HAN_GRP_NAME.Value = Request.Form("hdnMOVE_HAN_GRP_NAME")  '2014/12/03 H.Hosoda add �Ď����P2014 No.7
                    hdnMOVE_KINREN_GRP.Value = Request.Form("hdnMOVE_KINREN_GRP")            '2016/11/25 H.Mori add �Ď����P2016 No3-1
                    hdnMOVE_KINREN_GRP_NAME.Value = Request.Form("hdnMOVE_KINREN_GRP_NAME")  '2016/11/25 H.Mori add �Ď����P2016 No3-1
                    hdnMOVE_ACBCD.Value = Request.Form("hdnMOVE_ACBCD")
                    hdnMOVE_ACBCD_NAME.Value = Request.Form("hdnMOVE_ACBCD_NAME")
                    hdnMOVE_ACBCD_CLI.Value = Request.Form("hdnMOVE_ACBCD_CLI")           '2019/11/01 T.Ono add �Ď����P2019
                    hdnMOVE_ACBCD_TO.Value = Request.Form("hdnMOVE_ACBCD_TO")             '2019/11/01 T.Ono add �Ď����P2019
                    hdnMOVE_ACBCD_TO_NAME.Value = Request.Form("hdnMOVE_ACBCD_TO_NAME")   '2019/11/01 T.Ono add �Ď����P2019
                    hdnMOVE_ACBCD_TO_CLI.Value = Request.Form("hdnMOVE_ACBCD_TO_CLI")     '2019/11/01 T.Ono add �Ď����P2019
                    hdnMOVE_USER_CD.Value = Request.Form("hdnMOVE_USER_CD")
                    '2011.11.15 ADD H.Uema
                    hdnMOVE_KMCD.Value = Request.Form("hdnMOVE_KMCD")
                    hdnMOVE_KMNM.Value = Request.Form("hdnMOVE_KMNM")                   '2013/12/10 T.Ono add �Ď����P2013
                    '�X�N���[���o�[�ʒu�̕ێ�
                    hdnScrollTop.Value = Request.Form("hdnScrollTop")                   '2013/12/10 T.Ono add �Ď����P2013
                    '��ʂ̏o�́i�R���{�̏ꍇ�͕ϐ��Ɋi�[�j
                    strRec = fncSetData_TAIOU()
                    If strRec <> "OK" Then
                        Call fncError()
                        Exit Sub
                    End If

                ElseIf strMyAspx = "KEJUKJAG00" Then
                    '�x���M�p�l������̉�ʑJ�ڂ̏ꍇ

                    '�Ď��Z���^�[�R�[�h�t���O
                    hdnKANSFLG.Value = "1"

                    '�ꗗ�ɂđI�����ꂽ�����L�[�̎擾
                    hdnKEY_SERIAL.Value = Request.Form("hdnKEY_SERIAL")
                    '����l(MOVE)��ێ�����
                    hdnJido.Value = Request.Form("hdnJido")                           '2013/12/13 T.Ono add �Ď����P2013
                    hdnMishori.Value = Request.Form("hdnMishori")                     '2013/12/13 T.Ono add �Ď����P2013

                    '--- ��2005/04/20 ADD�@Falcon�� -----------------
                    '���p�ҏ����͕s��
                    Call fncSetState(True)
                    '--- ��2005/04/20 ADD�@Falcon�� -----------------

                    '��ʂ̏o�́i�R���{�̏ꍇ�͕ϐ��Ɋi�[�j
                    strRec = fncSetData_KEIHOU()
                    If strRec <> "OK" Then
                        Call fncError()
                        Exit Sub
                    End If
                Else
                    '���̑�����̉�ʑJ�ڂ̏ꍇ
                    Call fncError()
                    Exit Sub
                End If
            End If

            '�R���{�{�b�N�X���o�͂���
            Call fncCombo_Create_Taiou()
            Call fncCombo_Create_Syori()
            Call fncCombo_Create_Rebrakua()
            Call fncCombo_Create_Denwaren()
            Call fncCombo_Create_Hukkitai()
            Call fncCombo_Create_Gakukigu()
            Call fncCombo_Create_Sadougen()
            Call fncCombo_Create_Syutusij()

            '2022/12/09 ADD START Y.Arakaki 2022�X��No�F _����x�񃁃b�Z�[�WNo�I�����̃��X�g�����I��Ή�
            '�R���{�{�b�N�X�ҏW�p�̃��X�g�擾(��ʕ\�����JavaScript�����Ɏg�p�����f�[�^)
            Call fncCombo_Get_JidouSentakuList() '����̌x��No�I�����A�����̉�ʃ��X�g���ڂ������I������悤�ݒ�
            '2022/12/09 ADD END   Y.Arakaki 2022�X��No�F _����x�񃁃b�Z�[�WNo�I�����̃��X�g�����I��Ή�

            '�R���{�̒l��I������
            Call fncComboSet()

            '//-------------------------------------------------
            '�t�H�[�J�X���Z�b�g����
            If strMyAspx = "MSKOSJAG00" Then
                '�ڋq������ʂ���̑J�ڎ�
                If Convert.ToString(Request.Form("hdnTaiouClick")) = "1" Then
                    '�ڋq�����̑Ή����̓{�^��������
                    strMsg.Append("Form1.btnKURACD.focus();")
                Else
                    '���̑�
                    strMsg.Append("Form1.btnTelHas1.focus();")
                End If
            Else
                '��M�p�l���E���ʈꗗ����̑J�ڎ�
                strMsg.Append("Form1.btnTelHas1.focus();")
            End If

            '2022/12/09 ADD START Y.Arakaki 2022�X��No�F _����x�񃁃b�Z�[�WNo�I�����̃��X�g�����I��Ή�
            If strMyAspx = "KEJUKJAG00" Then
                '�x���M�p�l������̉�ʑJ�ڂ̏ꍇ�A�x�񃁃b�Z�[�W�����Ƃɓ��胊�X�g���e�������I������B
                strMsg.Append("setAutoListValues();")
            End If
            '2022/12/09 ADD END   Y.Arakaki 2022�X��No�F _����x�񃁃b�Z�[�WNo�I�����̃��X�g�����I��Ή�

            '2014/12/19 T.Ono mod 2014���P�J�� No2 START
            ''�o�͂����i�`�����A�o����ЁE�A����̃f�[�^�擾���s��
            'strMsg.Append("fncSyutudou();")
            '�o�͂����i�`�����A�o����ЁE�A����E�̔����Ǝ҂̃f�[�^�擾���s��
            strMsg.Append("fncSyutudou(1);")

            '�o�͂��������敪���Ή����������𐧌䂷��
            strMsg.Append("fncTMSKB_Chenge();")

            '�K�X�����x�~���E�p�~���E�������ɂ��A��ʂ̐F��ς��� 2013/08/19 T.Ono add �Ď����P2013��1
            strMsg.Append("fncChangeColor();")

            '2019/11/01 W.GANEKO 2019�Ď����P No8-12 start
            If strMyAspx = "KEKEKJAG00" Then
                strMsg.Append("fncTAIO_Change();")
                If strCBO_TFKICD <> "" Then
                    strMsg.Append("with (Form1) {")
                    strMsg.Append("  cboTFKICD.value = '" + strCBO_TFKICD + "';")
                    strMsg.Append("}")
                End If
            End If
            '2019/11/01 W.GANEKO 2019�Ď����P No8-12 end

            '2020/03/11 T.Ono add �Ď����P2019
            '�Ή��敪 = 1�d�b�Ή��A�����敪=�P�������A�R�������̏ꍇ�A�A�����蓖�̃v���_�E����K�{�Ƃ��Ȃ�
            If strMyAspx = "KEKEKJAG00" Then
                If strCBO_TMSKB <> "2" Then
                    strMsg.Append("fncTMSKB_Chenge();")


                End If
            End If


            hdnInputClientList.Value = fncGetData_ClientList() '2007/05/09 T.Watabe add

            hdnNCUDiffChkMin.Value = ConfigurationSettings.AppSettings("NCU_DIFF_CHK_MIN") '�����`��M���Ԃ̌o�ߎ��ԃ`�F�b�N�i���j' 2008/10/16 T.Watabe add

        Else
            '//--------------------------------------
            '//�@�Q��ڈȍ~���s�����
            '//--------------------------------------------------------------------------
            '//����ʕ\������R���{�{�b�N�X�͊e�ŏI�C�x���g/���\�b�h��CALL���܂�
            '//--------------------------------------------------------------------------
        End If


        '//-------------------------------------------------
        '<TODO>�����̉��ID��HIDDEN��hdnMyAspx�ɏ������ށi�V�X�e�����ʁj
        hdnMyAspx.Value = "KETAIJAG00"
        '//-------------------------------------------------
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load end")

    End Sub

    '--- ��2005/04/20 ADD�@Falcon�� -----------------
    '******************************************************************************
    '*�@�T�@�v�F��Ԃ̐ݒ�
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncSetState(ByVal bolState As Boolean)
        '�N���C�A���g�R�[�h�����{�^���̐���
        btnKURACD.Disabled = bolState

        '�i�`�x���R�[�h�����{�^���̐���
        btnJASCD.Disabled = bolState
    End Sub
    '--- ��2005/04/20 ADD�@Falcon�� -----------------

    '******************************************************************************
    '*�@�T�@�v�F�R���{�{�b�N�X�̑I��
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncComboSet()
        Dim list As New ListItem

        If strCBO_TAIOKBN <> "" Then
            list = cboTAIOKBN.Items.FindByValue(strCBO_TAIOKBN)
            cboTAIOKBN.SelectedIndex = cboTAIOKBN.Items.IndexOf(list)
        End If
        If strCBO_TMSKB <> "" Then
            list = cboTMSKB.Items.FindByValue(strCBO_TMSKB)
            cboTMSKB.SelectedIndex = cboTMSKB.Items.IndexOf(list)
        End If
        If strCBO_TAITCD <> "" Then
            list = cboTAITCD.Items.FindByValue(strCBO_TAITCD)
            cboTAITCD.SelectedIndex = cboTAITCD.Items.IndexOf(list)
        End If
        If strCBO_TELRCD <> "" Then
            list = cboTELRCD.Items.FindByValue(strCBO_TELRCD)
            cboTELRCD.SelectedIndex = cboTELRCD.Items.IndexOf(list)
        End If
        If strCBO_TFKICD <> "" Then
            list = cboTFKICD.Items.FindByValue(strCBO_TFKICD)
            cboTFKICD.SelectedIndex = cboTFKICD.Items.IndexOf(list)
        End If
        If strCBO_TKIGCD <> "" Then
            list = cboTKIGCD.Items.FindByValue(strCBO_TKIGCD)
            cboTKIGCD.SelectedIndex = cboTKIGCD.Items.IndexOf(list)
        End If
        If strCBO_TSADCD <> "" Then
            list = cboTSADCD.Items.FindByValue(strCBO_TSADCD)
            cboTSADCD.SelectedIndex = cboTSADCD.Items.IndexOf(list)
        End If
        If strCBO_SDCD <> "" Then
            list = cboSDCD.Items.FindByValue(strCBO_SDCD)
            cboSDCD.SelectedIndex = cboSDCD.Items.IndexOf(list)
        End If

    End Sub

    '******************************************************************************
    '*�@�T�@�v�F���s�{�^���������̏���
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnUpdate_ServerClick(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) Handles btnUpdate.ServerClick
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnUpdate_ServerClick start")
        Call fncSetPublic()
        '//--------------------------------------------------------------------------
        '<TODO>�o�^�������s��
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnUpdate_ServerClick Server.Transfer=KETAIJJG00.aspx")
        Server.Transfer("KETAIJJG00.aspx")
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnUpdate_ServerClick end")
    End Sub

    '******************************************************************************
    '*�@�T�@�v�F�I���{�^���������̏���
    '*�@���@�l�F
    '******************************************************************************
    Private Sub btnExit_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles btnExit.ServerClick
        '�J�ڂ��Ă�����ʂ�ێ����A[�I���{�^��]�������ɖ߂��ʂ̐��������(VB-Transfer)
        Dim strMyAspx As String
        Dim strRes As String
        strMyAspx = Request.Form("hdnMyAspx")
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnExit_ServerClick start")

        If hdnBackUrl.Value = "MSKOSJAG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load MSKOSJAG00 ���p�Ҍ������ Server.Transfer=MSKOSJAG00.aspx")
            '���p�Ҍ�����ʂ���̉�ʑJ�ڂ̏ꍇ
            Server.Transfer("../../../MS/MSKOSJAG/MSKOSJAG00/MSKOSJAG00.aspx")

        ElseIf hdnBackUrl.Value = "KEKEKJAG00" Then
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEKEKJAG00 �Ή��ύX�ꗗ��� Server.Transfer=KEKEKJAG00.aspx")
            '�Ή��ύX�ꗗ��ʂ���̉�ʑJ�ڂ̏ꍇ
            Server.Transfer("../../../KE/KEKEKJAG/KEKEKJAG00/KEKEKJAG00.aspx")

        ElseIf hdnBackUrl.Value = "KEJUKJAG00" Then
            Dim KETAIJAW00C As New KETAIJAG00KETAIJAW00.KETAIJAW00
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJAG00 �Ή�����_�I������ hdnKEY_SERIAL=" & hdnKEY_SERIAL.Value)
            '�x��DB�̃��b�N�t���O�ƑΉ��J�n���Ԃ�������

            'strRes = KETAIJAW00C.mSet_NoRoc(hdnKEY_SERIAL.Value) 
            strRes = KETAIJAW00C.mSet_NoRoc(hdnKEY_SERIAL.Value, AuthC.pUSERNAME) '2017/10/23 H.Mori add 2017���P�J�� No4-3
            Select Case strRes
                Case "OK"
                    '�x���M�p�l������̉�ʑJ�ڂ̏ꍇ----------
                    mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJAG00 �Ή�����_�I������ Server.Transfer=KEJUKJAG00.aspx OK")
                    Server.Transfer("../../../KE/KEJUKJAG/KEJUKJAG00/KEJUKJAG00.aspx")
                Case Else
                    Dim ErrMsgC As New CErrMsg
                    Call fncError()
                    strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRes) & "');")
            End Select
        End If
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnExit_ServerClick end")

    End Sub
    '******************************************************************************
    '*�@�T�@�v�F�G���[�������̉�ʐ���
    '*�@���@�l�F�߂�{�^���̂ݎg�p�\
    '******************************************************************************
    Private Sub fncError()
        ''''''�C�x���g�����I�u�W�F�N�g�ɑ΂��郍�b�N����
        '''''btnTelHas1.Disabled = True
        '''''btnTelHas2.Disabled = True
        '''''btnFAX.Disabled = True
        '''''btnTaiouRireki.Disabled = True
        '''''btnKyoryok.Disabled = True
        '''''txtRNRK_ST_DATE.Enabled = False
        '''''txtRNRK_EN_DATE.Enabled = False
        '''''txtTOKRY_DATE.Enabled = False
        '''''btnUpdate.Disabled = True
        '''''btnExit.Disabled = False
        ''''''�G���[���������̃t�H�[�J�X�Z�b�g
        '''''strMsg.Append("Form1.btnExit.focus();")
    End Sub
    '******************************************************************************
    '*�@�T�@�v�F��ʂ̍X�V�Ώۍ��ڂ�Public�ϐ��Ɋi�[����
    '*�@���@�l�F
    '******************************************************************************
    Private Sub fncSetPublic()
        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc
        Dim NaNFncC As New CNaNFnc
        Dim UtilFucC As New CUtilFuc

        If hdnBackUrl.Value = "KEKEKJAG00" Then
            gstrKBN = "2"               '�C��
        Else
            gstrKBN = "1"               '�o�^
        End If
        gstrADD_DATE = hdnADD_DATE.Value
        gstrEDT_DATE = hdnEDT_DATE.Value
        gstrTIME = hdnTIME.Value

        '�f�[�^�]�L
        '''''gstrKANSCD = strKANSCD  '�Ď��Z���^�[�R�[�h�͊Ď��S���҂��擾���遨�N���C�A���g�R�[�h���擾����
        gstrKANSCD = hdnKANSCD.Value
        gstrSYONO = txtSYONO.Text
        gstrNCUHATYMD = DateFncC.mHenkanGet(txtNCUHATYMD.Text) ' 2008/10/15 T.Watabe add
        gstrNCUHATTIME = TimeFncC.mHenkanGet(txtNCUHATTIME.Text) ' 2008/10/15 T.Watabe add
        gstrHATYMD = DateFncC.mHenkanGet(txtHATYMD.Text)
        gstrHATTIME = TimeFncC.mHenkanGet(txtHATTIME.Text)
        gstrKENSIN = txtKMSIN.Text
        gstrKEIHOSU = txtKEIHOSU.Text
        gstrRYURYO = txtRYURYO.Text
        gstrMETASYU = txtMETASYU.Text
        gstrUNYO = hdnUNYOCD.Value
        gstrJUYMD = hdnJUYMD.Value
        gstrJUTIME = hdnJUTIME.Value
        gstrNUM_DIGIT = hdnNUM_DIGIT.Value
        ' �x�񃁃b�Z�[�W�̓���ւ� 2013/08/23 T.Ono mod �Ď����P2013��1
        'gstrKMCD1 = hdnKMCD1.Value
        'gstrKMNM1 = hdnKMNM1.Value
        'gstrKMCD2 = hdnKMCD2.Value
        'gstrKMNM2 = hdnKMNM2.Value
        'gstrKMCD3 = hdnKMCD3.Value
        'gstrKMNM3 = hdnKMNM3.Value
        'gstrKMCD4 = hdnKMCD4.Value
        'gstrKMNM4 = hdnKMNM4.Value
        'gstrKMCD5 = hdnKMCD5.Value
        'gstrKMNM5 = hdnKMNM5.Value
        'gstrKMCD6 = hdnKMCD6.Value
        'gstrKMNM6 = hdnKMNM6.Value
        fncSetMessage()
        gstrKURACD = txtClientCD.Text
        gstrKENNM = txtKENNM.Text
        gstrJACD = hdnJACD.Value
        gstrJANM = hdnJANAME.Value
        gstrHANJICD = hdnHANJICD.Value '�̔����Ǝ҃R�[�h 2014/12/17 T.Ono add 2014���P�J�� No2 START
        gstrHANJINM = hdnHANJINM.Value '�̔����ƎҖ�     2014/12/17 T.Ono add 2014���P�J�� No2 START
        gstrACBCD = hdnJASCD.Value
        gstrACBNM = hdnJASNAME.Value
        gstrUSER_CD = txtJUYOKA.Text
        gstrJUSYONM = txtJUSYONM.Text
        gstrJUSYOKN = txtJUSYOKN.Text
        gstrJUTEL1 = txtJUTEL1.Text
        gstrJUTEL2 = txtJUTEL2.Text
        gstrRENTEL = txtRENTEL.Text
        gstrKTELNO = hdnKTELNO.Value
        gstrADDR = UtilFucC.CrlfCut(txtADDR.Text)       '�Z���F���s����
        '--- ��2005/09/09 MOD Falcon�� ---
        'gstrUSER_KIJI = txtUSER_KIJI.Text
        gstrBIKOU = txtUSER_KIJI.Text
        '--- ��2005/09/09 MOD Falcon�� ---
        gstrNCU_SET = hdnNCU.Value
        gstrTIZUNO = txtMAP_CD.Text
        gstrTUSIN = txtTUSIN.Text ' 2008/10/24 T.Watabe add
        gstrHANBAI_KBN = hdnHANBAI_KBN.Value '2015/11/25 H.Mori add 2015���P�J�� No1
        gstrKYOKTKBN = hdnKYOKTKBN.Value '2016/12/02 H.Mori add 2016���P�J�� No4-3
        gstrMET_KATA = txtMET_KATA.Text
        gstrMET_MAKER = txtMET_MAKER.Text
        gstrBONB1_KKG = NaNFncC.mHenkanGet(txtBONB1_KKG.Text)
        gstrBONB1_HON = NaNFncC.mHenkanGet(txtBONB1_HON.Text)
        gstrBONB1_YOBI = hdnBONB1_YOBI.Value
        gstrBONB2_KKG = NaNFncC.mHenkanGet(txtBONB2_KKG.Text)
        gstrBONB2_HON = NaNFncC.mHenkanGet(txtBONB2_HON.Text)
        gstrBONB2_YOBI = hdnBONB2_YOBI.Value
        gstrBONB3_KKG = NaNFncC.mHenkanGet(txtBONB3_KKG.Text)
        gstrBONB3_HON = NaNFncC.mHenkanGet(txtBONB3_HON.Text)
        gstrBONB3_YOBI = hdnBONB3_YOBI.Value
        gstrBONB4_KKG = NaNFncC.mHenkanGet(txtBONB4_KKG.Text)
        gstrBONB4_HON = NaNFncC.mHenkanGet(txtBONB4_HON.Text)
        gstrBONB4_YOBI = hdnBONB4_YOBI.Value
        gstrZENKAI_HAISO = DateFncC.mHenkanGet(txtZENKAI_HAISO.Text)
        gstrZENKAI_HAI_S = fncHenkanSisin(txtZENKAI_HAI_S.Text)
        gstrKONKAI_HAISO = DateFncC.mHenkanGet(txtKONKAI_HAISO.Text)
        gstrKONKAI_HAI_S = fncHenkanSisin(txtKONKAI_HAI_S.Text)
        gstrJIKAI_HAISO = DateFncC.mHenkanGet(txtJIKAI_HAISO.Text)
        gstrZENKAI_KENSIN = DateFncC.mHenkanGet(txtZENKAI_KENSIN.Text)
        gstrZENKAI_KEN_S = fncHenkanSisin(txtZENKAI_KEN_S.Text)
        gstrZENKAI_KEN_SIYO = NaNFncC.mHenkanGet(txtZENKAI_KEN_SIYO.Text)
        gstrKONKAI_KENSIN = DateFncC.mHenkanGet(txtKONKAI_KENSIN.Text)
        gstrKONKAI_KEN_S = fncHenkanSisin(txtKONKAI_KEN_S.Text)
        gstrKONKAI_KEN_SIYO = NaNFncC.mHenkanGet(txtKONKAI_KEN_SIYO.Text)
        gstrZENKAI_HASEI = DateFncC.mHenkanGet(txtZENKAI_HASEI.Text)
        gstrZENKAI_HAS_S = fncHenkanSisin(txtZENKAI_HAS_S.Text)
        gstrKONKAI_HASEI = DateFncC.mHenkanGet(txtKONKAI_HASEI.Text)
        gstrKONKAI_HAS_S = fncHenkanSisin(txtKONKAI_HAS_S.Text)
        gstrG_ZAIKO = NaNFncC.mHenkanGet(txtG_ZAIKO.Text)
        '2005/11/22 NEC UPDATE START
        '        gstrICHI_SIYO = fncHenkanSisin(txtICHI_SIYO.Text)
        '        gstrYOSOKU_ICHI_SIYO = fncHenkanSisin(txtYOSOKU_ICHI_SIYO.Text)
        gstrICHI_SIYO = fncHenkanSisin(txtICHI_SIYO.Text, 3)
        gstrYOSOKU_ICHI_SIYO = fncHenkanSisin(txtYOSOKU_ICHI_SIYO.Text, 3)
        '2005/11/22 NEC UPDATE END
        gstrGAS1_HINMEI = txtGAS1_HINMEI.Text
        gstrGAS1_DAISU = txtGAS1_DAISU.Text
        gstrGAS1_SEIFL = txtGAS1_SEIFL.Text
        gstrGAS2_HINMEI = txtGAS2_HINMEI.Text
        gstrGAS2_DAISU = txtGAS2_DAISU.Text
        gstrGAS2_SEIFL = txtGAS2_SEIFL.Text
        gstrGAS3_HINMEI = txtGAS3_HINMEI.Text
        gstrGAS3_DAISU = txtGAS3_DAISU.Text
        gstrGAS3_SEIFL = txtGAS3_SEIFL.Text
        gstrGAS4_HINMEI = txtGAS4_HINMEI.Text
        gstrGAS4_DAISU = txtGAS4_DAISU.Text
        gstrGAS4_SEIFL = txtGAS4_SEIFL.Text
        gstrGAS5_HINMEI = txtGAS5_HINMEI.Text
        gstrGAS5_DAISU = txtGAS5_DAISU.Text
        gstrGAS5_SEIFL = txtGAS5_SEIFL.Text
        gstrHATKBN = hdnHATKBN.Value
        gstrTAIOKBN = Request.Form("cboTAIOKBN")
        gstrTMSKB = Request.Form("cboTMSKB")
        gstrTKTANCD = hdnTKTANCD.Value
        gstrTAITCD = Request.Form("cboTAITCD")
        gstrTAIO_ST_DATE = hdnTAIO_ST_DATE.Value
        gstrTAIO_ST_TIME = hdnTAIO_ST_TIME.Value
        gstrSYOYMD = DateFncC.mHenkanGet(txtSYOYMD.Text)
        gstrSYOTIME = TimeFncC.mHenkanGet(txtSYOTIME.Text)
        If chkFAXKBN.Checked = True Then
            gstrFAXKBN = "1" '�`�F�b�N����@1:�s�v
        Else
            gstrFAXKBN = "2" '�`�F�b�N�Ȃ��@2:�K�v
        End If
        If chkFAXKURAKBN.Checked = True Then
            gstrFAXKURAKBN = "1" '�`�F�b�N����@1:�s�v
        Else
            gstrFAXKURAKBN = "2" '�`�F�b�N�Ȃ��@2:�K�v
        End If
        '2015/11/17 H.Mori add 2015���P�J�� No1 START
        If chkFAXRUISEKIKBN.Checked = True Then
            gstrFAXRUISEKIKBN = "1" '�`�F�b�N����@1:�s�v
        Else
            gstrFAXRUISEKIKBN = "2" '�`�F�b�N�Ȃ��@2:�K�v
        End If
        '2015/11/17 H.Mori add 2015���P�J�� No1 END
        ' 2010/07/12 T.Watabe add
        gstrTELRCD = Request.Form("cboTELRCD")
        gstrTFKICD = Request.Form("cboTFKICD")
        ' 2013/10/24 T.Ono T.Ono �Ď����P2013��1 Start
        'gstrFUK_MEMO = txtFUK_MEMO.Text
        'gstrTEL_MEMO1 = txtTEL_MEMO1.Text
        'gstrTEL_MEMO2 = txtTEL_MEMO2.Text
        gstrTEL_MEMO1 = hdnTEL_MEMO1.Value
        gstrTEL_MEMO2 = hdnTEL_MEMO2.Value
        gstrFUK_MEMO = hdnFUK_MEMO.Value
        ' 2013/10/24 T.Ono T.Ono �Ď����P2013��1 End
        '2020/11/01T.Ono add 2020�Ď����P Start
        gstrTEL_MEMO4 = hdnTEL_MEMO4.Value
        gstrTEL_MEMO5 = hdnTEL_MEMO5.Value
        gstrTEL_MEMO6 = hdnTEL_MEMO6.Value
        '2020/11/01T.Ono add 2020�Ď����P End
        gstrMITOKBN = hdnMOVE_MITOKBN.Value             '�b�s�h�ł��q�l�����Ȃ������Ƃ��P�����ڂb�s�h�ɂđJ�ڂ����Ƃ��͂O
        gstrTKIGCD = Request.Form("cboTKIGCD")
        gstrTSADCD = Request.Form("cboTSADCD")
        'gstrGENIN_KIJI = txtGENIN_KIJI.Text    '2021/01/05 T.Ono mod 2020�Ď����P
        gstrGENIN_KIJI = txtGENIN_KIJI.Value
        gstrSDCD = Request.Form("cboSDCD")
        gstrSIJIYMD = DateFncC.mHenkanGet(txtSIJIYMD.Text)
        gstrSIJITIME = TimeFncC.mHenkanGet(txtSIJITIME.Text)
        gstrSIJI_BIKO1 = txtSIJI_BIKO1.Text
        gstrSIJI_BIKO2 = txtSIJI_BIKO2.Text
        gstrSTD_JASCD = hdnREN_STD_JASCD.Value
        gstrSTD_JANA = hdnREN_STD_JANA.Value
        gstrSTD_JASNA = hdnREN_STD_JASNA.Value
        gstrREN_CODE = hdnREN_0_TANCD.Value
        gstrREN_NA = hdnREN_0_NA.Value
        gstrREN_TEL_1 = hdnREN_0_TEL1.Value
        gstrREN_TEL_2 = hdnREN_0_TEL2.Value
        gstrREN_TEL_3 = hdnREN_0_TEL3.Value         ' 2013/05/27 T.Ono add
        gstrREN_FAX = hdnREN_0_FAX.Value            '�e�`�w�ԍ��P
        gstrREN_BIKO = hdnREN_0_BIKO.Value
        gstrREN_EDT_DATE = hdnREN_0_EDT_DATE.Value
        gstrREN_TIME = hdnREN_0_TIME.Value
        gstrREN_1_CODE = hdnREN_1_TANCD.Value
        gstrREN_1_NA = hdnREN_1_NA.Value
        gstrREN_1_TEL1 = hdnREN_1_TEL1.Value
        gstrREN_1_TEL2 = hdnREN_1_TEL2.Value
        gstrREN_1_TEL3 = hdnREN_1_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_1_FAX = hdnREN_1_FAX.Value          '�e�`�w�ԍ��Q
        gstrREN_1_BIKO = hdnREN_1_BIKO.Value
        gstrREN_1_EDT_DATE = hdnREN_1_EDT_DATE.Value
        gstrREN_1_TIME = hdnREN_1_TIME.Value
        gstrREN_2_CODE = hdnREN_2_TANCD.Value
        gstrREN_2_NA = hdnREN_2_NA.Value
        gstrREN_2_TEL1 = hdnREN_2_TEL1.Value
        gstrREN_2_TEL2 = hdnREN_2_TEL2.Value
        gstrREN_2_TEL3 = hdnREN_2_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_2_FAX = hdnREN_2_FAX.Value          '�e�`�w�ԍ��R
        gstrREN_2_BIKO = hdnREN_2_BIKO.Value
        gstrREN_2_EDT_DATE = hdnREN_2_EDT_DATE.Value
        gstrREN_2_TIME = hdnREN_2_TIME.Value
        gstrREN_3_CODE = hdnREN_3_TANCD.Value
        gstrREN_3_NA = hdnREN_3_NA.Value
        gstrREN_3_TEL1 = hdnREN_3_TEL1.Value
        gstrREN_3_TEL2 = hdnREN_3_TEL2.Value
        gstrREN_3_TEL3 = hdnREN_3_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_3_FAX = hdnREN_3_FAX.Value          '�e�`�w�ԍ��S
        gstrREN_3_BIKO = hdnREN_3_BIKO.Value
        gstrREN_3_EDT_DATE = hdnREN_3_EDT_DATE.Value
        gstrREN_3_TIME = hdnREN_3_TIME.Value

        ' 2008/10/31 T.Watabe add
        gstrREN_4_CODE = hdnREN_4_TANCD.Value              '�T
        gstrREN_4_NA = hdnREN_4_NA.Value
        gstrREN_4_TEL1 = hdnREN_4_TEL1.Value
        gstrREN_4_TEL2 = hdnREN_4_TEL2.Value
        gstrREN_4_TEL3 = hdnREN_4_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_4_FAX = hdnREN_4_FAX.Value
        gstrREN_4_BIKO = hdnREN_4_BIKO.Value
        gstrREN_5_CODE = hdnREN_5_TANCD.Value              '�U
        gstrREN_5_NA = hdnREN_5_NA.Value
        gstrREN_5_TEL1 = hdnREN_5_TEL1.Value
        gstrREN_5_TEL2 = hdnREN_5_TEL2.Value
        gstrREN_5_TEL3 = hdnREN_5_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_5_FAX = hdnREN_5_FAX.Value
        gstrREN_5_BIKO = hdnREN_5_BIKO.Value
        gstrREN_6_CODE = hdnREN_6_TANCD.Value              '�V
        gstrREN_6_NA = hdnREN_6_NA.Value
        gstrREN_6_TEL1 = hdnREN_6_TEL1.Value
        gstrREN_6_TEL2 = hdnREN_6_TEL2.Value
        gstrREN_6_TEL3 = hdnREN_6_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_6_FAX = hdnREN_6_FAX.Value
        gstrREN_6_BIKO = hdnREN_6_BIKO.Value
        gstrREN_7_CODE = hdnREN_7_TANCD.Value              '�W
        gstrREN_7_NA = hdnREN_7_NA.Value
        gstrREN_7_TEL1 = hdnREN_7_TEL1.Value
        gstrREN_7_TEL2 = hdnREN_7_TEL2.Value
        gstrREN_7_TEL3 = hdnREN_7_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_7_FAX = hdnREN_7_FAX.Value
        gstrREN_7_BIKO = hdnREN_7_BIKO.Value
        gstrREN_8_CODE = hdnREN_8_TANCD.Value              '�X
        gstrREN_8_NA = hdnREN_8_NA.Value
        gstrREN_8_TEL1 = hdnREN_8_TEL1.Value
        gstrREN_8_TEL2 = hdnREN_8_TEL2.Value
        gstrREN_8_TEL3 = hdnREN_8_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_8_FAX = hdnREN_8_FAX.Value
        gstrREN_8_BIKO = hdnREN_8_BIKO.Value
        gstrREN_9_CODE = hdnREN_9_TANCD.Value              '�P�O
        gstrREN_9_NA = hdnREN_9_NA.Value
        gstrREN_9_TEL1 = hdnREN_9_TEL1.Value
        gstrREN_9_TEL2 = hdnREN_9_TEL2.Value
        gstrREN_9_TEL3 = hdnREN_9_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_9_FAX = hdnREN_9_FAX.Value
        gstrREN_9_BIKO = hdnREN_9_BIKO.Value

        ' 2010/05/10 T.Watabe add
        gstrREN_10_CODE = hdnREN_10_TANCD.Value
        gstrREN_10_NA = hdnREN_10_NA.Value
        gstrREN_10_TEL1 = hdnREN_10_TEL1.Value
        gstrREN_10_TEL2 = hdnREN_10_TEL2.Value
        gstrREN_10_TEL3 = hdnREN_10_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_10_FAX = hdnREN_10_FAX.Value
        gstrREN_10_BIKO = hdnREN_10_BIKO.Value
        gstrREN_11_CODE = hdnREN_11_TANCD.Value
        gstrREN_11_NA = hdnREN_11_NA.Value
        gstrREN_11_TEL1 = hdnREN_11_TEL1.Value
        gstrREN_11_TEL2 = hdnREN_11_TEL2.Value
        gstrREN_11_TEL3 = hdnREN_11_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_11_FAX = hdnREN_11_FAX.Value
        gstrREN_11_BIKO = hdnREN_11_BIKO.Value
        gstrREN_12_CODE = hdnREN_12_TANCD.Value
        gstrREN_12_NA = hdnREN_12_NA.Value
        gstrREN_12_TEL1 = hdnREN_12_TEL1.Value
        gstrREN_12_TEL2 = hdnREN_12_TEL2.Value
        gstrREN_12_TEL3 = hdnREN_12_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_12_FAX = hdnREN_12_FAX.Value
        gstrREN_12_BIKO = hdnREN_12_BIKO.Value
        gstrREN_13_CODE = hdnREN_13_TANCD.Value
        gstrREN_13_NA = hdnREN_13_NA.Value
        gstrREN_13_TEL1 = hdnREN_13_TEL1.Value
        gstrREN_13_TEL2 = hdnREN_13_TEL2.Value
        gstrREN_13_TEL3 = hdnREN_13_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_13_FAX = hdnREN_13_FAX.Value
        gstrREN_13_BIKO = hdnREN_13_BIKO.Value
        gstrREN_14_CODE = hdnREN_14_TANCD.Value
        gstrREN_14_NA = hdnREN_14_NA.Value
        gstrREN_14_TEL1 = hdnREN_14_TEL1.Value
        gstrREN_14_TEL2 = hdnREN_14_TEL2.Value
        gstrREN_14_TEL3 = hdnREN_14_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_14_FAX = hdnREN_14_FAX.Value
        gstrREN_14_BIKO = hdnREN_14_BIKO.Value
        gstrREN_15_CODE = hdnREN_15_TANCD.Value
        gstrREN_15_NA = hdnREN_15_NA.Value
        gstrREN_15_TEL1 = hdnREN_15_TEL1.Value
        gstrREN_15_TEL2 = hdnREN_15_TEL2.Value
        gstrREN_15_TEL3 = hdnREN_15_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_15_FAX = hdnREN_15_FAX.Value
        gstrREN_15_BIKO = hdnREN_15_BIKO.Value
        gstrREN_16_CODE = hdnREN_16_TANCD.Value
        gstrREN_16_NA = hdnREN_16_NA.Value
        gstrREN_16_TEL1 = hdnREN_16_TEL1.Value
        gstrREN_16_TEL2 = hdnREN_16_TEL2.Value
        gstrREN_16_TEL3 = hdnREN_16_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_16_FAX = hdnREN_16_FAX.Value
        gstrREN_16_BIKO = hdnREN_16_BIKO.Value
        gstrREN_17_CODE = hdnREN_17_TANCD.Value
        gstrREN_17_NA = hdnREN_17_NA.Value
        gstrREN_17_TEL1 = hdnREN_17_TEL1.Value
        gstrREN_17_TEL2 = hdnREN_17_TEL2.Value
        gstrREN_17_TEL3 = hdnREN_17_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_17_FAX = hdnREN_17_FAX.Value
        gstrREN_17_BIKO = hdnREN_17_BIKO.Value
        gstrREN_18_CODE = hdnREN_18_TANCD.Value
        gstrREN_18_NA = hdnREN_18_NA.Value
        gstrREN_18_TEL1 = hdnREN_18_TEL1.Value
        gstrREN_18_TEL2 = hdnREN_18_TEL2.Value
        gstrREN_18_TEL3 = hdnREN_18_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_18_FAX = hdnREN_18_FAX.Value
        gstrREN_18_BIKO = hdnREN_18_BIKO.Value
        gstrREN_19_CODE = hdnREN_19_TANCD.Value
        gstrREN_19_NA = hdnREN_19_NA.Value
        gstrREN_19_TEL1 = hdnREN_19_TEL1.Value
        gstrREN_19_TEL2 = hdnREN_19_TEL2.Value
        gstrREN_19_TEL3 = hdnREN_19_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_19_FAX = hdnREN_19_FAX.Value
        gstrREN_19_BIKO = hdnREN_19_BIKO.Value
        gstrREN_20_CODE = hdnREN_20_TANCD.Value
        gstrREN_20_NA = hdnREN_20_NA.Value
        gstrREN_20_TEL1 = hdnREN_20_TEL1.Value
        gstrREN_20_TEL2 = hdnREN_20_TEL2.Value
        gstrREN_20_TEL3 = hdnREN_20_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_20_FAX = hdnREN_20_FAX.Value
        gstrREN_20_BIKO = hdnREN_20_BIKO.Value
        gstrREN_21_CODE = hdnREN_21_TANCD.Value
        gstrREN_21_NA = hdnREN_21_NA.Value
        gstrREN_21_TEL1 = hdnREN_21_TEL1.Value
        gstrREN_21_TEL2 = hdnREN_21_TEL2.Value
        gstrREN_21_TEL3 = hdnREN_21_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_21_FAX = hdnREN_21_FAX.Value
        gstrREN_21_BIKO = hdnREN_21_BIKO.Value
        gstrREN_22_CODE = hdnREN_22_TANCD.Value
        gstrREN_22_NA = hdnREN_22_NA.Value
        gstrREN_22_TEL1 = hdnREN_22_TEL1.Value
        gstrREN_22_TEL2 = hdnREN_22_TEL2.Value
        gstrREN_22_TEL3 = hdnREN_22_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_22_FAX = hdnREN_22_FAX.Value
        gstrREN_22_BIKO = hdnREN_22_BIKO.Value
        gstrREN_23_CODE = hdnREN_23_TANCD.Value
        gstrREN_23_NA = hdnREN_23_NA.Value
        gstrREN_23_TEL1 = hdnREN_23_TEL1.Value
        gstrREN_23_TEL2 = hdnREN_23_TEL2.Value
        gstrREN_23_TEL3 = hdnREN_23_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_23_FAX = hdnREN_23_FAX.Value
        gstrREN_23_BIKO = hdnREN_23_BIKO.Value
        gstrREN_24_CODE = hdnREN_24_TANCD.Value
        gstrREN_24_NA = hdnREN_24_NA.Value
        gstrREN_24_TEL1 = hdnREN_24_TEL1.Value
        gstrREN_24_TEL2 = hdnREN_24_TEL2.Value
        gstrREN_24_TEL3 = hdnREN_24_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_24_FAX = hdnREN_24_FAX.Value
        gstrREN_24_BIKO = hdnREN_24_BIKO.Value
        gstrREN_25_CODE = hdnREN_25_TANCD.Value
        gstrREN_25_NA = hdnREN_25_NA.Value
        gstrREN_25_TEL1 = hdnREN_25_TEL1.Value
        gstrREN_25_TEL2 = hdnREN_25_TEL2.Value
        gstrREN_25_TEL3 = hdnREN_25_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_25_FAX = hdnREN_25_FAX.Value
        gstrREN_25_BIKO = hdnREN_25_BIKO.Value
        gstrREN_26_CODE = hdnREN_26_TANCD.Value
        gstrREN_26_NA = hdnREN_26_NA.Value
        gstrREN_26_TEL1 = hdnREN_26_TEL1.Value
        gstrREN_26_TEL2 = hdnREN_26_TEL2.Value
        gstrREN_26_TEL3 = hdnREN_26_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_26_FAX = hdnREN_26_FAX.Value
        gstrREN_26_BIKO = hdnREN_26_BIKO.Value
        gstrREN_27_CODE = hdnREN_27_TANCD.Value
        gstrREN_27_NA = hdnREN_27_NA.Value
        gstrREN_27_TEL1 = hdnREN_27_TEL1.Value
        gstrREN_27_TEL2 = hdnREN_27_TEL2.Value
        gstrREN_27_TEL3 = hdnREN_27_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_27_FAX = hdnREN_27_FAX.Value
        gstrREN_27_BIKO = hdnREN_27_BIKO.Value
        gstrREN_28_CODE = hdnREN_28_TANCD.Value
        gstrREN_28_NA = hdnREN_28_NA.Value
        gstrREN_28_TEL1 = hdnREN_28_TEL1.Value
        gstrREN_28_TEL2 = hdnREN_28_TEL2.Value
        gstrREN_28_TEL3 = hdnREN_28_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_28_FAX = hdnREN_28_FAX.Value
        gstrREN_28_BIKO = hdnREN_28_BIKO.Value
        gstrREN_29_CODE = hdnREN_29_TANCD.Value
        gstrREN_29_NA = hdnREN_29_NA.Value
        gstrREN_29_TEL1 = hdnREN_29_TEL1.Value
        gstrREN_29_TEL2 = hdnREN_29_TEL2.Value
        gstrREN_29_TEL3 = hdnREN_29_TEL3.Value        ' 2013/05/27 T.Ono add
        gstrREN_29_FAX = hdnREN_29_FAX.Value
        gstrREN_29_BIKO = hdnREN_29_BIKO.Value

        '2012/03/26 START ADD W.GANEKO
        gstrREN_MAIL = hdnREN_0_MAIL.Value
        gstrREN_1_MAIL = hdnREN_1_MAIL.Value
        gstrREN_2_MAIL = hdnREN_2_MAIL.Value
        gstrREN_3_MAIL = hdnREN_3_MAIL.Value
        gstrREN_4_MAIL = hdnREN_4_MAIL.Value
        gstrREN_5_MAIL = hdnREN_5_MAIL.Value
        gstrREN_6_MAIL = hdnREN_6_MAIL.Value
        gstrREN_7_MAIL = hdnREN_7_MAIL.Value
        gstrREN_8_MAIL = hdnREN_8_MAIL.Value
        gstrREN_9_MAIL = hdnREN_9_MAIL.Value
        gstrREN_10_MAIL = hdnREN_10_MAIL.Value
        gstrREN_11_MAIL = hdnREN_11_MAIL.Value
        gstrREN_12_MAIL = hdnREN_12_MAIL.Value
        gstrREN_13_MAIL = hdnREN_13_MAIL.Value
        gstrREN_14_MAIL = hdnREN_14_MAIL.Value
        gstrREN_15_MAIL = hdnREN_15_MAIL.Value
        gstrREN_16_MAIL = hdnREN_16_MAIL.Value
        gstrREN_17_MAIL = hdnREN_17_MAIL.Value
        gstrREN_18_MAIL = hdnREN_18_MAIL.Value
        gstrREN_19_MAIL = hdnREN_19_MAIL.Value
        gstrREN_20_MAIL = hdnREN_20_MAIL.Value
        gstrREN_21_MAIL = hdnREN_21_MAIL.Value
        gstrREN_22_MAIL = hdnREN_22_MAIL.Value
        gstrREN_23_MAIL = hdnREN_23_MAIL.Value
        gstrREN_24_MAIL = hdnREN_24_MAIL.Value
        gstrREN_25_MAIL = hdnREN_25_MAIL.Value
        gstrREN_26_MAIL = hdnREN_26_MAIL.Value
        gstrREN_27_MAIL = hdnREN_27_MAIL.Value
        gstrREN_28_MAIL = hdnREN_28_MAIL.Value
        gstrREN_29_MAIL = hdnREN_29_MAIL.Value
        gstrREN_MAILPASS = hdnREN_0_MAILPASS.Value
        gstrREN_1_MAILPASS = hdnREN_1_MAILPASS.Value
        gstrREN_2_MAILPASS = hdnREN_2_MAILPASS.Value
        gstrREN_3_MAILPASS = hdnREN_3_MAILPASS.Value
        gstrREN_4_MAILPASS = hdnREN_4_MAILPASS.Value
        gstrREN_5_MAILPASS = hdnREN_5_MAILPASS.Value
        gstrREN_6_MAILPASS = hdnREN_6_MAILPASS.Value
        gstrREN_7_MAILPASS = hdnREN_7_MAILPASS.Value
        gstrREN_8_MAILPASS = hdnREN_8_MAILPASS.Value
        gstrREN_9_MAILPASS = hdnREN_9_MAILPASS.Value
        gstrREN_10_MAILPASS = hdnREN_10_MAILPASS.Value
        gstrREN_11_MAILPASS = hdnREN_11_MAILPASS.Value
        gstrREN_12_MAILPASS = hdnREN_12_MAILPASS.Value
        gstrREN_13_MAILPASS = hdnREN_13_MAILPASS.Value
        gstrREN_14_MAILPASS = hdnREN_14_MAILPASS.Value
        gstrREN_15_MAILPASS = hdnREN_15_MAILPASS.Value
        gstrREN_16_MAILPASS = hdnREN_16_MAILPASS.Value
        gstrREN_17_MAILPASS = hdnREN_17_MAILPASS.Value
        gstrREN_18_MAILPASS = hdnREN_18_MAILPASS.Value
        gstrREN_19_MAILPASS = hdnREN_19_MAILPASS.Value
        gstrREN_20_MAILPASS = hdnREN_20_MAILPASS.Value
        gstrREN_21_MAILPASS = hdnREN_21_MAILPASS.Value
        gstrREN_22_MAILPASS = hdnREN_22_MAILPASS.Value
        gstrREN_23_MAILPASS = hdnREN_23_MAILPASS.Value
        gstrREN_24_MAILPASS = hdnREN_24_MAILPASS.Value
        gstrREN_25_MAILPASS = hdnREN_25_MAILPASS.Value
        gstrREN_26_MAILPASS = hdnREN_26_MAILPASS.Value
        gstrREN_27_MAILPASS = hdnREN_27_MAILPASS.Value
        gstrREN_28_MAILPASS = hdnREN_28_MAILPASS.Value
        gstrREN_29_MAILPASS = hdnREN_29_MAILPASS.Value
        '2012/03/26 END ADD W.GANEKO

        gstrREN_DENWABIKO = hdnREN_DENWABIKO.Value
        gstrFAX_TITLE_CD = hdnFAX_TITLE_CD.Value    '�e�`�w�^�C�g���R�[�h
        gstrREN_FAXTITLE = hdnREN_FAXTITLE.Value    '�e�`�w�^�C�g��
        gstrREN_FAX_REN = hdnREN_FAXREN.Value       '������
        gstrSTD_CD = hdnSTD_CD.Value
        gstrSTD = txtSTD.Text
        gstrSTD_KYOTEN_CD = hdnSTD_KYOTEN_CD.Value
        gstrSTD_KYOTEN = txtSTD_KYOTEN.Text
        gstrSTD_TEL = txtSTD_TEL.Text
        '//�Ή�DB�ǉ�����-----------------
        gstrBOMB_TYPE = hdnBOMB_TYPE.Value
        gstrGAS_STOP = DateFncC.mHenkanGet(txtGAS_START.Text)
        gstrGAS_DELE = DateFncC.mHenkanGet(txtGAS_DELE.Text)
        gstrGAS_RESTART = DateFncC.mHenkanGet(txtGAS_RESTART.Text)
        '2016/02/02 w.ganeko 2015�Ď����P ��1-3 start
        gstrKANSHI_BIKO = txtKANSHI_BIKO.Text
        gstrRENTEL2 = hdnRENTEL2.Value
        gstrRENTEL2_BIKO = hdnRENTEL2_BIKO.Value
        gstrRENTEL2_UPD_DATE = DateFncC.mHenkanGet(hdnRENTEL2_UPD_DATE.Value)
        gstrRENTEL3 = hdnRENTEL3.Value
        gstrRENTEL3_BIKO = hdnRENTEL3_BIKO.Value
        gstrRENTEL3_UPD_DATE = DateFncC.mHenkanGet(hdnRENTEL3_UPD_DATE.Value)
        gstrTelJVG = hdnTelJVG.Value
        '2016/02/02 w.ganeko 2015�Ď����P ��1-3 end
        '2016/12/12 H.Mori add 2015�Ď����P No5-1 START
        gstrTELAB = hdnTELAB.Value
        gstrDAI3RENDORENTEL = hdnDAI3RENDORENTEL.Value
        '2016/12/12 H.Mori add 2015�Ď����P No5-1
        '2016/12/14 H.Mori add 2016�Ď����P No6-3 START
        If hdnFAXSPOTKBN.Value = "2" Then
            gstrFAXSPOTKBN = "2" '�X�|�b�gFAX���M�ς�
        Else
            gstrFAXSPOTKBN = "1" '�X�|�b�gFAX�����M
        End If
        '2016/12/14 H.Mori add 2016�Ď����P No6-3 END
        '2016/12/22 H.Mori add 2016�Ď����P No4-6 START
        gstrDAIHYO_NAME = hdnDAIHYO_NAME.Value
        gstrHOKBN = hdnHOKBN.Value
        gstrYOTOKBN = hdnYOTOKBN.Value
        gstrHANBCD = hdnHANBCD.Value
        gstrKINRENCD = hdnGROUPCD.Value
        gstrJMNAME = hdnGROUPNM.Value   ' 2023/01/04 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 
        '2016/12/22 H.Mori add 2016�Ď����P No4-6 END
        '2017/10/16 H.Mori add 2017���P�J�� No4-1 START
        gstrSHUGOU = hdnSHUGOU.Value
        '2017/10/16 H.Mori add 2017���P�J�� No4-1 END

        '//-------------------------------
        '�d�b���M���O�o�^�p
        gstrDialKbns = hdnDialKbns.Value
        gstrDialNumbers = hdnDialNumbers.Value
        gstrDialAites = hdnDialAitename.Value
        gstrDialResult = hdnDialResult.Value
        gstrDialDates = hdnDialDates.Value
        gstrDialTimes = hdnDialTimes.Value
        gstrDialStates = hdnDialStates.Value
        gstrSDSKBN = hdnSDSKBN.Value ' 2008/10/17 T.Watabe add

        '�{���H���󋵁@2013/08/23 T.Ono add �Ď����P2013��1
        gstrKAITU_DAY = txtKAITU_DAY.Text


    End Sub

    '******************************************************************************
    ' �ʕ��M�p�l������̑J�ڎ��̉�ʏo��
    '******************************************************************************
    Private Function fncSetData_KEIHOU() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec As String
        'Dim strPar(2) As String ' FAXKBN,FAXKURAKBN,GUIDELINE�i�[�p�@2013/08/07 T.Ono add '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        Dim strPar(4) As String ' FAXKBN,FAXKURAKBN,GUIDELINE,GUIDELINE2,GUIDELINE3 �i�[�p�@2019/11/01 W.GANEKO 2019�Ď����P No8-12 
        Dim strKAITU_DAY As String  ' �{���H���󋵁@2013/08/23 T.Ono add �Ď����P2013��1
        Try
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_KEIHOU start")

            ' 2013/08/07 T.Ono add FAXKBN,FAXKURAKBN,GUIDELINE�͂Ƃ�������ƈႤ���߁A��Ɏ擾
            strPar = fncGetFAXKBN_GUIDE_KEIHOU()
            strKAITU_DAY = fncGetKAITU_DAY_KEIHO()

            '//�x���M�p�l������̉�ʑJ�ڂ̏ꍇ
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT  ")
            strSQL.Append("KEI.SYORI_SERIAL, ")
            strSQL.Append("KEI.FILE_NAME, ")
            strSQL.Append("KEI.REACTION, ")
            strSQL.Append("KEI.IS_PRINTED, ")
            strSQL.Append("KEI.SYONO, ")
            strSQL.Append("KEI.SAYMD AS JUYMD, ")
            strSQL.Append("KEI.SUYMD, ")
            strSQL.Append("KEI.STIME AS JUTIME, ")
            strSQL.Append("KEI.MES_TYPE, ")
            strSQL.Append("KEI.REPLY_CODE, ")
            strSQL.Append("KEI.MEDIA_TYPE, ")
            strSQL.Append("KEI.KANSCD, ")
            strSQL.Append("KEI.KURACD AS CLI_CD, ")
            strSQL.Append("KEI.ACBCD, ")
            strSQL.Append("KEI.JUYOKA, ")
            strSQL.Append("KEI.JUYOKA AS JUYOKA_CD, ")
            '''''strSQL.Append("KEI.ACBCD || KEI.JUYOKA AS JUYOKA_CD, ")
            strSQL.Append("KEI.INFO_1, ")
            strSQL.Append("KEI.INFO_2, ")
            strSQL.Append("SUBSTR(KEI.INFO_2,3,1) AS RYURYO, ")
            strSQL.Append("KEI.SECURITY_2, ")
            strSQL.Append("KEI.KMYMD, ")
            strSQL.Append("KEI.KMTIME, ")
            strSQL.Append("KEI.JUYONM, ")
            'strSQL.Append("KEI.ADDR, ") ' 2008/10/29 T.Watabe edit �x�񂩂�̏ꍇ�ɁA�Z���������؂�Ȃ��悤�ɑΉ�
            'strSQL.Append("RTRIM(KEI.ADDR || ' ' || KOK.ADD_3) AS ADDR, ")
            strSQL.Append("KOK.ADD_1 || ' ' || KOK.ADD_2 || ' ' || KOK.ADD_3 AS ADDR, ") '2017/10/17 H.Mori mod 2017���P�J�� No4-2
            strSQL.Append("KEI.KMSIN, ")
            strSQL.Append("KEI.NUM_DIGIT, ")
            strSQL.Append("KEI.KMCD1, ")
            strSQL.Append("KEI.KMNM1, ")
            strSQL.Append("KEI.KMCD2, ")
            strSQL.Append("KEI.KMNM2, ")
            strSQL.Append("KEI.KMCD3, ")
            strSQL.Append("KEI.KMNM3, ")
            strSQL.Append("KEI.KMCD4, ")
            strSQL.Append("KEI.KMNM4, ")
            strSQL.Append("KEI.KMCD5, ")
            strSQL.Append("KEI.KMNM5, ")
            strSQL.Append("KEI.KMCD6, ")
            strSQL.Append("KEI.KMNM6, ")
            strSQL.Append("KEI.META_SYUBETU, ")
            strSQL.Append("KEI.KENSIN_MODE, ")
            strSQL.Append("KEI.OKYAKU_FLG AS UNYOCD, ")
            strSQL.Append("KEI.ROC_FRG, ")
            strSQL.Append("KEI.ROC_TIME, ")
            strSQL.Append("KEI.BIKOU, ")          '--- 2005/09/09 ADD Falcon
            strSQL.Append("KOK.NAME, ")
            strSQL.Append("KOK.KANA, ")
            '2005/07/28 NEC UPDATE START
            'strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")           '�ڋq�F�m�b�t�d�b�ԍ��s�O
            'strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")           '�ڋq�F�m�b�t�d�b�ԍ��s��
            '2006/05/23 NEC UPDATE START
            'strSQL.Append("KOK.TELA AS JUTEL1, ")           '�ڋq�F�m�b�t�d�b�ԍ��s�O
            'strSQL.Append("KOK.TELB AS JUTEL2, ")           '�ڋq�F�m�b�t�d�b�ԍ��s��
            strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")           '�ڋq�F�m�b�t�d�b�ԍ��s�O
            strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")           '�ڋq�F�m�b�t�d�b�ԍ��s��
            '2006/05/23 NEC UPDATE END
            '2005/07/28 NEC UPDATE END
            strSQL.Append("KEI.JUTEL AS RENTEL, ")              '�x��F�d�b�ԍ�
            strSQL.Append("KOK.KANKENSAKU_TEL AS KTELNO, ")     '�ڋq�F�����p�d�b�ԍ�
            strSQL.Append("KOK.USR_MEMO, ")
            strSQL.Append("KOK.USR_MEMO AS GENIN_KIJI, ")
            strSQL.Append("KOK.NCU_CON, ")
            strSQL.Append("KOK.HANBAI_KBN, ") '2015/11/25 H.Mori add 2015���P�J�� No1
            strSQL.Append("KOK.KYOKTKBN, ") '2016/12/02 H.Mori add 2016���P�J�� No4-3
            strSQL.Append("KOK.SETSUBI, ")
            strSQL.Append("KOK.KYOKYU_MK, ")
            strSQL.Append("KOK.MAP_CD, ")
            strSQL.Append("KOK.BOMB_TYPE, ")
            strSQL.Append("KOK.BOMB_YOUKI1, ")
            strSQL.Append("KOK.BOMB_SUU1, ")
            strSQL.Append("KOK.YOBI_FLG1 AS BOMB_RYO1, ")
            strSQL.Append("KOK.BOMB_YOUKI2, ")
            strSQL.Append("KOK.BOMB_SUU2, ")
            strSQL.Append("KOK.YOBI_FLG2 AS BOMB_RYO2, ")
            strSQL.Append("KOK.BOMB_YOUKI3, ")
            strSQL.Append("KOK.BOMB_SUU3, ")
            strSQL.Append("KOK.YOBI_FLG3 AS BOMB_RYO3, ")
            strSQL.Append("KOK.BOMB_YOUKI4, ")
            strSQL.Append("KOK.BOMB_SUU4, ")
            strSQL.Append("KOK.YOBI_FLG4 AS BOMB_RYO4, ")
            strSQL.Append("KOK.SIYOU3, ")
            strSQL.Append("KOK.SIYOU4, ")
            strSQL.Append("KOK.BOMV_HAISO1, ")
            strSQL.Append("KOK.BOMV_SISIN1, ")
            strSQL.Append("KOK.BOMV_HAISO2, ")
            strSQL.Append("KOK.BOMV_SISIN2, ")
            strSQL.Append("KOK.HAISO_YOTEI, ")
            strSQL.Append("KOK.BOMB_DATE1, ")
            strSQL.Append("KOK.BOMB_SISIN1, ")
            strSQL.Append("KOK.BOMB_DATE2, ")
            strSQL.Append("KOK.BOMB_SISIN2, ")
            strSQL.Append("KOK.KENSIN_DAY1, ")
            strSQL.Append("KOK.KENSINTI1, ")
            strSQL.Append("KOK.KENSIN_DAY2, ")
            strSQL.Append("KOK.KENSINTI2, ")
            strSQL.Append("KOK.SIYOU1, ")
            strSQL.Append("KOK.SIYOU2, ")
            strSQL.Append("KOK.GAS_NAME1, ")
            strSQL.Append("KOK.GAS_NAME2, ")
            strSQL.Append("KOK.GAS_NAME3, ")
            strSQL.Append("KOK.GAS_NAME4, ")
            strSQL.Append("KOK.GAS_NAME5, ")
            strSQL.Append("KOK.GAS_SUU1, ")
            strSQL.Append("KOK.GAS_SUU2, ")
            strSQL.Append("KOK.GAS_SUU3, ")
            strSQL.Append("KOK.GAS_SUU4, ")
            strSQL.Append("KOK.GAS_SUU5, ")
            strSQL.Append("KOK.GAS_SEIF1, ")
            strSQL.Append("KOK.GAS_SEIF2, ")
            strSQL.Append("KOK.GAS_SEIF3, ")
            strSQL.Append("KOK.GAS_SEIF4, ")
            strSQL.Append("KOK.GAS_SEIF5, ")
            strSQL.Append("KOK.GAS_STOP AS GAS_START, ")
            strSQL.Append("KOK.GAS_DELE, ")
            strSQL.Append("KOK.GAS_RESTART, ")
            strSQL.Append("KOK.KANSHI_BIKO, ")          '2016/02/02 w.ganeko 2015�Ď����P ��1-3
            strSQL.Append("KOK.RENTEL2, ")                '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL2_BIKO, ")           '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL2_UPD_DATE, ")       '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL3, ")                '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL3_BIKO, ")           '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL3_UPD_DATE, ")       '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.TELA || TELB TELAB, ")     '2016/12/12 add H.Mori 2016���P�J�� No5-1
            strSQL.Append("KOK.DAI3RENDORENTEL, ")        '2016/12/12 add H.Mori 2016���P�J�� No5-1
            strSQL.Append("KOK.DAIHYO_NAME, ")            '2016/12/22 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("KOK.HOKBN, ")                  '2016/12/22 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("KOK.YOTOKBN, ")                '2016/12/12 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("KOK.HANBCD, ")                 '2016/12/12 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("KOK.SHUGOU, ")                 '2017/10/16 H.Mori add 2017���P�J�� No4-1
            strSQL.Append("CLI.KEN_NAME, ")
            strSQL.Append("JAS.JA_CD, ")
            strSQL.Append("JAS.JA_NAME, ")
            strSQL.Append("JAS.JAS_NAME, ")
            strSQL.Append("PU1.NAME AS METASYU_NAI, ")
            strSQL.Append("PU2.NAME AS UNYO_NAI, ")
            strSQL.Append("'2' AS HATKBN, ")            '�����敪[2:�ً}�x��]
            strSQL.Append("PU3.NAME AS HATKBN_NAI, ")
            strSQL.Append("'1' AS SDSKBN, ")            '�o����Џ����敪[1:������] '2008/10/17 T.Watabe add
            'strSQL.Append("KEI.KMYMD  AS NCUHATYMD, ")  '������   '2008/10/15 T.Watabe add
            'strSQL.Append("KEI.KMTIME AS NCUHATTIME ")  '�������� '2008/10/15 T.Watabe add
            strSQL.Append("NVL(KEI.NCUHATYMD,  KEI.KMYMD)  AS NCUHATYMD, ")  '[�x��]NCU�x�񔭐���   '2009/03/23 T.Watabe edit
            strSQL.Append("NVL(KEI.NCUHATTIME, KEI.KMTIME) AS NCUHATTIME ")  '[�x��]NCU�x�񔭐����� '2009/03/23 T.Watabe edit
            strSQL.Append(",KOK.TUSIN ")                '�e���R��.�ʐM���[�h 2008/10/24 T.Watabe add
            ' ������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TA1.FAXKURAKBN, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.FAXKURAKBN ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.FAXKURAKBN) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     '0' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS FAXKURAKBN ")
            'strSQL.Append(",NVL(TA2.GUIDELINE, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.GUIDELINE ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.GUIDELINE) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     ' ' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS GUIDELINE ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TA3.FAXKBN, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.FAXKBN ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.FAXKBN) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     '0' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS FAXKBN ")
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            strSQL.Append(", ")
            strSQL.Append("'" & strPar(0) & "' AS FAXKBN, ")
            strSQL.Append("'" & strPar(1) & "' AS FAXKURAKBN, ")
            strSQL.Append("'" & strPar(2) & "' AS GUIDELINE ")
            strSQL.Append(",'" & strPar(3) & "' AS GUIDELINE2 ")  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",'" & strPar(4) & "' AS GUIDELINE3 ")  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            strSQL.Append(", '" & strKAITU_DAY & "' AS KAITU_DAY ")  '�{���H���󋵁@2013/08/23 T.Ono add �Ď����P2013��1 
            strSQL.Append(",NVL(H3.GROUPCD, NVL(H2.GROUPCD, NVL(H1.GROUPCD, ''))) AS HANJICD ") '�̔����Ǝ҃R�[�h�@2014/12/16 T.Ono add 2014���P�J�� No2
            strSQL.Append(",NVL2(H3.GROUPCD, H3.HANJIGYOSYANM, NVL2(H2.GROUPCD, H2.HANJIGYOSYANM ,NVL2(H1.GROUPCD, H1.HANJIGYOSYANM,''))) AS HANJINM ") '�̔����ƎҖ��@2014/12/16 T.Ono add 2014���P�J�� No2
            strSQL.Append("FROM T10_KEIHO KEI, ")
            strSQL.Append("     SHAMAS KOK, ")
            strSQL.Append("     CLIMAS CLI, ")
            strSQL.Append("     HN2MAS JAS, ")
            strSQL.Append("     M06_PULLDOWN PU1, ")
            strSQL.Append("     M06_PULLDOWN PU2, ")
            strSQL.Append("     M06_PULLDOWN PU3  ")
            '2014/12/16 T.Ono add 2014���P�J�� No2 START
            strSQL.Append("     ,M09_JAGROUP G1 ")      'JA�P��
            strSQL.Append("     ,M10_HANJIGYOSYA H1 ")
            strSQL.Append("     ,M09_JAGROUP G2 ")      '���[�U�[�͈�
            strSQL.Append("     ,M10_HANJIGYOSYA H2 ")
            strSQL.Append("     ,M09_JAGROUP G3 ")      '���[�U�[��
            strSQL.Append("     ,M10_HANJIGYOSYA H3 ")
            '2014/12/16 T.Ono add 2014���P�J�� No2 END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA1 ") 'FAX�s�v(�ײ���)�t���O�擾
            'strSQL.Append("     ,M05_TANTO TA2 ") 'JA���ӎ����擾
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA3 ") 'FAX�s�v(JA)�t���O�擾
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            strSQL.Append("WHERE KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("  AND KEI.KURACD = KOK.CLI_CD(+) ")
            strSQL.Append("  AND KEI.ACBCD  = KOK.HAN_CD(+) ")
            strSQL.Append("  AND KEI.JUYOKA = KOK.USER_CD(+) ")
            strSQL.Append("  AND KEI.KURACD = CLI.CLI_CD(+) ")
            strSQL.Append("  AND KEI.KURACD = JAS.CLI_CD(+) ")
            strSQL.Append("  AND KEI.ACBCD  = JAS.HAN_CD(+) ")
            strSQL.Append("  AND '06' = PU1.KBN(+) ")               '���[�^���
            strSQL.Append("  AND KEI.META_SYUBETU = PU1.CD(+) ")
            strSQL.Append("  AND '04' = PU2.KBN(+) ")               '���q�l�t���O
            strSQL.Append("  AND KEI.OKYAKU_FLG = PU2.CD(+) ")
            strSQL.Append("  AND '08' = PU3.KBN(+) ")               '�����敪[2:�ً}�x��]
            strSQL.Append("  AND '2' = PU3.CD(+) ")
            '�̔����ƎҖ��̎擾�@2014/12/16 T.Ono add 2014���P�J�� No2 START
            'JA�x���P��
            strSQL.Append("  AND G1.KBN(+) = '001' ")
            strSQL.Append("  AND G1.KURACD(+) = KEI.KURACD ")
            strSQL.Append("  AND G1.ACBCD(+) = KEI.ACBCD ")
            strSQL.Append("  AND G1.USERCD_FROM(+) IS NULL ")
            strSQL.Append("  AND G1.USERCD_TO(+) IS NULL ")
            strSQL.Append("  AND G1.GROUPCD = H1.GROUPCD(+) ")
            '���[�U�[�͈�
            strSQL.Append("  AND G2.KBN(+) = '001' ")
            strSQL.Append("  AND G2.KURACD(+) = KEI.KURACD ")
            strSQL.Append("  AND G2.ACBCD(+) = KEI.ACBCD ")
            strSQL.Append("  AND KEI.JUYOKA BETWEEN G2.USERCD_FROM(+) AND G2.USERCD_TO(+) ")
            strSQL.Append("  AND G2.USERCD_TO(+) IS NOT NULL ")
            strSQL.Append("  AND G2.GROUPCD = H2.GROUPCD(+) ")
            '���[�U�[��
            strSQL.Append("  AND G3.KBN(+) = '001' ")
            strSQL.Append("  AND G3.KURACD(+) = KEI.KURACD ")
            strSQL.Append("  AND G3.ACBCD(+) = KEI.ACBCD ")
            strSQL.Append("  AND G3.USERCD_FROM(+) = KEI.JUYOKA ")
            strSQL.Append("  AND G3.USERCD_TO(+) IS NULL ")
            strSQL.Append("  AND G3.GROUPCD = H3.GROUPCD(+) ")
            '2014/12/16 T.Ono add 2014���P�J�� No2 END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA1.KBN(+) ")
            'strSQL.Append("  AND KEI.KURACD = TA1.KURACD(+) ")
            'strSQL.Append("  AND TA1.FAXKURAKBN(+) IS NOT NULL ")
            'strSQL.Append("  AND TA1.CODE(+) = KEI.ACBCD ")
            'strSQL.Append("  AND '01' = TA1.TANCD(+) ")
            'strSQL.Append("  AND '3' = TA2.KBN(+) ")
            'strSQL.Append("  AND KEI.KURACD = TA2.KURACD(+) ")
            'strSQL.Append("  AND TA2.GUIDELINE(+) IS NOT NULL ")
            'strSQL.Append("  AND TA2.CODE(+) = KEI.ACBCD ")
            'strSQL.Append("  AND '01' = TA2.TANCD(+) ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA3.KBN(+) ")
            'strSQL.Append("  AND KEI.KURACD = TA3.KURACD(+) ")
            'strSQL.Append("  AND TA3.FAXKBN(+) IS NOT NULL ")
            'strSQL.Append("  AND TA3.CODE(+) = KEI.ACBCD ")
            'strSQL.Append("  AND '01' = TA3.TANCD(+) ")
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("SYORI_SERIAL", True, hdnKEY_SERIAL.Value)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToInt32(dbData.Tables(0).Rows.Count) = 0 Then
                strMsg.Append("alert('�Ώۃf�[�^�����݂��܂���');")
                strRec = "ERROR"
            Else
                '//�f�[�^���o�͂��܂�
                Call fncDataSet(dbData, "KEIHOU")
                strRec = "OK"
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

            '--- ��2005/04/22 MOD Falcon�� ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ��2005/04/22 MOD Falcon�� ---
        End Try

        '--- ��2005/04/22 DEL Falcon�� ---
        'dbData.Dispose()
        '--- ��2005/04/22 DEL Falcon�� ---
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_KEIHOU end")

        Return strRec
    End Function

    '******************************************************************************
    ' �ڋq������ʂ���̑J�ڎ��̉�ʏo��
    '******************************************************************************
    Private Function fncSetData_KOKYAKU() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec As String
        'Dim strPar(2) As String ' FAXKBN,FAXKURAKBN,GUIDELINE�i�[�p�@2013/08/07 T.Ono add  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        Dim strPar(4) As String ' FAXKBN,FAXKURAKBN,GUIDELINE,GUIDELINE2,GUIDELINE3 �i�[�p�@2019/11/01 W.GANEKO 2019�Ď����P No8-12 
        Dim strKAITU_DAY As String  ' �{���H���󋵁@2013/08/23 T.Ono add �Ď����P2013��1

        Try
            ' 2013/08/07 T.Ono add FAXKBN,FAXKURAKBN,GUIDELINE�͂Ƃ�������ƈႤ���߁A��Ɏ擾
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_KOKYAKU start")
            strPar = fncGetFAXKBN_GUIDE_KOKYAKU()
            strKAITU_DAY = fncGetKAITU_DAY_KOKYAKU()

            '//�ڋq��������̉�ʑJ�ڂ̏ꍇ
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("TO_CHAR(SYSDATE,'YYYYMMDD') AS KMYMD, ") '��M��
            strSQL.Append("TO_CHAR(SYSDATE,'HH24MI') AS KMTIME, ") '��M����
            strSQL.Append("KOK.CLI_CD, ")
            strSQL.Append("KOK.HAN_CD AS ACBCD, ")
            strSQL.Append("KOK.USER_CD AS JUYOKA_CD, ")
            strSQL.Append("KOK.NAME AS JUYONM, ")
            strSQL.Append("KOK.KANA, ")
            strSQL.Append("KOK.USER_FLG AS UNYOCD, ")
            'strSQL.Append("KOK.ADD_1 || KOK.ADD_2 || KOK.ADD_3 AS ADDR, ")
            strSQL.Append("KOK.ADD_1 || ' ' || KOK.ADD_2 || ' ' || KOK.ADD_3 AS ADDR, ") ' 2008/10/29 T.Watabe edit
            '2005/07/29 NEC UPDATE START
            'strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")                   '�ڋq�F�m�b�t�d�b�ԍ��s�O
            'strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")                   '�ڋq�F�m�b�t�d�b�ԍ��s��
            '2006/05/23 NEC UPDATE START
            'strSQL.Append("KOK.TELA AS JUTEL1, ")                   '�ڋq�F�m�b�t�d�b�ԍ��s�O
            'strSQL.Append("KOK.TELB AS JUTEL2, ")                   '�ڋq�F�m�b�t�d�b�ԍ��s��
            strSQL.Append("KOK.NCU_TELA AS JUTEL1, ")                   '�ڋq�F�m�b�t�d�b�ԍ��s�O
            strSQL.Append("KOK.NCU_TELB AS JUTEL2, ")                   '�ڋq�F�m�b�t�d�b�ԍ��s��
            '2006/05/23 NEC UPDATE END
            '2005/07/29 NEC UPDATE END
            '2006/06/06 NEC UPDATE START
            'strSQL.Append("KOK.REN_TELA || KOK.REN_TELB AS RENTEL, ")   '�ڋq�F�A���d�b�ԍ�
            strSQL.Append("KOK.KANKENSAKU_TEL AS RENTEL, ")   '�ڋq�F�A���d�b�ԍ�
            '2005/06/06 NEC UPDATE END
            strSQL.Append("KOK.KANKENSAKU_TEL AS KTELNO, ")             '�ڋq�F�����p�d�b�ԍ�
            strSQL.Append("KOK.USR_MEMO, ")
            strSQL.Append("KOK.USR_MEMO AS GENIN_KIJI, ")
            strSQL.Append("KOK.NCU_CON, ")
            strSQL.Append("KOK.HANBAI_KBN, ") '2015/11/25 H.Mori add 2015���P�J�� No1
            strSQL.Append("KOK.KYOKTKBN, ") '2016/12/02 H.Mori add 2016���P�J�� No4-3
            strSQL.Append("KOK.SETSUBI, ")
            strSQL.Append("KOK.KYOKYU_MK, ")
            strSQL.Append("KOK.MAP_CD, ")
            strSQL.Append("KOK.BOMB_TYPE, ")
            strSQL.Append("KOK.BOMB_YOUKI1, ")
            strSQL.Append("KOK.BOMB_SUU1, ")
            strSQL.Append("KOK.YOBI_FLG1 AS BOMB_RYO1, ")
            strSQL.Append("KOK.BOMB_YOUKI2, ")
            strSQL.Append("KOK.BOMB_SUU2, ")
            strSQL.Append("KOK.YOBI_FLG2 AS BOMB_RYO2, ")
            strSQL.Append("KOK.BOMB_YOUKI3, ")
            strSQL.Append("KOK.BOMB_SUU3, ")
            strSQL.Append("KOK.YOBI_FLG3 AS BOMB_RYO3, ")
            strSQL.Append("KOK.BOMB_YOUKI4, ")
            strSQL.Append("KOK.BOMB_SUU4, ")
            strSQL.Append("KOK.YOBI_FLG4 AS BOMB_RYO4, ")
            strSQL.Append("KOK.SIYOU3, ")
            strSQL.Append("KOK.SIYOU4, ")
            strSQL.Append("KOK.BOMV_HAISO1, ")
            strSQL.Append("KOK.BOMV_SISIN1, ")
            strSQL.Append("KOK.BOMV_HAISO2, ")
            strSQL.Append("KOK.BOMV_SISIN2, ")
            strSQL.Append("KOK.HAISO_YOTEI, ")
            strSQL.Append("KOK.BOMB_DATE1, ")
            strSQL.Append("KOK.BOMB_SISIN1, ")
            strSQL.Append("KOK.BOMB_DATE2, ")
            strSQL.Append("KOK.BOMB_SISIN2, ")
            strSQL.Append("KOK.KENSIN_DAY1, ")
            strSQL.Append("KOK.KENSINTI1, ")
            strSQL.Append("KOK.KENSIN_DAY2, ")
            strSQL.Append("KOK.KENSINTI2, ")
            strSQL.Append("KOK.SIYOU1, ")
            strSQL.Append("KOK.SIYOU2, ")
            strSQL.Append("KOK.GAS_NAME1, ")
            strSQL.Append("KOK.GAS_NAME2, ")
            strSQL.Append("KOK.GAS_NAME3, ")
            strSQL.Append("KOK.GAS_NAME4, ")
            strSQL.Append("KOK.GAS_NAME5, ")
            strSQL.Append("KOK.GAS_SUU1, ")
            strSQL.Append("KOK.GAS_SUU2, ")
            strSQL.Append("KOK.GAS_SUU3, ")
            strSQL.Append("KOK.GAS_SUU4, ")
            strSQL.Append("KOK.GAS_SUU5, ")
            strSQL.Append("KOK.GAS_SEIF1, ")
            strSQL.Append("KOK.GAS_SEIF2, ")
            strSQL.Append("KOK.GAS_SEIF3, ")
            strSQL.Append("KOK.GAS_SEIF4, ")
            strSQL.Append("KOK.GAS_SEIF5, ")
            strSQL.Append("KOK.GAS_STOP AS GAS_START, ")
            strSQL.Append("KOK.GAS_DELE, ")
            strSQL.Append("KOK.GAS_RESTART, ")
            strSQL.Append("KOK.KANSHI_BIKO, ")            '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL2, ")                '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL2_BIKO, ")           '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL2_UPD_DATE, ")       '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL3, ")                '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL3_BIKO, ")           '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.RENTEL3_UPD_DATE, ")       '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("KOK.TELA || TELB TELAB, ")     '2016/12/12 add H.Mori 2016���P�J�� No5-1
            strSQL.Append("KOK.DAI3RENDORENTEL, ")        '2016/12/12 add H.Mori 2016���P�J�� No5-1
            strSQL.Append("KOK.DAIHYO_NAME, ")            '2016/12/22 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("KOK.HOKBN, ")                  '2016/12/22 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("KOK.YOTOKBN, ")                '2016/12/12 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("KOK.HANBCD, ")                 '2016/12/12 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("KOK.SHUGOU, ")                 '2017/10/16 H.Mori add 2017���P�J�� No4-1
            strSQL.Append("CLI.KANSI_CODE AS KANSCD, ")
            strSQL.Append("CLI.KEN_NAME, ")
            strSQL.Append("JAS.JA_CD, ")
            strSQL.Append("JAS.JA_NAME, ")
            strSQL.Append("JAS.JAS_NAME, ")
            strSQL.Append("PU2.NAME AS UNYO_NAI, ")
            strSQL.Append("'1' AS HATKBN, ")                            '�����敪[1:�d�b]
            strSQL.Append("PU3.NAME AS HATKBN_NAI, ")
            strSQL.Append("'1' AS SDSKBN, ")                            '�o����Џ����敪[1:������] '2008/10/17 T.Watabe add
            strSQL.Append("TO_CHAR(SYSDATE,'YYYYMMDD') AS NCUHATYMD, ") '������ '2008/10/15 T.Watabe add
            strSQL.Append("TO_CHAR(SYSDATE,'HH24MI') AS NCUHATTIME ")   '�������� '2008/10/15 T.Watabe add
            strSQL.Append(",KOK.TUSIN ")                                '�e���R��.�ʐM���[�h 2008/10/24 T.Watabe add
            ' ������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TRIM(TA1.FAXKURAKBN), ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT TRIM(T.FAXKURAKBN) ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.FAXKURAKBN) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     '0' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS FAXKURAKBN ")
            'strSQL.Append(",NVL(TA2.GUIDELINE, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.GUIDELINE ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.GUIDELINE) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     ' ' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS GUIDELINE ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TRIM(TA3.FAXKBN), ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT TRIM(T.FAXKBN) ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.FAXKBN) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND T.CODE = JAS.JA_CD), ")
            'strSQL.Append("     '0' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS FAXKBN ")
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            strSQL.Append(", ")
            strSQL.Append("'" & strPar(0) & "' AS FAXKBN, ")
            strSQL.Append("'" & strPar(1) & "' AS FAXKURAKBN, ")
            strSQL.Append("'" & strPar(2) & "' AS GUIDELINE ")
            strSQL.Append(",'" & strPar(3) & "' AS GUIDELINE2 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",'" & strPar(4) & "' AS GUIDELINE3 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            ' ������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            strSQL.Append(", '" & strKAITU_DAY & "' AS KAITU_DAY ") ' �{���H���� 2013/08/23 T.Ono add �Ď����P2013��1
            strSQL.Append(",NVL(H3.GROUPCD, NVL(H2.GROUPCD, NVL(H1.GROUPCD, ''))) AS HANJICD ") '�̔����Ǝ҃R�[�h2014/12/17 T.Ono add 2014���P�J�� No2
            strSQL.Append(",NVL2(H3.GROUPCD, H3.HANJIGYOSYANM, NVL2(H2.GROUPCD, H2.HANJIGYOSYANM ,NVL2(H1.GROUPCD, H1.HANJIGYOSYANM,''))) AS HANJINM ") '�̔����Ǝ҃R�[�h2014/12/17 T.Ono add 2014���P�J�� No2
            strSQL.Append("FROM SHAMAS KOK, ")
            strSQL.Append("     CLIMAS CLI, ")
            strSQL.Append("     HN2MAS JAS, ")
            'strSQL.Append("     M06_PULLDOWN PU1, ")   ' 2013/06/27 T.ono del �g�p���Ă��Ȃ��悤�Ȃ̂ō폜
            strSQL.Append("     M06_PULLDOWN PU2, ")
            strSQL.Append("     M06_PULLDOWN PU3  ")
            '2014/12/17 T.Ono add 2014���P�J�� No2 START
            strSQL.Append("     ,M09_JAGROUP G1 ")
            strSQL.Append("     ,M10_HANJIGYOSYA H1 ")
            strSQL.Append("     ,M09_JAGROUP G2 ")
            strSQL.Append("     ,M10_HANJIGYOSYA H2 ")
            strSQL.Append("     ,M09_JAGROUP G3 ")
            strSQL.Append("     ,M10_HANJIGYOSYA H3 ")
            '2014/12/17 T.Ono add 2014���P�J�� No2 END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            '2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA1 ") 'FAX�s�v(�ײ���)�t���O�擾
            'strSQL.Append("     ,M05_TANTO TA2 ") 'JA���ӎ����擾
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA3 ") 'FAX�s�v(JA)�t���O�擾
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            strSQL.Append("WHERE KOK.CLI_CD  = :CLI_CD ")
            strSQL.Append("  AND KOK.HAN_CD  = :HAN_CD ")
            strSQL.Append("  AND KOK.USER_CD = :USER_CD ")
            strSQL.Append("  AND KOK.CLI_CD = CLI.CLI_CD(+) ")
            strSQL.Append("  AND KOK.CLI_CD = JAS.CLI_CD(+) ")
            strSQL.Append("  AND KOK.HAN_CD = JAS.HAN_CD(+) ")
            strSQL.Append("  AND '04' = PU2.KBN(+) ")
            strSQL.Append("  AND KOK.USER_FLG = PU2.CD(+) ")
            strSQL.Append("  AND '08' = PU3.KBN(+) ")           '�����敪[1:�d�b]
            strSQL.Append("  AND '1' = PU3.CD(+) ")
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA1.KBN(+) ")
            'strSQL.Append("  AND KOK.CLI_CD = TA1.KURACD(+) ")
            'strSQL.Append("  AND TA1.FAXKURAKBN(+) IS NOT NULL ")
            'strSQL.Append("  AND TA1.CODE(+) = KOK.HAN_CD ")
            'strSQL.Append("  AND '01' = TA1.TANCD(+) ")
            'strSQL.Append("  AND '3' = TA2.KBN(+) ")
            'strSQL.Append("  AND KOK.CLI_CD = TA2.KURACD(+) ")
            'strSQL.Append("  AND TA2.GUIDELINE(+) IS NOT NULL ")
            'strSQL.Append("  AND TA2.CODE(+) = KOK.HAN_CD ")
            'strSQL.Append("  AND '01' = TA2.TANCD(+) ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ''2011.12.01 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA3.KBN(+) ")
            'strSQL.Append("  AND KOK.CLI_CD = TA3.KURACD(+) ")
            'strSQL.Append("  AND TA3.FAXKBN(+) IS NOT NULL ")
            'strSQL.Append("  AND TA3.CODE(+) = KOK.HAN_CD ")
            'strSQL.Append("  AND '01' = TA3.TANCD(+) ")
            ''2011.12.01 ADD H.Uema *------------------------------------------* END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            '�̔����ƎҖ��̎擾�@2014/12/16 T.Ono add 2014���P�J�� No2 START
            'JA�x��
            strSQL.Append("  AND G1.KBN(+) = '001' ")
            strSQL.Append("  AND G1.KURACD(+) = KOK.CLI_CD ")
            strSQL.Append("  AND G1.ACBCD(+) = KOK.HAN_CD ")
            strSQL.Append("  AND G1.USERCD_FROM(+) IS NULL ")
            strSQL.Append("  AND G1.USERCD_TO(+) IS NULL ")
            strSQL.Append("  AND G1.GROUPCD = H1.GROUPCD(+) ")
            '���[�U�[�͈�
            strSQL.Append("  AND G2.KBN(+) = '001' ")
            strSQL.Append("  AND G2.KURACD(+) = KOK.CLI_CD ")
            strSQL.Append("  AND G2.ACBCD(+) = KOK.HAN_CD ")
            strSQL.Append("  AND KOK.USER_CD BETWEEN G2.USERCD_FROM(+) AND G2.USERCD_TO(+) ")
            strSQL.Append("  AND G2.USERCD_TO(+) IS NOT NULL ")
            strSQL.Append("  AND G2.GROUPCD = H2.GROUPCD(+) ")
            '���[�U�[��
            strSQL.Append("  AND G3.KBN(+) = '001' ")
            strSQL.Append("  AND G3.KURACD(+) = KOK.CLI_CD ")
            strSQL.Append("  AND G3.ACBCD(+) = KOK.HAN_CD ")
            strSQL.Append("  AND G3.USERCD_FROM(+) = KOK.USER_CD ")
            strSQL.Append("  AND G3.USERCD_TO(+) IS NULL ")
            strSQL.Append("  AND G3.GROUPCD = H3.GROUPCD(+) ")
            '2014/12/16 T.Ono add 2014���P�J�� No2 END

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLI_CD", True, hdnKEY_CLI_CD.Value)
            SqlParamC.fncSetParam("USER_CD", True, hdnKEY_USER_CD.Value)

            SqlParamC.fncSetParam("HAN_CD", True, hdnKEY_HAN_CD.Value)
            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToInt32(dbData.Tables(0).Rows.Count) = 0 Then
                strMsg.Append("alert('�Ώۃf�[�^�����݂��܂���');")
                strRec = "ERROR"
            Else
                '//�f�[�^���o�͂��܂�
                Call fncDataSet(dbData, "KOKYAK")
                strRec = "OK"
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

            '--- ��2005/04/22 MOD Falcon�� ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ��2005/04/22 MOD Falcon�� ---
        End Try

        '--- ��2005/04/22 DEL Falcon�� ---
        'dbData.Dispose()
        '--- ��2005/04/22 DEL Falcon�� ---
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_KOKYAKU end")

        Return strRec
    End Function

    '******************************************************************************
    ' �Ή����͕ύX�ꗗ����̑J�ڎ��̉�ʏo��
    '******************************************************************************
    Private Function fncSetData_TAIOU() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRec As String
        'Dim strPar(2) As String ' FAXKBN,FAXKURAKBN,GUIDELINE�i�[�p(�����ł�GUIDELIN�̂ݎg�p) 2013/08/07 T.Ono add   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        Dim strPar(4) As String   ' FAXKBN,FAXKURAKBN,GUIDELINE,GUIDELINE2,GUIDELINE3�i�[�p(�����ł�GUIDELIN�̂ݎg�p) 2019/11/01 W.GANEKO 2019�Ď����P No8-12

        Try
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_TAIOU start")
            ' 2013/08/07 T.Ono add FAXKBN,FAXKURAKBN,GUIDELINE�͂Ƃ�������ƈႤ���߁A��Ɏ擾
            strPar = fncGetFAXKBN_GUIDE_TAIOU()

            '//�Ή����͂���̉�ʑJ�ڂ̏ꍇ
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("TAI.KANSCD, ")
            strSQL.Append("TAI.SYONO, ")
            strSQL.Append("TAI.HATYMD AS KMYMD, ")
            strSQL.Append("TAI.HATTIME AS KMTIME, ")
            strSQL.Append("TAI.KENSIN AS KMSIN, ")          '�������������[�^�l����������
            strSQL.Append("TAI.KEIHOSU, ")
            strSQL.Append("TAI.RYURYO, ")
            strSQL.Append("TAI.METASYU AS METASYU_NAI, ")
            strSQL.Append("TAI.UNYO AS UNYOCD, ")
            strSQL.Append("TAI.JUYMD, ")
            strSQL.Append("TAI.JUTIME, ")
            strSQL.Append("TAI.NUM_DIGIT, ")
            strSQL.Append("TAI.KMCD1, ")
            strSQL.Append("TAI.KMNM1, ")
            strSQL.Append("TAI.KMCD2, ")
            strSQL.Append("TAI.KMNM2, ")
            strSQL.Append("TAI.KMCD3, ")
            strSQL.Append("TAI.KMNM3, ")
            strSQL.Append("TAI.KMCD4, ")
            strSQL.Append("TAI.KMNM4, ")
            strSQL.Append("TAI.KMCD5, ")
            strSQL.Append("TAI.KMNM5, ")
            strSQL.Append("TAI.KMCD6, ")
            strSQL.Append("TAI.KMNM6, ")
            strSQL.Append("TAI.ZSISYO, ")
            strSQL.Append("TAI.KURACD AS CLI_CD, ")
            strSQL.Append("TAI.KENNM AS KEN_NAME, ")
            strSQL.Append("TAI.JACD AS JA_CD, ")
            strSQL.Append("TAI.JANM AS JA_NAME, ")
            strSQL.Append("TAI.ACBCD, ")
            strSQL.Append("TAI.ACBNM AS JAS_NAME, ")
            strSQL.Append("TAI.USER_CD AS JUYOKA_CD, ")
            strSQL.Append("TAI.JUSYONM AS JUYONM, ")
            strSQL.Append("TAI.JUSYOKN AS KANA, ")
            strSQL.Append("TAI.JUTEL1, ")
            strSQL.Append("TAI.JUTEL2, ")
            strSQL.Append("TAI.RENTEL, ")
            strSQL.Append("TAI.KTELNO, ")
            strSQL.Append("TAI.ADDR, ")
            strSQL.Append("TAI.USER_KIJI AS USR_MEMO, ")
            strSQL.Append("TAI.NCU_SET AS NCU_CON, ")
            strSQL.Append("TAI.TIZUNO AS MAP_CD, ")
            strSQL.Append("TAI.BOMB_TYPE AS BOMB_TYPE, ")           '���������������敪����������
            strSQL.Append("TAI.HANBAI_KBN, ") '2015/11/25 H.Mori add 2015���P�J�� No1   ���̔��敪��
            strSQL.Append("TAI.KYOKTKBN, ") '2016/12/02 H.Mori add 2016���P�J�� No4-3   �������`�ԋ敪��
            strSQL.Append("TAI.MET_KATA AS SETSUBI, ")
            strSQL.Append("TAI.MET_MAKER AS KYOKYU_MK, ")
            strSQL.Append("TAI.BONB1_KKG AS BOMB_YOUKI1, ")
            strSQL.Append("TAI.BONB1_HON AS BOMB_SUU1, ")
            strSQL.Append("TAI.BONB1_YOBI AS BOMB_RYO1, ")
            strSQL.Append("TAI.BONB2_KKG AS BOMB_YOUKI2, ")
            strSQL.Append("TAI.BONB2_HON AS BOMB_SUU2, ")
            strSQL.Append("TAI.BONB2_YOBI AS BOMB_RYO2, ")
            strSQL.Append("TAI.BONB3_KKG AS BOMB_YOUKI3, ")
            strSQL.Append("TAI.BONB3_HON AS BOMB_SUU3, ")
            strSQL.Append("TAI.BONB3_YOBI AS BOMB_RYO3, ")
            strSQL.Append("TAI.BONB4_KKG AS BOMB_YOUKI4, ")
            strSQL.Append("TAI.BONB4_HON AS BOMB_SUU4, ")
            strSQL.Append("TAI.BONB4_YOBI AS BOMB_RYO4, ")
            strSQL.Append("TAI.ZENKAI_HAISO AS BOMV_HAISO1, ")
            strSQL.Append("TAI.ZENKAI_HAI_S AS BOMV_SISIN1, ")
            strSQL.Append("TAI.KONKAI_HAISO AS BOMV_HAISO2, ")
            strSQL.Append("TAI.KONKAI_HAI_S AS BOMV_SISIN2, ")
            strSQL.Append("TAI.JIKAI_HAISO AS HAISO_YOTEI, ")
            strSQL.Append("TAI.ZENKAI_KENSIN AS KENSIN_DAY1, ")
            strSQL.Append("TAI.ZENKAI_KEN_S AS KENSINTI1, ")
            strSQL.Append("TAI.ZENKAI_KEN_SIYO AS SIYOU1, ")
            strSQL.Append("TAI.KONKAI_KENSIN AS KENSIN_DAY2, ")
            strSQL.Append("TAI.KONKAI_KEN_S AS KENSINTI2, ")
            strSQL.Append("TAI.KONKAI_KEN_SIYO AS SIYOU2, ")
            strSQL.Append("TAI.ZENKAI_HASEI AS BOMB_DATE1, ")
            strSQL.Append("TAI.ZENKAI_HAS_S AS BOMB_SISIN1, ")
            strSQL.Append("TAI.KONKAI_HASEI AS BOMB_DATE2, ")
            strSQL.Append("TAI.KONKAI_HAS_S AS BOMB_SISIN2, ")
            strSQL.Append("TAI.G_ZAIKO, ")
            strSQL.Append("TAI.ICHI_SIYO AS SIYOU3, ")
            strSQL.Append("TAI.YOSOKU_ICHI_SIYO AS SIYOU4, ")
            strSQL.Append("TAI.GAS1_HINMEI AS GAS_NAME1, ")
            strSQL.Append("TAI.GAS1_DAISU AS GAS_SUU1, ")
            strSQL.Append("TAI.GAS1_SEIFL AS GAS_SEIF1, ")
            strSQL.Append("TAI.GAS2_HINMEI AS GAS_NAME2, ")
            strSQL.Append("TAI.GAS2_DAISU AS GAS_SUU2, ")
            strSQL.Append("TAI.GAS2_SEIFL AS GAS_SEIF2, ")
            strSQL.Append("TAI.GAS3_HINMEI AS GAS_NAME3, ")
            strSQL.Append("TAI.GAS3_DAISU AS GAS_SUU3, ")
            strSQL.Append("TAI.GAS3_SEIFL AS GAS_SEIF3, ")
            strSQL.Append("TAI.GAS4_HINMEI AS GAS_NAME4, ")
            strSQL.Append("TAI.GAS4_DAISU AS GAS_SUU4, ")
            strSQL.Append("TAI.GAS4_SEIFL AS GAS_SEIF4, ")
            strSQL.Append("TAI.GAS5_HINMEI AS GAS_NAME5, ")
            strSQL.Append("TAI.GAS5_DAISU AS GAS_SUU5, ")
            strSQL.Append("TAI.GAS5_SEIFL AS GAS_SEIF5, ")
            strSQL.Append("TAI.GAS_STOP AS GAS_START, ")            '�����������K�X�����x�~������������
            strSQL.Append("TAI.GAS_DELE AS GAS_DELE, ")             '�����������K�X�����p�~������������
            strSQL.Append("TAI.GAS_RESTART AS GAS_RESTART, ")       '�����������K�X��������������������
            strSQL.Append("TAI.KANSHI_BIKO, ")                      '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("TAI.RENTEL2, ")                          '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("TAI.RENTEL2_BIKO, ")                     '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("TAI.RENTEL2_UPD_DATE, ")                 '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("TAI.RENTEL3, ")                          '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("TAI.RENTEL3_BIKO, ")                     '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("TAI.RENTEL3_UPD_DATE, ")                 '2016/02/02 w.ganeko 2015���P�J�� ��1-3
            strSQL.Append("TAI.TELAB, ")                            '2016/12/12 add H.Mori 2016���P�J�� No5-1
            strSQL.Append("TAI.DAI3RENDORENTEL, ")                  '2016/12/12 add H.Mori 2016���P�J�� No5-1
            strSQL.Append("TAI.DAIHYO_NAME, ")                      '2016/12/22 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("TAI.HOKBN, ")                            '2016/12/22 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("TAI.YOTOKBN, ")                          '2016/12/12 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("TAI.HANBCD, ")                           '2016/12/12 add H.Mori 2016���P�J�� No4-6
            strSQL.Append("TAI.SHUGOU, ")                 '2017/10/16 H.Mori add 2017���P�J�� No4-1
            strSQL.Append("TAI.HATKBN, ")
            strSQL.Append("TAI.HATKBN_NAI, ")
            strSQL.Append("TAI.TAIOKBN, ")
            strSQL.Append("TAI.TAIOKBN_NAI, ")
            strSQL.Append("TAI.TMSKB, ")
            strSQL.Append("TAI.TMSKB_NAI, ")
            strSQL.Append("TAI.TKTANCD, ")
            strSQL.Append("TAI.TKTANCD_NM, ")
            strSQL.Append("TAI.TAITCD, ")
            strSQL.Append("TAI.TAITNM, ")
            strSQL.Append("TAI.TAIO_ST_DATE, ")
            strSQL.Append("TAI.TAIO_ST_TIME, ")
            strSQL.Append("TAI.SYOYMD, ")
            strSQL.Append("TAI.SYOTIME, ")
            strSQL.Append("TAI.TAIO_SYO_TIME, ")
            strSQL.Append("TAI.FAXKBN, ")
            strSQL.Append("TAI.TELRCD, ")
            strSQL.Append("TAI.TELRNM, ")
            strSQL.Append("TAI.TFKICD, ")
            strSQL.Append("TAI.TFKINM, ")
            strSQL.Append("TAI.FUK_MEMO, ")
            strSQL.Append("TAI.TEL_MEMO1, ")
            strSQL.Append("TAI.TEL_MEMO2, ")
            strSQL.Append("TAI.TEL_MEMO4, ")            '2020/11/01 T.Ono add 2020 �Ď����P
            strSQL.Append("TAI.TEL_MEMO5, ")            '2020/11/01 T.Ono add 2020 �Ď����P
            strSQL.Append("TAI.TEL_MEMO6, ")            '2020/11/01 T.Ono add 2020 �Ď����P
            strSQL.Append("TAI.MITOKBN, ")
            strSQL.Append("TAI.TKIGCD, ")
            strSQL.Append("TAI.TKIGNM, ")
            strSQL.Append("TAI.TSADCD, ")
            strSQL.Append("TAI.TSADNM, ")
            strSQL.Append("TAI.GENIN_KIJI, ")
            strSQL.Append("TAI.SDCD, ")
            strSQL.Append("TAI.SDNM, ")
            strSQL.Append("TAI.SIJIYMD, ")
            strSQL.Append("TAI.SIJITIME, ")
            strSQL.Append("TAI.SIJI_BIKO1, ")
            strSQL.Append("TAI.SIJI_BIKO2, ")
            strSQL.Append("TAI.STD_JASCD, ")
            strSQL.Append("TAI.STD_JANA, ")
            strSQL.Append("TAI.STD_JASNA, ")
            strSQL.Append("TAI.REN_NA, ")
            strSQL.Append("TAI.REN_TEL_1, ")
            strSQL.Append("TAI.REN_TEL_2, ")
            strSQL.Append("TAI.REN_FAX, ")
            strSQL.Append("TAI.REN_BIKO, ")
            strSQL.Append("TAI.REN_1_NA, ")
            strSQL.Append("TAI.REN_1_TEL1, ")
            strSQL.Append("TAI.REN_1_TEL2, ")
            strSQL.Append("TAI.REN_1_FAX, ")
            strSQL.Append("TAI.REN_1_BIKO, ")
            strSQL.Append("TAI.REN_2_NA, ")
            strSQL.Append("TAI.REN_2_TEL1, ")
            strSQL.Append("TAI.REN_2_TEL2, ")
            strSQL.Append("TAI.REN_2_FAX, ")
            strSQL.Append("TAI.REN_2_BIKO, ")
            strSQL.Append("TAI.REN_3_NA, ")
            strSQL.Append("TAI.REN_3_TEL1, ")
            strSQL.Append("TAI.REN_3_TEL2, ")
            strSQL.Append("TAI.REN_3_FAX, ")
            strSQL.Append("TAI.REN_3_BIKO, ")
            strSQL.Append("'4' AS REN_4_NA, ") ' 2008/10/31 TEST ADD
            strSQL.Append("'4' AS REN_4_TEL1, ")
            strSQL.Append("'4' AS REN_4_TEL2, ")
            strSQL.Append("'4' AS REN_4_FAX, ")
            strSQL.Append("'4' AS REN_4_BIKO, ")
            strSQL.Append("TAI.FAX_TITLE, ")
            strSQL.Append("TAI.FAX_REN, ")
            strSQL.Append("TAI.STD_CD, ")
            strSQL.Append("TAI.STD, ")
            strSQL.Append("TAI.STD_KYOTEN_CD, ")
            strSQL.Append("TAI.STD_KYOTEN, ")
            strSQL.Append("TAI.STD_TEL, ")
            strSQL.Append("TAI.TEL_BIKO, ")
            strSQL.Append("TAI.ADD_DATE, ")
            strSQL.Append("TAI.EDT_DATE, ")
            strSQL.Append("TAI.EDT_TIME, ")
            '--- ��2005/09/09 ADD Falcon�� ---
            strSQL.Append("TAI.BIKOU, ")
            strSQL.Append("TAI.FAX_TITLE_CD, ")
            '--- ��2005/09/09 ADD Falcon�� ---
            strSQL.Append("PU2.NAME AS UNYO_NAI, ")
            strSQL.Append("TAI.SDSKBN, ")                   ' 2008/10/17 T.Watabe add
            strSQL.Append("DECODE(TAI.NCUHATYMD,  NULL, TAI.HATYMD,  TAI.NCUHATYMD ) AS NCUHATYMD, ") ' 2008/10/15 T.Watabe add
            strSQL.Append("DECODE(TAI.NCUHATTIME, NULL, TAI.HATTIME, TAI.NCUHATTIME) AS NCUHATTIME ") ' 2008/10/15 T.Watabe add
            '2016/12/22 H.Mori mod 2016���P�J�� No4-1 NCU�ڑ� START
            'strSQL.Append(",KOK.TUSIN ")                                '�e���R��.�ʐM���[�h 2008/10/24 T.Watabe add
            strSQL.Append(",TAI.TUSIN ")
            '2016/12/22 H.Mori mod 2016���P�J�� No4-1 NCU�ڑ� START
            strSQL.Append(",TAI.FAXKURAKBN ") ' 2010/07/12 T.Watabe add
            ' ������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append(",NVL(TA1.GUIDELINE, ")
            'strSQL.Append("    NVL( ")
            'strSQL.Append("      (SELECT T.GUIDELINE ")
            'strSQL.Append("       FROM M05_TANTO T ")
            'strSQL.Append("       WHERE '3' = T.KBN ")
            'strSQL.Append("         AND TAI.KURACD = T.KURACD ")
            'strSQL.Append("         AND TRIM(T.GUIDELINE) IS NOT NULL ")
            'strSQL.Append("         AND '01' = T.TANCD ")
            'strSQL.Append("         AND EXISTS (SELECT 'X' ")
            'strSQL.Append("                     FROM HN2MAS JAS ")
            'strSQL.Append("                     WHERE JAS.CLI_CD = T.KURACD ")
            'strSQL.Append("                       AND JAS.HAN_CD = TAI.ACBCD ")
            'strSQL.Append("                       AND T.CODE = JAS.JA_CD ")
            'strSQL.Append("                     )), ")
            'strSQL.Append("     ' ' ")
            'strSQL.Append("     ) ")
            'strSQL.Append(") AS GUIDELINE ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            strSQL.Append(", ")
            strSQL.Append("'" & strPar(2) & "' AS GUIDELINE ")
            strSQL.Append(",'" & strPar(3) & "' AS GUIDELINE2 ")  '2019/11/01 W.GANEKO 2019�Ď����P�@No8-12
            strSQL.Append(",'" & strPar(4) & "' AS GUIDELINE3 ")  '2019/11/01 W.GANEKO 2019�Ď����P�@No8-12
            ' ������ 2013/08/07 T.Ono mod �ڋq�P�ʓo�^�@�\�ǉ� ������
            strSQL.Append(",TAI.KAITU_DAY ") ' �{���H���� 2013/08/23 T.Ono add �Ď����P2013��1
            strSQL.Append(",TAI.HANJICD AS HANJICD ") '�̔����Ǝ҃R�[�h�@2014/12/16 T.Ono add 2014���P�J�� No2
            strSQL.Append(",TAI.HANJINM AS HANJINM ") '�̔����ƎҖ��@2014/12/16 T.Ono add 2014���P�J�� No2
            strSQL.Append(",TAI.FAXRUISEKIKBN ") ' 2015/11/17 H.Mori add 2015���P�J�� No1
            strSQL.Append(",TAI.FAXSPOTKBN ") ' 2016/12/19 H.Mori add 2016���P�J�� No6-3
            strSQL.Append("FROM ")
            strSQL.Append("    D20_TAIOU TAI, ")
            strSQL.Append("    M06_PULLDOWN PU2 ")
            '2016/12/22 H.Mori del 2016���P�J�� No4-1 START
            'strSQL.Append("    ,SHAMAS KOK ") ' 2008/10/24 T.Watabe add
            '2016/12/22 H.Mori del 2016���P�J�� No4-1 END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("     ,M05_TANTO TA1 ") 'JA���ӎ����擾
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            strSQL.Append("WHERE  ")
            strSQL.Append("      KANSCD      = :KANSCD ")
            strSQL.Append("  AND SYONO       = :SYONO ")
            strSQL.Append("  AND '04'        = PU2.KBN(+) ")
            strSQL.Append("  AND TAI.UNYO    = PU2.CD(+) ")
            '2016/12/22 H.Mori del 2016���P�J�� No4-1 START
            'strSQL.Append("  AND TAI.KURACD  = KOK.CLI_CD(+) ") ' 2008/10/24 T.Watabe add
            'strSQL.Append("  AND TAI.ACBCD   = KOK.HAN_CD(+) ") ' 2008/10/24 T.Watabe add
            'strSQL.Append("  AND TAI.USER_CD = KOK.USER_CD(+) ") ' 2008/10/24 T.Watabe add
            '2016/12/22 H.Mori del 2016���P�J�� No4-1 END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������
            ''2011.11.28 ADD H.Uema *------------------------------------------* START
            'strSQL.Append("  AND '3' = TA1.KBN(+) ")
            'strSQL.Append("  AND TAI.KURACD = TA1.KURACD(+) ")
            'strSQL.Append("  AND TA1.GUIDELINE(+) IS NOT NULL ")
            'strSQL.Append("  AND TA1.CODE(+) = TAI.ACBCD ")
            'strSQL.Append("  AND '01' = TA1.TANCD(+) ")
            ''2011.11.28 ADD H.Uema *------------------------------------------* END
            ' ������ 2013/08/07 T.Ono del �ڋq�P�ʓo�^�@�\�ǉ� ������

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("KANSCD", True, hdnKEY_KANSCD.Value)
            SqlParamC.fncSetParam("SYONO", True, hdnKEY_SYONO.Value)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToInt32(dbData.Tables(0).Rows.Count) = 0 Then
                strMsg.Append("alert('�Ώۃf�[�^�����݂��܂���');")
                strRec = "ERROR"
            Else
                '//�f�[�^���o�͂��܂�
                Call fncDataSet(dbData, "TAIOUK")
                strRec = "OK"
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRec = "ERROR"

            '--- ��2005/04/22 MOD Falcon�� ---
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '--- ��2005/04/22 MOD Falcon�� ---
        End Try

        '--- ��2005/04/22 DEL Falcon�� ---
        'dbData.Dispose()
        '--- ��2005/04/22 DEL Falcon�� ---
        mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncSetData_TAIOU end")

        Return strRec

    End Function

    '******************************************************************************
    ' �擾�f�[�^����ʂɓ]�L
    '******************************************************************************
    Private Sub fncDataSet(ByVal pdbData As DataSet, ByVal strFLG As String)


        Dim decKonkai_Hai_S As Decimal              '//����z�����E�w�j�ꎞ�i�[�p
        Dim decKmsin As Decimal                     '//���[�^�l�ꎞ�i�[�p�i�z��������̐���g�p�ʌv�Z���Ɏg�p�j
        Dim strG_Zaiko As String                    '//�z��������̐���g�p���ꎞ�i�[�p
        Dim strNcuSet As String                     '//�m�b�t�ڑ��ꎞ�i�[�p
        Dim decKeihosu As Decimal                   '//�x�񃁃b�Z�[�W��
        Dim sRyuryo As String '2009/01/05 T.Watabe ���ʋ敪

        Dim DateFncC As New CDateFnc
        Dim TimeFncC As New CTimeFnc
        Dim NaNFncC As New CNaNFnc
        Try
            '//--------------------------------------------------------------------------
            '<TODO>�����������s��
            '
            mlog("[KETAIJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncDataSet start")
            Dim strTemp As String
            Dim intTemp As Integer
            Dim intLoop As Integer

            '�f�[�^���������
            If Convert.ToString(pdbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then

            Else
                '���ɑΉ��ς݂̌x�񂾂�����\�����Ȃ�
                If strFLG = "KEIHOU" Then
                    '�Ώۂ̌x�񂪊��ɑΉ��ς݂������ꍇ�̃`�F�b�N
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("REACTION")) <> "0" Then
                        strMsg.Append("alert('�Ώۂ̌x��͊��ɑΉ��ςׁ̈A�Ή����͍͂s���܂���');")
                        strMsg.Append("fncExit();")
                        Return
                    End If
                End If

                '---------------------
                '�f�[�^�]�L����
                '---------------------
                '������ ' 2008/10/15 T.Watabe add
                txtNCUHATYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCUHATYMD")))
                '������(Hidden�Ɋi�[) ' 2008/10/15 T.Watabe add
                hdnNCUHATYMD.Value = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCUHATYMD")))
                '�������� ' 2008/10/15 T.Watabe add
                txtNCUHATTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCUHATTIME")), 0)

                '��M��
                txtHATYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMYMD")))
                '��M��(Hidden�Ɋi�[)
                hdnHATYMD.Value = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMYMD")))
                '��M����
                txtHATTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMTIME")), 0)

                '���[�^�l/���[�^����
                If strFLG = "KEIHOU" Then
                    '����������
                    If IsNumeric(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT")) = True Then
                        intTemp = Convert.ToInt32(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT"))
                    Else
                        intTemp = 0
                    End If
                    If IsNumeric(pdbData.Tables(0).Rows(0).Item("KMSIN")) = True Then
                        strTemp = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMSIN"))
                    Else
                        strTemp = ""
                    End If
                    If strTemp.Length = 0 Then
                        '���[�^�l���w�肳��Ă��Ȃ�������
                        strTemp = ""
                    Else
                        '���[�^�l���w�肳��Ă����珬���_�ҏW
                        strTemp = strTemp.Substring(0, intTemp) & "." & strTemp.Substring(intTemp)
                    End If
                    If strTemp.Length > 0 Then
                        decKmsin = CDec(strTemp)
                    End If
                    txtKMSIN.Text = strTemp
                    hdnNUM_DIGIT.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT"))
                ElseIf strFLG = "KOKYAK" Then
                    decKmsin = 0
                    txtKMSIN.Text = ""
                    hdnNUM_DIGIT.Value = ""
                Else
                    decKmsin = 0
                    txtKMSIN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMSIN"))
                    hdnNUM_DIGIT.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT"))
                End If
                '�x�񃁃b�Z�[�W��
                If strFLG = "KEIHOU" Then
                    '�x���M�p�l������̑J�ڂ������ꍇ
                    For intLoop = 1 To 6
                        '�x�񃁃b�Z�[�W���Z�o����
                        If Convert.ToString _
                            (pdbData.Tables(0).Rows(0).Item("KMCD" & intLoop)) <> "" Then
                            '�l�������Ă���Όx�񃁃b�Z�[�W���J�E���g
                            decKeihosu = decKeihosu + 1
                        End If
                    Next
                    txtKEIHOSU.Text = Convert.ToString(decKeihosu)
                ElseIf strFLG = "KOKYAK" Then
                    txtKEIHOSU.Text = ""
                Else
                    txtKEIHOSU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KEIHOSU"))
                End If
                '���ʋ敪
                If strFLG = "KOKYAK" Then
                    txtRYURYO.Text = ""
                Else
                    '2005/11/22 NEC UPDATE START
                    '2005/09/22 NEC UPDATE START
                    'txtRYURYO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RYURYO"))
                    'txtRYURYO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RYURYO")).Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("-", "13").Replace(">", "14").Replace("?", "15")
                    'txtRYURYO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RYURYO")).Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("=", "13").Replace(">", "14").Replace("?", "15")
                    '2005/09/22 NEC UPDATE END
                    '2005/11/22 NEC UPDATE END
                    '2009/01/05 T.Watabe edit �u0�`9�v�͂��̂܂܁A�u: ; < = > ?�v�͂��ꂼ��u10 11 12 13 14 15�v�ɒu�������A���̑��́u0�v
                    '2009/02/17 T.Watabe edit �u0�`15�v�͂��̂܂܂Ƃ���B
                    sRyuryo = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RYURYO")).Trim
                    'If sRyuryo = "0" Or sRyuryo = "1" Or sRyuryo = "2" Or sRyuryo = "3" Or sRyuryo = "4" Or _
                    '    sRyuryo = "5" Or sRyuryo = "6" Or sRyuryo = "7" Or sRyuryo = "8" Or sRyuryo = "9" Then
                    If (sRyuryo >= "0" And sRyuryo <= "9") Or (sRyuryo >= "10" And sRyuryo <= "15") Then
                        txtRYURYO.Text = sRyuryo
                    ElseIf sRyuryo = ":" Or sRyuryo = ";" Or sRyuryo = "<" Or sRyuryo = "=" Or sRyuryo = ">" Or sRyuryo = "?" Then
                        txtRYURYO.Text = sRyuryo.Replace(":", "10").Replace(";", "11").Replace("<", "12").Replace("=", "13").Replace(">", "14").Replace("?", "15")
                    Else
                        txtRYURYO.Text = "0" '���̑�
                    End If
                End If
                '���[�^���
                If strFLG = "KOKYAK" Then
                    txtMETASYU.Text = ""
                Else
                    txtMETASYU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("METASYU_NAI"))
                End If
                '���q�l�e�k�f
                txtUSER_FLG.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("UNYO_NAI"))
                '���q�l�e�k�f�R�[�h�iHidden�Ɋi�[�j
                hdnUNYOCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("UNYOCD"))
                '�x�񃁃b�Z�[�W
                If strFLG = "KOKYAK" Then
                    '�x�񃁃b�Z�[�W�P
                    txtKMNM1.Text = ""
                    hdnKMCD1.Value = ""
                    hdnKMNM1.Value = ""
                    '�x�񃁃b�Z�[�W�Q
                    txtKMNM2.Text = ""
                    hdnKMCD2.Value = ""
                    hdnKMNM2.Value = ""
                    '�x�񃁃b�Z�[�W�R
                    txtKMNM3.Text = ""
                    hdnKMCD3.Value = ""
                    hdnKMNM3.Value = ""
                    '�x�񃁃b�Z�[�W�S
                    txtKMNM4.Text = ""
                    hdnKMCD4.Value = ""
                    hdnKMNM4.Value = ""
                    '�x�񃁃b�Z�[�W�T
                    txtKMNM5.Text = ""
                    hdnKMCD5.Value = ""
                    hdnKMNM5.Value = ""
                    '�x�񃁃b�Z�[�W�U
                    txtKMNM6.Text = ""
                    hdnKMCD6.Value = ""
                    hdnKMNM6.Value = ""
                Else
                    '�x�񃁃b�Z�[�W�P
                    txtKMNM1.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD1")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM1")), "�F")
                    hdnKMCD1.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD1"))
                    hdnKMNM1.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM1"))
                    '�x�񃁃b�Z�[�W�Q
                    txtKMNM2.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD2")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM2")), "�F")
                    hdnKMCD2.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD2"))
                    hdnKMNM2.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM2"))
                    '�x�񃁃b�Z�[�W�R
                    txtKMNM3.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD3")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM3")), "�F")
                    hdnKMCD3.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD3"))
                    hdnKMNM3.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM3"))
                    '�x�񃁃b�Z�[�W�S
                    txtKMNM4.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD4")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM4")), "�F")
                    hdnKMCD4.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD4"))
                    hdnKMNM4.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM4"))
                    '�x�񃁃b�Z�[�W�T
                    txtKMNM5.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD5")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM5")), "�F")
                    hdnKMCD5.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD5"))
                    hdnKMNM5.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM5"))
                    '�x�񃁃b�Z�[�W�U
                    txtKMNM6.Text = fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD6")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM6")), "�F")
                    hdnKMCD6.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMCD6"))
                    hdnKMNM6.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMNM6"))
                End If

                '���q�l�R�[�h
                txtJUYOKA.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUYOKA_CD"))
                '���q�l����
                txtJUSYONM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUYONM"))
                '���q�l�J�i
                txtJUSYOKN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KANA"))
                '�d�b�ԍ�
                txtJUTEL1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUTEL1"))
                txtJUTEL2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUTEL2"))
                '2006/06/12 NEC UPDATE START
                'If strFLG = "TAIOUK" Then  '2021/10/01sakaDEL 2021�N�x�Ď����P�F�����d�b�ԍ�14�P�^���ɑΉ����āA�n�C�t���Z�b�g�������폜�i��2006�N��NEC���P���ہX�J�b�g�ƂȂ�j
                'Else
                'If txtJUTEL2.Text.Length > 4 Then
                'txtJUTEL2.Text = txtJUTEL2.Text.Substring(0, txtJUTEL2.Text.Length - 4) & "-" & txtJUTEL2.Text.Substring(txtJUTEL2.Text.Length - 4, 4)
                'End If
                'End If
                '2006/06/12 NEC UPDATE END
                '�A����
                txtRENTEL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL"))
                '�����d�b�ԍ�
                hdnKTELNO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KTELNO"))
                '�Z��
                txtADDR.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ADDR"))
                '�N���C�A���g�R�[�h
                txtClientCD.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("CLI_CD"))
                '�N���C�A���g�R�[�h
                hdnKURACD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("CLI_CD"))
                '�Ď��Z���^�[�R�[�h
                hdnKANSCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KANSCD"))
                '����
                txtKENNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KEN_NAME"))
                '�i�`/�i�`�x����
                '2006/06/06 NEC UPDATE START
                'txtACBNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD")) & " : " & fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(0).Item("JA_NAME")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("JAS_NAME")), "/")
                txtACBNM.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD")) & " : " & Convert.ToString(pdbData.Tables(0).Rows(0).Item("JAS_NAME"))
                '2006/06/06 NEC UPDATE END
                '�i�`�R�[�h(Hidden�Ɋi�[)
                hdnJACD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JA_CD"))
                '�i�`��(Hidden�Ɋi�[)
                hdnJANAME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JA_NAME"))
                '�i�`�x���R�[�h(Hidden�Ɋi�[)
                hdnJASCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ACBCD"))
                '�i�`�x����(Hidden�Ɋi�[)
                hdnJASNAME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JAS_NAME"))

                '�̔����Ǝҁ@2014/12/16 T.Ono add 2014���P�J�� No2 
                txtHANGRP.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANJICD")) & " : " & Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANJINM"))
                hdnHANJICD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANJICD"))
                hdnHANJINM.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANJINM"))

                '2016/02/02 w.ganeko add 2015���P�J�� ��1-3 start
                txtKANSHI_BIKO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KANSHI_BIKO"))
                hdnRENTEL2.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL2"))
                hdnRENTEL2_BIKO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL2_BIKO"))
                hdnRENTEL2_UPD_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL2_UPD_DATE"))
                hdnRENTEL3.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL3"))
                hdnRENTEL3_BIKO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL3_BIKO"))
                hdnRENTEL3_UPD_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("RENTEL3_UPD_DATE"))
                '2016/12/12 H.Mori add 2016���P�J�� No5-1 START
                hdnTELAB.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TELAB"))
                hdnDAI3RENDORENTEL.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("DAI3RENDORENTEL"))
                '2016/12/12 H.Mori add 2016���P�J�� No5-1 END
                hdnTelJVG.Value = "2"
                '2016/02/02 w.ganeko add 2015���P�J�� ��1-3 end
                '2016/12/22 H.Mori add 2016���P�J�� No4-6 START
                hdnDAIHYO_NAME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("DAIHYO_NAME"))
                hdnHOKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HOKBN"))
                hdnYOTOKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("YOTOKBN"))
                hdnHANBCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANBCD"))
                '2016/12/22 H.Mori add 2016���P�J�� No4-6 END
                '2017/10/16 H.Mori add 2017���P�J�� No4-1 START
                hdnSHUGOU.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SHUGOU"))
                '2017/10/16 H.Mori add 2017���P�J�� No4-1 END

                '--- ��2005/09/09 MOD Falcon�� ---
                If strFLG = "KEIHOU" Or strFLG = "TAIOUK" Then
                    '�i�o���l
                    txtUSER_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("BIKOU"))
                End If
                '���q�l�L��
                'txtUSER_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("USR_MEMO"))
                '--- ��2005/09/09 MOD Falcon�� ---

                '------------------------------------------------------------
                '------------------------------------------------------------
                '�m�b�t�ڑ��̒l��ϐ��Ɋi�[
                '2006/06/09 NEC UPDATE START
                'If strFLG = "KEIHOU" Then
                '    '�x���M�p�l������̑J�ڂ������ꍇ
                '    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("UNYOCD")) <> "0" Then
                '        '���q�l�e�k�f��0�ȊO��������
                '        If Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSIN_MODE")) = "T" Then
                '            '���j���[�h��T��������
                '            strNcuSet = "2"
                '        Else
                '            strNcuSet = "1"
                '        End If
                '    Else
                '        strNcuSet = "0"
                '    End If
                'Else
                '    strNcuSet = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCU_CON"))
                'End If
                '�Ή����ʈꗗ��ʂ���J�ڂ����Ƃ�
                If strFLG = "TAIOUK" Then
                    'NCU_CON�́A�Ή�DB�́uNCU�ڑ��v�̍��ڂ���擾���邽�߁A�P�C�Q�C�R�̂����ꂩ
                    strNcuSet = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCU_CON"))
                    '�x���M�p�l���A�ڋq������ʂ���J�ڂ����Ƃ�
                Else
                    'NCU_CON�́A���L�}�X�^�́u���j��ʁv�̍��ڂ���擾���邽�߁AA�AB�AM�AT�At�̂����ꂩ
                    strNcuSet = Convert.ToString(pdbData.Tables(0).Rows(0).Item("NCU_CON"))
                    Dim SQLC As New KETAIJAG00CSQL.CSQL
                    Dim SqlParamC As New CSQLParam
                    Dim SqlParamt As New CSQLParam      'add 2012/03/01 NEC ou
                    Dim strSQL As New StringBuilder("")
                    Dim dbData As DataSet

                    Dim strRec As String

                    '//�Ή����͂���̉�ʑJ�ڂ̏ꍇ
                    strSQL = New StringBuilder("")
                    strSQL.Append("SELECT ")
                    strSQL.Append("COUNT(*) AS CNT ")
                    strSQL.Append("FROM ")
                    strSQL.Append("M06_PULLDOWN ")
                    strSQL.Append("WHERE ")
                    strSQL.Append("KBN=:KBN AND ")
                    strSQL.Append("CD=:CD ")

                    '�p�����[�^�̃Z�b�g(NCU�ڑ��i�o�����j�̌����j
                    SqlParamC.fncSetParam("KBN", True, "60")
                    SqlParamC.fncSetParam("CD", True, strNcuSet)

                    '//SQL�̎��s
                    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                    '���ʂ��P���ł����
                    If Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT")) = "1" Then
                        'NCU�ڑ��i�o�����j
                        strNcuSet = "1"
                    Else
                        'upd 2012/03/01 NEC ou Str
                        '�p�����[�^�̃Z�b�g(NCU�ڑ��i�[�����āj�̌����j
                        SqlParamt.fncSetParam("KBN", True, "61")
                        SqlParamt.fncSetParam("CD", True, strNcuSet)
                        '//SQL�̎��s
                        dbData = SQLC.mGetData(strSQL.ToString, SqlParamt.pParamDataSet, True)
                        'upd 2012/03/01 NEC ou End
                        '���ʂ��P���ł����
                        If Convert.ToString(dbData.Tables(0).Rows(0).Item("CNT")) = "1" Then
                            'NCU�ڑ��i�[������)
                            strNcuSet = "2"
                        ElseIf strNcuSet = "" Then
                            'NCU�ڑ�(���ڑ��j
                            strNcuSet = "3"
                        Else
                            strNcuSet = ""
                        End If
                    End If
                End If
                '2006/06/09 NEC UPDATE END
                '�m�b�t�ڑ��iHidden�Ɋi�[�j
                hdnNCU.Value = strNcuSet
                '�m�b�t�ڑ��i�`�F�b�N�{�b�N�X�ɃZ�b�g�j
                Select Case strNcuSet
                    Case "1"
                        '�P:�ڑ��i�o�j
                        chkNCU_SET1.Checked = True
                        chkNCU_SET2.Checked = False
                        chkNCU_SET0.Checked = False
                    Case "2"
                        '�Q:�ڑ��i�[�j
                        chkNCU_SET1.Checked = False
                        chkNCU_SET2.Checked = True
                        chkNCU_SET0.Checked = False
                    Case "3"
                        '�R:���ڑ�
                        chkNCU_SET1.Checked = False
                        chkNCU_SET2.Checked = False
                        chkNCU_SET0.Checked = True
                    Case Else
                        '���̑�
                        chkNCU_SET1.Checked = False
                        chkNCU_SET2.Checked = False
                        chkNCU_SET0.Checked = False
                End Select
                '�n�}�ԍ�
                txtMAP_CD.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("MAP_CD"))
                '�����敪(�P�F�S�����@�Q�F�������� �R�F�\������ �S�F�\�����݌���)
                hdnBOMB_TYPE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_TYPE"))
                Select Case Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_TYPE"))
                    Case "1"
                        txtBOMB_TYPE.Text = "�S����"
                    Case "2"
                        txtBOMB_TYPE.Text = "��������"
                    Case "3"
                        txtBOMB_TYPE.Text = "�\������"
                    Case "4"
                        txtBOMB_TYPE.Text = "�\�����݌���"
                    Case Else
                        txtBOMB_TYPE.Text = ""
                End Select
                'NCU�ڑ� 2008/10/24 T.Watabe add
                txtTUSIN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TUSIN"))
                '�̔��敪(�P�F���[�^���@�Q�F�{���x�� �R�F���� �S�F���̑�) 2015/11/25 H.Mori add 2015���P�J�� No1�@add  
                hdnHANBAI_KBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANBAI_KBN")).Trim
                Select Case Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANBAI_KBN")).Trim
                    Case "1"
                        txtHANBAI_KBN.Text = "���[�^��"
                    Case "2"
                        txtHANBAI_KBN.Text = "�{���x��"
                    Case "3"
                        txtHANBAI_KBN.Text = "����"
                    Case "4"
                        txtHANBAI_KBN.Text = "���̑�"
                    Case Else
                        txtHANBAI_KBN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HANBAI_KBN")).Trim
                End Select
                '�����`�ԋ敪(�P�F��ʁ@�Q�F�W�� �R�F�ȃK�X) 2016/12/02 H.Mori add 2016���P�J�� No4-3�@add  
                hdnKYOKTKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOKTKBN")).Trim
                Select Case Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOKTKBN")).Trim
                    Case "1"
                        txtKYOKTKBN.Text = "���"
                    Case "2"
                        txtKYOKTKBN.Text = "�W��"
                    Case "3"
                        txtKYOKTKBN.Text = "�ȃK�X"
                    Case Else
                        txtKYOKTKBN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOKTKBN")).Trim
                End Select
                '���[�^�^��
                txtMET_KATA.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SETSUBI"))
                '���[�^���[�J�[
                txtMET_MAKER.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KYOKYU_MK"))
                '�{���x�P�e��j�f
                txtBONB1_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI1")), 0)
                '�{���x�P�ݒu�{��
                txtBONB1_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU1")), 0)
                '�{���x�P�e�ʂj�f
                txtBONB1_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI1")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU1")))
                '�{���x�P�e��\���t���O
                hdnBONB1_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO1")))
                If hdnBONB1_YOBI.Value = "1" Then
                    chkBONB1_YOBI.Checked = True    '�\���e��Ƃ��ă`�F�b�N
                Else
                    chkBONB1_YOBI.Checked = False
                End If
                '�{���x�Q�e��j�f
                txtBONB2_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI2")), 0)
                '�{���x�Q�ݒu�{��
                txtBONB2_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU2")), 0)
                '�{���x�Q�e�ʂj�f
                txtBONB2_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI2")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU2")))
                '�{���x�Q�e��\���t���O
                hdnBONB2_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO2")))
                If hdnBONB2_YOBI.Value = "1" Then
                    chkBONB2_YOBI.Checked = True    '�\���e��Ƃ��ă`�F�b�N
                Else
                    chkBONB2_YOBI.Checked = False
                End If
                '�{���x�R�e��j�f
                txtBONB3_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI3")), 0)
                '�{���x�R�ݒu�{��
                txtBONB3_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU3")), 0)
                '�{���x�R�e�ʂj�f
                txtBONB3_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI3")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU3")))
                '�{���x�R�e��\���t���O
                hdnBONB3_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO3")))
                If hdnBONB3_YOBI.Value = "1" Then
                    chkBONB3_YOBI.Checked = True    '�\���e��Ƃ��ă`�F�b�N
                Else
                    chkBONB3_YOBI.Checked = False
                End If
                '�{���x�S�e��j�f
                txtBONB4_KKG.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI4")), 0)
                '�{���x�S�ݒu�{��
                txtBONB4_HON.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU4")), 0)
                '�{���x�S�e�ʂj�f
                txtBONB4_RKG.Text = fncEditYouryou(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_YOUKI4")), Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SUU4")))
                '�{���x�S�e��\���t���O
                hdnBONB4_YOBI.Value = Convert.ToString(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_RYO4")))
                If hdnBONB4_YOBI.Value = "1" Then
                    chkBONB4_YOBI.Checked = True    '�\���e��Ƃ��ă`�F�b�N
                Else
                    chkBONB4_YOBI.Checked = False
                End If
                '�z��������̐���g�p��(���H
                If strFLG = "TAIOUK" Then
                    strG_Zaiko = Convert.ToString(pdbData.Tables(0).Rows(0).Item("G_ZAIKO"))
                ElseIf strFLG = "KOKYAK" Then
                    strG_Zaiko = ""
                ElseIf (
                        IsNumeric(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1"))) = True And
                        IsNumeric(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KMSIN"))) = True
                       ) And
                       strFLG = "KEIHOU" And
                       Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUYOKA")).Length > 0 Then

                    If IsNumeric(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1"))) = True Then
                        decKonkai_Hai_S = fncEditSisinDec(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1")))
                    End If

                    '�z��������̐���g�p�ʎ擾
                    If decKmsin >= decKonkai_Hai_S Then
                        '���[�^�l������z�����E�w�j�ȏゾ������
                        strG_Zaiko = CStr(Decimal.Truncate((decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)

                    ElseIf decKmsin < decKonkai_Hai_S Then
                        '���[�^�l������z�����E�w�j������������
                        Select Case Convert.ToString(pdbData.Tables(0).Rows(0).Item("NUM_DIGIT"))
                            Case "0"
                                strG_Zaiko = CStr(Decimal.Truncate((1D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "1"
                                strG_Zaiko = CStr(Decimal.Truncate((10D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "2"
                                strG_Zaiko = CStr(Decimal.Truncate((100D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "3"
                                strG_Zaiko = CStr(Decimal.Truncate((1000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "4"
                                strG_Zaiko = CStr(Decimal.Truncate((10000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "5"
                                strG_Zaiko = CStr(Decimal.Truncate((100000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "6"
                                strG_Zaiko = CStr(Decimal.Truncate((1000000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case "7"
                                strG_Zaiko = CStr(Decimal.Truncate((10000000D + decKmsin - decKonkai_Hai_S) / 0.482D * 10D) / 10D)
                            Case Else
                                strG_Zaiko = ""
                        End Select
                    End If
                Else
                    '�����Ƃ��w�肪�Ȃ��ꍇ�͋�ŏo��
                    strG_Zaiko = ""
                End If
                '�z��������̐���g�p��
                txtG_ZAIKO.Text = NaNFncC.mGet(strG_Zaiko, 0)
                '���������g�p��
                '2005/11/22 NEC UPDATE START
                'txtICHI_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU3")))
                txtICHI_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU3")), 3)
                '2005/11/22 NEC UPDATE END
                '�\���P������g�p��
                '2005/11/22 NEC UPDATE START
                'txtYOSOKU_ICHI_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU4")))
                txtYOSOKU_ICHI_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU4")), 3)
                '2005/11/22 NEC UPDATE END
                '�{���x�����O��z����
                txtZENKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_HAISO1")))
                '�{���x�����O��z���w�j
                '2005/11/22 NEC UPDATE START
                'txtZENKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1")))
                txtZENKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN1")), 1)
                '2005/11/22 NEC UPDATE END
                '�{���x��������z����
                txtKONKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_HAISO2")))
                '����z���\���
                txtJIKAI_HAISO.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("HAISO_YOTEI")))
                '�{���x��������z���w�j
                '2005/11/22 NEC UPDATE START
                'txtKONKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN2")))
                txtKONKAI_HAI_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMV_SISIN2")), 1)
                '2005/11/22 NEC UPDATE END
                '�{���x�֑ؑO�񔭐���
                txtZENKAI_HASEI.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_DATE1")))
                '�{���x�֑ؑO�񔭐��w�j
                '2005/11/22 NEC UPDATE START
                'txtZENKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SISIN1")))
                txtZENKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SISIN1")), 1)
                '2005/11/22 NEC UPDATE END
                '�{���x�ؑ֍��񔭐���
                txtKONKAI_HASEI.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_DATE2")))
                '�{���x�ؑ֍��񔭐��w�j
                '2005/11/22 NEC UPDATE START
                'txtKONKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SISIN2")))
                txtKONKAI_HAS_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("BOMB_SISIN2")), 1)
                '2005/11/22 NEC UPDATE END
                '���j���O�񌟐j��
                txtZENKAI_KENSIN.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSIN_DAY1")))
                '���j���O�񌟐j�w�j
                '2005/11/22 NEC UPDATE START
                'txtZENKAI_KEN_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSINTI1")))
                txtZENKAI_KEN_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSINTI1")), 1)
                '2005/11/22 NEC UPDATE END
                '�O��g�p��
                ''''txtZENKAI_KEN_SIYO.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU1")), 0)
                '2005/11/22 NEC UPDATE START
                'txtZENKAI_KEN_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU1")))
                txtZENKAI_KEN_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU1")), 1)
                '2005/11/22 NEC UPDATE END
                '���j��񍡉񌟐j��
                txtKONKAI_KENSIN.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSIN_DAY2")))
                '���j��񍡉񌟐j�w�j
                '2005/11/22 NEC UPDATE START
                'txtKONKAI_KEN_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSINTI2")))
                txtKONKAI_KEN_S.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("KENSINTI2")), 1)
                '2005/11/22 NEC UPDATE END
                '����g�p��
                ''''txtKONKAI_KEN_SIYO.Text = NaNFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU2")), 0)
                '2005/11/22 NEC UPDATE START
                'txtKONKAI_KEN_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU2")))
                txtKONKAI_KEN_SIYO.Text = fncEditSisin(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIYOU2")), 1)
                '2005/11/22 NEC UPDATE END
                '�K�X���P�i��
                txtGAS1_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME1"))
                '�K�X���P�䐔
                txtGAS1_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU1"))
                '�K�X���P�Z�C�t��
                txtGAS1_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF1"))
                '�K�X���Q�i��
                txtGAS2_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME2"))
                '�K�X���Q�䐔
                txtGAS2_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU2"))
                '�K�X���Q�Z�C�t��
                txtGAS2_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF2"))
                '�K�X���R�i��
                txtGAS3_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME3"))
                '�K�X���R�䐔
                txtGAS3_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU3"))
                '�K�X���R�Z�C�t��
                txtGAS3_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF3"))
                '�K�X���S�i��
                txtGAS4_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME4"))
                '�K�X���S�䐔
                txtGAS4_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU4"))
                '�K�X���S�Z�C�t��
                txtGAS4_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF4"))
                '�K�X���T�i��
                txtGAS5_HINMEI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_NAME5"))
                '�K�X���T�䐔
                txtGAS5_DAISU.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SUU5"))
                '�K�X���T�Z�C�t��
                txtGAS5_SEIFL.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_SEIF5"))
                '�K�X�����x�~��
                txtGAS_START.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_START")))
                '�K�X�����p�~��
                txtGAS_DELE.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_DELE")))
                '�K�X����������
                txtGAS_RESTART.Text = fncEditDate(Convert.ToString(pdbData.Tables(0).Rows(0).Item("GAS_RESTART")))
                '�{���H���󋵁@2013/08/23 T.Ono add �Ď����P2013��1
                txtKAITU_DAY.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("KAITU_DAY"))

                '------------------------------------------------------------
                '------------------------------------------------------------
                '�����敪
                '//�����敪(1:�d�b�^2:�ً}�Ή�)
                hdnHATKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATKBN"))
                txtHATKBN.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATKBN_NAI"))
                '�d�b�A�����e�i�����l55:���̑��j 2016/12/20 H.Mori add 2016���P�J�� No4-2
                'strCBO_TELRCD = "55"  '2019/11/01 w.ganeko 2019�Ď����P No 6 del
                '--- ��2005/05/23 ADD Falcon�� ---
                '�ً}�Ή��̏ꍇ�́A
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("HATKBN")) = "2" Then
                    '�d�b�A�����e�i�����l55:���̑��j 2020/03/10 T.Ono add 2019�Ď����P  �x��̎��͏����l�w��
                    strCBO_TELRCD = "55"

                    '���p�ҏ����͕s��
                    Call fncSetState(True)
                End If
                '--- ��2005/05/23 ADD Falcon�� ---

                '[���͍��ڃG���A]�E[�����I��]-------------------------------
                If strFLG = "TAIOUK" Then
                    '//�Ή��敪
                    strCBO_TAIOKBN = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TAIOKBN"))
                    '//�����敪
                    strCBO_TMSKB = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TMSKB"))
                    '//�Ď��Z���^�[�S���҃R�[�h
                    hdnTKTANCD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKTANCD"))
                    '//�Ď��Z���^�[�S���Җ�
                    txtTKTANCD.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKTANCD")) & "�F" & Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKTANCD_NM"))
                    '//�A������
                    strCBO_TAITCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TAITCD"))
                    '//�Ή�������
                    txtSYOYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYOYMD")))
                    '//�Ή���������
                    txtSYOTIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYOTIME")), 1)
                    '//�e�`�w�s�v(JA)�@1:�s�v�@2:�K�v
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXKBN")) = "1" Then
                        chkFAXKBN.Checked = True
                    Else
                        chkFAXKBN.Checked = False
                    End If
                    '//�e�`�w�s�v(�ײ���)�@1:�s�v�@2:�K�v 2010/07/12 T.Watabe add
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXKURAKBN")) = "1" Then
                        chkFAXKURAKBN.Checked = True
                    Else
                        chkFAXKURAKBN.Checked = False
                    End If
                    '//�e�`�w�s�v(�ݐ�)�@1:�s�v�@2:�K�v 2015/11/17 H.Mori add 2015���P�J�� No1 START
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXRUISEKIKBN")) = "1" Then
                        chkFAXRUISEKIKBN.Checked = True
                    Else
                        chkFAXRUISEKIKBN.Checked = False
                    End If
                    '2015/11/17 H.Mori add 2015���P�J�� No1 END
                    '//�d�b�A�����e
                    strCBO_TELRCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TELRCD"))
                    '//���A�Ή���
                    strCBO_TFKICD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TFKICD"))
                    '�d�b�Ή�����
                    ' 2014/02/13 T.Ono mod �Ď����P2013 ���ʂȉ��s������Ȃ��悤�ɏC�� Start
                    '' 2013/10/24 T.Ono �Ď����P2013��1 Start
                    ''//���A���상��
                    ''txtFUK_MEMO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                    ' ''//�d�b�Ή������P
                    ''txtTEL_MEMO1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1"))
                    ' ''//�d�b�Ή������Q
                    ''txtTEL_MEMO2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2"))
                    'txtTEL_MEMO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) & vbCrLf _
                    '                    & Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) & vbCrLf _
                    '                    & Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                    '' 2013/10/24 T.Ono �Ď����P2013��1 End
                    Dim strMemo As String = ""
                    Dim row As String = "0"

                    '2020/11/01 T.Ono mod 2020�ĉ��P Start
                    'If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO")) <> "" Then
                    '    strMemo = vbCrLf & Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO"))
                    '    row = "3"
                    'End If
                    'If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) <> "" Then
                    '    strMemo = vbCrLf & Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) & strMemo
                    '    row = "2"
                    'ElseIf row = "3" Then
                    '    '2�s�ڂ̓f�[�^�Ȃ������A3�s�ڂ̓f�[�^����
                    '    strMemo = vbCrLf & strMemo
                    'End If
                    'If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) <> "" Then
                    '    strMemo = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) & strMemo
                    'ElseIf (row = "2" OrElse row = "3") Then
                    '    '1�s�ڂ̓f�[�^�Ȃ������A2,3�s�ڂ̓f�[�^����
                    '    '�i���l�F�擪�̉��s�͖��������A2�������1�ڂ͖�������2�ڂ͗L���ƂȂ�j
                    '    strMemo = vbCrLf & strMemo
                    'End If

                    '6�s��
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO6")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO6"))
                    End If

                    '5�s��
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO5")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO5")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If

                    '4�s��
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO4")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO4")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If

                    '3�s��
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("FUK_MEMO")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If

                    '2�s��
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) <> "" Then
                        strMemo = vbCrLf + Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO2")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If

                    '1�s��
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) <> "" Then
                        strMemo = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_MEMO1")) + strMemo
                    Else
                        If strMemo <> "" Then
                            strMemo = vbCrLf + strMemo
                        End If
                    End If
                    '2020/11/01 T.Ono mod 2020�ĉ��P End

                    txtTEL_MEMO.Value = strMemo.ToString
                    'txtTEL_MEMO.Text = strMemo.ToString '������
                    ' 2014/02/13 T.Ono mod �Ď����P2013 End
                    '//�K�X���
                    strCBO_TKIGCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TKIGCD"))
                    '//�쓮����
                    strCBO_TSADCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TSADCD"))
                    '//���q�l�L��
                    'txtGENIN_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))   '2021/01/05 T.Ono mod 2020�Ď����P
                    txtGENIN_KIJI.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))
                    '//�o���w�����e
                    strCBO_SDCD = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDCD"))
                    '//�o���w����
                    txtSIJIYMD.Text = DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJIYMD")))
                    '//�o���w������
                    txtSIJITIME.Text = TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJITIME")), 1)
                    '//�o���w�����l1
                    txtSIJI_BIKO1.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJI_BIKO1"))
                    '//�o���w�����l2
                    txtSIJI_BIKO2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SIJI_BIKO2"))
                    '//�����ԍ�
                    txtSYONO.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYONO"))
                    '//�����ԍ�
                    hdnSYONO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SYONO"))
                    '//�쐬��
                    hdnADD_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("ADD_DATE"))
                    '//�X�V��
                    hdnEDT_DATE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("EDT_DATE"))
                    '//�X�V����
                    hdnTIME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("EDT_TIME"))
                    '�A����I����ʁF�d�b�A�����l
                    hdnREN_DENWABIKO.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("TEL_BIKO"))
                    '--- ��2005/09/09 ADD Falcon�� ---
                    '�A����I����ʁF�e�`�w�^�C�g���R�[�h
                    hdnFAX_TITLE_CD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAX_TITLE_CD"))
                    '--- ��2005/09/09 ADD Falcon�� ---
                    '�A����I����ʁF�e�`�w�^�C�g��
                    hdnREN_FAXTITLE.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAX_TITLE"))
                    '�A����I����ʁF������
                    hdnREN_FAXREN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAX_REN"))
                    '2016/12/14 H.Mori add 2016���P�J�� No6-3 START
                    '�A����I����ʁF�X�|�b�gFAX���M�敪
                    hdnFAXSPOTKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXSPOTKBN"))
                    '2016/12/14 H.Mori add 2016���P�J�� No6-3 END

                Else
                    '=============================================================================================
                    '2011.11.07 ADD h.uema
                    'Else�ǉ�(�J�ڌ����Ή����ʈꗗ��ʈȊO�̏ꍇ, FAX�s�v(�N���C�A���g)��ݒ肷��悤�ɉ��C
                    '=============================================================================================
                    '//�e�`�w�s�v(�ײ���)�@1:�s�v�@0:�K�v ���S���҃}�X�^���擾
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXKURAKBN")) = "1" Then
                        chkFAXKURAKBN.Checked = True
                    Else
                        chkFAXKURAKBN.Checked = False
                    End If
                    '2011.12.01 ADD H.Uema FAX�s�v(JA)�ǉ�
                    If Convert.ToString(pdbData.Tables(0).Rows(0).Item("FAXKBN")) = "1" Then
                        chkFAXKBN.Checked = True
                    Else
                        chkFAXKBN.Checked = False
                    End If
                End If
                '//���q�l�L��
                'txtGENIN_KIJI.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))    '2021/01/05 T.Ono mod 2020�Ď����P
                txtGENIN_KIJI.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI"))
                '2016/11/17 H.Mori add 2016���P�J�� No4-4
                If Convert.ToString(pdbData.Tables(0).Rows(0).Item("GENIN_KIJI")) <> "" Then
                    txtRENTEL.BackColor = Color.GreenYellow
                End If

                Dim strSYSDATE As String = Now.ToString("yyyyMMdd")
                Dim strSYSTIME As String = Now.ToString("HHmmss")

                '���łɂc�a�ɊJ�n�����Z�b�g����āA���������Z�b�g����Ă���ꍇ�͖�������
                '�܂��A���łɂc�a�ɂ�����t���ύX����Ă���ꍇ�͂��̒l���g�p���A�ēx���v���Ԃ��v�Z����
                hdnTAIO_ST_DATE.Value = strSYSDATE
                hdnTAIO_ST_TIME.Value = strSYSTIME

                '�Ή���M���E�Ή�����
                If strFLG = "TAIOUK" Or strFLG = "KEIHOU" Then
                    hdnJUYMD.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUYMD"))
                    hdnJUTIME.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("JUTIME"))
                Else
                    '�d�b�Ή��̏ꍇ�͉�ʂ��J��������
                    hdnJUYMD.Value = strSYSDATE
                    hdnJUTIME.Value = strSYSTIME
                End If
                hdnSDSKBN.Value = Convert.ToString(pdbData.Tables(0).Rows(0).Item("SDSKBN")) ' 2008/10/17 T.Watabe add

                '������ 2011.11.09 ADD H.Uema JA���ӎ����̒ǉ� ������
                lblGuideline.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GUIDELINE"))
                lblGuideline2.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GUIDELINE2"))  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                lblGuideline3.Text = Convert.ToString(pdbData.Tables(0).Rows(0).Item("GUIDELINE3"))  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                '������ 2011.11.09 ADD H.Uema JA���ӎ����̒ǉ� ������


                '2014/02/10 T.Ono add �Ď����P2013�@�d���\���@�\�ǉ�
                '�d���\���Ώۂ̂��̂́A�Ή��敪�ƕ񍐕s�v���Z�b�g
                If strFLG = "KEIHOU" Then
                    Dim taiounaiyou As New KETAIJAG00DTO.AutoTaiouDto
                    '�d���\���̑Ώۂ��`�F�b�N
                    taiounaiyou = fncChoufukuHyouji()
                    If Not IsNothing(taiounaiyou.groupcd) Then
                        strCBO_TAIOKBN = "3"                '�Ή��敪��3�ɃZ�b�g�ifncComboSet�ŃZ�b�g�j
                        hdnchoufukuhyouji.Value = "1"       '�񍐕s�v�Ƀ`�F�b�N�iKETAIJKG00.aspx.vb��fncGetData_REN�ŃZ�b�g�j

                        '���̑��@�}�X�^�̓o�^���e����ʂ֔��f
                        '�����敪
                        If Convert.ToString(taiounaiyou.tmskb) <> "" Then
                            strCBO_TMSKB = Convert.ToString(taiounaiyou.tmskb)
                        End If
                        '�Ď��Z���^�[�S���҃R�[�h
                        If Convert.ToString(taiounaiyou.tktancd) <> "" Then
                            hdnTKTANCD.Value = Convert.ToString(taiounaiyou.tktancd)
                            '�Ď��Z���^�[�S���Җ�
                            txtTKTANCD.Text = Convert.ToString(taiounaiyou.tktancd) & "�F" & Convert.ToString(taiounaiyou.tktannm)
                        End If
                        '�A������
                        If Convert.ToString(taiounaiyou.taitcd) <> "" Then
                            strCBO_TAITCD = Convert.ToString(taiounaiyou.taitcd)
                        End If
                        '���A�Ή���
                        If Convert.ToString(taiounaiyou.tfkicd) <> "" Then
                            strCBO_TFKICD = Convert.ToString(taiounaiyou.tfkicd)
                        End If
                        '�K�X���
                        If Convert.ToString(taiounaiyou.tkigcd) <> "" Then
                            strCBO_TKIGCD = Convert.ToString(taiounaiyou.tkigcd)
                        End If
                        '�쓮����
                        If Convert.ToString(taiounaiyou.tsadcd) <> "" Then
                            strCBO_TSADCD = Convert.ToString(taiounaiyou.tsadcd)
                        End If
                        '�d�b�A�����e
                        If Convert.ToString(taiounaiyou.telrcd) <> "" Then
                            strCBO_TELRCD = Convert.ToString(taiounaiyou.telrcd)
                        End If
                        '�d�b�Ή������i1�s���j
                        If Convert.ToString(taiounaiyou.tel_memo1) <> "" Then
                            txtTEL_MEMO.Value = Convert.ToString(taiounaiyou.tel_memo1)
                            'txtTEL_MEMO.Text = Convert.ToString(taiounaiyou.tel_memo1) '������
                        End If

                    Else
                        '2020/11/01 T.Ono add 2020�Ď����P
                        '�����Ή�����Ȃ��ꍇ
                        Dim strTANInfo() As String
                        strTANInfo = fncGetTANInfo()

                        '�Ď��Z���^�[�S���҃R�[�h
                        If Convert.ToString(strTANInfo(0)) <> "" Then
                            hdnTKTANCD.Value = Convert.ToString(strTANInfo(0))
                            '�Ď��Z���^�[�S���Җ�
                            txtTKTANCD.Text = Convert.ToString(strTANInfo(0)) & "�F" & Convert.ToString(strTANInfo(1))
                        End If
                    End If
                End If

                '2020/11/01 T.Ono add 2020�Ď����P
                '�ڋq�����̏ꍇ
                If strFLG = "KOKYAK" Then
                    Dim strTANInfo() As String
                    strTANInfo = fncGetTANInfo()

                    '�Ď��Z���^�[�S���҃R�[�h
                    If Convert.ToString(strTANInfo(0)) <> "" Then
                        hdnTKTANCD.Value = Convert.ToString(strTANInfo(0))
                        '�Ď��Z���^�[�S���Җ�
                        txtTKTANCD.Text = Convert.ToString(strTANInfo(0)) & "�F" & Convert.ToString(strTANInfo(1))
                    End If
                End If

                '2014/12/16 T.Ono add 2014���P�J�� No2
                If hdnJACD.Value = "" OrElse hdnJANAME.Value = "" OrElse hdnJASCD.Value = "" OrElse hdnJASNAME.Value = "" Then
                    strMsg.Append("alert('JA/JA�x�����������Ȃ��\��������܂��B\n��U�I�����A�x���Q�o�^���m�F���Ă��������B');")
                End If

            End If
        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        End Try

    End Sub

    Private Sub fncCombo_Create_Taiou()
        cboTAIOKBN.pComboTitle = True
        cboTAIOKBN.pNoData = False
        cboTAIOKBN.pType = "TAIOUKBN"               '//�Ή��敪
        cboTAIOKBN.mMakeCombo()
    End Sub
    Private Sub fncCombo_Create_Syori()
        cboTMSKB.pComboTitle = True
        cboTMSKB.pNoData = False
        cboTMSKB.pType = "SYORIKBN"                 '//�����敪
        cboTMSKB.mMakeCombo()
    End Sub
    Private Sub fncCombo_Create_Rebrakua()
        cboTAITCD.pComboTitle = True
        cboTAITCD.pNoData = False
        cboTAITCD.pType = "RENRAKUA"                '//�A������
        cboTAITCD.mMakeCombo()
    End Sub
    Private Sub fncCombo_Create_Denwaren()
        cboTELRCD.pComboTitle = True
        cboTELRCD.pNoData = False
        cboTELRCD.pType = "DENWAREN"                '//�d�b�A�����e
        cboTELRCD.mMakeCombo()
    End Sub
    Private Sub fncCombo_Create_Hukkitai()
        cboTFKICD.pComboTitle = True
        cboTFKICD.pNoData = False
        cboTFKICD.pType = "HUKKITAI"                '//���A�󋵑Ή�
        '2019/11/01 w.ganeko mod 2019�Ď����P No9-12 start
        'cboTFKICD.mMakeCombo()
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        ' 2023/01/11 ADD START Y.ARAKAKI 2022�X��No8 _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�
        Dim strSQL2 As New StringBuilder("") '2022/07/29  �Ή��敪�ƌx�񃁃b�Z�[�W�̑g�����Łu���A�Ή��󋵁v�u�������v�u���쌴���v���X�g���e��ҏW����B
        Dim dbData2 As DataSet               '2022/07/29  �Ή��敪�ƌx�񃁃b�Z�[�W�̑g�����Łu���A�Ή��󋵁v�u�������v�u���쌴���v���X�g���e��ҏW����B
        ' 2023/01/11 ADD END   Y.ARAKAKI 2022�X��No8 _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�
        Dim wkKeihoTaiouCds As String
        wkKeihoTaiouCds = "" '������

        Dim cdb As New CDB
        Dim i As Integer

        cdb.mOpen()

        strSQL.Append("SELECT ")
        strSQL.Append("CD, ")
        strSQL.Append("CD || '�F' || NAME AS NAME, ")
        strSQL.Append("NAIYO1 ")
        strSQL.Append("FROM M06_PULLDOWN ")
        strSQL.Append("WHERE KBN=:KBN ")
        strSQL.Append("ORDER BY TO_NUMBER(DISP_NO),CD ")
        cdb.pSQL = strSQL.ToString
        cdb.pSQLParamStr("KBN") = "14"
        cdb.mExecQuery()
        dbData = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        cdb.mClose()
        cdb = Nothing
        cboTFKICD.Items.Add(New ListItem("", ""))
        If dbData.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData.Tables(0).Rows.Count - 1
                strMsg.Append("var item = {val:'" + Convert.ToString(dbData.Tables(0).Rows(i).Item(0)) + "',txt:'" + Convert.ToString(dbData.Tables(0).Rows(i).Item(1)) + "',flg:'" + Convert.ToString(dbData.Tables(0).Rows(i).Item(2)) + "'};")
                strMsg.Append("listcboTFKICD.push(item);")
                '�R���{�ɒǉ�
                cboTFKICD.Items.Add(New ListItem(Convert.ToString(dbData.Tables(0).Rows(i).Item(1)),
                  Convert.ToString(dbData.Tables(0).Rows(i).Item(0))))
            Next
        End If
        '2019/11/01 w.ganeko mod 2019�Ď����P No9-12 end

        '2022/07/29 ADD START Y.ARAKAKI 2022�X��No8 _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�
        '���O�Ώۍ��ڂ�����
        Dim cdb2 As New CDB
        cdb2.mOpen()

        strSQL2.Append("SELECT ")
        strSQL2.Append("CD, ")
        strSQL2.Append("NAIYO1 ")
        strSQL2.Append("FROM M06_PULLDOWN ")
        strSQL2.Append("WHERE KBN=:KBN ")
        strSQL2.Append("ORDER BY TO_NUMBER(DISP_NO),CD ")
        cdb2.pSQL = strSQL2.ToString
        cdb2.pSQLParamStr("KBN") = "82" '82�F���A�Ή��󋵁i�\�����O�Ώہj
        cdb2.mExecQuery()
        dbData2 = cdb2.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        cdb2.mClose()
        cdb2 = Nothing
        If dbData2.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData2.Tables(0).Rows.Count - 1
                wkKeihoTaiouCds = Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) '�����O�ɋ��ʒl���擾(20220729���_�ŁA3���z��)
                strMsg.Append(
                      "var item = {keihoMsgNo:'" + Strings.Left(wkKeihoTaiouCds, 2) _
                    + "',taioKbnNo:'" + Strings.Mid(wkKeihoTaiouCds, 3) _
                    + "',removeNo:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listRemoveCheckTFKICD.push(item);")
            Next
        End If
        '2022/07/29 ADD END Y.ARAKAKI 2022�X��No8 _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�

    End Sub
    Private Sub fncCombo_Create_Gakukigu() '�������X�g�̎擾�͂����B�i�v���_�E���}�X�^�敪��'16'�j
        '2021/10/01DELsaka2021�N�x�Ď����P START �V���v���Ƀv���_�E���}�X�^���獀�ڂ��������鏈�����폜�A�������߂�(20211105)
        cboTKIGCD.pComboTitle = True
        cboTKIGCD.pNoData = False
        cboTKIGCD.pType = "GAKUKIGU"                '//�K�X��� 2021/10/01�Ȃ��GAKUKIGU(GASUKIGU����Ȃ��́H)�Ȃ̂��s�������ς���̂͂�߂Ă���

        '2022/07/29 MOD START Y.Arakaki 2022�X��No8 _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�
        '�����̃��X�g�{�b�N�X�擾�i���ʏ����j�ł͂Ȃ��A�����Ō������̑S���ڃ��X�g�Ə��O���X�g���������A��ʂ�js�錾�ŕێ�������B
        '���X�g���e�̐ؑւ́A��ʏ�iJS�����j�݂̂ōs���A����VB�����ɂ͖߂��Ă��Ȃ��B
        'cboTKIGCD.mMakeCombo()

        '�S���ڌ����p
        Dim strSQL1 As New StringBuilder("")
        Dim dbData1 As DataSet
        Dim cdb As New CDB

        '���O���ڌ����p
        Dim strSQL2 As New StringBuilder("")
        Dim dbData2 As DataSet
        Dim cdb2 As New CDB

        'DB��������
        Dim i As Integer

        '�������(�S����)����SQL �����ʏ���CTLCombo.vb��SQL���\�b�h��private�ݒ�ŌĂяo���Ȃ��ׁA�Ǝ������B
        '�t���O�Ǘ����͂��ĂȂ��ׁA�R�[�h�Ɩ��O�̂ݎ擾�B(����Ă邱�Ƃ͋��ʏ����Ɠ���)
        cdb.mOpen()
        strSQL1.Append("SELECT ")
        strSQL1.Append("MS.CD AS CD,")
        strSQL1.Append("MS.CD || '�F' || MS.NAME AS NAME ")
        strSQL1.Append("FROM ")
        strSQL1.Append("M06_PULLDOWN MS ")
        strSQL1.Append("WHERE MS.KBN=:KBN ")
        strSQL1.Append("ORDER BY TO_NUMBER(MS.DISP_NO), MS.CD")
        cdb.pSQL = strSQL1.ToString
        cdb.pSQLParamStr("KBN") = "16"  '16:�K�X���i��ʏ�ł͌������Ƃ��ă��X�g�\���B�j
        cdb.mExecQuery()
        dbData1 = cdb.pResult     '���ʂ��f�[�^�Z�b�g�i�[
        cdb.mClose()
        cdb = Nothing

        '���������ʏ����ƈႤ��肽�����ƁB�F���X�g���e��ݒ肵�A�S����(�ҏW�p�o�b�N�A�b�v)�����js���X�g�ɐݒ�B
        cboTKIGCD.Items.Add(New ListItem("", "")) '���X�g�ҏW1�s�ڂ͋�s��ݒ�B
        If dbData1.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData1.Tables(0).Rows.Count - 1

                strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listcboTKIGCD.push(item);")
                '�R���{�ɒǉ�
                cboTKIGCD.Items.Add(New ListItem(Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)),
                  Convert.ToString(dbData1.Tables(0).Rows(i).Item(0))))
            Next
        End If


        '�������(���O�Ώۍ���)����SQL 
        cdb2.mOpen()
        strSQL2.Append("SELECT ")
        strSQL2.Append("CD, ")
        strSQL2.Append("NAIYO1 ")
        strSQL2.Append("FROM M06_PULLDOWN ")
        strSQL2.Append("WHERE KBN=:KBN ")
        strSQL2.Append("ORDER BY TO_NUMBER(DISP_NO),CD ")
        cdb2.pSQL = strSQL2.ToString
        cdb2.pSQLParamStr("KBN") = "83" '83�F�������i�\�����O�Ώہj
        cdb2.mExecQuery()
        dbData2 = cdb2.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        cdb2.mClose()
        cdb2 = Nothing
        Dim wkKeihoTaiouCds As String
        wkKeihoTaiouCds = "" '������
        If dbData2.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbData2.Tables(0).Rows.Count - 1
                wkKeihoTaiouCds = Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) '�����O�ɋ��ʒl���擾(20220729���_�ŁA3���z��)
                strMsg.Append(
                      "var item = {keihoMsgNo:'" + Strings.Left(wkKeihoTaiouCds, 2) _
                    + "',taioKbnNo:'" + Strings.Mid(wkKeihoTaiouCds, 3) _
                    + "',removeNo:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listRemoveCheckTKIGCD.push(item);")
            Next
        End If
        '2022/07/29 MOD END Y.Arakaki 2022�X��No8 _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�

    End Sub
    Private Sub fncCombo_Create_Sadougen()
        '2020/11/01 T.Ono �Ď����P2020 Start
        'cboTSADCD.pComboTitle = True
        'cboTSADCD.pNoData = False
        'If hdnKMCD1.Value.Length = 0 Then
        '    cboTSADCD.pType = "SADOUGEN"                '//�쓮����
        'Else
        '    cboTSADCD.pKeihocd = hdnKMCD1.Value         '//���x��R�[�h���Z�b�g
        '    cboTSADCD.pType = "KEIHOUSADOU"             '//�쓮����(�x�񃁃b�Z�[�W����L��)
        'End If

        'cboTSADCD.mMakeCombo()

        Dim strSQL1 As New StringBuilder("")
        'Dim strSQL2 As New StringBuilder("")      '2023/09/15 DEL Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        Dim dbData1 As DataSet
        'Dim dbData2 As DataSet                    '2023/09/15 DEL Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        Dim cdb As New CDB
        Dim i As Integer

        cboTSADCD.Items.Add(New ListItem("", ""))

        cdb.mOpen()

        '2022/08/10 ADD START Y.Arakaki 2022�X��No8 _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�
        '2023/01/18 DEL START Y.ARAKAKI No8�ǉ��C�� �v���_�E���敪59�ɂ�鐧���\���ݒ��s�g�p�Ƃ��A����敪84�̏��O���ڂ݂̂Ő��䂷��悤�C���B
        'Dim strSQLViewList As New StringBuilder("")
        'Dim dbDataViewList As DataSet
        'strSQLViewList.Append("SELECT ")
        'strSQLViewList.Append(" SUBSTR(M06A.CD,1,2) AS KEIKOKU_NO ")  '�x�����b�Z�[�WNo
        'strSQLViewList.Append(" ,LISTAGG(SUBSTR(M06A.CD,3,2), ',') WITHIN GROUP (ORDER BY SUBSTR(M06A.CD,1,2)) AS SADOUGENIN_NO_LIST ") '�쓮�����J���}��؂�i�x��No���Ɓj
        'strSQLViewList.Append("FROM ")
        'strSQLViewList.Append("  M06_PULLDOWN M06A ")
        'strSQLViewList.Append("WHERE ")
        'strSQLViewList.Append("  M06A.KBN='59' ") '�敪�F�i�荞�ݕ\��
        'strSQLViewList.Append("  AND EXISTS(")
        'strSQLViewList.Append("    SELECT 1 FROM M06_PULLDOWN M06B_SADOU ")
        'strSQLViewList.Append("    WHERE ")
        'strSQLViewList.Append("      M06B_SADOU.KBN='17' ") '�敪17�i�쓮�����j
        'strSQLViewList.Append("      AND M06B_SADOU.CD=SUBSTR(M06A.CD,3,2)")
        'strSQLViewList.Append("    ) ")
        'strSQLViewList.Append("GROUP BY ")
        'strSQLViewList.Append("  SUBSTR(M06A.CD,1,2) ") '�x��No�ŃO���[�v��
        'cdb.pSQL = strSQLViewList.ToString
        'cdb.mExecQuery()
        'dbDataViewList = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        'If dbDataViewList.Tables(0).Rows.Count > 0 Then
        '    For i = 0 To dbDataViewList.Tables(0).Rows.Count - 1
        '        strMsg.Append(
        '              "var item = {keihoMsgNo:'" + Convert.ToString(dbDataViewList.Tables(0).Rows(i).Item(0)) _
        '            + "',viewNo:'" + Convert.ToString(dbDataViewList.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listViewCheckTSADCD.push(item);")
        '    Next
        'End If
        '2023/01/18 DEL END   Y.ARAKAKI No8�ǉ��C�� �v���_�E���敪59�ɂ�鐧���\���ݒ��s�g�p�Ƃ��A����敪84�̏��O���ڂ݂̂Ő��䂷��悤�C���B

        '�쓮����(���O�Ώۍ���)����SQL 
        Dim strSQLRemoveList As New StringBuilder("")
        Dim dbDataRemoveList As DataSet
        strSQLRemoveList.Append("SELECT ")
        strSQLRemoveList.Append("CD, ")
        strSQLRemoveList.Append("NAIYO1 ")
        strSQLRemoveList.Append("FROM M06_PULLDOWN ")
        strSQLRemoveList.Append("WHERE KBN=:KBN ")
        strSQLRemoveList.Append("ORDER BY TO_NUMBER(DISP_NO),CD ")
        cdb.pSQL = strSQLRemoveList.ToString
        cdb.pSQLParamStr("KBN") = "84" '84�F�쓮�����i�\�����O�Ώہj
        cdb.mExecQuery()
        dbDataRemoveList = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        Dim wkSadouGenninCds As String
        wkSadouGenninCds = "" '������
        If dbDataRemoveList.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbDataRemoveList.Tables(0).Rows.Count - 1
                wkSadouGenninCds = Convert.ToString(dbDataRemoveList.Tables(0).Rows(i).Item(0)) '�����O�ɋ��ʒl���擾(20220729���_�ŁA3���z��)
                strMsg.Append(
                      "var item = {keihoMsgNo:'" + Strings.Left(wkSadouGenninCds, 2) _
                    + "',taioKbnNo:'" + Strings.Mid(wkSadouGenninCds, 3) _
                    + "',removeNo:'" + Convert.ToString(dbDataRemoveList.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listRemoveCheckTSADCD.push(item);")
            Next
        End If
        '2022/08/10 ADD END Y.Arakaki 2022�X��No8 _�Ή����͉�ʂ̑Ή��敪�{�x�񃁃b�Z�[�W�g�����̃��X�g�i���Ή�


        '�S�쓮����
        strSQL1.Append("SELECT ")
        strSQL1.Append("MS.CD AS CD,")
        strSQL1.Append("MS.CD || '�F' || MS.NAME AS NAME ")
        strSQL1.Append("FROM ")
        strSQL1.Append("M06_PULLDOWN MS ")
        strSQL1.Append("WHERE MS.KBN='17'")
        strSQL1.Append("ORDER BY TO_NUMBER(MS.DISP_NO), MS.CD")

        '�S�쓮�����擾
        cdb.pSQL = strSQL1.ToString
        cdb.mExecQuery()
        dbData1 = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        ''�쓮����(���b�Z�[�W����L��)
        'strSQL2.Append("SELECT ")
        'strSQL2.Append("MS.CD AS CD,")
        'strSQL2.Append("MS.CD || '�F' || MS.NAME AS NAME ")
        'strSQL2.Append("FROM ")
        'strSQL2.Append("M06_PULLDOWN KH,")
        'strSQL2.Append("M06_PULLDOWN MS ")
        'strSQL2.Append("WHERE KH.KBN='59'")
        'strSQL2.Append("  AND SUBSTR(KH.CD,1,2) = :KEIHOCD")
        'strSQL2.Append("  AND MS.KBN='17'")
        'strSQL2.Append("  AND MS.CD = SUBSTR(KH.CD,3,2)")
        'strSQL2.Append("ORDER BY TO_NUMBER(MS.DISP_NO), MS.CD")
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        hdnTSADCD1.Value = ""
        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        ''�x��P
        'If hdnKMCD1.Value.Length <> 0 Then
        '    '�쓮����(���b�Z�[�W����L��)������
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD1.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�



        '�x��Ȃ��A�܂��́Aү���ސ���Ȃ�
        'If hdnKMCD1.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then  '2023/09/15 DEL Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        '�S�쓮�������Z�b�g����
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD1.push(item);")
            '�R���{�ɒǉ�
            cboTSADCD.Items.Add(New ListItem(Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)),
                      Convert.ToString(dbData1.Tables(0).Rows(i).Item(0))))
        Next
        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        'Else
        '    '�쓮����(���b�Z�[�W����L��)���Z�b�g����
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD1.push(item);")
        '        '�R���{�ɒǉ�
        '        cboTSADCD.Items.Add(New ListItem(Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)),
        '              Convert.ToString(dbData2.Tables(0).Rows(i).Item(0))))
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        ''�x��Q
        ''�x�񂠂�
        'If hdnKMCD2.Value.Length <> 0 Then
        '    '�쓮����(���b�Z�[�W����L��)������
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD2.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '�x��Ȃ��A�܂��́Aү���ސ���Ȃ�
        'If hdnKMCD2.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        '�S�쓮�������Z�b�g����
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD2.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        'Else
        '    '�쓮����(���b�Z�[�W����L��)���Z�b�g����
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD2.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        ''�x��R
        ''�x�񂠂�
        'If hdnKMCD3.Value.Length <> 0 Then
        '    '�쓮����(���b�Z�[�W����L��)������
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD3.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '�x��Ȃ��A�܂��́Aү���ސ���Ȃ�
        'If hdnKMCD3.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        '�S�쓮�������Z�b�g����
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD3.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        'Else
        '    '�쓮����(���b�Z�[�W����L��)���Z�b�g����
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD3.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        ''�x��S
        ''�x�񂠂�
        'If hdnKMCD4.Value.Length <> 0 Then
        '    '�쓮����(���b�Z�[�W����L��)������
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD4.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '�x��Ȃ��A�܂��́Aү���ސ���Ȃ�
        'If hdnKMCD4.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        '�S�쓮�������Z�b�g����
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD4.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        'Else
        '    '�쓮����(���b�Z�[�W����L��)���Z�b�g����
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD4.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        ''�x��T
        ''�x�񂠂�
        'If hdnKMCD5.Value.Length <> 0 Then
        '    '�쓮����(���b�Z�[�W����L��)������
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD5.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '�x��Ȃ��A�܂��́Aү���ސ���Ȃ�
        'If hdnKMCD5.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        '�S�쓮�������Z�b�g����
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD5.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        'Else
        '    '�쓮����(���b�Z�[�W����L��)���Z�b�g����
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD5.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        ''�x��U
        ''�x�񂠂�
        'If hdnKMCD6.Value.Length <> 0 Then
        '    '�쓮����(���b�Z�[�W����L��)������
        '    cdb.pSQL = strSQL2.ToString
        '    cdb.pSQLParamStr("KEIHOCD") = hdnKMCD6.Value
        '    cdb.mExecQuery()
        '    dbData2 = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[

        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�

        '�x��Ȃ��A�܂��́Aү���ސ���Ȃ�
        'If hdnKMCD6.Value.Length = 0 OrElse dbData2.Tables(0).Rows.Count = 0 Then '2023/09/15 DEL Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        '�S�쓮�������Z�b�g����
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                              + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD6.push(item);")
        Next
        '2023/09/15 DEL START Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�
        'Else
        '    '�쓮����(���b�Z�[�W����L��)���Z�b�g����
        '    For i = 0 To dbData2.Tables(0).Rows.Count - 1
        '        strMsg.Append("var item = {val:'" + Convert.ToString(dbData2.Tables(0).Rows(i).Item(0)) + "',txt:'" _
        '                      + Convert.ToString(dbData2.Tables(0).Rows(i).Item(1)) + "'};")
        '        strMsg.Append("listcboTSADCD6.push(item);")
        '    Next
        'End If
        '2023/09/15 DEL END   Y.ARAKAKI �v���_�E���敪59�i�쓮�������X�g�\���i���j�̊��S�������Ή�


        '�x���ύX�����Ƃ��̂��߂ɁB
        For i = 0 To dbData1.Tables(0).Rows.Count - 1
            strMsg.Append("var item = {val:'" + Convert.ToString(dbData1.Tables(0).Rows(i).Item(0)) + "',txt:'" _
                          + Convert.ToString(dbData1.Tables(0).Rows(i).Item(1)) + "'};")
            strMsg.Append("listcboTSADCD0.push(item);")
        Next


        '2020/11/01 T.Ono �Ď����P2020 End
    End Sub
    Private Sub fncCombo_Create_Syutusij()
        cboSDCD.pComboTitle = True
        cboSDCD.pNoData = False
        cboSDCD.pType = "SYUTUSIJ"                 '//�o���w�����e
        cboSDCD.mMakeCombo()
    End Sub

    '2022/12/08 ADD START Y.Arakaki 2022�X��No�F _����x�񃁃b�Z�[�WNo�I�����̃��X�g�����I��Ή�
    '******************************************************************************
    '*�@�T�@�v�F�����I�����X�g�擾�����i����̌x�񃁃b�Z�[�WNo�I�����A��ʂ̕������X�g���ڂ������I���ł���悤�ҏW�l����������B�j
    '*�@���@�l�F�����I��Ώۂ̌x�񃁃b�Z�[�WNo�Ǝ����I��惊�X�g�̃v���_�E���}�X�^��CD�́AJavaScript���ŌŒ�l�g�p���Ă���ׁA
    '*�@      �F�x��No�⎩���I���̒ǉ��Ή�������������vb��Js�ǂ�����C�����邱�ƁB
    '******************************************************************************
    Private Sub fncCombo_Get_JidouSentakuList()
        Dim cdb As New CDB
        Dim i As Integer

        cdb.mOpen()

        Dim strSQLJidowSentakuList As New StringBuilder("")
        Dim dbDataJidowSentakuList As DataSet
        strSQLJidowSentakuList.Append("SELECT ")
        strSQLJidowSentakuList.Append("  MP.CD  ")    '�x�����b�Z�[�WNo
        strSQLJidowSentakuList.Append(" ,MP.NAIYO1 ") '�����I�����X�g�i�Ώۂ̃v���_�E�����X�gNo2���{���X�g���e2���A���J���}��؂�Ǘ��j
        strSQLJidowSentakuList.Append("FROM ")
        strSQLJidowSentakuList.Append("  M06_PULLDOWN MP ")
        strSQLJidowSentakuList.Append("WHERE ")
        strSQLJidowSentakuList.Append("  MP.KBN='86' ") '�敪�F�x��No���̃��X�g�����I��
        strSQLJidowSentakuList.Append("  AND MP.CD NOT LIKE 'X%' ") 'X�n�܂��CD���R�[�h�͂����̃R�����g�p�R�[�h�Ŏg�p�s�̂��߁A�������珜�O�B
        strSQLJidowSentakuList.Append("ORDER BY MP.CD ")
        cdb.pSQL = strSQLJidowSentakuList.ToString
        cdb.mExecQuery()
        dbDataJidowSentakuList = cdb.pResult    '���ʂ��f�[�^�Z�b�g�Ɋi�[
        If dbDataJidowSentakuList.Tables(0).Rows.Count > 0 Then
            For i = 0 To dbDataJidowSentakuList.Tables(0).Rows.Count - 1
                strMsg.Append(
                      "var item = {keihoMsgNo:'" + Convert.ToString(dbDataJidowSentakuList.Tables(0).Rows(i).Item(0)) _
                    + "',jidouSentakuList:'" + Convert.ToString(dbDataJidowSentakuList.Tables(0).Rows(i).Item(1)) + "'};")
                strMsg.Append("listKeihouJidouSentakuCD.push(item);")
            Next
        End If

    End Sub
    '2022/12/08 ADD END   Y.Arakaki 2022�X��No�F _����x�񃁃b�Z�[�WNo�I�����̃��X�g�����I��Ή�

    '******************************************************************************
    '*�@�T�@�v�F�����e�L�X�g�o�͎��Ɏg�p�i����(��:�R����)�ŋ�؂�j
    '*�@���@�l�F
    '******************************************************************************
    Private Function fncEditCutMsg(ByVal strCd As String, ByVal strMsg As String, ByVal strCut As String) As String
        Dim strRec As String
        If strCd.Length = 0 Then
            '2014/12/16 T.Ono mod 2014���P�J�� No2
            'strRec = ""
            strRec = strMsg
        Else
            strRec = strCd & strCut & strMsg
        End If
        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�e�ʌv�Z���Ɏg�p
    '*�@���@�l�F�e��Ɩ{�����e�ʂ����߂�
    '******************************************************************************
    Private Function fncEditYouryou(ByVal strYouki As String, ByVal strHonsu As String) As String
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc

        '�����ꂩ�������Ă��Ȃ��ꍇ�A�������͐��l�łȂ��ꍇ�͌v�Z���Ȃ�()
        If (strYouki.Length = 0 Or strHonsu.Length = 0) Or _
           (IsNumeric(strYouki) = False Or IsNumeric(strHonsu) = False) Then
            strRec = ""
        Else
            strRec = Convert.ToString(Convert.ToDecimal(strYouki) * Convert.ToDecimal(strHonsu))
            strRec = NaNFncC.mGet(strRec, 0)
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�z�������o�͎��Ɏg�p
    '*�@���@�l�F���t�̏ꍇ�͕ϊ��ȊO�͂��̂܂܏o��
    '******************************************************************************
    Private Function fncEditDate(ByVal strDate As String) As String
        Dim strRec As String
        Dim strFlg As String
        '���t�`�F�b�N
        If strDate.Length = 8 Then
            strRec = strDate.Substring(0, 4) & "/" & strDate.Substring(4, 2) & "/" & strDate.Substring(6, 2)
            If IsDate(strRec) = True Then
                strFlg = "1"
            Else
                strFlg = "0"
            End If
        Else
            strFlg = "0"
        End If
        '���t�łȂ��ꍇ�͂��̂܂܂̒l���Z�b�g
        If strFlg = "0" Then
            strRec = strDate
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�w�j���o�͎��Ɏg�p�i�E���琔�����ꍇ�̌����������ȉ������Ƃ���j
    '*�@���@�l�F���������l�̏ꍇ�̂݁A���l�łȂ��ꍇ�͂��̂܂܂̒l��Ԃ�
    '******************************************************************************
    '2005/11/22 NEC UPDATE START
    '    Private Function fncEditSisin(ByVal strSisin As String) As String
    Private Function fncEditSisin(ByVal strSisin As String, ByVal intKeta As Integer) As String
        '2005/11/22 NEC UPDATE END
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                strRec = ""
                '2005/11/22 NEC ADD START
                '�����_���܂܂�Ă����炻�̂܂ܒl��Ԃ�
            ElseIf InStr(strSisin, ".") > 0 Then
                strRec = strSisin
                '2005/11/22 NEC ADD END
            ElseIf strSisin.Length = 1 Then
                '2005/11/22 NEC UPDATE START
                'strRec = "0." & strSisin
                strRec = Convert.ToString(Convert.ToDecimal(strSisin) / 10D ^ Convert.ToDecimal(intKeta))
                '2005/11/22 NEC UPDATE END
            Else
                '2005/11/22 NEC UPDATE START
                'strRec = strSisin
                'strRec = Left(strRec, strRec.Length - 1) & "." & Right(strRec, 1)
                '�[������
                strRec = strSisin.PadLeft(8 - strSisin.Length, "0"c)
                strRec = Left(strRec, strRec.Length - intKeta) & "." & Right(strRec, intKeta)
                If intKeta = 1 Then
                    strRec = Format(Convert.ToDecimal(strRec), "##,###,##0.0")
                ElseIf intKeta = 3 Then
                    strRec = Format(Convert.ToDecimal(strRec), "##,###,##0.000")
                End If
                '2005/11/22 NEC UPDATE END
                '2005/11/22 NEC DEL START
                'strRec = NaNFncC.mGet(strRec, 1)
                '2005/11/22 NEC DEL START
            End If
        Else
            strRec = strSisin
        End If

        Return strRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F���P���������_�Ƃ��鐔�l�^�ɕϊ�����
    '*�@���@�l�F
    '******************************************************************************
    Private Function fncEditSisinDec(ByVal strSisin As String) As Decimal
        Dim strRec As String
        If IsNumeric(strSisin) = True Then
            If strSisin.Length = 0 Then
                '20050729 NEC udpate START
                '                strRec = ""
                strRec = "0"
                '20050729 NEC udpate END
            ElseIf strSisin.Length = 1 Then
                strRec = "0." & strSisin
            Else
                strRec = strSisin
                strRec = Left(strRec, strRec.Length - 1) & "." & Right(strRec, 1)
            End If
        Else
            strRec = strSisin
        End If
        '20050729 NEC ADD START
        If IsNumeric(strRec) = False Then
            strRec = "0"
        End If
        '20050729 NEC ADD STOP

        Return CDec(strRec)
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�w�j�����(�o�^)���Ɏg�p�i�Ō�P���������ȉ������ɖ߂��j
    '*�@���@�l�F���������l�̏ꍇ�̂݁A���l�łȂ��ꍇ�͂��̂܂܂̒l��Ԃ�
    '******************************************************************************
    '2005/11/22 NEC UPDATE START
    'Private Function fncHenkanSisin(ByVal strSisin As String) As String
    Private Function fncHenkanSisin(ByVal strSisin As String, Optional ByVal intKeta As Integer = 1) As String
        '2005/11/22 NEC UPDATE END
        Dim strRec As String
        Dim NaNFncC As New CNaNFnc
        '2005/11/22 NEC ADD START
        If intKeta = 1 Then
            '2005/11/22 NEC ADD END

            strRec = NaNFncC.mHenkanGet(strSisin)
            If IsNumeric(strRec) = True Then
                strRec = CStr(CInt(CDec(strRec) * 10))
            Else
                strRec = strSisin
            End If
            '2005/11/22 NEC ADD START
        ElseIf intKeta = 3 Then
            strRec = NaNFncC.mHenkanGet(strSisin)
            If IsNumeric(strRec) = True Then
                strRec = CStr(CInt(CDec(strRec) * 1000))
            Else
                strRec = strSisin
            End If
        End If
        '2005/11/22 NEC ADD END

        Return strRec
    End Function

    '******************************************************************************
    '******************************************************************************
    '******************************************************************************
    '*�@�T�@�v�FhdnBackUrl�̒l��n���v���p�e�B
    '*�@���@�l�F�J�ڌ��̉�ʂɂ���ă`�F�b�N�𐧌䂷��
    '******************************************************************************
    Public ReadOnly Property pBackUrl() As String
        Get
            Return hdnBackUrl.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�FhdnKEY_SERIAL�̒l��n���v���p�e�B
    '*�@���@�l�F�Ď��p�l�����J�ڎ��g�p����
    '******************************************************************************
    Public ReadOnly Property pMoveSerial() As String
        Get
            Return hdnKEY_SERIAL.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�i���ݏ�����n���v���p�e�B
    '*�@���@�l�F���o�����P�̒l��n��
    '******************************************************************************
    Public ReadOnly Property pCode1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                '�Ď��Z���^�[�R�[�h�t���O("0"������ "1"����)
                If hdnKANSFLG.Value = "1" Then
                    strRec = hdnKANSCD.Value            '//�N���C�A���g�R�[�h�ꗗ�@�f�[�^�����܂��Ă���̂ł��̊Ď��Z���^�[�R�[�h
                Else
                    strRec = AuthC.pAUTHCENTERCD        '//�N���C�A���g�R�[�h�ꗗ�@�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h
                End If
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = txtClientCD.Text           '//�i�`/�i�`�x���R�[�h�ꗗ �N���C�A���g�R�[�h��n��
            ElseIf hdnPopcrtl.Value = "3" Then
                'strRec = txtClientCD.Text           '//�Ď��S���҈ꗗ �N���C�A���g�R�[�h��n�� 2007/08/09 T.Watabe edit ��s�Ή�
                'strRec = AuthC.pAUTHCENTERCD        '//�Ď��S���҈ꗗ�@�`�c�F�؂̎g�p�\�Ď��Z���^�[�R�[�h 2007/08/09 T.Watabe edit ��s�Ή�
                'strRec = AuthC.pCENTERCD            '//�Ď��S���҈ꗗ�@�����̊Ď��Z���^�[�R�[�h
                ''�^�s�J�����̏ꍇ�͑S�Ă̊Ď��Z���^�[�̊Ď��S���҂�I���\
                ''�ȊO�̏ꍇ�͑�s���g�p�����Ɏ����̊Ď��Z���^�[�̊Ď��S���҂̂ݎg�p�\
                Dim strGROUPNAME As String = AuthC.pGROUPNAME
                Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))
                If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
                    strRec = AuthC.pAUTHCENTERCD
                Else
                    strRec = AuthC.pCENTERCD
                End If
            ElseIf hdnPopcrtl.Value = "11" Or _
                    hdnPopcrtl.Value = "12" Or _
                    hdnPopcrtl.Value = "13" Or _
                    hdnPopcrtl.Value = "14" Or _
                    hdnPopcrtl.Value = "15" Or _
                    hdnPopcrtl.Value = "16" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ
                strRec = "70"                         '//�x�񃁃b�Z�[�W�ꗗ KBN=70��n�� 2007/04/19
            ElseIf hdnPopcrtl.Value = "21" Then      '// �����敪(PULLCODE)�R�[�h�ꗗ 2007/04/25
                strRec = "08"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�̖��O��n���v���p�e�B
    '*�@���@�l�F�|�b�v�A�b�v�̃^�C�g������n��
    '******************************************************************************
    Public ReadOnly Property pListName() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "�N���C�A���g�R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "2" Then      '//�i�`/�i�`�x���R�[�h�ꗗ
                strRec = "�i�`/�i�`�x���R�[�h�ꗗ"
            ElseIf hdnPopcrtl.Value = "3" Then      '//�Ď��Z���^�[�S���҈ꗗ
                strRec = "�Ď��Z���^�[�S���҈ꗗ"
            ElseIf hdnPopcrtl.Value = "11" Or _
                   hdnPopcrtl.Value = "12" Or _
                   hdnPopcrtl.Value = "13" Or _
                   hdnPopcrtl.Value = "14" Or _
                   hdnPopcrtl.Value = "15" Or _
                   hdnPopcrtl.Value = "16" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "�x�񃁃b�Z�[�W�ꗗ"
            ElseIf hdnPopcrtl.Value = "21" Then      '// �����敪(PULLCODE)�R�[�h�ꗗ 2007/04/25
                strRec = "�����敪"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�o�͂���ꗗ�𐧌䂷��l��n���v���p�e�B
    '*�@���@�l�F�|�b�v�A�b�v�̎�ނ�I������
    '******************************************************************************
    Public ReadOnly Property pListCd() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then          '//�N���C�A���g�R�[�h�ꗗ
                strRec = "CLI"
            ElseIf hdnPopcrtl.Value = "2" Then      '//�i�`/�i�`�x���R�[�h�ꗗ
                'strRec = "JAJASS"
                'strRec = "JASS2"      '--- 2005/05/24 MOD Falcon ---
                strRec = "JASS"      '--- 2008/02/27 MOD T.Watabe ---
            ElseIf hdnPopcrtl.Value = "3" Then      '//�i�`/�i�`�x���R�[�h�ꗗ
                'strRec = "TKTANCD" '2007/08/09 T.Watabe edit �Ď��Z���^�[�S���҂��N���C�A���g�ł͂Ȃ��Ď��Z���^�[�R�[�h�ōi��悤�ɕύX
                strRec = "TKTANCDKN"
            ElseIf hdnPopcrtl.Value = "11" Or _
                   hdnPopcrtl.Value = "12" Or _
                   hdnPopcrtl.Value = "13" Or _
                   hdnPopcrtl.Value = "14" Or _
                   hdnPopcrtl.Value = "15" Or _
                   hdnPopcrtl.Value = "16" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "PULLCODE"
            ElseIf hdnPopcrtl.Value = "21" Then      '// �����敪(PULLCODE)�R�[�h�ꗗ 2007/04/25
                strRec = "PULLCODE"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�R�[�h��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�R�[�h��Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackCode() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtClientCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "hdnJASCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "hdnTKTANCD"
            ElseIf hdnPopcrtl.Value = "11" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMCD1"
            ElseIf hdnPopcrtl.Value = "12" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMCD2"
            ElseIf hdnPopcrtl.Value = "13" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMCD3"
            ElseIf hdnPopcrtl.Value = "14" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMCD4"
            ElseIf hdnPopcrtl.Value = "15" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMCD5"
            ElseIf hdnPopcrtl.Value = "16" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMCD6"
            ElseIf hdnPopcrtl.Value = "21" Then      '// �����敪(PULLCODE)�R�[�h�ꗗ 2007/04/25
                strRec = "hdnHATKBN"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���̂�Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A���̂�Ԃ��I�u�W�F�N�g�����w�肷��
    '******************************************************************************
    Public ReadOnly Property pBackName() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtClientNAME"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "txtTKTANCD"
            ElseIf hdnPopcrtl.Value = "11" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMNM1"
            ElseIf hdnPopcrtl.Value = "12" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMNM2"
            ElseIf hdnPopcrtl.Value = "13" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMNM3"
            ElseIf hdnPopcrtl.Value = "14" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMNM4"
            ElseIf hdnPopcrtl.Value = "15" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMNM5"
            ElseIf hdnPopcrtl.Value = "16" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "hdnKMNM6"
            ElseIf hdnPopcrtl.Value = "21" Then      '// �����敪(PULLCODE)�R�[�h�ꗗ 2007/04/25
                strRec = "txtHATKBN"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F�t�H�[�J�X��Ԃ��I�u�W�F�N�g�̖��O�l��n���v���p�e�B
    '*�@���@�l�F�f�[�^�I����A�l��Ԃ�����ɁA�J�[�\�����Z�b�g����ꏊ�̎w��
    '******************************************************************************
    Public ReadOnly Property pBackFocs() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "btnKURACD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = "btnJASCD"
            ElseIf hdnPopcrtl.Value = "3" Then
                strRec = "btnTKTANCD"
            ElseIf hdnPopcrtl.Value = "11" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "btnKEICD1"
            ElseIf hdnPopcrtl.Value = "12" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "btnKEICD2"
            ElseIf hdnPopcrtl.Value = "13" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "btnKEICD3"
            ElseIf hdnPopcrtl.Value = "14" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "btnKEICD4"
            ElseIf hdnPopcrtl.Value = "15" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "btnKEICD5"
            ElseIf hdnPopcrtl.Value = "16" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "btnKEICD6"
            ElseIf hdnPopcrtl.Value = "21" Then      '// �����敪(PULLCODE)�R�[�h�ꗗ 2007/04/25
                strRec = "btnHATKBN"
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���^�[����Ɏ��s�����i�r
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pBackScript() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then      '�N���C�A���g�R�[�h
                strRec = "fncSyutudouIni"

            ElseIf hdnPopcrtl.Value = "2" Then  '�i�`�x��
                strRec = "fncSyutudou"
            ElseIf hdnPopcrtl.Value = "3" Then  '�Ď��Z���^�[�S����
                strRec = ""
            ElseIf hdnPopcrtl.Value = "11" Or _
                    hdnPopcrtl.Value = "12" Or _
                    hdnPopcrtl.Value = "13" Or _
                    hdnPopcrtl.Value = "14" Or _
                    hdnPopcrtl.Value = "15" Or _
                    hdnPopcrtl.Value = "16" Then      '// �x�񃁃b�Z�[�W(PULLCODE)�R�[�h�ꗗ 2007/04/19
                strRec = "fncKeihoMsgCopy"
            ElseIf hdnPopcrtl.Value = "21" Then       '�����敪(PULLCODE)�R�[�h�ꗗ 2007/04/25
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear1() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnJASCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear2() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtACBNM"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear3() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "hdnTKTANCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pClear4() As String
        Get
            Dim strRec As String
            If hdnPopcrtl.Value = "1" Then
                strRec = "txtTKTANCD"
            ElseIf hdnPopcrtl.Value = "2" Then
                strRec = ""
            Else
                strRec = ""
            End If
            Return strRec
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPRAM_CLI() As String
        Get
            Return txtClientCD.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPRAM_JASS() As String
        Get
            Return hdnJASCD.Value
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPRAM_JUYOKA() As String
        Get
            Return txtJUYOKA.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F
    '*�@���@�l�F
    '******************************************************************************
    Public ReadOnly Property pPRAM_JUYOKANAME() As String
        Get
            Return txtJUSYONM.Text
        End Get
    End Property

    '******************************************************************************
    '*�@�T�@�v�F���q�l�d�b�ԍ�1�̎擾
    '*�@���@�l�F2007/04/19 T.Watabe add
    '******************************************************************************
    Public ReadOnly Property pPRAM_TEL1() As String
        Get
            Dim tel As String
            If txtJUTEL1.Text.Length > 0 Then
                ' �����ȊO�͍폜        
                Dim pattern As String = "[^0-9]" '�p�^�[���F�����ȊO
                Dim rgx As New System.Text.RegularExpressions.Regex(pattern)
                tel = rgx.Replace(txtJUTEL1.Text, "") '�u������
            End If
            Return tel
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F���q�l�d�b�ԍ�2�̎擾
    '*�@���@�l�F2007/04/19 T.Watabe add
    '******************************************************************************
    Public ReadOnly Property pPRAM_TEL2() As String
        Get
            Dim tel As String
            If txtJUTEL2.Text.Length > 0 Then
                ' �����ȊO�͍폜        
                Dim pattern As String = "[^0-9]" '�p�^�[���F�����ȊO
                Dim rgx As New System.Text.RegularExpressions.Regex(pattern)
                tel = rgx.Replace(txtJUTEL2.Text, "") '�u������
            End If
            Return tel
        End Get
    End Property
    '******************************************************************************
    '*�@�T�@�v�F�d���\���̑Ώۂ�
    '*�@���@�l�F0�F�ΏۊO�@1�F�Ώ�
    '******************************************************************************
    Public ReadOnly Property pPRAM_choufukuhyouji() As String
        Get
            Return hdnchoufukuhyouji.Value
        End Get
    End Property

    '* 2007/04/18 ZBS T.Watabe �f�o�b�O�p�ꎞ�o��
    Sub putlog(ByVal msg As String)
        ' ���O�E�t�@�C��err.log�ւ̏o�̓X�g���[���𐶐�
        'Dim objSw As New System.IO.StreamWriter(Server.MapPath("/err.log"), True, Encoding.GetEncoding("Shift_JIS"))
        Dim objSw As New System.IO.StreamWriter("c:\debug.log", True, System.Text.Encoding.Default)
        objSw.WriteLine(DateTime.Now.ToString() & " " & msg)
        objSw.Close()
    End Sub

    ' 2007/05/09 T.Watabe add
    '******************************************************************************
    ' �v���_�E���}�X�^����KBN=71�i�Ή����͉\�N���C�A���g�j���擾����
    '******************************************************************************
    Private Function fncGetData_ClientList() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRes As String
        Dim strClientList As New StringBuilder("")
        Dim i As Integer

        strRes = ""
        Try
            '//�o����Џ��̎擾
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT CD ")
            strSQL.Append("FROM M06_PULLDOWN ")
            strSQL.Append("WHERE KBN = '71' ")   ' KBN=71�i�Ή����͉\�N���C�A���g�j
            strSQL.Append("ORDER BY CD ")

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)


            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�Ȃ��̏ꍇ
            Else
                '�f�[�^����̏ꍇ
                For i = 0 To dbData.Tables(0).Rows.Count - 1
                    If i > 0 Then
                        strClientList.Append(",") ' �Q�ڂ���J���}��t����
                    End If
                    strClientList.Append(Convert.ToString(dbData.Tables(0).Rows(i).Item("CD")))
                Next
            End If
            strRes = strClientList.ToString

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRes = ""

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim LogC As New CLog
        Dim strRecLog As String

        Dim linestring As New StringBuilder("")
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)
            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''�����̕�������X�g���[���ɏ�������
            'sw.Write(linestring.ToString)

            ''�������t���b�V���i�t�@�C���������݁j
            ''sw.Flush()

            ''�t�@�C���N���[�Y
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
        End If
    End Sub

    '**********************************************************
    ' 2013/08/02 T.Ono
    'FAX�s�v�敪(JA�E�ײ���)�A���ӎ����擾 fncSetData_KEIHOU
    '**********************************************************
    Private Function fncGetFAXKBN_GUIDE_KEIHOU() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        'Dim strRes(2) As String       '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        'For i As Integer = 0 To 2     '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        Dim strRes(4) As String        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        For i As Integer = 0 To 4      '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strRes(i) = ""
        Next

        Try
            strSQL = New StringBuilder("")
            '2016/02/02 w.ganeko 2015�J�����P ��1 start
            'strSQL.Append("WITH ")
            'strSQL.Append("/* ���q�l�� */ ")
            'strSQL.Append("A AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO2 T ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NULL ")
            'strSQL.Append("AND    KEI.JUYOKA = T.USER_CD_FROM ")
            'strSQL.Append("), ")
            'strSQL.Append("/* ���q�l�͈� */ ")
            'strSQL.Append("B AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO2 T ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NOT NULL ")
            'strSQL.Append("AND    KEI.JUYOKA BETWEEN T.USER_CD_FROM AND T.USER_CD_TO ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA�x�� */ ")
            'strSQL.Append("C AS( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO T ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    KEI.ACBCD = T.CODE ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA3�P�^ */ ")
            'strSQL.Append("D AS( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO T, ")
            'strSQL.Append("       HN2MAS H ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    H.CLI_CD = T.KURACD ")
            'strSQL.Append("AND    T.CODE = H.JA_CD ")
            'strSQL.Append("AND    KEI.KURACD = H.CLI_CD ")
            'strSQL.Append("AND    KEI.ACBCD  = H.HAN_CD ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01'  ")
            'strSQL.Append("), ")
            ''2015/02/19 T.Ono add 2014���P�J�� No15 �ײ��Ēǉ� START
            'strSQL.Append("/* �N���C�A���g */ ")
            'strSQL.Append("K AS( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, '' AS GUIDELINE ")
            'strSQL.Append("FROM   T10_KEIHO KEI, ")
            'strSQL.Append("       M05_TANTO T ")
            'strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            'strSQL.Append("AND    T.CODE = 'XXXX' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            ''2015/02/19 T.Ono add 2014���P�J�� No15 END
            strSQL.Append("WITH ")
            strSQL.Append("/* ���q�l�� */ ")
            strSQL.Append("A AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   T10_KEIHO KEI, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            strSQL.Append("AND    KEI.ACBCD = T.ACBCD ")
            strSQL.Append("AND    KEI.JUYOKA = T.USERCD_FROM ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            strSQL.Append("/* ���q�l�͈� */ ")
            strSQL.Append("B AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   T10_KEIHO KEI, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            strSQL.Append("AND    KEI.ACBCD = T.ACBCD ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_TO IS NOT NULL ")
            strSQL.Append("AND    KEI.JUYOKA BETWEEN T.USERCD_FROM AND T.USERCD_TO ")
            strSQL.Append("), ")
            strSQL.Append("/* JA�x�� */ ")
            strSQL.Append("C AS( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   T10_KEIHO KEI, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    KEI.KURACD = T.KURACD ")
            strSQL.Append("AND    KEI.ACBCD = T.ACBCD ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_FROM IS NULL ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("), ")
            strSQL.Append("/* �N���C�A���g */ ")
            strSQL.Append("K AS( ")
            strSQL.Append("SELECT T.GROUPCD AS KURACD, T.FAXKBN, T.FAXKURAKBN, '' AS GUIDELINE ")
            strSQL.Append(",'' AS GUIDELINE2 ")        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",'' AS GUIDELINE3 ")        '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   T10_KEIHO KEI, ")
            strSQL.Append("       M11_JAHOKOKU T ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL ")
            strSQL.Append("AND    T.KBN = '1' ")
            strSQL.Append("AND    KEI.KURACD = T.GROUPCD ")
            strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 end
            strSQL.Append("/* DUMMY */ ")
            strSQL.Append("E AS( ")
            strSQL.Append("SELECT KEI.KURACD ")
            strSQL.Append("FROM   T10_KEIHO KEI ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL  ")
            strSQL.Append(") ")
            '2015/02/19 T.Ono mod 2014���P�J�� No15 �ײ��Ēǉ� START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, '0')))) AS FAXKBN , ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM A, B, C, D, E ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, NVL(K.FAXKBN, '0'))))) AS FAXKBN , ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, NVL(K.FAXKURAKBN, '0'))))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM A, B, C, D, K, E ")
            ''2015/02/19 T.Ono mod 2014���P�J�� No15 END
            'strSQL.Append("WHERE 	E.KURACD = D.KURACD(+) ")
            'strSQL.Append("AND	E.KURACD = C.KURACD(+) ")
            'strSQL.Append("AND	E.KURACD = B.KURACD(+) ")
            'strSQL.Append("AND	E.KURACD = A.KURACD(+) ")
            'strSQL.Append("AND	E.KURACD = K.KURACD(+) ") '2015/02/19 T.Ono mod 2014���P�J�� No15 �ײ��Ēǉ�
            strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(K.FAXKBN, '0')))) AS FAXKBN , ")
            strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(K.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, ''))) AS GUIDELINE, ")
            strSQL.Append("       NVL(A.GUIDELINE2, NVL(B.GUIDELINE2, NVL(C.GUIDELINE2, ''))) AS GUIDELINE2, ") '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("       NVL(A.GUIDELINE3, NVL(B.GUIDELINE3, NVL(C.GUIDELINE3, ''))) AS GUIDELINE3, ") '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("       NVL(A.USERCD_FROM, NVL(B.USERCD_FROM, '')) AS USER_CD_FROM ")
            strSQL.Append("FROM A, B, C, K, E ")
            strSQL.Append("WHERE 	")
            strSQL.Append("     E.KURACD = C.KURACD(+) ")
            strSQL.Append("AND	E.KURACD = B.KURACD(+) ")
            strSQL.Append("AND	E.KURACD = A.KURACD(+) ")
            strSQL.Append("AND	E.KURACD = K.KURACD(+) ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 END

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("SYORI_SERIAL", True, hdnKEY_SERIAL.Value)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�Ȃ��̏ꍇ
                strRes(0) = "0"
                strRes(1) = "0"
                strRes(2) = ""
                strRes(3) = ""    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                strRes(4) = ""    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            Else
                '�f�[�^����̏ꍇ
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN"))
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKURAKBN"))
                strRes(2) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE"))
                strRes(3) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE2"))  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                strRes(4) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE3"))  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                hdnUSER_CD_FROM.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_FROM"))
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            For i As Integer = 0 To 2
                strRes(i) = ""
            Next

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/23 T.Ono add �Ď����P2013��1
    ' �{���H���󋵎擾�iKAILOG�FKAITU_DAY�j�@fncSetData_KEIHOU
    '**********************************************************
    Private Function fncGetKAITU_DAY_KEIHO() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRes As String

        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT MAX(TO_CHAR(KAITU_DAY, 'YYYY/MM/DD HH24:MI:SS')) AS KAITU_DAY ")
            strSQL.Append("FROM   T10_KEIHO KEI,  ")
            strSQL.Append("       KAILOG L ")
            strSQL.Append("WHERE  KEI.SYORI_SERIAL = :SYORI_SERIAL  ")
            strSQL.Append("AND    KEI.KURACD = L.CLI_CD  ")
            strSQL.Append("AND    KEI.ACBCD = L.HAN_CD  ")
            strSQL.Append("AND    KEI.JUYOKA = L.USER_CD ")
            strSQL.Append("AND    KAITU_DAY >= TO_DATE(TO_CHAR(SYSDATE, 'YYYY/MM/DD'),'YYYY/MM/DD') ")
            strSQL.Append("AND    KAITU_FLG = '20' ")
            strSQL.Append("ORDER BY KAITU_DAY ")

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("SYORI_SERIAL", True, hdnKEY_SERIAL.Value)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�Ȃ��̏ꍇ
                strRes = ""
            Else
                '�f�[�^����̏ꍇ
                strRes = Convert.ToString(dbData.Tables(0).Rows(0).Item("KAITU_DAY"))
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRes = ""

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/05 T.Ono
    'FAX�s�v�敪(JA�E�ײ���)�A���ӎ����擾 fncSetData_KOKYAKU
    '**********************************************************
    Private Function fncGetFAXKBN_GUIDE_KOKYAKU() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        'Dim strRes(2) As String      '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        'For i As Integer = 0 To 2    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        Dim strRes(4) As String       '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        For i As Integer = 0 To 4     '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strRes(i) = ""
        Next

        Try
            strSQL = New StringBuilder("")
            '2016/02/02 w.ganeko 2015�J�����P ��1 start
            'strSQL.Append("WITH  ")
            'strSQL.Append("/* ���q�l�� */ ")
            'strSQL.Append("A AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO2 T ")
            'strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.USER_CD_FROM = :USER_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NULL ")
            'strSQL.Append("), ")
            'strSQL.Append("/* ���q�l�͈� */ ")
            'strSQL.Append("B AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.USER_CD_FROM, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO2 T ")
            'strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND    T.USER_CD_TO IS NOT NULL ")
            'strSQL.Append("AND    :USER_CD BETWEEN T.USER_CD_FROM AND T.USER_CD_TO ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA�x�� */ ")
            'strSQL.Append("C AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO T ")
            'strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            'strSQL.Append("AND    T.CODE = :HAN_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            'strSQL.Append("/* JA3�P�^ */ ")
            'strSQL.Append("D AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, T.GUIDELINE ")
            'strSQL.Append("FROM   HN2MAS H, ")
            'strSQL.Append("       M05_TANTO T ")
            'strSQL.Append("WHERE  H.CLI_CD = :CLI_CD ")
            'strSQL.Append("AND    H.HAN_CD = :HAN_CD ")
            'strSQL.Append("AND    H.CLI_CD = T.KURACD ")
            'strSQL.Append("AND    T.CODE = H.JA_CD ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            ''2015/02/19 T.Ono add 2014���P�J�� No15 �ײ��Ēǉ� START
            'strSQL.Append("/* �N���C�A���g */ ")
            'strSQL.Append("K AS ( ")
            'strSQL.Append("SELECT T.KURACD, T.CODE, T.FAXKBN, T.FAXKURAKBN, '' AS GUIDELINE ")
            'strSQL.Append("FROM   M05_TANTO T ")
            'strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            'strSQL.Append("AND    T.CODE = 'XXXX' ")
            'strSQL.Append("AND    T.KBN = '3' ")
            'strSQL.Append("AND    LPAD(T.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            '2015/02/19 T.Ono add 2014���P�J�� No15 END
            strSQL.Append("WITH ")
            strSQL.Append("/* ���q�l�� */ ")
            strSQL.Append("A AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    T.USERCD_FROM = :USER_CD ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            strSQL.Append("/* ���q�l�͈� */ ")
            strSQL.Append("B AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_TO IS NOT NULL ")
            strSQL.Append("AND    :USER_CD BETWEEN T.USERCD_FROM AND T.USERCD_TO ")
            strSQL.Append("), ")
            strSQL.Append("/* JA�x�� */ ")
            strSQL.Append("C AS ( ")
            strSQL.Append("SELECT T.KURACD, T.ACBCD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 ")    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  T.KURACD = :CLI_CD ")
            strSQL.Append("AND    T.ACBCD = :HAN_CD ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_FROM IS NULL ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("), ")
            strSQL.Append("/* �N���C�A���g */ ")
            strSQL.Append("K AS ( ")
            strSQL.Append("SELECT D.GROUPCD AS KURACD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE AS GUIDELINECL ")
            strSQL.Append(",D.GUIDELINE2 AS GUIDELINECL2 ")    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append(",D.GUIDELINE3 AS GUIDELINECL3 ")    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM M11_JAHOKOKU D ")
            strSQL.Append("WHERE  D.KBN = '1' ")
            strSQL.Append("AND    D.GROUPCD = :CLI_CD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 END
            strSQL.Append("/* DUMMY */ ")
            strSQL.Append("E AS( ")
            strSQL.Append("SELECT :CLI_CD AS CLI_CD ")
            strSQL.Append("FROM   DUAL  ")
            strSQL.Append(") ")
            '2015/02/19 T.Ono add 2014���P�J�� No15 �ײ��Ēǉ� START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, '0')))) AS FAXKBN, ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM   A, B, C, D, E ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, NVL(K.FAXKBN, '0'))))) AS FAXKBN, ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, NVL(K.FAXKURAKBN, '0'))))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM   A, B, C, D, K, E ")
            ''2015/02/19 T.Ono add 2014���P�J�� No15 END
            'strSQL.Append("WHERE  E.CLI_CD = A.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = B.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = C.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = D.KURACD(+) ")
            'strSQL.Append("AND    E.CLI_CD = K.KURACD(+) ") '2015/02/19 T.Ono add 2014���P�J�� No15
            strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(K.FAXKBN, '0')))) AS FAXKBN, ")
            strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(K.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, ''))) AS GUIDELINE, ")
            strSQL.Append("       NVL(A.GUIDELINE2, NVL(B.GUIDELINE2, NVL(C.GUIDELINE2, ''))) AS GUIDELINE2, ")  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("       NVL(A.GUIDELINE3, NVL(B.GUIDELINE3, NVL(C.GUIDELINE3, ''))) AS GUIDELINE3, ")  '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("       NVL(A.USERCD_FROM, NVL(B.USERCD_FROM, '')) AS USER_CD_FROM ")
            strSQL.Append("FROM   A, B, C, K, E ")
            strSQL.Append("WHERE  E.CLI_CD = A.KURACD(+) ")
            strSQL.Append("AND    E.CLI_CD = B.KURACD(+) ")
            strSQL.Append("AND    E.CLI_CD = C.KURACD(+) ")
            strSQL.Append("AND    E.CLI_CD = K.KURACD(+) ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 END

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLI_CD", True, hdnKEY_CLI_CD.Value)
            SqlParamC.fncSetParam("USER_CD", True, hdnKEY_USER_CD.Value)
            SqlParamC.fncSetParam("HAN_CD", True, hdnKEY_HAN_CD.Value)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�Ȃ��̏ꍇ
                strRes(0) = "0"
                strRes(1) = "0"
                strRes(2) = ""
                strRes(3) = ""     '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                strRes(4) = ""     '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            Else
                '�f�[�^����̏ꍇ
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN"))
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKURAKBN"))
                strRes(2) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE"))
                strRes(3) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE2"))    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                strRes(4) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE3"))    '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                hdnUSER_CD_FROM.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_FROM"))
            End If


        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            For i As Integer = 0 To 2
                strRes(i) = ""
            Next

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/23 T.Ono add �Ď����P2013��1
    ' �{���H���󋵎擾�iKAILOG�FKAITU_DAY�j fncSetData_KOKYAKU
    '**********************************************************
    Private Function fncGetKAITU_DAY_KOKYAKU() As String
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRes As String

        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT MAX(TO_CHAR(KAITU_DAY, 'YYYY/MM/DD HH24:MI:SS')) AS KAITU_DAY ")
            strSQL.Append("FROM   KAILOG L ")
            strSQL.Append("WHERE  L.CLI_CD = :CLI_CD  ")
            strSQL.Append("AND    L.HAN_CD = :HAN_CD  ")
            strSQL.Append("AND    L.USER_CD = :USER_CD  ")
            strSQL.Append("AND    KAITU_DAY >= TO_DATE(TO_CHAR(SYSDATE, 'YYYY/MM/DD'),'YYYY/MM/DD') ")
            strSQL.Append("AND    KAITU_FLG = '20' ")
            strSQL.Append("ORDER BY KAITU_DAY ")

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLI_CD", True, hdnKEY_CLI_CD.Value)
            SqlParamC.fncSetParam("USER_CD", True, hdnKEY_USER_CD.Value)
            SqlParamC.fncSetParam("HAN_CD", True, hdnKEY_HAN_CD.Value)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�Ȃ��̏ꍇ
                strRes = ""
            Else
                '�f�[�^����̏ꍇ
                strRes = Convert.ToString(dbData.Tables(0).Rows(0).Item("KAITU_DAY"))
            End If


        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            strRes = ""

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/06/25 T.Ono
    'FAX�s�v�敪(JA�E�ײ���)�A���ӎ����擾 fncSetData_TAIOU
    '**********************************************************
    Private Function fncGetFAXKBN_GUIDE_TAIOU() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        'Dim strRes(2) As String      '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        'For i As Integer = 0 To 2
        Dim strRes(4) As String       '2019/11/01 W.GANEKO 2019�Ď����P No8-12
        For i As Integer = 0 To 4     '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strRes(i) = ""
        Next

        Try
            strSQL = New StringBuilder("")
            '2016/02/02 w.ganeko 2015�J�����P ��1 start
            'strSQL.Append("WITH ")
            'strSQL.Append("A AS( ")
            'strSQL.Append("SELECT B.KURACD, B.FAXKBN, B.FAXKURAKBN, B.GUIDELINE, B.USER_CD_FROM ")
            'strSQL.Append("FROM   D20_TAIOU A, ")
            'strSQL.Append("       M05_TANTO2 B ")
            'strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            'strSQL.Append("AND    A.SYONO = :SYONO ")
            'strSQL.Append("AND    B.KURACD = A.KURACD ")
            'strSQL.Append("AND    B.CODE = A.ACBCD ")
            'strSQL.Append("AND    KBN = '3' ")
            'strSQL.Append("AND    LPAD(B.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND	    B.USER_CD_TO IS NULL ")
            'strSQL.Append("AND	    A.USER_CD =  B.USER_CD_FROM  ")
            'strSQL.Append("), ")
            'strSQL.Append("B AS( ")
            'strSQL.Append("SELECT B.KURACD, B.FAXKBN, B.FAXKURAKBN, B.GUIDELINE, B.USER_CD_FROM ")
            'strSQL.Append("FROM   D20_TAIOU A, ")
            'strSQL.Append("       M05_TANTO2 B ")
            'strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            'strSQL.Append("AND    A.SYONO = :SYONO ")
            'strSQL.Append("AND    B.KURACD = A.KURACD ")
            'strSQL.Append("AND    B.CODE = A.ACBCD ")
            'strSQL.Append("AND    KBN = '3' ")
            'strSQL.Append("AND    LPAD(B.TANCD, 2, '0') = '01' ")
            'strSQL.Append("AND	    B.USER_CD_TO IS NULL ")
            'strSQL.Append("AND	    A.USER_CD =  B.USER_CD_FROM  ")
            'strSQL.Append("), ")
            'strSQL.Append("C AS( ")
            'strSQL.Append("SELECT B.KURACD, B.FAXKBN, B.FAXKURAKBN, B.GUIDELINE ")
            'strSQL.Append("FROM   D20_TAIOU A, ")
            'strSQL.Append("       M05_TANTO B ")
            'strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            'strSQL.Append("AND    A.SYONO = :SYONO ")
            'strSQL.Append("AND    B.KURACD = A.KURACD ")
            'strSQL.Append("AND    B.CODE = A.ACBCD ")
            'strSQL.Append("AND    KBN = '3' ")
            'strSQL.Append("AND    LPAD(B.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            'strSQL.Append("D AS( ")
            'strSQL.Append("SELECT B.KURACD, B.FAXKBN, B.FAXKURAKBN, B.GUIDELINE ")
            'strSQL.Append("FROM   D20_TAIOU A, ")
            'strSQL.Append("       M05_TANTO B ")
            'strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            'strSQL.Append("AND    A.SYONO = :SYONO ")
            'strSQL.Append("AND    B.KURACD = A.KURACD ")
            'strSQL.Append("AND    B.CODE = A.JACD ")
            'strSQL.Append("AND    KBN = '3' ")
            'strSQL.Append("AND    LPAD(B.TANCD, 2, '0') = '01' ")
            'strSQL.Append("), ")
            ''2015/02/19 T.Ono add 2014���P�J�� No15
            ''KEIHOU,KOKYAKU�ɂ̓N���C�A���g�̌�����ǉ��������ATAIOU�͕񍐗v�E�s�v�敪�͎g�p���Ȃ����߁A�ǉ����Ȃ��B
            strSQL.Append("WITH ")
            strSQL.Append("/* ���q�l�� */ ")
            strSQL.Append("A AS( ")
            strSQL.Append("SELECT T.KURACD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12 
            strSQL.Append(",D.GUIDELINE3 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12 
            strSQL.Append("FROM   D20_TAIOU A, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            strSQL.Append("AND    A.SYONO = :SYONO ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    A.KURACD = T.KURACD ")
            strSQL.Append("AND    A.ACBCD = T.ACBCD ")
            strSQL.Append("AND    A.USER_CD = T.USERCD_FROM ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("), ")
            strSQL.Append("/* ���q�l�͈� */ ")
            strSQL.Append("B AS ( ")
            strSQL.Append("SELECT T.KURACD, T.USERCD_FROM, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12 
            strSQL.Append(",D.GUIDELINE3 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   D20_TAIOU A, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            strSQL.Append("AND    A.SYONO = :SYONO ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    A.KURACD = T.KURACD ")
            strSQL.Append("AND    A.ACBCD = T.ACBCD ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_TO IS NOT NULL ")
            strSQL.Append("AND    A.USER_CD BETWEEN T.USERCD_FROM AND T.USERCD_TO ")
            strSQL.Append("), ")
            strSQL.Append("/* JA�x�� */ ")
            strSQL.Append("C AS( ")
            strSQL.Append("SELECT T.KURACD, D.FAXKBN, D.FAXKURAKBN, D.GUIDELINE ")
            strSQL.Append(",D.GUIDELINE2 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12 
            strSQL.Append(",D.GUIDELINE3 ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            strSQL.Append("FROM   D20_TAIOU A, ")
            strSQL.Append("       M09_JAGROUP T, ")
            strSQL.Append("       M11_JAHOKOKU D ")
            strSQL.Append("WHERE  A.KANSCD = :KANSCD ")
            strSQL.Append("AND    A.SYONO = :SYONO ")
            strSQL.Append("AND    T.KBN = '002' ")
            strSQL.Append("AND    A.KURACD = T.KURACD ")
            strSQL.Append("AND    A.ACBCD = T.ACBCD ")
            strSQL.Append("AND    D.KBN = '2' ")
            strSQL.Append("AND    T.GROUPCD = D.GROUPCD ")
            strSQL.Append("AND    LPAD(D.TANCD, 2, '0') = '01' ")
            strSQL.Append("AND    T.USERCD_FROM IS NULL ")
            strSQL.Append("AND    T.USERCD_TO IS NULL ")
            strSQL.Append("), ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 end
            strSQL.Append("E AS ( ")
            strSQL.Append("SELECT KURACD ")
            strSQL.Append("FROM   D20_TAIOU ")
            strSQL.Append("WHERE  KANSCD = :KANSCD ")
            strSQL.Append("AND    SYONO = :SYONO ")
            strSQL.Append(") ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 START
            'strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, NVL(D.FAXKBN, '0')))) AS FAXKBN, ")
            'strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, NVL(D.FAXKURAKBN, '0')))) AS FAXKURAKBN, ")
            'strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, NVL(D.GUIDELINE, '')))) AS GUIDELINE, ")
            'strSQL.Append("       NVL(A.USER_CD_FROM, NVL(B.USER_CD_FROM, '')) AS USER_CD_FROM ")
            'strSQL.Append("FROM A, B, C, D, E ")
            'strSQL.Append("WHERE  E.KURACD = A.KURACD(+) ")
            'strSQL.Append("AND    E.KURACD = B.KURACD(+) ")
            'strSQL.Append("AND    E.KURACD = C.KURACD(+) ")
            'strSQL.Append("AND    E.KURACD = D.KURACD(+) ")
            strSQL.Append("SELECT NVL(A.FAXKBN, NVL(B.FAXKBN, NVL(C.FAXKBN, '0'))) AS FAXKBN, ")
            strSQL.Append("       NVL(A.FAXKURAKBN, NVL(B.FAXKURAKBN, NVL(C.FAXKURAKBN, '0'))) AS FAXKURAKBN, ")
            strSQL.Append("       NVL(A.GUIDELINE, NVL(B.GUIDELINE, NVL(C.GUIDELINE, ''))) AS GUIDELINE, ")
            strSQL.Append("       NVL(A.GUIDELINE2, NVL(B.GUIDELINE2, NVL(C.GUIDELINE2, ''))) AS GUIDELINE2, ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12 
            strSQL.Append("       NVL(A.GUIDELINE3, NVL(B.GUIDELINE3, NVL(C.GUIDELINE3, ''))) AS GUIDELINE3, ")   '2019/11/01 W.GANEKO 2019�Ď����P No8-12 
            strSQL.Append("       NVL(A.USERCD_FROM, NVL(B.USERCD_FROM, '')) AS USER_CD_FROM ")
            strSQL.Append("FROM A, B, C, E ")
            strSQL.Append("WHERE  E.KURACD = A.KURACD(+) ")
            strSQL.Append("AND    E.KURACD = B.KURACD(+) ")
            strSQL.Append("AND    E.KURACD = C.KURACD(+) ")
            '2016/02/02 w.ganeko 2015�J�����P ��1 end

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("KANSCD", True, hdnKEY_KANSCD.Value)
            SqlParamC.fncSetParam("SYONO", True, hdnKEY_SYONO.Value)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�Ȃ��̏ꍇ
                strRes(0) = "0"
                strRes(1) = "0"
                strRes(2) = ""
                strRes(3) = ""     '2019/11/01 W.GANEKO 2019�Ď����P No8-12
                strRes(4) = ""     '2019/11/01 W.GANEKO 2019�Ď����P No8-12
            Else
                '�f�[�^����̏ꍇ
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKBN"))
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("FAXKURAKBN"))
                strRes(2) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE"))
                strRes(3) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE2")) '2019/11/01 W.GANEKO 2019�Ď����P No8-12 
                strRes(4) = Convert.ToString(dbData.Tables(0).Rows(0).Item("GUIDELINE3")) '2019/11/01 W.GANEKO 2019�Ď����P No8-12 
                hdnUSER_CD_FROM.Value = Convert.ToString(dbData.Tables(0).Rows(0).Item("USER_CD_FROM"))
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            For i As Integer = 0 To 2
                strRes(i) = ""
            Next

        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

    '**********************************************************
    ' 2013/08/20 T.Ono add �Ď����P2013��1
    '�x�񃁃b�Z�[�W�̓���ւ�
    '**********************************************************
    Private Sub fncSetMessage()

        If rdoMsg1.Checked = True Then
            gstrKMCD1 = hdnKMCD1.Value
            gstrKMNM1 = hdnKMNM1.Value
            gstrKMCD2 = hdnKMCD2.Value
            gstrKMNM2 = hdnKMNM2.Value
            gstrKMCD3 = hdnKMCD3.Value
            gstrKMNM3 = hdnKMNM3.Value
            gstrKMCD4 = hdnKMCD4.Value
            gstrKMNM4 = hdnKMNM4.Value
            gstrKMCD5 = hdnKMCD5.Value
            gstrKMNM5 = hdnKMNM5.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg2.Checked Then
            gstrKMCD1 = hdnKMCD2.Value
            gstrKMNM1 = hdnKMNM2.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD3.Value
            gstrKMNM3 = hdnKMNM3.Value
            gstrKMCD4 = hdnKMCD4.Value
            gstrKMNM4 = hdnKMNM4.Value
            gstrKMCD5 = hdnKMCD5.Value
            gstrKMNM5 = hdnKMNM5.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg3.Checked Then
            gstrKMCD1 = hdnKMCD3.Value
            gstrKMNM1 = hdnKMNM3.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD2.Value
            gstrKMNM3 = hdnKMNM2.Value
            gstrKMCD4 = hdnKMCD4.Value
            gstrKMNM4 = hdnKMNM4.Value
            gstrKMCD5 = hdnKMCD5.Value
            gstrKMNM5 = hdnKMNM5.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg4.Checked Then
            gstrKMCD1 = hdnKMCD4.Value
            gstrKMNM1 = hdnKMNM4.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD2.Value
            gstrKMNM3 = hdnKMNM2.Value
            gstrKMCD4 = hdnKMCD3.Value
            gstrKMNM4 = hdnKMNM3.Value
            gstrKMCD5 = hdnKMCD5.Value
            gstrKMNM5 = hdnKMNM5.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg5.Checked Then
            gstrKMCD1 = hdnKMCD5.Value
            gstrKMNM1 = hdnKMNM5.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD2.Value
            gstrKMNM3 = hdnKMNM2.Value
            gstrKMCD4 = hdnKMCD3.Value
            gstrKMNM4 = hdnKMNM3.Value
            gstrKMCD5 = hdnKMCD4.Value
            gstrKMNM5 = hdnKMNM4.Value
            gstrKMCD6 = hdnKMCD6.Value
            gstrKMNM6 = hdnKMNM6.Value
        ElseIf rdoMsg6.Checked Then
            gstrKMCD1 = hdnKMCD6.Value
            gstrKMNM1 = hdnKMNM6.Value
            gstrKMCD2 = hdnKMCD1.Value
            gstrKMNM2 = hdnKMNM1.Value
            gstrKMCD3 = hdnKMCD2.Value
            gstrKMNM3 = hdnKMNM2.Value
            gstrKMCD4 = hdnKMCD3.Value
            gstrKMNM4 = hdnKMNM3.Value
            gstrKMCD5 = hdnKMCD4.Value
            gstrKMNM5 = hdnKMNM4.Value
            gstrKMCD6 = hdnKMCD5.Value
            gstrKMNM6 = hdnKMNM5.Value
        End If
    End Sub

    '**********************************************************
    ' 2014/02/10 T.Ono add �Ď����P2013 �d���\��
    '�����Ή����e�}�X�^���A�����I�ɏd���ƕ\������
    '**********************************************************
    Private Function fncChoufukuHyouji() As KETAIJAG00DTO.AutoTaiouDto
        Dim res As New KETAIJAG00DTO.AutoTaiouDto
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim dbKeiho As DataSet '2014/06/23 T.Ono add �d���\���G���[�Ή�

        Dim kmdto As KETAIJAG00DTO.KmDto
        Dim kmList As ArrayList
        Dim autoTaiouList As KETAIJAG00DTO.AutoTaiouLists

        Try
            '*-----------------------------------------------------*
            ' �x��ɏd���\���̑Ώ������邩
            '*-----------------------------------------------------*
            strSQL = New StringBuilder("")
            strSQL.Append(getSqlExistsChoufukuHyouji())
            '//SQL�̎��s
            '2014/06/23 T.Ono mod START �d���\���G���[�@�����̎擾����(�x��f�[�^)�͌�Ŏg���̂ŕʂ̕ϐ��Ɋi�[
            'dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            'If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            '    '������Δ�����
            '    Return res
            'End If

            ''*-----------------------------------------------------*
            '' �x�񃁃b�Z�[�W���X�g�쐬
            ''*-----------------------------------------------------*
            'kmList = New ArrayList
            'For intLoop As Integer = 1 To 6
            '    '�x�񃁃b�Z�[�W���Z�o����
            '    If Convert.ToString(dbData.Tables(0).Rows(0).Item("KMCD" & intLoop)) <> "" Then
            '        '�l�������Ă���Όx�񃁃b�Z�[�W�����X�g�ɃZ�b�g
            '        kmdto = New KETAIJAG00DTO.KmDto( _
            '                        Convert.ToString(dbData.Tables(0).Rows(0).Item("KMCD" & intLoop)) _
            '                        , Convert.ToString(dbData.Tables(0).Rows(0).Item("KMNM" & intLoop)))
            '        kmList.Add(kmdto)
            '    End If
            'Next
            dbKeiho = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            If Convert.ToString(dbKeiho.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '������Δ�����
                Return res
            End If

            '*-----------------------------------------------------*
            ' �x�񃁃b�Z�[�W���X�g�쐬
            '*-----------------------------------------------------*
            kmList = New ArrayList
            For intLoop As Integer = 1 To 6
                '�x�񃁃b�Z�[�W���Z�o����
                If Convert.ToString(dbKeiho.Tables(0).Rows(0).Item("KMCD" & intLoop)) <> "" Then
                    '�l�������Ă���Όx�񃁃b�Z�[�W�����X�g�ɃZ�b�g
                    kmdto = New KETAIJAG00DTO.KmDto( _
                                    Convert.ToString(dbKeiho.Tables(0).Rows(0).Item("KMCD" & intLoop)) _
                                    , Convert.ToString(dbKeiho.Tables(0).Rows(0).Item("KMNM" & intLoop)))
                    kmList.Add(kmdto)
                End If
            Next
            '2014/06/23 T.Ono mod END �d���\���G���[

            '*-----------------------------------------------------*
            ' 2.�����Ή����e���X�g�쐬
            '*-----------------------------------------------------*
            strSQL = New StringBuilder("")
            strSQL.Append(getSqlAutoTaiouList())
            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If (dbData.Tables(0).Rows.Count = 0) Then
                '������Δ�����
                Return res
            End If

            '*-----------------------------------------------------*
            ' 2-2.�����Ή����e���X�g���A�����Ή��A�����A�d���\�����ƂɃ��X�g��
            '*-----------------------------------------------------*
            autoTaiouList = New KETAIJAG00DTO.AutoTaiouLists(dbData.Tables(0))


            '�������X�g�̃`�F�b�N
            For Each atDto As KETAIJAG00DTO.AutoTaiouDto In CType(autoTaiouList.procListByIgnore, ArrayList)
                If atDto.prockbn.ToString = "2" AndAlso isExists(kmList, CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)) > -1 Then
                    '*-----------------------------------------------------*
                    ' 3.�����Ή����e.�Ή��E�����敪="2"�́A�x�񃁃b�Z�[�W���X�g����폜
                    '*-----------------------------------------------------*
                    kmList.RemoveAt(isExists(kmList, CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)))

                ElseIf atDto.prockbn.ToString = "3" Then
                    '*-----------------------------------------------------*
                    ' 4.�Ή��E�����敪��"3"�����ɐݒ肳��Ă���ꍇ�́A�Z�L�����e�B���e�[�u�����m�F
                    '*-----------------------------------------------------*
                    If isExists(kmList, CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)) > -1 Then
                        '*-----------------------------------------------------*
                        ' 4-1.�Z�L�����e�B���e�[�u�����Q�Ƃ���
                        '     �����F�N���C�A���g�R�[�h, JA�x���R�[�h, �ڋq�R�[�h
                        '*-----------------------------------------------------*
                        Dim seqSql As New StringBuilder
                        'Dim bExex As Boolean = getSqlSecurityInfo(seqSql, dbData.Tables(0).Rows(0), Convert.ToString(CType(atDto.pkmDto, KETAIJAG00DTO.KmDto).KmCd)) 2014/06/23 T.Ono mod �d���\���G���[
                        Dim bExex As Boolean = getSqlSecurityInfo(seqSql, dbKeiho.Tables(0).Rows(0), Convert.ToString(CType(atDto.pkmDto, KETAIJAG00DTO.KmDto).KmCd))

                        If bExex Then
                            strSQL = New StringBuilder("")
                            strSQL.Append(seqSql.ToString)
                            '//SQL�̎��s
                            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
                        Else
                            Return res
                        End If
                        '*-----------------------------------------------------*
                        ' 4-2.�擾�ł��Ȃ��ꍇ�A�d���\���͍s��Ȃ�
                        '*-----------------------------------------------------*
                        'If (dbData.Tables(0).Rows.Count = 0) Then 2014/06/23 T.Ono mod �d���\���G���[
                        If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                            Return res
                        End If

                        '*-----------------------------------------------------*
                        ' 4-3.�o�͗L���t���O���o�͂���̏ꍇ�A�d���\���͍s��Ȃ�
                        '*-----------------------------------------------------*
                        For intSec As Integer = 0 To dbData.Tables(0).Rows.Count - 1
                            If "1".Equals(Convert.ToString(dbData.Tables(0).Rows(0).Item("OUT_FLG"))) Then
                                Return res
                            End If
                        Next
                        kmList.RemoveAt(isExists(kmList, CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)))
                    End If
                End If
            Next

            '*-----------------------------------------------------*
            ' 5.���X�g�A�b�v�����x��R�[�h���珜�O�������ʁA�f�[�^��
            '   ���݂��Ă��Ȃ��A�܂��͂ЂƂɍi��Ȃ��ꍇ�́A�d���\���͍s��Ȃ�
            '*-----------------------------------------------------*
            If kmList.Count <> 1 Then
                Return res
            End If

            '*-----------------------------------------------------*
            ' 6.���X�g�A�b�v�����x��R�[�h�ƌx�񖼏̂����ɁA
            '   �����Ή����e�e�[�u������d���\�����s���f�[�^�𒊏o����B
            '*-----------------------------------------------------*
            For Each atDto As KETAIJAG00DTO.AutoTaiouDto In CType(autoTaiouList.procListByChoufuku, ArrayList)
                If CType(kmList(0), KETAIJAG00DTO.KmDto).isEquals _
                                                            (CType(atDto.pkmDto, KETAIJAG00DTO.KmDto)) Then
                    res = atDto
                    Return res
                End If
            Next

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
            '2014/06/23 T.Ono mod �d���\���G���[
            If dbKeiho Is Nothing Then
            Else
                dbKeiho.Dispose()
            End If
        End Try

        Return res
    End Function
    '************************************************
    '2014/02/10 T.Ono add �Ď����P2013
    ' �d���\�����s���Ώۂ̃f�[�^�擾SQL
    '************************************************
    Private Function getSqlExistsChoufukuHyouji() As String

        Dim strSQL As StringBuilder = New StringBuilder
        '+----------------------------------------------------+
        '|�d���\�����s���Ώۂ̃f�[�^�̎擾����SQL
        '+----------------------------------------------------+
        strSQL.Append("SELECT ")
        strSQL.Append("  KEI.SYORI_SERIAL ")
        strSQL.Append("  ,KEI.REACTION ")
        strSQL.Append("  ,KEI.KANSCD ")
        strSQL.Append("  ,KEI.KURACD ")
        strSQL.Append("  ,KEI.ACBCD ")
        strSQL.Append("  ,KEI.JUYOKA ")
        strSQL.Append("  ,KEI.KMCD1 ")
        strSQL.Append("  ,KEI.KMNM1 ")
        strSQL.Append("  ,KEI.KMCD2 ")
        strSQL.Append("  ,KEI.KMNM2 ")
        strSQL.Append("  ,KEI.KMCD3 ")
        strSQL.Append("  ,KEI.KMNM3 ")
        strSQL.Append("  ,KEI.KMCD4 ")
        strSQL.Append("  ,KEI.KMNM4 ")
        strSQL.Append("  ,KEI.KMCD5 ")
        strSQL.Append("  ,KEI.KMNM5 ")
        strSQL.Append("  ,KEI.KMCD6 ")
        strSQL.Append("  ,KEI.KMNM6 ")
        strSQL.Append("FROM ")
        strSQL.Append("  T10_KEIHO KEI ")
        strSQL.Append("WHERE ")
        strSQL.Append("  KEI.SYORI_SERIAL = '" & hdnKEY_SERIAL.Value & "' ")
        '2017/02/09 W.GANEKO UPD START 2016�Ď����P ��10
        strSQL.Append("  AND EXISTS (SELECT ")
        strSQL.Append("                'X' ")
        strSQL.Append("              FROM ")
        strSQL.Append("                M09_JAGROUP JAGRP ")
        strSQL.Append("                ,M08_AUTOTAIOU ATTAI ")
        strSQL.Append("              WHERE ")
        strSQL.Append("                JAGRP.KBN = '003' ")
        strSQL.Append("                AND JAGRP.KURACD = KEI.KURACD ")
        strSQL.Append("                AND JAGRP.ACBCD = KEI.ACBCD ")
        strSQL.Append("                AND JAGRP.GROUPCD = ATTAI.GROUPCD ")
        strSQL.Append("                AND ATTAI.USE_FLG = '1' ")
        strSQL.Append("                AND ATTAI.PROCKBN = '4' ")
        strSQL.Append("                AND ATTAI.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        strSQL.Append("              ) ")
        'strSQL.Append("  AND EXISTS (SELECT ")
        'strSQL.Append("                'X' ")
        'strSQL.Append("              FROM ")
        'strSQL.Append("                M07_AUTOTAIOUGROUP ATTAIGRP ")
        'strSQL.Append("                ,M08_AUTOTAIOU ATTAI ")
        'strSQL.Append("              WHERE ")
        'strSQL.Append("                ATTAIGRP.KURACD = KEI.KURACD ")
        'strSQL.Append("                AND ATTAIGRP.ACBCD = KEI.ACBCD ")
        'strSQL.Append("                AND ATTAIGRP.USE_FLG = '1' ")
        'strSQL.Append("                AND ATTAIGRP.GROUPCD = ATTAI.GROUPCD ")
        'strSQL.Append("                AND ATTAI.USE_FLG = '1' ")
        'strSQL.Append("                AND ATTAI.PROCKBN = '4' ")
        'strSQL.Append("                AND ATTAI.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        'strSQL.Append("              ) ")
        '2017/02/09 W.GANEKO UPD END 2016�Ď����P ��10

        Return strSQL.ToString

    End Function

    '************************************************
    '2014/02/10 T.Ono add �Ď����P2013
    ' �����Ή����e�̃��X�g���擾SQL
    '************************************************
    Private Function getSqlAutoTaiouList() As String
        Dim strSQL As StringBuilder = New StringBuilder
        '+----------------------------------------------------+
        '|�����Ή����e�̃��X�g���擾����SQL
        '+----------------------------------------------------+
        strSQL.Append("WITH TN AS ") '�Ď��Z���^�[�S���҂̈ꗗ
        strSQL.Append("	(SELECT ")
        strSQL.Append("	        A.CODE ")
        strSQL.Append("		    ,A.TANCD ")
        strSQL.Append("		    ,A.TANNM ")
        strSQL.Append("	FROM	M05_TANTO A ")
        strSQL.Append("		    ,T10_KEIHO B ")
        strSQL.Append("	WHERE ")
        strSQL.Append("		    B.SYORI_SERIAL = '" & hdnKEY_SERIAL.Value & "' ")
        strSQL.Append("	AND	    B.KANSCD = A.CODE ")
        strSQL.Append("	AND     A.KBN = '1' ") '2016/02/24 T.Ono add �敪�w�肵�A��̫��ݽ����
        strSQL.Append("	    ) ")
        strSQL.Append("SELECT ")
        strSQL.Append("	    AN.GROUPCD ")
        strSQL.Append("	    ,AN.KMCD ")
        strSQL.Append("	    ,AN.KMNM ")
        strSQL.Append("	    ,AN.PROCKBN ")
        strSQL.Append("	    ,AN.TAIOKBN ")
        strSQL.Append("	    ,AN.TMSKB ")
        strSQL.Append("	    ,AN.TKTANCD ")
        strSQL.Append("	    ,AN.TAITCD ")
        strSQL.Append("	    ,AN.TFKICD ")
        strSQL.Append("	    ,AN.TKIGCD ")
        strSQL.Append("	    ,AN.TSADCD ")
        strSQL.Append("	    ,AN.TELRCD ")
        strSQL.Append("	    ,AN.TEL_MEMO1 ")
        strSQL.Append("	    ,AN.USE_FLG ")
        strSQL.Append("	    ,AN.INS_DATE ")
        strSQL.Append("	    ,AN.UPD_DATE ")
        strSQL.Append("	    ,TN.TANNM ")
        strSQL.Append("FROM ")
        strSQL.Append(" 	T10_KEIHO KEI ")
        '2017/02/09 W.GANEKO UPD START 2016�Ď����P ��10
        strSQL.Append("	    ,M09_JAGROUP JA ")
        strSQL.Append("	    ,M08_AUTOTAIOU AN ")
        strSQL.Append("	    ,TN ")
        strSQL.Append("WHERE ")
        strSQL.Append(" 	KEI.SYORI_SERIAL = '" & hdnKEY_SERIAL.Value & "' ")
        strSQL.Append("AND	KEI.KURACD = JA.KURACD ")
        strSQL.Append("AND	KEI.ACBCD = JA.ACBCD ")
        strSQL.Append("AND	JA.KBN = '003' ")
        strSQL.Append("AND	JA.GROUPCD = AN.GROUPCD ")
        strSQL.Append("AND	AN.USE_FLG = '1' ")
        strSQL.Append("AND	AN.TKTANCD = TN.TANCD(+) ")
        strSQL.Append("AND  EXISTS ") '�d���\���̑Ώیx�񂪂��邩
        strSQL.Append("     (SELECT	'X' ")
        strSQL.Append("     FROM ")
        strSQL.Append("     	    M08_AUTOTAIOU AN2 ")
        strSQL.Append("     WHERE ")
        strSQL.Append("     	    KEI.KURACD = JA.KURACD ")
        strSQL.Append("     AND	    KEI.ACBCD = JA.ACBCD ")
        strSQL.Append("     AND     JA.KBN = '003' ")
        strSQL.Append("     AND	    JA.GROUPCD = AN2.GROUPCD ")
        strSQL.Append("     AND	    AN2.PROCKBN = '4' ")
        strSQL.Append("     AND	    AN2.USE_FLG = '1' ")
        strSQL.Append("     AND	    AN2.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        strSQL.Append("	) ")
        strSQL.Append("ORDER BY AN.PROCKBN ")
        'strSQL.Append("	    ,M07_AUTOTAIOUGROUP AG ")
        'strSQL.Append("	    ,M08_AUTOTAIOU AN ")
        'strSQL.Append("	    ,TN ")
        'strSQL.Append("WHERE ")
        'strSQL.Append(" 	KEI.SYORI_SERIAL = '" & hdnKEY_SERIAL.Value & "' ")
        'strSQL.Append("AND	KEI.KURACD = AG.KURACD ")
        'strSQL.Append("AND	KEI.ACBCD = AG.ACBCD ")
        'strSQL.Append("AND	AG.USE_FLG = '1' ")
        'strSQL.Append("AND	AG.GROUPCD = AN.GROUPCD ")
        'strSQL.Append("AND	AN.USE_FLG = '1' ")
        'strSQL.Append("AND	AN.TKTANCD = TN.TANCD(+) ")
        'strSQL.Append("AND  EXISTS ") '�d���\���̑Ώیx�񂪂��邩
        'strSQL.Append("     (SELECT	'X' ")
        'strSQL.Append("     FROM ")
        'strSQL.Append("     	    M08_AUTOTAIOU AN2 ")
        'strSQL.Append("     WHERE ")
        'strSQL.Append("     	    KEI.KURACD = AG.KURACD ")
        'strSQL.Append("     AND	    KEI.ACBCD = AG.ACBCD ")
        'strSQL.Append("     AND	    AG.USE_FLG = '1' ")
        'strSQL.Append("     AND	    AG.GROUPCD = AN2.GROUPCD ")
        'strSQL.Append("     AND	    AN2.PROCKBN = '4' ")
        'strSQL.Append("     AND	    AN2.USE_FLG = '1' ")
        'strSQL.Append("     AND	    AN2.KMCD IN (KEI.KMCD1, KEI.KMCD2, KEI.KMCD3, KEI.KMCD4, KEI.KMCD5, KEI.KMCD6) ")
        'strSQL.Append("	) ")
        'strSQL.Append("ORDER BY AN.PROCKBN ")
        '2017/02/09 W.GANEKO UPD END 2016�Ď����P ��10

        Return strSQL.ToString

    End Function

    '********************************************************
    '2014/02/10 T.Ono add �Ď����P2013
    '�Z�L�����e�B��񒊏oSQL����
    '********************************************************
    Private Function getSqlSecurityInfo(ByRef sql As StringBuilder, ByVal row As DataRow, ByVal kmcd As String) As Boolean
        Dim KM_ZAN1 As String = "29" '�x���F�c�ʌx���P
        Dim KM_ZAN2 As String = "28" '�x���F�c�ʌx���Q
        Dim KM_ZAN3 As String = "27" '�x���F�c�ʌx���R
        '��L�ȊO�̌x��R�[�h�ȊO�́A�Z�L�����e�B�������Ă��Ȃ��c

        sql.Append("SELECT ")
        sql.Append("  CLI_CD ")
        sql.Append("  ,HAN_CD ")
        sql.Append("  ,USER_CD ")
        sql.Append("  ,OUT_FLG ")
        sql.Append("  ,SEQMSG ")
        sql.Append("FROM ")
        sql.Append("  SQIMAS ")
        sql.Append("WHERE ")
        sql.Append("  CLI_CD = '" & Convert.ToString(row.Item("KURACD")) & "' ")
        sql.Append("  AND (HAN_CD = '" & Convert.ToString(row.Item("ACBCD")) & "' OR NOT REGEXP_LIKE(HAN_CD, '[0-9]')) ")
        sql.Append("  AND (USER_CD = '" & Convert.ToString(row.Item("JUYOKA")) & "' OR NOT REGEXP_LIKE(USER_CD, '[0-9]')) ")

        Select Case kmcd
            Case KM_ZAN3
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '06' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___4___' ")
            Case KM_ZAN2
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '07' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___2___' ")
            Case KM_ZAN1
                sql.Append("  AND SEQ_GRP1 = '2' ")
                sql.Append("  AND SEQ_GRP2 = '08' ")
                sql.Append("  AND SEQ_GRP3 = '020' ")
                sql.Append("  AND ID_BYTE  = '3' ")
                sql.Append("  AND SEQ_BYTE1_1 = '20' ")
                sql.Append("  AND SEQ_CD1_1   = '2---0' ")
                sql.Append("  AND SEQ_BYTE1_2 = '25' ")
                sql.Append("  AND SEQ_CD1_2 LIKE '___1___' ")
            Case Else
                '���̃��R�[�h��
                Return False
        End Select

        sql.Append("ORDER BY ")
        sql.Append("  USER_CD DESC ")
        sql.Append("  ,HAN_CD DESC ")

        Return True
    End Function

    '2014/02/10 T.Ono add �Ď����P2013
    Private Function isExists(ByVal list As ArrayList, ByVal kmDto As KETAIJAG00DTO.KmDto) As Integer
        Dim i As Integer = 0
        For Each dto As KETAIJAG00DTO.KmDto In list
            If dto.isEquals(kmDto) Then
                Return i
            End If
            i = i + 1
        Next
        Return -1
    End Function
    '**********************************************************
    ' 2016/02/02 W.GANEKO 2015�Ď����P ��1
    'SHAMAS�擾
    '**********************************************************
    Private Function fncGetSHAMAS() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        Dim strRes(9) As String
        'For i As Integer = 0 To 5  2016/12/12 H.Mori Mod 2016���P�J�� No5-1
        For i As Integer = 0 To 8
            strRes(i) = ""
        Next

        Try
            strSQL = New StringBuilder("")

            strSQL.Append("SELECT ")
            strSQL.Append(" * ")                                     '//���b�N�t���O
            strSQL.Append("FROM ")
            strSQL.Append("SHAMAS ")                                 '//�x��c�a
            strSQL.Append("WHERE ")
            strSQL.Append("CLI_CD = :CLI_CD ")
            strSQL.Append("AND HAN_CD = :HAN_CD ")
            strSQL.Append("AND USER_CD = :USER_CD ")
            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("CLI_CD", True, txtClientCD.Text)
            SqlParamC.fncSetParam("HAN_CD", True, hdnJASCD.Value)
            SqlParamC.fncSetParam("USER_CD", True, txtJUYOKA.Text)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�Ȃ��̏ꍇ
            Else
                '�f�[�^����̏ꍇ
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL2"))
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL2_BIKO"))
                strRes(2) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL2_UPD_DATE"))
                strRes(3) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL3"))
                strRes(4) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL3_BIKO"))
                strRes(5) = Convert.ToString(dbData.Tables(0).Rows(0).Item("RENTEL3_UPD_DATE"))
                '2016/12/12 H.Mori add 2016���P�J�� No5-1 START
                strRes(6) = Convert.ToString(dbData.Tables(0).Rows(0).Item("TELA"))
                strRes(7) = Convert.ToString(dbData.Tables(0).Rows(0).Item("TELB"))
                strRes(8) = Convert.ToString(dbData.Tables(0).Rows(0).Item("DAI3RENDORENTEL"))
                '2016/12/12 H.Mori add 2016���P�J�� No5-1 END
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
            'For i As Integer = 0 To 5  2016/12/12 H.Mori Mod 2016���P�J�� No5-1
            For i As Integer = 0 To 8
                strRes(i) = ""
            Next
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function
    ' 2016/02/02 W.GANEKO 2015�Ď����P ��1�@END

    '**********************************************************
    '  �Ď��Z���^�[�S���ҏ����擾����
    '  2020/11/01 T.Ono add 2020�Ď����P
    '**********************************************************
    Private Function fncGetTANInfo() As String()
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet
        Dim strRes() As String = {"", ""}

        Try
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("       TANCD ")
            strSQL.Append("       ,TANNM ")
            strSQL.Append("FROM   M05_TANTO ")
            strSQL.Append("WHERE  KBN = '1' ")
            strSQL.Append("AND    GUIDELINE = :TANID ")    'GUIDELINE�S����ID���i�[����Ă�
            If hdnKANSCD.Value.Trim <> "" Then
                strSQL.Append("AND    CODE = :KANSCD ")
                SqlParamC.fncSetParam("KANSCD", True, hdnKANSCD.Value)
            End If

            '�p�����[�^�̃Z�b�g
            SqlParamC.fncSetParam("TANID", True, AuthC.pUSERNAME)

            '//SQL�̎��s
            dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

            If Convert.ToString(dbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
                '�f�[�^�Ȃ��̏ꍇ
            Else
                '�f�[�^����̏ꍇ
                strRes(0) = Convert.ToString(dbData.Tables(0).Rows(0).Item("TANCD"))  '�S����CD
                strRes(1) = Convert.ToString(dbData.Tables(0).Rows(0).Item("TANNM"))  '�S���Җ�
            End If

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")
        Finally
            If dbData Is Nothing Then
            Else
                dbData.Dispose()
            End If
        End Try

        Return strRes
    End Function

End Class
