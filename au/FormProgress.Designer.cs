namespace au
{
    partial class FormProgress
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(31, 30);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(440, 23);
            this.pbar.Step = 20;
            this.pbar.TabIndex = 0;
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(31, 68);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(440, 167);
            this.rtbMessage.TabIndex = 1;
            this.rtbMessage.Text = "";
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinish.Location = new System.Drawing.Point(163, 241);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(164, 33);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "关  闭";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 286);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.pbar);
            this.Name = "FormProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新中...";
            this.Load += new System.EventHandler(this.FormProgress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button btnFinish;
    }
}

