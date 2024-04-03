//**************************************
//対応入力画面ボタン押下時の処理
//**************************************
// 変更履歴
// 2008/11/04 T.Watabe 連絡先を４→１０へ追加。但し５～１０は変更をＤＢへ保存しない。
// 2010/05/10 T.Watabe 連絡先を１０→３０へ追加。但し変更をＤＢへ保存しない。
// 2012/03/26 W.GANEKO SPOTメール追加
//
function btnTaiou_onclick() {
	if (fncDataCheck()==false) {
		return;
	}
	var strRes;
	strRes = confirm("入力値を反映してよろしいですか？");
	if (strRes==false){
		return;
	}
	parent.opener.frames('data').Form1.hdnREN_0_NA.value = Form1.txtTANNM1.value;
	parent.opener.frames('data').Form1.hdnREN_0_TEL1.value = Form1.txtRENTEL1_1.value;
	parent.opener.frames('data').Form1.hdnREN_0_TEL2.value = Form1.txtRENTEL2_1.value;
    parent.opener.frames('data').Form1.hdnREN_0_TEL3.value = Form1.txtRENTEL3_1.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_0_FAX.value = Form1.txtFAX1.value;
	parent.opener.frames('data').Form1.hdnREN_0_BIKO.value = Form1.txtBIKO1.value;
	parent.opener.frames('data').Form1.hdnREN_1_NA.value = Form1.txtTANNM2.value;
	parent.opener.frames('data').Form1.hdnREN_1_TEL1.value = Form1.txtRENTEL1_2.value;
	parent.opener.frames('data').Form1.hdnREN_1_TEL2.value = Form1.txtRENTEL2_2.value;
	parent.opener.frames('data').Form1.hdnREN_1_TEL3.value = Form1.txtRENTEL3_2.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_1_FAX.value = Form1.txtFAX2.value;
	parent.opener.frames('data').Form1.hdnREN_1_BIKO.value = Form1.txtBIKO2.value;
	parent.opener.frames('data').Form1.hdnREN_2_NA.value = Form1.txtTANNM3.value;
	parent.opener.frames('data').Form1.hdnREN_2_TEL1.value = Form1.txtRENTEL1_3.value;
	parent.opener.frames('data').Form1.hdnREN_2_TEL2.value = Form1.txtRENTEL2_3.value;
	parent.opener.frames('data').Form1.hdnREN_2_TEL3.value = Form1.txtRENTEL3_3.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_2_FAX.value = Form1.txtFAX3.value;
	parent.opener.frames('data').Form1.hdnREN_2_BIKO.value = Form1.txtBIKO3.value;
	parent.opener.frames('data').Form1.hdnREN_3_NA.value = Form1.txtTANNM4.value;
	parent.opener.frames('data').Form1.hdnREN_3_TEL1.value = Form1.txtRENTEL1_4.value;
	parent.opener.frames('data').Form1.hdnREN_3_TEL2.value = Form1.txtRENTEL2_4.value;
	parent.opener.frames('data').Form1.hdnREN_3_TEL3.value = Form1.txtRENTEL3_4.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_3_FAX.value = Form1.txtFAX4.value;
	parent.opener.frames('data').Form1.hdnREN_3_BIKO.value = Form1.txtBIKO4.value;
	parent.opener.frames('data').Form1.hdnREN_DENWABIKO.value = Form1.txtDENWABIKO.value;
	
	// 2008/11/04 T.Watabe add
	parent.opener.frames('data').Form1.hdnREN_4_NA.value   = Form1.txtTANNM5.value;
	parent.opener.frames('data').Form1.hdnREN_4_TEL1.value = Form1.txtRENTEL1_5.value;
	parent.opener.frames('data').Form1.hdnREN_4_TEL2.value = Form1.txtRENTEL2_5.value;
	parent.opener.frames('data').Form1.hdnREN_4_TEL3.value = Form1.txtRENTEL3_5.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_4_FAX.value  = Form1.txtFAX5.value;
	parent.opener.frames('data').Form1.hdnREN_4_BIKO.value = Form1.txtBIKO5.value;
	parent.opener.frames('data').Form1.hdnREN_5_NA.value   = Form1.txtTANNM6.value;
	parent.opener.frames('data').Form1.hdnREN_5_TEL1.value = Form1.txtRENTEL1_6.value;
	parent.opener.frames('data').Form1.hdnREN_5_TEL2.value = Form1.txtRENTEL2_6.value;
	parent.opener.frames('data').Form1.hdnREN_5_TEL3.value = Form1.txtRENTEL3_6.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_5_FAX.value  = Form1.txtFAX6.value;
	parent.opener.frames('data').Form1.hdnREN_5_BIKO.value = Form1.txtBIKO6.value;
	parent.opener.frames('data').Form1.hdnREN_6_NA.value   = Form1.txtTANNM7.value;
	parent.opener.frames('data').Form1.hdnREN_6_TEL1.value = Form1.txtRENTEL1_7.value;
	parent.opener.frames('data').Form1.hdnREN_6_TEL2.value = Form1.txtRENTEL2_7.value;
	parent.opener.frames('data').Form1.hdnREN_6_TEL3.value = Form1.txtRENTEL3_7.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_6_FAX.value  = Form1.txtFAX7.value;
	parent.opener.frames('data').Form1.hdnREN_6_BIKO.value = Form1.txtBIKO7.value;
	parent.opener.frames('data').Form1.hdnREN_7_NA.value   = Form1.txtTANNM8.value;
	parent.opener.frames('data').Form1.hdnREN_7_TEL1.value = Form1.txtRENTEL1_8.value;
	parent.opener.frames('data').Form1.hdnREN_7_TEL2.value = Form1.txtRENTEL2_8.value;
	parent.opener.frames('data').Form1.hdnREN_7_TEL3.value = Form1.txtRENTEL3_8.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_7_FAX.value  = Form1.txtFAX8.value;
	parent.opener.frames('data').Form1.hdnREN_7_BIKO.value = Form1.txtBIKO8.value;
	parent.opener.frames('data').Form1.hdnREN_8_NA.value   = Form1.txtTANNM9.value;
	parent.opener.frames('data').Form1.hdnREN_8_TEL1.value = Form1.txtRENTEL1_9.value;
	parent.opener.frames('data').Form1.hdnREN_8_TEL2.value = Form1.txtRENTEL2_9.value;
	parent.opener.frames('data').Form1.hdnREN_8_TEL3.value = Form1.txtRENTEL3_9.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_8_FAX.value  = Form1.txtFAX9.value;
	parent.opener.frames('data').Form1.hdnREN_8_BIKO.value = Form1.txtBIKO9.value;
	parent.opener.frames('data').Form1.hdnREN_9_NA.value   = Form1.txtTANNM10.value;
	parent.opener.frames('data').Form1.hdnREN_9_TEL1.value = Form1.txtRENTEL1_10.value;
	parent.opener.frames('data').Form1.hdnREN_9_TEL2.value = Form1.txtRENTEL2_10.value;
	parent.opener.frames('data').Form1.hdnREN_9_TEL3.value = Form1.txtRENTEL3_10.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_9_FAX.value  = Form1.txtFAX10.value;
	parent.opener.frames('data').Form1.hdnREN_9_BIKO.value = Form1.txtBIKO10.value;

	// 2010/05/10 T.Watabe add
	parent.opener.frames('data').Form1.hdnREN_10_NA.value   = Form1.txtTANNM11.value;
	parent.opener.frames('data').Form1.hdnREN_10_TEL1.value = Form1.txtRENTEL1_11.value;
	parent.opener.frames('data').Form1.hdnREN_10_TEL2.value = Form1.txtRENTEL2_11.value;
	parent.opener.frames('data').Form1.hdnREN_10_TEL3.value = Form1.txtRENTEL3_11.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_10_FAX.value  = Form1.txtFAX11.value;
	parent.opener.frames('data').Form1.hdnREN_10_BIKO.value = Form1.txtBIKO11.value;
	parent.opener.frames('data').Form1.hdnREN_11_NA.value   = Form1.txtTANNM12.value;
	parent.opener.frames('data').Form1.hdnREN_11_TEL1.value = Form1.txtRENTEL1_12.value;
	parent.opener.frames('data').Form1.hdnREN_11_TEL2.value = Form1.txtRENTEL2_12.value;
	parent.opener.frames('data').Form1.hdnREN_11_TEL3.value = Form1.txtRENTEL3_12.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_11_FAX.value  = Form1.txtFAX12.value;
	parent.opener.frames('data').Form1.hdnREN_11_BIKO.value = Form1.txtBIKO12.value;
	parent.opener.frames('data').Form1.hdnREN_12_NA.value   = Form1.txtTANNM13.value;
	parent.opener.frames('data').Form1.hdnREN_12_TEL1.value = Form1.txtRENTEL1_13.value;
	parent.opener.frames('data').Form1.hdnREN_12_TEL2.value = Form1.txtRENTEL2_13.value;
	parent.opener.frames('data').Form1.hdnREN_12_TEL3.value = Form1.txtRENTEL3_13.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_12_FAX.value  = Form1.txtFAX13.value;
	parent.opener.frames('data').Form1.hdnREN_12_BIKO.value = Form1.txtBIKO13.value;
	parent.opener.frames('data').Form1.hdnREN_13_NA.value   = Form1.txtTANNM14.value;
	parent.opener.frames('data').Form1.hdnREN_13_TEL1.value = Form1.txtRENTEL1_14.value;
	parent.opener.frames('data').Form1.hdnREN_13_TEL2.value = Form1.txtRENTEL2_14.value;
	parent.opener.frames('data').Form1.hdnREN_13_TEL3.value = Form1.txtRENTEL3_14.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_13_FAX.value  = Form1.txtFAX14.value;
	parent.opener.frames('data').Form1.hdnREN_13_BIKO.value = Form1.txtBIKO14.value;
	parent.opener.frames('data').Form1.hdnREN_14_NA.value   = Form1.txtTANNM15.value;
	parent.opener.frames('data').Form1.hdnREN_14_TEL1.value = Form1.txtRENTEL1_15.value;
	parent.opener.frames('data').Form1.hdnREN_14_TEL2.value = Form1.txtRENTEL2_15.value;
	parent.opener.frames('data').Form1.hdnREN_14_TEL3.value = Form1.txtRENTEL3_15.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_14_FAX.value  = Form1.txtFAX15.value;
	parent.opener.frames('data').Form1.hdnREN_14_BIKO.value = Form1.txtBIKO15.value;
	parent.opener.frames('data').Form1.hdnREN_15_NA.value   = Form1.txtTANNM16.value;
	parent.opener.frames('data').Form1.hdnREN_15_TEL1.value = Form1.txtRENTEL1_16.value;
	parent.opener.frames('data').Form1.hdnREN_15_TEL2.value = Form1.txtRENTEL2_16.value;
	parent.opener.frames('data').Form1.hdnREN_15_TEL3.value = Form1.txtRENTEL3_16.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_15_FAX.value  = Form1.txtFAX16.value;
	parent.opener.frames('data').Form1.hdnREN_15_BIKO.value = Form1.txtBIKO16.value;
	parent.opener.frames('data').Form1.hdnREN_16_NA.value   = Form1.txtTANNM17.value;
	parent.opener.frames('data').Form1.hdnREN_16_TEL1.value = Form1.txtRENTEL1_17.value;
	parent.opener.frames('data').Form1.hdnREN_16_TEL2.value = Form1.txtRENTEL2_17.value;
	parent.opener.frames('data').Form1.hdnREN_16_TEL3.value = Form1.txtRENTEL3_17.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_16_FAX.value  = Form1.txtFAX17.value;
	parent.opener.frames('data').Form1.hdnREN_16_BIKO.value = Form1.txtBIKO17.value;
	parent.opener.frames('data').Form1.hdnREN_17_NA.value   = Form1.txtTANNM18.value;
	parent.opener.frames('data').Form1.hdnREN_17_TEL1.value = Form1.txtRENTEL1_18.value;
	parent.opener.frames('data').Form1.hdnREN_17_TEL2.value = Form1.txtRENTEL2_18.value;
	parent.opener.frames('data').Form1.hdnREN_17_TEL3.value = Form1.txtRENTEL3_18.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_17_FAX.value  = Form1.txtFAX18.value;
	parent.opener.frames('data').Form1.hdnREN_17_BIKO.value = Form1.txtBIKO18.value;
	parent.opener.frames('data').Form1.hdnREN_18_NA.value   = Form1.txtTANNM19.value;
	parent.opener.frames('data').Form1.hdnREN_18_TEL1.value = Form1.txtRENTEL1_19.value;
	parent.opener.frames('data').Form1.hdnREN_18_TEL2.value = Form1.txtRENTEL2_19.value;
	parent.opener.frames('data').Form1.hdnREN_18_TEL3.value = Form1.txtRENTEL3_19.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_18_FAX.value  = Form1.txtFAX19.value;
	parent.opener.frames('data').Form1.hdnREN_18_BIKO.value = Form1.txtBIKO19.value;
	parent.opener.frames('data').Form1.hdnREN_19_NA.value   = Form1.txtTANNM20.value;
	parent.opener.frames('data').Form1.hdnREN_19_TEL1.value = Form1.txtRENTEL1_20.value;
	parent.opener.frames('data').Form1.hdnREN_19_TEL2.value = Form1.txtRENTEL2_20.value;
	parent.opener.frames('data').Form1.hdnREN_19_TEL3.value = Form1.txtRENTEL3_20.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_19_FAX.value  = Form1.txtFAX20.value;
	parent.opener.frames('data').Form1.hdnREN_19_BIKO.value = Form1.txtBIKO20.value;
	parent.opener.frames('data').Form1.hdnREN_20_NA.value   = Form1.txtTANNM21.value;
	parent.opener.frames('data').Form1.hdnREN_20_TEL1.value = Form1.txtRENTEL1_21.value;
	parent.opener.frames('data').Form1.hdnREN_20_TEL2.value = Form1.txtRENTEL2_21.value;
	parent.opener.frames('data').Form1.hdnREN_20_TEL3.value = Form1.txtRENTEL3_21.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_20_FAX.value  = Form1.txtFAX21.value;
	parent.opener.frames('data').Form1.hdnREN_20_BIKO.value = Form1.txtBIKO21.value;
	parent.opener.frames('data').Form1.hdnREN_21_NA.value   = Form1.txtTANNM22.value;
	parent.opener.frames('data').Form1.hdnREN_21_TEL1.value = Form1.txtRENTEL1_22.value;
	parent.opener.frames('data').Form1.hdnREN_21_TEL2.value = Form1.txtRENTEL2_22.value;
	parent.opener.frames('data').Form1.hdnREN_21_TEL3.value = Form1.txtRENTEL3_22.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_21_FAX.value  = Form1.txtFAX22.value;
	parent.opener.frames('data').Form1.hdnREN_21_BIKO.value = Form1.txtBIKO22.value;
	parent.opener.frames('data').Form1.hdnREN_22_NA.value   = Form1.txtTANNM23.value;
	parent.opener.frames('data').Form1.hdnREN_22_TEL1.value = Form1.txtRENTEL1_23.value;
	parent.opener.frames('data').Form1.hdnREN_22_TEL2.value = Form1.txtRENTEL2_23.value;
	parent.opener.frames('data').Form1.hdnREN_22_TEL3.value = Form1.txtRENTEL3_23.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_22_FAX.value  = Form1.txtFAX23.value;
	parent.opener.frames('data').Form1.hdnREN_22_BIKO.value = Form1.txtBIKO23.value;
	parent.opener.frames('data').Form1.hdnREN_23_NA.value   = Form1.txtTANNM24.value;
	parent.opener.frames('data').Form1.hdnREN_23_TEL1.value = Form1.txtRENTEL1_24.value;
	parent.opener.frames('data').Form1.hdnREN_23_TEL2.value = Form1.txtRENTEL2_24.value;
	parent.opener.frames('data').Form1.hdnREN_23_TEL3.value = Form1.txtRENTEL3_24.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_23_FAX.value  = Form1.txtFAX24.value;
	parent.opener.frames('data').Form1.hdnREN_23_BIKO.value = Form1.txtBIKO24.value;
	parent.opener.frames('data').Form1.hdnREN_24_NA.value   = Form1.txtTANNM25.value;
	parent.opener.frames('data').Form1.hdnREN_24_TEL1.value = Form1.txtRENTEL1_25.value;
	parent.opener.frames('data').Form1.hdnREN_24_TEL2.value = Form1.txtRENTEL2_25.value;
	parent.opener.frames('data').Form1.hdnREN_24_TEL3.value = Form1.txtRENTEL3_25.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_24_FAX.value  = Form1.txtFAX25.value;
	parent.opener.frames('data').Form1.hdnREN_24_BIKO.value = Form1.txtBIKO25.value;
	parent.opener.frames('data').Form1.hdnREN_25_NA.value   = Form1.txtTANNM26.value;
	parent.opener.frames('data').Form1.hdnREN_25_TEL1.value = Form1.txtRENTEL1_26.value;
	parent.opener.frames('data').Form1.hdnREN_25_TEL2.value = Form1.txtRENTEL2_26.value;
	parent.opener.frames('data').Form1.hdnREN_25_TEL3.value = Form1.txtRENTEL3_26.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_25_FAX.value  = Form1.txtFAX26.value;
	parent.opener.frames('data').Form1.hdnREN_25_BIKO.value = Form1.txtBIKO26.value;
	parent.opener.frames('data').Form1.hdnREN_26_NA.value   = Form1.txtTANNM27.value;
	parent.opener.frames('data').Form1.hdnREN_26_TEL1.value = Form1.txtRENTEL1_27.value;
	parent.opener.frames('data').Form1.hdnREN_26_TEL2.value = Form1.txtRENTEL2_27.value;
	parent.opener.frames('data').Form1.hdnREN_26_TEL3.value = Form1.txtRENTEL3_27.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_26_FAX.value  = Form1.txtFAX27.value;
	parent.opener.frames('data').Form1.hdnREN_26_BIKO.value = Form1.txtBIKO27.value;
	parent.opener.frames('data').Form1.hdnREN_27_NA.value   = Form1.txtTANNM28.value;
	parent.opener.frames('data').Form1.hdnREN_27_TEL1.value = Form1.txtRENTEL1_28.value;
	parent.opener.frames('data').Form1.hdnREN_27_TEL2.value = Form1.txtRENTEL2_28.value;
	parent.opener.frames('data').Form1.hdnREN_27_TEL3.value = Form1.txtRENTEL3_28.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_27_FAX.value  = Form1.txtFAX28.value;
	parent.opener.frames('data').Form1.hdnREN_27_BIKO.value = Form1.txtBIKO28.value;
	parent.opener.frames('data').Form1.hdnREN_28_NA.value   = Form1.txtTANNM29.value;
	parent.opener.frames('data').Form1.hdnREN_28_TEL1.value = Form1.txtRENTEL1_29.value;
	parent.opener.frames('data').Form1.hdnREN_28_TEL2.value = Form1.txtRENTEL2_29.value;
	parent.opener.frames('data').Form1.hdnREN_28_TEL3.value = Form1.txtRENTEL3_29.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_28_FAX.value  = Form1.txtFAX29.value;
	parent.opener.frames('data').Form1.hdnREN_28_BIKO.value = Form1.txtBIKO29.value;
	parent.opener.frames('data').Form1.hdnREN_29_NA.value   = Form1.txtTANNM30.value;
	parent.opener.frames('data').Form1.hdnREN_29_TEL1.value = Form1.txtRENTEL1_30.value;
	parent.opener.frames('data').Form1.hdnREN_29_TEL2.value = Form1.txtRENTEL2_30.value;
	parent.opener.frames('data').Form1.hdnREN_29_TEL3.value = Form1.txtRENTEL3_30.value; //2013/05/27 T.Ono add
	parent.opener.frames('data').Form1.hdnREN_29_FAX.value  = Form1.txtFAX30.value;
	parent.opener.frames('data').Form1.hdnREN_29_BIKO.value = Form1.txtBIKO30.value;
	//--- 2012/03/26 START ADD W.GANEKO ---//
	parent.opener.frames('data').Form1.hdnREN_0_MAIL.value = Form1.txtSPOT_MAIL_1.value;
	parent.opener.frames('data').Form1.hdnREN_1_MAIL.value = Form1.txtSPOT_MAIL_2.value;
	parent.opener.frames('data').Form1.hdnREN_2_MAIL.value = Form1.txtSPOT_MAIL_3.value;
	parent.opener.frames('data').Form1.hdnREN_3_MAIL.value = Form1.txtSPOT_MAIL_4.value;
	parent.opener.frames('data').Form1.hdnREN_4_MAIL.value = Form1.txtSPOT_MAIL_5.value;
	parent.opener.frames('data').Form1.hdnREN_5_MAIL.value = Form1.txtSPOT_MAIL_6.value;
	parent.opener.frames('data').Form1.hdnREN_6_MAIL.value = Form1.txtSPOT_MAIL_7.value;
	parent.opener.frames('data').Form1.hdnREN_7_MAIL.value = Form1.txtSPOT_MAIL_8.value;
	parent.opener.frames('data').Form1.hdnREN_8_MAIL.value = Form1.txtSPOT_MAIL_9.value;
	parent.opener.frames('data').Form1.hdnREN_9_MAIL.value = Form1.txtSPOT_MAIL_10.value;
	parent.opener.frames('data').Form1.hdnREN_10_MAIL.value = Form1.txtSPOT_MAIL_11.value;
	parent.opener.frames('data').Form1.hdnREN_11_MAIL.value = Form1.txtSPOT_MAIL_12.value;
	parent.opener.frames('data').Form1.hdnREN_12_MAIL.value = Form1.txtSPOT_MAIL_13.value;
	parent.opener.frames('data').Form1.hdnREN_13_MAIL.value = Form1.txtSPOT_MAIL_14.value;
	parent.opener.frames('data').Form1.hdnREN_14_MAIL.value = Form1.txtSPOT_MAIL_15.value;
	parent.opener.frames('data').Form1.hdnREN_15_MAIL.value = Form1.txtSPOT_MAIL_16.value;
	parent.opener.frames('data').Form1.hdnREN_16_MAIL.value = Form1.txtSPOT_MAIL_17.value;
	parent.opener.frames('data').Form1.hdnREN_17_MAIL.value = Form1.txtSPOT_MAIL_18.value;
	parent.opener.frames('data').Form1.hdnREN_18_MAIL.value = Form1.txtSPOT_MAIL_19.value;
	parent.opener.frames('data').Form1.hdnREN_19_MAIL.value = Form1.txtSPOT_MAIL_20.value;
	parent.opener.frames('data').Form1.hdnREN_20_MAIL.value = Form1.txtSPOT_MAIL_21.value;
	parent.opener.frames('data').Form1.hdnREN_21_MAIL.value = Form1.txtSPOT_MAIL_22.value;
	parent.opener.frames('data').Form1.hdnREN_22_MAIL.value = Form1.txtSPOT_MAIL_23.value;
	parent.opener.frames('data').Form1.hdnREN_23_MAIL.value = Form1.txtSPOT_MAIL_24.value;
	parent.opener.frames('data').Form1.hdnREN_24_MAIL.value = Form1.txtSPOT_MAIL_25.value;
	parent.opener.frames('data').Form1.hdnREN_25_MAIL.value = Form1.txtSPOT_MAIL_26.value;
	parent.opener.frames('data').Form1.hdnREN_26_MAIL.value = Form1.txtSPOT_MAIL_27.value;
	parent.opener.frames('data').Form1.hdnREN_27_MAIL.value = Form1.txtSPOT_MAIL_28.value;
	parent.opener.frames('data').Form1.hdnREN_28_MAIL.value = Form1.txtSPOT_MAIL_29.value;
	parent.opener.frames('data').Form1.hdnREN_29_MAIL.value = Form1.txtSPOT_MAIL_30.value;
	parent.opener.frames('data').Form1.hdnREN_0_MAILPASS.value = Form1.hdnREN_1_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_1_MAILPASS.value = Form1.hdnREN_2_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_2_MAILPASS.value = Form1.hdnREN_3_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_3_MAILPASS.value = Form1.hdnREN_4_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_4_MAILPASS.value = Form1.hdnREN_5_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_5_MAILPASS.value = Form1.hdnREN_6_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_6_MAILPASS.value = Form1.hdnREN_7_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_7_MAILPASS.value = Form1.hdnREN_8_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_8_MAILPASS.value = Form1.hdnREN_9_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_9_MAILPASS.value = Form1.hdnREN_10_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_10_MAILPASS.value = Form1.hdnREN_11_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_11_MAILPASS.value = Form1.hdnREN_12_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_12_MAILPASS.value = Form1.hdnREN_13_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_13_MAILPASS.value = Form1.hdnREN_14_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_14_MAILPASS.value = Form1.hdnREN_15_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_15_MAILPASS.value = Form1.hdnREN_16_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_16_MAILPASS.value = Form1.hdnREN_17_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_17_MAILPASS.value = Form1.hdnREN_18_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_18_MAILPASS.value = Form1.hdnREN_19_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_19_MAILPASS.value = Form1.hdnREN_20_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_20_MAILPASS.value = Form1.hdnREN_21_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_21_MAILPASS.value = Form1.hdnREN_22_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_22_MAILPASS.value = Form1.hdnREN_23_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_23_MAILPASS.value = Form1.hdnREN_24_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_24_MAILPASS.value = Form1.hdnREN_25_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_25_MAILPASS.value = Form1.hdnREN_26_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_26_MAILPASS.value = Form1.hdnREN_27_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_27_MAILPASS.value = Form1.hdnREN_28_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_28_MAILPASS.value = Form1.hdnREN_29_MAILPASS.value;
	parent.opener.frames('data').Form1.hdnREN_29_MAILPASS.value = Form1.hdnREN_30_MAILPASS.value;
	//--- 2012/03/26 END ADD W.GANEKO ---//
	
	//--- ↓2005/09/09 MOD Falcon↓ ---
	//parent.opener.frames('data').Form1.hdnREN_FAXTITLE.value = Form1.cboFAX_TITLE.value;
	parent.opener.frames('data').Form1.hdnFAX_TITLE_CD.value = Form1.cboFAX_TITLE.value;
	parent.opener.frames('data').Form1.hdnREN_FAXTITLE.value = getCboName(Form1.cboFAX_TITLE);
	//--- ↑2005/09/09 MOD Falcon↑ ---
	parent.opener.frames('data').Form1.hdnREN_FAXREN.value = Form1.txtFAX_REN.value;
		
	parent.opener.frames('data').Form1.btnRenraku.focus();
	window.close();
}
//**************************************
//入力値チェック
//**************************************
function fncDataCheck() {
	//入力禁止文字チェック
	if(fncChkChar()==false){
		return false;
	}
	//<TODO> 入力値チェック
	with(Form1) {
		var i;
		i = 1;
		while(i<=4) {
			obj = document.getElementById("txtTANNM"+i);
			if (obj.value.length!=0) {
				//担当名漢字が入力されていた時のみ有効データとする			
				//電話番号１ : 必須チェック
				obj = document.getElementById("txtRENTEL1_"+i);
				if (obj.value.length==0) {
					alert("電話番号１は必須です");
					obj.focus();
					return false;
				}
				//電話番号１：電話番号チェック
				obj = document.getElementById("txtRENTEL1_"+i);
				if (fncChkTel(obj.value) == false) {
					alert("電話番号１は正しい電話番号ではありません");
					obj.focus();
					return false;
				}
				//電話番号２：電話番号チェック
				obj = document.getElementById("txtRENTEL2_"+i);
				if (fncChkTel(obj.value) == false) {
					alert("電話番号２は正しい電話番号ではありません");
					obj.focus();
					return false;
	            }
	            // 2013/05/27 T.Ono add
                //電話番号３：電話番号チェック
	            obj = document.getElementById("txtRENTEL3_" + i);
	            if (fncChkTel(obj.value) == false) {
	                alert("電話番号３は正しい電話番号ではありません");
	                obj.focus();
	                return false;
	            }
				//ＦＡＸ番号：電話番号チェック
				obj = document.getElementById("txtFAX"+i);
				if (fncChkTel(obj.value) == false) {
					alert("ＦＡＸ番号は正しいＦＡＸ番号ではありません");
					obj.focus();
					return false;
				}
			} else {
				//担当名漢字が入力されていない場合、他のデータが入力されていたらエラー
				//電話番号１ : 未入力チェック
				obj = document.getElementById("txtRENTEL1_"+i);
				if (obj.value.length!=0) {
					alert("担当名漢字が入力されていない為、電話番号１は入力できません");
					obj.focus();
					return false;
				}
				//電話番号２ : 未入力チェック
				obj = document.getElementById("txtRENTEL2_"+i);
				if (obj.value.length!=0) {
					alert("担当名漢字が入力されていない為、電話番号２は入力できません");
					obj.focus();
					return false;
	            }
                // 2013/05/27 T.Ono add
	            //電話番号２ : 未入力チェック
	            obj = document.getElementById("txtRENTEL3_" + i);
	            if (obj.value.length != 0) {
	                alert("担当名漢字が入力されていない為、電話番号２は入力できません");
	                obj.focus();
	                return false;
	            }
				//ＦＡＸ番号 : 未入力チェック
				obj = document.getElementById("txtFAX"+i);
				if (obj.value.length!=0) {
					alert("担当名漢字が入力されていない為、ＦＡＸ番号は入力できません");
					obj.focus();
					return false;
				}
				//連絡先記事 : 未入力チェック
				obj = document.getElementById("txtBIKO"+i);
				if (obj.value.length!=0) {
					alert("担当名漢字が入力されていない為、連絡先記事は入力できません");
					obj.focus();
					return false;
				}
			}
			i++;
		}
		//電話連絡備考(レングスチェック)
		if(fncGetByte(txtDENWABIKO.value) > 100) {
			alert("電話連絡備考は全角50文字以内で入力して下さい");
			txtDENWABIKO.focus();
			return false;
		}
		//メモ欄(レングスチェック)
		if(fncGetByte(txtFAX_REN.value) > 140) {
			alert("メモ欄は全角70文字以内で入力して下さい");
			txtFAX_REN.focus();
			return false;
		}
	}
	return true;
}
//**************************************
//電話／ＦＡＸ発信ボタン押下時の処理
//**************************************
//2014/12/24 T.Ono mod 2014改善開発 No4
//  元々、btnTelHasから"1"を渡しているが受け取ってなかった。
//  btnPreviewから"2"を渡して区別できるようにする。
//  BtnKBN=1:btnTelHas押下 2:btnPreview押下
//  function btnDial_onclick() { 
function btnDial_onclick(BtnKBN) {
    var DialFlg;

	//<TODO> ＦＡＸ発信チェック
	with(Form1) {
		var i;
		i = 1;
		//while(i<=4) { 2008/11/04 T.Watabe edit
		//while(i <= 10) {
		while(i <= 30) {
		    //2012/03/23 add W.GANEKO 
            //2015/12/09 dell w.ganeko 2015改善開発 №2
			//obj = document.getElementById("rdoMail1");
			//if (obj.checked==true) {
			//	DialFlg = "4";
			//	break;
			//}
　　　　　　//2015/12/09 dell w.ganeko 2015改善開発 №2
　　　　　　//2012/03/23 add W.GANEKO 
			obj = document.getElementById("rdoTel1_"+i);
			if (obj.checked==true) {
				DialFlg = "1";
				break;
			}
			obj = document.getElementById("rdoTel2_"+i);
			if (obj.checked==true) {
				DialFlg = "1";
				break;
			}
            // 2013/05/27 T.Ono add
            obj = document.getElementById("rdoTel3_" + i);
            if (obj.checked == true) {
                DialFlg = "1";
                break;
            }
            //2015/12/09 w.ganeko mod 2015改善開発 №2	
			//obj = document.getElementById("rdoFax"+i);
			obj = document.getElementById("chkFax_" + i);
			if (obj.checked == true) {
				DialFlg = "2";
				break;
			}
			//2012/03/23 add W.GANEKO 
            //2015/12/09 w.ganeko mod 2015改善開発 №2	
            //obj = document.getElementById("rdoFaxMail" + i);
            //2016/05/06 w.ganeko start
//            obj = document.getElementById("chkFaxMail_" + i);
//			if (obj.checked == true) {
//				DialFlg = "3";
//				break;
//			}
            //2016/05/06 w.ganeko end
            //2012/03/23 add W.GANEKO
            //2015/12/09 w.ganeko mod 2015改善開発 №2 start
            obj = document.getElementById("chkMail_" + i);
            if (obj.checked == true) {
                DialFlg = "4";
                break;
            }
            //2015/12/09 w.ganeko mod 2015改善開発 №2 end
            i++;
		}
    }
    //2015/12/09 w.ganeko mod 2015改善開発 №2 del
	//document.getElementById("hdnSendFlg").value = DialFlg;

	//2014/02/04 T.Ono add 監視改善2013 FAXサーバー選択
	document.getElementById("hdnFAXServerKBN").value = fncSetFAXServerKBN();

	//2014/12/24 T.Ono mod 2014改善開発 No4 START
	if (BtnKBN == "2") {
	    //プレビューボタンを押した場合
	    Form1.hdnBtnKBN.value = '2'  //プレビューボタン押下
        if (DialFlg == "1") {
		    alert('電話番号が選択されています');
		    return;
	    }
    } else {
        Form1.hdnBtnKBN.value = '1'  //発信ボタン押下
    }
    //2014/12/24 T.Ono mod 2014改善開発 No4 END

    if (DialFlg == "1") {
        //2015/12/09 w.ganeko mod 2015改善開発 №2 add
        document.getElementById("hdnSendFlg").value = DialFlg;
        fncDial_Tel(); //電話発信
     //2015/12/09 w.ganeko 2015改善開発 №2 start
     //} else if (DialFlg == "2") {
     //	fncDial_Fax();	//ＦＡＸ送信
     //} else if (DialFlg == "3") {
     //  fncDial_FaxMail();	//ＦＡＸ＆メール送信
     //} else if(DialFlg == "4"){
     //  fncDial_Mail();	//メール送信
    } else if (DialFlg == "2" || DialFlg == "3" || DialFlg == "4") {
        fncDial_SendFaxMail();  //ＦＡＸ＆メール送信
    }
    //2015/12/09 w.ganeko 2015改善開発 №2 end
}
//**************************************
//電話発信
//**************************************
function fncDial_Tel() {

	var strRec;
	strRes = confirm("電話発信してよろしいですか？");
	if (strRes==false){
		return;
	}
	var strTel
	var strAite
	var strObj
	with(Form1) {
		var i;
	    i = 1;
		while(i <= 30){
			//電話１
			obj = document.getElementById("rdoTel1_" + i);
			if (obj.checked==true) { // チェックあり！
				strTel  = document.getElementById("txtRENTEL1_" + i).value;
				strAite = document.getElementById("txtTANNM" + i).value;
				strObj  = document.getElementById("txtRENTEL1_" + i);
				break;
			}
			//電話２
			obj = document.getElementById("rdoTel2_"+i);
			if (obj.checked==true) { // チェックあり！
				strTel  = document.getElementById("txtRENTEL2_" + i).value;
				strAite = document.getElementById("txtTANNM" + i).value;
				strObj  = document.getElementById("txtRENTEL2_" + i);
				break;
			}
            // 2013/05/27 T.Ono add
            //電話３ 
            obj = document.getElementById("rdoTel3_" + i);
            if (obj.checked == true) { // チェックあり！
                strTel = document.getElementById("txtRENTEL3_" + i).value;
                strAite = document.getElementById("txtTANNM" + i).value;
                strObj = document.getElementById("txtRENTEL3_" + i);
                break;
            }
			i++;
	    }
	if (false){
		//一次連絡先　電話１
		if (rdoTel1_1.checked==true) {
			strTel = txtRENTEL1_1.value;
			strAite = txtTANNM1.value;
			strObj = txtRENTEL1_1;
		}
		//一次連絡先　電話２
		if (rdoTel2_1.checked==true) {
			strTel = txtRENTEL2_1.value;
			strAite = txtTANNM1.value;
			strObj = txtRENTEL2_1;
        }
        // 2013/05/27 T.Ono add
        //一次連絡先　電話３
        if (rdoTel3_1.checked == true) {
            strTel = txtRENTEL3_1.value;
            strAite = txtTANNM1.value;
            strObj = txtRENTEL3_1;
        }
		//二次連絡先１　電話１
		if (rdoTel1_2.checked==true) {
			strTel = txtRENTEL1_2.value;
			strAite = txtTANNM2.value;
			strObj = txtRENTEL1_2;		
		}
		//二次連絡先１　電話２
		if (rdoTel2_2.checked==true) {
			strTel = txtRENTEL2_2.value;
			strAite = txtTANNM2.value;
			strObj = txtRENTEL2_2;
        }
        // 2013/05/27 T.Ono add
        //二次連絡先１　電話３
        if (rdoTel3_2.checked == true) {
            strTel = txtRENTEL3_2.value;
            strAite = txtTANNM2.value;
            strObj = txtRENTEL3_2;
        }
		//二次連絡先２　電話１
		if (rdoTel1_3.checked==true) {
			strTel = txtRENTEL1_3.value;
			strAite = txtTANNM3.value;
			strObj = txtRENTEL1_3;
		}
		//二次連絡先２　電話２
		if (rdoTel2_3.checked==true) {
			strTel = txtRENTEL2_3.value;
			strAite = txtTANNM3.value;
			strObj = txtRENTEL2_3;
        }
        // 2013/05/27 T.Ono add
        //二次連絡先３　電話３
        if (rdoTel3_3.checked == true) {
            strTel = txtRENTEL3_3.value;
            strAite = txtTANNM3.value;
            strObj = txtRENTEL3_3;
        }
		//二次連絡先３　電話１
		if (rdoTel1_4.checked==true) {
			strTel = txtRENTEL1_4.value;
			strAite = txtTANNM4.value;
			strObj = txtRENTEL1_4;
		}
		//二次連絡先３　電話２
		if (rdoTel2_4.checked==true) {
			strTel = txtRENTEL2_4.value;
			strAite = txtTANNM4.value;
			strObj = txtRENTEL2_4;
		}
        // 2013/05/27 T.Ono add
        //二次連絡先３　電話３
        if (rdoTel3_4.checked == true) {
            strTel = txtRENTEL3_4.value;
            strAite = txtTANNM4.value;
            strObj = txtRENTEL3_4;
        }
		// 2008/11/04 T.Watabe add
		//二次連絡先４　電話１
		if (rdoTel1_5.checked==true) {
			strTel = txtRENTEL1_5.value;
			strAite = txtTANNM5.value;
			strObj = txtRENTEL1_5;
		}
		//二次連絡先４　電話２
		if (rdoTel2_5.checked==true) {
			strTel = txtRENTEL2_5.value;
			strAite = txtTANNM5.value;
			strObj = txtRENTEL2_5;
        }
        // 2013/05/27 T.Ono add
        //二次連絡先４　電話３
        if (rdoTel3_5.checked == true) {
            strTel = txtRENTEL3_5.value;
            strAite = txtTANNM5.value;
            strObj = txtRENTEL3_5;
        }
		//二次連絡先５　電話１
		if (rdoTel1_6.checked==true) {
			strTel = txtRENTEL1_6.value;
			strAite = txtTANNM6.value;
			strObj = txtRENTEL1_6;
		}
		//二次連絡先５　電話２
		if (rdoTel2_6.checked==true) {
			strTel = txtRENTEL2_6.value;
			strAite = txtTANNM6.value;
			strObj = txtRENTEL2_6;
        }
        // 2013/05/27 T.Ono add
        //二次連絡先５　電話３
        if (rdoTel3_6.checked == true) {
            strTel = txtRENTEL3_6.value;
            strAite = txtTANNM6.value;
            strObj = txtRENTEL3_6;
        }
		//二次連絡先６　電話１
		if (rdoTel1_7.checked==true) {
			strTel = txtRENTEL1_7.value;
			strAite = txtTANNM7.value;
			strObj = txtRENTEL1_7;
		}
		//二次連絡先６　電話２
		if (rdoTel2_7.checked==true) {
			strTel = txtRENTEL2_7.value;
			strAite = txtTANNM7.value;
			strObj = txtRENTEL2_7;
        }
        // 2013/05/27 T.Ono add
        //二次連絡先６　電話３
        if (rdoTel3_7.checked == true) {
            strTel = txtRENTEL3_7.value;
            strAite = txtTANNM7.value;
            strObj = txtRENTEL3_7;
        }
		//二次連絡先７　電話１
		if (rdoTel1_8.checked==true) {
			strTel = txtRENTEL1_8.value;
			strAite = txtTANNM8.value;
			strObj = txtRENTEL1_8;
		}
		//二次連絡先７　電話２
		if (rdoTel2_8.checked==true) {
			strTel = txtRENTEL2_8.value;
			strAite = txtTANNM8.value;
			strObj = txtRENTEL2_8;
        }
        // 2013/05/27 T.Ono add
        //二次連絡先７　電話３
        if (rdoTel3_8.checked == true) {
            strTel = txtRENTEL3_8.value;
            strAite = txtTANNM8.value;
            strObj = txtRENTEL3_8;
        }
		//二次連絡先８　電話１
		if (rdoTel1_9.checked==true) {
			strTel = txtRENTEL1_9.value;
			strAite = txtTANNM9.value;
			strObj = txtRENTEL1_9;
		}
		//二次連絡先８　電話２
		if (rdoTel2_9.checked==true) {
			strTel = txtRENTEL2_9.value;
			strAite = txtTANNM9.value;
			strObj = txtRENTEL2_9;
       }
        // 2013/05/27 T.Ono add
        //二次連絡先８　電話３
        if (rdoTel3_9.checked == true) {
            strTel = txtRENTEL3_9.value;
            strAite = txtTANNM9.value;
            strObj = txtRENTEL3_9;
        }
		//二次連絡先９　電話１
		if (rdoTel1_10.checked==true) {
			strTel = txtRENTEL1_10.value;
			strAite = txtTANNM10.value;
			strObj = txtRENTEL1_10;
		}
		//二次連絡先９　電話２
		if (rdoTel2_10.checked==true) {
			strTel = txtRENTEL2_10.value;
			strAite = txtTANNM10.value;
			strObj = txtRENTEL2_10;
        }
        // 2013/05/27 T.Ono add
        //二次連絡先９　電話３
        if (rdoTel3_10.checked == true) {
            strTel = txtRENTEL3_10.value;
            strAite = txtTANNM10.value;
            strObj = txtRENTEL3_10;
        }
	} // if
	} // with

	//電話番号必須チェック
	if(strTel.length==0) {
		alert('電話番号がありません');
		strObj.focus();
		return;
	}
	//電話番号チェック
	if (fncChkTel(strTel) == false) {
		alert("電話番号が正しくありません");
		strObj.focus();
		return;
	}
		
	//ログの整合性を合わせる為に親画面の電話発信機能を使用する
	parent.opener.frames('data').btnDial_onclick('3',strTel,strAite);

	//カーソルはポップアップにセットしておく
	//2015/12/09 w.ganeko 2015改善開発 №2 start
	Form1.btnSoExit.disabled = false;
	Form1.btnTelHas.focus();
}
//2015/12/09 w.ganeko 2015改善開発 №2 start
//**************************************
//ＦＡＸ＆メール発信
//**************************************
function fncDial_SendFaxMail() {
    var strRes;
    //入力禁止文字チェック
    if (fncChkChar() == false) {
        return false;
    }

    if (Form1.hdnBtnKBN.value == "2") {
        alert('  プレビューを作成します  ');
    }

    //メモ欄　文字数チェック
    if (fncGetByte(Form1.txtFAX_REN.value) > 140) {
        alert("メモ欄は全角70文字以内で入力して下さい");
        Form1.txtFAX_REN.focus();
        return false;
    }
    var strMailLen = new Array();
    var strMailPassLen = new Array();
    var strMailObjAry = new Array();
    var strMail;
    var strMailPass;
    var strMailCnt = false;
    var strMailObj
    var strFaxCnt = false;
    var strFax
    var strFaxLen = new Array();
    var strFaxObj
    var strObjAry = new Array();
    var strFaxObjAry = new Array();
    with (Form1) {
        var i;
        i = 1;
        while (i <= 30) {
            //メール
            //2016/05/06 w.ganeko start
//            objFaxMail = document.getElementById("chkFaxMail_" + i);
            //2016/05/06 w.ganeko end
            objFax = document.getElementById("chkFax_" + i);
            objMail = document.getElementById("chkMail_" + i);
            //2016/05/06 w.ganeko start
            // if (objFaxMail.checked == true || objFax.checked == true || objMail.checked == true) { // チェックあり！
            //    if (objFaxMail.checked == true || objMail.checked == true) {
            if (objFax.checked == true || objMail.checked == true) { // チェックあり！
                if (objMail.checked == true) {
                    //2016/05/06 w.ganeko end
                    strMail = document.getElementById("txtSPOT_MAIL_" + i).value;
                    strMailObj = document.getElementById("txtSPOT_MAIL_" + i);
                    if (strMail.length != 0) {
                        strMailCnt = true;
                        if (fncArrayCheck(strMailLen,strMail)) {
                            strMailLen.push(strMail);
                            strMailPassLen.push(document.getElementById("hdnREN_" + i + "_MAILPASS").value);
                            strMailObjAry.push(strMailObj);
                            if (fncArrayCheck(strObjAry, i.toString())) {
                                strObjAry.push(i.toString());
                            }
                        }
                    } else {
                        alert('メールアドレスがありません');
                        strMailObj.focus();
                        return;
                    }
                }
                //2016/05/06 w.ganeko start
                //if (objFaxMail.checked == true || objFax.checked == true) {
                if (objFax.checked == true) {
                //2016/05/06 w.ganeko end
                    strFax = document.getElementById("txtFAX" + i).value;
                    strFaxObj = document.getElementById("txtFAX" + i);
                    if (strFax.length != 0) {
                        //電話番号チェック
                        if (fncChkTel(strFax) == false) {
                            alert("ＦＡＸ番号が正しくありません");
                            strFaxObj.focus();
                            return;
                        }
                        strFaxCnt = true;
                        var strFaxvl = strFax.split(' - ').join('').split('-').join('');
                        if (fncArrayCheck(strFaxLen, strFaxvl)) {
                            strFaxLen.push(strFaxvl);
                            strFaxObjAry.push(strFaxObj);
                            if (fncArrayCheck(strObjAry, i.toString())) {
                                strObjAry.push(i.toString());
                            }
                        }
                    } else {
                        alert('ＦＡＸ番号がありません');
                        strFaxObj.focus();
                        return;
                    }
                }
            }
            i++;
        }
    }

    if (Form1.hdnBtnKBN.value == "1") {
        //2016/02/02 w.ganeko 2015改善開発 №2 第2弾
        //if (strMailLen.length > 1 || strFaxLen.length > 1 || strObjAry.length > 1) {
        if (strMailLen.length > 1 || strFaxLen.length > 1 || strObjAry.length > 1 || (strMailLen.length >= 1 && strFaxLen.length >= 1)) {
            objSendMeny = document.getElementById("chkMenyMail1");
            if(objSendMeny.checked == false){
                alert("複数宛先にチェックがあります");
                objSendMeny.focus();
                return;
            }
        }
        if (strFaxLen.length > 10) {
            alert("FAXを同時に送れるのは10件までです。分けて送信してください。");
            strFaxObjAry(0).focus();
            return;
        }
        if (strMailCnt && !strFaxCnt) {
            strRes = confirm("メールを送信してよろしいですか？");
            document.getElementById("hdnSendFlg").value = "4";
        } else if (!strMailCnt && strFaxCnt) {
            strRes = confirm("ＦＡＸを送信してよろしいですか？");
            document.getElementById("hdnSendFlg").value = "2";
        } else if (strMailCnt && strFaxCnt) {
            strRes = confirm("ＦＡＸとメールを送信してよろしいですか？");
            document.getElementById("hdnSendFlg").value = "3";
        }
        if (strRes == false) {
            return;
        }
    }
    Form1.hdnSNDFAXNO.value = strFaxLen.toString();
    Form1.hdnSNDMAIL.value = strMailLen.toString();
    Form1.hdnSNDMAILPASS.value = strMailPassLen.toString();
    strFAX_TITLE = Form1.cboFAX_TITLE.options[Form1.cboFAX_TITLE.selectedIndex].text;
    if (strFAX_TITLE.indexOf(":") != -1) {
        strFAX_TITLE = strFAX_TITLE.split(":")[1];
    } else if (strFAX_TITLE.indexOf("：") != -1) {
        strFAX_TITLE = strFAX_TITLE.split("：")[1];
    }
    Form1.hdnFAX_TITLE.value = strFAX_TITLE;
    parent.opener.frames('data').Form1.hdnREN_FAXTITLE.value = strFAX_TITLE;              //FAXタイトル
    parent.opener.frames('data').Form1.hdnFAX_TITLE_CD.value = Form1.cboFAX_TITLE.value;  //FAXタイトルコード
    parent.opener.frames('data').Form1.hdnREN_FAXREN.value = Form1.txtFAX_REN.value;      //メモ欄

    if (Form1.hdnBtnKBN.value == "2") {
        Form1.hdnPreviewFlg.value = '1'                                                   //プレビュー確認済みフラグ
        Form1.btnTelHas.disabled = false;
        Form1.btnSoExit.disabled = false;
    } else {
        Form1.btnTelHas.disabled = true; //btnTelHas無効化
        parent.opener.frames('data').Form1.hdnSEND_FAX_FLG.value = '1';                     //FAX・メール送信フラグ
        //2016/12/19 H.Mori add 2016改善開発 No6-3 
        parent.opener.frames('data').Form1.hdnFAXSPOTKBN.value = '2';                     //スポットFAX送信フラグ
    }
    doPostBack('btnTelHas', '');
}
//2015/12/09 w.ganeko 2015改善開発 №2 start
//**************************************
//ＦＡＸ＆メール発信
//**************************************
function fncArrayCheck(ary,str) {
    for (var i = 0; i < ary.length; i++) {
        if (ary[i] == str) {
            return false;
        }
    }
    return true;
}
//2015/12/09 w.ganeko 2015改善開発 №2 end
//↓2005/04/26 ADD Falcon↓
//2015/12/09 w.ganeko del 2015改善開発 №2 start
//**************************************
//ＦＡＸ発信
//**************************************
//function fncDial_Fax() {
//	var strRes;
//	//入力禁止文字チェック
//	if(fncChkChar()==false){
//		return false;
//	}

