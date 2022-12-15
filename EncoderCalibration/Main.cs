using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderCalibration
{
    public delegate void delegateInsert(ListViewItem lvItem);
    public delegate void delegateClear(int maxCount);

    public partial class Main : Form
    {
        public delegateInsert del_ins;                  // main listview
        public delegateClear del_clr;                   // main listview

        // variable
        public static bool bFrmPosRefreshReq = new bool();

        // ICHaus Variable
        IntPtr muHandle;
        MU_InterfaceEnum interfaceType = MU_InterfaceEnum.MU_MB3U_SPI;
        byte revisionId = 0x20;     // #define MU_REV_MU200_0 0x20

        UInt32 masterPeriodCode;
        MU_Calibration_AnalogTrackAdjustments_ initialMasterAdjustments;
        MU_Calibration_AnalogTrackAdjustments_ initialNoniusAdjustments;
        IntPtr calibration;
        IntPtr analyzeResult;
        IntPtr analyzeResult2;

        const ulong numberOfSamples = 30000; // min. 16 (recommended 128) values per period
        const double acquireFrameCycleTime_s = 0;       //403E-6
        const double acquireClockFrequency_hz = 100000;

        UInt16[] masterRawData = new UInt16[numberOfSamples];
        UInt16[] noniusRawData = new UInt16[numberOfSamples];

        public Main()
        {
            InitializeComponent();
        }

        #region form load/closing event
        private void Main_Load(object sender, EventArgs e)
        {
            del_ins = new delegateInsert(Insert);
            del_clr = new delegateClear(Clear);
            Log.LogEvent += new LogEventHandler(lViewMain_Update);

            List<string> History = ANGFileInfo.ANGFileInfo.HistoryInfo;
            string[] str = History[History.Count - 1].Split(new char[] { '\t' });

            Log.LogStr(false, "Main", "Start program. Version " + str[0]);
            this.Text += " [" + str[0] + "]";

            Config.ReadConfigIni();

            WinStateUpdate();

            tmrUpdate.Enabled = true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogInVar Info = new LogInVar();
            Info = Util.LogInProcess();

            if (Info.iLvl > LogInVar.LGITPIC)
            {
            }
            else if (Info.iLvl < 0)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                Log.LogStr(false, "Warn",
                    string.Format("ID: {0}, Level: {1} has no access authority.", Info.szID, Info.iLvl));
                e.Cancel = true;
                return;
            }
        }
        #endregion

        #region Main List View
        private void Insert(ListViewItem lvItem)
        {
            lstViewMain.Items.Insert(0, lvItem);
            lstViewMain.AutoScrollOffset = lstViewMain.Items[lstViewMain.Items.Count - 1].Position;
            lstViewMain.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void Clear(int max)
        {
            if (lstViewMain.Items.Count > max) lstViewMain.Items.Clear();
        }
        string sOldMsg = "";

        public void lViewMain_Update(string who, string msg)
        {
            DateTime dt = DateTime.Now;
            ListViewItem newitem;

            try
            {
                if (sOldMsg.Equals(msg))
                {
                    sOldMsg = msg;
                    return;
                }
                else
                {
                    lstViewMain.Invoke(new MethodInvoker(delegate () { lstViewMain.BeginUpdate(); }));

                    newitem = new ListViewItem(dt.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo));
                    newitem.SubItems.Add(who);
                    newitem.SubItems.Add(msg);
                    if (who.ToUpper() == "FAULT") newitem.ForeColor = Color.Red;
                    else if (who.ToUpper() == "WARN") newitem.ForeColor = Color.Blue;

                    lstViewMain.Invoke(del_clr, new Object[] { 50 });
                    if (!sOldMsg.Equals(msg)) lstViewMain.Invoke(del_ins, new Object[] { newitem });

                    lstViewMain.Invoke(new MethodInvoker(delegate () { lstViewMain.EndUpdate(); }));
                    sOldMsg = msg;
                }
            }
            catch
            {
            }
        }
        #endregion

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            tmrUpdate.Enabled = false;

            if (bFrmPosRefreshReq)
            {
                WinStateUpdate();
                bFrmPosRefreshReq = false;
            }

            tableLayoutPanel3.SuspendLayout();
            lblGC_M.Text = Rlt.GC_M_Val.ToString("F1");
            lblGF_M.Text = Rlt.GF_M_Val.ToString("F3");
            lblGX_M.Text = Rlt.GX_M_Val.ToString("F4");
            lblVOSS_M.Text = Rlt.VOSS_M_Val.ToString("F0");
            lblVOSC_M.Text = Rlt.VOSC_M_Val.ToString("F0");
            lblPH_M.Text = Rlt.PH_M_Val.ToString("F3");

            lblGC_N.Text = Rlt.GC_N_Val.ToString("F1");
            lblGF_N.Text = Rlt.GF_N_Val.ToString("F3");
            lblGX_N.Text = Rlt.GX_N_Val.ToString("F4");
            lblVOSS_N.Text = Rlt.VOSS_N_Val.ToString("F0");
            lblVOSC_N.Text = Rlt.VOSC_N_Val.ToString("F0");
            lblPH_N.Text = Rlt.PH_N_Val.ToString("F3");

            lblGXErr_M.Text = Rlt.GX_MErr_Val.ToString("F4");
            lblVOSSErr_M.Text = Rlt.VOSS_MErr_Val.ToString("F0");
            lblVOSCErr_M.Text = Rlt.VOSC_MErr_Val.ToString("F0");
            lblPHErr_M.Text = Rlt.PH_MErr_Val.ToString("F3");

            lblGXErr_N.Text = Rlt.GX_NErr_Val.ToString("F4");
            lblVOSSErr_N.Text = Rlt.VOSS_NErr_Val.ToString("F0");
            lblVOSCErr_N.Text = Rlt.VOSC_NErr_Val.ToString("F0");
            lblPHErr_N.Text = Rlt.PH_NErr_Val.ToString("F3");

            lblNoniusInMin.Text = Rlt.nonius_InRange_Min.ToString("F1");
            lblNoniusInMax.Text = Rlt.nonius_InRange_Max.ToString("F1");

            lblBeforeAng.Text = "-2.15";
            lblAfterAng.Text = "3.215";

            tableLayoutPanel3.ResumeLayout(false);

            tmrUpdate.Enabled = true;
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogInVar Info = new LogInVar();
            Info = Util.LogInProcess();

            if (Info.iLvl > LogInVar.LGITPIC)
            {
                Config dlg = new Config();
                dlg.Show();
                Log.LogStr(false, "Main",
                    string.Format("Config setup form open, ID: {0}, Level: {1}", Info.szID, Info.iLvl));
            }
            else if (Info.iLvl < 0)
            {
                // login canceled
            }
            else
            {
                Log.LogStr(false, "Warn",
                    string.Format("ID: {0}, Level: {1} has no access authority.", Info.szID, Info.iLvl));
            }
        }
        
        void WinStateUpdate()
        {
            Screen scr = Screen.FromControl(this);

            switch (SysVar.iStartUpPos)
            {
                case 1: // Left
                    this.Size = new Size(scr.Bounds.Size.Width / 2, scr.WorkingArea.Height);
                    this.Location = new Point(0, 0);
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    this.Visible = true;
                    this.BringToFront();
                    break;
                case 2: // Right
                    this.Size = new Size(scr.Bounds.Size.Width / 2, scr.WorkingArea.Height);
                    Point frmLoc = new Point(scr.Bounds.Size.Width / 2, 0);
                    this.Location = frmLoc;
                    this.WindowState = FormWindowState.Normal;
                    this.ShowInTaskbar = true;
                    this.Visible = true;
                    this.BringToFront();
                    break;
            }
        }

        private void dllTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManualTest dlg = new ManualTest();
            dlg.Show();
        }

        #region calibration function
        private int interfacePrepare()
        {
            // get handle & open, get & set interface, get & set revision code, load param
            int iRtn = 0;
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);

            //// get handle & open
            //funcCallRet = DllImport.MU_Open(ref muHandle);
            //if (funcCallRet != MU_ErrorEnum.MU_OK)
            //{
            //    iRtn = -1;
            //    DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
            //    Log.TestLogStr(true, "Open", string.Format("errNo={0}, errType={1}, errText={2}",
            //        errNo.ToString(), errType.ToString(), errText.ToString()));
            //    return iRtn;
            //}
            //else
            //    Log.TestLogStr(true, "Open", string.Format("rtn = {0}", funcCallRet.ToString()));
            //// ***************************************************************************************

            //// 테스트 결과 get interface 에 대한 response 0 = No interface. --> 필요시 myWrapper에서 처리 (MP3U SPI로 처리함)
            //////// get & set interface
            ////////funcCallRet = DllImport.MU_GetInterface(muHandle, ref interfaceType);
            ////////if (funcCallRet != MU_ErrorEnum.MU_OK)
            ////////{
            ////////    iRtn = -2;
            ////////    DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
            ////////    Log.TestLogStr(true, "GetInterface", string.Format("errNo={0}, errType={1}, errText={2}",
            ////////        errNo.ToString(), errType.ToString(), errText.ToString()));
            ////////    return iRtn;
            ////////}
            ////////else
            ////////    Log.TestLogStr(true, "GetInterface", string.Format(
            ////////        "rtn = {0}, Interface = {1}", funcCallRet.ToString(), interfaceType.ToString()));

            ////////if (interfaceType != MU_InterfaceEnum.MU_MB3U_SPI)
            ////////{
            ////////    iRtn = -3;
            ////////    Log.TestLogStr(true, "GetInterface", "Interface type is not MB3U_SPI");
            ////////    return iRtn;
            ////////}

            ////If only one PC USB adapter is connected, an empty string has to be passed.
            //funcCallRet = DllImport.MU_SetInterface(muHandle, interfaceType, "");
            //if (funcCallRet != MU_ErrorEnum.MU_OK)
            //{
            //    iRtn = -4;
            //    DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
            //    Log.TestLogStr(true, "SetInterface", string.Format("errNo={0}, errType={1}, errText={2}",
            //        errNo.ToString(), errType.ToString(), errText.ToString()));
            //    return iRtn;
            //}
            //else
            //    Log.TestLogStr(true, "SetInterface", string.Format("rtn = {0}", funcCallRet.ToString()));
            // ***************************************************************************************

            // get and set chip revision code
            funcCallRet = DllImport.MU_ReadChipRevision(muHandle, ref revisionId);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -5;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "RdChipRev", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "RdChipRev", string.Format("rtn = {0}", funcCallRet.ToString()));

            if (revisionId != 0x20)
            {
                iRtn = -6;
                Log.TestLogStr(true, "RdChipRev", "Chip revision code is not 0x20");
                return iRtn;
            }

            funcCallRet =  DllImport.MU_UseRevision(muHandle, revisionId);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -7;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "UseChipRev", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "UseChipRev", string.Format("rtn = {0}", funcCallRet.ToString()));
            // ***************************************************************************************

            // load param (configuration file)
            string szFilePath = Application.StartupPath + "\\Config\\calibration.cfg";
            funcCallRet = DllImport.MU_LoadParams(muHandle, szFilePath);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -8;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "LoadParam", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "LoadParam", string.Format("rtn = {0}", funcCallRet.ToString()));
            // ***************************************************************************************

            // Write parameter to Chip
            funcCallRet = DllImport.MU_WriteParams2(muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -9;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "WriteParams2", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "WriteParams2", string.Format("rtn = {0}", funcCallRet.ToString()));

            return iRtn;
            // -1: MU_Open_Fail
            // -2: MU_GetInterface_Fail
            // -3: Attached_Interface_Wrong (attached interface is not MU_InterfaceEnum.MU_MB3U_SPI)
            // -4: MU_SetInterface_Fail
            // -5: MU_ReadChipRevision_Fail
            // -6: Attached_ChipRev_Wrong (attached chip revision is not MU200)
            // -7: MU_UseRevision_Fail
            // -8: MU_LoadParams_Fail
            // -9: MU_WriteParams_Fail
        }

        private int calibrationPrepare()
        {
            int iRtn = 0;
            bool bRtn = false;
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);

            // get calibration
            calibration = DllImport.MU_getCalibration(muHandle);
            Log.TestLogStr(true, "GetCalibration", "MU_getCalibration from muHandle");

            // get MPC (master period code)
            UInt32 temp = new UInt32();
            funcCallRet = DllImport.MU_GetParam(muHandle, MU_ParamEnum.MU_MPC, ref temp, ref masterPeriodCode);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -9;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "GetParam_MPC", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "GetParam_MPC", string.Format("rtn = {0}", funcCallRet.ToString()));

            // set initial master and nonius adjustment
            initialMasterAdjustments.cosineGain = 0;
            initialMasterAdjustments.sineOffset = 0;
            initialMasterAdjustments.cosineOffset = 0;
            initialMasterAdjustments.phase = 0;
            initialMasterAdjustments.phaseRange = 0;

            initialNoniusAdjustments.cosineGain = 0;
            initialNoniusAdjustments.sineOffset = 0;
            initialNoniusAdjustments.cosineOffset = 0;
            initialNoniusAdjustments.phase = 0;
            initialNoniusAdjustments.phaseRange = 0;

            bRtn = DllImport.MU_Calibration_setCurrentAnalogTrackAdjustments(
                calibration, initialMasterAdjustments, initialNoniusAdjustments);
            if (!bRtn)
            {
                iRtn = -10;
                Log.TestLogStr(true, "InitAdjustment", "MU_Calibration_setCurrentAnalogTrackAdjustments return false when init.");
                return iRtn;
            }
            else
                Log.TestLogStr(true, "InitAdjustment", "MU_Calibration_setCurrentAnalogTrackAdjustments configuration is success.");

            // set calibration
            funcCallRet = DllImport.MU_setCalibration(muHandle, calibration);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -11;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "SetCalibration", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "SetCalibration", string.Format("rtn = {0}", funcCallRet.ToString()));

            // write parameter
            funcCallRet = DllImport.MU_WriteParams2(muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -12;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "WriteParam", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "WriteParam", string.Format("rtn = {0}", funcCallRet.ToString()));

            Log.TestLogStr(true, "Message", "=============================================");
            Log.TestLogStr(true, "Message", "Initial iC-MU signal conditioning parameters:");
            printAnalogAdjustments(calibration, false);
            Log.TestLogStr(true, "Message", "=============================================");

            return iRtn;
            // -9: MU_MPC read fail
            // -10: set current analong track adjustment (initialize)
            // -11: set calibration fail
            // -12: write parameter
        }

        private int AnalogCalibration()
        {
            int iRtn = 0;
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);

            // activate calibration
            funcCallRet = DllImport.MU_activateCalibrationConfig(muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -13;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "ActivateCal", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "ActivateCal", string.Format("rtn = {0}", funcCallRet.ToString()));

            // acquisition
            funcCallRet = DllImport.MU_acquireRawData2(
                muHandle, masterRawData, noniusRawData, numberOfSamples, 0,
                acquireFrameCycleTime_s, acquireClockFrequency_hz);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -14;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "Acquisition", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));

                funcCallRet = DllImport.MU_deactivateCalibrationConfig(muHandle);
                if (funcCallRet != MU_ErrorEnum.MU_OK)
                    Log.TestLogStr(true, "Acquisition", string.Format("errNo={0}, errType={1}, errText={2}",
                        errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "Acquisition", string.Format("rtn = {0}", funcCallRet.ToString()));

            // deactivate calibration
            funcCallRet = DllImport.MU_deactivateCalibrationConfig(muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -15;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "DeactivateCal", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "DeactivateCal", string.Format("rtn = {0}", funcCallRet.ToString()));

            // get analyze result
            analyzeResult = DllImport.MU_Calibration_analyzeRawData(calibration, masterRawData, noniusRawData, numberOfSamples);
            if (analyzeResult == IntPtr.Zero)
            {
                iRtn = -16;
                Log.TestLogStr(true, "AnalyzeRlt", string.Format("rtn = {0}", funcCallRet.ToString()));
                return iRtn;
            }

            // print result log
            ulong logSize = DllImport.getAnalyzeResultLogSize(analyzeResult);
            StringBuilder sbAnalyzeRlt = new StringBuilder(4096);
            DllImport.getAnalyzeResultLogMsg(analyzeResult, logSize, sbAnalyzeRlt);
            Log.TestLogStr(true, "Message", "=============================================");
            Log.TestLogStr(true, "Message", "Analog calibration result log");
            Log.TestLogStr(true, "Message", sbAnalyzeRlt.ToString());

            Log.TestLogStr(true, "Message", "Relative track adjustments");
            printRelativeAdjustments(analyzeResult, false);

            StringBuilder sbMsg = new StringBuilder(1024);
            bool isAdjustable = DllImport.printAnalogAnalyzeResultAdjustableLog(calibration, analyzeResult, sbMsg);
            // isAdjustable에 대한 활용 필요있어 보임.
            Log.TestLogStr(true, "Message", sbMsg.ToString());
            Log.TestLogStr(true, "Message", "=============================================");

            // adjust the analog parameter in calibration object
            bool rlt = DllImport.MU_Calibration_adjustAnalogByAnalyzeResult(calibration, analyzeResult);

            Log.TestLogStr(true, "Message", "=============================================");
            Log.TestLogStr(true, "Message", "iC-MU signal conditioning parameters after calibration:");
            printAnalogAdjustments(calibration, true);
            Log.TestLogStr(true, "Message", "=============================================");

            // set calibration
            funcCallRet = DllImport.MU_setCalibration(muHandle, calibration);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -17;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "SetCalibration", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "SetCalibration", string.Format("rtn = {0}", funcCallRet.ToString()));

            // write parameter
            funcCallRet = DllImport.MU_WriteParams2(muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -18;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "WriteParam", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "WriteParam", string.Format("rtn = {0}", funcCallRet.ToString()));

            // delete analyze result
            DllImport.MU_CalibrationAnalyzeResult_delete(analyzeResult);

            return iRtn;
            // -13: activate calibration config error
            // -14: acquisition error
            // -15: deactivate calibration config error
            // -16: get analyze result error
            // -17: set calibration error
            // -18: write parameter error
        }

        private int NoniusCalibration()
        {
            int iRtn = 0;
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);

            // activate calibration
            funcCallRet = DllImport.MU_activateCalibrationConfig(muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -19;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "ActivateCal", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "ActivateCal", string.Format("rtn = {0}", funcCallRet.ToString()));

            // acquisition
            funcCallRet = DllImport.MU_acquireRawData2(
                muHandle, masterRawData, noniusRawData, numberOfSamples, 0,
                acquireFrameCycleTime_s, acquireClockFrequency_hz);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -20;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "Acquisition", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));

                funcCallRet = DllImport.MU_deactivateCalibrationConfig(muHandle);
                if (funcCallRet != MU_ErrorEnum.MU_OK)
                    Log.TestLogStr(true, "Acquisition", string.Format("errNo={0}, errType={1}, errText={2}",
                        errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "Acquisition", string.Format("rtn = {0}", funcCallRet.ToString()));

            // deactivate calibration
            funcCallRet = DllImport.MU_deactivateCalibrationConfig(muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -21;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "DeactivateCal", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "DeactivateCal", string.Format("rtn = {0}", funcCallRet.ToString()));

            // get analyze result
            analyzeResult2 = DllImport.MU_Calibration_analyzeRawData(calibration, masterRawData, noniusRawData, numberOfSamples);
            if (analyzeResult2 == IntPtr.Zero)
            {
                iRtn = -22;
                Log.TestLogStr(true, "AnalyzeRlt", string.Format("rtn = {0}", funcCallRet.ToString()));
                return iRtn;
            }

            // print result log
            ulong logSize = DllImport.getAnalyzeResultLogSize(analyzeResult2);
            StringBuilder sbAnalyzeRlt = new StringBuilder(4096);
            DllImport.getAnalyzeResultLogMsg(analyzeResult2, logSize, sbAnalyzeRlt);
            Log.TestLogStr(true, "Message", "=============================================");
            Log.TestLogStr(true, "Message", "Nonious calibration result log");
            Log.TestLogStr(true, "Message", sbAnalyzeRlt.ToString());

            Log.TestLogStr(true, "Message", "Residual errors ");
            printRelativeAdjustments(analyzeResult2, true);

            string csvPath = Application.StartupPath +
                string.Format("\\TestLog\\{0}\\{1}\\{2}\\{3}.csv",
                DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), "barcode");

            optionalPrintOptimizedNoniusTrackOffsetTable(analyzeResult2, masterPeriodCode, csvPath);

            bool isSuccess = DllImport.setCurrentNoniusTrackOffsetTable(calibration, analyzeResult2);

            // set calibration
            funcCallRet = DllImport.MU_setCalibration(muHandle, calibration);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -23;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "SetCalibration", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "SetCalibration", string.Format("rtn = {0}", funcCallRet.ToString()));

            // write parameter
            funcCallRet = DllImport.MU_WriteParams2(muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -24;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "WriteParam", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "WriteParam", string.Format("rtn = {0}", funcCallRet.ToString()));


            // delete analyze result
            DllImport.MU_CalibrationAnalyzeResult_delete(analyzeResult2);

            // delete calibration
            DllImport.MU_Calibration_delete(calibration);

            return iRtn;
            // -19: activate calibration config error
            // -20: acquisition error
            // -21: deactivate calibration config error
            // -22: get analyze result error
            // -23: set calibration error
            // -24: write parameter error
        }

        private void printAnalogAdjustments(IntPtr calibration, bool afterCal)
        {
            uint GC_M = new uint();
            uint GF_M = new uint();
            uint GC_N = new uint();
            uint GF_N = new uint();
            double mGainRange = new double();
            double mGainFine = new double();
            double nGainRange = new double();
            double nGainFine = new double();
            MU_ErrorEnum funcCallRet;
            UInt32 temp = new UInt32();
            funcCallRet = DllImport.MU_GetParam(muHandle, MU_ParamEnum.MU_GC_M, ref temp, ref GC_M);
            funcCallRet = DllImport.MU_GetParam(muHandle, MU_ParamEnum.MU_GF_M, ref temp, ref GF_M);
            funcCallRet = DllImport.MU_GetParam(muHandle, MU_ParamEnum.MU_GC_N, ref temp, ref GC_N);
            funcCallRet = DllImport.MU_GetParam(muHandle, MU_ParamEnum.MU_GF_N, ref temp, ref GF_N);
            mGainRange = GCHex2Double(GC_M);
            mGainFine = GFHex2Double(GF_M);
            nGainRange = GCHex2Double(GC_N);
            nGainFine = GFHex2Double(GF_N);

            if (afterCal)
            {
                Rlt.GC_M_Val = mGainRange;
                Rlt.GC_M_Judge = Judge(Spec.GC_Min, Spec.GC_Max, Rlt.GC_M_Val);
                Rlt.GF_M_Val = mGainFine;
                Rlt.GF_M_Judge = Judge(Spec.GF_Min, Spec.GF_Max, Rlt.GF_M_Val);
                Rlt.GC_N_Val = nGainRange;
                Rlt.GC_N_Judge = Judge(Spec.GC_Min, Spec.GC_Max, Rlt.GC_N_Val);
                Rlt.GF_N_Val = nGainFine;
                Rlt.GF_N_Judge = Judge(Spec.GF_Min, Spec.GF_Max, Rlt.GF_N_Val);
            }

            MU_Calibration_AnalogTrackAdjustments_ masterTrackAdjustments = new MU_Calibration_AnalogTrackAdjustments_();
            DllImport.MU_Calibration_getAnalogMasterTrackAdjustments(calibration, ref masterTrackAdjustments);

            Log.TestLogStr(true, "Message", string.Format("Gain Range (GC_M)\t: {0} (0x{1:X2})", mGainRange, GC_M));
            Log.TestLogStr(true, "Message", string.Format("Gain Fine (GF_M)\t: {0} (0x{1:X2})", mGainFine, GF_M));
            printAnalogTrackAdjustment(masterTrackAdjustments, "M", afterCal);

            MU_Calibration_AnalogTrackAdjustments_ noniusTrackAdjustments = new MU_Calibration_AnalogTrackAdjustments_();
            DllImport.MU_Calibration_getAnalogNoniusTrackAdjustments(calibration, ref noniusTrackAdjustments);
            Log.TestLogStr(true, "Message", string.Format("Gain Range (GC_N)\t: {0} (0x{1:X2})", nGainRange, GC_N));
            Log.TestLogStr(true, "Message", string.Format("Gain Fine (GF_N)\t: {0} (0x{1:X2})", nGainFine, GF_N));
            printAnalogTrackAdjustment(noniusTrackAdjustments, "N", afterCal);
        }

        private bool Judge(double _min, double _max, double _val)
        {
            bool rtn = false;
            if (_min <= _val && _val <= _max)
                rtn = true;
            return rtn;
        }

        private void printAnalogTrackAdjustment(MU_Calibration_AnalogTrackAdjustments_ item, string track, bool afterCal)
        {
            double cosineGain = new double();
            double sineOffset = new double();
            double cosineOffset = new double();
            double phase = new double();

            cosineGain = GxHex2Double(item.cosineGain);
            sineOffset = VOSx_xHex2Double(item.sineOffset);
            cosineOffset = VOSx_xHex2Double(item.cosineOffset);
            if (track == "M")
                phase = PHMHex2Double(item.phase, item.phaseRange);
            else if (track == "N")
                phase = PHNHex2double(item.phase, item.phaseRange);
            else
                Log.TestLogStr(true, "Error", "Parameter track should be M or N");

            Log.TestLogStr(true, "Message", string.Format("Cosine gain (GX_{0})\t: {1} (0x{2:X2})", track, cosineGain, item.cosineGain));
            Log.TestLogStr(true, "Message", string.Format("Sine offset (VOSS_{0})\t: {1} (0x{2:X2})", track, sineOffset, item.sineOffset));
            Log.TestLogStr(true, "Message", string.Format("Cosine offset (VOSC_{0})\t: {1} (0x{2:X2})", track, cosineOffset, item.cosineOffset));
            Log.TestLogStr(true, "Message", string.Format("Phase (PH_{0})\t\t: {1} (0x{2:X2})", track, phase, item.phase));
            Log.TestLogStr(true, "Message", string.Format("Phase range (PHR_{0})\t: {1} (0x{1:X2})", track, item.phaseRange));

            if (afterCal)
            {
                if (track == "M")
                {
                    Rlt.GX_M_Val = cosineGain;
                    Rlt.GX_M_Judge = Judge(Spec.GX_Min, Spec.GX_Max, Rlt.GX_M_Val);
                    Rlt.VOSS_M_Val = sineOffset;
                    Rlt.VOSS_M_Judge = Judge(Spec.VOSS_Min, Spec.VOSS_Max, Rlt.VOSS_M_Val);
                    Rlt.VOSC_M_Val = cosineOffset;
                    Rlt.VOSC_M_Judge = Judge(Spec.VOSC_Min, Spec.VOSC_Max, Rlt.VOSC_M_Val);
                    Rlt.PH_M_Val = phase;
                    Rlt.PH_M_Judge = Judge(Spec.PH_Min, Spec.PH_Max, Rlt.PH_M_Val);
                }
                else if (track == "N")
                {
                    Rlt.GX_N_Val = cosineGain;
                    Rlt.GX_N_Judge = Judge(Spec.GX_Min, Spec.GX_Max, Rlt.GX_N_Val);
                    Rlt.VOSS_N_Val = sineOffset;
                    Rlt.VOSS_N_Judge = Judge(Spec.VOSS_Min, Spec.VOSS_Max, Rlt.VOSS_N_Val);
                    Rlt.VOSC_N_Val = cosineOffset;
                    Rlt.VOSC_N_Judge = Judge(Spec.VOSC_Min, Spec.VOSC_Max, Rlt.VOSC_N_Val);
                    Rlt.PH_N_Val = phase;
                    Rlt.PH_N_Judge = Judge(Spec.PH_Min, Spec.PH_Max, Rlt.PH_N_Val);
                }
                else
                    Log.TestLogStr(true, "Error", "Parameter track should be M or N");
            }
        }
        
        private void printRelativeAdjustments(IntPtr analyzeResult, bool afterCal)
        {
            MU_Calibration_RelativeAnalogTrackAdjustments_ relativeMasterTrackAdjustments = new MU_Calibration_RelativeAnalogTrackAdjustments_();
            DllImport.MU_Calibration_getRelativeMasterTrackAdjustments(analyzeResult, ref relativeMasterTrackAdjustments);

            MU_Calibration_RelativeAnalogTrackAdjustments_ relativeNoniusTrackAdjustments = new MU_Calibration_RelativeAnalogTrackAdjustments_();
            DllImport.MU_Calibration_getRelativeMasterTrackAdjustments(analyzeResult, ref relativeNoniusTrackAdjustments);
            Log.TestLogStr(true, "Message", "Track:\t\tMaster\t|\t Nonius");
            Log.TestLogStr(true, "Message", string.Format("Cosine gain:\t{0:F4}\t|\t{1:F4}",
                relativeMasterTrackAdjustments.cosineGain_lsb, relativeNoniusTrackAdjustments.cosineGain_lsb));
            Log.TestLogStr(true, "Message", string.Format("Sine offset:\t{0:F4}\t|\t{1:F4}",
                relativeMasterTrackAdjustments.sineOffset_lsb, relativeNoniusTrackAdjustments.sineOffset_lsb));
            Log.TestLogStr(true, "Message", string.Format("Cosine offset:\t{0:F4}\t|\t{1:F4}",
                relativeMasterTrackAdjustments.cosineOffset_lsb, relativeNoniusTrackAdjustments.cosineOffset_lsb));
            Log.TestLogStr(true, "Message", string.Format("Phase adjust:\t{0:F4}\t|\t{1:F4}",
                relativeMasterTrackAdjustments.phase_lsb, relativeNoniusTrackAdjustments.phase_lsb));

            if (afterCal)
            {
                Rlt.GX_MErr_Val = relativeMasterTrackAdjustments.cosineGain_lsb;
                Rlt.GX_MErr_Judge = Judge(Spec.GX_ErrMin, Spec.GX_ErrMax, Rlt.GX_MErr_Val);
                Rlt.VOSS_MErr_Val = relativeMasterTrackAdjustments.sineOffset_lsb;
                Rlt.VOSS_MErr_Judge = Judge(Spec.VOSS_ErrMin, Spec.VOSS_ErrMax, Rlt.VOSS_MErr_Val);
                Rlt.VOSC_MErr_Val = relativeMasterTrackAdjustments.cosineOffset_lsb;
                Rlt.VOSC_MErr_Judge = Judge(Spec.VOSC_ErrMin, Spec.VOSC_ErrMax, Rlt.VOSC_MErr_Val);
                Rlt.PH_MErr_Val = relativeMasterTrackAdjustments.phase_lsb;
                Rlt.PH_MErr_Judge = Judge(Spec.PH_ErrMin, Spec.PH_ErrMax, Rlt.PH_MErr_Val);

                Rlt.GX_NErr_Val = relativeNoniusTrackAdjustments.cosineGain_lsb;
                Rlt.GX_NErr_Judge = Judge(Spec.GX_ErrMin, Spec.GX_ErrMax, Rlt.GX_NErr_Val);
                Rlt.VOSS_NErr_Val = relativeNoniusTrackAdjustments.sineOffset_lsb;
                Rlt.VOSS_NErr_Judge = Judge(Spec.VOSS_ErrMin, Spec.VOSS_ErrMax, Rlt.VOSS_NErr_Val);
                Rlt.VOSC_NErr_Val = relativeNoniusTrackAdjustments.cosineOffset_lsb;
                Rlt.VOSC_NErr_Judge = Judge(Spec.VOSC_ErrMin, Spec.VOSC_ErrMax, Rlt.VOSC_NErr_Val);
                Rlt.PH_NErr_Val = relativeNoniusTrackAdjustments.phase_lsb;
                Rlt.PH_NErr_Judge = Judge(Spec.PH_ErrMin, Spec.PH_ErrMax, Rlt.PH_NErr_Val);
            }
        }
        
        public static void optionalPrintOptimizedNoniusTrackOffsetTable(
            IntPtr analyzeResult, UInt32 masterPeriodCode, string noniusCurveCSVPath)
        {
            sbyte[] spoN = new sbyte[16];
            sbyte spoBase = DllImport.getOptimizedNoniusTrackOffsetTable(analyzeResult, spoN);
            Log.TestLogStr(true, "Message", "spoBase = " + spoBase.ToString());
            string szt = "";
            szt = "spoN[0..15] = ";
            for (int i = 0; i < spoN.Length; i++)
                szt += spoN[i].ToString() + ", ";
            szt.TrimEnd(' ');
            szt.TrimEnd(',');
            Log.TestLogStr(true, "Message", szt);

            long noniusCalibrationMaxAllowPhaseError = Convert.ToInt64(Math.Pow(2.0, (14 - 1 - masterPeriodCode)));
            long noniusPhaseMarginMax = DllImport.MU_Calibration_noniusPhaseMarginMax(analyzeResult);
            long noniusPhaseMarginMin = DllImport.MU_Calibration_noniusPhaseMarginMin(analyzeResult);
            Log.TestLogStr(true, "Message", "Nonius Max Allow Phase Error = " + noniusCalibrationMaxAllowPhaseError.ToString());
            Log.TestLogStr(true, "Message", "Nonius Phase Margin Max = " + noniusPhaseMarginMax.ToString());
            Log.TestLogStr(true, "Message", "Nonius Phase Margin Min = " + noniusPhaseMarginMin.ToString());

            double noniusPhaseMarginMax_percent =
                    (double)noniusPhaseMarginMax / (double)noniusCalibrationMaxAllowPhaseError * 100;
            double noniusPhaseMarginMin_percent =
                    (double)noniusPhaseMarginMin / (double)(-noniusCalibrationMaxAllowPhaseError) * 100;
            Log.TestLogStr(true, "Message", "Nonius Phase Margin Max (%) = " + noniusPhaseMarginMax_percent.ToString("F3"));
            Log.TestLogStr(true, "Message", "Nonius Phase Margin Min (%) = " + noniusPhaseMarginMin_percent.ToString("F3"));

            long PhaseRangeLimit = DllImport.MU_Calibration_noniusPhaseRangeLimit(analyzeResult);
            double UpperPhaseMargin = DllImport.MU_Calibration_noniusUpperPhaseMargin(analyzeResult);
            double LowerPhaseMargin = DllImport.MU_Calibration_noniusLowerPhaseMargin(analyzeResult);
            double inRangeMax = 100.0 - UpperPhaseMargin;
            double inRangeMin = 100.0 - LowerPhaseMargin;
            Log.TestLogStr(true, "Message", "Nonius Phase Range Limit = " + PhaseRangeLimit.ToString());
            Log.TestLogStr(true, "Message", "Nonius Upper Phase Margin = " + UpperPhaseMargin.ToString("F3"));
            Log.TestLogStr(true, "Message", "Nonius Lower Phase Margin = " + LowerPhaseMargin.ToString("F3"));
            Log.TestLogStr(true, "Message", "Nonius In Range Max = " + inRangeMax.ToString("F3"));
            Log.TestLogStr(true, "Message", "Nonius In Range Min = " + inRangeMin.ToString("F3"));

            ulong numberOfNoniusCurveSamples = DllImport.MU_Calibration_numberOfNoniusCurveSamples(analyzeResult);
            int[] noniusPhaseError = new int[numberOfNoniusCurveSamples];
            DllImport.getNoniusPhaseError(analyzeResult, noniusPhaseError);

            int[] noniusTrackOffsetCurve = new int[numberOfNoniusCurveSamples];
            DllImport.getNoniusTrackOffsetCurve(analyzeResult, noniusTrackOffsetCurve);

            int[] noniusPhaseMargin = new int[numberOfNoniusCurveSamples];
            DllImport.getnoniusPhaseMargin(analyzeResult, noniusPhaseMargin);

            double[] noniusPosition = new double[numberOfNoniusCurveSamples];
            DllImport.MU_Calibration_calculateNoniusPosition(
                analyzeResult, noniusPosition, numberOfNoniusCurveSamples, MU_Calibration_Unit_.MU_CALIBRATION_UNIT_DEGREE, false);

            double[] continuousNoniusPosition = new double[numberOfNoniusCurveSamples];
            DllImport.MU_Calibration_calculateNoniusPosition(
                analyzeResult, continuousNoniusPosition, numberOfNoniusCurveSamples, MU_Calibration_Unit_.MU_CALIBRATION_UNIT_DEGREE, true);

            StringBuilder ResultMsg = new StringBuilder();
            ResultMsg.Append("phase error in absolute resolution,");
            ResultMsg.Append("track offset curve in absolute resolution,");
            ResultMsg.Append("phase margin in absolute resolution,");
            ResultMsg.Append("single turn position in degree,");
            ResultMsg.Append("continuous single turn position in degree");
            ResultMsg.AppendLine();

            for (ulong i = 0; i < numberOfNoniusCurveSamples; i++)
            {
                ResultMsg.AppendFormat("{0},{1},{2},{3},{4}",
                    noniusPhaseError[i], noniusTrackOffsetCurve[i], noniusPhaseMargin[i], noniusPosition[i], continuousNoniusPosition[i]);
                ResultMsg.AppendLine();
            }

            File.AppendAllText(noniusCurveCSVPath, ResultMsg.ToString());
        }

        private double GCHex2Double(uint GC_x)
        {
            double rtn = 4.4;

            switch(GC_x)
            {
                case 0:
                    rtn = 4.4;
                    break;
                case 1:
                    rtn = 7.8;
                    break;
                case 2:
                    rtn = 12.4;
                    break;
                case 3:
                    rtn = 20.7;
                    break;
            }
            return rtn;
        }

        private double GFHex2Double(uint GF_x)
        {
            double rtn = 1.0;
            // exp(ln(20)/64*afgain)
            rtn = Math.Exp(0.015625 * Math.Log(20) * GF_x);
            return rtn;
        }

        private double GxHex2Double(byte GX_x)
        {
            double rtn;
            if (0x00 <= GX_x && GX_x <= 0x3F)
            {   // exp(ln(20)/2048 * GX_x)
                rtn = Math.Exp(0.00048828125 * Math.Log(20) * (double)GX_x);
            }
            else
            {   // exp(-ln(20)/2048 * (128-GX_x))
                rtn = Math.Exp(0.00048828125 * -Math.Log(20) * (128.0 - (double)GX_x));
            }
            return rtn;
        }

        private double VOSx_xHex2Double(byte VOSx_x)
        {
            double rtn;
            if (0x00 <= VOSx_x && VOSx_x <= 0x3F)
                rtn = Convert.ToDouble(VOSx_x);
            else
                rtn = 64.0 - Convert.ToDouble(VOSx_x);
            return rtn;
        }

        private double PHMHex2Double(byte PH_M, byte PHR_M)
        {
            double rtn;
            double ang = PHR_M == 0x0 ? 8.0 : 16.0;
            if (0x00 <= PH_M && PH_M <= 0x3F)
                rtn = 0.015873016 * ang * Convert.ToDouble(PH_M);
            else
                rtn = 0.015873016 * -ang * (Convert.ToDouble(PH_M) - 64.0);
            return rtn;
        }

        private double PHNHex2double(byte PH_N, byte PHR_N)
        {
            double rtn;
            double ang = PHR_N == 0x0 ? 12.0 : 20.0;
            if (0x00 <= PH_N && PH_N <= 0x3F)
                rtn = 0.015873016 * ang * Convert.ToDouble(PH_N);
            else
                rtn = 0.015873016 * -ang * (Convert.ToDouble(PH_N) - 64.0);
            return rtn;
        }
        #endregion

        #region motor zero set
        private int MotorZeroSet()
        {

        
            int iRtn = 0;
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);
            ReadSensStruct rdSene = new ReadSensStruct();

            // read sens
            uint mt = new uint();
            uint st = new uint();
            uint err = new uint();
            uint warn = new uint();
            uint rawMaster = new uint();
            uint rawNonius = new uint();
            //funcCallRet = DllImport.MU_ReadSens(muHandle, rdSene);
            funcCallRet = DllImport.MU_readSens2(muHandle, mt, st, err, warn, rawMaster, rawNonius);
            //funcCallRet = DllImport.MU_ReadSens(muHandle, rdSene);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -25;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "ReadSens1", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
            {
                Log.TestLogStr(true, "ReadSens1", string.Format(
                    "rtn = {0}, mt = {1}, st = {2}", funcCallRet.ToString(), mt, st));
            }
                
            // send SOFT_PRES command
            //funcCallRet = DllImport.MU_WriteCmdRegister(muHandle, MU_CommandEnum.MU_CMD_SOFT_PRES);
            //if (funcCallRet != MU_ErrorEnum.MU_OK)
            //{
            //    iRtn = -26;
            //    DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
            //    Log.TestLogStr(true, "CmdSOFTPRES", string.Format("errNo={0}, errType={1}, errText={2}",
            //        errNo.ToString(), errType.ToString(), errText.ToString()));
            //    return iRtn;
            //}
            //else
            //    Log.TestLogStr(true, "CmdSOFTPRES", string.Format("rtn = {0}", funcCallRet.ToString()));


            // read sens again (to check degree)
            //funcCallRet = DllImport.MU_ReadSens(muHandle, rdSene);
            funcCallRet = DllImport.MU_readSens2(muHandle, mt, st, err, warn, rawMaster, rawNonius);

            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -27;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "ReadSens", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
            {
                Log.TestLogStr(true, "ReadSens2", string.Format(
                    "rtn = {0}, mt = {1}, st = {2}", funcCallRet.ToString(), mt, st));
                Log.TestLogStr(true, "ReadSens2", string.Format(
                    "rtn = {0}, mt = {1}, st = {2}", funcCallRet.ToString(), mt, st));
            }


            return iRtn;
            // -25: read sens error
            // -26: SOFT_PRES command error
            // -27: read sens error
        }
        #endregion

        private void WriteEEPROM()
        {
            int iRtn = 0;
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);

            int iRtn = interfacePrepare();
            if (iRtn < 0)
            {
                Log.TestLogStr(true, "Error", string.Format("Error in interfacePrepare function, iRtn={0}", iRtn));
                if (muHandle != IntPtr.Zero)
                {
                    funcCallRet = DllImport.MU_Close(muHandle);
                    Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                        errNo.ToString(), errType.ToString(), errText.ToString()));
                }
            }

            iRtn = calibrationPrepare();
            if (iRtn < 0)
            {
                Log.TestLogStr(true, "Error", string.Format("Error in calibrationPrepare function, iRtn={0}", iRtn));
                if (calibration != IntPtr.Zero)
                    DllImport.MU_Calibration_delete(calibration);
                if (muHandle != IntPtr.Zero)
                {
                    funcCallRet = DllImport.MU_Close(muHandle);
                    Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                        errNo.ToString(), errType.ToString(), errText.ToString()));
                }
            }

            iRtn = AnalogCalibration();
            if (iRtn < 0)
            {
                Log.TestLogStr(true, "Error", string.Format("Error in AnalogCalibration function, iRtn={0}", iRtn));
                if (analyzeResult != IntPtr.Zero)
                    DllImport.MU_CalibrationAnalyzeResult_delete(analyzeResult);
                if (calibration != IntPtr.Zero)
                    DllImport.MU_Calibration_delete(calibration);
                if (muHandle != IntPtr.Zero)
                {
                    funcCallRet = DllImport.MU_Close(muHandle);
                    Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                        errNo.ToString(), errType.ToString(), errText.ToString()));
                }
            }

            iRtn = NoniusCalibration();
            if (iRtn < 0)
            {
                Log.TestLogStr(true, "Error", string.Format("Error in NoniusCalibration function, iRtn={0}", iRtn));
                if (analyzeResult != IntPtr.Zero)
                    DllImport.MU_CalibrationAnalyzeResult_delete(analyzeResult);
                if (calibration != IntPtr.Zero)
                    DllImport.MU_Calibration_delete(calibration);
                if (muHandle != IntPtr.Zero)
                {
                    funcCallRet = DllImport.MU_Close(muHandle);
                    Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                        errNo.ToString(), errType.ToString(), errText.ToString()));
                }
            }

            // Encoder Calibration이 여기까지

            // 제품 정지
            // 여기부터가 Motor Zero Set

            //iRtn = MotorZeroSet();
            //if (iRtn < 0)
            //{
            //    Log.TestLogStr(true, "Error", string.Format("Error in MotorZeroSet function, iRtn={0}", iRtn));
            //    if (muHandle != IntPtr.Zero)
            //    {
            //        funcCallRet = DllImport.MU_Close(muHandle);
            //        Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
            //            errNo.ToString(), errType.ToString(), errText.ToString()));
            //    }
            //}

            // write all command
            // NRKim should be coding!!!!!
            // write EEPROM
            //iRtn = WriteEEPROM();



            // mu close
            //funcCallRet = DllImport.MU_Close(muHandle);
            //Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
            //    errNo.ToString(), errType.ToString(), errText.ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);
            int iRtn = 0;
            if (textBox1.Text == "1")
            {
                iRtn = interfacePrepare();
                if (iRtn < 0)
                {
                    Log.TestLogStr(true, "Error", string.Format("Error in interfacePrepare function, iRtn={0}", iRtn));
                    if (muHandle != IntPtr.Zero)
                    {
                        funcCallRet = DllImport.MU_Close(muHandle);
                        Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                            errNo.ToString(), errType.ToString(), errText.ToString()));
                    }
                }
            }
            else if (textBox1.Text == "2")
            {
                iRtn = calibrationPrepare();
                if (iRtn < 0)
                {
                    Log.TestLogStr(true, "Error", string.Format("Error in calibrationPrepare function, iRtn={0}", iRtn));
                    if (calibration != IntPtr.Zero)
                        DllImport.MU_Calibration_delete(calibration);
                    if (muHandle != IntPtr.Zero)
                    {
                        funcCallRet = DllImport.MU_Close(muHandle);
                        Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                            errNo.ToString(), errType.ToString(), errText.ToString()));
                    }
                }
            }
            else if (textBox1.Text == "3")
            {
                iRtn = AnalogCalibration();
                if (iRtn < 0)
                {
                    Log.TestLogStr(true, "Error", string.Format("Error in AnalogCalibration function, iRtn={0}", iRtn));
                    if (analyzeResult != IntPtr.Zero)
                        DllImport.MU_CalibrationAnalyzeResult_delete(analyzeResult);
                    if (calibration != IntPtr.Zero)
                        DllImport.MU_Calibration_delete(calibration);
                    if (muHandle != IntPtr.Zero)
                    {
                        funcCallRet = DllImport.MU_Close(muHandle);
                        Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                            errNo.ToString(), errType.ToString(), errText.ToString()));
                    }
                }
            }

            else if (textBox1.Text == "4")
            {
                iRtn = NoniusCalibration();
                if (iRtn < 0)
                {
                    Log.TestLogStr(true, "Error", string.Format("Error in NoniusCalibration function, iRtn={0}", iRtn));
                    if (analyzeResult != IntPtr.Zero)
                        DllImport.MU_CalibrationAnalyzeResult_delete(analyzeResult);
                    if (calibration != IntPtr.Zero)
                        DllImport.MU_Calibration_delete(calibration);
                    if (muHandle != IntPtr.Zero)
                    {
                        funcCallRet = DllImport.MU_Close(muHandle);
                        Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                            errNo.ToString(), errType.ToString(), errText.ToString()));
                    }
                }
            }

            else if (textBox1.Text == "5")
            {
                iRtn = MotorZeroSet();
                if (iRtn < 0)
                {
                    Log.TestLogStr(true, "Error", string.Format("Error in MotorZeroSet function, iRtn={0}", iRtn));
                    if (muHandle != IntPtr.Zero)
                    {
                        funcCallRet = DllImport.MU_Close(muHandle);
                        Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                            errNo.ToString(), errType.ToString(), errText.ToString()));
                    }
                }
            }

            // Encoder Calibration이 여기까지

            // 여기부터가 Motor Zero Set


            // write all command
            // NRKim should be coding!!!!!
            // write EEPROM
            //iRtn = WriteEEPROM();


            else
            {
                funcCallRet = DllImport.MU_Close(muHandle);
                Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
            }
            // mu close
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);

            
            int iRtn = MotorZeroSet();
            if (iRtn < 0)
            {
                Log.TestLogStr(true, "Error", string.Format("Error in MotorZeroSet function, iRtn={0}", iRtn));
                if (muHandle != IntPtr.Zero)
                {
                    funcCallRet = DllImport.MU_Close(muHandle);
                    Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                        errNo.ToString(), errType.ToString(), errText.ToString()));
                }
            }

            ////mu close
            //funcCallRet = DllImport.MU_Close(muHandle);
            //Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
            //    errNo.ToString(), errType.ToString(), errText.ToString()));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);

            int iRtn = interfacePrepare1();
            if (iRtn < 0)
            {
                Log.TestLogStr(true, "Error", string.Format("Error in interfacePrepare function, iRtn={0}", iRtn));
                if (muHandle != IntPtr.Zero)
                {
                    funcCallRet = DllImport.MU_Close(muHandle);
                    Log.TestLogStr(true, "Close", string.Format("errNo={0}, errType={1}, errText={2}",
                        errNo.ToString(), errType.ToString(), errText.ToString()));
                }
            }
        }

        private int interfacePrepare1()
        {
            int iRtn = 0;
            MU_ErrorEnum funcCallRet;

            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();
            StringBuilder errText = new StringBuilder(1024);

            // get handle & open
            funcCallRet = DllImport.MU_Open(ref muHandle);
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -1;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "Open", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "Open", string.Format("rtn = {0}", funcCallRet.ToString()));

            funcCallRet = DllImport.MU_SetInterface(muHandle, interfaceType, "");
            if (funcCallRet != MU_ErrorEnum.MU_OK)
            {
                iRtn = -4;
                DllImport.callGetLastError(muHandle, ref errNo, ref errType, errText);
                Log.TestLogStr(true, "SetInterface", string.Format("errNo={0}, errType={1}, errText={2}",
                    errNo.ToString(), errType.ToString(), errText.ToString()));
                return iRtn;
            }
            else
                Log.TestLogStr(true, "SetInterface", string.Format("rtn = {0}", funcCallRet.ToString()));

            return iRtn;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
