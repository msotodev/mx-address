using mxaddress.Application.Abstractions;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Services
{
	public class DeviceInfoService : IDeviceInfo
	{
		public string CapitalsPath => Path.Combine(ResourcesPath, "capitals.json");

		public string DatabasePath => Path.Combine(ResourcesPath, $"{LOCAL_DB}.db3");

		public string ResourcesPath => Path.Combine(Directory.GetCurrentDirectory(), "Resources");

		public string EntitiesScriptPath => GetScriptsPath("EntitiesCreationScript.sql");

		public string RelationalMappingScriptPath => GetScriptsPath("RelationalMapping.sql");

		public string StatesPath => Path.Combine(ResourcesPath, "states.json");

		private static string GetScriptsPath(string filename)
		{
			string srcPaht = string.Join("\\", Directory.GetCurrentDirectory().Split("\\").SkipLast(1));

			return Path.Combine(srcPaht, "Database", "Scripts", filename);
		}
	}
}