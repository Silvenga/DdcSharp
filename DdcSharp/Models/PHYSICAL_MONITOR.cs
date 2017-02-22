using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace DdcSharp.Models
{
    /// <summary>
    /// Contains a handle and text description corresponding to a physical monitor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public struct PHYSICAL_MONITOR
    {
        /// <summary>
        /// Handle to the physical monitor. 
        /// hPhysicalMonitor
        /// </summary>
        public IntPtr PhysicalMonitorHandler;

        /// <summary>
        /// Text description of the physical monitor.
        /// szPhysicalMonitorDescription
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] public string PhysicalMonitorDescription;
    }
}