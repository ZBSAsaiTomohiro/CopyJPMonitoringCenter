Namespace KEJUKJAW00DTO
    Public Class KmDto

        Private strKmCd As String '�x��R�[�h
        Private strKmNm As String '�x�񖼏�

        Public Sub New(ByVal kmcd As String, ByVal kmnm As String)
            strKmCd = kmcd
            strKmNm = kmnm
        End Sub

        Public Function isEquals(ByVal kmdto As KmDto) As Boolean
            If strKmCd.Equals(kmdto.KmCd) And strKmNm.Equals(kmdto.KmNm) Then
                Return True
            End If
            Return False
        End Function

        '�x��R�[�h Setter/Getter
        Public Property KmCd()
            Get
                Return strKmCd
            End Get
            Set(ByVal Value)
                strKmCd = Value
            End Set
        End Property

        '�x�񖼏� Setter/Getter
        Public Property KmNm()
            Get
                Return strKmNm
            End Get
            Set(ByVal Value)
                strKmNm = Value
            End Set
        End Property

    End Class
End Namespace
