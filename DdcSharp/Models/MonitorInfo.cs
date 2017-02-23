using System;

using DdcSharp.Native;

namespace DdcSharp.Models
{
    public class MonitorInfo : IDisposable
    {
        public IntPtr MonitorHandler { get; set; }

        public MonitorCapabilities Capabilities { get; set; }

        public SupportedColorTemperatures SupportedColorTemperatures { get; set; }

        public string Description { get; set; }

        public void Dispose()
        {
            NativeApi.DestroyPhysicalMonitors(MonitorHandler);
        }
    }
}