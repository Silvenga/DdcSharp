module DdcSharp.Core.MonitorModels

open System
open NativeModels

type PhysicalDisplay(capabilities : MonitorCapabilities, colorTemperatures : SupportedColorTemperatures) =
    member val Handle = IntPtr.Zero with get, set
    member val Name = "" with get, set
    member val SupportsBrightness = capabilities.HasFlag(MonitorCapabilities.MC_CAPS_BRIGHTNESS) with get
    member val SupportsColorTemperature = capabilities.HasFlag(MonitorCapabilities.MC_CAPS_COLOR_TEMPERATURE) with get
    
type VirtualDisplay() =
    member val Handle = IntPtr.Zero with get, set
    member val Name = "" with get, set
    member val IsPrimary = false with get, set
    member val Height = 0 with get, set
    member val Width = 0 with get, set
    member val PhysicalDisplays : PhysicalDisplay[] = [||] with get, set