using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace EncoderCalibration
{
    public class IMultiTCPSerDll
    {
        Object m_objDLL;
        Type m_typeDLL;

        string m_strDLLFileName;
        Boolean m_bFind = false;

        // DLL Module 설정
        public IMultiTCPSerDll(string _strDLLFileName)
        {
            m_strDLLFileName = _strDLLFileName;
        }

        // DLL Module 생성
        public bool CreateModule()
        {
            FileInfo f = new FileInfo(m_strDLLFileName);
            m_bFind = f.Exists;

            if (!m_bFind) return false;

            // dll 파일 loading
            Assembly asmDLL = Assembly.LoadFrom(m_strDLLFileName);
            if (asmDLL == null) return false;

            // dll namespace 얻기
            String strLibName = asmDLL.GetName().Name;
            m_typeDLL = asmDLL.GetType(String.Format("{0}.{1}", strLibName, strLibName)); // class type 얻기
            if (m_typeDLL == null) return false;

            m_objDLL = Activator.CreateInstance(m_typeDLL);   // class 객체 생성 
            if (m_objDLL == null) return false;

            return true;
        }

        // DLL Module 실행
        public void Setup()
        {
            if (!m_bFind) return;

            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("Setup");
                miInfo.Invoke(m_objDLL, null);
            }
            catch
            {
                return;
            }
            return;
        }

        // DLL Module 실행
        public void Monitor()
        {
            if (!m_bFind) return;

            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("Monitor");
                miInfo.Invoke(m_objDLL, null);
            }
            catch
            {
                return;
            }
            return;
        }

        // DLL Module 실행
        public Boolean Start()
        {
            if (!m_bFind) return false;

            bool bData;
            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("Start");
                bData = (bool)miInfo.Invoke(m_objDLL, null);


            }
            catch
            {
                return false;
            }
            return bData;
        }

        // DLL Moudle 정지
        public Boolean Stop()
        {
            if (!m_bFind) return false;

            bool bData;
            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("Stop");
                bData = (bool)miInfo.Invoke(m_objDLL, null);
            }
            catch
            {
                return false;
            }
            return bData;

        }

        public bool Connect(int _nDeviceIndex)
        {
            if (!m_bFind) return false;

            bool bData;

            object[] paraInfo = new object[1];
            paraInfo[0] = _nDeviceIndex;

            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("Connect", new Type[] { typeof(int) });
                bData = (bool)miInfo.Invoke(m_objDLL, paraInfo);
            }
            catch
            {
                return false;
            }
            return bData;

        }

        public bool Disconnect(int _nDeviceIndex)
        {
            if (!m_bFind) return false;

            bool bData;

            object[] paraInfo = new object[1];
            paraInfo[0] = _nDeviceIndex;

            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("Disconnect", new Type[] { typeof(int) });
                bData = (bool)miInfo.Invoke(m_objDLL, paraInfo);
            }
            catch
            {
                return false;
            }
            return bData;

        }


        public Boolean SendData(int _nChIndex, string _strData)
        {
            if (!m_bFind) return false;

            Boolean bData = false;

            try
            {
                object[] paraInfo = new object[2];
                paraInfo[0] = _nChIndex;
                paraInfo[1] = _strData;

                MethodInfo miInfo = m_typeDLL.GetMethod("SendData", new Type[] { typeof(int), typeof(string) });
                bData = (bool)miInfo.Invoke(m_objDLL, paraInfo);
            }
            catch
            {
                return bData;
            }
            return bData;
        }

        public Boolean SendData(int _nChIndex, byte[] _bData, int _nLength)
        {
            if (!m_bFind) return false;

            Boolean bData = false;

            try
            {
                object[] paraInfo = new object[3];
                paraInfo[0] = _nChIndex;
                paraInfo[1] = _bData;
                paraInfo[2] = _nLength;

                MethodInfo miInfo = m_typeDLL.GetMethod("SendData", new Type[] { typeof(int), typeof(byte[]), typeof(int) });
                bData = (bool)miInfo.Invoke(m_objDLL, paraInfo);
            }
            catch
            {
                return bData;
            }
            return bData;
        }

        // DLL Instance Destory
        public void DestoryModule()
        {
            if (!m_bFind) return;

            if (m_objDLL != null)
                m_objDLL = null;

            if (m_typeDLL != null)
                m_typeDLL = null;
        }

        public string SGetValue(int _nChannelIndex)
        {
            if (!m_bFind) return "";

            string strData = "";

            object[] paraInfo = new object[1];
            paraInfo[0] = _nChannelIndex;
           
            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("SGetValue", new Type[] {typeof(int)});
                strData = (string)miInfo.Invoke(m_objDLL, paraInfo);

                return strData;
            }
            catch
            {
                return "";
            }
        }

        public bool SGetValue(string[] _strReadBuf)
        {
            object[] paraInfo = new object[1];
            paraInfo[0] = _strReadBuf;

            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("SGetValue", new Type[] { typeof(string[]) });
                miInfo.Invoke(m_objDLL, paraInfo);

                return true;
            }
            catch
            {
                return false;
            }
        }

        // 모든 채널 버퍼 클리어
        public void AllBufferClear()
        {
            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("AllBufferClear");
                miInfo.Invoke(m_objDLL, null);
            }
            catch
            {
                return;
            }
        }

        // 선택 채널 버퍼 클리어
        public void BufferClear(int _nChannelIndex)
        {
            object[] paraInfo = new object[1];
            paraInfo[0] = _nChannelIndex;

            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("BufferClear", new Type[] { typeof(int) });
                miInfo.Invoke(m_objDLL, paraInfo);

                return;
            }
            catch
            {
                return;
            }
        }

        // Read Device One Status
        public int GetDeviceStatus(int _nChannelIndex)
        {
            int nData = 0;  // 0 : STOP, 1 : RUN, 2 : ERROR

            try
            {
                object[] paraInfo = new object[1];
                paraInfo[0] = _nChannelIndex;

                MethodInfo miInfo = m_typeDLL.GetMethod("GetDeviceStatus", new Type[] { typeof(int) });
                nData = (int)miInfo.Invoke(m_objDLL, paraInfo);
            }
            catch
            {
                return nData;
            }
            return nData;
        }

        // Read Device Multi Status
        public bool GetDeviceStatus(int[] _nDeviceStatus)
        {
            bool nData = false;

            object[] paraInfo = new object[1];
            paraInfo[0] = _nDeviceStatus;  // 0 : STOP, 1 : RUN, 2 : ERROR
           
            try
            {
                MethodInfo miInfo = m_typeDLL.GetMethod("GetDeviceStatus", new Type[] { typeof(int[]) });
                nData = (bool)miInfo.Invoke(m_objDLL, paraInfo);
            }
            catch
            {
                return nData;
            }
            return nData;
        }
    }

}
