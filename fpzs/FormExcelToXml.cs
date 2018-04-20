using fpzs.bl;
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
        public FormExcelToXml()
        {
            InitializeComponent();
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
            InvoiceType invoiceType = GetInvoiceType();

            ExcelToXml excelToXml = new ExcelToXml();
            InvokeResult result = excelToXml.ConvertExcelToXml(excelFilepath, xmlFilepath, invoiceType);
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

        private InvoiceType GetInvoiceType()
        {
            InvoiceType invtype = InvoiceType.Electric;
            string str = cbInvoiceType.Text;
            if(str.Equals(DescriptionAttributeUtils.GetEnumDescription(InvoiceType.Common)))
            {
                invtype = InvoiceType.Common;
            }
            else if(str.Equals(DescriptionAttributeUtils.GetEnumDescription(InvoiceType.Special)))
            {
                invtype = InvoiceType.Special;
            }
            else if(str.Equals(DescriptionAttributeUtils.GetEnumDescription(InvoiceType.Electric)))
            {
                invtype = InvoiceType.Electric;
            }
            else
            {
                throw new Exception("发票种类不存在！");
            }

            return invtype;
        }

        private void FormExcelToXml_Load(object sender, EventArgs e)
        {
            cbInvoiceType.Items.Add(DescriptionAttributeUtils.GetEnumDescription(InvoiceType.Electric));
            cbInvoiceType.Items.Add(DescriptionAttributeUtils.GetEnumDescription(InvoiceType.Special));
            cbInvoiceType.Items.Add(DescriptionAttributeUtils.GetEnumDescription(InvoiceType.Common));
            cbInvoiceType.SelectedIndex = 0;
        }
    }
}
