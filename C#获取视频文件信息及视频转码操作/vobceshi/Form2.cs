using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace vobceshi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Video video = new Video();

        private void button1_Click(object sender, EventArgs e)
        {
            MediaInfoDLL.MediaInfo media = new MediaInfoDLL.MediaInfo();
            //string path = @"f:\video\temp2.mkv";
            media.Open(video.Path);

            //media.Get(vobceshi.MediaInfoDLL.StreamKind.General, 0, "Duration");
            //rtbmessage.Text = media.Inform();

            //获得媒体的播放时间，单位为ms
            string d = media.Get(MediaInfoDLL.StreamKind.General, 0, "Duration");

            //TimeSpan ts = new TimeSpan((long.Parse(d))*10000);
            ShowMessage("媒体的时间长度为：" + TimeCodeString(int.Parse(d)));

            //获取文件长度（单位B）
            float fs = Convert.ToSingle(media.Get(MediaInfoDLL.StreamKind.General, 0, "FileSize"));
            ShowMessage("文件大小为：" + fs / 1024 / 1024 + "MB");

            //获得媒体格式信息
            string type = media.Get(vobceshi.MediaInfoDLL.StreamKind.General, 0, "Format");
            ShowMessage("文件容器格式为：" + type);

            //获取文件名
            string name = media.Get(MediaInfoDLL.StreamKind.General, 0, "FileName");
            string leixing = media.Get(MediaInfoDLL.StreamKind.General, 0, "FileExtension");            
            ShowMessage("文件名称为："+name+"."+leixing);

            //获取全局速率
            string overall = media.Get(MediaInfoDLL.StreamKind.General,0,"OverallBitRate");
            ShowMessage("全局速率为："+convert(int.Parse(overall))+"Kbps");

            //视频的码率
            string videorate = media.getVidBitrate();
            ShowMessage("视频码率为："+convert(int.Parse(videorate))+"Kbps");

            //音频的码率
            string audiorate = media.getAudioBitrate();
            ShowMessage("音频的码率为："+convert(int.Parse(audiorate))+"Kbps");

            //视频的宽度和高度
            bool bvideo = media.Count_Get(vobceshi.MediaInfoDLL.StreamKind.Video) > 0;
            ShowMessage("是否为视频：" + bvideo);
            if (bvideo)
            {
                string width = media.getWidth();
                ShowMessage("视频的宽度为：" + width);
                string height = media.getHeight();
                ShowMessage("视频的高度为：" + height);
                video.Vwidth = width;
                video.Vheight = height;
            }
            
            //视频比例
            string bili = media.Get(MediaInfoDLL.StreamKind.Video, 0, "DisplayAspectRatio");
            ShowMessage("视频比例为："+bili);
            
            //视频格式
            string vformat = media.Get(MediaInfoDLL.StreamKind.Video,0,"Format");
            ShowMessage("视频格式为："+vformat);

            //音频格式
            string aformat = media.Get(MediaInfoDLL.StreamKind.Audio,0,"Format");
            ShowMessage("音频格式为："+aformat);

            //编码格式
            string coding = media.getVidCodec();
            ShowMessage("编码格式为："+coding);

            //帧速率
            string rate = media.getFPS();
            ShowMessage("帧速率为："+rate+"fps");

            //音频采样率
            string srate = media.Get(MediaInfoDLL.StreamKind.Audio,0,"SamplingRate");
            ShowMessage("音频采样率为："+srate);


            //显示所有媒体信息(第二参数的1相当于true)
            media.Option("Complete", "1");
            ShowMessage(media.Inform());
            
            media.Close();

        }

        private void ShowMessage(string msg)
        {
            rtbmessage.AppendText(msg + "\n");
        }

        //转换数值
        private static string convert(int num)
        {
            int number = num / 1000;
            string n = num.ToString();
            if (n.Length > 3)
            {
                n = n.Substring(3,1);
                if (int.Parse(n) > 5)
                {
                    number += 1;
                }
            }
            return number.ToString();
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

        //常用的标签
        // Format　　　编码格式，mp3,rmvb等大伙都有的。
        //FileSize　　  文件大小，这个也是通用
        //Duration　　 播放时间，大伙都有
        //Performer　  艺术家，音频有，视频文件没有
        //Recorded_Date　录制日期，音频有，视频文件没有
        //Album　　　　专辑，音频有，视频文件没有
        //Comment　　  备注，音频有，视频文件没有
    }
}
