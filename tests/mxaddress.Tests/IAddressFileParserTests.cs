using Moq;
using mxaddress.Application.Abstractions;
using mxaddress.Domain.Entities;
using System.Text;

namespace mxaddress.Tests
{
	public class IAddressFileParserTests
	{
		private readonly Mock<IAddressFileParser> _mockService = new();

		[Fact]
		public async Task ParseAsync()
		{
			// ARRANGE
			// d_codigo | d_asenta | d_tipo_asenta | D_mnpio | d_estado | d_ciudad | d_CP | c_estado | c_oficina | c_CP | c_tipo_asenta | c_mnpio | id_asenta_cpcons | d_zona | c_cve_ciudad
			string fakeText = "01000|San Ángel|Colonia|Álvaro Obregón|Ciudad de México|Ciudad de México|01001|09|01001||09|010|0001|Urbano|01";

			Stream fakeStream = new MemoryStream();

			fakeStream.Write(Encoding.UTF8.GetBytes(fakeText));

			_mockService.Setup(x => x.ParseAsync(fakeStream)).Returns(
				new List<ZipCodeBase>
				{
					new () {
						Code = "01000",
						SettlementName = "San Ángel",
						SettlementTypeName = "Colonia",
						MunicipalityName = "Álvaro Obregón",
						StateName = "Ciudad de México",
						CityName = "Ciudad de México",
						ZipCodeAddress = "01001",
						StateKey = "09",
						OfficeZipCode = "01001",
						ZipCodeKey = "010",
						SettlementTypeCode = "09",
						MunicipalityKey = "010",
						UniqueSettlementIdentifier = "0001",
						ZoneAddress = "Urbano",
						CityKey = "01"
					}
				}.ToAsyncEnumerable()
			);

			// ACT
			List<ZipCodeBase> result = await _mockService.Object.ParseAsync(
				fakeStream
			).ToListAsync(CancellationToken.None);

			// ASSERT
			Assert.Single(result);
			Assert.Equal("01000", result[0].Code);
			Assert.Equal("San Ángel", result[0].SettlementName);
		}
	}
}
