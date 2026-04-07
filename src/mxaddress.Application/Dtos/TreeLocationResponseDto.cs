namespace mxaddress.Application.Dtos
{
	public class TreeLocationRequestDto
	{
		public int StateId { get; set; }
	}

	public class TreeLocationResponseDto
	{
		public int StateId { get; set; }

		public string StateName { get; set; } = string.Empty;

		public int MunicipalityId { get; set; }

		public string MunicipalityName { get; set; } = string.Empty;

		public int LocalityId { get; set; }

		public string LocalityName { get; set; } = string.Empty;

		public int ZipCodeId { get; set; }

		public string ZipCodeName { get; set; } = string.Empty;

		public int SettlementId { get; set; }

		public string SettlementName { get; set; } = string.Empty;
	}
}