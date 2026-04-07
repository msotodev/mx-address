namespace mxaddress.Domain.Entities
{
	public class Locality : Entity
	{
		public string Name { get; set; } = string.Empty;

		public string Code { get; set; } = string.Empty;

		public int StateId { get; set; }
	}
}