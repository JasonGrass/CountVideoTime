using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using GetVideoTime.DLL;

namespace GetVideoTime.UI.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] videoFiles;
        private bool isDir;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbStyle.Items.Add("文件");
            cmbStyle.Items.Add("文件夹");
            cmbStyle.SelectedIndex = 1;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (cmbStyle.SelectedIndex == 1)//文件夹
            {               
                System.Windows.Forms.FolderBrowserDialog fd = new System.Windows.Forms.FolderBrowserDialog();
                fd.ShowNewFolderButton = false;
                fd.Description = "请选择文件路径";
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string foldPath = fd.SelectedPath;
                    txtDir.Text = foldPath;
                }
                isDir = true;
            }
            else  //文件
            {
                System.Windows.Forms.OpenFileDialog fd = new System.Windows.Forms.OpenFileDialog();
                fd.Multiselect = true;
                fd.Filter = "视频文件|*.avi;*.mp4;*.wmv;*.3gp;*.rmvb;*.rm;*.mpg;.mkv;*.flv|" +
                    "avi|*.avi|mp4|*.mp4|wmv|*.wmv|3gp|*.3gp|rmvb|*.rmvb|rm|*.rm|mpg|*.mpg|mkv|*.mkv|flv|*.flv";
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string[] videoFilesTmp = fd.SafeFileNames;
                    this.videoFiles = fd.FileNames;
                    foreach (string str in videoFilesTmp)
                        txtDir.Text += str + "; ";
                }
                isDir = false;
            }
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            pBarReading.Visibility = System.Windows.Visibility.Visible;
            txtVideoInfo.Text = "正在读取，请耐心等待……";
            if (MessageBox.Show("如果文件较多，读取过程将很慢……\n期间不要把窗口关闭\n是否继续？",
                "是否继续？", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
            {
                pBarReading.Visibility = System.Windows.Visibility.Collapsed;
                txtVideoInfo.Text = "";
                return;
            }
            if (cmbStyle.SelectedIndex == 1)//文件夹
            {
                if (!Directory.Exists(txtDir.Text))
                {
                    MessageBox.Show("路径不存在", "读取文件夹出错", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                GetVidoeTimes getTimes = new GetVidoeTimes(txtDir.Text);
                System.Threading.ThreadPool.QueueUserWorkItem(ReadFile, getTimes);
            }
            else//文件
            {
                if (this.videoFiles == null)
                {
                    MessageBox.Show("空文件", "读取出错", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                GetVidoeTimes getTimes = new GetVidoeTimes(this.videoFiles);
                System.Threading.ThreadPool.QueueUserWorkItem(ReadFile, getTimes);
            }

            btnOpen.IsEnabled = false;
            btnRead.IsEnabled = false;
            cmbStyle.IsEnabled = false;

        }

        private void ShowVideosInfo(GetVidoeTimes getTimes)
        {
            /*
            txtVideoInfo.Text = "";
            foreach (string str in getTimes.MediaFilesInfo)
            {
                txtVideoInfo.AppendText(str + "\n");
            }
            txtbCount.Text = getTimes.FileCount.ToString();
            txtbToatalTime.Text =
                Math.Floor(getTimes.TotalTimeCount.TotalHours).ToString("00") + "h " +
                getTimes.TotalTimeCount.Minutes.ToString("00") + "m " +
                getTimes.TotalTimeCount.Seconds.ToString("00") + "s";
            lbTotalLength.Content = (((double)getTimes.TotalLength / (1024 * 1024))).ToString("F2") + "M";
                */
        }

        private void ReadFile(object obj)
        {
            GetVidoeTimes getTimes = (GetVidoeTimes)obj;
            if (isDir)//文件夹
            {
                getTimes.TraversalMediaInDir();
            }
            else // 文件
            {
                getTimes.TraversalMediaInFiles();
            }
            SetForm(getTimes);
            MessageBox.Show("久等啦，\n我读取完毕啦", "完成", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SetForm(GetVidoeTimes getTimes)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                ShowVideosInfo(getTimes);
                pBarReading.Visibility = System.Windows.Visibility.Collapsed;
                btnOpen.IsEnabled = true;
                btnRead.IsEnabled = true;
                cmbStyle.IsEnabled = true;
            }));

            
        }

    }
}
