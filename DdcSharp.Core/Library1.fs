namespace DdcSharp.Core

open DdcSharp.Native
open DdcSharp.Native.Models
open DdcSharp.Models
open System
open System.Collections.Generic

type MonitorApi() = 
    member this.GetDisplays = 
        let monitors = new List<VirtualDisplay>()
        
        let del (hMonitor : IntPtr) (hdcMonitor : IntPtr) (lprcMonitor: RECT) (dwData : IntPtr) = 
            let info = new MONITORINFOEX()
            info.Init()
            let monitorInfo = ref (new MONITORINFOEX())
            match NativeApi.GetMonitorInfo(hMonitor, monitorInfo) with
                | true ->
                    let ret = !monitorInfo
                    let a = new VirtualDisplay ( Width = ret.Monitor.Width, Height = ret.Monitor.Height, IsPrimary = ret.Flags.HasFlag(MONITORINFOEX_FLAGS.MONITORINFOF_PRIMARY), Handle = hMonitor)
                    monitors.Add(a)
                |> ignore
            true
            
        let populatePhysicalDisplays (display : VirtualDisplay) = this.GetPysicalMonitors(display.Handle)

        let success = NativeApi.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, new NativeApi.MonitorEnumDelegate(del), IntPtr.Zero)
        monitors
            |> List.ofSeq
            |> List.map populatePhysicalDisplays
     
    member this.GetPysicalMonitors (hMonitor : IntPtr) = 
        let numberOfPhysicalMonitors = ref (0u)
        let success = NativeApi.GetNumberOfPhysicalMonitorsFromHMONITOR(hMonitor, numberOfPhysicalMonitors)
        let physicalMonitors = 
            match success with
                | true -> Array.zeroCreate (int32(numberOfPhysicalMonitors.Value)) 
                | false -> [||]
        let success = NativeApi.GetPhysicalMonitorsFromHMONITOR(hMonitor, numberOfPhysicalMonitors.Value, physicalMonitors);

        let getPhysicalDisplay (physicalMonitor : PHYSICAL_MONITOR) =
            let pdwMonitorCapabilities = ref MonitorCapabilities.MC_CAPS_BRIGHTNESS
            let pdwSupportedColorTemperatures = ref SupportedColorTemperatures.MC_SUPPORTED_COLOR_TEMPERATURE_10000K
            NativeApi.GetMonitorCapabilities(physicalMonitor.PhysicalMonitorHandler, pdwMonitorCapabilities, pdwSupportedColorTemperatures) |> ignore
            new PhysicalDisplay((fun () -> NativeApi.DestroyPhysicalMonitors(physicalMonitor.PhysicalMonitorHandler) |> ignore), physicalMonitor.PhysicalMonitorHandler, !pdwMonitorCapabilities, !pdwSupportedColorTemperatures)

        physicalMonitors
            |> Seq.map getPhysicalDisplay