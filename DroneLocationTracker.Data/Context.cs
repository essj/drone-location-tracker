using Microsoft.EntityFrameworkCore;
using DroneLocationTracker.Data.Models;

namespace DroneLocationTracker.Data
{
	public class Context : DbContext
	{
		public DbSet<Drone> Drones { get; set; }
		public DbSet<Location> Locations { get; set; }

		public Context(DbContextOptions<Context> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
		}
	}
}
