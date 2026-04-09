using MediatR;
using Microsoft.AspNetCore.Mvc;
using mxaddress.Application.Dtos;
using static mxaddress.Application.Features.City.Queries.CityQuery;

namespace mxaddress.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CityController(
		IMediator mediator
	) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			IReadOnlyList<CityResponseDto> result = await mediator.Send(new GetAllCityQuery());

			return Ok(result);
		}
	}
}