namespace mxaddress.Application.Abstractions
{
	public interface IDatabaseInitializer
	{
		Task InitializeAsync();
	}
}