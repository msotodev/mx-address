using MediatR;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.Address.Interfaces;
using static mxaddress.Application.Features.Address.Queries.AddressQuery;

namespace mxaddress.Application.Features.Address.Queries
{
	internal class GetAddressHandler(
		IAddressReadRepository readRepository
	) : IRequestHandler<GetAllAddressQuery, IReadOnlyList<AddressResponseDto>>
	{
		public Task<IReadOnlyList<AddressResponseDto>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
		{
			return readRepository.GetAllAsync();
		}
	}
}