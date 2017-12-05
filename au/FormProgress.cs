using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace au
{
    public partial class FormProgress : Form
    {
        private bool successToUpdate = false;
        public FormProgress()
        {
            InitializeComponent();
        }

        private void FormProgress_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(ExecuteAutoUpdate);
            thread.Start();
        }

        private void ExecuteAutoUpdate()
        {
            try
            {
                int updateFileCount = AutoUpdate();
                if(updateFileCount == 0)
                {
                    Application.Exit();
                }
                else
                {
                    successToUpdate = true;
                }
            }
            catch(Exception ex)
            {
                ShowMessage("自动更新失败：");
                ShowMessage(ex.Message);
                ShowMessage(ex.StackTrace);
            }
        }
        private int AutoUpdate()
        {
            Updater u = new Updater();
            UpdateConfig config = u.GetUpdateConfig(Application.StartupPath);
            ShowMessage("从"+Application.StartupPath+"读取配置文件。");
            StepProgress(false);

            List<FileVersion> serverList = u.ReadServerVersion(config.ServerUpdateUrl);
            ShowMessage("从服务器读取更新文件列表。");
            StepProgress(false);

            List<FileVersion> localList = u.ReadLocalVersion(config.LocalUpdateDirectory);
            ShowMessage("从服务器读取文件列表。");
            StepProgress(false);

            List<FileVersion> updateList = u.CompareFileVersionList(serverList, localList);
            ShowMessage("比较服务器与本地文件列表。");
            StepProgress(false);

            if (updateList.Count <= 0)
            {
                return 0;
            }
            u.DownloadUpdateList(config.ServerUpdateUrl, config.LocalUpdateDirectory, updateList);
            ShowMessage("从服务器下载更新文件。");
            StepProgress(false);

            DialogResult dr = MessageBox.Show("主程将退出，以进行更新...", "更新确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr != DialogResult.OK)
            {
                return 0;
            }
            KillProcess(Program.PARENT_PROGRAM_PROCESS_ID);
            u.CopyFile(config.LocalUpdateDirectory, config.LocalAppDirectory, updateList);
            ShowMessage("完成文件更新。");
            StepProgress(false);
            return updateList.Count;
        }

        private void KillProcess(int processId)
        {
            if (processId != 0)
            {
                Process parentProgramProcess = Process.GetProcessById(processId);
                parentProgramProcess.Kill();
                parentProgramProcess.Close();

                try
                {
                    while (Process.GetProcessById(processId) != null)
                    {
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.StackTrace);
                }
            }
        }

        public delegate void StepProgressCallback(bool finish);

        public void StepProgress(bool finish)
        {
            if (pbar.InvokeRequired)
            {
                StepProgressCallback d = new StepProgressCallback(StepProgress);
                this.Invoke(d,new object[]{finish});
            }
            else
            {
                if (finish)
                {
                    pbar.Value = pbar.Maximum;
                }
                else
                {
                    pbar.PerformStep();
                }
            }
        }
        public delegate void ShowMessageCallback(string message);
        public void ShowMessage(string message)
        {
            if(rtbMessage.InvokeRequired)
            {
                ShowMessageCallback d = new ShowMessageCallback(ShowMessage);
                this.Invoke(d, new object[]{message});
            }
            else
            {
                rtbMessage.AppendText(message + "\n");
            }
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            Application.Exit();
            if (successToUpdate)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(Program.PARENT_PROGRAM_EXE_FILEPATH);
                process.StartInfo = startInfo;
                process.Start();
            }

        }
    }
}
