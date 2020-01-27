using DroneLocationTracker.Controllers.Locations;
using System;

namespace DroneLocationTracker.Services
{
	public interface IDroneLastLocationService
	{
		/// <summary>
		/// Get dummy last location data.
		/// </summary>
		LocationDto GetLastLocation(DroneLastLocationServiceStatus status);
	}

	public class DroneLastLocationService : IDroneLastLocationService
	{
		private readonly Random _random;

		public DroneLastLocationService()
		{
			_random = new Random();
		}

		/// <inheritdoc />
		public LocationDto GetLastLocation(DroneLastLocationServiceStatus status)
		{
			var (Timestamp, Speed) = GetMovement(status);

			return new LocationDto()
			{
				Latitude = Math.Round(NextDouble(-90, 90), 6),
				Longitude = Math.Round(NextDouble(-180, 180), 6),
				Timestamp = Timestamp,
				Speed = Speed,
			};
		}

		/// <summary>
		/// Returns a random double betweeen the given min and max (inclusive).
		/// </summary>
		private double NextDouble(double min, double max)
		{
			return _random.NextDouble() * (max - min) + min;
		}

		private (DateTimeOffset Timestamp, double Speed) GetMovement(DroneLastLocationServiceStatus status)
		{
			var numberOfSecondsToSubtract = _random.Next(0, 10);
			var timestamp = DateTimeOffset.UtcNow.AddSeconds(numberOfSecondsToSubtract * -1);

			if (status == DroneLastLocationServiceStatus.Online)
				return (timestamp, NextDouble(5, 15));

			if (status == DroneLastLocationServiceStatus.Stale)
				return (timestamp, NextDouble(0.1, 1.5));

			// Offline.
			return (DateTimeOffset.UtcNow.AddSeconds(_random.Next(500, 5000) * -1), 0);
		}
	}

	public enum DroneLastLocationServiceStatus
	{
		Online,
		Offline,
		Stale,
	}
}
