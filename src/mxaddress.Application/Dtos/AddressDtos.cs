namespace mxaddress.Application.Dtos
{
	public class AddressResponseDto
	{
		public string ZipCode { get; set; } = string.Empty;

		public string SettlementName { get; set; } = string.Empty;

		public string SettlementTypeName { get; set; } = string.Empty;

		public string MunicipalityName { get; set; } = string.Empty;

		public string StateName { get; set; } = string.Empty;

		public string CityName { get; set; } = string.Empty;

		public string Zone { get; set; } = string.Empty;
	}
}