//    //2014/12/24 T.Ono mod 2014改善開発 No4 START
////    strRes = confirm("ＦＡＸ送信してよろしいですか？");
////    if (strRes == false) {
////        return;
////    }
//    if (Form1.hdnBtnKBN.value == "2") {
//        alert('  プレビューを作成します  ');
//    }else{
//        strRes = confirm("ＦＡＸ送信してよろしいですか？");
//	    if (strRes==false){
//		    return;
//        }
//    }
//    //2014/12/24 T.Ono mod 2014改善開発 No4 END

//	var strFax
//	var strObj
//	with(Form1) {
//		var i;
//	    i = 1;
//		while(i <= 30){
//		    //ＦＡＸ
//            //2015/12/09 w.ganeko 2015改善開発 №2
//			//obj = document.getElementById("rdoFax" + i);
//			obj = document.getElementById("chkFax_" + i);
//			if (obj.checked == true) { // チェックあり！
//				strFax  = document.getElementById("txtFAX" + i).value;
//				strObj  = document.getElementById("txtFAX" + i);
//				break;
//			}
//			i++;
//	    }
//	if (false){
//		//一次連絡先　ＦＡＸ
//	    //2015/12/09 w.ganeko 2015改善開発 №2
//	    //if (rdoFax1.checked == true) {
//	    if (chkFax_1.checked == true) {
//			strFax = txtFAX1.value;
//			strObj = txtFAX1;
//		}
//        //二次連絡先１　ＦＡＸ
//		//2015/12/09 w.ganeko 2015改善開発 №2
//        //if (rdoFax2.checked==true) {
//        if (chkFax_2.checked==true) {
//			strFax = txtFAX2.value;
//			strObj = txtFAX2;
//		}
//		//二次連絡先２　ＦＡＸ
//　　　　//2015/12/09 w.ganeko 2015改善開発 №2

