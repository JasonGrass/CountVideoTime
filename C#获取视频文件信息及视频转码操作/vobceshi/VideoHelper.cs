using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace vobceshi
{
    public class VideoHelper
    {
        //检测 video 信息
        public void CheckInfo(string time1, string time2, string path, string name)
        {
            StartProcess(true,time1,time2,path,name);
        }

        //video 转码
        public void Transcoding(string time1, string time2, string path, string name)
        {
            StartProcess(false,time1,time2,path,name);
        }

        public string width { get; set; }

        public string height { get; set; }

        public string times { get; set; }

        public int step { get; set; }

        public string begintime { get; set; }

        public string endtime { get; set; }

        private void StartProcess(bool onlyCheckInfo,string time1,string time2,string path,string name)
        {
           

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"F:\Project\vod\ffmpeg-r26400-swscale-r32676-mingw32-shared\bin\ffmpeg.exe";
            if (onlyCheckInfo)
            {
                p.StartInfo.Arguments = @" -i " + path;
            }
            else
            {
                string subtime = "";
                //string time1 = textBox1.Text.Trim();
                //string time2 = textBox2.Text.Trim();
                if (time1 != "" && time2 != "")
                {
                    int count = checkvoidtime(times,time1,time2);
                    subtime = @" -ss " + time1 + " -t " + count;
                }
                p.StartInfo.Arguments = @"-y -i " + path + subtime + @" -pass 1 -threads 2 -vcodec libx264 -b 512k -flags +loop+mv4 -cmp 256 -partitions +parti4x4+parti8x8+partp4x4+partp8x8+partb8x8 -me_method hex -subq 7 -trellis 1 -refs 5 -bf 3 -flags2 +bpyramid+wpred+mixed_refs+dct8x8 -coder 1 -me_range 16 -g 250 -keyint_min 25 -sc_threshold 40 -i_qfactor 0.71 -qmin 10 -qmax 51 -qdiff 4 f:\" + name + ".mp4";
            }
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(p_OutputDataReceived);
            if (onlyCheckInfo)//只检测文件是否可转换与获到内部宽与高
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
                //video.IsCanChange = false;
                //ShowMessage("错误消息：" + err.ToString());
                //video.ErrorMessage = err.ToString();
                //Console.WriteLine(err.Message);
            }
            finally
            {
                p.Close();

            }
        }
        void p_CheckInfoDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                if (e.Data.Contains("Stream") && e.Data.Contains("Video:"))//设置原视频窗口大小作为视频的宽与高
                {
                    Match match = Regex.Match(e.Data, @", (\d+)x(\d+)");
                    if (match != null)
                    {
                        this.width = match.Groups[1].Value;
                        this.height = match.Groups[2].Value;
                        //ShowMessage("宽：" + video.Vwidth);
                        //ShowMessage("高：" + video.Vheight);
                    }
                }
                if (e.Data.Contains("Duration:"))
                {
                    Match match = Regex.Match(e.Data, "Duration:(.+?),");
                    if (match != null)
                    {
                        this.times = match.Groups[1].Value;
                        //ShowMessage("视频长度：" + video.Vtimecount);
                    }
                }
                else if (e.Data.Contains("could not find codec parameters"))//ffmpeg转换失败
                {
                    //video.IsCanChange = false;
                    //ShowMessage("转换失败.");
                    //Program.SetDataBase(id, 1, count + 1);
                }
                else if (e.Data.Contains(" No such file or directory"))//没有找到要转换的文件
                {
                    //ShowMessage("转换失败.");
                    //ShowMessage("没有找到要转换的文件.");
                    //video.ErrorMessage = "没有找到要转换的文件.";
                }
                else if (e.Data.Contains("Uable to find a suitable output"))//没有相应的视频输出格式支持
                {
                    //ShowMessage("转换失败.");
                    //ShowMessage("不支持的视频输出格式.");
                    //video.ErrorMessage = "不支持的视频输出格式.";
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
                    step = 100;
                    //video.ErrorMessage = "转换成功.";
                    //ShowMessage("转换成功.");
                    //backgroundWorker1.CancelAsync();
                }
                if (e.Data.Contains("frame=") && e.Data.Contains("time="))//只输出进度
                {
                    //ShowMessage("转换进度如下：");
                    //ShowMessage(e.Data);
                    Match match = Regex.Match(e.Data, @"time=(.+?) bitrate=.+? ");
                    if (match != null)
                    {
                        string tvalue = match.Groups[1].Value.ToString();
                        float jindu = 0;
                        int time = checkvoidtime(times,begintime,endtime);
                        if (begintime != "" && endtime != "")
                        {
                            //int times = checkvoidtime(video.Vtimecount);
                            jindu = float.Parse(tvalue) * 100 / float.Parse("" + time);
                        }
                        else
                        {
                            jindu = float.Parse(tvalue) * 100 / float.Parse("" + time);
                        }
                        string jd = jindu.ToString();
                        if (jindu.ToString().IndexOf('.') > 0)
                            jd = jindu.ToString().Substring(0, jindu.ToString().IndexOf('.'));

                        step = int.Parse(jd);
                        //video.ErrorMessage = "";
                        //ShowMessage(video.Step.ToString());
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

        private int checkvoidtime(string videotime,string begintime,string endtime)
        {
            //string begintime = textBox1.Text.Trim();
            //string endtime = textBox2.Text.Trim();
            int vcount = timecount(videotime);
            int bcount = 0; int ecount = 0; int count = 0;
            if (begintime != "" && begintime != null && endtime != "" && endtime != null)
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
            if (match != null)
            {
                int vh = int.Parse(match.Groups[1].Value);
                int vm = int.Parse(match.Groups[2].Value);
                int vs = int.Parse(match.Groups[3].Value);
                tcount = vh * 3600 + vm * 60 + vs;
            }
            return tcount;
        }
    }
}
