Namespace KETAIJAG00DTO
    Public Class AutoTaiouLists

        Private allList As ArrayList '対応リスト
        Private ignoreList As ArrayList '無視リスト
        Private autoList As ArrayList '自動対応リスト
        Private choufukuList As ArrayList '重複表示リスト
        Private Const PROCKBN_AUTO As String = "1" '対応・無視区分（自動対応）
        Private Const PROCKBN_OUT1 As String = "2" '対応・無視区分（無視）
        Private Const PROCKBN_OUT2 As String = "3" '対応・無視区分（無視：集中監視確認）
        Private Const PROCKBN_CHOUFUKU As String = "4" '対応・無視区分（重複表示）

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
                    'リストに追加
                    allList.Add(record)

                    If record.prockbn = PROCKBN_AUTO Then
                        '自動対応データを追加
                        autoList.Add(record)
                    ElseIf record.prockbn = PROCKBN_OUT1 Or record.prockbn = PROCKBN_OUT2 Then
                        '無視データを追加
                        ignoreList.Add(record)
                    ElseIf record.prockbn = PROCKBN_CHOUFUKU Then
                        '重複表示データを追加
                        choufukuList.Add(record)
                    End If
                Next
            End If
        End Sub

        '対応リスト setter/getter
        Public Property taiouList()
            Get
                Return allList
            End Get
            Set(ByVal Value)
                allList = Value
            End Set
        End Property

        '自動対応リスト setter/getter
        Public Property procListByAuto()
            Get
                Return autoList
            End Get
            Set(ByVal Value)
                autoList = Value
            End Set
        End Property

        '無視リスト setter/getter
        Public Property procListByIgnore()
            Get
                Return ignoreList
            End Get
            Set(ByVal Value)
                ignoreList = Value
            End Set
        End Property

        '重複表示リスト setter/getter
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

