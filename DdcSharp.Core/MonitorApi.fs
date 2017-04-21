namespace DdcSharp.Core

open System
open System.Collections.Generic
open NativeApis
open MonitorModels
open NativeModels
open System.Runtime.InteropServices
open System.Linq

type MonitorInfo = 
    { PHYSICAL_MONITOR : PHYSICAL_MONITOR
      MonitorCapabilities : MonitorCapabilities
      SupportedColorTemperatures : SupportedColorTemperatures }

type MonitorApi() = 
    
    member this.GetDisplays() : IEnumerable<VirtualDisplay> = 
        let monitors = new List<VirtualDisplay>()
        
        let callback (hMonitor : IntPtr) (hdcMonitor : IntPtr) (lprcMonitor : RECT) (dwData : IntPtr) = 
            let mutable monitorInfo = new MONITORINFOEX()
            monitorInfo.Size <- 104
            monitorInfo.DeviceName <- ""
            let success = GetMonitorInfo(hMonitor, &monitorInfo)
            match success with
            | true -> 
                let virtualDisplay = 
                    new VirtualDisplay(Width = monitorInfo.Monitor.Width, Height = monitorInfo.Monitor.Height, 
                                       IsPrimary = monitorInfo.Flags.HasFlag(MONITORINFOEX_FLAGS.MONITORINFOF_PRIMARY), 
                                       Handle = hMonitor, Name = monitorInfo.DeviceName)
                monitors.Add(virtualDisplay)
            | _ -> failwithf "Failed with error %i." (Marshal.GetLastWin32Error())
            true
        
        let success = EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, new MonitorEnumDelegate(callback), IntPtr.Zero)
        if not success then failwithf "Failed with error %i." (Marshal.GetLastWin32Error())
        monitors
        |> List.ofSeq
        |> Seq.map (fun display -> 
               display.PhysicalDisplays <- this.GetPysicalMonitors(display.Handle)
               display)
    
    member this.GetPysicalMonitors(hMonitor : IntPtr) = 
        let mutable numberOfPhysicalMonitors = 0u
        let success = GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, &numberOfPhysicalMonitors)
        if not success then failwithf "Failed with error %i." (Marshal.GetLastWin32Error())
        let physicalMonitors = 
            match success with
            | true -> 
                let mutable inMonitors = Array.zeroCreate (int32 (numberOfPhysicalMonitors))
                let success = GetPhysicalMonitorsFromHMONITOR(hMonitor, numberOfPhysicalMonitors, inMonitors)
                if not success then failwithf "Failed with error %i." (Marshal.GetLastWin32Error())
                inMonitors
            | false -> [||]
        
        let getInfo (physicalMonitor : PHYSICAL_MONITOR) = 
            let mutable pdwMonitorCapabilities = LanguagePrimitives.EnumOfValue 0u
            let mutable pdwSupportedColorTemperatures = LanguagePrimitives.EnumOfValue 0u
            let success = 
                GetMonitorCapabilities
                    (physicalMonitor.PhysicalMonitorHandler, &pdwMonitorCapabilities, &pdwSupportedColorTemperatures)
            if not success then failwithf "Failed with error %i." (Marshal.GetLastWin32Error())
            { MonitorCapabilities = pdwMonitorCapabilities
              SupportedColorTemperatures = pdwSupportedColorTemperatures
              PHYSICAL_MONITOR = physicalMonitor }
        
        let getPhysicalDisplay (info : MonitorInfo) = 
            new PhysicalDisplay(Handle = info.PHYSICAL_MONITOR.PhysicalMonitorHandler, 
                                capabilities = info.MonitorCapabilities, 
                                colorTemperatures = info.SupportedColorTemperatures, 
                                Name = info.PHYSICAL_MONITOR.PhysicalMonitorDescription)
        physicalMonitors
        |> Array.map getInfo
        |> Array.map getPhysicalDisplay
