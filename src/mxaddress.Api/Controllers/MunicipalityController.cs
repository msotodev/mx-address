using MediatR;
using Microsoft.AspNetCore.Mvc;
using mxaddress.Application.Dtos;
using static mxaddress.Application.Features.Municipality.Queries.MunicipalityQuery;

namespace mxaddress.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class MunicipalityController(
		IMediator mediator
	) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			IReadOnlyList<MunicipalityResponseDto> result = await mediator.Send(new GetAllMunicipalityQuery());

			return Ok(result);
		}
	}
}