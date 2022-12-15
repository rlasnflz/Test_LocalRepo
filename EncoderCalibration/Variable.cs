using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoderCalibration
{

    public class LogInVar
    {
        public string szID;
        public int iLvl; // = new int();
        public const int ANGPIC = 50;
        public const int LGITPIC = 30;
    }

    public class SysVar
    {
        public static int iStartUpPos = new int();
        // 1: left, 2: right
    }

    public class Rlt
    {
        public static string barcode = string.Empty;

        public static bool totalJudge = new bool();

        // signal conditioning
        // master
        public static bool GC_M_Judge = new bool();
        public static double GC_M_Val = new double();
        public static bool GF_M_Judge = new bool();
        public static double GF_M_Val = new double();
        public static bool GX_M_Judge = new bool();
        public static double GX_M_Val = new double();
        public static bool VOSS_M_Judge = new bool();
        public static double VOSS_M_Val = new double();
        public static bool VOSC_M_Judge = new bool();
        public static double VOSC_M_Val = new double();
        public static bool PH_M_Judge = new bool();
        public static double PH_M_Val = new double();
        // nonius
        public static bool GC_N_Judge = new bool();
        public static double GC_N_Val = new double();
        public static bool GF_N_Judge = new bool();
        public static double GF_N_Val = new double();
        public static bool GX_N_Judge = new bool();
        public static double GX_N_Val = new double();
        public static bool VOSS_N_Judge = new bool();
        public static double VOSS_N_Val = new double();
        public static bool VOSC_N_Judge = new bool();
        public static double VOSC_N_Val = new double();
        public static bool PH_N_Judge = new bool();
        public static double PH_N_Val = new double();
        // relative chagnes
        public static bool GX_MErr_Judge = new bool();
        public static double GX_MErr_Val = new double();
        public static bool VOSS_MErr_Judge = new bool();
        public static double VOSS_MErr_Val = new double();
        public static bool VOSC_MErr_Judge = new bool();
        public static double VOSC_MErr_Val = new double();
        public static bool PH_MErr_Judge = new bool();
        public static double PH_MErr_Val = new double();
        public static bool GX_NErr_Judge = new bool();
        public static double GX_NErr_Val = new double();
        public static bool VOSS_NErr_Judge = new bool();
        public static double VOSS_NErr_Val = new double();
        public static bool VOSC_NErr_Judge = new bool();
        public static double VOSC_NErr_Val = new double();
        public static bool PH_NErr_Judge = new bool();
        public static double PH_NErr_Val = new double();
        // nonius calibration
        public static bool nonius_InRange_Judge = new bool();
        public static double nonius_InRange_Min = new double();
        public static double nonius_InRange_Max = new double();
    }

    public class Spec
    {
        public static double GC_Min = new double();
        public static double GC_Max = new double();
        public static double GF_Min = new double();
        public static double GF_Max = new double();
        public static double GX_Min = new double();
        public static double GX_Max = new double();
        public static double VOSS_Min = new double();
        public static double VOSS_Max = new double();
        public static double VOSC_Min = new double();
        public static double VOSC_Max = new double();
        public static double PH_Min = new double();
        public static double PH_Max = new double();
        public static double GX_ErrMin = new double();
        public static double GX_ErrMax = new double();
        public static double VOSS_ErrMin = new double();
        public static double VOSS_ErrMax = new double();
        public static double VOSC_ErrMin = new double();
        public static double VOSC_ErrMax = new double();
        public static double PH_ErrMin = new double();
        public static double PH_ErrMax = new double();
        public static double nonius_Inrange_Min = new double();
        public static double nonius_Inrange_Max = new double();
    }

}
