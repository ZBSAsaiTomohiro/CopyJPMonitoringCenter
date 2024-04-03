<script runat="server">
    private const SID = "KANSIKAI"
    ''private const SID = "KANSIHON"
    ''private const SID = "NKANSIHON"
</script>
<script runat="server">
    Function getcount(ymdto)
        Dim sql2
                
        if(kanscdlock <> "1") Then
            sql2 = ""
            
            ''sql2 = sql2 & "SELECT  " & vbCrLf
	        ''sql2 = sql2 & "  "" AS AUTO_FAXCNT " & vbCrLf
	        ''sql2 = sql2 & "  ,"" AS FAXLOGCONT " & vbCrLf
	        ''sql2 = sql2 & "  ,"" AS RES " & vbCrLf
            ''sql2 = sql2 & "FROM DUAL " & vbCrLf
            ''sql2 = sql2 & "WHERE 1=0 " & vbCrLf
            
            
            sql2 = sql2 & "SELECT  " & vbCrLf
	        sql2 = sql2 & "  "" AS FAX_TYPE " & vbCrLf
	        sql2 = sql2 & "  ,"" AS AUTO_FAXCNT " & vbCrLf
	        sql2 = sql2 & "  ,"" AS FAXLOGCONT " & vbCrLf
	        sql2 = sql2 & "  ,"" AS RES " & vbCrLf
            sql2 = sql2 & "FROM DUAL " & vbCrLf
            sql2 = sql2 & "WHERE 1=0 " & vbCrLf
            
            return sql2
        end if
        
        
        sql2 = ""
        
        sql2 = sql2 & "SELECT " & vbCrLf
        sql2 = sql2 & "  DECODE(NVL(D.EXEC_KBN, F.EXEC_KBN), '0', '累積', '1', '自動', '他') AS FAX_TYPE " & vbCrLf
        sql2 = sql2 & "  ,D.AUTO_FAXCNT " & vbCrLf
        sql2 = sql2 & "  ,F.FAXLOGCONT " & vbCrLf
        sql2 = sql2 & "  ,DECODE(D.AUTO_FAXCNT, F.FAXLOGCONT, '○','×') AS RES " & vbCrLf
        sql2 = sql2 & "FROM " & vbCrLf
        sql2 = sql2 & "  (SELECT " & vbCrLf
        sql2 = sql2 & "    COUNT(C.AUTO_FAXNO) AS AUTO_FAXCNT " & vbCrLf
        sql2 = sql2 & "    ,C.EXEC_KBN " & vbCrLf
        sql2 = sql2 & "  FROM " & vbCrLf
        sql2 = sql2 & "    (SELECT " & vbCrLf
        sql2 = sql2 & "      B.AUTO_FAXNO " & vbCrLf
        sql2 = sql2 & "      ,B.EXEC_KBN " & vbCrLf
        sql2 = sql2 & "    FROM " & vbCrLf
        sql2 = sql2 & "      (SELECT  " & vbCrLf
        sql2 = sql2 & "        DECODE(A.EXEC_KBN, '2', '1', A.EXEC_KBN) AS EXEC_KBN " & vbCrLf
        sql2 = sql2 & "        ,A.GUID " & vbCrLf
        sql2 = sql2 & "        ,A.TAIOU_KANSCD " & vbCrLf
        sql2 = sql2 & "        ,A.TAIOU_KURACD " & vbCrLf
        sql2 = sql2 & "        ,A.AUTO_FAXNO " & vbCrLf
        sql2 = sql2 & "        ,A.AUTO_ZERO_FLG " & vbCrLf
        sql2 = sql2 & "      FROM " & vbCrLf
        sql2 = sql2 & "        S05_AUTOFAXLOGDB A " & vbCrLf
        sql2 = sql2 & "      WHERE  1=1 " & vbCrLf
        sql2 = sql2 & "      AND A.EXEC_YMD = '" & ymdto & "'" & vbCrLf
        sql2 = sql2 & "      AND A.DEBUGFLG = '0' " & vbCrLf
        sql2 = sql2 & "      AND A.AUTO_KBN = '1' " & vbCrLf
        sql2 = sql2 & "      AND A.EXEC_KBN IN ('1', '2', '0') " & vbCrLf
        sql2 = sql2 & "      ) B " & vbCrLf
        sql2 = sql2 & "    GROUP BY " & vbCrLf
        sql2 = sql2 & "      B.EXEC_KBN " & vbCrLf
        sql2 = sql2 & "      ,B.GUID " & vbCrLf
        sql2 = sql2 & "      ,B.TAIOU_KANSCD " & vbCrLf
        sql2 = sql2 & "      ,B.AUTO_FAXNO " & vbCrLf
        sql2 = sql2 & "      ,B.AUTO_ZERO_FLG " & vbCrLf
        sql2 = sql2 & "      ,B.EXEC_KBN " & vbCrLf
        sql2 = sql2 & "    )C " & vbCrLf
        sql2 = sql2 & "    GROUP BY C.EXEC_KBN " & vbCrLf
        sql2 = sql2 & "  )D " & vbCrLf
        sql2 = sql2 & "  FULL OUTER JOIN " & vbCrLf
        sql2 = sql2 & "  (SELECT " & vbCrLf
        sql2 = sql2 & "    COUNT(E.JOBID) AS FAXLOGCONT " & vbCrLf
        sql2 = sql2 & "    ,DECODE(DOCUMENT, '監視センター対応内容明細', '1', '監視センター対応内容明細(累積)', '0', '4') AS EXEC_KBN " & vbCrLf
        sql2 = sql2 & "  FROM " & vbCrLf
        sql2 = sql2 & "    S07_FAXOUTBOXLOG E " & vbCrLf
        sql2 = sql2 & "  WHERE 1=1 " & vbCrLf
        sql2 = sql2 & "  AND E.SUBMISSIONYMD = '" & ymdto & "'" & vbCrLf
        sql2 = sql2 & "  AND E.DEBUGNO = '0'" & vbCrLf
        sql2 = sql2 & "  GROUP BY DOCUMENT " & vbCrLf
        sql2 = sql2 & "  )F " & vbCrLf
        sql2 = sql2 & "  ON D.EXEC_KBN = F.EXEC_KBN " & vbCrLf
        
        
        
        getcount = sql2
    End Function

    Function getlist(ymdto, kanscdwhe, kanscdlock, sendkbn, faxtype, faxmatch)
        Dim sql1
                
        if(kanscdlock <> "1") Then
            sql1 = ""
            sql1 = sql1 & "SELECT  " & vbCrLf
            sql1 = sql1 & "       '' AS EXEC_KBN " & vbCrLf
            sql1 = sql1 & "       ,'' AS FAXTYPE " & vbCrLf
            sql1 = sql1 & "       ,'' AS KANSCD " & vbCrLf
            sql1 = sql1 & "       ,'' AS KURACD " & vbCrLf
            sql1 = sql1 & "       ,'' AS EXEC_YMD  " & vbCrLf
            sql1 = sql1 & "       ,'' AS EXEC_TIME  " & vbCrLf
            sql1 = sql1 & "       ,'' AS AUTO_FAXNO  " & vbCrLf
            sql1 = sql1 & "       ,'' AS PAGE  " & vbCrLf
            sql1 = sql1 & "       ,'' AS ZERO_FLG  " & vbCrLf
            sql1 = sql1 & "       ,'' AS RES  " & vbCrLf
            sql1 = sql1 & "       ,'' AS STATUS  " & vbCrLf
            sql1 = sql1 & "       ,'' AS STARTTIME  " & vbCrLf
            sql1 = sql1 & "       ,'' AS RECIPIENTFAXNUMBER  " & vbCrLf
            sql1 = sql1 & "       ,'' AS TOTALPAGES " & vbCrLf
            sql1 = sql1 & "       ,'' AS DOCUMENT  " & vbCrLf
            sql1 = sql1 & "FROM DUAL " & vbCrLf
            sql1 = sql1 & "WHERE 1=0 " & vbCrLf
            return sql1
        end if
        
        
        sql1 = ""
        sql1 = sql1 & "SELECT " & vbCrLf
        sql1 = sql1 & "       DECODE(A.EXEC_KBN, '1', '2', '2', '1', '0', '3', '4') AS SORTNO " & vbCrLf
        sql1 = sql1 & "       ,DECODE(A.EXEC_KBN, '1', '自JA', '2', '自ｸﾗ', '0', '累', '') AS FAXTYPE " & vbCrLf
        sql1 = sql1 & "       ,A.KANSCD " & vbCrLf
        sql1 = sql1 & "       ,A.KURACD " & vbCrLf
        sql1 = sql1 & "       ,A.EXEC_YMD " & vbCr
        sql1 = sql1 & "       ,A.EXEC_TIME " & vbCrLf
        sql1 = sql1 & "       ,A.AUTO_FAXNO " & vbCrLf
        sql1 = sql1 & "       ,A.PAGE " & vbCrLf
        sql1 = sql1 & "       ,A.ZERO_FLG " & vbCrLf
        sql1 = sql1 & "       ,DECODE(A.EXEC_KBN, '0' " & vbCrLf
        sql1 = sql1 & "                  ,DECODE(B.STATUS, '完了', DECODE(A.AUTO_FAXNO, B.RECIPIENTFAXNUMBER,'○','×'), '×') " & vbCrLf
        sql1 = sql1 & "                  ,DECODE(A.AUTO_FAXNO || A.PAGE, B.RECIPIENTFAXNUMBER || B.PAGES ,'○','×')) AS RES  " & vbCrLf
        sql1 = sql1 & "       ,B.STATUS " & vbCrLf
        sql1 = sql1 & "       ,TO_DATE(B.STARTTIME, 'YYYYMMDDHH24MISS') AS STARTTIME " & vbCrLf
        sql1 = sql1 & "       ,B.RECIPIENTFAXNUMBER " & vbCrLf
        sql1 = sql1 & "       ,B.TOTALPAGES " & vbCrLf
        sql1 = sql1 & "       ,B.DOCUMENT " & vbCrLf
        sql1 = sql1 & "FROM " & vbCrLf
        sql1 = sql1 & "     (SELECT * " & vbCrLf
        sql1 = sql1 & "      FROM S07_FAXOUTBOXLOG Y " & vbCrLf
        sql1 = sql1 & "      WHERE Y.SUBMISSIONYMD = '" & ymdto & "'" & vbCrLf
        sql1 = sql1 & "      AND   Y.DEBUGNO = '0'" & vbCrLf
        sql1 = sql1 & "      AND   Y.DOCUMENT LIKE '監視センター対応内容明細%' " & vbCrLf
        sql1 = sql1 & "     ) B FULL OUTER JOIN " & vbCrLf
        sql1 = sql1 & "     (SELECT " & vbCrLf
        sql1 = sql1 & "             Z.EXEC_KBN " & vbCrLf
        sql1 = sql1 & "             ,MIN(Z.TAIOU_KANSCD) AS KANSCD " & vbCrLf
        sql1 = sql1 & "             ,MIN(Z.TAIOU_KURACD) AS KURACD " & vbCrLf
        sql1 = sql1 & "             ,Z.EXEC_YMD " & vbCrLf
        sql1 = sql1 & "             ,MAX(Z.EXEC_TIME) AS EXEC_TIME " & vbCrLf
        sql1 = sql1 & "             ,Z.AUTO_FAXNO " & vbCrLf
        sql1 = sql1 & "             ,SUBSTR(COUNT(*),0,3) AS PAGE " & vbCrLf
        sql1 = sql1 & "             ,MAX(AUTO_ZERO_FLG) AS ZERO_FLG " & vbCrLf
        sql1 = sql1 & "      FROM   S05_AUTOFAXLOGDB Z " & vbCrLf
        sql1 = sql1 & "      WHERE  Z.EXEC_YMD = '" & ymdto & "'" & vbCrLf
        sql1 = sql1 & "      AND    Z.AUTO_KBN = '1' " & vbCrLf
        sql1 = sql1 & "      AND    Z.DEBUGFLG = '0' " & vbCrLf
        sql1 = sql1 & "      GROUP BY Z.EXEC_YMD, Z.AUTO_FAXNO, Z.EXEC_KBN, Z.GUID " & vbCrLf
        sql1 = sql1 & "     ) A " & vbCrLf
        sql1 = sql1 & "     ON  B.RECIPIENTFAXNUMBER = A.AUTO_FAXNO " & vbCrLf
        sql1 = sql1 & "WHERE 1=1 " & vbCrLf


