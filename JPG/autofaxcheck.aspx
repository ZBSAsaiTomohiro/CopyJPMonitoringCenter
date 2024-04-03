<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="System.Security" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.IO" %>
<html>
<head>
    <title>�Ď��V�X�e��</title>
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
            String sAUTH = "0"; // ����
            
            // AD�����萔
            String AD_CN_UNKO      = "JA-LP\\1�^�s�J����";
            String AD_CN_KANSHI    = "JA-LP\\�W���Ď��Z���^";
            String AD_CN_KANSHI_G  = "JA-LP\\0�Ď��Ɩ�";
            String AD_CN_EIGYO_HON = "JA-LP\\0�{�Љc�Ə��Ǘ�";
            String AD_CN_EIGYO_SHI = "JA-LP\\0�c�Ə��Ǘ�";
            String AD_CN_GIFU      = "JA-LP\\�ǉ��Ď��Z���^�[";
            //String AD_CN_GIFU2     = "JA-LP\\0�Ď��Ɩ��P��"; // 2009/11/27 T.Watabe del
            String AD_CN_TOHOKU    = "JA-LP\\���k�Ď��Z���^�["; // 2009/05/12 T.Watabe add
            String AD_CN_OKINAWA   = "JA-LP\\�d���Ď��Z���^�["; // 2009/11/27 T.Watabe add
            
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
                
                // ���[�U�̌������`�F�b�N
                if (!IsPostBack) {
                    if (User.IsInRole(AD_CN_UNKO)) {
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:��s�ݒ肠��ŁA�S�Ă̊Ď��Z���^�[���������B
                        sUSERID = "unko";
                        sADCN = AD_CN_UNKO;
                        sAUTH = "1";
                        
                    }else if (User.IsInRole(AD_CN_KANSHI)) {
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:��s�ݒ肠��ŁA�S�Ă̊Ď��Z���^�[���������B
                        sUSERID = "unko";
                        sADCN = AD_CN_KANSHI;
                        sAUTH = "2";
                        
                    }else if (User.IsInRole(AD_CN_TOHOKU)) { // 2009/05/12 T.Watabe add
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:��s�ݒ肠��ŁA�S�Ă̊Ď��Z���^�[���������B
                        sUSERID = "unko";
                        sADCN = AD_CN_TOHOKU;
                        sAUTH = "6";
                        
                    }else if (User.IsInRole(AD_CN_KANSHI_G)) { // 2009/05/13 T.Watabe add
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:��s�ݒ肠��ŁA�S�Ă̊Ď��Z���^�[���������B
                        sUSERID = "unko";
                        sADCN = AD_CN_KANSHI_G;
                        sAUTH = "7";
                        
                    }else if (User.IsInRole(AD_CN_EIGYO_HON)) {
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:��s�ݒ肠��ŁA�S�Ă̊Ď��Z���^�[���������B
                        sUSERID = "unko";
                        sADCN = AD_CN_EIGYO_HON;
                        sAUTH = "3";
                        
                    }else if (User.IsInRole(AD_CN_EIGYO_SHI)) {
                        bSSO = true;
                        sCENTCD = "40000"; // 40000:��s�ݒ肠��ŁA�S�Ă̊Ď��Z���^�[���������B
                        sUSERID = "unko";
                        sADCN = AD_CN_EIGYO_SHI;
                        sAUTH = "4";
                        
                    }else if (User.IsInRole(AD_CN_GIFU)) {
                        bSSO = true;
                        sCENTCD = "10004"; // 10004:�򕌊Ď��Z���^�[�̂�
                        sUSERID = "gifu";
                        sADCN = AD_CN_GIFU;
                        sAUTH = "5";
                        
                    // 2009/11/27 T.Watabe del
                    //}else if (User.IsInRole(AD_CN_GIFU2)) { // 2009/05/13 T.Watabe add
                    //    bSSO = true;
                    //    sCENTCD = "10004"; // 10004:�򕌊Ď��Z���^�[�̂�
                    //    sUSERID = "gifu";
                    //    sADCN = AD_CN_GIFU2;
                    //    sAUTH = "8";
                    //    
                    }else if (User.IsInRole(AD_CN_OKINAWA)) { // 2009/11/27 T.Watabe add
                        bSSO = true;
                        sCENTCD = "10001"; // 10001:�_���v���p���Ď��Z���^�[(����)�̂�
                        sUSERID = "okinawa";
                        sADCN = AD_CN_OKINAWA;
                        sAUTH = "9";
                        
                    }
                }
                
                // �\�����閼�̂�ݒ�
                tmp = User.Identity.Name;
                if (tmp.IndexOf("\\") > 0){
                    sUSERNM = tmp.Substring(tmp.IndexOf("\\") + 1);
                }
                
                // ���O�t�@�C�����̌���
                string logfilename = Server.MapPath(".") + @"\log\access" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                
                //�N�b�L�[�̐ݒ�
                Response.Cookies.Clear();
                if (bSSO){ // �V���O���T�C���I�������H
                    Response.Cookies["SSO_CHECK"].Value = "OK"; // ASP.NET����ASP�֓n���ۂ̃L�[�Btyouhyou.asp�Ŗ{���̃Z�b�V����ID�ɒu�������B
                    Response.Cookies["SSO_CHECK"].Expires = DateTime.Now.AddDays(1); //�N�b�L�[�̃^�C���A�E�g�ݒ�
                    
                    Response.Cookies["userid"].Value = sUSERID;   //���[�UID���N�b�L�[�ɃZ�b�g
                    Response.Cookies["usernm"].Value = sUSERNM;   //���[�U�����N�b�L�[�ɃZ�b�g
                    Response.Cookies["CENTCD"].Value = sCENTCD;   //�Ď��Z���^�[�R�[�h���N�b�L�[�ɃZ�b�g
                    Response.Cookies["IP"].Value = sIP;           //IP���N�b�L�[�ɃZ�b�g
                    Response.Cookies["PCNAME"].Value = sPCName;   //PC�����N�b�L�[�ɃZ�b�g
                    Response.Cookies["USERNAME"].Value = User.Identity.Name;   //���[�U�����N�b�L�[�ɃZ�b�g
                    Response.Cookies["AD_CN"].Value  = Server.UrlEncode(sADCN);     //�`�c�̌���������
                    Response.Cookies["AUTH_KBN"].Value  = sAUTH;  //����
                    //Response.Cookies["AD_CN"].Value  = Server.UrlEncode(sADCN);     //�`�c�̌���������
                    //Response.Cookies["AD_CN"].Value  = Server.UrlDecode(sADCN);     //�`�c�̌���������
                    //Response.Cookies["AD_CN"].Value  = Encoding.GetEncoding("shift_jis").Get(sADCN);     //�`�c�̌���������
                    //Message.Text = Server.UrlEncode(sADCN) + "[" + sADCN + "]";
                    
                    // ���ʂ����O�o��
                    try {
                        StreamWriter writer = new StreamWriter(
                            new FileStream(logfilename, FileMode.Append, FileAccess.Write));
                        writer.WriteLine("" + DateTime.Now.ToString() + ",IP=" + sIP + ",PC=" + sPCName + ",NAME=" + User.Identity.Name + ",AUTH=" + sAUTH + ",PG=010,PT=01,MEMO=Windows�F��OK,");
                        writer.Close();
                    }catch (Exception ex) {
                        Message.Text = ex.Message;
                    }
                    
                    Response.Redirect("./asp/autofaxcomp0.aspx");
                }else{
                    // ���ʂ����O�o��
                    try {
                        StreamWriter writer = new StreamWriter(
                            new FileStream(logfilename, FileMode.Append, FileAccess.Write));
                        writer.WriteLine("" + DateTime.Now.ToString() + ",IP=" + sIP + ",PC=" + sPCName + ",NAME=" + User.Identity.Name + ",AUTH=" + sAUTH + ",PG=010,PT=02,MEMO=Windows�F�؃G���[(���[�U�����Y���Ȃ�),");
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
        �V�X�e���Ƀ��O�C�����錠��������܂���B
        <hr>
    </form>
    <asp:Label id="Message" runat="server" />
</body>
</html>
