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
            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("路径不存在", "读取文件夹出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvResult.Visible = false;
            processBar.Visible = true;

            GetVidoeTimes getTimes = new GetVidoeTimes(txtPath.Text);
            System.Threading.ThreadPool.QueueUserWorkItem(ReadFile, getTimes);

            btnOpenDir.Visible = false;
            btnOK.Visible = false;
            btnClear.Visible = false;
            processBar.Visible = true;

            lbCount.Text = string.Empty;
            lbTotalSize.Text = string.Empty;
            lbTotalTime.Text = string.Empty;
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
        }

        private void SetDataGridView(List<VideoInfo> infos)
        {
            dgvDataSource.Rows.Clear();
            foreach (VideoInfo videoInfo in infos)
            {
                dgvDataSource.Rows.Add(videoInfo.FileName, videoInfo.FilePath, videoInfo.VideoTime, videoInfo.FileSize);
            }        
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            processBar.Visible = false;
            dgvResult.Visible = false;
            Init();

            ToolTip tipBtn = new ToolTip
            {
                AutoPopDelay = 2000,
                InitialDelay = 200,
                ReshowDelay = 200,
                ShowAlways = true
            };
            tipBtn.SetToolTip(btnOpenDir, "打开文件夹");
            tipBtn.SetToolTip(btnOK, "开始统计");
            tipBtn.SetToolTip(btnClear, "清除路径");

            txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private DataTable dgvDataSource;
        private void Init()
        {
            dgvDataSource = new DataTable();
            DataColumn dcName = new DataColumn("文件名");
            DataColumn dcPath = new DataColumn("路径");
            DataColumn dcTime = new DataColumn("时间");
            DataColumn dcSize = new DataColumn("大小") {DataType = typeof (FileSize)};
            dgvDataSource.Columns.AddRange(new[] { dcName, dcPath, dcTime, dcSize });
            dgvResult.DataSource = dgvDataSource;

            dgvResult.AllowUserToAddRows = false;
            dgvResult.AllowUserToDeleteRows = false;
            dgvResult.AllowUserToResizeRows = false;
            dgvResult.ReadOnly = true;
            dgvResult.MultiSelect = false;
            dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvResult.Columns[0].Width = 130;
            dgvResult.Columns[1].Width = 383;
            dgvResult.Columns[2].Width = 60;
            dgvResult.Columns[3].Width = 60;
            dgvResult.RowHeadersWidth = 46;

            // 显示行号
            dgvResult.RowStateChanged += (o, args) =>
            {
                try
                {
                    args.Row.HeaderCell.Value = string.Format("{0}", args.Row.Index + 1);
                }
                catch (Exception)
                {
                }
            };

            // 右键菜单       
            dgvResult.CellMouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (e.RowIndex >= 0)
                    {
                        //若行已是选中状态就不再进行设置
                        if (dgvResult.Rows[e.RowIndex].Selected == false)
                        {
                            dgvResult.ClearSelection();
                            dgvResult.Rows[e.RowIndex].Selected = true;
                        }
                        //弹出操作菜单
                        contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                    }
                }
            };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPath.Clear();
        }

        private void menuItemOpenPath_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvResult.SelectedRows[0];
            System.Diagnostics.Process.Start(Path.GetDirectoryName(row.Cells[1].Value.ToString()));
        }

        private void menuItemOpenFile_Click(object sender, EventArgs e)
        {          
            DataGridViewRow row = dgvResult.SelectedRows[0];
            System.Diagnostics.Process.Start(row.Cells[1].Value.ToString());
        }

        private void lbSupport_Click(object sender, EventArgs e)
        {
            // 查看支持的格式
            MessageBox.Show("avi、mp4、wmv、3gp \nrmvb、rm、mpg、mkv、flv", "信息", 
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
