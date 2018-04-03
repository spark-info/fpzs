namespace fpzs
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuDocumentManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExcelToXml = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCustomizeExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDocumentManage,
            this.menuOption,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuDocumentManage
            // 
            this.menuDocumentManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExcelToXml});
            this.menuDocumentManage.Name = "menuDocumentManage";
            this.menuDocumentManage.Size = new System.Drawing.Size(68, 21);
            this.menuDocumentManage.Text = "开票管理";
            // 
            // menuExcelToXml
            // 
            this.menuExcelToXml.Name = "menuExcelToXml";
            this.menuExcelToXml.Size = new System.Drawing.Size(124, 22);
            this.menuExcelToXml.Text = "批量开票";
            this.menuExcelToXml.Click += new System.EventHandler(this.menuExcelToXml_Click);
            // 
            // menuOption
            // 
            this.menuOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCustomizeExcel});
            this.menuOption.Name = "menuOption";
            this.menuOption.Size = new System.Drawing.Size(44, 21);
            this.menuOption.Text = "设置";
            this.menuOption.Visible = false;
            // 
            // menuCustomizeExcel
            // 
            this.menuCustomizeExcel.Name = "menuCustomizeExcel";
            this.menuCustomizeExcel.Size = new System.Drawing.Size(208, 22);
            this.menuCustomizeExcel.Text = "开票数据EXCEL格式设置";
            this.menuCustomizeExcel.Click += new System.EventHandler(this.menuCustomizeExcel_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 21);
            this.menuHelp.Text = "帮助";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(100, 22);
            this.menuAbout.Text = "关于";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 417);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发票助手";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripMenuItem menuDocumentManage;
        private System.Windows.Forms.ToolStripMenuItem menuExcelToXml;
        private System.Windows.Forms.ToolStripMenuItem menuOption;
        private System.Windows.Forms.ToolStripMenuItem menuCustomizeExcel;
    }
}