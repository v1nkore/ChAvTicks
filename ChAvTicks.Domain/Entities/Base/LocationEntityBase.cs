namespace ChAvTicks.Domain.Entities.Base
{
	public class LocationEntityBase
	{
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
