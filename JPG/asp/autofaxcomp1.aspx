<!-- 
'*******************************************************************************
' PG     : autofaxcomp.aspx
' PG名称 : 自動FAX送信前確認(送信先毎)
' 作成日 : 2014/01/01 ZBS T.Watabe
'*******************************************************************************
' 更新履歴
' 2014/04/16 T.Watabe ゼロ件送信フラグの比較チェックも付け加える。
' 2016/03/02 T.Ono    2015改善開発 参照マスタ変更のため、備考などの文言変更
' 2016/11/14 T.Ono 送信済み確認画面の追加。監視ｾﾝﾀｰの10001を削除。
!-->
<%@ Page aspcompat=true LANGUAGE="VBScript" CODEPAGE="932"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<!-- #include file ="autofaxcommon.aspx" -->
<script runat="server">
    '定義、宣言'
    private Dim sendkbn As String
    private dim ymdfr as string
    private dim ymdto as string
    private dim kanscd as string 
    private dim kanscdwhe as string 
    private dim kanscdlock as string 
    private Dim sql1 as String
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
    
    '権限に基づく監視センター範囲の情報のみ表示するための規制
    if Request.Cookies("CENTCD").Value = "40000" then
        kanscdlock = "'32020','34020','36020','10001'"
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
    <title>自動FAX(1)</title>
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
<!-- JA-LP監視CS　自動FAX送信前確認　01 -->
JA-LP監視CS　FAX送信確認　01
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
(1:送信先毎)
<a href="./autofaxcomp2.aspx" target="_blank">(2:明細)</a>
<a href="./autofaxmakedat.aspx" target="_blank">(3:データ作成)</a>
<a href="./autofaxcomp4.aspx" target="_blank">(4:送信結果確認)</a>
<a href="./autofaxcomp.pdf" target="_blank"><img src="./icon_pdf.gif" border="0" alt="説明資料" title="説明資料"></a>
<a href="./autofaxcomp.xls" target="_blank"><img src="./icon_xls.gif" border="0" alt="説明資料" title="説明資料"></a>
<hr>
&nbsp;送信単位：<SELECT name="sendkbn">
<%
dim wk as string
    if sendkbn = "1" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='1'" & wk & ">1:JA/販売所</option>")
    if sendkbn = "2" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='2'" & wk & ">2:ｸﾗｲｱﾝﾄ</option>")
%>
</SELECT>
&nbsp;監視ｾﾝﾀｰ：<SELECT name="kanscd">
<%
if Request.Cookies("CENTCD").Value = "40000" then
    if kanscd = "40000" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='40000'" & wk & ">40000:３監視全て</option>")
    if kanscd = "32020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='32020'" & wk & ">32020</option>")
    if kanscd = "34020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='34020'" & wk & ">34020</option>")
    if kanscd = "36020" then wk = "SELECTED" else wk = ""
    Response.Write("<option value='36020'" & wk & ">36020</option>")
    '2016/12/21 T.Ono del 2016改善開発 №12 沖縄は表示しないようにする。
    '(そのほかの10001で入ってきたときの分岐はそのままにしておく)
    'Response.Write("<option value=''" & wk & ">--------</option>")
    'if kanscd = "10001" then wk = "SELECTED" else wk = ""
    'Response.Write("<option value='10001'" & wk & ">10001:沖縄</option>")
elseif Request.Cookies("CENTCD").Value = "10001" then
    Response.Write("<option value='10001' SELECTED>10001:沖縄</option>")
