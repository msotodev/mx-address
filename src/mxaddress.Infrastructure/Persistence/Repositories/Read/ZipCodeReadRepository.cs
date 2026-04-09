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
		private const string QUERY_ALL = $@"SELECT ZC.Code, ZC.StateId, S.Name AS StateName,
			ZC.MunicipalityId, M.Name AS MunicipalityName, ZC.SettlementId, SE.Name AS SettlementName,
			ZC.CityId, C.Name AS CityName, CASE WHEN ZC.IsUrban = 1 THEN 'Urbano' ELSE 'Rural' END AS Zone
		FROM ZipCode ZC
			INNER JOIN State S ON S.Id = ZC.StateId
			INNER JOIN Municipality M ON M.Id = ZC.MunicipalityId
			INNER JOIN Settlement SE ON SE.Id = ZC.SettlementId
			INNER JOIN City C ON C.Id = ZC.CityId";

		private static string QUERY_BY_CODE(string code) => $"{QUERY_ALL}\nWHERE Code LIKE '%{code}%'";

		public Task<IReadOnlyList<ZipCodeResponseDto>> GetAllAsync()
		{
			IReadOnlyList<ZipCodeResponseDto> result = queryDatabase.Query<ZipCodeResponseDto>(
				QUERY_ALL
			);

			return Task.FromResult(result);
		}

		public Task<IReadOnlyList<ZipCodeResponseDto>> GetByCodeAsync(string code)
		{
			IReadOnlyList<ZipCodeResponseDto> result = queryDatabase.Query<ZipCodeResponseDto>(
				QUERY_BY_CODE(code)
			);

			return Task.FromResult(result);
		}
	}
}