using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.ZipCodes.Interfaces
{
	public interface IZipCodeReadRepository
	{
		Task<IReadOnlyList<ZipCodeResponseDto>> GetAllAsync();

		Task<ZipCodeResponseDto?> GetByCodeAsync(string code);
	}
}