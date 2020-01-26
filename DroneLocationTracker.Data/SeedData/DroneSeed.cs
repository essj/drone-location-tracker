using DroneLocationTracker.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DroneLocationTracker.Data.SeedData
{
	public class DroneSeed : IEntityTypeConfiguration<Drone>
	{
		public void Configure(EntityTypeBuilder<Drone> builder)
		{
			builder.HasData(
				new Drone
				{
					DroneId = Guid.Parse("f358be15-2e6f-4235-802a-27ca93a5fef7"),
					Name = "Test Drone 1",
				},
				new Drone
				{
					DroneId = Guid.Parse("5dee1226-3865-45de-aa97-e0d9f80ab51f"),
					Name = "Test Drone 2",
				},
				new Drone
				{
					DroneId = Guid.Parse("4e8873e5-09d5-4eee-8602-e6f6046daaad"),
					Name = "Test Drone 3",
				},
				new Drone
				{
					DroneId = Guid.Parse("81372f59-1cd0-4577-9d7d-ad04d1e35e99"),
					Name = "Test Drone 4",
				},
				new Drone
				{
					DroneId = Guid.Parse("aa2252b6-7f41-41a1-9d5a-bd8b4064fd39"),
					Name = "Test Drone 5",
				}
			);
		}
	}
}
