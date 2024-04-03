<!-- 
'*******************************************************************************
' PG     : autofaxcomp4.aspx
' PG名称 : FAX送信確認(4:送信結果確認)
' 作成日 : 2016/11/14 ZBS T.Ono
'*******************************************************************************
' 更新履歴
' 
!-->
<%@ Page aspcompat=true LANGUAGE="VBScript" CODEPAGE="932"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<!-- #include file ="autofaxcomp4sql.aspx" -->
<script runat="server">
    '定義、宣言'
    private Dim sendkbn As String
    private dim ymdfr as string
    private dim ymdto as string
    private dim kanscd as string 
    private dim kanscdwhe as string 
    private dim kanscdlock as string 
    private Dim faxtype as String
    private Dim faxtype0 as String
    private Dim faxtype1 as String
    private Dim faxtype2 as String
    private Dim faxmatch as String
    private Dim faxmatch0 as String
    private Dim faxmatch1 as String
    private Dim faxmatch2 as String
    private Dim sql1 as String
    private Dim sql2 as String
</script>
<%
    
    'キャッシュをセキュリティー上、利用不可にする。
    Response.Buffer = True
    Response.CacheControl = "no-cache"
    Response.AddHeader("Pragma", "no-cache")
    Response.Expires = -1 
    Response.Cookies("SESSION").Expires = datetime.today.adddays(1)
    
    '不正遷移防止措置
    try
        if request.cookies("SSO_CHECK").value = "OK" then
            response.cookies("SESSION").value = session.sessionID ' 本来のセッションIDに置き換え。
        elseif request.cookies("SESSION").value <> session.sessionID then
            response.redirect("../autofaxcheck.aspx") '認証処理へ
        end if
        if request.cookies("userid").value = "" then 'ユーザIDがない場合は認証処理へ
            response.redirect("../autofaxcheck.aspx")
        elseif request.cookies("CENTCD").value = "" then '監視センターコードがない場合は認証処理へ
            response.redirect("../autofaxcheck.aspx")
        end if
    catch ex as System.NullReferenceException
        response.redirect("../autofaxcheck.aspx") '認証処理へ
    end try
    
    dim dt as datetime
    dim ss as string
    
    ymdfr = ""
    ymdto = ""
    if request("ymd") <> "" then 
        if request("ymd").length <> 8 then
            'エラー
        else
            ss = request("ymd").substring(0,4) & "/" & request("ymd").substring(4,2) & "/" & request("ymd").substring(6,2)
            If DateTime.TryParse(ss, dt) Then
              'ok
              ymdfr = dt.addDays(-1).ToString("yyyyMMdd")
              ymdto = request("ymd")
            else
              'エラー
            end if
        end if
    end if
    if ymdto = "" then
        '未指定、エラーだった時は、本日日付をベースに指定
        ymdfr = DateTime.Today.addDays(-1).ToString("yyyyMMdd")
        ymdto = DateTime.Today.ToString("yyyyMMdd")
    end if
    
    
    if request("kanscd") <> "" then 
        kanscd = request("kanscd")
    else
        '空の場合
        if Request.Cookies("CENTCD").Value = "40000" then
            kanscd = "40000"
        elseif Request.Cookies("CENTCD").Value = "10001" then
            kanscd = "10001"
        else
            kanscd = ""
        end if
    end if
    if kanscd = "40000" then
        kanscdwhe = "'32020','34020','36020'"
    else
        kanscdwhe = "'" & kanscd & "'"
    end if
    
    '種別ラジオボタン
    if request("faxtype") = "1" then
        '自動FAX
        faxtype0 = ""
        faxtype1 = "checked"
        faxtype2 = ""
        faxtype  = "1"
    elseif request("faxtype") = "2" then
        '累積FAX
        faxtype0 = ""
        faxtype1 = ""
        faxtype2 = "checked"
        faxtype  = "2"
    else
        '全て(初期値)
        faxtype0 = "checked"
        faxtype1 = ""
        faxtype2 = ""
        faxtype  = "0"
    end if
    
     '一致ラジオボタン
    if request("faxmatch") = "0" then
        '全て
        faxmatch0 = "checked"
        faxmatch1 = ""
        faxmatch2 = ""
        faxmatch  = "0"
    elseif request("faxmatch") = "1" then
        'OK
        faxmatch0 = ""
        faxmatch1 = "checked"
        faxmatch2 = ""
        faxmatch  = "1"
    else
        'NG(初期値)
        faxmatch0 = ""
        faxmatch1 = ""
        faxmatch2 = "checked"
        faxmatch  = "2"
    end if

    
    '権限に基づく監視センター範囲の情報のみ表示するための規制
    if Request.Cookies("CENTCD").Value = "40000" then
        'kanscdlock = "'32020','34020','36020','10001'"
        kanscdlock = "1" '川口監視センターであることがわかればOKなのでフラグにする。
    elseif Request.Cookies("CENTCD").Value = "10001" then
        kanscdlock = "'10001'"
    else
        kanscdlock = "'ERROR'"
    end if
    '送信区分　1:販売所JA/2:ｸﾗｲｱﾝﾄ
    if request("sendkbn") <> "" then 
        sendkbn = request("sendkbn")
    else
        sendkbn = "1"
    end if
