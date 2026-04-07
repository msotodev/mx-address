using EssentialLayers.Helpers.Result;
using MediatR;
using mxaddress.Application.Abstractions;
using mxaddress.Application.Features.ZipCodes.Interfaces;
using mxaddress.Domain.Entities;
using static mxaddress.Application.Features.ZipCodes.Commands.ImportZipCodesCommands;

namespace mxaddress.Application.Features.ZipCodes.Commands
{
	public class ImportZipCodesHandler(
		IAddressFileParser addressFileParser,
		IZipCodeWriteRepository zipCodeWriteRepository
	) : IRequestHandler<ImportZipCodesCommand, Response>
	{
		public async Task<Response> Handle(ImportZipCodesCommand request, CancellationToken cancellationToken)
		{
            List<ZipCode> records = await addressFileParser.ParseAsync(request.stream).ToListAsync(cancellationToken);

			return await zipCodeWriteRepository.ImportAsync(records);
		}
	}
}