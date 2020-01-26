using AutoMapper;
using DroneLocationTracker.Data;
using DroneLocationTracker.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DroneLocationTracker.Controllers.Locations
{
	[Route("api/locations")]
	[AllowAnonymous]
	public class LocationController : Controller
	{
		private readonly Context _context;
		private readonly IMapper _mapper;

		public LocationController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		private class LocationControllerProfile : Profile
		{
			public LocationControllerProfile()
			{
				CreateMap<LocationRequest, Location>(MemberList.Destination)
					.ForMember(x => x.LocationId, o => o.Ignore())
					.ForMember(x => x.Drone, o => o.Ignore())
					.ForMember(x => x.Timestamp, o => o.MapFrom(x => DateTimeOffset.UtcNow));
			}
		}

		/// <summary>
		/// Send a location from a drone.
		/// </summary>
		[HttpPost("v1/send")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public async Task<IActionResult> SendLocation([FromBody] LocationRequest request)
		{
			var drone = await _context.Drones
				.SingleOrDefaultAsync(x => x.DroneId == request.DroneId);

			if (drone == null)
				return Forbid();

			var location = _mapper.Map<Location>(request);

			_context.Add(location);

			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}
