namespace mxaddress.Domain.Entities
{
	public class Municipality : Entity
	{
		public string Name { get; set; } = string.Empty;

		public int Code { get; set; }

		public int StateId { get; set; }
	}
}