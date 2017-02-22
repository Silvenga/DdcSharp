using System;
using System.Runtime.InteropServices;

using DdcSharp.Models;

namespace DdcSharp
{
    public class NativeApi
    {
        /// <summary>
        /// The EnumDisplayMonitors function enumerates display monitors (including invisible pseudo-monitors associated with the mirroring drivers) 
        /// that intersect a region formed by the intersection of a specified clipping rectangle and the visible region of a device context. 
        /// EnumDisplayMonitors calls an application-defined MonitorEnumProc callback function once for each monitor that is enumerated. 
        /// Note that GetSystemMetrics (SM_CMONITORS) counts only the display monitors.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd162610(v=vs.85).aspx
        /// </summary>
        /// <param name="hdc">A handle to a display device context that defines the visible region of interest.</param>
        /// <param name="lprcClip">A pointer to a RECT structure that specifies a clipping rectangle. The region of interest is the intersection of the clipping rectangle with the visible region specified by hdc.</param>
        /// <param name="lpfnEnum">A pointer to a MonitorEnumProc application-defined callback function.</param>
        /// <param name="dwData">Application-defined data that EnumDisplayMonitors passes directly to the MonitorEnumProc function.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

        /// <summary>
        /// A MonitorEnumProc function is an application-defined callback function that is called by the EnumDisplayMonitors function.
        /// </summary>
        /// <param name="hMonitor">A handle to the display monitor. This value will always be non-NULL.</param>
        /// <param name="hdcMonitor">A handle to a device context.</param>
        /// <param name="lprcMonitor">A pointer to a RECT structure.</param>
        /// <param name="dwData">Application-defined data that EnumDisplayMonitors passes directly to the enumeration function.</param>
        /// <returns></returns>
        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        /// <summary>
        /// The GetMonitorInfo function retrieves information about a display monitor.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd144901(v=vs.85).aspx
        /// </summary>
        /// <param name="hMonitor">A handle to the display monitor of interest.</param>
        /// <param name="lpmi">A pointer to a MONITORINFO or MONITORINFOEX structure that receives information about the specified display monitor.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFOEX lpmi);

        /// <summary>
        /// Retrieves the type of technology used by a monitor.
        /// </summary>
        /// <param name="hMonitor">Handle to a physical monitor. To get the monitor handle, call GetPhysicalMonitorsFromHMONITOR or GetPhysicalMonitorsFromIDirect3DDevice9.</param>
        /// <param name="pdtyDisplayTechnologyType">Receives the technology type, specified as a member of the MC_DISPLAY_TECHNOLOGY_TYPE enumeration.</param>
        /// <returns></returns>
        [DllImport("dxva2.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorTechnologyType(IntPtr hMonitor, ref MC_DISPLAY_TECHNOLOGY_TYPE pdtyDisplayTechnologyType);

        /// <summary>
        /// Retrieves the configuration capabilities of a monitor. Call this function to find out which high-level monitor configuration functions are supported by the monitor.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd692940(v=vs.85).aspx
        /// </summary>
        /// <param name="hMonitor">Handle to a physical monitor. To get the monitor handle, call GetPhysicalMonitorsFromHMONITOR or GetPhysicalMonitorsFromIDirect3DDevice9.</param>
        /// <param name="pdwMonitorCapabilities">Receives a bitwise OR of capabilities flags. See Remarks.</param>
        /// <param name="pdwSupportedColorTemperatures">Receives a bitwise OR of color temperature flags. See Remarks.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</returns>
        [DllImport("dxva2.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMonitorCapabilities(IntPtr hMonitor, ref uint pdwMonitorCapabilities, ref uint pdwSupportedColorTemperatures);

        /// <summary>
        /// Closes an array of physical monitor handles. 
        /// Call this function to close an array of monitor handles obtained from the GetPhysicalMonitorsFromHMONITOR or GetPhysicalMonitorsFromIDirect3DDevice9 function.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd692937(v=vs.85).aspx
        /// </summary>
        /// <param name="dwPhysicalMonitorArraySize">Number of elements in the pPhysicalMonitorArray array.</param>
        /// <param name="pPhysicalMonitorArray">Pointer to an array of PHYSICAL_MONITOR structures.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</returns>
        [DllImport("dxva2.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyPhysicalMonitors(uint dwPhysicalMonitorArraySize, ref PHYSICAL_MONITOR[] pPhysicalMonitorArray);

        /// <summary>
        /// Retrieves the number of physical monitors associated with an HMONITOR monitor handle. Call this function before calling GetPhysicalMonitorsFromHMONITOR.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd692948(v=vs.85).aspx
        /// </summary>
        /// <param name="hMonitor">A monitor handle. Monitor handles are returned by several Multiple Display Monitor functions, including EnumDisplayMonitors and MonitorFromWindow, which are part of the graphics device interface (GDI).</param>
        /// <param name="pdwNumberOfPhysicalMonitors">Receives the number of physical monitors associated with the monitor handle.</param>
        /// <returns>If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</returns>
        [DllImport("dxva2.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, ref uint pdwNumberOfPhysicalMonitors);

        /// <summary>
        /// Retrieves the physical monitors associated with an HMONITOR monitor handle.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd692950(v=vs.85).aspx
        /// </summary>
        /// <param name="hMonitor">A monitor handle. Monitor handles are returned by several Multiple Display Monitor functions, including EnumDisplayMonitors and MonitorFromWindow, which are part of the graphics device interface (GDI).</param>
        /// <param name="dwPhysicalMonitorArraySize">Number of elements in pPhysicalMonitorArray. To get the required size of the array, call GetNumberOfPhysicalMonitorsFromHMONITOR.</param>
        /// <param name="pPhysicalMonitorArray">Pointer to an array of PHYSICAL_MONITOR structures. The caller must allocate the array.</param>
        /// <returns></returns>
        [DllImport("dxva2.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint dwPhysicalMonitorArraySize,
                                                                  [Out] PHYSICAL_MONITOR[] pPhysicalMonitorArray);
    }
}