namespace DdcSharp.Core

open System
open System.Collections.Generic
open NativeApis
open MonitorModels
open DdcSharp.Native.Models
open DdcSharp.Models
open NativeModels

type MonitorInfo = 
    { Handle : IntPtr
      MonitorCapabilities : MonitorCapabilities
      SupportedColorTemperatures : SupportedColorTemperatures }

type MonitorApi() = 
    
    member this.GetDisplays() : IEnumerable<VirtualDisplay> = 
        let monitors = new List<VirtualDisplay>()
        
        let callback (hMonitor : IntPtr) (hdcMonitor : IntPtr) (lprcMonitor : RECT) (dwData : IntPtr) = 
            let mutable monitorInfo = new MONITORINFOEX()
            monitorInfo.Size <- 104
            monitorInfo.DeviceName<- ""
            match GetMonitorInfo(hMonitor, &monitorInfo) with
            | true -> 
                let virtualDisplay = 
                    new VirtualDisplay(Width = monitorInfo.Monitor.Width, Height = monitorInfo.Monitor.Height, 
                                       IsPrimary = monitorInfo.Flags.HasFlag(MONITORINFOEX_FLAGS.MONITORINFOF_PRIMARY), 
                                       Handle = hMonitor)
                monitors.Add(virtualDisplay)
            | _ -> failwith "Oh no!"
            |> ignore
            true
        EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, new MonitorEnumDelegate(callback), IntPtr.Zero) |> ignore
        monitors
        |> List.ofSeq
        |> Seq.map (fun display -> 
               display.PhysicalDisplays <- this.GetPysicalMonitors(display.Handle)
               display)
    
    member this.GetPysicalMonitors(hMonitor : IntPtr) = 
        let mutable numberOfPhysicalMonitors = 0u
        let success = GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, &numberOfPhysicalMonitors)
        
        let physicalMonitors = 
            match success with
            | true -> 
                let mutable inMonitors = Array.zeroCreate (int32 (numberOfPhysicalMonitors))
                GetPhysicalMonitorsFromHMONITOR(hMonitor, numberOfPhysicalMonitors, &inMonitors) |> ignore
                inMonitors
            | false -> [||]
        
        let getInfo (physicalMonitor : PHYSICAL_MONITOR) = 
            let mutable pdwMonitorCapabilities = LanguagePrimitives.EnumOfValue 0u
            let mutable pdwSupportedColorTemperatures = LanguagePrimitives.EnumOfValue 0u
            GetMonitorCapabilities
                (physicalMonitor.PhysicalMonitorHandler, &pdwMonitorCapabilities, &pdwSupportedColorTemperatures) 
            |> ignore
            { MonitorCapabilities = pdwMonitorCapabilities
              SupportedColorTemperatures = pdwSupportedColorTemperatures
              Handle = physicalMonitor.PhysicalMonitorHandler }
        
        let getPhysicalDisplay (info : MonitorInfo) = 
            //new PhysicalDisplay(Handle = info.Handle, capabilities = info.MonitorCapabilities, 
            //                    colorTemperatures = info.SupportedColorTemperatures)
            null
        physicalMonitors
        |> Array.map getInfo
        |> Array.map getPhysicalDisplay
