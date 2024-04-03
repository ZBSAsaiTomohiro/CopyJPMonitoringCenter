'***********************************************
' �Ή�����  ���s����
'***********************************************
' �ύX����
' 2010/10/27 T.Watabe FAX�s�v(�ײ���)���֐������ɒǉ��BKETAIJAW00C.mSet_Taiou��KETAIJAW00C.mSet_Taiou2�֕ύX

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports JPG.Common.log

Imports System.Text
Imports System.IO

Partial Class KETAIJJG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>�錾���ʎd�l
    '******************************************************************************
    ' �F�؃N���X
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")      '//<script>�͕K�v�Ȃ�

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
    '*�@�T�@�v�F���s�{�^��������
    '*�@���@�l�F
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles MyBase.Load
        '//------------------------------------------
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '// �F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        '//------------------------------------------
        '// �v�d�a�T�[�r�X�̃C���X�^���X���쐬
        Dim strRec As String
        Dim KETAIJAW00C As New KETAIJAG00KETAIJAW00.KETAIJAW00

        '//------------------------------------------
        '// �Ăяo�����̉�ʃN���X�C���X�^���X���쐬
        Dim KETAIJAG00C As KETAIJAG00
        KETAIJAG00C = CType(Context.Handler, KETAIJAG00)

        '//------------------------------------------
        '// �v�d�a�T�[�r�X�̎��s
        '2005/09/09 ADD Falcon ���l�A�e�`�w�^�C�g���R�[�h�ǉ�
        '           DEL Falcon ���q�l�L��
        'strRec = KETAIJAW00C.mSet_Taiou(KETAIJAG00C.pBackUrl, _ ' 2010/10/27 T.Watabe edit
        ' 2013/05/27 T.Ono edit TEL3�ǉ�
        ' 2013/08/23 T.Ono edit �{���H���󋵒ǉ� �Ď����P2013��1
        ' 2014/12/17 T.Ono edit �̔����Ǝ҃R�[�h�E���̒ǉ� 2014���P�J�� No2
        ' 2016/02/02 W.GANEKO edit �Ď����l�A�A����2�A�A����3�ǉ� 2015���P�J�� No1-3
        ' 2016/12/22 H.Mori mod 2016���P�J�� No4-1 NCU�ڑ� START
        ' 2016/12/14 H.Mori mod �����`�ԋ敪�A�X�|�b�gFAX�敪�A�d�b�ԍ��A��3�A���A����A�@�l��\�Ҏ����A�K�p�@�ߋ敪�A�p�r�敪�A�̔����R�[�h�A�ً}�A����CD 2016���P�J�� No4-6
        ' 2017/10/16 H.Mori mod �W���敪 2017���P�J�� No4-1
        ' 2020/11/01 T.Ono mod 2020�Ď����P �d�b�Ή������g��TEL_MEMO4�`6�ǉ�
        ' 2023/01/04 ADD Y.ARAKAKI 2022�X��No�E _���[JM�R�[�h�\���ǉ��Ή� ������JM�a���igstrJMNAME�j��ǉ�. D20_TAIOU�ɂ��J�����ǉ��B
        strRec = KETAIJAW00C.mSet_Taiou2(KETAIJAG00C.pBackUrl,
                                        KETAIJAG00C.pMoveSerial,
                                        KETAIJAG00C.gstrKBN,
                                        KETAIJAG00C.gstrKANSCD,
                                        KETAIJAG00C.gstrSYONO,
                                        KETAIJAG00C.gstrNCUHATYMD,
                                        KETAIJAG00C.gstrNCUHATTIME,
                                        KETAIJAG00C.gstrHATYMD,
                                        KETAIJAG00C.gstrHATTIME,
                                        KETAIJAG00C.gstrKENSIN,
                                        KETAIJAG00C.gstrKEIHOSU,
                                        KETAIJAG00C.gstrRYURYO,
                                        KETAIJAG00C.gstrMETASYU,
                                        KETAIJAG00C.gstrUNYO,
                                        KETAIJAG00C.gstrJUYMD,
                                        KETAIJAG00C.gstrJUTIME,
                                        KETAIJAG00C.gstrNUM_DIGIT,
                                        KETAIJAG00C.gstrKMCD1,
                                        KETAIJAG00C.gstrKMNM1,
                                        KETAIJAG00C.gstrKMCD2,
                                        KETAIJAG00C.gstrKMNM2,
                                        KETAIJAG00C.gstrKMCD3,
                                        KETAIJAG00C.gstrKMNM3,
                                        KETAIJAG00C.gstrKMCD4,
                                        KETAIJAG00C.gstrKMNM4,
                                        KETAIJAG00C.gstrKMCD5,
                                        KETAIJAG00C.gstrKMNM5,
                                        KETAIJAG00C.gstrKMCD6,
                                        KETAIJAG00C.gstrKMNM6,
                                        KETAIJAG00C.gstrKURACD,
                                        KETAIJAG00C.gstrKENNM,
                                        KETAIJAG00C.gstrJACD,
                                        KETAIJAG00C.gstrJANM,
                                        KETAIJAG00C.gstrHANJICD,
                                        KETAIJAG00C.gstrHANJINM,
                                        KETAIJAG00C.gstrACBCD,
                                        KETAIJAG00C.gstrACBNM,
                                        KETAIJAG00C.gstrUSER_CD,
                                        KETAIJAG00C.gstrJUSYONM,
                                        KETAIJAG00C.gstrJUSYOKN,
                                        KETAIJAG00C.gstrJUTEL1,
                                        KETAIJAG00C.gstrJUTEL2,
                                        KETAIJAG00C.gstrRENTEL,
                                        KETAIJAG00C.gstrKTELNO,
                                        KETAIJAG00C.gstrADDR,
                                        KETAIJAG00C.gstrNCU_SET,
                                        KETAIJAG00C.gstrTIZUNO,
                                        KETAIJAG00C.gstrHANBAI_KBN,
                                        KETAIJAG00C.gstrKYOKTKBN,
                                        KETAIJAG00C.gstrMET_KATA,
                                        KETAIJAG00C.gstrMET_MAKER,
                                        KETAIJAG00C.gstrBONB1_KKG,
                                        KETAIJAG00C.gstrBONB1_HON,
                                        KETAIJAG00C.gstrBONB1_YOBI,
                                        KETAIJAG00C.gstrBONB2_KKG,
                                        KETAIJAG00C.gstrBONB2_HON,
                                        KETAIJAG00C.gstrBONB2_YOBI,
                                        KETAIJAG00C.gstrBONB3_KKG,
                                        KETAIJAG00C.gstrBONB3_HON,
                                        KETAIJAG00C.gstrBONB3_YOBI,
                                        KETAIJAG00C.gstrBONB4_KKG,
                                        KETAIJAG00C.gstrBONB4_HON,
                                        KETAIJAG00C.gstrBONB4_YOBI,
                                        KETAIJAG00C.gstrZENKAI_HAISO,
                                        KETAIJAG00C.gstrZENKAI_HAI_S,
                                        KETAIJAG00C.gstrKONKAI_HAISO,
                                        KETAIJAG00C.gstrKONKAI_HAI_S,
                                        KETAIJAG00C.gstrJIKAI_HAISO,
                                        KETAIJAG00C.gstrZENKAI_KENSIN,
                                        KETAIJAG00C.gstrZENKAI_KEN_S,
                                        KETAIJAG00C.gstrZENKAI_KEN_SIYO,
                                        KETAIJAG00C.gstrKONKAI_KENSIN,
                                        KETAIJAG00C.gstrKONKAI_KEN_S,
                                        KETAIJAG00C.gstrKONKAI_KEN_SIYO,
                                        KETAIJAG00C.gstrZENKAI_HASEI,
                                        KETAIJAG00C.gstrZENKAI_HAS_S,
                                        KETAIJAG00C.gstrKONKAI_HASEI,
                                        KETAIJAG00C.gstrKONKAI_HAS_S,
                                        KETAIJAG00C.gstrG_ZAIKO,
                                        KETAIJAG00C.gstrICHI_SIYO,
                                        KETAIJAG00C.gstrYOSOKU_ICHI_SIYO,
                                        KETAIJAG00C.gstrGAS1_HINMEI,
                                        KETAIJAG00C.gstrGAS1_DAISU,
                                        KETAIJAG00C.gstrGAS1_SEIFL,
                                        KETAIJAG00C.gstrGAS2_HINMEI,
                                        KETAIJAG00C.gstrGAS2_DAISU,
                                        KETAIJAG00C.gstrGAS2_SEIFL,
                                        KETAIJAG00C.gstrGAS3_HINMEI,
                                        KETAIJAG00C.gstrGAS3_DAISU,
                                        KETAIJAG00C.gstrGAS3_SEIFL,
                                        KETAIJAG00C.gstrGAS4_HINMEI,
                                        KETAIJAG00C.gstrGAS4_DAISU,
                                        KETAIJAG00C.gstrGAS4_SEIFL,
                                        KETAIJAG00C.gstrGAS5_HINMEI,
                                        KETAIJAG00C.gstrGAS5_DAISU,
                                        KETAIJAG00C.gstrGAS5_SEIFL,
                                        KETAIJAG00C.gstrHATKBN,
                                        KETAIJAG00C.gstrTAIOKBN,
                                        KETAIJAG00C.gstrTMSKB,
                                        KETAIJAG00C.gstrTKTANCD,
                                        KETAIJAG00C.gstrTAITCD,
                                        KETAIJAG00C.gstrTAIO_ST_DATE,
                                        KETAIJAG00C.gstrTAIO_ST_TIME,
                                        KETAIJAG00C.gstrSYOYMD,
                                        KETAIJAG00C.gstrSYOTIME,
                                        KETAIJAG00C.gstrTAIO_SYO_TIME,
                                        KETAIJAG00C.gstrFAXKBN,
                                        KETAIJAG00C.gstrFAXKURAKBN,
                                        KETAIJAG00C.gstrFAXRUISEKIKBN,
                                        KETAIJAG00C.gstrTELRCD,
                                        KETAIJAG00C.gstrTFKICD,
                                        KETAIJAG00C.gstrFUK_MEMO,
                                        KETAIJAG00C.gstrTEL_MEMO1,
                                        KETAIJAG00C.gstrTEL_MEMO2,
                                        KETAIJAG00C.gstrTEL_MEMO4,
                                        KETAIJAG00C.gstrTEL_MEMO5,
                                        KETAIJAG00C.gstrTEL_MEMO6,
                                        KETAIJAG00C.gstrMITOKBN,
                                        KETAIJAG00C.gstrTKIGCD,
                                        KETAIJAG00C.gstrTSADCD,
                                        KETAIJAG00C.gstrGENIN_KIJI,
                                        KETAIJAG00C.gstrSDCD,
                                        KETAIJAG00C.gstrSIJIYMD,
                                        KETAIJAG00C.gstrSIJITIME,
                                        KETAIJAG00C.gstrSIJI_BIKO1,
                                        KETAIJAG00C.gstrSIJI_BIKO2,
                                        KETAIJAG00C.gstrSTD_JASCD,
                                        KETAIJAG00C.gstrSTD_JANA,
                                        KETAIJAG00C.gstrSTD_JASNA,
                                        KETAIJAG00C.gstrREN_CODE,
                                        KETAIJAG00C.gstrREN_NA,
                                        KETAIJAG00C.gstrREN_TEL_1,
                                        KETAIJAG00C.gstrREN_TEL_2,
                                        KETAIJAG00C.gstrREN_TEL_3,
                                        KETAIJAG00C.gstrREN_FAX,
                                        KETAIJAG00C.gstrREN_BIKO,
                                        KETAIJAG00C.gstrREN_EDT_DATE,
                                        KETAIJAG00C.gstrREN_TIME,
                                        KETAIJAG00C.gstrREN_1_CODE,
                                        KETAIJAG00C.gstrREN_1_NA,
                                        KETAIJAG00C.gstrREN_1_TEL1,
                                        KETAIJAG00C.gstrREN_1_TEL2,
                                        KETAIJAG00C.gstrREN_1_TEL3,
                                        KETAIJAG00C.gstrREN_1_FAX,
                                        KETAIJAG00C.gstrREN_1_BIKO,
                                        KETAIJAG00C.gstrREN_1_EDT_DATE,
                                        KETAIJAG00C.gstrREN_1_TIME,
                                        KETAIJAG00C.gstrREN_2_CODE,
                                        KETAIJAG00C.gstrREN_2_NA,
                                        KETAIJAG00C.gstrREN_2_TEL1,
                                        KETAIJAG00C.gstrREN_2_TEL2,
                                        KETAIJAG00C.gstrREN_2_TEL3,
                                        KETAIJAG00C.gstrREN_2_FAX,
                                        KETAIJAG00C.gstrREN_2_BIKO,
                                        KETAIJAG00C.gstrREN_2_EDT_DATE,
                                        KETAIJAG00C.gstrREN_2_TIME,
                                        KETAIJAG00C.gstrREN_3_CODE,
                                        KETAIJAG00C.gstrREN_3_NA,
                                        KETAIJAG00C.gstrREN_3_TEL1,
                                        KETAIJAG00C.gstrREN_3_TEL2,
                                        KETAIJAG00C.gstrREN_3_TEL3,
                                        KETAIJAG00C.gstrREN_3_FAX,
                                        KETAIJAG00C.gstrREN_3_BIKO,
                                        KETAIJAG00C.gstrREN_3_EDT_DATE,
                                        KETAIJAG00C.gstrREN_3_TIME,
                                        KETAIJAG00C.gstrREN_DENWABIKO,
                                        KETAIJAG00C.gstrREN_FAXTITLE,
                                        KETAIJAG00C.gstrREN_FAX_REN,
                                        KETAIJAG00C.gstrSTD_CD,
                                        KETAIJAG00C.gstrSTD,
                                        KETAIJAG00C.gstrSTD_KYOTEN_CD,
                                        KETAIJAG00C.gstrSTD_KYOTEN,
                                        KETAIJAG00C.gstrSTD_TEL,
                                        KETAIJAG00C.gstrADD_DATE,
                                        KETAIJAG00C.gstrEDT_DATE,
                                        KETAIJAG00C.gstrTIME,
                                        KETAIJAG00C.gstrBOMB_TYPE,
                                        KETAIJAG00C.gstrGAS_STOP,
                                        KETAIJAG00C.gstrGAS_DELE,
                                        KETAIJAG00C.gstrGAS_RESTART,
                                        KETAIJAG00C.gstrKAITU_DAY,
                                        KETAIJAG00C.gstrBIKOU,
                                        KETAIJAG00C.gstrFAX_TITLE_CD,
                                        KETAIJAG00C.gstrDialKbns,
                                        KETAIJAG00C.gstrDialNumbers,
                                        KETAIJAG00C.gstrDialAites,
                                        KETAIJAG00C.gstrDialResult,
                                        KETAIJAG00C.gstrDialDates,
                                        KETAIJAG00C.gstrDialTimes,
                                        KETAIJAG00C.gstrDialStates,
                                        KETAIJAG00C.gstrSDSKBN,
                                        "0",
                                        KETAIJAG00C.gstrKANSHI_BIKO,
                                        KETAIJAG00C.gstrRENTEL2,
                                        KETAIJAG00C.gstrRENTEL2_BIKO,
                                        KETAIJAG00C.gstrRENTEL2_UPD_DATE,
                                        KETAIJAG00C.gstrRENTEL3,
                                        KETAIJAG00C.gstrRENTEL3_BIKO,
                                        KETAIJAG00C.gstrRENTEL3_UPD_DATE,
                                        KETAIJAG00C.gstrTUSIN,
                                        KETAIJAG00C.gstrFAXSPOTKBN,
                                        KETAIJAG00C.gstrTELAB,
                                        KETAIJAG00C.gstrDAI3RENDORENTEL,
                                        KETAIJAG00C.gstrDAIHYO_NAME,
                                        KETAIJAG00C.gstrHOKBN,
                                        KETAIJAG00C.gstrYOTOKBN,
                                        KETAIJAG00C.gstrHANBCD,
                                        KETAIJAG00C.gstrKINRENCD,
                                        KETAIJAG00C.gstrSHUGOU,
                                        KETAIJAG00C.gstrJMNAME
                                        )

        Dim strRecMsg As String
        If strRec <> "OK" Then
            strMsg.Append("parent.Data.Form1.btnExit.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnTelHas1.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnRireki.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnUpdate.disabled=false;")
            strMsg.Append("parent.Data.Form1.btnRenraku.disabled=false;")
            strMsg.Append("parent.Data.Form1.txtSYOYMD.readOnly=false;")
            strMsg.Append("parent.Data.Form1.txtSIJIYMD.readOnly=false;")
        End If

        Select Case strRec
            Case "OK"   '//����I��
                If KETAIJAG00C.pBackUrl() = "KEJUKJAG00" Then
                    '2012/06/28 W.GANEKO ADD
                    mlog("�Ή����͓o�^|" & KETAIJAG00C.pMoveSerial & "|1" & KETAIJAG00C.gstrHATYMD & KETAIJAG00C.gstrHATTIME & KETAIJAG00C.pMoveSerial)
                End If
                '--- ��2005/05/19 MOD Falcon�� ---
                strMsg.Append("alert('����ɏI�����܂���');")
                If Request.Form("hdnCtiFlg") = "1" Then
                    '�b�s�h�ɂ��f�[�^�X�V�ˉ�ʂ����
                    strMsg.Append("parent.Data.fncWindow_close();")
                Else
                    '�ʏ폈���ˉ�ʑJ��
                    '���̑������̏ꍇ�͏I���{�^���C�x���g
                    strMsg.Append("parent.Data.doPostBack('btnExit','');")
                End If
                '--- ��2005/05/19 MOD Falcon�� ---
            Case "1"
                strRecMsg = "�Ώۃf�[�^�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "2"
                strRecMsg = "���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "3"
                strRecMsg = "���ɑΉ��ς݂ɂȂ��Ă��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T0"
                strRecMsg = "�S���҃f�[�^���A���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T1"
                strRecMsg = "�S���҃f�[�^���A���Ƀf�[�^�����݂��܂�"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T2"
                strRecMsg = "�Ώۂ̒S���҃f�[�^�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T3"
                strRecMsg = "�S���҃f�[�^�X�V���A�r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T4"
                strRecMsg = "�S���҃f�[�^�̃N���C�A���g�R�[�h�����݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case "T5"
                strRecMsg = "�i�`�x�������݂��܂���"
                strMsg.Append("alert('" & strRecMsg & "');")
                strRec = strRecMsg
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
            Case Else
                Dim ErrMsgC As New CErrMsg
                strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(strRec) & "');")
                strMsg.Append("parent.Data.Form1.btnUpdate.focus();")
        End Select

        '-------------------------------------------------
        '//�`�o���O��������
        Dim LogC As New CLog
        Dim strRecLog As String
        '2012/04/04 NEC ou Upd Str
        'strRecLog = LogC.mAPLog(Request.Cookies.Get("ASP.NET_SessionId").Value, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), KETAIJAG00C.gstrKBN, strRec, Request.Form)
        strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), KETAIJAG00C.gstrKBN, strRec, Request.Form)
        '2012/04/04 NEC ou Upd End
        If strRecLog <> "OK" Then
            Dim errmsgc As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & errmsgc.mGetArtMsg(strRecLog) & "');")
        End If

        '-------------------------------------------------
        '//
        strMsg.Append("location.replace('about:blank');")   '��M�t���[�������u�����N�y�[�W�ɁB

    End Sub
    '**********************************************************
    '2012/06/28 W.GANEKO ADD
    '���O�f���o��
    '�߂�l�F�������񂾃t�@�C���ւ̃t���p�X
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim linestring As New StringBuilder("")
        Dim LogC As New CLog

        Dim strRecLog As String
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
End Class
