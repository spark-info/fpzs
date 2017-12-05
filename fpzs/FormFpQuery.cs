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
    public partial class FormFpQuery : Form
    {
        public FormFpQuery()
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
            /*
            DateTime dtMonth = dtpMonth.Value;
            if(!TaxBoxAisino.Instance.Open(AppConfig.Instance.CertPassword))
            {
                MessageBox.Show("打开金税盘失败。","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            dgvFapiao.Rows.Clear();
            List<Fapiao> list = TaxBoxAisino.Instance.GetFapiao(dtMonth.Year, dtMonth.Month);
            foreach(Fapiao fp in list)
            {
                int n = dgvFapiao.Rows.Add();
                List<VisualProperty> properties = VisualProperty.GetValueWithChineseName(fp);
                foreach (VisualProperty property in properties)
                {
                    dgvFapiao.Rows[n].Cells[property.Name].Value = property.Value.ToString();
                }
            }

            MessageBox.Show("同步" + dtMonth.Year + "年" + dtMonth.Month + "月发票数据[ " + list.Count + " ]条！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
             */
        }

        private void menuOptions_Click(object sender, EventArgs e)
        {
            FormOptions frm = new FormOptions();
            frm.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            /*
            List<VisualProperty> properties = VisualProperty.GetChineseName(typeof(Fapiao));
            foreach (VisualProperty property in properties)
            {
                dgvFapiao.Columns.Add(property.Name, property.ChineseName);
            }*/
        }
    }
}
