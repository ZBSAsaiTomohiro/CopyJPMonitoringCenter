Namespace KETAIJAG00DTO
    Public Class AutoTaiouLists

        Private allList As ArrayList '�Ή����X�g
        Private ignoreList As ArrayList '�������X�g
        Private autoList As ArrayList '�����Ή����X�g
        Private choufukuList As ArrayList '�d���\�����X�g
        Private Const PROCKBN_AUTO As String = "1" '�Ή��E�����敪�i�����Ή��j
        Private Const PROCKBN_OUT1 As String = "2" '�Ή��E�����敪�i�����j
        Private Const PROCKBN_OUT2 As String = "3" '�Ή��E�����敪�i�����F�W���Ď��m�F�j
        Private Const PROCKBN_CHOUFUKU As String = "4" '�Ή��E�����敪�i�d���\���j

        Public Sub New(ByVal dataTable As DataTable)
            allList = New ArrayList
            ignoreList = New ArrayList
            autoList = New ArrayList
            choufukuList = New ArrayList
            If dataTable.Rows.Count > 0 Then
                Dim record As AutoTaiouDto
                For i As Integer = 0 To dataTable.Rows.Count - 1
                    record = New AutoTaiouDto
                    record.groupcd = Convert.ToString(dataTable.Rows(i).Item("GROUPCD"))
                    record.pkmDto = New KmDto(Convert.ToString(dataTable.Rows(i).Item("KMCD")), _
                                                Convert.ToString(dataTable.Rows(i).Item("KMNM")))
                    record.prockbn = Convert.ToString(dataTable.Rows(i).Item("PROCKBN"))
                    record.taiokbn = Convert.ToString(dataTable.Rows(i).Item("TAIOKBN"))
                    record.tmskb = Convert.ToString(dataTable.Rows(i).Item("TMSKB"))
                    record.tktancd = Convert.ToString(dataTable.Rows(i).Item("TKTANCD"))
                    record.tktannm = Convert.ToString(dataTable.Rows(i).Item("TANNM"))
                    record.taitcd = Convert.ToString(dataTable.Rows(i).Item("TAITCD"))
                    record.tfkicd = Convert.ToString(dataTable.Rows(i).Item("TFKICD"))
                    record.tkigcd = Convert.ToString(dataTable.Rows(i).Item("TKIGCD"))
                    record.tsadcd = Convert.ToString(dataTable.Rows(i).Item("TSADCD"))
                    record.telrcd = Convert.ToString(dataTable.Rows(i).Item("TELRCD"))
                    record.tel_memo1 = Convert.ToString(dataTable.Rows(i).Item("TEL_MEMO1"))
                    record.use_flg = Convert.ToString(dataTable.Rows(i).Item("USE_FLG"))
                    '���X�g�ɒǉ�
                    allList.Add(record)

                    If record.prockbn = PROCKBN_AUTO Then
                        '�����Ή��f�[�^��ǉ�
                        autoList.Add(record)
                    ElseIf record.prockbn = PROCKBN_OUT1 Or record.prockbn = PROCKBN_OUT2 Then
                        '�����f�[�^��ǉ�
                        ignoreList.Add(record)
                    ElseIf record.prockbn = PROCKBN_CHOUFUKU Then
                        '�d���\���f�[�^��ǉ�
                        choufukuList.Add(record)
                    End If
                Next
            End If
        End Sub

        '�Ή����X�g setter/getter
        Public Property taiouList()
            Get
                Return allList
            End Get
            Set(ByVal Value)
                allList = Value
            End Set
        End Property

        '�����Ή����X�g setter/getter
        Public Property procListByAuto()
            Get
                Return autoList
            End Get
            Set(ByVal Value)
                autoList = Value
            End Set
        End Property

        '�������X�g setter/getter
        Public Property procListByIgnore()
            Get
                Return ignoreList
            End Get
            Set(ByVal Value)
                ignoreList = Value
            End Set
        End Property

        '�d���\�����X�g setter/getter
        Public Property procListByChoufuku()
            Get
                Return choufukuList
            End Get
            Set(ByVal Value)
                choufukuList = Value
            End Set
        End Property

    End Class
End Namespace

