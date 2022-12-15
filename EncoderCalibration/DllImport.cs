using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EncoderCalibration
{
    enum MU_ErrorTypeEnum
    {
        MU_NONE,
        MU_HINT,
        MU_WARNING,
        MU_PROGRAMMING_ERROR,
        MU_OPERATING_ERROR,
        MU_COMMUNICATION_ERROR
    };

    enum MU_ErrorEnum
    {
        MU_OK,
        MU_INVALID_HANDLE,
        MU_INTERFACEDRIVER_NOT_FOUND,
        MU_INTERFACE_NOT_FOUND,
        MU_INVALID_INTERFACE,
        MU_NO_INTERFACE_SELECTED,
        MU_INVALID_PARAMETER,
        MU_INVALID_ADDRESS,
        MU_INVALID_VALUE,
        MU_USB_ERROR,
        MU_FILE_NOT_FOUND,
        MU_INVALID_FILE,
        MU_SPI_ERROR,
        MU_SPI_DISMISS,
        MU_SPI_FAIL,
        MU_SPI_BUSY_TIMEOUT,
        MU_VERIFY_FAILED,
        MU_MASTERCOMM_FAILED,
        MU_BISSCOMM_FAILED,
        MU_INVALID_BISSMASTER,
        MU_USB_HIGHSPEED_WARNING,
        MU_FAST_ROTATION,
        MU_SLOW_ROTATION,
        MU_FILE_ACCESS_DENIED,
        MU_READPARAM_SSI,
        MU_SSIRING_ERROR,
        MU_SEMI_ROTATION,
        MU_BISS_REGERROR,
        MU_INTERNAL_CALIB_ERROR,
        MU_INVALID_CONFIGURATION,
        MU_CALIBRATION_FAILED,
        MU_ACQUISITION_FAILED,
        MU_GAIN_LIMIT,
        MU_OFFSET_LIMIT,
        MU_PHASE_LIMIT,
        MU_BAD_CAL_DATA,
        MU_I2C_COMM_FAILED,
        MU_USB_DATA_LOSS,
        MU_MT_SYNC_FAILED,
        MU_UNKNOWN_ERROR,
        MU_UNKNOWN_REVISION,
        MU_UNSUPPORTED_REVISION,
        MU_UNKNOWN_PARAMETER,
        MU_PARAMETER_NOT_IN_REVISION,
        MU_REVISION_NOT_SET,
        MU_UNSUPPORTED_CHIP,
        MU_CONTRADICTORY_REVISIONS,
        MU_FRAME_RATE_NOT_SUPPORTED,
        MU_CLOCK_FREQUENCY_NOT_SUPPORTED,
        MU_FRAME_CYCLE_TIME_TO_SHORT
    };

    enum MU_ConfigDataEnum
    {
        MU_RESERVED0,
        MU_FREQ_SPI,
        MU_MASTERVER,
        MU_MASTERREV,
        MU_SLAVE_ID,
        MU_FREQ_SCD,
        MU_CLKENI,
        MU_FREQ_AGS,
        MU_SLAVE_COUNT,
        MU_START_CONTROL_FRAME,
        MU_REG_END,
        MU_FREQ_SSI,
        MU_READ_STATUS_ENABLE,
        MU_USB_PERFORMANCE,
        MU_READ_GAIN_ENABLE,
        MU_BP,
        MU_UPDATE_BISSID_ENABLE,
        MU_ENABLE_TTL
    };

    enum MU_ParamEnum
    {
        MU_GF_M,
        MU_GC_M,
        MU_GX_M,
        MU_VOSS_M,
        MU_VOSC_M,
        MU_PH_M,
        MU_PHR_M,
        MU_CIBM,
        MU_ENAC,
        MU_GF_N,
        MU_GC_N,
        MU_GX_N,
        MU_VOSS_N,
        MU_VOSC_N,
        MU_PH_N,
        MU_PHR_N,
        MU_MODEA,
        MU_NTOA,
        MU_MODEB,
        MU_CFGEW,
        MU_EMTD,
        MU_ACRM_RES,
        MU_NCHK_NON,
        MU_NCHK_CRC,
        MU_ACC_STAT,
        MU_FILT,
        MU_LIN,
        MU_ESSI_MT,
        MU_ROT_MT,
        MU_MPC,
        MU_SPO_MT,
        MU_MODE_MT,
        MU_SBL_MT,
        MU_CHK_MT,
        MU_GET_MT,
        MU_OUT_MSB,
        MU_OUT_ZERO,
        MU_OUT_LSB,
        MU_MODE_ST,
        MU_RSSI,
        MU_GSSI,
        MU_RESABZ,
        MU_FRQAB,
        MU_ENIF_AUTO,
        MU_SS_AB,
        MU_ROT_ALL,
        MU_INV_Z,
        MU_INV_B,
        MU_INV_A,
        MU_PP60UVW,
        MU_CHYS_AB,
        MU_LENZ,
        MU_PPUVW,
        MU_RPL,
        MU_TEST,
        MU_ROT_POS,
        MU_OFF_ABZ,
        MU_OFF_POS,
        MU_OFF_COM,
        MU_PA0_CONF,
        MU_AFGAIN_M,
        MU_ACGAIN_M,
        MU_AFGAIN_N,
        MU_ACGAIN_N,
        MU_EDSBANK,
        MU_PROFILE_ID,
        MU_SERIAL,
        MU_OFF_UVW,
        MU_PRES_POS,
        MU_SPO_BASE,
        MU_SPO_0,
        MU_SPO_1,
        MU_SPO_2,
        MU_SPO_3,
        MU_SPO_4,
        MU_SPO_5,
        MU_SPO_6,
        MU_SPO_7,
        MU_SPO_8,
        MU_SPO_9,
        MU_SPO_10,
        MU_SPO_11,
        MU_SPO_12,
        MU_SPO_13,
        MU_SPO_14,
        MU_SPO_15,
        MU_RPL_RESET,
        MU_I2C_DEV_START,
        MU_I2C_RAM_START,
        MU_I2C_RAM_END,
        MU_I2C_DEVID,
        MU_I2C_RETRY,
        MU_HARD_REV,
        MU_DEV_ID0,
        MU_DEV_ID1,
        MU_DEV_ID2,
        MU_DEV_ID3,
        MU_DEV_ID4,
        MU_DEV_ID5,
        MU_MFG_ID0,
        MU_MFG_ID1,
        MU_CRC16,
        MU_CRC8,
        MU_AM_MIN,
        MU_AM_MAX,
        MU_AN_MIN,
        MU_AN_MAX,
        MU_STUP,
        MU_CMD_EXE,
        MU_FRQ_CNV,
        MU_FRQ_ABZ,
        MU_NON_CTR,
        MU_MT_CTR,
        MU_MT_ERR,
        MU_EPR_ERR,
        MU_CRC_ERR
    };

    enum MU_Calibration_Unit_
    {
        MU_CALIBRATION_UNIT_RESOLUTION,
        MU_CALIBRATION_UNIT_TURN,
        MU_CALIBRATION_UNIT_DEGREE,
        MU_CALIBRATION_UNIT_RAD
    };

    enum MU_CommandEnum
    {
        MU_CMD_NO_FUNCTION,
        MU_CMD_WRITE_ALL,
        MU_CMD_WRITE_OFF,
        MU_CMD_ABS_RESET,
        MU_CMD_NON_VER,
        MU_CMD_MT_RESET,
        MU_CMD_MT_VER,
        MU_CMD_SOFT_RESET,
        MU_CMD_SOFT_PRES,
        MU_CMD_SOFT_E2P_PRES,
        MU_CMD_I2C_COM,
        MU_CMD_EVENT_COUNT,
        MU_CMD_SWITCH,
        MU_CMD_CRC_VER,
        MU_CMD_CRC_CALC,
        MU_CMD_SET_MTC,
        MU_CMD_RES_MTC,
        MU_CMD_RESERVED0,
        MU_CMD_MODEA_SPI,
        MU_CMD_ROT_POS,
        MU_CMD_ROT_POS_E2P
    };

    enum MU_InterfaceEnum { MU_NO_INTERFACE, MU_MB3U_SPI, MU_MB3U_BISS, MU_MB4U, MU_MB5U };

    [StructLayout(LayoutKind.Sequential)]
    struct MU_Calibration_AnalogTrackAdjustments_
    {
        public byte cosineGain;   // GX_{M; N}
        public byte sineOffset;   // VOSS_{M; N}
        public byte cosineOffset; // VOSC_{M; N}
        public byte phase;        // PH_{M; N}
        public byte phaseRange;   // PHR_{M; N} (with iC-MU{128} not used; 0 only)
    };

    [StructLayout(LayoutKind.Sequential)]
    struct MU_Calibration_RelativeAnalogTrackAdjustments_
    {
        public double cosineGain_lsb;
        public double sineOffset_lsb;
        public double cosineOffset_lsb;
        public double phase_lsb;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct MU_Calibration_NoniusTrackOffsetTable_
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public sbyte spoBase;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public sbyte[] spoN;
    };


    [StructLayout(LayoutKind.Sequential)]
    struct ReadSensStruct
    {
        public UInt32 mt;
        public UInt32 st;
        public UInt32 err;
        public UInt32 warn;
        public UInt32 rawMaster;
        public UInt32 rawNonius;
    }

    class DllImport
    {
        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern MU_ErrorEnum callGetLastError
            (IntPtr handle, ref MU_ErrorEnum lastError, ref MU_ErrorTypeEnum lastErrorType, [MarshalAs(UnmanagedType.LPStr, SizeConst = 1024)] StringBuilder errorText);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_Open(ref IntPtr handle);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_Close(IntPtr handle);


        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_GetInterface(IntPtr handle, ref MU_InterfaceEnum interfaceType);
        
        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_SetInterface(IntPtr handle, MU_InterfaceEnum interfaceType, [In] string interfaceOption);
        

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_ReadChipRevision(IntPtr handle, ref byte revisionId);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_UseRevision(IntPtr handle, byte revisionId);


        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_SetConfig(IntPtr handle, MU_ConfigDataEnum configuration, UInt32 value);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_LoadParams(IntPtr handle, [In] string filepath);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_WriteParams(IntPtr handle, bool verify, out bool[] valid);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_WriteParams2(IntPtr handle);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_ReadParams(IntPtr handle);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum  MU_GetParam(IntPtr handle, MU_ParamEnum parameter, ref UInt32 valueHigh, ref UInt32 valueLow);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MU_getCalibration(IntPtr handle);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_setCalibration(IntPtr handle, [In] IntPtr calibration);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MU_Calibration_delete(IntPtr calibration);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MU_Calibration_getAnalogMasterTrackAdjustments(
            [In] IntPtr calibration, ref MU_Calibration_AnalogTrackAdjustments_ dest);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MU_Calibration_getAnalogNoniusTrackAdjustments(
            [In] IntPtr calibration, ref MU_Calibration_AnalogTrackAdjustments_ dest);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MU_Calibration_setCurrentAnalogTrackAdjustments(
            IntPtr calibration,
            [In] MU_Calibration_AnalogTrackAdjustments_ masterAdjustments,
            [In] MU_Calibration_AnalogTrackAdjustments_ noniusAdjustments);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_activateCalibrationConfig(IntPtr handle);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_deactivateCalibrationConfig(IntPtr handle);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_acquireRawData(
            IntPtr handle,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ref UInt16[] masterRawData,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ref UInt16[] noniusRawData,
            ulong nSamples,     // size_t --> 4byte when 32bit, 8byte when 64bit
            UInt32 slaveId, double frameCycleTime_s,double clockFreq_hz);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_acquireRawData2(
            IntPtr handle, UInt16[] masterRawData, UInt16[] noniusRawData,
            ulong nSamples,     // size_t --> 4byte when 32bit, 8byte when 64bit
            UInt32 slaveId, double frameCycleTime_s, double clockFreq_hz);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr MU_Calibration_analyzeRawData(
            [In] IntPtr calibration, [In] UInt16[] masterTrackRawData, [In] UInt16[] noniusTrackRawData, ulong nRawDataSamples);
        // size_t --> 4byte when 32bit, 8byte when 64bit

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern ulong getAnalyzeResultLogSize([In] IntPtr analyzeResult);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void getAnalyzeResultLogMsg(
            [In] IntPtr analyzeResult, ulong size, [MarshalAs(UnmanagedType.LPStr, SizeConst = 4096)] StringBuilder RltMsg);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void MU_Calibration_getRelativeMasterTrackAdjustments(
            [In] IntPtr analyzeResult, ref MU_Calibration_RelativeAnalogTrackAdjustments_ dest);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void MU_Calibration_getRelativeNoniusTrackAdjustments(
            [In] IntPtr analyzeResult, ref MU_Calibration_RelativeAnalogTrackAdjustments_ dest);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool printAnalogAnalyzeResultAdjustableLog(
            [In] IntPtr calibration, [In] IntPtr analyzeResult, [MarshalAs(UnmanagedType.LPStr, SizeConst = 1024)] StringBuilder RltMsg);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool MU_Calibration_adjustAnalogByAnalyzeResult(IntPtr calibration, [In] IntPtr analyzeResult);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void MU_CalibrationAnalyzeResult_delete(IntPtr analyzeResult);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern sbyte getOptimizedNoniusTrackOffsetTable([In] IntPtr analyzeResult, sbyte[] table);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long MU_Calibration_noniusPhaseMarginMax([In] IntPtr analyzeResult);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long MU_Calibration_noniusPhaseMarginMin([In] IntPtr analyzeResult);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long MU_Calibration_noniusPhaseRangeLimit([In] IntPtr analyzeResult);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double MU_Calibration_noniusUpperPhaseMargin([In] IntPtr analyzeResult);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double MU_Calibration_noniusLowerPhaseMargin([In] IntPtr analyzeResult);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern ulong MU_Calibration_numberOfNoniusCurveSamples([In] IntPtr analyzeResult);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getNoniusPhaseError([In] IntPtr analyzeResult, int[] data);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getNoniusTrackOffsetCurve([In] IntPtr analyzeResult, int[] data);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void getnoniusPhaseMargin([In] IntPtr analyzeResult, int[] data);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern ulong MU_Calibration_calculateNoniusPosition(
            [In] IntPtr analyzeResult, double[] dest, ulong destBufferSize, MU_Calibration_Unit_ unit, bool continuous);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool setCurrentNoniusTrackOffsetTable(IntPtr calibration, [In]IntPtr analyzeResult);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern MU_ErrorEnum MU_WriteCmdRegister(IntPtr handle, MU_CommandEnum command);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern MU_ErrorEnum MU_ReadSens(IntPtr handle, ReadSensStruct data);

        [DllImport("myWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern MU_ErrorEnum MU_readSens2(IntPtr handle, uint mt, uint st, uint err, uint warn, uint rawMaster, uint rawNonius);


        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MU_Interface_nearestPossibleFrameCycleTime(MU_InterfaceEnum interfaceType, double frameCycleTime_s);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MU_Interface_nextPossibleFrameCycleTime(MU_InterfaceEnum interfaceType, double frameCycleTime_s);

        [DllImport("MU_3SL_interface_64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MU_Interface_nearestPossibleClockFreq(MU_InterfaceEnum interfaceType, double clockFreq_hz);
    }
}
