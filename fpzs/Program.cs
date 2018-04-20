using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fpzs
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //StartAutoUpdate();
            App.Instance.Initialize();
            Application.Run(new FormMain());
        }

        private static void StartAutoUpdate()
        {
            try 
            {
                string currentProcessId = Convert.ToString(Process.GetCurrentProcess().Id);
                string arguments = currentProcessId + " " + Application.ExecutablePath;
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo("au.exe", arguments);
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
            catch(Exception ex)
            {
                MessageBox.Show("启动自动更新失败。\n" + ex.StackTrace,"发票助手");
            }
        }
    }
}
