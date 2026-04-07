using EssentialLayers.Helpers.Result;
using mxaddress.Domain.Entities;

namespace mxaddress.Application.Features.ZipCodes.Interfaces
{
	public interface IZipCodeWriteRepository
	{
		Task<Response> ImportAsync(IReadOnlyList<ZipCode> data);
	}
}