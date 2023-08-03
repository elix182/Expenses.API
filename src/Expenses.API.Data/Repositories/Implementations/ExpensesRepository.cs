using Dapper;
using Expenses.API.Data.Models;
using Expenses.API.Data.Providers;
using MySql.Data.MySqlClient;

namespace Expenses.API.Data.Repositories
{
    public class ExpensesRepository : IExpensesRepository
	{
        private readonly DatabaseConnectionProvider _connectionProvider;
		public ExpensesRepository(DatabaseConnectionProvider connectionProvider)
		{
            _connectionProvider = connectionProvider;
		}

        public async Task CreateExpense(ExpenseEntity expense)
        {
            using var con = new MySqlConnection(_connectionProvider.ExpensesDB);
            string sql = "INSERT INTO expenses (description, amount, date, inserted_date, inserted_by) VALUES (@Description, @Amount, @Date, @InsertedDate, @InsertedBy)";
            var result = await con.ExecuteAsync(sql, expense);
        }

        public async Task DeleteExpense(Guid expenseUid)
        {
            using var con = new MySqlConnection(_connectionProvider.ExpensesDB);
            string sql = "DELETE FROM expenses WHERE expense_uid = @expenseUid";
            var queryParams = new
            {
                expenseUid
            };
            var result = await con.ExecuteAsync(sql, queryParams);
        }

        public async Task<IEnumerable<ExpenseEntity>> FindAll()
        {
            using var con = new MySqlConnection(_connectionProvider.ExpensesDB);
            string sql = "SELECT * FROM expenses";
            var result = await con.QueryAsync<ExpenseEntity>(sql);
            return result;
        }

        public async Task<ExpenseEntity> GetExpense(Guid expenseUid)
        {
            using var con = new MySqlConnection(_connectionProvider.ExpensesDB);
            string sql = "SELECT * FROM expenses WHERE expense_uid = @expenseUid";
            var queryParams = new
            {
                expenseUid
            };
            var result = await con.QueryFirstOrDefaultAsync<ExpenseEntity>(sql, queryParams);
            return result;
        }

        public async Task UpdateExpense(Guid expenseUid, ExpenseEntity data)
        {
            using var con = new MySqlConnection(_connectionProvider.ExpensesDB);
            string sql = "UPDATE expenses SET description = @Description, amount = @Amount, date = @Date, updated_date = @UpdatedDate, updated_by = @UpdatedBy WHERE expense_uid = @expenseUid";
            var queryParams = new
            {
                expenseUid,
                data.Description,
                data.Amount,
                data.Date,
                data.UpdatedDate,
                data.UpdatedBy
            };
            var result = await con.ExecuteAsync(sql, queryParams);
        }
    }
}

