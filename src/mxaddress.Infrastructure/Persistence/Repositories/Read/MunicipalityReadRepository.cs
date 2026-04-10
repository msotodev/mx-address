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
		private const string QUERY_ALL = @"SELECT M.Id, M.Key, M.Name,
			M.StateId, S.Name AS StateName
		FROM Municipality M
			INNER JOIN State S ON S.Id = M.StateId";

		private static string QUERY_BY_STATE_ID => $"{QUERY_ALL}\nWHERE S.Key = LIKE '%?%'";

		private static string QUERY_BY_STATE_NAME => $"{QUERY_ALL}\nWHERE S.Name LIKE '%?%'";

		public Task<IReadOnlyList<MunicipalityResponseDto>> GetAllAsync()
		{
			IReadOnlyList<MunicipalityResponseDto> result = queryDatabase.Query<MunicipalityResponseDto>(
				QUERY_ALL
			);

			return Task.FromResult(result);
		}

		public Task<IReadOnlyList<MunicipalityResponseDto>> GetByStateKeyAsync(string stateKey)
		{
			IReadOnlyList<MunicipalityResponseDto> result = queryDatabase.Query<MunicipalityResponseDto>(
				QUERY_BY_STATE_ID, stateKey
			);

			return Task.FromResult(result);
		}

		public Task<IReadOnlyList<MunicipalityResponseDto>> GetByStateNameAsync(string stateName)
		{
			IReadOnlyList<MunicipalityResponseDto> result = queryDatabase.Query<MunicipalityResponseDto>(
				QUERY_BY_STATE_NAME, stateName
			);

			return Task.FromResult(result);
		}
	}
}