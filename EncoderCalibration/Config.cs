using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderCalibration
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            switch (SysVar.iStartUpPos)
            {
                case 1:
                    rBtnLeft.Checked = true;
                    rBtnRight.Checked = false;
                    break;
                case 2:
                    rBtnLeft.Checked = false;
                    rBtnRight.Checked = true;
                    break;
            }

            tBoxGCMin.Text = Spec.GC_Min.ToString();
            tBoxGCMax.Text = Spec.GC_Max.ToString();
            tBoxGFMin.Text = Spec.GF_Min.ToString();
            tBoxGFMax.Text = Spec.GF_Max.ToString();
            tBoxGXMin.Text = Spec.GX_Min.ToString();
            tBoxGXMax.Text = Spec.GX_Max.ToString();
            tBoxVOSSMin.Text = Spec.VOSS_Min.ToString();
            tBoxVOSSMax.Text = Spec.VOSS_Max.ToString();
            tBoxVOSCMin.Text = Spec.VOSC_Min.ToString();
            tBoxVOSCMax.Text = Spec.VOSC_Max.ToString();
            tBoxPHMin.Text = Spec.PH_Min.ToString();
            tBoxPHMax.Text = Spec.PH_Max.ToString();
            tBoxGXErrMin.Text = Spec.GX_ErrMin.ToString();
            tBoxGXErrMax.Text = Spec.GX_ErrMax.ToString();
            tBoxVOSSErrMin.Text = Spec.VOSS_ErrMin.ToString();
            tBoxVOSSErrMax.Text = Spec.VOSS_ErrMax.ToString();
            tBoxVOSCErrMin.Text = Spec.VOSC_ErrMin.ToString();
            tBoxVOSCErrMax.Text = Spec.VOSC_ErrMax.ToString();
            tBoxPHErrMin.Text = Spec.PH_ErrMin.ToString();
            tBoxPHErrMax.Text = Spec.PH_ErrMax.ToString();
            tBoxNoniusMin.Text = Spec.nonius_Inrange_Min.ToString();
            tBoxNoniusMax.Text = Spec.nonius_Inrange_Max.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string FilePath;
            string strTemp = Application.StartupPath;
            FilePath = strTemp + "\\ini\\Config.ini";
            FileInfo f = new FileInfo(FilePath);

            try
            {
                if (!f.Directory.Exists)
                    f.Directory.Create();

                if (!f.Exists)
                {
                    FileStream fs = f.Create();
                    fs.Close();
                    f.Delete();

                    if (rBtnLeft.Checked) SysVar.iStartUpPos = 1;
                    else if (rBtnRight.Checked) SysVar.iStartUpPos = 2;
                    CodeINI.WriteIniFilePath(FilePath, "System", "DpPos", SysVar.iStartUpPos.ToString());
                    Main.bFrmPosRefreshReq = true;

                    Spec.GC_Min = Convert.ToDouble(tBoxGCMin.Text);
                    Spec.GC_Max = Convert.ToDouble(tBoxGCMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GCMin", Spec.GC_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GCMax", Spec.GC_Max.ToString());
                    Spec.GF_Min = Convert.ToDouble(tBoxGFMin.Text);
                    Spec.GF_Max = Convert.ToDouble(tBoxGFMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GFMin", Spec.GF_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GFMax", Spec.GF_Max.ToString());
                    Spec.GX_Min = Convert.ToDouble(tBoxGXMin.Text);
                    Spec.GX_Max = Convert.ToDouble(tBoxGXMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GXMin", Spec.GX_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GXMax", Spec.GX_Max.ToString());
                    Spec.VOSS_Min = Convert.ToDouble(tBoxVOSSMin.Text);
                    Spec.VOSS_Max = Convert.ToDouble(tBoxVOSSMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSSMin", Spec.VOSS_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSSMax", Spec.VOSS_Max.ToString());
                    Spec.VOSC_Min = Convert.ToDouble(tBoxVOSCMin.Text);
                    Spec.VOSC_Max = Convert.ToDouble(tBoxVOSCMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSCMin", Spec.VOSC_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSCMax", Spec.VOSC_Max.ToString());
                    Spec.PH_Min = Convert.ToDouble(tBoxPHMin.Text);
                    Spec.PH_Max = Convert.ToDouble(tBoxPHMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "PHMin", Spec.PH_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "PHMax", Spec.PH_Max.ToString());
                    Spec.GX_ErrMin = Convert.ToDouble(tBoxGXErrMin.Text);
                    Spec.GX_ErrMax = Convert.ToDouble(tBoxGXErrMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GXErrMin", Spec.GX_ErrMin.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GXErrMax", Spec.GX_ErrMax.ToString());
                    Spec.VOSS_ErrMin = Convert.ToDouble(tBoxVOSSErrMin.Text);
                    Spec.VOSS_ErrMax = Convert.ToDouble(tBoxVOSSErrMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSSErrMin", Spec.VOSS_ErrMin.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSSErrMax", Spec.VOSS_ErrMax.ToString());
                    Spec.VOSC_ErrMin = Convert.ToDouble(tBoxVOSCErrMin.Text);
                    Spec.VOSC_ErrMax = Convert.ToDouble(tBoxVOSCErrMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSCErrMin", Spec.VOSC_ErrMin.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSCErrMax", Spec.VOSC_ErrMax.ToString());
                    Spec.PH_ErrMin = Convert.ToDouble(tBoxPHErrMin.Text);
                    Spec.PH_ErrMax = Convert.ToDouble(tBoxPHErrMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "PHErrMin", Spec.PH_ErrMin.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "PHErrMax", Spec.PH_ErrMax.ToString());
                    Spec.nonius_Inrange_Min = Convert.ToDouble(tBoxNoniusMin.Text);
                    Spec.nonius_Inrange_Max = Convert.ToDouble(tBoxNoniusMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "InRangeMin", Spec.nonius_Inrange_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "InRangeMax", Spec.nonius_Inrange_Max.ToString());
                }
                else
                {
                    if (rBtnLeft.Checked) SysVar.iStartUpPos = 1;
                    else if (rBtnRight.Checked) SysVar.iStartUpPos = 2;
                    CodeINI.WriteIniFilePath(FilePath, "System", "DpPos", SysVar.iStartUpPos.ToString());
                    Main.bFrmPosRefreshReq = true;

                    Spec.GC_Min = Convert.ToDouble(tBoxGCMin.Text);
                    Spec.GC_Max = Convert.ToDouble(tBoxGCMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GCMin", Spec.GC_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GCMax", Spec.GC_Max.ToString());
                    Spec.GF_Min = Convert.ToDouble(tBoxGFMin.Text);
                    Spec.GF_Max = Convert.ToDouble(tBoxGFMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GFMin", Spec.GF_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GFMax", Spec.GF_Max.ToString());
                    Spec.GX_Min = Convert.ToDouble(tBoxGXMin.Text);
                    Spec.GX_Max = Convert.ToDouble(tBoxGXMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GXMin", Spec.GX_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GXMax", Spec.GX_Max.ToString());
                    Spec.VOSS_Min = Convert.ToDouble(tBoxVOSSMin.Text);
                    Spec.VOSS_Max = Convert.ToDouble(tBoxVOSSMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSSMin", Spec.VOSS_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSSMax", Spec.VOSS_Max.ToString());
                    Spec.VOSC_Min = Convert.ToDouble(tBoxVOSCMin.Text);
                    Spec.VOSC_Max = Convert.ToDouble(tBoxVOSCMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSCMin", Spec.VOSC_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSCMax", Spec.VOSC_Max.ToString());
                    Spec.PH_Min = Convert.ToDouble(tBoxPHMin.Text);
                    Spec.PH_Max = Convert.ToDouble(tBoxPHMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "PHMin", Spec.PH_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "PHMax", Spec.PH_Max.ToString());
                    Spec.GX_ErrMin = Convert.ToDouble(tBoxGXErrMin.Text);
                    Spec.GX_ErrMax = Convert.ToDouble(tBoxGXErrMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GXErrMin", Spec.GX_ErrMin.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "GXErrMax", Spec.GX_ErrMax.ToString());
                    Spec.VOSS_ErrMin = Convert.ToDouble(tBoxVOSSErrMin.Text);
                    Spec.VOSS_ErrMax = Convert.ToDouble(tBoxVOSSErrMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSSErrMin", Spec.VOSS_ErrMin.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSSErrMax", Spec.VOSS_ErrMax.ToString());
                    Spec.VOSC_ErrMin = Convert.ToDouble(tBoxVOSCErrMin.Text);
                    Spec.VOSC_ErrMax = Convert.ToDouble(tBoxVOSCErrMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSCErrMin", Spec.VOSC_ErrMin.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "VOSCErrMax", Spec.VOSC_ErrMax.ToString());
                    Spec.PH_ErrMin = Convert.ToDouble(tBoxPHErrMin.Text);
                    Spec.PH_ErrMax = Convert.ToDouble(tBoxPHErrMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "PHErrMin", Spec.PH_ErrMin.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "PHErrMax", Spec.PH_ErrMax.ToString());
                    Spec.nonius_Inrange_Min = Convert.ToDouble(tBoxNoniusMin.Text);
                    Spec.nonius_Inrange_Max = Convert.ToDouble(tBoxNoniusMax.Text);
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "InRangeMin", Spec.nonius_Inrange_Min.ToString());
                    CodeINI.WriteIniFilePath(FilePath, "Spec", "InRangeMax", Spec.nonius_Inrange_Max.ToString());
                }
            }
            catch (Exception exep)
            {
                Log.LogStr(false, "FAULT", "Save Config.ini file: " + exep.Message.ToString());
            }
        }

        public static bool ReadConfigIni()
        {
            try
            {
                string FilePath;
                string strTemp = Application.StartupPath;
                FilePath = strTemp + "\\ini\\Config.ini";
                FileInfo f = new FileInfo(FilePath);

                if (f.Exists)
                {
                    string sz = CodeINI.ReadIniFilePath(FilePath, "System", "DpPos");
                    if (sz != "") SysVar.iStartUpPos = Convert.ToInt32(sz);
                    else SysVar.iStartUpPos = 1;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "GCMin");
                    if (sz != "") Spec.GC_Min = Convert.ToDouble(sz);
                    else Spec.GC_Min = -10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "GCMax");
                    if (sz != "") Spec.GC_Max = Convert.ToDouble(sz);
                    else Spec.GC_Max = 10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "GFMin");
                    if (sz != "") Spec.GF_Min = Convert.ToDouble(sz);
                    else Spec.GF_Min = -10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "GFMax");
                    if (sz != "") Spec.GF_Max = Convert.ToDouble(sz);
                    else Spec.GF_Max = 10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "GXMin");
                    if (sz != "") Spec.GX_Min = Convert.ToDouble(sz);
                    else Spec.GX_Min = -10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "GXMax");
                    if (sz != "") Spec.GX_Max = Convert.ToDouble(sz);
                    else Spec.GX_Max = 10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "VOSSMin");
                    if (sz != "") Spec.VOSS_Min = Convert.ToDouble(sz);
                    else Spec.VOSS_Min = -10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "VOSSMax");
                    if (sz != "") Spec.VOSS_Max = Convert.ToDouble(sz);
                    else Spec.VOSS_Max = 10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "VOSCMin");
                    if (sz != "") Spec.VOSC_Min = Convert.ToDouble(sz);
                    else Spec.VOSC_Min = -10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "VOSCMax");
                    if (sz != "") Spec.VOSC_Max = Convert.ToDouble(sz);
                    else Spec.VOSC_Max = 10;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "PHMin");
                    if (sz != "") Spec.PH_Min = Convert.ToDouble(sz);
                    else Spec.PH_Min = -2;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "PHMax");
                    if (sz != "") Spec.PH_Max = Convert.ToDouble(sz);
                    else Spec.PH_Max = 2;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "GXErrMin");
                    if (sz != "") Spec.GX_ErrMin = Convert.ToDouble(sz);
                    else Spec.GX_ErrMin = -3;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "GXErrMax");
                    if (sz != "") Spec.GX_ErrMax = Convert.ToDouble(sz);
                    else Spec.GX_ErrMax = 3;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "VOSSErrMin");
                    if (sz != "") Spec.VOSS_ErrMin = Convert.ToDouble(sz);
                    else Spec.VOSS_ErrMin = -3;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "VOSSErrMax");
                    if (sz != "") Spec.VOSS_ErrMax = Convert.ToDouble(sz);
                    else Spec.VOSS_ErrMax = 3;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "VOSCErrMin");
                    if (sz != "") Spec.VOSC_ErrMin = Convert.ToDouble(sz);
                    else Spec.VOSC_ErrMin = -3;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "VOSCErrMax");
                    if (sz != "") Spec.VOSC_ErrMax = Convert.ToDouble(sz);
                    else Spec.VOSC_ErrMax = 3;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "PHErrMin");
                    if (sz != "") Spec.PH_ErrMin = Convert.ToDouble(sz);
                    else Spec.PH_ErrMin = -3;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "PHErrMax");
                    if (sz != "") Spec.PH_ErrMax = Convert.ToDouble(sz);
                    else Spec.PH_ErrMax = 3;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "InRangeMin");
                    if (sz != "") Spec.nonius_Inrange_Min = Convert.ToDouble(sz);
                    else Spec.nonius_Inrange_Min = -60;

                    sz = CodeINI.ReadIniFilePath(FilePath, "Spec", "InRangeMax");
                    if (sz != "") Spec.nonius_Inrange_Max = Convert.ToDouble(sz);
                    else Spec.nonius_Inrange_Max = 60;
                }
            }
            catch (Exception ex)
            {
                Log.LogStr(false, "Warn", "exception in read Config.ini Fail!");
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
