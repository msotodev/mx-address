using EssentialLayer.SQLite.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Domain.Entities;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Initialization
{
	internal class DatabaseInitializer(
		[FromKeyedServices(LOCAL_DB)] IDatabaseService databaseService
	)
	{
		public async Task InitializeAsync()
		{
			Drop();
			Create();
		}

		private void Create()
		{
			databaseService.Create<Locality>();
			databaseService.Create<Municipality>();
			databaseService.Create<State>();
			databaseService.Create<Settlement>();
			databaseService.Create<ZipCode>();
		}

		private void Drop()
		{
			databaseService.Drop<Locality>();
			databaseService.Drop<Municipality>();
			databaseService.Drop<State>();
			databaseService.Drop<Settlement>();
			databaseService.Drop<ZipCode>();
		}
	}
}