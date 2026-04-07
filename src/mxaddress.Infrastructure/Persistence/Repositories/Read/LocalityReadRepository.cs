using EssentialLayer.SQLite.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.Locality.Interfaces;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Repositories.Read
{
	internal class LocalityReadRepository(
		[FromKeyedServices(LOCAL_DB)] IQueryDatabaseService queryDatabase	
	) : ILocalityReadRepository
	{
		private const string EntityName = "Locality";

		public Task<IReadOnlyList<LocalityResponseDto>> GetAllAsync()
		{
			IReadOnlyList<LocalityResponseDto> result = queryDatabase.Query<LocalityResponseDto>(
				$@"SELECT Id, Name, Abbreviation, Mnemonic FROM {EntityName}"
			);

			return Task.FromResult(result);
		}

		public Task<LocalityResponseDto?> GetByNameAsync(string name)
		{
			LocalityResponseDto? first = queryDatabase.QueryFirst<LocalityResponseDto>(
				$@"SELECT * FROM {EntityName}", name
			);

			return Task.FromResult(first);
		}
	}
}