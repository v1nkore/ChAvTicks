using System.ComponentModel;

namespace ChAvTicks.Domain.Enums.Airport
{
	public enum AirportRunwaySurfaceType
	{
		[Description("Unknown")]
		Unknown,
		[Description("Asphalt")]
		Asphalt,
		[Description("Concrete")]
		Concrete,
		[Description("Grass")]
		Grass,
		[Description("Dirt")]
		Dirt,
		[Description("Gravel")]
		Gravel,
		[Description("Dry lakebed")]
		DryLakebed,
		[Description("Water")]
		Water,
		[Description("Snow")]
		Snow
	}
}
