using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fpzs
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {

            tbCertPassword.Text = AppConfig.Instance.CertPassword;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.CertPassword = tbCertPassword.Text;
            Close();
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
