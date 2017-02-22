using System;
using System.Collections.Generic;

using DdcSharp.Models;

namespace DdcSharp
{
    public class MonitorApi
    {
        // Refs
        // http://stackoverflow.com/q/846518/2001966
        // http://stackoverflow.com/a/18065609/2001966

        public IEnumerable<DisplayInfo> GetDisplays()
        {
            var monitors = new List<DisplayInfo>();

            NativeApi.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
                {
                    var monitorInfo = new MONITORINFOEX();
                    monitorInfo.Init();
                    var success = NativeApi.GetMonitorInfo(hMonitor, ref monitorInfo);
                    if (success)
                    {
                        var displayInfo = new DisplayInfo
                        {
                            ScreenWidth = monitorInfo.Monitor.Width,
                            ScreenHeight = monitorInfo.Monitor.Height,
                            MonitorArea = monitorInfo.Monitor,
                            WorkArea = monitorInfo.WorkArea,
                            Availability = monitorInfo.Flags,
                            MonitorHandler = hMonitor
                        };
                        monitors.Add(displayInfo);
                    }
                    return true;
                }, IntPtr.Zero);

            return monitors;
        }

        public void GetPysicalMonitors(IntPtr hMonitor)
        {
            uint numberOfPhysicalMonitors = 0;
            var success = NativeApi.GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, ref numberOfPhysicalMonitors);
            if (success)
            {
                var physicalMonitors = new PHYSICAL_MONITOR[numberOfPhysicalMonitors];
                success = NativeApi.GetPhysicalMonitorsFromHMONITOR(hMonitor, numberOfPhysicalMonitors, physicalMonitors);
            }
        }
    }
}