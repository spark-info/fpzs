using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace au
{
    static class Program
    {
        public static int PARENT_PROGRAM_PROCESS_ID = 0;
        public static string PARENT_PROGRAM_EXE_FILEPATH = "";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(args.Length>=2)
            { 
                PARENT_PROGRAM_PROCESS_ID = Convert.ToInt32(args[0]);
                PARENT_PROGRAM_EXE_FILEPATH = args[1];
            }
            Application.Run(new FormProgress());
        }
    }
}
