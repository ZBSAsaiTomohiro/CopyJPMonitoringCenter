Namespace KETAIJAG00DTO
    Public Class AutoTaiouDto

        Private strGROUPCD As String 'グループコード
        Private kmDto As KmDto
        Private strPROCKBN As String '対応/無視区分
        Private strTAIOKBN As String '対応区分
        Private strTMSKB As String '処理区分
        Private strTKTANCD As String '監視担当者コード
        Private strTKTANNM As String '監視担当者名
        Private strTAITCD As String '連絡相手CD
        Private strTFKICD As String '復帰対応状況
        Private strTKIGCD As String 'ガス器具
        Private strTSADCD As String '作動原因
        Private strTELRCD As String '電話連絡内容
        Private strTEL_MEMO1 As String '電話対応メモ１
        Private strUSE_FLG As String '使用フラグ

        Public Sub New()
        End Sub

        'グループコード Setter/Getter
        Public Property groupcd()
            Get
                Return strGROUPCD
            End Get
            Set(ByVal Value)
                strGROUPCD = Value
            End Set
        End Property

        '警報DTO Setter/Getter
        Public Property pkmDto()
            Get
                Return kmDto
            End Get
            Set(ByVal Value)
                kmDto = Value
            End Set
        End Property

        '対応/無視区分 Setter/Getter
        Public Property prockbn()
            Get
                Return strPROCKBN
            End Get
            Set(ByVal Value)
                strPROCKBN = Value
            End Set
        End Property

        '対応区分 Setter/Getter
        Public Property taiokbn()
            Get
                Return strTAIOKBN
            End Get
            Set(ByVal Value)
                strTAIOKBN = Value
            End Set
        End Property

        '処理区分 Setter/Getter
        Public Property tmskb()
            Get
                Return strTMSKB
            End Get
            Set(ByVal Value)
                strTMSKB = Value
            End Set
        End Property

        '監視担当者コード Setter/Getter
        Public Property tktancd()
            Get
                Return strTKTANCD
            End Get
            Set(ByVal Value)
                strTKTANCD = Value
            End Set
        End Property

        '監視担当者名 Setter/Getter
        Public Property tktannm()
            Get
                Return strTKTANNM
            End Get
            Set(ByVal Value)
                strTKTANNM = Value
            End Set
        End Property

        '連絡相手CD Setter/Getter
        Public Property taitcd()
            Get
                Return strTAITCD
            End Get
            Set(ByVal Value)
                strTAITCD = Value
            End Set
        End Property

        '復帰対応状況 Setter/Getter
        Public Property tfkicd()
            Get
                Return strTFKICD
            End Get
            Set(ByVal Value)
                strTFKICD = Value
            End Set
        End Property

        'ガス器具 Setter/Getter
        Public Property tkigcd()
            Get
                Return strTKIGCD
            End Get
            Set(ByVal Value)
                strTKIGCD = Value
            End Set
        End Property

        '作動原因 Setter/Getter
        Public Property tsadcd()
            Get
                Return strTSADCD
            End Get
            Set(ByVal Value)
                strTSADCD = Value
            End Set
        End Property

        '電話連絡内容 Setter/Getter
        Public Property telrcd()
            Get
                Return strTELRCD
            End Get
            Set(ByVal Value)
                strTELRCD = Value
            End Set
        End Property

        '電話対応メモ１ Setter/Getter
        Public Property tel_memo1()
            Get
                Return strTEL_MEMO1
            End Get
            Set(ByVal Value)
                strTEL_MEMO1 = Value
            End Set
        End Property

        '使用フラグ Setter/Getter
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
