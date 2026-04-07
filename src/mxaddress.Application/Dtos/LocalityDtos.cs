namespace mxaddress.Application.Dtos
{
	public class LocalityResponseDto
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string? ZipCode { get; set; }
	}
}