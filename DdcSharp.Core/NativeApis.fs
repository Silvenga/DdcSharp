module NativeApis

open System.Runtime.InteropServices
open System
open NativeModels

[<DllImport("user32.dll", SetLastError = true)>]
extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData)

[<DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)>]
extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFOEX& lpmi)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool GetNumberOfPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint32& pdwNumberOfPhysicalMonitors)

[<DllImport("dxva2.dll", CharSet = CharSet.Auto)>]
extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint32 dwPhysicalMonitorArraySize,
                                                                  [<Out>] PHYSICAL_MONITOR[] pPhysicalMonitorArray)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool GetMonitorCapabilities(IntPtr hMonitor, MonitorCapabilities& pdwMonitorCapabilities,
                                                         SupportedColorTemperatures& pdwSupportedColorTemperatures)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool DestroyPhysicalMonitors(IntPtr hMonitor)

[<DllImport("kernel32.dll")>]
extern uint32 GetLastError();