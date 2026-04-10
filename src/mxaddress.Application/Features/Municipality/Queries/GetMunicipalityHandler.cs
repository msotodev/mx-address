using MediatR;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.Municipality.Interfaces;
using static mxaddress.Application.Features.Municipality.Queries.MunicipalityQuery;

namespace mxaddress.Application.Features.Municipality.Queries
{
	public class GetMunicipalityHandler(
		IMunicipalityReadRepository readRepository
	) : IRequestHandler<GetAllMunicipalityQuery, IReadOnlyList<MunicipalityResponseDto>>
	{
		public Task<IReadOnlyList<MunicipalityResponseDto>> Handle(
			GetAllMunicipalityQuery request, CancellationToken cancellationToken
		) => readRepository.GetAllAsync();

		public Task<IReadOnlyList<MunicipalityResponseDto>> Handle(
			GetAllByKeyMunicipalityQuery request, CancellationToken cancellationToken
		) => readRepository.GetByStateKeyAsync(request.Key);

		public Task<IReadOnlyList<MunicipalityResponseDto>> Handle(
			GetAllByNameMunicipalityQuery request, CancellationToken cancellationToken
		) => readRepository.GetByStateNameAsync(request.Name);
	}
}