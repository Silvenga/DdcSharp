module NativeApis

open System.Runtime.InteropServices
open System
open NativeModels
open DdcSharp.Native.Models
open DdcSharp.Models

[<DllImport("user32.dll")>]
extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData)

[<DllImport("user32.dll")>]
extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFOEX& lpmi)

[<DllImport("dxva2.dll")>]
extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint32& pdwNumberOfPhysicalMonitors)

[<DllImport("dxva2.dll")>]
extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint32 dwPhysicalMonitorArraySize,
                                                                  PHYSICAL_MONITOR[]& pPhysicalMonitorArray)

[<DllImport("dxva2.dll")>]
extern bool GetMonitorCapabilities(IntPtr hMonitor, MonitorCapabilities& pdwMonitorCapabilities,
                                                         SupportedColorTemperatures& pdwSupportedColorTemperatures)

[<DllImport("dxva2.dll")>]
extern bool DestroyPhysicalMonitors(IntPtr hMonitor)