' ------------------------------------------------------------
' �ύX����
' 2009/02/13 T.Watabe del �S���҂̍X�V�͂��Ȃ��悤�ɕύX
' 2010/07/12 T.Watabe add DB���ڂ�FAX�Ή��敪(�ײ���)��ǉ�
' 2012/03/30 W.Ganeko add 8���ԓ��̑Ή��̏ꍇ�A�d�������œo�^
' 2023/01/13 Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 
' ------------------------------------------------------------
Option Explicit On
Option Strict On

Imports Common.DB
Imports Common

Imports System.Web.Services
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Configuration


<System.Web.Services.WebService(Namespace:="http://tempuri.org/KETAIJAW00/Service1")> _
Public Class KETAIJAW00
    Inherits System.Web.Services.WebService

#Region " Web �T�[�r�X �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        '���̌Ăяo���� Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɓƎ��̏������R�[�h��ǉ����Ă��������B

    End Sub

    'Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    '���� : �ȉ��̃v���V�[�W���́AWeb �T�[�r�X �f�U�C�i�ŕK�v�ł��B
    'Web �T�[�r�X �f�U�C�i���g���ĕύX���邱�Ƃ��ł��܂��B  
    '�R�[�h �G�f�B�^�ɂ��ύX�͍s��Ȃ��ł��������B
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: ���̃v���V�[�W���� Web �T�[�r�X �f�U�C�i�ŕK�v�ł��B
        '�R�[�h �G�f�B�^�ɂ��ύX�͍s��Ȃ��ł��������B
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    '���S�_�x���R�[�h(1Byte)�{���R�[�h(2Byte)�{�A��(2Byte) �� �o�ϘA�R�[�h �� �N���C�A���g�R�[�h
    '************************************************
    '�Ή�DB�̓o�^�A�C�����s���܂�
    '�d�b���M�̃��O���������݂܂�
    '���ꂼ��̍��ڂ��J���}��؂�Ŏ擾�\�Ȃ̂ŁA
    '�������P���P��DB��INSERT���܂�
    '************************************************
    '��2005/09/09 ADD Falcon ���l�A�e�`�w�^�C�g���R�[�h�ǉ�
    '             DEL Falcon ���q�l�L���폜
    '2010/10/27 T.Watabe add
    '2012/06/25 W.GANEKO add pstrAUTOTAIOU �ǉ� �����Ή��t���O�ǉ��@0:�����Ή��ȊO/1:�����Ή�
    '2013/05/27 T.Ono edit�@�ڋq�P�ʓo�^�@�\�ǉ��@���ڒǉ�
    '2014/12/17 T.Ono edit �̔����Ǝ҃R�[�h�E���̒ǉ� 2014���P�J�� No2
    '2016/02/02 W.GANEKO edit �Ď����l�A�A����2�A�A����3�ǉ� 2015���P�J�� No1
    '2016/12/22 H.Mori mod 2016���P�J�� No4-1 NCU�ڑ�
    '2016/12/14 H.Mori mod �����`�ԋ敪�A��߯�FAX�敪�A�d�b�ԍ�(TELAB)�A��3�A���A����A�@�l��\�Ҏ����A�K�p�@�ߋ敪�A�p�r�敪�A�̔����R�[�h�A�ً}�A����CD 2016���P�J�� No4-6
    '2017/10/16 H.Mori mod �W���敪 2017���P�J�� No4-1
    '2020/11/01 T.Ono del 2020�Ď����P�@�g�p���Ă��Ȃ��̂ō폜
    '<WebMethod()> Public Function mSet_Taiou( _
    '                                        ByVal pstrSeniPG As String, _
    '                                        ByVal pstrSERIAL As String, _
    '                                        ByVal pstrKBN As String, _
    '                                        ByVal pstrKANSICD As String, _
    '                                        ByVal pstrSYONO As String, _
    '                                        ByVal pstrNCUHATYMD As String, _
    '                                        ByVal pstrNCUHATTIME As String, _
    '                                        ByVal pstrHATYMD As String, _
    '                                        ByVal pstrHATTIME As String, _
    '                                        ByVal pstrKENSIN As String, _
    '                                        ByVal pstrKEIHOSU As String, _
    '                                        ByVal pstrRYURYO As String, _
    '                                        ByVal pstrMETASYU As String, _
    '                                        ByVal pstrUNYO As String, _
    '                                        ByVal pstrJUYMD As String, _
    '                                        ByVal pstrJUTIME As String, _
    '                                        ByVal pstrNUM_DIGIT As String, _
    '                                        ByVal pstrKMCD1 As String, _
    '                                        ByVal pstrKMNM1 As String, _
    '                                        ByVal pstrKMCD2 As String, _
    '                                        ByVal pstrKMNM2 As String, _
    '                                        ByVal pstrKMCD3 As String, _
    '                                        ByVal pstrKMNM3 As String, _
    '                                        ByVal pstrKMCD4 As String, _
    '                                        ByVal pstrKMNM4 As String, _
    '                                        ByVal pstrKMCD5 As String, _
    '                                        ByVal pstrKMNM5 As String, _
    '                                        ByVal pstrKMCD6 As String, _
    '                                        ByVal pstrKMNM6 As String, _
    '                                        ByVal pstrKURACD As String, _
    '                                        ByVal pstrKENNM As String, _
    '                                        ByVal pstrJACD As String, _
    '                                        ByVal pstrJANM As String, _
    '                                        ByVal pstrHANJICD As String, _
    '                                        ByVal pstrHANJINM As String, _
    '                                        ByVal pstrACBCD As String, _
    '                                        ByVal pstrACBNM As String, _
    '                                        ByVal pstrUSER_CD As String, _
    '                                        ByVal pstrJUSYONM As String, _
    '                                        ByVal pstrJUSYOKN As String, _
    '                                        ByVal pstrJUTEL1 As String, _
    '                                        ByVal pstrJUTEL2 As String, _
    '                                        ByVal pstrRENTEL As String, _
    '                                        ByVal pstrKTELNO As String, _
    '                                        ByVal pstrADDR As String, _
    '                                        ByVal pstrNCU_SET As String, _
    '                                        ByVal pstrTIZUNO As String, _
    '                                        ByVal pstrHANBAI_KBN As String, _
    '                                        ByVal pstrKYOKTKBN As String, _
    '                                        ByVal pstrMET_KATA As String, _
    '                                        ByVal pstrMET_MAKER As String, _
    '                                        ByVal pstrBONB1_KKG As String, _
    '                                        ByVal pstrBONB1_HON As String, _
    '                                        ByVal pstrBONB1_YOBI As String, _
    '                                        ByVal pstrBONB2_KKG As String, _
    '                                        ByVal pstrBONB2_HON As String, _
    '                                        ByVal pstrBONB2_YOBI As String, _
    '                                        ByVal pstrBONB3_KKG As String, _
    '                                        ByVal pstrBONB3_HON As String, _
    '                                        ByVal pstrBONB3_YOBI As String, _
    '                                        ByVal pstrBONB4_KKG As String, _
    '                                        ByVal pstrBONB4_HON As String, _
    '                                        ByVal pstrBONB4_YOBI As String, _
    '                                        ByVal pstrZENKAI_HAISO As String, _
    '                                        ByVal pstrZENKAI_HAI_S As String, _
    '                                        ByVal pstrKONKAI_HAISO As String, _
    '                                        ByVal pstrKONKAI_HAI_S As String, _
    '                                        ByVal pstrJIKAI_HAISO As String, _
    '                                        ByVal pstrZENKAI_KENSIN As String, _
    '                                        ByVal pstrZENKAI_KEN_S As String, _
    '                                        ByVal pstrZENKAI_KEN_SIYO As String, _
    '                                        ByVal pstrKONKAI_KENSIN As String, _
    '                                        ByVal pstrKONKAI_KEN_S As String, _
    '                                        ByVal pstrKONKAI_KEN_SIYO As String, _
    '                                        ByVal pstrZENKAI_HASEI As String, _
    '                                        ByVal pstrZENKAI_HAS_S As String, _
    '                                        ByVal pstrKONKAI_HASEI As String, _
    '                                        ByVal pstrKONKAI_HAS_S As String, _
    '                                        ByVal pstrG_ZAIKO As String, _
    '                                        ByVal pstrICHI_SIYO As String, _
    '                                        ByVal pstrYOSOKU_ICHI_SIYO As String, _
    '                                        ByVal pstrGAS1_HINMEI As String, _
    '                                        ByVal pstrGAS1_DAISU As String, _
    '                                        ByVal pstrGAS1_SEIFL As String, _
    '                                        ByVal pstrGAS2_HINMEI As String, _
    '                                        ByVal pstrGAS2_DAISU As String, _
    '                                        ByVal pstrGAS2_SEIFL As String, _
    '                                        ByVal pstrGAS3_HINMEI As String, _
    '                                        ByVal pstrGAS3_DAISU As String, _
    '                                        ByVal pstrGAS3_SEIFL As String, _
    '                                        ByVal pstrGAS4_HINMEI As String, _
    '                                        ByVal pstrGAS4_DAISU As String, _
    '                                        ByVal pstrGAS4_SEIFL As String, _
    '                                        ByVal pstrGAS5_HINMEI As String, _
    '                                        ByVal pstrGAS5_DAISU As String, _
    '                                        ByVal pstrGAS5_SEIFL As String, _
    '                                        ByVal pstrHATKBN As String, _
    '                                        ByVal pstrTAIOKBN As String, _
    '                                        ByVal pstrTMSKB As String, _
    '                                        ByVal pstrTKTANCD As String, _
    '                                        ByVal pstrTAITCD As String, _
    '                                        ByVal pstrTAIO_ST_DATE As String, _
    '                                        ByVal pstrTAIO_ST_TIME As String, _
    '                                        ByVal pstrSYOYMD As String, _
    '                                        ByVal pstrSYOTIME As String, _
    '                                        ByVal pstrTAIO_SYO_TIME As String, _
    '                                        ByVal pstrFAXKBN As String, _
    '                                        ByVal pstrFAXRUISEKIKBN As String, _
    '                                        ByVal pstrTELRCD As String, _
    '                                        ByVal pstrTFKICD As String, _
    '                                        ByVal pstrFUK_MEMO As String, _
    '                                        ByVal pstrTEL_MEMO1 As String, _
    '                                        ByVal pstrTEL_MEMO2 As String, _
    '                                        ByVal pstrMITOKBN As String, _
    '                                        ByVal pstrTKIGCD As String, _
    '                                        ByVal pstrTSADCD As String, _
    '                                        ByVal pstrGENIN_KIJI As String, _
    '                                        ByVal pstrSDCD As String, _
    '                                        ByVal pstrSIJIYMD As String, _
    '                                        ByVal pstrSIJITIME As String, _
    '                                        ByVal pstrSIJI_BIKO1 As String, _
    '                                        ByVal pstrSIJI_BIKO2 As String, _
    '                                        ByVal pstrSTD_JASCD As String, _
    '                                        ByVal pstrSTD_JANA As String, _
    '                                        ByVal pstrSTD_JASNA As String, _
    '                                        ByVal pstrREN_CODE As String, _
    '                                        ByVal pstrREN_NA As String, _
    '                                        ByVal pstrREN_TEL_1 As String, _
    '                                        ByVal pstrREN_TEL_2 As String, _
    '                                        ByVal pstrREN_TEL_3 As String, _
    '                                        ByVal pstrREN_FAX As String, _
    '                                        ByVal pstrREN_BIKO As String, _
    '                                        ByVal pstrREN_EDT_DATE As String, _
    '                                        ByVal pstrREN_TIME As String, _
    '                                        ByVal pstrREN_1_CODE As String, _
    '                                        ByVal pstrREN_1_NA As String, _
    '                                        ByVal pstrREN_1_TEL1 As String, _
    '                                        ByVal pstrREN_1_TEL2 As String, _
    '                                        ByVal pstrREN_1_TEL3 As String, _
    '                                        ByVal pstrREN_1_FAX As String, _
    '                                        ByVal pstrREN_1_BIKO As String, _
    '                                        ByVal pstrREN_1_EDT_DATE As String, _
    '                                        ByVal pstrREN_1_TIME As String, _
    '                                        ByVal pstrREN_2_CODE As String, _
    '                                        ByVal pstrREN_2_NA As String, _
    '                                        ByVal pstrREN_2_TEL1 As String, _
    '                                        ByVal pstrREN_2_TEL2 As String, _
    '                                        ByVal pstrREN_2_TEL3 As String, _
    '                                        ByVal pstrREN_2_FAX As String, _
    '                                        ByVal pstrREN_2_BIKO As String, _
    '                                        ByVal pstrREN_2_EDT_DATE As String, _
    '                                        ByVal pstrREN_2_TIME As String, _
    '                                        ByVal pstrREN_3_CODE As String, _
    '                                        ByVal pstrREN_3_NA As String, _
    '                                        ByVal pstrREN_3_TEL1 As String, _
    '                                        ByVal pstrREN_3_TEL2 As String, _
    '                                        ByVal pstrREN_3_TEL3 As String, _
    '                                        ByVal pstrREN_3_FAX As String, _
    '                                        ByVal pstrREN_3_BIKO As String, _
    '                                        ByVal pstrREN_3_EDT_DATE As String, _
    '                                        ByVal pstrREN_3_TIME As String, _
    '                                        ByVal pstrTEL_BIKO As String, _
    '                                        ByVal pstrFAX_TITLE As String, _
    '                                        ByVal pstrFAX_REN As String, _
    '                                        ByVal pstrSTD_CD As String, _
    '                                        ByVal pstrSTD As String, _
    '                                        ByVal pstrSTD_KYOTEN_CD As String, _
    '                                        ByVal pstrSTD_KYOTEN As String, _
    '                                        ByVal pstrSTD_TEL As String, _
    '                                        ByVal pstrADD_DATE As String, _
    '                                        ByVal pstrEDT_DATE As String, _
    '                                        ByVal pstrTIME As String, _
    '                                        ByVal pstrBOMB_TYPE As String, _
    '                                        ByVal pstrGAS_STOP As String, _
    '                                        ByVal pstrGAS_DELE As String, _
    '                                        ByVal pstrGAS_RESTART As String, _
    '                                        ByVal pstrKAITU_DAY As String, _
    '                                        ByVal pstrBIKOU As String, _
    '                                        ByVal pstrFAX_TITLE_CD As String, _
    '                                        ByVal pstrDialKbns As String, _
    '                                        ByVal pstrDialNumbers As String, _
    '                                        ByVal pstrDialAites As String, _
    '                                        ByVal pstrDialResult As String, _
    '                                        ByVal pstrDialDates As String, _
    '                                        ByVal pstrDialTimes As String, _
    '                                        ByVal pstrDialStates As String, _
    '                                        ByVal pstrSDSKBN As String, _
    '                                        ByVal pstrKANSHI_BIKO As String, _
    '                                        ByVal pstrRENTEL2 As String, _
    '                                        ByVal pstrRENTEL2_BIKO As String, _
    '                                        ByVal pstrRENTEL2_UPD_DATE As String, _
    '                                        ByVal pstrRENTEL3 As String, _
    '                                        ByVal pstrRENTEL3_BIKO As String, _
    '                                        ByVal pstrRENTEL3_UPD_DATE As String, _
    '                                        ByVal pstrTUSIN As String, _
    '                                        ByVal pstrFAXSPOTKBN As String, _
    '                                        ByVal pstrTELAB As String, _
    '                                        ByVal pstrDAI3RENDORENTEL As String, _
    '                                        ByVal pstrDAIHYO_NAME As String, _
    '                                        ByVal pstrHOKBN As String, _
    '                                        ByVal pstrYOTOKBN As String, _
    '                                        ByVal pstrHANBCD As String, _
    '                                        ByVal pstrKINRENCD As String, _
    '                                        ByVal pstrSHUGOU As String _
    '                                        ) As String
    '    mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Taiou START pstrKURACD=" & pstrKURACD & ",pstrJACD=" & pstrJACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrHATYMD=" & pstrHATYMD & ",pstrHATTIME=" & pstrHATTIME)

    '    Dim strFAXKURAKBN As String = "2" 'FAX�s�v�敪(�ײ���) 1:�s�v/2:�K�v
    '    '2012/06/25 W.GANEKO ADD �p�����[�^�̍Ō��ǉ� "0":�����Ή��ȊO 
    '    Return mSet_Taiou2(
    '                        pstrSeniPG,
    '                        pstrSERIAL,
    '                        pstrKBN,
    '                        pstrKANSICD,
    '                        pstrSYONO,
    '                        pstrNCUHATYMD,
    '                        pstrNCUHATTIME,
    '                        pstrHATYMD,
    '                        pstrHATTIME,
    '                        pstrKENSIN,
    '                        pstrKEIHOSU,
    '                        pstrRYURYO,
    '                        pstrMETASYU,
    '                        pstrUNYO,
    '                        pstrJUYMD,
    '                        pstrJUTIME,
    '                        pstrNUM_DIGIT,
    '                        pstrKMCD1,
    '                        pstrKMNM1,
    '                        pstrKMCD2,
    '                        pstrKMNM2,
    '                        pstrKMCD3,
    '                        pstrKMNM3,
    '                        pstrKMCD4,
    '                        pstrKMNM4,
    '                        pstrKMCD5,
    '                        pstrKMNM5,
    '                        pstrKMCD6,
    '                        pstrKMNM6,
    '                        pstrKURACD,
    '                        pstrKENNM,
    '                        pstrJACD,
    '                        pstrJANM,
    '                        pstrHANJICD,
    '                        pstrHANJINM,
    '                        pstrACBCD,
    '                        pstrACBNM,
    '                        pstrUSER_CD,
    '                        pstrJUSYONM,
    '                        pstrJUSYOKN,
    '                        pstrJUTEL1,
    '                        pstrJUTEL2,
    '                        pstrRENTEL,
    '                        pstrKTELNO,
    '                        pstrADDR,
    '                        pstrNCU_SET,
    '                        pstrTIZUNO,
    '                        pstrHANBAI_KBN,
    '                        pstrKYOKTKBN,
    '                        pstrMET_KATA,
    '                        pstrMET_MAKER,
    '                        pstrBONB1_KKG,
    '                        pstrBONB1_HON,
    '                        pstrBONB1_YOBI,
    '                        pstrBONB2_KKG,
    '                        pstrBONB2_HON,
    '                        pstrBONB2_YOBI,
    '                        pstrBONB3_KKG,
    '                        pstrBONB3_HON,
    '                        pstrBONB3_YOBI,
    '                        pstrBONB4_KKG,
    '                        pstrBONB4_HON,
    '                        pstrBONB4_YOBI,
    '                        pstrZENKAI_HAISO,
    '                        pstrZENKAI_HAI_S,
    '                        pstrKONKAI_HAISO,
    '                        pstrKONKAI_HAI_S,
    '                        pstrJIKAI_HAISO,
    '                        pstrZENKAI_KENSIN,
    '                        pstrZENKAI_KEN_S,
    '                        pstrZENKAI_KEN_SIYO,
    '                        pstrKONKAI_KENSIN,
    '                        pstrKONKAI_KEN_S,
    '                        pstrKONKAI_KEN_SIYO,
    '                        pstrZENKAI_HASEI,
    '                        pstrZENKAI_HAS_S,
    '                        pstrKONKAI_HASEI,
    '                        pstrKONKAI_HAS_S,
    '                        pstrG_ZAIKO,
    '                        pstrICHI_SIYO,
    '                        pstrYOSOKU_ICHI_SIYO,
    '                        pstrGAS1_HINMEI,
    '                        pstrGAS1_DAISU,
    '                        pstrGAS1_SEIFL,
    '                        pstrGAS2_HINMEI,
    '                        pstrGAS2_DAISU,
    '                        pstrGAS2_SEIFL,
    '                        pstrGAS3_HINMEI,
    '                        pstrGAS3_DAISU,
    '                        pstrGAS3_SEIFL,
    '                        pstrGAS4_HINMEI,
    '                        pstrGAS4_DAISU,
    '                        pstrGAS4_SEIFL,
    '                        pstrGAS5_HINMEI,
    '                        pstrGAS5_DAISU,
    '                        pstrGAS5_SEIFL,
    '                        pstrHATKBN,
    '                        pstrTAIOKBN,
    '                        pstrTMSKB,
    '                        pstrTKTANCD,
    '                        pstrTAITCD,
    '                        pstrTAIO_ST_DATE,
    '                        pstrTAIO_ST_TIME,
    '                        pstrSYOYMD,
    '                        pstrSYOTIME,
    '                        pstrTAIO_SYO_TIME,
    '                        pstrFAXKBN,
    '                        strFAXKURAKBN,
    '                        pstrFAXRUISEKIKBN,
    '                        pstrTELRCD,
    '                        pstrTFKICD,
    '                        pstrFUK_MEMO,
    '                        pstrTEL_MEMO1,
    '                        pstrTEL_MEMO2,
    '                        pstrMITOKBN,
    '                        pstrTKIGCD,
    '                        pstrTSADCD,
    '                        pstrGENIN_KIJI,
    '                        pstrSDCD,
    '                        pstrSIJIYMD,
    '                        pstrSIJITIME,
    '                        pstrSIJI_BIKO1,
    '                        pstrSIJI_BIKO2,
    '                        pstrSTD_JASCD,
    '                        pstrSTD_JANA,
    '                        pstrSTD_JASNA,
    '                        pstrREN_CODE,
    '                        pstrREN_NA,
    '                        pstrREN_TEL_1,
    '                        pstrREN_TEL_2,
    '                        pstrREN_TEL_3,
    '                        pstrREN_FAX,
    '                        pstrREN_BIKO,
    '                        pstrREN_EDT_DATE,
    '                        pstrREN_TIME,
    '                        pstrREN_1_CODE,
    '                        pstrREN_1_NA,
    '                        pstrREN_1_TEL1,
    '                        pstrREN_1_TEL2,
    '                        pstrREN_1_TEL3,
    '                        pstrREN_1_FAX,
    '                        pstrREN_1_BIKO,
    '                        pstrREN_1_EDT_DATE,
    '                        pstrREN_1_TIME,
    '                        pstrREN_2_CODE,
    '                        pstrREN_2_NA,
    '                        pstrREN_2_TEL1,
    '                        pstrREN_2_TEL2,
    '                        pstrREN_2_TEL3,
    '                        pstrREN_2_FAX,
    '                        pstrREN_2_BIKO,
    '                        pstrREN_2_EDT_DATE,
    '                        pstrREN_2_TIME,
    '                        pstrREN_3_CODE,
    '                        pstrREN_3_NA,
    '                        pstrREN_3_TEL1,
    '                        pstrREN_3_TEL2,
    '                        pstrREN_3_TEL3,
    '                        pstrREN_3_FAX,
    '                        pstrREN_3_BIKO,
    '                        pstrREN_3_EDT_DATE,
    '                        pstrREN_3_TIME,
    '                        pstrTEL_BIKO,
    '                        pstrFAX_TITLE,
    '                        pstrFAX_REN,
    '                        pstrSTD_CD,
    '                        pstrSTD,
    '                        pstrSTD_KYOTEN_CD,
    '                        pstrSTD_KYOTEN,
    '                        pstrSTD_TEL,
    '                        pstrADD_DATE,
    '                        pstrEDT_DATE,
    '                        pstrTIME,
    '                        pstrBOMB_TYPE,
    '                        pstrGAS_STOP,
    '                        pstrGAS_DELE,
    '                        pstrGAS_RESTART,
    '                        pstrKAITU_DAY,
    '                        pstrBIKOU,
    '                        pstrFAX_TITLE_CD,
    '                        pstrDialKbns,
    '                        pstrDialNumbers,
    '                        pstrDialAites,
    '                        pstrDialResult,
    '                        pstrDialDates,
    '                        pstrDialTimes,
    '                        pstrDialStates,
    '                        pstrSDSKBN,
    '                        "0",
    '                        pstrKANSHI_BIKO,
    '                        pstrRENTEL2,
    '                        pstrRENTEL2_BIKO,
    '                        pstrRENTEL2_UPD_DATE,
    '                        pstrRENTEL3,
    '                        pstrRENTEL3_BIKO,
    '                        pstrRENTEL3_UPD_DATE,
    '                        pstrTUSIN,
    '                        pstrFAXSPOTKBN,
    '                        pstrTELAB,
    '                        pstrDAI3RENDORENTEL,
    '                        pstrDAIHYO_NAME,
    '                        pstrHOKBN,
    '                        pstrYOTOKBN,
    '                        pstrHANBCD,
    '                        pstrKINRENCD,
    '                        pstrSHUGOU
    '                        )
    'End Function
    '************************************************
    '�Ή�DB�̓o�^�A�C�����s���܂�
    '�d�b���M�̃��O���������݂܂�
    '���ꂼ��̍��ڂ��J���}��؂�Ŏ擾�\�Ȃ̂ŁA
    '�������P���P��DB��INSERT���܂�
    '************************************************
    '2016/02/02 W.GANEKO edit �Ď����l�A�A����2�A�A����3�ǉ� 2015���P�J�� No1
    ' 2016/12/22 H.Mori mod 2016���P�J�� No4-1 NCU�ڑ�
    ' 2016/12/14 H.Mori mod �����`�ԋ敪�A��߯�FAX�敪�A�d�b�ԍ�(TELAB)�A��3�A���A����A�@�l��\�Ҏ����A�K�p�@�ߋ敪�A�p�r�敪�A�̔����R�[�h�A�ً}�A����CD 2016���P�J�� No4-6
    ' 2017/10/16 H.Mori mod �W���敪 2017���P�J�� No4-1
    ' 2020/11/01 T.Ono mod 2020�Ď����P TEL_MEMO4�`6�ǉ�
    ' 2023/01/04 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� �����ɁAJM�a���ipstrJMNAME�j��ǉ��BD20_TAIOU�o�^�ɃJ���������킹�Ēǉ��B
    <WebMethod()> Public Function mSet_Taiou2(
                                            ByVal pstrSeniPG As String,
                                            ByVal pstrSERIAL As String,
                                            ByVal pstrKBN As String,
                                            ByVal pstrKANSICD As String,
                                            ByVal pstrSYONO As String,
                                            ByVal pstrNCUHATYMD As String,
                                            ByVal pstrNCUHATTIME As String,
                                            ByVal pstrHATYMD As String,
                                            ByVal pstrHATTIME As String,
                                            ByVal pstrKENSIN As String,
                                            ByVal pstrKEIHOSU As String,
                                            ByVal pstrRYURYO As String,
                                            ByVal pstrMETASYU As String,
                                            ByVal pstrUNYO As String,
                                            ByVal pstrJUYMD As String,
                                            ByVal pstrJUTIME As String,
                                            ByVal pstrNUM_DIGIT As String,
                                            ByVal pstrKMCD1 As String,
                                            ByVal pstrKMNM1 As String,
                                            ByVal pstrKMCD2 As String,
                                            ByVal pstrKMNM2 As String,
                                            ByVal pstrKMCD3 As String,
                                            ByVal pstrKMNM3 As String,
                                            ByVal pstrKMCD4 As String,
                                            ByVal pstrKMNM4 As String,
                                            ByVal pstrKMCD5 As String,
                                            ByVal pstrKMNM5 As String,
                                            ByVal pstrKMCD6 As String,
                                            ByVal pstrKMNM6 As String,
                                            ByVal pstrKURACD As String,
                                            ByVal pstrKENNM As String,
                                            ByVal pstrJACD As String,
                                            ByVal pstrJANM As String,
                                            ByVal pstrHANJICD As String,
                                            ByVal pstrHANJINM As String,
                                            ByVal pstrACBCD As String,
                                            ByVal pstrACBNM As String,
                                            ByVal pstrUSER_CD As String,
                                            ByVal pstrJUSYONM As String,
                                            ByVal pstrJUSYOKN As String,
                                            ByVal pstrJUTEL1 As String,
                                            ByVal pstrJUTEL2 As String,
                                            ByVal pstrRENTEL As String,
                                            ByVal pstrKTELNO As String,
                                            ByVal pstrADDR As String,
                                            ByVal pstrNCU_SET As String,
                                            ByVal pstrTIZUNO As String,
                                            ByVal pstrHANBAI_KBN As String,
                                            ByVal pstrKYOKTKBN As String,
                                            ByVal pstrMET_KATA As String,
                                            ByVal pstrMET_MAKER As String,
                                            ByVal pstrBONB1_KKG As String,
                                            ByVal pstrBONB1_HON As String,
                                            ByVal pstrBONB1_YOBI As String,
                                            ByVal pstrBONB2_KKG As String,
                                            ByVal pstrBONB2_HON As String,
                                            ByVal pstrBONB2_YOBI As String,
                                            ByVal pstrBONB3_KKG As String,
                                            ByVal pstrBONB3_HON As String,
                                            ByVal pstrBONB3_YOBI As String,
                                            ByVal pstrBONB4_KKG As String,
                                            ByVal pstrBONB4_HON As String,
                                            ByVal pstrBONB4_YOBI As String,
                                            ByVal pstrZENKAI_HAISO As String,
                                            ByVal pstrZENKAI_HAI_S As String,
                                            ByVal pstrKONKAI_HAISO As String,
                                            ByVal pstrKONKAI_HAI_S As String,
                                            ByVal pstrJIKAI_HAISO As String,
                                            ByVal pstrZENKAI_KENSIN As String,
                                            ByVal pstrZENKAI_KEN_S As String,
                                            ByVal pstrZENKAI_KEN_SIYO As String,
                                            ByVal pstrKONKAI_KENSIN As String,
                                            ByVal pstrKONKAI_KEN_S As String,
                                            ByVal pstrKONKAI_KEN_SIYO As String,
                                            ByVal pstrZENKAI_HASEI As String,
                                            ByVal pstrZENKAI_HAS_S As String,
                                            ByVal pstrKONKAI_HASEI As String,
                                            ByVal pstrKONKAI_HAS_S As String,
                                            ByVal pstrG_ZAIKO As String,
                                            ByVal pstrICHI_SIYO As String,
                                            ByVal pstrYOSOKU_ICHI_SIYO As String,
                                            ByVal pstrGAS1_HINMEI As String,
                                            ByVal pstrGAS1_DAISU As String,
                                            ByVal pstrGAS1_SEIFL As String,
                                            ByVal pstrGAS2_HINMEI As String,
                                            ByVal pstrGAS2_DAISU As String,
                                            ByVal pstrGAS2_SEIFL As String,
                                            ByVal pstrGAS3_HINMEI As String,
                                            ByVal pstrGAS3_DAISU As String,
                                            ByVal pstrGAS3_SEIFL As String,
                                            ByVal pstrGAS4_HINMEI As String,
                                            ByVal pstrGAS4_DAISU As String,
                                            ByVal pstrGAS4_SEIFL As String,
                                            ByVal pstrGAS5_HINMEI As String,
                                            ByVal pstrGAS5_DAISU As String,
                                            ByVal pstrGAS5_SEIFL As String,
                                            ByVal pstrHATKBN As String,
                                            ByVal pstrTAIOKBN As String,
                                            ByVal pstrTMSKB As String,
                                            ByVal pstrTKTANCD As String,
                                            ByVal pstrTAITCD As String,
                                            ByVal pstrTAIO_ST_DATE As String,
                                            ByVal pstrTAIO_ST_TIME As String,
                                            ByVal pstrSYOYMD As String,
                                            ByVal pstrSYOTIME As String,
                                            ByVal pstrTAIO_SYO_TIME As String,
                                            ByVal pstrFAXKBN As String,
                                            ByVal pstrFAXKURAKBN As String,
                                            ByVal pstrFAXRUISEKIKBN As String,
                                            ByVal pstrTELRCD As String,
                                            ByVal pstrTFKICD As String,
                                            ByVal pstrFUK_MEMO As String,
                                            ByVal pstrTEL_MEMO1 As String,
                                            ByVal pstrTEL_MEMO2 As String,
                                            ByVal pstrTEL_MEMO4 As String,
                                            ByVal pstrTEL_MEMO5 As String,
                                            ByVal pstrTEL_MEMO6 As String,
                                            ByVal pstrMITOKBN As String,
                                            ByVal pstrTKIGCD As String,
                                            ByVal pstrTSADCD As String,
                                            ByVal pstrGENIN_KIJI As String,
                                            ByVal pstrSDCD As String,
                                            ByVal pstrSIJIYMD As String,
                                            ByVal pstrSIJITIME As String,
                                            ByVal pstrSIJI_BIKO1 As String,
                                            ByVal pstrSIJI_BIKO2 As String,
                                            ByVal pstrSTD_JASCD As String,
                                            ByVal pstrSTD_JANA As String,
                                            ByVal pstrSTD_JASNA As String,
                                            ByVal pstrREN_CODE As String,
                                            ByVal pstrREN_NA As String,
                                            ByVal pstrREN_TEL_1 As String,
                                            ByVal pstrREN_TEL_2 As String,
                                            ByVal pstrREN_TEL_3 As String,
                                            ByVal pstrREN_FAX As String,
                                            ByVal pstrREN_BIKO As String,
                                            ByVal pstrREN_EDT_DATE As String,
                                            ByVal pstrREN_TIME As String,
                                            ByVal pstrREN_1_CODE As String,
                                            ByVal pstrREN_1_NA As String,
                                            ByVal pstrREN_1_TEL1 As String,
                                            ByVal pstrREN_1_TEL2 As String,
                                            ByVal pstrREN_1_TEL3 As String,
                                            ByVal pstrREN_1_FAX As String,
                                            ByVal pstrREN_1_BIKO As String,
                                            ByVal pstrREN_1_EDT_DATE As String,
                                            ByVal pstrREN_1_TIME As String,
                                            ByVal pstrREN_2_CODE As String,
                                            ByVal pstrREN_2_NA As String,
                                            ByVal pstrREN_2_TEL1 As String,
                                            ByVal pstrREN_2_TEL2 As String,
                                            ByVal pstrREN_2_TEL3 As String,
                                            ByVal pstrREN_2_FAX As String,
                                            ByVal pstrREN_2_BIKO As String,
                                            ByVal pstrREN_2_EDT_DATE As String,
                                            ByVal pstrREN_2_TIME As String,
                                            ByVal pstrREN_3_CODE As String,
                                            ByVal pstrREN_3_NA As String,
                                            ByVal pstrREN_3_TEL1 As String,
                                            ByVal pstrREN_3_TEL2 As String,
                                            ByVal pstrREN_3_TEL3 As String,
                                            ByVal pstrREN_3_FAX As String,
                                            ByVal pstrREN_3_BIKO As String,
                                            ByVal pstrREN_3_EDT_DATE As String,
                                            ByVal pstrREN_3_TIME As String,
                                            ByVal pstrTEL_BIKO As String,
                                            ByVal pstrFAX_TITLE As String,
                                            ByVal pstrFAX_REN As String,
                                            ByVal pstrSTD_CD As String,
                                            ByVal pstrSTD As String,
                                            ByVal pstrSTD_KYOTEN_CD As String,
                                            ByVal pstrSTD_KYOTEN As String,
                                            ByVal pstrSTD_TEL As String,
                                            ByVal pstrADD_DATE As String,
                                            ByVal pstrEDT_DATE As String,
                                            ByVal pstrTIME As String,
                                            ByVal pstrBOMB_TYPE As String,
                                            ByVal pstrGAS_STOP As String,
                                            ByVal pstrGAS_DELE As String,
                                            ByVal pstrGAS_RESTART As String,
                                            ByVal pstrKAITU_DAY As String,
                                            ByVal pstrBIKOU As String,
                                            ByVal pstrFAX_TITLE_CD As String,
                                            ByVal pstrDialKbns As String,
                                            ByVal pstrDialNumbers As String,
                                            ByVal pstrDialAites As String,
                                            ByVal pstrDialResult As String,
                                            ByVal pstrDialDates As String,
                                            ByVal pstrDialTimes As String,
                                            ByVal pstrDialStates As String,
                                            ByVal pstrSDSKBN As String,
                                            ByVal pstrAUTOTAIOU As String,
                                            ByVal pstrKANSHI_BIKO As String,
                                            ByVal pstrRENTEL2 As String,
                                            ByVal pstrRENTEL2_BIKO As String,
                                            ByVal pstrRENTEL2_UPD_DATE As String,
                                            ByVal pstrRENTEL3 As String,
                                            ByVal pstrRENTEL3_BIKO As String,
                                            ByVal pstrRENTEL3_UPD_DATE As String,
                                            ByVal pstrTUSIN As String,
                                            ByVal pstrFAXSPOTKBN As String,
                                            ByVal pstrTELAB As String,
                                            ByVal pstrDAI3RENDORENTEL As String,
                                            ByVal pstrDAIHYO_NAME As String,
                                            ByVal pstrHOKBN As String,
                                            ByVal pstrYOTOKBN As String,
                                            ByVal pstrHANBCD As String,
                                            ByVal pstrKINRENCD As String,
                                            ByVal pstrSHUGOU As String,
                                            ByVal pstrJMNAME As String
                                            ) As String

        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Taiou2 START pstrKURACD=" & pstrKURACD & ",pstrJACD=" & pstrJACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrHATYMD=" & pstrHATYMD & ",pstrHATTIME=" & pstrHATTIME)
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim strSeqno As String                                  '//�����ԍ��i�[�p

        Dim strZ_SYOTIME As String                              '//���v���Ԃ��v�Z����i�Ή��I�����t�j
        Dim strZ_SYOYMD As String                               '//���v���Ԃ��v�Z����i�Ή��I�������j
        Dim strZ_TaioStDate As String                           '//���v���Ԃ��v�Z����i�Ή��J�n���t�j
        Dim strZ_TaioStTime As String                           '//���v���Ԃ��v�Z����i�Ή��J�n�����j
        Dim strZ_SYOYOTIME As String                            '//���v���Ԃ��v�Z����i���v�����j

        strRes = "OK"
        '�ڑ�OPEN----------------------------------------
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally

        End Try

        Try
            '�g�����U�N�V�����J�n--------------------------
            cdb.mBeginTrans()

            '*********************************
            '�����X�g�[���[
            '[1]�C�����ɂ̓f�[�^�͑��݂��邱��
            '[2]�r���̃`�F�b�N���s���B
            '[3]�x���ʂ���̑J�ڎ��A�Ή����͑Ώۂ̌x��c�a���Ή��ς݂łȂ�����
            '*********************************

            If (pstrSeniPG = "KEKEKJAG00") Then
                '�Ή����ʈꗗ����̑J�ڂ������ꍇ
                '�Ή��c�a�̑��݃`�F�b�N
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append("EDT_DATE,")
                strSQL.Append("TAIO_ST_DATE,")                  '//���v���Ԃ��v�Z���Ɍ��ݓo�^���̒l���g�p
                strSQL.Append("TAIO_ST_TIME,")                  '//���v���Ԃ��v�Z���Ɍ��ݓo�^���̒l���g�p
                strSQL.Append("SYOYMD,")                        '//���v���Ԃ��v�Z���Ɍ��ݓo�^���̒l���g�p
                strSQL.Append("SYOTIME,")                       '//���v���Ԃ��v�Z���Ɍ��ݓo�^���̒l���g�p
                strSQL.Append("TAIO_SYO_TIME,")                 '//���v���Ԃ��v�Z���Ɍ��ݓo�^���̒l���g�p
                strSQL.Append("EDT_TIME ")
                strSQL.Append("FROM D20_TAIOU ")
                strSQL.Append("WHERE KANSCD = :KANSCD")
                strSQL.Append("  AND SYONO = :SYONO ")
                strSQL.Append("FOR UPDATE ")                    '//�r�������������
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString
                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("KANSCD") = pstrKANSICD        '//�Ď��Z���^�[�R�[�h
                cdb.pSQLParamStr("SYONO") = pstrSYONO           '//�r�d�p�ԍ�
                'SQL���s
                cdb.mExecQuery()
                '�f�[�^�Z�b�g�ɒl���i�[
                ds = cdb.pResult

                If (ds.Tables(0).Rows.Count = 0) Then
                    '*******************************************
                    '�C���������L�[�̃f�[�^�����݂��Ȃ��ꍇ�̓G���[�Ƃ���
                    '*******************************************
                    strRes = "1"
                    Exit Try
                End If
                If ((Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) <> pstrEDT_DATE) Or
                    (Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_TIME")) <> pstrTIME)) Then
                    '*******************************************
                    '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
                    '*******************************************
                    strRes = "2"
                    Exit Try
                End If

                strZ_SYOTIME = Convert.ToString(ds.Tables(0).Rows(0).Item("SYOTIME"))
                strZ_SYOYMD = Convert.ToString(ds.Tables(0).Rows(0).Item("SYOYMD"))
                strZ_TaioStDate = Convert.ToString(ds.Tables(0).Rows(0).Item("TAIO_ST_DATE"))
                strZ_TaioStTime = Convert.ToString(ds.Tables(0).Rows(0).Item("TAIO_ST_TIME"))
                strZ_SYOYOTIME = Convert.ToString(ds.Tables(0).Rows(0).Item("TAIO_SYO_TIME"))
            Else
                strZ_SYOTIME = ""
                strZ_SYOYMD = ""
                strZ_TaioStDate = ""
                strZ_TaioStTime = ""
                strZ_SYOYOTIME = ""
            End If

            If pstrSeniPG = "KEJUKJAG00" Then
                '�x���M�p�l������̑J�ڂ������ꍇ

                '�x��c�a����S���ґΉ���ԂƎ�M���A��M�����A���j���[�h���擾
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                strSQL.Append("REACTION ")
                strSQL.Append("FROM T10_KEIHO ")
                strSQL.Append("WHERE SYORI_SERIAL = :SYORISERIAL ")
                strSQL.Append("FOR UPDATE ")                    '//�r�������������
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString
                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("SYORISERIAL") = pstrSERIAL    '//SEQ�ԍ�
                'SQL���s
                cdb.mExecQuery()
                '�f�[�^�Z�b�g�ɒl���i�[
                ds = cdb.pResult

                If Convert.ToString(ds.Tables(0).Rows(0).Item("REACTION")) = "1" Then
                    '*******************************************
                    '�Ή����͑Ώۂ̌x��t�@�C�������ɑΉ��ς݂������ꍇ�̓G���[�Ƃ���
                    '*******************************************
                    strRes = "3"
                    Exit Try
                End If
            End If

            '*******************************************
            '�ڋq�c�a���Ɍx��t�@�C�����ڋq���(���q�l�L��)���t�o�c�`�s�d����
            '*******************************************
            Dim intCnt As Integer                               '//�X�V���ڐ��i�[�p
            '�ڋq�c�a�̑��݃`�F�b�N
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append("USR_MEMO ")
            strSQL.Append(",RENTEL2 ")
            strSQL.Append(",RENTEL2_BIKO ")
            strSQL.Append(",RENTEL2_UPD_DATE ")
            strSQL.Append(",RENTEL3 ")
            strSQL.Append(",RENTEL3_BIKO ")
            strSQL.Append(",RENTEL3_UPD_DATE ")
            strSQL.Append(",TELA || TELB TELAB ")                     ' 2016/12/20 H.Mori add 2016���P�J�� No4-3
            strSQL.Append(",DAI3RENDORENTEL ")                 ' 2016/12/20 H.Mori add 2016���P�J�� No4-3
            strSQL.Append("FROM SHAMAS ")
            strSQL.Append("WHERE CLI_CD = :CLI_CD")
            strSQL.Append("  AND HAN_CD = :HAN_CD ")
            strSQL.Append("  AND USER_CD = :USER_CD ")
            strSQL.Append("FOR UPDATE ")
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("CLI_CD") = pstrKURACD             '//�N���C�A���g�R�[�h
            cdb.pSQLParamStr("HAN_CD") = pstrACBCD              '//�i�`�x���R�[�h
            cdb.pSQLParamStr("USER_CD") = pstrUSER_CD           '//���q�l�R�[�h
            'SQL���s
            cdb.mExecQuery()
            '�f�[�^�Z�b�g�ɒl���i�[
            ds = cdb.pResult

            If ds.Tables(0).Rows.Count > 0 Then
                If pstrRENTEL2 = "" And pstrRENTEL2_BIKO = "" And pstrRENTEL2_UPD_DATE = "" And
                  pstrRENTEL3 = "" And pstrRENTEL3_BIKO = "" And pstrRENTEL3_UPD_DATE = "" And
                  pstrTELAB = "" And pstrDAI3RENDORENTEL = "" Then
                    pstrRENTEL2 = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2"))
                    pstrRENTEL2_BIKO = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2_BIKO"))
                    pstrRENTEL2_UPD_DATE = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2_UPD_DATE"))
                    pstrRENTEL3 = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3"))
                    pstrRENTEL3_BIKO = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3_BIKO"))
                    pstrRENTEL3_UPD_DATE = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3_UPD_DATE"))
                    pstrTELAB = Convert.ToString(ds.Tables(0).Rows(0).Item("TELAB"))          ' 2016/12/20 H.Mori add 2016���P�J�� No4-3
                    pstrDAI3RENDORENTEL = Convert.ToString(ds.Tables(0).Rows(0).Item("DAI3RENDORENTEL"))  ' 2016/12/20 H.Mori add 2016���P�J�� No4-3
                End If
                '�ڋq�̃f�[�^�����݂�����ڋq�c�a���X�V����
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("SHAMAS ")
                strSQL.Append("SET ")
                If Convert.ToString(ds.Tables(0).Rows(0).Item("USR_MEMO")) <> pstrGENIN_KIJI Then
                    '���q�l�L�����ύX���ꂽ��
                    strSQL.Append("USR_MEMO = :USR_MEMO ")
                    intCnt = intCnt + 1
                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("USR_MEMO") = pstrGENIN_KIJI
                End If
                strSQL.Append("WHERE CLI_CD = :CLI_CD")
                strSQL.Append("  AND HAN_CD = :HAN_CD ")
                strSQL.Append("  AND USER_CD = :USER_CD ")
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '��ł��ύX���ꂽ�f�[�^����������SQL���s
                If intCnt > 0 Then
                    '�p�����[�^�ɒl���Z�b�g
                    cdb.pSQLParamStr("CLI_CD") = pstrKURACD     '//�N���C�A���g�R�[�h
                    cdb.pSQLParamStr("HAN_CD") = pstrACBCD      '//�i�`�x���R�[�h
                    cdb.pSQLParamStr("USER_CD") = pstrUSER_CD   '//���q�l�R�[�h
                    cdb.mExecQuery()
                End If
            End If

            '���̂̎擾�i��ʂ���̓R�[�h�݂̂̎擾�����Ă������)
            '//�S�_�x���R�[�h
            Dim strZSISYO As String = fncGET_ZSISYO(pstrKURACD)
            '//�����敪�E���e
            Dim strHATKBN_NAI As String = fncGET_PULLNM("08", pstrHATKBN)
            '//�Ή��敪�E���e
            Dim strTAIOKBN_NAI As String = fncGET_PULLNM("09", pstrTAIOKBN)
            '//�����敪�E���e
            Dim strTMSKB_NAI As String = fncGET_PULLNM("10", pstrTMSKB)
            '//�Ď��Z���^�[�S���Җ�
            Dim strTKTANCD_NM As String = fncGET_TKTAN(pstrKANSICD, pstrTKTANCD)
            '//�A�����薼
            Dim strTAITNM As String = fncGET_PULLNM("12", pstrTAITCD)
            '//�d�b�A���E���e
            Dim strTELRNM As String = fncGET_PULLNM("15", pstrTELRCD)
            '//���A�Ή��E���e
            Dim strTFKINM As String = fncGET_PULLNM("14", pstrTFKICD)
            '//�K�X���E���e
            Dim strTKIGNM As String = fncGET_PULLNM("16", pstrTKIGCD)
            '//�쓮�����E���e
            Dim strTSADNM As String = fncGET_PULLNM("17", pstrTSADCD)
            '//�o���w���E���e
            Dim strSDNM As String = fncGET_PULLNM("18", pstrSDCD)
            '//�o����Џ����敪�E���e 2008/10/17 T.Watabe add
            Dim strSDSKBN_NAI As String = ""


            If ((pstrSeniPG = "KEJUKJAG00") Or (pstrSeniPG = "MSKOSJAG00")) Then
                '*******************************************
                '�x���M�p�l���A�܂��͌ڋq��������̑J�ڂ������ꍇ
                '*******************************************
                mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Taiou2 pstrSeniPG=" & pstrSeniPG & ",pstrKURACD=" & pstrKURACD & ",pstrJACD=" & pstrJACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrHATYMD=" & pstrHATYMD & ",pstrHATTIME=" & pstrHATTIME)

                '//�����ԍ��̎擾
                strSQL = New StringBuilder("")
                strSQL.Append("SELECT ")
                'strSQL.Append("'" & Now.ToString("yy") & "' || LPAD(S00_TAIOUSEQ.NEXTVAL,7,'0') AS SEQNO ") '--- 2005/05/17 MOD Falcon ---
                strSQL.Append("'" & Now.ToString("yy") & "' || LPAD(S00_TAIOUSEQ.NEXTVAL,9,'0') AS SEQNO ")
                strSQL.Append("FROM DUAL ")
                cdb.pSQL = strSQL.ToString  'SQL���Z�b�g
                cdb.mExecQuery()            'SQL���s
                ds = cdb.pResult            '�f�[�^�Z�b�g�ɒl���i�[
                strSeqno = Convert.ToString(ds.Tables(0).Rows(0).Item("SEQNO"))  '�����ԍ���ϐ��Ɋi�[

                '2012/03/30 ADD START W.GANEKO
                '8���ԓ��ɓ���x�񂪂������ꍇ�A�d���ɂ���B
                '2012/04/27 add �x���M�p�l���̎������d�������ɂ���B
                'If (pstrSeniPG = "KEJUKJAG00") Then
                '    If (getSqlDupTaiou(cdb, pstrKANSICD, _
                '                       strSeqno, _
                '                       pstrKMCD1, _
                '                       pstrKMNM1, _
                '                       pstrKMCD2, _
                '                       pstrKMNM2, _
                '                       pstrKMCD3, _
                '                       pstrKMNM3, _
                '                       pstrKMCD4, _
                '                       pstrKMNM4, _
                '                       pstrKMCD5, _
                '                       pstrKMNM5, _
                '                       pstrKMCD6, _
                '                       pstrKMNM6, _
                '                       pstrKURACD, _
                '                       pstrJACD, _
                '                       pstrACBCD, _
                '                       pstrUSER_CD, _
                '                       pstrHATYMD, _
                '                       pstrHATTIME _
                '                       )) Then
                '        pstrTAIOKBN = "3"
                '        strTAIOKBN_NAI = fncGET_PULLNM("09", pstrTAIOKBN)
                '        pstrFAXKBN = "1"
                '        pstrFAXKURAKBN = "1"
                '    End If
                'End If
                '//��ʂ̃f�[�^�̂h�m�r�d�q�s���s��
                strSQL = New StringBuilder("")
                strSQL.Append("INSERT INTO ")
                strSQL.Append("D20_TAIOU (")
                strSQL.Append("KANSCD, ")
                strSQL.Append("SYONO, ")
                strSQL.Append("HATYMD, ")
                strSQL.Append("HATTIME, ")
                strSQL.Append("KENSIN, ")
                strSQL.Append("KEIHOSU, ")
                strSQL.Append("RYURYO, ")
                strSQL.Append("METASYU, ")
                strSQL.Append("UNYO, ")
                strSQL.Append("JUYMD, ")
                strSQL.Append("JUTIME, ")
                strSQL.Append("NUM_DIGIT, ")
                strSQL.Append("KMCD1, ")
                strSQL.Append("KMNM1, ")
                strSQL.Append("KMCD2, ")
                strSQL.Append("KMNM2, ")
                strSQL.Append("KMCD3, ")
                strSQL.Append("KMNM3, ")
                strSQL.Append("KMCD4, ")
                strSQL.Append("KMNM4, ")
                strSQL.Append("KMCD5, ")
                strSQL.Append("KMNM5, ")
                strSQL.Append("KMCD6, ")
                strSQL.Append("KMNM6, ")
                strSQL.Append("ZSISYO, ")
                strSQL.Append("KURACD, ")
                strSQL.Append("KENNM, ")
                strSQL.Append("JACD, ")
                strSQL.Append("JANM, ")
                strSQL.Append("HANJICD, ")   ' �̔����Ǝ҃R�[�h 2014/12/17 T.Ono add 2014���P�J�� No2
                strSQL.Append("HANJINM, ")   ' �̔����ƎҖ�     2014/12/17 T.Ono add 2014���P�J�� No2
                strSQL.Append("ACBCD, ")
                strSQL.Append("ACBNM, ")
                strSQL.Append("USER_CD, ")
                strSQL.Append("JUSYONM, ")
                strSQL.Append("JUSYOKN, ")
                strSQL.Append("JUTEL1, ")
                strSQL.Append("JUTEL2, ")
                strSQL.Append("RENTEL, ")
                strSQL.Append("KTELNO, ")
                strSQL.Append("ADDR, ")
                strSQL.Append("USER_KIJI, ")
                strSQL.Append("NCU_SET, ")
                strSQL.Append("TIZUNO, ")
                strSQL.Append("HANBAI_KBN, ") '�̔��敪 2015/11/25 H.Mori add 2015���P�J�� No1 
                strSQL.Append("KYOKTKBN, ") '�����`�ԋ敪 2016/12/14 H.Mori add 2016���P�J�� No4-3
                strSQL.Append("MET_KATA, ")
                strSQL.Append("MET_MAKER, ")
                strSQL.Append("BONB1_KKG, ")
                strSQL.Append("BONB1_HON, ")
                strSQL.Append("BONB1_YOBI, ")
                strSQL.Append("BONB2_KKG, ")
                strSQL.Append("BONB2_HON, ")
                strSQL.Append("BONB2_YOBI, ")
                strSQL.Append("BONB3_KKG, ")
                strSQL.Append("BONB3_HON, ")
                strSQL.Append("BONB3_YOBI, ")
                strSQL.Append("BONB4_KKG, ")
                strSQL.Append("BONB4_HON, ")
                strSQL.Append("BONB4_YOBI, ")
                strSQL.Append("ZENKAI_HAISO, ")
                strSQL.Append("ZENKAI_HAI_S, ")
                strSQL.Append("KONKAI_HAISO, ")
                strSQL.Append("KONKAI_HAI_S, ")
                strSQL.Append("JIKAI_HAISO, ")
                strSQL.Append("ZENKAI_KENSIN, ")
                strSQL.Append("ZENKAI_KEN_S, ")
                strSQL.Append("ZENKAI_KEN_SIYO, ")
                strSQL.Append("KONKAI_KENSIN, ")
                strSQL.Append("KONKAI_KEN_S, ")
                strSQL.Append("KONKAI_KEN_SIYO, ")
                strSQL.Append("ZENKAI_HASEI, ")
                strSQL.Append("ZENKAI_HAS_S, ")
                strSQL.Append("KONKAI_HASEI, ")
                strSQL.Append("KONKAI_HAS_S, ")
                strSQL.Append("G_ZAIKO, ")
                strSQL.Append("ICHI_SIYO, ")
                strSQL.Append("YOSOKU_ICHI_SIYO, ")
                strSQL.Append("GAS1_HINMEI, ")
                strSQL.Append("GAS1_DAISU, ")
                strSQL.Append("GAS1_SEIFL, ")
                strSQL.Append("GAS2_HINMEI, ")
                strSQL.Append("GAS2_DAISU, ")
                strSQL.Append("GAS2_SEIFL, ")
                strSQL.Append("GAS3_HINMEI, ")
                strSQL.Append("GAS3_DAISU, ")
                strSQL.Append("GAS3_SEIFL, ")
                strSQL.Append("GAS4_HINMEI, ")
                strSQL.Append("GAS4_DAISU, ")
                strSQL.Append("GAS4_SEIFL, ")
                strSQL.Append("GAS5_HINMEI, ")
                strSQL.Append("GAS5_DAISU, ")
                strSQL.Append("GAS5_SEIFL, ")
                strSQL.Append("HATKBN, ")
                strSQL.Append("HATKBN_NAI, ")
                strSQL.Append("TAIOKBN, ")
                strSQL.Append("TAIOKBN_NAI, ")
                strSQL.Append("TMSKB, ")
                strSQL.Append("TMSKB_NAI, ")
                strSQL.Append("TKTANCD, ")
                strSQL.Append("TKTANCD_NM, ")
                strSQL.Append("TAITCD, ")
                strSQL.Append("TAITNM, ")
                strSQL.Append("TAIO_ST_DATE, ")
                strSQL.Append("TAIO_ST_TIME, ")
                strSQL.Append("SYOYMD, ")
                strSQL.Append("SYOTIME, ")
                strSQL.Append("TAIO_SYO_TIME, ")
                strSQL.Append("FAXKBN, ")
                strSQL.Append("FAXKURAKBN, ") ' 2010/07/12 T.Watabe add
                strSQL.Append("FAXRUISEKIKBN, ") ' 2015/11/17 H.Mori add 2015���P�J�� No1 
                strSQL.Append("TELRCD, ")
                strSQL.Append("TELRNM, ")
                strSQL.Append("TFKICD, ")
                strSQL.Append("TFKINM, ")
                strSQL.Append("FUK_MEMO, ")
                strSQL.Append("TEL_MEMO1, ")
                strSQL.Append("TEL_MEMO2, ")
                strSQL.Append("TEL_MEMO4, ")        '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("TEL_MEMO5, ")        '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("TEL_MEMO6, ")        '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("MITOKBN, ")
                strSQL.Append("TKIGCD, ")
                strSQL.Append("TKIGNM, ")
                strSQL.Append("TSADCD, ")
                strSQL.Append("TSADNM, ")
                strSQL.Append("GENIN_KIJI, ")
                strSQL.Append("SDCD, ")
                strSQL.Append("SDNM, ")
                strSQL.Append("SIJIYMD, ")
                strSQL.Append("SIJITIME, ")
                strSQL.Append("SIJI_BIKO1, ")
                strSQL.Append("SIJI_BIKO2, ")
                strSQL.Append("STD_JASCD, ")
                strSQL.Append("STD_JANA, ")
                strSQL.Append("STD_JASNA, ")
                strSQL.Append("REN_NA, ")
                strSQL.Append("REN_TEL_1, ")
                strSQL.Append("REN_TEL_2, ")
                strSQL.Append("REN_TEL_3, ")        '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append("REN_FAX, ")
                strSQL.Append("REN_BIKO, ")
                strSQL.Append("REN_1_NA, ")
                strSQL.Append("REN_1_TEL1, ")
                strSQL.Append("REN_1_TEL2, ")
                strSQL.Append("REN_1_TEL3, ")       '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append("REN_1_FAX, ")
                strSQL.Append("REN_1_BIKO, ")
                strSQL.Append("REN_2_NA, ")
                strSQL.Append("REN_2_TEL1, ")
                strSQL.Append("REN_2_TEL2, ")
                strSQL.Append("REN_2_TEL3, ")       '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append("REN_2_FAX, ")
                strSQL.Append("REN_2_BIKO, ")
                strSQL.Append("REN_3_NA, ")
                strSQL.Append("REN_3_TEL1, ")
                strSQL.Append("REN_3_TEL2, ")
                strSQL.Append("REN_3_TEL3, ")       '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append("REN_3_FAX, ")
                strSQL.Append("REN_3_BIKO, ")
                strSQL.Append("STD_CD, ")
                strSQL.Append("STD, ")
                strSQL.Append("STD_KYOTEN_CD, ")
                strSQL.Append("STD_KYOTEN, ")
                strSQL.Append("STD_TEL, ")
                strSQL.Append("TEL_BIKO, ")
                strSQL.Append("FAX_TITLE, ")
                strSQL.Append("FAX_REN, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("EDT_TIME, ")
                '--- ��2005/09/09 ADD Falcon�� ---
                strSQL.Append("BIKOU, ")
                strSQL.Append("FAX_TITLE_CD, ")
                '--- ��2005/09/09 ADD Falcon�� ---
                '//�Ή�DB�ǉ�����----------------
                strSQL.Append("BOMB_TYPE, ")
                strSQL.Append("GAS_STOP, ")
                strSQL.Append("GAS_DELE, ")
                strSQL.Append("GAS_RESTART, ")
                strSQL.Append("LTOS_DATE, ")
                '//------------------------------
                '2016/02/02 w.ganeko 2015���P�J�� ��1-3 start
                strSQL.Append("KANSHI_BIKO, ")
                strSQL.Append("RENTEL2, ")
                strSQL.Append("RENTEL2_BIKO, ")
                strSQL.Append("RENTEL2_UPD_DATE, ")
                strSQL.Append("RENTEL3, ")
                strSQL.Append("RENTEL3_BIKO, ")
                strSQL.Append("RENTEL3_UPD_DATE, ")
                '2016/02/02 w.ganeko 2015���P�J�� ��1-3 end
                '2016/12/14 H.Mori add 2016���P�J�� No4-6,No4-1 START
                strSQL.Append("TUSIN, ")
                strSQL.Append("FAXSPOTKBN, ")
                strSQL.Append("TELAB, ")
                strSQL.Append("DAI3RENDORENTEL, ")
                strSQL.Append("DAIHYO_NAME, ")
                strSQL.Append("HOKBN, ")
                strSQL.Append("YOTOKBN, ")
                strSQL.Append("HANBCD, ")
                strSQL.Append("KINRENCD, ")
                '2016/12/22 H.Mori add 2016���P�J�� No4-6,No4-1 END
                '2017/10/16 H.Mori add 2017���P�J�� No4-1 START
                strSQL.Append("SHUGOU, ")
                '2017/10/16 H.Mori add 2017���P�J�� No4-1 END
                strSQL.Append("SDYMD, ")      ' 2008/10/15 T.Watabe add
                strSQL.Append("SDTIME, ")     ' 2008/10/15 T.Watabe add
                strSQL.Append("SDSKBN, ")     ' 2008/10/15 T.Watabe add
                strSQL.Append("SDSKBN_NAI, ") ' 2008/10/15 T.Watabe add
                strSQL.Append("NCUHATYMD, ")  ' 2008/10/15 T.Watabe add
                strSQL.Append("NCUHATTIME, ")  ' 2008/10/15 T.Watabe add
                strSQL.Append("SYORI_SERIAL ")  ' 2012/06/28 W.GANEKO add
                strSQL.Append(", KAITU_DAY ") ' �{���H���� 2013/08/23 T.Ono add �Ď����P2013��1
                strSQL.Append(", JMNAME ") ' JM�a�� 2023/01/04 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 
                strSQL.Append(") VALUES(")
                strSQL.Append(":KANSCD, ")
                strSQL.Append(":SYONO, ")
                strSQL.Append(":HATYMD, ")
                strSQL.Append(":HATTIME, ")
                strSQL.Append(":KENSIN, ")
                strSQL.Append(":KEIHOSU, ")
                strSQL.Append(":RYURYO, ")
                strSQL.Append(":METASYU, ")
                strSQL.Append(":UNYO, ")
                strSQL.Append(":JUYMD, ")
                strSQL.Append(":JUTIME, ")
                strSQL.Append(":NUM_DIGIT, ")
                strSQL.Append(":KMCD1, ")
                strSQL.Append(":KMNM1, ")
                strSQL.Append(":KMCD2, ")
                strSQL.Append(":KMNM2, ")
                strSQL.Append(":KMCD3, ")
                strSQL.Append(":KMNM3, ")
                strSQL.Append(":KMCD4, ")
                strSQL.Append(":KMNM4, ")
                strSQL.Append(":KMCD5, ")
                strSQL.Append(":KMNM5, ")
                strSQL.Append(":KMCD6, ")
                strSQL.Append(":KMNM6, ")
                strSQL.Append(":ZSISYO, ")
                strSQL.Append(":KURACD, ")
                strSQL.Append(":KENNM, ")
                strSQL.Append(":JACD, ")
                strSQL.Append(":JANM, ")
                strSQL.Append(":HANJICD, ")  ' 2014/12/17 T.Ono add 2014���P�J�� No2
                strSQL.Append(":HANJINM, ")  ' 2014/12/17 T.Ono add 2014���P�J�� No2
                strSQL.Append(":ACBCD, ")
                strSQL.Append(":ACBNM, ")
                strSQL.Append(":USER_CD, ")
                strSQL.Append(":JUSYONM, ")
                strSQL.Append(":JUSYOKN, ")
                strSQL.Append(":JUTEL1, ")
                strSQL.Append(":JUTEL2, ")
                strSQL.Append(":RENTEL, ")
                strSQL.Append(":KTELNO, ")
                strSQL.Append(":ADDR, ")
                '--- ��2005/09/09 MOD Falcon�� ---
                'strSQL.Append(":USER_KIJI, ")
                strSQL.Append("NULL, ")
                '--- ��2005/09/09 MOD Falcon�� ---
                strSQL.Append(":NCU_SET, ")
                strSQL.Append(":TIZUNO, ")
                strSQL.Append(":HANBAI_KBN, ") '�̔��敪 2015/11/25 H.Mori add 2015���P�J�� No1 
                strSQL.Append(":KYOKTKBN, ")   '�����`�ԋ敪 2016/12/14 H.Mori add 2016���P�J�� No4-3
                strSQL.Append(":MET_KATA, ")
                strSQL.Append(":MET_MAKER, ")
                strSQL.Append(":BONB1_KKG, ")
                strSQL.Append(":BONB1_HON, ")
                strSQL.Append(":BONB1_YOBI, ")
                strSQL.Append(":BONB2_KKG, ")
                strSQL.Append(":BONB2_HON, ")
                strSQL.Append(":BONB2_YOBI, ")
                strSQL.Append(":BONB3_KKG, ")
                strSQL.Append(":BONB3_HON, ")
                strSQL.Append(":BONB3_YOBI, ")
                strSQL.Append(":BONB4_KKG, ")
                strSQL.Append(":BONB4_HON, ")
                strSQL.Append(":BONB4_YOBI, ")
                strSQL.Append(":ZENKAI_HAISO, ")
                strSQL.Append(":ZENKAI_HAI_S, ")
                strSQL.Append(":KONKAI_HAISO, ")
                strSQL.Append(":KONKAI_HAI_S, ")
                strSQL.Append(":JIKAI_HAISO, ")
                strSQL.Append(":ZENKAI_KENSIN, ")
                strSQL.Append(":ZENKAI_KEN_S, ")
                strSQL.Append(":ZENKAI_KEN_SIYO, ")
                strSQL.Append(":KONKAI_KENSIN, ")
                strSQL.Append(":KONKAI_KEN_S, ")
                strSQL.Append(":KONKAI_KEN_SIYO, ")
                strSQL.Append(":ZENKAI_HASEI, ")
                strSQL.Append(":ZENKAI_HAS_S, ")
                strSQL.Append(":KONKAI_HASEI, ")
                strSQL.Append(":KONKAI_HAS_S, ")
                strSQL.Append(":G_ZAIKO, ")
                strSQL.Append(":ICHI_SIYO, ")
                strSQL.Append(":YOSOKU_ICHI_SIYO, ")
                strSQL.Append(":GAS1_HINMEI, ")
                strSQL.Append(":GAS1_DAISU, ")
                strSQL.Append(":GAS1_SEIFL, ")
                strSQL.Append(":GAS2_HINMEI, ")
                strSQL.Append(":GAS2_DAISU, ")
                strSQL.Append(":GAS2_SEIFL, ")
                strSQL.Append(":GAS3_HINMEI, ")
                strSQL.Append(":GAS3_DAISU, ")
                strSQL.Append(":GAS3_SEIFL, ")
                strSQL.Append(":GAS4_HINMEI, ")
                strSQL.Append(":GAS4_DAISU, ")
                strSQL.Append(":GAS4_SEIFL, ")
                strSQL.Append(":GAS5_HINMEI, ")
                strSQL.Append(":GAS5_DAISU, ")
                strSQL.Append(":GAS5_SEIFL, ")
                strSQL.Append(":HATKBN, ")
                strSQL.Append(":HATKBN_NAI, ")
                strSQL.Append(":TAIOKBN, ")
                strSQL.Append(":TAIOKBN_NAI, ")
                strSQL.Append(":TMSKB, ")
                strSQL.Append(":TMSKB_NAI, ")
                strSQL.Append(":TKTANCD, ")
                strSQL.Append(":TKTANCD_NM, ")
                strSQL.Append(":TAITCD, ")
                strSQL.Append(":TAITNM, ")
                strSQL.Append(":TAIO_ST_DATE, ")
                strSQL.Append(":TAIO_ST_TIME, ")
                strSQL.Append(":SYOYMD, ")
                strSQL.Append(":SYOTIME, ")
                strSQL.Append(":TAIO_SYO_TIME, ")
                strSQL.Append(":FAXKBN, ")
                strSQL.Append(":FAXKURAKBN, ") ' 2010/07/12 T.Watabe add
                strSQL.Append(":FAXRUISEKIKBN, ") ' 2015/11/17 H.Mori add 2015���P�J�� No1
                strSQL.Append(":TELRCD, ")
                strSQL.Append(":TELRNM, ")
                strSQL.Append(":TFKICD, ")
                strSQL.Append(":TFKINM, ")
                strSQL.Append(":FUK_MEMO, ")
                strSQL.Append(":TEL_MEMO1, ")
                strSQL.Append(":TEL_MEMO2, ")
                strSQL.Append(":TEL_MEMO4, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append(":TEL_MEMO5, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append(":TEL_MEMO6, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append(":MITOKBN, ")
                strSQL.Append(":TKIGCD, ")
                strSQL.Append(":TKIGNM, ")
                strSQL.Append(":TSADCD, ")
                strSQL.Append(":TSADNM, ")
                strSQL.Append(":GENIN_KIJI, ")
                strSQL.Append(":SDCD, ")
                strSQL.Append(":SDNM, ")
                strSQL.Append(":SIJIYMD, ")
                strSQL.Append(":SIJITIME, ")
                strSQL.Append(":SIJI_BIKO1, ")
                strSQL.Append(":SIJI_BIKO2, ")
                strSQL.Append(":STD_JASCD, ")
                strSQL.Append(":STD_JANA, ")
                strSQL.Append(":STD_JASNA, ")
                strSQL.Append(":REN_NA, ")
                strSQL.Append(":REN_TEL_1, ")
                strSQL.Append(":REN_TEL_2, ")
                strSQL.Append(":REN_TEL_3, ")       '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append(":REN_FAX, ")
                strSQL.Append(":REN_BIKO, ")
                strSQL.Append(":REN_1_NA, ")
                strSQL.Append(":REN_1_TEL1, ")
                strSQL.Append(":REN_1_TEL2, ")
                strSQL.Append(":REN_1_TEL3, ")      '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append(":REN_1_FAX, ")
                strSQL.Append(":REN_1_BIKO, ")
                strSQL.Append(":REN_2_NA, ")
                strSQL.Append(":REN_2_TEL1, ")
                strSQL.Append(":REN_2_TEL2, ")
                strSQL.Append(":REN_2_TEL3, ")      '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append(":REN_2_FAX, ")
                strSQL.Append(":REN_2_BIKO, ")
                strSQL.Append(":REN_3_NA, ")
                strSQL.Append(":REN_3_TEL1, ")
                strSQL.Append(":REN_3_TEL2, ")
                strSQL.Append(":REN_3_TEL3, ")      '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append(":REN_3_FAX, ")
                strSQL.Append(":REN_3_BIKO, ")
                strSQL.Append(":STD_CD, ")
                strSQL.Append(":STD, ")
                strSQL.Append(":STD_KYOTEN_CD, ")
                strSQL.Append(":STD_KYOTEN, ")
                strSQL.Append(":STD_TEL, ")
                strSQL.Append(":TEL_BIKO, ")
                strSQL.Append(":FAX_TITLE, ")
                strSQL.Append(":FAX_REN, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":EDT_TIME, ")
                '--- ��2005/09/09 ADD Falcon�� ---
                strSQL.Append(":BIKOU, ")
                strSQL.Append(":FAX_TITLE_CD, ")
                '--- ��2005/09/09 ADD Falcon�� ---
                '//�Ή�DB�ǉ�����----------------
                strSQL.Append(":BOMB_TYPE, ")
                strSQL.Append(":GAS_STOP, ")
                strSQL.Append(":GAS_DELE, ")
                strSQL.Append(":GAS_RESTART, ")
                strSQL.Append(":LTOS_DATE, ")
                '2016/02/02 w.ganeko 2015���P�J�� ��1-3 start
                strSQL.Append(":KANSHI_BIKO, ")
                strSQL.Append(":RENTEL2, ")
                strSQL.Append(":RENTEL2_BIKO, ")
                strSQL.Append(":RENTEL2_UPD_DATE, ")
                strSQL.Append(":RENTEL3, ")
                strSQL.Append(":RENTEL3_BIKO, ")
                strSQL.Append(":RENTEL3_UPD_DATE, ")
                '2016/02/02 w.ganeko 2015���P�J�� ��1-3 end
                '2016/12/14 H.Mori add 2016���P�J�� No4-6,No4-1 START
                strSQL.Append(":TUSIN, ")
                strSQL.Append(":FAXSPOTKBN, ")
                strSQL.Append(":TELAB, ")
                strSQL.Append(":DAI3RENDORENTEL, ")
                strSQL.Append(":DAIHYO_NAME, ")
                strSQL.Append(":HOKBN, ")
                strSQL.Append(":YOTOKBN, ")
                strSQL.Append(":HANBCD, ")
                strSQL.Append(":KINRENCD, ")
                '2016/12/22 H.Mori add 2016���P�J�� No4-6,No4-1 END
                '2017/10/16 H.Mori add 2017���P�J�� No4-1 START
                strSQL.Append(":SHUGOU, ")
                '2017/10/16 H.Mori add 2017���P�J�� No4-1 END
                '//------------------------------
                strSQL.Append("NULL, ")       ' 2008/10/15 T.Watabe add
                strSQL.Append("NULL, ")       ' 2008/10/15 T.Watabe add
                strSQL.Append(":SDSKBN, ")     ' 2008/10/17 T.Watabe add
                strSQL.Append(":SDSKBN_NAI, ") ' 2008/10/17 T.Watabe add
                strSQL.Append(":NCUHATYMD, ")  ' 2008/10/15 T.Watabe add
                strSQL.Append(":NCUHATTIME, ")  ' 2008/10/15 T.Watabe add
                strSQL.Append(":SYORI_SERIAL ")  ' 2012/06/28 W.GANEKO add
                strSQL.Append(", TO_DATE( :KAITU_DAY, 'YYYY/MM/DD HH24:MI:SS')")  ' �{���H���� 2013/08/23 T.Ono add �Ď����P2013��1
                strSQL.Append(", :JMNAME")  ' JM�a�� 2023/01/04 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή�
                strSQL.Append(")")
            ElseIf pstrSeniPG = "KEKEKJAG00" Then
                '*******************************************
                '�Ή����ʈꗗ����̑J�ڂ������ꍇ
                '*******************************************
                '//�����ԍ��̎擾
                mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Taiou2 pstrSeniPG=" & pstrSeniPG & ",pstrKURACD=" & pstrKURACD & ",pstrJACD=" & pstrJACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrHATYMD=" & pstrHATYMD & ",pstrHATTIME=" & pstrHATTIME)
                strSeqno = pstrSYONO
                '//��ʂ̃f�[�^�̂t�o�c�`�s�d���s��
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("D20_TAIOU ")
                strSQL.Append("SET ")
                '���p�ғ��͍���--------
                strSQL.Append("ZSISYO = :ZSISYO, ")
                strSQL.Append("KURACD = :KURACD, ")
                strSQL.Append("KENNM = :KENNM, ")
                strSQL.Append("JACD = :JACD, ")
                strSQL.Append("JANM = :JANM, ")
                strSQL.Append("HANJICD = :HANJICD, ")     ' 2014/12/17 T.Ono add 2014���P�J�� No2
                strSQL.Append("HANJINM = :HANJINM, ")     ' 2014/12/17 T.Ono add 2014���P�J�� No2
                strSQL.Append("ACBCD = :ACBCD, ")
                strSQL.Append("ACBNM = :ACBNM, ")
                strSQL.Append("USER_CD = :USER_CD, ")
                strSQL.Append("JUSYONM = :JUSYONM, ")
                strSQL.Append("JUSYOKN = :JUSYOKN, ")
                strSQL.Append("JUTEL1 = :JUTEL1, ")
                strSQL.Append("JUTEL2 = :JUTEL2, ")
                strSQL.Append("RENTEL = :RENTEL, ")
                '�x�񃁃b�Z�[�W����-------- 2007/04/25 T.Watabe add
                strSQL.Append("KMCD1 = :KMCD1, ")
                strSQL.Append("KMNM1 = :KMNM1, ")
                strSQL.Append("KMCD2 = :KMCD2, ")
                strSQL.Append("KMNM2 = :KMNM2, ")
                strSQL.Append("KMCD3 = :KMCD3, ")
                strSQL.Append("KMNM3 = :KMNM3, ")
                strSQL.Append("KMCD4 = :KMCD4, ")
                strSQL.Append("KMNM4 = :KMNM4, ")
                strSQL.Append("KMCD5 = :KMCD5, ")
                strSQL.Append("KMNM5 = :KMNM5, ")
                strSQL.Append("KMCD6 = :KMCD6, ")
                strSQL.Append("KMNM6 = :KMNM6, ")
                strSQL.Append("HATYMD = :HATYMD, ")
                strSQL.Append("HATTIME = :HATTIME, ")
                '----------------------
                strSQL.Append("ADDR = :ADDR, ")
                strSQL.Append("HATKBN = :HATKBN, ")
                strSQL.Append("HATKBN_NAI = :HATKBN_NAI, ")
                strSQL.Append("TAIOKBN = :TAIOKBN, ")
                strSQL.Append("TAIOKBN_NAI = :TAIOKBN_NAI, ")
                strSQL.Append("TMSKB = :TMSKB, ")
                strSQL.Append("TMSKB_NAI = :TMSKB_NAI, ")
                strSQL.Append("TKTANCD = :TKTANCD, ")
                strSQL.Append("TKTANCD_NM = :TKTANCD_NM, ")
                strSQL.Append("TAITCD = :TAITCD, ")
                strSQL.Append("TAITNM = :TAITNM, ")
                strSQL.Append("TAIO_ST_DATE = :TAIO_ST_DATE, ")
                strSQL.Append("TAIO_ST_TIME = :TAIO_ST_TIME, ")
                strSQL.Append("SYOYMD = :SYOYMD, ")
                strSQL.Append("SYOTIME = :SYOTIME, ")
                strSQL.Append("TAIO_SYO_TIME = :TAIO_SYO_TIME, ")
                strSQL.Append("FAXKBN = :FAXKBN, ")
                strSQL.Append("FAXKURAKBN = :FAXKURAKBN, ")  ' 2010/07/12 T.Watabe add
                strSQL.Append("FAXRUISEKIKBN = :FAXRUISEKIKBN, ") ' 2015/11/17 H.Mori add 2015���P�J�� No1 
                strSQL.Append("TELRCD = :TELRCD, ")
                strSQL.Append("TELRNM = :TELRNM, ")
                strSQL.Append("TFKICD = :TFKICD, ")
                strSQL.Append("TFKINM = :TFKINM, ")
                strSQL.Append("FUK_MEMO = :FUK_MEMO, ")
                strSQL.Append("TEL_MEMO1 = :TEL_MEMO1, ")
                strSQL.Append("TEL_MEMO2 = :TEL_MEMO2, ")
                strSQL.Append("TEL_MEMO4 = :TEL_MEMO4, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("TEL_MEMO5 = :TEL_MEMO5, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("TEL_MEMO6 = :TEL_MEMO6, ")       '2020/11/01 T.Ono add 2020�Ď����P
                strSQL.Append("MITOKBN = :MITOKBN, ")
                strSQL.Append("TKIGCD = :TKIGCD, ")
                strSQL.Append("TKIGNM = :TKIGNM, ")
                strSQL.Append("TSADCD = :TSADCD, ")
                strSQL.Append("TSADNM = :TSADNM, ")
                strSQL.Append("GENIN_KIJI = :GENIN_KIJI, ")
                strSQL.Append("SDCD = :SDCD, ")
                strSQL.Append("SDNM = :SDNM, ")
                strSQL.Append("SIJIYMD = :SIJIYMD, ")
                strSQL.Append("SIJITIME = :SIJITIME, ")
                strSQL.Append("SIJI_BIKO1 = :SIJI_BIKO1, ")
                strSQL.Append("SIJI_BIKO2 = :SIJI_BIKO2, ")
                strSQL.Append("STD_JASCD = :STD_JASCD, ")
                strSQL.Append("STD_JANA = :STD_JANA, ")
                strSQL.Append("STD_JASNA = :STD_JASNA, ")
                strSQL.Append("REN_NA = :REN_NA, ")
                strSQL.Append("REN_TEL_1 = :REN_TEL_1, ")
                strSQL.Append("REN_TEL_2 = :REN_TEL_2, ")
                strSQL.Append("REN_TEL_3 = :REN_TEL_3, ")       '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append("REN_FAX = :REN_FAX, ")
                strSQL.Append("REN_BIKO = :REN_BIKO, ")
                strSQL.Append("REN_1_NA = :REN_1_NA, ")
                strSQL.Append("REN_1_TEL1 = :REN_1_TEL1, ")
                strSQL.Append("REN_1_TEL2 = :REN_1_TEL2, ")
                strSQL.Append("REN_1_TEL3 = :REN_1_TEL3, ")     '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append("REN_1_FAX = :REN_1_FAX, ")
                strSQL.Append("REN_1_BIKO = :REN_1_BIKO, ")
                strSQL.Append("REN_2_NA = :REN_2_NA, ")
                strSQL.Append("REN_2_TEL1 = :REN_2_TEL1, ")
                strSQL.Append("REN_2_TEL2 = :REN_2_TEL2, ")
                strSQL.Append("REN_2_TEL3 = :REN_2_TEL3, ")     '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append("REN_2_FAX = :REN_2_FAX, ")
                strSQL.Append("REN_2_BIKO = :REN_2_BIKO, ")
                strSQL.Append("REN_3_NA = :REN_3_NA, ")
                strSQL.Append("REN_3_TEL1 = :REN_3_TEL1, ")
                strSQL.Append("REN_3_TEL2 = :REN_3_TEL2, ")
                strSQL.Append("REN_3_TEL3 = :REN_3_TEL3, ")     '2015/01/05 T.Ono add 2014���P�J��
                strSQL.Append("REN_3_FAX = :REN_3_FAX, ")
                strSQL.Append("REN_3_BIKO = :REN_3_BIKO, ")
                strSQL.Append("STD_CD = :STD_CD, ")
                strSQL.Append("STD = :STD, ")
                strSQL.Append("STD_KYOTEN_CD = :STD_KYOTEN_CD, ")
                strSQL.Append("STD_KYOTEN = :STD_KYOTEN, ")
                strSQL.Append("STD_TEL = :STD_TEL, ")
                strSQL.Append("TEL_BIKO = :TEL_BIKO, ")
                strSQL.Append("FAX_TITLE_CD = :FAX_TITLE_CD, ")       '--- 2005/09/09 ADD Falcon
                strSQL.Append("FAX_TITLE = :FAX_TITLE, ")
                strSQL.Append("FAX_REN = :FAX_REN, ")
                '2016/02/02 w.ganeko 2015���P�J�� ��1-3 start
                strSQL.Append("KANSHI_BIKO = :KANSHI_BIKO, ")
                strSQL.Append("RENTEL2 = :RENTEL2, ")
                strSQL.Append("RENTEL2_BIKO = :RENTEL2_BIKO, ")
                strSQL.Append("RENTEL2_UPD_DATE = :RENTEL2_UPD_DATE, ")
                strSQL.Append("RENTEL3 = :RENTEL3, ")
                strSQL.Append("RENTEL3_BIKO = :RENTEL3_BIKO, ")
                strSQL.Append("RENTEL3_UPD_DATE = :RENTEL3_UPD_DATE, ")
                '2016/02/02 w.ganeko 2015���P�J�� ��1-3 end
                '2016/12/14 H.Mori add 2016���P�J�� No4-6 START
                strSQL.Append("FAXSPOTKBN = :FAXSPOTKBN, ")
                strSQL.Append("TELAB = :TELAB, ")
                strSQL.Append("DAI3RENDORENTEL = :DAI3RENDORENTEL, ")
                strSQL.Append("KINRENCD = :KINRENCD, ")
                strSQL.Append("JMNAME = :JMNAME, ")  ' 2023/01/04 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 
                '2016/12/22 H.Mori add 2016���P�J�� No4-6 END
                strSQL.Append("EDT_DATE    = :EDT_DATE, ")
                strSQL.Append("EDT_TIME    = :EDT_TIME, ")
                strSQL.Append("NCUHATYMD   = :NCUHATYMD, ")  ' 2008/10/15 T.Watabe add
                strSQL.Append("NCUHATTIME  = :NCUHATTIME ")  ' 2008/10/15 T.Watabe add
                strSQL.Append("WHERE ")
                strSQL.Append("      KANSCD = :KANSCD")
                strSQL.Append("  AND SYONO  = :SYONO")
            End If
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�̃Z�b�g
            cdb.pSQLParamStr("KANSCD") = pstrKANSICD
            cdb.pSQLParamStr("SYONO") = strSeqno

            cdb.pSQLParamStr("ZSISYO") = strZSISYO          '�f�[�^�擾
            cdb.pSQLParamStr("KURACD") = pstrKURACD
            cdb.pSQLParamStr("KENNM") = pstrKENNM
            cdb.pSQLParamStr("JACD") = pstrJACD
            cdb.pSQLParamStr("JANM") = pstrJANM
            cdb.pSQLParamStr("HANJICD") = pstrHANJICD       ' 2014/12/17 T.Ono add 2014���P�J�� No2
            cdb.pSQLParamStr("HANJINM") = pstrHANJINM       ' 2014/12/17 T.Ono add 2014���P�J�� No2
            cdb.pSQLParamStr("ACBCD") = pstrACBCD
            cdb.pSQLParamStr("ACBNM") = pstrACBNM
            cdb.pSQLParamStr("USER_CD") = pstrUSER_CD
            cdb.pSQLParamStr("JUSYONM") = pstrJUSYONM
            cdb.pSQLParamStr("JUSYOKN") = pstrJUSYOKN
            cdb.pSQLParamStr("JUTEL1") = pstrJUTEL1
            cdb.pSQLParamStr("JUTEL2") = pstrJUTEL2
            cdb.pSQLParamStr("RENTEL") = pstrRENTEL
            cdb.pSQLParamStr("ADDR") = pstrADDR
            cdb.pSQLParamStr("KINRENCD") = pstrKINRENCD     '�ً}�A����O���[�v�R�[�h 2016/12/22 H.Mori add 2016���P�J�� No4-6 END
            cdb.pSQLParamStr("JMNAME") = pstrJMNAME     'JM�a�� 2023/01/04 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� 

            If ((pstrSeniPG = "KEJUKJAG00") Or (pstrSeniPG = "MSKOSJAG00")) Then
                cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL '2012/06/28 add W.GANEKO
                '*******************************************
                '�x���M�p�l���A�܂��͌ڋq��������̑J�ڂ������ꍇ
                '*******************************************

                ' 2008/10/15 T.Watabe add
                If pstrNCUHATYMD.Length = 0 Then       '�x��ɂċ�f�[�^�����Ă��܂����ꍇ��[ALL0]
                    cdb.pSQLParamStr("NCUHATYMD") = "00000000"
                Else
                    cdb.pSQLParamStr("NCUHATYMD") = pstrNCUHATYMD
                End If
                If pstrNCUHATTIME.Length = 0 Then      '�x��ɂċ�f�[�^�����Ă��܂����ꍇ��[ALL0]
                    cdb.pSQLParamStr("NCUHATTIME") = "000000"
                Else
                    cdb.pSQLParamStr("NCUHATTIME") = pstrNCUHATTIME
                End If

                If pstrHATYMD.Length = 0 Then       '�x��ɂċ�f�[�^�����Ă��܂����ꍇ��[ALL0]
                    cdb.pSQLParamStr("HATYMD") = "00000000"
                Else
                    cdb.pSQLParamStr("HATYMD") = pstrHATYMD
                End If
                If pstrHATTIME.Length = 0 Then      '�x��ɂċ�f�[�^�����Ă��܂����ꍇ��[ALL0]
                    cdb.pSQLParamStr("HATTIME") = "000000"
                Else
                    cdb.pSQLParamStr("HATTIME") = pstrHATTIME
                End If
                cdb.pSQLParamStr("KENSIN") = pstrKENSIN
                cdb.pSQLParamStr("KEIHOSU") = pstrKEIHOSU
                cdb.pSQLParamStr("RYURYO") = pstrRYURYO
                cdb.pSQLParamStr("METASYU") = pstrMETASYU
                cdb.pSQLParamStr("UNYO") = pstrUNYO
                cdb.pSQLParamStr("JUYMD") = pstrJUYMD
                cdb.pSQLParamStr("JUTIME") = pstrJUTIME
                cdb.pSQLParamStr("NUM_DIGIT") = pstrNUM_DIGIT
                cdb.pSQLParamStr("KMCD1") = pstrKMCD1
                cdb.pSQLParamStr("KMNM1") = pstrKMNM1
                cdb.pSQLParamStr("KMCD2") = pstrKMCD2
                cdb.pSQLParamStr("KMNM2") = pstrKMNM2
                cdb.pSQLParamStr("KMCD3") = pstrKMCD3
                cdb.pSQLParamStr("KMNM3") = pstrKMNM3
                cdb.pSQLParamStr("KMCD4") = pstrKMCD4
                cdb.pSQLParamStr("KMNM4") = pstrKMNM4
                cdb.pSQLParamStr("KMCD5") = pstrKMCD5
                cdb.pSQLParamStr("KMNM5") = pstrKMNM5
                cdb.pSQLParamStr("KMCD6") = pstrKMCD6
                cdb.pSQLParamStr("KMNM6") = pstrKMNM6
                'cdb.pSQLParamStr("ZSISYO") = strZSISYO          '�f�[�^�擾
                'cdb.pSQLParamStr("KURACD") = pstrKURACD
                'cdb.pSQLParamStr("KENNM") = pstrKENNM
                'cdb.pSQLParamStr("JACD") = pstrJACD
                'cdb.pSQLParamStr("JANM") = pstrJANM
                'cdb.pSQLParamStr("ACBCD") = pstrACBCD
                'cdb.pSQLParamStr("ACBNM") = pstrACBNM
                'cdb.pSQLParamStr("USER_CD") = pstrUSER_CD
                'cdb.pSQLParamStr("JUSYONM") = pstrJUSYONM
                'cdb.pSQLParamStr("JUSYOKN") = pstrJUSYOKN
                'cdb.pSQLParamStr("JUTEL1") = pstrJUTEL1
                'cdb.pSQLParamStr("JUTEL2") = pstrJUTEL2
                'cdb.pSQLParamStr("RENTEL") = pstrRENTEL
                cdb.pSQLParamStr("KTELNO") = pstrKTELNO
                'cdb.pSQLParamStr("ADDR") = pstrADDR
                '--- ��2005/09/09 MOD Falcon�� ---
                'cdb.pSQLParamStr("USER_KIJI") = pstrUSER_KIJI
                cdb.pSQLParamStr("BIKOU") = pstrBIKOU
                '--- ��2005/09/09 MOD Falcon�� ---
                cdb.pSQLParamStr("NCU_SET") = pstrNCU_SET
                cdb.pSQLParamStr("TIZUNO") = pstrTIZUNO
                cdb.pSQLParamStr("HANBAI_KBN") = pstrHANBAI_KBN '2015/11/25 H.Mori add 2015���P�J�� No1 
                cdb.pSQLParamStr("KYOKTKBN") = pstrKYOKTKBN   '2016/12/14 H.Mori add 2016���P�J�� No4-3
                cdb.pSQLParamStr("MET_KATA") = pstrMET_KATA
                cdb.pSQLParamStr("MET_MAKER") = pstrMET_MAKER
                cdb.pSQLParamStr("BONB1_KKG") = pstrBONB1_KKG
                cdb.pSQLParamStr("BONB1_HON") = pstrBONB1_HON
                cdb.pSQLParamStr("BONB1_YOBI") = pstrBONB1_YOBI
                cdb.pSQLParamStr("BONB2_KKG") = pstrBONB2_KKG
                cdb.pSQLParamStr("BONB2_HON") = pstrBONB2_HON
                cdb.pSQLParamStr("BONB2_YOBI") = pstrBONB2_YOBI
                cdb.pSQLParamStr("BONB3_KKG") = pstrBONB3_KKG
                cdb.pSQLParamStr("BONB3_HON") = pstrBONB3_HON
                cdb.pSQLParamStr("BONB3_YOBI") = pstrBONB3_YOBI
                cdb.pSQLParamStr("BONB4_KKG") = pstrBONB4_KKG
                cdb.pSQLParamStr("BONB4_HON") = pstrBONB4_HON
                cdb.pSQLParamStr("BONB4_YOBI") = pstrBONB4_YOBI
                cdb.pSQLParamStr("ZENKAI_HAISO") = pstrZENKAI_HAISO
                '20050729 NEC UPDATE START
                'cdb.pSQLParamStr("ZENKAI_HAI_S") = pstrZENKAI_HAI_S
                cdb.pSQLParamStr("ZENKAI_HAI_S") = pstrZENKAI_HAI_S.Replace(".", "")
                '20050729 NEC UPDATE END
                cdb.pSQLParamStr("KONKAI_HAISO") = pstrKONKAI_HAISO
                '20050729 NEC UPDATE START
                'cdb.pSQLParamStr("KONKAI_HAI_S") = pstrKONKAI_HAI_S
                cdb.pSQLParamStr("KONKAI_HAI_S") = pstrKONKAI_HAI_S.Replace(".", "")
                '20050729 NEC UPDATE END
                cdb.pSQLParamStr("JIKAI_HAISO") = pstrJIKAI_HAISO
                cdb.pSQLParamStr("ZENKAI_KENSIN") = pstrZENKAI_KENSIN
                '20050729 NEC UPDATE START
                'cdb.pSQLParamStr("ZENKAI_KEN_S") = pstrZENKAI_KEN_S
                'cdb.pSQLParamStr("ZENKAI_KEN_SIYO") = pstrZENKAI_KEN_SIYO
                cdb.pSQLParamStr("ZENKAI_KEN_S") = pstrZENKAI_KEN_S.Replace(".", "")
                cdb.pSQLParamStr("ZENKAI_KEN_SIYO") = pstrZENKAI_KEN_SIYO.Replace(".", "")
                '20050729 NEC UPDATE END
                cdb.pSQLParamStr("KONKAI_KENSIN") = pstrKONKAI_KENSIN
                '20050729 NEC UPDATE START
                'cdb.pSQLParamStr("KONKAI_KEN_S") = pstrKONKAI_KEN_S
                'cdb.pSQLParamStr("KONKAI_KEN_SIYO") = pstrKONKAI_KEN_SIYO
                cdb.pSQLParamStr("KONKAI_KEN_S") = pstrKONKAI_KEN_S.Replace(".", "")
                cdb.pSQLParamStr("KONKAI_KEN_SIYO") = pstrKONKAI_KEN_SIYO.Replace(".", "")
                '20050729 NEC UPDATE END
                cdb.pSQLParamStr("ZENKAI_HASEI") = pstrZENKAI_HASEI
                '20050729 NEC UPDATE START
                'cdb.pSQLParamStr("ZENKAI_HAS_S") = pstrZENKAI_HAS_S
                cdb.pSQLParamStr("ZENKAI_HAS_S") = pstrZENKAI_HAS_S.Replace(".", "")
                '20050729 NEC UPDATE END
                cdb.pSQLParamStr("KONKAI_HASEI") = pstrKONKAI_HASEI
                '20050729 NEC UPDATE START
                'cdb.pSQLParamStr("KONKAI_HAS_S") = pstrKONKAI_HAS_S
                cdb.pSQLParamStr("KONKAI_HAS_S") = pstrKONKAI_HAS_S.Replace(".", "")
                '20050729 NEC UPDATE END
                cdb.pSQLParamStr("G_ZAIKO") = pstrG_ZAIKO
                cdb.pSQLParamStr("ICHI_SIYO") = pstrICHI_SIYO
                cdb.pSQLParamStr("YOSOKU_ICHI_SIYO") = pstrYOSOKU_ICHI_SIYO
                cdb.pSQLParamStr("GAS1_HINMEI") = pstrGAS1_HINMEI
                cdb.pSQLParamStr("GAS1_DAISU") = pstrGAS1_DAISU
                cdb.pSQLParamStr("GAS1_SEIFL") = pstrGAS1_SEIFL
                cdb.pSQLParamStr("GAS2_HINMEI") = pstrGAS2_HINMEI
                cdb.pSQLParamStr("GAS2_DAISU") = pstrGAS2_DAISU
                cdb.pSQLParamStr("GAS2_SEIFL") = pstrGAS2_SEIFL
                cdb.pSQLParamStr("GAS3_HINMEI") = pstrGAS3_HINMEI
                cdb.pSQLParamStr("GAS3_DAISU") = pstrGAS3_DAISU
                cdb.pSQLParamStr("GAS3_SEIFL") = pstrGAS3_SEIFL
                cdb.pSQLParamStr("GAS4_HINMEI") = pstrGAS4_HINMEI
                cdb.pSQLParamStr("GAS4_DAISU") = pstrGAS4_DAISU
                cdb.pSQLParamStr("GAS4_SEIFL") = pstrGAS4_SEIFL
                cdb.pSQLParamStr("GAS5_HINMEI") = pstrGAS5_HINMEI
                cdb.pSQLParamStr("GAS5_DAISU") = pstrGAS5_DAISU
                cdb.pSQLParamStr("GAS5_SEIFL") = pstrGAS5_SEIFL
                '//�Ή�DB�ǉ�����----------------
                cdb.pSQLParamStr("BOMB_TYPE") = pstrBOMB_TYPE
                cdb.pSQLParamStr("GAS_STOP") = pstrGAS_STOP
                cdb.pSQLParamStr("GAS_DELE") = pstrGAS_DELE
                cdb.pSQLParamStr("GAS_RESTART") = pstrGAS_RESTART
                cdb.pSQLParamStr("LTOS_DATE") = "00000000"  'LTOS���A���̈�ALL0�̓��t���Z�b�g
                '//------------------------------
                strSDSKBN_NAI = fncGET_PULLNM("10", "1") '�o����Џ����敪=1(:������)�̖��̂��擾 ' 2008/10/20 T.Watabe add
                cdb.pSQLParamStr("SDSKBN") = "1"         ' 2008/10/17 T.Watabe add
                cdb.pSQLParamStr("SDSKBN_NAI") = strSDSKBN_NAI  ' 2008/10/17 T.Watabe add
                cdb.pSQLParamStr("KAITU_DAY") = pstrKAITU_DAY '�{���H���� 2013/08/23 T.Ono add �Ď����P2013��1
                cdb.pSQLParamStr("TUSIN") = pstrTUSIN         'NCU�ڑ� 2016/12/22 H.Mori add 2016���P�J�� No4-6 
                cdb.pSQLParamStr("DAIHYO_NAME") = pstrDAIHYO_NAME         '�@�l��\�Ҏ��� 2016/12/22 H.Mori add 2016���P�J�� No4-6 
                cdb.pSQLParamStr("HOKBN") = pstrHOKBN         '�K�p�@�ߋ敪 2016/12/22 H.Mori add 2016���P�J�� No4-6 
                cdb.pSQLParamStr("YOTOKBN") = pstrYOTOKBN         '�p�r�敪 2016/12/22 H.Mori add 2016���P�J�� No4-6 
                cdb.pSQLParamStr("HANBCD") = pstrHANBCD         '�̔����R�[�h 2016/12/22 H.Mori add 2016���P�J�� No4-6
                cdb.pSQLParamStr("SHUGOU") = pstrSHUGOU         '�W���敪 2017/10/16 H.Mori add 2017���P�J�� No4-1 
            End If
            If pstrSeniPG = "KEKEKJAG00" Then
                '*******************************************
                '�Ή����ʈꗗ����̑J�ڂ������ꍇ
                '*******************************************

                '�x�񃁃b�Z�[�W����-------- 2007/04/25 T.Watabe add
                cdb.pSQLParamStr("KMCD1") = pstrKMCD1
                cdb.pSQLParamStr("KMNM1") = pstrKMNM1
                cdb.pSQLParamStr("KMCD2") = pstrKMCD2
                cdb.pSQLParamStr("KMNM2") = pstrKMNM2
                cdb.pSQLParamStr("KMCD3") = pstrKMCD3
                cdb.pSQLParamStr("KMNM3") = pstrKMNM3
                cdb.pSQLParamStr("KMCD4") = pstrKMCD4
                cdb.pSQLParamStr("KMNM4") = pstrKMNM4
                cdb.pSQLParamStr("KMCD5") = pstrKMCD5
                cdb.pSQLParamStr("KMNM5") = pstrKMNM5
                cdb.pSQLParamStr("KMCD6") = pstrKMCD6
                cdb.pSQLParamStr("KMNM6") = pstrKMNM6
                cdb.pSQLParamStr("NCUHATYMD") = pstrNCUHATYMD   ' 2008/10/15 T.Watabe add
                cdb.pSQLParamStr("NCUHATTIME") = pstrNCUHATTIME ' 2008/10/15 T.Watabe add
                cdb.pSQLParamStr("HATYMD") = pstrHATYMD
                cdb.pSQLParamStr("HATTIME") = pstrHATTIME
            End If
            cdb.pSQLParamStr("HATKBN") = pstrHATKBN
            cdb.pSQLParamStr("HATKBN_NAI") = strHATKBN_NAI
            cdb.pSQLParamStr("TAIOKBN") = pstrTAIOKBN
            cdb.pSQLParamStr("TAIOKBN_NAI") = strTAIOKBN_NAI
            cdb.pSQLParamStr("TMSKB") = pstrTMSKB
            cdb.pSQLParamStr("TMSKB_NAI") = strTMSKB_NAI
            cdb.pSQLParamStr("TKTANCD") = pstrTKTANCD
            cdb.pSQLParamStr("TKTANCD_NM") = strTKTANCD_NM      '�f�[�^�擾
            cdb.pSQLParamStr("TAITCD") = pstrTAITCD
            cdb.pSQLParamStr("TAITNM") = strTAITNM              '�f�[�^�擾
            If ((pstrSeniPG = "KEJUKJAG00") Or (pstrSeniPG = "MSKOSJAG00")) Then
                '*******************************************
                '�x���M�p�l���A�܂��͌ڋq��������̑J�ڂ������ꍇ
                '*******************************************

                '//�Ή����͎��A���������w�肳��Ă��Ȃ��ꍇ(�����ςł͂Ȃ�)�́A�J�n���̍X�V�͍s��Ȃ�
                If pstrSYOYMD.Length > 0 And pstrSYOTIME.Length > 0 Then
                    cdb.pSQLParamStr("TAIO_ST_DATE") = pstrTAIO_ST_DATE
                    cdb.pSQLParamStr("TAIO_ST_TIME") = pstrTAIO_ST_TIME
                    cdb.pSQLParamStr("SYOYMD") = pstrSYOYMD
                    cdb.pSQLParamStr("SYOTIME") = pstrSYOTIME
                    cdb.pSQLParamStr("TAIO_SYO_TIME") = CStr(fncDateDiff(pstrTAIO_ST_DATE, pstrTAIO_ST_TIME, pstrSYOYMD, pstrSYOTIME))
                Else
                    '//�o���w���ŏ����ςłȂ��ꍇ�͊J�n����o�^����
                    If pstrTAIOKBN = "2" And pstrTMSKB <> "2" Then
                        cdb.pSQLParamStr("TAIO_ST_DATE") = Now.ToString("yyyyMMdd")
                        cdb.pSQLParamStr("TAIO_ST_TIME") = Now.ToString("HHmmss")
                    Else
                        cdb.pSQLParamStr("TAIO_ST_DATE") = ""
                        cdb.pSQLParamStr("TAIO_ST_TIME") = ""
                    End If
                    cdb.pSQLParamStr("SYOYMD") = ""
                    cdb.pSQLParamStr("SYOTIME") = ""
                    cdb.pSQLParamStr("TAIO_SYO_TIME") = ""
                End If
            Else
                '//�Ή����͕ύX���A���͂��ꂽ�������Ƃc�a�̊��������قȂ����ꍇ�A
                '//�V���ɊJ�n���E�������E���v���Ԃ��Z�b�g
                '//�قȂ�Ȃ��ꍇ�A�c�a�̓��e�ł��̂܂܍X�V
                If (strZ_SYOYMD.Length = 0) Or
                   (strZ_SYOYMD & strZ_SYOTIME <> pstrSYOYMD & pstrSYOTIME) Then
                    If pstrSYOYMD.Length > 0 And pstrSYOTIME.Length > 0 Then
                        cdb.pSQLParamStr("TAIO_ST_DATE") = pstrTAIO_ST_DATE
                        cdb.pSQLParamStr("TAIO_ST_TIME") = pstrTAIO_ST_TIME
                        cdb.pSQLParamStr("SYOYMD") = pstrSYOYMD
                        cdb.pSQLParamStr("SYOTIME") = pstrSYOTIME

                        cdb.pSQLParamStr("TAIO_SYO_TIME") = CStr(fncDateDiff(pstrTAIO_ST_DATE, pstrTAIO_ST_TIME, pstrSYOYMD, pstrSYOTIME))
                    Else
                        '//�o���w���ŏ����ςłȂ��ꍇ�͊J�n����o�^����
                        If pstrTAIOKBN = "2" And pstrTMSKB <> "2" Then
                            cdb.pSQLParamStr("TAIO_ST_DATE") = Now.ToString("yyyyMMdd")
                            cdb.pSQLParamStr("TAIO_ST_TIME") = Now.ToString("HHmmss")
                        Else
                            cdb.pSQLParamStr("TAIO_ST_DATE") = ""
                            cdb.pSQLParamStr("TAIO_ST_TIME") = ""
                        End If
                        cdb.pSQLParamStr("SYOYMD") = ""
                        cdb.pSQLParamStr("SYOTIME") = ""
                        cdb.pSQLParamStr("TAIO_SYO_TIME") = ""
                    End If
                Else
                    cdb.pSQLParamStr("TAIO_ST_DATE") = strZ_TaioStDate
                    cdb.pSQLParamStr("TAIO_ST_TIME") = strZ_TaioStTime
                    cdb.pSQLParamStr("SYOYMD") = strZ_SYOYMD
                    cdb.pSQLParamStr("SYOTIME") = strZ_SYOTIME
                    cdb.pSQLParamStr("TAIO_SYO_TIME") = strZ_SYOYOTIME
                End If
            End If

            cdb.pSQLParamStr("FAXKBN") = pstrFAXKBN
            cdb.pSQLParamStr("FAXKURAKBN") = pstrFAXKURAKBN      ' 2010/07/12 T.Watabe add
            cdb.pSQLParamStr("FAXRUISEKIKBN") = pstrFAXRUISEKIKBN '2015/11/19 H.Mori add 2015���P�J�� No1
            cdb.pSQLParamStr("TELRCD") = pstrTELRCD
            cdb.pSQLParamStr("TELRNM") = strTELRNM              '�f�[�^�擾
            cdb.pSQLParamStr("TFKICD") = pstrTFKICD
            cdb.pSQLParamStr("TFKINM") = strTFKINM
            cdb.pSQLParamStr("FUK_MEMO") = pstrFUK_MEMO
            cdb.pSQLParamStr("TEL_MEMO1") = pstrTEL_MEMO1
            cdb.pSQLParamStr("TEL_MEMO2") = pstrTEL_MEMO2
            cdb.pSQLParamStr("TEL_MEMO4") = pstrTEL_MEMO4       '2020/11/01 T.Ono add 2020�Ď����P
            cdb.pSQLParamStr("TEL_MEMO5") = pstrTEL_MEMO5       '2020/11/01 T.Ono add 2020�Ď����P
            cdb.pSQLParamStr("TEL_MEMO6") = pstrTEL_MEMO6       '2020/11/01 T.Ono add 2020�Ď����P
            cdb.pSQLParamStr("MITOKBN") = pstrMITOKBN
            cdb.pSQLParamStr("TKIGCD") = pstrTKIGCD
            cdb.pSQLParamStr("TKIGNM") = strTKIGNM              '�f�[�^�擾
            cdb.pSQLParamStr("TSADCD") = pstrTSADCD
            cdb.pSQLParamStr("TSADNM") = strTSADNM              '�f�[�^�擾
            cdb.pSQLParamStr("GENIN_KIJI") = pstrGENIN_KIJI
            cdb.pSQLParamStr("SDCD") = pstrSDCD
            cdb.pSQLParamStr("SDNM") = strSDNM                  '�f�[�^�擾
            cdb.pSQLParamStr("SIJIYMD") = pstrSIJIYMD
            cdb.pSQLParamStr("SIJITIME") = pstrSIJITIME
            cdb.pSQLParamStr("SIJI_BIKO1") = pstrSIJI_BIKO1
            cdb.pSQLParamStr("SIJI_BIKO2") = pstrSIJI_BIKO2
            cdb.pSQLParamStr("STD_JASCD") = pstrSTD_JASCD
            cdb.pSQLParamStr("STD_JANA") = pstrSTD_JANA
            cdb.pSQLParamStr("STD_JASNA") = pstrSTD_JASNA
            cdb.pSQLParamStr("REN_NA") = pstrREN_NA
            cdb.pSQLParamStr("REN_TEL_1") = pstrREN_TEL_1
            cdb.pSQLParamStr("REN_TEL_2") = pstrREN_TEL_2
            cdb.pSQLParamStr("REN_TEL_3") = pstrREN_TEL_3       '2015/01/05 T.Ono add 2014���P�J��
            cdb.pSQLParamStr("REN_FAX") = pstrREN_FAX
            cdb.pSQLParamStr("REN_BIKO") = pstrREN_BIKO
            cdb.pSQLParamStr("REN_1_NA") = pstrREN_1_NA
            cdb.pSQLParamStr("REN_1_TEL1") = pstrREN_1_TEL1
            cdb.pSQLParamStr("REN_1_TEL2") = pstrREN_1_TEL2
            cdb.pSQLParamStr("REN_1_TEL3") = pstrREN_1_TEL3     '2015/01/05 T.Ono add 2014���P�J��
            cdb.pSQLParamStr("REN_1_FAX") = pstrREN_1_FAX
            cdb.pSQLParamStr("REN_1_BIKO") = pstrREN_1_BIKO
            cdb.pSQLParamStr("REN_2_NA") = pstrREN_2_NA
            cdb.pSQLParamStr("REN_2_TEL1") = pstrREN_2_TEL1
            cdb.pSQLParamStr("REN_2_TEL2") = pstrREN_2_TEL2
            cdb.pSQLParamStr("REN_2_TEL3") = pstrREN_2_TEL3     '2015/01/05 T.Ono add 2014���P�J��
            cdb.pSQLParamStr("REN_2_FAX") = pstrREN_2_FAX
            cdb.pSQLParamStr("REN_2_BIKO") = pstrREN_2_BIKO
            cdb.pSQLParamStr("REN_3_NA") = pstrREN_3_NA
            cdb.pSQLParamStr("REN_3_TEL1") = pstrREN_3_TEL1
            cdb.pSQLParamStr("REN_3_TEL2") = pstrREN_3_TEL2
            cdb.pSQLParamStr("REN_3_TEL3") = pstrREN_3_TEL3     '2015/01/05 T.Ono add 2014���P�J��
            cdb.pSQLParamStr("REN_3_FAX") = pstrREN_3_FAX
            cdb.pSQLParamStr("REN_3_BIKO") = pstrREN_3_BIKO
            cdb.pSQLParamStr("STD_CD") = pstrSTD_CD
            cdb.pSQLParamStr("STD") = pstrSTD
            cdb.pSQLParamStr("STD_KYOTEN_CD") = pstrSTD_KYOTEN_CD
            cdb.pSQLParamStr("STD_KYOTEN") = pstrSTD_KYOTEN
            cdb.pSQLParamStr("STD_TEL") = pstrSTD_TEL
            cdb.pSQLParamStr("TEL_BIKO") = pstrTEL_BIKO
            '2016/02/02 w.ganeko 2015���P�J�� ��1-3 start
            cdb.pSQLParamStr("KANSHI_BIKO") = pstrKANSHI_BIKO
            cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2
            cdb.pSQLParamStr("RENTEL2_BIKO") = pstrRENTEL2_BIKO
            'cdb.pSQLParamStr("RENTEL2_UPD_DATE") = Now.ToString("yyyyMMdd") '2016/03/24 T.Ono mod
            cdb.pSQLParamStr("RENTEL2_UPD_DATE") = pstrRENTEL2_UPD_DATE
            cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3
            cdb.pSQLParamStr("RENTEL3_BIKO") = pstrRENTEL3_BIKO
            'cdb.pSQLParamStr("RENTEL3_UPD_DATE") = Now.ToString("yyyyMMdd") '2016/03/24 T.Ono mod
            cdb.pSQLParamStr("RENTEL3_UPD_DATE") = pstrRENTEL3_UPD_DATE
            '2016/02/02 w.ganeko 2015���P�J�� ��1-3 end
            '2016/12/14 H.Mori 2016���P�J�� No4-6,No4-1 START
            cdb.pSQLParamStr("FAXSPOTKBN") = pstrFAXSPOTKBN
            cdb.pSQLParamStr("TELAB") = pstrTELAB
            cdb.pSQLParamStr("DAI3RENDORENTEL") = pstrDAI3RENDORENTEL
            '2016/12/14 H.Mori 2016���P�J�� No4-6,No4-1 END
            '--- ��2005/09/09 ADD Falcon�� ---
            cdb.pSQLParamStr("FAX_TITLE_CD") = pstrFAX_TITLE_CD
            '--- ��2005/09/09 ADD Falcon�� ---
            cdb.pSQLParamStr("FAX_TITLE") = pstrFAX_TITLE
            cdb.pSQLParamStr("FAX_REN") = pstrFAX_REN
            If ((pstrSeniPG = "KEJUKJAG00") Or (pstrSeniPG = "MSKOSJAG00")) Then
                '�x���M�p�l���A�܂��͌ڋq��������̑J�ڂ������ꍇ�i�o�^���j
                cdb.pSQLParamStr("ADD_DATE") = Now.ToString("yyyyMMdd")
            Else
                '�Ή����ʈꗗ����̑J�ڂ������ꍇ�i�X�V���j
                cdb.pSQLParamStr("EDT_DATE") = Now.ToString("yyyyMMdd")
            End If
            cdb.pSQLParamStr("EDT_TIME") = Now.ToString("HHmmss")

            'SQL�����s
            cdb.mExecNonQuery()
            '�x���M�p�l������̑J�ڂ������ꍇ
            '�Ή��Ώۂ̌x��t�@�C����Ή��ς݂ɂ���
            If pstrSeniPG = "KEJUKJAG00" Then
                strSQL = New StringBuilder("")
                strSQL.Append("UPDATE ")
                strSQL.Append("T10_KEIHO ")
                strSQL.Append("SET ")
                '2012/06/25 W.GANEKO CHG START
                'strSQL.Append("REACTION = '1' ")
                If pstrAUTOTAIOU = "1" Then
                    strSQL.Append("REACTION = '4' ")
                Else
                    strSQL.Append("REACTION = '1' ")
                End If
                '2012/06/25 W.GANEKO CHG END
                strSQL.Append("WHERE SYORI_SERIAL = :SYORI_SERIAL")
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�̃Z�b�g
                cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL

                'SQL���s
                cdb.mExecQuery()
            End If

            mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Taiou2 sqlend pstrSeniPG=" & pstrSeniPG & ",pstrKURACD=" & pstrKURACD & ",pstrJACD=" & pstrJACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrHATYMD=" & pstrHATYMD & ",pstrHATTIME=" & pstrHATTIME)

            '*******************************************
            '�d�b���M���O�o��
            '*******************************************
            Call fncTelHasLog(cdb,
                            strSeqno,
                            pstrDialKbns,
                            pstrDialNumbers,
                            pstrDialAites,
                            pstrDialResult,
                            pstrDialDates,
                            pstrDialTimes,
                            pstrDialStates)
            '*******************************************

            ' 2009/02/13 T.Watabe del �S���҂̍X�V�͂��Ȃ��悤�ɕύX
            '*******************************************
            '�S���҂c�a�X�V
            '*******************************************
            'Dim intKBN As Integer
            'Dim strADD_DATE As String
            'Dim MSTANJAW00C As New MSTANJAW00.MSTANJAW00
            'Try
            '    '//�ꎟ�A����
            '    If pstrREN_NA.Length > 0 Then
            '        intKBN = fncGET_TANTO _
            '                        (pstrKURACD, pstrACBCD, pstrREN_CODE, strADD_DATE, _
            '                        pstrREN_NA, pstrREN_TEL_1, pstrREN_TEL_2, pstrREN_BIKO)
            '        If intKBN <> 9 Then
            '            '�Ԃ�l��[1][2]�̎��̂ݏ��������s����
            '            strRes = MSTANJAW00C.mSetTanto(cdb, _
            '                    intKBN, "3", pstrKURACD, pstrACBCD, _
            '                    pstrREN_CODE, pstrREN_NA, pstrREN_TEL_1, _
            '                    pstrREN_TEL_2, pstrREN_FAX, "1", pstrREN_BIKO, strADD_DATE, _
            '                    pstrREN_EDT_DATE, pstrREN_TIME)
            '            If strRes <> "OK" Then
            '                Exit Try
            '            End If
            '        End If
            '    End If
            '    '//�񎟘A����P
            '    If pstrREN_1_NA.Length > 0 Then
            '        intKBN = fncGET_TANTO _
            '                        (pstrKURACD, pstrACBCD, pstrREN_1_CODE, strADD_DATE, _
            '                        pstrREN_1_NA, pstrREN_1_TEL1, pstrREN_1_TEL2, pstrREN_1_BIKO)
            '        If intKBN <> 9 Then
            '            '�Ԃ�l��[1][2]�̎��̂ݏ��������s����
            '            strRes = MSTANJAW00C.mSetTanto(cdb, _
            '                    intKBN, "3", pstrKURACD, pstrACBCD, _
            '                    pstrREN_1_CODE, pstrREN_1_NA, pstrREN_1_TEL1, _
            '                    pstrREN_1_TEL2, pstrREN_1_FAX, "2", pstrREN_1_BIKO, strADD_DATE, _
            '                    pstrREN_1_EDT_DATE, pstrREN_1_TIME)
            '            If strRes <> "OK" Then
            '                Exit Try
            '            End If
            '        End If
            '    End If
            '    '//�񎟘A����Q
            '    If pstrREN_2_NA.Length > 0 Then
            '        intKBN = fncGET_TANTO _
            '                        (pstrKURACD, pstrACBCD, pstrREN_2_CODE, strADD_DATE, _
            '                        pstrREN_2_NA, pstrREN_2_TEL1, pstrREN_2_TEL2, pstrREN_2_BIKO)
            '        If intKBN <> 9 Then
            '            '�Ԃ�l��[1][2]�̎��̂ݏ��������s����
            '            strRes = MSTANJAW00C.mSetTanto(cdb, _
            '                    intKBN, "3", pstrKURACD, pstrACBCD, _
            '                    pstrREN_2_CODE, pstrREN_2_NA, pstrREN_2_TEL1, _
            '                    pstrREN_2_TEL2, pstrREN_2_FAX, "3", pstrREN_2_BIKO, strADD_DATE, _
            '                    pstrREN_2_EDT_DATE, pstrREN_2_TIME)
            '            If strRes <> "OK" Then
            '                Exit Try
            '            End If
            '        End If
            '    End If
            '    '//�񎟘A����R
            '    If pstrREN_3_NA.Length > 0 Then
            '        intKBN = fncGET_TANTO _
            '                        (pstrKURACD, pstrACBCD, pstrREN_3_CODE, strADD_DATE, _
            '                        pstrREN_3_NA, pstrREN_3_TEL1, pstrREN_3_TEL2, pstrREN_3_BIKO)
            '        If intKBN <> 9 Then
            '            '�Ԃ�l��[1][2]�̎��̂ݏ��������s����
            '            strRes = MSTANJAW00C.mSetTanto(cdb, _
            '                    intKBN, "3", pstrKURACD, pstrACBCD, _
            '                    pstrREN_3_CODE, pstrREN_3_NA, pstrREN_3_TEL1, _
            '                    pstrREN_3_TEL2, pstrREN_3_FAX, "4", pstrREN_3_BIKO, strADD_DATE, _
            '                    pstrREN_3_EDT_DATE, pstrREN_3_TIME)
            '            If strRes <> "OK" Then
            '                Exit Try
            '            End If

            '        End If
            '    End If
            'Catch ex As Exception
            '    strRes = "ERROR" & ex.ToString
            'End Try
            '//------------------------------
            If strRes <> "OK" Then
                If Left(strRes, 5) <> "ERROR" Then
                    strRes = "T" & strRes
                End If
                '���[���o�b�N
                cdb.mRollback()
                Exit Try
            End If

            '�R�~�b�g
            cdb.mCommit()
        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString
            '���[���o�b�N
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        cdb = Nothing
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_Taiou2 end pstrKURACD=" & pstrKURACD & ",pstrJACD=" & pstrJACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrHATYMD=" & pstrHATYMD & ",pstrHATTIME=" & pstrHATTIME)

        Return strRes
    End Function

    '************************************************
    '*�@�T�@�v�F�p�����[�^�����ԍ��f�[�^�̃��b�N�t���O������(NULL)���܂�
    '*�@�@�@�@�@�x���M�p�l������̑J�ڎ��ŏI���{�^�����������ꍇ�Ɏ��s���܂�
    '************************************************
    '<WebMethod()> Public Function mSet_NoRoc(ByVal pstrSERIAL As String) As String '2017/10/23 H.Mori mod 2017���P�J�� No4-3
    <WebMethod()> Public Function mSet_NoRoc(ByVal pstrSERIAL As String, ByVal pstrUSERNAME As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_NoRoc start pstrSERIAL=" & pstrSERIAL)

        strRes = "OK"

        '--------------------------------------------------
        '�ڑ�OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            '----------------------------------------------
            '�g�����U�N�V�����J�n
            cdb.mBeginTrans()

            '----------------------------------------------
            '�c�a�`�F�b�N
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" NVL(ROC_FRG,'') AS ROC_FRG, ")              '//���b�N�t���O
            strSQL.Append(" SYORI_SERIAL, ")                             '//�����ԍ�
            strSQL.Append(" ROC_USER ")                                   '���b�N���[�U�[  2017/10/20 H.Mori add 2017���P�J�� No4-3
            strSQL.Append("FROM ")
            strSQL.Append("T10_KEIHO ")                                 '//�x��c�a
            strSQL.Append("WHERE SYORI_SERIAL =:SYORI_SERIAL ")         '//�����ԍ�
            strSQL.Append("  AND REACTION = '0' ")                      '//�������(O�łȂ��ꍇ�͊��ɑΉ����͓o�^���݂ƂȂ�)
            strSQL.Append("FOR UPDATE ")
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL               '//�����ԍ�
            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '�r������̂���
            If ds.Tables(0).Rows.Count = 0 Then
                '���[���o�b�N
                cdb.mRollback()
            ElseIf Convert.ToString(ds.Tables(0).Rows(0).Item("ROC_FRG")) = "" Then
                '���b�N�t���O�����ɉ�������Ă�����UPDATE�����Ȃ�
                cdb.mRollback()
            ElseIf pstrUSERNAME <> Convert.ToString(ds.Tables(0).Rows(0).Item("ROC_USER")) Then '2017/10/23 H.Mori add 2017���P�J�� No4-3
                '���b�N���[�U�[����v���Ȃ��ꍇ�AUPDATE�����Ȃ�
                cdb.mRollback()
            Else
                '-----------------------------------------------
                '�c�a�X�V�i���b�N�����j
                strSQL = New StringBuilder("")
                strSQL.Append("")
                strSQL.Append("UPDATE ")
                strSQL.Append("T10_KEIHO ")
                strSQL.Append("SET ")
                strSQL.Append("ROC_FRG = NULL, ")                       '//���b�N�t���O
                strSQL.Append("ROC_TIME= NULL,  ")                      '//���b�N����
                strSQL.Append("ROC_USER= NULL ")                        '���b�N���[�U�[ 2017/10/11 H.Mori add 2017���P�J�� No1
                strSQL.Append("WHERE SYORI_SERIAL =:SYORI_SERIAL ")     '//�����ԍ�
                'SQL���Z�b�g
                cdb.pSQL = strSQL.ToString
                '�p�����[�^�Z�b�g
                cdb.pSQLParamStr("SYORI_SERIAL") = pstrSERIAL           '//�����ԍ�
                'SQL�����s
                cdb.mExecNonQuery()

                '�R�~�b�g
                cdb.mCommit()
            End If
        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString
            '���[���o�b�N
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        cdb = Nothing
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mSet_NoRoc end pstrSERIAL=" & pstrSERIAL)

        Return strRes
    End Function

    '************************************************
    '*�@�T�@�v�F�d�b���M���O���o�͂��܂��B
    '************************************************
    Public Function fncTelHasLog(ByRef cdb As CDB, _
                                ByVal pstrSeqno As String, _
                                ByVal pstrDialKbns As String, _
                                ByVal pstrDialNumbers As String, _
                                ByVal pstrDialAites As String, _
                                ByVal pstrDialResult As String, _
                                ByVal pstrDialDates As String, _
                                ByVal pstrDialTimes As String, _
                                ByVal pstrDialStates As String _
                                ) As String
        Dim ds As New DataSet
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim intLoop As Integer
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncTelHasLog start Seqno=" & pstrSeqno & ",DialKbns=" & pstrDialKbns & ",DialNumbers=" & pstrDialNumbers)

        '�����i�[�p�z��
        Dim strDialKbns() As String                                     '//�d�b���M�敪
        Dim strDialNumbers() As String                                  '//���M�d�b�ԍ�
        Dim strDialAites() As String                                    '//���M����於
        Dim strDialResult() As String                                   '//���M���ʃX�e�[�^�X
        Dim strDialDates() As String                                    '//���M�N����
        Dim strDialTimes() As String                                    '//���M����
        Dim strDialStates() As String

        '�J���}��؂�̕������z��Ɋi�[
        strDialKbns = pstrDialKbns.Split(Convert.ToChar(","))
        strDialNumbers = pstrDialNumbers.Split(Convert.ToChar(","))
        strDialAites = pstrDialAites.Split(Convert.ToChar(","))
        strDialResult = pstrDialResult.Split(Convert.ToChar(","))
        strDialDates = pstrDialDates.Split(Convert.ToChar(","))
        strDialTimes = pstrDialTimes.Split(Convert.ToChar(","))
        strDialStates = pstrDialStates.Split(Convert.ToChar(","))
        If strDialKbns.Length <> strDialDates.Length Then
            ReDim strDialDates(strDialKbns.Length - 1)
        End If
        If strDialKbns.Length <> strDialTimes.Length Then
            ReDim strDialTimes(strDialKbns.Length - 1)
        End If
        If strDialKbns.Length = 1 And strDialKbns(0).Length = 0 Then
            '�z��̗v�f�̐���1�ł���΃��O�̏o�͂��s��Ȃ�
            Return ""
        End If

        '�d�b���M���O�c�a�ɂh�m�r�d�q�s
        strSQL = New StringBuilder("")
        strSQL.Append("INSERT ")
        strSQL.Append("INTO ")
        strSQL.Append("S04_TELLOGDB (")
        strSQL.Append("SEQNO,")
        strSQL.Append("EDANO,")
        strSQL.Append("EXEC_KBN,")
        strSQL.Append("EXEC_YMD,")
        strSQL.Append("EXEC_TIME,")
        strSQL.Append("KOK_STATUS,")
        strSQL.Append("KOK_TELNO,")
        strSQL.Append("KOK_NM,")
        strSQL.Append("ADD_DATE,")
        strSQL.Append("TIME")
        strSQL.Append(") VALUES(")
        strSQL.Append(":SEQNO,")
        strSQL.Append(":EDANO,")
        strSQL.Append(":EXEC_KBN,")
        strSQL.Append(":EXEC_YMD,")
        strSQL.Append(":EXEC_TIME,")
        strSQL.Append(":KOK_STATUS,")
        strSQL.Append(":KOK_TELNO,")
        strSQL.Append(":KOK_NM,")
        strSQL.Append(":ADD_DATE,")
        strSQL.Append(":TIME")
        strSQL.Append(")")
        For intLoop = 0 To strDialKbns.Length - 1
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�Z�b�g
            cdb.pSQLParamStr("SEQNO") = pstrSeqno
            cdb.pSQLParamStr("EDANO") = CStr(intLoop + 1)
            cdb.pSQLParamStr("EXEC_KBN") = strDialKbns(intLoop)
            cdb.pSQLParamStr("EXEC_YMD") = strDialDates(intLoop)
            cdb.pSQLParamStr("EXEC_TIME") = strDialTimes(intLoop)
            cdb.pSQLParamStr("KOK_STATUS") = strDialResult(intLoop)
            cdb.pSQLParamStr("KOK_TELNO") = strDialNumbers(intLoop)
            cdb.pSQLParamStr("KOK_NM") = strDialAites(intLoop)
            cdb.pSQLParamStr("ADD_DATE") = Now.ToString("yyyyMMdd")
            cdb.pSQLParamStr("TIME") = Now.ToString("HHmmss")
            'SQL�����s
            cdb.mExecQuery()
        Next
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncTelHasLog end pstrSeqno=" & pstrSeqno & ",pstrDialKbns=" & pstrDialKbns & ",pstrDialNumbers=" & pstrDialNumbers & ",pstrDialAites=" & pstrDialAites & ",pstrDialDates=" & pstrDialDates & ",pstrDialTimes=" & pstrDialTimes)

    End Function

    '******************************************************************************
    '*�@�T�@�v�F�v���_�E���}�X�^���������A�R�[�h���疼�̂��擾����
    '******************************************************************************
    Private Function fncGET_PULLNM(ByVal pstrKBN As String, ByVal pstrCD As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        strRes = ""
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncGET_PULLNM start pstrKBN=" & pstrKBN & ",pstrCD=" & pstrCD)

        '�l���Ȃ��ꍇ�͋��Ԃ�
        If pstrCD.Length = 0 Then
            Return strRes
        End If

        '�c�a�I�[�v��
        cdb.mOpen()
        'SQL�쐬
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("NAME ")
        strSQL.Append("FROM ")
        strSQL.Append("M06_PULLDOWN ")
        strSQL.Append("WHERE :KBN = KBN(+)")
        strSQL.Append(" AND :CD = CD(+)")
        'SQL���Z�b�g
        cdb.pSQL = strSQL.ToString
        '�p�����[�^�Z�b�g
        cdb.pSQLParamStr("KBN") = pstrKBN       '//�敪
        cdb.pSQLParamStr("CD") = pstrCD         '//�R�[�h
        'SQL�����s
        cdb.mExecQuery()
        '�f�[�^�Z�b�g�ɒl���i�[
        ds = cdb.pResult
        If ds.Tables(0).Rows.Count = 0 Then
            '�f�[�^��0����������
            strRes = ""
        Else
            strRes = Convert.ToString(ds.Tables(0).Rows(0).Item("NAME"))
        End If
        '�c�a�N���[�Y
        cdb.mClose()
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncGET_PULLNM end pstrKBN=" & pstrKBN & ",pstrCD=" & pstrCD)

        Return strRes
    End Function

    '******************************************************************************
    '*�@�T�@�v�F���v���Ԃ̍쐬
    '******************************************************************************
    Private Function fncDateDiff(ByVal strSTDate As String, ByVal strSTTime As String, _
                                ByVal strEDDate As String, ByVal strEDTime As String) As Long
        Dim DatTim1 As Date
        Dim DatTim2 As Date

        Dim lngRec As Long
        strSTDate = strSTDate.Substring(0, 4) & "/" & strSTDate.Substring(4, 2) & "/" & strSTDate.Substring(6, 2)
        strSTTime = strSTTime.Substring(0, 2) & ":" & strSTTime.Substring(2, 2) & ":" & strSTTime.Substring(4, 2)
        strEDDate = strEDDate.Substring(0, 4) & "/" & strEDDate.Substring(4, 2) & "/" & strEDDate.Substring(6, 2)
        strEDTime = strEDTime.Substring(0, 2) & ":" & strEDTime.Substring(2, 2) & ":" & strEDTime.Substring(4, 2)

        DatTim1 = CDate(strSTDate & " " & strSTTime)
        DatTim2 = CDate(strEDDate & " " & strEDTime)

        lngRec = DateDiff(DateInterval.Minute, DatTim1, DatTim2)

        If lngRec > 99999 Then
            lngRec = 99999
        ElseIf lngRec < -9999 Then
            lngRec = -9999
        End If
        Return lngRec
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�S�_�x���R�[�h�擾
    '******************************************************************************
    Private Function fncGET_ZSISYO(ByVal strCLI As String) As String
        Return Left(strCLI, 1)

    End Function

    '******************************************************************************
    '*�@�T�@�v�F�v���_�E���}�X�^���������A�R�[�h���疼�̂��擾����
    '******************************************************************************
    Private Function fncGET_TKTAN(ByVal pstrKANSCD As String, ByVal pstrTKTANCD As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        strRes = ""
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncGET_TKTAN start pstrKANSCD=" & pstrKANSCD & ",pstrTKTANCD=" & pstrTKTANCD)

        '�c�a�I�[�v��
        cdb.mOpen()
        'SQL�쐬
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("TANNM ")
        strSQL.Append("FROM M05_TANTO ")
        strSQL.Append("WHERE KBN = :KBN ")
        strSQL.Append("  AND KURACD = :KURACD ")
        strSQL.Append("  AND CODE = :CODE ")
        strSQL.Append("  AND TANCD = :TANCD ")
        'SQL���Z�b�g
        cdb.pSQL = strSQL.ToString
        '�p�����[�^�Z�b�g
        cdb.pSQLParamStr("KBN") = "1"               '//1:�Ď��Z���^�[�S����
        cdb.pSQLParamStr("KURACD") = "ZZZZ"         '//�Ď��Z���^�[�̏ꍇALL[Z]
        cdb.pSQLParamStr("CODE") = pstrKANSCD       '//�Ď��Z���^�[�R�[�h
        cdb.pSQLParamStr("TANCD") = pstrTKTANCD     '//�S���҃R�[�h
        'SQL�����s
        cdb.mExecQuery()
        '�f�[�^�Z�b�g�ɒl���i�[
        ds = cdb.pResult
        If ds.Tables(0).Rows.Count = 0 Then
            '�f�[�^��0����������
            strRes = ""
        Else
            strRes = Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM"))
        End If
        '�c�a�N���[�Y
        cdb.mClose()
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncGET_TKTAN end pstrKANSCD=" & pstrKANSCD & ",pstrTKTANCD=" & pstrTKTANCD)
        Return strRes
    End Function

    '******************************************************************************
    '*�@�T�@�v�F�S���҂c�a�̑��݃`�F�b�N(1:���݂��Ȃ�/2:���݂���/9:�������s��Ȃ�(�ύX���Ă��Ȃ���))
    '******************************************************************************
    Private Function fncGET_TANTO( _
                                    ByVal pstrKURACD As String, _
                                    ByVal pstrJASSCD As String, _
                                    ByVal pstrTANCD As String, _
                                    ByRef pstrADD_DATE As String, _
                                    ByVal pstrTANNM As String, _
                                    ByVal pstrRENTEL1 As String, _
                                    ByVal pstrRENTEL2 As String, _
                                    ByVal pstrBIKO As String) As Integer
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim intRec As Integer
        Dim strSQL As StringBuilder
        intRec = 1
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncGET_TANTO start pstrKURACD=" & pstrKURACD & ",pstrJASSCD=" & pstrJASSCD & ",pstrTANCD=" & pstrTANCD & ",pstrADD_DATE=" & pstrADD_DATE & ",pstrTANNM=" & pstrTANNM & ",pstrRENTEL1=" & pstrRENTEL1 & ",pstrRENTEL2=" & pstrRENTEL2)

        '�c�a�I�[�v��
        cdb.mOpen()
        'SQL�쐬
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("TANNM, ")
        strSQL.Append("RENTEL1, ")
        strSQL.Append("RENTEL2, ")
        strSQL.Append("BIKO, ")
        strSQL.Append("ADD_DATE ")
        strSQL.Append("FROM M05_TANTO ")
        strSQL.Append("WHERE KBN = :KBN")
        strSQL.Append("  AND KURACD = :KURACD ")
        strSQL.Append("  AND CODE = :CODE ")
        strSQL.Append("  AND TANCD = :TANCD ")
        'SQL���Z�b�g
        cdb.pSQL = strSQL.ToString
        '�p�����[�^�ɒl���Z�b�g
        cdb.pSQLParamStr("KBN") = "3"                   '//�敪
        cdb.pSQLParamStr("KURACD") = pstrKURACD         '//�N���C�A���g�R�[�h
        cdb.pSQLParamStr("CODE") = pstrJASSCD           '//�i�`�x���R�[�h
        cdb.pSQLParamStr("TANCD") = pstrTANCD           '//�S���҃R�[�h

        'SQL���s
        cdb.mExecQuery()
        '�f�[�^�Z�b�g�ɒl���i�[
        ds = cdb.pResult

        If (ds.Tables(0).Rows.Count = 0) Then
            pstrADD_DATE = ""
            intRec = 1
        Else
            '�f�[�^�����݂����ꍇ�A���̓f�[�^�Ƃc�a�f�[�^���r���A
            '���ق�����ꍇ��[2:���݂���]��UPDATE���A
            '���ق��Ȃ��ꍇ��[9:�������s��Ȃ�]���s��
            If _
                Convert.ToString(ds.Tables(0).Rows(0).Item("TANNM")) = pstrTANNM And _
                Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL1")) = pstrRENTEL1 And _
                Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2")) = pstrRENTEL2 And _
                Convert.ToString(ds.Tables(0).Rows(0).Item("BIKO")) = pstrBIKO Then

                intRec = 9
            Else
                pstrADD_DATE = Convert.ToString(ds.Tables(0).Rows(0).Item("ADD_DATE"))
                intRec = 2
            End If
        End If
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- fncGET_TANTO end pstrKURACD=" & pstrKURACD & ",pstrJASSCD=" & pstrJASSCD & ",pstrTANCD=" & pstrTANCD & ",pstrADD_DATE=" & pstrADD_DATE & ",pstrTANNM=" & pstrTANNM & ",pstrRENTEL1=" & pstrRENTEL1 & ",pstrRENTEL2=" & pstrRENTEL2)

        Return intRec

    End Function
    '2016/02/02 W.GANEKO 2015���P�J�� ��1-3
    '************************************************
    '*�@�T�@�vSHAMAS�̘A������X�V
    '************************************************
    <WebMethod()> Public Function mUpd_SHAMAS(ByVal pstrKURACD As String, _
                                    ByVal pstrACBCD As String, _
                                    ByVal pstrUSER_CD As String, _
                                    ByVal pstrRENTEL2 As String, _
                                    ByVal pstrRENTEL2_BIKO As String, _
                                    ByVal pstrRENTEL3 As String, _
                                    ByVal pstrRENTEL3_BIKO As String _
                                    ) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        Dim rentel2Flg As Boolean = False
        Dim rentel3Flg As Boolean = False

        strRes = "OK"
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mUpd_SHAMAS start pstrKURACD=" & pstrKURACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrRENTEL2=" & pstrRENTEL2 & ",pstrRENTEL2_BIKO=" & pstrRENTEL2_BIKO & ",pstrRENTEL3=" & pstrRENTEL3 & ",pstrRENTEL3_BIKO=" & pstrRENTEL3_BIKO)

        '--------------------------------------------------
        '�ڑ�OPEN
        Try
            cdb.mOpen()
        Catch ex As Exception
            strRes = ex.ToString
            Return strRes
        Finally
        End Try

        Try
            '----------------------------------------------
            '�g�����U�N�V�����J�n
            cdb.mBeginTrans()
            '�c�a�`�F�b�N
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" * ")                                     '//���b�N�t���O
            strSQL.Append("FROM ")
            strSQL.Append("SHAMAS ")                                 '//�x��c�a
            strSQL.Append("WHERE ")
            strSQL.Append("CLI_CD = :CLI_CD ")
            strSQL.Append("AND HAN_CD = :HAN_CD ")
            strSQL.Append("AND USER_CD = :USER_CD ")
            'SQL���Z�b�g
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString
            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("CLI_CD") = pstrKURACD             '//�N���C�A���g�R�[�h
            cdb.pSQLParamStr("HAN_CD") = pstrACBCD              '//JA�x��
            cdb.pSQLParamStr("USER_CD") = pstrUSER_CD           '//���q�l�R�[�h
            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '�r������̂���
            If ds.Tables(0).Rows.Count = 0 Then
                strRes = "N1"
                '���[���o�b�N
                cdb.mRollback()
            Else
                Dim strUpdDate As String
                strUpdDate = Now.ToString("yyyyMMdd")
                Dim strRENTEL2 As String = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2"))
                If strRENTEL2.Replace("-", "") <> pstrRENTEL2.Replace("-", "") Or _
                   Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL2_BIKO")) <> pstrRENTEL2_BIKO Then
                    rentel2Flg = True
                End If
                Dim strRENTEL3 As String = Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3"))
                If strRENTEL3.Replace("-", "") <> pstrRENTEL3.Replace("-", "") Or _
                   Convert.ToString(ds.Tables(0).Rows(0).Item("RENTEL3_BIKO")) <> pstrRENTEL3_BIKO Then
                    rentel3Flg = True
                End If
                '----------------------------------------------
                '�c�a�`�F�b�N
                If rentel2Flg = True Or rentel3Flg = True Then
                    strSQL = New StringBuilder
                    strSQL.Append("UPDATE  ")
                    strSQL.Append("SHAMAS  ")
                    strSQL.Append("SET ")
                    If rentel2Flg = True Then
                        strSQL.Append("RENTEL2 = :RENTEL2, ")
                        strSQL.Append("RENTEL2_BIKO = :RENTEL2_BIKO, ")
                        strSQL.Append("RENTEL2_UPD_DATE = :RENTEL2_UPD_DATE ")
                        If rentel3Flg = True Then
                            strSQL.Append(",")
                        End If
                    End If
                    If rentel3Flg = True Then
                        strSQL.Append("RENTEL3 = :RENTEL3, ")
                        strSQL.Append("RENTEL3_BIKO = :RENTEL3_BIKO, ")
                        strSQL.Append("RENTEL3_UPD_DATE = :RENTEL3_UPD_DATE ")
                    End If
                    strSQL.Append("WHERE ")
                    strSQL.Append("CLI_CD = :CLI_CD ")
                    strSQL.Append("AND HAN_CD = :HAN_CD ")
                    strSQL.Append("AND USER_CD = :USER_CD ")
                    'SQL���Z�b�g
                    cdb.pSQL = strSQL.ToString
                    '�p�����[�^�Z�b�g
                    cdb.pSQLParamStr("CLI_CD") = pstrKURACD             '//�N���C�A���g�R�[�h
                    cdb.pSQLParamStr("HAN_CD") = pstrACBCD              '//JA�x��
                    cdb.pSQLParamStr("USER_CD") = pstrUSER_CD           '//���q�l�R�[�h
                    If rentel2Flg = True Then
                        cdb.pSQLParamStr("RENTEL2") = pstrRENTEL2.Replace("-", "") '//�A����Q
                        cdb.pSQLParamStr("RENTEL2_BIKO") = pstrRENTEL2_BIKO '//�A����Q���l
                        cdb.pSQLParamStr("RENTEL2_UPD_DATE") = strUpdDate   '//�A����Q�X�V��
                    End If
                    If rentel3Flg = True Then
                        cdb.pSQLParamStr("RENTEL3") = pstrRENTEL3.Replace("-", "") '//�A����R
                        cdb.pSQLParamStr("RENTEL3_BIKO") = pstrRENTEL3_BIKO '//�A����R���l
                        cdb.pSQLParamStr("RENTEL3_UPD_DATE") = strUpdDate   '//�A����R�X�V��
                    End If
                    'SQL�����s
                    cdb.mExecNonQuery()

                    '�R�~�b�g
                    cdb.mCommit()
                    Dim strrentel As String = ""
                    If rentel2Flg = True And rentel3Flg = True Then
                        strrentel = "1"
                    ElseIf rentel2Flg = True And rentel3Flg = False Then
                        strrentel = "2"
                    ElseIf rentel2Flg = False And rentel3Flg = True Then
                        strrentel = "3"
                    End If
                    strRes = strRes & strUpdDate & strrentel
                Else
                    strRes = "N2"
                End If
            End If
        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString
            '���[���o�b�N
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        cdb = Nothing
        mlog("[KETAIJAW00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- mUpd_SHAMAS end pstrKURACD=" & pstrKURACD & ",pstrACBCD=" & pstrACBCD & ",pstrUSER_CD=" & pstrUSER_CD & ",pstrRENTEL2=" & pstrRENTEL2 & ",pstrRENTEL2_BIKO=" & pstrRENTEL2_BIKO & ",pstrRENTEL3=" & pstrRENTEL3 & ",pstrRENTEL3_BIKO=" & pstrRENTEL3_BIKO)

        Return strRes
    End Function
    '  '2012/03/30 ADD START W.GANEKO
    '  '************************************************
    '  ' �Ή��e�[�u����8���ԓ��̏d���`�F�b�N
    '  '************************************************
    '  Private Function getSqlDupTaiou(ByVal cdb As CDB, _
    '                                  ByVal pstrKANSCD As String, _
    '                                  ByVal pstrSYONO As String, _
    '                                  ByVal pstrKMCD1 As String, _
    '                                  ByVal pstrKMNM1 As String, _
    '                                  ByVal pstrKMCD2 As String, _
    '                                  ByVal pstrKMNM2 As String, _
    '                                  ByVal pstrKMCD3 As String, _
    '                                  ByVal pstrKMNM3 As String, _
    '                                  ByVal pstrKMCD4 As String, _
    '                                  ByVal pstrKMNM4 As String, _
    '                                  ByVal pstrKMCD5 As String, _
    '                                  ByVal pstrKMNM5 As String, _
    '                                  ByVal pstrKMCD6 As String, _
    '                                  ByVal pstrKMNM6 As String, _
    '                                  ByVal pstrKURACD As String, _
    '                                  ByVal pstrJACD As String, _
    '                                  ByVal pstrACBCD As String, _
    '                                  ByVal pstrUSER_CD As String, _
    '                                  ByVal pstrHATYMD As String, _
    '                                  ByVal pstrHATTIME As String _
    ') As Boolean

    '      Dim strSQL As New StringBuilder("")
    '      Dim ds As DataSet

    '      Dim strRslt As Boolean = False
    '      '8���ԓ��ɓ���̑Ή��f�[�^�����݂��邩�m�F
    '      strSQL.Append("SELECT ")
    '      strSQL.Append("    COUNT(KANSCD) AS CNT ")
    '      strSQL.Append("FROM ")
    '      strSQL.Append("    D20_TAIOU ")
    '      strSQL.Append("WHERE ")
    '      strSQL.Append("    KANSCD = :KANSCD ")
    '      strSQL.Append("AND SYONO  < :SYONO ")
    '      strSQL.Append("AND NVL(KMCD1,'NULL')  = NVL(:KMCD1,'NULL') ")
    '      strSQL.Append("AND NVL(KMNM1,'NULL')  = NVL(:KMNM1,'NULL') ")
    '      strSQL.Append("AND NVL(KMCD2,'NULL')  = NVL(:KMCD2,'NULL') ")
    '      strSQL.Append("AND NVL(KMNM2,'NULL')  = NVL(:KMNM2,'NULL') ")
    '      strSQL.Append("AND NVL(KMCD3,'NULL')  = NVL(:KMCD3,'NULL') ")
    '      strSQL.Append("AND NVL(KMNM3,'NULL')  = NVL(:KMNM3,'NULL') ")
    '      strSQL.Append("AND NVL(KMCD4,'NULL')  = NVL(:KMCD4,'NULL') ")
    '      strSQL.Append("AND NVL(KMNM4,'NULL')  = NVL(:KMNM4,'NULL') ")
    '      strSQL.Append("AND NVL(KMCD5,'NULL')  = NVL(:KMCD5,'NULL') ")
    '      strSQL.Append("AND NVL(KMNM5,'NULL')  = NVL(:KMNM5,'NULL') ")
    '      strSQL.Append("AND NVL(KMCD6,'NULL')  = NVL(:KMCD6,'NULL') ")
    '      strSQL.Append("AND NVL(KMNM6,'NULL')  = NVL(:KMNM6,'NULL') ")
    '      strSQL.Append("AND NVL(KURACD,'NULL') = NVL(:KURACD,'NULL') ")
    '      strSQL.Append("AND NVL(JACD,'NULL')   = NVL(:JACD,'NULL') ")
    '      strSQL.Append("AND NVL(ACBCD,'NULL')  = NVL(:ACBCD,'NULL') ")
    '      strSQL.Append("AND NVL(USER_CD,'NULL') = NVL(:USER_CD,'NULL') ")
    '      strSQL.Append("AND TO_DATE(HATYMD||HATTIME,'YYYY/MM/DD HH24:MI:SS') BETWEEN ")
    '      strSQL.Append(" TO_DATE(:HATYMD||:HATTIME,'YYYY/MM/DD HH24:MI:SS')-8/24 AND ")
    '      strSQL.Append(" TO_DATE(:HATYMD||:HATTIME,'YYYY/MM/DD HH24:MI:SS') ")
    '      strSQL.Append("AND TAIOKBN <> '3' ")
    '      'SQL���Z�b�g
    '      cdb.pSQL = strSQL.ToString
    '      '�p�����[�^�ɒl���Z�b�g
    '      cdb.pSQLParamStr("KANSCD") = pstrKANSCD
    '      cdb.pSQLParamStr("SYONO") = pstrSYONO
    '      cdb.pSQLParamStr("KMCD1") = pstrKMCD1
    '      cdb.pSQLParamStr("KMNM1") = pstrKMNM1
    '      cdb.pSQLParamStr("KMCD2") = pstrKMCD2
    '      cdb.pSQLParamStr("KMNM2") = pstrKMNM2
    '      cdb.pSQLParamStr("KMCD3") = pstrKMCD3
    '      cdb.pSQLParamStr("KMNM3") = pstrKMNM3
    '      cdb.pSQLParamStr("KMCD4") = pstrKMCD4
    '      cdb.pSQLParamStr("KMNM4") = pstrKMNM4
    '      cdb.pSQLParamStr("KMCD5") = pstrKMCD5
    '      cdb.pSQLParamStr("KMNM5") = pstrKMNM5
    '      cdb.pSQLParamStr("KMCD6") = pstrKMCD6
    '      cdb.pSQLParamStr("KMNM6") = pstrKMNM6
    '      cdb.pSQLParamStr("KURACD") = pstrKURACD
    '      cdb.pSQLParamStr("JACD") = pstrJACD
    '      cdb.pSQLParamStr("ACBCD") = pstrACBCD
    '      cdb.pSQLParamStr("USER_CD") = pstrUSER_CD
    '      cdb.pSQLParamStr("HATYMD") = pstrHATYMD
    '      cdb.pSQLParamStr("HATTIME") = pstrHATTIME

    '      'SQL���s
    '      cdb.mExecQuery()
    '      '�f�[�^�Z�b�g�ɒl���i�[
    '      ds = cdb.pResult
    '      If Convert.ToInt16(ds.Tables(0).Rows(0).Item("CNT")) <> 0 Then
    '          strRslt = True
    '      End If

    '      Return strRslt
    '  End Function
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
        Dim linestring As New StringBuilder("")
        Dim strRecLog As String
        If strLogFlg = "1" Then
            '�������݃t�@�C���ւ̃X�g���[��
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[]" & pstrString & Chr(13) & Chr(10))
            ''strRecLog = LogC.mAPLog(Me.Session.SessionID, "system", "127.0.0.1", "KEJUKJAW00", "4", tbllog, "")
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
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString

            Dim cdb As New CDB
            Dim dr As DataRow
            Dim strSQL As New StringBuilder("")


            Try
                'DB�I�[�v��
                cdb.mOpen()
                cdb.mBeginTrans()
                strSQL.Append("INSERT INTO S03_APLOGDB (")
                strSQL.Append("SESSION_ID, ")
                strSQL.Append("LOGINCD, ")
                strSQL.Append("IPADR, ")
                strSQL.Append("PROC_ID, ")
                strSQL.Append("EXEC_STATUS, ")
                strSQL.Append("TEXT, ")
                strSQL.Append("MSG, ")
                strSQL.Append("ADD_DATE, ")
                strSQL.Append("TIME ")
                strSQL.Append(") VALUES (")
                strSQL.Append(":SESSION_ID, ")
                strSQL.Append(":LOGINCD, ")
                strSQL.Append(":IPADR, ")
                strSQL.Append(":PROC_ID, ")
                strSQL.Append(":EXEC_STATUS, ")
                strSQL.Append(":TEXT, ")
                strSQL.Append(":MSG, ")
                strSQL.Append(":ADD_DATE, ")
                strSQL.Append(":TIME ")
                strSQL.Append(")")

                'SQL
                cdb.pSQL = strSQL.ToString

                '�p�����[�^�ɒl���Z�b�g
                cdb.pSQLParamStr("SESSION_ID") = "KETAIJAW00"
                cdb.pSQLParamStr("LOGINCD") = "SYSTEM"
                cdb.pSQLParamStr("IPADR") = "SYSTEM"
                cdb.pSQLParamStr("PROC_ID") = "KETAIJAW00"
                cdb.pSQLParamStr("EXEC_STATUS") = "4"
                cdb.pSQLParamStr("TEXT") = tbllog
                cdb.pSQLParamStr("MSG") = tbllog.Substring(0, 100)
                cdb.pSQLParamStr("ADD_DATE") = Format(Now, "yyyyMMdd")      '�쐬��
                cdb.pSQLParamStr("TIME") = Format(Now, "HHmmss")      '�쐬����

                cdb.mExecNonQuery()
                cdb.mCommit()
            Catch

                cdb.mRollback()
            Finally
                'DB�N���[�Y
                cdb.mClose()
            End Try
        End If
    End Sub
End Class
