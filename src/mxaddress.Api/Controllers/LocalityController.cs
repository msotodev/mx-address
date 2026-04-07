using MediatR;
using Microsoft.AspNetCore.Mvc;
using mxaddress.Application.Dtos;
using static mxaddress.Application.Features.Locality.Queries.LocalityQuery;

namespace mxaddress.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class LocalityController(
		IMediator mediator
	) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			IReadOnlyList<LocalityResponseDto> result = await mediator.Send(new GetAllLocalityQuery());

			return Ok(result);
		}
	}
}