using System.Diagnostics.CodeAnalysis;

namespace DdcSharp.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public enum MC_DISPLAY_TECHNOLOGY_TYPE
    {
        MC_SHADOW_MASK_CATHODE_RAY_TUBE,

        MC_APERTURE_GRILL_CATHODE_RAY_TUBE,

        MC_THIN_FILM_TRANSISTOR,

        MC_LIQUID_CRYSTAL_ON_SILICON,

        MC_PLASMA,

        MC_ORGANIC_LIGHT_EMITTING_DIODE,

        MC_ELECTROLUMINESCENT,

        MC_MICROELECTROMECHANICAL,

        MC_FIELD_EMISSION_DEVICE,
    }
}