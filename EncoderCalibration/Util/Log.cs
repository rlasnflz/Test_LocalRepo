using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace EncoderCalibration
{
    public delegate void LogEventHandler(string who, string msg);

    class Log
    {
        public static event LogEventHandler LogEvent;     // to update log listview
        private static string sOldMsg = "";
        private static string sOldWho = "";

        private static string GetTestLogFileName()
        {
            string sDir = Application.StartupPath + "\\TestLog";
            string yyyy = DateTime.Now.Year.ToString();
            string mm = DateTime.Now.Month.ToString();
            string dd = DateTime.Now.Day.ToString();
            sDir = string.Format("{0}\\{1}\\{2}\\{3}", sDir, yyyy, mm, dd);

            if (!Directory.Exists(sDir)) Directory.CreateDirectory(sDir);

            //return string.Format("{0}\\{1}.log", sDir, barcode);
            //return string.Format("{0}\\{1}.log", sDir, "barcode");
            return string.Format("{0}\\{1}.log", sDir, DateTime.Now.ToString("yyyyMMddHHmm"));
        }

        public static bool TestLogStr(bool fileonly, string who, string msg)
        {
            if (!sOldMsg.Equals(msg) || !sOldWho.Equals(who))
            {
                sOldMsg = msg;
                sOldWho = who;
                try
                {
                    FileStream LogStream = new FileStream(GetTestLogFileName(), FileMode.Append);

                    if (!LogStream.CanWrite)
                    {
                        LogStream.Close();
                        return false;
                    }

                    StreamWriter LogWriter = new StreamWriter(LogStream);
                    LogWriter.Write(string.Format("[{0}]\t[{1}]\t\t{2}\r\n", DateTime.Now.ToString("HH:mm:ss.fff"), who, msg));
                    LogWriter.Flush();
                    LogWriter.Close();
                    LogStream.Close();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private static string GetLogFileName(bool IsFault)
        {
            string sDir = Application.StartupPath + "\\Log";
            string yyyy = DateTime.Now.Year.ToString();
            string mm = DateTime.Now.Month.ToString();
            sDir = string.Format("{0}\\{1}\\{2}", sDir, yyyy, mm);

            if (!Directory.Exists(sDir)) Directory.CreateDirectory(sDir);

            if (IsFault)
                return string.Format("{0}\\{1}_Fault.log", sDir, DateTime.Now.ToString("yyyyMMdd"));
            else
                return string.Format("{0}\\{1}.log", sDir, DateTime.Now.ToString("yyyyMMdd"));
        }

        public static bool LogStr(bool fileonly, string who, string msg)
        {
            if (!fileonly)
                LogEvent(who, msg);                    // to update log listview

            if (!sOldMsg.Equals(msg))
            {
                sOldMsg = msg;
                try
                {
                    FileStream LogStream = new FileStream(GetLogFileName(false), FileMode.Append);

                    if (!LogStream.CanWrite)
                    {
                        LogStream.Close();
                        return false;
                    }

                    StreamWriter LogWriter = new StreamWriter(LogStream);
                    LogWriter.Write(string.Format("[{0}]\t[{1}]\t{2}\r\n", DateTime.Now.ToString("HH:mm:ss.fff"), who, msg));
                    LogWriter.Flush();
                    LogWriter.Close();
                    LogStream.Close();

                    if (who.ToLower() == "fault")
                    {
                        LogStream = new FileStream(GetLogFileName(true), FileMode.Append);

                        if (!LogStream.CanWrite)
                        {
                            LogStream.Close();
                            return false;
                        }

                        LogWriter = new StreamWriter(LogStream);
                        LogWriter.Write(string.Format("[{0}][{1}]:\t{2}\r\n", DateTime.Now.ToString("HH:mm:ss.fff"), who, msg));
                        LogWriter.Flush();
                        LogWriter.Close();
                        LogStream.Close();
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}
