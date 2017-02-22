using System;
using System.Collections.Generic;
using System.Linq;

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

            foreach (var displayInfo in monitors)
            {
                displayInfo.PhysicalMonitors = GetPysicalMonitors(displayInfo.MonitorHandler).ToList();

                yield return displayInfo;
            }
        }

        public IEnumerable<MonitorInfo> GetPysicalMonitors(IntPtr hMonitor)
        {
            uint numberOfPhysicalMonitors = 0;
            var success = NativeApi.GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, ref numberOfPhysicalMonitors);
            if (success)
            {
                var physicalMonitors = new PHYSICAL_MONITOR[numberOfPhysicalMonitors];
                NativeApi.GetPhysicalMonitorsFromHMONITOR(hMonitor, numberOfPhysicalMonitors, physicalMonitors);
                foreach (var physicalMonitor in physicalMonitors)
                {
                    MonitorCapabilities pdwMonitorCapabilities = 0;
                    SupportedColorTemperatures pdwSupportedColorTemperatures = 0;
                    NativeApi.GetMonitorCapabilities(physicalMonitor.PhysicalMonitorHandler, ref pdwMonitorCapabilities, ref pdwSupportedColorTemperatures);

                    yield return new MonitorInfo
                    {
                        Capabilities = pdwMonitorCapabilities,
                        SupportedColorTemperatures = pdwSupportedColorTemperatures,
                        MonitorHandler = physicalMonitor.PhysicalMonitorHandler,
                        Description = physicalMonitor.PhysicalMonitorDescription
                    };
                }
            }
        }
    }
}