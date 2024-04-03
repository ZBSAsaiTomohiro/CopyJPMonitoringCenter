Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common

Partial Class COGMENUG00
    Inherits System.Web.UI.Page

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
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//------------------------------------------
        '//�@HTTP�w�b�_�𑗐M
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//�@�F�؃N���X�̃C���X�^���X����
        AuthC = New CAuthenticate(Request, Response)

        Dim strGROUPNAME As String = AuthC.pGROUPNAME
        Dim arrGroupName() As String = strGROUPNAME.Split(Convert.ToChar(","))

        '--- ��2005/04/19 MOD�@Falcon�� -----------------
        Dim bolKANSHI_FLG As Boolean = False
        Dim arrKanshiGroup() As String = AuthC.pGROUP_KANSHI.Split(Convert.ToChar(","))
        Dim i As Integer
        Dim bolUNKOU_FLG As Boolean = False
        Dim arrUnkouGroup() As String = AuthC.pGROUP_UNKOU.Split(Convert.ToChar(","))

        '>>�^�s�J���������`�F�b�N
        For i = 0 To arrUnkouGroup.Length - 1
            If Array.IndexOf(arrGroupName, arrUnkouGroup(i)) >= 0 Then
                bolUNKOU_FLG = True
                Exit For
            End If
        Next i

        '>>�Ď��Z���^�[�����`�F�b�N
        If bolUNKOU_FLG = False Then
            For i = 0 To arrKanshiGroup.Length - 1
                If Array.IndexOf(arrGroupName, arrKanshiGroup(i)) >= 0 Then
                    bolKANSHI_FLG = True
                    Exit For
                End If
            Next i
        End If
        '--- ��2005/04/19 MOD Falcon�� ------------------

        '--- ��2005/04/19 MOD�@Falcon�� -----------------
        If bolUNKOU_FLG = True Then
            '//-----------------------------------------------------
            '// �^�s�J�����̃O���[�v�ɑ����Ă���ꍇ�́u�^�s�J�������j���[�v���o��
            '//-----------------------------------------------------

            Server.Transfer("COGMNKHG00.aspx")
            '--- ��2005/04/19 MOD Falcon�� ------------------

            '--- ��2005/04/19 DEL�@Falcon�� -----------------
            'If Array.IndexOf(arrGroupName, AuthC.pGROUP_UNKOU) >= 0 Then
            '    '//-----------------------------------------------------
            '    '// �^�s�J�����̃O���[�v�ɑ����Ă���ꍇ�́u�^�s�J�������j���[�v���o��
            '    '//-----------------------------------------------------
            '    Server.Transfer("COGMNKHG00.aspx")
            '--- ��2005/04/19 DEL Falcon�� ------------------

            '--- ��2005/04/19 MOD�@Falcon�� -----------------
        ElseIf bolKANSHI_FLG = True Then
            '//-----------------------------------------------------
            '// �Ď��Z���^�[�̃O���[�v�ɑ����Ă���ꍇ�́u�Ď��Z���^�[���j���[�v���o��
            '//-----------------------------------------------------
            Server.Transfer("COGMNCTG00.aspx")
            '--- ��2005/04/19 MOD Falcon�� ------------------

            '--- ��2005/04/19 DEL�@Falcon�� -----------------
            '''''ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_TOUHOKU) >= 0 Then
            '''''    '//-----------------------------------------------------
            '''''    '// ���Ď��Z���^�[�̃O���[�v�ɑ����Ă���ꍇ�́u�Ď��Z���^�[���j���[�v���o��
            '''''    '//-----------------------------------------------------
            '''''    Server.Transfer("COGMNCTG00.aspx")

            '''''ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_NAKANIHON) >= 0 Then
            '''''    '//-----------------------------------------------------
            '''''    '// �����{�Ď��Z���^�[�̃O���[�v�ɑ����Ă���ꍇ�́u�Ď��Z���^�[���j���[�v���o��
            '''''    '//-----------------------------------------------------
            '''''    Server.Transfer("COGMNCTG00.aspx")

            '''''ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_NISHINIHON) >= 0 Then
            '''''    '//-----------------------------------------------------
            '''''    '// �L���Ď��Z���^�[�̃O���[�v�ɑ����Ă���ꍇ�́u�Ď��Z���^�[���j���[�v���o��
            '''''    '//-----------------------------------------------------
            '''''    Server.Transfer("COGMNCTG00.aspx")
            '--- ��2005/04/19 DEL Falcon�� ------------------

        ElseIf Array.IndexOf(arrGroupName, AuthC.pGROUP_EIGYOU) >= 0 Then
            '//-----------------------------------------------------
            '// �c�ƕ��̃O���[�v�ɑ����Ă���ꍇ�́u�c�ƕ����j���[�v���o��
            '//-----------------------------------------------------
            Server.Transfer("COGMNEGG00.aspx")

        Else
            '//-----------------------------------------------------
            '// �c�ƕ��̃O���[�v�ɑ����Ă���ꍇ�́u�c�ƕ����j���[�v���o��
            '// �擾�����񂪍Ō�ɂ��Ă���O���[�v�����c�Ə��Ƃ��Ĕ��f
            '//-----------------------------------------------------
            Dim j As Integer
            Dim intEIGYOU_LEN As Integer
            Dim intGROUP_LEN As Integer
            intEIGYOU_LEN = AuthC.pGROUP_EIGYOU.Length
            For j = 0 To arrGroupName.Length - 1
                intGROUP_LEN = arrGroupName(j).Length
                If intGROUP_LEN > 0 Then
                    If Convert.ToString(arrGroupName(j)).Substring(intGROUP_LEN - intEIGYOU_LEN, intEIGYOU_LEN) = AuthC.pGROUP_EIGYOU Then
                        '//�c�Ə��O���[�v�������݂���ꍇ�͂��̂܂܃��^�[��
                        Server.Transfer("COGMNEGG00.aspx")
                    End If
                End If
            Next

            Response.Write("�����O���[�v�����ł��܂���ł���")
        End If
    End Sub

End Class
