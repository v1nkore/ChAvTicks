using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Flight
{
    public enum AirportMovementQuality
    {
        [Description("Basic")]
        Basic,
        [Description("Live")]
        Live,
        [Description("Approximate")]
        Approximate
    }
}
