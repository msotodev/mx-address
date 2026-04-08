using EssentialLayers.Helpers.Result;
using mxaddress.Domain.Entities;

namespace mxaddress.Application.Features.ZipCodes.Interfaces
{
	public interface IZipCodeBaseWriteRepository
	{
		Task<Response> ImportAsync(IReadOnlyList<ZipCodeBase> data);
	}
}