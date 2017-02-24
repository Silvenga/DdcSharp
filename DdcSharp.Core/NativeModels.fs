module NativeModels

open DdcSharp.Native.Models
open System

//open System
//open System.Runtime.InteropServices
//open DdcSharp.Native.Models

//[<StructAttribute>]
//[<StructLayout(LayoutKind.Sequential)>]
//type PHYSICAL_MONITOR =
//    val mutable PhysicalMonitorHandler : IntPtr
//    [<MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)>]
//    val mutable PhysicalMonitorDescription : string

////[<StructAttribute>]
////[<StructLayout(LayoutKind.Sequential)>]
////type RECT =
////    val mutable Left: int
////    val mutable Top: int
////    val mutable Right: int
////    val mutable Bottom: int
////    member this.Height with get() = this.Bottom - this.Top
////    member this.Width with get() = this.Right - this.Left

//[<FlagsAttribute>]
//type MONITORINFOEX_FLAGS =
//    | MONITORINFOF_PRIMARY = 0

//[<StructAttribute>]
//[<StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)>]
//type MONITORINFOEX =
//    val mutable Size : int
//    val mutable Monitor : RECT
//    val mutable WorkArea : RECT
//    val mutable Flags : MONITORINFOEX_FLAGS
//    [<MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)>]
//    val mutable DeviceName : string

    
//[<FlagsAttribute>]
//type MonitorCapabilities =
//    | MC_CAPS_BRIGHTNESS =                                   0b0_0000_0000_0001u
//    | MC_CAPS_COLOR_TEMPERATURE =                            0b0_0000_0000_0010u
//    | MC_CAPS_CONTRAST =                                     0b0_0000_0000_0100u
//    | MC_CAPS_DEGAUSS =                                      0b0_0000_0000_1000u
//    | MC_CAPS_DISPLAY_AREA_POSITION =                        0b0_0000_0001_0000u
//    | MC_CAPS_DISPLAY_AREA_SIZE =                            0b0_0000_0010_0000u
//    | MC_CAPS_MONITOR_TECHNOLOGY_TYPE =                      0b0_0000_0100_0000u
//    | MC_CAPS_NONE =                                         0b0_0000_1000_0000u
//    | MC_CAPS_RED_GREEN_BLUE_DRIVE =                         0b0_0001_0000_0000u
//    | MC_CAPS_RED_GREEN_BLUE_GAIN =                          0b0_0010_0000_0000u
//    | MC_CAPS_RESTORE_FACTORY_COLOR_DEFAULTS =               0b0_0100_0000_0000u
//    | MC_CAPS_RESTORE_FACTORY_DEFAULTS =                     0b0_1000_0000_0000u
//    | MC_RESTORE_FACTORY_DEFAULTS_ENABLES_MONITOR_SETTINGS = 0b1_0000_0000_0000u

//[<FlagsAttribute>]
//type SupportedColorTemperatures =
//    | MC_SUPPORTED_COLOR_TEMPERATURE_NONE =   0b000000001u
//    | MC_SUPPORTED_COLOR_TEMPERATURE_4000K =  0b000000010u
//    | MC_SUPPORTED_COLOR_TEMPERATURE_5000K =  0b000000100u
//    | MC_SUPPORTED_COLOR_TEMPERATURE_6500K =  0b000001000u
//    | MC_SUPPORTED_COLOR_TEMPERATURE_7500K =  0b000010000u
//    | MC_SUPPORTED_COLOR_TEMPERATURE_8200K =  0b000100000u
//    | MC_SUPPORTED_COLOR_TEMPERATURE_9300K =  0b001000000u
//    | MC_SUPPORTED_COLOR_TEMPERATURE_10000K = 0b010000000u
//    | MC_SUPPORTED_COLOR_TEMPERATURE_11500K = 0b100000000u

type MonitorEnumDelegate = delegate of IntPtr * IntPtr * RECT * IntPtr -> bool