using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalDiary2
{
    internal class global 
    {
        public global(){}

        //DataBase Connection Information(DBID, DBSID, PORT, ID, PW)
        //DEFAULT PORT IS 1521.
        public String address = "koyoungsuk2.iptime.org";
        public String port = "1521";
        public String sid = "xe";
        public String id = "dbid";
        public String pw = "dbpw";
        //DataBase Connection Information is censored due to security.

        public String connectionString(String address, String port, String sid, String id, String pw)
        {
            String connstr = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id={3};Password={4}", address, port, sid, id, pw);
            return connstr;
        }

        public String checkOS()
        {
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString();
            string osBuild = Registry.GetValue(HKLMWinNTCurrent, "CurrentBuildNumber", "").ToString();
            String label;
            String[] osName_arr = osName.Split(' ');
            if (osName_arr[1].Equals("10"))
            {
                if (Int32.Parse(osBuild) > 21000)
                {
                    label = "Your OS: Windows 11 " + osName_arr[2] + " Build: " + osBuild;
                }
                else
                {
                    label = "Your OS: " + osName + " Build: " + osBuild;
                }
            }
            else
            {
                label = "Your OS: " + osName + " Build: " + osBuild;
            }
            return label;
        }
        public void errormessage(String errormsg)
        {
            MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void informationmessage(String msg)
        {
            MessageBox.Show(msg, "PersonalDiary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
