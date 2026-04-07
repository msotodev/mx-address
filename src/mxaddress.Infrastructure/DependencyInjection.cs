using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Abstractions;
using mxaddress.Application.Features.Locality.Interfaces;
using mxaddress.Application.Features.Municipality.Interfaces;
using mxaddress.Application.Features.States.Interfaces;
using mxaddress.Application.Features.ZipCodes.Interfaces;
using mxaddress.Infrastructure.FileParsing;
using mxaddress.Infrastructure.Persistence.Initialization;
using mxaddress.Infrastructure.Persistence.Repositories.Read;
using mxaddress.Infrastructure.Persistence.Repositories.Write;

namespace mxaddress.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddScoped<DatabaseInitializer>();
			services.AddScoped<IAddressFileParser, TxtAddressFileParser>();

			services.AddScoped<ILocalityReadRepository, LocalityReadRepository>();
			services.AddScoped<IMunicipalityReadRepository, MunicipalityReadRepository>();
			services.AddScoped<IStateReadRepository, StateReadRepository>();
			services.AddScoped<IZipCodeReadRepository, ZipCodeReadRepository>();

			services.AddScoped<IZipCodeWriteRepository, ZipCodeWriteRepository>();

			return services;
		}
	}
}