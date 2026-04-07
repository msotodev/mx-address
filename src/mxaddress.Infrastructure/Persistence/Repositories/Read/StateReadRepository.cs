using EssentialLayer.SQLite.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using mxaddress.Application.Dtos;
using mxaddress.Application.Features.States.Interfaces;
using static mxaddress.Application.Constants.DefaultConstant;

namespace mxaddress.Infrastructure.Persistence.Repositories.Read
{
	internal class StateReadRepository(
		[FromKeyedServices(LOCAL_DB)] IQueryDatabaseService queryDatabase
	) : IStateReadRepository
	{
		private const string EntityName = "State";

		public Task<IReadOnlyList<StateResponseDto>> GetAllAsync()
		{
			IReadOnlyList<StateResponseDto> result = queryDatabase.Query<StateResponseDto>(
				$@"SELECT Id, Name, Abbreviation, Mnemonic FROM {EntityName}"
			);

			return Task.FromResult(result);
		}

		public Task<StateResponseDto?> GetByNameAsync(string name)
		{
			StateResponseDto? first = queryDatabase.QueryFirst<StateResponseDto>(
				$@"SELECT * FROM {EntityName}", name
			);

			return Task.FromResult(first);
		}
	}
}