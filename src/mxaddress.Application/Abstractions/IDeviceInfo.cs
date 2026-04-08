namespace mxaddress.Application.Abstractions
{
	public interface IDeviceInfo
	{
		string ResourcesPath { get; }

		string StatesPath { get; }

		string CapitalsPath { get; }
	}
}