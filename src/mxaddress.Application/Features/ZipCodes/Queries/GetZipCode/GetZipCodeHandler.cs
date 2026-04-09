using MediatR;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.ZipCodes.Interfaces;
using static mxaddress.Application.Features.ZipCodes.Queries.GetZipCode.ZipCodeQuery;

namespace mxaddress.Application.Features.ZipCodes.Queries.GetZipCode
{
	public class GetZipCodeHandler(
		IZipCodeReadRepository repository
	) : IRequestHandler<GetZipCodeQuery, IReadOnlyList<ZipCodeResponseDto>>
	{
		public Task<IReadOnlyList<ZipCodeResponseDto>> Handle(GetZipCodeQuery request, CancellationToken cancellationToken)
		{
			return repository.GetByCodeAsync(request.code);
		}
	}
}