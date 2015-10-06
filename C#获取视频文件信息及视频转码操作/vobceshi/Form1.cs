using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace vobceshi
{

    public delegate void ShowMessageHandler(string msg);
    public partial class Form1 : Form
    {
        Thread videothread = null;
        public Form1()
        {
            InitializeComponent();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(DoWork);

            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);

            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            txttime1.Enabled = false;
            txttime2.Enabled = false;
            pnstep.Visible = true;
            if (videothread == null || videothread.IsAlive == false)
            {
                try
                {
                    backgroundWorker1.RunWorkerAsync();
                    videothread = new Thread(new ThreadStart(this.Start));
                    videothread.IsBackground = true;
                    videothread.Start();
                }
                catch (Exception ex)
                {
                    ShowMessage("错误消息：" + ex.ToString());
                }
            }
        }

        private void Start()
        {
            video.Path = txtpath.Text.Trim();
            video.Name = txtname.Text.Trim();
            video.StartTime = txttime1.Text.Trim();
            video.EndTime = txttime2.Text.Trim();
            if (txttime.Text.Trim() != "")
                video.Time = int.Parse(txttime.Text.Trim());
            //StartProcess(true);//第一次 读取
            CheckInfo();
            //StartProcess(false);//第二次 转码
            Transcoding();
        }

        public string Type { get; set; }

        private void CheckInfo()
        {
            //Type = "check";
            //StartProcess();//检测
            MediaInfoDLL.MediaInfo media = new MediaInfoDLL.MediaInfo();
            media.Open(video.Path);
            //获得媒体的播放时间，单位为ms
            string d = media.Get(MediaInfoDLL.StreamKind.General, 0, "Duration");
            ShowMessage("文件的时间长度为：" + TimeCodeString(int.Parse(d)));
            video.Vtimecount = timecount(TimeCodeString(int.Parse(d))).ToString();
            //获取文件长度（单位B）
            float fs = Convert.ToSingle(media.Get(0, 0, "FileSize"));
            ShowMessage("文件长度为：" + fs / 1024 / 1024 + "B");

            //获得媒体格式信息
            string type = media.Get(vobceshi.MediaInfoDLL.StreamKind.General, 0, "Format");
            ShowMessage("文件格式为：" + type);

            //


            bool bvideo = media.Count_Get(vobceshi.MediaInfoDLL.StreamKind.Video) > 0;
            ShowMessage("是否为视频：" + bvideo);
            if (bvideo)
            {
                string width = media.getWidth();
                ShowMessage("视频的宽度为：" + width);
                string height = media.getHeight();
                ShowMessage("视频的高度为："+height);
                video.Vwidth = width;
                video.Vheight = height;
            }


            //显示所有媒体信息(第二参数的1相当于true)
            media.Option("Complete", "1");
            ShowMessage(media.Inform());

            media.Close();



        }
        public string starttime { get; set; }
        public string endtime { get; set; }


        private void Transcoding()
        {
            starttime = DateTime.Now.ToLongTimeString();
            Type = "makeimg";
            StartProcess();;//转换的同时 抓取图片
            Type = "";
            StartProcess();//转换
            

            
            //lbltime.Text =""+(time2 - time1);

        }

        private void StartProcess()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = Application.StartupPath + @"\Lib\ffmpeg.exe";
            if (Type=="check")
            {
                ShowMessage("开始检测.");
                p.StartInfo.Arguments = @" -i " + video.Path;
            }
            else if (Type == "makeimg")
            {
                ShowMessage("开始生成图片.");
                if (video.StartTime != "")
                {
                    video.Time += timecount(video.StartTime);
                }
                int height = 640 * int.Parse(video.Vheight) / int.Parse(video.Vwidth);
                if (height % 2 != 0)
                    height += 1;
                //p.StartInfo.Arguments = @" -y -i " + video.Path + " -y -f image2 -ss " + video.Time + " -t 0.001 -s 640x" + height + @" f:\" + video.Name + @"-%05d.jpg";
                p.StartInfo.Arguments = @"-y -i " + video.Path + " -r 1 -ss " + video.Time + " -s 640x" + height + @" -f image2 f:\"+video.Name+".jpeg";
            }
            else if (Type == "jiequ")
            {
                ShowMessage("截取任务开始.");
                string subtime = "";
                if (video.StartTime != "" && video.EndTime != "")
                {
                    int count = timecount(video.EndTime) - timecount(video.StartTime);
                    subtime = @" -ss " + video.StartTime + " -t " + count;
                }
                string path = video.Path.Substring(video.Path.LastIndexOf(@"\"));
               // p.StartInfo.Arguments = subtime+" -i "+video.Path+@" -vcodec copy -acodec copy f:"+path+"";
                p.StartInfo.Arguments = "-sameq "+subtime+" -y -i "+video.Path+" f:"+path;
            }
            else
            {
                ShowMessage("转码任务开始.");
                string subtime = "";
                if (video.StartTime != "" && video.EndTime != "")
                {
                    int count = checkvoidtime(video.Vtimecount);
                    subtime = @" -ss " + video.StartTime + " -t " + count;
                }

                int height = 640 * int.Parse(video.Vheight) / int.Parse(video.Vwidth);
                if (height % 2 != 0)
                    height += 1;
                //p.StartInfo.Arguments = @"-y -i " + video.Path + subtime + @" -pass 1 -threads 2 -vcodec libx264 -b 512k -flags +loop+mv4 -cmp 256 -partitions +parti4x4+parti8x8+partp4x4+partp8x8+partb8x8 -me_method hex -subq 7 -trellis 1 -refs 5 -bf 3 -flags2 +bpyramid+wpred+mixed_refs+dct8x8 -coder 1 -me_range 16 -g 250 -keyint_min 25 -sc_threshold 40 -i_qfactor 0.71 -qmin 10 -qmax 51 -qdiff 4 f:\" + video.Name + ".mp4";
                p.StartInfo.Arguments = @"-y -i " + video.Path + " -acodec libfaac -ab 64k -vcodec libx264 -threads 0 -coder 1 -flags +loop -cmp +chroma -partitions +parti8x8+parti4x4+partp8x8+partb8x8 -me_method umh -subq 8 -me_range 16 -g 250 -keyint_min 25 -sc_threshold 40 -i_qfactor 0.71 -qcomp 0.6 -qmin 10 -qmax 51 -qdiff 4 -directpred 3 -trellis 1 -flags2 +bpyramid+mixed_refs+wpred+dct8x8+fastpskip -wpredp 2 -rc_lookahead 50 -refs 6 -bf 5 -b_strategy 2 -crf 22 " + subtime + " -s 640x" + height + @" f:\" + video.Name + ".mp4";
            }
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(p_OutputDataReceived);
            if (Type=="check" ||Type=="jiequ")//只检测文件是否可转换与获到内部宽与高
            {
                p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(p_CheckInfoDataReceived);
            }
            else
            {
                p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(p_ErrorDataReceived);
            }
            //开始执行 
            try
            {
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();
            }
            catch (Exception err)
            {
                ShowMessage("错误消息：" + err.ToString());
                //Console.WriteLine(err.Message);
            }
            finally
            {
                p.Close();//关闭进程
                p.Dispose();//释放资源
            }
        }
        Video video = new Video();
        void p_CheckInfoDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains("Stream") && e.Data.Contains("Video:"))//设置原视频窗口大小作为视频的宽与高
                {
                    Match match = Regex.Match(e.Data, @", (\d+)x(\d+)");
                    if (match != null)
                    {
                        video.Vwidth = match.Groups[1].Value;
                        video.Vheight = match.Groups[2].Value;
                        ShowMessage("宽：" + video.Vwidth);
                        ShowMessage("高：" + video.Vheight);
                    }
                }
                if (e.Data.Contains("Duration:"))
                {
                    Match match = Regex.Match(e.Data, "Duration:(.+?),");
                    if (match != null)
                    {
                        video.Vtimecount = match.Groups[1].Value;
                        ShowMessage("视频长度：" + video.Vtimecount);
                    }
                }
                else if (e.Data.Contains("could not find codec parameters"))//ffmpeg转换失败
                {
                    video.IsCanChange = false;
                    ShowMessage("转换失败.");
                    ShowMessage("没有设置相关参数.");
                    videothread.Abort();
                }
                else if (e.Data.Contains(" No such file or directory"))//没有找到要转换的文件
                {
                    ShowMessage("转换失败.");
                    ShowMessage("没有找到要转换的文件.");
                    videothread.Abort();
                }
                else if (e.Data.Contains("Uable to find a suitable output"))//没有相应的视频输出格式支持
                {
                    ShowMessage("转换失败.");
                    ShowMessage("不支持的视频输出格式.");
                    videothread.Abort();
                }
                else if (e.Data.Contains("Invalid data found when processing input"))
                {
                    ShowMessage("转换失败.");
                    ShowMessage("不支持的视频输入格式.");
                    videothread.Abort();
                }
                else if (e.Data.Contains("not found output stream"))
                {
                    ShowMessage("转换失败.");
                    ShowMessage("不支持的音频格式.");
                }
                else
                {
                    if (Type == "jiequ")
                    { 
                        
                    }
                    else if (Type != "check")
                    {
                        ShowMessage("转换失败.");
                        ShowMessage(e.Data);
                        videothread.Abort();
                    }
                }
            }
        }

        void p_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains("video:") && e.Data.Contains("muxing overhead"))//ffmpeg转换完成
                {
                    //Program.SetDataBase(id, 2, count + 1);
                    //Console.WriteLine("转换完成");
                    Match match = Regex.Match(e.Data, @"video:(\d+)kB+?");
                    if (match.Groups[1].Value == "0")
                        return;
                    video.Step = 100;
                    ShowMessage(e.Data.ToString());
                    ShowMessage("100%");
                    //lblstep.Text = "100%";
                    if (Type == "makeimg")
                        ShowMessage("图片生成成功.");
                    else
                        ShowMessage("视频转码成功.");

                    //backgroundWorker1.CancelAsync();
                }
                if (e.Data.Contains("frame=") && e.Data.Contains("time="))//只输出进度
                {
                        Match match1 = Regex.Match(e.Data, @" +size=      (.+?)kB+?");
                        if (match1.Groups[1].Value == " 0" || match1.Groups[1].Value == "-0")
                            return;
                        if (e.Data.Contains("Lsize"))
                        {
                            Match match2 = Regex.Match(e.Data, @" +Lsize=      (.+?)kB+?");
                            if (match2.Groups[1].Value == " 0" || match2.Groups[1].Value == "-0")
                                return;
                        }
                    ShowMessage("转换进度如下：");
                    ShowMessage(e.Data);
                    Match match = Regex.Match(e.Data, @"time=(.+?) bitrate=.+? ");
                    if (match != null)
                    {
                        string tvalue = match.Groups[1].Value.ToString();
                        float jindu = 0;
                        int times = checkvoidtime(video.Vtimecount);
                        if (txttime1.Text.Trim() != "" && txttime2.Text.Trim() != "")
                        {
                            //int times = checkvoidtime(video.Vtimecount);
                            jindu = float.Parse(tvalue) * 100 / float.Parse("" + times);
                        }
                        else
                        {
                            jindu = float.Parse(tvalue) * 100 / float.Parse("" + times);
                        }
                        string jd = jindu.ToString();
                        if (jindu.ToString().IndexOf('.') > 0)
                            jd = jindu.ToString().Substring(0, jindu.ToString().IndexOf('.'));

                        video.Step = int.Parse(jd);                        
                        //ShowMessage(video.Step.ToString()+"%");
                    }
                }

                //Console.WriteLine(e.Data);
            }
        }

        void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains("Writing index"))//mencoder转换完成
                {
                    //Program.SetDataBase(id, 2, count + 1);
                    //Console.WriteLine("转换完成");
                }
                //else if (e.Data.Contains("Exiting"))//mencoder转换失败
                //{
                //     Console.WriteLine("转换失败");
                //}
                //Console.WriteLine(e.Data);
            }
        }

        private void ShowMessage(string msg)
        {

            if (videothread == null)
                return;
            if (!videothread.IsAlive)
                return;
            if (!rtbmessage.InvokeRequired)
            {
                rtbmessage.AppendText(msg + "\n");
            }
            else
            {
                ShowMessageHandler smHandler = new ShowMessageHandler(ShowMessage);
                Invoke(smHandler, new object[] { msg });
            }
        }


        private int checkvoidtime(string videotime)
        {
            string begintime = txttime1.Text.Trim();
            string endtime = txttime2.Text.Trim();
            int vcount = timecount(videotime);
            int bcount = 0; int ecount = 0; int count = 0;
            if (begintime != "" && endtime != "")
            {
                if (begintime.Contains(":") && endtime.Contains(":"))
                {
                    bcount = timecount(begintime);
                    ecount = timecount(endtime);
                }
                else
                {
                    bcount = int.Parse(begintime);
                    ecount = int.Parse(endtime);
                }
                if (bcount < ecount && ecount < vcount)
                {
                    count = ecount - bcount;
                }
            }
            else
                count = vcount;
            return count;
        }

        private int timecount(string time)
        {
            int tcount = 0;
            Match match = Regex.Match(time, @"(\d+):(\d+):(\d+)");
            if (match != null && match.Groups[1].Value != "")
            {
                int vh = int.Parse(match.Groups[1].Value);
                int vm = int.Parse(match.Groups[2].Value);
                int vs = int.Parse(match.Groups[3].Value);
                tcount = vh * 3600 + vm * 60 + vs;
            }
            else
            {
                tcount = int.Parse(time);
            }
            return tcount;
        }

        //转换时间格式
        public static string TimeCodeString(int msecs)
        {
            //frames
            int timebase = msecs % 1000;
            string frames = ((int)((float)timebase / 33.3333333333f)).ToString();
            if (frames.Length == 1) frames = "0" + frames;
            msecs -= timebase;

            //seconds
            timebase = msecs % 60000;
            string secs = (timebase / 1000).ToString();
            if (secs.Length == 1) secs = "0" + secs;
            msecs -= timebase;

            //minutes
            timebase = msecs % 3600000;
            string mins = (timebase / 60000).ToString();
            if (mins.Length == 1) mins = "0" + mins;
            msecs -= timebase;

            return (msecs / 3600000).ToString() + ":" + mins + ":" + secs;
            //return (msecs / 3600000).ToString() + ":" + mins + ":" + secs + ";" + frames;
        }

        private void setvalue()
        {
            videothread.Abort();
            //button1.Enabled = true;
            //txttime1.Enabled = true;
            //txttime2.Enabled = true;
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ComputeFibonacci(backgroundWorker1, e);
            //获取异步操作结果的值，当ComputeFibonacci(worker, e)返回时，异步过程结束
        }

        //调用 ReportProgress 时发生
        public void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {
            if (video.Step > 100)
                video.Step = 100;
                this.progressBar1.Value = video.Step;
                if (video.Step == 0)
                    lblstep.Text = "1%";
                else
                    lblstep.Text = video.Step + "%";

            if (Type == "")
            {
                if (video.Step != 100)
                {
                    endtime = DateTime.Now.ToLongTimeString();
                    if (starttime == null)
                        return;
                    int time1 = timecount(starttime);
                    int time2 = timecount(endtime);
                    lbltime.Text = "" + (time2 - time1);
                }
                else
                {
                    button1.Enabled = true;
                }
            }

            //将异步任务进度的百分比赋给进度条
        }

        //当后台操作已完成、被取消或引发异常时发生
        public void CompleteWork(object sender, RunWorkerCompletedEventArgs e)
        {
            lblstep.Text = "100%";
            //MessageBox.Show("完成！");
        }

        private int ComputeFibonacci(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                //判断应用程序是否取消后台操作
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    backgroundWorker1.ReportProgress(i);
                }

                System.Threading.Thread.Sleep(10);
            }
            return -1;
        }


        //选择转换文件
        private void button2_Click(object sender, EventArgs e)
        {
            string resutlfile = "";
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.InitialDirectory = "f:\\";
            //openfiledialog1.Filter = "All files (*.*) files";
            openfiledialog1.FilterIndex = 2;
            openfiledialog1.RestoreDirectory = true;
            if (openfiledialog1.ShowDialog() == DialogResult.OK)
                resutlfile = openfiledialog1.FileName;
            txtpath.Text = resutlfile;
            video.Path = resutlfile;
        }

        private void btnjiequ_Click(object sender, EventArgs e)
        {
            if (videothread == null || videothread.IsAlive == false)
            {
                try
                {
                    backgroundWorker1.RunWorkerAsync();
                    videothread = new Thread(new ThreadStart(this.Start_jq));
                    videothread.IsBackground = true;
                    videothread.Start();
                }
                catch (Exception ex)
                {
                    ShowMessage("错误消息：" + ex.ToString());
                }
            }
            
        }

        private void Start_jq()
        {
            video.Path = txtpath.Text.Trim();
            video.Name = txtname.Text.Trim();
            video.StartTime = txttime1.Text.Trim();
            video.EndTime = txttime2.Text.Trim();
            CheckInfo();
            Type = "jiequ";
            StartProcess();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (videothread != null)
            {
                if (videothread.IsAlive)
                    videothread.Abort();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videothread != null)
            {
                if (videothread.IsAlive)
                {
                    DialogResult dr = MessageBox.Show("视频转码正在进行，关闭将造成转码视频失败。是否继续关闭?", "否", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr != DialogResult.Yes)
                        e.Cancel = true;
                }
            }
           
        }


        

    }
}
