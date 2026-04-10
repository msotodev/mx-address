namespace mxaddress.Domain.Entities
{
	public class State : Entity
	{
		public string Name { get; set; } = string.Empty;

		public string Key { get; set; } = string.Empty;
		
		public string Abbreviation { get; set; } = string.Empty;

		public string Shield { get; set; } = string.Empty;

		public string Flag { get; set; } = string.Empty;

		public string MapLocation { get; set; } = string.Empty;
	}
}