//　　　　if (rdoFax3.checked == true) {
//			strFax = txtFAX3.value;
//			strObj = txtFAX3;
//		}
//		//二次連絡先３　ＦＡＸ
//		if (rdoFax4.checked==true) {
//			strFax = txtFAX4.value;
//			strObj = txtFAX4;
//		}
//		
//		// 2008/11/04 T.Watabe add
//		//二次連絡先４　ＦＡＸ
//		if (rdoFax5.checked==true) {
//			strFax = txtFAX5.value;
//			strObj = txtFAX5;
//		}
//		//二次連絡先５　ＦＡＸ
//		if (rdoFax6.checked==true) {
//			strFax = txtFAX6.value;
//			strObj = txtFAX6;
//		}
//		//二次連絡先６　ＦＡＸ
//		if (rdoFax7.checked==true) {
//			strFax = txtFAX7.value;
//			strObj = txtFAX7;
//		}
//		//二次連絡先７　ＦＡＸ
//		if (rdoFax8.checked==true) {
//			strFax = txtFAX8.value;
//			strObj = txtFAX8;
//		}
//		//二次連絡先８　ＦＡＸ
//		if (rdoFax9.checked==true) {
//			strFax = txtFAX9.value;
//			strObj = txtFAX9;
//		}
//		//二次連絡先９　ＦＡＸ
//		if (rdoFax10.checked==true) {
//			strFax = txtFAX10.value;
//			strObj = txtFAX10;
//		}
//	} // if
//	} // with
//	//電話番号必須チェック
//	if(strFax.length==0) {
//		alert('ＦＡＸ番号がありません');
//		strObj.focus();
//		return;
//	}
//	//電話番号チェック
//	if (fncChkTel(strFax) == false) {
//		alert("ＦＡＸ番号が正しくありません");
//		strObj.focus();
//		return;
//	}
//    //メモ欄　文字数チェック　2014/12/22 T.Ono add 2014改善開発 No2
//    if (fncGetByte(Form1.txtFAX_REN.value) > 140) {
//        alert("メモ欄は全角70文字以内で入力して下さい");
//        Form1.txtFAX_REN.focus();
//        return false;
//    }

