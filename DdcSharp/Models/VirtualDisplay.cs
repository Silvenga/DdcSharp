using System;
using System.Collections.Generic;

using DdcSharp.Native;

namespace DdcSharp.Models
{
    public class VirtualDisplay
    {
        public bool IsPrimary { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public IList<PhysicalDisplay> PhysicalDisplays { get; set; }
    }

    public class PhysicalDisplay : IDisposable
    {
        public IntPtr Handle { get; private set; }

        public bool SupportsBrightness { get; set; }

        public bool SupportsColorTemperature { get; set; }

        public void Dispose()
        {
            NativeApi.DestroyPhysicalMonitors(Handle);
        }
    }
}