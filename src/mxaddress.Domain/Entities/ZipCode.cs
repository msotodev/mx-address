namespace mxaddress.Domain.Entities
{
	public class ZipCode : Entity
	{
		public string Code { get; set; } = string.Empty;

		public int StateId { get; set; }

		public int MunicipalityId { get; set; }

		public int SettlementId { get; set; }

		public string ZipCodeAddress { get; set; } = string.Empty;

		public string OfficeZipCode { get; set; } = string.Empty;

		public string CityName { get; set; } = string.Empty;

		public string ZoneAddress { get; set; } = string.Empty;

		public string CityKey { get; set; } = string.Empty;
	}
}