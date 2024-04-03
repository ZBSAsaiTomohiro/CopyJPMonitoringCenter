
Namespace KEJUKJAW00DTO

    Public Class D20TaiouDto

        Private strBackUrl As String = ""
        Private strMoveSerial As String = ""
        Private strKBN As String
        Private strKANSCD As String = ""
        Private strSYONO As String = ""
        Private strNCUHATYMD As String = ""
        Private strNCUHATTIME As String = ""
        Private strHATYMD As String = ""
        Private strHATTIME As String = ""
        Private strKENSIN As String = ""
        Private strKEIHOSU As String = ""
        Private strRYURYO As String = ""
        Private strMETASYU As String = ""
        Private strUNYO As String = ""
        Private strJUYMD As String = ""
        Private strJUTIME As String = ""
        Private strNUM_DIGIT As String = ""
        Private strKMCD1 As String = ""
        Private strKMNM1 As String = ""
        Private strKMCD2 As String = ""
        Private strKMNM2 As String = ""
        Private strKMCD3 As String = ""
        Private strKMNM3 As String = ""
        Private strKMCD4 As String = ""
        Private strKMNM4 As String = ""
        Private strKMCD5 As String = ""
        Private strKMNM5 As String = ""
        Private strKMCD6 As String = ""
        Private strKMNM6 As String = ""
        Private strKURACD As String = ""
        Private strKENNM As String = ""
        Private strJACD As String = ""
        Private strJANM As String = ""
        Private strHANJICD As String = "" '2014/12/19 T.Ono add 2014â¸ëPäJî≠ No2
        Private strHANJINM As String = "" '2014/12/19 T.Ono add 2014â¸ëPäJî≠ No2
        Private strACBCD As String = ""
        Private strACBNM As String = ""
        Private strUSER_CD As String = ""
        Private strJUSYONM As String = ""
        Private strJUSYOKN As String = ""
        Private strJUTEL1 As String = ""
        Private strJUTEL2 As String = ""
        Private strRENTEL As String = ""
        Private strKTELNO As String = ""
        Private strADDR As String = ""
        Private strNCU_SET As String = ""
        Private strTIZUNO As String = ""
        Private strHANBAI_KBN As String = "" '2015/11/25 H.Mori add 2015â¸ëPäJî≠ No1
        Private strKYOKTKBN As String = "" '2016/12/02 H.Mori add 2016â¸ëPäJî≠ No4-3
        Private strMET_KATA As String = ""
        Private strMET_MAKER As String = ""
        Private strBONB1_KKG As String = ""
        Private strBONB1_HON As String = ""
        Private strBONB1_YOBI As String = ""
        Private strBONB2_KKG As String = ""
        Private strBONB2_HON As String = ""
        Private strBONB2_YOBI As String = ""
        Private strBONB3_KKG As String = ""
        Private strBONB3_HON As String = ""
        Private strBONB3_YOBI As String = ""
        Private strBONB4_KKG As String = ""
        Private strBONB4_HON As String = ""
        Private strBONB4_YOBI As String = ""
        Private strZENKAI_HAISO As String = ""
        Private strZENKAI_HAI_S As String = ""
        Private strKONKAI_HAISO As String = ""
        Private strKONKAI_HAI_S As String = ""
        Private strJIKAI_HAISO As String = ""
        Private strZENKAI_KENSIN As String = ""
        Private strZENKAI_KEN_S As String = ""
        Private strZENKAI_KEN_SIYO As String = ""
        Private strKONKAI_KENSIN As String = ""
        Private strKONKAI_KEN_S As String = ""
        Private strKONKAI_KEN_SIYO As String = ""
        Private strZENKAI_HASEI As String = ""
        Private strZENKAI_HAS_S As String = ""
        Private strKONKAI_HASEI As String = ""
        Private strKONKAI_HAS_S As String = ""
        Private strG_ZAIKO As String = ""
        Private strICHI_SIYO As String = ""
        Private strYOSOKU_ICHI_SIYO As String = ""
        Private strGAS1_HINMEI As String = ""
        Private strGAS1_DAISU As String = ""
        Private strGAS1_SEIFL As String = ""
        Private strGAS2_HINMEI As String = ""
        Private strGAS2_DAISU As String = ""
        Private strGAS2_SEIFL As String = ""
        Private strGAS3_HINMEI As String = ""
        Private strGAS3_DAISU As String = ""
        Private strGAS3_SEIFL As String = ""
        Private strGAS4_HINMEI As String = ""
        Private strGAS4_DAISU As String = ""
        Private strGAS4_SEIFL As String = ""
        Private strGAS5_HINMEI As String = ""
        Private strGAS5_DAISU As String = ""
        Private strGAS5_SEIFL As String = ""
        Private strHATKBN As String = ""
        Private strTAIOKBN As String = ""
        Private strTMSKB As String = ""
        Private strTKTANCD As String = ""
        Private strTAITCD As String = ""
        Private strTAIO_ST_DATE As String = ""
        Private strTAIO_ST_TIME As String = ""
        Private strSYOYMD As String = ""
        Private strSYOTIME As String = ""
        Private strTAIO_SYO_TIME As String = ""
        Private strFAXKBN As String = ""
        Private strFAXKURAKBN As String = ""
        Private strFAXRUISEKIKBN As String = "" '2015/11/19 H.Mori add 2015â¸ëPäJî≠ No1
        Private strTELRCD As String = ""
        Private strTFKICD As String = ""
        Private strFUK_MEMO As String = ""
        Private strTEL_MEMO1 As String = ""
        Private strTEL_MEMO2 As String = ""
        Private strTEL_MEMO4 As String = ""      '2021/01/19 T.Ono add 2020â¸ëPäJî≠
        Private strTEL_MEMO5 As String = ""      '2021/01/19 T.Ono add 2020â¸ëPäJî≠
        Private strTEL_MEMO6 As String = ""      '2021/01/19 T.Ono add 2020â¸ëPäJî≠
        Private strMITOKBN As String = ""
        Private strTKIGCD As String = ""
        Private strTSADCD As String = ""
        Private strGENIN_KIJI As String = ""
        Private strSDCD As String = ""
        Private strSIJIYMD As String = ""
        Private strSIJITIME As String = ""
        Private strSIJI_BIKO1 As String = ""
        Private strSIJI_BIKO2 As String = ""
        Private strSTD_JASCD As String = ""
        Private strSTD_JANA As String = ""
        Private strSTD_JASNA As String = ""
        Private strREN_CODE As String = ""
        Private strREN_NA As String = ""
        Private strREN_TEL_1 As String = ""
        Private strREN_TEL_2 As String = ""
        Private strREN_TEL_3 As String = ""         ' 2013/05/27 T.Ono add
        Private strREN_FAX As String = ""
        Private strREN_BIKO As String = ""
        Private strREN_EDT_DATE As String = ""
        Private strREN_TIME As String = ""
        Private strREN_1_CODE As String = ""
        Private strREN_1_NA As String = ""
        Private strREN_1_TEL1 As String = ""
        Private strREN_1_TEL2 As String = ""
        Private strREN_1_TEL3 As String = ""        ' 2013/05/27 T.Ono add
        Private strREN_1_FAX As String = ""
        Private strREN_1_BIKO As String = ""
        Private strREN_1_EDT_DATE As String = ""
        Private strREN_1_TIME As String = ""
        Private strREN_2_CODE As String = ""
        Private strREN_2_NA As String = ""
        Private strREN_2_TEL1 As String = ""
        Private strREN_2_TEL2 As String = ""
        Private strREN_2_TEL3 As String = ""        ' 2013/05/27 T.Ono add
        Private strREN_2_FAX As String = ""
        Private strREN_2_BIKO As String = ""
        Private strREN_2_EDT_DATE As String = ""
        Private strREN_2_TIME As String = ""
        Private strREN_3_CODE As String = ""
        Private strREN_3_NA As String = ""
        Private strREN_3_TEL1 As String = ""
        Private strREN_3_TEL2 As String = ""
        Private strREN_3_TEL3 As String = ""        ' 2013/05/27 T.Ono add
        Private strREN_3_FAX As String = ""
        Private strREN_3_BIKO As String = ""
        Private strREN_3_EDT_DATE As String = ""
        Private strREN_3_TIME As String = ""
        Private strREN_DENWABIKO As String = ""
        Private strREN_FAXTITLE As String = ""
        Private strREN_FAX_REN As String = ""
        Private strSTD_CD As String = ""
        Private strSTD As String = ""
        Private strSTD_KYOTEN_CD As String = ""
        Private strSTD_KYOTEN As String = ""
        Private strSTD_TEL As String = ""
        Private strADD_DATE As String = ""
        Private strEDT_DATE As String = ""
        Private strTIME As String = ""
        Private strBOMB_TYPE As String = ""
        Private strGAS_STOP As String = ""
        Private strGAS_DELE As String = ""
        Private strGAS_RESTART As String = ""
        Private strBIKOU As String = ""
        Private strFAX_TITLE_CD As String = ""
        Private strDialKbns As String = ""
        Private strDialNumbers As String = ""
        Private strDialAites As String = ""
        Private strDialResult As String = ""
        Private strDialDates As String = ""
        Private strDialTimes As String = ""
        Private strDialStates As String = ""
        Private strSDSKBN As String = ""
        Private strKAITU_DAY As String = "" ' 2013/08/26 T.Ono add äƒéãâ¸ëP2013áÇ1
        Private strKANSHI_BIKO As String = "" ' 2016/02/02 W.GANEKO add 2015äƒéãâ¸ëP áÇ1-3
        Private strRENTEL2 As String = "" ' 2016/02/02 W.GANEKO add 2015äƒéãâ¸ëP áÇ1-3
        Private strRENTEL2_BIKO As String = "" ' 2016/02/02 W.GANEKO add 2015äƒéãâ¸ëP áÇ1-3
        Private strRENTEL2_UPD_DATE As String = "" ' 2016/02/02 W.GANEKO add 2015äƒéãâ¸ëP áÇ1-3
        Private strRENTEL3 As String = "" ' 2016/02/02 W.GANEKO add 2015äƒéãâ¸ëP áÇ1-3
        Private strRENTEL3_BIKO As String = "" ' 2016/02/02 W.GANEKO add 2015äƒéãâ¸ëP áÇ1-3
        Private strRENTEL3_UPD_DATE As String = "" ' 2016/02/02 W.GANEKO add 2015äƒéãâ¸ëP áÇ1-3
        Private strTUSIN As String = "" ' 2016/12/22 H.Mori add 2016â¸ëPäJî≠ No4-1 NCUê⁄ë±
        Private strFAXSPOTKBN As String = ""    ' 2016/12/14 H.Mori add 2016äƒéãâ¸ëP áÇ4-6
        Private strTELAB As String = "" ' 2016/12/19 H.Mori add 2016äƒéãâ¸ëP áÇ4-6
        Private strDAI3RENDORENTEL As String = "" ' 2016/12/19 H.Mori add 2016äƒéãâ¸ëP áÇ4-6
        Private strDAIHYO_NAME As String = "" ' 2016/12/22 H.Mori add 2016â¸ëPäJî≠ No4-6 
        Private strHOKBN As String = "" ' 2016/12/22 H.Mori add 2016â¸ëPäJî≠ No4-6 
        Private strYOTOKBN As String = "" ' 2016/12/22 H.Mori add 2016â¸ëPäJî≠ No4-6 
        Private strHANBCD As String = "" ' 2016/12/22 H.Mori add 2016â¸ëPäJî≠ No4-6 
        Private strKINRENCD As String = "" ' 2016/12/22 H.Mori add 2016â¸ëPäJî≠ No4-6 
        Private strSHUGOU As String = "" ' 2017/10/17 H.Mori add 2017â¸ëPäJî≠ No4-1
        Private strJMNAME As String = "" ' 2023/01/04 ADD Y.ARAKAKI 2022çXâ¸NoáE _í†ï[JMÉRÅ[Éhï\é¶í«â¡ëŒâû 

        Public Sub New()
        End Sub

        Public Property BackUrl() As String
            Get
                Return strBackUrl
            End Get
            Set(ByVal Value As String)
                strBackUrl = Value
            End Set
        End Property

        Public Property MoveSerial() As String
            Get
                Return strMoveSerial
            End Get
            Set(ByVal Value As String)
                strMoveSerial = Value
            End Set
        End Property

        Public Property KBN() As String
            Get
                Return strKBN
            End Get
            Set(ByVal Value As String)
                strKBN = Value
            End Set
        End Property

        Public Property KANSCD() As String
            Get
                Return strKANSCD
            End Get
            Set(ByVal Value As String)
                strKANSCD = Value
            End Set
        End Property

        Public Property SYONO() As String
            Get
                Return strSYONO
            End Get
            Set(ByVal Value As String)
                strSYONO = Value
            End Set
        End Property

        Public Property NCUHATYMD() As String
            Get
                Return strNCUHATYMD
            End Get
            Set(ByVal Value As String)
                strNCUHATYMD = Value
            End Set
        End Property

        Public Property NCUHATTIME() As String
            Get
                Return strNCUHATTIME
            End Get
            Set(ByVal Value As String)
                strNCUHATTIME = Value
            End Set
        End Property

        Public Property HATYMD() As String
            Get
                Return strHATYMD
            End Get
            Set(ByVal Value As String)
                strHATYMD = Value
            End Set
        End Property

        Public Property HATTIME() As String
            Get
                Return strHATTIME
            End Get
            Set(ByVal Value As String)
                strHATTIME = Value
            End Set
        End Property

        Public Property KENSIN() As String
            Get
                Return strKENSIN
            End Get
            Set(ByVal Value As String)
                strKENSIN = Value
            End Set
        End Property

        Public Property KEIHOSU() As String
            Get
                Return strKEIHOSU
            End Get
            Set(ByVal Value As String)
                strKEIHOSU = Value
            End Set
        End Property

        Public Property RYURYO() As String
            Get
                Return strRYURYO
            End Get
            Set(ByVal Value As String)
                strRYURYO = Value
            End Set
        End Property

        Public Property METASYU() As String
            Get
                Return strMETASYU
            End Get
            Set(ByVal Value As String)
                strMETASYU = Value
            End Set
        End Property

        Public Property UNYO() As String
            Get
                Return strUNYO
            End Get
            Set(ByVal Value As String)
                strUNYO = Value
            End Set
        End Property

        Public Property JUYMD() As String
            Get
                Return strJUYMD
            End Get
            Set(ByVal Value As String)
                strJUYMD = Value
            End Set
        End Property

        Public Property JUTIME() As String
            Get
                Return strJUTIME
            End Get
            Set(ByVal Value As String)
                strJUTIME = Value
            End Set
        End Property

        Public Property NUM_DIGIT() As String
            Get
                Return strNUM_DIGIT
            End Get
            Set(ByVal Value As String)
                strNUM_DIGIT = Value
            End Set
        End Property

        Public Property KMCD1() As String
            Get
                Return strKMCD1
            End Get
            Set(ByVal Value As String)
                strKMCD1 = Value
            End Set
        End Property

        Public Property KMNM1() As String
            Get
                Return strKMNM1
            End Get
            Set(ByVal Value As String)
                strKMNM1 = Value
            End Set
        End Property

        Public Property KMCD2() As String
            Get
                Return strKMCD2
            End Get
            Set(ByVal Value As String)
                strKMCD2 = Value
            End Set
        End Property

        Public Property KMNM2() As String
            Get
                Return strKMNM2
            End Get
            Set(ByVal Value As String)
                strKMNM2 = Value
            End Set
        End Property

        Public Property KMCD3() As String
            Get
                Return strKMCD3
            End Get
            Set(ByVal Value As String)
                strKMCD3 = Value
            End Set
        End Property

        Public Property KMNM3() As String
            Get
                Return strKMNM3
            End Get
            Set(ByVal Value As String)
                strKMNM3 = Value
            End Set
        End Property

        Public Property KMCD4() As String
            Get
                Return strKMCD4
            End Get
            Set(ByVal Value As String)
                strKMCD4 = Value
            End Set
        End Property

        Public Property KMNM4() As String
            Get
                Return strKMNM4
            End Get
            Set(ByVal Value As String)
                strKMNM4 = Value
            End Set
        End Property

        Public Property KMCD5() As String
            Get
                Return strKMCD5
            End Get
            Set(ByVal Value As String)
                strKMCD5 = Value
            End Set
        End Property

        Public Property KMNM5() As String
            Get
                Return strKMNM5
            End Get
            Set(ByVal Value As String)
                strKMNM5 = Value
            End Set
        End Property

        Public Property KMCD6() As String
            Get
                Return strKMCD6
            End Get
            Set(ByVal Value As String)
                strKMCD6 = Value
            End Set
        End Property

        Public Property KMNM6() As String
            Get
                Return strKMNM6
            End Get
            Set(ByVal Value As String)
                strKMNM6 = Value
            End Set
        End Property

        Public Property KURACD() As String
            Get
                Return strKURACD
            End Get
            Set(ByVal Value As String)
                strKURACD = Value
            End Set
        End Property

        Public Property KENNM() As String
            Get
                Return strKENNM
            End Get
            Set(ByVal Value As String)
                strKENNM = Value
            End Set
        End Property

        Public Property JACD() As String
            Get
                Return strJACD
            End Get
            Set(ByVal Value As String)
                strJACD = Value
            End Set
        End Property

        Public Property JANM() As String
            Get
                Return strJANM
            End Get
            Set(ByVal Value As String)
                strJANM = Value
            End Set
        End Property

        Public Property ACBCD() As String
            Get
                Return strACBCD
            End Get
            Set(ByVal Value As String)
                strACBCD = Value
            End Set
        End Property

        Public Property ACBNM() As String
            Get
                Return strACBNM
            End Get
            Set(ByVal Value As String)
                strACBNM = Value
            End Set
        End Property

        Public Property USER_CD() As String
            Get
                Return strUSER_CD
            End Get
            Set(ByVal Value As String)
                strUSER_CD = Value
            End Set
        End Property

        Public Property JUSYONM() As String
            Get
                Return strJUSYONM
            End Get
            Set(ByVal Value As String)
                strJUSYONM = Value
            End Set
        End Property

        Public Property JUSYOKN() As String
            Get
                Return strJUSYOKN
            End Get
            Set(ByVal Value As String)
                strJUSYOKN = Value
            End Set
        End Property

        Public Property JUTEL1() As String
            Get
                Return strJUTEL1
            End Get
            Set(ByVal Value As String)
                strJUTEL1 = Value
            End Set
        End Property

        Public Property JUTEL2() As String
            Get
                Return strJUTEL2
            End Get
            Set(ByVal Value As String)
                strJUTEL2 = Value
            End Set
        End Property

        Public Property RENTEL() As String
            Get
                Return strRENTEL
            End Get
            Set(ByVal Value As String)
                strRENTEL = Value
            End Set
        End Property

        Public Property KTELNO() As String
            Get
                Return strKTELNO
            End Get
            Set(ByVal Value As String)
                strKTELNO = Value
            End Set
        End Property

        Public Property ADDR() As String
            Get
                'Return strADDR
                Return Left(strADDR, 60) '2017/10/18 H.Mori mod ëŒâûT.ADDRÇÃí∑Ç≥Ç…é˚Ç‹ÇÈÇÊÇ§í≤êÆ 2017â¸ëPäJî≠ No4-2
            End Get
            Set(ByVal Value As String)
                strADDR = Value
            End Set
        End Property

        Public Property NCU_SET() As String
            Get
                Return strNCU_SET
            End Get
            Set(ByVal Value As String)
                strNCU_SET = Value
            End Set
        End Property

        Public Property TIZUNO() As String
            Get
                Return strTIZUNO
            End Get
            Set(ByVal Value As String)
                strTIZUNO = Value
            End Set
        End Property

        Public Property HANBAI_KBN() As String
            Get
                Return strHANBAI_KBN
            End Get
            Set(ByVal Value As String)
                strHANBAI_KBN = Value
            End Set
        End Property

        '2016/12/14 H.Mori add 2016äƒéãâ¸ëP START
        Public Property KYOKTKBN() As String
            Get
                Return strKYOKTKBN
            End Get
            Set(ByVal Value As String)
                strKYOKTKBN = Value
            End Set
        End Property
        '2016/12/14 H.Mori add 2016äƒéãâ¸ëP END

        Public Property MET_KATA() As String
            Get
                Return strMET_KATA
            End Get
            Set(ByVal Value As String)
                strMET_KATA = Value
            End Set
        End Property

        Public Property MET_MAKER() As String
            Get
                Return strMET_MAKER
            End Get
            Set(ByVal Value As String)
                strMET_MAKER = Value
            End Set
        End Property

        Public Property BONB1_KKG() As String
            Get
                Return strBONB1_KKG
            End Get
            Set(ByVal Value As String)
                strBONB1_KKG = Value
            End Set
        End Property

        Public Property BONB1_HON() As String
            Get
                Return strBONB1_HON
            End Get
            Set(ByVal Value As String)
                strBONB1_HON = Value
            End Set
        End Property

        Public Property BONB1_YOBI() As String
            Get
                Return strBONB1_YOBI
            End Get
            Set(ByVal Value As String)
                strBONB1_YOBI = Value
            End Set
        End Property

        Public Property BONB2_KKG() As String
            Get
                Return strBONB2_KKG
            End Get
            Set(ByVal Value As String)
                strBONB2_KKG = Value
            End Set
        End Property

        Public Property BONB2_HON() As String
            Get
                Return strBONB2_HON
            End Get
            Set(ByVal Value As String)
                strBONB2_HON = Value
            End Set
        End Property

        Public Property BONB2_YOBI() As String
            Get
                Return strBONB2_YOBI
            End Get
            Set(ByVal Value As String)
                strBONB2_YOBI = Value
            End Set
        End Property

        Public Property BONB3_KKG() As String
            Get
                Return strBONB3_KKG
            End Get
            Set(ByVal Value As String)
                strBONB3_KKG = Value
            End Set
        End Property

        Public Property BONB3_HON() As String
            Get
                Return strBONB3_HON
            End Get
            Set(ByVal Value As String)
                strBONB3_HON = Value
            End Set
        End Property

        Public Property BONB3_YOBI() As String
            Get
                Return strBONB3_YOBI
            End Get
            Set(ByVal Value As String)
                strBONB3_YOBI = Value
            End Set
        End Property

        Public Property BONB4_KKG() As String
            Get
                Return strBONB4_KKG
            End Get
            Set(ByVal Value As String)
                strBONB4_KKG = Value
            End Set
        End Property

        Public Property BONB4_HON() As String
            Get
                Return strBONB4_HON
            End Get
            Set(ByVal Value As String)
                strBONB4_HON = Value
            End Set
        End Property

        Public Property BONB4_YOBI() As String
            Get
                Return strBONB4_YOBI
            End Get
            Set(ByVal Value As String)
                strBONB4_YOBI = Value
            End Set
        End Property

        Public Property ZENKAI_HAISO() As String
            Get
                Return strZENKAI_HAISO
            End Get
            Set(ByVal Value As String)
                strZENKAI_HAISO = Value
            End Set
        End Property

        Public Property ZENKAI_HAI_S() As String
            Get
                Return strZENKAI_HAI_S
            End Get
            Set(ByVal Value As String)
                strZENKAI_HAI_S = Value
            End Set
        End Property

        Public Property KONKAI_HAISO() As String
            Get
                Return strKONKAI_HAISO
            End Get
            Set(ByVal Value As String)
                strKONKAI_HAISO = Value
            End Set
        End Property

        Public Property KONKAI_HAI_S() As String
            Get
                Return strKONKAI_HAI_S
            End Get
            Set(ByVal Value As String)
                strKONKAI_HAI_S = Value
            End Set
        End Property

        Public Property JIKAI_HAISO() As String
            Get
                Return strJIKAI_HAISO
            End Get
            Set(ByVal Value As String)
                strJIKAI_HAISO = Value
            End Set
        End Property

        Public Property ZENKAI_KENSIN() As String
            Get
                Return strZENKAI_KENSIN
            End Get
            Set(ByVal Value As String)
                strZENKAI_KENSIN = Value
            End Set
        End Property

        Public Property ZENKAI_KEN_S() As String
            Get
                Return strZENKAI_KEN_S
            End Get
            Set(ByVal Value As String)
                strZENKAI_KEN_S = Value
            End Set
        End Property

        Public Property ZENKAI_KEN_SIYO() As String
            Get
                Return strZENKAI_KEN_SIYO
            End Get
            Set(ByVal Value As String)
                strZENKAI_KEN_SIYO = Value
            End Set
        End Property

        Public Property KONKAI_KENSIN() As String
            Get
                Return strKONKAI_KENSIN
            End Get
            Set(ByVal Value As String)
                strKONKAI_KENSIN = Value
            End Set
        End Property

        Public Property KONKAI_KEN_S() As String
            Get
                Return strKONKAI_KEN_S
            End Get
            Set(ByVal Value As String)
                strKONKAI_KEN_S = Value
            End Set
        End Property

        Public Property KONKAI_KEN_SIYO() As String
            Get
                Return strKONKAI_KEN_SIYO
            End Get
            Set(ByVal Value As String)
                strKONKAI_KEN_SIYO = Value
            End Set
        End Property

        Public Property ZENKAI_HASEI() As String
            Get
                Return strZENKAI_HASEI
            End Get
            Set(ByVal Value As String)
                strZENKAI_HASEI = Value
            End Set
        End Property

        Public Property ZENKAI_HAS_S() As String
            Get
                Return strZENKAI_HAS_S
            End Get
            Set(ByVal Value As String)
                strZENKAI_HAS_S = Value
            End Set
        End Property

        Public Property KONKAI_HASEI() As String
            Get
                Return strKONKAI_HASEI
            End Get
            Set(ByVal Value As String)
                strKONKAI_HASEI = Value
            End Set
        End Property

        Public Property KONKAI_HAS_S() As String
            Get
                Return strKONKAI_HAS_S
            End Get
            Set(ByVal Value As String)
                strKONKAI_HAS_S = Value
            End Set
        End Property

        Public Property G_ZAIKO() As String
            Get
                Return strG_ZAIKO
            End Get
            Set(ByVal Value As String)
                strG_ZAIKO = Value
            End Set
        End Property

        Public Property ICHI_SIYO() As String
            Get
                Return strICHI_SIYO
            End Get
            Set(ByVal Value As String)
                strICHI_SIYO = Value
            End Set
        End Property

        Public Property YOSOKU_ICHI_SIYO() As String
            Get
                Return strYOSOKU_ICHI_SIYO
            End Get
            Set(ByVal Value As String)
                strYOSOKU_ICHI_SIYO = Value
            End Set
        End Property

        Public Property GAS1_HINMEI() As String
            Get
                Return strGAS1_HINMEI
            End Get
            Set(ByVal Value As String)
                strGAS1_HINMEI = Value
            End Set
        End Property

        Public Property GAS1_DAISU() As String
            Get
                Return strGAS1_DAISU
            End Get
            Set(ByVal Value As String)
                strGAS1_DAISU = Value
            End Set
        End Property

        Public Property GAS1_SEIFL() As String
            Get
                Return strGAS1_SEIFL
            End Get
            Set(ByVal Value As String)
                strGAS1_SEIFL = Value
            End Set
        End Property

        Public Property GAS2_HINMEI() As String
            Get
                Return strGAS2_HINMEI
            End Get
            Set(ByVal Value As String)
                strGAS2_HINMEI = Value
            End Set
        End Property

        Public Property GAS2_DAISU() As String
            Get
                Return strGAS2_DAISU
            End Get
            Set(ByVal Value As String)
                strGAS2_DAISU = Value
            End Set
        End Property

        Public Property GAS2_SEIFL() As String
            Get
                Return strGAS2_SEIFL
            End Get
            Set(ByVal Value As String)
                strGAS2_SEIFL = Value
            End Set
        End Property

        Public Property GAS3_HINMEI() As String
            Get
                Return strGAS3_HINMEI
            End Get
            Set(ByVal Value As String)
                strGAS3_HINMEI = Value
            End Set
        End Property

        Public Property GAS3_DAISU() As String
            Get
                Return strGAS3_DAISU
            End Get
            Set(ByVal Value As String)
                strGAS3_DAISU = Value
            End Set
        End Property

        Public Property GAS3_SEIFL() As String
            Get
                Return strGAS3_SEIFL
            End Get
            Set(ByVal Value As String)
                strGAS3_SEIFL = Value
            End Set
        End Property

        Public Property GAS4_HINMEI() As String
            Get
                Return strGAS4_HINMEI
            End Get
            Set(ByVal Value As String)
                strGAS4_HINMEI = Value
            End Set
        End Property

        Public Property GAS4_DAISU() As String
            Get
                Return strGAS4_DAISU
            End Get
            Set(ByVal Value As String)
                strGAS4_DAISU = Value
            End Set
        End Property

        Public Property GAS4_SEIFL() As String
            Get
                Return strGAS4_SEIFL
            End Get
            Set(ByVal Value As String)
                strGAS4_SEIFL = Value
            End Set
        End Property

        Public Property GAS5_HINMEI() As String
            Get
                Return strGAS5_HINMEI
            End Get
            Set(ByVal Value As String)
                strGAS5_HINMEI = Value
            End Set
        End Property

        Public Property GAS5_DAISU() As String
            Get
                Return strGAS5_DAISU
            End Get
            Set(ByVal Value As String)
                strGAS5_DAISU = Value
            End Set
        End Property

        Public Property GAS5_SEIFL() As String
            Get
                Return strGAS5_SEIFL
            End Get
            Set(ByVal Value As String)
                strGAS5_SEIFL = Value
            End Set
        End Property

        Public Property HATKBN() As String
            Get
                Return strHATKBN
            End Get
            Set(ByVal Value As String)
                strHATKBN = Value
            End Set
        End Property

        Public Property TAIOKBN() As String
            Get
                Return strTAIOKBN
            End Get
            Set(ByVal Value As String)
                strTAIOKBN = Value
            End Set
        End Property

        Public Property TMSKB() As String
            Get
                Return strTMSKB
            End Get
            Set(ByVal Value As String)
                strTMSKB = Value
            End Set
        End Property

        Public Property TKTANCD() As String
            Get
                Return strTKTANCD
            End Get
            Set(ByVal Value As String)
                strTKTANCD = Value
            End Set
        End Property

        Public Property TAITCD() As String
            Get
                Return strTAITCD
            End Get
            Set(ByVal Value As String)
                strTAITCD = Value
            End Set
        End Property

        Public Property TAIO_ST_DATE() As String
            Get
                Return strTAIO_ST_DATE
            End Get
            Set(ByVal Value As String)
                strTAIO_ST_DATE = Value
            End Set
        End Property

        Public Property TAIO_ST_TIME() As String
            Get
                Return strTAIO_ST_TIME
            End Get
            Set(ByVal Value As String)
                strTAIO_ST_TIME = Value
            End Set
        End Property

        Public Property SYOYMD() As String
            Get
                Return strSYOYMD
            End Get
            Set(ByVal Value As String)
                strSYOYMD = Value
            End Set
        End Property

        Public Property SYOTIME() As String
            Get
                Return strSYOTIME
            End Get
            Set(ByVal Value As String)
                strSYOTIME = Value
            End Set
        End Property

        Public Property TAIO_SYO_TIME() As String
            Get
                Return strTAIO_SYO_TIME
            End Get
            Set(ByVal Value As String)
                strTAIO_SYO_TIME = Value
            End Set
        End Property

        Public Property FAXKBN() As String
            Get
                Return strFAXKBN
            End Get
            Set(ByVal Value As String)
                strFAXKBN = Value
            End Set
        End Property

        Public Property FAXKURAKBN() As String
            Get
                Return strFAXKURAKBN
            End Get
            Set(ByVal Value As String)
                strFAXKURAKBN = Value
            End Set
        End Property

        Public Property FAXRUISEKIKBN() As String
            Get
                Return strFAXRUISEKIKBN
            End Get
            Set(ByVal Value As String)
                strFAXRUISEKIKBN = Value
            End Set
        End Property

        Public Property TELRCD() As String
            Get
                Return strTELRCD
            End Get
            Set(ByVal Value As String)
                strTELRCD = Value
            End Set
        End Property

        Public Property TFKICD() As String
            Get
                Return strTFKICD
            End Get
            Set(ByVal Value As String)
                strTFKICD = Value
            End Set
        End Property

        Public Property FUK_MEMO() As String
            Get
                Return strFUK_MEMO
            End Get
            Set(ByVal Value As String)
                strFUK_MEMO = Value
            End Set
        End Property

        Public Property TEL_MEMO1() As String
            Get
                Return strTEL_MEMO1
            End Get
            Set(ByVal Value As String)
                strTEL_MEMO1 = Value
            End Set
        End Property

        Public Property TEL_MEMO2() As String
            Get
                Return strTEL_MEMO2
            End Get
            Set(ByVal Value As String)
                strTEL_MEMO2 = Value
            End Set
        End Property
        '2021/01/19 T.Ono add 2020â¸ëPäJî≠
        Public Property TEL_MEMO4() As String
            Get
                Return strTEL_MEMO4
            End Get
            Set(ByVal Value As String)
                strTEL_MEMO4 = Value
            End Set
        End Property
        '2021/01/19 T.Ono add 2020â¸ëPäJî≠
        Public Property TEL_MEMO5() As String
            Get
                Return strTEL_MEMO5
            End Get
            Set(ByVal Value As String)
                strTEL_MEMO5 = Value
            End Set
        End Property
        '2021/01/19 T.Ono add 2020â¸ëPäJî≠
        Public Property TEL_MEMO6() As String
            Get
                Return strTEL_MEMO6
            End Get
            Set(ByVal Value As String)
                strTEL_MEMO6 = Value
            End Set
        End Property
        Public Property MITOKBN() As String
            Get
                Return strMITOKBN
            End Get
            Set(ByVal Value As String)
                strMITOKBN = Value
            End Set
        End Property

        Public Property TKIGCD() As String
            Get
                Return strTKIGCD
            End Get
            Set(ByVal Value As String)
                strTKIGCD = Value
            End Set
        End Property

        Public Property TSADCD() As String
            Get
                Return strTSADCD
            End Get
            Set(ByVal Value As String)
                strTSADCD = Value
            End Set
        End Property

        Public Property GENIN_KIJI() As String
            Get
                Return strGENIN_KIJI
            End Get
            Set(ByVal Value As String)
                strGENIN_KIJI = Value
            End Set
        End Property

        Public Property SDCD() As String
            Get
                Return strSDCD
            End Get
            Set(ByVal Value As String)
                strSDCD = Value
            End Set
        End Property

        Public Property SIJIYMD() As String
            Get
                Return strSIJIYMD
            End Get
            Set(ByVal Value As String)
                strSIJIYMD = Value
            End Set
        End Property

        Public Property SIJITIME() As String
            Get
                Return strSIJITIME
            End Get
            Set(ByVal Value As String)
                strSIJITIME = Value
            End Set
        End Property

        Public Property SIJI_BIKO1() As String
            Get
                Return strSIJI_BIKO1
            End Get
            Set(ByVal Value As String)
                strSIJI_BIKO1 = Value
            End Set
        End Property

        Public Property SIJI_BIKO2() As String
            Get
                Return strSIJI_BIKO2
            End Get
            Set(ByVal Value As String)
                strSIJI_BIKO2 = Value
            End Set
        End Property

        Public Property STD_JASCD() As String
            Get
                Return strSTD_JASCD
            End Get
            Set(ByVal Value As String)
                strSTD_JASCD = Value
            End Set
        End Property

        Public Property STD_JANA() As String
            Get
                Return strSTD_JANA
            End Get
            Set(ByVal Value As String)
                strSTD_JANA = Value
            End Set
        End Property

        Public Property STD_JASNA() As String
            Get
                Return strSTD_JASNA
            End Get
            Set(ByVal Value As String)
                strSTD_JASNA = Value
            End Set
        End Property

        Public Property REN_CODE() As String
            Get
                Return strREN_CODE
            End Get
            Set(ByVal Value As String)
                strREN_CODE = Value
            End Set
        End Property

        Public Property REN_NA() As String
            Get
                Return strREN_NA
            End Get
            Set(ByVal Value As String)
                strREN_NA = Value
            End Set
        End Property

        Public Property REN_TEL_1() As String
            Get
                Return strREN_TEL_1
            End Get
            Set(ByVal Value As String)
                strREN_TEL_1 = Value
            End Set
        End Property

        Public Property REN_TEL_2() As String
            Get
                Return strREN_TEL_2
            End Get
            Set(ByVal Value As String)
                strREN_TEL_2 = Value
            End Set
        End Property

        ' 2013/05/27 T.Ono add
        Public Property REN_TEL_3() As String
            Get
                Return strREN_TEL_3
            End Get
            Set(ByVal Value As String)
                strREN_TEL_3 = Value
            End Set
        End Property

        Public Property REN_FAX() As String
            Get
                Return strREN_FAX
            End Get
            Set(ByVal Value As String)
                strREN_FAX = Value
            End Set
        End Property

        Public Property REN_BIKO() As String
            Get
                Return strREN_BIKO
            End Get
            Set(ByVal Value As String)
                strREN_BIKO = Value
            End Set
        End Property

        Public Property REN_EDT_DATE() As String
            Get
                Return strREN_EDT_DATE
            End Get
            Set(ByVal Value As String)
                strREN_EDT_DATE = Value
            End Set
        End Property

        Public Property REN_TIME() As String
            Get
                Return strREN_TIME
            End Get
            Set(ByVal Value As String)
                strREN_TIME = Value
            End Set
        End Property

        Public Property REN_1_CODE() As String
            Get
                Return strREN_1_CODE
            End Get
            Set(ByVal Value As String)
                strREN_1_CODE = Value
            End Set
        End Property

        Public Property REN_1_NA() As String
            Get
                Return strREN_1_NA
            End Get
            Set(ByVal Value As String)
                strREN_1_NA = Value
            End Set
        End Property

        Public Property REN_1_TEL1() As String
            Get
                Return strREN_1_TEL1
            End Get
            Set(ByVal Value As String)
                strREN_1_TEL1 = Value
            End Set
        End Property

        Public Property REN_1_TEL2() As String
            Get
                Return strREN_1_TEL2
            End Get
            Set(ByVal Value As String)
                strREN_1_TEL2 = Value
            End Set
        End Property

        ' 2013/05/27 T.Ono add
        Public Property REN_1_TEL3() As String
            Get
                Return strREN_1_TEL3
            End Get
            Set(ByVal Value As String)
                strREN_1_TEL3 = Value
            End Set
        End Property

        Public Property REN_1_FAX() As String
            Get
                Return strREN_1_FAX
            End Get
            Set(ByVal Value As String)
                strREN_1_FAX = Value
            End Set
        End Property

        Public Property REN_1_BIKO() As String
            Get
                Return strREN_1_BIKO
            End Get
            Set(ByVal Value As String)
                strREN_1_BIKO = Value
            End Set
        End Property

        Public Property REN_1_EDT_DATE() As String
            Get
                Return strREN_1_EDT_DATE
            End Get
            Set(ByVal Value As String)
                strREN_1_EDT_DATE = Value
            End Set
        End Property

        Public Property REN_1_TIME() As String
            Get
                Return strREN_1_TIME
            End Get
            Set(ByVal Value As String)
                strREN_1_TIME = Value
            End Set
        End Property

        Public Property REN_2_CODE() As String
            Get
                Return strREN_2_CODE
            End Get
            Set(ByVal Value As String)
                strREN_2_CODE = Value
            End Set
        End Property

        Public Property REN_2_NA() As String
            Get
                Return strREN_2_NA
            End Get
            Set(ByVal Value As String)
                strREN_2_NA = Value
            End Set
        End Property

        Public Property REN_2_TEL1() As String
            Get
                Return strREN_2_TEL1
            End Get
            Set(ByVal Value As String)
                strREN_2_TEL1 = Value
            End Set
        End Property

        Public Property REN_2_TEL2() As String
            Get
                Return strREN_2_TEL2
            End Get
            Set(ByVal Value As String)
                strREN_2_TEL2 = Value
            End Set
        End Property

        ' 2013/05/27 T.Ono add
        Public Property REN_2_TEL3() As String
            Get
                Return strREN_2_TEL3
            End Get
            Set(ByVal Value As String)
                strREN_2_TEL3 = Value
            End Set
        End Property

        Public Property REN_2_FAX() As String
            Get
                Return strREN_2_FAX
            End Get
            Set(ByVal Value As String)
                strREN_2_FAX = Value
            End Set
        End Property

        Public Property REN_2_BIKO() As String
            Get
                Return strREN_2_BIKO
            End Get
            Set(ByVal Value As String)
                strREN_2_BIKO = Value
            End Set
        End Property

        Public Property REN_2_EDT_DATE() As String
            Get
                Return strREN_2_EDT_DATE
            End Get
            Set(ByVal Value As String)
                strREN_2_EDT_DATE = Value
            End Set
        End Property

        Public Property REN_2_TIME() As String
            Get
                Return strREN_2_TIME
            End Get
            Set(ByVal Value As String)
                strREN_2_TIME = Value
            End Set
        End Property

        Public Property REN_3_CODE() As String
            Get
                Return strREN_3_CODE
            End Get
            Set(ByVal Value As String)
                strREN_3_CODE = Value
            End Set
        End Property

        Public Property REN_3_NA() As String
            Get
                Return strREN_3_NA
            End Get
            Set(ByVal Value As String)
                strREN_3_NA = Value
            End Set
        End Property

        Public Property REN_3_TEL1() As String
            Get
                Return strREN_3_TEL1
            End Get
            Set(ByVal Value As String)
                strREN_3_TEL1 = Value
            End Set
        End Property

        Public Property REN_3_TEL2() As String
            Get
                Return strREN_3_TEL2
            End Get
            Set(ByVal Value As String)
                strREN_3_TEL2 = Value
            End Set
        End Property

        ' 2013/05/27 T.Ono add
        Public Property REN_3_TEL3() As String
            Get
                Return strREN_3_TEL3
            End Get
            Set(ByVal Value As String)
                strREN_3_TEL3 = Value
            End Set
        End Property

        Public Property REN_3_FAX() As String
            Get
                Return strREN_3_FAX
            End Get
            Set(ByVal Value As String)
                strREN_3_FAX = Value
            End Set
        End Property

        Public Property REN_3_BIKO() As String
            Get
                Return strREN_3_BIKO
            End Get
            Set(ByVal Value As String)
                strREN_3_BIKO = Value
            End Set
        End Property

        Public Property REN_3_EDT_DATE() As String
            Get
                Return strREN_3_EDT_DATE
            End Get
            Set(ByVal Value As String)
                strREN_3_EDT_DATE = Value
            End Set
        End Property

        Public Property REN_3_TIME() As String
            Get
                Return strREN_3_TIME
            End Get
            Set(ByVal Value As String)
                strREN_3_TIME = Value
            End Set
        End Property

        Public Property REN_DENWABIKO() As String
            Get
                Return strREN_DENWABIKO
            End Get
            Set(ByVal Value As String)
                strREN_DENWABIKO = Value
            End Set
        End Property

        Public Property REN_FAXTITLE() As String
            Get
                Return strREN_FAXTITLE
            End Get
            Set(ByVal Value As String)
                strREN_FAXTITLE = Value
            End Set
        End Property

        Public Property REN_FAX_REN() As String
            Get
                Return strREN_FAX_REN
            End Get
            Set(ByVal Value As String)
                strREN_FAX_REN = Value
            End Set
        End Property

        Public Property STD_CD() As String
            Get
                Return strSTD_CD
            End Get
            Set(ByVal Value As String)
                strSTD_CD = Value
            End Set
        End Property

        Public Property STD() As String
            Get
                Return strSTD
            End Get
            Set(ByVal Value As String)
                strSTD = Value
            End Set
        End Property

        Public Property STD_KYOTEN_CD() As String
            Get
                Return strSTD_KYOTEN_CD
            End Get
            Set(ByVal Value As String)
                strSTD_KYOTEN_CD = Value
            End Set
        End Property

        Public Property STD_KYOTEN() As String
            Get
                Return strSTD_KYOTEN
            End Get
            Set(ByVal Value As String)
                strSTD_KYOTEN = Value
            End Set
        End Property

        Public Property STD_TEL() As String
            Get
                Return strSTD_TEL
            End Get
            Set(ByVal Value As String)
                strSTD_TEL = Value
            End Set
        End Property

        Public Property ADD_DATE() As String
            Get
                Return strADD_DATE
            End Get
            Set(ByVal Value As String)
                strADD_DATE = Value
            End Set
        End Property

        Public Property EDT_DATE() As String
            Get
                Return strEDT_DATE
            End Get
            Set(ByVal Value As String)
                strEDT_DATE = Value
            End Set
        End Property

        Public Property TIME() As String
            Get
                Return strTIME
            End Get
            Set(ByVal Value As String)
                strTIME = Value
            End Set
        End Property

        Public Property BOMB_TYPE() As String
            Get
                Return strBOMB_TYPE
            End Get
            Set(ByVal Value As String)
                strBOMB_TYPE = Value
            End Set
        End Property

        Public Property GAS_STOP() As String
            Get
                Return strGAS_STOP
            End Get
            Set(ByVal Value As String)
                strGAS_STOP = Value
            End Set
        End Property

        Public Property GAS_DELE() As String
            Get
                Return strGAS_DELE
            End Get
            Set(ByVal Value As String)
                strGAS_DELE = Value
            End Set
        End Property

        Public Property GAS_RESTART() As String
            Get
                Return strGAS_RESTART
            End Get
            Set(ByVal Value As String)
                strGAS_RESTART = Value
            End Set
        End Property

        Public Property BIKOU() As String
            Get
                Return strBIKOU
            End Get
            Set(ByVal Value As String)
                strBIKOU = Value
            End Set
        End Property

        Public Property FAX_TITLE_CD() As String
            Get
                Return strFAX_TITLE_CD
            End Get
            Set(ByVal Value As String)
                strFAX_TITLE_CD = Value
            End Set
        End Property

        Public Property DialKbns() As String
            Get
                Return strDialKbns
            End Get
            Set(ByVal Value As String)
                strDialKbns = Value
            End Set
        End Property

        Public Property DialNumbers() As String
            Get
                Return strDialNumbers
            End Get
            Set(ByVal Value As String)
                strDialNumbers = Value
            End Set
        End Property

        Public Property DialAites() As String
            Get
                Return strDialAites
            End Get
            Set(ByVal Value As String)
                strDialAites = Value
            End Set
        End Property

        Public Property DialResult() As String
            Get
                Return strDialResult
            End Get
            Set(ByVal Value As String)
                strDialResult = Value
            End Set
        End Property

        Public Property DialDates() As String
            Get
                Return strDialDates
            End Get
            Set(ByVal Value As String)
                strDialDates = Value
            End Set
        End Property

        Public Property DialTimes() As String
            Get
                Return strDialTimes
            End Get
            Set(ByVal Value As String)
                strDialTimes = Value
            End Set
        End Property

        Public Property DialStates() As String
            Get
                Return strDialStates
            End Get
            Set(ByVal Value As String)
                strDialStates = Value
            End Set
        End Property

        Public Property SDSKBN() As String
            Get
                Return strSDSKBN
            End Get
            Set(ByVal Value As String)
                strSDSKBN = Value
            End Set
        End Property

        Public Property KAITU_DAY() As String
            Get
                Return strKAITU_DAY
            End Get
            Set(ByVal Value As String)
                strKAITU_DAY = Value
            End Set
        End Property

        Property HANJICD As String

        Property HANJINM As String
        '2016/02/02 W.GANEKO 2015äƒéãâ¸ëP áÇ1-3 start
        Public Property KANSHI_BIKO() As String
            Get
                Return strKANSHI_BIKO
            End Get
            Set(ByVal Value As String)
                strKANSHI_BIKO = Value
            End Set
        End Property
        Public Property RENTEL2() As String
            Get
                Return strRENTEL2
            End Get
            Set(ByVal Value As String)
                strRENTEL2 = Value
            End Set
        End Property
        Public Property RENTEL2_BIKO() As String
            Get
                Return strRENTEL2_BIKO
            End Get
            Set(ByVal Value As String)
                strRENTEL2_BIKO = Value
            End Set
        End Property
        Public Property RENTEL2_UPD_DATE() As String
            Get
                Return strRENTEL2_UPD_DATE
            End Get
            Set(ByVal Value As String)
                strRENTEL2_UPD_DATE = Value
            End Set
        End Property
        Public Property RENTEL3() As String
            Get
                Return strRENTEL3
            End Get
            Set(ByVal Value As String)
                strRENTEL3 = Value
            End Set
        End Property
        Public Property RENTEL3_BIKO() As String
            Get
                Return strRENTEL3_BIKO
            End Get
            Set(ByVal Value As String)
                strRENTEL3_BIKO = Value
            End Set
        End Property
        Public Property RENTEL3_UPD_DATE() As String
            Get
                Return strRENTEL3_UPD_DATE
            End Get
            Set(ByVal Value As String)
                strRENTEL3_UPD_DATE = Value
            End Set
        End Property
        '2016/02/02 W.GANEKO 2015äƒéãâ¸ëP áÇ1-3 end
        ' 2016/12/22 H.Mori add 2016â¸ëPäJî≠ No4-1 NCUê⁄ë± START
        Public Property TUSIN() As String
            Get
                Return strTUSIN
            End Get
            Set(ByVal Value As String)
                strTUSIN = Value
            End Set
        End Property
        ' 2016/12/22 H.Mori add 2016â¸ëPäJî≠ No4-1 NCUê⁄ë± END
        '2016/12/14 H.Mori 2016äƒéãâ¸ëP N04-6 START
        Public Property FAXSPOTKBN() As String
            Get
                Return strFAXSPOTKBN
            End Get
            Set(ByVal Value As String)
                strFAXSPOTKBN = Value
            End Set
        End Property
        Public Property TELAB() As String
            Get
                Return strTELAB
            End Get
            Set(ByVal Value As String)
                strTELAB = Value
            End Set
        End Property
        Public Property DAI3RENDORENTEL() As String
            Get
                Return strDAI3RENDORENTEL
            End Get
            Set(ByVal Value As String)
                strDAI3RENDORENTEL = Value
            End Set
        End Property
        Public Property DAIHYO_NAME() As String
            Get
                Return strDAIHYO_NAME
            End Get
            Set(ByVal Value As String)
                strDAIHYO_NAME = Value
            End Set
        End Property
        Public Property HOKBN() As String
            Get
                Return strHOKBN
            End Get
            Set(ByVal Value As String)
                strHOKBN = Value
            End Set
        End Property
        Public Property YOTOKBN() As String
            Get
                Return strYOTOKBN
            End Get
            Set(ByVal Value As String)
                strYOTOKBN = Value
            End Set
        End Property
        Public Property HANBCD() As String
            Get
                Return strHANBCD
            End Get
            Set(ByVal Value As String)
                strHANBCD = Value
            End Set
        End Property
        Public Property KINRENCD() As String
            Get
                Return strKINRENCD
            End Get
            Set(ByVal Value As String)
                strKINRENCD = Value
            End Set
        End Property
        '2016/12/22 H.Mori 2016äƒéãâ¸ëP No4-6 END
        ' 2023/01/04 ADD START Y.ARAKAKI 2022çXâ¸NoáE _í†ï[JMÉRÅ[Éhï\é¶í«â¡ëŒâû
        Public Property JMNAME() As String
            Get
                Return strJMNAME
            End Get
            Set(ByVal Value As String)
                strJMNAME = Value
            End Set
        End Property
        ' 2023/01/04 ADD END   Y.ARAKAKI 2022çXâ¸NoáE _í†ï[JMÉRÅ[Éhï\é¶í«â¡ëŒâû
        '2017/10/17 H.Mori add 2017â¸ëPäJî≠ No4-1 START
        Public Property SHUGOU() As String
            Get
                Return strSHUGOU
            End Get
            Set(ByVal Value As String)
                strSHUGOU = Value
            End Set
        End Property
        '2017/10/17 H.Mori add 2017â¸ëPäJî≠ No4-1 END
    End Class
End Namespace

