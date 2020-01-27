using AutoMapper;
using DroneLocationTracker.Data;
using DroneLocationTracker.Data.Models;
using DroneLocationTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DroneLocationTracker.Controllers.Drones
{
	[Route("api/drones")]
	[AllowAnonymous]
	public class DroneController : Controller
	{
		private readonly Context _context;
		private readonly IMapper _mapper;

		private readonly IDroneLastLocationService _droneLastLocationService = new DroneLastLocationService();

		public DroneController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		private class DroneControllerProfile : Profile
		{
			public DroneControllerProfile()
			{
				CreateMap<Drone, DroneDto>(MemberList.Destination)
					.ForMember(x => x.LastLocation, o => o.Ignore()); // Manually mapped.
			}
		}

		/// <summary>
		/// List all drones.
		/// </summary>
		[HttpGet("v1")]
		[ProducesResponseType(typeof(DroneDto[]), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> List()
		{
			// Fetch all drones.
			// Don't use ProjectTo here as it will ignore our AfterMap for last location information.
			var drones = await _context.Drones
				.Include(x => x.LastLocation)
				.Select(x => _mapper.Map<DroneDto>(x))
				.ToArrayAsync();

			// Populate dummy location information.
			for (int i = 0; i < drones.Length; i++)
			{
				// Make some drones offline and stale so we get a range of statuses to display.
				if (i == 2)
				{
					drones[i].LastLocation = _droneLastLocationService.GetLastLocation(DroneLastLocationServiceStatus.Stale);
					continue;
				}

				if (i == drones.Length - 1)
				{
					drones[i].LastLocation = _droneLastLocationService.GetLastLocation(DroneLastLocationServiceStatus.Offline);
					continue;
				}

				drones[i].LastLocation = _droneLastLocationService.GetLastLocation(DroneLastLocationServiceStatus.Online);
			}

			return Ok(drones);
		}
	}
}
