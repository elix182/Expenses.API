using Expenses.API.Data.Providers;
using Expenses.API.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.API.Data
{
    public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddExpensesDatabaseServices(this IServiceCollection services)
		{
			services.AddSingleton<DatabaseConnectionProvider>();
			services.AddScoped<IExpensesRepository, ExpensesRepository>();
			ServiceTypeHandlers.ConfigureTypeHandlers();
            return services;
		}
    }
}

