namespace mxaddress.Application.Dtos
{
	public class StateResponseDto
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Mnemonic { get; set; } = string.Empty;

		public string Abbreviation { get; set; } = string.Empty;
	}
}