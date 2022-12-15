using System;
using System.IO;
using System.Text;
using IniHandler1;
using System.Runtime.InteropServices;


namespace EncoderCalibration
{
    public class IniControl1
    {
        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32")]
        public static extern uint GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
    }

    public class myFuction
    {
        public static bool IsNumeric(string txt)
        {

            //for (int i =0; i<txt.Length(); i++)
            //{
            //    char.
            string a = txt.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(txt.Trim(), "^([0-9,-])"))
                return false;
            else
                return true;
        }

    }

    public class CodeINI
    {
        public static String MTree;
        public static int TCount;


        public static void IniFileCreate(string FileName, string title)
        {
            FileStream IniStream = new FileStream(FileName, FileMode.Create);
            if (!IniStream.CanWrite)
            {
                IniStream.Close();
                return;
            }
            StreamWriter writer = new StreamWriter(IniStream);
            writer.Write("[" + title + "]");
            writer.Flush();
            writer.Close();

        }

        public static void WriteIniFile(string title, string subtitle, string value)
        {
            //           IniControl1.WritePrivateProfileString( title,subtitle,value, Main.mFileName);

            //    IniControl1.WritePrivateProfileString("CHANNEL", i.ToString(), strValue, VAR.Filepath);

            ////string sPath = System.Environment.SystemDirectory;
            //IniStructure1 IniFile = IniStructure1.ReadIni(Main.mFileName);
            //IniFile.DeleteValue(title, subtitle);
            //IniFile.AddValue(title, subtitle, value);

            //IniStructure1.WriteIni(IniFile, Main.mFileName, "");
        }

        public static void WriteIniFilePath(string FileName, string title, string subtitle, string value)
        {

            IniControl1.WritePrivateProfileString(title, subtitle, value, FileName);

            ////string sPath = System.Environment.SystemDirectory;
            //IniStructure1 IniFile = IniStructure1.ReadIni(FileName);
            //IniFile.DeleteValue(title, subtitle);

            //IniFile.AddValue(title, subtitle, value);
            //IniStructure1.WriteIni(IniFile, FileName, "");
        }

        public static void WriteIniFileCategory(string FileName, string title)
        {
            //string sPath = System.Environment.SystemDirectory;

            //  IniStructure1 IniFile = IniStructure1.ReadIni(FileName);
            IniStructure IniFile = IniStructure.ReadIni(FileName);
            if (IniFile == null)
            {

            }

            // if (ctg == null) IniFile.DeleteCategory(title);

            IniFile.AddCategory(title);

            IniStructure.WriteIni(IniFile, FileName, "");
        }

        public static void DeleteIniFile(string FileName, string title, string subtitle)
        {
            //string rINI;
            IniStructure IniFile = IniStructure.ReadIni(FileName);
            if (IniFile != null)
                IniFile.DeleteValue(title, subtitle);
            IniStructure.WriteIni(IniFile, FileName, "");
        }

        public static string ReadIniFile(string title, string subtitle)
        {
            string rINI = "";
            //IniStructure1 IniFile = IniStructure1.ReadIni(Main.mFileName);
            //if (IniFile == null) return "";

            //rINI = Convert.ToString(IniFile.GetValue(title, subtitle));
            return rINI;

        }

        public static string ReadIniFilePath(string FileName, string title, string subtitle)
        {
            StringBuilder rINI;
            rINI = new StringBuilder("", 5120);
            IniControl1.GetPrivateProfileString(title, subtitle, "", rINI, 5120, FileName);

            return rINI.ToString();
        }


        public static string ReadIniFilePath(string FileName, string title, string subtitle, double dDefault)
        {
            StringBuilder rINI;
            rINI = new StringBuilder("", 5120);
            IniControl1.GetPrivateProfileString(title, subtitle, "", rINI, 5120, FileName);
            if (rINI.ToString() == "")
                return dDefault.ToString();
            else
                return rINI.ToString();
        }

        public static string ReadItem(string FileName, int ictg, int ikey)
        {
            //string sPath = System.Environment.SystemDirectory;
            //IniStructure1 IniFile = IniStructure1.ReadIni(sPath + @"\" + asFileName);
            string rINI;
            IniStructure IniFile = IniStructure.ReadIni(FileName);
            if (IniFile == null) return "";

            rINI = Convert.ToString(IniFile.GetKeyName(ictg, ikey));

            return rINI;
        }

        public static void DeleteCatagory(string FileName, string cty)
        {
            //string sPath = System.Environment.SystemDirectory;
            //IniStructure1 IniFile = IniStructure1.ReadIni(sPath + @"\" + asFileName);
            //string rINI;
            IniStructure IniFile = IniStructure.ReadIni(FileName);
            if (IniFile == null) return;

            IniFile.DeleteCategory(cty);
        }

        public static void CreateCatagory(string FileName, string cty)
        {
            //string sPath = System.Environment.SystemDirectory;
            //IniStructure1 IniFile = IniStructure1.ReadIni(sPath + @"\" + asFileName);
            //string rINI;
            IniStructure IniFile = IniStructure.ReadIni(FileName);
            if (IniFile == null) return;


            FileStream IniStream = new FileStream(FileName, FileMode.Create);
            if (!IniStream.CanWrite)
            {
                IniStream.Close();
                return;
            }
            StreamWriter writer = new StreamWriter(IniStream);
            writer.Write("[" + cty + "]");
            writer.Flush();
            writer.Close();

        }
    }
}