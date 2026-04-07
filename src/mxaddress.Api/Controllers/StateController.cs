using MediatR;
using Microsoft.AspNetCore.Mvc;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.States.Queries;

namespace mxaddress.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class StateController(
		IMediator mediator
	) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			IReadOnlyList<StateResponseDto> result = await mediator.Send(new GetAllStateQuery());

			return Ok(result);
		}
	}
}