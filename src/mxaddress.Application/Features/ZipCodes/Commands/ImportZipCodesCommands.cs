using EssentialLayers.Helpers.Result;
using MediatR;

namespace mxaddress.Application.Features.ZipCodes.Commands
{
	public class ImportZipCodesCommands
	{
		public record ImportZipCodesCommand(Stream stream) : IRequest<Response>;
	}
}