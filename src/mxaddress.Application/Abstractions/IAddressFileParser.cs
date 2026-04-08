using mxaddress.Domain.Entities;

namespace mxaddress.Application.Abstractions
{
	public interface IAddressFileParser
	{
		IAsyncEnumerable<ZipCodeBase> ParseAsync(Stream stream);
	}
}