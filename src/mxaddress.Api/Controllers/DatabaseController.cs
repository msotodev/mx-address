using Microsoft.AspNetCore.Mvc;
using mxaddress.Application.Abstractions;

namespace mxaddress.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class DatabaseController(
		IDatabaseStartupScript databaseStartup
	) : ControllerBase
	{
		[HttpGet("sqlite")]
		public async Task<IActionResult> GetAsync()
		{
			string[] entitiesScripts = await databaseStartup.EntitiesScriptAsync();
			string zipCodeBaseScript = await databaseStartup.ZipCodeBaseScript();
			string[] mappingScripts = await databaseStartup.MappingScriptsAsync();
			string[] results = [.. entitiesScripts, "\n\n", zipCodeBaseScript, "\n\n", .. mappingScripts];

			string content = string.Join(string.Empty, results);

			return Content(content, "text/html");
		}
	}
}