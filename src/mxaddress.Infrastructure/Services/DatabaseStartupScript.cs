using EssentialLayers.Helpers.Extension;
using mxaddress.Application.Abstractions;
using mxaddress.Application.Dtos;
using mxaddress.Domain.Entities;
using System.Reflection;
using System.Text;

namespace mxaddress.Infrastructure.Services
{
	public class DatabaseStartupScript(
		IAddressFileParser addressFileParser,
		IDeviceInfo deviceInfo
	) : IDatabaseStartupScript
	{
		private readonly HttpClient _httpClient = new();

		public async Task<List<CapitalState>> GetCapitalStateAsync()
		{
			string text = await File.ReadAllTextAsync(deviceInfo.CapitalsPath);

			IReadOnlyList<CapitalState>? values = text.Deserialize<IReadOnlyList<CapitalState>>();

			if (values == null) return [];

			return [.. values];
		}

		public async Task<string[]> EntitiesScriptAsync()
		{
			string text = await File.ReadAllTextAsync(deviceInfo.EntitiesScriptPath);

			return text.Split(';', StringSplitOptions.RemoveEmptyEntries);
		}

		public async Task<string[]> MappingScriptsAsync()
		{
			string text = await File.ReadAllTextAsync(deviceInfo.RelationalMappingScriptPath);

			return text.Split(';', StringSplitOptions.RemoveEmptyEntries);
		}

		public async Task<List<State>> GetStateAsync()
		{
			string text = await File.ReadAllTextAsync(deviceInfo.StatesPath);

			IReadOnlyList<StateResponseDto>? values = text.Deserialize<IReadOnlyList<StateResponseDto>>();

			if (values == null) return [];

			return [.. values.Select(
				v => new State {
					Abbreviation = v.Abbreviation,
					Flag = v.Flag,
					Key = v.Key,
					MapLocation = v.MapLocation,
					Name = v.Name,
					Shield = v.Shield
				}
			)];
		}

		public async Task<List<ZipCodeBase>> GetZipCodeBaseAsync()
		{
			Stream stream = await _httpClient.GetStreamAsync("https://www.correosdemexico.gob.mx/datosabiertos/cp/cpdescarga.txt");

			List<ZipCodeBase> records = await addressFileParser.ParseAsync(stream).ToListAsync(CancellationToken.None);

			return records;
		}

		public async Task<string> ZipCodeBaseScript()
		{
			List<ZipCodeBase> zipCodes = await GetZipCodeBaseAsync();

			return Template(zipCodes);
		}

		private string Template<T>(List<T> rows)
		{
			PropertyInfo[] properties = typeof(T).GetProperties();

			string columnNames = string.Join(", ", properties.Select(p => p.Name));

			StringBuilder columnValues = new();
			int count = 0;

			foreach (T row in rows)
			{
				string[] values = [.. properties.Select(p => $"'{p.GetValue(row)}'" ?? string.Empty)];
				string stringValues = string.Join(", ", values);

				columnValues.Append($"({stringValues}){(count < rows.Count - 1 ? "," : string.Empty)}");

				count++;
			}

			return $"INSERT INTO {nameof(ZipCodeBase)} ({columnNames}) VALUES {columnValues}";
		}
	}
}