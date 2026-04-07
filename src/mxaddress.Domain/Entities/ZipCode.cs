namespace mxaddress.Domain.Entities
{
	public class ZipCode : Entity
	{
		public string Code { get; set; } = string.Empty;

		public string StateName { get; set; } = string.Empty;

		public string MunicipalityName { get; set; } = string.Empty;

		public string LocalityName { get; set; } = string.Empty;
	}
}