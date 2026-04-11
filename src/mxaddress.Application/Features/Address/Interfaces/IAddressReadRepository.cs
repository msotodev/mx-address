using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.Address.Interfaces
{
	public interface IAddressReadRepository
	{
		Task<IReadOnlyList<AddressResponseDto>> GetAllAsync();
	}
}