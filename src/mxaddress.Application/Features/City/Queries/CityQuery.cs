using MediatR;
using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.City.Queries
{
	public sealed class CityQuery
	{
		public record GetAllCityQuery() : IRequest<IReadOnlyList<CityResponseDto>>;
	}
}