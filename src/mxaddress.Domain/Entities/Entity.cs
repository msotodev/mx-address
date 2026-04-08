using SQLite;

namespace mxaddress.Domain.Entities
{
	public class Entity
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
    }
}