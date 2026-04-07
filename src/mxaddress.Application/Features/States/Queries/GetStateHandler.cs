using MediatR;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.States.Interfaces;

namespace mxaddress.Application.Features.States.Queries
{
	public class GetStateHandler(
		IStateReadRepository readRepository
	) : IRequestHandler<GetAllStateQuery, IReadOnlyList<StateResponseDto>>
	{
		public Task<IReadOnlyList<StateResponseDto>> Handle(
			GetAllStateQuery request, CancellationToken cancellationToken
		) => readRepository.GetAllAsync();
	}
}