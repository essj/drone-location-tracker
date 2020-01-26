using DroneLocationTracker.Controllers.Locations;
using System;
using System.ComponentModel.DataAnnotations;

namespace DroneLocationTracker.Controllers.Drones
{
	public class DroneDto
	{
		[Required]
		public Guid DroneId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public LocationDto LastLocation { get; set; }
	}
}