//	Form1.hdnSNDFAXNO.value = strFax;
//	//Form1.btnTelHas.disabled = true;      //下に移動 2014/12/24 T.Ono add 2014改善開発 No4
//	//--- ↓2005.09.25 ADD Falcon↓ ---
//	strFAX_TITLE = Form1.cboFAX_TITLE.options[Form1.cboFAX_TITLE.selectedIndex].text;
//	if(strFAX_TITLE.indexOf(":")!=-1) {
//		strFAX_TITLE=strFAX_TITLE.split(":")[1];
//	}else if(strFAX_TITLE.indexOf("：")!=-1) {
//		strFAX_TITLE=strFAX_TITLE.split("：")[1];
//	}
//    Form1.hdnFAX_TITLE.value = strFAX_TITLE;
//    //--- ↑2005.09.25 ADD Falcon↑ ---
//	//2014/12/22 T.Ono add 2014改善開発 No4 START
//	parent.opener.frames('data').Form1.hdnREN_FAXTITLE.value = strFAX_TITLE;              //FAXタイトル
//	parent.opener.frames('data').Form1.hdnFAX_TITLE_CD.value = Form1.cboFAX_TITLE.value;  //FAXタイトルコード
//	parent.opener.frames('data').Form1.hdnREN_FAXREN.value = Form1.txtFAX_REN.value;      //メモ欄