''監視ｾﾝﾀｰ
''        sql1 = sql1 & "AND   (A.KANSCD = '32020' OR A.KANSCD IS NULL) " & vbCrLf 

        ''種別 faxtype 0:全て 1:自動FAX 2:累積FAX
        if(faxtype = "1") Then
            sql1 = sql1 & "AND   (A.EXEC_KBN IN ('1','2') OR A.EXEC_KBN IS NULL) " & vbCrLf
        elseif (faxtype = "2") Then
            sql1 = sql1 & "AND   (A.EXEC_KBN = '0' OR A.EXEC_KBN IS NULL) " & vbCrLf
        end if

        ''一致 faxmatch 0:全て 1:OK 2:NG
        if(faxmatch = "1") Then
             sql1 = sql1 & "AND  DECODE(A.EXEC_KBN, '0' " & vbCrLf
             sql1 = sql1 & "                  ,DECODE(B.STATUS, '完了', DECODE(A.AUTO_FAXNO, B.RECIPIENTFAXNUMBER,'○','×'), '×') " & vbCrLf
             sql1 = sql1 & "                  ,DECODE(A.AUTO_FAXNO || A.PAGE, B.RECIPIENTFAXNUMBER || B.PAGES ,'○','×')) = '○'  " & vbCrLf
        elseif (faxmatch = "2") Then
             sql1 = sql1 & "AND  DECODE(A.EXEC_KBN, '0' " & vbCrLf
             sql1 = sql1 & "                  ,DECODE(B.STATUS, '完了', DECODE(A.AUTO_FAXNO, B.RECIPIENTFAXNUMBER,'○','×'), '×') " & vbCrLf
             sql1 = sql1 & "                  ,DECODE(A.AUTO_FAXNO || A.PAGE, B.RECIPIENTFAXNUMBER || B.PAGES ,'○','×')) = '×'  " & vbCrLf
        end if

        ''FAXサーバーログ、報告FAX以外のログを抽出
        if(faxmatch <> "1") then
            ''○のみ表示の場合は不要
            sql1 = sql1 & "UNION ALL " & vbCrLf
            sql1 = sql1 & "SELECT  " & vbCrLf
            sql1 = sql1 & "       '4' AS SORTNO " & vbCrLf
            sql1 = sql1 & "       ,'' AS FAXTYPE " & vbCrLf
            sql1 = sql1 & "       ,'' AS KANSCD " & vbCrLf
            sql1 = sql1 & "       ,'' AS KURACD " & vbCrLf
            sql1 = sql1 & "       ,'' AS EXEC_YMD  " & vbCrLf
            sql1 = sql1 & "       ,'' AS EXEC_TIME  " & vbCrLf
            sql1 = sql1 & "       ,'' AS AUTO_FAXNO  " & vbCrLf
            sql1 = sql1 & "       ,'' AS PAGE  " & vbCrLf
            sql1 = sql1 & "       ,'' AS ZERO_FLG  " & vbCrLf
            sql1 = sql1 & "       ,'×' AS RES  " & vbCrLf
            sql1 = sql1 & "       ,B.STATUS  " & vbCrLf
            sql1 = sql1 & "       ,TO_DATE(B.STARTTIME, 'YYYYMMDDHH24MISS') AS STARTTIME  " & vbCrLf
            sql1 = sql1 & "       ,B.RECIPIENTFAXNUMBER  " & vbCrLf
            sql1 = sql1 & "       ,B.TOTALPAGES " & vbCrLf
            sql1 = sql1 & "       ,B.DOCUMENT  " & vbCrLf
            sql1 = sql1 & "FROM   S07_FAXOUTBOXLOG B " & vbCrLf
            sql1 = sql1 & "WHERE  NOT EXISTS " & vbCrLf
            sql1 = sql1 & "       (SELECT 'X' " & vbCrLf
            sql1 = sql1 & "        FROM   S07_FAXOUTBOXLOG A " & vbCrLf
            sql1 = sql1 & "        WHERE  A.JOBID = B.JOBID " & vbCrLf
            sql1 = sql1 & "        AND    A.SUBMISSIONTIME = B.SUBMISSIONTIME " & vbCrLf
            sql1 = sql1 & "        AND    A.SUBMISSIONYMD = '" & ymdto & "' " & vbCrLf
            sql1 = sql1 & "        AND    A.DEBUGNO = '0' " & vbCrLf
            sql1 = sql1 & "        AND    A.DOCUMENT LIKE '監視センター対応内容明細%' " & vbCrLf
            sql1 = sql1 & "       ) " & vbCrLf
            sql1 = sql1 & "AND    B.SUBMISSIONYMD = '" & ymdto & "' " & vbCrLf
            sql1 = sql1 & "AND    B.DEBUGNO = '0' " & vbCrLf
        end if
        
        sql1 = sql1 & "ORDER BY SORTNO, KANSCD, KURACD, STARTTIME " & vbCrLf        
        
        getlist = sql1
    End Function
</script>
