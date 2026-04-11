using MediatR;
using Microsoft.AspNetCore.Mvc;
using mxaddress.Application.Dtos;
using static mxaddress.Application.Features.Address.Queries.AddressQuery;

namespace mxaddress.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AddressController(
		IMediator mediator
	) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			IReadOnlyList<AddressResponseDto> result = await mediator.Send(new GetAllAddressQuery());

			return Ok(result);
		}
	}
}