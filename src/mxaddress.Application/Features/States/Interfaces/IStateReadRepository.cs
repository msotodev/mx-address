using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.States.Interfaces
{
	public interface IStateReadRepository
	{
		Task<IReadOnlyList<StateResponseDto>> GetAllAsync();

		Task<StateResponseDto?> GetByNameAsync(string name);
	}
}