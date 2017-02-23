using System;
using System.Collections.Generic;
using System.Linq;

using DdcSharp.Native;
using DdcSharp.Native.Models;

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

        public IList<MonitorInfo> PhysicalMonitors { get; set; }

        public void Dispose()
        {
            foreach (var physicalMonitor in PhysicalMonitors ?? Enumerable.Empty<MonitorInfo>())
            {
                physicalMonitor?.Dispose();
            }
        }
    }
}