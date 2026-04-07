using MediatR;
using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.ZipCodes.Queries.GetZipCode
{
	public sealed class ZipCodeQuery
	{
		public record GetZipCodeQuery(string code) : IRequest<ZipCodeResponseDto>;

		public record GetAllZipCodeQuery() : IRequest<IReadOnlyList<ZipCodeResponseDto>>;
	}
}