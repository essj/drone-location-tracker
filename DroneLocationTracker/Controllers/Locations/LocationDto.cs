using System;
using System.ComponentModel.DataAnnotations;

namespace DroneLocationTracker.Controllers.Locations
{
	public class LocationDto
	{
		[Required]
		public double Latitude { get; set; }

		[Required]
		public double Longitude { get; set; }

		[Required]
		public DateTimeOffset Timestamp { get; set; }

		[Required]
		public double Speed { get; set; }
	}
}
