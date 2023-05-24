using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalDiary2
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]

        static void Main()
        {
            
            if (AdministratorConfirmed()) //관리자 권한일때는 그냥 실행 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm());
            }
            else //관리자 권한이 아닐때는 관리자 권한으로 실행하게 함. 
            {
                try
                {
                    ProcessStartInfo info = new ProcessStartInfo()
                    {
                        UseShellExecute = true,
                        FileName = Application.ExecutablePath,
                        WorkingDirectory = Environment.CurrentDirectory,
                        Verb = "runas"
                    };

                    Process.Start(info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static bool AdministratorConfirmed()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            bool administratorconfirm = false;
            if (identity != null)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                administratorconfirm = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            return administratorconfirm;
        }
    }
}
