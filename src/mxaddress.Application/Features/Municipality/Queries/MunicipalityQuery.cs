using MediatR;
using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.Municipality.Queries
{
	public sealed class MunicipalityQuery
	{
		public record GetAllMunicipalityQuery() : IRequest<IReadOnlyList<MunicipalityResponseDto>>;

		public record GetAllByKeyMunicipalityQuery(string Key) : IRequest<IReadOnlyList<MunicipalityResponseDto>>;
		
		public record GetAllByNameMunicipalityQuery(string Name) : IRequest<IReadOnlyList<MunicipalityResponseDto>>;
	}
}