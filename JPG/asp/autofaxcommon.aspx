<script runat="server">
    private const SID = "KANSIKAI"
    'private const SID = "KANSIHON"
</script>
<script runat="server">
    Function getCompSQL4FaxNo(pg, ymdto, kanscdwhe, kanscdlock, sendkbn)
        Dim sql_z
        Dim sql1
        sql_z = ""
        sql_z = sql_z & "/* åèêîämîFÅFäƒéãÉZÉìÉ^Å[ÅÑÇeÇ`Çwî‘çÜ èá */ " & vbcrlf
        sql_z = sql_z & "SELECT  " & vbCrLf
        sql_z = sql_z & "    T.EXEC_KBN,  " & vbCrLf
        sql_z = sql_z & "    T.TAIOU_KANSCD,  " & vbCrLf
        sql_z = sql_z & "    T.TAIOU_KURACD,  " & vbCrLf
        sql_z = sql_z & "    T.AUTO_FAXNO,  " & vbCrLf
        sql_z = sql_z & "    T.AUTO_JANM,  " & vbCrLf
        sql_z = sql_z & "    T.SEND_CNT,  " & vbCrLf
        sql_z = sql_z & "    T.ALL_CNT,  " & vbCrLf
        sql_z = sql_z & "    T.AUTO_ZERO_FLG,  " & vbCrLf ' 2014/04/16 T.Watabe add
        sql_z = sql_z & "    DECODE(T.AUTO_CHOICE, '4', '4:JA', '3', '3:JAéxèä', '2', '2:å⁄ãqîÕàÕ', '1', '1:å⁄ãqéwíË', '') AS AUTO_CHOICE,  " & vbCrLf
        sql_z = sql_z & "    P.EXEC_KBN AS LOG_EXEC_KBN,  " & vbCrLf
        sql_z = sql_z & "    P.TAIOU_KANSCD AS LOG_KANSCD,   " & vbCrLf
        sql_z = sql_z & "    P.TAIOU_KURACD AS LOG_KURACD,  " & vbCrLf
        sql_z = sql_z & "    P.AUTO_FAXNO   AS LOG_AUTO_FAXNO,  " & vbCrLf
        sql_z = sql_z & "    P.SEND_CNT          AS LOG_CNT,  " & vbCrLf
        sql_z = sql_z & "    P.AUTO_ZERO_FLG AS LOG_AUTO_ZERO_FLG,  " & vbCrLf
        'sql_z = sql_z & "    (DECODE(P.AUTO_ZERO_FLG, '1', 'Åõ',  " & vbCrLf
        'sql_z = sql_z & "      DECODE((T.AUTO_FAXNO || P.AUTO_FAXNO), null, 'Åõ',  " & vbCrLf
        'sql_z = sql_z & "        DECODE(T.AUTO_FAXNO, P.AUTO_FAXNO,  " & vbCrLf
        'sql_z = sql_z & "          DECODE(T.SEND_CNT, P.SEND_CNT, 'Åõ', 'Çw'),  " & vbCrLf
        'sql_z = sql_z & "          DECODE(T.SEND_CNT, 0, 'Åõ', 'Çw') " & vbCrLf
        'sql_z = sql_z & "          ) " & vbCrLf
        'sql_z = sql_z & "        ) " & vbCrLf
        'sql_z = sql_z & "      ) " & vbCrLf
        'sql_z = sql_z & "    ) AS COMP  " & vbCrLf
        sql_z = sql_z & "    DECODE((T.AUTO_FAXNO || P.AUTO_FAXNO), null, 'Åõ',  " & vbCrLf
        sql_z = sql_z & "        DECODE(P.AUTO_FAXNO, NULL, " & vbCrLf
        sql_z = sql_z & "            DECODE(T.SEND_CNT, 0, 'Åõ', 'Çw'), " & vbCrLf
        sql_z = sql_z & "            DECODE(T.SEND_CNT, " & vbCrLf
        sql_z = sql_z & "                   P.SEND_CNT, " & vbCrLf
        sql_z = sql_z & "                   DECODE(T.AUTO_ZERO_FLG, P.AUTO_ZERO_FLG, 'Åõ', 'Çw'), " & vbCrLf
        sql_z = sql_z & "                   'Çw'  " & vbCrLf
        sql_z = sql_z & "            )  " & vbCrLf
        sql_z = sql_z & "        )  " & vbCrLf
        sql_z = sql_z & "    ) AS COMP  " & vbCrLf ' 2014/04/16 T.Watabe add
        sql_z = sql_z & "FROM  " & vbCrLf
        sql_z = sql_z & "(  " & vbCrLf
        sql_z = sql_z & "        /* ÇPÅFóùò_íl */  " & vbCrLf
        sql_z = sql_z & "        SELECT   " & vbCrLf
        sql_z = sql_z & "          X.EXEC_KBN,  " & vbCrLf
        sql_z = sql_z & "          X.TAIOU_KANSCD,   " & vbCrLf
        sql_z = sql_z & "          MIN(X.TAIOU_KURACD) AS TAIOU_KURACD,  " & vbCrLf
        sql_z = sql_z & "          MIN(X.TAIOU_KENNM)  AS TAIOU_KENNM,  " & vbCrLf
        sql_z = sql_z & "          MIN(X.AUTO_JANM)   AS AUTO_JANM,  " & vbCrLf
        sql_z = sql_z & "          X.AUTO_FAXNO,  " & vbCrLf
        sql_z = sql_z & "          SUM(X.SEND_CNT) AS SEND_CNT,  " & vbCrLf
        sql_z = sql_z & "          SUM(X.SEND_CNT) + SUM(X.NOTSEND_CNT) AS ALL_CNT,  " & vbCrLf
        sql_z = sql_z & "          MIN( X.AUTO_CHOICE)   AS AUTO_CHOICE, " & vbCrLf
        sql_z = sql_z & "          MAX(X.AUTO_ZERO_FLG) AS AUTO_ZERO_FLG " & vbCrLf ' 2014/04/16 T.Watabe add
        sql_z = sql_z & "        FROM  " & vbCrLf
        sql_z = sql_z & "        (  " & vbCrLf
        sql_z = sql_z & "            SELECT   " & vbCrLf
        sql_z = sql_z & "              A.EXEC_KBN,  " & vbCrLf
        sql_z = sql_z & "              A.TAIOU_KANSCD, A.TAIOU_KURACD, A.TAIOU_KENNM, A.TAIOU_JACD, A.TAIOU_ACBCD, A.TAIOU_USER_CD, A.TAIOU_USER_NM,  " & vbCrLf
        sql_z = sql_z & "              DECODE(A.TAIOU_FAXKBN, '2', 1, 0) AS SEND_CNT,   " & vbCrLf
        sql_z = sql_z & "              DECODE(A.TAIOU_FAXKBN, '2', 0, 1) AS NOTSEND_CNT,   " & vbCrLf
        sql_z = sql_z & "              A.AUTO_JANM, " & vbCrLf
        sql_z = sql_z & "              DECODE(A.AUTO_KBN, '2', A.AUTO_MAIL, A.AUTO_FAXNO) AS AUTO_FAXNO,  " & vbCrLf
        sql_z = sql_z & "              A.AUTO_CHOICE,  " & vbCrLf
        sql_z = sql_z & "              NVL(A.AUTO_ZERO_FLG, '0') AS AUTO_ZERO_FLG " & vbCrLf ' 2014/04/16 T.Watabe add
        sql_z = sql_z & "            FROM S06_AUTOFAXTAIDB A  " & vbCrLf
        sql_z = sql_z & "            WHERE 1=1  " & vbCrLf
        sql_z = sql_z & "                AND A.INPUT_YMD = '" & ymdto & "' AND A.LATEST_OF_DAY_FLG = '1' " & vbcrlf
        sql_z = sql_z & "                AND A.TAIOU_KANSCD IN (" & kanscdwhe & ") " & vbcrlf
        sql_z = sql_z & "                AND A.TAIOU_KANSCD IN (" & kanscdlock & ") " & vbcrlf
        sql_z = sql_z & "                AND A.EXEC_KBN IN ('" & sendkbn & "') " & vbcrlf
        sql_z = sql_z & "        ) X  " & vbCrLf
        sql_z = sql_z & "        GROUP BY X.EXEC_KBN, X.TAIOU_KANSCD, X.AUTO_FAXNO " & vbCrLf
        sql_z = sql_z & ") T FULL OUTER JOIN   " & vbCrLf
        sql_z = sql_z & "(  " & vbCrLf
        sql_z = sql_z & "    /* ÇQÅDé¿ç€Ç…ëóÇÈèàóùÇÃÉçÉOåèêîàÍóóÅFäƒéãÉZÉìÉ^Å[ÅÑÇeÇ`Çwî‘çÜ èá */  " & vbCrLf
        sql_z = sql_z & "    SELECT   " & vbCrLf
        sql_z = sql_z & "      B.EXEC_KBN,  " & vbCrLf
        sql_z = sql_z & "      B.TAIOU_KANSCD,   " & vbCrLf
        sql_z = sql_z & "      MAX(B.TAIOU_KURACD) AS TAIOU_KURACD,  " & vbCrLf
        sql_z = sql_z & "      B.AUTO_FAXNO,  " & vbCrLf
        sql_z = sql_z & "      COUNT(*) AS SEND_CNT,  " & vbCrLf
        sql_z = sql_z & "      B.AUTO_ZERO_FLG  " & vbCrLf
        sql_z = sql_z & "    FROM  " & vbCrLf
        sql_z = sql_z & "    (  " & vbCrLf
        sql_z = sql_z & "        SELECT   " & vbCrLf
        sql_z = sql_z & "          A.EXEC_KBN,  " & vbCrLf
        sql_z = sql_z & "          A.TAIOU_KANSCD,   " & vbCrLf
        sql_z = sql_z & "          A.TAIOU_KURACD,  " & vbCrLf
        sql_z = sql_z & "          NVL(A.AUTO_FAXNO, A.AUTO_MAIL) AS AUTO_FAXNO,  " & vbCrLf
        sql_z = sql_z & "          A.AUTO_ZERO_FLG  " & vbCrLf
        sql_z = sql_z & "        FROM  " & vbCrLf
        sql_z = sql_z & "          S05_AUTOFAXLOGDB A  " & vbCrLf
        sql_z = sql_z & "        WHERE  1=1 " & vbCrLf
        sql_z = sql_z & "            AND A.INPUT_YMD = '" & ymdto & "' AND A.LATEST_OF_DAY_FLG = '1' " & vbcrlf
        sql_z = sql_z & "            AND A.TAIOU_KANSCD IN (" & kanscdwhe & ") " & vbcrlf
        sql_z = sql_z & "            AND A.TAIOU_KANSCD IN (" & kanscdlock & ") " & vbcrlf
        sql_z = sql_z & "            AND A.EXEC_KBN IN ('" & sendkbn & "') " & vbcrlf
        sql_z = sql_z & "    ) B  " & vbCrLf
        sql_z = sql_z & "    GROUP BY  " & vbCrLf
        sql_z = sql_z & "      B.EXEC_KBN,  " & vbCrLf
        sql_z = sql_z & "      B.TAIOU_KANSCD,   " & vbCrLf
        sql_z = sql_z & "      B.AUTO_FAXNO,  " & vbCrLf
        sql_z = sql_z & "      B.AUTO_ZERO_FLG  " & vbCrLf
        sql_z = sql_z & ") P  " & vbCrLf
        sql_z = sql_z & "ON " & vbCrLf
        'sql_z = sql_z & "      T.TAIOU_KANSCD     = P.TAIOU_KANSCD  " & vbCrLf
        'sql_z = sql_z & "    AND T.TAIOU_KURACD     = P.TAIOU_KURACD  " & vbCrLf ' ÉNÉâÉCÉAÉìÉgÉRÅ[ÉhÇÕåãçáëŒè€Ç©ÇÁè»Ç≠
        'sql_z = sql_z & "    AND T.AUTO_FAXNO       = P.AUTO_FAXNO  " & vbCrLf
        sql_z = sql_z & "        T.AUTO_FAXNO       = P.AUTO_FAXNO  " & vbCrLf
        sql_z = sql_z & "    AND T.EXEC_KBN         = P.EXEC_KBN  " & vbCrLf
        sql1 = ""
        if(pg = "1")then '1:FAXáÇñàï\é¶
            sql1 = sql1 & "SELECT  " & vbCrLf
            sql1 = sql1 & "        EXEC_KBN, " & vbCrLf
            sql1 = sql1 & "        TAIOU_KANSCD,   " & vbCrLf
            sql1 = sql1 & "        TAIOU_KURACD,   " & vbCrLf
            sql1 = sql1 & "        AUTO_FAXNO,   " & vbCrLf
            sql1 = sql1 & "        AUTO_JANM,   " & vbCrLf
            sql1 = sql1 & "        SEND_CNT,   " & vbCrLf
            sql1 = sql1 & "        ALL_CNT,   " & vbCrLf
            sql1 = sql1 & "        AUTO_ZERO_FLG,   " & vbCrLf
            sql1 = sql1 & "        AUTO_CHOICE,   " & vbCrLf
            sql1 = sql1 & "        LOG_EXEC_KBN, " & vbCrLf
            sql1 = sql1 & "        LOG_KANSCD,    " & vbCrLf
            sql1 = sql1 & "        LOG_KURACD,   " & vbCrLf
            sql1 = sql1 & "        LOG_AUTO_FAXNO,   " & vbCrLf
            sql1 = sql1 & "        LOG_CNT,   " & vbCrLf
            sql1 = sql1 & "        LOG_AUTO_ZERO_FLG,   " & vbCrLf
            sql1 = sql1 & "        COMP   " & vbCrLf
            sql1 = sql1 & "FROM (" & sql_z & ") Z " & vbCrLf
            sql1 = sql1 & "ORDER BY   " & vbCrLf
            sql1 = sql1 & "    Z.EXEC_KBN, Z.TAIOU_KANSCD, Z.AUTO_FAXNO, LOG_AUTO_FAXNO, LOG_KURACD  " & vbCrLf
        else '0:çáî€ämîFâÊñ 
            sql1 = sql1 & "SELECT   " & vbCrLf
            sql1 = sql1 & "    EXEC_KBN,   " & vbCrLf
            sql1 = sql1 & "    SUM(DECODE(COMP,'Çw',1,0)) AS ERR_CNT,    " & vbCrLf
            sql1 = sql1 & "    COUNT(*) AS CNT    " & vbCrLf
            sql1 = sql1 & "FROM ( " & vbCrLf
            sql1 = sql1 & "    SELECT " & vbCrLf
            sql1 = sql1 & "        DECODE(DECODE(EXEC_KBN,NULL,LOG_EXEC_KBN,EXEC_KBN), '1', '1:JA/îÃîÑèä', '2', '2:∏◊≤±›ƒ', '') AS EXEC_KBN,   " & vbCrLf
            sql1 = sql1 & "        COMP " & vbCrLf
            sql1 = sql1 & "FROM (" & sql_z & ") Z " & vbCrLf
            sql1 = sql1 & "    )        " & vbCrLf
            sql1 = sql1 & "GROUP BY     " & vbCrLf
            sql1 = sql1 & "    EXEC_KBN " & vbCrLf
            sql1 = sql1 & "ORDER BY     " & vbCrLf
            sql1 = sql1 & "    EXEC_KBN " & vbCrLf       
        end if
        getCompSQL4FaxNo = sql1
    End Function
</script>
