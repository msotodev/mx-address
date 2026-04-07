using MediatR;
using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.Locality.Queries
{
	public sealed class LocalityQuery
	{
		public record GetAllLocalityQuery() : IRequest<IReadOnlyList<LocalityResponseDto>>;
	}
}