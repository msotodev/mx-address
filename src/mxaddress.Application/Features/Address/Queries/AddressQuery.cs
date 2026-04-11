using MediatR;
using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.Address.Queries
{
	public class AddressQuery
	{
		public record GetAllAddressQuery() : IRequest<IReadOnlyList<AddressResponseDto>>;
	}
}