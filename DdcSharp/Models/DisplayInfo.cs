using System;
using System.Collections.Generic;

namespace DdcSharp.Models
{
    public class DisplayInfo : IDisposable
    {
        public IntPtr MonitorHandler { get; set; }
        public MONITORINFOEX_FLAGS Availability { get; set; }
        public int ScreenHeight { get; set; }
        public int ScreenWidth { get; set; }
        public RECT MonitorArea { get; set; }
        public RECT WorkArea { get; set; }

        public IList<PHYSICAL_MONITOR> PhysicalMonitors { get; set; }

        public void Dispose()
        {
        }
    }

    public class MonitorInfo
    {
        
    }
}