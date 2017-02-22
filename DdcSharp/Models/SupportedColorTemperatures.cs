using System;
using System.Diagnostics.CodeAnalysis;

namespace DdcSharp.Models
{
    [Flags]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public enum SupportedColorTemperatures : uint
    {
        MC_SUPPORTED_COLOR_TEMPERATURE_NONE = 1 << 0,
        MC_SUPPORTED_COLOR_TEMPERATURE_4000K = 1 << 1,
        MC_SUPPORTED_COLOR_TEMPERATURE_5000K = 1 << 3,
        MC_SUPPORTED_COLOR_TEMPERATURE_6500K = 1 << 4,
        MC_SUPPORTED_COLOR_TEMPERATURE_7500K = 1 << 5,
        MC_SUPPORTED_COLOR_TEMPERATURE_8200K = 1 << 6,
        MC_SUPPORTED_COLOR_TEMPERATURE_9300K = 1 << 7,
        MC_SUPPORTED_COLOR_TEMPERATURE_10000K = 1 << 8,
        MC_SUPPORTED_COLOR_TEMPERATURE_11500K = 1 << 9
    }
}