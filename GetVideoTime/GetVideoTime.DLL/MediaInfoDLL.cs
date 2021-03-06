﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
//using WindowPlugins.GUITVSeries;
namespace GetVideoTime.DLL
{
    public class MediaInfoDLL
    {

        public enum StreamKind
        {
            General,
            Video,
            Audio,
            Text,
            Chapters,
            Image
        }

        public enum InfoKind
        {
            Name,
            Text,
            Measure,
            Options,
            NameText,
            MeasureText,
            Info,
            HowTo
        }

        public enum InfoOptions
        {
            ShowInInform,
            Support,
            ShowInSupported,
            TypeOfValue
        }
        public enum StreamInfo
        { 
            Audio,
            Video,
            General
        }

        public class MediaInfo
        {
            //Import of DLL functions. DO NOT USE until you know what you do (MediaInfo DLL do NOT use CoTaskMemAlloc to allocate memory)  
            [DllImport("MediaInfo.dll")]
            public static extern IntPtr MediaInfo_New();
            [DllImport("MediaInfo.dll")]
            public static extern void MediaInfo_Delete(IntPtr Handle);
            [DllImport("MediaInfo.dll")]
            public static extern int MediaInfo_Open(IntPtr Handle, [MarshalAs(UnmanagedType.LPWStr)] string FileName);
            [DllImport("MediaInfo.dll")]
            public static extern void MediaInfo_Close(IntPtr Handle);
            [DllImport("MediaInfo.dll")]
            public static extern IntPtr MediaInfo_Inform(IntPtr Handle, [MarshalAs(UnmanagedType.U4)] uint Reserved);
            [DllImport("MediaInfo.dll")]
            public static extern IntPtr MediaInfo_GetI(IntPtr Handle, [MarshalAs(UnmanagedType.U4)] StreamKind StreamKind, uint StreamNumber, uint Parameter, [MarshalAs(UnmanagedType.U4)] InfoKind KindOfInfo);
            [DllImport("MediaInfo.dll")]
            public static extern IntPtr MediaInfo_Get(IntPtr Handle, [MarshalAs(UnmanagedType.U4)] StreamKind StreamKind, uint StreamNumber, [MarshalAs(UnmanagedType.LPWStr)] string Parameter, [MarshalAs(UnmanagedType.U4)] InfoKind KindOfInfo, [MarshalAs(UnmanagedType.U4)] InfoKind KindOfSearch);
            [DllImport("MediaInfo.dll")]
            public static extern IntPtr MediaInfo_Option(IntPtr Handle, [MarshalAs(UnmanagedType.LPWStr)] string Option, [MarshalAs(UnmanagedType.LPWStr)] string Value);
            [DllImport("MediaInfo.dll")]
            public static extern int MediaInfo_State_Get(IntPtr Handle);
            [DllImport("MediaInfo.dll")]
            public static extern int MediaInfo_Count_Get(IntPtr Handle, [MarshalAs(UnmanagedType.U4)] StreamKind StreamKind, int StreamNumber);

            //MediaInfo class
            public MediaInfo()
            {
                try
                {
                    Handle = MediaInfo_New();
                }
                catch (Exception ex)
                {
                    //MPTVSeriesLog.Write("Error creating the MediaInfo Object, most likely no or wrong mediainfo.dll in directory: ", ex.Message , MPTVSeriesLog.LogLevel.Normal);
                }
            }
            ~MediaInfo()
            {
                try
                {
                    MediaInfo_Delete(Handle);
                }
                catch (Exception ex)
                {
                    //MPTVSeriesLog.Write("Error deleting the MediaInfo Object: ", ex.Message, MPTVSeriesLog.LogLevel.Normal);
                }
            }
            public int Open(String FileName) { return MediaInfo_Open(Handle, FileName); }
            public void Close() { MediaInfo_Close(Handle); }
            public String Inform() { return Marshal.PtrToStringUni(MediaInfo_Inform(Handle, 0)); }
            public String Get(StreamKind StreamKind, uint StreamNumber, String Parameter, InfoKind KindOfInfo, InfoKind KindOfSearch) { return Marshal.PtrToStringUni(MediaInfo_Get(Handle, StreamKind, StreamNumber, Parameter, KindOfInfo, KindOfSearch)); }
            public String Get(StreamKind StreamKind, uint StreamNumber, uint Parameter, InfoKind KindOfInfo) { return Marshal.PtrToStringUni(MediaInfo_GetI(Handle, StreamKind, StreamNumber, Parameter, KindOfInfo)); }
            public String Option(String Option, String Value) { return Marshal.PtrToStringUni(MediaInfo_Option(Handle, Option, Value)); }
            public int State_Get() { return MediaInfo_State_Get(Handle); }
            public int Count_Get(StreamKind StreamKind, int StreamNumber) { return MediaInfo_Count_Get(Handle, StreamKind, StreamNumber); }
            private IntPtr Handle;

            //Default values, if you know how to set default values in C#, say me
            public String Get(StreamKind StreamKind, uint StreamNumber, String Parameter, InfoKind KindOfInfo) { return Get(StreamKind, StreamNumber, Parameter, KindOfInfo, InfoKind.Name); }
            public String Get(StreamKind StreamKind, uint StreamNumber, String Parameter) { return Get(StreamKind, StreamNumber, Parameter, InfoKind.Text, InfoKind.Name); }
            public String Get(StreamKind StreamKind, uint StreamNumber, uint Parameter) { return Get(StreamKind, StreamNumber, Parameter, InfoKind.Text); }
            public String Option(String Option_) { return Option(Option_, ""); }
            public int Count_Get(StreamKind StreamKind) { return Count_Get(StreamKind, -1); }

            public string getVidCodec() { return this.Get(StreamKind.Video, 0, "Codec"); }
            public string getVidBitrate() { return this.Get(StreamKind.Video, 0, "BitRate"); }
            public string getWidth() { return this.Get(StreamKind.Video, 0, "Width"); }
            public string getHeight() { return this.Get(StreamKind.Video, 0, "Height"); }
            public string getAR() { return this.Get(StreamKind.Video, 0, "AspectRatio"); }
            public string getPlaytime() { return this.Get(StreamKind.Video, 0, "PlayTime"); }
            public string getFPS() { return this.Get(StreamKind.Video, 0, "FrameRate"); }
            public string getAudioCount() { return this.Get(StreamKind.Audio, 0, "StreamCount"); }
            public string getAudioCodec() { return this.Get(StreamKind.Audio, 0, "Codec"); }
            public string getAudioBitrate() { return this.Get(StreamKind.Audio, 0, "BitRate"); }
            public string getNoChannels() { return getNoChannels(0); }
            public string getNoChannels(int stream) { return this.Get(StreamKind.Audio, (uint)stream, "Channel(s)"); }

        }
    }
}