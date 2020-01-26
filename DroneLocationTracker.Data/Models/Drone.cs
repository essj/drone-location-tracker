using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace DroneLocationTracker.Data.Models
{
	public class Drone
	{
		[Key]
		public Guid DroneId { get; set; }

		public string Name { get; set; }

		public Guid? LastLocationId { get; set; }

		// Navigation properties.
		public Location LastLocation { get; set; }
	}

	public class DroneConfiguration : IEntityTypeConfiguration<Drone>
	{
		public void Configure(EntityTypeBuilder<Drone> builder)
		{
			builder.HasOne(x => x.LastLocation)
				.WithOne(x => x.Drone)
				.HasForeignKey<Drone>(x => x.LastLocationId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
