using MediatR;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.ZipCodes.Interfaces;
using static mxaddress.Application.Features.ZipCodes.Queries.GetZipCode.ZipCodeQuery;

namespace mxaddress.Application.Features.ZipCodes.Queries.GetZipCode
{
	public class GetAllZipCodeHandler(
		IZipCodeReadRepository repository
	) : IRequestHandler<GetAllZipCodeQuery, IReadOnlyList<ZipCodeResponseDto>>
	{
		public Task<IReadOnlyList<ZipCodeResponseDto>> Handle(
			GetAllZipCodeQuery request, CancellationToken cancellationToken
		) => repository.GetAllAsync();
	}
}
