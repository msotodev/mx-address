using EssentialLayers.Helpers.Result;
using MediatR;

namespace mxaddress.Application.Features.ZipCodes.Commands
{
	public class ImportZipCodesCommands
	{
		public record ImportZipCodeBaseCommand(Stream stream) : IRequest<Response>;
	}
}