//	if (Form1.hdnBtnKBN.value == "2") {
//	    Form1.hdnPreviewFlg.value = '1'
//	    Form1.btnTelHas.disabled = false;                                                   //プレビュー確認済みフラグ
//        //2015/12/09 w.ganeko 2015改善開発 №2
//	    Form1.btnSoExit.disabled = false;
//    }else{
//        Form1.btnTelHas.disabled = true;　　　　　　　　　　　　　　　　　　　　　　　　　//btnTelHas無効化
//        parent.opener.frames('data').Form1.hdnSEND_FAX_FLG.value = '1'                    //FAX・メール送信フラグ
//    }
//    //2014/12/22 T.Ono add 2014改善開発 No4 END

//    doPostBack('btnTelHas', ''); 
//    
//	
//}
////↓2012/03/23 ADD W.GANEKO↓
////**************************************
////ＦＡＸ＆メール送信
////**************************************
//function fncDial_FaxMail() {
//	var strRes;
//	//入力禁止文字チェック
//	if(fncChkChar()==false){
//		return false;
//	}

//    //2014/12/26 T.Ono add 2014改善開発 No4 START
////    strRes = confirm("ＦＡＸとメールを送信してよろしいですか？");
////	if (strRes==false){
////		return;
////    }
//    if (Form1.hdnBtnKBN.value == "2") {
//        alert('  プレビューを作成します  ');
//    } else {
//        strRes = confirm("ＦＡＸとメールを送信してよろしいですか？");
//        if (strRes == false) {
//            return;
//        }
//    }
//    //2014/12/26 T.Ono mod 2014改善開発 No4 END

