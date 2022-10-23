using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Aircraft
{
    public enum AircraftEngineType
    {
        [Description("Unknown")]
        Unknown,
        [Description("Jet")]
        Jet,
        [Description("Turbo prop")]
        Turboprop,
        [Description("Piston")]
        Piston,
    }
}
