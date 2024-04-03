<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<html>
<head>
    <title>監視システム</title>
    <script runat="server">
        void Page_Load(object sender, EventArgs e) {
            
            Boolean bSSO = false;
            String sCENTCD = "";
            String sUSERID = "";
            String sUSERNM = "";
            String sADCN = "";
            String tmp = "";
            String sIP = "";
            String sPCName = "";
            String sAUTH = "0"; // 権限
            
            // AD権限定数
            String AD_CN_UNKO      = "JA-LP\\1運行開発部";
            String AD_CN_KANSHI    = "JA-LP\\集中監視センタ";
            String AD_CN_KANSHI_G  = "JA-LP\\0監視業務";
            String AD_CN_EIGYO_HON = "JA-LP\\0本社営業所管理";
            String AD_CN_EIGYO_SHI = "JA-LP\\0営業所管理";
            String AD_CN_GIFU      = "JA-LP\\追加監視センター";
            //String AD_CN_GIFU2     = "JA-LP\\0監視業務単独"; // 2009/11/27 T.Watabe del
            String AD_CN_TOHOKU    = "JA-LP\\東北監視センター"; // 2009/05/12 T.Watabe add
            String AD_CN_OKINAWA   = "JA-LP\\重複監視センター"; // 2009/11/27 T.Watabe add
            
            sIP = Request.ServerVariables["REMOTE_ADDR"];
            
            //Message.Text = sIP; return; // debug
            
            if (sIP == null || sIP.Trim() == ""){
                Response.Redirect("login.asp");
            } else {
                try{
                    System.Net.IPHostEntry iphe = System.Net.Dns.GetHostEntry(sIP);
                    sPCName = iphe.HostName;
                }catch (Exception ex) {
                    sPCName = "unknown";
                }
                
                // ユーザの権限をチェック
                if (!IsPostBack) {
                    if (User.IsInRole(AD_CN_UNKO)) {
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:代行設定ありで、全ての監視センター情報を見れる。
                        sUSERID = "unko";
                        sADCN = AD_CN_UNKO;
                        sAUTH = "1";
                        
                    }else if (User.IsInRole(AD_CN_KANSHI)) {
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:代行設定ありで、全ての監視センター情報を見れる。
                        sUSERID = "unko";
                        sADCN = AD_CN_KANSHI;
                        sAUTH = "2";
                        
                    }else if (User.IsInRole(AD_CN_TOHOKU)) { // 2009/05/12 T.Watabe add
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:代行設定ありで、全ての監視センター情報を見れる。
                        sUSERID = "unko";
                        sADCN = AD_CN_TOHOKU;
                        sAUTH = "6";
                        
                    }else if (User.IsInRole(AD_CN_KANSHI_G)) { // 2009/05/13 T.Watabe add
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:代行設定ありで、全ての監視センター情報を見れる。
                        sUSERID = "unko";
                        sADCN = AD_CN_KANSHI_G;
                        sAUTH = "7";
                        
                    }else if (User.IsInRole(AD_CN_EIGYO_HON)) {
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:代行設定ありで、全ての監視センター情報を見れる。
                        sUSERID = "unko";
                        sADCN = AD_CN_EIGYO_HON;
                        sAUTH = "3";
                        
                    }else if (User.IsInRole(AD_CN_EIGYO_SHI)) {
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:代行設定ありで、全ての監視センター情報を見れる。
                        sUSERID = "unko";
                        sADCN = AD_CN_EIGYO_SHI;
                        sAUTH = "4";
                        
                    }else if (User.IsInRole(AD_CN_GIFU)) {
                        bSSO = true;
                        sCENTCD = "10004"; // 10004:岐阜監視センターのみ
                        sUSERID = "gifu";
                        sADCN = AD_CN_GIFU;
                        sAUTH = "5";
                        
                    // 2009/11/27 T.Watabe del
                    //}else if (User.IsInRole(AD_CN_GIFU2)) { // 2009/05/13 T.Watabe add
                    //    bSSO = true;
                    //    sCENTCD = "10004"; // 10004:岐阜監視センターのみ
                    //    sUSERID = "gifu";
                    //    sADCN = AD_CN_GIFU2;
                    //    sAUTH = "8";
                    //    
                    }else if (User.IsInRole(AD_CN_OKINAWA)) { // 2009/11/27 T.Watabe add
                        bSSO = true;
                        sCENTCD = "10001"; // 10001:農協プロパン監視センター(沖縄)のみ
                        sUSERID = "okinawa";
                        sADCN = AD_CN_OKINAWA;
                        sAUTH = "9";
                        
                    }
                }
                
                // 表示する名称を設定
                tmp = User.Identity.Name;
                if (tmp.IndexOf("\\") > 0){
                    sUSERNM = tmp.Substring(tmp.IndexOf("\\") + 1);
                }
                
                // ログファイル名の決定
                string logfilename = Server.MapPath(".") + @"\log\access" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                
                //クッキーの設定
                Response.Cookies.Clear();
                if (bSSO){ // シングルサインオン成功？
                    Response.Cookies["SSO_CHECK"].Value = "OK"; // ASP.NETからASPへ渡す際のキー。tyouhyou.aspで本来のセッションIDに置き換え。
                    Response.Cookies["SSO_CHECK"].Expires = DateTime.Now.AddDays(1); //クッキーのタイムアウト設定
                    
                    Response.Cookies["userid"].Value = sUSERID;   //ユーザIDをクッキーにセット
                    Response.Cookies["usernm"].Value = sUSERNM;   //ユーザ名をクッキーにセット
                    Response.Cookies["CENTCD"].Value = sCENTCD;   //監視センターコードをクッキーにセット
                    Response.Cookies["IP"].Value = sIP;           //IPをクッキーにセット
                    Response.Cookies["PCNAME"].Value = sPCName;   //PC名をクッキーにセット
                    Response.Cookies["USERNAME"].Value = User.Identity.Name;   //ユーザ名をクッキーにセット
                    Response.Cookies["AD_CN"].Value  = Server.UrlEncode(sADCN);     //ＡＤの権限文字列
                    Response.Cookies["AUTH_KBN"].Value  = sAUTH;  //権限
                    //Response.Cookies["AD_CN"].Value  = Server.UrlEncode(sADCN);     //ＡＤの権限文字列
                    //Response.Cookies["AD_CN"].Value  = Server.UrlDecode(sADCN);     //ＡＤの権限文字列
                    //Response.Cookies["AD_CN"].Value  = Encoding.GetEncoding("shift_jis").Get(sADCN);     //ＡＤの権限文字列
                    //Message.Text = Server.UrlEncode(sADCN) + "[" + sADCN + "]";
                    
                    // 結果をログ出力
                    try {
                        StreamWriter writer = new StreamWriter(
                            new FileStream(logfilename, FileMode.Append, FileAccess.Write));
                        writer.WriteLine("" + DateTime.Now.ToString() + ",IP=" + sIP + ",PC=" + sPCName + ",NAME=" + User.Identity.Name + ",AUTH=" + sAUTH + ",PG=010,PT=01,MEMO=Windows認証OK,");
                        writer.Close();
                    }catch (Exception ex) {
                        Message.Text = ex.Message;
                    }
                    
                    Response.Redirect("./asp/autofaxcomp0.aspx");
                }else{
                    // 結果をログ出力
                    try {
                        StreamWriter writer = new StreamWriter(
                            new FileStream(logfilename, FileMode.Append, FileAccess.Write));
                        writer.WriteLine("" + DateTime.Now.ToString() + ",IP=" + sIP + ",PC=" + sPCName + ",NAME=" + User.Identity.Name + ",AUTH=" + sAUTH + ",PG=010,PT=02,MEMO=Windows認証エラー(ユーザ権限該当なし),");
                        writer.Close();
                    }catch (Exception ex) {
                        Message.Text = ex.Message;
                    }
                }
            }
        }
        
    </script>
</head>
<body>
    <form runat="server">
        <hr>
        システムにログインする権限がありません。
        <hr>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>
