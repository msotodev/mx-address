using MediatR;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.City.Interfaces;
using static mxaddress.Application.Features.City.Queries.CityQuery;

namespace mxaddress.Application.Features.City.Queries
{
	public class GetCityHandler(
		ICityReadRepository readRepository
	) : IRequestHandler<GetAllCityQuery, IReadOnlyList<CityResponseDto>>
	{
		public Task<IReadOnlyList<CityResponseDto>> Handle(
			GetAllCityQuery request, CancellationToken cancellationToken
		) => readRepository.GetAllAsync();
	}
}