using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace mxaddress.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class AddressController(
		IMediator mediator
	) : ControllerBase
	{
		[HttpGet]
		public Task<IActionResult> GetAsync()
		{
			return Task.FromResult<IActionResult>(Ok("Hello World"));
		}
	}
}
