using System;
using System.Collections.Generic;
using System.Linq;

using DdcSharp.Models;
using DdcSharp.Native;
using DdcSharp.Native.Models;

namespace DdcSharp
{
    public class MonitorApi
    {
        // Refs
        // http://stackoverflow.com/q/846518/2001966
        // http://stackoverflow.com/a/18065609/2001966
        // Monitor functions - https://msdn.microsoft.com/en-us/library/windows/desktop/dd692964(v=vs.85).aspx

        public IEnumerable<VirtualDisplay> GetDisplays()
        {
            var monitors = new List<VirtualDisplay>();

            NativeApi.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate(IntPtr hMonitor, IntPtr hdcMonitor, RECT lprcMonitor, IntPtr dwData)
                {
                    var monitorInfo = new MONITORINFOEX();
                    monitorInfo.Init();
                    var success = NativeApi.GetMonitorInfo(hMonitor, ref monitorInfo);
                    if (success)
                    {
                        var displayInfo = new VirtualDisplay
                        {
                            Width = monitorInfo.Monitor.Width,
                            Height = monitorInfo.Monitor.Height,
                            IsPrimary = monitorInfo.Flags.HasFlag(MONITORINFOEX_FLAGS.MONITORINFOF_PRIMARY),
                            Handle = hMonitor
                        };
                        monitors.Add(displayInfo);
                    }
                    return true;
                }, IntPtr.Zero);

            foreach (var displayInfo in monitors)
            {
                displayInfo.PhysicalDisplays = GetPysicalMonitors(displayInfo.Handle).ToList();

                yield return displayInfo;
            }
        }

        public IEnumerable<PhysicalDisplay> GetPysicalMonitors(IntPtr hMonitor)
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

                    yield return
                        new PhysicalDisplay(
                            () => NativeApi.DestroyPhysicalMonitors(physicalMonitor.PhysicalMonitorHandler),
                            physicalMonitor.PhysicalMonitorHandler,
                            pdwMonitorCapabilities,
                            pdwSupportedColorTemperatures
                        );
                }
            }
        }
    }
}