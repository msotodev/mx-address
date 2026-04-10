namespace mxaddress.Application.Abstractions
{
	public interface IDeviceInfo
	{
		string CapitalsPath { get; }

		string ResourcesPath { get; }

		string EntitiesScriptPath { get; }

		string RelationalMappingScriptPath { get; }

		string StatesPath { get; }
	}
}