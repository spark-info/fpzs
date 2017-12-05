namespace fpzs
{
    partial class FormExcelToXml
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbExcelFilepath = new System.Windows.Forms.TextBox();
            this.btnExcelFilepath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbXmlFilepath = new System.Windows.Forms.TextBox();
            this.btnXmlFilepath = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开票数据(Excel)：";
            // 
            // tbExcelFilepath
            // 
            this.tbExcelFilepath.Location = new System.Drawing.Point(161, 26);
            this.tbExcelFilepath.Name = "tbExcelFilepath";
            this.tbExcelFilepath.Size = new System.Drawing.Size(386, 21);
            this.tbExcelFilepath.TabIndex = 1;
            // 
            // btnExcelFilepath
            // 
            this.btnExcelFilepath.Location = new System.Drawing.Point(550, 24);
            this.btnExcelFilepath.Name = "btnExcelFilepath";
            this.btnExcelFilepath.Size = new System.Drawing.Size(34, 23);
            this.btnExcelFilepath.TabIndex = 2;
            this.btnExcelFilepath.Text = "...";
            this.btnExcelFilepath.UseVisualStyleBackColor = true;
            this.btnExcelFilepath.Click += new System.EventHandler(this.btnExcelFilepath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "开票文件(XML)：";
            // 
            // tbXmlFilepath
            // 
            this.tbXmlFilepath.Location = new System.Drawing.Point(161, 61);
            this.tbXmlFilepath.Name = "tbXmlFilepath";
            this.tbXmlFilepath.Size = new System.Drawing.Size(386, 21);
            this.tbXmlFilepath.TabIndex = 4;
            // 
            // btnXmlFilepath
            // 
            this.btnXmlFilepath.Location = new System.Drawing.Point(550, 59);
            this.btnXmlFilepath.Name = "btnXmlFilepath";
            this.btnXmlFilepath.Size = new System.Drawing.Size(34, 23);
            this.btnXmlFilepath.TabIndex = 5;
            this.btnXmlFilepath.Text = "...";
            this.btnXmlFilepath.UseVisualStyleBackColor = true;
            this.btnXmlFilepath.Click += new System.EventHandler(this.btnXmlFilepath_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(224, 141);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(101, 33);
            this.btnBuild.TabIndex = 6;
            this.btnBuild.Text = "生成开票文件";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(331, 141);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 33);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormExcelToXml
            // 
            this.AcceptButton = this.btnBuild;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(650, 186);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.btnXmlFilepath);
            this.Controls.Add(this.tbXmlFilepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExcelFilepath);
            this.Controls.Add(this.tbExcelFilepath);
            this.Controls.Add(this.label1);
            this.Name = "FormExcelToXml";
            this.Text = "批量开票";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExcelFilepath;
        private System.Windows.Forms.Button btnExcelFilepath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbXmlFilepath;
        private System.Windows.Forms.Button btnXmlFilepath;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnClose;
    }
}