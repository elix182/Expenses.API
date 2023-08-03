using Microsoft.Extensions.Configuration;

namespace Expenses.API.Data.Providers
{
	public class DatabaseConnectionProvider
	{
		private readonly IConfiguration _configuration;

		public DatabaseConnectionProvider(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string ExpensesDB
		{
			get => _configuration.GetConnectionString("ExpensesDB") ?? "";
        }
	}
}

