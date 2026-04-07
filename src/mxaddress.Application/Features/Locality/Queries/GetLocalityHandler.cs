using MediatR;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.Locality.Interfaces;
using static mxaddress.Application.Features.Locality.Queries.LocalityQuery;

namespace mxaddress.Application.Features.Locality.Queries
{
	public class GetLocalityHandler(
		ILocalityReadRepository readRepository
	) : IRequestHandler<GetAllLocalityQuery, IReadOnlyList<LocalityResponseDto>>
	{
		public Task<IReadOnlyList<LocalityResponseDto>> Handle(
			GetAllLocalityQuery request, CancellationToken cancellationToken
		) => readRepository.GetAllAsync();
	}
}