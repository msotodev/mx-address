using EssentialLayer.SQLite.Interfaces;
using EssentialLayers.Helpers.Extension;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Abstractions;
using mxaddress.Domain.Entities;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Initialization
{
	internal class DatabaseInitializer(
		[FromKeyedServices(LOCAL_DB)] IDatabaseService databaseService,
		IDeviceInfo deviceInfo
	)
	{
		public Task InitializeAsync()
		{
			databaseService.Reset();

			Drop();
			Create();

			return InitialValuesAsync();
		}

		private void Create()
		{
			databaseService.Create<CapitalState>();
			databaseService.Create<Municipality>();
			databaseService.Create<Settlement>();
			databaseService.Create<SettlementType>();
			databaseService.Create<State>();
			databaseService.Create<ZipCode>();
			databaseService.Create<ZipCodeBase>();
		}

		private void Drop()
		{
			databaseService.Drop<CapitalState>();
			databaseService.Drop<Municipality>();
			databaseService.Drop<Settlement>();
			databaseService.Drop<SettlementType>();
			databaseService.Drop<State>();
			databaseService.Drop<ZipCode>();
			databaseService.Drop<ZipCodeBase>();
		}

		private async Task InitialValuesAsync()
		{
			await SetStatesAsync();
			await SetCapitalsAsync();
		}

		private async Task SetStatesAsync()
		{
			string text = await File.ReadAllTextAsync(deviceInfo.StatesPath);

			IReadOnlyList<State>? values = text.Deserialize<IReadOnlyList<State>>();

			if (values == null) return;

			databaseService.BulkInsert(values);
		}

		private async Task SetCapitalsAsync()
		{
			string text = await File.ReadAllTextAsync(deviceInfo.CapitalsPath);

			IReadOnlyList<CapitalState>? values = text.Deserialize<IReadOnlyList<CapitalState>>();

			if (values == null) return;

			databaseService.BulkInsert(values);
		}
	}
}