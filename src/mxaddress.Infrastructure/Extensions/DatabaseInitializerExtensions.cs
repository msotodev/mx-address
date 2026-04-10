using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Abstractions;

namespace mxaddress.Infrastructure.Extensions
{
	public static class DatabaseInitializerExtensions
	{
		public static async Task InitializeDatabaseAsync(
			this IServiceProvider services
		)
		{
			using IServiceScope scope = services.CreateScope();

			IDatabaseInitializer initializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();

			await initializer.InitializeAsync();
		}
	}
}