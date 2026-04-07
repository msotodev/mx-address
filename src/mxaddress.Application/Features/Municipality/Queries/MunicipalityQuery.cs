using MediatR;
using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.Municipality.Queries
{
	public sealed class MunicipalityQuery
	{
		public record GetAllMunicipalityQuery() : IRequest<IReadOnlyList<MunicipalityResponseDto>>;
	}
}