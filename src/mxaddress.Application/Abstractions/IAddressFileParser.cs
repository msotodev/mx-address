using mxaddress.Domain.Entities;

namespace mxaddress.Application.Abstractions
{
	public interface IAddressFileParser
	{
		IAsyncEnumerable<ZipCode> ParseAsync(Stream stream);
	}
}