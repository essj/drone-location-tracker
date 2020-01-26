using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DroneLocationTracker.Data.Models
{
	public class Drone
	{
		[Key]
		public Guid DroneId { get; set; }

		public string Name { get; set; }

		// Navigation properties.
		public List<Location> Locations { get; set; }
	}
}
