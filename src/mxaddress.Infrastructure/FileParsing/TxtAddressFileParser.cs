using mxaddress.Application.Abstractions;
using mxaddress.Domain.Entities;
using System.Text;

namespace mxaddress.Infrastructure.FileParsing
{
	internal class TxtAddressFileParser : IAddressFileParser
	{
		public async IAsyncEnumerable<ZipCode> ParseAsync(Stream stream)
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			using StreamReader reader = new(stream, Encoding.GetEncoding(1252));
			int numberOfLine = 0;

			while (!reader.EndOfStream)
			{
				string? line = await reader.ReadLineAsync();

				if (string.IsNullOrWhiteSpace(line)) continue;

				numberOfLine++;

				if (numberOfLine <= 2) continue;  // 1. Legend 2. header

				string[] columns = line.Split('|');

				if (columns.Length == 0) continue;

				// d_codigo | d_asenta | d_tipo_asenta | D_mnpio | d_estado | d_ciudad | d_CP | c_estado | c_oficina | c_CP | c_tipo_asenta | c_mnpio | id_asenta_cpcons | d_zona | c_cve_ciudad
				// 01000|San Ángel|Colonia|Álvaro Obregón|Ciudad de México|Ciudad de México|01001|09|01001||09|010|0001|Urbano|01

				yield return new ZipCode
				{
					Code = Format(columns[0]),
					LocalityName = Format(columns[5]),
					MunicipalityName = Format(columns[3]),
					StateName = Format(columns[4])
				};
			}
		}

		private static string Format(string value) => value.Trim();
	}
}