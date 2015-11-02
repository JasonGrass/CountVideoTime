using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using GetVideoTime.DLL;

namespace GetVideoTime.UI.WinForm
{
    public partial class MainForm : CCSkinMain
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fd = new System.Windows.Forms.FolderBrowserDialog();
            fd.ShowNewFolderButton = false;
            fd.Description = "请选择文件路径";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string foldPath = fd.SelectedPath;
                txtPath.Text = foldPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            dgvResult.Visible = false;
            processBar.Visible = true;

            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("路径不存在", "读取文件夹出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GetVidoeTimes getTimes = new GetVidoeTimes(txtPath.Text);
            System.Threading.ThreadPool.QueueUserWorkItem(ReadFile, getTimes);

            btnOpenDir.Visible = false;
            btnOK.Visible = false;
            btnClear.Visible = false;
            processBar.Visible = true;
        }

        private void ReadFile(object o)
        {

            GetVidoeTimes getTimes = (GetVidoeTimes)o;
            getTimes.TraversalMediaInDir();

            Invoke(new Action(() =>
            {
                lbCount.Text = getTimes.FileCount.ToString();
                lbTotalTime.Text =
                    Math.Floor(getTimes.TotalTimeCount.TotalHours).ToString("00") + "h " +
                    getTimes.TotalTimeCount.Minutes.ToString("00") + "m " +
                    getTimes.TotalTimeCount.Seconds.ToString("00") + "s";
                lbTotalSize.Text = (((double) getTimes.TotalLength/(1024*1024))).ToString("F2") + "M";
                processBar.Visible = false;
                dgvResult.Visible = true;
                SetDataGridView(getTimes.TotalVideoInfos);
                btnOpenDir.Visible = true;
                btnOK.Visible = true;
                btnClear.Visible = true;
            }));

            //MessageBox.Show("久等啦，\n我读取完毕啦", "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetDataGridView(List<VideoInfo> infos )
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            processBar.Visible = false;
            dgvResult.Visible = false;
        }
    }
}
