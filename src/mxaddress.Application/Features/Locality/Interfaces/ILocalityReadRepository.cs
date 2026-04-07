using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.Locality.Interfaces
{
	public interface ILocalityReadRepository
	{
		Task<IReadOnlyList<LocalityResponseDto>> GetAllAsync();

		Task<LocalityResponseDto?> GetByNameAsync(string name);
	}
}