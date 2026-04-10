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

		[HttpGet("{stateKey}")]
		public async Task<IActionResult> GetByStateKey(string stateKey)
		{
			IReadOnlyList<MunicipalityResponseDto> result = await mediator.Send(new GetAllByKeyMunicipalityQuery(stateKey));

			return Ok(result);
		}

		[HttpGet("state/{stateName}")]
		public async Task<IActionResult> GetByStateName(string stateName)
		{
			IReadOnlyList<MunicipalityResponseDto> result = await mediator.Send(new GetAllByNameMunicipalityQuery(stateName));

			return Ok(result);
		}
	}
}