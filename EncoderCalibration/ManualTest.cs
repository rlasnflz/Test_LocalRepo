using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderCalibration
{
    public partial class ManualTest : Form
    {
        const ulong numberOfSamples = 12407; // min. 16 (recommended 128) values per period
        double acquireFrameCycleTime_s = 403E-6;        // 0.000403; //  187.5E-6;  //1.0 / 8E3;
        double acquireClockFrequency_hz = 100000;    //2E6;

        UInt16[] masterRawData = new UInt16[numberOfSamples];
        UInt16[] noniusRawData = new UInt16[numberOfSamples];

        IntPtr devHandle;
        MU_InterfaceEnum interfaceType = MU_InterfaceEnum.MU_MB3U_SPI;
        MU_ErrorEnum FuncCallRtn;
        byte revisionId = 0x00;     // #define MU_REV_MU200_0 0x20

        IntPtr calibration;
        IntPtr analyzeResult;

        // Initial value. all zero
        MU_Calibration_AnalogTrackAdjustments_ initialMasterAdjustments;
        MU_Calibration_AnalogTrackAdjustments_ initialNoniusAdjustments;
        // to check 
        MU_Calibration_AnalogTrackAdjustments_ masterTrackAdjustments;
        MU_Calibration_AnalogTrackAdjustments_ noniusTrackAdjustments;

        MU_Calibration_RelativeAnalogTrackAdjustments_ relativeMasterTrackAdjustments;
        MU_Calibration_RelativeAnalogTrackAdjustments_ relativeNoniusTrackAdjustments;
        
        MU_Calibration_NoniusTrackOffsetTable_ optimizedNoniusTrackOffsetTable;

        UInt32 masterPeriodCode;

        public ManualTest()
        {
            InitializeComponent();
        }

        private void btnMUOpen_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_Open(ref devHandle);
            lblRtn.Text = "MU_Open: " + FuncCallRtn.ToString();
        }

        private void btnMUClose_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_Close(devHandle);
            lblRtn.Text = "MU_Close: " + FuncCallRtn.ToString();
        }

        private void btnGetInterface_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_GetInterface(devHandle, ref interfaceType);
            lblRtn.Text = "MU_GetInterface: " + FuncCallRtn.ToString();
            label1.Text = interfaceType.ToString();
        }

        private void btnSetInterface_Click(object sender, EventArgs e)
        {
            // interfaceOption: If only one PC USB adapter is connected, an empty string has to be passed.
            FuncCallRtn = DllImport.MU_SetInterface(devHandle, interfaceType, "");
            lblRtn.Text = "MU_SetInterface: " + FuncCallRtn.ToString();
        }

        private void btnReadChipRev_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_ReadChipRevision(devHandle, ref revisionId);
            lblRtn.Text = "MU_ReadChipRevision: " + FuncCallRtn.ToString();
            lblRevID.Text = "ID: 0x" + revisionId.ToString("X2");
        }

        private void btnUseRev_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_UseRevision(devHandle, revisionId);
            lblRtn.Text = "MU_UseRevision: " + FuncCallRtn.ToString();
        }

        private void btnLoadParam_Click(object sender, EventArgs e)
        {
            string szFilePath = Application.StartupPath + "\\Config\\calibration.cfg";
            FuncCallRtn = DllImport.MU_LoadParams(devHandle, szFilePath);
            lblRtn.Text = "MU_LoadParams: " + FuncCallRtn.ToString();
        }

        private void btnReadParam_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_ReadParams(devHandle);
            lblRtn.Text = "MU_ReadParams: " + FuncCallRtn.ToString();
        }

        private void btnDeleteCal_Click(object sender, EventArgs e)
        {
            DllImport.MU_Calibration_delete(calibration);
            lblRtn.Text = "MU_Calibration_delete";
        }

        private void btnGetCal_Click(object sender, EventArgs e)
        {
            calibration = DllImport.MU_getCalibration(devHandle);
            lblRtn.Text = "MU_getCalibration";
        }

        private void btnWriteParam_Click(object sender, EventArgs e)
        {
            bool[] valid;
            //FuncCallRtn = DllImport.MU_WriteParams(devHandle, false, out valid);
            FuncCallRtn = DllImport.MU_WriteParams2(devHandle);
            lblRtn.Text = "MU_WriteParams: " + FuncCallRtn.ToString();
        }

        private void btnGetAMasterTrackAdj_Click(object sender, EventArgs e)
        {
            DllImport.MU_Calibration_getAnalogMasterTrackAdjustments(calibration, ref masterTrackAdjustments);
        }

        private void btnGetANoniusTrackAdj_Click(object sender, EventArgs e)
        {
            DllImport.MU_Calibration_getAnalogNoniusTrackAdjustments(calibration, ref noniusTrackAdjustments);
        }

        private void btnGetParam_MU_MPC_Click(object sender, EventArgs e)
        {
            UInt32 temp = new UInt32();
            FuncCallRtn = DllImport.MU_GetParam(devHandle, MU_ParamEnum.MU_MPC, ref temp, ref masterPeriodCode);
            lblRtn.Text = "MU_GetParam (MU_MPC): " + FuncCallRtn.ToString();
            label5.Text = "MU_MPC = 0x" + masterPeriodCode.ToString("X2");
        }

        private void btnSetATrackAdj_Click(object sender, EventArgs e)
        {
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

            DllImport.MU_Calibration_setCurrentAnalogTrackAdjustments(
                calibration, initialMasterAdjustments, initialNoniusAdjustments);
        }

        private void btnSetCalibration_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_setCalibration(devHandle, calibration);
            lblRtn.Text = "MU_setCalibration: " + FuncCallRtn.ToString();
        }

        private void btnActiveCal_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_activateCalibrationConfig(devHandle);
            lblRtn.Text = "MU_activateCalibrationConfig: " + FuncCallRtn.ToString();
        }

        private void btnAcqRawData_Click(object sender, EventArgs e)
        {
            //FuncCallRtn = DllImport.MU_acquireRawData(
            //    devHandle, ref masterRawData, ref noniusRawData, numberOfSamples, 0,
            //    acquireFrameCycleTime_s, acquireClockFrequency_hz);

            FuncCallRtn = DllImport.MU_acquireRawData2(
                devHandle, masterRawData, noniusRawData, numberOfSamples, 0,
                acquireFrameCycleTime_s, acquireClockFrequency_hz);
            lblRtn.Text = "MU_acquireRawData: " + FuncCallRtn.ToString();
        }

        private void btnReadLastErr_Click(object sender, EventArgs e)
        {
            MU_ErrorEnum errNo = new MU_ErrorEnum();
            MU_ErrorTypeEnum errType = new MU_ErrorTypeEnum();

            StringBuilder sb = new StringBuilder(1024);
            FuncCallRtn = DllImport.callGetLastError(devHandle, ref errNo, ref errType, sb);
            string sz = sb.ToString();
            label6.Text = "Last Error: " + sz;
        }

        private void btnDeactiveCalConfig_Click(object sender, EventArgs e)
        {
            FuncCallRtn = DllImport.MU_deactivateCalibrationConfig(devHandle);
            lblRtn.Text = "MU_deactivateCalibrationConfig: " + FuncCallRtn.ToString();
        }

        private void btnCalAnalyze_Click(object sender, EventArgs e)
        {
            analyzeResult = DllImport.MU_Calibration_analyzeRawData(calibration, masterRawData, noniusRawData, numberOfSamples);
        }

        private void btnGetCalAnalRltLog_Click(object sender, EventArgs e)
        {
            ulong logSize = DllImport.getAnalyzeResultLogSize(analyzeResult);
            StringBuilder sbAnalyzeRlt = new StringBuilder(4096);
            DllImport.getAnalyzeResultLogMsg(analyzeResult, logSize, sbAnalyzeRlt);
            string sz = sbAnalyzeRlt.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string file = Application.StartupPath + "\\raw_sample\\raw_sample_data_MU_Y_MU2L_82-32N_0.csv";
            StreamReader sr = new StreamReader(file);

            int idx = 0;
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] sz = line.Split(',');
                masterRawData[idx] = Convert.ToUInt16(sz[0]);
                noniusRawData[idx] = Convert.ToUInt16(sz[1]);
                idx++;
            }

            //analyzeResult = DllImport.MU_Calibration_analyzeRawData(calibration, masterRawData, noniusRawData, numberOfSamples);
        }

        private void btnGetRelativeAdj_Click(object sender, EventArgs e)
        {
            DllImport.MU_Calibration_getRelativeMasterTrackAdjustments(analyzeResult, ref relativeMasterTrackAdjustments);
            DllImport.MU_Calibration_getRelativeMasterTrackAdjustments(analyzeResult, ref relativeNoniusTrackAdjustments);
            string sz = "Track:\t\tMaster\t|\t Nonius\r\n";
            sz += string.Format("Cosine gain:\t{0:F4}\t|\t{1:F4}\r\n",
                relativeMasterTrackAdjustments.cosineGain_lsb, relativeNoniusTrackAdjustments.cosineGain_lsb);
            sz += string.Format("Sine offset:\t{0:F4}\t|\t{1:F4}\r\n",
                relativeMasterTrackAdjustments.sineOffset_lsb, relativeNoniusTrackAdjustments.sineOffset_lsb);
            sz += string.Format("Cosine offset:\t{0:F4}\t|\t{1:F4}\r\n",
                relativeMasterTrackAdjustments.cosineOffset_lsb, relativeNoniusTrackAdjustments.cosineOffset_lsb);
            sz += string.Format("Phase adjust:\t{0:F4}\t|\t{1:F4}\r\n",
                relativeMasterTrackAdjustments.phase_lsb, relativeNoniusTrackAdjustments.phase_lsb);
        }

        private void btnIsAdjustable_Click(object sender, EventArgs e)
        {
            StringBuilder sbMsg = new StringBuilder(1024);
            bool isAdjustable = DllImport.printAnalogAnalyzeResultAdjustableLog(
                calibration, analyzeResult, sbMsg);
            string sz = sbMsg.ToString();
        }

        private void btnAdjustAnlByRlt_Click(object sender, EventArgs e)
        {
            bool rlt = DllImport.MU_Calibration_adjustAnalogByAnalyzeResult(calibration, analyzeResult);
        }

        private void btnDelAnalRlt_Click(object sender, EventArgs e)
        {
            DllImport.MU_CalibrationAnalyzeResult_delete(analyzeResult);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = Application.StartupPath + "\\TestLog\\Manual_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".csv";
            Main.optionalPrintOptimizedNoniusTrackOffsetTable(analyzeResult, masterPeriodCode, filePath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool ret = DllImport.setCurrentNoniusTrackOffsetTable(calibration, analyzeResult);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ReadSensStruct rdSene = new ReadSensStruct();
            //FuncCallRtn = DllImport.MU_ReadSens(devHandle, rdSene);
            uint mt = new uint();
            uint st = new uint();
            uint err = new uint();
            uint warn = new uint();
            uint rawMaster = new uint();
            uint rawNonius = new uint();
            FuncCallRtn = DllImport.MU_readSens2(devHandle, mt, st, err, warn, rawMaster, rawNonius);
            lblRtn.Text = "MU_ReadSens: " + FuncCallRtn.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int iCmd = comboBox1.SelectedIndex;
            MU_CommandEnum cmd = (MU_CommandEnum)iCmd;
            FuncCallRtn = DllImport.MU_WriteCmdRegister(devHandle, cmd);
            lblRtn.Text = "MU_ReadSens: " + FuncCallRtn.ToString();
        }

        private void ManualTest_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 8;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UInt32 temp = new UInt32();
            uint acGainM = new uint();
            uint afGainM = new uint();
            uint acGainN = new int();
            uint afGainN = new uint();
            FuncCallRtn = DllImport.MU_GetParam(devHandle, MU_ParamEnum.MU_ACGAIN_M, ref temp, ref acGainM);
            FuncCallRtn = DllImport.MU_GetParam(devHandle, MU_ParamEnum.MU_AFGAIN_M, ref temp, ref afGainM);
            FuncCallRtn = DllImport.MU_GetParam(devHandle, MU_ParamEnum.MU_ACGAIN_N, ref temp, ref acGainN);
            FuncCallRtn = DllImport.MU_GetParam(devHandle, MU_ParamEnum.MU_AFGAIN_N, ref temp, ref afGainN);
            //0x0 4.4, 0x1 7.8, 0x2 12.4, 0x3 20.7
            lblRtn.Text = "MU_GetParam (MU_MPC): " + FuncCallRtn.ToString();
            label7.Text = string.Format("ACGainM={0}, AFGainM={1}, ACGainN={2}, AFGainN={3}", acGainM, afGainM, acGainN, afGainN);
            double mGainRange = rangeHex2Double(acGainM);
            double nGainRange = rangeHex2Double(acGainN);
            double mGainFine = fineHex2Double(afGainM);
            double nGainFine = fineHex2Double(afGainN);
            label8.Text = string.Format("ACGainM={0}, AFGainM={1}, ACGainN={2}, AFGainN={3}", mGainRange, mGainFine, nGainRange, nGainFine);
        }

        private double rangeHex2Double(uint acgain)
        {
            double rtn = 4.4;

            switch (acgain)
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

        private double fineHex2Double(uint afgain)
        {
            double rtn = 1.0;
            rtn = Math.Exp(0.125 * Math.Log(20) * afgain);
            return rtn;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //acquireFrameCycleTime_s = DllImport.MU_Interface_nearestPossibleFrameCycleTime(interfaceType, acquireFrameCycleTime_s);
            acquireFrameCycleTime_s = DllImport.MU_Interface_nextPossibleFrameCycleTime(interfaceType, acquireFrameCycleTime_s);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            acquireClockFrequency_hz = DllImport.MU_Interface_nearestPossibleClockFreq(interfaceType, acquireClockFrequency_hz);
        }
    }
}