//	var strFax
//	var strObj
//	var strObj2
//	with(Form1) {
//		var i;
//	    i = 1;
//		while(i <= 30){
//		    //ＦＡＸ
//            //2015/12/09 w.ganeko 2015改善開発 №2
//			//obj = document.getElementById("rdoFaxMail" + i);
//			obj = document.getElementById("chkFaxMail_" + i);
//			if (obj.checked == true) { // チェックあり！
//				strFax  = document.getElementById("txtFAX" + i).value;
//				strObj  = document.getElementById("txtFAX" + i);
//				break;
//			}
//			i++;
//	    }
//	if (false){
//		//一次連絡先　ＦＡＸ＆メール
//		if (rdoFaxMail1.checked==true) {
//			strFax = txtFAX1.value;
//			strObj = txtFAX1;
//		}
//		//二次連絡先１　ＦＡＸ
//		if (rdoFaxMail2.checked==true) {
//			strFax = txtFAX2.value;
//			strObj = txtFAX2;
//		}
//		//二次連絡先２　ＦＡＸ
//		if (rdoFaxMail3.checked==true) {
//			strFax = txtFAX3.value;
//			strObj = txtFAX3;
//		}
//		//二次連絡先３　ＦＡＸ
//		if (rdoFaxMail4.checked==true) {
//			strFax = txtFAX4.value;
//			strObj = txtFAX4;
//		}
//		
//		// 2008/11/04 T.Watabe add
//		//二次連絡先４　ＦＡＸ
//		if (rdoFaxMail5.checked==true) {
//			strFax = txtFAX5.value;
//			strObj = txtFAX5;
//		}
//		//二次連絡先５　ＦＡＸ
//		if (rdoFaxMail6.checked==true) {
//			strFax = txtFAX6.value;
//			strObj = txtFAX6;
//		}
//		//二次連絡先６　ＦＡＸ
//		if (rdoFaxMail7.checked==true) {
//			strFax = txtFAX7.value;
//			strObj = txtFAX7;
//		}
//		//二次連絡先７　ＦＡＸ
//		if (rdoFaxMail8.checked==true) {
//			strFax = txtFAX8.value;
//			strObj = txtFAX8;
//		}
//		//二次連絡先８　ＦＡＸ
//		if (rdoFaxMail9.checked==true) {
//			strFax = txtFAX9.value;
//			strObj = txtFAX9;
//		}
//		//二次連絡先９　ＦＡＸ
//		if (rdoFaxMail10.checked==true) {
//			strFax = txtFAX10.value;
//			strObj = txtFAX10;
//		}
//	} // if
//	} // with
//	//電話番号必須チェック
//	if(strFax.length==0) {
//		alert('ＦＡＸ番号がありません');
//		strObj.focus();
//		return;
//	}
//	//電話番号チェック
//	if (fncChkTel(strFax) == false) {
//		alert("ＦＡＸ番号が正しくありません");
//		strObj.focus();
//		return;
//    }
//    //メモ欄　文字数チェック　2014/12/22 T.Ono add 2014改善開発 No2
//    if (fncGetByte(Form1.txtFAX_REN.value) > 140) {
//        alert("メモ欄は全角70文字以内で入力して下さい");
//        Form1.txtFAX_REN.focus();
//        return false;
//    }
//	var strMailLen = "";
//	var strMailPassLen = "";
//	var strMail;
//	var strMailPass;
//	var strMailCnt = false;
//	with(Form1) {
//		var i;
//	    i = 1;
//		while(i <= 30){
//			//ＦＡＸ
//			strMail  = document.getElementById("txtSPOT_MAIL_" + i).value;
//			if(strMail.length != 0) {
//				strMailCnt = true;
//				if (strMailLen != ""){
//					strMailLen = strMailLen + "|";
//					strMailPassLen = strMailPassLen + '|';
//				}
//				strMailLen = strMailLen + strMail;
//				strMailPassLen = strMailPassLen + document.getElementById("hdnREN_" + i + "_MAILPASS").value;
//			}
//			i++;
//	    }
//	} 
//	//メール必須チェック
//	if(!strMailCnt) {
//		alert('メールアドレスがありません');
//		return;
//	}
//	//メール形式チェック
//	//if (fncChkTel(strMail) == false) {
//		//alert("メールアドレスが正しくありません");
//		//strObj2.focus();
//		//return;
//	//}	
//	Form1.hdnSNDFAXNO.value = strFax;
//	//Form1.btnTelHas.disabled = true;  //下に移動 2014/12/26 T.Ono add 2014改善開発 No4
//	Form1.hdnSNDMAIL.value = strMailLen;
//	Form1.hdnSNDMAILPASS.value = strMailPassLen;
//	strFAX_TITLE = Form1.cboFAX_TITLE.options[Form1.cboFAX_TITLE.selectedIndex].text;
//	if(strFAX_TITLE.indexOf(":")!=-1) {
//		strFAX_TITLE=strFAX_TITLE.split(":")[1];
//	}else if(strFAX_TITLE.indexOf("：")!=-1) {
//		strFAX_TITLE=strFAX_TITLE.split("：")[1];
//	}
//	Form1.hdnFAX_TITLE.value = strFAX_TITLE;
//	//2014/12/26 T.Ono add 2014改善開発 No4 START
//	parent.opener.frames('data').Form1.hdnREN_FAXTITLE.value = strFAX_TITLE;              //FAXタイトル
//	parent.opener.frames('data').Form1.hdnFAX_TITLE_CD.value = Form1.cboFAX_TITLE.value;  //FAXタイトルコード
//	parent.opener.frames('data').Form1.hdnREN_FAXREN.value = Form1.txtFAX_REN.value;      //メモ欄

