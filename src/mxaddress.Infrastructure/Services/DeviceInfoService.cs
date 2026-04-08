using mxaddress.Application.Abstractions;

namespace mxaddress.Infrastructure.Services
{
	public class DeviceInfoService : IDeviceInfo
	{
		public string ResourcesPath => Path.Combine(Directory.GetCurrentDirectory(), "Resources");

		public string StatesPath => Path.Combine(ResourcesPath, "states.json");

		public string CapitalsPath => Path.Combine(ResourcesPath, "capitals.json");
	}
}