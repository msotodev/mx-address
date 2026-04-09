using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.City.Interfaces
{
	public interface ICityReadRepository
	{
		Task<IReadOnlyList<CityResponseDto>> GetAllAsync();

		Task<CityResponseDto?> GetByNameAsync(string name);
	}
}