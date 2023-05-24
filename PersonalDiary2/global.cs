using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Renci.SshNet;

namespace PersonalDiary2
{
    internal class global 
    {
        public global(){}

        //DataBase Connection Information(DBID, DBSID, PORT, ID, PW)
        //DEFAULT PORT IS 1521.
        /*
        public String address = "koyoungsuk2.iptime.org";
        public String port = "1521";
        public String sid = "xe";
        public String id = "dbid";
        public String pw = "dbpw";
        */
        //DataBase Connection Information is censored due to security.

        #region["연결 정보 스트링"] 
        public String connectionString(String address, String port, String sid, String id, String pw)
        {
            String connstr = String.Format("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User Id={3};Password={4}", address, port, sid, id, pw);
            return connstr;
        }
        #endregion


        #region["OS 버전 체크"] 
        public String checkOS()
        {
            string HKLMWinNTCurrent = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string osName = Registry.GetValue(HKLMWinNTCurrent, "productName", "").ToString();
            string osBuild = Registry.GetValue(HKLMWinNTCurrent, "CurrentBuildNumber", "").ToString();
            String label;
            String[] osName_arr = osName.Split(' ');
            if (osName_arr[1].Equals("10"))
            {
                if (Int32.Parse(osBuild) > 22000) //Windows 11과 Windows 10, Windows Server 2016~2022 구분 
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
        #endregion

        #region["오류 메시지"] 
        public DialogResult errormessage(String errormsg)
        {
            return MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region["정보 메시지"] 
        public DialogResult informationmessage(String msg)
        {
            return MessageBox.Show(msg, "MyDiary", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        #endregion


        #region["SFTP 파일 업로드"]
        public void UploadSFTP(String FileName, String SafeFileName) //FileName: 전체경로, SafeFileName: 부분경로 
        {
            StreamReader sr = new StreamReader("sftp.txt"); //텍스트파일에서 SFTP 정보를 불러온다. 

            String full = sr.ReadToEnd();

            String sftp_address = full.Split(',')[0];

            String sftp_id = full.Split(',')[1];
            String sftp_pw = full.Split(',')[2];

            sftp_address = sftp_address.Trim();
            sftp_id = sftp_id.Trim();
            sftp_pw = sftp_pw.Trim();

            SftpClient sc = new SftpClient(sftp_address, sftp_id, sftp_pw);

            FileStream fs = new FileStream(FileName, FileMode.Open);
            sc.Connect();

            //SFTP 서버는 우분투 20.04 LTS 운영 체제가 깔려 있음. 
            sc.UploadFile(fs, "/mnt/hdd3/Secret Documents/Self-Criticism/Before 2020-07/" + SafeFileName); //SFTP 업로드 

            sc.Disconnect();
        }
        #endregion


        #region["SFTP 파일 삭제"] 
        //일기장 데이터베이스에서 삭제할때 파일도 같이 삭제 
        public void DeleteSFTP(String SafeFileName)
        {
            StreamReader sr = new StreamReader("sftp.txt");

            String full = sr.ReadToEnd();

            String sftp_address = full.Split(',')[0];

            String sftp_id = full.Split(',')[1];
            String sftp_pw = full.Split(',')[2];

            sftp_address = sftp_address.Trim();
            sftp_id = sftp_id.Trim();
            sftp_pw = sftp_pw.Trim();

            System.Diagnostics.Debug.WriteLine("sftp_pw: " + sftp_pw);

            SftpClient sc = new SftpClient(sftp_address, sftp_id, sftp_pw);

            //FileStream fs = new FileStream(FileName, FileMode.Open);
            sc.Connect();

            sc.DeleteFile("/mnt/hdd3/Secret Documents/Self-Criticism/Before 2020-07/" + SafeFileName);

            sc.Disconnect();
        }
        #endregion  
    }
}
