'***********************************************
'受信警報表示パネル  メイン画面(登録系フレームワーク)
'***********************************************
Option Explicit On
Option Strict On

Imports Common
Imports JPG.Common
Imports System.Text
Imports JPG.Common.log
Imports System.IO
Imports System.Diagnostics

Partial Class KEJUKJAG00
    Inherits System.Web.UI.Page

    Private strExecFlg As String            'ボタンのイベントを制御する

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' HttpHeader
    '******************************************************************************
    Protected HttpHeaderC As New CHttpHeader

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' 認証クラス
    '******************************************************************************
    Protected AuthC As CAuthenticate

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' ScriptMessage
    '******************************************************************************
    Private strMsg As New StringBuilder("")

    '<TODO>宣言共通仕様
    '******************************************************************************
    ' Render
    '******************************************************************************
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
        MyBase.Render(writer)

        Dim strWrite As New StringBuilder("")

        strWrite.Append("<script language='JavaScript'>")
        strWrite.Append(strMsg.ToString())
        strWrite.Append("</script>")
        writer.Write(strWrite.ToString())
    End Sub
#Region " Web フォーム デザイナで生成されたコード "

    'この呼び出しは Web フォーム デザイナで必要です。
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'メモ : 次のプレースホルダ宣言は Web フォーム デザイナで必要です。
    '削除および移動しないでください。
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        ' CODEGEN: このメソッド呼び出しは Web フォーム デザイナで必要です。
        ' コード エディタを使って変更しないでください。
        InitializeComponent()
    End Sub

