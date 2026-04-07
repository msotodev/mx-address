namespace mxaddress.Domain.Entities
{
	public class State : Entity
	{
		public string Name { get; set; } = string.Empty;

		public string Mnemonic { get; set; } = string.Empty;

		public string Abbreviation { get; set; } = string.Empty;
	}
}