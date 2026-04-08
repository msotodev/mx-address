namespace mxaddress.Application.Dtos
{
	public class StateResponseDto
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Abbreviation { get; set; } = string.Empty;

		public string Shield { get; set; } = string.Empty;

		public string Flag { get; set; } = string.Empty;

		public string MapLocation { get; set; } = string.Empty;
	}
}