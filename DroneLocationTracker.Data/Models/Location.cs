using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace DroneLocationTracker.Data.Models
{
	public class Location
	{
		[Key]
		public Guid LocationId { get; set; }

		/// <summary>
		/// Which drone this location is for.
		/// </summary>
		public Guid DroneId { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		// Navigation properties.
		public Drone Drone { get; set; }
	}
}
