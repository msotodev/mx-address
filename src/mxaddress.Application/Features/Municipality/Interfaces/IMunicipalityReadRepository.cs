using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.Municipality.Interfaces
{
	public interface IMunicipalityReadRepository
	{
		Task<IReadOnlyList<MunicipalityResponseDto>> GetAllAsync();

		Task<MunicipalityResponseDto?> GetByNameAsync(string name);
	}
}