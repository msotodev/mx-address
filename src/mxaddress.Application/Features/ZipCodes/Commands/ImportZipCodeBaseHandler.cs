using EssentialLayers.Helpers.Result;
using MediatR;
using mxaddress.Application.Abstractions;
using mxaddress.Application.Features.ZipCodes.Interfaces;
using mxaddress.Domain.Entities;
using static mxaddress.Application.Features.ZipCodes.Commands.ImportZipCodesCommands;

namespace mxaddress.Application.Features.ZipCodes.Commands
{
	public class ImportZipCodeBaseHandler(
		IAddressFileParser addressFileParser,
		IZipCodeBaseWriteRepository zipCodeWriteRepository
	) : IRequestHandler<ImportZipCodeBaseCommand, Response>
	{
		public async Task<Response> Handle(ImportZipCodeBaseCommand request, CancellationToken cancellationToken)
		{
            List<ZipCodeBase> records = await addressFileParser.ParseAsync(request.stream).ToListAsync(cancellationToken);

			return await zipCodeWriteRepository.ImportAsync(records);
		}
	}
}