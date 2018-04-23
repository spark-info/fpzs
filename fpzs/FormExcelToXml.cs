using fpzs.bl;
using fpzs.cl;
using fpzs.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fpzs
{
    public partial class FormExcelToXml : Form
    {
        private DocumentManager docMgr;
        public FormExcelToXml()
        {
            InitializeComponent();
        }
        private void FormExcelToXml_Load(object sender, EventArgs e)
        {
            docMgr = new DocumentManager(App.Instance.GetSqliteHelper());

            cbInvoiceType.Items.Add(InvoiceTypeWrapper.GetText(InvoiceType.Electric));
            cbInvoiceType.Items.Add(InvoiceTypeWrapper.GetText(InvoiceType.Special));
            cbInvoiceType.Items.Add(InvoiceTypeWrapper.GetText(InvoiceType.Common));
            cbInvoiceType.SelectedIndex = 0;
        }
        private void btnXmlFilepath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Xml文件|*.xml";
            if(sfd.ShowDialog()==DialogResult.OK)
            {
                tbXmlFilepath.Text = sfd.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            string excelFilepath = tbExcelFilepath.Text;
            string xmlFilepath = tbXmlFilepath.Text;
            InvoiceType invoiceType = InvoiceTypeWrapper.TextOf(cbInvoiceType.Text);

            Dictionary<string,List<DocumentExcel>> dict = docMgr.ParseExcel(excelFilepath);
            List<Document> list = docMgr.ConvertToDocument(dict);
            InvokeResult result = docMgr.SaveDocument(list);
            //ExcelToXml excelToXml = new ExcelToXml();
            //InvokeResult result = excelToXml.ConvertExcelToXml(excelFilepath, xmlFilepath, invoiceType);
            if(result.State)
            {
                MessageBox.Show("开票文件已生成：" + xmlFilepath, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("开票文件生成失败。" + result.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcelFilepath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel文件|*.xlsx";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                tbExcelFilepath.Text = ofd.FileName;
            }
        }
    }
}
