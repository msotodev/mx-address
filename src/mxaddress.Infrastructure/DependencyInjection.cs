using EssentialLayer.SQLite;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Abstractions;
using mxaddress.Application.Features.City.Interfaces;
using mxaddress.Application.Features.Municipality.Interfaces;
using mxaddress.Application.Features.States.Interfaces;
using mxaddress.Application.Features.ZipCodes.Interfaces;
using mxaddress.Infrastructure.Persistence.Initialization;
using mxaddress.Infrastructure.Persistence.Repositories.Read;
using mxaddress.Infrastructure.Persistence.Repositories.Write;
using mxaddress.Infrastructure.Services;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services
		)
		{
			string resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

			services.AddSQLiteInstance(
				LOCAL_DB,
				databasePathFactory: provider => Path.Combine(resourcesPath, $"{LOCAL_DB}.db3")
			);

			services.AddScoped<IDeviceInfo, DeviceInfoService>();

			services.AddScoped<DatabaseInitializer>();
			services.AddScoped<IAddressFileParser, TxtAddressFileParser>();

			services.AddScoped<ICityReadRepository, CityReadRepository>();
			services.AddScoped<IMunicipalityReadRepository, MunicipalityReadRepository>();
			services.AddScoped<IStateReadRepository, StateReadRepository>();
			services.AddScoped<IZipCodeReadRepository, ZipCodeReadRepository>();

			services.AddScoped<IZipCodeBaseWriteRepository, ZipCodeBaseWriteRepository>();

			return services;
		}
	}
}