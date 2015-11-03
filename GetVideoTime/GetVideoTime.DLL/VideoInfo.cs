using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetVideoTime.DLL
{
    public class VideoInfo
    {
        public string FileName { get; set; }

        public FileSize FileSize { get; set; }

        public string FilePath { get; set; }

        public string VideoTime { get; set; }
    }

    public class FileSize : IComparable
    {
        public double Size { get; set; }

        public FileSize(double size)
        {
            Size = size;
        }

        public override string ToString()
        {
            return Size.ToString("F2") + " M";
        }

        public int CompareTo(object obj)
        {
            FileSize f = (FileSize) obj;
            return this.Size.CompareTo(f.Size);
        }


    }

}
