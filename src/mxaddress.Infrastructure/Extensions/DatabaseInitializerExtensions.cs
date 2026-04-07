using Microsoft.Extensions.DependencyInjection;
using mxaddress.Infrastructure.Persistence.Initialization;

namespace mxaddress.Infrastructure.Extensions
{
	public static class DatabaseInitializerExtensions
	{
		public static async Task InitializeDatabaseAsync(
			this IServiceProvider services
		)
		{
			using IServiceScope scope = services.CreateScope();

			DatabaseInitializer initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();

			await initializer.InitializeAsync();
		}
	}
}