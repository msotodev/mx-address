namespace mxaddress.Domain.Entities
{
	public class ZipCode : Entity
	{
		public string Code { get; set; } = string.Empty;

		public int StateId { get; set; }

		public int MunicipalityId { get; set; }

		public int SettlementId { get; set; }

		public int CityId { get; set; }

		public bool IsUrban { get; set; }
	}
}