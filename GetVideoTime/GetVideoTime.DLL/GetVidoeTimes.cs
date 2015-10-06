using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;

namespace GetVideoTime.DLL
{
    public class GetVidoeTimes
    {
        public GetVidoeTimes(string dirPath)
        {
            rootDir = new DirectoryInfo(dirPath);
        }

        public GetVidoeTimes(string[] filePaths)
        {
            this.filesPaths = filePaths;
        }

        //文件夹目录
        private DirectoryInfo rootDir;
        //文件路径集合
        private string[] filesPaths;

        /// <summary>
        /// 所有文件总大小 单位：字节
        /// </summary>
        public long TotalLength { get; private set; }

        public List<string> MediaFilesInfo = new List<string>();
        public TimeSpan TotalTimeCount;
        public int FileCount;

        private TimeSpan GetSingleMediaTime(string filePath)
        {
            MediaInfoDLL.MediaInfo media = new MediaInfoDLL.MediaInfo();
            //string path = @"f:\video\temp2.mkv";
            media.Open(filePath);
            //获得媒体的播放时间，单位为ms
            string d = media.Get(MediaInfoDLL.StreamKind.General, 0, "Duration");
            if (d == "")
                return new TimeSpan(0);
            return new TimeSpan((long.Parse(d)*10000));
        }

        /// <summary>
        /// 获取文件夹中视频文件的数据
        /// </summary>
        public void TraversalMediaInDir()
        {
            this.FileCount = 0;
            this.TotalTimeCount = new TimeSpan();
            TraversalDir(rootDir);
        }

        /// <summary>
        /// 获取多个文件的数据
        /// </summary>
        public void TraversalMediaInFiles()
        {
            this.FileCount = 0;
            this.TotalTimeCount = new TimeSpan();
            foreach (string filePath in this.filesPaths)
            {
                FileInfo fi = new FileInfo(filePath);
                if (IsMediaFile(fi))
                {
                    GetMediaFileInfo(fi);
                }
            }
        }

        private void TraversalDir(DirectoryInfo dir)
        {
            //遍历文件
            foreach (FileInfo NextFile in dir.GetFiles())
            {
                if (IsMediaFile(NextFile))
                {
                    GetMediaFileInfo(NextFile);
                }
            }
            //递归遍历文件夹
            foreach (DirectoryInfo NextFolder in dir.GetDirectories())
            {
                //判断是否有访问权限
                //DirectorySecurity ds = new DirectorySecurity(NextFolder.FullName, AccessControlSections.Access);
                //if (!ds.AreAuditRulesProtected)
                //    TraversalDir(NextFolder);
                try
                {
                    string str = NextFolder.FullName;
                    TraversalDir(NextFolder);
                }
                catch
                {
                    // do nothing
                }
            }
        }

        private void GetMediaFileInfo(FileInfo fileInfo)
        {
            TimeSpan ts = GetSingleMediaTime(fileInfo.FullName);
            if (ts.Milliseconds != 0)
            {
                string str = Math.Floor(ts.TotalHours).ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00")
                    + "  " + fileInfo.Name + "  " + (((double)fileInfo.Length)/(1024*1024)).ToString("F2") +"M" ;
                this.MediaFilesInfo.Add(str);
                this.TotalTimeCount = TotalTimeCount.Add(ts);
                FileCount += 1;
                TotalLength += fileInfo.Length;
            }
        }

        private bool IsMediaFile(FileInfo inf)
        {
            switch (inf.Extension)
            {
                case ".avi": return true;
                case ".mp4": return true;
                case ".wmv": return true;
                case ".3gp": return true;
                case ".rmvb": return true;
                case ".rm": return true;
                case ".mpg": return true;
                case ".mkv": return true;
                case ".flv": return true;
                default: return false;
            }
        }

    }
}
