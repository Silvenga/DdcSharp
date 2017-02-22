using System;

namespace DdcSharp.Models
{
    public class DisplayInfo
    {
        public IntPtr MonitorHandler { get; set; }
        public MONITORINFOEX_FLAGS Availability { get; set; }
        public int ScreenHeight { get; set; }
        public int ScreenWidth { get; set; }
        public RECT MonitorArea { get; set; }
        public RECT WorkArea { get; set; }
    }
}