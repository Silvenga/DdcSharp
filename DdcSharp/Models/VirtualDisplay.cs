using System;
using System.Collections.Generic;

namespace DdcSharp.Models
{
    public class VirtualDisplay : IDisposable
    {
        public IntPtr Handle { get; set; }

        public bool IsPrimary { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public IList<PhysicalDisplay> PhysicalDisplays { get; set; }

        public void Dispose()
        {
            foreach (var physicalDisplay in PhysicalDisplays)
            {
                physicalDisplay.Dispose();
            }
        }
    }

    public class PhysicalDisplay : IDisposable
    {
        private readonly Action _disposeHandle;
        private readonly MonitorCapabilities _capabilities;
        private readonly SupportedColorTemperatures _colorTemperatures;

        public IntPtr Handle { get; private set; }

        public bool SupportsBrightness => _capabilities.HasFlag(MonitorCapabilities.MC_CAPS_BRIGHTNESS);

        public bool SupportsColorTemperature => _capabilities.HasFlag(MonitorCapabilities.MC_CAPS_COLOR_TEMPERATURE);

        public PhysicalDisplay(Action disposeHandle, IntPtr handle, MonitorCapabilities capabilities, SupportedColorTemperatures colorTemperatures)
        {
            _disposeHandle = disposeHandle;
            _capabilities = capabilities;
            _colorTemperatures = colorTemperatures;
            Handle = handle;
        }

        private void ReleaseUnmanagedResources()
        {
            _disposeHandle();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~PhysicalDisplay()
        {
            ReleaseUnmanagedResources();
        }
    }
}