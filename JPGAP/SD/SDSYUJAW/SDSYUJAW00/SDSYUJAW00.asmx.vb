'***********************************************
' �o����ЃV�X�e�� �ً}�Ή�������
'***********************************************
' �ύX����
' 2010/04/02 T.Watabe �o����Ў�t�҂̖��̂����Ă��Ȃ������_���C��

Option Explicit On 
Option Strict On

Imports Common.DB

Imports System.Text
Imports System.Web.Services

<System.Web.Services.WebService(Namespace:="http://tempuri.org/SDSYUJAW00/Service1")> _
Public Class SDSYUJAW00
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

    ' WEB �T�[�r�X�̗�
    ' HelloWorld() �T���v�� �T�[�r�X�́AHello World �Ƃ����������Ԃ��܂��B
    ' �r���h����ɂ́A�ȉ��̍s����R�����g���O���ăv���W�F�N�g��ۑ��A�r���h���Ă��������B
    ' ���� Web �T�[�r�X���e�X�g����ɂ́A.asmx �t�@�C�����X�^�[�g �y�[�W�ɐݒ肳��Ă��邱�Ƃ��m�F���A
    ' F5 �L�[�������Ă��������B
    '
    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function
    'pintKBN
    '   1:�V�K�o�^
    '   2:�C���o�^
    '   3:�폜
    '************************************************
    '�S���҃}�X�^���X�g�f�[�^�擾
    '************************************************
    '�y���ʁz
    '  OK : ����ɏI�����܂���
    '   0 : ���̃��[�U�[�ɂ���ăf�[�^���X�V����Ă��܂��B�ēx�������Ă�������
    '   1 : ���Ƀf�[�^�����݂��܂�
    '   2 : �Ώۃf�[�^�����݂��܂���
    '   3 : �r�����䏈���ŃG���[���������܂����B�ēx���s���Ă�������

    '2006/06/14 NEC UPDATE START
    '<WebMethod()> Public Function mSet( _
    '                                ByVal pstrKANSCD As String, _
    '                                ByVal pstrSYONO As String, _
    '                                ByVal pstrKBN As String, _
    '                                ByVal pstrTSTANCD As String, _
    '                                ByVal pstrSTD_CD As String, _
    '                                ByVal pstrSTD_KYOTEN_CD As String, _
    '                                ByVal pstrSYUTDTNM As String, _
    '                                ByVal pstrSIJIYMD As String, _
    '                                ByVal pstrSIJITIME As String, _
    '                                ByVal pstrTYAKYMD As String, _
    '                                ByVal pstrTYAKTIME As String, _
    '                                ByVal pstrSYOKANYMD As String, _
    '                                ByVal pstrSYOKANTIME As String, _
    '                                ByVal pstrAITCD As String, _
    '                                ByVal pstrMETHEIKAKU As String, _
    '                                ByVal pstrRUSUHARI As String, _
    '                                ByVal pstrKIGCD As String, _
    '                                ByVal pstrSADCD As String, _
    '                                ByVal pstrASECD As String, _
    '                                ByVal pstrSTACD As String, _
    '                                ByVal pstrFKICD As String, _
    '                                ByVal pstrJAKENREN As String, _
    '                                ByVal pstrRENTIME As String, _
    '                                ByVal pstrKIGTAIYO As String, _
    '                                ByVal pstrGASMUMU As String, _
    '                                ByVal pstrORGENIN As String, _
    '                                ByVal pstrHAIKAN As String, _
    '                                ByVal pstrGASGUMU As String, _
    '                                ByVal pstrHOSKOKAN As String, _
    '                                ByVal pstrMETYOINA As String, _
    '                                ByVal pstrTYOUYOINA As String, _
    '                                ByVal pstrVALYOINA As String, _
    '                                ByVal pstrKYUHAIUMU As String, _
    '                                ByVal pstrCOYOINA As String, _
    '                                ByVal pstrSDTBIK2 As String, _
    '                                ByVal pstrSNTTOKKI As String, _
    '                                ByVal pstrMETFUKKI As String, _
    '                                ByVal pstrHOAN As String, _
    '                                ByVal pstrGASGIRE As String, _
    '                                ByVal pstrKIGKOSYO As String, _
    '                                ByVal pstrCSNTGEN As String, _
    '                                ByVal pstrCSNTNGAS As String, _
    '                                ByVal pstrSDTBIK1 As String, _
    '                                ByVal pstrADD_DATE As String, _
    '                                ByVal pstrEDT_DATE As String, _
    '                                ByVal pstrTIME As String) As String
    ' 2014/10/30 H.Hosoda mod 2014���P�J�� No11 START
    '<WebMethod()> Public Function mSet( _
    '                        ByVal pstrKANSCD As String, _
    '                        ByVal pstrSYONO As String, _
    '                        ByVal pstrKBN As String, _
    '                        ByVal pstrTSTANCD As String, _
    '                        ByVal pstrSTD_CD As String, _
    '                        ByVal pstrSTD_KYOTEN_CD As String, _
    '                        ByVal pstrSYUTDTNM As String, _
    '                        ByVal pstrSIJIYMD As String, _
    '                        ByVal pstrSIJITIME As String, _
    '                        ByVal pstrSDYMD As String, _
    '                        ByVal pstrSDTIME As String, _
    '                        ByVal pstrTYAKYMD As String, _
    '                        ByVal pstrTYAKTIME As String, _
    '                        ByVal pstrSYOKANYMD As String, _
    '                        ByVal pstrSYOKANTIME As String, _
    '                        ByVal pstrAITCD As String, _
    '                        ByVal pstrMETHEIKAKU As String, _
    '                        ByVal pstrRUSUHARI As String, _
    '                        ByVal pstrKIGCD As String, _
    '                        ByVal pstrSADCD As String, _
    '                        ByVal pstrASECD As String, _
    '                        ByVal pstrSTACD As String, _
    '                        ByVal pstrFKICD As String, _
    '                        ByVal pstrJAKENREN As String, _
    '                        ByVal pstrRENTIME As String, _
    '                        ByVal pstrKIGTAIYO As String, _
    '                        ByVal pstrGASMUMU As String, _
    '                        ByVal pstrORGENIN As String, _
    '                        ByVal pstrHAIKAN As String, _
    '                        ByVal pstrGASGUMU As String, _
    '                        ByVal pstrHOSKOKAN As String, _
    '                        ByVal pstrMETYOINA As String, _
    '                        ByVal pstrTYOUYOINA As String, _
    '                        ByVal pstrVALYOINA As String, _
    '                        ByVal pstrKYUHAIUMU As String, _
    '                        ByVal pstrCOYOINA As String, _
    '                        ByVal pstrSDTBIK2 As String, _
    '                        ByVal pstrSNTTOKKI As String, _
    '                        ByVal pstrSDTBIK3 As String, _
    '                        ByVal pstrMETFUKKI As String, _
    '                        ByVal pstrHOAN As String, _
    '                        ByVal pstrGASGIRE As String, _
    '                        ByVal pstrKIGKOSYO As String, _
    '                        ByVal pstrCSNTGEN As String, _
    '                        ByVal pstrCSNTNGAS As String, _
    '                        ByVal pstrSDTBIK1 As String, _
    '                        ByVal pstrADD_DATE As String, _
    '                        ByVal pstrEDT_DATE As String, _
    '                        ByVal pstrTIME As String) As String
    '2006/06/14 NEC UPDATE END
    <WebMethod()> Public Function mSet( _
                            ByVal pstrKANSCD As String, _
                            ByVal pstrSYONO As String, _
                            ByVal pstrKBN As String, _
                            ByVal pstrTSTANCD As String, _
                            ByVal pstrTSTANNM As String, _
                            ByVal pstrSTD_CD As String, _
                            ByVal pstrSTD_KYOTEN_CD As String, _
                            ByVal pstrSYUTDTNM As String, _
                            ByVal pstrSIJIYMD As String, _
                            ByVal pstrSIJITIME As String, _
                            ByVal pstrSDYMD As String, _
                            ByVal pstrSDTIME As String, _
                            ByVal pstrTYAKYMD As String, _
                            ByVal pstrTYAKTIME As String, _
                            ByVal pstrSYOKANYMD As String, _
                            ByVal pstrSYOKANTIME As String, _
                            ByVal pstrAITCD As String, _
                            ByVal pstrMETHEIKAKU As String, _
                            ByVal pstrRUSUHARI As String, _
                            ByVal pstrKIGCD As String, _
                            ByVal pstrSADCD As String, _
                            ByVal pstrASECD As String, _
                            ByVal pstrSTACD As String, _
                            ByVal pstrFKICD As String, _
                            ByVal pstrJAKENREN As String, _
                            ByVal pstrRENTIME As String, _
                            ByVal pstrKIGTAIYO As String, _
                            ByVal pstrGASMUMU As String, _
                            ByVal pstrORGENIN As String, _
                            ByVal pstrHAIKAN As String, _
                            ByVal pstrGASGUMU As String, _
                            ByVal pstrHOSKOKAN As String, _
                            ByVal pstrMETYOINA As String, _
                            ByVal pstrTYOUYOINA As String, _
                            ByVal pstrVALYOINA As String, _
                            ByVal pstrKYUHAIUMU As String, _
                            ByVal pstrCOYOINA As String, _
                            ByVal pstrSDTBIK2 As String, _
                            ByVal pstrSNTTOKKI As String, _
                            ByVal pstrSDTBIK3 As String, _
                            ByVal pstrMETFUKKI As String, _
                            ByVal pstrHOAN As String, _
                            ByVal pstrGASGIRE As String, _
                            ByVal pstrKIGKOSYO As String, _
                            ByVal pstrCSNTGEN As String, _
                            ByVal pstrCSNTNGAS As String, _
                            ByVal pstrSDTBIK1 As String, _
                            ByVal pstrADD_DATE As String, _
                            ByVal pstrEDT_DATE As String, _
                            ByVal pstrTIME As String) As String
        ' 2014/10/30 H.Hosoda mod 2014���P�J�� No11 END
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder

        Dim strTAIO_ST_DATE As String
        Dim strTAIO_ST_TIME As String
        '2006/06/23 NEC ADD START
        Dim strTMSKB_NAI As String
        '2006/06/23 NEC ADD END

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
            '�E�r���̃`�F�b�N���s���B
            '�E�C�����ɂ̓f�[�^�͑��݂��邱��
            '*********************************

            '�c�a�`�F�b�N(��{)-----------------------------
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT ")
            strSQL.Append(" EDT_DATE, ")             '�X�V��
            strSQL.Append(" EDT_TIME, ")              '�X�V����
            strSQL.Append(" TAIO_ST_DATE ,")              '�X�V����
            strSQL.Append(" TAIO_ST_TIME ")              '�X�V����
            strSQL.Append("FROM ")
            strSQL.Append("D20_TAIOU ")              '�Ή��c�a
            strSQL.Append("WHERE KANSCD = :KANSCD ") '�č��R�[�h
            strSQL.Append("AND   SYONO  = :SYONO  ") '�����ԍ�
            strSQL.Append("FOR UPDATE NOWAIT ")      '�r�������������

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("KANSCD") = pstrKANSCD   '�敪
            cdb.pSQLParamStr("SYONO") = pstrSYONO     '�R�[�h
            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult

            '*****************************************************
            '�C���������L�[�̃f�[�^�����݂��Ȃ��ꍇ�̓G���[�Ƃ���
            '*****************************************************
            If (ds.Tables(0).Rows.Count = 0) Then
                strRes = "2"
                Exit Try
            End If
            '*****************************************************
            '�C�����Ŏ󂯓n���ꂽ���t�y�ю��ԂƍX�V�Ώۃf�[�^���قȂ�ꍇ�G���[
            '*****************************************************
            If ((Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_DATE")) <> pstrEDT_DATE) Or _
                (Convert.ToString(ds.Tables(0).Rows(0).Item("EDT_TIME")) <> pstrTIME)) Then
                strRes = "0"
                Exit Try
            End If
            strTAIO_ST_DATE = Convert.ToString(ds.Tables(0).Rows(0).Item("TAIO_ST_DATE"))
            strTAIO_ST_TIME = Convert.ToString(ds.Tables(0).Rows(0).Item("TAIO_ST_TIME"))

            '���̂̎擾�i��ʂ���̓R�[�h�݂̂̎擾�����Ă������)

            ' 2014/10/30 H.Hosoda del 2014���P�J�� No11 START
            '//��M�Җ�
            'Dim strTSTANNM As String = fncGET_TANNM(pstrSTD_CD, pstrTSTANCD) ' 2010/04/02 T.Watabe edit
            'Dim strTSTANNM As String = fncGET_TANNM(pstrSTD_CD + pstrSTD_KYOTEN_CD, pstrTSTANCD) '�o����к��ށ{���_���ށA�o����Ў�t�҂Ō���
            'If strTSTANNM = "" Then
            '    strTSTANNM = fncGET_TANNM(pstrSTD_CD, pstrTSTANCD) '�o����к��ށA�o����Ў�t�҂Ō���
            'End If
            ' 2014/10/30 H.Hosoda del 2014���P�J�� No11 END

            '//����
            'Dim strSTD As String = fncGET_KYOTEN(pstrSTD_CD) 2008/02/07 T.Watabe edit �������X�V����Ȃ��o�O���C��
            'Dim strSTD As String = fncGET_KYOTEN(pstrSTD_KYOTEN_CD)
            'Dim strSTD_KYOTEN As String = fncGET_KYOTEN(pstrSTD_KYOTEN_CD) 2008/02/14 T.Watabe edit
            Dim strSTD_KYOTEN As String = fncGET_KYOTEN(pstrSTD_CD, pstrSTD_KYOTEN_CD)
            '//�Ή�����
            Dim strAITNM As String = fncGET_PULLNM("12", pstrAITCD)
            '//����
            Dim strKIGNM As String = fncGET_PULLNM("51", pstrKIGCD)
            '//�쓮����
            Dim strSADNM As String = fncGET_PULLNM("52", pstrSADCD)
            '//�쓮����
            'Dim strASENM As String = fncGET_PULLNM("53", pstrASECD) ' 2008/10/16 T.Watabe edit
            Dim strASENM As String = ""
            '//���̑�����
            'Dim strSTANM As String = fncGET_PULLNM("54", pstrSTACD) ' 2008/10/16 T.Watabe edit
            Dim strSTANM As String = ""
            '//���A����
            Dim strFKINM As String = fncGET_PULLNM("55", pstrFKICD)

            '2006/06/23 NEC ADD START
            '*****************************************************
            '�����敪���̎擾
            '*****************************************************
            strSQL = New StringBuilder("")
            strSQL.Append("SELECT NAME FROM M06_PULLDOWN WHERE KBN='10' AND CD=:CD")
            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            '�p�����[�^�ɒl���Z�b�g
            cdb.pSQLParamStr("CD") = pstrKBN   '�R�[�h
            'SQL���s
            cdb.mExecQuery()
            ds = cdb.pResult
            strTMSKB_NAI = Convert.ToString(ds.Tables(0).Rows(0).Item("NAME"))

            '2006/06/23 NEC ADD END

            '*****************************************************
            '�Ή��c�a�̍X�V����
            '*****************************************************
            strSQL = New StringBuilder("")
            strSQL.Append("UPDATE D20_TAIOU ")
            strSQL.Append("SET TSTANCD    = :TSTANCD ")                     '��M�҃R�[�h
            strSQL.Append("   ,TSTANNM    = :TSTANNM ")                     '��M�Ҏ���
            strSQL.Append("   ,STD_KYOTEN_CD = :STD_KYOTEN_CD ")            '�o����Ћ��_�R�[�h '2008/02/08 T.Watabe add
            strSQL.Append("   ,STD_KYOTEN    = :STD_KYOTEN ")               '�o����Ћ��_��     '2008/02/08 T.Watabe add

            '2008/10/15 T.Watabe del �o����Ђ̏����������݂̂��X�V����悤�ɕύX
            'If pstrKBN = "2" Then
            '    '//�Ή�����
            '    strSQL.Append("   ,SYOYMD     = REPLACE(:SYOKANYMD,'/')")   '����������
            '    strSQL.Append("   ,SYOTIME    = REPLACE(:SYOKANTIME,':')")  '������������
            '    strSQL.Append("   ,TAIO_SYO_TIME    = :TAIO_SYO_TIME   ")   '���v����
            'Else
            '    '//�Ή����@���Ή��������͍폜����
            '    strSQL.Append("   ,SYOYMD  = '' ")                          '����������
            '    strSQL.Append("   ,SYOTIME = '' ")                          '������������
            '    strSQL.Append("   ,TAIO_SYO_TIME = ''   ")                  '���v����
            'End If

            strSQL.Append("   ,SYUTDTNM   = :SYUTDTNM  ")                   '�o���Ή���
            strSQL.Append("   ,SIJIYMD    = REPLACE(:SIJIYMD,'/')     ")    '�o���w�����t
            strSQL.Append("   ,SIJITIME   = REPLACE(:SIJITIME,':')    ")    '�o���w������
            strSQL.Append("   ,SDYMD    = REPLACE(:SDYMD,'/')   ")          '�o����  ' 2008/10/14 T.Watabe add
            strSQL.Append("   ,SDTIME   = REPLACE(:SDTIME,':')  ")          '�o������  ' 2008/10/14 T.Watabe add
            strSQL.Append("   ,TYAKYMD    = REPLACE(:TYAKYMD,'/')   ")      '������
            strSQL.Append("   ,TYAKTIME   = REPLACE(:TYAKTIME,':')  ")      '��������
            strSQL.Append("   ,SYOKANYMD  = REPLACE(:SYOKANYMD,'/') ")      '����������
            strSQL.Append("   ,SYOKANTIME = REPLACE(:SYOKANTIME,':')")      '������������
            strSQL.Append("   ,AITCD      = :AITCD     ")                   '�Ή�����
            strSQL.Append("   ,AITNM      = :AITNM     ")                   '�Ή����薼
            strSQL.Append("   ,METHEIKAKU = :METHEIKAKU")                   '�s�ݎ��̑[�u�@���[�^�Ւf�ٕ~�m�F 1:�L
            strSQL.Append("   ,RUSUHARI   = :RUSUHARI  ")                   '�s�ݎ��̑[�u�@�����\���̓\�t�@ 1:�L
            strSQL.Append("   ,KIGCD      = :KIGCD     ")                   '�����R�[�h	
            strSQL.Append("   ,KIGNM      = :KIGNM     ")                   '��������	
            strSQL.Append("   ,SADCD      = :SADCD     ")                   '�쓮�����R�[�h	
            strSQL.Append("   ,SADNM      = :SADNM     ")                   '�쓮��������	
            strSQL.Append("   ,ASECD      = :ASECD     ")                   '���̓Z���T�[�쓮����
            strSQL.Append("   ,ASENM      = :ASENM     ")                   '���̓Z���T�[�쓮����
            strSQL.Append("   ,STACD      = :STACD     ")                   '���̑������R�[�h
            strSQL.Append("   ,STANM      = :STANM     ")                   '���̑���������
            strSQL.Append("   ,FKICD      = :FKICD     ")                   '���A����R�[�h
            strSQL.Append("   ,FKINM      = :FKINM     ")                   '���A���얼��
            strSQL.Append("   ,JAKENREN   = :JAKENREN  ")                   '�i�`�^���A�ւ̘A������
            strSQL.Append("   ,RENTIME    = REPLACE(:RENTIME,':')   ")      '�i�`�^���A�ւ̘A������
            strSQL.Append("   ,KIGTAIYO   = :KIGTAIYO  ")                   '�ȈՃK�X���̑ݗ^�@1�F�L
            strSQL.Append("   ,GASMUMU    = :GASMUMU   ")                   '�K�X�R��_���@0�F�L�@1�F��
            strSQL.Append("   ,ORGENIN    = :ORGENIN   ")                   '�K�X�R��_���L�@�����@�K�X���@1:�L
            strSQL.Append("   ,HAIKAN     = :HAIKAN    ")                   '�K�X�R��_���L�@�����@�z�ǁ@1:�L
            strSQL.Append("   ,GASGUMU    = :GASGUMU   ")                   '�K�X�؂�m�F�@0�F�L�@1�F��
            strSQL.Append("   ,HOSKOKAN   = :HOSKOKAN  ")                   '�S���z�[�X�����@0�F���{�@1�F�����{
            strSQL.Append("   ,METYOINA   = :METYOINA  ")                   '���̑��_���@���[�^�@0�F�ǁ@1�F��
            strSQL.Append("   ,TYOUYOINA  = :TYOUYOINA ")                   '���̑��_���@������@0�F�ǁ@1�F��
            strSQL.Append("   ,VALYOINA   = :VALYOINA  ")                   '���̑��_���@�e��E���ԃo���u�@0�F�ǁ@1�F��
            strSQL.Append("   ,KYUHAIUMU  = :KYUHAIUMU ")                   '���̑��_���@�z�r�C���@0�F�L�@1�F��
            strSQL.Append("   ,COYOINA    = :COYOINA   ")                   '���̑��_���@�b�n�Z�x�@0�F�ǁ@1�F��
            strSQL.Append("   ,SDTBIK2    = :SDTBIK2   ")                   '���L����
            strSQL.Append("   ,SNTTOKKI   = :SNTTOKKI  ")                   '���̑����L����
            strSQL.Append("   ,SDTBIK3    = :SDTBIK3   ")                   '�o�����ʓ��e/�� '2006/06/15 NEC UPDATE
            'strSQL.Append("   ,TMSKB     = :TMSKB     ")                   '�����敪 ' 2008/10/15 T.Watabe edit
            strSQL.Append("   ,SDSKBN     = :SDSKBN     ")                  '�o����Џ����敪
            'strSQL.Append("   ,TMSKB_NAI = :TMSKB_NAI ")                   '�����敪�� '2006/06/23 NEC ADD
            strSQL.Append("   ,SDSKBN_NAI = :SDSKBN_NAI ")                  '�o����Џ����敪��  ' 2008/10/15 T.Watabe edit
            strSQL.Append("   ,METFUKKI   = :METFUKKI  ")                   '���̑����L����
            strSQL.Append("   ,HOAN       = :HOAN  ")                       '���̑����L����
            strSQL.Append("   ,GASGIRE    = :GASGIRE  ")                    '���̑����L����
            strSQL.Append("   ,KIGKOSYO   = :KIGKOSYO  ")                   '���̑����L����
            strSQL.Append("   ,CSNTGEN    = :CSNTGEN  ")                    '���̑����L����
            strSQL.Append("   ,CSNTNGAS   = :CSNTNGAS  ")                   '���̑����L����
            strSQL.Append("   ,SDTBIK1    = :SDTBIK1  ")                    '���̑����L����
            strSQL.Append("   ,EDT_DATE   = TO_CHAR(SYSDATE,'YYYYMMDD')  ") '�X�V���t
            strSQL.Append("   ,EDT_TIME   = TO_CHAR(SYSDATE,'HH24MISS')  ") '�X�V����
            strSQL.Append("WHERE KANSCD   = :KANSCD ")                      '�č��R�[�h
            strSQL.Append("AND   SYONO    = :SYONO ")                       '�����ԍ�

            'SQL���Z�b�g
            cdb.pSQL = strSQL.ToString

            cdb.pSQLParamStr("KANSCD") = pstrKANSCD   '�敪
            cdb.pSQLParamStr("SYONO") = pstrSYONO     '�R�[�h

            cdb.pSQLParamStr("TSTANCD") = pstrTSTANCD               '��M�҃R�[�h
            ' 2014/10/30 H.Hosoda mod 2014���P�J�� No11 START
            'cdb.pSQLParamStr("TSTANNM") = strTSTANNM                '��M�Ҏ���
            cdb.pSQLParamStr("TSTANNM") = pstrTSTANNM                '��M�Ҏ���
            ' 2014/10/30 H.Hosoda mod 2014���P�J�� No11 END
            'cdb.pSQLParamStr("STD_CD") = pstrSTD_CD                '�o����ЃR�[�h
            'cdb.pSQLParamStr("STD") = strSTD                       '�o����Ж�
            cdb.pSQLParamStr("STD_KYOTEN_CD") = pstrSTD_KYOTEN_CD   '�o����Ћ��_�R�[�h '2008/02/08 T.Watabe add
            cdb.pSQLParamStr("STD_KYOTEN") = strSTD_KYOTEN          '�o����Ћ��_��     '2008/02/08 T.Watabe add
            cdb.pSQLParamStr("SYUTDTNM") = pstrSYUTDTNM             '�o���Ή���
            cdb.pSQLParamStr("SIJIYMD") = pstrSIJIYMD               '�Ή���M���i�x���M���j
            cdb.pSQLParamStr("SIJITIME") = pstrSIJITIME             '�Ή������i��M�����j
            cdb.pSQLParamStr("SDYMD") = pstrSDYMD                   '�o���� ' 2008/10/14 T.Watabe add
            cdb.pSQLParamStr("SDTIME") = pstrSDTIME                 '�o������ ' 2008/10/14 T.Watabe add
            cdb.pSQLParamStr("TYAKYMD") = pstrTYAKYMD               '������
            cdb.pSQLParamStr("TYAKTIME") = pstrTYAKTIME             '��������
            cdb.pSQLParamStr("SYOKANYMD") = pstrSYOKANYMD           '����������
            cdb.pSQLParamStr("SYOKANTIME") = pstrSYOKANTIME         '������������
            cdb.pSQLParamStr("AITCD") = pstrAITCD                   '�Ή�����
            cdb.pSQLParamStr("AITNM") = strAITNM                    '�Ή����薼
            cdb.pSQLParamStr("METHEIKAKU") = pstrMETHEIKAKU         '�s�ݎ��̑[�u�@���[�^�Ւf�ٕ~�m�F 1:�L
            cdb.pSQLParamStr("RUSUHARI") = pstrRUSUHARI             '�s�ݎ��̑[�u�@�����\���̓\�t�@ 1:�L
            cdb.pSQLParamStr("KIGCD") = pstrKIGCD                   '�����R�[�h	
            cdb.pSQLParamStr("KIGNM") = strKIGNM                    '��������	
            cdb.pSQLParamStr("SADCD") = pstrSADCD                   '�쓮�����R�[�h	
            cdb.pSQLParamStr("SADNM") = strSADNM                    '�쓮��������	
            cdb.pSQLParamStr("ASECD") = pstrASECD                   '���̓Z���T�[�쓮����
            cdb.pSQLParamStr("ASENM") = strASENM                    '���̓Z���T�[�쓮����
            cdb.pSQLParamStr("STACD") = pstrSTACD                   '���̑������R�[�h
            cdb.pSQLParamStr("STANM") = strSTANM                    '���̑���������
            cdb.pSQLParamStr("FKICD") = pstrFKICD                   '���A����R�[�h
            cdb.pSQLParamStr("FKINM") = strFKINM                    '���A���얼��
            cdb.pSQLParamStr("JAKENREN") = pstrJAKENREN             '�i�`�^���A�ւ̘A������
            cdb.pSQLParamStr("RENTIME") = pstrRENTIME               '�i�`�^���A�ւ̘A������
            cdb.pSQLParamStr("KIGTAIYO") = pstrKIGTAIYO             '�ȈՃK�X���̑ݗ^�@1�F�L
            cdb.pSQLParamStr("GASMUMU") = pstrGASMUMU               '�K�X�R��_���@0�F�L�@1�F��
            cdb.pSQLParamStr("ORGENIN") = pstrORGENIN               '�K�X�R��_���L�@�����@�K�X���@1:�L
            cdb.pSQLParamStr("HAIKAN") = pstrHAIKAN                 '�K�X�R��_���L�@�����@�z�ǁ@1:�L
            cdb.pSQLParamStr("GASGUMU") = pstrGASGUMU               '�K�X�؂�m�F�@0�F�L�@1�F��
            cdb.pSQLParamStr("HOSKOKAN") = pstrHOSKOKAN             '�S���z�[�X�����@0�F���{�@1�F�����{
            cdb.pSQLParamStr("METYOINA") = pstrMETYOINA             '���̑��_���@���[�^�@0�F�ǁ@1�F��
            cdb.pSQLParamStr("TYOUYOINA") = pstrTYOUYOINA           '���̑��_���@������@0�F�ǁ@1�F��
            cdb.pSQLParamStr("VALYOINA") = pstrVALYOINA             '���̑��_���@�e��E���ԃo���u�@0�F�ǁ@1�F��
            cdb.pSQLParamStr("KYUHAIUMU") = pstrKYUHAIUMU           '���̑��_���@�z�r�C���@0�F�L�@1�F��
            cdb.pSQLParamStr("COYOINA") = pstrCOYOINA               '���̑��_���@�b�n�Z�x�@0�F�ǁ@1�F��
            cdb.pSQLParamStr("SDTBIK2") = pstrSDTBIK2               '���L����
            cdb.pSQLParamStr("SNTTOKKI") = pstrSNTTOKKI             '���̑����L����
            cdb.pSQLParamStr("SDTBIK3") = pstrSDTBIK3               '�o�����ʓ��e/�� '2006/06/15 NEC UPDATE
            'cdb.pSQLParamStr("TMSKB") = pstrKBN                    '�����敪 ' 2008/10/15 T.Watabe edit
            cdb.pSQLParamStr("SDSKBN") = pstrKBN                    '�o����Џ����敪
            'cdb.pSQLParamStr("TMSKB_NAI") = strTMSKB_NAI           '�����敪�� '2006/06/23 NEC ADD ' 2008/10/15 T.Watabe edit
            cdb.pSQLParamStr("SDSKBN_NAI") = strTMSKB_NAI           '�o����Џ����敪��
            cdb.pSQLParamStr("METFUKKI") = pstrMETFUKKI             '
            cdb.pSQLParamStr("HOAN") = pstrHOAN                     '
            cdb.pSQLParamStr("GASGIRE") = pstrGASGIRE               '
            cdb.pSQLParamStr("KIGKOSYO") = pstrKIGKOSYO             '
            cdb.pSQLParamStr("CSNTGEN") = pstrCSNTGEN               '
            cdb.pSQLParamStr("CSNTNGAS") = pstrCSNTNGAS             '
            cdb.pSQLParamStr("SDTBIK1") = pstrSDTBIK1               '

            ' 2008/10/16 T.Watabe del
            'If pstrKBN = "2" Then
            '    If strTAIO_ST_DATE.Length > 0 And strTAIO_ST_TIME.Length > 0 Then
            '        '�����J�n�����ݒ肳��Ă���Ƃ��̂݌v�Z
            '        cdb.pSQLParamStr("TAIO_SYO_TIME") = CStr(fncDateDiff(strTAIO_ST_DATE, strTAIO_ST_TIME, pstrSYOKANYMD, pstrSYOKANTIME))
            '    Else
            '        cdb.pSQLParamStr("TAIO_SYO_TIME") = ""
            '    End If
            'End If

            'SQL�����s
            cdb.mExecNonQuery()
            '�R�~�b�g
            cdb.mCommit()
        Catch ex As Exception
            '�G���[���N������ �G���[���e���i�[
            strRes = ex.ToString

            '�r�����䏈���G���[
            If ErrorToString.Substring(0, 9) = "ORA-00054" Then
                Return "3"
            End If

            '���[���o�b�N
            cdb.mRollback()
            strRes = strRes & cdb.pErr
        Finally
            '�ڑ��N���[�Y
            cdb.mClose()
        End Try

        cdb = Nothing

        Return strRes

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

        Return strRes
    End Function
    '******************************************************************************
    '*�@�T�@�v�F�S���҃}�X�^���������A�R�[�h���疼�̂��擾����
    '******************************************************************************
    Private Function fncGET_TANNM(ByVal pstrCD As String, ByVal pstrTANCD As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        strRes = ""

        '�l���Ȃ��ꍇ�͋��Ԃ�
        If pstrCD.Length = 0 Then
            Return strRes
        End If

        '�c�a�I�[�v��
        cdb.mOpen()
        'SQL�쐬
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("TANNM AS NAME ")
        strSQL.Append("FROM M05_TANTO ")
        strSQL.Append("WHERE KBN = '2' ")
        strSQL.Append("  AND KURACD = 'ZZZZ' ")
        'strSQL.Append("  AND CODE = :CODE  ") 2010/04/02 T.Watabe edit
        strSQL.Append("  AND CODE LIKE :CODE || '%'  ")
        strSQL.Append("  AND TANCD = :TANCD ")
        strSQL.Append("ORDER BY TANCD ")

        'SQL���Z�b�g
        cdb.pSQL = strSQL.ToString
        '�p�����[�^�Z�b�g
        cdb.pSQLParamStr("CODE") = pstrCD         '//�R�[�h
        cdb.pSQLParamStr("TANCD") = pstrTANCD         '//�R�[�h
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

        Return strRes
    End Function
    '******************************************************************************
    '*�@�T�@�v�F�S���҃}�X�^���������A�R�[�h���疼�̂��擾����
    '******************************************************************************
    Private Function fncGET_KYOTEN(ByVal pstrSHUTU_CD As String, ByVal pstrKYOTEN_CD As String) As String
        Dim ds As New DataSet
        Dim cdb As New CDB
        Dim strRes As String
        Dim strSQL As StringBuilder
        strRes = ""

        '�l���Ȃ��ꍇ�͋��Ԃ�
        If pstrSHUTU_CD.Length = 0 Then
            Return strRes
        End If
        If pstrKYOTEN_CD.Length = 0 Then
            Return strRes
        End If

        '�c�a�I�[�v��
        cdb.mOpen()
        'SQL�쐬
        strSQL = New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("    KYOTEN_NAME AS NAME ")
        strSQL.Append("FROM ")
        strSQL.Append("    SHUTUDOMAS ")
        strSQL.Append("WHERE ")
        strSQL.Append("        SHUTU_CD  = :SHUTU_CD ")
        strSQL.Append("    AND KYOTEN_CD = :KYOTEN_CD ")
        strSQL.Append("    AND KUBUN = '1' ")

        'SQL���Z�b�g
        cdb.pSQL = strSQL.ToString
        '�p�����[�^�Z�b�g
        cdb.pSQLParamStr("SHUTU_CD") = pstrSHUTU_CD         '// �o����ЃR�[�h
        cdb.pSQLParamStr("KYOTEN_CD") = pstrKYOTEN_CD       '// ���_�R�[�h
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

        If strSTDate.Length = 0 Or strSTTime.Length = 0 Then
            lngRec = 0
        End If

        strSTDate = strSTDate.Substring(0, 4) & "/" & strSTDate.Substring(4, 2) & "/" & strSTDate.Substring(6, 2)
        strSTTime = strSTTime.Substring(0, 2) & ":" & strSTTime.Substring(2, 2) & ":" & strSTTime.Substring(4, 2)
        'strEDDate = strEDDate.Substring(0, 4) & "/" & strEDDate.Substring(4, 2) & "/" & strEDDate.Substring(6, 2)
        'strEDTime = strEDTime.Substring(0, 2) & ":" & strEDTime.Substring(2, 2) & ":" & strEDTime.Substring(4, 2)

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

End Class
