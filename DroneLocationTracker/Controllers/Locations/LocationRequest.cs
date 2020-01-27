using System;
using System.ComponentModel.DataAnnotations;

namespace DroneLocationTracker.Controllers.Locations
{
	public class LocationRequest
	{
		/// <summary>
		/// Which drone this location is for.
		/// </summary>
		[Required]
		public Guid DroneId { get; set; }

		[Required]
		public double Latitude { get; set; }

		[Required]
		public double Longitude { get; set; }

		[Required]
		public double Speed { get; set; }
	}
}
