using EssentialLayer.SQLite.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.City.Interfaces;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Repositories.Read
{
	internal class CityReadRepository(
		[FromKeyedServices(LOCAL_DB)] IQueryDatabaseService queryDatabase	
	) : ICityReadRepository
	{
		private const string EntityName = "City";

		public Task<IReadOnlyList<CityResponseDto>> GetAllAsync()
		{
			IReadOnlyList<CityResponseDto> result = queryDatabase.Query<CityResponseDto>(
				$@"SELECT Id, Name FROM {EntityName}"
			);

			return Task.FromResult(result);
		}

		public Task<CityResponseDto?> GetByNameAsync(string name)
		{
			CityResponseDto? first = queryDatabase.QueryFirst<CityResponseDto>(
				$@"SELECT Id, Name FROM {EntityName}", name
			);

			return Task.FromResult(first);
		}
	}
}