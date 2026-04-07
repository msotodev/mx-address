namespace mxaddress.Domain.Entities
{
	public class Settlement : Entity
	{
		public string Name { get; set; } = string.Empty;

		public int ZipCodeId { get; set; }
	}
}