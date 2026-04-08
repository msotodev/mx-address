namespace mxaddress.Domain.Entities
{
	public class Municipality : Entity
	{
		public string Name { get; set; } = string.Empty;

		public string Key { get; set; } = string.Empty;

		public int StateId { get; set; }
	}
}