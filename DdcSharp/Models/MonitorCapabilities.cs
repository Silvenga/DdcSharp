using System;
using System.Diagnostics.CodeAnalysis;

namespace DdcSharp.Models
{
    [Flags]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public enum MonitorCapabilities : uint
    {
        /// <summary>
        /// The monitor supports the GetMonitorBrightness and SetMonitorBrightness functions.
        /// </summary>
        MC_CAPS_BRIGHTNESS = 1 << 0,

        /// <summary>
        /// The monitor supports the GetMonitorColorTemperature and SetMonitorColorTemperature functions.
        /// </summary>
        MC_CAPS_COLOR_TEMPERATURE = 1 << 1,

        /// <summary>
        /// The monitor supports the GetMonitorContrast and SetMonitorContrast functions.
        /// </summary>
        MC_CAPS_CONTRAST = 1 << 2,

        /// <summary>
        /// The monitor supports the DegaussMonitor function.
        /// </summary>
        MC_CAPS_DEGAUSS = 1 << 3,

        /// <summary>
        /// The monitor supports the GetMonitorDisplayAreaPosition and SetMonitorDisplayAreaPosition functions.
        /// </summary>
        MC_CAPS_DISPLAY_AREA_POSITION = 1 << 4,

        /// <summary>
        /// The monitor supports the GetMonitorDisplayAreaSize and SetMonitorDisplayAreaSize functions.
        /// </summary>
        MC_CAPS_DISPLAY_AREA_SIZE = 1 << 5,

        /// <summary>
        /// The monitor supports the GetMonitorTechnologyType function.
        /// </summary>
        MC_CAPS_MONITOR_TECHNOLOGY_TYPE = 1 << 6,

        /// <summary>
        /// The monitor does not support any monitor settings.
        /// </summary>
        MC_CAPS_NONE = 1 << 7,

        /// <summary>
        /// The monitor supports the GetMonitorRedGreenOrBlueDrive and SetMonitorRedGreenOrBlueDrive functions.
        /// </summary>
        MC_CAPS_RED_GREEN_BLUE_DRIVE = 1 << 8,

        /// <summary>
        /// The monitor supports the GetMonitorRedGreenOrBlueGain and SetMonitorRedGreenOrBlueGain functions.
        /// </summary>
        MC_CAPS_RED_GREEN_BLUE_GAIN = 1 << 9,

        /// <summary>
        /// The monitor supports the RestoreMonitorFactoryColorDefaults function.
        /// </summary>
        MC_CAPS_RESTORE_FACTORY_COLOR_DEFAULTS = 1 << 10,

        /// <summary>
        /// The monitor supports the RestoreMonitorFactoryDefaults function.
        /// </summary>
        MC_CAPS_RESTORE_FACTORY_DEFAULTS = 1 << 11,

        /// <summary>
        /// If this flag is present, calling the RestoreMonitorFactoryDefaults function enables all of the monitor settings used by the high-level monitor configuration functions. 
        /// For more information, see the Remarks section in RestoreMonitorFactoryDefaults.
        /// </summary>
        MC_RESTORE_FACTORY_DEFAULTS_ENABLES_MONITOR_SETTINGS = 1 << 12
    }
}