using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fpzs
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void menuCheckUpdate_Click(object sender, EventArgs e)
        {
            string currentProcessId = Convert.ToString(Process.GetCurrentProcess().Id);
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("au.exe", currentProcessId);
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
        }

        private void menuOptions_Click(object sender, EventArgs e)
        {
            FormOptions frm = new FormOptions();
            frm.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            frm.StartPosition = FormStartPosition.CenterScreen;
            OpenChild(frm);
        }

        private void menuExcelToXml_Click(object sender, EventArgs e)
        {
            FormExcelToXml frm = new FormExcelToXml();
            frm.StartPosition = FormStartPosition.CenterScreen;
            OpenChild(frm);
        }

        private void OpenChild(Form child)
        {
            Form[] array = this.MdiChildren;
            foreach (Form frm in array)
            {
                if (frm.GetType().Equals(child.GetType()))
                {
                    frm.BringToFront();
                    return;
                }
            }
            child.MdiParent = this;
            child.Show();
        }

        private void menuCustomizeExcel_Click(object sender, EventArgs e)
        {
            FormCustomizeExcel frm = new FormCustomizeExcel();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Maximized;
            OpenChild(frm);
        }
    }
}
