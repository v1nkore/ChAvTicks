using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Flight
{
	public enum CodeshareStatus
	{
		[Description("Unknown")]
		Unknown,
		[Description("Operator")]
		IsOperator,
		[Description("Codeshare")]
		IsCodeshared,
	}
}
