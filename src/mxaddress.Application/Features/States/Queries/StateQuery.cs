using MediatR;
using mxaddress.Application.Dtos;

namespace mxaddress.Application.Features.States.Queries
{
	public record GetAllStateQuery() : IRequest<IReadOnlyList<StateResponseDto>>;
}