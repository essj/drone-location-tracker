﻿using DroneLocationTracker.Controllers.Locations;
using DroneLocationTracker.Data.Models;
using System;

namespace DroneLocationTracker.Services
{
	public interface IDroneLastLocationService
	{
		/// <summary>
		/// Get dummy last location data.
		/// </summary>
		LocationDto GetLastLocation();
	}

	public class DroneLastLocationService : IDroneLastLocationService
	{
		private readonly Random _random;

		public DroneLastLocationService()
		{
			_random = new Random();
		}

		/// <inheritdoc />
		public LocationDto GetLastLocation()
		{
			return new LocationDto()
			{
				Latitude = Math.Round(NextDouble(-90, 90), 6),
				Longitude = Math.Round(NextDouble(-180, 180), 6),
				Timestamp = DateTimeOffset.UtcNow,
			};
		}

		private double NextDouble(double min, double max)
		{
			return _random.NextDouble() * (max - min) + min;
		}
	}
}
