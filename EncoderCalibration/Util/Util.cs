using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncoderCalibration
{
    class Util
    {
        // login dll superuser ID: angrnd, PW: angrnd2011
        public static LogInVar LogInProcess()
        {
            LogInVar ret = new LogInVar();
            try
            {
                string retstr = LOGIN.LOGIN.LogIn();
                string[] temp = retstr.Split(',');
                if (temp.Length < 2)
                {
                    ret.szID = "";
                    ret.iLvl = -2;
                    return ret;
                }
                else
                {
                    ret.szID = temp[0];
                    ret.iLvl = Convert.ToInt16(temp[1]);
                    return ret;
                }
            }
            catch (Exception exep)
            {
                ret.szID = "";
                ret.iLvl = -2;
                Log.LogStr(true, "Login", "Exception occured: " + exep.Message);
                return ret;
            }
        }
    }
}