//	if (Form1.hdnBtnKBN.value == "2") {
//	    Form1.hdnPreviewFlg.value = '1'                                                   //プレビュー確認済みフラグ
//	    Form1.btnTelHas.disabled = false;
//	    //2015/12/09 w.ganeko 2015改善開発 №2
//	    Form1.btnSoExit.disabled = false;
//	} else {
//	    Form1.btnTelHas.disabled = true; //btnTelHas無効化
//	    parent.opener.frames('data').Form1.hdnSEND_FAX_FLG.value = '1'                    //FAX・メール送信フラグ
//	}
//	//2014/12/26 T.Ono add 2014改善開発 No4 END
//	doPostBack('btnTelHas',''); 

//}
////**************************************
////メール送信
////**************************************
//function fncDial_Mail() {
//	var strRes;
//	//入力禁止文字チェック
//	if(fncChkChar()==false){
//		return false;
//	}

//    //2014/12/26 T.Ono mod 2014改善開発 No4 START
////	strRes = confirm("メールを一斉送信してよろしいですか？");
////	if (strRes==false){
////		return;
////    }
//    if (Form1.hdnBtnKBN.value == "2") {
//        alert('  プレビューを作成します  ');
//    } else {
//        strRes = confirm("メールを一斉送信してよろしいですか？");
//        if (strRes == false) {
//            return;
//        }
//    }
//    //2014/12/26 T.Ono mod 2014改善開発 No4 END

//    //メモ欄　文字数チェック　2014/12/22 T.Ono add 2014改善開発 No2
//    if (fncGetByte(Form1.txtFAX_REN.value) > 140) {
//        alert("メモ欄は全角70文字以内で入力して下さい");
//        Form1.txtFAX_REN.focus();
//        return false;
//    }
//	var strMail
//	var strMailLen = "";
//	var strMailPassLen = "";
//	var strObj2
//	var strMailCnt = false;
//	with(Form1) {
//		var i;
//	    i = 1;
//		while(i <= 30){
//			//ＦＡＸ
//			strMail  = document.getElementById("txtSPOT_MAIL_" + i).value;
//			if(strMail.length != 0) {
//				strMailCnt = true;
//				if (strMailLen != ""){
//					strMailLen = strMailLen + "|";
//					strMailPassLen = strMailPassLen + '|';
//				}
//				strMailLen = strMailLen + strMail;
//				strMailPassLen = strMailPassLen + document.getElementById("hdnREN_" + i + "_MAILPASS").value;
//			}
//			i++;
//	    }
//	} // with
//	//メール必須チェック
//	if(!strMailCnt) {
//		alert('メールアドレスがありません');
//		return;
//	}
//	Form1.hdnSNDMAIL.value = strMailLen;
//	Form1.hdnSNDMAILPASS.value = strMailPassLen;
//	//Form1.btnTelHas.disabled = true;  //下に移動 2014/12/26 T.Ono add 2014改善開発 No4
//	//--- ↓2005.09.25 ADD Falcon↓ ---
//	strFAX_TITLE = Form1.cboFAX_TITLE.options[Form1.cboFAX_TITLE.selectedIndex].text;
//	if(strFAX_TITLE.indexOf(":")!=-1) {
//		strFAX_TITLE=strFAX_TITLE.split(":")[1];
//	}else if(strFAX_TITLE.indexOf("：")!=-1) {
//		strFAX_TITLE=strFAX_TITLE.split("：")[1];
//	}
//	Form1.hdnFAX_TITLE.value = strFAX_TITLE;
//	//--- ↑2005.09.25 ADD Falcon↑ ---
//	//2014/12/26 T.Ono add 2014改善開発 No4 START
//	parent.opener.frames('data').Form1.hdnREN_FAXTITLE.value = strFAX_TITLE;              //FAXタイトル
//	parent.opener.frames('data').Form1.hdnFAX_TITLE_CD.value = Form1.cboFAX_TITLE.value;  //FAXタイトルコード
//	parent.opener.frames('data').Form1.hdnREN_FAXREN.value = Form1.txtFAX_REN.value;      //メモ欄

//	if (Form1.hdnBtnKBN.value == "2") {
//	    Form1.hdnSNDFAXNO.value = '';                                                     //プレビューに出ない様、FAX番号を消す
//        Form1.hdnPreviewFlg.value = '1'                                                   //プレビュー確認済みフラグ
//	    Form1.btnTelHas.disabled = false;
//	    //2015/12/09 w.ganeko 2015改善開発 №2
//	    Form1.btnSoExit.disabled = false;
//	} else {
//	    Form1.btnTelHas.disabled = true; //btnTelHas無効化
//	    parent.opener.frames('data').Form1.hdnSEND_FAX_FLG.value = '1'                    //FAX・メール送信フラグ
//	}    
//    //2014/12/26 T.Ono add 2014改善開発 No4 END
//	doPostBack('btnTelHas','');

