using EssentialLayers.Helpers.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using mxaddress.Application.Dtos;
using static mxaddress.Application.Features.ZipCodes.Commands.ImportZipCodesCommands;
using static mxaddress.Application.Features.ZipCodes.Queries.GetZipCode.ZipCodeQuery;

namespace mxaddress.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ZipCodeController(
		IMediator mediator
	) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllAsync() => Ok(
			await mediator.Send(new GetAllZipCodeQuery())
		);

		[HttpGet("{code}")]
		public async Task<IActionResult> GetAsync(string code)
		{
			ZipCodeResponseDto result = await mediator.Send(new GetZipCodeQuery(code));

			return Ok(result);
		}

		[HttpPost("Import/txt")]
		public async Task<IActionResult> ImportFromTextPlain(IFormFile file)
		{
			if (file == null || file.Length == 0) return BadRequest("File is required");

			Response result = await mediator.Send(
				new ImportZipCodesCommand(file.OpenReadStream())
			);

			return Ok(result);
		}
	}
}