using EssentialLayer.SQLite.Interfaces;
using EssentialLayers.Helpers.Result;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Features.ZipCodes.Interfaces;
using mxaddress.Domain.Entities;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Repositories.Write
{
	internal class ZipCodeWriteRepository(
		[FromKeyedServices(LOCAL_DB)] IDatabaseService database
	) : IZipCodeWriteRepository
	{
		public Task<Response> ImportAsync(
			IReadOnlyList<ZipCode> data
		) => Task.FromResult(database.BulkInsert(data));
	}
}