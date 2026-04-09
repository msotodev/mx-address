namespace mxaddress.Application.Dtos
{
	public class ZipCodeResponseDto
	{
		public string Code { get; set; } = string.Empty;

		public int StateId { get; set; }

		public string StateName { get; set; } = string.Empty;

		public int MunicipalityId { get; set; }

		public string MunicipalityName { get; set; } = string.Empty;

		public int SettlementId { get; set; }

		public string SettlementName { get; set; } = string.Empty;

		public int CityId { get; set; }

		public string CityName { get; set; } = string.Empty;

		public string Zone { get; set; } = string.Empty;
	}
}