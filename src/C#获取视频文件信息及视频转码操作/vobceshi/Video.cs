using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vobceshi
{
    public class Video
    {
        bool _change = true;
        int _step = 0;
        string _name = "output";
        string _path = "f:\temp.vob";
        string _error="";
        string _begintime = "";
        string _endtime = "";
        int _time = 2;
        public string Vwidth
        {
            get;
            set;
        }
        public string Vheight
        {
            get;
            set;
        }
        public string Vtimecount
        {
            get;
            set;
        }
        public bool IsCanChange
        {
            get { return _change; }
            set { _change = value; }
        }
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }
        public string ErrorMessage
        {
            get { return _error; }
            set { _error = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string StartTime     
        {
            get { return _begintime; }
            set { _begintime = value; }
        }
        public string EndTime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }
        public int Time 
        {
            get { return _time; }
            set { _time = value; }
        }

    }
}
