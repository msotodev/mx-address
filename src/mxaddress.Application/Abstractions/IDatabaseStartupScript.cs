using mxaddress.Domain.Entities;

namespace mxaddress.Application.Abstractions
{
	public interface IDatabaseStartupScript
	{
		Task<List<CapitalState>> GetCapitalStateAsync();

		Task<string[]> EntitiesScriptAsync();

		Task<string[]> MappingScriptsAsync();

		Task<List<State>> GetStateAsync();

		Task<List<ZipCodeBase>> GetZipCodeBaseAsync();

		Task<string> ZipCodeBaseScript();
	}
}