namespace EncoderCalibration
{
    partial class ManualTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMUOpen = new System.Windows.Forms.Button();
            this.btnMUClose = new System.Windows.Forms.Button();
            this.btnGetInterface = new System.Windows.Forms.Button();
            this.btnSetInterface = new System.Windows.Forms.Button();
            this.btnReadChipRev = new System.Windows.Forms.Button();
            this.btnUseRev = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRtn = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadParam = new System.Windows.Forms.Button();
            this.btnWriteParam = new System.Windows.Forms.Button();
            this.btnReadParam = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteCal = new System.Windows.Forms.Button();
            this.btnGetCal = new System.Windows.Forms.Button();
            this.lblRevID = new System.Windows.Forms.Label();
            this.btnGetAMasterTrackAdj = new System.Windows.Forms.Button();
            this.btnGetANoniusTrackAdj = new System.Windows.Forms.Button();
            this.btnGetParam_MU_MPC = new System.Windows.Forms.Button();
            this.btnSetATrackAdj = new System.Windows.Forms.Button();
            this.btnSetCalibration = new System.Windows.Forms.Button();
            this.btnActiveCal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAcqRawData = new System.Windows.Forms.Button();
            this.btnDeactiveCalConfig = new System.Windows.Forms.Button();
            this.btnReadLastErr = new System.Windows.Forms.Button();
            this.btnCalAnalyze = new System.Windows.Forms.Button();
            this.btnGetCalAnalRltLog = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnGetRelativeAdj = new System.Windows.Forms.Button();
            this.btnIsAdjustable = new System.Windows.Forms.Button();
            this.btnAdjustAnlByRlt = new System.Windows.Forms.Button();
            this.btnDelAnalRlt = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMUOpen
            // 
            this.btnMUOpen.Location = new System.Drawing.Point(12, 12);
            this.btnMUOpen.Name = "btnMUOpen";
            this.btnMUOpen.Size = new System.Drawing.Size(131, 30);
            this.btnMUOpen.TabIndex = 0;
            this.btnMUOpen.Text = "MU Open";
            this.btnMUOpen.UseVisualStyleBackColor = true;
            this.btnMUOpen.Click += new System.EventHandler(this.btnMUOpen_Click);
            // 
            // btnMUClose
            // 
            this.btnMUClose.Location = new System.Drawing.Point(12, 782);
            this.btnMUClose.Name = "btnMUClose";
            this.btnMUClose.Size = new System.Drawing.Size(84, 30);
            this.btnMUClose.TabIndex = 0;
            this.btnMUClose.Text = "MU Close";
            this.btnMUClose.UseVisualStyleBackColor = true;
            this.btnMUClose.Click += new System.EventHandler(this.btnMUClose_Click);
            // 
            // btnGetInterface
            // 
            this.btnGetInterface.Enabled = false;
            this.btnGetInterface.Location = new System.Drawing.Point(193, 48);
            this.btnGetInterface.Name = "btnGetInterface";
            this.btnGetInterface.Size = new System.Drawing.Size(131, 30);
            this.btnGetInterface.TabIndex = 1;
            this.btnGetInterface.Text = "Get Interface";
            this.btnGetInterface.UseVisualStyleBackColor = true;
            this.btnGetInterface.Click += new System.EventHandler(this.btnGetInterface_Click);
            // 
            // btnSetInterface
            // 
            this.btnSetInterface.Location = new System.Drawing.Point(12, 48);
            this.btnSetInterface.Name = "btnSetInterface";
            this.btnSetInterface.Size = new System.Drawing.Size(131, 30);
            this.btnSetInterface.TabIndex = 2;
            this.btnSetInterface.Text = "Set Interface";
            this.btnSetInterface.UseVisualStyleBackColor = true;
            this.btnSetInterface.Click += new System.EventHandler(this.btnSetInterface_Click);
            // 
            // btnReadChipRev
            // 
            this.btnReadChipRev.Location = new System.Drawing.Point(12, 84);
            this.btnReadChipRev.Name = "btnReadChipRev";
            this.btnReadChipRev.Size = new System.Drawing.Size(131, 30);
            this.btnReadChipRev.TabIndex = 3;
            this.btnReadChipRev.Text = "Read Revision ID";
            this.btnReadChipRev.UseVisualStyleBackColor = true;
            this.btnReadChipRev.Click += new System.EventHandler(this.btnReadChipRev_Click);
            // 
            // btnUseRev
            // 
            this.btnUseRev.Location = new System.Drawing.Point(12, 120);
            this.btnUseRev.Name = "btnUseRev";
            this.btnUseRev.Size = new System.Drawing.Size(131, 30);
            this.btnUseRev.TabIndex = 3;
            this.btnUseRev.Text = "Use Revision ID";
            this.btnUseRev.UseVisualStyleBackColor = true;
            this.btnUseRev.Click += new System.EventHandler(this.btnUseRev_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // lblRtn
            // 
            this.lblRtn.AutoSize = true;
            this.lblRtn.ForeColor = System.Drawing.Color.Blue;
            this.lblRtn.Location = new System.Drawing.Point(190, 790);
            this.lblRtn.Name = "lblRtn";
            this.lblRtn.Size = new System.Drawing.Size(45, 14);
            this.lblRtn.TabIndex = 5;
            this.lblRtn.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(769, 743);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnLoadParam
            // 
            this.btnLoadParam.Location = new System.Drawing.Point(12, 192);
            this.btnLoadParam.Name = "btnLoadParam";
            this.btnLoadParam.Size = new System.Drawing.Size(131, 30);
            this.btnLoadParam.TabIndex = 6;
            this.btnLoadParam.Text = "Load Param";
            this.btnLoadParam.UseVisualStyleBackColor = true;
            this.btnLoadParam.Click += new System.EventHandler(this.btnLoadParam_Click);
            // 
            // btnWriteParam
            // 
            this.btnWriteParam.Location = new System.Drawing.Point(12, 228);
            this.btnWriteParam.Name = "btnWriteParam";
            this.btnWriteParam.Size = new System.Drawing.Size(131, 30);
            this.btnWriteParam.TabIndex = 6;
            this.btnWriteParam.Text = "Write Param";
            this.btnWriteParam.UseVisualStyleBackColor = true;
            this.btnWriteParam.Click += new System.EventHandler(this.btnWriteParam_Click);
            // 
            // btnReadParam
            // 
            this.btnReadParam.Location = new System.Drawing.Point(53, 157);
            this.btnReadParam.Name = "btnReadParam";
            this.btnReadParam.Size = new System.Drawing.Size(131, 30);
            this.btnReadParam.TabIndex = 6;
            this.btnReadParam.Text = "Read Param";
            this.btnReadParam.UseVisualStyleBackColor = true;
            this.btnReadParam.Click += new System.EventHandler(this.btnReadParam_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Load configuration (virtual chip obj)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Write parameter to Chip";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Read parameter from Chip (to Virtual chip obj)";
            // 
            // btnDeleteCal
            // 
            this.btnDeleteCal.Location = new System.Drawing.Point(12, 746);
            this.btnDeleteCal.Name = "btnDeleteCal";
            this.btnDeleteCal.Size = new System.Drawing.Size(131, 30);
            this.btnDeleteCal.TabIndex = 6;
            this.btnDeleteCal.Text = "Cal Delete";
            this.btnDeleteCal.UseVisualStyleBackColor = true;
            this.btnDeleteCal.Click += new System.EventHandler(this.btnDeleteCal_Click);
            // 
            // btnGetCal
            // 
            this.btnGetCal.Location = new System.Drawing.Point(12, 264);
            this.btnGetCal.Name = "btnGetCal";
            this.btnGetCal.Size = new System.Drawing.Size(131, 30);
            this.btnGetCal.TabIndex = 6;
            this.btnGetCal.Text = "Get Calibration";
            this.btnGetCal.UseVisualStyleBackColor = true;
            this.btnGetCal.Click += new System.EventHandler(this.btnGetCal_Click);
            // 
            // lblRevID
            // 
            this.lblRevID.AutoSize = true;
            this.lblRevID.ForeColor = System.Drawing.Color.Red;
            this.lblRevID.Location = new System.Drawing.Point(149, 92);
            this.lblRevID.Name = "lblRevID";
            this.lblRevID.Size = new System.Drawing.Size(30, 14);
            this.lblRevID.TabIndex = 8;
            this.lblRevID.Text = "ID: ";
            // 
            // btnGetAMasterTrackAdj
            // 
            this.btnGetAMasterTrackAdj.Location = new System.Drawing.Point(522, 266);
            this.btnGetAMasterTrackAdj.Name = "btnGetAMasterTrackAdj";
            this.btnGetAMasterTrackAdj.Size = new System.Drawing.Size(186, 64);
            this.btnGetAMasterTrackAdj.TabIndex = 6;
            this.btnGetAMasterTrackAdj.Text = "MU_Calibration_getAnalogMasterTrackAdjustments";
            this.btnGetAMasterTrackAdj.UseVisualStyleBackColor = true;
            this.btnGetAMasterTrackAdj.Click += new System.EventHandler(this.btnGetAMasterTrackAdj_Click);
            // 
            // btnGetANoniusTrackAdj
            // 
            this.btnGetANoniusTrackAdj.Location = new System.Drawing.Point(714, 266);
            this.btnGetANoniusTrackAdj.Name = "btnGetANoniusTrackAdj";
            this.btnGetANoniusTrackAdj.Size = new System.Drawing.Size(186, 64);
            this.btnGetANoniusTrackAdj.TabIndex = 6;
            this.btnGetANoniusTrackAdj.Text = "MU_Calibration_getAnalogNoniusTrackAdjustments";
            this.btnGetANoniusTrackAdj.UseVisualStyleBackColor = true;
            this.btnGetANoniusTrackAdj.Click += new System.EventHandler(this.btnGetANoniusTrackAdj_Click);
            // 
            // btnGetParam_MU_MPC
            // 
            this.btnGetParam_MU_MPC.Location = new System.Drawing.Point(522, 192);
            this.btnGetParam_MU_MPC.Name = "btnGetParam_MU_MPC";
            this.btnGetParam_MU_MPC.Size = new System.Drawing.Size(131, 30);
            this.btnGetParam_MU_MPC.TabIndex = 6;
            this.btnGetParam_MU_MPC.Text = "get MU_MPC";
            this.btnGetParam_MU_MPC.UseVisualStyleBackColor = true;
            this.btnGetParam_MU_MPC.Click += new System.EventHandler(this.btnGetParam_MU_MPC_Click);
            // 
            // btnSetATrackAdj
            // 
            this.btnSetATrackAdj.Location = new System.Drawing.Point(330, 266);
            this.btnSetATrackAdj.Name = "btnSetATrackAdj";
            this.btnSetATrackAdj.Size = new System.Drawing.Size(186, 64);
            this.btnSetATrackAdj.TabIndex = 6;
            this.btnSetATrackAdj.Text = "MU_Calibration_setCurrentAnalogTrackAdjustments";
            this.btnSetATrackAdj.UseVisualStyleBackColor = true;
            this.btnSetATrackAdj.Click += new System.EventHandler(this.btnSetATrackAdj_Click);
            // 
            // btnSetCalibration
            // 
            this.btnSetCalibration.Location = new System.Drawing.Point(53, 300);
            this.btnSetCalibration.Name = "btnSetCalibration";
            this.btnSetCalibration.Size = new System.Drawing.Size(131, 30);
            this.btnSetCalibration.TabIndex = 6;
            this.btnSetCalibration.Text = "Set Calibration";
            this.btnSetCalibration.UseVisualStyleBackColor = true;
            this.btnSetCalibration.Click += new System.EventHandler(this.btnSetCalibration_Click);
            // 
            // btnActiveCal
            // 
            this.btnActiveCal.Location = new System.Drawing.Point(12, 336);
            this.btnActiveCal.Name = "btnActiveCal";
            this.btnActiveCal.Size = new System.Drawing.Size(131, 30);
            this.btnActiveCal.TabIndex = 6;
            this.btnActiveCal.Text = "Active Cal Config";
            this.btnActiveCal.UseVisualStyleBackColor = true;
            this.btnActiveCal.Click += new System.EventHandler(this.btnActiveCal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(659, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // btnAcqRawData
            // 
            this.btnAcqRawData.Location = new System.Drawing.Point(12, 372);
            this.btnAcqRawData.Name = "btnAcqRawData";
            this.btnAcqRawData.Size = new System.Drawing.Size(131, 30);
            this.btnAcqRawData.TabIndex = 6;
            this.btnAcqRawData.Text = "Acquire Raw Data";
            this.btnAcqRawData.UseVisualStyleBackColor = true;
            this.btnAcqRawData.Click += new System.EventHandler(this.btnAcqRawData_Click);
            // 
            // btnDeactiveCalConfig
            // 
            this.btnDeactiveCalConfig.Location = new System.Drawing.Point(152, 336);
            this.btnDeactiveCalConfig.Name = "btnDeactiveCalConfig";
            this.btnDeactiveCalConfig.Size = new System.Drawing.Size(157, 30);
            this.btnDeactiveCalConfig.TabIndex = 6;
            this.btnDeactiveCalConfig.Text = "Deactive Cal Config";
            this.btnDeactiveCalConfig.UseVisualStyleBackColor = true;
            this.btnDeactiveCalConfig.Click += new System.EventHandler(this.btnDeactiveCalConfig_Click);
            // 
            // btnReadLastErr
            // 
            this.btnReadLastErr.ForeColor = System.Drawing.Color.Black;
            this.btnReadLastErr.Location = new System.Drawing.Point(522, 12);
            this.btnReadLastErr.Name = "btnReadLastErr";
            this.btnReadLastErr.Size = new System.Drawing.Size(131, 30);
            this.btnReadLastErr.TabIndex = 6;
            this.btnReadLastErr.Text = "Get Last Error";
            this.btnReadLastErr.UseVisualStyleBackColor = true;
            this.btnReadLastErr.Click += new System.EventHandler(this.btnReadLastErr_Click);
            // 
            // btnCalAnalyze
            // 
            this.btnCalAnalyze.Location = new System.Drawing.Point(53, 408);
            this.btnCalAnalyze.Name = "btnCalAnalyze";
            this.btnCalAnalyze.Size = new System.Drawing.Size(131, 30);
            this.btnCalAnalyze.TabIndex = 6;
            this.btnCalAnalyze.Text = "Cal Analyze";
            this.btnCalAnalyze.UseVisualStyleBackColor = true;
            this.btnCalAnalyze.Click += new System.EventHandler(this.btnCalAnalyze_Click);
            // 
            // btnGetCalAnalRltLog
            // 
            this.btnGetCalAnalRltLog.ForeColor = System.Drawing.Color.Black;
            this.btnGetCalAnalRltLog.Location = new System.Drawing.Point(193, 408);
            this.btnGetCalAnalRltLog.Name = "btnGetCalAnalRltLog";
            this.btnGetCalAnalRltLog.Size = new System.Drawing.Size(161, 30);
            this.btnGetCalAnalRltLog.TabIndex = 6;
            this.btnGetCalAnalRltLog.Text = "Get Cal Anal Result";
            this.btnGetCalAnalRltLog.UseVisualStyleBackColor = true;
            this.btnGetCalAnalRltLog.Click += new System.EventHandler(this.btnGetCalAnalRltLog_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(726, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 66);
            this.button2.TabIndex = 6;
            this.button2.Text = "AcquireRaw to Office Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnGetRelativeAdj
            // 
            this.btnGetRelativeAdj.Location = new System.Drawing.Point(360, 408);
            this.btnGetRelativeAdj.Name = "btnGetRelativeAdj";
            this.btnGetRelativeAdj.Size = new System.Drawing.Size(360, 30);
            this.btnGetRelativeAdj.TabIndex = 6;
            this.btnGetRelativeAdj.Text = "MU_Calibration_getRelativeMasterTrackAdjustments";
            this.btnGetRelativeAdj.UseVisualStyleBackColor = true;
            this.btnGetRelativeAdj.Click += new System.EventHandler(this.btnGetRelativeAdj_Click);
            // 
            // btnIsAdjustable
            // 
            this.btnIsAdjustable.ForeColor = System.Drawing.Color.Black;
            this.btnIsAdjustable.Location = new System.Drawing.Point(360, 444);
            this.btnIsAdjustable.Name = "btnIsAdjustable";
            this.btnIsAdjustable.Size = new System.Drawing.Size(360, 30);
            this.btnIsAdjustable.TabIndex = 6;
            this.btnIsAdjustable.Text = "MU_Calibration_isAnalogAnalyzeResultAdjustable";
            this.btnIsAdjustable.UseVisualStyleBackColor = true;
            this.btnIsAdjustable.Click += new System.EventHandler(this.btnIsAdjustable_Click);
            // 
            // btnAdjustAnlByRlt
            // 
            this.btnAdjustAnlByRlt.Location = new System.Drawing.Point(360, 480);
            this.btnAdjustAnlByRlt.Name = "btnAdjustAnlByRlt";
            this.btnAdjustAnlByRlt.Size = new System.Drawing.Size(360, 30);
            this.btnAdjustAnlByRlt.TabIndex = 6;
            this.btnAdjustAnlByRlt.Text = "MU_Calibration_adjustAnalogByAnalyzeResult";
            this.btnAdjustAnlByRlt.UseVisualStyleBackColor = true;
            this.btnAdjustAnlByRlt.Click += new System.EventHandler(this.btnAdjustAnlByRlt_Click);
            // 
            // btnDelAnalRlt
            // 
            this.btnDelAnalRlt.Location = new System.Drawing.Point(360, 516);
            this.btnDelAnalRlt.Name = "btnDelAnalRlt";
            this.btnDelAnalRlt.Size = new System.Drawing.Size(131, 30);
            this.btnDelAnalRlt.TabIndex = 6;
            this.btnDelAnalRlt.Text = "Delete Analyze Rlt";
            this.btnDelAnalRlt.UseVisualStyleBackColor = true;
            this.btnDelAnalRlt.Click += new System.EventHandler(this.btnDelAnalRlt_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(53, 552);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(301, 30);
            this.button3.TabIndex = 6;
            this.button3.Text = "PrintOptimizedNoniusTrackOffsetTable";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(519, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "label6";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(53, 588);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(301, 30);
            this.button4.TabIndex = 6;
            this.button4.Text = "setCurrentNoniusTrackOffsetTable";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(577, 710);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(131, 30);
            this.button5.TabIndex = 6;
            this.button5.Text = "ReadSens";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(577, 746);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(131, 30);
            this.button6.TabIndex = 6;
            this.button6.Text = "WriteCmd";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "MU_CMD_NO_FUNCTION",
            "MU_CMD_WRITE_ALL",
            "MU_CMD_WRITE_OFF",
            "MU_CMD_ABS_RESET",
            "MU_CMD_NON_VER",
            "MU_CMD_MT_RESET",
            "MU_CMD_MT_VER",
            "MU_CMD_SOFT_RESET",
            "MU_CMD_SOFT_PRES",
            "MU_CMD_SOFT_E2P_PRES",
            "MU_CMD_I2C_COM",
            "MU_CMD_EVENT_COUNT",
            "MU_CMD_SWITCH",
            "MU_CMD_CRC_VER",
            "MU_CMD_CRC_CALC",
            "MU_CMD_SET_MTC",
            "MU_CMD_RES_MTC",
            "MU_CMD_RESERVED0",
            "MU_CMD_MODEA_SPI",
            "MU_CMD_ROT_POS",
            "MU_CMD_ROT_POS_E2P"});
            this.comboBox1.Location = new System.Drawing.Point(393, 751);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(178, 22);
            this.comboBox1.TabIndex = 11;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(522, 110);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(131, 30);
            this.button7.TabIndex = 6;
            this.button7.Text = "get GAIN";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(526, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(526, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "label8";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(769, 444);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(131, 30);
            this.button8.TabIndex = 14;
            this.button8.Text = "getFrameCycle";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(769, 487);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(131, 35);
            this.button9.TabIndex = 15;
            this.button9.Text = "getClockFeq";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // ManualTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 824);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRevID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoadParam);
            this.Controls.Add(this.btnWriteParam);
            this.Controls.Add(this.btnReadParam);
            this.Controls.Add(this.btnDeleteCal);
            this.Controls.Add(this.btnGetCal);
            this.Controls.Add(this.btnGetAMasterTrackAdj);
            this.Controls.Add(this.btnGetANoniusTrackAdj);
            this.Controls.Add(this.btnGetParam_MU_MPC);
            this.Controls.Add(this.btnSetATrackAdj);
            this.Controls.Add(this.btnSetCalibration);
            this.Controls.Add(this.btnActiveCal);
            this.Controls.Add(this.btnAcqRawData);
            this.Controls.Add(this.btnDeactiveCalConfig);
            this.Controls.Add(this.btnReadLastErr);
            this.Controls.Add(this.btnCalAnalyze);
            this.Controls.Add(this.btnGetCalAnalRltLog);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnGetRelativeAdj);
            this.Controls.Add(this.btnIsAdjustable);
            this.Controls.Add(this.btnAdjustAnlByRlt);
            this.Controls.Add(this.btnDelAnalRlt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblRtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUseRev);
            this.Controls.Add(this.btnReadChipRev);
            this.Controls.Add(this.btnSetInterface);
            this.Controls.Add(this.btnGetInterface);
            this.Controls.Add(this.btnMUClose);
            this.Controls.Add(this.btnMUOpen);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ManualTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ManualTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMUOpen;
        private System.Windows.Forms.Button btnMUClose;
        private System.Windows.Forms.Button btnGetInterface;
        private System.Windows.Forms.Button btnSetInterface;
        private System.Windows.Forms.Button btnReadChipRev;
        private System.Windows.Forms.Button btnUseRev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLoadParam;
        private System.Windows.Forms.Button btnWriteParam;
        private System.Windows.Forms.Button btnReadParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteCal;
        private System.Windows.Forms.Button btnGetCal;
        private System.Windows.Forms.Label lblRevID;
        private System.Windows.Forms.Button btnGetAMasterTrackAdj;
        private System.Windows.Forms.Button btnGetANoniusTrackAdj;
        private System.Windows.Forms.Button btnGetParam_MU_MPC;
        private System.Windows.Forms.Button btnSetATrackAdj;
        private System.Windows.Forms.Button btnSetCalibration;
        private System.Windows.Forms.Button btnActiveCal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAcqRawData;
        private System.Windows.Forms.Button btnDeactiveCalConfig;
        private System.Windows.Forms.Button btnReadLastErr;
        private System.Windows.Forms.Button btnCalAnalyze;
        private System.Windows.Forms.Button btnGetCalAnalRltLog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnGetRelativeAdj;
        private System.Windows.Forms.Button btnIsAdjustable;
        private System.Windows.Forms.Button btnAdjustAnlByRlt;
        private System.Windows.Forms.Button btnDelAnalRlt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

