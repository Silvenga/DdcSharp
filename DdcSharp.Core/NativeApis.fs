module DdcSharp.Core.NativeApis

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
extern bool GetPhysicalMonitorsFromHMONITOR(IntPtr hMonitor, uint32 dwPhysicalMonitorArraySize, [<Out>] PHYSICAL_MONITOR[] pPhysicalMonitorArray)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool GetMonitorCapabilities(IntPtr hMonitor, MonitorCapabilities& pdwMonitorCapabilities, SupportedColorTemperatures& pdwSupportedColorTemperatures)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool DestroyPhysicalMonitors(IntPtr hMonitor)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool GetMonitorTechnologyType(IntPtr hMonitor, MC_DISPLAY_TECHNOLOGY_TYPE& pdtyDisplayTechnologyType)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool SetVCPFeature(IntPtr hMonitor, byte bVCPCode, uint32 dwNewValue)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool SetMonitorBrightness(IntPtr hMonitor, uint32 dwNewBrightness)

[<DllImport("dxva2.dll", SetLastError = true)>]
extern bool GetMonitorBrightness(IntPtr hMonitor, uint32& pdwMinimumBrightness, uint32& pdwCurrentBrightness, uint32& pdwMaximumBrightness)
