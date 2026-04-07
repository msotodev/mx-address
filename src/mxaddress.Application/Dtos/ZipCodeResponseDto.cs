namespace mxaddress.Application.Dtos
{
	public class ZipCodeResponseDto
	{
		public string Code { get; set; } = string.Empty;

		public int StateId { get; set; }

		public string StateName { get; set; } = string.Empty;

		public int MunicipalityId { get; set; }

		public string MunicipalityName { get; set; } = string.Empty;

		public int LocalityId { get; set; }

		public string LocalityName { get; set; } = string.Empty;
	}
}