using EssentialLayer.SQLite.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.Municipality.Interfaces;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Repositories.Read
{
	internal class MunicipalityReadRepository(
		[FromKeyedServices(LOCAL_DB)] IQueryDatabaseService queryDatabase
	) : IMunicipalityReadRepository
	{
		private const string EntityName = "Municipality";

		public Task<IReadOnlyList<MunicipalityResponseDto>> GetAllAsync()
		{
			IReadOnlyList<MunicipalityResponseDto> result = queryDatabase.Query<MunicipalityResponseDto>(
				$@"SELECT Id, Name, Abbreviation, Mnemonic FROM {EntityName}"
			);

			return Task.FromResult(result);
		}

		public Task<MunicipalityResponseDto?> GetByNameAsync(string name)
		{
			MunicipalityResponseDto? first = queryDatabase.QueryFirst<MunicipalityResponseDto>(
				$@"SELECT * FROM {EntityName}", name
			);

			return Task.FromResult(first);
		}
	}
}