else
end if
%>
</SELECT>
&nbsp;対象日：<input type="text" name="ymd" value="<%= ymdto %>" size="10" maxlength="8" onKeyDown="fncEasyDateChg(this,'d');" autocomplete="off">
<input type="submit" value="検索" name="btnSearch">
<hr>
<%
    'SQL取得 共通定義[autofaxcommon.aspx]
    sql1 = getCompSQL4FaxNo("1", ymdto, kanscdwhe, kanscdlock, sendkbn)
    
    Dim ADO_Cnn
    Dim ADO_Rst
    Dim i as integer
    Dim f as integer
    
    'DEBUG用
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
    Response.Write("<td colspan=8 class='tdh2'>送信対象リスト</td>")
    Response.Write("<td rowspan=2 class='tdh4'>一致</td>")
    Response.Write("<td colspan=5 class='tdh3'>自動FAX実行結果</td>")
    Response.Write("</tr>")
    Response.Write("<tr>")
    'Response.Write("<td class='tdh1'>№</td>")
    Response.Write("<td class='tdh2'>ｾﾝﾀｰ</td>")
    Response.Write("<td class='tdh2'>ｸﾗ</td>")
    Response.Write("<td class='tdh2'>FAX/ﾒｰﾙ</td>")
    'Response.Write("<td class='tdh2'>送信先JA名(FAX番号からﾏｽﾀに該当した名称)</td>") 2016/02/24 T.Ono mod 2015改善開発
    Response.Write("<td class='tdh2'>自動FAX送信名(FAX番号からﾏｽﾀに該当した名称)</td>")
    Response.Write("<td class='tdh2'>件<br>数</td>")
    Response.Write("<td class='tdh2'>総<br>数</td>")
    Response.Write("<td class='tdh2'>0件<br>送信</td>") ' 2014/04/16 T.Watabe add
    Response.Write("<td class='tdh2'>該当ﾏｽﾀ</td>")
    Response.Write("<td class='tdh3'>ｾﾝﾀｰ</td>")
    Response.Write("<td class='tdh3'>ｸﾗ</td>")
    Response.Write("<td class='tdh3'>FAX/ﾒｰﾙ</td>")
    Response.Write("<td class='tdh3'>件<br>数</td>")
    Response.Write("<td class='tdh3'>0件<br>送信</td>")
    'Response.Write("<td class='tdh4'>一致</td>")
    Response.Write("</tr>")
    
    Dim cnt as integer
    cnt = 0
    Do Until ADO_Rst.EOF = True
        i = i + 1
        cnt = cnt + 1
        f = i mod 2
        if ADO_Rst.Fields("COMP").Value = "○" then wk = " style='background-color:#98f9f9;'" else wk = " style='background-color:pink;'"
        Response.Write("<tr>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & i                                            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("TAIOU_KANSCD").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("TAIOU_KURACD").Value            & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("AUTO_FAXNO").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("AUTO_JANM").Value              & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("SEND_CNT").Value               & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("ALL_CNT").Value               & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'>" & ADO_Rst.Fields("AUTO_ZERO_FLG").Value & "</td>" & vbcrlf) ' 2014/04/16 T.Watabe add
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("AUTO_CHOICE").Value       & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'" & wk & ">" & ADO_Rst.Fields("COMP").Value              & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("LOG_KANSCD").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("LOG_KURACD").Value        & "</td>" & vbcrlf)
        Response.Write("<td class='tdl" & f & "'>" & ADO_Rst.Fields("LOG_AUTO_FAXNO").Value    & "</td>" & vbcrlf)
        Response.Write("<td class='tdr" & f & "'>" & ADO_Rst.Fields("LOG_CNT").Value           & "</td>" & vbcrlf)
        Response.Write("<td class='tdc" & f & "'>" & ADO_Rst.Fields("LOG_AUTO_ZERO_FLG").Value & "</td>" & vbcrlf)
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
<div class='comment'>前日AM5:00から指定日AM5:00まで</div><br>
<!-- 2016/03/02 T.Ono mod 2015改善開発 
※送信対象リスト・・・前日am5:00から指定日am5:00までの24Hの対応データを基に、JA担当者ﾏｽﾀを参照して割り出した送信先一覧。ゼロ件送信については、JA担当者ﾏｽﾀを基にする必要があるため含めていません。
※自動FAX実行結果・・・実際に自動FAXを実行してﾌｧｲﾙを生成する際にDBへ出力されるログを基に、FAX番号で集約した一覧。デバッグモードで実行することにより、送信せずにログ出力可能。<br>
※該当ﾏｽﾀ・・・JA担当者ﾏｽﾀ登録したうちで該当したレベルを表示 （1:顧客指定/2:顧客範囲/3:JA支所/4:JA）<br>
※送信先名・・・一覧になったFAX番号からJA担当者ﾏｽﾀを再度引きなおして表示したもの。同一FAX番号で違う名称を登録してしまった場合は、想定どおり表示されない場合があります。<br>
※一致・・・電話番号と件数が一致しているか判定。ゼロ件送信の場合のみ送信対象リストは存在せず。（○:一致/×:不一致）<br> -->
※送信対象リスト・・・前日am5:00から指定日am5:00までの24Hの対応データを基に、JA担当者・報告先・注意事項ﾏｽﾀを参照して割り出した送信先一覧。<br>
※自動FAX実行結果・・・実際に自動FAXを実行してﾌｧｲﾙを生成する際にDBへ出力されるログを基に、FAX番号で集約した一覧。デバッグモードで実行することにより、送信せずにログ出力可能。<br>
※該当ﾏｽﾀ・・・JA担当者・報告先・注意事項ﾏｽﾀ登録したうちで該当したレベルを表示 （1:顧客指定/2:顧客範囲/3:JA支所）<br>
※自動FAX送信名・・・一覧になったFAX番号からJA担当者・報告先・注意事項ﾏｽﾀを再度引きなおして表示したもの。同一FAX番号で違う名称を登録してしまった場合は、想定どおり表示されない場合があります。<br>
※一致・・・電話番号と件数が一致しているか判定。（○:一致/×:不一致）<br>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>
