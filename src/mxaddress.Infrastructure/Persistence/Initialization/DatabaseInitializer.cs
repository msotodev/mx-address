using EssentialLayer.SQLite.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Abstractions;
using mxaddress.Domain.Entities;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Initialization
{
	internal class DatabaseInitializer(
		[FromKeyedServices(LOCAL_DB)] IDatabaseService databaseService,
		IDatabaseStartupScript databaseStartup
	) : IDatabaseInitializer
	{
		public async Task InitializeAsync()
		{
			await CreateEntitiesAsync();

			await SetStatesAsync();
			await SetCapitalsAsync();
			await SetZipCodeBase();

			await RelationalMappingAsync();
		}

		private async Task CreateEntitiesAsync()
		{
			string[] scripts = await databaseStartup.EntitiesScriptAsync();

			foreach (string script in scripts)
			{
				databaseService.Execute(script);
			}
		}

		private async Task RelationalMappingAsync()
		{
			string[] scripts = await databaseStartup.MappingScriptsAsync();

			foreach (string script in scripts)
			{
				databaseService.Execute(script);
			}
		}

		private async Task SetStatesAsync()
		{
			List<State> records = await databaseStartup.GetStateAsync();

			databaseService.BulkInsert(records);
		}

		private async Task SetCapitalsAsync()
		{
			List<CapitalState> records = await databaseStartup.GetCapitalStateAsync();

			databaseService.BulkInsert(records);
		}

		private async Task SetZipCodeBase()
		{
			List<ZipCodeBase> records = await databaseStartup.GetZipCodeBaseAsync();

			databaseService.BulkInsert(records);
		}
	}
}