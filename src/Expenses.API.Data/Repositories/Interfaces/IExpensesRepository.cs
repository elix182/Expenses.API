using Expenses.API.Data.Models;

namespace Expenses.API.Data.Repositories
{
    public interface IExpensesRepository
	{
		Task<IEnumerable<ExpenseEntity>> FindAll();
        Task CreateExpense(ExpenseEntity expense);
		Task<ExpenseEntity> GetExpense(Guid expenseUid);
		Task UpdateExpense(Guid expenseUid, ExpenseEntity data);
		Task DeleteExpense(Guid expenseUid);
    }
}