%>
<html>
<head>
    <title>自動FAX(4)</title>
    <meta http-equiv="Content-Type" content="text/html; charset=Shift_JIS">
    <meta http-equiv="Content-Script-Type" content="text/javascript">
    <meta http-equiv="Content-Style-Type" content="text/css">
    <script src="./autofax.js"></script>
    <style>
    body{
        font-family: "MS UI Gothic", "Meiryo UI", "MS Gothic";
        ##font-size:small;
    }
    .tbl{
        border-collapse: collapse; /* 枠線の表示方法 */ 
        border: 1px #1C79C6 solid; /* テーブル全体の枠線（太さ・色・スタイル） */ 
    }
    .tbl td{
        border: 1px #1C79C6 solid; /* セルの枠線（太さ・色・スタイル） */ 
    }
    .comment{
        font-size:small;
        color:purple;
        display: inline-block; _display: inline;
    }
    .trh{}
    .tdh1{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(255,255,255, 0.5)), to(#f9ca9a));
          background: -moz-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: -o-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
        background-color: #f9ca9a;
        text-align: center;
    }
    .tdh2{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(153,255,153, 0.5)), to(#33CC00));
          background: -moz-linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
          background: -o-linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
          background: linear-gradient(top, rgba(153,255,153, 0.5), #33CC00);
        background-color: #33CC00;
        text-align: center;
    }
    .tdh3{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(255,255,255, 0.5)), to(#98f9f9));
          background: -moz-linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
          background: -o-linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
          background: linear-gradient(top, rgba(255,255,255, 0.5), #98f9f9);
        background-color:#98f9f9;
        text-align: center;
    }
    .tdh4{
          background: -webkit-gradient(linear, left top, left bottom, from(rgba(255,255,255, 0.5)), to(#f9ca9a));
          background: -moz-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: -o-linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
          background: linear-gradient(top, rgba(255,255,255, 0.5), #f9ca9a);
        background-color: #f9ca9a;
        text-align: center;
    }
    .tdl0{
        text-align: left;
        background-color: #CCFFCC;
    }
    .tdr0{
        text-align: right;
        background-color: #CCFFCC;
    }
    .tdc0{
        text-align: center;
        background-color: #CCFFCC;
    }
    .tdl1{
        text-align: left;
        background-color: white;
    }
    .tdr1{
        text-align: right;
        background-color: white;
    }
    .tdc1{
        text-align: center;
        background-color: white;
    }
    </style>
</head>
<body>
    <form runat="server">
JA-LP監視CS　FAX送信確認　04
【<%= Request.Cookies("IP").Value %>, 
<%= Request.Cookies("USERNAME").Value %>, 
<%= Request.Cookies("CENTCD").Value %>,
<%= SID %>】
<!-- 
<%= Request.Cookies("userid").Value  %><br>
<%= Request.Cookies("usernm").Value  %><br>
<%= Request.Cookies("PCNAME").Value  %><br>
<%= Request.Cookies("AD_CN").Value  %><br>
<%= Request.Cookies("AUTH_KBN").Value  %><br>
<%= ymdfr %><br>
<%= ymdto  %><br>
<%= kanscd  %><br>
<%= kanscdwhe  %><br>
-->
&nbsp;&nbsp;
<a href="./autofaxcomp0.aspx" target="_blank">(0:全体確認)</a>
<a href="./autofaxcomp1.aspx" target="_blank">(1:送信先毎)</a>
<a href="./autofaxcomp2.aspx" target="_blank">(2:明細)</a>
<a href="./autofaxmakedat.aspx" target="_blank">(3:データ作成)</a>
(4:送信結果確認)
<a href="./autofaxcomp.pdf" target="_blank"><img src="./icon_pdf.gif" border="0" alt="説明資料" title="説明資料"></a>
<a href="./autofaxcomp.xls" target="_blank"><img src="./icon_xls.gif" border="0" alt="説明資料" title="説明資料"></a>
<hr>
&nbsp;監視ｾﾝﾀｰ：<SELECT name="kanscd">
<%
dim wk as string
if Request.Cookies("CENTCD").Value = "40000" then
    if kanscd = "40000" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='40000'" & wk & ">40000:３監視全て</option>")
    if kanscd = "32020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='32020'" & wk & ">32020</option>")
    if kanscd = "34020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='34020'" & wk & ">34020</option>")
    if kanscd = "36020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='36020'" & wk & ">36020</option>")
elseif Request.Cookies("CENTCD").Value = "10001" then
    Response.Write("<option value='10001' SELECTED>10001:沖縄</option>")
else
end if
%>
</SELECT>
&nbsp;送信日：<input type="text" name="ymd" value="<%= ymdto %>" size="10" maxlength="8" onKeyDown="fncEasyDateChg(this,'d');" autocomplete="off">
(種別：
<input type="radio" name="faxtype" value="0" <%= faxtype0 %> />全て&nbsp;
<input type="radio" name="faxtype" value="1" <%= faxtype1 %> />自動FAX&nbsp;
<input type="radio" name="faxtype" value="2" <%= faxtype2 %> />累積FAX
(空白は常に表示))&nbsp;
(一致：
<input type="radio" name="faxmatch" value="0" <%= faxmatch0 %> />全て&nbsp;
<input type="radio" name="faxmatch" value="1" <%= faxmatch1 %> />OK&nbsp;
<input type="radio" name="faxmatch" value="2" <%= faxmatch2 %> />NG
)&nbsp;


<input type="submit" value="検索" name="btnSearch">
<hr>
<%
    'SQL取得 送信結果確認専用[autofaxcomp4sql.aspx]
    sql2 = getcount(ymdto)
    
    Dim ADO_Cnn2
    Dim ADO_Rst2
    Dim i2 as integer
    Dim f2 as integer
    
    'DEBUG用
    'Response.Write("faxtypeL=[" & ymdto & ":" & kanscdwhe & ":" & kanscdlock & ":" & sendkbn & ":" & faxtype & ":" & faxmatch & "]")
    'Response.Write("SQL=[" & sql1 & "]")
    'Response.End


    ADO_Cnn2 = server.CreateObject("ADODB.Connection")
    ADO_Rst2 = server.CreateObject("ADODB.Recordset")
    'ADO_Cnn2.open("Driver={Microsoft ODBC for Oracle};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    'ADO_Cnn2.open("Driver={Oracle in OraDB12Home1};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Cnn2.open("Driver={Oracle in OraDB12Home1};DBQ=" & SID & "; UID=KANSHI; PWD=KANSHI0;")

    ADO_Rst2 = ADO_Cnn2.Execute(sql2)

    i2 = 0
    Response.Write("<table class='tbl'>")
    Response.Write("<tr class='trh'>")
    Response.Write("<td class='tdh1'>種別</td>")
    Response.Write("<td class='tdh3'>FAX実行結果</td>")
    Response.Write("<td class='tdh2'>FAX送信ログ<br>（取消含む）</td>")
    Response.Write("<td class='tdh4'>一致</td>")
    Response.Write("</tr>")

    
    Dim cnt2 as integer
    cnt2 = 0
    Do Until ADO_Rst2.EOF = True
        i2 = i2 + 1
        cnt2 = cnt2 + 1
        f2 = i2 mod 2
        if ADO_Rst2.Fields("RES").Value = "○" then wk = " style='background-color:#98f9f9;'" else wk = " style='background-color:pink;'"
        Response.Write("<tr>" & vbcrlf)
        Response.Write("<td class='tdr" & f2 & "'>" & ADO_Rst2.Fields("FAX_TYPE").Value                                            & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f2 & "'>" & ADO_Rst2.Fields("AUTO_FAXCNT").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f2 & "'>" & ADO_Rst2.Fields("FAXLOGCONT").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f2 & "'" & wk & ">" & ADO_Rst2.Fields("RES").Value              & "</td>" & vbcrlf)
        Response.Write("</tr>" & vbcrlf)
        ADO_Rst2.MoveNext
    Loop
    
    Response.Write("</table>")
    
    
    if cnt2 <= 0 then
        Response.Write("<br>該当データがありません。<br><br>")
    end if
    
    ADO_Rst2.Close                    'オブジェクト開放
    ADO_Cnn2.Close                    'オブジェクト開放
    ADO_Rst2 = Nothing                 'オブジェクト開放
    ADO_Cnn2 = Nothing                'オブジェクト開放
    
    Response.Write("<!-- " & sql2 & " -->")
%>
【備考】<br>
※累積情報自動FAX、自動FAXを実行して生成した送信件数とFAX送信ログの送信件数比較。<br>
　一致しない場合、累積・自動FAXを実行したが送信されていない。または、システムを実行していないが送信された可能性がある。<br>
※上記、「監視ｾﾝﾀｰ」「種別」「一致」の絞り込み条件は適用されない。
<hr>
<%
    'SQL取得 送信結果確認専用[autofaxcomp4sql.aspx]
    sql1 = getlist(ymdto, kanscdwhe, kanscdlock, sendkbn, faxtype, faxmatch)
    
    Dim ADO_Cnn
    Dim ADO_Rst
    Dim i as integer
    Dim f as integer
    
    'DEBUG用
    'Response.Write("faxtypeL=[" & ymdto & ":" & kanscdwhe & ":" & kanscdlock & ":" & sendkbn & ":" & faxtype & ":" & faxmatch & "]")
    'Response.Write("SQL=[" & sql1 & "]")
    'Response.End


    ADO_Cnn = server.CreateObject("ADODB.Connection")
    ADO_Rst = server.CreateObject("ADODB.Recordset")
    'ADO_Cnn.open("Driver={Microsoft ODBC for Oracle};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    'ADO_Cnn.open("Driver={Oracle in OraDB12Home1};CONNECTSTRING=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Cnn.open("Driver={Oracle in OraDB12Home1};DBQ=" & SID & "; UID=KANSHI; PWD=KANSHI0;")
    ADO_Rst = ADO_Cnn.Execute(sql1)

    i = 0
    Response.Write("<table class='tbl'>")
    Response.Write("<tr class='trh'>")
    Response.Write("<td rowspan=2 class='tdh1'>№</td>")
    Response.Write("<td colspan=6 class='tdh3'>FAX実行結果</td>")
    Response.Write("<td rowspan=2 class='tdh4'>一致</td>")
    Response.Write("<td colspan=5 class='tdh2'>FAX送信ログ</td>")
    Response.Write("</tr>")
    Response.Write("<tr>")
    Response.Write("<td class='tdh3'>種別</td>")
    Response.Write("<td class='tdh3'>ｾﾝﾀｰ</td>")
    Response.Write("<td class='tdh3'>ｸﾗ</td>")
    Response.Write("<td class='tdh3'>FAX番号</td>")
    Response.Write("<td class='tdh3'>件数</td>")
    Response.Write("<td class='tdh3'>0件<br>送信</td>")
    Response.Write("<td class='tdh2'>ステータス</td>")
    Response.Write("<td class='tdh2'>日時</td>")
    Response.Write("<td class='tdh2'>FAX番号</td>")
    Response.Write("<td class='tdh2'>枚数</td>")
    Response.Write("<td class='tdh2'>タイトル</td>")
    Response.Write("</tr>")
    
    Dim cnt as integer
    cnt = 0
    Do Until ADO_Rst.EOF = True
        i = i + 1
        cnt = cnt + 1
        f = i mod 2
        if ADO_Rst.Fields("RES").Value = "○" then wk = " style='background-color:#98f9f9;'" else wk = " style='background-color:pink;'"
        Response.Write("<tr>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & i                                            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("FAXTYPE").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("KANSCD").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("KURACD").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("AUTO_FAXNO").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("PAGE").Value              & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("ZERO_FLG").Value               & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'" & wk & ">" & ADO_Rst.Fields("RES").Value              & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("STATUS").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("STARTTIME").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("RECIPIENTFAXNUMBER").Value    & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("TOTALPAGES").Value           & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("DOCUMENT").Value & "</td>" & vbcrlf)
        Response.Write("</tr>" & vbcrlf)
        ADO_Rst.MoveNext
    Loop
    Response.Write("</table>")
    
    if cnt <= 0 then
        Response.Write("<br>該当データがありません。<br><br>")
    end if
    
    ADO_Rst.Close                    'オブジェクト開放
    ADO_Cnn.Close                    'オブジェクト開放
    ADO_Rst = Nothing                 'オブジェクト開放
    ADO_Cnn = Nothing                'オブジェクト開放
    
    Response.Write("<!-- " & sql1 & " -->")
    
%>
<hr>
【備考】<br>
※FAX実行結果・・・累積情報自動FAX、自動FAXを実行してファイルを生成する際にDBへ出力されるログを基に、FAX番号で集計した一覧。自動FAXデバッグモードで実行した結果は含まない。<br>
※FAX送信ログ・・・FAXサーバー(141)のFAX送信ログ(OutBoxLog.txt)をDBに取込み表示したもの。<br>
※一致・・・種別“自ｸﾗ”“自JA”は電話番号と件数が一致しているか判定。種別：累は電話番号の一致、ステータス“完了”であるか判定。（○:一致/×:不一致）<br>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>
