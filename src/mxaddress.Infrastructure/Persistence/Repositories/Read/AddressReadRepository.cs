using EssentialLayer.SQLite.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.Address.Interfaces;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Repositories.Read
{
	internal class AddressReadRepository(
		[FromKeyedServices(LOCAL_DB)] IQueryDatabaseService queryDatabase
	) : IAddressReadRepository
	{
		private const string QUERY_ALL = $@"SELECT ZC.Code AS ZipCode, SE.Name AS SettlementName, ST.Name SettlementTypeName,
			S.Name AS StateName, M.Name AS MunicipalityName, C.Name AS CityName,
			CASE WHEN ZC.IsUrban = 1 THEN 'Urbano' ELSE 'Rural' END AS Zone
		FROM ZipCode ZC
			INNER JOIN State S ON S.Id = ZC.StateId
			INNER JOIN Municipality M ON M.Id = ZC.MunicipalityId
			INNER JOIN Settlement SE ON SE.Id = ZC.SettlementId
			INNER JOIN SettlementType ST ON ST.Id = SE.SettlementTypeId
			INNER JOIN City C ON C.Id = ZC.CityId";

		public Task<IReadOnlyList<AddressResponseDto>> GetAllAsync()
		{
			IReadOnlyList<AddressResponseDto> result = queryDatabase.Query<AddressResponseDto>(QUERY_ALL);

			return Task.FromResult(result);
		}
	}
}