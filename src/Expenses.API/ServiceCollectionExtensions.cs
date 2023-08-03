using Expenses.API.Services;
using Expenses.API.Data;

namespace Expenses.API
{
    public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddExpensesServices(this IServiceCollection services)
		{
			services.AddExpensesDatabaseServices();
			services.AddScoped<IExpensesService, ExpensesService>();
            return services;
		}
    }
}

