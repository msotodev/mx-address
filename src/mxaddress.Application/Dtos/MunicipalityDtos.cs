namespace mxaddress.Application.Dtos
{
	public class MunicipalityResponseDto
	{
		public int Id { get; set; }

		public string Key { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		public int StateId { get; set; }

		public string StateName { get; set; } = string.Empty;
	}
}