#End Region

    '******************************************************************************
    ' Page_Load
    '******************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '2012/04/03 NEC ou Add Str
        '.NETの仕様変更により、ReadOnly属性をASPXでつけると、サーバ側で値の参照ができなくなるため、VB側でAttributeでつける
        If MyBase.IsPostBack = False Then

            txtCOUNT.Attributes.Add("ReadOnly", "true")
            txtTAICNT.Attributes.Add("ReadOnly", "true")
            txtTOTALCNT.Attributes.Add("ReadOnly", "true") '2016/11/16 H.Mori add 2016改善開発 No1-2
            txt1KMYMD.Attributes.Add("ReadOnly", "true")
            txt1KMTIME.Attributes.Add("ReadOnly", "true")
            txt1KURACD.Attributes.Add("ReadOnly", "true")
            txt1KENNM.Attributes.Add("ReadOnly", "true")
            txt1KMCNT.Attributes.Add("ReadOnly", "true")
            txt1RYURYO.Attributes.Add("ReadOnly", "true")
            txt1ROC.Attributes.Add("ReadOnly", "true")
            txt1KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt1KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt1KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt1JUYONM.Attributes.Add("ReadOnly", "true")
            txt1JANM.Attributes.Add("ReadOnly", "true")
            txt1JUTEL.Attributes.Add("ReadOnly", "true")
            txt1ADDR.Attributes.Add("ReadOnly", "true")
            txt1META.Attributes.Add("ReadOnly", "true")
            txt1ROCUSER.Attributes.Add("ReadOnly", "true") '2017/10/11 H.Mori add 2017改善開発 No1

            txt2KMYMD.Attributes.Add("ReadOnly", "true")
            txt2KMTIME.Attributes.Add("ReadOnly", "true")
            txt2KURACD.Attributes.Add("ReadOnly", "true")
            txt2KENNM.Attributes.Add("ReadOnly", "true")
            txt2KMCNT.Attributes.Add("ReadOnly", "true")
            txt2RYURYO.Attributes.Add("ReadOnly", "true")
            txt2ROC.Attributes.Add("ReadOnly", "true")
            txt2KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt2KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt2KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt2JUYONM.Attributes.Add("ReadOnly", "true")
            txt2JANM.Attributes.Add("ReadOnly", "true")
            txt2JUTEL.Attributes.Add("ReadOnly", "true")
            txt2ADDR.Attributes.Add("ReadOnly", "true")
            txt2META.Attributes.Add("ReadOnly", "true")
            txt2ROCUSER.Attributes.Add("ReadOnly", "true") '2017/10/11 H.Mori add 2017改善開発 No1

            txt3KMYMD.Attributes.Add("ReadOnly", "true")
            txt3KMTIME.Attributes.Add("ReadOnly", "true")
            txt3KURACD.Attributes.Add("ReadOnly", "true")
            txt3KENNM.Attributes.Add("ReadOnly", "true")
            txt3KMCNT.Attributes.Add("ReadOnly", "true")
            txt3RYURYO.Attributes.Add("ReadOnly", "true")
            txt3ROC.Attributes.Add("ReadOnly", "true")
            txt3KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt3KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt3KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt3JUYONM.Attributes.Add("ReadOnly", "true")
            txt3JANM.Attributes.Add("ReadOnly", "true")
            txt3JUTEL.Attributes.Add("ReadOnly", "true")
            txt3ADDR.Attributes.Add("ReadOnly", "true")
            txt3META.Attributes.Add("ReadOnly", "true")
            txt3ROCUSER.Attributes.Add("ReadOnly", "true") '2017/10/11 H.Mori add 2017改善開発 No1
            '2019/11/01 W.GANEKO ADD 2019改善開発 No3,4 start
            txt4KMYMD.Attributes.Add("ReadOnly", "true")
            txt4KMTIME.Attributes.Add("ReadOnly", "true")
            txt4KURACD.Attributes.Add("ReadOnly", "true")
            txt4KENNM.Attributes.Add("ReadOnly", "true")
            txt4KMCNT.Attributes.Add("ReadOnly", "true")
            txt4RYURYO.Attributes.Add("ReadOnly", "true")
            txt4ROC.Attributes.Add("ReadOnly", "true")
            txt4KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt4KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt4KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt4JUYONM.Attributes.Add("ReadOnly", "true")
            txt4JANM.Attributes.Add("ReadOnly", "true")
            txt4JUTEL.Attributes.Add("ReadOnly", "true")
            txt4ADDR.Attributes.Add("ReadOnly", "true")
            txt4META.Attributes.Add("ReadOnly", "true")
            txt4ROCUSER.Attributes.Add("ReadOnly", "true")

            txt5KMYMD.Attributes.Add("ReadOnly", "true")
            txt5KMTIME.Attributes.Add("ReadOnly", "true")
            txt5KURACD.Attributes.Add("ReadOnly", "true")
            txt5KENNM.Attributes.Add("ReadOnly", "true")
            txt5KMCNT.Attributes.Add("ReadOnly", "true")
            txt5RYURYO.Attributes.Add("ReadOnly", "true")
            txt5ROC.Attributes.Add("ReadOnly", "true")
            txt5KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt5KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt5KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt5JUYONM.Attributes.Add("ReadOnly", "true")
            txt5JANM.Attributes.Add("ReadOnly", "true")
            txt5JUTEL.Attributes.Add("ReadOnly", "true")
            txt5ADDR.Attributes.Add("ReadOnly", "true")
            txt5META.Attributes.Add("ReadOnly", "true")
            txt5ROCUSER.Attributes.Add("ReadOnly", "true")

            txt6KMYMD.Attributes.Add("ReadOnly", "true")
            txt6KMTIME.Attributes.Add("ReadOnly", "true")
            txt6KURACD.Attributes.Add("ReadOnly", "true")
            txt6KENNM.Attributes.Add("ReadOnly", "true")
            txt6KMCNT.Attributes.Add("ReadOnly", "true")
            txt6RYURYO.Attributes.Add("ReadOnly", "true")
            txt6ROC.Attributes.Add("ReadOnly", "true")
            txt6KMMESSAGE1.Attributes.Add("ReadOnly", "true")
            txt6KMMESSAGE2.Attributes.Add("ReadOnly", "true")
            txt6KMMESSAGE3.Attributes.Add("ReadOnly", "true")
            txt6JUYONM.Attributes.Add("ReadOnly", "true")
            txt6JANM.Attributes.Add("ReadOnly", "true")
            txt6JUTEL.Attributes.Add("ReadOnly", "true")
            txt6ADDR.Attributes.Add("ReadOnly", "true")
            txt6META.Attributes.Add("ReadOnly", "true")
            txt6ROCUSER.Attributes.Add("ReadOnly", "true")
            '2019/11/01 W.GANEKO ADD 2019改善開発 No3,4 end
        End If
        '2012/04/03 NEC ou Add End

        '//------------------------------------------
        '//　HTTPヘッダを送信
        HttpHeaderC.mNoCache(Response)

        '//------------------------------------------
        '//　認証クラスのインスタンス生成
        AuthC = New CAuthenticate(Request, Response)
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load start")

        '//------------------------------------------
        '//　認証処理
        '<TODO>：使用可能権限を指定する
        '[受信警報表示パネル]使用可能権限(運:○/営:×/監:△/出:×)
        AuthC.fncAuthCheck(Server, AuthC.pGROUP_UNKOU & "," & AuthC.pGROUP_KANSHI)

        '//------------------------------------------
        '<TODO>対応入力画面へ遷移
        '      [hdnKensaku(Hidden)]を作成する事
        '//------------------------------------------
        '欠損一覧ポップアップ出力
        If hdnKensaku.Value = "KEKESJAG00" Then
            mlog("[KEJUKJAG00" & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEKESJAG00")

            Server.Transfer("../../KEKESJAG/KEKESJAG00/KEKESJAG00.aspx")
        End If
        '2015/11/02 w.ganeko 2015改善開発 No9 start
        '担当者一覧ポップアップ出力
        If hdnKensaku.Value = "MSTASJAG00" Then
            mlog("[KEJUKJAG00" & New StackFrame(True).GetFileLineNumber.ToString & "]-Page_Load MSTASJAG00")
            Server.Transfer("../../../MS/MSTASJAG/MSTASJAG00/MSTASJAG00.aspx")
        End If
        '2015/11/02 w.ganeko 2015改善開発 No9 end
        '//------------------------------------------
        'アラート出力
        If hdnKensaku.Value = "KEJUKJOG00" Then
            mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJOG00")
            Server.Transfer("KEJUKJOG00.aspx")
        End If
        '//------------------------------------------
        'データチェックを行い、新しい警報が発見されたら出力する
        If hdnKensaku.Value = "KEJUKJKG00" Then
            mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJKG00")
            strExecFlg = "DATACHECK"
            Server.Transfer("KEJUKJKG00.aspx")
        End If
        '//------------------------------------------
        'ロック解除処理を実行
        If hdnKensaku.Value = "KEJUKJRG00" Then
            mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJRG00")
            strExecFlg = "DATANOROC"
            Server.Transfer("KEJUKJKG00.aspx")
        End If
        '//------------------------------------------
        '対応入力処理を実行（ロック処理）
        If hdnKensaku.Value = "KEJUKJNG00" Then
            mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KEJUKJNG00")
            strExecFlg = "DATAROC"
            Server.Transfer("KEJUKJKG00.aspx")
        End If
        '//------------------------------------------
        '対応入力画面へ遷移します
        If hdnKensaku.Value = "KETAIJAG00" Then
             mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load KETAIJAG00")
            Server.Transfer("../../KETAIJAG/KETAIJAG00/KETAIJAG00.aspx")
        End If


        '//------------------------------------------
        '// Script書込み用変数宣言
        Dim strScript As New StringBuilder("")
        Dim cscript1 As New CScript
        Dim strScriptPath As String
        strScriptPath = ConfigurationSettings.AppSettings("SCRIPTPATH")

        '------------------------------------------------------------------------------
        '<TODO>HTML内に必要なJavaScript/CSSはここで[strScript]変数に格納後
        '      画面上[lblScript]に書き込みを行います(SPANタグとしてクライアントにスクリプトが
        '      出力されます。)
        '//------------------------------------------
        '//　JavaScript格納
        strScript.Append("<Script language=javascript>")
        '<独自スクリプト>
        strScript.Append(cscript1.mWriteScript( _
                MyBase.MapPath("../../../KE/KEJUKJAG/KEJUKJAG00/") & "KEJUKJAG00.js"))
        '<フォーカス関連関数>
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "fncFo.js"))
        strScript.Append("</Script>")
        '//------------------------------------------
        '//　Css格納
        strScript.Append("<Style>")
        strScript.Append(cscript1.mWriteScript(strScriptPath & "\" & "CssData.css"))
        strScript.Append("</Style>")
        '//------------------------------------------
        '//　Script書込み
        lblScript.Text = strScript.ToString

        '//------------------------------------------------------------------------------
        If MyBase.IsPostBack = False Then
            '//--------------------------------------
            '//　初めて開いた時だけ実行される

            '初期値として警報の状態をセットする
            hdnRownum.Value = "1"
            hdnDataCount.Value = "0"
            hdnBtmOukaFlg.Value = "0"  '2014/01/20 T.Ono
            '画面遷移による制御
            Select Case Request.Form("hdnMyAspx")
                Case "KETAIJAG00"
                    '//------------------------------
                    '//対応入力画面からの遷移
                    hdnCtlFlg.Value = "KEJUTAI"
                Case Else
                    '//------------------------------
                    '//実行パターン別制御
                    If Request.QueryString("CLFLG") = "KANSHI" Then
                        hdnCtlFlg.Value = "KEJUKEI"
                    Else
                        hdnCtlFlg.Value = "KEJUTAI"
                    End If
            End Select

            '//--------------------------------------
            '最新表示ボタンイベントを実行する
            strMsg.Append("btnRenew_onclick();")

            '//--------------------------------------
            '<TODO>初期表示として必要なコントロールの設定を行います
            '対応入力画面からの遷移 2013/12/13 T.Ono add 監視改善2013
            If hdnCtlFlg.Value = "KEJUTAI" Then
                '処理№
                If Request.Form("hdnKEY_SERIAL") <> "" Then
                    hdnKEY_SERIAL.Value = Request.Form("hdnKEY_SERIAL")
                End If

                '自動更新
                If Request.Form("hdnJido") = "1" Then
                    hdnJido.Value = "1"
                    chkJido.Checked = True
                Else
                    hdnJido.Value = "0"
                    chkJido.Checked = False
                End If
                '未処理のみ
                If Request.Form("hdnMishori") = "1" Then
                    hdnMishori.Value = "1"
                    chkMishori.Checked = True
                Else
                    hdnMishori.Value = "0"
                    chkMishori.Checked = False
                End If
            End If
            '監視時の画面の制御処理
            If hdnCtlFlg.Value = "KEJUKEI" Then
                strMsg.Append("fncDispKansi();")
            End If

            '//--------------------------------------------------------------------------
            '　処理結果による画面の状態の設定------------------------
            '　画面を【検索前状態】にする（入力データはそのまま遷移させる）
        Else
            '//--------------------------------------
            '//　２回目以降実行される
            '//--------------------------------------------------------------------------
            '//※画面表示するコンボボックスは各最終イベント/メソッドでCALLします
            '//--------------------------------------------------------------------------
        End If

        '//-------------------------------------------------
        '<TODO>自分の画面IDをHIDDENのhdnMyAspxに書き込む（システム共通）
        hdnMyAspx.Value = "KEJUKJAG00"
        '//-------------------------------------------------

        '//-------------------------------------------------
        '//監視用の場合、データ受信フレームの一定時間のチェックを監視する
        '//一定時間更新画面では[hdnDummy]を出力する事
        If hdnCtlFlg.Value = "KEJUKEI" Then
            Dim strJUSINCHECK As String = CStr((CInt(ConfigurationSettings.AppSettings("JINTER")) * 1000) * 3)
            'Dim strJUSINCHECK As String = CStr((CInt(ConfigurationSettings.AppSettings("JINTER")) * 1000) * 10)　'★★★ T.Ono「* 1000) * 3)」が正　テスト用必ず戻す
            '[監視]N行後に再度実行JSを出力する
            '//2012/10/10 W.GANEKO CHG
            strMsg.Append("myTimer = setInterval('fncCheck_retry()'," & strJUSINCHECK & ");")
            strMsg.Append("function fncCheck_retry(){")
            strMsg.Append("var s='try{ parent.Recv.document.location.href }catch(kl_err){ 0 }';")
            strMsg.Append("if(!eval(s)) {")
            '　　　ネットワーク等の理由によりフレーム内にＨＴＭＬ展開されなかった時。
            '　　　通常の方法でチェックを行うとセキュリティの問題上アクセスを拒否される為
            strMsg.Append("	 fncDataCheck();")
            strMsg.Append("	 fncMessage();")
            strMsg.Append("} else {")
            '      ページは存在したのでダミーのHIDDEN項目の存在チェックを行う
            strMsg.Append("  obj=parent.Recv.document.getElementById('hdnDummy');")
            strMsg.Append("  if (obj == null){")
            strMsg.Append("	   fncDataCheck();")
            strMsg.Append("	   fncMessage();")
            strMsg.Append("  }")
            strMsg.Append("}")
            strMsg.Append("}")
            'strMsg.Append("var fncckrty = function() {")
            'strMsg.Append("var s='try{ parent.Recv.document.location.href }catch(kl_err){ 0 }';")
            'strMsg.Append("if(!eval(s)) {")
            '　　　ネットワーク等の理由によりフレーム内にＨＴＭＬ展開されなかった時。
            '　　　通常の方法でチェックを行うとセキュリティの問題上アクセスを拒否される為
            'strMsg.Append("	 fncDataCheck();")
            'strMsg.Append("	 fncMessage();")
            'strMsg.Append("} else {")
            '      ページは存在したのでダミーのHIDDEN項目の存在チェックを行う
            'strMsg.Append("  obj=parent.Recv.document.getElementById('hdnDummy');")
            'strMsg.Append("  if (obj == null){")
            'strMsg.Append("	   fncDataCheck();")
            'strMsg.Append("	   fncMessage();")
            'strMsg.Append("  }")
            'strMsg.Append("}")
            'strMsg.Append("};")
            'strMsg.Append("myTimer = setInterval(fncckrty," & strJUSINCHECK & ");")
            '//2012/10/10 W.GANEKO CHG
        End If

        '2013/12/25 T.Ono add 監視改善2013
        If hdnCtlFlg.Value = "KEJUTAI" Then
            Dim strJUSINCHECK As String = CStr((CInt(ConfigurationSettings.AppSettings("JINTER2")) * 1000) * 3)
            strMsg.Append("myTimer = setInterval('fncCheck_retry2()'," & strJUSINCHECK & ");")
        End If
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- Page_Load end")

    End Sub

    '******************************************************************************
    '*　概　要：処理実行制御値を渡すプロパティ
    '*　備　考：押下したボタンの種類を返す
    '******************************************************************************
    Public ReadOnly Property pExecFlag() As String
        Get
            Return strExecFlg
        End Get
    End Property

    '******************************************************************************
    '*　概　要：警報・対応区分を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pCtlFlg() As String
        Get
            Return hdnCtlFlg.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：前回データ総数を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pDataCount() As String
        Get
            Return hdnDataCount.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：前回データ出力のスタート位置を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pRownum() As String
        Get
            Return hdnRownum.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：処理対象のボタンインデックスを返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pINDEX() As String
        Get
            Return hdnINDEX.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：処理対象の処理番号を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pSERIAL() As String
        Get
            Return hdnKEY_SERIAL.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：画面の未処理処理中件数を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pNoReactionCount() As Integer
        Get
            If Request.Form("hdnNoReactionCOUNT").Length > 0 Then
                Return CInt(Request.Form("hdnNoReactionCOUNT"))
            Else
                Return 0
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：画面の未処理件数を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pDoReactionCount() As Integer
        Get
            If Request.Form("hdnDoReactionCOUNT").Length > 0 Then
                Return CInt(Request.Form("hdnDoReactionCOUNT"))
            Else
                Return 0
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：画面の未処理件数を返すプロパティ
    '*　備　考：
    '******************************************************************************
    Public ReadOnly Property pTaiTmskbCount() As Integer
        Get
            If Request.Form("hdnTaiTmskbCOUNT").Length > 0 Then
                Return CInt(Request.Form("hdnTaiTmskbCOUNT"))
            Else
                Return 0
            End If
        End Get
    End Property

    '******************************************************************************
    '*　概　要：自動更新チェック状態を返すプロパティ　2013/12/13 T.Ono add 監視改善2013
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pChkJido() As String
        Get
            Return hdnJido.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：未処理のみチェック状態を返すプロパティ　2013/12/13 T.Ono add 監視改善2013
    '*　備　考：0：チェックなし　1：チェックあり
    '******************************************************************************
    Public ReadOnly Property pChkMishori() As String
        Get
            Return hdnMishori.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：前回出力の処理№を返すプロパティ　2013/12/18 T.Ono add 監視改善2013
    '*　備　考：画面上
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL1() As String
        Get
            Return hdnSYORI_SERIAL1.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：前回出力の処理№を返すプロパティ　2013/12/18 T.Ono add 監視改善2013
    '*　備　考：画面中
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL2() As String
        Get
            Return hdnSYORI_SERIAL2.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：前回出力の処理№を返すプロパティ　2013/12/18 T.Ono add 監視改善2013
    '*　備　考：画面下
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL3() As String
        Get
            Return hdnSYORI_SERIAL3.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：前回出力の処理№を返すプロパティ　2019/11/01 w.ganeko add 監視改善2019
    '*　備　考：画面下
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL4() As String
        Get
            Return hdnSYORI_SERIAL4.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：前回出力の処理№を返すプロパティ　2019/11/01 w.ganeko add 監視改善2019
    '*　備　考：画面下
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL5() As String
        Get
            Return hdnSYORI_SERIAL5.Value
        End Get
    End Property
    '******************************************************************************
    '*　概　要：前回出力の処理№を返すプロパティ　2019/11/01 w.ganeko add 監視改善2019
    '*　備　考：画面下
    '******************************************************************************
    Public ReadOnly Property pSYORI_SERIAL6() As String
        Get
            Return hdnSYORI_SERIAL6.Value
        End Get
    End Property

    '******************************************************************************
    '*　概　要：緊急対応ボタン押下フラグを返すプロパティ　2014/01/20 T.Ono add 監視改善2013
    '*　備　考：１：押下　0：押下してない
    '******************************************************************************
    Public ReadOnly Property pBtmOukaFlg() As String
        Get
            Return hdnBtmOukaFlg.Value
        End Get
    End Property

    Private Sub btnFirst_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.ServerClick
        strExecFlg = "DATAFIRST"
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnFirst_ServerClick KEJUKJKG00.aspx server.Transfer DATAFIRST")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub

    Private Sub btnPre_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPre.ServerClick
        strExecFlg = "DATAPRE"
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnPre_ServerClick KEJUKJKG00.aspx server.Transfer DATAPRE")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub

    Private Sub btnNex_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNex.ServerClick
        strExecFlg = "DATANEX"
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnNex_ServerClick KEJUKJKG00.aspx server.Transfer DATANEX")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub

    Private Sub btnEnd_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnd.ServerClick
        strExecFlg = "DATAEND"
        Dim lineno As String = New StackFrame(True).GetFileLineNumber.ToString
        mlog("[KEJUKJAG00 " & lineno & "]- btnEnd_ServerClick KEJUKJKG00.aspx server.Transfer DATAEND")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub

    Private Sub btnRenew_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.ServerClick
        strExecFlg = "DATARENEW"
        mlog("[KEJUKJAG00 " & New StackFrame(True).GetFileLineNumber.ToString & "]- btnRenew_ServerClick KEJUKJKG00.aspx server.Transfer DATARENEW")
        Server.Transfer("KEJUKJKG00.aspx")
    End Sub
    '**********************************************************
    ' 2012/06/28 ADD W.GANEKO
    'ログ吐き出し
    '戻り値：書き込んだファイルへのフルパス
    '**********************************************************
    Public Sub mlog(ByVal pstrString As String)
        Dim strFilnm As String = "log" & System.DateTime.Today.ToString("yyyyMMdd")
        Dim strLogPath As String = ConfigurationSettings.AppSettings("LOG_OUT_PATH")
        Dim strPath As String = strLogPath & strFilnm & ".txt"
        Dim strLogFlg As String = ConfigurationSettings.AppSettings("LOG_OUT")
        Dim strRecLog As String
        Dim LogC As New CLog

        Dim linestring As New StringBuilder("")
        If strLogFlg = "1" Then
            '書き込みファイルへのストリーム
            'Dim sw As StreamWriter
            'Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)
            'linestring = New StringBuilder("")
            'linestring.Append(System.DateTime.Now & "." & System.DateTime.Now.Millisecond & "[" & AuthC.pUSERNAME & "][" & AuthC.pIPADDRESS & "][" & Me.Session.SessionID & "]" & pstrString & Chr(13) & Chr(10))
            Dim tbllog As String = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") & " " & pstrString
            strRecLog = LogC.mAPLog(Me.Session.SessionID, AuthC.pUSERNAME, AuthC.pIPADDRESS, Request.Form("hdnMyAspx"), "4", tbllog, Request.Form)

            'sw = New StreamWriter(fs, System.Text.Encoding.Default)

            ''引数の文字列をストリームに書き込み
            'sw.Write(linestring.ToString)

            ''メモリフラッシュ（ファイル書き込み）
            ''sw.Flush()

            ''ファイルクローズ
            'sw.Close()
            'sw.Dispose()
            'fs.Close()
            'fs.Dispose()
        End If
    End Sub
End Class
