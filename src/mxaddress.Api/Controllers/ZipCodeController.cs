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
		/// <summary>
		/// Information about the source of the data:
		/// Base Url: https://www.correosdemexico.gob.mx/SSLServicios/ConsultaCP/CodigoPostal_Exportar.aspx
		/// Text plain URL: https://www.correosdemexico.gob.mx/datosabiertos/cp/cpdescarga.txt
		/// </summary>
		/// <returns></returns>

		[HttpGet]
		public async Task<IActionResult> GetAllAsync() => Ok(
			await mediator.Send(new GetAllZipCodeQuery())
		);

		[HttpGet("{code}")]
		public async Task<IActionResult> GetAsync(string code)
		{
			IReadOnlyList<ZipCodeResponseDto> result = await mediator.Send(new GetZipCodeQuery(code));

			return Ok(result);
		}

		[HttpPost("Import/txt")]
		public async Task<IActionResult> ImportFromTextPlain(IFormFile file)
		{
			if (file == null || file.Length == 0) return BadRequest("File is required");

			Response result = await mediator.Send(
				new ImportZipCodeBaseCommand(file.OpenReadStream())
			);

			return Ok(result);
		}
	}
}