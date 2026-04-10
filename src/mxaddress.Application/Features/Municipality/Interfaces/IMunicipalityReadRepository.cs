using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.Municipality.Interfaces
{
	public interface IMunicipalityReadRepository
	{
		Task<IReadOnlyList<MunicipalityResponseDto>> GetAllAsync();

		Task<IReadOnlyList<MunicipalityResponseDto>> GetByStateKeyAsync(string stateKey);

		Task<IReadOnlyList<MunicipalityResponseDto>> GetByStateNameAsync(string stateName);
	}
}