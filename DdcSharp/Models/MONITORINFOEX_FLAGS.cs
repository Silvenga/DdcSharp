using System;
using System.Diagnostics.CodeAnalysis;

namespace DdcSharp.Models
{
    [Flags]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public enum MONITORINFOEX_FLAGS
    {
        MONITORINFOF_PRIMARY = 1
    }
}