//}
//2015/12/09 w.ganeko del 2015改善開発 №2 end
//**************************************
//doPostBack
//**************************************
function doPostBack(strCtl,strFlg) {
	Form1.target="ifFax";
	__doPostBack(strCtl,strFlg); 
	Form1.target="";
}
//↑2005/04/26 ADD Falcon↑
//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_onclick() {
	//var strRes;
	//strRes = confirm("終了してよろしいですか？");
	//if (strRes==false){
	//	return;
	//}
	parent.opener.frames('data').Form1.btnRenraku.focus();
	window.close();
}
//2015/12/09 ADD w.ganeko 2015改善案件 №2 start
//**************************************
//終了ボタン押下時の処理
//**************************************
function btnExit_Check_onclick() {
    var strRes;
    strRes = document.getElementById("hdnBtnKBN").value;
    if (strRes != "1" && strRes != "") {
        alert("FAXまたはメールが送信されていません。");
    	return;
    }
    parent.opener.frames('data').Form1.btnRenraku.focus();
    window.close();
}
//2015/12/09 ADD w.ganeko 2015改善案件 №2 end
//--- ↓2005/09/09 ADD Falcon↓ ---
//コンボボックスの名称を返す
function getCboName(obj){
	var strText;
	with(Form1){
		strText=obj.options[obj.selectedIndex].text;
	}
	if(strText.indexOf(":")!=-1) {
		strText=strText.split(":")[1];
	}else if(strText.indexOf("：")!=-1) {
		strText=strText.split("：")[1];
	}
	return strText;
}
//--- ↑2005/09/09 ADD Falcon↑ ---
// 2012/03/30 W.GANEKO add
//**************************************
// ほかの監視ｾﾝﾀｰには見せない
//**************************************
function fncOTHER_KANSI_CENTER() {
    //2016/02/02 w.ganeko 2015改善開発 №2 第2弾 start
    //2016/05/06 w.ganeko start
//    for (i = 1; i <= 30; i++) {
//        document.getElementById('chkFaxMail_' + i).style.display = 'none';
//        document.getElementById('lblFaxMail_' + i).style.display = 'none';
//        document.getElementById('tdFaxMail_' + i).style.textAlign = 'left';
//    }
    //2016/05/06 w.ganeko end
    //    //2016/02/02 w.ganeko 2015改善開発 №2 第2弾 end
    if (parent.opener.frames('data').Form1.hdnOTHER_KANSI_CENTER.value == "1") { // ほかの監視ｾﾝﾀｰ？
            //2015/12/14 w.ganeko 2015改善開発 №2 start
		    //document.getElementById('tagMail1').style.display='none';
		    document.getElementById("menylbl").innerHTML = "同時送信可能な件数は<br />FAX:10件です。";
		    //2015/12/14 w.ganeko 2015改善開発 №2 end
		    document.getElementById('btnTelHas').value = '電話ＦＡＸ\r\n発信';
	        document.getElementById('btnPreview').value = 'ＦＡＸプレビュー'; //2014/12/15 T.Ono add 2014改善開発 No4
            //2016/05/02 w.ganeko start
//	        for(i = 1;i<= 30;i++){
//	            document.getElementById('tagFaxMail' + i).style.display = 'none';
//	            //2015/12/14 w.ganeko 2015改善開発 №2 start
//	            //2016/02/02 w.ganeko 2015改善開発 №2 第2弾 start
//	            //document.getElementById('chkFaxMail_' + i).style.display = 'none';
//	            //document.getElementById('lblFaxMail_' + i).style.display = 'none';
//	            //document.getElementById('tdFaxMail_' + i).style.textAlign = 'left';
//	            //2016/02/02 w.ganeko 2015改善開発 №2 第2弾 end
//	            //2015/12/14 w.ganeko 2015改善開発 №2 end
//	        }
	        //2016/05/02 w.ganeko end
	        document.getElementById('tblFAXServer').style.display = 'none'; //2014/02/03 T.Ono add 監視改善2013
	    }
	    if (Form1.hdnPreviewFlg.value != "1"){
            Form1.btnSoExit.disabled = true;
        }
}
//2013/08/22 T.Ono add 監視改善2013№1
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSetFocus() {
    Form1.txtACBNM.focus()
}
//**************************************
//コンボボックスからのフォーカス移動
//**************************************
function fncSelectValue() {
    Form1.hdnFAX_TITLE_SELECT.value = Form1.cboFAX_TITLE.value
}
//2014/02/04 T.Ono add 監視改善2013
//**************************************
//FAXサーバー選択結果の取得
//**************************************
function fncSetFAXServerKBN() {
    //上段にチェック = 1 SEND_FAX_SERVER1を使用
    //下段にチェック = 2 SEND_FAX_SERVER2を使用
    var res = 1;
    with (Form1) {
        var i;
        i = 1;
        while (i <= 2) {
            obj = document.getElementById("rdoFAXServer" + i);
            if (obj.checked == true) {
                res = i;
                break;
            }
            i++;
        }
    }
    return res;
}
//2014/12/25 T.Ono add 2014改善開発
//**************************************
//ラジオボタンにより発信ボタンの状態を変更
//**************************************
//2015/12/09 w.ganeko mode 2015改善開発 №2
//function fncClickRadio() {
function fncClickRadio(Mode) {
    var DialFlg;
    var chkcnt = "0";
    var PreviewFlg = Form1.hdnPreviewFlg.value;  //プレビュー確認済みフラグ取得
    //2015/12/09 w.ganeko add 2015改善開発 №2
    with (Form1) {
        var i;
        i = 1;
        while (i <= 30) {
            //2015/12/09 dell w.ganeko 2015改善開発 №2 start
            //obj = document.getElementById("rdoMail1");
            //if (obj.checked == true) {
            //    DialFlg = "4";
            //    break;
            //}
            //2015/12/09 dell w.ganeko 2015改善開発 №2 end
                obj = document.getElementById("rdoTel1_" + i);
                if (obj.checked == true) {
                   DialFlg = "1";
                   chkcnt = "1";
                   fncTel_chkoff(Mode);
                }
                obj = document.getElementById("rdoTel2_" + i);
                if (obj.checked == true) {
                   DialFlg = "1";
                   chkcnt = "1";
                   fncTel_chkoff(Mode);
                }
                obj = document.getElementById("rdoTel3_" + i);
                if (obj.checked == true) {
                   DialFlg = "1";
                   chkcnt = "1";
                   fncTel_chkoff(Mode);
                }
                //2015/12/09 w.ganeko 2015改善開発 №2
                //obj = document.getElementById("rdoFax" + i);
                obj = document.getElementById("chkFax_" + i);
                if (obj.checked == true) {
                    DialFlg = "2";
                    chkcnt = "1";
                    fncTel_chkoff(Mode);
                }
                //2015/12/09 w.ganeko 2015改善開発 №2
                //obj = document.getElementById("rdoFaxMail" + i);
                //2016/05/06 w.ganeko start
//                obj = document.getElementById("chkFaxMail_" + i);
//                if (obj.checked == true) {
//                   DialFlg = "3";
//                   chkcnt = "1";
//                   fncTel_chkoff(Mode);
//                }
                //2016/05/06 w.ganeko end
                //2015/12/09 w.ganeko 2015改善開発 №2 start
                obj = document.getElementById("chkMail_" + i);
                if (obj.checked == true) {
                   DialFlg = "4";
                   chkcnt = "1";
                   fncTel_chkoff(Mode);
                }
            //2015/12/09 w.ganeko 2015改善開発 №2 end
            i++;
        }
        if(chkcnt == "0"){
           obj = document.getElementById("rdoTel1_4");
           obj.checked = true;
           DialFlg = "1";
        }
    }

    //alert(DialFlg + ":" + PreviewFlg);
    if (DialFlg == "1") {
        //電話は押下可
        Form1.btnTelHas.disabled = false;
    } else if (PreviewFlg == "1") {
    　　//電話以外、プレビュー確認済
        Form1.btnTelHas.disabled = false;
    } else {
        //電話以外、プレビュー確認未
        Form1.btnTelHas.disabled = true;
    }
}
//2015/12/09 w.ganeko 2015改善開発 №2 start
//**************************************
//電話発信
//**************************************
function fncTel_chkoff(mode) {
    with (Form1) {
        var i;
        i = 1;
        while (i <= 30) {
            if (mode == "1") {
                obj = document.getElementById("rdoTel1_" + i);
                if (obj.checked == true) {
                    obj.checked = false;
                    break;
                }
                obj = document.getElementById("rdoTel2_" + i);
                if (obj.checked == true) {
                    obj.checked = false;
                    break;
                }
                obj = document.getElementById("rdoTel3_" + i);
                if (obj.checked == true) {
                    obj.checked = false;
                    break;
                }
            } else if (mode == "2") {
                obj = document.getElementById("chkFax_" + i);
                if (obj.checked == true) {
                    obj.checked = false;
                }
                //2016/05/06 w.ganeko start
//                obj = document.getElementById("chkFaxMail_" + i);
//                if (obj.checked == true) {
//                    obj.checked = false;
//                }
                //2016/05/06 w.ganeko end
                obj = document.getElementById("chkMail_" + i);
                if (obj.checked == true) {
                    obj.checked = false;
                }
            }
            i++;
        }
    }
}
//2015/12/09 w.ganeko 2015改善開発 №2 end
//2015/01/07 T.Ono add 2014改善開発 №4
//**************************************
//改行を削除する
//**************************************
function fncDelKAIGYO(obj) {

    strTemp = obj.value.replace(/\r\n/g, "");
    obj.value = strTemp

}