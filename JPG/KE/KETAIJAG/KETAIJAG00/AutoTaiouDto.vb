Namespace KETAIJAG00DTO
    Public Class AutoTaiouDto

        Private strGROUPCD As String '�O���[�v�R�[�h
        Private kmDto As KmDto
        Private strPROCKBN As String '�Ή�/�����敪
        Private strTAIOKBN As String '�Ή��敪
        Private strTMSKB As String '�����敪
        Private strTKTANCD As String '�Ď��S���҃R�[�h
        Private strTKTANNM As String '�Ď��S���Җ�
        Private strTAITCD As String '�A������CD
        Private strTFKICD As String '���A�Ή���
        Private strTKIGCD As String '�K�X���
        Private strTSADCD As String '�쓮����
        Private strTELRCD As String '�d�b�A�����e
        Private strTEL_MEMO1 As String '�d�b�Ή������P
        Private strUSE_FLG As String '�g�p�t���O

        Public Sub New()
        End Sub

        '�O���[�v�R�[�h Setter/Getter
        Public Property groupcd()
            Get
                Return strGROUPCD
            End Get
            Set(ByVal Value)
                strGROUPCD = Value
            End Set
        End Property

        '�x��DTO Setter/Getter
        Public Property pkmDto()
            Get
                Return kmDto
            End Get
            Set(ByVal Value)
                kmDto = Value
            End Set
        End Property

        '�Ή�/�����敪 Setter/Getter
        Public Property prockbn()
            Get
                Return strPROCKBN
            End Get
            Set(ByVal Value)
                strPROCKBN = Value
            End Set
        End Property

        '�Ή��敪 Setter/Getter
        Public Property taiokbn()
            Get
                Return strTAIOKBN
            End Get
            Set(ByVal Value)
                strTAIOKBN = Value
            End Set
        End Property

        '�����敪 Setter/Getter
        Public Property tmskb()
            Get
                Return strTMSKB
            End Get
            Set(ByVal Value)
                strTMSKB = Value
            End Set
        End Property

        '�Ď��S���҃R�[�h Setter/Getter
        Public Property tktancd()
            Get
                Return strTKTANCD
            End Get
            Set(ByVal Value)
                strTKTANCD = Value
            End Set
        End Property

        '�Ď��S���Җ� Setter/Getter
        Public Property tktannm()
            Get
                Return strTKTANNM
            End Get
            Set(ByVal Value)
                strTKTANNM = Value
            End Set
        End Property

        '�A������CD Setter/Getter
        Public Property taitcd()
            Get
                Return strTAITCD
            End Get
            Set(ByVal Value)
                strTAITCD = Value
            End Set
        End Property

        '���A�Ή��� Setter/Getter
        Public Property tfkicd()
            Get
                Return strTFKICD
            End Get
            Set(ByVal Value)
                strTFKICD = Value
            End Set
        End Property

        '�K�X��� Setter/Getter
        Public Property tkigcd()
            Get
                Return strTKIGCD
            End Get
            Set(ByVal Value)
                strTKIGCD = Value
            End Set
        End Property

        '�쓮���� Setter/Getter
        Public Property tsadcd()
            Get
                Return strTSADCD
            End Get
            Set(ByVal Value)
                strTSADCD = Value
            End Set
        End Property

        '�d�b�A�����e Setter/Getter
        Public Property telrcd()
            Get
                Return strTELRCD
            End Get
            Set(ByVal Value)
                strTELRCD = Value
            End Set
        End Property

        '�d�b�Ή������P Setter/Getter
        Public Property tel_memo1()
            Get
                Return strTEL_MEMO1
            End Get
            Set(ByVal Value)
                strTEL_MEMO1 = Value
            End Set
        End Property

        '�g�p�t���O Setter/Getter
        Public Property use_flg()
            Get
                Return strUSE_FLG
            End Get
            Set(ByVal Value)
                strUSE_FLG = Value
            End Set
        End Property

    End Class
End Namespace
