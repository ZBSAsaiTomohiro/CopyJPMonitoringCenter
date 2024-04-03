'***********************************************
'�Ή������ꗗ�@�f�[�^����
'***********************************************
' �ύX����
' 2021/10/01 Saka 2021�N�x�Ď����P�@�Ď��Ή�����g�̊g��

Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common.log

Imports System.Text

Partial Class KETAIJSG00
    Inherits System.Web.UI.Page

    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

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
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                                    Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        Try
            '--------------------------------------------
            Dim KETAIJRG00C As KETAIJRG00
            KETAIJRG00C = CType(Context.Handler, KETAIJRG00)

            '--------------------------------------------
            Dim SQLC As New KETAIJAG00CSQL.CSQL
            Dim SqlParamC As New CSQLParam
            Dim strSQL As String
            Dim dbData As DataSet

            Dim intTargetRownum As Integer
            Dim intDataCount As Integer = fncDataCount(KETAIJRG00C.pRIREKI_CLI, KETAIJRG00C.pRIREKI_JASS, KETAIJRG00C.pRIREKI_JUYOKA)

            '--------------------------------------------
            SqlParamC.fncSetParam("KURACD", True, KETAIJRG00C.pRIREKI_CLI)
            SqlParamC.fncSetParam("ACBCD", True, KETAIJRG00C.pRIREKI_JASS)
            SqlParamC.fncSetParam("USER_CD", True, KETAIJRG00C.pRIREKI_JUYOKA)

            '--------------------------------------------
            Select Case KETAIJRG00C.pExecFlag
                Case "DATAFIRST"
                    ''-------------------------------
                    ''�擪�{�^���̃f�[�^�J�ڂ��s���܂�
                    ''-------------------------------
                    '����ROWNUM��1�ɂ��܂�
                    intTargetRownum = 1

                    '�f�[�^���������܂�
                    strSQL = fncSelectSql(intTargetRownum)
                    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                Case "DATAPRE"
                    ''-------------------------------
                    ''�O�{�^���̃f�[�^�J�ڂ��s���܂�
                    ''-------------------------------
                    '����ROWNUM��-2�ɂ��܂�(�}�C�i�X�ɂȂ�ꍇ��1�ɂ��܂�)
                    If CInt(KETAIJRG00C.pRownum) - 3 <= 0 Then
                        intTargetRownum = 1
                    Else
                        intTargetRownum = CInt(KETAIJRG00C.pRownum) - 2
                    End If

                    '�f�[�^���������܂�
                    strSQL = fncSelectSql(intTargetRownum)
                    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                Case "DATANEX"
                    ''-------------------------------
                    ''���{�^���̃f�[�^�J�ڂ��s���܂�
                    ''-------------------------------
                    '����ROWNUM��+2�ɂ��܂��B�f�[�^�����𒴂���ꍇ�́A����-1�ɂ��܂�
                    If CInt(KETAIJRG00C.pRownum) + 2 > intDataCount Then
                        If intDataCount < 3 Then
                            intTargetRownum = 1
                        Else
                            If ((intDataCount \ 2) * 2) + 1 > CInt(KETAIJRG00C.pRownum) Then
                                intTargetRownum = CInt(KETAIJRG00C.pRownum)
                            Else
                                intTargetRownum = ((intTargetRownum \ 2) * 2) + 1
                            End If
                        End If
                    Else
                        intTargetRownum = CInt(KETAIJRG00C.pRownum) + 2
                    End If

                    '�f�[�^���������܂�
                    strSQL = fncSelectSql(intTargetRownum)
                    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

                Case "DATAEND"
                    ''-------------------------------
                    ''�Ō�{�^���̃f�[�^�J�ڂ��s���܂�
                    ''-------------------------------
                    '����ROWNUM��[����������(�Ή������܂�)-2]�ɂ��܂�
                    If intDataCount < 3 Then
                        intTargetRownum = 1
                    Else
                        If ((intDataCount \ 2) * 2) + 1 > intDataCount Then
                            intTargetRownum = ((intDataCount \ 2) * 2) + 1 - 2
                        Else
                            intTargetRownum = ((intDataCount \ 2) * 2) + 1
                        End If
                    End If

                    '�f�[�^���������܂�
                    strSQL = fncSelectSql(intTargetRownum)
                    dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)
            End Select

            '--------------------------------------------
            '�f�[�^���o�͂��܂�
            Call fncDataSet(dbData)


            '--------------------------------------------
            '�o�͂����f�[�^��(�y�[�W�J�ڂɎg�p)��ێ�
            strMsg.Append("parent.Form1.hdnRownum.value = '" & intTargetRownum & "';")     '�o�͂��Ă���f�[�^�̃J�E���g


            '--------------------------------------------
            '���b�N�����{�^���̏�Ԃ�ύX����
            strMsg.Append("parent.Form1.btnExit.disabled = true;")

            If intTargetRownum = 1 Then
                '�ŏ��̃y�[�W�̎�
                If intDataCount <= 2 Then
                    '���������y�[�W�܂ōs���Ȃ���
                    strMsg.Append("parent.Form1.btnFirst.disabled = true;")
                    strMsg.Append("parent.Form1.btnPre.disabled = true;")
                    strMsg.Append("parent.Form1.btnEnd.disabled = true;")
                    strMsg.Append("parent.Form1.btnNex.disabled = true;")
                Else
                    '��L�ȊO�A���͎��y�[�W����̖߂�
                    strMsg.Append("parent.fncFo(parent.Form1.btnFirst, 5);")
                    strMsg.Append("parent.fncFo(parent.Form1.btnPre, 5);")
                    strMsg.Append("parent.Form1.btnFirst.disabled = true;")
                    strMsg.Append("parent.Form1.btnPre.disabled = true;")
                    strMsg.Append("parent.Form1.btnEnd.disabled = false;")
                    strMsg.Append("parent.Form1.btnNex.disabled = false;")
                End If

            ElseIf intTargetRownum = (((intDataCount - 1) \ 2) * 2) + 1 Then
                '�Ō�̃y�[�W�̎�
                strMsg.Append("parent.Form1.btnFirst.disabled = false;")
                strMsg.Append("parent.Form1.btnPre.disabled = false;")
                strMsg.Append("parent.fncFo(parent.Form1.btnEnd, 5);")
                strMsg.Append("parent.fncFo(parent.Form1.btnNex, 5);")
                strMsg.Append("parent.Form1.btnEnd.disabled = true;")
                strMsg.Append("parent.Form1.btnNex.disabled = true;")

            Else
                strMsg.Append("parent.Form1.btnFirst.disabled = false;")
                strMsg.Append("parent.Form1.btnPre.disabled = false;")
                strMsg.Append("parent.Form1.btnEnd.disabled = false;")
                strMsg.Append("parent.Form1.btnNex.disabled = false;")

            End If

            '�t���[�����[�N����ɂ���
            strMsg.Append("location.replace('about:blank');")

        Catch ex As Exception
            Dim ErrMsgC As New CErrMsg
            strMsg.Append("alert('�V�X�e���G���[�F" & ErrMsgC.mGetArtMsg(ex.ToString) & "');")

        End Try
    End Sub

    '***************************************************
    '*�Ώۂ̂��q�l�f�[�^�����擾����
    '***************************************************
    Private Function fncDataCount(ByVal strKURACD As String, ByVal strACBCD As String, ByVal strUSER_CD As String) As Integer
        Dim SQLC As New KETAIJAG00CSQL.CSQL
        Dim SqlParamC As New CSQLParam
        Dim strSQL As New StringBuilder("")
        Dim dbData As DataSet

        '2016/05/09 H.Mori mod �Ď����P2015 ��3 PG�߂� START
        '2015/12/04 H.Mori mod 2015���P�J�� No3 START  
        'strSQL.Append("SELECT COUNT(*) AS CNT ")
        'strSQL.Append("FROM D20_TAIOU ")
        'strSQL.Append("WHERE KURACD  = :KURACD ")
        'strSQL.Append("  AND ACBCD   = :ACBCD ")
        'strSQL.Append("  AND USER_CD = :USER_CD ")

        'strSQL.Append("WITH ") 
        'strSQL.Append("TEL AS ( ")
        'strSQL.Append("SELECT C.KOK_TELNO,C.EXEC_KBN,C.SEQNO ")
        'strSQL.Append("FROM   S04_TELLOGDB C ")
        'strSQL.Append("       ,(SELECT MAX(B.EXEC_YMD || LPAD(B.EXEC_TIME, 6, '0')) AS YMD, B.SEQNO ")
        'strSQL.Append("       FROM D20_TAIOU A,S04_TELLOGDB B ")
        'strSQL.Append("       WHERE A.KURACD = :KURACD ")
        'strSQL.Append("       AND A.ACBCD = :ACBCD ")
        'strSQL.Append("       AND A.USER_CD = :USER_CD ")
        'strSQL.Append("       AND A.SYONO = B.SEQNO ")
        'strSQL.Append("       AND 1 = B.EXEC_KBN ")
        'strSQL.Append("       GROUP BY B.SEQNO) TEL ")
        'strSQL.Append("WHERE  C.SEQNO = TEL.SEQNO ")
        'strSQL.Append("AND    (C.EXEC_YMD || LPAD(C.EXEC_TIME, 6, '0')) = TEL.YMD) ")
        'strSQL.Append("SELECT COUNT(*) AS CNT ")
        'strSQL.Append("FROM   D20_TAIOU TAI ")
        'strSQL.Append("       ,TEL ")
        'strSQL.Append("WHERE    TAI.KURACD = :KURACD ")
        'strSQL.Append("AND    TAI.ACBCD = :ACBCD ")
        'strSQL.Append("AND    TAI.USER_CD = :USER_CD ")
        'strSQL.Append("AND    TAI.SYONO = TEL.SEQNO(+) ")
        '2015/12/04 H.Mori mod 2015���P�J�� No3 END
        strSQL.Append("SELECT COUNT(*) AS CNT ")
        strSQL.Append("FROM D20_TAIOU ")
        strSQL.Append("WHERE KURACD  = :KURACD ")
        strSQL.Append("  AND ACBCD   = :ACBCD ")
        strSQL.Append("  AND USER_CD = :USER_CD ")
        '2016/05/09 H.Mori mod �Ď����P2015 ��3 PG�߂� END

        SqlParamC.fncSetParam("KURACD", True, strKURACD)
        SqlParamC.fncSetParam("ACBCD", True, strACBCD)
        SqlParamC.fncSetParam("USER_CD", True, strUSER_CD)

        dbData = SQLC.mGetData(strSQL.ToString, SqlParamC.pParamDataSet, True)

        Return Convert.ToInt32(dbData.Tables(0).Rows(0).Item("CNT"))
    End Function

    '***************************************************
    '*
    '***************************************************
    Private Function fncSelectSql(ByVal pintRownum As Integer) As String
        Dim strSQL As New StringBuilder("")
        strSQL.Append("SELECT ")
        strSQL.Append("* ")
        strSQL.Append("FROM ")
        strSQL.Append("( ")
        strSQL.Append("SELECT ")
        strSQL.Append("TO_CHAR(ROWNUM) AS ROWNUMIND, ")
        strSQL.Append("A.* ")
        strSQL.Append("FROM ")
        strSQL.Append("( ")
        '2016/05/09 H.Mori mod �Ď����P2015 ��3�C�� START
        '2015/12/04 H.Mori mod 2015���P�J�� No3 START
        'strSQL.Append("SELECT ")
        'strSQL.Append("HATYMD, ")
        'strSQL.Append("HATTIME, ")
        'strSQL.Append("KEIHOSU, ")
        'strSQL.Append("RYURYO, ")
        'strSQL.Append("KMCD1, ")
        'strSQL.Append("KMNM1, ")
        'strSQL.Append("KMCD2, ")
        'strSQL.Append("KMNM2, ")
        'strSQL.Append("KMCD3, ")
        'strSQL.Append("KMNM3, ")
        'strSQL.Append("KMCD4, ")
        'strSQL.Append("KMNM4, ")
        'strSQL.Append("KMCD5, ")
        'strSQL.Append("KMNM5, ")
        'strSQL.Append("KMCD6, ")
        'strSQL.Append("KMNM6, ")
        ' '''''strSQL.Append("ACBCD, ")
        ' '''''strSQL.Append("USER_CD, ")
        ' '''''strSQL.Append("ACBCD - USER_CD AS JUYOKACD, ")
        'strSQL.Append("JUSYONM, ")
        'strSQL.Append("HATKBN_NAI, ")
        'strSQL.Append("TAIOKBN_NAI, ")
        'strSQL.Append("TMSKB_NAI, ")
        'strSQL.Append("TKTANCD_NM, ")
        'strSQL.Append("TAITNM, ")
        'strSQL.Append("SYOYMD, ")
        'strSQL.Append("SYOTIME, ")
        'strSQL.Append("TELRNM, ")
        'strSQL.Append("FUK_MEMO, ")
        'strSQL.Append("TEL_MEMO1, ")
        'strSQL.Append("TEL_MEMO2, ")
        'strSQL.Append("MITOKBN, ")
        'strSQL.Append("TKIGNM, ")
        'strSQL.Append("TSADNM, ")
        'strSQL.Append("FAX_REN, ") '2014/12/19 T.Ono add 2014���P�J�� No3
        'strSQL.Append("TSTANNM, ")
        'strSQL.Append("SYUTDTNM, ")
        'strSQL.Append("AITNM, ")
        'strSQL.Append("KIGNM, ")
        'strSQL.Append("SADNM, ")
        'strSQL.Append("STANM, ")
        'strSQL.Append("ASENM, ")
        'strSQL.Append("FKINM, ")
        'strSQL.Append("SDTBIK2 ")
        'strSQL.Append(",SNTTOKKI ") '2013/11/14 T.Ono add �Ď����P2013��1
        'strSQL.Append(",SDTBIK3 ") '2013/11/14 T.Ono add �Ď����P2013��1
        'strSQL.Append("FROM D20_TAIOU ")
        'strSQL.Append("WHERE KURACD  = :KURACD ")
        'strSQL.Append("  AND ACBCD   = :ACBCD ")
        'strSQL.Append("  AND USER_CD = :USER_CD ")
        'strSQL.Append("ORDER BY HATYMD DESC, HATTIME DESC")
        'strSQL.Append("WITH ")
        'strSQL.Append("TEL AS ( ")
        'strSQL.Append("SELECT C.KOK_TELNO,C.EXEC_KBN,C.SEQNO ")
        'strSQL.Append("FROM   S04_TELLOGDB C ")
        'strSQL.Append("       ,(SELECT MAX(B.EXEC_YMD || LPAD(B.EXEC_TIME, 6, '0')) AS YMD, B.SEQNO ")
        'strSQL.Append("         FROM D20_TAIOU A,S04_TELLOGDB B ")
        'strSQL.Append("         WHERE A.KURACD = :KURACD ")
        'strSQL.Append("         AND A.ACBCD = :ACBCD ")
        'strSQL.Append("         AND A.USER_CD = :USER_CD ")
        'strSQL.Append("         AND A.SYONO = B.SEQNO ")
        'strSQL.Append("         AND B.EXEC_KBN = '1' ")
        'strSQL.Append("         GROUP BY B.SEQNO) TEL ")
        'strSQL.Append("WHERE  C.SEQNO = TEL.SEQNO ")
        'strSQL.Append("AND    (C.EXEC_YMD || LPAD(C.EXEC_TIME, 6, '0')) = TEL.YMD) ")
        'strSQL.Append("SELECT ")
        'strSQL.Append("TAI.HATYMD, ")
        'strSQL.Append("TAI.HATTIME, ")
        'strSQL.Append("TAI.KENSIN, ")
        'strSQL.Append("TAI.RYURYO, ")
        'strSQL.Append("TAI.KMCD1, ")
        'strSQL.Append("TAI.KMNM1, ")
        'strSQL.Append("TAI.KMCD2, ")
        'strSQL.Append("TAI.KMNM2, ")
        'strSQL.Append("TAI.KMCD3, ")
        'strSQL.Append("TAI.KMNM3, ")
        'strSQL.Append("TAI.KMCD4, ")
        'strSQL.Append("TAI.KMNM4, ")
        'strSQL.Append("TAI.KMCD5, ")
        'strSQL.Append("TAI.KMNM5, ")
        'strSQL.Append("TAI.KMCD6, ")
        'strSQL.Append("TAI.KMNM6, ")
        'strSQL.Append("TAI.JUSYONM, ")
        'strSQL.Append("TAI.HATKBN_NAI, ")
        'strSQL.Append("TAI.TAIOKBN_NAI, ")
        'strSQL.Append("TAI.TMSKB_NAI, ")
        'strSQL.Append("TAI.TKTANCD_NM, ")
        'strSQL.Append("TAI.TAITNM, ")
        'strSQL.Append("TAI.SYOYMD, ")
        'strSQL.Append("TAI.SYOTIME, ")
        'strSQL.Append("TAI.TELRNM, ")
        'strSQL.Append("TAI.FUK_MEMO, ")
        'strSQL.Append("TAI.TEL_MEMO1, ")
        'strSQL.Append("TAI.TEL_MEMO2, ")
        'strSQL.Append("TAI.MITOKBN, ")
        'strSQL.Append("TAI.TKIGNM, ")
        'strSQL.Append("TAI.TSADNM, ")
        'strSQL.Append("TAI.FAX_REN, ")
        'strSQL.Append("TAI.TSTANNM, ")
        'strSQL.Append("TAI.SYUTDTNM, ")
        'strSQL.Append("TAI.AITNM, ")
        'strSQL.Append("TAI.KIGNM, ")
        'strSQL.Append("TAI.SADNM, ")
        'strSQL.Append("TAI.STANM, ")
        'strSQL.Append("TAI.ASENM, ")
        'strSQL.Append("TAI.FKINM, ")
        'strSQL.Append("TAI.SDTBIK2 ")
        'strSQL.Append(",TAI.SNTTOKKI ")
        'strSQL.Append(",TAI.SDTBIK3 ")
        'strSQL.Append(",TAI.TFKINM ")
        'strSQL.Append(",TEL.KOK_TELNO ")
        'strSQL.Append(",TEL.EXEC_KBN ")
        'strSQL.Append("FROM   D20_TAIOU TAI ")
        'strSQL.Append("       ,TEL ")
        'strSQL.Append("WHERE    TAI.KURACD = :KURACD ")
        'strSQL.Append("AND    TAI.ACBCD = :ACBCD ")
        'strSQL.Append("AND    TAI.USER_CD = :USER_CD ")
        'strSQL.Append("AND    TAI.SYONO = TEL.SEQNO(+) ")
        'strSQL.Append("ORDER BY TAI.HATYMD DESC, TAI.HATTIME DESC")
        '2015/12/04 H.Mori mod 2015���P�J�� No3 END
        strSQL.Append("WITH ")
        strSQL.Append("TEL AS ( ")
        strSQL.Append("SELECT D.SEQNO, ")
        strSQL.Append("       D.KOK_TELNO ")
        strSQL.Append("FROM ( ")
        strSQL.Append("  SELECT ROWNUM AS NUM, ")
        strSQL.Append("         C.SEQNO, ")
        strSQL.Append("         C.KOK_TELNO ")
        strSQL.Append("  FROM ( ")
        strSQL.Append("    SELECT B.SEQNO, ")
        strSQL.Append("           B.KOK_TELNO ")
        strSQL.Append("    FROM   D20_TAIOU    A, ")
        strSQL.Append("           S04_TELLOGDB B ")
        strSQL.Append("    WHERE  A.KURACD   = :KURACD ")
        strSQL.Append("    AND    A.ACBCD    = :ACBCD ")
        strSQL.Append("    AND    A.USER_CD  = :USER_CD ")
        strSQL.Append("    AND    A.SYONO    = B.SEQNO ")
        strSQL.Append("    AND    B.EXEC_KBN = '1' ")
        strSQL.Append("    AND    B.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(B.EXEC_YMD, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        strSQL.Append("                      AND     TO_CHAR(ADD_MONTHS(TO_DATE(B.EXEC_YMD, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        strSQL.Append("    ORDER BY B.SEQNO, B.ADD_DATE, B.TIME, LPAD(B.EDANO,2,'0') ")
        strSQL.Append("    ) C ")
        strSQL.Append("  ) D ")
        strSQL.Append("WHERE NOT EXISTS ( ")
        strSQL.Append("  SELECT 'X' ")
        strSQL.Append("  FROM ( ")
        strSQL.Append("    SELECT ROWNUM AS NUM, ")
        strSQL.Append("           G.SEQNO ")
        strSQL.Append("    FROM ( ")
        strSQL.Append("      SELECT F.SEQNO ")
        strSQL.Append("    FROM   D20_TAIOU    E, ")
        strSQL.Append("           S04_TELLOGDB F ")
        strSQL.Append("    WHERE  E.KURACD   = :KURACD ")
        strSQL.Append("    AND    E.ACBCD    = :ACBCD ")
        strSQL.Append("    AND    E.USER_CD  = :USER_CD ")
        strSQL.Append("    AND    E.SYONO    = F.SEQNO ")
        strSQL.Append("    AND    F.EXEC_KBN = '1' ")
        strSQL.Append("    AND    F.EXEC_YMD BETWEEN TO_CHAR(ADD_MONTHS(TO_DATE(F.EXEC_YMD, 'YYYYMMDD'), -1), 'YYYYMMDD') ")
        strSQL.Append("                      AND     TO_CHAR(ADD_MONTHS(TO_DATE(F.EXEC_YMD, 'YYYYMMDD'), +1), 'YYYYMMDD') ")
        strSQL.Append("    ORDER BY F.SEQNO, F.ADD_DATE, F.TIME, LPAD(F.EDANO,2,'0') ")
        strSQL.Append("      ) G ")
        strSQL.Append("    ) H ")
        strSQL.Append("  WHERE D.SEQNO = H.SEQNO ")
        strSQL.Append("  AND   D.NUM < H.NUM ")
        strSQL.Append("  ) ")
        strSQL.Append(") ")
        strSQL.Append("SELECT ")
        strSQL.Append("     TAI.HATYMD, ")
        strSQL.Append("     TAI.HATTIME, ")
        strSQL.Append("     TAI.KENSIN, ")
        strSQL.Append("     TAI.RYURYO, ")
        strSQL.Append("     TAI.KMCD1, ")
        strSQL.Append("     TAI.KMNM1, ")
        strSQL.Append("     TAI.KMCD2, ")
        strSQL.Append("     TAI.KMNM2, ")
        strSQL.Append("     TAI.KMCD3, ")
        strSQL.Append("     TAI.KMNM3, ")
        strSQL.Append("     TAI.KMCD4, ")
        strSQL.Append("     TAI.KMNM4, ")
        strSQL.Append("     TAI.KMCD5, ")
        strSQL.Append("     TAI.KMNM5, ")
        strSQL.Append("     TAI.KMCD6, ")
        strSQL.Append("     TAI.KMNM6, ")
        strSQL.Append("     TAI.JUSYONM, ")
        strSQL.Append("     TAI.HATKBN_NAI, ")
        strSQL.Append("     TAI.TAIOKBN_NAI, ")
        strSQL.Append("     TAI.TMSKB_NAI, ")
        strSQL.Append("     TAI.TKTANCD_NM, ")
        strSQL.Append("     TAI.TAITNM, ")
        strSQL.Append("     TAI.SYOYMD, ")
        strSQL.Append("     TAI.SYOTIME, ")
        strSQL.Append("     TAI.TELRNM, ")
        strSQL.Append("     TAI.FUK_MEMO, ")
        strSQL.Append("     TAI.TEL_MEMO1, ")
        strSQL.Append("     TAI.TEL_MEMO2, ")
'2021/10/01 2021�N�x�Ď����P sakaADD�D start
        strSQL.Append("     TAI.TEL_MEMO4, ")
        strSQL.Append("     TAI.TEL_MEMO5, ")
        strSQL.Append("     TAI.TEL_MEMO6, ")
'2021/10/01 2021�N�x�Ď����P sakaADD�D end
        strSQL.Append("     TAI.MITOKBN, ")
        strSQL.Append("     TAI.TKIGNM, ")
        strSQL.Append("     TAI.TSADNM, ")
        strSQL.Append("     TAI.FAX_REN, ")
        strSQL.Append("     TAI.TSTANNM, ")
        strSQL.Append("     TAI.SYUTDTNM, ")
        strSQL.Append("     TAI.AITNM, ")
        strSQL.Append("     TAI.KIGNM, ")
        strSQL.Append("     TAI.SADNM, ")
        strSQL.Append("     TAI.STANM, ")
        strSQL.Append("     TAI.ASENM, ")
        strSQL.Append("     TAI.FKINM, ")
        strSQL.Append("     TAI.SDTBIK2 ")
        strSQL.Append("     ,TAI.SNTTOKKI ")
        strSQL.Append("     ,TAI.SDTBIK3 ")
        strSQL.Append("     ,TAI.TFKINM ")
        strSQL.Append("     ,TEL.KOK_TELNO ")
        strSQL.Append("FROM   D20_TAIOU TAI ")
        strSQL.Append("       ,TEL ")
        strSQL.Append("WHERE  TAI.KURACD = :KURACD ")
        strSQL.Append("AND    TAI.ACBCD = :ACBCD ")
        strSQL.Append("AND    TAI.USER_CD = :USER_CD ")
        strSQL.Append("AND    TAI.SYONO = TEL.SEQNO(+) ")
        strSQL.Append("ORDER BY TAI.HATYMD DESC, TAI.HATTIME DESC")
        '2016/05/09 H.Mori mod �Ď����P2015 ��3�C�� END
        strSQL.Append(") A ")
        strSQL.Append(") T ")
        strSQL.Append("WHERE ROWNUMIND BETWEEN " & pintRownum & " AND " & pintRownum + 1 & " ")

        Return strSQL.ToString

    End Function

    '***************************************************
    '*
    '***************************************************
    Private Sub fncDataSet(ByRef pdbData As DataSet)
        Dim i As Integer
        Dim strTemp As String
        Dim intTemp As Integer

        Dim DateFncC As New CDateFnc
        'Dim NaNFncC As New CNaNFnc
        Dim TimeFncC As New CTimeFnc

        Dim intRow As Integer

        If Convert.ToString(pdbData.Tables(0).Rows(0).Item(0)) = "XYZ" Then
            For intRow = 0 To 1
                '������--------------------
                strMsg.Append("parent.Form1.txtHATYMD" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtRYURYO" & intRow + 1 & ".value = '';")
                '2015/11/19 H.Mori mod 2015���P�J�� No3 START
                'strMsg.Append("parent.Form1.txtKEIHOSU" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtKENSIN" & intRow + 1 & ".value = '';")
                '2015/11/19 H.Mori mod 2015���P�J�� No3 END
                strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_1.value = '';")
                strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_2.value = '';")
                strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_3.value = '';")
                strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_4.value = '';")
                strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_5.value = '';")
                strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_6.value = '';")
                strMsg.Append("parent.Form1.txtHATKBN" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtTAIOKBN" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtTMSKB_NAI" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtTKTANCD_NM" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtTAITNM" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtSYOYMD" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtTELRNM" & intRow + 1 & ".value = '';")
                ' 2013/08/24 T.Ono �Ď����P2013��1 Start
                'strMsg.Append("parent.Form1.txtFUK_MEMO" & intRow + 1 & ".value = '';")
                'strMsg.Append("parent.Form1.txtTEL_MEMO1_" & intRow + 1 & ".value = '';")
                'strMsg.Append("parent.Form1.txtTEL_MEMO1_" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtTEL_MEMO_" & intRow + 1 & ".value = '';")
                ' 2013/08/24 T.Ono �Ď����P2013��1 End
                strMsg.Append("parent.Form1.txtTKIGNM" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtTSADNM" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtTSTANNM" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtAITNM" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtKIGNM" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtSADNM" & intRow + 1 & ".value = '';")
                'strMsg.Append("parent.Form1.txtSTANM" & intRow + 1 & ".value = '';") 2014/12/19 T.Ono del 2014���P�J�� No3
                'strMsg.Append("parent.Form1.txtASENM" & intRow + 1 & ".value = '';") 2014/12/19 T.Ono del 2014���P�J�� No3
                strMsg.Append("parent.Form1.txtFKINM" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtSDTBIK2_" & intRow + 1 & ".value = '';")
                strMsg.Append("parent.Form1.txtFAX_REN_" & intRow + 1 & ".value = '';") '������ 2014/12/19 T.Ono add 2014���P�J�� No3
                strMsg.Append("parent.Form1.txtTFKINM" & intRow + 1 & ".value = '';") '2015/11/20 H.Mori add 2015���P�J�� No3
                strMsg.Append("parent.Form1.txtKOK_TELNO" & intRow + 1 & ".value = '';") '2015/11/20 H.Mori add 2015���P�J�� No3
            Next
        Else
            For intRow = 0 To 1
                If intRow > pdbData.Tables(0).Rows.Count - 1 Then
                    '������--------------------
                    strMsg.Append("parent.Form1.txtHATYMD" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtRYURYO" & intRow + 1 & ".value = '';")
                    '2015/11/19 H.Mori mod 2015���P�J�� No3 START
                    'strMsg.Append("parent.Form1.txtKEIHOSU" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtKENSIN" & intRow + 1 & ".value = '';")
                    '2015/11/19 H.Mori mod 2015���P�J�� No3 END
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_1.value = '';")
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_2.value = '';")
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_3.value = '';")
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_4.value = '';")
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_5.value = '';")
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_6.value = '';")
                    strMsg.Append("parent.Form1.txtHATKBN" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtTAIOKBN" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtTMSKB_NAI" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtTKTANCD_NM" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtTAITNM" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtSYOYMD" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtTELRNM" & intRow + 1 & ".value = '';")
                    ' 2013/08/24 T.Ono �Ď����P2013��1 Start
                    'strMsg.Append("parent.Form1.txtFUK_MEMO" & intRow + 1 & ".value = '';")
                    'strMsg.Append("parent.Form1.txtTEL_MEMO1_" & intRow + 1 & ".value = '';")
                    'strMsg.Append("parent.Form1.txtTEL_MEMO1_" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtTEL_MEMO_" & intRow + 1 & ".value = '';")
                    ' 2013/08/24 T.Ono �Ď����P2013��1 End
                    strMsg.Append("parent.Form1.txtTKIGNM" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtTSADNM" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtTSTANNM" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtAITNM" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtKIGNM" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtSADNM" & intRow + 1 & ".value = '';")
                    'strMsg.Append("parent.Form1.txtSTANM" & intRow + 1 & ".value = '';") 2014/12/19 T.Ono del 2014���P�J�� No3
                    'strMsg.Append("parent.Form1.txtASENM" & intRow + 1 & ".value = '';") 2014/12/19 T.Ono del 2014���P�J�� No3
                    strMsg.Append("parent.Form1.txtFKINM" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtSDTBIK2_" & intRow + 1 & ".value = '';")
                    strMsg.Append("parent.Form1.txtFAX_REN_" & intRow + 1 & ".value = '';") '������ 2014/12/19 T.Ono add 2014���P�J�� No3
                    strMsg.Append("parent.Form1.txtTFKINM" & intRow + 1 & ".value = '';") '2015/11/20 H.Mori add 2015���P�J�� No3
                    strMsg.Append("parent.Form1.txtKOK_TELNO" & intRow + 1 & ".value = '';") '2015/11/20 H.Mori add 2015���P�J�� No3
                Else
                    '�����N����
                    strMsg.Append("parent.Form1.txtHATYMD" & intRow + 1 & ".value = '" & _
                            DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("HATYMD"))) & _
                            " " & _
                            TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("HATTIME")), 0) & _
                            "';")
                    '�����敪
                    strMsg.Append("parent.Form1.txtTMSKB_NAI" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TMSKB_NAI")) & "';")
                    '�����敪
                    strMsg.Append("parent.Form1.txtHATKBN" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("HATKBN_NAI")) & "';")
                    '�Ή��敪
                    strMsg.Append("parent.Form1.txtTAIOKBN" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TAIOKBN_NAI")) & "';")
                    '2015/11/19 H.Mori mod 2015���P�J�� No3 START
                    '���ې�
                    'strMsg.Append("parent.Form1.txtKEIHOSU" & intRow + 1 & ".value = '" & _
                    '        Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KEIHOSU")) & "';")
                    '���[�^�l
                    strMsg.Append("parent.Form1.txtKENSIN" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KENSIN")) & "';")
                    '2015/11/19 H.Mori mod 2015���P�J�� No3 END
                    '���p�敪
                    strMsg.Append("parent.Form1.txtRYURYO" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("RYURYO")) & "';")
                    '���b�Z�[�W�P
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_1.value = '" & _
                            fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD1")), Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM1")), "�F") & "';")
                    '���b�Z�[�W�Q
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_2.value = '" & _
                            fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD2")), Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM2")), "�F") & "';")
                    '���b�Z�[�W�R
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_3.value = '" & _
                            fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD3")), Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM3")), "�F") & "';")
                    '���b�Z�[�W�S
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_4.value = '" & _
                            fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD4")), Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM4")), "�F") & "';")
                    '���b�Z�[�W�T
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_5.value = '" & _
                            fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD5")), Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM5")), "�F") & "';")
                    '���b�Z�[�W�U
                    strMsg.Append("parent.Form1.txtMSG" & intRow + 1 & "_6.value = '" & _
                            fncEditCutMsg(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMCD6")), Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KMNM6")), "�F") & "';")
                    '�d�b�S����
                    strMsg.Append("parent.Form1.txtTKTANCD_NM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TKTANCD_NM")) & "';")
                    '�A������
                    strMsg.Append("parent.Form1.txtTAITNM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TAITNM")) & "';")
                    '����
                    strMsg.Append("parent.Form1.txtTKIGNM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TKIGNM")) & "';")
                    '�쓮����
                    strMsg.Append("parent.Form1.txtTSADNM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TSADNM")) & "';")
                    '�d�b���e
                    strMsg.Append("parent.Form1.txtTELRNM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TELRNM")) & "';")
                    ' 2013/08/24 T.Ono �Ď����P2013��1 Start
                    '���A���상��
                    'strMsg.Append("parent.Form1.txtFUK_MEMO" & intRow + 1 & ".value = '" & _
                    '        Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("FUK_MEMO")) & "';")
                    ''�d�b�Ή������P
                    'strMsg.Append("parent.Form1.txtTEL_MEMO1_" & intRow + 1 & ".value = '" & _
                    '        Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO1")) & "';")
                    ''�d�b�Ή������Q
                    'strMsg.Append("parent.Form1.txtTEL_MEMO2_" & intRow + 1 & ".value = '" & _
                    '        Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO2")) & "';")
                    '2021/10/01 2021�N�x�Ď����P�E start
                    '2021/10/01 strMsg.Append("parent.Form1.txtTEL_MEMO_" & intRow + 1 & ".value = '" & _
                    '2021/10/01     Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO1")) & "\n" & _
                    '2021/10/01     Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO2")) & "\n" & _
                    '2021/10/01     Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("FUK_MEMO")) & "';")
                    strMsg.Append("parent.Form1.txtTEL_MEMO_" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO1")) & "\n" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO2")) & "\n" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("FUK_MEMO")) & "\n" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO4")) & "\n" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO5")) & "\n" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TEL_MEMO6")) & "';")
                    '2021/10/01 2021�N�x�Ď����P�E end
                    ' 2013/08/24 T.Ono �Ď����P2013��1 End
                    '�o���S����(�o���Ή���)
                    strMsg.Append("parent.Form1.txtTSTANNM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SYUTDTNM")) & "';")
                    '�A������ 
                    strMsg.Append("parent.Form1.txtAITNM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("AITNM")) & "';")
                    '����
                    strMsg.Append("parent.Form1.txtKIGNM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KIGNM")) & "';")
                    '�쓮����
                    strMsg.Append("parent.Form1.txtSADNM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SADNM")) & "';")
                    '2014/12/19 T.Ono del 2014���P�J�� No3 START
                    ''���̑�����
                    'strMsg.Append("parent.Form1.txtSTANM" & intRow + 1 & ".value = '" & _
                    '        Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("STANM")) & "';")
                    ''�Z���T����
                    'strMsg.Append("parent.Form1.txtASENM" & intRow + 1 & ".value = '" & _
                    '        Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("ASENM")) & "';")
                    '2014/12/19 T.Ono del 2014���P�J�� No3 END
                    '���A����
                    strMsg.Append("parent.Form1.txtFKINM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("FKINM")) & "';")
                    '���l�P�i�o�����ʓ��e/�񍐁j
                    ' 2013/08/24 T.Ono mod �Ď����P2013��1
                    'strMsg.Append("parent.Form1.txtSDTBIK2_" & intRow + 1 & ".value = '" & _
                    '        Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SDTBIK2")) & "';")
                    strMsg.Append("parent.Form1.txtSDTBIK2_" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SDTBIK2")) & "\n" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SNTTOKKI")) & "\n" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SDTBIK3")) & "';")
                    '�ً}�Ή�����
                    strMsg.Append("parent.Form1.txtSYOYMD" & intRow + 1 & ".value = '" & _
                            DateFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SYOYMD"))) & _
                            " " & _
                            TimeFncC.mGet(Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("SYOTIME")), 1) & _
                            "';")
                    '������ 2014/12/19 T.Ono add 2014���P�J�� No3
                    strMsg.Append("parent.Form1.txtFAX_REN_" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("FAX_REN")) & "';")
                    '2015/11/20 H.Mori add 2015���P�J�� No3 
                    strMsg.Append("parent.Form1.txtTFKINM" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("TFKINM")) & "';")
                    '2015/11/20 H.Mori add 2015���P�J�� No3
                    strMsg.Append("parent.Form1.txtKOK_TELNO" & intRow + 1 & ".value = '" & _
                            Convert.ToString(pdbData.Tables(0).Rows(intRow).Item("KOK_TELNO")) & "';")
                End If
            Next
        End If
    End Sub


    '******************************************************************************
    '*�@�T�@�v�F�����e�L�X�g�o�͎��Ɏg�p�i����(��:�R����)�ŋ�؂�j
    '*�@���@�l�F
    '******************************************************************************
    Private Function fncEditCutMsg(ByVal strCd As String, ByVal strMsg As String, ByVal strCut As String) As String
        Dim strRec As String
        If strCd.Length = 0 Then
            '2014/12/16 T.Ono mod 2014���P�J�� No3
            'strRec = ""
            strRec = strMsg
        Else
            strRec = strCd & strCut & strMsg
        End If
        Return strRec
    End Function
End Class
