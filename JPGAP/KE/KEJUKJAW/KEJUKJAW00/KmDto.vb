Namespace KEJUKJAW00DTO
    Public Class KmDto

        Private strKmCd As String 'åxïÒÉRÅ[Éh
        Private strKmNm As String 'åxïÒñºèÃ

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

        'åxïÒÉRÅ[Éh Setter/Getter
        Public Property KmCd()
            Get
                Return strKmCd
            End Get
            Set(ByVal Value)
                strKmCd = Value
            End Set
        End Property

        'åxïÒñºèÃ Setter/Getter
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
