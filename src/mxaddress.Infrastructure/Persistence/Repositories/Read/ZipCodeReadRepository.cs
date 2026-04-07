using EssentialLayer.SQLite.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.ZipCodes.Interfaces;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Repositories.Read
{
	internal class ZipCodeReadRepository(
		[FromKeyedServices(LOCAL_DB)] IQueryDatabaseService queryDatabase
	) : IZipCodeReadRepository
	{
		private const string EntityName = "ZipCode";

		public Task<IReadOnlyList<ZipCodeResponseDto>> GetAllAsync()
		{
			IReadOnlyList<ZipCodeResponseDto> response = queryDatabase.Query<ZipCodeResponseDto>(
				$@"SELECT Id, Code, StateName, MunicipalityName, LocalityName FROM {EntityName}"
			);

			return Task.FromResult(response);
		}

		public Task<ZipCodeResponseDto?> GetByCodeAsync(string code)
		{
			ZipCodeResponseDto? result = queryDatabase.QueryFirst<ZipCodeResponseDto>(
				$@"SELECT Id, Code, StateName, MunicipalityName, LocalityName
					FROM {EntityName}
				WHERE Code LIKE '%{code}%'"
			);

			return Task.FromResult(result);
		}
	}
}